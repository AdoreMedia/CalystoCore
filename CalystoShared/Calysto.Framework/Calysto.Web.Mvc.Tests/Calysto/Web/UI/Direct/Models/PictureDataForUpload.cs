using Calysto.Web;

namespace CalystoWebTests.Calysto.Web.UI.Direct.Models
{
	public class PictureDataForUpload
	{
		public int? DirClientPictureID { get; set; }
		public CalystoBlob Blob { get; set; }
		public bool? IsNaslovna { get; set; }
		public bool? IsLogo { get; set; }
	}
}
