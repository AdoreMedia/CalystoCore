using System;
using System.Threading.Tasks;
using Calysto.Web;
using Calysto.Web.CalystoTextTemplating;

namespace Calysto.Web.Generators
{
	class Program
	{
		static async Task Main(string[] args)
		{
			await Task.CompletedTask;

			Console.WriteLine("Start Calysto.Web.Generators");

			new AppConstantsGenerator().GenerateCalystoWebAppConstants();
			Console.WriteLine("AppConstantsGenerator done");

			new BaseXCharsTableGenerator().GenerateCalystoWebBaseXCharsTable();
			Console.WriteLine("BaseXCharsTableGenerator done");

			new CalystoAjaxHandlerConstantsGenerator().GenerateCalystoWebAjaxHandlerConstants();
			Console.WriteLine("CalystoAjaxHandlerConstantsGenerator done");

			new CalystoDomAttributesGenerator().GenerateCalystoWebDomAttributes();
			Console.WriteLine("CalystoDomAttributesGenerator done");

			new EngineConstantsGenerator().GenerateCalystoWebEngineConstants();
			Console.WriteLine("EngineConstantsGenerator done");

			new ImagesGenerator().GenerateCalystoWebImages();
			Console.WriteLine("ImagesGenerator done");

			new PredefinedCulturesGenerator().GenerateCalystoWebPredefinedCultures();
			Console.WriteLine("PredefinedCulturesGenerator done");

			new WsjsHeaderConstantsGenerator().GenerateCalystoWebWsjsHeaderConstants();
			Console.WriteLine("WsjsHeaderConstantsGenerator done");

			////await new OutputCopier().CopyOutputAsync();
			////Console.WriteLine("OutputCopier done");

			Console.WriteLine("Completed Calysto.Web.Generators");
		}
	}
}
