using System;

namespace Calysto.Common
{
	public class CalystoRandom : Random
	{
		/// <summary>
		/// Create Random instance with random guid seed to make random results realy random.
		/// </summary>
		public CalystoRandom() : base(BitConverter.ToInt32(Guid.NewGuid().ToByteArray(), 0))
		{
		}
	}
}
