using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calysto.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Net;
using System.Threading;

namespace Calysto.Net.Tests
{
	[TestClass()]
	public class CalystoWebDownloaderTests
	{
		private void Client_OnUploadProgress(CalystoWebClient obj, CalystoWebClientProgressArg arg)
		{
			Trace.WriteLine($"UploadPosition: {arg.Current} / {arg.Total}");
		}

		private void Client_OnUploadComplete(CalystoWebClient obj)
		{
			Trace.WriteLine($"UploadComplete");
		}

		private void Client_OnResponseProgress(CalystoWebClient obj, CalystoWebClientProgressArg arg)
		{
			Trace.WriteLine($"ResponsePosition: {arg.Current} / {arg.Total}");
		}

		private void Client_OnResponseComplete(CalystoWebClient obj)
		{
			Trace.WriteLine($"ResponseComplete");
		}

		[TestMethod()]
		public void Test001()
		{
			CalystoWebDownloader dd = new CalystoWebDownloader("https://www.eposlovni.eu");
			dd.Client.OnResponseComplete += (Client_OnResponseComplete);
			dd.Client.OnResponseProgress += (Client_OnResponseProgress);
			dd.Client.OnUploadComplete += (Client_OnUploadComplete);
			dd.Client.OnUploadProgress += (Client_OnUploadProgress);
			string html1 = dd.DownloadString();
		}

		[ExpectedException(typeof(WebException))]
		[TestMethod()]
		public void Test002()
		{
			// nece uploadirati jer receiver ne cita podatke iz streama
			CalystoWebDownloader dd = new CalystoWebDownloader("https://www.eposlovni.eu");
			dd.Timeout = 10000;
			dd.UploadData = new byte[1000000];
			dd.Client.OnResponseComplete += (Client_OnResponseComplete);
			dd.Client.OnResponseProgress += (Client_OnResponseProgress);
			dd.Client.OnUploadComplete += (Client_OnUploadComplete);
			dd.Client.OnUploadProgress += (Client_OnUploadProgress);
			string html1 = dd.DownloadString();
		}

		[ExpectedException(typeof(WebException))]
		[TestMethod()]
		public void Test003()
		{
			// nepostojeci url
			CalystoWebDownloader dd = new CalystoWebDownloader("https://www.nepostojeciurl413261234rterwey14512.com");
			string html1 = dd.DownloadString();
		}
	}
}