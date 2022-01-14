using Calysto.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calysto.Security.Cryptography
{
	/// <summary>
	/// Simple encrypter. Creates remaping table 256 bytes to 256 bytes.
	/// </summary>
	public class CalystoEncrypter
	{
		const string _passConst = "!(&#@`#)#$%^*(_+~`";
		Dictionary<byte, byte> _dicEncryption;
		Dictionary<byte, byte> _dicDecryption;

		private void CreateKeys(string password)
		{
			password += _passConst;

			var list1 = password.Cycle().Select((ch, fromByte) => new
			{
				ch = (int)ch,
				fromByte
			}).Take(256)
			.OrderBy(o => o.ch)
			.Select((o, toByte) => new
			{
				o.ch,
				o.fromByte,
				toByte
			}).ToList();

			_dicEncryption = list1.OrderBy(o=>o.fromByte).ToDictionary(o => (byte)o.fromByte, o => (byte)o.toByte); // key is source byte, value is destination byte
			_dicDecryption = list1.OrderBy(o=>o.toByte).ToDictionary(o => (byte)o.toByte, o => (byte)o.fromByte); // key is source byte, value is destination byte
			
		}

		public CalystoEncrypter(string password)
		{
			CreateKeys(password);
		}

		public byte[] Encrypt(byte[] rawData)
		{
			return rawData.Select(o => _dicEncryption[o]).ToArray();
		}

		public byte[] Encrypt(string rawString)
		{
			return this.Encrypt(Encoding.UTF8.GetBytes(rawString));
		}

		public byte[] Decrypt(byte[] encryptedData)
		{
			return encryptedData.Select(o => _dicDecryption[o]).ToArray();
		}

		public string DecryptToString(byte[] encryptedData)
		{
			return Encoding.UTF8.GetString(this.Decrypt(encryptedData));
		}

	}
}
