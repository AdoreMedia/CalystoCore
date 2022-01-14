using Calysto.Linq;
using Calysto.Text.RegularExpressions;
using System.Linq;
using System.Text.RegularExpressions;

namespace Calysto.Utility
{
	public class CalystoStringCompressor
	{
		class ComprResult
		{
			public string[] Dic;
			public int[] Cont;
			public int Pass;
		}

		/// <summary>
		/// Compress text and return json string.
		/// </summary>
		/// <param name="text"></param>
		/// <returns></returns>
		private string CompressImpl(string text, int currentPass)
		{
			var arr = new Regex("(.+?)\\1+?").SelectSegments(text).Select(o => o.Value).Distinct().ToArray();
			var phrases = arr.OrderByDescending(o => o.Length).Skip(arr.Length > 1 ? 1 : 0).ToArray(); // largest match has to be removed
			int index = 0;
			var phraseIndex = phrases.ToDictionary(o => o, o => index++);
			string strre = phrases.Select(o => "(" + Regex.Escape(o) + ")").ToStringJoined("|");
			var indexesArr = new Regex(strre).SelectSegments(text).Select(o =>
			{
				if(!o.Success && !phraseIndex.ContainsKey(o.Value))
				{
					// if largest match still exists, add it to the dictionary:
					phraseIndex.Add(o.Value, index++);
				}
				return phraseIndex[o.Value];
			}).ToArray();

			var obj = new ComprResult()
			{
				Dic = phraseIndex.Select(o => o.Key).ToArray(),
				Cont = indexesArr,
				Pass = currentPass
			};

			return Calysto.Serialization.Json.JsonSerializer.Serialize(obj);
		}

		/// <summary>
		/// Compress using x passes and return shortest compressed value.
		/// </summary>
		/// <param name="text"></param>
		/// <param name="passesMax"></param>
		/// <returns></returns>
		public string Compress(string text, int passesMax = 2)
		{
			int pass = 0;
			string previousResult = text;
			while(pass <=passesMax)
			{
				string result = CompressImpl(previousResult, pass); // first pass is 0
				if(result.Length > previousResult.Length)
				{
					return previousResult;
				}
				previousResult = result;
				// increase pass and compress again
				pass++;
			}
			return previousResult;
		}

		/// <summary>
		/// Decompress compressed json and returns raw string.
		/// </summary>
		/// <param name="json"></param>
		/// <returns></returns>
		public string Decompress(string json)
		{
			if (!json.Contains("\"Dic\"") || !json.Contains("\"Cont\"") || !json.Contains("\"Pass\""))
			{
				// not compressed
				return json;
			}

			var obj = Calysto.Serialization.Json.JsonSerializer.Deserialize<ComprResult>(json);
			int index = 0;
			var indexPhrase = obj.Dic.ToDictionary(o => index++, o => o);
			string txt = obj.Cont.Select(o => indexPhrase[o]).ToStringJoined();
			if (obj.Pass > 0)
			{
				return Decompress(txt);
			}
			else
			{
				// last pass is 0
				return txt;
			}
		}
	}
}
