namespace SqlMetal
{
	using LinqToSqlShared;
	using System;

    internal static class Strings
    {
        internal static string CouldNotIdentifyPrimaryKeyColumn(object p0, object p1)
        {
            return SR.GetString(Resources.SqlMetal.CouldNotIdentifyPrimaryKeyColumn, new object[] { p0, p1 });
        }

        internal static string CouldNotMakePropertyNameForAssociation(object p0)
        {
            return SR.GetString(Resources.SqlMetal.CouldNotMakePropertyNameForAssociation, new object[] { p0 });
        }

        internal static string EmptyNameError(object p0)
        {
            return SR.GetString(Resources.SqlMetal.EmptyNameError, new object[] { p0 });
        }

        internal static string InputFileDoesNotExist(object p0)
        {
            return SR.GetString(Resources.SqlMetal.InputFileDoesNotExist, new object[] { p0 });
        }

        internal static string InvalidTimeoutFormat(object p0)
        {
            return SR.GetString(Resources.SqlMetal.InvalidTimeoutFormat, new object[] { p0 });
        }

        internal static string OutputFileIOError(object p0)
        {
            return SR.GetString(Resources.SqlMetal.OutputFileIOError, new object[] { p0 });
        }

        internal static string OutputFileNameFormatError(object p0)
        {
            return SR.GetString(Resources.SqlMetal.OutputFileNameFormatError, new object[] { p0 });
        }

        internal static string ProviderNotInstalled(object p0, object p1)
        {
            return SR.GetString(Resources.SqlMetal.ProviderNotInstalled, new object[] { p0, p1 });
        }

        internal static string SprocParameterTypeNotSupported(object p0, object p1, object p2)
        {
            return SR.GetString(Resources.SqlMetal.SprocParameterTypeNotSupported, new object[] { p0, p1, p2 });
        }

        internal static string SprocResultColumnsHaveSameName(object p0, object p1)
        {
            return SR.GetString(Resources.SqlMetal.SprocResultColumnsHaveSameName, new object[] { p0, p1 });
        }

        internal static string SprocResultMultipleAnonymousColumns(object p0)
        {
            return SR.GetString(Resources.SqlMetal.SprocResultMultipleAnonymousColumns, new object[] { p0 });
        }

        internal static string TimeoutMustNotBeNegative(object p0)
        {
            return SR.GetString(Resources.SqlMetal.TimeoutMustNotBeNegative, new object[] { p0 });
        }

        internal static string UnableToExtractColumnBecauseOfUDT(object p0, object p1)
        {
            return SR.GetString(Resources.SqlMetal.UnableToExtractColumnBecauseOfUDT, new object[] { p0, p1 });
        }

        internal static string UnableToExtractFunction(object p0, object p1)
        {
            return SR.GetString(Resources.SqlMetal.UnableToExtractFunction, new object[] { p0, p1 });
        }

        internal static string UnableToExtractSproc(object p0, object p1)
        {
            return SR.GetString(Resources.SqlMetal.UnableToExtractSproc, new object[] { p0, p1 });
        }

        internal static string UnableToExtractTable(object p0, object p1)
        {
            return SR.GetString(Resources.SqlMetal.UnableToExtractTable, new object[] { p0, p1 });
        }

        internal static string UnableToExtractView(object p0, object p1)
        {
            return SR.GetString(Resources.SqlMetal.UnableToExtractView, new object[] { p0, p1 });
        }

        internal static string UnknownLanguage(object p0)
        {
            return SR.GetString(Resources.SqlMetal.UnknownLanguage, new object[] { p0 });
        }

        internal static string UnknownOption(object p0)
        {
            return SR.GetString(Resources.SqlMetal.UnknownOption, new object[] { p0 });
        }

        internal static string UnknownProvider(object p0)
        {
            return SR.GetString(Resources.SqlMetal.UnknownProvider, new object[] { p0 });
        }

        internal static string UnknownSerializationMode(object p0)
        {
            return SR.GetString(Resources.SqlMetal.UnknownSerializationMode, new object[] { p0 });
        }

        internal static string VersionString(object p0, object p1)
        {
            return SR.GetString(Resources.SqlMetal.VersionString, new object[] { p0, p1 });
        }

        internal static string CodeDescription
        {
            get
            {
                return SR.GetString(Resources.SqlMetal.CodeDescription);
            }
        }

        internal static string CodeUsage
        {
            get
            {
                return SR.GetString(Resources.SqlMetal.CodeUsage);
            }
        }

        internal static string ConnectionStringDescription
        {
            get
            {
                return SR.GetString(Resources.SqlMetal.ConnectionStringDescription);
            }
        }

        internal static string ConnectionStringUsage
        {
            get
            {
                return SR.GetString(Resources.SqlMetal.ConnectionStringUsage);
            }
        }

        internal static string ContextDescription
        {
            get
            {
                return SR.GetString(Resources.SqlMetal.ContextDescription);
            }
        }

