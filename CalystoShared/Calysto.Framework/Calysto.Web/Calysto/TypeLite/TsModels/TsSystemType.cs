using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Calysto.TypeLite.Extensions;

namespace Calysto.TypeLite.TsModels
{
	/// <summary>
	/// Represents a system type in the code model.
	/// </summary>
	public class TsSystemType : TsType
	{
		/// <summary>
		/// Gets kind of the system type.
		/// </summary>
		public SystemTypeKind Kind { get; private set; }

		/// <summary>
		/// Initializes a new instance of the TsSystemType with the specific CLR type.
		/// </summary>
		/// <param name="type">The CLR type represented by this instance of the TsSystemType.</param>
		public TsSystemType(Type type)
			: base(type)
		{
			switch (this.Type.FullName) // gurufix changed to FullName
			{
				case "Calysto.Web.CalystoBlob": this.Kind = SystemTypeKind.Blob; break; // gurufix: added blob
				case "System.Void": this.Kind = SystemTypeKind.Void;break; // gurufix: added void
				case "System.Boolean": this.Kind = SystemTypeKind.Bool; break;
				case "System.String":
				case "System.Char":
					this.Kind = SystemTypeKind.String; break;
				case "System.Byte":
				case "System.SByte":
				case "System.Int16":
				case "System.Int32":
				case "System.Int64":
				case "System.UInt16":
				case "System.UInt32":
				case "System.UInt64":
				case "System.Single":
				case "System.Double":
				case "System.Decimal":
				case "System.IntPtr":
				case "System.UIntPtr":
					this.Kind = SystemTypeKind.Number; break;
				case "System.DateTime":
				case "System.DateTimeOffset":
					this.Kind = SystemTypeKind.Date; break;
				default:
					throw new ArgumentException(string.Format("The type '{0}' is not supported system type.", type.FullName));
			}
		}
	}
}