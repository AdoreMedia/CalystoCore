namespace Calysto.Web.Script.Services
{
	public static class WsjsHeaderConstants
	{

		public const string XAjaxHeaderKey = "x-calysto-ajax";
		public const string XAjaxHeaderValue = "calysto-ajax";
		public const string XExceptionHeaderValue = "calysto-exception";

		public const string XTypeHeaderKey = "x-calysto-type";
		public const string XTypeHeaderBinaryFrameValue = "calysto-binary-frame";

		public const string XCalystoAjaxFormKey = "x-calysto-ajax-form";
		public const string XCalystoAjaxFormValue = "calysto-form";

		public const string XCalystoAjaxLoadKey = "x-calysto-ajax-load";
		public const string XCalystoAjaxLoadValue = "calysto-load";

		public const string XCalystoResponseContainerKey = "x-calysto-container";
		public const string XCalystoResponseContainerValue = "calysto-container";

		public const string XCalystoFileNameKey = "x-calysto-filename";

		public const string XCalystoRequestWithKey = "x-calysto-request-with";
		public const string XCalystoRequestWithValue = "calysto-web-client";

		/// <summary>
		/// Value is Content-Type (mime)
		/// </summary>
		public const string XCalystoContentTypeKey = "x-calysto-content-type";

		/// <summary>
		/// Value is custom content from window.XCalystoPageStateValue
		/// </summary>
		public const string XCalystoPageStateKey = "x-calysto-page-state";

		/// <summary>
		/// Property on window, e.g. window.XCalystoPageStateValue
		/// </summary>
		public const string XCalystoPageStateValue = nameof(XCalystoPageStateValue);
	}
}