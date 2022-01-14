using System;
using System.Data;
using System.Globalization;
using System.Xml.Linq;

namespace LinqToSqlShared.Utility
{
	internal static class DbTypeSystem
    {
        internal static Type GetClosestRuntimeType(SqlDbType sqlDbType)
        {
            switch (sqlDbType)
            {
                case SqlDbType.BigInt:
                    return typeof(long);

                case SqlDbType.Binary:
                case SqlDbType.Image:
                case SqlDbType.Timestamp:
                case SqlDbType.VarBinary:
                    return typeof(Binary);

                case SqlDbType.Bit:
                    return typeof(bool);

                case SqlDbType.Char:
                case SqlDbType.NChar:
                case SqlDbType.NText:
                case SqlDbType.NVarChar:
                case SqlDbType.Text:
                case SqlDbType.VarChar:
                    return typeof(string);

                case SqlDbType.DateTime:
                case SqlDbType.SmallDateTime:
                case SqlDbType.Date:
                case SqlDbType.DateTime2:
                    return typeof(DateTime);

                case SqlDbType.Decimal:
                case SqlDbType.Money:
                case SqlDbType.SmallMoney:
                    return typeof(decimal);

                case SqlDbType.Float:
                    return typeof(double);

                case SqlDbType.Int:
                    return typeof(int);

                case SqlDbType.Real:
                    return typeof(float);

                case SqlDbType.UniqueIdentifier:
                    return typeof(Guid);

                case SqlDbType.SmallInt:
                    return typeof(short);

                case SqlDbType.TinyInt:
                    return typeof(byte);

                case SqlDbType.Xml:
                    return typeof(XElement);

                case SqlDbType.Time:
                    return typeof(TimeSpan);

                case SqlDbType.DateTimeOffset:
                    return typeof(DateTimeOffset);
            }
            return typeof(object);
        }

        internal static SqlDbType Parse(string stype)
        {
            stype = stype.ToUpper(CultureInfo.InvariantCulture).Replace("NOT NULL", "");
            stype = stype.ToUpper(CultureInfo.InvariantCulture).Replace("NULL", "");
            string strA = null;
            int index = stype.IndexOf('(');
            int num2 = stype.IndexOf(' ');
            int length = ((index != -1) && (num2 != -1)) ? Math.Min(num2, index) : ((index != -1) ? index : ((num2 != -1) ? num2 : -1));
            if (length == -1)
            {
                strA = stype;
                length = stype.Length;
            }
            else
            {
                strA = stype.Substring(0, length);
            }
            int startIndex = length;
            if ((startIndex < stype.Length) && (stype[startIndex] == '('))
            {
                startIndex++;
                length = stype.IndexOf(',', startIndex);
                if (length > 0)
                {
                    startIndex = length + 1;
                    length = stype.IndexOf(')', startIndex);
                }
                else
                {
                    length = stype.IndexOf(')', startIndex);
                }
                startIndex = length++;
            }
            if (string.Compare(strA, "rowversion", StringComparison.OrdinalIgnoreCase) == 0)
            {
                strA = "Timestamp";
            }
            if (string.Compare(strA, "numeric", StringComparison.OrdinalIgnoreCase) == 0)
            {
                strA = "Decimal";
            }
            if (string.Compare(strA, "sql_variant", StringComparison.OrdinalIgnoreCase) == 0)
            {
                strA = "Variant";
            }
            if (string.Compare(strA, "filestream", StringComparison.OrdinalIgnoreCase) == 0)
            {
                strA = "Binary";
            }
            if (string.Compare(strA, "table", StringComparison.OrdinalIgnoreCase) == 0)
            {
                strA = "Structured";
            }
            SqlDbType type = (SqlDbType) Enum.Parse(typeof(SqlDbType), strA, true);
            switch (type)
            {
                case SqlDbType.Binary:
                case SqlDbType.Char:
                case SqlDbType.NChar:
                case SqlDbType.NVarChar:
                    return type;

                case SqlDbType.Bit:
                case SqlDbType.DateTime:
                case SqlDbType.Image:
                case SqlDbType.Int:
                case SqlDbType.Money:
                case SqlDbType.NText:
                    return type;

                case SqlDbType.Decimal:
                case SqlDbType.Float:
                case SqlDbType.Real:
                    return type;

                case SqlDbType.Timestamp:
                case SqlDbType.TinyInt:
                    return type;

                case SqlDbType.VarBinary:
                case SqlDbType.VarChar:
                    return type;
            }
            return type;
        }
    }
}

