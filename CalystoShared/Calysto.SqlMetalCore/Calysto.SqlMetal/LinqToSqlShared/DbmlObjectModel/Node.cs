namespace LinqToSqlShared.DbmlObjectModel
{
    using System;

    internal abstract class Node
    {
        protected Node()
        {
        }

        protected static string KeyValue<T>(string key, T value)
        {
            if (value != null)
            {
                return (key + "=" + value.ToString() + " ");
            }
            return string.Empty;
        }

        protected static string SingleValue<T>(T value)
        {
            if (value != null)
            {
                return (value.ToString() + " ");
            }
            return string.Empty;
        }

        protected static string GetFullName(string schema, string name)
        {
            if (string.IsNullOrEmpty(schema))
            {
                return name;
            }
            return schema + "." + name;
        }
    }
}

