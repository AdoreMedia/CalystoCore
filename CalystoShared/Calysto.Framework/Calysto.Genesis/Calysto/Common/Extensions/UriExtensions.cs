using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calysto.Common.Extensions
{
	/*
	currentUri
{http://www.pnew.hr/CentarPopusta/Web/include/images/crte_ch.gif?nesto=43}
    AbsolutePath: "/CentarPopusta/Web/include/images/crte_ch.gif"
    AbsoluteUri: "http://www.pnew.hr/CentarPopusta/Web/include/images/crte_ch.gif?nesto=43"
    AllowIdn: false
    Authority: "www.pnew.hr"
    DnsSafeHost: "www.pnew.hr"
    Fragment: ""
    HasAuthority: true
    Host: "www.pnew.hr"
    HostNameType: Dns
    HostType: IPv6HostType | IPv4HostType
    IdnHost: "www.pnew.hr"
    IsAbsoluteUri: true
    IsDefaultPort: true
    IsDosPath: false
    IsFile: false
    IsImplicitFile: false
    IsLoopback: false
    IsNotAbsoluteUri: false
    IsUnc: false
    IsUncOrDosPath: false
    IsUncPath: false
    LocalPath: "/CentarPopusta/Web/include/images/crte_ch.gif"
    m_DnsSafeHost: null
    m_Flags: PortNotCanonical | E_PortNotCanonical | IPv6HostType | IPv4HostType | AuthorityFound | MinimalUriInfoSet | AllUriInfoSet | HostUnicodeNormalized | RestUnicodeNormalized
    m_Info: {System.Uri.UriInfo}
    m_iriParsing: true
    m_originalUnicodeString: null
    m_String: "http://www.pnew.hr:80/CentarPopusta/Web/include/images/crte_ch.gif?nesto=43"
    m_Syntax: {System.UriParser.BuiltInUriParser}
    OriginalString: "http://www.pnew.hr:80/CentarPopusta/Web/include/images/crte_ch.gif?nesto=43"
    OriginalStringSwitched: false
    PathAndQuery: "/CentarPopusta/Web/include/images/crte_ch.gif?nesto=43"
    Port: 80
    PrivateAbsolutePath: "/CentarPopusta/Web/include/images/crte_ch.gif"
    Query: "?nesto=43"
    Scheme: "http"
    SecuredPathIndex: 0
    Segments: {string[6]}
    Syntax: {System.UriParser.BuiltInUriParser}
    UserDrivenParsing: false
    UserEscaped: false
    UserInfo: ""
*/
	public static class UriExtensions
	{
		/// <summary>
		/// Returns http(s)://host or http(s)://host:port if port is not 80 and not 443
		/// </summary>
		/// <param name="uri"></param>
		/// <returns></returns>
		public static string GetSchemeHost(this Uri uri)
		{
			return uri.Scheme + "://" + uri.Host + (uri.Port == 80 || uri.Port == 443 ? "" : uri.Port.ToString());
		}

		/// <summary>
		/// Returns http(s)://host/path or http(s)://host:port/path if port is not 80 and not 443, without query string
		/// </summary>
		/// <param name="uri"></param>
		/// <returns></returns>
		public static string GetSchemeHostPath(this Uri uri)
		{
			return uri.GetSchemeHost() + uri.LocalPath;
		}



	}
}
