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
    
    public partial class tblAppNewsletter
    {
    	/// <summary>
    	/// Column, PrimaryKey, MaxLength(150)
    	/// </summary>
        public string Email { get; set; }
    	/// <summary>
    	/// Column
    	/// </summary>
        public System.DateTime InsertionDate { get; set; }
    	/// <summary>
    	/// Column, Nullable
    	/// </summary>
        public Nullable<System.DateTime> SubscribeDate { get; set; }
    	/// <summary>
    	/// Column, Nullable
    	/// </summary>
        public Nullable<System.DateTime> UnsubscribeDate { get; set; }
    	/// <summary>
    	/// Column
    	/// </summary>
        public bool IsSubscribed { get; set; }
    }
}
