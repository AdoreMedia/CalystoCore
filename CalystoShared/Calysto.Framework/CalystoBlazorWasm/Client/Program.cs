using Calysto.Genesis.WebSite.Controllers;
using Calysto.Web.TestSite.Web.CalystoUI.Ajax;
using Calysto.Web.TestSite.Web.CalystoUI.Sockets;
using Calysto.Web.TestSite.Web.VS.Home;
using Calysto.Blazor.Utility;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace CalystoBlazorWasm.Client
{
	public class Program
	{
		public static async Task Main(string[] args)
		{
			var builder = WebAssemblyHostBuilder.CreateDefault(args);
			//builder.RootComponents.Add<App>("#app");

			builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

			builder.Services.AddSingleton<BrowserContext>();

			builder.Services.AddTransient<IAjaxService, AjaxServiceClient>();
			builder.Services.AddTransient<HomeControllerClient>();
			builder.Services.AddTransient<SocketSessionClient>();
			builder.Services.AddTransient<SomeMethodsClient>();

			await builder.Build().RunAsync();
		}
	}
}
