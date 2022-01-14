using Calysto.Linq;
using System.Collections.Generic;

namespace Calysto.Web.Script.Services.WebSockets
{
	public class SocketWebRequestArguments
	{
		public bool IsSocketWebClient { get; set; }

		/** used for ajax request over socket */
		public string AjaxQueryString { get; set; }

		/** used for ajax request over socket */
		public Dictionary<string, object> AjaxArgs { get; set; }

		public static SocketWebRequestArguments ConvertRequestObj(object requestObj)
		{
			SocketWebRequestArguments item = new SocketWebRequestArguments();

			Dictionary<string, object> dic = requestObj as Dictionary<string, object>;
			if (dic != null)
			{
				item.IsSocketWebClient = object.Equals(dic.GetValueOrDefault(nameof(IsSocketWebClient)), true);
				if (item.IsSocketWebClient)
				{
					item.AjaxQueryString = (string)dic[nameof(AjaxQueryString)];
					item.AjaxArgs = (Dictionary<string, object>)dic[nameof(AjaxArgs)];
				}
			}

			return item;
		}
	};

}
