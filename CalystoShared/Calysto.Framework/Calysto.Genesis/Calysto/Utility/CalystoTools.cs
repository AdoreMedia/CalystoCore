using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Collections;
using System.Threading;
using Calysto.Threading;
using Calysto.Common;
using Calysto.Genesis.EnvDTE;
using System.Reflection;

namespace Calysto.Utility
{
	public static class CalystoTools
	{
		public static bool IsDebugDefined { get; set; }

		public static bool IsTddSpecific { get; set; }

		static CalystoTools()
		{
#if DEBUG
			IsDebugDefined = true;
#endif

#if TDDSPECIFIC
			IsTddSpecific = true;
#endif
		}

		#region IsLocalMachine

		private static bool? _isLocalMachine;
		/// <summary>
		/// Return true if file exists.
		/// </summary>
		public static bool IsLocalMachine => _isLocalMachine ?? (_isLocalMachine = File.Exists(EnvDTECalystoGenesis.ProjectPath)).GetValueOrDefault();

		#endregion

		#region IsDotNetCore
		/*
	 * .NET:
		typeof(object).AssemblyQualifiedName
		"System.Object, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"

		Core:
		typeof(object).AssemblyQualifiedName
		"System.Object, System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e"
	*/

		private static bool? _isDotNetCore;

		public static bool IsDotNetCore => _isDotNetCore ?? (_isDotNetCore = ResolveIsDotNetCore()) ?? false;

		private static bool ResolveIsDotNetCore()
		{
			if (typeof(object).AssemblyQualifiedName.StartsWith("System.Object, System.Private.CoreLib"))
				return true;
			else if (typeof(object).AssemblyQualifiedName.StartsWith("System.Object, mscorlib"))
				return false;
			else
				throw new NotSupportedException(); // radi sigurnosti, ako se nesto promijeni da ne postoji nikakav podatak
		}

		#endregion

		#region IsUnitTest

		/*
		.NET Framework Environment.CommandLine:
		"\"C:\\Program Files (x86)\\Microsoft Visual Studio\\2019\\Enterprise\\Common7\\IDE\\Extensions\\TestPlatform\\Extensions\\..//testhost.x86.exe\"  --port 16446 --endpoint 127.0.0.1:016446 --role client --parentprocessid 19572 --telemetryoptedin true"

		.NET Core 3.1 Environment.CommandLine:
		"C:\\LOCAL\\VSPROJECTS\\packages\\microsoft.testplatform.testhost\\16.5.0\\build\\netcoreapp2.1\\x64\\testhost.x86.dll --port 34749 --endpoint 127.0.0.1:034749 --role client --parentprocessid 248 --telemetryoptedin true"
		*/

		private static bool IsUnitTestWorker()
		{
			if (Regex.Match(System.Environment.CommandLine, "[\\\\]TestPlatform[\\\\][\\S]+?testhost.[\\w]+?.exe").Success)
			{
				return true; // .NET Framework
			}
			else if (Regex.Match(System.Environment.CommandLine, "[\\\\](netcoreapp|netstandard|net)[\\d\\.]+[\\w\\W]+?testhost[\\.\\w]+dll").Success)
			{
				return true; // .NET Core or .NET Standard
			}
			else
			{
				return false;
			}
		}

		private static bool? _isUnitTest;

		public static bool IsUnitTest => _isUnitTest ?? (_isUnitTest = IsLocalMachine && IsUnitTestWorker()) ?? false;

		#endregion

		#region Project location resolver

		/// <summary>
		/// Search for .csproj file in ancestors directories.
		/// </summary>
		/// <param name="startDirectory"></param>
		/// <returns></returns>
		/// <exception cref="FileNotFoundException"></exception>
		public static FileInfo FindProjectFileInfo(string startDirectory)
		{
			DirectoryInfo dd2 = new DirectoryInfo(startDirectory);
			int loops1 = 0;
			while (loops1++ < 5 && dd2 != null)
			{
				FileInfo[] files = dd2.GetFiles("*.csproj");
				if (files.Any())
				{
					return files.First();
				}
				dd2 = dd2.Parent;
			}
			throw new FileNotFoundException("*.csproj");
		}

