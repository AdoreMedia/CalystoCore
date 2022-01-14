namespace Calysto.Web.TestSite.Web.CalystoUI.Notifications
{
	let _autoHide = 5000;

	export function ShowNotification1()
	{
		Calysto.Notification.Create("this is my text", "none", _autoHide).Show();
	}

	export function ShowNotification2()
	{
		Calysto.Notification.Create("this is my text", "error", _autoHide, "bottom", "left").Show();
	}

	export function ShowNotification3()
	{
		Calysto.Notification.Create("this is my text", "info", _autoHide, "bottom", "center").Show();
	}

	export function ShowNotification4()
	{
		Calysto.Notification.Create("this is my text", "question", _autoHide, "bottom", "right").Show();
	}

	export function ShowNotification5()
	{
		Calysto.Notification.Create("this is my text", "success", _autoHide, "top", "left").Show();
	}

	export function ShowNotification6()
	{
		Calysto.Notification.Create("this is my text", "warning", _autoHide, "top", "center").Show();
	}

	export function ShowNotification7()
	{
		Calysto.Notification.Create("this is my text", "error", _autoHide, "top", "right").Show();
	}
}

const Notifications = Calysto.Web.TestSite.Web.CalystoUI.Notifications;
