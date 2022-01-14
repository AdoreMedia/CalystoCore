namespace Calysto.Utility
{
	public static class CalystoConstants
	{
		public const string EmailRegexPattern = "^[\\w\\.\\+\\-_']+[@][\\w\\+\\-_']+?[\\.][\\w\\.\\+\\-_']+$";
		public const string BroadcastMethodName = "$broadcast-message$";
		public const string EchoClientRequest = nameof(EchoClientRequest);
		public const string EchoClientResponse = nameof(EchoClientResponse);
		public const string EchoServerRequest = nameof(EchoServerRequest);
		public const string EchoServerResponse = nameof(EchoServerResponse);
	}
}
