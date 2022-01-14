namespace Calysto.Net
{
	public class CalystoWebClientProgressArg
	{
		public long Current { get; }
		public long Total { get; }

		public CalystoWebClientProgressArg(long current, long total)
		{
			this.Current = current;
			this.Total = total;
		}
	}
}
