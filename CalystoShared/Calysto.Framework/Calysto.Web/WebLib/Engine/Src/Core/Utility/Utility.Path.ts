namespace Calysto.Utility.Path
{
	function RemoveQueryStr(path: string)
	{
		var index;
		if (path && (index = path.indexOf("?")) >= 0)
		{
			return path.substr(0, index);
		}
		return path;
	}

	export function GetQueryString(path: string)
	{
		/// <summary>
		/// Returns query string from path, starting with ?<br/>
		/// Returns "?par=something&amp;nn=4325" from "/CalystoWebControlsTests/TelephoneNumbers.aspx?par=something&amp;nn=4325"<br/>
		/// Works with left and right slash: / \
		/// </summary>
		/// <param name="path"></param>
		var index;
		if (path && (index = path.indexOf("?")) >= 0)
		{
			return path.substr(index);
		}
		return "";
	}

	export function GetFilePath(path: string)
	{
		/// <summary>
		/// Returns "/CalystoWebControlsTests/TelephoneNumbers.aspx" from "/CalystoWebControlsTests/TelephoneNumbers.aspx?par=something&amp;nn=4325"<br/>
		/// Works with left and right slash: / \
		/// </summary>
		/// <param name="path"></param>
		var index;
		if (path && (index = path.indexOf("?")) >= 0)
		{
			return path.substr(0, index);
		}
		return path;
	}

	export function GetExtension(path: string)
	{
		/// <summary>
		/// Returns ".aspx" from "/CalystoWebControlsTests/TelephoneNumbers.aspx?par=something&amp;nn=4325"<br/>
		/// Works with left and right slash: / \
		/// </summary>
		/// <param name="path"></param>
		var index;
		if (path && (path = RemoveQueryStr(path)) && (index = path.lastIndexOf(".")) >= 0)
		{
			return path.substr(index);
		}
		return "";
	}

	export function GetDirectoryName(path: string)
	{
		/// <summary>
		/// Returns "/CalystoWebControlsTests" from "/CalystoWebControlsTests/TelephoneNumbers.aspx"<br/>
		/// Works with left and right slash: / \
		/// </summary>
		/// <param name="path"></param>
		var index;
		if (path && (path = RemoveQueryStr(path)) && ((index = path.lastIndexOf("/")) >= 0 || (index = path.lastIndexOf("\\")) >= 0))
		{
			return path.substr(0, index);
		}
		return path;
	}

	export function GetFileName(path: string)
	{
		/// <summary>
		/// Returns "TelephoneNumbers.aspx" from "/CalystoWebControlsTests/TelephoneNumbers.aspx"<br/>
		/// Works with left and right slash: / \
		/// </summary>
		/// <param name="path"></param>
		var index;
		if (path && (path = RemoveQueryStr(path)) && ((index = path.lastIndexOf("/")) >= 0 || (index = path.lastIndexOf("\\")) >= 0))
		{
			return path.substr(index + 1);
		}
		return path;
	}
}
