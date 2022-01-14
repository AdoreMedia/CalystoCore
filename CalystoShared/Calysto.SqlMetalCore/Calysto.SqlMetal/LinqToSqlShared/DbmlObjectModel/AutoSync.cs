namespace LinqToSqlShared.DbmlObjectModel
{
    using System;

    internal enum AutoSync
    {
        Default,
        Always,
        Never,
        OnInsert,
        OnUpdate
    }
}

