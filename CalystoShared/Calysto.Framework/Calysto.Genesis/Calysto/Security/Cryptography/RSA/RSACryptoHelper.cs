#if !SILVERLIGHT

using Calysto.Common;
using Calysto.IO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

/// <summary>
/// Key generation is slow. 
/// Use System.Security.Cryptography.RSACryptoServiceProvider instead which works on .NET Core 3 (core 2.2 is not supported)
/// Example is in UnitTest project, class RSACryptoHelperTests
/// </summary>
namespace Calysto.Security.Cryptography.RSA
{
	public class RSACryptoHelper
	{
		#region encrypt method

		public static byte[] Encrypt(byte[] data, RSASecretKey key)
		{
			if (!key.HasPublicKey)
				throw new InvalidOperationException("Public key not found.");

			int digitSize = key.n.GetDigitSize();
			int chunkSize = digitSize -11; // 11 byte for padding if used, else chunkSize = digitSize

			// split into parts:
			List<byte[]> parts = new MemoryStream(data).SplitToParts(chunkSize).ToList();

			byte[] encryptedBytes = new byte[parts.Count * digitSize];
			// encrypt parts
			for(int n = 0; n < parts.Count; n++)
			{
				BigInteger biData = new BigInteger(parts[n]);
				BigInteger biEncrypted = biData.modPow(key.e, key.n);
				byte[] tmp = biEncrypted.ToBytes();
				if(tmp.Length < digitSize)
				{
					Array.Resize(ref tmp, digitSize);
				}
				Array.Copy(tmp, 0, encryptedBytes, n * digitSize, digitSize);
			}
			return encryptedBytes;
		}

		#endregion

		#region decrypt methods

		public static byte[] Decrypt(byte[] cipherData, RSASecretKey key)
		{
			if (!key.HasPrivateKey)
				throw new InvalidOperationException("Private key not found.");

			int digitSize = key.n.GetDigitSize();

			if (cipherData.Length % digitSize != 0)
			{
				return null; // invalid length
			}

			List<byte[]> parts = new MemoryStream(cipherData).SplitToParts(digitSize).ToList(); // RSA encrypted block == digitSaze
			List<byte[]> decryptedList = new List<byte[]>();

			int decryptedLenth = 0;

			for (int n = 0; n < parts.Count; n++)
			{
				BigInteger biChiper = new BigInteger(parts[n]);
				BigInteger biData = biChiper.modPow(key.d, key.n);
				byte[] tmp = biData.ToBytes();
				decryptedLenth += tmp.Length;
				decryptedList.Add(tmp);
			}

			int destIndex = 0;
			byte[] decryptedData = new byte[decryptedLenth]; 
			foreach(byte[] decData in decryptedList)
			{
				Array.Copy(decData, 0, decryptedData, destIndex, decData.Length);
				destIndex += decData.Length;
			}
			return decryptedData;

		}

		#endregion

		#region sign & verify

		/// <summary>
		/// Sign (encrypt) hash using private key. Returns signature.
		/// </summary>
		/// <param name="hash"></param>
		/// <returns></returns>
		public static byte[] Sign(byte[] hash, RSASecretKey key)
		{
			// encrypt hash using private key
			RSASecretKey skey = new RSASecretKey();
			skey.e = key.d; // use private key to encrypt data
			skey.n = key.n; // modulus
			return Encrypt(hash, skey);
		}

		/// <summary>
		/// Verify hash using public key. Decrypt signature using public key and compare it with hash.
		/// </summary>
		/// <param name="hash"></param>
		/// <param name="signature"></param>
		/// <returns></returns>
		public static bool Verify(byte[] hash, byte[] signature, RSASecretKey key)
		{
			// decrypt signature using public key
			RSASecretKey skey = new RSASecretKey();
			skey.d = key.e; // use public key to decrypt data
			skey.n = key.n;
			byte[] decrypted = Decrypt(signature, skey);
			if (decrypted == null || hash == null)
			{
				return false;
			}
			else
			{
				return Convert.ToBase64String(decrypted) == Convert.ToBase64String(hash);
			}
		}

		#endregion

	}

}
#endif
