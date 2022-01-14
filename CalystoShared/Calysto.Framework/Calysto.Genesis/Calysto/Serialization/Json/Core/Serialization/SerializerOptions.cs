using Calysto.Linq;
using Calysto.Web;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Calysto.Serialization.Json.Core.Serialization
{
	public class BinaryFrameState
	{
		/// <summary>
		/// In or out parameters used with binary frame.
		/// </summary>
		public readonly List<CalystoBlob> Blobs = new List<CalystoBlob>();

		/// <summary>
		/// Output json from binary frame deserialization.
		/// </summary>
		public string Json { get; set; }
	}

	public class FormSerializerState
	{
		List<string> _parentPath = new List<string>();
		public void PushPath(string property)
		{
			_parentPath.Add(property);
		}
		public void PopPath()
		{
			_parentPath.RemoveAt(_parentPath.Count - 1);
		}
		public string CreatePath(string currentProperty)
		{
			return _parentPath.Concat(currentProperty).ToStringJoined(".");
		}
	}

	public class SerializerOptions
	{
		/// <summary>
		/// If true, wil not create property name to json if it's value is null
		/// </summary>
		public bool IgnoreNullValues { get; set; }

		/// <summary>
		/// If true, will add __type$ property to json for correct deserialization
		/// </summary>
		public bool UseTypeName { get; set; }

		public int RecursionLimit { get; set; } = 100;

		public SerializationFormat Format { get; set; } = SerializationFormat.JSON;

		public DateTimeFormat DateFormat { get; set; } = DateTimeFormat.ExtendedObject;

		public bool UseBinaryFrame { get; set; }

		public bool SkipCircularReference { get; set; }

		private CultureInfo _useCulture;
		/// <summary>
		/// get/set Culture for number formating. Default is InvariantCulture.
		/// </summary>
		public CultureInfo Culture
		{
			get => _useCulture ?? CultureInfo.InvariantCulture;
			set => _useCulture = value;
		}

		/// <summary>
		/// Will create dictionary with flat hierarchy. Keys are nested property names. Prop1.Prop2.Prop3
		/// </summary>
		public bool UseFormSerialization { get; set; }

		/// <summary>
		/// If true, will create JavaScript code.
		/// </summary>
		public bool ToJavaScript { get; set; }

		/// <summary>
		/// Output from BinaryFrame serializer.
		/// </summary>
		public readonly BinaryFrameState BFOutput = new BinaryFrameState();

		/// <summary>
		/// Output from FormSerializer.
		/// </summary>
		public readonly FormSerializerState FormState = new FormSerializerState();
	}
}
