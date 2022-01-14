using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using UnitTests.Calysto.CCFServices.Contract;
using System.Diagnostics;
using System.IO;
using Calysto.CCFServices.Host;
using Calysto.CCFServices.Transport;
using System.Threading;
using System.Threading.Tasks;
using Calysto.Threading.Tasks;
using Calysto.CCFServices.Transport.Tcp;

namespace Calysto.CCFServices.Tests
{
	[TestClass()]
	public class TcpTransportTests2
	{
		string _hostname1 = "local.server";
		int _port1 = 42385;
		int _port2 = 42386;

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
			catch (Exception ex)
			{
				Assert.AreEqual("this is exception #1", ex.GetBaseException().GetBaseException().Message);
				return;
			}

			Assert.Fail();
		}

		TaskCompletionNumeric _completion1 = new TaskCompletionNumeric(2);
		TaskCompletionNumeric _completion2 = new TaskCompletionNumeric(3);

		[Timeout(5000)]
		[TestMethod]
		public void EventTest1()
		{
			Task.Run(async () =>
			{
				RemoteClient cc = new RemoteClient(new TcpTransportClient(_hostname1, _port2));
				cc.OnAgeChanged += Cc_OnAgeChanged1;
				int a1 = cc.GetAge(21);
				cc.SetAge(500); // poziva samo 1. callback
				cc.OnAgeChanged += Cc_OnAgeChanged2;
				cc.SetAge(125); // poziva oba callbacka jer su oba dodijeljena
				cc.OnAgeChanged -= Cc_OnAgeChanged1;
				int a2 = cc.GetAge(73);
				cc.SetAge(22); // poziva samo 2. callback
				cc.OnAgeChanged -= Cc_OnAgeChanged1;
				cc.SetAge(22); // poziva samo 2. callback
				cc.OnAgeChanged -= Cc_OnAgeChanged2;
				cc.SetAge(22); // ne poziva vise nista
				int a3 = cc.GetAge(88);

				await _completion1.Task;
				await _completion2.Task;

			}).Wait();

			Assert.IsTrue(_completion1.Task.IsCompletedSuccessfully);
			Assert.IsTrue(_completion2.Task.IsCompletedSuccessfully);
		}

		private void Cc_OnAgeChanged1(int arg1, string arg2)
		{
			_completion1.DecrementOne();
		}

		private void Cc_OnAgeChanged2(int arg1, string arg2)
		{
			_completion2.DecrementOne();
		}

		TaskCompletionNumeric _completion3 = new TaskCompletionNumeric(2);

		[TestMethod]
		public void TestListChanged1()
		{
			Task.Run(async () =>
			{
				RemoteClient cc = new RemoteClient(new TcpTransportClient(_hostname1, _port2));
				cc.OnListChanged += Cc_OnListChanged;
				cc.MakeListChanged(null);
				cc.MakeListChanged(new List<string>() { "one", "two", "three" });

				await _completion3.Task;

			}).Wait();

			Assert.IsTrue(_completion3.Task.IsCompletedSuccessfully);
		}

		private void Cc_OnListChanged(int arg1, List<string> arg2)
		{
			_completion3.DecrementOne();
		}

		[TestMethod]
		public void SameMethodNameTest1()
		{
			// same method name is not allowed - Generator will report an error.

			var client = CreateNewClient();

			int age1 = client.GetNameLength("ovnm", 23);
			Assert.AreEqual(4, age1);


		}
	}
}