/// <reference path="Json.Infrastructure.ts" />
/// <reference path="json.infrastructure.calystojsonserializer.ts" />
/// <reference path="json.infrastructure.calystojsonreader.ts" />
namespace Calysto.Json
{
	/*
	// // "2014-02-01T09:28:56.321Z", Z: UTC
	// "2014-02-01T09:28:56.321-01:00", time zone -1h
	// "2015-04-25T11:37:32.323Z" // when T or Z exists, new Date("2015-04-25T11:37:32.323Z") convert to utc time (9:37) + time zone if local time zone is +02:00
	// "2015-04-25 11:37:32.323" // without T and Z, new Date("2015-04-25 11:37:32.323") convert to exact time (11:37) + time zone
	*/

	// Calysto.JSON.Deserialize
	function fnJsonDeserialize(jsonString: string, blobsArray?: Blob[])
	{
		///<summary>Deserialize JSON string into object.</summary>
		///<param name="jsonString" type="String">Valid JSON string</param>
		/// <param name="blobsArray" type="BlobsArrayCtor" optional="true"></param>
		///<returns type="Object|Array|Null">JS object</returns>

		if (typeof (jsonString) == "string" && !!jsonString)
		{
			if ((<any>window).JSON)
			{
				return JSON.parse(jsonString, (key, value)=>
				{
					return value ? fnJsonPostConvertObj2(<Infrastructure.IJsonItem>value, blobsArray) : value;
				});
			}
			else
			{
				return new Infrastructure.CalystoJsonReader(jsonString, blobsArray).Parse();
			}
		}
		// will return undefined
	}

	/**
	 * public method: Calysto.JSON.PostConvertObject is used in DateTimeConverter.cs
	 * @param obj
	 * @param blobsArray
	 */
	export function fnJsonPostConvertObj2(obj: Infrastructure.IJsonItem, blobsArray?: Blob[])
	{
		/// <param name="blobsArray" type="BlobsArrayCtor" optional="true"></param>
		if (!obj) return obj;

		switch (obj.__calystotype)
		{
			case "Calysto_Date":
				return Date.FromLocalISOTString((<Infrastructure.JsonDateTime>obj).Date);

			case "Calysto_Blob":
				let blob = <Infrastructure.JsonBlob>obj;
				if (blob.DataUrl)
				{
					return Calysto.Utility.Blob.DataUrlToBlob(blob.DataUrl, blob.FileName);
				}
				else if (blob.BlobIndex === 0 || blob.BlobIndex > 0)
				{
					var data1 = (blobsArray || []).AsEnumerable().Where(o => o.blobIndex == blob.BlobIndex).FirstOrDefault(); // must return single item
					if (!data1) throw new Error("Blob not found at index: " + blob.BlobIndex);
					return data1;
				}
				return blob;

			case "Calysto_Function":
				return Calysto.Utility.Expressions.CompileLambdaNoReturnCheck((<Infrastructure.JsonFunction>obj).Function);

			default:
				return obj;
		}
	}

	// global function, used in DateTimeConverter
	Calysto.Core.ExportGlobal(fnJsonPostConvertObj2, "fnJsonPostConvertObj2");

	/**
	 * Serialize Blobs
	 * @param objectToSerialize
	 * @param recursionLimit
	 * @param useBlobIndex true to create blob indexes inside JSON, false to create dataURL-s for blobs inside JSON
	 */
	export async function SerializeAsync(objectToSerialize: any, recursionLimit: number = 100, useBlobIndex: boolean = true)
	{
		/// <summary>
		/// Serialize Blobs
		/// </summary>
		/// <param name="objectToSerialize" type="Object"></param>
		/// <param name="recursionLimit" type="Number"></param>
		/// <param name="useBlobIndex" type="Boolean">true to create blob indexes inside JSON, false to create dataURL-s for blobs inside JSON</param>
		/// <param name="onComplete" type="Function">function(json, blobsArray){....}</param>

		return await new Infrastructure.CalystoJsonSerializer(true).SerializeAsync(objectToSerialize, recursionLimit, useBlobIndex);
	}

	export function Serialize(objectToSerialize: any, recursionLimit = 100)
	{
		/// <summary>
		/// Serialize sync, Blobs are not serialized
		/// </summary>
		/// <param name="objectToSerialize" type="Object"></param>
		/// <param name="recursionLimit" type="Number"></param>
		return new Infrastructure.CalystoJsonSerializer(false).Serialize(objectToSerialize, recursionLimit);
	};

	export function Deserialize<TResult>(jsonString: string, blobsArray?: Blob[]): TResult
	{
		///<summary>Deserialize JSON string into object.</summary>
		///<param name="jsonString" type="String">Valid JSON string</param>
		/// <param name="blobsArray" type="BlobsArrayCtor" optional="true"></param>
		///<returns type="Object|Array|Null">JS object</returns>

		return fnJsonDeserialize(jsonString, blobsArray);
	}

}


