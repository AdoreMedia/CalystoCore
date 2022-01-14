using System.Drawing;

namespace Calysto.Colorspace
{
	public static class ColorExtensions
	{
		public static RGB ToRGB(this Color color)
		{
			return new RGB(color.R, color.G, color.B, (double)color.A / (double)255);
		}

		public static Color FromHtml(string htmlColor)
		{
			return System.Drawing.ColorTranslator.FromHtml(htmlColor);
		}

		public static string ToRgbString(this Color color)
		{
			return color.ToRGB().ToRgbString();
		}

	}
}
