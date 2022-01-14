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
		public Calysto.Data.Linq.Table<tblAppMember2> tblAppMember2 { get { return this.GetTable<tblAppMember2>(); } }
		public Calysto.Data.Linq.Table<guest_tblAppMember2> guest_tblAppMember2 { get { return this.GetTable<guest_tblAppMember2>(); } }
		public Calysto.Data.Linq.Table<tblAppMemberPermission> tblAppMemberPermission { get { return this.GetTable<tblAppMemberPermission>(); } }
		public Calysto.Data.Linq.Table<tblAppMemberPicture> tblAppMemberPicture { get { return this.GetTable<tblAppMemberPicture>(); } }
		public Calysto.Data.Linq.Table<tblAppMemberPicture2> tblAppMemberPicture2 { get { return this.GetTable<tblAppMemberPicture2>(); } }
		public Calysto.Data.Linq.Table<tblAppMemberStatus> tblAppMemberStatus { get { return this.GetTable<tblAppMemberStatus>(); } }
		public Calysto.Data.Linq.Table<tblVehicle> tblVehicle { get { return this.GetTable<tblVehicle>(); } }
		#endregion Context properties for tables

		#region Context database functions
		[FunctionAttribute(Name="dbo.fnConvertCurrency", IsComposable=true)]
		public double? fnConvertCurrency(
			[ParameterAttribute(DbType="Float")] double? amount = (double)(0),
			[ParameterAttribute(DbType="Float")] double? amount2 = (double)(-0.05),
			[ParameterAttribute(DbType="VarChar(10)")] string fromCurrency = "EUR",
			[ParameterAttribute(DbType="VarChar(10)")] string toCurrency = "HRK",
			[ParameterAttribute(DbType="DateTime")] DateTime? exchangeRateDate = null
		)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), amount, amount2, fromCurrency, toCurrency, exchangeRateDate);
			return ((double?) result.ReturnValue);
		}

		[FunctionAttribute(Name="dbo.fnGetBankaValutaTecaj", IsComposable=true)]
		public ISingleResult<ValutaTecaj> fnGetBankaValutaTecaj(
			[ParameterAttribute(DbType="Int")] int? skip111,
			[ParameterAttribute(DbType="Int")] int? take111 = (int)(50),
			[ParameterAttribute(DbType="DateTime")] DateTime? validOnDate = null,
			[ParameterAttribute(DbType="VarChar(50)")] string valuta = null
		)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), skip111, take111, validOnDate, valuta);
			return ((ISingleResult<ValutaTecaj>) result.ReturnValue);
		}

		[FunctionAttribute(Name="dbo.fnSumNumbers", IsComposable=true)]
		public double? fnSumNumbers(
			[ParameterAttribute(DbType="Float")] double? num1,
			[ParameterAttribute(DbType="Float")] double? num2
		)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), num1, num2);
			return ((double?) result.ReturnValue);
		}

		[FunctionAttribute(Name="guest.fnAddPaddingSpace", IsComposable=true)]
		public string guest_fnAddPaddingSpace(
			[ParameterAttribute(DbType="NVarChar(MAX)")] string str,
			[ParameterAttribute(DbType="Int")] int? expectedLength,
			[ParameterAttribute(DbType="Bit")] bool? addPrefix
		)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), str, expectedLength, addPrefix);
			return ((string) result.ReturnValue);
		}

		[FunctionAttribute(Name="guest.fnGetStariNoviGranica", IsComposable=true)]
		public ISingleResult<guest_fnGetStariNoviGranicaResult> guest_fnGetStariNoviGranica(
		)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())));
			return ((ISingleResult<guest_fnGetStariNoviGranicaResult>) result.ReturnValue);
		}

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
			private EntityRef<tblAppMemberStatus> _tblAppMemberStatus;
			private EntitySet<tblAppMemberPermission> _tblAppMemberPermissionList;
			private EntitySet<tblAppMemberPicture> _tblAppMemberPictureList;
			private EntitySet<tblAppMemberPicture2> _tblAppMemberPicture2List;
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
				_tblAppMemberStatus = default(EntityRef<tblAppMemberStatus>);
				_tblAppMemberPermissionList = new EntitySet<tblAppMemberPermission>(
					new Action<tblAppMemberPermission>(item=>{this.SendPropertyChanging(); item.tblAppMember=this;}), 
					new Action<tblAppMemberPermission>(item=>{this.SendPropertyChanging(); item.tblAppMember=null;}));
				_tblAppMemberPictureList = new EntitySet<tblAppMemberPicture>(
					new Action<tblAppMemberPicture>(item=>{this.SendPropertyChanging(); item.tblAppMember=this;}), 
					new Action<tblAppMemberPicture>(item=>{this.SendPropertyChanging(); item.tblAppMember=null;}));
				_tblAppMemberPicture2List = new EntitySet<tblAppMemberPicture2>(
					new Action<tblAppMemberPicture2>(item=>{this.SendPropertyChanging(); item.tblAppMember=this;}), 
					new Action<tblAppMemberPicture2>(item=>{this.SendPropertyChanging(); item.tblAppMember=null;}));
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
			/// <summary>
			/// Association [FK][Many]tblAppMember.AppMemberStatusID --- [PK][One]tblAppMemberStatus.AppMemberStatusID
			/// </summary>
			[AssociationAttribute(Name="FK_AppMember_AppMemberStatus", Storage="_tblAppMemberStatus", ThisKey="AppMemberStatusID", OtherKey="AppMemberStatusID", IsUnique=false, IsForeignKey=true)]
			public tblAppMemberStatus tblAppMemberStatus
			{
				get
				{
					return this._tblAppMemberStatus.Entity;
				}
				set
				{
					tblAppMemberStatus previousValue = this._tblAppMemberStatus.Entity;
					if ((previousValue != value) || (this._tblAppMemberStatus.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._tblAppMemberStatus.Entity = null;
							previousValue.tblAppMemberList.Remove(this);
						}
						this._tblAppMemberStatus.Entity = value;
						if (value != null)
						{
							value.tblAppMemberList.Add(this);
							this._AppMemberStatusID = value.AppMemberStatusID;
						}
						else
						{
							this._AppMemberStatusID = default(int);
						}
						this.SendPropertyChanged("tblAppMemberStatus");
					}
					this.SendPropertySetterInvoked("tblAppMemberStatus", value);
				}
			}
			
			/// <summary>
			/// Association [PK][One]tblAppMember.AppMemberID --- [FK][Many]tblAppMemberPermission.AppMemberID
			/// </summary>
			[AssociationAttribute(Name="FK_AppMemberPermission_AppMember", Storage="_tblAppMemberPermissionList", ThisKey="AppMemberID", OtherKey="AppMemberID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<tblAppMemberPermission> tblAppMemberPermissionList
			{
				get { return this._tblAppMemberPermissionList; }
				set { this._tblAppMemberPermissionList.Assign(value); }
			}
			
			/// <summary>
			/// Association [PK][One]tblAppMember.AppMemberID --- [FK][Many]tblAppMemberPicture.AppMemberID
			/// </summary>
			[AssociationAttribute(Name="FK_AppMemberPicture_AppMember", Storage="_tblAppMemberPictureList", ThisKey="AppMemberID", OtherKey="AppMemberID", IsUnique=false, IsForeignKey=false, DeleteRule="Cascade")]
			public EntitySet<tblAppMemberPicture> tblAppMemberPictureList
			{
				get { return this._tblAppMemberPictureList; }
				set { this._tblAppMemberPictureList.Assign(value); }
			}
			
			/// <summary>
			/// Association [PK][One]tblAppMember.AppMemberID --- [FK][Many]tblAppMemberPicture2.AppMemberID
			/// </summary>
			[AssociationAttribute(Name="FK_tblAppMemberPicture2_tblAppMember", Storage="_tblAppMemberPicture2List", ThisKey="AppMemberID", OtherKey="AppMemberID", IsUnique=false, IsForeignKey=false, DeleteRule="SetDefault")]
			public EntitySet<tblAppMemberPicture2> tblAppMemberPicture2List
			{
				get { return this._tblAppMemberPicture2List; }
				set { this._tblAppMemberPicture2List.Assign(value); }
			}
			
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

		#region dbo.tblAppMember2
		[TableAttribute(Name="dbo.tblAppMember2")]
		public partial class tblAppMember2 : EntityBase<tblAppMember2, dbCalystoUnittestDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
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
			private string _ReferentNote;
			private bool? _IsQuizQuestionsEditor;
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
			partial void OnReferentNoteChanging(string value);
			partial void OnReferentNoteChanged();
			partial void OnIsQuizQuestionsEditorChanging(bool? value);
			partial void OnIsQuizQuestionsEditorChanged();
			#endregion

			public tblAppMember2()
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
			/// Column DbType=NVarChar(1000)
			/// </summary>
			[ColumnAttribute(Storage="_ReferentNote", DbType="NVarChar(1000)", CanBeNull=true)]
			public string ReferentNote
			{
				get
				{
					return this._ReferentNote;
				}
				set
				{
					if (this._ReferentNote != value)
					{
						this.OnReferentNoteChanging(value);
						this.SendPropertyChanging();
						this._ReferentNote = value;
						this.SendPropertyChanged("ReferentNote");
						this.OnReferentNoteChanged();
					}
					this.SendPropertySetterInvoked("ReferentNote", value);
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
		#endregion dbo.tblAppMember2

		#region guest.tblAppMember2
		[TableAttribute(Name="guest.tblAppMember2")]
		public partial class guest_tblAppMember2 : EntityBase<guest_tblAppMember2, dbCalystoUnittestDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
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
			private string _ReferentNote;
			private bool? _IsQuizQuestionsEditor;
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
			partial void OnReferentNoteChanging(string value);
			partial void OnReferentNoteChanged();
			partial void OnIsQuizQuestionsEditorChanging(bool? value);
			partial void OnIsQuizQuestionsEditorChanged();
			#endregion

			public guest_tblAppMember2()
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
			/// Column DbType=NVarChar(1000)
			/// </summary>
			[ColumnAttribute(Storage="_ReferentNote", DbType="NVarChar(1000)", CanBeNull=true)]
			public string ReferentNote
			{
				get
				{
					return this._ReferentNote;
				}
				set
				{
					if (this._ReferentNote != value)
					{
						this.OnReferentNoteChanging(value);
						this.SendPropertyChanging();
						this._ReferentNote = value;
						this.SendPropertyChanged("ReferentNote");
						this.OnReferentNoteChanged();
					}
					this.SendPropertySetterInvoked("ReferentNote", value);
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
		#endregion guest.tblAppMember2

		#region dbo.tblAppMemberPermission
		[TableAttribute(Name="dbo.tblAppMemberPermission")]
		public partial class tblAppMemberPermission : EntityBase<tblAppMemberPermission, dbCalystoUnittestDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private int _AppPermissionID;
			private int _AppMemberID;
			private DateTime _DateInserted;
			private int? _InsertedByAppMemberID;
			private EntityRef<tblAppMember> _tblAppMember;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnAppPermissionIDChanging(int value);
			partial void OnAppPermissionIDChanged();
			partial void OnAppMemberIDChanging(int value);
			partial void OnAppMemberIDChanged();
			partial void OnDateInsertedChanging(DateTime value);
			partial void OnDateInsertedChanged();
			partial void OnInsertedByAppMemberIDChanging(int? value);
			partial void OnInsertedByAppMemberIDChanged();
			#endregion

			public tblAppMemberPermission()
			{
				_tblAppMember = default(EntityRef<tblAppMember>);
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_AppPermissionID", DbType="Int NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
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
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_AppMemberID", DbType="Int NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
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
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_DateInserted", DbType="DateTime NOT NULL", CanBeNull=false)]
			public DateTime DateInserted
			{
				get
				{
					return this._DateInserted;
				}
				set
				{
					if (this._DateInserted != value)
					{
						this.OnDateInsertedChanging(value);
						this.SendPropertyChanging();
						this._DateInserted = value;
						this.SendPropertyChanged("DateInserted");
						this.OnDateInsertedChanged();
					}
					this.SendPropertySetterInvoked("DateInserted", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int
			/// </summary>
			[ColumnAttribute(Storage="_InsertedByAppMemberID", DbType="Int", CanBeNull=true)]
			public int? InsertedByAppMemberID
			{
				get
				{
					return this._InsertedByAppMemberID;
				}
				set
				{
					if (this._InsertedByAppMemberID != value)
					{
						this.OnInsertedByAppMemberIDChanging(value);
						this.SendPropertyChanging();
						this._InsertedByAppMemberID = value;
						this.SendPropertyChanged("InsertedByAppMemberID");
						this.OnInsertedByAppMemberIDChanged();
					}
					this.SendPropertySetterInvoked("InsertedByAppMemberID", value);
				}
			}
			
			#endregion Columns

			#region Associations
			/// <summary>
			/// Association [FK][Many]tblAppMemberPermission.AppMemberID --- [PK][One]tblAppMember.AppMemberID
			/// </summary>
			[AssociationAttribute(Name="FK_AppMemberPermission_AppMember", Storage="_tblAppMember", ThisKey="AppMemberID", OtherKey="AppMemberID", IsUnique=false, IsForeignKey=true)]
			public tblAppMember tblAppMember
			{
				get
				{
					return this._tblAppMember.Entity;
				}
				set
				{
					tblAppMember previousValue = this._tblAppMember.Entity;
					if ((previousValue != value) || (this._tblAppMember.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._tblAppMember.Entity = null;
							previousValue.tblAppMemberPermissionList.Remove(this);
						}
						this._tblAppMember.Entity = value;
						if (value != null)
						{
							value.tblAppMemberPermissionList.Add(this);
							this._AppMemberID = value.AppMemberID;
						}
						else
						{
							this._AppMemberID = default(int);
						}
						this.SendPropertyChanged("tblAppMember");
					}
					this.SendPropertySetterInvoked("tblAppMember", value);
				}
			}
			
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
		#endregion dbo.tblAppMemberPermission

		#region dbo.tblAppMemberPicture
		[TableAttribute(Name="dbo.tblAppMemberPicture")]
		public partial class tblAppMemberPicture : EntityBase<tblAppMemberPicture, dbCalystoUnittestDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private int _AppMemberPictureID;
			private int? _AppMemberID;
			private DateTime? _InsertionDate;
			private string _FileName;
			private byte[] _ImageData;
			private string _ImageMimeType;
			private byte[] _ThumbData;
			private string _ThumbMimeType;
			private EntityRef<tblAppMember> _tblAppMember;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnAppMemberPictureIDChanging(int value);
			partial void OnAppMemberPictureIDChanged();
			partial void OnAppMemberIDChanging(int? value);
			partial void OnAppMemberIDChanged();
			partial void OnInsertionDateChanging(DateTime? value);
			partial void OnInsertionDateChanged();
			partial void OnFileNameChanging(string value);
			partial void OnFileNameChanged();
			partial void OnImageDataChanging(byte[] value);
			partial void OnImageDataChanged();
			partial void OnImageMimeTypeChanging(string value);
			partial void OnImageMimeTypeChanged();
			partial void OnThumbDataChanging(byte[] value);
			partial void OnThumbDataChanged();
			partial void OnThumbMimeTypeChanging(string value);
			partial void OnThumbMimeTypeChanged();
			#endregion

			public tblAppMemberPicture()
			{
				_tblAppMember = default(EntityRef<tblAppMember>);
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=Int NOT NULL IDENTITY
			/// </summary>
			[ColumnAttribute(Storage="_AppMemberPictureID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", CanBeNull=false, IsPrimaryKey=true, IsDbGenerated=true)]
			public int AppMemberPictureID
			{
				get
				{
					return this._AppMemberPictureID;
				}
				set
				{
					if (this._AppMemberPictureID != value)
					{
						this.OnAppMemberPictureIDChanging(value);
						this.SendPropertyChanging();
						this._AppMemberPictureID = value;
						this.SendPropertyChanged("AppMemberPictureID");
						this.OnAppMemberPictureIDChanged();
					}
					this.SendPropertySetterInvoked("AppMemberPictureID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int
			/// </summary>
			[ColumnAttribute(Storage="_AppMemberID", DbType="Int", CanBeNull=true)]
			public int? AppMemberID
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
			/// Column DbType=DateTime
			/// </summary>
			[ColumnAttribute(Storage="_InsertionDate", DbType="DateTime", CanBeNull=true)]
			public DateTime? InsertionDate
			{
				get
				{
					return this._InsertionDate;
				}
				set
				{
					if (this._InsertionDate != value)
					{
						this.OnInsertionDateChanging(value);
						this.SendPropertyChanging();
						this._InsertionDate = value;
						this.SendPropertyChanged("InsertionDate");
						this.OnInsertionDateChanged();
					}
					this.SendPropertySetterInvoked("InsertionDate", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(500)
			/// </summary>
			[ColumnAttribute(Storage="_FileName", DbType="NVarChar(500)", CanBeNull=true)]
			public string FileName
			{
				get
				{
					return this._FileName;
				}
				set
				{
					if (this._FileName != value)
					{
						this.OnFileNameChanging(value);
						this.SendPropertyChanging();
						this._FileName = value;
						this.SendPropertyChanged("FileName");
						this.OnFileNameChanged();
					}
					this.SendPropertySetterInvoked("FileName", value);
				}
			}
			
			/// <summary>
			/// Column DbType=VarBinary(MAX)
			/// </summary>
			[ColumnAttribute(Storage="_ImageData", DbType="VarBinary(MAX)", CanBeNull=true)]
			public byte[] ImageData
			{
				get
				{
					return this._ImageData;
				}
				set
				{
					if (this._ImageData != value)
					{
						this.OnImageDataChanging(value);
						this.SendPropertyChanging();
						this._ImageData = value;
						this.SendPropertyChanged("ImageData");
						this.OnImageDataChanged();
					}
					this.SendPropertySetterInvoked("ImageData", value);
				}
			}
			
			/// <summary>
			/// Column DbType=VarChar(20)
			/// </summary>
			[ColumnAttribute(Storage="_ImageMimeType", DbType="VarChar(20)", CanBeNull=true)]
			public string ImageMimeType
			{
				get
				{
					return this._ImageMimeType;
				}
				set
				{
					if (this._ImageMimeType != value)
					{
						this.OnImageMimeTypeChanging(value);
						this.SendPropertyChanging();
						this._ImageMimeType = value;
						this.SendPropertyChanged("ImageMimeType");
						this.OnImageMimeTypeChanged();
					}
					this.SendPropertySetterInvoked("ImageMimeType", value);
				}
			}
			
			/// <summary>
			/// Column DbType=VarBinary(MAX)
			/// </summary>
			[ColumnAttribute(Storage="_ThumbData", DbType="VarBinary(MAX)", CanBeNull=true)]
			public byte[] ThumbData
			{
				get
				{
					return this._ThumbData;
				}
				set
				{
					if (this._ThumbData != value)
					{
						this.OnThumbDataChanging(value);
						this.SendPropertyChanging();
						this._ThumbData = value;
						this.SendPropertyChanged("ThumbData");
						this.OnThumbDataChanged();
					}
					this.SendPropertySetterInvoked("ThumbData", value);
				}
			}
			
			/// <summary>
			/// Column DbType=VarChar(20)
			/// </summary>
			[ColumnAttribute(Storage="_ThumbMimeType", DbType="VarChar(20)", CanBeNull=true)]
			public string ThumbMimeType
			{
				get
				{
					return this._ThumbMimeType;
				}
				set
				{
					if (this._ThumbMimeType != value)
					{
						this.OnThumbMimeTypeChanging(value);
						this.SendPropertyChanging();
						this._ThumbMimeType = value;
						this.SendPropertyChanged("ThumbMimeType");
						this.OnThumbMimeTypeChanged();
					}
					this.SendPropertySetterInvoked("ThumbMimeType", value);
				}
			}
			
			#endregion Columns

			#region Associations
			/// <summary>
			/// Association [FK][Many]tblAppMemberPicture.AppMemberID --- [PK][One]tblAppMember.AppMemberID
			/// </summary>
			[AssociationAttribute(Name="FK_AppMemberPicture_AppMember", Storage="_tblAppMember", ThisKey="AppMemberID", OtherKey="AppMemberID", IsUnique=false, IsForeignKey=true)]
			public tblAppMember tblAppMember
			{
				get
				{
					return this._tblAppMember.Entity;
				}
				set
				{
					tblAppMember previousValue = this._tblAppMember.Entity;
					if ((previousValue != value) || (this._tblAppMember.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._tblAppMember.Entity = null;
							previousValue.tblAppMemberPictureList.Remove(this);
						}
						this._tblAppMember.Entity = value;
						if (value != null)
						{
							value.tblAppMemberPictureList.Add(this);
							this._AppMemberID = value.AppMemberID;
						}
						else
						{
							this._AppMemberID = default(int?);
						}
						this.SendPropertyChanged("tblAppMember");
					}
					this.SendPropertySetterInvoked("tblAppMember", value);
				}
			}
			
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
		#endregion dbo.tblAppMemberPicture

		#region dbo.tblAppMemberPicture2
		[TableAttribute(Name="dbo.tblAppMemberPicture2")]
		public partial class tblAppMemberPicture2 : EntityBase<tblAppMemberPicture2, dbCalystoUnittestDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private int _AppMemberPictureID;
			private int? _AppMemberID;
			private DateTime? _InsertionDate;
			private byte[] _ImageData;
			private byte[] _ThumbData;
			private string _FileName;
			private string _ImageMimeType;
			private string _ThumbMimeType;
			private EntityRef<tblAppMember> _tblAppMember;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnAppMemberPictureIDChanging(int value);
			partial void OnAppMemberPictureIDChanged();
			partial void OnAppMemberIDChanging(int? value);
			partial void OnAppMemberIDChanged();
			partial void OnInsertionDateChanging(DateTime? value);
			partial void OnInsertionDateChanged();
			partial void OnImageDataChanging(byte[] value);
			partial void OnImageDataChanged();
			partial void OnThumbDataChanging(byte[] value);
			partial void OnThumbDataChanged();
			partial void OnFileNameChanging(string value);
			partial void OnFileNameChanged();
			partial void OnImageMimeTypeChanging(string value);
			partial void OnImageMimeTypeChanged();
			partial void OnThumbMimeTypeChanging(string value);
			partial void OnThumbMimeTypeChanged();
			#endregion

			public tblAppMemberPicture2()
			{
				_tblAppMember = default(EntityRef<tblAppMember>);
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=Int NOT NULL IDENTITY
			/// </summary>
			[ColumnAttribute(Storage="_AppMemberPictureID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", CanBeNull=false, IsPrimaryKey=true, IsDbGenerated=true)]
			public int AppMemberPictureID
			{
				get
				{
					return this._AppMemberPictureID;
				}
				set
				{
					if (this._AppMemberPictureID != value)
					{
						this.OnAppMemberPictureIDChanging(value);
						this.SendPropertyChanging();
						this._AppMemberPictureID = value;
						this.SendPropertyChanged("AppMemberPictureID");
						this.OnAppMemberPictureIDChanged();
					}
					this.SendPropertySetterInvoked("AppMemberPictureID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int
			/// </summary>
			[ColumnAttribute(Storage="_AppMemberID", DbType="Int", CanBeNull=true)]
			public int? AppMemberID
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
			/// Column DbType=DateTime
			/// </summary>
			[ColumnAttribute(Storage="_InsertionDate", DbType="DateTime", CanBeNull=true)]
			public DateTime? InsertionDate
			{
				get
				{
					return this._InsertionDate;
				}
				set
				{
					if (this._InsertionDate != value)
					{
						this.OnInsertionDateChanging(value);
						this.SendPropertyChanging();
						this._InsertionDate = value;
						this.SendPropertyChanged("InsertionDate");
						this.OnInsertionDateChanged();
					}
					this.SendPropertySetterInvoked("InsertionDate", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Image
			/// </summary>
			[ColumnAttribute(Storage="_ImageData", DbType="Image", CanBeNull=true)]
			public byte[] ImageData
			{
				get
				{
					return this._ImageData;
				}
				set
				{
					if (this._ImageData != value)
					{
						this.OnImageDataChanging(value);
						this.SendPropertyChanging();
						this._ImageData = value;
						this.SendPropertyChanged("ImageData");
						this.OnImageDataChanged();
					}
					this.SendPropertySetterInvoked("ImageData", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Image
			/// </summary>
			[ColumnAttribute(Storage="_ThumbData", DbType="Image", CanBeNull=true)]
			public byte[] ThumbData
			{
				get
				{
					return this._ThumbData;
				}
				set
				{
					if (this._ThumbData != value)
					{
						this.OnThumbDataChanging(value);
						this.SendPropertyChanging();
						this._ThumbData = value;
						this.SendPropertyChanged("ThumbData");
						this.OnThumbDataChanged();
					}
					this.SendPropertySetterInvoked("ThumbData", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(500)
			/// </summary>
			[ColumnAttribute(Storage="_FileName", DbType="NVarChar(500)", CanBeNull=true)]
			public string FileName
			{
				get
				{
					return this._FileName;
				}
				set
				{
					if (this._FileName != value)
					{
						this.OnFileNameChanging(value);
						this.SendPropertyChanging();
						this._FileName = value;
						this.SendPropertyChanged("FileName");
						this.OnFileNameChanged();
					}
					this.SendPropertySetterInvoked("FileName", value);
				}
			}
			
			/// <summary>
			/// Column DbType=VarChar(20)
			/// </summary>
			[ColumnAttribute(Storage="_ImageMimeType", DbType="VarChar(20)", CanBeNull=true)]
			public string ImageMimeType
			{
				get
				{
					return this._ImageMimeType;
				}
				set
				{
					if (this._ImageMimeType != value)
					{
						this.OnImageMimeTypeChanging(value);
						this.SendPropertyChanging();
						this._ImageMimeType = value;
						this.SendPropertyChanged("ImageMimeType");
						this.OnImageMimeTypeChanged();
					}
					this.SendPropertySetterInvoked("ImageMimeType", value);
				}
			}
			
			/// <summary>
			/// Column DbType=VarChar(20)
			/// </summary>
			[ColumnAttribute(Storage="_ThumbMimeType", DbType="VarChar(20)", CanBeNull=true)]
			public string ThumbMimeType
			{
				get
				{
					return this._ThumbMimeType;
				}
				set
				{
					if (this._ThumbMimeType != value)
					{
						this.OnThumbMimeTypeChanging(value);
						this.SendPropertyChanging();
						this._ThumbMimeType = value;
						this.SendPropertyChanged("ThumbMimeType");
						this.OnThumbMimeTypeChanged();
					}
					this.SendPropertySetterInvoked("ThumbMimeType", value);
				}
			}
			
			#endregion Columns

			#region Associations
			/// <summary>
			/// Association [FK][Many]tblAppMemberPicture2.AppMemberID --- [PK][One]tblAppMember.AppMemberID
			/// </summary>
			[AssociationAttribute(Name="FK_tblAppMemberPicture2_tblAppMember", Storage="_tblAppMember", ThisKey="AppMemberID", OtherKey="AppMemberID", IsUnique=false, IsForeignKey=true)]
			public tblAppMember tblAppMember
			{
				get
				{
					return this._tblAppMember.Entity;
				}
				set
				{
					tblAppMember previousValue = this._tblAppMember.Entity;
					if ((previousValue != value) || (this._tblAppMember.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._tblAppMember.Entity = null;
							previousValue.tblAppMemberPicture2List.Remove(this);
						}
						this._tblAppMember.Entity = value;
						if (value != null)
						{
							value.tblAppMemberPicture2List.Add(this);
							this._AppMemberID = value.AppMemberID;
						}
						else
						{
							this._AppMemberID = default(int?);
						}
						this.SendPropertyChanged("tblAppMember");
					}
					this.SendPropertySetterInvoked("tblAppMember", value);
				}
			}
			
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
		#endregion dbo.tblAppMemberPicture2

		#region dbo.tblAppMemberStatus
		[TableAttribute(Name="dbo.tblAppMemberStatus")]
		public partial class tblAppMemberStatus : EntityBase<tblAppMemberStatus, dbCalystoUnittestDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private int _AppMemberStatusID;
			private bool _IsActive;
			private string _Name;
			private string _Description;
			private EntitySet<tblAppMember> _tblAppMemberList;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnAppMemberStatusIDChanging(int value);
			partial void OnAppMemberStatusIDChanged();
			partial void OnIsActiveChanging(bool value);
			partial void OnIsActiveChanged();
			partial void OnNameChanging(string value);
			partial void OnNameChanged();
			partial void OnDescriptionChanging(string value);
			partial void OnDescriptionChanged();
			#endregion

			public tblAppMemberStatus()
			{
				_tblAppMemberList = new EntitySet<tblAppMember>(
					new Action<tblAppMember>(item=>{this.SendPropertyChanging(); item.tblAppMemberStatus=this;}), 
					new Action<tblAppMember>(item=>{this.SendPropertyChanging(); item.tblAppMemberStatus=null;}));
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_AppMemberStatusID", DbType="Int NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
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
			/// Column DbType=NVarChar(100)
			/// </summary>
			[ColumnAttribute(Storage="_Name", DbType="NVarChar(100)", CanBeNull=true)]
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
			
			#endregion Columns

			#region Associations
			/// <summary>
			/// Association [PK][One]tblAppMemberStatus.AppMemberStatusID --- [FK][Many]tblAppMember.AppMemberStatusID
			/// </summary>
			[AssociationAttribute(Name="FK_AppMember_AppMemberStatus", Storage="_tblAppMemberList", ThisKey="AppMemberStatusID", OtherKey="AppMemberStatusID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<tblAppMember> tblAppMemberList
			{
				get { return this._tblAppMemberList; }
				set { this._tblAppMemberList.Assign(value); }
			}
			
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
		#endregion dbo.tblAppMemberStatus

		#region dbo.tblVehicle
		[TableAttribute(Name="dbo.tblVehicle")]
		public partial class tblVehicle : EntityBase<tblVehicle, dbCalystoUnittestDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private int _VehicleID;
			private int _VehicleRipID;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnVehicleIDChanging(int value);
			partial void OnVehicleIDChanged();
			partial void OnVehicleRipIDChanging(int value);
			partial void OnVehicleRipIDChanged();
			#endregion

			public tblVehicle()
			{
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=Int NOT NULL IDENTITY
			/// </summary>
			[ColumnAttribute(Storage="_VehicleID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", CanBeNull=false, IsPrimaryKey=true, IsDbGenerated=true)]
			public int VehicleID
			{
				get
				{
					return this._VehicleID;
				}
				set
				{
					if (this._VehicleID != value)
					{
						this.OnVehicleIDChanging(value);
						this.SendPropertyChanging();
						this._VehicleID = value;
						this.SendPropertyChanged("VehicleID");
						this.OnVehicleIDChanged();
					}
					this.SendPropertySetterInvoked("VehicleID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_VehicleRipID", DbType="Int NOT NULL", CanBeNull=false)]
			public int VehicleRipID
			{
				get
				{
					return this._VehicleRipID;
				}
				set
				{
					if (this._VehicleRipID != value)
					{
						this.OnVehicleRipIDChanging(value);
						this.SendPropertyChanging();
						this._VehicleRipID = value;
						this.SendPropertyChanged("VehicleRipID");
						this.OnVehicleRipIDChanged();
					}
					this.SendPropertySetterInvoked("VehicleRipID", value);
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
		#endregion dbo.tblVehicle


	#endregion Entity Tables

	#region Entity Return types

	#region ValutaTecaj
	public partial class ValutaTecaj
	{
		#region Storage members
		#endregion Storage members

		public ValutaTecaj(){ }

	}
	#endregion ValutaTecaj

	#region spMultiResultsMultipleResults
	public partial class spMultiResultsMultipleResults
	{
		#region Storage members
		private List<spMultiResultsResult1> _Result1;
		private List<spMultiResultsResult2> _Result2;
		private List<spMultiResultsResult3> _Result3;
		private List<spMultiResultsResult4> _Result4;
		private int _ReturnValue;
		#endregion Storage members

		public spMultiResultsMultipleResults(){ }

		/// <summary>
		/// Column DbType=
		/// </summary>
		[ColumnAttribute(Storage="_Result1", DbType="", CanBeNull=false)]
		public List<spMultiResultsResult1> Result1
		{
			get
			{
				return this._Result1;
			}
			set
			{
				if (this._Result1 != value)
				{
					this._Result1 = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=
		/// </summary>
		[ColumnAttribute(Storage="_Result2", DbType="", CanBeNull=false)]
		public List<spMultiResultsResult2> Result2
		{
			get
			{
				return this._Result2;
			}
			set
			{
				if (this._Result2 != value)
				{
					this._Result2 = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=
		/// </summary>
		[ColumnAttribute(Storage="_Result3", DbType="", CanBeNull=false)]
		public List<spMultiResultsResult3> Result3
		{
			get
			{
				return this._Result3;
			}
			set
			{
				if (this._Result3 != value)
				{
					this._Result3 = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=
		/// </summary>
		[ColumnAttribute(Storage="_Result4", DbType="", CanBeNull=false)]
		public List<spMultiResultsResult4> Result4
		{
			get
			{
				return this._Result4;
			}
			set
			{
				if (this._Result4 != value)
				{
					this._Result4 = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=
		/// </summary>
		[ColumnAttribute(Storage="_ReturnValue", DbType="", CanBeNull=false)]
		public int ReturnValue
		{
			get
			{
				return this._ReturnValue;
			}
			set
			{
				if (this._ReturnValue != value)
				{
					this._ReturnValue = value;
				}
			}
		}
		
	}
	#endregion spMultiResultsMultipleResults

	#region spMultiResults2MultipleResults
	public partial class spMultiResults2MultipleResults
	{
		#region Storage members
		private List<int> _Clients;
		private List<double?> _Owners;
		private List<tblVehicle> _Vehicles;
		private List<spMultiResults2Result> _Result4;
		private int _ReturnValue;
		#endregion Storage members

		public spMultiResults2MultipleResults(){ }

		/// <summary>
		/// Column DbType=
		/// </summary>
		[ColumnAttribute(Storage="_Clients", DbType="", CanBeNull=false)]
		public List<int> Clients
		{
			get
			{
				return this._Clients;
			}
			set
			{
				if (this._Clients != value)
				{
					this._Clients = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=
		/// </summary>
		[ColumnAttribute(Storage="_Owners", DbType="", CanBeNull=false)]
		public List<double?> Owners
		{
			get
			{
				return this._Owners;
			}
			set
			{
				if (this._Owners != value)
				{
					this._Owners = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=
		/// </summary>
		[ColumnAttribute(Storage="_Vehicles", DbType="", CanBeNull=false)]
		public List<tblVehicle> Vehicles
		{
			get
			{
				return this._Vehicles;
			}
			set
			{
				if (this._Vehicles != value)
				{
					this._Vehicles = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=
		/// </summary>
		[ColumnAttribute(Storage="_Result4", DbType="", CanBeNull=false)]
		public List<spMultiResults2Result> Result4
		{
			get
			{
				return this._Result4;
			}
			set
			{
				if (this._Result4 != value)
				{
					this._Result4 = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=
		/// </summary>
		[ColumnAttribute(Storage="_ReturnValue", DbType="", CanBeNull=false)]
		public int ReturnValue
		{
			get
			{
				return this._ReturnValue;
			}
			set
			{
				if (this._ReturnValue != value)
				{
					this._ReturnValue = value;
				}
			}
		}
		
	}
	#endregion spMultiResults2MultipleResults

	#region spRandomNumberMultipleResults
	public partial class spRandomNumberMultipleResults
	{
		#region Storage members
		private double _Random;
		private int _ReturnValue;
		#endregion Storage members

		public spRandomNumberMultipleResults(){ }

		/// <summary>
		/// Column DbType=
		/// </summary>
		[ColumnAttribute(Storage="_Random", DbType="", CanBeNull=false)]
		public double Random
		{
			get
			{
				return this._Random;
			}
			set
			{
				if (this._Random != value)
				{
					this._Random = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=
		/// </summary>
		[ColumnAttribute(Storage="_ReturnValue", DbType="", CanBeNull=false)]
		public int ReturnValue
		{
			get
			{
				return this._ReturnValue;
			}
			set
			{
				if (this._ReturnValue != value)
				{
					this._ReturnValue = value;
				}
			}
		}
		
	}
	#endregion spRandomNumberMultipleResults

	#region guest_fnGetStariNoviGranicaResult
	public partial class guest_fnGetStariNoviGranicaResult
	{
		#region Storage members
		private DateTime _StartDate;
		private DateTime _EndDate;
		#endregion Storage members

		public guest_fnGetStariNoviGranicaResult(){ }

		/// <summary>
		/// Column DbType=DateTime
		/// </summary>
		[ColumnAttribute(Storage="_StartDate", DbType="DateTime", CanBeNull=false)]
		public DateTime StartDate
		{
			get
			{
				return this._StartDate;
			}
			set
			{
				if (this._StartDate != value)
				{
					this._StartDate = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=DateTime
		/// </summary>
		[ColumnAttribute(Storage="_EndDate", DbType="DateTime", CanBeNull=false)]
		public DateTime EndDate
		{
			get
			{
				return this._EndDate;
			}
			set
			{
				if (this._EndDate != value)
				{
					this._EndDate = value;
				}
			}
		}
		
	}
	#endregion guest_fnGetStariNoviGranicaResult

	#region guest_spGetAppMembersMultipleResults
	public partial class guest_spGetAppMembersMultipleResults
	{
		#region Storage members
		private List<guest_spGetAppMembersResult1> _Result1;
		private List<guest_spGetAppMembersResult2> _Result2;
		private int _ReturnValue;
		#endregion Storage members

		public guest_spGetAppMembersMultipleResults(){ }

		/// <summary>
		/// Column DbType=
		/// </summary>
		[ColumnAttribute(Storage="_Result1", DbType="", CanBeNull=false)]
		public List<guest_spGetAppMembersResult1> Result1
		{
			get
			{
				return this._Result1;
			}
			set
			{
				if (this._Result1 != value)
				{
					this._Result1 = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=
		/// </summary>
		[ColumnAttribute(Storage="_Result2", DbType="", CanBeNull=false)]
		public List<guest_spGetAppMembersResult2> Result2
		{
			get
			{
				return this._Result2;
			}
			set
			{
				if (this._Result2 != value)
				{
					this._Result2 = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=
		/// </summary>
		[ColumnAttribute(Storage="_ReturnValue", DbType="", CanBeNull=false)]
		public int ReturnValue
		{
			get
			{
				return this._ReturnValue;
			}
			set
			{
				if (this._ReturnValue != value)
				{
					this._ReturnValue = value;
				}
			}
		}
		
	}
	#endregion guest_spGetAppMembersMultipleResults

	#region spMultiResultsResult1
	public partial class spMultiResultsResult1
	{
		#region Storage members
		private DateTime _CurrentDate1;
		#endregion Storage members

		public spMultiResultsResult1(){ }

		/// <summary>
		/// Column DbType=DateTime
		/// </summary>
		[ColumnAttribute(Storage="_CurrentDate1", DbType="DateTime", CanBeNull=false)]
		public DateTime CurrentDate1
		{
			get
			{
				return this._CurrentDate1;
			}
			set
			{
				if (this._CurrentDate1 != value)
				{
					this._CurrentDate1 = value;
				}
			}
		}
		
	}
	#endregion spMultiResultsResult1

	#region spMultiResultsResult2
	public partial class spMultiResultsResult2
	{
		#region Storage members
		private int _RowID;
		private int _Name;
		#endregion Storage members

		public spMultiResultsResult2(){ }

		/// <summary>
		/// Column DbType=Int
		/// </summary>
		[ColumnAttribute(Storage="_RowID", DbType="Int", CanBeNull=false)]
		public int RowID
		{
			get
			{
				return this._RowID;
			}
			set
			{
				if (this._RowID != value)
				{
					this._RowID = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Int
		/// </summary>
		[ColumnAttribute(Storage="_Name", DbType="Int", CanBeNull=false)]
		public int Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if (this._Name != value)
				{
					this._Name = value;
				}
			}
		}
		
	}
	#endregion spMultiResultsResult2

	#region spMultiResultsResult3
	public partial class spMultiResultsResult3
	{
		#region Storage members
		private string _Name;
		private string _Value;
		#endregion Storage members

		public spMultiResultsResult3(){ }

		/// <summary>
		/// Column DbType=VarChar(100)
		/// </summary>
		[ColumnAttribute(Storage="_Name", DbType="VarChar(100)", CanBeNull=true)]
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
					this._Name = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=VarChar(100)
		/// </summary>
		[ColumnAttribute(Storage="_Value", DbType="VarChar(100)", CanBeNull=true)]
		public string Value
		{
			get
			{
				return this._Value;
			}
			set
			{
				if (this._Value != value)
				{
					this._Value = value;
				}
			}
		}
		
	}
	#endregion spMultiResultsResult3

	#region spMultiResultsResult4
	public partial class spMultiResultsResult4
	{
		#region Storage members
		private DateTime _CurrentDate2;
		#endregion Storage members

		public spMultiResultsResult4(){ }

		/// <summary>
		/// Column DbType=DateTime
		/// </summary>
		[ColumnAttribute(Storage="_CurrentDate2", DbType="DateTime", CanBeNull=false)]
		public DateTime CurrentDate2
		{
			get
			{
				return this._CurrentDate2;
			}
			set
			{
				if (this._CurrentDate2 != value)
				{
					this._CurrentDate2 = value;
				}
			}
		}
		
	}
	#endregion spMultiResultsResult4

	#region spMultiResults2Result
	public partial class spMultiResults2Result
	{
		#region Storage members
		private int _Ordinal;
		private string _Name;
		#endregion Storage members

		public spMultiResults2Result(){ }

		/// <summary>
		/// Column DbType=Int
		/// </summary>
		[ColumnAttribute(Storage="_Ordinal", DbType="Int", CanBeNull=false)]
		public int Ordinal
		{
			get
			{
				return this._Ordinal;
			}
			set
			{
				if (this._Ordinal != value)
				{
					this._Ordinal = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=VarChar(6)
		/// </summary>
		[ColumnAttribute(Storage="_Name", DbType="VarChar(6)", CanBeNull=false)]
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
					this._Name = value;
				}
			}
		}
		
	}
	#endregion spMultiResults2Result

	#region guest_spGetAppMembersResult1
	public partial class guest_spGetAppMembersResult1
	{
		#region Storage members
		private int? _num;
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

		public guest_spGetAppMembersResult1(){ }

		/// <summary>
		/// Column DbType=Int
		/// </summary>
		[ColumnAttribute(Storage="_num", DbType="Int", CanBeNull=true)]
		public int? num
		{
			get
			{
				return this._num;
			}
			set
			{
				if (this._num != value)
				{
					this._num = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Int
		/// </summary>
		[ColumnAttribute(Storage="_AppMemberID", DbType="Int", CanBeNull=false)]
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
					this._AppMemberID = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Int
		/// </summary>
		[ColumnAttribute(Storage="_AppMemberStatusID", DbType="Int", CanBeNull=false)]
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
					this._AppMemberStatusID = value;
				}
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
					this._MSISDN = value;
				}
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
					this._FacebookId = value;
				}
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
					this._GoogleId = value;
				}
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
					this._Email = value;
				}
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
					this._Username = value;
				}
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
					this._Password = value;
				}
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
					this._BirthDate = value;
				}
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
					this._CreationDate = value;
				}
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
					this._LastLoginDate = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Int
		/// </summary>
		[ColumnAttribute(Storage="_LoginsCount", DbType="Int", CanBeNull=false)]
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
					this._LoginsCount = value;
				}
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
					this._FirstName = value;
				}
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
					this._LastName = value;
				}
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
					this._Gender = value;
				}
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
					this._PersonalNote = value;
				}
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
					this._WebUrl = value;
				}
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
					this._Address = value;
				}
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
					this._ZipCode = value;
				}
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
					this._City = value;
				}
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
					this._Country = value;
				}
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
					this._IP = value;
				}
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
					this._PosFirmaID = value;
				}
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
					this._IsQuizQuestionsEditor = value;
				}
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
					this._StanjeRacuna = value;
				}
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
					this._HomeMemberAddressID = value;
				}
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
					this._WorkMemberAddressID = value;
				}
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
					this._PrimaryMemberAddressID = value;
				}
			}
		}
		
	}
	#endregion guest_spGetAppMembersResult1

	#region guest_spGetAppMembersResult2
	public partial class guest_spGetAppMembersResult2
	{
		#region Storage members
		private int? _TotalCount;
		#endregion Storage members

		public guest_spGetAppMembersResult2(){ }

		/// <summary>
		/// Column DbType=Int
		/// </summary>
		[ColumnAttribute(Storage="_TotalCount", DbType="Int", CanBeNull=true)]
		public int? TotalCount
		{
			get
			{
				return this._TotalCount;
			}
			set
			{
				if (this._TotalCount != value)
				{
					this._TotalCount = value;
				}
			}
		}
		
	}
	#endregion guest_spGetAppMembersResult2

	#endregion Entity Return types

}
#pragma warning restore 1591
