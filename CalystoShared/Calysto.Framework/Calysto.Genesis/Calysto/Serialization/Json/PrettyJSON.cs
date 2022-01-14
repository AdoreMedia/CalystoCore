using System;
using System.Collections.Generic;
using System.Text;

namespace Calysto.Serialization.Json
{
	public class PrettyJSON
	{
		private static string str_repeat(string str, int repatCount)
		{
			string ss = "";
			for (int n = 0; n < repatCount; n++)
			{
				ss += str;
			}
			return ss;
		}

		public static string PrettyJSONFormat(string json, bool isHtml = false, int indentSpaces = 4, int startingIndentLevel = 0)
		{
			string newLine = isHtml ? "<br/>" : "\r\n";
		
			string tab = str_repeat(isHtml ? "&nbsp;" : " ", indentSpaces);
			string new_json = "";
			if(isHtml)
			{
				new_json += "<div style='font-size:11px; font-family:Verdana'>";
			}
		
			int indent_level = startingIndentLevel;
			bool in_string = false;
		
			//json = json_encode(object);
			int len = json.Length;
					
			for(int index = 0; index < len; index++)
			{
				char ch = json[index];
				switch(ch)
				{
					case '{':
					case '[':
						if(!in_string)
						{
							new_json += newLine + str_repeat(tab, indent_level) + ch + newLine + str_repeat(tab, indent_level+1);
							indent_level++;
						}
						else
						{
							new_json += ch;
						}
						break;
					case '}':
					case ']':
						if(!in_string)
						{
							indent_level--;
							new_json += newLine + str_repeat(tab, indent_level) + ch;
						}
						else
						{
							new_json += ch;
						}
						break;
					case ',':
						if(!in_string)
						{
							new_json += "," + newLine + str_repeat(tab, indent_level);
						}
						else
						{
							new_json += ch;
						}
						break;
					case ':':
						if(!in_string)
						{
							new_json += ": ";
						}
						else
						{
							new_json += ch;
						}
						break;
					case '"':
						if(index > 0 && json[index-1] != '\\')
						{
							in_string = !in_string;
						}
						new_json += ch;
						break;
					default:
						new_json += ch;
						break;                    
				}
			}
			
			if(isHtml)
			{
				new_json += "</div>";
			}
			
			return new_json;
		}

	}
}