namespace Calysto.Web.TestSite.Web.CalystoUI.Sockets
{
	function GetSocketInputText()
	{
		return $$calysto<HTMLInputElement>("#socketInput").Select(o => o.value).First();
	}

	function GetSocketInputFiles()
	{
		return <Blob[]><any> $$calysto<HTMLInputElement>("#socketFiles").Select(o => o.files).First();
	}

	var hh = new SocketSession();

	hh.Socket.OnClose(() => console.log("socket OnClose"));

	hh.Socket.OnMessage((rawObj) => console.log({ OnMessage: rawObj }));

	hh.Socket.OnError((msg) => console.log("OnError: " + msg));

	hh.OnBroadcastMessage((obj) =>
	{
		console.log({ OnBroadcastMessage: obj });
	});

	export async function SocketOpen(sender)
	{
		await hh.Socket.OpenAsync();
		console.log("opened: " + hh.Socket.IsOpened());
	}

	export function SocketClose(sender)
	{
		hh.Socket.Close();
	}

	export async function SendSocket(sender)
	{
		hh.HelloWorld(GetSocketInputText(), GetSocketInputFiles())
			.OnSuccess(resp => console.log({ HelloWorldResponse: resp }));
	}

	export function SendSocketDelayed(sender)
	{
		let a1 = hh.HelloWorld(GetSocketInputText(), GetSocketInputFiles())
			.OnSuccess(resp => console.log({ HelloWorldResponse: resp }));

		setTimeout(() => { a1.OnSuccess(resp => alert("delayed: " + resp)) }, 1000);
	}

	export function SocketErrorTest(sender, error)
	{
		hh.SocketErrorTest(GetSocketInputText(), "last name", 22, GetSocketInputFiles())
			.OnSuccess(() => console.log("SocketErrorTest success"))
			.OnError(err => console.log("SocketErrorTest error: " + err))
			.OnResponse(cc => console.log(cc));
	}

	export function SocketHelloWorld(sender)
	{
		hh.SetHelloString(GetSocketInputText())
			.OnSuccess(resp => console.log("SocketHelloWorld response: " + resp));
	}

	export function SocketSendToAll(sender)
	{

		hh.SocketSendToAll(GetSocketInputText())
			.OnSuccess(() => console.log("SocketSendToAll response"));
	}

	export async function SocketSendResultAsync(sender)
	{
		let res1 = await hh.SetHelloString(GetSocketInputText()).ResultAsync();
		console.log("async response: " + res1);
	}

}

const Sockets = Calysto.Web.TestSite.Web.CalystoUI.Sockets;