		/// <summary>
		/// Search for .csproj file in ancestors directories.
		/// </summary>
		/// <param name="assembly"></param>
		/// <returns></returns>
		/// <exception cref="FileNotFoundException"></exception>
		public static FileInfo FindProjectFileInfo(Assembly assembly = null)
		{
			assembly = assembly ?? Assembly.GetExecutingAssembly();
			string dir1 = Path.GetDirectoryName(assembly.Location);
			return FindProjectFileInfo(dir1);
		}

		#endregion

		#region string quote / dequote

		public static string QuoteString(string str)
		{
			return "\"" + str + "\"";
		}

		public static string DequoteString(string str)
		{
			if (string.IsNullOrEmpty(str))
				return str;

			if (str.StartsWith("\""))
				str = str.Substring(1);

			if (str.EndsWith("\""))
				str = str.Remove(str.Length - 1);

			return str;
		}

		#endregion

		#region Javascript tools

		private static string GetJavaScriptTypeNameWorker(object obj)
		{
			Type tt;
			bool isArray = false;
			bool isList = false;
			bool isNullable = false;

			if (obj == null)
			{
				return "null";
			}
			else if (obj is String)
			{
				return (string)obj;
			}
			else if (obj is Type)
			{
				tt = (Type)obj;
			}
			else
			{
				tt = obj.GetType();
			}


			Type elementType = null;

			if ((elementType = tt.GetElementType()) != null)
			{
				isArray = true;
				tt = elementType;
			}
			else if (tt.IsGenericType && tt.GetInterfaces().Contains(typeof(IEnumerable)) && (elementType = tt.GetGenericArguments().FirstOrDefault()) != null)
			{
				isList = true;
				tt = elementType;
			}

			Type under = System.Nullable.GetUnderlyingType(tt);

			if (under != null)
			{
				tt = under;
				isNullable = true;
			}

			StringBuilder sb = new StringBuilder();
			sb.Append(tt.FullName.Replace("+", "."));

			if (isNullable)
			{
				sb.Append("_Nullable");
			}

			if (isArray)
			{
				sb.Append("_Array");
			}

			if (isList)
			{
				sb.Append("_List");
			}

			return sb.ToString();
		}

		/// <summary>
		/// Get Javascript qualified type name, replace + with .
		/// </summary>
		/// <param name="obj"></param>
		/// <param name="useShortNames">if true, replace System.String with string, System.Int32 with int, System.Boolean with bool</param>
		/// <returns></returns>
		public static string GetJavaScriptTypeName(object obj)
		{
			string ss = GetJavaScriptTypeNameWorker(obj)
				.Replace("+", ".")
				.Replace("System.Byte[]", "ArrayBuffer");

			if (ss.Contains("[") || ss.Contains("]"))
			{
				return "[]";
			}
			return ss;
		}

		#endregion

		#region String tools

		/// <summary>
		/// trim string, if string is null or empty, returns null, else return string
		/// </summary>
		/// <param name="str"></param>
		/// <returns></returns>
		public static string StringOrNullIfEmpty(string str)
		{
			if (string.IsNullOrEmpty(str))
			{
				return null;
			}

			str = str.Trim();

			if (string.IsNullOrEmpty(str))
			{
				return null;
			}
			else
			{
				return str;
			}
		}

		//static string _utfHeader = "" + (char)0xEF + (char)0xBB + (char)0xBF;
		// utf header char num value: 65279

		public static string RemoveUtfHeader(string str)
		{
			while (!string.IsNullOrEmpty(str) && str[0] > 6000)
			{
				str = str.Substring(1);
			}

			return str;
		}

		/// <summary>
		/// Shorten text to maxChars size including elipsis. If minChars >= 0, cut on word boundry, else cut string anywhere at exact maxChars size.
		/// </summary>
		/// <param name="str"></param>
		/// <param name="maxChars"></param>
		/// <param name="minChars"></param>
		/// <param name="elipsis"></param>
		/// <returns></returns>
		public static string ShortenText(string str, int maxChars, int? minChars = null, string elipsis = "...")
		{
			if (string.IsNullOrEmpty(str) || maxChars < 0 || str.Length <= maxChars)
			{
				return str;
			}

			int elipsisLength = !string.IsNullOrEmpty(elipsis) ? elipsis.Length : 0;
			if (maxChars <= elipsisLength)
			{
				throw new Exception("maxChars can't be less then elipsis length");
			}

			maxChars -= elipsisLength; // maxChars = chars + elipsis

			// if minChars is defined, cut on word, else just cut anywhere
			if (minChars == null)
			{
				return str.Remove(maxChars - 1) + elipsis;
			}

			for (int index = maxChars - 1; index >= minChars.GetValueOrDefault(); index--)
			{
				if (!char.IsLetterOrDigit(str, index))
				{
					// can cut here
					return str.Remove(index) + elipsis;
				}
			}

			// if comes here, index = 0, string was not cut, non letter or digit was not found, cut string at maxchars
			return str.Remove(maxChars) + elipsis;
		}

