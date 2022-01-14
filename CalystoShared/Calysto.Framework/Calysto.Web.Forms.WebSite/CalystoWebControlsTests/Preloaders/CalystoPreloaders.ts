namespace CalystoPreloaders
{
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