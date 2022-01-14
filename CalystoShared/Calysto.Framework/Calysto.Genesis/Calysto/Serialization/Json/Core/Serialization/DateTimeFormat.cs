using System;
using System.Collections.Generic;
using System.Text;

namespace Calysto.Serialization.Json.Core.Serialization
{
	public enum DateTimeFormat
	{
		/// <summary>
		/// Default. Create object with propety __calystotype=Calysto_Date
		/// </summary>
		ExtendedObject,

		/// <summary>
		/// Serialize to new Date("yyyy-MM-ddTHH:mm:ss.ffffff")
		/// </summary>
		ISOTDateTime

	}
}
