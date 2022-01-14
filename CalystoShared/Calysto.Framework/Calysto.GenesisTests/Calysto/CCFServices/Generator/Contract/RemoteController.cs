using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace UnitTests.Calysto.CCFServices.Contract
{
	public class RemoteController : IRemoteController, IDisposable
	{
		public RemoteController()
		{
		}

		~RemoteController()
		{
			this.Dispose();
		}

		public bool IsDisposed { get; private set; }

		public void Dispose()
		{
			if (this.IsDisposed) return;
			this.IsDisposed = true;
			// to the rest of disposing here
		}

		public event Action OnConnected;
		public event Action<int, string> OnAgeChanged;
		public event ThreadStart OnThreadStart;
		public event Action<ThreadStart> OnThreadStart2;
		public event Action<int, List<string>> OnListChanged;

		public void MakeListChanged(List<string> list)
		{
			this.OnListChanged?.Invoke(list?.Count ?? 0, list);
		}

		int _age;

		public int TestExceptionThrowing()
		{
			throw new InvalidOperationException("this is exception #1");
		}

		private void RemoteController_OnAgeChanged(int arg1, string arg2)
		{
			throw new NotImplementedException();
		}

		public int GetAge(int height)
		{
			return height + _age;
		}

		public string GetToken()
		{
			return Guid.NewGuid().ToString();
		}

		public Tuple<int, int, int> SumNumbers(int a, int b)
		{
			return new Tuple<int, int, int>(a, b, a + b);
		}

		public int SumNumbers2(int a, int b)
		{
			return a + b;
		}

		public TimeSpan DateDiff(DateTime dt1, DateTime dt2)
		{
			return dt1 - dt2;
		}

		public void SetAge(int age)
		{
			this.OnAgeChanged?.Invoke(age, $"old age: {this._age}, new age: {age}");

			this._age = age;
		}

		public Tuple<int, byte[]> MeasureLength(byte[]data)
		{
			return new Tuple<int, byte[]>(data.Length, data);
		}

		public IEnumerable<int> GetNumbers(int a, int b = 123, int? c = 22, decimal mn = 1.2m, double mk = 52.323, bool? isLight = null, string name1 = "some \"john\" of '2'")
		{
			throw new NotImplementedException();
		}

		public List<List<Tuple<int, string>>> GetTuples(int a, string name, byte[] data, byte[][] doubleArray)
		{
			throw new NotImplementedException();
		}

		public List<List<Tuple<int?[][], double, string>>> GetTuples(int? a, int b, string name, byte[] data, byte[][] doubleArray)
		{
			throw new NotImplementedException();
		}

		public DateTime GetCurrentDateTime()
		{
			return DateTime.Now;
		}

		public int GetNameLength(string name1, int age1) => name1.Length;

		public List<List<Tuple<int, string>>> GetTuples1(int a, string name, byte[] data, byte[][] doubleArray)
		{
			throw new NotImplementedException();
		}

		public List<List<Tuple<int?[][], double, string>>> GetTuples2(int? a, int b, string name, byte[] data, byte[][] doubleArray)
		{
			throw new NotImplementedException();
		}

		public TResult GetSomeResult1<TSource, TResult>(List<TSource> list)
		{
			throw new NotImplementedException();
		}

		public TResult GetSomeResult2<TSource, TResult>(TSource[] list)
		{
			throw new NotImplementedException();
		}

		public List<TResult[]> GetSomeResult3<TSource, TResult>(List<TSource[][]> list, List<TSource[]> list2, List<TResult> list3)
		{
			throw new NotImplementedException();
		}

		byte[] _data;

		public string UploadBinaryData(string name, byte[] data)
		{
			return $"Received {name} of {data.Length} bytes";
		}

		public byte[] DownloadBinaryData()
		{
			return _data;
		}
	}
}
