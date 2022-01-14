using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Calysto.Web.Script.Services
{
	internal interface IHttpHandler
	{
		Task ProcessRequestAsync(HttpContext context);
	}
}