		public static string CapitalizeFirstLetter(string str)
		{
			if (string.IsNullOrEmpty(str))
			{
				return str;
			}

			return str.Substring(0, 1).ToUpper() + str.Substring(1);
		}

		public static string TrimNonWords(string str, bool trimStart, bool trimEnd)
		{
			if (string.IsNullOrEmpty(str))
			{
				return str;
			}

			if (trimStart && trimEnd)
			{
				return new Regex("(^[^\\w]+)|([^\\w]+$)").Replace(str, "");
			}

			if (trimStart)
			{
				return new Regex("(^[^\\w]+)").Replace(str, "");
			}

			if (trimEnd)
			{
				return new Regex("([^\\w]+$)").Replace(str, "");
			}

			throw new ArgumentOutOfRangeException("trimStart or trimEnd has to be true");
		}

		/// <summary>
		/// Replace multiple spaces with replacement
		/// </summary>
		/// <param name="str"></param>
		/// <param name="replacement"></param>
		/// <returns></returns>
		public static string ReplaceWhiteSpaces(string str, string replacement)
		{
			return new Regex("[\\s]+").Replace(str ?? "", replacement);
		}

		public static string ConvertToGoogleMapDecimal(decimal? value)
		{
			if (value == null)
			{
				return "null";
			}
			return value.Value.ToString("N14", CultureInfo.InvariantCulture.NumberFormat);
		}

		#endregion

		/// <summary>
		/// Adjust directory left and right separator slashes to directorySeparator or current Path.DirectorySeparatorChar
		/// </summary>
		/// <param name="path"></param>
		/// <param name="directorySeparator"></param>
		/// <returns></returns>
		public static string NormalizeDirectorySeparatorChar(string path, char? directorySeparator = default)
		{
			if (string.IsNullOrEmpty(path))
				return path;

			directorySeparator = directorySeparator ?? Path.DirectorySeparatorChar;

			string str1 = path.Replace('/', directorySeparator.Value)
				.Replace('\\', directorySeparator.Value);

			// replace multiple backslashes with single one
			str1 = Regex.Replace(str1, "[\\\\]{2,}", "\\");

			// replace multiple forwardslashes with single one
			str1 = Regex.Replace(str1, "[/]{2,}", "/");

			return str1;
		}

		/// <summary>
		/// Make sure directory ends with directory separator char
		/// </summary>
		/// <param name="path"></param>
		/// <returns></returns>
		public static string EnsureEndingDirectorySeparatorChar(string path)
		{
			if (string.IsNullOrEmpty(path))
				return path;

			if (!path.EndsWith(Path.DirectorySeparatorChar.ToString()))
				return path + Path.DirectorySeparatorChar;
			else
				return path;
		}

		public static decimal? ParseGoogleMapDecimal(string num)
		{
			if (string.IsNullOrEmpty(num))
			{
				return null;
			}
			decimal result;
			if (decimal.TryParse(num, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out result))
			{
				return result;
			}
			return null;
		}

		public static string FormatCroDateTime(DateTime? date, bool addDate, bool addTime)
		{
			if (date == null)
			{
				return null;
			}
			else if (addDate && addTime)
			{
				return date.GetValueOrDefault().ToString("dd.MM.yyyy. HH:mm:ss");
			}
			else if (addTime)
			{
				return date.GetValueOrDefault().ToString("HH:mm:ss");
			}
			else if (addDate)
			{
				return date.GetValueOrDefault().ToString("dd.MM.yyyy.");
			}
			else
			{
				return null;
			}
		}

		public static T GetPropertyValue<T>(object item, string propertyName)
		{
			object obj = item.GetType().GetProperty(propertyName).GetValue(item, null);
			return CalystoTypeConverter.ChangeType<T>(obj);
		}

