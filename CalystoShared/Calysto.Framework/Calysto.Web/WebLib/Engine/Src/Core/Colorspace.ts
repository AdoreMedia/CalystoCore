namespace Calysto.Colorspace
{
	export var NamedColors = {
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
	};

	export namespace ColorConverter
	{
		export function ParseToRGB(colorStr: string): RGB
		{
			/// <summary>
			/// Detect format and parse to RGBA. Returns RGB color object. Parse from hex, rgb or hsv: #rgb, #rrggbb, rgb(R, G, B), rgb(R, G, B, opacity), hsv(H, S, V).
			/// Returns RGB always.
			/// </summary>
			/// <param name="colorStr"></param>

			var hex;

			if (colorStr && (hex = NamedColors[colorStr]) && hex.indexOf("#") == 0)
			{
				// named color is converted to #hex value, parse from hex:
				return ColorConverter.ParseToRGB(hex);
			}
			else if (colorStr.indexOf("rgb") == 0)
			{
				var arr: string[] = <any>colorStr.match(new RegExp("[\\d\\.]+", "ig"));
				return new RGB(arr[0], arr[1], arr[2], arr[3]);
			}
			else if (colorStr.indexOf("hsl") == 0)
			{
				var arr: string[] = <any>colorStr.match(new RegExp("[\\d\\.\\%]+", "ig"));
				return new HSL(arr[0], arr[1], arr[2], arr[3]).ToRGB();
			}
			else if (colorStr.indexOf("#") == 0)
			{
				var str = colorStr.substr(1);
				let h: any[] = <any>str.match(new RegExp('(.{' + str.length / 3 + '})', 'g'));
				for (var i = 0; i < h.length; i++)
				{
					h[i] = parseInt(h[i].length == 1 ? h[i] + h[i] : h[i], 16);
				}
				return new RGB(h[0], h[1], h[2], h[3]);
			}
			else
			{
				throw Error(colorStr + " can not be parsed to RGB color");
			}
		}
	}

	function toInt(str, def, min, max)
	{
		var n = parseFloat(str);
		if (isNaN(n) || !isFinite(n)) return def;
		if (typeof (str) == "string" && str.indexOf("%") > 0) n = n / 100; // HSL uses % for view, has to be converted to value
		if (n < min) return min;
		if (n > max) return max;
		return n;
	}

	function pad(val, len)
	{
		val = String(val);
		len = len || 2;
		while (val.length < len) val = "0" + val;
		return val;
	}

	export class HSL
	{
		/**int, 0...360*/
		public h: number;
		/**double, 0...1*/
		public s: number;
		/**double, 0...1*/
		public l: number;
		/**double, 0...1*/
		public a: number;


		constructor(hue, saturation, luminance, alpha)
		{
			/// <summary>
			/// 
			/// </summary>
			/// <param name="hue" type="int">0...360</param>
			/// <param name="saturation" type="double">0...1</param>
			/// <param name="luminance" type="double">0...1</param>
			/// <param name="alpha" type="double">0...1</param>
			this.h = (parseInt(hue) || 0) % 360;
			this.s = toInt(saturation, 1, 0, 1);
			this.l = toInt(luminance, 0.5, 0, 1);
			this.a = toInt(alpha, 1, 0, 1);
		}

		public static Parse(colorStr)
		{
			/// <summary>
			/// parse hex #rgb or #rrggbb or rgb(....)
			/// </summary>
			/// <param name="hexString"></param>
			if (colorStr.indexOf("hsl") == 0)
			{
				// hsla(350,120%,50%,0.5) // % has to be converted to value: x/100
				var arr = colorStr.match(new RegExp("[\\d\\.\\%]+", "ig"));
				return new HSL(arr[0], arr[1], arr[2], arr[3]);
			}
			else
			{
				// hex, rgb, named color
				var rgba = ColorConverter.ParseToRGB(colorStr);
				return rgba.ToHSL();
			}
		}

		public Clone()
		{
			return new HSL(this.h, this.s, this.l, this.a);
		}

		public Set(fn: (rgb: HSL) => void)
		{
			fn(this);
			return this;
		}

		// eg. hsla(130.4325324,47.5%,79%,0.443534001)
		// eg. hsl(130.4325324,47.5%,79%)
		ToHslString()
		{
			var hasAlpha = this.a != 1 && (this.a > 0 || this.a === 0);
			var str = "hsl";
			if (hasAlpha) str += "a";
			str += "(" + this.h + "," + (this.s * 100) + "%," + (this.l * 100) + "%";
			if (hasAlpha) str += "," + this.a;
			str += ")";
			return str;
		}

		public ToRGB()
		{
			var hsla = this;
			var h = hsla.h / 360;
			var s = hsla.s;
			var v = hsla.l;
			var a = hsla.a;

			if (s == 0)
			{
				return new RGB(v * 255, v * 255, v * 255, a);
			}
			else
			{
				var var_h = h * 6;
				var var_i = Math.floor(var_h);
				var var_1 = v * (1 - s);
				var var_2 = v * (1 - s * (var_h - var_i));
				var var_3 = v * (1 - s * (1 - (var_h - var_i)));
				var var_r, var_g, var_b;

				if (var_i == 0) { var_r = v; var_g = var_3; var_b = var_1 }
				else if (var_i == 1) { var_r = var_2; var_g = v; var_b = var_1 }
				else if (var_i == 2) { var_r = var_1; var_g = v; var_b = var_3 }
				else if (var_i == 3) { var_r = var_1; var_g = var_2; var_b = v }
				else if (var_i == 4) { var_r = var_3; var_g = var_1; var_b = v }
				else { var_r = v; var_g = var_1; var_b = var_2 };

				return new RGB(var_r * 255, var_g * 255, var_b * 255, a);
			}
		}
	}

	export class RGB
	{
		/**int, 0...255*/
		public r: number;
		/**int, 0...255*/
		public g: number;
		/**int, 0...255*/
		public b: number;
		/**decimal, 0...1*/
		public a: number;

		constructor(r, g, b, alpha)
		{
			this.r = Math.round(toInt(r, 255, 0, 255));
			this.g = Math.round(toInt(g, 255, 0, 255));
			this.b = Math.round(toInt(b, 255, 0, 255));
			this.a = toInt(alpha, 1, 0, 1);
		}

		public static Parse(colorStr)
		{
			/// <summary>
			/// parse hex #rgb or #rrggbb or rgb(....)
			/// </summary>
			/// <param name="colorStr"></param>
			if (colorStr.indexOf("rgb"))
			{
				var arr: string[] = <any>colorStr.match(new RegExp("[\\d\\.]+", "ig"));
				return new RGB(arr[0], arr[1], arr[2], arr[3]);
			}
			else
			{
				// hex, hsl, named color, cmyk
				return ColorConverter.ParseToRGB(colorStr);
			}
		}

		public Clone()
		{
			return new RGB(this.r, this.g, this.b, this.a);
		}

		public Set(fn : (rgb: RGB) => void)
		{
			fn(this);
			return this;
		}

		// eg. rgba(176, 227, 185, 0.443534001)
		// eg. rgb(176, 227, 185)
		public ToRgbString()
		{
			var hasAlpha = this.a != 1 && (this.a > 0 || this.a === 0);
			var str = "rgb";
			if (hasAlpha) str += "a";
			str += "(" + this.r + "," + this.g + "," + this.b;
			if (hasAlpha) str += "," + this.a;
			str += ")";
			return str;
		}

		public ToHexString()
		{
			return "#"
				+ pad(Number(Math.round(this.r || 0)).toString(16), 2)
				+ pad(Number(Math.round(this.g || 0)).toString(16), 2)
				+ pad(Number(Math.round(this.b || 0)).toString(16), 2);
		}

		public ToHSL()
		{
			var rgba = this;
			var result = { h: NaN, s: NaN, l: NaN, a: NaN };

			var r = rgba.r / 255;
			var g = rgba.g / 255;
			var b = rgba.b / 255;
			result.a = rgba.a;

			var minVal = Math.min(r, g, b);
			var maxVal = Math.max(r, g, b);
			var delta = maxVal - minVal;

			result.l = maxVal;

			if (delta == 0)
			{
				result.h = 0;
				result.s = 0;
			}
			else
			{
				result.s = delta / maxVal;
				var del_R = (((maxVal - r) / 6) + (delta / 2)) / delta;
				var del_G = (((maxVal - g) / 6) + (delta / 2)) / delta;
				var del_B = (((maxVal - b) / 6) + (delta / 2)) / delta;

				if (r == maxVal) { result.h = del_B - del_G; }
				else if (g == maxVal) { result.h = (1 / 3) + del_R - del_B; }
				else if (b == maxVal) { result.h = (2 / 3) + del_G - del_R; }

				if (result.h < 0) { result.h += 1; }
				if (result.h > 1) { result.h -= 1; }
			}

			// don't round it, to be more precize when adjusting values for web
			result.h = (result.h * 360);
			result.s = (result.s);
			result.l = (result.l);

			return new HSL(result.h, result.s, result.l, result.a);
		}

		public ToCMYK()
		{
			var RGB = this;
			var result = { k: NaN, c: NaN, m: NaN, y: NaN };

			var r = RGB.r / 255;
			var g = RGB.g / 255;
			var b = RGB.b / 255;

			result.k = Math.min(1 - r, 1 - g, 1 - b);
			result.c = (1 - r - result.k) / (1 - result.k);
			result.m = (1 - g - result.k) / (1 - result.k);
			result.y = (1 - b - result.k) / (1 - result.k);

			result.c = Math.round(result.c * 100);
			result.m = Math.round(result.m * 100);
			result.y = Math.round(result.y * 100);
			result.k = Math.round(result.k * 100);

			return new CMYK(result.c, result.m, result.y, result.k);
		}
	}

	export class CMYK
	{
		/**int, 0...100*/
		public c: number;
		/**int, 0...100*/
		public m: number;
		/**int, 0...100*/
		public y: number;
		/**int, 0...100*/
		public k: number;

		constructor(c, m, y, k)
		{
			/// <summary>
			/// ctor.
			/// </summary>
			/// <param name="c">0...100</param>
			/// <param name="m">0...100</param>
			/// <param name="y">0...100</param>
			/// <param name="k">0...100</param>
			this.c = toInt(c, 100, 0, 100);
			this.m = toInt(m, 100, 0, 100);
			this.y = toInt(y, 100, 0, 100);
			this.k = toInt(k, 100, 0, 100);
		}

		public ToRGB()
		{
			var CMYK = this;
			var result: { r: number, g: number, b: number, a: number } = <any>{};

			var c = CMYK.c / 100;
			var m = CMYK.m / 100;
			var y = CMYK.y / 100;
			var k = CMYK.k / 100;

			result.r = 1 - Math.min(1, c * (1 - k) + k);
			result.g = 1 - Math.min(1, m * (1 - k) + k);
			result.b = 1 - Math.min(1, y * (1 - k) + k);

			result.r = Math.round(result.r * 255);
			result.g = Math.round(result.g * 255);
			result.b = Math.round(result.b * 255);

			return new RGB(result.r, result.g, result.b, result.a);
		}
	}
}

