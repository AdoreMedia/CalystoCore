using Calysto.Web.WebSiteGenerators.Generators;
using System;
using System.Threading.Tasks;

namespace CalystoWebSiteGenerators
{
	class Program
	{
		static async Task Main(string[] args)
		{
			Console.WriteLine("Start Calysto.Web.Mvc.WebSiteGenerators");

			Console.WriteLine("CalystoLiteGenerator start");
			new CSharpLiteGenerator().GenerateCalystoLiteClient();
			Console.WriteLine("CalystoLiteGenerator done");

			Console.WriteLine("TypeLiteGenerator start");
			new TypeLiteGenerator().GenerateCalystoTestSiteTypeLite();
			Console.WriteLine("TypeLiteGenerator done");

			Console.WriteLine("Completed Calysto.Web.Mvc.WebSiteGenerators");

			await Task.CompletedTask;
		}
	}
}
