/// <reference path="Json.Infrastructure.ts" />
namespace Calysto.Json.Infrastructure
{
	export class CalystoJsonSerializer
	{
		private parts: string[] = [];
		private blobs: UidWithBlobType[] = [];
		private indexes: number[] = [];
		private isAsync = false;
		private escapee = escapeeChars;

		public SerializeFunctions = false;

		constructor(isAsync = false)
		{
			this.parts = [];
			this.blobs = [];
			this.indexes = [];
			this.isAsync = !!isAsync;
		}

		private Write(str) { this.parts.push(str); }
		private isArray(v) { return v && typeof v.pop == 'function'; }
		private isDate(v) { return v && typeof v.getFullYear == 'function'; }

		private encodeString(s: string)
		{
			var s1 = s.replace(new RegExp('([\\\\\x00-\x1f\\"])', 'g'), (a, b) =>
			{
				var c = this.escapee[b];
				if (c)
				{
					return c;
				}
				c = b.charCodeAt();
				return "\\u00" +
					Math.floor(c / 16).toString(16) +
					(c % 16).toString(16);
			});

			this.Write('"' + s1 + '"');
		}

		private encodeArray(o, recursionLeft: number)
		{
			this.Write("[");
			var addComma, n, len = o.length, val, vtype;
			for (n = 0; n < len; n++)
			{
				val = o[n];
				vtype = typeof val;
				if (vtype == "undefined")
				{
					// nothing
				}
				else if (vtype == "function" && !this.SerializeFunctions)
				{
					// nothing
				}
				else
				{
					if (addComma)
					{
						this.Write(",");
					}
					if (val === null)
					{
						this.Write("null");
					}
					else
					{
						this.serializeWithCalysto(val, recursionLeft - 1);
					}
					addComma = true;
				}
			}
			this.Write("]");
		}

		private createJsonDateTime(o: Date)
		{
			var obj = new JsonDateTime();
			obj.Date = Date.ToLocalISOTString(o);
			return obj;
		}

		private serializeDate(o: Date)
		{
			// use current date, without time zone info, we add Z, but time zone is ignored
			// this way we send exact date and time as it is visible to user, ignoring client time zone, this way values are presented in GUI
			this.Write(new CalystoJsonSerializer().Serialize(this.createJsonDateTime(o)));
		}

		private createJsonFunction(o: Function)
		{
			let obj = new JsonFunction();
			obj.Function = o + "";
			return obj;
		}

		private serializeFunction(o: Function)
		{
			this.Write(new CalystoJsonSerializer().Serialize(this.createJsonFunction(o)));
		}

		private createBlob(o: Blob)
		{
			if (!this.isAsync)
			{
				throw new Error("Blob type serialization requires async serializer mode");
			}
			// must generate numeric placeholder, when used JSON.stringify, this value is serialized into string, so avoid serializing into string with quotes "...", use number
			var uid = (this.blobs.length + 100 + Math.random()) + ""; // add prefix to make sure the value is changing if random fails :)
			this.blobs.push({ UID: uid, BLOB: o }); // UID is used later in .replace(), so we need string
			return uid;
		}

		private serializeBlob(o: Blob)
		{
			this.Write(this.createBlob(o));
		}

		private async asyncSerializeBlobsAsync(stateObj: SerializerAsyncStateType)
		{
			var item1;
			while(stateObj.blobsCopy && stateObj.blobsCopy.length > 0 && (item1 = stateObj.blobsCopy[++stateObj.currentIndex]))
			{
				var obj = new JsonBlob();
				////obj.DataUrl = null;
				////obj.BlobIndex = null;
				obj.FileName = item1.BLOB.name || item1.BLOB.filename || "";
				obj.MimeType = item1.BLOB.type;
				obj.Size = item1.BLOB.size;

				if (stateObj.useBlobIndex)
				{
					obj.BlobIndex = stateObj.currentIndex;
					stateObj.json = stateObj.json.replace(item1.UID, new CalystoJsonSerializer().Serialize(obj));
				}
				else
				{
					// converting to dataUrl has to be done async
					// encode Blob to dataURL base64
					let result1 = await Calysto.Utility.Blob.BlobToDataUrlAsync(item1.BLOB);

					obj.DataUrl = result1.dataUrl;
					stateObj.json = stateObj.json.replace(item1.UID, new CalystoJsonSerializer().Serialize(obj));
				}
			}

			// complete
			return <AsyncCompleteType>{
				json: stateObj.json,
				blobs: stateObj.pureBlobs
			};
		}

		private serializeWithJsonStringify(objectToSerialize)
		{
			var _reDate = new RegExp("^[\\d]{4}[\\-][\\d]{2}[\\-][\\d]{2}T[\\d]{2}[\\:][\\d]{2}[\\:][\\d]{2}[\\.][\\d]{3}Z$");

			return JSON.stringify(objectToSerialize, (key, value) =>
			{
				let vtype = typeof value;

				if (vtype == "undefined" || value == null)
				{
					return null;
				}
				else if (vtype == "function")
				{
					if (this.SerializeFunctions)
					{
						return this.createJsonFunction(value);
					}
					else
					{
						return value;
					}
				}
				else if (value.constructor == (<any>window).FileList) // VS intellisense doesn't work with instanceof
				{
					var arr: any[] = [];
					for (var n1 = 0; n1 < value.length; n1++)
					{
						arr.push(value[n1]);
					}
					return arr;
				}
				else if (value.constructor == (<any>window).File)
				{
					return this.createBlob(value);
				}
				else if (value.constructor == window.Blob)
				{
					return this.createBlob(value);
				}
				else if (value.constructor == Calysto.DateTime)
				{
					return this.createJsonDateTime(value.ToSystemDate());
				}
				else if (this.isDate(value))
				{
					// stringify doesn't send Date object, but string instead: "2016-07-02T11:08:25.244Z"
					// so, it will never come here
					return this.createJsonDateTime(value);
				}
				else if (typeof (value) == "string" && _reDate.test(value))
				{
					// stringify doesn't send Date object, but string instead: "2016-07-02T11:08:25.244Z"
					return this.createJsonDateTime(new Date(value));
				}
				else if (typeof value == "number")
				{
					return isFinite(value) ? value : null;
				}
				else if (this.isArray(value))
				{
					return value;
				}
				else if (value && value["ToArray"])
				{
					return value.ToArray();
				}
				else
				{
					return value;
				}
			});
		}

