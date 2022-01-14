namespace Calysto.Web.TestSite.Web.CalystoUI.Flexbox.FlexboxController
{
	// mark js file as EmbeddedResource for ScriptManager to load it in Release build
	// include js file using ScriptManager for Relese build
	// include js file on page with script tag for debugging

	// add your code here

	function fnGoHome()
	{
		console.log("Invoked fnGoHome");
	}

	let fnLambda = function ()
	{
		console.log("fnLambda");
	};

	Calysto.Core.ExportGlobal(fnGoHome);
	//Calysto.Core.ExportGlobal(fnLambda); // ovo ne radi na IE-u 11 i starijima

	export function LoadDynamicContent(id, url)
	{
		new Calysto.Net.WebClient(url)
			.OnLoad((sender, ev) =>
			{
				let txt = sender.GetResponseText();
				let h1 = Calysto.DomQuery.FromHtml(txt);
				$$calysto("#" + id).ParentNodes().ReplaceWith(h1);
			}).Start();
	}

}

import FlexboxControllerWeb = Calysto.Web.TestSite.Web.CalystoUI.Flexbox.FlexboxController;

