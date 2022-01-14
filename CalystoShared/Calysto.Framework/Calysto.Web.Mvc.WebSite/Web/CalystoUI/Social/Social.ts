namespace Calysto.Web.TestSite.Web.CalystoUI.Social.Unittests
{
	export function RunTests()
	{
		Calysto.TestTools.TestRunner.RunTests();
	}
}

import Unittests = Calysto.Web.TestSite.Web.CalystoUI.Social.Unittests;

namespace Calysto.Web.TestSite.Web.CalystoUI.Social.Facebook
{
	let _facebookAppId = "763422044109553"; // BlueStack

	export async function InitApp()
	{
		var tokenSource = new Calysto.Tasks.CancellationTokenSource(10000);
		let fb = Calysto.Page.Social.Facebook.FacebookProvider.GetProvider(_facebookAppId);
		//console.log(await fb.InitEngine());
		console.log(await fb.InitApp(tokenSource.Token));
		console.log(fb);
	}

	export async function Logout()
	{
		alert("not implemented");
	}

	export async function Login()
	{
		var tokenSource = new Calysto.Tasks.CancellationTokenSource(10000);
		let fb = Calysto.Page.Social.Facebook.FacebookProvider.GetProvider(_facebookAppId);
		console.log(await fb.Login());
		console.log(await fb.LoadPermissions(tokenSource.Token));
		console.log(await fb.LoadPicture(tokenSource.Token));
		console.log(await fb.LoadProfile(tokenSource.Token));
		console.log(fb);
	}

	export async function Status()
	{
		var tokenSource = new Calysto.Tasks.CancellationTokenSource(10000);
		let fb = Calysto.Page.Social.Facebook.FacebookProvider.GetProvider(_facebookAppId);
		//console.log(await fb.InitEngine());
		//console.log(await fb.InitApp());
		console.log(await fb.GetLoginStatus(tokenSource.Token));
		console.log(fb);
		console.log(await fb.IsFbAuthenticated());
		console.log(await fb.IsAuthenticated());
	}
}

import Facebook = Calysto.Web.TestSite.Web.CalystoUI.Social.Facebook;

namespace Calysto.Web.TestSite.Web.CalystoUI.Social.Google
{
	let _googleApiKey = "AIzaSyCRzDlVMG8_EHhIjwyqDApaLWKMBjRGrRM";
	let _googleClientId = "658661145263-qah8cdjjb5idbo2ovt90msr3nsr4kvh1.apps.googleusercontent.com";

	export async function InitApp()
	{
		var tokenSource = new Calysto.Tasks.CancellationTokenSource(10000);
		let gg = Calysto.Page.Social.Google.GoogleProvider.GetProvider(_googleApiKey, _googleClientId);
		//console.log(await gg.InitEngine());
		console.log(await gg.InitApp(tokenSource.Token));
		console.log(gg);
	}

	export async function Login()
	{
		try
		{
			var tokenSource = new Calysto.Tasks.CancellationTokenSource(10000);
			let gg = Calysto.Page.Social.Google.GoogleProvider.GetProvider(_googleApiKey, _googleClientId);
			//console.log(await gg.Login());
			console.log(await gg.LoadProfile(tokenSource.Token));
			console.log(gg);
			//tokenSource.Register(() => alert("token timeout"));
			tokenSource.CancelAfter();
		}
		catch (e)
		{
			alert(e);
		}
	}
}

import Google = Calysto.Web.TestSite.Web.CalystoUI.Social.Google

namespace Calysto.Web.TestSite.Web.CalystoUI.Social.Other
{
	//window.onunhandledrejection = function (ev)
	//{
	//	console.log(ev);
	//	console.log(ev.reason);
	//};

	//Calysto.Event.Attach(<any>window, "unhandledrejection", function (ev)
	//{
	//	console.log(ev.type);
	//	console.log(ev);
	//});

	Calysto.Page.OnUnhandledException(err =>
	{
		alert("unhandled: " + err);
	});

	export async function Test1()
	{
		let m1 = 0;
		while (m1++ < 10)
		{
			console.log(m1);
			await Tasks.TaskUtility.SleepAsync(500);
		}
	}

	export async function Test2()
	{
		let t1 = new DateTime().Ticks;
		let t2 = TimeSpan.FromTicks(t1);

		try
		{
			console.log("#1");
			throw "err1";
		}
		catch(ex1)
		{
			console.log(ex1);
			throw "err2";
		}
		finally
		{
			console.log("#2");
		}
	}

	export async function Test3()
	{
		console.log("#1");

		let res4 = await Calysto.Core.UseDispose(new Tasks.CancellationTokenSource(3000), token =>
		{
			Tasks.TaskUtility.SleepAsync(1000).TimeoutAsync(100);
		});

		let res1 = await Calysto.Core.UseDispose(new Tasks.CancellationTokenSource(3000), async token => await Tasks.TaskUtility.RunAsync(async () =>
		{
			await Tasks.TaskUtility.SleepAsync(1000);
			return 22;
		}, token));

		console.log(res1);

		let token1 = new Tasks.CancellationTokenSource(3000);
		try
		{
			let res2 = await Tasks.TaskUtility.RunAsync(async () =>
			{
				await Tasks.TaskUtility.SleepAsync(1000);
				return 33;
			}, token1);

			console.log(res2);
		}
		finally
		{
			token1.Dispose();
		}

		console.log("#2");
	}

	let monitor1 = new Calysto.Tasks.CalystoMonitor();

	export async function Test4()
	{
		console.log("#start");
		let cnt = 0;
		setTimeout(async () =>
		{
			while (cnt++ < 10)
			{
				console.log("#before: " + cnt)
				console.log(await monitor1.WaitAsync(3000));
				console.log("#after: " + cnt);
			}
		});

		console.log("#end");
	}

	export async function Test5()
	{
		monitor1.Pulse("single");
	}

	export async function Test6()
	{
		monitor1.PulseAll("all");
	}

	export async function Test7()
	{
		// ne reloadirati cesce od 30 sekundi
		// setiramo _cRelExpires, potom provjerimo da li je setiran i onda moze reload, u protivnom ne
		if (!(parseInt(sessionStorage["_cRelExpires"]) > Date.now()))
		{
			sessionStorage["_cRelExpires"] = Date.now() + 30000;
			if (parseInt(sessionStorage["_cRelExpires"]) > Date.now())
			{
				location.reload(true);
			}
		}
	}

	export async function Test8()
	{
		
	}

	export async function Test9()
	{

	}
}

import Other = Calysto.Web.TestSite.Web.CalystoUI.Social.Other

