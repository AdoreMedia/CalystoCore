//using Calysto.AspNetCore.Mvc.Razor;
//using Calysto.AspNetCore.Mvc.Razor.Templating;
//using Calysto.Web;
//using Microsoft.AspNetCore.Authentication;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Http;
//using System.Threading.Tasks;

//namespace Calysto.AspNetCore.Middlewares
//{
//	public class CalystoContextInitializatorMiddleware
//	{
//		private readonly RequestDelegate _next;

//		public CalystoContextInitializatorMiddleware(RequestDelegate next)
//		{
//			_next = next;
//		}

//		public async Task Invoke(HttpContext context,
//						IAuthorizationService authorization,
//						IAuthenticationService authentication)
//		{

//			CalystoContextMvc.Create(context, authorization, authentication);

//			await _next.Invoke(context);
//		}
//	}
//}
