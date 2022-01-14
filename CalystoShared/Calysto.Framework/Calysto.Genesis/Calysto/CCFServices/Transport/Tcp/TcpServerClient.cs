using Calysto.CCFServices.Transport.Tcp.TcpNode;
using System.Net.Sockets;

namespace Calysto.CCFServices.Transport.Tcp
{
	public class TcpServerClient : TcpTransportSocketBase<TcpServerClient>
	{
		public TcpServerClient(Socket socket = null) : base(socket)
		{
		}
	}
}
