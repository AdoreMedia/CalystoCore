namespace SqlMetal
{
    using System;

    public enum OutputType
    {
        /// <summary>
        /// Read tables, views, procedures and functions names only.
        /// </summary>
        NamesOnly,

        CalystoLinq2SqlCSharp,
        
        CalystoEFCoreFluent,
    }
}

