using Calysto.Web.Forms.WebSiteGenerators.Generators;
using System;
using System.Threading.Tasks;

namespace Calysto.Web.Forms.WebSiteGenerators
{
	class Program
	{
		static async Task Main(string[] args)
		{
			Console.WriteLine("Start Calysto.Web.Forms.WebSiteGenerators");

			//new IntellisenseFilesGenerator().GenerateCalystoTestSiteIntellisenseFiles();

			//Console.WriteLine("IntellisenseFilesGenerator done");

			new TypeLiteGenerator().GenerateCalystoTestSiteTypeLite();

			Console.WriteLine("TypeLiteGenerator done");

			Console.WriteLine("Completed Calysto.Web.Forms.WebSiteGenerators");

			await Task.CompletedTask;
		}
	}
}
