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

namespace AdventureWorks.Database
{
	[DatabaseAttribute(Name="dbAdventureWorks")]
	public partial class AdventureWorksDataContext : Calysto.Data.Linq.DataContext
	{
		private static MappingSource mappingSource = new AttributeMappingSource();

		#region Extensibility Method Definitions
		partial void OnCreated();
		#endregion Extensibility Method Definitions

		#region Context constructors

		public AdventureWorksDataContext(string connection) : base(connection, mappingSource)
		{
			OnCreated();
		}

		public AdventureWorksDataContext(IDbConnection connection) : base(connection, mappingSource)
		{
			OnCreated();
		}

		public AdventureWorksDataContext(string connection, MappingSource mappingSource) : base(connection, mappingSource)
		{
			OnCreated();
		}

		public AdventureWorksDataContext(IDbConnection connection, MappingSource mappingSource) : base(connection, mappingSource)
		{
			OnCreated();
		}
		#endregion Context constructors

		#region Context properties for tables
		public Calysto.Data.Linq.Table<Person_Address> Person_Address { get { return this.GetTable<Person_Address>(); } }
		public Calysto.Data.Linq.Table<Person_AddressType> Person_AddressType { get { return this.GetTable<Person_AddressType>(); } }
		public Calysto.Data.Linq.Table<AWBuildVersion> AWBuildVersion { get { return this.GetTable<AWBuildVersion>(); } }
		public Calysto.Data.Linq.Table<Production_BillOfMaterials> Production_BillOfMaterials { get { return this.GetTable<Production_BillOfMaterials>(); } }
		public Calysto.Data.Linq.Table<Person_Contact> Person_Contact { get { return this.GetTable<Person_Contact>(); } }
		public Calysto.Data.Linq.Table<Sales_ContactCreditCard> Sales_ContactCreditCard { get { return this.GetTable<Sales_ContactCreditCard>(); } }
		public Calysto.Data.Linq.Table<Person_ContactType> Person_ContactType { get { return this.GetTable<Person_ContactType>(); } }
		public Calysto.Data.Linq.Table<Person_CountryRegion> Person_CountryRegion { get { return this.GetTable<Person_CountryRegion>(); } }
		public Calysto.Data.Linq.Table<Sales_CountryRegionCurrency> Sales_CountryRegionCurrency { get { return this.GetTable<Sales_CountryRegionCurrency>(); } }
		public Calysto.Data.Linq.Table<Sales_CreditCard> Sales_CreditCard { get { return this.GetTable<Sales_CreditCard>(); } }
		public Calysto.Data.Linq.Table<Production_Culture> Production_Culture { get { return this.GetTable<Production_Culture>(); } }
		public Calysto.Data.Linq.Table<Sales_Currency> Sales_Currency { get { return this.GetTable<Sales_Currency>(); } }
		public Calysto.Data.Linq.Table<Sales_CurrencyRate> Sales_CurrencyRate { get { return this.GetTable<Sales_CurrencyRate>(); } }
		public Calysto.Data.Linq.Table<Sales_Customer> Sales_Customer { get { return this.GetTable<Sales_Customer>(); } }
		public Calysto.Data.Linq.Table<Sales_CustomerAddress> Sales_CustomerAddress { get { return this.GetTable<Sales_CustomerAddress>(); } }
		public Calysto.Data.Linq.Table<DatabaseLog> DatabaseLog { get { return this.GetTable<DatabaseLog>(); } }
		public Calysto.Data.Linq.Table<HumanResources_Department> HumanResources_Department { get { return this.GetTable<HumanResources_Department>(); } }
		public Calysto.Data.Linq.Table<Production_Document> Production_Document { get { return this.GetTable<Production_Document>(); } }
		public Calysto.Data.Linq.Table<HumanResources_Employee> HumanResources_Employee { get { return this.GetTable<HumanResources_Employee>(); } }
		public Calysto.Data.Linq.Table<HumanResources_EmployeeAddress> HumanResources_EmployeeAddress { get { return this.GetTable<HumanResources_EmployeeAddress>(); } }
		public Calysto.Data.Linq.Table<HumanResources_EmployeeDepartmentHistory> HumanResources_EmployeeDepartmentHistory { get { return this.GetTable<HumanResources_EmployeeDepartmentHistory>(); } }
		public Calysto.Data.Linq.Table<HumanResources_EmployeePayHistory> HumanResources_EmployeePayHistory { get { return this.GetTable<HumanResources_EmployeePayHistory>(); } }
		public Calysto.Data.Linq.Table<ErrorLog> ErrorLog { get { return this.GetTable<ErrorLog>(); } }
		public Calysto.Data.Linq.Table<Production_Illustration> Production_Illustration { get { return this.GetTable<Production_Illustration>(); } }
		public Calysto.Data.Linq.Table<Sales_Individual> Sales_Individual { get { return this.GetTable<Sales_Individual>(); } }
		public Calysto.Data.Linq.Table<HumanResources_JobCandidate> HumanResources_JobCandidate { get { return this.GetTable<HumanResources_JobCandidate>(); } }
		public Calysto.Data.Linq.Table<Production_Location> Production_Location { get { return this.GetTable<Production_Location>(); } }
		public Calysto.Data.Linq.Table<Production_Product> Production_Product { get { return this.GetTable<Production_Product>(); } }
		public Calysto.Data.Linq.Table<Production_ProductCategory> Production_ProductCategory { get { return this.GetTable<Production_ProductCategory>(); } }
		public Calysto.Data.Linq.Table<Production_ProductCostHistory> Production_ProductCostHistory { get { return this.GetTable<Production_ProductCostHistory>(); } }
		public Calysto.Data.Linq.Table<Production_ProductDescription> Production_ProductDescription { get { return this.GetTable<Production_ProductDescription>(); } }
		public Calysto.Data.Linq.Table<Production_ProductDocument> Production_ProductDocument { get { return this.GetTable<Production_ProductDocument>(); } }
		public Calysto.Data.Linq.Table<Production_ProductInventory> Production_ProductInventory { get { return this.GetTable<Production_ProductInventory>(); } }
		public Calysto.Data.Linq.Table<Production_ProductListPriceHistory> Production_ProductListPriceHistory { get { return this.GetTable<Production_ProductListPriceHistory>(); } }
		public Calysto.Data.Linq.Table<Production_ProductModel> Production_ProductModel { get { return this.GetTable<Production_ProductModel>(); } }
		public Calysto.Data.Linq.Table<Production_ProductModelIllustration> Production_ProductModelIllustration { get { return this.GetTable<Production_ProductModelIllustration>(); } }
		public Calysto.Data.Linq.Table<Production_ProductModelProductDescriptionCulture> Production_ProductModelProductDescriptionCulture { get { return this.GetTable<Production_ProductModelProductDescriptionCulture>(); } }
		public Calysto.Data.Linq.Table<Production_ProductPhoto> Production_ProductPhoto { get { return this.GetTable<Production_ProductPhoto>(); } }
		public Calysto.Data.Linq.Table<Production_ProductProductPhoto> Production_ProductProductPhoto { get { return this.GetTable<Production_ProductProductPhoto>(); } }
		public Calysto.Data.Linq.Table<Production_ProductReview> Production_ProductReview { get { return this.GetTable<Production_ProductReview>(); } }
		public Calysto.Data.Linq.Table<Production_ProductSubcategory> Production_ProductSubcategory { get { return this.GetTable<Production_ProductSubcategory>(); } }
		public Calysto.Data.Linq.Table<Purchasing_ProductVendor> Purchasing_ProductVendor { get { return this.GetTable<Purchasing_ProductVendor>(); } }
		public Calysto.Data.Linq.Table<Purchasing_PurchaseOrderDetail> Purchasing_PurchaseOrderDetail { get { return this.GetTable<Purchasing_PurchaseOrderDetail>(); } }
		public Calysto.Data.Linq.Table<Purchasing_PurchaseOrderHeader> Purchasing_PurchaseOrderHeader { get { return this.GetTable<Purchasing_PurchaseOrderHeader>(); } }
		public Calysto.Data.Linq.Table<Sales_SalesOrderDetail> Sales_SalesOrderDetail { get { return this.GetTable<Sales_SalesOrderDetail>(); } }
		public Calysto.Data.Linq.Table<Sales_SalesOrderHeader> Sales_SalesOrderHeader { get { return this.GetTable<Sales_SalesOrderHeader>(); } }
		public Calysto.Data.Linq.Table<Sales_SalesOrderHeaderSalesReason> Sales_SalesOrderHeaderSalesReason { get { return this.GetTable<Sales_SalesOrderHeaderSalesReason>(); } }
		public Calysto.Data.Linq.Table<Sales_SalesPerson> Sales_SalesPerson { get { return this.GetTable<Sales_SalesPerson>(); } }
		public Calysto.Data.Linq.Table<Sales_SalesPersonQuotaHistory> Sales_SalesPersonQuotaHistory { get { return this.GetTable<Sales_SalesPersonQuotaHistory>(); } }
		public Calysto.Data.Linq.Table<Sales_SalesReason> Sales_SalesReason { get { return this.GetTable<Sales_SalesReason>(); } }
		public Calysto.Data.Linq.Table<Sales_SalesTaxRate> Sales_SalesTaxRate { get { return this.GetTable<Sales_SalesTaxRate>(); } }
		public Calysto.Data.Linq.Table<Sales_SalesTerritory> Sales_SalesTerritory { get { return this.GetTable<Sales_SalesTerritory>(); } }
		public Calysto.Data.Linq.Table<Sales_SalesTerritoryHistory> Sales_SalesTerritoryHistory { get { return this.GetTable<Sales_SalesTerritoryHistory>(); } }
		public Calysto.Data.Linq.Table<Production_ScrapReason> Production_ScrapReason { get { return this.GetTable<Production_ScrapReason>(); } }
		public Calysto.Data.Linq.Table<HumanResources_Shift> HumanResources_Shift { get { return this.GetTable<HumanResources_Shift>(); } }
		public Calysto.Data.Linq.Table<Purchasing_ShipMethod> Purchasing_ShipMethod { get { return this.GetTable<Purchasing_ShipMethod>(); } }
		public Calysto.Data.Linq.Table<Sales_ShoppingCartItem> Sales_ShoppingCartItem { get { return this.GetTable<Sales_ShoppingCartItem>(); } }
		public Calysto.Data.Linq.Table<Sales_SpecialOffer> Sales_SpecialOffer { get { return this.GetTable<Sales_SpecialOffer>(); } }
		public Calysto.Data.Linq.Table<Sales_SpecialOfferProduct> Sales_SpecialOfferProduct { get { return this.GetTable<Sales_SpecialOfferProduct>(); } }
		public Calysto.Data.Linq.Table<Person_StateProvince> Person_StateProvince { get { return this.GetTable<Person_StateProvince>(); } }
		public Calysto.Data.Linq.Table<Sales_Store> Sales_Store { get { return this.GetTable<Sales_Store>(); } }
		public Calysto.Data.Linq.Table<Sales_StoreContact> Sales_StoreContact { get { return this.GetTable<Sales_StoreContact>(); } }
		public Calysto.Data.Linq.Table<Production_TransactionHistory> Production_TransactionHistory { get { return this.GetTable<Production_TransactionHistory>(); } }
		public Calysto.Data.Linq.Table<Production_TransactionHistoryArchive> Production_TransactionHistoryArchive { get { return this.GetTable<Production_TransactionHistoryArchive>(); } }
		public Calysto.Data.Linq.Table<Production_UnitMeasure> Production_UnitMeasure { get { return this.GetTable<Production_UnitMeasure>(); } }
		public Calysto.Data.Linq.Table<Person_vAdditionalContactInfo> Person_vAdditionalContactInfo { get { return this.GetTable<Person_vAdditionalContactInfo>(); } }
		public Calysto.Data.Linq.Table<HumanResources_vEmployee> HumanResources_vEmployee { get { return this.GetTable<HumanResources_vEmployee>(); } }
		public Calysto.Data.Linq.Table<HumanResources_vEmployeeDepartment> HumanResources_vEmployeeDepartment { get { return this.GetTable<HumanResources_vEmployeeDepartment>(); } }
		public Calysto.Data.Linq.Table<HumanResources_vEmployeeDepartmentHistory> HumanResources_vEmployeeDepartmentHistory { get { return this.GetTable<HumanResources_vEmployeeDepartmentHistory>(); } }
		public Calysto.Data.Linq.Table<Purchasing_Vendor> Purchasing_Vendor { get { return this.GetTable<Purchasing_Vendor>(); } }
		public Calysto.Data.Linq.Table<Purchasing_VendorAddress> Purchasing_VendorAddress { get { return this.GetTable<Purchasing_VendorAddress>(); } }
		public Calysto.Data.Linq.Table<Purchasing_VendorContact> Purchasing_VendorContact { get { return this.GetTable<Purchasing_VendorContact>(); } }
		public Calysto.Data.Linq.Table<Sales_vIndividualCustomer> Sales_vIndividualCustomer { get { return this.GetTable<Sales_vIndividualCustomer>(); } }
		public Calysto.Data.Linq.Table<Sales_vIndividualDemographics> Sales_vIndividualDemographics { get { return this.GetTable<Sales_vIndividualDemographics>(); } }
		public Calysto.Data.Linq.Table<HumanResources_vJobCandidate> HumanResources_vJobCandidate { get { return this.GetTable<HumanResources_vJobCandidate>(); } }
		public Calysto.Data.Linq.Table<HumanResources_vJobCandidateEducation> HumanResources_vJobCandidateEducation { get { return this.GetTable<HumanResources_vJobCandidateEducation>(); } }
		public Calysto.Data.Linq.Table<HumanResources_vJobCandidateEmployment> HumanResources_vJobCandidateEmployment { get { return this.GetTable<HumanResources_vJobCandidateEmployment>(); } }
		public Calysto.Data.Linq.Table<Production_vProductAndDescription> Production_vProductAndDescription { get { return this.GetTable<Production_vProductAndDescription>(); } }
		public Calysto.Data.Linq.Table<Production_vProductModelCatalogDescription> Production_vProductModelCatalogDescription { get { return this.GetTable<Production_vProductModelCatalogDescription>(); } }
		public Calysto.Data.Linq.Table<Production_vProductModelInstructions> Production_vProductModelInstructions { get { return this.GetTable<Production_vProductModelInstructions>(); } }
		public Calysto.Data.Linq.Table<Sales_vSalesPerson> Sales_vSalesPerson { get { return this.GetTable<Sales_vSalesPerson>(); } }
		public Calysto.Data.Linq.Table<Sales_vSalesPersonSalesByFiscalYears> Sales_vSalesPersonSalesByFiscalYears { get { return this.GetTable<Sales_vSalesPersonSalesByFiscalYears>(); } }
		public Calysto.Data.Linq.Table<Person_vStateProvinceCountryRegion> Person_vStateProvinceCountryRegion { get { return this.GetTable<Person_vStateProvinceCountryRegion>(); } }
		public Calysto.Data.Linq.Table<Sales_vStoreWithDemographics> Sales_vStoreWithDemographics { get { return this.GetTable<Sales_vStoreWithDemographics>(); } }
		public Calysto.Data.Linq.Table<Purchasing_vVendor> Purchasing_vVendor { get { return this.GetTable<Purchasing_vVendor>(); } }
		public Calysto.Data.Linq.Table<Production_WorkOrder> Production_WorkOrder { get { return this.GetTable<Production_WorkOrder>(); } }
		public Calysto.Data.Linq.Table<Production_WorkOrderRouting> Production_WorkOrderRouting { get { return this.GetTable<Production_WorkOrderRouting>(); } }
		#endregion Context properties for tables

		#region Context database functions
		[FunctionAttribute(Name="dbo.ufnGetAccountingEndDate", IsComposable=true)]
		public DateTime? ufnGetAccountingEndDate(
		)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())));
			return ((DateTime?) result.ReturnValue);
		}

		[FunctionAttribute(Name="dbo.ufnGetAccountingStartDate", IsComposable=true)]
		public DateTime? ufnGetAccountingStartDate(
		)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())));
			return ((DateTime?) result.ReturnValue);
		}

		[FunctionAttribute(Name="dbo.ufnGetContactInformation", IsComposable=true)]
		public ISingleResult<ufnGetContactInformationResult> ufnGetContactInformation(
			[ParameterAttribute(DbType="Int")] int? ContactID
		)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), ContactID);
			return ((ISingleResult<ufnGetContactInformationResult>) result.ReturnValue);
		}

		[FunctionAttribute(Name="dbo.ufnGetDocumentStatusText", IsComposable=true)]
		public string ufnGetDocumentStatusText(
			[ParameterAttribute(DbType="TinyInt")] byte? Status
		)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), Status);
			return ((string) result.ReturnValue);
		}

		[FunctionAttribute(Name="dbo.ufnGetProductDealerPrice", IsComposable=true)]
		public decimal? ufnGetProductDealerPrice(
			[ParameterAttribute(DbType="Int")] int? ProductID,
			[ParameterAttribute(DbType="DateTime")] DateTime? OrderDate
		)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), ProductID, OrderDate);
			return ((decimal?) result.ReturnValue);
		}

		[FunctionAttribute(Name="dbo.ufnGetProductListPrice", IsComposable=true)]
		public decimal? ufnGetProductListPrice(
			[ParameterAttribute(DbType="Int")] int? ProductID,
			[ParameterAttribute(DbType="DateTime")] DateTime? OrderDate
		)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), ProductID, OrderDate);
			return ((decimal?) result.ReturnValue);
		}

		[FunctionAttribute(Name="dbo.ufnGetProductStandardCost", IsComposable=true)]
		public decimal? ufnGetProductStandardCost(
			[ParameterAttribute(DbType="Int")] int? ProductID,
			[ParameterAttribute(DbType="DateTime")] DateTime? OrderDate
		)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), ProductID, OrderDate);
			return ((decimal?) result.ReturnValue);
		}

		[FunctionAttribute(Name="dbo.ufnGetPurchaseOrderStatusText", IsComposable=true)]
		public string ufnGetPurchaseOrderStatusText(
			[ParameterAttribute(DbType="TinyInt")] byte? Status
		)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), Status);
			return ((string) result.ReturnValue);
		}

		[FunctionAttribute(Name="dbo.ufnGetSalesOrderStatusText", IsComposable=true)]
		public string ufnGetSalesOrderStatusText(
			[ParameterAttribute(DbType="TinyInt")] byte? Status
		)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), Status);
			return ((string) result.ReturnValue);
		}

		[FunctionAttribute(Name="dbo.ufnGetStock", IsComposable=true)]
		public int? ufnGetStock(
			[ParameterAttribute(DbType="Int")] int? ProductID
		)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), ProductID);
			return ((int?) result.ReturnValue);
		}

		[FunctionAttribute(Name="dbo.ufnLeadingZeros", IsComposable=true)]
		public string ufnLeadingZeros(
			[ParameterAttribute(DbType="Int")] int? Value
		)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), Value);
			return ((string) result.ReturnValue);
		}

		#endregion Context database functions

	}

	#region Entity Tables

		#region Person.Address
		[TableAttribute(Name="Person.Address")]
		public partial class Person_Address : EntityBase<Person_Address, AdventureWorksDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private int _AddressID;
			private string _AddressLine1;
			private string _AddressLine2;
			private string _City;
			private int _StateProvinceID;
			private string _PostalCode;
			private System.Guid _rowguid;
			private DateTime _ModifiedDate;
			private EntitySet<HumanResources_EmployeeAddress> _HumanResources_EmployeeAddressList;
			private EntityRef<Person_StateProvince> _Person_StateProvince;
			private EntitySet<Purchasing_VendorAddress> _Purchasing_VendorAddressList;
			private EntitySet<Sales_CustomerAddress> _Sales_CustomerAddressList;
			private EntitySet<Sales_SalesOrderHeader> _Sales_SalesOrderHeaderList;
			private EntitySet<Sales_SalesOrderHeader> _AddressList;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnAddressIDChanging(int value);
			partial void OnAddressIDChanged();
			partial void OnAddressLine1Changing(string value);
			partial void OnAddressLine1Changed();
			partial void OnAddressLine2Changing(string value);
			partial void OnAddressLine2Changed();
			partial void OnCityChanging(string value);
			partial void OnCityChanged();
			partial void OnStateProvinceIDChanging(int value);
			partial void OnStateProvinceIDChanged();
			partial void OnPostalCodeChanging(string value);
			partial void OnPostalCodeChanged();
			partial void OnrowguidChanging(System.Guid value);
			partial void OnrowguidChanged();
			partial void OnModifiedDateChanging(DateTime value);
			partial void OnModifiedDateChanged();
			#endregion

			public Person_Address()
			{
				_HumanResources_EmployeeAddressList = new EntitySet<HumanResources_EmployeeAddress>(
					new Action<HumanResources_EmployeeAddress>(item=>{this.SendPropertyChanging(); item.Person_Address=this;}), 
					new Action<HumanResources_EmployeeAddress>(item=>{this.SendPropertyChanging(); item.Person_Address=null;}));
				_Person_StateProvince = default(EntityRef<Person_StateProvince>);
				_Purchasing_VendorAddressList = new EntitySet<Purchasing_VendorAddress>(
					new Action<Purchasing_VendorAddress>(item=>{this.SendPropertyChanging(); item.Person_Address=this;}), 
					new Action<Purchasing_VendorAddress>(item=>{this.SendPropertyChanging(); item.Person_Address=null;}));
				_Sales_CustomerAddressList = new EntitySet<Sales_CustomerAddress>(
					new Action<Sales_CustomerAddress>(item=>{this.SendPropertyChanging(); item.Person_Address=this;}), 
					new Action<Sales_CustomerAddress>(item=>{this.SendPropertyChanging(); item.Person_Address=null;}));
				_Sales_SalesOrderHeaderList = new EntitySet<Sales_SalesOrderHeader>(
					new Action<Sales_SalesOrderHeader>(item=>{this.SendPropertyChanging(); item.Person_Address=this;}), 
					new Action<Sales_SalesOrderHeader>(item=>{this.SendPropertyChanging(); item.Person_Address=null;}));
				_AddressList = new EntitySet<Sales_SalesOrderHeader>(
					new Action<Sales_SalesOrderHeader>(item=>{this.SendPropertyChanging(); item.ShipToAddress=this;}), 
					new Action<Sales_SalesOrderHeader>(item=>{this.SendPropertyChanging(); item.ShipToAddress=null;}));
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=Int NOT NULL IDENTITY
			/// </summary>
			[ColumnAttribute(Storage="_AddressID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", CanBeNull=false, IsPrimaryKey=true, IsDbGenerated=true)]
			public int AddressID
			{
				get
				{
					return this._AddressID;
				}
				set
				{
					if (this._AddressID != value)
					{
						this.OnAddressIDChanging(value);
						this.SendPropertyChanging();
						this._AddressID = value;
						this.SendPropertyChanged("AddressID");
						this.OnAddressIDChanged();
					}
					this.SendPropertySetterInvoked("AddressID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(60) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_AddressLine1", DbType="NVarChar(60) NOT NULL", CanBeNull=false)]
			public string AddressLine1
			{
				get
				{
					return this._AddressLine1;
				}
				set
				{
					if (this._AddressLine1 != value)
					{
						this.OnAddressLine1Changing(value);
						this.SendPropertyChanging();
						this._AddressLine1 = value;
						this.SendPropertyChanged("AddressLine1");
						this.OnAddressLine1Changed();
					}
					this.SendPropertySetterInvoked("AddressLine1", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(60)
			/// </summary>
			[ColumnAttribute(Storage="_AddressLine2", DbType="NVarChar(60)", CanBeNull=true)]
			public string AddressLine2
			{
				get
				{
					return this._AddressLine2;
				}
				set
				{
					if (this._AddressLine2 != value)
					{
						this.OnAddressLine2Changing(value);
						this.SendPropertyChanging();
						this._AddressLine2 = value;
						this.SendPropertyChanged("AddressLine2");
						this.OnAddressLine2Changed();
					}
					this.SendPropertySetterInvoked("AddressLine2", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(30) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_City", DbType="NVarChar(30) NOT NULL", CanBeNull=false)]
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
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_StateProvinceID", DbType="Int NOT NULL", CanBeNull=false)]
			public int StateProvinceID
			{
				get
				{
					return this._StateProvinceID;
				}
				set
				{
					if (this._StateProvinceID != value)
					{
						this.OnStateProvinceIDChanging(value);
						this.SendPropertyChanging();
						this._StateProvinceID = value;
						this.SendPropertyChanged("StateProvinceID");
						this.OnStateProvinceIDChanged();
					}
					this.SendPropertySetterInvoked("StateProvinceID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(15) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_PostalCode", DbType="NVarChar(15) NOT NULL", CanBeNull=false)]
			public string PostalCode
			{
				get
				{
					return this._PostalCode;
				}
				set
				{
					if (this._PostalCode != value)
					{
						this.OnPostalCodeChanging(value);
						this.SendPropertyChanging();
						this._PostalCode = value;
						this.SendPropertyChanged("PostalCode");
						this.OnPostalCodeChanged();
					}
					this.SendPropertySetterInvoked("PostalCode", value);
				}
			}
			
			/// <summary>
			/// Column DbType=UniqueIdentifier NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_rowguid", DbType="UniqueIdentifier NOT NULL", CanBeNull=false)]
			public System.Guid rowguid
			{
				get
				{
					return this._rowguid;
				}
				set
				{
					if (this._rowguid != value)
					{
						this.OnrowguidChanging(value);
						this.SendPropertyChanging();
						this._rowguid = value;
						this.SendPropertyChanged("rowguid");
						this.OnrowguidChanged();
					}
					this.SendPropertySetterInvoked("rowguid", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ModifiedDate", DbType="DateTime NOT NULL", CanBeNull=false)]
			public DateTime ModifiedDate
			{
				get
				{
					return this._ModifiedDate;
				}
				set
				{
					if (this._ModifiedDate != value)
					{
						this.OnModifiedDateChanging(value);
						this.SendPropertyChanging();
						this._ModifiedDate = value;
						this.SendPropertyChanged("ModifiedDate");
						this.OnModifiedDateChanged();
					}
					this.SendPropertySetterInvoked("ModifiedDate", value);
				}
			}
			
			#endregion Columns

			#region Associations
			/// <summary>
			/// Association [PK][One]Person_Address.AddressID --- [FK][Many]HumanResources_EmployeeAddress.AddressID
			/// </summary>
			[AssociationAttribute(Name="FK_EmployeeAddress_Address_AddressID", Storage="_HumanResources_EmployeeAddressList", ThisKey="AddressID", OtherKey="AddressID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<HumanResources_EmployeeAddress> HumanResources_EmployeeAddressList
			{
				get { return this._HumanResources_EmployeeAddressList; }
				set { this._HumanResources_EmployeeAddressList.Assign(value); }
			}
			
			/// <summary>
			/// Association [FK][Many]Person_Address.StateProvinceID --- [PK][One]Person_StateProvince.StateProvinceID
			/// </summary>
			[AssociationAttribute(Name="FK_Address_StateProvince_StateProvinceID", Storage="_Person_StateProvince", ThisKey="StateProvinceID", OtherKey="StateProvinceID", IsUnique=false, IsForeignKey=true)]
			public Person_StateProvince Person_StateProvince
			{
				get
				{
					return this._Person_StateProvince.Entity;
				}
				set
				{
					Person_StateProvince previousValue = this._Person_StateProvince.Entity;
					if ((previousValue != value) || (this._Person_StateProvince.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._Person_StateProvince.Entity = null;
							previousValue.Person_AddressList.Remove(this);
						}
						this._Person_StateProvince.Entity = value;
						if (value != null)
						{
							value.Person_AddressList.Add(this);
							this._StateProvinceID = value.StateProvinceID;
						}
						else
						{
							this._StateProvinceID = default(int);
						}
						this.SendPropertyChanged("Person_StateProvince");
					}
					this.SendPropertySetterInvoked("Person_StateProvince", value);
				}
			}
			
			/// <summary>
			/// Association [PK][One]Person_Address.AddressID --- [FK][Many]Purchasing_VendorAddress.AddressID
			/// </summary>
			[AssociationAttribute(Name="FK_VendorAddress_Address_AddressID", Storage="_Purchasing_VendorAddressList", ThisKey="AddressID", OtherKey="AddressID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<Purchasing_VendorAddress> Purchasing_VendorAddressList
			{
				get { return this._Purchasing_VendorAddressList; }
				set { this._Purchasing_VendorAddressList.Assign(value); }
			}
			
			/// <summary>
			/// Association [PK][One]Person_Address.AddressID --- [FK][Many]Sales_CustomerAddress.AddressID
			/// </summary>
			[AssociationAttribute(Name="FK_CustomerAddress_Address_AddressID", Storage="_Sales_CustomerAddressList", ThisKey="AddressID", OtherKey="AddressID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<Sales_CustomerAddress> Sales_CustomerAddressList
			{
				get { return this._Sales_CustomerAddressList; }
				set { this._Sales_CustomerAddressList.Assign(value); }
			}
			
			/// <summary>
			/// Association [PK][One]Person_Address.AddressID --- [FK][Many]Sales_SalesOrderHeader.BillToAddressID
			/// </summary>
			[AssociationAttribute(Name="FK_SalesOrderHeader_Address_BillToAddressID", Storage="_Sales_SalesOrderHeaderList", ThisKey="AddressID", OtherKey="BillToAddressID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<Sales_SalesOrderHeader> Sales_SalesOrderHeaderList
			{
				get { return this._Sales_SalesOrderHeaderList; }
				set { this._Sales_SalesOrderHeaderList.Assign(value); }
			}
			
			/// <summary>
			/// Association [PK][One]Person_Address.AddressID --- [FK][Many]Sales_SalesOrderHeader.ShipToAddressID
			/// </summary>
			[AssociationAttribute(Name="FK_SalesOrderHeader_Address_ShipToAddressID", Storage="_AddressList", ThisKey="AddressID", OtherKey="ShipToAddressID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<Sales_SalesOrderHeader> AddressList
			{
				get { return this._AddressList; }
				set { this._AddressList.Assign(value); }
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
		#endregion Person.Address

		#region Person.AddressType
		[TableAttribute(Name="Person.AddressType")]
		public partial class Person_AddressType : EntityBase<Person_AddressType, AdventureWorksDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private int _AddressTypeID;
			private string _Name;
			private System.Guid _rowguid;
			private DateTime _ModifiedDate;
			private EntitySet<Purchasing_VendorAddress> _Purchasing_VendorAddressList;
			private EntitySet<Sales_CustomerAddress> _Sales_CustomerAddressList;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnAddressTypeIDChanging(int value);
			partial void OnAddressTypeIDChanged();
			partial void OnNameChanging(string value);
			partial void OnNameChanged();
			partial void OnrowguidChanging(System.Guid value);
			partial void OnrowguidChanged();
			partial void OnModifiedDateChanging(DateTime value);
			partial void OnModifiedDateChanged();
			#endregion

			public Person_AddressType()
			{
				_Purchasing_VendorAddressList = new EntitySet<Purchasing_VendorAddress>(
					new Action<Purchasing_VendorAddress>(item=>{this.SendPropertyChanging(); item.Person_AddressType=this;}), 
					new Action<Purchasing_VendorAddress>(item=>{this.SendPropertyChanging(); item.Person_AddressType=null;}));
				_Sales_CustomerAddressList = new EntitySet<Sales_CustomerAddress>(
					new Action<Sales_CustomerAddress>(item=>{this.SendPropertyChanging(); item.Person_AddressType=this;}), 
					new Action<Sales_CustomerAddress>(item=>{this.SendPropertyChanging(); item.Person_AddressType=null;}));
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=Int NOT NULL IDENTITY
			/// </summary>
			[ColumnAttribute(Storage="_AddressTypeID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", CanBeNull=false, IsPrimaryKey=true, IsDbGenerated=true)]
			public int AddressTypeID
			{
				get
				{
					return this._AddressTypeID;
				}
				set
				{
					if (this._AddressTypeID != value)
					{
						this.OnAddressTypeIDChanging(value);
						this.SendPropertyChanging();
						this._AddressTypeID = value;
						this.SendPropertyChanged("AddressTypeID");
						this.OnAddressTypeIDChanged();
					}
					this.SendPropertySetterInvoked("AddressTypeID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(50) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_Name", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
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
			/// Column DbType=UniqueIdentifier NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_rowguid", DbType="UniqueIdentifier NOT NULL", CanBeNull=false)]
			public System.Guid rowguid
			{
				get
				{
					return this._rowguid;
				}
				set
				{
					if (this._rowguid != value)
					{
						this.OnrowguidChanging(value);
						this.SendPropertyChanging();
						this._rowguid = value;
						this.SendPropertyChanged("rowguid");
						this.OnrowguidChanged();
					}
					this.SendPropertySetterInvoked("rowguid", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ModifiedDate", DbType="DateTime NOT NULL", CanBeNull=false)]
			public DateTime ModifiedDate
			{
				get
				{
					return this._ModifiedDate;
				}
				set
				{
					if (this._ModifiedDate != value)
					{
						this.OnModifiedDateChanging(value);
						this.SendPropertyChanging();
						this._ModifiedDate = value;
						this.SendPropertyChanged("ModifiedDate");
						this.OnModifiedDateChanged();
					}
					this.SendPropertySetterInvoked("ModifiedDate", value);
				}
			}
			
			#endregion Columns

			#region Associations
			/// <summary>
			/// Association [PK][One]Person_AddressType.AddressTypeID --- [FK][Many]Purchasing_VendorAddress.AddressTypeID
			/// </summary>
			[AssociationAttribute(Name="FK_VendorAddress_AddressType_AddressTypeID", Storage="_Purchasing_VendorAddressList", ThisKey="AddressTypeID", OtherKey="AddressTypeID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<Purchasing_VendorAddress> Purchasing_VendorAddressList
			{
				get { return this._Purchasing_VendorAddressList; }
				set { this._Purchasing_VendorAddressList.Assign(value); }
			}
			
			/// <summary>
			/// Association [PK][One]Person_AddressType.AddressTypeID --- [FK][Many]Sales_CustomerAddress.AddressTypeID
			/// </summary>
			[AssociationAttribute(Name="FK_CustomerAddress_AddressType_AddressTypeID", Storage="_Sales_CustomerAddressList", ThisKey="AddressTypeID", OtherKey="AddressTypeID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<Sales_CustomerAddress> Sales_CustomerAddressList
			{
				get { return this._Sales_CustomerAddressList; }
				set { this._Sales_CustomerAddressList.Assign(value); }
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
		#endregion Person.AddressType

		#region dbo.AWBuildVersion
		[TableAttribute(Name="dbo.AWBuildVersion")]
		public partial class AWBuildVersion : EntityBase<AWBuildVersion, AdventureWorksDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private byte _SystemInformationID;
			private string _DatabaseVersion;
			private DateTime _VersionDate;
			private DateTime _ModifiedDate;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnSystemInformationIDChanging(byte value);
			partial void OnSystemInformationIDChanged();
			partial void OnDatabaseVersionChanging(string value);
			partial void OnDatabaseVersionChanged();
			partial void OnVersionDateChanging(DateTime value);
			partial void OnVersionDateChanged();
			partial void OnModifiedDateChanging(DateTime value);
			partial void OnModifiedDateChanged();
			#endregion

			public AWBuildVersion()
			{
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=TinyInt NOT NULL IDENTITY
			/// </summary>
			[ColumnAttribute(Storage="_SystemInformationID", AutoSync=AutoSync.OnInsert, DbType="TinyInt NOT NULL IDENTITY", CanBeNull=false, IsPrimaryKey=true, IsDbGenerated=true)]
			public byte SystemInformationID
			{
				get
				{
					return this._SystemInformationID;
				}
				set
				{
					if (this._SystemInformationID != value)
					{
						this.OnSystemInformationIDChanging(value);
						this.SendPropertyChanging();
						this._SystemInformationID = value;
						this.SendPropertyChanged("SystemInformationID");
						this.OnSystemInformationIDChanged();
					}
					this.SendPropertySetterInvoked("SystemInformationID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(25) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_DatabaseVersion", DbType="NVarChar(25) NOT NULL", CanBeNull=false)]
			public string DatabaseVersion
			{
				get
				{
					return this._DatabaseVersion;
				}
				set
				{
					if (this._DatabaseVersion != value)
					{
						this.OnDatabaseVersionChanging(value);
						this.SendPropertyChanging();
						this._DatabaseVersion = value;
						this.SendPropertyChanged("DatabaseVersion");
						this.OnDatabaseVersionChanged();
					}
					this.SendPropertySetterInvoked("DatabaseVersion", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_VersionDate", DbType="DateTime NOT NULL", CanBeNull=false)]
			public DateTime VersionDate
			{
				get
				{
					return this._VersionDate;
				}
				set
				{
					if (this._VersionDate != value)
					{
						this.OnVersionDateChanging(value);
						this.SendPropertyChanging();
						this._VersionDate = value;
						this.SendPropertyChanged("VersionDate");
						this.OnVersionDateChanged();
					}
					this.SendPropertySetterInvoked("VersionDate", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ModifiedDate", DbType="DateTime NOT NULL", CanBeNull=false)]
			public DateTime ModifiedDate
			{
				get
				{
					return this._ModifiedDate;
				}
				set
				{
					if (this._ModifiedDate != value)
					{
						this.OnModifiedDateChanging(value);
						this.SendPropertyChanging();
						this._ModifiedDate = value;
						this.SendPropertyChanged("ModifiedDate");
						this.OnModifiedDateChanged();
					}
					this.SendPropertySetterInvoked("ModifiedDate", value);
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
		#endregion dbo.AWBuildVersion

		#region Production.BillOfMaterials
		[TableAttribute(Name="Production.BillOfMaterials")]
		public partial class Production_BillOfMaterials : EntityBase<Production_BillOfMaterials, AdventureWorksDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private int _BillOfMaterialsID;
			private int? _ProductAssemblyID;
			private int _ComponentID;
			private DateTime _StartDate;
			private DateTime? _EndDate;
			private string _UnitMeasureCode;
			private System.Int16 _BOMLevel;
			private decimal _PerAssemblyQty;
			private DateTime _ModifiedDate;
			private EntityRef<Production_Product> _Production_Product;
			private EntityRef<Production_Product> _ProductAssembly;
			private EntityRef<Production_UnitMeasure> _Production_UnitMeasure;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnBillOfMaterialsIDChanging(int value);
			partial void OnBillOfMaterialsIDChanged();
			partial void OnProductAssemblyIDChanging(int? value);
			partial void OnProductAssemblyIDChanged();
			partial void OnComponentIDChanging(int value);
			partial void OnComponentIDChanged();
			partial void OnStartDateChanging(DateTime value);
			partial void OnStartDateChanged();
			partial void OnEndDateChanging(DateTime? value);
			partial void OnEndDateChanged();
			partial void OnUnitMeasureCodeChanging(string value);
			partial void OnUnitMeasureCodeChanged();
			partial void OnBOMLevelChanging(System.Int16 value);
			partial void OnBOMLevelChanged();
			partial void OnPerAssemblyQtyChanging(decimal value);
			partial void OnPerAssemblyQtyChanged();
			partial void OnModifiedDateChanging(DateTime value);
			partial void OnModifiedDateChanged();
			#endregion

			public Production_BillOfMaterials()
			{
				_Production_Product = default(EntityRef<Production_Product>);
				_ProductAssembly = default(EntityRef<Production_Product>);
				_Production_UnitMeasure = default(EntityRef<Production_UnitMeasure>);
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=Int NOT NULL IDENTITY
			/// </summary>
			[ColumnAttribute(Storage="_BillOfMaterialsID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", CanBeNull=false, IsPrimaryKey=true, IsDbGenerated=true)]
			public int BillOfMaterialsID
			{
				get
				{
					return this._BillOfMaterialsID;
				}
				set
				{
					if (this._BillOfMaterialsID != value)
					{
						this.OnBillOfMaterialsIDChanging(value);
						this.SendPropertyChanging();
						this._BillOfMaterialsID = value;
						this.SendPropertyChanged("BillOfMaterialsID");
						this.OnBillOfMaterialsIDChanged();
					}
					this.SendPropertySetterInvoked("BillOfMaterialsID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int
			/// </summary>
			[ColumnAttribute(Storage="_ProductAssemblyID", DbType="Int", CanBeNull=true)]
			public int? ProductAssemblyID
			{
				get
				{
					return this._ProductAssemblyID;
				}
				set
				{
					if (this._ProductAssemblyID != value)
					{
						this.OnProductAssemblyIDChanging(value);
						this.SendPropertyChanging();
						this._ProductAssemblyID = value;
						this.SendPropertyChanged("ProductAssemblyID");
						this.OnProductAssemblyIDChanged();
					}
					this.SendPropertySetterInvoked("ProductAssemblyID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ComponentID", DbType="Int NOT NULL", CanBeNull=false)]
			public int ComponentID
			{
				get
				{
					return this._ComponentID;
				}
				set
				{
					if (this._ComponentID != value)
					{
						this.OnComponentIDChanging(value);
						this.SendPropertyChanging();
						this._ComponentID = value;
						this.SendPropertyChanged("ComponentID");
						this.OnComponentIDChanged();
					}
					this.SendPropertySetterInvoked("ComponentID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_StartDate", DbType="DateTime NOT NULL", CanBeNull=false)]
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
						this.OnStartDateChanging(value);
						this.SendPropertyChanging();
						this._StartDate = value;
						this.SendPropertyChanged("StartDate");
						this.OnStartDateChanged();
					}
					this.SendPropertySetterInvoked("StartDate", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime
			/// </summary>
			[ColumnAttribute(Storage="_EndDate", DbType="DateTime", CanBeNull=true)]
			public DateTime? EndDate
			{
				get
				{
					return this._EndDate;
				}
				set
				{
					if (this._EndDate != value)
					{
						this.OnEndDateChanging(value);
						this.SendPropertyChanging();
						this._EndDate = value;
						this.SendPropertyChanged("EndDate");
						this.OnEndDateChanged();
					}
					this.SendPropertySetterInvoked("EndDate", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NChar(3) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_UnitMeasureCode", DbType="NChar(3) NOT NULL", CanBeNull=false)]
			public string UnitMeasureCode
			{
				get
				{
					return this._UnitMeasureCode;
				}
				set
				{
					if (this._UnitMeasureCode != value)
					{
						this.OnUnitMeasureCodeChanging(value);
						this.SendPropertyChanging();
						this._UnitMeasureCode = value;
						this.SendPropertyChanged("UnitMeasureCode");
						this.OnUnitMeasureCodeChanged();
					}
					this.SendPropertySetterInvoked("UnitMeasureCode", value);
				}
			}
			
			/// <summary>
			/// Column DbType=SmallInt NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_BOMLevel", DbType="SmallInt NOT NULL", CanBeNull=false)]
			public System.Int16 BOMLevel
			{
				get
				{
					return this._BOMLevel;
				}
				set
				{
					if (this._BOMLevel != value)
					{
						this.OnBOMLevelChanging(value);
						this.SendPropertyChanging();
						this._BOMLevel = value;
						this.SendPropertyChanged("BOMLevel");
						this.OnBOMLevelChanged();
					}
					this.SendPropertySetterInvoked("BOMLevel", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Decimal(8,2) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_PerAssemblyQty", DbType="Decimal(8,2) NOT NULL", CanBeNull=false)]
			public decimal PerAssemblyQty
			{
				get
				{
					return this._PerAssemblyQty;
				}
				set
				{
					if (this._PerAssemblyQty != value)
					{
						this.OnPerAssemblyQtyChanging(value);
						this.SendPropertyChanging();
						this._PerAssemblyQty = value;
						this.SendPropertyChanged("PerAssemblyQty");
						this.OnPerAssemblyQtyChanged();
					}
					this.SendPropertySetterInvoked("PerAssemblyQty", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ModifiedDate", DbType="DateTime NOT NULL", CanBeNull=false)]
			public DateTime ModifiedDate
			{
				get
				{
					return this._ModifiedDate;
				}
				set
				{
					if (this._ModifiedDate != value)
					{
						this.OnModifiedDateChanging(value);
						this.SendPropertyChanging();
						this._ModifiedDate = value;
						this.SendPropertyChanged("ModifiedDate");
						this.OnModifiedDateChanged();
					}
					this.SendPropertySetterInvoked("ModifiedDate", value);
				}
			}
			
			#endregion Columns

			#region Associations
			/// <summary>
			/// Association [FK][Many]Production_BillOfMaterials.ComponentID --- [PK][One]Production_Product.ProductID
			/// </summary>
			[AssociationAttribute(Name="FK_BillOfMaterials_Product_ComponentID", Storage="_Production_Product", ThisKey="ComponentID", OtherKey="ProductID", IsUnique=false, IsForeignKey=true)]
			public Production_Product Production_Product
			{
				get
				{
					return this._Production_Product.Entity;
				}
				set
				{
					Production_Product previousValue = this._Production_Product.Entity;
					if ((previousValue != value) || (this._Production_Product.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._Production_Product.Entity = null;
							previousValue.Production_BillOfMaterialsList.Remove(this);
						}
						this._Production_Product.Entity = value;
						if (value != null)
						{
							value.Production_BillOfMaterialsList.Add(this);
							this._ComponentID = value.ProductID;
						}
						else
						{
							this._ComponentID = default(int);
						}
						this.SendPropertyChanged("Production_Product");
					}
					this.SendPropertySetterInvoked("Production_Product", value);
				}
			}
			
			/// <summary>
			/// Association [FK][Many]Production_BillOfMaterials.ProductAssemblyID --- [PK][One]Production_Product.ProductID
			/// </summary>
			[AssociationAttribute(Name="FK_BillOfMaterials_Product_ProductAssemblyID", Storage="_ProductAssembly", ThisKey="ProductAssemblyID", OtherKey="ProductID", IsUnique=false, IsForeignKey=true)]
			public Production_Product ProductAssembly
			{
				get
				{
					return this._ProductAssembly.Entity;
				}
				set
				{
					Production_Product previousValue = this._ProductAssembly.Entity;
					if ((previousValue != value) || (this._ProductAssembly.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._ProductAssembly.Entity = null;
							previousValue.ProductList.Remove(this);
						}
						this._ProductAssembly.Entity = value;
						if (value != null)
						{
							value.ProductList.Add(this);
							this._ProductAssemblyID = value.ProductID;
						}
						else
						{
							this._ProductAssemblyID = default(int?);
						}
						this.SendPropertyChanged("ProductAssembly");
					}
					this.SendPropertySetterInvoked("ProductAssembly", value);
				}
			}
			
			/// <summary>
			/// Association [FK][Many]Production_BillOfMaterials.UnitMeasureCode --- [PK][One]Production_UnitMeasure.UnitMeasureCode
			/// </summary>
			[AssociationAttribute(Name="FK_BillOfMaterials_UnitMeasure_UnitMeasureCode", Storage="_Production_UnitMeasure", ThisKey="UnitMeasureCode", OtherKey="UnitMeasureCode", IsUnique=false, IsForeignKey=true)]
			public Production_UnitMeasure Production_UnitMeasure
			{
				get
				{
					return this._Production_UnitMeasure.Entity;
				}
				set
				{
					Production_UnitMeasure previousValue = this._Production_UnitMeasure.Entity;
					if ((previousValue != value) || (this._Production_UnitMeasure.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._Production_UnitMeasure.Entity = null;
							previousValue.Production_BillOfMaterialsList.Remove(this);
						}
						this._Production_UnitMeasure.Entity = value;
						if (value != null)
						{
							value.Production_BillOfMaterialsList.Add(this);
							this._UnitMeasureCode = value.UnitMeasureCode;
						}
						else
						{
							this._UnitMeasureCode = default(string);
						}
						this.SendPropertyChanged("Production_UnitMeasure");
					}
					this.SendPropertySetterInvoked("Production_UnitMeasure", value);
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
		#endregion Production.BillOfMaterials

		#region Person.Contact
		[TableAttribute(Name="Person.Contact")]
		public partial class Person_Contact : EntityBase<Person_Contact, AdventureWorksDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private int _ContactID;
			private bool _NameStyle;
			private string _Title;
			private string _FirstName;
			private string _MiddleName;
			private string _LastName;
			private string _Suffix;
			private string _EmailAddress;
			private int _EmailPromotion;
			private string _Phone;
			private string _PasswordHash;
			private string _PasswordSalt;
			private System.Xml.Linq.XElement _AdditionalContactInfo;
			private System.Guid _rowguid;
			private DateTime _ModifiedDate;
			private EntitySet<HumanResources_Employee> _HumanResources_EmployeeList;
			private EntitySet<Purchasing_VendorContact> _Purchasing_VendorContactList;
			private EntitySet<Sales_ContactCreditCard> _Sales_ContactCreditCardList;
			private EntitySet<Sales_Individual> _Sales_IndividualList;
			private EntitySet<Sales_SalesOrderHeader> _Sales_SalesOrderHeaderList;
			private EntitySet<Sales_StoreContact> _Sales_StoreContactList;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnContactIDChanging(int value);
			partial void OnContactIDChanged();
			partial void OnNameStyleChanging(bool value);
			partial void OnNameStyleChanged();
			partial void OnTitleChanging(string value);
			partial void OnTitleChanged();
			partial void OnFirstNameChanging(string value);
			partial void OnFirstNameChanged();
			partial void OnMiddleNameChanging(string value);
			partial void OnMiddleNameChanged();
			partial void OnLastNameChanging(string value);
			partial void OnLastNameChanged();
			partial void OnSuffixChanging(string value);
			partial void OnSuffixChanged();
			partial void OnEmailAddressChanging(string value);
			partial void OnEmailAddressChanged();
			partial void OnEmailPromotionChanging(int value);
			partial void OnEmailPromotionChanged();
			partial void OnPhoneChanging(string value);
			partial void OnPhoneChanged();
			partial void OnPasswordHashChanging(string value);
			partial void OnPasswordHashChanged();
			partial void OnPasswordSaltChanging(string value);
			partial void OnPasswordSaltChanged();
			partial void OnAdditionalContactInfoChanging(System.Xml.Linq.XElement value);
			partial void OnAdditionalContactInfoChanged();
			partial void OnrowguidChanging(System.Guid value);
			partial void OnrowguidChanged();
			partial void OnModifiedDateChanging(DateTime value);
			partial void OnModifiedDateChanged();
			#endregion

			public Person_Contact()
			{
				_HumanResources_EmployeeList = new EntitySet<HumanResources_Employee>(
					new Action<HumanResources_Employee>(item=>{this.SendPropertyChanging(); item.Person_Contact=this;}), 
					new Action<HumanResources_Employee>(item=>{this.SendPropertyChanging(); item.Person_Contact=null;}));
				_Purchasing_VendorContactList = new EntitySet<Purchasing_VendorContact>(
					new Action<Purchasing_VendorContact>(item=>{this.SendPropertyChanging(); item.Person_Contact=this;}), 
					new Action<Purchasing_VendorContact>(item=>{this.SendPropertyChanging(); item.Person_Contact=null;}));
				_Sales_ContactCreditCardList = new EntitySet<Sales_ContactCreditCard>(
					new Action<Sales_ContactCreditCard>(item=>{this.SendPropertyChanging(); item.Person_Contact=this;}), 
					new Action<Sales_ContactCreditCard>(item=>{this.SendPropertyChanging(); item.Person_Contact=null;}));
				_Sales_IndividualList = new EntitySet<Sales_Individual>(
					new Action<Sales_Individual>(item=>{this.SendPropertyChanging(); item.Person_Contact=this;}), 
					new Action<Sales_Individual>(item=>{this.SendPropertyChanging(); item.Person_Contact=null;}));
				_Sales_SalesOrderHeaderList = new EntitySet<Sales_SalesOrderHeader>(
					new Action<Sales_SalesOrderHeader>(item=>{this.SendPropertyChanging(); item.Person_Contact=this;}), 
					new Action<Sales_SalesOrderHeader>(item=>{this.SendPropertyChanging(); item.Person_Contact=null;}));
				_Sales_StoreContactList = new EntitySet<Sales_StoreContact>(
					new Action<Sales_StoreContact>(item=>{this.SendPropertyChanging(); item.Person_Contact=this;}), 
					new Action<Sales_StoreContact>(item=>{this.SendPropertyChanging(); item.Person_Contact=null;}));
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=Int NOT NULL IDENTITY
			/// </summary>
			[ColumnAttribute(Storage="_ContactID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", CanBeNull=false, IsPrimaryKey=true, IsDbGenerated=true)]
			public int ContactID
			{
				get
				{
					return this._ContactID;
				}
				set
				{
					if (this._ContactID != value)
					{
						this.OnContactIDChanging(value);
						this.SendPropertyChanging();
						this._ContactID = value;
						this.SendPropertyChanged("ContactID");
						this.OnContactIDChanged();
					}
					this.SendPropertySetterInvoked("ContactID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Bit NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_NameStyle", DbType="Bit NOT NULL", CanBeNull=false)]
			public bool NameStyle
			{
				get
				{
					return this._NameStyle;
				}
				set
				{
					if (this._NameStyle != value)
					{
						this.OnNameStyleChanging(value);
						this.SendPropertyChanging();
						this._NameStyle = value;
						this.SendPropertyChanged("NameStyle");
						this.OnNameStyleChanged();
					}
					this.SendPropertySetterInvoked("NameStyle", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(8)
			/// </summary>
			[ColumnAttribute(Storage="_Title", DbType="NVarChar(8)", CanBeNull=true)]
			public string Title
			{
				get
				{
					return this._Title;
				}
				set
				{
					if (this._Title != value)
					{
						this.OnTitleChanging(value);
						this.SendPropertyChanging();
						this._Title = value;
						this.SendPropertyChanged("Title");
						this.OnTitleChanged();
					}
					this.SendPropertySetterInvoked("Title", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(50) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_FirstName", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
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
			/// Column DbType=NVarChar(50)
			/// </summary>
			[ColumnAttribute(Storage="_MiddleName", DbType="NVarChar(50)", CanBeNull=true)]
			public string MiddleName
			{
				get
				{
					return this._MiddleName;
				}
				set
				{
					if (this._MiddleName != value)
					{
						this.OnMiddleNameChanging(value);
						this.SendPropertyChanging();
						this._MiddleName = value;
						this.SendPropertyChanged("MiddleName");
						this.OnMiddleNameChanged();
					}
					this.SendPropertySetterInvoked("MiddleName", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(50) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_LastName", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
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
			/// Column DbType=NVarChar(10)
			/// </summary>
			[ColumnAttribute(Storage="_Suffix", DbType="NVarChar(10)", CanBeNull=true)]
			public string Suffix
			{
				get
				{
					return this._Suffix;
				}
				set
				{
					if (this._Suffix != value)
					{
						this.OnSuffixChanging(value);
						this.SendPropertyChanging();
						this._Suffix = value;
						this.SendPropertyChanged("Suffix");
						this.OnSuffixChanged();
					}
					this.SendPropertySetterInvoked("Suffix", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(50)
			/// </summary>
			[ColumnAttribute(Storage="_EmailAddress", DbType="NVarChar(50)", CanBeNull=true)]
			public string EmailAddress
			{
				get
				{
					return this._EmailAddress;
				}
				set
				{
					if (this._EmailAddress != value)
					{
						this.OnEmailAddressChanging(value);
						this.SendPropertyChanging();
						this._EmailAddress = value;
						this.SendPropertyChanged("EmailAddress");
						this.OnEmailAddressChanged();
					}
					this.SendPropertySetterInvoked("EmailAddress", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_EmailPromotion", DbType="Int NOT NULL", CanBeNull=false)]
			public int EmailPromotion
			{
				get
				{
					return this._EmailPromotion;
				}
				set
				{
					if (this._EmailPromotion != value)
					{
						this.OnEmailPromotionChanging(value);
						this.SendPropertyChanging();
						this._EmailPromotion = value;
						this.SendPropertyChanged("EmailPromotion");
						this.OnEmailPromotionChanged();
					}
					this.SendPropertySetterInvoked("EmailPromotion", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(25)
			/// </summary>
			[ColumnAttribute(Storage="_Phone", DbType="NVarChar(25)", CanBeNull=true)]
			public string Phone
			{
				get
				{
					return this._Phone;
				}
				set
				{
					if (this._Phone != value)
					{
						this.OnPhoneChanging(value);
						this.SendPropertyChanging();
						this._Phone = value;
						this.SendPropertyChanged("Phone");
						this.OnPhoneChanged();
					}
					this.SendPropertySetterInvoked("Phone", value);
				}
			}
			
			/// <summary>
			/// Column DbType=VarChar(128) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_PasswordHash", DbType="VarChar(128) NOT NULL", CanBeNull=false)]
			public string PasswordHash
			{
				get
				{
					return this._PasswordHash;
				}
				set
				{
					if (this._PasswordHash != value)
					{
						this.OnPasswordHashChanging(value);
						this.SendPropertyChanging();
						this._PasswordHash = value;
						this.SendPropertyChanged("PasswordHash");
						this.OnPasswordHashChanged();
					}
					this.SendPropertySetterInvoked("PasswordHash", value);
				}
			}
			
			/// <summary>
			/// Column DbType=VarChar(10) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_PasswordSalt", DbType="VarChar(10) NOT NULL", CanBeNull=false)]
			public string PasswordSalt
			{
				get
				{
					return this._PasswordSalt;
				}
				set
				{
					if (this._PasswordSalt != value)
					{
						this.OnPasswordSaltChanging(value);
						this.SendPropertyChanging();
						this._PasswordSalt = value;
						this.SendPropertyChanged("PasswordSalt");
						this.OnPasswordSaltChanged();
					}
					this.SendPropertySetterInvoked("PasswordSalt", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Xml
			/// </summary>
			[ColumnAttribute(Storage="_AdditionalContactInfo", DbType="Xml", CanBeNull=true)]
			public System.Xml.Linq.XElement AdditionalContactInfo
			{
				get
				{
					return this._AdditionalContactInfo;
				}
				set
				{
					if (this._AdditionalContactInfo != value)
					{
						this.OnAdditionalContactInfoChanging(value);
						this.SendPropertyChanging();
						this._AdditionalContactInfo = value;
						this.SendPropertyChanged("AdditionalContactInfo");
						this.OnAdditionalContactInfoChanged();
					}
					this.SendPropertySetterInvoked("AdditionalContactInfo", value);
				}
			}
			
			/// <summary>
			/// Column DbType=UniqueIdentifier NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_rowguid", DbType="UniqueIdentifier NOT NULL", CanBeNull=false)]
			public System.Guid rowguid
			{
				get
				{
					return this._rowguid;
				}
				set
				{
					if (this._rowguid != value)
					{
						this.OnrowguidChanging(value);
						this.SendPropertyChanging();
						this._rowguid = value;
						this.SendPropertyChanged("rowguid");
						this.OnrowguidChanged();
					}
					this.SendPropertySetterInvoked("rowguid", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ModifiedDate", DbType="DateTime NOT NULL", CanBeNull=false)]
			public DateTime ModifiedDate
			{
				get
				{
					return this._ModifiedDate;
				}
				set
				{
					if (this._ModifiedDate != value)
					{
						this.OnModifiedDateChanging(value);
						this.SendPropertyChanging();
						this._ModifiedDate = value;
						this.SendPropertyChanged("ModifiedDate");
						this.OnModifiedDateChanged();
					}
					this.SendPropertySetterInvoked("ModifiedDate", value);
				}
			}
			
			#endregion Columns

			#region Associations
			/// <summary>
			/// Association [PK][One]Person_Contact.ContactID --- [FK][Many]HumanResources_Employee.ContactID
			/// </summary>
			[AssociationAttribute(Name="FK_Employee_Contact_ContactID", Storage="_HumanResources_EmployeeList", ThisKey="ContactID", OtherKey="ContactID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<HumanResources_Employee> HumanResources_EmployeeList
			{
				get { return this._HumanResources_EmployeeList; }
				set { this._HumanResources_EmployeeList.Assign(value); }
			}
			
			/// <summary>
			/// Association [PK][One]Person_Contact.ContactID --- [FK][Many]Purchasing_VendorContact.ContactID
			/// </summary>
			[AssociationAttribute(Name="FK_VendorContact_Contact_ContactID", Storage="_Purchasing_VendorContactList", ThisKey="ContactID", OtherKey="ContactID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<Purchasing_VendorContact> Purchasing_VendorContactList
			{
				get { return this._Purchasing_VendorContactList; }
				set { this._Purchasing_VendorContactList.Assign(value); }
			}
			
			/// <summary>
			/// Association [PK][One]Person_Contact.ContactID --- [FK][Many]Sales_ContactCreditCard.ContactID
			/// </summary>
			[AssociationAttribute(Name="FK_ContactCreditCard_Contact_ContactID", Storage="_Sales_ContactCreditCardList", ThisKey="ContactID", OtherKey="ContactID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<Sales_ContactCreditCard> Sales_ContactCreditCardList
			{
				get { return this._Sales_ContactCreditCardList; }
				set { this._Sales_ContactCreditCardList.Assign(value); }
			}
			
			/// <summary>
			/// Association [PK][One]Person_Contact.ContactID --- [FK][Many]Sales_Individual.ContactID
			/// </summary>
			[AssociationAttribute(Name="FK_Individual_Contact_ContactID", Storage="_Sales_IndividualList", ThisKey="ContactID", OtherKey="ContactID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<Sales_Individual> Sales_IndividualList
			{
				get { return this._Sales_IndividualList; }
				set { this._Sales_IndividualList.Assign(value); }
			}
			
			/// <summary>
			/// Association [PK][One]Person_Contact.ContactID --- [FK][Many]Sales_SalesOrderHeader.ContactID
			/// </summary>
			[AssociationAttribute(Name="FK_SalesOrderHeader_Contact_ContactID", Storage="_Sales_SalesOrderHeaderList", ThisKey="ContactID", OtherKey="ContactID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<Sales_SalesOrderHeader> Sales_SalesOrderHeaderList
			{
				get { return this._Sales_SalesOrderHeaderList; }
				set { this._Sales_SalesOrderHeaderList.Assign(value); }
			}
			
			/// <summary>
			/// Association [PK][One]Person_Contact.ContactID --- [FK][Many]Sales_StoreContact.ContactID
			/// </summary>
			[AssociationAttribute(Name="FK_StoreContact_Contact_ContactID", Storage="_Sales_StoreContactList", ThisKey="ContactID", OtherKey="ContactID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<Sales_StoreContact> Sales_StoreContactList
			{
				get { return this._Sales_StoreContactList; }
				set { this._Sales_StoreContactList.Assign(value); }
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
		#endregion Person.Contact

		#region Sales.ContactCreditCard
		[TableAttribute(Name="Sales.ContactCreditCard")]
		public partial class Sales_ContactCreditCard : EntityBase<Sales_ContactCreditCard, AdventureWorksDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private int _ContactID;
			private int _CreditCardID;
			private DateTime _ModifiedDate;
			private EntityRef<Person_Contact> _Person_Contact;
			private EntityRef<Sales_CreditCard> _Sales_CreditCard;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnContactIDChanging(int value);
			partial void OnContactIDChanged();
			partial void OnCreditCardIDChanging(int value);
			partial void OnCreditCardIDChanged();
			partial void OnModifiedDateChanging(DateTime value);
			partial void OnModifiedDateChanged();
			#endregion

			public Sales_ContactCreditCard()
			{
				_Person_Contact = default(EntityRef<Person_Contact>);
				_Sales_CreditCard = default(EntityRef<Sales_CreditCard>);
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ContactID", DbType="Int NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
			public int ContactID
			{
				get
				{
					return this._ContactID;
				}
				set
				{
					if (this._ContactID != value)
					{
						this.OnContactIDChanging(value);
						this.SendPropertyChanging();
						this._ContactID = value;
						this.SendPropertyChanged("ContactID");
						this.OnContactIDChanged();
					}
					this.SendPropertySetterInvoked("ContactID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_CreditCardID", DbType="Int NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
			public int CreditCardID
			{
				get
				{
					return this._CreditCardID;
				}
				set
				{
					if (this._CreditCardID != value)
					{
						this.OnCreditCardIDChanging(value);
						this.SendPropertyChanging();
						this._CreditCardID = value;
						this.SendPropertyChanged("CreditCardID");
						this.OnCreditCardIDChanged();
					}
					this.SendPropertySetterInvoked("CreditCardID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ModifiedDate", DbType="DateTime NOT NULL", CanBeNull=false)]
			public DateTime ModifiedDate
			{
				get
				{
					return this._ModifiedDate;
				}
				set
				{
					if (this._ModifiedDate != value)
					{
						this.OnModifiedDateChanging(value);
						this.SendPropertyChanging();
						this._ModifiedDate = value;
						this.SendPropertyChanged("ModifiedDate");
						this.OnModifiedDateChanged();
					}
					this.SendPropertySetterInvoked("ModifiedDate", value);
				}
			}
			
			#endregion Columns

			#region Associations
			/// <summary>
			/// Association [FK][Many]Sales_ContactCreditCard.ContactID --- [PK][One]Person_Contact.ContactID
			/// </summary>
			[AssociationAttribute(Name="FK_ContactCreditCard_Contact_ContactID", Storage="_Person_Contact", ThisKey="ContactID", OtherKey="ContactID", IsUnique=false, IsForeignKey=true)]
			public Person_Contact Person_Contact
			{
				get
				{
					return this._Person_Contact.Entity;
				}
				set
				{
					Person_Contact previousValue = this._Person_Contact.Entity;
					if ((previousValue != value) || (this._Person_Contact.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._Person_Contact.Entity = null;
							previousValue.Sales_ContactCreditCardList.Remove(this);
						}
						this._Person_Contact.Entity = value;
						if (value != null)
						{
							value.Sales_ContactCreditCardList.Add(this);
							this._ContactID = value.ContactID;
						}
						else
						{
							this._ContactID = default(int);
						}
						this.SendPropertyChanged("Person_Contact");
					}
					this.SendPropertySetterInvoked("Person_Contact", value);
				}
			}
			
			/// <summary>
			/// Association [FK][Many]Sales_ContactCreditCard.CreditCardID --- [PK][One]Sales_CreditCard.CreditCardID
			/// </summary>
			[AssociationAttribute(Name="FK_ContactCreditCard_CreditCard_CreditCardID", Storage="_Sales_CreditCard", ThisKey="CreditCardID", OtherKey="CreditCardID", IsUnique=false, IsForeignKey=true)]
			public Sales_CreditCard Sales_CreditCard
			{
				get
				{
					return this._Sales_CreditCard.Entity;
				}
				set
				{
					Sales_CreditCard previousValue = this._Sales_CreditCard.Entity;
					if ((previousValue != value) || (this._Sales_CreditCard.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._Sales_CreditCard.Entity = null;
							previousValue.Sales_ContactCreditCardList.Remove(this);
						}
						this._Sales_CreditCard.Entity = value;
						if (value != null)
						{
							value.Sales_ContactCreditCardList.Add(this);
							this._CreditCardID = value.CreditCardID;
						}
						else
						{
							this._CreditCardID = default(int);
						}
						this.SendPropertyChanged("Sales_CreditCard");
					}
					this.SendPropertySetterInvoked("Sales_CreditCard", value);
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
		#endregion Sales.ContactCreditCard

		#region Person.ContactType
		[TableAttribute(Name="Person.ContactType")]
		public partial class Person_ContactType : EntityBase<Person_ContactType, AdventureWorksDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private int _ContactTypeID;
			private string _Name;
			private DateTime _ModifiedDate;
			private EntitySet<Purchasing_VendorContact> _Purchasing_VendorContactList;
			private EntitySet<Sales_StoreContact> _Sales_StoreContactList;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnContactTypeIDChanging(int value);
			partial void OnContactTypeIDChanged();
			partial void OnNameChanging(string value);
			partial void OnNameChanged();
			partial void OnModifiedDateChanging(DateTime value);
			partial void OnModifiedDateChanged();
			#endregion

			public Person_ContactType()
			{
				_Purchasing_VendorContactList = new EntitySet<Purchasing_VendorContact>(
					new Action<Purchasing_VendorContact>(item=>{this.SendPropertyChanging(); item.Person_ContactType=this;}), 
					new Action<Purchasing_VendorContact>(item=>{this.SendPropertyChanging(); item.Person_ContactType=null;}));
				_Sales_StoreContactList = new EntitySet<Sales_StoreContact>(
					new Action<Sales_StoreContact>(item=>{this.SendPropertyChanging(); item.Person_ContactType=this;}), 
					new Action<Sales_StoreContact>(item=>{this.SendPropertyChanging(); item.Person_ContactType=null;}));
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=Int NOT NULL IDENTITY
			/// </summary>
			[ColumnAttribute(Storage="_ContactTypeID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", CanBeNull=false, IsPrimaryKey=true, IsDbGenerated=true)]
			public int ContactTypeID
			{
				get
				{
					return this._ContactTypeID;
				}
				set
				{
					if (this._ContactTypeID != value)
					{
						this.OnContactTypeIDChanging(value);
						this.SendPropertyChanging();
						this._ContactTypeID = value;
						this.SendPropertyChanged("ContactTypeID");
						this.OnContactTypeIDChanged();
					}
					this.SendPropertySetterInvoked("ContactTypeID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(50) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_Name", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
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
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ModifiedDate", DbType="DateTime NOT NULL", CanBeNull=false)]
			public DateTime ModifiedDate
			{
				get
				{
					return this._ModifiedDate;
				}
				set
				{
					if (this._ModifiedDate != value)
					{
						this.OnModifiedDateChanging(value);
						this.SendPropertyChanging();
						this._ModifiedDate = value;
						this.SendPropertyChanged("ModifiedDate");
						this.OnModifiedDateChanged();
					}
					this.SendPropertySetterInvoked("ModifiedDate", value);
				}
			}
			
			#endregion Columns

			#region Associations
			/// <summary>
			/// Association [PK][One]Person_ContactType.ContactTypeID --- [FK][Many]Purchasing_VendorContact.ContactTypeID
			/// </summary>
			[AssociationAttribute(Name="FK_VendorContact_ContactType_ContactTypeID", Storage="_Purchasing_VendorContactList", ThisKey="ContactTypeID", OtherKey="ContactTypeID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<Purchasing_VendorContact> Purchasing_VendorContactList
			{
				get { return this._Purchasing_VendorContactList; }
				set { this._Purchasing_VendorContactList.Assign(value); }
			}
			
			/// <summary>
			/// Association [PK][One]Person_ContactType.ContactTypeID --- [FK][Many]Sales_StoreContact.ContactTypeID
			/// </summary>
			[AssociationAttribute(Name="FK_StoreContact_ContactType_ContactTypeID", Storage="_Sales_StoreContactList", ThisKey="ContactTypeID", OtherKey="ContactTypeID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<Sales_StoreContact> Sales_StoreContactList
			{
				get { return this._Sales_StoreContactList; }
				set { this._Sales_StoreContactList.Assign(value); }
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
		#endregion Person.ContactType

		#region Person.CountryRegion
		[TableAttribute(Name="Person.CountryRegion")]
		public partial class Person_CountryRegion : EntityBase<Person_CountryRegion, AdventureWorksDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private string _CountryRegionCode;
			private string _Name;
			private DateTime _ModifiedDate;
			private EntitySet<Person_StateProvince> _Person_StateProvinceList;
			private EntitySet<Sales_CountryRegionCurrency> _Sales_CountryRegionCurrencyList;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnCountryRegionCodeChanging(string value);
			partial void OnCountryRegionCodeChanged();
			partial void OnNameChanging(string value);
			partial void OnNameChanged();
			partial void OnModifiedDateChanging(DateTime value);
			partial void OnModifiedDateChanged();
			#endregion

			public Person_CountryRegion()
			{
				_Person_StateProvinceList = new EntitySet<Person_StateProvince>(
					new Action<Person_StateProvince>(item=>{this.SendPropertyChanging(); item.Person_CountryRegion=this;}), 
					new Action<Person_StateProvince>(item=>{this.SendPropertyChanging(); item.Person_CountryRegion=null;}));
				_Sales_CountryRegionCurrencyList = new EntitySet<Sales_CountryRegionCurrency>(
					new Action<Sales_CountryRegionCurrency>(item=>{this.SendPropertyChanging(); item.Person_CountryRegion=this;}), 
					new Action<Sales_CountryRegionCurrency>(item=>{this.SendPropertyChanging(); item.Person_CountryRegion=null;}));
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=NVarChar(3) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_CountryRegionCode", DbType="NVarChar(3) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
			public string CountryRegionCode
			{
				get
				{
					return this._CountryRegionCode;
				}
				set
				{
					if (this._CountryRegionCode != value)
					{
						this.OnCountryRegionCodeChanging(value);
						this.SendPropertyChanging();
						this._CountryRegionCode = value;
						this.SendPropertyChanged("CountryRegionCode");
						this.OnCountryRegionCodeChanged();
					}
					this.SendPropertySetterInvoked("CountryRegionCode", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(50) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_Name", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
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
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ModifiedDate", DbType="DateTime NOT NULL", CanBeNull=false)]
			public DateTime ModifiedDate
			{
				get
				{
					return this._ModifiedDate;
				}
				set
				{
					if (this._ModifiedDate != value)
					{
						this.OnModifiedDateChanging(value);
						this.SendPropertyChanging();
						this._ModifiedDate = value;
						this.SendPropertyChanged("ModifiedDate");
						this.OnModifiedDateChanged();
					}
					this.SendPropertySetterInvoked("ModifiedDate", value);
				}
			}
			
			#endregion Columns

			#region Associations
			/// <summary>
			/// Association [PK][One]Person_CountryRegion.CountryRegionCode --- [FK][Many]Person_StateProvince.CountryRegionCode
			/// </summary>
			[AssociationAttribute(Name="FK_StateProvince_CountryRegion_CountryRegionCode", Storage="_Person_StateProvinceList", ThisKey="CountryRegionCode", OtherKey="CountryRegionCode", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<Person_StateProvince> Person_StateProvinceList
			{
				get { return this._Person_StateProvinceList; }
				set { this._Person_StateProvinceList.Assign(value); }
			}
			
			/// <summary>
			/// Association [PK][One]Person_CountryRegion.CountryRegionCode --- [FK][Many]Sales_CountryRegionCurrency.CountryRegionCode
			/// </summary>
			[AssociationAttribute(Name="FK_CountryRegionCurrency_CountryRegion_CountryRegionCode", Storage="_Sales_CountryRegionCurrencyList", ThisKey="CountryRegionCode", OtherKey="CountryRegionCode", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<Sales_CountryRegionCurrency> Sales_CountryRegionCurrencyList
			{
				get { return this._Sales_CountryRegionCurrencyList; }
				set { this._Sales_CountryRegionCurrencyList.Assign(value); }
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
		#endregion Person.CountryRegion

		#region Sales.CountryRegionCurrency
		[TableAttribute(Name="Sales.CountryRegionCurrency")]
		public partial class Sales_CountryRegionCurrency : EntityBase<Sales_CountryRegionCurrency, AdventureWorksDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private string _CountryRegionCode;
			private string _CurrencyCode;
			private DateTime _ModifiedDate;
			private EntityRef<Person_CountryRegion> _Person_CountryRegion;
			private EntityRef<Sales_Currency> _Sales_Currency;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnCountryRegionCodeChanging(string value);
			partial void OnCountryRegionCodeChanged();
			partial void OnCurrencyCodeChanging(string value);
			partial void OnCurrencyCodeChanged();
			partial void OnModifiedDateChanging(DateTime value);
			partial void OnModifiedDateChanged();
			#endregion

			public Sales_CountryRegionCurrency()
			{
				_Person_CountryRegion = default(EntityRef<Person_CountryRegion>);
				_Sales_Currency = default(EntityRef<Sales_Currency>);
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=NVarChar(3) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_CountryRegionCode", DbType="NVarChar(3) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
			public string CountryRegionCode
			{
				get
				{
					return this._CountryRegionCode;
				}
				set
				{
					if (this._CountryRegionCode != value)
					{
						this.OnCountryRegionCodeChanging(value);
						this.SendPropertyChanging();
						this._CountryRegionCode = value;
						this.SendPropertyChanged("CountryRegionCode");
						this.OnCountryRegionCodeChanged();
					}
					this.SendPropertySetterInvoked("CountryRegionCode", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NChar(3) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_CurrencyCode", DbType="NChar(3) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
			public string CurrencyCode
			{
				get
				{
					return this._CurrencyCode;
				}
				set
				{
					if (this._CurrencyCode != value)
					{
						this.OnCurrencyCodeChanging(value);
						this.SendPropertyChanging();
						this._CurrencyCode = value;
						this.SendPropertyChanged("CurrencyCode");
						this.OnCurrencyCodeChanged();
					}
					this.SendPropertySetterInvoked("CurrencyCode", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ModifiedDate", DbType="DateTime NOT NULL", CanBeNull=false)]
			public DateTime ModifiedDate
			{
				get
				{
					return this._ModifiedDate;
				}
				set
				{
					if (this._ModifiedDate != value)
					{
						this.OnModifiedDateChanging(value);
						this.SendPropertyChanging();
						this._ModifiedDate = value;
						this.SendPropertyChanged("ModifiedDate");
						this.OnModifiedDateChanged();
					}
					this.SendPropertySetterInvoked("ModifiedDate", value);
				}
			}
			
			#endregion Columns

			#region Associations
			/// <summary>
			/// Association [FK][Many]Sales_CountryRegionCurrency.CountryRegionCode --- [PK][One]Person_CountryRegion.CountryRegionCode
			/// </summary>
			[AssociationAttribute(Name="FK_CountryRegionCurrency_CountryRegion_CountryRegionCode", Storage="_Person_CountryRegion", ThisKey="CountryRegionCode", OtherKey="CountryRegionCode", IsUnique=false, IsForeignKey=true)]
			public Person_CountryRegion Person_CountryRegion
			{
				get
				{
					return this._Person_CountryRegion.Entity;
				}
				set
				{
					Person_CountryRegion previousValue = this._Person_CountryRegion.Entity;
					if ((previousValue != value) || (this._Person_CountryRegion.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._Person_CountryRegion.Entity = null;
							previousValue.Sales_CountryRegionCurrencyList.Remove(this);
						}
						this._Person_CountryRegion.Entity = value;
						if (value != null)
						{
							value.Sales_CountryRegionCurrencyList.Add(this);
							this._CountryRegionCode = value.CountryRegionCode;
						}
						else
						{
							this._CountryRegionCode = default(string);
						}
						this.SendPropertyChanged("Person_CountryRegion");
					}
					this.SendPropertySetterInvoked("Person_CountryRegion", value);
				}
			}
			
			/// <summary>
			/// Association [FK][Many]Sales_CountryRegionCurrency.CurrencyCode --- [PK][One]Sales_Currency.CurrencyCode
			/// </summary>
			[AssociationAttribute(Name="FK_CountryRegionCurrency_Currency_CurrencyCode", Storage="_Sales_Currency", ThisKey="CurrencyCode", OtherKey="CurrencyCode", IsUnique=false, IsForeignKey=true)]
			public Sales_Currency Sales_Currency
			{
				get
				{
					return this._Sales_Currency.Entity;
				}
				set
				{
					Sales_Currency previousValue = this._Sales_Currency.Entity;
					if ((previousValue != value) || (this._Sales_Currency.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._Sales_Currency.Entity = null;
							previousValue.Sales_CountryRegionCurrencyList.Remove(this);
						}
						this._Sales_Currency.Entity = value;
						if (value != null)
						{
							value.Sales_CountryRegionCurrencyList.Add(this);
							this._CurrencyCode = value.CurrencyCode;
						}
						else
						{
							this._CurrencyCode = default(string);
						}
						this.SendPropertyChanged("Sales_Currency");
					}
					this.SendPropertySetterInvoked("Sales_Currency", value);
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
		#endregion Sales.CountryRegionCurrency

		#region Sales.CreditCard
		[TableAttribute(Name="Sales.CreditCard")]
		public partial class Sales_CreditCard : EntityBase<Sales_CreditCard, AdventureWorksDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private int _CreditCardID;
			private string _CardType;
			private string _CardNumber;
			private byte _ExpMonth;
			private System.Int16 _ExpYear;
			private DateTime _ModifiedDate;
			private EntitySet<Sales_ContactCreditCard> _Sales_ContactCreditCardList;
			private EntitySet<Sales_SalesOrderHeader> _Sales_SalesOrderHeaderList;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnCreditCardIDChanging(int value);
			partial void OnCreditCardIDChanged();
			partial void OnCardTypeChanging(string value);
			partial void OnCardTypeChanged();
			partial void OnCardNumberChanging(string value);
			partial void OnCardNumberChanged();
			partial void OnExpMonthChanging(byte value);
			partial void OnExpMonthChanged();
			partial void OnExpYearChanging(System.Int16 value);
			partial void OnExpYearChanged();
			partial void OnModifiedDateChanging(DateTime value);
			partial void OnModifiedDateChanged();
			#endregion

			public Sales_CreditCard()
			{
				_Sales_ContactCreditCardList = new EntitySet<Sales_ContactCreditCard>(
					new Action<Sales_ContactCreditCard>(item=>{this.SendPropertyChanging(); item.Sales_CreditCard=this;}), 
					new Action<Sales_ContactCreditCard>(item=>{this.SendPropertyChanging(); item.Sales_CreditCard=null;}));
				_Sales_SalesOrderHeaderList = new EntitySet<Sales_SalesOrderHeader>(
					new Action<Sales_SalesOrderHeader>(item=>{this.SendPropertyChanging(); item.Sales_CreditCard=this;}), 
					new Action<Sales_SalesOrderHeader>(item=>{this.SendPropertyChanging(); item.Sales_CreditCard=null;}));
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=Int NOT NULL IDENTITY
			/// </summary>
			[ColumnAttribute(Storage="_CreditCardID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", CanBeNull=false, IsPrimaryKey=true, IsDbGenerated=true)]
			public int CreditCardID
			{
				get
				{
					return this._CreditCardID;
				}
				set
				{
					if (this._CreditCardID != value)
					{
						this.OnCreditCardIDChanging(value);
						this.SendPropertyChanging();
						this._CreditCardID = value;
						this.SendPropertyChanged("CreditCardID");
						this.OnCreditCardIDChanged();
					}
					this.SendPropertySetterInvoked("CreditCardID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(50) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_CardType", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
			public string CardType
			{
				get
				{
					return this._CardType;
				}
				set
				{
					if (this._CardType != value)
					{
						this.OnCardTypeChanging(value);
						this.SendPropertyChanging();
						this._CardType = value;
						this.SendPropertyChanged("CardType");
						this.OnCardTypeChanged();
					}
					this.SendPropertySetterInvoked("CardType", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(25) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_CardNumber", DbType="NVarChar(25) NOT NULL", CanBeNull=false)]
			public string CardNumber
			{
				get
				{
					return this._CardNumber;
				}
				set
				{
					if (this._CardNumber != value)
					{
						this.OnCardNumberChanging(value);
						this.SendPropertyChanging();
						this._CardNumber = value;
						this.SendPropertyChanged("CardNumber");
						this.OnCardNumberChanged();
					}
					this.SendPropertySetterInvoked("CardNumber", value);
				}
			}
			
			/// <summary>
			/// Column DbType=TinyInt NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ExpMonth", DbType="TinyInt NOT NULL", CanBeNull=false)]
			public byte ExpMonth
			{
				get
				{
					return this._ExpMonth;
				}
				set
				{
					if (this._ExpMonth != value)
					{
						this.OnExpMonthChanging(value);
						this.SendPropertyChanging();
						this._ExpMonth = value;
						this.SendPropertyChanged("ExpMonth");
						this.OnExpMonthChanged();
					}
					this.SendPropertySetterInvoked("ExpMonth", value);
				}
			}
			
			/// <summary>
			/// Column DbType=SmallInt NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ExpYear", DbType="SmallInt NOT NULL", CanBeNull=false)]
			public System.Int16 ExpYear
			{
				get
				{
					return this._ExpYear;
				}
				set
				{
					if (this._ExpYear != value)
					{
						this.OnExpYearChanging(value);
						this.SendPropertyChanging();
						this._ExpYear = value;
						this.SendPropertyChanged("ExpYear");
						this.OnExpYearChanged();
					}
					this.SendPropertySetterInvoked("ExpYear", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ModifiedDate", DbType="DateTime NOT NULL", CanBeNull=false)]
			public DateTime ModifiedDate
			{
				get
				{
					return this._ModifiedDate;
				}
				set
				{
					if (this._ModifiedDate != value)
					{
						this.OnModifiedDateChanging(value);
						this.SendPropertyChanging();
						this._ModifiedDate = value;
						this.SendPropertyChanged("ModifiedDate");
						this.OnModifiedDateChanged();
					}
					this.SendPropertySetterInvoked("ModifiedDate", value);
				}
			}
			
			#endregion Columns

			#region Associations
			/// <summary>
			/// Association [PK][One]Sales_CreditCard.CreditCardID --- [FK][Many]Sales_ContactCreditCard.CreditCardID
			/// </summary>
			[AssociationAttribute(Name="FK_ContactCreditCard_CreditCard_CreditCardID", Storage="_Sales_ContactCreditCardList", ThisKey="CreditCardID", OtherKey="CreditCardID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<Sales_ContactCreditCard> Sales_ContactCreditCardList
			{
				get { return this._Sales_ContactCreditCardList; }
				set { this._Sales_ContactCreditCardList.Assign(value); }
			}
			
			/// <summary>
			/// Association [PK][One]Sales_CreditCard.CreditCardID --- [FK][Many]Sales_SalesOrderHeader.CreditCardID
			/// </summary>
			[AssociationAttribute(Name="FK_SalesOrderHeader_CreditCard_CreditCardID", Storage="_Sales_SalesOrderHeaderList", ThisKey="CreditCardID", OtherKey="CreditCardID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<Sales_SalesOrderHeader> Sales_SalesOrderHeaderList
			{
				get { return this._Sales_SalesOrderHeaderList; }
				set { this._Sales_SalesOrderHeaderList.Assign(value); }
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
		#endregion Sales.CreditCard

		#region Production.Culture
		[TableAttribute(Name="Production.Culture")]
		public partial class Production_Culture : EntityBase<Production_Culture, AdventureWorksDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private string _CultureID;
			private string _Name;
			private DateTime _ModifiedDate;
			private EntitySet<Production_ProductModelProductDescriptionCulture> _Production_ProductModelProductDescriptionCultureList;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnCultureIDChanging(string value);
			partial void OnCultureIDChanged();
			partial void OnNameChanging(string value);
			partial void OnNameChanged();
			partial void OnModifiedDateChanging(DateTime value);
			partial void OnModifiedDateChanged();
			#endregion

			public Production_Culture()
			{
				_Production_ProductModelProductDescriptionCultureList = new EntitySet<Production_ProductModelProductDescriptionCulture>(
					new Action<Production_ProductModelProductDescriptionCulture>(item=>{this.SendPropertyChanging(); item.Production_Culture=this;}), 
					new Action<Production_ProductModelProductDescriptionCulture>(item=>{this.SendPropertyChanging(); item.Production_Culture=null;}));
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=NChar(6) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_CultureID", DbType="NChar(6) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
			public string CultureID
			{
				get
				{
					return this._CultureID;
				}
				set
				{
					if (this._CultureID != value)
					{
						this.OnCultureIDChanging(value);
						this.SendPropertyChanging();
						this._CultureID = value;
						this.SendPropertyChanged("CultureID");
						this.OnCultureIDChanged();
					}
					this.SendPropertySetterInvoked("CultureID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(50) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_Name", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
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
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ModifiedDate", DbType="DateTime NOT NULL", CanBeNull=false)]
			public DateTime ModifiedDate
			{
				get
				{
					return this._ModifiedDate;
				}
				set
				{
					if (this._ModifiedDate != value)
					{
						this.OnModifiedDateChanging(value);
						this.SendPropertyChanging();
						this._ModifiedDate = value;
						this.SendPropertyChanged("ModifiedDate");
						this.OnModifiedDateChanged();
					}
					this.SendPropertySetterInvoked("ModifiedDate", value);
				}
			}
			
			#endregion Columns

			#region Associations
			/// <summary>
			/// Association [PK][One]Production_Culture.CultureID --- [FK][Many]Production_ProductModelProductDescriptionCulture.CultureID
			/// </summary>
			[AssociationAttribute(Name="FK_ProductModelProductDescriptionCulture_Culture_CultureID", Storage="_Production_ProductModelProductDescriptionCultureList", ThisKey="CultureID", OtherKey="CultureID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<Production_ProductModelProductDescriptionCulture> Production_ProductModelProductDescriptionCultureList
			{
				get { return this._Production_ProductModelProductDescriptionCultureList; }
				set { this._Production_ProductModelProductDescriptionCultureList.Assign(value); }
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
		#endregion Production.Culture

		#region Sales.Currency
		[TableAttribute(Name="Sales.Currency")]
		public partial class Sales_Currency : EntityBase<Sales_Currency, AdventureWorksDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private string _CurrencyCode;
			private string _Name;
			private DateTime _ModifiedDate;
			private EntitySet<Sales_CountryRegionCurrency> _Sales_CountryRegionCurrencyList;
			private EntitySet<Sales_CurrencyRate> _Sales_CurrencyRateList;
			private EntitySet<Sales_CurrencyRate> _CurrencyCodeSales_CurrencyRateList;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnCurrencyCodeChanging(string value);
			partial void OnCurrencyCodeChanged();
			partial void OnNameChanging(string value);
			partial void OnNameChanged();
			partial void OnModifiedDateChanging(DateTime value);
			partial void OnModifiedDateChanged();
			#endregion

			public Sales_Currency()
			{
				_Sales_CountryRegionCurrencyList = new EntitySet<Sales_CountryRegionCurrency>(
					new Action<Sales_CountryRegionCurrency>(item=>{this.SendPropertyChanging(); item.Sales_Currency=this;}), 
					new Action<Sales_CountryRegionCurrency>(item=>{this.SendPropertyChanging(); item.Sales_Currency=null;}));
				_Sales_CurrencyRateList = new EntitySet<Sales_CurrencyRate>(
					new Action<Sales_CurrencyRate>(item=>{this.SendPropertyChanging(); item.Sales_Currency=this;}), 
					new Action<Sales_CurrencyRate>(item=>{this.SendPropertyChanging(); item.Sales_Currency=null;}));
				_CurrencyCodeSales_CurrencyRateList = new EntitySet<Sales_CurrencyRate>(
					new Action<Sales_CurrencyRate>(item=>{this.SendPropertyChanging(); item.ToCurrencyCodeSales_Currency=this;}), 
					new Action<Sales_CurrencyRate>(item=>{this.SendPropertyChanging(); item.ToCurrencyCodeSales_Currency=null;}));
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=NChar(3) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_CurrencyCode", DbType="NChar(3) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
			public string CurrencyCode
			{
				get
				{
					return this._CurrencyCode;
				}
				set
				{
					if (this._CurrencyCode != value)
					{
						this.OnCurrencyCodeChanging(value);
						this.SendPropertyChanging();
						this._CurrencyCode = value;
						this.SendPropertyChanged("CurrencyCode");
						this.OnCurrencyCodeChanged();
					}
					this.SendPropertySetterInvoked("CurrencyCode", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(50) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_Name", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
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
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ModifiedDate", DbType="DateTime NOT NULL", CanBeNull=false)]
			public DateTime ModifiedDate
			{
				get
				{
					return this._ModifiedDate;
				}
				set
				{
					if (this._ModifiedDate != value)
					{
						this.OnModifiedDateChanging(value);
						this.SendPropertyChanging();
						this._ModifiedDate = value;
						this.SendPropertyChanged("ModifiedDate");
						this.OnModifiedDateChanged();
					}
					this.SendPropertySetterInvoked("ModifiedDate", value);
				}
			}
			
			#endregion Columns

			#region Associations
			/// <summary>
			/// Association [PK][One]Sales_Currency.CurrencyCode --- [FK][Many]Sales_CountryRegionCurrency.CurrencyCode
			/// </summary>
			[AssociationAttribute(Name="FK_CountryRegionCurrency_Currency_CurrencyCode", Storage="_Sales_CountryRegionCurrencyList", ThisKey="CurrencyCode", OtherKey="CurrencyCode", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<Sales_CountryRegionCurrency> Sales_CountryRegionCurrencyList
			{
				get { return this._Sales_CountryRegionCurrencyList; }
				set { this._Sales_CountryRegionCurrencyList.Assign(value); }
			}
			
			/// <summary>
			/// Association [PK][One]Sales_Currency.CurrencyCode --- [FK][Many]Sales_CurrencyRate.FromCurrencyCode
			/// </summary>
			[AssociationAttribute(Name="FK_CurrencyRate_Currency_FromCurrencyCode", Storage="_Sales_CurrencyRateList", ThisKey="CurrencyCode", OtherKey="FromCurrencyCode", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<Sales_CurrencyRate> Sales_CurrencyRateList
			{
				get { return this._Sales_CurrencyRateList; }
				set { this._Sales_CurrencyRateList.Assign(value); }
			}
			
			/// <summary>
			/// Association [PK][One]Sales_Currency.CurrencyCode --- [FK][Many]Sales_CurrencyRate.ToCurrencyCode
			/// </summary>
			[AssociationAttribute(Name="FK_CurrencyRate_Currency_ToCurrencyCode", Storage="_CurrencyCodeSales_CurrencyRateList", ThisKey="CurrencyCode", OtherKey="ToCurrencyCode", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<Sales_CurrencyRate> CurrencyCodeSales_CurrencyRateList
			{
				get { return this._CurrencyCodeSales_CurrencyRateList; }
				set { this._CurrencyCodeSales_CurrencyRateList.Assign(value); }
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
		#endregion Sales.Currency

		#region Sales.CurrencyRate
		[TableAttribute(Name="Sales.CurrencyRate")]
		public partial class Sales_CurrencyRate : EntityBase<Sales_CurrencyRate, AdventureWorksDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private int _CurrencyRateID;
			private DateTime _CurrencyRateDate;
			private string _FromCurrencyCode;
			private string _ToCurrencyCode;
			private decimal _AverageRate;
			private decimal _EndOfDayRate;
			private DateTime _ModifiedDate;
			private EntityRef<Sales_Currency> _Sales_Currency;
			private EntityRef<Sales_Currency> _ToCurrencyCodeSales_Currency;
			private EntitySet<Sales_SalesOrderHeader> _Sales_SalesOrderHeaderList;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnCurrencyRateIDChanging(int value);
			partial void OnCurrencyRateIDChanged();
			partial void OnCurrencyRateDateChanging(DateTime value);
			partial void OnCurrencyRateDateChanged();
			partial void OnFromCurrencyCodeChanging(string value);
			partial void OnFromCurrencyCodeChanged();
			partial void OnToCurrencyCodeChanging(string value);
			partial void OnToCurrencyCodeChanged();
			partial void OnAverageRateChanging(decimal value);
			partial void OnAverageRateChanged();
			partial void OnEndOfDayRateChanging(decimal value);
			partial void OnEndOfDayRateChanged();
			partial void OnModifiedDateChanging(DateTime value);
			partial void OnModifiedDateChanged();
			#endregion

			public Sales_CurrencyRate()
			{
				_Sales_Currency = default(EntityRef<Sales_Currency>);
				_ToCurrencyCodeSales_Currency = default(EntityRef<Sales_Currency>);
				_Sales_SalesOrderHeaderList = new EntitySet<Sales_SalesOrderHeader>(
					new Action<Sales_SalesOrderHeader>(item=>{this.SendPropertyChanging(); item.Sales_CurrencyRate=this;}), 
					new Action<Sales_SalesOrderHeader>(item=>{this.SendPropertyChanging(); item.Sales_CurrencyRate=null;}));
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=Int NOT NULL IDENTITY
			/// </summary>
			[ColumnAttribute(Storage="_CurrencyRateID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", CanBeNull=false, IsPrimaryKey=true, IsDbGenerated=true)]
			public int CurrencyRateID
			{
				get
				{
					return this._CurrencyRateID;
				}
				set
				{
					if (this._CurrencyRateID != value)
					{
						this.OnCurrencyRateIDChanging(value);
						this.SendPropertyChanging();
						this._CurrencyRateID = value;
						this.SendPropertyChanged("CurrencyRateID");
						this.OnCurrencyRateIDChanged();
					}
					this.SendPropertySetterInvoked("CurrencyRateID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_CurrencyRateDate", DbType="DateTime NOT NULL", CanBeNull=false)]
			public DateTime CurrencyRateDate
			{
				get
				{
					return this._CurrencyRateDate;
				}
				set
				{
					if (this._CurrencyRateDate != value)
					{
						this.OnCurrencyRateDateChanging(value);
						this.SendPropertyChanging();
						this._CurrencyRateDate = value;
						this.SendPropertyChanged("CurrencyRateDate");
						this.OnCurrencyRateDateChanged();
					}
					this.SendPropertySetterInvoked("CurrencyRateDate", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NChar(3) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_FromCurrencyCode", DbType="NChar(3) NOT NULL", CanBeNull=false)]
			public string FromCurrencyCode
			{
				get
				{
					return this._FromCurrencyCode;
				}
				set
				{
					if (this._FromCurrencyCode != value)
					{
						this.OnFromCurrencyCodeChanging(value);
						this.SendPropertyChanging();
						this._FromCurrencyCode = value;
						this.SendPropertyChanged("FromCurrencyCode");
						this.OnFromCurrencyCodeChanged();
					}
					this.SendPropertySetterInvoked("FromCurrencyCode", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NChar(3) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ToCurrencyCode", DbType="NChar(3) NOT NULL", CanBeNull=false)]
			public string ToCurrencyCode
			{
				get
				{
					return this._ToCurrencyCode;
				}
				set
				{
					if (this._ToCurrencyCode != value)
					{
						this.OnToCurrencyCodeChanging(value);
						this.SendPropertyChanging();
						this._ToCurrencyCode = value;
						this.SendPropertyChanged("ToCurrencyCode");
						this.OnToCurrencyCodeChanged();
					}
					this.SendPropertySetterInvoked("ToCurrencyCode", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Money NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_AverageRate", DbType="Money NOT NULL", CanBeNull=false)]
			public decimal AverageRate
			{
				get
				{
					return this._AverageRate;
				}
				set
				{
					if (this._AverageRate != value)
					{
						this.OnAverageRateChanging(value);
						this.SendPropertyChanging();
						this._AverageRate = value;
						this.SendPropertyChanged("AverageRate");
						this.OnAverageRateChanged();
					}
					this.SendPropertySetterInvoked("AverageRate", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Money NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_EndOfDayRate", DbType="Money NOT NULL", CanBeNull=false)]
			public decimal EndOfDayRate
			{
				get
				{
					return this._EndOfDayRate;
				}
				set
				{
					if (this._EndOfDayRate != value)
					{
						this.OnEndOfDayRateChanging(value);
						this.SendPropertyChanging();
						this._EndOfDayRate = value;
						this.SendPropertyChanged("EndOfDayRate");
						this.OnEndOfDayRateChanged();
					}
					this.SendPropertySetterInvoked("EndOfDayRate", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ModifiedDate", DbType="DateTime NOT NULL", CanBeNull=false)]
			public DateTime ModifiedDate
			{
				get
				{
					return this._ModifiedDate;
				}
				set
				{
					if (this._ModifiedDate != value)
					{
						this.OnModifiedDateChanging(value);
						this.SendPropertyChanging();
						this._ModifiedDate = value;
						this.SendPropertyChanged("ModifiedDate");
						this.OnModifiedDateChanged();
					}
					this.SendPropertySetterInvoked("ModifiedDate", value);
				}
			}
			
			#endregion Columns

			#region Associations
			/// <summary>
			/// Association [FK][Many]Sales_CurrencyRate.FromCurrencyCode --- [PK][One]Sales_Currency.CurrencyCode
			/// </summary>
			[AssociationAttribute(Name="FK_CurrencyRate_Currency_FromCurrencyCode", Storage="_Sales_Currency", ThisKey="FromCurrencyCode", OtherKey="CurrencyCode", IsUnique=false, IsForeignKey=true)]
			public Sales_Currency Sales_Currency
			{
				get
				{
					return this._Sales_Currency.Entity;
				}
				set
				{
					Sales_Currency previousValue = this._Sales_Currency.Entity;
					if ((previousValue != value) || (this._Sales_Currency.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._Sales_Currency.Entity = null;
							previousValue.Sales_CurrencyRateList.Remove(this);
						}
						this._Sales_Currency.Entity = value;
						if (value != null)
						{
							value.Sales_CurrencyRateList.Add(this);
							this._FromCurrencyCode = value.CurrencyCode;
						}
						else
						{
							this._FromCurrencyCode = default(string);
						}
						this.SendPropertyChanged("Sales_Currency");
					}
					this.SendPropertySetterInvoked("Sales_Currency", value);
				}
			}
			
			/// <summary>
			/// Association [FK][Many]Sales_CurrencyRate.ToCurrencyCode --- [PK][One]Sales_Currency.CurrencyCode
			/// </summary>
			[AssociationAttribute(Name="FK_CurrencyRate_Currency_ToCurrencyCode", Storage="_ToCurrencyCodeSales_Currency", ThisKey="ToCurrencyCode", OtherKey="CurrencyCode", IsUnique=false, IsForeignKey=true)]
			public Sales_Currency ToCurrencyCodeSales_Currency
			{
				get
				{
					return this._ToCurrencyCodeSales_Currency.Entity;
				}
				set
				{
					Sales_Currency previousValue = this._ToCurrencyCodeSales_Currency.Entity;
					if ((previousValue != value) || (this._ToCurrencyCodeSales_Currency.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._ToCurrencyCodeSales_Currency.Entity = null;
							previousValue.CurrencyCodeSales_CurrencyRateList.Remove(this);
						}
						this._ToCurrencyCodeSales_Currency.Entity = value;
						if (value != null)
						{
							value.CurrencyCodeSales_CurrencyRateList.Add(this);
							this._ToCurrencyCode = value.CurrencyCode;
						}
						else
						{
							this._ToCurrencyCode = default(string);
						}
						this.SendPropertyChanged("ToCurrencyCodeSales_Currency");
					}
					this.SendPropertySetterInvoked("ToCurrencyCodeSales_Currency", value);
				}
			}
			
			/// <summary>
			/// Association [PK][One]Sales_CurrencyRate.CurrencyRateID --- [FK][Many]Sales_SalesOrderHeader.CurrencyRateID
			/// </summary>
			[AssociationAttribute(Name="FK_SalesOrderHeader_CurrencyRate_CurrencyRateID", Storage="_Sales_SalesOrderHeaderList", ThisKey="CurrencyRateID", OtherKey="CurrencyRateID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<Sales_SalesOrderHeader> Sales_SalesOrderHeaderList
			{
				get { return this._Sales_SalesOrderHeaderList; }
				set { this._Sales_SalesOrderHeaderList.Assign(value); }
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
		#endregion Sales.CurrencyRate

		#region Sales.Customer
		[TableAttribute(Name="Sales.Customer")]
		public partial class Sales_Customer : EntityBase<Sales_Customer, AdventureWorksDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private int _CustomerID;
			private int? _TerritoryID;
			private string _AccountNumber;
			private string _CustomerType;
			private System.Guid _rowguid;
			private DateTime _ModifiedDate;
			private EntityRef<Sales_SalesTerritory> _Sales_SalesTerritory;
			private EntitySet<Sales_CustomerAddress> _Sales_CustomerAddressList;
			private EntityRef<Sales_Individual> _Sales_Individual;
			private EntitySet<Sales_SalesOrderHeader> _Sales_SalesOrderHeaderList;
			private EntityRef<Sales_Store> _Sales_Store;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnCustomerIDChanging(int value);
			partial void OnCustomerIDChanged();
			partial void OnTerritoryIDChanging(int? value);
			partial void OnTerritoryIDChanged();
			partial void OnAccountNumberChanging(string value);
			partial void OnAccountNumberChanged();
			partial void OnCustomerTypeChanging(string value);
			partial void OnCustomerTypeChanged();
			partial void OnrowguidChanging(System.Guid value);
			partial void OnrowguidChanged();
			partial void OnModifiedDateChanging(DateTime value);
			partial void OnModifiedDateChanged();
			#endregion

			public Sales_Customer()
			{
				_Sales_SalesTerritory = default(EntityRef<Sales_SalesTerritory>);
				_Sales_CustomerAddressList = new EntitySet<Sales_CustomerAddress>(
					new Action<Sales_CustomerAddress>(item=>{this.SendPropertyChanging(); item.Sales_Customer=this;}), 
					new Action<Sales_CustomerAddress>(item=>{this.SendPropertyChanging(); item.Sales_Customer=null;}));
				_Sales_Individual = default(EntityRef<Sales_Individual>);
				_Sales_SalesOrderHeaderList = new EntitySet<Sales_SalesOrderHeader>(
					new Action<Sales_SalesOrderHeader>(item=>{this.SendPropertyChanging(); item.Sales_Customer=this;}), 
					new Action<Sales_SalesOrderHeader>(item=>{this.SendPropertyChanging(); item.Sales_Customer=null;}));
				_Sales_Store = default(EntityRef<Sales_Store>);
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=Int NOT NULL IDENTITY
			/// </summary>
			[ColumnAttribute(Storage="_CustomerID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", CanBeNull=false, IsPrimaryKey=true, IsDbGenerated=true)]
			public int CustomerID
			{
				get
				{
					return this._CustomerID;
				}
				set
				{
					if (this._CustomerID != value)
					{
						this.OnCustomerIDChanging(value);
						this.SendPropertyChanging();
						this._CustomerID = value;
						this.SendPropertyChanged("CustomerID");
						this.OnCustomerIDChanged();
					}
					this.SendPropertySetterInvoked("CustomerID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int
			/// </summary>
			[ColumnAttribute(Storage="_TerritoryID", DbType="Int", CanBeNull=true)]
			public int? TerritoryID
			{
				get
				{
					return this._TerritoryID;
				}
				set
				{
					if (this._TerritoryID != value)
					{
						this.OnTerritoryIDChanging(value);
						this.SendPropertyChanging();
						this._TerritoryID = value;
						this.SendPropertyChanged("TerritoryID");
						this.OnTerritoryIDChanged();
					}
					this.SendPropertySetterInvoked("TerritoryID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=VarChar(10) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_AccountNumber", DbType="VarChar(10) NOT NULL", CanBeNull=false)]
			public string AccountNumber
			{
				get
				{
					return this._AccountNumber;
				}
				set
				{
					if (this._AccountNumber != value)
					{
						this.OnAccountNumberChanging(value);
						this.SendPropertyChanging();
						this._AccountNumber = value;
						this.SendPropertyChanged("AccountNumber");
						this.OnAccountNumberChanged();
					}
					this.SendPropertySetterInvoked("AccountNumber", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NChar(1) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_CustomerType", DbType="NChar(1) NOT NULL", CanBeNull=false)]
			public string CustomerType
			{
				get
				{
					return this._CustomerType;
				}
				set
				{
					if (this._CustomerType != value)
					{
						this.OnCustomerTypeChanging(value);
						this.SendPropertyChanging();
						this._CustomerType = value;
						this.SendPropertyChanged("CustomerType");
						this.OnCustomerTypeChanged();
					}
					this.SendPropertySetterInvoked("CustomerType", value);
				}
			}
			
			/// <summary>
			/// Column DbType=UniqueIdentifier NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_rowguid", DbType="UniqueIdentifier NOT NULL", CanBeNull=false)]
			public System.Guid rowguid
			{
				get
				{
					return this._rowguid;
				}
				set
				{
					if (this._rowguid != value)
					{
						this.OnrowguidChanging(value);
						this.SendPropertyChanging();
						this._rowguid = value;
						this.SendPropertyChanged("rowguid");
						this.OnrowguidChanged();
					}
					this.SendPropertySetterInvoked("rowguid", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ModifiedDate", DbType="DateTime NOT NULL", CanBeNull=false)]
			public DateTime ModifiedDate
			{
				get
				{
					return this._ModifiedDate;
				}
				set
				{
					if (this._ModifiedDate != value)
					{
						this.OnModifiedDateChanging(value);
						this.SendPropertyChanging();
						this._ModifiedDate = value;
						this.SendPropertyChanged("ModifiedDate");
						this.OnModifiedDateChanged();
					}
					this.SendPropertySetterInvoked("ModifiedDate", value);
				}
			}
			
			#endregion Columns

			#region Associations
			/// <summary>
			/// Association [FK][Many]Sales_Customer.TerritoryID --- [PK][One]Sales_SalesTerritory.TerritoryID
			/// </summary>
			[AssociationAttribute(Name="FK_Customer_SalesTerritory_TerritoryID", Storage="_Sales_SalesTerritory", ThisKey="TerritoryID", OtherKey="TerritoryID", IsUnique=false, IsForeignKey=true)]
			public Sales_SalesTerritory Sales_SalesTerritory
			{
				get
				{
					return this._Sales_SalesTerritory.Entity;
				}
				set
				{
					Sales_SalesTerritory previousValue = this._Sales_SalesTerritory.Entity;
					if ((previousValue != value) || (this._Sales_SalesTerritory.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._Sales_SalesTerritory.Entity = null;
							previousValue.Sales_CustomerList.Remove(this);
						}
						this._Sales_SalesTerritory.Entity = value;
						if (value != null)
						{
							value.Sales_CustomerList.Add(this);
							this._TerritoryID = value.TerritoryID;
						}
						else
						{
							this._TerritoryID = default(int?);
						}
						this.SendPropertyChanged("Sales_SalesTerritory");
					}
					this.SendPropertySetterInvoked("Sales_SalesTerritory", value);
				}
			}
			
			/// <summary>
			/// Association [PK][One]Sales_Customer.CustomerID --- [FK][Many]Sales_CustomerAddress.CustomerID
			/// </summary>
			[AssociationAttribute(Name="FK_CustomerAddress_Customer_CustomerID", Storage="_Sales_CustomerAddressList", ThisKey="CustomerID", OtherKey="CustomerID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<Sales_CustomerAddress> Sales_CustomerAddressList
			{
				get { return this._Sales_CustomerAddressList; }
				set { this._Sales_CustomerAddressList.Assign(value); }
			}
			
			/// <summary>
			/// Association [PK][One]Sales_Customer.CustomerID --- [FK][One]Sales_Individual.CustomerID
			/// </summary>
			[AssociationAttribute(Name="FK_Individual_Customer_CustomerID", Storage="_Sales_Individual", ThisKey="CustomerID", OtherKey="CustomerID", IsUnique=true, IsForeignKey=false, DeleteRule="NoAction")]
			public Sales_Individual Sales_Individual
			{
				get
				{
					return this._Sales_Individual.Entity;
				}
				set
				{
					Sales_Individual previousValue = this._Sales_Individual.Entity;
					if ((previousValue != value) || (this._Sales_Individual.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._Sales_Individual.Entity = null;
							previousValue.Sales_Customer = null;
						}
						this._Sales_Individual.Entity = value;
						if (value != null)
						{
							value.Sales_Customer = this;
						}
						this.SendPropertyChanged("Sales_Individual");
					}
					this.SendPropertySetterInvoked("Sales_Individual", value);
				}
			}
			
			/// <summary>
			/// Association [PK][One]Sales_Customer.CustomerID --- [FK][Many]Sales_SalesOrderHeader.CustomerID
			/// </summary>
			[AssociationAttribute(Name="FK_SalesOrderHeader_Customer_CustomerID", Storage="_Sales_SalesOrderHeaderList", ThisKey="CustomerID", OtherKey="CustomerID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<Sales_SalesOrderHeader> Sales_SalesOrderHeaderList
			{
				get { return this._Sales_SalesOrderHeaderList; }
				set { this._Sales_SalesOrderHeaderList.Assign(value); }
			}
			
			/// <summary>
			/// Association [PK][One]Sales_Customer.CustomerID --- [FK][One]Sales_Store.CustomerID
			/// </summary>
			[AssociationAttribute(Name="FK_Store_Customer_CustomerID", Storage="_Sales_Store", ThisKey="CustomerID", OtherKey="CustomerID", IsUnique=true, IsForeignKey=false, DeleteRule="NoAction")]
			public Sales_Store Sales_Store
			{
				get
				{
					return this._Sales_Store.Entity;
				}
				set
				{
					Sales_Store previousValue = this._Sales_Store.Entity;
					if ((previousValue != value) || (this._Sales_Store.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._Sales_Store.Entity = null;
							previousValue.Sales_Customer = null;
						}
						this._Sales_Store.Entity = value;
						if (value != null)
						{
							value.Sales_Customer = this;
						}
						this.SendPropertyChanged("Sales_Store");
					}
					this.SendPropertySetterInvoked("Sales_Store", value);
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
		#endregion Sales.Customer

		#region Sales.CustomerAddress
		[TableAttribute(Name="Sales.CustomerAddress")]
		public partial class Sales_CustomerAddress : EntityBase<Sales_CustomerAddress, AdventureWorksDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private int _CustomerID;
			private int _AddressID;
			private int _AddressTypeID;
			private System.Guid _rowguid;
			private DateTime _ModifiedDate;
			private EntityRef<Person_Address> _Person_Address;
			private EntityRef<Person_AddressType> _Person_AddressType;
			private EntityRef<Sales_Customer> _Sales_Customer;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnCustomerIDChanging(int value);
			partial void OnCustomerIDChanged();
			partial void OnAddressIDChanging(int value);
			partial void OnAddressIDChanged();
			partial void OnAddressTypeIDChanging(int value);
			partial void OnAddressTypeIDChanged();
			partial void OnrowguidChanging(System.Guid value);
			partial void OnrowguidChanged();
			partial void OnModifiedDateChanging(DateTime value);
			partial void OnModifiedDateChanged();
			#endregion

			public Sales_CustomerAddress()
			{
				_Person_Address = default(EntityRef<Person_Address>);
				_Person_AddressType = default(EntityRef<Person_AddressType>);
				_Sales_Customer = default(EntityRef<Sales_Customer>);
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_CustomerID", DbType="Int NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
			public int CustomerID
			{
				get
				{
					return this._CustomerID;
				}
				set
				{
					if (this._CustomerID != value)
					{
						this.OnCustomerIDChanging(value);
						this.SendPropertyChanging();
						this._CustomerID = value;
						this.SendPropertyChanged("CustomerID");
						this.OnCustomerIDChanged();
					}
					this.SendPropertySetterInvoked("CustomerID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_AddressID", DbType="Int NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
			public int AddressID
			{
				get
				{
					return this._AddressID;
				}
				set
				{
					if (this._AddressID != value)
					{
						this.OnAddressIDChanging(value);
						this.SendPropertyChanging();
						this._AddressID = value;
						this.SendPropertyChanged("AddressID");
						this.OnAddressIDChanged();
					}
					this.SendPropertySetterInvoked("AddressID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_AddressTypeID", DbType="Int NOT NULL", CanBeNull=false)]
			public int AddressTypeID
			{
				get
				{
					return this._AddressTypeID;
				}
				set
				{
					if (this._AddressTypeID != value)
					{
						this.OnAddressTypeIDChanging(value);
						this.SendPropertyChanging();
						this._AddressTypeID = value;
						this.SendPropertyChanged("AddressTypeID");
						this.OnAddressTypeIDChanged();
					}
					this.SendPropertySetterInvoked("AddressTypeID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=UniqueIdentifier NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_rowguid", DbType="UniqueIdentifier NOT NULL", CanBeNull=false)]
			public System.Guid rowguid
			{
				get
				{
					return this._rowguid;
				}
				set
				{
					if (this._rowguid != value)
					{
						this.OnrowguidChanging(value);
						this.SendPropertyChanging();
						this._rowguid = value;
						this.SendPropertyChanged("rowguid");
						this.OnrowguidChanged();
					}
					this.SendPropertySetterInvoked("rowguid", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ModifiedDate", DbType="DateTime NOT NULL", CanBeNull=false)]
			public DateTime ModifiedDate
			{
				get
				{
					return this._ModifiedDate;
				}
				set
				{
					if (this._ModifiedDate != value)
					{
						this.OnModifiedDateChanging(value);
						this.SendPropertyChanging();
						this._ModifiedDate = value;
						this.SendPropertyChanged("ModifiedDate");
						this.OnModifiedDateChanged();
					}
					this.SendPropertySetterInvoked("ModifiedDate", value);
				}
			}
			
			#endregion Columns

			#region Associations
			/// <summary>
			/// Association [FK][Many]Sales_CustomerAddress.AddressID --- [PK][One]Person_Address.AddressID
			/// </summary>
			[AssociationAttribute(Name="FK_CustomerAddress_Address_AddressID", Storage="_Person_Address", ThisKey="AddressID", OtherKey="AddressID", IsUnique=false, IsForeignKey=true)]
			public Person_Address Person_Address
			{
				get
				{
					return this._Person_Address.Entity;
				}
				set
				{
					Person_Address previousValue = this._Person_Address.Entity;
					if ((previousValue != value) || (this._Person_Address.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._Person_Address.Entity = null;
							previousValue.Sales_CustomerAddressList.Remove(this);
						}
						this._Person_Address.Entity = value;
						if (value != null)
						{
							value.Sales_CustomerAddressList.Add(this);
							this._AddressID = value.AddressID;
						}
						else
						{
							this._AddressID = default(int);
						}
						this.SendPropertyChanged("Person_Address");
					}
					this.SendPropertySetterInvoked("Person_Address", value);
				}
			}
			
			/// <summary>
			/// Association [FK][Many]Sales_CustomerAddress.AddressTypeID --- [PK][One]Person_AddressType.AddressTypeID
			/// </summary>
			[AssociationAttribute(Name="FK_CustomerAddress_AddressType_AddressTypeID", Storage="_Person_AddressType", ThisKey="AddressTypeID", OtherKey="AddressTypeID", IsUnique=false, IsForeignKey=true)]
			public Person_AddressType Person_AddressType
			{
				get
				{
					return this._Person_AddressType.Entity;
				}
				set
				{
					Person_AddressType previousValue = this._Person_AddressType.Entity;
					if ((previousValue != value) || (this._Person_AddressType.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._Person_AddressType.Entity = null;
							previousValue.Sales_CustomerAddressList.Remove(this);
						}
						this._Person_AddressType.Entity = value;
						if (value != null)
						{
							value.Sales_CustomerAddressList.Add(this);
							this._AddressTypeID = value.AddressTypeID;
						}
						else
						{
							this._AddressTypeID = default(int);
						}
						this.SendPropertyChanged("Person_AddressType");
					}
					this.SendPropertySetterInvoked("Person_AddressType", value);
				}
			}
			
			/// <summary>
			/// Association [FK][Many]Sales_CustomerAddress.CustomerID --- [PK][One]Sales_Customer.CustomerID
			/// </summary>
			[AssociationAttribute(Name="FK_CustomerAddress_Customer_CustomerID", Storage="_Sales_Customer", ThisKey="CustomerID", OtherKey="CustomerID", IsUnique=false, IsForeignKey=true)]
			public Sales_Customer Sales_Customer
			{
				get
				{
					return this._Sales_Customer.Entity;
				}
				set
				{
					Sales_Customer previousValue = this._Sales_Customer.Entity;
					if ((previousValue != value) || (this._Sales_Customer.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._Sales_Customer.Entity = null;
							previousValue.Sales_CustomerAddressList.Remove(this);
						}
						this._Sales_Customer.Entity = value;
						if (value != null)
						{
							value.Sales_CustomerAddressList.Add(this);
							this._CustomerID = value.CustomerID;
						}
						else
						{
							this._CustomerID = default(int);
						}
						this.SendPropertyChanged("Sales_Customer");
					}
					this.SendPropertySetterInvoked("Sales_Customer", value);
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
		#endregion Sales.CustomerAddress

		#region dbo.DatabaseLog
		[TableAttribute(Name="dbo.DatabaseLog")]
		public partial class DatabaseLog : EntityBase<DatabaseLog, AdventureWorksDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private int _DatabaseLogID;
			private DateTime _PostTime;
			private string _DatabaseUser;
			private string _Event;
			private string _Schema;
			private string _Object;
			private string _TSQL;
			private System.Xml.Linq.XElement _XmlEvent;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnDatabaseLogIDChanging(int value);
			partial void OnDatabaseLogIDChanged();
			partial void OnPostTimeChanging(DateTime value);
			partial void OnPostTimeChanged();
			partial void OnDatabaseUserChanging(string value);
			partial void OnDatabaseUserChanged();
			partial void OnEventChanging(string value);
			partial void OnEventChanged();
			partial void OnSchemaChanging(string value);
			partial void OnSchemaChanged();
			partial void OnObjectChanging(string value);
			partial void OnObjectChanged();
			partial void OnTSQLChanging(string value);
			partial void OnTSQLChanged();
			partial void OnXmlEventChanging(System.Xml.Linq.XElement value);
			partial void OnXmlEventChanged();
			#endregion

			public DatabaseLog()
			{
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=Int NOT NULL IDENTITY
			/// </summary>
			[ColumnAttribute(Storage="_DatabaseLogID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", CanBeNull=false, IsPrimaryKey=true, IsDbGenerated=true)]
			public int DatabaseLogID
			{
				get
				{
					return this._DatabaseLogID;
				}
				set
				{
					if (this._DatabaseLogID != value)
					{
						this.OnDatabaseLogIDChanging(value);
						this.SendPropertyChanging();
						this._DatabaseLogID = value;
						this.SendPropertyChanged("DatabaseLogID");
						this.OnDatabaseLogIDChanged();
					}
					this.SendPropertySetterInvoked("DatabaseLogID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_PostTime", DbType="DateTime NOT NULL", CanBeNull=false)]
			public DateTime PostTime
			{
				get
				{
					return this._PostTime;
				}
				set
				{
					if (this._PostTime != value)
					{
						this.OnPostTimeChanging(value);
						this.SendPropertyChanging();
						this._PostTime = value;
						this.SendPropertyChanged("PostTime");
						this.OnPostTimeChanged();
					}
					this.SendPropertySetterInvoked("PostTime", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(128) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_DatabaseUser", DbType="NVarChar(128) NOT NULL", CanBeNull=false)]
			public string DatabaseUser
			{
				get
				{
					return this._DatabaseUser;
				}
				set
				{
					if (this._DatabaseUser != value)
					{
						this.OnDatabaseUserChanging(value);
						this.SendPropertyChanging();
						this._DatabaseUser = value;
						this.SendPropertyChanged("DatabaseUser");
						this.OnDatabaseUserChanged();
					}
					this.SendPropertySetterInvoked("DatabaseUser", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(128) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_Event", DbType="NVarChar(128) NOT NULL", CanBeNull=false)]
			public string Event
			{
				get
				{
					return this._Event;
				}
				set
				{
					if (this._Event != value)
					{
						this.OnEventChanging(value);
						this.SendPropertyChanging();
						this._Event = value;
						this.SendPropertyChanged("Event");
						this.OnEventChanged();
					}
					this.SendPropertySetterInvoked("Event", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(128)
			/// </summary>
			[ColumnAttribute(Storage="_Schema", DbType="NVarChar(128)", CanBeNull=true)]
			public string Schema
			{
				get
				{
					return this._Schema;
				}
				set
				{
					if (this._Schema != value)
					{
						this.OnSchemaChanging(value);
						this.SendPropertyChanging();
						this._Schema = value;
						this.SendPropertyChanged("Schema");
						this.OnSchemaChanged();
					}
					this.SendPropertySetterInvoked("Schema", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(128)
			/// </summary>
			[ColumnAttribute(Storage="_Object", DbType="NVarChar(128)", CanBeNull=true)]
			public string Object
			{
				get
				{
					return this._Object;
				}
				set
				{
					if (this._Object != value)
					{
						this.OnObjectChanging(value);
						this.SendPropertyChanging();
						this._Object = value;
						this.SendPropertyChanged("Object");
						this.OnObjectChanged();
					}
					this.SendPropertySetterInvoked("Object", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(MAX) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_TSQL", DbType="NVarChar(MAX) NOT NULL", CanBeNull=false)]
			public string TSQL
			{
				get
				{
					return this._TSQL;
				}
				set
				{
					if (this._TSQL != value)
					{
						this.OnTSQLChanging(value);
						this.SendPropertyChanging();
						this._TSQL = value;
						this.SendPropertyChanged("TSQL");
						this.OnTSQLChanged();
					}
					this.SendPropertySetterInvoked("TSQL", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Xml NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_XmlEvent", DbType="Xml NOT NULL", CanBeNull=false)]
			public System.Xml.Linq.XElement XmlEvent
			{
				get
				{
					return this._XmlEvent;
				}
				set
				{
					if (this._XmlEvent != value)
					{
						this.OnXmlEventChanging(value);
						this.SendPropertyChanging();
						this._XmlEvent = value;
						this.SendPropertyChanged("XmlEvent");
						this.OnXmlEventChanged();
					}
					this.SendPropertySetterInvoked("XmlEvent", value);
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
		#endregion dbo.DatabaseLog

		#region HumanResources.Department
		[TableAttribute(Name="HumanResources.Department")]
		public partial class HumanResources_Department : EntityBase<HumanResources_Department, AdventureWorksDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private System.Int16 _DepartmentID;
			private string _Name;
			private string _GroupName;
			private DateTime _ModifiedDate;
			private EntitySet<HumanResources_EmployeeDepartmentHistory> _HumanResources_EmployeeDepartmentHistoryList;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnDepartmentIDChanging(System.Int16 value);
			partial void OnDepartmentIDChanged();
			partial void OnNameChanging(string value);
			partial void OnNameChanged();
			partial void OnGroupNameChanging(string value);
			partial void OnGroupNameChanged();
			partial void OnModifiedDateChanging(DateTime value);
			partial void OnModifiedDateChanged();
			#endregion

			public HumanResources_Department()
			{
				_HumanResources_EmployeeDepartmentHistoryList = new EntitySet<HumanResources_EmployeeDepartmentHistory>(
					new Action<HumanResources_EmployeeDepartmentHistory>(item=>{this.SendPropertyChanging(); item.HumanResources_Department=this;}), 
					new Action<HumanResources_EmployeeDepartmentHistory>(item=>{this.SendPropertyChanging(); item.HumanResources_Department=null;}));
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=SmallInt NOT NULL IDENTITY
			/// </summary>
			[ColumnAttribute(Storage="_DepartmentID", AutoSync=AutoSync.OnInsert, DbType="SmallInt NOT NULL IDENTITY", CanBeNull=false, IsPrimaryKey=true, IsDbGenerated=true)]
			public System.Int16 DepartmentID
			{
				get
				{
					return this._DepartmentID;
				}
				set
				{
					if (this._DepartmentID != value)
					{
						this.OnDepartmentIDChanging(value);
						this.SendPropertyChanging();
						this._DepartmentID = value;
						this.SendPropertyChanged("DepartmentID");
						this.OnDepartmentIDChanged();
					}
					this.SendPropertySetterInvoked("DepartmentID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(50) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_Name", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
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
			/// Column DbType=NVarChar(50) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_GroupName", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
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
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ModifiedDate", DbType="DateTime NOT NULL", CanBeNull=false)]
			public DateTime ModifiedDate
			{
				get
				{
					return this._ModifiedDate;
				}
				set
				{
					if (this._ModifiedDate != value)
					{
						this.OnModifiedDateChanging(value);
						this.SendPropertyChanging();
						this._ModifiedDate = value;
						this.SendPropertyChanged("ModifiedDate");
						this.OnModifiedDateChanged();
					}
					this.SendPropertySetterInvoked("ModifiedDate", value);
				}
			}
			
			#endregion Columns

			#region Associations
			/// <summary>
			/// Association [PK][One]HumanResources_Department.DepartmentID --- [FK][Many]HumanResources_EmployeeDepartmentHistory.DepartmentID
			/// </summary>
			[AssociationAttribute(Name="FK_EmployeeDepartmentHistory_Department_DepartmentID", Storage="_HumanResources_EmployeeDepartmentHistoryList", ThisKey="DepartmentID", OtherKey="DepartmentID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<HumanResources_EmployeeDepartmentHistory> HumanResources_EmployeeDepartmentHistoryList
			{
				get { return this._HumanResources_EmployeeDepartmentHistoryList; }
				set { this._HumanResources_EmployeeDepartmentHistoryList.Assign(value); }
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
		#endregion HumanResources.Department

		#region Production.Document
		[TableAttribute(Name="Production.Document")]
		public partial class Production_Document : EntityBase<Production_Document, AdventureWorksDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private int _DocumentID;
			private string _Title;
			private string _FileName;
			private string _FileExtension;
			private string _Revision;
			private int _ChangeNumber;
			private byte _Status;
			private string _DocumentSummary;
			private byte[] _Document;
			private DateTime _ModifiedDate;
			private EntitySet<Production_ProductDocument> _Production_ProductDocumentList;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnDocumentIDChanging(int value);
			partial void OnDocumentIDChanged();
			partial void OnTitleChanging(string value);
			partial void OnTitleChanged();
			partial void OnFileNameChanging(string value);
			partial void OnFileNameChanged();
			partial void OnFileExtensionChanging(string value);
			partial void OnFileExtensionChanged();
			partial void OnRevisionChanging(string value);
			partial void OnRevisionChanged();
			partial void OnChangeNumberChanging(int value);
			partial void OnChangeNumberChanged();
			partial void OnStatusChanging(byte value);
			partial void OnStatusChanged();
			partial void OnDocumentSummaryChanging(string value);
			partial void OnDocumentSummaryChanged();
			partial void OnDocumentChanging(byte[] value);
			partial void OnDocumentChanged();
			partial void OnModifiedDateChanging(DateTime value);
			partial void OnModifiedDateChanged();
			#endregion

			public Production_Document()
			{
				_Production_ProductDocumentList = new EntitySet<Production_ProductDocument>(
					new Action<Production_ProductDocument>(item=>{this.SendPropertyChanging(); item.Production_Document=this;}), 
					new Action<Production_ProductDocument>(item=>{this.SendPropertyChanging(); item.Production_Document=null;}));
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=Int NOT NULL IDENTITY
			/// </summary>
			[ColumnAttribute(Storage="_DocumentID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", CanBeNull=false, IsPrimaryKey=true, IsDbGenerated=true)]
			public int DocumentID
			{
				get
				{
					return this._DocumentID;
				}
				set
				{
					if (this._DocumentID != value)
					{
						this.OnDocumentIDChanging(value);
						this.SendPropertyChanging();
						this._DocumentID = value;
						this.SendPropertyChanged("DocumentID");
						this.OnDocumentIDChanged();
					}
					this.SendPropertySetterInvoked("DocumentID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(50) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_Title", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
			public string Title
			{
				get
				{
					return this._Title;
				}
				set
				{
					if (this._Title != value)
					{
						this.OnTitleChanging(value);
						this.SendPropertyChanging();
						this._Title = value;
						this.SendPropertyChanged("Title");
						this.OnTitleChanged();
					}
					this.SendPropertySetterInvoked("Title", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(400) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_FileName", DbType="NVarChar(400) NOT NULL", CanBeNull=false)]
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
			/// Column DbType=NVarChar(8) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_FileExtension", DbType="NVarChar(8) NOT NULL", CanBeNull=false)]
			public string FileExtension
			{
				get
				{
					return this._FileExtension;
				}
				set
				{
					if (this._FileExtension != value)
					{
						this.OnFileExtensionChanging(value);
						this.SendPropertyChanging();
						this._FileExtension = value;
						this.SendPropertyChanged("FileExtension");
						this.OnFileExtensionChanged();
					}
					this.SendPropertySetterInvoked("FileExtension", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NChar(5) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_Revision", DbType="NChar(5) NOT NULL", CanBeNull=false)]
			public string Revision
			{
				get
				{
					return this._Revision;
				}
				set
				{
					if (this._Revision != value)
					{
						this.OnRevisionChanging(value);
						this.SendPropertyChanging();
						this._Revision = value;
						this.SendPropertyChanged("Revision");
						this.OnRevisionChanged();
					}
					this.SendPropertySetterInvoked("Revision", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ChangeNumber", DbType="Int NOT NULL", CanBeNull=false)]
			public int ChangeNumber
			{
				get
				{
					return this._ChangeNumber;
				}
				set
				{
					if (this._ChangeNumber != value)
					{
						this.OnChangeNumberChanging(value);
						this.SendPropertyChanging();
						this._ChangeNumber = value;
						this.SendPropertyChanged("ChangeNumber");
						this.OnChangeNumberChanged();
					}
					this.SendPropertySetterInvoked("ChangeNumber", value);
				}
			}
			
			/// <summary>
			/// Column DbType=TinyInt NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_Status", DbType="TinyInt NOT NULL", CanBeNull=false)]
			public byte Status
			{
				get
				{
					return this._Status;
				}
				set
				{
					if (this._Status != value)
					{
						this.OnStatusChanging(value);
						this.SendPropertyChanging();
						this._Status = value;
						this.SendPropertyChanged("Status");
						this.OnStatusChanged();
					}
					this.SendPropertySetterInvoked("Status", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(MAX)
			/// </summary>
			[ColumnAttribute(Storage="_DocumentSummary", DbType="NVarChar(MAX)", CanBeNull=true)]
			public string DocumentSummary
			{
				get
				{
					return this._DocumentSummary;
				}
				set
				{
					if (this._DocumentSummary != value)
					{
						this.OnDocumentSummaryChanging(value);
						this.SendPropertyChanging();
						this._DocumentSummary = value;
						this.SendPropertyChanged("DocumentSummary");
						this.OnDocumentSummaryChanged();
					}
					this.SendPropertySetterInvoked("DocumentSummary", value);
				}
			}
			
			/// <summary>
			/// Column DbType=VarBinary(MAX)
			/// </summary>
			[ColumnAttribute(Storage="_Document", DbType="VarBinary(MAX)", CanBeNull=true)]
			public byte[] Document
			{
				get
				{
					return this._Document;
				}
				set
				{
					if (this._Document != value)
					{
						this.OnDocumentChanging(value);
						this.SendPropertyChanging();
						this._Document = value;
						this.SendPropertyChanged("Document");
						this.OnDocumentChanged();
					}
					this.SendPropertySetterInvoked("Document", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ModifiedDate", DbType="DateTime NOT NULL", CanBeNull=false)]
			public DateTime ModifiedDate
			{
				get
				{
					return this._ModifiedDate;
				}
				set
				{
					if (this._ModifiedDate != value)
					{
						this.OnModifiedDateChanging(value);
						this.SendPropertyChanging();
						this._ModifiedDate = value;
						this.SendPropertyChanged("ModifiedDate");
						this.OnModifiedDateChanged();
					}
					this.SendPropertySetterInvoked("ModifiedDate", value);
				}
			}
			
			#endregion Columns

			#region Associations
			/// <summary>
			/// Association [PK][One]Production_Document.DocumentID --- [FK][Many]Production_ProductDocument.DocumentID
			/// </summary>
			[AssociationAttribute(Name="FK_ProductDocument_Document_DocumentID", Storage="_Production_ProductDocumentList", ThisKey="DocumentID", OtherKey="DocumentID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<Production_ProductDocument> Production_ProductDocumentList
			{
				get { return this._Production_ProductDocumentList; }
				set { this._Production_ProductDocumentList.Assign(value); }
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
		#endregion Production.Document

		#region HumanResources.Employee
		[TableAttribute(Name="HumanResources.Employee")]
		public partial class HumanResources_Employee : EntityBase<HumanResources_Employee, AdventureWorksDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private int _EmployeeID;
			private string _NationalIDNumber;
			private int _ContactID;
			private string _LoginID;
			private int? _ManagerID;
			private string _Title;
			private DateTime _BirthDate;
			private string _MaritalStatus;
			private string _Gender;
			private DateTime _HireDate;
			private bool _SalariedFlag;
			private System.Int16 _VacationHours;
			private System.Int16 _SickLeaveHours;
			private bool _CurrentFlag;
			private System.Guid _rowguid;
			private DateTime _ModifiedDate;
			private EntityRef<Person_Contact> _Person_Contact;
			private EntityRef<HumanResources_Employee> _Manager;
			private EntitySet<HumanResources_Employee> _EmployeeList;
			private EntitySet<HumanResources_EmployeeAddress> _HumanResources_EmployeeAddressList;
			private EntitySet<HumanResources_EmployeeDepartmentHistory> _HumanResources_EmployeeDepartmentHistoryList;
			private EntitySet<HumanResources_EmployeePayHistory> _HumanResources_EmployeePayHistoryList;
			private EntitySet<HumanResources_JobCandidate> _HumanResources_JobCandidateList;
			private EntitySet<Purchasing_PurchaseOrderHeader> _Purchasing_PurchaseOrderHeaderList;
			private EntityRef<Sales_SalesPerson> _Sales_SalesPerson;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnEmployeeIDChanging(int value);
			partial void OnEmployeeIDChanged();
			partial void OnNationalIDNumberChanging(string value);
			partial void OnNationalIDNumberChanged();
			partial void OnContactIDChanging(int value);
			partial void OnContactIDChanged();
			partial void OnLoginIDChanging(string value);
			partial void OnLoginIDChanged();
			partial void OnManagerIDChanging(int? value);
			partial void OnManagerIDChanged();
			partial void OnTitleChanging(string value);
			partial void OnTitleChanged();
			partial void OnBirthDateChanging(DateTime value);
			partial void OnBirthDateChanged();
			partial void OnMaritalStatusChanging(string value);
			partial void OnMaritalStatusChanged();
			partial void OnGenderChanging(string value);
			partial void OnGenderChanged();
			partial void OnHireDateChanging(DateTime value);
			partial void OnHireDateChanged();
			partial void OnSalariedFlagChanging(bool value);
			partial void OnSalariedFlagChanged();
			partial void OnVacationHoursChanging(System.Int16 value);
			partial void OnVacationHoursChanged();
			partial void OnSickLeaveHoursChanging(System.Int16 value);
			partial void OnSickLeaveHoursChanged();
			partial void OnCurrentFlagChanging(bool value);
			partial void OnCurrentFlagChanged();
			partial void OnrowguidChanging(System.Guid value);
			partial void OnrowguidChanged();
			partial void OnModifiedDateChanging(DateTime value);
			partial void OnModifiedDateChanged();
			#endregion

			public HumanResources_Employee()
			{
				_Person_Contact = default(EntityRef<Person_Contact>);
				_Manager = default(EntityRef<HumanResources_Employee>);
				_EmployeeList = new EntitySet<HumanResources_Employee>(
					new Action<HumanResources_Employee>(item=>{this.SendPropertyChanging(); item.Manager=this;}), 
					new Action<HumanResources_Employee>(item=>{this.SendPropertyChanging(); item.Manager=null;}));
				_HumanResources_EmployeeAddressList = new EntitySet<HumanResources_EmployeeAddress>(
					new Action<HumanResources_EmployeeAddress>(item=>{this.SendPropertyChanging(); item.HumanResources_Employee=this;}), 
					new Action<HumanResources_EmployeeAddress>(item=>{this.SendPropertyChanging(); item.HumanResources_Employee=null;}));
				_HumanResources_EmployeeDepartmentHistoryList = new EntitySet<HumanResources_EmployeeDepartmentHistory>(
					new Action<HumanResources_EmployeeDepartmentHistory>(item=>{this.SendPropertyChanging(); item.HumanResources_Employee=this;}), 
					new Action<HumanResources_EmployeeDepartmentHistory>(item=>{this.SendPropertyChanging(); item.HumanResources_Employee=null;}));
				_HumanResources_EmployeePayHistoryList = new EntitySet<HumanResources_EmployeePayHistory>(
					new Action<HumanResources_EmployeePayHistory>(item=>{this.SendPropertyChanging(); item.HumanResources_Employee=this;}), 
					new Action<HumanResources_EmployeePayHistory>(item=>{this.SendPropertyChanging(); item.HumanResources_Employee=null;}));
				_HumanResources_JobCandidateList = new EntitySet<HumanResources_JobCandidate>(
					new Action<HumanResources_JobCandidate>(item=>{this.SendPropertyChanging(); item.HumanResources_Employee=this;}), 
					new Action<HumanResources_JobCandidate>(item=>{this.SendPropertyChanging(); item.HumanResources_Employee=null;}));
				_Purchasing_PurchaseOrderHeaderList = new EntitySet<Purchasing_PurchaseOrderHeader>(
					new Action<Purchasing_PurchaseOrderHeader>(item=>{this.SendPropertyChanging(); item.HumanResources_Employee=this;}), 
					new Action<Purchasing_PurchaseOrderHeader>(item=>{this.SendPropertyChanging(); item.HumanResources_Employee=null;}));
				_Sales_SalesPerson = default(EntityRef<Sales_SalesPerson>);
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=Int NOT NULL IDENTITY
			/// </summary>
			[ColumnAttribute(Storage="_EmployeeID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", CanBeNull=false, IsPrimaryKey=true, IsDbGenerated=true)]
			public int EmployeeID
			{
				get
				{
					return this._EmployeeID;
				}
				set
				{
					if (this._EmployeeID != value)
					{
						this.OnEmployeeIDChanging(value);
						this.SendPropertyChanging();
						this._EmployeeID = value;
						this.SendPropertyChanged("EmployeeID");
						this.OnEmployeeIDChanged();
					}
					this.SendPropertySetterInvoked("EmployeeID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(15) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_NationalIDNumber", DbType="NVarChar(15) NOT NULL", CanBeNull=false)]
			public string NationalIDNumber
			{
				get
				{
					return this._NationalIDNumber;
				}
				set
				{
					if (this._NationalIDNumber != value)
					{
						this.OnNationalIDNumberChanging(value);
						this.SendPropertyChanging();
						this._NationalIDNumber = value;
						this.SendPropertyChanged("NationalIDNumber");
						this.OnNationalIDNumberChanged();
					}
					this.SendPropertySetterInvoked("NationalIDNumber", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ContactID", DbType="Int NOT NULL", CanBeNull=false)]
			public int ContactID
			{
				get
				{
					return this._ContactID;
				}
				set
				{
					if (this._ContactID != value)
					{
						this.OnContactIDChanging(value);
						this.SendPropertyChanging();
						this._ContactID = value;
						this.SendPropertyChanged("ContactID");
						this.OnContactIDChanged();
					}
					this.SendPropertySetterInvoked("ContactID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(256) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_LoginID", DbType="NVarChar(256) NOT NULL", CanBeNull=false)]
			public string LoginID
			{
				get
				{
					return this._LoginID;
				}
				set
				{
					if (this._LoginID != value)
					{
						this.OnLoginIDChanging(value);
						this.SendPropertyChanging();
						this._LoginID = value;
						this.SendPropertyChanged("LoginID");
						this.OnLoginIDChanged();
					}
					this.SendPropertySetterInvoked("LoginID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int
			/// </summary>
			[ColumnAttribute(Storage="_ManagerID", DbType="Int", CanBeNull=true)]
			public int? ManagerID
			{
				get
				{
					return this._ManagerID;
				}
				set
				{
					if (this._ManagerID != value)
					{
						this.OnManagerIDChanging(value);
						this.SendPropertyChanging();
						this._ManagerID = value;
						this.SendPropertyChanged("ManagerID");
						this.OnManagerIDChanged();
					}
					this.SendPropertySetterInvoked("ManagerID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(50) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_Title", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
			public string Title
			{
				get
				{
					return this._Title;
				}
				set
				{
					if (this._Title != value)
					{
						this.OnTitleChanging(value);
						this.SendPropertyChanging();
						this._Title = value;
						this.SendPropertyChanged("Title");
						this.OnTitleChanged();
					}
					this.SendPropertySetterInvoked("Title", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_BirthDate", DbType="DateTime NOT NULL", CanBeNull=false)]
			public DateTime BirthDate
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
			/// Column DbType=NChar(1) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_MaritalStatus", DbType="NChar(1) NOT NULL", CanBeNull=false)]
			public string MaritalStatus
			{
				get
				{
					return this._MaritalStatus;
				}
				set
				{
					if (this._MaritalStatus != value)
					{
						this.OnMaritalStatusChanging(value);
						this.SendPropertyChanging();
						this._MaritalStatus = value;
						this.SendPropertyChanged("MaritalStatus");
						this.OnMaritalStatusChanged();
					}
					this.SendPropertySetterInvoked("MaritalStatus", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NChar(1) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_Gender", DbType="NChar(1) NOT NULL", CanBeNull=false)]
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
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_HireDate", DbType="DateTime NOT NULL", CanBeNull=false)]
			public DateTime HireDate
			{
				get
				{
					return this._HireDate;
				}
				set
				{
					if (this._HireDate != value)
					{
						this.OnHireDateChanging(value);
						this.SendPropertyChanging();
						this._HireDate = value;
						this.SendPropertyChanged("HireDate");
						this.OnHireDateChanged();
					}
					this.SendPropertySetterInvoked("HireDate", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Bit NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_SalariedFlag", DbType="Bit NOT NULL", CanBeNull=false)]
			public bool SalariedFlag
			{
				get
				{
					return this._SalariedFlag;
				}
				set
				{
					if (this._SalariedFlag != value)
					{
						this.OnSalariedFlagChanging(value);
						this.SendPropertyChanging();
						this._SalariedFlag = value;
						this.SendPropertyChanged("SalariedFlag");
						this.OnSalariedFlagChanged();
					}
					this.SendPropertySetterInvoked("SalariedFlag", value);
				}
			}
			
			/// <summary>
			/// Column DbType=SmallInt NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_VacationHours", DbType="SmallInt NOT NULL", CanBeNull=false)]
			public System.Int16 VacationHours
			{
				get
				{
					return this._VacationHours;
				}
				set
				{
					if (this._VacationHours != value)
					{
						this.OnVacationHoursChanging(value);
						this.SendPropertyChanging();
						this._VacationHours = value;
						this.SendPropertyChanged("VacationHours");
						this.OnVacationHoursChanged();
					}
					this.SendPropertySetterInvoked("VacationHours", value);
				}
			}
			
			/// <summary>
			/// Column DbType=SmallInt NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_SickLeaveHours", DbType="SmallInt NOT NULL", CanBeNull=false)]
			public System.Int16 SickLeaveHours
			{
				get
				{
					return this._SickLeaveHours;
				}
				set
				{
					if (this._SickLeaveHours != value)
					{
						this.OnSickLeaveHoursChanging(value);
						this.SendPropertyChanging();
						this._SickLeaveHours = value;
						this.SendPropertyChanged("SickLeaveHours");
						this.OnSickLeaveHoursChanged();
					}
					this.SendPropertySetterInvoked("SickLeaveHours", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Bit NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_CurrentFlag", DbType="Bit NOT NULL", CanBeNull=false)]
			public bool CurrentFlag
			{
				get
				{
					return this._CurrentFlag;
				}
				set
				{
					if (this._CurrentFlag != value)
					{
						this.OnCurrentFlagChanging(value);
						this.SendPropertyChanging();
						this._CurrentFlag = value;
						this.SendPropertyChanged("CurrentFlag");
						this.OnCurrentFlagChanged();
					}
					this.SendPropertySetterInvoked("CurrentFlag", value);
				}
			}
			
			/// <summary>
			/// Column DbType=UniqueIdentifier NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_rowguid", DbType="UniqueIdentifier NOT NULL", CanBeNull=false)]
			public System.Guid rowguid
			{
				get
				{
					return this._rowguid;
				}
				set
				{
					if (this._rowguid != value)
					{
						this.OnrowguidChanging(value);
						this.SendPropertyChanging();
						this._rowguid = value;
						this.SendPropertyChanged("rowguid");
						this.OnrowguidChanged();
					}
					this.SendPropertySetterInvoked("rowguid", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ModifiedDate", DbType="DateTime NOT NULL", CanBeNull=false)]
			public DateTime ModifiedDate
			{
				get
				{
					return this._ModifiedDate;
				}
				set
				{
					if (this._ModifiedDate != value)
					{
						this.OnModifiedDateChanging(value);
						this.SendPropertyChanging();
						this._ModifiedDate = value;
						this.SendPropertyChanged("ModifiedDate");
						this.OnModifiedDateChanged();
					}
					this.SendPropertySetterInvoked("ModifiedDate", value);
				}
			}
			
			#endregion Columns

			#region Associations
			/// <summary>
			/// Association [FK][Many]HumanResources_Employee.ContactID --- [PK][One]Person_Contact.ContactID
			/// </summary>
			[AssociationAttribute(Name="FK_Employee_Contact_ContactID", Storage="_Person_Contact", ThisKey="ContactID", OtherKey="ContactID", IsUnique=false, IsForeignKey=true)]
			public Person_Contact Person_Contact
			{
				get
				{
					return this._Person_Contact.Entity;
				}
				set
				{
					Person_Contact previousValue = this._Person_Contact.Entity;
					if ((previousValue != value) || (this._Person_Contact.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._Person_Contact.Entity = null;
							previousValue.HumanResources_EmployeeList.Remove(this);
						}
						this._Person_Contact.Entity = value;
						if (value != null)
						{
							value.HumanResources_EmployeeList.Add(this);
							this._ContactID = value.ContactID;
						}
						else
						{
							this._ContactID = default(int);
						}
						this.SendPropertyChanged("Person_Contact");
					}
					this.SendPropertySetterInvoked("Person_Contact", value);
				}
			}
			
			/// <summary>
			/// Association [FK][Many]HumanResources_Employee.ManagerID --- [PK][One]HumanResources_Employee.EmployeeID
			/// </summary>
			[AssociationAttribute(Name="FK_Employee_Employee_ManagerID", Storage="_Manager", ThisKey="ManagerID", OtherKey="EmployeeID", IsUnique=false, IsForeignKey=true)]
			public HumanResources_Employee Manager
			{
				get
				{
					return this._Manager.Entity;
				}
				set
				{
					HumanResources_Employee previousValue = this._Manager.Entity;
					if ((previousValue != value) || (this._Manager.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._Manager.Entity = null;
							previousValue.EmployeeList.Remove(this);
						}
						this._Manager.Entity = value;
						if (value != null)
						{
							value.EmployeeList.Add(this);
							this._ManagerID = value.EmployeeID;
						}
						else
						{
							this._ManagerID = default(int?);
						}
						this.SendPropertyChanged("Manager");
					}
					this.SendPropertySetterInvoked("Manager", value);
				}
			}
			
			/// <summary>
			/// Association [PK][One]HumanResources_Employee.EmployeeID --- [FK][Many]HumanResources_Employee.ManagerID
			/// </summary>
			[AssociationAttribute(Name="FK_Employee_Employee_ManagerID", Storage="_EmployeeList", ThisKey="EmployeeID", OtherKey="ManagerID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<HumanResources_Employee> EmployeeList
			{
				get { return this._EmployeeList; }
				set { this._EmployeeList.Assign(value); }
			}
			
			/// <summary>
			/// Association [PK][One]HumanResources_Employee.EmployeeID --- [FK][Many]HumanResources_EmployeeAddress.EmployeeID
			/// </summary>
			[AssociationAttribute(Name="FK_EmployeeAddress_Employee_EmployeeID", Storage="_HumanResources_EmployeeAddressList", ThisKey="EmployeeID", OtherKey="EmployeeID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<HumanResources_EmployeeAddress> HumanResources_EmployeeAddressList
			{
				get { return this._HumanResources_EmployeeAddressList; }
				set { this._HumanResources_EmployeeAddressList.Assign(value); }
			}
			
			/// <summary>
			/// Association [PK][One]HumanResources_Employee.EmployeeID --- [FK][Many]HumanResources_EmployeeDepartmentHistory.EmployeeID
			/// </summary>
			[AssociationAttribute(Name="FK_EmployeeDepartmentHistory_Employee_EmployeeID", Storage="_HumanResources_EmployeeDepartmentHistoryList", ThisKey="EmployeeID", OtherKey="EmployeeID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<HumanResources_EmployeeDepartmentHistory> HumanResources_EmployeeDepartmentHistoryList
			{
				get { return this._HumanResources_EmployeeDepartmentHistoryList; }
				set { this._HumanResources_EmployeeDepartmentHistoryList.Assign(value); }
			}
			
			/// <summary>
			/// Association [PK][One]HumanResources_Employee.EmployeeID --- [FK][Many]HumanResources_EmployeePayHistory.EmployeeID
			/// </summary>
			[AssociationAttribute(Name="FK_EmployeePayHistory_Employee_EmployeeID", Storage="_HumanResources_EmployeePayHistoryList", ThisKey="EmployeeID", OtherKey="EmployeeID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<HumanResources_EmployeePayHistory> HumanResources_EmployeePayHistoryList
			{
				get { return this._HumanResources_EmployeePayHistoryList; }
				set { this._HumanResources_EmployeePayHistoryList.Assign(value); }
			}
			
			/// <summary>
			/// Association [PK][One]HumanResources_Employee.EmployeeID --- [FK][Many]HumanResources_JobCandidate.EmployeeID
			/// </summary>
			[AssociationAttribute(Name="FK_JobCandidate_Employee_EmployeeID", Storage="_HumanResources_JobCandidateList", ThisKey="EmployeeID", OtherKey="EmployeeID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<HumanResources_JobCandidate> HumanResources_JobCandidateList
			{
				get { return this._HumanResources_JobCandidateList; }
				set { this._HumanResources_JobCandidateList.Assign(value); }
			}
			
			/// <summary>
			/// Association [PK][One]HumanResources_Employee.EmployeeID --- [FK][Many]Purchasing_PurchaseOrderHeader.EmployeeID
			/// </summary>
			[AssociationAttribute(Name="FK_PurchaseOrderHeader_Employee_EmployeeID", Storage="_Purchasing_PurchaseOrderHeaderList", ThisKey="EmployeeID", OtherKey="EmployeeID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<Purchasing_PurchaseOrderHeader> Purchasing_PurchaseOrderHeaderList
			{
				get { return this._Purchasing_PurchaseOrderHeaderList; }
				set { this._Purchasing_PurchaseOrderHeaderList.Assign(value); }
			}
			
			/// <summary>
			/// Association [PK][One]HumanResources_Employee.EmployeeID --- [FK][One]Sales_SalesPerson.SalesPersonID
			/// </summary>
			[AssociationAttribute(Name="FK_SalesPerson_Employee_SalesPersonID", Storage="_Sales_SalesPerson", ThisKey="EmployeeID", OtherKey="SalesPersonID", IsUnique=true, IsForeignKey=false, DeleteRule="NoAction")]
			public Sales_SalesPerson Sales_SalesPerson
			{
				get
				{
					return this._Sales_SalesPerson.Entity;
				}
				set
				{
					Sales_SalesPerson previousValue = this._Sales_SalesPerson.Entity;
					if ((previousValue != value) || (this._Sales_SalesPerson.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._Sales_SalesPerson.Entity = null;
							previousValue.HumanResources_Employee = null;
						}
						this._Sales_SalesPerson.Entity = value;
						if (value != null)
						{
							value.HumanResources_Employee = this;
						}
						this.SendPropertyChanged("Sales_SalesPerson");
					}
					this.SendPropertySetterInvoked("Sales_SalesPerson", value);
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
		#endregion HumanResources.Employee

		#region HumanResources.EmployeeAddress
		[TableAttribute(Name="HumanResources.EmployeeAddress")]
		public partial class HumanResources_EmployeeAddress : EntityBase<HumanResources_EmployeeAddress, AdventureWorksDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private int _EmployeeID;
			private int _AddressID;
			private System.Guid _rowguid;
			private DateTime _ModifiedDate;
			private EntityRef<Person_Address> _Person_Address;
			private EntityRef<HumanResources_Employee> _HumanResources_Employee;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnEmployeeIDChanging(int value);
			partial void OnEmployeeIDChanged();
			partial void OnAddressIDChanging(int value);
			partial void OnAddressIDChanged();
			partial void OnrowguidChanging(System.Guid value);
			partial void OnrowguidChanged();
			partial void OnModifiedDateChanging(DateTime value);
			partial void OnModifiedDateChanged();
			#endregion

			public HumanResources_EmployeeAddress()
			{
				_Person_Address = default(EntityRef<Person_Address>);
				_HumanResources_Employee = default(EntityRef<HumanResources_Employee>);
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_EmployeeID", DbType="Int NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
			public int EmployeeID
			{
				get
				{
					return this._EmployeeID;
				}
				set
				{
					if (this._EmployeeID != value)
					{
						this.OnEmployeeIDChanging(value);
						this.SendPropertyChanging();
						this._EmployeeID = value;
						this.SendPropertyChanged("EmployeeID");
						this.OnEmployeeIDChanged();
					}
					this.SendPropertySetterInvoked("EmployeeID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_AddressID", DbType="Int NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
			public int AddressID
			{
				get
				{
					return this._AddressID;
				}
				set
				{
					if (this._AddressID != value)
					{
						this.OnAddressIDChanging(value);
						this.SendPropertyChanging();
						this._AddressID = value;
						this.SendPropertyChanged("AddressID");
						this.OnAddressIDChanged();
					}
					this.SendPropertySetterInvoked("AddressID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=UniqueIdentifier NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_rowguid", DbType="UniqueIdentifier NOT NULL", CanBeNull=false)]
			public System.Guid rowguid
			{
				get
				{
					return this._rowguid;
				}
				set
				{
					if (this._rowguid != value)
					{
						this.OnrowguidChanging(value);
						this.SendPropertyChanging();
						this._rowguid = value;
						this.SendPropertyChanged("rowguid");
						this.OnrowguidChanged();
					}
					this.SendPropertySetterInvoked("rowguid", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ModifiedDate", DbType="DateTime NOT NULL", CanBeNull=false)]
			public DateTime ModifiedDate
			{
				get
				{
					return this._ModifiedDate;
				}
				set
				{
					if (this._ModifiedDate != value)
					{
						this.OnModifiedDateChanging(value);
						this.SendPropertyChanging();
						this._ModifiedDate = value;
						this.SendPropertyChanged("ModifiedDate");
						this.OnModifiedDateChanged();
					}
					this.SendPropertySetterInvoked("ModifiedDate", value);
				}
			}
			
			#endregion Columns

			#region Associations
			/// <summary>
			/// Association [FK][Many]HumanResources_EmployeeAddress.AddressID --- [PK][One]Person_Address.AddressID
			/// </summary>
			[AssociationAttribute(Name="FK_EmployeeAddress_Address_AddressID", Storage="_Person_Address", ThisKey="AddressID", OtherKey="AddressID", IsUnique=false, IsForeignKey=true)]
			public Person_Address Person_Address
			{
				get
				{
					return this._Person_Address.Entity;
				}
				set
				{
					Person_Address previousValue = this._Person_Address.Entity;
					if ((previousValue != value) || (this._Person_Address.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._Person_Address.Entity = null;
							previousValue.HumanResources_EmployeeAddressList.Remove(this);
						}
						this._Person_Address.Entity = value;
						if (value != null)
						{
							value.HumanResources_EmployeeAddressList.Add(this);
							this._AddressID = value.AddressID;
						}
						else
						{
							this._AddressID = default(int);
						}
						this.SendPropertyChanged("Person_Address");
					}
					this.SendPropertySetterInvoked("Person_Address", value);
				}
			}
			
			/// <summary>
			/// Association [FK][Many]HumanResources_EmployeeAddress.EmployeeID --- [PK][One]HumanResources_Employee.EmployeeID
			/// </summary>
			[AssociationAttribute(Name="FK_EmployeeAddress_Employee_EmployeeID", Storage="_HumanResources_Employee", ThisKey="EmployeeID", OtherKey="EmployeeID", IsUnique=false, IsForeignKey=true)]
			public HumanResources_Employee HumanResources_Employee
			{
				get
				{
					return this._HumanResources_Employee.Entity;
				}
				set
				{
					HumanResources_Employee previousValue = this._HumanResources_Employee.Entity;
					if ((previousValue != value) || (this._HumanResources_Employee.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._HumanResources_Employee.Entity = null;
							previousValue.HumanResources_EmployeeAddressList.Remove(this);
						}
						this._HumanResources_Employee.Entity = value;
						if (value != null)
						{
							value.HumanResources_EmployeeAddressList.Add(this);
							this._EmployeeID = value.EmployeeID;
						}
						else
						{
							this._EmployeeID = default(int);
						}
						this.SendPropertyChanged("HumanResources_Employee");
					}
					this.SendPropertySetterInvoked("HumanResources_Employee", value);
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
		#endregion HumanResources.EmployeeAddress

		#region HumanResources.EmployeeDepartmentHistory
		[TableAttribute(Name="HumanResources.EmployeeDepartmentHistory")]
		public partial class HumanResources_EmployeeDepartmentHistory : EntityBase<HumanResources_EmployeeDepartmentHistory, AdventureWorksDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private int _EmployeeID;
			private System.Int16 _DepartmentID;
			private byte _ShiftID;
			private DateTime _StartDate;
			private DateTime? _EndDate;
			private DateTime _ModifiedDate;
			private EntityRef<HumanResources_Department> _HumanResources_Department;
			private EntityRef<HumanResources_Employee> _HumanResources_Employee;
			private EntityRef<HumanResources_Shift> _HumanResources_Shift;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnEmployeeIDChanging(int value);
			partial void OnEmployeeIDChanged();
			partial void OnDepartmentIDChanging(System.Int16 value);
			partial void OnDepartmentIDChanged();
			partial void OnShiftIDChanging(byte value);
			partial void OnShiftIDChanged();
			partial void OnStartDateChanging(DateTime value);
			partial void OnStartDateChanged();
			partial void OnEndDateChanging(DateTime? value);
			partial void OnEndDateChanged();
			partial void OnModifiedDateChanging(DateTime value);
			partial void OnModifiedDateChanged();
			#endregion

			public HumanResources_EmployeeDepartmentHistory()
			{
				_HumanResources_Department = default(EntityRef<HumanResources_Department>);
				_HumanResources_Employee = default(EntityRef<HumanResources_Employee>);
				_HumanResources_Shift = default(EntityRef<HumanResources_Shift>);
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_EmployeeID", DbType="Int NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
			public int EmployeeID
			{
				get
				{
					return this._EmployeeID;
				}
				set
				{
					if (this._EmployeeID != value)
					{
						this.OnEmployeeIDChanging(value);
						this.SendPropertyChanging();
						this._EmployeeID = value;
						this.SendPropertyChanged("EmployeeID");
						this.OnEmployeeIDChanged();
					}
					this.SendPropertySetterInvoked("EmployeeID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=SmallInt NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_DepartmentID", DbType="SmallInt NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
			public System.Int16 DepartmentID
			{
				get
				{
					return this._DepartmentID;
				}
				set
				{
					if (this._DepartmentID != value)
					{
						this.OnDepartmentIDChanging(value);
						this.SendPropertyChanging();
						this._DepartmentID = value;
						this.SendPropertyChanged("DepartmentID");
						this.OnDepartmentIDChanged();
					}
					this.SendPropertySetterInvoked("DepartmentID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=TinyInt NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ShiftID", DbType="TinyInt NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
			public byte ShiftID
			{
				get
				{
					return this._ShiftID;
				}
				set
				{
					if (this._ShiftID != value)
					{
						this.OnShiftIDChanging(value);
						this.SendPropertyChanging();
						this._ShiftID = value;
						this.SendPropertyChanged("ShiftID");
						this.OnShiftIDChanged();
					}
					this.SendPropertySetterInvoked("ShiftID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_StartDate", DbType="DateTime NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
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
						this.OnStartDateChanging(value);
						this.SendPropertyChanging();
						this._StartDate = value;
						this.SendPropertyChanged("StartDate");
						this.OnStartDateChanged();
					}
					this.SendPropertySetterInvoked("StartDate", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime
			/// </summary>
			[ColumnAttribute(Storage="_EndDate", DbType="DateTime", CanBeNull=true)]
			public DateTime? EndDate
			{
				get
				{
					return this._EndDate;
				}
				set
				{
					if (this._EndDate != value)
					{
						this.OnEndDateChanging(value);
						this.SendPropertyChanging();
						this._EndDate = value;
						this.SendPropertyChanged("EndDate");
						this.OnEndDateChanged();
					}
					this.SendPropertySetterInvoked("EndDate", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ModifiedDate", DbType="DateTime NOT NULL", CanBeNull=false)]
			public DateTime ModifiedDate
			{
				get
				{
					return this._ModifiedDate;
				}
				set
				{
					if (this._ModifiedDate != value)
					{
						this.OnModifiedDateChanging(value);
						this.SendPropertyChanging();
						this._ModifiedDate = value;
						this.SendPropertyChanged("ModifiedDate");
						this.OnModifiedDateChanged();
					}
					this.SendPropertySetterInvoked("ModifiedDate", value);
				}
			}
			
			#endregion Columns

			#region Associations
			/// <summary>
			/// Association [FK][Many]HumanResources_EmployeeDepartmentHistory.DepartmentID --- [PK][One]HumanResources_Department.DepartmentID
			/// </summary>
			[AssociationAttribute(Name="FK_EmployeeDepartmentHistory_Department_DepartmentID", Storage="_HumanResources_Department", ThisKey="DepartmentID", OtherKey="DepartmentID", IsUnique=false, IsForeignKey=true)]
			public HumanResources_Department HumanResources_Department
			{
				get
				{
					return this._HumanResources_Department.Entity;
				}
				set
				{
					HumanResources_Department previousValue = this._HumanResources_Department.Entity;
					if ((previousValue != value) || (this._HumanResources_Department.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._HumanResources_Department.Entity = null;
							previousValue.HumanResources_EmployeeDepartmentHistoryList.Remove(this);
						}
						this._HumanResources_Department.Entity = value;
						if (value != null)
						{
							value.HumanResources_EmployeeDepartmentHistoryList.Add(this);
							this._DepartmentID = value.DepartmentID;
						}
						else
						{
							this._DepartmentID = default(System.Int16);
						}
						this.SendPropertyChanged("HumanResources_Department");
					}
					this.SendPropertySetterInvoked("HumanResources_Department", value);
				}
			}
			
			/// <summary>
			/// Association [FK][Many]HumanResources_EmployeeDepartmentHistory.EmployeeID --- [PK][One]HumanResources_Employee.EmployeeID
			/// </summary>
			[AssociationAttribute(Name="FK_EmployeeDepartmentHistory_Employee_EmployeeID", Storage="_HumanResources_Employee", ThisKey="EmployeeID", OtherKey="EmployeeID", IsUnique=false, IsForeignKey=true)]
			public HumanResources_Employee HumanResources_Employee
			{
				get
				{
					return this._HumanResources_Employee.Entity;
				}
				set
				{
					HumanResources_Employee previousValue = this._HumanResources_Employee.Entity;
					if ((previousValue != value) || (this._HumanResources_Employee.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._HumanResources_Employee.Entity = null;
							previousValue.HumanResources_EmployeeDepartmentHistoryList.Remove(this);
						}
						this._HumanResources_Employee.Entity = value;
						if (value != null)
						{
							value.HumanResources_EmployeeDepartmentHistoryList.Add(this);
							this._EmployeeID = value.EmployeeID;
						}
						else
						{
							this._EmployeeID = default(int);
						}
						this.SendPropertyChanged("HumanResources_Employee");
					}
					this.SendPropertySetterInvoked("HumanResources_Employee", value);
				}
			}
			
			/// <summary>
			/// Association [FK][Many]HumanResources_EmployeeDepartmentHistory.ShiftID --- [PK][One]HumanResources_Shift.ShiftID
			/// </summary>
			[AssociationAttribute(Name="FK_EmployeeDepartmentHistory_Shift_ShiftID", Storage="_HumanResources_Shift", ThisKey="ShiftID", OtherKey="ShiftID", IsUnique=false, IsForeignKey=true)]
			public HumanResources_Shift HumanResources_Shift
			{
				get
				{
					return this._HumanResources_Shift.Entity;
				}
				set
				{
					HumanResources_Shift previousValue = this._HumanResources_Shift.Entity;
					if ((previousValue != value) || (this._HumanResources_Shift.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._HumanResources_Shift.Entity = null;
							previousValue.HumanResources_EmployeeDepartmentHistoryList.Remove(this);
						}
						this._HumanResources_Shift.Entity = value;
						if (value != null)
						{
							value.HumanResources_EmployeeDepartmentHistoryList.Add(this);
							this._ShiftID = value.ShiftID;
						}
						else
						{
							this._ShiftID = default(byte);
						}
						this.SendPropertyChanged("HumanResources_Shift");
					}
					this.SendPropertySetterInvoked("HumanResources_Shift", value);
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
		#endregion HumanResources.EmployeeDepartmentHistory

		#region HumanResources.EmployeePayHistory
		[TableAttribute(Name="HumanResources.EmployeePayHistory")]
		public partial class HumanResources_EmployeePayHistory : EntityBase<HumanResources_EmployeePayHistory, AdventureWorksDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private int _EmployeeID;
			private DateTime _RateChangeDate;
			private decimal _Rate;
			private byte _PayFrequency;
			private DateTime _ModifiedDate;
			private EntityRef<HumanResources_Employee> _HumanResources_Employee;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnEmployeeIDChanging(int value);
			partial void OnEmployeeIDChanged();
			partial void OnRateChangeDateChanging(DateTime value);
			partial void OnRateChangeDateChanged();
			partial void OnRateChanging(decimal value);
			partial void OnRateChanged();
			partial void OnPayFrequencyChanging(byte value);
			partial void OnPayFrequencyChanged();
			partial void OnModifiedDateChanging(DateTime value);
			partial void OnModifiedDateChanged();
			#endregion

			public HumanResources_EmployeePayHistory()
			{
				_HumanResources_Employee = default(EntityRef<HumanResources_Employee>);
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_EmployeeID", DbType="Int NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
			public int EmployeeID
			{
				get
				{
					return this._EmployeeID;
				}
				set
				{
					if (this._EmployeeID != value)
					{
						this.OnEmployeeIDChanging(value);
						this.SendPropertyChanging();
						this._EmployeeID = value;
						this.SendPropertyChanged("EmployeeID");
						this.OnEmployeeIDChanged();
					}
					this.SendPropertySetterInvoked("EmployeeID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_RateChangeDate", DbType="DateTime NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
			public DateTime RateChangeDate
			{
				get
				{
					return this._RateChangeDate;
				}
				set
				{
					if (this._RateChangeDate != value)
					{
						this.OnRateChangeDateChanging(value);
						this.SendPropertyChanging();
						this._RateChangeDate = value;
						this.SendPropertyChanged("RateChangeDate");
						this.OnRateChangeDateChanged();
					}
					this.SendPropertySetterInvoked("RateChangeDate", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Money NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_Rate", DbType="Money NOT NULL", CanBeNull=false)]
			public decimal Rate
			{
				get
				{
					return this._Rate;
				}
				set
				{
					if (this._Rate != value)
					{
						this.OnRateChanging(value);
						this.SendPropertyChanging();
						this._Rate = value;
						this.SendPropertyChanged("Rate");
						this.OnRateChanged();
					}
					this.SendPropertySetterInvoked("Rate", value);
				}
			}
			
			/// <summary>
			/// Column DbType=TinyInt NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_PayFrequency", DbType="TinyInt NOT NULL", CanBeNull=false)]
			public byte PayFrequency
			{
				get
				{
					return this._PayFrequency;
				}
				set
				{
					if (this._PayFrequency != value)
					{
						this.OnPayFrequencyChanging(value);
						this.SendPropertyChanging();
						this._PayFrequency = value;
						this.SendPropertyChanged("PayFrequency");
						this.OnPayFrequencyChanged();
					}
					this.SendPropertySetterInvoked("PayFrequency", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ModifiedDate", DbType="DateTime NOT NULL", CanBeNull=false)]
			public DateTime ModifiedDate
			{
				get
				{
					return this._ModifiedDate;
				}
				set
				{
					if (this._ModifiedDate != value)
					{
						this.OnModifiedDateChanging(value);
						this.SendPropertyChanging();
						this._ModifiedDate = value;
						this.SendPropertyChanged("ModifiedDate");
						this.OnModifiedDateChanged();
					}
					this.SendPropertySetterInvoked("ModifiedDate", value);
				}
			}
			
			#endregion Columns

			#region Associations
			/// <summary>
			/// Association [FK][Many]HumanResources_EmployeePayHistory.EmployeeID --- [PK][One]HumanResources_Employee.EmployeeID
			/// </summary>
			[AssociationAttribute(Name="FK_EmployeePayHistory_Employee_EmployeeID", Storage="_HumanResources_Employee", ThisKey="EmployeeID", OtherKey="EmployeeID", IsUnique=false, IsForeignKey=true)]
			public HumanResources_Employee HumanResources_Employee
			{
				get
				{
					return this._HumanResources_Employee.Entity;
				}
				set
				{
					HumanResources_Employee previousValue = this._HumanResources_Employee.Entity;
					if ((previousValue != value) || (this._HumanResources_Employee.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._HumanResources_Employee.Entity = null;
							previousValue.HumanResources_EmployeePayHistoryList.Remove(this);
						}
						this._HumanResources_Employee.Entity = value;
						if (value != null)
						{
							value.HumanResources_EmployeePayHistoryList.Add(this);
							this._EmployeeID = value.EmployeeID;
						}
						else
						{
							this._EmployeeID = default(int);
						}
						this.SendPropertyChanged("HumanResources_Employee");
					}
					this.SendPropertySetterInvoked("HumanResources_Employee", value);
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
		#endregion HumanResources.EmployeePayHistory

		#region dbo.ErrorLog
		[TableAttribute(Name="dbo.ErrorLog")]
		public partial class ErrorLog : EntityBase<ErrorLog, AdventureWorksDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private int _ErrorLogID;
			private DateTime _ErrorTime;
			private string _UserName;
			private int _ErrorNumber;
			private int? _ErrorSeverity;
			private int? _ErrorState;
			private string _ErrorProcedure;
			private int? _ErrorLine;
			private string _ErrorMessage;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnErrorLogIDChanging(int value);
			partial void OnErrorLogIDChanged();
			partial void OnErrorTimeChanging(DateTime value);
			partial void OnErrorTimeChanged();
			partial void OnUserNameChanging(string value);
			partial void OnUserNameChanged();
			partial void OnErrorNumberChanging(int value);
			partial void OnErrorNumberChanged();
			partial void OnErrorSeverityChanging(int? value);
			partial void OnErrorSeverityChanged();
			partial void OnErrorStateChanging(int? value);
			partial void OnErrorStateChanged();
			partial void OnErrorProcedureChanging(string value);
			partial void OnErrorProcedureChanged();
			partial void OnErrorLineChanging(int? value);
			partial void OnErrorLineChanged();
			partial void OnErrorMessageChanging(string value);
			partial void OnErrorMessageChanged();
			#endregion

			public ErrorLog()
			{
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=Int NOT NULL IDENTITY
			/// </summary>
			[ColumnAttribute(Storage="_ErrorLogID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", CanBeNull=false, IsPrimaryKey=true, IsDbGenerated=true)]
			public int ErrorLogID
			{
				get
				{
					return this._ErrorLogID;
				}
				set
				{
					if (this._ErrorLogID != value)
					{
						this.OnErrorLogIDChanging(value);
						this.SendPropertyChanging();
						this._ErrorLogID = value;
						this.SendPropertyChanged("ErrorLogID");
						this.OnErrorLogIDChanged();
					}
					this.SendPropertySetterInvoked("ErrorLogID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ErrorTime", DbType="DateTime NOT NULL", CanBeNull=false)]
			public DateTime ErrorTime
			{
				get
				{
					return this._ErrorTime;
				}
				set
				{
					if (this._ErrorTime != value)
					{
						this.OnErrorTimeChanging(value);
						this.SendPropertyChanging();
						this._ErrorTime = value;
						this.SendPropertyChanged("ErrorTime");
						this.OnErrorTimeChanged();
					}
					this.SendPropertySetterInvoked("ErrorTime", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(128) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_UserName", DbType="NVarChar(128) NOT NULL", CanBeNull=false)]
			public string UserName
			{
				get
				{
					return this._UserName;
				}
				set
				{
					if (this._UserName != value)
					{
						this.OnUserNameChanging(value);
						this.SendPropertyChanging();
						this._UserName = value;
						this.SendPropertyChanged("UserName");
						this.OnUserNameChanged();
					}
					this.SendPropertySetterInvoked("UserName", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ErrorNumber", DbType="Int NOT NULL", CanBeNull=false)]
			public int ErrorNumber
			{
				get
				{
					return this._ErrorNumber;
				}
				set
				{
					if (this._ErrorNumber != value)
					{
						this.OnErrorNumberChanging(value);
						this.SendPropertyChanging();
						this._ErrorNumber = value;
						this.SendPropertyChanged("ErrorNumber");
						this.OnErrorNumberChanged();
					}
					this.SendPropertySetterInvoked("ErrorNumber", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int
			/// </summary>
			[ColumnAttribute(Storage="_ErrorSeverity", DbType="Int", CanBeNull=true)]
			public int? ErrorSeverity
			{
				get
				{
					return this._ErrorSeverity;
				}
				set
				{
					if (this._ErrorSeverity != value)
					{
						this.OnErrorSeverityChanging(value);
						this.SendPropertyChanging();
						this._ErrorSeverity = value;
						this.SendPropertyChanged("ErrorSeverity");
						this.OnErrorSeverityChanged();
					}
					this.SendPropertySetterInvoked("ErrorSeverity", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int
			/// </summary>
			[ColumnAttribute(Storage="_ErrorState", DbType="Int", CanBeNull=true)]
			public int? ErrorState
			{
				get
				{
					return this._ErrorState;
				}
				set
				{
					if (this._ErrorState != value)
					{
						this.OnErrorStateChanging(value);
						this.SendPropertyChanging();
						this._ErrorState = value;
						this.SendPropertyChanged("ErrorState");
						this.OnErrorStateChanged();
					}
					this.SendPropertySetterInvoked("ErrorState", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(126)
			/// </summary>
			[ColumnAttribute(Storage="_ErrorProcedure", DbType="NVarChar(126)", CanBeNull=true)]
			public string ErrorProcedure
			{
				get
				{
					return this._ErrorProcedure;
				}
				set
				{
					if (this._ErrorProcedure != value)
					{
						this.OnErrorProcedureChanging(value);
						this.SendPropertyChanging();
						this._ErrorProcedure = value;
						this.SendPropertyChanged("ErrorProcedure");
						this.OnErrorProcedureChanged();
					}
					this.SendPropertySetterInvoked("ErrorProcedure", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int
			/// </summary>
			[ColumnAttribute(Storage="_ErrorLine", DbType="Int", CanBeNull=true)]
			public int? ErrorLine
			{
				get
				{
					return this._ErrorLine;
				}
				set
				{
					if (this._ErrorLine != value)
					{
						this.OnErrorLineChanging(value);
						this.SendPropertyChanging();
						this._ErrorLine = value;
						this.SendPropertyChanged("ErrorLine");
						this.OnErrorLineChanged();
					}
					this.SendPropertySetterInvoked("ErrorLine", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(4000) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ErrorMessage", DbType="NVarChar(4000) NOT NULL", CanBeNull=false)]
			public string ErrorMessage
			{
				get
				{
					return this._ErrorMessage;
				}
				set
				{
					if (this._ErrorMessage != value)
					{
						this.OnErrorMessageChanging(value);
						this.SendPropertyChanging();
						this._ErrorMessage = value;
						this.SendPropertyChanged("ErrorMessage");
						this.OnErrorMessageChanged();
					}
					this.SendPropertySetterInvoked("ErrorMessage", value);
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
		#endregion dbo.ErrorLog

		#region Production.Illustration
		[TableAttribute(Name="Production.Illustration")]
		public partial class Production_Illustration : EntityBase<Production_Illustration, AdventureWorksDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private int _IllustrationID;
			private System.Xml.Linq.XElement _Diagram;
			private DateTime _ModifiedDate;
			private EntitySet<Production_ProductModelIllustration> _Production_ProductModelIllustrationList;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnIllustrationIDChanging(int value);
			partial void OnIllustrationIDChanged();
			partial void OnDiagramChanging(System.Xml.Linq.XElement value);
			partial void OnDiagramChanged();
			partial void OnModifiedDateChanging(DateTime value);
			partial void OnModifiedDateChanged();
			#endregion

			public Production_Illustration()
			{
				_Production_ProductModelIllustrationList = new EntitySet<Production_ProductModelIllustration>(
					new Action<Production_ProductModelIllustration>(item=>{this.SendPropertyChanging(); item.Production_Illustration=this;}), 
					new Action<Production_ProductModelIllustration>(item=>{this.SendPropertyChanging(); item.Production_Illustration=null;}));
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=Int NOT NULL IDENTITY
			/// </summary>
			[ColumnAttribute(Storage="_IllustrationID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", CanBeNull=false, IsPrimaryKey=true, IsDbGenerated=true)]
			public int IllustrationID
			{
				get
				{
					return this._IllustrationID;
				}
				set
				{
					if (this._IllustrationID != value)
					{
						this.OnIllustrationIDChanging(value);
						this.SendPropertyChanging();
						this._IllustrationID = value;
						this.SendPropertyChanged("IllustrationID");
						this.OnIllustrationIDChanged();
					}
					this.SendPropertySetterInvoked("IllustrationID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Xml
			/// </summary>
			[ColumnAttribute(Storage="_Diagram", DbType="Xml", CanBeNull=true)]
			public System.Xml.Linq.XElement Diagram
			{
				get
				{
					return this._Diagram;
				}
				set
				{
					if (this._Diagram != value)
					{
						this.OnDiagramChanging(value);
						this.SendPropertyChanging();
						this._Diagram = value;
						this.SendPropertyChanged("Diagram");
						this.OnDiagramChanged();
					}
					this.SendPropertySetterInvoked("Diagram", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ModifiedDate", DbType="DateTime NOT NULL", CanBeNull=false)]
			public DateTime ModifiedDate
			{
				get
				{
					return this._ModifiedDate;
				}
				set
				{
					if (this._ModifiedDate != value)
					{
						this.OnModifiedDateChanging(value);
						this.SendPropertyChanging();
						this._ModifiedDate = value;
						this.SendPropertyChanged("ModifiedDate");
						this.OnModifiedDateChanged();
					}
					this.SendPropertySetterInvoked("ModifiedDate", value);
				}
			}
			
			#endregion Columns

			#region Associations
			/// <summary>
			/// Association [PK][One]Production_Illustration.IllustrationID --- [FK][Many]Production_ProductModelIllustration.IllustrationID
			/// </summary>
			[AssociationAttribute(Name="FK_ProductModelIllustration_Illustration_IllustrationID", Storage="_Production_ProductModelIllustrationList", ThisKey="IllustrationID", OtherKey="IllustrationID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<Production_ProductModelIllustration> Production_ProductModelIllustrationList
			{
				get { return this._Production_ProductModelIllustrationList; }
				set { this._Production_ProductModelIllustrationList.Assign(value); }
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
		#endregion Production.Illustration

		#region Sales.Individual
		[TableAttribute(Name="Sales.Individual")]
		public partial class Sales_Individual : EntityBase<Sales_Individual, AdventureWorksDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private int _CustomerID;
			private int _ContactID;
			private System.Xml.Linq.XElement _Demographics;
			private DateTime _ModifiedDate;
			private EntityRef<Person_Contact> _Person_Contact;
			private EntityRef<Sales_Customer> _Sales_Customer;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnCustomerIDChanging(int value);
			partial void OnCustomerIDChanged();
			partial void OnContactIDChanging(int value);
			partial void OnContactIDChanged();
			partial void OnDemographicsChanging(System.Xml.Linq.XElement value);
			partial void OnDemographicsChanged();
			partial void OnModifiedDateChanging(DateTime value);
			partial void OnModifiedDateChanged();
			#endregion

			public Sales_Individual()
			{
				_Person_Contact = default(EntityRef<Person_Contact>);
				_Sales_Customer = default(EntityRef<Sales_Customer>);
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_CustomerID", DbType="Int NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
			public int CustomerID
			{
				get
				{
					return this._CustomerID;
				}
				set
				{
					if (this._CustomerID != value)
					{
						this.OnCustomerIDChanging(value);
						this.SendPropertyChanging();
						this._CustomerID = value;
						this.SendPropertyChanged("CustomerID");
						this.OnCustomerIDChanged();
					}
					this.SendPropertySetterInvoked("CustomerID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ContactID", DbType="Int NOT NULL", CanBeNull=false)]
			public int ContactID
			{
				get
				{
					return this._ContactID;
				}
				set
				{
					if (this._ContactID != value)
					{
						this.OnContactIDChanging(value);
						this.SendPropertyChanging();
						this._ContactID = value;
						this.SendPropertyChanged("ContactID");
						this.OnContactIDChanged();
					}
					this.SendPropertySetterInvoked("ContactID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Xml
			/// </summary>
			[ColumnAttribute(Storage="_Demographics", DbType="Xml", CanBeNull=true)]
			public System.Xml.Linq.XElement Demographics
			{
				get
				{
					return this._Demographics;
				}
				set
				{
					if (this._Demographics != value)
					{
						this.OnDemographicsChanging(value);
						this.SendPropertyChanging();
						this._Demographics = value;
						this.SendPropertyChanged("Demographics");
						this.OnDemographicsChanged();
					}
					this.SendPropertySetterInvoked("Demographics", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ModifiedDate", DbType="DateTime NOT NULL", CanBeNull=false)]
			public DateTime ModifiedDate
			{
				get
				{
					return this._ModifiedDate;
				}
				set
				{
					if (this._ModifiedDate != value)
					{
						this.OnModifiedDateChanging(value);
						this.SendPropertyChanging();
						this._ModifiedDate = value;
						this.SendPropertyChanged("ModifiedDate");
						this.OnModifiedDateChanged();
					}
					this.SendPropertySetterInvoked("ModifiedDate", value);
				}
			}
			
			#endregion Columns

			#region Associations
			/// <summary>
			/// Association [FK][Many]Sales_Individual.ContactID --- [PK][One]Person_Contact.ContactID
			/// </summary>
			[AssociationAttribute(Name="FK_Individual_Contact_ContactID", Storage="_Person_Contact", ThisKey="ContactID", OtherKey="ContactID", IsUnique=false, IsForeignKey=true)]
			public Person_Contact Person_Contact
			{
				get
				{
					return this._Person_Contact.Entity;
				}
				set
				{
					Person_Contact previousValue = this._Person_Contact.Entity;
					if ((previousValue != value) || (this._Person_Contact.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._Person_Contact.Entity = null;
							previousValue.Sales_IndividualList.Remove(this);
						}
						this._Person_Contact.Entity = value;
						if (value != null)
						{
							value.Sales_IndividualList.Add(this);
							this._ContactID = value.ContactID;
						}
						else
						{
							this._ContactID = default(int);
						}
						this.SendPropertyChanged("Person_Contact");
					}
					this.SendPropertySetterInvoked("Person_Contact", value);
				}
			}
			
			/// <summary>
			/// Association [FK][One]Sales_Individual.CustomerID --- [PK][One]Sales_Customer.CustomerID
			/// </summary>
			[AssociationAttribute(Name="FK_Individual_Customer_CustomerID", Storage="_Sales_Customer", ThisKey="CustomerID", OtherKey="CustomerID", IsUnique=true, IsForeignKey=true)]
			public Sales_Customer Sales_Customer
			{
				get
				{
					return this._Sales_Customer.Entity;
				}
				set
				{
					Sales_Customer previousValue = this._Sales_Customer.Entity;
					if ((previousValue != value) || (this._Sales_Customer.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._Sales_Customer.Entity = null;
							previousValue.Sales_Individual = null;
						}
						this._Sales_Customer.Entity = value;
						if (value != null)
						{
							value.Sales_Individual = this;
							this._CustomerID = value.CustomerID;
						}
						else
						{
							this._CustomerID = default(int);
						}
						this.SendPropertyChanged("Sales_Customer");
					}
					this.SendPropertySetterInvoked("Sales_Customer", value);
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
		#endregion Sales.Individual

		#region HumanResources.JobCandidate
		[TableAttribute(Name="HumanResources.JobCandidate")]
		public partial class HumanResources_JobCandidate : EntityBase<HumanResources_JobCandidate, AdventureWorksDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private int _JobCandidateID;
			private int? _EmployeeID;
			private System.Xml.Linq.XElement _Resume;
			private DateTime _ModifiedDate;
			private EntityRef<HumanResources_Employee> _HumanResources_Employee;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnJobCandidateIDChanging(int value);
			partial void OnJobCandidateIDChanged();
			partial void OnEmployeeIDChanging(int? value);
			partial void OnEmployeeIDChanged();
			partial void OnResumeChanging(System.Xml.Linq.XElement value);
			partial void OnResumeChanged();
			partial void OnModifiedDateChanging(DateTime value);
			partial void OnModifiedDateChanged();
			#endregion

			public HumanResources_JobCandidate()
			{
				_HumanResources_Employee = default(EntityRef<HumanResources_Employee>);
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=Int NOT NULL IDENTITY
			/// </summary>
			[ColumnAttribute(Storage="_JobCandidateID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", CanBeNull=false, IsPrimaryKey=true, IsDbGenerated=true)]
			public int JobCandidateID
			{
				get
				{
					return this._JobCandidateID;
				}
				set
				{
					if (this._JobCandidateID != value)
					{
						this.OnJobCandidateIDChanging(value);
						this.SendPropertyChanging();
						this._JobCandidateID = value;
						this.SendPropertyChanged("JobCandidateID");
						this.OnJobCandidateIDChanged();
					}
					this.SendPropertySetterInvoked("JobCandidateID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int
			/// </summary>
			[ColumnAttribute(Storage="_EmployeeID", DbType="Int", CanBeNull=true)]
			public int? EmployeeID
			{
				get
				{
					return this._EmployeeID;
				}
				set
				{
					if (this._EmployeeID != value)
					{
						this.OnEmployeeIDChanging(value);
						this.SendPropertyChanging();
						this._EmployeeID = value;
						this.SendPropertyChanged("EmployeeID");
						this.OnEmployeeIDChanged();
					}
					this.SendPropertySetterInvoked("EmployeeID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Xml
			/// </summary>
			[ColumnAttribute(Storage="_Resume", DbType="Xml", CanBeNull=true)]
			public System.Xml.Linq.XElement Resume
			{
				get
				{
					return this._Resume;
				}
				set
				{
					if (this._Resume != value)
					{
						this.OnResumeChanging(value);
						this.SendPropertyChanging();
						this._Resume = value;
						this.SendPropertyChanged("Resume");
						this.OnResumeChanged();
					}
					this.SendPropertySetterInvoked("Resume", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ModifiedDate", DbType="DateTime NOT NULL", CanBeNull=false)]
			public DateTime ModifiedDate
			{
				get
				{
					return this._ModifiedDate;
				}
				set
				{
					if (this._ModifiedDate != value)
					{
						this.OnModifiedDateChanging(value);
						this.SendPropertyChanging();
						this._ModifiedDate = value;
						this.SendPropertyChanged("ModifiedDate");
						this.OnModifiedDateChanged();
					}
					this.SendPropertySetterInvoked("ModifiedDate", value);
				}
			}
			
			#endregion Columns

			#region Associations
			/// <summary>
			/// Association [FK][Many]HumanResources_JobCandidate.EmployeeID --- [PK][One]HumanResources_Employee.EmployeeID
			/// </summary>
			[AssociationAttribute(Name="FK_JobCandidate_Employee_EmployeeID", Storage="_HumanResources_Employee", ThisKey="EmployeeID", OtherKey="EmployeeID", IsUnique=false, IsForeignKey=true)]
			public HumanResources_Employee HumanResources_Employee
			{
				get
				{
					return this._HumanResources_Employee.Entity;
				}
				set
				{
					HumanResources_Employee previousValue = this._HumanResources_Employee.Entity;
					if ((previousValue != value) || (this._HumanResources_Employee.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._HumanResources_Employee.Entity = null;
							previousValue.HumanResources_JobCandidateList.Remove(this);
						}
						this._HumanResources_Employee.Entity = value;
						if (value != null)
						{
							value.HumanResources_JobCandidateList.Add(this);
							this._EmployeeID = value.EmployeeID;
						}
						else
						{
							this._EmployeeID = default(int?);
						}
						this.SendPropertyChanged("HumanResources_Employee");
					}
					this.SendPropertySetterInvoked("HumanResources_Employee", value);
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
		#endregion HumanResources.JobCandidate

		#region Production.Location
		[TableAttribute(Name="Production.Location")]
		public partial class Production_Location : EntityBase<Production_Location, AdventureWorksDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private System.Int16 _LocationID;
			private string _Name;
			private decimal _CostRate;
			private decimal _Availability;
			private DateTime _ModifiedDate;
			private EntitySet<Production_ProductInventory> _Production_ProductInventoryList;
			private EntitySet<Production_WorkOrderRouting> _Production_WorkOrderRoutingList;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnLocationIDChanging(System.Int16 value);
			partial void OnLocationIDChanged();
			partial void OnNameChanging(string value);
			partial void OnNameChanged();
			partial void OnCostRateChanging(decimal value);
			partial void OnCostRateChanged();
			partial void OnAvailabilityChanging(decimal value);
			partial void OnAvailabilityChanged();
			partial void OnModifiedDateChanging(DateTime value);
			partial void OnModifiedDateChanged();
			#endregion

			public Production_Location()
			{
				_Production_ProductInventoryList = new EntitySet<Production_ProductInventory>(
					new Action<Production_ProductInventory>(item=>{this.SendPropertyChanging(); item.Production_Location=this;}), 
					new Action<Production_ProductInventory>(item=>{this.SendPropertyChanging(); item.Production_Location=null;}));
				_Production_WorkOrderRoutingList = new EntitySet<Production_WorkOrderRouting>(
					new Action<Production_WorkOrderRouting>(item=>{this.SendPropertyChanging(); item.Production_Location=this;}), 
					new Action<Production_WorkOrderRouting>(item=>{this.SendPropertyChanging(); item.Production_Location=null;}));
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=SmallInt NOT NULL IDENTITY
			/// </summary>
			[ColumnAttribute(Storage="_LocationID", AutoSync=AutoSync.OnInsert, DbType="SmallInt NOT NULL IDENTITY", CanBeNull=false, IsPrimaryKey=true, IsDbGenerated=true)]
			public System.Int16 LocationID
			{
				get
				{
					return this._LocationID;
				}
				set
				{
					if (this._LocationID != value)
					{
						this.OnLocationIDChanging(value);
						this.SendPropertyChanging();
						this._LocationID = value;
						this.SendPropertyChanged("LocationID");
						this.OnLocationIDChanged();
					}
					this.SendPropertySetterInvoked("LocationID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(50) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_Name", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
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
			/// Column DbType=SmallMoney NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_CostRate", DbType="SmallMoney NOT NULL", CanBeNull=false)]
			public decimal CostRate
			{
				get
				{
					return this._CostRate;
				}
				set
				{
					if (this._CostRate != value)
					{
						this.OnCostRateChanging(value);
						this.SendPropertyChanging();
						this._CostRate = value;
						this.SendPropertyChanged("CostRate");
						this.OnCostRateChanged();
					}
					this.SendPropertySetterInvoked("CostRate", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Decimal(8,2) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_Availability", DbType="Decimal(8,2) NOT NULL", CanBeNull=false)]
			public decimal Availability
			{
				get
				{
					return this._Availability;
				}
				set
				{
					if (this._Availability != value)
					{
						this.OnAvailabilityChanging(value);
						this.SendPropertyChanging();
						this._Availability = value;
						this.SendPropertyChanged("Availability");
						this.OnAvailabilityChanged();
					}
					this.SendPropertySetterInvoked("Availability", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ModifiedDate", DbType="DateTime NOT NULL", CanBeNull=false)]
			public DateTime ModifiedDate
			{
				get
				{
					return this._ModifiedDate;
				}
				set
				{
					if (this._ModifiedDate != value)
					{
						this.OnModifiedDateChanging(value);
						this.SendPropertyChanging();
						this._ModifiedDate = value;
						this.SendPropertyChanged("ModifiedDate");
						this.OnModifiedDateChanged();
					}
					this.SendPropertySetterInvoked("ModifiedDate", value);
				}
			}
			
			#endregion Columns

			#region Associations
			/// <summary>
			/// Association [PK][One]Production_Location.LocationID --- [FK][Many]Production_ProductInventory.LocationID
			/// </summary>
			[AssociationAttribute(Name="FK_ProductInventory_Location_LocationID", Storage="_Production_ProductInventoryList", ThisKey="LocationID", OtherKey="LocationID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<Production_ProductInventory> Production_ProductInventoryList
			{
				get { return this._Production_ProductInventoryList; }
				set { this._Production_ProductInventoryList.Assign(value); }
			}
			
			/// <summary>
			/// Association [PK][One]Production_Location.LocationID --- [FK][Many]Production_WorkOrderRouting.LocationID
			/// </summary>
			[AssociationAttribute(Name="FK_WorkOrderRouting_Location_LocationID", Storage="_Production_WorkOrderRoutingList", ThisKey="LocationID", OtherKey="LocationID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<Production_WorkOrderRouting> Production_WorkOrderRoutingList
			{
				get { return this._Production_WorkOrderRoutingList; }
				set { this._Production_WorkOrderRoutingList.Assign(value); }
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
		#endregion Production.Location

		#region Production.Product
		[TableAttribute(Name="Production.Product")]
		public partial class Production_Product : EntityBase<Production_Product, AdventureWorksDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private int _ProductID;
			private string _Name;
			private string _ProductNumber;
			private bool _MakeFlag;
			private bool _FinishedGoodsFlag;
			private string _Color;
			private System.Int16 _SafetyStockLevel;
			private System.Int16 _ReorderPoint;
			private decimal _StandardCost;
			private decimal _ListPrice;
			private string _Size;
			private string _SizeUnitMeasureCode;
			private string _WeightUnitMeasureCode;
			private decimal? _Weight;
			private int _DaysToManufacture;
			private string _ProductLine;
			private string _Class;
			private string _Style;
			private int? _ProductSubcategoryID;
			private int? _ProductModelID;
			private DateTime _SellStartDate;
			private DateTime? _SellEndDate;
			private DateTime? _DiscontinuedDate;
			private System.Guid _rowguid;
			private DateTime _ModifiedDate;
			private EntitySet<Production_BillOfMaterials> _Production_BillOfMaterialsList;
			private EntitySet<Production_BillOfMaterials> _ProductList;
			private EntityRef<Production_ProductModel> _Production_ProductModel;
			private EntityRef<Production_ProductSubcategory> _Production_ProductSubcategory;
			private EntityRef<Production_UnitMeasure> _Production_UnitMeasure;
			private EntityRef<Production_UnitMeasure> _WeightUnitMeasureCodeProduction_UnitMeasure;
			private EntitySet<Production_ProductCostHistory> _Production_ProductCostHistoryList;
			private EntitySet<Production_ProductDocument> _Production_ProductDocumentList;
			private EntitySet<Production_ProductInventory> _Production_ProductInventoryList;
			private EntitySet<Production_ProductListPriceHistory> _Production_ProductListPriceHistoryList;
			private EntitySet<Production_ProductProductPhoto> _Production_ProductProductPhotoList;
			private EntitySet<Production_ProductReview> _Production_ProductReviewList;
			private EntitySet<Production_TransactionHistory> _Production_TransactionHistoryList;
			private EntitySet<Production_WorkOrder> _Production_WorkOrderList;
			private EntitySet<Purchasing_ProductVendor> _Purchasing_ProductVendorList;
			private EntitySet<Purchasing_PurchaseOrderDetail> _Purchasing_PurchaseOrderDetailList;
			private EntitySet<Sales_ShoppingCartItem> _Sales_ShoppingCartItemList;
			private EntitySet<Sales_SpecialOfferProduct> _Sales_SpecialOfferProductList;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnProductIDChanging(int value);
			partial void OnProductIDChanged();
			partial void OnNameChanging(string value);
			partial void OnNameChanged();
			partial void OnProductNumberChanging(string value);
			partial void OnProductNumberChanged();
			partial void OnMakeFlagChanging(bool value);
			partial void OnMakeFlagChanged();
			partial void OnFinishedGoodsFlagChanging(bool value);
			partial void OnFinishedGoodsFlagChanged();
			partial void OnColorChanging(string value);
			partial void OnColorChanged();
			partial void OnSafetyStockLevelChanging(System.Int16 value);
			partial void OnSafetyStockLevelChanged();
			partial void OnReorderPointChanging(System.Int16 value);
			partial void OnReorderPointChanged();
			partial void OnStandardCostChanging(decimal value);
			partial void OnStandardCostChanged();
			partial void OnListPriceChanging(decimal value);
			partial void OnListPriceChanged();
			partial void OnSizeChanging(string value);
			partial void OnSizeChanged();
			partial void OnSizeUnitMeasureCodeChanging(string value);
			partial void OnSizeUnitMeasureCodeChanged();
			partial void OnWeightUnitMeasureCodeChanging(string value);
			partial void OnWeightUnitMeasureCodeChanged();
			partial void OnWeightChanging(decimal? value);
			partial void OnWeightChanged();
			partial void OnDaysToManufactureChanging(int value);
			partial void OnDaysToManufactureChanged();
			partial void OnProductLineChanging(string value);
			partial void OnProductLineChanged();
			partial void OnClassChanging(string value);
			partial void OnClassChanged();
			partial void OnStyleChanging(string value);
			partial void OnStyleChanged();
			partial void OnProductSubcategoryIDChanging(int? value);
			partial void OnProductSubcategoryIDChanged();
			partial void OnProductModelIDChanging(int? value);
			partial void OnProductModelIDChanged();
			partial void OnSellStartDateChanging(DateTime value);
			partial void OnSellStartDateChanged();
			partial void OnSellEndDateChanging(DateTime? value);
			partial void OnSellEndDateChanged();
			partial void OnDiscontinuedDateChanging(DateTime? value);
			partial void OnDiscontinuedDateChanged();
			partial void OnrowguidChanging(System.Guid value);
			partial void OnrowguidChanged();
			partial void OnModifiedDateChanging(DateTime value);
			partial void OnModifiedDateChanged();
			#endregion

			public Production_Product()
			{
				_Production_BillOfMaterialsList = new EntitySet<Production_BillOfMaterials>(
					new Action<Production_BillOfMaterials>(item=>{this.SendPropertyChanging(); item.Production_Product=this;}), 
					new Action<Production_BillOfMaterials>(item=>{this.SendPropertyChanging(); item.Production_Product=null;}));
				_ProductList = new EntitySet<Production_BillOfMaterials>(
					new Action<Production_BillOfMaterials>(item=>{this.SendPropertyChanging(); item.ProductAssembly=this;}), 
					new Action<Production_BillOfMaterials>(item=>{this.SendPropertyChanging(); item.ProductAssembly=null;}));
				_Production_ProductModel = default(EntityRef<Production_ProductModel>);
				_Production_ProductSubcategory = default(EntityRef<Production_ProductSubcategory>);
				_Production_UnitMeasure = default(EntityRef<Production_UnitMeasure>);
				_WeightUnitMeasureCodeProduction_UnitMeasure = default(EntityRef<Production_UnitMeasure>);
				_Production_ProductCostHistoryList = new EntitySet<Production_ProductCostHistory>(
					new Action<Production_ProductCostHistory>(item=>{this.SendPropertyChanging(); item.Production_Product=this;}), 
					new Action<Production_ProductCostHistory>(item=>{this.SendPropertyChanging(); item.Production_Product=null;}));
				_Production_ProductDocumentList = new EntitySet<Production_ProductDocument>(
					new Action<Production_ProductDocument>(item=>{this.SendPropertyChanging(); item.Production_Product=this;}), 
					new Action<Production_ProductDocument>(item=>{this.SendPropertyChanging(); item.Production_Product=null;}));
				_Production_ProductInventoryList = new EntitySet<Production_ProductInventory>(
					new Action<Production_ProductInventory>(item=>{this.SendPropertyChanging(); item.Production_Product=this;}), 
					new Action<Production_ProductInventory>(item=>{this.SendPropertyChanging(); item.Production_Product=null;}));
				_Production_ProductListPriceHistoryList = new EntitySet<Production_ProductListPriceHistory>(
					new Action<Production_ProductListPriceHistory>(item=>{this.SendPropertyChanging(); item.Production_Product=this;}), 
					new Action<Production_ProductListPriceHistory>(item=>{this.SendPropertyChanging(); item.Production_Product=null;}));
				_Production_ProductProductPhotoList = new EntitySet<Production_ProductProductPhoto>(
					new Action<Production_ProductProductPhoto>(item=>{this.SendPropertyChanging(); item.Production_Product=this;}), 
					new Action<Production_ProductProductPhoto>(item=>{this.SendPropertyChanging(); item.Production_Product=null;}));
				_Production_ProductReviewList = new EntitySet<Production_ProductReview>(
					new Action<Production_ProductReview>(item=>{this.SendPropertyChanging(); item.Production_Product=this;}), 
					new Action<Production_ProductReview>(item=>{this.SendPropertyChanging(); item.Production_Product=null;}));
				_Production_TransactionHistoryList = new EntitySet<Production_TransactionHistory>(
					new Action<Production_TransactionHistory>(item=>{this.SendPropertyChanging(); item.Production_Product=this;}), 
					new Action<Production_TransactionHistory>(item=>{this.SendPropertyChanging(); item.Production_Product=null;}));
				_Production_WorkOrderList = new EntitySet<Production_WorkOrder>(
					new Action<Production_WorkOrder>(item=>{this.SendPropertyChanging(); item.Production_Product=this;}), 
					new Action<Production_WorkOrder>(item=>{this.SendPropertyChanging(); item.Production_Product=null;}));
				_Purchasing_ProductVendorList = new EntitySet<Purchasing_ProductVendor>(
					new Action<Purchasing_ProductVendor>(item=>{this.SendPropertyChanging(); item.Production_Product=this;}), 
					new Action<Purchasing_ProductVendor>(item=>{this.SendPropertyChanging(); item.Production_Product=null;}));
				_Purchasing_PurchaseOrderDetailList = new EntitySet<Purchasing_PurchaseOrderDetail>(
					new Action<Purchasing_PurchaseOrderDetail>(item=>{this.SendPropertyChanging(); item.Production_Product=this;}), 
					new Action<Purchasing_PurchaseOrderDetail>(item=>{this.SendPropertyChanging(); item.Production_Product=null;}));
				_Sales_ShoppingCartItemList = new EntitySet<Sales_ShoppingCartItem>(
					new Action<Sales_ShoppingCartItem>(item=>{this.SendPropertyChanging(); item.Production_Product=this;}), 
					new Action<Sales_ShoppingCartItem>(item=>{this.SendPropertyChanging(); item.Production_Product=null;}));
				_Sales_SpecialOfferProductList = new EntitySet<Sales_SpecialOfferProduct>(
					new Action<Sales_SpecialOfferProduct>(item=>{this.SendPropertyChanging(); item.Production_Product=this;}), 
					new Action<Sales_SpecialOfferProduct>(item=>{this.SendPropertyChanging(); item.Production_Product=null;}));
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=Int NOT NULL IDENTITY
			/// </summary>
			[ColumnAttribute(Storage="_ProductID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", CanBeNull=false, IsPrimaryKey=true, IsDbGenerated=true)]
			public int ProductID
			{
				get
				{
					return this._ProductID;
				}
				set
				{
					if (this._ProductID != value)
					{
						this.OnProductIDChanging(value);
						this.SendPropertyChanging();
						this._ProductID = value;
						this.SendPropertyChanged("ProductID");
						this.OnProductIDChanged();
					}
					this.SendPropertySetterInvoked("ProductID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(50) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_Name", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
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
			/// Column DbType=NVarChar(25) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ProductNumber", DbType="NVarChar(25) NOT NULL", CanBeNull=false)]
			public string ProductNumber
			{
				get
				{
					return this._ProductNumber;
				}
				set
				{
					if (this._ProductNumber != value)
					{
						this.OnProductNumberChanging(value);
						this.SendPropertyChanging();
						this._ProductNumber = value;
						this.SendPropertyChanged("ProductNumber");
						this.OnProductNumberChanged();
					}
					this.SendPropertySetterInvoked("ProductNumber", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Bit NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_MakeFlag", DbType="Bit NOT NULL", CanBeNull=false)]
			public bool MakeFlag
			{
				get
				{
					return this._MakeFlag;
				}
				set
				{
					if (this._MakeFlag != value)
					{
						this.OnMakeFlagChanging(value);
						this.SendPropertyChanging();
						this._MakeFlag = value;
						this.SendPropertyChanged("MakeFlag");
						this.OnMakeFlagChanged();
					}
					this.SendPropertySetterInvoked("MakeFlag", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Bit NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_FinishedGoodsFlag", DbType="Bit NOT NULL", CanBeNull=false)]
			public bool FinishedGoodsFlag
			{
				get
				{
					return this._FinishedGoodsFlag;
				}
				set
				{
					if (this._FinishedGoodsFlag != value)
					{
						this.OnFinishedGoodsFlagChanging(value);
						this.SendPropertyChanging();
						this._FinishedGoodsFlag = value;
						this.SendPropertyChanged("FinishedGoodsFlag");
						this.OnFinishedGoodsFlagChanged();
					}
					this.SendPropertySetterInvoked("FinishedGoodsFlag", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(15)
			/// </summary>
			[ColumnAttribute(Storage="_Color", DbType="NVarChar(15)", CanBeNull=true)]
			public string Color
			{
				get
				{
					return this._Color;
				}
				set
				{
					if (this._Color != value)
					{
						this.OnColorChanging(value);
						this.SendPropertyChanging();
						this._Color = value;
						this.SendPropertyChanged("Color");
						this.OnColorChanged();
					}
					this.SendPropertySetterInvoked("Color", value);
				}
			}
			
			/// <summary>
			/// Column DbType=SmallInt NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_SafetyStockLevel", DbType="SmallInt NOT NULL", CanBeNull=false)]
			public System.Int16 SafetyStockLevel
			{
				get
				{
					return this._SafetyStockLevel;
				}
				set
				{
					if (this._SafetyStockLevel != value)
					{
						this.OnSafetyStockLevelChanging(value);
						this.SendPropertyChanging();
						this._SafetyStockLevel = value;
						this.SendPropertyChanged("SafetyStockLevel");
						this.OnSafetyStockLevelChanged();
					}
					this.SendPropertySetterInvoked("SafetyStockLevel", value);
				}
			}
			
			/// <summary>
			/// Column DbType=SmallInt NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ReorderPoint", DbType="SmallInt NOT NULL", CanBeNull=false)]
			public System.Int16 ReorderPoint
			{
				get
				{
					return this._ReorderPoint;
				}
				set
				{
					if (this._ReorderPoint != value)
					{
						this.OnReorderPointChanging(value);
						this.SendPropertyChanging();
						this._ReorderPoint = value;
						this.SendPropertyChanged("ReorderPoint");
						this.OnReorderPointChanged();
					}
					this.SendPropertySetterInvoked("ReorderPoint", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Money NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_StandardCost", DbType="Money NOT NULL", CanBeNull=false)]
			public decimal StandardCost
			{
				get
				{
					return this._StandardCost;
				}
				set
				{
					if (this._StandardCost != value)
					{
						this.OnStandardCostChanging(value);
						this.SendPropertyChanging();
						this._StandardCost = value;
						this.SendPropertyChanged("StandardCost");
						this.OnStandardCostChanged();
					}
					this.SendPropertySetterInvoked("StandardCost", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Money NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ListPrice", DbType="Money NOT NULL", CanBeNull=false)]
			public decimal ListPrice
			{
				get
				{
					return this._ListPrice;
				}
				set
				{
					if (this._ListPrice != value)
					{
						this.OnListPriceChanging(value);
						this.SendPropertyChanging();
						this._ListPrice = value;
						this.SendPropertyChanged("ListPrice");
						this.OnListPriceChanged();
					}
					this.SendPropertySetterInvoked("ListPrice", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(5)
			/// </summary>
			[ColumnAttribute(Storage="_Size", DbType="NVarChar(5)", CanBeNull=true)]
			public string Size
			{
				get
				{
					return this._Size;
				}
				set
				{
					if (this._Size != value)
					{
						this.OnSizeChanging(value);
						this.SendPropertyChanging();
						this._Size = value;
						this.SendPropertyChanged("Size");
						this.OnSizeChanged();
					}
					this.SendPropertySetterInvoked("Size", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NChar(3)
			/// </summary>
			[ColumnAttribute(Storage="_SizeUnitMeasureCode", DbType="NChar(3)", CanBeNull=true)]
			public string SizeUnitMeasureCode
			{
				get
				{
					return this._SizeUnitMeasureCode;
				}
				set
				{
					if (this._SizeUnitMeasureCode != value)
					{
						this.OnSizeUnitMeasureCodeChanging(value);
						this.SendPropertyChanging();
						this._SizeUnitMeasureCode = value;
						this.SendPropertyChanged("SizeUnitMeasureCode");
						this.OnSizeUnitMeasureCodeChanged();
					}
					this.SendPropertySetterInvoked("SizeUnitMeasureCode", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NChar(3)
			/// </summary>
			[ColumnAttribute(Storage="_WeightUnitMeasureCode", DbType="NChar(3)", CanBeNull=true)]
			public string WeightUnitMeasureCode
			{
				get
				{
					return this._WeightUnitMeasureCode;
				}
				set
				{
					if (this._WeightUnitMeasureCode != value)
					{
						this.OnWeightUnitMeasureCodeChanging(value);
						this.SendPropertyChanging();
						this._WeightUnitMeasureCode = value;
						this.SendPropertyChanged("WeightUnitMeasureCode");
						this.OnWeightUnitMeasureCodeChanged();
					}
					this.SendPropertySetterInvoked("WeightUnitMeasureCode", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Decimal(8,2)
			/// </summary>
			[ColumnAttribute(Storage="_Weight", DbType="Decimal(8,2)", CanBeNull=true)]
			public decimal? Weight
			{
				get
				{
					return this._Weight;
				}
				set
				{
					if (this._Weight != value)
					{
						this.OnWeightChanging(value);
						this.SendPropertyChanging();
						this._Weight = value;
						this.SendPropertyChanged("Weight");
						this.OnWeightChanged();
					}
					this.SendPropertySetterInvoked("Weight", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_DaysToManufacture", DbType="Int NOT NULL", CanBeNull=false)]
			public int DaysToManufacture
			{
				get
				{
					return this._DaysToManufacture;
				}
				set
				{
					if (this._DaysToManufacture != value)
					{
						this.OnDaysToManufactureChanging(value);
						this.SendPropertyChanging();
						this._DaysToManufacture = value;
						this.SendPropertyChanged("DaysToManufacture");
						this.OnDaysToManufactureChanged();
					}
					this.SendPropertySetterInvoked("DaysToManufacture", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NChar(2)
			/// </summary>
			[ColumnAttribute(Storage="_ProductLine", DbType="NChar(2)", CanBeNull=true)]
			public string ProductLine
			{
				get
				{
					return this._ProductLine;
				}
				set
				{
					if (this._ProductLine != value)
					{
						this.OnProductLineChanging(value);
						this.SendPropertyChanging();
						this._ProductLine = value;
						this.SendPropertyChanged("ProductLine");
						this.OnProductLineChanged();
					}
					this.SendPropertySetterInvoked("ProductLine", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NChar(2)
			/// </summary>
			[ColumnAttribute(Storage="_Class", DbType="NChar(2)", CanBeNull=true)]
			public string Class
			{
				get
				{
					return this._Class;
				}
				set
				{
					if (this._Class != value)
					{
						this.OnClassChanging(value);
						this.SendPropertyChanging();
						this._Class = value;
						this.SendPropertyChanged("Class");
						this.OnClassChanged();
					}
					this.SendPropertySetterInvoked("Class", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NChar(2)
			/// </summary>
			[ColumnAttribute(Storage="_Style", DbType="NChar(2)", CanBeNull=true)]
			public string Style
			{
				get
				{
					return this._Style;
				}
				set
				{
					if (this._Style != value)
					{
						this.OnStyleChanging(value);
						this.SendPropertyChanging();
						this._Style = value;
						this.SendPropertyChanged("Style");
						this.OnStyleChanged();
					}
					this.SendPropertySetterInvoked("Style", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int
			/// </summary>
			[ColumnAttribute(Storage="_ProductSubcategoryID", DbType="Int", CanBeNull=true)]
			public int? ProductSubcategoryID
			{
				get
				{
					return this._ProductSubcategoryID;
				}
				set
				{
					if (this._ProductSubcategoryID != value)
					{
						this.OnProductSubcategoryIDChanging(value);
						this.SendPropertyChanging();
						this._ProductSubcategoryID = value;
						this.SendPropertyChanged("ProductSubcategoryID");
						this.OnProductSubcategoryIDChanged();
					}
					this.SendPropertySetterInvoked("ProductSubcategoryID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int
			/// </summary>
			[ColumnAttribute(Storage="_ProductModelID", DbType="Int", CanBeNull=true)]
			public int? ProductModelID
			{
				get
				{
					return this._ProductModelID;
				}
				set
				{
					if (this._ProductModelID != value)
					{
						this.OnProductModelIDChanging(value);
						this.SendPropertyChanging();
						this._ProductModelID = value;
						this.SendPropertyChanged("ProductModelID");
						this.OnProductModelIDChanged();
					}
					this.SendPropertySetterInvoked("ProductModelID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_SellStartDate", DbType="DateTime NOT NULL", CanBeNull=false)]
			public DateTime SellStartDate
			{
				get
				{
					return this._SellStartDate;
				}
				set
				{
					if (this._SellStartDate != value)
					{
						this.OnSellStartDateChanging(value);
						this.SendPropertyChanging();
						this._SellStartDate = value;
						this.SendPropertyChanged("SellStartDate");
						this.OnSellStartDateChanged();
					}
					this.SendPropertySetterInvoked("SellStartDate", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime
			/// </summary>
			[ColumnAttribute(Storage="_SellEndDate", DbType="DateTime", CanBeNull=true)]
			public DateTime? SellEndDate
			{
				get
				{
					return this._SellEndDate;
				}
				set
				{
					if (this._SellEndDate != value)
					{
						this.OnSellEndDateChanging(value);
						this.SendPropertyChanging();
						this._SellEndDate = value;
						this.SendPropertyChanged("SellEndDate");
						this.OnSellEndDateChanged();
					}
					this.SendPropertySetterInvoked("SellEndDate", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime
			/// </summary>
			[ColumnAttribute(Storage="_DiscontinuedDate", DbType="DateTime", CanBeNull=true)]
			public DateTime? DiscontinuedDate
			{
				get
				{
					return this._DiscontinuedDate;
				}
				set
				{
					if (this._DiscontinuedDate != value)
					{
						this.OnDiscontinuedDateChanging(value);
						this.SendPropertyChanging();
						this._DiscontinuedDate = value;
						this.SendPropertyChanged("DiscontinuedDate");
						this.OnDiscontinuedDateChanged();
					}
					this.SendPropertySetterInvoked("DiscontinuedDate", value);
				}
			}
			
			/// <summary>
			/// Column DbType=UniqueIdentifier NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_rowguid", DbType="UniqueIdentifier NOT NULL", CanBeNull=false)]
			public System.Guid rowguid
			{
				get
				{
					return this._rowguid;
				}
				set
				{
					if (this._rowguid != value)
					{
						this.OnrowguidChanging(value);
						this.SendPropertyChanging();
						this._rowguid = value;
						this.SendPropertyChanged("rowguid");
						this.OnrowguidChanged();
					}
					this.SendPropertySetterInvoked("rowguid", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ModifiedDate", DbType="DateTime NOT NULL", CanBeNull=false)]
			public DateTime ModifiedDate
			{
				get
				{
					return this._ModifiedDate;
				}
				set
				{
					if (this._ModifiedDate != value)
					{
						this.OnModifiedDateChanging(value);
						this.SendPropertyChanging();
						this._ModifiedDate = value;
						this.SendPropertyChanged("ModifiedDate");
						this.OnModifiedDateChanged();
					}
					this.SendPropertySetterInvoked("ModifiedDate", value);
				}
			}
			
			#endregion Columns

			#region Associations
			/// <summary>
			/// Association [PK][One]Production_Product.ProductID --- [FK][Many]Production_BillOfMaterials.ComponentID
			/// </summary>
			[AssociationAttribute(Name="FK_BillOfMaterials_Product_ComponentID", Storage="_Production_BillOfMaterialsList", ThisKey="ProductID", OtherKey="ComponentID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<Production_BillOfMaterials> Production_BillOfMaterialsList
			{
				get { return this._Production_BillOfMaterialsList; }
				set { this._Production_BillOfMaterialsList.Assign(value); }
			}
			
			/// <summary>
			/// Association [PK][One]Production_Product.ProductID --- [FK][Many]Production_BillOfMaterials.ProductAssemblyID
			/// </summary>
			[AssociationAttribute(Name="FK_BillOfMaterials_Product_ProductAssemblyID", Storage="_ProductList", ThisKey="ProductID", OtherKey="ProductAssemblyID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<Production_BillOfMaterials> ProductList
			{
				get { return this._ProductList; }
				set { this._ProductList.Assign(value); }
			}
			
			/// <summary>
			/// Association [FK][Many]Production_Product.ProductModelID --- [PK][One]Production_ProductModel.ProductModelID
			/// </summary>
			[AssociationAttribute(Name="FK_Product_ProductModel_ProductModelID", Storage="_Production_ProductModel", ThisKey="ProductModelID", OtherKey="ProductModelID", IsUnique=false, IsForeignKey=true)]
			public Production_ProductModel Production_ProductModel
			{
				get
				{
					return this._Production_ProductModel.Entity;
				}
				set
				{
					Production_ProductModel previousValue = this._Production_ProductModel.Entity;
					if ((previousValue != value) || (this._Production_ProductModel.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._Production_ProductModel.Entity = null;
							previousValue.Production_ProductList.Remove(this);
						}
						this._Production_ProductModel.Entity = value;
						if (value != null)
						{
							value.Production_ProductList.Add(this);
							this._ProductModelID = value.ProductModelID;
						}
						else
						{
							this._ProductModelID = default(int?);
						}
						this.SendPropertyChanged("Production_ProductModel");
					}
					this.SendPropertySetterInvoked("Production_ProductModel", value);
				}
			}
			
			/// <summary>
			/// Association [FK][Many]Production_Product.ProductSubcategoryID --- [PK][One]Production_ProductSubcategory.ProductSubcategoryID
			/// </summary>
			[AssociationAttribute(Name="FK_Product_ProductSubcategory_ProductSubcategoryID", Storage="_Production_ProductSubcategory", ThisKey="ProductSubcategoryID", OtherKey="ProductSubcategoryID", IsUnique=false, IsForeignKey=true)]
			public Production_ProductSubcategory Production_ProductSubcategory
			{
				get
				{
					return this._Production_ProductSubcategory.Entity;
				}
				set
				{
					Production_ProductSubcategory previousValue = this._Production_ProductSubcategory.Entity;
					if ((previousValue != value) || (this._Production_ProductSubcategory.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._Production_ProductSubcategory.Entity = null;
							previousValue.Production_ProductList.Remove(this);
						}
						this._Production_ProductSubcategory.Entity = value;
						if (value != null)
						{
							value.Production_ProductList.Add(this);
							this._ProductSubcategoryID = value.ProductSubcategoryID;
						}
						else
						{
							this._ProductSubcategoryID = default(int?);
						}
						this.SendPropertyChanged("Production_ProductSubcategory");
					}
					this.SendPropertySetterInvoked("Production_ProductSubcategory", value);
				}
			}
			
			/// <summary>
			/// Association [FK][Many]Production_Product.SizeUnitMeasureCode --- [PK][One]Production_UnitMeasure.UnitMeasureCode
			/// </summary>
			[AssociationAttribute(Name="FK_Product_UnitMeasure_SizeUnitMeasureCode", Storage="_Production_UnitMeasure", ThisKey="SizeUnitMeasureCode", OtherKey="UnitMeasureCode", IsUnique=false, IsForeignKey=true)]
			public Production_UnitMeasure Production_UnitMeasure
			{
				get
				{
					return this._Production_UnitMeasure.Entity;
				}
				set
				{
					Production_UnitMeasure previousValue = this._Production_UnitMeasure.Entity;
					if ((previousValue != value) || (this._Production_UnitMeasure.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._Production_UnitMeasure.Entity = null;
							previousValue.Production_ProductList.Remove(this);
						}
						this._Production_UnitMeasure.Entity = value;
						if (value != null)
						{
							value.Production_ProductList.Add(this);
							this._SizeUnitMeasureCode = value.UnitMeasureCode;
						}
						else
						{
							this._SizeUnitMeasureCode = default(string);
						}
						this.SendPropertyChanged("Production_UnitMeasure");
					}
					this.SendPropertySetterInvoked("Production_UnitMeasure", value);
				}
			}
			
			/// <summary>
			/// Association [FK][Many]Production_Product.WeightUnitMeasureCode --- [PK][One]Production_UnitMeasure.UnitMeasureCode
			/// </summary>
			[AssociationAttribute(Name="FK_Product_UnitMeasure_WeightUnitMeasureCode", Storage="_WeightUnitMeasureCodeProduction_UnitMeasure", ThisKey="WeightUnitMeasureCode", OtherKey="UnitMeasureCode", IsUnique=false, IsForeignKey=true)]
			public Production_UnitMeasure WeightUnitMeasureCodeProduction_UnitMeasure
			{
				get
				{
					return this._WeightUnitMeasureCodeProduction_UnitMeasure.Entity;
				}
				set
				{
					Production_UnitMeasure previousValue = this._WeightUnitMeasureCodeProduction_UnitMeasure.Entity;
					if ((previousValue != value) || (this._WeightUnitMeasureCodeProduction_UnitMeasure.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._WeightUnitMeasureCodeProduction_UnitMeasure.Entity = null;
							previousValue.UnitMeasureCodeProduction_ProductList.Remove(this);
						}
						this._WeightUnitMeasureCodeProduction_UnitMeasure.Entity = value;
						if (value != null)
						{
							value.UnitMeasureCodeProduction_ProductList.Add(this);
							this._WeightUnitMeasureCode = value.UnitMeasureCode;
						}
						else
						{
							this._WeightUnitMeasureCode = default(string);
						}
						this.SendPropertyChanged("WeightUnitMeasureCodeProduction_UnitMeasure");
					}
					this.SendPropertySetterInvoked("WeightUnitMeasureCodeProduction_UnitMeasure", value);
				}
			}
			
			/// <summary>
			/// Association [PK][One]Production_Product.ProductID --- [FK][Many]Production_ProductCostHistory.ProductID
			/// </summary>
			[AssociationAttribute(Name="FK_ProductCostHistory_Product_ProductID", Storage="_Production_ProductCostHistoryList", ThisKey="ProductID", OtherKey="ProductID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<Production_ProductCostHistory> Production_ProductCostHistoryList
			{
				get { return this._Production_ProductCostHistoryList; }
				set { this._Production_ProductCostHistoryList.Assign(value); }
			}
			
			/// <summary>
			/// Association [PK][One]Production_Product.ProductID --- [FK][Many]Production_ProductDocument.ProductID
			/// </summary>
			[AssociationAttribute(Name="FK_ProductDocument_Product_ProductID", Storage="_Production_ProductDocumentList", ThisKey="ProductID", OtherKey="ProductID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<Production_ProductDocument> Production_ProductDocumentList
			{
				get { return this._Production_ProductDocumentList; }
				set { this._Production_ProductDocumentList.Assign(value); }
			}
			
			/// <summary>
			/// Association [PK][One]Production_Product.ProductID --- [FK][Many]Production_ProductInventory.ProductID
			/// </summary>
			[AssociationAttribute(Name="FK_ProductInventory_Product_ProductID", Storage="_Production_ProductInventoryList", ThisKey="ProductID", OtherKey="ProductID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<Production_ProductInventory> Production_ProductInventoryList
			{
				get { return this._Production_ProductInventoryList; }
				set { this._Production_ProductInventoryList.Assign(value); }
			}
			
			/// <summary>
			/// Association [PK][One]Production_Product.ProductID --- [FK][Many]Production_ProductListPriceHistory.ProductID
			/// </summary>
			[AssociationAttribute(Name="FK_ProductListPriceHistory_Product_ProductID", Storage="_Production_ProductListPriceHistoryList", ThisKey="ProductID", OtherKey="ProductID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<Production_ProductListPriceHistory> Production_ProductListPriceHistoryList
			{
				get { return this._Production_ProductListPriceHistoryList; }
				set { this._Production_ProductListPriceHistoryList.Assign(value); }
			}
			
			/// <summary>
			/// Association [PK][One]Production_Product.ProductID --- [FK][Many]Production_ProductProductPhoto.ProductID
			/// </summary>
			[AssociationAttribute(Name="FK_ProductProductPhoto_Product_ProductID", Storage="_Production_ProductProductPhotoList", ThisKey="ProductID", OtherKey="ProductID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<Production_ProductProductPhoto> Production_ProductProductPhotoList
			{
				get { return this._Production_ProductProductPhotoList; }
				set { this._Production_ProductProductPhotoList.Assign(value); }
			}
			
			/// <summary>
			/// Association [PK][One]Production_Product.ProductID --- [FK][Many]Production_ProductReview.ProductID
			/// </summary>
			[AssociationAttribute(Name="FK_ProductReview_Product_ProductID", Storage="_Production_ProductReviewList", ThisKey="ProductID", OtherKey="ProductID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<Production_ProductReview> Production_ProductReviewList
			{
				get { return this._Production_ProductReviewList; }
				set { this._Production_ProductReviewList.Assign(value); }
			}
			
			/// <summary>
			/// Association [PK][One]Production_Product.ProductID --- [FK][Many]Production_TransactionHistory.ProductID
			/// </summary>
			[AssociationAttribute(Name="FK_TransactionHistory_Product_ProductID", Storage="_Production_TransactionHistoryList", ThisKey="ProductID", OtherKey="ProductID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<Production_TransactionHistory> Production_TransactionHistoryList
			{
				get { return this._Production_TransactionHistoryList; }
				set { this._Production_TransactionHistoryList.Assign(value); }
			}
			
			/// <summary>
			/// Association [PK][One]Production_Product.ProductID --- [FK][Many]Production_WorkOrder.ProductID
			/// </summary>
			[AssociationAttribute(Name="FK_WorkOrder_Product_ProductID", Storage="_Production_WorkOrderList", ThisKey="ProductID", OtherKey="ProductID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<Production_WorkOrder> Production_WorkOrderList
			{
				get { return this._Production_WorkOrderList; }
				set { this._Production_WorkOrderList.Assign(value); }
			}
			
			/// <summary>
			/// Association [PK][One]Production_Product.ProductID --- [FK][Many]Purchasing_ProductVendor.ProductID
			/// </summary>
			[AssociationAttribute(Name="FK_ProductVendor_Product_ProductID", Storage="_Purchasing_ProductVendorList", ThisKey="ProductID", OtherKey="ProductID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<Purchasing_ProductVendor> Purchasing_ProductVendorList
			{
				get { return this._Purchasing_ProductVendorList; }
				set { this._Purchasing_ProductVendorList.Assign(value); }
			}
			
			/// <summary>
			/// Association [PK][One]Production_Product.ProductID --- [FK][Many]Purchasing_PurchaseOrderDetail.ProductID
			/// </summary>
			[AssociationAttribute(Name="FK_PurchaseOrderDetail_Product_ProductID", Storage="_Purchasing_PurchaseOrderDetailList", ThisKey="ProductID", OtherKey="ProductID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<Purchasing_PurchaseOrderDetail> Purchasing_PurchaseOrderDetailList
			{
				get { return this._Purchasing_PurchaseOrderDetailList; }
				set { this._Purchasing_PurchaseOrderDetailList.Assign(value); }
			}
			
			/// <summary>
			/// Association [PK][One]Production_Product.ProductID --- [FK][Many]Sales_ShoppingCartItem.ProductID
			/// </summary>
			[AssociationAttribute(Name="FK_ShoppingCartItem_Product_ProductID", Storage="_Sales_ShoppingCartItemList", ThisKey="ProductID", OtherKey="ProductID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<Sales_ShoppingCartItem> Sales_ShoppingCartItemList
			{
				get { return this._Sales_ShoppingCartItemList; }
				set { this._Sales_ShoppingCartItemList.Assign(value); }
			}
			
			/// <summary>
			/// Association [PK][One]Production_Product.ProductID --- [FK][Many]Sales_SpecialOfferProduct.ProductID
			/// </summary>
			[AssociationAttribute(Name="FK_SpecialOfferProduct_Product_ProductID", Storage="_Sales_SpecialOfferProductList", ThisKey="ProductID", OtherKey="ProductID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<Sales_SpecialOfferProduct> Sales_SpecialOfferProductList
			{
				get { return this._Sales_SpecialOfferProductList; }
				set { this._Sales_SpecialOfferProductList.Assign(value); }
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
		#endregion Production.Product

		#region Production.ProductCategory
		[TableAttribute(Name="Production.ProductCategory")]
		public partial class Production_ProductCategory : EntityBase<Production_ProductCategory, AdventureWorksDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private int _ProductCategoryID;
			private string _Name;
			private System.Guid _rowguid;
			private DateTime _ModifiedDate;
			private EntitySet<Production_ProductSubcategory> _Production_ProductSubcategoryList;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnProductCategoryIDChanging(int value);
			partial void OnProductCategoryIDChanged();
			partial void OnNameChanging(string value);
			partial void OnNameChanged();
			partial void OnrowguidChanging(System.Guid value);
			partial void OnrowguidChanged();
			partial void OnModifiedDateChanging(DateTime value);
			partial void OnModifiedDateChanged();
			#endregion

			public Production_ProductCategory()
			{
				_Production_ProductSubcategoryList = new EntitySet<Production_ProductSubcategory>(
					new Action<Production_ProductSubcategory>(item=>{this.SendPropertyChanging(); item.Production_ProductCategory=this;}), 
					new Action<Production_ProductSubcategory>(item=>{this.SendPropertyChanging(); item.Production_ProductCategory=null;}));
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=Int NOT NULL IDENTITY
			/// </summary>
			[ColumnAttribute(Storage="_ProductCategoryID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", CanBeNull=false, IsPrimaryKey=true, IsDbGenerated=true)]
			public int ProductCategoryID
			{
				get
				{
					return this._ProductCategoryID;
				}
				set
				{
					if (this._ProductCategoryID != value)
					{
						this.OnProductCategoryIDChanging(value);
						this.SendPropertyChanging();
						this._ProductCategoryID = value;
						this.SendPropertyChanged("ProductCategoryID");
						this.OnProductCategoryIDChanged();
					}
					this.SendPropertySetterInvoked("ProductCategoryID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(50) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_Name", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
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
			/// Column DbType=UniqueIdentifier NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_rowguid", DbType="UniqueIdentifier NOT NULL", CanBeNull=false)]
			public System.Guid rowguid
			{
				get
				{
					return this._rowguid;
				}
				set
				{
					if (this._rowguid != value)
					{
						this.OnrowguidChanging(value);
						this.SendPropertyChanging();
						this._rowguid = value;
						this.SendPropertyChanged("rowguid");
						this.OnrowguidChanged();
					}
					this.SendPropertySetterInvoked("rowguid", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ModifiedDate", DbType="DateTime NOT NULL", CanBeNull=false)]
			public DateTime ModifiedDate
			{
				get
				{
					return this._ModifiedDate;
				}
				set
				{
					if (this._ModifiedDate != value)
					{
						this.OnModifiedDateChanging(value);
						this.SendPropertyChanging();
						this._ModifiedDate = value;
						this.SendPropertyChanged("ModifiedDate");
						this.OnModifiedDateChanged();
					}
					this.SendPropertySetterInvoked("ModifiedDate", value);
				}
			}
			
			#endregion Columns

			#region Associations
			/// <summary>
			/// Association [PK][One]Production_ProductCategory.ProductCategoryID --- [FK][Many]Production_ProductSubcategory.ProductCategoryID
			/// </summary>
			[AssociationAttribute(Name="FK_ProductSubcategory_ProductCategory_ProductCategoryID", Storage="_Production_ProductSubcategoryList", ThisKey="ProductCategoryID", OtherKey="ProductCategoryID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<Production_ProductSubcategory> Production_ProductSubcategoryList
			{
				get { return this._Production_ProductSubcategoryList; }
				set { this._Production_ProductSubcategoryList.Assign(value); }
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
		#endregion Production.ProductCategory

		#region Production.ProductCostHistory
		[TableAttribute(Name="Production.ProductCostHistory")]
		public partial class Production_ProductCostHistory : EntityBase<Production_ProductCostHistory, AdventureWorksDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private int _ProductID;
			private DateTime _StartDate;
			private DateTime? _EndDate;
			private decimal _StandardCost;
			private DateTime _ModifiedDate;
			private EntityRef<Production_Product> _Production_Product;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnProductIDChanging(int value);
			partial void OnProductIDChanged();
			partial void OnStartDateChanging(DateTime value);
			partial void OnStartDateChanged();
			partial void OnEndDateChanging(DateTime? value);
			partial void OnEndDateChanged();
			partial void OnStandardCostChanging(decimal value);
			partial void OnStandardCostChanged();
			partial void OnModifiedDateChanging(DateTime value);
			partial void OnModifiedDateChanged();
			#endregion

			public Production_ProductCostHistory()
			{
				_Production_Product = default(EntityRef<Production_Product>);
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ProductID", DbType="Int NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
			public int ProductID
			{
				get
				{
					return this._ProductID;
				}
				set
				{
					if (this._ProductID != value)
					{
						this.OnProductIDChanging(value);
						this.SendPropertyChanging();
						this._ProductID = value;
						this.SendPropertyChanged("ProductID");
						this.OnProductIDChanged();
					}
					this.SendPropertySetterInvoked("ProductID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_StartDate", DbType="DateTime NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
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
						this.OnStartDateChanging(value);
						this.SendPropertyChanging();
						this._StartDate = value;
						this.SendPropertyChanged("StartDate");
						this.OnStartDateChanged();
					}
					this.SendPropertySetterInvoked("StartDate", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime
			/// </summary>
			[ColumnAttribute(Storage="_EndDate", DbType="DateTime", CanBeNull=true)]
			public DateTime? EndDate
			{
				get
				{
					return this._EndDate;
				}
				set
				{
					if (this._EndDate != value)
					{
						this.OnEndDateChanging(value);
						this.SendPropertyChanging();
						this._EndDate = value;
						this.SendPropertyChanged("EndDate");
						this.OnEndDateChanged();
					}
					this.SendPropertySetterInvoked("EndDate", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Money NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_StandardCost", DbType="Money NOT NULL", CanBeNull=false)]
			public decimal StandardCost
			{
				get
				{
					return this._StandardCost;
				}
				set
				{
					if (this._StandardCost != value)
					{
						this.OnStandardCostChanging(value);
						this.SendPropertyChanging();
						this._StandardCost = value;
						this.SendPropertyChanged("StandardCost");
						this.OnStandardCostChanged();
					}
					this.SendPropertySetterInvoked("StandardCost", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ModifiedDate", DbType="DateTime NOT NULL", CanBeNull=false)]
			public DateTime ModifiedDate
			{
				get
				{
					return this._ModifiedDate;
				}
				set
				{
					if (this._ModifiedDate != value)
					{
						this.OnModifiedDateChanging(value);
						this.SendPropertyChanging();
						this._ModifiedDate = value;
						this.SendPropertyChanged("ModifiedDate");
						this.OnModifiedDateChanged();
					}
					this.SendPropertySetterInvoked("ModifiedDate", value);
				}
			}
			
			#endregion Columns

			#region Associations
			/// <summary>
			/// Association [FK][Many]Production_ProductCostHistory.ProductID --- [PK][One]Production_Product.ProductID
			/// </summary>
			[AssociationAttribute(Name="FK_ProductCostHistory_Product_ProductID", Storage="_Production_Product", ThisKey="ProductID", OtherKey="ProductID", IsUnique=false, IsForeignKey=true)]
			public Production_Product Production_Product
			{
				get
				{
					return this._Production_Product.Entity;
				}
				set
				{
					Production_Product previousValue = this._Production_Product.Entity;
					if ((previousValue != value) || (this._Production_Product.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._Production_Product.Entity = null;
							previousValue.Production_ProductCostHistoryList.Remove(this);
						}
						this._Production_Product.Entity = value;
						if (value != null)
						{
							value.Production_ProductCostHistoryList.Add(this);
							this._ProductID = value.ProductID;
						}
						else
						{
							this._ProductID = default(int);
						}
						this.SendPropertyChanged("Production_Product");
					}
					this.SendPropertySetterInvoked("Production_Product", value);
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
		#endregion Production.ProductCostHistory

		#region Production.ProductDescription
		[TableAttribute(Name="Production.ProductDescription")]
		public partial class Production_ProductDescription : EntityBase<Production_ProductDescription, AdventureWorksDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private int _ProductDescriptionID;
			private string _Description;
			private System.Guid _rowguid;
			private DateTime _ModifiedDate;
			private EntitySet<Production_ProductModelProductDescriptionCulture> _Production_ProductModelProductDescriptionCultureList;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnProductDescriptionIDChanging(int value);
			partial void OnProductDescriptionIDChanged();
			partial void OnDescriptionChanging(string value);
			partial void OnDescriptionChanged();
			partial void OnrowguidChanging(System.Guid value);
			partial void OnrowguidChanged();
			partial void OnModifiedDateChanging(DateTime value);
			partial void OnModifiedDateChanged();
			#endregion

			public Production_ProductDescription()
			{
				_Production_ProductModelProductDescriptionCultureList = new EntitySet<Production_ProductModelProductDescriptionCulture>(
					new Action<Production_ProductModelProductDescriptionCulture>(item=>{this.SendPropertyChanging(); item.Production_ProductDescription=this;}), 
					new Action<Production_ProductModelProductDescriptionCulture>(item=>{this.SendPropertyChanging(); item.Production_ProductDescription=null;}));
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=Int NOT NULL IDENTITY
			/// </summary>
			[ColumnAttribute(Storage="_ProductDescriptionID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", CanBeNull=false, IsPrimaryKey=true, IsDbGenerated=true)]
			public int ProductDescriptionID
			{
				get
				{
					return this._ProductDescriptionID;
				}
				set
				{
					if (this._ProductDescriptionID != value)
					{
						this.OnProductDescriptionIDChanging(value);
						this.SendPropertyChanging();
						this._ProductDescriptionID = value;
						this.SendPropertyChanged("ProductDescriptionID");
						this.OnProductDescriptionIDChanged();
					}
					this.SendPropertySetterInvoked("ProductDescriptionID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(400) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_Description", DbType="NVarChar(400) NOT NULL", CanBeNull=false)]
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
			/// Column DbType=UniqueIdentifier NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_rowguid", DbType="UniqueIdentifier NOT NULL", CanBeNull=false)]
			public System.Guid rowguid
			{
				get
				{
					return this._rowguid;
				}
				set
				{
					if (this._rowguid != value)
					{
						this.OnrowguidChanging(value);
						this.SendPropertyChanging();
						this._rowguid = value;
						this.SendPropertyChanged("rowguid");
						this.OnrowguidChanged();
					}
					this.SendPropertySetterInvoked("rowguid", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ModifiedDate", DbType="DateTime NOT NULL", CanBeNull=false)]
			public DateTime ModifiedDate
			{
				get
				{
					return this._ModifiedDate;
				}
				set
				{
					if (this._ModifiedDate != value)
					{
						this.OnModifiedDateChanging(value);
						this.SendPropertyChanging();
						this._ModifiedDate = value;
						this.SendPropertyChanged("ModifiedDate");
						this.OnModifiedDateChanged();
					}
					this.SendPropertySetterInvoked("ModifiedDate", value);
				}
			}
			
			#endregion Columns

			#region Associations
			/// <summary>
			/// Association [PK][One]Production_ProductDescription.ProductDescriptionID --- [FK][Many]Production_ProductModelProductDescriptionCulture.ProductDescriptionID
			/// </summary>
			[AssociationAttribute(Name="FK_ProductModelProductDescriptionCulture_ProductDescription_ProductDescriptionID", Storage="_Production_ProductModelProductDescriptionCultureList", ThisKey="ProductDescriptionID", OtherKey="ProductDescriptionID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<Production_ProductModelProductDescriptionCulture> Production_ProductModelProductDescriptionCultureList
			{
				get { return this._Production_ProductModelProductDescriptionCultureList; }
				set { this._Production_ProductModelProductDescriptionCultureList.Assign(value); }
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
		#endregion Production.ProductDescription

		#region Production.ProductDocument
		[TableAttribute(Name="Production.ProductDocument")]
		public partial class Production_ProductDocument : EntityBase<Production_ProductDocument, AdventureWorksDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private int _ProductID;
			private int _DocumentID;
			private DateTime _ModifiedDate;
			private EntityRef<Production_Document> _Production_Document;
			private EntityRef<Production_Product> _Production_Product;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnProductIDChanging(int value);
			partial void OnProductIDChanged();
			partial void OnDocumentIDChanging(int value);
			partial void OnDocumentIDChanged();
			partial void OnModifiedDateChanging(DateTime value);
			partial void OnModifiedDateChanged();
			#endregion

			public Production_ProductDocument()
			{
				_Production_Document = default(EntityRef<Production_Document>);
				_Production_Product = default(EntityRef<Production_Product>);
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ProductID", DbType="Int NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
			public int ProductID
			{
				get
				{
					return this._ProductID;
				}
				set
				{
					if (this._ProductID != value)
					{
						this.OnProductIDChanging(value);
						this.SendPropertyChanging();
						this._ProductID = value;
						this.SendPropertyChanged("ProductID");
						this.OnProductIDChanged();
					}
					this.SendPropertySetterInvoked("ProductID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_DocumentID", DbType="Int NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
			public int DocumentID
			{
				get
				{
					return this._DocumentID;
				}
				set
				{
					if (this._DocumentID != value)
					{
						this.OnDocumentIDChanging(value);
						this.SendPropertyChanging();
						this._DocumentID = value;
						this.SendPropertyChanged("DocumentID");
						this.OnDocumentIDChanged();
					}
					this.SendPropertySetterInvoked("DocumentID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ModifiedDate", DbType="DateTime NOT NULL", CanBeNull=false)]
			public DateTime ModifiedDate
			{
				get
				{
					return this._ModifiedDate;
				}
				set
				{
					if (this._ModifiedDate != value)
					{
						this.OnModifiedDateChanging(value);
						this.SendPropertyChanging();
						this._ModifiedDate = value;
						this.SendPropertyChanged("ModifiedDate");
						this.OnModifiedDateChanged();
					}
					this.SendPropertySetterInvoked("ModifiedDate", value);
				}
			}
			
			#endregion Columns

			#region Associations
			/// <summary>
			/// Association [FK][Many]Production_ProductDocument.DocumentID --- [PK][One]Production_Document.DocumentID
			/// </summary>
			[AssociationAttribute(Name="FK_ProductDocument_Document_DocumentID", Storage="_Production_Document", ThisKey="DocumentID", OtherKey="DocumentID", IsUnique=false, IsForeignKey=true)]
			public Production_Document Production_Document
			{
				get
				{
					return this._Production_Document.Entity;
				}
				set
				{
					Production_Document previousValue = this._Production_Document.Entity;
					if ((previousValue != value) || (this._Production_Document.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._Production_Document.Entity = null;
							previousValue.Production_ProductDocumentList.Remove(this);
						}
						this._Production_Document.Entity = value;
						if (value != null)
						{
							value.Production_ProductDocumentList.Add(this);
							this._DocumentID = value.DocumentID;
						}
						else
						{
							this._DocumentID = default(int);
						}
						this.SendPropertyChanged("Production_Document");
					}
					this.SendPropertySetterInvoked("Production_Document", value);
				}
			}
			
			/// <summary>
			/// Association [FK][Many]Production_ProductDocument.ProductID --- [PK][One]Production_Product.ProductID
			/// </summary>
			[AssociationAttribute(Name="FK_ProductDocument_Product_ProductID", Storage="_Production_Product", ThisKey="ProductID", OtherKey="ProductID", IsUnique=false, IsForeignKey=true)]
			public Production_Product Production_Product
			{
				get
				{
					return this._Production_Product.Entity;
				}
				set
				{
					Production_Product previousValue = this._Production_Product.Entity;
					if ((previousValue != value) || (this._Production_Product.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._Production_Product.Entity = null;
							previousValue.Production_ProductDocumentList.Remove(this);
						}
						this._Production_Product.Entity = value;
						if (value != null)
						{
							value.Production_ProductDocumentList.Add(this);
							this._ProductID = value.ProductID;
						}
						else
						{
							this._ProductID = default(int);
						}
						this.SendPropertyChanged("Production_Product");
					}
					this.SendPropertySetterInvoked("Production_Product", value);
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
		#endregion Production.ProductDocument

		#region Production.ProductInventory
		[TableAttribute(Name="Production.ProductInventory")]
		public partial class Production_ProductInventory : EntityBase<Production_ProductInventory, AdventureWorksDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private int _ProductID;
			private System.Int16 _LocationID;
			private string _Shelf;
			private byte _Bin;
			private System.Int16 _Quantity;
			private System.Guid _rowguid;
			private DateTime _ModifiedDate;
			private EntityRef<Production_Location> _Production_Location;
			private EntityRef<Production_Product> _Production_Product;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnProductIDChanging(int value);
			partial void OnProductIDChanged();
			partial void OnLocationIDChanging(System.Int16 value);
			partial void OnLocationIDChanged();
			partial void OnShelfChanging(string value);
			partial void OnShelfChanged();
			partial void OnBinChanging(byte value);
			partial void OnBinChanged();
			partial void OnQuantityChanging(System.Int16 value);
			partial void OnQuantityChanged();
			partial void OnrowguidChanging(System.Guid value);
			partial void OnrowguidChanged();
			partial void OnModifiedDateChanging(DateTime value);
			partial void OnModifiedDateChanged();
			#endregion

			public Production_ProductInventory()
			{
				_Production_Location = default(EntityRef<Production_Location>);
				_Production_Product = default(EntityRef<Production_Product>);
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ProductID", DbType="Int NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
			public int ProductID
			{
				get
				{
					return this._ProductID;
				}
				set
				{
					if (this._ProductID != value)
					{
						this.OnProductIDChanging(value);
						this.SendPropertyChanging();
						this._ProductID = value;
						this.SendPropertyChanged("ProductID");
						this.OnProductIDChanged();
					}
					this.SendPropertySetterInvoked("ProductID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=SmallInt NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_LocationID", DbType="SmallInt NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
			public System.Int16 LocationID
			{
				get
				{
					return this._LocationID;
				}
				set
				{
					if (this._LocationID != value)
					{
						this.OnLocationIDChanging(value);
						this.SendPropertyChanging();
						this._LocationID = value;
						this.SendPropertyChanged("LocationID");
						this.OnLocationIDChanged();
					}
					this.SendPropertySetterInvoked("LocationID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(10) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_Shelf", DbType="NVarChar(10) NOT NULL", CanBeNull=false)]
			public string Shelf
			{
				get
				{
					return this._Shelf;
				}
				set
				{
					if (this._Shelf != value)
					{
						this.OnShelfChanging(value);
						this.SendPropertyChanging();
						this._Shelf = value;
						this.SendPropertyChanged("Shelf");
						this.OnShelfChanged();
					}
					this.SendPropertySetterInvoked("Shelf", value);
				}
			}
			
			/// <summary>
			/// Column DbType=TinyInt NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_Bin", DbType="TinyInt NOT NULL", CanBeNull=false)]
			public byte Bin
			{
				get
				{
					return this._Bin;
				}
				set
				{
					if (this._Bin != value)
					{
						this.OnBinChanging(value);
						this.SendPropertyChanging();
						this._Bin = value;
						this.SendPropertyChanged("Bin");
						this.OnBinChanged();
					}
					this.SendPropertySetterInvoked("Bin", value);
				}
			}
			
			/// <summary>
			/// Column DbType=SmallInt NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_Quantity", DbType="SmallInt NOT NULL", CanBeNull=false)]
			public System.Int16 Quantity
			{
				get
				{
					return this._Quantity;
				}
				set
				{
					if (this._Quantity != value)
					{
						this.OnQuantityChanging(value);
						this.SendPropertyChanging();
						this._Quantity = value;
						this.SendPropertyChanged("Quantity");
						this.OnQuantityChanged();
					}
					this.SendPropertySetterInvoked("Quantity", value);
				}
			}
			
			/// <summary>
			/// Column DbType=UniqueIdentifier NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_rowguid", DbType="UniqueIdentifier NOT NULL", CanBeNull=false)]
			public System.Guid rowguid
			{
				get
				{
					return this._rowguid;
				}
				set
				{
					if (this._rowguid != value)
					{
						this.OnrowguidChanging(value);
						this.SendPropertyChanging();
						this._rowguid = value;
						this.SendPropertyChanged("rowguid");
						this.OnrowguidChanged();
					}
					this.SendPropertySetterInvoked("rowguid", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ModifiedDate", DbType="DateTime NOT NULL", CanBeNull=false)]
			public DateTime ModifiedDate
			{
				get
				{
					return this._ModifiedDate;
				}
				set
				{
					if (this._ModifiedDate != value)
					{
						this.OnModifiedDateChanging(value);
						this.SendPropertyChanging();
						this._ModifiedDate = value;
						this.SendPropertyChanged("ModifiedDate");
						this.OnModifiedDateChanged();
					}
					this.SendPropertySetterInvoked("ModifiedDate", value);
				}
			}
			
			#endregion Columns

			#region Associations
			/// <summary>
			/// Association [FK][Many]Production_ProductInventory.LocationID --- [PK][One]Production_Location.LocationID
			/// </summary>
			[AssociationAttribute(Name="FK_ProductInventory_Location_LocationID", Storage="_Production_Location", ThisKey="LocationID", OtherKey="LocationID", IsUnique=false, IsForeignKey=true)]
			public Production_Location Production_Location
			{
				get
				{
					return this._Production_Location.Entity;
				}
				set
				{
					Production_Location previousValue = this._Production_Location.Entity;
					if ((previousValue != value) || (this._Production_Location.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._Production_Location.Entity = null;
							previousValue.Production_ProductInventoryList.Remove(this);
						}
						this._Production_Location.Entity = value;
						if (value != null)
						{
							value.Production_ProductInventoryList.Add(this);
							this._LocationID = value.LocationID;
						}
						else
						{
							this._LocationID = default(System.Int16);
						}
						this.SendPropertyChanged("Production_Location");
					}
					this.SendPropertySetterInvoked("Production_Location", value);
				}
			}
			
			/// <summary>
			/// Association [FK][Many]Production_ProductInventory.ProductID --- [PK][One]Production_Product.ProductID
			/// </summary>
			[AssociationAttribute(Name="FK_ProductInventory_Product_ProductID", Storage="_Production_Product", ThisKey="ProductID", OtherKey="ProductID", IsUnique=false, IsForeignKey=true)]
			public Production_Product Production_Product
			{
				get
				{
					return this._Production_Product.Entity;
				}
				set
				{
					Production_Product previousValue = this._Production_Product.Entity;
					if ((previousValue != value) || (this._Production_Product.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._Production_Product.Entity = null;
							previousValue.Production_ProductInventoryList.Remove(this);
						}
						this._Production_Product.Entity = value;
						if (value != null)
						{
							value.Production_ProductInventoryList.Add(this);
							this._ProductID = value.ProductID;
						}
						else
						{
							this._ProductID = default(int);
						}
						this.SendPropertyChanged("Production_Product");
					}
					this.SendPropertySetterInvoked("Production_Product", value);
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
		#endregion Production.ProductInventory

		#region Production.ProductListPriceHistory
		[TableAttribute(Name="Production.ProductListPriceHistory")]
		public partial class Production_ProductListPriceHistory : EntityBase<Production_ProductListPriceHistory, AdventureWorksDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private int _ProductID;
			private DateTime _StartDate;
			private DateTime? _EndDate;
			private decimal _ListPrice;
			private DateTime _ModifiedDate;
			private EntityRef<Production_Product> _Production_Product;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnProductIDChanging(int value);
			partial void OnProductIDChanged();
			partial void OnStartDateChanging(DateTime value);
			partial void OnStartDateChanged();
			partial void OnEndDateChanging(DateTime? value);
			partial void OnEndDateChanged();
			partial void OnListPriceChanging(decimal value);
			partial void OnListPriceChanged();
			partial void OnModifiedDateChanging(DateTime value);
			partial void OnModifiedDateChanged();
			#endregion

			public Production_ProductListPriceHistory()
			{
				_Production_Product = default(EntityRef<Production_Product>);
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ProductID", DbType="Int NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
			public int ProductID
			{
				get
				{
					return this._ProductID;
				}
				set
				{
					if (this._ProductID != value)
					{
						this.OnProductIDChanging(value);
						this.SendPropertyChanging();
						this._ProductID = value;
						this.SendPropertyChanged("ProductID");
						this.OnProductIDChanged();
					}
					this.SendPropertySetterInvoked("ProductID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_StartDate", DbType="DateTime NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
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
						this.OnStartDateChanging(value);
						this.SendPropertyChanging();
						this._StartDate = value;
						this.SendPropertyChanged("StartDate");
						this.OnStartDateChanged();
					}
					this.SendPropertySetterInvoked("StartDate", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime
			/// </summary>
			[ColumnAttribute(Storage="_EndDate", DbType="DateTime", CanBeNull=true)]
			public DateTime? EndDate
			{
				get
				{
					return this._EndDate;
				}
				set
				{
					if (this._EndDate != value)
					{
						this.OnEndDateChanging(value);
						this.SendPropertyChanging();
						this._EndDate = value;
						this.SendPropertyChanged("EndDate");
						this.OnEndDateChanged();
					}
					this.SendPropertySetterInvoked("EndDate", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Money NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ListPrice", DbType="Money NOT NULL", CanBeNull=false)]
			public decimal ListPrice
			{
				get
				{
					return this._ListPrice;
				}
				set
				{
					if (this._ListPrice != value)
					{
						this.OnListPriceChanging(value);
						this.SendPropertyChanging();
						this._ListPrice = value;
						this.SendPropertyChanged("ListPrice");
						this.OnListPriceChanged();
					}
					this.SendPropertySetterInvoked("ListPrice", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ModifiedDate", DbType="DateTime NOT NULL", CanBeNull=false)]
			public DateTime ModifiedDate
			{
				get
				{
					return this._ModifiedDate;
				}
				set
				{
					if (this._ModifiedDate != value)
					{
						this.OnModifiedDateChanging(value);
						this.SendPropertyChanging();
						this._ModifiedDate = value;
						this.SendPropertyChanged("ModifiedDate");
						this.OnModifiedDateChanged();
					}
					this.SendPropertySetterInvoked("ModifiedDate", value);
				}
			}
			
			#endregion Columns

			#region Associations
			/// <summary>
			/// Association [FK][Many]Production_ProductListPriceHistory.ProductID --- [PK][One]Production_Product.ProductID
			/// </summary>
			[AssociationAttribute(Name="FK_ProductListPriceHistory_Product_ProductID", Storage="_Production_Product", ThisKey="ProductID", OtherKey="ProductID", IsUnique=false, IsForeignKey=true)]
			public Production_Product Production_Product
			{
				get
				{
					return this._Production_Product.Entity;
				}
				set
				{
					Production_Product previousValue = this._Production_Product.Entity;
					if ((previousValue != value) || (this._Production_Product.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._Production_Product.Entity = null;
							previousValue.Production_ProductListPriceHistoryList.Remove(this);
						}
						this._Production_Product.Entity = value;
						if (value != null)
						{
							value.Production_ProductListPriceHistoryList.Add(this);
							this._ProductID = value.ProductID;
						}
						else
						{
							this._ProductID = default(int);
						}
						this.SendPropertyChanged("Production_Product");
					}
					this.SendPropertySetterInvoked("Production_Product", value);
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
		#endregion Production.ProductListPriceHistory

		#region Production.ProductModel
		[TableAttribute(Name="Production.ProductModel")]
		public partial class Production_ProductModel : EntityBase<Production_ProductModel, AdventureWorksDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private int _ProductModelID;
			private string _Name;
			private System.Xml.Linq.XElement _CatalogDescription;
			private System.Xml.Linq.XElement _Instructions;
			private System.Guid _rowguid;
			private DateTime _ModifiedDate;
			private EntitySet<Production_Product> _Production_ProductList;
			private EntitySet<Production_ProductModelIllustration> _Production_ProductModelIllustrationList;
			private EntitySet<Production_ProductModelProductDescriptionCulture> _Production_ProductModelProductDescriptionCultureList;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnProductModelIDChanging(int value);
			partial void OnProductModelIDChanged();
			partial void OnNameChanging(string value);
			partial void OnNameChanged();
			partial void OnCatalogDescriptionChanging(System.Xml.Linq.XElement value);
			partial void OnCatalogDescriptionChanged();
			partial void OnInstructionsChanging(System.Xml.Linq.XElement value);
			partial void OnInstructionsChanged();
			partial void OnrowguidChanging(System.Guid value);
			partial void OnrowguidChanged();
			partial void OnModifiedDateChanging(DateTime value);
			partial void OnModifiedDateChanged();
			#endregion

			public Production_ProductModel()
			{
				_Production_ProductList = new EntitySet<Production_Product>(
					new Action<Production_Product>(item=>{this.SendPropertyChanging(); item.Production_ProductModel=this;}), 
					new Action<Production_Product>(item=>{this.SendPropertyChanging(); item.Production_ProductModel=null;}));
				_Production_ProductModelIllustrationList = new EntitySet<Production_ProductModelIllustration>(
					new Action<Production_ProductModelIllustration>(item=>{this.SendPropertyChanging(); item.Production_ProductModel=this;}), 
					new Action<Production_ProductModelIllustration>(item=>{this.SendPropertyChanging(); item.Production_ProductModel=null;}));
				_Production_ProductModelProductDescriptionCultureList = new EntitySet<Production_ProductModelProductDescriptionCulture>(
					new Action<Production_ProductModelProductDescriptionCulture>(item=>{this.SendPropertyChanging(); item.Production_ProductModel=this;}), 
					new Action<Production_ProductModelProductDescriptionCulture>(item=>{this.SendPropertyChanging(); item.Production_ProductModel=null;}));
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=Int NOT NULL IDENTITY
			/// </summary>
			[ColumnAttribute(Storage="_ProductModelID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", CanBeNull=false, IsPrimaryKey=true, IsDbGenerated=true)]
			public int ProductModelID
			{
				get
				{
					return this._ProductModelID;
				}
				set
				{
					if (this._ProductModelID != value)
					{
						this.OnProductModelIDChanging(value);
						this.SendPropertyChanging();
						this._ProductModelID = value;
						this.SendPropertyChanged("ProductModelID");
						this.OnProductModelIDChanged();
					}
					this.SendPropertySetterInvoked("ProductModelID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(50) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_Name", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
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
			/// Column DbType=Xml
			/// </summary>
			[ColumnAttribute(Storage="_CatalogDescription", DbType="Xml", CanBeNull=true)]
			public System.Xml.Linq.XElement CatalogDescription
			{
				get
				{
					return this._CatalogDescription;
				}
				set
				{
					if (this._CatalogDescription != value)
					{
						this.OnCatalogDescriptionChanging(value);
						this.SendPropertyChanging();
						this._CatalogDescription = value;
						this.SendPropertyChanged("CatalogDescription");
						this.OnCatalogDescriptionChanged();
					}
					this.SendPropertySetterInvoked("CatalogDescription", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Xml
			/// </summary>
			[ColumnAttribute(Storage="_Instructions", DbType="Xml", CanBeNull=true)]
			public System.Xml.Linq.XElement Instructions
			{
				get
				{
					return this._Instructions;
				}
				set
				{
					if (this._Instructions != value)
					{
						this.OnInstructionsChanging(value);
						this.SendPropertyChanging();
						this._Instructions = value;
						this.SendPropertyChanged("Instructions");
						this.OnInstructionsChanged();
					}
					this.SendPropertySetterInvoked("Instructions", value);
				}
			}
			
			/// <summary>
			/// Column DbType=UniqueIdentifier NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_rowguid", DbType="UniqueIdentifier NOT NULL", CanBeNull=false)]
			public System.Guid rowguid
			{
				get
				{
					return this._rowguid;
				}
				set
				{
					if (this._rowguid != value)
					{
						this.OnrowguidChanging(value);
						this.SendPropertyChanging();
						this._rowguid = value;
						this.SendPropertyChanged("rowguid");
						this.OnrowguidChanged();
					}
					this.SendPropertySetterInvoked("rowguid", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ModifiedDate", DbType="DateTime NOT NULL", CanBeNull=false)]
			public DateTime ModifiedDate
			{
				get
				{
					return this._ModifiedDate;
				}
				set
				{
					if (this._ModifiedDate != value)
					{
						this.OnModifiedDateChanging(value);
						this.SendPropertyChanging();
						this._ModifiedDate = value;
						this.SendPropertyChanged("ModifiedDate");
						this.OnModifiedDateChanged();
					}
					this.SendPropertySetterInvoked("ModifiedDate", value);
				}
			}
			
			#endregion Columns

			#region Associations
			/// <summary>
			/// Association [PK][One]Production_ProductModel.ProductModelID --- [FK][Many]Production_Product.ProductModelID
			/// </summary>
			[AssociationAttribute(Name="FK_Product_ProductModel_ProductModelID", Storage="_Production_ProductList", ThisKey="ProductModelID", OtherKey="ProductModelID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<Production_Product> Production_ProductList
			{
				get { return this._Production_ProductList; }
				set { this._Production_ProductList.Assign(value); }
			}
			
			/// <summary>
			/// Association [PK][One]Production_ProductModel.ProductModelID --- [FK][Many]Production_ProductModelIllustration.ProductModelID
			/// </summary>
			[AssociationAttribute(Name="FK_ProductModelIllustration_ProductModel_ProductModelID", Storage="_Production_ProductModelIllustrationList", ThisKey="ProductModelID", OtherKey="ProductModelID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<Production_ProductModelIllustration> Production_ProductModelIllustrationList
			{
				get { return this._Production_ProductModelIllustrationList; }
				set { this._Production_ProductModelIllustrationList.Assign(value); }
			}
			
			/// <summary>
			/// Association [PK][One]Production_ProductModel.ProductModelID --- [FK][Many]Production_ProductModelProductDescriptionCulture.ProductModelID
			/// </summary>
			[AssociationAttribute(Name="FK_ProductModelProductDescriptionCulture_ProductModel_ProductModelID", Storage="_Production_ProductModelProductDescriptionCultureList", ThisKey="ProductModelID", OtherKey="ProductModelID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<Production_ProductModelProductDescriptionCulture> Production_ProductModelProductDescriptionCultureList
			{
				get { return this._Production_ProductModelProductDescriptionCultureList; }
				set { this._Production_ProductModelProductDescriptionCultureList.Assign(value); }
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
		#endregion Production.ProductModel

		#region Production.ProductModelIllustration
		[TableAttribute(Name="Production.ProductModelIllustration")]
		public partial class Production_ProductModelIllustration : EntityBase<Production_ProductModelIllustration, AdventureWorksDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private int _ProductModelID;
			private int _IllustrationID;
			private DateTime _ModifiedDate;
			private EntityRef<Production_Illustration> _Production_Illustration;
			private EntityRef<Production_ProductModel> _Production_ProductModel;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnProductModelIDChanging(int value);
			partial void OnProductModelIDChanged();
			partial void OnIllustrationIDChanging(int value);
			partial void OnIllustrationIDChanged();
			partial void OnModifiedDateChanging(DateTime value);
			partial void OnModifiedDateChanged();
			#endregion

			public Production_ProductModelIllustration()
			{
				_Production_Illustration = default(EntityRef<Production_Illustration>);
				_Production_ProductModel = default(EntityRef<Production_ProductModel>);
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ProductModelID", DbType="Int NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
			public int ProductModelID
			{
				get
				{
					return this._ProductModelID;
				}
				set
				{
					if (this._ProductModelID != value)
					{
						this.OnProductModelIDChanging(value);
						this.SendPropertyChanging();
						this._ProductModelID = value;
						this.SendPropertyChanged("ProductModelID");
						this.OnProductModelIDChanged();
					}
					this.SendPropertySetterInvoked("ProductModelID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_IllustrationID", DbType="Int NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
			public int IllustrationID
			{
				get
				{
					return this._IllustrationID;
				}
				set
				{
					if (this._IllustrationID != value)
					{
						this.OnIllustrationIDChanging(value);
						this.SendPropertyChanging();
						this._IllustrationID = value;
						this.SendPropertyChanged("IllustrationID");
						this.OnIllustrationIDChanged();
					}
					this.SendPropertySetterInvoked("IllustrationID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ModifiedDate", DbType="DateTime NOT NULL", CanBeNull=false)]
			public DateTime ModifiedDate
			{
				get
				{
					return this._ModifiedDate;
				}
				set
				{
					if (this._ModifiedDate != value)
					{
						this.OnModifiedDateChanging(value);
						this.SendPropertyChanging();
						this._ModifiedDate = value;
						this.SendPropertyChanged("ModifiedDate");
						this.OnModifiedDateChanged();
					}
					this.SendPropertySetterInvoked("ModifiedDate", value);
				}
			}
			
			#endregion Columns

			#region Associations
			/// <summary>
			/// Association [FK][Many]Production_ProductModelIllustration.IllustrationID --- [PK][One]Production_Illustration.IllustrationID
			/// </summary>
			[AssociationAttribute(Name="FK_ProductModelIllustration_Illustration_IllustrationID", Storage="_Production_Illustration", ThisKey="IllustrationID", OtherKey="IllustrationID", IsUnique=false, IsForeignKey=true)]
			public Production_Illustration Production_Illustration
			{
				get
				{
					return this._Production_Illustration.Entity;
				}
				set
				{
					Production_Illustration previousValue = this._Production_Illustration.Entity;
					if ((previousValue != value) || (this._Production_Illustration.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._Production_Illustration.Entity = null;
							previousValue.Production_ProductModelIllustrationList.Remove(this);
						}
						this._Production_Illustration.Entity = value;
						if (value != null)
						{
							value.Production_ProductModelIllustrationList.Add(this);
							this._IllustrationID = value.IllustrationID;
						}
						else
						{
							this._IllustrationID = default(int);
						}
						this.SendPropertyChanged("Production_Illustration");
					}
					this.SendPropertySetterInvoked("Production_Illustration", value);
				}
			}
			
			/// <summary>
			/// Association [FK][Many]Production_ProductModelIllustration.ProductModelID --- [PK][One]Production_ProductModel.ProductModelID
			/// </summary>
			[AssociationAttribute(Name="FK_ProductModelIllustration_ProductModel_ProductModelID", Storage="_Production_ProductModel", ThisKey="ProductModelID", OtherKey="ProductModelID", IsUnique=false, IsForeignKey=true)]
			public Production_ProductModel Production_ProductModel
			{
				get
				{
					return this._Production_ProductModel.Entity;
				}
				set
				{
					Production_ProductModel previousValue = this._Production_ProductModel.Entity;
					if ((previousValue != value) || (this._Production_ProductModel.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._Production_ProductModel.Entity = null;
							previousValue.Production_ProductModelIllustrationList.Remove(this);
						}
						this._Production_ProductModel.Entity = value;
						if (value != null)
						{
							value.Production_ProductModelIllustrationList.Add(this);
							this._ProductModelID = value.ProductModelID;
						}
						else
						{
							this._ProductModelID = default(int);
						}
						this.SendPropertyChanged("Production_ProductModel");
					}
					this.SendPropertySetterInvoked("Production_ProductModel", value);
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
		#endregion Production.ProductModelIllustration

		#region Production.ProductModelProductDescriptionCulture
		[TableAttribute(Name="Production.ProductModelProductDescriptionCulture")]
		public partial class Production_ProductModelProductDescriptionCulture : EntityBase<Production_ProductModelProductDescriptionCulture, AdventureWorksDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private int _ProductModelID;
			private int _ProductDescriptionID;
			private string _CultureID;
			private DateTime _ModifiedDate;
			private EntityRef<Production_Culture> _Production_Culture;
			private EntityRef<Production_ProductDescription> _Production_ProductDescription;
			private EntityRef<Production_ProductModel> _Production_ProductModel;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnProductModelIDChanging(int value);
			partial void OnProductModelIDChanged();
			partial void OnProductDescriptionIDChanging(int value);
			partial void OnProductDescriptionIDChanged();
			partial void OnCultureIDChanging(string value);
			partial void OnCultureIDChanged();
			partial void OnModifiedDateChanging(DateTime value);
			partial void OnModifiedDateChanged();
			#endregion

			public Production_ProductModelProductDescriptionCulture()
			{
				_Production_Culture = default(EntityRef<Production_Culture>);
				_Production_ProductDescription = default(EntityRef<Production_ProductDescription>);
				_Production_ProductModel = default(EntityRef<Production_ProductModel>);
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ProductModelID", DbType="Int NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
			public int ProductModelID
			{
				get
				{
					return this._ProductModelID;
				}
				set
				{
					if (this._ProductModelID != value)
					{
						this.OnProductModelIDChanging(value);
						this.SendPropertyChanging();
						this._ProductModelID = value;
						this.SendPropertyChanged("ProductModelID");
						this.OnProductModelIDChanged();
					}
					this.SendPropertySetterInvoked("ProductModelID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ProductDescriptionID", DbType="Int NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
			public int ProductDescriptionID
			{
				get
				{
					return this._ProductDescriptionID;
				}
				set
				{
					if (this._ProductDescriptionID != value)
					{
						this.OnProductDescriptionIDChanging(value);
						this.SendPropertyChanging();
						this._ProductDescriptionID = value;
						this.SendPropertyChanged("ProductDescriptionID");
						this.OnProductDescriptionIDChanged();
					}
					this.SendPropertySetterInvoked("ProductDescriptionID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NChar(6) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_CultureID", DbType="NChar(6) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
			public string CultureID
			{
				get
				{
					return this._CultureID;
				}
				set
				{
					if (this._CultureID != value)
					{
						this.OnCultureIDChanging(value);
						this.SendPropertyChanging();
						this._CultureID = value;
						this.SendPropertyChanged("CultureID");
						this.OnCultureIDChanged();
					}
					this.SendPropertySetterInvoked("CultureID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ModifiedDate", DbType="DateTime NOT NULL", CanBeNull=false)]
			public DateTime ModifiedDate
			{
				get
				{
					return this._ModifiedDate;
				}
				set
				{
					if (this._ModifiedDate != value)
					{
						this.OnModifiedDateChanging(value);
						this.SendPropertyChanging();
						this._ModifiedDate = value;
						this.SendPropertyChanged("ModifiedDate");
						this.OnModifiedDateChanged();
					}
					this.SendPropertySetterInvoked("ModifiedDate", value);
				}
			}
			
			#endregion Columns

			#region Associations
			/// <summary>
			/// Association [FK][Many]Production_ProductModelProductDescriptionCulture.CultureID --- [PK][One]Production_Culture.CultureID
			/// </summary>
			[AssociationAttribute(Name="FK_ProductModelProductDescriptionCulture_Culture_CultureID", Storage="_Production_Culture", ThisKey="CultureID", OtherKey="CultureID", IsUnique=false, IsForeignKey=true)]
			public Production_Culture Production_Culture
			{
				get
				{
					return this._Production_Culture.Entity;
				}
				set
				{
					Production_Culture previousValue = this._Production_Culture.Entity;
					if ((previousValue != value) || (this._Production_Culture.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._Production_Culture.Entity = null;
							previousValue.Production_ProductModelProductDescriptionCultureList.Remove(this);
						}
						this._Production_Culture.Entity = value;
						if (value != null)
						{
							value.Production_ProductModelProductDescriptionCultureList.Add(this);
							this._CultureID = value.CultureID;
						}
						else
						{
							this._CultureID = default(string);
						}
						this.SendPropertyChanged("Production_Culture");
					}
					this.SendPropertySetterInvoked("Production_Culture", value);
				}
			}
			
			/// <summary>
			/// Association [FK][Many]Production_ProductModelProductDescriptionCulture.ProductDescriptionID --- [PK][One]Production_ProductDescription.ProductDescriptionID
			/// </summary>
			[AssociationAttribute(Name="FK_ProductModelProductDescriptionCulture_ProductDescription_ProductDescriptionID", Storage="_Production_ProductDescription", ThisKey="ProductDescriptionID", OtherKey="ProductDescriptionID", IsUnique=false, IsForeignKey=true)]
			public Production_ProductDescription Production_ProductDescription
			{
				get
				{
					return this._Production_ProductDescription.Entity;
				}
				set
				{
					Production_ProductDescription previousValue = this._Production_ProductDescription.Entity;
					if ((previousValue != value) || (this._Production_ProductDescription.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._Production_ProductDescription.Entity = null;
							previousValue.Production_ProductModelProductDescriptionCultureList.Remove(this);
						}
						this._Production_ProductDescription.Entity = value;
						if (value != null)
						{
							value.Production_ProductModelProductDescriptionCultureList.Add(this);
							this._ProductDescriptionID = value.ProductDescriptionID;
						}
						else
						{
							this._ProductDescriptionID = default(int);
						}
						this.SendPropertyChanged("Production_ProductDescription");
					}
					this.SendPropertySetterInvoked("Production_ProductDescription", value);
				}
			}
			
			/// <summary>
			/// Association [FK][Many]Production_ProductModelProductDescriptionCulture.ProductModelID --- [PK][One]Production_ProductModel.ProductModelID
			/// </summary>
			[AssociationAttribute(Name="FK_ProductModelProductDescriptionCulture_ProductModel_ProductModelID", Storage="_Production_ProductModel", ThisKey="ProductModelID", OtherKey="ProductModelID", IsUnique=false, IsForeignKey=true)]
			public Production_ProductModel Production_ProductModel
			{
				get
				{
					return this._Production_ProductModel.Entity;
				}
				set
				{
					Production_ProductModel previousValue = this._Production_ProductModel.Entity;
					if ((previousValue != value) || (this._Production_ProductModel.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._Production_ProductModel.Entity = null;
							previousValue.Production_ProductModelProductDescriptionCultureList.Remove(this);
						}
						this._Production_ProductModel.Entity = value;
						if (value != null)
						{
							value.Production_ProductModelProductDescriptionCultureList.Add(this);
							this._ProductModelID = value.ProductModelID;
						}
						else
						{
							this._ProductModelID = default(int);
						}
						this.SendPropertyChanged("Production_ProductModel");
					}
					this.SendPropertySetterInvoked("Production_ProductModel", value);
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
		#endregion Production.ProductModelProductDescriptionCulture

		#region Production.ProductPhoto
		[TableAttribute(Name="Production.ProductPhoto")]
		public partial class Production_ProductPhoto : EntityBase<Production_ProductPhoto, AdventureWorksDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private int _ProductPhotoID;
			private byte[] _ThumbNailPhoto;
			private string _ThumbnailPhotoFileName;
			private byte[] _LargePhoto;
			private string _LargePhotoFileName;
			private DateTime _ModifiedDate;
			private EntitySet<Production_ProductProductPhoto> _Production_ProductProductPhotoList;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnProductPhotoIDChanging(int value);
			partial void OnProductPhotoIDChanged();
			partial void OnThumbNailPhotoChanging(byte[] value);
			partial void OnThumbNailPhotoChanged();
			partial void OnThumbnailPhotoFileNameChanging(string value);
			partial void OnThumbnailPhotoFileNameChanged();
			partial void OnLargePhotoChanging(byte[] value);
			partial void OnLargePhotoChanged();
			partial void OnLargePhotoFileNameChanging(string value);
			partial void OnLargePhotoFileNameChanged();
			partial void OnModifiedDateChanging(DateTime value);
			partial void OnModifiedDateChanged();
			#endregion

			public Production_ProductPhoto()
			{
				_Production_ProductProductPhotoList = new EntitySet<Production_ProductProductPhoto>(
					new Action<Production_ProductProductPhoto>(item=>{this.SendPropertyChanging(); item.Production_ProductPhoto=this;}), 
					new Action<Production_ProductProductPhoto>(item=>{this.SendPropertyChanging(); item.Production_ProductPhoto=null;}));
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=Int NOT NULL IDENTITY
			/// </summary>
			[ColumnAttribute(Storage="_ProductPhotoID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", CanBeNull=false, IsPrimaryKey=true, IsDbGenerated=true)]
			public int ProductPhotoID
			{
				get
				{
					return this._ProductPhotoID;
				}
				set
				{
					if (this._ProductPhotoID != value)
					{
						this.OnProductPhotoIDChanging(value);
						this.SendPropertyChanging();
						this._ProductPhotoID = value;
						this.SendPropertyChanged("ProductPhotoID");
						this.OnProductPhotoIDChanged();
					}
					this.SendPropertySetterInvoked("ProductPhotoID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=VarBinary(MAX)
			/// </summary>
			[ColumnAttribute(Storage="_ThumbNailPhoto", DbType="VarBinary(MAX)", CanBeNull=true)]
			public byte[] ThumbNailPhoto
			{
				get
				{
					return this._ThumbNailPhoto;
				}
				set
				{
					if (this._ThumbNailPhoto != value)
					{
						this.OnThumbNailPhotoChanging(value);
						this.SendPropertyChanging();
						this._ThumbNailPhoto = value;
						this.SendPropertyChanged("ThumbNailPhoto");
						this.OnThumbNailPhotoChanged();
					}
					this.SendPropertySetterInvoked("ThumbNailPhoto", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(50)
			/// </summary>
			[ColumnAttribute(Storage="_ThumbnailPhotoFileName", DbType="NVarChar(50)", CanBeNull=true)]
			public string ThumbnailPhotoFileName
			{
				get
				{
					return this._ThumbnailPhotoFileName;
				}
				set
				{
					if (this._ThumbnailPhotoFileName != value)
					{
						this.OnThumbnailPhotoFileNameChanging(value);
						this.SendPropertyChanging();
						this._ThumbnailPhotoFileName = value;
						this.SendPropertyChanged("ThumbnailPhotoFileName");
						this.OnThumbnailPhotoFileNameChanged();
					}
					this.SendPropertySetterInvoked("ThumbnailPhotoFileName", value);
				}
			}
			
			/// <summary>
			/// Column DbType=VarBinary(MAX)
			/// </summary>
			[ColumnAttribute(Storage="_LargePhoto", DbType="VarBinary(MAX)", CanBeNull=true)]
			public byte[] LargePhoto
			{
				get
				{
					return this._LargePhoto;
				}
				set
				{
					if (this._LargePhoto != value)
					{
						this.OnLargePhotoChanging(value);
						this.SendPropertyChanging();
						this._LargePhoto = value;
						this.SendPropertyChanged("LargePhoto");
						this.OnLargePhotoChanged();
					}
					this.SendPropertySetterInvoked("LargePhoto", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(50)
			/// </summary>
			[ColumnAttribute(Storage="_LargePhotoFileName", DbType="NVarChar(50)", CanBeNull=true)]
			public string LargePhotoFileName
			{
				get
				{
					return this._LargePhotoFileName;
				}
				set
				{
					if (this._LargePhotoFileName != value)
					{
						this.OnLargePhotoFileNameChanging(value);
						this.SendPropertyChanging();
						this._LargePhotoFileName = value;
						this.SendPropertyChanged("LargePhotoFileName");
						this.OnLargePhotoFileNameChanged();
					}
					this.SendPropertySetterInvoked("LargePhotoFileName", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ModifiedDate", DbType="DateTime NOT NULL", CanBeNull=false)]
			public DateTime ModifiedDate
			{
				get
				{
					return this._ModifiedDate;
				}
				set
				{
					if (this._ModifiedDate != value)
					{
						this.OnModifiedDateChanging(value);
						this.SendPropertyChanging();
						this._ModifiedDate = value;
						this.SendPropertyChanged("ModifiedDate");
						this.OnModifiedDateChanged();
					}
					this.SendPropertySetterInvoked("ModifiedDate", value);
				}
			}
			
			#endregion Columns

			#region Associations
			/// <summary>
			/// Association [PK][One]Production_ProductPhoto.ProductPhotoID --- [FK][Many]Production_ProductProductPhoto.ProductPhotoID
			/// </summary>
			[AssociationAttribute(Name="FK_ProductProductPhoto_ProductPhoto_ProductPhotoID", Storage="_Production_ProductProductPhotoList", ThisKey="ProductPhotoID", OtherKey="ProductPhotoID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<Production_ProductProductPhoto> Production_ProductProductPhotoList
			{
				get { return this._Production_ProductProductPhotoList; }
				set { this._Production_ProductProductPhotoList.Assign(value); }
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
		#endregion Production.ProductPhoto

		#region Production.ProductProductPhoto
		[TableAttribute(Name="Production.ProductProductPhoto")]
		public partial class Production_ProductProductPhoto : EntityBase<Production_ProductProductPhoto, AdventureWorksDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private int _ProductID;
			private int _ProductPhotoID;
			private bool _Primary;
			private DateTime _ModifiedDate;
			private EntityRef<Production_Product> _Production_Product;
			private EntityRef<Production_ProductPhoto> _Production_ProductPhoto;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnProductIDChanging(int value);
			partial void OnProductIDChanged();
			partial void OnProductPhotoIDChanging(int value);
			partial void OnProductPhotoIDChanged();
			partial void OnPrimaryChanging(bool value);
			partial void OnPrimaryChanged();
			partial void OnModifiedDateChanging(DateTime value);
			partial void OnModifiedDateChanged();
			#endregion

			public Production_ProductProductPhoto()
			{
				_Production_Product = default(EntityRef<Production_Product>);
				_Production_ProductPhoto = default(EntityRef<Production_ProductPhoto>);
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ProductID", DbType="Int NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
			public int ProductID
			{
				get
				{
					return this._ProductID;
				}
				set
				{
					if (this._ProductID != value)
					{
						this.OnProductIDChanging(value);
						this.SendPropertyChanging();
						this._ProductID = value;
						this.SendPropertyChanged("ProductID");
						this.OnProductIDChanged();
					}
					this.SendPropertySetterInvoked("ProductID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ProductPhotoID", DbType="Int NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
			public int ProductPhotoID
			{
				get
				{
					return this._ProductPhotoID;
				}
				set
				{
					if (this._ProductPhotoID != value)
					{
						this.OnProductPhotoIDChanging(value);
						this.SendPropertyChanging();
						this._ProductPhotoID = value;
						this.SendPropertyChanged("ProductPhotoID");
						this.OnProductPhotoIDChanged();
					}
					this.SendPropertySetterInvoked("ProductPhotoID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Bit NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_Primary", DbType="Bit NOT NULL", CanBeNull=false)]
			public bool Primary
			{
				get
				{
					return this._Primary;
				}
				set
				{
					if (this._Primary != value)
					{
						this.OnPrimaryChanging(value);
						this.SendPropertyChanging();
						this._Primary = value;
						this.SendPropertyChanged("Primary");
						this.OnPrimaryChanged();
					}
					this.SendPropertySetterInvoked("Primary", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ModifiedDate", DbType="DateTime NOT NULL", CanBeNull=false)]
			public DateTime ModifiedDate
			{
				get
				{
					return this._ModifiedDate;
				}
				set
				{
					if (this._ModifiedDate != value)
					{
						this.OnModifiedDateChanging(value);
						this.SendPropertyChanging();
						this._ModifiedDate = value;
						this.SendPropertyChanged("ModifiedDate");
						this.OnModifiedDateChanged();
					}
					this.SendPropertySetterInvoked("ModifiedDate", value);
				}
			}
			
			#endregion Columns

			#region Associations
			/// <summary>
			/// Association [FK][Many]Production_ProductProductPhoto.ProductID --- [PK][One]Production_Product.ProductID
			/// </summary>
			[AssociationAttribute(Name="FK_ProductProductPhoto_Product_ProductID", Storage="_Production_Product", ThisKey="ProductID", OtherKey="ProductID", IsUnique=false, IsForeignKey=true)]
			public Production_Product Production_Product
			{
				get
				{
					return this._Production_Product.Entity;
				}
				set
				{
					Production_Product previousValue = this._Production_Product.Entity;
					if ((previousValue != value) || (this._Production_Product.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._Production_Product.Entity = null;
							previousValue.Production_ProductProductPhotoList.Remove(this);
						}
						this._Production_Product.Entity = value;
						if (value != null)
						{
							value.Production_ProductProductPhotoList.Add(this);
							this._ProductID = value.ProductID;
						}
						else
						{
							this._ProductID = default(int);
						}
						this.SendPropertyChanged("Production_Product");
					}
					this.SendPropertySetterInvoked("Production_Product", value);
				}
			}
			
			/// <summary>
			/// Association [FK][Many]Production_ProductProductPhoto.ProductPhotoID --- [PK][One]Production_ProductPhoto.ProductPhotoID
			/// </summary>
			[AssociationAttribute(Name="FK_ProductProductPhoto_ProductPhoto_ProductPhotoID", Storage="_Production_ProductPhoto", ThisKey="ProductPhotoID", OtherKey="ProductPhotoID", IsUnique=false, IsForeignKey=true)]
			public Production_ProductPhoto Production_ProductPhoto
			{
				get
				{
					return this._Production_ProductPhoto.Entity;
				}
				set
				{
					Production_ProductPhoto previousValue = this._Production_ProductPhoto.Entity;
					if ((previousValue != value) || (this._Production_ProductPhoto.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._Production_ProductPhoto.Entity = null;
							previousValue.Production_ProductProductPhotoList.Remove(this);
						}
						this._Production_ProductPhoto.Entity = value;
						if (value != null)
						{
							value.Production_ProductProductPhotoList.Add(this);
							this._ProductPhotoID = value.ProductPhotoID;
						}
						else
						{
							this._ProductPhotoID = default(int);
						}
						this.SendPropertyChanged("Production_ProductPhoto");
					}
					this.SendPropertySetterInvoked("Production_ProductPhoto", value);
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
		#endregion Production.ProductProductPhoto

		#region Production.ProductReview
		[TableAttribute(Name="Production.ProductReview")]
		public partial class Production_ProductReview : EntityBase<Production_ProductReview, AdventureWorksDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private int _ProductReviewID;
			private int _ProductID;
			private string _ReviewerName;
			private DateTime _ReviewDate;
			private string _EmailAddress;
			private int _Rating;
			private string _Comments;
			private DateTime _ModifiedDate;
			private EntityRef<Production_Product> _Production_Product;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnProductReviewIDChanging(int value);
			partial void OnProductReviewIDChanged();
			partial void OnProductIDChanging(int value);
			partial void OnProductIDChanged();
			partial void OnReviewerNameChanging(string value);
			partial void OnReviewerNameChanged();
			partial void OnReviewDateChanging(DateTime value);
			partial void OnReviewDateChanged();
			partial void OnEmailAddressChanging(string value);
			partial void OnEmailAddressChanged();
			partial void OnRatingChanging(int value);
			partial void OnRatingChanged();
			partial void OnCommentsChanging(string value);
			partial void OnCommentsChanged();
			partial void OnModifiedDateChanging(DateTime value);
			partial void OnModifiedDateChanged();
			#endregion

			public Production_ProductReview()
			{
				_Production_Product = default(EntityRef<Production_Product>);
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=Int NOT NULL IDENTITY
			/// </summary>
			[ColumnAttribute(Storage="_ProductReviewID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", CanBeNull=false, IsPrimaryKey=true, IsDbGenerated=true)]
			public int ProductReviewID
			{
				get
				{
					return this._ProductReviewID;
				}
				set
				{
					if (this._ProductReviewID != value)
					{
						this.OnProductReviewIDChanging(value);
						this.SendPropertyChanging();
						this._ProductReviewID = value;
						this.SendPropertyChanged("ProductReviewID");
						this.OnProductReviewIDChanged();
					}
					this.SendPropertySetterInvoked("ProductReviewID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ProductID", DbType="Int NOT NULL", CanBeNull=false)]
			public int ProductID
			{
				get
				{
					return this._ProductID;
				}
				set
				{
					if (this._ProductID != value)
					{
						this.OnProductIDChanging(value);
						this.SendPropertyChanging();
						this._ProductID = value;
						this.SendPropertyChanged("ProductID");
						this.OnProductIDChanged();
					}
					this.SendPropertySetterInvoked("ProductID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(50) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ReviewerName", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
			public string ReviewerName
			{
				get
				{
					return this._ReviewerName;
				}
				set
				{
					if (this._ReviewerName != value)
					{
						this.OnReviewerNameChanging(value);
						this.SendPropertyChanging();
						this._ReviewerName = value;
						this.SendPropertyChanged("ReviewerName");
						this.OnReviewerNameChanged();
					}
					this.SendPropertySetterInvoked("ReviewerName", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ReviewDate", DbType="DateTime NOT NULL", CanBeNull=false)]
			public DateTime ReviewDate
			{
				get
				{
					return this._ReviewDate;
				}
				set
				{
					if (this._ReviewDate != value)
					{
						this.OnReviewDateChanging(value);
						this.SendPropertyChanging();
						this._ReviewDate = value;
						this.SendPropertyChanged("ReviewDate");
						this.OnReviewDateChanged();
					}
					this.SendPropertySetterInvoked("ReviewDate", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(50) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_EmailAddress", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
			public string EmailAddress
			{
				get
				{
					return this._EmailAddress;
				}
				set
				{
					if (this._EmailAddress != value)
					{
						this.OnEmailAddressChanging(value);
						this.SendPropertyChanging();
						this._EmailAddress = value;
						this.SendPropertyChanged("EmailAddress");
						this.OnEmailAddressChanged();
					}
					this.SendPropertySetterInvoked("EmailAddress", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_Rating", DbType="Int NOT NULL", CanBeNull=false)]
			public int Rating
			{
				get
				{
					return this._Rating;
				}
				set
				{
					if (this._Rating != value)
					{
						this.OnRatingChanging(value);
						this.SendPropertyChanging();
						this._Rating = value;
						this.SendPropertyChanged("Rating");
						this.OnRatingChanged();
					}
					this.SendPropertySetterInvoked("Rating", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(3850)
			/// </summary>
			[ColumnAttribute(Storage="_Comments", DbType="NVarChar(3850)", CanBeNull=true)]
			public string Comments
			{
				get
				{
					return this._Comments;
				}
				set
				{
					if (this._Comments != value)
					{
						this.OnCommentsChanging(value);
						this.SendPropertyChanging();
						this._Comments = value;
						this.SendPropertyChanged("Comments");
						this.OnCommentsChanged();
					}
					this.SendPropertySetterInvoked("Comments", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ModifiedDate", DbType="DateTime NOT NULL", CanBeNull=false)]
			public DateTime ModifiedDate
			{
				get
				{
					return this._ModifiedDate;
				}
				set
				{
					if (this._ModifiedDate != value)
					{
						this.OnModifiedDateChanging(value);
						this.SendPropertyChanging();
						this._ModifiedDate = value;
						this.SendPropertyChanged("ModifiedDate");
						this.OnModifiedDateChanged();
					}
					this.SendPropertySetterInvoked("ModifiedDate", value);
				}
			}
			
			#endregion Columns

			#region Associations
			/// <summary>
			/// Association [FK][Many]Production_ProductReview.ProductID --- [PK][One]Production_Product.ProductID
			/// </summary>
			[AssociationAttribute(Name="FK_ProductReview_Product_ProductID", Storage="_Production_Product", ThisKey="ProductID", OtherKey="ProductID", IsUnique=false, IsForeignKey=true)]
			public Production_Product Production_Product
			{
				get
				{
					return this._Production_Product.Entity;
				}
				set
				{
					Production_Product previousValue = this._Production_Product.Entity;
					if ((previousValue != value) || (this._Production_Product.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._Production_Product.Entity = null;
							previousValue.Production_ProductReviewList.Remove(this);
						}
						this._Production_Product.Entity = value;
						if (value != null)
						{
							value.Production_ProductReviewList.Add(this);
							this._ProductID = value.ProductID;
						}
						else
						{
							this._ProductID = default(int);
						}
						this.SendPropertyChanged("Production_Product");
					}
					this.SendPropertySetterInvoked("Production_Product", value);
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
		#endregion Production.ProductReview

		#region Production.ProductSubcategory
		[TableAttribute(Name="Production.ProductSubcategory")]
		public partial class Production_ProductSubcategory : EntityBase<Production_ProductSubcategory, AdventureWorksDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private int _ProductSubcategoryID;
			private int _ProductCategoryID;
			private string _Name;
			private System.Guid _rowguid;
			private DateTime _ModifiedDate;
			private EntitySet<Production_Product> _Production_ProductList;
			private EntityRef<Production_ProductCategory> _Production_ProductCategory;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnProductSubcategoryIDChanging(int value);
			partial void OnProductSubcategoryIDChanged();
			partial void OnProductCategoryIDChanging(int value);
			partial void OnProductCategoryIDChanged();
			partial void OnNameChanging(string value);
			partial void OnNameChanged();
			partial void OnrowguidChanging(System.Guid value);
			partial void OnrowguidChanged();
			partial void OnModifiedDateChanging(DateTime value);
			partial void OnModifiedDateChanged();
			#endregion

			public Production_ProductSubcategory()
			{
				_Production_ProductList = new EntitySet<Production_Product>(
					new Action<Production_Product>(item=>{this.SendPropertyChanging(); item.Production_ProductSubcategory=this;}), 
					new Action<Production_Product>(item=>{this.SendPropertyChanging(); item.Production_ProductSubcategory=null;}));
				_Production_ProductCategory = default(EntityRef<Production_ProductCategory>);
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=Int NOT NULL IDENTITY
			/// </summary>
			[ColumnAttribute(Storage="_ProductSubcategoryID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", CanBeNull=false, IsPrimaryKey=true, IsDbGenerated=true)]
			public int ProductSubcategoryID
			{
				get
				{
					return this._ProductSubcategoryID;
				}
				set
				{
					if (this._ProductSubcategoryID != value)
					{
						this.OnProductSubcategoryIDChanging(value);
						this.SendPropertyChanging();
						this._ProductSubcategoryID = value;
						this.SendPropertyChanged("ProductSubcategoryID");
						this.OnProductSubcategoryIDChanged();
					}
					this.SendPropertySetterInvoked("ProductSubcategoryID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ProductCategoryID", DbType="Int NOT NULL", CanBeNull=false)]
			public int ProductCategoryID
			{
				get
				{
					return this._ProductCategoryID;
				}
				set
				{
					if (this._ProductCategoryID != value)
					{
						this.OnProductCategoryIDChanging(value);
						this.SendPropertyChanging();
						this._ProductCategoryID = value;
						this.SendPropertyChanged("ProductCategoryID");
						this.OnProductCategoryIDChanged();
					}
					this.SendPropertySetterInvoked("ProductCategoryID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(50) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_Name", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
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
			/// Column DbType=UniqueIdentifier NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_rowguid", DbType="UniqueIdentifier NOT NULL", CanBeNull=false)]
			public System.Guid rowguid
			{
				get
				{
					return this._rowguid;
				}
				set
				{
					if (this._rowguid != value)
					{
						this.OnrowguidChanging(value);
						this.SendPropertyChanging();
						this._rowguid = value;
						this.SendPropertyChanged("rowguid");
						this.OnrowguidChanged();
					}
					this.SendPropertySetterInvoked("rowguid", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ModifiedDate", DbType="DateTime NOT NULL", CanBeNull=false)]
			public DateTime ModifiedDate
			{
				get
				{
					return this._ModifiedDate;
				}
				set
				{
					if (this._ModifiedDate != value)
					{
						this.OnModifiedDateChanging(value);
						this.SendPropertyChanging();
						this._ModifiedDate = value;
						this.SendPropertyChanged("ModifiedDate");
						this.OnModifiedDateChanged();
					}
					this.SendPropertySetterInvoked("ModifiedDate", value);
				}
			}
			
			#endregion Columns

			#region Associations
			/// <summary>
			/// Association [PK][One]Production_ProductSubcategory.ProductSubcategoryID --- [FK][Many]Production_Product.ProductSubcategoryID
			/// </summary>
			[AssociationAttribute(Name="FK_Product_ProductSubcategory_ProductSubcategoryID", Storage="_Production_ProductList", ThisKey="ProductSubcategoryID", OtherKey="ProductSubcategoryID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<Production_Product> Production_ProductList
			{
				get { return this._Production_ProductList; }
				set { this._Production_ProductList.Assign(value); }
			}
			
			/// <summary>
			/// Association [FK][Many]Production_ProductSubcategory.ProductCategoryID --- [PK][One]Production_ProductCategory.ProductCategoryID
			/// </summary>
			[AssociationAttribute(Name="FK_ProductSubcategory_ProductCategory_ProductCategoryID", Storage="_Production_ProductCategory", ThisKey="ProductCategoryID", OtherKey="ProductCategoryID", IsUnique=false, IsForeignKey=true)]
			public Production_ProductCategory Production_ProductCategory
			{
				get
				{
					return this._Production_ProductCategory.Entity;
				}
				set
				{
					Production_ProductCategory previousValue = this._Production_ProductCategory.Entity;
					if ((previousValue != value) || (this._Production_ProductCategory.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._Production_ProductCategory.Entity = null;
							previousValue.Production_ProductSubcategoryList.Remove(this);
						}
						this._Production_ProductCategory.Entity = value;
						if (value != null)
						{
							value.Production_ProductSubcategoryList.Add(this);
							this._ProductCategoryID = value.ProductCategoryID;
						}
						else
						{
							this._ProductCategoryID = default(int);
						}
						this.SendPropertyChanged("Production_ProductCategory");
					}
					this.SendPropertySetterInvoked("Production_ProductCategory", value);
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
		#endregion Production.ProductSubcategory

		#region Purchasing.ProductVendor
		[TableAttribute(Name="Purchasing.ProductVendor")]
		public partial class Purchasing_ProductVendor : EntityBase<Purchasing_ProductVendor, AdventureWorksDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private int _ProductID;
			private int _VendorID;
			private int _AverageLeadTime;
			private decimal _StandardPrice;
			private decimal? _LastReceiptCost;
			private DateTime? _LastReceiptDate;
			private int _MinOrderQty;
			private int _MaxOrderQty;
			private int? _OnOrderQty;
			private string _UnitMeasureCode;
			private DateTime _ModifiedDate;
			private EntityRef<Production_Product> _Production_Product;
			private EntityRef<Production_UnitMeasure> _Production_UnitMeasure;
			private EntityRef<Purchasing_Vendor> _Purchasing_Vendor;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnProductIDChanging(int value);
			partial void OnProductIDChanged();
			partial void OnVendorIDChanging(int value);
			partial void OnVendorIDChanged();
			partial void OnAverageLeadTimeChanging(int value);
			partial void OnAverageLeadTimeChanged();
			partial void OnStandardPriceChanging(decimal value);
			partial void OnStandardPriceChanged();
			partial void OnLastReceiptCostChanging(decimal? value);
			partial void OnLastReceiptCostChanged();
			partial void OnLastReceiptDateChanging(DateTime? value);
			partial void OnLastReceiptDateChanged();
			partial void OnMinOrderQtyChanging(int value);
			partial void OnMinOrderQtyChanged();
			partial void OnMaxOrderQtyChanging(int value);
			partial void OnMaxOrderQtyChanged();
			partial void OnOnOrderQtyChanging(int? value);
			partial void OnOnOrderQtyChanged();
			partial void OnUnitMeasureCodeChanging(string value);
			partial void OnUnitMeasureCodeChanged();
			partial void OnModifiedDateChanging(DateTime value);
			partial void OnModifiedDateChanged();
			#endregion

			public Purchasing_ProductVendor()
			{
				_Production_Product = default(EntityRef<Production_Product>);
				_Production_UnitMeasure = default(EntityRef<Production_UnitMeasure>);
				_Purchasing_Vendor = default(EntityRef<Purchasing_Vendor>);
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ProductID", DbType="Int NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
			public int ProductID
			{
				get
				{
					return this._ProductID;
				}
				set
				{
					if (this._ProductID != value)
					{
						this.OnProductIDChanging(value);
						this.SendPropertyChanging();
						this._ProductID = value;
						this.SendPropertyChanged("ProductID");
						this.OnProductIDChanged();
					}
					this.SendPropertySetterInvoked("ProductID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_VendorID", DbType="Int NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
			public int VendorID
			{
				get
				{
					return this._VendorID;
				}
				set
				{
					if (this._VendorID != value)
					{
						this.OnVendorIDChanging(value);
						this.SendPropertyChanging();
						this._VendorID = value;
						this.SendPropertyChanged("VendorID");
						this.OnVendorIDChanged();
					}
					this.SendPropertySetterInvoked("VendorID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_AverageLeadTime", DbType="Int NOT NULL", CanBeNull=false)]
			public int AverageLeadTime
			{
				get
				{
					return this._AverageLeadTime;
				}
				set
				{
					if (this._AverageLeadTime != value)
					{
						this.OnAverageLeadTimeChanging(value);
						this.SendPropertyChanging();
						this._AverageLeadTime = value;
						this.SendPropertyChanged("AverageLeadTime");
						this.OnAverageLeadTimeChanged();
					}
					this.SendPropertySetterInvoked("AverageLeadTime", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Money NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_StandardPrice", DbType="Money NOT NULL", CanBeNull=false)]
			public decimal StandardPrice
			{
				get
				{
					return this._StandardPrice;
				}
				set
				{
					if (this._StandardPrice != value)
					{
						this.OnStandardPriceChanging(value);
						this.SendPropertyChanging();
						this._StandardPrice = value;
						this.SendPropertyChanged("StandardPrice");
						this.OnStandardPriceChanged();
					}
					this.SendPropertySetterInvoked("StandardPrice", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Money
			/// </summary>
			[ColumnAttribute(Storage="_LastReceiptCost", DbType="Money", CanBeNull=true)]
			public decimal? LastReceiptCost
			{
				get
				{
					return this._LastReceiptCost;
				}
				set
				{
					if (this._LastReceiptCost != value)
					{
						this.OnLastReceiptCostChanging(value);
						this.SendPropertyChanging();
						this._LastReceiptCost = value;
						this.SendPropertyChanged("LastReceiptCost");
						this.OnLastReceiptCostChanged();
					}
					this.SendPropertySetterInvoked("LastReceiptCost", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime
			/// </summary>
			[ColumnAttribute(Storage="_LastReceiptDate", DbType="DateTime", CanBeNull=true)]
			public DateTime? LastReceiptDate
			{
				get
				{
					return this._LastReceiptDate;
				}
				set
				{
					if (this._LastReceiptDate != value)
					{
						this.OnLastReceiptDateChanging(value);
						this.SendPropertyChanging();
						this._LastReceiptDate = value;
						this.SendPropertyChanged("LastReceiptDate");
						this.OnLastReceiptDateChanged();
					}
					this.SendPropertySetterInvoked("LastReceiptDate", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_MinOrderQty", DbType="Int NOT NULL", CanBeNull=false)]
			public int MinOrderQty
			{
				get
				{
					return this._MinOrderQty;
				}
				set
				{
					if (this._MinOrderQty != value)
					{
						this.OnMinOrderQtyChanging(value);
						this.SendPropertyChanging();
						this._MinOrderQty = value;
						this.SendPropertyChanged("MinOrderQty");
						this.OnMinOrderQtyChanged();
					}
					this.SendPropertySetterInvoked("MinOrderQty", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_MaxOrderQty", DbType="Int NOT NULL", CanBeNull=false)]
			public int MaxOrderQty
			{
				get
				{
					return this._MaxOrderQty;
				}
				set
				{
					if (this._MaxOrderQty != value)
					{
						this.OnMaxOrderQtyChanging(value);
						this.SendPropertyChanging();
						this._MaxOrderQty = value;
						this.SendPropertyChanged("MaxOrderQty");
						this.OnMaxOrderQtyChanged();
					}
					this.SendPropertySetterInvoked("MaxOrderQty", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int
			/// </summary>
			[ColumnAttribute(Storage="_OnOrderQty", DbType="Int", CanBeNull=true)]
			public int? OnOrderQty
			{
				get
				{
					return this._OnOrderQty;
				}
				set
				{
					if (this._OnOrderQty != value)
					{
						this.OnOnOrderQtyChanging(value);
						this.SendPropertyChanging();
						this._OnOrderQty = value;
						this.SendPropertyChanged("OnOrderQty");
						this.OnOnOrderQtyChanged();
					}
					this.SendPropertySetterInvoked("OnOrderQty", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NChar(3) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_UnitMeasureCode", DbType="NChar(3) NOT NULL", CanBeNull=false)]
			public string UnitMeasureCode
			{
				get
				{
					return this._UnitMeasureCode;
				}
				set
				{
					if (this._UnitMeasureCode != value)
					{
						this.OnUnitMeasureCodeChanging(value);
						this.SendPropertyChanging();
						this._UnitMeasureCode = value;
						this.SendPropertyChanged("UnitMeasureCode");
						this.OnUnitMeasureCodeChanged();
					}
					this.SendPropertySetterInvoked("UnitMeasureCode", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ModifiedDate", DbType="DateTime NOT NULL", CanBeNull=false)]
			public DateTime ModifiedDate
			{
				get
				{
					return this._ModifiedDate;
				}
				set
				{
					if (this._ModifiedDate != value)
					{
						this.OnModifiedDateChanging(value);
						this.SendPropertyChanging();
						this._ModifiedDate = value;
						this.SendPropertyChanged("ModifiedDate");
						this.OnModifiedDateChanged();
					}
					this.SendPropertySetterInvoked("ModifiedDate", value);
				}
			}
			
			#endregion Columns

			#region Associations
			/// <summary>
			/// Association [FK][Many]Purchasing_ProductVendor.ProductID --- [PK][One]Production_Product.ProductID
			/// </summary>
			[AssociationAttribute(Name="FK_ProductVendor_Product_ProductID", Storage="_Production_Product", ThisKey="ProductID", OtherKey="ProductID", IsUnique=false, IsForeignKey=true)]
			public Production_Product Production_Product
			{
				get
				{
					return this._Production_Product.Entity;
				}
				set
				{
					Production_Product previousValue = this._Production_Product.Entity;
					if ((previousValue != value) || (this._Production_Product.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._Production_Product.Entity = null;
							previousValue.Purchasing_ProductVendorList.Remove(this);
						}
						this._Production_Product.Entity = value;
						if (value != null)
						{
							value.Purchasing_ProductVendorList.Add(this);
							this._ProductID = value.ProductID;
						}
						else
						{
							this._ProductID = default(int);
						}
						this.SendPropertyChanged("Production_Product");
					}
					this.SendPropertySetterInvoked("Production_Product", value);
				}
			}
			
			/// <summary>
			/// Association [FK][Many]Purchasing_ProductVendor.UnitMeasureCode --- [PK][One]Production_UnitMeasure.UnitMeasureCode
			/// </summary>
			[AssociationAttribute(Name="FK_ProductVendor_UnitMeasure_UnitMeasureCode", Storage="_Production_UnitMeasure", ThisKey="UnitMeasureCode", OtherKey="UnitMeasureCode", IsUnique=false, IsForeignKey=true)]
			public Production_UnitMeasure Production_UnitMeasure
			{
				get
				{
					return this._Production_UnitMeasure.Entity;
				}
				set
				{
					Production_UnitMeasure previousValue = this._Production_UnitMeasure.Entity;
					if ((previousValue != value) || (this._Production_UnitMeasure.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._Production_UnitMeasure.Entity = null;
							previousValue.Purchasing_ProductVendorList.Remove(this);
						}
						this._Production_UnitMeasure.Entity = value;
						if (value != null)
						{
							value.Purchasing_ProductVendorList.Add(this);
							this._UnitMeasureCode = value.UnitMeasureCode;
						}
						else
						{
							this._UnitMeasureCode = default(string);
						}
						this.SendPropertyChanged("Production_UnitMeasure");
					}
					this.SendPropertySetterInvoked("Production_UnitMeasure", value);
				}
			}
			
			/// <summary>
			/// Association [FK][Many]Purchasing_ProductVendor.VendorID --- [PK][One]Purchasing_Vendor.VendorID
			/// </summary>
			[AssociationAttribute(Name="FK_ProductVendor_Vendor_VendorID", Storage="_Purchasing_Vendor", ThisKey="VendorID", OtherKey="VendorID", IsUnique=false, IsForeignKey=true)]
			public Purchasing_Vendor Purchasing_Vendor
			{
				get
				{
					return this._Purchasing_Vendor.Entity;
				}
				set
				{
					Purchasing_Vendor previousValue = this._Purchasing_Vendor.Entity;
					if ((previousValue != value) || (this._Purchasing_Vendor.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._Purchasing_Vendor.Entity = null;
							previousValue.Purchasing_ProductVendorList.Remove(this);
						}
						this._Purchasing_Vendor.Entity = value;
						if (value != null)
						{
							value.Purchasing_ProductVendorList.Add(this);
							this._VendorID = value.VendorID;
						}
						else
						{
							this._VendorID = default(int);
						}
						this.SendPropertyChanged("Purchasing_Vendor");
					}
					this.SendPropertySetterInvoked("Purchasing_Vendor", value);
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
		#endregion Purchasing.ProductVendor

		#region Purchasing.PurchaseOrderDetail
		[TableAttribute(Name="Purchasing.PurchaseOrderDetail")]
		public partial class Purchasing_PurchaseOrderDetail : EntityBase<Purchasing_PurchaseOrderDetail, AdventureWorksDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private int _PurchaseOrderID;
			private int _PurchaseOrderDetailID;
			private DateTime _DueDate;
			private System.Int16 _OrderQty;
			private int _ProductID;
			private decimal _UnitPrice;
			private decimal _LineTotal;
			private decimal _ReceivedQty;
			private decimal _RejectedQty;
			private decimal _StockedQty;
			private DateTime _ModifiedDate;
			private EntityRef<Production_Product> _Production_Product;
			private EntityRef<Purchasing_PurchaseOrderHeader> _Purchasing_PurchaseOrderHeader;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnPurchaseOrderIDChanging(int value);
			partial void OnPurchaseOrderIDChanged();
			partial void OnPurchaseOrderDetailIDChanging(int value);
			partial void OnPurchaseOrderDetailIDChanged();
			partial void OnDueDateChanging(DateTime value);
			partial void OnDueDateChanged();
			partial void OnOrderQtyChanging(System.Int16 value);
			partial void OnOrderQtyChanged();
			partial void OnProductIDChanging(int value);
			partial void OnProductIDChanged();
			partial void OnUnitPriceChanging(decimal value);
			partial void OnUnitPriceChanged();
			partial void OnLineTotalChanging(decimal value);
			partial void OnLineTotalChanged();
			partial void OnReceivedQtyChanging(decimal value);
			partial void OnReceivedQtyChanged();
			partial void OnRejectedQtyChanging(decimal value);
			partial void OnRejectedQtyChanged();
			partial void OnStockedQtyChanging(decimal value);
			partial void OnStockedQtyChanged();
			partial void OnModifiedDateChanging(DateTime value);
			partial void OnModifiedDateChanged();
			#endregion

			public Purchasing_PurchaseOrderDetail()
			{
				_Production_Product = default(EntityRef<Production_Product>);
				_Purchasing_PurchaseOrderHeader = default(EntityRef<Purchasing_PurchaseOrderHeader>);
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_PurchaseOrderID", DbType="Int NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
			public int PurchaseOrderID
			{
				get
				{
					return this._PurchaseOrderID;
				}
				set
				{
					if (this._PurchaseOrderID != value)
					{
						this.OnPurchaseOrderIDChanging(value);
						this.SendPropertyChanging();
						this._PurchaseOrderID = value;
						this.SendPropertyChanged("PurchaseOrderID");
						this.OnPurchaseOrderIDChanged();
					}
					this.SendPropertySetterInvoked("PurchaseOrderID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int NOT NULL IDENTITY
			/// </summary>
			[ColumnAttribute(Storage="_PurchaseOrderDetailID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", CanBeNull=false, IsPrimaryKey=true, IsDbGenerated=true)]
			public int PurchaseOrderDetailID
			{
				get
				{
					return this._PurchaseOrderDetailID;
				}
				set
				{
					if (this._PurchaseOrderDetailID != value)
					{
						this.OnPurchaseOrderDetailIDChanging(value);
						this.SendPropertyChanging();
						this._PurchaseOrderDetailID = value;
						this.SendPropertyChanged("PurchaseOrderDetailID");
						this.OnPurchaseOrderDetailIDChanged();
					}
					this.SendPropertySetterInvoked("PurchaseOrderDetailID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_DueDate", DbType="DateTime NOT NULL", CanBeNull=false)]
			public DateTime DueDate
			{
				get
				{
					return this._DueDate;
				}
				set
				{
					if (this._DueDate != value)
					{
						this.OnDueDateChanging(value);
						this.SendPropertyChanging();
						this._DueDate = value;
						this.SendPropertyChanged("DueDate");
						this.OnDueDateChanged();
					}
					this.SendPropertySetterInvoked("DueDate", value);
				}
			}
			
			/// <summary>
			/// Column DbType=SmallInt NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_OrderQty", DbType="SmallInt NOT NULL", CanBeNull=false)]
			public System.Int16 OrderQty
			{
				get
				{
					return this._OrderQty;
				}
				set
				{
					if (this._OrderQty != value)
					{
						this.OnOrderQtyChanging(value);
						this.SendPropertyChanging();
						this._OrderQty = value;
						this.SendPropertyChanged("OrderQty");
						this.OnOrderQtyChanged();
					}
					this.SendPropertySetterInvoked("OrderQty", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ProductID", DbType="Int NOT NULL", CanBeNull=false)]
			public int ProductID
			{
				get
				{
					return this._ProductID;
				}
				set
				{
					if (this._ProductID != value)
					{
						this.OnProductIDChanging(value);
						this.SendPropertyChanging();
						this._ProductID = value;
						this.SendPropertyChanged("ProductID");
						this.OnProductIDChanged();
					}
					this.SendPropertySetterInvoked("ProductID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Money NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_UnitPrice", DbType="Money NOT NULL", CanBeNull=false)]
			public decimal UnitPrice
			{
				get
				{
					return this._UnitPrice;
				}
				set
				{
					if (this._UnitPrice != value)
					{
						this.OnUnitPriceChanging(value);
						this.SendPropertyChanging();
						this._UnitPrice = value;
						this.SendPropertyChanged("UnitPrice");
						this.OnUnitPriceChanged();
					}
					this.SendPropertySetterInvoked("UnitPrice", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Money NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_LineTotal", DbType="Money NOT NULL", CanBeNull=false)]
			public decimal LineTotal
			{
				get
				{
					return this._LineTotal;
				}
				set
				{
					if (this._LineTotal != value)
					{
						this.OnLineTotalChanging(value);
						this.SendPropertyChanging();
						this._LineTotal = value;
						this.SendPropertyChanged("LineTotal");
						this.OnLineTotalChanged();
					}
					this.SendPropertySetterInvoked("LineTotal", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Decimal(8,2) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ReceivedQty", DbType="Decimal(8,2) NOT NULL", CanBeNull=false)]
			public decimal ReceivedQty
			{
				get
				{
					return this._ReceivedQty;
				}
				set
				{
					if (this._ReceivedQty != value)
					{
						this.OnReceivedQtyChanging(value);
						this.SendPropertyChanging();
						this._ReceivedQty = value;
						this.SendPropertyChanged("ReceivedQty");
						this.OnReceivedQtyChanged();
					}
					this.SendPropertySetterInvoked("ReceivedQty", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Decimal(8,2) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_RejectedQty", DbType="Decimal(8,2) NOT NULL", CanBeNull=false)]
			public decimal RejectedQty
			{
				get
				{
					return this._RejectedQty;
				}
				set
				{
					if (this._RejectedQty != value)
					{
						this.OnRejectedQtyChanging(value);
						this.SendPropertyChanging();
						this._RejectedQty = value;
						this.SendPropertyChanged("RejectedQty");
						this.OnRejectedQtyChanged();
					}
					this.SendPropertySetterInvoked("RejectedQty", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Decimal(9,2) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_StockedQty", DbType="Decimal(9,2) NOT NULL", CanBeNull=false)]
			public decimal StockedQty
			{
				get
				{
					return this._StockedQty;
				}
				set
				{
					if (this._StockedQty != value)
					{
						this.OnStockedQtyChanging(value);
						this.SendPropertyChanging();
						this._StockedQty = value;
						this.SendPropertyChanged("StockedQty");
						this.OnStockedQtyChanged();
					}
					this.SendPropertySetterInvoked("StockedQty", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ModifiedDate", DbType="DateTime NOT NULL", CanBeNull=false)]
			public DateTime ModifiedDate
			{
				get
				{
					return this._ModifiedDate;
				}
				set
				{
					if (this._ModifiedDate != value)
					{
						this.OnModifiedDateChanging(value);
						this.SendPropertyChanging();
						this._ModifiedDate = value;
						this.SendPropertyChanged("ModifiedDate");
						this.OnModifiedDateChanged();
					}
					this.SendPropertySetterInvoked("ModifiedDate", value);
				}
			}
			
			#endregion Columns

			#region Associations
			/// <summary>
			/// Association [FK][Many]Purchasing_PurchaseOrderDetail.ProductID --- [PK][One]Production_Product.ProductID
			/// </summary>
			[AssociationAttribute(Name="FK_PurchaseOrderDetail_Product_ProductID", Storage="_Production_Product", ThisKey="ProductID", OtherKey="ProductID", IsUnique=false, IsForeignKey=true)]
			public Production_Product Production_Product
			{
				get
				{
					return this._Production_Product.Entity;
				}
				set
				{
					Production_Product previousValue = this._Production_Product.Entity;
					if ((previousValue != value) || (this._Production_Product.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._Production_Product.Entity = null;
							previousValue.Purchasing_PurchaseOrderDetailList.Remove(this);
						}
						this._Production_Product.Entity = value;
						if (value != null)
						{
							value.Purchasing_PurchaseOrderDetailList.Add(this);
							this._ProductID = value.ProductID;
						}
						else
						{
							this._ProductID = default(int);
						}
						this.SendPropertyChanged("Production_Product");
					}
					this.SendPropertySetterInvoked("Production_Product", value);
				}
			}
			
			/// <summary>
			/// Association [FK][Many]Purchasing_PurchaseOrderDetail.PurchaseOrderID --- [PK][One]Purchasing_PurchaseOrderHeader.PurchaseOrderID
			/// </summary>
			[AssociationAttribute(Name="FK_PurchaseOrderDetail_PurchaseOrderHeader_PurchaseOrderID", Storage="_Purchasing_PurchaseOrderHeader", ThisKey="PurchaseOrderID", OtherKey="PurchaseOrderID", IsUnique=false, IsForeignKey=true)]
			public Purchasing_PurchaseOrderHeader Purchasing_PurchaseOrderHeader
			{
				get
				{
					return this._Purchasing_PurchaseOrderHeader.Entity;
				}
				set
				{
					Purchasing_PurchaseOrderHeader previousValue = this._Purchasing_PurchaseOrderHeader.Entity;
					if ((previousValue != value) || (this._Purchasing_PurchaseOrderHeader.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._Purchasing_PurchaseOrderHeader.Entity = null;
							previousValue.Purchasing_PurchaseOrderDetailList.Remove(this);
						}
						this._Purchasing_PurchaseOrderHeader.Entity = value;
						if (value != null)
						{
							value.Purchasing_PurchaseOrderDetailList.Add(this);
							this._PurchaseOrderID = value.PurchaseOrderID;
						}
						else
						{
							this._PurchaseOrderID = default(int);
						}
						this.SendPropertyChanged("Purchasing_PurchaseOrderHeader");
					}
					this.SendPropertySetterInvoked("Purchasing_PurchaseOrderHeader", value);
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
		#endregion Purchasing.PurchaseOrderDetail

		#region Purchasing.PurchaseOrderHeader
		[TableAttribute(Name="Purchasing.PurchaseOrderHeader")]
		public partial class Purchasing_PurchaseOrderHeader : EntityBase<Purchasing_PurchaseOrderHeader, AdventureWorksDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private int _PurchaseOrderID;
			private byte _RevisionNumber;
			private byte _Status;
			private int _EmployeeID;
			private int _VendorID;
			private int _ShipMethodID;
			private DateTime _OrderDate;
			private DateTime? _ShipDate;
			private decimal _SubTotal;
			private decimal _TaxAmt;
			private decimal _Freight;
			private decimal _TotalDue;
			private DateTime _ModifiedDate;
			private EntitySet<Purchasing_PurchaseOrderDetail> _Purchasing_PurchaseOrderDetailList;
			private EntityRef<HumanResources_Employee> _HumanResources_Employee;
			private EntityRef<Purchasing_ShipMethod> _Purchasing_ShipMethod;
			private EntityRef<Purchasing_Vendor> _Purchasing_Vendor;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnPurchaseOrderIDChanging(int value);
			partial void OnPurchaseOrderIDChanged();
			partial void OnRevisionNumberChanging(byte value);
			partial void OnRevisionNumberChanged();
			partial void OnStatusChanging(byte value);
			partial void OnStatusChanged();
			partial void OnEmployeeIDChanging(int value);
			partial void OnEmployeeIDChanged();
			partial void OnVendorIDChanging(int value);
			partial void OnVendorIDChanged();
			partial void OnShipMethodIDChanging(int value);
			partial void OnShipMethodIDChanged();
			partial void OnOrderDateChanging(DateTime value);
			partial void OnOrderDateChanged();
			partial void OnShipDateChanging(DateTime? value);
			partial void OnShipDateChanged();
			partial void OnSubTotalChanging(decimal value);
			partial void OnSubTotalChanged();
			partial void OnTaxAmtChanging(decimal value);
			partial void OnTaxAmtChanged();
			partial void OnFreightChanging(decimal value);
			partial void OnFreightChanged();
			partial void OnTotalDueChanging(decimal value);
			partial void OnTotalDueChanged();
			partial void OnModifiedDateChanging(DateTime value);
			partial void OnModifiedDateChanged();
			#endregion

			public Purchasing_PurchaseOrderHeader()
			{
				_Purchasing_PurchaseOrderDetailList = new EntitySet<Purchasing_PurchaseOrderDetail>(
					new Action<Purchasing_PurchaseOrderDetail>(item=>{this.SendPropertyChanging(); item.Purchasing_PurchaseOrderHeader=this;}), 
					new Action<Purchasing_PurchaseOrderDetail>(item=>{this.SendPropertyChanging(); item.Purchasing_PurchaseOrderHeader=null;}));
				_HumanResources_Employee = default(EntityRef<HumanResources_Employee>);
				_Purchasing_ShipMethod = default(EntityRef<Purchasing_ShipMethod>);
				_Purchasing_Vendor = default(EntityRef<Purchasing_Vendor>);
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=Int NOT NULL IDENTITY
			/// </summary>
			[ColumnAttribute(Storage="_PurchaseOrderID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", CanBeNull=false, IsPrimaryKey=true, IsDbGenerated=true)]
			public int PurchaseOrderID
			{
				get
				{
					return this._PurchaseOrderID;
				}
				set
				{
					if (this._PurchaseOrderID != value)
					{
						this.OnPurchaseOrderIDChanging(value);
						this.SendPropertyChanging();
						this._PurchaseOrderID = value;
						this.SendPropertyChanged("PurchaseOrderID");
						this.OnPurchaseOrderIDChanged();
					}
					this.SendPropertySetterInvoked("PurchaseOrderID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=TinyInt NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_RevisionNumber", DbType="TinyInt NOT NULL", CanBeNull=false)]
			public byte RevisionNumber
			{
				get
				{
					return this._RevisionNumber;
				}
				set
				{
					if (this._RevisionNumber != value)
					{
						this.OnRevisionNumberChanging(value);
						this.SendPropertyChanging();
						this._RevisionNumber = value;
						this.SendPropertyChanged("RevisionNumber");
						this.OnRevisionNumberChanged();
					}
					this.SendPropertySetterInvoked("RevisionNumber", value);
				}
			}
			
			/// <summary>
			/// Column DbType=TinyInt NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_Status", DbType="TinyInt NOT NULL", CanBeNull=false)]
			public byte Status
			{
				get
				{
					return this._Status;
				}
				set
				{
					if (this._Status != value)
					{
						this.OnStatusChanging(value);
						this.SendPropertyChanging();
						this._Status = value;
						this.SendPropertyChanged("Status");
						this.OnStatusChanged();
					}
					this.SendPropertySetterInvoked("Status", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_EmployeeID", DbType="Int NOT NULL", CanBeNull=false)]
			public int EmployeeID
			{
				get
				{
					return this._EmployeeID;
				}
				set
				{
					if (this._EmployeeID != value)
					{
						this.OnEmployeeIDChanging(value);
						this.SendPropertyChanging();
						this._EmployeeID = value;
						this.SendPropertyChanged("EmployeeID");
						this.OnEmployeeIDChanged();
					}
					this.SendPropertySetterInvoked("EmployeeID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_VendorID", DbType="Int NOT NULL", CanBeNull=false)]
			public int VendorID
			{
				get
				{
					return this._VendorID;
				}
				set
				{
					if (this._VendorID != value)
					{
						this.OnVendorIDChanging(value);
						this.SendPropertyChanging();
						this._VendorID = value;
						this.SendPropertyChanged("VendorID");
						this.OnVendorIDChanged();
					}
					this.SendPropertySetterInvoked("VendorID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ShipMethodID", DbType="Int NOT NULL", CanBeNull=false)]
			public int ShipMethodID
			{
				get
				{
					return this._ShipMethodID;
				}
				set
				{
					if (this._ShipMethodID != value)
					{
						this.OnShipMethodIDChanging(value);
						this.SendPropertyChanging();
						this._ShipMethodID = value;
						this.SendPropertyChanged("ShipMethodID");
						this.OnShipMethodIDChanged();
					}
					this.SendPropertySetterInvoked("ShipMethodID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_OrderDate", DbType="DateTime NOT NULL", CanBeNull=false)]
			public DateTime OrderDate
			{
				get
				{
					return this._OrderDate;
				}
				set
				{
					if (this._OrderDate != value)
					{
						this.OnOrderDateChanging(value);
						this.SendPropertyChanging();
						this._OrderDate = value;
						this.SendPropertyChanged("OrderDate");
						this.OnOrderDateChanged();
					}
					this.SendPropertySetterInvoked("OrderDate", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime
			/// </summary>
			[ColumnAttribute(Storage="_ShipDate", DbType="DateTime", CanBeNull=true)]
			public DateTime? ShipDate
			{
				get
				{
					return this._ShipDate;
				}
				set
				{
					if (this._ShipDate != value)
					{
						this.OnShipDateChanging(value);
						this.SendPropertyChanging();
						this._ShipDate = value;
						this.SendPropertyChanged("ShipDate");
						this.OnShipDateChanged();
					}
					this.SendPropertySetterInvoked("ShipDate", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Money NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_SubTotal", DbType="Money NOT NULL", CanBeNull=false)]
			public decimal SubTotal
			{
				get
				{
					return this._SubTotal;
				}
				set
				{
					if (this._SubTotal != value)
					{
						this.OnSubTotalChanging(value);
						this.SendPropertyChanging();
						this._SubTotal = value;
						this.SendPropertyChanged("SubTotal");
						this.OnSubTotalChanged();
					}
					this.SendPropertySetterInvoked("SubTotal", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Money NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_TaxAmt", DbType="Money NOT NULL", CanBeNull=false)]
			public decimal TaxAmt
			{
				get
				{
					return this._TaxAmt;
				}
				set
				{
					if (this._TaxAmt != value)
					{
						this.OnTaxAmtChanging(value);
						this.SendPropertyChanging();
						this._TaxAmt = value;
						this.SendPropertyChanged("TaxAmt");
						this.OnTaxAmtChanged();
					}
					this.SendPropertySetterInvoked("TaxAmt", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Money NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_Freight", DbType="Money NOT NULL", CanBeNull=false)]
			public decimal Freight
			{
				get
				{
					return this._Freight;
				}
				set
				{
					if (this._Freight != value)
					{
						this.OnFreightChanging(value);
						this.SendPropertyChanging();
						this._Freight = value;
						this.SendPropertyChanged("Freight");
						this.OnFreightChanged();
					}
					this.SendPropertySetterInvoked("Freight", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Money NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_TotalDue", DbType="Money NOT NULL", CanBeNull=false)]
			public decimal TotalDue
			{
				get
				{
					return this._TotalDue;
				}
				set
				{
					if (this._TotalDue != value)
					{
						this.OnTotalDueChanging(value);
						this.SendPropertyChanging();
						this._TotalDue = value;
						this.SendPropertyChanged("TotalDue");
						this.OnTotalDueChanged();
					}
					this.SendPropertySetterInvoked("TotalDue", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ModifiedDate", DbType="DateTime NOT NULL", CanBeNull=false)]
			public DateTime ModifiedDate
			{
				get
				{
					return this._ModifiedDate;
				}
				set
				{
					if (this._ModifiedDate != value)
					{
						this.OnModifiedDateChanging(value);
						this.SendPropertyChanging();
						this._ModifiedDate = value;
						this.SendPropertyChanged("ModifiedDate");
						this.OnModifiedDateChanged();
					}
					this.SendPropertySetterInvoked("ModifiedDate", value);
				}
			}
			
			#endregion Columns

			#region Associations
			/// <summary>
			/// Association [PK][One]Purchasing_PurchaseOrderHeader.PurchaseOrderID --- [FK][Many]Purchasing_PurchaseOrderDetail.PurchaseOrderID
			/// </summary>
			[AssociationAttribute(Name="FK_PurchaseOrderDetail_PurchaseOrderHeader_PurchaseOrderID", Storage="_Purchasing_PurchaseOrderDetailList", ThisKey="PurchaseOrderID", OtherKey="PurchaseOrderID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<Purchasing_PurchaseOrderDetail> Purchasing_PurchaseOrderDetailList
			{
				get { return this._Purchasing_PurchaseOrderDetailList; }
				set { this._Purchasing_PurchaseOrderDetailList.Assign(value); }
			}
			
			/// <summary>
			/// Association [FK][Many]Purchasing_PurchaseOrderHeader.EmployeeID --- [PK][One]HumanResources_Employee.EmployeeID
			/// </summary>
			[AssociationAttribute(Name="FK_PurchaseOrderHeader_Employee_EmployeeID", Storage="_HumanResources_Employee", ThisKey="EmployeeID", OtherKey="EmployeeID", IsUnique=false, IsForeignKey=true)]
			public HumanResources_Employee HumanResources_Employee
			{
				get
				{
					return this._HumanResources_Employee.Entity;
				}
				set
				{
					HumanResources_Employee previousValue = this._HumanResources_Employee.Entity;
					if ((previousValue != value) || (this._HumanResources_Employee.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._HumanResources_Employee.Entity = null;
							previousValue.Purchasing_PurchaseOrderHeaderList.Remove(this);
						}
						this._HumanResources_Employee.Entity = value;
						if (value != null)
						{
							value.Purchasing_PurchaseOrderHeaderList.Add(this);
							this._EmployeeID = value.EmployeeID;
						}
						else
						{
							this._EmployeeID = default(int);
						}
						this.SendPropertyChanged("HumanResources_Employee");
					}
					this.SendPropertySetterInvoked("HumanResources_Employee", value);
				}
			}
			
			/// <summary>
			/// Association [FK][Many]Purchasing_PurchaseOrderHeader.ShipMethodID --- [PK][One]Purchasing_ShipMethod.ShipMethodID
			/// </summary>
			[AssociationAttribute(Name="FK_PurchaseOrderHeader_ShipMethod_ShipMethodID", Storage="_Purchasing_ShipMethod", ThisKey="ShipMethodID", OtherKey="ShipMethodID", IsUnique=false, IsForeignKey=true)]
			public Purchasing_ShipMethod Purchasing_ShipMethod
			{
				get
				{
					return this._Purchasing_ShipMethod.Entity;
				}
				set
				{
					Purchasing_ShipMethod previousValue = this._Purchasing_ShipMethod.Entity;
					if ((previousValue != value) || (this._Purchasing_ShipMethod.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._Purchasing_ShipMethod.Entity = null;
							previousValue.Purchasing_PurchaseOrderHeaderList.Remove(this);
						}
						this._Purchasing_ShipMethod.Entity = value;
						if (value != null)
						{
							value.Purchasing_PurchaseOrderHeaderList.Add(this);
							this._ShipMethodID = value.ShipMethodID;
						}
						else
						{
							this._ShipMethodID = default(int);
						}
						this.SendPropertyChanged("Purchasing_ShipMethod");
					}
					this.SendPropertySetterInvoked("Purchasing_ShipMethod", value);
				}
			}
			
			/// <summary>
			/// Association [FK][Many]Purchasing_PurchaseOrderHeader.VendorID --- [PK][One]Purchasing_Vendor.VendorID
			/// </summary>
			[AssociationAttribute(Name="FK_PurchaseOrderHeader_Vendor_VendorID", Storage="_Purchasing_Vendor", ThisKey="VendorID", OtherKey="VendorID", IsUnique=false, IsForeignKey=true)]
			public Purchasing_Vendor Purchasing_Vendor
			{
				get
				{
					return this._Purchasing_Vendor.Entity;
				}
				set
				{
					Purchasing_Vendor previousValue = this._Purchasing_Vendor.Entity;
					if ((previousValue != value) || (this._Purchasing_Vendor.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._Purchasing_Vendor.Entity = null;
							previousValue.Purchasing_PurchaseOrderHeaderList.Remove(this);
						}
						this._Purchasing_Vendor.Entity = value;
						if (value != null)
						{
							value.Purchasing_PurchaseOrderHeaderList.Add(this);
							this._VendorID = value.VendorID;
						}
						else
						{
							this._VendorID = default(int);
						}
						this.SendPropertyChanged("Purchasing_Vendor");
					}
					this.SendPropertySetterInvoked("Purchasing_Vendor", value);
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
		#endregion Purchasing.PurchaseOrderHeader

		#region Sales.SalesOrderDetail
		[TableAttribute(Name="Sales.SalesOrderDetail")]
		public partial class Sales_SalesOrderDetail : EntityBase<Sales_SalesOrderDetail, AdventureWorksDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private int _SalesOrderID;
			private int _SalesOrderDetailID;
			private string _CarrierTrackingNumber;
			private System.Int16 _OrderQty;
			private int _ProductID;
			private int _SpecialOfferID;
			private decimal _UnitPrice;
			private decimal _UnitPriceDiscount;
			private decimal _LineTotal;
			private System.Guid _rowguid;
			private DateTime _ModifiedDate;
			private EntityRef<Sales_SalesOrderHeader> _Sales_SalesOrderHeader;
			private EntityRef<Sales_SpecialOfferProduct> _Sales_SpecialOfferProduct;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnSalesOrderIDChanging(int value);
			partial void OnSalesOrderIDChanged();
			partial void OnSalesOrderDetailIDChanging(int value);
			partial void OnSalesOrderDetailIDChanged();
			partial void OnCarrierTrackingNumberChanging(string value);
			partial void OnCarrierTrackingNumberChanged();
			partial void OnOrderQtyChanging(System.Int16 value);
			partial void OnOrderQtyChanged();
			partial void OnProductIDChanging(int value);
			partial void OnProductIDChanged();
			partial void OnSpecialOfferIDChanging(int value);
			partial void OnSpecialOfferIDChanged();
			partial void OnUnitPriceChanging(decimal value);
			partial void OnUnitPriceChanged();
			partial void OnUnitPriceDiscountChanging(decimal value);
			partial void OnUnitPriceDiscountChanged();
			partial void OnLineTotalChanging(decimal value);
			partial void OnLineTotalChanged();
			partial void OnrowguidChanging(System.Guid value);
			partial void OnrowguidChanged();
			partial void OnModifiedDateChanging(DateTime value);
			partial void OnModifiedDateChanged();
			#endregion

			public Sales_SalesOrderDetail()
			{
				_Sales_SalesOrderHeader = default(EntityRef<Sales_SalesOrderHeader>);
				_Sales_SpecialOfferProduct = default(EntityRef<Sales_SpecialOfferProduct>);
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_SalesOrderID", DbType="Int NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
			public int SalesOrderID
			{
				get
				{
					return this._SalesOrderID;
				}
				set
				{
					if (this._SalesOrderID != value)
					{
						this.OnSalesOrderIDChanging(value);
						this.SendPropertyChanging();
						this._SalesOrderID = value;
						this.SendPropertyChanged("SalesOrderID");
						this.OnSalesOrderIDChanged();
					}
					this.SendPropertySetterInvoked("SalesOrderID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int NOT NULL IDENTITY
			/// </summary>
			[ColumnAttribute(Storage="_SalesOrderDetailID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", CanBeNull=false, IsPrimaryKey=true, IsDbGenerated=true)]
			public int SalesOrderDetailID
			{
				get
				{
					return this._SalesOrderDetailID;
				}
				set
				{
					if (this._SalesOrderDetailID != value)
					{
						this.OnSalesOrderDetailIDChanging(value);
						this.SendPropertyChanging();
						this._SalesOrderDetailID = value;
						this.SendPropertyChanged("SalesOrderDetailID");
						this.OnSalesOrderDetailIDChanged();
					}
					this.SendPropertySetterInvoked("SalesOrderDetailID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(25)
			/// </summary>
			[ColumnAttribute(Storage="_CarrierTrackingNumber", DbType="NVarChar(25)", CanBeNull=true)]
			public string CarrierTrackingNumber
			{
				get
				{
					return this._CarrierTrackingNumber;
				}
				set
				{
					if (this._CarrierTrackingNumber != value)
					{
						this.OnCarrierTrackingNumberChanging(value);
						this.SendPropertyChanging();
						this._CarrierTrackingNumber = value;
						this.SendPropertyChanged("CarrierTrackingNumber");
						this.OnCarrierTrackingNumberChanged();
					}
					this.SendPropertySetterInvoked("CarrierTrackingNumber", value);
				}
			}
			
			/// <summary>
			/// Column DbType=SmallInt NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_OrderQty", DbType="SmallInt NOT NULL", CanBeNull=false)]
			public System.Int16 OrderQty
			{
				get
				{
					return this._OrderQty;
				}
				set
				{
					if (this._OrderQty != value)
					{
						this.OnOrderQtyChanging(value);
						this.SendPropertyChanging();
						this._OrderQty = value;
						this.SendPropertyChanged("OrderQty");
						this.OnOrderQtyChanged();
					}
					this.SendPropertySetterInvoked("OrderQty", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ProductID", DbType="Int NOT NULL", CanBeNull=false)]
			public int ProductID
			{
				get
				{
					return this._ProductID;
				}
				set
				{
					if (this._ProductID != value)
					{
						this.OnProductIDChanging(value);
						this.SendPropertyChanging();
						this._ProductID = value;
						this.SendPropertyChanged("ProductID");
						this.OnProductIDChanged();
					}
					this.SendPropertySetterInvoked("ProductID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_SpecialOfferID", DbType="Int NOT NULL", CanBeNull=false)]
			public int SpecialOfferID
			{
				get
				{
					return this._SpecialOfferID;
				}
				set
				{
					if (this._SpecialOfferID != value)
					{
						this.OnSpecialOfferIDChanging(value);
						this.SendPropertyChanging();
						this._SpecialOfferID = value;
						this.SendPropertyChanged("SpecialOfferID");
						this.OnSpecialOfferIDChanged();
					}
					this.SendPropertySetterInvoked("SpecialOfferID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Money NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_UnitPrice", DbType="Money NOT NULL", CanBeNull=false)]
			public decimal UnitPrice
			{
				get
				{
					return this._UnitPrice;
				}
				set
				{
					if (this._UnitPrice != value)
					{
						this.OnUnitPriceChanging(value);
						this.SendPropertyChanging();
						this._UnitPrice = value;
						this.SendPropertyChanged("UnitPrice");
						this.OnUnitPriceChanged();
					}
					this.SendPropertySetterInvoked("UnitPrice", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Money NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_UnitPriceDiscount", DbType="Money NOT NULL", CanBeNull=false)]
			public decimal UnitPriceDiscount
			{
				get
				{
					return this._UnitPriceDiscount;
				}
				set
				{
					if (this._UnitPriceDiscount != value)
					{
						this.OnUnitPriceDiscountChanging(value);
						this.SendPropertyChanging();
						this._UnitPriceDiscount = value;
						this.SendPropertyChanged("UnitPriceDiscount");
						this.OnUnitPriceDiscountChanged();
					}
					this.SendPropertySetterInvoked("UnitPriceDiscount", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Decimal(38,6) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_LineTotal", DbType="Decimal(38,6) NOT NULL", CanBeNull=false)]
			public decimal LineTotal
			{
				get
				{
					return this._LineTotal;
				}
				set
				{
					if (this._LineTotal != value)
					{
						this.OnLineTotalChanging(value);
						this.SendPropertyChanging();
						this._LineTotal = value;
						this.SendPropertyChanged("LineTotal");
						this.OnLineTotalChanged();
					}
					this.SendPropertySetterInvoked("LineTotal", value);
				}
			}
			
			/// <summary>
			/// Column DbType=UniqueIdentifier NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_rowguid", DbType="UniqueIdentifier NOT NULL", CanBeNull=false)]
			public System.Guid rowguid
			{
				get
				{
					return this._rowguid;
				}
				set
				{
					if (this._rowguid != value)
					{
						this.OnrowguidChanging(value);
						this.SendPropertyChanging();
						this._rowguid = value;
						this.SendPropertyChanged("rowguid");
						this.OnrowguidChanged();
					}
					this.SendPropertySetterInvoked("rowguid", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ModifiedDate", DbType="DateTime NOT NULL", CanBeNull=false)]
			public DateTime ModifiedDate
			{
				get
				{
					return this._ModifiedDate;
				}
				set
				{
					if (this._ModifiedDate != value)
					{
						this.OnModifiedDateChanging(value);
						this.SendPropertyChanging();
						this._ModifiedDate = value;
						this.SendPropertyChanged("ModifiedDate");
						this.OnModifiedDateChanged();
					}
					this.SendPropertySetterInvoked("ModifiedDate", value);
				}
			}
			
			#endregion Columns

			#region Associations
			/// <summary>
			/// Association [FK][Many]Sales_SalesOrderDetail.SalesOrderID --- [PK][One]Sales_SalesOrderHeader.SalesOrderID
			/// </summary>
			[AssociationAttribute(Name="FK_SalesOrderDetail_SalesOrderHeader_SalesOrderID", Storage="_Sales_SalesOrderHeader", ThisKey="SalesOrderID", OtherKey="SalesOrderID", IsUnique=false, IsForeignKey=true, DeleteOnNull=true)]
			public Sales_SalesOrderHeader Sales_SalesOrderHeader
			{
				get
				{
					return this._Sales_SalesOrderHeader.Entity;
				}
				set
				{
					Sales_SalesOrderHeader previousValue = this._Sales_SalesOrderHeader.Entity;
					if ((previousValue != value) || (this._Sales_SalesOrderHeader.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._Sales_SalesOrderHeader.Entity = null;
							previousValue.Sales_SalesOrderDetailList.Remove(this);
						}
						this._Sales_SalesOrderHeader.Entity = value;
						if (value != null)
						{
							value.Sales_SalesOrderDetailList.Add(this);
							this._SalesOrderID = value.SalesOrderID;
						}
						else
						{
							this._SalesOrderID = default(int);
						}
						this.SendPropertyChanged("Sales_SalesOrderHeader");
					}
					this.SendPropertySetterInvoked("Sales_SalesOrderHeader", value);
				}
			}
			
			/// <summary>
			/// Association [FK][Many]Sales_SalesOrderDetail.SpecialOfferID --- [PK][One]Sales_SpecialOfferProduct.SpecialOfferID
			/// </summary>
			[AssociationAttribute(Name="FK_SalesOrderDetail_SpecialOfferProduct_SpecialOfferIDProductID", Storage="_Sales_SpecialOfferProduct", ThisKey="SpecialOfferID", OtherKey="SpecialOfferID", IsUnique=false, IsForeignKey=true)]
			public Sales_SpecialOfferProduct Sales_SpecialOfferProduct
			{
				get
				{
					return this._Sales_SpecialOfferProduct.Entity;
				}
				set
				{
					Sales_SpecialOfferProduct previousValue = this._Sales_SpecialOfferProduct.Entity;
					if ((previousValue != value) || (this._Sales_SpecialOfferProduct.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._Sales_SpecialOfferProduct.Entity = null;
							previousValue.Sales_SalesOrderDetailList.Remove(this);
						}
						this._Sales_SpecialOfferProduct.Entity = value;
						if (value != null)
						{
							value.Sales_SalesOrderDetailList.Add(this);
							this._SpecialOfferID = value.SpecialOfferID;
						}
						else
						{
							this._SpecialOfferID = default(int);
						}
						this.SendPropertyChanged("Sales_SpecialOfferProduct");
					}
					this.SendPropertySetterInvoked("Sales_SpecialOfferProduct", value);
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
		#endregion Sales.SalesOrderDetail

		#region Sales.SalesOrderHeader
		[TableAttribute(Name="Sales.SalesOrderHeader")]
		public partial class Sales_SalesOrderHeader : EntityBase<Sales_SalesOrderHeader, AdventureWorksDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private int _SalesOrderID;
			private byte _RevisionNumber;
			private DateTime _OrderDate;
			private DateTime _DueDate;
			private DateTime? _ShipDate;
			private byte _Status;
			private bool _OnlineOrderFlag;
			private string _SalesOrderNumber;
			private string _PurchaseOrderNumber;
			private string _AccountNumber;
			private int _CustomerID;
			private int _ContactID;
			private int? _SalesPersonID;
			private int? _TerritoryID;
			private int _BillToAddressID;
			private int _ShipToAddressID;
			private int _ShipMethodID;
			private int? _CreditCardID;
			private string _CreditCardApprovalCode;
			private int? _CurrencyRateID;
			private decimal _SubTotal;
			private decimal _TaxAmt;
			private decimal _Freight;
			private decimal _TotalDue;
			private string _Comment;
			private System.Guid _rowguid;
			private DateTime _ModifiedDate;
			private EntitySet<Sales_SalesOrderDetail> _Sales_SalesOrderDetailList;
			private EntityRef<Person_Address> _Person_Address;
			private EntityRef<Person_Address> _ShipToAddress;
			private EntityRef<Person_Contact> _Person_Contact;
			private EntityRef<Sales_CreditCard> _Sales_CreditCard;
			private EntityRef<Sales_CurrencyRate> _Sales_CurrencyRate;
			private EntityRef<Sales_Customer> _Sales_Customer;
			private EntityRef<Sales_SalesPerson> _Sales_SalesPerson;
			private EntityRef<Sales_SalesTerritory> _Sales_SalesTerritory;
			private EntityRef<Purchasing_ShipMethod> _Purchasing_ShipMethod;
			private EntitySet<Sales_SalesOrderHeaderSalesReason> _Sales_SalesOrderHeaderSalesReasonList;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnSalesOrderIDChanging(int value);
			partial void OnSalesOrderIDChanged();
			partial void OnRevisionNumberChanging(byte value);
			partial void OnRevisionNumberChanged();
			partial void OnOrderDateChanging(DateTime value);
			partial void OnOrderDateChanged();
			partial void OnDueDateChanging(DateTime value);
			partial void OnDueDateChanged();
			partial void OnShipDateChanging(DateTime? value);
			partial void OnShipDateChanged();
			partial void OnStatusChanging(byte value);
			partial void OnStatusChanged();
			partial void OnOnlineOrderFlagChanging(bool value);
			partial void OnOnlineOrderFlagChanged();
			partial void OnSalesOrderNumberChanging(string value);
			partial void OnSalesOrderNumberChanged();
			partial void OnPurchaseOrderNumberChanging(string value);
			partial void OnPurchaseOrderNumberChanged();
			partial void OnAccountNumberChanging(string value);
			partial void OnAccountNumberChanged();
			partial void OnCustomerIDChanging(int value);
			partial void OnCustomerIDChanged();
			partial void OnContactIDChanging(int value);
			partial void OnContactIDChanged();
			partial void OnSalesPersonIDChanging(int? value);
			partial void OnSalesPersonIDChanged();
			partial void OnTerritoryIDChanging(int? value);
			partial void OnTerritoryIDChanged();
			partial void OnBillToAddressIDChanging(int value);
			partial void OnBillToAddressIDChanged();
			partial void OnShipToAddressIDChanging(int value);
			partial void OnShipToAddressIDChanged();
			partial void OnShipMethodIDChanging(int value);
			partial void OnShipMethodIDChanged();
			partial void OnCreditCardIDChanging(int? value);
			partial void OnCreditCardIDChanged();
			partial void OnCreditCardApprovalCodeChanging(string value);
			partial void OnCreditCardApprovalCodeChanged();
			partial void OnCurrencyRateIDChanging(int? value);
			partial void OnCurrencyRateIDChanged();
			partial void OnSubTotalChanging(decimal value);
			partial void OnSubTotalChanged();
			partial void OnTaxAmtChanging(decimal value);
			partial void OnTaxAmtChanged();
			partial void OnFreightChanging(decimal value);
			partial void OnFreightChanged();
			partial void OnTotalDueChanging(decimal value);
			partial void OnTotalDueChanged();
			partial void OnCommentChanging(string value);
			partial void OnCommentChanged();
			partial void OnrowguidChanging(System.Guid value);
			partial void OnrowguidChanged();
			partial void OnModifiedDateChanging(DateTime value);
			partial void OnModifiedDateChanged();
			#endregion

			public Sales_SalesOrderHeader()
			{
				_Sales_SalesOrderDetailList = new EntitySet<Sales_SalesOrderDetail>(
					new Action<Sales_SalesOrderDetail>(item=>{this.SendPropertyChanging(); item.Sales_SalesOrderHeader=this;}), 
					new Action<Sales_SalesOrderDetail>(item=>{this.SendPropertyChanging(); item.Sales_SalesOrderHeader=null;}));
				_Person_Address = default(EntityRef<Person_Address>);
				_ShipToAddress = default(EntityRef<Person_Address>);
				_Person_Contact = default(EntityRef<Person_Contact>);
				_Sales_CreditCard = default(EntityRef<Sales_CreditCard>);
				_Sales_CurrencyRate = default(EntityRef<Sales_CurrencyRate>);
				_Sales_Customer = default(EntityRef<Sales_Customer>);
				_Sales_SalesPerson = default(EntityRef<Sales_SalesPerson>);
				_Sales_SalesTerritory = default(EntityRef<Sales_SalesTerritory>);
				_Purchasing_ShipMethod = default(EntityRef<Purchasing_ShipMethod>);
				_Sales_SalesOrderHeaderSalesReasonList = new EntitySet<Sales_SalesOrderHeaderSalesReason>(
					new Action<Sales_SalesOrderHeaderSalesReason>(item=>{this.SendPropertyChanging(); item.Sales_SalesOrderHeader=this;}), 
					new Action<Sales_SalesOrderHeaderSalesReason>(item=>{this.SendPropertyChanging(); item.Sales_SalesOrderHeader=null;}));
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=Int NOT NULL IDENTITY
			/// </summary>
			[ColumnAttribute(Storage="_SalesOrderID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", CanBeNull=false, IsPrimaryKey=true, IsDbGenerated=true)]
			public int SalesOrderID
			{
				get
				{
					return this._SalesOrderID;
				}
				set
				{
					if (this._SalesOrderID != value)
					{
						this.OnSalesOrderIDChanging(value);
						this.SendPropertyChanging();
						this._SalesOrderID = value;
						this.SendPropertyChanged("SalesOrderID");
						this.OnSalesOrderIDChanged();
					}
					this.SendPropertySetterInvoked("SalesOrderID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=TinyInt NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_RevisionNumber", DbType="TinyInt NOT NULL", CanBeNull=false)]
			public byte RevisionNumber
			{
				get
				{
					return this._RevisionNumber;
				}
				set
				{
					if (this._RevisionNumber != value)
					{
						this.OnRevisionNumberChanging(value);
						this.SendPropertyChanging();
						this._RevisionNumber = value;
						this.SendPropertyChanged("RevisionNumber");
						this.OnRevisionNumberChanged();
					}
					this.SendPropertySetterInvoked("RevisionNumber", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_OrderDate", DbType="DateTime NOT NULL", CanBeNull=false)]
			public DateTime OrderDate
			{
				get
				{
					return this._OrderDate;
				}
				set
				{
					if (this._OrderDate != value)
					{
						this.OnOrderDateChanging(value);
						this.SendPropertyChanging();
						this._OrderDate = value;
						this.SendPropertyChanged("OrderDate");
						this.OnOrderDateChanged();
					}
					this.SendPropertySetterInvoked("OrderDate", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_DueDate", DbType="DateTime NOT NULL", CanBeNull=false)]
			public DateTime DueDate
			{
				get
				{
					return this._DueDate;
				}
				set
				{
					if (this._DueDate != value)
					{
						this.OnDueDateChanging(value);
						this.SendPropertyChanging();
						this._DueDate = value;
						this.SendPropertyChanged("DueDate");
						this.OnDueDateChanged();
					}
					this.SendPropertySetterInvoked("DueDate", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime
			/// </summary>
			[ColumnAttribute(Storage="_ShipDate", DbType="DateTime", CanBeNull=true)]
			public DateTime? ShipDate
			{
				get
				{
					return this._ShipDate;
				}
				set
				{
					if (this._ShipDate != value)
					{
						this.OnShipDateChanging(value);
						this.SendPropertyChanging();
						this._ShipDate = value;
						this.SendPropertyChanged("ShipDate");
						this.OnShipDateChanged();
					}
					this.SendPropertySetterInvoked("ShipDate", value);
				}
			}
			
			/// <summary>
			/// Column DbType=TinyInt NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_Status", DbType="TinyInt NOT NULL", CanBeNull=false)]
			public byte Status
			{
				get
				{
					return this._Status;
				}
				set
				{
					if (this._Status != value)
					{
						this.OnStatusChanging(value);
						this.SendPropertyChanging();
						this._Status = value;
						this.SendPropertyChanged("Status");
						this.OnStatusChanged();
					}
					this.SendPropertySetterInvoked("Status", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Bit NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_OnlineOrderFlag", DbType="Bit NOT NULL", CanBeNull=false)]
			public bool OnlineOrderFlag
			{
				get
				{
					return this._OnlineOrderFlag;
				}
				set
				{
					if (this._OnlineOrderFlag != value)
					{
						this.OnOnlineOrderFlagChanging(value);
						this.SendPropertyChanging();
						this._OnlineOrderFlag = value;
						this.SendPropertyChanged("OnlineOrderFlag");
						this.OnOnlineOrderFlagChanged();
					}
					this.SendPropertySetterInvoked("OnlineOrderFlag", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(25) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_SalesOrderNumber", DbType="NVarChar(25) NOT NULL", CanBeNull=false)]
			public string SalesOrderNumber
			{
				get
				{
					return this._SalesOrderNumber;
				}
				set
				{
					if (this._SalesOrderNumber != value)
					{
						this.OnSalesOrderNumberChanging(value);
						this.SendPropertyChanging();
						this._SalesOrderNumber = value;
						this.SendPropertyChanged("SalesOrderNumber");
						this.OnSalesOrderNumberChanged();
					}
					this.SendPropertySetterInvoked("SalesOrderNumber", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(25)
			/// </summary>
			[ColumnAttribute(Storage="_PurchaseOrderNumber", DbType="NVarChar(25)", CanBeNull=true)]
			public string PurchaseOrderNumber
			{
				get
				{
					return this._PurchaseOrderNumber;
				}
				set
				{
					if (this._PurchaseOrderNumber != value)
					{
						this.OnPurchaseOrderNumberChanging(value);
						this.SendPropertyChanging();
						this._PurchaseOrderNumber = value;
						this.SendPropertyChanged("PurchaseOrderNumber");
						this.OnPurchaseOrderNumberChanged();
					}
					this.SendPropertySetterInvoked("PurchaseOrderNumber", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(15)
			/// </summary>
			[ColumnAttribute(Storage="_AccountNumber", DbType="NVarChar(15)", CanBeNull=true)]
			public string AccountNumber
			{
				get
				{
					return this._AccountNumber;
				}
				set
				{
					if (this._AccountNumber != value)
					{
						this.OnAccountNumberChanging(value);
						this.SendPropertyChanging();
						this._AccountNumber = value;
						this.SendPropertyChanged("AccountNumber");
						this.OnAccountNumberChanged();
					}
					this.SendPropertySetterInvoked("AccountNumber", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_CustomerID", DbType="Int NOT NULL", CanBeNull=false)]
			public int CustomerID
			{
				get
				{
					return this._CustomerID;
				}
				set
				{
					if (this._CustomerID != value)
					{
						this.OnCustomerIDChanging(value);
						this.SendPropertyChanging();
						this._CustomerID = value;
						this.SendPropertyChanged("CustomerID");
						this.OnCustomerIDChanged();
					}
					this.SendPropertySetterInvoked("CustomerID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ContactID", DbType="Int NOT NULL", CanBeNull=false)]
			public int ContactID
			{
				get
				{
					return this._ContactID;
				}
				set
				{
					if (this._ContactID != value)
					{
						this.OnContactIDChanging(value);
						this.SendPropertyChanging();
						this._ContactID = value;
						this.SendPropertyChanged("ContactID");
						this.OnContactIDChanged();
					}
					this.SendPropertySetterInvoked("ContactID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int
			/// </summary>
			[ColumnAttribute(Storage="_SalesPersonID", DbType="Int", CanBeNull=true)]
			public int? SalesPersonID
			{
				get
				{
					return this._SalesPersonID;
				}
				set
				{
					if (this._SalesPersonID != value)
					{
						this.OnSalesPersonIDChanging(value);
						this.SendPropertyChanging();
						this._SalesPersonID = value;
						this.SendPropertyChanged("SalesPersonID");
						this.OnSalesPersonIDChanged();
					}
					this.SendPropertySetterInvoked("SalesPersonID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int
			/// </summary>
			[ColumnAttribute(Storage="_TerritoryID", DbType="Int", CanBeNull=true)]
			public int? TerritoryID
			{
				get
				{
					return this._TerritoryID;
				}
				set
				{
					if (this._TerritoryID != value)
					{
						this.OnTerritoryIDChanging(value);
						this.SendPropertyChanging();
						this._TerritoryID = value;
						this.SendPropertyChanged("TerritoryID");
						this.OnTerritoryIDChanged();
					}
					this.SendPropertySetterInvoked("TerritoryID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_BillToAddressID", DbType="Int NOT NULL", CanBeNull=false)]
			public int BillToAddressID
			{
				get
				{
					return this._BillToAddressID;
				}
				set
				{
					if (this._BillToAddressID != value)
					{
						this.OnBillToAddressIDChanging(value);
						this.SendPropertyChanging();
						this._BillToAddressID = value;
						this.SendPropertyChanged("BillToAddressID");
						this.OnBillToAddressIDChanged();
					}
					this.SendPropertySetterInvoked("BillToAddressID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ShipToAddressID", DbType="Int NOT NULL", CanBeNull=false)]
			public int ShipToAddressID
			{
				get
				{
					return this._ShipToAddressID;
				}
				set
				{
					if (this._ShipToAddressID != value)
					{
						this.OnShipToAddressIDChanging(value);
						this.SendPropertyChanging();
						this._ShipToAddressID = value;
						this.SendPropertyChanged("ShipToAddressID");
						this.OnShipToAddressIDChanged();
					}
					this.SendPropertySetterInvoked("ShipToAddressID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ShipMethodID", DbType="Int NOT NULL", CanBeNull=false)]
			public int ShipMethodID
			{
				get
				{
					return this._ShipMethodID;
				}
				set
				{
					if (this._ShipMethodID != value)
					{
						this.OnShipMethodIDChanging(value);
						this.SendPropertyChanging();
						this._ShipMethodID = value;
						this.SendPropertyChanged("ShipMethodID");
						this.OnShipMethodIDChanged();
					}
					this.SendPropertySetterInvoked("ShipMethodID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int
			/// </summary>
			[ColumnAttribute(Storage="_CreditCardID", DbType="Int", CanBeNull=true)]
			public int? CreditCardID
			{
				get
				{
					return this._CreditCardID;
				}
				set
				{
					if (this._CreditCardID != value)
					{
						this.OnCreditCardIDChanging(value);
						this.SendPropertyChanging();
						this._CreditCardID = value;
						this.SendPropertyChanged("CreditCardID");
						this.OnCreditCardIDChanged();
					}
					this.SendPropertySetterInvoked("CreditCardID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=VarChar(15)
			/// </summary>
			[ColumnAttribute(Storage="_CreditCardApprovalCode", DbType="VarChar(15)", CanBeNull=true)]
			public string CreditCardApprovalCode
			{
				get
				{
					return this._CreditCardApprovalCode;
				}
				set
				{
					if (this._CreditCardApprovalCode != value)
					{
						this.OnCreditCardApprovalCodeChanging(value);
						this.SendPropertyChanging();
						this._CreditCardApprovalCode = value;
						this.SendPropertyChanged("CreditCardApprovalCode");
						this.OnCreditCardApprovalCodeChanged();
					}
					this.SendPropertySetterInvoked("CreditCardApprovalCode", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int
			/// </summary>
			[ColumnAttribute(Storage="_CurrencyRateID", DbType="Int", CanBeNull=true)]
			public int? CurrencyRateID
			{
				get
				{
					return this._CurrencyRateID;
				}
				set
				{
					if (this._CurrencyRateID != value)
					{
						this.OnCurrencyRateIDChanging(value);
						this.SendPropertyChanging();
						this._CurrencyRateID = value;
						this.SendPropertyChanged("CurrencyRateID");
						this.OnCurrencyRateIDChanged();
					}
					this.SendPropertySetterInvoked("CurrencyRateID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Money NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_SubTotal", DbType="Money NOT NULL", CanBeNull=false)]
			public decimal SubTotal
			{
				get
				{
					return this._SubTotal;
				}
				set
				{
					if (this._SubTotal != value)
					{
						this.OnSubTotalChanging(value);
						this.SendPropertyChanging();
						this._SubTotal = value;
						this.SendPropertyChanged("SubTotal");
						this.OnSubTotalChanged();
					}
					this.SendPropertySetterInvoked("SubTotal", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Money NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_TaxAmt", DbType="Money NOT NULL", CanBeNull=false)]
			public decimal TaxAmt
			{
				get
				{
					return this._TaxAmt;
				}
				set
				{
					if (this._TaxAmt != value)
					{
						this.OnTaxAmtChanging(value);
						this.SendPropertyChanging();
						this._TaxAmt = value;
						this.SendPropertyChanged("TaxAmt");
						this.OnTaxAmtChanged();
					}
					this.SendPropertySetterInvoked("TaxAmt", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Money NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_Freight", DbType="Money NOT NULL", CanBeNull=false)]
			public decimal Freight
			{
				get
				{
					return this._Freight;
				}
				set
				{
					if (this._Freight != value)
					{
						this.OnFreightChanging(value);
						this.SendPropertyChanging();
						this._Freight = value;
						this.SendPropertyChanged("Freight");
						this.OnFreightChanged();
					}
					this.SendPropertySetterInvoked("Freight", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Money NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_TotalDue", DbType="Money NOT NULL", CanBeNull=false)]
			public decimal TotalDue
			{
				get
				{
					return this._TotalDue;
				}
				set
				{
					if (this._TotalDue != value)
					{
						this.OnTotalDueChanging(value);
						this.SendPropertyChanging();
						this._TotalDue = value;
						this.SendPropertyChanged("TotalDue");
						this.OnTotalDueChanged();
					}
					this.SendPropertySetterInvoked("TotalDue", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(128)
			/// </summary>
			[ColumnAttribute(Storage="_Comment", DbType="NVarChar(128)", CanBeNull=true)]
			public string Comment
			{
				get
				{
					return this._Comment;
				}
				set
				{
					if (this._Comment != value)
					{
						this.OnCommentChanging(value);
						this.SendPropertyChanging();
						this._Comment = value;
						this.SendPropertyChanged("Comment");
						this.OnCommentChanged();
					}
					this.SendPropertySetterInvoked("Comment", value);
				}
			}
			
			/// <summary>
			/// Column DbType=UniqueIdentifier NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_rowguid", DbType="UniqueIdentifier NOT NULL", CanBeNull=false)]
			public System.Guid rowguid
			{
				get
				{
					return this._rowguid;
				}
				set
				{
					if (this._rowguid != value)
					{
						this.OnrowguidChanging(value);
						this.SendPropertyChanging();
						this._rowguid = value;
						this.SendPropertyChanged("rowguid");
						this.OnrowguidChanged();
					}
					this.SendPropertySetterInvoked("rowguid", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ModifiedDate", DbType="DateTime NOT NULL", CanBeNull=false)]
			public DateTime ModifiedDate
			{
				get
				{
					return this._ModifiedDate;
				}
				set
				{
					if (this._ModifiedDate != value)
					{
						this.OnModifiedDateChanging(value);
						this.SendPropertyChanging();
						this._ModifiedDate = value;
						this.SendPropertyChanged("ModifiedDate");
						this.OnModifiedDateChanged();
					}
					this.SendPropertySetterInvoked("ModifiedDate", value);
				}
			}
			
			#endregion Columns

			#region Associations
			/// <summary>
			/// Association [PK][One]Sales_SalesOrderHeader.SalesOrderID --- [FK][Many]Sales_SalesOrderDetail.SalesOrderID
			/// </summary>
			[AssociationAttribute(Name="FK_SalesOrderDetail_SalesOrderHeader_SalesOrderID", Storage="_Sales_SalesOrderDetailList", ThisKey="SalesOrderID", OtherKey="SalesOrderID", IsUnique=false, IsForeignKey=false, DeleteRule="Cascade")]
			public EntitySet<Sales_SalesOrderDetail> Sales_SalesOrderDetailList
			{
				get { return this._Sales_SalesOrderDetailList; }
				set { this._Sales_SalesOrderDetailList.Assign(value); }
			}
			
			/// <summary>
			/// Association [FK][Many]Sales_SalesOrderHeader.BillToAddressID --- [PK][One]Person_Address.AddressID
			/// </summary>
			[AssociationAttribute(Name="FK_SalesOrderHeader_Address_BillToAddressID", Storage="_Person_Address", ThisKey="BillToAddressID", OtherKey="AddressID", IsUnique=false, IsForeignKey=true)]
			public Person_Address Person_Address
			{
				get
				{
					return this._Person_Address.Entity;
				}
				set
				{
					Person_Address previousValue = this._Person_Address.Entity;
					if ((previousValue != value) || (this._Person_Address.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._Person_Address.Entity = null;
							previousValue.Sales_SalesOrderHeaderList.Remove(this);
						}
						this._Person_Address.Entity = value;
						if (value != null)
						{
							value.Sales_SalesOrderHeaderList.Add(this);
							this._BillToAddressID = value.AddressID;
						}
						else
						{
							this._BillToAddressID = default(int);
						}
						this.SendPropertyChanged("Person_Address");
					}
					this.SendPropertySetterInvoked("Person_Address", value);
				}
			}
			
			/// <summary>
			/// Association [FK][Many]Sales_SalesOrderHeader.ShipToAddressID --- [PK][One]Person_Address.AddressID
			/// </summary>
			[AssociationAttribute(Name="FK_SalesOrderHeader_Address_ShipToAddressID", Storage="_ShipToAddress", ThisKey="ShipToAddressID", OtherKey="AddressID", IsUnique=false, IsForeignKey=true)]
			public Person_Address ShipToAddress
			{
				get
				{
					return this._ShipToAddress.Entity;
				}
				set
				{
					Person_Address previousValue = this._ShipToAddress.Entity;
					if ((previousValue != value) || (this._ShipToAddress.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._ShipToAddress.Entity = null;
							previousValue.AddressList.Remove(this);
						}
						this._ShipToAddress.Entity = value;
						if (value != null)
						{
							value.AddressList.Add(this);
							this._ShipToAddressID = value.AddressID;
						}
						else
						{
							this._ShipToAddressID = default(int);
						}
						this.SendPropertyChanged("ShipToAddress");
					}
					this.SendPropertySetterInvoked("ShipToAddress", value);
				}
			}
			
			/// <summary>
			/// Association [FK][Many]Sales_SalesOrderHeader.ContactID --- [PK][One]Person_Contact.ContactID
			/// </summary>
			[AssociationAttribute(Name="FK_SalesOrderHeader_Contact_ContactID", Storage="_Person_Contact", ThisKey="ContactID", OtherKey="ContactID", IsUnique=false, IsForeignKey=true)]
			public Person_Contact Person_Contact
			{
				get
				{
					return this._Person_Contact.Entity;
				}
				set
				{
					Person_Contact previousValue = this._Person_Contact.Entity;
					if ((previousValue != value) || (this._Person_Contact.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._Person_Contact.Entity = null;
							previousValue.Sales_SalesOrderHeaderList.Remove(this);
						}
						this._Person_Contact.Entity = value;
						if (value != null)
						{
							value.Sales_SalesOrderHeaderList.Add(this);
							this._ContactID = value.ContactID;
						}
						else
						{
							this._ContactID = default(int);
						}
						this.SendPropertyChanged("Person_Contact");
					}
					this.SendPropertySetterInvoked("Person_Contact", value);
				}
			}
			
			/// <summary>
			/// Association [FK][Many]Sales_SalesOrderHeader.CreditCardID --- [PK][One]Sales_CreditCard.CreditCardID
			/// </summary>
			[AssociationAttribute(Name="FK_SalesOrderHeader_CreditCard_CreditCardID", Storage="_Sales_CreditCard", ThisKey="CreditCardID", OtherKey="CreditCardID", IsUnique=false, IsForeignKey=true)]
			public Sales_CreditCard Sales_CreditCard
			{
				get
				{
					return this._Sales_CreditCard.Entity;
				}
				set
				{
					Sales_CreditCard previousValue = this._Sales_CreditCard.Entity;
					if ((previousValue != value) || (this._Sales_CreditCard.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._Sales_CreditCard.Entity = null;
							previousValue.Sales_SalesOrderHeaderList.Remove(this);
						}
						this._Sales_CreditCard.Entity = value;
						if (value != null)
						{
							value.Sales_SalesOrderHeaderList.Add(this);
							this._CreditCardID = value.CreditCardID;
						}
						else
						{
							this._CreditCardID = default(int?);
						}
						this.SendPropertyChanged("Sales_CreditCard");
					}
					this.SendPropertySetterInvoked("Sales_CreditCard", value);
				}
			}
			
			/// <summary>
			/// Association [FK][Many]Sales_SalesOrderHeader.CurrencyRateID --- [PK][One]Sales_CurrencyRate.CurrencyRateID
			/// </summary>
			[AssociationAttribute(Name="FK_SalesOrderHeader_CurrencyRate_CurrencyRateID", Storage="_Sales_CurrencyRate", ThisKey="CurrencyRateID", OtherKey="CurrencyRateID", IsUnique=false, IsForeignKey=true)]
			public Sales_CurrencyRate Sales_CurrencyRate
			{
				get
				{
					return this._Sales_CurrencyRate.Entity;
				}
				set
				{
					Sales_CurrencyRate previousValue = this._Sales_CurrencyRate.Entity;
					if ((previousValue != value) || (this._Sales_CurrencyRate.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._Sales_CurrencyRate.Entity = null;
							previousValue.Sales_SalesOrderHeaderList.Remove(this);
						}
						this._Sales_CurrencyRate.Entity = value;
						if (value != null)
						{
							value.Sales_SalesOrderHeaderList.Add(this);
							this._CurrencyRateID = value.CurrencyRateID;
						}
						else
						{
							this._CurrencyRateID = default(int?);
						}
						this.SendPropertyChanged("Sales_CurrencyRate");
					}
					this.SendPropertySetterInvoked("Sales_CurrencyRate", value);
				}
			}
			
			/// <summary>
			/// Association [FK][Many]Sales_SalesOrderHeader.CustomerID --- [PK][One]Sales_Customer.CustomerID
			/// </summary>
			[AssociationAttribute(Name="FK_SalesOrderHeader_Customer_CustomerID", Storage="_Sales_Customer", ThisKey="CustomerID", OtherKey="CustomerID", IsUnique=false, IsForeignKey=true)]
			public Sales_Customer Sales_Customer
			{
				get
				{
					return this._Sales_Customer.Entity;
				}
				set
				{
					Sales_Customer previousValue = this._Sales_Customer.Entity;
					if ((previousValue != value) || (this._Sales_Customer.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._Sales_Customer.Entity = null;
							previousValue.Sales_SalesOrderHeaderList.Remove(this);
						}
						this._Sales_Customer.Entity = value;
						if (value != null)
						{
							value.Sales_SalesOrderHeaderList.Add(this);
							this._CustomerID = value.CustomerID;
						}
						else
						{
							this._CustomerID = default(int);
						}
						this.SendPropertyChanged("Sales_Customer");
					}
					this.SendPropertySetterInvoked("Sales_Customer", value);
				}
			}
			
			/// <summary>
			/// Association [FK][Many]Sales_SalesOrderHeader.SalesPersonID --- [PK][One]Sales_SalesPerson.SalesPersonID
			/// </summary>
			[AssociationAttribute(Name="FK_SalesOrderHeader_SalesPerson_SalesPersonID", Storage="_Sales_SalesPerson", ThisKey="SalesPersonID", OtherKey="SalesPersonID", IsUnique=false, IsForeignKey=true)]
			public Sales_SalesPerson Sales_SalesPerson
			{
				get
				{
					return this._Sales_SalesPerson.Entity;
				}
				set
				{
					Sales_SalesPerson previousValue = this._Sales_SalesPerson.Entity;
					if ((previousValue != value) || (this._Sales_SalesPerson.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._Sales_SalesPerson.Entity = null;
							previousValue.Sales_SalesOrderHeaderList.Remove(this);
						}
						this._Sales_SalesPerson.Entity = value;
						if (value != null)
						{
							value.Sales_SalesOrderHeaderList.Add(this);
							this._SalesPersonID = value.SalesPersonID;
						}
						else
						{
							this._SalesPersonID = default(int?);
						}
						this.SendPropertyChanged("Sales_SalesPerson");
					}
					this.SendPropertySetterInvoked("Sales_SalesPerson", value);
				}
			}
			
			/// <summary>
			/// Association [FK][Many]Sales_SalesOrderHeader.TerritoryID --- [PK][One]Sales_SalesTerritory.TerritoryID
			/// </summary>
			[AssociationAttribute(Name="FK_SalesOrderHeader_SalesTerritory_TerritoryID", Storage="_Sales_SalesTerritory", ThisKey="TerritoryID", OtherKey="TerritoryID", IsUnique=false, IsForeignKey=true)]
			public Sales_SalesTerritory Sales_SalesTerritory
			{
				get
				{
					return this._Sales_SalesTerritory.Entity;
				}
				set
				{
					Sales_SalesTerritory previousValue = this._Sales_SalesTerritory.Entity;
					if ((previousValue != value) || (this._Sales_SalesTerritory.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._Sales_SalesTerritory.Entity = null;
							previousValue.Sales_SalesOrderHeaderList.Remove(this);
						}
						this._Sales_SalesTerritory.Entity = value;
						if (value != null)
						{
							value.Sales_SalesOrderHeaderList.Add(this);
							this._TerritoryID = value.TerritoryID;
						}
						else
						{
							this._TerritoryID = default(int?);
						}
						this.SendPropertyChanged("Sales_SalesTerritory");
					}
					this.SendPropertySetterInvoked("Sales_SalesTerritory", value);
				}
			}
			
			/// <summary>
			/// Association [FK][Many]Sales_SalesOrderHeader.ShipMethodID --- [PK][One]Purchasing_ShipMethod.ShipMethodID
			/// </summary>
			[AssociationAttribute(Name="FK_SalesOrderHeader_ShipMethod_ShipMethodID", Storage="_Purchasing_ShipMethod", ThisKey="ShipMethodID", OtherKey="ShipMethodID", IsUnique=false, IsForeignKey=true)]
			public Purchasing_ShipMethod Purchasing_ShipMethod
			{
				get
				{
					return this._Purchasing_ShipMethod.Entity;
				}
				set
				{
					Purchasing_ShipMethod previousValue = this._Purchasing_ShipMethod.Entity;
					if ((previousValue != value) || (this._Purchasing_ShipMethod.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._Purchasing_ShipMethod.Entity = null;
							previousValue.Sales_SalesOrderHeaderList.Remove(this);
						}
						this._Purchasing_ShipMethod.Entity = value;
						if (value != null)
						{
							value.Sales_SalesOrderHeaderList.Add(this);
							this._ShipMethodID = value.ShipMethodID;
						}
						else
						{
							this._ShipMethodID = default(int);
						}
						this.SendPropertyChanged("Purchasing_ShipMethod");
					}
					this.SendPropertySetterInvoked("Purchasing_ShipMethod", value);
				}
			}
			
			/// <summary>
			/// Association [PK][One]Sales_SalesOrderHeader.SalesOrderID --- [FK][Many]Sales_SalesOrderHeaderSalesReason.SalesOrderID
			/// </summary>
			[AssociationAttribute(Name="FK_SalesOrderHeaderSalesReason_SalesOrderHeader_SalesOrderID", Storage="_Sales_SalesOrderHeaderSalesReasonList", ThisKey="SalesOrderID", OtherKey="SalesOrderID", IsUnique=false, IsForeignKey=false, DeleteRule="Cascade")]
			public EntitySet<Sales_SalesOrderHeaderSalesReason> Sales_SalesOrderHeaderSalesReasonList
			{
				get { return this._Sales_SalesOrderHeaderSalesReasonList; }
				set { this._Sales_SalesOrderHeaderSalesReasonList.Assign(value); }
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
		#endregion Sales.SalesOrderHeader

		#region Sales.SalesOrderHeaderSalesReason
		[TableAttribute(Name="Sales.SalesOrderHeaderSalesReason")]
		public partial class Sales_SalesOrderHeaderSalesReason : EntityBase<Sales_SalesOrderHeaderSalesReason, AdventureWorksDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private int _SalesOrderID;
			private int _SalesReasonID;
			private DateTime _ModifiedDate;
			private EntityRef<Sales_SalesOrderHeader> _Sales_SalesOrderHeader;
			private EntityRef<Sales_SalesReason> _Sales_SalesReason;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnSalesOrderIDChanging(int value);
			partial void OnSalesOrderIDChanged();
			partial void OnSalesReasonIDChanging(int value);
			partial void OnSalesReasonIDChanged();
			partial void OnModifiedDateChanging(DateTime value);
			partial void OnModifiedDateChanged();
			#endregion

			public Sales_SalesOrderHeaderSalesReason()
			{
				_Sales_SalesOrderHeader = default(EntityRef<Sales_SalesOrderHeader>);
				_Sales_SalesReason = default(EntityRef<Sales_SalesReason>);
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_SalesOrderID", DbType="Int NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
			public int SalesOrderID
			{
				get
				{
					return this._SalesOrderID;
				}
				set
				{
					if (this._SalesOrderID != value)
					{
						this.OnSalesOrderIDChanging(value);
						this.SendPropertyChanging();
						this._SalesOrderID = value;
						this.SendPropertyChanged("SalesOrderID");
						this.OnSalesOrderIDChanged();
					}
					this.SendPropertySetterInvoked("SalesOrderID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_SalesReasonID", DbType="Int NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
			public int SalesReasonID
			{
				get
				{
					return this._SalesReasonID;
				}
				set
				{
					if (this._SalesReasonID != value)
					{
						this.OnSalesReasonIDChanging(value);
						this.SendPropertyChanging();
						this._SalesReasonID = value;
						this.SendPropertyChanged("SalesReasonID");
						this.OnSalesReasonIDChanged();
					}
					this.SendPropertySetterInvoked("SalesReasonID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ModifiedDate", DbType="DateTime NOT NULL", CanBeNull=false)]
			public DateTime ModifiedDate
			{
				get
				{
					return this._ModifiedDate;
				}
				set
				{
					if (this._ModifiedDate != value)
					{
						this.OnModifiedDateChanging(value);
						this.SendPropertyChanging();
						this._ModifiedDate = value;
						this.SendPropertyChanged("ModifiedDate");
						this.OnModifiedDateChanged();
					}
					this.SendPropertySetterInvoked("ModifiedDate", value);
				}
			}
			
			#endregion Columns

			#region Associations
			/// <summary>
			/// Association [FK][Many]Sales_SalesOrderHeaderSalesReason.SalesOrderID --- [PK][One]Sales_SalesOrderHeader.SalesOrderID
			/// </summary>
			[AssociationAttribute(Name="FK_SalesOrderHeaderSalesReason_SalesOrderHeader_SalesOrderID", Storage="_Sales_SalesOrderHeader", ThisKey="SalesOrderID", OtherKey="SalesOrderID", IsUnique=false, IsForeignKey=true, DeleteOnNull=true)]
			public Sales_SalesOrderHeader Sales_SalesOrderHeader
			{
				get
				{
					return this._Sales_SalesOrderHeader.Entity;
				}
				set
				{
					Sales_SalesOrderHeader previousValue = this._Sales_SalesOrderHeader.Entity;
					if ((previousValue != value) || (this._Sales_SalesOrderHeader.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._Sales_SalesOrderHeader.Entity = null;
							previousValue.Sales_SalesOrderHeaderSalesReasonList.Remove(this);
						}
						this._Sales_SalesOrderHeader.Entity = value;
						if (value != null)
						{
							value.Sales_SalesOrderHeaderSalesReasonList.Add(this);
							this._SalesOrderID = value.SalesOrderID;
						}
						else
						{
							this._SalesOrderID = default(int);
						}
						this.SendPropertyChanged("Sales_SalesOrderHeader");
					}
					this.SendPropertySetterInvoked("Sales_SalesOrderHeader", value);
				}
			}
			
			/// <summary>
			/// Association [FK][Many]Sales_SalesOrderHeaderSalesReason.SalesReasonID --- [PK][One]Sales_SalesReason.SalesReasonID
			/// </summary>
			[AssociationAttribute(Name="FK_SalesOrderHeaderSalesReason_SalesReason_SalesReasonID", Storage="_Sales_SalesReason", ThisKey="SalesReasonID", OtherKey="SalesReasonID", IsUnique=false, IsForeignKey=true)]
			public Sales_SalesReason Sales_SalesReason
			{
				get
				{
					return this._Sales_SalesReason.Entity;
				}
				set
				{
					Sales_SalesReason previousValue = this._Sales_SalesReason.Entity;
					if ((previousValue != value) || (this._Sales_SalesReason.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._Sales_SalesReason.Entity = null;
							previousValue.Sales_SalesOrderHeaderSalesReasonList.Remove(this);
						}
						this._Sales_SalesReason.Entity = value;
						if (value != null)
						{
							value.Sales_SalesOrderHeaderSalesReasonList.Add(this);
							this._SalesReasonID = value.SalesReasonID;
						}
						else
						{
							this._SalesReasonID = default(int);
						}
						this.SendPropertyChanged("Sales_SalesReason");
					}
					this.SendPropertySetterInvoked("Sales_SalesReason", value);
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
		#endregion Sales.SalesOrderHeaderSalesReason

		#region Sales.SalesPerson
		[TableAttribute(Name="Sales.SalesPerson")]
		public partial class Sales_SalesPerson : EntityBase<Sales_SalesPerson, AdventureWorksDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private int _SalesPersonID;
			private int? _TerritoryID;
			private decimal? _SalesQuota;
			private decimal _Bonus;
			private decimal _CommissionPct;
			private decimal _SalesYTD;
			private decimal _SalesLastYear;
			private System.Guid _rowguid;
			private DateTime _ModifiedDate;
			private EntitySet<Sales_SalesOrderHeader> _Sales_SalesOrderHeaderList;
			private EntityRef<HumanResources_Employee> _HumanResources_Employee;
			private EntityRef<Sales_SalesTerritory> _Sales_SalesTerritory;
			private EntitySet<Sales_SalesPersonQuotaHistory> _Sales_SalesPersonQuotaHistoryList;
			private EntitySet<Sales_SalesTerritoryHistory> _Sales_SalesTerritoryHistoryList;
			private EntitySet<Sales_Store> _Sales_StoreList;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnSalesPersonIDChanging(int value);
			partial void OnSalesPersonIDChanged();
			partial void OnTerritoryIDChanging(int? value);
			partial void OnTerritoryIDChanged();
			partial void OnSalesQuotaChanging(decimal? value);
			partial void OnSalesQuotaChanged();
			partial void OnBonusChanging(decimal value);
			partial void OnBonusChanged();
			partial void OnCommissionPctChanging(decimal value);
			partial void OnCommissionPctChanged();
			partial void OnSalesYTDChanging(decimal value);
			partial void OnSalesYTDChanged();
			partial void OnSalesLastYearChanging(decimal value);
			partial void OnSalesLastYearChanged();
			partial void OnrowguidChanging(System.Guid value);
			partial void OnrowguidChanged();
			partial void OnModifiedDateChanging(DateTime value);
			partial void OnModifiedDateChanged();
			#endregion

			public Sales_SalesPerson()
			{
				_Sales_SalesOrderHeaderList = new EntitySet<Sales_SalesOrderHeader>(
					new Action<Sales_SalesOrderHeader>(item=>{this.SendPropertyChanging(); item.Sales_SalesPerson=this;}), 
					new Action<Sales_SalesOrderHeader>(item=>{this.SendPropertyChanging(); item.Sales_SalesPerson=null;}));
				_HumanResources_Employee = default(EntityRef<HumanResources_Employee>);
				_Sales_SalesTerritory = default(EntityRef<Sales_SalesTerritory>);
				_Sales_SalesPersonQuotaHistoryList = new EntitySet<Sales_SalesPersonQuotaHistory>(
					new Action<Sales_SalesPersonQuotaHistory>(item=>{this.SendPropertyChanging(); item.Sales_SalesPerson=this;}), 
					new Action<Sales_SalesPersonQuotaHistory>(item=>{this.SendPropertyChanging(); item.Sales_SalesPerson=null;}));
				_Sales_SalesTerritoryHistoryList = new EntitySet<Sales_SalesTerritoryHistory>(
					new Action<Sales_SalesTerritoryHistory>(item=>{this.SendPropertyChanging(); item.Sales_SalesPerson=this;}), 
					new Action<Sales_SalesTerritoryHistory>(item=>{this.SendPropertyChanging(); item.Sales_SalesPerson=null;}));
				_Sales_StoreList = new EntitySet<Sales_Store>(
					new Action<Sales_Store>(item=>{this.SendPropertyChanging(); item.Sales_SalesPerson=this;}), 
					new Action<Sales_Store>(item=>{this.SendPropertyChanging(); item.Sales_SalesPerson=null;}));
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_SalesPersonID", DbType="Int NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
			public int SalesPersonID
			{
				get
				{
					return this._SalesPersonID;
				}
				set
				{
					if (this._SalesPersonID != value)
					{
						this.OnSalesPersonIDChanging(value);
						this.SendPropertyChanging();
						this._SalesPersonID = value;
						this.SendPropertyChanged("SalesPersonID");
						this.OnSalesPersonIDChanged();
					}
					this.SendPropertySetterInvoked("SalesPersonID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int
			/// </summary>
			[ColumnAttribute(Storage="_TerritoryID", DbType="Int", CanBeNull=true)]
			public int? TerritoryID
			{
				get
				{
					return this._TerritoryID;
				}
				set
				{
					if (this._TerritoryID != value)
					{
						this.OnTerritoryIDChanging(value);
						this.SendPropertyChanging();
						this._TerritoryID = value;
						this.SendPropertyChanged("TerritoryID");
						this.OnTerritoryIDChanged();
					}
					this.SendPropertySetterInvoked("TerritoryID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Money
			/// </summary>
			[ColumnAttribute(Storage="_SalesQuota", DbType="Money", CanBeNull=true)]
			public decimal? SalesQuota
			{
				get
				{
					return this._SalesQuota;
				}
				set
				{
					if (this._SalesQuota != value)
					{
						this.OnSalesQuotaChanging(value);
						this.SendPropertyChanging();
						this._SalesQuota = value;
						this.SendPropertyChanged("SalesQuota");
						this.OnSalesQuotaChanged();
					}
					this.SendPropertySetterInvoked("SalesQuota", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Money NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_Bonus", DbType="Money NOT NULL", CanBeNull=false)]
			public decimal Bonus
			{
				get
				{
					return this._Bonus;
				}
				set
				{
					if (this._Bonus != value)
					{
						this.OnBonusChanging(value);
						this.SendPropertyChanging();
						this._Bonus = value;
						this.SendPropertyChanged("Bonus");
						this.OnBonusChanged();
					}
					this.SendPropertySetterInvoked("Bonus", value);
				}
			}
			
			/// <summary>
			/// Column DbType=SmallMoney NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_CommissionPct", DbType="SmallMoney NOT NULL", CanBeNull=false)]
			public decimal CommissionPct
			{
				get
				{
					return this._CommissionPct;
				}
				set
				{
					if (this._CommissionPct != value)
					{
						this.OnCommissionPctChanging(value);
						this.SendPropertyChanging();
						this._CommissionPct = value;
						this.SendPropertyChanged("CommissionPct");
						this.OnCommissionPctChanged();
					}
					this.SendPropertySetterInvoked("CommissionPct", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Money NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_SalesYTD", DbType="Money NOT NULL", CanBeNull=false)]
			public decimal SalesYTD
			{
				get
				{
					return this._SalesYTD;
				}
				set
				{
					if (this._SalesYTD != value)
					{
						this.OnSalesYTDChanging(value);
						this.SendPropertyChanging();
						this._SalesYTD = value;
						this.SendPropertyChanged("SalesYTD");
						this.OnSalesYTDChanged();
					}
					this.SendPropertySetterInvoked("SalesYTD", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Money NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_SalesLastYear", DbType="Money NOT NULL", CanBeNull=false)]
			public decimal SalesLastYear
			{
				get
				{
					return this._SalesLastYear;
				}
				set
				{
					if (this._SalesLastYear != value)
					{
						this.OnSalesLastYearChanging(value);
						this.SendPropertyChanging();
						this._SalesLastYear = value;
						this.SendPropertyChanged("SalesLastYear");
						this.OnSalesLastYearChanged();
					}
					this.SendPropertySetterInvoked("SalesLastYear", value);
				}
			}
			
			/// <summary>
			/// Column DbType=UniqueIdentifier NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_rowguid", DbType="UniqueIdentifier NOT NULL", CanBeNull=false)]
			public System.Guid rowguid
			{
				get
				{
					return this._rowguid;
				}
				set
				{
					if (this._rowguid != value)
					{
						this.OnrowguidChanging(value);
						this.SendPropertyChanging();
						this._rowguid = value;
						this.SendPropertyChanged("rowguid");
						this.OnrowguidChanged();
					}
					this.SendPropertySetterInvoked("rowguid", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ModifiedDate", DbType="DateTime NOT NULL", CanBeNull=false)]
			public DateTime ModifiedDate
			{
				get
				{
					return this._ModifiedDate;
				}
				set
				{
					if (this._ModifiedDate != value)
					{
						this.OnModifiedDateChanging(value);
						this.SendPropertyChanging();
						this._ModifiedDate = value;
						this.SendPropertyChanged("ModifiedDate");
						this.OnModifiedDateChanged();
					}
					this.SendPropertySetterInvoked("ModifiedDate", value);
				}
			}
			
			#endregion Columns

			#region Associations
			/// <summary>
			/// Association [PK][One]Sales_SalesPerson.SalesPersonID --- [FK][Many]Sales_SalesOrderHeader.SalesPersonID
			/// </summary>
			[AssociationAttribute(Name="FK_SalesOrderHeader_SalesPerson_SalesPersonID", Storage="_Sales_SalesOrderHeaderList", ThisKey="SalesPersonID", OtherKey="SalesPersonID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<Sales_SalesOrderHeader> Sales_SalesOrderHeaderList
			{
				get { return this._Sales_SalesOrderHeaderList; }
				set { this._Sales_SalesOrderHeaderList.Assign(value); }
			}
			
			/// <summary>
			/// Association [FK][One]Sales_SalesPerson.SalesPersonID --- [PK][One]HumanResources_Employee.EmployeeID
			/// </summary>
			[AssociationAttribute(Name="FK_SalesPerson_Employee_SalesPersonID", Storage="_HumanResources_Employee", ThisKey="SalesPersonID", OtherKey="EmployeeID", IsUnique=true, IsForeignKey=true)]
			public HumanResources_Employee HumanResources_Employee
			{
				get
				{
					return this._HumanResources_Employee.Entity;
				}
				set
				{
					HumanResources_Employee previousValue = this._HumanResources_Employee.Entity;
					if ((previousValue != value) || (this._HumanResources_Employee.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._HumanResources_Employee.Entity = null;
							previousValue.Sales_SalesPerson = null;
						}
						this._HumanResources_Employee.Entity = value;
						if (value != null)
						{
							value.Sales_SalesPerson = this;
							this._SalesPersonID = value.EmployeeID;
						}
						else
						{
							this._SalesPersonID = default(int);
						}
						this.SendPropertyChanged("HumanResources_Employee");
					}
					this.SendPropertySetterInvoked("HumanResources_Employee", value);
				}
			}
			
			/// <summary>
			/// Association [FK][Many]Sales_SalesPerson.TerritoryID --- [PK][One]Sales_SalesTerritory.TerritoryID
			/// </summary>
			[AssociationAttribute(Name="FK_SalesPerson_SalesTerritory_TerritoryID", Storage="_Sales_SalesTerritory", ThisKey="TerritoryID", OtherKey="TerritoryID", IsUnique=false, IsForeignKey=true)]
			public Sales_SalesTerritory Sales_SalesTerritory
			{
				get
				{
					return this._Sales_SalesTerritory.Entity;
				}
				set
				{
					Sales_SalesTerritory previousValue = this._Sales_SalesTerritory.Entity;
					if ((previousValue != value) || (this._Sales_SalesTerritory.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._Sales_SalesTerritory.Entity = null;
							previousValue.Sales_SalesPersonList.Remove(this);
						}
						this._Sales_SalesTerritory.Entity = value;
						if (value != null)
						{
							value.Sales_SalesPersonList.Add(this);
							this._TerritoryID = value.TerritoryID;
						}
						else
						{
							this._TerritoryID = default(int?);
						}
						this.SendPropertyChanged("Sales_SalesTerritory");
					}
					this.SendPropertySetterInvoked("Sales_SalesTerritory", value);
				}
			}
			
			/// <summary>
			/// Association [PK][One]Sales_SalesPerson.SalesPersonID --- [FK][Many]Sales_SalesPersonQuotaHistory.SalesPersonID
			/// </summary>
			[AssociationAttribute(Name="FK_SalesPersonQuotaHistory_SalesPerson_SalesPersonID", Storage="_Sales_SalesPersonQuotaHistoryList", ThisKey="SalesPersonID", OtherKey="SalesPersonID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<Sales_SalesPersonQuotaHistory> Sales_SalesPersonQuotaHistoryList
			{
				get { return this._Sales_SalesPersonQuotaHistoryList; }
				set { this._Sales_SalesPersonQuotaHistoryList.Assign(value); }
			}
			
			/// <summary>
			/// Association [PK][One]Sales_SalesPerson.SalesPersonID --- [FK][Many]Sales_SalesTerritoryHistory.SalesPersonID
			/// </summary>
			[AssociationAttribute(Name="FK_SalesTerritoryHistory_SalesPerson_SalesPersonID", Storage="_Sales_SalesTerritoryHistoryList", ThisKey="SalesPersonID", OtherKey="SalesPersonID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<Sales_SalesTerritoryHistory> Sales_SalesTerritoryHistoryList
			{
				get { return this._Sales_SalesTerritoryHistoryList; }
				set { this._Sales_SalesTerritoryHistoryList.Assign(value); }
			}
			
			/// <summary>
			/// Association [PK][One]Sales_SalesPerson.SalesPersonID --- [FK][Many]Sales_Store.SalesPersonID
			/// </summary>
			[AssociationAttribute(Name="FK_Store_SalesPerson_SalesPersonID", Storage="_Sales_StoreList", ThisKey="SalesPersonID", OtherKey="SalesPersonID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<Sales_Store> Sales_StoreList
			{
				get { return this._Sales_StoreList; }
				set { this._Sales_StoreList.Assign(value); }
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
		#endregion Sales.SalesPerson

		#region Sales.SalesPersonQuotaHistory
		[TableAttribute(Name="Sales.SalesPersonQuotaHistory")]
		public partial class Sales_SalesPersonQuotaHistory : EntityBase<Sales_SalesPersonQuotaHistory, AdventureWorksDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private int _SalesPersonID;
			private DateTime _QuotaDate;
			private decimal _SalesQuota;
			private System.Guid _rowguid;
			private DateTime _ModifiedDate;
			private EntityRef<Sales_SalesPerson> _Sales_SalesPerson;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnSalesPersonIDChanging(int value);
			partial void OnSalesPersonIDChanged();
			partial void OnQuotaDateChanging(DateTime value);
			partial void OnQuotaDateChanged();
			partial void OnSalesQuotaChanging(decimal value);
			partial void OnSalesQuotaChanged();
			partial void OnrowguidChanging(System.Guid value);
			partial void OnrowguidChanged();
			partial void OnModifiedDateChanging(DateTime value);
			partial void OnModifiedDateChanged();
			#endregion

			public Sales_SalesPersonQuotaHistory()
			{
				_Sales_SalesPerson = default(EntityRef<Sales_SalesPerson>);
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_SalesPersonID", DbType="Int NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
			public int SalesPersonID
			{
				get
				{
					return this._SalesPersonID;
				}
				set
				{
					if (this._SalesPersonID != value)
					{
						this.OnSalesPersonIDChanging(value);
						this.SendPropertyChanging();
						this._SalesPersonID = value;
						this.SendPropertyChanged("SalesPersonID");
						this.OnSalesPersonIDChanged();
					}
					this.SendPropertySetterInvoked("SalesPersonID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_QuotaDate", DbType="DateTime NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
			public DateTime QuotaDate
			{
				get
				{
					return this._QuotaDate;
				}
				set
				{
					if (this._QuotaDate != value)
					{
						this.OnQuotaDateChanging(value);
						this.SendPropertyChanging();
						this._QuotaDate = value;
						this.SendPropertyChanged("QuotaDate");
						this.OnQuotaDateChanged();
					}
					this.SendPropertySetterInvoked("QuotaDate", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Money NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_SalesQuota", DbType="Money NOT NULL", CanBeNull=false)]
			public decimal SalesQuota
			{
				get
				{
					return this._SalesQuota;
				}
				set
				{
					if (this._SalesQuota != value)
					{
						this.OnSalesQuotaChanging(value);
						this.SendPropertyChanging();
						this._SalesQuota = value;
						this.SendPropertyChanged("SalesQuota");
						this.OnSalesQuotaChanged();
					}
					this.SendPropertySetterInvoked("SalesQuota", value);
				}
			}
			
			/// <summary>
			/// Column DbType=UniqueIdentifier NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_rowguid", DbType="UniqueIdentifier NOT NULL", CanBeNull=false)]
			public System.Guid rowguid
			{
				get
				{
					return this._rowguid;
				}
				set
				{
					if (this._rowguid != value)
					{
						this.OnrowguidChanging(value);
						this.SendPropertyChanging();
						this._rowguid = value;
						this.SendPropertyChanged("rowguid");
						this.OnrowguidChanged();
					}
					this.SendPropertySetterInvoked("rowguid", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ModifiedDate", DbType="DateTime NOT NULL", CanBeNull=false)]
			public DateTime ModifiedDate
			{
				get
				{
					return this._ModifiedDate;
				}
				set
				{
					if (this._ModifiedDate != value)
					{
						this.OnModifiedDateChanging(value);
						this.SendPropertyChanging();
						this._ModifiedDate = value;
						this.SendPropertyChanged("ModifiedDate");
						this.OnModifiedDateChanged();
					}
					this.SendPropertySetterInvoked("ModifiedDate", value);
				}
			}
			
			#endregion Columns

			#region Associations
			/// <summary>
			/// Association [FK][Many]Sales_SalesPersonQuotaHistory.SalesPersonID --- [PK][One]Sales_SalesPerson.SalesPersonID
			/// </summary>
			[AssociationAttribute(Name="FK_SalesPersonQuotaHistory_SalesPerson_SalesPersonID", Storage="_Sales_SalesPerson", ThisKey="SalesPersonID", OtherKey="SalesPersonID", IsUnique=false, IsForeignKey=true)]
			public Sales_SalesPerson Sales_SalesPerson
			{
				get
				{
					return this._Sales_SalesPerson.Entity;
				}
				set
				{
					Sales_SalesPerson previousValue = this._Sales_SalesPerson.Entity;
					if ((previousValue != value) || (this._Sales_SalesPerson.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._Sales_SalesPerson.Entity = null;
							previousValue.Sales_SalesPersonQuotaHistoryList.Remove(this);
						}
						this._Sales_SalesPerson.Entity = value;
						if (value != null)
						{
							value.Sales_SalesPersonQuotaHistoryList.Add(this);
							this._SalesPersonID = value.SalesPersonID;
						}
						else
						{
							this._SalesPersonID = default(int);
						}
						this.SendPropertyChanged("Sales_SalesPerson");
					}
					this.SendPropertySetterInvoked("Sales_SalesPerson", value);
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
		#endregion Sales.SalesPersonQuotaHistory

		#region Sales.SalesReason
		[TableAttribute(Name="Sales.SalesReason")]
		public partial class Sales_SalesReason : EntityBase<Sales_SalesReason, AdventureWorksDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private int _SalesReasonID;
			private string _Name;
			private string _ReasonType;
			private DateTime _ModifiedDate;
			private EntitySet<Sales_SalesOrderHeaderSalesReason> _Sales_SalesOrderHeaderSalesReasonList;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnSalesReasonIDChanging(int value);
			partial void OnSalesReasonIDChanged();
			partial void OnNameChanging(string value);
			partial void OnNameChanged();
			partial void OnReasonTypeChanging(string value);
			partial void OnReasonTypeChanged();
			partial void OnModifiedDateChanging(DateTime value);
			partial void OnModifiedDateChanged();
			#endregion

			public Sales_SalesReason()
			{
				_Sales_SalesOrderHeaderSalesReasonList = new EntitySet<Sales_SalesOrderHeaderSalesReason>(
					new Action<Sales_SalesOrderHeaderSalesReason>(item=>{this.SendPropertyChanging(); item.Sales_SalesReason=this;}), 
					new Action<Sales_SalesOrderHeaderSalesReason>(item=>{this.SendPropertyChanging(); item.Sales_SalesReason=null;}));
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=Int NOT NULL IDENTITY
			/// </summary>
			[ColumnAttribute(Storage="_SalesReasonID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", CanBeNull=false, IsPrimaryKey=true, IsDbGenerated=true)]
			public int SalesReasonID
			{
				get
				{
					return this._SalesReasonID;
				}
				set
				{
					if (this._SalesReasonID != value)
					{
						this.OnSalesReasonIDChanging(value);
						this.SendPropertyChanging();
						this._SalesReasonID = value;
						this.SendPropertyChanged("SalesReasonID");
						this.OnSalesReasonIDChanged();
					}
					this.SendPropertySetterInvoked("SalesReasonID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(50) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_Name", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
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
			/// Column DbType=NVarChar(50) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ReasonType", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
			public string ReasonType
			{
				get
				{
					return this._ReasonType;
				}
				set
				{
					if (this._ReasonType != value)
					{
						this.OnReasonTypeChanging(value);
						this.SendPropertyChanging();
						this._ReasonType = value;
						this.SendPropertyChanged("ReasonType");
						this.OnReasonTypeChanged();
					}
					this.SendPropertySetterInvoked("ReasonType", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ModifiedDate", DbType="DateTime NOT NULL", CanBeNull=false)]
			public DateTime ModifiedDate
			{
				get
				{
					return this._ModifiedDate;
				}
				set
				{
					if (this._ModifiedDate != value)
					{
						this.OnModifiedDateChanging(value);
						this.SendPropertyChanging();
						this._ModifiedDate = value;
						this.SendPropertyChanged("ModifiedDate");
						this.OnModifiedDateChanged();
					}
					this.SendPropertySetterInvoked("ModifiedDate", value);
				}
			}
			
			#endregion Columns

			#region Associations
			/// <summary>
			/// Association [PK][One]Sales_SalesReason.SalesReasonID --- [FK][Many]Sales_SalesOrderHeaderSalesReason.SalesReasonID
			/// </summary>
			[AssociationAttribute(Name="FK_SalesOrderHeaderSalesReason_SalesReason_SalesReasonID", Storage="_Sales_SalesOrderHeaderSalesReasonList", ThisKey="SalesReasonID", OtherKey="SalesReasonID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<Sales_SalesOrderHeaderSalesReason> Sales_SalesOrderHeaderSalesReasonList
			{
				get { return this._Sales_SalesOrderHeaderSalesReasonList; }
				set { this._Sales_SalesOrderHeaderSalesReasonList.Assign(value); }
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
		#endregion Sales.SalesReason

		#region Sales.SalesTaxRate
		[TableAttribute(Name="Sales.SalesTaxRate")]
		public partial class Sales_SalesTaxRate : EntityBase<Sales_SalesTaxRate, AdventureWorksDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private int _SalesTaxRateID;
			private int _StateProvinceID;
			private byte _TaxType;
			private decimal _TaxRate;
			private string _Name;
			private System.Guid _rowguid;
			private DateTime _ModifiedDate;
			private EntityRef<Person_StateProvince> _Person_StateProvince;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnSalesTaxRateIDChanging(int value);
			partial void OnSalesTaxRateIDChanged();
			partial void OnStateProvinceIDChanging(int value);
			partial void OnStateProvinceIDChanged();
			partial void OnTaxTypeChanging(byte value);
			partial void OnTaxTypeChanged();
			partial void OnTaxRateChanging(decimal value);
			partial void OnTaxRateChanged();
			partial void OnNameChanging(string value);
			partial void OnNameChanged();
			partial void OnrowguidChanging(System.Guid value);
			partial void OnrowguidChanged();
			partial void OnModifiedDateChanging(DateTime value);
			partial void OnModifiedDateChanged();
			#endregion

			public Sales_SalesTaxRate()
			{
				_Person_StateProvince = default(EntityRef<Person_StateProvince>);
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=Int NOT NULL IDENTITY
			/// </summary>
			[ColumnAttribute(Storage="_SalesTaxRateID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", CanBeNull=false, IsPrimaryKey=true, IsDbGenerated=true)]
			public int SalesTaxRateID
			{
				get
				{
					return this._SalesTaxRateID;
				}
				set
				{
					if (this._SalesTaxRateID != value)
					{
						this.OnSalesTaxRateIDChanging(value);
						this.SendPropertyChanging();
						this._SalesTaxRateID = value;
						this.SendPropertyChanged("SalesTaxRateID");
						this.OnSalesTaxRateIDChanged();
					}
					this.SendPropertySetterInvoked("SalesTaxRateID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_StateProvinceID", DbType="Int NOT NULL", CanBeNull=false)]
			public int StateProvinceID
			{
				get
				{
					return this._StateProvinceID;
				}
				set
				{
					if (this._StateProvinceID != value)
					{
						this.OnStateProvinceIDChanging(value);
						this.SendPropertyChanging();
						this._StateProvinceID = value;
						this.SendPropertyChanged("StateProvinceID");
						this.OnStateProvinceIDChanged();
					}
					this.SendPropertySetterInvoked("StateProvinceID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=TinyInt NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_TaxType", DbType="TinyInt NOT NULL", CanBeNull=false)]
			public byte TaxType
			{
				get
				{
					return this._TaxType;
				}
				set
				{
					if (this._TaxType != value)
					{
						this.OnTaxTypeChanging(value);
						this.SendPropertyChanging();
						this._TaxType = value;
						this.SendPropertyChanged("TaxType");
						this.OnTaxTypeChanged();
					}
					this.SendPropertySetterInvoked("TaxType", value);
				}
			}
			
			/// <summary>
			/// Column DbType=SmallMoney NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_TaxRate", DbType="SmallMoney NOT NULL", CanBeNull=false)]
			public decimal TaxRate
			{
				get
				{
					return this._TaxRate;
				}
				set
				{
					if (this._TaxRate != value)
					{
						this.OnTaxRateChanging(value);
						this.SendPropertyChanging();
						this._TaxRate = value;
						this.SendPropertyChanged("TaxRate");
						this.OnTaxRateChanged();
					}
					this.SendPropertySetterInvoked("TaxRate", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(50) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_Name", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
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
			/// Column DbType=UniqueIdentifier NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_rowguid", DbType="UniqueIdentifier NOT NULL", CanBeNull=false)]
			public System.Guid rowguid
			{
				get
				{
					return this._rowguid;
				}
				set
				{
					if (this._rowguid != value)
					{
						this.OnrowguidChanging(value);
						this.SendPropertyChanging();
						this._rowguid = value;
						this.SendPropertyChanged("rowguid");
						this.OnrowguidChanged();
					}
					this.SendPropertySetterInvoked("rowguid", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ModifiedDate", DbType="DateTime NOT NULL", CanBeNull=false)]
			public DateTime ModifiedDate
			{
				get
				{
					return this._ModifiedDate;
				}
				set
				{
					if (this._ModifiedDate != value)
					{
						this.OnModifiedDateChanging(value);
						this.SendPropertyChanging();
						this._ModifiedDate = value;
						this.SendPropertyChanged("ModifiedDate");
						this.OnModifiedDateChanged();
					}
					this.SendPropertySetterInvoked("ModifiedDate", value);
				}
			}
			
			#endregion Columns

			#region Associations
			/// <summary>
			/// Association [FK][Many]Sales_SalesTaxRate.StateProvinceID --- [PK][One]Person_StateProvince.StateProvinceID
			/// </summary>
			[AssociationAttribute(Name="FK_SalesTaxRate_StateProvince_StateProvinceID", Storage="_Person_StateProvince", ThisKey="StateProvinceID", OtherKey="StateProvinceID", IsUnique=false, IsForeignKey=true)]
			public Person_StateProvince Person_StateProvince
			{
				get
				{
					return this._Person_StateProvince.Entity;
				}
				set
				{
					Person_StateProvince previousValue = this._Person_StateProvince.Entity;
					if ((previousValue != value) || (this._Person_StateProvince.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._Person_StateProvince.Entity = null;
							previousValue.Sales_SalesTaxRateList.Remove(this);
						}
						this._Person_StateProvince.Entity = value;
						if (value != null)
						{
							value.Sales_SalesTaxRateList.Add(this);
							this._StateProvinceID = value.StateProvinceID;
						}
						else
						{
							this._StateProvinceID = default(int);
						}
						this.SendPropertyChanged("Person_StateProvince");
					}
					this.SendPropertySetterInvoked("Person_StateProvince", value);
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
		#endregion Sales.SalesTaxRate

		#region Sales.SalesTerritory
		[TableAttribute(Name="Sales.SalesTerritory")]
		public partial class Sales_SalesTerritory : EntityBase<Sales_SalesTerritory, AdventureWorksDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private int _TerritoryID;
			private string _Name;
			private string _CountryRegionCode;
			private string _Group;
			private decimal _SalesYTD;
			private decimal _SalesLastYear;
			private decimal _CostYTD;
			private decimal _CostLastYear;
			private System.Guid _rowguid;
			private DateTime _ModifiedDate;
			private EntitySet<Person_StateProvince> _Person_StateProvinceList;
			private EntitySet<Sales_Customer> _Sales_CustomerList;
			private EntitySet<Sales_SalesOrderHeader> _Sales_SalesOrderHeaderList;
			private EntitySet<Sales_SalesPerson> _Sales_SalesPersonList;
			private EntitySet<Sales_SalesTerritoryHistory> _Sales_SalesTerritoryHistoryList;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnTerritoryIDChanging(int value);
			partial void OnTerritoryIDChanged();
			partial void OnNameChanging(string value);
			partial void OnNameChanged();
			partial void OnCountryRegionCodeChanging(string value);
			partial void OnCountryRegionCodeChanged();
			partial void OnGroupChanging(string value);
			partial void OnGroupChanged();
			partial void OnSalesYTDChanging(decimal value);
			partial void OnSalesYTDChanged();
			partial void OnSalesLastYearChanging(decimal value);
			partial void OnSalesLastYearChanged();
			partial void OnCostYTDChanging(decimal value);
			partial void OnCostYTDChanged();
			partial void OnCostLastYearChanging(decimal value);
			partial void OnCostLastYearChanged();
			partial void OnrowguidChanging(System.Guid value);
			partial void OnrowguidChanged();
			partial void OnModifiedDateChanging(DateTime value);
			partial void OnModifiedDateChanged();
			#endregion

			public Sales_SalesTerritory()
			{
				_Person_StateProvinceList = new EntitySet<Person_StateProvince>(
					new Action<Person_StateProvince>(item=>{this.SendPropertyChanging(); item.Sales_SalesTerritory=this;}), 
					new Action<Person_StateProvince>(item=>{this.SendPropertyChanging(); item.Sales_SalesTerritory=null;}));
				_Sales_CustomerList = new EntitySet<Sales_Customer>(
					new Action<Sales_Customer>(item=>{this.SendPropertyChanging(); item.Sales_SalesTerritory=this;}), 
					new Action<Sales_Customer>(item=>{this.SendPropertyChanging(); item.Sales_SalesTerritory=null;}));
				_Sales_SalesOrderHeaderList = new EntitySet<Sales_SalesOrderHeader>(
					new Action<Sales_SalesOrderHeader>(item=>{this.SendPropertyChanging(); item.Sales_SalesTerritory=this;}), 
					new Action<Sales_SalesOrderHeader>(item=>{this.SendPropertyChanging(); item.Sales_SalesTerritory=null;}));
				_Sales_SalesPersonList = new EntitySet<Sales_SalesPerson>(
					new Action<Sales_SalesPerson>(item=>{this.SendPropertyChanging(); item.Sales_SalesTerritory=this;}), 
					new Action<Sales_SalesPerson>(item=>{this.SendPropertyChanging(); item.Sales_SalesTerritory=null;}));
				_Sales_SalesTerritoryHistoryList = new EntitySet<Sales_SalesTerritoryHistory>(
					new Action<Sales_SalesTerritoryHistory>(item=>{this.SendPropertyChanging(); item.Sales_SalesTerritory=this;}), 
					new Action<Sales_SalesTerritoryHistory>(item=>{this.SendPropertyChanging(); item.Sales_SalesTerritory=null;}));
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=Int NOT NULL IDENTITY
			/// </summary>
			[ColumnAttribute(Storage="_TerritoryID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", CanBeNull=false, IsPrimaryKey=true, IsDbGenerated=true)]
			public int TerritoryID
			{
				get
				{
					return this._TerritoryID;
				}
				set
				{
					if (this._TerritoryID != value)
					{
						this.OnTerritoryIDChanging(value);
						this.SendPropertyChanging();
						this._TerritoryID = value;
						this.SendPropertyChanged("TerritoryID");
						this.OnTerritoryIDChanged();
					}
					this.SendPropertySetterInvoked("TerritoryID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(50) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_Name", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
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
			/// Column DbType=NVarChar(3) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_CountryRegionCode", DbType="NVarChar(3) NOT NULL", CanBeNull=false)]
			public string CountryRegionCode
			{
				get
				{
					return this._CountryRegionCode;
				}
				set
				{
					if (this._CountryRegionCode != value)
					{
						this.OnCountryRegionCodeChanging(value);
						this.SendPropertyChanging();
						this._CountryRegionCode = value;
						this.SendPropertyChanged("CountryRegionCode");
						this.OnCountryRegionCodeChanged();
					}
					this.SendPropertySetterInvoked("CountryRegionCode", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(50) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_Group", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
			public string Group
			{
				get
				{
					return this._Group;
				}
				set
				{
					if (this._Group != value)
					{
						this.OnGroupChanging(value);
						this.SendPropertyChanging();
						this._Group = value;
						this.SendPropertyChanged("Group");
						this.OnGroupChanged();
					}
					this.SendPropertySetterInvoked("Group", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Money NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_SalesYTD", DbType="Money NOT NULL", CanBeNull=false)]
			public decimal SalesYTD
			{
				get
				{
					return this._SalesYTD;
				}
				set
				{
					if (this._SalesYTD != value)
					{
						this.OnSalesYTDChanging(value);
						this.SendPropertyChanging();
						this._SalesYTD = value;
						this.SendPropertyChanged("SalesYTD");
						this.OnSalesYTDChanged();
					}
					this.SendPropertySetterInvoked("SalesYTD", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Money NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_SalesLastYear", DbType="Money NOT NULL", CanBeNull=false)]
			public decimal SalesLastYear
			{
				get
				{
					return this._SalesLastYear;
				}
				set
				{
					if (this._SalesLastYear != value)
					{
						this.OnSalesLastYearChanging(value);
						this.SendPropertyChanging();
						this._SalesLastYear = value;
						this.SendPropertyChanged("SalesLastYear");
						this.OnSalesLastYearChanged();
					}
					this.SendPropertySetterInvoked("SalesLastYear", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Money NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_CostYTD", DbType="Money NOT NULL", CanBeNull=false)]
			public decimal CostYTD
			{
				get
				{
					return this._CostYTD;
				}
				set
				{
					if (this._CostYTD != value)
					{
						this.OnCostYTDChanging(value);
						this.SendPropertyChanging();
						this._CostYTD = value;
						this.SendPropertyChanged("CostYTD");
						this.OnCostYTDChanged();
					}
					this.SendPropertySetterInvoked("CostYTD", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Money NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_CostLastYear", DbType="Money NOT NULL", CanBeNull=false)]
			public decimal CostLastYear
			{
				get
				{
					return this._CostLastYear;
				}
				set
				{
					if (this._CostLastYear != value)
					{
						this.OnCostLastYearChanging(value);
						this.SendPropertyChanging();
						this._CostLastYear = value;
						this.SendPropertyChanged("CostLastYear");
						this.OnCostLastYearChanged();
					}
					this.SendPropertySetterInvoked("CostLastYear", value);
				}
			}
			
			/// <summary>
			/// Column DbType=UniqueIdentifier NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_rowguid", DbType="UniqueIdentifier NOT NULL", CanBeNull=false)]
			public System.Guid rowguid
			{
				get
				{
					return this._rowguid;
				}
				set
				{
					if (this._rowguid != value)
					{
						this.OnrowguidChanging(value);
						this.SendPropertyChanging();
						this._rowguid = value;
						this.SendPropertyChanged("rowguid");
						this.OnrowguidChanged();
					}
					this.SendPropertySetterInvoked("rowguid", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ModifiedDate", DbType="DateTime NOT NULL", CanBeNull=false)]
			public DateTime ModifiedDate
			{
				get
				{
					return this._ModifiedDate;
				}
				set
				{
					if (this._ModifiedDate != value)
					{
						this.OnModifiedDateChanging(value);
						this.SendPropertyChanging();
						this._ModifiedDate = value;
						this.SendPropertyChanged("ModifiedDate");
						this.OnModifiedDateChanged();
					}
					this.SendPropertySetterInvoked("ModifiedDate", value);
				}
			}
			
			#endregion Columns

			#region Associations
			/// <summary>
			/// Association [PK][One]Sales_SalesTerritory.TerritoryID --- [FK][Many]Person_StateProvince.TerritoryID
			/// </summary>
			[AssociationAttribute(Name="FK_StateProvince_SalesTerritory_TerritoryID", Storage="_Person_StateProvinceList", ThisKey="TerritoryID", OtherKey="TerritoryID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<Person_StateProvince> Person_StateProvinceList
			{
				get { return this._Person_StateProvinceList; }
				set { this._Person_StateProvinceList.Assign(value); }
			}
			
			/// <summary>
			/// Association [PK][One]Sales_SalesTerritory.TerritoryID --- [FK][Many]Sales_Customer.TerritoryID
			/// </summary>
			[AssociationAttribute(Name="FK_Customer_SalesTerritory_TerritoryID", Storage="_Sales_CustomerList", ThisKey="TerritoryID", OtherKey="TerritoryID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<Sales_Customer> Sales_CustomerList
			{
				get { return this._Sales_CustomerList; }
				set { this._Sales_CustomerList.Assign(value); }
			}
			
			/// <summary>
			/// Association [PK][One]Sales_SalesTerritory.TerritoryID --- [FK][Many]Sales_SalesOrderHeader.TerritoryID
			/// </summary>
			[AssociationAttribute(Name="FK_SalesOrderHeader_SalesTerritory_TerritoryID", Storage="_Sales_SalesOrderHeaderList", ThisKey="TerritoryID", OtherKey="TerritoryID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<Sales_SalesOrderHeader> Sales_SalesOrderHeaderList
			{
				get { return this._Sales_SalesOrderHeaderList; }
				set { this._Sales_SalesOrderHeaderList.Assign(value); }
			}
			
			/// <summary>
			/// Association [PK][One]Sales_SalesTerritory.TerritoryID --- [FK][Many]Sales_SalesPerson.TerritoryID
			/// </summary>
			[AssociationAttribute(Name="FK_SalesPerson_SalesTerritory_TerritoryID", Storage="_Sales_SalesPersonList", ThisKey="TerritoryID", OtherKey="TerritoryID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<Sales_SalesPerson> Sales_SalesPersonList
			{
				get { return this._Sales_SalesPersonList; }
				set { this._Sales_SalesPersonList.Assign(value); }
			}
			
			/// <summary>
			/// Association [PK][One]Sales_SalesTerritory.TerritoryID --- [FK][Many]Sales_SalesTerritoryHistory.TerritoryID
			/// </summary>
			[AssociationAttribute(Name="FK_SalesTerritoryHistory_SalesTerritory_TerritoryID", Storage="_Sales_SalesTerritoryHistoryList", ThisKey="TerritoryID", OtherKey="TerritoryID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<Sales_SalesTerritoryHistory> Sales_SalesTerritoryHistoryList
			{
				get { return this._Sales_SalesTerritoryHistoryList; }
				set { this._Sales_SalesTerritoryHistoryList.Assign(value); }
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
		#endregion Sales.SalesTerritory

		#region Sales.SalesTerritoryHistory
		[TableAttribute(Name="Sales.SalesTerritoryHistory")]
		public partial class Sales_SalesTerritoryHistory : EntityBase<Sales_SalesTerritoryHistory, AdventureWorksDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private int _SalesPersonID;
			private int _TerritoryID;
			private DateTime _StartDate;
			private DateTime? _EndDate;
			private System.Guid _rowguid;
			private DateTime _ModifiedDate;
			private EntityRef<Sales_SalesPerson> _Sales_SalesPerson;
			private EntityRef<Sales_SalesTerritory> _Sales_SalesTerritory;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnSalesPersonIDChanging(int value);
			partial void OnSalesPersonIDChanged();
			partial void OnTerritoryIDChanging(int value);
			partial void OnTerritoryIDChanged();
			partial void OnStartDateChanging(DateTime value);
			partial void OnStartDateChanged();
			partial void OnEndDateChanging(DateTime? value);
			partial void OnEndDateChanged();
			partial void OnrowguidChanging(System.Guid value);
			partial void OnrowguidChanged();
			partial void OnModifiedDateChanging(DateTime value);
			partial void OnModifiedDateChanged();
			#endregion

			public Sales_SalesTerritoryHistory()
			{
				_Sales_SalesPerson = default(EntityRef<Sales_SalesPerson>);
				_Sales_SalesTerritory = default(EntityRef<Sales_SalesTerritory>);
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_SalesPersonID", DbType="Int NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
			public int SalesPersonID
			{
				get
				{
					return this._SalesPersonID;
				}
				set
				{
					if (this._SalesPersonID != value)
					{
						this.OnSalesPersonIDChanging(value);
						this.SendPropertyChanging();
						this._SalesPersonID = value;
						this.SendPropertyChanged("SalesPersonID");
						this.OnSalesPersonIDChanged();
					}
					this.SendPropertySetterInvoked("SalesPersonID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_TerritoryID", DbType="Int NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
			public int TerritoryID
			{
				get
				{
					return this._TerritoryID;
				}
				set
				{
					if (this._TerritoryID != value)
					{
						this.OnTerritoryIDChanging(value);
						this.SendPropertyChanging();
						this._TerritoryID = value;
						this.SendPropertyChanged("TerritoryID");
						this.OnTerritoryIDChanged();
					}
					this.SendPropertySetterInvoked("TerritoryID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_StartDate", DbType="DateTime NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
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
						this.OnStartDateChanging(value);
						this.SendPropertyChanging();
						this._StartDate = value;
						this.SendPropertyChanged("StartDate");
						this.OnStartDateChanged();
					}
					this.SendPropertySetterInvoked("StartDate", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime
			/// </summary>
			[ColumnAttribute(Storage="_EndDate", DbType="DateTime", CanBeNull=true)]
			public DateTime? EndDate
			{
				get
				{
					return this._EndDate;
				}
				set
				{
					if (this._EndDate != value)
					{
						this.OnEndDateChanging(value);
						this.SendPropertyChanging();
						this._EndDate = value;
						this.SendPropertyChanged("EndDate");
						this.OnEndDateChanged();
					}
					this.SendPropertySetterInvoked("EndDate", value);
				}
			}
			
			/// <summary>
			/// Column DbType=UniqueIdentifier NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_rowguid", DbType="UniqueIdentifier NOT NULL", CanBeNull=false)]
			public System.Guid rowguid
			{
				get
				{
					return this._rowguid;
				}
				set
				{
					if (this._rowguid != value)
					{
						this.OnrowguidChanging(value);
						this.SendPropertyChanging();
						this._rowguid = value;
						this.SendPropertyChanged("rowguid");
						this.OnrowguidChanged();
					}
					this.SendPropertySetterInvoked("rowguid", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ModifiedDate", DbType="DateTime NOT NULL", CanBeNull=false)]
			public DateTime ModifiedDate
			{
				get
				{
					return this._ModifiedDate;
				}
				set
				{
					if (this._ModifiedDate != value)
					{
						this.OnModifiedDateChanging(value);
						this.SendPropertyChanging();
						this._ModifiedDate = value;
						this.SendPropertyChanged("ModifiedDate");
						this.OnModifiedDateChanged();
					}
					this.SendPropertySetterInvoked("ModifiedDate", value);
				}
			}
			
			#endregion Columns

			#region Associations
			/// <summary>
			/// Association [FK][Many]Sales_SalesTerritoryHistory.SalesPersonID --- [PK][One]Sales_SalesPerson.SalesPersonID
			/// </summary>
			[AssociationAttribute(Name="FK_SalesTerritoryHistory_SalesPerson_SalesPersonID", Storage="_Sales_SalesPerson", ThisKey="SalesPersonID", OtherKey="SalesPersonID", IsUnique=false, IsForeignKey=true)]
			public Sales_SalesPerson Sales_SalesPerson
			{
				get
				{
					return this._Sales_SalesPerson.Entity;
				}
				set
				{
					Sales_SalesPerson previousValue = this._Sales_SalesPerson.Entity;
					if ((previousValue != value) || (this._Sales_SalesPerson.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._Sales_SalesPerson.Entity = null;
							previousValue.Sales_SalesTerritoryHistoryList.Remove(this);
						}
						this._Sales_SalesPerson.Entity = value;
						if (value != null)
						{
							value.Sales_SalesTerritoryHistoryList.Add(this);
							this._SalesPersonID = value.SalesPersonID;
						}
						else
						{
							this._SalesPersonID = default(int);
						}
						this.SendPropertyChanged("Sales_SalesPerson");
					}
					this.SendPropertySetterInvoked("Sales_SalesPerson", value);
				}
			}
			
			/// <summary>
			/// Association [FK][Many]Sales_SalesTerritoryHistory.TerritoryID --- [PK][One]Sales_SalesTerritory.TerritoryID
			/// </summary>
			[AssociationAttribute(Name="FK_SalesTerritoryHistory_SalesTerritory_TerritoryID", Storage="_Sales_SalesTerritory", ThisKey="TerritoryID", OtherKey="TerritoryID", IsUnique=false, IsForeignKey=true)]
			public Sales_SalesTerritory Sales_SalesTerritory
			{
				get
				{
					return this._Sales_SalesTerritory.Entity;
				}
				set
				{
					Sales_SalesTerritory previousValue = this._Sales_SalesTerritory.Entity;
					if ((previousValue != value) || (this._Sales_SalesTerritory.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._Sales_SalesTerritory.Entity = null;
							previousValue.Sales_SalesTerritoryHistoryList.Remove(this);
						}
						this._Sales_SalesTerritory.Entity = value;
						if (value != null)
						{
							value.Sales_SalesTerritoryHistoryList.Add(this);
							this._TerritoryID = value.TerritoryID;
						}
						else
						{
							this._TerritoryID = default(int);
						}
						this.SendPropertyChanged("Sales_SalesTerritory");
					}
					this.SendPropertySetterInvoked("Sales_SalesTerritory", value);
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
		#endregion Sales.SalesTerritoryHistory

		#region Production.ScrapReason
		[TableAttribute(Name="Production.ScrapReason")]
		public partial class Production_ScrapReason : EntityBase<Production_ScrapReason, AdventureWorksDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private System.Int16 _ScrapReasonID;
			private string _Name;
			private DateTime _ModifiedDate;
			private EntitySet<Production_WorkOrder> _Production_WorkOrderList;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnScrapReasonIDChanging(System.Int16 value);
			partial void OnScrapReasonIDChanged();
			partial void OnNameChanging(string value);
			partial void OnNameChanged();
			partial void OnModifiedDateChanging(DateTime value);
			partial void OnModifiedDateChanged();
			#endregion

			public Production_ScrapReason()
			{
				_Production_WorkOrderList = new EntitySet<Production_WorkOrder>(
					new Action<Production_WorkOrder>(item=>{this.SendPropertyChanging(); item.Production_ScrapReason=this;}), 
					new Action<Production_WorkOrder>(item=>{this.SendPropertyChanging(); item.Production_ScrapReason=null;}));
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=SmallInt NOT NULL IDENTITY
			/// </summary>
			[ColumnAttribute(Storage="_ScrapReasonID", AutoSync=AutoSync.OnInsert, DbType="SmallInt NOT NULL IDENTITY", CanBeNull=false, IsPrimaryKey=true, IsDbGenerated=true)]
			public System.Int16 ScrapReasonID
			{
				get
				{
					return this._ScrapReasonID;
				}
				set
				{
					if (this._ScrapReasonID != value)
					{
						this.OnScrapReasonIDChanging(value);
						this.SendPropertyChanging();
						this._ScrapReasonID = value;
						this.SendPropertyChanged("ScrapReasonID");
						this.OnScrapReasonIDChanged();
					}
					this.SendPropertySetterInvoked("ScrapReasonID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(50) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_Name", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
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
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ModifiedDate", DbType="DateTime NOT NULL", CanBeNull=false)]
			public DateTime ModifiedDate
			{
				get
				{
					return this._ModifiedDate;
				}
				set
				{
					if (this._ModifiedDate != value)
					{
						this.OnModifiedDateChanging(value);
						this.SendPropertyChanging();
						this._ModifiedDate = value;
						this.SendPropertyChanged("ModifiedDate");
						this.OnModifiedDateChanged();
					}
					this.SendPropertySetterInvoked("ModifiedDate", value);
				}
			}
			
			#endregion Columns

			#region Associations
			/// <summary>
			/// Association [PK][One]Production_ScrapReason.ScrapReasonID --- [FK][Many]Production_WorkOrder.ScrapReasonID
			/// </summary>
			[AssociationAttribute(Name="FK_WorkOrder_ScrapReason_ScrapReasonID", Storage="_Production_WorkOrderList", ThisKey="ScrapReasonID", OtherKey="ScrapReasonID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<Production_WorkOrder> Production_WorkOrderList
			{
				get { return this._Production_WorkOrderList; }
				set { this._Production_WorkOrderList.Assign(value); }
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
		#endregion Production.ScrapReason

		#region HumanResources.Shift
		[TableAttribute(Name="HumanResources.Shift")]
		public partial class HumanResources_Shift : EntityBase<HumanResources_Shift, AdventureWorksDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private byte _ShiftID;
			private string _Name;
			private DateTime _StartTime;
			private DateTime _EndTime;
			private DateTime _ModifiedDate;
			private EntitySet<HumanResources_EmployeeDepartmentHistory> _HumanResources_EmployeeDepartmentHistoryList;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnShiftIDChanging(byte value);
			partial void OnShiftIDChanged();
			partial void OnNameChanging(string value);
			partial void OnNameChanged();
			partial void OnStartTimeChanging(DateTime value);
			partial void OnStartTimeChanged();
			partial void OnEndTimeChanging(DateTime value);
			partial void OnEndTimeChanged();
			partial void OnModifiedDateChanging(DateTime value);
			partial void OnModifiedDateChanged();
			#endregion

			public HumanResources_Shift()
			{
				_HumanResources_EmployeeDepartmentHistoryList = new EntitySet<HumanResources_EmployeeDepartmentHistory>(
					new Action<HumanResources_EmployeeDepartmentHistory>(item=>{this.SendPropertyChanging(); item.HumanResources_Shift=this;}), 
					new Action<HumanResources_EmployeeDepartmentHistory>(item=>{this.SendPropertyChanging(); item.HumanResources_Shift=null;}));
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=TinyInt NOT NULL IDENTITY
			/// </summary>
			[ColumnAttribute(Storage="_ShiftID", AutoSync=AutoSync.OnInsert, DbType="TinyInt NOT NULL IDENTITY", CanBeNull=false, IsPrimaryKey=true, IsDbGenerated=true)]
			public byte ShiftID
			{
				get
				{
					return this._ShiftID;
				}
				set
				{
					if (this._ShiftID != value)
					{
						this.OnShiftIDChanging(value);
						this.SendPropertyChanging();
						this._ShiftID = value;
						this.SendPropertyChanged("ShiftID");
						this.OnShiftIDChanged();
					}
					this.SendPropertySetterInvoked("ShiftID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(50) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_Name", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
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
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_StartTime", DbType="DateTime NOT NULL", CanBeNull=false)]
			public DateTime StartTime
			{
				get
				{
					return this._StartTime;
				}
				set
				{
					if (this._StartTime != value)
					{
						this.OnStartTimeChanging(value);
						this.SendPropertyChanging();
						this._StartTime = value;
						this.SendPropertyChanged("StartTime");
						this.OnStartTimeChanged();
					}
					this.SendPropertySetterInvoked("StartTime", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_EndTime", DbType="DateTime NOT NULL", CanBeNull=false)]
			public DateTime EndTime
			{
				get
				{
					return this._EndTime;
				}
				set
				{
					if (this._EndTime != value)
					{
						this.OnEndTimeChanging(value);
						this.SendPropertyChanging();
						this._EndTime = value;
						this.SendPropertyChanged("EndTime");
						this.OnEndTimeChanged();
					}
					this.SendPropertySetterInvoked("EndTime", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ModifiedDate", DbType="DateTime NOT NULL", CanBeNull=false)]
			public DateTime ModifiedDate
			{
				get
				{
					return this._ModifiedDate;
				}
				set
				{
					if (this._ModifiedDate != value)
					{
						this.OnModifiedDateChanging(value);
						this.SendPropertyChanging();
						this._ModifiedDate = value;
						this.SendPropertyChanged("ModifiedDate");
						this.OnModifiedDateChanged();
					}
					this.SendPropertySetterInvoked("ModifiedDate", value);
				}
			}
			
			#endregion Columns

			#region Associations
			/// <summary>
			/// Association [PK][One]HumanResources_Shift.ShiftID --- [FK][Many]HumanResources_EmployeeDepartmentHistory.ShiftID
			/// </summary>
			[AssociationAttribute(Name="FK_EmployeeDepartmentHistory_Shift_ShiftID", Storage="_HumanResources_EmployeeDepartmentHistoryList", ThisKey="ShiftID", OtherKey="ShiftID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<HumanResources_EmployeeDepartmentHistory> HumanResources_EmployeeDepartmentHistoryList
			{
				get { return this._HumanResources_EmployeeDepartmentHistoryList; }
				set { this._HumanResources_EmployeeDepartmentHistoryList.Assign(value); }
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
		#endregion HumanResources.Shift

		#region Purchasing.ShipMethod
		[TableAttribute(Name="Purchasing.ShipMethod")]
		public partial class Purchasing_ShipMethod : EntityBase<Purchasing_ShipMethod, AdventureWorksDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private int _ShipMethodID;
			private string _Name;
			private decimal _ShipBase;
			private decimal _ShipRate;
			private System.Guid _rowguid;
			private DateTime _ModifiedDate;
			private EntitySet<Purchasing_PurchaseOrderHeader> _Purchasing_PurchaseOrderHeaderList;
			private EntitySet<Sales_SalesOrderHeader> _Sales_SalesOrderHeaderList;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnShipMethodIDChanging(int value);
			partial void OnShipMethodIDChanged();
			partial void OnNameChanging(string value);
			partial void OnNameChanged();
			partial void OnShipBaseChanging(decimal value);
			partial void OnShipBaseChanged();
			partial void OnShipRateChanging(decimal value);
			partial void OnShipRateChanged();
			partial void OnrowguidChanging(System.Guid value);
			partial void OnrowguidChanged();
			partial void OnModifiedDateChanging(DateTime value);
			partial void OnModifiedDateChanged();
			#endregion

			public Purchasing_ShipMethod()
			{
				_Purchasing_PurchaseOrderHeaderList = new EntitySet<Purchasing_PurchaseOrderHeader>(
					new Action<Purchasing_PurchaseOrderHeader>(item=>{this.SendPropertyChanging(); item.Purchasing_ShipMethod=this;}), 
					new Action<Purchasing_PurchaseOrderHeader>(item=>{this.SendPropertyChanging(); item.Purchasing_ShipMethod=null;}));
				_Sales_SalesOrderHeaderList = new EntitySet<Sales_SalesOrderHeader>(
					new Action<Sales_SalesOrderHeader>(item=>{this.SendPropertyChanging(); item.Purchasing_ShipMethod=this;}), 
					new Action<Sales_SalesOrderHeader>(item=>{this.SendPropertyChanging(); item.Purchasing_ShipMethod=null;}));
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=Int NOT NULL IDENTITY
			/// </summary>
			[ColumnAttribute(Storage="_ShipMethodID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", CanBeNull=false, IsPrimaryKey=true, IsDbGenerated=true)]
			public int ShipMethodID
			{
				get
				{
					return this._ShipMethodID;
				}
				set
				{
					if (this._ShipMethodID != value)
					{
						this.OnShipMethodIDChanging(value);
						this.SendPropertyChanging();
						this._ShipMethodID = value;
						this.SendPropertyChanged("ShipMethodID");
						this.OnShipMethodIDChanged();
					}
					this.SendPropertySetterInvoked("ShipMethodID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(50) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_Name", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
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
			/// Column DbType=Money NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ShipBase", DbType="Money NOT NULL", CanBeNull=false)]
			public decimal ShipBase
			{
				get
				{
					return this._ShipBase;
				}
				set
				{
					if (this._ShipBase != value)
					{
						this.OnShipBaseChanging(value);
						this.SendPropertyChanging();
						this._ShipBase = value;
						this.SendPropertyChanged("ShipBase");
						this.OnShipBaseChanged();
					}
					this.SendPropertySetterInvoked("ShipBase", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Money NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ShipRate", DbType="Money NOT NULL", CanBeNull=false)]
			public decimal ShipRate
			{
				get
				{
					return this._ShipRate;
				}
				set
				{
					if (this._ShipRate != value)
					{
						this.OnShipRateChanging(value);
						this.SendPropertyChanging();
						this._ShipRate = value;
						this.SendPropertyChanged("ShipRate");
						this.OnShipRateChanged();
					}
					this.SendPropertySetterInvoked("ShipRate", value);
				}
			}
			
			/// <summary>
			/// Column DbType=UniqueIdentifier NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_rowguid", DbType="UniqueIdentifier NOT NULL", CanBeNull=false)]
			public System.Guid rowguid
			{
				get
				{
					return this._rowguid;
				}
				set
				{
					if (this._rowguid != value)
					{
						this.OnrowguidChanging(value);
						this.SendPropertyChanging();
						this._rowguid = value;
						this.SendPropertyChanged("rowguid");
						this.OnrowguidChanged();
					}
					this.SendPropertySetterInvoked("rowguid", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ModifiedDate", DbType="DateTime NOT NULL", CanBeNull=false)]
			public DateTime ModifiedDate
			{
				get
				{
					return this._ModifiedDate;
				}
				set
				{
					if (this._ModifiedDate != value)
					{
						this.OnModifiedDateChanging(value);
						this.SendPropertyChanging();
						this._ModifiedDate = value;
						this.SendPropertyChanged("ModifiedDate");
						this.OnModifiedDateChanged();
					}
					this.SendPropertySetterInvoked("ModifiedDate", value);
				}
			}
			
			#endregion Columns

			#region Associations
			/// <summary>
			/// Association [PK][One]Purchasing_ShipMethod.ShipMethodID --- [FK][Many]Purchasing_PurchaseOrderHeader.ShipMethodID
			/// </summary>
			[AssociationAttribute(Name="FK_PurchaseOrderHeader_ShipMethod_ShipMethodID", Storage="_Purchasing_PurchaseOrderHeaderList", ThisKey="ShipMethodID", OtherKey="ShipMethodID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<Purchasing_PurchaseOrderHeader> Purchasing_PurchaseOrderHeaderList
			{
				get { return this._Purchasing_PurchaseOrderHeaderList; }
				set { this._Purchasing_PurchaseOrderHeaderList.Assign(value); }
			}
			
			/// <summary>
			/// Association [PK][One]Purchasing_ShipMethod.ShipMethodID --- [FK][Many]Sales_SalesOrderHeader.ShipMethodID
			/// </summary>
			[AssociationAttribute(Name="FK_SalesOrderHeader_ShipMethod_ShipMethodID", Storage="_Sales_SalesOrderHeaderList", ThisKey="ShipMethodID", OtherKey="ShipMethodID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<Sales_SalesOrderHeader> Sales_SalesOrderHeaderList
			{
				get { return this._Sales_SalesOrderHeaderList; }
				set { this._Sales_SalesOrderHeaderList.Assign(value); }
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
		#endregion Purchasing.ShipMethod

		#region Sales.ShoppingCartItem
		[TableAttribute(Name="Sales.ShoppingCartItem")]
		public partial class Sales_ShoppingCartItem : EntityBase<Sales_ShoppingCartItem, AdventureWorksDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private int _ShoppingCartItemID;
			private string _ShoppingCartID;
			private int _Quantity;
			private int _ProductID;
			private DateTime _DateCreated;
			private DateTime _ModifiedDate;
			private EntityRef<Production_Product> _Production_Product;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnShoppingCartItemIDChanging(int value);
			partial void OnShoppingCartItemIDChanged();
			partial void OnShoppingCartIDChanging(string value);
			partial void OnShoppingCartIDChanged();
			partial void OnQuantityChanging(int value);
			partial void OnQuantityChanged();
			partial void OnProductIDChanging(int value);
			partial void OnProductIDChanged();
			partial void OnDateCreatedChanging(DateTime value);
			partial void OnDateCreatedChanged();
			partial void OnModifiedDateChanging(DateTime value);
			partial void OnModifiedDateChanged();
			#endregion

			public Sales_ShoppingCartItem()
			{
				_Production_Product = default(EntityRef<Production_Product>);
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=Int NOT NULL IDENTITY
			/// </summary>
			[ColumnAttribute(Storage="_ShoppingCartItemID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", CanBeNull=false, IsPrimaryKey=true, IsDbGenerated=true)]
			public int ShoppingCartItemID
			{
				get
				{
					return this._ShoppingCartItemID;
				}
				set
				{
					if (this._ShoppingCartItemID != value)
					{
						this.OnShoppingCartItemIDChanging(value);
						this.SendPropertyChanging();
						this._ShoppingCartItemID = value;
						this.SendPropertyChanged("ShoppingCartItemID");
						this.OnShoppingCartItemIDChanged();
					}
					this.SendPropertySetterInvoked("ShoppingCartItemID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(50) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ShoppingCartID", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
			public string ShoppingCartID
			{
				get
				{
					return this._ShoppingCartID;
				}
				set
				{
					if (this._ShoppingCartID != value)
					{
						this.OnShoppingCartIDChanging(value);
						this.SendPropertyChanging();
						this._ShoppingCartID = value;
						this.SendPropertyChanged("ShoppingCartID");
						this.OnShoppingCartIDChanged();
					}
					this.SendPropertySetterInvoked("ShoppingCartID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_Quantity", DbType="Int NOT NULL", CanBeNull=false)]
			public int Quantity
			{
				get
				{
					return this._Quantity;
				}
				set
				{
					if (this._Quantity != value)
					{
						this.OnQuantityChanging(value);
						this.SendPropertyChanging();
						this._Quantity = value;
						this.SendPropertyChanged("Quantity");
						this.OnQuantityChanged();
					}
					this.SendPropertySetterInvoked("Quantity", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ProductID", DbType="Int NOT NULL", CanBeNull=false)]
			public int ProductID
			{
				get
				{
					return this._ProductID;
				}
				set
				{
					if (this._ProductID != value)
					{
						this.OnProductIDChanging(value);
						this.SendPropertyChanging();
						this._ProductID = value;
						this.SendPropertyChanged("ProductID");
						this.OnProductIDChanged();
					}
					this.SendPropertySetterInvoked("ProductID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_DateCreated", DbType="DateTime NOT NULL", CanBeNull=false)]
			public DateTime DateCreated
			{
				get
				{
					return this._DateCreated;
				}
				set
				{
					if (this._DateCreated != value)
					{
						this.OnDateCreatedChanging(value);
						this.SendPropertyChanging();
						this._DateCreated = value;
						this.SendPropertyChanged("DateCreated");
						this.OnDateCreatedChanged();
					}
					this.SendPropertySetterInvoked("DateCreated", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ModifiedDate", DbType="DateTime NOT NULL", CanBeNull=false)]
			public DateTime ModifiedDate
			{
				get
				{
					return this._ModifiedDate;
				}
				set
				{
					if (this._ModifiedDate != value)
					{
						this.OnModifiedDateChanging(value);
						this.SendPropertyChanging();
						this._ModifiedDate = value;
						this.SendPropertyChanged("ModifiedDate");
						this.OnModifiedDateChanged();
					}
					this.SendPropertySetterInvoked("ModifiedDate", value);
				}
			}
			
			#endregion Columns

			#region Associations
			/// <summary>
			/// Association [FK][Many]Sales_ShoppingCartItem.ProductID --- [PK][One]Production_Product.ProductID
			/// </summary>
			[AssociationAttribute(Name="FK_ShoppingCartItem_Product_ProductID", Storage="_Production_Product", ThisKey="ProductID", OtherKey="ProductID", IsUnique=false, IsForeignKey=true)]
			public Production_Product Production_Product
			{
				get
				{
					return this._Production_Product.Entity;
				}
				set
				{
					Production_Product previousValue = this._Production_Product.Entity;
					if ((previousValue != value) || (this._Production_Product.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._Production_Product.Entity = null;
							previousValue.Sales_ShoppingCartItemList.Remove(this);
						}
						this._Production_Product.Entity = value;
						if (value != null)
						{
							value.Sales_ShoppingCartItemList.Add(this);
							this._ProductID = value.ProductID;
						}
						else
						{
							this._ProductID = default(int);
						}
						this.SendPropertyChanged("Production_Product");
					}
					this.SendPropertySetterInvoked("Production_Product", value);
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
		#endregion Sales.ShoppingCartItem

		#region Sales.SpecialOffer
		[TableAttribute(Name="Sales.SpecialOffer")]
		public partial class Sales_SpecialOffer : EntityBase<Sales_SpecialOffer, AdventureWorksDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private int _SpecialOfferID;
			private string _Description;
			private decimal _DiscountPct;
			private string _Type;
			private string _Category;
			private DateTime _StartDate;
			private DateTime _EndDate;
			private int _MinQty;
			private int? _MaxQty;
			private System.Guid _rowguid;
			private DateTime _ModifiedDate;
			private EntitySet<Sales_SpecialOfferProduct> _Sales_SpecialOfferProductList;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnSpecialOfferIDChanging(int value);
			partial void OnSpecialOfferIDChanged();
			partial void OnDescriptionChanging(string value);
			partial void OnDescriptionChanged();
			partial void OnDiscountPctChanging(decimal value);
			partial void OnDiscountPctChanged();
			partial void OnTypeChanging(string value);
			partial void OnTypeChanged();
			partial void OnCategoryChanging(string value);
			partial void OnCategoryChanged();
			partial void OnStartDateChanging(DateTime value);
			partial void OnStartDateChanged();
			partial void OnEndDateChanging(DateTime value);
			partial void OnEndDateChanged();
			partial void OnMinQtyChanging(int value);
			partial void OnMinQtyChanged();
			partial void OnMaxQtyChanging(int? value);
			partial void OnMaxQtyChanged();
			partial void OnrowguidChanging(System.Guid value);
			partial void OnrowguidChanged();
			partial void OnModifiedDateChanging(DateTime value);
			partial void OnModifiedDateChanged();
			#endregion

			public Sales_SpecialOffer()
			{
				_Sales_SpecialOfferProductList = new EntitySet<Sales_SpecialOfferProduct>(
					new Action<Sales_SpecialOfferProduct>(item=>{this.SendPropertyChanging(); item.Sales_SpecialOffer=this;}), 
					new Action<Sales_SpecialOfferProduct>(item=>{this.SendPropertyChanging(); item.Sales_SpecialOffer=null;}));
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=Int NOT NULL IDENTITY
			/// </summary>
			[ColumnAttribute(Storage="_SpecialOfferID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", CanBeNull=false, IsPrimaryKey=true, IsDbGenerated=true)]
			public int SpecialOfferID
			{
				get
				{
					return this._SpecialOfferID;
				}
				set
				{
					if (this._SpecialOfferID != value)
					{
						this.OnSpecialOfferIDChanging(value);
						this.SendPropertyChanging();
						this._SpecialOfferID = value;
						this.SendPropertyChanged("SpecialOfferID");
						this.OnSpecialOfferIDChanged();
					}
					this.SendPropertySetterInvoked("SpecialOfferID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(255) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_Description", DbType="NVarChar(255) NOT NULL", CanBeNull=false)]
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
			/// Column DbType=SmallMoney NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_DiscountPct", DbType="SmallMoney NOT NULL", CanBeNull=false)]
			public decimal DiscountPct
			{
				get
				{
					return this._DiscountPct;
				}
				set
				{
					if (this._DiscountPct != value)
					{
						this.OnDiscountPctChanging(value);
						this.SendPropertyChanging();
						this._DiscountPct = value;
						this.SendPropertyChanged("DiscountPct");
						this.OnDiscountPctChanged();
					}
					this.SendPropertySetterInvoked("DiscountPct", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(50) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_Type", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
			public string Type
			{
				get
				{
					return this._Type;
				}
				set
				{
					if (this._Type != value)
					{
						this.OnTypeChanging(value);
						this.SendPropertyChanging();
						this._Type = value;
						this.SendPropertyChanged("Type");
						this.OnTypeChanged();
					}
					this.SendPropertySetterInvoked("Type", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(50) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_Category", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
			public string Category
			{
				get
				{
					return this._Category;
				}
				set
				{
					if (this._Category != value)
					{
						this.OnCategoryChanging(value);
						this.SendPropertyChanging();
						this._Category = value;
						this.SendPropertyChanged("Category");
						this.OnCategoryChanged();
					}
					this.SendPropertySetterInvoked("Category", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_StartDate", DbType="DateTime NOT NULL", CanBeNull=false)]
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
						this.OnStartDateChanging(value);
						this.SendPropertyChanging();
						this._StartDate = value;
						this.SendPropertyChanged("StartDate");
						this.OnStartDateChanged();
					}
					this.SendPropertySetterInvoked("StartDate", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_EndDate", DbType="DateTime NOT NULL", CanBeNull=false)]
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
						this.OnEndDateChanging(value);
						this.SendPropertyChanging();
						this._EndDate = value;
						this.SendPropertyChanged("EndDate");
						this.OnEndDateChanged();
					}
					this.SendPropertySetterInvoked("EndDate", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_MinQty", DbType="Int NOT NULL", CanBeNull=false)]
			public int MinQty
			{
				get
				{
					return this._MinQty;
				}
				set
				{
					if (this._MinQty != value)
					{
						this.OnMinQtyChanging(value);
						this.SendPropertyChanging();
						this._MinQty = value;
						this.SendPropertyChanged("MinQty");
						this.OnMinQtyChanged();
					}
					this.SendPropertySetterInvoked("MinQty", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int
			/// </summary>
			[ColumnAttribute(Storage="_MaxQty", DbType="Int", CanBeNull=true)]
			public int? MaxQty
			{
				get
				{
					return this._MaxQty;
				}
				set
				{
					if (this._MaxQty != value)
					{
						this.OnMaxQtyChanging(value);
						this.SendPropertyChanging();
						this._MaxQty = value;
						this.SendPropertyChanged("MaxQty");
						this.OnMaxQtyChanged();
					}
					this.SendPropertySetterInvoked("MaxQty", value);
				}
			}
			
			/// <summary>
			/// Column DbType=UniqueIdentifier NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_rowguid", DbType="UniqueIdentifier NOT NULL", CanBeNull=false)]
			public System.Guid rowguid
			{
				get
				{
					return this._rowguid;
				}
				set
				{
					if (this._rowguid != value)
					{
						this.OnrowguidChanging(value);
						this.SendPropertyChanging();
						this._rowguid = value;
						this.SendPropertyChanged("rowguid");
						this.OnrowguidChanged();
					}
					this.SendPropertySetterInvoked("rowguid", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ModifiedDate", DbType="DateTime NOT NULL", CanBeNull=false)]
			public DateTime ModifiedDate
			{
				get
				{
					return this._ModifiedDate;
				}
				set
				{
					if (this._ModifiedDate != value)
					{
						this.OnModifiedDateChanging(value);
						this.SendPropertyChanging();
						this._ModifiedDate = value;
						this.SendPropertyChanged("ModifiedDate");
						this.OnModifiedDateChanged();
					}
					this.SendPropertySetterInvoked("ModifiedDate", value);
				}
			}
			
			#endregion Columns

			#region Associations
			/// <summary>
			/// Association [PK][One]Sales_SpecialOffer.SpecialOfferID --- [FK][Many]Sales_SpecialOfferProduct.SpecialOfferID
			/// </summary>
			[AssociationAttribute(Name="FK_SpecialOfferProduct_SpecialOffer_SpecialOfferID", Storage="_Sales_SpecialOfferProductList", ThisKey="SpecialOfferID", OtherKey="SpecialOfferID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<Sales_SpecialOfferProduct> Sales_SpecialOfferProductList
			{
				get { return this._Sales_SpecialOfferProductList; }
				set { this._Sales_SpecialOfferProductList.Assign(value); }
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
		#endregion Sales.SpecialOffer

		#region Sales.SpecialOfferProduct
		[TableAttribute(Name="Sales.SpecialOfferProduct")]
		public partial class Sales_SpecialOfferProduct : EntityBase<Sales_SpecialOfferProduct, AdventureWorksDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private int _SpecialOfferID;
			private int _ProductID;
			private System.Guid _rowguid;
			private DateTime _ModifiedDate;
			private EntitySet<Sales_SalesOrderDetail> _Sales_SalesOrderDetailList;
			private EntityRef<Production_Product> _Production_Product;
			private EntityRef<Sales_SpecialOffer> _Sales_SpecialOffer;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnSpecialOfferIDChanging(int value);
			partial void OnSpecialOfferIDChanged();
			partial void OnProductIDChanging(int value);
			partial void OnProductIDChanged();
			partial void OnrowguidChanging(System.Guid value);
			partial void OnrowguidChanged();
			partial void OnModifiedDateChanging(DateTime value);
			partial void OnModifiedDateChanged();
			#endregion

			public Sales_SpecialOfferProduct()
			{
				_Sales_SalesOrderDetailList = new EntitySet<Sales_SalesOrderDetail>(
					new Action<Sales_SalesOrderDetail>(item=>{this.SendPropertyChanging(); item.Sales_SpecialOfferProduct=this;}), 
					new Action<Sales_SalesOrderDetail>(item=>{this.SendPropertyChanging(); item.Sales_SpecialOfferProduct=null;}));
				_Production_Product = default(EntityRef<Production_Product>);
				_Sales_SpecialOffer = default(EntityRef<Sales_SpecialOffer>);
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_SpecialOfferID", DbType="Int NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
			public int SpecialOfferID
			{
				get
				{
					return this._SpecialOfferID;
				}
				set
				{
					if (this._SpecialOfferID != value)
					{
						this.OnSpecialOfferIDChanging(value);
						this.SendPropertyChanging();
						this._SpecialOfferID = value;
						this.SendPropertyChanged("SpecialOfferID");
						this.OnSpecialOfferIDChanged();
					}
					this.SendPropertySetterInvoked("SpecialOfferID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ProductID", DbType="Int NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
			public int ProductID
			{
				get
				{
					return this._ProductID;
				}
				set
				{
					if (this._ProductID != value)
					{
						this.OnProductIDChanging(value);
						this.SendPropertyChanging();
						this._ProductID = value;
						this.SendPropertyChanged("ProductID");
						this.OnProductIDChanged();
					}
					this.SendPropertySetterInvoked("ProductID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=UniqueIdentifier NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_rowguid", DbType="UniqueIdentifier NOT NULL", CanBeNull=false)]
			public System.Guid rowguid
			{
				get
				{
					return this._rowguid;
				}
				set
				{
					if (this._rowguid != value)
					{
						this.OnrowguidChanging(value);
						this.SendPropertyChanging();
						this._rowguid = value;
						this.SendPropertyChanged("rowguid");
						this.OnrowguidChanged();
					}
					this.SendPropertySetterInvoked("rowguid", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ModifiedDate", DbType="DateTime NOT NULL", CanBeNull=false)]
			public DateTime ModifiedDate
			{
				get
				{
					return this._ModifiedDate;
				}
				set
				{
					if (this._ModifiedDate != value)
					{
						this.OnModifiedDateChanging(value);
						this.SendPropertyChanging();
						this._ModifiedDate = value;
						this.SendPropertyChanged("ModifiedDate");
						this.OnModifiedDateChanged();
					}
					this.SendPropertySetterInvoked("ModifiedDate", value);
				}
			}
			
			#endregion Columns

			#region Associations
			/// <summary>
			/// Association [PK][One]Sales_SpecialOfferProduct.SpecialOfferID --- [FK][Many]Sales_SalesOrderDetail.SpecialOfferID
			/// </summary>
			[AssociationAttribute(Name="FK_SalesOrderDetail_SpecialOfferProduct_SpecialOfferIDProductID", Storage="_Sales_SalesOrderDetailList", ThisKey="SpecialOfferID", OtherKey="SpecialOfferID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<Sales_SalesOrderDetail> Sales_SalesOrderDetailList
			{
				get { return this._Sales_SalesOrderDetailList; }
				set { this._Sales_SalesOrderDetailList.Assign(value); }
			}
			
			/// <summary>
			/// Association [FK][Many]Sales_SpecialOfferProduct.ProductID --- [PK][One]Production_Product.ProductID
			/// </summary>
			[AssociationAttribute(Name="FK_SpecialOfferProduct_Product_ProductID", Storage="_Production_Product", ThisKey="ProductID", OtherKey="ProductID", IsUnique=false, IsForeignKey=true)]
			public Production_Product Production_Product
			{
				get
				{
					return this._Production_Product.Entity;
				}
				set
				{
					Production_Product previousValue = this._Production_Product.Entity;
					if ((previousValue != value) || (this._Production_Product.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._Production_Product.Entity = null;
							previousValue.Sales_SpecialOfferProductList.Remove(this);
						}
						this._Production_Product.Entity = value;
						if (value != null)
						{
							value.Sales_SpecialOfferProductList.Add(this);
							this._ProductID = value.ProductID;
						}
						else
						{
							this._ProductID = default(int);
						}
						this.SendPropertyChanged("Production_Product");
					}
					this.SendPropertySetterInvoked("Production_Product", value);
				}
			}
			
			/// <summary>
			/// Association [FK][Many]Sales_SpecialOfferProduct.SpecialOfferID --- [PK][One]Sales_SpecialOffer.SpecialOfferID
			/// </summary>
			[AssociationAttribute(Name="FK_SpecialOfferProduct_SpecialOffer_SpecialOfferID", Storage="_Sales_SpecialOffer", ThisKey="SpecialOfferID", OtherKey="SpecialOfferID", IsUnique=false, IsForeignKey=true)]
			public Sales_SpecialOffer Sales_SpecialOffer
			{
				get
				{
					return this._Sales_SpecialOffer.Entity;
				}
				set
				{
					Sales_SpecialOffer previousValue = this._Sales_SpecialOffer.Entity;
					if ((previousValue != value) || (this._Sales_SpecialOffer.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._Sales_SpecialOffer.Entity = null;
							previousValue.Sales_SpecialOfferProductList.Remove(this);
						}
						this._Sales_SpecialOffer.Entity = value;
						if (value != null)
						{
							value.Sales_SpecialOfferProductList.Add(this);
							this._SpecialOfferID = value.SpecialOfferID;
						}
						else
						{
							this._SpecialOfferID = default(int);
						}
						this.SendPropertyChanged("Sales_SpecialOffer");
					}
					this.SendPropertySetterInvoked("Sales_SpecialOffer", value);
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
		#endregion Sales.SpecialOfferProduct

		#region Person.StateProvince
		[TableAttribute(Name="Person.StateProvince")]
		public partial class Person_StateProvince : EntityBase<Person_StateProvince, AdventureWorksDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private int _StateProvinceID;
			private string _StateProvinceCode;
			private string _CountryRegionCode;
			private bool _IsOnlyStateProvinceFlag;
			private string _Name;
			private int _TerritoryID;
			private System.Guid _rowguid;
			private DateTime _ModifiedDate;
			private EntitySet<Person_Address> _Person_AddressList;
			private EntityRef<Person_CountryRegion> _Person_CountryRegion;
			private EntityRef<Sales_SalesTerritory> _Sales_SalesTerritory;
			private EntitySet<Sales_SalesTaxRate> _Sales_SalesTaxRateList;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnStateProvinceIDChanging(int value);
			partial void OnStateProvinceIDChanged();
			partial void OnStateProvinceCodeChanging(string value);
			partial void OnStateProvinceCodeChanged();
			partial void OnCountryRegionCodeChanging(string value);
			partial void OnCountryRegionCodeChanged();
			partial void OnIsOnlyStateProvinceFlagChanging(bool value);
			partial void OnIsOnlyStateProvinceFlagChanged();
			partial void OnNameChanging(string value);
			partial void OnNameChanged();
			partial void OnTerritoryIDChanging(int value);
			partial void OnTerritoryIDChanged();
			partial void OnrowguidChanging(System.Guid value);
			partial void OnrowguidChanged();
			partial void OnModifiedDateChanging(DateTime value);
			partial void OnModifiedDateChanged();
			#endregion

			public Person_StateProvince()
			{
				_Person_AddressList = new EntitySet<Person_Address>(
					new Action<Person_Address>(item=>{this.SendPropertyChanging(); item.Person_StateProvince=this;}), 
					new Action<Person_Address>(item=>{this.SendPropertyChanging(); item.Person_StateProvince=null;}));
				_Person_CountryRegion = default(EntityRef<Person_CountryRegion>);
				_Sales_SalesTerritory = default(EntityRef<Sales_SalesTerritory>);
				_Sales_SalesTaxRateList = new EntitySet<Sales_SalesTaxRate>(
					new Action<Sales_SalesTaxRate>(item=>{this.SendPropertyChanging(); item.Person_StateProvince=this;}), 
					new Action<Sales_SalesTaxRate>(item=>{this.SendPropertyChanging(); item.Person_StateProvince=null;}));
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=Int NOT NULL IDENTITY
			/// </summary>
			[ColumnAttribute(Storage="_StateProvinceID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", CanBeNull=false, IsPrimaryKey=true, IsDbGenerated=true)]
			public int StateProvinceID
			{
				get
				{
					return this._StateProvinceID;
				}
				set
				{
					if (this._StateProvinceID != value)
					{
						this.OnStateProvinceIDChanging(value);
						this.SendPropertyChanging();
						this._StateProvinceID = value;
						this.SendPropertyChanged("StateProvinceID");
						this.OnStateProvinceIDChanged();
					}
					this.SendPropertySetterInvoked("StateProvinceID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NChar(3) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_StateProvinceCode", DbType="NChar(3) NOT NULL", CanBeNull=false)]
			public string StateProvinceCode
			{
				get
				{
					return this._StateProvinceCode;
				}
				set
				{
					if (this._StateProvinceCode != value)
					{
						this.OnStateProvinceCodeChanging(value);
						this.SendPropertyChanging();
						this._StateProvinceCode = value;
						this.SendPropertyChanged("StateProvinceCode");
						this.OnStateProvinceCodeChanged();
					}
					this.SendPropertySetterInvoked("StateProvinceCode", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(3) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_CountryRegionCode", DbType="NVarChar(3) NOT NULL", CanBeNull=false)]
			public string CountryRegionCode
			{
				get
				{
					return this._CountryRegionCode;
				}
				set
				{
					if (this._CountryRegionCode != value)
					{
						this.OnCountryRegionCodeChanging(value);
						this.SendPropertyChanging();
						this._CountryRegionCode = value;
						this.SendPropertyChanged("CountryRegionCode");
						this.OnCountryRegionCodeChanged();
					}
					this.SendPropertySetterInvoked("CountryRegionCode", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Bit NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_IsOnlyStateProvinceFlag", DbType="Bit NOT NULL", CanBeNull=false)]
			public bool IsOnlyStateProvinceFlag
			{
				get
				{
					return this._IsOnlyStateProvinceFlag;
				}
				set
				{
					if (this._IsOnlyStateProvinceFlag != value)
					{
						this.OnIsOnlyStateProvinceFlagChanging(value);
						this.SendPropertyChanging();
						this._IsOnlyStateProvinceFlag = value;
						this.SendPropertyChanged("IsOnlyStateProvinceFlag");
						this.OnIsOnlyStateProvinceFlagChanged();
					}
					this.SendPropertySetterInvoked("IsOnlyStateProvinceFlag", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(50) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_Name", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
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
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_TerritoryID", DbType="Int NOT NULL", CanBeNull=false)]
			public int TerritoryID
			{
				get
				{
					return this._TerritoryID;
				}
				set
				{
					if (this._TerritoryID != value)
					{
						this.OnTerritoryIDChanging(value);
						this.SendPropertyChanging();
						this._TerritoryID = value;
						this.SendPropertyChanged("TerritoryID");
						this.OnTerritoryIDChanged();
					}
					this.SendPropertySetterInvoked("TerritoryID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=UniqueIdentifier NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_rowguid", DbType="UniqueIdentifier NOT NULL", CanBeNull=false)]
			public System.Guid rowguid
			{
				get
				{
					return this._rowguid;
				}
				set
				{
					if (this._rowguid != value)
					{
						this.OnrowguidChanging(value);
						this.SendPropertyChanging();
						this._rowguid = value;
						this.SendPropertyChanged("rowguid");
						this.OnrowguidChanged();
					}
					this.SendPropertySetterInvoked("rowguid", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ModifiedDate", DbType="DateTime NOT NULL", CanBeNull=false)]
			public DateTime ModifiedDate
			{
				get
				{
					return this._ModifiedDate;
				}
				set
				{
					if (this._ModifiedDate != value)
					{
						this.OnModifiedDateChanging(value);
						this.SendPropertyChanging();
						this._ModifiedDate = value;
						this.SendPropertyChanged("ModifiedDate");
						this.OnModifiedDateChanged();
					}
					this.SendPropertySetterInvoked("ModifiedDate", value);
				}
			}
			
			#endregion Columns

			#region Associations
			/// <summary>
			/// Association [PK][One]Person_StateProvince.StateProvinceID --- [FK][Many]Person_Address.StateProvinceID
			/// </summary>
			[AssociationAttribute(Name="FK_Address_StateProvince_StateProvinceID", Storage="_Person_AddressList", ThisKey="StateProvinceID", OtherKey="StateProvinceID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<Person_Address> Person_AddressList
			{
				get { return this._Person_AddressList; }
				set { this._Person_AddressList.Assign(value); }
			}
			
			/// <summary>
			/// Association [FK][Many]Person_StateProvince.CountryRegionCode --- [PK][One]Person_CountryRegion.CountryRegionCode
			/// </summary>
			[AssociationAttribute(Name="FK_StateProvince_CountryRegion_CountryRegionCode", Storage="_Person_CountryRegion", ThisKey="CountryRegionCode", OtherKey="CountryRegionCode", IsUnique=false, IsForeignKey=true)]
			public Person_CountryRegion Person_CountryRegion
			{
				get
				{
					return this._Person_CountryRegion.Entity;
				}
				set
				{
					Person_CountryRegion previousValue = this._Person_CountryRegion.Entity;
					if ((previousValue != value) || (this._Person_CountryRegion.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._Person_CountryRegion.Entity = null;
							previousValue.Person_StateProvinceList.Remove(this);
						}
						this._Person_CountryRegion.Entity = value;
						if (value != null)
						{
							value.Person_StateProvinceList.Add(this);
							this._CountryRegionCode = value.CountryRegionCode;
						}
						else
						{
							this._CountryRegionCode = default(string);
						}
						this.SendPropertyChanged("Person_CountryRegion");
					}
					this.SendPropertySetterInvoked("Person_CountryRegion", value);
				}
			}
			
			/// <summary>
			/// Association [FK][Many]Person_StateProvince.TerritoryID --- [PK][One]Sales_SalesTerritory.TerritoryID
			/// </summary>
			[AssociationAttribute(Name="FK_StateProvince_SalesTerritory_TerritoryID", Storage="_Sales_SalesTerritory", ThisKey="TerritoryID", OtherKey="TerritoryID", IsUnique=false, IsForeignKey=true)]
			public Sales_SalesTerritory Sales_SalesTerritory
			{
				get
				{
					return this._Sales_SalesTerritory.Entity;
				}
				set
				{
					Sales_SalesTerritory previousValue = this._Sales_SalesTerritory.Entity;
					if ((previousValue != value) || (this._Sales_SalesTerritory.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._Sales_SalesTerritory.Entity = null;
							previousValue.Person_StateProvinceList.Remove(this);
						}
						this._Sales_SalesTerritory.Entity = value;
						if (value != null)
						{
							value.Person_StateProvinceList.Add(this);
							this._TerritoryID = value.TerritoryID;
						}
						else
						{
							this._TerritoryID = default(int);
						}
						this.SendPropertyChanged("Sales_SalesTerritory");
					}
					this.SendPropertySetterInvoked("Sales_SalesTerritory", value);
				}
			}
			
			/// <summary>
			/// Association [PK][One]Person_StateProvince.StateProvinceID --- [FK][Many]Sales_SalesTaxRate.StateProvinceID
			/// </summary>
			[AssociationAttribute(Name="FK_SalesTaxRate_StateProvince_StateProvinceID", Storage="_Sales_SalesTaxRateList", ThisKey="StateProvinceID", OtherKey="StateProvinceID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<Sales_SalesTaxRate> Sales_SalesTaxRateList
			{
				get { return this._Sales_SalesTaxRateList; }
				set { this._Sales_SalesTaxRateList.Assign(value); }
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
		#endregion Person.StateProvince

		#region Sales.Store
		[TableAttribute(Name="Sales.Store")]
		public partial class Sales_Store : EntityBase<Sales_Store, AdventureWorksDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private int _CustomerID;
			private string _Name;
			private int? _SalesPersonID;
			private System.Xml.Linq.XElement _Demographics;
			private System.Guid _rowguid;
			private DateTime _ModifiedDate;
			private EntityRef<Sales_Customer> _Sales_Customer;
			private EntityRef<Sales_SalesPerson> _Sales_SalesPerson;
			private EntitySet<Sales_StoreContact> _Sales_StoreContactList;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnCustomerIDChanging(int value);
			partial void OnCustomerIDChanged();
			partial void OnNameChanging(string value);
			partial void OnNameChanged();
			partial void OnSalesPersonIDChanging(int? value);
			partial void OnSalesPersonIDChanged();
			partial void OnDemographicsChanging(System.Xml.Linq.XElement value);
			partial void OnDemographicsChanged();
			partial void OnrowguidChanging(System.Guid value);
			partial void OnrowguidChanged();
			partial void OnModifiedDateChanging(DateTime value);
			partial void OnModifiedDateChanged();
			#endregion

			public Sales_Store()
			{
				_Sales_Customer = default(EntityRef<Sales_Customer>);
				_Sales_SalesPerson = default(EntityRef<Sales_SalesPerson>);
				_Sales_StoreContactList = new EntitySet<Sales_StoreContact>(
					new Action<Sales_StoreContact>(item=>{this.SendPropertyChanging(); item.Sales_Store=this;}), 
					new Action<Sales_StoreContact>(item=>{this.SendPropertyChanging(); item.Sales_Store=null;}));
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_CustomerID", DbType="Int NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
			public int CustomerID
			{
				get
				{
					return this._CustomerID;
				}
				set
				{
					if (this._CustomerID != value)
					{
						this.OnCustomerIDChanging(value);
						this.SendPropertyChanging();
						this._CustomerID = value;
						this.SendPropertyChanged("CustomerID");
						this.OnCustomerIDChanged();
					}
					this.SendPropertySetterInvoked("CustomerID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(50) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_Name", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
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
			/// Column DbType=Int
			/// </summary>
			[ColumnAttribute(Storage="_SalesPersonID", DbType="Int", CanBeNull=true)]
			public int? SalesPersonID
			{
				get
				{
					return this._SalesPersonID;
				}
				set
				{
					if (this._SalesPersonID != value)
					{
						this.OnSalesPersonIDChanging(value);
						this.SendPropertyChanging();
						this._SalesPersonID = value;
						this.SendPropertyChanged("SalesPersonID");
						this.OnSalesPersonIDChanged();
					}
					this.SendPropertySetterInvoked("SalesPersonID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Xml
			/// </summary>
			[ColumnAttribute(Storage="_Demographics", DbType="Xml", CanBeNull=true)]
			public System.Xml.Linq.XElement Demographics
			{
				get
				{
					return this._Demographics;
				}
				set
				{
					if (this._Demographics != value)
					{
						this.OnDemographicsChanging(value);
						this.SendPropertyChanging();
						this._Demographics = value;
						this.SendPropertyChanged("Demographics");
						this.OnDemographicsChanged();
					}
					this.SendPropertySetterInvoked("Demographics", value);
				}
			}
			
			/// <summary>
			/// Column DbType=UniqueIdentifier NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_rowguid", DbType="UniqueIdentifier NOT NULL", CanBeNull=false)]
			public System.Guid rowguid
			{
				get
				{
					return this._rowguid;
				}
				set
				{
					if (this._rowguid != value)
					{
						this.OnrowguidChanging(value);
						this.SendPropertyChanging();
						this._rowguid = value;
						this.SendPropertyChanged("rowguid");
						this.OnrowguidChanged();
					}
					this.SendPropertySetterInvoked("rowguid", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ModifiedDate", DbType="DateTime NOT NULL", CanBeNull=false)]
			public DateTime ModifiedDate
			{
				get
				{
					return this._ModifiedDate;
				}
				set
				{
					if (this._ModifiedDate != value)
					{
						this.OnModifiedDateChanging(value);
						this.SendPropertyChanging();
						this._ModifiedDate = value;
						this.SendPropertyChanged("ModifiedDate");
						this.OnModifiedDateChanged();
					}
					this.SendPropertySetterInvoked("ModifiedDate", value);
				}
			}
			
			#endregion Columns

			#region Associations
			/// <summary>
			/// Association [FK][One]Sales_Store.CustomerID --- [PK][One]Sales_Customer.CustomerID
			/// </summary>
			[AssociationAttribute(Name="FK_Store_Customer_CustomerID", Storage="_Sales_Customer", ThisKey="CustomerID", OtherKey="CustomerID", IsUnique=true, IsForeignKey=true)]
			public Sales_Customer Sales_Customer
			{
				get
				{
					return this._Sales_Customer.Entity;
				}
				set
				{
					Sales_Customer previousValue = this._Sales_Customer.Entity;
					if ((previousValue != value) || (this._Sales_Customer.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._Sales_Customer.Entity = null;
							previousValue.Sales_Store = null;
						}
						this._Sales_Customer.Entity = value;
						if (value != null)
						{
							value.Sales_Store = this;
							this._CustomerID = value.CustomerID;
						}
						else
						{
							this._CustomerID = default(int);
						}
						this.SendPropertyChanged("Sales_Customer");
					}
					this.SendPropertySetterInvoked("Sales_Customer", value);
				}
			}
			
			/// <summary>
			/// Association [FK][Many]Sales_Store.SalesPersonID --- [PK][One]Sales_SalesPerson.SalesPersonID
			/// </summary>
			[AssociationAttribute(Name="FK_Store_SalesPerson_SalesPersonID", Storage="_Sales_SalesPerson", ThisKey="SalesPersonID", OtherKey="SalesPersonID", IsUnique=false, IsForeignKey=true)]
			public Sales_SalesPerson Sales_SalesPerson
			{
				get
				{
					return this._Sales_SalesPerson.Entity;
				}
				set
				{
					Sales_SalesPerson previousValue = this._Sales_SalesPerson.Entity;
					if ((previousValue != value) || (this._Sales_SalesPerson.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._Sales_SalesPerson.Entity = null;
							previousValue.Sales_StoreList.Remove(this);
						}
						this._Sales_SalesPerson.Entity = value;
						if (value != null)
						{
							value.Sales_StoreList.Add(this);
							this._SalesPersonID = value.SalesPersonID;
						}
						else
						{
							this._SalesPersonID = default(int?);
						}
						this.SendPropertyChanged("Sales_SalesPerson");
					}
					this.SendPropertySetterInvoked("Sales_SalesPerson", value);
				}
			}
			
			/// <summary>
			/// Association [PK][One]Sales_Store.CustomerID --- [FK][Many]Sales_StoreContact.CustomerID
			/// </summary>
			[AssociationAttribute(Name="FK_StoreContact_Store_CustomerID", Storage="_Sales_StoreContactList", ThisKey="CustomerID", OtherKey="CustomerID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<Sales_StoreContact> Sales_StoreContactList
			{
				get { return this._Sales_StoreContactList; }
				set { this._Sales_StoreContactList.Assign(value); }
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
		#endregion Sales.Store

		#region Sales.StoreContact
		[TableAttribute(Name="Sales.StoreContact")]
		public partial class Sales_StoreContact : EntityBase<Sales_StoreContact, AdventureWorksDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private int _CustomerID;
			private int _ContactID;
			private int _ContactTypeID;
			private System.Guid _rowguid;
			private DateTime _ModifiedDate;
			private EntityRef<Person_Contact> _Person_Contact;
			private EntityRef<Person_ContactType> _Person_ContactType;
			private EntityRef<Sales_Store> _Sales_Store;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnCustomerIDChanging(int value);
			partial void OnCustomerIDChanged();
			partial void OnContactIDChanging(int value);
			partial void OnContactIDChanged();
			partial void OnContactTypeIDChanging(int value);
			partial void OnContactTypeIDChanged();
			partial void OnrowguidChanging(System.Guid value);
			partial void OnrowguidChanged();
			partial void OnModifiedDateChanging(DateTime value);
			partial void OnModifiedDateChanged();
			#endregion

			public Sales_StoreContact()
			{
				_Person_Contact = default(EntityRef<Person_Contact>);
				_Person_ContactType = default(EntityRef<Person_ContactType>);
				_Sales_Store = default(EntityRef<Sales_Store>);
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_CustomerID", DbType="Int NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
			public int CustomerID
			{
				get
				{
					return this._CustomerID;
				}
				set
				{
					if (this._CustomerID != value)
					{
						this.OnCustomerIDChanging(value);
						this.SendPropertyChanging();
						this._CustomerID = value;
						this.SendPropertyChanged("CustomerID");
						this.OnCustomerIDChanged();
					}
					this.SendPropertySetterInvoked("CustomerID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ContactID", DbType="Int NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
			public int ContactID
			{
				get
				{
					return this._ContactID;
				}
				set
				{
					if (this._ContactID != value)
					{
						this.OnContactIDChanging(value);
						this.SendPropertyChanging();
						this._ContactID = value;
						this.SendPropertyChanged("ContactID");
						this.OnContactIDChanged();
					}
					this.SendPropertySetterInvoked("ContactID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ContactTypeID", DbType="Int NOT NULL", CanBeNull=false)]
			public int ContactTypeID
			{
				get
				{
					return this._ContactTypeID;
				}
				set
				{
					if (this._ContactTypeID != value)
					{
						this.OnContactTypeIDChanging(value);
						this.SendPropertyChanging();
						this._ContactTypeID = value;
						this.SendPropertyChanged("ContactTypeID");
						this.OnContactTypeIDChanged();
					}
					this.SendPropertySetterInvoked("ContactTypeID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=UniqueIdentifier NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_rowguid", DbType="UniqueIdentifier NOT NULL", CanBeNull=false)]
			public System.Guid rowguid
			{
				get
				{
					return this._rowguid;
				}
				set
				{
					if (this._rowguid != value)
					{
						this.OnrowguidChanging(value);
						this.SendPropertyChanging();
						this._rowguid = value;
						this.SendPropertyChanged("rowguid");
						this.OnrowguidChanged();
					}
					this.SendPropertySetterInvoked("rowguid", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ModifiedDate", DbType="DateTime NOT NULL", CanBeNull=false)]
			public DateTime ModifiedDate
			{
				get
				{
					return this._ModifiedDate;
				}
				set
				{
					if (this._ModifiedDate != value)
					{
						this.OnModifiedDateChanging(value);
						this.SendPropertyChanging();
						this._ModifiedDate = value;
						this.SendPropertyChanged("ModifiedDate");
						this.OnModifiedDateChanged();
					}
					this.SendPropertySetterInvoked("ModifiedDate", value);
				}
			}
			
			#endregion Columns

			#region Associations
			/// <summary>
			/// Association [FK][Many]Sales_StoreContact.ContactID --- [PK][One]Person_Contact.ContactID
			/// </summary>
			[AssociationAttribute(Name="FK_StoreContact_Contact_ContactID", Storage="_Person_Contact", ThisKey="ContactID", OtherKey="ContactID", IsUnique=false, IsForeignKey=true)]
			public Person_Contact Person_Contact
			{
				get
				{
					return this._Person_Contact.Entity;
				}
				set
				{
					Person_Contact previousValue = this._Person_Contact.Entity;
					if ((previousValue != value) || (this._Person_Contact.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._Person_Contact.Entity = null;
							previousValue.Sales_StoreContactList.Remove(this);
						}
						this._Person_Contact.Entity = value;
						if (value != null)
						{
							value.Sales_StoreContactList.Add(this);
							this._ContactID = value.ContactID;
						}
						else
						{
							this._ContactID = default(int);
						}
						this.SendPropertyChanged("Person_Contact");
					}
					this.SendPropertySetterInvoked("Person_Contact", value);
				}
			}
			
			/// <summary>
			/// Association [FK][Many]Sales_StoreContact.ContactTypeID --- [PK][One]Person_ContactType.ContactTypeID
			/// </summary>
			[AssociationAttribute(Name="FK_StoreContact_ContactType_ContactTypeID", Storage="_Person_ContactType", ThisKey="ContactTypeID", OtherKey="ContactTypeID", IsUnique=false, IsForeignKey=true)]
			public Person_ContactType Person_ContactType
			{
				get
				{
					return this._Person_ContactType.Entity;
				}
				set
				{
					Person_ContactType previousValue = this._Person_ContactType.Entity;
					if ((previousValue != value) || (this._Person_ContactType.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._Person_ContactType.Entity = null;
							previousValue.Sales_StoreContactList.Remove(this);
						}
						this._Person_ContactType.Entity = value;
						if (value != null)
						{
							value.Sales_StoreContactList.Add(this);
							this._ContactTypeID = value.ContactTypeID;
						}
						else
						{
							this._ContactTypeID = default(int);
						}
						this.SendPropertyChanged("Person_ContactType");
					}
					this.SendPropertySetterInvoked("Person_ContactType", value);
				}
			}
			
			/// <summary>
			/// Association [FK][Many]Sales_StoreContact.CustomerID --- [PK][One]Sales_Store.CustomerID
			/// </summary>
			[AssociationAttribute(Name="FK_StoreContact_Store_CustomerID", Storage="_Sales_Store", ThisKey="CustomerID", OtherKey="CustomerID", IsUnique=false, IsForeignKey=true)]
			public Sales_Store Sales_Store
			{
				get
				{
					return this._Sales_Store.Entity;
				}
				set
				{
					Sales_Store previousValue = this._Sales_Store.Entity;
					if ((previousValue != value) || (this._Sales_Store.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._Sales_Store.Entity = null;
							previousValue.Sales_StoreContactList.Remove(this);
						}
						this._Sales_Store.Entity = value;
						if (value != null)
						{
							value.Sales_StoreContactList.Add(this);
							this._CustomerID = value.CustomerID;
						}
						else
						{
							this._CustomerID = default(int);
						}
						this.SendPropertyChanged("Sales_Store");
					}
					this.SendPropertySetterInvoked("Sales_Store", value);
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
		#endregion Sales.StoreContact

		#region Production.TransactionHistory
		[TableAttribute(Name="Production.TransactionHistory")]
		public partial class Production_TransactionHistory : EntityBase<Production_TransactionHistory, AdventureWorksDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private int _TransactionID;
			private int _ProductID;
			private int _ReferenceOrderID;
			private int _ReferenceOrderLineID;
			private DateTime _TransactionDate;
			private string _TransactionType;
			private int _Quantity;
			private decimal _ActualCost;
			private DateTime _ModifiedDate;
			private EntityRef<Production_Product> _Production_Product;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnTransactionIDChanging(int value);
			partial void OnTransactionIDChanged();
			partial void OnProductIDChanging(int value);
			partial void OnProductIDChanged();
			partial void OnReferenceOrderIDChanging(int value);
			partial void OnReferenceOrderIDChanged();
			partial void OnReferenceOrderLineIDChanging(int value);
			partial void OnReferenceOrderLineIDChanged();
			partial void OnTransactionDateChanging(DateTime value);
			partial void OnTransactionDateChanged();
			partial void OnTransactionTypeChanging(string value);
			partial void OnTransactionTypeChanged();
			partial void OnQuantityChanging(int value);
			partial void OnQuantityChanged();
			partial void OnActualCostChanging(decimal value);
			partial void OnActualCostChanged();
			partial void OnModifiedDateChanging(DateTime value);
			partial void OnModifiedDateChanged();
			#endregion

			public Production_TransactionHistory()
			{
				_Production_Product = default(EntityRef<Production_Product>);
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=Int NOT NULL IDENTITY
			/// </summary>
			[ColumnAttribute(Storage="_TransactionID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", CanBeNull=false, IsPrimaryKey=true, IsDbGenerated=true)]
			public int TransactionID
			{
				get
				{
					return this._TransactionID;
				}
				set
				{
					if (this._TransactionID != value)
					{
						this.OnTransactionIDChanging(value);
						this.SendPropertyChanging();
						this._TransactionID = value;
						this.SendPropertyChanged("TransactionID");
						this.OnTransactionIDChanged();
					}
					this.SendPropertySetterInvoked("TransactionID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ProductID", DbType="Int NOT NULL", CanBeNull=false)]
			public int ProductID
			{
				get
				{
					return this._ProductID;
				}
				set
				{
					if (this._ProductID != value)
					{
						this.OnProductIDChanging(value);
						this.SendPropertyChanging();
						this._ProductID = value;
						this.SendPropertyChanged("ProductID");
						this.OnProductIDChanged();
					}
					this.SendPropertySetterInvoked("ProductID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ReferenceOrderID", DbType="Int NOT NULL", CanBeNull=false)]
			public int ReferenceOrderID
			{
				get
				{
					return this._ReferenceOrderID;
				}
				set
				{
					if (this._ReferenceOrderID != value)
					{
						this.OnReferenceOrderIDChanging(value);
						this.SendPropertyChanging();
						this._ReferenceOrderID = value;
						this.SendPropertyChanged("ReferenceOrderID");
						this.OnReferenceOrderIDChanged();
					}
					this.SendPropertySetterInvoked("ReferenceOrderID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ReferenceOrderLineID", DbType="Int NOT NULL", CanBeNull=false)]
			public int ReferenceOrderLineID
			{
				get
				{
					return this._ReferenceOrderLineID;
				}
				set
				{
					if (this._ReferenceOrderLineID != value)
					{
						this.OnReferenceOrderLineIDChanging(value);
						this.SendPropertyChanging();
						this._ReferenceOrderLineID = value;
						this.SendPropertyChanged("ReferenceOrderLineID");
						this.OnReferenceOrderLineIDChanged();
					}
					this.SendPropertySetterInvoked("ReferenceOrderLineID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_TransactionDate", DbType="DateTime NOT NULL", CanBeNull=false)]
			public DateTime TransactionDate
			{
				get
				{
					return this._TransactionDate;
				}
				set
				{
					if (this._TransactionDate != value)
					{
						this.OnTransactionDateChanging(value);
						this.SendPropertyChanging();
						this._TransactionDate = value;
						this.SendPropertyChanged("TransactionDate");
						this.OnTransactionDateChanged();
					}
					this.SendPropertySetterInvoked("TransactionDate", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NChar(1) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_TransactionType", DbType="NChar(1) NOT NULL", CanBeNull=false)]
			public string TransactionType
			{
				get
				{
					return this._TransactionType;
				}
				set
				{
					if (this._TransactionType != value)
					{
						this.OnTransactionTypeChanging(value);
						this.SendPropertyChanging();
						this._TransactionType = value;
						this.SendPropertyChanged("TransactionType");
						this.OnTransactionTypeChanged();
					}
					this.SendPropertySetterInvoked("TransactionType", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_Quantity", DbType="Int NOT NULL", CanBeNull=false)]
			public int Quantity
			{
				get
				{
					return this._Quantity;
				}
				set
				{
					if (this._Quantity != value)
					{
						this.OnQuantityChanging(value);
						this.SendPropertyChanging();
						this._Quantity = value;
						this.SendPropertyChanged("Quantity");
						this.OnQuantityChanged();
					}
					this.SendPropertySetterInvoked("Quantity", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Money NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ActualCost", DbType="Money NOT NULL", CanBeNull=false)]
			public decimal ActualCost
			{
				get
				{
					return this._ActualCost;
				}
				set
				{
					if (this._ActualCost != value)
					{
						this.OnActualCostChanging(value);
						this.SendPropertyChanging();
						this._ActualCost = value;
						this.SendPropertyChanged("ActualCost");
						this.OnActualCostChanged();
					}
					this.SendPropertySetterInvoked("ActualCost", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ModifiedDate", DbType="DateTime NOT NULL", CanBeNull=false)]
			public DateTime ModifiedDate
			{
				get
				{
					return this._ModifiedDate;
				}
				set
				{
					if (this._ModifiedDate != value)
					{
						this.OnModifiedDateChanging(value);
						this.SendPropertyChanging();
						this._ModifiedDate = value;
						this.SendPropertyChanged("ModifiedDate");
						this.OnModifiedDateChanged();
					}
					this.SendPropertySetterInvoked("ModifiedDate", value);
				}
			}
			
			#endregion Columns

			#region Associations
			/// <summary>
			/// Association [FK][Many]Production_TransactionHistory.ProductID --- [PK][One]Production_Product.ProductID
			/// </summary>
			[AssociationAttribute(Name="FK_TransactionHistory_Product_ProductID", Storage="_Production_Product", ThisKey="ProductID", OtherKey="ProductID", IsUnique=false, IsForeignKey=true)]
			public Production_Product Production_Product
			{
				get
				{
					return this._Production_Product.Entity;
				}
				set
				{
					Production_Product previousValue = this._Production_Product.Entity;
					if ((previousValue != value) || (this._Production_Product.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._Production_Product.Entity = null;
							previousValue.Production_TransactionHistoryList.Remove(this);
						}
						this._Production_Product.Entity = value;
						if (value != null)
						{
							value.Production_TransactionHistoryList.Add(this);
							this._ProductID = value.ProductID;
						}
						else
						{
							this._ProductID = default(int);
						}
						this.SendPropertyChanged("Production_Product");
					}
					this.SendPropertySetterInvoked("Production_Product", value);
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
		#endregion Production.TransactionHistory

		#region Production.TransactionHistoryArchive
		[TableAttribute(Name="Production.TransactionHistoryArchive")]
		public partial class Production_TransactionHistoryArchive : EntityBase<Production_TransactionHistoryArchive, AdventureWorksDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private int _TransactionID;
			private int _ProductID;
			private int _ReferenceOrderID;
			private int _ReferenceOrderLineID;
			private DateTime _TransactionDate;
			private string _TransactionType;
			private int _Quantity;
			private decimal _ActualCost;
			private DateTime _ModifiedDate;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnTransactionIDChanging(int value);
			partial void OnTransactionIDChanged();
			partial void OnProductIDChanging(int value);
			partial void OnProductIDChanged();
			partial void OnReferenceOrderIDChanging(int value);
			partial void OnReferenceOrderIDChanged();
			partial void OnReferenceOrderLineIDChanging(int value);
			partial void OnReferenceOrderLineIDChanged();
			partial void OnTransactionDateChanging(DateTime value);
			partial void OnTransactionDateChanged();
			partial void OnTransactionTypeChanging(string value);
			partial void OnTransactionTypeChanged();
			partial void OnQuantityChanging(int value);
			partial void OnQuantityChanged();
			partial void OnActualCostChanging(decimal value);
			partial void OnActualCostChanged();
			partial void OnModifiedDateChanging(DateTime value);
			partial void OnModifiedDateChanged();
			#endregion

			public Production_TransactionHistoryArchive()
			{
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_TransactionID", DbType="Int NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
			public int TransactionID
			{
				get
				{
					return this._TransactionID;
				}
				set
				{
					if (this._TransactionID != value)
					{
						this.OnTransactionIDChanging(value);
						this.SendPropertyChanging();
						this._TransactionID = value;
						this.SendPropertyChanged("TransactionID");
						this.OnTransactionIDChanged();
					}
					this.SendPropertySetterInvoked("TransactionID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ProductID", DbType="Int NOT NULL", CanBeNull=false)]
			public int ProductID
			{
				get
				{
					return this._ProductID;
				}
				set
				{
					if (this._ProductID != value)
					{
						this.OnProductIDChanging(value);
						this.SendPropertyChanging();
						this._ProductID = value;
						this.SendPropertyChanged("ProductID");
						this.OnProductIDChanged();
					}
					this.SendPropertySetterInvoked("ProductID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ReferenceOrderID", DbType="Int NOT NULL", CanBeNull=false)]
			public int ReferenceOrderID
			{
				get
				{
					return this._ReferenceOrderID;
				}
				set
				{
					if (this._ReferenceOrderID != value)
					{
						this.OnReferenceOrderIDChanging(value);
						this.SendPropertyChanging();
						this._ReferenceOrderID = value;
						this.SendPropertyChanged("ReferenceOrderID");
						this.OnReferenceOrderIDChanged();
					}
					this.SendPropertySetterInvoked("ReferenceOrderID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ReferenceOrderLineID", DbType="Int NOT NULL", CanBeNull=false)]
			public int ReferenceOrderLineID
			{
				get
				{
					return this._ReferenceOrderLineID;
				}
				set
				{
					if (this._ReferenceOrderLineID != value)
					{
						this.OnReferenceOrderLineIDChanging(value);
						this.SendPropertyChanging();
						this._ReferenceOrderLineID = value;
						this.SendPropertyChanged("ReferenceOrderLineID");
						this.OnReferenceOrderLineIDChanged();
					}
					this.SendPropertySetterInvoked("ReferenceOrderLineID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_TransactionDate", DbType="DateTime NOT NULL", CanBeNull=false)]
			public DateTime TransactionDate
			{
				get
				{
					return this._TransactionDate;
				}
				set
				{
					if (this._TransactionDate != value)
					{
						this.OnTransactionDateChanging(value);
						this.SendPropertyChanging();
						this._TransactionDate = value;
						this.SendPropertyChanged("TransactionDate");
						this.OnTransactionDateChanged();
					}
					this.SendPropertySetterInvoked("TransactionDate", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NChar(1) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_TransactionType", DbType="NChar(1) NOT NULL", CanBeNull=false)]
			public string TransactionType
			{
				get
				{
					return this._TransactionType;
				}
				set
				{
					if (this._TransactionType != value)
					{
						this.OnTransactionTypeChanging(value);
						this.SendPropertyChanging();
						this._TransactionType = value;
						this.SendPropertyChanged("TransactionType");
						this.OnTransactionTypeChanged();
					}
					this.SendPropertySetterInvoked("TransactionType", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_Quantity", DbType="Int NOT NULL", CanBeNull=false)]
			public int Quantity
			{
				get
				{
					return this._Quantity;
				}
				set
				{
					if (this._Quantity != value)
					{
						this.OnQuantityChanging(value);
						this.SendPropertyChanging();
						this._Quantity = value;
						this.SendPropertyChanged("Quantity");
						this.OnQuantityChanged();
					}
					this.SendPropertySetterInvoked("Quantity", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Money NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ActualCost", DbType="Money NOT NULL", CanBeNull=false)]
			public decimal ActualCost
			{
				get
				{
					return this._ActualCost;
				}
				set
				{
					if (this._ActualCost != value)
					{
						this.OnActualCostChanging(value);
						this.SendPropertyChanging();
						this._ActualCost = value;
						this.SendPropertyChanged("ActualCost");
						this.OnActualCostChanged();
					}
					this.SendPropertySetterInvoked("ActualCost", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ModifiedDate", DbType="DateTime NOT NULL", CanBeNull=false)]
			public DateTime ModifiedDate
			{
				get
				{
					return this._ModifiedDate;
				}
				set
				{
					if (this._ModifiedDate != value)
					{
						this.OnModifiedDateChanging(value);
						this.SendPropertyChanging();
						this._ModifiedDate = value;
						this.SendPropertyChanged("ModifiedDate");
						this.OnModifiedDateChanged();
					}
					this.SendPropertySetterInvoked("ModifiedDate", value);
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
		#endregion Production.TransactionHistoryArchive

		#region Production.UnitMeasure
		[TableAttribute(Name="Production.UnitMeasure")]
		public partial class Production_UnitMeasure : EntityBase<Production_UnitMeasure, AdventureWorksDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private string _UnitMeasureCode;
			private string _Name;
			private DateTime _ModifiedDate;
			private EntitySet<Production_BillOfMaterials> _Production_BillOfMaterialsList;
			private EntitySet<Production_Product> _Production_ProductList;
			private EntitySet<Production_Product> _UnitMeasureCodeProduction_ProductList;
			private EntitySet<Purchasing_ProductVendor> _Purchasing_ProductVendorList;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnUnitMeasureCodeChanging(string value);
			partial void OnUnitMeasureCodeChanged();
			partial void OnNameChanging(string value);
			partial void OnNameChanged();
			partial void OnModifiedDateChanging(DateTime value);
			partial void OnModifiedDateChanged();
			#endregion

			public Production_UnitMeasure()
			{
				_Production_BillOfMaterialsList = new EntitySet<Production_BillOfMaterials>(
					new Action<Production_BillOfMaterials>(item=>{this.SendPropertyChanging(); item.Production_UnitMeasure=this;}), 
					new Action<Production_BillOfMaterials>(item=>{this.SendPropertyChanging(); item.Production_UnitMeasure=null;}));
				_Production_ProductList = new EntitySet<Production_Product>(
					new Action<Production_Product>(item=>{this.SendPropertyChanging(); item.Production_UnitMeasure=this;}), 
					new Action<Production_Product>(item=>{this.SendPropertyChanging(); item.Production_UnitMeasure=null;}));
				_UnitMeasureCodeProduction_ProductList = new EntitySet<Production_Product>(
					new Action<Production_Product>(item=>{this.SendPropertyChanging(); item.WeightUnitMeasureCodeProduction_UnitMeasure=this;}), 
					new Action<Production_Product>(item=>{this.SendPropertyChanging(); item.WeightUnitMeasureCodeProduction_UnitMeasure=null;}));
				_Purchasing_ProductVendorList = new EntitySet<Purchasing_ProductVendor>(
					new Action<Purchasing_ProductVendor>(item=>{this.SendPropertyChanging(); item.Production_UnitMeasure=this;}), 
					new Action<Purchasing_ProductVendor>(item=>{this.SendPropertyChanging(); item.Production_UnitMeasure=null;}));
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=NChar(3) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_UnitMeasureCode", DbType="NChar(3) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
			public string UnitMeasureCode
			{
				get
				{
					return this._UnitMeasureCode;
				}
				set
				{
					if (this._UnitMeasureCode != value)
					{
						this.OnUnitMeasureCodeChanging(value);
						this.SendPropertyChanging();
						this._UnitMeasureCode = value;
						this.SendPropertyChanged("UnitMeasureCode");
						this.OnUnitMeasureCodeChanged();
					}
					this.SendPropertySetterInvoked("UnitMeasureCode", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(50) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_Name", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
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
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ModifiedDate", DbType="DateTime NOT NULL", CanBeNull=false)]
			public DateTime ModifiedDate
			{
				get
				{
					return this._ModifiedDate;
				}
				set
				{
					if (this._ModifiedDate != value)
					{
						this.OnModifiedDateChanging(value);
						this.SendPropertyChanging();
						this._ModifiedDate = value;
						this.SendPropertyChanged("ModifiedDate");
						this.OnModifiedDateChanged();
					}
					this.SendPropertySetterInvoked("ModifiedDate", value);
				}
			}
			
			#endregion Columns

			#region Associations
			/// <summary>
			/// Association [PK][One]Production_UnitMeasure.UnitMeasureCode --- [FK][Many]Production_BillOfMaterials.UnitMeasureCode
			/// </summary>
			[AssociationAttribute(Name="FK_BillOfMaterials_UnitMeasure_UnitMeasureCode", Storage="_Production_BillOfMaterialsList", ThisKey="UnitMeasureCode", OtherKey="UnitMeasureCode", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<Production_BillOfMaterials> Production_BillOfMaterialsList
			{
				get { return this._Production_BillOfMaterialsList; }
				set { this._Production_BillOfMaterialsList.Assign(value); }
			}
			
			/// <summary>
			/// Association [PK][One]Production_UnitMeasure.UnitMeasureCode --- [FK][Many]Production_Product.SizeUnitMeasureCode
			/// </summary>
			[AssociationAttribute(Name="FK_Product_UnitMeasure_SizeUnitMeasureCode", Storage="_Production_ProductList", ThisKey="UnitMeasureCode", OtherKey="SizeUnitMeasureCode", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<Production_Product> Production_ProductList
			{
				get { return this._Production_ProductList; }
				set { this._Production_ProductList.Assign(value); }
			}
			
			/// <summary>
			/// Association [PK][One]Production_UnitMeasure.UnitMeasureCode --- [FK][Many]Production_Product.WeightUnitMeasureCode
			/// </summary>
			[AssociationAttribute(Name="FK_Product_UnitMeasure_WeightUnitMeasureCode", Storage="_UnitMeasureCodeProduction_ProductList", ThisKey="UnitMeasureCode", OtherKey="WeightUnitMeasureCode", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<Production_Product> UnitMeasureCodeProduction_ProductList
			{
				get { return this._UnitMeasureCodeProduction_ProductList; }
				set { this._UnitMeasureCodeProduction_ProductList.Assign(value); }
			}
			
			/// <summary>
			/// Association [PK][One]Production_UnitMeasure.UnitMeasureCode --- [FK][Many]Purchasing_ProductVendor.UnitMeasureCode
			/// </summary>
			[AssociationAttribute(Name="FK_ProductVendor_UnitMeasure_UnitMeasureCode", Storage="_Purchasing_ProductVendorList", ThisKey="UnitMeasureCode", OtherKey="UnitMeasureCode", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<Purchasing_ProductVendor> Purchasing_ProductVendorList
			{
				get { return this._Purchasing_ProductVendorList; }
				set { this._Purchasing_ProductVendorList.Assign(value); }
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
		#endregion Production.UnitMeasure

		#region Person.vAdditionalContactInfo
		[TableAttribute(Name="Person.vAdditionalContactInfo")]
		public partial class Person_vAdditionalContactInfo : EntityBase<Person_vAdditionalContactInfo, AdventureWorksDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private int _ContactID;
			private string _FirstName;
			private string _MiddleName;
			private string _LastName;
			private string _TelephoneNumber;
			private string _TelephoneSpecialInstructions;
			private string _Street;
			private string _City;
			private string _StateProvince;
			private string _PostalCode;
			private string _CountryRegion;
			private string _HomeAddressSpecialInstructions;
			private string _EMailAddress;
			private string _EMailSpecialInstructions;
			private string _EMailTelephoneNumber;
			private System.Guid _rowguid;
			private DateTime _ModifiedDate;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnContactIDChanging(int value);
			partial void OnContactIDChanged();
			partial void OnFirstNameChanging(string value);
			partial void OnFirstNameChanged();
			partial void OnMiddleNameChanging(string value);
			partial void OnMiddleNameChanged();
			partial void OnLastNameChanging(string value);
			partial void OnLastNameChanged();
			partial void OnTelephoneNumberChanging(string value);
			partial void OnTelephoneNumberChanged();
			partial void OnTelephoneSpecialInstructionsChanging(string value);
			partial void OnTelephoneSpecialInstructionsChanged();
			partial void OnStreetChanging(string value);
			partial void OnStreetChanged();
			partial void OnCityChanging(string value);
			partial void OnCityChanged();
			partial void OnStateProvinceChanging(string value);
			partial void OnStateProvinceChanged();
			partial void OnPostalCodeChanging(string value);
			partial void OnPostalCodeChanged();
			partial void OnCountryRegionChanging(string value);
			partial void OnCountryRegionChanged();
			partial void OnHomeAddressSpecialInstructionsChanging(string value);
			partial void OnHomeAddressSpecialInstructionsChanged();
			partial void OnEMailAddressChanging(string value);
			partial void OnEMailAddressChanged();
			partial void OnEMailSpecialInstructionsChanging(string value);
			partial void OnEMailSpecialInstructionsChanged();
			partial void OnEMailTelephoneNumberChanging(string value);
			partial void OnEMailTelephoneNumberChanged();
			partial void OnrowguidChanging(System.Guid value);
			partial void OnrowguidChanged();
			partial void OnModifiedDateChanging(DateTime value);
			partial void OnModifiedDateChanged();
			#endregion

			public Person_vAdditionalContactInfo()
			{
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=Int NOT NULL IDENTITY
			/// </summary>
			[ColumnAttribute(Storage="_ContactID", DbType="Int NOT NULL IDENTITY", CanBeNull=false)]
			public int ContactID
			{
				get
				{
					return this._ContactID;
				}
				set
				{
					if (this._ContactID != value)
					{
						this.OnContactIDChanging(value);
						this.SendPropertyChanging();
						this._ContactID = value;
						this.SendPropertyChanged("ContactID");
						this.OnContactIDChanged();
					}
					this.SendPropertySetterInvoked("ContactID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(50) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_FirstName", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
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
			/// Column DbType=NVarChar(50)
			/// </summary>
			[ColumnAttribute(Storage="_MiddleName", DbType="NVarChar(50)", CanBeNull=true)]
			public string MiddleName
			{
				get
				{
					return this._MiddleName;
				}
				set
				{
					if (this._MiddleName != value)
					{
						this.OnMiddleNameChanging(value);
						this.SendPropertyChanging();
						this._MiddleName = value;
						this.SendPropertyChanged("MiddleName");
						this.OnMiddleNameChanged();
					}
					this.SendPropertySetterInvoked("MiddleName", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(50) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_LastName", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
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
			/// Column DbType=NVarChar(50)
			/// </summary>
			[ColumnAttribute(Storage="_TelephoneNumber", DbType="NVarChar(50)", CanBeNull=true)]
			public string TelephoneNumber
			{
				get
				{
					return this._TelephoneNumber;
				}
				set
				{
					if (this._TelephoneNumber != value)
					{
						this.OnTelephoneNumberChanging(value);
						this.SendPropertyChanging();
						this._TelephoneNumber = value;
						this.SendPropertyChanged("TelephoneNumber");
						this.OnTelephoneNumberChanged();
					}
					this.SendPropertySetterInvoked("TelephoneNumber", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(MAX)
			/// </summary>
			[ColumnAttribute(Storage="_TelephoneSpecialInstructions", DbType="NVarChar(MAX)", CanBeNull=true)]
			public string TelephoneSpecialInstructions
			{
				get
				{
					return this._TelephoneSpecialInstructions;
				}
				set
				{
					if (this._TelephoneSpecialInstructions != value)
					{
						this.OnTelephoneSpecialInstructionsChanging(value);
						this.SendPropertyChanging();
						this._TelephoneSpecialInstructions = value;
						this.SendPropertyChanged("TelephoneSpecialInstructions");
						this.OnTelephoneSpecialInstructionsChanged();
					}
					this.SendPropertySetterInvoked("TelephoneSpecialInstructions", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(50)
			/// </summary>
			[ColumnAttribute(Storage="_Street", DbType="NVarChar(50)", CanBeNull=true)]
			public string Street
			{
				get
				{
					return this._Street;
				}
				set
				{
					if (this._Street != value)
					{
						this.OnStreetChanging(value);
						this.SendPropertyChanging();
						this._Street = value;
						this.SendPropertyChanged("Street");
						this.OnStreetChanged();
					}
					this.SendPropertySetterInvoked("Street", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(50)
			/// </summary>
			[ColumnAttribute(Storage="_City", DbType="NVarChar(50)", CanBeNull=true)]
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
			/// Column DbType=NVarChar(50)
			/// </summary>
			[ColumnAttribute(Storage="_StateProvince", DbType="NVarChar(50)", CanBeNull=true)]
			public string StateProvince
			{
				get
				{
					return this._StateProvince;
				}
				set
				{
					if (this._StateProvince != value)
					{
						this.OnStateProvinceChanging(value);
						this.SendPropertyChanging();
						this._StateProvince = value;
						this.SendPropertyChanged("StateProvince");
						this.OnStateProvinceChanged();
					}
					this.SendPropertySetterInvoked("StateProvince", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(50)
			/// </summary>
			[ColumnAttribute(Storage="_PostalCode", DbType="NVarChar(50)", CanBeNull=true)]
			public string PostalCode
			{
				get
				{
					return this._PostalCode;
				}
				set
				{
					if (this._PostalCode != value)
					{
						this.OnPostalCodeChanging(value);
						this.SendPropertyChanging();
						this._PostalCode = value;
						this.SendPropertyChanged("PostalCode");
						this.OnPostalCodeChanged();
					}
					this.SendPropertySetterInvoked("PostalCode", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(50)
			/// </summary>
			[ColumnAttribute(Storage="_CountryRegion", DbType="NVarChar(50)", CanBeNull=true)]
			public string CountryRegion
			{
				get
				{
					return this._CountryRegion;
				}
				set
				{
					if (this._CountryRegion != value)
					{
						this.OnCountryRegionChanging(value);
						this.SendPropertyChanging();
						this._CountryRegion = value;
						this.SendPropertyChanged("CountryRegion");
						this.OnCountryRegionChanged();
					}
					this.SendPropertySetterInvoked("CountryRegion", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(MAX)
			/// </summary>
			[ColumnAttribute(Storage="_HomeAddressSpecialInstructions", DbType="NVarChar(MAX)", CanBeNull=true)]
			public string HomeAddressSpecialInstructions
			{
				get
				{
					return this._HomeAddressSpecialInstructions;
				}
				set
				{
					if (this._HomeAddressSpecialInstructions != value)
					{
						this.OnHomeAddressSpecialInstructionsChanging(value);
						this.SendPropertyChanging();
						this._HomeAddressSpecialInstructions = value;
						this.SendPropertyChanged("HomeAddressSpecialInstructions");
						this.OnHomeAddressSpecialInstructionsChanged();
					}
					this.SendPropertySetterInvoked("HomeAddressSpecialInstructions", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(128)
			/// </summary>
			[ColumnAttribute(Storage="_EMailAddress", DbType="NVarChar(128)", CanBeNull=true)]
			public string EMailAddress
			{
				get
				{
					return this._EMailAddress;
				}
				set
				{
					if (this._EMailAddress != value)
					{
						this.OnEMailAddressChanging(value);
						this.SendPropertyChanging();
						this._EMailAddress = value;
						this.SendPropertyChanged("EMailAddress");
						this.OnEMailAddressChanged();
					}
					this.SendPropertySetterInvoked("EMailAddress", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(MAX)
			/// </summary>
			[ColumnAttribute(Storage="_EMailSpecialInstructions", DbType="NVarChar(MAX)", CanBeNull=true)]
			public string EMailSpecialInstructions
			{
				get
				{
					return this._EMailSpecialInstructions;
				}
				set
				{
					if (this._EMailSpecialInstructions != value)
					{
						this.OnEMailSpecialInstructionsChanging(value);
						this.SendPropertyChanging();
						this._EMailSpecialInstructions = value;
						this.SendPropertyChanged("EMailSpecialInstructions");
						this.OnEMailSpecialInstructionsChanged();
					}
					this.SendPropertySetterInvoked("EMailSpecialInstructions", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(50)
			/// </summary>
			[ColumnAttribute(Storage="_EMailTelephoneNumber", DbType="NVarChar(50)", CanBeNull=true)]
			public string EMailTelephoneNumber
			{
				get
				{
					return this._EMailTelephoneNumber;
				}
				set
				{
					if (this._EMailTelephoneNumber != value)
					{
						this.OnEMailTelephoneNumberChanging(value);
						this.SendPropertyChanging();
						this._EMailTelephoneNumber = value;
						this.SendPropertyChanged("EMailTelephoneNumber");
						this.OnEMailTelephoneNumberChanged();
					}
					this.SendPropertySetterInvoked("EMailTelephoneNumber", value);
				}
			}
			
			/// <summary>
			/// Column DbType=UniqueIdentifier NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_rowguid", DbType="UniqueIdentifier NOT NULL", CanBeNull=false)]
			public System.Guid rowguid
			{
				get
				{
					return this._rowguid;
				}
				set
				{
					if (this._rowguid != value)
					{
						this.OnrowguidChanging(value);
						this.SendPropertyChanging();
						this._rowguid = value;
						this.SendPropertyChanged("rowguid");
						this.OnrowguidChanged();
					}
					this.SendPropertySetterInvoked("rowguid", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ModifiedDate", DbType="DateTime NOT NULL", CanBeNull=false)]
			public DateTime ModifiedDate
			{
				get
				{
					return this._ModifiedDate;
				}
				set
				{
					if (this._ModifiedDate != value)
					{
						this.OnModifiedDateChanging(value);
						this.SendPropertyChanging();
						this._ModifiedDate = value;
						this.SendPropertyChanged("ModifiedDate");
						this.OnModifiedDateChanged();
					}
					this.SendPropertySetterInvoked("ModifiedDate", value);
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
		#endregion Person.vAdditionalContactInfo

		#region HumanResources.vEmployee
		[TableAttribute(Name="HumanResources.vEmployee")]
		public partial class HumanResources_vEmployee : EntityBase<HumanResources_vEmployee, AdventureWorksDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private int _EmployeeID;
			private string _Title;
			private string _FirstName;
			private string _MiddleName;
			private string _LastName;
			private string _Suffix;
			private string _JobTitle;
			private string _Phone;
			private string _EmailAddress;
			private int _EmailPromotion;
			private string _AddressLine1;
			private string _AddressLine2;
			private string _City;
			private string _StateProvinceName;
			private string _PostalCode;
			private string _CountryRegionName;
			private System.Xml.Linq.XElement _AdditionalContactInfo;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnEmployeeIDChanging(int value);
			partial void OnEmployeeIDChanged();
			partial void OnTitleChanging(string value);
			partial void OnTitleChanged();
			partial void OnFirstNameChanging(string value);
			partial void OnFirstNameChanged();
			partial void OnMiddleNameChanging(string value);
			partial void OnMiddleNameChanged();
			partial void OnLastNameChanging(string value);
			partial void OnLastNameChanged();
			partial void OnSuffixChanging(string value);
			partial void OnSuffixChanged();
			partial void OnJobTitleChanging(string value);
			partial void OnJobTitleChanged();
			partial void OnPhoneChanging(string value);
			partial void OnPhoneChanged();
			partial void OnEmailAddressChanging(string value);
			partial void OnEmailAddressChanged();
			partial void OnEmailPromotionChanging(int value);
			partial void OnEmailPromotionChanged();
			partial void OnAddressLine1Changing(string value);
			partial void OnAddressLine1Changed();
			partial void OnAddressLine2Changing(string value);
			partial void OnAddressLine2Changed();
			partial void OnCityChanging(string value);
			partial void OnCityChanged();
			partial void OnStateProvinceNameChanging(string value);
			partial void OnStateProvinceNameChanged();
			partial void OnPostalCodeChanging(string value);
			partial void OnPostalCodeChanged();
			partial void OnCountryRegionNameChanging(string value);
			partial void OnCountryRegionNameChanged();
			partial void OnAdditionalContactInfoChanging(System.Xml.Linq.XElement value);
			partial void OnAdditionalContactInfoChanged();
			#endregion

			public HumanResources_vEmployee()
			{
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_EmployeeID", DbType="Int NOT NULL", CanBeNull=false)]
			public int EmployeeID
			{
				get
				{
					return this._EmployeeID;
				}
				set
				{
					if (this._EmployeeID != value)
					{
						this.OnEmployeeIDChanging(value);
						this.SendPropertyChanging();
						this._EmployeeID = value;
						this.SendPropertyChanged("EmployeeID");
						this.OnEmployeeIDChanged();
					}
					this.SendPropertySetterInvoked("EmployeeID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(8)
			/// </summary>
			[ColumnAttribute(Storage="_Title", DbType="NVarChar(8)", CanBeNull=true)]
			public string Title
			{
				get
				{
					return this._Title;
				}
				set
				{
					if (this._Title != value)
					{
						this.OnTitleChanging(value);
						this.SendPropertyChanging();
						this._Title = value;
						this.SendPropertyChanged("Title");
						this.OnTitleChanged();
					}
					this.SendPropertySetterInvoked("Title", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(50) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_FirstName", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
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
			/// Column DbType=NVarChar(50)
			/// </summary>
			[ColumnAttribute(Storage="_MiddleName", DbType="NVarChar(50)", CanBeNull=true)]
			public string MiddleName
			{
				get
				{
					return this._MiddleName;
				}
				set
				{
					if (this._MiddleName != value)
					{
						this.OnMiddleNameChanging(value);
						this.SendPropertyChanging();
						this._MiddleName = value;
						this.SendPropertyChanged("MiddleName");
						this.OnMiddleNameChanged();
					}
					this.SendPropertySetterInvoked("MiddleName", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(50) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_LastName", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
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
			/// Column DbType=NVarChar(10)
			/// </summary>
			[ColumnAttribute(Storage="_Suffix", DbType="NVarChar(10)", CanBeNull=true)]
			public string Suffix
			{
				get
				{
					return this._Suffix;
				}
				set
				{
					if (this._Suffix != value)
					{
						this.OnSuffixChanging(value);
						this.SendPropertyChanging();
						this._Suffix = value;
						this.SendPropertyChanged("Suffix");
						this.OnSuffixChanged();
					}
					this.SendPropertySetterInvoked("Suffix", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(50) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_JobTitle", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
			public string JobTitle
			{
				get
				{
					return this._JobTitle;
				}
				set
				{
					if (this._JobTitle != value)
					{
						this.OnJobTitleChanging(value);
						this.SendPropertyChanging();
						this._JobTitle = value;
						this.SendPropertyChanged("JobTitle");
						this.OnJobTitleChanged();
					}
					this.SendPropertySetterInvoked("JobTitle", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(25)
			/// </summary>
			[ColumnAttribute(Storage="_Phone", DbType="NVarChar(25)", CanBeNull=true)]
			public string Phone
			{
				get
				{
					return this._Phone;
				}
				set
				{
					if (this._Phone != value)
					{
						this.OnPhoneChanging(value);
						this.SendPropertyChanging();
						this._Phone = value;
						this.SendPropertyChanged("Phone");
						this.OnPhoneChanged();
					}
					this.SendPropertySetterInvoked("Phone", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(50)
			/// </summary>
			[ColumnAttribute(Storage="_EmailAddress", DbType="NVarChar(50)", CanBeNull=true)]
			public string EmailAddress
			{
				get
				{
					return this._EmailAddress;
				}
				set
				{
					if (this._EmailAddress != value)
					{
						this.OnEmailAddressChanging(value);
						this.SendPropertyChanging();
						this._EmailAddress = value;
						this.SendPropertyChanged("EmailAddress");
						this.OnEmailAddressChanged();
					}
					this.SendPropertySetterInvoked("EmailAddress", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_EmailPromotion", DbType="Int NOT NULL", CanBeNull=false)]
			public int EmailPromotion
			{
				get
				{
					return this._EmailPromotion;
				}
				set
				{
					if (this._EmailPromotion != value)
					{
						this.OnEmailPromotionChanging(value);
						this.SendPropertyChanging();
						this._EmailPromotion = value;
						this.SendPropertyChanged("EmailPromotion");
						this.OnEmailPromotionChanged();
					}
					this.SendPropertySetterInvoked("EmailPromotion", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(60) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_AddressLine1", DbType="NVarChar(60) NOT NULL", CanBeNull=false)]
			public string AddressLine1
			{
				get
				{
					return this._AddressLine1;
				}
				set
				{
					if (this._AddressLine1 != value)
					{
						this.OnAddressLine1Changing(value);
						this.SendPropertyChanging();
						this._AddressLine1 = value;
						this.SendPropertyChanged("AddressLine1");
						this.OnAddressLine1Changed();
					}
					this.SendPropertySetterInvoked("AddressLine1", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(60)
			/// </summary>
			[ColumnAttribute(Storage="_AddressLine2", DbType="NVarChar(60)", CanBeNull=true)]
			public string AddressLine2
			{
				get
				{
					return this._AddressLine2;
				}
				set
				{
					if (this._AddressLine2 != value)
					{
						this.OnAddressLine2Changing(value);
						this.SendPropertyChanging();
						this._AddressLine2 = value;
						this.SendPropertyChanged("AddressLine2");
						this.OnAddressLine2Changed();
					}
					this.SendPropertySetterInvoked("AddressLine2", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(30) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_City", DbType="NVarChar(30) NOT NULL", CanBeNull=false)]
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
			/// Column DbType=NVarChar(50) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_StateProvinceName", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
			public string StateProvinceName
			{
				get
				{
					return this._StateProvinceName;
				}
				set
				{
					if (this._StateProvinceName != value)
					{
						this.OnStateProvinceNameChanging(value);
						this.SendPropertyChanging();
						this._StateProvinceName = value;
						this.SendPropertyChanged("StateProvinceName");
						this.OnStateProvinceNameChanged();
					}
					this.SendPropertySetterInvoked("StateProvinceName", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(15) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_PostalCode", DbType="NVarChar(15) NOT NULL", CanBeNull=false)]
			public string PostalCode
			{
				get
				{
					return this._PostalCode;
				}
				set
				{
					if (this._PostalCode != value)
					{
						this.OnPostalCodeChanging(value);
						this.SendPropertyChanging();
						this._PostalCode = value;
						this.SendPropertyChanged("PostalCode");
						this.OnPostalCodeChanged();
					}
					this.SendPropertySetterInvoked("PostalCode", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(50) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_CountryRegionName", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
			public string CountryRegionName
			{
				get
				{
					return this._CountryRegionName;
				}
				set
				{
					if (this._CountryRegionName != value)
					{
						this.OnCountryRegionNameChanging(value);
						this.SendPropertyChanging();
						this._CountryRegionName = value;
						this.SendPropertyChanged("CountryRegionName");
						this.OnCountryRegionNameChanged();
					}
					this.SendPropertySetterInvoked("CountryRegionName", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Xml
			/// </summary>
			[ColumnAttribute(Storage="_AdditionalContactInfo", DbType="Xml", CanBeNull=true)]
			public System.Xml.Linq.XElement AdditionalContactInfo
			{
				get
				{
					return this._AdditionalContactInfo;
				}
				set
				{
					if (this._AdditionalContactInfo != value)
					{
						this.OnAdditionalContactInfoChanging(value);
						this.SendPropertyChanging();
						this._AdditionalContactInfo = value;
						this.SendPropertyChanged("AdditionalContactInfo");
						this.OnAdditionalContactInfoChanged();
					}
					this.SendPropertySetterInvoked("AdditionalContactInfo", value);
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
		#endregion HumanResources.vEmployee

		#region HumanResources.vEmployeeDepartment
		[TableAttribute(Name="HumanResources.vEmployeeDepartment")]
		public partial class HumanResources_vEmployeeDepartment : EntityBase<HumanResources_vEmployeeDepartment, AdventureWorksDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private int _EmployeeID;
			private string _Title;
			private string _FirstName;
			private string _MiddleName;
			private string _LastName;
			private string _Suffix;
			private string _JobTitle;
			private string _Department;
			private string _GroupName;
			private DateTime _StartDate;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnEmployeeIDChanging(int value);
			partial void OnEmployeeIDChanged();
			partial void OnTitleChanging(string value);
			partial void OnTitleChanged();
			partial void OnFirstNameChanging(string value);
			partial void OnFirstNameChanged();
			partial void OnMiddleNameChanging(string value);
			partial void OnMiddleNameChanged();
			partial void OnLastNameChanging(string value);
			partial void OnLastNameChanged();
			partial void OnSuffixChanging(string value);
			partial void OnSuffixChanged();
			partial void OnJobTitleChanging(string value);
			partial void OnJobTitleChanged();
			partial void OnDepartmentChanging(string value);
			partial void OnDepartmentChanged();
			partial void OnGroupNameChanging(string value);
			partial void OnGroupNameChanged();
			partial void OnStartDateChanging(DateTime value);
			partial void OnStartDateChanged();
			#endregion

			public HumanResources_vEmployeeDepartment()
			{
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_EmployeeID", DbType="Int NOT NULL", CanBeNull=false)]
			public int EmployeeID
			{
				get
				{
					return this._EmployeeID;
				}
				set
				{
					if (this._EmployeeID != value)
					{
						this.OnEmployeeIDChanging(value);
						this.SendPropertyChanging();
						this._EmployeeID = value;
						this.SendPropertyChanged("EmployeeID");
						this.OnEmployeeIDChanged();
					}
					this.SendPropertySetterInvoked("EmployeeID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(8)
			/// </summary>
			[ColumnAttribute(Storage="_Title", DbType="NVarChar(8)", CanBeNull=true)]
			public string Title
			{
				get
				{
					return this._Title;
				}
				set
				{
					if (this._Title != value)
					{
						this.OnTitleChanging(value);
						this.SendPropertyChanging();
						this._Title = value;
						this.SendPropertyChanged("Title");
						this.OnTitleChanged();
					}
					this.SendPropertySetterInvoked("Title", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(50) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_FirstName", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
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
			/// Column DbType=NVarChar(50)
			/// </summary>
			[ColumnAttribute(Storage="_MiddleName", DbType="NVarChar(50)", CanBeNull=true)]
			public string MiddleName
			{
				get
				{
					return this._MiddleName;
				}
				set
				{
					if (this._MiddleName != value)
					{
						this.OnMiddleNameChanging(value);
						this.SendPropertyChanging();
						this._MiddleName = value;
						this.SendPropertyChanged("MiddleName");
						this.OnMiddleNameChanged();
					}
					this.SendPropertySetterInvoked("MiddleName", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(50) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_LastName", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
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
			/// Column DbType=NVarChar(10)
			/// </summary>
			[ColumnAttribute(Storage="_Suffix", DbType="NVarChar(10)", CanBeNull=true)]
			public string Suffix
			{
				get
				{
					return this._Suffix;
				}
				set
				{
					if (this._Suffix != value)
					{
						this.OnSuffixChanging(value);
						this.SendPropertyChanging();
						this._Suffix = value;
						this.SendPropertyChanged("Suffix");
						this.OnSuffixChanged();
					}
					this.SendPropertySetterInvoked("Suffix", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(50) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_JobTitle", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
			public string JobTitle
			{
				get
				{
					return this._JobTitle;
				}
				set
				{
					if (this._JobTitle != value)
					{
						this.OnJobTitleChanging(value);
						this.SendPropertyChanging();
						this._JobTitle = value;
						this.SendPropertyChanged("JobTitle");
						this.OnJobTitleChanged();
					}
					this.SendPropertySetterInvoked("JobTitle", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(50) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_Department", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
			public string Department
			{
				get
				{
					return this._Department;
				}
				set
				{
					if (this._Department != value)
					{
						this.OnDepartmentChanging(value);
						this.SendPropertyChanging();
						this._Department = value;
						this.SendPropertyChanged("Department");
						this.OnDepartmentChanged();
					}
					this.SendPropertySetterInvoked("Department", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(50) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_GroupName", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
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
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_StartDate", DbType="DateTime NOT NULL", CanBeNull=false)]
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
						this.OnStartDateChanging(value);
						this.SendPropertyChanging();
						this._StartDate = value;
						this.SendPropertyChanged("StartDate");
						this.OnStartDateChanged();
					}
					this.SendPropertySetterInvoked("StartDate", value);
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
		#endregion HumanResources.vEmployeeDepartment

		#region HumanResources.vEmployeeDepartmentHistory
		[TableAttribute(Name="HumanResources.vEmployeeDepartmentHistory")]
		public partial class HumanResources_vEmployeeDepartmentHistory : EntityBase<HumanResources_vEmployeeDepartmentHistory, AdventureWorksDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private int _EmployeeID;
			private string _Title;
			private string _FirstName;
			private string _MiddleName;
			private string _LastName;
			private string _Suffix;
			private string _Shift;
			private string _Department;
			private string _GroupName;
			private DateTime _StartDate;
			private DateTime? _EndDate;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnEmployeeIDChanging(int value);
			partial void OnEmployeeIDChanged();
			partial void OnTitleChanging(string value);
			partial void OnTitleChanged();
			partial void OnFirstNameChanging(string value);
			partial void OnFirstNameChanged();
			partial void OnMiddleNameChanging(string value);
			partial void OnMiddleNameChanged();
			partial void OnLastNameChanging(string value);
			partial void OnLastNameChanged();
			partial void OnSuffixChanging(string value);
			partial void OnSuffixChanged();
			partial void OnShiftChanging(string value);
			partial void OnShiftChanged();
			partial void OnDepartmentChanging(string value);
			partial void OnDepartmentChanged();
			partial void OnGroupNameChanging(string value);
			partial void OnGroupNameChanged();
			partial void OnStartDateChanging(DateTime value);
			partial void OnStartDateChanged();
			partial void OnEndDateChanging(DateTime? value);
			partial void OnEndDateChanged();
			#endregion

			public HumanResources_vEmployeeDepartmentHistory()
			{
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_EmployeeID", DbType="Int NOT NULL", CanBeNull=false)]
			public int EmployeeID
			{
				get
				{
					return this._EmployeeID;
				}
				set
				{
					if (this._EmployeeID != value)
					{
						this.OnEmployeeIDChanging(value);
						this.SendPropertyChanging();
						this._EmployeeID = value;
						this.SendPropertyChanged("EmployeeID");
						this.OnEmployeeIDChanged();
					}
					this.SendPropertySetterInvoked("EmployeeID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(8)
			/// </summary>
			[ColumnAttribute(Storage="_Title", DbType="NVarChar(8)", CanBeNull=true)]
			public string Title
			{
				get
				{
					return this._Title;
				}
				set
				{
					if (this._Title != value)
					{
						this.OnTitleChanging(value);
						this.SendPropertyChanging();
						this._Title = value;
						this.SendPropertyChanged("Title");
						this.OnTitleChanged();
					}
					this.SendPropertySetterInvoked("Title", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(50) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_FirstName", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
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
			/// Column DbType=NVarChar(50)
			/// </summary>
			[ColumnAttribute(Storage="_MiddleName", DbType="NVarChar(50)", CanBeNull=true)]
			public string MiddleName
			{
				get
				{
					return this._MiddleName;
				}
				set
				{
					if (this._MiddleName != value)
					{
						this.OnMiddleNameChanging(value);
						this.SendPropertyChanging();
						this._MiddleName = value;
						this.SendPropertyChanged("MiddleName");
						this.OnMiddleNameChanged();
					}
					this.SendPropertySetterInvoked("MiddleName", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(50) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_LastName", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
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
			/// Column DbType=NVarChar(10)
			/// </summary>
			[ColumnAttribute(Storage="_Suffix", DbType="NVarChar(10)", CanBeNull=true)]
			public string Suffix
			{
				get
				{
					return this._Suffix;
				}
				set
				{
					if (this._Suffix != value)
					{
						this.OnSuffixChanging(value);
						this.SendPropertyChanging();
						this._Suffix = value;
						this.SendPropertyChanged("Suffix");
						this.OnSuffixChanged();
					}
					this.SendPropertySetterInvoked("Suffix", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(50) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_Shift", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
			public string Shift
			{
				get
				{
					return this._Shift;
				}
				set
				{
					if (this._Shift != value)
					{
						this.OnShiftChanging(value);
						this.SendPropertyChanging();
						this._Shift = value;
						this.SendPropertyChanged("Shift");
						this.OnShiftChanged();
					}
					this.SendPropertySetterInvoked("Shift", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(50) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_Department", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
			public string Department
			{
				get
				{
					return this._Department;
				}
				set
				{
					if (this._Department != value)
					{
						this.OnDepartmentChanging(value);
						this.SendPropertyChanging();
						this._Department = value;
						this.SendPropertyChanged("Department");
						this.OnDepartmentChanged();
					}
					this.SendPropertySetterInvoked("Department", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(50) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_GroupName", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
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
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_StartDate", DbType="DateTime NOT NULL", CanBeNull=false)]
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
						this.OnStartDateChanging(value);
						this.SendPropertyChanging();
						this._StartDate = value;
						this.SendPropertyChanged("StartDate");
						this.OnStartDateChanged();
					}
					this.SendPropertySetterInvoked("StartDate", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime
			/// </summary>
			[ColumnAttribute(Storage="_EndDate", DbType="DateTime", CanBeNull=true)]
			public DateTime? EndDate
			{
				get
				{
					return this._EndDate;
				}
				set
				{
					if (this._EndDate != value)
					{
						this.OnEndDateChanging(value);
						this.SendPropertyChanging();
						this._EndDate = value;
						this.SendPropertyChanged("EndDate");
						this.OnEndDateChanged();
					}
					this.SendPropertySetterInvoked("EndDate", value);
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
		#endregion HumanResources.vEmployeeDepartmentHistory

		#region Purchasing.Vendor
		[TableAttribute(Name="Purchasing.Vendor")]
		public partial class Purchasing_Vendor : EntityBase<Purchasing_Vendor, AdventureWorksDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private int _VendorID;
			private string _AccountNumber;
			private string _Name;
			private byte _CreditRating;
			private bool _PreferredVendorStatus;
			private bool _ActiveFlag;
			private string _PurchasingWebServiceURL;
			private DateTime _ModifiedDate;
			private EntitySet<Purchasing_ProductVendor> _Purchasing_ProductVendorList;
			private EntitySet<Purchasing_PurchaseOrderHeader> _Purchasing_PurchaseOrderHeaderList;
			private EntitySet<Purchasing_VendorAddress> _Purchasing_VendorAddressList;
			private EntitySet<Purchasing_VendorContact> _Purchasing_VendorContactList;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnVendorIDChanging(int value);
			partial void OnVendorIDChanged();
			partial void OnAccountNumberChanging(string value);
			partial void OnAccountNumberChanged();
			partial void OnNameChanging(string value);
			partial void OnNameChanged();
			partial void OnCreditRatingChanging(byte value);
			partial void OnCreditRatingChanged();
			partial void OnPreferredVendorStatusChanging(bool value);
			partial void OnPreferredVendorStatusChanged();
			partial void OnActiveFlagChanging(bool value);
			partial void OnActiveFlagChanged();
			partial void OnPurchasingWebServiceURLChanging(string value);
			partial void OnPurchasingWebServiceURLChanged();
			partial void OnModifiedDateChanging(DateTime value);
			partial void OnModifiedDateChanged();
			#endregion

			public Purchasing_Vendor()
			{
				_Purchasing_ProductVendorList = new EntitySet<Purchasing_ProductVendor>(
					new Action<Purchasing_ProductVendor>(item=>{this.SendPropertyChanging(); item.Purchasing_Vendor=this;}), 
					new Action<Purchasing_ProductVendor>(item=>{this.SendPropertyChanging(); item.Purchasing_Vendor=null;}));
				_Purchasing_PurchaseOrderHeaderList = new EntitySet<Purchasing_PurchaseOrderHeader>(
					new Action<Purchasing_PurchaseOrderHeader>(item=>{this.SendPropertyChanging(); item.Purchasing_Vendor=this;}), 
					new Action<Purchasing_PurchaseOrderHeader>(item=>{this.SendPropertyChanging(); item.Purchasing_Vendor=null;}));
				_Purchasing_VendorAddressList = new EntitySet<Purchasing_VendorAddress>(
					new Action<Purchasing_VendorAddress>(item=>{this.SendPropertyChanging(); item.Purchasing_Vendor=this;}), 
					new Action<Purchasing_VendorAddress>(item=>{this.SendPropertyChanging(); item.Purchasing_Vendor=null;}));
				_Purchasing_VendorContactList = new EntitySet<Purchasing_VendorContact>(
					new Action<Purchasing_VendorContact>(item=>{this.SendPropertyChanging(); item.Purchasing_Vendor=this;}), 
					new Action<Purchasing_VendorContact>(item=>{this.SendPropertyChanging(); item.Purchasing_Vendor=null;}));
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=Int NOT NULL IDENTITY
			/// </summary>
			[ColumnAttribute(Storage="_VendorID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", CanBeNull=false, IsPrimaryKey=true, IsDbGenerated=true)]
			public int VendorID
			{
				get
				{
					return this._VendorID;
				}
				set
				{
					if (this._VendorID != value)
					{
						this.OnVendorIDChanging(value);
						this.SendPropertyChanging();
						this._VendorID = value;
						this.SendPropertyChanged("VendorID");
						this.OnVendorIDChanged();
					}
					this.SendPropertySetterInvoked("VendorID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(15) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_AccountNumber", DbType="NVarChar(15) NOT NULL", CanBeNull=false)]
			public string AccountNumber
			{
				get
				{
					return this._AccountNumber;
				}
				set
				{
					if (this._AccountNumber != value)
					{
						this.OnAccountNumberChanging(value);
						this.SendPropertyChanging();
						this._AccountNumber = value;
						this.SendPropertyChanged("AccountNumber");
						this.OnAccountNumberChanged();
					}
					this.SendPropertySetterInvoked("AccountNumber", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(50) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_Name", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
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
			/// Column DbType=TinyInt NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_CreditRating", DbType="TinyInt NOT NULL", CanBeNull=false)]
			public byte CreditRating
			{
				get
				{
					return this._CreditRating;
				}
				set
				{
					if (this._CreditRating != value)
					{
						this.OnCreditRatingChanging(value);
						this.SendPropertyChanging();
						this._CreditRating = value;
						this.SendPropertyChanged("CreditRating");
						this.OnCreditRatingChanged();
					}
					this.SendPropertySetterInvoked("CreditRating", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Bit NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_PreferredVendorStatus", DbType="Bit NOT NULL", CanBeNull=false)]
			public bool PreferredVendorStatus
			{
				get
				{
					return this._PreferredVendorStatus;
				}
				set
				{
					if (this._PreferredVendorStatus != value)
					{
						this.OnPreferredVendorStatusChanging(value);
						this.SendPropertyChanging();
						this._PreferredVendorStatus = value;
						this.SendPropertyChanged("PreferredVendorStatus");
						this.OnPreferredVendorStatusChanged();
					}
					this.SendPropertySetterInvoked("PreferredVendorStatus", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Bit NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ActiveFlag", DbType="Bit NOT NULL", CanBeNull=false)]
			public bool ActiveFlag
			{
				get
				{
					return this._ActiveFlag;
				}
				set
				{
					if (this._ActiveFlag != value)
					{
						this.OnActiveFlagChanging(value);
						this.SendPropertyChanging();
						this._ActiveFlag = value;
						this.SendPropertyChanged("ActiveFlag");
						this.OnActiveFlagChanged();
					}
					this.SendPropertySetterInvoked("ActiveFlag", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(1024)
			/// </summary>
			[ColumnAttribute(Storage="_PurchasingWebServiceURL", DbType="NVarChar(1024)", CanBeNull=true)]
			public string PurchasingWebServiceURL
			{
				get
				{
					return this._PurchasingWebServiceURL;
				}
				set
				{
					if (this._PurchasingWebServiceURL != value)
					{
						this.OnPurchasingWebServiceURLChanging(value);
						this.SendPropertyChanging();
						this._PurchasingWebServiceURL = value;
						this.SendPropertyChanged("PurchasingWebServiceURL");
						this.OnPurchasingWebServiceURLChanged();
					}
					this.SendPropertySetterInvoked("PurchasingWebServiceURL", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ModifiedDate", DbType="DateTime NOT NULL", CanBeNull=false)]
			public DateTime ModifiedDate
			{
				get
				{
					return this._ModifiedDate;
				}
				set
				{
					if (this._ModifiedDate != value)
					{
						this.OnModifiedDateChanging(value);
						this.SendPropertyChanging();
						this._ModifiedDate = value;
						this.SendPropertyChanged("ModifiedDate");
						this.OnModifiedDateChanged();
					}
					this.SendPropertySetterInvoked("ModifiedDate", value);
				}
			}
			
			#endregion Columns

			#region Associations
			/// <summary>
			/// Association [PK][One]Purchasing_Vendor.VendorID --- [FK][Many]Purchasing_ProductVendor.VendorID
			/// </summary>
			[AssociationAttribute(Name="FK_ProductVendor_Vendor_VendorID", Storage="_Purchasing_ProductVendorList", ThisKey="VendorID", OtherKey="VendorID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<Purchasing_ProductVendor> Purchasing_ProductVendorList
			{
				get { return this._Purchasing_ProductVendorList; }
				set { this._Purchasing_ProductVendorList.Assign(value); }
			}
			
			/// <summary>
			/// Association [PK][One]Purchasing_Vendor.VendorID --- [FK][Many]Purchasing_PurchaseOrderHeader.VendorID
			/// </summary>
			[AssociationAttribute(Name="FK_PurchaseOrderHeader_Vendor_VendorID", Storage="_Purchasing_PurchaseOrderHeaderList", ThisKey="VendorID", OtherKey="VendorID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<Purchasing_PurchaseOrderHeader> Purchasing_PurchaseOrderHeaderList
			{
				get { return this._Purchasing_PurchaseOrderHeaderList; }
				set { this._Purchasing_PurchaseOrderHeaderList.Assign(value); }
			}
			
			/// <summary>
			/// Association [PK][One]Purchasing_Vendor.VendorID --- [FK][Many]Purchasing_VendorAddress.VendorID
			/// </summary>
			[AssociationAttribute(Name="FK_VendorAddress_Vendor_VendorID", Storage="_Purchasing_VendorAddressList", ThisKey="VendorID", OtherKey="VendorID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<Purchasing_VendorAddress> Purchasing_VendorAddressList
			{
				get { return this._Purchasing_VendorAddressList; }
				set { this._Purchasing_VendorAddressList.Assign(value); }
			}
			
			/// <summary>
			/// Association [PK][One]Purchasing_Vendor.VendorID --- [FK][Many]Purchasing_VendorContact.VendorID
			/// </summary>
			[AssociationAttribute(Name="FK_VendorContact_Vendor_VendorID", Storage="_Purchasing_VendorContactList", ThisKey="VendorID", OtherKey="VendorID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<Purchasing_VendorContact> Purchasing_VendorContactList
			{
				get { return this._Purchasing_VendorContactList; }
				set { this._Purchasing_VendorContactList.Assign(value); }
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
		#endregion Purchasing.Vendor

		#region Purchasing.VendorAddress
		[TableAttribute(Name="Purchasing.VendorAddress")]
		public partial class Purchasing_VendorAddress : EntityBase<Purchasing_VendorAddress, AdventureWorksDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private int _VendorID;
			private int _AddressID;
			private int _AddressTypeID;
			private DateTime _ModifiedDate;
			private EntityRef<Person_Address> _Person_Address;
			private EntityRef<Person_AddressType> _Person_AddressType;
			private EntityRef<Purchasing_Vendor> _Purchasing_Vendor;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnVendorIDChanging(int value);
			partial void OnVendorIDChanged();
			partial void OnAddressIDChanging(int value);
			partial void OnAddressIDChanged();
			partial void OnAddressTypeIDChanging(int value);
			partial void OnAddressTypeIDChanged();
			partial void OnModifiedDateChanging(DateTime value);
			partial void OnModifiedDateChanged();
			#endregion

			public Purchasing_VendorAddress()
			{
				_Person_Address = default(EntityRef<Person_Address>);
				_Person_AddressType = default(EntityRef<Person_AddressType>);
				_Purchasing_Vendor = default(EntityRef<Purchasing_Vendor>);
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_VendorID", DbType="Int NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
			public int VendorID
			{
				get
				{
					return this._VendorID;
				}
				set
				{
					if (this._VendorID != value)
					{
						this.OnVendorIDChanging(value);
						this.SendPropertyChanging();
						this._VendorID = value;
						this.SendPropertyChanged("VendorID");
						this.OnVendorIDChanged();
					}
					this.SendPropertySetterInvoked("VendorID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_AddressID", DbType="Int NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
			public int AddressID
			{
				get
				{
					return this._AddressID;
				}
				set
				{
					if (this._AddressID != value)
					{
						this.OnAddressIDChanging(value);
						this.SendPropertyChanging();
						this._AddressID = value;
						this.SendPropertyChanged("AddressID");
						this.OnAddressIDChanged();
					}
					this.SendPropertySetterInvoked("AddressID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_AddressTypeID", DbType="Int NOT NULL", CanBeNull=false)]
			public int AddressTypeID
			{
				get
				{
					return this._AddressTypeID;
				}
				set
				{
					if (this._AddressTypeID != value)
					{
						this.OnAddressTypeIDChanging(value);
						this.SendPropertyChanging();
						this._AddressTypeID = value;
						this.SendPropertyChanged("AddressTypeID");
						this.OnAddressTypeIDChanged();
					}
					this.SendPropertySetterInvoked("AddressTypeID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ModifiedDate", DbType="DateTime NOT NULL", CanBeNull=false)]
			public DateTime ModifiedDate
			{
				get
				{
					return this._ModifiedDate;
				}
				set
				{
					if (this._ModifiedDate != value)
					{
						this.OnModifiedDateChanging(value);
						this.SendPropertyChanging();
						this._ModifiedDate = value;
						this.SendPropertyChanged("ModifiedDate");
						this.OnModifiedDateChanged();
					}
					this.SendPropertySetterInvoked("ModifiedDate", value);
				}
			}
			
			#endregion Columns

			#region Associations
			/// <summary>
			/// Association [FK][Many]Purchasing_VendorAddress.AddressID --- [PK][One]Person_Address.AddressID
			/// </summary>
			[AssociationAttribute(Name="FK_VendorAddress_Address_AddressID", Storage="_Person_Address", ThisKey="AddressID", OtherKey="AddressID", IsUnique=false, IsForeignKey=true)]
			public Person_Address Person_Address
			{
				get
				{
					return this._Person_Address.Entity;
				}
				set
				{
					Person_Address previousValue = this._Person_Address.Entity;
					if ((previousValue != value) || (this._Person_Address.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._Person_Address.Entity = null;
							previousValue.Purchasing_VendorAddressList.Remove(this);
						}
						this._Person_Address.Entity = value;
						if (value != null)
						{
							value.Purchasing_VendorAddressList.Add(this);
							this._AddressID = value.AddressID;
						}
						else
						{
							this._AddressID = default(int);
						}
						this.SendPropertyChanged("Person_Address");
					}
					this.SendPropertySetterInvoked("Person_Address", value);
				}
			}
			
			/// <summary>
			/// Association [FK][Many]Purchasing_VendorAddress.AddressTypeID --- [PK][One]Person_AddressType.AddressTypeID
			/// </summary>
			[AssociationAttribute(Name="FK_VendorAddress_AddressType_AddressTypeID", Storage="_Person_AddressType", ThisKey="AddressTypeID", OtherKey="AddressTypeID", IsUnique=false, IsForeignKey=true)]
			public Person_AddressType Person_AddressType
			{
				get
				{
					return this._Person_AddressType.Entity;
				}
				set
				{
					Person_AddressType previousValue = this._Person_AddressType.Entity;
					if ((previousValue != value) || (this._Person_AddressType.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._Person_AddressType.Entity = null;
							previousValue.Purchasing_VendorAddressList.Remove(this);
						}
						this._Person_AddressType.Entity = value;
						if (value != null)
						{
							value.Purchasing_VendorAddressList.Add(this);
							this._AddressTypeID = value.AddressTypeID;
						}
						else
						{
							this._AddressTypeID = default(int);
						}
						this.SendPropertyChanged("Person_AddressType");
					}
					this.SendPropertySetterInvoked("Person_AddressType", value);
				}
			}
			
			/// <summary>
			/// Association [FK][Many]Purchasing_VendorAddress.VendorID --- [PK][One]Purchasing_Vendor.VendorID
			/// </summary>
			[AssociationAttribute(Name="FK_VendorAddress_Vendor_VendorID", Storage="_Purchasing_Vendor", ThisKey="VendorID", OtherKey="VendorID", IsUnique=false, IsForeignKey=true)]
			public Purchasing_Vendor Purchasing_Vendor
			{
				get
				{
					return this._Purchasing_Vendor.Entity;
				}
				set
				{
					Purchasing_Vendor previousValue = this._Purchasing_Vendor.Entity;
					if ((previousValue != value) || (this._Purchasing_Vendor.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._Purchasing_Vendor.Entity = null;
							previousValue.Purchasing_VendorAddressList.Remove(this);
						}
						this._Purchasing_Vendor.Entity = value;
						if (value != null)
						{
							value.Purchasing_VendorAddressList.Add(this);
							this._VendorID = value.VendorID;
						}
						else
						{
							this._VendorID = default(int);
						}
						this.SendPropertyChanged("Purchasing_Vendor");
					}
					this.SendPropertySetterInvoked("Purchasing_Vendor", value);
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
		#endregion Purchasing.VendorAddress

		#region Purchasing.VendorContact
		[TableAttribute(Name="Purchasing.VendorContact")]
		public partial class Purchasing_VendorContact : EntityBase<Purchasing_VendorContact, AdventureWorksDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private int _VendorID;
			private int _ContactID;
			private int _ContactTypeID;
			private DateTime _ModifiedDate;
			private EntityRef<Person_Contact> _Person_Contact;
			private EntityRef<Person_ContactType> _Person_ContactType;
			private EntityRef<Purchasing_Vendor> _Purchasing_Vendor;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnVendorIDChanging(int value);
			partial void OnVendorIDChanged();
			partial void OnContactIDChanging(int value);
			partial void OnContactIDChanged();
			partial void OnContactTypeIDChanging(int value);
			partial void OnContactTypeIDChanged();
			partial void OnModifiedDateChanging(DateTime value);
			partial void OnModifiedDateChanged();
			#endregion

			public Purchasing_VendorContact()
			{
				_Person_Contact = default(EntityRef<Person_Contact>);
				_Person_ContactType = default(EntityRef<Person_ContactType>);
				_Purchasing_Vendor = default(EntityRef<Purchasing_Vendor>);
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_VendorID", DbType="Int NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
			public int VendorID
			{
				get
				{
					return this._VendorID;
				}
				set
				{
					if (this._VendorID != value)
					{
						this.OnVendorIDChanging(value);
						this.SendPropertyChanging();
						this._VendorID = value;
						this.SendPropertyChanged("VendorID");
						this.OnVendorIDChanged();
					}
					this.SendPropertySetterInvoked("VendorID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ContactID", DbType="Int NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
			public int ContactID
			{
				get
				{
					return this._ContactID;
				}
				set
				{
					if (this._ContactID != value)
					{
						this.OnContactIDChanging(value);
						this.SendPropertyChanging();
						this._ContactID = value;
						this.SendPropertyChanged("ContactID");
						this.OnContactIDChanged();
					}
					this.SendPropertySetterInvoked("ContactID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ContactTypeID", DbType="Int NOT NULL", CanBeNull=false)]
			public int ContactTypeID
			{
				get
				{
					return this._ContactTypeID;
				}
				set
				{
					if (this._ContactTypeID != value)
					{
						this.OnContactTypeIDChanging(value);
						this.SendPropertyChanging();
						this._ContactTypeID = value;
						this.SendPropertyChanged("ContactTypeID");
						this.OnContactTypeIDChanged();
					}
					this.SendPropertySetterInvoked("ContactTypeID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ModifiedDate", DbType="DateTime NOT NULL", CanBeNull=false)]
			public DateTime ModifiedDate
			{
				get
				{
					return this._ModifiedDate;
				}
				set
				{
					if (this._ModifiedDate != value)
					{
						this.OnModifiedDateChanging(value);
						this.SendPropertyChanging();
						this._ModifiedDate = value;
						this.SendPropertyChanged("ModifiedDate");
						this.OnModifiedDateChanged();
					}
					this.SendPropertySetterInvoked("ModifiedDate", value);
				}
			}
			
			#endregion Columns

			#region Associations
			/// <summary>
			/// Association [FK][Many]Purchasing_VendorContact.ContactID --- [PK][One]Person_Contact.ContactID
			/// </summary>
			[AssociationAttribute(Name="FK_VendorContact_Contact_ContactID", Storage="_Person_Contact", ThisKey="ContactID", OtherKey="ContactID", IsUnique=false, IsForeignKey=true)]
			public Person_Contact Person_Contact
			{
				get
				{
					return this._Person_Contact.Entity;
				}
				set
				{
					Person_Contact previousValue = this._Person_Contact.Entity;
					if ((previousValue != value) || (this._Person_Contact.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._Person_Contact.Entity = null;
							previousValue.Purchasing_VendorContactList.Remove(this);
						}
						this._Person_Contact.Entity = value;
						if (value != null)
						{
							value.Purchasing_VendorContactList.Add(this);
							this._ContactID = value.ContactID;
						}
						else
						{
							this._ContactID = default(int);
						}
						this.SendPropertyChanged("Person_Contact");
					}
					this.SendPropertySetterInvoked("Person_Contact", value);
				}
			}
			
			/// <summary>
			/// Association [FK][Many]Purchasing_VendorContact.ContactTypeID --- [PK][One]Person_ContactType.ContactTypeID
			/// </summary>
			[AssociationAttribute(Name="FK_VendorContact_ContactType_ContactTypeID", Storage="_Person_ContactType", ThisKey="ContactTypeID", OtherKey="ContactTypeID", IsUnique=false, IsForeignKey=true)]
			public Person_ContactType Person_ContactType
			{
				get
				{
					return this._Person_ContactType.Entity;
				}
				set
				{
					Person_ContactType previousValue = this._Person_ContactType.Entity;
					if ((previousValue != value) || (this._Person_ContactType.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._Person_ContactType.Entity = null;
							previousValue.Purchasing_VendorContactList.Remove(this);
						}
						this._Person_ContactType.Entity = value;
						if (value != null)
						{
							value.Purchasing_VendorContactList.Add(this);
							this._ContactTypeID = value.ContactTypeID;
						}
						else
						{
							this._ContactTypeID = default(int);
						}
						this.SendPropertyChanged("Person_ContactType");
					}
					this.SendPropertySetterInvoked("Person_ContactType", value);
				}
			}
			
			/// <summary>
			/// Association [FK][Many]Purchasing_VendorContact.VendorID --- [PK][One]Purchasing_Vendor.VendorID
			/// </summary>
			[AssociationAttribute(Name="FK_VendorContact_Vendor_VendorID", Storage="_Purchasing_Vendor", ThisKey="VendorID", OtherKey="VendorID", IsUnique=false, IsForeignKey=true)]
			public Purchasing_Vendor Purchasing_Vendor
			{
				get
				{
					return this._Purchasing_Vendor.Entity;
				}
				set
				{
					Purchasing_Vendor previousValue = this._Purchasing_Vendor.Entity;
					if ((previousValue != value) || (this._Purchasing_Vendor.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._Purchasing_Vendor.Entity = null;
							previousValue.Purchasing_VendorContactList.Remove(this);
						}
						this._Purchasing_Vendor.Entity = value;
						if (value != null)
						{
							value.Purchasing_VendorContactList.Add(this);
							this._VendorID = value.VendorID;
						}
						else
						{
							this._VendorID = default(int);
						}
						this.SendPropertyChanged("Purchasing_Vendor");
					}
					this.SendPropertySetterInvoked("Purchasing_Vendor", value);
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
		#endregion Purchasing.VendorContact

		#region Sales.vIndividualCustomer
		[TableAttribute(Name="Sales.vIndividualCustomer")]
		public partial class Sales_vIndividualCustomer : EntityBase<Sales_vIndividualCustomer, AdventureWorksDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private int _CustomerID;
			private string _Title;
			private string _FirstName;
			private string _MiddleName;
			private string _LastName;
			private string _Suffix;
			private string _Phone;
			private string _EmailAddress;
			private int _EmailPromotion;
			private string _AddressType;
			private string _AddressLine1;
			private string _AddressLine2;
			private string _City;
			private string _StateProvinceName;
			private string _PostalCode;
			private string _CountryRegionName;
			private System.Xml.Linq.XElement _Demographics;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnCustomerIDChanging(int value);
			partial void OnCustomerIDChanged();
			partial void OnTitleChanging(string value);
			partial void OnTitleChanged();
			partial void OnFirstNameChanging(string value);
			partial void OnFirstNameChanged();
			partial void OnMiddleNameChanging(string value);
			partial void OnMiddleNameChanged();
			partial void OnLastNameChanging(string value);
			partial void OnLastNameChanged();
			partial void OnSuffixChanging(string value);
			partial void OnSuffixChanged();
			partial void OnPhoneChanging(string value);
			partial void OnPhoneChanged();
			partial void OnEmailAddressChanging(string value);
			partial void OnEmailAddressChanged();
			partial void OnEmailPromotionChanging(int value);
			partial void OnEmailPromotionChanged();
			partial void OnAddressTypeChanging(string value);
			partial void OnAddressTypeChanged();
			partial void OnAddressLine1Changing(string value);
			partial void OnAddressLine1Changed();
			partial void OnAddressLine2Changing(string value);
			partial void OnAddressLine2Changed();
			partial void OnCityChanging(string value);
			partial void OnCityChanged();
			partial void OnStateProvinceNameChanging(string value);
			partial void OnStateProvinceNameChanged();
			partial void OnPostalCodeChanging(string value);
			partial void OnPostalCodeChanged();
			partial void OnCountryRegionNameChanging(string value);
			partial void OnCountryRegionNameChanged();
			partial void OnDemographicsChanging(System.Xml.Linq.XElement value);
			partial void OnDemographicsChanged();
			#endregion

			public Sales_vIndividualCustomer()
			{
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_CustomerID", DbType="Int NOT NULL", CanBeNull=false)]
			public int CustomerID
			{
				get
				{
					return this._CustomerID;
				}
				set
				{
					if (this._CustomerID != value)
					{
						this.OnCustomerIDChanging(value);
						this.SendPropertyChanging();
						this._CustomerID = value;
						this.SendPropertyChanged("CustomerID");
						this.OnCustomerIDChanged();
					}
					this.SendPropertySetterInvoked("CustomerID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(8)
			/// </summary>
			[ColumnAttribute(Storage="_Title", DbType="NVarChar(8)", CanBeNull=true)]
			public string Title
			{
				get
				{
					return this._Title;
				}
				set
				{
					if (this._Title != value)
					{
						this.OnTitleChanging(value);
						this.SendPropertyChanging();
						this._Title = value;
						this.SendPropertyChanged("Title");
						this.OnTitleChanged();
					}
					this.SendPropertySetterInvoked("Title", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(50) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_FirstName", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
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
			/// Column DbType=NVarChar(50)
			/// </summary>
			[ColumnAttribute(Storage="_MiddleName", DbType="NVarChar(50)", CanBeNull=true)]
			public string MiddleName
			{
				get
				{
					return this._MiddleName;
				}
				set
				{
					if (this._MiddleName != value)
					{
						this.OnMiddleNameChanging(value);
						this.SendPropertyChanging();
						this._MiddleName = value;
						this.SendPropertyChanged("MiddleName");
						this.OnMiddleNameChanged();
					}
					this.SendPropertySetterInvoked("MiddleName", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(50) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_LastName", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
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
			/// Column DbType=NVarChar(10)
			/// </summary>
			[ColumnAttribute(Storage="_Suffix", DbType="NVarChar(10)", CanBeNull=true)]
			public string Suffix
			{
				get
				{
					return this._Suffix;
				}
				set
				{
					if (this._Suffix != value)
					{
						this.OnSuffixChanging(value);
						this.SendPropertyChanging();
						this._Suffix = value;
						this.SendPropertyChanged("Suffix");
						this.OnSuffixChanged();
					}
					this.SendPropertySetterInvoked("Suffix", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(25)
			/// </summary>
			[ColumnAttribute(Storage="_Phone", DbType="NVarChar(25)", CanBeNull=true)]
			public string Phone
			{
				get
				{
					return this._Phone;
				}
				set
				{
					if (this._Phone != value)
					{
						this.OnPhoneChanging(value);
						this.SendPropertyChanging();
						this._Phone = value;
						this.SendPropertyChanged("Phone");
						this.OnPhoneChanged();
					}
					this.SendPropertySetterInvoked("Phone", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(50)
			/// </summary>
			[ColumnAttribute(Storage="_EmailAddress", DbType="NVarChar(50)", CanBeNull=true)]
			public string EmailAddress
			{
				get
				{
					return this._EmailAddress;
				}
				set
				{
					if (this._EmailAddress != value)
					{
						this.OnEmailAddressChanging(value);
						this.SendPropertyChanging();
						this._EmailAddress = value;
						this.SendPropertyChanged("EmailAddress");
						this.OnEmailAddressChanged();
					}
					this.SendPropertySetterInvoked("EmailAddress", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_EmailPromotion", DbType="Int NOT NULL", CanBeNull=false)]
			public int EmailPromotion
			{
				get
				{
					return this._EmailPromotion;
				}
				set
				{
					if (this._EmailPromotion != value)
					{
						this.OnEmailPromotionChanging(value);
						this.SendPropertyChanging();
						this._EmailPromotion = value;
						this.SendPropertyChanged("EmailPromotion");
						this.OnEmailPromotionChanged();
					}
					this.SendPropertySetterInvoked("EmailPromotion", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(50) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_AddressType", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
			public string AddressType
			{
				get
				{
					return this._AddressType;
				}
				set
				{
					if (this._AddressType != value)
					{
						this.OnAddressTypeChanging(value);
						this.SendPropertyChanging();
						this._AddressType = value;
						this.SendPropertyChanged("AddressType");
						this.OnAddressTypeChanged();
					}
					this.SendPropertySetterInvoked("AddressType", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(60) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_AddressLine1", DbType="NVarChar(60) NOT NULL", CanBeNull=false)]
			public string AddressLine1
			{
				get
				{
					return this._AddressLine1;
				}
				set
				{
					if (this._AddressLine1 != value)
					{
						this.OnAddressLine1Changing(value);
						this.SendPropertyChanging();
						this._AddressLine1 = value;
						this.SendPropertyChanged("AddressLine1");
						this.OnAddressLine1Changed();
					}
					this.SendPropertySetterInvoked("AddressLine1", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(60)
			/// </summary>
			[ColumnAttribute(Storage="_AddressLine2", DbType="NVarChar(60)", CanBeNull=true)]
			public string AddressLine2
			{
				get
				{
					return this._AddressLine2;
				}
				set
				{
					if (this._AddressLine2 != value)
					{
						this.OnAddressLine2Changing(value);
						this.SendPropertyChanging();
						this._AddressLine2 = value;
						this.SendPropertyChanged("AddressLine2");
						this.OnAddressLine2Changed();
					}
					this.SendPropertySetterInvoked("AddressLine2", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(30) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_City", DbType="NVarChar(30) NOT NULL", CanBeNull=false)]
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
			/// Column DbType=NVarChar(50) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_StateProvinceName", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
			public string StateProvinceName
			{
				get
				{
					return this._StateProvinceName;
				}
				set
				{
					if (this._StateProvinceName != value)
					{
						this.OnStateProvinceNameChanging(value);
						this.SendPropertyChanging();
						this._StateProvinceName = value;
						this.SendPropertyChanged("StateProvinceName");
						this.OnStateProvinceNameChanged();
					}
					this.SendPropertySetterInvoked("StateProvinceName", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(15) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_PostalCode", DbType="NVarChar(15) NOT NULL", CanBeNull=false)]
			public string PostalCode
			{
				get
				{
					return this._PostalCode;
				}
				set
				{
					if (this._PostalCode != value)
					{
						this.OnPostalCodeChanging(value);
						this.SendPropertyChanging();
						this._PostalCode = value;
						this.SendPropertyChanged("PostalCode");
						this.OnPostalCodeChanged();
					}
					this.SendPropertySetterInvoked("PostalCode", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(50) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_CountryRegionName", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
			public string CountryRegionName
			{
				get
				{
					return this._CountryRegionName;
				}
				set
				{
					if (this._CountryRegionName != value)
					{
						this.OnCountryRegionNameChanging(value);
						this.SendPropertyChanging();
						this._CountryRegionName = value;
						this.SendPropertyChanged("CountryRegionName");
						this.OnCountryRegionNameChanged();
					}
					this.SendPropertySetterInvoked("CountryRegionName", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Xml
			/// </summary>
			[ColumnAttribute(Storage="_Demographics", DbType="Xml", CanBeNull=true)]
			public System.Xml.Linq.XElement Demographics
			{
				get
				{
					return this._Demographics;
				}
				set
				{
					if (this._Demographics != value)
					{
						this.OnDemographicsChanging(value);
						this.SendPropertyChanging();
						this._Demographics = value;
						this.SendPropertyChanged("Demographics");
						this.OnDemographicsChanged();
					}
					this.SendPropertySetterInvoked("Demographics", value);
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
		#endregion Sales.vIndividualCustomer

		#region Sales.vIndividualDemographics
		[TableAttribute(Name="Sales.vIndividualDemographics")]
		public partial class Sales_vIndividualDemographics : EntityBase<Sales_vIndividualDemographics, AdventureWorksDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private int _CustomerID;
			private decimal? _TotalPurchaseYTD;
			private DateTime? _DateFirstPurchase;
			private DateTime? _BirthDate;
			private string _MaritalStatus;
			private string _YearlyIncome;
			private string _Gender;
			private int? _TotalChildren;
			private int? _NumberChildrenAtHome;
			private string _Education;
			private string _Occupation;
			private bool? _HomeOwnerFlag;
			private int? _NumberCarsOwned;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnCustomerIDChanging(int value);
			partial void OnCustomerIDChanged();
			partial void OnTotalPurchaseYTDChanging(decimal? value);
			partial void OnTotalPurchaseYTDChanged();
			partial void OnDateFirstPurchaseChanging(DateTime? value);
			partial void OnDateFirstPurchaseChanged();
			partial void OnBirthDateChanging(DateTime? value);
			partial void OnBirthDateChanged();
			partial void OnMaritalStatusChanging(string value);
			partial void OnMaritalStatusChanged();
			partial void OnYearlyIncomeChanging(string value);
			partial void OnYearlyIncomeChanged();
			partial void OnGenderChanging(string value);
			partial void OnGenderChanged();
			partial void OnTotalChildrenChanging(int? value);
			partial void OnTotalChildrenChanged();
			partial void OnNumberChildrenAtHomeChanging(int? value);
			partial void OnNumberChildrenAtHomeChanged();
			partial void OnEducationChanging(string value);
			partial void OnEducationChanged();
			partial void OnOccupationChanging(string value);
			partial void OnOccupationChanged();
			partial void OnHomeOwnerFlagChanging(bool? value);
			partial void OnHomeOwnerFlagChanged();
			partial void OnNumberCarsOwnedChanging(int? value);
			partial void OnNumberCarsOwnedChanged();
			#endregion

			public Sales_vIndividualDemographics()
			{
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_CustomerID", DbType="Int NOT NULL", CanBeNull=false)]
			public int CustomerID
			{
				get
				{
					return this._CustomerID;
				}
				set
				{
					if (this._CustomerID != value)
					{
						this.OnCustomerIDChanging(value);
						this.SendPropertyChanging();
						this._CustomerID = value;
						this.SendPropertyChanged("CustomerID");
						this.OnCustomerIDChanged();
					}
					this.SendPropertySetterInvoked("CustomerID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Money
			/// </summary>
			[ColumnAttribute(Storage="_TotalPurchaseYTD", DbType="Money", CanBeNull=true)]
			public decimal? TotalPurchaseYTD
			{
				get
				{
					return this._TotalPurchaseYTD;
				}
				set
				{
					if (this._TotalPurchaseYTD != value)
					{
						this.OnTotalPurchaseYTDChanging(value);
						this.SendPropertyChanging();
						this._TotalPurchaseYTD = value;
						this.SendPropertyChanged("TotalPurchaseYTD");
						this.OnTotalPurchaseYTDChanged();
					}
					this.SendPropertySetterInvoked("TotalPurchaseYTD", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime
			/// </summary>
			[ColumnAttribute(Storage="_DateFirstPurchase", DbType="DateTime", CanBeNull=true)]
			public DateTime? DateFirstPurchase
			{
				get
				{
					return this._DateFirstPurchase;
				}
				set
				{
					if (this._DateFirstPurchase != value)
					{
						this.OnDateFirstPurchaseChanging(value);
						this.SendPropertyChanging();
						this._DateFirstPurchase = value;
						this.SendPropertyChanged("DateFirstPurchase");
						this.OnDateFirstPurchaseChanged();
					}
					this.SendPropertySetterInvoked("DateFirstPurchase", value);
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
			/// Column DbType=NVarChar(1)
			/// </summary>
			[ColumnAttribute(Storage="_MaritalStatus", DbType="NVarChar(1)", CanBeNull=true)]
			public string MaritalStatus
			{
				get
				{
					return this._MaritalStatus;
				}
				set
				{
					if (this._MaritalStatus != value)
					{
						this.OnMaritalStatusChanging(value);
						this.SendPropertyChanging();
						this._MaritalStatus = value;
						this.SendPropertyChanged("MaritalStatus");
						this.OnMaritalStatusChanged();
					}
					this.SendPropertySetterInvoked("MaritalStatus", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(30)
			/// </summary>
			[ColumnAttribute(Storage="_YearlyIncome", DbType="NVarChar(30)", CanBeNull=true)]
			public string YearlyIncome
			{
				get
				{
					return this._YearlyIncome;
				}
				set
				{
					if (this._YearlyIncome != value)
					{
						this.OnYearlyIncomeChanging(value);
						this.SendPropertyChanging();
						this._YearlyIncome = value;
						this.SendPropertyChanged("YearlyIncome");
						this.OnYearlyIncomeChanged();
					}
					this.SendPropertySetterInvoked("YearlyIncome", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(1)
			/// </summary>
			[ColumnAttribute(Storage="_Gender", DbType="NVarChar(1)", CanBeNull=true)]
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
			/// Column DbType=Int
			/// </summary>
			[ColumnAttribute(Storage="_TotalChildren", DbType="Int", CanBeNull=true)]
			public int? TotalChildren
			{
				get
				{
					return this._TotalChildren;
				}
				set
				{
					if (this._TotalChildren != value)
					{
						this.OnTotalChildrenChanging(value);
						this.SendPropertyChanging();
						this._TotalChildren = value;
						this.SendPropertyChanged("TotalChildren");
						this.OnTotalChildrenChanged();
					}
					this.SendPropertySetterInvoked("TotalChildren", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int
			/// </summary>
			[ColumnAttribute(Storage="_NumberChildrenAtHome", DbType="Int", CanBeNull=true)]
			public int? NumberChildrenAtHome
			{
				get
				{
					return this._NumberChildrenAtHome;
				}
				set
				{
					if (this._NumberChildrenAtHome != value)
					{
						this.OnNumberChildrenAtHomeChanging(value);
						this.SendPropertyChanging();
						this._NumberChildrenAtHome = value;
						this.SendPropertyChanged("NumberChildrenAtHome");
						this.OnNumberChildrenAtHomeChanged();
					}
					this.SendPropertySetterInvoked("NumberChildrenAtHome", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(30)
			/// </summary>
			[ColumnAttribute(Storage="_Education", DbType="NVarChar(30)", CanBeNull=true)]
			public string Education
			{
				get
				{
					return this._Education;
				}
				set
				{
					if (this._Education != value)
					{
						this.OnEducationChanging(value);
						this.SendPropertyChanging();
						this._Education = value;
						this.SendPropertyChanged("Education");
						this.OnEducationChanged();
					}
					this.SendPropertySetterInvoked("Education", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(30)
			/// </summary>
			[ColumnAttribute(Storage="_Occupation", DbType="NVarChar(30)", CanBeNull=true)]
			public string Occupation
			{
				get
				{
					return this._Occupation;
				}
				set
				{
					if (this._Occupation != value)
					{
						this.OnOccupationChanging(value);
						this.SendPropertyChanging();
						this._Occupation = value;
						this.SendPropertyChanged("Occupation");
						this.OnOccupationChanged();
					}
					this.SendPropertySetterInvoked("Occupation", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Bit
			/// </summary>
			[ColumnAttribute(Storage="_HomeOwnerFlag", DbType="Bit", CanBeNull=true)]
			public bool? HomeOwnerFlag
			{
				get
				{
					return this._HomeOwnerFlag;
				}
				set
				{
					if (this._HomeOwnerFlag != value)
					{
						this.OnHomeOwnerFlagChanging(value);
						this.SendPropertyChanging();
						this._HomeOwnerFlag = value;
						this.SendPropertyChanged("HomeOwnerFlag");
						this.OnHomeOwnerFlagChanged();
					}
					this.SendPropertySetterInvoked("HomeOwnerFlag", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int
			/// </summary>
			[ColumnAttribute(Storage="_NumberCarsOwned", DbType="Int", CanBeNull=true)]
			public int? NumberCarsOwned
			{
				get
				{
					return this._NumberCarsOwned;
				}
				set
				{
					if (this._NumberCarsOwned != value)
					{
						this.OnNumberCarsOwnedChanging(value);
						this.SendPropertyChanging();
						this._NumberCarsOwned = value;
						this.SendPropertyChanged("NumberCarsOwned");
						this.OnNumberCarsOwnedChanged();
					}
					this.SendPropertySetterInvoked("NumberCarsOwned", value);
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
		#endregion Sales.vIndividualDemographics

		#region HumanResources.vJobCandidate
		[TableAttribute(Name="HumanResources.vJobCandidate")]
		public partial class HumanResources_vJobCandidate : EntityBase<HumanResources_vJobCandidate, AdventureWorksDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private int _JobCandidateID;
			private int? _EmployeeID;
			private string _Name_Prefix;
			private string _Name_First;
			private string _Name_Middle;
			private string _Name_Last;
			private string _Name_Suffix;
			private string _Skills;
			private string _Addr_Type;
			private string _Addr_Loc_CountryRegion;
			private string _Addr_Loc_State;
			private string _Addr_Loc_City;
			private string _Addr_PostalCode;
			private string _EMail;
			private string _WebSite;
			private DateTime _ModifiedDate;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnJobCandidateIDChanging(int value);
			partial void OnJobCandidateIDChanged();
			partial void OnEmployeeIDChanging(int? value);
			partial void OnEmployeeIDChanged();
			partial void OnName_PrefixChanging(string value);
			partial void OnName_PrefixChanged();
			partial void OnName_FirstChanging(string value);
			partial void OnName_FirstChanged();
			partial void OnName_MiddleChanging(string value);
			partial void OnName_MiddleChanged();
			partial void OnName_LastChanging(string value);
			partial void OnName_LastChanged();
			partial void OnName_SuffixChanging(string value);
			partial void OnName_SuffixChanged();
			partial void OnSkillsChanging(string value);
			partial void OnSkillsChanged();
			partial void OnAddr_TypeChanging(string value);
			partial void OnAddr_TypeChanged();
			partial void OnAddr_Loc_CountryRegionChanging(string value);
			partial void OnAddr_Loc_CountryRegionChanged();
			partial void OnAddr_Loc_StateChanging(string value);
			partial void OnAddr_Loc_StateChanged();
			partial void OnAddr_Loc_CityChanging(string value);
			partial void OnAddr_Loc_CityChanged();
			partial void OnAddr_PostalCodeChanging(string value);
			partial void OnAddr_PostalCodeChanged();
			partial void OnEMailChanging(string value);
			partial void OnEMailChanged();
			partial void OnWebSiteChanging(string value);
			partial void OnWebSiteChanged();
			partial void OnModifiedDateChanging(DateTime value);
			partial void OnModifiedDateChanged();
			#endregion

			public HumanResources_vJobCandidate()
			{
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=Int NOT NULL IDENTITY
			/// </summary>
			[ColumnAttribute(Storage="_JobCandidateID", DbType="Int NOT NULL IDENTITY", CanBeNull=false)]
			public int JobCandidateID
			{
				get
				{
					return this._JobCandidateID;
				}
				set
				{
					if (this._JobCandidateID != value)
					{
						this.OnJobCandidateIDChanging(value);
						this.SendPropertyChanging();
						this._JobCandidateID = value;
						this.SendPropertyChanged("JobCandidateID");
						this.OnJobCandidateIDChanged();
					}
					this.SendPropertySetterInvoked("JobCandidateID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int
			/// </summary>
			[ColumnAttribute(Storage="_EmployeeID", DbType="Int", CanBeNull=true)]
			public int? EmployeeID
			{
				get
				{
					return this._EmployeeID;
				}
				set
				{
					if (this._EmployeeID != value)
					{
						this.OnEmployeeIDChanging(value);
						this.SendPropertyChanging();
						this._EmployeeID = value;
						this.SendPropertyChanged("EmployeeID");
						this.OnEmployeeIDChanged();
					}
					this.SendPropertySetterInvoked("EmployeeID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(30)
			/// </summary>
			[ColumnAttribute(Storage="_Name_Prefix", DbType="NVarChar(30)", CanBeNull=true)]
			public string Name_Prefix
			{
				get
				{
					return this._Name_Prefix;
				}
				set
				{
					if (this._Name_Prefix != value)
					{
						this.OnName_PrefixChanging(value);
						this.SendPropertyChanging();
						this._Name_Prefix = value;
						this.SendPropertyChanged("Name_Prefix");
						this.OnName_PrefixChanged();
					}
					this.SendPropertySetterInvoked("Name_Prefix", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(30)
			/// </summary>
			[ColumnAttribute(Storage="_Name_First", DbType="NVarChar(30)", CanBeNull=true)]
			public string Name_First
			{
				get
				{
					return this._Name_First;
				}
				set
				{
					if (this._Name_First != value)
					{
						this.OnName_FirstChanging(value);
						this.SendPropertyChanging();
						this._Name_First = value;
						this.SendPropertyChanged("Name_First");
						this.OnName_FirstChanged();
					}
					this.SendPropertySetterInvoked("Name_First", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(30)
			/// </summary>
			[ColumnAttribute(Storage="_Name_Middle", DbType="NVarChar(30)", CanBeNull=true)]
			public string Name_Middle
			{
				get
				{
					return this._Name_Middle;
				}
				set
				{
					if (this._Name_Middle != value)
					{
						this.OnName_MiddleChanging(value);
						this.SendPropertyChanging();
						this._Name_Middle = value;
						this.SendPropertyChanged("Name_Middle");
						this.OnName_MiddleChanged();
					}
					this.SendPropertySetterInvoked("Name_Middle", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(30)
			/// </summary>
			[ColumnAttribute(Storage="_Name_Last", DbType="NVarChar(30)", CanBeNull=true)]
			public string Name_Last
			{
				get
				{
					return this._Name_Last;
				}
				set
				{
					if (this._Name_Last != value)
					{
						this.OnName_LastChanging(value);
						this.SendPropertyChanging();
						this._Name_Last = value;
						this.SendPropertyChanged("Name_Last");
						this.OnName_LastChanged();
					}
					this.SendPropertySetterInvoked("Name_Last", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(30)
			/// </summary>
			[ColumnAttribute(Storage="_Name_Suffix", DbType="NVarChar(30)", CanBeNull=true)]
			public string Name_Suffix
			{
				get
				{
					return this._Name_Suffix;
				}
				set
				{
					if (this._Name_Suffix != value)
					{
						this.OnName_SuffixChanging(value);
						this.SendPropertyChanging();
						this._Name_Suffix = value;
						this.SendPropertyChanged("Name_Suffix");
						this.OnName_SuffixChanged();
					}
					this.SendPropertySetterInvoked("Name_Suffix", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(MAX)
			/// </summary>
			[ColumnAttribute(Storage="_Skills", DbType="NVarChar(MAX)", CanBeNull=true)]
			public string Skills
			{
				get
				{
					return this._Skills;
				}
				set
				{
					if (this._Skills != value)
					{
						this.OnSkillsChanging(value);
						this.SendPropertyChanging();
						this._Skills = value;
						this.SendPropertyChanged("Skills");
						this.OnSkillsChanged();
					}
					this.SendPropertySetterInvoked("Skills", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(30)
			/// </summary>
			[ColumnAttribute(Storage="_Addr_Type", DbType="NVarChar(30)", CanBeNull=true)]
			public string Addr_Type
			{
				get
				{
					return this._Addr_Type;
				}
				set
				{
					if (this._Addr_Type != value)
					{
						this.OnAddr_TypeChanging(value);
						this.SendPropertyChanging();
						this._Addr_Type = value;
						this.SendPropertyChanged("Addr_Type");
						this.OnAddr_TypeChanged();
					}
					this.SendPropertySetterInvoked("Addr_Type", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(100)
			/// </summary>
			[ColumnAttribute(Storage="_Addr_Loc_CountryRegion", DbType="NVarChar(100)", CanBeNull=true)]
			public string Addr_Loc_CountryRegion
			{
				get
				{
					return this._Addr_Loc_CountryRegion;
				}
				set
				{
					if (this._Addr_Loc_CountryRegion != value)
					{
						this.OnAddr_Loc_CountryRegionChanging(value);
						this.SendPropertyChanging();
						this._Addr_Loc_CountryRegion = value;
						this.SendPropertyChanged("Addr_Loc_CountryRegion");
						this.OnAddr_Loc_CountryRegionChanged();
					}
					this.SendPropertySetterInvoked("Addr_Loc_CountryRegion", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(100)
			/// </summary>
			[ColumnAttribute(Storage="_Addr_Loc_State", DbType="NVarChar(100)", CanBeNull=true)]
			public string Addr_Loc_State
			{
				get
				{
					return this._Addr_Loc_State;
				}
				set
				{
					if (this._Addr_Loc_State != value)
					{
						this.OnAddr_Loc_StateChanging(value);
						this.SendPropertyChanging();
						this._Addr_Loc_State = value;
						this.SendPropertyChanged("Addr_Loc_State");
						this.OnAddr_Loc_StateChanged();
					}
					this.SendPropertySetterInvoked("Addr_Loc_State", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(100)
			/// </summary>
			[ColumnAttribute(Storage="_Addr_Loc_City", DbType="NVarChar(100)", CanBeNull=true)]
			public string Addr_Loc_City
			{
				get
				{
					return this._Addr_Loc_City;
				}
				set
				{
					if (this._Addr_Loc_City != value)
					{
						this.OnAddr_Loc_CityChanging(value);
						this.SendPropertyChanging();
						this._Addr_Loc_City = value;
						this.SendPropertyChanged("Addr_Loc_City");
						this.OnAddr_Loc_CityChanged();
					}
					this.SendPropertySetterInvoked("Addr_Loc_City", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(20)
			/// </summary>
			[ColumnAttribute(Storage="_Addr_PostalCode", DbType="NVarChar(20)", CanBeNull=true)]
			public string Addr_PostalCode
			{
				get
				{
					return this._Addr_PostalCode;
				}
				set
				{
					if (this._Addr_PostalCode != value)
					{
						this.OnAddr_PostalCodeChanging(value);
						this.SendPropertyChanging();
						this._Addr_PostalCode = value;
						this.SendPropertyChanged("Addr_PostalCode");
						this.OnAddr_PostalCodeChanged();
					}
					this.SendPropertySetterInvoked("Addr_PostalCode", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(MAX)
			/// </summary>
			[ColumnAttribute(Storage="_EMail", DbType="NVarChar(MAX)", CanBeNull=true)]
			public string EMail
			{
				get
				{
					return this._EMail;
				}
				set
				{
					if (this._EMail != value)
					{
						this.OnEMailChanging(value);
						this.SendPropertyChanging();
						this._EMail = value;
						this.SendPropertyChanged("EMail");
						this.OnEMailChanged();
					}
					this.SendPropertySetterInvoked("EMail", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(MAX)
			/// </summary>
			[ColumnAttribute(Storage="_WebSite", DbType="NVarChar(MAX)", CanBeNull=true)]
			public string WebSite
			{
				get
				{
					return this._WebSite;
				}
				set
				{
					if (this._WebSite != value)
					{
						this.OnWebSiteChanging(value);
						this.SendPropertyChanging();
						this._WebSite = value;
						this.SendPropertyChanged("WebSite");
						this.OnWebSiteChanged();
					}
					this.SendPropertySetterInvoked("WebSite", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ModifiedDate", DbType="DateTime NOT NULL", CanBeNull=false)]
			public DateTime ModifiedDate
			{
				get
				{
					return this._ModifiedDate;
				}
				set
				{
					if (this._ModifiedDate != value)
					{
						this.OnModifiedDateChanging(value);
						this.SendPropertyChanging();
						this._ModifiedDate = value;
						this.SendPropertyChanged("ModifiedDate");
						this.OnModifiedDateChanged();
					}
					this.SendPropertySetterInvoked("ModifiedDate", value);
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
		#endregion HumanResources.vJobCandidate

		#region HumanResources.vJobCandidateEducation
		[TableAttribute(Name="HumanResources.vJobCandidateEducation")]
		public partial class HumanResources_vJobCandidateEducation : EntityBase<HumanResources_vJobCandidateEducation, AdventureWorksDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private int _JobCandidateID;
			private string _Edu_Level;
			private DateTime? _Edu_StartDate;
			private DateTime? _Edu_EndDate;
			private string _Edu_Degree;
			private string _Edu_Major;
			private string _Edu_Minor;
			private string _Edu_GPA;
			private string _Edu_GPAScale;
			private string _Edu_School;
			private string _Edu_Loc_CountryRegion;
			private string _Edu_Loc_State;
			private string _Edu_Loc_City;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnJobCandidateIDChanging(int value);
			partial void OnJobCandidateIDChanged();
			partial void OnEdu_LevelChanging(string value);
			partial void OnEdu_LevelChanged();
			partial void OnEdu_StartDateChanging(DateTime? value);
			partial void OnEdu_StartDateChanged();
			partial void OnEdu_EndDateChanging(DateTime? value);
			partial void OnEdu_EndDateChanged();
			partial void OnEdu_DegreeChanging(string value);
			partial void OnEdu_DegreeChanged();
			partial void OnEdu_MajorChanging(string value);
			partial void OnEdu_MajorChanged();
			partial void OnEdu_MinorChanging(string value);
			partial void OnEdu_MinorChanged();
			partial void OnEdu_GPAChanging(string value);
			partial void OnEdu_GPAChanged();
			partial void OnEdu_GPAScaleChanging(string value);
			partial void OnEdu_GPAScaleChanged();
			partial void OnEdu_SchoolChanging(string value);
			partial void OnEdu_SchoolChanged();
			partial void OnEdu_Loc_CountryRegionChanging(string value);
			partial void OnEdu_Loc_CountryRegionChanged();
			partial void OnEdu_Loc_StateChanging(string value);
			partial void OnEdu_Loc_StateChanged();
			partial void OnEdu_Loc_CityChanging(string value);
			partial void OnEdu_Loc_CityChanged();
			#endregion

			public HumanResources_vJobCandidateEducation()
			{
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=Int NOT NULL IDENTITY
			/// </summary>
			[ColumnAttribute(Storage="_JobCandidateID", DbType="Int NOT NULL IDENTITY", CanBeNull=false)]
			public int JobCandidateID
			{
				get
				{
					return this._JobCandidateID;
				}
				set
				{
					if (this._JobCandidateID != value)
					{
						this.OnJobCandidateIDChanging(value);
						this.SendPropertyChanging();
						this._JobCandidateID = value;
						this.SendPropertyChanged("JobCandidateID");
						this.OnJobCandidateIDChanged();
					}
					this.SendPropertySetterInvoked("JobCandidateID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(MAX)
			/// </summary>
			[ColumnAttribute(Storage="_Edu_Level", DbType="NVarChar(MAX)", CanBeNull=true)]
			public string Edu_Level
			{
				get
				{
					return this._Edu_Level;
				}
				set
				{
					if (this._Edu_Level != value)
					{
						this.OnEdu_LevelChanging(value);
						this.SendPropertyChanging();
						this._Edu_Level = value;
						this.SendPropertyChanged("Edu_Level");
						this.OnEdu_LevelChanged();
					}
					this.SendPropertySetterInvoked("Edu_Level", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime
			/// </summary>
			[ColumnAttribute(Storage="_Edu_StartDate", DbType="DateTime", CanBeNull=true)]
			public DateTime? Edu_StartDate
			{
				get
				{
					return this._Edu_StartDate;
				}
				set
				{
					if (this._Edu_StartDate != value)
					{
						this.OnEdu_StartDateChanging(value);
						this.SendPropertyChanging();
						this._Edu_StartDate = value;
						this.SendPropertyChanged("Edu_StartDate");
						this.OnEdu_StartDateChanged();
					}
					this.SendPropertySetterInvoked("Edu_StartDate", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime
			/// </summary>
			[ColumnAttribute(Storage="_Edu_EndDate", DbType="DateTime", CanBeNull=true)]
			public DateTime? Edu_EndDate
			{
				get
				{
					return this._Edu_EndDate;
				}
				set
				{
					if (this._Edu_EndDate != value)
					{
						this.OnEdu_EndDateChanging(value);
						this.SendPropertyChanging();
						this._Edu_EndDate = value;
						this.SendPropertyChanged("Edu_EndDate");
						this.OnEdu_EndDateChanged();
					}
					this.SendPropertySetterInvoked("Edu_EndDate", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(50)
			/// </summary>
			[ColumnAttribute(Storage="_Edu_Degree", DbType="NVarChar(50)", CanBeNull=true)]
			public string Edu_Degree
			{
				get
				{
					return this._Edu_Degree;
				}
				set
				{
					if (this._Edu_Degree != value)
					{
						this.OnEdu_DegreeChanging(value);
						this.SendPropertyChanging();
						this._Edu_Degree = value;
						this.SendPropertyChanged("Edu_Degree");
						this.OnEdu_DegreeChanged();
					}
					this.SendPropertySetterInvoked("Edu_Degree", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(50)
			/// </summary>
			[ColumnAttribute(Storage="_Edu_Major", DbType="NVarChar(50)", CanBeNull=true)]
			public string Edu_Major
			{
				get
				{
					return this._Edu_Major;
				}
				set
				{
					if (this._Edu_Major != value)
					{
						this.OnEdu_MajorChanging(value);
						this.SendPropertyChanging();
						this._Edu_Major = value;
						this.SendPropertyChanged("Edu_Major");
						this.OnEdu_MajorChanged();
					}
					this.SendPropertySetterInvoked("Edu_Major", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(50)
			/// </summary>
			[ColumnAttribute(Storage="_Edu_Minor", DbType="NVarChar(50)", CanBeNull=true)]
			public string Edu_Minor
			{
				get
				{
					return this._Edu_Minor;
				}
				set
				{
					if (this._Edu_Minor != value)
					{
						this.OnEdu_MinorChanging(value);
						this.SendPropertyChanging();
						this._Edu_Minor = value;
						this.SendPropertyChanged("Edu_Minor");
						this.OnEdu_MinorChanged();
					}
					this.SendPropertySetterInvoked("Edu_Minor", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(5)
			/// </summary>
			[ColumnAttribute(Storage="_Edu_GPA", DbType="NVarChar(5)", CanBeNull=true)]
			public string Edu_GPA
			{
				get
				{
					return this._Edu_GPA;
				}
				set
				{
					if (this._Edu_GPA != value)
					{
						this.OnEdu_GPAChanging(value);
						this.SendPropertyChanging();
						this._Edu_GPA = value;
						this.SendPropertyChanged("Edu_GPA");
						this.OnEdu_GPAChanged();
					}
					this.SendPropertySetterInvoked("Edu_GPA", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(5)
			/// </summary>
			[ColumnAttribute(Storage="_Edu_GPAScale", DbType="NVarChar(5)", CanBeNull=true)]
			public string Edu_GPAScale
			{
				get
				{
					return this._Edu_GPAScale;
				}
				set
				{
					if (this._Edu_GPAScale != value)
					{
						this.OnEdu_GPAScaleChanging(value);
						this.SendPropertyChanging();
						this._Edu_GPAScale = value;
						this.SendPropertyChanged("Edu_GPAScale");
						this.OnEdu_GPAScaleChanged();
					}
					this.SendPropertySetterInvoked("Edu_GPAScale", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(100)
			/// </summary>
			[ColumnAttribute(Storage="_Edu_School", DbType="NVarChar(100)", CanBeNull=true)]
			public string Edu_School
			{
				get
				{
					return this._Edu_School;
				}
				set
				{
					if (this._Edu_School != value)
					{
						this.OnEdu_SchoolChanging(value);
						this.SendPropertyChanging();
						this._Edu_School = value;
						this.SendPropertyChanged("Edu_School");
						this.OnEdu_SchoolChanged();
					}
					this.SendPropertySetterInvoked("Edu_School", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(100)
			/// </summary>
			[ColumnAttribute(Storage="_Edu_Loc_CountryRegion", DbType="NVarChar(100)", CanBeNull=true)]
			public string Edu_Loc_CountryRegion
			{
				get
				{
					return this._Edu_Loc_CountryRegion;
				}
				set
				{
					if (this._Edu_Loc_CountryRegion != value)
					{
						this.OnEdu_Loc_CountryRegionChanging(value);
						this.SendPropertyChanging();
						this._Edu_Loc_CountryRegion = value;
						this.SendPropertyChanged("Edu_Loc_CountryRegion");
						this.OnEdu_Loc_CountryRegionChanged();
					}
					this.SendPropertySetterInvoked("Edu_Loc_CountryRegion", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(100)
			/// </summary>
			[ColumnAttribute(Storage="_Edu_Loc_State", DbType="NVarChar(100)", CanBeNull=true)]
			public string Edu_Loc_State
			{
				get
				{
					return this._Edu_Loc_State;
				}
				set
				{
					if (this._Edu_Loc_State != value)
					{
						this.OnEdu_Loc_StateChanging(value);
						this.SendPropertyChanging();
						this._Edu_Loc_State = value;
						this.SendPropertyChanged("Edu_Loc_State");
						this.OnEdu_Loc_StateChanged();
					}
					this.SendPropertySetterInvoked("Edu_Loc_State", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(100)
			/// </summary>
			[ColumnAttribute(Storage="_Edu_Loc_City", DbType="NVarChar(100)", CanBeNull=true)]
			public string Edu_Loc_City
			{
				get
				{
					return this._Edu_Loc_City;
				}
				set
				{
					if (this._Edu_Loc_City != value)
					{
						this.OnEdu_Loc_CityChanging(value);
						this.SendPropertyChanging();
						this._Edu_Loc_City = value;
						this.SendPropertyChanged("Edu_Loc_City");
						this.OnEdu_Loc_CityChanged();
					}
					this.SendPropertySetterInvoked("Edu_Loc_City", value);
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
		#endregion HumanResources.vJobCandidateEducation

		#region HumanResources.vJobCandidateEmployment
		[TableAttribute(Name="HumanResources.vJobCandidateEmployment")]
		public partial class HumanResources_vJobCandidateEmployment : EntityBase<HumanResources_vJobCandidateEmployment, AdventureWorksDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private int _JobCandidateID;
			private DateTime? _Emp_StartDate;
			private DateTime? _Emp_EndDate;
			private string _Emp_OrgName;
			private string _Emp_JobTitle;
			private string _Emp_Responsibility;
			private string _Emp_FunctionCategory;
			private string _Emp_IndustryCategory;
			private string _Emp_Loc_CountryRegion;
			private string _Emp_Loc_State;
			private string _Emp_Loc_City;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnJobCandidateIDChanging(int value);
			partial void OnJobCandidateIDChanged();
			partial void OnEmp_StartDateChanging(DateTime? value);
			partial void OnEmp_StartDateChanged();
			partial void OnEmp_EndDateChanging(DateTime? value);
			partial void OnEmp_EndDateChanged();
			partial void OnEmp_OrgNameChanging(string value);
			partial void OnEmp_OrgNameChanged();
			partial void OnEmp_JobTitleChanging(string value);
			partial void OnEmp_JobTitleChanged();
			partial void OnEmp_ResponsibilityChanging(string value);
			partial void OnEmp_ResponsibilityChanged();
			partial void OnEmp_FunctionCategoryChanging(string value);
			partial void OnEmp_FunctionCategoryChanged();
			partial void OnEmp_IndustryCategoryChanging(string value);
			partial void OnEmp_IndustryCategoryChanged();
			partial void OnEmp_Loc_CountryRegionChanging(string value);
			partial void OnEmp_Loc_CountryRegionChanged();
			partial void OnEmp_Loc_StateChanging(string value);
			partial void OnEmp_Loc_StateChanged();
			partial void OnEmp_Loc_CityChanging(string value);
			partial void OnEmp_Loc_CityChanged();
			#endregion

			public HumanResources_vJobCandidateEmployment()
			{
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=Int NOT NULL IDENTITY
			/// </summary>
			[ColumnAttribute(Storage="_JobCandidateID", DbType="Int NOT NULL IDENTITY", CanBeNull=false)]
			public int JobCandidateID
			{
				get
				{
					return this._JobCandidateID;
				}
				set
				{
					if (this._JobCandidateID != value)
					{
						this.OnJobCandidateIDChanging(value);
						this.SendPropertyChanging();
						this._JobCandidateID = value;
						this.SendPropertyChanged("JobCandidateID");
						this.OnJobCandidateIDChanged();
					}
					this.SendPropertySetterInvoked("JobCandidateID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime
			/// </summary>
			[ColumnAttribute(Storage="_Emp_StartDate", DbType="DateTime", CanBeNull=true)]
			public DateTime? Emp_StartDate
			{
				get
				{
					return this._Emp_StartDate;
				}
				set
				{
					if (this._Emp_StartDate != value)
					{
						this.OnEmp_StartDateChanging(value);
						this.SendPropertyChanging();
						this._Emp_StartDate = value;
						this.SendPropertyChanged("Emp_StartDate");
						this.OnEmp_StartDateChanged();
					}
					this.SendPropertySetterInvoked("Emp_StartDate", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime
			/// </summary>
			[ColumnAttribute(Storage="_Emp_EndDate", DbType="DateTime", CanBeNull=true)]
			public DateTime? Emp_EndDate
			{
				get
				{
					return this._Emp_EndDate;
				}
				set
				{
					if (this._Emp_EndDate != value)
					{
						this.OnEmp_EndDateChanging(value);
						this.SendPropertyChanging();
						this._Emp_EndDate = value;
						this.SendPropertyChanged("Emp_EndDate");
						this.OnEmp_EndDateChanged();
					}
					this.SendPropertySetterInvoked("Emp_EndDate", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(100)
			/// </summary>
			[ColumnAttribute(Storage="_Emp_OrgName", DbType="NVarChar(100)", CanBeNull=true)]
			public string Emp_OrgName
			{
				get
				{
					return this._Emp_OrgName;
				}
				set
				{
					if (this._Emp_OrgName != value)
					{
						this.OnEmp_OrgNameChanging(value);
						this.SendPropertyChanging();
						this._Emp_OrgName = value;
						this.SendPropertyChanged("Emp_OrgName");
						this.OnEmp_OrgNameChanged();
					}
					this.SendPropertySetterInvoked("Emp_OrgName", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(100)
			/// </summary>
			[ColumnAttribute(Storage="_Emp_JobTitle", DbType="NVarChar(100)", CanBeNull=true)]
			public string Emp_JobTitle
			{
				get
				{
					return this._Emp_JobTitle;
				}
				set
				{
					if (this._Emp_JobTitle != value)
					{
						this.OnEmp_JobTitleChanging(value);
						this.SendPropertyChanging();
						this._Emp_JobTitle = value;
						this.SendPropertyChanged("Emp_JobTitle");
						this.OnEmp_JobTitleChanged();
					}
					this.SendPropertySetterInvoked("Emp_JobTitle", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(MAX)
			/// </summary>
			[ColumnAttribute(Storage="_Emp_Responsibility", DbType="NVarChar(MAX)", CanBeNull=true)]
			public string Emp_Responsibility
			{
				get
				{
					return this._Emp_Responsibility;
				}
				set
				{
					if (this._Emp_Responsibility != value)
					{
						this.OnEmp_ResponsibilityChanging(value);
						this.SendPropertyChanging();
						this._Emp_Responsibility = value;
						this.SendPropertyChanged("Emp_Responsibility");
						this.OnEmp_ResponsibilityChanged();
					}
					this.SendPropertySetterInvoked("Emp_Responsibility", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(MAX)
			/// </summary>
			[ColumnAttribute(Storage="_Emp_FunctionCategory", DbType="NVarChar(MAX)", CanBeNull=true)]
			public string Emp_FunctionCategory
			{
				get
				{
					return this._Emp_FunctionCategory;
				}
				set
				{
					if (this._Emp_FunctionCategory != value)
					{
						this.OnEmp_FunctionCategoryChanging(value);
						this.SendPropertyChanging();
						this._Emp_FunctionCategory = value;
						this.SendPropertyChanged("Emp_FunctionCategory");
						this.OnEmp_FunctionCategoryChanged();
					}
					this.SendPropertySetterInvoked("Emp_FunctionCategory", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(MAX)
			/// </summary>
			[ColumnAttribute(Storage="_Emp_IndustryCategory", DbType="NVarChar(MAX)", CanBeNull=true)]
			public string Emp_IndustryCategory
			{
				get
				{
					return this._Emp_IndustryCategory;
				}
				set
				{
					if (this._Emp_IndustryCategory != value)
					{
						this.OnEmp_IndustryCategoryChanging(value);
						this.SendPropertyChanging();
						this._Emp_IndustryCategory = value;
						this.SendPropertyChanged("Emp_IndustryCategory");
						this.OnEmp_IndustryCategoryChanged();
					}
					this.SendPropertySetterInvoked("Emp_IndustryCategory", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(MAX)
			/// </summary>
			[ColumnAttribute(Storage="_Emp_Loc_CountryRegion", DbType="NVarChar(MAX)", CanBeNull=true)]
			public string Emp_Loc_CountryRegion
			{
				get
				{
					return this._Emp_Loc_CountryRegion;
				}
				set
				{
					if (this._Emp_Loc_CountryRegion != value)
					{
						this.OnEmp_Loc_CountryRegionChanging(value);
						this.SendPropertyChanging();
						this._Emp_Loc_CountryRegion = value;
						this.SendPropertyChanged("Emp_Loc_CountryRegion");
						this.OnEmp_Loc_CountryRegionChanged();
					}
					this.SendPropertySetterInvoked("Emp_Loc_CountryRegion", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(MAX)
			/// </summary>
			[ColumnAttribute(Storage="_Emp_Loc_State", DbType="NVarChar(MAX)", CanBeNull=true)]
			public string Emp_Loc_State
			{
				get
				{
					return this._Emp_Loc_State;
				}
				set
				{
					if (this._Emp_Loc_State != value)
					{
						this.OnEmp_Loc_StateChanging(value);
						this.SendPropertyChanging();
						this._Emp_Loc_State = value;
						this.SendPropertyChanged("Emp_Loc_State");
						this.OnEmp_Loc_StateChanged();
					}
					this.SendPropertySetterInvoked("Emp_Loc_State", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(MAX)
			/// </summary>
			[ColumnAttribute(Storage="_Emp_Loc_City", DbType="NVarChar(MAX)", CanBeNull=true)]
			public string Emp_Loc_City
			{
				get
				{
					return this._Emp_Loc_City;
				}
				set
				{
					if (this._Emp_Loc_City != value)
					{
						this.OnEmp_Loc_CityChanging(value);
						this.SendPropertyChanging();
						this._Emp_Loc_City = value;
						this.SendPropertyChanged("Emp_Loc_City");
						this.OnEmp_Loc_CityChanged();
					}
					this.SendPropertySetterInvoked("Emp_Loc_City", value);
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
		#endregion HumanResources.vJobCandidateEmployment

		#region Production.vProductAndDescription
		[TableAttribute(Name="Production.vProductAndDescription")]
		public partial class Production_vProductAndDescription : EntityBase<Production_vProductAndDescription, AdventureWorksDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private int _ProductID;
			private string _Name;
			private string _ProductModel;
			private string _CultureID;
			private string _Description;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnProductIDChanging(int value);
			partial void OnProductIDChanged();
			partial void OnNameChanging(string value);
			partial void OnNameChanged();
			partial void OnProductModelChanging(string value);
			partial void OnProductModelChanged();
			partial void OnCultureIDChanging(string value);
			partial void OnCultureIDChanged();
			partial void OnDescriptionChanging(string value);
			partial void OnDescriptionChanged();
			#endregion

			public Production_vProductAndDescription()
			{
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ProductID", DbType="Int NOT NULL", CanBeNull=false)]
			public int ProductID
			{
				get
				{
					return this._ProductID;
				}
				set
				{
					if (this._ProductID != value)
					{
						this.OnProductIDChanging(value);
						this.SendPropertyChanging();
						this._ProductID = value;
						this.SendPropertyChanged("ProductID");
						this.OnProductIDChanged();
					}
					this.SendPropertySetterInvoked("ProductID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(50) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_Name", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
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
			/// Column DbType=NVarChar(50) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ProductModel", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
			public string ProductModel
			{
				get
				{
					return this._ProductModel;
				}
				set
				{
					if (this._ProductModel != value)
					{
						this.OnProductModelChanging(value);
						this.SendPropertyChanging();
						this._ProductModel = value;
						this.SendPropertyChanged("ProductModel");
						this.OnProductModelChanged();
					}
					this.SendPropertySetterInvoked("ProductModel", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NChar(6) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_CultureID", DbType="NChar(6) NOT NULL", CanBeNull=false)]
			public string CultureID
			{
				get
				{
					return this._CultureID;
				}
				set
				{
					if (this._CultureID != value)
					{
						this.OnCultureIDChanging(value);
						this.SendPropertyChanging();
						this._CultureID = value;
						this.SendPropertyChanged("CultureID");
						this.OnCultureIDChanged();
					}
					this.SendPropertySetterInvoked("CultureID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(400) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_Description", DbType="NVarChar(400) NOT NULL", CanBeNull=false)]
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
		#endregion Production.vProductAndDescription

		#region Production.vProductModelCatalogDescription
		[TableAttribute(Name="Production.vProductModelCatalogDescription")]
		public partial class Production_vProductModelCatalogDescription : EntityBase<Production_vProductModelCatalogDescription, AdventureWorksDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private int _ProductModelID;
			private string _Name;
			private string _Summary;
			private string _Manufacturer;
			private string _Copyright;
			private string _ProductURL;
			private string _WarrantyPeriod;
			private string _WarrantyDescription;
			private string _NoOfYears;
			private string _MaintenanceDescription;
			private string _Wheel;
			private string _Saddle;
			private string _Pedal;
			private string _BikeFrame;
			private string _Crankset;
			private string _PictureAngle;
			private string _PictureSize;
			private string _ProductPhotoID;
			private string _Material;
			private string _Color;
			private string _ProductLine;
			private string _Style;
			private string _RiderExperience;
			private System.Guid _rowguid;
			private DateTime _ModifiedDate;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnProductModelIDChanging(int value);
			partial void OnProductModelIDChanged();
			partial void OnNameChanging(string value);
			partial void OnNameChanged();
			partial void OnSummaryChanging(string value);
			partial void OnSummaryChanged();
			partial void OnManufacturerChanging(string value);
			partial void OnManufacturerChanged();
			partial void OnCopyrightChanging(string value);
			partial void OnCopyrightChanged();
			partial void OnProductURLChanging(string value);
			partial void OnProductURLChanged();
			partial void OnWarrantyPeriodChanging(string value);
			partial void OnWarrantyPeriodChanged();
			partial void OnWarrantyDescriptionChanging(string value);
			partial void OnWarrantyDescriptionChanged();
			partial void OnNoOfYearsChanging(string value);
			partial void OnNoOfYearsChanged();
			partial void OnMaintenanceDescriptionChanging(string value);
			partial void OnMaintenanceDescriptionChanged();
			partial void OnWheelChanging(string value);
			partial void OnWheelChanged();
			partial void OnSaddleChanging(string value);
			partial void OnSaddleChanged();
			partial void OnPedalChanging(string value);
			partial void OnPedalChanged();
			partial void OnBikeFrameChanging(string value);
			partial void OnBikeFrameChanged();
			partial void OnCranksetChanging(string value);
			partial void OnCranksetChanged();
			partial void OnPictureAngleChanging(string value);
			partial void OnPictureAngleChanged();
			partial void OnPictureSizeChanging(string value);
			partial void OnPictureSizeChanged();
			partial void OnProductPhotoIDChanging(string value);
			partial void OnProductPhotoIDChanged();
			partial void OnMaterialChanging(string value);
			partial void OnMaterialChanged();
			partial void OnColorChanging(string value);
			partial void OnColorChanged();
			partial void OnProductLineChanging(string value);
			partial void OnProductLineChanged();
			partial void OnStyleChanging(string value);
			partial void OnStyleChanged();
			partial void OnRiderExperienceChanging(string value);
			partial void OnRiderExperienceChanged();
			partial void OnrowguidChanging(System.Guid value);
			partial void OnrowguidChanged();
			partial void OnModifiedDateChanging(DateTime value);
			partial void OnModifiedDateChanged();
			#endregion

			public Production_vProductModelCatalogDescription()
			{
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=Int NOT NULL IDENTITY
			/// </summary>
			[ColumnAttribute(Storage="_ProductModelID", DbType="Int NOT NULL IDENTITY", CanBeNull=false)]
			public int ProductModelID
			{
				get
				{
					return this._ProductModelID;
				}
				set
				{
					if (this._ProductModelID != value)
					{
						this.OnProductModelIDChanging(value);
						this.SendPropertyChanging();
						this._ProductModelID = value;
						this.SendPropertyChanged("ProductModelID");
						this.OnProductModelIDChanged();
					}
					this.SendPropertySetterInvoked("ProductModelID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(50) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_Name", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
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
			/// Column DbType=NVarChar(MAX)
			/// </summary>
			[ColumnAttribute(Storage="_Summary", DbType="NVarChar(MAX)", CanBeNull=true)]
			public string Summary
			{
				get
				{
					return this._Summary;
				}
				set
				{
					if (this._Summary != value)
					{
						this.OnSummaryChanging(value);
						this.SendPropertyChanging();
						this._Summary = value;
						this.SendPropertyChanged("Summary");
						this.OnSummaryChanged();
					}
					this.SendPropertySetterInvoked("Summary", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(MAX)
			/// </summary>
			[ColumnAttribute(Storage="_Manufacturer", DbType="NVarChar(MAX)", CanBeNull=true)]
			public string Manufacturer
			{
				get
				{
					return this._Manufacturer;
				}
				set
				{
					if (this._Manufacturer != value)
					{
						this.OnManufacturerChanging(value);
						this.SendPropertyChanging();
						this._Manufacturer = value;
						this.SendPropertyChanged("Manufacturer");
						this.OnManufacturerChanged();
					}
					this.SendPropertySetterInvoked("Manufacturer", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(30)
			/// </summary>
			[ColumnAttribute(Storage="_Copyright", DbType="NVarChar(30)", CanBeNull=true)]
			public string Copyright
			{
				get
				{
					return this._Copyright;
				}
				set
				{
					if (this._Copyright != value)
					{
						this.OnCopyrightChanging(value);
						this.SendPropertyChanging();
						this._Copyright = value;
						this.SendPropertyChanged("Copyright");
						this.OnCopyrightChanged();
					}
					this.SendPropertySetterInvoked("Copyright", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(256)
			/// </summary>
			[ColumnAttribute(Storage="_ProductURL", DbType="NVarChar(256)", CanBeNull=true)]
			public string ProductURL
			{
				get
				{
					return this._ProductURL;
				}
				set
				{
					if (this._ProductURL != value)
					{
						this.OnProductURLChanging(value);
						this.SendPropertyChanging();
						this._ProductURL = value;
						this.SendPropertyChanged("ProductURL");
						this.OnProductURLChanged();
					}
					this.SendPropertySetterInvoked("ProductURL", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(256)
			/// </summary>
			[ColumnAttribute(Storage="_WarrantyPeriod", DbType="NVarChar(256)", CanBeNull=true)]
			public string WarrantyPeriod
			{
				get
				{
					return this._WarrantyPeriod;
				}
				set
				{
					if (this._WarrantyPeriod != value)
					{
						this.OnWarrantyPeriodChanging(value);
						this.SendPropertyChanging();
						this._WarrantyPeriod = value;
						this.SendPropertyChanged("WarrantyPeriod");
						this.OnWarrantyPeriodChanged();
					}
					this.SendPropertySetterInvoked("WarrantyPeriod", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(256)
			/// </summary>
			[ColumnAttribute(Storage="_WarrantyDescription", DbType="NVarChar(256)", CanBeNull=true)]
			public string WarrantyDescription
			{
				get
				{
					return this._WarrantyDescription;
				}
				set
				{
					if (this._WarrantyDescription != value)
					{
						this.OnWarrantyDescriptionChanging(value);
						this.SendPropertyChanging();
						this._WarrantyDescription = value;
						this.SendPropertyChanged("WarrantyDescription");
						this.OnWarrantyDescriptionChanged();
					}
					this.SendPropertySetterInvoked("WarrantyDescription", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(256)
			/// </summary>
			[ColumnAttribute(Storage="_NoOfYears", DbType="NVarChar(256)", CanBeNull=true)]
			public string NoOfYears
			{
				get
				{
					return this._NoOfYears;
				}
				set
				{
					if (this._NoOfYears != value)
					{
						this.OnNoOfYearsChanging(value);
						this.SendPropertyChanging();
						this._NoOfYears = value;
						this.SendPropertyChanged("NoOfYears");
						this.OnNoOfYearsChanged();
					}
					this.SendPropertySetterInvoked("NoOfYears", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(256)
			/// </summary>
			[ColumnAttribute(Storage="_MaintenanceDescription", DbType="NVarChar(256)", CanBeNull=true)]
			public string MaintenanceDescription
			{
				get
				{
					return this._MaintenanceDescription;
				}
				set
				{
					if (this._MaintenanceDescription != value)
					{
						this.OnMaintenanceDescriptionChanging(value);
						this.SendPropertyChanging();
						this._MaintenanceDescription = value;
						this.SendPropertyChanged("MaintenanceDescription");
						this.OnMaintenanceDescriptionChanged();
					}
					this.SendPropertySetterInvoked("MaintenanceDescription", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(256)
			/// </summary>
			[ColumnAttribute(Storage="_Wheel", DbType="NVarChar(256)", CanBeNull=true)]
			public string Wheel
			{
				get
				{
					return this._Wheel;
				}
				set
				{
					if (this._Wheel != value)
					{
						this.OnWheelChanging(value);
						this.SendPropertyChanging();
						this._Wheel = value;
						this.SendPropertyChanged("Wheel");
						this.OnWheelChanged();
					}
					this.SendPropertySetterInvoked("Wheel", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(256)
			/// </summary>
			[ColumnAttribute(Storage="_Saddle", DbType="NVarChar(256)", CanBeNull=true)]
			public string Saddle
			{
				get
				{
					return this._Saddle;
				}
				set
				{
					if (this._Saddle != value)
					{
						this.OnSaddleChanging(value);
						this.SendPropertyChanging();
						this._Saddle = value;
						this.SendPropertyChanged("Saddle");
						this.OnSaddleChanged();
					}
					this.SendPropertySetterInvoked("Saddle", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(256)
			/// </summary>
			[ColumnAttribute(Storage="_Pedal", DbType="NVarChar(256)", CanBeNull=true)]
			public string Pedal
			{
				get
				{
					return this._Pedal;
				}
				set
				{
					if (this._Pedal != value)
					{
						this.OnPedalChanging(value);
						this.SendPropertyChanging();
						this._Pedal = value;
						this.SendPropertyChanged("Pedal");
						this.OnPedalChanged();
					}
					this.SendPropertySetterInvoked("Pedal", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(MAX)
			/// </summary>
			[ColumnAttribute(Storage="_BikeFrame", DbType="NVarChar(MAX)", CanBeNull=true)]
			public string BikeFrame
			{
				get
				{
					return this._BikeFrame;
				}
				set
				{
					if (this._BikeFrame != value)
					{
						this.OnBikeFrameChanging(value);
						this.SendPropertyChanging();
						this._BikeFrame = value;
						this.SendPropertyChanged("BikeFrame");
						this.OnBikeFrameChanged();
					}
					this.SendPropertySetterInvoked("BikeFrame", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(256)
			/// </summary>
			[ColumnAttribute(Storage="_Crankset", DbType="NVarChar(256)", CanBeNull=true)]
			public string Crankset
			{
				get
				{
					return this._Crankset;
				}
				set
				{
					if (this._Crankset != value)
					{
						this.OnCranksetChanging(value);
						this.SendPropertyChanging();
						this._Crankset = value;
						this.SendPropertyChanged("Crankset");
						this.OnCranksetChanged();
					}
					this.SendPropertySetterInvoked("Crankset", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(256)
			/// </summary>
			[ColumnAttribute(Storage="_PictureAngle", DbType="NVarChar(256)", CanBeNull=true)]
			public string PictureAngle
			{
				get
				{
					return this._PictureAngle;
				}
				set
				{
					if (this._PictureAngle != value)
					{
						this.OnPictureAngleChanging(value);
						this.SendPropertyChanging();
						this._PictureAngle = value;
						this.SendPropertyChanged("PictureAngle");
						this.OnPictureAngleChanged();
					}
					this.SendPropertySetterInvoked("PictureAngle", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(256)
			/// </summary>
			[ColumnAttribute(Storage="_PictureSize", DbType="NVarChar(256)", CanBeNull=true)]
			public string PictureSize
			{
				get
				{
					return this._PictureSize;
				}
				set
				{
					if (this._PictureSize != value)
					{
						this.OnPictureSizeChanging(value);
						this.SendPropertyChanging();
						this._PictureSize = value;
						this.SendPropertyChanged("PictureSize");
						this.OnPictureSizeChanged();
					}
					this.SendPropertySetterInvoked("PictureSize", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(256)
			/// </summary>
			[ColumnAttribute(Storage="_ProductPhotoID", DbType="NVarChar(256)", CanBeNull=true)]
			public string ProductPhotoID
			{
				get
				{
					return this._ProductPhotoID;
				}
				set
				{
					if (this._ProductPhotoID != value)
					{
						this.OnProductPhotoIDChanging(value);
						this.SendPropertyChanging();
						this._ProductPhotoID = value;
						this.SendPropertyChanged("ProductPhotoID");
						this.OnProductPhotoIDChanged();
					}
					this.SendPropertySetterInvoked("ProductPhotoID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(256)
			/// </summary>
			[ColumnAttribute(Storage="_Material", DbType="NVarChar(256)", CanBeNull=true)]
			public string Material
			{
				get
				{
					return this._Material;
				}
				set
				{
					if (this._Material != value)
					{
						this.OnMaterialChanging(value);
						this.SendPropertyChanging();
						this._Material = value;
						this.SendPropertyChanged("Material");
						this.OnMaterialChanged();
					}
					this.SendPropertySetterInvoked("Material", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(256)
			/// </summary>
			[ColumnAttribute(Storage="_Color", DbType="NVarChar(256)", CanBeNull=true)]
			public string Color
			{
				get
				{
					return this._Color;
				}
				set
				{
					if (this._Color != value)
					{
						this.OnColorChanging(value);
						this.SendPropertyChanging();
						this._Color = value;
						this.SendPropertyChanged("Color");
						this.OnColorChanged();
					}
					this.SendPropertySetterInvoked("Color", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(256)
			/// </summary>
			[ColumnAttribute(Storage="_ProductLine", DbType="NVarChar(256)", CanBeNull=true)]
			public string ProductLine
			{
				get
				{
					return this._ProductLine;
				}
				set
				{
					if (this._ProductLine != value)
					{
						this.OnProductLineChanging(value);
						this.SendPropertyChanging();
						this._ProductLine = value;
						this.SendPropertyChanged("ProductLine");
						this.OnProductLineChanged();
					}
					this.SendPropertySetterInvoked("ProductLine", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(256)
			/// </summary>
			[ColumnAttribute(Storage="_Style", DbType="NVarChar(256)", CanBeNull=true)]
			public string Style
			{
				get
				{
					return this._Style;
				}
				set
				{
					if (this._Style != value)
					{
						this.OnStyleChanging(value);
						this.SendPropertyChanging();
						this._Style = value;
						this.SendPropertyChanged("Style");
						this.OnStyleChanged();
					}
					this.SendPropertySetterInvoked("Style", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(1024)
			/// </summary>
			[ColumnAttribute(Storage="_RiderExperience", DbType="NVarChar(1024)", CanBeNull=true)]
			public string RiderExperience
			{
				get
				{
					return this._RiderExperience;
				}
				set
				{
					if (this._RiderExperience != value)
					{
						this.OnRiderExperienceChanging(value);
						this.SendPropertyChanging();
						this._RiderExperience = value;
						this.SendPropertyChanged("RiderExperience");
						this.OnRiderExperienceChanged();
					}
					this.SendPropertySetterInvoked("RiderExperience", value);
				}
			}
			
			/// <summary>
			/// Column DbType=UniqueIdentifier NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_rowguid", DbType="UniqueIdentifier NOT NULL", CanBeNull=false)]
			public System.Guid rowguid
			{
				get
				{
					return this._rowguid;
				}
				set
				{
					if (this._rowguid != value)
					{
						this.OnrowguidChanging(value);
						this.SendPropertyChanging();
						this._rowguid = value;
						this.SendPropertyChanged("rowguid");
						this.OnrowguidChanged();
					}
					this.SendPropertySetterInvoked("rowguid", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ModifiedDate", DbType="DateTime NOT NULL", CanBeNull=false)]
			public DateTime ModifiedDate
			{
				get
				{
					return this._ModifiedDate;
				}
				set
				{
					if (this._ModifiedDate != value)
					{
						this.OnModifiedDateChanging(value);
						this.SendPropertyChanging();
						this._ModifiedDate = value;
						this.SendPropertyChanged("ModifiedDate");
						this.OnModifiedDateChanged();
					}
					this.SendPropertySetterInvoked("ModifiedDate", value);
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
		#endregion Production.vProductModelCatalogDescription

		#region Production.vProductModelInstructions
		[TableAttribute(Name="Production.vProductModelInstructions")]
		public partial class Production_vProductModelInstructions : EntityBase<Production_vProductModelInstructions, AdventureWorksDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private int _ProductModelID;
			private string _Name;
			private string _Instructions;
			private int? _LocationID;
			private decimal? _SetupHours;
			private decimal? _MachineHours;
			private decimal? _LaborHours;
			private int? _LotSize;
			private string _Step;
			private System.Guid _rowguid;
			private DateTime _ModifiedDate;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnProductModelIDChanging(int value);
			partial void OnProductModelIDChanged();
			partial void OnNameChanging(string value);
			partial void OnNameChanged();
			partial void OnInstructionsChanging(string value);
			partial void OnInstructionsChanged();
			partial void OnLocationIDChanging(int? value);
			partial void OnLocationIDChanged();
			partial void OnSetupHoursChanging(decimal? value);
			partial void OnSetupHoursChanged();
			partial void OnMachineHoursChanging(decimal? value);
			partial void OnMachineHoursChanged();
			partial void OnLaborHoursChanging(decimal? value);
			partial void OnLaborHoursChanged();
			partial void OnLotSizeChanging(int? value);
			partial void OnLotSizeChanged();
			partial void OnStepChanging(string value);
			partial void OnStepChanged();
			partial void OnrowguidChanging(System.Guid value);
			partial void OnrowguidChanged();
			partial void OnModifiedDateChanging(DateTime value);
			partial void OnModifiedDateChanged();
			#endregion

			public Production_vProductModelInstructions()
			{
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=Int NOT NULL IDENTITY
			/// </summary>
			[ColumnAttribute(Storage="_ProductModelID", DbType="Int NOT NULL IDENTITY", CanBeNull=false)]
			public int ProductModelID
			{
				get
				{
					return this._ProductModelID;
				}
				set
				{
					if (this._ProductModelID != value)
					{
						this.OnProductModelIDChanging(value);
						this.SendPropertyChanging();
						this._ProductModelID = value;
						this.SendPropertyChanged("ProductModelID");
						this.OnProductModelIDChanged();
					}
					this.SendPropertySetterInvoked("ProductModelID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(50) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_Name", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
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
			/// Column DbType=NVarChar(MAX)
			/// </summary>
			[ColumnAttribute(Storage="_Instructions", DbType="NVarChar(MAX)", CanBeNull=true)]
			public string Instructions
			{
				get
				{
					return this._Instructions;
				}
				set
				{
					if (this._Instructions != value)
					{
						this.OnInstructionsChanging(value);
						this.SendPropertyChanging();
						this._Instructions = value;
						this.SendPropertyChanged("Instructions");
						this.OnInstructionsChanged();
					}
					this.SendPropertySetterInvoked("Instructions", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int
			/// </summary>
			[ColumnAttribute(Storage="_LocationID", DbType="Int", CanBeNull=true)]
			public int? LocationID
			{
				get
				{
					return this._LocationID;
				}
				set
				{
					if (this._LocationID != value)
					{
						this.OnLocationIDChanging(value);
						this.SendPropertyChanging();
						this._LocationID = value;
						this.SendPropertyChanged("LocationID");
						this.OnLocationIDChanged();
					}
					this.SendPropertySetterInvoked("LocationID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Decimal(9,4)
			/// </summary>
			[ColumnAttribute(Storage="_SetupHours", DbType="Decimal(9,4)", CanBeNull=true)]
			public decimal? SetupHours
			{
				get
				{
					return this._SetupHours;
				}
				set
				{
					if (this._SetupHours != value)
					{
						this.OnSetupHoursChanging(value);
						this.SendPropertyChanging();
						this._SetupHours = value;
						this.SendPropertyChanged("SetupHours");
						this.OnSetupHoursChanged();
					}
					this.SendPropertySetterInvoked("SetupHours", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Decimal(9,4)
			/// </summary>
			[ColumnAttribute(Storage="_MachineHours", DbType="Decimal(9,4)", CanBeNull=true)]
			public decimal? MachineHours
			{
				get
				{
					return this._MachineHours;
				}
				set
				{
					if (this._MachineHours != value)
					{
						this.OnMachineHoursChanging(value);
						this.SendPropertyChanging();
						this._MachineHours = value;
						this.SendPropertyChanged("MachineHours");
						this.OnMachineHoursChanged();
					}
					this.SendPropertySetterInvoked("MachineHours", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Decimal(9,4)
			/// </summary>
			[ColumnAttribute(Storage="_LaborHours", DbType="Decimal(9,4)", CanBeNull=true)]
			public decimal? LaborHours
			{
				get
				{
					return this._LaborHours;
				}
				set
				{
					if (this._LaborHours != value)
					{
						this.OnLaborHoursChanging(value);
						this.SendPropertyChanging();
						this._LaborHours = value;
						this.SendPropertyChanged("LaborHours");
						this.OnLaborHoursChanged();
					}
					this.SendPropertySetterInvoked("LaborHours", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int
			/// </summary>
			[ColumnAttribute(Storage="_LotSize", DbType="Int", CanBeNull=true)]
			public int? LotSize
			{
				get
				{
					return this._LotSize;
				}
				set
				{
					if (this._LotSize != value)
					{
						this.OnLotSizeChanging(value);
						this.SendPropertyChanging();
						this._LotSize = value;
						this.SendPropertyChanged("LotSize");
						this.OnLotSizeChanged();
					}
					this.SendPropertySetterInvoked("LotSize", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(1024)
			/// </summary>
			[ColumnAttribute(Storage="_Step", DbType="NVarChar(1024)", CanBeNull=true)]
			public string Step
			{
				get
				{
					return this._Step;
				}
				set
				{
					if (this._Step != value)
					{
						this.OnStepChanging(value);
						this.SendPropertyChanging();
						this._Step = value;
						this.SendPropertyChanged("Step");
						this.OnStepChanged();
					}
					this.SendPropertySetterInvoked("Step", value);
				}
			}
			
			/// <summary>
			/// Column DbType=UniqueIdentifier NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_rowguid", DbType="UniqueIdentifier NOT NULL", CanBeNull=false)]
			public System.Guid rowguid
			{
				get
				{
					return this._rowguid;
				}
				set
				{
					if (this._rowguid != value)
					{
						this.OnrowguidChanging(value);
						this.SendPropertyChanging();
						this._rowguid = value;
						this.SendPropertyChanged("rowguid");
						this.OnrowguidChanged();
					}
					this.SendPropertySetterInvoked("rowguid", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ModifiedDate", DbType="DateTime NOT NULL", CanBeNull=false)]
			public DateTime ModifiedDate
			{
				get
				{
					return this._ModifiedDate;
				}
				set
				{
					if (this._ModifiedDate != value)
					{
						this.OnModifiedDateChanging(value);
						this.SendPropertyChanging();
						this._ModifiedDate = value;
						this.SendPropertyChanged("ModifiedDate");
						this.OnModifiedDateChanged();
					}
					this.SendPropertySetterInvoked("ModifiedDate", value);
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
		#endregion Production.vProductModelInstructions

		#region Sales.vSalesPerson
		[TableAttribute(Name="Sales.vSalesPerson")]
		public partial class Sales_vSalesPerson : EntityBase<Sales_vSalesPerson, AdventureWorksDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private int _SalesPersonID;
			private string _Title;
			private string _FirstName;
			private string _MiddleName;
			private string _LastName;
			private string _Suffix;
			private string _JobTitle;
			private string _Phone;
			private string _EmailAddress;
			private int _EmailPromotion;
			private string _AddressLine1;
			private string _AddressLine2;
			private string _City;
			private string _StateProvinceName;
			private string _PostalCode;
			private string _CountryRegionName;
			private string _TerritoryName;
			private string _TerritoryGroup;
			private decimal? _SalesQuota;
			private decimal _SalesYTD;
			private decimal _SalesLastYear;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnSalesPersonIDChanging(int value);
			partial void OnSalesPersonIDChanged();
			partial void OnTitleChanging(string value);
			partial void OnTitleChanged();
			partial void OnFirstNameChanging(string value);
			partial void OnFirstNameChanged();
			partial void OnMiddleNameChanging(string value);
			partial void OnMiddleNameChanged();
			partial void OnLastNameChanging(string value);
			partial void OnLastNameChanged();
			partial void OnSuffixChanging(string value);
			partial void OnSuffixChanged();
			partial void OnJobTitleChanging(string value);
			partial void OnJobTitleChanged();
			partial void OnPhoneChanging(string value);
			partial void OnPhoneChanged();
			partial void OnEmailAddressChanging(string value);
			partial void OnEmailAddressChanged();
			partial void OnEmailPromotionChanging(int value);
			partial void OnEmailPromotionChanged();
			partial void OnAddressLine1Changing(string value);
			partial void OnAddressLine1Changed();
			partial void OnAddressLine2Changing(string value);
			partial void OnAddressLine2Changed();
			partial void OnCityChanging(string value);
			partial void OnCityChanged();
			partial void OnStateProvinceNameChanging(string value);
			partial void OnStateProvinceNameChanged();
			partial void OnPostalCodeChanging(string value);
			partial void OnPostalCodeChanged();
			partial void OnCountryRegionNameChanging(string value);
			partial void OnCountryRegionNameChanged();
			partial void OnTerritoryNameChanging(string value);
			partial void OnTerritoryNameChanged();
			partial void OnTerritoryGroupChanging(string value);
			partial void OnTerritoryGroupChanged();
			partial void OnSalesQuotaChanging(decimal? value);
			partial void OnSalesQuotaChanged();
			partial void OnSalesYTDChanging(decimal value);
			partial void OnSalesYTDChanged();
			partial void OnSalesLastYearChanging(decimal value);
			partial void OnSalesLastYearChanged();
			#endregion

			public Sales_vSalesPerson()
			{
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_SalesPersonID", DbType="Int NOT NULL", CanBeNull=false)]
			public int SalesPersonID
			{
				get
				{
					return this._SalesPersonID;
				}
				set
				{
					if (this._SalesPersonID != value)
					{
						this.OnSalesPersonIDChanging(value);
						this.SendPropertyChanging();
						this._SalesPersonID = value;
						this.SendPropertyChanged("SalesPersonID");
						this.OnSalesPersonIDChanged();
					}
					this.SendPropertySetterInvoked("SalesPersonID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(8)
			/// </summary>
			[ColumnAttribute(Storage="_Title", DbType="NVarChar(8)", CanBeNull=true)]
			public string Title
			{
				get
				{
					return this._Title;
				}
				set
				{
					if (this._Title != value)
					{
						this.OnTitleChanging(value);
						this.SendPropertyChanging();
						this._Title = value;
						this.SendPropertyChanged("Title");
						this.OnTitleChanged();
					}
					this.SendPropertySetterInvoked("Title", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(50) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_FirstName", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
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
			/// Column DbType=NVarChar(50)
			/// </summary>
			[ColumnAttribute(Storage="_MiddleName", DbType="NVarChar(50)", CanBeNull=true)]
			public string MiddleName
			{
				get
				{
					return this._MiddleName;
				}
				set
				{
					if (this._MiddleName != value)
					{
						this.OnMiddleNameChanging(value);
						this.SendPropertyChanging();
						this._MiddleName = value;
						this.SendPropertyChanged("MiddleName");
						this.OnMiddleNameChanged();
					}
					this.SendPropertySetterInvoked("MiddleName", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(50) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_LastName", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
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
			/// Column DbType=NVarChar(10)
			/// </summary>
			[ColumnAttribute(Storage="_Suffix", DbType="NVarChar(10)", CanBeNull=true)]
			public string Suffix
			{
				get
				{
					return this._Suffix;
				}
				set
				{
					if (this._Suffix != value)
					{
						this.OnSuffixChanging(value);
						this.SendPropertyChanging();
						this._Suffix = value;
						this.SendPropertyChanged("Suffix");
						this.OnSuffixChanged();
					}
					this.SendPropertySetterInvoked("Suffix", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(50) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_JobTitle", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
			public string JobTitle
			{
				get
				{
					return this._JobTitle;
				}
				set
				{
					if (this._JobTitle != value)
					{
						this.OnJobTitleChanging(value);
						this.SendPropertyChanging();
						this._JobTitle = value;
						this.SendPropertyChanged("JobTitle");
						this.OnJobTitleChanged();
					}
					this.SendPropertySetterInvoked("JobTitle", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(25)
			/// </summary>
			[ColumnAttribute(Storage="_Phone", DbType="NVarChar(25)", CanBeNull=true)]
			public string Phone
			{
				get
				{
					return this._Phone;
				}
				set
				{
					if (this._Phone != value)
					{
						this.OnPhoneChanging(value);
						this.SendPropertyChanging();
						this._Phone = value;
						this.SendPropertyChanged("Phone");
						this.OnPhoneChanged();
					}
					this.SendPropertySetterInvoked("Phone", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(50)
			/// </summary>
			[ColumnAttribute(Storage="_EmailAddress", DbType="NVarChar(50)", CanBeNull=true)]
			public string EmailAddress
			{
				get
				{
					return this._EmailAddress;
				}
				set
				{
					if (this._EmailAddress != value)
					{
						this.OnEmailAddressChanging(value);
						this.SendPropertyChanging();
						this._EmailAddress = value;
						this.SendPropertyChanged("EmailAddress");
						this.OnEmailAddressChanged();
					}
					this.SendPropertySetterInvoked("EmailAddress", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_EmailPromotion", DbType="Int NOT NULL", CanBeNull=false)]
			public int EmailPromotion
			{
				get
				{
					return this._EmailPromotion;
				}
				set
				{
					if (this._EmailPromotion != value)
					{
						this.OnEmailPromotionChanging(value);
						this.SendPropertyChanging();
						this._EmailPromotion = value;
						this.SendPropertyChanged("EmailPromotion");
						this.OnEmailPromotionChanged();
					}
					this.SendPropertySetterInvoked("EmailPromotion", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(60) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_AddressLine1", DbType="NVarChar(60) NOT NULL", CanBeNull=false)]
			public string AddressLine1
			{
				get
				{
					return this._AddressLine1;
				}
				set
				{
					if (this._AddressLine1 != value)
					{
						this.OnAddressLine1Changing(value);
						this.SendPropertyChanging();
						this._AddressLine1 = value;
						this.SendPropertyChanged("AddressLine1");
						this.OnAddressLine1Changed();
					}
					this.SendPropertySetterInvoked("AddressLine1", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(60)
			/// </summary>
			[ColumnAttribute(Storage="_AddressLine2", DbType="NVarChar(60)", CanBeNull=true)]
			public string AddressLine2
			{
				get
				{
					return this._AddressLine2;
				}
				set
				{
					if (this._AddressLine2 != value)
					{
						this.OnAddressLine2Changing(value);
						this.SendPropertyChanging();
						this._AddressLine2 = value;
						this.SendPropertyChanged("AddressLine2");
						this.OnAddressLine2Changed();
					}
					this.SendPropertySetterInvoked("AddressLine2", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(30) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_City", DbType="NVarChar(30) NOT NULL", CanBeNull=false)]
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
			/// Column DbType=NVarChar(50) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_StateProvinceName", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
			public string StateProvinceName
			{
				get
				{
					return this._StateProvinceName;
				}
				set
				{
					if (this._StateProvinceName != value)
					{
						this.OnStateProvinceNameChanging(value);
						this.SendPropertyChanging();
						this._StateProvinceName = value;
						this.SendPropertyChanged("StateProvinceName");
						this.OnStateProvinceNameChanged();
					}
					this.SendPropertySetterInvoked("StateProvinceName", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(15) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_PostalCode", DbType="NVarChar(15) NOT NULL", CanBeNull=false)]
			public string PostalCode
			{
				get
				{
					return this._PostalCode;
				}
				set
				{
					if (this._PostalCode != value)
					{
						this.OnPostalCodeChanging(value);
						this.SendPropertyChanging();
						this._PostalCode = value;
						this.SendPropertyChanged("PostalCode");
						this.OnPostalCodeChanged();
					}
					this.SendPropertySetterInvoked("PostalCode", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(50) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_CountryRegionName", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
			public string CountryRegionName
			{
				get
				{
					return this._CountryRegionName;
				}
				set
				{
					if (this._CountryRegionName != value)
					{
						this.OnCountryRegionNameChanging(value);
						this.SendPropertyChanging();
						this._CountryRegionName = value;
						this.SendPropertyChanged("CountryRegionName");
						this.OnCountryRegionNameChanged();
					}
					this.SendPropertySetterInvoked("CountryRegionName", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(50)
			/// </summary>
			[ColumnAttribute(Storage="_TerritoryName", DbType="NVarChar(50)", CanBeNull=true)]
			public string TerritoryName
			{
				get
				{
					return this._TerritoryName;
				}
				set
				{
					if (this._TerritoryName != value)
					{
						this.OnTerritoryNameChanging(value);
						this.SendPropertyChanging();
						this._TerritoryName = value;
						this.SendPropertyChanged("TerritoryName");
						this.OnTerritoryNameChanged();
					}
					this.SendPropertySetterInvoked("TerritoryName", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(50)
			/// </summary>
			[ColumnAttribute(Storage="_TerritoryGroup", DbType="NVarChar(50)", CanBeNull=true)]
			public string TerritoryGroup
			{
				get
				{
					return this._TerritoryGroup;
				}
				set
				{
					if (this._TerritoryGroup != value)
					{
						this.OnTerritoryGroupChanging(value);
						this.SendPropertyChanging();
						this._TerritoryGroup = value;
						this.SendPropertyChanged("TerritoryGroup");
						this.OnTerritoryGroupChanged();
					}
					this.SendPropertySetterInvoked("TerritoryGroup", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Money
			/// </summary>
			[ColumnAttribute(Storage="_SalesQuota", DbType="Money", CanBeNull=true)]
			public decimal? SalesQuota
			{
				get
				{
					return this._SalesQuota;
				}
				set
				{
					if (this._SalesQuota != value)
					{
						this.OnSalesQuotaChanging(value);
						this.SendPropertyChanging();
						this._SalesQuota = value;
						this.SendPropertyChanged("SalesQuota");
						this.OnSalesQuotaChanged();
					}
					this.SendPropertySetterInvoked("SalesQuota", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Money NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_SalesYTD", DbType="Money NOT NULL", CanBeNull=false)]
			public decimal SalesYTD
			{
				get
				{
					return this._SalesYTD;
				}
				set
				{
					if (this._SalesYTD != value)
					{
						this.OnSalesYTDChanging(value);
						this.SendPropertyChanging();
						this._SalesYTD = value;
						this.SendPropertyChanged("SalesYTD");
						this.OnSalesYTDChanged();
					}
					this.SendPropertySetterInvoked("SalesYTD", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Money NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_SalesLastYear", DbType="Money NOT NULL", CanBeNull=false)]
			public decimal SalesLastYear
			{
				get
				{
					return this._SalesLastYear;
				}
				set
				{
					if (this._SalesLastYear != value)
					{
						this.OnSalesLastYearChanging(value);
						this.SendPropertyChanging();
						this._SalesLastYear = value;
						this.SendPropertyChanged("SalesLastYear");
						this.OnSalesLastYearChanged();
					}
					this.SendPropertySetterInvoked("SalesLastYear", value);
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
		#endregion Sales.vSalesPerson

		#region Sales.vSalesPersonSalesByFiscalYears
		[TableAttribute(Name="Sales.vSalesPersonSalesByFiscalYears")]
		public partial class Sales_vSalesPersonSalesByFiscalYears : EntityBase<Sales_vSalesPersonSalesByFiscalYears, AdventureWorksDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private int? _SalesPersonID;
			private string _FullName;
			private string _Title;
			private string _SalesTerritory;
			private decimal? __2002;
			private decimal? __2003;
			private decimal? __2004;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnSalesPersonIDChanging(int? value);
			partial void OnSalesPersonIDChanged();
			partial void OnFullNameChanging(string value);
			partial void OnFullNameChanged();
			partial void OnTitleChanging(string value);
			partial void OnTitleChanged();
			partial void OnSalesTerritoryChanging(string value);
			partial void OnSalesTerritoryChanged();
			partial void On_2002Changing(decimal? value);
			partial void On_2002Changed();
			partial void On_2003Changing(decimal? value);
			partial void On_2003Changed();
			partial void On_2004Changing(decimal? value);
			partial void On_2004Changed();
			#endregion

			public Sales_vSalesPersonSalesByFiscalYears()
			{
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=Int
			/// </summary>
			[ColumnAttribute(Storage="_SalesPersonID", DbType="Int", CanBeNull=true)]
			public int? SalesPersonID
			{
				get
				{
					return this._SalesPersonID;
				}
				set
				{
					if (this._SalesPersonID != value)
					{
						this.OnSalesPersonIDChanging(value);
						this.SendPropertyChanging();
						this._SalesPersonID = value;
						this.SendPropertyChanged("SalesPersonID");
						this.OnSalesPersonIDChanged();
					}
					this.SendPropertySetterInvoked("SalesPersonID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(152)
			/// </summary>
			[ColumnAttribute(Storage="_FullName", DbType="NVarChar(152)", CanBeNull=true)]
			public string FullName
			{
				get
				{
					return this._FullName;
				}
				set
				{
					if (this._FullName != value)
					{
						this.OnFullNameChanging(value);
						this.SendPropertyChanging();
						this._FullName = value;
						this.SendPropertyChanged("FullName");
						this.OnFullNameChanged();
					}
					this.SendPropertySetterInvoked("FullName", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(50) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_Title", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
			public string Title
			{
				get
				{
					return this._Title;
				}
				set
				{
					if (this._Title != value)
					{
						this.OnTitleChanging(value);
						this.SendPropertyChanging();
						this._Title = value;
						this.SendPropertyChanged("Title");
						this.OnTitleChanged();
					}
					this.SendPropertySetterInvoked("Title", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(50) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_SalesTerritory", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
			public string SalesTerritory
			{
				get
				{
					return this._SalesTerritory;
				}
				set
				{
					if (this._SalesTerritory != value)
					{
						this.OnSalesTerritoryChanging(value);
						this.SendPropertyChanging();
						this._SalesTerritory = value;
						this.SendPropertyChanged("SalesTerritory");
						this.OnSalesTerritoryChanged();
					}
					this.SendPropertySetterInvoked("SalesTerritory", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Money
			/// </summary>
			[ColumnAttribute(Storage="__2002", DbType="Money", CanBeNull=true)]
			public decimal? _2002
			{
				get
				{
					return this.__2002;
				}
				set
				{
					if (this.__2002 != value)
					{
						this.On_2002Changing(value);
						this.SendPropertyChanging();
						this.__2002 = value;
						this.SendPropertyChanged("_2002");
						this.On_2002Changed();
					}
					this.SendPropertySetterInvoked("_2002", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Money
			/// </summary>
			[ColumnAttribute(Storage="__2003", DbType="Money", CanBeNull=true)]
			public decimal? _2003
			{
				get
				{
					return this.__2003;
				}
				set
				{
					if (this.__2003 != value)
					{
						this.On_2003Changing(value);
						this.SendPropertyChanging();
						this.__2003 = value;
						this.SendPropertyChanged("_2003");
						this.On_2003Changed();
					}
					this.SendPropertySetterInvoked("_2003", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Money
			/// </summary>
			[ColumnAttribute(Storage="__2004", DbType="Money", CanBeNull=true)]
			public decimal? _2004
			{
				get
				{
					return this.__2004;
				}
				set
				{
					if (this.__2004 != value)
					{
						this.On_2004Changing(value);
						this.SendPropertyChanging();
						this.__2004 = value;
						this.SendPropertyChanged("_2004");
						this.On_2004Changed();
					}
					this.SendPropertySetterInvoked("_2004", value);
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
		#endregion Sales.vSalesPersonSalesByFiscalYears

		#region Person.vStateProvinceCountryRegion
		[TableAttribute(Name="Person.vStateProvinceCountryRegion")]
		public partial class Person_vStateProvinceCountryRegion : EntityBase<Person_vStateProvinceCountryRegion, AdventureWorksDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private int _StateProvinceID;
			private string _StateProvinceCode;
			private bool _IsOnlyStateProvinceFlag;
			private string _StateProvinceName;
			private int _TerritoryID;
			private string _CountryRegionCode;
			private string _CountryRegionName;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnStateProvinceIDChanging(int value);
			partial void OnStateProvinceIDChanged();
			partial void OnStateProvinceCodeChanging(string value);
			partial void OnStateProvinceCodeChanged();
			partial void OnIsOnlyStateProvinceFlagChanging(bool value);
			partial void OnIsOnlyStateProvinceFlagChanged();
			partial void OnStateProvinceNameChanging(string value);
			partial void OnStateProvinceNameChanged();
			partial void OnTerritoryIDChanging(int value);
			partial void OnTerritoryIDChanged();
			partial void OnCountryRegionCodeChanging(string value);
			partial void OnCountryRegionCodeChanged();
			partial void OnCountryRegionNameChanging(string value);
			partial void OnCountryRegionNameChanged();
			#endregion

			public Person_vStateProvinceCountryRegion()
			{
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_StateProvinceID", DbType="Int NOT NULL", CanBeNull=false)]
			public int StateProvinceID
			{
				get
				{
					return this._StateProvinceID;
				}
				set
				{
					if (this._StateProvinceID != value)
					{
						this.OnStateProvinceIDChanging(value);
						this.SendPropertyChanging();
						this._StateProvinceID = value;
						this.SendPropertyChanged("StateProvinceID");
						this.OnStateProvinceIDChanged();
					}
					this.SendPropertySetterInvoked("StateProvinceID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NChar(3) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_StateProvinceCode", DbType="NChar(3) NOT NULL", CanBeNull=false)]
			public string StateProvinceCode
			{
				get
				{
					return this._StateProvinceCode;
				}
				set
				{
					if (this._StateProvinceCode != value)
					{
						this.OnStateProvinceCodeChanging(value);
						this.SendPropertyChanging();
						this._StateProvinceCode = value;
						this.SendPropertyChanged("StateProvinceCode");
						this.OnStateProvinceCodeChanged();
					}
					this.SendPropertySetterInvoked("StateProvinceCode", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Bit NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_IsOnlyStateProvinceFlag", DbType="Bit NOT NULL", CanBeNull=false)]
			public bool IsOnlyStateProvinceFlag
			{
				get
				{
					return this._IsOnlyStateProvinceFlag;
				}
				set
				{
					if (this._IsOnlyStateProvinceFlag != value)
					{
						this.OnIsOnlyStateProvinceFlagChanging(value);
						this.SendPropertyChanging();
						this._IsOnlyStateProvinceFlag = value;
						this.SendPropertyChanged("IsOnlyStateProvinceFlag");
						this.OnIsOnlyStateProvinceFlagChanged();
					}
					this.SendPropertySetterInvoked("IsOnlyStateProvinceFlag", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(50) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_StateProvinceName", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
			public string StateProvinceName
			{
				get
				{
					return this._StateProvinceName;
				}
				set
				{
					if (this._StateProvinceName != value)
					{
						this.OnStateProvinceNameChanging(value);
						this.SendPropertyChanging();
						this._StateProvinceName = value;
						this.SendPropertyChanged("StateProvinceName");
						this.OnStateProvinceNameChanged();
					}
					this.SendPropertySetterInvoked("StateProvinceName", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_TerritoryID", DbType="Int NOT NULL", CanBeNull=false)]
			public int TerritoryID
			{
				get
				{
					return this._TerritoryID;
				}
				set
				{
					if (this._TerritoryID != value)
					{
						this.OnTerritoryIDChanging(value);
						this.SendPropertyChanging();
						this._TerritoryID = value;
						this.SendPropertyChanged("TerritoryID");
						this.OnTerritoryIDChanged();
					}
					this.SendPropertySetterInvoked("TerritoryID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(3) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_CountryRegionCode", DbType="NVarChar(3) NOT NULL", CanBeNull=false)]
			public string CountryRegionCode
			{
				get
				{
					return this._CountryRegionCode;
				}
				set
				{
					if (this._CountryRegionCode != value)
					{
						this.OnCountryRegionCodeChanging(value);
						this.SendPropertyChanging();
						this._CountryRegionCode = value;
						this.SendPropertyChanged("CountryRegionCode");
						this.OnCountryRegionCodeChanged();
					}
					this.SendPropertySetterInvoked("CountryRegionCode", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(50) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_CountryRegionName", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
			public string CountryRegionName
			{
				get
				{
					return this._CountryRegionName;
				}
				set
				{
					if (this._CountryRegionName != value)
					{
						this.OnCountryRegionNameChanging(value);
						this.SendPropertyChanging();
						this._CountryRegionName = value;
						this.SendPropertyChanged("CountryRegionName");
						this.OnCountryRegionNameChanged();
					}
					this.SendPropertySetterInvoked("CountryRegionName", value);
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
		#endregion Person.vStateProvinceCountryRegion

		#region Sales.vStoreWithDemographics
		[TableAttribute(Name="Sales.vStoreWithDemographics")]
		public partial class Sales_vStoreWithDemographics : EntityBase<Sales_vStoreWithDemographics, AdventureWorksDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private int _CustomerID;
			private string _Name;
			private string _ContactType;
			private string _Title;
			private string _FirstName;
			private string _MiddleName;
			private string _LastName;
			private string _Suffix;
			private string _Phone;
			private string _EmailAddress;
			private int _EmailPromotion;
			private string _AddressType;
			private string _AddressLine1;
			private string _AddressLine2;
			private string _City;
			private string _StateProvinceName;
			private string _PostalCode;
			private string _CountryRegionName;
			private decimal? _AnnualSales;
			private decimal? _AnnualRevenue;
			private string _BankName;
			private string _BusinessType;
			private int? _YearOpened;
			private string _Specialty;
			private int? _SquareFeet;
			private string _Brands;
			private string _Internet;
			private int? _NumberEmployees;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnCustomerIDChanging(int value);
			partial void OnCustomerIDChanged();
			partial void OnNameChanging(string value);
			partial void OnNameChanged();
			partial void OnContactTypeChanging(string value);
			partial void OnContactTypeChanged();
			partial void OnTitleChanging(string value);
			partial void OnTitleChanged();
			partial void OnFirstNameChanging(string value);
			partial void OnFirstNameChanged();
			partial void OnMiddleNameChanging(string value);
			partial void OnMiddleNameChanged();
			partial void OnLastNameChanging(string value);
			partial void OnLastNameChanged();
			partial void OnSuffixChanging(string value);
			partial void OnSuffixChanged();
			partial void OnPhoneChanging(string value);
			partial void OnPhoneChanged();
			partial void OnEmailAddressChanging(string value);
			partial void OnEmailAddressChanged();
			partial void OnEmailPromotionChanging(int value);
			partial void OnEmailPromotionChanged();
			partial void OnAddressTypeChanging(string value);
			partial void OnAddressTypeChanged();
			partial void OnAddressLine1Changing(string value);
			partial void OnAddressLine1Changed();
			partial void OnAddressLine2Changing(string value);
			partial void OnAddressLine2Changed();
			partial void OnCityChanging(string value);
			partial void OnCityChanged();
			partial void OnStateProvinceNameChanging(string value);
			partial void OnStateProvinceNameChanged();
			partial void OnPostalCodeChanging(string value);
			partial void OnPostalCodeChanged();
			partial void OnCountryRegionNameChanging(string value);
			partial void OnCountryRegionNameChanged();
			partial void OnAnnualSalesChanging(decimal? value);
			partial void OnAnnualSalesChanged();
			partial void OnAnnualRevenueChanging(decimal? value);
			partial void OnAnnualRevenueChanged();
			partial void OnBankNameChanging(string value);
			partial void OnBankNameChanged();
			partial void OnBusinessTypeChanging(string value);
			partial void OnBusinessTypeChanged();
			partial void OnYearOpenedChanging(int? value);
			partial void OnYearOpenedChanged();
			partial void OnSpecialtyChanging(string value);
			partial void OnSpecialtyChanged();
			partial void OnSquareFeetChanging(int? value);
			partial void OnSquareFeetChanged();
			partial void OnBrandsChanging(string value);
			partial void OnBrandsChanged();
			partial void OnInternetChanging(string value);
			partial void OnInternetChanged();
			partial void OnNumberEmployeesChanging(int? value);
			partial void OnNumberEmployeesChanged();
			#endregion

			public Sales_vStoreWithDemographics()
			{
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_CustomerID", DbType="Int NOT NULL", CanBeNull=false)]
			public int CustomerID
			{
				get
				{
					return this._CustomerID;
				}
				set
				{
					if (this._CustomerID != value)
					{
						this.OnCustomerIDChanging(value);
						this.SendPropertyChanging();
						this._CustomerID = value;
						this.SendPropertyChanged("CustomerID");
						this.OnCustomerIDChanged();
					}
					this.SendPropertySetterInvoked("CustomerID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(50) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_Name", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
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
			/// Column DbType=NVarChar(50) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ContactType", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
			public string ContactType
			{
				get
				{
					return this._ContactType;
				}
				set
				{
					if (this._ContactType != value)
					{
						this.OnContactTypeChanging(value);
						this.SendPropertyChanging();
						this._ContactType = value;
						this.SendPropertyChanged("ContactType");
						this.OnContactTypeChanged();
					}
					this.SendPropertySetterInvoked("ContactType", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(8)
			/// </summary>
			[ColumnAttribute(Storage="_Title", DbType="NVarChar(8)", CanBeNull=true)]
			public string Title
			{
				get
				{
					return this._Title;
				}
				set
				{
					if (this._Title != value)
					{
						this.OnTitleChanging(value);
						this.SendPropertyChanging();
						this._Title = value;
						this.SendPropertyChanged("Title");
						this.OnTitleChanged();
					}
					this.SendPropertySetterInvoked("Title", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(50) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_FirstName", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
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
			/// Column DbType=NVarChar(50)
			/// </summary>
			[ColumnAttribute(Storage="_MiddleName", DbType="NVarChar(50)", CanBeNull=true)]
			public string MiddleName
			{
				get
				{
					return this._MiddleName;
				}
				set
				{
					if (this._MiddleName != value)
					{
						this.OnMiddleNameChanging(value);
						this.SendPropertyChanging();
						this._MiddleName = value;
						this.SendPropertyChanged("MiddleName");
						this.OnMiddleNameChanged();
					}
					this.SendPropertySetterInvoked("MiddleName", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(50) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_LastName", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
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
			/// Column DbType=NVarChar(10)
			/// </summary>
			[ColumnAttribute(Storage="_Suffix", DbType="NVarChar(10)", CanBeNull=true)]
			public string Suffix
			{
				get
				{
					return this._Suffix;
				}
				set
				{
					if (this._Suffix != value)
					{
						this.OnSuffixChanging(value);
						this.SendPropertyChanging();
						this._Suffix = value;
						this.SendPropertyChanged("Suffix");
						this.OnSuffixChanged();
					}
					this.SendPropertySetterInvoked("Suffix", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(25)
			/// </summary>
			[ColumnAttribute(Storage="_Phone", DbType="NVarChar(25)", CanBeNull=true)]
			public string Phone
			{
				get
				{
					return this._Phone;
				}
				set
				{
					if (this._Phone != value)
					{
						this.OnPhoneChanging(value);
						this.SendPropertyChanging();
						this._Phone = value;
						this.SendPropertyChanged("Phone");
						this.OnPhoneChanged();
					}
					this.SendPropertySetterInvoked("Phone", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(50)
			/// </summary>
			[ColumnAttribute(Storage="_EmailAddress", DbType="NVarChar(50)", CanBeNull=true)]
			public string EmailAddress
			{
				get
				{
					return this._EmailAddress;
				}
				set
				{
					if (this._EmailAddress != value)
					{
						this.OnEmailAddressChanging(value);
						this.SendPropertyChanging();
						this._EmailAddress = value;
						this.SendPropertyChanged("EmailAddress");
						this.OnEmailAddressChanged();
					}
					this.SendPropertySetterInvoked("EmailAddress", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_EmailPromotion", DbType="Int NOT NULL", CanBeNull=false)]
			public int EmailPromotion
			{
				get
				{
					return this._EmailPromotion;
				}
				set
				{
					if (this._EmailPromotion != value)
					{
						this.OnEmailPromotionChanging(value);
						this.SendPropertyChanging();
						this._EmailPromotion = value;
						this.SendPropertyChanged("EmailPromotion");
						this.OnEmailPromotionChanged();
					}
					this.SendPropertySetterInvoked("EmailPromotion", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(50) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_AddressType", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
			public string AddressType
			{
				get
				{
					return this._AddressType;
				}
				set
				{
					if (this._AddressType != value)
					{
						this.OnAddressTypeChanging(value);
						this.SendPropertyChanging();
						this._AddressType = value;
						this.SendPropertyChanged("AddressType");
						this.OnAddressTypeChanged();
					}
					this.SendPropertySetterInvoked("AddressType", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(60) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_AddressLine1", DbType="NVarChar(60) NOT NULL", CanBeNull=false)]
			public string AddressLine1
			{
				get
				{
					return this._AddressLine1;
				}
				set
				{
					if (this._AddressLine1 != value)
					{
						this.OnAddressLine1Changing(value);
						this.SendPropertyChanging();
						this._AddressLine1 = value;
						this.SendPropertyChanged("AddressLine1");
						this.OnAddressLine1Changed();
					}
					this.SendPropertySetterInvoked("AddressLine1", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(60)
			/// </summary>
			[ColumnAttribute(Storage="_AddressLine2", DbType="NVarChar(60)", CanBeNull=true)]
			public string AddressLine2
			{
				get
				{
					return this._AddressLine2;
				}
				set
				{
					if (this._AddressLine2 != value)
					{
						this.OnAddressLine2Changing(value);
						this.SendPropertyChanging();
						this._AddressLine2 = value;
						this.SendPropertyChanged("AddressLine2");
						this.OnAddressLine2Changed();
					}
					this.SendPropertySetterInvoked("AddressLine2", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(30) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_City", DbType="NVarChar(30) NOT NULL", CanBeNull=false)]
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
			/// Column DbType=NVarChar(50) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_StateProvinceName", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
			public string StateProvinceName
			{
				get
				{
					return this._StateProvinceName;
				}
				set
				{
					if (this._StateProvinceName != value)
					{
						this.OnStateProvinceNameChanging(value);
						this.SendPropertyChanging();
						this._StateProvinceName = value;
						this.SendPropertyChanged("StateProvinceName");
						this.OnStateProvinceNameChanged();
					}
					this.SendPropertySetterInvoked("StateProvinceName", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(15) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_PostalCode", DbType="NVarChar(15) NOT NULL", CanBeNull=false)]
			public string PostalCode
			{
				get
				{
					return this._PostalCode;
				}
				set
				{
					if (this._PostalCode != value)
					{
						this.OnPostalCodeChanging(value);
						this.SendPropertyChanging();
						this._PostalCode = value;
						this.SendPropertyChanged("PostalCode");
						this.OnPostalCodeChanged();
					}
					this.SendPropertySetterInvoked("PostalCode", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(50) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_CountryRegionName", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
			public string CountryRegionName
			{
				get
				{
					return this._CountryRegionName;
				}
				set
				{
					if (this._CountryRegionName != value)
					{
						this.OnCountryRegionNameChanging(value);
						this.SendPropertyChanging();
						this._CountryRegionName = value;
						this.SendPropertyChanged("CountryRegionName");
						this.OnCountryRegionNameChanged();
					}
					this.SendPropertySetterInvoked("CountryRegionName", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Money
			/// </summary>
			[ColumnAttribute(Storage="_AnnualSales", DbType="Money", CanBeNull=true)]
			public decimal? AnnualSales
			{
				get
				{
					return this._AnnualSales;
				}
				set
				{
					if (this._AnnualSales != value)
					{
						this.OnAnnualSalesChanging(value);
						this.SendPropertyChanging();
						this._AnnualSales = value;
						this.SendPropertyChanged("AnnualSales");
						this.OnAnnualSalesChanged();
					}
					this.SendPropertySetterInvoked("AnnualSales", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Money
			/// </summary>
			[ColumnAttribute(Storage="_AnnualRevenue", DbType="Money", CanBeNull=true)]
			public decimal? AnnualRevenue
			{
				get
				{
					return this._AnnualRevenue;
				}
				set
				{
					if (this._AnnualRevenue != value)
					{
						this.OnAnnualRevenueChanging(value);
						this.SendPropertyChanging();
						this._AnnualRevenue = value;
						this.SendPropertyChanged("AnnualRevenue");
						this.OnAnnualRevenueChanged();
					}
					this.SendPropertySetterInvoked("AnnualRevenue", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(50)
			/// </summary>
			[ColumnAttribute(Storage="_BankName", DbType="NVarChar(50)", CanBeNull=true)]
			public string BankName
			{
				get
				{
					return this._BankName;
				}
				set
				{
					if (this._BankName != value)
					{
						this.OnBankNameChanging(value);
						this.SendPropertyChanging();
						this._BankName = value;
						this.SendPropertyChanged("BankName");
						this.OnBankNameChanged();
					}
					this.SendPropertySetterInvoked("BankName", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(5)
			/// </summary>
			[ColumnAttribute(Storage="_BusinessType", DbType="NVarChar(5)", CanBeNull=true)]
			public string BusinessType
			{
				get
				{
					return this._BusinessType;
				}
				set
				{
					if (this._BusinessType != value)
					{
						this.OnBusinessTypeChanging(value);
						this.SendPropertyChanging();
						this._BusinessType = value;
						this.SendPropertyChanged("BusinessType");
						this.OnBusinessTypeChanged();
					}
					this.SendPropertySetterInvoked("BusinessType", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int
			/// </summary>
			[ColumnAttribute(Storage="_YearOpened", DbType="Int", CanBeNull=true)]
			public int? YearOpened
			{
				get
				{
					return this._YearOpened;
				}
				set
				{
					if (this._YearOpened != value)
					{
						this.OnYearOpenedChanging(value);
						this.SendPropertyChanging();
						this._YearOpened = value;
						this.SendPropertyChanged("YearOpened");
						this.OnYearOpenedChanged();
					}
					this.SendPropertySetterInvoked("YearOpened", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(50)
			/// </summary>
			[ColumnAttribute(Storage="_Specialty", DbType="NVarChar(50)", CanBeNull=true)]
			public string Specialty
			{
				get
				{
					return this._Specialty;
				}
				set
				{
					if (this._Specialty != value)
					{
						this.OnSpecialtyChanging(value);
						this.SendPropertyChanging();
						this._Specialty = value;
						this.SendPropertyChanged("Specialty");
						this.OnSpecialtyChanged();
					}
					this.SendPropertySetterInvoked("Specialty", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int
			/// </summary>
			[ColumnAttribute(Storage="_SquareFeet", DbType="Int", CanBeNull=true)]
			public int? SquareFeet
			{
				get
				{
					return this._SquareFeet;
				}
				set
				{
					if (this._SquareFeet != value)
					{
						this.OnSquareFeetChanging(value);
						this.SendPropertyChanging();
						this._SquareFeet = value;
						this.SendPropertyChanged("SquareFeet");
						this.OnSquareFeetChanged();
					}
					this.SendPropertySetterInvoked("SquareFeet", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(30)
			/// </summary>
			[ColumnAttribute(Storage="_Brands", DbType="NVarChar(30)", CanBeNull=true)]
			public string Brands
			{
				get
				{
					return this._Brands;
				}
				set
				{
					if (this._Brands != value)
					{
						this.OnBrandsChanging(value);
						this.SendPropertyChanging();
						this._Brands = value;
						this.SendPropertyChanged("Brands");
						this.OnBrandsChanged();
					}
					this.SendPropertySetterInvoked("Brands", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(30)
			/// </summary>
			[ColumnAttribute(Storage="_Internet", DbType="NVarChar(30)", CanBeNull=true)]
			public string Internet
			{
				get
				{
					return this._Internet;
				}
				set
				{
					if (this._Internet != value)
					{
						this.OnInternetChanging(value);
						this.SendPropertyChanging();
						this._Internet = value;
						this.SendPropertyChanged("Internet");
						this.OnInternetChanged();
					}
					this.SendPropertySetterInvoked("Internet", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int
			/// </summary>
			[ColumnAttribute(Storage="_NumberEmployees", DbType="Int", CanBeNull=true)]
			public int? NumberEmployees
			{
				get
				{
					return this._NumberEmployees;
				}
				set
				{
					if (this._NumberEmployees != value)
					{
						this.OnNumberEmployeesChanging(value);
						this.SendPropertyChanging();
						this._NumberEmployees = value;
						this.SendPropertyChanged("NumberEmployees");
						this.OnNumberEmployeesChanged();
					}
					this.SendPropertySetterInvoked("NumberEmployees", value);
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
		#endregion Sales.vStoreWithDemographics

		#region Purchasing.vVendor
		[TableAttribute(Name="Purchasing.vVendor")]
		public partial class Purchasing_vVendor : EntityBase<Purchasing_vVendor, AdventureWorksDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private int _VendorID;
			private string _Name;
			private string _ContactType;
			private string _Title;
			private string _FirstName;
			private string _MiddleName;
			private string _LastName;
			private string _Suffix;
			private string _Phone;
			private string _EmailAddress;
			private int _EmailPromotion;
			private string _AddressLine1;
			private string _AddressLine2;
			private string _City;
			private string _StateProvinceName;
			private string _PostalCode;
			private string _CountryRegionName;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnVendorIDChanging(int value);
			partial void OnVendorIDChanged();
			partial void OnNameChanging(string value);
			partial void OnNameChanged();
			partial void OnContactTypeChanging(string value);
			partial void OnContactTypeChanged();
			partial void OnTitleChanging(string value);
			partial void OnTitleChanged();
			partial void OnFirstNameChanging(string value);
			partial void OnFirstNameChanged();
			partial void OnMiddleNameChanging(string value);
			partial void OnMiddleNameChanged();
			partial void OnLastNameChanging(string value);
			partial void OnLastNameChanged();
			partial void OnSuffixChanging(string value);
			partial void OnSuffixChanged();
			partial void OnPhoneChanging(string value);
			partial void OnPhoneChanged();
			partial void OnEmailAddressChanging(string value);
			partial void OnEmailAddressChanged();
			partial void OnEmailPromotionChanging(int value);
			partial void OnEmailPromotionChanged();
			partial void OnAddressLine1Changing(string value);
			partial void OnAddressLine1Changed();
			partial void OnAddressLine2Changing(string value);
			partial void OnAddressLine2Changed();
			partial void OnCityChanging(string value);
			partial void OnCityChanged();
			partial void OnStateProvinceNameChanging(string value);
			partial void OnStateProvinceNameChanged();
			partial void OnPostalCodeChanging(string value);
			partial void OnPostalCodeChanged();
			partial void OnCountryRegionNameChanging(string value);
			partial void OnCountryRegionNameChanged();
			#endregion

			public Purchasing_vVendor()
			{
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_VendorID", DbType="Int NOT NULL", CanBeNull=false)]
			public int VendorID
			{
				get
				{
					return this._VendorID;
				}
				set
				{
					if (this._VendorID != value)
					{
						this.OnVendorIDChanging(value);
						this.SendPropertyChanging();
						this._VendorID = value;
						this.SendPropertyChanged("VendorID");
						this.OnVendorIDChanged();
					}
					this.SendPropertySetterInvoked("VendorID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(50) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_Name", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
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
			/// Column DbType=NVarChar(50) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ContactType", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
			public string ContactType
			{
				get
				{
					return this._ContactType;
				}
				set
				{
					if (this._ContactType != value)
					{
						this.OnContactTypeChanging(value);
						this.SendPropertyChanging();
						this._ContactType = value;
						this.SendPropertyChanged("ContactType");
						this.OnContactTypeChanged();
					}
					this.SendPropertySetterInvoked("ContactType", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(8)
			/// </summary>
			[ColumnAttribute(Storage="_Title", DbType="NVarChar(8)", CanBeNull=true)]
			public string Title
			{
				get
				{
					return this._Title;
				}
				set
				{
					if (this._Title != value)
					{
						this.OnTitleChanging(value);
						this.SendPropertyChanging();
						this._Title = value;
						this.SendPropertyChanged("Title");
						this.OnTitleChanged();
					}
					this.SendPropertySetterInvoked("Title", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(50) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_FirstName", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
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
			/// Column DbType=NVarChar(50)
			/// </summary>
			[ColumnAttribute(Storage="_MiddleName", DbType="NVarChar(50)", CanBeNull=true)]
			public string MiddleName
			{
				get
				{
					return this._MiddleName;
				}
				set
				{
					if (this._MiddleName != value)
					{
						this.OnMiddleNameChanging(value);
						this.SendPropertyChanging();
						this._MiddleName = value;
						this.SendPropertyChanged("MiddleName");
						this.OnMiddleNameChanged();
					}
					this.SendPropertySetterInvoked("MiddleName", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(50) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_LastName", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
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
			/// Column DbType=NVarChar(10)
			/// </summary>
			[ColumnAttribute(Storage="_Suffix", DbType="NVarChar(10)", CanBeNull=true)]
			public string Suffix
			{
				get
				{
					return this._Suffix;
				}
				set
				{
					if (this._Suffix != value)
					{
						this.OnSuffixChanging(value);
						this.SendPropertyChanging();
						this._Suffix = value;
						this.SendPropertyChanged("Suffix");
						this.OnSuffixChanged();
					}
					this.SendPropertySetterInvoked("Suffix", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(25)
			/// </summary>
			[ColumnAttribute(Storage="_Phone", DbType="NVarChar(25)", CanBeNull=true)]
			public string Phone
			{
				get
				{
					return this._Phone;
				}
				set
				{
					if (this._Phone != value)
					{
						this.OnPhoneChanging(value);
						this.SendPropertyChanging();
						this._Phone = value;
						this.SendPropertyChanged("Phone");
						this.OnPhoneChanged();
					}
					this.SendPropertySetterInvoked("Phone", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(50)
			/// </summary>
			[ColumnAttribute(Storage="_EmailAddress", DbType="NVarChar(50)", CanBeNull=true)]
			public string EmailAddress
			{
				get
				{
					return this._EmailAddress;
				}
				set
				{
					if (this._EmailAddress != value)
					{
						this.OnEmailAddressChanging(value);
						this.SendPropertyChanging();
						this._EmailAddress = value;
						this.SendPropertyChanged("EmailAddress");
						this.OnEmailAddressChanged();
					}
					this.SendPropertySetterInvoked("EmailAddress", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_EmailPromotion", DbType="Int NOT NULL", CanBeNull=false)]
			public int EmailPromotion
			{
				get
				{
					return this._EmailPromotion;
				}
				set
				{
					if (this._EmailPromotion != value)
					{
						this.OnEmailPromotionChanging(value);
						this.SendPropertyChanging();
						this._EmailPromotion = value;
						this.SendPropertyChanged("EmailPromotion");
						this.OnEmailPromotionChanged();
					}
					this.SendPropertySetterInvoked("EmailPromotion", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(60) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_AddressLine1", DbType="NVarChar(60) NOT NULL", CanBeNull=false)]
			public string AddressLine1
			{
				get
				{
					return this._AddressLine1;
				}
				set
				{
					if (this._AddressLine1 != value)
					{
						this.OnAddressLine1Changing(value);
						this.SendPropertyChanging();
						this._AddressLine1 = value;
						this.SendPropertyChanged("AddressLine1");
						this.OnAddressLine1Changed();
					}
					this.SendPropertySetterInvoked("AddressLine1", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(60)
			/// </summary>
			[ColumnAttribute(Storage="_AddressLine2", DbType="NVarChar(60)", CanBeNull=true)]
			public string AddressLine2
			{
				get
				{
					return this._AddressLine2;
				}
				set
				{
					if (this._AddressLine2 != value)
					{
						this.OnAddressLine2Changing(value);
						this.SendPropertyChanging();
						this._AddressLine2 = value;
						this.SendPropertyChanged("AddressLine2");
						this.OnAddressLine2Changed();
					}
					this.SendPropertySetterInvoked("AddressLine2", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(30) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_City", DbType="NVarChar(30) NOT NULL", CanBeNull=false)]
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
			/// Column DbType=NVarChar(50) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_StateProvinceName", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
			public string StateProvinceName
			{
				get
				{
					return this._StateProvinceName;
				}
				set
				{
					if (this._StateProvinceName != value)
					{
						this.OnStateProvinceNameChanging(value);
						this.SendPropertyChanging();
						this._StateProvinceName = value;
						this.SendPropertyChanged("StateProvinceName");
						this.OnStateProvinceNameChanged();
					}
					this.SendPropertySetterInvoked("StateProvinceName", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(15) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_PostalCode", DbType="NVarChar(15) NOT NULL", CanBeNull=false)]
			public string PostalCode
			{
				get
				{
					return this._PostalCode;
				}
				set
				{
					if (this._PostalCode != value)
					{
						this.OnPostalCodeChanging(value);
						this.SendPropertyChanging();
						this._PostalCode = value;
						this.SendPropertyChanged("PostalCode");
						this.OnPostalCodeChanged();
					}
					this.SendPropertySetterInvoked("PostalCode", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(50) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_CountryRegionName", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
			public string CountryRegionName
			{
				get
				{
					return this._CountryRegionName;
				}
				set
				{
					if (this._CountryRegionName != value)
					{
						this.OnCountryRegionNameChanging(value);
						this.SendPropertyChanging();
						this._CountryRegionName = value;
						this.SendPropertyChanged("CountryRegionName");
						this.OnCountryRegionNameChanged();
					}
					this.SendPropertySetterInvoked("CountryRegionName", value);
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
		#endregion Purchasing.vVendor

		#region Production.WorkOrder
		[TableAttribute(Name="Production.WorkOrder")]
		public partial class Production_WorkOrder : EntityBase<Production_WorkOrder, AdventureWorksDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private int _WorkOrderID;
			private int _ProductID;
			private int _OrderQty;
			private int _StockedQty;
			private System.Int16 _ScrappedQty;
			private DateTime _StartDate;
			private DateTime? _EndDate;
			private DateTime _DueDate;
			private System.Int16? _ScrapReasonID;
			private DateTime _ModifiedDate;
			private EntityRef<Production_Product> _Production_Product;
			private EntityRef<Production_ScrapReason> _Production_ScrapReason;
			private EntitySet<Production_WorkOrderRouting> _Production_WorkOrderRoutingList;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnWorkOrderIDChanging(int value);
			partial void OnWorkOrderIDChanged();
			partial void OnProductIDChanging(int value);
			partial void OnProductIDChanged();
			partial void OnOrderQtyChanging(int value);
			partial void OnOrderQtyChanged();
			partial void OnStockedQtyChanging(int value);
			partial void OnStockedQtyChanged();
			partial void OnScrappedQtyChanging(System.Int16 value);
			partial void OnScrappedQtyChanged();
			partial void OnStartDateChanging(DateTime value);
			partial void OnStartDateChanged();
			partial void OnEndDateChanging(DateTime? value);
			partial void OnEndDateChanged();
			partial void OnDueDateChanging(DateTime value);
			partial void OnDueDateChanged();
			partial void OnScrapReasonIDChanging(System.Int16? value);
			partial void OnScrapReasonIDChanged();
			partial void OnModifiedDateChanging(DateTime value);
			partial void OnModifiedDateChanged();
			#endregion

			public Production_WorkOrder()
			{
				_Production_Product = default(EntityRef<Production_Product>);
				_Production_ScrapReason = default(EntityRef<Production_ScrapReason>);
				_Production_WorkOrderRoutingList = new EntitySet<Production_WorkOrderRouting>(
					new Action<Production_WorkOrderRouting>(item=>{this.SendPropertyChanging(); item.Production_WorkOrder=this;}), 
					new Action<Production_WorkOrderRouting>(item=>{this.SendPropertyChanging(); item.Production_WorkOrder=null;}));
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=Int NOT NULL IDENTITY
			/// </summary>
			[ColumnAttribute(Storage="_WorkOrderID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", CanBeNull=false, IsPrimaryKey=true, IsDbGenerated=true)]
			public int WorkOrderID
			{
				get
				{
					return this._WorkOrderID;
				}
				set
				{
					if (this._WorkOrderID != value)
					{
						this.OnWorkOrderIDChanging(value);
						this.SendPropertyChanging();
						this._WorkOrderID = value;
						this.SendPropertyChanged("WorkOrderID");
						this.OnWorkOrderIDChanged();
					}
					this.SendPropertySetterInvoked("WorkOrderID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ProductID", DbType="Int NOT NULL", CanBeNull=false)]
			public int ProductID
			{
				get
				{
					return this._ProductID;
				}
				set
				{
					if (this._ProductID != value)
					{
						this.OnProductIDChanging(value);
						this.SendPropertyChanging();
						this._ProductID = value;
						this.SendPropertyChanged("ProductID");
						this.OnProductIDChanged();
					}
					this.SendPropertySetterInvoked("ProductID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_OrderQty", DbType="Int NOT NULL", CanBeNull=false)]
			public int OrderQty
			{
				get
				{
					return this._OrderQty;
				}
				set
				{
					if (this._OrderQty != value)
					{
						this.OnOrderQtyChanging(value);
						this.SendPropertyChanging();
						this._OrderQty = value;
						this.SendPropertyChanged("OrderQty");
						this.OnOrderQtyChanged();
					}
					this.SendPropertySetterInvoked("OrderQty", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_StockedQty", DbType="Int NOT NULL", CanBeNull=false)]
			public int StockedQty
			{
				get
				{
					return this._StockedQty;
				}
				set
				{
					if (this._StockedQty != value)
					{
						this.OnStockedQtyChanging(value);
						this.SendPropertyChanging();
						this._StockedQty = value;
						this.SendPropertyChanged("StockedQty");
						this.OnStockedQtyChanged();
					}
					this.SendPropertySetterInvoked("StockedQty", value);
				}
			}
			
			/// <summary>
			/// Column DbType=SmallInt NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ScrappedQty", DbType="SmallInt NOT NULL", CanBeNull=false)]
			public System.Int16 ScrappedQty
			{
				get
				{
					return this._ScrappedQty;
				}
				set
				{
					if (this._ScrappedQty != value)
					{
						this.OnScrappedQtyChanging(value);
						this.SendPropertyChanging();
						this._ScrappedQty = value;
						this.SendPropertyChanged("ScrappedQty");
						this.OnScrappedQtyChanged();
					}
					this.SendPropertySetterInvoked("ScrappedQty", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_StartDate", DbType="DateTime NOT NULL", CanBeNull=false)]
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
						this.OnStartDateChanging(value);
						this.SendPropertyChanging();
						this._StartDate = value;
						this.SendPropertyChanged("StartDate");
						this.OnStartDateChanged();
					}
					this.SendPropertySetterInvoked("StartDate", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime
			/// </summary>
			[ColumnAttribute(Storage="_EndDate", DbType="DateTime", CanBeNull=true)]
			public DateTime? EndDate
			{
				get
				{
					return this._EndDate;
				}
				set
				{
					if (this._EndDate != value)
					{
						this.OnEndDateChanging(value);
						this.SendPropertyChanging();
						this._EndDate = value;
						this.SendPropertyChanged("EndDate");
						this.OnEndDateChanged();
					}
					this.SendPropertySetterInvoked("EndDate", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_DueDate", DbType="DateTime NOT NULL", CanBeNull=false)]
			public DateTime DueDate
			{
				get
				{
					return this._DueDate;
				}
				set
				{
					if (this._DueDate != value)
					{
						this.OnDueDateChanging(value);
						this.SendPropertyChanging();
						this._DueDate = value;
						this.SendPropertyChanged("DueDate");
						this.OnDueDateChanged();
					}
					this.SendPropertySetterInvoked("DueDate", value);
				}
			}
			
			/// <summary>
			/// Column DbType=SmallInt
			/// </summary>
			[ColumnAttribute(Storage="_ScrapReasonID", DbType="SmallInt", CanBeNull=true)]
			public System.Int16? ScrapReasonID
			{
				get
				{
					return this._ScrapReasonID;
				}
				set
				{
					if (this._ScrapReasonID != value)
					{
						this.OnScrapReasonIDChanging(value);
						this.SendPropertyChanging();
						this._ScrapReasonID = value;
						this.SendPropertyChanged("ScrapReasonID");
						this.OnScrapReasonIDChanged();
					}
					this.SendPropertySetterInvoked("ScrapReasonID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ModifiedDate", DbType="DateTime NOT NULL", CanBeNull=false)]
			public DateTime ModifiedDate
			{
				get
				{
					return this._ModifiedDate;
				}
				set
				{
					if (this._ModifiedDate != value)
					{
						this.OnModifiedDateChanging(value);
						this.SendPropertyChanging();
						this._ModifiedDate = value;
						this.SendPropertyChanged("ModifiedDate");
						this.OnModifiedDateChanged();
					}
					this.SendPropertySetterInvoked("ModifiedDate", value);
				}
			}
			
			#endregion Columns

			#region Associations
			/// <summary>
			/// Association [FK][Many]Production_WorkOrder.ProductID --- [PK][One]Production_Product.ProductID
			/// </summary>
			[AssociationAttribute(Name="FK_WorkOrder_Product_ProductID", Storage="_Production_Product", ThisKey="ProductID", OtherKey="ProductID", IsUnique=false, IsForeignKey=true)]
			public Production_Product Production_Product
			{
				get
				{
					return this._Production_Product.Entity;
				}
				set
				{
					Production_Product previousValue = this._Production_Product.Entity;
					if ((previousValue != value) || (this._Production_Product.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._Production_Product.Entity = null;
							previousValue.Production_WorkOrderList.Remove(this);
						}
						this._Production_Product.Entity = value;
						if (value != null)
						{
							value.Production_WorkOrderList.Add(this);
							this._ProductID = value.ProductID;
						}
						else
						{
							this._ProductID = default(int);
						}
						this.SendPropertyChanged("Production_Product");
					}
					this.SendPropertySetterInvoked("Production_Product", value);
				}
			}
			
			/// <summary>
			/// Association [FK][Many]Production_WorkOrder.ScrapReasonID --- [PK][One]Production_ScrapReason.ScrapReasonID
			/// </summary>
			[AssociationAttribute(Name="FK_WorkOrder_ScrapReason_ScrapReasonID", Storage="_Production_ScrapReason", ThisKey="ScrapReasonID", OtherKey="ScrapReasonID", IsUnique=false, IsForeignKey=true)]
			public Production_ScrapReason Production_ScrapReason
			{
				get
				{
					return this._Production_ScrapReason.Entity;
				}
				set
				{
					Production_ScrapReason previousValue = this._Production_ScrapReason.Entity;
					if ((previousValue != value) || (this._Production_ScrapReason.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._Production_ScrapReason.Entity = null;
							previousValue.Production_WorkOrderList.Remove(this);
						}
						this._Production_ScrapReason.Entity = value;
						if (value != null)
						{
							value.Production_WorkOrderList.Add(this);
							this._ScrapReasonID = value.ScrapReasonID;
						}
						else
						{
							this._ScrapReasonID = default(System.Int16?);
						}
						this.SendPropertyChanged("Production_ScrapReason");
					}
					this.SendPropertySetterInvoked("Production_ScrapReason", value);
				}
			}
			
			/// <summary>
			/// Association [PK][One]Production_WorkOrder.WorkOrderID --- [FK][Many]Production_WorkOrderRouting.WorkOrderID
			/// </summary>
			[AssociationAttribute(Name="FK_WorkOrderRouting_WorkOrder_WorkOrderID", Storage="_Production_WorkOrderRoutingList", ThisKey="WorkOrderID", OtherKey="WorkOrderID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<Production_WorkOrderRouting> Production_WorkOrderRoutingList
			{
				get { return this._Production_WorkOrderRoutingList; }
				set { this._Production_WorkOrderRoutingList.Assign(value); }
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
		#endregion Production.WorkOrder

		#region Production.WorkOrderRouting
		[TableAttribute(Name="Production.WorkOrderRouting")]
		public partial class Production_WorkOrderRouting : EntityBase<Production_WorkOrderRouting, AdventureWorksDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private int _WorkOrderID;
			private int _ProductID;
			private System.Int16 _OperationSequence;
			private System.Int16 _LocationID;
			private DateTime _ScheduledStartDate;
			private DateTime _ScheduledEndDate;
			private DateTime? _ActualStartDate;
			private DateTime? _ActualEndDate;
			private decimal? _ActualResourceHrs;
			private decimal _PlannedCost;
			private decimal? _ActualCost;
			private DateTime _ModifiedDate;
			private EntityRef<Production_Location> _Production_Location;
			private EntityRef<Production_WorkOrder> _Production_WorkOrder;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnWorkOrderIDChanging(int value);
			partial void OnWorkOrderIDChanged();
			partial void OnProductIDChanging(int value);
			partial void OnProductIDChanged();
			partial void OnOperationSequenceChanging(System.Int16 value);
			partial void OnOperationSequenceChanged();
			partial void OnLocationIDChanging(System.Int16 value);
			partial void OnLocationIDChanged();
			partial void OnScheduledStartDateChanging(DateTime value);
			partial void OnScheduledStartDateChanged();
			partial void OnScheduledEndDateChanging(DateTime value);
			partial void OnScheduledEndDateChanged();
			partial void OnActualStartDateChanging(DateTime? value);
			partial void OnActualStartDateChanged();
			partial void OnActualEndDateChanging(DateTime? value);
			partial void OnActualEndDateChanged();
			partial void OnActualResourceHrsChanging(decimal? value);
			partial void OnActualResourceHrsChanged();
			partial void OnPlannedCostChanging(decimal value);
			partial void OnPlannedCostChanged();
			partial void OnActualCostChanging(decimal? value);
			partial void OnActualCostChanged();
			partial void OnModifiedDateChanging(DateTime value);
			partial void OnModifiedDateChanged();
			#endregion

			public Production_WorkOrderRouting()
			{
				_Production_Location = default(EntityRef<Production_Location>);
				_Production_WorkOrder = default(EntityRef<Production_WorkOrder>);
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_WorkOrderID", DbType="Int NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
			public int WorkOrderID
			{
				get
				{
					return this._WorkOrderID;
				}
				set
				{
					if (this._WorkOrderID != value)
					{
						this.OnWorkOrderIDChanging(value);
						this.SendPropertyChanging();
						this._WorkOrderID = value;
						this.SendPropertyChanged("WorkOrderID");
						this.OnWorkOrderIDChanged();
					}
					this.SendPropertySetterInvoked("WorkOrderID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ProductID", DbType="Int NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
			public int ProductID
			{
				get
				{
					return this._ProductID;
				}
				set
				{
					if (this._ProductID != value)
					{
						this.OnProductIDChanging(value);
						this.SendPropertyChanging();
						this._ProductID = value;
						this.SendPropertyChanged("ProductID");
						this.OnProductIDChanged();
					}
					this.SendPropertySetterInvoked("ProductID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=SmallInt NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_OperationSequence", DbType="SmallInt NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
			public System.Int16 OperationSequence
			{
				get
				{
					return this._OperationSequence;
				}
				set
				{
					if (this._OperationSequence != value)
					{
						this.OnOperationSequenceChanging(value);
						this.SendPropertyChanging();
						this._OperationSequence = value;
						this.SendPropertyChanged("OperationSequence");
						this.OnOperationSequenceChanged();
					}
					this.SendPropertySetterInvoked("OperationSequence", value);
				}
			}
			
			/// <summary>
			/// Column DbType=SmallInt NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_LocationID", DbType="SmallInt NOT NULL", CanBeNull=false)]
			public System.Int16 LocationID
			{
				get
				{
					return this._LocationID;
				}
				set
				{
					if (this._LocationID != value)
					{
						this.OnLocationIDChanging(value);
						this.SendPropertyChanging();
						this._LocationID = value;
						this.SendPropertyChanged("LocationID");
						this.OnLocationIDChanged();
					}
					this.SendPropertySetterInvoked("LocationID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ScheduledStartDate", DbType="DateTime NOT NULL", CanBeNull=false)]
			public DateTime ScheduledStartDate
			{
				get
				{
					return this._ScheduledStartDate;
				}
				set
				{
					if (this._ScheduledStartDate != value)
					{
						this.OnScheduledStartDateChanging(value);
						this.SendPropertyChanging();
						this._ScheduledStartDate = value;
						this.SendPropertyChanged("ScheduledStartDate");
						this.OnScheduledStartDateChanged();
					}
					this.SendPropertySetterInvoked("ScheduledStartDate", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ScheduledEndDate", DbType="DateTime NOT NULL", CanBeNull=false)]
			public DateTime ScheduledEndDate
			{
				get
				{
					return this._ScheduledEndDate;
				}
				set
				{
					if (this._ScheduledEndDate != value)
					{
						this.OnScheduledEndDateChanging(value);
						this.SendPropertyChanging();
						this._ScheduledEndDate = value;
						this.SendPropertyChanged("ScheduledEndDate");
						this.OnScheduledEndDateChanged();
					}
					this.SendPropertySetterInvoked("ScheduledEndDate", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime
			/// </summary>
			[ColumnAttribute(Storage="_ActualStartDate", DbType="DateTime", CanBeNull=true)]
			public DateTime? ActualStartDate
			{
				get
				{
					return this._ActualStartDate;
				}
				set
				{
					if (this._ActualStartDate != value)
					{
						this.OnActualStartDateChanging(value);
						this.SendPropertyChanging();
						this._ActualStartDate = value;
						this.SendPropertyChanged("ActualStartDate");
						this.OnActualStartDateChanged();
					}
					this.SendPropertySetterInvoked("ActualStartDate", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime
			/// </summary>
			[ColumnAttribute(Storage="_ActualEndDate", DbType="DateTime", CanBeNull=true)]
			public DateTime? ActualEndDate
			{
				get
				{
					return this._ActualEndDate;
				}
				set
				{
					if (this._ActualEndDate != value)
					{
						this.OnActualEndDateChanging(value);
						this.SendPropertyChanging();
						this._ActualEndDate = value;
						this.SendPropertyChanged("ActualEndDate");
						this.OnActualEndDateChanged();
					}
					this.SendPropertySetterInvoked("ActualEndDate", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Decimal(9,4)
			/// </summary>
			[ColumnAttribute(Storage="_ActualResourceHrs", DbType="Decimal(9,4)", CanBeNull=true)]
			public decimal? ActualResourceHrs
			{
				get
				{
					return this._ActualResourceHrs;
				}
				set
				{
					if (this._ActualResourceHrs != value)
					{
						this.OnActualResourceHrsChanging(value);
						this.SendPropertyChanging();
						this._ActualResourceHrs = value;
						this.SendPropertyChanged("ActualResourceHrs");
						this.OnActualResourceHrsChanged();
					}
					this.SendPropertySetterInvoked("ActualResourceHrs", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Money NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_PlannedCost", DbType="Money NOT NULL", CanBeNull=false)]
			public decimal PlannedCost
			{
				get
				{
					return this._PlannedCost;
				}
				set
				{
					if (this._PlannedCost != value)
					{
						this.OnPlannedCostChanging(value);
						this.SendPropertyChanging();
						this._PlannedCost = value;
						this.SendPropertyChanged("PlannedCost");
						this.OnPlannedCostChanged();
					}
					this.SendPropertySetterInvoked("PlannedCost", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Money
			/// </summary>
			[ColumnAttribute(Storage="_ActualCost", DbType="Money", CanBeNull=true)]
			public decimal? ActualCost
			{
				get
				{
					return this._ActualCost;
				}
				set
				{
					if (this._ActualCost != value)
					{
						this.OnActualCostChanging(value);
						this.SendPropertyChanging();
						this._ActualCost = value;
						this.SendPropertyChanged("ActualCost");
						this.OnActualCostChanged();
					}
					this.SendPropertySetterInvoked("ActualCost", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ModifiedDate", DbType="DateTime NOT NULL", CanBeNull=false)]
			public DateTime ModifiedDate
			{
				get
				{
					return this._ModifiedDate;
				}
				set
				{
					if (this._ModifiedDate != value)
					{
						this.OnModifiedDateChanging(value);
						this.SendPropertyChanging();
						this._ModifiedDate = value;
						this.SendPropertyChanged("ModifiedDate");
						this.OnModifiedDateChanged();
					}
					this.SendPropertySetterInvoked("ModifiedDate", value);
				}
			}
			
			#endregion Columns

			#region Associations
			/// <summary>
			/// Association [FK][Many]Production_WorkOrderRouting.LocationID --- [PK][One]Production_Location.LocationID
			/// </summary>
			[AssociationAttribute(Name="FK_WorkOrderRouting_Location_LocationID", Storage="_Production_Location", ThisKey="LocationID", OtherKey="LocationID", IsUnique=false, IsForeignKey=true)]
			public Production_Location Production_Location
			{
				get
				{
					return this._Production_Location.Entity;
				}
				set
				{
					Production_Location previousValue = this._Production_Location.Entity;
					if ((previousValue != value) || (this._Production_Location.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._Production_Location.Entity = null;
							previousValue.Production_WorkOrderRoutingList.Remove(this);
						}
						this._Production_Location.Entity = value;
						if (value != null)
						{
							value.Production_WorkOrderRoutingList.Add(this);
							this._LocationID = value.LocationID;
						}
						else
						{
							this._LocationID = default(System.Int16);
						}
						this.SendPropertyChanged("Production_Location");
					}
					this.SendPropertySetterInvoked("Production_Location", value);
				}
			}
			
			/// <summary>
			/// Association [FK][Many]Production_WorkOrderRouting.WorkOrderID --- [PK][One]Production_WorkOrder.WorkOrderID
			/// </summary>
			[AssociationAttribute(Name="FK_WorkOrderRouting_WorkOrder_WorkOrderID", Storage="_Production_WorkOrder", ThisKey="WorkOrderID", OtherKey="WorkOrderID", IsUnique=false, IsForeignKey=true)]
			public Production_WorkOrder Production_WorkOrder
			{
				get
				{
					return this._Production_WorkOrder.Entity;
				}
				set
				{
					Production_WorkOrder previousValue = this._Production_WorkOrder.Entity;
					if ((previousValue != value) || (this._Production_WorkOrder.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._Production_WorkOrder.Entity = null;
							previousValue.Production_WorkOrderRoutingList.Remove(this);
						}
						this._Production_WorkOrder.Entity = value;
						if (value != null)
						{
							value.Production_WorkOrderRoutingList.Add(this);
							this._WorkOrderID = value.WorkOrderID;
						}
						else
						{
							this._WorkOrderID = default(int);
						}
						this.SendPropertyChanged("Production_WorkOrder");
					}
					this.SendPropertySetterInvoked("Production_WorkOrder", value);
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
		#endregion Production.WorkOrderRouting


	#endregion Entity Tables

	#region Entity Return types

	#region ufnGetContactInformationResult
	public partial class ufnGetContactInformationResult
	{
		#region Storage members
		private int _ContactID;
		private string _FirstName;
		private string _LastName;
		private string _JobTitle;
		private string _ContactType;
		#endregion Storage members

		public ufnGetContactInformationResult(){ }

		/// <summary>
		/// Column DbType=Int
		/// </summary>
		[ColumnAttribute(Storage="_ContactID", DbType="Int", CanBeNull=false)]
		public int ContactID
		{
			get
			{
				return this._ContactID;
			}
			set
			{
				if (this._ContactID != value)
				{
					this._ContactID = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=NVarChar(50)
		/// </summary>
		[ColumnAttribute(Storage="_FirstName", DbType="NVarChar(50)", CanBeNull=true)]
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
		/// Column DbType=NVarChar(50)
		/// </summary>
		[ColumnAttribute(Storage="_LastName", DbType="NVarChar(50)", CanBeNull=true)]
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
		/// Column DbType=NVarChar(50)
		/// </summary>
		[ColumnAttribute(Storage="_JobTitle", DbType="NVarChar(50)", CanBeNull=true)]
		public string JobTitle
		{
			get
			{
				return this._JobTitle;
			}
			set
			{
				if (this._JobTitle != value)
				{
					this._JobTitle = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=NVarChar(50)
		/// </summary>
		[ColumnAttribute(Storage="_ContactType", DbType="NVarChar(50)", CanBeNull=true)]
		public string ContactType
		{
			get
			{
				return this._ContactType;
			}
			set
			{
				if (this._ContactType != value)
				{
					this._ContactType = value;
				}
			}
		}
		
	}
	#endregion ufnGetContactInformationResult

	#region uspGetBillOfMaterialsMultipleResults
	public partial class uspGetBillOfMaterialsMultipleResults
	{
		#region Storage members
		private List<uspGetBillOfMaterialsResult> _Result1;
		private int _ReturnValue;
		#endregion Storage members

		public uspGetBillOfMaterialsMultipleResults(){ }

		/// <summary>
		/// Column DbType=
		/// </summary>
		[ColumnAttribute(Storage="_Result1", DbType="", CanBeNull=false)]
		public List<uspGetBillOfMaterialsResult> Result1
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
	#endregion uspGetBillOfMaterialsMultipleResults

	#region uspGetEmployeeManagersMultipleResults
	public partial class uspGetEmployeeManagersMultipleResults
	{
		#region Storage members
		private List<uspGetEmployeeManagersResult> _Result1;
		private int _ReturnValue;
		#endregion Storage members

		public uspGetEmployeeManagersMultipleResults(){ }

		/// <summary>
		/// Column DbType=
		/// </summary>
		[ColumnAttribute(Storage="_Result1", DbType="", CanBeNull=false)]
		public List<uspGetEmployeeManagersResult> Result1
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
	#endregion uspGetEmployeeManagersMultipleResults

	#region uspGetManagerEmployeesMultipleResults
	public partial class uspGetManagerEmployeesMultipleResults
	{
		#region Storage members
		private List<uspGetManagerEmployeesResult> _Result1;
		private int _ReturnValue;
		#endregion Storage members

		public uspGetManagerEmployeesMultipleResults(){ }

		/// <summary>
		/// Column DbType=
		/// </summary>
		[ColumnAttribute(Storage="_Result1", DbType="", CanBeNull=false)]
		public List<uspGetManagerEmployeesResult> Result1
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
	#endregion uspGetManagerEmployeesMultipleResults

	#region uspGetWhereUsedProductIDMultipleResults
	public partial class uspGetWhereUsedProductIDMultipleResults
	{
		#region Storage members
		private List<uspGetWhereUsedProductIDResult> _Result1;
		private int _ReturnValue;
		#endregion Storage members

		public uspGetWhereUsedProductIDMultipleResults(){ }

		/// <summary>
		/// Column DbType=
		/// </summary>
		[ColumnAttribute(Storage="_Result1", DbType="", CanBeNull=false)]
		public List<uspGetWhereUsedProductIDResult> Result1
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
	#endregion uspGetWhereUsedProductIDMultipleResults

	#region uspLogErrorMultipleResults
	public partial class uspLogErrorMultipleResults
	{
		#region Storage members
		private int _ReturnValue;
		#endregion Storage members

		public uspLogErrorMultipleResults(){ }

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
	#endregion uspLogErrorMultipleResults

	#region uspPrintErrorMultipleResults
	public partial class uspPrintErrorMultipleResults
	{
		#region Storage members
		private int _ReturnValue;
		#endregion Storage members

		public uspPrintErrorMultipleResults(){ }

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
	#endregion uspPrintErrorMultipleResults

	#region HumanResources_uspUpdateEmployeeHireInfoMultipleResults
	public partial class HumanResources_uspUpdateEmployeeHireInfoMultipleResults
	{
		#region Storage members
		private int _ReturnValue;
		#endregion Storage members

		public HumanResources_uspUpdateEmployeeHireInfoMultipleResults(){ }

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
	#endregion HumanResources_uspUpdateEmployeeHireInfoMultipleResults

	#region HumanResources_uspUpdateEmployeeLoginMultipleResults
	public partial class HumanResources_uspUpdateEmployeeLoginMultipleResults
	{
		#region Storage members
		private int _ReturnValue;
		#endregion Storage members

		public HumanResources_uspUpdateEmployeeLoginMultipleResults(){ }

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
	#endregion HumanResources_uspUpdateEmployeeLoginMultipleResults

	#region HumanResources_uspUpdateEmployeePersonalInfoMultipleResults
	public partial class HumanResources_uspUpdateEmployeePersonalInfoMultipleResults
	{
		#region Storage members
		private int _ReturnValue;
		#endregion Storage members

		public HumanResources_uspUpdateEmployeePersonalInfoMultipleResults(){ }

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
	#endregion HumanResources_uspUpdateEmployeePersonalInfoMultipleResults

	#region uspGetBillOfMaterialsResult
	public partial class uspGetBillOfMaterialsResult
	{
		#region Storage members
		private int? _ProductAssemblyID;
		private int? _ComponentID;
		private string _ComponentDesc;
		private decimal? _TotalQuantity;
		private decimal? _StandardCost;
		private decimal? _ListPrice;
		private System.Int16? _BOMLevel;
		private int? _RecursionLevel;
		#endregion Storage members

		public uspGetBillOfMaterialsResult(){ }

		/// <summary>
		/// Column DbType=Int
		/// </summary>
		[ColumnAttribute(Storage="_ProductAssemblyID", DbType="Int", CanBeNull=true)]
		public int? ProductAssemblyID
		{
			get
			{
				return this._ProductAssemblyID;
			}
			set
			{
				if (this._ProductAssemblyID != value)
				{
					this._ProductAssemblyID = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Int
		/// </summary>
		[ColumnAttribute(Storage="_ComponentID", DbType="Int", CanBeNull=true)]
		public int? ComponentID
		{
			get
			{
				return this._ComponentID;
			}
			set
			{
				if (this._ComponentID != value)
				{
					this._ComponentID = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=NVarChar(50)
		/// </summary>
		[ColumnAttribute(Storage="_ComponentDesc", DbType="NVarChar(50)", CanBeNull=true)]
		public string ComponentDesc
		{
			get
			{
				return this._ComponentDesc;
			}
			set
			{
				if (this._ComponentDesc != value)
				{
					this._ComponentDesc = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Decimal(38,2)
		/// </summary>
		[ColumnAttribute(Storage="_TotalQuantity", DbType="Decimal(38,2)", CanBeNull=true)]
		public decimal? TotalQuantity
		{
			get
			{
				return this._TotalQuantity;
			}
			set
			{
				if (this._TotalQuantity != value)
				{
					this._TotalQuantity = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Money
		/// </summary>
		[ColumnAttribute(Storage="_StandardCost", DbType="Money", CanBeNull=true)]
		public decimal? StandardCost
		{
			get
			{
				return this._StandardCost;
			}
			set
			{
				if (this._StandardCost != value)
				{
					this._StandardCost = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Money
		/// </summary>
		[ColumnAttribute(Storage="_ListPrice", DbType="Money", CanBeNull=true)]
		public decimal? ListPrice
		{
			get
			{
				return this._ListPrice;
			}
			set
			{
				if (this._ListPrice != value)
				{
					this._ListPrice = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=SmallInt
		/// </summary>
		[ColumnAttribute(Storage="_BOMLevel", DbType="SmallInt", CanBeNull=true)]
		public System.Int16? BOMLevel
		{
			get
			{
				return this._BOMLevel;
			}
			set
			{
				if (this._BOMLevel != value)
				{
					this._BOMLevel = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Int
		/// </summary>
		[ColumnAttribute(Storage="_RecursionLevel", DbType="Int", CanBeNull=true)]
		public int? RecursionLevel
		{
			get
			{
				return this._RecursionLevel;
			}
			set
			{
				if (this._RecursionLevel != value)
				{
					this._RecursionLevel = value;
				}
			}
		}
		
	}
	#endregion uspGetBillOfMaterialsResult

	#region uspGetEmployeeManagersResult
	public partial class uspGetEmployeeManagersResult
	{
		#region Storage members
		private int? _RecursionLevel;
		private int? _EmployeeID;
		private string _FirstName;
		private string _LastName;
		private int? _ManagerID;
		private string _ManagerFirstName;
		private string _ManagerLastName;
		#endregion Storage members

		public uspGetEmployeeManagersResult(){ }

		/// <summary>
		/// Column DbType=Int
		/// </summary>
		[ColumnAttribute(Storage="_RecursionLevel", DbType="Int", CanBeNull=true)]
		public int? RecursionLevel
		{
			get
			{
				return this._RecursionLevel;
			}
			set
			{
				if (this._RecursionLevel != value)
				{
					this._RecursionLevel = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Int
		/// </summary>
		[ColumnAttribute(Storage="_EmployeeID", DbType="Int", CanBeNull=true)]
		public int? EmployeeID
		{
			get
			{
				return this._EmployeeID;
			}
			set
			{
				if (this._EmployeeID != value)
				{
					this._EmployeeID = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=NVarChar(50)
		/// </summary>
		[ColumnAttribute(Storage="_FirstName", DbType="NVarChar(50)", CanBeNull=true)]
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
		/// Column DbType=NVarChar(50)
		/// </summary>
		[ColumnAttribute(Storage="_LastName", DbType="NVarChar(50)", CanBeNull=true)]
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
		/// Column DbType=Int
		/// </summary>
		[ColumnAttribute(Storage="_ManagerID", DbType="Int", CanBeNull=true)]
		public int? ManagerID
		{
			get
			{
				return this._ManagerID;
			}
			set
			{
				if (this._ManagerID != value)
				{
					this._ManagerID = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=NVarChar(50)
		/// </summary>
		[ColumnAttribute(Storage="_ManagerFirstName", DbType="NVarChar(50)", CanBeNull=false)]
		public string ManagerFirstName
		{
			get
			{
				return this._ManagerFirstName;
			}
			set
			{
				if (this._ManagerFirstName != value)
				{
					this._ManagerFirstName = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=NVarChar(50)
		/// </summary>
		[ColumnAttribute(Storage="_ManagerLastName", DbType="NVarChar(50)", CanBeNull=false)]
		public string ManagerLastName
		{
			get
			{
				return this._ManagerLastName;
			}
			set
			{
				if (this._ManagerLastName != value)
				{
					this._ManagerLastName = value;
				}
			}
		}
		
	}
	#endregion uspGetEmployeeManagersResult

	#region uspGetManagerEmployeesResult
	public partial class uspGetManagerEmployeesResult
	{
		#region Storage members
		private int? _RecursionLevel;
		private int? _ManagerID;
		private string _ManagerFirstName;
		private string _ManagerLastName;
		private int? _EmployeeID;
		private string _FirstName;
		private string _LastName;
		#endregion Storage members

		public uspGetManagerEmployeesResult(){ }

		/// <summary>
		/// Column DbType=Int
		/// </summary>
		[ColumnAttribute(Storage="_RecursionLevel", DbType="Int", CanBeNull=true)]
		public int? RecursionLevel
		{
			get
			{
				return this._RecursionLevel;
			}
			set
			{
				if (this._RecursionLevel != value)
				{
					this._RecursionLevel = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Int
		/// </summary>
		[ColumnAttribute(Storage="_ManagerID", DbType="Int", CanBeNull=true)]
		public int? ManagerID
		{
			get
			{
				return this._ManagerID;
			}
			set
			{
				if (this._ManagerID != value)
				{
					this._ManagerID = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=NVarChar(50)
		/// </summary>
		[ColumnAttribute(Storage="_ManagerFirstName", DbType="NVarChar(50)", CanBeNull=false)]
		public string ManagerFirstName
		{
			get
			{
				return this._ManagerFirstName;
			}
			set
			{
				if (this._ManagerFirstName != value)
				{
					this._ManagerFirstName = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=NVarChar(50)
		/// </summary>
		[ColumnAttribute(Storage="_ManagerLastName", DbType="NVarChar(50)", CanBeNull=false)]
		public string ManagerLastName
		{
			get
			{
				return this._ManagerLastName;
			}
			set
			{
				if (this._ManagerLastName != value)
				{
					this._ManagerLastName = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Int
		/// </summary>
		[ColumnAttribute(Storage="_EmployeeID", DbType="Int", CanBeNull=true)]
		public int? EmployeeID
		{
			get
			{
				return this._EmployeeID;
			}
			set
			{
				if (this._EmployeeID != value)
				{
					this._EmployeeID = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=NVarChar(50)
		/// </summary>
		[ColumnAttribute(Storage="_FirstName", DbType="NVarChar(50)", CanBeNull=true)]
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
		/// Column DbType=NVarChar(50)
		/// </summary>
		[ColumnAttribute(Storage="_LastName", DbType="NVarChar(50)", CanBeNull=true)]
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
		
	}
	#endregion uspGetManagerEmployeesResult

	#region uspGetWhereUsedProductIDResult
	public partial class uspGetWhereUsedProductIDResult
	{
		#region Storage members
		private int? _ProductAssemblyID;
		private int? _ComponentID;
		private string _ComponentDesc;
		private decimal? _TotalQuantity;
		private decimal? _StandardCost;
		private decimal? _ListPrice;
		private System.Int16? _BOMLevel;
		private int? _RecursionLevel;
		#endregion Storage members

		public uspGetWhereUsedProductIDResult(){ }

		/// <summary>
		/// Column DbType=Int
		/// </summary>
		[ColumnAttribute(Storage="_ProductAssemblyID", DbType="Int", CanBeNull=true)]
		public int? ProductAssemblyID
		{
			get
			{
				return this._ProductAssemblyID;
			}
			set
			{
				if (this._ProductAssemblyID != value)
				{
					this._ProductAssemblyID = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Int
		/// </summary>
		[ColumnAttribute(Storage="_ComponentID", DbType="Int", CanBeNull=true)]
		public int? ComponentID
		{
			get
			{
				return this._ComponentID;
			}
			set
			{
				if (this._ComponentID != value)
				{
					this._ComponentID = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=NVarChar(50)
		/// </summary>
		[ColumnAttribute(Storage="_ComponentDesc", DbType="NVarChar(50)", CanBeNull=true)]
		public string ComponentDesc
		{
			get
			{
				return this._ComponentDesc;
			}
			set
			{
				if (this._ComponentDesc != value)
				{
					this._ComponentDesc = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Decimal(38,2)
		/// </summary>
		[ColumnAttribute(Storage="_TotalQuantity", DbType="Decimal(38,2)", CanBeNull=true)]
		public decimal? TotalQuantity
		{
			get
			{
				return this._TotalQuantity;
			}
			set
			{
				if (this._TotalQuantity != value)
				{
					this._TotalQuantity = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Money
		/// </summary>
		[ColumnAttribute(Storage="_StandardCost", DbType="Money", CanBeNull=true)]
		public decimal? StandardCost
		{
			get
			{
				return this._StandardCost;
			}
			set
			{
				if (this._StandardCost != value)
				{
					this._StandardCost = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Money
		/// </summary>
		[ColumnAttribute(Storage="_ListPrice", DbType="Money", CanBeNull=true)]
		public decimal? ListPrice
		{
			get
			{
				return this._ListPrice;
			}
			set
			{
				if (this._ListPrice != value)
				{
					this._ListPrice = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=SmallInt
		/// </summary>
		[ColumnAttribute(Storage="_BOMLevel", DbType="SmallInt", CanBeNull=true)]
		public System.Int16? BOMLevel
		{
			get
			{
				return this._BOMLevel;
			}
			set
			{
				if (this._BOMLevel != value)
				{
					this._BOMLevel = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Int
		/// </summary>
		[ColumnAttribute(Storage="_RecursionLevel", DbType="Int", CanBeNull=true)]
		public int? RecursionLevel
		{
			get
			{
				return this._RecursionLevel;
			}
			set
			{
				if (this._RecursionLevel != value)
				{
					this._RecursionLevel = value;
				}
			}
		}
		
	}
	#endregion uspGetWhereUsedProductIDResult

	#endregion Entity Return types

}
#pragma warning restore 1591
