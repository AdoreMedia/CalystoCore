namespace Calysto.Json.Infrastructure
{
	type CalystoJsonType = "Calysto_Blob" | "Calysto_Date" | "Calysto_Function";

	export interface IJsonItem
	{
		__calystotype: CalystoJsonType;
	}

	// clone from C#: Calysto.Serialization.Json.Core.Converters.CalystoBlobConverter.JsonBlob
	export class JsonBlob implements IJsonItem
	{
		/** (string) Base64 encoded data url */
		public DataUrl: string;
		/** (int) Blob index when indexes are used instead of dataURL */
		public BlobIndex: number;
		/** (string) FileName string */
		public FileName: string;
		/** mime type */
		public MimeType: string;
		/** (int), data length */
		public Size: number;
		/** string */
		public __calystotype: CalystoJsonType = "Calysto_Blob";
	}

	// clone from C#: Calysto.Serialization.Json.Core.Converters.DateTimeConverter.JsonDateTime
	export class JsonDateTime implements IJsonItem
	{
		/**(string) ISO date string yyyy-MM-dd HH:mm:ss.fff */
		public Date: string;

		/** string */
		public __calystotype: CalystoJsonType = "Calysto_Date";
	}

	export class JsonFunction implements IJsonItem
	{
		public Function: string;

		public __calystotype: CalystoJsonType = "Calysto_Function";
	}

	export type UidWithBlobType = { UID: string, BLOB: Blob };

	export type AsyncCompleteType = ({ json: string, blobs: Blob[] });

	export type SerializerAsyncStateType = ({
		currentIndex: number,
		json: string,
		pureBlobs: Blob[],
		blobsCopy: UidWithBlobType[],
		useBlobIndex: boolean
	});

	export const escapeeChars = {
		"\b": '\\b',
		"\t": '\\t',
		"\n": '\\n',
		"\f": '\\f',
		"\r": '\\r',
		'"': '\\"',
		"\\": '\\\\'
	};
}
