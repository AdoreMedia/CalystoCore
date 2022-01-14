//************************************************************
// Generated using CalystoEFCoreFluentGenerator for MSSQL
//************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Metadata;
using Calysto.EntityFrameworkCore;
using Calysto.Data.Direct;
using Calysto.Common;
using Calysto.Common.Extensions;

namespace AdventureWorks.Database
{
	/// <summary>
	/// CalystoEFCoreFluent for MSSQL
	/// </summary>
	public partial class AdventureWorksDataContext : DbContext
	{
		#region Context constructors
		
		public AdventureWorksDataContext(bool useLazyLoadingProxies)
			: base(new DbContextOptionsBuilder<AdventureWorksDataContext>()
				.UsingThis(builder => { if (useLazyLoadingProxies) builder.UseLazyLoadingProxies(); })
				.Options)
		{
			OnCreated();
		}
		
		public AdventureWorksDataContext(Action<DbContextOptionsBuilder<AdventureWorksDataContext>> configure)
			: base(new DbContextOptionsBuilder<AdventureWorksDataContext>()
				.UsingThis(builder => configure(builder))
				.Options)
		{
			OnCreated();
		}

		public AdventureWorksDataContext(DbContextOptions<AdventureWorksDataContext> options) : base(options)
		{
			OnCreated();
		}

		#endregion Context constructors

		#region OnConfiguring

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured ||
				(!optionsBuilder.Options.Extensions.OfType<RelationalOptionsExtension>().Any(ext => !string.IsNullOrEmpty(ext.ConnectionString) || ext.Connection != null) &&
				!optionsBuilder.Options.Extensions.Any(ext => !(ext is RelationalOptionsExtension) && !(ext is CoreOptionsExtension))))
			{
				optionsBuilder.UseSqlServer(@"Data Source=.\MSSQL2019;Initial Catalog=dbAdventureWorks;Integrated Security=True;Connect Timeout=30;");
			}
			CustomizeConfiguration(ref optionsBuilder);
			base.OnConfiguring(optionsBuilder);
		}

		partial void CustomizeConfiguration(ref DbContextOptionsBuilder optionsBuilder);

		#endregion OnConfiguring

		#region Context properties for tables

		public virtual DbSet<Person_Address> Person_Address { get; set; }
		public virtual DbSet<Person_AddressType> Person_AddressType { get; set; }
		public virtual DbSet<AWBuildVersion> AWBuildVersion { get; set; }
		public virtual DbSet<Production_BillOfMaterials> Production_BillOfMaterials { get; set; }
		public virtual DbSet<Person_Contact> Person_Contact { get; set; }
		public virtual DbSet<Sales_ContactCreditCard> Sales_ContactCreditCard { get; set; }
		public virtual DbSet<Person_ContactType> Person_ContactType { get; set; }
		public virtual DbSet<Person_CountryRegion> Person_CountryRegion { get; set; }
		public virtual DbSet<Sales_CountryRegionCurrency> Sales_CountryRegionCurrency { get; set; }
		public virtual DbSet<Sales_CreditCard> Sales_CreditCard { get; set; }
		public virtual DbSet<Production_Culture> Production_Culture { get; set; }
		public virtual DbSet<Sales_Currency> Sales_Currency { get; set; }
		public virtual DbSet<Sales_CurrencyRate> Sales_CurrencyRate { get; set; }
		public virtual DbSet<Sales_Customer> Sales_Customer { get; set; }
		public virtual DbSet<Sales_CustomerAddress> Sales_CustomerAddress { get; set; }
		public virtual DbSet<DatabaseLog> DatabaseLog { get; set; }
		public virtual DbSet<HumanResources_Department> HumanResources_Department { get; set; }
		public virtual DbSet<Production_Document> Production_Document { get; set; }
		public virtual DbSet<HumanResources_Employee> HumanResources_Employee { get; set; }
		public virtual DbSet<HumanResources_EmployeeAddress> HumanResources_EmployeeAddress { get; set; }
		public virtual DbSet<HumanResources_EmployeeDepartmentHistory> HumanResources_EmployeeDepartmentHistory { get; set; }
		public virtual DbSet<HumanResources_EmployeePayHistory> HumanResources_EmployeePayHistory { get; set; }
		public virtual DbSet<ErrorLog> ErrorLog { get; set; }
		public virtual DbSet<Production_Illustration> Production_Illustration { get; set; }
		public virtual DbSet<Sales_Individual> Sales_Individual { get; set; }
		public virtual DbSet<HumanResources_JobCandidate> HumanResources_JobCandidate { get; set; }
		public virtual DbSet<Production_Location> Production_Location { get; set; }
		public virtual DbSet<Production_Product> Production_Product { get; set; }
		public virtual DbSet<Production_ProductCategory> Production_ProductCategory { get; set; }
		public virtual DbSet<Production_ProductCostHistory> Production_ProductCostHistory { get; set; }
		public virtual DbSet<Production_ProductDescription> Production_ProductDescription { get; set; }
		public virtual DbSet<Production_ProductDocument> Production_ProductDocument { get; set; }
		public virtual DbSet<Production_ProductInventory> Production_ProductInventory { get; set; }
		public virtual DbSet<Production_ProductListPriceHistory> Production_ProductListPriceHistory { get; set; }
		public virtual DbSet<Production_ProductModel> Production_ProductModel { get; set; }
		public virtual DbSet<Production_ProductModelIllustration> Production_ProductModelIllustration { get; set; }
		public virtual DbSet<Production_ProductModelProductDescriptionCulture> Production_ProductModelProductDescriptionCulture { get; set; }
		public virtual DbSet<Production_ProductPhoto> Production_ProductPhoto { get; set; }
		public virtual DbSet<Production_ProductProductPhoto> Production_ProductProductPhoto { get; set; }
		public virtual DbSet<Production_ProductReview> Production_ProductReview { get; set; }
		public virtual DbSet<Production_ProductSubcategory> Production_ProductSubcategory { get; set; }
		public virtual DbSet<Purchasing_ProductVendor> Purchasing_ProductVendor { get; set; }
		public virtual DbSet<Purchasing_PurchaseOrderDetail> Purchasing_PurchaseOrderDetail { get; set; }
		public virtual DbSet<Purchasing_PurchaseOrderHeader> Purchasing_PurchaseOrderHeader { get; set; }
		public virtual DbSet<Sales_SalesOrderDetail> Sales_SalesOrderDetail { get; set; }
		public virtual DbSet<Sales_SalesOrderHeader> Sales_SalesOrderHeader { get; set; }
		public virtual DbSet<Sales_SalesOrderHeaderSalesReason> Sales_SalesOrderHeaderSalesReason { get; set; }
		public virtual DbSet<Sales_SalesPerson> Sales_SalesPerson { get; set; }
		public virtual DbSet<Sales_SalesPersonQuotaHistory> Sales_SalesPersonQuotaHistory { get; set; }
		public virtual DbSet<Sales_SalesReason> Sales_SalesReason { get; set; }
		public virtual DbSet<Sales_SalesTaxRate> Sales_SalesTaxRate { get; set; }
		public virtual DbSet<Sales_SalesTerritory> Sales_SalesTerritory { get; set; }
		public virtual DbSet<Sales_SalesTerritoryHistory> Sales_SalesTerritoryHistory { get; set; }
		public virtual DbSet<Production_ScrapReason> Production_ScrapReason { get; set; }
		public virtual DbSet<HumanResources_Shift> HumanResources_Shift { get; set; }
		public virtual DbSet<Purchasing_ShipMethod> Purchasing_ShipMethod { get; set; }
		public virtual DbSet<Sales_ShoppingCartItem> Sales_ShoppingCartItem { get; set; }
		public virtual DbSet<Sales_SpecialOffer> Sales_SpecialOffer { get; set; }
		public virtual DbSet<Sales_SpecialOfferProduct> Sales_SpecialOfferProduct { get; set; }
		public virtual DbSet<Person_StateProvince> Person_StateProvince { get; set; }
		public virtual DbSet<Sales_Store> Sales_Store { get; set; }
		public virtual DbSet<Sales_StoreContact> Sales_StoreContact { get; set; }
		public virtual DbSet<Production_TransactionHistory> Production_TransactionHistory { get; set; }
		public virtual DbSet<Production_TransactionHistoryArchive> Production_TransactionHistoryArchive { get; set; }
		public virtual DbSet<Production_UnitMeasure> Production_UnitMeasure { get; set; }
		public virtual DbSet<Person_vAdditionalContactInfo> Person_vAdditionalContactInfo { get; set; }
		public virtual DbSet<HumanResources_vEmployee> HumanResources_vEmployee { get; set; }
		public virtual DbSet<HumanResources_vEmployeeDepartment> HumanResources_vEmployeeDepartment { get; set; }
		public virtual DbSet<HumanResources_vEmployeeDepartmentHistory> HumanResources_vEmployeeDepartmentHistory { get; set; }
		public virtual DbSet<Purchasing_Vendor> Purchasing_Vendor { get; set; }
		public virtual DbSet<Purchasing_VendorAddress> Purchasing_VendorAddress { get; set; }
		public virtual DbSet<Purchasing_VendorContact> Purchasing_VendorContact { get; set; }
		public virtual DbSet<Sales_vIndividualCustomer> Sales_vIndividualCustomer { get; set; }
		public virtual DbSet<Sales_vIndividualDemographics> Sales_vIndividualDemographics { get; set; }
		public virtual DbSet<HumanResources_vJobCandidate> HumanResources_vJobCandidate { get; set; }
		public virtual DbSet<HumanResources_vJobCandidateEducation> HumanResources_vJobCandidateEducation { get; set; }
		public virtual DbSet<HumanResources_vJobCandidateEmployment> HumanResources_vJobCandidateEmployment { get; set; }
		public virtual DbSet<Production_vProductAndDescription> Production_vProductAndDescription { get; set; }
		public virtual DbSet<Production_vProductModelCatalogDescription> Production_vProductModelCatalogDescription { get; set; }
		public virtual DbSet<Production_vProductModelInstructions> Production_vProductModelInstructions { get; set; }
		public virtual DbSet<Sales_vSalesPerson> Sales_vSalesPerson { get; set; }
		public virtual DbSet<Sales_vSalesPersonSalesByFiscalYears> Sales_vSalesPersonSalesByFiscalYears { get; set; }
		public virtual DbSet<Person_vStateProvinceCountryRegion> Person_vStateProvinceCountryRegion { get; set; }
		public virtual DbSet<Sales_vStoreWithDemographics> Sales_vStoreWithDemographics { get; set; }
		public virtual DbSet<Purchasing_vVendor> Purchasing_vVendor { get; set; }
		public virtual DbSet<Production_WorkOrder> Production_WorkOrder { get; set; }
		public virtual DbSet<Production_WorkOrderRouting> Production_WorkOrderRouting { get; set; }

		#endregion Context properties for tables

		#region Context database functions

		/// <returns>Scalar value from function</returns>
		public DateTime? ufnGetAccountingEndDate()
		{
			return this.ExecuteList<DateTime?>($@"select dbo.ufnGetAccountingEndDate()").First();
		}

		/// <returns>Scalar value from function</returns>
		public DateTime? ufnGetAccountingStartDate()
		{
			return this.ExecuteList<DateTime?>($@"select dbo.ufnGetAccountingStartDate()").First();
		}

		/// <param name="ContactID">Int</param>
		/// <returns>Sequence from function</returns>
		public List<ufnGetContactInformationResult> ufnGetContactInformation(int? ContactID)
		{
			return this.ExecuteList<ufnGetContactInformationResult>($@"select * from dbo.ufnGetContactInformation({{0}})", ContactID).ToList();
		}

		/// <param name="Status">TinyInt</param>
		/// <returns>Scalar value from function</returns>
		public string ufnGetDocumentStatusText(byte? Status)
		{
			return this.ExecuteList<string>($@"select dbo.ufnGetDocumentStatusText({{0}})", Status).First();
		}

		/// <param name="ProductID">Int</param>
		/// <param name="OrderDate">DateTime</param>
		/// <returns>Scalar value from function</returns>
		public decimal? ufnGetProductDealerPrice(
			int? ProductID, 
			DateTime? OrderDate)
		{
			return this.ExecuteList<decimal?>($@"select dbo.ufnGetProductDealerPrice({{0}}, {{1}})", ProductID, OrderDate).First();
		}

		/// <param name="ProductID">Int</param>
		/// <param name="OrderDate">DateTime</param>
		/// <returns>Scalar value from function</returns>
		public decimal? ufnGetProductListPrice(
			int? ProductID, 
			DateTime? OrderDate)
		{
			return this.ExecuteList<decimal?>($@"select dbo.ufnGetProductListPrice({{0}}, {{1}})", ProductID, OrderDate).First();
		}

		/// <param name="ProductID">Int</param>
		/// <param name="OrderDate">DateTime</param>
		/// <returns>Scalar value from function</returns>
		public decimal? ufnGetProductStandardCost(
			int? ProductID, 
			DateTime? OrderDate)
		{
			return this.ExecuteList<decimal?>($@"select dbo.ufnGetProductStandardCost({{0}}, {{1}})", ProductID, OrderDate).First();
		}

		/// <param name="Status">TinyInt</param>
		/// <returns>Scalar value from function</returns>
		public string ufnGetPurchaseOrderStatusText(byte? Status)
		{
			return this.ExecuteList<string>($@"select dbo.ufnGetPurchaseOrderStatusText({{0}})", Status).First();
		}

		/// <param name="Status">TinyInt</param>
		/// <returns>Scalar value from function</returns>
		public string ufnGetSalesOrderStatusText(byte? Status)
		{
			return this.ExecuteList<string>($@"select dbo.ufnGetSalesOrderStatusText({{0}})", Status).First();
		}

		/// <param name="ProductID">Int</param>
		/// <returns>Scalar value from function</returns>
		public int? ufnGetStock(int? ProductID)
		{
			return this.ExecuteList<int?>($@"select dbo.ufnGetStock({{0}})", ProductID).First();
		}

		/// <param name="Value">Int</param>
		/// <returns>Scalar value from function</returns>
		public string ufnLeadingZeros(int? Value)
		{
			return this.ExecuteList<string>($@"select dbo.ufnLeadingZeros({{0}})", Value).First();
		}

		/// <param name="StartProductID">Int</param>
		/// <param name="CheckDate">DateTime</param>
		/// <returns>MultipleResults from stored procedure</returns>
		public uspGetBillOfMaterialsMultipleResults uspGetBillOfMaterials(
			int? StartProductID, 
			DateTime? CheckDate)
		{
			var multiple_results_1 = this.ExecuteMultipleResults($@"declare @return_value int; 
					exec @return_value = dbo.uspGetBillOfMaterials {{0}}, {{1}}; 
					select @return_value as ReturnValue;", StartProductID, CheckDate);
			var final_result_1 = multiple_results_1.ReadResults(res => new uspGetBillOfMaterialsMultipleResults()
			{
				Result1 = res.GetSequence<uspGetBillOfMaterialsResult>().ToList(),
				ReturnValue = res.GetSequence<int>().Single(),
			});
			return final_result_1;
		}

		/// <param name="EmployeeID">Int</param>
		/// <returns>MultipleResults from stored procedure</returns>
		public uspGetEmployeeManagersMultipleResults uspGetEmployeeManagers(int? EmployeeID)
		{
			var multiple_results_1 = this.ExecuteMultipleResults($@"declare @return_value int; 
					exec @return_value = dbo.uspGetEmployeeManagers {{0}}; 
					select @return_value as ReturnValue;", EmployeeID);
			var final_result_1 = multiple_results_1.ReadResults(res => new uspGetEmployeeManagersMultipleResults()
			{
				Result1 = res.GetSequence<uspGetEmployeeManagersResult>().ToList(),
				ReturnValue = res.GetSequence<int>().Single(),
			});
			return final_result_1;
		}

		/// <param name="ManagerID">Int</param>
		/// <returns>MultipleResults from stored procedure</returns>
		public uspGetManagerEmployeesMultipleResults uspGetManagerEmployees(int? ManagerID)
		{
			var multiple_results_1 = this.ExecuteMultipleResults($@"declare @return_value int; 
					exec @return_value = dbo.uspGetManagerEmployees {{0}}; 
					select @return_value as ReturnValue;", ManagerID);
			var final_result_1 = multiple_results_1.ReadResults(res => new uspGetManagerEmployeesMultipleResults()
			{
				Result1 = res.GetSequence<uspGetManagerEmployeesResult>().ToList(),
				ReturnValue = res.GetSequence<int>().Single(),
			});
			return final_result_1;
		}

		/// <param name="StartProductID">Int</param>
		/// <param name="CheckDate">DateTime</param>
		/// <returns>MultipleResults from stored procedure</returns>
		public uspGetWhereUsedProductIDMultipleResults uspGetWhereUsedProductID(
			int? StartProductID, 
			DateTime? CheckDate)
		{
			var multiple_results_1 = this.ExecuteMultipleResults($@"declare @return_value int; 
					exec @return_value = dbo.uspGetWhereUsedProductID {{0}}, {{1}}; 
					select @return_value as ReturnValue;", StartProductID, CheckDate);
			var final_result_1 = multiple_results_1.ReadResults(res => new uspGetWhereUsedProductIDMultipleResults()
			{
				Result1 = res.GetSequence<uspGetWhereUsedProductIDResult>().ToList(),
				ReturnValue = res.GetSequence<int>().Single(),
			});
			return final_result_1;
		}

		/// <param name="ErrorLogID">Int</param>
		/// <returns>MultipleResults from stored procedure</returns>
		public uspLogErrorMultipleResults uspLogError(ref int? ErrorLogID)
		{
			var multiple_results_1 = this.ExecuteMultipleResults($@"declare @return_value int; 
					exec @return_value = dbo.uspLogError {{0}} out; 
					select @return_value as ReturnValue;", ErrorLogID);
			var final_result_1 = multiple_results_1.ReadResults(res => new uspLogErrorMultipleResults()
			{
				ReturnValue = res.GetSequence<int>().Single(),
			});
			// read Output parameter from stored procedure
			ErrorLogID = Calysto.Utility.CalystoTypeConverter.ChangeType<int?>(multiple_results_1.Command.Parameters[0].Value);
			return final_result_1;
		}

		/// <returns>MultipleResults from stored procedure</returns>
		public uspPrintErrorMultipleResults uspPrintError()
		{
			var multiple_results_1 = this.ExecuteMultipleResults($@"declare @return_value int; 
					exec @return_value = dbo.uspPrintError; 
					select @return_value as ReturnValue;");
			var final_result_1 = multiple_results_1.ReadResults(res => new uspPrintErrorMultipleResults()
			{
				ReturnValue = res.GetSequence<int>().Single(),
			});
			return final_result_1;
		}

		/// <param name="EmployeeID">Int</param>
		/// <param name="Title">NVarChar(50)</param>
		/// <param name="HireDate">DateTime</param>
		/// <param name="RateChangeDate">DateTime</param>
		/// <param name="Rate">Money</param>
		/// <param name="PayFrequency">TinyInt</param>
		/// <param name="CurrentFlag">Bit</param>
		/// <returns>MultipleResults from stored procedure</returns>
		public HumanResources_uspUpdateEmployeeHireInfoMultipleResults HumanResources_uspUpdateEmployeeHireInfo(
			int? EmployeeID, 
			string Title, 
			DateTime? HireDate, 
			DateTime? RateChangeDate, 
			decimal? Rate, 
			byte? PayFrequency, 
			bool? CurrentFlag)
		{
			var multiple_results_1 = this.ExecuteMultipleResults($@"declare @return_value int; 
					exec @return_value = HumanResources.uspUpdateEmployeeHireInfo {{0}}, {{1}}, {{2}}, {{3}}, {{4}}, {{5}}, {{6}}; 
					select @return_value as ReturnValue;", EmployeeID, Title, HireDate, RateChangeDate, Rate, PayFrequency, CurrentFlag);
			var final_result_1 = multiple_results_1.ReadResults(res => new HumanResources_uspUpdateEmployeeHireInfoMultipleResults()
			{
				ReturnValue = res.GetSequence<int>().Single(),
			});
			return final_result_1;
		}

		/// <param name="EmployeeID">Int</param>
		/// <param name="ManagerID">Int</param>
		/// <param name="LoginID">NVarChar(256)</param>
		/// <param name="Title">NVarChar(50)</param>
		/// <param name="HireDate">DateTime</param>
		/// <param name="CurrentFlag">Bit</param>
		/// <returns>MultipleResults from stored procedure</returns>
		public HumanResources_uspUpdateEmployeeLoginMultipleResults HumanResources_uspUpdateEmployeeLogin(
			int? EmployeeID, 
			int? ManagerID, 
			string LoginID, 
			string Title, 
			DateTime? HireDate, 
			bool? CurrentFlag)
		{
			var multiple_results_1 = this.ExecuteMultipleResults($@"declare @return_value int; 
					exec @return_value = HumanResources.uspUpdateEmployeeLogin {{0}}, {{1}}, {{2}}, {{3}}, {{4}}, {{5}}; 
					select @return_value as ReturnValue;", EmployeeID, ManagerID, LoginID, Title, HireDate, CurrentFlag);
			var final_result_1 = multiple_results_1.ReadResults(res => new HumanResources_uspUpdateEmployeeLoginMultipleResults()
			{
				ReturnValue = res.GetSequence<int>().Single(),
			});
			return final_result_1;
		}

		/// <param name="EmployeeID">Int</param>
		/// <param name="NationalIDNumber">NVarChar(15)</param>
		/// <param name="BirthDate">DateTime</param>
		/// <param name="MaritalStatus">NChar(1)</param>
		/// <param name="Gender">NChar(1)</param>
		/// <returns>MultipleResults from stored procedure</returns>
		public HumanResources_uspUpdateEmployeePersonalInfoMultipleResults HumanResources_uspUpdateEmployeePersonalInfo(
			int? EmployeeID, 
			string NationalIDNumber, 
			DateTime? BirthDate, 
			string MaritalStatus, 
			string Gender)
		{
			var multiple_results_1 = this.ExecuteMultipleResults($@"declare @return_value int; 
					exec @return_value = HumanResources.uspUpdateEmployeePersonalInfo {{0}}, {{1}}, {{2}}, {{3}}, {{4}}; 
					select @return_value as ReturnValue;", EmployeeID, NationalIDNumber, BirthDate, MaritalStatus, Gender);
			var final_result_1 = multiple_results_1.ReadResults(res => new HumanResources_uspUpdateEmployeePersonalInfoMultipleResults()
			{
				ReturnValue = res.GetSequence<int>().Single(),
			});
			return final_result_1;
		}


		#endregion Context database functions

		#region OnModelCreating

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			this.Map_Person_Address(modelBuilder);
			this.Customize_Person_Address(modelBuilder);

			this.Map_Person_AddressType(modelBuilder);
			this.Customize_Person_AddressType(modelBuilder);

			this.Map_AWBuildVersion(modelBuilder);
			this.Customize_AWBuildVersion(modelBuilder);

			this.Map_Production_BillOfMaterials(modelBuilder);
			this.Customize_Production_BillOfMaterials(modelBuilder);

			this.Map_Person_Contact(modelBuilder);
			this.Customize_Person_Contact(modelBuilder);

			this.Map_Sales_ContactCreditCard(modelBuilder);
			this.Customize_Sales_ContactCreditCard(modelBuilder);

			this.Map_Person_ContactType(modelBuilder);
			this.Customize_Person_ContactType(modelBuilder);

			this.Map_Person_CountryRegion(modelBuilder);
			this.Customize_Person_CountryRegion(modelBuilder);

			this.Map_Sales_CountryRegionCurrency(modelBuilder);
			this.Customize_Sales_CountryRegionCurrency(modelBuilder);

			this.Map_Sales_CreditCard(modelBuilder);
			this.Customize_Sales_CreditCard(modelBuilder);

			this.Map_Production_Culture(modelBuilder);
			this.Customize_Production_Culture(modelBuilder);

			this.Map_Sales_Currency(modelBuilder);
			this.Customize_Sales_Currency(modelBuilder);

			this.Map_Sales_CurrencyRate(modelBuilder);
			this.Customize_Sales_CurrencyRate(modelBuilder);

			this.Map_Sales_Customer(modelBuilder);
			this.Customize_Sales_Customer(modelBuilder);

			this.Map_Sales_CustomerAddress(modelBuilder);
			this.Customize_Sales_CustomerAddress(modelBuilder);

			this.Map_DatabaseLog(modelBuilder);
			this.Customize_DatabaseLog(modelBuilder);

			this.Map_HumanResources_Department(modelBuilder);
			this.Customize_HumanResources_Department(modelBuilder);

			this.Map_Production_Document(modelBuilder);
			this.Customize_Production_Document(modelBuilder);

			this.Map_HumanResources_Employee(modelBuilder);
			this.Customize_HumanResources_Employee(modelBuilder);

			this.Map_HumanResources_EmployeeAddress(modelBuilder);
			this.Customize_HumanResources_EmployeeAddress(modelBuilder);

			this.Map_HumanResources_EmployeeDepartmentHistory(modelBuilder);
			this.Customize_HumanResources_EmployeeDepartmentHistory(modelBuilder);

			this.Map_HumanResources_EmployeePayHistory(modelBuilder);
			this.Customize_HumanResources_EmployeePayHistory(modelBuilder);

			this.Map_ErrorLog(modelBuilder);
			this.Customize_ErrorLog(modelBuilder);

			this.Map_Production_Illustration(modelBuilder);
			this.Customize_Production_Illustration(modelBuilder);

			this.Map_Sales_Individual(modelBuilder);
			this.Customize_Sales_Individual(modelBuilder);

			this.Map_HumanResources_JobCandidate(modelBuilder);
			this.Customize_HumanResources_JobCandidate(modelBuilder);

			this.Map_Production_Location(modelBuilder);
			this.Customize_Production_Location(modelBuilder);

			this.Map_Production_Product(modelBuilder);
			this.Customize_Production_Product(modelBuilder);

			this.Map_Production_ProductCategory(modelBuilder);
			this.Customize_Production_ProductCategory(modelBuilder);

			this.Map_Production_ProductCostHistory(modelBuilder);
			this.Customize_Production_ProductCostHistory(modelBuilder);

			this.Map_Production_ProductDescription(modelBuilder);
			this.Customize_Production_ProductDescription(modelBuilder);

			this.Map_Production_ProductDocument(modelBuilder);
			this.Customize_Production_ProductDocument(modelBuilder);

			this.Map_Production_ProductInventory(modelBuilder);
			this.Customize_Production_ProductInventory(modelBuilder);

			this.Map_Production_ProductListPriceHistory(modelBuilder);
			this.Customize_Production_ProductListPriceHistory(modelBuilder);

			this.Map_Production_ProductModel(modelBuilder);
			this.Customize_Production_ProductModel(modelBuilder);

			this.Map_Production_ProductModelIllustration(modelBuilder);
			this.Customize_Production_ProductModelIllustration(modelBuilder);

			this.Map_Production_ProductModelProductDescriptionCulture(modelBuilder);
			this.Customize_Production_ProductModelProductDescriptionCulture(modelBuilder);

			this.Map_Production_ProductPhoto(modelBuilder);
			this.Customize_Production_ProductPhoto(modelBuilder);

			this.Map_Production_ProductProductPhoto(modelBuilder);
			this.Customize_Production_ProductProductPhoto(modelBuilder);

			this.Map_Production_ProductReview(modelBuilder);
			this.Customize_Production_ProductReview(modelBuilder);

			this.Map_Production_ProductSubcategory(modelBuilder);
			this.Customize_Production_ProductSubcategory(modelBuilder);

			this.Map_Purchasing_ProductVendor(modelBuilder);
			this.Customize_Purchasing_ProductVendor(modelBuilder);

			this.Map_Purchasing_PurchaseOrderDetail(modelBuilder);
			this.Customize_Purchasing_PurchaseOrderDetail(modelBuilder);

			this.Map_Purchasing_PurchaseOrderHeader(modelBuilder);
			this.Customize_Purchasing_PurchaseOrderHeader(modelBuilder);

			this.Map_Sales_SalesOrderDetail(modelBuilder);
			this.Customize_Sales_SalesOrderDetail(modelBuilder);

			this.Map_Sales_SalesOrderHeader(modelBuilder);
			this.Customize_Sales_SalesOrderHeader(modelBuilder);

			this.Map_Sales_SalesOrderHeaderSalesReason(modelBuilder);
			this.Customize_Sales_SalesOrderHeaderSalesReason(modelBuilder);

			this.Map_Sales_SalesPerson(modelBuilder);
			this.Customize_Sales_SalesPerson(modelBuilder);

			this.Map_Sales_SalesPersonQuotaHistory(modelBuilder);
			this.Customize_Sales_SalesPersonQuotaHistory(modelBuilder);

			this.Map_Sales_SalesReason(modelBuilder);
			this.Customize_Sales_SalesReason(modelBuilder);

			this.Map_Sales_SalesTaxRate(modelBuilder);
			this.Customize_Sales_SalesTaxRate(modelBuilder);

			this.Map_Sales_SalesTerritory(modelBuilder);
			this.Customize_Sales_SalesTerritory(modelBuilder);

			this.Map_Sales_SalesTerritoryHistory(modelBuilder);
			this.Customize_Sales_SalesTerritoryHistory(modelBuilder);

			this.Map_Production_ScrapReason(modelBuilder);
			this.Customize_Production_ScrapReason(modelBuilder);

			this.Map_HumanResources_Shift(modelBuilder);
			this.Customize_HumanResources_Shift(modelBuilder);

			this.Map_Purchasing_ShipMethod(modelBuilder);
			this.Customize_Purchasing_ShipMethod(modelBuilder);

			this.Map_Sales_ShoppingCartItem(modelBuilder);
			this.Customize_Sales_ShoppingCartItem(modelBuilder);

			this.Map_Sales_SpecialOffer(modelBuilder);
			this.Customize_Sales_SpecialOffer(modelBuilder);

			this.Map_Sales_SpecialOfferProduct(modelBuilder);
			this.Customize_Sales_SpecialOfferProduct(modelBuilder);

			this.Map_Person_StateProvince(modelBuilder);
			this.Customize_Person_StateProvince(modelBuilder);

			this.Map_Sales_Store(modelBuilder);
			this.Customize_Sales_Store(modelBuilder);

			this.Map_Sales_StoreContact(modelBuilder);
			this.Customize_Sales_StoreContact(modelBuilder);

			this.Map_Production_TransactionHistory(modelBuilder);
			this.Customize_Production_TransactionHistory(modelBuilder);

			this.Map_Production_TransactionHistoryArchive(modelBuilder);
			this.Customize_Production_TransactionHistoryArchive(modelBuilder);

			this.Map_Production_UnitMeasure(modelBuilder);
			this.Customize_Production_UnitMeasure(modelBuilder);

			this.Map_Person_vAdditionalContactInfo(modelBuilder);
			this.Customize_Person_vAdditionalContactInfo(modelBuilder);

			this.Map_HumanResources_vEmployee(modelBuilder);
			this.Customize_HumanResources_vEmployee(modelBuilder);

			this.Map_HumanResources_vEmployeeDepartment(modelBuilder);
			this.Customize_HumanResources_vEmployeeDepartment(modelBuilder);

			this.Map_HumanResources_vEmployeeDepartmentHistory(modelBuilder);
			this.Customize_HumanResources_vEmployeeDepartmentHistory(modelBuilder);

			this.Map_Purchasing_Vendor(modelBuilder);
			this.Customize_Purchasing_Vendor(modelBuilder);

			this.Map_Purchasing_VendorAddress(modelBuilder);
			this.Customize_Purchasing_VendorAddress(modelBuilder);

			this.Map_Purchasing_VendorContact(modelBuilder);
			this.Customize_Purchasing_VendorContact(modelBuilder);

			this.Map_Sales_vIndividualCustomer(modelBuilder);
			this.Customize_Sales_vIndividualCustomer(modelBuilder);

			this.Map_Sales_vIndividualDemographics(modelBuilder);
			this.Customize_Sales_vIndividualDemographics(modelBuilder);

			this.Map_HumanResources_vJobCandidate(modelBuilder);
			this.Customize_HumanResources_vJobCandidate(modelBuilder);

			this.Map_HumanResources_vJobCandidateEducation(modelBuilder);
			this.Customize_HumanResources_vJobCandidateEducation(modelBuilder);

			this.Map_HumanResources_vJobCandidateEmployment(modelBuilder);
			this.Customize_HumanResources_vJobCandidateEmployment(modelBuilder);

			this.Map_Production_vProductAndDescription(modelBuilder);
			this.Customize_Production_vProductAndDescription(modelBuilder);

			this.Map_Production_vProductModelCatalogDescription(modelBuilder);
			this.Customize_Production_vProductModelCatalogDescription(modelBuilder);

			this.Map_Production_vProductModelInstructions(modelBuilder);
			this.Customize_Production_vProductModelInstructions(modelBuilder);

			this.Map_Sales_vSalesPerson(modelBuilder);
			this.Customize_Sales_vSalesPerson(modelBuilder);

			this.Map_Sales_vSalesPersonSalesByFiscalYears(modelBuilder);
			this.Customize_Sales_vSalesPersonSalesByFiscalYears(modelBuilder);

			this.Map_Person_vStateProvinceCountryRegion(modelBuilder);
			this.Customize_Person_vStateProvinceCountryRegion(modelBuilder);

			this.Map_Sales_vStoreWithDemographics(modelBuilder);
			this.Customize_Sales_vStoreWithDemographics(modelBuilder);

			this.Map_Purchasing_vVendor(modelBuilder);
			this.Customize_Purchasing_vVendor(modelBuilder);

			this.Map_Production_WorkOrder(modelBuilder);
			this.Customize_Production_WorkOrder(modelBuilder);

			this.Map_Production_WorkOrderRouting(modelBuilder);
			this.Customize_Production_WorkOrderRouting(modelBuilder);

			RelationshipsMapping(modelBuilder);
			CustomizeMapping(ref modelBuilder);
		}

		#endregion

		#region TablesMappingDetails

		#region Person_Address
		private void Map_Person_Address(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Person_Address>().ToTable("Address", "Person");
			modelBuilder.Entity<Person_Address>().HasKey(x=>x.AddressID);
			modelBuilder.Entity<Person_Address>().Property(x=>x.AddressID).HasColumnName("AddressID").HasColumnType("Int").IsRequired().ValueGeneratedOnAdd();
			modelBuilder.Entity<Person_Address>().Property(x=>x.AddressLine1).HasColumnName("AddressLine1").HasColumnType("NVarChar(60)").IsRequired().ValueGeneratedNever().HasMaxLength(60);
			modelBuilder.Entity<Person_Address>().Property(x=>x.AddressLine2).HasColumnName("AddressLine2").HasColumnType("NVarChar(60)").ValueGeneratedNever().HasMaxLength(60);
			modelBuilder.Entity<Person_Address>().Property(x=>x.City).HasColumnName("City").HasColumnType("NVarChar(30)").IsRequired().ValueGeneratedNever().HasMaxLength(30);
			modelBuilder.Entity<Person_Address>().Property(x=>x.StateProvinceID).HasColumnName("StateProvinceID").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Person_Address>().Property(x=>x.PostalCode).HasColumnName("PostalCode").HasColumnType("NVarChar(15)").IsRequired().ValueGeneratedNever().HasMaxLength(15);
			modelBuilder.Entity<Person_Address>().Property(x=>x.rowguid).HasColumnName("rowguid").HasColumnType("UniqueIdentifier").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Person_Address>().Property(x=>x.ModifiedDate).HasColumnName("ModifiedDate").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
		}

		partial void Customize_Person_Address(ModelBuilder modelBuilder);
		#endregion

		#region Person_AddressType
		private void Map_Person_AddressType(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Person_AddressType>().ToTable("AddressType", "Person");
			modelBuilder.Entity<Person_AddressType>().HasKey(x=>x.AddressTypeID);
			modelBuilder.Entity<Person_AddressType>().Property(x=>x.AddressTypeID).HasColumnName("AddressTypeID").HasColumnType("Int").IsRequired().ValueGeneratedOnAdd();
			modelBuilder.Entity<Person_AddressType>().Property(x=>x.Name).HasColumnName("Name").HasColumnType("NVarChar(50)").IsRequired().ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<Person_AddressType>().Property(x=>x.rowguid).HasColumnName("rowguid").HasColumnType("UniqueIdentifier").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Person_AddressType>().Property(x=>x.ModifiedDate).HasColumnName("ModifiedDate").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
		}

		partial void Customize_Person_AddressType(ModelBuilder modelBuilder);
		#endregion

		#region AWBuildVersion
		private void Map_AWBuildVersion(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<AWBuildVersion>().ToTable("AWBuildVersion", "dbo");
			modelBuilder.Entity<AWBuildVersion>().HasKey(x=>x.SystemInformationID);
			modelBuilder.Entity<AWBuildVersion>().Property(x=>x.SystemInformationID).HasColumnName("SystemInformationID").HasColumnType("TinyInt").IsRequired().ValueGeneratedOnAdd();
			modelBuilder.Entity<AWBuildVersion>().Property(x=>x.DatabaseVersion).HasColumnName("DatabaseVersion").HasColumnType("NVarChar(25)").IsRequired().ValueGeneratedNever().HasMaxLength(25);
			modelBuilder.Entity<AWBuildVersion>().Property(x=>x.VersionDate).HasColumnName("VersionDate").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<AWBuildVersion>().Property(x=>x.ModifiedDate).HasColumnName("ModifiedDate").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
		}

		partial void Customize_AWBuildVersion(ModelBuilder modelBuilder);
		#endregion

		#region Production_BillOfMaterials
		private void Map_Production_BillOfMaterials(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Production_BillOfMaterials>().ToTable("BillOfMaterials", "Production");
			modelBuilder.Entity<Production_BillOfMaterials>().HasKey(x=>x.BillOfMaterialsID);
			modelBuilder.Entity<Production_BillOfMaterials>().Property(x=>x.BillOfMaterialsID).HasColumnName("BillOfMaterialsID").HasColumnType("Int").IsRequired().ValueGeneratedOnAdd();
			modelBuilder.Entity<Production_BillOfMaterials>().Property(x=>x.ProductAssemblyID).HasColumnName("ProductAssemblyID").HasColumnType("Int").ValueGeneratedNever();
			modelBuilder.Entity<Production_BillOfMaterials>().Property(x=>x.ComponentID).HasColumnName("ComponentID").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Production_BillOfMaterials>().Property(x=>x.StartDate).HasColumnName("StartDate").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Production_BillOfMaterials>().Property(x=>x.EndDate).HasColumnName("EndDate").HasColumnType("DateTime").ValueGeneratedNever();
			modelBuilder.Entity<Production_BillOfMaterials>().Property(x=>x.UnitMeasureCode).HasColumnName("UnitMeasureCode").HasColumnType("NChar(3)").IsRequired().ValueGeneratedNever().HasMaxLength(3);
			modelBuilder.Entity<Production_BillOfMaterials>().Property(x=>x.BOMLevel).HasColumnName("BOMLevel").HasColumnType("SmallInt").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Production_BillOfMaterials>().Property(x=>x.PerAssemblyQty).HasColumnName("PerAssemblyQty").HasColumnType("Decimal(8,2)").IsRequired().ValueGeneratedNever().HasMaxLength(8);
			modelBuilder.Entity<Production_BillOfMaterials>().Property(x=>x.ModifiedDate).HasColumnName("ModifiedDate").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
		}

		partial void Customize_Production_BillOfMaterials(ModelBuilder modelBuilder);
		#endregion

		#region Person_Contact
		private void Map_Person_Contact(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Person_Contact>().ToTable("Contact", "Person");
			modelBuilder.Entity<Person_Contact>().HasKey(x=>x.ContactID);
			modelBuilder.Entity<Person_Contact>().Property(x=>x.ContactID).HasColumnName("ContactID").HasColumnType("Int").IsRequired().ValueGeneratedOnAdd();
			modelBuilder.Entity<Person_Contact>().Property(x=>x.NameStyle).HasColumnName("NameStyle").HasColumnType("Bit").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Person_Contact>().Property(x=>x.Title).HasColumnName("Title").HasColumnType("NVarChar(8)").ValueGeneratedNever().HasMaxLength(8);
			modelBuilder.Entity<Person_Contact>().Property(x=>x.FirstName).HasColumnName("FirstName").HasColumnType("NVarChar(50)").IsRequired().ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<Person_Contact>().Property(x=>x.MiddleName).HasColumnName("MiddleName").HasColumnType("NVarChar(50)").ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<Person_Contact>().Property(x=>x.LastName).HasColumnName("LastName").HasColumnType("NVarChar(50)").IsRequired().ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<Person_Contact>().Property(x=>x.Suffix).HasColumnName("Suffix").HasColumnType("NVarChar(10)").ValueGeneratedNever().HasMaxLength(10);
			modelBuilder.Entity<Person_Contact>().Property(x=>x.EmailAddress).HasColumnName("EmailAddress").HasColumnType("NVarChar(50)").ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<Person_Contact>().Property(x=>x.EmailPromotion).HasColumnName("EmailPromotion").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Person_Contact>().Property(x=>x.Phone).HasColumnName("Phone").HasColumnType("NVarChar(25)").ValueGeneratedNever().HasMaxLength(25);
			modelBuilder.Entity<Person_Contact>().Property(x=>x.PasswordHash).HasColumnName("PasswordHash").HasColumnType("VarChar(128)").IsRequired().ValueGeneratedNever().HasMaxLength(128);
			modelBuilder.Entity<Person_Contact>().Property(x=>x.PasswordSalt).HasColumnName("PasswordSalt").HasColumnType("VarChar(10)").IsRequired().ValueGeneratedNever().HasMaxLength(10);
			modelBuilder.Entity<Person_Contact>().Property(x=>x.AdditionalContactInfo).HasColumnName("AdditionalContactInfo").HasColumnType("Xml").ValueGeneratedNever();
			modelBuilder.Entity<Person_Contact>().Property(x=>x.rowguid).HasColumnName("rowguid").HasColumnType("UniqueIdentifier").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Person_Contact>().Property(x=>x.ModifiedDate).HasColumnName("ModifiedDate").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
		}

		partial void Customize_Person_Contact(ModelBuilder modelBuilder);
		#endregion

		#region Sales_ContactCreditCard
		private void Map_Sales_ContactCreditCard(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Sales_ContactCreditCard>().ToTable("ContactCreditCard", "Sales");
			modelBuilder.Entity<Sales_ContactCreditCard>().HasKey("ContactID", "CreditCardID");
			modelBuilder.Entity<Sales_ContactCreditCard>().Property(x=>x.ContactID).HasColumnName("ContactID").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Sales_ContactCreditCard>().Property(x=>x.CreditCardID).HasColumnName("CreditCardID").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Sales_ContactCreditCard>().Property(x=>x.ModifiedDate).HasColumnName("ModifiedDate").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
		}

		partial void Customize_Sales_ContactCreditCard(ModelBuilder modelBuilder);
		#endregion

		#region Person_ContactType
		private void Map_Person_ContactType(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Person_ContactType>().ToTable("ContactType", "Person");
			modelBuilder.Entity<Person_ContactType>().HasKey(x=>x.ContactTypeID);
			modelBuilder.Entity<Person_ContactType>().Property(x=>x.ContactTypeID).HasColumnName("ContactTypeID").HasColumnType("Int").IsRequired().ValueGeneratedOnAdd();
			modelBuilder.Entity<Person_ContactType>().Property(x=>x.Name).HasColumnName("Name").HasColumnType("NVarChar(50)").IsRequired().ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<Person_ContactType>().Property(x=>x.ModifiedDate).HasColumnName("ModifiedDate").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
		}

		partial void Customize_Person_ContactType(ModelBuilder modelBuilder);
		#endregion

		#region Person_CountryRegion
		private void Map_Person_CountryRegion(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Person_CountryRegion>().ToTable("CountryRegion", "Person");
			modelBuilder.Entity<Person_CountryRegion>().HasKey(x=>x.CountryRegionCode);
			modelBuilder.Entity<Person_CountryRegion>().Property(x=>x.CountryRegionCode).HasColumnName("CountryRegionCode").HasColumnType("NVarChar(3)").IsRequired().ValueGeneratedNever().HasMaxLength(3);
			modelBuilder.Entity<Person_CountryRegion>().Property(x=>x.Name).HasColumnName("Name").HasColumnType("NVarChar(50)").IsRequired().ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<Person_CountryRegion>().Property(x=>x.ModifiedDate).HasColumnName("ModifiedDate").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
		}

		partial void Customize_Person_CountryRegion(ModelBuilder modelBuilder);
		#endregion

		#region Sales_CountryRegionCurrency
		private void Map_Sales_CountryRegionCurrency(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Sales_CountryRegionCurrency>().ToTable("CountryRegionCurrency", "Sales");
			modelBuilder.Entity<Sales_CountryRegionCurrency>().HasKey("CountryRegionCode", "CurrencyCode");
			modelBuilder.Entity<Sales_CountryRegionCurrency>().Property(x=>x.CountryRegionCode).HasColumnName("CountryRegionCode").HasColumnType("NVarChar(3)").IsRequired().ValueGeneratedNever().HasMaxLength(3);
			modelBuilder.Entity<Sales_CountryRegionCurrency>().Property(x=>x.CurrencyCode).HasColumnName("CurrencyCode").HasColumnType("NChar(3)").IsRequired().ValueGeneratedNever().HasMaxLength(3);
			modelBuilder.Entity<Sales_CountryRegionCurrency>().Property(x=>x.ModifiedDate).HasColumnName("ModifiedDate").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
		}

		partial void Customize_Sales_CountryRegionCurrency(ModelBuilder modelBuilder);
		#endregion

		#region Sales_CreditCard
		private void Map_Sales_CreditCard(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Sales_CreditCard>().ToTable("CreditCard", "Sales");
			modelBuilder.Entity<Sales_CreditCard>().HasKey(x=>x.CreditCardID);
			modelBuilder.Entity<Sales_CreditCard>().Property(x=>x.CreditCardID).HasColumnName("CreditCardID").HasColumnType("Int").IsRequired().ValueGeneratedOnAdd();
			modelBuilder.Entity<Sales_CreditCard>().Property(x=>x.CardType).HasColumnName("CardType").HasColumnType("NVarChar(50)").IsRequired().ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<Sales_CreditCard>().Property(x=>x.CardNumber).HasColumnName("CardNumber").HasColumnType("NVarChar(25)").IsRequired().ValueGeneratedNever().HasMaxLength(25);
			modelBuilder.Entity<Sales_CreditCard>().Property(x=>x.ExpMonth).HasColumnName("ExpMonth").HasColumnType("TinyInt").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Sales_CreditCard>().Property(x=>x.ExpYear).HasColumnName("ExpYear").HasColumnType("SmallInt").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Sales_CreditCard>().Property(x=>x.ModifiedDate).HasColumnName("ModifiedDate").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
		}

		partial void Customize_Sales_CreditCard(ModelBuilder modelBuilder);
		#endregion

		#region Production_Culture
		private void Map_Production_Culture(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Production_Culture>().ToTable("Culture", "Production");
			modelBuilder.Entity<Production_Culture>().HasKey(x=>x.CultureID);
			modelBuilder.Entity<Production_Culture>().Property(x=>x.CultureID).HasColumnName("CultureID").HasColumnType("NChar(6)").IsRequired().ValueGeneratedNever().HasMaxLength(6);
			modelBuilder.Entity<Production_Culture>().Property(x=>x.Name).HasColumnName("Name").HasColumnType("NVarChar(50)").IsRequired().ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<Production_Culture>().Property(x=>x.ModifiedDate).HasColumnName("ModifiedDate").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
		}

		partial void Customize_Production_Culture(ModelBuilder modelBuilder);
		#endregion

		#region Sales_Currency
		private void Map_Sales_Currency(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Sales_Currency>().ToTable("Currency", "Sales");
			modelBuilder.Entity<Sales_Currency>().HasKey(x=>x.CurrencyCode);
			modelBuilder.Entity<Sales_Currency>().Property(x=>x.CurrencyCode).HasColumnName("CurrencyCode").HasColumnType("NChar(3)").IsRequired().ValueGeneratedNever().HasMaxLength(3);
			modelBuilder.Entity<Sales_Currency>().Property(x=>x.Name).HasColumnName("Name").HasColumnType("NVarChar(50)").IsRequired().ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<Sales_Currency>().Property(x=>x.ModifiedDate).HasColumnName("ModifiedDate").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
		}

		partial void Customize_Sales_Currency(ModelBuilder modelBuilder);
		#endregion

		#region Sales_CurrencyRate
		private void Map_Sales_CurrencyRate(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Sales_CurrencyRate>().ToTable("CurrencyRate", "Sales");
			modelBuilder.Entity<Sales_CurrencyRate>().HasKey(x=>x.CurrencyRateID);
			modelBuilder.Entity<Sales_CurrencyRate>().Property(x=>x.CurrencyRateID).HasColumnName("CurrencyRateID").HasColumnType("Int").IsRequired().ValueGeneratedOnAdd();
			modelBuilder.Entity<Sales_CurrencyRate>().Property(x=>x.CurrencyRateDate).HasColumnName("CurrencyRateDate").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Sales_CurrencyRate>().Property(x=>x.FromCurrencyCode).HasColumnName("FromCurrencyCode").HasColumnType("NChar(3)").IsRequired().ValueGeneratedNever().HasMaxLength(3);
			modelBuilder.Entity<Sales_CurrencyRate>().Property(x=>x.ToCurrencyCode).HasColumnName("ToCurrencyCode").HasColumnType("NChar(3)").IsRequired().ValueGeneratedNever().HasMaxLength(3);
			modelBuilder.Entity<Sales_CurrencyRate>().Property(x=>x.AverageRate).HasColumnName("AverageRate").HasColumnType("Money").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Sales_CurrencyRate>().Property(x=>x.EndOfDayRate).HasColumnName("EndOfDayRate").HasColumnType("Money").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Sales_CurrencyRate>().Property(x=>x.ModifiedDate).HasColumnName("ModifiedDate").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
		}

		partial void Customize_Sales_CurrencyRate(ModelBuilder modelBuilder);
		#endregion

		#region Sales_Customer
		private void Map_Sales_Customer(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Sales_Customer>().ToTable("Customer", "Sales");
			modelBuilder.Entity<Sales_Customer>().HasKey(x=>x.CustomerID);
			modelBuilder.Entity<Sales_Customer>().Property(x=>x.CustomerID).HasColumnName("CustomerID").HasColumnType("Int").IsRequired().ValueGeneratedOnAdd();
			modelBuilder.Entity<Sales_Customer>().Property(x=>x.TerritoryID).HasColumnName("TerritoryID").HasColumnType("Int").ValueGeneratedNever();
			modelBuilder.Entity<Sales_Customer>().Property(x=>x.AccountNumber).HasColumnName("AccountNumber").HasColumnType("VarChar(10)").IsRequired().ValueGeneratedNever().HasMaxLength(10);
			modelBuilder.Entity<Sales_Customer>().Property(x=>x.CustomerType).HasColumnName("CustomerType").HasColumnType("NChar(1)").IsRequired().ValueGeneratedNever().HasMaxLength(1);
			modelBuilder.Entity<Sales_Customer>().Property(x=>x.rowguid).HasColumnName("rowguid").HasColumnType("UniqueIdentifier").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Sales_Customer>().Property(x=>x.ModifiedDate).HasColumnName("ModifiedDate").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
		}

		partial void Customize_Sales_Customer(ModelBuilder modelBuilder);
		#endregion

		#region Sales_CustomerAddress
		private void Map_Sales_CustomerAddress(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Sales_CustomerAddress>().ToTable("CustomerAddress", "Sales");
			modelBuilder.Entity<Sales_CustomerAddress>().HasKey("CustomerID", "AddressID");
			modelBuilder.Entity<Sales_CustomerAddress>().Property(x=>x.CustomerID).HasColumnName("CustomerID").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Sales_CustomerAddress>().Property(x=>x.AddressID).HasColumnName("AddressID").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Sales_CustomerAddress>().Property(x=>x.AddressTypeID).HasColumnName("AddressTypeID").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Sales_CustomerAddress>().Property(x=>x.rowguid).HasColumnName("rowguid").HasColumnType("UniqueIdentifier").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Sales_CustomerAddress>().Property(x=>x.ModifiedDate).HasColumnName("ModifiedDate").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
		}

		partial void Customize_Sales_CustomerAddress(ModelBuilder modelBuilder);
		#endregion

		#region DatabaseLog
		private void Map_DatabaseLog(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<DatabaseLog>().ToTable("DatabaseLog", "dbo");
			modelBuilder.Entity<DatabaseLog>().HasKey(x=>x.DatabaseLogID);
			modelBuilder.Entity<DatabaseLog>().Property(x=>x.DatabaseLogID).HasColumnName("DatabaseLogID").HasColumnType("Int").IsRequired().ValueGeneratedOnAdd();
			modelBuilder.Entity<DatabaseLog>().Property(x=>x.PostTime).HasColumnName("PostTime").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<DatabaseLog>().Property(x=>x.DatabaseUser).HasColumnName("DatabaseUser").HasColumnType("NVarChar(128)").IsRequired().ValueGeneratedNever().HasMaxLength(128);
			modelBuilder.Entity<DatabaseLog>().Property(x=>x.Event).HasColumnName("Event").HasColumnType("NVarChar(128)").IsRequired().ValueGeneratedNever().HasMaxLength(128);
			modelBuilder.Entity<DatabaseLog>().Property(x=>x.Schema).HasColumnName("Schema").HasColumnType("NVarChar(128)").ValueGeneratedNever().HasMaxLength(128);
			modelBuilder.Entity<DatabaseLog>().Property(x=>x.Object).HasColumnName("Object").HasColumnType("NVarChar(128)").ValueGeneratedNever().HasMaxLength(128);
			modelBuilder.Entity<DatabaseLog>().Property(x=>x.TSQL).HasColumnName("TSQL").HasColumnType("NVarChar(MAX)").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<DatabaseLog>().Property(x=>x.XmlEvent).HasColumnName("XmlEvent").HasColumnType("Xml").IsRequired().ValueGeneratedNever();
		}

		partial void Customize_DatabaseLog(ModelBuilder modelBuilder);
		#endregion

		#region HumanResources_Department
		private void Map_HumanResources_Department(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<HumanResources_Department>().ToTable("Department", "HumanResources");
			modelBuilder.Entity<HumanResources_Department>().HasKey(x=>x.DepartmentID);
			modelBuilder.Entity<HumanResources_Department>().Property(x=>x.DepartmentID).HasColumnName("DepartmentID").HasColumnType("SmallInt").IsRequired().ValueGeneratedOnAdd();
			modelBuilder.Entity<HumanResources_Department>().Property(x=>x.Name).HasColumnName("Name").HasColumnType("NVarChar(50)").IsRequired().ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<HumanResources_Department>().Property(x=>x.GroupName).HasColumnName("GroupName").HasColumnType("NVarChar(50)").IsRequired().ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<HumanResources_Department>().Property(x=>x.ModifiedDate).HasColumnName("ModifiedDate").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
		}

		partial void Customize_HumanResources_Department(ModelBuilder modelBuilder);
		#endregion

		#region Production_Document
		private void Map_Production_Document(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Production_Document>().ToTable("Document", "Production");
			modelBuilder.Entity<Production_Document>().HasKey(x=>x.DocumentID);
			modelBuilder.Entity<Production_Document>().Property(x=>x.DocumentID).HasColumnName("DocumentID").HasColumnType("Int").IsRequired().ValueGeneratedOnAdd();
			modelBuilder.Entity<Production_Document>().Property(x=>x.Title).HasColumnName("Title").HasColumnType("NVarChar(50)").IsRequired().ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<Production_Document>().Property(x=>x.FileName).HasColumnName("FileName").HasColumnType("NVarChar(400)").IsRequired().ValueGeneratedNever().HasMaxLength(400);
			modelBuilder.Entity<Production_Document>().Property(x=>x.FileExtension).HasColumnName("FileExtension").HasColumnType("NVarChar(8)").IsRequired().ValueGeneratedNever().HasMaxLength(8);
			modelBuilder.Entity<Production_Document>().Property(x=>x.Revision).HasColumnName("Revision").HasColumnType("NChar(5)").IsRequired().ValueGeneratedNever().HasMaxLength(5);
			modelBuilder.Entity<Production_Document>().Property(x=>x.ChangeNumber).HasColumnName("ChangeNumber").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Production_Document>().Property(x=>x.Status).HasColumnName("Status").HasColumnType("TinyInt").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Production_Document>().Property(x=>x.DocumentSummary).HasColumnName("DocumentSummary").HasColumnType("NVarChar(MAX)").ValueGeneratedNever();
			modelBuilder.Entity<Production_Document>().Property(x=>x.Document).HasColumnName("Document").HasColumnType("VarBinary(MAX)").ValueGeneratedNever();
			modelBuilder.Entity<Production_Document>().Property(x=>x.ModifiedDate).HasColumnName("ModifiedDate").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
		}

		partial void Customize_Production_Document(ModelBuilder modelBuilder);
		#endregion

		#region HumanResources_Employee
		private void Map_HumanResources_Employee(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<HumanResources_Employee>().ToTable("Employee", "HumanResources");
			modelBuilder.Entity<HumanResources_Employee>().HasKey(x=>x.EmployeeID);
			modelBuilder.Entity<HumanResources_Employee>().Property(x=>x.EmployeeID).HasColumnName("EmployeeID").HasColumnType("Int").IsRequired().ValueGeneratedOnAdd();
			modelBuilder.Entity<HumanResources_Employee>().Property(x=>x.NationalIDNumber).HasColumnName("NationalIDNumber").HasColumnType("NVarChar(15)").IsRequired().ValueGeneratedNever().HasMaxLength(15);
			modelBuilder.Entity<HumanResources_Employee>().Property(x=>x.ContactID).HasColumnName("ContactID").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<HumanResources_Employee>().Property(x=>x.LoginID).HasColumnName("LoginID").HasColumnType("NVarChar(256)").IsRequired().ValueGeneratedNever().HasMaxLength(256);
			modelBuilder.Entity<HumanResources_Employee>().Property(x=>x.ManagerID).HasColumnName("ManagerID").HasColumnType("Int").ValueGeneratedNever();
			modelBuilder.Entity<HumanResources_Employee>().Property(x=>x.Title).HasColumnName("Title").HasColumnType("NVarChar(50)").IsRequired().ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<HumanResources_Employee>().Property(x=>x.BirthDate).HasColumnName("BirthDate").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<HumanResources_Employee>().Property(x=>x.MaritalStatus).HasColumnName("MaritalStatus").HasColumnType("NChar(1)").IsRequired().ValueGeneratedNever().HasMaxLength(1);
			modelBuilder.Entity<HumanResources_Employee>().Property(x=>x.Gender).HasColumnName("Gender").HasColumnType("NChar(1)").IsRequired().ValueGeneratedNever().HasMaxLength(1);
			modelBuilder.Entity<HumanResources_Employee>().Property(x=>x.HireDate).HasColumnName("HireDate").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<HumanResources_Employee>().Property(x=>x.SalariedFlag).HasColumnName("SalariedFlag").HasColumnType("Bit").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<HumanResources_Employee>().Property(x=>x.VacationHours).HasColumnName("VacationHours").HasColumnType("SmallInt").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<HumanResources_Employee>().Property(x=>x.SickLeaveHours).HasColumnName("SickLeaveHours").HasColumnType("SmallInt").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<HumanResources_Employee>().Property(x=>x.CurrentFlag).HasColumnName("CurrentFlag").HasColumnType("Bit").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<HumanResources_Employee>().Property(x=>x.rowguid).HasColumnName("rowguid").HasColumnType("UniqueIdentifier").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<HumanResources_Employee>().Property(x=>x.ModifiedDate).HasColumnName("ModifiedDate").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
		}

		partial void Customize_HumanResources_Employee(ModelBuilder modelBuilder);
		#endregion

		#region HumanResources_EmployeeAddress
		private void Map_HumanResources_EmployeeAddress(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<HumanResources_EmployeeAddress>().ToTable("EmployeeAddress", "HumanResources");
			modelBuilder.Entity<HumanResources_EmployeeAddress>().HasKey("EmployeeID", "AddressID");
			modelBuilder.Entity<HumanResources_EmployeeAddress>().Property(x=>x.EmployeeID).HasColumnName("EmployeeID").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<HumanResources_EmployeeAddress>().Property(x=>x.AddressID).HasColumnName("AddressID").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<HumanResources_EmployeeAddress>().Property(x=>x.rowguid).HasColumnName("rowguid").HasColumnType("UniqueIdentifier").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<HumanResources_EmployeeAddress>().Property(x=>x.ModifiedDate).HasColumnName("ModifiedDate").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
		}

		partial void Customize_HumanResources_EmployeeAddress(ModelBuilder modelBuilder);
		#endregion

		#region HumanResources_EmployeeDepartmentHistory
		private void Map_HumanResources_EmployeeDepartmentHistory(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<HumanResources_EmployeeDepartmentHistory>().ToTable("EmployeeDepartmentHistory", "HumanResources");
			modelBuilder.Entity<HumanResources_EmployeeDepartmentHistory>().HasKey("EmployeeID", "DepartmentID", "ShiftID", "StartDate");
			modelBuilder.Entity<HumanResources_EmployeeDepartmentHistory>().Property(x=>x.EmployeeID).HasColumnName("EmployeeID").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<HumanResources_EmployeeDepartmentHistory>().Property(x=>x.DepartmentID).HasColumnName("DepartmentID").HasColumnType("SmallInt").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<HumanResources_EmployeeDepartmentHistory>().Property(x=>x.ShiftID).HasColumnName("ShiftID").HasColumnType("TinyInt").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<HumanResources_EmployeeDepartmentHistory>().Property(x=>x.StartDate).HasColumnName("StartDate").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<HumanResources_EmployeeDepartmentHistory>().Property(x=>x.EndDate).HasColumnName("EndDate").HasColumnType("DateTime").ValueGeneratedNever();
			modelBuilder.Entity<HumanResources_EmployeeDepartmentHistory>().Property(x=>x.ModifiedDate).HasColumnName("ModifiedDate").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
		}

		partial void Customize_HumanResources_EmployeeDepartmentHistory(ModelBuilder modelBuilder);
		#endregion

		#region HumanResources_EmployeePayHistory
		private void Map_HumanResources_EmployeePayHistory(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<HumanResources_EmployeePayHistory>().ToTable("EmployeePayHistory", "HumanResources");
			modelBuilder.Entity<HumanResources_EmployeePayHistory>().HasKey("EmployeeID", "RateChangeDate");
			modelBuilder.Entity<HumanResources_EmployeePayHistory>().Property(x=>x.EmployeeID).HasColumnName("EmployeeID").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<HumanResources_EmployeePayHistory>().Property(x=>x.RateChangeDate).HasColumnName("RateChangeDate").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<HumanResources_EmployeePayHistory>().Property(x=>x.Rate).HasColumnName("Rate").HasColumnType("Money").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<HumanResources_EmployeePayHistory>().Property(x=>x.PayFrequency).HasColumnName("PayFrequency").HasColumnType("TinyInt").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<HumanResources_EmployeePayHistory>().Property(x=>x.ModifiedDate).HasColumnName("ModifiedDate").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
		}

		partial void Customize_HumanResources_EmployeePayHistory(ModelBuilder modelBuilder);
		#endregion

		#region ErrorLog
		private void Map_ErrorLog(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<ErrorLog>().ToTable("ErrorLog", "dbo");
			modelBuilder.Entity<ErrorLog>().HasKey(x=>x.ErrorLogID);
			modelBuilder.Entity<ErrorLog>().Property(x=>x.ErrorLogID).HasColumnName("ErrorLogID").HasColumnType("Int").IsRequired().ValueGeneratedOnAdd();
			modelBuilder.Entity<ErrorLog>().Property(x=>x.ErrorTime).HasColumnName("ErrorTime").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<ErrorLog>().Property(x=>x.UserName).HasColumnName("UserName").HasColumnType("NVarChar(128)").IsRequired().ValueGeneratedNever().HasMaxLength(128);
			modelBuilder.Entity<ErrorLog>().Property(x=>x.ErrorNumber).HasColumnName("ErrorNumber").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<ErrorLog>().Property(x=>x.ErrorSeverity).HasColumnName("ErrorSeverity").HasColumnType("Int").ValueGeneratedNever();
			modelBuilder.Entity<ErrorLog>().Property(x=>x.ErrorState).HasColumnName("ErrorState").HasColumnType("Int").ValueGeneratedNever();
			modelBuilder.Entity<ErrorLog>().Property(x=>x.ErrorProcedure).HasColumnName("ErrorProcedure").HasColumnType("NVarChar(126)").ValueGeneratedNever().HasMaxLength(126);
			modelBuilder.Entity<ErrorLog>().Property(x=>x.ErrorLine).HasColumnName("ErrorLine").HasColumnType("Int").ValueGeneratedNever();
			modelBuilder.Entity<ErrorLog>().Property(x=>x.ErrorMessage).HasColumnName("ErrorMessage").HasColumnType("NVarChar(4000)").IsRequired().ValueGeneratedNever().HasMaxLength(4000);
		}

		partial void Customize_ErrorLog(ModelBuilder modelBuilder);
		#endregion

		#region Production_Illustration
		private void Map_Production_Illustration(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Production_Illustration>().ToTable("Illustration", "Production");
			modelBuilder.Entity<Production_Illustration>().HasKey(x=>x.IllustrationID);
			modelBuilder.Entity<Production_Illustration>().Property(x=>x.IllustrationID).HasColumnName("IllustrationID").HasColumnType("Int").IsRequired().ValueGeneratedOnAdd();
			modelBuilder.Entity<Production_Illustration>().Property(x=>x.Diagram).HasColumnName("Diagram").HasColumnType("Xml").ValueGeneratedNever();
			modelBuilder.Entity<Production_Illustration>().Property(x=>x.ModifiedDate).HasColumnName("ModifiedDate").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
		}

		partial void Customize_Production_Illustration(ModelBuilder modelBuilder);
		#endregion

		#region Sales_Individual
		private void Map_Sales_Individual(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Sales_Individual>().ToTable("Individual", "Sales");
			modelBuilder.Entity<Sales_Individual>().HasKey(x=>x.CustomerID);
			modelBuilder.Entity<Sales_Individual>().Property(x=>x.CustomerID).HasColumnName("CustomerID").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Sales_Individual>().Property(x=>x.ContactID).HasColumnName("ContactID").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Sales_Individual>().Property(x=>x.Demographics).HasColumnName("Demographics").HasColumnType("Xml").ValueGeneratedNever();
			modelBuilder.Entity<Sales_Individual>().Property(x=>x.ModifiedDate).HasColumnName("ModifiedDate").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
		}

		partial void Customize_Sales_Individual(ModelBuilder modelBuilder);
		#endregion

		#region HumanResources_JobCandidate
		private void Map_HumanResources_JobCandidate(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<HumanResources_JobCandidate>().ToTable("JobCandidate", "HumanResources");
			modelBuilder.Entity<HumanResources_JobCandidate>().HasKey(x=>x.JobCandidateID);
			modelBuilder.Entity<HumanResources_JobCandidate>().Property(x=>x.JobCandidateID).HasColumnName("JobCandidateID").HasColumnType("Int").IsRequired().ValueGeneratedOnAdd();
			modelBuilder.Entity<HumanResources_JobCandidate>().Property(x=>x.EmployeeID).HasColumnName("EmployeeID").HasColumnType("Int").ValueGeneratedNever();
			modelBuilder.Entity<HumanResources_JobCandidate>().Property(x=>x.Resume).HasColumnName("Resume").HasColumnType("Xml").ValueGeneratedNever();
			modelBuilder.Entity<HumanResources_JobCandidate>().Property(x=>x.ModifiedDate).HasColumnName("ModifiedDate").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
		}

		partial void Customize_HumanResources_JobCandidate(ModelBuilder modelBuilder);
		#endregion

		#region Production_Location
		private void Map_Production_Location(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Production_Location>().ToTable("Location", "Production");
			modelBuilder.Entity<Production_Location>().HasKey(x=>x.LocationID);
			modelBuilder.Entity<Production_Location>().Property(x=>x.LocationID).HasColumnName("LocationID").HasColumnType("SmallInt").IsRequired().ValueGeneratedOnAdd();
			modelBuilder.Entity<Production_Location>().Property(x=>x.Name).HasColumnName("Name").HasColumnType("NVarChar(50)").IsRequired().ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<Production_Location>().Property(x=>x.CostRate).HasColumnName("CostRate").HasColumnType("SmallMoney").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Production_Location>().Property(x=>x.Availability).HasColumnName("Availability").HasColumnType("Decimal(8,2)").IsRequired().ValueGeneratedNever().HasMaxLength(8);
			modelBuilder.Entity<Production_Location>().Property(x=>x.ModifiedDate).HasColumnName("ModifiedDate").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
		}

		partial void Customize_Production_Location(ModelBuilder modelBuilder);
		#endregion

		#region Production_Product
		private void Map_Production_Product(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Production_Product>().ToTable("Product", "Production");
			modelBuilder.Entity<Production_Product>().HasKey(x=>x.ProductID);
			modelBuilder.Entity<Production_Product>().Property(x=>x.ProductID).HasColumnName("ProductID").HasColumnType("Int").IsRequired().ValueGeneratedOnAdd();
			modelBuilder.Entity<Production_Product>().Property(x=>x.Name).HasColumnName("Name").HasColumnType("NVarChar(50)").IsRequired().ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<Production_Product>().Property(x=>x.ProductNumber).HasColumnName("ProductNumber").HasColumnType("NVarChar(25)").IsRequired().ValueGeneratedNever().HasMaxLength(25);
			modelBuilder.Entity<Production_Product>().Property(x=>x.MakeFlag).HasColumnName("MakeFlag").HasColumnType("Bit").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Production_Product>().Property(x=>x.FinishedGoodsFlag).HasColumnName("FinishedGoodsFlag").HasColumnType("Bit").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Production_Product>().Property(x=>x.Color).HasColumnName("Color").HasColumnType("NVarChar(15)").ValueGeneratedNever().HasMaxLength(15);
			modelBuilder.Entity<Production_Product>().Property(x=>x.SafetyStockLevel).HasColumnName("SafetyStockLevel").HasColumnType("SmallInt").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Production_Product>().Property(x=>x.ReorderPoint).HasColumnName("ReorderPoint").HasColumnType("SmallInt").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Production_Product>().Property(x=>x.StandardCost).HasColumnName("StandardCost").HasColumnType("Money").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Production_Product>().Property(x=>x.ListPrice).HasColumnName("ListPrice").HasColumnType("Money").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Production_Product>().Property(x=>x.Size).HasColumnName("Size").HasColumnType("NVarChar(5)").ValueGeneratedNever().HasMaxLength(5);
			modelBuilder.Entity<Production_Product>().Property(x=>x.SizeUnitMeasureCode).HasColumnName("SizeUnitMeasureCode").HasColumnType("NChar(3)").ValueGeneratedNever().HasMaxLength(3);
			modelBuilder.Entity<Production_Product>().Property(x=>x.WeightUnitMeasureCode).HasColumnName("WeightUnitMeasureCode").HasColumnType("NChar(3)").ValueGeneratedNever().HasMaxLength(3);
			modelBuilder.Entity<Production_Product>().Property(x=>x.Weight).HasColumnName("Weight").HasColumnType("Decimal(8,2)").ValueGeneratedNever().HasMaxLength(8);
			modelBuilder.Entity<Production_Product>().Property(x=>x.DaysToManufacture).HasColumnName("DaysToManufacture").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Production_Product>().Property(x=>x.ProductLine).HasColumnName("ProductLine").HasColumnType("NChar(2)").ValueGeneratedNever().HasMaxLength(2);
			modelBuilder.Entity<Production_Product>().Property(x=>x.Class).HasColumnName("Class").HasColumnType("NChar(2)").ValueGeneratedNever().HasMaxLength(2);
			modelBuilder.Entity<Production_Product>().Property(x=>x.Style).HasColumnName("Style").HasColumnType("NChar(2)").ValueGeneratedNever().HasMaxLength(2);
			modelBuilder.Entity<Production_Product>().Property(x=>x.ProductSubcategoryID).HasColumnName("ProductSubcategoryID").HasColumnType("Int").ValueGeneratedNever();
			modelBuilder.Entity<Production_Product>().Property(x=>x.ProductModelID).HasColumnName("ProductModelID").HasColumnType("Int").ValueGeneratedNever();
			modelBuilder.Entity<Production_Product>().Property(x=>x.SellStartDate).HasColumnName("SellStartDate").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Production_Product>().Property(x=>x.SellEndDate).HasColumnName("SellEndDate").HasColumnType("DateTime").ValueGeneratedNever();
			modelBuilder.Entity<Production_Product>().Property(x=>x.DiscontinuedDate).HasColumnName("DiscontinuedDate").HasColumnType("DateTime").ValueGeneratedNever();
			modelBuilder.Entity<Production_Product>().Property(x=>x.rowguid).HasColumnName("rowguid").HasColumnType("UniqueIdentifier").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Production_Product>().Property(x=>x.ModifiedDate).HasColumnName("ModifiedDate").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
		}

		partial void Customize_Production_Product(ModelBuilder modelBuilder);
		#endregion

		#region Production_ProductCategory
		private void Map_Production_ProductCategory(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Production_ProductCategory>().ToTable("ProductCategory", "Production");
			modelBuilder.Entity<Production_ProductCategory>().HasKey(x=>x.ProductCategoryID);
			modelBuilder.Entity<Production_ProductCategory>().Property(x=>x.ProductCategoryID).HasColumnName("ProductCategoryID").HasColumnType("Int").IsRequired().ValueGeneratedOnAdd();
			modelBuilder.Entity<Production_ProductCategory>().Property(x=>x.Name).HasColumnName("Name").HasColumnType("NVarChar(50)").IsRequired().ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<Production_ProductCategory>().Property(x=>x.rowguid).HasColumnName("rowguid").HasColumnType("UniqueIdentifier").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Production_ProductCategory>().Property(x=>x.ModifiedDate).HasColumnName("ModifiedDate").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
		}

		partial void Customize_Production_ProductCategory(ModelBuilder modelBuilder);
		#endregion

		#region Production_ProductCostHistory
		private void Map_Production_ProductCostHistory(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Production_ProductCostHistory>().ToTable("ProductCostHistory", "Production");
			modelBuilder.Entity<Production_ProductCostHistory>().HasKey("ProductID", "StartDate");
			modelBuilder.Entity<Production_ProductCostHistory>().Property(x=>x.ProductID).HasColumnName("ProductID").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Production_ProductCostHistory>().Property(x=>x.StartDate).HasColumnName("StartDate").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Production_ProductCostHistory>().Property(x=>x.EndDate).HasColumnName("EndDate").HasColumnType("DateTime").ValueGeneratedNever();
			modelBuilder.Entity<Production_ProductCostHistory>().Property(x=>x.StandardCost).HasColumnName("StandardCost").HasColumnType("Money").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Production_ProductCostHistory>().Property(x=>x.ModifiedDate).HasColumnName("ModifiedDate").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
		}

		partial void Customize_Production_ProductCostHistory(ModelBuilder modelBuilder);
		#endregion

		#region Production_ProductDescription
		private void Map_Production_ProductDescription(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Production_ProductDescription>().ToTable("ProductDescription", "Production");
			modelBuilder.Entity<Production_ProductDescription>().HasKey(x=>x.ProductDescriptionID);
			modelBuilder.Entity<Production_ProductDescription>().Property(x=>x.ProductDescriptionID).HasColumnName("ProductDescriptionID").HasColumnType("Int").IsRequired().ValueGeneratedOnAdd();
			modelBuilder.Entity<Production_ProductDescription>().Property(x=>x.Description).HasColumnName("Description").HasColumnType("NVarChar(400)").IsRequired().ValueGeneratedNever().HasMaxLength(400);
			modelBuilder.Entity<Production_ProductDescription>().Property(x=>x.rowguid).HasColumnName("rowguid").HasColumnType("UniqueIdentifier").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Production_ProductDescription>().Property(x=>x.ModifiedDate).HasColumnName("ModifiedDate").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
		}

		partial void Customize_Production_ProductDescription(ModelBuilder modelBuilder);
		#endregion

		#region Production_ProductDocument
		private void Map_Production_ProductDocument(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Production_ProductDocument>().ToTable("ProductDocument", "Production");
			modelBuilder.Entity<Production_ProductDocument>().HasKey("ProductID", "DocumentID");
			modelBuilder.Entity<Production_ProductDocument>().Property(x=>x.ProductID).HasColumnName("ProductID").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Production_ProductDocument>().Property(x=>x.DocumentID).HasColumnName("DocumentID").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Production_ProductDocument>().Property(x=>x.ModifiedDate).HasColumnName("ModifiedDate").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
		}

		partial void Customize_Production_ProductDocument(ModelBuilder modelBuilder);
		#endregion

		#region Production_ProductInventory
		private void Map_Production_ProductInventory(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Production_ProductInventory>().ToTable("ProductInventory", "Production");
			modelBuilder.Entity<Production_ProductInventory>().HasKey("ProductID", "LocationID");
			modelBuilder.Entity<Production_ProductInventory>().Property(x=>x.ProductID).HasColumnName("ProductID").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Production_ProductInventory>().Property(x=>x.LocationID).HasColumnName("LocationID").HasColumnType("SmallInt").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Production_ProductInventory>().Property(x=>x.Shelf).HasColumnName("Shelf").HasColumnType("NVarChar(10)").IsRequired().ValueGeneratedNever().HasMaxLength(10);
			modelBuilder.Entity<Production_ProductInventory>().Property(x=>x.Bin).HasColumnName("Bin").HasColumnType("TinyInt").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Production_ProductInventory>().Property(x=>x.Quantity).HasColumnName("Quantity").HasColumnType("SmallInt").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Production_ProductInventory>().Property(x=>x.rowguid).HasColumnName("rowguid").HasColumnType("UniqueIdentifier").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Production_ProductInventory>().Property(x=>x.ModifiedDate).HasColumnName("ModifiedDate").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
		}

		partial void Customize_Production_ProductInventory(ModelBuilder modelBuilder);
		#endregion

		#region Production_ProductListPriceHistory
		private void Map_Production_ProductListPriceHistory(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Production_ProductListPriceHistory>().ToTable("ProductListPriceHistory", "Production");
			modelBuilder.Entity<Production_ProductListPriceHistory>().HasKey("ProductID", "StartDate");
			modelBuilder.Entity<Production_ProductListPriceHistory>().Property(x=>x.ProductID).HasColumnName("ProductID").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Production_ProductListPriceHistory>().Property(x=>x.StartDate).HasColumnName("StartDate").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Production_ProductListPriceHistory>().Property(x=>x.EndDate).HasColumnName("EndDate").HasColumnType("DateTime").ValueGeneratedNever();
			modelBuilder.Entity<Production_ProductListPriceHistory>().Property(x=>x.ListPrice).HasColumnName("ListPrice").HasColumnType("Money").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Production_ProductListPriceHistory>().Property(x=>x.ModifiedDate).HasColumnName("ModifiedDate").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
		}

		partial void Customize_Production_ProductListPriceHistory(ModelBuilder modelBuilder);
		#endregion

		#region Production_ProductModel
		private void Map_Production_ProductModel(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Production_ProductModel>().ToTable("ProductModel", "Production");
			modelBuilder.Entity<Production_ProductModel>().HasKey(x=>x.ProductModelID);
			modelBuilder.Entity<Production_ProductModel>().Property(x=>x.ProductModelID).HasColumnName("ProductModelID").HasColumnType("Int").IsRequired().ValueGeneratedOnAdd();
			modelBuilder.Entity<Production_ProductModel>().Property(x=>x.Name).HasColumnName("Name").HasColumnType("NVarChar(50)").IsRequired().ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<Production_ProductModel>().Property(x=>x.CatalogDescription).HasColumnName("CatalogDescription").HasColumnType("Xml").ValueGeneratedNever();
			modelBuilder.Entity<Production_ProductModel>().Property(x=>x.Instructions).HasColumnName("Instructions").HasColumnType("Xml").ValueGeneratedNever();
			modelBuilder.Entity<Production_ProductModel>().Property(x=>x.rowguid).HasColumnName("rowguid").HasColumnType("UniqueIdentifier").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Production_ProductModel>().Property(x=>x.ModifiedDate).HasColumnName("ModifiedDate").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
		}

		partial void Customize_Production_ProductModel(ModelBuilder modelBuilder);
		#endregion

		#region Production_ProductModelIllustration
		private void Map_Production_ProductModelIllustration(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Production_ProductModelIllustration>().ToTable("ProductModelIllustration", "Production");
			modelBuilder.Entity<Production_ProductModelIllustration>().HasKey("ProductModelID", "IllustrationID");
			modelBuilder.Entity<Production_ProductModelIllustration>().Property(x=>x.ProductModelID).HasColumnName("ProductModelID").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Production_ProductModelIllustration>().Property(x=>x.IllustrationID).HasColumnName("IllustrationID").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Production_ProductModelIllustration>().Property(x=>x.ModifiedDate).HasColumnName("ModifiedDate").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
		}

		partial void Customize_Production_ProductModelIllustration(ModelBuilder modelBuilder);
		#endregion

		#region Production_ProductModelProductDescriptionCulture
		private void Map_Production_ProductModelProductDescriptionCulture(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Production_ProductModelProductDescriptionCulture>().ToTable("ProductModelProductDescriptionCulture", "Production");
			modelBuilder.Entity<Production_ProductModelProductDescriptionCulture>().HasKey("ProductModelID", "ProductDescriptionID", "CultureID");
			modelBuilder.Entity<Production_ProductModelProductDescriptionCulture>().Property(x=>x.ProductModelID).HasColumnName("ProductModelID").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Production_ProductModelProductDescriptionCulture>().Property(x=>x.ProductDescriptionID).HasColumnName("ProductDescriptionID").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Production_ProductModelProductDescriptionCulture>().Property(x=>x.CultureID).HasColumnName("CultureID").HasColumnType("NChar(6)").IsRequired().ValueGeneratedNever().HasMaxLength(6);
			modelBuilder.Entity<Production_ProductModelProductDescriptionCulture>().Property(x=>x.ModifiedDate).HasColumnName("ModifiedDate").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
		}

		partial void Customize_Production_ProductModelProductDescriptionCulture(ModelBuilder modelBuilder);
		#endregion

		#region Production_ProductPhoto
		private void Map_Production_ProductPhoto(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Production_ProductPhoto>().ToTable("ProductPhoto", "Production");
			modelBuilder.Entity<Production_ProductPhoto>().HasKey(x=>x.ProductPhotoID);
			modelBuilder.Entity<Production_ProductPhoto>().Property(x=>x.ProductPhotoID).HasColumnName("ProductPhotoID").HasColumnType("Int").IsRequired().ValueGeneratedOnAdd();
			modelBuilder.Entity<Production_ProductPhoto>().Property(x=>x.ThumbNailPhoto).HasColumnName("ThumbNailPhoto").HasColumnType("VarBinary(MAX)").ValueGeneratedNever();
			modelBuilder.Entity<Production_ProductPhoto>().Property(x=>x.ThumbnailPhotoFileName).HasColumnName("ThumbnailPhotoFileName").HasColumnType("NVarChar(50)").ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<Production_ProductPhoto>().Property(x=>x.LargePhoto).HasColumnName("LargePhoto").HasColumnType("VarBinary(MAX)").ValueGeneratedNever();
			modelBuilder.Entity<Production_ProductPhoto>().Property(x=>x.LargePhotoFileName).HasColumnName("LargePhotoFileName").HasColumnType("NVarChar(50)").ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<Production_ProductPhoto>().Property(x=>x.ModifiedDate).HasColumnName("ModifiedDate").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
		}

		partial void Customize_Production_ProductPhoto(ModelBuilder modelBuilder);
		#endregion

		#region Production_ProductProductPhoto
		private void Map_Production_ProductProductPhoto(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Production_ProductProductPhoto>().ToTable("ProductProductPhoto", "Production");
			modelBuilder.Entity<Production_ProductProductPhoto>().HasKey("ProductID", "ProductPhotoID");
			modelBuilder.Entity<Production_ProductProductPhoto>().Property(x=>x.ProductID).HasColumnName("ProductID").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Production_ProductProductPhoto>().Property(x=>x.ProductPhotoID).HasColumnName("ProductPhotoID").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Production_ProductProductPhoto>().Property(x=>x.Primary).HasColumnName("Primary").HasColumnType("Bit").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Production_ProductProductPhoto>().Property(x=>x.ModifiedDate).HasColumnName("ModifiedDate").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
		}

		partial void Customize_Production_ProductProductPhoto(ModelBuilder modelBuilder);
		#endregion

		#region Production_ProductReview
		private void Map_Production_ProductReview(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Production_ProductReview>().ToTable("ProductReview", "Production");
			modelBuilder.Entity<Production_ProductReview>().HasKey(x=>x.ProductReviewID);
			modelBuilder.Entity<Production_ProductReview>().Property(x=>x.ProductReviewID).HasColumnName("ProductReviewID").HasColumnType("Int").IsRequired().ValueGeneratedOnAdd();
			modelBuilder.Entity<Production_ProductReview>().Property(x=>x.ProductID).HasColumnName("ProductID").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Production_ProductReview>().Property(x=>x.ReviewerName).HasColumnName("ReviewerName").HasColumnType("NVarChar(50)").IsRequired().ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<Production_ProductReview>().Property(x=>x.ReviewDate).HasColumnName("ReviewDate").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Production_ProductReview>().Property(x=>x.EmailAddress).HasColumnName("EmailAddress").HasColumnType("NVarChar(50)").IsRequired().ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<Production_ProductReview>().Property(x=>x.Rating).HasColumnName("Rating").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Production_ProductReview>().Property(x=>x.Comments).HasColumnName("Comments").HasColumnType("NVarChar(3850)").ValueGeneratedNever().HasMaxLength(3850);
			modelBuilder.Entity<Production_ProductReview>().Property(x=>x.ModifiedDate).HasColumnName("ModifiedDate").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
		}

		partial void Customize_Production_ProductReview(ModelBuilder modelBuilder);
		#endregion

		#region Production_ProductSubcategory
		private void Map_Production_ProductSubcategory(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Production_ProductSubcategory>().ToTable("ProductSubcategory", "Production");
			modelBuilder.Entity<Production_ProductSubcategory>().HasKey(x=>x.ProductSubcategoryID);
			modelBuilder.Entity<Production_ProductSubcategory>().Property(x=>x.ProductSubcategoryID).HasColumnName("ProductSubcategoryID").HasColumnType("Int").IsRequired().ValueGeneratedOnAdd();
			modelBuilder.Entity<Production_ProductSubcategory>().Property(x=>x.ProductCategoryID).HasColumnName("ProductCategoryID").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Production_ProductSubcategory>().Property(x=>x.Name).HasColumnName("Name").HasColumnType("NVarChar(50)").IsRequired().ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<Production_ProductSubcategory>().Property(x=>x.rowguid).HasColumnName("rowguid").HasColumnType("UniqueIdentifier").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Production_ProductSubcategory>().Property(x=>x.ModifiedDate).HasColumnName("ModifiedDate").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
		}

		partial void Customize_Production_ProductSubcategory(ModelBuilder modelBuilder);
		#endregion

		#region Purchasing_ProductVendor
		private void Map_Purchasing_ProductVendor(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Purchasing_ProductVendor>().ToTable("ProductVendor", "Purchasing");
			modelBuilder.Entity<Purchasing_ProductVendor>().HasKey("ProductID", "VendorID");
			modelBuilder.Entity<Purchasing_ProductVendor>().Property(x=>x.ProductID).HasColumnName("ProductID").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Purchasing_ProductVendor>().Property(x=>x.VendorID).HasColumnName("VendorID").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Purchasing_ProductVendor>().Property(x=>x.AverageLeadTime).HasColumnName("AverageLeadTime").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Purchasing_ProductVendor>().Property(x=>x.StandardPrice).HasColumnName("StandardPrice").HasColumnType("Money").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Purchasing_ProductVendor>().Property(x=>x.LastReceiptCost).HasColumnName("LastReceiptCost").HasColumnType("Money").ValueGeneratedNever();
			modelBuilder.Entity<Purchasing_ProductVendor>().Property(x=>x.LastReceiptDate).HasColumnName("LastReceiptDate").HasColumnType("DateTime").ValueGeneratedNever();
			modelBuilder.Entity<Purchasing_ProductVendor>().Property(x=>x.MinOrderQty).HasColumnName("MinOrderQty").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Purchasing_ProductVendor>().Property(x=>x.MaxOrderQty).HasColumnName("MaxOrderQty").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Purchasing_ProductVendor>().Property(x=>x.OnOrderQty).HasColumnName("OnOrderQty").HasColumnType("Int").ValueGeneratedNever();
			modelBuilder.Entity<Purchasing_ProductVendor>().Property(x=>x.UnitMeasureCode).HasColumnName("UnitMeasureCode").HasColumnType("NChar(3)").IsRequired().ValueGeneratedNever().HasMaxLength(3);
			modelBuilder.Entity<Purchasing_ProductVendor>().Property(x=>x.ModifiedDate).HasColumnName("ModifiedDate").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
		}

		partial void Customize_Purchasing_ProductVendor(ModelBuilder modelBuilder);
		#endregion

		#region Purchasing_PurchaseOrderDetail
		private void Map_Purchasing_PurchaseOrderDetail(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Purchasing_PurchaseOrderDetail>().ToTable("PurchaseOrderDetail", "Purchasing");
			modelBuilder.Entity<Purchasing_PurchaseOrderDetail>().HasKey("PurchaseOrderID", "PurchaseOrderDetailID");
			modelBuilder.Entity<Purchasing_PurchaseOrderDetail>().Property(x=>x.PurchaseOrderID).HasColumnName("PurchaseOrderID").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Purchasing_PurchaseOrderDetail>().Property(x=>x.PurchaseOrderDetailID).HasColumnName("PurchaseOrderDetailID").HasColumnType("Int").IsRequired().ValueGeneratedOnAdd();
			modelBuilder.Entity<Purchasing_PurchaseOrderDetail>().Property(x=>x.DueDate).HasColumnName("DueDate").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Purchasing_PurchaseOrderDetail>().Property(x=>x.OrderQty).HasColumnName("OrderQty").HasColumnType("SmallInt").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Purchasing_PurchaseOrderDetail>().Property(x=>x.ProductID).HasColumnName("ProductID").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Purchasing_PurchaseOrderDetail>().Property(x=>x.UnitPrice).HasColumnName("UnitPrice").HasColumnType("Money").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Purchasing_PurchaseOrderDetail>().Property(x=>x.LineTotal).HasColumnName("LineTotal").HasColumnType("Money").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Purchasing_PurchaseOrderDetail>().Property(x=>x.ReceivedQty).HasColumnName("ReceivedQty").HasColumnType("Decimal(8,2)").IsRequired().ValueGeneratedNever().HasMaxLength(8);
			modelBuilder.Entity<Purchasing_PurchaseOrderDetail>().Property(x=>x.RejectedQty).HasColumnName("RejectedQty").HasColumnType("Decimal(8,2)").IsRequired().ValueGeneratedNever().HasMaxLength(8);
			modelBuilder.Entity<Purchasing_PurchaseOrderDetail>().Property(x=>x.StockedQty).HasColumnName("StockedQty").HasColumnType("Decimal(9,2)").IsRequired().ValueGeneratedNever().HasMaxLength(9);
			modelBuilder.Entity<Purchasing_PurchaseOrderDetail>().Property(x=>x.ModifiedDate).HasColumnName("ModifiedDate").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
		}

		partial void Customize_Purchasing_PurchaseOrderDetail(ModelBuilder modelBuilder);
		#endregion

		#region Purchasing_PurchaseOrderHeader
		private void Map_Purchasing_PurchaseOrderHeader(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Purchasing_PurchaseOrderHeader>().ToTable("PurchaseOrderHeader", "Purchasing");
			modelBuilder.Entity<Purchasing_PurchaseOrderHeader>().HasKey(x=>x.PurchaseOrderID);
			modelBuilder.Entity<Purchasing_PurchaseOrderHeader>().Property(x=>x.PurchaseOrderID).HasColumnName("PurchaseOrderID").HasColumnType("Int").IsRequired().ValueGeneratedOnAdd();
			modelBuilder.Entity<Purchasing_PurchaseOrderHeader>().Property(x=>x.RevisionNumber).HasColumnName("RevisionNumber").HasColumnType("TinyInt").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Purchasing_PurchaseOrderHeader>().Property(x=>x.Status).HasColumnName("Status").HasColumnType("TinyInt").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Purchasing_PurchaseOrderHeader>().Property(x=>x.EmployeeID).HasColumnName("EmployeeID").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Purchasing_PurchaseOrderHeader>().Property(x=>x.VendorID).HasColumnName("VendorID").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Purchasing_PurchaseOrderHeader>().Property(x=>x.ShipMethodID).HasColumnName("ShipMethodID").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Purchasing_PurchaseOrderHeader>().Property(x=>x.OrderDate).HasColumnName("OrderDate").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Purchasing_PurchaseOrderHeader>().Property(x=>x.ShipDate).HasColumnName("ShipDate").HasColumnType("DateTime").ValueGeneratedNever();
			modelBuilder.Entity<Purchasing_PurchaseOrderHeader>().Property(x=>x.SubTotal).HasColumnName("SubTotal").HasColumnType("Money").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Purchasing_PurchaseOrderHeader>().Property(x=>x.TaxAmt).HasColumnName("TaxAmt").HasColumnType("Money").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Purchasing_PurchaseOrderHeader>().Property(x=>x.Freight).HasColumnName("Freight").HasColumnType("Money").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Purchasing_PurchaseOrderHeader>().Property(x=>x.TotalDue).HasColumnName("TotalDue").HasColumnType("Money").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Purchasing_PurchaseOrderHeader>().Property(x=>x.ModifiedDate).HasColumnName("ModifiedDate").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
		}

		partial void Customize_Purchasing_PurchaseOrderHeader(ModelBuilder modelBuilder);
		#endregion

		#region Sales_SalesOrderDetail
		private void Map_Sales_SalesOrderDetail(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Sales_SalesOrderDetail>().ToTable("SalesOrderDetail", "Sales");
			modelBuilder.Entity<Sales_SalesOrderDetail>().HasKey("SalesOrderID", "SalesOrderDetailID");
			modelBuilder.Entity<Sales_SalesOrderDetail>().Property(x=>x.SalesOrderID).HasColumnName("SalesOrderID").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Sales_SalesOrderDetail>().Property(x=>x.SalesOrderDetailID).HasColumnName("SalesOrderDetailID").HasColumnType("Int").IsRequired().ValueGeneratedOnAdd();
			modelBuilder.Entity<Sales_SalesOrderDetail>().Property(x=>x.CarrierTrackingNumber).HasColumnName("CarrierTrackingNumber").HasColumnType("NVarChar(25)").ValueGeneratedNever().HasMaxLength(25);
			modelBuilder.Entity<Sales_SalesOrderDetail>().Property(x=>x.OrderQty).HasColumnName("OrderQty").HasColumnType("SmallInt").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Sales_SalesOrderDetail>().Property(x=>x.ProductID).HasColumnName("ProductID").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Sales_SalesOrderDetail>().Property(x=>x.SpecialOfferID).HasColumnName("SpecialOfferID").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Sales_SalesOrderDetail>().Property(x=>x.UnitPrice).HasColumnName("UnitPrice").HasColumnType("Money").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Sales_SalesOrderDetail>().Property(x=>x.UnitPriceDiscount).HasColumnName("UnitPriceDiscount").HasColumnType("Money").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Sales_SalesOrderDetail>().Property(x=>x.LineTotal).HasColumnName("LineTotal").HasColumnType("Decimal(38,6)").IsRequired().ValueGeneratedNever().HasMaxLength(38);
			modelBuilder.Entity<Sales_SalesOrderDetail>().Property(x=>x.rowguid).HasColumnName("rowguid").HasColumnType("UniqueIdentifier").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Sales_SalesOrderDetail>().Property(x=>x.ModifiedDate).HasColumnName("ModifiedDate").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
		}

		partial void Customize_Sales_SalesOrderDetail(ModelBuilder modelBuilder);
		#endregion

		#region Sales_SalesOrderHeader
		private void Map_Sales_SalesOrderHeader(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Sales_SalesOrderHeader>().ToTable("SalesOrderHeader", "Sales");
			modelBuilder.Entity<Sales_SalesOrderHeader>().HasKey(x=>x.SalesOrderID);
			modelBuilder.Entity<Sales_SalesOrderHeader>().Property(x=>x.SalesOrderID).HasColumnName("SalesOrderID").HasColumnType("Int").IsRequired().ValueGeneratedOnAdd();
			modelBuilder.Entity<Sales_SalesOrderHeader>().Property(x=>x.RevisionNumber).HasColumnName("RevisionNumber").HasColumnType("TinyInt").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Sales_SalesOrderHeader>().Property(x=>x.OrderDate).HasColumnName("OrderDate").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Sales_SalesOrderHeader>().Property(x=>x.DueDate).HasColumnName("DueDate").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Sales_SalesOrderHeader>().Property(x=>x.ShipDate).HasColumnName("ShipDate").HasColumnType("DateTime").ValueGeneratedNever();
			modelBuilder.Entity<Sales_SalesOrderHeader>().Property(x=>x.Status).HasColumnName("Status").HasColumnType("TinyInt").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Sales_SalesOrderHeader>().Property(x=>x.OnlineOrderFlag).HasColumnName("OnlineOrderFlag").HasColumnType("Bit").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Sales_SalesOrderHeader>().Property(x=>x.SalesOrderNumber).HasColumnName("SalesOrderNumber").HasColumnType("NVarChar(25)").IsRequired().ValueGeneratedNever().HasMaxLength(25);
			modelBuilder.Entity<Sales_SalesOrderHeader>().Property(x=>x.PurchaseOrderNumber).HasColumnName("PurchaseOrderNumber").HasColumnType("NVarChar(25)").ValueGeneratedNever().HasMaxLength(25);
			modelBuilder.Entity<Sales_SalesOrderHeader>().Property(x=>x.AccountNumber).HasColumnName("AccountNumber").HasColumnType("NVarChar(15)").ValueGeneratedNever().HasMaxLength(15);
			modelBuilder.Entity<Sales_SalesOrderHeader>().Property(x=>x.CustomerID).HasColumnName("CustomerID").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Sales_SalesOrderHeader>().Property(x=>x.ContactID).HasColumnName("ContactID").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Sales_SalesOrderHeader>().Property(x=>x.SalesPersonID).HasColumnName("SalesPersonID").HasColumnType("Int").ValueGeneratedNever();
			modelBuilder.Entity<Sales_SalesOrderHeader>().Property(x=>x.TerritoryID).HasColumnName("TerritoryID").HasColumnType("Int").ValueGeneratedNever();
			modelBuilder.Entity<Sales_SalesOrderHeader>().Property(x=>x.BillToAddressID).HasColumnName("BillToAddressID").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Sales_SalesOrderHeader>().Property(x=>x.ShipToAddressID).HasColumnName("ShipToAddressID").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Sales_SalesOrderHeader>().Property(x=>x.ShipMethodID).HasColumnName("ShipMethodID").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Sales_SalesOrderHeader>().Property(x=>x.CreditCardID).HasColumnName("CreditCardID").HasColumnType("Int").ValueGeneratedNever();
			modelBuilder.Entity<Sales_SalesOrderHeader>().Property(x=>x.CreditCardApprovalCode).HasColumnName("CreditCardApprovalCode").HasColumnType("VarChar(15)").ValueGeneratedNever().HasMaxLength(15);
			modelBuilder.Entity<Sales_SalesOrderHeader>().Property(x=>x.CurrencyRateID).HasColumnName("CurrencyRateID").HasColumnType("Int").ValueGeneratedNever();
			modelBuilder.Entity<Sales_SalesOrderHeader>().Property(x=>x.SubTotal).HasColumnName("SubTotal").HasColumnType("Money").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Sales_SalesOrderHeader>().Property(x=>x.TaxAmt).HasColumnName("TaxAmt").HasColumnType("Money").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Sales_SalesOrderHeader>().Property(x=>x.Freight).HasColumnName("Freight").HasColumnType("Money").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Sales_SalesOrderHeader>().Property(x=>x.TotalDue).HasColumnName("TotalDue").HasColumnType("Money").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Sales_SalesOrderHeader>().Property(x=>x.Comment).HasColumnName("Comment").HasColumnType("NVarChar(128)").ValueGeneratedNever().HasMaxLength(128);
			modelBuilder.Entity<Sales_SalesOrderHeader>().Property(x=>x.rowguid).HasColumnName("rowguid").HasColumnType("UniqueIdentifier").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Sales_SalesOrderHeader>().Property(x=>x.ModifiedDate).HasColumnName("ModifiedDate").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
		}

		partial void Customize_Sales_SalesOrderHeader(ModelBuilder modelBuilder);
		#endregion

		#region Sales_SalesOrderHeaderSalesReason
		private void Map_Sales_SalesOrderHeaderSalesReason(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Sales_SalesOrderHeaderSalesReason>().ToTable("SalesOrderHeaderSalesReason", "Sales");
			modelBuilder.Entity<Sales_SalesOrderHeaderSalesReason>().HasKey("SalesOrderID", "SalesReasonID");
			modelBuilder.Entity<Sales_SalesOrderHeaderSalesReason>().Property(x=>x.SalesOrderID).HasColumnName("SalesOrderID").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Sales_SalesOrderHeaderSalesReason>().Property(x=>x.SalesReasonID).HasColumnName("SalesReasonID").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Sales_SalesOrderHeaderSalesReason>().Property(x=>x.ModifiedDate).HasColumnName("ModifiedDate").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
		}

		partial void Customize_Sales_SalesOrderHeaderSalesReason(ModelBuilder modelBuilder);
		#endregion

		#region Sales_SalesPerson
		private void Map_Sales_SalesPerson(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Sales_SalesPerson>().ToTable("SalesPerson", "Sales");
			modelBuilder.Entity<Sales_SalesPerson>().HasKey(x=>x.SalesPersonID);
			modelBuilder.Entity<Sales_SalesPerson>().Property(x=>x.SalesPersonID).HasColumnName("SalesPersonID").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Sales_SalesPerson>().Property(x=>x.TerritoryID).HasColumnName("TerritoryID").HasColumnType("Int").ValueGeneratedNever();
			modelBuilder.Entity<Sales_SalesPerson>().Property(x=>x.SalesQuota).HasColumnName("SalesQuota").HasColumnType("Money").ValueGeneratedNever();
			modelBuilder.Entity<Sales_SalesPerson>().Property(x=>x.Bonus).HasColumnName("Bonus").HasColumnType("Money").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Sales_SalesPerson>().Property(x=>x.CommissionPct).HasColumnName("CommissionPct").HasColumnType("SmallMoney").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Sales_SalesPerson>().Property(x=>x.SalesYTD).HasColumnName("SalesYTD").HasColumnType("Money").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Sales_SalesPerson>().Property(x=>x.SalesLastYear).HasColumnName("SalesLastYear").HasColumnType("Money").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Sales_SalesPerson>().Property(x=>x.rowguid).HasColumnName("rowguid").HasColumnType("UniqueIdentifier").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Sales_SalesPerson>().Property(x=>x.ModifiedDate).HasColumnName("ModifiedDate").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
		}

		partial void Customize_Sales_SalesPerson(ModelBuilder modelBuilder);
		#endregion

		#region Sales_SalesPersonQuotaHistory
		private void Map_Sales_SalesPersonQuotaHistory(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Sales_SalesPersonQuotaHistory>().ToTable("SalesPersonQuotaHistory", "Sales");
			modelBuilder.Entity<Sales_SalesPersonQuotaHistory>().HasKey("SalesPersonID", "QuotaDate");
			modelBuilder.Entity<Sales_SalesPersonQuotaHistory>().Property(x=>x.SalesPersonID).HasColumnName("SalesPersonID").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Sales_SalesPersonQuotaHistory>().Property(x=>x.QuotaDate).HasColumnName("QuotaDate").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Sales_SalesPersonQuotaHistory>().Property(x=>x.SalesQuota).HasColumnName("SalesQuota").HasColumnType("Money").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Sales_SalesPersonQuotaHistory>().Property(x=>x.rowguid).HasColumnName("rowguid").HasColumnType("UniqueIdentifier").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Sales_SalesPersonQuotaHistory>().Property(x=>x.ModifiedDate).HasColumnName("ModifiedDate").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
		}

		partial void Customize_Sales_SalesPersonQuotaHistory(ModelBuilder modelBuilder);
		#endregion

		#region Sales_SalesReason
		private void Map_Sales_SalesReason(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Sales_SalesReason>().ToTable("SalesReason", "Sales");
			modelBuilder.Entity<Sales_SalesReason>().HasKey(x=>x.SalesReasonID);
			modelBuilder.Entity<Sales_SalesReason>().Property(x=>x.SalesReasonID).HasColumnName("SalesReasonID").HasColumnType("Int").IsRequired().ValueGeneratedOnAdd();
			modelBuilder.Entity<Sales_SalesReason>().Property(x=>x.Name).HasColumnName("Name").HasColumnType("NVarChar(50)").IsRequired().ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<Sales_SalesReason>().Property(x=>x.ReasonType).HasColumnName("ReasonType").HasColumnType("NVarChar(50)").IsRequired().ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<Sales_SalesReason>().Property(x=>x.ModifiedDate).HasColumnName("ModifiedDate").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
		}

		partial void Customize_Sales_SalesReason(ModelBuilder modelBuilder);
		#endregion

		#region Sales_SalesTaxRate
		private void Map_Sales_SalesTaxRate(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Sales_SalesTaxRate>().ToTable("SalesTaxRate", "Sales");
			modelBuilder.Entity<Sales_SalesTaxRate>().HasKey(x=>x.SalesTaxRateID);
			modelBuilder.Entity<Sales_SalesTaxRate>().Property(x=>x.SalesTaxRateID).HasColumnName("SalesTaxRateID").HasColumnType("Int").IsRequired().ValueGeneratedOnAdd();
			modelBuilder.Entity<Sales_SalesTaxRate>().Property(x=>x.StateProvinceID).HasColumnName("StateProvinceID").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Sales_SalesTaxRate>().Property(x=>x.TaxType).HasColumnName("TaxType").HasColumnType("TinyInt").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Sales_SalesTaxRate>().Property(x=>x.TaxRate).HasColumnName("TaxRate").HasColumnType("SmallMoney").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Sales_SalesTaxRate>().Property(x=>x.Name).HasColumnName("Name").HasColumnType("NVarChar(50)").IsRequired().ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<Sales_SalesTaxRate>().Property(x=>x.rowguid).HasColumnName("rowguid").HasColumnType("UniqueIdentifier").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Sales_SalesTaxRate>().Property(x=>x.ModifiedDate).HasColumnName("ModifiedDate").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
		}

		partial void Customize_Sales_SalesTaxRate(ModelBuilder modelBuilder);
		#endregion

		#region Sales_SalesTerritory
		private void Map_Sales_SalesTerritory(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Sales_SalesTerritory>().ToTable("SalesTerritory", "Sales");
			modelBuilder.Entity<Sales_SalesTerritory>().HasKey(x=>x.TerritoryID);
			modelBuilder.Entity<Sales_SalesTerritory>().Property(x=>x.TerritoryID).HasColumnName("TerritoryID").HasColumnType("Int").IsRequired().ValueGeneratedOnAdd();
			modelBuilder.Entity<Sales_SalesTerritory>().Property(x=>x.Name).HasColumnName("Name").HasColumnType("NVarChar(50)").IsRequired().ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<Sales_SalesTerritory>().Property(x=>x.CountryRegionCode).HasColumnName("CountryRegionCode").HasColumnType("NVarChar(3)").IsRequired().ValueGeneratedNever().HasMaxLength(3);
			modelBuilder.Entity<Sales_SalesTerritory>().Property(x=>x.Group).HasColumnName("Group").HasColumnType("NVarChar(50)").IsRequired().ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<Sales_SalesTerritory>().Property(x=>x.SalesYTD).HasColumnName("SalesYTD").HasColumnType("Money").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Sales_SalesTerritory>().Property(x=>x.SalesLastYear).HasColumnName("SalesLastYear").HasColumnType("Money").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Sales_SalesTerritory>().Property(x=>x.CostYTD).HasColumnName("CostYTD").HasColumnType("Money").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Sales_SalesTerritory>().Property(x=>x.CostLastYear).HasColumnName("CostLastYear").HasColumnType("Money").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Sales_SalesTerritory>().Property(x=>x.rowguid).HasColumnName("rowguid").HasColumnType("UniqueIdentifier").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Sales_SalesTerritory>().Property(x=>x.ModifiedDate).HasColumnName("ModifiedDate").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
		}

		partial void Customize_Sales_SalesTerritory(ModelBuilder modelBuilder);
		#endregion

		#region Sales_SalesTerritoryHistory
		private void Map_Sales_SalesTerritoryHistory(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Sales_SalesTerritoryHistory>().ToTable("SalesTerritoryHistory", "Sales");
			modelBuilder.Entity<Sales_SalesTerritoryHistory>().HasKey("SalesPersonID", "TerritoryID", "StartDate");
			modelBuilder.Entity<Sales_SalesTerritoryHistory>().Property(x=>x.SalesPersonID).HasColumnName("SalesPersonID").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Sales_SalesTerritoryHistory>().Property(x=>x.TerritoryID).HasColumnName("TerritoryID").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Sales_SalesTerritoryHistory>().Property(x=>x.StartDate).HasColumnName("StartDate").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Sales_SalesTerritoryHistory>().Property(x=>x.EndDate).HasColumnName("EndDate").HasColumnType("DateTime").ValueGeneratedNever();
			modelBuilder.Entity<Sales_SalesTerritoryHistory>().Property(x=>x.rowguid).HasColumnName("rowguid").HasColumnType("UniqueIdentifier").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Sales_SalesTerritoryHistory>().Property(x=>x.ModifiedDate).HasColumnName("ModifiedDate").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
		}

		partial void Customize_Sales_SalesTerritoryHistory(ModelBuilder modelBuilder);
		#endregion

		#region Production_ScrapReason
		private void Map_Production_ScrapReason(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Production_ScrapReason>().ToTable("ScrapReason", "Production");
			modelBuilder.Entity<Production_ScrapReason>().HasKey(x=>x.ScrapReasonID);
			modelBuilder.Entity<Production_ScrapReason>().Property(x=>x.ScrapReasonID).HasColumnName("ScrapReasonID").HasColumnType("SmallInt").IsRequired().ValueGeneratedOnAdd();
			modelBuilder.Entity<Production_ScrapReason>().Property(x=>x.Name).HasColumnName("Name").HasColumnType("NVarChar(50)").IsRequired().ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<Production_ScrapReason>().Property(x=>x.ModifiedDate).HasColumnName("ModifiedDate").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
		}

		partial void Customize_Production_ScrapReason(ModelBuilder modelBuilder);
		#endregion

		#region HumanResources_Shift
		private void Map_HumanResources_Shift(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<HumanResources_Shift>().ToTable("Shift", "HumanResources");
			modelBuilder.Entity<HumanResources_Shift>().HasKey(x=>x.ShiftID);
			modelBuilder.Entity<HumanResources_Shift>().Property(x=>x.ShiftID).HasColumnName("ShiftID").HasColumnType("TinyInt").IsRequired().ValueGeneratedOnAdd();
			modelBuilder.Entity<HumanResources_Shift>().Property(x=>x.Name).HasColumnName("Name").HasColumnType("NVarChar(50)").IsRequired().ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<HumanResources_Shift>().Property(x=>x.StartTime).HasColumnName("StartTime").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<HumanResources_Shift>().Property(x=>x.EndTime).HasColumnName("EndTime").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<HumanResources_Shift>().Property(x=>x.ModifiedDate).HasColumnName("ModifiedDate").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
		}

		partial void Customize_HumanResources_Shift(ModelBuilder modelBuilder);
		#endregion

		#region Purchasing_ShipMethod
		private void Map_Purchasing_ShipMethod(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Purchasing_ShipMethod>().ToTable("ShipMethod", "Purchasing");
			modelBuilder.Entity<Purchasing_ShipMethod>().HasKey(x=>x.ShipMethodID);
			modelBuilder.Entity<Purchasing_ShipMethod>().Property(x=>x.ShipMethodID).HasColumnName("ShipMethodID").HasColumnType("Int").IsRequired().ValueGeneratedOnAdd();
			modelBuilder.Entity<Purchasing_ShipMethod>().Property(x=>x.Name).HasColumnName("Name").HasColumnType("NVarChar(50)").IsRequired().ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<Purchasing_ShipMethod>().Property(x=>x.ShipBase).HasColumnName("ShipBase").HasColumnType("Money").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Purchasing_ShipMethod>().Property(x=>x.ShipRate).HasColumnName("ShipRate").HasColumnType("Money").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Purchasing_ShipMethod>().Property(x=>x.rowguid).HasColumnName("rowguid").HasColumnType("UniqueIdentifier").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Purchasing_ShipMethod>().Property(x=>x.ModifiedDate).HasColumnName("ModifiedDate").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
		}

		partial void Customize_Purchasing_ShipMethod(ModelBuilder modelBuilder);
		#endregion

		#region Sales_ShoppingCartItem
		private void Map_Sales_ShoppingCartItem(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Sales_ShoppingCartItem>().ToTable("ShoppingCartItem", "Sales");
			modelBuilder.Entity<Sales_ShoppingCartItem>().HasKey(x=>x.ShoppingCartItemID);
			modelBuilder.Entity<Sales_ShoppingCartItem>().Property(x=>x.ShoppingCartItemID).HasColumnName("ShoppingCartItemID").HasColumnType("Int").IsRequired().ValueGeneratedOnAdd();
			modelBuilder.Entity<Sales_ShoppingCartItem>().Property(x=>x.ShoppingCartID).HasColumnName("ShoppingCartID").HasColumnType("NVarChar(50)").IsRequired().ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<Sales_ShoppingCartItem>().Property(x=>x.Quantity).HasColumnName("Quantity").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Sales_ShoppingCartItem>().Property(x=>x.ProductID).HasColumnName("ProductID").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Sales_ShoppingCartItem>().Property(x=>x.DateCreated).HasColumnName("DateCreated").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Sales_ShoppingCartItem>().Property(x=>x.ModifiedDate).HasColumnName("ModifiedDate").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
		}

		partial void Customize_Sales_ShoppingCartItem(ModelBuilder modelBuilder);
		#endregion

		#region Sales_SpecialOffer
		private void Map_Sales_SpecialOffer(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Sales_SpecialOffer>().ToTable("SpecialOffer", "Sales");
			modelBuilder.Entity<Sales_SpecialOffer>().HasKey(x=>x.SpecialOfferID);
			modelBuilder.Entity<Sales_SpecialOffer>().Property(x=>x.SpecialOfferID).HasColumnName("SpecialOfferID").HasColumnType("Int").IsRequired().ValueGeneratedOnAdd();
			modelBuilder.Entity<Sales_SpecialOffer>().Property(x=>x.Description).HasColumnName("Description").HasColumnType("NVarChar(255)").IsRequired().ValueGeneratedNever().HasMaxLength(255);
			modelBuilder.Entity<Sales_SpecialOffer>().Property(x=>x.DiscountPct).HasColumnName("DiscountPct").HasColumnType("SmallMoney").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Sales_SpecialOffer>().Property(x=>x.Type).HasColumnName("Type").HasColumnType("NVarChar(50)").IsRequired().ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<Sales_SpecialOffer>().Property(x=>x.Category).HasColumnName("Category").HasColumnType("NVarChar(50)").IsRequired().ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<Sales_SpecialOffer>().Property(x=>x.StartDate).HasColumnName("StartDate").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Sales_SpecialOffer>().Property(x=>x.EndDate).HasColumnName("EndDate").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Sales_SpecialOffer>().Property(x=>x.MinQty).HasColumnName("MinQty").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Sales_SpecialOffer>().Property(x=>x.MaxQty).HasColumnName("MaxQty").HasColumnType("Int").ValueGeneratedNever();
			modelBuilder.Entity<Sales_SpecialOffer>().Property(x=>x.rowguid).HasColumnName("rowguid").HasColumnType("UniqueIdentifier").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Sales_SpecialOffer>().Property(x=>x.ModifiedDate).HasColumnName("ModifiedDate").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
		}

		partial void Customize_Sales_SpecialOffer(ModelBuilder modelBuilder);
		#endregion

		#region Sales_SpecialOfferProduct
		private void Map_Sales_SpecialOfferProduct(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Sales_SpecialOfferProduct>().ToTable("SpecialOfferProduct", "Sales");
			modelBuilder.Entity<Sales_SpecialOfferProduct>().HasKey("SpecialOfferID", "ProductID");
			modelBuilder.Entity<Sales_SpecialOfferProduct>().Property(x=>x.SpecialOfferID).HasColumnName("SpecialOfferID").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Sales_SpecialOfferProduct>().Property(x=>x.ProductID).HasColumnName("ProductID").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Sales_SpecialOfferProduct>().Property(x=>x.rowguid).HasColumnName("rowguid").HasColumnType("UniqueIdentifier").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Sales_SpecialOfferProduct>().Property(x=>x.ModifiedDate).HasColumnName("ModifiedDate").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
		}

		partial void Customize_Sales_SpecialOfferProduct(ModelBuilder modelBuilder);
		#endregion

		#region Person_StateProvince
		private void Map_Person_StateProvince(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Person_StateProvince>().ToTable("StateProvince", "Person");
			modelBuilder.Entity<Person_StateProvince>().HasKey(x=>x.StateProvinceID);
			modelBuilder.Entity<Person_StateProvince>().Property(x=>x.StateProvinceID).HasColumnName("StateProvinceID").HasColumnType("Int").IsRequired().ValueGeneratedOnAdd();
			modelBuilder.Entity<Person_StateProvince>().Property(x=>x.StateProvinceCode).HasColumnName("StateProvinceCode").HasColumnType("NChar(3)").IsRequired().ValueGeneratedNever().HasMaxLength(3);
			modelBuilder.Entity<Person_StateProvince>().Property(x=>x.CountryRegionCode).HasColumnName("CountryRegionCode").HasColumnType("NVarChar(3)").IsRequired().ValueGeneratedNever().HasMaxLength(3);
			modelBuilder.Entity<Person_StateProvince>().Property(x=>x.IsOnlyStateProvinceFlag).HasColumnName("IsOnlyStateProvinceFlag").HasColumnType("Bit").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Person_StateProvince>().Property(x=>x.Name).HasColumnName("Name").HasColumnType("NVarChar(50)").IsRequired().ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<Person_StateProvince>().Property(x=>x.TerritoryID).HasColumnName("TerritoryID").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Person_StateProvince>().Property(x=>x.rowguid).HasColumnName("rowguid").HasColumnType("UniqueIdentifier").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Person_StateProvince>().Property(x=>x.ModifiedDate).HasColumnName("ModifiedDate").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
		}

		partial void Customize_Person_StateProvince(ModelBuilder modelBuilder);
		#endregion

		#region Sales_Store
		private void Map_Sales_Store(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Sales_Store>().ToTable("Store", "Sales");
			modelBuilder.Entity<Sales_Store>().HasKey(x=>x.CustomerID);
			modelBuilder.Entity<Sales_Store>().Property(x=>x.CustomerID).HasColumnName("CustomerID").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Sales_Store>().Property(x=>x.Name).HasColumnName("Name").HasColumnType("NVarChar(50)").IsRequired().ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<Sales_Store>().Property(x=>x.SalesPersonID).HasColumnName("SalesPersonID").HasColumnType("Int").ValueGeneratedNever();
			modelBuilder.Entity<Sales_Store>().Property(x=>x.Demographics).HasColumnName("Demographics").HasColumnType("Xml").ValueGeneratedNever();
			modelBuilder.Entity<Sales_Store>().Property(x=>x.rowguid).HasColumnName("rowguid").HasColumnType("UniqueIdentifier").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Sales_Store>().Property(x=>x.ModifiedDate).HasColumnName("ModifiedDate").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
		}

		partial void Customize_Sales_Store(ModelBuilder modelBuilder);
		#endregion

		#region Sales_StoreContact
		private void Map_Sales_StoreContact(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Sales_StoreContact>().ToTable("StoreContact", "Sales");
			modelBuilder.Entity<Sales_StoreContact>().HasKey("CustomerID", "ContactID");
			modelBuilder.Entity<Sales_StoreContact>().Property(x=>x.CustomerID).HasColumnName("CustomerID").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Sales_StoreContact>().Property(x=>x.ContactID).HasColumnName("ContactID").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Sales_StoreContact>().Property(x=>x.ContactTypeID).HasColumnName("ContactTypeID").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Sales_StoreContact>().Property(x=>x.rowguid).HasColumnName("rowguid").HasColumnType("UniqueIdentifier").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Sales_StoreContact>().Property(x=>x.ModifiedDate).HasColumnName("ModifiedDate").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
		}

		partial void Customize_Sales_StoreContact(ModelBuilder modelBuilder);
		#endregion

		#region Production_TransactionHistory
		private void Map_Production_TransactionHistory(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Production_TransactionHistory>().ToTable("TransactionHistory", "Production");
			modelBuilder.Entity<Production_TransactionHistory>().HasKey(x=>x.TransactionID);
			modelBuilder.Entity<Production_TransactionHistory>().Property(x=>x.TransactionID).HasColumnName("TransactionID").HasColumnType("Int").IsRequired().ValueGeneratedOnAdd();
			modelBuilder.Entity<Production_TransactionHistory>().Property(x=>x.ProductID).HasColumnName("ProductID").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Production_TransactionHistory>().Property(x=>x.ReferenceOrderID).HasColumnName("ReferenceOrderID").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Production_TransactionHistory>().Property(x=>x.ReferenceOrderLineID).HasColumnName("ReferenceOrderLineID").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Production_TransactionHistory>().Property(x=>x.TransactionDate).HasColumnName("TransactionDate").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Production_TransactionHistory>().Property(x=>x.TransactionType).HasColumnName("TransactionType").HasColumnType("NChar(1)").IsRequired().ValueGeneratedNever().HasMaxLength(1);
			modelBuilder.Entity<Production_TransactionHistory>().Property(x=>x.Quantity).HasColumnName("Quantity").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Production_TransactionHistory>().Property(x=>x.ActualCost).HasColumnName("ActualCost").HasColumnType("Money").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Production_TransactionHistory>().Property(x=>x.ModifiedDate).HasColumnName("ModifiedDate").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
		}

		partial void Customize_Production_TransactionHistory(ModelBuilder modelBuilder);
		#endregion

		#region Production_TransactionHistoryArchive
		private void Map_Production_TransactionHistoryArchive(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Production_TransactionHistoryArchive>().ToTable("TransactionHistoryArchive", "Production");
			modelBuilder.Entity<Production_TransactionHistoryArchive>().HasKey(x=>x.TransactionID);
			modelBuilder.Entity<Production_TransactionHistoryArchive>().Property(x=>x.TransactionID).HasColumnName("TransactionID").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Production_TransactionHistoryArchive>().Property(x=>x.ProductID).HasColumnName("ProductID").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Production_TransactionHistoryArchive>().Property(x=>x.ReferenceOrderID).HasColumnName("ReferenceOrderID").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Production_TransactionHistoryArchive>().Property(x=>x.ReferenceOrderLineID).HasColumnName("ReferenceOrderLineID").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Production_TransactionHistoryArchive>().Property(x=>x.TransactionDate).HasColumnName("TransactionDate").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Production_TransactionHistoryArchive>().Property(x=>x.TransactionType).HasColumnName("TransactionType").HasColumnType("NChar(1)").IsRequired().ValueGeneratedNever().HasMaxLength(1);
			modelBuilder.Entity<Production_TransactionHistoryArchive>().Property(x=>x.Quantity).HasColumnName("Quantity").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Production_TransactionHistoryArchive>().Property(x=>x.ActualCost).HasColumnName("ActualCost").HasColumnType("Money").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Production_TransactionHistoryArchive>().Property(x=>x.ModifiedDate).HasColumnName("ModifiedDate").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
		}

		partial void Customize_Production_TransactionHistoryArchive(ModelBuilder modelBuilder);
		#endregion

		#region Production_UnitMeasure
		private void Map_Production_UnitMeasure(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Production_UnitMeasure>().ToTable("UnitMeasure", "Production");
			modelBuilder.Entity<Production_UnitMeasure>().HasKey(x=>x.UnitMeasureCode);
			modelBuilder.Entity<Production_UnitMeasure>().Property(x=>x.UnitMeasureCode).HasColumnName("UnitMeasureCode").HasColumnType("NChar(3)").IsRequired().ValueGeneratedNever().HasMaxLength(3);
			modelBuilder.Entity<Production_UnitMeasure>().Property(x=>x.Name).HasColumnName("Name").HasColumnType("NVarChar(50)").IsRequired().ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<Production_UnitMeasure>().Property(x=>x.ModifiedDate).HasColumnName("ModifiedDate").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
		}

		partial void Customize_Production_UnitMeasure(ModelBuilder modelBuilder);
		#endregion

		#region Person_vAdditionalContactInfo
		private void Map_Person_vAdditionalContactInfo(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Person_vAdditionalContactInfo>().ToTable("vAdditionalContactInfo", "Person");
			modelBuilder.Entity<Person_vAdditionalContactInfo>().HasNoKey();
			modelBuilder.Entity<Person_vAdditionalContactInfo>().Property(x=>x.ContactID).HasColumnName("ContactID").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Person_vAdditionalContactInfo>().Property(x=>x.FirstName).HasColumnName("FirstName").HasColumnType("NVarChar(50)").IsRequired().ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<Person_vAdditionalContactInfo>().Property(x=>x.MiddleName).HasColumnName("MiddleName").HasColumnType("NVarChar(50)").ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<Person_vAdditionalContactInfo>().Property(x=>x.LastName).HasColumnName("LastName").HasColumnType("NVarChar(50)").IsRequired().ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<Person_vAdditionalContactInfo>().Property(x=>x.TelephoneNumber).HasColumnName("TelephoneNumber").HasColumnType("NVarChar(50)").ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<Person_vAdditionalContactInfo>().Property(x=>x.TelephoneSpecialInstructions).HasColumnName("TelephoneSpecialInstructions").HasColumnType("NVarChar(MAX)").ValueGeneratedNever();
			modelBuilder.Entity<Person_vAdditionalContactInfo>().Property(x=>x.Street).HasColumnName("Street").HasColumnType("NVarChar(50)").ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<Person_vAdditionalContactInfo>().Property(x=>x.City).HasColumnName("City").HasColumnType("NVarChar(50)").ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<Person_vAdditionalContactInfo>().Property(x=>x.StateProvince).HasColumnName("StateProvince").HasColumnType("NVarChar(50)").ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<Person_vAdditionalContactInfo>().Property(x=>x.PostalCode).HasColumnName("PostalCode").HasColumnType("NVarChar(50)").ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<Person_vAdditionalContactInfo>().Property(x=>x.CountryRegion).HasColumnName("CountryRegion").HasColumnType("NVarChar(50)").ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<Person_vAdditionalContactInfo>().Property(x=>x.HomeAddressSpecialInstructions).HasColumnName("HomeAddressSpecialInstructions").HasColumnType("NVarChar(MAX)").ValueGeneratedNever();
			modelBuilder.Entity<Person_vAdditionalContactInfo>().Property(x=>x.EMailAddress).HasColumnName("EMailAddress").HasColumnType("NVarChar(128)").ValueGeneratedNever().HasMaxLength(128);
			modelBuilder.Entity<Person_vAdditionalContactInfo>().Property(x=>x.EMailSpecialInstructions).HasColumnName("EMailSpecialInstructions").HasColumnType("NVarChar(MAX)").ValueGeneratedNever();
			modelBuilder.Entity<Person_vAdditionalContactInfo>().Property(x=>x.EMailTelephoneNumber).HasColumnName("EMailTelephoneNumber").HasColumnType("NVarChar(50)").ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<Person_vAdditionalContactInfo>().Property(x=>x.rowguid).HasColumnName("rowguid").HasColumnType("UniqueIdentifier").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Person_vAdditionalContactInfo>().Property(x=>x.ModifiedDate).HasColumnName("ModifiedDate").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
		}

		partial void Customize_Person_vAdditionalContactInfo(ModelBuilder modelBuilder);
		#endregion

		#region HumanResources_vEmployee
		private void Map_HumanResources_vEmployee(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<HumanResources_vEmployee>().ToTable("vEmployee", "HumanResources");
			modelBuilder.Entity<HumanResources_vEmployee>().HasNoKey();
			modelBuilder.Entity<HumanResources_vEmployee>().Property(x=>x.EmployeeID).HasColumnName("EmployeeID").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<HumanResources_vEmployee>().Property(x=>x.Title).HasColumnName("Title").HasColumnType("NVarChar(8)").ValueGeneratedNever().HasMaxLength(8);
			modelBuilder.Entity<HumanResources_vEmployee>().Property(x=>x.FirstName).HasColumnName("FirstName").HasColumnType("NVarChar(50)").IsRequired().ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<HumanResources_vEmployee>().Property(x=>x.MiddleName).HasColumnName("MiddleName").HasColumnType("NVarChar(50)").ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<HumanResources_vEmployee>().Property(x=>x.LastName).HasColumnName("LastName").HasColumnType("NVarChar(50)").IsRequired().ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<HumanResources_vEmployee>().Property(x=>x.Suffix).HasColumnName("Suffix").HasColumnType("NVarChar(10)").ValueGeneratedNever().HasMaxLength(10);
			modelBuilder.Entity<HumanResources_vEmployee>().Property(x=>x.JobTitle).HasColumnName("JobTitle").HasColumnType("NVarChar(50)").IsRequired().ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<HumanResources_vEmployee>().Property(x=>x.Phone).HasColumnName("Phone").HasColumnType("NVarChar(25)").ValueGeneratedNever().HasMaxLength(25);
			modelBuilder.Entity<HumanResources_vEmployee>().Property(x=>x.EmailAddress).HasColumnName("EmailAddress").HasColumnType("NVarChar(50)").ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<HumanResources_vEmployee>().Property(x=>x.EmailPromotion).HasColumnName("EmailPromotion").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<HumanResources_vEmployee>().Property(x=>x.AddressLine1).HasColumnName("AddressLine1").HasColumnType("NVarChar(60)").IsRequired().ValueGeneratedNever().HasMaxLength(60);
			modelBuilder.Entity<HumanResources_vEmployee>().Property(x=>x.AddressLine2).HasColumnName("AddressLine2").HasColumnType("NVarChar(60)").ValueGeneratedNever().HasMaxLength(60);
			modelBuilder.Entity<HumanResources_vEmployee>().Property(x=>x.City).HasColumnName("City").HasColumnType("NVarChar(30)").IsRequired().ValueGeneratedNever().HasMaxLength(30);
			modelBuilder.Entity<HumanResources_vEmployee>().Property(x=>x.StateProvinceName).HasColumnName("StateProvinceName").HasColumnType("NVarChar(50)").IsRequired().ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<HumanResources_vEmployee>().Property(x=>x.PostalCode).HasColumnName("PostalCode").HasColumnType("NVarChar(15)").IsRequired().ValueGeneratedNever().HasMaxLength(15);
			modelBuilder.Entity<HumanResources_vEmployee>().Property(x=>x.CountryRegionName).HasColumnName("CountryRegionName").HasColumnType("NVarChar(50)").IsRequired().ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<HumanResources_vEmployee>().Property(x=>x.AdditionalContactInfo).HasColumnName("AdditionalContactInfo").HasColumnType("Xml").ValueGeneratedNever();
		}

		partial void Customize_HumanResources_vEmployee(ModelBuilder modelBuilder);
		#endregion

		#region HumanResources_vEmployeeDepartment
		private void Map_HumanResources_vEmployeeDepartment(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<HumanResources_vEmployeeDepartment>().ToTable("vEmployeeDepartment", "HumanResources");
			modelBuilder.Entity<HumanResources_vEmployeeDepartment>().HasNoKey();
			modelBuilder.Entity<HumanResources_vEmployeeDepartment>().Property(x=>x.EmployeeID).HasColumnName("EmployeeID").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<HumanResources_vEmployeeDepartment>().Property(x=>x.Title).HasColumnName("Title").HasColumnType("NVarChar(8)").ValueGeneratedNever().HasMaxLength(8);
			modelBuilder.Entity<HumanResources_vEmployeeDepartment>().Property(x=>x.FirstName).HasColumnName("FirstName").HasColumnType("NVarChar(50)").IsRequired().ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<HumanResources_vEmployeeDepartment>().Property(x=>x.MiddleName).HasColumnName("MiddleName").HasColumnType("NVarChar(50)").ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<HumanResources_vEmployeeDepartment>().Property(x=>x.LastName).HasColumnName("LastName").HasColumnType("NVarChar(50)").IsRequired().ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<HumanResources_vEmployeeDepartment>().Property(x=>x.Suffix).HasColumnName("Suffix").HasColumnType("NVarChar(10)").ValueGeneratedNever().HasMaxLength(10);
			modelBuilder.Entity<HumanResources_vEmployeeDepartment>().Property(x=>x.JobTitle).HasColumnName("JobTitle").HasColumnType("NVarChar(50)").IsRequired().ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<HumanResources_vEmployeeDepartment>().Property(x=>x.Department).HasColumnName("Department").HasColumnType("NVarChar(50)").IsRequired().ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<HumanResources_vEmployeeDepartment>().Property(x=>x.GroupName).HasColumnName("GroupName").HasColumnType("NVarChar(50)").IsRequired().ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<HumanResources_vEmployeeDepartment>().Property(x=>x.StartDate).HasColumnName("StartDate").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
		}

		partial void Customize_HumanResources_vEmployeeDepartment(ModelBuilder modelBuilder);
		#endregion

		#region HumanResources_vEmployeeDepartmentHistory
		private void Map_HumanResources_vEmployeeDepartmentHistory(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<HumanResources_vEmployeeDepartmentHistory>().ToTable("vEmployeeDepartmentHistory", "HumanResources");
			modelBuilder.Entity<HumanResources_vEmployeeDepartmentHistory>().HasNoKey();
			modelBuilder.Entity<HumanResources_vEmployeeDepartmentHistory>().Property(x=>x.EmployeeID).HasColumnName("EmployeeID").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<HumanResources_vEmployeeDepartmentHistory>().Property(x=>x.Title).HasColumnName("Title").HasColumnType("NVarChar(8)").ValueGeneratedNever().HasMaxLength(8);
			modelBuilder.Entity<HumanResources_vEmployeeDepartmentHistory>().Property(x=>x.FirstName).HasColumnName("FirstName").HasColumnType("NVarChar(50)").IsRequired().ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<HumanResources_vEmployeeDepartmentHistory>().Property(x=>x.MiddleName).HasColumnName("MiddleName").HasColumnType("NVarChar(50)").ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<HumanResources_vEmployeeDepartmentHistory>().Property(x=>x.LastName).HasColumnName("LastName").HasColumnType("NVarChar(50)").IsRequired().ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<HumanResources_vEmployeeDepartmentHistory>().Property(x=>x.Suffix).HasColumnName("Suffix").HasColumnType("NVarChar(10)").ValueGeneratedNever().HasMaxLength(10);
			modelBuilder.Entity<HumanResources_vEmployeeDepartmentHistory>().Property(x=>x.Shift).HasColumnName("Shift").HasColumnType("NVarChar(50)").IsRequired().ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<HumanResources_vEmployeeDepartmentHistory>().Property(x=>x.Department).HasColumnName("Department").HasColumnType("NVarChar(50)").IsRequired().ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<HumanResources_vEmployeeDepartmentHistory>().Property(x=>x.GroupName).HasColumnName("GroupName").HasColumnType("NVarChar(50)").IsRequired().ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<HumanResources_vEmployeeDepartmentHistory>().Property(x=>x.StartDate).HasColumnName("StartDate").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<HumanResources_vEmployeeDepartmentHistory>().Property(x=>x.EndDate).HasColumnName("EndDate").HasColumnType("DateTime").ValueGeneratedNever();
		}

		partial void Customize_HumanResources_vEmployeeDepartmentHistory(ModelBuilder modelBuilder);
		#endregion

		#region Purchasing_Vendor
		private void Map_Purchasing_Vendor(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Purchasing_Vendor>().ToTable("Vendor", "Purchasing");
			modelBuilder.Entity<Purchasing_Vendor>().HasKey(x=>x.VendorID);
			modelBuilder.Entity<Purchasing_Vendor>().Property(x=>x.VendorID).HasColumnName("VendorID").HasColumnType("Int").IsRequired().ValueGeneratedOnAdd();
			modelBuilder.Entity<Purchasing_Vendor>().Property(x=>x.AccountNumber).HasColumnName("AccountNumber").HasColumnType("NVarChar(15)").IsRequired().ValueGeneratedNever().HasMaxLength(15);
			modelBuilder.Entity<Purchasing_Vendor>().Property(x=>x.Name).HasColumnName("Name").HasColumnType("NVarChar(50)").IsRequired().ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<Purchasing_Vendor>().Property(x=>x.CreditRating).HasColumnName("CreditRating").HasColumnType("TinyInt").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Purchasing_Vendor>().Property(x=>x.PreferredVendorStatus).HasColumnName("PreferredVendorStatus").HasColumnType("Bit").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Purchasing_Vendor>().Property(x=>x.ActiveFlag).HasColumnName("ActiveFlag").HasColumnType("Bit").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Purchasing_Vendor>().Property(x=>x.PurchasingWebServiceURL).HasColumnName("PurchasingWebServiceURL").HasColumnType("NVarChar(1024)").ValueGeneratedNever().HasMaxLength(1024);
			modelBuilder.Entity<Purchasing_Vendor>().Property(x=>x.ModifiedDate).HasColumnName("ModifiedDate").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
		}

		partial void Customize_Purchasing_Vendor(ModelBuilder modelBuilder);
		#endregion

		#region Purchasing_VendorAddress
		private void Map_Purchasing_VendorAddress(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Purchasing_VendorAddress>().ToTable("VendorAddress", "Purchasing");
			modelBuilder.Entity<Purchasing_VendorAddress>().HasKey("VendorID", "AddressID");
			modelBuilder.Entity<Purchasing_VendorAddress>().Property(x=>x.VendorID).HasColumnName("VendorID").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Purchasing_VendorAddress>().Property(x=>x.AddressID).HasColumnName("AddressID").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Purchasing_VendorAddress>().Property(x=>x.AddressTypeID).HasColumnName("AddressTypeID").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Purchasing_VendorAddress>().Property(x=>x.ModifiedDate).HasColumnName("ModifiedDate").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
		}

		partial void Customize_Purchasing_VendorAddress(ModelBuilder modelBuilder);
		#endregion

		#region Purchasing_VendorContact
		private void Map_Purchasing_VendorContact(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Purchasing_VendorContact>().ToTable("VendorContact", "Purchasing");
			modelBuilder.Entity<Purchasing_VendorContact>().HasKey("VendorID", "ContactID");
			modelBuilder.Entity<Purchasing_VendorContact>().Property(x=>x.VendorID).HasColumnName("VendorID").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Purchasing_VendorContact>().Property(x=>x.ContactID).HasColumnName("ContactID").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Purchasing_VendorContact>().Property(x=>x.ContactTypeID).HasColumnName("ContactTypeID").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Purchasing_VendorContact>().Property(x=>x.ModifiedDate).HasColumnName("ModifiedDate").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
		}

		partial void Customize_Purchasing_VendorContact(ModelBuilder modelBuilder);
		#endregion

		#region Sales_vIndividualCustomer
		private void Map_Sales_vIndividualCustomer(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Sales_vIndividualCustomer>().ToTable("vIndividualCustomer", "Sales");
			modelBuilder.Entity<Sales_vIndividualCustomer>().HasNoKey();
			modelBuilder.Entity<Sales_vIndividualCustomer>().Property(x=>x.CustomerID).HasColumnName("CustomerID").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Sales_vIndividualCustomer>().Property(x=>x.Title).HasColumnName("Title").HasColumnType("NVarChar(8)").ValueGeneratedNever().HasMaxLength(8);
			modelBuilder.Entity<Sales_vIndividualCustomer>().Property(x=>x.FirstName).HasColumnName("FirstName").HasColumnType("NVarChar(50)").IsRequired().ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<Sales_vIndividualCustomer>().Property(x=>x.MiddleName).HasColumnName("MiddleName").HasColumnType("NVarChar(50)").ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<Sales_vIndividualCustomer>().Property(x=>x.LastName).HasColumnName("LastName").HasColumnType("NVarChar(50)").IsRequired().ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<Sales_vIndividualCustomer>().Property(x=>x.Suffix).HasColumnName("Suffix").HasColumnType("NVarChar(10)").ValueGeneratedNever().HasMaxLength(10);
			modelBuilder.Entity<Sales_vIndividualCustomer>().Property(x=>x.Phone).HasColumnName("Phone").HasColumnType("NVarChar(25)").ValueGeneratedNever().HasMaxLength(25);
			modelBuilder.Entity<Sales_vIndividualCustomer>().Property(x=>x.EmailAddress).HasColumnName("EmailAddress").HasColumnType("NVarChar(50)").ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<Sales_vIndividualCustomer>().Property(x=>x.EmailPromotion).HasColumnName("EmailPromotion").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Sales_vIndividualCustomer>().Property(x=>x.AddressType).HasColumnName("AddressType").HasColumnType("NVarChar(50)").IsRequired().ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<Sales_vIndividualCustomer>().Property(x=>x.AddressLine1).HasColumnName("AddressLine1").HasColumnType("NVarChar(60)").IsRequired().ValueGeneratedNever().HasMaxLength(60);
			modelBuilder.Entity<Sales_vIndividualCustomer>().Property(x=>x.AddressLine2).HasColumnName("AddressLine2").HasColumnType("NVarChar(60)").ValueGeneratedNever().HasMaxLength(60);
			modelBuilder.Entity<Sales_vIndividualCustomer>().Property(x=>x.City).HasColumnName("City").HasColumnType("NVarChar(30)").IsRequired().ValueGeneratedNever().HasMaxLength(30);
			modelBuilder.Entity<Sales_vIndividualCustomer>().Property(x=>x.StateProvinceName).HasColumnName("StateProvinceName").HasColumnType("NVarChar(50)").IsRequired().ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<Sales_vIndividualCustomer>().Property(x=>x.PostalCode).HasColumnName("PostalCode").HasColumnType("NVarChar(15)").IsRequired().ValueGeneratedNever().HasMaxLength(15);
			modelBuilder.Entity<Sales_vIndividualCustomer>().Property(x=>x.CountryRegionName).HasColumnName("CountryRegionName").HasColumnType("NVarChar(50)").IsRequired().ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<Sales_vIndividualCustomer>().Property(x=>x.Demographics).HasColumnName("Demographics").HasColumnType("Xml").ValueGeneratedNever();
		}

		partial void Customize_Sales_vIndividualCustomer(ModelBuilder modelBuilder);
		#endregion

		#region Sales_vIndividualDemographics
		private void Map_Sales_vIndividualDemographics(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Sales_vIndividualDemographics>().ToTable("vIndividualDemographics", "Sales");
			modelBuilder.Entity<Sales_vIndividualDemographics>().HasNoKey();
			modelBuilder.Entity<Sales_vIndividualDemographics>().Property(x=>x.CustomerID).HasColumnName("CustomerID").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Sales_vIndividualDemographics>().Property(x=>x.TotalPurchaseYTD).HasColumnName("TotalPurchaseYTD").HasColumnType("Money").ValueGeneratedNever();
			modelBuilder.Entity<Sales_vIndividualDemographics>().Property(x=>x.DateFirstPurchase).HasColumnName("DateFirstPurchase").HasColumnType("DateTime").ValueGeneratedNever();
			modelBuilder.Entity<Sales_vIndividualDemographics>().Property(x=>x.BirthDate).HasColumnName("BirthDate").HasColumnType("DateTime").ValueGeneratedNever();
			modelBuilder.Entity<Sales_vIndividualDemographics>().Property(x=>x.MaritalStatus).HasColumnName("MaritalStatus").HasColumnType("NVarChar(1)").ValueGeneratedNever().HasMaxLength(1);
			modelBuilder.Entity<Sales_vIndividualDemographics>().Property(x=>x.YearlyIncome).HasColumnName("YearlyIncome").HasColumnType("NVarChar(30)").ValueGeneratedNever().HasMaxLength(30);
			modelBuilder.Entity<Sales_vIndividualDemographics>().Property(x=>x.Gender).HasColumnName("Gender").HasColumnType("NVarChar(1)").ValueGeneratedNever().HasMaxLength(1);
			modelBuilder.Entity<Sales_vIndividualDemographics>().Property(x=>x.TotalChildren).HasColumnName("TotalChildren").HasColumnType("Int").ValueGeneratedNever();
			modelBuilder.Entity<Sales_vIndividualDemographics>().Property(x=>x.NumberChildrenAtHome).HasColumnName("NumberChildrenAtHome").HasColumnType("Int").ValueGeneratedNever();
			modelBuilder.Entity<Sales_vIndividualDemographics>().Property(x=>x.Education).HasColumnName("Education").HasColumnType("NVarChar(30)").ValueGeneratedNever().HasMaxLength(30);
			modelBuilder.Entity<Sales_vIndividualDemographics>().Property(x=>x.Occupation).HasColumnName("Occupation").HasColumnType("NVarChar(30)").ValueGeneratedNever().HasMaxLength(30);
			modelBuilder.Entity<Sales_vIndividualDemographics>().Property(x=>x.HomeOwnerFlag).HasColumnName("HomeOwnerFlag").HasColumnType("Bit").ValueGeneratedNever();
			modelBuilder.Entity<Sales_vIndividualDemographics>().Property(x=>x.NumberCarsOwned).HasColumnName("NumberCarsOwned").HasColumnType("Int").ValueGeneratedNever();
		}

		partial void Customize_Sales_vIndividualDemographics(ModelBuilder modelBuilder);
		#endregion

		#region HumanResources_vJobCandidate
		private void Map_HumanResources_vJobCandidate(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<HumanResources_vJobCandidate>().ToTable("vJobCandidate", "HumanResources");
			modelBuilder.Entity<HumanResources_vJobCandidate>().HasNoKey();
			modelBuilder.Entity<HumanResources_vJobCandidate>().Property(x=>x.JobCandidateID).HasColumnName("JobCandidateID").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<HumanResources_vJobCandidate>().Property(x=>x.EmployeeID).HasColumnName("EmployeeID").HasColumnType("Int").ValueGeneratedNever();
			modelBuilder.Entity<HumanResources_vJobCandidate>().Property(x=>x.Name_Prefix).HasColumnName("Name_Prefix").HasColumnType("NVarChar(30)").ValueGeneratedNever().HasMaxLength(30);
			modelBuilder.Entity<HumanResources_vJobCandidate>().Property(x=>x.Name_First).HasColumnName("Name_First").HasColumnType("NVarChar(30)").ValueGeneratedNever().HasMaxLength(30);
			modelBuilder.Entity<HumanResources_vJobCandidate>().Property(x=>x.Name_Middle).HasColumnName("Name_Middle").HasColumnType("NVarChar(30)").ValueGeneratedNever().HasMaxLength(30);
			modelBuilder.Entity<HumanResources_vJobCandidate>().Property(x=>x.Name_Last).HasColumnName("Name_Last").HasColumnType("NVarChar(30)").ValueGeneratedNever().HasMaxLength(30);
			modelBuilder.Entity<HumanResources_vJobCandidate>().Property(x=>x.Name_Suffix).HasColumnName("Name_Suffix").HasColumnType("NVarChar(30)").ValueGeneratedNever().HasMaxLength(30);
			modelBuilder.Entity<HumanResources_vJobCandidate>().Property(x=>x.Skills).HasColumnName("Skills").HasColumnType("NVarChar(MAX)").ValueGeneratedNever();
			modelBuilder.Entity<HumanResources_vJobCandidate>().Property(x=>x.Addr_Type).HasColumnName("Addr_Type").HasColumnType("NVarChar(30)").ValueGeneratedNever().HasMaxLength(30);
			modelBuilder.Entity<HumanResources_vJobCandidate>().Property(x=>x.Addr_Loc_CountryRegion).HasColumnName("Addr_Loc_CountryRegion").HasColumnType("NVarChar(100)").ValueGeneratedNever().HasMaxLength(100);
			modelBuilder.Entity<HumanResources_vJobCandidate>().Property(x=>x.Addr_Loc_State).HasColumnName("Addr_Loc_State").HasColumnType("NVarChar(100)").ValueGeneratedNever().HasMaxLength(100);
			modelBuilder.Entity<HumanResources_vJobCandidate>().Property(x=>x.Addr_Loc_City).HasColumnName("Addr_Loc_City").HasColumnType("NVarChar(100)").ValueGeneratedNever().HasMaxLength(100);
			modelBuilder.Entity<HumanResources_vJobCandidate>().Property(x=>x.Addr_PostalCode).HasColumnName("Addr_PostalCode").HasColumnType("NVarChar(20)").ValueGeneratedNever().HasMaxLength(20);
			modelBuilder.Entity<HumanResources_vJobCandidate>().Property(x=>x.EMail).HasColumnName("EMail").HasColumnType("NVarChar(MAX)").ValueGeneratedNever();
			modelBuilder.Entity<HumanResources_vJobCandidate>().Property(x=>x.WebSite).HasColumnName("WebSite").HasColumnType("NVarChar(MAX)").ValueGeneratedNever();
			modelBuilder.Entity<HumanResources_vJobCandidate>().Property(x=>x.ModifiedDate).HasColumnName("ModifiedDate").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
		}

		partial void Customize_HumanResources_vJobCandidate(ModelBuilder modelBuilder);
		#endregion

		#region HumanResources_vJobCandidateEducation
		private void Map_HumanResources_vJobCandidateEducation(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<HumanResources_vJobCandidateEducation>().ToTable("vJobCandidateEducation", "HumanResources");
			modelBuilder.Entity<HumanResources_vJobCandidateEducation>().HasNoKey();
			modelBuilder.Entity<HumanResources_vJobCandidateEducation>().Property(x=>x.JobCandidateID).HasColumnName("JobCandidateID").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<HumanResources_vJobCandidateEducation>().Property(x=>x.Edu_Level).HasColumnName("Edu_Level").HasColumnType("NVarChar(MAX)").ValueGeneratedNever();
			modelBuilder.Entity<HumanResources_vJobCandidateEducation>().Property(x=>x.Edu_StartDate).HasColumnName("Edu_StartDate").HasColumnType("DateTime").ValueGeneratedNever();
			modelBuilder.Entity<HumanResources_vJobCandidateEducation>().Property(x=>x.Edu_EndDate).HasColumnName("Edu_EndDate").HasColumnType("DateTime").ValueGeneratedNever();
			modelBuilder.Entity<HumanResources_vJobCandidateEducation>().Property(x=>x.Edu_Degree).HasColumnName("Edu_Degree").HasColumnType("NVarChar(50)").ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<HumanResources_vJobCandidateEducation>().Property(x=>x.Edu_Major).HasColumnName("Edu_Major").HasColumnType("NVarChar(50)").ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<HumanResources_vJobCandidateEducation>().Property(x=>x.Edu_Minor).HasColumnName("Edu_Minor").HasColumnType("NVarChar(50)").ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<HumanResources_vJobCandidateEducation>().Property(x=>x.Edu_GPA).HasColumnName("Edu_GPA").HasColumnType("NVarChar(5)").ValueGeneratedNever().HasMaxLength(5);
			modelBuilder.Entity<HumanResources_vJobCandidateEducation>().Property(x=>x.Edu_GPAScale).HasColumnName("Edu_GPAScale").HasColumnType("NVarChar(5)").ValueGeneratedNever().HasMaxLength(5);
			modelBuilder.Entity<HumanResources_vJobCandidateEducation>().Property(x=>x.Edu_School).HasColumnName("Edu_School").HasColumnType("NVarChar(100)").ValueGeneratedNever().HasMaxLength(100);
			modelBuilder.Entity<HumanResources_vJobCandidateEducation>().Property(x=>x.Edu_Loc_CountryRegion).HasColumnName("Edu_Loc_CountryRegion").HasColumnType("NVarChar(100)").ValueGeneratedNever().HasMaxLength(100);
			modelBuilder.Entity<HumanResources_vJobCandidateEducation>().Property(x=>x.Edu_Loc_State).HasColumnName("Edu_Loc_State").HasColumnType("NVarChar(100)").ValueGeneratedNever().HasMaxLength(100);
			modelBuilder.Entity<HumanResources_vJobCandidateEducation>().Property(x=>x.Edu_Loc_City).HasColumnName("Edu_Loc_City").HasColumnType("NVarChar(100)").ValueGeneratedNever().HasMaxLength(100);
		}

		partial void Customize_HumanResources_vJobCandidateEducation(ModelBuilder modelBuilder);
		#endregion

		#region HumanResources_vJobCandidateEmployment
		private void Map_HumanResources_vJobCandidateEmployment(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<HumanResources_vJobCandidateEmployment>().ToTable("vJobCandidateEmployment", "HumanResources");
			modelBuilder.Entity<HumanResources_vJobCandidateEmployment>().HasNoKey();
			modelBuilder.Entity<HumanResources_vJobCandidateEmployment>().Property(x=>x.JobCandidateID).HasColumnName("JobCandidateID").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<HumanResources_vJobCandidateEmployment>().Property(x=>x.Emp_StartDate).HasColumnName("Emp_StartDate").HasColumnType("DateTime").ValueGeneratedNever();
			modelBuilder.Entity<HumanResources_vJobCandidateEmployment>().Property(x=>x.Emp_EndDate).HasColumnName("Emp_EndDate").HasColumnType("DateTime").ValueGeneratedNever();
			modelBuilder.Entity<HumanResources_vJobCandidateEmployment>().Property(x=>x.Emp_OrgName).HasColumnName("Emp_OrgName").HasColumnType("NVarChar(100)").ValueGeneratedNever().HasMaxLength(100);
			modelBuilder.Entity<HumanResources_vJobCandidateEmployment>().Property(x=>x.Emp_JobTitle).HasColumnName("Emp_JobTitle").HasColumnType("NVarChar(100)").ValueGeneratedNever().HasMaxLength(100);
			modelBuilder.Entity<HumanResources_vJobCandidateEmployment>().Property(x=>x.Emp_Responsibility).HasColumnName("Emp_Responsibility").HasColumnType("NVarChar(MAX)").ValueGeneratedNever();
			modelBuilder.Entity<HumanResources_vJobCandidateEmployment>().Property(x=>x.Emp_FunctionCategory).HasColumnName("Emp_FunctionCategory").HasColumnType("NVarChar(MAX)").ValueGeneratedNever();
			modelBuilder.Entity<HumanResources_vJobCandidateEmployment>().Property(x=>x.Emp_IndustryCategory).HasColumnName("Emp_IndustryCategory").HasColumnType("NVarChar(MAX)").ValueGeneratedNever();
			modelBuilder.Entity<HumanResources_vJobCandidateEmployment>().Property(x=>x.Emp_Loc_CountryRegion).HasColumnName("Emp_Loc_CountryRegion").HasColumnType("NVarChar(MAX)").ValueGeneratedNever();
			modelBuilder.Entity<HumanResources_vJobCandidateEmployment>().Property(x=>x.Emp_Loc_State).HasColumnName("Emp_Loc_State").HasColumnType("NVarChar(MAX)").ValueGeneratedNever();
			modelBuilder.Entity<HumanResources_vJobCandidateEmployment>().Property(x=>x.Emp_Loc_City).HasColumnName("Emp_Loc_City").HasColumnType("NVarChar(MAX)").ValueGeneratedNever();
		}

		partial void Customize_HumanResources_vJobCandidateEmployment(ModelBuilder modelBuilder);
		#endregion

		#region Production_vProductAndDescription
		private void Map_Production_vProductAndDescription(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Production_vProductAndDescription>().ToTable("vProductAndDescription", "Production");
			modelBuilder.Entity<Production_vProductAndDescription>().HasNoKey();
			modelBuilder.Entity<Production_vProductAndDescription>().Property(x=>x.ProductID).HasColumnName("ProductID").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Production_vProductAndDescription>().Property(x=>x.Name).HasColumnName("Name").HasColumnType("NVarChar(50)").IsRequired().ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<Production_vProductAndDescription>().Property(x=>x.ProductModel).HasColumnName("ProductModel").HasColumnType("NVarChar(50)").IsRequired().ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<Production_vProductAndDescription>().Property(x=>x.CultureID).HasColumnName("CultureID").HasColumnType("NChar(6)").IsRequired().ValueGeneratedNever().HasMaxLength(6);
			modelBuilder.Entity<Production_vProductAndDescription>().Property(x=>x.Description).HasColumnName("Description").HasColumnType("NVarChar(400)").IsRequired().ValueGeneratedNever().HasMaxLength(400);
		}

		partial void Customize_Production_vProductAndDescription(ModelBuilder modelBuilder);
		#endregion

		#region Production_vProductModelCatalogDescription
		private void Map_Production_vProductModelCatalogDescription(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Production_vProductModelCatalogDescription>().ToTable("vProductModelCatalogDescription", "Production");
			modelBuilder.Entity<Production_vProductModelCatalogDescription>().HasNoKey();
			modelBuilder.Entity<Production_vProductModelCatalogDescription>().Property(x=>x.ProductModelID).HasColumnName("ProductModelID").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Production_vProductModelCatalogDescription>().Property(x=>x.Name).HasColumnName("Name").HasColumnType("NVarChar(50)").IsRequired().ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<Production_vProductModelCatalogDescription>().Property(x=>x.Summary).HasColumnName("Summary").HasColumnType("NVarChar(MAX)").ValueGeneratedNever();
			modelBuilder.Entity<Production_vProductModelCatalogDescription>().Property(x=>x.Manufacturer).HasColumnName("Manufacturer").HasColumnType("NVarChar(MAX)").ValueGeneratedNever();
			modelBuilder.Entity<Production_vProductModelCatalogDescription>().Property(x=>x.Copyright).HasColumnName("Copyright").HasColumnType("NVarChar(30)").ValueGeneratedNever().HasMaxLength(30);
			modelBuilder.Entity<Production_vProductModelCatalogDescription>().Property(x=>x.ProductURL).HasColumnName("ProductURL").HasColumnType("NVarChar(256)").ValueGeneratedNever().HasMaxLength(256);
			modelBuilder.Entity<Production_vProductModelCatalogDescription>().Property(x=>x.WarrantyPeriod).HasColumnName("WarrantyPeriod").HasColumnType("NVarChar(256)").ValueGeneratedNever().HasMaxLength(256);
			modelBuilder.Entity<Production_vProductModelCatalogDescription>().Property(x=>x.WarrantyDescription).HasColumnName("WarrantyDescription").HasColumnType("NVarChar(256)").ValueGeneratedNever().HasMaxLength(256);
			modelBuilder.Entity<Production_vProductModelCatalogDescription>().Property(x=>x.NoOfYears).HasColumnName("NoOfYears").HasColumnType("NVarChar(256)").ValueGeneratedNever().HasMaxLength(256);
			modelBuilder.Entity<Production_vProductModelCatalogDescription>().Property(x=>x.MaintenanceDescription).HasColumnName("MaintenanceDescription").HasColumnType("NVarChar(256)").ValueGeneratedNever().HasMaxLength(256);
			modelBuilder.Entity<Production_vProductModelCatalogDescription>().Property(x=>x.Wheel).HasColumnName("Wheel").HasColumnType("NVarChar(256)").ValueGeneratedNever().HasMaxLength(256);
			modelBuilder.Entity<Production_vProductModelCatalogDescription>().Property(x=>x.Saddle).HasColumnName("Saddle").HasColumnType("NVarChar(256)").ValueGeneratedNever().HasMaxLength(256);
			modelBuilder.Entity<Production_vProductModelCatalogDescription>().Property(x=>x.Pedal).HasColumnName("Pedal").HasColumnType("NVarChar(256)").ValueGeneratedNever().HasMaxLength(256);
			modelBuilder.Entity<Production_vProductModelCatalogDescription>().Property(x=>x.BikeFrame).HasColumnName("BikeFrame").HasColumnType("NVarChar(MAX)").ValueGeneratedNever();
			modelBuilder.Entity<Production_vProductModelCatalogDescription>().Property(x=>x.Crankset).HasColumnName("Crankset").HasColumnType("NVarChar(256)").ValueGeneratedNever().HasMaxLength(256);
			modelBuilder.Entity<Production_vProductModelCatalogDescription>().Property(x=>x.PictureAngle).HasColumnName("PictureAngle").HasColumnType("NVarChar(256)").ValueGeneratedNever().HasMaxLength(256);
			modelBuilder.Entity<Production_vProductModelCatalogDescription>().Property(x=>x.PictureSize).HasColumnName("PictureSize").HasColumnType("NVarChar(256)").ValueGeneratedNever().HasMaxLength(256);
			modelBuilder.Entity<Production_vProductModelCatalogDescription>().Property(x=>x.ProductPhotoID).HasColumnName("ProductPhotoID").HasColumnType("NVarChar(256)").ValueGeneratedNever().HasMaxLength(256);
			modelBuilder.Entity<Production_vProductModelCatalogDescription>().Property(x=>x.Material).HasColumnName("Material").HasColumnType("NVarChar(256)").ValueGeneratedNever().HasMaxLength(256);
			modelBuilder.Entity<Production_vProductModelCatalogDescription>().Property(x=>x.Color).HasColumnName("Color").HasColumnType("NVarChar(256)").ValueGeneratedNever().HasMaxLength(256);
			modelBuilder.Entity<Production_vProductModelCatalogDescription>().Property(x=>x.ProductLine).HasColumnName("ProductLine").HasColumnType("NVarChar(256)").ValueGeneratedNever().HasMaxLength(256);
			modelBuilder.Entity<Production_vProductModelCatalogDescription>().Property(x=>x.Style).HasColumnName("Style").HasColumnType("NVarChar(256)").ValueGeneratedNever().HasMaxLength(256);
			modelBuilder.Entity<Production_vProductModelCatalogDescription>().Property(x=>x.RiderExperience).HasColumnName("RiderExperience").HasColumnType("NVarChar(1024)").ValueGeneratedNever().HasMaxLength(1024);
			modelBuilder.Entity<Production_vProductModelCatalogDescription>().Property(x=>x.rowguid).HasColumnName("rowguid").HasColumnType("UniqueIdentifier").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Production_vProductModelCatalogDescription>().Property(x=>x.ModifiedDate).HasColumnName("ModifiedDate").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
		}

		partial void Customize_Production_vProductModelCatalogDescription(ModelBuilder modelBuilder);
		#endregion

		#region Production_vProductModelInstructions
		private void Map_Production_vProductModelInstructions(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Production_vProductModelInstructions>().ToTable("vProductModelInstructions", "Production");
			modelBuilder.Entity<Production_vProductModelInstructions>().HasNoKey();
			modelBuilder.Entity<Production_vProductModelInstructions>().Property(x=>x.ProductModelID).HasColumnName("ProductModelID").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Production_vProductModelInstructions>().Property(x=>x.Name).HasColumnName("Name").HasColumnType("NVarChar(50)").IsRequired().ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<Production_vProductModelInstructions>().Property(x=>x.Instructions).HasColumnName("Instructions").HasColumnType("NVarChar(MAX)").ValueGeneratedNever();
			modelBuilder.Entity<Production_vProductModelInstructions>().Property(x=>x.LocationID).HasColumnName("LocationID").HasColumnType("Int").ValueGeneratedNever();
			modelBuilder.Entity<Production_vProductModelInstructions>().Property(x=>x.SetupHours).HasColumnName("SetupHours").HasColumnType("Decimal(9,4)").ValueGeneratedNever().HasMaxLength(9);
			modelBuilder.Entity<Production_vProductModelInstructions>().Property(x=>x.MachineHours).HasColumnName("MachineHours").HasColumnType("Decimal(9,4)").ValueGeneratedNever().HasMaxLength(9);
			modelBuilder.Entity<Production_vProductModelInstructions>().Property(x=>x.LaborHours).HasColumnName("LaborHours").HasColumnType("Decimal(9,4)").ValueGeneratedNever().HasMaxLength(9);
			modelBuilder.Entity<Production_vProductModelInstructions>().Property(x=>x.LotSize).HasColumnName("LotSize").HasColumnType("Int").ValueGeneratedNever();
			modelBuilder.Entity<Production_vProductModelInstructions>().Property(x=>x.Step).HasColumnName("Step").HasColumnType("NVarChar(1024)").ValueGeneratedNever().HasMaxLength(1024);
			modelBuilder.Entity<Production_vProductModelInstructions>().Property(x=>x.rowguid).HasColumnName("rowguid").HasColumnType("UniqueIdentifier").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Production_vProductModelInstructions>().Property(x=>x.ModifiedDate).HasColumnName("ModifiedDate").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
		}

		partial void Customize_Production_vProductModelInstructions(ModelBuilder modelBuilder);
		#endregion

		#region Sales_vSalesPerson
		private void Map_Sales_vSalesPerson(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Sales_vSalesPerson>().ToTable("vSalesPerson", "Sales");
			modelBuilder.Entity<Sales_vSalesPerson>().HasNoKey();
			modelBuilder.Entity<Sales_vSalesPerson>().Property(x=>x.SalesPersonID).HasColumnName("SalesPersonID").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Sales_vSalesPerson>().Property(x=>x.Title).HasColumnName("Title").HasColumnType("NVarChar(8)").ValueGeneratedNever().HasMaxLength(8);
			modelBuilder.Entity<Sales_vSalesPerson>().Property(x=>x.FirstName).HasColumnName("FirstName").HasColumnType("NVarChar(50)").IsRequired().ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<Sales_vSalesPerson>().Property(x=>x.MiddleName).HasColumnName("MiddleName").HasColumnType("NVarChar(50)").ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<Sales_vSalesPerson>().Property(x=>x.LastName).HasColumnName("LastName").HasColumnType("NVarChar(50)").IsRequired().ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<Sales_vSalesPerson>().Property(x=>x.Suffix).HasColumnName("Suffix").HasColumnType("NVarChar(10)").ValueGeneratedNever().HasMaxLength(10);
			modelBuilder.Entity<Sales_vSalesPerson>().Property(x=>x.JobTitle).HasColumnName("JobTitle").HasColumnType("NVarChar(50)").IsRequired().ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<Sales_vSalesPerson>().Property(x=>x.Phone).HasColumnName("Phone").HasColumnType("NVarChar(25)").ValueGeneratedNever().HasMaxLength(25);
			modelBuilder.Entity<Sales_vSalesPerson>().Property(x=>x.EmailAddress).HasColumnName("EmailAddress").HasColumnType("NVarChar(50)").ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<Sales_vSalesPerson>().Property(x=>x.EmailPromotion).HasColumnName("EmailPromotion").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Sales_vSalesPerson>().Property(x=>x.AddressLine1).HasColumnName("AddressLine1").HasColumnType("NVarChar(60)").IsRequired().ValueGeneratedNever().HasMaxLength(60);
			modelBuilder.Entity<Sales_vSalesPerson>().Property(x=>x.AddressLine2).HasColumnName("AddressLine2").HasColumnType("NVarChar(60)").ValueGeneratedNever().HasMaxLength(60);
			modelBuilder.Entity<Sales_vSalesPerson>().Property(x=>x.City).HasColumnName("City").HasColumnType("NVarChar(30)").IsRequired().ValueGeneratedNever().HasMaxLength(30);
			modelBuilder.Entity<Sales_vSalesPerson>().Property(x=>x.StateProvinceName).HasColumnName("StateProvinceName").HasColumnType("NVarChar(50)").IsRequired().ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<Sales_vSalesPerson>().Property(x=>x.PostalCode).HasColumnName("PostalCode").HasColumnType("NVarChar(15)").IsRequired().ValueGeneratedNever().HasMaxLength(15);
			modelBuilder.Entity<Sales_vSalesPerson>().Property(x=>x.CountryRegionName).HasColumnName("CountryRegionName").HasColumnType("NVarChar(50)").IsRequired().ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<Sales_vSalesPerson>().Property(x=>x.TerritoryName).HasColumnName("TerritoryName").HasColumnType("NVarChar(50)").ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<Sales_vSalesPerson>().Property(x=>x.TerritoryGroup).HasColumnName("TerritoryGroup").HasColumnType("NVarChar(50)").ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<Sales_vSalesPerson>().Property(x=>x.SalesQuota).HasColumnName("SalesQuota").HasColumnType("Money").ValueGeneratedNever();
			modelBuilder.Entity<Sales_vSalesPerson>().Property(x=>x.SalesYTD).HasColumnName("SalesYTD").HasColumnType("Money").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Sales_vSalesPerson>().Property(x=>x.SalesLastYear).HasColumnName("SalesLastYear").HasColumnType("Money").IsRequired().ValueGeneratedNever();
		}

		partial void Customize_Sales_vSalesPerson(ModelBuilder modelBuilder);
		#endregion

		#region Sales_vSalesPersonSalesByFiscalYears
		private void Map_Sales_vSalesPersonSalesByFiscalYears(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Sales_vSalesPersonSalesByFiscalYears>().ToTable("vSalesPersonSalesByFiscalYears", "Sales");
			modelBuilder.Entity<Sales_vSalesPersonSalesByFiscalYears>().HasNoKey();
			modelBuilder.Entity<Sales_vSalesPersonSalesByFiscalYears>().Property(x=>x.SalesPersonID).HasColumnName("SalesPersonID").HasColumnType("Int").ValueGeneratedNever();
			modelBuilder.Entity<Sales_vSalesPersonSalesByFiscalYears>().Property(x=>x.FullName).HasColumnName("FullName").HasColumnType("NVarChar(152)").ValueGeneratedNever().HasMaxLength(152);
			modelBuilder.Entity<Sales_vSalesPersonSalesByFiscalYears>().Property(x=>x.Title).HasColumnName("Title").HasColumnType("NVarChar(50)").IsRequired().ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<Sales_vSalesPersonSalesByFiscalYears>().Property(x=>x.SalesTerritory).HasColumnName("SalesTerritory").HasColumnType("NVarChar(50)").IsRequired().ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<Sales_vSalesPersonSalesByFiscalYears>().Property(x=>x._2002).HasColumnName("_2002").HasColumnType("Money").ValueGeneratedNever();
			modelBuilder.Entity<Sales_vSalesPersonSalesByFiscalYears>().Property(x=>x._2003).HasColumnName("_2003").HasColumnType("Money").ValueGeneratedNever();
			modelBuilder.Entity<Sales_vSalesPersonSalesByFiscalYears>().Property(x=>x._2004).HasColumnName("_2004").HasColumnType("Money").ValueGeneratedNever();
		}

		partial void Customize_Sales_vSalesPersonSalesByFiscalYears(ModelBuilder modelBuilder);
		#endregion

		#region Person_vStateProvinceCountryRegion
		private void Map_Person_vStateProvinceCountryRegion(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Person_vStateProvinceCountryRegion>().ToTable("vStateProvinceCountryRegion", "Person");
			modelBuilder.Entity<Person_vStateProvinceCountryRegion>().HasNoKey();
			modelBuilder.Entity<Person_vStateProvinceCountryRegion>().Property(x=>x.StateProvinceID).HasColumnName("StateProvinceID").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Person_vStateProvinceCountryRegion>().Property(x=>x.StateProvinceCode).HasColumnName("StateProvinceCode").HasColumnType("NChar(3)").IsRequired().ValueGeneratedNever().HasMaxLength(3);
			modelBuilder.Entity<Person_vStateProvinceCountryRegion>().Property(x=>x.IsOnlyStateProvinceFlag).HasColumnName("IsOnlyStateProvinceFlag").HasColumnType("Bit").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Person_vStateProvinceCountryRegion>().Property(x=>x.StateProvinceName).HasColumnName("StateProvinceName").HasColumnType("NVarChar(50)").IsRequired().ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<Person_vStateProvinceCountryRegion>().Property(x=>x.TerritoryID).HasColumnName("TerritoryID").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Person_vStateProvinceCountryRegion>().Property(x=>x.CountryRegionCode).HasColumnName("CountryRegionCode").HasColumnType("NVarChar(3)").IsRequired().ValueGeneratedNever().HasMaxLength(3);
			modelBuilder.Entity<Person_vStateProvinceCountryRegion>().Property(x=>x.CountryRegionName).HasColumnName("CountryRegionName").HasColumnType("NVarChar(50)").IsRequired().ValueGeneratedNever().HasMaxLength(50);
		}

		partial void Customize_Person_vStateProvinceCountryRegion(ModelBuilder modelBuilder);
		#endregion

		#region Sales_vStoreWithDemographics
		private void Map_Sales_vStoreWithDemographics(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Sales_vStoreWithDemographics>().ToTable("vStoreWithDemographics", "Sales");
			modelBuilder.Entity<Sales_vStoreWithDemographics>().HasNoKey();
			modelBuilder.Entity<Sales_vStoreWithDemographics>().Property(x=>x.CustomerID).HasColumnName("CustomerID").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Sales_vStoreWithDemographics>().Property(x=>x.Name).HasColumnName("Name").HasColumnType("NVarChar(50)").IsRequired().ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<Sales_vStoreWithDemographics>().Property(x=>x.ContactType).HasColumnName("ContactType").HasColumnType("NVarChar(50)").IsRequired().ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<Sales_vStoreWithDemographics>().Property(x=>x.Title).HasColumnName("Title").HasColumnType("NVarChar(8)").ValueGeneratedNever().HasMaxLength(8);
			modelBuilder.Entity<Sales_vStoreWithDemographics>().Property(x=>x.FirstName).HasColumnName("FirstName").HasColumnType("NVarChar(50)").IsRequired().ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<Sales_vStoreWithDemographics>().Property(x=>x.MiddleName).HasColumnName("MiddleName").HasColumnType("NVarChar(50)").ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<Sales_vStoreWithDemographics>().Property(x=>x.LastName).HasColumnName("LastName").HasColumnType("NVarChar(50)").IsRequired().ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<Sales_vStoreWithDemographics>().Property(x=>x.Suffix).HasColumnName("Suffix").HasColumnType("NVarChar(10)").ValueGeneratedNever().HasMaxLength(10);
			modelBuilder.Entity<Sales_vStoreWithDemographics>().Property(x=>x.Phone).HasColumnName("Phone").HasColumnType("NVarChar(25)").ValueGeneratedNever().HasMaxLength(25);
			modelBuilder.Entity<Sales_vStoreWithDemographics>().Property(x=>x.EmailAddress).HasColumnName("EmailAddress").HasColumnType("NVarChar(50)").ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<Sales_vStoreWithDemographics>().Property(x=>x.EmailPromotion).HasColumnName("EmailPromotion").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Sales_vStoreWithDemographics>().Property(x=>x.AddressType).HasColumnName("AddressType").HasColumnType("NVarChar(50)").IsRequired().ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<Sales_vStoreWithDemographics>().Property(x=>x.AddressLine1).HasColumnName("AddressLine1").HasColumnType("NVarChar(60)").IsRequired().ValueGeneratedNever().HasMaxLength(60);
			modelBuilder.Entity<Sales_vStoreWithDemographics>().Property(x=>x.AddressLine2).HasColumnName("AddressLine2").HasColumnType("NVarChar(60)").ValueGeneratedNever().HasMaxLength(60);
			modelBuilder.Entity<Sales_vStoreWithDemographics>().Property(x=>x.City).HasColumnName("City").HasColumnType("NVarChar(30)").IsRequired().ValueGeneratedNever().HasMaxLength(30);
			modelBuilder.Entity<Sales_vStoreWithDemographics>().Property(x=>x.StateProvinceName).HasColumnName("StateProvinceName").HasColumnType("NVarChar(50)").IsRequired().ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<Sales_vStoreWithDemographics>().Property(x=>x.PostalCode).HasColumnName("PostalCode").HasColumnType("NVarChar(15)").IsRequired().ValueGeneratedNever().HasMaxLength(15);
			modelBuilder.Entity<Sales_vStoreWithDemographics>().Property(x=>x.CountryRegionName).HasColumnName("CountryRegionName").HasColumnType("NVarChar(50)").IsRequired().ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<Sales_vStoreWithDemographics>().Property(x=>x.AnnualSales).HasColumnName("AnnualSales").HasColumnType("Money").ValueGeneratedNever();
			modelBuilder.Entity<Sales_vStoreWithDemographics>().Property(x=>x.AnnualRevenue).HasColumnName("AnnualRevenue").HasColumnType("Money").ValueGeneratedNever();
			modelBuilder.Entity<Sales_vStoreWithDemographics>().Property(x=>x.BankName).HasColumnName("BankName").HasColumnType("NVarChar(50)").ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<Sales_vStoreWithDemographics>().Property(x=>x.BusinessType).HasColumnName("BusinessType").HasColumnType("NVarChar(5)").ValueGeneratedNever().HasMaxLength(5);
			modelBuilder.Entity<Sales_vStoreWithDemographics>().Property(x=>x.YearOpened).HasColumnName("YearOpened").HasColumnType("Int").ValueGeneratedNever();
			modelBuilder.Entity<Sales_vStoreWithDemographics>().Property(x=>x.Specialty).HasColumnName("Specialty").HasColumnType("NVarChar(50)").ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<Sales_vStoreWithDemographics>().Property(x=>x.SquareFeet).HasColumnName("SquareFeet").HasColumnType("Int").ValueGeneratedNever();
			modelBuilder.Entity<Sales_vStoreWithDemographics>().Property(x=>x.Brands).HasColumnName("Brands").HasColumnType("NVarChar(30)").ValueGeneratedNever().HasMaxLength(30);
			modelBuilder.Entity<Sales_vStoreWithDemographics>().Property(x=>x.Internet).HasColumnName("Internet").HasColumnType("NVarChar(30)").ValueGeneratedNever().HasMaxLength(30);
			modelBuilder.Entity<Sales_vStoreWithDemographics>().Property(x=>x.NumberEmployees).HasColumnName("NumberEmployees").HasColumnType("Int").ValueGeneratedNever();
		}

		partial void Customize_Sales_vStoreWithDemographics(ModelBuilder modelBuilder);
		#endregion

		#region Purchasing_vVendor
		private void Map_Purchasing_vVendor(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Purchasing_vVendor>().ToTable("vVendor", "Purchasing");
			modelBuilder.Entity<Purchasing_vVendor>().HasNoKey();
			modelBuilder.Entity<Purchasing_vVendor>().Property(x=>x.VendorID).HasColumnName("VendorID").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Purchasing_vVendor>().Property(x=>x.Name).HasColumnName("Name").HasColumnType("NVarChar(50)").IsRequired().ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<Purchasing_vVendor>().Property(x=>x.ContactType).HasColumnName("ContactType").HasColumnType("NVarChar(50)").IsRequired().ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<Purchasing_vVendor>().Property(x=>x.Title).HasColumnName("Title").HasColumnType("NVarChar(8)").ValueGeneratedNever().HasMaxLength(8);
			modelBuilder.Entity<Purchasing_vVendor>().Property(x=>x.FirstName).HasColumnName("FirstName").HasColumnType("NVarChar(50)").IsRequired().ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<Purchasing_vVendor>().Property(x=>x.MiddleName).HasColumnName("MiddleName").HasColumnType("NVarChar(50)").ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<Purchasing_vVendor>().Property(x=>x.LastName).HasColumnName("LastName").HasColumnType("NVarChar(50)").IsRequired().ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<Purchasing_vVendor>().Property(x=>x.Suffix).HasColumnName("Suffix").HasColumnType("NVarChar(10)").ValueGeneratedNever().HasMaxLength(10);
			modelBuilder.Entity<Purchasing_vVendor>().Property(x=>x.Phone).HasColumnName("Phone").HasColumnType("NVarChar(25)").ValueGeneratedNever().HasMaxLength(25);
			modelBuilder.Entity<Purchasing_vVendor>().Property(x=>x.EmailAddress).HasColumnName("EmailAddress").HasColumnType("NVarChar(50)").ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<Purchasing_vVendor>().Property(x=>x.EmailPromotion).HasColumnName("EmailPromotion").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Purchasing_vVendor>().Property(x=>x.AddressLine1).HasColumnName("AddressLine1").HasColumnType("NVarChar(60)").IsRequired().ValueGeneratedNever().HasMaxLength(60);
			modelBuilder.Entity<Purchasing_vVendor>().Property(x=>x.AddressLine2).HasColumnName("AddressLine2").HasColumnType("NVarChar(60)").ValueGeneratedNever().HasMaxLength(60);
			modelBuilder.Entity<Purchasing_vVendor>().Property(x=>x.City).HasColumnName("City").HasColumnType("NVarChar(30)").IsRequired().ValueGeneratedNever().HasMaxLength(30);
			modelBuilder.Entity<Purchasing_vVendor>().Property(x=>x.StateProvinceName).HasColumnName("StateProvinceName").HasColumnType("NVarChar(50)").IsRequired().ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<Purchasing_vVendor>().Property(x=>x.PostalCode).HasColumnName("PostalCode").HasColumnType("NVarChar(15)").IsRequired().ValueGeneratedNever().HasMaxLength(15);
			modelBuilder.Entity<Purchasing_vVendor>().Property(x=>x.CountryRegionName).HasColumnName("CountryRegionName").HasColumnType("NVarChar(50)").IsRequired().ValueGeneratedNever().HasMaxLength(50);
		}

		partial void Customize_Purchasing_vVendor(ModelBuilder modelBuilder);
		#endregion

		#region Production_WorkOrder
		private void Map_Production_WorkOrder(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Production_WorkOrder>().ToTable("WorkOrder", "Production");
			modelBuilder.Entity<Production_WorkOrder>().HasKey(x=>x.WorkOrderID);
			modelBuilder.Entity<Production_WorkOrder>().Property(x=>x.WorkOrderID).HasColumnName("WorkOrderID").HasColumnType("Int").IsRequired().ValueGeneratedOnAdd();
			modelBuilder.Entity<Production_WorkOrder>().Property(x=>x.ProductID).HasColumnName("ProductID").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Production_WorkOrder>().Property(x=>x.OrderQty).HasColumnName("OrderQty").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Production_WorkOrder>().Property(x=>x.StockedQty).HasColumnName("StockedQty").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Production_WorkOrder>().Property(x=>x.ScrappedQty).HasColumnName("ScrappedQty").HasColumnType("SmallInt").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Production_WorkOrder>().Property(x=>x.StartDate).HasColumnName("StartDate").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Production_WorkOrder>().Property(x=>x.EndDate).HasColumnName("EndDate").HasColumnType("DateTime").ValueGeneratedNever();
			modelBuilder.Entity<Production_WorkOrder>().Property(x=>x.DueDate).HasColumnName("DueDate").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Production_WorkOrder>().Property(x=>x.ScrapReasonID).HasColumnName("ScrapReasonID").HasColumnType("SmallInt").ValueGeneratedNever();
			modelBuilder.Entity<Production_WorkOrder>().Property(x=>x.ModifiedDate).HasColumnName("ModifiedDate").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
		}

		partial void Customize_Production_WorkOrder(ModelBuilder modelBuilder);
		#endregion

		#region Production_WorkOrderRouting
		private void Map_Production_WorkOrderRouting(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Production_WorkOrderRouting>().ToTable("WorkOrderRouting", "Production");
			modelBuilder.Entity<Production_WorkOrderRouting>().HasKey("WorkOrderID", "ProductID", "OperationSequence");
			modelBuilder.Entity<Production_WorkOrderRouting>().Property(x=>x.WorkOrderID).HasColumnName("WorkOrderID").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Production_WorkOrderRouting>().Property(x=>x.ProductID).HasColumnName("ProductID").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Production_WorkOrderRouting>().Property(x=>x.OperationSequence).HasColumnName("OperationSequence").HasColumnType("SmallInt").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Production_WorkOrderRouting>().Property(x=>x.LocationID).HasColumnName("LocationID").HasColumnType("SmallInt").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Production_WorkOrderRouting>().Property(x=>x.ScheduledStartDate).HasColumnName("ScheduledStartDate").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Production_WorkOrderRouting>().Property(x=>x.ScheduledEndDate).HasColumnName("ScheduledEndDate").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Production_WorkOrderRouting>().Property(x=>x.ActualStartDate).HasColumnName("ActualStartDate").HasColumnType("DateTime").ValueGeneratedNever();
			modelBuilder.Entity<Production_WorkOrderRouting>().Property(x=>x.ActualEndDate).HasColumnName("ActualEndDate").HasColumnType("DateTime").ValueGeneratedNever();
			modelBuilder.Entity<Production_WorkOrderRouting>().Property(x=>x.ActualResourceHrs).HasColumnName("ActualResourceHrs").HasColumnType("Decimal(9,4)").ValueGeneratedNever().HasMaxLength(9);
			modelBuilder.Entity<Production_WorkOrderRouting>().Property(x=>x.PlannedCost).HasColumnName("PlannedCost").HasColumnType("Money").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<Production_WorkOrderRouting>().Property(x=>x.ActualCost).HasColumnName("ActualCost").HasColumnType("Money").ValueGeneratedNever();
			modelBuilder.Entity<Production_WorkOrderRouting>().Property(x=>x.ModifiedDate).HasColumnName("ModifiedDate").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
		}

		partial void Customize_Production_WorkOrderRouting(ModelBuilder modelBuilder);
		#endregion

		#endregion

		#region Relationships mapping
		private void RelationshipsMapping(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Person_Address>().HasMany(x=>x.HumanResources_EmployeeAddressList).WithOne(x=>x.Person_Address).HasForeignKey(x=>x.AddressID).IsRequired(true);
			modelBuilder.Entity<Person_Address>().HasOne(x=>x.Person_StateProvince).WithMany(x=>x.Person_AddressList).HasForeignKey(x=>x.StateProvinceID).IsRequired(true);
			modelBuilder.Entity<Person_Address>().HasMany(x=>x.Purchasing_VendorAddressList).WithOne(x=>x.Person_Address).HasForeignKey(x=>x.AddressID).IsRequired(true);
			modelBuilder.Entity<Person_Address>().HasMany(x=>x.Sales_CustomerAddressList).WithOne(x=>x.Person_Address).HasForeignKey(x=>x.AddressID).IsRequired(true);
			modelBuilder.Entity<Person_Address>().HasMany(x=>x.Sales_SalesOrderHeaderList).WithOne(x=>x.Person_Address).HasForeignKey(x=>x.BillToAddressID).IsRequired(true);
			modelBuilder.Entity<Person_Address>().HasMany(x=>x.AddressList).WithOne(x=>x.ShipToAddress).HasForeignKey(x=>x.ShipToAddressID).IsRequired(true);

			modelBuilder.Entity<Person_AddressType>().HasMany(x=>x.Purchasing_VendorAddressList).WithOne(x=>x.Person_AddressType).HasForeignKey(x=>x.AddressTypeID).IsRequired(true);
			modelBuilder.Entity<Person_AddressType>().HasMany(x=>x.Sales_CustomerAddressList).WithOne(x=>x.Person_AddressType).HasForeignKey(x=>x.AddressTypeID).IsRequired(true);

			modelBuilder.Entity<Production_BillOfMaterials>().HasOne(x=>x.Production_Product).WithMany(x=>x.Production_BillOfMaterialsList).HasForeignKey(x=>x.ComponentID).IsRequired(true);
			modelBuilder.Entity<Production_BillOfMaterials>().HasOne(x=>x.ProductAssembly).WithMany(x=>x.ProductList).HasForeignKey(x=>x.ProductAssemblyID).IsRequired(false);
			modelBuilder.Entity<Production_BillOfMaterials>().HasOne(x=>x.Production_UnitMeasure).WithMany(x=>x.Production_BillOfMaterialsList).HasForeignKey(x=>x.UnitMeasureCode).IsRequired(true);

			modelBuilder.Entity<Person_Contact>().HasMany(x=>x.HumanResources_EmployeeList).WithOne(x=>x.Person_Contact).HasForeignKey(x=>x.ContactID).IsRequired(true);
			modelBuilder.Entity<Person_Contact>().HasMany(x=>x.Purchasing_VendorContactList).WithOne(x=>x.Person_Contact).HasForeignKey(x=>x.ContactID).IsRequired(true);
			modelBuilder.Entity<Person_Contact>().HasMany(x=>x.Sales_ContactCreditCardList).WithOne(x=>x.Person_Contact).HasForeignKey(x=>x.ContactID).IsRequired(true);
			modelBuilder.Entity<Person_Contact>().HasMany(x=>x.Sales_IndividualList).WithOne(x=>x.Person_Contact).HasForeignKey(x=>x.ContactID).IsRequired(true);
			modelBuilder.Entity<Person_Contact>().HasMany(x=>x.Sales_SalesOrderHeaderList).WithOne(x=>x.Person_Contact).HasForeignKey(x=>x.ContactID).IsRequired(true);
			modelBuilder.Entity<Person_Contact>().HasMany(x=>x.Sales_StoreContactList).WithOne(x=>x.Person_Contact).HasForeignKey(x=>x.ContactID).IsRequired(true);

			modelBuilder.Entity<Sales_ContactCreditCard>().HasOne(x=>x.Person_Contact).WithMany(x=>x.Sales_ContactCreditCardList).HasForeignKey(x=>x.ContactID).IsRequired(true);
			modelBuilder.Entity<Sales_ContactCreditCard>().HasOne(x=>x.Sales_CreditCard).WithMany(x=>x.Sales_ContactCreditCardList).HasForeignKey(x=>x.CreditCardID).IsRequired(true);

			modelBuilder.Entity<Person_ContactType>().HasMany(x=>x.Purchasing_VendorContactList).WithOne(x=>x.Person_ContactType).HasForeignKey(x=>x.ContactTypeID).IsRequired(true);
			modelBuilder.Entity<Person_ContactType>().HasMany(x=>x.Sales_StoreContactList).WithOne(x=>x.Person_ContactType).HasForeignKey(x=>x.ContactTypeID).IsRequired(true);

			modelBuilder.Entity<Person_CountryRegion>().HasMany(x=>x.Person_StateProvinceList).WithOne(x=>x.Person_CountryRegion).HasForeignKey(x=>x.CountryRegionCode).IsRequired(true);
			modelBuilder.Entity<Person_CountryRegion>().HasMany(x=>x.Sales_CountryRegionCurrencyList).WithOne(x=>x.Person_CountryRegion).HasForeignKey(x=>x.CountryRegionCode).IsRequired(true);

			modelBuilder.Entity<Sales_CountryRegionCurrency>().HasOne(x=>x.Person_CountryRegion).WithMany(x=>x.Sales_CountryRegionCurrencyList).HasForeignKey(x=>x.CountryRegionCode).IsRequired(true);
			modelBuilder.Entity<Sales_CountryRegionCurrency>().HasOne(x=>x.Sales_Currency).WithMany(x=>x.Sales_CountryRegionCurrencyList).HasForeignKey(x=>x.CurrencyCode).IsRequired(true);

			modelBuilder.Entity<Sales_CreditCard>().HasMany(x=>x.Sales_ContactCreditCardList).WithOne(x=>x.Sales_CreditCard).HasForeignKey(x=>x.CreditCardID).IsRequired(true);
			modelBuilder.Entity<Sales_CreditCard>().HasMany(x=>x.Sales_SalesOrderHeaderList).WithOne(x=>x.Sales_CreditCard).HasForeignKey(x=>x.CreditCardID).IsRequired(false);

			modelBuilder.Entity<Production_Culture>().HasMany(x=>x.Production_ProductModelProductDescriptionCultureList).WithOne(x=>x.Production_Culture).HasForeignKey(x=>x.CultureID).IsRequired(true);

			modelBuilder.Entity<Sales_Currency>().HasMany(x=>x.Sales_CountryRegionCurrencyList).WithOne(x=>x.Sales_Currency).HasForeignKey(x=>x.CurrencyCode).IsRequired(true);
			modelBuilder.Entity<Sales_Currency>().HasMany(x=>x.Sales_CurrencyRateList).WithOne(x=>x.Sales_Currency).HasForeignKey(x=>x.FromCurrencyCode).IsRequired(true);
			modelBuilder.Entity<Sales_Currency>().HasMany(x=>x.CurrencyCodeSales_CurrencyRateList).WithOne(x=>x.ToCurrencyCodeSales_Currency).HasForeignKey(x=>x.ToCurrencyCode).IsRequired(true);

			modelBuilder.Entity<Sales_CurrencyRate>().HasOne(x=>x.Sales_Currency).WithMany(x=>x.Sales_CurrencyRateList).HasForeignKey(x=>x.FromCurrencyCode).IsRequired(true);
			modelBuilder.Entity<Sales_CurrencyRate>().HasOne(x=>x.ToCurrencyCodeSales_Currency).WithMany(x=>x.CurrencyCodeSales_CurrencyRateList).HasForeignKey(x=>x.ToCurrencyCode).IsRequired(true);
			modelBuilder.Entity<Sales_CurrencyRate>().HasMany(x=>x.Sales_SalesOrderHeaderList).WithOne(x=>x.Sales_CurrencyRate).HasForeignKey(x=>x.CurrencyRateID).IsRequired(false);

			modelBuilder.Entity<Sales_Customer>().HasOne(x=>x.Sales_SalesTerritory).WithMany(x=>x.Sales_CustomerList).HasForeignKey(x=>x.TerritoryID).IsRequired(false);
			modelBuilder.Entity<Sales_Customer>().HasMany(x=>x.Sales_CustomerAddressList).WithOne(x=>x.Sales_Customer).HasForeignKey(x=>x.CustomerID).IsRequired(true);
			modelBuilder.Entity<Sales_Customer>().HasOne(x=>x.Sales_Individual).WithOne(x=>x.Sales_Customer).HasForeignKey<Sales_Individual>(x=>x.CustomerID).IsRequired(true);
			modelBuilder.Entity<Sales_Customer>().HasMany(x=>x.Sales_SalesOrderHeaderList).WithOne(x=>x.Sales_Customer).HasForeignKey(x=>x.CustomerID).IsRequired(true);
			modelBuilder.Entity<Sales_Customer>().HasOne(x=>x.Sales_Store).WithOne(x=>x.Sales_Customer).HasForeignKey<Sales_Store>(x=>x.CustomerID).IsRequired(true);

			modelBuilder.Entity<Sales_CustomerAddress>().HasOne(x=>x.Person_Address).WithMany(x=>x.Sales_CustomerAddressList).HasForeignKey(x=>x.AddressID).IsRequired(true);
			modelBuilder.Entity<Sales_CustomerAddress>().HasOne(x=>x.Person_AddressType).WithMany(x=>x.Sales_CustomerAddressList).HasForeignKey(x=>x.AddressTypeID).IsRequired(true);
			modelBuilder.Entity<Sales_CustomerAddress>().HasOne(x=>x.Sales_Customer).WithMany(x=>x.Sales_CustomerAddressList).HasForeignKey(x=>x.CustomerID).IsRequired(true);

			modelBuilder.Entity<HumanResources_Department>().HasMany(x=>x.HumanResources_EmployeeDepartmentHistoryList).WithOne(x=>x.HumanResources_Department).HasForeignKey(x=>x.DepartmentID).IsRequired(true);

			modelBuilder.Entity<Production_Document>().HasMany(x=>x.Production_ProductDocumentList).WithOne(x=>x.Production_Document).HasForeignKey(x=>x.DocumentID).IsRequired(true);

			modelBuilder.Entity<HumanResources_Employee>().HasOne(x=>x.Person_Contact).WithMany(x=>x.HumanResources_EmployeeList).HasForeignKey(x=>x.ContactID).IsRequired(true);
			modelBuilder.Entity<HumanResources_Employee>().HasOne(x=>x.Manager).WithMany(x=>x.EmployeeList).HasForeignKey(x=>x.ManagerID).IsRequired(false);
			modelBuilder.Entity<HumanResources_Employee>().HasMany(x=>x.EmployeeList).WithOne(x=>x.Manager).HasForeignKey(x=>x.ManagerID).IsRequired(false);
			modelBuilder.Entity<HumanResources_Employee>().HasMany(x=>x.HumanResources_EmployeeAddressList).WithOne(x=>x.HumanResources_Employee).HasForeignKey(x=>x.EmployeeID).IsRequired(true);
			modelBuilder.Entity<HumanResources_Employee>().HasMany(x=>x.HumanResources_EmployeeDepartmentHistoryList).WithOne(x=>x.HumanResources_Employee).HasForeignKey(x=>x.EmployeeID).IsRequired(true);
			modelBuilder.Entity<HumanResources_Employee>().HasMany(x=>x.HumanResources_EmployeePayHistoryList).WithOne(x=>x.HumanResources_Employee).HasForeignKey(x=>x.EmployeeID).IsRequired(true);
			modelBuilder.Entity<HumanResources_Employee>().HasMany(x=>x.HumanResources_JobCandidateList).WithOne(x=>x.HumanResources_Employee).HasForeignKey(x=>x.EmployeeID).IsRequired(false);
			modelBuilder.Entity<HumanResources_Employee>().HasMany(x=>x.Purchasing_PurchaseOrderHeaderList).WithOne(x=>x.HumanResources_Employee).HasForeignKey(x=>x.EmployeeID).IsRequired(true);
			modelBuilder.Entity<HumanResources_Employee>().HasOne(x=>x.Sales_SalesPerson).WithOne(x=>x.HumanResources_Employee).HasForeignKey<Sales_SalesPerson>(x=>x.SalesPersonID).IsRequired(true);

			modelBuilder.Entity<HumanResources_EmployeeAddress>().HasOne(x=>x.Person_Address).WithMany(x=>x.HumanResources_EmployeeAddressList).HasForeignKey(x=>x.AddressID).IsRequired(true);
			modelBuilder.Entity<HumanResources_EmployeeAddress>().HasOne(x=>x.HumanResources_Employee).WithMany(x=>x.HumanResources_EmployeeAddressList).HasForeignKey(x=>x.EmployeeID).IsRequired(true);

			modelBuilder.Entity<HumanResources_EmployeeDepartmentHistory>().HasOne(x=>x.HumanResources_Department).WithMany(x=>x.HumanResources_EmployeeDepartmentHistoryList).HasForeignKey(x=>x.DepartmentID).IsRequired(true);
			modelBuilder.Entity<HumanResources_EmployeeDepartmentHistory>().HasOne(x=>x.HumanResources_Employee).WithMany(x=>x.HumanResources_EmployeeDepartmentHistoryList).HasForeignKey(x=>x.EmployeeID).IsRequired(true);
			modelBuilder.Entity<HumanResources_EmployeeDepartmentHistory>().HasOne(x=>x.HumanResources_Shift).WithMany(x=>x.HumanResources_EmployeeDepartmentHistoryList).HasForeignKey(x=>x.ShiftID).IsRequired(true);

			modelBuilder.Entity<HumanResources_EmployeePayHistory>().HasOne(x=>x.HumanResources_Employee).WithMany(x=>x.HumanResources_EmployeePayHistoryList).HasForeignKey(x=>x.EmployeeID).IsRequired(true);

			modelBuilder.Entity<Production_Illustration>().HasMany(x=>x.Production_ProductModelIllustrationList).WithOne(x=>x.Production_Illustration).HasForeignKey(x=>x.IllustrationID).IsRequired(true);

			modelBuilder.Entity<Sales_Individual>().HasOne(x=>x.Person_Contact).WithMany(x=>x.Sales_IndividualList).HasForeignKey(x=>x.ContactID).IsRequired(true);
			modelBuilder.Entity<Sales_Individual>().HasOne(x=>x.Sales_Customer).WithOne(x=>x.Sales_Individual).HasForeignKey<Sales_Customer>(x=>x.CustomerID).IsRequired(true);

			modelBuilder.Entity<HumanResources_JobCandidate>().HasOne(x=>x.HumanResources_Employee).WithMany(x=>x.HumanResources_JobCandidateList).HasForeignKey(x=>x.EmployeeID).IsRequired(false);

			modelBuilder.Entity<Production_Location>().HasMany(x=>x.Production_ProductInventoryList).WithOne(x=>x.Production_Location).HasForeignKey(x=>x.LocationID).IsRequired(true);
			modelBuilder.Entity<Production_Location>().HasMany(x=>x.Production_WorkOrderRoutingList).WithOne(x=>x.Production_Location).HasForeignKey(x=>x.LocationID).IsRequired(true);

			modelBuilder.Entity<Production_Product>().HasMany(x=>x.Production_BillOfMaterialsList).WithOne(x=>x.Production_Product).HasForeignKey(x=>x.ComponentID).IsRequired(true);
			modelBuilder.Entity<Production_Product>().HasMany(x=>x.ProductList).WithOne(x=>x.ProductAssembly).HasForeignKey(x=>x.ProductAssemblyID).IsRequired(false);
			modelBuilder.Entity<Production_Product>().HasOne(x=>x.Production_ProductModel).WithMany(x=>x.Production_ProductList).HasForeignKey(x=>x.ProductModelID).IsRequired(false);
			modelBuilder.Entity<Production_Product>().HasOne(x=>x.Production_ProductSubcategory).WithMany(x=>x.Production_ProductList).HasForeignKey(x=>x.ProductSubcategoryID).IsRequired(false);
			modelBuilder.Entity<Production_Product>().HasOne(x=>x.Production_UnitMeasure).WithMany(x=>x.Production_ProductList).HasForeignKey(x=>x.SizeUnitMeasureCode).IsRequired(false);
			modelBuilder.Entity<Production_Product>().HasOne(x=>x.WeightUnitMeasureCodeProduction_UnitMeasure).WithMany(x=>x.UnitMeasureCodeProduction_ProductList).HasForeignKey(x=>x.WeightUnitMeasureCode).IsRequired(false);
			modelBuilder.Entity<Production_Product>().HasMany(x=>x.Production_ProductCostHistoryList).WithOne(x=>x.Production_Product).HasForeignKey(x=>x.ProductID).IsRequired(true);
			modelBuilder.Entity<Production_Product>().HasMany(x=>x.Production_ProductDocumentList).WithOne(x=>x.Production_Product).HasForeignKey(x=>x.ProductID).IsRequired(true);
			modelBuilder.Entity<Production_Product>().HasMany(x=>x.Production_ProductInventoryList).WithOne(x=>x.Production_Product).HasForeignKey(x=>x.ProductID).IsRequired(true);
			modelBuilder.Entity<Production_Product>().HasMany(x=>x.Production_ProductListPriceHistoryList).WithOne(x=>x.Production_Product).HasForeignKey(x=>x.ProductID).IsRequired(true);
			modelBuilder.Entity<Production_Product>().HasMany(x=>x.Production_ProductProductPhotoList).WithOne(x=>x.Production_Product).HasForeignKey(x=>x.ProductID).IsRequired(true);
			modelBuilder.Entity<Production_Product>().HasMany(x=>x.Production_ProductReviewList).WithOne(x=>x.Production_Product).HasForeignKey(x=>x.ProductID).IsRequired(true);
			modelBuilder.Entity<Production_Product>().HasMany(x=>x.Production_TransactionHistoryList).WithOne(x=>x.Production_Product).HasForeignKey(x=>x.ProductID).IsRequired(true);
			modelBuilder.Entity<Production_Product>().HasMany(x=>x.Production_WorkOrderList).WithOne(x=>x.Production_Product).HasForeignKey(x=>x.ProductID).IsRequired(true);
			modelBuilder.Entity<Production_Product>().HasMany(x=>x.Purchasing_ProductVendorList).WithOne(x=>x.Production_Product).HasForeignKey(x=>x.ProductID).IsRequired(true);
			modelBuilder.Entity<Production_Product>().HasMany(x=>x.Purchasing_PurchaseOrderDetailList).WithOne(x=>x.Production_Product).HasForeignKey(x=>x.ProductID).IsRequired(true);
			modelBuilder.Entity<Production_Product>().HasMany(x=>x.Sales_ShoppingCartItemList).WithOne(x=>x.Production_Product).HasForeignKey(x=>x.ProductID).IsRequired(true);
			modelBuilder.Entity<Production_Product>().HasMany(x=>x.Sales_SpecialOfferProductList).WithOne(x=>x.Production_Product).HasForeignKey(x=>x.ProductID).IsRequired(true);

			modelBuilder.Entity<Production_ProductCategory>().HasMany(x=>x.Production_ProductSubcategoryList).WithOne(x=>x.Production_ProductCategory).HasForeignKey(x=>x.ProductCategoryID).IsRequired(true);

			modelBuilder.Entity<Production_ProductCostHistory>().HasOne(x=>x.Production_Product).WithMany(x=>x.Production_ProductCostHistoryList).HasForeignKey(x=>x.ProductID).IsRequired(true);

			modelBuilder.Entity<Production_ProductDescription>().HasMany(x=>x.Production_ProductModelProductDescriptionCultureList).WithOne(x=>x.Production_ProductDescription).HasForeignKey(x=>x.ProductDescriptionID).IsRequired(true);

			modelBuilder.Entity<Production_ProductDocument>().HasOne(x=>x.Production_Document).WithMany(x=>x.Production_ProductDocumentList).HasForeignKey(x=>x.DocumentID).IsRequired(true);
			modelBuilder.Entity<Production_ProductDocument>().HasOne(x=>x.Production_Product).WithMany(x=>x.Production_ProductDocumentList).HasForeignKey(x=>x.ProductID).IsRequired(true);

			modelBuilder.Entity<Production_ProductInventory>().HasOne(x=>x.Production_Location).WithMany(x=>x.Production_ProductInventoryList).HasForeignKey(x=>x.LocationID).IsRequired(true);
			modelBuilder.Entity<Production_ProductInventory>().HasOne(x=>x.Production_Product).WithMany(x=>x.Production_ProductInventoryList).HasForeignKey(x=>x.ProductID).IsRequired(true);

			modelBuilder.Entity<Production_ProductListPriceHistory>().HasOne(x=>x.Production_Product).WithMany(x=>x.Production_ProductListPriceHistoryList).HasForeignKey(x=>x.ProductID).IsRequired(true);

			modelBuilder.Entity<Production_ProductModel>().HasMany(x=>x.Production_ProductList).WithOne(x=>x.Production_ProductModel).HasForeignKey(x=>x.ProductModelID).IsRequired(false);
			modelBuilder.Entity<Production_ProductModel>().HasMany(x=>x.Production_ProductModelIllustrationList).WithOne(x=>x.Production_ProductModel).HasForeignKey(x=>x.ProductModelID).IsRequired(true);
			modelBuilder.Entity<Production_ProductModel>().HasMany(x=>x.Production_ProductModelProductDescriptionCultureList).WithOne(x=>x.Production_ProductModel).HasForeignKey(x=>x.ProductModelID).IsRequired(true);

			modelBuilder.Entity<Production_ProductModelIllustration>().HasOne(x=>x.Production_Illustration).WithMany(x=>x.Production_ProductModelIllustrationList).HasForeignKey(x=>x.IllustrationID).IsRequired(true);
			modelBuilder.Entity<Production_ProductModelIllustration>().HasOne(x=>x.Production_ProductModel).WithMany(x=>x.Production_ProductModelIllustrationList).HasForeignKey(x=>x.ProductModelID).IsRequired(true);

			modelBuilder.Entity<Production_ProductModelProductDescriptionCulture>().HasOne(x=>x.Production_Culture).WithMany(x=>x.Production_ProductModelProductDescriptionCultureList).HasForeignKey(x=>x.CultureID).IsRequired(true);
			modelBuilder.Entity<Production_ProductModelProductDescriptionCulture>().HasOne(x=>x.Production_ProductDescription).WithMany(x=>x.Production_ProductModelProductDescriptionCultureList).HasForeignKey(x=>x.ProductDescriptionID).IsRequired(true);
			modelBuilder.Entity<Production_ProductModelProductDescriptionCulture>().HasOne(x=>x.Production_ProductModel).WithMany(x=>x.Production_ProductModelProductDescriptionCultureList).HasForeignKey(x=>x.ProductModelID).IsRequired(true);

			modelBuilder.Entity<Production_ProductPhoto>().HasMany(x=>x.Production_ProductProductPhotoList).WithOne(x=>x.Production_ProductPhoto).HasForeignKey(x=>x.ProductPhotoID).IsRequired(true);

			modelBuilder.Entity<Production_ProductProductPhoto>().HasOne(x=>x.Production_Product).WithMany(x=>x.Production_ProductProductPhotoList).HasForeignKey(x=>x.ProductID).IsRequired(true);
			modelBuilder.Entity<Production_ProductProductPhoto>().HasOne(x=>x.Production_ProductPhoto).WithMany(x=>x.Production_ProductProductPhotoList).HasForeignKey(x=>x.ProductPhotoID).IsRequired(true);

			modelBuilder.Entity<Production_ProductReview>().HasOne(x=>x.Production_Product).WithMany(x=>x.Production_ProductReviewList).HasForeignKey(x=>x.ProductID).IsRequired(true);

			modelBuilder.Entity<Production_ProductSubcategory>().HasMany(x=>x.Production_ProductList).WithOne(x=>x.Production_ProductSubcategory).HasForeignKey(x=>x.ProductSubcategoryID).IsRequired(false);
			modelBuilder.Entity<Production_ProductSubcategory>().HasOne(x=>x.Production_ProductCategory).WithMany(x=>x.Production_ProductSubcategoryList).HasForeignKey(x=>x.ProductCategoryID).IsRequired(true);

			modelBuilder.Entity<Purchasing_ProductVendor>().HasOne(x=>x.Production_Product).WithMany(x=>x.Purchasing_ProductVendorList).HasForeignKey(x=>x.ProductID).IsRequired(true);
			modelBuilder.Entity<Purchasing_ProductVendor>().HasOne(x=>x.Production_UnitMeasure).WithMany(x=>x.Purchasing_ProductVendorList).HasForeignKey(x=>x.UnitMeasureCode).IsRequired(true);
			modelBuilder.Entity<Purchasing_ProductVendor>().HasOne(x=>x.Purchasing_Vendor).WithMany(x=>x.Purchasing_ProductVendorList).HasForeignKey(x=>x.VendorID).IsRequired(true);

			modelBuilder.Entity<Purchasing_PurchaseOrderDetail>().HasOne(x=>x.Production_Product).WithMany(x=>x.Purchasing_PurchaseOrderDetailList).HasForeignKey(x=>x.ProductID).IsRequired(true);
			modelBuilder.Entity<Purchasing_PurchaseOrderDetail>().HasOne(x=>x.Purchasing_PurchaseOrderHeader).WithMany(x=>x.Purchasing_PurchaseOrderDetailList).HasForeignKey(x=>x.PurchaseOrderID).IsRequired(true);

			modelBuilder.Entity<Purchasing_PurchaseOrderHeader>().HasMany(x=>x.Purchasing_PurchaseOrderDetailList).WithOne(x=>x.Purchasing_PurchaseOrderHeader).HasForeignKey(x=>x.PurchaseOrderID).IsRequired(true);
			modelBuilder.Entity<Purchasing_PurchaseOrderHeader>().HasOne(x=>x.HumanResources_Employee).WithMany(x=>x.Purchasing_PurchaseOrderHeaderList).HasForeignKey(x=>x.EmployeeID).IsRequired(true);
			modelBuilder.Entity<Purchasing_PurchaseOrderHeader>().HasOne(x=>x.Purchasing_ShipMethod).WithMany(x=>x.Purchasing_PurchaseOrderHeaderList).HasForeignKey(x=>x.ShipMethodID).IsRequired(true);
			modelBuilder.Entity<Purchasing_PurchaseOrderHeader>().HasOne(x=>x.Purchasing_Vendor).WithMany(x=>x.Purchasing_PurchaseOrderHeaderList).HasForeignKey(x=>x.VendorID).IsRequired(true);

			modelBuilder.Entity<Sales_SalesOrderDetail>().HasOne(x=>x.Sales_SalesOrderHeader).WithMany(x=>x.Sales_SalesOrderDetailList).HasForeignKey(x=>x.SalesOrderID).IsRequired(true).OnDelete(DeleteBehavior.Cascade);
			modelBuilder.Entity<Sales_SalesOrderDetail>().HasOne(x=>x.Sales_SpecialOfferProduct).WithMany(x=>x.Sales_SalesOrderDetailList).HasForeignKey(x=>x.SpecialOfferID).IsRequired(true);

			modelBuilder.Entity<Sales_SalesOrderHeader>().HasMany(x=>x.Sales_SalesOrderDetailList).WithOne(x=>x.Sales_SalesOrderHeader).HasForeignKey(x=>x.SalesOrderID).IsRequired(true).OnDelete(DeleteBehavior.Cascade);
			modelBuilder.Entity<Sales_SalesOrderHeader>().HasOne(x=>x.Person_Address).WithMany(x=>x.Sales_SalesOrderHeaderList).HasForeignKey(x=>x.BillToAddressID).IsRequired(true);
			modelBuilder.Entity<Sales_SalesOrderHeader>().HasOne(x=>x.ShipToAddress).WithMany(x=>x.AddressList).HasForeignKey(x=>x.ShipToAddressID).IsRequired(true);
			modelBuilder.Entity<Sales_SalesOrderHeader>().HasOne(x=>x.Person_Contact).WithMany(x=>x.Sales_SalesOrderHeaderList).HasForeignKey(x=>x.ContactID).IsRequired(true);
			modelBuilder.Entity<Sales_SalesOrderHeader>().HasOne(x=>x.Sales_CreditCard).WithMany(x=>x.Sales_SalesOrderHeaderList).HasForeignKey(x=>x.CreditCardID).IsRequired(false);
			modelBuilder.Entity<Sales_SalesOrderHeader>().HasOne(x=>x.Sales_CurrencyRate).WithMany(x=>x.Sales_SalesOrderHeaderList).HasForeignKey(x=>x.CurrencyRateID).IsRequired(false);
			modelBuilder.Entity<Sales_SalesOrderHeader>().HasOne(x=>x.Sales_Customer).WithMany(x=>x.Sales_SalesOrderHeaderList).HasForeignKey(x=>x.CustomerID).IsRequired(true);
			modelBuilder.Entity<Sales_SalesOrderHeader>().HasOne(x=>x.Sales_SalesPerson).WithMany(x=>x.Sales_SalesOrderHeaderList).HasForeignKey(x=>x.SalesPersonID).IsRequired(false);
			modelBuilder.Entity<Sales_SalesOrderHeader>().HasOne(x=>x.Sales_SalesTerritory).WithMany(x=>x.Sales_SalesOrderHeaderList).HasForeignKey(x=>x.TerritoryID).IsRequired(false);
			modelBuilder.Entity<Sales_SalesOrderHeader>().HasOne(x=>x.Purchasing_ShipMethod).WithMany(x=>x.Sales_SalesOrderHeaderList).HasForeignKey(x=>x.ShipMethodID).IsRequired(true);
			modelBuilder.Entity<Sales_SalesOrderHeader>().HasMany(x=>x.Sales_SalesOrderHeaderSalesReasonList).WithOne(x=>x.Sales_SalesOrderHeader).HasForeignKey(x=>x.SalesOrderID).IsRequired(true).OnDelete(DeleteBehavior.Cascade);

			modelBuilder.Entity<Sales_SalesOrderHeaderSalesReason>().HasOne(x=>x.Sales_SalesOrderHeader).WithMany(x=>x.Sales_SalesOrderHeaderSalesReasonList).HasForeignKey(x=>x.SalesOrderID).IsRequired(true).OnDelete(DeleteBehavior.Cascade);
			modelBuilder.Entity<Sales_SalesOrderHeaderSalesReason>().HasOne(x=>x.Sales_SalesReason).WithMany(x=>x.Sales_SalesOrderHeaderSalesReasonList).HasForeignKey(x=>x.SalesReasonID).IsRequired(true);

			modelBuilder.Entity<Sales_SalesPerson>().HasMany(x=>x.Sales_SalesOrderHeaderList).WithOne(x=>x.Sales_SalesPerson).HasForeignKey(x=>x.SalesPersonID).IsRequired(false);
			modelBuilder.Entity<Sales_SalesPerson>().HasOne(x=>x.HumanResources_Employee).WithOne(x=>x.Sales_SalesPerson).HasForeignKey<HumanResources_Employee>(x=>x.EmployeeID).IsRequired(true);
			modelBuilder.Entity<Sales_SalesPerson>().HasOne(x=>x.Sales_SalesTerritory).WithMany(x=>x.Sales_SalesPersonList).HasForeignKey(x=>x.TerritoryID).IsRequired(false);
			modelBuilder.Entity<Sales_SalesPerson>().HasMany(x=>x.Sales_SalesPersonQuotaHistoryList).WithOne(x=>x.Sales_SalesPerson).HasForeignKey(x=>x.SalesPersonID).IsRequired(true);
			modelBuilder.Entity<Sales_SalesPerson>().HasMany(x=>x.Sales_SalesTerritoryHistoryList).WithOne(x=>x.Sales_SalesPerson).HasForeignKey(x=>x.SalesPersonID).IsRequired(true);
			modelBuilder.Entity<Sales_SalesPerson>().HasMany(x=>x.Sales_StoreList).WithOne(x=>x.Sales_SalesPerson).HasForeignKey(x=>x.SalesPersonID).IsRequired(false);

			modelBuilder.Entity<Sales_SalesPersonQuotaHistory>().HasOne(x=>x.Sales_SalesPerson).WithMany(x=>x.Sales_SalesPersonQuotaHistoryList).HasForeignKey(x=>x.SalesPersonID).IsRequired(true);

			modelBuilder.Entity<Sales_SalesReason>().HasMany(x=>x.Sales_SalesOrderHeaderSalesReasonList).WithOne(x=>x.Sales_SalesReason).HasForeignKey(x=>x.SalesReasonID).IsRequired(true);

			modelBuilder.Entity<Sales_SalesTaxRate>().HasOne(x=>x.Person_StateProvince).WithMany(x=>x.Sales_SalesTaxRateList).HasForeignKey(x=>x.StateProvinceID).IsRequired(true);

			modelBuilder.Entity<Sales_SalesTerritory>().HasMany(x=>x.Person_StateProvinceList).WithOne(x=>x.Sales_SalesTerritory).HasForeignKey(x=>x.TerritoryID).IsRequired(true);
			modelBuilder.Entity<Sales_SalesTerritory>().HasMany(x=>x.Sales_CustomerList).WithOne(x=>x.Sales_SalesTerritory).HasForeignKey(x=>x.TerritoryID).IsRequired(false);
			modelBuilder.Entity<Sales_SalesTerritory>().HasMany(x=>x.Sales_SalesOrderHeaderList).WithOne(x=>x.Sales_SalesTerritory).HasForeignKey(x=>x.TerritoryID).IsRequired(false);
			modelBuilder.Entity<Sales_SalesTerritory>().HasMany(x=>x.Sales_SalesPersonList).WithOne(x=>x.Sales_SalesTerritory).HasForeignKey(x=>x.TerritoryID).IsRequired(false);
			modelBuilder.Entity<Sales_SalesTerritory>().HasMany(x=>x.Sales_SalesTerritoryHistoryList).WithOne(x=>x.Sales_SalesTerritory).HasForeignKey(x=>x.TerritoryID).IsRequired(true);

			modelBuilder.Entity<Sales_SalesTerritoryHistory>().HasOne(x=>x.Sales_SalesPerson).WithMany(x=>x.Sales_SalesTerritoryHistoryList).HasForeignKey(x=>x.SalesPersonID).IsRequired(true);
			modelBuilder.Entity<Sales_SalesTerritoryHistory>().HasOne(x=>x.Sales_SalesTerritory).WithMany(x=>x.Sales_SalesTerritoryHistoryList).HasForeignKey(x=>x.TerritoryID).IsRequired(true);

			modelBuilder.Entity<Production_ScrapReason>().HasMany(x=>x.Production_WorkOrderList).WithOne(x=>x.Production_ScrapReason).HasForeignKey(x=>x.ScrapReasonID).IsRequired(false);

			modelBuilder.Entity<HumanResources_Shift>().HasMany(x=>x.HumanResources_EmployeeDepartmentHistoryList).WithOne(x=>x.HumanResources_Shift).HasForeignKey(x=>x.ShiftID).IsRequired(true);

			modelBuilder.Entity<Purchasing_ShipMethod>().HasMany(x=>x.Purchasing_PurchaseOrderHeaderList).WithOne(x=>x.Purchasing_ShipMethod).HasForeignKey(x=>x.ShipMethodID).IsRequired(true);
			modelBuilder.Entity<Purchasing_ShipMethod>().HasMany(x=>x.Sales_SalesOrderHeaderList).WithOne(x=>x.Purchasing_ShipMethod).HasForeignKey(x=>x.ShipMethodID).IsRequired(true);

			modelBuilder.Entity<Sales_ShoppingCartItem>().HasOne(x=>x.Production_Product).WithMany(x=>x.Sales_ShoppingCartItemList).HasForeignKey(x=>x.ProductID).IsRequired(true);

			modelBuilder.Entity<Sales_SpecialOffer>().HasMany(x=>x.Sales_SpecialOfferProductList).WithOne(x=>x.Sales_SpecialOffer).HasForeignKey(x=>x.SpecialOfferID).IsRequired(true);

			modelBuilder.Entity<Sales_SpecialOfferProduct>().HasMany(x=>x.Sales_SalesOrderDetailList).WithOne(x=>x.Sales_SpecialOfferProduct).HasForeignKey(x=>x.SpecialOfferID).IsRequired(true);
			modelBuilder.Entity<Sales_SpecialOfferProduct>().HasOne(x=>x.Production_Product).WithMany(x=>x.Sales_SpecialOfferProductList).HasForeignKey(x=>x.ProductID).IsRequired(true);
			modelBuilder.Entity<Sales_SpecialOfferProduct>().HasOne(x=>x.Sales_SpecialOffer).WithMany(x=>x.Sales_SpecialOfferProductList).HasForeignKey(x=>x.SpecialOfferID).IsRequired(true);

			modelBuilder.Entity<Person_StateProvince>().HasMany(x=>x.Person_AddressList).WithOne(x=>x.Person_StateProvince).HasForeignKey(x=>x.StateProvinceID).IsRequired(true);
			modelBuilder.Entity<Person_StateProvince>().HasOne(x=>x.Person_CountryRegion).WithMany(x=>x.Person_StateProvinceList).HasForeignKey(x=>x.CountryRegionCode).IsRequired(true);
			modelBuilder.Entity<Person_StateProvince>().HasOne(x=>x.Sales_SalesTerritory).WithMany(x=>x.Person_StateProvinceList).HasForeignKey(x=>x.TerritoryID).IsRequired(true);
			modelBuilder.Entity<Person_StateProvince>().HasMany(x=>x.Sales_SalesTaxRateList).WithOne(x=>x.Person_StateProvince).HasForeignKey(x=>x.StateProvinceID).IsRequired(true);

			modelBuilder.Entity<Sales_Store>().HasOne(x=>x.Sales_Customer).WithOne(x=>x.Sales_Store).HasForeignKey<Sales_Customer>(x=>x.CustomerID).IsRequired(true);
			modelBuilder.Entity<Sales_Store>().HasOne(x=>x.Sales_SalesPerson).WithMany(x=>x.Sales_StoreList).HasForeignKey(x=>x.SalesPersonID).IsRequired(false);
			modelBuilder.Entity<Sales_Store>().HasMany(x=>x.Sales_StoreContactList).WithOne(x=>x.Sales_Store).HasForeignKey(x=>x.CustomerID).IsRequired(true);

			modelBuilder.Entity<Sales_StoreContact>().HasOne(x=>x.Person_Contact).WithMany(x=>x.Sales_StoreContactList).HasForeignKey(x=>x.ContactID).IsRequired(true);
			modelBuilder.Entity<Sales_StoreContact>().HasOne(x=>x.Person_ContactType).WithMany(x=>x.Sales_StoreContactList).HasForeignKey(x=>x.ContactTypeID).IsRequired(true);
			modelBuilder.Entity<Sales_StoreContact>().HasOne(x=>x.Sales_Store).WithMany(x=>x.Sales_StoreContactList).HasForeignKey(x=>x.CustomerID).IsRequired(true);

			modelBuilder.Entity<Production_TransactionHistory>().HasOne(x=>x.Production_Product).WithMany(x=>x.Production_TransactionHistoryList).HasForeignKey(x=>x.ProductID).IsRequired(true);

			modelBuilder.Entity<Production_UnitMeasure>().HasMany(x=>x.Production_BillOfMaterialsList).WithOne(x=>x.Production_UnitMeasure).HasForeignKey(x=>x.UnitMeasureCode).IsRequired(true);
			modelBuilder.Entity<Production_UnitMeasure>().HasMany(x=>x.Production_ProductList).WithOne(x=>x.Production_UnitMeasure).HasForeignKey(x=>x.SizeUnitMeasureCode).IsRequired(false);
			modelBuilder.Entity<Production_UnitMeasure>().HasMany(x=>x.UnitMeasureCodeProduction_ProductList).WithOne(x=>x.WeightUnitMeasureCodeProduction_UnitMeasure).HasForeignKey(x=>x.WeightUnitMeasureCode).IsRequired(false);
			modelBuilder.Entity<Production_UnitMeasure>().HasMany(x=>x.Purchasing_ProductVendorList).WithOne(x=>x.Production_UnitMeasure).HasForeignKey(x=>x.UnitMeasureCode).IsRequired(true);

			modelBuilder.Entity<Purchasing_Vendor>().HasMany(x=>x.Purchasing_ProductVendorList).WithOne(x=>x.Purchasing_Vendor).HasForeignKey(x=>x.VendorID).IsRequired(true);
			modelBuilder.Entity<Purchasing_Vendor>().HasMany(x=>x.Purchasing_PurchaseOrderHeaderList).WithOne(x=>x.Purchasing_Vendor).HasForeignKey(x=>x.VendorID).IsRequired(true);
			modelBuilder.Entity<Purchasing_Vendor>().HasMany(x=>x.Purchasing_VendorAddressList).WithOne(x=>x.Purchasing_Vendor).HasForeignKey(x=>x.VendorID).IsRequired(true);
			modelBuilder.Entity<Purchasing_Vendor>().HasMany(x=>x.Purchasing_VendorContactList).WithOne(x=>x.Purchasing_Vendor).HasForeignKey(x=>x.VendorID).IsRequired(true);

			modelBuilder.Entity<Purchasing_VendorAddress>().HasOne(x=>x.Person_Address).WithMany(x=>x.Purchasing_VendorAddressList).HasForeignKey(x=>x.AddressID).IsRequired(true);
			modelBuilder.Entity<Purchasing_VendorAddress>().HasOne(x=>x.Person_AddressType).WithMany(x=>x.Purchasing_VendorAddressList).HasForeignKey(x=>x.AddressTypeID).IsRequired(true);
			modelBuilder.Entity<Purchasing_VendorAddress>().HasOne(x=>x.Purchasing_Vendor).WithMany(x=>x.Purchasing_VendorAddressList).HasForeignKey(x=>x.VendorID).IsRequired(true);

			modelBuilder.Entity<Purchasing_VendorContact>().HasOne(x=>x.Person_Contact).WithMany(x=>x.Purchasing_VendorContactList).HasForeignKey(x=>x.ContactID).IsRequired(true);
			modelBuilder.Entity<Purchasing_VendorContact>().HasOne(x=>x.Person_ContactType).WithMany(x=>x.Purchasing_VendorContactList).HasForeignKey(x=>x.ContactTypeID).IsRequired(true);
			modelBuilder.Entity<Purchasing_VendorContact>().HasOne(x=>x.Purchasing_Vendor).WithMany(x=>x.Purchasing_VendorContactList).HasForeignKey(x=>x.VendorID).IsRequired(true);

			modelBuilder.Entity<Production_WorkOrder>().HasOne(x=>x.Production_Product).WithMany(x=>x.Production_WorkOrderList).HasForeignKey(x=>x.ProductID).IsRequired(true);
			modelBuilder.Entity<Production_WorkOrder>().HasOne(x=>x.Production_ScrapReason).WithMany(x=>x.Production_WorkOrderList).HasForeignKey(x=>x.ScrapReasonID).IsRequired(false);
			modelBuilder.Entity<Production_WorkOrder>().HasMany(x=>x.Production_WorkOrderRoutingList).WithOne(x=>x.Production_WorkOrder).HasForeignKey(x=>x.WorkOrderID).IsRequired(true);

			modelBuilder.Entity<Production_WorkOrderRouting>().HasOne(x=>x.Production_Location).WithMany(x=>x.Production_WorkOrderRoutingList).HasForeignKey(x=>x.LocationID).IsRequired(true);
			modelBuilder.Entity<Production_WorkOrderRouting>().HasOne(x=>x.Production_WorkOrder).WithMany(x=>x.Production_WorkOrderRoutingList).HasForeignKey(x=>x.WorkOrderID).IsRequired(true);

		}
		#endregion

		#region Other details
		partial void CustomizeMapping(ref ModelBuilder modelBuilder);
		
		public bool HasChanges()
		{
		    return ChangeTracker.Entries().Any(e => e.State == Microsoft.EntityFrameworkCore.EntityState.Added || e.State == Microsoft.EntityFrameworkCore.EntityState.Modified || e.State == Microsoft.EntityFrameworkCore.EntityState.Deleted);
		}
		
		partial void OnCreated();
		#endregion

	}

	#region Entity Tables

	#region Person.Address
	public partial class Person_Address : EFCoreEntityBase<Person_Address>
	{
		public Person_Address()
		{
			OnCreated();
		}

		public Person_Address(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert
		/// </summary>
		public int AddressID { get; set; }

		/// <summary>
		/// DbType = "NVarChar(60) NOT NULL"
		/// </summary>
		public string AddressLine1 { get; set; }

		/// <summary>
		/// DbType = "NVarChar(60)"
		/// </summary>
		public string AddressLine2 { get; set; }

		/// <summary>
		/// DbType = "NVarChar(30) NOT NULL"
		/// </summary>
		public string City { get; set; }

		/// <summary>
		/// DbType = "Int NOT NULL"
		/// </summary>
		public int StateProvinceID { get; set; }

		/// <summary>
		/// DbType = "NVarChar(15) NOT NULL"
		/// </summary>
		public string PostalCode { get; set; }

		/// <summary>
		/// DbType = "UniqueIdentifier NOT NULL", DefaultValue = /*newid()*/ Guid.NewGuid()
		/// </summary>
		public System.Guid rowguid { get; set; } = /*newid()*/ Guid.NewGuid();

		/// <summary>
		/// DbType = "DateTime NOT NULL", DefaultValue = /*getdate()*/ DateTime.Now
		/// </summary>
		public DateTime ModifiedDate { get; set; } = /*getdate()*/ DateTime.Now;

		#endregion Columns

		#region Associations

		/// <summary>
		/// Association <br/>
		/// [PK][One]Person_Address.AddressID --- [FK][Many]HumanResources_EmployeeAddress.AddressID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<HumanResources_EmployeeAddress> HumanResources_EmployeeAddressList { get; set; } = new List<HumanResources_EmployeeAddress>();

		/// <summary>
		/// Association <br/>
		/// [FK][Many]Person_Address.StateProvinceID --- [PK][One]Person_StateProvince.StateProvinceID <br/>
		/// </summary>
		public virtual Person_StateProvince Person_StateProvince { get; set; }

		/// <summary>
		/// Association <br/>
		/// [PK][One]Person_Address.AddressID --- [FK][Many]Purchasing_VendorAddress.AddressID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<Purchasing_VendorAddress> Purchasing_VendorAddressList { get; set; } = new List<Purchasing_VendorAddress>();

		/// <summary>
		/// Association <br/>
		/// [PK][One]Person_Address.AddressID --- [FK][Many]Sales_CustomerAddress.AddressID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<Sales_CustomerAddress> Sales_CustomerAddressList { get; set; } = new List<Sales_CustomerAddress>();

		/// <summary>
		/// Association <br/>
		/// [PK][One]Person_Address.AddressID --- [FK][Many]Sales_SalesOrderHeader.BillToAddressID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<Sales_SalesOrderHeader> Sales_SalesOrderHeaderList { get; set; } = new List<Sales_SalesOrderHeader>();

		/// <summary>
		/// Association <br/>
		/// [PK][One]Person_Address.AddressID --- [FK][Many]Sales_SalesOrderHeader.ShipToAddressID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<Sales_SalesOrderHeader> AddressList { get; set; } = new List<Sales_SalesOrderHeader>();
		#endregion Associations

		partial void OnCreated();
	}
	#endregion Person.Address

	#region Person.AddressType
	public partial class Person_AddressType : EFCoreEntityBase<Person_AddressType>
	{
		public Person_AddressType()
		{
			OnCreated();
		}

		public Person_AddressType(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert
		/// </summary>
		public int AddressTypeID { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50) NOT NULL"
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// DbType = "UniqueIdentifier NOT NULL", DefaultValue = /*newid()*/ Guid.NewGuid()
		/// </summary>
		public System.Guid rowguid { get; set; } = /*newid()*/ Guid.NewGuid();

		/// <summary>
		/// DbType = "DateTime NOT NULL", DefaultValue = /*getdate()*/ DateTime.Now
		/// </summary>
		public DateTime ModifiedDate { get; set; } = /*getdate()*/ DateTime.Now;

		#endregion Columns

		#region Associations

		/// <summary>
		/// Association <br/>
		/// [PK][One]Person_AddressType.AddressTypeID --- [FK][Many]Purchasing_VendorAddress.AddressTypeID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<Purchasing_VendorAddress> Purchasing_VendorAddressList { get; set; } = new List<Purchasing_VendorAddress>();

		/// <summary>
		/// Association <br/>
		/// [PK][One]Person_AddressType.AddressTypeID --- [FK][Many]Sales_CustomerAddress.AddressTypeID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<Sales_CustomerAddress> Sales_CustomerAddressList { get; set; } = new List<Sales_CustomerAddress>();
		#endregion Associations

		partial void OnCreated();
	}
	#endregion Person.AddressType

	#region dbo.AWBuildVersion
	public partial class AWBuildVersion : EFCoreEntityBase<AWBuildVersion>
	{
		public AWBuildVersion()
		{
			OnCreated();
		}

		public AWBuildVersion(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "TinyInt NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert
		/// </summary>
		public byte SystemInformationID { get; set; }

		/// <summary>
		/// DbType = "NVarChar(25) NOT NULL"
		/// </summary>
		public string DatabaseVersion { get; set; }

		/// <summary>
		/// DbType = "DateTime NOT NULL"
		/// </summary>
		public DateTime VersionDate { get; set; }

		/// <summary>
		/// DbType = "DateTime NOT NULL", DefaultValue = /*getdate()*/ DateTime.Now
		/// </summary>
		public DateTime ModifiedDate { get; set; } = /*getdate()*/ DateTime.Now;

		#endregion Columns

		#region Associations
		#endregion Associations

		partial void OnCreated();
	}
	#endregion dbo.AWBuildVersion

	#region Production.BillOfMaterials
	public partial class Production_BillOfMaterials : EFCoreEntityBase<Production_BillOfMaterials>
	{
		public Production_BillOfMaterials()
		{
			OnCreated();
		}

		public Production_BillOfMaterials(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert
		/// </summary>
		public int BillOfMaterialsID { get; set; }

		/// <summary>
		/// DbType = "Int"
		/// </summary>
		public int? ProductAssemblyID { get; set; }

		/// <summary>
		/// DbType = "Int NOT NULL"
		/// </summary>
		public int ComponentID { get; set; }

		/// <summary>
		/// DbType = "DateTime NOT NULL", DefaultValue = /*getdate()*/ DateTime.Now
		/// </summary>
		public DateTime StartDate { get; set; } = /*getdate()*/ DateTime.Now;

		/// <summary>
		/// DbType = "DateTime"
		/// </summary>
		public DateTime? EndDate { get; set; }

		/// <summary>
		/// DbType = "NChar(3) NOT NULL"
		/// </summary>
		public string UnitMeasureCode { get; set; }

		/// <summary>
		/// DbType = "SmallInt NOT NULL"
		/// </summary>
		public System.Int16 BOMLevel { get; set; }

		/// <summary>
		/// DbType = "Decimal(8,2) NOT NULL", DefaultValue = (decimal)(1.00)
		/// </summary>
		public decimal PerAssemblyQty { get; set; } = (decimal)(1.00);

		/// <summary>
		/// DbType = "DateTime NOT NULL", DefaultValue = /*getdate()*/ DateTime.Now
		/// </summary>
		public DateTime ModifiedDate { get; set; } = /*getdate()*/ DateTime.Now;

		#endregion Columns

		#region Associations

		/// <summary>
		/// Association <br/>
		/// [FK][Many]Production_BillOfMaterials.ComponentID --- [PK][One]Production_Product.ProductID <br/>
		/// </summary>
		public virtual Production_Product Production_Product { get; set; }

		/// <summary>
		/// Association <br/>
		/// [FK][Many]Production_BillOfMaterials.ProductAssemblyID --- [PK][One]Production_Product.ProductID <br/>
		/// </summary>
		public virtual Production_Product ProductAssembly { get; set; }

		/// <summary>
		/// Association <br/>
		/// [FK][Many]Production_BillOfMaterials.UnitMeasureCode --- [PK][One]Production_UnitMeasure.UnitMeasureCode <br/>
		/// </summary>
		public virtual Production_UnitMeasure Production_UnitMeasure { get; set; }
		#endregion Associations

		partial void OnCreated();
	}
	#endregion Production.BillOfMaterials

	#region Person.Contact
	public partial class Person_Contact : EFCoreEntityBase<Person_Contact>
	{
		public Person_Contact()
		{
			OnCreated();
		}

		public Person_Contact(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert
		/// </summary>
		public int ContactID { get; set; }

		/// <summary>
		/// DbType = "Bit NOT NULL", DefaultValue = false
		/// </summary>
		public bool NameStyle { get; set; } = false;

		/// <summary>
		/// DbType = "NVarChar(8)"
		/// </summary>
		public string Title { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50) NOT NULL"
		/// </summary>
		public string FirstName { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50)"
		/// </summary>
		public string MiddleName { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50) NOT NULL"
		/// </summary>
		public string LastName { get; set; }

		/// <summary>
		/// DbType = "NVarChar(10)"
		/// </summary>
		public string Suffix { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50)"
		/// </summary>
		public string EmailAddress { get; set; }

		/// <summary>
		/// DbType = "Int NOT NULL", DefaultValue = (int)(0)
		/// </summary>
		public int EmailPromotion { get; set; } = (int)(0);

		/// <summary>
		/// DbType = "NVarChar(25)"
		/// </summary>
		public string Phone { get; set; }

		/// <summary>
		/// DbType = "VarChar(128) NOT NULL"
		/// </summary>
		public string PasswordHash { get; set; }

		/// <summary>
		/// DbType = "VarChar(10) NOT NULL"
		/// </summary>
		public string PasswordSalt { get; set; }

		/// <summary>
		/// DbType = "Xml"
		/// </summary>
		public System.Xml.Linq.XElement AdditionalContactInfo { get; set; }

		/// <summary>
		/// DbType = "UniqueIdentifier NOT NULL", DefaultValue = /*newid()*/ Guid.NewGuid()
		/// </summary>
		public System.Guid rowguid { get; set; } = /*newid()*/ Guid.NewGuid();

		/// <summary>
		/// DbType = "DateTime NOT NULL", DefaultValue = /*getdate()*/ DateTime.Now
		/// </summary>
		public DateTime ModifiedDate { get; set; } = /*getdate()*/ DateTime.Now;

		#endregion Columns

		#region Associations

		/// <summary>
		/// Association <br/>
		/// [PK][One]Person_Contact.ContactID --- [FK][Many]HumanResources_Employee.ContactID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<HumanResources_Employee> HumanResources_EmployeeList { get; set; } = new List<HumanResources_Employee>();

		/// <summary>
		/// Association <br/>
		/// [PK][One]Person_Contact.ContactID --- [FK][Many]Purchasing_VendorContact.ContactID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<Purchasing_VendorContact> Purchasing_VendorContactList { get; set; } = new List<Purchasing_VendorContact>();

		/// <summary>
		/// Association <br/>
		/// [PK][One]Person_Contact.ContactID --- [FK][Many]Sales_ContactCreditCard.ContactID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<Sales_ContactCreditCard> Sales_ContactCreditCardList { get; set; } = new List<Sales_ContactCreditCard>();

		/// <summary>
		/// Association <br/>
		/// [PK][One]Person_Contact.ContactID --- [FK][Many]Sales_Individual.ContactID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<Sales_Individual> Sales_IndividualList { get; set; } = new List<Sales_Individual>();

		/// <summary>
		/// Association <br/>
		/// [PK][One]Person_Contact.ContactID --- [FK][Many]Sales_SalesOrderHeader.ContactID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<Sales_SalesOrderHeader> Sales_SalesOrderHeaderList { get; set; } = new List<Sales_SalesOrderHeader>();

		/// <summary>
		/// Association <br/>
		/// [PK][One]Person_Contact.ContactID --- [FK][Many]Sales_StoreContact.ContactID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<Sales_StoreContact> Sales_StoreContactList { get; set; } = new List<Sales_StoreContact>();
		#endregion Associations

		partial void OnCreated();
	}
	#endregion Person.Contact

	#region Sales.ContactCreditCard
	public partial class Sales_ContactCreditCard : EFCoreEntityBase<Sales_ContactCreditCard>
	{
		public Sales_ContactCreditCard()
		{
			OnCreated();
		}

		public Sales_ContactCreditCard(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "Int NOT NULL", IsPrimaryKey = true
		/// </summary>
		public int ContactID { get; set; }

		/// <summary>
		/// DbType = "Int NOT NULL", IsPrimaryKey = true
		/// </summary>
		public int CreditCardID { get; set; }

		/// <summary>
		/// DbType = "DateTime NOT NULL", DefaultValue = /*getdate()*/ DateTime.Now
		/// </summary>
		public DateTime ModifiedDate { get; set; } = /*getdate()*/ DateTime.Now;

		#endregion Columns

		#region Associations

		/// <summary>
		/// Association <br/>
		/// [FK][Many]Sales_ContactCreditCard.ContactID --- [PK][One]Person_Contact.ContactID <br/>
		/// </summary>
		public virtual Person_Contact Person_Contact { get; set; }

		/// <summary>
		/// Association <br/>
		/// [FK][Many]Sales_ContactCreditCard.CreditCardID --- [PK][One]Sales_CreditCard.CreditCardID <br/>
		/// </summary>
		public virtual Sales_CreditCard Sales_CreditCard { get; set; }
		#endregion Associations

		partial void OnCreated();
	}
	#endregion Sales.ContactCreditCard

	#region Person.ContactType
	public partial class Person_ContactType : EFCoreEntityBase<Person_ContactType>
	{
		public Person_ContactType()
		{
			OnCreated();
		}

		public Person_ContactType(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert
		/// </summary>
		public int ContactTypeID { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50) NOT NULL"
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// DbType = "DateTime NOT NULL", DefaultValue = /*getdate()*/ DateTime.Now
		/// </summary>
		public DateTime ModifiedDate { get; set; } = /*getdate()*/ DateTime.Now;

		#endregion Columns

		#region Associations

		/// <summary>
		/// Association <br/>
		/// [PK][One]Person_ContactType.ContactTypeID --- [FK][Many]Purchasing_VendorContact.ContactTypeID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<Purchasing_VendorContact> Purchasing_VendorContactList { get; set; } = new List<Purchasing_VendorContact>();

		/// <summary>
		/// Association <br/>
		/// [PK][One]Person_ContactType.ContactTypeID --- [FK][Many]Sales_StoreContact.ContactTypeID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<Sales_StoreContact> Sales_StoreContactList { get; set; } = new List<Sales_StoreContact>();
		#endregion Associations

		partial void OnCreated();
	}
	#endregion Person.ContactType

	#region Person.CountryRegion
	public partial class Person_CountryRegion : EFCoreEntityBase<Person_CountryRegion>
	{
		public Person_CountryRegion()
		{
			OnCreated();
		}

		public Person_CountryRegion(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "NVarChar(3) NOT NULL", IsPrimaryKey = true
		/// </summary>
		public string CountryRegionCode { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50) NOT NULL"
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// DbType = "DateTime NOT NULL", DefaultValue = /*getdate()*/ DateTime.Now
		/// </summary>
		public DateTime ModifiedDate { get; set; } = /*getdate()*/ DateTime.Now;

		#endregion Columns

		#region Associations

		/// <summary>
		/// Association <br/>
		/// [PK][One]Person_CountryRegion.CountryRegionCode --- [FK][Many]Person_StateProvince.CountryRegionCode <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<Person_StateProvince> Person_StateProvinceList { get; set; } = new List<Person_StateProvince>();

		/// <summary>
		/// Association <br/>
		/// [PK][One]Person_CountryRegion.CountryRegionCode --- [FK][Many]Sales_CountryRegionCurrency.CountryRegionCode <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<Sales_CountryRegionCurrency> Sales_CountryRegionCurrencyList { get; set; } = new List<Sales_CountryRegionCurrency>();
		#endregion Associations

		partial void OnCreated();
	}
	#endregion Person.CountryRegion

	#region Sales.CountryRegionCurrency
	public partial class Sales_CountryRegionCurrency : EFCoreEntityBase<Sales_CountryRegionCurrency>
	{
		public Sales_CountryRegionCurrency()
		{
			OnCreated();
		}

		public Sales_CountryRegionCurrency(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "NVarChar(3) NOT NULL", IsPrimaryKey = true
		/// </summary>
		public string CountryRegionCode { get; set; }

		/// <summary>
		/// DbType = "NChar(3) NOT NULL", IsPrimaryKey = true
		/// </summary>
		public string CurrencyCode { get; set; }

		/// <summary>
		/// DbType = "DateTime NOT NULL", DefaultValue = /*getdate()*/ DateTime.Now
		/// </summary>
		public DateTime ModifiedDate { get; set; } = /*getdate()*/ DateTime.Now;

		#endregion Columns

		#region Associations

		/// <summary>
		/// Association <br/>
		/// [FK][Many]Sales_CountryRegionCurrency.CountryRegionCode --- [PK][One]Person_CountryRegion.CountryRegionCode <br/>
		/// </summary>
		public virtual Person_CountryRegion Person_CountryRegion { get; set; }

		/// <summary>
		/// Association <br/>
		/// [FK][Many]Sales_CountryRegionCurrency.CurrencyCode --- [PK][One]Sales_Currency.CurrencyCode <br/>
		/// </summary>
		public virtual Sales_Currency Sales_Currency { get; set; }
		#endregion Associations

		partial void OnCreated();
	}
	#endregion Sales.CountryRegionCurrency

	#region Sales.CreditCard
	public partial class Sales_CreditCard : EFCoreEntityBase<Sales_CreditCard>
	{
		public Sales_CreditCard()
		{
			OnCreated();
		}

		public Sales_CreditCard(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert
		/// </summary>
		public int CreditCardID { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50) NOT NULL"
		/// </summary>
		public string CardType { get; set; }

		/// <summary>
		/// DbType = "NVarChar(25) NOT NULL"
		/// </summary>
		public string CardNumber { get; set; }

		/// <summary>
		/// DbType = "TinyInt NOT NULL"
		/// </summary>
		public byte ExpMonth { get; set; }

		/// <summary>
		/// DbType = "SmallInt NOT NULL"
		/// </summary>
		public System.Int16 ExpYear { get; set; }

		/// <summary>
		/// DbType = "DateTime NOT NULL", DefaultValue = /*getdate()*/ DateTime.Now
		/// </summary>
		public DateTime ModifiedDate { get; set; } = /*getdate()*/ DateTime.Now;

		#endregion Columns

		#region Associations

		/// <summary>
		/// Association <br/>
		/// [PK][One]Sales_CreditCard.CreditCardID --- [FK][Many]Sales_ContactCreditCard.CreditCardID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<Sales_ContactCreditCard> Sales_ContactCreditCardList { get; set; } = new List<Sales_ContactCreditCard>();

		/// <summary>
		/// Association <br/>
		/// [PK][One]Sales_CreditCard.CreditCardID --- [FK][Many]Sales_SalesOrderHeader.CreditCardID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<Sales_SalesOrderHeader> Sales_SalesOrderHeaderList { get; set; } = new List<Sales_SalesOrderHeader>();
		#endregion Associations

		partial void OnCreated();
	}
	#endregion Sales.CreditCard

	#region Production.Culture
	public partial class Production_Culture : EFCoreEntityBase<Production_Culture>
	{
		public Production_Culture()
		{
			OnCreated();
		}

		public Production_Culture(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "NChar(6) NOT NULL", IsPrimaryKey = true
		/// </summary>
		public string CultureID { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50) NOT NULL"
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// DbType = "DateTime NOT NULL", DefaultValue = /*getdate()*/ DateTime.Now
		/// </summary>
		public DateTime ModifiedDate { get; set; } = /*getdate()*/ DateTime.Now;

		#endregion Columns

		#region Associations

		/// <summary>
		/// Association <br/>
		/// [PK][One]Production_Culture.CultureID --- [FK][Many]Production_ProductModelProductDescriptionCulture.CultureID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<Production_ProductModelProductDescriptionCulture> Production_ProductModelProductDescriptionCultureList { get; set; } = new List<Production_ProductModelProductDescriptionCulture>();
		#endregion Associations

		partial void OnCreated();
	}
	#endregion Production.Culture

	#region Sales.Currency
	public partial class Sales_Currency : EFCoreEntityBase<Sales_Currency>
	{
		public Sales_Currency()
		{
			OnCreated();
		}

		public Sales_Currency(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "NChar(3) NOT NULL", IsPrimaryKey = true
		/// </summary>
		public string CurrencyCode { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50) NOT NULL"
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// DbType = "DateTime NOT NULL", DefaultValue = /*getdate()*/ DateTime.Now
		/// </summary>
		public DateTime ModifiedDate { get; set; } = /*getdate()*/ DateTime.Now;

		#endregion Columns

		#region Associations

		/// <summary>
		/// Association <br/>
		/// [PK][One]Sales_Currency.CurrencyCode --- [FK][Many]Sales_CountryRegionCurrency.CurrencyCode <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<Sales_CountryRegionCurrency> Sales_CountryRegionCurrencyList { get; set; } = new List<Sales_CountryRegionCurrency>();

		/// <summary>
		/// Association <br/>
		/// [PK][One]Sales_Currency.CurrencyCode --- [FK][Many]Sales_CurrencyRate.FromCurrencyCode <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<Sales_CurrencyRate> Sales_CurrencyRateList { get; set; } = new List<Sales_CurrencyRate>();

		/// <summary>
		/// Association <br/>
		/// [PK][One]Sales_Currency.CurrencyCode --- [FK][Many]Sales_CurrencyRate.ToCurrencyCode <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<Sales_CurrencyRate> CurrencyCodeSales_CurrencyRateList { get; set; } = new List<Sales_CurrencyRate>();
		#endregion Associations

		partial void OnCreated();
	}
	#endregion Sales.Currency

	#region Sales.CurrencyRate
	public partial class Sales_CurrencyRate : EFCoreEntityBase<Sales_CurrencyRate>
	{
		public Sales_CurrencyRate()
		{
			OnCreated();
		}

		public Sales_CurrencyRate(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert
		/// </summary>
		public int CurrencyRateID { get; set; }

		/// <summary>
		/// DbType = "DateTime NOT NULL"
		/// </summary>
		public DateTime CurrencyRateDate { get; set; }

		/// <summary>
		/// DbType = "NChar(3) NOT NULL"
		/// </summary>
		public string FromCurrencyCode { get; set; }

		/// <summary>
		/// DbType = "NChar(3) NOT NULL"
		/// </summary>
		public string ToCurrencyCode { get; set; }

		/// <summary>
		/// DbType = "Money NOT NULL"
		/// </summary>
		public decimal AverageRate { get; set; }

		/// <summary>
		/// DbType = "Money NOT NULL"
		/// </summary>
		public decimal EndOfDayRate { get; set; }

		/// <summary>
		/// DbType = "DateTime NOT NULL", DefaultValue = /*getdate()*/ DateTime.Now
		/// </summary>
		public DateTime ModifiedDate { get; set; } = /*getdate()*/ DateTime.Now;

		#endregion Columns

		#region Associations

		/// <summary>
		/// Association <br/>
		/// [FK][Many]Sales_CurrencyRate.FromCurrencyCode --- [PK][One]Sales_Currency.CurrencyCode <br/>
		/// </summary>
		public virtual Sales_Currency Sales_Currency { get; set; }

		/// <summary>
		/// Association <br/>
		/// [FK][Many]Sales_CurrencyRate.ToCurrencyCode --- [PK][One]Sales_Currency.CurrencyCode <br/>
		/// </summary>
		public virtual Sales_Currency ToCurrencyCodeSales_Currency { get; set; }

		/// <summary>
		/// Association <br/>
		/// [PK][One]Sales_CurrencyRate.CurrencyRateID --- [FK][Many]Sales_SalesOrderHeader.CurrencyRateID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<Sales_SalesOrderHeader> Sales_SalesOrderHeaderList { get; set; } = new List<Sales_SalesOrderHeader>();
		#endregion Associations

		partial void OnCreated();
	}
	#endregion Sales.CurrencyRate

	#region Sales.Customer
	public partial class Sales_Customer : EFCoreEntityBase<Sales_Customer>
	{
		public Sales_Customer()
		{
			OnCreated();
		}

		public Sales_Customer(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert
		/// </summary>
		public int CustomerID { get; set; }

		/// <summary>
		/// DbType = "Int"
		/// </summary>
		public int? TerritoryID { get; set; }

		/// <summary>
		/// DbType = "VarChar(10) NOT NULL"
		/// </summary>
		public string AccountNumber { get; set; }

		/// <summary>
		/// DbType = "NChar(1) NOT NULL"
		/// </summary>
		public string CustomerType { get; set; }

		/// <summary>
		/// DbType = "UniqueIdentifier NOT NULL", DefaultValue = /*newid()*/ Guid.NewGuid()
		/// </summary>
		public System.Guid rowguid { get; set; } = /*newid()*/ Guid.NewGuid();

		/// <summary>
		/// DbType = "DateTime NOT NULL", DefaultValue = /*getdate()*/ DateTime.Now
		/// </summary>
		public DateTime ModifiedDate { get; set; } = /*getdate()*/ DateTime.Now;

		#endregion Columns

		#region Associations

		/// <summary>
		/// Association <br/>
		/// [FK][Many]Sales_Customer.TerritoryID --- [PK][One]Sales_SalesTerritory.TerritoryID <br/>
		/// </summary>
		public virtual Sales_SalesTerritory Sales_SalesTerritory { get; set; }

		/// <summary>
		/// Association <br/>
		/// [PK][One]Sales_Customer.CustomerID --- [FK][Many]Sales_CustomerAddress.CustomerID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<Sales_CustomerAddress> Sales_CustomerAddressList { get; set; } = new List<Sales_CustomerAddress>();

		/// <summary>
		/// Association <br/>
		/// [PK][One]Sales_Customer.CustomerID --- [FK][One]Sales_Individual.CustomerID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual Sales_Individual Sales_Individual { get; set; }

		/// <summary>
		/// Association <br/>
		/// [PK][One]Sales_Customer.CustomerID --- [FK][Many]Sales_SalesOrderHeader.CustomerID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<Sales_SalesOrderHeader> Sales_SalesOrderHeaderList { get; set; } = new List<Sales_SalesOrderHeader>();

		/// <summary>
		/// Association <br/>
		/// [PK][One]Sales_Customer.CustomerID --- [FK][One]Sales_Store.CustomerID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual Sales_Store Sales_Store { get; set; }
		#endregion Associations

		partial void OnCreated();
	}
	#endregion Sales.Customer

	#region Sales.CustomerAddress
	public partial class Sales_CustomerAddress : EFCoreEntityBase<Sales_CustomerAddress>
	{
		public Sales_CustomerAddress()
		{
			OnCreated();
		}

		public Sales_CustomerAddress(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "Int NOT NULL", IsPrimaryKey = true
		/// </summary>
		public int CustomerID { get; set; }

		/// <summary>
		/// DbType = "Int NOT NULL", IsPrimaryKey = true
		/// </summary>
		public int AddressID { get; set; }

		/// <summary>
		/// DbType = "Int NOT NULL"
		/// </summary>
		public int AddressTypeID { get; set; }

		/// <summary>
		/// DbType = "UniqueIdentifier NOT NULL", DefaultValue = /*newid()*/ Guid.NewGuid()
		/// </summary>
		public System.Guid rowguid { get; set; } = /*newid()*/ Guid.NewGuid();

		/// <summary>
		/// DbType = "DateTime NOT NULL", DefaultValue = /*getdate()*/ DateTime.Now
		/// </summary>
		public DateTime ModifiedDate { get; set; } = /*getdate()*/ DateTime.Now;

		#endregion Columns

		#region Associations

		/// <summary>
		/// Association <br/>
		/// [FK][Many]Sales_CustomerAddress.AddressID --- [PK][One]Person_Address.AddressID <br/>
		/// </summary>
		public virtual Person_Address Person_Address { get; set; }

		/// <summary>
		/// Association <br/>
		/// [FK][Many]Sales_CustomerAddress.AddressTypeID --- [PK][One]Person_AddressType.AddressTypeID <br/>
		/// </summary>
		public virtual Person_AddressType Person_AddressType { get; set; }

		/// <summary>
		/// Association <br/>
		/// [FK][Many]Sales_CustomerAddress.CustomerID --- [PK][One]Sales_Customer.CustomerID <br/>
		/// </summary>
		public virtual Sales_Customer Sales_Customer { get; set; }
		#endregion Associations

		partial void OnCreated();
	}
	#endregion Sales.CustomerAddress

	#region dbo.DatabaseLog
	public partial class DatabaseLog : EFCoreEntityBase<DatabaseLog>
	{
		public DatabaseLog()
		{
			OnCreated();
		}

		public DatabaseLog(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert
		/// </summary>
		public int DatabaseLogID { get; set; }

		/// <summary>
		/// DbType = "DateTime NOT NULL"
		/// </summary>
		public DateTime PostTime { get; set; }

		/// <summary>
		/// DbType = "NVarChar(128) NOT NULL"
		/// </summary>
		public string DatabaseUser { get; set; }

		/// <summary>
		/// DbType = "NVarChar(128) NOT NULL"
		/// </summary>
		public string Event { get; set; }

		/// <summary>
		/// DbType = "NVarChar(128)"
		/// </summary>
		public string Schema { get; set; }

		/// <summary>
		/// DbType = "NVarChar(128)"
		/// </summary>
		public string Object { get; set; }

		/// <summary>
		/// DbType = "NVarChar(MAX) NOT NULL"
		/// </summary>
		public string TSQL { get; set; }

		/// <summary>
		/// DbType = "Xml NOT NULL"
		/// </summary>
		public System.Xml.Linq.XElement XmlEvent { get; set; }

		#endregion Columns

		#region Associations
		#endregion Associations

		partial void OnCreated();
	}
	#endregion dbo.DatabaseLog

	#region HumanResources.Department
	public partial class HumanResources_Department : EFCoreEntityBase<HumanResources_Department>
	{
		public HumanResources_Department()
		{
			OnCreated();
		}

		public HumanResources_Department(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "SmallInt NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert
		/// </summary>
		public System.Int16 DepartmentID { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50) NOT NULL"
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50) NOT NULL"
		/// </summary>
		public string GroupName { get; set; }

		/// <summary>
		/// DbType = "DateTime NOT NULL", DefaultValue = /*getdate()*/ DateTime.Now
		/// </summary>
		public DateTime ModifiedDate { get; set; } = /*getdate()*/ DateTime.Now;

		#endregion Columns

		#region Associations

		/// <summary>
		/// Association <br/>
		/// [PK][One]HumanResources_Department.DepartmentID --- [FK][Many]HumanResources_EmployeeDepartmentHistory.DepartmentID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<HumanResources_EmployeeDepartmentHistory> HumanResources_EmployeeDepartmentHistoryList { get; set; } = new List<HumanResources_EmployeeDepartmentHistory>();
		#endregion Associations

		partial void OnCreated();
	}
	#endregion HumanResources.Department

	#region Production.Document
	public partial class Production_Document : EFCoreEntityBase<Production_Document>
	{
		public Production_Document()
		{
			OnCreated();
		}

		public Production_Document(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert
		/// </summary>
		public int DocumentID { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50) NOT NULL"
		/// </summary>
		public string Title { get; set; }

		/// <summary>
		/// DbType = "NVarChar(400) NOT NULL"
		/// </summary>
		public string FileName { get; set; }

		/// <summary>
		/// DbType = "NVarChar(8) NOT NULL"
		/// </summary>
		public string FileExtension { get; set; }

		/// <summary>
		/// DbType = "NChar(5) NOT NULL"
		/// </summary>
		public string Revision { get; set; }

		/// <summary>
		/// DbType = "Int NOT NULL", DefaultValue = (int)(0)
		/// </summary>
		public int ChangeNumber { get; set; } = (int)(0);

		/// <summary>
		/// DbType = "TinyInt NOT NULL"
		/// </summary>
		public byte Status { get; set; }

		/// <summary>
		/// DbType = "NVarChar(MAX)"
		/// </summary>
		public string DocumentSummary { get; set; }

		/// <summary>
		/// DbType = "VarBinary(MAX)"
		/// </summary>
		public byte[] Document { get; set; }

		/// <summary>
		/// DbType = "DateTime NOT NULL", DefaultValue = /*getdate()*/ DateTime.Now
		/// </summary>
		public DateTime ModifiedDate { get; set; } = /*getdate()*/ DateTime.Now;

		#endregion Columns

		#region Associations

		/// <summary>
		/// Association <br/>
		/// [PK][One]Production_Document.DocumentID --- [FK][Many]Production_ProductDocument.DocumentID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<Production_ProductDocument> Production_ProductDocumentList { get; set; } = new List<Production_ProductDocument>();
		#endregion Associations

		partial void OnCreated();
	}
	#endregion Production.Document

	#region HumanResources.Employee
	public partial class HumanResources_Employee : EFCoreEntityBase<HumanResources_Employee>
	{
		public HumanResources_Employee()
		{
			OnCreated();
		}

		public HumanResources_Employee(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert
		/// </summary>
		public int EmployeeID { get; set; }

		/// <summary>
		/// DbType = "NVarChar(15) NOT NULL"
		/// </summary>
		public string NationalIDNumber { get; set; }

		/// <summary>
		/// DbType = "Int NOT NULL"
		/// </summary>
		public int ContactID { get; set; }

		/// <summary>
		/// DbType = "NVarChar(256) NOT NULL"
		/// </summary>
		public string LoginID { get; set; }

		/// <summary>
		/// DbType = "Int"
		/// </summary>
		public int? ManagerID { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50) NOT NULL"
		/// </summary>
		public string Title { get; set; }

		/// <summary>
		/// DbType = "DateTime NOT NULL"
		/// </summary>
		public DateTime BirthDate { get; set; }

		/// <summary>
		/// DbType = "NChar(1) NOT NULL"
		/// </summary>
		public string MaritalStatus { get; set; }

		/// <summary>
		/// DbType = "NChar(1) NOT NULL"
		/// </summary>
		public string Gender { get; set; }

		/// <summary>
		/// DbType = "DateTime NOT NULL"
		/// </summary>
		public DateTime HireDate { get; set; }

		/// <summary>
		/// DbType = "Bit NOT NULL", DefaultValue = true
		/// </summary>
		public bool SalariedFlag { get; set; } = true;

		/// <summary>
		/// DbType = "SmallInt NOT NULL", DefaultValue = (System.Int16)(0)
		/// </summary>
		public System.Int16 VacationHours { get; set; } = (System.Int16)(0);

		/// <summary>
		/// DbType = "SmallInt NOT NULL", DefaultValue = (System.Int16)(0)
		/// </summary>
		public System.Int16 SickLeaveHours { get; set; } = (System.Int16)(0);

		/// <summary>
		/// DbType = "Bit NOT NULL", DefaultValue = true
		/// </summary>
		public bool CurrentFlag { get; set; } = true;

		/// <summary>
		/// DbType = "UniqueIdentifier NOT NULL", DefaultValue = /*newid()*/ Guid.NewGuid()
		/// </summary>
		public System.Guid rowguid { get; set; } = /*newid()*/ Guid.NewGuid();

		/// <summary>
		/// DbType = "DateTime NOT NULL", DefaultValue = /*getdate()*/ DateTime.Now
		/// </summary>
		public DateTime ModifiedDate { get; set; } = /*getdate()*/ DateTime.Now;

		#endregion Columns

		#region Associations

		/// <summary>
		/// Association <br/>
		/// [FK][Many]HumanResources_Employee.ContactID --- [PK][One]Person_Contact.ContactID <br/>
		/// </summary>
		public virtual Person_Contact Person_Contact { get; set; }

		/// <summary>
		/// Association <br/>
		/// [FK][Many]HumanResources_Employee.ManagerID --- [PK][One]HumanResources_Employee.EmployeeID <br/>
		/// </summary>
		public virtual HumanResources_Employee Manager { get; set; }

		/// <summary>
		/// Association <br/>
		/// [PK][One]HumanResources_Employee.EmployeeID --- [FK][Many]HumanResources_Employee.ManagerID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<HumanResources_Employee> EmployeeList { get; set; } = new List<HumanResources_Employee>();

		/// <summary>
		/// Association <br/>
		/// [PK][One]HumanResources_Employee.EmployeeID --- [FK][Many]HumanResources_EmployeeAddress.EmployeeID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<HumanResources_EmployeeAddress> HumanResources_EmployeeAddressList { get; set; } = new List<HumanResources_EmployeeAddress>();

		/// <summary>
		/// Association <br/>
		/// [PK][One]HumanResources_Employee.EmployeeID --- [FK][Many]HumanResources_EmployeeDepartmentHistory.EmployeeID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<HumanResources_EmployeeDepartmentHistory> HumanResources_EmployeeDepartmentHistoryList { get; set; } = new List<HumanResources_EmployeeDepartmentHistory>();

		/// <summary>
		/// Association <br/>
		/// [PK][One]HumanResources_Employee.EmployeeID --- [FK][Many]HumanResources_EmployeePayHistory.EmployeeID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<HumanResources_EmployeePayHistory> HumanResources_EmployeePayHistoryList { get; set; } = new List<HumanResources_EmployeePayHistory>();

		/// <summary>
		/// Association <br/>
		/// [PK][One]HumanResources_Employee.EmployeeID --- [FK][Many]HumanResources_JobCandidate.EmployeeID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<HumanResources_JobCandidate> HumanResources_JobCandidateList { get; set; } = new List<HumanResources_JobCandidate>();

		/// <summary>
		/// Association <br/>
		/// [PK][One]HumanResources_Employee.EmployeeID --- [FK][Many]Purchasing_PurchaseOrderHeader.EmployeeID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<Purchasing_PurchaseOrderHeader> Purchasing_PurchaseOrderHeaderList { get; set; } = new List<Purchasing_PurchaseOrderHeader>();

		/// <summary>
		/// Association <br/>
		/// [PK][One]HumanResources_Employee.EmployeeID --- [FK][One]Sales_SalesPerson.SalesPersonID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual Sales_SalesPerson Sales_SalesPerson { get; set; }
		#endregion Associations

		partial void OnCreated();
	}
	#endregion HumanResources.Employee

	#region HumanResources.EmployeeAddress
	public partial class HumanResources_EmployeeAddress : EFCoreEntityBase<HumanResources_EmployeeAddress>
	{
		public HumanResources_EmployeeAddress()
		{
			OnCreated();
		}

		public HumanResources_EmployeeAddress(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "Int NOT NULL", IsPrimaryKey = true
		/// </summary>
		public int EmployeeID { get; set; }

		/// <summary>
		/// DbType = "Int NOT NULL", IsPrimaryKey = true
		/// </summary>
		public int AddressID { get; set; }

		/// <summary>
		/// DbType = "UniqueIdentifier NOT NULL", DefaultValue = /*newid()*/ Guid.NewGuid()
		/// </summary>
		public System.Guid rowguid { get; set; } = /*newid()*/ Guid.NewGuid();

		/// <summary>
		/// DbType = "DateTime NOT NULL", DefaultValue = /*getdate()*/ DateTime.Now
		/// </summary>
		public DateTime ModifiedDate { get; set; } = /*getdate()*/ DateTime.Now;

		#endregion Columns

		#region Associations

		/// <summary>
		/// Association <br/>
		/// [FK][Many]HumanResources_EmployeeAddress.AddressID --- [PK][One]Person_Address.AddressID <br/>
		/// </summary>
		public virtual Person_Address Person_Address { get; set; }

		/// <summary>
		/// Association <br/>
		/// [FK][Many]HumanResources_EmployeeAddress.EmployeeID --- [PK][One]HumanResources_Employee.EmployeeID <br/>
		/// </summary>
		public virtual HumanResources_Employee HumanResources_Employee { get; set; }
		#endregion Associations

		partial void OnCreated();
	}
	#endregion HumanResources.EmployeeAddress

	#region HumanResources.EmployeeDepartmentHistory
	public partial class HumanResources_EmployeeDepartmentHistory : EFCoreEntityBase<HumanResources_EmployeeDepartmentHistory>
	{
		public HumanResources_EmployeeDepartmentHistory()
		{
			OnCreated();
		}

		public HumanResources_EmployeeDepartmentHistory(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "Int NOT NULL", IsPrimaryKey = true
		/// </summary>
		public int EmployeeID { get; set; }

		/// <summary>
		/// DbType = "SmallInt NOT NULL", IsPrimaryKey = true
		/// </summary>
		public System.Int16 DepartmentID { get; set; }

		/// <summary>
		/// DbType = "TinyInt NOT NULL", IsPrimaryKey = true
		/// </summary>
		public byte ShiftID { get; set; }

		/// <summary>
		/// DbType = "DateTime NOT NULL", IsPrimaryKey = true
		/// </summary>
		public DateTime StartDate { get; set; }

		/// <summary>
		/// DbType = "DateTime"
		/// </summary>
		public DateTime? EndDate { get; set; }

		/// <summary>
		/// DbType = "DateTime NOT NULL", DefaultValue = /*getdate()*/ DateTime.Now
		/// </summary>
		public DateTime ModifiedDate { get; set; } = /*getdate()*/ DateTime.Now;

		#endregion Columns

		#region Associations

		/// <summary>
		/// Association <br/>
		/// [FK][Many]HumanResources_EmployeeDepartmentHistory.DepartmentID --- [PK][One]HumanResources_Department.DepartmentID <br/>
		/// </summary>
		public virtual HumanResources_Department HumanResources_Department { get; set; }

		/// <summary>
		/// Association <br/>
		/// [FK][Many]HumanResources_EmployeeDepartmentHistory.EmployeeID --- [PK][One]HumanResources_Employee.EmployeeID <br/>
		/// </summary>
		public virtual HumanResources_Employee HumanResources_Employee { get; set; }

		/// <summary>
		/// Association <br/>
		/// [FK][Many]HumanResources_EmployeeDepartmentHistory.ShiftID --- [PK][One]HumanResources_Shift.ShiftID <br/>
		/// </summary>
		public virtual HumanResources_Shift HumanResources_Shift { get; set; }
		#endregion Associations

		partial void OnCreated();
	}
	#endregion HumanResources.EmployeeDepartmentHistory

	#region HumanResources.EmployeePayHistory
	public partial class HumanResources_EmployeePayHistory : EFCoreEntityBase<HumanResources_EmployeePayHistory>
	{
		public HumanResources_EmployeePayHistory()
		{
			OnCreated();
		}

		public HumanResources_EmployeePayHistory(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "Int NOT NULL", IsPrimaryKey = true
		/// </summary>
		public int EmployeeID { get; set; }

		/// <summary>
		/// DbType = "DateTime NOT NULL", IsPrimaryKey = true
		/// </summary>
		public DateTime RateChangeDate { get; set; }

		/// <summary>
		/// DbType = "Money NOT NULL"
		/// </summary>
		public decimal Rate { get; set; }

		/// <summary>
		/// DbType = "TinyInt NOT NULL"
		/// </summary>
		public byte PayFrequency { get; set; }

		/// <summary>
		/// DbType = "DateTime NOT NULL", DefaultValue = /*getdate()*/ DateTime.Now
		/// </summary>
		public DateTime ModifiedDate { get; set; } = /*getdate()*/ DateTime.Now;

		#endregion Columns

		#region Associations

		/// <summary>
		/// Association <br/>
		/// [FK][Many]HumanResources_EmployeePayHistory.EmployeeID --- [PK][One]HumanResources_Employee.EmployeeID <br/>
		/// </summary>
		public virtual HumanResources_Employee HumanResources_Employee { get; set; }
		#endregion Associations

		partial void OnCreated();
	}
	#endregion HumanResources.EmployeePayHistory

	#region dbo.ErrorLog
	public partial class ErrorLog : EFCoreEntityBase<ErrorLog>
	{
		public ErrorLog()
		{
			OnCreated();
		}

		public ErrorLog(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert
		/// </summary>
		public int ErrorLogID { get; set; }

		/// <summary>
		/// DbType = "DateTime NOT NULL", DefaultValue = /*getdate()*/ DateTime.Now
		/// </summary>
		public DateTime ErrorTime { get; set; } = /*getdate()*/ DateTime.Now;

		/// <summary>
		/// DbType = "NVarChar(128) NOT NULL"
		/// </summary>
		public string UserName { get; set; }

		/// <summary>
		/// DbType = "Int NOT NULL"
		/// </summary>
		public int ErrorNumber { get; set; }

		/// <summary>
		/// DbType = "Int"
		/// </summary>
		public int? ErrorSeverity { get; set; }

		/// <summary>
		/// DbType = "Int"
		/// </summary>
		public int? ErrorState { get; set; }

		/// <summary>
		/// DbType = "NVarChar(126)"
		/// </summary>
		public string ErrorProcedure { get; set; }

		/// <summary>
		/// DbType = "Int"
		/// </summary>
		public int? ErrorLine { get; set; }

		/// <summary>
		/// DbType = "NVarChar(4000) NOT NULL"
		/// </summary>
		public string ErrorMessage { get; set; }

		#endregion Columns

		#region Associations
		#endregion Associations

		partial void OnCreated();
	}
	#endregion dbo.ErrorLog

	#region Production.Illustration
	public partial class Production_Illustration : EFCoreEntityBase<Production_Illustration>
	{
		public Production_Illustration()
		{
			OnCreated();
		}

		public Production_Illustration(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert
		/// </summary>
		public int IllustrationID { get; set; }

		/// <summary>
		/// DbType = "Xml"
		/// </summary>
		public System.Xml.Linq.XElement Diagram { get; set; }

		/// <summary>
		/// DbType = "DateTime NOT NULL", DefaultValue = /*getdate()*/ DateTime.Now
		/// </summary>
		public DateTime ModifiedDate { get; set; } = /*getdate()*/ DateTime.Now;

		#endregion Columns

		#region Associations

		/// <summary>
		/// Association <br/>
		/// [PK][One]Production_Illustration.IllustrationID --- [FK][Many]Production_ProductModelIllustration.IllustrationID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<Production_ProductModelIllustration> Production_ProductModelIllustrationList { get; set; } = new List<Production_ProductModelIllustration>();
		#endregion Associations

		partial void OnCreated();
	}
	#endregion Production.Illustration

	#region Sales.Individual
	public partial class Sales_Individual : EFCoreEntityBase<Sales_Individual>
	{
		public Sales_Individual()
		{
			OnCreated();
		}

		public Sales_Individual(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "Int NOT NULL", IsPrimaryKey = true
		/// </summary>
		public int CustomerID { get; set; }

		/// <summary>
		/// DbType = "Int NOT NULL"
		/// </summary>
		public int ContactID { get; set; }

		/// <summary>
		/// DbType = "Xml"
		/// </summary>
		public System.Xml.Linq.XElement Demographics { get; set; }

		/// <summary>
		/// DbType = "DateTime NOT NULL", DefaultValue = /*getdate()*/ DateTime.Now
		/// </summary>
		public DateTime ModifiedDate { get; set; } = /*getdate()*/ DateTime.Now;

		#endregion Columns

		#region Associations

		/// <summary>
		/// Association <br/>
		/// [FK][Many]Sales_Individual.ContactID --- [PK][One]Person_Contact.ContactID <br/>
		/// </summary>
		public virtual Person_Contact Person_Contact { get; set; }

		/// <summary>
		/// Association <br/>
		/// [FK][One]Sales_Individual.CustomerID --- [PK][One]Sales_Customer.CustomerID <br/>
		/// </summary>
		public virtual Sales_Customer Sales_Customer { get; set; }
		#endregion Associations

		partial void OnCreated();
	}
	#endregion Sales.Individual

	#region HumanResources.JobCandidate
	public partial class HumanResources_JobCandidate : EFCoreEntityBase<HumanResources_JobCandidate>
	{
		public HumanResources_JobCandidate()
		{
			OnCreated();
		}

		public HumanResources_JobCandidate(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert
		/// </summary>
		public int JobCandidateID { get; set; }

		/// <summary>
		/// DbType = "Int"
		/// </summary>
		public int? EmployeeID { get; set; }

		/// <summary>
		/// DbType = "Xml"
		/// </summary>
		public System.Xml.Linq.XElement Resume { get; set; }

		/// <summary>
		/// DbType = "DateTime NOT NULL", DefaultValue = /*getdate()*/ DateTime.Now
		/// </summary>
		public DateTime ModifiedDate { get; set; } = /*getdate()*/ DateTime.Now;

		#endregion Columns

		#region Associations

		/// <summary>
		/// Association <br/>
		/// [FK][Many]HumanResources_JobCandidate.EmployeeID --- [PK][One]HumanResources_Employee.EmployeeID <br/>
		/// </summary>
		public virtual HumanResources_Employee HumanResources_Employee { get; set; }
		#endregion Associations

		partial void OnCreated();
	}
	#endregion HumanResources.JobCandidate

	#region Production.Location
	public partial class Production_Location : EFCoreEntityBase<Production_Location>
	{
		public Production_Location()
		{
			OnCreated();
		}

		public Production_Location(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "SmallInt NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert
		/// </summary>
		public System.Int16 LocationID { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50) NOT NULL"
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// DbType = "SmallMoney NOT NULL", DefaultValue = (decimal)(0.00)
		/// </summary>
		public decimal CostRate { get; set; } = (decimal)(0.00);

		/// <summary>
		/// DbType = "Decimal(8,2) NOT NULL", DefaultValue = (decimal)(0.00)
		/// </summary>
		public decimal Availability { get; set; } = (decimal)(0.00);

		/// <summary>
		/// DbType = "DateTime NOT NULL", DefaultValue = /*getdate()*/ DateTime.Now
		/// </summary>
		public DateTime ModifiedDate { get; set; } = /*getdate()*/ DateTime.Now;

		#endregion Columns

		#region Associations

		/// <summary>
		/// Association <br/>
		/// [PK][One]Production_Location.LocationID --- [FK][Many]Production_ProductInventory.LocationID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<Production_ProductInventory> Production_ProductInventoryList { get; set; } = new List<Production_ProductInventory>();

		/// <summary>
		/// Association <br/>
		/// [PK][One]Production_Location.LocationID --- [FK][Many]Production_WorkOrderRouting.LocationID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<Production_WorkOrderRouting> Production_WorkOrderRoutingList { get; set; } = new List<Production_WorkOrderRouting>();
		#endregion Associations

		partial void OnCreated();
	}
	#endregion Production.Location

	#region Production.Product
	public partial class Production_Product : EFCoreEntityBase<Production_Product>
	{
		public Production_Product()
		{
			OnCreated();
		}

		public Production_Product(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert
		/// </summary>
		public int ProductID { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50) NOT NULL"
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// DbType = "NVarChar(25) NOT NULL"
		/// </summary>
		public string ProductNumber { get; set; }

		/// <summary>
		/// DbType = "Bit NOT NULL", DefaultValue = true
		/// </summary>
		public bool MakeFlag { get; set; } = true;

		/// <summary>
		/// DbType = "Bit NOT NULL", DefaultValue = true
		/// </summary>
		public bool FinishedGoodsFlag { get; set; } = true;

		/// <summary>
		/// DbType = "NVarChar(15)"
		/// </summary>
		public string Color { get; set; }

		/// <summary>
		/// DbType = "SmallInt NOT NULL"
		/// </summary>
		public System.Int16 SafetyStockLevel { get; set; }

		/// <summary>
		/// DbType = "SmallInt NOT NULL"
		/// </summary>
		public System.Int16 ReorderPoint { get; set; }

		/// <summary>
		/// DbType = "Money NOT NULL"
		/// </summary>
		public decimal StandardCost { get; set; }

		/// <summary>
		/// DbType = "Money NOT NULL"
		/// </summary>
		public decimal ListPrice { get; set; }

		/// <summary>
		/// DbType = "NVarChar(5)"
		/// </summary>
		public string Size { get; set; }

		/// <summary>
		/// DbType = "NChar(3)"
		/// </summary>
		public string SizeUnitMeasureCode { get; set; }

		/// <summary>
		/// DbType = "NChar(3)"
		/// </summary>
		public string WeightUnitMeasureCode { get; set; }

		/// <summary>
		/// DbType = "Decimal(8,2)"
		/// </summary>
		public decimal? Weight { get; set; }

		/// <summary>
		/// DbType = "Int NOT NULL"
		/// </summary>
		public int DaysToManufacture { get; set; }

		/// <summary>
		/// DbType = "NChar(2)"
		/// </summary>
		public string ProductLine { get; set; }

		/// <summary>
		/// DbType = "NChar(2)"
		/// </summary>
		public string Class { get; set; }

		/// <summary>
		/// DbType = "NChar(2)"
		/// </summary>
		public string Style { get; set; }

		/// <summary>
		/// DbType = "Int"
		/// </summary>
		public int? ProductSubcategoryID { get; set; }

		/// <summary>
		/// DbType = "Int"
		/// </summary>
		public int? ProductModelID { get; set; }

		/// <summary>
		/// DbType = "DateTime NOT NULL"
		/// </summary>
		public DateTime SellStartDate { get; set; }

		/// <summary>
		/// DbType = "DateTime"
		/// </summary>
		public DateTime? SellEndDate { get; set; }

		/// <summary>
		/// DbType = "DateTime"
		/// </summary>
		public DateTime? DiscontinuedDate { get; set; }

		/// <summary>
		/// DbType = "UniqueIdentifier NOT NULL", DefaultValue = /*newid()*/ Guid.NewGuid()
		/// </summary>
		public System.Guid rowguid { get; set; } = /*newid()*/ Guid.NewGuid();

		/// <summary>
		/// DbType = "DateTime NOT NULL", DefaultValue = /*getdate()*/ DateTime.Now
		/// </summary>
		public DateTime ModifiedDate { get; set; } = /*getdate()*/ DateTime.Now;

		#endregion Columns

		#region Associations

		/// <summary>
		/// Association <br/>
		/// [PK][One]Production_Product.ProductID --- [FK][Many]Production_BillOfMaterials.ComponentID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<Production_BillOfMaterials> Production_BillOfMaterialsList { get; set; } = new List<Production_BillOfMaterials>();

		/// <summary>
		/// Association <br/>
		/// [PK][One]Production_Product.ProductID --- [FK][Many]Production_BillOfMaterials.ProductAssemblyID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<Production_BillOfMaterials> ProductList { get; set; } = new List<Production_BillOfMaterials>();

		/// <summary>
		/// Association <br/>
		/// [FK][Many]Production_Product.ProductModelID --- [PK][One]Production_ProductModel.ProductModelID <br/>
		/// </summary>
		public virtual Production_ProductModel Production_ProductModel { get; set; }

		/// <summary>
		/// Association <br/>
		/// [FK][Many]Production_Product.ProductSubcategoryID --- [PK][One]Production_ProductSubcategory.ProductSubcategoryID <br/>
		/// </summary>
		public virtual Production_ProductSubcategory Production_ProductSubcategory { get; set; }

		/// <summary>
		/// Association <br/>
		/// [FK][Many]Production_Product.SizeUnitMeasureCode --- [PK][One]Production_UnitMeasure.UnitMeasureCode <br/>
		/// </summary>
		public virtual Production_UnitMeasure Production_UnitMeasure { get; set; }

		/// <summary>
		/// Association <br/>
		/// [FK][Many]Production_Product.WeightUnitMeasureCode --- [PK][One]Production_UnitMeasure.UnitMeasureCode <br/>
		/// </summary>
		public virtual Production_UnitMeasure WeightUnitMeasureCodeProduction_UnitMeasure { get; set; }

		/// <summary>
		/// Association <br/>
		/// [PK][One]Production_Product.ProductID --- [FK][Many]Production_ProductCostHistory.ProductID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<Production_ProductCostHistory> Production_ProductCostHistoryList { get; set; } = new List<Production_ProductCostHistory>();

		/// <summary>
		/// Association <br/>
		/// [PK][One]Production_Product.ProductID --- [FK][Many]Production_ProductDocument.ProductID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<Production_ProductDocument> Production_ProductDocumentList { get; set; } = new List<Production_ProductDocument>();

		/// <summary>
		/// Association <br/>
		/// [PK][One]Production_Product.ProductID --- [FK][Many]Production_ProductInventory.ProductID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<Production_ProductInventory> Production_ProductInventoryList { get; set; } = new List<Production_ProductInventory>();

		/// <summary>
		/// Association <br/>
		/// [PK][One]Production_Product.ProductID --- [FK][Many]Production_ProductListPriceHistory.ProductID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<Production_ProductListPriceHistory> Production_ProductListPriceHistoryList { get; set; } = new List<Production_ProductListPriceHistory>();

		/// <summary>
		/// Association <br/>
		/// [PK][One]Production_Product.ProductID --- [FK][Many]Production_ProductProductPhoto.ProductID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<Production_ProductProductPhoto> Production_ProductProductPhotoList { get; set; } = new List<Production_ProductProductPhoto>();

		/// <summary>
		/// Association <br/>
		/// [PK][One]Production_Product.ProductID --- [FK][Many]Production_ProductReview.ProductID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<Production_ProductReview> Production_ProductReviewList { get; set; } = new List<Production_ProductReview>();

		/// <summary>
		/// Association <br/>
		/// [PK][One]Production_Product.ProductID --- [FK][Many]Production_TransactionHistory.ProductID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<Production_TransactionHistory> Production_TransactionHistoryList { get; set; } = new List<Production_TransactionHistory>();

		/// <summary>
		/// Association <br/>
		/// [PK][One]Production_Product.ProductID --- [FK][Many]Production_WorkOrder.ProductID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<Production_WorkOrder> Production_WorkOrderList { get; set; } = new List<Production_WorkOrder>();

		/// <summary>
		/// Association <br/>
		/// [PK][One]Production_Product.ProductID --- [FK][Many]Purchasing_ProductVendor.ProductID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<Purchasing_ProductVendor> Purchasing_ProductVendorList { get; set; } = new List<Purchasing_ProductVendor>();

		/// <summary>
		/// Association <br/>
		/// [PK][One]Production_Product.ProductID --- [FK][Many]Purchasing_PurchaseOrderDetail.ProductID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<Purchasing_PurchaseOrderDetail> Purchasing_PurchaseOrderDetailList { get; set; } = new List<Purchasing_PurchaseOrderDetail>();

		/// <summary>
		/// Association <br/>
		/// [PK][One]Production_Product.ProductID --- [FK][Many]Sales_ShoppingCartItem.ProductID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<Sales_ShoppingCartItem> Sales_ShoppingCartItemList { get; set; } = new List<Sales_ShoppingCartItem>();

		/// <summary>
		/// Association <br/>
		/// [PK][One]Production_Product.ProductID --- [FK][Many]Sales_SpecialOfferProduct.ProductID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<Sales_SpecialOfferProduct> Sales_SpecialOfferProductList { get; set; } = new List<Sales_SpecialOfferProduct>();
		#endregion Associations

		partial void OnCreated();
	}
	#endregion Production.Product

	#region Production.ProductCategory
	public partial class Production_ProductCategory : EFCoreEntityBase<Production_ProductCategory>
	{
		public Production_ProductCategory()
		{
			OnCreated();
		}

		public Production_ProductCategory(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert
		/// </summary>
		public int ProductCategoryID { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50) NOT NULL"
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// DbType = "UniqueIdentifier NOT NULL", DefaultValue = /*newid()*/ Guid.NewGuid()
		/// </summary>
		public System.Guid rowguid { get; set; } = /*newid()*/ Guid.NewGuid();

		/// <summary>
		/// DbType = "DateTime NOT NULL", DefaultValue = /*getdate()*/ DateTime.Now
		/// </summary>
		public DateTime ModifiedDate { get; set; } = /*getdate()*/ DateTime.Now;

		#endregion Columns

		#region Associations

		/// <summary>
		/// Association <br/>
		/// [PK][One]Production_ProductCategory.ProductCategoryID --- [FK][Many]Production_ProductSubcategory.ProductCategoryID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<Production_ProductSubcategory> Production_ProductSubcategoryList { get; set; } = new List<Production_ProductSubcategory>();
		#endregion Associations

		partial void OnCreated();
	}
	#endregion Production.ProductCategory

	#region Production.ProductCostHistory
	public partial class Production_ProductCostHistory : EFCoreEntityBase<Production_ProductCostHistory>
	{
		public Production_ProductCostHistory()
		{
			OnCreated();
		}

		public Production_ProductCostHistory(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "Int NOT NULL", IsPrimaryKey = true
		/// </summary>
		public int ProductID { get; set; }

		/// <summary>
		/// DbType = "DateTime NOT NULL", IsPrimaryKey = true
		/// </summary>
		public DateTime StartDate { get; set; }

		/// <summary>
		/// DbType = "DateTime"
		/// </summary>
		public DateTime? EndDate { get; set; }

		/// <summary>
		/// DbType = "Money NOT NULL"
		/// </summary>
		public decimal StandardCost { get; set; }

		/// <summary>
		/// DbType = "DateTime NOT NULL", DefaultValue = /*getdate()*/ DateTime.Now
		/// </summary>
		public DateTime ModifiedDate { get; set; } = /*getdate()*/ DateTime.Now;

		#endregion Columns

		#region Associations

		/// <summary>
		/// Association <br/>
		/// [FK][Many]Production_ProductCostHistory.ProductID --- [PK][One]Production_Product.ProductID <br/>
		/// </summary>
		public virtual Production_Product Production_Product { get; set; }
		#endregion Associations

		partial void OnCreated();
	}
	#endregion Production.ProductCostHistory

	#region Production.ProductDescription
	public partial class Production_ProductDescription : EFCoreEntityBase<Production_ProductDescription>
	{
		public Production_ProductDescription()
		{
			OnCreated();
		}

		public Production_ProductDescription(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert
		/// </summary>
		public int ProductDescriptionID { get; set; }

		/// <summary>
		/// DbType = "NVarChar(400) NOT NULL"
		/// </summary>
		public string Description { get; set; }

		/// <summary>
		/// DbType = "UniqueIdentifier NOT NULL", DefaultValue = /*newid()*/ Guid.NewGuid()
		/// </summary>
		public System.Guid rowguid { get; set; } = /*newid()*/ Guid.NewGuid();

		/// <summary>
		/// DbType = "DateTime NOT NULL", DefaultValue = /*getdate()*/ DateTime.Now
		/// </summary>
		public DateTime ModifiedDate { get; set; } = /*getdate()*/ DateTime.Now;

		#endregion Columns

		#region Associations

		/// <summary>
		/// Association <br/>
		/// [PK][One]Production_ProductDescription.ProductDescriptionID --- [FK][Many]Production_ProductModelProductDescriptionCulture.ProductDescriptionID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<Production_ProductModelProductDescriptionCulture> Production_ProductModelProductDescriptionCultureList { get; set; } = new List<Production_ProductModelProductDescriptionCulture>();
		#endregion Associations

		partial void OnCreated();
	}
	#endregion Production.ProductDescription

	#region Production.ProductDocument
	public partial class Production_ProductDocument : EFCoreEntityBase<Production_ProductDocument>
	{
		public Production_ProductDocument()
		{
			OnCreated();
		}

		public Production_ProductDocument(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "Int NOT NULL", IsPrimaryKey = true
		/// </summary>
		public int ProductID { get; set; }

		/// <summary>
		/// DbType = "Int NOT NULL", IsPrimaryKey = true
		/// </summary>
		public int DocumentID { get; set; }

		/// <summary>
		/// DbType = "DateTime NOT NULL", DefaultValue = /*getdate()*/ DateTime.Now
		/// </summary>
		public DateTime ModifiedDate { get; set; } = /*getdate()*/ DateTime.Now;

		#endregion Columns

		#region Associations

		/// <summary>
		/// Association <br/>
		/// [FK][Many]Production_ProductDocument.DocumentID --- [PK][One]Production_Document.DocumentID <br/>
		/// </summary>
		public virtual Production_Document Production_Document { get; set; }

		/// <summary>
		/// Association <br/>
		/// [FK][Many]Production_ProductDocument.ProductID --- [PK][One]Production_Product.ProductID <br/>
		/// </summary>
		public virtual Production_Product Production_Product { get; set; }
		#endregion Associations

		partial void OnCreated();
	}
	#endregion Production.ProductDocument

	#region Production.ProductInventory
	public partial class Production_ProductInventory : EFCoreEntityBase<Production_ProductInventory>
	{
		public Production_ProductInventory()
		{
			OnCreated();
		}

		public Production_ProductInventory(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "Int NOT NULL", IsPrimaryKey = true
		/// </summary>
		public int ProductID { get; set; }

		/// <summary>
		/// DbType = "SmallInt NOT NULL", IsPrimaryKey = true
		/// </summary>
		public System.Int16 LocationID { get; set; }

		/// <summary>
		/// DbType = "NVarChar(10) NOT NULL"
		/// </summary>
		public string Shelf { get; set; }

		/// <summary>
		/// DbType = "TinyInt NOT NULL"
		/// </summary>
		public byte Bin { get; set; }

		/// <summary>
		/// DbType = "SmallInt NOT NULL", DefaultValue = (System.Int16)(0)
		/// </summary>
		public System.Int16 Quantity { get; set; } = (System.Int16)(0);

		/// <summary>
		/// DbType = "UniqueIdentifier NOT NULL", DefaultValue = /*newid()*/ Guid.NewGuid()
		/// </summary>
		public System.Guid rowguid { get; set; } = /*newid()*/ Guid.NewGuid();

		/// <summary>
		/// DbType = "DateTime NOT NULL", DefaultValue = /*getdate()*/ DateTime.Now
		/// </summary>
		public DateTime ModifiedDate { get; set; } = /*getdate()*/ DateTime.Now;

		#endregion Columns

		#region Associations

		/// <summary>
		/// Association <br/>
		/// [FK][Many]Production_ProductInventory.LocationID --- [PK][One]Production_Location.LocationID <br/>
		/// </summary>
		public virtual Production_Location Production_Location { get; set; }

		/// <summary>
		/// Association <br/>
		/// [FK][Many]Production_ProductInventory.ProductID --- [PK][One]Production_Product.ProductID <br/>
		/// </summary>
		public virtual Production_Product Production_Product { get; set; }
		#endregion Associations

		partial void OnCreated();
	}
	#endregion Production.ProductInventory

	#region Production.ProductListPriceHistory
	public partial class Production_ProductListPriceHistory : EFCoreEntityBase<Production_ProductListPriceHistory>
	{
		public Production_ProductListPriceHistory()
		{
			OnCreated();
		}

		public Production_ProductListPriceHistory(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "Int NOT NULL", IsPrimaryKey = true
		/// </summary>
		public int ProductID { get; set; }

		/// <summary>
		/// DbType = "DateTime NOT NULL", IsPrimaryKey = true
		/// </summary>
		public DateTime StartDate { get; set; }

		/// <summary>
		/// DbType = "DateTime"
		/// </summary>
		public DateTime? EndDate { get; set; }

		/// <summary>
		/// DbType = "Money NOT NULL"
		/// </summary>
		public decimal ListPrice { get; set; }

		/// <summary>
		/// DbType = "DateTime NOT NULL", DefaultValue = /*getdate()*/ DateTime.Now
		/// </summary>
		public DateTime ModifiedDate { get; set; } = /*getdate()*/ DateTime.Now;

		#endregion Columns

		#region Associations

		/// <summary>
		/// Association <br/>
		/// [FK][Many]Production_ProductListPriceHistory.ProductID --- [PK][One]Production_Product.ProductID <br/>
		/// </summary>
		public virtual Production_Product Production_Product { get; set; }
		#endregion Associations

		partial void OnCreated();
	}
	#endregion Production.ProductListPriceHistory

	#region Production.ProductModel
	public partial class Production_ProductModel : EFCoreEntityBase<Production_ProductModel>
	{
		public Production_ProductModel()
		{
			OnCreated();
		}

		public Production_ProductModel(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert
		/// </summary>
		public int ProductModelID { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50) NOT NULL"
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// DbType = "Xml"
		/// </summary>
		public System.Xml.Linq.XElement CatalogDescription { get; set; }

		/// <summary>
		/// DbType = "Xml"
		/// </summary>
		public System.Xml.Linq.XElement Instructions { get; set; }

		/// <summary>
		/// DbType = "UniqueIdentifier NOT NULL", DefaultValue = /*newid()*/ Guid.NewGuid()
		/// </summary>
		public System.Guid rowguid { get; set; } = /*newid()*/ Guid.NewGuid();

		/// <summary>
		/// DbType = "DateTime NOT NULL", DefaultValue = /*getdate()*/ DateTime.Now
		/// </summary>
		public DateTime ModifiedDate { get; set; } = /*getdate()*/ DateTime.Now;

		#endregion Columns

		#region Associations

		/// <summary>
		/// Association <br/>
		/// [PK][One]Production_ProductModel.ProductModelID --- [FK][Many]Production_Product.ProductModelID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<Production_Product> Production_ProductList { get; set; } = new List<Production_Product>();

		/// <summary>
		/// Association <br/>
		/// [PK][One]Production_ProductModel.ProductModelID --- [FK][Many]Production_ProductModelIllustration.ProductModelID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<Production_ProductModelIllustration> Production_ProductModelIllustrationList { get; set; } = new List<Production_ProductModelIllustration>();

		/// <summary>
		/// Association <br/>
		/// [PK][One]Production_ProductModel.ProductModelID --- [FK][Many]Production_ProductModelProductDescriptionCulture.ProductModelID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<Production_ProductModelProductDescriptionCulture> Production_ProductModelProductDescriptionCultureList { get; set; } = new List<Production_ProductModelProductDescriptionCulture>();
		#endregion Associations

		partial void OnCreated();
	}
	#endregion Production.ProductModel

	#region Production.ProductModelIllustration
	public partial class Production_ProductModelIllustration : EFCoreEntityBase<Production_ProductModelIllustration>
	{
		public Production_ProductModelIllustration()
		{
			OnCreated();
		}

		public Production_ProductModelIllustration(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "Int NOT NULL", IsPrimaryKey = true
		/// </summary>
		public int ProductModelID { get; set; }

		/// <summary>
		/// DbType = "Int NOT NULL", IsPrimaryKey = true
		/// </summary>
		public int IllustrationID { get; set; }

		/// <summary>
		/// DbType = "DateTime NOT NULL", DefaultValue = /*getdate()*/ DateTime.Now
		/// </summary>
		public DateTime ModifiedDate { get; set; } = /*getdate()*/ DateTime.Now;

		#endregion Columns

		#region Associations

		/// <summary>
		/// Association <br/>
		/// [FK][Many]Production_ProductModelIllustration.IllustrationID --- [PK][One]Production_Illustration.IllustrationID <br/>
		/// </summary>
		public virtual Production_Illustration Production_Illustration { get; set; }

		/// <summary>
		/// Association <br/>
		/// [FK][Many]Production_ProductModelIllustration.ProductModelID --- [PK][One]Production_ProductModel.ProductModelID <br/>
		/// </summary>
		public virtual Production_ProductModel Production_ProductModel { get; set; }
		#endregion Associations

		partial void OnCreated();
	}
	#endregion Production.ProductModelIllustration

	#region Production.ProductModelProductDescriptionCulture
	public partial class Production_ProductModelProductDescriptionCulture : EFCoreEntityBase<Production_ProductModelProductDescriptionCulture>
	{
		public Production_ProductModelProductDescriptionCulture()
		{
			OnCreated();
		}

		public Production_ProductModelProductDescriptionCulture(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "Int NOT NULL", IsPrimaryKey = true
		/// </summary>
		public int ProductModelID { get; set; }

		/// <summary>
		/// DbType = "Int NOT NULL", IsPrimaryKey = true
		/// </summary>
		public int ProductDescriptionID { get; set; }

		/// <summary>
		/// DbType = "NChar(6) NOT NULL", IsPrimaryKey = true
		/// </summary>
		public string CultureID { get; set; }

		/// <summary>
		/// DbType = "DateTime NOT NULL", DefaultValue = /*getdate()*/ DateTime.Now
		/// </summary>
		public DateTime ModifiedDate { get; set; } = /*getdate()*/ DateTime.Now;

		#endregion Columns

		#region Associations

		/// <summary>
		/// Association <br/>
		/// [FK][Many]Production_ProductModelProductDescriptionCulture.CultureID --- [PK][One]Production_Culture.CultureID <br/>
		/// </summary>
		public virtual Production_Culture Production_Culture { get; set; }

		/// <summary>
		/// Association <br/>
		/// [FK][Many]Production_ProductModelProductDescriptionCulture.ProductDescriptionID --- [PK][One]Production_ProductDescription.ProductDescriptionID <br/>
		/// </summary>
		public virtual Production_ProductDescription Production_ProductDescription { get; set; }

		/// <summary>
		/// Association <br/>
		/// [FK][Many]Production_ProductModelProductDescriptionCulture.ProductModelID --- [PK][One]Production_ProductModel.ProductModelID <br/>
		/// </summary>
		public virtual Production_ProductModel Production_ProductModel { get; set; }
		#endregion Associations

		partial void OnCreated();
	}
	#endregion Production.ProductModelProductDescriptionCulture

	#region Production.ProductPhoto
	public partial class Production_ProductPhoto : EFCoreEntityBase<Production_ProductPhoto>
	{
		public Production_ProductPhoto()
		{
			OnCreated();
		}

		public Production_ProductPhoto(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert
		/// </summary>
		public int ProductPhotoID { get; set; }

		/// <summary>
		/// DbType = "VarBinary(MAX)"
		/// </summary>
		public byte[] ThumbNailPhoto { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50)"
		/// </summary>
		public string ThumbnailPhotoFileName { get; set; }

		/// <summary>
		/// DbType = "VarBinary(MAX)"
		/// </summary>
		public byte[] LargePhoto { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50)"
		/// </summary>
		public string LargePhotoFileName { get; set; }

		/// <summary>
		/// DbType = "DateTime NOT NULL", DefaultValue = /*getdate()*/ DateTime.Now
		/// </summary>
		public DateTime ModifiedDate { get; set; } = /*getdate()*/ DateTime.Now;

		#endregion Columns

		#region Associations

		/// <summary>
		/// Association <br/>
		/// [PK][One]Production_ProductPhoto.ProductPhotoID --- [FK][Many]Production_ProductProductPhoto.ProductPhotoID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<Production_ProductProductPhoto> Production_ProductProductPhotoList { get; set; } = new List<Production_ProductProductPhoto>();
		#endregion Associations

		partial void OnCreated();
	}
	#endregion Production.ProductPhoto

	#region Production.ProductProductPhoto
	public partial class Production_ProductProductPhoto : EFCoreEntityBase<Production_ProductProductPhoto>
	{
		public Production_ProductProductPhoto()
		{
			OnCreated();
		}

		public Production_ProductProductPhoto(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "Int NOT NULL", IsPrimaryKey = true
		/// </summary>
		public int ProductID { get; set; }

		/// <summary>
		/// DbType = "Int NOT NULL", IsPrimaryKey = true
		/// </summary>
		public int ProductPhotoID { get; set; }

		/// <summary>
		/// DbType = "Bit NOT NULL", DefaultValue = false
		/// </summary>
		public bool Primary { get; set; } = false;

		/// <summary>
		/// DbType = "DateTime NOT NULL", DefaultValue = /*getdate()*/ DateTime.Now
		/// </summary>
		public DateTime ModifiedDate { get; set; } = /*getdate()*/ DateTime.Now;

		#endregion Columns

		#region Associations

		/// <summary>
		/// Association <br/>
		/// [FK][Many]Production_ProductProductPhoto.ProductID --- [PK][One]Production_Product.ProductID <br/>
		/// </summary>
		public virtual Production_Product Production_Product { get; set; }

		/// <summary>
		/// Association <br/>
		/// [FK][Many]Production_ProductProductPhoto.ProductPhotoID --- [PK][One]Production_ProductPhoto.ProductPhotoID <br/>
		/// </summary>
		public virtual Production_ProductPhoto Production_ProductPhoto { get; set; }
		#endregion Associations

		partial void OnCreated();
	}
	#endregion Production.ProductProductPhoto

	#region Production.ProductReview
	public partial class Production_ProductReview : EFCoreEntityBase<Production_ProductReview>
	{
		public Production_ProductReview()
		{
			OnCreated();
		}

		public Production_ProductReview(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert
		/// </summary>
		public int ProductReviewID { get; set; }

		/// <summary>
		/// DbType = "Int NOT NULL"
		/// </summary>
		public int ProductID { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50) NOT NULL"
		/// </summary>
		public string ReviewerName { get; set; }

		/// <summary>
		/// DbType = "DateTime NOT NULL", DefaultValue = /*getdate()*/ DateTime.Now
		/// </summary>
		public DateTime ReviewDate { get; set; } = /*getdate()*/ DateTime.Now;

		/// <summary>
		/// DbType = "NVarChar(50) NOT NULL"
		/// </summary>
		public string EmailAddress { get; set; }

		/// <summary>
		/// DbType = "Int NOT NULL"
		/// </summary>
		public int Rating { get; set; }

		/// <summary>
		/// DbType = "NVarChar(3850)"
		/// </summary>
		public string Comments { get; set; }

		/// <summary>
		/// DbType = "DateTime NOT NULL", DefaultValue = /*getdate()*/ DateTime.Now
		/// </summary>
		public DateTime ModifiedDate { get; set; } = /*getdate()*/ DateTime.Now;

		#endregion Columns

		#region Associations

		/// <summary>
		/// Association <br/>
		/// [FK][Many]Production_ProductReview.ProductID --- [PK][One]Production_Product.ProductID <br/>
		/// </summary>
		public virtual Production_Product Production_Product { get; set; }
		#endregion Associations

		partial void OnCreated();
	}
	#endregion Production.ProductReview

	#region Production.ProductSubcategory
	public partial class Production_ProductSubcategory : EFCoreEntityBase<Production_ProductSubcategory>
	{
		public Production_ProductSubcategory()
		{
			OnCreated();
		}

		public Production_ProductSubcategory(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert
		/// </summary>
		public int ProductSubcategoryID { get; set; }

		/// <summary>
		/// DbType = "Int NOT NULL"
		/// </summary>
		public int ProductCategoryID { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50) NOT NULL"
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// DbType = "UniqueIdentifier NOT NULL", DefaultValue = /*newid()*/ Guid.NewGuid()
		/// </summary>
		public System.Guid rowguid { get; set; } = /*newid()*/ Guid.NewGuid();

		/// <summary>
		/// DbType = "DateTime NOT NULL", DefaultValue = /*getdate()*/ DateTime.Now
		/// </summary>
		public DateTime ModifiedDate { get; set; } = /*getdate()*/ DateTime.Now;

		#endregion Columns

		#region Associations

		/// <summary>
		/// Association <br/>
		/// [PK][One]Production_ProductSubcategory.ProductSubcategoryID --- [FK][Many]Production_Product.ProductSubcategoryID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<Production_Product> Production_ProductList { get; set; } = new List<Production_Product>();

		/// <summary>
		/// Association <br/>
		/// [FK][Many]Production_ProductSubcategory.ProductCategoryID --- [PK][One]Production_ProductCategory.ProductCategoryID <br/>
		/// </summary>
		public virtual Production_ProductCategory Production_ProductCategory { get; set; }
		#endregion Associations

		partial void OnCreated();
	}
	#endregion Production.ProductSubcategory

	#region Purchasing.ProductVendor
	public partial class Purchasing_ProductVendor : EFCoreEntityBase<Purchasing_ProductVendor>
	{
		public Purchasing_ProductVendor()
		{
			OnCreated();
		}

		public Purchasing_ProductVendor(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "Int NOT NULL", IsPrimaryKey = true
		/// </summary>
		public int ProductID { get; set; }

		/// <summary>
		/// DbType = "Int NOT NULL", IsPrimaryKey = true
		/// </summary>
		public int VendorID { get; set; }

		/// <summary>
		/// DbType = "Int NOT NULL"
		/// </summary>
		public int AverageLeadTime { get; set; }

		/// <summary>
		/// DbType = "Money NOT NULL"
		/// </summary>
		public decimal StandardPrice { get; set; }

		/// <summary>
		/// DbType = "Money"
		/// </summary>
		public decimal? LastReceiptCost { get; set; }

		/// <summary>
		/// DbType = "DateTime"
		/// </summary>
		public DateTime? LastReceiptDate { get; set; }

		/// <summary>
		/// DbType = "Int NOT NULL"
		/// </summary>
		public int MinOrderQty { get; set; }

		/// <summary>
		/// DbType = "Int NOT NULL"
		/// </summary>
		public int MaxOrderQty { get; set; }

		/// <summary>
		/// DbType = "Int"
		/// </summary>
		public int? OnOrderQty { get; set; }

		/// <summary>
		/// DbType = "NChar(3) NOT NULL"
		/// </summary>
		public string UnitMeasureCode { get; set; }

		/// <summary>
		/// DbType = "DateTime NOT NULL", DefaultValue = /*getdate()*/ DateTime.Now
		/// </summary>
		public DateTime ModifiedDate { get; set; } = /*getdate()*/ DateTime.Now;

		#endregion Columns

		#region Associations

		/// <summary>
		/// Association <br/>
		/// [FK][Many]Purchasing_ProductVendor.ProductID --- [PK][One]Production_Product.ProductID <br/>
		/// </summary>
		public virtual Production_Product Production_Product { get; set; }

		/// <summary>
		/// Association <br/>
		/// [FK][Many]Purchasing_ProductVendor.UnitMeasureCode --- [PK][One]Production_UnitMeasure.UnitMeasureCode <br/>
		/// </summary>
		public virtual Production_UnitMeasure Production_UnitMeasure { get; set; }

		/// <summary>
		/// Association <br/>
		/// [FK][Many]Purchasing_ProductVendor.VendorID --- [PK][One]Purchasing_Vendor.VendorID <br/>
		/// </summary>
		public virtual Purchasing_Vendor Purchasing_Vendor { get; set; }
		#endregion Associations

		partial void OnCreated();
	}
	#endregion Purchasing.ProductVendor

	#region Purchasing.PurchaseOrderDetail
	public partial class Purchasing_PurchaseOrderDetail : EFCoreEntityBase<Purchasing_PurchaseOrderDetail>
	{
		public Purchasing_PurchaseOrderDetail()
		{
			OnCreated();
		}

		public Purchasing_PurchaseOrderDetail(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "Int NOT NULL", IsPrimaryKey = true
		/// </summary>
		public int PurchaseOrderID { get; set; }

		/// <summary>
		/// DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert
		/// </summary>
		public int PurchaseOrderDetailID { get; set; }

		/// <summary>
		/// DbType = "DateTime NOT NULL"
		/// </summary>
		public DateTime DueDate { get; set; }

		/// <summary>
		/// DbType = "SmallInt NOT NULL"
		/// </summary>
		public System.Int16 OrderQty { get; set; }

		/// <summary>
		/// DbType = "Int NOT NULL"
		/// </summary>
		public int ProductID { get; set; }

		/// <summary>
		/// DbType = "Money NOT NULL"
		/// </summary>
		public decimal UnitPrice { get; set; }

		/// <summary>
		/// DbType = "Money NOT NULL"
		/// </summary>
		public decimal LineTotal { get; set; }

		/// <summary>
		/// DbType = "Decimal(8,2) NOT NULL"
		/// </summary>
		public decimal ReceivedQty { get; set; }

		/// <summary>
		/// DbType = "Decimal(8,2) NOT NULL"
		/// </summary>
		public decimal RejectedQty { get; set; }

		/// <summary>
		/// DbType = "Decimal(9,2) NOT NULL"
		/// </summary>
		public decimal StockedQty { get; set; }

		/// <summary>
		/// DbType = "DateTime NOT NULL", DefaultValue = /*getdate()*/ DateTime.Now
		/// </summary>
		public DateTime ModifiedDate { get; set; } = /*getdate()*/ DateTime.Now;

		#endregion Columns

		#region Associations

		/// <summary>
		/// Association <br/>
		/// [FK][Many]Purchasing_PurchaseOrderDetail.ProductID --- [PK][One]Production_Product.ProductID <br/>
		/// </summary>
		public virtual Production_Product Production_Product { get; set; }

		/// <summary>
		/// Association <br/>
		/// [FK][Many]Purchasing_PurchaseOrderDetail.PurchaseOrderID --- [PK][One]Purchasing_PurchaseOrderHeader.PurchaseOrderID <br/>
		/// </summary>
		public virtual Purchasing_PurchaseOrderHeader Purchasing_PurchaseOrderHeader { get; set; }
		#endregion Associations

		partial void OnCreated();
	}
	#endregion Purchasing.PurchaseOrderDetail

	#region Purchasing.PurchaseOrderHeader
	public partial class Purchasing_PurchaseOrderHeader : EFCoreEntityBase<Purchasing_PurchaseOrderHeader>
	{
		public Purchasing_PurchaseOrderHeader()
		{
			OnCreated();
		}

		public Purchasing_PurchaseOrderHeader(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert
		/// </summary>
		public int PurchaseOrderID { get; set; }

		/// <summary>
		/// DbType = "TinyInt NOT NULL", DefaultValue = (byte)(0)
		/// </summary>
		public byte RevisionNumber { get; set; } = (byte)(0);

		/// <summary>
		/// DbType = "TinyInt NOT NULL", DefaultValue = (byte)(1)
		/// </summary>
		public byte Status { get; set; } = (byte)(1);

		/// <summary>
		/// DbType = "Int NOT NULL"
		/// </summary>
		public int EmployeeID { get; set; }

		/// <summary>
		/// DbType = "Int NOT NULL"
		/// </summary>
		public int VendorID { get; set; }

		/// <summary>
		/// DbType = "Int NOT NULL"
		/// </summary>
		public int ShipMethodID { get; set; }

		/// <summary>
		/// DbType = "DateTime NOT NULL", DefaultValue = /*getdate()*/ DateTime.Now
		/// </summary>
		public DateTime OrderDate { get; set; } = /*getdate()*/ DateTime.Now;

		/// <summary>
		/// DbType = "DateTime"
		/// </summary>
		public DateTime? ShipDate { get; set; }

		/// <summary>
		/// DbType = "Money NOT NULL", DefaultValue = (decimal)(0.00)
		/// </summary>
		public decimal SubTotal { get; set; } = (decimal)(0.00);

		/// <summary>
		/// DbType = "Money NOT NULL", DefaultValue = (decimal)(0.00)
		/// </summary>
		public decimal TaxAmt { get; set; } = (decimal)(0.00);

		/// <summary>
		/// DbType = "Money NOT NULL", DefaultValue = (decimal)(0.00)
		/// </summary>
		public decimal Freight { get; set; } = (decimal)(0.00);

		/// <summary>
		/// DbType = "Money NOT NULL"
		/// </summary>
		public decimal TotalDue { get; set; }

		/// <summary>
		/// DbType = "DateTime NOT NULL", DefaultValue = /*getdate()*/ DateTime.Now
		/// </summary>
		public DateTime ModifiedDate { get; set; } = /*getdate()*/ DateTime.Now;

		#endregion Columns

		#region Associations

		/// <summary>
		/// Association <br/>
		/// [PK][One]Purchasing_PurchaseOrderHeader.PurchaseOrderID --- [FK][Many]Purchasing_PurchaseOrderDetail.PurchaseOrderID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<Purchasing_PurchaseOrderDetail> Purchasing_PurchaseOrderDetailList { get; set; } = new List<Purchasing_PurchaseOrderDetail>();

		/// <summary>
		/// Association <br/>
		/// [FK][Many]Purchasing_PurchaseOrderHeader.EmployeeID --- [PK][One]HumanResources_Employee.EmployeeID <br/>
		/// </summary>
		public virtual HumanResources_Employee HumanResources_Employee { get; set; }

		/// <summary>
		/// Association <br/>
		/// [FK][Many]Purchasing_PurchaseOrderHeader.ShipMethodID --- [PK][One]Purchasing_ShipMethod.ShipMethodID <br/>
		/// </summary>
		public virtual Purchasing_ShipMethod Purchasing_ShipMethod { get; set; }

		/// <summary>
		/// Association <br/>
		/// [FK][Many]Purchasing_PurchaseOrderHeader.VendorID --- [PK][One]Purchasing_Vendor.VendorID <br/>
		/// </summary>
		public virtual Purchasing_Vendor Purchasing_Vendor { get; set; }
		#endregion Associations

		partial void OnCreated();
	}
	#endregion Purchasing.PurchaseOrderHeader

	#region Sales.SalesOrderDetail
	public partial class Sales_SalesOrderDetail : EFCoreEntityBase<Sales_SalesOrderDetail>
	{
		public Sales_SalesOrderDetail()
		{
			OnCreated();
		}

		public Sales_SalesOrderDetail(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "Int NOT NULL", IsPrimaryKey = true
		/// </summary>
		public int SalesOrderID { get; set; }

		/// <summary>
		/// DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert
		/// </summary>
		public int SalesOrderDetailID { get; set; }

		/// <summary>
		/// DbType = "NVarChar(25)"
		/// </summary>
		public string CarrierTrackingNumber { get; set; }

		/// <summary>
		/// DbType = "SmallInt NOT NULL"
		/// </summary>
		public System.Int16 OrderQty { get; set; }

		/// <summary>
		/// DbType = "Int NOT NULL"
		/// </summary>
		public int ProductID { get; set; }

		/// <summary>
		/// DbType = "Int NOT NULL"
		/// </summary>
		public int SpecialOfferID { get; set; }

		/// <summary>
		/// DbType = "Money NOT NULL"
		/// </summary>
		public decimal UnitPrice { get; set; }

		/// <summary>
		/// DbType = "Money NOT NULL", DefaultValue = (decimal)(0.0)
		/// </summary>
		public decimal UnitPriceDiscount { get; set; } = (decimal)(0.0);

		/// <summary>
		/// DbType = "Decimal(38,6) NOT NULL"
		/// </summary>
		public decimal LineTotal { get; set; }

		/// <summary>
		/// DbType = "UniqueIdentifier NOT NULL", DefaultValue = /*newid()*/ Guid.NewGuid()
		/// </summary>
		public System.Guid rowguid { get; set; } = /*newid()*/ Guid.NewGuid();

		/// <summary>
		/// DbType = "DateTime NOT NULL", DefaultValue = /*getdate()*/ DateTime.Now
		/// </summary>
		public DateTime ModifiedDate { get; set; } = /*getdate()*/ DateTime.Now;

		#endregion Columns

		#region Associations

		/// <summary>
		/// Association <br/>
		/// [FK][Many]Sales_SalesOrderDetail.SalesOrderID --- [PK][One]Sales_SalesOrderHeader.SalesOrderID <br/>
		/// DeleteOnNull = true <br/>
		/// </summary>
		public virtual Sales_SalesOrderHeader Sales_SalesOrderHeader { get; set; }

		/// <summary>
		/// Association <br/>
		/// [FK][Many]Sales_SalesOrderDetail.SpecialOfferID --- [PK][One]Sales_SpecialOfferProduct.SpecialOfferID <br/>
		/// </summary>
		public virtual Sales_SpecialOfferProduct Sales_SpecialOfferProduct { get; set; }
		#endregion Associations

		partial void OnCreated();
	}
	#endregion Sales.SalesOrderDetail

	#region Sales.SalesOrderHeader
	public partial class Sales_SalesOrderHeader : EFCoreEntityBase<Sales_SalesOrderHeader>
	{
		public Sales_SalesOrderHeader()
		{
			OnCreated();
		}

		public Sales_SalesOrderHeader(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert
		/// </summary>
		public int SalesOrderID { get; set; }

		/// <summary>
		/// DbType = "TinyInt NOT NULL", DefaultValue = (byte)(0)
		/// </summary>
		public byte RevisionNumber { get; set; } = (byte)(0);

		/// <summary>
		/// DbType = "DateTime NOT NULL", DefaultValue = /*getdate()*/ DateTime.Now
		/// </summary>
		public DateTime OrderDate { get; set; } = /*getdate()*/ DateTime.Now;

		/// <summary>
		/// DbType = "DateTime NOT NULL"
		/// </summary>
		public DateTime DueDate { get; set; }

		/// <summary>
		/// DbType = "DateTime"
		/// </summary>
		public DateTime? ShipDate { get; set; }

		/// <summary>
		/// DbType = "TinyInt NOT NULL", DefaultValue = (byte)(1)
		/// </summary>
		public byte Status { get; set; } = (byte)(1);

		/// <summary>
		/// DbType = "Bit NOT NULL", DefaultValue = true
		/// </summary>
		public bool OnlineOrderFlag { get; set; } = true;

		/// <summary>
		/// DbType = "NVarChar(25) NOT NULL"
		/// </summary>
		public string SalesOrderNumber { get; set; }

		/// <summary>
		/// DbType = "NVarChar(25)"
		/// </summary>
		public string PurchaseOrderNumber { get; set; }

		/// <summary>
		/// DbType = "NVarChar(15)"
		/// </summary>
		public string AccountNumber { get; set; }

		/// <summary>
		/// DbType = "Int NOT NULL"
		/// </summary>
		public int CustomerID { get; set; }

		/// <summary>
		/// DbType = "Int NOT NULL"
		/// </summary>
		public int ContactID { get; set; }

		/// <summary>
		/// DbType = "Int"
		/// </summary>
		public int? SalesPersonID { get; set; }

		/// <summary>
		/// DbType = "Int"
		/// </summary>
		public int? TerritoryID { get; set; }

		/// <summary>
		/// DbType = "Int NOT NULL"
		/// </summary>
		public int BillToAddressID { get; set; }

		/// <summary>
		/// DbType = "Int NOT NULL"
		/// </summary>
		public int ShipToAddressID { get; set; }

		/// <summary>
		/// DbType = "Int NOT NULL"
		/// </summary>
		public int ShipMethodID { get; set; }

		/// <summary>
		/// DbType = "Int"
		/// </summary>
		public int? CreditCardID { get; set; }

		/// <summary>
		/// DbType = "VarChar(15)"
		/// </summary>
		public string CreditCardApprovalCode { get; set; }

		/// <summary>
		/// DbType = "Int"
		/// </summary>
		public int? CurrencyRateID { get; set; }

		/// <summary>
		/// DbType = "Money NOT NULL", DefaultValue = (decimal)(0.00)
		/// </summary>
		public decimal SubTotal { get; set; } = (decimal)(0.00);

		/// <summary>
		/// DbType = "Money NOT NULL", DefaultValue = (decimal)(0.00)
		/// </summary>
		public decimal TaxAmt { get; set; } = (decimal)(0.00);

		/// <summary>
		/// DbType = "Money NOT NULL", DefaultValue = (decimal)(0.00)
		/// </summary>
		public decimal Freight { get; set; } = (decimal)(0.00);

		/// <summary>
		/// DbType = "Money NOT NULL"
		/// </summary>
		public decimal TotalDue { get; set; }

		/// <summary>
		/// DbType = "NVarChar(128)"
		/// </summary>
		public string Comment { get; set; }

		/// <summary>
		/// DbType = "UniqueIdentifier NOT NULL", DefaultValue = /*newid()*/ Guid.NewGuid()
		/// </summary>
		public System.Guid rowguid { get; set; } = /*newid()*/ Guid.NewGuid();

		/// <summary>
		/// DbType = "DateTime NOT NULL", DefaultValue = /*getdate()*/ DateTime.Now
		/// </summary>
		public DateTime ModifiedDate { get; set; } = /*getdate()*/ DateTime.Now;

		#endregion Columns

		#region Associations

		/// <summary>
		/// Association <br/>
		/// [PK][One]Sales_SalesOrderHeader.SalesOrderID --- [FK][Many]Sales_SalesOrderDetail.SalesOrderID <br/>
		/// DeleteRule = Cascade <br/>
		/// </summary>
		public virtual List<Sales_SalesOrderDetail> Sales_SalesOrderDetailList { get; set; } = new List<Sales_SalesOrderDetail>();

		/// <summary>
		/// Association <br/>
		/// [FK][Many]Sales_SalesOrderHeader.BillToAddressID --- [PK][One]Person_Address.AddressID <br/>
		/// </summary>
		public virtual Person_Address Person_Address { get; set; }

		/// <summary>
		/// Association <br/>
		/// [FK][Many]Sales_SalesOrderHeader.ShipToAddressID --- [PK][One]Person_Address.AddressID <br/>
		/// </summary>
		public virtual Person_Address ShipToAddress { get; set; }

		/// <summary>
		/// Association <br/>
		/// [FK][Many]Sales_SalesOrderHeader.ContactID --- [PK][One]Person_Contact.ContactID <br/>
		/// </summary>
		public virtual Person_Contact Person_Contact { get; set; }

		/// <summary>
		/// Association <br/>
		/// [FK][Many]Sales_SalesOrderHeader.CreditCardID --- [PK][One]Sales_CreditCard.CreditCardID <br/>
		/// </summary>
		public virtual Sales_CreditCard Sales_CreditCard { get; set; }

		/// <summary>
		/// Association <br/>
		/// [FK][Many]Sales_SalesOrderHeader.CurrencyRateID --- [PK][One]Sales_CurrencyRate.CurrencyRateID <br/>
		/// </summary>
		public virtual Sales_CurrencyRate Sales_CurrencyRate { get; set; }

		/// <summary>
		/// Association <br/>
		/// [FK][Many]Sales_SalesOrderHeader.CustomerID --- [PK][One]Sales_Customer.CustomerID <br/>
		/// </summary>
		public virtual Sales_Customer Sales_Customer { get; set; }

		/// <summary>
		/// Association <br/>
		/// [FK][Many]Sales_SalesOrderHeader.SalesPersonID --- [PK][One]Sales_SalesPerson.SalesPersonID <br/>
		/// </summary>
		public virtual Sales_SalesPerson Sales_SalesPerson { get; set; }

		/// <summary>
		/// Association <br/>
		/// [FK][Many]Sales_SalesOrderHeader.TerritoryID --- [PK][One]Sales_SalesTerritory.TerritoryID <br/>
		/// </summary>
		public virtual Sales_SalesTerritory Sales_SalesTerritory { get; set; }

		/// <summary>
		/// Association <br/>
		/// [FK][Many]Sales_SalesOrderHeader.ShipMethodID --- [PK][One]Purchasing_ShipMethod.ShipMethodID <br/>
		/// </summary>
		public virtual Purchasing_ShipMethod Purchasing_ShipMethod { get; set; }

		/// <summary>
		/// Association <br/>
		/// [PK][One]Sales_SalesOrderHeader.SalesOrderID --- [FK][Many]Sales_SalesOrderHeaderSalesReason.SalesOrderID <br/>
		/// DeleteRule = Cascade <br/>
		/// </summary>
		public virtual List<Sales_SalesOrderHeaderSalesReason> Sales_SalesOrderHeaderSalesReasonList { get; set; } = new List<Sales_SalesOrderHeaderSalesReason>();
		#endregion Associations

		partial void OnCreated();
	}
	#endregion Sales.SalesOrderHeader

	#region Sales.SalesOrderHeaderSalesReason
	public partial class Sales_SalesOrderHeaderSalesReason : EFCoreEntityBase<Sales_SalesOrderHeaderSalesReason>
	{
		public Sales_SalesOrderHeaderSalesReason()
		{
			OnCreated();
		}

		public Sales_SalesOrderHeaderSalesReason(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "Int NOT NULL", IsPrimaryKey = true
		/// </summary>
		public int SalesOrderID { get; set; }

		/// <summary>
		/// DbType = "Int NOT NULL", IsPrimaryKey = true
		/// </summary>
		public int SalesReasonID { get; set; }

		/// <summary>
		/// DbType = "DateTime NOT NULL", DefaultValue = /*getdate()*/ DateTime.Now
		/// </summary>
		public DateTime ModifiedDate { get; set; } = /*getdate()*/ DateTime.Now;

		#endregion Columns

		#region Associations

		/// <summary>
		/// Association <br/>
		/// [FK][Many]Sales_SalesOrderHeaderSalesReason.SalesOrderID --- [PK][One]Sales_SalesOrderHeader.SalesOrderID <br/>
		/// DeleteOnNull = true <br/>
		/// </summary>
		public virtual Sales_SalesOrderHeader Sales_SalesOrderHeader { get; set; }

		/// <summary>
		/// Association <br/>
		/// [FK][Many]Sales_SalesOrderHeaderSalesReason.SalesReasonID --- [PK][One]Sales_SalesReason.SalesReasonID <br/>
		/// </summary>
		public virtual Sales_SalesReason Sales_SalesReason { get; set; }
		#endregion Associations

		partial void OnCreated();
	}
	#endregion Sales.SalesOrderHeaderSalesReason

	#region Sales.SalesPerson
	public partial class Sales_SalesPerson : EFCoreEntityBase<Sales_SalesPerson>
	{
		public Sales_SalesPerson()
		{
			OnCreated();
		}

		public Sales_SalesPerson(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "Int NOT NULL", IsPrimaryKey = true
		/// </summary>
		public int SalesPersonID { get; set; }

		/// <summary>
		/// DbType = "Int"
		/// </summary>
		public int? TerritoryID { get; set; }

		/// <summary>
		/// DbType = "Money"
		/// </summary>
		public decimal? SalesQuota { get; set; }

		/// <summary>
		/// DbType = "Money NOT NULL", DefaultValue = (decimal)(0.00)
		/// </summary>
		public decimal Bonus { get; set; } = (decimal)(0.00);

		/// <summary>
		/// DbType = "SmallMoney NOT NULL", DefaultValue = (decimal)(0.00)
		/// </summary>
		public decimal CommissionPct { get; set; } = (decimal)(0.00);

		/// <summary>
		/// DbType = "Money NOT NULL", DefaultValue = (decimal)(0.00)
		/// </summary>
		public decimal SalesYTD { get; set; } = (decimal)(0.00);

		/// <summary>
		/// DbType = "Money NOT NULL", DefaultValue = (decimal)(0.00)
		/// </summary>
		public decimal SalesLastYear { get; set; } = (decimal)(0.00);

		/// <summary>
		/// DbType = "UniqueIdentifier NOT NULL", DefaultValue = /*newid()*/ Guid.NewGuid()
		/// </summary>
		public System.Guid rowguid { get; set; } = /*newid()*/ Guid.NewGuid();

		/// <summary>
		/// DbType = "DateTime NOT NULL", DefaultValue = /*getdate()*/ DateTime.Now
		/// </summary>
		public DateTime ModifiedDate { get; set; } = /*getdate()*/ DateTime.Now;

		#endregion Columns

		#region Associations

		/// <summary>
		/// Association <br/>
		/// [PK][One]Sales_SalesPerson.SalesPersonID --- [FK][Many]Sales_SalesOrderHeader.SalesPersonID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<Sales_SalesOrderHeader> Sales_SalesOrderHeaderList { get; set; } = new List<Sales_SalesOrderHeader>();

		/// <summary>
		/// Association <br/>
		/// [FK][One]Sales_SalesPerson.SalesPersonID --- [PK][One]HumanResources_Employee.EmployeeID <br/>
		/// </summary>
		public virtual HumanResources_Employee HumanResources_Employee { get; set; }

		/// <summary>
		/// Association <br/>
		/// [FK][Many]Sales_SalesPerson.TerritoryID --- [PK][One]Sales_SalesTerritory.TerritoryID <br/>
		/// </summary>
		public virtual Sales_SalesTerritory Sales_SalesTerritory { get; set; }

		/// <summary>
		/// Association <br/>
		/// [PK][One]Sales_SalesPerson.SalesPersonID --- [FK][Many]Sales_SalesPersonQuotaHistory.SalesPersonID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<Sales_SalesPersonQuotaHistory> Sales_SalesPersonQuotaHistoryList { get; set; } = new List<Sales_SalesPersonQuotaHistory>();

		/// <summary>
		/// Association <br/>
		/// [PK][One]Sales_SalesPerson.SalesPersonID --- [FK][Many]Sales_SalesTerritoryHistory.SalesPersonID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<Sales_SalesTerritoryHistory> Sales_SalesTerritoryHistoryList { get; set; } = new List<Sales_SalesTerritoryHistory>();

		/// <summary>
		/// Association <br/>
		/// [PK][One]Sales_SalesPerson.SalesPersonID --- [FK][Many]Sales_Store.SalesPersonID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<Sales_Store> Sales_StoreList { get; set; } = new List<Sales_Store>();
		#endregion Associations

		partial void OnCreated();
	}
	#endregion Sales.SalesPerson

	#region Sales.SalesPersonQuotaHistory
	public partial class Sales_SalesPersonQuotaHistory : EFCoreEntityBase<Sales_SalesPersonQuotaHistory>
	{
		public Sales_SalesPersonQuotaHistory()
		{
			OnCreated();
		}

		public Sales_SalesPersonQuotaHistory(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "Int NOT NULL", IsPrimaryKey = true
		/// </summary>
		public int SalesPersonID { get; set; }

		/// <summary>
		/// DbType = "DateTime NOT NULL", IsPrimaryKey = true
		/// </summary>
		public DateTime QuotaDate { get; set; }

		/// <summary>
		/// DbType = "Money NOT NULL"
		/// </summary>
		public decimal SalesQuota { get; set; }

		/// <summary>
		/// DbType = "UniqueIdentifier NOT NULL", DefaultValue = /*newid()*/ Guid.NewGuid()
		/// </summary>
		public System.Guid rowguid { get; set; } = /*newid()*/ Guid.NewGuid();

		/// <summary>
		/// DbType = "DateTime NOT NULL", DefaultValue = /*getdate()*/ DateTime.Now
		/// </summary>
		public DateTime ModifiedDate { get; set; } = /*getdate()*/ DateTime.Now;

		#endregion Columns

		#region Associations

		/// <summary>
		/// Association <br/>
		/// [FK][Many]Sales_SalesPersonQuotaHistory.SalesPersonID --- [PK][One]Sales_SalesPerson.SalesPersonID <br/>
		/// </summary>
		public virtual Sales_SalesPerson Sales_SalesPerson { get; set; }
		#endregion Associations

		partial void OnCreated();
	}
	#endregion Sales.SalesPersonQuotaHistory

	#region Sales.SalesReason
	public partial class Sales_SalesReason : EFCoreEntityBase<Sales_SalesReason>
	{
		public Sales_SalesReason()
		{
			OnCreated();
		}

		public Sales_SalesReason(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert
		/// </summary>
		public int SalesReasonID { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50) NOT NULL"
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50) NOT NULL"
		/// </summary>
		public string ReasonType { get; set; }

		/// <summary>
		/// DbType = "DateTime NOT NULL", DefaultValue = /*getdate()*/ DateTime.Now
		/// </summary>
		public DateTime ModifiedDate { get; set; } = /*getdate()*/ DateTime.Now;

		#endregion Columns

		#region Associations

		/// <summary>
		/// Association <br/>
		/// [PK][One]Sales_SalesReason.SalesReasonID --- [FK][Many]Sales_SalesOrderHeaderSalesReason.SalesReasonID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<Sales_SalesOrderHeaderSalesReason> Sales_SalesOrderHeaderSalesReasonList { get; set; } = new List<Sales_SalesOrderHeaderSalesReason>();
		#endregion Associations

		partial void OnCreated();
	}
	#endregion Sales.SalesReason

	#region Sales.SalesTaxRate
	public partial class Sales_SalesTaxRate : EFCoreEntityBase<Sales_SalesTaxRate>
	{
		public Sales_SalesTaxRate()
		{
			OnCreated();
		}

		public Sales_SalesTaxRate(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert
		/// </summary>
		public int SalesTaxRateID { get; set; }

		/// <summary>
		/// DbType = "Int NOT NULL"
		/// </summary>
		public int StateProvinceID { get; set; }

		/// <summary>
		/// DbType = "TinyInt NOT NULL"
		/// </summary>
		public byte TaxType { get; set; }

		/// <summary>
		/// DbType = "SmallMoney NOT NULL", DefaultValue = (decimal)(0.00)
		/// </summary>
		public decimal TaxRate { get; set; } = (decimal)(0.00);

		/// <summary>
		/// DbType = "NVarChar(50) NOT NULL"
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// DbType = "UniqueIdentifier NOT NULL", DefaultValue = /*newid()*/ Guid.NewGuid()
		/// </summary>
		public System.Guid rowguid { get; set; } = /*newid()*/ Guid.NewGuid();

		/// <summary>
		/// DbType = "DateTime NOT NULL", DefaultValue = /*getdate()*/ DateTime.Now
		/// </summary>
		public DateTime ModifiedDate { get; set; } = /*getdate()*/ DateTime.Now;

		#endregion Columns

		#region Associations

		/// <summary>
		/// Association <br/>
		/// [FK][Many]Sales_SalesTaxRate.StateProvinceID --- [PK][One]Person_StateProvince.StateProvinceID <br/>
		/// </summary>
		public virtual Person_StateProvince Person_StateProvince { get; set; }
		#endregion Associations

		partial void OnCreated();
	}
	#endregion Sales.SalesTaxRate

	#region Sales.SalesTerritory
	public partial class Sales_SalesTerritory : EFCoreEntityBase<Sales_SalesTerritory>
	{
		public Sales_SalesTerritory()
		{
			OnCreated();
		}

		public Sales_SalesTerritory(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert
		/// </summary>
		public int TerritoryID { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50) NOT NULL"
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// DbType = "NVarChar(3) NOT NULL"
		/// </summary>
		public string CountryRegionCode { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50) NOT NULL"
		/// </summary>
		public string Group { get; set; }

		/// <summary>
		/// DbType = "Money NOT NULL", DefaultValue = (decimal)(0.00)
		/// </summary>
		public decimal SalesYTD { get; set; } = (decimal)(0.00);

		/// <summary>
		/// DbType = "Money NOT NULL", DefaultValue = (decimal)(0.00)
		/// </summary>
		public decimal SalesLastYear { get; set; } = (decimal)(0.00);

		/// <summary>
		/// DbType = "Money NOT NULL", DefaultValue = (decimal)(0.00)
		/// </summary>
		public decimal CostYTD { get; set; } = (decimal)(0.00);

		/// <summary>
		/// DbType = "Money NOT NULL", DefaultValue = (decimal)(0.00)
		/// </summary>
		public decimal CostLastYear { get; set; } = (decimal)(0.00);

		/// <summary>
		/// DbType = "UniqueIdentifier NOT NULL", DefaultValue = /*newid()*/ Guid.NewGuid()
		/// </summary>
		public System.Guid rowguid { get; set; } = /*newid()*/ Guid.NewGuid();

		/// <summary>
		/// DbType = "DateTime NOT NULL", DefaultValue = /*getdate()*/ DateTime.Now
		/// </summary>
		public DateTime ModifiedDate { get; set; } = /*getdate()*/ DateTime.Now;

		#endregion Columns

		#region Associations

		/// <summary>
		/// Association <br/>
		/// [PK][One]Sales_SalesTerritory.TerritoryID --- [FK][Many]Person_StateProvince.TerritoryID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<Person_StateProvince> Person_StateProvinceList { get; set; } = new List<Person_StateProvince>();

		/// <summary>
		/// Association <br/>
		/// [PK][One]Sales_SalesTerritory.TerritoryID --- [FK][Many]Sales_Customer.TerritoryID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<Sales_Customer> Sales_CustomerList { get; set; } = new List<Sales_Customer>();

		/// <summary>
		/// Association <br/>
		/// [PK][One]Sales_SalesTerritory.TerritoryID --- [FK][Many]Sales_SalesOrderHeader.TerritoryID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<Sales_SalesOrderHeader> Sales_SalesOrderHeaderList { get; set; } = new List<Sales_SalesOrderHeader>();

		/// <summary>
		/// Association <br/>
		/// [PK][One]Sales_SalesTerritory.TerritoryID --- [FK][Many]Sales_SalesPerson.TerritoryID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<Sales_SalesPerson> Sales_SalesPersonList { get; set; } = new List<Sales_SalesPerson>();

		/// <summary>
		/// Association <br/>
		/// [PK][One]Sales_SalesTerritory.TerritoryID --- [FK][Many]Sales_SalesTerritoryHistory.TerritoryID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<Sales_SalesTerritoryHistory> Sales_SalesTerritoryHistoryList { get; set; } = new List<Sales_SalesTerritoryHistory>();
		#endregion Associations

		partial void OnCreated();
	}
	#endregion Sales.SalesTerritory

	#region Sales.SalesTerritoryHistory
	public partial class Sales_SalesTerritoryHistory : EFCoreEntityBase<Sales_SalesTerritoryHistory>
	{
		public Sales_SalesTerritoryHistory()
		{
			OnCreated();
		}

		public Sales_SalesTerritoryHistory(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "Int NOT NULL", IsPrimaryKey = true
		/// </summary>
		public int SalesPersonID { get; set; }

		/// <summary>
		/// DbType = "Int NOT NULL", IsPrimaryKey = true
		/// </summary>
		public int TerritoryID { get; set; }

		/// <summary>
		/// DbType = "DateTime NOT NULL", IsPrimaryKey = true
		/// </summary>
		public DateTime StartDate { get; set; }

		/// <summary>
		/// DbType = "DateTime"
		/// </summary>
		public DateTime? EndDate { get; set; }

		/// <summary>
		/// DbType = "UniqueIdentifier NOT NULL", DefaultValue = /*newid()*/ Guid.NewGuid()
		/// </summary>
		public System.Guid rowguid { get; set; } = /*newid()*/ Guid.NewGuid();

		/// <summary>
		/// DbType = "DateTime NOT NULL", DefaultValue = /*getdate()*/ DateTime.Now
		/// </summary>
		public DateTime ModifiedDate { get; set; } = /*getdate()*/ DateTime.Now;

		#endregion Columns

		#region Associations

		/// <summary>
		/// Association <br/>
		/// [FK][Many]Sales_SalesTerritoryHistory.SalesPersonID --- [PK][One]Sales_SalesPerson.SalesPersonID <br/>
		/// </summary>
		public virtual Sales_SalesPerson Sales_SalesPerson { get; set; }

		/// <summary>
		/// Association <br/>
		/// [FK][Many]Sales_SalesTerritoryHistory.TerritoryID --- [PK][One]Sales_SalesTerritory.TerritoryID <br/>
		/// </summary>
		public virtual Sales_SalesTerritory Sales_SalesTerritory { get; set; }
		#endregion Associations

		partial void OnCreated();
	}
	#endregion Sales.SalesTerritoryHistory

	#region Production.ScrapReason
	public partial class Production_ScrapReason : EFCoreEntityBase<Production_ScrapReason>
	{
		public Production_ScrapReason()
		{
			OnCreated();
		}

		public Production_ScrapReason(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "SmallInt NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert
		/// </summary>
		public System.Int16 ScrapReasonID { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50) NOT NULL"
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// DbType = "DateTime NOT NULL", DefaultValue = /*getdate()*/ DateTime.Now
		/// </summary>
		public DateTime ModifiedDate { get; set; } = /*getdate()*/ DateTime.Now;

		#endregion Columns

		#region Associations

		/// <summary>
		/// Association <br/>
		/// [PK][One]Production_ScrapReason.ScrapReasonID --- [FK][Many]Production_WorkOrder.ScrapReasonID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<Production_WorkOrder> Production_WorkOrderList { get; set; } = new List<Production_WorkOrder>();
		#endregion Associations

		partial void OnCreated();
	}
	#endregion Production.ScrapReason

	#region HumanResources.Shift
	public partial class HumanResources_Shift : EFCoreEntityBase<HumanResources_Shift>
	{
		public HumanResources_Shift()
		{
			OnCreated();
		}

		public HumanResources_Shift(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "TinyInt NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert
		/// </summary>
		public byte ShiftID { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50) NOT NULL"
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// DbType = "DateTime NOT NULL"
		/// </summary>
		public DateTime StartTime { get; set; }

		/// <summary>
		/// DbType = "DateTime NOT NULL"
		/// </summary>
		public DateTime EndTime { get; set; }

		/// <summary>
		/// DbType = "DateTime NOT NULL", DefaultValue = /*getdate()*/ DateTime.Now
		/// </summary>
		public DateTime ModifiedDate { get; set; } = /*getdate()*/ DateTime.Now;

		#endregion Columns

		#region Associations

		/// <summary>
		/// Association <br/>
		/// [PK][One]HumanResources_Shift.ShiftID --- [FK][Many]HumanResources_EmployeeDepartmentHistory.ShiftID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<HumanResources_EmployeeDepartmentHistory> HumanResources_EmployeeDepartmentHistoryList { get; set; } = new List<HumanResources_EmployeeDepartmentHistory>();
		#endregion Associations

		partial void OnCreated();
	}
	#endregion HumanResources.Shift

	#region Purchasing.ShipMethod
	public partial class Purchasing_ShipMethod : EFCoreEntityBase<Purchasing_ShipMethod>
	{
		public Purchasing_ShipMethod()
		{
			OnCreated();
		}

		public Purchasing_ShipMethod(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert
		/// </summary>
		public int ShipMethodID { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50) NOT NULL"
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// DbType = "Money NOT NULL", DefaultValue = (decimal)(0.00)
		/// </summary>
		public decimal ShipBase { get; set; } = (decimal)(0.00);

		/// <summary>
		/// DbType = "Money NOT NULL", DefaultValue = (decimal)(0.00)
		/// </summary>
		public decimal ShipRate { get; set; } = (decimal)(0.00);

		/// <summary>
		/// DbType = "UniqueIdentifier NOT NULL", DefaultValue = /*newid()*/ Guid.NewGuid()
		/// </summary>
		public System.Guid rowguid { get; set; } = /*newid()*/ Guid.NewGuid();

		/// <summary>
		/// DbType = "DateTime NOT NULL", DefaultValue = /*getdate()*/ DateTime.Now
		/// </summary>
		public DateTime ModifiedDate { get; set; } = /*getdate()*/ DateTime.Now;

		#endregion Columns

		#region Associations

		/// <summary>
		/// Association <br/>
		/// [PK][One]Purchasing_ShipMethod.ShipMethodID --- [FK][Many]Purchasing_PurchaseOrderHeader.ShipMethodID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<Purchasing_PurchaseOrderHeader> Purchasing_PurchaseOrderHeaderList { get; set; } = new List<Purchasing_PurchaseOrderHeader>();

		/// <summary>
		/// Association <br/>
		/// [PK][One]Purchasing_ShipMethod.ShipMethodID --- [FK][Many]Sales_SalesOrderHeader.ShipMethodID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<Sales_SalesOrderHeader> Sales_SalesOrderHeaderList { get; set; } = new List<Sales_SalesOrderHeader>();
		#endregion Associations

		partial void OnCreated();
	}
	#endregion Purchasing.ShipMethod

	#region Sales.ShoppingCartItem
	public partial class Sales_ShoppingCartItem : EFCoreEntityBase<Sales_ShoppingCartItem>
	{
		public Sales_ShoppingCartItem()
		{
			OnCreated();
		}

		public Sales_ShoppingCartItem(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert
		/// </summary>
		public int ShoppingCartItemID { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50) NOT NULL"
		/// </summary>
		public string ShoppingCartID { get; set; }

		/// <summary>
		/// DbType = "Int NOT NULL", DefaultValue = (int)(1)
		/// </summary>
		public int Quantity { get; set; } = (int)(1);

		/// <summary>
		/// DbType = "Int NOT NULL"
		/// </summary>
		public int ProductID { get; set; }

		/// <summary>
		/// DbType = "DateTime NOT NULL", DefaultValue = /*getdate()*/ DateTime.Now
		/// </summary>
		public DateTime DateCreated { get; set; } = /*getdate()*/ DateTime.Now;

		/// <summary>
		/// DbType = "DateTime NOT NULL", DefaultValue = /*getdate()*/ DateTime.Now
		/// </summary>
		public DateTime ModifiedDate { get; set; } = /*getdate()*/ DateTime.Now;

		#endregion Columns

		#region Associations

		/// <summary>
		/// Association <br/>
		/// [FK][Many]Sales_ShoppingCartItem.ProductID --- [PK][One]Production_Product.ProductID <br/>
		/// </summary>
		public virtual Production_Product Production_Product { get; set; }
		#endregion Associations

		partial void OnCreated();
	}
	#endregion Sales.ShoppingCartItem

	#region Sales.SpecialOffer
	public partial class Sales_SpecialOffer : EFCoreEntityBase<Sales_SpecialOffer>
	{
		public Sales_SpecialOffer()
		{
			OnCreated();
		}

		public Sales_SpecialOffer(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert
		/// </summary>
		public int SpecialOfferID { get; set; }

		/// <summary>
		/// DbType = "NVarChar(255) NOT NULL"
		/// </summary>
		public string Description { get; set; }

		/// <summary>
		/// DbType = "SmallMoney NOT NULL", DefaultValue = (decimal)(0.00)
		/// </summary>
		public decimal DiscountPct { get; set; } = (decimal)(0.00);

		/// <summary>
		/// DbType = "NVarChar(50) NOT NULL"
		/// </summary>
		public string Type { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50) NOT NULL"
		/// </summary>
		public string Category { get; set; }

		/// <summary>
		/// DbType = "DateTime NOT NULL"
		/// </summary>
		public DateTime StartDate { get; set; }

		/// <summary>
		/// DbType = "DateTime NOT NULL"
		/// </summary>
		public DateTime EndDate { get; set; }

		/// <summary>
		/// DbType = "Int NOT NULL", DefaultValue = (int)(0)
		/// </summary>
		public int MinQty { get; set; } = (int)(0);

		/// <summary>
		/// DbType = "Int"
		/// </summary>
		public int? MaxQty { get; set; }

		/// <summary>
		/// DbType = "UniqueIdentifier NOT NULL", DefaultValue = /*newid()*/ Guid.NewGuid()
		/// </summary>
		public System.Guid rowguid { get; set; } = /*newid()*/ Guid.NewGuid();

		/// <summary>
		/// DbType = "DateTime NOT NULL", DefaultValue = /*getdate()*/ DateTime.Now
		/// </summary>
		public DateTime ModifiedDate { get; set; } = /*getdate()*/ DateTime.Now;

		#endregion Columns

		#region Associations

		/// <summary>
		/// Association <br/>
		/// [PK][One]Sales_SpecialOffer.SpecialOfferID --- [FK][Many]Sales_SpecialOfferProduct.SpecialOfferID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<Sales_SpecialOfferProduct> Sales_SpecialOfferProductList { get; set; } = new List<Sales_SpecialOfferProduct>();
		#endregion Associations

		partial void OnCreated();
	}
	#endregion Sales.SpecialOffer

	#region Sales.SpecialOfferProduct
	public partial class Sales_SpecialOfferProduct : EFCoreEntityBase<Sales_SpecialOfferProduct>
	{
		public Sales_SpecialOfferProduct()
		{
			OnCreated();
		}

		public Sales_SpecialOfferProduct(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "Int NOT NULL", IsPrimaryKey = true
		/// </summary>
		public int SpecialOfferID { get; set; }

		/// <summary>
		/// DbType = "Int NOT NULL", IsPrimaryKey = true
		/// </summary>
		public int ProductID { get; set; }

		/// <summary>
		/// DbType = "UniqueIdentifier NOT NULL", DefaultValue = /*newid()*/ Guid.NewGuid()
		/// </summary>
		public System.Guid rowguid { get; set; } = /*newid()*/ Guid.NewGuid();

		/// <summary>
		/// DbType = "DateTime NOT NULL", DefaultValue = /*getdate()*/ DateTime.Now
		/// </summary>
		public DateTime ModifiedDate { get; set; } = /*getdate()*/ DateTime.Now;

		#endregion Columns

		#region Associations

		/// <summary>
		/// Association <br/>
		/// [PK][One]Sales_SpecialOfferProduct.SpecialOfferID --- [FK][Many]Sales_SalesOrderDetail.SpecialOfferID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<Sales_SalesOrderDetail> Sales_SalesOrderDetailList { get; set; } = new List<Sales_SalesOrderDetail>();

		/// <summary>
		/// Association <br/>
		/// [FK][Many]Sales_SpecialOfferProduct.ProductID --- [PK][One]Production_Product.ProductID <br/>
		/// </summary>
		public virtual Production_Product Production_Product { get; set; }

		/// <summary>
		/// Association <br/>
		/// [FK][Many]Sales_SpecialOfferProduct.SpecialOfferID --- [PK][One]Sales_SpecialOffer.SpecialOfferID <br/>
		/// </summary>
		public virtual Sales_SpecialOffer Sales_SpecialOffer { get; set; }
		#endregion Associations

		partial void OnCreated();
	}
	#endregion Sales.SpecialOfferProduct

	#region Person.StateProvince
	public partial class Person_StateProvince : EFCoreEntityBase<Person_StateProvince>
	{
		public Person_StateProvince()
		{
			OnCreated();
		}

		public Person_StateProvince(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert
		/// </summary>
		public int StateProvinceID { get; set; }

		/// <summary>
		/// DbType = "NChar(3) NOT NULL"
		/// </summary>
		public string StateProvinceCode { get; set; }

		/// <summary>
		/// DbType = "NVarChar(3) NOT NULL"
		/// </summary>
		public string CountryRegionCode { get; set; }

		/// <summary>
		/// DbType = "Bit NOT NULL", DefaultValue = true
		/// </summary>
		public bool IsOnlyStateProvinceFlag { get; set; } = true;

		/// <summary>
		/// DbType = "NVarChar(50) NOT NULL"
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// DbType = "Int NOT NULL"
		/// </summary>
		public int TerritoryID { get; set; }

		/// <summary>
		/// DbType = "UniqueIdentifier NOT NULL", DefaultValue = /*newid()*/ Guid.NewGuid()
		/// </summary>
		public System.Guid rowguid { get; set; } = /*newid()*/ Guid.NewGuid();

		/// <summary>
		/// DbType = "DateTime NOT NULL", DefaultValue = /*getdate()*/ DateTime.Now
		/// </summary>
		public DateTime ModifiedDate { get; set; } = /*getdate()*/ DateTime.Now;

		#endregion Columns

		#region Associations

		/// <summary>
		/// Association <br/>
		/// [PK][One]Person_StateProvince.StateProvinceID --- [FK][Many]Person_Address.StateProvinceID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<Person_Address> Person_AddressList { get; set; } = new List<Person_Address>();

		/// <summary>
		/// Association <br/>
		/// [FK][Many]Person_StateProvince.CountryRegionCode --- [PK][One]Person_CountryRegion.CountryRegionCode <br/>
		/// </summary>
		public virtual Person_CountryRegion Person_CountryRegion { get; set; }

		/// <summary>
		/// Association <br/>
		/// [FK][Many]Person_StateProvince.TerritoryID --- [PK][One]Sales_SalesTerritory.TerritoryID <br/>
		/// </summary>
		public virtual Sales_SalesTerritory Sales_SalesTerritory { get; set; }

		/// <summary>
		/// Association <br/>
		/// [PK][One]Person_StateProvince.StateProvinceID --- [FK][Many]Sales_SalesTaxRate.StateProvinceID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<Sales_SalesTaxRate> Sales_SalesTaxRateList { get; set; } = new List<Sales_SalesTaxRate>();
		#endregion Associations

		partial void OnCreated();
	}
	#endregion Person.StateProvince

	#region Sales.Store
	public partial class Sales_Store : EFCoreEntityBase<Sales_Store>
	{
		public Sales_Store()
		{
			OnCreated();
		}

		public Sales_Store(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "Int NOT NULL", IsPrimaryKey = true
		/// </summary>
		public int CustomerID { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50) NOT NULL"
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// DbType = "Int"
		/// </summary>
		public int? SalesPersonID { get; set; }

		/// <summary>
		/// DbType = "Xml"
		/// </summary>
		public System.Xml.Linq.XElement Demographics { get; set; }

		/// <summary>
		/// DbType = "UniqueIdentifier NOT NULL", DefaultValue = /*newid()*/ Guid.NewGuid()
		/// </summary>
		public System.Guid rowguid { get; set; } = /*newid()*/ Guid.NewGuid();

		/// <summary>
		/// DbType = "DateTime NOT NULL", DefaultValue = /*getdate()*/ DateTime.Now
		/// </summary>
		public DateTime ModifiedDate { get; set; } = /*getdate()*/ DateTime.Now;

		#endregion Columns

		#region Associations

		/// <summary>
		/// Association <br/>
		/// [FK][One]Sales_Store.CustomerID --- [PK][One]Sales_Customer.CustomerID <br/>
		/// </summary>
		public virtual Sales_Customer Sales_Customer { get; set; }

		/// <summary>
		/// Association <br/>
		/// [FK][Many]Sales_Store.SalesPersonID --- [PK][One]Sales_SalesPerson.SalesPersonID <br/>
		/// </summary>
		public virtual Sales_SalesPerson Sales_SalesPerson { get; set; }

		/// <summary>
		/// Association <br/>
		/// [PK][One]Sales_Store.CustomerID --- [FK][Many]Sales_StoreContact.CustomerID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<Sales_StoreContact> Sales_StoreContactList { get; set; } = new List<Sales_StoreContact>();
		#endregion Associations

		partial void OnCreated();
	}
	#endregion Sales.Store

	#region Sales.StoreContact
	public partial class Sales_StoreContact : EFCoreEntityBase<Sales_StoreContact>
	{
		public Sales_StoreContact()
		{
			OnCreated();
		}

		public Sales_StoreContact(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "Int NOT NULL", IsPrimaryKey = true
		/// </summary>
		public int CustomerID { get; set; }

		/// <summary>
		/// DbType = "Int NOT NULL", IsPrimaryKey = true
		/// </summary>
		public int ContactID { get; set; }

		/// <summary>
		/// DbType = "Int NOT NULL"
		/// </summary>
		public int ContactTypeID { get; set; }

		/// <summary>
		/// DbType = "UniqueIdentifier NOT NULL", DefaultValue = /*newid()*/ Guid.NewGuid()
		/// </summary>
		public System.Guid rowguid { get; set; } = /*newid()*/ Guid.NewGuid();

		/// <summary>
		/// DbType = "DateTime NOT NULL", DefaultValue = /*getdate()*/ DateTime.Now
		/// </summary>
		public DateTime ModifiedDate { get; set; } = /*getdate()*/ DateTime.Now;

		#endregion Columns

		#region Associations

		/// <summary>
		/// Association <br/>
		/// [FK][Many]Sales_StoreContact.ContactID --- [PK][One]Person_Contact.ContactID <br/>
		/// </summary>
		public virtual Person_Contact Person_Contact { get; set; }

		/// <summary>
		/// Association <br/>
		/// [FK][Many]Sales_StoreContact.ContactTypeID --- [PK][One]Person_ContactType.ContactTypeID <br/>
		/// </summary>
		public virtual Person_ContactType Person_ContactType { get; set; }

		/// <summary>
		/// Association <br/>
		/// [FK][Many]Sales_StoreContact.CustomerID --- [PK][One]Sales_Store.CustomerID <br/>
		/// </summary>
		public virtual Sales_Store Sales_Store { get; set; }
		#endregion Associations

		partial void OnCreated();
	}
	#endregion Sales.StoreContact

	#region Production.TransactionHistory
	public partial class Production_TransactionHistory : EFCoreEntityBase<Production_TransactionHistory>
	{
		public Production_TransactionHistory()
		{
			OnCreated();
		}

		public Production_TransactionHistory(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert
		/// </summary>
		public int TransactionID { get; set; }

		/// <summary>
		/// DbType = "Int NOT NULL"
		/// </summary>
		public int ProductID { get; set; }

		/// <summary>
		/// DbType = "Int NOT NULL"
		/// </summary>
		public int ReferenceOrderID { get; set; }

		/// <summary>
		/// DbType = "Int NOT NULL", DefaultValue = (int)(0)
		/// </summary>
		public int ReferenceOrderLineID { get; set; } = (int)(0);

		/// <summary>
		/// DbType = "DateTime NOT NULL", DefaultValue = /*getdate()*/ DateTime.Now
		/// </summary>
		public DateTime TransactionDate { get; set; } = /*getdate()*/ DateTime.Now;

		/// <summary>
		/// DbType = "NChar(1) NOT NULL"
		/// </summary>
		public string TransactionType { get; set; }

		/// <summary>
		/// DbType = "Int NOT NULL"
		/// </summary>
		public int Quantity { get; set; }

		/// <summary>
		/// DbType = "Money NOT NULL"
		/// </summary>
		public decimal ActualCost { get; set; }

		/// <summary>
		/// DbType = "DateTime NOT NULL", DefaultValue = /*getdate()*/ DateTime.Now
		/// </summary>
		public DateTime ModifiedDate { get; set; } = /*getdate()*/ DateTime.Now;

		#endregion Columns

		#region Associations

		/// <summary>
		/// Association <br/>
		/// [FK][Many]Production_TransactionHistory.ProductID --- [PK][One]Production_Product.ProductID <br/>
		/// </summary>
		public virtual Production_Product Production_Product { get; set; }
		#endregion Associations

		partial void OnCreated();
	}
	#endregion Production.TransactionHistory

	#region Production.TransactionHistoryArchive
	public partial class Production_TransactionHistoryArchive : EFCoreEntityBase<Production_TransactionHistoryArchive>
	{
		public Production_TransactionHistoryArchive()
		{
			OnCreated();
		}

		public Production_TransactionHistoryArchive(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "Int NOT NULL", IsPrimaryKey = true
		/// </summary>
		public int TransactionID { get; set; }

		/// <summary>
		/// DbType = "Int NOT NULL"
		/// </summary>
		public int ProductID { get; set; }

		/// <summary>
		/// DbType = "Int NOT NULL"
		/// </summary>
		public int ReferenceOrderID { get; set; }

		/// <summary>
		/// DbType = "Int NOT NULL", DefaultValue = (int)(0)
		/// </summary>
		public int ReferenceOrderLineID { get; set; } = (int)(0);

		/// <summary>
		/// DbType = "DateTime NOT NULL", DefaultValue = /*getdate()*/ DateTime.Now
		/// </summary>
		public DateTime TransactionDate { get; set; } = /*getdate()*/ DateTime.Now;

		/// <summary>
		/// DbType = "NChar(1) NOT NULL"
		/// </summary>
		public string TransactionType { get; set; }

		/// <summary>
		/// DbType = "Int NOT NULL"
		/// </summary>
		public int Quantity { get; set; }

		/// <summary>
		/// DbType = "Money NOT NULL"
		/// </summary>
		public decimal ActualCost { get; set; }

		/// <summary>
		/// DbType = "DateTime NOT NULL", DefaultValue = /*getdate()*/ DateTime.Now
		/// </summary>
		public DateTime ModifiedDate { get; set; } = /*getdate()*/ DateTime.Now;

		#endregion Columns

		#region Associations
		#endregion Associations

		partial void OnCreated();
	}
	#endregion Production.TransactionHistoryArchive

	#region Production.UnitMeasure
	public partial class Production_UnitMeasure : EFCoreEntityBase<Production_UnitMeasure>
	{
		public Production_UnitMeasure()
		{
			OnCreated();
		}

		public Production_UnitMeasure(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "NChar(3) NOT NULL", IsPrimaryKey = true
		/// </summary>
		public string UnitMeasureCode { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50) NOT NULL"
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// DbType = "DateTime NOT NULL", DefaultValue = /*getdate()*/ DateTime.Now
		/// </summary>
		public DateTime ModifiedDate { get; set; } = /*getdate()*/ DateTime.Now;

		#endregion Columns

		#region Associations

		/// <summary>
		/// Association <br/>
		/// [PK][One]Production_UnitMeasure.UnitMeasureCode --- [FK][Many]Production_BillOfMaterials.UnitMeasureCode <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<Production_BillOfMaterials> Production_BillOfMaterialsList { get; set; } = new List<Production_BillOfMaterials>();

		/// <summary>
		/// Association <br/>
		/// [PK][One]Production_UnitMeasure.UnitMeasureCode --- [FK][Many]Production_Product.SizeUnitMeasureCode <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<Production_Product> Production_ProductList { get; set; } = new List<Production_Product>();

		/// <summary>
		/// Association <br/>
		/// [PK][One]Production_UnitMeasure.UnitMeasureCode --- [FK][Many]Production_Product.WeightUnitMeasureCode <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<Production_Product> UnitMeasureCodeProduction_ProductList { get; set; } = new List<Production_Product>();

		/// <summary>
		/// Association <br/>
		/// [PK][One]Production_UnitMeasure.UnitMeasureCode --- [FK][Many]Purchasing_ProductVendor.UnitMeasureCode <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<Purchasing_ProductVendor> Purchasing_ProductVendorList { get; set; } = new List<Purchasing_ProductVendor>();
		#endregion Associations

		partial void OnCreated();
	}
	#endregion Production.UnitMeasure

	#region Person.vAdditionalContactInfo
	public partial class Person_vAdditionalContactInfo : EFCoreEntityBase<Person_vAdditionalContactInfo>
	{
		public Person_vAdditionalContactInfo()
		{
			OnCreated();
		}

		public Person_vAdditionalContactInfo(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "Int NOT NULL IDENTITY"
		/// </summary>
		public int ContactID { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50) NOT NULL"
		/// </summary>
		public string FirstName { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50)"
		/// </summary>
		public string MiddleName { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50) NOT NULL"
		/// </summary>
		public string LastName { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50)"
		/// </summary>
		public string TelephoneNumber { get; set; }

		/// <summary>
		/// DbType = "NVarChar(MAX)"
		/// </summary>
		public string TelephoneSpecialInstructions { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50)"
		/// </summary>
		public string Street { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50)"
		/// </summary>
		public string City { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50)"
		/// </summary>
		public string StateProvince { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50)"
		/// </summary>
		public string PostalCode { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50)"
		/// </summary>
		public string CountryRegion { get; set; }

		/// <summary>
		/// DbType = "NVarChar(MAX)"
		/// </summary>
		public string HomeAddressSpecialInstructions { get; set; }

		/// <summary>
		/// DbType = "NVarChar(128)"
		/// </summary>
		public string EMailAddress { get; set; }

		/// <summary>
		/// DbType = "NVarChar(MAX)"
		/// </summary>
		public string EMailSpecialInstructions { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50)"
		/// </summary>
		public string EMailTelephoneNumber { get; set; }

		/// <summary>
		/// DbType = "UniqueIdentifier NOT NULL"
		/// </summary>
		public System.Guid rowguid { get; set; }

		/// <summary>
		/// DbType = "DateTime NOT NULL"
		/// </summary>
		public DateTime ModifiedDate { get; set; }

		#endregion Columns

		#region Associations
		#endregion Associations

		partial void OnCreated();
	}
	#endregion Person.vAdditionalContactInfo

	#region HumanResources.vEmployee
	public partial class HumanResources_vEmployee : EFCoreEntityBase<HumanResources_vEmployee>
	{
		public HumanResources_vEmployee()
		{
			OnCreated();
		}

		public HumanResources_vEmployee(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "Int NOT NULL"
		/// </summary>
		public int EmployeeID { get; set; }

		/// <summary>
		/// DbType = "NVarChar(8)"
		/// </summary>
		public string Title { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50) NOT NULL"
		/// </summary>
		public string FirstName { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50)"
		/// </summary>
		public string MiddleName { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50) NOT NULL"
		/// </summary>
		public string LastName { get; set; }

		/// <summary>
		/// DbType = "NVarChar(10)"
		/// </summary>
		public string Suffix { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50) NOT NULL"
		/// </summary>
		public string JobTitle { get; set; }

		/// <summary>
		/// DbType = "NVarChar(25)"
		/// </summary>
		public string Phone { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50)"
		/// </summary>
		public string EmailAddress { get; set; }

		/// <summary>
		/// DbType = "Int NOT NULL"
		/// </summary>
		public int EmailPromotion { get; set; }

		/// <summary>
		/// DbType = "NVarChar(60) NOT NULL"
		/// </summary>
		public string AddressLine1 { get; set; }

		/// <summary>
		/// DbType = "NVarChar(60)"
		/// </summary>
		public string AddressLine2 { get; set; }

		/// <summary>
		/// DbType = "NVarChar(30) NOT NULL"
		/// </summary>
		public string City { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50) NOT NULL"
		/// </summary>
		public string StateProvinceName { get; set; }

		/// <summary>
		/// DbType = "NVarChar(15) NOT NULL"
		/// </summary>
		public string PostalCode { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50) NOT NULL"
		/// </summary>
		public string CountryRegionName { get; set; }

		/// <summary>
		/// DbType = "Xml"
		/// </summary>
		public System.Xml.Linq.XElement AdditionalContactInfo { get; set; }

		#endregion Columns

		#region Associations
		#endregion Associations

		partial void OnCreated();
	}
	#endregion HumanResources.vEmployee

	#region HumanResources.vEmployeeDepartment
	public partial class HumanResources_vEmployeeDepartment : EFCoreEntityBase<HumanResources_vEmployeeDepartment>
	{
		public HumanResources_vEmployeeDepartment()
		{
			OnCreated();
		}

		public HumanResources_vEmployeeDepartment(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "Int NOT NULL"
		/// </summary>
		public int EmployeeID { get; set; }

		/// <summary>
		/// DbType = "NVarChar(8)"
		/// </summary>
		public string Title { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50) NOT NULL"
		/// </summary>
		public string FirstName { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50)"
		/// </summary>
		public string MiddleName { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50) NOT NULL"
		/// </summary>
		public string LastName { get; set; }

		/// <summary>
		/// DbType = "NVarChar(10)"
		/// </summary>
		public string Suffix { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50) NOT NULL"
		/// </summary>
		public string JobTitle { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50) NOT NULL"
		/// </summary>
		public string Department { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50) NOT NULL"
		/// </summary>
		public string GroupName { get; set; }

		/// <summary>
		/// DbType = "DateTime NOT NULL"
		/// </summary>
		public DateTime StartDate { get; set; }

		#endregion Columns

		#region Associations
		#endregion Associations

		partial void OnCreated();
	}
	#endregion HumanResources.vEmployeeDepartment

	#region HumanResources.vEmployeeDepartmentHistory
	public partial class HumanResources_vEmployeeDepartmentHistory : EFCoreEntityBase<HumanResources_vEmployeeDepartmentHistory>
	{
		public HumanResources_vEmployeeDepartmentHistory()
		{
			OnCreated();
		}

		public HumanResources_vEmployeeDepartmentHistory(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "Int NOT NULL"
		/// </summary>
		public int EmployeeID { get; set; }

		/// <summary>
		/// DbType = "NVarChar(8)"
		/// </summary>
		public string Title { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50) NOT NULL"
		/// </summary>
		public string FirstName { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50)"
		/// </summary>
		public string MiddleName { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50) NOT NULL"
		/// </summary>
		public string LastName { get; set; }

		/// <summary>
		/// DbType = "NVarChar(10)"
		/// </summary>
		public string Suffix { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50) NOT NULL"
		/// </summary>
		public string Shift { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50) NOT NULL"
		/// </summary>
		public string Department { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50) NOT NULL"
		/// </summary>
		public string GroupName { get; set; }

		/// <summary>
		/// DbType = "DateTime NOT NULL"
		/// </summary>
		public DateTime StartDate { get; set; }

		/// <summary>
		/// DbType = "DateTime"
		/// </summary>
		public DateTime? EndDate { get; set; }

		#endregion Columns

		#region Associations
		#endregion Associations

		partial void OnCreated();
	}
	#endregion HumanResources.vEmployeeDepartmentHistory

	#region Purchasing.Vendor
	public partial class Purchasing_Vendor : EFCoreEntityBase<Purchasing_Vendor>
	{
		public Purchasing_Vendor()
		{
			OnCreated();
		}

		public Purchasing_Vendor(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert
		/// </summary>
		public int VendorID { get; set; }

		/// <summary>
		/// DbType = "NVarChar(15) NOT NULL"
		/// </summary>
		public string AccountNumber { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50) NOT NULL"
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// DbType = "TinyInt NOT NULL"
		/// </summary>
		public byte CreditRating { get; set; }

		/// <summary>
		/// DbType = "Bit NOT NULL", DefaultValue = true
		/// </summary>
		public bool PreferredVendorStatus { get; set; } = true;

		/// <summary>
		/// DbType = "Bit NOT NULL", DefaultValue = true
		/// </summary>
		public bool ActiveFlag { get; set; } = true;

		/// <summary>
		/// DbType = "NVarChar(1024)"
		/// </summary>
		public string PurchasingWebServiceURL { get; set; }

		/// <summary>
		/// DbType = "DateTime NOT NULL", DefaultValue = /*getdate()*/ DateTime.Now
		/// </summary>
		public DateTime ModifiedDate { get; set; } = /*getdate()*/ DateTime.Now;

		#endregion Columns

		#region Associations

		/// <summary>
		/// Association <br/>
		/// [PK][One]Purchasing_Vendor.VendorID --- [FK][Many]Purchasing_ProductVendor.VendorID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<Purchasing_ProductVendor> Purchasing_ProductVendorList { get; set; } = new List<Purchasing_ProductVendor>();

		/// <summary>
		/// Association <br/>
		/// [PK][One]Purchasing_Vendor.VendorID --- [FK][Many]Purchasing_PurchaseOrderHeader.VendorID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<Purchasing_PurchaseOrderHeader> Purchasing_PurchaseOrderHeaderList { get; set; } = new List<Purchasing_PurchaseOrderHeader>();

		/// <summary>
		/// Association <br/>
		/// [PK][One]Purchasing_Vendor.VendorID --- [FK][Many]Purchasing_VendorAddress.VendorID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<Purchasing_VendorAddress> Purchasing_VendorAddressList { get; set; } = new List<Purchasing_VendorAddress>();

		/// <summary>
		/// Association <br/>
		/// [PK][One]Purchasing_Vendor.VendorID --- [FK][Many]Purchasing_VendorContact.VendorID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<Purchasing_VendorContact> Purchasing_VendorContactList { get; set; } = new List<Purchasing_VendorContact>();
		#endregion Associations

		partial void OnCreated();
	}
	#endregion Purchasing.Vendor

	#region Purchasing.VendorAddress
	public partial class Purchasing_VendorAddress : EFCoreEntityBase<Purchasing_VendorAddress>
	{
		public Purchasing_VendorAddress()
		{
			OnCreated();
		}

		public Purchasing_VendorAddress(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "Int NOT NULL", IsPrimaryKey = true
		/// </summary>
		public int VendorID { get; set; }

		/// <summary>
		/// DbType = "Int NOT NULL", IsPrimaryKey = true
		/// </summary>
		public int AddressID { get; set; }

		/// <summary>
		/// DbType = "Int NOT NULL"
		/// </summary>
		public int AddressTypeID { get; set; }

		/// <summary>
		/// DbType = "DateTime NOT NULL", DefaultValue = /*getdate()*/ DateTime.Now
		/// </summary>
		public DateTime ModifiedDate { get; set; } = /*getdate()*/ DateTime.Now;

		#endregion Columns

		#region Associations

		/// <summary>
		/// Association <br/>
		/// [FK][Many]Purchasing_VendorAddress.AddressID --- [PK][One]Person_Address.AddressID <br/>
		/// </summary>
		public virtual Person_Address Person_Address { get; set; }

		/// <summary>
		/// Association <br/>
		/// [FK][Many]Purchasing_VendorAddress.AddressTypeID --- [PK][One]Person_AddressType.AddressTypeID <br/>
		/// </summary>
		public virtual Person_AddressType Person_AddressType { get; set; }

		/// <summary>
		/// Association <br/>
		/// [FK][Many]Purchasing_VendorAddress.VendorID --- [PK][One]Purchasing_Vendor.VendorID <br/>
		/// </summary>
		public virtual Purchasing_Vendor Purchasing_Vendor { get; set; }
		#endregion Associations

		partial void OnCreated();
	}
	#endregion Purchasing.VendorAddress

	#region Purchasing.VendorContact
	public partial class Purchasing_VendorContact : EFCoreEntityBase<Purchasing_VendorContact>
	{
		public Purchasing_VendorContact()
		{
			OnCreated();
		}

		public Purchasing_VendorContact(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "Int NOT NULL", IsPrimaryKey = true
		/// </summary>
		public int VendorID { get; set; }

		/// <summary>
		/// DbType = "Int NOT NULL", IsPrimaryKey = true
		/// </summary>
		public int ContactID { get; set; }

		/// <summary>
		/// DbType = "Int NOT NULL"
		/// </summary>
		public int ContactTypeID { get; set; }

		/// <summary>
		/// DbType = "DateTime NOT NULL", DefaultValue = /*getdate()*/ DateTime.Now
		/// </summary>
		public DateTime ModifiedDate { get; set; } = /*getdate()*/ DateTime.Now;

		#endregion Columns

		#region Associations

		/// <summary>
		/// Association <br/>
		/// [FK][Many]Purchasing_VendorContact.ContactID --- [PK][One]Person_Contact.ContactID <br/>
		/// </summary>
		public virtual Person_Contact Person_Contact { get; set; }

		/// <summary>
		/// Association <br/>
		/// [FK][Many]Purchasing_VendorContact.ContactTypeID --- [PK][One]Person_ContactType.ContactTypeID <br/>
		/// </summary>
		public virtual Person_ContactType Person_ContactType { get; set; }

		/// <summary>
		/// Association <br/>
		/// [FK][Many]Purchasing_VendorContact.VendorID --- [PK][One]Purchasing_Vendor.VendorID <br/>
		/// </summary>
		public virtual Purchasing_Vendor Purchasing_Vendor { get; set; }
		#endregion Associations

		partial void OnCreated();
	}
	#endregion Purchasing.VendorContact

	#region Sales.vIndividualCustomer
	public partial class Sales_vIndividualCustomer : EFCoreEntityBase<Sales_vIndividualCustomer>
	{
		public Sales_vIndividualCustomer()
		{
			OnCreated();
		}

		public Sales_vIndividualCustomer(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "Int NOT NULL"
		/// </summary>
		public int CustomerID { get; set; }

		/// <summary>
		/// DbType = "NVarChar(8)"
		/// </summary>
		public string Title { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50) NOT NULL"
		/// </summary>
		public string FirstName { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50)"
		/// </summary>
		public string MiddleName { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50) NOT NULL"
		/// </summary>
		public string LastName { get; set; }

		/// <summary>
		/// DbType = "NVarChar(10)"
		/// </summary>
		public string Suffix { get; set; }

		/// <summary>
		/// DbType = "NVarChar(25)"
		/// </summary>
		public string Phone { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50)"
		/// </summary>
		public string EmailAddress { get; set; }

		/// <summary>
		/// DbType = "Int NOT NULL"
		/// </summary>
		public int EmailPromotion { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50) NOT NULL"
		/// </summary>
		public string AddressType { get; set; }

		/// <summary>
		/// DbType = "NVarChar(60) NOT NULL"
		/// </summary>
		public string AddressLine1 { get; set; }

		/// <summary>
		/// DbType = "NVarChar(60)"
		/// </summary>
		public string AddressLine2 { get; set; }

		/// <summary>
		/// DbType = "NVarChar(30) NOT NULL"
		/// </summary>
		public string City { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50) NOT NULL"
		/// </summary>
		public string StateProvinceName { get; set; }

		/// <summary>
		/// DbType = "NVarChar(15) NOT NULL"
		/// </summary>
		public string PostalCode { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50) NOT NULL"
		/// </summary>
		public string CountryRegionName { get; set; }

		/// <summary>
		/// DbType = "Xml"
		/// </summary>
		public System.Xml.Linq.XElement Demographics { get; set; }

		#endregion Columns

		#region Associations
		#endregion Associations

		partial void OnCreated();
	}
	#endregion Sales.vIndividualCustomer

	#region Sales.vIndividualDemographics
	public partial class Sales_vIndividualDemographics : EFCoreEntityBase<Sales_vIndividualDemographics>
	{
		public Sales_vIndividualDemographics()
		{
			OnCreated();
		}

		public Sales_vIndividualDemographics(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "Int NOT NULL"
		/// </summary>
		public int CustomerID { get; set; }

		/// <summary>
		/// DbType = "Money"
		/// </summary>
		public decimal? TotalPurchaseYTD { get; set; }

		/// <summary>
		/// DbType = "DateTime"
		/// </summary>
		public DateTime? DateFirstPurchase { get; set; }

		/// <summary>
		/// DbType = "DateTime"
		/// </summary>
		public DateTime? BirthDate { get; set; }

		/// <summary>
		/// DbType = "NVarChar(1)"
		/// </summary>
		public string MaritalStatus { get; set; }

		/// <summary>
		/// DbType = "NVarChar(30)"
		/// </summary>
		public string YearlyIncome { get; set; }

		/// <summary>
		/// DbType = "NVarChar(1)"
		/// </summary>
		public string Gender { get; set; }

		/// <summary>
		/// DbType = "Int"
		/// </summary>
		public int? TotalChildren { get; set; }

		/// <summary>
		/// DbType = "Int"
		/// </summary>
		public int? NumberChildrenAtHome { get; set; }

		/// <summary>
		/// DbType = "NVarChar(30)"
		/// </summary>
		public string Education { get; set; }

		/// <summary>
		/// DbType = "NVarChar(30)"
		/// </summary>
		public string Occupation { get; set; }

		/// <summary>
		/// DbType = "Bit"
		/// </summary>
		public bool? HomeOwnerFlag { get; set; }

		/// <summary>
		/// DbType = "Int"
		/// </summary>
		public int? NumberCarsOwned { get; set; }

		#endregion Columns

		#region Associations
		#endregion Associations

		partial void OnCreated();
	}
	#endregion Sales.vIndividualDemographics

	#region HumanResources.vJobCandidate
	public partial class HumanResources_vJobCandidate : EFCoreEntityBase<HumanResources_vJobCandidate>
	{
		public HumanResources_vJobCandidate()
		{
			OnCreated();
		}

		public HumanResources_vJobCandidate(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "Int NOT NULL IDENTITY"
		/// </summary>
		public int JobCandidateID { get; set; }

		/// <summary>
		/// DbType = "Int"
		/// </summary>
		public int? EmployeeID { get; set; }

		/// <summary>
		/// DbType = "NVarChar(30)"
		/// </summary>
		public string Name_Prefix { get; set; }

		/// <summary>
		/// DbType = "NVarChar(30)"
		/// </summary>
		public string Name_First { get; set; }

		/// <summary>
		/// DbType = "NVarChar(30)"
		/// </summary>
		public string Name_Middle { get; set; }

		/// <summary>
		/// DbType = "NVarChar(30)"
		/// </summary>
		public string Name_Last { get; set; }

		/// <summary>
		/// DbType = "NVarChar(30)"
		/// </summary>
		public string Name_Suffix { get; set; }

		/// <summary>
		/// DbType = "NVarChar(MAX)"
		/// </summary>
		public string Skills { get; set; }

		/// <summary>
		/// DbType = "NVarChar(30)"
		/// </summary>
		public string Addr_Type { get; set; }

		/// <summary>
		/// DbType = "NVarChar(100)"
		/// </summary>
		public string Addr_Loc_CountryRegion { get; set; }

		/// <summary>
		/// DbType = "NVarChar(100)"
		/// </summary>
		public string Addr_Loc_State { get; set; }

		/// <summary>
		/// DbType = "NVarChar(100)"
		/// </summary>
		public string Addr_Loc_City { get; set; }

		/// <summary>
		/// DbType = "NVarChar(20)"
		/// </summary>
		public string Addr_PostalCode { get; set; }

		/// <summary>
		/// DbType = "NVarChar(MAX)"
		/// </summary>
		public string EMail { get; set; }

		/// <summary>
		/// DbType = "NVarChar(MAX)"
		/// </summary>
		public string WebSite { get; set; }

		/// <summary>
		/// DbType = "DateTime NOT NULL"
		/// </summary>
		public DateTime ModifiedDate { get; set; }

		#endregion Columns

		#region Associations
		#endregion Associations

		partial void OnCreated();
	}
	#endregion HumanResources.vJobCandidate

	#region HumanResources.vJobCandidateEducation
	public partial class HumanResources_vJobCandidateEducation : EFCoreEntityBase<HumanResources_vJobCandidateEducation>
	{
		public HumanResources_vJobCandidateEducation()
		{
			OnCreated();
		}

		public HumanResources_vJobCandidateEducation(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "Int NOT NULL IDENTITY"
		/// </summary>
		public int JobCandidateID { get; set; }

		/// <summary>
		/// DbType = "NVarChar(MAX)"
		/// </summary>
		public string Edu_Level { get; set; }

		/// <summary>
		/// DbType = "DateTime"
		/// </summary>
		public DateTime? Edu_StartDate { get; set; }

		/// <summary>
		/// DbType = "DateTime"
		/// </summary>
		public DateTime? Edu_EndDate { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50)"
		/// </summary>
		public string Edu_Degree { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50)"
		/// </summary>
		public string Edu_Major { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50)"
		/// </summary>
		public string Edu_Minor { get; set; }

		/// <summary>
		/// DbType = "NVarChar(5)"
		/// </summary>
		public string Edu_GPA { get; set; }

		/// <summary>
		/// DbType = "NVarChar(5)"
		/// </summary>
		public string Edu_GPAScale { get; set; }

		/// <summary>
		/// DbType = "NVarChar(100)"
		/// </summary>
		public string Edu_School { get; set; }

		/// <summary>
		/// DbType = "NVarChar(100)"
		/// </summary>
		public string Edu_Loc_CountryRegion { get; set; }

		/// <summary>
		/// DbType = "NVarChar(100)"
		/// </summary>
		public string Edu_Loc_State { get; set; }

		/// <summary>
		/// DbType = "NVarChar(100)"
		/// </summary>
		public string Edu_Loc_City { get; set; }

		#endregion Columns

		#region Associations
		#endregion Associations

		partial void OnCreated();
	}
	#endregion HumanResources.vJobCandidateEducation

	#region HumanResources.vJobCandidateEmployment
	public partial class HumanResources_vJobCandidateEmployment : EFCoreEntityBase<HumanResources_vJobCandidateEmployment>
	{
		public HumanResources_vJobCandidateEmployment()
		{
			OnCreated();
		}

		public HumanResources_vJobCandidateEmployment(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "Int NOT NULL IDENTITY"
		/// </summary>
		public int JobCandidateID { get; set; }

		/// <summary>
		/// DbType = "DateTime"
		/// </summary>
		public DateTime? Emp_StartDate { get; set; }

		/// <summary>
		/// DbType = "DateTime"
		/// </summary>
		public DateTime? Emp_EndDate { get; set; }

		/// <summary>
		/// DbType = "NVarChar(100)"
		/// </summary>
		public string Emp_OrgName { get; set; }

		/// <summary>
		/// DbType = "NVarChar(100)"
		/// </summary>
		public string Emp_JobTitle { get; set; }

		/// <summary>
		/// DbType = "NVarChar(MAX)"
		/// </summary>
		public string Emp_Responsibility { get; set; }

		/// <summary>
		/// DbType = "NVarChar(MAX)"
		/// </summary>
		public string Emp_FunctionCategory { get; set; }

		/// <summary>
		/// DbType = "NVarChar(MAX)"
		/// </summary>
		public string Emp_IndustryCategory { get; set; }

		/// <summary>
		/// DbType = "NVarChar(MAX)"
		/// </summary>
		public string Emp_Loc_CountryRegion { get; set; }

		/// <summary>
		/// DbType = "NVarChar(MAX)"
		/// </summary>
		public string Emp_Loc_State { get; set; }

		/// <summary>
		/// DbType = "NVarChar(MAX)"
		/// </summary>
		public string Emp_Loc_City { get; set; }

		#endregion Columns

		#region Associations
		#endregion Associations

		partial void OnCreated();
	}
	#endregion HumanResources.vJobCandidateEmployment

	#region Production.vProductAndDescription
	public partial class Production_vProductAndDescription : EFCoreEntityBase<Production_vProductAndDescription>
	{
		public Production_vProductAndDescription()
		{
			OnCreated();
		}

		public Production_vProductAndDescription(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "Int NOT NULL"
		/// </summary>
		public int ProductID { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50) NOT NULL"
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50) NOT NULL"
		/// </summary>
		public string ProductModel { get; set; }

		/// <summary>
		/// DbType = "NChar(6) NOT NULL"
		/// </summary>
		public string CultureID { get; set; }

		/// <summary>
		/// DbType = "NVarChar(400) NOT NULL"
		/// </summary>
		public string Description { get; set; }

		#endregion Columns

		#region Associations
		#endregion Associations

		partial void OnCreated();
	}
	#endregion Production.vProductAndDescription

	#region Production.vProductModelCatalogDescription
	public partial class Production_vProductModelCatalogDescription : EFCoreEntityBase<Production_vProductModelCatalogDescription>
	{
		public Production_vProductModelCatalogDescription()
		{
			OnCreated();
		}

		public Production_vProductModelCatalogDescription(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "Int NOT NULL IDENTITY"
		/// </summary>
		public int ProductModelID { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50) NOT NULL"
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// DbType = "NVarChar(MAX)"
		/// </summary>
		public string Summary { get; set; }

		/// <summary>
		/// DbType = "NVarChar(MAX)"
		/// </summary>
		public string Manufacturer { get; set; }

		/// <summary>
		/// DbType = "NVarChar(30)"
		/// </summary>
		public string Copyright { get; set; }

		/// <summary>
		/// DbType = "NVarChar(256)"
		/// </summary>
		public string ProductURL { get; set; }

		/// <summary>
		/// DbType = "NVarChar(256)"
		/// </summary>
		public string WarrantyPeriod { get; set; }

		/// <summary>
		/// DbType = "NVarChar(256)"
		/// </summary>
		public string WarrantyDescription { get; set; }

		/// <summary>
		/// DbType = "NVarChar(256)"
		/// </summary>
		public string NoOfYears { get; set; }

		/// <summary>
		/// DbType = "NVarChar(256)"
		/// </summary>
		public string MaintenanceDescription { get; set; }

		/// <summary>
		/// DbType = "NVarChar(256)"
		/// </summary>
		public string Wheel { get; set; }

		/// <summary>
		/// DbType = "NVarChar(256)"
		/// </summary>
		public string Saddle { get; set; }

		/// <summary>
		/// DbType = "NVarChar(256)"
		/// </summary>
		public string Pedal { get; set; }

		/// <summary>
		/// DbType = "NVarChar(MAX)"
		/// </summary>
		public string BikeFrame { get; set; }

		/// <summary>
		/// DbType = "NVarChar(256)"
		/// </summary>
		public string Crankset { get; set; }

		/// <summary>
		/// DbType = "NVarChar(256)"
		/// </summary>
		public string PictureAngle { get; set; }

		/// <summary>
		/// DbType = "NVarChar(256)"
		/// </summary>
		public string PictureSize { get; set; }

		/// <summary>
		/// DbType = "NVarChar(256)"
		/// </summary>
		public string ProductPhotoID { get; set; }

		/// <summary>
		/// DbType = "NVarChar(256)"
		/// </summary>
		public string Material { get; set; }

		/// <summary>
		/// DbType = "NVarChar(256)"
		/// </summary>
		public string Color { get; set; }

		/// <summary>
		/// DbType = "NVarChar(256)"
		/// </summary>
		public string ProductLine { get; set; }

		/// <summary>
		/// DbType = "NVarChar(256)"
		/// </summary>
		public string Style { get; set; }

		/// <summary>
		/// DbType = "NVarChar(1024)"
		/// </summary>
		public string RiderExperience { get; set; }

		/// <summary>
		/// DbType = "UniqueIdentifier NOT NULL"
		/// </summary>
		public System.Guid rowguid { get; set; }

		/// <summary>
		/// DbType = "DateTime NOT NULL"
		/// </summary>
		public DateTime ModifiedDate { get; set; }

		#endregion Columns

		#region Associations
		#endregion Associations

		partial void OnCreated();
	}
	#endregion Production.vProductModelCatalogDescription

	#region Production.vProductModelInstructions
	public partial class Production_vProductModelInstructions : EFCoreEntityBase<Production_vProductModelInstructions>
	{
		public Production_vProductModelInstructions()
		{
			OnCreated();
		}

		public Production_vProductModelInstructions(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "Int NOT NULL IDENTITY"
		/// </summary>
		public int ProductModelID { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50) NOT NULL"
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// DbType = "NVarChar(MAX)"
		/// </summary>
		public string Instructions { get; set; }

		/// <summary>
		/// DbType = "Int"
		/// </summary>
		public int? LocationID { get; set; }

		/// <summary>
		/// DbType = "Decimal(9,4)"
		/// </summary>
		public decimal? SetupHours { get; set; }

		/// <summary>
		/// DbType = "Decimal(9,4)"
		/// </summary>
		public decimal? MachineHours { get; set; }

		/// <summary>
		/// DbType = "Decimal(9,4)"
		/// </summary>
		public decimal? LaborHours { get; set; }

		/// <summary>
		/// DbType = "Int"
		/// </summary>
		public int? LotSize { get; set; }

		/// <summary>
		/// DbType = "NVarChar(1024)"
		/// </summary>
		public string Step { get; set; }

		/// <summary>
		/// DbType = "UniqueIdentifier NOT NULL"
		/// </summary>
		public System.Guid rowguid { get; set; }

		/// <summary>
		/// DbType = "DateTime NOT NULL"
		/// </summary>
		public DateTime ModifiedDate { get; set; }

		#endregion Columns

		#region Associations
		#endregion Associations

		partial void OnCreated();
	}
	#endregion Production.vProductModelInstructions

	#region Sales.vSalesPerson
	public partial class Sales_vSalesPerson : EFCoreEntityBase<Sales_vSalesPerson>
	{
		public Sales_vSalesPerson()
		{
			OnCreated();
		}

		public Sales_vSalesPerson(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "Int NOT NULL"
		/// </summary>
		public int SalesPersonID { get; set; }

		/// <summary>
		/// DbType = "NVarChar(8)"
		/// </summary>
		public string Title { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50) NOT NULL"
		/// </summary>
		public string FirstName { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50)"
		/// </summary>
		public string MiddleName { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50) NOT NULL"
		/// </summary>
		public string LastName { get; set; }

		/// <summary>
		/// DbType = "NVarChar(10)"
		/// </summary>
		public string Suffix { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50) NOT NULL"
		/// </summary>
		public string JobTitle { get; set; }

		/// <summary>
		/// DbType = "NVarChar(25)"
		/// </summary>
		public string Phone { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50)"
		/// </summary>
		public string EmailAddress { get; set; }

		/// <summary>
		/// DbType = "Int NOT NULL"
		/// </summary>
		public int EmailPromotion { get; set; }

		/// <summary>
		/// DbType = "NVarChar(60) NOT NULL"
		/// </summary>
		public string AddressLine1 { get; set; }

		/// <summary>
		/// DbType = "NVarChar(60)"
		/// </summary>
		public string AddressLine2 { get; set; }

		/// <summary>
		/// DbType = "NVarChar(30) NOT NULL"
		/// </summary>
		public string City { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50) NOT NULL"
		/// </summary>
		public string StateProvinceName { get; set; }

		/// <summary>
		/// DbType = "NVarChar(15) NOT NULL"
		/// </summary>
		public string PostalCode { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50) NOT NULL"
		/// </summary>
		public string CountryRegionName { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50)"
		/// </summary>
		public string TerritoryName { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50)"
		/// </summary>
		public string TerritoryGroup { get; set; }

		/// <summary>
		/// DbType = "Money"
		/// </summary>
		public decimal? SalesQuota { get; set; }

		/// <summary>
		/// DbType = "Money NOT NULL"
		/// </summary>
		public decimal SalesYTD { get; set; }

		/// <summary>
		/// DbType = "Money NOT NULL"
		/// </summary>
		public decimal SalesLastYear { get; set; }

		#endregion Columns

		#region Associations
		#endregion Associations

		partial void OnCreated();
	}
	#endregion Sales.vSalesPerson

	#region Sales.vSalesPersonSalesByFiscalYears
	public partial class Sales_vSalesPersonSalesByFiscalYears : EFCoreEntityBase<Sales_vSalesPersonSalesByFiscalYears>
	{
		public Sales_vSalesPersonSalesByFiscalYears()
		{
			OnCreated();
		}

		public Sales_vSalesPersonSalesByFiscalYears(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "Int"
		/// </summary>
		public int? SalesPersonID { get; set; }

		/// <summary>
		/// DbType = "NVarChar(152)"
		/// </summary>
		public string FullName { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50) NOT NULL"
		/// </summary>
		public string Title { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50) NOT NULL"
		/// </summary>
		public string SalesTerritory { get; set; }

		/// <summary>
		/// DbType = "Money"
		/// </summary>
		public decimal? _2002 { get; set; }

		/// <summary>
		/// DbType = "Money"
		/// </summary>
		public decimal? _2003 { get; set; }

		/// <summary>
		/// DbType = "Money"
		/// </summary>
		public decimal? _2004 { get; set; }

		#endregion Columns

		#region Associations
		#endregion Associations

		partial void OnCreated();
	}
	#endregion Sales.vSalesPersonSalesByFiscalYears

	#region Person.vStateProvinceCountryRegion
	public partial class Person_vStateProvinceCountryRegion : EFCoreEntityBase<Person_vStateProvinceCountryRegion>
	{
		public Person_vStateProvinceCountryRegion()
		{
			OnCreated();
		}

		public Person_vStateProvinceCountryRegion(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "Int NOT NULL"
		/// </summary>
		public int StateProvinceID { get; set; }

		/// <summary>
		/// DbType = "NChar(3) NOT NULL"
		/// </summary>
		public string StateProvinceCode { get; set; }

		/// <summary>
		/// DbType = "Bit NOT NULL"
		/// </summary>
		public bool IsOnlyStateProvinceFlag { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50) NOT NULL"
		/// </summary>
		public string StateProvinceName { get; set; }

		/// <summary>
		/// DbType = "Int NOT NULL"
		/// </summary>
		public int TerritoryID { get; set; }

		/// <summary>
		/// DbType = "NVarChar(3) NOT NULL"
		/// </summary>
		public string CountryRegionCode { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50) NOT NULL"
		/// </summary>
		public string CountryRegionName { get; set; }

		#endregion Columns

		#region Associations
		#endregion Associations

		partial void OnCreated();
	}
	#endregion Person.vStateProvinceCountryRegion

	#region Sales.vStoreWithDemographics
	public partial class Sales_vStoreWithDemographics : EFCoreEntityBase<Sales_vStoreWithDemographics>
	{
		public Sales_vStoreWithDemographics()
		{
			OnCreated();
		}

		public Sales_vStoreWithDemographics(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "Int NOT NULL"
		/// </summary>
		public int CustomerID { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50) NOT NULL"
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50) NOT NULL"
		/// </summary>
		public string ContactType { get; set; }

		/// <summary>
		/// DbType = "NVarChar(8)"
		/// </summary>
		public string Title { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50) NOT NULL"
		/// </summary>
		public string FirstName { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50)"
		/// </summary>
		public string MiddleName { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50) NOT NULL"
		/// </summary>
		public string LastName { get; set; }

		/// <summary>
		/// DbType = "NVarChar(10)"
		/// </summary>
		public string Suffix { get; set; }

		/// <summary>
		/// DbType = "NVarChar(25)"
		/// </summary>
		public string Phone { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50)"
		/// </summary>
		public string EmailAddress { get; set; }

		/// <summary>
		/// DbType = "Int NOT NULL"
		/// </summary>
		public int EmailPromotion { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50) NOT NULL"
		/// </summary>
		public string AddressType { get; set; }

		/// <summary>
		/// DbType = "NVarChar(60) NOT NULL"
		/// </summary>
		public string AddressLine1 { get; set; }

		/// <summary>
		/// DbType = "NVarChar(60)"
		/// </summary>
		public string AddressLine2 { get; set; }

		/// <summary>
		/// DbType = "NVarChar(30) NOT NULL"
		/// </summary>
		public string City { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50) NOT NULL"
		/// </summary>
		public string StateProvinceName { get; set; }

		/// <summary>
		/// DbType = "NVarChar(15) NOT NULL"
		/// </summary>
		public string PostalCode { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50) NOT NULL"
		/// </summary>
		public string CountryRegionName { get; set; }

		/// <summary>
		/// DbType = "Money"
		/// </summary>
		public decimal? AnnualSales { get; set; }

		/// <summary>
		/// DbType = "Money"
		/// </summary>
		public decimal? AnnualRevenue { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50)"
		/// </summary>
		public string BankName { get; set; }

		/// <summary>
		/// DbType = "NVarChar(5)"
		/// </summary>
		public string BusinessType { get; set; }

		/// <summary>
		/// DbType = "Int"
		/// </summary>
		public int? YearOpened { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50)"
		/// </summary>
		public string Specialty { get; set; }

		/// <summary>
		/// DbType = "Int"
		/// </summary>
		public int? SquareFeet { get; set; }

		/// <summary>
		/// DbType = "NVarChar(30)"
		/// </summary>
		public string Brands { get; set; }

		/// <summary>
		/// DbType = "NVarChar(30)"
		/// </summary>
		public string Internet { get; set; }

		/// <summary>
		/// DbType = "Int"
		/// </summary>
		public int? NumberEmployees { get; set; }

		#endregion Columns

		#region Associations
		#endregion Associations

		partial void OnCreated();
	}
	#endregion Sales.vStoreWithDemographics

	#region Purchasing.vVendor
	public partial class Purchasing_vVendor : EFCoreEntityBase<Purchasing_vVendor>
	{
		public Purchasing_vVendor()
		{
			OnCreated();
		}

		public Purchasing_vVendor(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "Int NOT NULL"
		/// </summary>
		public int VendorID { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50) NOT NULL"
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50) NOT NULL"
		/// </summary>
		public string ContactType { get; set; }

		/// <summary>
		/// DbType = "NVarChar(8)"
		/// </summary>
		public string Title { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50) NOT NULL"
		/// </summary>
		public string FirstName { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50)"
		/// </summary>
		public string MiddleName { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50) NOT NULL"
		/// </summary>
		public string LastName { get; set; }

		/// <summary>
		/// DbType = "NVarChar(10)"
		/// </summary>
		public string Suffix { get; set; }

		/// <summary>
		/// DbType = "NVarChar(25)"
		/// </summary>
		public string Phone { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50)"
		/// </summary>
		public string EmailAddress { get; set; }

		/// <summary>
		/// DbType = "Int NOT NULL"
		/// </summary>
		public int EmailPromotion { get; set; }

		/// <summary>
		/// DbType = "NVarChar(60) NOT NULL"
		/// </summary>
		public string AddressLine1 { get; set; }

		/// <summary>
		/// DbType = "NVarChar(60)"
		/// </summary>
		public string AddressLine2 { get; set; }

		/// <summary>
		/// DbType = "NVarChar(30) NOT NULL"
		/// </summary>
		public string City { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50) NOT NULL"
		/// </summary>
		public string StateProvinceName { get; set; }

		/// <summary>
		/// DbType = "NVarChar(15) NOT NULL"
		/// </summary>
		public string PostalCode { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50) NOT NULL"
		/// </summary>
		public string CountryRegionName { get; set; }

		#endregion Columns

		#region Associations
		#endregion Associations

		partial void OnCreated();
	}
	#endregion Purchasing.vVendor

	#region Production.WorkOrder
	public partial class Production_WorkOrder : EFCoreEntityBase<Production_WorkOrder>
	{
		public Production_WorkOrder()
		{
			OnCreated();
		}

		public Production_WorkOrder(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert
		/// </summary>
		public int WorkOrderID { get; set; }

		/// <summary>
		/// DbType = "Int NOT NULL"
		/// </summary>
		public int ProductID { get; set; }

		/// <summary>
		/// DbType = "Int NOT NULL"
		/// </summary>
		public int OrderQty { get; set; }

		/// <summary>
		/// DbType = "Int NOT NULL"
		/// </summary>
		public int StockedQty { get; set; }

		/// <summary>
		/// DbType = "SmallInt NOT NULL"
		/// </summary>
		public System.Int16 ScrappedQty { get; set; }

		/// <summary>
		/// DbType = "DateTime NOT NULL"
		/// </summary>
		public DateTime StartDate { get; set; }

		/// <summary>
		/// DbType = "DateTime"
		/// </summary>
		public DateTime? EndDate { get; set; }

		/// <summary>
		/// DbType = "DateTime NOT NULL"
		/// </summary>
		public DateTime DueDate { get; set; }

		/// <summary>
		/// DbType = "SmallInt"
		/// </summary>
		public System.Int16? ScrapReasonID { get; set; }

		/// <summary>
		/// DbType = "DateTime NOT NULL", DefaultValue = /*getdate()*/ DateTime.Now
		/// </summary>
		public DateTime ModifiedDate { get; set; } = /*getdate()*/ DateTime.Now;

		#endregion Columns

		#region Associations

		/// <summary>
		/// Association <br/>
		/// [FK][Many]Production_WorkOrder.ProductID --- [PK][One]Production_Product.ProductID <br/>
		/// </summary>
		public virtual Production_Product Production_Product { get; set; }

		/// <summary>
		/// Association <br/>
		/// [FK][Many]Production_WorkOrder.ScrapReasonID --- [PK][One]Production_ScrapReason.ScrapReasonID <br/>
		/// </summary>
		public virtual Production_ScrapReason Production_ScrapReason { get; set; }

		/// <summary>
		/// Association <br/>
		/// [PK][One]Production_WorkOrder.WorkOrderID --- [FK][Many]Production_WorkOrderRouting.WorkOrderID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<Production_WorkOrderRouting> Production_WorkOrderRoutingList { get; set; } = new List<Production_WorkOrderRouting>();
		#endregion Associations

		partial void OnCreated();
	}
	#endregion Production.WorkOrder

	#region Production.WorkOrderRouting
	public partial class Production_WorkOrderRouting : EFCoreEntityBase<Production_WorkOrderRouting>
	{
		public Production_WorkOrderRouting()
		{
			OnCreated();
		}

		public Production_WorkOrderRouting(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "Int NOT NULL", IsPrimaryKey = true
		/// </summary>
		public int WorkOrderID { get; set; }

		/// <summary>
		/// DbType = "Int NOT NULL", IsPrimaryKey = true
		/// </summary>
		public int ProductID { get; set; }

		/// <summary>
		/// DbType = "SmallInt NOT NULL", IsPrimaryKey = true
		/// </summary>
		public System.Int16 OperationSequence { get; set; }

		/// <summary>
		/// DbType = "SmallInt NOT NULL"
		/// </summary>
		public System.Int16 LocationID { get; set; }

		/// <summary>
		/// DbType = "DateTime NOT NULL"
		/// </summary>
		public DateTime ScheduledStartDate { get; set; }

		/// <summary>
		/// DbType = "DateTime NOT NULL"
		/// </summary>
		public DateTime ScheduledEndDate { get; set; }

		/// <summary>
		/// DbType = "DateTime"
		/// </summary>
		public DateTime? ActualStartDate { get; set; }

		/// <summary>
		/// DbType = "DateTime"
		/// </summary>
		public DateTime? ActualEndDate { get; set; }

		/// <summary>
		/// DbType = "Decimal(9,4)"
		/// </summary>
		public decimal? ActualResourceHrs { get; set; }

		/// <summary>
		/// DbType = "Money NOT NULL"
		/// </summary>
		public decimal PlannedCost { get; set; }

		/// <summary>
		/// DbType = "Money"
		/// </summary>
		public decimal? ActualCost { get; set; }

		/// <summary>
		/// DbType = "DateTime NOT NULL", DefaultValue = /*getdate()*/ DateTime.Now
		/// </summary>
		public DateTime ModifiedDate { get; set; } = /*getdate()*/ DateTime.Now;

		#endregion Columns

		#region Associations

		/// <summary>
		/// Association <br/>
		/// [FK][Many]Production_WorkOrderRouting.LocationID --- [PK][One]Production_Location.LocationID <br/>
		/// </summary>
		public virtual Production_Location Production_Location { get; set; }

		/// <summary>
		/// Association <br/>
		/// [FK][Many]Production_WorkOrderRouting.WorkOrderID --- [PK][One]Production_WorkOrder.WorkOrderID <br/>
		/// </summary>
		public virtual Production_WorkOrder Production_WorkOrder { get; set; }
		#endregion Associations

		partial void OnCreated();
	}
	#endregion Production.WorkOrderRouting


	#endregion

	#region Functions Return types

	#region ufnGetContactInformationResult
	public partial class ufnGetContactInformationResult
	{
		public ufnGetContactInformationResult(){ }

		/// <summary>
		/// DbType = "Int NOT NULL"
		/// </summary>
		public int ContactID { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50)"
		/// </summary>
		public string FirstName { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50)"
		/// </summary>
		public string LastName { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50)"
		/// </summary>
		public string JobTitle { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50)"
		/// </summary>
		public string ContactType { get; set; }

	}
	#endregion ufnGetContactInformationResult

	#region uspGetBillOfMaterialsMultipleResults
	public partial class uspGetBillOfMaterialsMultipleResults
	{
		public uspGetBillOfMaterialsMultipleResults(){ }

		public List<uspGetBillOfMaterialsResult> Result1 { get; set; }

		public int ReturnValue { get; set; }

	}
	#endregion uspGetBillOfMaterialsMultipleResults

	#region uspGetEmployeeManagersMultipleResults
	public partial class uspGetEmployeeManagersMultipleResults
	{
		public uspGetEmployeeManagersMultipleResults(){ }

		public List<uspGetEmployeeManagersResult> Result1 { get; set; }

		public int ReturnValue { get; set; }

	}
	#endregion uspGetEmployeeManagersMultipleResults

	#region uspGetManagerEmployeesMultipleResults
	public partial class uspGetManagerEmployeesMultipleResults
	{
		public uspGetManagerEmployeesMultipleResults(){ }

		public List<uspGetManagerEmployeesResult> Result1 { get; set; }

		public int ReturnValue { get; set; }

	}
	#endregion uspGetManagerEmployeesMultipleResults

	#region uspGetWhereUsedProductIDMultipleResults
	public partial class uspGetWhereUsedProductIDMultipleResults
	{
		public uspGetWhereUsedProductIDMultipleResults(){ }

		public List<uspGetWhereUsedProductIDResult> Result1 { get; set; }

		public int ReturnValue { get; set; }

	}
	#endregion uspGetWhereUsedProductIDMultipleResults

	#region uspLogErrorMultipleResults
	public partial class uspLogErrorMultipleResults
	{
		public uspLogErrorMultipleResults(){ }

		public int ReturnValue { get; set; }

	}
	#endregion uspLogErrorMultipleResults

	#region uspPrintErrorMultipleResults
	public partial class uspPrintErrorMultipleResults
	{
		public uspPrintErrorMultipleResults(){ }

		public int ReturnValue { get; set; }

	}
	#endregion uspPrintErrorMultipleResults

	#region HumanResources_uspUpdateEmployeeHireInfoMultipleResults
	public partial class HumanResources_uspUpdateEmployeeHireInfoMultipleResults
	{
		public HumanResources_uspUpdateEmployeeHireInfoMultipleResults(){ }

		public int ReturnValue { get; set; }

	}
	#endregion HumanResources_uspUpdateEmployeeHireInfoMultipleResults

	#region HumanResources_uspUpdateEmployeeLoginMultipleResults
	public partial class HumanResources_uspUpdateEmployeeLoginMultipleResults
	{
		public HumanResources_uspUpdateEmployeeLoginMultipleResults(){ }

		public int ReturnValue { get; set; }

	}
	#endregion HumanResources_uspUpdateEmployeeLoginMultipleResults

	#region HumanResources_uspUpdateEmployeePersonalInfoMultipleResults
	public partial class HumanResources_uspUpdateEmployeePersonalInfoMultipleResults
	{
		public HumanResources_uspUpdateEmployeePersonalInfoMultipleResults(){ }

		public int ReturnValue { get; set; }

	}
	#endregion HumanResources_uspUpdateEmployeePersonalInfoMultipleResults

	#region uspGetBillOfMaterialsResult
	public partial class uspGetBillOfMaterialsResult
	{
		public uspGetBillOfMaterialsResult(){ }

		/// <summary>
		/// DbType = "Int"
		/// </summary>
		public int? ProductAssemblyID { get; set; }

		/// <summary>
		/// DbType = "Int"
		/// </summary>
		public int? ComponentID { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50)"
		/// </summary>
		public string ComponentDesc { get; set; }

		/// <summary>
		/// DbType = "Decimal(38,2)"
		/// </summary>
		public decimal? TotalQuantity { get; set; }

		/// <summary>
		/// DbType = "Money"
		/// </summary>
		public decimal? StandardCost { get; set; }

		/// <summary>
		/// DbType = "Money"
		/// </summary>
		public decimal? ListPrice { get; set; }

		/// <summary>
		/// DbType = "SmallInt"
		/// </summary>
		public System.Int16? BOMLevel { get; set; }

		/// <summary>
		/// DbType = "Int"
		/// </summary>
		public int? RecursionLevel { get; set; }

	}
	#endregion uspGetBillOfMaterialsResult

	#region uspGetEmployeeManagersResult
	public partial class uspGetEmployeeManagersResult
	{
		public uspGetEmployeeManagersResult(){ }

		/// <summary>
		/// DbType = "Int"
		/// </summary>
		public int? RecursionLevel { get; set; }

		/// <summary>
		/// DbType = "Int"
		/// </summary>
		public int? EmployeeID { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50)"
		/// </summary>
		public string FirstName { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50)"
		/// </summary>
		public string LastName { get; set; }

		/// <summary>
		/// DbType = "Int"
		/// </summary>
		public int? ManagerID { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50) NOT NULL"
		/// </summary>
		public string ManagerFirstName { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50) NOT NULL"
		/// </summary>
		public string ManagerLastName { get; set; }

	}
	#endregion uspGetEmployeeManagersResult

	#region uspGetManagerEmployeesResult
	public partial class uspGetManagerEmployeesResult
	{
		public uspGetManagerEmployeesResult(){ }

		/// <summary>
		/// DbType = "Int"
		/// </summary>
		public int? RecursionLevel { get; set; }

		/// <summary>
		/// DbType = "Int"
		/// </summary>
		public int? ManagerID { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50) NOT NULL"
		/// </summary>
		public string ManagerFirstName { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50) NOT NULL"
		/// </summary>
		public string ManagerLastName { get; set; }

		/// <summary>
		/// DbType = "Int"
		/// </summary>
		public int? EmployeeID { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50)"
		/// </summary>
		public string FirstName { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50)"
		/// </summary>
		public string LastName { get; set; }

	}
	#endregion uspGetManagerEmployeesResult

	#region uspGetWhereUsedProductIDResult
	public partial class uspGetWhereUsedProductIDResult
	{
		public uspGetWhereUsedProductIDResult(){ }

		/// <summary>
		/// DbType = "Int"
		/// </summary>
		public int? ProductAssemblyID { get; set; }

		/// <summary>
		/// DbType = "Int"
		/// </summary>
		public int? ComponentID { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50)"
		/// </summary>
		public string ComponentDesc { get; set; }

		/// <summary>
		/// DbType = "Decimal(38,2)"
		/// </summary>
		public decimal? TotalQuantity { get; set; }

		/// <summary>
		/// DbType = "Money"
		/// </summary>
		public decimal? StandardCost { get; set; }

		/// <summary>
		/// DbType = "Money"
		/// </summary>
		public decimal? ListPrice { get; set; }

		/// <summary>
		/// DbType = "SmallInt"
		/// </summary>
		public System.Int16? BOMLevel { get; set; }

		/// <summary>
		/// DbType = "Int"
		/// </summary>
		public int? RecursionLevel { get; set; }

	}
	#endregion uspGetWhereUsedProductIDResult

	#endregion

}
