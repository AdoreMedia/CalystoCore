using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Calysto.Common.Extensions;

namespace Calysto.Web
{
	public static class WebBotDetector
	{
		public enum NameEnum
		{
			Google = 1,
			Bing,
			Yahoo,
			DuckDuck,
			Baidu,
			Yandex,
			Sogou,
			Exabot,
			Facebook,
			Alexa,
			Crawler,
			Bot,
		}

		public static bool TryResolveWebBot(string userAgent, out NameEnum botName)
		{
			// based on:
			// https://www.keycdn.com/blog/web-crawlers

			botName = (NameEnum)(-1);

			if (string.IsNullOrEmpty(userAgent))
			{
				return false;
			}

			if(userAgent.Contains("Google", true))
			{
				botName = NameEnum.Google;
				return true;
			}

			if(userAgent.Contains("Bing", true))
			{
				botName = NameEnum.Bing;
				return true;
			}

			if(userAgent.Contains("Yahoo", true))
			{
				botName = NameEnum.Yahoo;
				return true;
			}

			if(userAgent.Contains("DuckDuck", true))
			{
				botName = NameEnum.DuckDuck;
				return true;
			}

			if(userAgent.Contains("Baidu", true))
			{
				botName = NameEnum.Baidu;
				return true;
			}

			if(userAgent.Contains("Yandex", true))
			{
				botName = NameEnum.Yandex;
				return true;
			}

			if(userAgent.Contains("Sogou", true))
			{
				botName = NameEnum.Sogou;
				return true;
			}

			if(userAgent.Contains("Exabot", true))
			{
				botName = NameEnum.Exabot;
				return true;
			}

			if(userAgent.Contains("Facebook", true) || userAgent.Contains("Facebot", true))
			{
				botName = NameEnum.Facebook;
				return true;
			}

			if(userAgent.Contains("Alexa", true))
			{
				botName = NameEnum.Alexa;
				return true;
			}

			if(userAgent.Contains("Crawler", true))
			{
				botName = NameEnum.Crawler;
				return true;
			}

			if(userAgent.Contains("bot", true))
			{
				botName = NameEnum.Bot;
				return true;
			}

			return false;
		}
	}
}
