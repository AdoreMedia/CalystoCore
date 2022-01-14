namespace Calysto.Web.UI.Css
{
	public class CalystoCssTest
	{
		private CalystoCssClass ClassicButton(int width, int height)
		{
			return new CalystoCssClass().ApplyValue("width", width + "px").ApplyValue("height", height + "px");
		}

		public void RenderCss()
		{
			CalystoStyleSheet sheet = new CalystoStyleSheet().AddCss(@"@font-face 
{ 
	font-family:'SwanOne'; 
	src:url('fonts/swan_one_icon.eot'); 
	src:url('fonts/swan_one_icon.eot?#iefix') format('embedded-opentype'),url('fonts/swan_one_icon.woff') format('woff'),url('fonts/swan_one_icon.ttf') format('truetype'),url('fonts/swan_one_icon.svg#SwanOne') format('svg'); 
	font-weight:normal; 
	font-style:normal; 
}");

			CalystoCssClass template1 = new CalystoCssClass()
				.AddToStyleSheet(sheet)
				.ApplyStyle(@"
border:solid 1px red;
color:red;
border-bottom:1px solid blue;	
");

			CalystoCssClass template2 = new CalystoCssClass(".name div, #first .moj.nesto")
				.AddToStyleSheet(sheet)
				.ApplyStyle(@"
width:500px;
height:100px;
");
			new CalystoPlainCssText("/*ovo je moj komentar*/").AddToStyleSheet(sheet);

			CalystoCssClass template3 = new CalystoCssClass("#test1")
				.AddToStyleSheet(sheet)
				.ApplyClass(template1)
				.Transition()
				.Opacity(50)
				.Background("red", "/any.gif", "no-repeat", "center", "center")
				.ApplyClass(template2)
				.ApplyStyle(@"
background-color:red;
border-bottom:none;
")
				.ApplyClass(ClassicButton(10, 10));

			template3 = template3.ApplyValue("border", "none");

			CalystoCssClass template4 = new CalystoCssClass("#first .moj.nesto")
			.AddToStyleSheet(sheet)
			.ApplyStyle(@"
	width:350px;
");

			template4.Transition();

			////CalystoMediaRule rule = new CalystoMediaRule("screen and (width-max:900px)").Add(template3, template4.ApplyClass(template1))
			////	.AddToStyleSheet(sheet)
			////	.Add(new CalystoPlainCssText("/*drugi komentar*/"));

			////Color borderColor = ColorExtensions.FromHtml("#affaab");
			////Color backColor = borderColor.ChangeLightnesPercent(-50).ChangeSaturationPercent(-50);

			////template4.ApplyValue("color1", borderColor.ToHtml());
			////template4.ApplyValue("color2", backColor.ToHtml());

			////new CalystoMediaScreenRule(p=>p.Width > 100 && p.Width <= 500 && p.Height > 100).AddToStyleSheet(sheet)
			////	.Add(new CalystoPlainCssText("/*ovo je unutra*/"));

			////sheet.NewMediaScreenRule(s => s.Width > 100 && s.Width < 1000, m=>m.NewCssClass(".fadsg", c=>c.ApplyStyle("dime:234px")));

			sheet.NewCssClass(".cls11    #two three .one, #my .new  div", ".fads5g, .fadsg", c => c.ApplyStyle("key1:value1"));
			sheet.NewCssClass(".cls11", c => c.ApplyStyle("req-prosje:2343252zcmd"));



			////File.WriteAllText("d:\\tt.css", sheet.ToCssString());


		}

	}
}
