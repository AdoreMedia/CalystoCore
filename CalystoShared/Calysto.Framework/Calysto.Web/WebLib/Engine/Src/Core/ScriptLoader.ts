namespace Calysto.ScriptLoader
{
	/**
	 * Return true if script is marked, return false if it was already marked and executed.
	 * @param node
	 */
	export function MarkScriptExecuted(node: HTMLScriptElement)
	{
		if ((<any>node).$$$executed)
		{
			return false;
		}
		else
		{
			(<any>node).$$$executed = true;
			return true;
		}
	}

	/**
	 * Reload and execute script tag content, only if not already executed.
	 * @param node
	 */
	export function ExecuteScriptNode(node: HTMLScriptElement, alwaysExecute: boolean = false)
	{
		if (!alwaysExecute && !MarkScriptExecuted(node))
			return false;

		let tagName = node.tagName.toLowerCase();
		let s1 = document.createElement(tagName);

		for (let n1 = 0; n1 < node.attributes.length; n1++)
			s1.setAttribute(node.attributes[n1].name, node.attributes[n1].value);

		s1["text"] = s1.textContent = node.textContent || node["text"];

		Calysto.Utility.Dom.ReplaceWith(node, [s1]);

		MarkScriptExecuted(<any>s1);

		return s1; // return node
	}

	/**
	 * Create and return script element.
	 * @param scriptFileUrl
	 * @param id
	 */
	export function LoadJSFile(scriptFileUrl: string, id?: string)
	{
		var s = document.createElement("script");
		s.type = "text/javascript";
		s.src = scriptFileUrl;
		s.async = true;
		if (id)
			s.id = id;
		(document.getElementsByTagName("head")[0] || document.body || document.documentElement).appendChild(s);
		return s;
	}

	/**
	 * Return script element if created, else undefined.
	 * @param scriptFileUrl
	 * @param id
	 */
	export function LoadJsFileOnce(scriptFileUrl: string, id: string)
	{
		if (!document.getElementById(id))
		{
			return LoadJSFile(scriptFileUrl, id);
		}
		return undefined;
	}

	export function LoadJS(javascriptCode: string)
	{
		////if (Calysto.Core.IsDebugDefined)
		////{
		////	(window["$js$"] = window["$js$"] || []).push(javascriptCode);
		////	console.log(javascriptCode);
		////}

		var s = document.createElement("script");
		s.type = "text/javascript";
		s.text = s.textContent = javascriptCode; // ie9 or higher and gecko uses textContent, <=ie8 uses text
		(document.getElementsByTagName("head")[0] || document.body || document.documentElement).appendChild(s);
		return s;
	}

	export function LoadCSSFile(cssFileUrl: string, id?: string)
	{
		var s = document.createElement("link");
		s.rel = "stylesheet";
		s.type = "text/css";
		if (id)
			s.id = id;
		s.href = cssFileUrl;
		(document.getElementsByTagName("head")[0] || document.body || document.documentElement).appendChild(s);
		return s;
	}

	export function LoadCSS(cssScriptCode: string, id?: string)
	{
		var s = document.createElement("style");
		s.type = "text/css";
		if (id)
			s.id = id;
		(<any>s).text = s.textContent = cssScriptCode; // works with ie 9 or higher and gecko only, <=ie8 is not supported
		(document.getElementsByTagName("head")[0] || document.body || document.documentElement).appendChild(s);
		return s;
	}
}
