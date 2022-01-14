using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Calysto.Genesis.WebSite
{
	public class Program
	{
		public static void Main(string[] args)
		{
			Startup.StopWatch.Start();
			Startup.StopWatch.Mark("start Main()");

			var builder = CreateHostBuilder(args);

			var host = builder.Build();
			
			host.Run();

		}

		public static IHostBuilder CreateHostBuilder(string[] args) =>
		Host.CreateDefaultBuilder(args)
				.ConfigureWebHostDefaults(webBuilder =>
				{
					Startup.StopWatch.Mark("start ConfigureWebHostDefaults()");

					string dir2 = Directory.GetCurrentDirectory();
					string dir3 = Path.Combine(dir2, "Content");

					webBuilder.UseStartup<Startup>()
					//.UseContentRoot(dir3)
					//.UseWebRoot("Views/_Sites") // where static handler maps to for ~/
					;

					Startup.StopWatch.Mark("complete ConfigureWebHostDefaults()");

				});
	}
}
