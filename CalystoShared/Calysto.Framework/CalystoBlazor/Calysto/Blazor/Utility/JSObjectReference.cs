using System.Text.Json.Serialization;

namespace Calysto.Blazor.Utility
{
	public class JSObjectReference
	{
		[JsonPropertyName("__jsObjectId")]
		public int JsObjectId { get; set; }
	}
}
