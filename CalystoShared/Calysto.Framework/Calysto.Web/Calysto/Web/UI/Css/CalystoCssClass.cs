using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System.Drawing;
using Calysto.Colorspace;
using System.Text.RegularExpressions;
using Calysto.Linq;
using Calysto.Graphics;

namespace Calysto.Web.UI.Css
{
	public class CalystoCssClass : ICalystoCssItem
	{
		static Regex _removeSpaces = new Regex("[ ][ ]+");

		public static List<string> SplitClassNames(params string[] classNames)
		{
			if (classNames == null || !classNames.Any())
			{
				return new List<string>();
			}
			// replace > 1 space with single space
			return _removeSpaces.Replace(classNames.ToStringJoined(", "), " ").Split(',').Select(o => o.Trim()).Where(o=>!string.IsNullOrEmpty(o)).ToList();
		}

		public static List<string> SplitClassNames(List<string> classNames)
		{
			return SplitClassNames(classNames.ToArray());
		}

		private static CultureInfo UsCultureInfo = CultureInfo.GetCultureInfo("en-us");

		public List<string> ClassNames { get; private set; }

		public CalystoStyleCollection Style { get; private set; }

		/// <summary>
		/// Encapsulate current CssClass into media rule, eg. screen and (max-width:300px). Will surround css class with @media screen and (max-width:300px){...}
		/// </summary>
		public string MediaRule { get; set; }

		public CalystoCssClass(params string [] className)
		{
			this.ClassNames = SplitClassNames(className);
			this.Style = new CalystoStyleCollection();
		}

		public CalystoCssClass(List<string> classNames, CalystoStyleCollection styles)
		{
			this.ClassNames = SplitClassNames(classNames);
			this.Style = styles;
		}

		/// <summary>
		/// Deep clone everything.
		/// </summary>
		/// <returns></returns>
		public CalystoCssClass Clone()
		{
			return new CalystoCssClass(this.ClassNames.ToList(), this.Style.Clone());
		}

		ICalystoCssItem ICalystoCssItem.Clone()
		{
			return this.Clone();
		}

		public string GetStyleString()
		{
			return this.Style.AsEnumerable().Select(m => "\t" + m.Key + ":" + m.Value + ";").ToStringJoined("\r\n");
		}

		public string GetCssRuleString()
		{
			if (this.ClassNames.Any())
			{
				return
					this.ClassNames.ToStringJoined(",\r\n") + "\r\n{\r\n"
					+ this.GetStyleString()
					+ "\r\n}";
			}
			else
			{
				return null;
			}
		}

		public string GetMediaRuleString(string cssRulesString)
		{
			return
				(this.MediaRule != null ? ("@media " + this.MediaRule + "\r\n{\r\n") : null)
				+ cssRulesString
				+ (this.MediaRule != null ? "\r\n}" : null);
		}

		public string ToCssString()
		{
			return GetMediaRuleString(GetCssRuleString());
		}

		public CalystoCssClass AddToStyleSheet(CalystoStyleSheet sheet)
		{
			sheet.Add(this);
			return this;
		}

		public CalystoCssClass ApplyStyle(string styleValues)
		{
			if (!string.IsNullOrEmpty(styleValues))
			{
				this.Style.ApplyValues(styleValues);
			}
			return this;
		}

		public CalystoCssClass ApplyClass(params CalystoCssClass[] cssClass)
		{
			cssClass.Where(o=>o != null).ForEach(o => this.Style.ApplyValues(o.Style));
			return this;
		}

		public CalystoCssClass ApplyValue(string propertyName, string value)
		{
			this.Style[propertyName] = value ?? "";
			return this;
		}

		/// <summary>
		/// Add style if value is not null or empty.
		/// </summary>
		/// <param name="propertyName"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public CalystoCssClass ApplyValueIf(string propertyName, string value, bool condition)
		{
			if(condition)
			{
				this.ApplyValue(propertyName, value);
			}
			return this;
		}

		#region border

		public CalystoCssClass BorderWidth(int topPx, int rightPx, int bottomPx, int leftPx)
		{
			return this.ApplyValue("border-width", new[] { topPx, rightPx, bottomPx, leftPx }.Select(o => o + "px").ToStringJoined(" "));
		}

		public CalystoCssClass BorderColor(string topColor, string rightColor, string bottomColor, string leftColor)
		{
			return this.ApplyValue("border-color", new []{topColor, rightColor, bottomColor, leftColor}.ToStringJoined(" "));
		}

