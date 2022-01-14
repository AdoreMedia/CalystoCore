/// <reference path="calystointerfaces.d.ts" />
/// <reference path="calystodeclarations.d.ts" />
// **************************************************************************
// Calysto.Core.Constants should be generated on server and included before any other js code
// **************************************************************************
declare interface IRuntimeConstants
{
	IsDebugDefined: boolean;

	IsLocallyHosted: boolean;

	IsTddSpecific: boolean;

	WebClientGlobalTimeout: number;

	/** Elmah url */
	ServerDiagnosticUrl: string;

	/** .NET context.Request.PathBase.Value
	 * path required to resolve app relative ~/ into virtual path /
	 * */
	UrlPathBase: string;

	RandomRFCTable64: string;

	/** Culture retrieved using AJAX on first request. */
	CurrentCulture: Calysto.Globalization.CultureInfo;

}

