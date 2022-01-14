namespace LinqToSqlShared.Utility
{
    using System;
	using Resources = SqlMetal.Resources;

	internal static class Strings
    {
        internal static string CouldNotMakeUniqueName(object p0)
        {
            return SR.GetString(Resources.LinqToSqlShared_Utility.CouldNotMakeUniqueName, new object[] { p0 });
        }

        internal static string OwningTeam
        {
            get
            {
                return SR.GetString(Resources.LinqToSqlShared_Utility.OwningTeam);
            }
        }
    }
}

