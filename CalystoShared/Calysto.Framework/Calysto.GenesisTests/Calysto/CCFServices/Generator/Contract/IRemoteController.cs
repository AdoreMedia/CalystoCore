using System;
using System.Collections.Generic;
using System.Threading;

namespace UnitTests.Calysto.CCFServices.Contract
{
	public interface IRemoteController
	{
		TimeSpan DateDiff(DateTime dt1, DateTime dt2);
		int GetAge(int height);
		string GetToken();
		System.Collections.Generic.List<System.Collections.Generic.List<Tuple<int, string>>> GetTuples1(int a, string name, byte[] data, byte[][] doubleArray);
		System.Collections.Generic.List<System.Collections.Generic.List<Tuple<int?[][], double, string>>> GetTuples2(int? a, int b, string name, byte[] data, byte[][] doubleArray);
		Tuple<int, byte[]> MeasureLength(byte[] data);
		void SetAge(int age);
		Tuple<int, int, int> SumNumbers(int a, int b);
		int SumNumbers2(int a, int b);
		DateTime GetCurrentDateTime();
		System.Collections.Generic.IEnumerable<int> GetNumbers(int a, int b = 123, int? c = 22, decimal mn = 123.52m, double mk = 52.323, bool? isLight = null, string name1 = @"so me ""john"" of '2'
	new line with tabs	a	a
another");
		int TestExceptionThrowing();

		int GetNameLength(string name1, int age1);
		
		void MakeListChanged(List<string> list);

		TResult GetSomeResult1<TSource, TResult>(List<TSource> list);
		
		TResult GetSomeResult2<TSource, TResult>(TSource[] list);
		
		List<TResult[]> GetSomeResult3<TSource, TResult>(List<TSource[][]> list, List<TSource[]> list2, List<TResult> list3);
		string UploadBinaryData(string name, byte[] data);
		byte[] DownloadBinaryData();

		event Action OnConnected;

		event Action<int, string> OnAgeChanged;

		event ThreadStart OnThreadStart;

		event Action<ThreadStart> OnThreadStart2;

		event Action<int, List<string>> OnListChanged;

	}
}