#if !SILVERLIGHT

using Calysto.Common;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Calysto.Security.Cryptography.RSA
{

	public class RSASecretKey
	{
		// private key: d, n
		// pubilc key: e, n

		/// <summary>
		/// Modulus - used for private and public key.
		/// </summary>
		public BigInteger n;	    // public modulus
		/// <summary>
		/// Exponent - public key.
		/// </summary>
		public BigInteger e;	    // public exponent
		/// <summary>
		/// D - Private key.
		/// </summary>
		public BigInteger d;	    // private exponent
		/// <summary>
		/// Prime P
		/// </summary>
		public BigInteger p;	    // prime  p. // not required
		/// <summary>
		/// Prime Q
		/// </summary>
		public BigInteger q;	    // prime  q. // not required
		/// <summary>
		/// Inverse of P mod Q
		/// </summary>
		public BigInteger u;	    // inverse of p mod q. // not requeired

		#region public properties

		public bool HasPublicKey
		{
			get { return ( Object.ReferenceEquals( this.e , null) == false && Object.ReferenceEquals(this.n, null) == false); }
		}


		public bool HasPrivateKey
		{
			get { return (Object.ReferenceEquals(this.d, null) == false && Object.ReferenceEquals(this.n, null) == false); }
		}

		#endregion

		#region private methods

		private static BigInteger GetBi(byte[] data)
		{
			if (data == null)
				return null;
			else
				return new BigInteger(data);
		}

		#endregion

		#region constructors

		public RSASecretKey()
		{
		}

		#endregion

		#region Key generator

		/// <summary>
		/// Default key size: 1024, use internal BigInteger to generate keys.
		/// </summary>
		/// <returns></returns>
		public static RSASecretKey GenerateKeys()
		{
			return GenerateKeys(1024);
		}

		public static RSASecretKey GenerateKeys(int nbits, bool useMSRSACryptoProvider)
		{
			if (useMSRSACryptoProvider)
			{
				System.Security.Cryptography.RSACryptoServiceProvider rsa = new System.Security.Cryptography.RSACryptoServiceProvider(nbits);
				System.Security.Cryptography.RSAParameters par = rsa.ExportParameters(true);
				RSASecretKey skey = new RSASecretKey();
				skey.e = new BigInteger(par.Exponent);
				skey.d = new BigInteger(par.D);
				skey.n = new BigInteger(par.Modulus);

				skey.p = new BigInteger(par.P); // not required
				skey.q = new BigInteger(par.Q); // not required
				return skey;
			}
			else
			{
				return GenerateKeys(nbits);
			}
		}

		public static RSASecretKey GenerateKeys(int nbits)
		{
			BigInteger p, q; /* the two primes */
			BigInteger d;    /* the private key */
			BigInteger u;
			BigInteger t1, t2;
			BigInteger n = new BigInteger();    /* the public key */
			BigInteger e;    /* the exponent */
			BigInteger phi;  /* helper: (p-1)(q-1) */
			BigInteger g;
			BigInteger f;
			CalystoRandom rand = new CalystoRandom();

			if ((nbits < 768) || (nbits > 4096))
				throw new ArgumentException("Only keysizes betwen 768 and 4096 bit are allowed!");

			/* make sure that nbits is even so that we generate p, q of equal size */
			if ((nbits & 1) == 1)
				nbits++;

			do
			{
				/* select two (very secret) primes */
				p = new BigInteger();
				q = new BigInteger();

				p = BigInteger.genPseudoPrime(nbits / 2, 10, rand);
				q = BigInteger.genPseudoPrime(nbits / 2, 10, rand);

				/* p shall be smaller than q (for calc of u)*/
				if (q > p)
				{
					BigInteger tmp = p;
					p = q;
					q = tmp;
				}

				/* calculate the modulus */
				n = p * q;
			} while (n.bitCount() != nbits);

			/* calculate Euler totient: phi = (p-1)(q-1) */
			t1 = p - new BigInteger(1);
			t2 = q - new BigInteger(1);
			phi = t1 * t2;

			g = t1.gcd(t2);
			f = phi / g;

			/* find an public exponent.
			We use 41 as this is quite fast and more secure than the
			commonly used 17.
			*/

			e = new BigInteger(41);
			t1 = e.gcd(phi);
			if (t1 != new BigInteger(1))
			{
				e = new BigInteger(257);
				t1 = e.gcd(phi);
				if (t1 != new BigInteger(1))
				{
					e = new BigInteger(65537);
					t1 = e.gcd(phi);

					/* (while gcd is not 1) */
					while (t1 != new BigInteger(1))
					{
						e += 2;
						t1 = e.gcd(phi);
					}
				}
			}

			/* calculate the secret key d = e^1 mod phi */
			d = e.modInverse(f);

			/* calculate the inverse of p and q (used for chinese remainder theorem)*/
			u = p.modInverse(q);

			RSASecretKey sk = new RSASecretKey();

			sk.n = n;
			sk.e = e;
			sk.p = p;
			sk.q = q;
			sk.d = d;
			sk.u = u;

			//this.biGeneratedKey = ParseSecretKey(sk);

			return sk;// this.biGeneratedKey;

			/* now we can test our keys (this should never fail!) */
			// test_keys( sk, nbits - 64 );
		}

		#endregion

		#region export keys

		private static byte[] GetValue(BigInteger bi)
		{
			if (Object.ReferenceEquals(bi, null) == false)
				return bi.ToBytes();
			else
				return null;
		}

		public RSAParameters ExportKeys(bool includePrivateKey)
		{
			RSAParameters rsa = new RSAParameters();
			rsa.Exponent = GetValue(this.e);
			rsa.Modulus = GetValue(this.n);
			if (includePrivateKey)
			{
				rsa.D = GetValue(this.d);
				rsa.Q = GetValue(this.q);
				rsa.P = GetValue(this.p);
			}
			return rsa;
		}

		private void AddXMLNode(StringBuilder sb, byte[] data, string nodeName)
		{
			if (data != null)
			{
				sb.AppendLine("<" + nodeName + ">" + Convert.ToBase64String(data) + "</" + nodeName + ">");
			}
		}

		public string ExportXmlKeys(bool includePrivateKey)
		{
			RSAParameters rsa = this.ExportKeys(includePrivateKey);

			System.Text.StringBuilder sb = new StringBuilder();
			sb.AppendLine("<RSAKeyValue>");

			AddXMLNode(sb, rsa.D, "D");
			AddXMLNode(sb, rsa.DP, "DP");
			AddXMLNode(sb, rsa.DQ, "DQ");
			AddXMLNode(sb, rsa.Exponent, "Exponent");
			AddXMLNode(sb, rsa.InverseQ, "InverseQ");
			AddXMLNode(sb, rsa.Modulus, "Modulus");
			AddXMLNode(sb, rsa.P, "P");
			AddXMLNode(sb, rsa.Q, "Q");

			sb.AppendLine("</RSAKeyValue>");
			return sb.ToString();
		}

		#endregion

		#region import keys

		public static RSASecretKey FromKeys(RSAParameters rsa)
		{
			RSASecretKey key = new RSASecretKey();
			key.d = GetBi(rsa.D);
			key.e = GetBi(rsa.Exponent);
			key.n = GetBi(rsa.Modulus);
			key.p = GetBi(rsa.P);
			key.q = GetBi(rsa.Q);
			return key;
		}

		private static byte[] GetData(System.Xml.XmlDocument doc, string nodeName)
		{
			System.Xml.XmlNode node = doc.SelectSingleNode("//RSAKeyValue/" + nodeName);
			if (node != null)
			{
				try { return Convert.FromBase64String(node.InnerText); } catch { }
			}
			return null;
		}

		private static RSAParameters FromXml(string xmlRsa)
		{
			System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
			doc.LoadXml(xmlRsa);

			RSAParameters rsa = new RSAParameters();
			rsa.D = GetData(doc, "D");
			rsa.DP = GetData(doc, "DP");
			rsa.DQ = GetData(doc, "DQ");
			rsa.Exponent = GetData(doc, "Exponent");
			rsa.InverseQ = GetData(doc, "InverseQ");
			rsa.Modulus = GetData(doc, "Modulus");
			rsa.P = GetData(doc, "P");
			rsa.Q = GetData(doc, "Q");
			return rsa;
		}

		public static RSASecretKey FromXmlKeys(string xmlRsa)
		{
			return FromKeys(FromXml(xmlRsa));
		}

		#endregion



	}
}
#endif
