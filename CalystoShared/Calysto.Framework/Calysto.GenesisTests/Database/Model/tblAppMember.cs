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
    
    public partial class tblAppMember
    {
    	/// <summary>
    	/// Column, PrimaryKey
    	/// </summary>
        public int AppMemberID { get; set; }
    	/// <summary>
    	/// Column
    	/// </summary>
        public int AppMemberStatusID { get; set; }
    	/// <summary>
    	/// Column, Nullable, MaxLength(15)
    	/// </summary>
        public string MSISDN { get; set; }
    	/// <summary>
    	/// Column, Nullable, MaxLength(50)
    	/// </summary>
        public string FacebookId { get; set; }
    	/// <summary>
    	/// Column, Nullable, MaxLength(50)
    	/// </summary>
        public string GoogleId { get; set; }
    	/// <summary>
    	/// Column, Nullable, MaxLength(150)
    	/// </summary>
        public string Email { get; set; }
    	/// <summary>
    	/// Column, Nullable, Unicode, MaxLength(50)
    	/// </summary>
        public string Username { get; set; }
    	/// <summary>
    	/// Column, Nullable, Unicode, MaxLength(50)
    	/// </summary>
        public string Password { get; set; }
    	/// <summary>
    	/// Column, Nullable
    	/// </summary>
        public Nullable<System.DateTime> BirthDate { get; set; }
    	/// <summary>
    	/// Column, Nullable
    	/// </summary>
        public Nullable<System.DateTime> CreationDate { get; set; }
    	/// <summary>
    	/// Column, Nullable
    	/// </summary>
        public Nullable<System.DateTime> LastLoginDate { get; set; }
    	/// <summary>
    	/// Column
    	/// </summary>
        public int LoginsCount { get; set; }
    	/// <summary>
    	/// Column, Nullable, Unicode, MaxLength(100)
    	/// </summary>
        public string FirstName { get; set; }
    	/// <summary>
    	/// Column, Nullable, Unicode, MaxLength(100)
    	/// </summary>
        public string LastName { get; set; }
    	/// <summary>
    	/// Column, Nullable, MaxLength(10)
    	/// </summary>
        public string Gender { get; set; }
    	/// <summary>
    	/// Column, Nullable, Unicode, MaxLength(1000)
    	/// </summary>
        public string PersonalNote { get; set; }
    	/// <summary>
    	/// Column, Nullable, MaxLength(255)
    	/// </summary>
        public string WebUrl { get; set; }
    	/// <summary>
    	/// Column, Nullable, Unicode, MaxLength(255)
    	/// </summary>
        public string Address { get; set; }
    	/// <summary>
    	/// Column, Nullable, Unicode, MaxLength(50)
    	/// </summary>
        public string ZipCode { get; set; }
    	/// <summary>
    	/// Column, Nullable, Unicode, MaxLength(250)
    	/// </summary>
        public string City { get; set; }
    	/// <summary>
    	/// Column, Nullable, Unicode, MaxLength(250)
    	/// </summary>
        public string Country { get; set; }
    	/// <summary>
    	/// Column, Nullable, MaxLength(50)
    	/// </summary>
        public string IP { get; set; }
    	/// <summary>
    	/// Column, Nullable
    	/// </summary>
        public Nullable<int> PosFirmaID { get; set; }
    	/// <summary>
    	/// Column, Nullable, Unicode, MaxLength(1000)
    	/// </summary>
        public string ReferentNote { get; set; }
    	/// <summary>
    	/// Column, Nullable
    	/// </summary>
        public Nullable<bool> IsQuizQuestionsEditor { get; set; }
    
    }
}