		public static T GetFieldValue<T>(object item, string fieldName)
		{
			object obj = item.GetType().GetField(fieldName).GetValue(item);
			return CalystoTypeConverter.ChangeType<T>(obj);
		}


		/// <summary>
		/// returns first non-null argument
		/// </summary>
		/// <param name="args"></param>
		public static object Coalesce(params object[] args)
		{
			if (args != null)
			{
				foreach (object o in args)
				{
					if (o != null)
					{
						return o;
					}
				}
			}
			return null;
		}

		/// <summary>
		/// returns first non-null argument
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="args"></param>
		/// <returns></returns>
		public static T Coalesce<T>(params T[] args)
		{
			if (args != null)
			{
				foreach (T o in args)
				{
					if (o != null)
					{
						return o;
					}
				}
			}
			return default(T);
		}

		#region Calysto specific IP to number and number to IP

		public static string IPAddressFromNumber(long ipAddress)
		{
			// BitConverter.GetBytes() returns little-endian
			// use BitConverter.IsLittleEndian to test
			byte[] arr1 = BitConverter.GetBytes(ipAddress);
			// convert to big-endian
			byte[] arr2 = arr1.Take(4).Reverse().ToArray();
			// Calysto specific, the same code is used in TypeScript
			return new IPAddress(arr2).ToString();
		}

