using System;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Linq;

namespace Calysto.Colorspace
{
	/// <summary>
	/// Structure to define HSL.
	/// </summary>
	public class HSL
	{
		#region Fields
		private double _hue = 0;
		private double _saturation = 0.5;
		private double _luminance = 1;
		private double _alpha = 1;
		#endregion

		#region Operators
		public static bool operator ==(HSL item1, HSL item2)
		{
			return (
				item1.Hue == item2.Hue
				&& item1.Saturation == item2.Saturation
				&& item1.Luminance == item2.Luminance
				&& item1.Alpha == item2.Alpha
				);
		}

		public static bool operator !=(HSL item1, HSL item2)
		{
			return (
				item1.Hue != item2.Hue
				|| item1.Saturation != item2.Saturation
				|| item1.Luminance != item2.Luminance
				|| item1.Alpha != item2.Alpha
				);
		}

		#endregion

		#region Accessors
		/// <summary>
		/// Gets or sets the hue component.
		/// </summary>
		[Description("Hue component"),]
		public double Hue
		{
			get
			{
				return _hue;
			}
			set
			{
				_hue = (value > 360) ? 360 : ((value < 0) ? 0 : value);
			}
		}

		/// <summary>
		/// Gets or sets saturation component.
		/// </summary>
		[Description("Saturation component"),]
		public double Saturation
		{
			get
			{
				return _saturation;
			}
			set
			{
				_saturation = (value > 1) ? 1 : ((value < 0) ? 0 : value);
			}
		}

		/// <summary>
		/// Gets or sets the luminance component.
		/// </summary>
		[Description("Luminance component"),]
		public double Luminance
		{
			get
			{
				return _luminance;
			}
			set
			{
				_luminance = (value > 1) ? 1 : ((value < 0) ? 0 : value);
			}
		}

		public double Alpha
		{
			get { return _alpha; }
			set { _alpha = (value > 1) ? 1 : value < 0 ? 0 : value; }
		}

		#endregion

		/// <summary>
		/// 
		/// </summary>
		/// <param name="h">0...360</param>
		/// <param name="s">0...1</param>
		/// <param name="l">0...1</param>
		/// <param name="alpha">0...1</param>
		public HSL(double h, double s, double l, double alpha)
		{
			this.Hue = h;
			this.Saturation = s;
			this.Luminance = l;
			this.Alpha = alpha;
		}

		#region Methods
		public override bool Equals(Object obj)
		{
			if (obj == null || GetType() != obj.GetType()) return false;

			return (this == (HSL)obj);
		}

		public override int GetHashCode()
		{
			return Hue.GetHashCode() ^ Saturation.GetHashCode() ^ Luminance.GetHashCode();
		}

		#endregion

		private static double ParseDouble(string str)
		{
			return double.Parse(str, Calysto.Globalization.CalystoCultureInfoHelper.USCulture);
		}

		public static HSL Parse(string colorStr)
		{
			if (colorStr.IndexOf("hsl") == 0)
			{
				var arr = Regex.Matches(colorStr, "[\\d\\.\\%]+").Cast<Match>().Select(o => o.Value).ToArray();
				double alpha = 1;
				if (arr.Length > 3)
				{
					alpha = ParseDouble(arr[3]);
				}
				double s = ParseDouble(arr[1].Replace("%", "")) / 100.0;
				double l = ParseDouble(arr[1].Replace("%", "")) / 100.0;

				return new HSL(int.Parse(arr[0]), s, l, alpha);
			}
			else
			{
				return RGB.Parse(colorStr).ToHSL();
			}
		}

		public RGB ToRGB()
		{
			var hsla = this;
			var h = hsla.Hue / 360.0;
			var s = hsla.Saturation;
			var v = hsla.Luminance;
			var a = hsla.Alpha;

			if (s == 0)
			{
				return new RGB((int)(v * 255.0), (int)(v * 255.0), (int)(v * 255.0), a);
			}
			else
			{
				var var_h = h * 6.0;
				var var_i = Math.Floor(var_h);
				var var_1 = v * (1.0 - s);
				var var_2 = v * (1.0 - s * (var_h - var_i));
				var var_3 = v * (1.0 - s * (1.0 - (var_h - var_i)));
				double var_r, var_g, var_b;

				if (var_i == 0) { var_r = v; var_g = var_3; var_b = var_1; }
				else if (var_i == 1) { var_r = var_2; var_g = v; var_b = var_1; }
				else if (var_i == 2) { var_r = var_1; var_g = v; var_b = var_3; }
				else if (var_i == 3) { var_r = var_1; var_g = var_2; var_b = v; }
				else if (var_i == 4) { var_r = var_3; var_g = var_1; var_b = v; }
				else { var_r = v; var_g = var_1; var_b = var_2; };

				return new RGB((int)(var_r * 255.0), (int)(var_g * 255.0), (int)(var_b * 255.0), a);
			}
		}

		public string ToHslString()
		{
			bool hasAlpha = this.Alpha != 1;
			var str = "hsl";
			if (hasAlpha) str += "a";
			str += "(" + Math.Round(this.Hue).ToString(Calysto.Globalization.CalystoCultureInfoHelper.USCulture)
				+ "," + Math.Round(this.Saturation * 100).ToString(Calysto.Globalization.CalystoCultureInfoHelper.USCulture) 
				+ "%," + Math.Round(this.Luminance * 100).ToString(Calysto.Globalization.CalystoCultureInfoHelper.USCulture) + "%";
			if (hasAlpha) str += "," + this.Alpha.ToString(Calysto.Globalization.CalystoCultureInfoHelper.USCulture);
			str += ")";
			return str;
		}

		public override string ToString()
		{
			return ToHslString();
		}


	}
}
