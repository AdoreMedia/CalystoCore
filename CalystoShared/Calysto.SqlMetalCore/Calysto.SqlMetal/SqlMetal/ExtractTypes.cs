namespace SqlMetal
{
    using System;

    [Flags]
    public enum ExtractTypes
    {
        Functions = 1,
        Relationships = 1<<1,
        StoredProcedures = 1<<2,
        Tables = 1<<3,
        Views = 1<<4,
        All = 255,

    }
}

