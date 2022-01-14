using System;
using System.Linq;
using System.Text;

namespace Calysto.Utility
{
	public class CalystoBitVector32
	{
		private int data = 0;

		public CalystoBitVector32()
		{
		}

		public CalystoBitVector32(int initialValue)
		{
			this.data = initialValue;
		}

		/// <summary>
		/// Set true or false (1 or 0) at bit position index. The most right bit has index 0.
		/// </summary>
		/// <param name="positionIndex"></param>
		/// <param name="setTrue"></param>
		/// <returns></returns>
		public CalystoBitVector32 Set(int index, bool value)
		{
			int intValue = 1 << index;
			if (value)
			{
				this.data |= intValue;
			}
			else
			{
				this.data &= ~intValue;
			}
			return this;
		}

		public bool Get(int index)
		{
			int intValue = 1 << index;
			return ((this.data & intValue) == intValue);
		}

		/// <summary>
		/// Get or set bit value at positionIndex.
		/// </summary>
		/// <param name="positionIndex"></param>
		/// <returns></returns>
		public bool this[int index]
		{
			get { return Get(index); }
			set { Set(index, value); }
		}

		public int Int32Value
		{
			get { return this.data; }
			set { this.data = value; }
		}

		/// <summary>
		/// Get or set bits string
		/// </summary>
		public string BitsString
		{
			get
			{
				StringBuilder sb = new StringBuilder();
				for(int n = 31; n >= 0; n--)
				{
					sb.Append(this.Get(n) ? 1 : 0);
				}
				return sb.ToString();
			}
			set
			{
				this.data = 0;
				char[] chars = value.Reverse().ToArray();
				if (chars.Length > 32)
				{
					throw new ArgumentOutOfRangeException("value can be 32 chars in length max");
				}
				for (int n = 0; n < chars.Length; n++)
				{
					this.Set(n, chars[n] == '0' ? false : true);
				}
			}
		}
	

	}


}
