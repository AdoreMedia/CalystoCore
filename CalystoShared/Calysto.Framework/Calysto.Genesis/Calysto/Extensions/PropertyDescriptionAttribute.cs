using System;

namespace Calysto.Extensions
{
	[AttributeUsage(AttributeTargets.Property)]
	public class PropertyDescriptionAttribute : Attribute
	{
		#region Properties

		/// <summary>
		/// Holds the stringvalue for a value in an enum.
		/// </summary>
		public string Text { get; private set; }

		#endregion

		#region Constructor

		/// <summary>
		/// Constructor used to init a StringValue Attribute
		/// </summary>
		/// <param name="value"></param>
		public PropertyDescriptionAttribute(string value)
		{
			this.Text = value;
		}

		#endregion
	}
}