namespace Calysto.Utility.Blob
{
	export interface IBlobResult
	{
		dataUrl: string;
		fileName: string;
	}

	/**
	 * 
	 * @param byteArrays Uint8Array|Blob|File, example: [new Uint8Array([data]), new Blob(), new File(), ...]
	 * @param contentType
	 */
	export function CreateBlob(byteArrays: any, contentType: string): Blob
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="byteArrays" type="[Uint8Array|Blob|File]">example: [new Uint8Array([data]), new Blob(), new File(), ...]</param>
		/// <param name="contentType" type="String">mime type</param>
		/// <returns type=""></returns>

		// warning: byteArrays has to be array of arrays
		// byteArrays accepts: [new Uint8Array([data]), new Blob(), new File(), ...]
		// simple Array is not suported, convert it to Uint8Array: new Unit8Array(Array instance)
		if (window.Blob)
		{
			return <Blob><any>new window.Blob(byteArrays, { type: contentType });
		}
		else
		{
			var win: any = window;
			var blobCtor: Function =
				win.BlobBuilder ||
				win.WebKitBlobBuilder ||
				win.MozBlobBuilder ||
				win.MSBlobBuilder;

			if (blobCtor)
			{
				var bb = new (<any>blobCtor)();
				bb.append(byteArrays);
				return bb.getBlob(contentType);
			}
		}
		throw new Error("Blob is not supported");
	}

	export function Base64ToBlob(base64Data: string, contentType: string)
	{
		/// <summary>
		/// returns Blob object
		/// </summary>
		/// <param name="base64Data" type="string"></param>
		/// <param name="contentType" type="string"></param>
		contentType = contentType || '';
		var sliceSize = 1024; // text MUST be in slices, max size 1024
		var byteCharacters = atob(base64Data);
		var bytesLength = byteCharacters.length;
		var slicesCount = Math.ceil(bytesLength / sliceSize);
		var byteArrays = new Array(slicesCount);

		for (var sliceIndex = 0; sliceIndex < slicesCount; ++sliceIndex)
		{
			var begin = sliceIndex * sliceSize;
			var end = Math.min(begin + sliceSize, bytesLength);

			var bytes = new Array(end - begin);
			for (var offset = begin, i = 0; offset < end; ++i, ++offset)
			{
				bytes[i] = byteCharacters[offset].charCodeAt(0); // converting chars to bytes
			}
			var arr = new Uint8Array(bytes);
			byteArrays[sliceIndex] = arr;
		}
		return CreateBlob(byteArrays, contentType);
	}

	export function DataUrlToBlob(dataUrl: string, filename: string)
	{
		/// <summary>
		/// convert string eg. data:image/png;base64,iVBORw0KGgoAAkJggg== to Blob instance
		/// </summary>
		/// <param name="dataUrl" type="String"></param>

		var type, base64data;
		var parts = dataUrl.split(";");
		for (var n = 0; n < parts.length; n++)
		{
			var pp = parts[n];
			if (pp.StartsWith("data:"))
			{
				type = pp.substr("data:".length);
			}
			else if (pp.StartsWith("base64,"))
			{
				base64data = pp.substr("base64,".length);
			}
		}

		var blob = Base64ToBlob(base64data, type);
		blob.filename = filename;
		return blob;
	}

	/**
	 * convert blob to RFC base64 string
	 * @param blob
	 * @param onComplete
	 */
	export async function BlobToBase64Async(blob: Blob)
	{
		/// <summary>
		/// returns string as base64 encoded blob data
		/// </summary>
		/// <param name="blob" type="Blob"></param>
		/// <param name="onComplete" type="function">function(base64str){...}</param>

		return new Promise<string>(resolve =>
		{
			var reader = new FileReader();
			reader.onload = function (res)
			{
				var arr = new Uint8Array((<any>res.currentTarget).result);
				// convert bytes[] to chars
				var chars: any[] = [arr.length];
				for (var n = 0; n < arr.length; n++)
				{
					chars[n] = String.fromCharCode(arr[n]);
				}
				var str = chars.join("");
				var b64 = btoa(str);
				resolve(b64);
			};
			reader.readAsArrayBuffer(blob);
		});
	}

	/**
	 * convert blob to string eg. data:image/png;base64,iVBORw0KGgoAAkJggg==
	 * @param blob
	 * @param onComplete
	 */
	export async function BlobToDataUrlAsync(blob: Blob)
	{
		/// <summary>
		/// return string eg. data:image/png;base64,iVBORw0KGgoAAkJggg==
		/// </summary>
		/// <param name="blob" type="Blob"></param>
		/// <param name="onComplete" type="function">function(dataUrl, fileName){...}</param>

		return Tasks.TaskUtility.CallbackAsync<IBlobResult>(resolve =>
		{
			var reader = new FileReader();
			reader.onload = function (res)
			{
				resolve(<IBlobResult>{
					dataUrl: (<any>res.currentTarget).result,
					fileName: blob.name || blob.filename
				});
			};
			reader.readAsDataURL(<Blob>blob);
		});

	}
}
