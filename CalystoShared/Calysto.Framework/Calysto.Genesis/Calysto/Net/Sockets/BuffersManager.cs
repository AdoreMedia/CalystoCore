using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calysto.Net.Sockets
{
	/// <summary>
	/// Reusable buffers manager.
	/// </summary>
	static class BuffersManager
	{
		// Key: size, Value: Dictionary<...>
		// Key: ArraySegment, Value: true is buffer currently in use, else false
		static Dictionary<int, Dictionary<ArraySegment<byte>, bool>> _buffersList1 = new Dictionary<int, Dictionary<ArraySegment<byte>, bool>>();

		public static ArraySegment<byte> GetAvailableBuffer(int size)
		{
			lock (_buffersList1)
			{
				if (!_buffersList1.TryGetValue(size, out var dic2))
				{
					dic2 = new Dictionary<ArraySegment<byte>, bool>();
					_buffersList1.Add(size, dic2);
				}

				ArraySegment<byte> arr1;

				var kv1 = dic2.Where(kv => !kv.Value).Take(1).ToArray();
				if (kv1.Length == 0)
				{
					arr1 = new ArraySegment<byte>(new byte[size]);
					dic2.Add(arr1, true);
				}
				else
				{
					arr1 = kv1[0].Key;
					dic2[arr1] = true;
				}
				return arr1;
			}
		}

		public static void ReleaseBuffer(ArraySegment<byte> array)
		{
			lock (_buffersList1)
			{
				_buffersList1[array.Array.Length][array] = false;
			}
		}

	}
}
