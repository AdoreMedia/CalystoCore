namespace Calysto.Utility
{
	class ComprResult
	{
		// string[] dictionary with phrases
		public Dic: string[];
		// int[] indexes of phrases
		public Cont: string[];
		// int current pass
		public Pass: number = -1;
	}

	export class StringCompressor
	{
		private CompressImpl(text: string, currentPass: number)
		{
			/// <summary>
			/// 
			/// </summary>
			/// <param name="text" type="string"></param>
			/// <param name="currentPass" type="int"></param>
			
			var arr = new Calysto.Regex("(.+?)\\1+?").SelectSegments(text).Select(function (o) { return o.Value }).Distinct().ToList();
			// largest match has to be removed
			var phrases = arr.OrderByDescending(function (o) { return o.length }).Skip(arr.Take(2).Count() > 1 ? 1 : 0).ToList(); 
			var index = 0;
			var phraseIndex = phrases.AsEnumerable().ToDictionary(function (o) { return o }, function (o) { return index++ }).ToRawObject(true);
			var strre = phrases.AsEnumerable().Select(function (o) { return "(" + RegExp.Escape(o) + ")" }).ToStringJoined("|");

			var indexesArr = new Calysto.Regex(strre).SelectSegments(text).Select(function (o)
			{
				if (!o.Success && !phraseIndex[o.Value])
				{
					// if largest match still exists, add it to the dictionary:
					phraseIndex[o.Value] = index++;
					phrases.Add(o.Value);
				}
				return phraseIndex[o.Value];
			}).ToArray();

			var obj: ComprResult = {
				Dic: phrases.ToArray(),
				Cont: indexesArr,
				Pass: currentPass
			};

			return Calysto.Json.Serialize(obj);
		}

		public Compress(text: string, passesMax?: number)
		{
			/// <summary>
			/// Compress using x passes and return shortest compressed value.
			/// </summary>
			/// <param name="text" type="String"></param>
			/// <param name="passesMax" type="Number"></param>
			/// <returns type=""></returns>
			if (arguments.length < 2) passesMax = 1;
			var pass = 0;
			var previousResult = text;
			while (pass <= <number>passesMax)
			{
				var result = this.CompressImpl(previousResult, pass); // first pass is 0
				if (result.length > previousResult.length)
				{
					// if first pass comppressed is larget than original, return uncompressed
					return previousResult;
				}
				previousResult = result;
				// increase pass and compress again
				pass++;
			}
			return previousResult;
		}

		public Decompress(json:string) : string
		{
			/// <summary>
			/// Decompress compressed json and returns raw string.
			/// </summary>
			/// <param name="json" type="String"></param>
			
			if(!json.Contains("\"Dic\"") || !json.Contains("\"Cont\"") || !json.Contains("\"Pass\""))
			{
				// not compressed
				return json;
			}

			var obj = Calysto.Json.Deserialize<ComprResult>(json);

			var index = 0;
			var indexPhrase = obj.Dic.AsEnumerable().ToDictionary(function (o) { return "n" + (index++) }, function (o) { return o }).ToRawObject(true);
			var txt = obj.Cont.AsEnumerable().Select(function (o) { return indexPhrase["n" + o] }).ToStringJoined();
			if (obj.Pass > 0)
			{
				return this.Decompress(txt);
			}
			else
			{
				// last pass is 0
				return txt;
			}
		}
	}
}