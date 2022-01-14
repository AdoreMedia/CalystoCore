namespace Calysto.Web.TestSite.Web.CalystoUI.Preloaders.PreloadersController
{
	// mark js file as EmbeddedResource for ScriptManager to load it in Release build
	// include js file using ScriptManager for Relese build
	// include js file on page with script tag for debugging

	// add your code here

	function AppendItem(name: string, svg: string)
	{
		$$calysto(["#divContainer1", "#divContainer2", "#divContainer3"])
			.AddChildren(`
<div class="spinnerItem">
	<div class="spinnerLabel">${name}</div>
	<div class="svgContainer">${svg}</div>
</div>
`)
	}

	Calysto.Page.OnInteractive(() =>
	{
		for (let prop in Calysto.Preloaders)
		{
			let fn1 = Calysto.Preloaders[prop];
			if (typeof fn1 == "function")
			{
				AppendItem(prop, fn1());
			}
		}

	});

}
