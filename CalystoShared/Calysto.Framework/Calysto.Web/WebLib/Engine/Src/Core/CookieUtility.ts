namespace Calysto.CookieUtility
{
	/**
	 * Set cookie value.
	 * @param cookieName
	 * @param cookieValue
	 * @param expiresAfterSECONDS Number of seconds to keep cookie alive. If value not set or null, creates session cookie.
	 * @param domain Domain with dot before: .domain.com or .www.domain.com
	 * @param path Path, default /
	 * @param secure Is secure
	 */
	export function SetCookieValue(cookieName: string, cookieValue: string, expiresAfterSECONDS?: number, domain?: string, path?: string, secure?: boolean)
	{
		// Set-Cookie:cookieName=cookieValue; domain=.pnew.hr; expires=Wed, 26-Oct-2112 07:54:37 GMT; path=/
		if (!cookieName)
		{
			throw Error("cookieName is required");
		}
		
		var expires = expiresAfterSECONDS ? new Date(Math.round(Date.now() + (1000 * expiresAfterSECONDS))) : null; // getTime() return ticks in ms, new Date(ticks in ms)

		var cc = encodeURIComponent(cookieName + "") + '=' + encodeURIComponent(cookieValue + "") // convert cookieValue to string
			+ (expires ? '; expires=' + expires.toUTCString() : '')
			+ (domain ? ('; domain=' + domain) : '') // if not set, browser uses current host, if domain is different than current host or not subset of current host, cookie is not set
			+ ('; path=' + (path ? path : '/')) // default /
			+ (secure ? '; secure' : '');

		document.cookie = cc;
	}
	
	/**
	 * Get cookie value by cookie name.
	 * @param cookieName
	 */
	export function GetCookieValue(cookieName:string)
	{
		// document.cookie has "name=value; name1=value1" only, last value doesn't have ;
		var cookieValue = '';
		var posName = document.cookie.indexOf(encodeURIComponent(cookieName) + '=');
		if (cookieName && posName >= 0)
		{
			var posValue = posName + (encodeURIComponent(cookieName) + '=').length;
			var endPos = document.cookie.indexOf(';', posValue);
			if (endPos >= 0)
			{
				cookieValue = decodeURIComponent(document.cookie.substring(posValue, endPos));
			}
			else
			{
				// there is no ; so it is last cookie
				cookieValue = decodeURIComponent(document.cookie.substring(posValue));
			}
		}
		return (cookieValue || "");
	}

	/** Get all cookies as array of Name-Values: [{Name:c1, Value:v1}, {Name:c2, Value:v2},...] */
	export function GetCookies()
	{
		var arr = document.cookie.split(';');
		var col: ({ Name: string, Value: string }[]) = []; // return type
		for (var n = 0; n < arr.length; n++)
		{
			var nv = arr[n].replace(new RegExp("(^[\\s]+)|([\\s]$)", "ig"), ""); // trim white space
			if (nv)
			{
				var a = nv.split('=');
				col.push({ Name: decodeURIComponent(a[0]), Value: decodeURIComponent(a[1]) });
			}
		}
		return col;
	};

	/**
	 * Delete cookie.
	 * @param cookieName
	 * @param domain
	 */
	export function DeleteCookie(cookieName: string, domain?:string)
	{
		return SetCookieValue(cookieName, "", (-1) * Date.now() / 1000, domain);
	};

}

