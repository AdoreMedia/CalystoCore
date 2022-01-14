using Calysto.Colorspace;
using Calysto.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace Calysto.Web.UI
{
	public class CalystoAjaxPreloaders
	{
		public CalystoAjaxPreloaders()
		{
		}

		class ValueItem<TItem>
		{
			TItem _value;
			public ValueItem(TItem value) => _value = value;
			public TItem GetValue() => _value;
		}

		class EnumeratorHelper<TItem>
		{
			IEnumerator<TItem> _enumerator;
			public EnumeratorHelper(IEnumerable<TItem> items) => _enumerator = items.GetEnumerator();

			public ValueItem<TItem> GetNext()
			{
				if (_enumerator.MoveNext())
					return new ValueItem<TItem>(_enumerator.Current);
				else
					return default;
			}
		}

		private EnumeratorHelper<TItem> CreateHelper<TItem>(IEnumerable<TItem> items) => new EnumeratorHelper<TItem>(items);

		public virtual string Snake(string color = "black", bool rotateCCV = false)
		{
			string values = "0 0 0; 45 0 0; 90 0 0; 135 0 0; 180 0 0; 225 0 0 ; 270 0 0; 315 0 0; 360 0 0";
			string[] rArr = new double[] { 5.375, 6.438, 8.063, 10.063, 10.75, 12.531, 14.344, 16 }
				.Select(o => o.ToString(Calysto.Globalization.CalystoCultureInfoHelper.USCulture))
				.ToArray();

			var en1 = CreateHelper(rArr);

			if (rotateCCV)
			{
				values = values.Split(';').AsEnumerable().Reverse().ToStringJoined(";");
				en1 = CreateHelper(rArr.Reverse());
			}

			return $@"<svg class=""snake-main"" xmlns=""http://www.w3.org/2000/svg"" viewBox=""0 0 128 128"" x=""384"" y=""0"">
				<circle cx = ""16"" cy=""64"" r=""{en1.GetNext().GetValue()}"" fill=""{color}"" />
				<circle cx = ""16"" cy=""64"" r=""{en1.GetNext().GetValue()}"" fill=""{color}"" transform=""rotate(45 64 64)"" />
				<circle cx = ""16"" cy=""64"" r=""{en1.GetNext().GetValue()}"" fill=""{color}"" transform=""rotate(90 64 64)"" />
				<circle cx = ""16"" cy=""64"" r=""{en1.GetNext().GetValue()}"" fill=""{color}"" transform=""rotate(135 64 64)"" />
				<circle cx = ""16"" cy=""64"" r=""{en1.GetNext().GetValue()}"" fill=""{color}"" transform=""rotate(180 64 64)"" />
				<circle cx = ""16"" cy=""64"" r=""{en1.GetNext().GetValue()}"" fill=""{color}"" transform=""rotate(225 64 64)"" />
				<circle cx = ""16"" cy=""64"" r=""{en1.GetNext().GetValue()}"" fill=""{color}"" transform=""rotate(270 64 64)"" />
				<circle cx = ""16"" cy=""64"" r=""{en1.GetNext().GetValue()}"" fill=""{color}"" transform=""rotate(315 64 64)"" />
				<animateTransform attributeName = ""transform"" type=""rotate"" calcMode=""discrete"" values=""{values}"" keyTimes=""0;0.125;0.25;0.375;0.5;0.625;0.75;0.875;1"" dur=""1s"" begin=""0s"" repeatCount=""indefinite""></animateTransform>
			</svg>";
		}

		public virtual string SnakeBlue(string color = "#2375b4", bool rotateCCV = false)
		{
			return this.Snake(color, rotateCCV);
		}

		private Color ApplyAlpha(double alpha, Color color) => Color.FromArgb((int)alpha, color);

		public virtual string BallsRing(string color = "black", bool rotateCCV = false)
		{
			string values = "0 0 0; 45 0 0; 90 0 0; 135 0 0; 180 0 0; 225 0 0 ; 270 0 0; 315 0 0; 360 0 0";
			double[] aArr = new double[] { 0.1, 0.2, 0.35, 0.5, 0.7, 0.8, 0.9 }.Select(o => o * 255.0).ToArray();
			var en1 = CreateHelper(aArr);

			if (rotateCCV)
			{
				values = values.Split(';').AsEnumerable().Reverse().ToStringJoined(";");
				en1 = CreateHelper(aArr.Reverse());
			}

			var main1 = Calysto.Colorspace.ColorExtensions.FromHtml(color);
			return $@"<svg xmlns=""http://www.w3.org/2000/svg"" viewBox=""0 0 128 128"" x=""448"" y=""0"">
					<circle cx=""16"" cy=""64"" r=""16"" fill=""{main1.ToRgbString()}"" />
					<circle cx=""16"" cy=""64"" r=""16"" fill=""{ApplyAlpha(en1.GetNext().GetValue(), main1).ToRgbString()}"" transform=""rotate(45, 64, 64)"" />
					<circle cx=""16"" cy=""64"" r=""16"" fill=""{ApplyAlpha(en1.GetNext().GetValue(), main1).ToRgbString()}"" transform=""rotate(90,64,64)"" />
					<circle cx=""16"" cy=""64"" r=""16"" fill=""{ApplyAlpha(en1.GetNext().GetValue(), main1).ToRgbString()}"" transform=""rotate(135,64,64)"" />
					<circle cx=""16"" cy=""64"" r=""16"" fill=""{ApplyAlpha(en1.GetNext().GetValue(), main1).ToRgbString()}"" transform=""rotate(180,64,64)"" />
					<circle cx=""16"" cy=""64"" r=""16"" fill=""{ApplyAlpha(en1.GetNext().GetValue(), main1).ToRgbString()}"" transform=""rotate(225,64,64)"" />
					<circle cx=""16"" cy=""64"" r=""16"" fill=""{ApplyAlpha(en1.GetNext().GetValue(), main1).ToRgbString()}"" transform=""rotate(270,64,64)"" />
					<circle cx=""16"" cy=""64"" r=""16"" fill=""{ApplyAlpha(en1.GetNext().GetValue(), main1).ToRgbString()}"" transform=""rotate(315,64,64)"" />
					<animateTransform attributeName=""transform"" type=""rotate"" calcMode=""discrete"" values=""{values}"" keyTimes=""0;0.125;0.25;0.375;0.5;0.625;0.75;0.875;1"" dur=""1s"" begin=""0s"" repeatCount=""indefinite""></animateTransform>
				</svg>";
		}

		public virtual string MsRing(string color = "black", string backColor = "gainsboro", bool rotateCCV = false)
		{
			string values = "0 64 64; 45 64 64; 90 64 64; 135 64 64; 180 64 64; 225 64 64; 270 64 64; 315 64 64; 360 64 64";
			if (rotateCCV)
				values = values.Split(';').AsEnumerable().Reverse().ToStringJoined(";");

			return $@"<svg xmlns=""http://www.w3.org/2000/svg"" viewBox=""0 0 128 128"" x=""576"" y=""0"">
				<path d=""M38.52 33.37L21.36 16.2A63.6 63.6 0 0 1 59.5.16v24.3a39.5 39.5 0 0 0-20.98 8.92z"" fill=""{backColor}"" />
				<path d=""M38.52 33.37L21.36 16.2A63.6 63.6 0 0 1 59.5.16v24.3a39.5 39.5 0 0 0-20.98 8.92z"" fill=""{backColor}"" transform=""rotate(45 64 64)"" />
				<path d=""M38.52 33.37L21.36 16.2A63.6 63.6 0 0 1 59.5.16v24.3a39.5 39.5 0 0 0-20.98 8.92z"" fill=""{backColor}"" transform=""rotate(90 64 64)"" />
				<path d=""M38.52 33.37L21.36 16.2A63.6 63.6 0 0 1 59.5.16v24.3a39.5 39.5 0 0 0-20.98 8.92z"" fill=""{backColor}"" transform=""rotate(135 64 64)"" />
				<path d=""M38.52 33.37L21.36 16.2A63.6 63.6 0 0 1 59.5.16v24.3a39.5 39.5 0 0 0-20.98 8.92z"" fill=""{backColor}"" transform=""rotate(180 64 64)"" />
				<path d=""M38.52 33.37L21.36 16.2A63.6 63.6 0 0 1 59.5.16v24.3a39.5 39.5 0 0 0-20.98 8.92z"" fill=""{backColor}"" transform=""rotate(225 64 64)"" />
				<path d=""M38.52 33.37L21.36 16.2A63.6 63.6 0 0 1 59.5.16v24.3a39.5 39.5 0 0 0-20.98 8.92z"" fill=""{backColor}"" transform=""rotate(270 64 64)"" />
				<path d=""M38.52 33.37L21.36 16.2A63.6 63.6 0 0 1 59.5.16v24.3a39.5 39.5 0 0 0-20.98 8.92z"" fill=""{backColor}"" transform=""rotate(315 64 64)"" />
				<path d=""M38.52 33.37L21.36 16.2A63.6 63.6 0 0 1 59.5.16v24.3a39.5 39.5 0 0 0-20.98 8.92z"" fill=""{color}"">
					<animateTransform attributeName=""transform"" type=""rotate"" calcMode=""discrete"" values=""{values}"" keyTimes=""0;0.125;0.25;0.375;0.5;0.625;0.75;0.875;1"" dur=""1s"" begin=""0s"" repeatCount=""indefinite""></animateTransform>
				</path>
			</svg>";
		}

		public virtual string TwoArrows(string color = "black")
		{
			return $@"<svg xmlns=""http://www.w3.org/2000/svg"" viewBox=""10 10 108 108"" x=""704"" y=""0"">
				<path fill=""{color}"" d=""M109.25 55.5h-36l12-12a29.54 29.54 0 0 0-49.53 12H18.75A46.04 46.04 0 0 1 96.9 31.84l12.35-12.34v36zm-90.5 17h36l-12 12a29.54 29.54 0 0 0 49.53-12h16.97A46.04 46.04 0 0 1 31.1 96.16L18.74 108.5v-36z"">
				</path>
				<animateTransform attributeName=""transform"" type=""rotate"" calcMode=""linear"" values=""0 0 0;360 0 0"" keyTimes=""0;1"" dur=""1s"" begin=""0s"" repeatCount=""indefinite""></animateTransform>
			</svg>";
		}

		public virtual string Flower(string color = "black", bool rotateCCV = false)
		{
			var main1 = Calysto.Colorspace.ColorExtensions.FromHtml(color);
			double[] aArr = new[] { 0.1, 0.1, 0.1, 0.1, 0.2, 0.3, 0.4, 0.5, 0.6, 0.7, 0.8, 0.9 }.Select(o => o * 255.0).ToArray();
			string values = "0 0 0;30 0 0;60 0 0;90 0 0;120 0 0;150 0 0;180 0 0;210 0 0;240 0 0;270 0 0;300 0 0;330 0 0;360 0 0";
			var en1 = CreateHelper(aArr);

			if (rotateCCV)
			{
				values = values.Split(';').AsEnumerable().Reverse().ToStringJoined(";");
				en1 = CreateHelper(aArr.Reverse());
			}

			return $@"<svg xmlns=""http://www.w3.org/2000/svg"" viewBox=""0 0 128 128"" x=""640"" y=""0"">
				<path d=""M59.6 0h8v40h-8V0z"" fill=""{main1.ToRgbString()}"" />
				<path d=""M59.6 0h8v40h-8V0z"" fill=""{ApplyAlpha(en1.GetNext().GetValue(), main1).ToRgbString()}"" transform=""rotate(30 64 64)"" />
				<path d=""M59.6 0h8v40h-8V0z"" fill=""{ApplyAlpha(en1.GetNext().GetValue(), main1).ToRgbString()}"" transform=""rotate(60 64 64)"" />
				<path d=""M59.6 0h8v40h-8V0z"" fill=""{ApplyAlpha(en1.GetNext().GetValue(), main1).ToRgbString()}"" transform=""rotate(90 64 64)"" />
				<path d=""M59.6 0h8v40h-8V0z"" fill=""{ApplyAlpha(en1.GetNext().GetValue(), main1).ToRgbString()}"" transform=""rotate(120 64 64)"" />
				<path d=""M59.6 0h8v40h-8V0z"" fill=""{ApplyAlpha(en1.GetNext().GetValue(), main1).ToRgbString()}"" transform=""rotate(150 64 64)"" />
				<path d=""M59.6 0h8v40h-8V0z"" fill=""{ApplyAlpha(en1.GetNext().GetValue(), main1).ToRgbString()}"" transform=""rotate(180 64 64)"" />
				<path d=""M59.6 0h8v40h-8V0z"" fill=""{ApplyAlpha(en1.GetNext().GetValue(), main1).ToRgbString()}"" transform=""rotate(210 64 64)"" />
				<path d=""M59.6 0h8v40h-8V0z"" fill=""{ApplyAlpha(en1.GetNext().GetValue(), main1).ToRgbString()}"" transform=""rotate(240 64 64)"" />
				<path d=""M59.6 0h8v40h-8V0z"" fill=""{ApplyAlpha(en1.GetNext().GetValue(), main1).ToRgbString()}"" transform=""rotate(270 64 64)"" />
				<path d=""M59.6 0h8v40h-8V0z"" fill=""{ApplyAlpha(en1.GetNext().GetValue(), main1).ToRgbString()}"" transform=""rotate(300 64 64)"" />
				<path d=""M59.6 0h8v40h-8V0z"" fill=""{ApplyAlpha(en1.GetNext().GetValue(), main1).ToRgbString()}"" transform=""rotate(330 64 64)"" />
				<animateTransform attributeName=""transform"" type=""rotate"" calcMode=""discrete"" values=""{values}"" keyTimes=""0;0.08;0.16;0.25;0.33;0.42;0.5;0.58;0.67;0.75;0.83;0.92;1"" dur=""1s"" begin=""0s"" repeatCount=""indefinite""></animateTransform>
			</svg>";
		}

		public virtual string ThreeArcs(string color = "black", bool rotateCCV = false)
		{
			return $@"<svg xmlns=""http://www.w3.org/2000/svg"" viewBox=""0 0 100 100"" preserveAspectRatio=""xMidYMid"" class=""lds-dual-ring"">
				<circle cx=""50"" cy=""50"" fill=""none"" stroke-linecap=""round"" r=""40"" stroke-width=""15"" stroke=""{color}"" stroke-dasharray=""42.411500823462205 42.411500823462205"" transform=""rotate(60 50 50)"">
					<animateTransform attributeName=""transform"" type=""rotate"" calcMode=""linear"" values=""{(rotateCCV ? 360 : 0)} 50 50;{(rotateCCV ? 0 : 360)} 50 50"" keyTimes=""0;1"" dur=""1s"" begin=""0s"" repeatCount=""indefinite""></animateTransform>
				</circle>
			</svg>";
		}

		public virtual string Oval(string color = "black", string backColor = "gainsboro", bool rotateCCV = false)
		{
			int strokeWidth = 4;
			int pathStart = 34;
			int radius = 18 - strokeWidth / 2;

			switch (strokeWidth)
			{
				case 2: pathStart = 36; break;
				case 4: pathStart = 34; break;
				case 8: pathStart = 32; break;
			}

			return $@"<svg viewBox=""0 0 38 38"" xmlns=""http://www.w3.org/2000/svg"" stroke=""{color}"">
    <g fill=""none"" fill-rule=""evenodd"">
        <g transform=""translate(1 1)"" stroke-width=""2"">
            <circle stroke-width=""{strokeWidth}"" stroke=""{backColor}"" stroke-opacity=""1"" cx=""18"" cy=""18"" r=""{radius}""/>
            <path stroke-width=""{strokeWidth}"" d=""M{pathStart} 18c0-9.94-8.06-{radius}-{radius}-{radius}"">
                <animateTransform
                    attributeName=""transform""
                    type=""rotate""
                    from=""{(rotateCCV ? 360 : 0)} 18 18""
                    to=""{(rotateCCV ? 0 : 360)} 18 18""
                    dur=""1s""
                    repeatCount=""indefinite""/>
            </path>
        </g>
    </g>
</svg>";
		}

		public virtual string Bars(string color = "black")
		{
			return $@"<svg viewBox=""0 0 135 140"" xmlns=""http://www.w3.org/2000/svg"" fill=""{color}"">
    <rect y=""10"" width=""15"" height=""120"" rx=""6"">
        <animate attributeName=""height""
             begin=""0.5s"" dur=""1s""
             values=""120;110;100;90;80;70;60;50;40;140;120"" calcMode=""linear""
             repeatCount=""indefinite"" />
        <animate attributeName=""y""
             begin=""0.5s"" dur=""1s""
             values=""10;15;20;25;30;35;40;45;50;0;10"" calcMode=""linear""
             repeatCount=""indefinite"" />
    </rect>
    <rect x=""30"" y=""10"" width=""15"" height=""120"" rx=""6"">
        <animate attributeName=""height""
             begin=""0.25s"" dur=""1s""
             values=""120;110;100;90;80;70;60;50;40;140;120"" calcMode=""linear""
             repeatCount=""indefinite"" />
        <animate attributeName=""y""
             begin=""0.25s"" dur=""1s""
             values=""10;15;20;25;30;35;40;45;50;0;10"" calcMode=""linear""
             repeatCount=""indefinite"" />
    </rect>
    <rect x=""60"" width=""15"" height=""140"" rx=""6"">
        <animate attributeName=""height""
             begin=""0s"" dur=""1s""
             values=""120;110;100;90;80;70;60;50;40;140;120"" calcMode=""linear""
             repeatCount=""indefinite"" />
        <animate attributeName=""y""
             begin=""0s"" dur=""1s""
             values=""10;15;20;25;30;35;40;45;50;0;10"" calcMode=""linear""
             repeatCount=""indefinite"" />
    </rect>
    <rect x=""90"" y=""10"" width=""15"" height=""120"" rx=""6"">
        <animate attributeName=""height""
             begin=""0.25s"" dur=""1s""
             values=""120;110;100;90;80;70;60;50;40;140;120"" calcMode=""linear""
             repeatCount=""indefinite"" />
        <animate attributeName=""y""
             begin=""0.25s"" dur=""1s""
             values=""10;15;20;25;30;35;40;45;50;0;10"" calcMode=""linear""
             repeatCount=""indefinite"" />
    </rect>
    <rect x=""120"" y=""10"" width=""15"" height=""120"" rx=""6"">
        <animate attributeName=""height""
             begin=""0.5s"" dur=""1s""
             values=""120;110;100;90;80;70;60;50;40;140;120"" calcMode=""linear""
             repeatCount=""indefinite"" />
        <animate attributeName=""y""
             begin=""0.5s"" dur=""1s""
             values=""10;15;20;25;30;35;40;45;50;0;10"" calcMode=""linear""
             repeatCount=""indefinite"" />
    </rect>
</svg>";
		}

		public virtual string BallTriangle(string color = "black")
		{
			return $@"<svg viewBox=""0 0 57 57"" xmlns=""http://www.w3.org/2000/svg"" stroke=""{color}"">
    <g fill=""none"" fill-rule=""evenodd"">
        <g transform=""translate(1 1)"" stroke-width=""2"">
            <circle cx=""5"" cy=""50"" r=""5"">
                <animate attributeName=""cy""
                     begin=""0s"" dur=""2.2s""
                     values=""50;5;50;50""
                     calcMode=""linear""
                     repeatCount=""indefinite"" />
                <animate attributeName=""cx""
                     begin=""0s"" dur=""2.2s""
                     values=""5;27;49;5""
                     calcMode=""linear""
                     repeatCount=""indefinite"" />
            </circle>
            <circle cx=""27"" cy=""5"" r=""5"">
                <animate attributeName=""cy""
                     begin=""0s"" dur=""2.2s""
                     from=""5"" to=""5""
                     values=""5;50;50;5""
                     calcMode=""linear""
                     repeatCount=""indefinite"" />
                <animate attributeName=""cx""
                     begin=""0s"" dur=""2.2s""
                     from=""27"" to=""27""
                     values=""27;49;5;27""
                     calcMode=""linear""
                     repeatCount=""indefinite"" />
            </circle>
            <circle cx=""49"" cy=""50"" r=""5"">
                <animate attributeName=""cy""
                     begin=""0s"" dur=""2.2s""
                     values=""50;50;5;50""
                     calcMode=""linear""
                     repeatCount=""indefinite"" />
                <animate attributeName=""cx""
                     from=""49"" to=""49""
                     begin=""0s"" dur=""2.2s""
                     values=""49;5;27;49""
                     calcMode=""linear""
                     repeatCount=""indefinite"" />
            </circle>
        </g>
    </g>
</svg>";
		}
	}
}
