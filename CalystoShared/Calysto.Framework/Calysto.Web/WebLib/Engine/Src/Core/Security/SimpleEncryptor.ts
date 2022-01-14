namespace Calysto.Security.Cryptography
{
	export class SimpleEncryptor
	{
		/**
		 * Simple encrypter. Creates remaping table 256 bytes to 256 bytes.
		 * @param password
		 */
		constructor(password: string)
		{
			let _passConst = "!(&#@`#)#$%^*(_+~`";

			password += _passConst;

			var list1 = password.ToCharArray().AsEnumerable().Cycle(1000).Select((ch, fromByte) =>
			({
					ch: ch.charCodeAt(0),
					fromByte: fromByte
			})).Take(256)
				.OrderBy(o => o.ch)
				.Select((o, toByte) =>
					({
						ch: o.ch,
						fromByte: o.fromByte,
						toByte: toByte
					})).ToList();

			// key must be string, if key is int, it won't work
			this._dicEncryption = list1.AsEnumerable().ToDictionary(o => o.fromByte + "_", o => o.toByte).ToRawObject(true); // key is source byte, value is destination byte
			this._dicDecryption = list1.AsEnumerable().ToDictionary(o => o.toByte + "_", o => o.fromByte).ToRawObject(true); // key is source byte, value is destination byte
		}

		private _dicEncryption: { [key: string]: number; };
		private _dicDecryption: { [key: string]: number; };

		public Encrypt(rawData: string | number[])
		{
			/// <summary>
			/// byte[] to be encrypted, returns encrypted byte[]
			/// </summary>
			/// <param name="rawData" type="Array|String">byte[] or string</param>
			if (typeof (rawData) == "string")
			{
				rawData = Calysto.Utility.Encoding.UTF8.GetBytes(rawData);
			}

			return rawData.AsEnumerable().Select(o => this._dicEncryption[o + "_"]).ToArray();
		};

		public Decrypt(encryptedData: number[])
		{
			/// <summary>
			/// byte[] encrypted data, returns decrypted byte[]
			/// </summary>
			/// <param name="encryptedData" type="Array">byte[]</param>

			return encryptedData.AsEnumerable().Select(o => this._dicDecryption[o + "_"]).ToArray();
		}

		public DecryptToString(encryptedData: number[])
		{
			/// <summary>
			/// byte[] encrypted data, returns decrypted string
			/// </summary>
			/// <param name="encryptedData" type="Array">byte[]</param>
			return Calysto.Utility.Encoding.UTF8.GetString(this.Decrypt(encryptedData));
		}

	}
}
