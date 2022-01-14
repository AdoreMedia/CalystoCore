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

namespace Calysto.SqlMetal.Win.Database
{
	/// <summary>
	/// CalystoEFCoreFluent for MSSQL
	/// </summary>
	public partial class dbCalystoUnittestDataContext : DbContext
	{
		#region Context constructors
		
		public dbCalystoUnittestDataContext(bool useLazyLoadingProxies)
			: base(new DbContextOptionsBuilder<dbCalystoUnittestDataContext>()
				.UsingThis(builder => { if (useLazyLoadingProxies) builder.UseLazyLoadingProxies(); })
				.Options)
		{
			OnCreated();
		}
		
		public dbCalystoUnittestDataContext(Action<DbContextOptionsBuilder<dbCalystoUnittestDataContext>> configure)
			: base(new DbContextOptionsBuilder<dbCalystoUnittestDataContext>()
				.UsingThis(builder => configure(builder))
				.Options)
		{
			OnCreated();
		}

		public dbCalystoUnittestDataContext(DbContextOptions<dbCalystoUnittestDataContext> options) : base(options)
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
				optionsBuilder.UseSqlServer(@"Data Source=.\MSSQL2019;Initial Catalog=dbCalystoUnittest;Integrated Security=True;Connect Timeout=30;");
			}
			CustomizeConfiguration(ref optionsBuilder);
			base.OnConfiguring(optionsBuilder);
		}

		partial void CustomizeConfiguration(ref DbContextOptionsBuilder optionsBuilder);

		#endregion OnConfiguring

		#region Context properties for tables

		public virtual DbSet<tblAppMember> tblAppMember { get; set; }
		public virtual DbSet<tblAppMember2> tblAppMember2 { get; set; }
		public virtual DbSet<guest_tblAppMember2> guest_tblAppMember2 { get; set; }
		public virtual DbSet<tblAppMemberPermission> tblAppMemberPermission { get; set; }
		public virtual DbSet<tblAppMemberPicture> tblAppMemberPicture { get; set; }
		public virtual DbSet<tblAppMemberPicture2> tblAppMemberPicture2 { get; set; }
		public virtual DbSet<tblAppMemberStatus> tblAppMemberStatus { get; set; }
		public virtual DbSet<tblVehicle> tblVehicle { get; set; }

		#endregion Context properties for tables

		#region Context database functions

		/// <param name="amount">Float, DefaultValue = (double)(0)</param>
		/// <param name="amount2">Float, DefaultValue = (double)(-0.05)</param>
		/// <param name="fromCurrency">VarChar(10), DefaultValue = "EUR"</param>
		/// <param name="toCurrency">VarChar(10), DefaultValue = "HRK"</param>
		/// <param name="exchangeRateDate">DateTime, DefaultValue = null</param>
		/// <returns>Scalar value from function</returns>
		public double? fnConvertCurrency(
			double? amount = (double)(0), 
			double? amount2 = (double)(-0.05), 
			string fromCurrency = "EUR", 
			string toCurrency = "HRK", 
			DateTime? exchangeRateDate = null)
		{
			return this.ExecuteList<double?>($@"select dbo.fnConvertCurrency({{0}}, {{1}}, {{2}}, {{3}}, {{4}})", amount, amount2, fromCurrency, toCurrency, exchangeRateDate).First();
		}

		/// <param name="skip111">Int</param>
		/// <param name="take111">Int, DefaultValue = (int)(50)</param>
		/// <param name="validOnDate">DateTime, DefaultValue = null</param>
		/// <param name="valuta">VarChar(50), DefaultValue = null</param>
		/// <returns>Scalar value from function</returns>
		public ValutaTecaj fnGetBankaValutaTecaj(
			int? skip111, 
			int? take111 = (int)(50), 
			DateTime? validOnDate = null, 
			string valuta = null)
		{
			return this.ExecuteList<ValutaTecaj>($@"select dbo.fnGetBankaValutaTecaj({{0}}, {{1}}, {{2}}, {{3}})", skip111, take111, validOnDate, valuta).First();
		}

		/// <param name="num1">Float</param>
		/// <param name="num2">Float</param>
		/// <returns>Scalar value from function</returns>
		public double? fnSumNumbers(
			double? num1, 
			double? num2)
		{
			return this.ExecuteList<double?>($@"select dbo.fnSumNumbers({{0}}, {{1}})", num1, num2).First();
		}

		/// <param name="skip">Int, DefaultValue = (int)(0)</param>
		/// <param name="take">Int, DefaultValue = (int)(100)</param>
		/// <param name="res">Int</param>
		/// <returns>MultipleResults from stored procedure</returns>
		public spMultiResultsMultipleResults spMultiResults(
			int? skip, 
			int? take, 
			ref int? res)
		{
			var multiple_results_1 = this.ExecuteMultipleResults($@"declare @return_value int; 
					exec @return_value = dbo.spMultiResults {{0}}, {{1}}, {{2}} out; 
					select @return_value as ReturnValue;", skip, take, res);
			var final_result_1 = multiple_results_1.ReadResults(res => new spMultiResultsMultipleResults()
			{
				Result1 = res.GetSequence<spMultiResultsResult1>().ToList(),
				Result2 = res.GetSequence<spMultiResultsResult2>().ToList(),
				Result3 = res.GetSequence<spMultiResultsResult3>().ToList(),
				Result4 = res.GetSequence<spMultiResultsResult4>().ToList(),
				ReturnValue = res.GetSequence<int>().Single(),
			});
			// read Output parameter from stored procedure
			res = Calysto.Utility.CalystoTypeConverter.ChangeType<int?>(multiple_results_1.Command.Parameters[2].Value);
			return final_result_1;
		}

		/// <returns>MultipleResults from stored procedure</returns>
		public spMultiResults2MultipleResults spMultiResults2()
		{
			var multiple_results_1 = this.ExecuteMultipleResults($@"declare @return_value int; 
					exec @return_value = dbo.spMultiResults2; 
					select @return_value as ReturnValue;");
			var final_result_1 = multiple_results_1.ReadResults(res => new spMultiResults2MultipleResults()
			{
				Clients = res.GetSequence<int>().ToList(),
				Owners = res.GetSequence<double?>().ToList(),
				Vehicles = res.GetSequence<tblVehicle>().ToList(),
				Result4 = res.GetSequence<spMultiResults2Result>().ToList(),
				ReturnValue = res.GetSequence<int>().Single(),
			});
			return final_result_1;
		}

		/// <returns>MultipleResults from stored procedure</returns>
		public spRandomNumberMultipleResults spRandomNumber()
		{
			var multiple_results_1 = this.ExecuteMultipleResults($@"declare @return_value int; 
					exec @return_value = dbo.spRandomNumber; 
					select @return_value as ReturnValue;");
			var final_result_1 = multiple_results_1.ReadResults(res => new spRandomNumberMultipleResults()
			{
				Random = res.GetSequence<double>().Single(),
				ReturnValue = res.GetSequence<int>().Single(),
			});
			return final_result_1;
		}

		/// <param name="str">NVarChar(MAX)</param>
		/// <param name="expectedLength">Int</param>
		/// <param name="addPrefix">Bit</param>
		/// <returns>Scalar value from function</returns>
		public string guest_fnAddPaddingSpace(
			string str, 
			int? expectedLength, 
			bool? addPrefix)
		{
			return this.ExecuteList<string>($@"select guest.fnAddPaddingSpace({{0}}, {{1}}, {{2}})", str, expectedLength, addPrefix).First();
		}

		/// <returns>Sequence from function</returns>
		public List<guest_fnGetStariNoviGranicaResult> guest_fnGetStariNoviGranica()
		{
			return this.ExecuteList<guest_fnGetStariNoviGranicaResult>($@"select * from guest.fnGetStariNoviGranica()").ToList();
		}

		/// <param name="skip">Int, DefaultValue = (int)(0)</param>
		/// <param name="take">Int, DefaultValue = (int)(100)</param>
		/// <param name="totalCount">Int, DefaultValue = null</param>
		/// <returns>MultipleResults from stored procedure</returns>
		public guest_spGetAppMembersMultipleResults guest_spGetAppMembers(
			int? skip, 
			int? take, 
			ref int? totalCount)
		{
			var multiple_results_1 = this.ExecuteMultipleResults($@"declare @return_value int; 
					exec @return_value = guest.spGetAppMembers {{0}}, {{1}}, {{2}} out; 
					select @return_value as ReturnValue;", skip, take, totalCount);
			var final_result_1 = multiple_results_1.ReadResults(res => new guest_spGetAppMembersMultipleResults()
			{
				Result1 = res.GetSequence<guest_spGetAppMembersResult1>().ToList(),
				Result2 = res.GetSequence<guest_spGetAppMembersResult2>().ToList(),
				ReturnValue = res.GetSequence<int>().Single(),
			});
			// read Output parameter from stored procedure
			totalCount = Calysto.Utility.CalystoTypeConverter.ChangeType<int?>(multiple_results_1.Command.Parameters[2].Value);
			return final_result_1;
		}


		#endregion Context database functions

		#region OnModelCreating

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			this.Map_tblAppMember(modelBuilder);
			this.Customize_tblAppMember(modelBuilder);

			this.Map_tblAppMember2(modelBuilder);
			this.Customize_tblAppMember2(modelBuilder);

			this.Map_guest_tblAppMember2(modelBuilder);
			this.Customize_guest_tblAppMember2(modelBuilder);

			this.Map_tblAppMemberPermission(modelBuilder);
			this.Customize_tblAppMemberPermission(modelBuilder);

			this.Map_tblAppMemberPicture(modelBuilder);
			this.Customize_tblAppMemberPicture(modelBuilder);

			this.Map_tblAppMemberPicture2(modelBuilder);
			this.Customize_tblAppMemberPicture2(modelBuilder);

			this.Map_tblAppMemberStatus(modelBuilder);
			this.Customize_tblAppMemberStatus(modelBuilder);

			this.Map_tblVehicle(modelBuilder);
			this.Customize_tblVehicle(modelBuilder);

			RelationshipsMapping(modelBuilder);
			CustomizeMapping(ref modelBuilder);
		}

		#endregion

		#region TablesMappingDetails

		#region tblAppMember
		private void Map_tblAppMember(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<tblAppMember>().ToTable("tblAppMember", "dbo");
			modelBuilder.Entity<tblAppMember>().HasKey(x=>x.AppMemberID);
			modelBuilder.Entity<tblAppMember>().Property(x=>x.AppMemberID).HasColumnName("AppMemberID").HasColumnType("Int").IsRequired().ValueGeneratedOnAdd();
			modelBuilder.Entity<tblAppMember>().Property(x=>x.AppMemberStatusID).HasColumnName("AppMemberStatusID").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblAppMember>().Property(x=>x.MSISDN).HasColumnName("MSISDN").HasColumnType("VarChar(15)").ValueGeneratedNever().HasMaxLength(15);
			modelBuilder.Entity<tblAppMember>().Property(x=>x.FacebookId).HasColumnName("FacebookId").HasColumnType("VarChar(50)").ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<tblAppMember>().Property(x=>x.GoogleId).HasColumnName("GoogleId").HasColumnType("VarChar(50)").ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<tblAppMember>().Property(x=>x.Email).HasColumnName("Email").HasColumnType("VarChar(150)").ValueGeneratedNever().HasMaxLength(150);
			modelBuilder.Entity<tblAppMember>().Property(x=>x.Username).HasColumnName("Username").HasColumnType("NVarChar(50)").ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<tblAppMember>().Property(x=>x.Password).HasColumnName("Password").HasColumnType("NVarChar(50)").ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<tblAppMember>().Property(x=>x.BirthDate).HasColumnName("BirthDate").HasColumnType("DateTime").ValueGeneratedNever();
			modelBuilder.Entity<tblAppMember>().Property(x=>x.CreationDate).HasColumnName("CreationDate").HasColumnType("DateTime").ValueGeneratedNever();
			modelBuilder.Entity<tblAppMember>().Property(x=>x.LastLoginDate).HasColumnName("LastLoginDate").HasColumnType("DateTime").ValueGeneratedNever();
			modelBuilder.Entity<tblAppMember>().Property(x=>x.LoginsCount).HasColumnName("LoginsCount").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblAppMember>().Property(x=>x.FirstName).HasColumnName("FirstName").HasColumnType("NVarChar(100)").ValueGeneratedNever().HasMaxLength(100);
			modelBuilder.Entity<tblAppMember>().Property(x=>x.LastName).HasColumnName("LastName").HasColumnType("NVarChar(100)").ValueGeneratedNever().HasMaxLength(100);
			modelBuilder.Entity<tblAppMember>().Property(x=>x.Gender).HasColumnName("Gender").HasColumnType("VarChar(10)").ValueGeneratedNever().HasMaxLength(10);
			modelBuilder.Entity<tblAppMember>().Property(x=>x.PersonalNote).HasColumnName("PersonalNote").HasColumnType("NVarChar(1000)").ValueGeneratedNever().HasMaxLength(1000);
			modelBuilder.Entity<tblAppMember>().Property(x=>x.WebUrl).HasColumnName("WebUrl").HasColumnType("VarChar(255)").ValueGeneratedNever().HasMaxLength(255);
			modelBuilder.Entity<tblAppMember>().Property(x=>x.Address).HasColumnName("Address").HasColumnType("NVarChar(255)").ValueGeneratedNever().HasMaxLength(255);
			modelBuilder.Entity<tblAppMember>().Property(x=>x.ZipCode).HasColumnName("ZipCode").HasColumnType("NVarChar(50)").ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<tblAppMember>().Property(x=>x.City).HasColumnName("City").HasColumnType("NVarChar(250)").ValueGeneratedNever().HasMaxLength(250);
			modelBuilder.Entity<tblAppMember>().Property(x=>x.Country).HasColumnName("Country").HasColumnType("NVarChar(250)").ValueGeneratedNever().HasMaxLength(250);
			modelBuilder.Entity<tblAppMember>().Property(x=>x.IP).HasColumnName("IP").HasColumnType("VarChar(50)").ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<tblAppMember>().Property(x=>x.PosFirmaID).HasColumnName("PosFirmaID").HasColumnType("Int").ValueGeneratedNever();
			modelBuilder.Entity<tblAppMember>().Property(x=>x.IsQuizQuestionsEditor).HasColumnName("IsQuizQuestionsEditor").HasColumnType("Bit").ValueGeneratedNever();
			modelBuilder.Entity<tblAppMember>().Property(x=>x.StanjeRacuna).HasColumnName("StanjeRacuna").HasColumnType("Money").ValueGeneratedNever();
			modelBuilder.Entity<tblAppMember>().Property(x=>x.HomeMemberAddressID).HasColumnName("HomeMemberAddressID").HasColumnType("Int").ValueGeneratedNever();
			modelBuilder.Entity<tblAppMember>().Property(x=>x.WorkMemberAddressID).HasColumnName("WorkMemberAddressID").HasColumnType("Int").ValueGeneratedNever();
			modelBuilder.Entity<tblAppMember>().Property(x=>x.PrimaryMemberAddressID).HasColumnName("PrimaryMemberAddressID").HasColumnType("Int").ValueGeneratedNever();
		}

		partial void Customize_tblAppMember(ModelBuilder modelBuilder);
		#endregion

		#region tblAppMember2
		private void Map_tblAppMember2(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<tblAppMember2>().ToTable("tblAppMember2", "dbo");
			modelBuilder.Entity<tblAppMember2>().HasNoKey();
			modelBuilder.Entity<tblAppMember2>().Property(x=>x.AppMemberID).HasColumnName("AppMemberID").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblAppMember2>().Property(x=>x.AppMemberStatusID).HasColumnName("AppMemberStatusID").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblAppMember2>().Property(x=>x.MSISDN).HasColumnName("MSISDN").HasColumnType("VarChar(15)").ValueGeneratedNever().HasMaxLength(15);
			modelBuilder.Entity<tblAppMember2>().Property(x=>x.FacebookId).HasColumnName("FacebookId").HasColumnType("VarChar(50)").ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<tblAppMember2>().Property(x=>x.GoogleId).HasColumnName("GoogleId").HasColumnType("VarChar(50)").ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<tblAppMember2>().Property(x=>x.Email).HasColumnName("Email").HasColumnType("VarChar(150)").ValueGeneratedNever().HasMaxLength(150);
			modelBuilder.Entity<tblAppMember2>().Property(x=>x.Username).HasColumnName("Username").HasColumnType("NVarChar(50)").ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<tblAppMember2>().Property(x=>x.Password).HasColumnName("Password").HasColumnType("NVarChar(50)").ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<tblAppMember2>().Property(x=>x.BirthDate).HasColumnName("BirthDate").HasColumnType("DateTime").ValueGeneratedNever();
			modelBuilder.Entity<tblAppMember2>().Property(x=>x.CreationDate).HasColumnName("CreationDate").HasColumnType("DateTime").ValueGeneratedNever();
			modelBuilder.Entity<tblAppMember2>().Property(x=>x.LastLoginDate).HasColumnName("LastLoginDate").HasColumnType("DateTime").ValueGeneratedNever();
			modelBuilder.Entity<tblAppMember2>().Property(x=>x.LoginsCount).HasColumnName("LoginsCount").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblAppMember2>().Property(x=>x.FirstName).HasColumnName("FirstName").HasColumnType("NVarChar(100)").ValueGeneratedNever().HasMaxLength(100);
			modelBuilder.Entity<tblAppMember2>().Property(x=>x.LastName).HasColumnName("LastName").HasColumnType("NVarChar(100)").ValueGeneratedNever().HasMaxLength(100);
			modelBuilder.Entity<tblAppMember2>().Property(x=>x.Gender).HasColumnName("Gender").HasColumnType("VarChar(10)").ValueGeneratedNever().HasMaxLength(10);
			modelBuilder.Entity<tblAppMember2>().Property(x=>x.PersonalNote).HasColumnName("PersonalNote").HasColumnType("NVarChar(1000)").ValueGeneratedNever().HasMaxLength(1000);
			modelBuilder.Entity<tblAppMember2>().Property(x=>x.WebUrl).HasColumnName("WebUrl").HasColumnType("VarChar(255)").ValueGeneratedNever().HasMaxLength(255);
			modelBuilder.Entity<tblAppMember2>().Property(x=>x.Address).HasColumnName("Address").HasColumnType("NVarChar(255)").ValueGeneratedNever().HasMaxLength(255);
			modelBuilder.Entity<tblAppMember2>().Property(x=>x.ZipCode).HasColumnName("ZipCode").HasColumnType("NVarChar(50)").ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<tblAppMember2>().Property(x=>x.City).HasColumnName("City").HasColumnType("NVarChar(250)").ValueGeneratedNever().HasMaxLength(250);
			modelBuilder.Entity<tblAppMember2>().Property(x=>x.Country).HasColumnName("Country").HasColumnType("NVarChar(250)").ValueGeneratedNever().HasMaxLength(250);
			modelBuilder.Entity<tblAppMember2>().Property(x=>x.IP).HasColumnName("IP").HasColumnType("VarChar(50)").ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<tblAppMember2>().Property(x=>x.PosFirmaID).HasColumnName("PosFirmaID").HasColumnType("Int").ValueGeneratedNever();
			modelBuilder.Entity<tblAppMember2>().Property(x=>x.ReferentNote).HasColumnName("ReferentNote").HasColumnType("NVarChar(1000)").ValueGeneratedNever().HasMaxLength(1000);
			modelBuilder.Entity<tblAppMember2>().Property(x=>x.IsQuizQuestionsEditor).HasColumnName("IsQuizQuestionsEditor").HasColumnType("Bit").ValueGeneratedNever();
		}

		partial void Customize_tblAppMember2(ModelBuilder modelBuilder);
		#endregion

		#region guest_tblAppMember2
		private void Map_guest_tblAppMember2(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<guest_tblAppMember2>().ToTable("tblAppMember2", "guest");
			modelBuilder.Entity<guest_tblAppMember2>().HasNoKey();
			modelBuilder.Entity<guest_tblAppMember2>().Property(x=>x.AppMemberID).HasColumnName("AppMemberID").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<guest_tblAppMember2>().Property(x=>x.AppMemberStatusID).HasColumnName("AppMemberStatusID").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<guest_tblAppMember2>().Property(x=>x.MSISDN).HasColumnName("MSISDN").HasColumnType("VarChar(15)").ValueGeneratedNever().HasMaxLength(15);
			modelBuilder.Entity<guest_tblAppMember2>().Property(x=>x.FacebookId).HasColumnName("FacebookId").HasColumnType("VarChar(50)").ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<guest_tblAppMember2>().Property(x=>x.GoogleId).HasColumnName("GoogleId").HasColumnType("VarChar(50)").ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<guest_tblAppMember2>().Property(x=>x.Email).HasColumnName("Email").HasColumnType("VarChar(150)").ValueGeneratedNever().HasMaxLength(150);
			modelBuilder.Entity<guest_tblAppMember2>().Property(x=>x.Username).HasColumnName("Username").HasColumnType("NVarChar(50)").ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<guest_tblAppMember2>().Property(x=>x.Password).HasColumnName("Password").HasColumnType("NVarChar(50)").ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<guest_tblAppMember2>().Property(x=>x.BirthDate).HasColumnName("BirthDate").HasColumnType("DateTime").ValueGeneratedNever();
			modelBuilder.Entity<guest_tblAppMember2>().Property(x=>x.CreationDate).HasColumnName("CreationDate").HasColumnType("DateTime").ValueGeneratedNever();
			modelBuilder.Entity<guest_tblAppMember2>().Property(x=>x.LastLoginDate).HasColumnName("LastLoginDate").HasColumnType("DateTime").ValueGeneratedNever();
			modelBuilder.Entity<guest_tblAppMember2>().Property(x=>x.LoginsCount).HasColumnName("LoginsCount").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<guest_tblAppMember2>().Property(x=>x.FirstName).HasColumnName("FirstName").HasColumnType("NVarChar(100)").ValueGeneratedNever().HasMaxLength(100);
			modelBuilder.Entity<guest_tblAppMember2>().Property(x=>x.LastName).HasColumnName("LastName").HasColumnType("NVarChar(100)").ValueGeneratedNever().HasMaxLength(100);
			modelBuilder.Entity<guest_tblAppMember2>().Property(x=>x.Gender).HasColumnName("Gender").HasColumnType("VarChar(10)").ValueGeneratedNever().HasMaxLength(10);
			modelBuilder.Entity<guest_tblAppMember2>().Property(x=>x.PersonalNote).HasColumnName("PersonalNote").HasColumnType("NVarChar(1000)").ValueGeneratedNever().HasMaxLength(1000);
			modelBuilder.Entity<guest_tblAppMember2>().Property(x=>x.WebUrl).HasColumnName("WebUrl").HasColumnType("VarChar(255)").ValueGeneratedNever().HasMaxLength(255);
			modelBuilder.Entity<guest_tblAppMember2>().Property(x=>x.Address).HasColumnName("Address").HasColumnType("NVarChar(255)").ValueGeneratedNever().HasMaxLength(255);
			modelBuilder.Entity<guest_tblAppMember2>().Property(x=>x.ZipCode).HasColumnName("ZipCode").HasColumnType("NVarChar(50)").ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<guest_tblAppMember2>().Property(x=>x.City).HasColumnName("City").HasColumnType("NVarChar(250)").ValueGeneratedNever().HasMaxLength(250);
			modelBuilder.Entity<guest_tblAppMember2>().Property(x=>x.Country).HasColumnName("Country").HasColumnType("NVarChar(250)").ValueGeneratedNever().HasMaxLength(250);
			modelBuilder.Entity<guest_tblAppMember2>().Property(x=>x.IP).HasColumnName("IP").HasColumnType("VarChar(50)").ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<guest_tblAppMember2>().Property(x=>x.PosFirmaID).HasColumnName("PosFirmaID").HasColumnType("Int").ValueGeneratedNever();
			modelBuilder.Entity<guest_tblAppMember2>().Property(x=>x.ReferentNote).HasColumnName("ReferentNote").HasColumnType("NVarChar(1000)").ValueGeneratedNever().HasMaxLength(1000);
			modelBuilder.Entity<guest_tblAppMember2>().Property(x=>x.IsQuizQuestionsEditor).HasColumnName("IsQuizQuestionsEditor").HasColumnType("Bit").ValueGeneratedNever();
		}

		partial void Customize_guest_tblAppMember2(ModelBuilder modelBuilder);
		#endregion

		#region tblAppMemberPermission
		private void Map_tblAppMemberPermission(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<tblAppMemberPermission>().ToTable("tblAppMemberPermission", "dbo");
			modelBuilder.Entity<tblAppMemberPermission>().HasKey("AppPermissionID", "AppMemberID");
			modelBuilder.Entity<tblAppMemberPermission>().Property(x=>x.AppPermissionID).HasColumnName("AppPermissionID").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblAppMemberPermission>().Property(x=>x.AppMemberID).HasColumnName("AppMemberID").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblAppMemberPermission>().Property(x=>x.DateInserted).HasColumnName("DateInserted").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblAppMemberPermission>().Property(x=>x.InsertedByAppMemberID).HasColumnName("InsertedByAppMemberID").HasColumnType("Int").ValueGeneratedNever();
		}

		partial void Customize_tblAppMemberPermission(ModelBuilder modelBuilder);
		#endregion

		#region tblAppMemberPicture
		private void Map_tblAppMemberPicture(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<tblAppMemberPicture>().ToTable("tblAppMemberPicture", "dbo");
			modelBuilder.Entity<tblAppMemberPicture>().HasKey(x=>x.AppMemberPictureID);
			modelBuilder.Entity<tblAppMemberPicture>().Property(x=>x.AppMemberPictureID).HasColumnName("AppMemberPictureID").HasColumnType("Int").IsRequired().ValueGeneratedOnAdd();
			modelBuilder.Entity<tblAppMemberPicture>().Property(x=>x.AppMemberID).HasColumnName("AppMemberID").HasColumnType("Int").ValueGeneratedNever();
			modelBuilder.Entity<tblAppMemberPicture>().Property(x=>x.InsertionDate).HasColumnName("InsertionDate").HasColumnType("DateTime").ValueGeneratedNever();
			modelBuilder.Entity<tblAppMemberPicture>().Property(x=>x.FileName).HasColumnName("FileName").HasColumnType("NVarChar(500)").ValueGeneratedNever().HasMaxLength(500);
			modelBuilder.Entity<tblAppMemberPicture>().Property(x=>x.ImageData).HasColumnName("ImageData").HasColumnType("VarBinary(MAX)").ValueGeneratedNever();
			modelBuilder.Entity<tblAppMemberPicture>().Property(x=>x.ImageMimeType).HasColumnName("ImageMimeType").HasColumnType("VarChar(20)").ValueGeneratedNever().HasMaxLength(20);
			modelBuilder.Entity<tblAppMemberPicture>().Property(x=>x.ThumbData).HasColumnName("ThumbData").HasColumnType("VarBinary(MAX)").ValueGeneratedNever();
			modelBuilder.Entity<tblAppMemberPicture>().Property(x=>x.ThumbMimeType).HasColumnName("ThumbMimeType").HasColumnType("VarChar(20)").ValueGeneratedNever().HasMaxLength(20);
		}

		partial void Customize_tblAppMemberPicture(ModelBuilder modelBuilder);
		#endregion

		#region tblAppMemberPicture2
		private void Map_tblAppMemberPicture2(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<tblAppMemberPicture2>().ToTable("tblAppMemberPicture2", "dbo");
			modelBuilder.Entity<tblAppMemberPicture2>().HasKey(x=>x.AppMemberPictureID);
			modelBuilder.Entity<tblAppMemberPicture2>().Property(x=>x.AppMemberPictureID).HasColumnName("AppMemberPictureID").HasColumnType("Int").IsRequired().ValueGeneratedOnAdd();
			modelBuilder.Entity<tblAppMemberPicture2>().Property(x=>x.AppMemberID).HasColumnName("AppMemberID").HasColumnType("Int").ValueGeneratedNever();
			modelBuilder.Entity<tblAppMemberPicture2>().Property(x=>x.InsertionDate).HasColumnName("InsertionDate").HasColumnType("DateTime").ValueGeneratedNever();
			modelBuilder.Entity<tblAppMemberPicture2>().Property(x=>x.ImageData).HasColumnName("ImageData").HasColumnType("Image").ValueGeneratedNever();
			modelBuilder.Entity<tblAppMemberPicture2>().Property(x=>x.ThumbData).HasColumnName("ThumbData").HasColumnType("Image").ValueGeneratedNever();
			modelBuilder.Entity<tblAppMemberPicture2>().Property(x=>x.FileName).HasColumnName("FileName").HasColumnType("NVarChar(500)").ValueGeneratedNever().HasMaxLength(500);
			modelBuilder.Entity<tblAppMemberPicture2>().Property(x=>x.ImageMimeType).HasColumnName("ImageMimeType").HasColumnType("VarChar(20)").ValueGeneratedNever().HasMaxLength(20);
			modelBuilder.Entity<tblAppMemberPicture2>().Property(x=>x.ThumbMimeType).HasColumnName("ThumbMimeType").HasColumnType("VarChar(20)").ValueGeneratedNever().HasMaxLength(20);
		}

		partial void Customize_tblAppMemberPicture2(ModelBuilder modelBuilder);
		#endregion

		#region tblAppMemberStatus
		private void Map_tblAppMemberStatus(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<tblAppMemberStatus>().ToTable("tblAppMemberStatus", "dbo");
			modelBuilder.Entity<tblAppMemberStatus>().HasKey(x=>x.AppMemberStatusID);
			modelBuilder.Entity<tblAppMemberStatus>().Property(x=>x.AppMemberStatusID).HasColumnName("AppMemberStatusID").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblAppMemberStatus>().Property(x=>x.IsActive).HasColumnName("IsActive").HasColumnType("Bit").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblAppMemberStatus>().Property(x=>x.Name).HasColumnName("Name").HasColumnType("NVarChar(100)").ValueGeneratedNever().HasMaxLength(100);
			modelBuilder.Entity<tblAppMemberStatus>().Property(x=>x.Description).HasColumnName("Description").HasColumnType("NVarChar(500)").ValueGeneratedNever().HasMaxLength(500);
		}

		partial void Customize_tblAppMemberStatus(ModelBuilder modelBuilder);
		#endregion

		#region tblVehicle
		private void Map_tblVehicle(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<tblVehicle>().ToTable("tblVehicle", "dbo");
			modelBuilder.Entity<tblVehicle>().HasKey(x=>x.VehicleID);
			modelBuilder.Entity<tblVehicle>().Property(x=>x.VehicleID).HasColumnName("VehicleID").HasColumnType("Int").IsRequired().ValueGeneratedOnAdd();
			modelBuilder.Entity<tblVehicle>().Property(x=>x.VehicleRipID).HasColumnName("VehicleRipID").HasColumnType("Int").IsRequired().ValueGeneratedNever();
		}

		partial void Customize_tblVehicle(ModelBuilder modelBuilder);
		#endregion

		#endregion

		#region Relationships mapping
		private void RelationshipsMapping(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<tblAppMember>().HasOne(x=>x.tblAppMemberStatus).WithMany(x=>x.tblAppMemberList).HasForeignKey(x=>x.AppMemberStatusID).IsRequired(true);
			modelBuilder.Entity<tblAppMember>().HasMany(x=>x.tblAppMemberPermissionList).WithOne(x=>x.tblAppMember).HasForeignKey(x=>x.AppMemberID).IsRequired(true);
			modelBuilder.Entity<tblAppMember>().HasMany(x=>x.tblAppMemberPictureList).WithOne(x=>x.tblAppMember).HasForeignKey(x=>x.AppMemberID).IsRequired(false).OnDelete(DeleteBehavior.Cascade);
			modelBuilder.Entity<tblAppMember>().HasMany(x=>x.tblAppMemberPicture2List).WithOne(x=>x.tblAppMember).HasForeignKey(x=>x.AppMemberID).IsRequired(false);

			modelBuilder.Entity<tblAppMemberPermission>().HasOne(x=>x.tblAppMember).WithMany(x=>x.tblAppMemberPermissionList).HasForeignKey(x=>x.AppMemberID).IsRequired(true);

			modelBuilder.Entity<tblAppMemberPicture>().HasOne(x=>x.tblAppMember).WithMany(x=>x.tblAppMemberPictureList).HasForeignKey(x=>x.AppMemberID).IsRequired(false).OnDelete(DeleteBehavior.Cascade);

			modelBuilder.Entity<tblAppMemberPicture2>().HasOne(x=>x.tblAppMember).WithMany(x=>x.tblAppMemberPicture2List).HasForeignKey(x=>x.AppMemberID).IsRequired(false);

			modelBuilder.Entity<tblAppMemberStatus>().HasMany(x=>x.tblAppMemberList).WithOne(x=>x.tblAppMemberStatus).HasForeignKey(x=>x.AppMemberStatusID).IsRequired(true);

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

	#region dbo.tblAppMember
	public partial class tblAppMember : EFCoreEntityBase<tblAppMember>
	{
		public tblAppMember()
		{
			OnCreated();
		}

		public tblAppMember(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert
		/// </summary>
		public int AppMemberID { get; set; }

		/// <summary>
		/// DbType = "Int NOT NULL"
		/// </summary>
		public int AppMemberStatusID { get; set; }

		/// <summary>
		/// DbType = "VarChar(15)"
		/// </summary>
		public string MSISDN { get; set; }

		/// <summary>
		/// DbType = "VarChar(50)"
		/// </summary>
		public string FacebookId { get; set; }

		/// <summary>
		/// DbType = "VarChar(50)", DefaultValue = "google-default-id"
		/// </summary>
		public string GoogleId { get; set; } = "google-default-id";

		/// <summary>
		/// DbType = "VarChar(150)"
		/// </summary>
		public string Email { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50)"
		/// </summary>
		public string Username { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50)"
		/// </summary>
		public string Password { get; set; }

		/// <summary>
		/// DbType = "DateTime"
		/// </summary>
		public DateTime? BirthDate { get; set; }

		/// <summary>
		/// DbType = "DateTime", DefaultValue = /*getdate()*/ DateTime.Now
		/// </summary>
		public DateTime? CreationDate { get; set; } = /*getdate()*/ DateTime.Now;

		/// <summary>
		/// DbType = "DateTime", DefaultValue = /*2020-02-01*/ new DateTime(637161120000000000)
		/// </summary>
		public DateTime? LastLoginDate { get; set; } = /*2020-02-01*/ new DateTime(637161120000000000);

		/// <summary>
		/// DbType = "Int NOT NULL", DefaultValue = (int)(-1)
		/// </summary>
		public int LoginsCount { get; set; } = (int)(-1);

		/// <summary>
		/// DbType = "NVarChar(100)"
		/// </summary>
		public string FirstName { get; set; }

		/// <summary>
		/// DbType = "NVarChar(100)"
		/// </summary>
		public string LastName { get; set; }

		/// <summary>
		/// DbType = "VarChar(10)"
		/// </summary>
		public string Gender { get; set; }

		/// <summary>
		/// DbType = "NVarChar(1000)"
		/// </summary>
		public string PersonalNote { get; set; }

		/// <summary>
		/// DbType = "VarChar(255)"
		/// </summary>
		public string WebUrl { get; set; }

		/// <summary>
		/// DbType = "NVarChar(255)"
		/// </summary>
		public string Address { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50)"
		/// </summary>
		public string ZipCode { get; set; }

		/// <summary>
		/// DbType = "NVarChar(250)"
		/// </summary>
		public string City { get; set; }

		/// <summary>
		/// DbType = "NVarChar(250)"
		/// </summary>
		public string Country { get; set; }

		/// <summary>
		/// DbType = "VarChar(50)"
		/// </summary>
		public string IP { get; set; }

		/// <summary>
		/// DbType = "Int"
		/// </summary>
		public int? PosFirmaID { get; set; }

		/// <summary>
		/// DbType = "Bit", DefaultValue = true
		/// </summary>
		public bool? IsQuizQuestionsEditor { get; set; } = true;

		/// <summary>
		/// DbType = "Money", DefaultValue = (decimal)(12.930134)
		/// </summary>
		public decimal? StanjeRacuna { get; set; } = (decimal)(12.930134);

		/// <summary>
		/// DbType = "Int"
		/// </summary>
		public int? HomeMemberAddressID { get; set; }

		/// <summary>
		/// DbType = "Int"
		/// </summary>
		public int? WorkMemberAddressID { get; set; }

		/// <summary>
		/// DbType = "Int"
		/// </summary>
		public int? PrimaryMemberAddressID { get; set; }

		#endregion Columns

		#region Associations

		/// <summary>
		/// Association <br/>
		/// [FK][Many]tblAppMember.AppMemberStatusID --- [PK][One]tblAppMemberStatus.AppMemberStatusID <br/>
		/// </summary>
		public virtual tblAppMemberStatus tblAppMemberStatus { get; set; }

		/// <summary>
		/// Association <br/>
		/// [PK][One]tblAppMember.AppMemberID --- [FK][Many]tblAppMemberPermission.AppMemberID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<tblAppMemberPermission> tblAppMemberPermissionList { get; set; } = new List<tblAppMemberPermission>();

		/// <summary>
		/// Association <br/>
		/// [PK][One]tblAppMember.AppMemberID --- [FK][Many]tblAppMemberPicture.AppMemberID <br/>
		/// DeleteRule = Cascade <br/>
		/// </summary>
		public virtual List<tblAppMemberPicture> tblAppMemberPictureList { get; set; } = new List<tblAppMemberPicture>();

		/// <summary>
		/// Association <br/>
		/// [PK][One]tblAppMember.AppMemberID --- [FK][Many]tblAppMemberPicture2.AppMemberID <br/>
		/// DeleteRule = SetDefault <br/>
		/// </summary>
		public virtual List<tblAppMemberPicture2> tblAppMemberPicture2List { get; set; } = new List<tblAppMemberPicture2>();
		#endregion Associations

		partial void OnCreated();
	}
	#endregion dbo.tblAppMember

	#region dbo.tblAppMember2
	public partial class tblAppMember2 : EFCoreEntityBase<tblAppMember2>
	{
		public tblAppMember2()
		{
			OnCreated();
		}

		public tblAppMember2(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "Int NOT NULL"
		/// </summary>
		public int AppMemberID { get; set; }

		/// <summary>
		/// DbType = "Int NOT NULL"
		/// </summary>
		public int AppMemberStatusID { get; set; }

		/// <summary>
		/// DbType = "VarChar(15)"
		/// </summary>
		public string MSISDN { get; set; }

		/// <summary>
		/// DbType = "VarChar(50)"
		/// </summary>
		public string FacebookId { get; set; }

		/// <summary>
		/// DbType = "VarChar(50)"
		/// </summary>
		public string GoogleId { get; set; }

		/// <summary>
		/// DbType = "VarChar(150)"
		/// </summary>
		public string Email { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50)"
		/// </summary>
		public string Username { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50)"
		/// </summary>
		public string Password { get; set; }

		/// <summary>
		/// DbType = "DateTime"
		/// </summary>
		public DateTime? BirthDate { get; set; }

		/// <summary>
		/// DbType = "DateTime"
		/// </summary>
		public DateTime? CreationDate { get; set; }

		/// <summary>
		/// DbType = "DateTime"
		/// </summary>
		public DateTime? LastLoginDate { get; set; }

		/// <summary>
		/// DbType = "Int NOT NULL", DefaultValue = (int)(0)
		/// </summary>
		public int LoginsCount { get; set; } = (int)(0);

		/// <summary>
		/// DbType = "NVarChar(100)"
		/// </summary>
		public string FirstName { get; set; }

		/// <summary>
		/// DbType = "NVarChar(100)"
		/// </summary>
		public string LastName { get; set; }

		/// <summary>
		/// DbType = "VarChar(10)"
		/// </summary>
		public string Gender { get; set; }

		/// <summary>
		/// DbType = "NVarChar(1000)"
		/// </summary>
		public string PersonalNote { get; set; }

		/// <summary>
		/// DbType = "VarChar(255)"
		/// </summary>
		public string WebUrl { get; set; }

		/// <summary>
		/// DbType = "NVarChar(255)"
		/// </summary>
		public string Address { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50)"
		/// </summary>
		public string ZipCode { get; set; }

		/// <summary>
		/// DbType = "NVarChar(250)"
		/// </summary>
		public string City { get; set; }

		/// <summary>
		/// DbType = "NVarChar(250)"
		/// </summary>
		public string Country { get; set; }

		/// <summary>
		/// DbType = "VarChar(50)"
		/// </summary>
		public string IP { get; set; }

		/// <summary>
		/// DbType = "Int"
		/// </summary>
		public int? PosFirmaID { get; set; }

		/// <summary>
		/// DbType = "NVarChar(1000)"
		/// </summary>
		public string ReferentNote { get; set; }

		/// <summary>
		/// DbType = "Bit"
		/// </summary>
		public bool? IsQuizQuestionsEditor { get; set; }

		#endregion Columns

		#region Associations
		#endregion Associations

		partial void OnCreated();
	}
	#endregion dbo.tblAppMember2

	#region guest.tblAppMember2
	public partial class guest_tblAppMember2 : EFCoreEntityBase<guest_tblAppMember2>
	{
		public guest_tblAppMember2()
		{
			OnCreated();
		}

		public guest_tblAppMember2(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "Int NOT NULL"
		/// </summary>
		public int AppMemberID { get; set; }

		/// <summary>
		/// DbType = "Int NOT NULL"
		/// </summary>
		public int AppMemberStatusID { get; set; }

		/// <summary>
		/// DbType = "VarChar(15)"
		/// </summary>
		public string MSISDN { get; set; }

		/// <summary>
		/// DbType = "VarChar(50)"
		/// </summary>
		public string FacebookId { get; set; }

		/// <summary>
		/// DbType = "VarChar(50)"
		/// </summary>
		public string GoogleId { get; set; }

		/// <summary>
		/// DbType = "VarChar(150)"
		/// </summary>
		public string Email { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50)"
		/// </summary>
		public string Username { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50)"
		/// </summary>
		public string Password { get; set; }

		/// <summary>
		/// DbType = "DateTime"
		/// </summary>
		public DateTime? BirthDate { get; set; }

		/// <summary>
		/// DbType = "DateTime"
		/// </summary>
		public DateTime? CreationDate { get; set; }

		/// <summary>
		/// DbType = "DateTime"
		/// </summary>
		public DateTime? LastLoginDate { get; set; }

		/// <summary>
		/// DbType = "Int NOT NULL", DefaultValue = (int)(0)
		/// </summary>
		public int LoginsCount { get; set; } = (int)(0);

		/// <summary>
		/// DbType = "NVarChar(100)"
		/// </summary>
		public string FirstName { get; set; }

		/// <summary>
		/// DbType = "NVarChar(100)"
		/// </summary>
		public string LastName { get; set; }

		/// <summary>
		/// DbType = "VarChar(10)"
		/// </summary>
		public string Gender { get; set; }

		/// <summary>
		/// DbType = "NVarChar(1000)"
		/// </summary>
		public string PersonalNote { get; set; }

		/// <summary>
		/// DbType = "VarChar(255)"
		/// </summary>
		public string WebUrl { get; set; }

		/// <summary>
		/// DbType = "NVarChar(255)"
		/// </summary>
		public string Address { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50)"
		/// </summary>
		public string ZipCode { get; set; }

		/// <summary>
		/// DbType = "NVarChar(250)"
		/// </summary>
		public string City { get; set; }

		/// <summary>
		/// DbType = "NVarChar(250)"
		/// </summary>
		public string Country { get; set; }

		/// <summary>
		/// DbType = "VarChar(50)"
		/// </summary>
		public string IP { get; set; }

		/// <summary>
		/// DbType = "Int"
		/// </summary>
		public int? PosFirmaID { get; set; }

		/// <summary>
		/// DbType = "NVarChar(1000)"
		/// </summary>
		public string ReferentNote { get; set; }

		/// <summary>
		/// DbType = "Bit"
		/// </summary>
		public bool? IsQuizQuestionsEditor { get; set; }

		#endregion Columns

		#region Associations
		#endregion Associations

		partial void OnCreated();
	}
	#endregion guest.tblAppMember2

	#region dbo.tblAppMemberPermission
	public partial class tblAppMemberPermission : EFCoreEntityBase<tblAppMemberPermission>
	{
		public tblAppMemberPermission()
		{
			OnCreated();
		}

		public tblAppMemberPermission(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "Int NOT NULL", IsPrimaryKey = true
		/// </summary>
		public int AppPermissionID { get; set; }

		/// <summary>
		/// DbType = "Int NOT NULL", IsPrimaryKey = true
		/// </summary>
		public int AppMemberID { get; set; }

		/// <summary>
		/// DbType = "DateTime NOT NULL"
		/// </summary>
		public DateTime DateInserted { get; set; }

		/// <summary>
		/// DbType = "Int"
		/// </summary>
		public int? InsertedByAppMemberID { get; set; }

		#endregion Columns

		#region Associations

		/// <summary>
		/// Association <br/>
		/// [FK][Many]tblAppMemberPermission.AppMemberID --- [PK][One]tblAppMember.AppMemberID <br/>
		/// </summary>
		public virtual tblAppMember tblAppMember { get; set; }
		#endregion Associations

		partial void OnCreated();
	}
	#endregion dbo.tblAppMemberPermission

	#region dbo.tblAppMemberPicture
	public partial class tblAppMemberPicture : EFCoreEntityBase<tblAppMemberPicture>
	{
		public tblAppMemberPicture()
		{
			OnCreated();
		}

		public tblAppMemberPicture(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert
		/// </summary>
		public int AppMemberPictureID { get; set; }

		/// <summary>
		/// DbType = "Int"
		/// </summary>
		public int? AppMemberID { get; set; }

		/// <summary>
		/// DbType = "DateTime"
		/// </summary>
		public DateTime? InsertionDate { get; set; }

		/// <summary>
		/// DbType = "NVarChar(500)"
		/// </summary>
		public string FileName { get; set; }

		/// <summary>
		/// DbType = "VarBinary(MAX)"
		/// </summary>
		public byte[] ImageData { get; set; }

		/// <summary>
		/// DbType = "VarChar(20)"
		/// </summary>
		public string ImageMimeType { get; set; }

		/// <summary>
		/// DbType = "VarBinary(MAX)"
		/// </summary>
		public byte[] ThumbData { get; set; }

		/// <summary>
		/// DbType = "VarChar(20)"
		/// </summary>
		public string ThumbMimeType { get; set; }

		#endregion Columns

		#region Associations

		/// <summary>
		/// Association <br/>
		/// [FK][Many]tblAppMemberPicture.AppMemberID --- [PK][One]tblAppMember.AppMemberID <br/>
		/// </summary>
		public virtual tblAppMember tblAppMember { get; set; }
		#endregion Associations

		partial void OnCreated();
	}
	#endregion dbo.tblAppMemberPicture

	#region dbo.tblAppMemberPicture2
	public partial class tblAppMemberPicture2 : EFCoreEntityBase<tblAppMemberPicture2>
	{
		public tblAppMemberPicture2()
		{
			OnCreated();
		}

		public tblAppMemberPicture2(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert
		/// </summary>
		public int AppMemberPictureID { get; set; }

		/// <summary>
		/// DbType = "Int"
		/// </summary>
		public int? AppMemberID { get; set; }

		/// <summary>
		/// DbType = "DateTime"
		/// </summary>
		public DateTime? InsertionDate { get; set; }

		/// <summary>
		/// DbType = "Image"
		/// </summary>
		public byte[] ImageData { get; set; }

		/// <summary>
		/// DbType = "Image"
		/// </summary>
		public byte[] ThumbData { get; set; }

		/// <summary>
		/// DbType = "NVarChar(500)"
		/// </summary>
		public string FileName { get; set; }

		/// <summary>
		/// DbType = "VarChar(20)"
		/// </summary>
		public string ImageMimeType { get; set; }

		/// <summary>
		/// DbType = "VarChar(20)"
		/// </summary>
		public string ThumbMimeType { get; set; }

		#endregion Columns

		#region Associations

		/// <summary>
		/// Association <br/>
		/// [FK][Many]tblAppMemberPicture2.AppMemberID --- [PK][One]tblAppMember.AppMemberID <br/>
		/// </summary>
		public virtual tblAppMember tblAppMember { get; set; }
		#endregion Associations

		partial void OnCreated();
	}
	#endregion dbo.tblAppMemberPicture2

	#region dbo.tblAppMemberStatus
	public partial class tblAppMemberStatus : EFCoreEntityBase<tblAppMemberStatus>
	{
		public tblAppMemberStatus()
		{
			OnCreated();
		}

		public tblAppMemberStatus(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "Int NOT NULL", IsPrimaryKey = true
		/// </summary>
		public int AppMemberStatusID { get; set; }

		/// <summary>
		/// DbType = "Bit NOT NULL", DefaultValue = false
		/// </summary>
		public bool IsActive { get; set; } = false;

		/// <summary>
		/// DbType = "NVarChar(100)"
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// DbType = "NVarChar(500)"
		/// </summary>
		public string Description { get; set; }

		#endregion Columns

		#region Associations

		/// <summary>
		/// Association <br/>
		/// [PK][One]tblAppMemberStatus.AppMemberStatusID --- [FK][Many]tblAppMember.AppMemberStatusID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<tblAppMember> tblAppMemberList { get; set; } = new List<tblAppMember>();
		#endregion Associations

		partial void OnCreated();
	}
	#endregion dbo.tblAppMemberStatus

	#region dbo.tblVehicle
	public partial class tblVehicle : EFCoreEntityBase<tblVehicle>
	{
		public tblVehicle()
		{
			OnCreated();
		}

		public tblVehicle(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert
		/// </summary>
		public int VehicleID { get; set; }

		/// <summary>
		/// DbType = "Int NOT NULL"
		/// </summary>
		public int VehicleRipID { get; set; }

		#endregion Columns

		#region Associations
		#endregion Associations

		partial void OnCreated();
	}
	#endregion dbo.tblVehicle


	#endregion

	#region Functions Return types

	#region spMultiResultsMultipleResults
	public partial class spMultiResultsMultipleResults
	{
		public spMultiResultsMultipleResults(){ }

		public List<spMultiResultsResult1> Result1 { get; set; }

		public List<spMultiResultsResult2> Result2 { get; set; }

		public List<spMultiResultsResult3> Result3 { get; set; }

		public List<spMultiResultsResult4> Result4 { get; set; }

		public int ReturnValue { get; set; }

	}
	#endregion spMultiResultsMultipleResults

	#region spMultiResults2MultipleResults
	public partial class spMultiResults2MultipleResults
	{
		public spMultiResults2MultipleResults(){ }

		public List<int> Clients { get; set; }

		public List<double?> Owners { get; set; }

		public List<tblVehicle> Vehicles { get; set; }

		public List<spMultiResults2Result> Result4 { get; set; }

		public int ReturnValue { get; set; }

	}
	#endregion spMultiResults2MultipleResults

	#region spRandomNumberMultipleResults
	public partial class spRandomNumberMultipleResults
	{
		public spRandomNumberMultipleResults(){ }

		public double Random { get; set; }

		public int ReturnValue { get; set; }

	}
	#endregion spRandomNumberMultipleResults

	#region guest_fnGetStariNoviGranicaResult
	public partial class guest_fnGetStariNoviGranicaResult
	{
		public guest_fnGetStariNoviGranicaResult(){ }

		/// <summary>
		/// DbType = "DateTime NOT NULL"
		/// </summary>
		public DateTime StartDate { get; set; }

		/// <summary>
		/// DbType = "DateTime NOT NULL"
		/// </summary>
		public DateTime EndDate { get; set; }

	}
	#endregion guest_fnGetStariNoviGranicaResult

	#region guest_spGetAppMembersMultipleResults
	public partial class guest_spGetAppMembersMultipleResults
	{
		public guest_spGetAppMembersMultipleResults(){ }

		public List<guest_spGetAppMembersResult1> Result1 { get; set; }

		public List<guest_spGetAppMembersResult2> Result2 { get; set; }

		public int ReturnValue { get; set; }

	}
	#endregion guest_spGetAppMembersMultipleResults

	#region spMultiResultsResult1
	public partial class spMultiResultsResult1
	{
		public spMultiResultsResult1(){ }

		/// <summary>
		/// DbType = "DateTime NOT NULL"
		/// </summary>
		public DateTime CurrentDate1 { get; set; }

	}
	#endregion spMultiResultsResult1

	#region spMultiResultsResult2
	public partial class spMultiResultsResult2
	{
		public spMultiResultsResult2(){ }

		/// <summary>
		/// DbType = "Int NOT NULL"
		/// </summary>
		public int RowID { get; set; }

		/// <summary>
		/// DbType = "Int NOT NULL"
		/// </summary>
		public int Name { get; set; }

	}
	#endregion spMultiResultsResult2

	#region spMultiResultsResult3
	public partial class spMultiResultsResult3
	{
		public spMultiResultsResult3(){ }

		/// <summary>
		/// DbType = "VarChar(100)"
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// DbType = "VarChar(100)"
		/// </summary>
		public string Value { get; set; }

	}
	#endregion spMultiResultsResult3

	#region spMultiResultsResult4
	public partial class spMultiResultsResult4
	{
		public spMultiResultsResult4(){ }

		/// <summary>
		/// DbType = "DateTime NOT NULL"
		/// </summary>
		public DateTime CurrentDate2 { get; set; }

	}
	#endregion spMultiResultsResult4

	#region spMultiResults2Result
	public partial class spMultiResults2Result
	{
		public spMultiResults2Result(){ }

		/// <summary>
		/// DbType = "Int NOT NULL"
		/// </summary>
		public int Ordinal { get; set; }

		/// <summary>
		/// DbType = "VarChar(6) NOT NULL"
		/// </summary>
		public string Name { get; set; }

	}
	#endregion spMultiResults2Result

	#region guest_spGetAppMembersResult1
	public partial class guest_spGetAppMembersResult1
	{
		public guest_spGetAppMembersResult1(){ }

		/// <summary>
		/// DbType = "Int"
		/// </summary>
		public int? num { get; set; }

		/// <summary>
		/// DbType = "Int NOT NULL"
		/// </summary>
		public int AppMemberID { get; set; }

		/// <summary>
		/// DbType = "Int NOT NULL"
		/// </summary>
		public int AppMemberStatusID { get; set; }

		/// <summary>
		/// DbType = "VarChar(15)"
		/// </summary>
		public string MSISDN { get; set; }

		/// <summary>
		/// DbType = "VarChar(50)"
		/// </summary>
		public string FacebookId { get; set; }

		/// <summary>
		/// DbType = "VarChar(50)"
		/// </summary>
		public string GoogleId { get; set; }

		/// <summary>
		/// DbType = "VarChar(150)"
		/// </summary>
		public string Email { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50)"
		/// </summary>
		public string Username { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50)"
		/// </summary>
		public string Password { get; set; }

		/// <summary>
		/// DbType = "DateTime"
		/// </summary>
		public DateTime? BirthDate { get; set; }

		/// <summary>
		/// DbType = "DateTime"
		/// </summary>
		public DateTime? CreationDate { get; set; }

		/// <summary>
		/// DbType = "DateTime"
		/// </summary>
		public DateTime? LastLoginDate { get; set; }

		/// <summary>
		/// DbType = "Int NOT NULL"
		/// </summary>
		public int LoginsCount { get; set; }

		/// <summary>
		/// DbType = "NVarChar(100)"
		/// </summary>
		public string FirstName { get; set; }

		/// <summary>
		/// DbType = "NVarChar(100)"
		/// </summary>
		public string LastName { get; set; }

		/// <summary>
		/// DbType = "VarChar(10)"
		/// </summary>
		public string Gender { get; set; }

		/// <summary>
		/// DbType = "NVarChar(1000)"
		/// </summary>
		public string PersonalNote { get; set; }

		/// <summary>
		/// DbType = "VarChar(255)"
		/// </summary>
		public string WebUrl { get; set; }

		/// <summary>
		/// DbType = "NVarChar(255)"
		/// </summary>
		public string Address { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50)"
		/// </summary>
		public string ZipCode { get; set; }

		/// <summary>
		/// DbType = "NVarChar(250)"
		/// </summary>
		public string City { get; set; }

		/// <summary>
		/// DbType = "NVarChar(250)"
		/// </summary>
		public string Country { get; set; }

		/// <summary>
		/// DbType = "VarChar(50)"
		/// </summary>
		public string IP { get; set; }

		/// <summary>
		/// DbType = "Int"
		/// </summary>
		public int? PosFirmaID { get; set; }

		/// <summary>
		/// DbType = "Bit"
		/// </summary>
		public bool? IsQuizQuestionsEditor { get; set; }

		/// <summary>
		/// DbType = "Money"
		/// </summary>
		public decimal? StanjeRacuna { get; set; }

		/// <summary>
		/// DbType = "Int"
		/// </summary>
		public int? HomeMemberAddressID { get; set; }

		/// <summary>
		/// DbType = "Int"
		/// </summary>
		public int? WorkMemberAddressID { get; set; }

		/// <summary>
		/// DbType = "Int"
		/// </summary>
		public int? PrimaryMemberAddressID { get; set; }

	}
	#endregion guest_spGetAppMembersResult1

	#region guest_spGetAppMembersResult2
	public partial class guest_spGetAppMembersResult2
	{
		public guest_spGetAppMembersResult2(){ }

		/// <summary>
		/// DbType = "Int"
		/// </summary>
		public int? TotalCount { get; set; }

	}
	#endregion guest_spGetAppMembersResult2

	#endregion

}
