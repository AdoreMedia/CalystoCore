using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Calysto.Serialization.Json.Core.Serialization
{
    /// <summary>
    /// Basic deserialize to object structure using dictionaries instead of object
    /// </summary>
    internal class ObjectDeserializer
    {
        private JavaScriptString _jsString;

        public SerializerOptions Options { get; private set; }

        public ObjectDeserializer(SerializerOptions options = null)
        {
            this.Options = options ?? new SerializerOptions();
        }

        public object BasicDeserialize(string input)
        {
            this._jsString = new JavaScriptString(input);

            object obj2 = this.DeserializeInternal(0);
            char? nextNonEmptyChar = this._jsString.GetNextNonEmptyChar();
            int? nullable3 = nextNonEmptyChar.HasValue ? new int?(nextNonEmptyChar.GetValueOrDefault()) : null;
            if (nullable3.HasValue)
            {
                throw new ArgumentException("JSON_IllegalPrimitive: " + input);
            }
            return obj2;
        }

        private void AppendCharToBuilder(char? c, StringBuilder sb)
        {
            if (((c == '"') || (c == '\'')) || (c == '/'))
            {
                sb.Append(c);
            }
            else if (c == 'b')
            {
                sb.Append('\b');
            }
            else if (c == 'f')
            {
                sb.Append('\f');
            }
            else if (c == 'n')
            {
                sb.Append('\n');
            }
            else if (c == 'r')
            {
                sb.Append('\r');
            }
            else if (c == 't')
            {
                sb.Append('\t');
            }
            else
            {
                if (c != 'u')
                {
                    throw new ArgumentException(this._jsString.GetDebugString(AtlasWeb.JSON_BadEscape));
                }
                sb.Append((char) int.Parse(this._jsString.MoveNext(4), NumberStyles.HexNumber, CultureInfo.InvariantCulture));
            }
        }

        private char CheckQuoteChar(char? c)
        {
            if (c == '\'')
            {
                return c.Value;
            }
            if (c != '"')
            {
                throw new ArgumentException(this._jsString.GetDebugString(AtlasWeb.JSON_StringNotQuoted));
            }
            return '"';
        }

        private IDictionary<string, object> DeserializeDictionary(int depth)
        {
            IDictionary<string, object> dictionary = null;
            char? nextNonEmptyChar;
            char? nullable8;
            char? nullable11;
            if (this._jsString.MoveNext() != '{')
            {
                throw new ArgumentException(this._jsString.GetDebugString(AtlasWeb.JSON_ExpectedOpenBrace));
            }
        Label_018D:
            nullable8 = nextNonEmptyChar = this._jsString.GetNextNonEmptyChar();
            int? nullable10 = nullable8.HasValue ? new int?(nullable8.GetValueOrDefault()) : null;
            if (nullable10.HasValue)
            {
                this._jsString.MovePrev();
                if (nextNonEmptyChar == ':')
                {
                    throw new ArgumentException(this._jsString.GetDebugString(AtlasWeb.JSON_InvalidMemberName));
                }
                string str = null;
                if (nextNonEmptyChar != '}')
                {
                    str = this.DeserializeMemberName();
                    if (string.IsNullOrEmpty(str))
                    {
                        throw new ArgumentException(this._jsString.GetDebugString(AtlasWeb.JSON_InvalidMemberName));
                    }
                    if (this._jsString.GetNextNonEmptyChar() != ':')
                    {
                        throw new ArgumentException(this._jsString.GetDebugString(AtlasWeb.JSON_InvalidObject));
                    }
                }
                if (dictionary == null)
                {
                    dictionary = new Dictionary<string, object>();
                    if (string.IsNullOrEmpty(str))
                    {
                        nextNonEmptyChar = this._jsString.GetNextNonEmptyChar();
                        goto Label_01CB;
                    }
                }
                object obj2 = this.DeserializeInternal(depth);
                dictionary[str] = obj2;
                nextNonEmptyChar = this._jsString.GetNextNonEmptyChar();
                if (nextNonEmptyChar != '}')
                {
                    if (nextNonEmptyChar != ',')
                    {
                        throw new ArgumentException(this._jsString.GetDebugString(AtlasWeb.JSON_InvalidObject));
                    }
                    goto Label_018D;
                }
            }
        Label_01CB:
            nullable11 = nextNonEmptyChar;
            if ((nullable11.GetValueOrDefault() != '}') || !nullable11.HasValue)
            {
                throw new ArgumentException(this._jsString.GetDebugString(AtlasWeb.JSON_InvalidObject));
            }
            return dictionary;
        }

        private object DeserializeInternal(int depth)
        {
            if (++depth > this.Options.RecursionLimit)
            {
                throw new ArgumentException(this._jsString.GetDebugString(AtlasWeb.JSON_DepthLimitExceeded));
            }
            char? nextNonEmptyChar = this._jsString.GetNextNonEmptyChar();
            char? nullable2 = nextNonEmptyChar;
            int? nullable4 = nullable2.HasValue ? new int?(nullable2.GetValueOrDefault()) : null;
            if (!nullable4.HasValue)
            {
                return null;
            }

            this._jsString.MovePrev();

            if (IsNextElementObject(nextNonEmptyChar))
            {
                IDictionary<string, object> o = this.DeserializeDictionary(depth);
                return o;
            }
            if (IsNextElementArray(nextNonEmptyChar))
            {
                return this.DeserializeList(depth);
            }
            if (IsNextElementString(nextNonEmptyChar))
            {
                return this.DeserializeString();
            }
            return this.DeserializePrimitiveObject();
        }

        private IList DeserializeList(int depth)
        {
            char? nextNonEmptyChar;
            char? nullable5;
            IList list = new ArrayList();
            if (this._jsString.MoveNext() != '[')
            {
                throw new ArgumentException(this._jsString.GetDebugString(AtlasWeb.JSON_InvalidArrayStart));
            }
            bool flag = false;
        Label_00C4:
            nullable5 = nextNonEmptyChar = this._jsString.GetNextNonEmptyChar();
            int? nullable7 = nullable5.HasValue ? new int?(nullable5.GetValueOrDefault()) : null;
            if (nullable7.HasValue && (nextNonEmptyChar != ']'))
            {
                this._jsString.MovePrev();
                object obj2 = this.DeserializeInternal(depth);
                list.Add(obj2);
                flag = false;
                nextNonEmptyChar = this._jsString.GetNextNonEmptyChar();
                if (nextNonEmptyChar != ']')
                {
                    flag = true;
                    if (nextNonEmptyChar != ',')
                    {
                        throw new ArgumentException(this._jsString.GetDebugString(AtlasWeb.JSON_InvalidArrayExpectComma));
                    }
                    goto Label_00C4;
                }
            }
            if (flag)
            {
                throw new ArgumentException(this._jsString.GetDebugString(AtlasWeb.JSON_InvalidArrayExtraComma));
            }
            if (nextNonEmptyChar != ']')
            {
                throw new ArgumentException(this._jsString.GetDebugString(AtlasWeb.JSON_InvalidArrayEnd));
            }
            return list;
        }

        private string DeserializeMemberName()
        {
            char? nextNonEmptyChar = this._jsString.GetNextNonEmptyChar();
            char? nullable2 = nextNonEmptyChar;
            int? nullable4 = nullable2.HasValue ? new int?(nullable2.GetValueOrDefault()) : null;
            if (!nullable4.HasValue)
            {
                return null;
            }
            this._jsString.MovePrev();
            if (IsNextElementString(nextNonEmptyChar))
            {
                return this.DeserializeString();
            }
            return this.DeserializePrimitiveToken();
        }

        private object DeserializePrimitiveObject()
        {
            double num4;
            string s = this.DeserializePrimitiveToken();
            if (s.Equals("null"))
            {
                return null;
            }
            if (s.Equals("true"))
            {
                return true;
            }
            if (s.Equals("false"))
            {
                return false;
            }
            bool flag = s.IndexOf('.') >= 0;
            if (s.LastIndexOf("e", StringComparison.OrdinalIgnoreCase) < 0)
            {
                decimal num3;
                if (!flag)
                {
                    int num;
                    long num2;
                    if (int.TryParse(s, NumberStyles.Integer, this.Options.Culture, out num))
                    {
                        return num;
                    }
                    if (long.TryParse(s, NumberStyles.Integer, this.Options.Culture, out num2))
                    {
                        return num2;
                    }
                }
                if (decimal.TryParse(s, NumberStyles.Number, this.Options.Culture, out num3))
                {
                    return num3;
                }
            }
            if (!double.TryParse(s, NumberStyles.Float, this.Options.Culture, out num4))
            {
                throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, AtlasWeb.JSON_IllegalPrimitive, new object[] { s }));
            }
            return num4;
        }

        private string DeserializePrimitiveToken()
        {
            char? nullable2;
            StringBuilder builder = new StringBuilder();
            char? nullable = null;
        Label_0066:
            nullable2 = nullable = this._jsString.MoveNext();
            int? nullable4 = nullable2.HasValue ? new int?(nullable2.GetValueOrDefault()) : null;
            if (nullable4.HasValue)
            {
                if ((char.IsLetterOrDigit(nullable.Value) || (nullable.Value == '.')) || (((nullable.Value == '-') || (nullable.Value == '_')) || (nullable.Value == '+')))
                {
                    builder.Append(nullable);
                }
                else
                {
                    this._jsString.MovePrev();
                    goto Label_00A2;
                }
                goto Label_0066;
            }
        Label_00A2:
            return builder.ToString();
        }

        private string DeserializeString()
        {
            StringBuilder sb = new StringBuilder();
            bool flag = false;
            char? c = this._jsString.MoveNext();
            char ch = this.CheckQuoteChar(c);
            while (true)
            {
                char? nullable4 = c = this._jsString.MoveNext();
                int? nullable6 = nullable4.HasValue ? new int?(nullable4.GetValueOrDefault()) : null;
                if (!nullable6.HasValue)
                {
                    throw new ArgumentException(this._jsString.GetDebugString(AtlasWeb.JSON_UnterminatedString));
                }
                if (c == '\\')
                {
                    if (flag)
                    {
                        sb.Append('\\');
                        flag = false;
                    }
                    else
                    {
                        flag = true;
                    }
                }
                else if (flag)
                {
                    this.AppendCharToBuilder(c, sb);
                    flag = false;
                }
                else
                {
                    char? nullable3 = c;
                    int num = ch;
                    if ((nullable3.GetValueOrDefault() == num) && nullable3.HasValue)
                    {
                        return sb.ToString();
                    }
                    sb.Append(c);
                }
            }
        }

        private bool IsNextElementArray(char? c)
        {
            return (c == '[');
        }

        private bool IsNextElementObject(char? c)
        {
            return (c == '{');
        }

        private bool IsNextElementString(char? c)
        {
            return ((c == '"') || (c == '\''));
        }
    }
}

