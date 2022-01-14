using System;
using System.Threading.Tasks;

namespace Calysto.CCFServices.Transport
{
	public interface ICCFTransport : IDisposable
	{
	}

	public interface ICCFTransportServer : ICCFTransport, IDisposable
	{
		event Action<TransportRequest> OnRequestDataReceived;
	}

	public interface ICCFTransportClient : ICCFTransport, IDisposable
	{
		event Action<ProgressEventArgs> OnProgress;
		event Action<byte[]> OnDataReceived;
		Task SendRequestAsync(byte[] sendData);
	}
}