        internal static string ContextUsage
        {
            get
            {
                return SR.GetString(Resources.SqlMetal.ContextUsage);
            }
        }

        internal static string CopyrightString
        {
            get
            {
                return SR.GetString(Resources.SqlMetal.CopyrightString);
            }
        }

        internal static string DatabaseAndConnectionConflict
        {
            get
            {
                return SR.GetString(Resources.SqlMetal.DatabaseAndConnectionConflict);
            }
        }

        internal static string DatabaseDescription
        {
            get
            {
                return SR.GetString(Resources.SqlMetal.DatabaseDescription);
            }
        }

        internal static string DatabaseIsNotSpecified
        {
            get
            {
                return SR.GetString(Resources.SqlMetal.DatabaseIsNotSpecified);
            }
        }

        internal static string DatabaseUsage
        {
            get
            {
                return SR.GetString(Resources.SqlMetal.DatabaseUsage);
            }
        }

        internal static string DbmlDescription
        {
            get
            {
                return SR.GetString(Resources.SqlMetal.DbmlDescription);
            }
        }

        internal static string DbmlOrCodeNotBoth
        {
            get
            {
                return SR.GetString(Resources.SqlMetal.DbmlOrCodeNotBoth);
            }
        }

        internal static string DbmlOrMapNotBoth
        {
            get
            {
                return SR.GetString(Resources.SqlMetal.DbmlOrMapNotBoth);
            }
        }

        internal static string DbmlUsage
        {
            get
            {
                return SR.GetString(Resources.SqlMetal.DbmlUsage);
            }
        }

        internal static string DirectGenerationDescription
        {
            get
            {
                return SR.GetString(Resources.SqlMetal.DirectGenerationDescription);
            }
        }

        internal static string DirectGenerationExample
        {
            get
            {
                return SR.GetString(Resources.SqlMetal.DirectGenerationExample);
            }
        }

        internal static string EntityBaseDescription
        {
            get
            {
                return SR.GetString(Resources.SqlMetal.EntityBaseDescription);
            }
        }

        internal static string EntityBaseUsage
        {
            get
            {
                return SR.GetString(Resources.SqlMetal.EntityBaseUsage);
            }
        }

        internal static string ExtractDbmlDescription
        {
            get
            {
                return SR.GetString(Resources.SqlMetal.ExtractDbmlDescription);
            }
        }

        internal static string ExtractDbmlExample
        {
            get
            {
                return SR.GetString(Resources.SqlMetal.ExtractDbmlExample);
            }
        }

        internal static string ExtractFromSdfDescription
        {
            get
            {
                return SR.GetString(Resources.SqlMetal.ExtractFromSdfDescription);
            }
        }

        internal static string ExtractFromSdfExample
        {
            get
            {
                return SR.GetString(Resources.SqlMetal.ExtractFromSdfExample);
            }
        }

        internal static string ExtractFromSqlExpressDescription
        {
            get
            {
                return SR.GetString(Resources.SqlMetal.ExtractFromSqlExpressDescription);
            }
        }

        internal static string ExtractFromSqlExpressExample
        {
            get
            {
                return SR.GetString(Resources.SqlMetal.ExtractFromSqlExpressExample);
            }
        }

        internal static string ExtractUsingConnectionStringDescription
        {
            get
            {
                return SR.GetString(Resources.SqlMetal.ExtractUsingConnectionStringDescription);
            }
        }

        internal static string ExtractUsingConnectionStringExample
        {
            get
            {
                return SR.GetString(Resources.SqlMetal.ExtractUsingConnectionStringExample);
            }
        }

        internal static string FunctionDescription
        {
            get
            {
                return SR.GetString(Resources.SqlMetal.FunctionDescription);
            }
        }

        internal static string FunctionsUsage
        {
            get
            {
                return SR.GetString(Resources.SqlMetal.FunctionsUsage);
            }
        }

        internal static string GenerateFromDbmlDescription
        {
            get
            {
                return SR.GetString(Resources.SqlMetal.GenerateFromDbmlDescription);
            }
        }

        internal static string GenerateFromDbmlExample
        {
            get
            {
                return SR.GetString(Resources.SqlMetal.GenerateFromDbmlExample);
            }
        }

        internal static string InputFileDescription
        {
            get
            {
                return SR.GetString(Resources.SqlMetal.InputFileDescription);
            }
        }

        internal static string InputFileUsage
        {
            get
            {
                return SR.GetString(Resources.SqlMetal.InputFileUsage);
            }
        }

        internal static string LanguageDescription
        {
            get
            {
                return SR.GetString(Resources.SqlMetal.LanguageDescription);
            }
        }

        internal static string LanguageUsage
        {
            get
            {
                return SR.GetString(Resources.SqlMetal.LanguageUsage);
            }
        }

        internal static string MapDescription
        {
            get
            {
                return SR.GetString(Resources.SqlMetal.MapDescription);
            }
        }

