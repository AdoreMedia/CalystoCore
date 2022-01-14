using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Calysto.Common;
using Calysto.Web.Script.Services.WebSockets;
using Calysto.TypeLite.TsModels;
using Calysto.Web.Script.Services;

namespace Calysto.TypeLite
{
	/// <summary>
	/// Defines output of the generator
	/// </summary>
	[Flags]
	public enum TsGeneratorOutput
	{

		Properties = 1,

		Enums = 1 << 1,

		Fields = 1 << 2,

		Constants = 1 << 3,

		/// <summary>
		/// Methods with <see cref="CalystoWebMethodAttribute"/>
		/// </summary>
		AjaxMethods = 1 << 4,

		/// <summary>
		/// Methods with <see cref="CalystoWebMethodAttribute"/> inside <see cref="IWebSocketSession"/>
		/// </summary>
		SocketMethods = 1 << 5,

		/// <summary>
		/// Methods with <see cref="CalystoWebMethodAttribute"/> inside <see cref="ICalystoWebViewHostObject"/>
		/// </summary>
		WebViewHostMethods = 1 << 6,

		/// <summary>
		/// Types added using .ForResx<T>()
		/// </summary>
		Resx = 1 << 7,

		/// <summary>
		/// Used with <see cref="WebViewHostMethods"/> to generate TS class with proxy methods, inherited from <see cref="Calysto.WebView.HostObjectBase"/><br/>
		/// Proxy methods can be used in TS to invoke C# methods in <see cref="ICalystoWebViewHostObject"/>
		/// </summary>
		Implementation = 1 << 8,
	}
}
