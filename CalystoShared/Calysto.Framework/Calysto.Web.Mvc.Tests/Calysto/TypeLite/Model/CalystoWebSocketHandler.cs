using Calysto.Threading;
using Calysto.TypeLite;
using Calysto.Web;
using Calysto.Web.Script.Services;
using Calysto.Web.Script.Services.WebSockets;
using Calysto.Web.TestSite.Web.CalystoUI.Sockets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace Calysto.Genesis.UnitTest.Calysto.TypeLite.Model
{
	public class Request
	{
		public string Boja { get; set; }
		public int Size { get; set; }
	}

	public class Response
	{
		public string Name { get; set; }
		public bool IsActive { get; set; }
	}

	[TsClass]
	public class CalystoWebSocketHandler : WebSocketSession<Response>
	{
		//[CalystoWebMethod(Socket = true)]
		//public static object DrugaProba(string name, string prezime, int age)
		//{
		//	return new { Primljeno = name, Odgovor = "poslali ste " + name };
		//}

		//[CalystoWebMethod(Socket = true)]
		//public static object Treca()
		//{
		//	return new object();
		//}

		//public class SocketResponse1
		//{
		//	public string Poruka { get; set; }
		//	public CalystoBlob[] FilesReceived { get; set; }
		//}

		[CalystoWebMethod]
		public SocketResponse1 HelloWorld(string name, string prezime, int age, CalystoBlob[] blob)
		{
			if (name == "baci gresku")
				throw new Exception("ovo je bacena greska kroz WebSocket");

			return new SocketResponse1 { };
		}

		[CalystoWebMethod]
		public void SetHelloText(string text)
		{
			
		}

		//[CalystoWebMethod(Socket = false)]
		//public object HelloWorldAjax1()
		//{
		//	return null;
		//}

		//[CalystoWebMethod(Socket = false)]
		//public object HelloWorldAjax(string name, string prezime, int age)
		//{
		//	SendAll("HelloWorld", "odogovor svima: " + name);

		//	return "primljeno: " + name + ", odgovor: poslali ste: " + name;
		//}

	}
}