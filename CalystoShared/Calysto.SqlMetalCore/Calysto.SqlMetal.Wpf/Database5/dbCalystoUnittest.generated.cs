#pragma warning disable 1591
//************************************************************
// Generated using CalystoLinqToSQLGenerator - CalystoSqlMetal
//************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using Calysto.Data.Linq;
using Calysto.Data.Linq.Mapping;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Calysto.SqlMetal.Win.Database
{
	[DatabaseAttribute(Name="dbCalystoUnittest")]
	public partial class dbCalystoUnittestDataContext : Calysto.Data.Linq.DataContext
	{
		private static MappingSource mappingSource = new AttributeMappingSource();

		#region Extensibility Method Definitions
		partial void OnCreated();
		#endregion Extensibility Method Definitions

		#region Context constructors

		public dbCalystoUnittestDataContext(string connection) : base(connection, mappingSource)
		{
			OnCreated();
		}

		public dbCalystoUnittestDataContext(IDbConnection connection) : base(connection, mappingSource)
		{
			OnCreated();
		}

		public dbCalystoUnittestDataContext(string connection, MappingSource mappingSource) : base(connection, mappingSource)
		{
			OnCreated();
		}

		public dbCalystoUnittestDataContext(IDbConnection connection, MappingSource mappingSource) : base(connection, mappingSource)
		{
			OnCreated();
		}
		#endregion Context constructors

		#region Context properties for tables
		public Calysto.Data.Linq.Table<tblAppMember> tblAppMember { get { return this.GetTable<tblAppMember>(); } }
		public Calysto.Data.Linq.Table<tblAppMemberAssignedPermission> tblAppMemberAssignedPermission { get { return this.GetTable<tblAppMemberAssignedPermission>(); } }
		public Calysto.Data.Linq.Table<tblAppPermission> tblAppPermission { get { return this.GetTable<tblAppPermission>(); } }
		#endregion Context properties for tables

		#region Context database functions
		#endregion Context database functions

	}

	#region Entity Tables

		#region dbo.tblAppMember
		[TableAttribute(Name="dbo.tblAppMember")]
		public partial class tblAppMember : EntityBase<tblAppMember, dbCalystoUnittestDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private int _AppMemberID;
			private int _AppMemberStatusID;
			private string _MSISDN;
			private string _FacebookId;
			private string _GoogleId;
			private string _Email;
			private string _Username;
			private string _Password;
			private DateTime? _BirthDate;
			private DateTime? _CreationDate;
			private DateTime? _LastLoginDate;
			private int _LoginsCount;
			private string _FirstName;
			private string _LastName;
			private string _Gender;
			private string _PersonalNote;
			private string _WebUrl;
			private string _Address;
			private string _ZipCode;
			private string _City;
			private string _Country;
			private string _IP;
			private int? _PosFirmaID;
			private bool? _IsQuizQuestionsEditor;
			private decimal? _StanjeRacuna;
			private int? _HomeMemberAddressID;
			private int? _WorkMemberAddressID;
			private int? _PrimaryMemberAddressID;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnAppMemberIDChanging(int value);
			partial void OnAppMemberIDChanged();
			partial void OnAppMemberStatusIDChanging(int value);
			partial void OnAppMemberStatusIDChanged();
			partial void OnMSISDNChanging(string value);
			partial void OnMSISDNChanged();
			partial void OnFacebookIdChanging(string value);
			partial void OnFacebookIdChanged();
			partial void OnGoogleIdChanging(string value);
			partial void OnGoogleIdChanged();
			partial void OnEmailChanging(string value);
			partial void OnEmailChanged();
			partial void OnUsernameChanging(string value);
			partial void OnUsernameChanged();
			partial void OnPasswordChanging(string value);
			partial void OnPasswordChanged();
			partial void OnBirthDateChanging(DateTime? value);
			partial void OnBirthDateChanged();
			partial void OnCreationDateChanging(DateTime? value);
			partial void OnCreationDateChanged();
			partial void OnLastLoginDateChanging(DateTime? value);
			partial void OnLastLoginDateChanged();
			partial void OnLoginsCountChanging(int value);
			partial void OnLoginsCountChanged();
			partial void OnFirstNameChanging(string value);
			partial void OnFirstNameChanged();
			partial void OnLastNameChanging(string value);
			partial void OnLastNameChanged();
			partial void OnGenderChanging(string value);
			partial void OnGenderChanged();
			partial void OnPersonalNoteChanging(string value);
			partial void OnPersonalNoteChanged();
			partial void OnWebUrlChanging(string value);
			partial void OnWebUrlChanged();
			partial void OnAddressChanging(string value);
			partial void OnAddressChanged();
			partial void OnZipCodeChanging(string value);
			partial void OnZipCodeChanged();
			partial void OnCityChanging(string value);
			partial void OnCityChanged();
			partial void OnCountryChanging(string value);
			partial void OnCountryChanged();
			partial void OnIPChanging(string value);
			partial void OnIPChanged();
			partial void OnPosFirmaIDChanging(int? value);
			partial void OnPosFirmaIDChanged();
			partial void OnIsQuizQuestionsEditorChanging(bool? value);
			partial void OnIsQuizQuestionsEditorChanged();
			partial void OnStanjeRacunaChanging(decimal? value);
			partial void OnStanjeRacunaChanged();
			partial void OnHomeMemberAddressIDChanging(int? value);
			partial void OnHomeMemberAddressIDChanged();
			partial void OnWorkMemberAddressIDChanging(int? value);
			partial void OnWorkMemberAddressIDChanged();
			partial void OnPrimaryMemberAddressIDChanging(int? value);
			partial void OnPrimaryMemberAddressIDChanged();
			#endregion

			public tblAppMember()
			{
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=Int NOT NULL IDENTITY
			/// </summary>
			[ColumnAttribute(Storage="_AppMemberID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", CanBeNull=false, IsPrimaryKey=true, IsDbGenerated=true)]
			public int AppMemberID
			{
				get
				{
					return this._AppMemberID;
				}
				set
				{
					if (this._AppMemberID != value)
					{
						this.OnAppMemberIDChanging(value);
						this.SendPropertyChanging();
						this._AppMemberID = value;
						this.SendPropertyChanged("AppMemberID");
						this.OnAppMemberIDChanged();
					}
					this.SendPropertySetterInvoked("AppMemberID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_AppMemberStatusID", DbType="Int NOT NULL", CanBeNull=false)]
			public int AppMemberStatusID
			{
				get
				{
					return this._AppMemberStatusID;
				}
				set
				{
					if (this._AppMemberStatusID != value)
					{
						this.OnAppMemberStatusIDChanging(value);
						this.SendPropertyChanging();
						this._AppMemberStatusID = value;
						this.SendPropertyChanged("AppMemberStatusID");
						this.OnAppMemberStatusIDChanged();
					}
					this.SendPropertySetterInvoked("AppMemberStatusID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=VarChar(15)
			/// </summary>
			[ColumnAttribute(Storage="_MSISDN", DbType="VarChar(15)", CanBeNull=true)]
			public string MSISDN
			{
				get
				{
					return this._MSISDN;
				}
				set
				{
					if (this._MSISDN != value)
					{
						this.OnMSISDNChanging(value);
						this.SendPropertyChanging();
						this._MSISDN = value;
						this.SendPropertyChanged("MSISDN");
						this.OnMSISDNChanged();
					}
					this.SendPropertySetterInvoked("MSISDN", value);
				}
			}
			
			/// <summary>
			/// Column DbType=VarChar(50)
			/// </summary>
			[ColumnAttribute(Storage="_FacebookId", DbType="VarChar(50)", CanBeNull=true)]
			public string FacebookId
			{
				get
				{
					return this._FacebookId;
				}
				set
				{
					if (this._FacebookId != value)
					{
						this.OnFacebookIdChanging(value);
						this.SendPropertyChanging();
						this._FacebookId = value;
						this.SendPropertyChanged("FacebookId");
						this.OnFacebookIdChanged();
					}
					this.SendPropertySetterInvoked("FacebookId", value);
				}
			}
			
			/// <summary>
			/// Column DbType=VarChar(50)
			/// </summary>
			[ColumnAttribute(Storage="_GoogleId", DbType="VarChar(50)", CanBeNull=true)]
			public string GoogleId
			{
				get
				{
					return this._GoogleId;
				}
				set
				{
					if (this._GoogleId != value)
					{
						this.OnGoogleIdChanging(value);
						this.SendPropertyChanging();
						this._GoogleId = value;
						this.SendPropertyChanged("GoogleId");
						this.OnGoogleIdChanged();
					}
					this.SendPropertySetterInvoked("GoogleId", value);
				}
			}
			
			/// <summary>
			/// Column DbType=VarChar(150)
			/// </summary>
			[ColumnAttribute(Storage="_Email", DbType="VarChar(150)", CanBeNull=true)]
			public string Email
			{
				get
				{
					return this._Email;
				}
				set
				{
					if (this._Email != value)
					{
						this.OnEmailChanging(value);
						this.SendPropertyChanging();
						this._Email = value;
						this.SendPropertyChanged("Email");
						this.OnEmailChanged();
					}
					this.SendPropertySetterInvoked("Email", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(50)
			/// </summary>
			[ColumnAttribute(Storage="_Username", DbType="NVarChar(50)", CanBeNull=true)]
			public string Username
			{
				get
				{
					return this._Username;
				}
				set
				{
					if (this._Username != value)
					{
						this.OnUsernameChanging(value);
						this.SendPropertyChanging();
						this._Username = value;
						this.SendPropertyChanged("Username");
						this.OnUsernameChanged();
					}
					this.SendPropertySetterInvoked("Username", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(50)
			/// </summary>
			[ColumnAttribute(Storage="_Password", DbType="NVarChar(50)", CanBeNull=true)]
			public string Password
			{
				get
				{
					return this._Password;
				}
				set
				{
					if (this._Password != value)
					{
						this.OnPasswordChanging(value);
						this.SendPropertyChanging();
						this._Password = value;
						this.SendPropertyChanged("Password");
						this.OnPasswordChanged();
					}
					this.SendPropertySetterInvoked("Password", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime
			/// </summary>
			[ColumnAttribute(Storage="_BirthDate", DbType="DateTime", CanBeNull=true)]
			public DateTime? BirthDate
			{
				get
				{
					return this._BirthDate;
				}
				set
				{
					if (this._BirthDate != value)
					{
						this.OnBirthDateChanging(value);
						this.SendPropertyChanging();
						this._BirthDate = value;
						this.SendPropertyChanged("BirthDate");
						this.OnBirthDateChanged();
					}
					this.SendPropertySetterInvoked("BirthDate", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime
			/// </summary>
			[ColumnAttribute(Storage="_CreationDate", DbType="DateTime", CanBeNull=true)]
			public DateTime? CreationDate
			{
				get
				{
					return this._CreationDate;
				}
				set
				{
					if (this._CreationDate != value)
					{
						this.OnCreationDateChanging(value);
						this.SendPropertyChanging();
						this._CreationDate = value;
						this.SendPropertyChanged("CreationDate");
						this.OnCreationDateChanged();
					}
					this.SendPropertySetterInvoked("CreationDate", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime
			/// </summary>
			[ColumnAttribute(Storage="_LastLoginDate", DbType="DateTime", CanBeNull=true)]
			public DateTime? LastLoginDate
			{
				get
				{
					return this._LastLoginDate;
				}
				set
				{
					if (this._LastLoginDate != value)
					{
						this.OnLastLoginDateChanging(value);
						this.SendPropertyChanging();
						this._LastLoginDate = value;
						this.SendPropertyChanged("LastLoginDate");
						this.OnLastLoginDateChanged();
					}
					this.SendPropertySetterInvoked("LastLoginDate", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_LoginsCount", DbType="Int NOT NULL", CanBeNull=false)]
			public int LoginsCount
			{
				get
				{
					return this._LoginsCount;
				}
				set
				{
					if (this._LoginsCount != value)
					{
						this.OnLoginsCountChanging(value);
						this.SendPropertyChanging();
						this._LoginsCount = value;
						this.SendPropertyChanged("LoginsCount");
						this.OnLoginsCountChanged();
					}
					this.SendPropertySetterInvoked("LoginsCount", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(100)
			/// </summary>
			[ColumnAttribute(Storage="_FirstName", DbType="NVarChar(100)", CanBeNull=true)]
			public string FirstName
			{
				get
				{
					return this._FirstName;
				}
				set
				{
					if (this._FirstName != value)
					{
						this.OnFirstNameChanging(value);
						this.SendPropertyChanging();
						this._FirstName = value;
						this.SendPropertyChanged("FirstName");
						this.OnFirstNameChanged();
					}
					this.SendPropertySetterInvoked("FirstName", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(100)
			/// </summary>
			[ColumnAttribute(Storage="_LastName", DbType="NVarChar(100)", CanBeNull=true)]
			public string LastName
			{
				get
				{
					return this._LastName;
				}
				set
				{
					if (this._LastName != value)
					{
						this.OnLastNameChanging(value);
						this.SendPropertyChanging();
						this._LastName = value;
						this.SendPropertyChanged("LastName");
						this.OnLastNameChanged();
					}
					this.SendPropertySetterInvoked("LastName", value);
				}
			}
			
			/// <summary>
			/// Column DbType=VarChar(10)
			/// </summary>
			[ColumnAttribute(Storage="_Gender", DbType="VarChar(10)", CanBeNull=true)]
			public string Gender
			{
				get
				{
					return this._Gender;
				}
				set
				{
					if (this._Gender != value)
					{
						this.OnGenderChanging(value);
						this.SendPropertyChanging();
						this._Gender = value;
						this.SendPropertyChanged("Gender");
						this.OnGenderChanged();
					}
					this.SendPropertySetterInvoked("Gender", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(1000)
			/// </summary>
			[ColumnAttribute(Storage="_PersonalNote", DbType="NVarChar(1000)", CanBeNull=true)]
			public string PersonalNote
			{
				get
				{
					return this._PersonalNote;
				}
				set
				{
					if (this._PersonalNote != value)
					{
						this.OnPersonalNoteChanging(value);
						this.SendPropertyChanging();
						this._PersonalNote = value;
						this.SendPropertyChanged("PersonalNote");
						this.OnPersonalNoteChanged();
					}
					this.SendPropertySetterInvoked("PersonalNote", value);
				}
			}
			
			/// <summary>
			/// Column DbType=VarChar(255)
			/// </summary>
			[ColumnAttribute(Storage="_WebUrl", DbType="VarChar(255)", CanBeNull=true)]
			public string WebUrl
			{
				get
				{
					return this._WebUrl;
				}
				set
				{
					if (this._WebUrl != value)
					{
						this.OnWebUrlChanging(value);
						this.SendPropertyChanging();
						this._WebUrl = value;
						this.SendPropertyChanged("WebUrl");
						this.OnWebUrlChanged();
					}
					this.SendPropertySetterInvoked("WebUrl", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(255)
			/// </summary>
			[ColumnAttribute(Storage="_Address", DbType="NVarChar(255)", CanBeNull=true)]
			public string Address
			{
				get
				{
					return this._Address;
				}
				set
				{
					if (this._Address != value)
					{
						this.OnAddressChanging(value);
						this.SendPropertyChanging();
						this._Address = value;
						this.SendPropertyChanged("Address");
						this.OnAddressChanged();
					}
					this.SendPropertySetterInvoked("Address", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(50)
			/// </summary>
			[ColumnAttribute(Storage="_ZipCode", DbType="NVarChar(50)", CanBeNull=true)]
			public string ZipCode
			{
				get
				{
					return this._ZipCode;
				}
				set
				{
					if (this._ZipCode != value)
					{
						this.OnZipCodeChanging(value);
						this.SendPropertyChanging();
						this._ZipCode = value;
						this.SendPropertyChanged("ZipCode");
						this.OnZipCodeChanged();
					}
					this.SendPropertySetterInvoked("ZipCode", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(250)
			/// </summary>
			[ColumnAttribute(Storage="_City", DbType="NVarChar(250)", CanBeNull=true)]
			public string City
			{
				get
				{
					return this._City;
				}
				set
				{
					if (this._City != value)
					{
						this.OnCityChanging(value);
						this.SendPropertyChanging();
						this._City = value;
						this.SendPropertyChanged("City");
						this.OnCityChanged();
					}
					this.SendPropertySetterInvoked("City", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(250)
			/// </summary>
			[ColumnAttribute(Storage="_Country", DbType="NVarChar(250)", CanBeNull=true)]
			public string Country
			{
				get
				{
					return this._Country;
				}
				set
				{
					if (this._Country != value)
					{
						this.OnCountryChanging(value);
						this.SendPropertyChanging();
						this._Country = value;
						this.SendPropertyChanged("Country");
						this.OnCountryChanged();
					}
					this.SendPropertySetterInvoked("Country", value);
				}
			}
			
			/// <summary>
			/// Column DbType=VarChar(50)
			/// </summary>
			[ColumnAttribute(Storage="_IP", DbType="VarChar(50)", CanBeNull=true)]
			public string IP
			{
				get
				{
					return this._IP;
				}
				set
				{
					if (this._IP != value)
					{
						this.OnIPChanging(value);
						this.SendPropertyChanging();
						this._IP = value;
						this.SendPropertyChanged("IP");
						this.OnIPChanged();
					}
					this.SendPropertySetterInvoked("IP", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int
			/// </summary>
			[ColumnAttribute(Storage="_PosFirmaID", DbType="Int", CanBeNull=true)]
			public int? PosFirmaID
			{
				get
				{
					return this._PosFirmaID;
				}
				set
				{
					if (this._PosFirmaID != value)
					{
						this.OnPosFirmaIDChanging(value);
						this.SendPropertyChanging();
						this._PosFirmaID = value;
						this.SendPropertyChanged("PosFirmaID");
						this.OnPosFirmaIDChanged();
					}
					this.SendPropertySetterInvoked("PosFirmaID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Bit
			/// </summary>
			[ColumnAttribute(Storage="_IsQuizQuestionsEditor", DbType="Bit", CanBeNull=true)]
			public bool? IsQuizQuestionsEditor
			{
				get
				{
					return this._IsQuizQuestionsEditor;
				}
				set
				{
					if (this._IsQuizQuestionsEditor != value)
					{
						this.OnIsQuizQuestionsEditorChanging(value);
						this.SendPropertyChanging();
						this._IsQuizQuestionsEditor = value;
						this.SendPropertyChanged("IsQuizQuestionsEditor");
						this.OnIsQuizQuestionsEditorChanged();
					}
					this.SendPropertySetterInvoked("IsQuizQuestionsEditor", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Money
			/// </summary>
			[ColumnAttribute(Storage="_StanjeRacuna", DbType="Money", CanBeNull=true)]
			public decimal? StanjeRacuna
			{
				get
				{
					return this._StanjeRacuna;
				}
				set
				{
					if (this._StanjeRacuna != value)
					{
						this.OnStanjeRacunaChanging(value);
						this.SendPropertyChanging();
						this._StanjeRacuna = value;
						this.SendPropertyChanged("StanjeRacuna");
						this.OnStanjeRacunaChanged();
					}
					this.SendPropertySetterInvoked("StanjeRacuna", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int
			/// </summary>
			[ColumnAttribute(Storage="_HomeMemberAddressID", DbType="Int", CanBeNull=true)]
			public int? HomeMemberAddressID
			{
				get
				{
					return this._HomeMemberAddressID;
				}
				set
				{
					if (this._HomeMemberAddressID != value)
					{
						this.OnHomeMemberAddressIDChanging(value);
						this.SendPropertyChanging();
						this._HomeMemberAddressID = value;
						this.SendPropertyChanged("HomeMemberAddressID");
						this.OnHomeMemberAddressIDChanged();
					}
					this.SendPropertySetterInvoked("HomeMemberAddressID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int
			/// </summary>
			[ColumnAttribute(Storage="_WorkMemberAddressID", DbType="Int", CanBeNull=true)]
			public int? WorkMemberAddressID
			{
				get
				{
					return this._WorkMemberAddressID;
				}
				set
				{
					if (this._WorkMemberAddressID != value)
					{
						this.OnWorkMemberAddressIDChanging(value);
						this.SendPropertyChanging();
						this._WorkMemberAddressID = value;
						this.SendPropertyChanged("WorkMemberAddressID");
						this.OnWorkMemberAddressIDChanged();
					}
					this.SendPropertySetterInvoked("WorkMemberAddressID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int
			/// </summary>
			[ColumnAttribute(Storage="_PrimaryMemberAddressID", DbType="Int", CanBeNull=true)]
			public int? PrimaryMemberAddressID
			{
				get
				{
					return this._PrimaryMemberAddressID;
				}
				set
				{
					if (this._PrimaryMemberAddressID != value)
					{
						this.OnPrimaryMemberAddressIDChanging(value);
						this.SendPropertyChanging();
						this._PrimaryMemberAddressID = value;
						this.SendPropertyChanged("PrimaryMemberAddressID");
						this.OnPrimaryMemberAddressIDChanged();
					}
					this.SendPropertySetterInvoked("PrimaryMemberAddressID", value);
				}
			}
			
			#endregion Columns

			#region Associations
			#endregion Associations

			#region Property changing events
			public event PropertyChangingEventHandler PropertyChanging;
			public event PropertyChangedEventHandler PropertyChanged;
			public event PropertySetterInvokedEventHandler PropertySetterInvoked;
			
			protected virtual void SendPropertyChanging()
			{
				if (this.PropertyChanging != null)
				{
					this.PropertyChanging(this, emptyChangingEventArgs);
				}
			}
			
			protected virtual void SendPropertyChanged(String propertyName)
			{
				if (this.PropertyChanged != null)
				{
					this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
				}
			}
			
			protected virtual void SendPropertySetterInvoked(String propertyName, Object value)
			{
				if (this.PropertySetterInvoked != null)
				{
					this.PropertySetterInvoked.Invoke(this, propertyName, value);
				}
			}
			#endregion Property changing events
		}
		#endregion dbo.tblAppMember

		#region dbo.tblAppMemberAssignedPermission
		[TableAttribute(Name="dbo.tblAppMemberAssignedPermission")]
		public partial class tblAppMemberAssignedPermission : EntityBase<tblAppMemberAssignedPermission, dbCalystoUnittestDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private int _AppMemberID;
			private int _AppPermissionID;
			private DateTime _AssignedDate;
			private int? _AssignedByAppMemberID;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnAppMemberIDChanging(int value);
			partial void OnAppMemberIDChanged();
			partial void OnAppPermissionIDChanging(int value);
			partial void OnAppPermissionIDChanged();
			partial void OnAssignedDateChanging(DateTime value);
			partial void OnAssignedDateChanged();
			partial void OnAssignedByAppMemberIDChanging(int? value);
			partial void OnAssignedByAppMemberIDChanged();
			#endregion

			public tblAppMemberAssignedPermission()
			{
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_AppMemberID", DbType="Int NOT NULL", CanBeNull=false)]
			public int AppMemberID
			{
				get
				{
					return this._AppMemberID;
				}
				set
				{
					if (this._AppMemberID != value)
					{
						this.OnAppMemberIDChanging(value);
						this.SendPropertyChanging();
						this._AppMemberID = value;
						this.SendPropertyChanged("AppMemberID");
						this.OnAppMemberIDChanged();
					}
					this.SendPropertySetterInvoked("AppMemberID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_AppPermissionID", DbType="Int NOT NULL", CanBeNull=false)]
			public int AppPermissionID
			{
				get
				{
					return this._AppPermissionID;
				}
				set
				{
					if (this._AppPermissionID != value)
					{
						this.OnAppPermissionIDChanging(value);
						this.SendPropertyChanging();
						this._AppPermissionID = value;
						this.SendPropertyChanged("AppPermissionID");
						this.OnAppPermissionIDChanged();
					}
					this.SendPropertySetterInvoked("AppPermissionID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_AssignedDate", DbType="DateTime NOT NULL", CanBeNull=false)]
			public DateTime AssignedDate
			{
				get
				{
					return this._AssignedDate;
				}
				set
				{
					if (this._AssignedDate != value)
					{
						this.OnAssignedDateChanging(value);
						this.SendPropertyChanging();
						this._AssignedDate = value;
						this.SendPropertyChanged("AssignedDate");
						this.OnAssignedDateChanged();
					}
					this.SendPropertySetterInvoked("AssignedDate", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int
			/// </summary>
			[ColumnAttribute(Storage="_AssignedByAppMemberID", DbType="Int", CanBeNull=true)]
			public int? AssignedByAppMemberID
			{
				get
				{
					return this._AssignedByAppMemberID;
				}
				set
				{
					if (this._AssignedByAppMemberID != value)
					{
						this.OnAssignedByAppMemberIDChanging(value);
						this.SendPropertyChanging();
						this._AssignedByAppMemberID = value;
						this.SendPropertyChanged("AssignedByAppMemberID");
						this.OnAssignedByAppMemberIDChanged();
					}
					this.SendPropertySetterInvoked("AssignedByAppMemberID", value);
				}
			}
			
			#endregion Columns

			#region Associations
			#endregion Associations

			#region Property changing events
			public event PropertyChangingEventHandler PropertyChanging;
			public event PropertyChangedEventHandler PropertyChanged;
			public event PropertySetterInvokedEventHandler PropertySetterInvoked;
			
			protected virtual void SendPropertyChanging()
			{
				if (this.PropertyChanging != null)
				{
					this.PropertyChanging(this, emptyChangingEventArgs);
				}
			}
			
			protected virtual void SendPropertyChanged(String propertyName)
			{
				if (this.PropertyChanged != null)
				{
					this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
				}
			}
			
			protected virtual void SendPropertySetterInvoked(String propertyName, Object value)
			{
				if (this.PropertySetterInvoked != null)
				{
					this.PropertySetterInvoked.Invoke(this, propertyName, value);
				}
			}
			#endregion Property changing events
		}
		#endregion dbo.tblAppMemberAssignedPermission

		#region dbo.tblAppPermission
		[TableAttribute(Name="dbo.tblAppPermission")]
		public partial class tblAppPermission : EntityBase<tblAppPermission, dbCalystoUnittestDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private int _AppPermissionID;
			private bool _IsActive;
			private string _Name;
			private string _Description;
			private string _GroupName;
			private int? _Ordinal;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnAppPermissionIDChanging(int value);
			partial void OnAppPermissionIDChanged();
			partial void OnIsActiveChanging(bool value);
			partial void OnIsActiveChanged();
			partial void OnNameChanging(string value);
			partial void OnNameChanged();
			partial void OnDescriptionChanging(string value);
			partial void OnDescriptionChanged();
			partial void OnGroupNameChanging(string value);
			partial void OnGroupNameChanged();
			partial void OnOrdinalChanging(int? value);
			partial void OnOrdinalChanged();
			#endregion

			public tblAppPermission()
			{
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=Int NOT NULL IDENTITY
			/// </summary>
			[ColumnAttribute(Storage="_AppPermissionID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", CanBeNull=false, IsPrimaryKey=true, IsDbGenerated=true)]
			public int AppPermissionID
			{
				get
				{
					return this._AppPermissionID;
				}
				set
				{
					if (this._AppPermissionID != value)
					{
						this.OnAppPermissionIDChanging(value);
						this.SendPropertyChanging();
						this._AppPermissionID = value;
						this.SendPropertyChanged("AppPermissionID");
						this.OnAppPermissionIDChanged();
					}
					this.SendPropertySetterInvoked("AppPermissionID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Bit NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_IsActive", DbType="Bit NOT NULL", CanBeNull=false)]
			public bool IsActive
			{
				get
				{
					return this._IsActive;
				}
				set
				{
					if (this._IsActive != value)
					{
						this.OnIsActiveChanging(value);
						this.SendPropertyChanging();
						this._IsActive = value;
						this.SendPropertyChanged("IsActive");
						this.OnIsActiveChanged();
					}
					this.SendPropertySetterInvoked("IsActive", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(100) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_Name", DbType="NVarChar(100) NOT NULL", CanBeNull=false)]
			public string Name
			{
				get
				{
					return this._Name;
				}
				set
				{
					if (this._Name != value)
					{
						this.OnNameChanging(value);
						this.SendPropertyChanging();
						this._Name = value;
						this.SendPropertyChanged("Name");
						this.OnNameChanged();
					}
					this.SendPropertySetterInvoked("Name", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(500)
			/// </summary>
			[ColumnAttribute(Storage="_Description", DbType="NVarChar(500)", CanBeNull=true)]
			public string Description
			{
				get
				{
					return this._Description;
				}
				set
				{
					if (this._Description != value)
					{
						this.OnDescriptionChanging(value);
						this.SendPropertyChanging();
						this._Description = value;
						this.SendPropertyChanged("Description");
						this.OnDescriptionChanged();
					}
					this.SendPropertySetterInvoked("Description", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(50)
			/// </summary>
			[ColumnAttribute(Storage="_GroupName", DbType="NVarChar(50)", CanBeNull=true)]
			public string GroupName
			{
				get
				{
					return this._GroupName;
				}
				set
				{
					if (this._GroupName != value)
					{
						this.OnGroupNameChanging(value);
						this.SendPropertyChanging();
						this._GroupName = value;
						this.SendPropertyChanged("GroupName");
						this.OnGroupNameChanged();
					}
					this.SendPropertySetterInvoked("GroupName", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int
			/// </summary>
			[ColumnAttribute(Storage="_Ordinal", DbType="Int", CanBeNull=true)]
			public int? Ordinal
			{
				get
				{
					return this._Ordinal;
				}
				set
				{
					if (this._Ordinal != value)
					{
						this.OnOrdinalChanging(value);
						this.SendPropertyChanging();
						this._Ordinal = value;
						this.SendPropertyChanged("Ordinal");
						this.OnOrdinalChanged();
					}
					this.SendPropertySetterInvoked("Ordinal", value);
				}
			}
			
			#endregion Columns

			#region Associations
			#endregion Associations

			#region Property changing events
			public event PropertyChangingEventHandler PropertyChanging;
			public event PropertyChangedEventHandler PropertyChanged;
			public event PropertySetterInvokedEventHandler PropertySetterInvoked;
			
			protected virtual void SendPropertyChanging()
			{
				if (this.PropertyChanging != null)
				{
					this.PropertyChanging(this, emptyChangingEventArgs);
				}
			}
			
			protected virtual void SendPropertyChanged(String propertyName)
			{
				if (this.PropertyChanged != null)
				{
					this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
				}
			}
			
			protected virtual void SendPropertySetterInvoked(String propertyName, Object value)
			{
				if (this.PropertySetterInvoked != null)
				{
					this.PropertySetterInvoked.Invoke(this, propertyName, value);
				}
			}
			#endregion Property changing events
		}
		#endregion dbo.tblAppPermission


	#endregion Entity Tables

	#region Entity Return types

	#endregion Entity Return types

}
#pragma warning restore 1591
