using System;
using System.Collections.Generic;
using Calysto.Linq;
using System.Collections;
using System.Globalization;
using System.Text;
using Calysto.Serialization.Json.Core.Serialization;
using Calysto.Common;
using Calysto.Common.Extensions;

namespace Calysto.Serialization.Json.Core.Converters
{
	/// <summary>
	/// <para>the main idea is to show the same date and time as it was on server, but if client browser is in different time zone, time zone will not be correct.</para>
	/// <para>on server use local time and get local ticks, send local ticks to client</para>
	/// <para>on client create Date() JS object and adjust time zone so the time and date will be exatctly the same as on server, only time zone on client may be different</para>
	/// <para>, this is not absolutely correct, but this way we have exactly the same time and date on client and server, but we have to keep in mind that client's time zone may be different</para>
	/// </summary>
	internal class DateTimeConverter : IJavaScriptConverter
	{
		const string __calystotype = "Calysto_Date";

		public const string _ISOTdateTimeFormat = "yyyy-MM-ddTHH:mm:ss.ffffff";

		class JsonDateTime
		{
			public string __calystotype { get { return DateTimeConverter.__calystotype; } }
			public string Date { get; set; }
		}

		public bool TryConvert(object obj, Type toType, SerializerOptions options, out object result)
		{
			if (toType == typeof(DateTime) && obj is string && options.DateFormat == DateTimeFormat.ISOTDateTime) 
			{
				// converting from pure string, eg. 25.12.2015.
				result = DateTimeExtensions.ParseISOTDateTimeString((string)obj);
				return true;
			}
			else if (obj is IDictionary<string, object> dic) // converting from Calysto_Date
			{
				if (dic.TryGetValue("__calystotype", out var key) && object.Equals(key, __calystotype))
				{
					if(dic.TryGetValue("Date", out object val1))
					{
						////if(DateTime.TryParseExact((string)val1, _ISOTdateTimeFormat, null, DateTimeStyles.None, out DateTime res1))
						// can not parse exact because browser send ### milliseconds, so parse exact throws exception
						if(DateTime.TryParse((string)val1, out DateTime res1))
						{
							result = res1;
							return true;
						}
					}

					throw new NotSupportedException("Can not convert " + obj + " into DateTime");
				}
			}
		
			result = null;
			return false;
		}

		public bool TrySerialize(object obj, StringBuilder sb, SerializerOptions options)
		{
			if (obj?.GetType() != typeof(DateTime))
				return false;

			DateTime datetime = (DateTime)obj;

			// when datetime loaded from database, it is unspecified. 
			if (datetime.Kind == DateTimeKind.Utc)
			{
				// if Kind = Unspecified, it is Local time, no time zone adjustment is made
				datetime = datetime.ToLocalTime();
			}

			if (options.DateFormat == DateTimeFormat.ISOTDateTime)
			{
				string str2 = datetime.ToISOTDateTimeString();
				string str3 = JsonSerializer.Serialize(str2);

				if (options.Format == SerializationFormat.JavaScript)
				{
					sb.Append("new Date(");
					sb.Append(str3);
					sb.Append(")");
				}
				else if (options.Format == SerializationFormat.JSON)
					sb.Append(str3);
				else
					throw new NotSupportedException();

				return true;
			}

			if (options.Format == SerializationFormat.JavaScript)
			{
				sb.Append("fnJsonPostConvertObj2(");
			}

			string json1 = JsonSerializer.Serialize(new JsonDateTime()
			{
				Date = datetime.ToString(_ISOTdateTimeFormat)
			});
			sb.Append(json1);

			if (options.Format == SerializationFormat.JavaScript)
			{
				sb.Append(")");
			}

			return true;
		}
	}

}