		public static long IPAddressToNumber(string ip)
		{
			// Calysto specific, the same code is used in TypeScript
			// .GetAddressBytes() returns big-endian bytes
			return IPAddress.Parse(ip).GetAddressBytes().Reverse<byte>().Select((val, index) => val * (long)Math.Pow(256, index)).Sum();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ipv4">x:x:x:x</param>
		/// <returns></returns>
		public static bool IsValidIPv4Address(string ipv4)
		{
			return Regex.IsMatch(ipv4 ?? "", "^[\\d]+[\\.][\\d]+[\\.][\\d]+[\\.][\\d]+$");
		}

		#endregion

		#region long to bytes and back

		/// <summary>
		/// the same as BitConverter.GetBytes(), we need implementation in JavaScript
		/// </summary>
		/// <param name="longNum"></param>
		/// <param name="truncateEmptyBytes"></param>
		/// <returns></returns>
		public static byte[] LongToByteArray(int longNum, bool truncateEmptyBytes = false)
		{
			return LongToByteArray((long)longNum, truncateEmptyBytes);
		}

		/// <summary>
		/// the same as BitConverter.GetBytes(), we need implementation in JavaScript
		/// </summary>
		/// <param name="longNum"></param>
		/// <param name="truncateEmptyBytes"></param>
		/// <returns></returns>
		public static byte[] LongToByteArray(long longNum, bool truncateEmptyBytes = false)
		{
			/// <summary>
			/// LSB is first
			/// </summary>
			/// <param name="long" type="type"></param>
			/// <param name="truncateEmptyBytes" type="Boolean" optional="true">if true, will truncate unused bytes</param>
			/// <returns type=""></returns>
			// we want to represent the input as a n-bytes array
			if (!(longNum > 0 || longNum == 0))
				throw new Exception("LongToByteArray argument may not be negative");

			List<byte> byteArray = new List<byte>();
			for (int index = 0; index < 8; index++)
			{
				byte b1 = (byte)(longNum & 0xff);
				if (truncateEmptyBytes && Math.Pow(2, index * 8) > longNum)
				{
					if (b1 > 0 || byteArray.Count == 0) byteArray.Add(b1);
					break;
				}
				else
				{
					byteArray.Add(b1);
					longNum = (longNum - b1) / 256;
				}
			}

			return byteArray.ToArray();
		}

		/// <summary>
		/// the same as BitConverter.ToInt64(), we need implementation in JavaScript
		/// </summary>
		/// <param name="byteArray"></param>
		/// <returns></returns>
		public static long ByteArrayToLong(byte[] byteArray)
		{
			/// <summary>
			/// LSB is first
			/// </summary>
			/// <param name="byteArray" type="type"></param>
			/// <returns type=""></returns>
			long value = 0;
			for (var index = byteArray.Length - 1; index >= 0; index--)
			{
				value = (value * 256) + byteArray[index];
			}

			return value;
		}

		#endregion

		#region e-mail regex

		// official e-mail regex, missing underscore!!!!
		// private static Regex mEmailRegex = new Regex(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$");

		//Calysto.Validate.IsEmail("myname@mfsd"), // not e-mail
		//Calysto.Validate.IsEmail("myname@mfsd.com"), // valid email
		//Calysto.Validate.IsEmail("myname.me@mfsd"), // not email
		//Calysto.Validate.IsEmail("myname.me@mfsd.com"), // valid email

		public static bool IsEmailValid(string email)
		{
			return new Regex(CalystoConstants.EmailRegexPattern).Match(email ?? "").Success;
		}

		#endregion

		/// <summary>
		/// Run action with timeout defined. Block calling thread until the action is completed. Throw exception if timeouted or any other exception occures in worker method.
		/// </summary>
		/// <typeparam name="TResult"></typeparam>
		/// <param name="timeoutMs"></param>
		/// <param name="func"></param>
		/// <returns></returns>
		public static TResult RunTimedAction<TResult>(int? timeoutMs, Func<TResult> func)
		{
			if (!(timeoutMs.GetValueOrDefault() > 0))
			{
				// run without timer
				return func.Invoke();
			}

			Thread curr1 = Thread.CurrentThread;
			CultureInfo culture1 = CultureInfo.CurrentCulture;
			CultureInfo uiCulture1 = CultureInfo.CurrentUICulture;

			Exception lastex = null;
			TResult res = default(TResult);

			Thread thr = null;
			thr = new Thread(() =>
			{
				try
				{
					thr.CurrentCulture = culture1;
					thr.CurrentUICulture = uiCulture1;

					res = func.Invoke();
				}
				catch (Exception ex)
				{
					lastex = ex;
				}
			});

			thr.StartBackground();

			if (!thr.Join(timeoutMs.Value))
			{
				try { thr.Abort(); } catch { } // jer u core-u nije podrzan thread.Abort()

				throw new TimeoutException();
			}
			else if (lastex != null)
			{
				throw lastex;
			}
			else
			{
				return res;
			}
		}

		/// <summary>
		/// Run action with timeout defined. Block calling thread until the action is completed. Throw exception if timeouted or any other exception occures in worker method.
		/// </summary>
		/// <typeparam name="TResult"></typeparam>
		/// <param name="timeoutMs"></param>
		/// <param name="action"></param>
		public static void RunTimedAction(int? timeoutMs, Action action)
		{
			RunTimedAction(timeoutMs, () =>
			{
				action.Invoke();
				return true;
			});
		}

		public static Thread RunTimedActionAsync(int? timeoutMs, Action action, Action<Exception> onError)
		{
			return new Thread(() =>
			{
				try
				{
					RunTimedAction(timeoutMs, action);
				}
				catch (Exception ex)
				{
					onError.Invoke(ex);
				}
			}).StartBackground();
		}

		/// <summary>
		/// Run action. If exception is thrown, will retry up to retryCnt times.
		/// </summary>
		/// <typeparam name="TResult"></typeparam>
		/// <param name="retryCnt"></param>
		/// <param name="func"></param>
		/// <returns></returns>
		public static TResult RunWithRetry<TResult>(int? retryCnt, Func<TResult> func)
		{
			Exception lastex = null;
			TResult res = default(TResult);
			int runCnt = 0;

			while (runCnt++ <= retryCnt.GetValueOrDefault())
			{
				try
				{
					res = func.Invoke();
					break;
				}
				catch (Exception ex)
				{
					lastex = ex;
				}
			}

			if (lastex != null)
			{
				throw lastex;
			}
			else
			{
				return res;
			}
		}

		/// <summary>
		/// Run action. If exception is thrown, will retry up to retryCnt times.
		/// </summary>
		/// <typeparam name="TResult"></typeparam>
		/// <param name="timeoutMs"></param>
		/// <param name="action"></param>
		public static void RunWithRetry(int? retryCnt, Action action)
		{
			RunWithRetry(retryCnt, () =>
			{
				action.Invoke();
				return true;
			});
		}

		/// <summary>
		/// Returns true if file content is updated.
		/// </summary>
		/// <param name="filePath"></param>
		/// <param name="newContent"></param>
		/// <returns></returns>
		public static bool WriteFileIfChanged(string filePath, string newContent)
		{
			string prev1 = File.Exists(filePath) ? File.ReadAllText(filePath, Encoding.UTF8) : null;
			if (prev1 != newContent)
			{
				File.WriteAllText(filePath, newContent, Encoding.UTF8);
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}
