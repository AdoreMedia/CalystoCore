namespace Calysto.CCFServices.Transport.Tcp.TcpNode
{
	public class LogEntry
	{
		private TcpTransportCommandEnum Command { get; set; }
		private byte[] Data { get; set; }

		public LogEntry(TcpTransportCommandEnum command, byte[] data)
		{
			this.Command = command;
			this.Data = data;
		}
	}
}