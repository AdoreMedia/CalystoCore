namespace Web.Calysto.Web.Social.Google.Infrastructure
{
	public class GoogleUser
	{
		// These six fields are included in all Google ID Tokens.
		public string iss { get; set; } //	 "iss": "https://accounts.google.com",
		public string sub { get; set; } //"sub": "110169484474386276334",
		public string azp { get; set; } //"azp": "1008719970978-hb24n2dstb40o45d4feuo2ukqmcc6381.apps.googleusercontent.com",
		public string aud { get; set; } //"aud": "1008719970978-hb24n2dstb40o45d4feuo2ukqmcc6381.apps.googleusercontent.com",
		public string iat { get; set; } //"iat": "1433978353",
		public string exp { get; set; } //"exp": "1433981953",

		// These seven fields are only included when the user has granted the "profile" and
		// "email" OAuth scopes to the application.
		public string email { get; set; } //"email": "testuser@gmail.com",
		public bool email_verified { get; set; } //"email_verified": "true",
		public string name { get; set; } //"name" : "Test User",
		public string picture { get; set; } //"picture": "https://lh4.googleusercontent.com/-kYgzyAWpZzJ/ABCDEFGHI/AAAJKLMNOP/tIXL9Ir44LE/s99-c/photo.jpg",
		public string given_name { get; set; } //"given_name": "Test",
		public string family_name { get; set; } //"family_name": "User",
		public string locale { get; set; }//"locale": "en"

		// error
		public string error { get; set; }
		public string error_description { get; set; }

		public string ClientId => this.aud;
		public string SocialId => this.sub;
	}
}