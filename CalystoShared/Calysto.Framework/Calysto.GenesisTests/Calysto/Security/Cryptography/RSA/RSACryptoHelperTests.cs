using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calysto.Security.Cryptography.RSA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace Calysto.Security.Cryptography.RSA.Tests
{
	[TestClass()]
	public class RSACryptoHelperTests
	{
		[TestMethod()]
		public void RSACryptoHelperTest1()
		{
			// works with .NET Core all versions

			RSASecretKey key = RSASecretKey.GenerateKeys();
			string publicXml = key.ExportXmlKeys(false);
			string privateXml = key.ExportXmlKeys(true);

			RSASecretKey publicKey = RSASecretKey.FromXmlKeys(publicXml);
			RSASecretKey privateKey = RSASecretKey.FromXmlKeys(privateXml);

			string str1 = "how nice, 23 degrees";

			byte[] encrypted1 = RSACryptoHelper.Encrypt(Encoding.UTF8.GetBytes(str1), publicKey);

			byte[] decrypted1 = RSACryptoHelper.Decrypt(encrypted1, privateKey);

			string result1 = Encoding.UTF8.GetString(decrypted1);

			// sometimes result is invalid
			Assert.AreEqual(str1, result1);
		}

		[TestMethod()]
		public void RSACryptoServiceProviderTest1()
		{
			// works with .NETCore 3 (.NETCore 2.2 or lower is not supported)
			var provider = RSACryptoServiceProvider.Create();
			string publicXml = provider.ToXmlString(false); 
			string privateXml = provider.ToXmlString(true);

			var publicProvider = RSACryptoServiceProvider.Create();
			publicProvider.FromXmlString(publicXml);

			var privateProvider = RSACryptoServiceProvider.Create();
			privateProvider.FromXmlString(privateXml);

			string str1 = "how nice, 23 degrees";

			byte[] encrypted1 = publicProvider.Encrypt(Encoding.UTF8.GetBytes(str1), RSAEncryptionPadding.Pkcs1);

			byte[] decrypted1 = privateProvider.Decrypt(encrypted1, RSAEncryptionPadding.Pkcs1);

			string result1 = Encoding.UTF8.GetString(decrypted1);

			Assert.AreEqual(str1, result1);
		}
	}
}