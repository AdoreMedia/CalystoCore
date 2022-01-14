using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UnitTests.Calysto.CCFServices.Contract;
using System.Diagnostics;
using System.IO;
using Calysto.CCFServices.Host;
using Calysto.CCFServices.Transport;
using Calysto.CCFServices.Transport.Tcp;

namespace Calysto.CCFServices.Tests
{
	[TestClass()]
	public class TcpTransportTests1
	{
		string _hostname1 = "local.server";
		int _port1 = 42381;
		int _port2 = 42382;

		CalystoServiceHost<RemoteController> host1;
		CalystoServiceHost<RemoteController> host2;

		[TestInitialize]
		public void StarListeners()
		{
			TcpTransportServer transport1 = new TcpTransportServer(_hostname1, _port1);
			host1 = new CalystoServiceHost<RemoteController>(transport1);
			host1.UseSessionState = true;
			host1.UseEncryptionKey("dasdfads");
			transport1.StartListening();

			TcpTransportServer transport2 = new TcpTransportServer(_hostname1, _port2);
			host2 = new CalystoServiceHost<RemoteController>(transport2);
			//host2.UseSessionState = true;
			transport2.StartListening();
		}

		[TestCleanup]
		public void StopListeners()
		{
			host1.Dispose();
			host2.Dispose();
		}

		private RemoteClient CreateNewClient()
		{
			RemoteClient client = new RemoteClient(new TcpTransportClient(_hostname1, _port1));
			client.Client.UseEncryptionKey("dasdfads");
			return client;
		}

		[TestMethod()]
		public void Test1()
		{
			int res1 = CreateNewClient().SumNumbers2(2, 4);
			Assert.AreEqual(6, res1);

			Tuple<int, int, int> res2 = CreateNewClient().SumNumbers(5, 6);
			Assert.AreEqual(5, res2.Item1);
			Assert.AreEqual(6, res2.Item2);
			Assert.AreEqual(11, res2.Item3);

			string token = CreateNewClient().GetToken();
			Assert.IsTrue(token.Length == 36);

			TimeSpan sp = CreateNewClient().DateDiff(DateTime.Now, DateTime.Now.AddMinutes(-25).AddDays(-2345));
			Assert.IsTrue(sp.TotalDays > 2000);
			Assert.IsTrue(sp.TotalDays < 3000);
		}

		[TestMethod]
		public void Test2()
		{
			var client = CreateNewClient();

			int age1 = client.GetAge(30);
			Assert.AreEqual(30, age1);
			
			client.SetAge(20); // spremi u session

			int age2 = client.GetAge(30);
			Assert.AreEqual(50, age2);

			client.Client.UseSessionState = false; // setting session to false will delete SessionId
			int age3 = client.GetAge(40);
			Assert.AreEqual(40, age3);

			client.Client.UseSessionState = true; // starta novi session
			int age4 = client.GetAge(50);
			Assert.AreEqual(50, age4);

			// novi client
			int age5 = CreateNewClient().GetAge(423);
			Assert.AreEqual(423, age5);

			// stari client
			client.SetAge(200);
			int age6 = client.GetAge(123);
			Assert.AreEqual(323, age6);
		}

		[TestMethod]
		public void Test3()
		{
			byte[] data = File.ReadAllBytes("TestFiles\\openvpn.tar.gz");
			var client = CreateNewClient();
			client.Client.OnRequestProgress += (Client_OnProgress);
			var res1 = client.MeasureLength(data);

			Assert.AreEqual(1457784, res1.Item1);
			Assert.AreEqual(1457784, res1.Item2.Length);

		}

		[TestMethod]
		public void Test4()
		{
			byte[] data = File.ReadAllBytes("TestFiles\\middle.mp4");
			var client = CreateNewClient();
			//client.Client.OnRequestProgress += (Client_OnProgress);
			// test 10 * 19MB = 190 MB traje cca 2 sekunde
			// test 100 * 19MB = 1900 MB traje cca 17 sekundi
			string res1 = null;
			for(int n1 = 0; n1 < 10; n1++)
			{
				res1 = client.UploadBinaryData("file1", data);
			}

			Assert.AreEqual("Received file1 of 19701913 bytes", res1);
		}

		private void Client_OnProgress(ProgressEventArgs obj)
		{
			Trace.WriteLine("Progress: " + obj.ProgressPercentage);
		}

		[TestMethod]
		public void TestException1()
		{
			try
			{
				var client = CreateNewClient();
				client.TestExceptionThrowing();
			}
			catch(Exception ex)
			{
				Assert.AreEqual("this is exception #1", ex.GetBaseException().GetBaseException().Message);
				return;
			}

			Assert.Fail();
		}

	}
}