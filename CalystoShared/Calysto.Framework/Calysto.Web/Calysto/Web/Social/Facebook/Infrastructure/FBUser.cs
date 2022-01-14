namespace Web.Calysto.Web.Social.Facebook.Infrastructure
{
	public class FBUser
	{
		public FBError error { get; set; }
		public string id { get; set; }
		public string name { get; set; }
		public string first_name { get; set; }
		public string last_name { get; set; }
		public string email { get; set; }

		public string SocialId => this.id;
	}
}