		public CalystoCssClass BorderStyle(string topStyle, string rightStyle, string bottomStyle, string leftStyle)
		{
			return this.ApplyValue("border-style", new []{topStyle, rightStyle, bottomStyle, leftStyle}.ToStringJoined(" "));
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="widthPx">width</param>
		/// <param name="style">none, hidden, dotted, dashed, solid, double, groove, ridge, inset, outset, inherit</param>
		/// <param name="color">color</param>
		/// <returns></returns>
		public CalystoCssClass Border(int widthPx, string borderStyle, string borderColor)
		{
			return this.ApplyValue("border", new[] { widthPx + "px", borderStyle, borderColor }.ToStringJoined(" "));
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="borderStyle">width borderStyle borderColor</param>
		/// <returns></returns>
		public CalystoCssClass Border(string borderStyle)
		{
			return this.ApplyValue("border", borderStyle);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="borderRadius">
		///		<para>a: width all</para>
		///		<para>a b: top and bottom rigth and left</para>
		///		<para>a b c d: top right bottom left</para>
		/// <returns></returns>
		public CalystoCssClass BorderRadius(string borderRadius)
		{
			return this.ApplyValue("border-radius", borderRadius);
		}

		#endregion

		#region background

		public CalystoCssClass BackgroundImage(byte[] imgBytes, string mime)
		{
			return this.ApplyValue("background-image", CalystoCssHelper.Base64EncodeImage(imgBytes, mime));
		}

		public CalystoCssClass BackgroundImage(string url)
		{
			return this.ApplyValue("background-image", "url(" + url + ")");
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="value">
		///		<para>scroll	The background scrolls along with the element. This is default</para>
		///		<para>fixed	The background is fixed with regard to the viewport</para>
		///		<para>local	The background scrolls along with the element's contents</para>
		/// </param>
		/// <returns></returns>
		public CalystoCssClass BackgroundAttachment(string value = "scroll")
		{
			return this.ApplyValue("background-attachment", value);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="color">transparent or color (#rrggbb, rbg, rgba...)</param>
		/// <returns></returns>
		public CalystoCssClass BackgroundColor(string color)
		{
			return this.ApplyValue("background-color", color);
		}

		public CalystoCssClass BackgroundColor(Color color)
		{
			return this.BackgroundColor(color.ToRgbString());
		}

		public CalystoCssClass BackgroundPosition(string hPosition = "left", string vPosition = "top")
		{
			return this.ApplyValue("background-position", hPosition + " " + vPosition);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="repeat">repeat (default), repeat-x, repeat-y, no-repeat</param>
		/// <returns></returns>
		public CalystoCssClass BackgroundRepeat(string repeat = "repeat")
		{
			return this.ApplyValue("background-position", repeat);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="clip">
		///		<para>border-box (default)	The background is clipped to the border box</para>
		///		<para>padding-box	The background is clipped to the padding box</para>
		///		<para>content-box	The background is clipped to the content box</para>
		/// </param>
		/// <returns></returns>
		public CalystoCssClass BackgroundClip(string clip = "border-box")
		{
			return this.ApplyValue("background-clip", clip);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="origin">
		///		<para>padding-box (default)	The background image is positioned relative to the padding box</para>
		///		<para>border-box	The background image is positioned relative to the border box</para>
		///		<para>content-box	The background image is positioned relative to the content box</para>
		///		<para></para>
		/// </param>
		/// <returns></returns>
		public CalystoCssClass BackgroundOrigin(string origin = "padding-box")
		{
			return this.ApplyValue("background-origin", origin);
		}

		/// <summary>
		/// specifies the size of the background images
		/// </summary>
		/// <param name="hSize">
		///		<para>length in units	Sets the width and height of the background image. The first value sets the width, the second value sets the height. If only one value is given, the second is set to "auto"</para>
		///		<para>percentage in % 	Sets the width and height of the background image in percent of the parent element. The first value sets the width, the second value sets the height. If only one value is given, the second is set to "auto"</para>
		///		<para>cover	Scale the background image to be as large as possible so that the background area is completely covered by the background image. Some parts of the background image may not be in view within the background positioning area</para>
		///		<para>contain	Scale the image to the largest size such that both its width and its height can fit inside the content area</para>
		/// </param>
		/// <param name="vSize"></param>
		/// <returns></returns>
		public CalystoCssClass BackgroundSize(string hSize = "auto", string vSize = "auto")
		{
			return this.ApplyValue("background-size", hSize + " " + vSize);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="color">transparent (default) or color</param>
		/// <param name="imageUrl">none (default) or url, will be encapsulated into url(...)</param>
		/// <param name="repeat">repeat (default), repeat-x, repeat-y, no-repeat</param>
		/// <param name="hPosition">left (default), right, center, %, px</param>
		/// <param name="vPosition">top (default), bottom, center, %, px</param>
		/// <param name="size">
		///		<para>length	Sets the width and height of the background image. The first value sets the width, the second value sets the height. If only one value is given, the second is set to "auto"</para>
		///		<para>percentage	Sets the width and height of the background image in percent of the parent element. The first value sets the width, the second value sets the height. If only one value is given, the second is set to "auto"</para>
		///		<para>cover	Scale the background image to be as large as possible so that the background area is completely covered by the background image. Some parts of the background image may not be in view within the background positioning area</para>
		///		<para>contain	Scale the image to the largest size such that both its width and its height can fit inside the content area</para>
		/// </param>
		/// <param name="attachment">scroll (default), fixed, local</param>
		/// <param name="clip"></param>		
		/// <param name="origin"></param>
		/// <returns></returns>
		public CalystoCssClass Background(string color, string imageUrl = null, string repeat = "repeat", string hPosition = "left", string vPosition ="top")
		{
			this.BackgroundColor(color);
			if (imageUrl != null)
			{
				this.BackgroundImage(imageUrl).BackgroundRepeat(repeat).BackgroundPosition(hPosition, vPosition);
			}
			return this;
		}

		#endregion

		#region opacity

		/// <summary>
		/// 
		/// </summary>
		/// <param name="opacity">range 0 - 100 (full visibility = 100)</param>
		/// <returns></returns>
		public CalystoCssClass Opacity(int opacity = 100)
		{
			 /*filter for For IE8 and earlier */
			return this.ApplyValue("filter", "alpha(opacity=" + opacity + ")")
				.ApplyValue("opacity", ((decimal)opacity / 100).ToString(UsCultureInfo));
		}

		#endregion

		#region transition

		/// <summary>
		/// 
		/// </summary>
		/// <param name="propertyName">Specifies the name of the CSS property the transition effect is for</param>
		/// <returns></returns>
		public CalystoCssClass TransitionProperty(string propertyName = "all")
		{
			new[]{
				"transition-property",
				"-moz-transition-property", /* Firefox 4 */
				"-webkit-transition-property", /* Safari and Chrome */
				"-o-transition-property" /* Opera */
			}.ForEach(o => this.ApplyValue(o, propertyName));

			return this;
		}

		public CalystoCssClass TransitionDuration(int durationMs = 400)
		{
			new[]{
				"transition-duration",
				"-webkit-transition-duration" /* Safari */
			}.ForEach(o => this.ApplyValue(o, durationMs + "ms"));
			
			return this;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="function">
		///		<para>linear	Specifies a transition effect with the same speed from start to end (equivalent to cubic-bezier(0,0,1,1))</para>
		///		<para>ease	Specifies a transition effect with a slow start, then fast, then end slowly (equivalent to cubic-bezier(0.25,0.1,0.25,1))</para>
		///		<para>ease-in	Specifies a transition effect with a slow start (equivalent to cubic-bezier(0.42,0,1,1))</para>
		///		<para>ease-out	Specifies a transition effect with a slow end (equivalent to cubic-bezier(0,0,0.58,1))</para>
		///		<para>ease-in-out	Specifies a transition effect with a slow start and end (equivalent to cubic-bezier(0.42,0,0.58,1))</para>
		///		<para>cubic-bezier(n,n,n,n)	Define your own values in the cubic-bezier function. Possible values are numeric values from 0 to 1</para>
		/// </param>
		/// <returns></returns>
		public CalystoCssClass TransitionTimingFunction(string function = "ease")
		{
			new[]{
				"transition-timing-function",
				"-webkit-transition-timing-function" /* Safari and Chrome */
			}.ForEach(o => this.ApplyValue(o, function));
			return this;
		}

		public CalystoCssClass TransitionDelay(int delayMs = 400)
		{
			new[]{
				"transition-delay",
				"-webkit-transition-delay" /* Safari */
			}.ForEach(o => this.ApplyValue(o, delayMs + "ms"));
			return this;
		}

		/// <summary>
		/// single line transition
		/// </summary>
		/// <param name="propertyName">Specifies the name of the CSS property the transition effect is for. Css default is all.</param>
		/// <param name="durationMs">Specifies how many seconds or milliseconds the transition effect takes to complete. Css default is 0</param>
		/// <param name="delayMs">Defines when the transition effect will start. css default is 0</param>
		/// <param name="function">
		///		<para>linear	Specifies a transition effect with the same speed from start to end (equivalent to cubic-bezier(0,0,1,1))</para>
		///		<para>ease	Specifies a transition effect with a slow start, then fast, then end slowly (equivalent to cubic-bezier(0.25,0.1,0.25,1))</para>
		///		<para>ease-in	Specifies a transition effect with a slow start (equivalent to cubic-bezier(0.42,0,1,1))</para>
		///		<para>ease-out	Specifies a transition effect with a slow end (equivalent to cubic-bezier(0,0,0.58,1))</para>
		///		<para>ease-in-out	Specifies a transition effect with a slow start and end (equivalent to cubic-bezier(0.42,0,0.58,1))</para>
		///		<para>cubic-bezier(n,n,n,n)	Define your own values in the cubic-bezier function. Possible values are numeric values from 0 to 1</para>
		/// </param>
		/// <returns></returns>
		public CalystoCssClass Transition(string propertyName = "all", int durationMs = 400, string function = "ease", int delayMs = 0)
		{
			string val = new object[] { propertyName, durationMs + "ms", function, delayMs + "ms" }.ToStringJoined(" ");
			new[]{
				"transition",
				"-webkit-transition" /* Safari */
			}.ForEach(o => this.ApplyValue(o, val));
			return this;

		}

		#endregion

		#region transform

		/// <summary>
		/// 
		/// </summary>
		/// <param name="xAxis">left, center, right, value px, value %</param>
		/// <param name="yAxis">left, center, right, value px, value %</param>
		/// <param name="zAxis">value px</param>
		/// <returns></returns>
		public CalystoCssClass TransformOrigin(string xAxis = "50%", string yAxis = "50%", string zAxis = "0")
		{
			string value = new string[] { xAxis, yAxis, zAxis }.ToStringJoined(" ");
			new []{
				"transform-origin",
				"-ms-transform-origin", /* IE 9 */
				"-webkit-transform-origin" /* Safari and Chrome */
			}.ForEach(o=>this.ApplyValue(o, value));

			return this;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="transformStyle">flat, preserve-3d</param>
		/// <returns></returns>
		public CalystoCssClass TransformStyle(string transformStyle)
		{
			new[]{
				"transform-style",
				"-webkit-transform-style" /* Safari and Chrome */
			}.ForEach(o => this.ApplyValue(o, transformStyle));
		
			return this;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="transformFunc">
		///		<para>none</para>
		///		<para></para>
		///		<para>matrix(n,n,n,n,n,n) 2D transform</para>
		///		<para>matrix3d(n,n,n,n,n,n,n,n,n,n,n,n,n,n,n,n) 3D transform</para>
		///		<para>translate(x,y)</para>
		///		<para>translate3d(x,y,z)</para>
		///		<para>translateX(x)</para>
		///		<para>translateY(y)</para>
		///		<para>translateZ(z)</para>
		///		<para>scale(x,y)</para>
		///		<para>scale3d(x,y,z)</para>
		///		<para>scaleX(x)</para>
		///		<para>scaleY(y)</para>
		///		<para>scaleZ(z)</para>
		///		<para>rotate(angle)</para>
		///		<para>rotate3d(x,y,z,angle)</para>
		///		<para>rotateX(angle)</para>
		///		<para>rotateY(angle)</para>
		///		<para>rotateZ(angle)</para>
		///		<para>skew(x-angle,y-angle)</para>
		///		<para>skewX(angle)</para>
		///		<para>skewY(angle)</para>
		///		<para>perspective(n)</para>
		/// </param>
		/// <returns></returns>
		public CalystoCssClass Transform(string transformFunc)
		{
			new[]{
				"transform",
				"-ms-transform", /* IE 9 */
				"-webkit-transform" /* Safari and Chrome */
			}.ForEach(o => this.ApplyValue(o, transformFunc));
			return this;
		}

		#endregion


	}
}
