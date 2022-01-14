using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Calysto.Net.Sockets
{
	public class UdpDataReceivedBlock
	{
		public UdpClient UdpClient { get; }
		public IPEndPoint RemoteEndPoint { get; }
		public IPEndPoint LocalEndPoint { get; }

		public byte[] ReceivedBytes { get; private set; }

		public string ReceivedText => Encoding.UTF8.GetString(this.ReceivedBytes);

		public string EndPointsKey { get; private set; }

		public UdpDataReceivedBlock(UdpClient udpClient, byte[] datagram, IPEndPoint localEP, IPEndPoint remoteEP)
		{
			this.UdpClient = udpClient;
			this.RemoteEndPoint = remoteEP;
			this.LocalEndPoint = localEP;
			this.ReceivedBytes = datagram;
			this.EndPointsKey = SocketUtility.CreateEndPointsKey(localEP, remoteEP);
		}
	}
}
