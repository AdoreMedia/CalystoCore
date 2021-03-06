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
    
    public partial class tblAppMobileLog
    {
    	/// <summary>
    	/// Column, PrimaryKey
    	/// </summary>
        public System.DateTime ServerDate { get; set; }
    	/// <summary>
    	/// Column, Nullable
    	/// </summary>
        public Nullable<System.DateTime> MobileDate { get; set; }
    	/// <summary>
    	/// Column, Nullable, MaxLength(50)
    	/// </summary>
        public string IMEI { get; set; }
    	/// <summary>
    	/// Column, Nullable, MaxLength(20)
    	/// </summary>
        public string MSISDN { get; set; }
    	/// <summary>
    	/// Column, Nullable
    	/// </summary>
        public Nullable<int> AppMobileLogKindID { get; set; }
    	/// <summary>
    	/// Column, Nullable
    	/// </summary>
        public Nullable<int> AppMemberID { get; set; }
    	/// <summary>
    	/// Column, Nullable, MaxLength(255)
    	/// </summary>
        public string CurrentUrl { get; set; }
    	/// <summary>
    	/// Column, Nullable
    	/// </summary>
        public Nullable<int> RemainingChargePercent { get; set; }
    	/// <summary>
    	/// Column, Nullable, MaxLength(50)
    	/// </summary>
        public string PowerSource { get; set; }
    	/// <summary>
    	/// Column, Nullable, MaxLength(50)
    	/// </summary>
        public string BatteryStatus { get; set; }
    	/// <summary>
    	/// Column, Nullable, MaxLength(50)
    	/// </summary>
        public string SubscriberId { get; set; }
    	/// <summary>
    	/// Column, Nullable, MaxLength(50)
    	/// </summary>
        public string NetworkType { get; set; }
    	/// <summary>
    	/// Column, Nullable, MaxLength(50)
    	/// </summary>
        public string PhoneType { get; set; }
    	/// <summary>
    	/// Column, Nullable, MaxLength(50)
    	/// </summary>
        public string SimState { get; set; }
    	/// <summary>
    	/// Column, Nullable, MaxLength(50)
    	/// </summary>
        public string NetworkOperator { get; set; }
    	/// <summary>
    	/// Column, Nullable
    	/// </summary>
        public Nullable<System.DateTime> LocationDate { get; set; }
    	/// <summary>
    	/// Column, Nullable, MaxLength(200)
    	/// </summary>
        public string LocationError { get; set; }
    	/// <summary>
    	/// Column, Nullable
    	/// </summary>
        public Nullable<double> Latitude { get; set; }
    	/// <summary>
    	/// Column, Nullable
    	/// </summary>
        public Nullable<double> Longitude { get; set; }
    	/// <summary>
    	/// Column, Nullable
    	/// </summary>
        public Nullable<double> AccuracyMeters { get; set; }
    	/// <summary>
    	/// Column, Nullable, Unicode, MaxLength(200)
    	/// </summary>
        public string Address { get; set; }
    

    }
}
