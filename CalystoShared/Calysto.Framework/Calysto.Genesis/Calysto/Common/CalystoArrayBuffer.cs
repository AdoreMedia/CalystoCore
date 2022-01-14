using System;
using System.Collections.Generic;
using System.Linq;

namespace Calysto.Common
{
	/// <summary>
	/// Thread safe!
	/// Create MemoryStream like wrapper to read multiple arrays. 
	/// Enables searchin for patterns which may extend over multiple arrays (start at the end of one array and finishes at the begining of the next array)
	/// </summary>
	////[DebuggerDisplay("{_debuggerDisplay}")]
	public class CalystoArrayBuffer<TItem> : IDisposable
	{
		public class ItemData : IDisposable
		{
			~ItemData() => this.Dispose();

			public void Dispose()
			{
				this.Buffer = null;
				this.OwnerList?.Remove(this);
				this.OwnerList = null;
			}

			public ItemData(List<ItemData> owner) => this.OwnerList = owner;

			List<ItemData> OwnerList;

			public IEnumerable<ItemData> PreviousNodes(bool includeCurrent = false)
			{
				if (includeCurrent) yield return this;
				foreach (var item in this.OwnerList.TakeWhile(o => o != this).Reverse()) yield return item;
			}

			public IEnumerable<ItemData> NextNodes(bool includeCurrent = false)
			{
				if (includeCurrent) yield return this;
				foreach (var item in this.OwnerList.SkipWhile(o => o != this).Skip(1)) yield return item;
			}

			/// <summary>
			/// Key to link original data with search results.
			/// </summary>
			public int? Key { get; internal set; }

			public TItem[] Buffer { get; internal set; }

			/// <summary>
			/// Cached value of Buffer.LongLength
			/// </summary>
			public long BufferSize { get; internal set; }

			/// <summary>
			/// After buffer is trimmed from start, it doesn't remove data from the byffer start, but set offset start instead.
			/// </summary>
			public long BufferOffsetStart { get; internal set; }

			/// <summary>
			/// Available length in buffer respecting BufferOffsetStart.
			/// </summary>
			public long AvailableBufferLength => this.BufferSize - this.BufferOffsetStart;

			/// <summary>
			/// Absolute start index, respecting BufferOffsetStart and AvailableLength.
			/// </summary>
			public long VirtualStartIndex { get; internal set; }

			/// <summary>
			/// Calculate in runtime. Slow if there is many items.
			/// </summary>
			public long LiveVirtualNextStartIndex => this.VirtualStartIndex + this.BufferSize - this.BufferOffsetStart;

			/// <summary>
			/// Convert absolute position to Relative position in current Buffer. 
			/// If value is negative or greater than VirtualNextIndex, absolutePosition is not inside current node.
			/// </summary>
			/// <param name="absolutePosition"></param>
			/// <returns></returns>
			public long GetRelativePosition(long absolutePosition) => absolutePosition - this.VirtualStartIndex + this.BufferOffsetStart;
		}

		List<ItemData> _list3 = new List<ItemData>();

		~CalystoArrayBuffer()
		{
			this.Dispose();
		}

		public void Dispose()
		{
			this.Clear();
		}

		private void RebuildIndexes()
		{
			long startIndex = 0;
			_list3.ForEach(node =>
			{
				node.VirtualStartIndex = startIndex;
				startIndex += node.AvailableBufferLength;
			});
		}

		/// <summary>
		/// Get node containing data at absolute position.
		/// </summary>
		/// <param name="position"></param>
		/// <returns></returns>
		ItemData GetNodeAtPosition(long position)
		{
			return _list3.SkipWhile(o => o.LiveVirtualNextStartIndex < position).FirstOrDefault();
		}

		public long Position { get; set; }

		/// <summary>
		/// Total length, from position 0 to the end.
		/// </summary>
		public long TotalLength => _list3.Sum(o => (long)o.AvailableBufferLength);

		/// <summary>
		/// Available bytes from current Position to the end.
		/// </summary>
		public long Available => this.TotalLength - this.Position;

		public TItem[] ToArray()
		{
			TItem[] data = new TItem[this.TotalLength];
			foreach (var node in _list3)
			{
				Array.Copy(node.Buffer, node.BufferOffsetStart, data, node.VirtualStartIndex, node.AvailableBufferLength);
			}
			return data;
		}

		/// <summary>
		/// Add data without advancing Position.
		/// </summary>
		/// <param name="data"></param>
		public void Add(TItem[] data, int? key = null)
		{
			ItemData node = new ItemData(_list3) { Buffer = data, Key = key, BufferSize = data?.LongLength ?? 0 };
			_list3.Add(node);

			node.VirtualStartIndex = node.PreviousNodes().FirstOrDefault()?.LiveVirtualNextStartIndex ?? 0;
		}

