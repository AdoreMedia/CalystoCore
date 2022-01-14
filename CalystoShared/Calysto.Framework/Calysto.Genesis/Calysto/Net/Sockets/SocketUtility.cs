using System.Net;

namespace Calysto.Net.Sockets
{
	public class SocketUtility
	{
		public static string CreateEndPointsKey(EndPoint localEP, EndPoint remoteEP)
		{
			return $"-L:{localEP} -R:{remoteEP}";
		}
	}
}
