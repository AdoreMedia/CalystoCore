using Calysto.Web;
using Calysto.Web.Hosting;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Claims;

namespace Calysto.AspNetCore.Authorization.Utility
{
	/// <summary>
	/// Reads values form <see cref="AuthorizeAttribute"/> and <see cref="AllowAnonymousAttribute"/>
	/// </summary>
	public class CalystoAuthorizationHelper
	{
		public static bool MayInvokeMethod(object targetInstance, MethodInfo method)
		{
			AccessKind kind = CheckAuthorization(targetInstance, method);
			switch (kind)
			{
				case AccessKind.Public:
				case AccessKind.AllowAnonymous:
				case AccessKind.Authorized:
					return true;
				default:
					return false;
			}
		}

		public class MethodAttrState
		{
			public List<AuthorizeAttribute> Authorize { get; }
			public List<AllowAnonymousAttribute> AllowAnonymous { get; }
			public MethodAttrState(List<AuthorizeAttribute> authorize, List<AllowAnonymousAttribute> anonymous)
			{
				this.Authorize = authorize;
				this.AllowAnonymous = anonymous;
			}
		}

		static Dictionary<MethodInfo, MethodAttrState> _dicCachedStates = new Dictionary<MethodInfo, MethodAttrState>();

		public static AccessKind CheckAuthorization(object targetInstance, MethodInfo minfo)
		{
			// ista metoda ima uvijek isti MethodInfo, koliko god puta se dohvati sa this.GetType().GetMethod(nameof(TestMethod2)), provjereno

			if (!_dicCachedStates.TryGetValue(minfo, out var state))
			{
				lock (_dicCachedStates)
				{
					if (!_dicCachedStates.TryGetValue(minfo, out state))
					{
						var authorize = minfo.DeclaringType.GetCustomAttributes<AuthorizeAttribute>()
							.Concat(minfo.GetCustomAttributes<AuthorizeAttribute>()).ToList();

						var allowAnonymous = minfo.DeclaringType.GetCustomAttributes<AllowAnonymousAttribute>()
							.Concat(minfo.GetCustomAttributes<AllowAnonymousAttribute>()).ToList();

						state = new MethodAttrState(authorize, allowAnonymous);

						_dicCachedStates.Add(minfo, state);
					}
				}
			}

			return CheckAuthorization(targetInstance, state?.Authorize, state?.AllowAnonymous);
		}

		public static AccessKind CheckAuthorization(
				object targetInstance,
				List<AuthorizeAttribute> authorizeAttributes = null,
				List<AllowAnonymousAttribute> allowAnonymousAttributes = null)
		{
			// AllowAnonymousAttribute has higher precedance than AuthorizeAttribute, wherever it is, on class or on method, tested

			if (allowAnonymousAttributes?.Any() != true && authorizeAttributes?.Any() != true)
				return AccessKind.Public;
			else if (allowAnonymousAttributes?.Any() == true)
				return AccessKind.AllowAnonymous;
			else if (authorizeAttributes?.All(attr => HasAuthorization(targetInstance, attr)) == true)
				return AccessKind.Authorized;
			else
				return AccessKind.Forbidden;
		}

		public static bool HasAuthorization(object targetInstance, AuthorizeAttribute attr)
		{
			ClaimsPrincipal principal = CalystoMvcHostingEnvironment.Current.HttpContext.User;
			if (!principal.Identity.IsAuthenticated || principal.Identity.AuthenticationType != attr.AuthenticationSchemes)
			{
				var res1 = CalystoMvcHostingEnvironment.Current.AuthenticateAsync(CalystoMvcHostingEnvironment.Current.HttpContext, attr.AuthenticationSchemes).Result;
				if (res1?.Principal?.Identity?.IsAuthenticated != true)
					return false;
				else
					principal = res1.Principal;
			}

			if (attr.Policy != null)
			{
				var res3 = new CalystoAuthorizationResource()
				{
					Authorize = attr,
					TargetInstance = targetInstance
				};

				var res2 = CalystoMvcHostingEnvironment.Current.AuthorizeAsync(principal, res3, attr.Policy).Result;
				if (!res2.Succeeded)
					return false;
			}

			if (string.IsNullOrEmpty(attr.Roles))
				return true; // allow any role

			var attrRoles = attr.Roles.Split(',').Select(o => o.Trim()).Where(o => !string.IsNullOrEmpty(o));
			var red3 = attrRoles.Where(role => principal.IsInRole(role)).Any();
			return red3;
		}
	}
}