		/// <summary>
		/// Remove all data and reset position to 0.
		/// </summary>
		public void Clear()
		{
			// on o.Dispose() item is removed from _list3, so we have to invoke .ToList() to run .ForEach() on list copy.
			_list3.ToList().ForEach(o => o.Dispose());
			_list3.Clear();
			this.Position = 0;
		}

		/// <summary>
		/// Remove data in front of current Postion and reset position to 0.
		/// </summary>
		public void TrimStart()
		{
			var node = this.GetNodeAtPosition(this.Position);
			if (node == null)
				return;

			node.BufferOffsetStart = node.GetRelativePosition(this.Position);
			this.Position = 0;

			node.PreviousNodes().ToList().ForEach(m => m.Dispose());

			if (node.AvailableBufferLength == 0)
				node.Dispose();

			this.RebuildIndexes();
		}

		#region Read bytes

		/// <summary>
		/// Read block from current position and take all available but not more than maxLength.
		/// Returns TItem[]
		/// Throw exception if there is not enough data.
		/// </summary>
		/// <param name="exactLength"></param>
		/// <returns></returns>
		public TItem[] Read(long maxLength)
		{
			if (maxLength < 1)
				return new TItem[0];

			long available1 = Math.Min(maxLength, this.Available);
			TItem[] result1 = new TItem[available1];

			long resultPos = 0;
			long positionInBuffer = 0;
			long take1 = 0;

			var node = this.GetNodeAtPosition(this.Position);
			positionInBuffer = node.GetRelativePosition(this.Position);

			while (resultPos < maxLength && node != null)
			{
				if (node.AvailableBufferLength > 0)
				{
					take1 = Math.Min(maxLength - resultPos, node.BufferSize - positionInBuffer);
					
					Array.Copy(node.Buffer, positionInBuffer, result1, resultPos, take1);

					resultPos += take1;
					positionInBuffer += take1;
					this.Position += take1; // advance position by taken count
				}

				if (positionInBuffer >= node.BufferSize)
				{
					node = node.NextNodes().FirstOrDefault();
					if (node != null)
						positionInBuffer = node.BufferOffsetStart;
				}
			}

			return result1;
		}

		/// <summary>
		/// Read block from current position and take length of bytes. Returns bytes[]
		/// Throw exception if there is not enough data.
		/// </summary>
		/// <param name="exactLength"></param>
		/// <returns></returns>
		public TItem[] ReadExactly(long exactLength)
		{
			if (exactLength < 1)
				return new TItem[0];

			long available = this.Available;

			if (exactLength > available)
				throw new ArgumentOutOfRangeException($"Read {exactLength} bytes requested, but available {available} bytes only.");

			return this.Read(exactLength);
		}

		/// <summary>
		/// Read single byte.
		/// Throw exception if there is not enough data.
		/// </summary>
		/// <returns></returns>
		public TItem ReadByte()
		{
			return this.Read(1)[0];
		}

		#endregion

		#region Patterns search

		/// <summary>
		/// Peek sequence from index without advancing Position.
		/// </summary>
		/// <param name="listIndex"></param>
		/// <param name="bufferIndex"></param>
		/// <returns></returns>
		private IEnumerable<TItem> PeekSequence(ItemData node, long bufferStartIndex, bool spreadPatternToNextNode)
		{
			var tmp1 = node;
			TItem[] buffer;
			long bufferLength;
			do
			{
				buffer = tmp1.Buffer;
				bufferLength = tmp1.BufferSize;

				while (bufferStartIndex < bufferLength)
				{
					yield return buffer[bufferStartIndex++];
				}

				bufferStartIndex = 0;
			}
			while (spreadPatternToNextNode && (tmp1 = node.NextNodes().FirstOrDefault()) != null);
		}

		public class SearchResult
		{
			public ItemData Item;
			public long VirtualPatternIndex;
		}

