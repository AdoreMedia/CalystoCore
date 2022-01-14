using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text;
using System.Threading;
using Calysto.Threading;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Linq;
using Calysto.Linq;
using System.Diagnostics;
using Calysto.Common;
using Calysto.Threading.Tasks;
using System.Threading.Tasks;

namespace Calysto.Net.Sockets
{
	class ClientSocket : ClientSocketBase<ClientSocket>
	{
		public ClientSocket(Socket socket = null) : base(socket) { }
	}

	class ServerSocket : ServerSocketBase<ServerSocket>
	{

	}

	[TestClass]
	public class ServerSocketTests
	{
		int _thrId = 0;
		private void WriteLine(string msg)
		{
			Trace.WriteLine($"{DateTime.Now.ToString("HH:mm:ss.fff")} {GetThreadName()} > {msg}");
		}

		private string GetThreadName()
		{
			if (Thread.CurrentThread.Name == null)
				Thread.CurrentThread.Name = $"thr({(_thrId++)}) mutex({_mutex1.Entrances})";

			return Thread.CurrentThread.Name;
		}

		private string GetString(byte[] data) => data == null ? "[empty]" : Encoding.UTF8.GetString(data);

		CalystoMutex _mutex1 = new CalystoMutex(2220);
		int _disposedCnt = 0;
		int _sentCnt = 0;
		int _receivedCnt = 0;
		int _num = 0;

		[TestMethod]
		public void CompleteCommunicationTest1()
		{
			ClientSocket remoteClient = new ClientSocket();
			ServerSocket server = new ServerSocket();

			Task.Run(async () =>
			{
				WriteLine("StartServer1");

				server.OnClientConnected += (Server_OnClientConnected);
				server.OnException += (Server_OnException);
				server.StartListening(870);

				remoteClient.OnDataChunkSent += (RemoteClient_OnDataBlockSent);
				remoteClient.OnDataReceived += (RemoteClient_OnDataReceived);
				remoteClient.OnDisposed += (RemoteClient_OnDisposed);
				remoteClient.OnException += (RemoteClient_OnException);
				remoteClient.OnSendCompleted += (RemoteClient_OnSendCompleted);
				WriteLine("RemoteClient_BeginConnect");
				await remoteClient.ConnectAsync("local.server", 870);
				await RemoteClient_OnConnected(remoteClient);
			});

			if (!_mutex1.Wait(TimeSpan.FromSeconds(5)))
			{
				Trace.WriteLine("Mutex.WaitingCount: " + _mutex1.Entrances);
				throw new TimeoutException();
			}

			Task.Run(() =>
			{
				// wait for the event to trigger
				while (_disposedCnt != 2)
					Thread.Sleep(100);

				WriteLine("Sent: " + _sentCnt);
				WriteLine("Received: " + _receivedCnt);
				WriteLine("Disposed: " + _disposedCnt);
			}).Wait(5000);

			Assert.IsTrue(_sentCnt > 4);
			Assert.IsTrue(_receivedCnt > 4);
			Assert.AreEqual(2, _disposedCnt);

			WriteLine("Test complete");
		}

		private void Server_OnException(ServerSocket arg1, Exception arg2)
		{
			WriteLine("Server_OnException");
		}

		private void RemoteClient_OnSendCompleted(ClientSocket obj, int totalSent)
		{
			Interlocked.Increment(ref _sentCnt);
			_mutex1.ReleaseOne();
			WriteLine("RemoteClient_OnSendCompleted " + totalSent);
		}

		private void RemoteClient_OnException(ClientSocket arg1, Exception arg2)
		{
			WriteLine("RemoteClient_OnFatalError: " + arg2.Message);
		}

		private void RemoteClient_OnDisposed(ClientSocket obj)
		{
			Interlocked.Increment(ref _disposedCnt);
			_mutex1.ReleaseOne();
			WriteLine("RemoteClient_OnDisposed");
		}

		private async Task RemoteClient_OnDataReceived(ClientSocket arg1, byte[] arg2)
		{
			Interlocked.Increment(ref _receivedCnt);
			_mutex1.ReleaseOne();
			WriteLine("RemoteClient_OnDataReceived: " + GetString(arg2));

			if (_mutex1.Entrances > 2)
				await arg1.SendAsync("from RemoteClient #" + Interlocked.Increment(ref _num));
			else
				arg1.Dispose();
		}

		private void RemoteClient_OnDataBlockSent(ClientSocket arg1, int arg2)
		{
			WriteLine("RemoteClient_OnDataBlockSent: " + arg2);
		}

		private async Task RemoteClient_OnConnected(ClientSocket obj)
		{
			WriteLine("RemoteClient_OnConnected");
			await obj.BeginReceiveAsync();

			WriteLine("RemoteClient_BeginSend: #1 sent from remoteClient");
			await obj.SendAsync("#1 sent from remoteClient");
		}

		private async Task Server_OnClientConnected(ServerSocket arg1, Socket client)
		{
			ClientSocket serversClient = new ClientSocket(client);
			WriteLine("Server_OnClientConnected");
			await ServersClient_OnConnected(serversClient);
			serversClient.OnDataChunkSent += (ServersClient_OnDataBlockSent);
			serversClient.OnDataReceived += (ServersClient_OnDataReceived);
			serversClient.OnDisposed += (ServersClient_OnDisposed);
			serversClient.OnException += (ServersClient_OnFatalError);
			serversClient.OnSendCompleted += (ServersClient_OnSendCompleted);
			await serversClient.BeginReceiveAsync();
			WriteLine("ServerClient_BeginSend: #2 sent from serversClient");
			await serversClient.SendAsync("#2 sent from serverClient");
		}

		private void ServersClient_OnSendCompleted(ClientSocket obj, int totalSent)
		{
			Interlocked.Increment(ref _sentCnt);
			_mutex1.ReleaseOne();
			WriteLine("ServersClient_OnSendCompleted " + totalSent);
		}

		private void ServersClient_OnFatalError(ClientSocket arg1, Exception arg2)
		{
			WriteLine("ServersClient_OnFatalError: " + arg2.Message);
		}

		private void ServersClient_OnDisposed(ClientSocket obj)
		{
			Interlocked.Increment(ref _disposedCnt);
			_mutex1.ReleaseOne();
			WriteLine("ServersClient_OnDisposed");
		}

		private async Task ServersClient_OnDataReceived(ClientSocket arg1, byte[] arg2)
		{
			Interlocked.Increment(ref _receivedCnt);
			_mutex1.ReleaseOne();
			WriteLine("ServersClient_OnDataReceived: " + GetString(arg2));

			if (_mutex1.Entrances > 2)
				await arg1.SendAsync("from ServersClient #" + Interlocked.Increment(ref _num));
			else
				arg1.Dispose();
		}

		private void ServersClient_OnDataBlockSent(ClientSocket arg1, int arg2)
		{
			WriteLine("ServersClient_OnDataBlockSent: " + arg2);
		}

		private async Task ServersClient_OnConnected(ClientSocket obj)
		{
			WriteLine("ServersClient_OnConnected");
			await Task.CompletedTask;
		}
	}
}
