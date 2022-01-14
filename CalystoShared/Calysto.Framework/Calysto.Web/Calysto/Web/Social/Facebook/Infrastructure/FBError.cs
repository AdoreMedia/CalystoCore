namespace Web.Calysto.Web.Social.Facebook.Infrastructure
{
	public class FBError
	{
		public string message { get; set; }
		public string type { get; set; }
		public string fbtrace_id { get; set; }
		public int? code { get; set; }
	}
}