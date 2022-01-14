using System;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;
using System.Drawing;
using Calysto.Linq;

namespace Calysto.Colorspace
{
	/// <summary>
	/// Structure to define RGB.
	/// </summary>
	public class RGB
	{
		#region Fields
		private int _red = 255;
		private int _green = 255;
		private int _blue = 255;
		private double _alpha = 1;

		#endregion

		#region Operators
		public static bool operator ==(RGB item1, RGB item2)
		{
			return (
				item1.Red == item2.Red 
				&& item1.Green == item2.Green 
				&& item1.Blue == item2.Blue
				&& item1.Alpha == item2.Alpha
				);
		}

		public static bool operator !=(RGB item1, RGB item2)
		{
			return (
				item1.Red != item2.Red 
				|| item1.Green != item2.Green 
				|| item1.Blue != item2.Blue
				|| item1.Alpha != item2.Alpha
				);
		}

		#endregion

		#region Accessors
		[Description("Red component."),]
		public int Red
		{
			get
			{
				return _red;
			}
			set
			{
				_red = (value>255)? 255 : ((value<0)?0 : value);
			}
		}

		[Description("Green component."),]
		public int Green
		{
			get
			{
				return _green;
			}
			set
			{
				_green = (value>255)? 255 : ((value<0)?0 : value);
			}
		}

		[Description("Blue component."),]
		public int Blue
		{
			get
			{
				return _blue;
			}
			set
			{
				_blue = (value>255)? 255 : ((value<0)?0 : value);
			}
		}

		[Description("Alpha component."),]
		public double Alpha
		{
			get
			{
				return _alpha;
			}
			set
			{
				_alpha = (value > 1) ? 1 : ((value < 0) ? 0 : value);
			}
		}
		#endregion

		/// <summary>
		/// 
		/// </summary>
		/// <param name="R">0...255</param>
		/// <param name="G">0...255</param>
		/// <param name="B">0...255</param>
		/// <param name="alpha">0...1</param>
		public RGB(int R, int G, int B, double alpha = 1) 
		{
			this.Red = R;
			this.Green = G;
			this.Blue = B;
			this.Alpha = alpha;
		}

		#region Methods
		public override bool Equals(Object obj) 
		{
			if(obj==null || GetType()!=obj.GetType()) return false;

			return (this == (RGB)obj);
		}

		public override int GetHashCode() 
		{
			return Red.GetHashCode() ^ Green.GetHashCode() ^ Blue.GetHashCode() ^ Alpha.GetHashCode();
		}

		#endregion

