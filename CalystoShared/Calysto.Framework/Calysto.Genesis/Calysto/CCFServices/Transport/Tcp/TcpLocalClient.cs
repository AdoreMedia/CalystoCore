using Calysto.CCFServices.Transport.Tcp.TcpNode;
using System.Net.Sockets;

namespace Calysto.CCFServices.Transport.Tcp
{
	public class TcpLocalClient : TcpTransportSocketBase<TcpLocalClient>
	{
		public TcpLocalClient(Socket socket = null) : base(socket)
		{
		}
	}
}
