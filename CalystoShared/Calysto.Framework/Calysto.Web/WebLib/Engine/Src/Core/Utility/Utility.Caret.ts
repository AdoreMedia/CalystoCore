namespace Calysto.Utility.Caret
{
	export function SetInputSelectionRange(node: Node, start: number, end: number)
	{
		/// <summary>
		/// Select text from start to end index. If start and end are not set, will unselect all.
		/// </summary>
		/// <param name="object"></param>
		/// <param name="start" optional="true">if not set, select from start</param>
		/// <param name="end" optional="true">if not set, select to the end of string</param>

		var object: any = node;

		if (object == null || !object.type)
		{
			return;
		}
		try
		{
			if (!start || start < 0)
			{
				start = 0;
			}
			if (arguments.length < 3 || end > object.value.length)
			{
				end = object.value.length;
			}
			if (object.setSelectionRange)
			{
				object.focus();
				object.setSelectionRange(start, end);
			}
			else if (object.createTextRange)
			{
				object.focus();
				var range;
				if (object.caret)
				{
					range = object.caret;
					range.moveStart("textedit", -1);
					range.moveEnd("textedit", -1);
				} else
				{
					range = object.createTextRange();
				}
				range.moveEnd('character', end);
				range.moveStart('character', start);
				range.select();
			}
		} catch (e)
		{
			// Ignore
		}
	}

	export function SetCaretPosition(node: Node, position: number)
	{
		/// <summary>
		/// Set caret position in text.
		/// </summary>
		/// <param name="object"></param>

		SetInputSelectionRange(node, position, position);
	}

	export function GetCaretPosition(obj: Node): number | null
	{
		/// <summary>
		/// Returns caret position in text.
		/// </summary>
		/// <param name="object"></param>

		var object: any = obj;

		if (object == null || !object.type)
		{
			return null;
		}
		try
		{
			if (object.createTextRange && object.caret)
			{
				var range = object.caret.duplicate();
				range.moveStart('textedit', -1);
				return range.text.length;
			} else if (object.selectionStart || object.selectionStart == 0)
			{
				return object.selectionStart;
			}
		} catch (e)
		{
		}
		return null;
	}

	export function GetInputSelectionRange(obj: Node): { start: number, end: number } | null
	{
		/// <summary>
		/// Returns array with start and end index of current text selection.
		/// </summary>
		/// <param name="object"></param>

		var object: any = obj;

		if (object == null || !object.type)
		{
			return null;
		}
		try
		{
			if (object.selectionEnd)
			{
				return { start: object.selectionStart, end: object.selectionEnd };
			} else if (object.createTextRange && object.caret)
			{
				var end = GetCaretPosition(object);
				if (typeof (end) == "number")
				{
					return { start: end - object.caret.text.length, end: end };
				}
				// nothing selected
			}
		} catch (e)
		{
			// Ignore
		}

		return null;
	}

}

