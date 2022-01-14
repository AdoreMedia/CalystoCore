using System.Linq;

namespace Calysto.Web
{
	/// <summary>
	/// Inherits javascript Blob.
	/// </summary>
	public class CalystoBlob
	{
		private string _mimeType = "application/octet-stream";
		/// <summary>
		/// Mime type, if not provided, default is application/octet-stream
		/// </summary>
		public string MimeType { get { return _mimeType; } set { _mimeType = value; } }

		/// <summary>
		/// Blob binary data.
		/// </summary>
		public byte[] Data { get; set; }

		/// <summary>
		/// Used for Calysto.Ajax uploads only.
		/// </summary>
		public int? BlobIndex { get; set; }

		/// <summary>
		/// Information only.
		/// </summary>
		public int? Size { get; set; }

		/// <summary>
		/// Filename when file is uploaded, or filename when file is downloaded.
		/// </summary>
		public string FileName { get; set; }

		/// <summary>
		/// ctor
		/// </summary>
		public CalystoBlob()
		{

		}

		public string ToDataUrl()
		{
			return "data:" + this.MimeType + ";base64," + (this.Data == null ? null : System.Convert.ToBase64String(this.Data));
		}

		public static CalystoBlob FromDataUrl(string dataUrl)
		{
			string[] parts = dataUrl.Split(';');
			string type = parts.Where(o => o.StartsWith("data:")).Select(o => o.Substring(5)).FirstOrDefault();
			string base64data = parts.Where(o => o.StartsWith("base64,")).Select(o => o.Substring("base64,".Length)).FirstOrDefault();

			CalystoBlob blob = new CalystoBlob();
			blob.MimeType = type;
			blob.Data = System.Convert.FromBase64String(base64data);
			return blob;
		}

	}
}
