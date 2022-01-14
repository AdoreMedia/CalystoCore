using Calysto.Common.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calysto.SqlMetal.CalystoGenerator.CalystoEFCoreFluent
{
	class EFUtility
	{
		public static Type GetTypeFromTypeName(string typeName)
		{
			typeName = typeName.Replace(" ", "");

			Type tt = Type.GetType(typeName);
			if (tt != null) return tt;

			if (typeName == "void") return typeof(void);
			if (typeName == "bool") return typeof(bool);
			if (typeName == "bool?") return typeof(bool?);
			if (typeName == "int") return typeof(int);
			if (typeName == "int?") return typeof(int?);
			if (typeName == "long") return typeof(long);
			if (typeName == "long?") return typeof(long?);
			if (typeName == "double") return typeof(double);
			if (typeName == "double?") return typeof(double?);
			if (typeName == "float") return typeof(float);
			if (typeName == "float?") return typeof(float?);
			if (typeName == "decimal") return typeof(decimal);
			if (typeName == "decimal?") return typeof(decimal?);
			if (typeName == "byte") return typeof(byte);
			if (typeName == "byte?") return typeof(byte?);
			if (typeName == "byte[]") return typeof(byte[]);
			if (typeName == "DateTime") return typeof(DateTime);

			return null;
		}

		private static string GetSimplifiedTypeName(string fullTypeName)
		{
			if (fullTypeName.StartsWith("System.Collections.Generic.")) return fullTypeName.Substring("System.Collections.Generic.".Length);
			else if (fullTypeName == typeof(void).FullName) return "void";
			else if (fullTypeName == typeof(bool).FullName) return "bool";
			else if (fullTypeName == typeof(int).FullName) return "int";
			else if (fullTypeName == typeof(long).FullName) return "long";
			else if (fullTypeName == typeof(double).FullName) return "double";
			else if (fullTypeName == typeof(decimal).FullName) return "decimal";
			else if (fullTypeName == typeof(float).FullName) return "double";
			else if (fullTypeName == typeof(string).FullName) return "string";
			else if (fullTypeName == typeof(byte).FullName) return "byte";
			else if (fullTypeName == typeof(char).FullName) return "char";
			else if (fullTypeName == typeof(object).FullName) return "object";
			else if (fullTypeName == typeof(byte[]).FullName) return "byte[]";
			else if (fullTypeName == typeof(DateTime).FullName) return "DateTime";
			else
				return fullTypeName;
		}

		public static string GetColumnType(string type, bool? canBeNull)
		{
			if (type == "System.Data.Linq.Binary" || type == "Calysto.Data.Linq.Binary" || type == "LinqToSqlShared.Utility.Binary")
			{
				return GetSimplifiedTypeName("System.Byte[]");
			}
			else if (!canBeNull.GetValueOrDefault() || type == "System.String" || type == "System.Byte[]" || type == "object")
			{
				return GetSimplifiedTypeName(type);
			}
			else
			{
				// nullable type
				Type type1 = Type.GetType(type);
				if(type1 == null)
				{
					// it is user type
					return type;
				}
				Type type2 = Nullable.GetUnderlyingType(type1) ?? type1;
				string str1 = GetSimplifiedTypeName(type2.FullName);
				if (type2.IsValueType)
					return str1 + "?";
				else
					return str1;
			}
		}

		#region C# reserverd keywords
		const string _csharpKeywords = @"
abstract
as
base
bool
break
byte
case
catch
char
checked
class
const
continue
decimal
default
delegate
do
double
else
enum
event
explicit
extern
false
finally
fixed
float
for
foreach
goto
if
implicit
in
in
int
interface
internal
is
lock
long
namespace
new
null
object
operator
out
out
override
params
private
protected
public
readonly
ref
return
sbyte
sealed
short
sizeof
stackalloc
static
string
struct
switch
this
throw
true
try
typeof
uint
ulong
unchecked
unsafe
ushort
using
virtual
void
volatile
while
";

		#endregion

		static Dictionary<string, string> _dicReservedKeywords = _csharpKeywords.Split('\r', '\n').Select(o => o.Trim()).Where(o => !string.IsNullOrWhiteSpace(o)).Distinct().ToDictionary(o => o);

		public static string GetCSharpValidName(string member)
		{
			if (_dicReservedKeywords.ContainsKey(member))
			{
				return "@" + member;
			}
			return member;
		}

		public static List<ColumnData> CreateColumnData(LinqToSqlShared.DbmlObjectModel.Type type)
		{
			return type.Columns.Select((o, n) => new ColumnData()
			{
				item = o,
				index = n,
				typeString = EFUtility.GetColumnType(o.PropertyType, o.CanBeNull)
			}).ToList();
		}
	}
}
