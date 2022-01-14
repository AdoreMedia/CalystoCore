namespace Calysto.Web.TestSite.Web.CalystoUI.Common
{
	Calysto.Page.Preloader.Enable(300);

	Calysto.Page.OnUnhandledException((msg) =>
	{
		//Calysto.Dialog.CreateError(msg, "Inside OnUnhandledException").Show();
	}).OnVersionExpired(() =>
	{
		Calysto.Dialog.ShowVersionExpired();
	});

}