		private serializeWithCalysto(objectToSerialize, recursionLeft: number)
		{
			///<summary>Serialize object to JSON string.</summary>
			///<param name="objectToSerialize" type="Object|String">Object to serialize</param>
			///<returns type="String|Null">JSON string</returns>

			var o = objectToSerialize;
			let vtype = typeof o;

			if (vtype == "undefined" || o === null)
			{
				return this.Write("null");
			}
			else if (this.isArray(o))
			{
				if (recursionLeft < 1)
				{
					return this.Write("[...]");
				}
				return this.encodeArray(o, recursionLeft - 1);
			}
			else if (o.constructor == Calysto.DateTime)
			{
				return this.serializeDate(o.ToSystemDate());
			}
			else if (o.constructor == (<any>window).FileList) // VS intellisense doesn't work with instanceof
			{
				this.encodeArray(o, recursionLeft - 1);
			}
			else if (o.constructor == (<any>window).File)
			{
				return this.serializeBlob(o);
			}
			else if (o.constructor == (<any>window).Blob)
			{
				return this.serializeBlob(o);
			}
			else if (this.isDate(o))
			{
				return this.serializeDate(o);
			}
			else if (vtype == "function")
			{
				if (this.SerializeFunctions)
				{
					return this.serializeFunction(o);
				}
				else
				{
					return null;
				}
			}
			else if (typeof o == "string")
			{
				return this.encodeString(o);
			}
			else if (typeof o == "number")
			{
				return this.Write(isFinite(o) ? String(o) : "null");
			}
			else if (typeof o == "boolean")
			{
				return this.Write(String(o));
			}
			else if ("ToArray" in o)
			{
				return this.serializeWithCalysto(o.ToArray(), recursionLeft - 1);
			}
			else
			{
				if (recursionLeft < 1)
				{
					return this.Write("{...}");
				}

				this.Write("{");
				var addComma, propName, value;
				for (propName in o)
				{
					try
					{
						if (!o.hasOwnProperty(propName)) continue;

						// must be in try-catch
						// Failed to read the 'responseXML' property from 'XMLHttpRequest': The value is only accessible if the object's 'responseType' is '' or 'document' (was 'text').
						value = o[propName];
					}
					catch (e111)
					{
						continue;
					}

					if (typeof value == "function" && !this.SerializeFunctions)
					{
						// ignore
					}
					else
					{
						if (addComma)
						{
							this.Write(',');
						}
						this.serializeWithCalysto(propName, recursionLeft - 1);
						this.Write(":");
						if (value === null || typeof (value) == "undefined" || value == NaN)
						{
							this.Write("null");
						}
						else
						{
							this.serializeWithCalysto(value, recursionLeft - 1);
						}
						addComma = true;
					}
				}

				return this.Write("}");
			}
		}

		private serializeObject(objectToSerialize, recursionLimit: number)
		{
			// stringify doesn't have recursion limit

			if ((<any>window).JSON && !recursionLimit)
			{
				return this.serializeWithJsonStringify(objectToSerialize);
			}
			else // use Calysto serializer
			{
				this.serializeWithCalysto(objectToSerialize, recursionLimit);
				return this.parts.join("");
			}
		}

		public async SerializeAsync(objectToSerialize: any, recursionLimit: number, useBlobIndex: boolean)
		{
			/// <summary>
			/// Serialize Blobs
			/// </summary>
			/// <param name="objectToSerialize" type="Object"></param>
			/// <param name="recursionLimit" type="Number"></param>
			/// <param name="useBlobIndex" type="Boolean">true to create blob indexex inside JSON, false to create dataURL-s for blobs inside JSON</param>
			/// <param name="onComplete" type="Function">function(json, blobsArray){....}</param>
			var json = this.serializeObject(objectToSerialize, recursionLimit);
			// serialize blobs if there is any

			var arr1: Blob[] = [];

			if (useBlobIndex && this.blobs.length > 0)
			{
				Calysto.Collections.ForEach(this.blobs, (item, index) => arr1.push(item.BLOB));
			}

			return await this.asyncSerializeBlobsAsync(<SerializerAsyncStateType>({
				currentIndex: -1,
				json: json,
				pureBlobs: arr1,
				blobsCopy: this.blobs.slice(0),
				useBlobIndex: useBlobIndex
			}));
		};

		public Serialize(objectToSerialize: any, recursionLimit = 100)
		{
			/// <summary>
			/// Serialize sync, Blobs are not serialized
			/// </summary>
			/// <param name="objectToSerialize" type="Object"></param>
			/// <param name="recursionLimit" type="Number"></param>

			return this.serializeObject(objectToSerialize, recursionLimit);
		}
	}
}