		private IEnumerable<SearchResult> SearchNodesWorker(TItem[] pattern, bool spreadPatternToNextNode, IEnumerable<ItemData> enumerable = null)
		{
			int patternLength = pattern?.Length ?? 0;
			var firstByte = pattern[0];
			long bufferStartIndex = 0;

			if (enumerable == null)
				enumerable = this.GetNodeAtPosition(this.Position)?.NextNodes(true);

			if (enumerable != null)
			{
				foreach (var node in enumerable)
				{
					bufferStartIndex = node.BufferOffsetStart;

					// Array.IndexOf is limited to int.MaxValue, so the segment for search may not be larger also
					if (node.AvailableBufferLength > int.MaxValue)
						throw new Exception("Search is not available for buffers larger than " + int.MaxValue.ToString("n0") + " bytes");

					while (patternLength > 0
						&& node.AvailableBufferLength > 0
						&& bufferStartIndex < node.BufferSize
						&& (bufferStartIndex = Array.IndexOf(node.Buffer, firstByte, (int)bufferStartIndex)) >= 0)
					{
						if (pattern.Length == 1)
						{
							yield return new SearchResult() { VirtualPatternIndex = node.VirtualStartIndex + bufferStartIndex - node.BufferOffsetStart, Item = node };
							bufferStartIndex += 1;
						}
						else if (pattern.SequenceEqual(this.PeekSequence(node, bufferStartIndex, spreadPatternToNextNode).Take(pattern.Length)))
						{
							yield return new SearchResult() { VirtualPatternIndex = node.VirtualStartIndex + bufferStartIndex - node.BufferOffsetStart, Item = node };
							bufferStartIndex += pattern.Length;
						}
						else
						{
							bufferStartIndex += 1;
						}
					}
				}
			}
		}

		private IEnumerable<SearchResult> SearchNodesParallel(TItem[] pattern, bool spreadPatternToNextNode)
		{
			return this.GetNodeAtPosition(this.Position).NextNodes(true)
				.AsParallel()
				.SelectMany(node => this.SearchNodesWorker(pattern, spreadPatternToNextNode, new[] { node }))
				.Where(o => o.VirtualPatternIndex >= this.Position)
				.OrderBy(o => o.VirtualPatternIndex); // required since search is done in multiple threads
		}

		/// <summary>
		/// Search for nodes containing the pattern.
		/// </summary>
		/// <param name="pattern">pattern to search for</param>
		/// <returns></returns>
		public IEnumerable<SearchResult> SearchNodes(TItem[] pattern)
		{
			// since we're not spanning pattern over multiple nodes, we may search each node in it's own thread, it is much faster way
			// Take(x) will be used to optimise query speed it up limiting number of searches
			return this.SearchNodesWorker(pattern, false);
		}

		/// <summary>
		/// Take is added to parallel query so parallel query is optimised for take.
		/// </summary>
		/// <param name="pattern"></param>
		/// <param name="take"></param>
		/// <returns></returns>
		public IEnumerable<SearchResult> SearchNodesParallel(TItem[] pattern)
		{
			// since we're not spanning pattern over multiple nodes, we may search each node in it's own thread, it is much faster way
			// Take(x) will be used to optimise query speed it up limiting number of searches
			return this.SearchNodesParallel(pattern, false);
		}

		/// <summary>
		/// Search for all occurrences of pattern from current Position to the end, which may extend through mutiple buffers.
		/// </summary>
		/// <param name="pattern">pattern to search for</param>
		/// <returns></returns>
		public IEnumerable<long> PatternAt(TItem[] pattern)
		{
			return this.SearchNodesWorker(pattern, true).Select(o => o.VirtualPatternIndex);
		}

		/// <summary>
		/// Take is added to parallel query so parallel query is optimised for take.
		/// </summary>
		/// <param name="pattern"></param>
		/// <param name="take"></param>
		/// <returns></returns>
		public IEnumerable<long> PatternAtParallel(TItem[] pattern)
		{
			// Distinct() is required in parallel since we're spreding pattern search to next node
			return this.SearchNodesParallel(pattern, true).Select(o => o.VirtualPatternIndex).Distinct();
		}

		/// <summary>
		/// Select data segments only, starting from current position, but only if followed by pattern segment. 
		/// Pattern is like end-of-data delimiter. 
		/// Pattern segments are not selected.
		/// </summary>
		/// <param name="source"></param>
		/// <param name="pattern"></param>
		/// <returns></returns>
		public IEnumerable<TItem[]> SelectCompleteSegments(TItem[] endingPattern)
		{
			// select segment and return those ending with pattern segment
			var en1 = this.PatternAt(endingPattern).Where(o => o >= this.Position).ToList().GetEnumerator();
			while (en1.MoveNext())
			{
				int dataLen1 = (int)(en1.Current - this.Position);
				if (dataLen1 > 0)
				{
					yield return this.Read(dataLen1);
				}
				else
				{
					yield return new TItem[0];
				}
				this.Position += endingPattern.Length; //do not change Position
			}
		}

		#endregion

	}
}
