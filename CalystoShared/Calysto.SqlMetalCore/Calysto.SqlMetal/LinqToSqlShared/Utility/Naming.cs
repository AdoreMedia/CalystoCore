namespace LinqToSqlShared.Utility
{
    using LinqToSqlShared.DbmlObjectModel;
    using Microsoft.CSharp;
    using Microsoft.VisualBasic;
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Runtime.CompilerServices;
    using System.Text;

    internal abstract class CodeDomProvider
	{
        public abstract string FileExtension { get; }
        public virtual bool IsValidIdentifier(string name) => true;
    }

    internal class CSharpCodeProvider : CodeDomProvider
	{
        public override string FileExtension => ".cs";
	}

    internal class VBCodeProvider : CodeDomProvider
	{
        public override string FileExtension => ".vb";
    }

    internal static class Naming
    {
        private static CodeDomProvider csharpProvider = new CSharpCodeProvider();
        private const string emptyIdentifierBase = "Name";
        private const int maxGenerationAttempts = 0x270f;
        private const int maxIdentifierLength = 0x80;
        private const int maxNameLength = 120;
        private static string[] vbInvalidKeywords = new string[] { "FROM", "WHERE", "ORDER", "GROUP", "BY", "ASCENDING", "DESCENDING", "DISTINCT" };
        private static CodeDomProvider vbProvider = new VBCodeProvider();

        internal static string CapitalizeFirstLettersOfWords(string name)
        {
            StringBuilder builder = new StringBuilder();
            bool flag = true;
            for (int i = 0; i < name.Length; i++)
            {
                char c = name[i];
                if ((((c >= 'a') && (c <= 'z')) || ((c >= 'A') && (c <= 'Z'))) || (((c >= '0') && (c <= '9')) || (c == '_')))
                {
                    if (flag)
                    {
                        c = char.ToUpper(c, CultureInfo.InvariantCulture);
                    }
                    flag = false;
                    builder.Append(c);
                }
                else
                {
                    flag = true;
                    builder.Append(c);
                }
            }
            name = builder.ToString();
            return name;
        }

        private static StringBuilder EscapeCSKeyword(string name)
        {
            return new StringBuilder("@" + name);
        }

        private static StringBuilder EscapeVBKeyword(string name)
        {
            return new StringBuilder("[" + name + "]");
        }

        private static string GetLanguageExtension(CodeDomProvider codeProvider)
        {
            if (codeProvider == null)
            {
                return string.Empty;
            }
            string str = "." + codeProvider.FileExtension;
            if (str.StartsWith("..", StringComparison.OrdinalIgnoreCase))
            {
                str = str.Substring(1);
            }
            return str;
        }

        internal static string GetUniqueName(string candidateLegalLanguageName, Predicate<string> isUniquename)
        {
            string str = candidateLegalLanguageName;
            for (int i = 1; i < 0x3e8; i++)
            {
                candidateLegalLanguageName = str + i;
                if (isUniquename(candidateLegalLanguageName))
                {
                    return candidateLegalLanguageName;
                }
            }
            throw LinqToSqlShared.Utility.Error.CouldNotMakeUniqueName(candidateLegalLanguageName);
        }

        internal static string GetUniqueParameterName(Function f, string suggestedName)
        {
            Predicate<string> isUniquename = s => IsUniqueParameterName(s, f);
            return GetUniqueName(suggestedName, isUniquename);
        }

        internal static string GetUniqueTableMemberName(Table table, string suggestedName)
        {
            Predicate<string> isUniquename = s => IsUniqueTableClassMemberName(s, table);
            return GetUniqueName(suggestedName, isUniquename);
        }

        internal static bool IsSameName(string name1, string name2)
        {
            if ((name1 == null) || (name2 == null))
            {
                return false;
            }
            return name1.ToLower() == name2.ToLower();
        }

        internal static bool IsUniqueParameterName(string legalLanguageName, Function f)
        {
            return !MatchingParameterNameExists(legalLanguageName, f);
        }

        internal static bool IsUniqueTableClassMemberName(string legalLanguageName, Table table)
        {
            if (IsSameName(table.Type.TypeName, legalLanguageName))
            {
                return false;
            }
            return (!MatchingColumnMemberExists(legalLanguageName, table) && !MatchingAssociationMemberExists(legalLanguageName, table));
        }

        internal static bool IsValidIdentifierLangDependent(string name, CodeDomProvider provider)
        {
            if (!IsValidIdentifierLangIndependent(name))
            {
                return false;
            }
            if (IsVbCodeDomProvider(provider) && StringUtil.ListContains(vbInvalidKeywords, name, true))
            {
                return false;
            }
            return provider.IsValidIdentifier(name);
        }

        internal static bool IsValidIdentifierLangIndependent(string name)
        {
            return IsValidIdentifierLangIndependentInternal(name);
        }

        private static bool IsValidIdentifierLangIndependentInternal(string name)
        {
            if (string.IsNullOrEmpty(name) || (name.Length > 120))
            {
                return false;
            }
            if (!IsValidIdentifierStart(name[0]))
            {
                return false;
            }
            for (int i = 1; i < name.Length; i++)
            {
                if (!IsValidIdentifierRest(name[i]))
                {
                    return false;
                }
            }
            return true;
        }

        private static bool IsValidIdentifierRest(char c)
        {
            if (!char.IsLetterOrDigit(c) && (c != '_'))
            {
                UnicodeCategory unicodeCategory = char.GetUnicodeCategory(c);
                if ((unicodeCategory != UnicodeCategory.ConnectorPunctuation) && (unicodeCategory != UnicodeCategory.NonSpacingMark))
                {
                    return (unicodeCategory == UnicodeCategory.SpacingCombiningMark);
                }
            }
            return true;
        }

        private static bool IsValidIdentifierStart(char c)
        {
            if (!char.IsLetter(c))
            {
                return (c == '_');
            }
            return true;
        }

        private static bool IsVbCodeDomProvider(CodeDomProvider codeProvider)
        {
            return StringUtil.EqualValue(GetLanguageExtension(codeProvider), ".vb");
        }

        private static bool IsVowel(char c)
        {
            switch (c)
            {
                case 'O':
                case 'U':
                case 'Y':
                case 'A':
                case 'E':
                case 'I':
                case 'o':
                case 'u':
                case 'y':
                case 'a':
                case 'e':
                case 'i':
                    return true;
            }
            return false;
        }

        private static string LegalizeCSharpKeywords(string name)
        {
            CodeDomProvider provider = new CSharpCodeProvider();
            if (!provider.IsValidIdentifier(name))
            {
                name = EscapeCSKeyword(name).ToString();
            }
            return name;
        }

        internal static string LegalizeKeyword(string name, CodeDomProvider provider)
        {
            if (name == null)
            {
                return null;
            }
            if (provider.GetType() == typeof(CSharpCodeProvider))
            {
                return LegalizeCSharpKeywords(name);
            }
            return LegalizeVBKeywords(name);
        }

        private static string LegalizeVBKeywords(string name)
        {
            CodeDomProvider provider = new VBCodeProvider();
            if ((Array.IndexOf<string>(vbInvalidKeywords, name.ToUpper(CultureInfo.InvariantCulture)) >= 0) || !provider.IsValidIdentifier(name))
            {
                name = EscapeVBKeyword(name).ToString();
            }
            return name;
        }

        internal static string MakeCSharpLegalName(StringBuilder name)
        {
            return MakeValidIdentifierLangDependent(name, csharpProvider).ToString();
        }

        internal static StringBuilder MakeLegalNameLangIndependent(StringBuilder name)
        {
            return MakeValidIdentifier(name, s => IsValidIdentifierLangIndependentInternal(s.ToString()), null);
        }

        internal static string MakePluralName(string name)
        {
            if ((name.EndsWith("x", StringComparison.OrdinalIgnoreCase) || name.EndsWith("ch", StringComparison.OrdinalIgnoreCase)) || (name.EndsWith("ss", StringComparison.OrdinalIgnoreCase) || name.EndsWith("sh", StringComparison.OrdinalIgnoreCase)))
            {
                name = name + "es";
                return name;
            }
            if ((name.EndsWith("y", StringComparison.OrdinalIgnoreCase) && (name.Length > 1)) && !IsVowel(name[name.Length - 2]))
            {
                name = name.Remove(name.Length - 1, 1);
                name = name + "ies";
                return name;
            }
            if (!name.EndsWith("s", StringComparison.OrdinalIgnoreCase))
            {
                name = name + "s";
            }
            return name;
        }

        internal static string MakeSingularName(string name)
        {
            if (string.Compare(name, "series", StringComparison.OrdinalIgnoreCase) != 0)
            {
                if (string.Compare(name, "wines", StringComparison.OrdinalIgnoreCase) == 0)
                {
                    return name.Remove(name.Length - 1, 1);
                }
                if ((name.Length > 3) && name.EndsWith("ies", StringComparison.OrdinalIgnoreCase))
                {
                    if (!IsVowel(name[name.Length - 4]))
                    {
                        name = name.Remove(name.Length - 3, 3);
                        name = name + 'y';
                    }
                    return name;
                }
                if (name.EndsWith("ees", StringComparison.OrdinalIgnoreCase))
                {
                    name = name.Remove(name.Length - 1, 1);
                    return name;
                }
                if ((name.EndsWith("ches", StringComparison.OrdinalIgnoreCase) || name.EndsWith("xes", StringComparison.OrdinalIgnoreCase)) || name.EndsWith("sses", StringComparison.OrdinalIgnoreCase))
                {
                    name = name.Remove(name.Length - 2, 2);
                    return name;
                }
                if (string.Compare(name, "gas", StringComparison.OrdinalIgnoreCase) == 0)
                {
                    return name;
                }
                if (((name.Length > 1) && name.EndsWith("s", StringComparison.OrdinalIgnoreCase)) && (!name.EndsWith("ss", StringComparison.OrdinalIgnoreCase) && !name.EndsWith("us", StringComparison.OrdinalIgnoreCase)))
                {
                    name = name.Remove(name.Length - 1, 1);
                }
            }
            return name;
        }

        private static StringBuilder MakeValidIdentifier(StringBuilder name, IsValidDelegate IsValidId, CodeDomProvider provider)
        {
            if (name.Length > 120)
            {
                name.Remove(120, name.Length - 120);
            }
            if (IsValidId(name))
            {
                return name;
            }
            name.Replace(" ", "");
            name.Replace("(", "");
            name.Replace(")", "");
            if (!IsValidId(name))
            {
                if (!IsValidIdentifierStart(name[0]))
                {
                    if (IsValidIdentifierRest(name[0]))
                    {
                        name.Insert(0, "_");
                    }
                    else
                    {
                        name.Replace(name[0], '_', 0, 1);
                    }
                }
                for (int i = 1; i < name.Length; i++)
                {
                    if (!IsValidIdentifierRest(name[i]))
                    {
                        name.Replace(name[i], '_');
                    }
                }
            }
            if (IsValidId(name))
            {
                return name;
            }
            if (provider == null)
            {
                name.Append('_');
                return name;
            }
            if (IsVbCodeDomProvider(provider))
            {
                return EscapeVBKeyword(name.ToString());
            }
            return EscapeCSKeyword(name.ToString());
        }

        private static StringBuilder MakeValidIdentifierLangDependent(StringBuilder name, CodeDomProvider codeProvider)
        {
            return MakeValidIdentifier(name, s => IsValidIdentifierLangDependent(s.ToString(), codeProvider), codeProvider);
        }

        internal static string MakeVBLegalName(StringBuilder name)
        {
            return MakeValidIdentifierLangDependent(name, vbProvider).ToString();
        }

        internal static bool MatchingAssociationMemberExists(string legalLanguageName, Table table)
        {
            return table.Type.Associations.Exists(a => IsSameName(a.Member, legalLanguageName));
        }

        internal static bool MatchingColumnMemberExists(string legalLanguageName, Table table)
        {
            return table.Type.Columns.Exists(c => IsSameName(c.Member, legalLanguageName) || ((c.Member == null) && IsSameName(c.Name, legalLanguageName)));
        }

        internal static bool MatchingParameterNameExists(string legalLanguageName, Function f)
        {
            return f.Parameters.Exists(p => IsSameName(p.ParameterName, legalLanguageName));
        }

        private delegate bool IsValidDelegate(StringBuilder name);

        private static class StringUtil
        {
            internal static bool EqualValue(string str1, string str2)
            {
                return EqualValue(str1, str2, false);
            }

            private static bool EqualValue(string str1, string str2, bool caseInsensitive)
            {
                if (str1 == null)
                {
                    throw LinqToSqlShared.Utility.Error.ArgumentNull("str1");
                }
                if (str2 == null)
                {
                    throw LinqToSqlShared.Utility.Error.ArgumentNull("str2");
                }
                if (caseInsensitive)
                {
                    return (string.Compare(str1, str2, StringComparison.OrdinalIgnoreCase) == 0);
                }
                return (string.Compare(str1, str2, StringComparison.Ordinal) == 0);
            }

            internal static bool ListContains(IEnumerable<string> array, string value, bool caseInsensitive)
            {
                foreach (string str in array)
                {
                    if (EqualValue(str, value, caseInsensitive))
                    {
                        return true;
                    }
                }
                return false;
            }
        }
    }
}