        internal static string MapUsage
        {
            get
            {
                return SR.GetString(Resources.SqlMetal.MapUsage);
            }
        }

        internal static string MapWithoutCode
        {
            get
            {
                return SR.GetString(Resources.SqlMetal.MapWithoutCode);
            }
        }

        internal static string MultipleInputFiles
        {
            get
            {
                return SR.GetString(Resources.SqlMetal.MultipleInputFiles);
            }
        }

        internal static string NamespaceDescription
        {
            get
            {
                return SR.GetString(Resources.SqlMetal.NamespaceDescription);
            }
        }

        internal static string NamespaceUsage
        {
            get
            {
                return SR.GetString(Resources.SqlMetal.NamespaceUsage);
            }
        }

        internal static string OwningTeam
        {
            get
            {
                return SR.GetString(Resources.SqlMetal.OwningTeam);
            }
        }

        internal static string PasswordAndConnectionConflict
        {
            get
            {
                return SR.GetString(Resources.SqlMetal.PasswordAndConnectionConflict);
            }
        }

        internal static string PasswordDescription
        {
            get
            {
                return SR.GetString(Resources.SqlMetal.PasswordDescription);
            }
        }

        internal static string PasswordUsage
        {
            get
            {
                return SR.GetString(Resources.SqlMetal.PasswordUsage);
            }
        }

        internal static string PluralizeDescription
        {
            get
            {
                return SR.GetString(Resources.SqlMetal.PluralizeDescription);
            }
        }

        internal static string PluralizeUsage
        {
            get
            {
                return SR.GetString(Resources.SqlMetal.PluralizeUsage);
            }
        }

        internal static string ProgramDescription0
        {
            get
            {
                return SR.GetString(Resources.SqlMetal.ProgramDescription0);
            }
        }

        internal static string ProgramDescription1
        {
            get
            {
                return SR.GetString(Resources.SqlMetal.ProgramDescription1);
            }
        }

        internal static string ProgramDescription2
        {
            get
            {
                return SR.GetString(Resources.SqlMetal.ProgramDescription2);
            }
        }

        internal static string ProgramDescription3
        {
            get
            {
                return SR.GetString(Resources.SqlMetal.ProgramDescription3);
            }
        }

        internal static string ProviderDescription
        {
            get
            {
                return SR.GetString(Resources.SqlMetal.ProviderDescription);
            }
        }

        internal static string ProviderUsage
        {
            get
            {
                return SR.GetString(Resources.SqlMetal.ProviderUsage);
            }
        }

        internal static string SerializationDescription
        {
            get
            {
                return SR.GetString(Resources.SqlMetal.SerializationDescription);
            }
        }

        internal static string SerializationUsage
        {
            get
            {
                return SR.GetString(Resources.SqlMetal.SerializationUsage);
            }
        }

        internal static string ServerAndConnectionConflict
        {
            get
            {
                return SR.GetString(Resources.SqlMetal.ServerAndConnectionConflict);
            }
        }

        internal static string ServerDescription
        {
            get
            {
                return SR.GetString(Resources.SqlMetal.ServerDescription);
            }
        }

        internal static string ServerUsage
        {
            get
            {
                return SR.GetString(Resources.SqlMetal.ServerUsage);
            }
        }

        internal static string SprocsDescription
        {
            get
            {
                return SR.GetString(Resources.SqlMetal.SprocsDescription);
            }
        }

        internal static string SprocsUsage
        {
            get
            {
                return SR.GetString(Resources.SqlMetal.SprocsUsage);
            }
        }

        internal static string TimeOutDescription
        {
            get
            {
                return SR.GetString(Resources.SqlMetal.TimeOutDescription);
            }
        }

        internal static string TimeOutUsage
        {
            get
            {
                return SR.GetString(Resources.SqlMetal.TimeOutUsage);
            }
        }

        internal static string UsageHeader
        {
            get
            {
                return SR.GetString(Resources.SqlMetal.UsageHeader);
            }
        }

        internal static string UsageOptions
        {
            get
            {
                return SR.GetString(Resources.SqlMetal.UsageOptions);
            }
        }

        internal static string UserAndConnectionConflict
        {
            get
            {
                return SR.GetString(Resources.SqlMetal.UserAndConnectionConflict);
            }
        }

        internal static string UserDescription
        {
            get
            {
                return SR.GetString(Resources.SqlMetal.UserDescription);
            }
        }

        internal static string UserIsMissing
        {
            get
            {
                return SR.GetString(Resources.SqlMetal.UserIsMissing);
            }
        }

        internal static string UserUsage
        {
            get
            {
                return SR.GetString(Resources.SqlMetal.UserUsage);
            }
        }

        internal static string ViewsDescription
        {
            get
            {
                return SR.GetString(Resources.SqlMetal.ViewsDescription);
            }
        }

        internal static string ViewsUsage
        {
            get
            {
                return SR.GetString(Resources.SqlMetal.ViewsUsage);
            }
        }
    }
}

