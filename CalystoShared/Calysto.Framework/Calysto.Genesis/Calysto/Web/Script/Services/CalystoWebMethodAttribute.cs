using System;

namespace Calysto.Web.Script.Services
{
	[AttributeUsage(AttributeTargets.Method)]
	public sealed class CalystoWebMethodAttribute : Attribute
	{
		/// <summary>
		/// [ms] Current method ajax request timeout in ms. Default is 0 meaning will use global timeout value.
		/// </summary>
		public int Timeout { get; set; }

		/// <summary>
		/// If true, use HttpSessionState.
		/// </summary>
		public bool SessionState { get; set; }

		/// <summary>
		/// If true, will not count ajax request and none of events connected with count will not be invoked (Calysto.Page.OnLoading, Calysto.Page.OnBeginRequest, Calysto.Page.OnEndResponse).
		/// </summary>
		public bool Silent { get; set; }

		/////// <summary>
		/////// If true, use web socket for this method.
		/////// </summary>
		////public bool Socket { get; set; }

		/// <summary>
		/// If true, method may be invoked only on user event on client. Validation is made on client.
		/// </summary>
		public bool UserEvent { get; set; }

		/////// <summary>
		/////// If true, will create shared socket and send ajax request using shared socket.
		/////// </summary>
		////public bool AjaxViaSocket { get; set; }

		/// <summary>
		/// if true, will always use POST to send data to server
		/// </summary>
		public bool UsePost { get; set; }

	}
}