		const string _colorNamesStr = @"
			'aliceblue': '#f0f8ff',
			'antiquewhite': '#faebd7',
			'aqua': '#00ffff',
			'aquamarine': '#7fffd4',
			'azure': '#f0ffff',
			'beige': '#f5f5dc',
			'bisque': '#ffe4c4',
			'black': '#000000',
			'blanchedalmond': '#ffebcd',
			'blue': '#0000ff',
			'blueviolet': '#8a2be2',
			'brown': '#a52a2a',
			'burlywood': '#deb887',
			'cadetblue': '#5f9ea0',
			'chartreuse': '#7fff00',
			'chocolate': '#d2691e',
			'coral': '#ff7f50',
			'cornflowerblue': '#6495ed',
			'cornsilk': '#fff8dc',
			'crimson': '#dc143c',
			'cyan': '#00ffff',
			'darkblue': '#00008b',
			'darkcyan': '#008b8b',
			'darkgoldenrod': '#b8860b',
			'darkgray': '#a9a9a9',
			'darkgrey': '#a9a9a9',
			'darkgreen': '#006400',
			'darkkhaki': '#bdb76b',
			'darkmagenta': '#8b008b',
			'darkolivegreen': '#556b2f',
			'darkorange': '#ff8c00',
			'darkorchid': '#9932cc',
			'darkred': '#8b0000',
			'darksalmon': '#e9967a',
			'darkseagreen': '#8fbc8f',
			'darkslateblue': '#483d8b',
			'darkslategray': '#2f4f4f',
			'darkslategrey': '#2f4f4f',
			'darkturquoise': '#00ced1',
			'darkviolet': '#9400d3',
			'deeppink': '#ff1493',
			'deepskyblue': '#00bfff',
			'dimgray': '#696969',
			'dimgrey': '#696969',
			'dodgerblue': '#1e90ff',
			'firebrick': '#b22222',
			'floralwhite': '#fffaf0',
			'forestgreen': '#228b22',
			'fuchsia': '#ff00ff',
			'gainsboro': '#dcdcdc',
			'ghostwhite': '#f8f8ff',
			'gold': '#ffd700',
			'goldenrod': '#daa520',
			'gray': '#808080',
			'grey': '#808080',
			'green': '#008000',
			'greenyellow': '#adff2f',
			'honeydew': '#f0fff0',
			'hotpink': '#ff69b4',
			'indianred': '#cd5c5c',
			'indigo': '#4b0082',
			'ivory': '#fffff0',
			'khaki': '#f0e68c',
			'lavender': '#e6e6fa',
			'lavenderblush': '#fff0f5',
			'lawngreen': '#7cfc00',
			'lemonchiffon': '#fffacd',
			'lightblue': '#add8e6',
			'lightcoral': '#f08080',
			'lightcyan': '#e0ffff',
			'lightgoldenrodyellow': '#fafad2',
			'lightgray': '#d3d3d3',
			'lightgrey': '#d3d3d3',
			'lightgreen': '#90ee90',
			'lightpink': '#ffb6c1',
			'lightsalmon': '#ffa07a',
			'lightseagreen': '#20b2aa',
			'lightskyblue': '#87cefa',
			'lightslategray': '#778899',
			'lightslategrey': '#778899',
			'lightsteelblue': '#b0c4de',
			'lightyellow': '#ffffe0',
			'lime': '#00ff00',
			'limegreen': '#32cd32',
			'linen': '#faf0e6',
			'magenta': '#ff00ff',
			'maroon': '#800000',
			'mediumaquamarine': '#66cdaa',
			'mediumblue': '#0000cd',
			'mediumorchid': '#ba55d3',
			'mediumpurple': '#9370d8',
			'mediumseagreen': '#3cb371',
			'mediumslateblue': '#7b68ee',
			'mediumspringgreen': '#00fa9a',
			'mediumturquoise': '#48d1cc',
			'mediumvioletred': '#c71585',
			'midnightblue': '#191970',
			'mintcream': '#f5fffa',
			'mistyrose': '#ffe4e1',
			'moccasin': '#ffe4b5',
			'navajowhite': '#ffdead',
			'navy': '#000080',
			'oldlace': '#fdf5e6',
			'olive': '#808000',
			'olivedrab': '#6b8e23',
			'orange': '#ffa500',
			'orangered': '#ff4500',
			'orchid': '#da70d6',
			'palegoldenrod': '#eee8aa',
			'palegreen': '#98fb98',
			'paleturquoise': '#afeeee',
			'palevioletred': '#d87093',
			'papayawhip': '#ffefd5',
			'peachpuff': '#ffdab9',
			'peru': '#cd853f',
			'pink': '#ffc0cb',
			'plum': '#dda0dd',
			'powderblue': '#b0e0e6',
			'purple': '#800080',
			'red': '#ff0000',
			'rosybrown': '#bc8f8f',
			'royalblue': '#4169e1',
			'saddlebrown': '#8b4513',
			'salmon': '#fa8072',
			'sandybrown': '#f4a460',
			'seagreen': '#2e8b57',
			'seashell': '#fff5ee',
			'sienna': '#a0522d',
			'silver': '#c0c0c0',
			'skyblue': '#87ceeb',
			'slateblue': '#6a5acd',
			'slategray': '#708090',
			'slategrey': '#708090',
			'snow': '#fffafa',
			'springgreen': '#00ff7f',
			'steelblue': '#4682b4',
			'tan': '#d2b48c',
			'teal': '#008080',
			'thistle': '#d8bfd8',
			'tomato': '#ff6347',
			'turquoise': '#40e0d0',
			'violet': '#ee82ee',
			'wheat': '#f5deb3',
			'white': '#ffffff',
			'whitesmoke': '#f5f5f5',
			'yellow': '#ffff00',
			'yellowgreen': '#9acd32'
		";

		static Dictionary<string, string> _dicHexNamedColors;

		static Dictionary<string, string> _dicNamedHexColors = new Func<Dictionary<string, string>>(() =>
		{
			var dic = _colorNamesStr.Split('\r', '\n').Select(o => o.Trim()).Where(o => !string.IsNullOrWhiteSpace(o)).Select(o =>
			{
				var arr = o.Split(':').Select(k => Regex.Match(k, "[\\w\\#]+").Value.ToLower()).ToArray();
				return new { Key = arr[0], Value = arr[1]};
			}).ToDictionary(o => o.Key, o => o.Value);

			_dicHexNamedColors = dic.Distinct(o=>o.Value).ToDictionary(o => o.Value, o => o.Key);

			return dic;
		}).Invoke();
		
