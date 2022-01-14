namespace Calysto.Json.BinaryFrame
{
	//type TocItemType = ({
	//	// int?
	//	Size: number,
	//	// string
	//	FileName?: string,
	//	// int?
	//	BlobIndex?: number,
	//	// string
	//	MimeType: string,
	//	// bool
	//	IsJson: boolean
	//});

	//type BinaryTocType = ({
	//	Items: TocItemType[]
	//});

	//type BlobsArrayType = [Blob];//[Calysto.Utility.Blob.CreateBlob([[1]], "image/png")];


	var _headerSizeBytes = 4;

	function DeserializeWorker<TResult>(arrayBuffer: ArrayBuffer)
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="arrayBuffer" type="ArrayBuffer"></param>
		/// <param name="onComplete" type="Function"></param>

		// IE11 doesn't have Uint8Array.prototype.slice, so, use slice on ArrayBuffer

		var tocLength = Calysto.Utility.CalystoTools.ByteArrayToLong(new Uint8Array(arrayBuffer.slice(0, _headerSizeBytes))); // header size is always 4 bytes (_headerSizeBytes)
		var tocJson = Calysto.Utility.Encoding.UTF8.GetString(new Uint8Array(arrayBuffer.slice(_headerSizeBytes, _headerSizeBytes + tocLength)));
		var toc = Calysto.Json.Deserialize<Calysto.Serialization.Json.BinaryFrame.BinaryToc>(tocJson);

		var mainJson: string = "";
		var blobsArray: Blob[] = [];
		var offsetStart = _headerSizeBytes + tocLength;
		for (var n1 = 0; n1 < toc.Items.length; n1++)
		{
			var item = toc.Items[n1];
			var data: number[] = <any>new Uint8Array(arrayBuffer.slice(offsetStart, offsetStart + item.Size));
			if (item.IsJson)
			{
				mainJson = Calysto.Utility.Encoding.UTF8.GetString(data);
			}
			else
			{
				var blob = Calysto.Utility.Blob.CreateBlob([data], item.MimeType);
				blob.filename = item.FileName;
				blob.blobIndex = item.BlobIndex;
				blobsArray.push(blob);
			}

			offsetStart += item.Size;
		}

		return Calysto.Json.Deserialize<TResult>(mainJson, blobsArray);
	}

	export async function DeserializeAsync<TResult>(binaryData: Blob | ArrayBuffer | string)
	{
		/// <summary>
		/// Async deserialize from binary data or json string, depending if binaryData is string or blob.<br/>
		/// Return deserialized object.
		/// </summary>
		/// <param name="binaryData" type="Blob|String">binary data or json string</param>
		/// <param name="onComplete" type="Function">function(finalObj){...}</param>
		// block:
		// "header size": 1 byte, its value says the length of bytes in header that follows
		// "header" : contains "header size" bytes, its value represents "data lenght" that follows
		// "data": contains "data length" bytes
		// block
		// "header size": 1 byte, its value says the length of bytes in header that follows
		// "header" : contains "header size" bytes, its value represents "data lenght" that follows
		// "data": contains "data length" bytes
		// next block....

		if (binaryData && (<any>window).ArrayBuffer && binaryData.constructor == ArrayBuffer)
		{
			return DeserializeWorker<TResult>(<ArrayBuffer><any>binaryData); // binaryData is ArrayBuffer
		}
		else if (typeof (binaryData) == "string")
		{
			return Calysto.Json.Deserialize<TResult>(<string>binaryData);
		}
		else if (binaryData && window.Blob && binaryData.constructor == Blob)
		{
			return new Promise<TResult>(resolve =>
			{
				var rr = new FileReader();
				rr.onload = async function (res)
				{
					let res1 = DeserializeWorker<TResult>(<ArrayBuffer>(<any>res.currentTarget).result); // result is ArrayBuffer
					resolve(res1);
				};
				rr.readAsArrayBuffer(<Blob><any>binaryData);
			});
		}
		else
		{
			throw new Error("Current binaryData type is not supported");
		}
	};

	function CreateBinaryFrame(json: string, blobsArray: Blob[]): Blob
	{
		/// <summary>
		/// json has to be created using SerializeAsync first with blobIndex option
		/// </summary>
		/// <param name="json" type="String"></param>
		/// <param name="blobsArray" type="Array"></param>
		// first 4 bytes contains TOC size
		// then follows TOC, it is JSON encoded into binary stream
		// then follows data, blobs described in TOC
		var toc: Calysto.Serialization.Json.BinaryFrame.BinaryToc = {
			Items:  []
		};

		blobsArray = blobsArray || []; // if there is no blobs, set [] to prevent from throwing null exception

		for (var n1 = 0; n1 < blobsArray.length; n1++)
		{
			var blob = blobsArray[n1];

			toc.Items.push({
				Size: blob.size,
				FileName: blob.filename,
				MimeType: blob.type,
				BlobIndex: blob.blobIndex || n1,
				IsJson:false
			});
		}

		// main JSON will be added at the end as last blob
		var jsonData = Calysto.Utility.Encoding.UTF8.GetBytes(json);

		toc.Items.push({
			Size: jsonData.length,
			FileName:<any>null,
			MimeType: "application/json",
			BlobIndex:<any>null,
			IsJson: true
		});

		var tocJson = Calysto.Json.Serialize(toc);
		var tocBytes = Calysto.Utility.Encoding.UTF8.GetBytes(tocJson);
		// TOC length writtent into 4 bytes
		var tocLengthBytes = Calysto.Utility.CalystoTools.LongToByteArray(tocBytes.length).slice(0, 4);

		// create complete single ArrayBuffer

		var finalArr:any[] = [];
		finalArr.push(new Uint8Array(tocLengthBytes)); // array, 4 bytes containing TOC size
		finalArr.push(new Uint8Array(tocBytes)); // array with TOC content
		// write blobs
		for (var n1 = 0; n1 < blobsArray.length; n1++)
		{
			finalArr.push(blobsArray[n1]);
		}

		// write main JSON
		finalArr.push(new Uint8Array(jsonData));

		// single large blob
		// we have to create Blob since we already have blobs in blobsArray, it can not be converted into ArrayBuffer without FileReader
		var finalBlob = Calysto.Utility.Blob.CreateBlob(finalArr, "application/octet-stream");
		return finalBlob;
	}

	export async function SerializeAsync(obj: any)
	{
		/// <summary>
		/// Async serialize obj and return BinaryFrame instance.
		/// </summary>
		/// <param name="obj" type="type"></param>
		/// <param name="onComplete" type="function">function(BinaryFrame){...}</param>

		let res1 = await Calysto.Json.SerializeAsync(obj, 100, true);
		return new BinaryFrameItem(res1?.json || "", res1?.blobs || []);
	}

	export class BinaryFrameItem
	{
		constructor(
			public Json: string,
			public Blobs: Blob[]
		)
		{
		}

		/**
		 * Pack json and blobs into single binary data as Blob
		 */
		public ToBinaryData(): Blob
		{
			/// <summary>
			/// Pack json and blobs into single binary data as Blob
			/// </summary>
			/// <returns type=""></returns>
			return CreateBinaryFrame(this.Json, this.Blobs);
		}
	}
}
