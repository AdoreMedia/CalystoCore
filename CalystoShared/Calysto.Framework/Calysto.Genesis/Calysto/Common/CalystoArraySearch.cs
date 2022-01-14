using System;
using System.Collections.Generic;
using System.Linq;

namespace Calysto.Common
{
	public static class CalystoArraySearch
	{
		/// <summary>
		/// Start sequence from index.
		/// </summary>
		/// <param name="listIndex"></param>
		/// <param name="bufferIndex"></param>
		/// <returns></returns>
		private static IEnumerable<byte> PeekSequence(byte[] buffer, int bufferIndex)
		{
			int bufferLength = buffer?.Length ?? 0;

			while (bufferIndex < bufferLength)
			{
				yield return buffer[bufferIndex++];
			}
		}

		/// <summary>
		/// Search from start. Returns indexed positions of all occurrences of pattern.
		/// </summary>
		/// <param name="pattern"></param>
		/// <returns></returns>
		public static IEnumerable<int> PatternAt(byte[] source, byte[] pattern, int startPos = 0)
		{
			byte? firstByte = pattern?.FirstOrDefault();
			int srcLen = source?.Length ?? 0;

			while (firstByte.HasValue && srcLen > 0 && startPos < srcLen && (startPos = Array.IndexOf(source, firstByte, startPos)) >= 0)
			{
				if (pattern.Length == 1)
				{
					yield return startPos;
					startPos += 1;
				}
				else if (pattern.Length > 1 && pattern.SequenceEqual(PeekSequence(source, startPos).Take(pattern.Length)))
				{
					yield return startPos;
					startPos += pattern.Length;
				}
				else
				{
					startPos += 1;
				}
			}
		}

		/// <summary>
		/// Returns first index, or -1 if not found.
		/// </summary>
		/// <param name="source"></param>
		/// <param name="pattern"></param>
		/// <param name="startPos"></param>
		/// <returns></returns>
		public static int IndexOfPattern(byte[] source, byte[] pattern, int startPos = 0)
		{
			var items = PatternAt(source, pattern, startPos).Take(1).ToList();
			if (items.Any())
				return items[0];
			else
				return -1;
		}

		/// <summary>
		/// Read bytes from source and return subarray.
		/// </summary>
		/// <param name="source"></param>
		/// <param name="startIndex"></param>
		/// <param name="length"></param>
		/// <returns></returns>
		public static byte[] ReadBytes(byte[] source, int startIndex, int length)
		{
			byte[] buffer = new byte[length];
			Array.Copy(source, startIndex, buffer, 0, length);
			return buffer;
		}

		/// <summary>
		/// Returns data parts, without pattern.
		/// If there is pattern than pattern found, will return byte[0] as data part, so join with pattern will reproduce the original data.
		/// </summary>
		/// <param name="source"></param>
		/// <param name="pattern"></param>
		/// <returns></returns>
		public static IEnumerable<byte[]> SplitByPattern(byte[] source, byte[] pattern)
		{
			int start1 = 0;
			int len1 = 0;

			foreach(int n1 in PatternAt(source, pattern))
			{
				len1 = n1 - start1;
				if (len1 > 0)
				{
					yield return ReadBytes(source, start1, len1);
				}
				else
				{
					yield return new byte[0];
				}
				start1 = n1 + pattern.Length;
			}

			// if there is more data after the last pattern, yield it also
			if(source.Length > start1)
			{
				yield return ReadBytes(source, start1, source.Length - start1);
			}
			else
			{
				// no more data after last pattern
				yield return new byte[0];
			}
		}

	}
}
