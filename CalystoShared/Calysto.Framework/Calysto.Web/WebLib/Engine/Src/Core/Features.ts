namespace Calysto.Features
{
	export enum BrowserKindEnum
	{
		Unknown = 0,
		Firefox = 1,
		Chrome = 2,
		Safari = 3,
		Opera = 4,
		MSIE = 5,
		Bot = 6,
		MobileBot = 7,
		iPhone = 8,
		AndroidMobile = 9,
		NokiaMobile = 10,
		WapPhone = 11,
		// Google bot
		MobilePhone = 12,
		IEMobile = 13,
		iPad = 14,
		AndroidTablet = 15,
		iPod = 16,
		BlackBerry = 17,
		MSEdge = 18,
		ChromiumEdge
	}

	export enum OSKindEnum
	{
		Unknown = 0,
		Windows = 1,
		Macintosh = 2,
		Android = 3,
		Linux = 4,
		WindowsPhone = 5
	}

	//#region Flash & Silverlight detection

	function IsContained(str: string)
	{
		if (window.navigator && navigator.mimeTypes)
		{
			for (var n = 0; n < navigator.mimeTypes.length; n++)
			{
				if ((navigator.mimeTypes[n]["type"] + "").indexOf(str) > 0)
				{
					return true;
				}
			}
		}
		return false;
	}

	var hasFlash: { value: boolean };

	export function HasFlash()
	{
		if (!hasFlash) hasFlash = { value: IsContained("x-shockwave-flash") };
		return hasFlash.value;
	}

	var hasSilverlight: { value: boolean };

	export function HasSilverlight()
	{
		if (!hasSilverlight) hasSilverlight = { value: IsContained("x-silverlight") };
		return hasSilverlight.value;
	};

	//#endregion

	/* UserAgent examples:

	navigator.userAgent:
	IE11: "Mozilla/5.0 (Windows NT 6.1; WOW64; Trident/7.0; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729; Media Center PC 6.0; .NET4.0C; .NET4.0E; rv:11.0) like Gecko"
	IE10: "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.1; WOW64; Trident/7.0; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729; Media Center PC 6.0; .NET4.0C; .NET4.0E)"
	IE9: "Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; WOW64; Trident/7.0; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729; Media Center PC 6.0; .NET4.0C; .NET4.0E)"
	IE8: "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.1; WOW64; Trident/7.0; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729; Media Center PC 6.0; .NET4.0C; .NET4.0E)"
	IE7: "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.1; WOW64; Trident/7.0; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729; Media Center PC 6.0; .NET4.0C; .NET4.0E)"
	
	Opera: "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/33.0.1750.154 Safari/537.36 OPR/20.0.1387.82"
	
	Chrome: "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/36.0.1985.125 Safari/537.36"
	
	Firefox: "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:30.0) Gecko/20100101 Firefox/30.0"
	
	Safari: "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/534.57.2 (KHTML, like Gecko) Version/5.1.7 Safari/534.57.2"
	
	Intel Mac OS X 10.7
	
	"Mozilla/5.0 (Windows Phone 8.1; ARM; Trident/7.0; Touch; rv:11.0; IEMobile/11.0; NOKIA; Lumia 520) like Gecko"

	"Mozilla/5.0 (compatible; MSIE 9.0; Windows Phone OS 7.5; Trident/5.0; IEMobile/9.0)"
	*/

	//#region Browser detection

	function RemoveDots(verStr: string)
	{
		// eg. "20.0.1387.82", leave first dot and remove others: 20.0138782
		var arr = verStr.split(".");
		var vv = arr.shift();
		if (arr.length > 0)
		{
			vv += "." + arr.join("");
		}
		return vv || "";
	}

	function DetectBrowser()
	{
		var ua = navigator.userAgent || "";
		var vendor = navigator.vendor || "";

		var detMatch: RegExpMatchArray | null = null;
		var detKind: BrowserKindEnum | null = null;
		var detIsMobile: boolean | null = null;
		var detIsTablet: boolean | null = null;
		var detIsCrawler: boolean | null = null;
		var detHasTouch: boolean | null = null;

		//**********************************
		// 0th level detection
		//**********************************
		if (ua.Contains("Bot", true) || ua.Contains("Crawler", true))
		{
			detIsCrawler = true;
		}

		if (ua.Contains("Mobile", true))
		{
			detIsMobile = true;
		}

		detHasTouch = navigator.maxTouchPoints > 0 || (<any>navigator).msMaxTouchPoints > 0;


		//**********************************
		// 1st level detection
		//**********************************
		if (ua.Contains("iPad"))
		{
			// Mozilla/5.0 (iPad; U; CPU OS 4_3_5 like Mac OS X; en-us) AppleWebKit/533.17.9 (KHTML, like Gecko) Version/5.0.2 Mobile/8L1 Safari/6533.18.5
			detIsTablet = true;
			detKind = BrowserKindEnum.iPad;
			detMatch = ua.match("Version\\/([\\d\\.]+)");
		}
		else if (ua.Contains("iPod"))
		{
			// Mozilla/5.0 (iPod; U; CPU OS 4_3_5 like Mac OS X; en-us) AppleWebKit/533.17.9 (KHTML, like Gecko) Version/5.0.2 Mobile/8L1 Safari/6533.18.5
			detIsMobile = true;
			detKind = BrowserKindEnum.iPod;
			detMatch = ua.match("Version\\/([\\d\\.]+)");
		}
		else if (ua.Contains("iPhone"))
		{
			// iphone User-Agent: Mozilla/5.0 (iPhone; U; CPU iPhone OS 4_0 like Mac OS X; en-us) AppleWebKit/532.9 (KHTML, like Gecko) Version/4.0.5 Mobile/8A293 Safari/6531.22.7
			detIsMobile = true;
			detKind = BrowserKindEnum.iPhone;
			detMatch = ua.match("Version\\/([\\d\\.]+)");
		}
		else if (ua.Contains("IEMobile"))
		{
			// new nokia is Windows Phone: "Mozilla/5.0 (compatible; MSIE 10.0; Windows Phone 8.0; Trident/6.0; IEMobile/10.0; ARM; Touch; NOKIA; Lumia 520)"
			// Windows Phone 8.1: "Mozilla/5.0 (Windows Phone 8.1; ARM; Trident/7.0; Touch; rv:11.0; IEMobile/11.0; NOKIA; Lumia 520) like Gecko"
			// vidi: http://www.zytrax.com/tech/web/mobile_ids.html
			detIsMobile = true;
			detKind = BrowserKindEnum.IEMobile;
			detMatch = ua.match("IEMobile\\/([\\d\\.]+)");
		}
		else if (ua.Contains("Nokia"))
		{
			// must be case-sensitive comparison for Nokia
			// User-Agent: Mozilla/5.0 (SymbianOS/9.4; Series60/5.0 Nokia5230/20.0.005; Profile/MIDP-2.1 Configuration/CLDC-1.1 ) AppleWebKit/525 (KHTML, like Gecko) Version/3.0 BrowserNG/7.2.3
			detIsMobile = true;
			detKind = BrowserKindEnum.NokiaMobile;
			detMatch = ua.match("Version\\/([\\d\\.]+)");
		}
		else if (ua.Contains("PlayBook") || ua.Contains("BlackBerry") || ua.Contains("BB10"))
		{
			// "Mozilla/5.0 (BB10; Touch) AppleWebKit/537.10+ (KHTML, like Gecko) Version/10.0.9.2372 Mobile Safari/537.10+"
			// "Mozilla/5.0 (PlayBook; U; RIM Tablet OS 2.1.0; en-US) AppleWebKit/536.2+ (KHTML like Gecko) Version/7.2.1.0 Safari/536.2+"
			detKind = BrowserKindEnum.BlackBerry;
			if (!(detIsTablet = ua.Contains("Tablet")))
			{
				detIsMobile = ua.Contains("Mobile");
			}
		}
		else if ((detMatch = ua.match("MSIE ([\\d\\.]+)"))) // ie v <= 10
		{
			detKind = BrowserKindEnum.MSIE;
		}
		else if (("msMaxTouchPoints" in navigator || "msManipulationViewsEnabled" in navigator) && (detMatch = ua.match("rv:([\\d\\.]+)"))) // ie 11 only
		{
			// ie 11 has no vendor string
			detKind = BrowserKindEnum.MSIE;
		}
		else if ("msManipulationViewsEnabled" in navigator && (detMatch = ua.match("Edge[\\/]([\\d\\.]+)")))
		{
			detKind = BrowserKindEnum.MSEdge;
		}
		else if (detMatch = ua.match(" Edg[\\/]([\\d\\.]+)"))
		{
			detKind = BrowserKindEnum.ChromiumEdge;
		}
		else if (ua.Contains("MSIE"))
		{
			// MSIE 8
			// User-Agent: Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.1; WOW64; Trident/4.0; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729; Media Center PC 6.0; InfoPath.3; .NET4.0C; .NET4.0E)
			detKind = BrowserKindEnum.MSIE;
		}
		else if (ua.Contains("Android"))
		{
			// Android HTC Evo user agent string:
			// Mozilla/5.0 (Linux; U; Android 2.2; en-us; Sprint APA9292KT Build/FRF91) AppleWebKit/533.1 (KHTML, like Gecko) Version/4.0 Mobile Safari/533.1
			// Mozilla/5.0 (Android; Mobile; rv:33.0) Gecko/33.0 Firefox/33.0
			// Mozilla/5.0 (Android; Tablet; rv:33.0) Gecko/33.0 Firefox/33.0
			if (!(detMatch = ua.match("Version\\/([\\d\\.]+)")))
			{
				detMatch = ua.match("Android ([\\d\\.]+)");
			}

			// mobile android has 360x640 screen
			// tablets has width > 900
			if (ua.Contains("Tablet") || (screen.width > 900 && screen.width > screen.height))
			{
				detIsTablet = true;
				detKind = BrowserKindEnum.AndroidTablet;
			}
			else
			{
				detIsMobile = true;
				detKind = BrowserKindEnum.AndroidMobile;
			}
		}
		else if (vendor.Contains("Opera") || ua.Contains("OPR/") || ua.Contains("Opera"))
		{
			detKind = BrowserKindEnum.Opera;
			detMatch = ua.match("(OPR|Opera)\\/([\\d\\.]+)"); // version is in detMatch[2]
			if (detMatch)
			{
				detMatch = [detMatch[0], detMatch[2]];
			}
		}
		else if (vendor.Contains("Google"))
		{
			if (detMatch = ua.match("(OPR|Opera)\\/([\\d\\.]+)"))
			{
				// version is in detMatch[2]
				// New Opera: 
				// vendor: Google Inc.
				// useragent: "Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/42.0.2311.152 Safari/537.36 OPR/29.0.1795.60"
				detKind = BrowserKindEnum.Opera;
			}
			else
			{
				// Chrome original:
				// useragent: "Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/43.0.2357.81 Safari/537.36"
				detKind = BrowserKindEnum.Chrome;
				detMatch = ua.match("Chrome\\/([\\d\\.]+)");
			}
		}
		else if (vendor.Contains("Apple"))
		{
			detKind = BrowserKindEnum.Safari;
			detMatch = ua.match("Version\\/([\\d\\.]+)");
		}
		else if ((detMatch = ua.match("Firefox\\/([\\d\\.]+)")))
		{
			// firefox has no vendor string
			detKind = BrowserKindEnum.Firefox;
		}
		else if (ua.Contains("Firefox"))
		{
			// User-Agent: Mozilla/5.0 (Windows; U; Windows NT 6.1; en-US; rv:1.9.2.8) Gecko/20100722 Firefox/3.6.8
			detKind = BrowserKindEnum.Firefox;
		}
		else if (ua.Contains("Mobile"))
		{
			detIsMobile = true;
			detKind = BrowserKindEnum.MobilePhone;
		}
		else if (ua.Contains("Chrome"))
		{
			detKind = BrowserKindEnum.Chrome;
		}
		else if (ua.Contains("Safari"))
		{
			detKind = BrowserKindEnum.Safari;
		}


		//**********************************
		// parse version
		//**********************************
		var verNum: number | null = null, verStr: string = detMatch ? detMatch[1] : "";
		if (verStr)
		{
			verNum = parseFloat(RemoveDots(verStr));
		}

		//**********************************
		// final object
		//**********************************
		if (detIsMobile && detIsTablet)
		{
			// this is tablet with Mobile in user-agent: //"Mozilla/5.0 (Linux; Android 4.3; Nexus 7 Build/JSS15Q) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/42.0.2307.2 Mobile Safari/537.36
			// leave IsTablet = true, remove IsMobile
			detIsMobile = false;
		}

		// return object so we may set property comments
		return ({
			// [bool] true: browser was detected, false: not detected
			Found: !!(detKind && detKind > 0),
			// [string] Browser name: Firefox, Chrome, Safari, Opera, MSIE, Unknown
			KindName: BrowserKindEnum[detKind || 0],
			// [BrowserKindEnum] Unknown: 0, Firefox: 1, Chrome: 2, Safari: 3, Opera: 4, MSIE: 5
			Kind: detKind || 0,
			// [float] eg. 8.1
			Version: verNum || 0,
			// [string] version as string, not parsed version, may contains non digit chars
			VersionString: verStr,

			IsCrawler: !!detIsCrawler,
			IsMobile: !!detIsMobile,
			IsTablet: !!detIsTablet,
			IsDesktop: !detIsMobile && !detIsTablet,
			HasTouch: !!detHasTouch,
		});
	}

	var detectedBrowser: {
		/** True: if browser is detected, False: browser not detected	*/
		Found: boolean,
		KindName: string,
		Kind: BrowserKindEnum,
		Version: number,
		VersionString: string,
		IsCrawler: boolean,
		IsMobile: boolean,
		IsTablet: boolean,
		IsDesktop: boolean,
		HasTouch: boolean,
	};

	export function GetBrowser()
	{
		return detectedBrowser || (detectedBrowser = DetectBrowser());
	}

	//#endregion

	//#region OS detection

	function GetWindowsVersionName(ntversion)
	{
		switch (ntversion)
		{
			case 10.0:
				return "Windows 10";
			case 6.3:
				return "Windows 8.1";
			case 6.2:
				return "Windows 8";
			case 6.1:
				return "Windows 7";
			case 6.0:
				return "Windows Vista";
			case 5.2:
				return "Windows XP Professional x64";
			case 5.1:
				return "Windows XP";
			case 4.9:
				return "Windows ME";
			case 5.0:
				return "Windows 2000";
			case 4.1:
				return "Windows 98";
			case 4.0:
				return "Windows NT 4.0";
			default:
				return null;
		}
	}

	function GetIphoneVersion(version)
	{
		switch (version)
		{
			case 4.21:
				return "iPhone 4";
			case 7.0:
				return "iPhone 5";
			case 8.0:
				return "iPhone 6";
			default:
				return null;
		}
	}

	function DetectOS()
	{
		var ua = navigator.userAgent || "";
		var detMatch: RegExpMatchArray | null = null;
		var detKind: OSKindEnum | null = null;

		if (ua.Contains("Windows Phone"))
		{
			// "Mozilla/5.0 (Windows Phone 8.1; ARM; Trident/7.0; Touch; rv:11.0; IEMobile/11.0; NOKIA; Lumia 520) like Gecko"
			// "Mozilla/5.0 (compatible; MSIE 9.0; Windows Phone OS 7.5; Trident/5.0; IEMobile/9.0)"
			detKind = OSKindEnum.WindowsPhone;
			detMatch = ua.match(new RegExp("Windows Phone( OS | )([\\d\\.]+)"));
			if (detMatch)
			{
				detMatch = [detMatch[0], detMatch[2]];
			}
		}
		else if (ua.Contains("Windows"))
		{
			detKind = OSKindEnum.Windows;
			detMatch = ua.match(new RegExp("Windows NT ([\\d\\.]+)"));
		}
		else if (ua.Contains("Mac"))
		{
			detKind = OSKindEnum.Macintosh;
			// "Mozilla/5.0 (iPhone; CPU iPhone OS 8_0 like Mac OS X) AppleWebKit/600.1.3 (KHTML, like Gecko) Version/8.0 Mobile/12A4345d Safari/600.1.4"
			// Mozilla/5.0 (iPad; CPU OS 7_1_1 like Mac OS X) AppleWebKit/537.51.2 (KHTML, like Gecko) Version/7.0 Mobile/11D201 Safari/9537.53
			// Mozilla/5.0 (Macintosh; Intel Mac OS X 10_6_8) AppleWebKit/534.59.10 (KHTML, like Gecko) Version/5.1.9 Safari/534.59.10
			detMatch = ua.match(new RegExp("(OS |OS X )([\\d_]+)"));
			if (detMatch && detMatch[2])
			{
				detMatch = [detMatch[0], detMatch[2].replace(new RegExp("_", "g"), ".")];
			}
		}
		else if (ua.Contains("Android"))
		{
			// must test for Android before Linux because Android userAgent contains Linux word too
			detKind = OSKindEnum.Android;
			detMatch = ua.match(new RegExp("Android ([\\d\\.]+)"));
		}
		else if (ua.Contains("Linux"))
		{
			detKind = OSKindEnum.Linux;
		}



		var verNum: number | null = null, verStr = detMatch ? detMatch[1] : "", winVersion: string | null = null, iPhoneVersion: string | null = null;

		if (verStr)
		{
			verNum = parseFloat(RemoveDots(verStr));
			if (detKind == OSKindEnum.Windows)
			{
				winVersion = GetWindowsVersionName(verNum);
			}
			else if (detKind == OSKindEnum.Macintosh)
			{
				// detect iPhone version
				iPhoneVersion = GetIphoneVersion(verNum);
			}
		}

		return {
			// [bool] true: OS was detected, false: not detected
			Found: !!(detKind && detKind > 0),
			// [string] OS name: Windows, Macintosh, Android, Linux, Unknown
			KindName: Calysto.Enum.GetName(OSKindEnum, detKind || 0),
			// [OSKindEnum] Unknown: 0, Windows: 1, Macintosh: 2, Android: 3, Linux: 4
			Kind: detKind || 0,
			// [float] version
			Version: verNum || 0,
			// [string] version as string, non parsed
			VersionString: verStr,
			// [string] windows exact version
			WinName: winVersion,
			// [string] iPhone version
			iPhoneVersion: iPhoneVersion,

			IsWindows: detKind == OSKindEnum.Windows,
			IsAndroid: detKind == OSKindEnum.Android,
			IsLinux: detKind == OSKindEnum.Linux,
			IsMacintosh: detKind == OSKindEnum.Macintosh
		};
	}

	var detectedOS: {
		/** true: OS was detected, false: not detected */
		Found: boolean,
		Kind: OSKindEnum,
		KindName: string,
		Version: number,
		VersionString: string,
		WinName: string | null,
		iPhoneVersion: string | null
	};

	export function GetOS()
	{
		return detectedOS || (detectedOS = DetectOS());
	}

	//#endregion
}

