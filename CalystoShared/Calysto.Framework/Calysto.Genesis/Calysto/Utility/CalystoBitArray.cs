using System;
using System.Linq;
using System.Collections;
using Calysto.Linq;

namespace Calysto.Utility
{
	public class CalystoBitArray
	{
		BitArray data;

		public CalystoBitArray(int length)
		{
			data = new BitArray(length);
		}

		public CalystoBitArray Set(int index, bool value)
		{
			data.Set(index, value);
			return this;
		}

		public bool Get(int index)
		{
			return data.Get(index);
		}

		public bool this[int index]
		{
			get { return this.Get(index); }
			set { this.Set(index, value); }
		}

		/// <summary>
		/// Get or set bits string
		/// </summary>
		public string BitsString
		{
			get { return this.data.Cast<bool>().Reverse().Select(o => o ? 1 : 0).ToStringJoined(); }
			set 
			{
				char[] chars = value.Reverse().ToArray();
				if (chars.Length > data.Length)
				{
					throw new ArgumentOutOfRangeException("value can be " + data.Length + " chars in length max");
				}
				for (int n = 0; n < chars.Length; n++)
				{
					this.Set(n, chars[n] == '0' ? false : true);
				}
			}
		}

		public int Int32Value
		{
			get
			{
				CalystoBitVector32 vec = new CalystoBitVector32();
				this.data.Cast<bool>().Select((bit, index) =>
				{
					vec.Set(index, bit);
					return bit;
				}).ToList();
				return vec.Int32Value;
			}
			set
			{
				this.data = new BitArray(new int[] { value });
			}
		}

	}
}