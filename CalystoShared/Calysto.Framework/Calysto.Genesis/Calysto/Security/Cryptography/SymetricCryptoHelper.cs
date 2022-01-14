using System;
using System.Text;
using System.Security.Cryptography;

namespace Calysto.Security.Cryptography
{

	#region SymetricCryptoHelper class

	public abstract class SymetricCryptoHelper : IDisposable
	{
		private SymmetricAlgorithm _serviceProvider = null;

		protected SymetricCryptoHelper()
		{
		}

		/// <summary>
		/// Creates IV and key from password.
		/// </summary>
		/// <param name="password"></param>
		protected SymetricCryptoHelper(string password, SymmetricAlgorithm serviceProvider)
		{
			_serviceProvider = serviceProvider;
			byte[] hash = new System.Security.Cryptography.SHA256Managed().ComputeHash(Encoding.UTF8.GetBytes(password));
			byte[] keyIV = new byte[_serviceProvider.IV.Length]; // AES length: 16
			byte[] key = new byte[_serviceProvider.Key.Length]; // AES length: 32
			Array.Copy(hash, keyIV, keyIV.Length);
			Array.Reverse(hash);
			Array.Copy(hash, key, key.Length); // ako je hash prekratak, ovdje baci exception
			InitializeKeys(keyIV, key);
		}

		/// <summary>
		/// Accepts base64 encoded keys.
		/// </summary>
		/// <param name="keyIV"></param>
		/// <param name="key"></param>
		protected SymetricCryptoHelper(string keyIV, string key, SymmetricAlgorithm serviceProvider)
		{
			_serviceProvider = serviceProvider;
			InitializeKeys(Convert.FromBase64String(keyIV), Convert.FromBase64String(key));
		}

		private void InitializeKeys(byte[] keyIV, byte[] key)
		{
			_serviceProvider.IV = keyIV;
			_serviceProvider.Key = key;
		}

		public byte[] Encrypt(byte[] data)
		{
			return _serviceProvider.CreateEncryptor().TransformFinalBlock(data, 0, data.Length);
		}

		public byte[] Encrypt(string plainText)
		{
			return Encrypt(Encoding.UTF8.GetBytes(plainText));
		}

		/// <summary>
		/// Throw exception if not successful
		/// </summary>
		/// <param name="cipherBytes"></param>
		/// <returns></returns>
		public byte[] Decrypt(byte[] cipherBytes)
		{
			return _serviceProvider.CreateDecryptor().TransformFinalBlock(cipherBytes, 0, cipherBytes.Length);
		}

		/// <summary>
		/// Throw exception if not successful
		/// </summary>
		/// <param name="chipperBytes"></param>
		/// <returns></returns>
		public string DecryptToString(byte[] chipperBytes)
		{
			byte[] data = Decrypt(chipperBytes);
			return Encoding.UTF8.GetString(data, 0, data.Length);
		}

		public void Dispose()
		{
			try { _serviceProvider?.Dispose(); } catch { }
			_serviceProvider = null;
		}

		~SymetricCryptoHelper() => this.Dispose();
	}

	#endregion

	#region AESCryptoHelper class

	public class AESCryptoHelper : SymetricCryptoHelper
	{
		/// <summary>
		/// Creates IV and key from password.
		/// </summary>
		/// <param name="password"></param>
		public AESCryptoHelper(string password)
			: base(password, new AesManaged())
		{
			
		}
	}

	#endregion

#if !SILVERLIGHT
	#region DESCryptoHelper class

	public class DESCryptoHelper : SymetricCryptoHelper
	{
		/// <summary>
		/// Creates IV and key from password.
		/// </summary>
		/// <param name="password"></param>
		public DESCryptoHelper(string password)
			: base(password, new DESCryptoServiceProvider())
		{

		}
	}

	#endregion

	#region TripleDESCryptoHelper class

	public class TripleDESCryptoHelper : SymetricCryptoHelper
	{
		/// <summary>
		/// Creates IV and key from password.
		/// </summary>
		/// <param name="password"></param>
		public TripleDESCryptoHelper(string password)
			: base(password, new TripleDESCryptoServiceProvider())
		{

		}
	}

	#endregion
#endif

}