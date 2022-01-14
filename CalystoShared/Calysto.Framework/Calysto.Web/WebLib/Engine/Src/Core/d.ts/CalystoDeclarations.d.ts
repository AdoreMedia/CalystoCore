/// <reference path="CalystoInterfaces.d.ts" />
declare namespace Calysto.Serialization.Json
{
	interface BinaryFrame
	{
		Blobs: Blob[];
		Json: string;
	}
}

declare namespace Calysto.Serialization.Json.BinaryFrame
{
	interface BinaryToc
	{
		Items: Calysto.Serialization.Json.BinaryFrame.BinaryToc.TocItem[];
	}
}

declare namespace Calysto.Serialization.Json.BinaryFrame.BinaryToc
{
	interface TocItem
	{
		BlobIndex: number;
		FileName: string;
		IsJson: boolean;
		MimeType: string;
		Size: number;
	}
}

declare namespace System.Web.UI
{
	interface Page { }
	interface UserControl { }
	interface MasterPage { }
}

declare namespace Calysto.Data.Linq
{
	interface EntityBase<T, C> { }
	interface DataContext { }
}

declare namespace System.Collections.Generic
{
	interface KeyValuePair<TKey, TValue> { }
}

declare namespace Calysto.Web.Script.Services.WebSockets
{
	interface WebSocketService { }
}

declare namespace Calysto.Web.Script.Services
{
	interface ICalystoJavaScriptDirect { }
}

declare namespace Microsoft.AspNetCore.Mvc
{
	interface Controller { }
}

declare namespace Microsoft.AspNetCore.Mvc.Razor
{
	interface RazorPage { }
}

declare namespace Calysto.Web
{
	interface CalystoResponse { }
}

declare namespace Microsoft.AspNetCore.Html
{
	interface HtmlString extends String
	{
	}
}

declare namespace Calysto.WebView
{
	interface HostServiceProvider { }
}