		private static double ParseDouble(string str)
		{
			return double.Parse(str, Calysto.Globalization.CalystoCultureInfoHelper.USCulture);
		}

		public static RGB Parse(string colorStr)
		{
			string hex = null;

			if(colorStr.IndexOf("hsl") == 0)
			{
				return HSL.Parse(colorStr).ToRGB();
			}
			else if (colorStr.IndexOf("rgb") == 0)
			{
				var arr = Regex.Matches(colorStr, "[\\d\\.]+").Cast<Match>().Select(o=>o.Value).ToArray();
				double alpha = 1;
				if(arr.Length > 3)
				{
					alpha = ParseDouble(arr[3]);
				}
				return new RGB(int.Parse(arr[0]), int.Parse(arr[1]), int.Parse(arr[2]), alpha);
			}
			else if (colorStr.IndexOf("#") == 0)
			{
				var converter = new Calysto.Converter.CalystoRadixConvert();
				var str = colorStr.Substring(1);
				// hex string can be 3 or 6 chars and hash # at start
				var h = Regex.Matches(str, "(.{" + str.Length / 3 + "})").Cast<Match>().Select(o => o.Value).ToArray();
				int[] vals = new int[h.Length];
				for (var i = 0; i < h.Length; i++)
				{
					vals[i] = converter.Convert<int>(h[i], 16, 10);
				}
				return new RGB(vals[0], vals[1], vals[2]);
			}
			else if (_dicNamedHexColors.TryGetValue(colorStr.ToLower(), out hex))
			{
				return RGB.Parse(hex);
			}
			throw new NotSupportedException(colorStr + " can not be converted to RGB color");
		}

		public Color ToColor()
		{
			return System.Drawing.Color.FromArgb((int)(this.Alpha * 255), this.Red, this.Green, this.Blue);
		}

		public HSL ToHSL()
		{
			var rgba = this;
			var result = new HSL(0, 0, 0, 0);

			var r = (double) rgba.Red / 255;
			var g = (double) rgba.Green / 255;
			var b = (double) rgba.Blue / 255;
			var hue = (double)0;

			result.Alpha = rgba.Alpha;

			var minVal = new[] { r, g, b }.Min();
			var maxVal = new[] { r, g, b }.Max();
			var delta = maxVal - minVal;

			result.Luminance = maxVal;

			if (delta == 0)
			{
				hue = 0;
				result.Saturation = 0;
			}
			else
			{
				result.Saturation = delta / maxVal;
				var del_R = (((maxVal - r) / 6.0) + (delta / 2.0)) / delta;
				var del_G = (((maxVal - g) / 6.0) + (delta / 2.0)) / delta;
				var del_B = (((maxVal - b) / 6.0) + (delta / 2.0)) / delta;

				if (r == maxVal) { hue = del_B - del_G; }
				else if (g == maxVal) { hue = (1.0 / 3.0) + del_R - del_B; }
				else if (b == maxVal) { hue = (2.0 / 3.0) + del_G - del_R; }

				if (hue < 0) { hue += 1.0; }
				if (hue > 1) { hue -= 1.0; }
			}

			// don't round it, to be more precize when adjusting values for web
			result.Hue = (hue * 360.0);
			return result;
		}

		public string ToRgbString()
		{
			bool hasAlpha = this.Alpha != 1;
			var str = "rgb";
			if (hasAlpha) str += "a";
			str += "(" + this.Red + "," + this.Green + "," + this.Blue;
			if (hasAlpha) str += "," + this.Alpha.ToString(Calysto.Globalization.CalystoCultureInfoHelper.USCulture);
			str += ")";
			return str;
		}

		public string ToNamedColorString()
		{
			return _dicHexNamedColors.GetValueOrDefault(this.ToHexString().ToLower());
		}

		public string ToHexString()
		{
			bool hasAlpha = this.Alpha != 1; // 0...1
			if (hasAlpha)
			{
				return String.Format("#{0:x2}{1:x2}{2:x2}{3:x2}", (int)(this.Alpha * 255.0), (int)this.Red, (int)this.Green, (int)this.Blue);
			}
			else
			{
				return String.Format("#{0:x2}{1:x2}{2:x2}", (int)this.Red, (int)this.Green, (int)this.Blue);
			}
		}

		public override string ToString()
		{
			return ToRgbString();
		}
	} 
}
