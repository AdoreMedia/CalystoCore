namespace Calysto.Web
{
	public class CalystoContext
	{
		public CalystoRequest Request { get; } = new CalystoRequest();

		public CalystoResponse Response { get; } = new CalystoResponse();
	}
}
