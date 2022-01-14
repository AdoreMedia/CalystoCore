using Calysto.TypeLite;
using Calysto.Web.Script.Services;
using Treci.Peti;

namespace Calysto.Genesis.UnitTest.Calysto.TypeLite.Model
{
	[TsClass]
	public partial class WebServiceClassExample
	{
		public class PrometResponse
		{
		}

		[CalystoWebMethod]
		public PrometResponse GetPrometItems(int skip, int take)
		{
			return new PrometResponse();
		}

		public class UploadResult
		{
			public string Message { get; set; }
			public int? ReloadAfterMs { get; set; }
		}

		public enum tblBankaEnum
		{
			Erste = 1,
			Pbz = 2,
			Zaba = 3
		}

		[CalystoWebMethod]
		public UploadResult UploadTransactionsData(string data, tblBankaEnum bankaKind)
		{
			return new UploadResult();
		}

		public class SavePozivNaBrojResponse
		{
			public string DocumentDetailsUrl { get; set; }
		}

		[CalystoWebMethod]
		public SavePozivNaBrojResponse SavePrimateljPozivNaBroj(int bankaPrometID, string primateljPozivNaBroj)
		{
			return new SavePozivNaBrojResponse();
		}

		[CalystoWebMethod]
		public ArizonaJSResponse SaveSomeData(int bankaPrometID, string primateljPozivNaBroj)
		{
			return new ArizonaJSResponse();
		}

	}
}

namespace Treci.Peti
{
	public interface IMyInterface
	{

	}

	public class ArizonaJSResponse : IMyInterface
	{
		// class with no properties
	}
}