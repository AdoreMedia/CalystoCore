using Calysto.CCFServices.Transport.Tcp;
using System;

namespace Calysto.CCFServices.Transport
{
	public class TransportRequest
	{
		public byte[] Data;
		public string RemoteAddress;
		public Action<byte[]> FnSendResponse;

		public TcpServerClient TcpNode;
	}
}
