//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Calysto.Genesis.UnitTests.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblAppMemberPermission
    {
    	/// <summary>
    	/// Column, PrimaryKey
    	/// </summary>
        public int AppPermissionID { get; set; }
    	/// <summary>
    	/// Column, PrimaryKey
    	/// </summary>
        public int AppMemberID { get; set; }
    	/// <summary>
    	/// Column
    	/// </summary>
        public System.DateTime DateInserted { get; set; }
    	/// <summary>
    	/// Column, Nullable
    	/// </summary>
        public Nullable<int> InsertedByAppMemberID { get; set; }
    

    }
}
