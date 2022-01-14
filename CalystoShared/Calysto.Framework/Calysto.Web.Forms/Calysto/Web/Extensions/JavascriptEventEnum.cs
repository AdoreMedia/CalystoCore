#if !SILVERLIGHT

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Calysto.Extensions;

namespace Calysto.Web.Extensions
{
	public enum JavascriptEventEnum
	{
		[StringValue("mouseover")]
		MouseOver,

		[StringValue("mouseout")]
		MouseOut,

		[StringValue("click")]
		Click,

		[StringValue("keydown")]
		KeyDown,

		[StringValue("keyup")]
		KeyUp,

		[StringValue("change")]
		Change,

		[StringValue("focus")]
		Focus,

		[StringValue("blur")]
		Blur,
	}
}

#endif