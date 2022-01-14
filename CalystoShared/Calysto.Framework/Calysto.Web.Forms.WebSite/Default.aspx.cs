using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Calysto.Web.Forms.WebSite
{
	public partial class _Default : Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			Response.Redirect("/CalystoWebControlsTests/Default.aspx");

		}
	}
}