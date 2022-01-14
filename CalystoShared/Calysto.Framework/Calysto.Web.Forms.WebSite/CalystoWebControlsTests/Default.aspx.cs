using Calysto.TypeLite;
using Calysto.Web.Script.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Calysto.Web.Forms.WebSite.CalystoWebControlsTests
{
	[TsClass]
	public partial class Default : System.Web.UI.Page
	{
		public class MenuItem
		{
			public string Name;
			public string Href;
		}

		protected List<MenuItem> MenuItems = new List<MenuItem>();

		protected void Page_Load(object sender, EventArgs e)
		{
			string dir1 = Path.GetDirectoryName(Request.PhysicalPath);
			this.MenuItems = Directory.EnumerateFiles(dir1, "*", SearchOption.AllDirectories)
				.Where(o => o.EndsWith(".aspx") || o.EndsWith(".ashx"))
				.Select(o=>o.Replace("\\", "/"))
				.Select(o => o.Substring(o.IndexOf(this.TemplateSourceDirectory)))
				.Select(o => new MenuItem()
				{
					Name = o,
					Href = o
				}).ToList();
		}

		[CalystoWebMethod]
		public string HelloWorld(string name)
		{
			return "Hello " + name;
		}
	}
}