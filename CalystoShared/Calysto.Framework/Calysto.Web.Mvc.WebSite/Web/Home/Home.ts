namespace Calysto.Web.TestSite.Web.VS.Home.HomeController
{
	// mark js file as EmbeddedResource for ScriptManager to load it in Release build
	// include js file using ScriptManager for Relese build
	// include js file on page with script tag for debugging

	// add your code here

	Calysto.Page.OnInteractive(() =>
	{
		$$calysto<HTMLButtonElement>("button[test-func]").ForEach(o =>
		{
			let fname = <string>o.getAttribute("test-func");
			o.innerHTML = fname;
			o.onclick = () =>
			{
				let fn1 = <Calysto.Net.WebService.AjaxServiceClientWithReturn<string>>HomeController[fname](1);
				fn1.OnSuccess(resp => alert(resp));
			};
		});

		$$calysto("#btnCheckLoginModel").OnClick((sender, ev) =>
		{
			var dic = Calysto.Forms.FormSerialize<Models.LoginViewModel>("#form1");
			HomeController.CheckLoginModel(dic);
		})

	});
}
