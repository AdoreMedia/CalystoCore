using Calysto.Threading;
using Calysto.TypeLite;
using Calysto.Web;
using Calysto.Web.Script.Services;
using Calysto.Web.Script.Services.WebSockets;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Web;

namespace Calysto.Web.TestSite.Web.CalystoUI.Sockets
{
	public class Request
	{
		public string Boja { get; set; }
		public int Visina { get; set; }
		public CalystoBlob[] FilesCollection { get; set; }
	}

	public class BroadcastMessage
	{
		public string Name { get; set; }
		public int Age { get; set; }
		public bool IsActive { get; set; }
		public CalystoBlob[] FilesCollection { get; set; }
	}

	public class SocketResponse1
	{
		public string Poruka { get; set; }
		public CalystoBlob[] FilesReceived { get; set; }
	}

	[TsClass]
	public class SocketSession : WebSocketSession<string>
	{
		public override void OnOpen()
		{
			var listeners = this.Service.GetListeners(ListenersKind.All);
			this.BroadcastMessage(ListenersKind.All, () => $"dodan novi listener, listeners: {listeners.Count}").Wait();
		}

		public override void OnClose()
		{
			var listeners = this.Service.GetListeners(ListenersKind.All);
			this.BroadcastMessage(ListenersKind.All, () => $"izbacen listener, listeners: {listeners.Count}").Wait();
		}

		[CalystoWebMethod]
		public SocketResponse1 HelloWorld(string text, CalystoBlob[] blob)
		{
			var obj1 = new SocketResponse1 { Poruka = text, FilesReceived = blob };

			return obj1;
		}

		[CalystoWebMethod]
		public void SocketErrorTest(string name, string prezime, int age, CalystoBlob[] blob)
		{
			throw new InvalidOperationException("ovo je opis greske");
		}

		[CalystoWebMethod]
		public string SetHelloString(string text)
		{
			return "received: " + text;
		}

		[CalystoWebMethod]
		public void SocketSendToAll(string text)
		{
			var listeners = this.Service.GetListeners(ListenersKind.All);
			this.BroadcastMessage(ListenersKind.All, () => $"poruka svima: {text}").Wait();
		}
	}
}