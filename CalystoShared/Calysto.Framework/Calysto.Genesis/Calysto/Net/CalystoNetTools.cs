using System;
using System.ComponentModel;
using System.Net;

namespace Calysto.Net
{
	/*
	ep1.Address
	16777343
	ep1.GetAddressBytes()
	{byte[4]}
		[0]: 127
		[1]: 0
		[2]: 0
		[3]: 1
	BitConverter.ToInt32(ep1.GetAddressBytes(), 0)
	16777343
	BitConverter.GetBytes(16777343)
	{byte[4]}
		[0]: 127
		[1]: 0
		[2]: 0
		[3]: 1
	*/

	public class CalystoNetTools
	{
		public static bool TryExtractIpV4AndPort(EndPoint endPoint, out string ipAddress, out int port, out long addressInt)
		{
			ipAddress = null;
			port = 0;
			addressInt = 0;

			try
			{
				IPEndPoint ep = (IPEndPoint)endPoint;
				var ep1 = ep?.Address?.MapToIPv4();
				
				ipAddress = ep1?.ToString(); ;
				port = ep?.Port ?? 0;
				addressInt = (long) Calysto.Utility.CalystoTools.IPAddressToNumber(ipAddress);

				return !string.IsNullOrEmpty(ipAddress);
			}
			catch { }

			return false;
		}

		//public static bool TryExtractIpAndPort(EndPoint endPoint, out string ipAddress, out int port)
		//{
		//	ipAddress = null;
		//	port = 0;

		//	// V6 endpoint: "[::ffff:127.0.0.1]:7255"
		//	string str1 = endPoint?.ToString();
		//	if (str1 != null)
		//	{
		//		int index1 = str1.LastIndexOf(':');
		//		if (index1 > 0)
		//		{
		//			ipAddress = str1.Remove(index1);

		//			if (!string.IsNullOrWhiteSpace(ipAddress) && int.TryParse(str1.Substring(index1 + 1), out port))
		//				return true;
		//		}
		//	}
		//	return false;
		//}

	}
}
