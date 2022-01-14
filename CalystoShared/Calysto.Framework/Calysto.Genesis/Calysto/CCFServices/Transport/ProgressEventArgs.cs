using System;

namespace Calysto.CCFServices.Transport
{
	public class ProgressEventArgs : EventArgs
	{
		public string Description { get; }
		public long BytesTransfered { get; }
		public long TotalBytes { get; }
		public double ProgressPercentage => 100.0 * this.BytesTransfered / this.TotalBytes;

		public ProgressEventArgs(long transferedBytes, long totalBytes, string description = null)
		{
			this.Description = description;
			this.BytesTransfered = transferedBytes;
			this.TotalBytes = totalBytes;
		}
	}
}