//************************************************************
// Generated using CalystoEFCoreFluentGenerator for MySql
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

namespace CalystoUnittestNamespace4
{
	/// <summary>
	/// CalystoEFCoreFluent for MySql
	/// </summary>
	public partial class dbCalystoUnittestDataContext4 : DbContext
	{
		#region Context constructors
		
		public dbCalystoUnittestDataContext4(bool useLazyLoadingProxies)
			: base(new DbContextOptionsBuilder<dbCalystoUnittestDataContext4>()
				.UsingThis(builder => { if (useLazyLoadingProxies) builder.UseLazyLoadingProxies(); })
				.Options)
		{
			OnCreated();
		}
		
		public dbCalystoUnittestDataContext4(Action<DbContextOptionsBuilder<dbCalystoUnittestDataContext4>> configure)
			: base(new DbContextOptionsBuilder<dbCalystoUnittestDataContext4>()
				.UsingThis(builder => configure(builder))
				.Options)
		{
			OnCreated();
		}

		public dbCalystoUnittestDataContext4(DbContextOptions<dbCalystoUnittestDataContext4> options) : base(options)
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
		public virtual DbSet<tblAppMemberPermission> tblAppMemberPermission { get; set; }
		public virtual DbSet<tblAppMemberPicture> tblAppMemberPicture { get; set; }
		public virtual DbSet<tblAppMemberPicture2> tblAppMemberPicture2 { get; set; }
		public virtual DbSet<tblAppMemberStatus> tblAppMemberStatus { get; set; }
		public virtual DbSet<tblAppMobileLog> tblAppMobileLog { get; set; }
		public virtual DbSet<tblAppMobileLogKind> tblAppMobileLogKind { get; set; }
		public virtual DbSet<tblAppNewsletter> tblAppNewsletter { get; set; }
		public virtual DbSet<tblAppPermission> tblAppPermission { get; set; }
		public virtual DbSet<tblMemberAddress> tblMemberAddress { get; set; }
		public virtual DbSet<tblVehicle> tblVehicle { get; set; }
		public virtual DbSet<tblVehicleOverview> tblVehicleOverview { get; set; }
		public virtual DbSet<tblVehicleOverviewImage> tblVehicleOverviewImage { get; set; }
		public virtual DbSet<tblVehicleRip> tblVehicleRip { get; set; }
		public virtual DbSet<tblVehicleRipStatus> tblVehicleRipStatus { get; set; }
		public virtual DbSet<viewRandom> viewRandom { get; set; }

		#endregion Context properties for tables

		#region Context database functions

		/// <returns>Scalar value from function</returns>
		public int? fn_diagramobjects()
		{
			return this.ExecuteList<int?>($@"select dbCalystoUnittest.fn_diagramobjects()").First();
		}

		/// <param name="str">NVarChar(MAX)</param>
		/// <param name="expectedLength">Int</param>
		/// <param name="addPrefix">TinyInt(1)</param>
		/// <returns>Scalar value from function</returns>
		public string fnAddPaddingSpace(
			string str, 
			int? expectedLength, 
			bool? addPrefix)
		{
			return this.ExecuteList<string>($@"select dbCalystoUnittest.fnAddPaddingSpace({{0}}, {{1}}, {{2}})", str, expectedLength, addPrefix).First();
		}

		/// <returns>Sequence from function</returns>
		public List<fnCalculateDatumValuteRokPlacanjaResult> fnCalculateDatumValuteRokPlacanja()
		{
			return this.ExecuteList<fnCalculateDatumValuteRokPlacanjaResult>($@"select * from dbCalystoUnittest.fnCalculateDatumValuteRokPlacanja()").ToList();
		}

		/// <param name="list">NVarChar(MAX)</param>
		/// <returns>Sequence from function</returns>
		public List<fnConvertCsvArgsToIntTableResult> fnConvertCsvArgsToIntTable(string list)
		{
			return this.ExecuteList<fnConvertCsvArgsToIntTableResult>($@"select * from dbCalystoUnittest.fnConvertCsvArgsToIntTable({{0}})", list).ToList();
		}

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
			return this.ExecuteList<double?>($@"select dbCalystoUnittest.fnConvertCurrency({{0}}, {{1}}, {{2}}, {{3}}, {{4}})", amount, amount2, fromCurrency, toCurrency, exchangeRateDate).First();
		}

		/// <param name="value">DateTime</param>
		/// <returns>Scalar value from function</returns>
		public string fnFormatDateToStringISO(DateTime? value)
		{
			return this.ExecuteList<string>($@"select dbCalystoUnittest.fnFormatDateToStringISO({{0}})", value).First();
		}

		/// <param name="skip111">Int</param>
		/// <param name="take111">Int, DefaultValue = (int)(50)</param>
		/// <param name="validOnDate">DateTime, DefaultValue = null</param>
		/// <param name="valuta">VarChar(50), DefaultValue = null</param>
		/// <returns>Sequence from function</returns>
		public List<fnGetBankaValutaTecajResult> fnGetBankaValutaTecaj(
			int? skip111, 
			int? take111 = (int)(50), 
			DateTime? validOnDate = null, 
			string valuta = null)
		{
			return this.ExecuteList<fnGetBankaValutaTecajResult>($@"select * from dbCalystoUnittest.fnGetBankaValutaTecaj({{0}}, {{1}}, {{2}}, {{3}})", skip111, take111, validOnDate, valuta).ToList();
		}

		/// <param name="csvValues">VarChar(MAX)</param>
		/// <returns>Scalar value from function</returns>
		public int? fnGetRandomIntegerValue(string csvValues)
		{
			return this.ExecuteList<int?>($@"select dbCalystoUnittest.fnGetRandomIntegerValue({{0}})", csvValues).First();
		}

		/// <returns>Sequence from function</returns>
		public List<fnGetStariNoviGranicaResult> fnGetStariNoviGranica()
		{
			return this.ExecuteList<fnGetStariNoviGranicaResult>($@"select * from dbCalystoUnittest.fnGetStariNoviGranica()").ToList();
		}

		/// <param name="strToSplit">VarChar(MAX)</param>
		/// <param name="pattern">VarChar(100)</param>
		/// <returns>Sequence from function</returns>
		public List<fnSplitStringByPatternResult> fnSplitStringByPattern(
			string strToSplit, 
			string pattern)
		{
			return this.ExecuteList<fnSplitStringByPatternResult>($@"select * from dbCalystoUnittest.fnSplitStringByPattern({{0}}, {{1}})", strToSplit, pattern).ToList();
		}

		/// <param name="num1">Float</param>
		/// <param name="num2">Float</param>
		/// <returns>Scalar value from function</returns>
		public double? fnSumNumbers(
			double? num1, 
			double? num2)
		{
			return this.ExecuteList<double?>($@"select dbCalystoUnittest.fnSumNumbers({{0}}, {{1}})", num1, num2).First();
		}

		/// <param name="errorCode">Int</param>
		/// <param name="systemMessage">NVarChar(MAX)</param>
		/// <param name="customerMessage">NVarChar(MAX)</param>
		/// <returns>Scalar value from function</returns>
		public int? fnThrowErrorMessage(
			int? errorCode, 
			string systemMessage, 
			string customerMessage)
		{
			return this.ExecuteList<int?>($@"select dbCalystoUnittest.fnThrowErrorMessage({{0}}, {{1}}, {{2}})", errorCode, systemMessage, customerMessage).First();
		}

		/// <param name="diagramname">NVarChar(128)</param>
		/// <param name="owner_id">Int, DefaultValue = null</param>
		/// <param name="version">Int</param>
		/// <param name="definition">VarBinary(MAX)</param>
		/// <returns>MultipleResults from stored procedure</returns>
		public sp_alterdiagramMultipleResults sp_alterdiagram(
			string diagramname, 
			int? owner_id, 
			int? version, 
			byte[] definition)
		{
			var multiple_results_1 = this.ExecuteMultipleResults($@"declare @return_value int; 
					exec @return_value = dbCalystoUnittest.sp_alterdiagram {{0}}, {{1}}, {{2}}, {{3}}; 
					select @return_value as ReturnValue;", diagramname, owner_id, version, definition);
			var final_result_1 = multiple_results_1.ReadResults(res => new sp_alterdiagramMultipleResults()
			{
				ReturnValue = res.GetSequence<int>().Single(),
			});
			return final_result_1;
		}

		/// <param name="diagramname">NVarChar(128)</param>
		/// <param name="owner_id">Int, DefaultValue = null</param>
		/// <param name="version">Int</param>
		/// <param name="definition">VarBinary(MAX)</param>
		/// <returns>MultipleResults from stored procedure</returns>
		public sp_creatediagramMultipleResults sp_creatediagram(
			string diagramname, 
			int? owner_id, 
			int? version, 
			byte[] definition)
		{
			var multiple_results_1 = this.ExecuteMultipleResults($@"declare @return_value int; 
					exec @return_value = dbCalystoUnittest.sp_creatediagram {{0}}, {{1}}, {{2}}, {{3}}; 
					select @return_value as ReturnValue;", diagramname, owner_id, version, definition);
			var final_result_1 = multiple_results_1.ReadResults(res => new sp_creatediagramMultipleResults()
			{
				ReturnValue = res.GetSequence<int>().Single(),
			});
			return final_result_1;
		}

		/// <param name="diagramname">NVarChar(128)</param>
		/// <param name="owner_id">Int, DefaultValue = null</param>
		/// <returns>MultipleResults from stored procedure</returns>
		public sp_dropdiagramMultipleResults sp_dropdiagram(
			string diagramname, 
			int? owner_id = null)
		{
			var multiple_results_1 = this.ExecuteMultipleResults($@"declare @return_value int; 
					exec @return_value = dbCalystoUnittest.sp_dropdiagram {{0}}, {{1}}; 
					select @return_value as ReturnValue;", diagramname, owner_id);
			var final_result_1 = multiple_results_1.ReadResults(res => new sp_dropdiagramMultipleResults()
			{
				ReturnValue = res.GetSequence<int>().Single(),
			});
			return final_result_1;
		}

		/// <param name="diagramname">NVarChar(128)</param>
		/// <param name="owner_id">Int, DefaultValue = null</param>
		/// <returns>MultipleResults from stored procedure</returns>
		public sp_helpdiagramdefinitionMultipleResults sp_helpdiagramdefinition(
			string diagramname, 
			int? owner_id = null)
		{
			var multiple_results_1 = this.ExecuteMultipleResults($@"declare @return_value int; 
					exec @return_value = dbCalystoUnittest.sp_helpdiagramdefinition {{0}}, {{1}}; 
					select @return_value as ReturnValue;", diagramname, owner_id);
			var final_result_1 = multiple_results_1.ReadResults(res => new sp_helpdiagramdefinitionMultipleResults()
			{
				Result1 = res.GetSequence<sp_helpdiagramdefinitionResult>().ToList(),
				ReturnValue = res.GetSequence<int>().Single(),
			});
			return final_result_1;
		}

		/// <param name="diagramname">NVarChar(128), DefaultValue = null</param>
		/// <param name="owner_id">Int, DefaultValue = null</param>
		/// <returns>MultipleResults from stored procedure</returns>
		public sp_helpdiagramsMultipleResults sp_helpdiagrams(
			string diagramname = null, 
			int? owner_id = null)
		{
			var multiple_results_1 = this.ExecuteMultipleResults($@"declare @return_value int; 
					exec @return_value = dbCalystoUnittest.sp_helpdiagrams {{0}}, {{1}}; 
					select @return_value as ReturnValue;", diagramname, owner_id);
			var final_result_1 = multiple_results_1.ReadResults(res => new sp_helpdiagramsMultipleResults()
			{
				Result1 = res.GetSequence<sp_helpdiagramsResult>().ToList(),
				ReturnValue = res.GetSequence<int>().Single(),
			});
			return final_result_1;
		}

		/// <param name="diagramname">NVarChar(128)</param>
		/// <param name="owner_id">Int, DefaultValue = null</param>
		/// <param name="new_diagramname">NVarChar(128)</param>
		/// <returns>MultipleResults from stored procedure</returns>
		public sp_renamediagramMultipleResults sp_renamediagram(
			string diagramname, 
			int? owner_id, 
			string new_diagramname)
		{
			var multiple_results_1 = this.ExecuteMultipleResults($@"declare @return_value int; 
					exec @return_value = dbCalystoUnittest.sp_renamediagram {{0}}, {{1}}, {{2}}; 
					select @return_value as ReturnValue;", diagramname, owner_id, new_diagramname);
			var final_result_1 = multiple_results_1.ReadResults(res => new sp_renamediagramMultipleResults()
			{
				ReturnValue = res.GetSequence<int>().Single(),
			});
			return final_result_1;
		}

		/// <param name="skip">Int, DefaultValue = (int)(0)</param>
		/// <param name="take">Int, DefaultValue = (int)(100)</param>
		/// <param name="totalCount">Int, DefaultValue = null</param>
		/// <returns>MultipleResults from stored procedure</returns>
		public spGetAppMembersMultipleResults spGetAppMembers(
			int? skip, 
			int? take, 
			ref int? totalCount)
		{
			var multiple_results_1 = this.ExecuteMultipleResults($@"declare @return_value int; 
					exec @return_value = dbCalystoUnittest.spGetAppMembers {{0}}, {{1}}, {{2}} out; 
					select @return_value as ReturnValue;", skip, take, totalCount);
			var final_result_1 = multiple_results_1.ReadResults(res => new spGetAppMembersMultipleResults()
			{
				Result1 = res.GetSequence<spGetAppMembersResult1>().ToList(),
				Result2 = res.GetSequence<spGetAppMembersResult2>().ToList(),
				ReturnValue = res.GetSequence<int>().Single(),
			});
			// read Output parameter from stored procedure
			totalCount = Calysto.Utility.CalystoTypeConverter.ChangeType<int?>(multiple_results_1.Command.Parameters[2].Value);
			return final_result_1;
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
					exec @return_value = dbCalystoUnittest.spMultiResults {{0}}, {{1}}, {{2}} out; 
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
					exec @return_value = dbCalystoUnittest.spMultiResults2; 
					select @return_value as ReturnValue;");
			var final_result_1 = multiple_results_1.ReadResults(res => new spMultiResults2MultipleResults()
			{
				Result1 = res.GetSequence<spMultiResults2Result1>().ToList(),
				Result2 = res.GetSequence<spMultiResults2Result2>().ToList(),
				Result3 = res.GetSequence<spMultiResults2Result1>().ToList(),
				Result4 = res.GetSequence<spMultiResults2Result2>().ToList(),
				ReturnValue = res.GetSequence<int>().Single(),
			});
			return final_result_1;
		}

		/// <returns>MultipleResults from stored procedure</returns>
		public spNoTablesResultsMultipleResults spNoTablesResults()
		{
			var multiple_results_1 = this.ExecuteMultipleResults($@"declare @return_value int; 
					exec @return_value = dbCalystoUnittest.spNoTablesResults; 
					select @return_value as ReturnValue;");
			var final_result_1 = multiple_results_1.ReadResults(res => new spNoTablesResultsMultipleResults()
			{
				ReturnValue = res.GetSequence<int>().Single(),
			});
			return final_result_1;
		}

		/// <param name="total">Int</param>
		/// <returns>MultipleResults from stored procedure</returns>
		public spNoTablesResults2MultipleResults spNoTablesResults2(ref int? total)
		{
			var multiple_results_1 = this.ExecuteMultipleResults($@"declare @return_value int; 
					exec @return_value = dbCalystoUnittest.spNoTablesResults2 {{0}} out; 
					select @return_value as ReturnValue;", total);
			var final_result_1 = multiple_results_1.ReadResults(res => new spNoTablesResults2MultipleResults()
			{
				ReturnValue = res.GetSequence<int>().Single(),
			});
			// read Output parameter from stored procedure
			total = Calysto.Utility.CalystoTypeConverter.ChangeType<int?>(multiple_results_1.Command.Parameters[0].Value);
			return final_result_1;
		}

		/// <returns>MultipleResults from stored procedure</returns>
		public spRandomNumberMultipleResults spRandomNumber()
		{
			var multiple_results_1 = this.ExecuteMultipleResults($@"declare @return_value int; 
					exec @return_value = dbCalystoUnittest.spRandomNumber; 
					select @return_value as ReturnValue;");
			var final_result_1 = multiple_results_1.ReadResults(res => new spRandomNumberMultipleResults()
			{
				Result1 = res.GetSequence<spRandomNumberResult>().ToList(),
				ReturnValue = res.GetSequence<int>().Single(),
			});
			return final_result_1;
		}

		/// <param name="updateAll">TinyInt(1), DefaultValue = false</param>
		/// <param name="skip">Int, DefaultValue = (int)(0)</param>
		/// <param name="take">Int, DefaultValue = (int)(100)</param>
		/// <returns>MultipleResults from stored procedure</returns>
		public spSpiderExtractVehicleModelMultipleResults spSpiderExtractVehicleModel(
			bool? updateAll = false, 
			int? skip = (int)(0), 
			int? take = (int)(100))
		{
			var multiple_results_1 = this.ExecuteMultipleResults($@"declare @return_value int; 
					exec @return_value = dbCalystoUnittest.spSpiderExtractVehicleModel {{0}}, {{1}}, {{2}}; 
					select @return_value as ReturnValue;", updateAll, skip, take);
			var final_result_1 = multiple_results_1.ReadResults(res => new spSpiderExtractVehicleModelMultipleResults()
			{
				ReturnValue = res.GetSequence<int>().Single(),
			});
			return final_result_1;
		}

		/// <param name="doRebuild">Int, DefaultValue = (int)(1)</param>
		/// <param name="count">Int, DefaultValue = (int)(-1)</param>
		/// <returns>MultipleResults from stored procedure</returns>
		public spSysRebuildAllIndexesMultipleResults spSysRebuildAllIndexes(
			int? doRebuild, 
			ref int? count)
		{
			var multiple_results_1 = this.ExecuteMultipleResults($@"declare @return_value int; 
					exec @return_value = dbCalystoUnittest.spSysRebuildAllIndexes {{0}}, {{1}} out; 
					select @return_value as ReturnValue;", doRebuild, count);
			var final_result_1 = multiple_results_1.ReadResults(res => new spSysRebuildAllIndexesMultipleResults()
			{
				Result1 = res.GetSequence<spSysRebuildAllIndexesResult>().ToList(),
				ReturnValue = res.GetSequence<int>().Single(),
			});
			// read Output parameter from stored procedure
			count = Calysto.Utility.CalystoTypeConverter.ChangeType<int?>(multiple_results_1.Command.Parameters[1].Value);
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

			this.Map_tblAppMemberPermission(modelBuilder);
			this.Customize_tblAppMemberPermission(modelBuilder);

			this.Map_tblAppMemberPicture(modelBuilder);
			this.Customize_tblAppMemberPicture(modelBuilder);

			this.Map_tblAppMemberPicture2(modelBuilder);
			this.Customize_tblAppMemberPicture2(modelBuilder);

			this.Map_tblAppMemberStatus(modelBuilder);
			this.Customize_tblAppMemberStatus(modelBuilder);

			this.Map_tblAppMobileLog(modelBuilder);
			this.Customize_tblAppMobileLog(modelBuilder);

			this.Map_tblAppMobileLogKind(modelBuilder);
			this.Customize_tblAppMobileLogKind(modelBuilder);

			this.Map_tblAppNewsletter(modelBuilder);
			this.Customize_tblAppNewsletter(modelBuilder);

			this.Map_tblAppPermission(modelBuilder);
			this.Customize_tblAppPermission(modelBuilder);

			this.Map_tblMemberAddress(modelBuilder);
			this.Customize_tblMemberAddress(modelBuilder);

			this.Map_tblVehicle(modelBuilder);
			this.Customize_tblVehicle(modelBuilder);

			this.Map_tblVehicleOverview(modelBuilder);
			this.Customize_tblVehicleOverview(modelBuilder);

			this.Map_tblVehicleOverviewImage(modelBuilder);
			this.Customize_tblVehicleOverviewImage(modelBuilder);

			this.Map_tblVehicleRip(modelBuilder);
			this.Customize_tblVehicleRip(modelBuilder);

			this.Map_tblVehicleRipStatus(modelBuilder);
			this.Customize_tblVehicleRipStatus(modelBuilder);

			this.Map_viewRandom(modelBuilder);
			this.Customize_viewRandom(modelBuilder);

			RelationshipsMapping(modelBuilder);
			CustomizeMapping(ref modelBuilder);
		}

		#endregion

		#region TablesMappingDetails

		#region tblAppMember
		private void Map_tblAppMember(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<tblAppMember>().ToTable("tblAppMember", "dbCalystoUnittest");
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
			modelBuilder.Entity<tblAppMember>().Property(x=>x.IsQuizQuestionsEditor).HasColumnName("IsQuizQuestionsEditor").HasColumnType("TinyInt(1)").ValueGeneratedNever().HasMaxLength(1);
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
			modelBuilder.Entity<tblAppMember2>().ToTable("tblAppMember2", "dbCalystoUnittest");
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
			modelBuilder.Entity<tblAppMember2>().Property(x=>x.IsQuizQuestionsEditor).HasColumnName("IsQuizQuestionsEditor").HasColumnType("TinyInt(1)").ValueGeneratedNever().HasMaxLength(1);
		}

		partial void Customize_tblAppMember2(ModelBuilder modelBuilder);
		#endregion

		#region tblAppMemberPermission
		private void Map_tblAppMemberPermission(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<tblAppMemberPermission>().ToTable("tblAppMemberPermission", "dbCalystoUnittest");
			modelBuilder.Entity<tblAppMemberPermission>().HasKey(x=>x.AppPermissionID);
			modelBuilder.Entity<tblAppMemberPermission>().HasKey(x=>x.AppMemberID);
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
			modelBuilder.Entity<tblAppMemberPicture>().ToTable("tblAppMemberPicture", "dbCalystoUnittest");
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
			modelBuilder.Entity<tblAppMemberPicture2>().ToTable("tblAppMemberPicture2", "dbCalystoUnittest");
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
			modelBuilder.Entity<tblAppMemberStatus>().ToTable("tblAppMemberStatus", "dbCalystoUnittest");
			modelBuilder.Entity<tblAppMemberStatus>().HasKey(x=>x.AppMemberStatusID);
			modelBuilder.Entity<tblAppMemberStatus>().Property(x=>x.AppMemberStatusID).HasColumnName("AppMemberStatusID").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblAppMemberStatus>().Property(x=>x.IsActive).HasColumnName("IsActive").HasColumnType("TinyInt(1)").IsRequired().ValueGeneratedNever().HasMaxLength(1);
			modelBuilder.Entity<tblAppMemberStatus>().Property(x=>x.Name).HasColumnName("Name").HasColumnType("NVarChar(100)").ValueGeneratedNever().HasMaxLength(100);
			modelBuilder.Entity<tblAppMemberStatus>().Property(x=>x.Description).HasColumnName("Description").HasColumnType("NVarChar(500)").ValueGeneratedNever().HasMaxLength(500);
		}

		partial void Customize_tblAppMemberStatus(ModelBuilder modelBuilder);
		#endregion

		#region tblAppMobileLog
		private void Map_tblAppMobileLog(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<tblAppMobileLog>().ToTable("tblAppMobileLog", "dbCalystoUnittest");
			modelBuilder.Entity<tblAppMobileLog>().HasNoKey();
			modelBuilder.Entity<tblAppMobileLog>().Property(x=>x.ServerDate).HasColumnName("ServerDate").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblAppMobileLog>().Property(x=>x.MobileDate).HasColumnName("MobileDate").HasColumnType("DateTime").ValueGeneratedNever();
			modelBuilder.Entity<tblAppMobileLog>().Property(x=>x.IMEI).HasColumnName("IMEI").HasColumnType("VarChar(50)").ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<tblAppMobileLog>().Property(x=>x.MSISDN).HasColumnName("MSISDN").HasColumnType("VarChar(20)").ValueGeneratedNever().HasMaxLength(20);
			modelBuilder.Entity<tblAppMobileLog>().Property(x=>x.AppMobileLogKindID).HasColumnName("AppMobileLogKindID").HasColumnType("Int").ValueGeneratedNever();
			modelBuilder.Entity<tblAppMobileLog>().Property(x=>x.AppMemberID).HasColumnName("AppMemberID").HasColumnType("Int").ValueGeneratedNever();
			modelBuilder.Entity<tblAppMobileLog>().Property(x=>x.CurrentUrl).HasColumnName("CurrentUrl").HasColumnType("VarChar(255)").ValueGeneratedNever().HasMaxLength(255);
			modelBuilder.Entity<tblAppMobileLog>().Property(x=>x.RemainingChargePercent).HasColumnName("RemainingChargePercent").HasColumnType("Int").ValueGeneratedNever();
			modelBuilder.Entity<tblAppMobileLog>().Property(x=>x.PowerSource).HasColumnName("PowerSource").HasColumnType("VarChar(50)").ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<tblAppMobileLog>().Property(x=>x.BatteryStatus).HasColumnName("BatteryStatus").HasColumnType("VarChar(50)").ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<tblAppMobileLog>().Property(x=>x.SubscriberId).HasColumnName("SubscriberId").HasColumnType("VarChar(50)").ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<tblAppMobileLog>().Property(x=>x.NetworkType).HasColumnName("NetworkType").HasColumnType("VarChar(50)").ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<tblAppMobileLog>().Property(x=>x.PhoneType).HasColumnName("PhoneType").HasColumnType("VarChar(50)").ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<tblAppMobileLog>().Property(x=>x.SimState).HasColumnName("SimState").HasColumnType("VarChar(50)").ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<tblAppMobileLog>().Property(x=>x.NetworkOperator).HasColumnName("NetworkOperator").HasColumnType("VarChar(50)").ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<tblAppMobileLog>().Property(x=>x.LocationDate).HasColumnName("LocationDate").HasColumnType("DateTime").ValueGeneratedNever();
			modelBuilder.Entity<tblAppMobileLog>().Property(x=>x.LocationError).HasColumnName("LocationError").HasColumnType("VarChar(200)").ValueGeneratedNever().HasMaxLength(200);
			modelBuilder.Entity<tblAppMobileLog>().Property(x=>x.Latitude).HasColumnName("Latitude").HasColumnType("Float").ValueGeneratedNever();
			modelBuilder.Entity<tblAppMobileLog>().Property(x=>x.Longitude).HasColumnName("Longitude").HasColumnType("Float").ValueGeneratedNever();
			modelBuilder.Entity<tblAppMobileLog>().Property(x=>x.AccuracyMeters).HasColumnName("AccuracyMeters").HasColumnType("Float").ValueGeneratedNever();
			modelBuilder.Entity<tblAppMobileLog>().Property(x=>x.Address).HasColumnName("Address").HasColumnType("NVarChar(200)").ValueGeneratedNever().HasMaxLength(200);
		}

		partial void Customize_tblAppMobileLog(ModelBuilder modelBuilder);
		#endregion

		#region tblAppMobileLogKind
		private void Map_tblAppMobileLogKind(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<tblAppMobileLogKind>().ToTable("tblAppMobileLogKind", "dbCalystoUnittest");
			modelBuilder.Entity<tblAppMobileLogKind>().HasKey(x=>x.AppMobileLogKindID);
			modelBuilder.Entity<tblAppMobileLogKind>().Property(x=>x.AppMobileLogKindID).HasColumnName("AppMobileLogKindID").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblAppMobileLogKind>().Property(x=>x.Name).HasColumnName("Name").HasColumnType("NVarChar(50)").IsRequired().ValueGeneratedNever().HasMaxLength(50);
		}

		partial void Customize_tblAppMobileLogKind(ModelBuilder modelBuilder);
		#endregion

		#region tblAppNewsletter
		private void Map_tblAppNewsletter(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<tblAppNewsletter>().ToTable("tblAppNewsletter", "dbCalystoUnittest");
			modelBuilder.Entity<tblAppNewsletter>().HasKey(x=>x.Email);
			modelBuilder.Entity<tblAppNewsletter>().Property(x=>x.Email).HasColumnName("Email").HasColumnType("VarChar(150)").IsRequired().ValueGeneratedNever().HasMaxLength(150);
			modelBuilder.Entity<tblAppNewsletter>().Property(x=>x.InsertionDate).HasColumnName("InsertionDate").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblAppNewsletter>().Property(x=>x.SubscribeDate).HasColumnName("SubscribeDate").HasColumnType("DateTime").ValueGeneratedNever();
			modelBuilder.Entity<tblAppNewsletter>().Property(x=>x.UnsubscribeDate).HasColumnName("UnsubscribeDate").HasColumnType("DateTime").ValueGeneratedNever();
			modelBuilder.Entity<tblAppNewsletter>().Property(x=>x.IsSubscribed).HasColumnName("IsSubscribed").HasColumnType("TinyInt(1)").IsRequired().ValueGeneratedNever().HasMaxLength(1);
		}

		partial void Customize_tblAppNewsletter(ModelBuilder modelBuilder);
		#endregion

		#region tblAppPermission
		private void Map_tblAppPermission(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<tblAppPermission>().ToTable("tblAppPermission", "dbCalystoUnittest");
			modelBuilder.Entity<tblAppPermission>().HasKey(x=>x.AppPermissionID);
			modelBuilder.Entity<tblAppPermission>().Property(x=>x.AppPermissionID).HasColumnName("AppPermissionID").HasColumnType("Int").IsRequired().ValueGeneratedOnAdd();
			modelBuilder.Entity<tblAppPermission>().Property(x=>x.IsActive).HasColumnName("IsActive").HasColumnType("TinyInt(1)").IsRequired().ValueGeneratedNever().HasMaxLength(1);
			modelBuilder.Entity<tblAppPermission>().Property(x=>x.Name).HasColumnName("Name").HasColumnType("NVarChar(100)").IsRequired().ValueGeneratedNever().HasMaxLength(100);
			modelBuilder.Entity<tblAppPermission>().Property(x=>x.Description).HasColumnName("Description").HasColumnType("NVarChar(500)").ValueGeneratedNever().HasMaxLength(500);
			modelBuilder.Entity<tblAppPermission>().Property(x=>x.GroupName).HasColumnName("GroupName").HasColumnType("NVarChar(50)").ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<tblAppPermission>().Property(x=>x.Ordinal).HasColumnName("Ordinal").HasColumnType("Int").ValueGeneratedNever();
		}

		partial void Customize_tblAppPermission(ModelBuilder modelBuilder);
		#endregion

		#region tblMemberAddress
		private void Map_tblMemberAddress(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<tblMemberAddress>().ToTable("tblMemberAddress", "dbCalystoUnittest");
			modelBuilder.Entity<tblMemberAddress>().HasKey(x=>x.MemberAddressID);
			modelBuilder.Entity<tblMemberAddress>().Property(x=>x.MemberAddressID).HasColumnName("MemberAddressID").HasColumnType("Int").IsRequired().ValueGeneratedOnAdd();
			modelBuilder.Entity<tblMemberAddress>().Property(x=>x.Street).HasColumnName("Street").HasColumnType("NChar(10)").ValueGeneratedNever().HasMaxLength(10);
			modelBuilder.Entity<tblMemberAddress>().Property(x=>x.City).HasColumnName("City").HasColumnType("NChar(10)").ValueGeneratedNever().HasMaxLength(10);
		}

		partial void Customize_tblMemberAddress(ModelBuilder modelBuilder);
		#endregion

		#region tblVehicle
		private void Map_tblVehicle(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<tblVehicle>().ToTable("tblVehicle", "dbCalystoUnittest");
			modelBuilder.Entity<tblVehicle>().HasKey(x=>x.VehicleID);
			modelBuilder.Entity<tblVehicle>().Property(x=>x.VehicleID).HasColumnName("VehicleID").HasColumnType("Int").IsRequired().ValueGeneratedOnAdd();
			modelBuilder.Entity<tblVehicle>().Property(x=>x.VehicleRipID).HasColumnName("VehicleRipID").HasColumnType("Int").IsRequired().ValueGeneratedNever();
		}

		partial void Customize_tblVehicle(ModelBuilder modelBuilder);
		#endregion

		#region tblVehicleOverview
		private void Map_tblVehicleOverview(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<tblVehicleOverview>().ToTable("tblVehicleOverview", "dbCalystoUnittest");
			modelBuilder.Entity<tblVehicleOverview>().HasKey(x=>x.VehicleRipID);
			modelBuilder.Entity<tblVehicleOverview>().Property(x=>x.VehicleRipID).HasColumnName("VehicleRipID").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblVehicleOverview>().Property(x=>x.LastUpdateDate).HasColumnName("LastUpdateDate").HasColumnType("DateTime").ValueGeneratedNever();
			modelBuilder.Entity<tblVehicleOverview>().Property(x=>x.countryCode).HasColumnName("countryCode").HasColumnType("VarChar(10)").ValueGeneratedNever().HasMaxLength(10);
			modelBuilder.Entity<tblVehicleOverview>().Property(x=>x.sourceCountry).HasColumnName("sourceCountry").HasColumnType("VarChar(10)").ValueGeneratedNever().HasMaxLength(10);
			modelBuilder.Entity<tblVehicleOverview>().Property(x=>x.locationLat).HasColumnName("locationLat").HasColumnType("Float").ValueGeneratedNever();
			modelBuilder.Entity<tblVehicleOverview>().Property(x=>x.locationLong).HasColumnName("locationLong").HasColumnType("Float").ValueGeneratedNever();
			modelBuilder.Entity<tblVehicleOverview>().Property(x=>x.multiRound).HasColumnName("multiRound").HasColumnType("TinyInt(1)").ValueGeneratedNever().HasMaxLength(1);
			modelBuilder.Entity<tblVehicleOverview>().Property(x=>x.hasPainPriceAgreement).HasColumnName("hasPainPriceAgreement").HasColumnType("TinyInt(1)").ValueGeneratedNever().HasMaxLength(1);
			modelBuilder.Entity<tblVehicleOverview>().Property(x=>x.bodyType).HasColumnName("bodyType").HasColumnType("VarChar(20)").ValueGeneratedNever().HasMaxLength(20);
			modelBuilder.Entity<tblVehicleOverview>().Property(x=>x.colour).HasColumnName("colour").HasColumnType("VarChar(20)").ValueGeneratedNever().HasMaxLength(20);
			modelBuilder.Entity<tblVehicleOverview>().Property(x=>x.doors).HasColumnName("doors").HasColumnType("Int").ValueGeneratedNever();
			modelBuilder.Entity<tblVehicleOverview>().Property(x=>x.firstRegistrationDate).HasColumnName("firstRegistrationDate").HasColumnType("DateTime").ValueGeneratedNever();
			modelBuilder.Entity<tblVehicleOverview>().Property(x=>x.fuelType).HasColumnName("fuelType").HasColumnType("VarChar(20)").ValueGeneratedNever().HasMaxLength(20);
			modelBuilder.Entity<tblVehicleOverview>().Property(x=>x.hp).HasColumnName("hp").HasColumnType("Int").ValueGeneratedNever();
			modelBuilder.Entity<tblVehicleOverview>().Property(x=>x.hasVideo).HasColumnName("hasVideo").HasColumnType("TinyInt(1)").ValueGeneratedNever().HasMaxLength(1);
			modelBuilder.Entity<tblVehicleOverview>().Property(x=>x.km).HasColumnName("km").HasColumnType("Int").ValueGeneratedNever();
			modelBuilder.Entity<tblVehicleOverview>().Property(x=>x.kw).HasColumnName("kw").HasColumnType("Int").ValueGeneratedNever();
			modelBuilder.Entity<tblVehicleOverview>().Property(x=>x.gearType).HasColumnName("gearType").HasColumnType("VarChar(20)").ValueGeneratedNever().HasMaxLength(20);
			modelBuilder.Entity<tblVehicleOverview>().Property(x=>x.stockNumber).HasColumnName("stockNumber").HasColumnType("VarChar(20)").ValueGeneratedNever().HasMaxLength(20);
			modelBuilder.Entity<tblVehicleOverview>().Property(x=>x.manufacturer).HasColumnName("manufacturer").HasColumnType("Int").ValueGeneratedNever();
			modelBuilder.Entity<tblVehicleOverview>().Property(x=>x.manufacturerName).HasColumnName("manufacturerName").HasColumnType("VarChar(50)").ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<tblVehicleOverview>().Property(x=>x.mainType).HasColumnName("mainType").HasColumnType("VarChar(50)").ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<tblVehicleOverview>().Property(x=>x.subType).HasColumnName("subType").HasColumnType("VarChar(50)").ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<tblVehicleOverview>().Property(x=>x.modelDescription).HasColumnName("modelDescription").HasColumnType("VarChar(100)").ValueGeneratedNever().HasMaxLength(100);
			modelBuilder.Entity<tblVehicleOverview>().Property(x=>x.isUnroadworthy).HasColumnName("isUnroadworthy").HasColumnType("TinyInt(1)").ValueGeneratedNever().HasMaxLength(1);
			modelBuilder.Entity<tblVehicleOverview>().Property(x=>x.emissionStandard).HasColumnName("emissionStandard").HasColumnType("VarChar(20)").ValueGeneratedNever().HasMaxLength(20);
			modelBuilder.Entity<tblVehicleOverview>().Property(x=>x.ac).HasColumnName("ac").HasColumnType("TinyInt(1)").ValueGeneratedNever().HasMaxLength(1);
			modelBuilder.Entity<tblVehicleOverview>().Property(x=>x.allWheelDrive).HasColumnName("allWheelDrive").HasColumnType("TinyInt(1)").ValueGeneratedNever().HasMaxLength(1);
			modelBuilder.Entity<tblVehicleOverview>().Property(x=>x.automatic).HasColumnName("automatic").HasColumnType("TinyInt(1)").ValueGeneratedNever().HasMaxLength(1);
			modelBuilder.Entity<tblVehicleOverview>().Property(x=>x.backupCamera).HasColumnName("backupCamera").HasColumnType("TinyInt(1)").ValueGeneratedNever().HasMaxLength(1);
			modelBuilder.Entity<tblVehicleOverview>().Property(x=>x.heatedSeats).HasColumnName("heatedSeats").HasColumnType("TinyInt(1)").ValueGeneratedNever().HasMaxLength(1);
			modelBuilder.Entity<tblVehicleOverview>().Property(x=>x.leather).HasColumnName("leather").HasColumnType("TinyInt(1)").ValueGeneratedNever().HasMaxLength(1);
			modelBuilder.Entity<tblVehicleOverview>().Property(x=>x.navigationSystem).HasColumnName("navigationSystem").HasColumnType("TinyInt(1)").ValueGeneratedNever().HasMaxLength(1);
			modelBuilder.Entity<tblVehicleOverview>().Property(x=>x.parkHeating).HasColumnName("parkHeating").HasColumnType("TinyInt(1)").ValueGeneratedNever().HasMaxLength(1);
			modelBuilder.Entity<tblVehicleOverview>().Property(x=>x.pdc).HasColumnName("pdc").HasColumnType("TinyInt(1)").ValueGeneratedNever().HasMaxLength(1);
			modelBuilder.Entity<tblVehicleOverview>().Property(x=>x.rearEntertainment).HasColumnName("rearEntertainment").HasColumnType("TinyInt(1)").ValueGeneratedNever().HasMaxLength(1);
			modelBuilder.Entity<tblVehicleOverview>().Property(x=>x.sunroof).HasColumnName("sunroof").HasColumnType("TinyInt(1)").ValueGeneratedNever().HasMaxLength(1);
			modelBuilder.Entity<tblVehicleOverview>().Property(x=>x.xenon).HasColumnName("xenon").HasColumnType("TinyInt(1)").ValueGeneratedNever().HasMaxLength(1);
			modelBuilder.Entity<tblVehicleOverview>().Property(x=>x.cashbackEligible).HasColumnName("cashbackEligible").HasColumnType("TinyInt(1)").ValueGeneratedNever().HasMaxLength(1);
			modelBuilder.Entity<tblVehicleOverview>().Property(x=>x.exportAdvantageAmount).HasColumnName("exportAdvantageAmount").HasColumnType("Float").ValueGeneratedNever();
			modelBuilder.Entity<tblVehicleOverview>().Property(x=>x.exportAdvantageEligible).HasColumnName("exportAdvantageEligible").HasColumnType("TinyInt(1)").ValueGeneratedNever().HasMaxLength(1);
			modelBuilder.Entity<tblVehicleOverview>().Property(x=>x.guaranteedSalesEligible).HasColumnName("guaranteedSalesEligible").HasColumnType("TinyInt(1)").ValueGeneratedNever().HasMaxLength(1);
			modelBuilder.Entity<tblVehicleOverview>().Property(x=>x.premiumHandlingEligible).HasColumnName("premiumHandlingEligible").HasColumnType("VarChar(50)").ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<tblVehicleOverview>().Property(x=>x.packageDealEligibleSince).HasColumnName("packageDealEligibleSince").HasColumnType("VarChar(50)").ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<tblVehicleOverview>().Property(x=>x.taxDeduction).HasColumnName("taxDeduction").HasColumnType("TinyInt(1)").ValueGeneratedNever().HasMaxLength(1);
			modelBuilder.Entity<tblVehicleOverview>().Property(x=>x.lastRun).HasColumnName("lastRun").HasColumnType("TinyInt(1)").ValueGeneratedNever().HasMaxLength(1);
			modelBuilder.Entity<tblVehicleOverview>().Property(x=>x.lrcCountry).HasColumnName("lrcCountry").HasColumnType("VarChar(50)").ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<tblVehicleOverview>().Property(x=>x.exportAdvantageType).HasColumnName("exportAdvantageType").HasColumnType("VarChar(20)").ValueGeneratedNever().HasMaxLength(20);
			modelBuilder.Entity<tblVehicleOverview>().Property(x=>x.exportAdvantageWarningType).HasColumnName("exportAdvantageWarningType").HasColumnType("VarChar(20)").ValueGeneratedNever().HasMaxLength(20);
			modelBuilder.Entity<tblVehicleOverview>().Property(x=>x.inspectionCompanyId).HasColumnName("inspectionCompanyId").HasColumnType("VarChar(20)").ValueGeneratedNever().HasMaxLength(20);
			modelBuilder.Entity<tblVehicleOverview>().Property(x=>x.inspectionReportPath).HasColumnName("inspectionReportPath").HasColumnType("VarChar(255)").ValueGeneratedNever().HasMaxLength(255);
			modelBuilder.Entity<tblVehicleOverview>().Property(x=>x.inspectionStatus).HasColumnName("inspectionStatus").HasColumnType("Int").ValueGeneratedNever();
			modelBuilder.Entity<tblVehicleOverview>().Property(x=>x.auctionDisplayChannelId).HasColumnName("auctionDisplayChannelId").HasColumnType("Int").ValueGeneratedNever();
			modelBuilder.Entity<tblVehicleOverview>().Property(x=>x.auctionStartDatetime).HasColumnName("auctionStartDatetime").HasColumnType("DateTime").ValueGeneratedNever();
			modelBuilder.Entity<tblVehicleOverview>().Property(x=>x.auctionEndDatetime).HasColumnName("auctionEndDatetime").HasColumnType("DateTime").ValueGeneratedNever();
			modelBuilder.Entity<tblVehicleOverview>().Property(x=>x.evaluationEnd).HasColumnName("evaluationEnd").HasColumnType("DateTime").ValueGeneratedNever();
			modelBuilder.Entity<tblVehicleOverview>().Property(x=>x.isInstantPurchaseOfferEnabled).HasColumnName("isInstantPurchaseOfferEnabled").HasColumnType("TinyInt(1)").ValueGeneratedNever().HasMaxLength(1);
			modelBuilder.Entity<tblVehicleOverview>().Property(x=>x.noBiddingEligible).HasColumnName("noBiddingEligible").HasColumnType("TinyInt(1)").ValueGeneratedNever().HasMaxLength(1);
			modelBuilder.Entity<tblVehicleOverview>().Property(x=>x.biddingStartDateTime).HasColumnName("biddingStartDateTime").HasColumnType("DateTime").ValueGeneratedNever();
			modelBuilder.Entity<tblVehicleOverview>().Property(x=>x.buyNowPrice).HasColumnName("buyNowPrice").HasColumnType("Float").ValueGeneratedNever();
			modelBuilder.Entity<tblVehicleOverview>().Property(x=>x.discount).HasColumnName("discount").HasColumnType("VarChar(20)").ValueGeneratedNever().HasMaxLength(20);
			modelBuilder.Entity<tblVehicleOverview>().Property(x=>x.expectedPriceDisplay).HasColumnName("expectedPriceDisplay").HasColumnType("VarChar(20)").ValueGeneratedNever().HasMaxLength(20);
			modelBuilder.Entity<tblVehicleOverview>().Property(x=>x.expectedPriceTarget).HasColumnName("expectedPriceTarget").HasColumnType("VarChar(20)").ValueGeneratedNever().HasMaxLength(20);
			modelBuilder.Entity<tblVehicleOverview>().Property(x=>x.minimumBid).HasColumnName("minimumBid").HasColumnType("Int").ValueGeneratedNever();
			modelBuilder.Entity<tblVehicleOverview>().Property(x=>x.mpPrice).HasColumnName("mpPrice").HasColumnType("Float").ValueGeneratedNever();
			modelBuilder.Entity<tblVehicleOverview>().Property(x=>x.percentOff).HasColumnName("percentOff").HasColumnType("Float").ValueGeneratedNever();
			modelBuilder.Entity<tblVehicleOverview>().Property(x=>x.priceWithoutDiscount).HasColumnName("priceWithoutDiscount").HasColumnType("Float").ValueGeneratedNever();
			modelBuilder.Entity<tblVehicleOverview>().Property(x=>x.searchPrice).HasColumnName("searchPrice").HasColumnType("Int").ValueGeneratedNever();
			modelBuilder.Entity<tblVehicleOverview>().Property(x=>x.lastTopBidValue).HasColumnName("lastTopBidValue").HasColumnType("Int").ValueGeneratedNever();
			modelBuilder.Entity<tblVehicleOverview>().Property(x=>x.lastRunSaving).HasColumnName("lastRunSaving").HasColumnType("Int").ValueGeneratedNever();
			modelBuilder.Entity<tblVehicleOverview>().Property(x=>x.isBuyNowEligible).HasColumnName("isBuyNowEligible").HasColumnType("TinyInt(1)").ValueGeneratedNever().HasMaxLength(1);
			modelBuilder.Entity<tblVehicleOverview>().Property(x=>x.reservePriceHidden).HasColumnName("reservePriceHidden").HasColumnType("TinyInt(1)").ValueGeneratedNever().HasMaxLength(1);
			modelBuilder.Entity<tblVehicleOverview>().Property(x=>x.customChannelUrl).HasColumnName("customChannelUrl").HasColumnType("VarChar(250)").ValueGeneratedNever().HasMaxLength(250);
			modelBuilder.Entity<tblVehicleOverview>().Property(x=>x.source).HasColumnName("source").HasColumnType("VarChar(50)").ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<tblVehicleOverview>().Property(x=>x.auctionSecLeft).HasColumnName("auctionSecLeft").HasColumnType("Int").ValueGeneratedNever();
			modelBuilder.Entity<tblVehicleOverview>().Property(x=>x.localReverseCharge).HasColumnName("localReverseCharge").HasColumnType("TinyInt(1)").ValueGeneratedNever().HasMaxLength(1);
			modelBuilder.Entity<tblVehicleOverview>().Property(x=>x.watchlisted).HasColumnName("watchlisted").HasColumnType("TinyInt(1)").ValueGeneratedNever().HasMaxLength(1);
			modelBuilder.Entity<tblVehicleOverview>().Property(x=>x.isInPackageDeal).HasColumnName("isInPackageDeal").HasColumnType("TinyInt(1)").ValueGeneratedNever().HasMaxLength(1);
			modelBuilder.Entity<tblVehicleOverview>().Property(x=>x.isPackageDealEligible).HasColumnName("isPackageDealEligible").HasColumnType("TinyInt(1)").ValueGeneratedNever().HasMaxLength(1);
			modelBuilder.Entity<tblVehicleOverview>().Property(x=>x.noBiddingWindowSecLeft).HasColumnName("noBiddingWindowSecLeft").HasColumnType("Int").ValueGeneratedNever();
			modelBuilder.Entity<tblVehicleOverview>().Property(x=>x.limitedTimeDiscount).HasColumnName("limitedTimeDiscount").HasColumnType("VarChar(20)").ValueGeneratedNever().HasMaxLength(20);
		}

		partial void Customize_tblVehicleOverview(ModelBuilder modelBuilder);
		#endregion

		#region tblVehicleOverviewImage
		private void Map_tblVehicleOverviewImage(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<tblVehicleOverviewImage>().ToTable("tblVehicleOverviewImage", "dbCalystoUnittest");
			modelBuilder.Entity<tblVehicleOverviewImage>().HasKey(x=>x.VehicleOverviewImageID);
			modelBuilder.Entity<tblVehicleOverviewImage>().Property(x=>x.VehicleOverviewImageID).HasColumnName("VehicleOverviewImageID").HasColumnType("Int").IsRequired().ValueGeneratedOnAdd();
			modelBuilder.Entity<tblVehicleOverviewImage>().Property(x=>x.VehicleRipID).HasColumnName("VehicleRipID").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblVehicleOverviewImage>().Property(x=>x.fullUrl).HasColumnName("fullUrl").HasColumnType("VarChar(250)").ValueGeneratedNever().HasMaxLength(250);
			modelBuilder.Entity<tblVehicleOverviewImage>().Property(x=>x.ImageDownloadDate).HasColumnName("ImageDownloadDate").HasColumnType("DateTime").ValueGeneratedNever();
		}

		partial void Customize_tblVehicleOverviewImage(ModelBuilder modelBuilder);
		#endregion

		#region tblVehicleRip
		private void Map_tblVehicleRip(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<tblVehicleRip>().ToTable("tblVehicleRip", "dbCalystoUnittest");
			modelBuilder.Entity<tblVehicleRip>().HasKey(x=>x.VehicleRipID);
			modelBuilder.Entity<tblVehicleRip>().Property(x=>x.VehicleRipID).HasColumnName("VehicleRipID").HasColumnType("Int").IsRequired().ValueGeneratedOnAdd();
			modelBuilder.Entity<tblVehicleRip>().Property(x=>x.AutoOneStockNumber).HasColumnName("AutoOneStockNumber").HasColumnType("VarChar(50)").ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<tblVehicleRip>().Property(x=>x.VehicleRipStatusID).HasColumnName("VehicleRipStatusID").HasColumnType("Int").ValueGeneratedNever();
			modelBuilder.Entity<tblVehicleRip>().Property(x=>x.LastUpdateDate).HasColumnName("LastUpdateDate").HasColumnType("DateTime").ValueGeneratedNever();
		}

		partial void Customize_tblVehicleRip(ModelBuilder modelBuilder);
		#endregion

		#region tblVehicleRipStatus
		private void Map_tblVehicleRipStatus(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<tblVehicleRipStatus>().ToTable("tblVehicleRipStatus", "dbCalystoUnittest");
			modelBuilder.Entity<tblVehicleRipStatus>().HasKey(x=>x.VehicleRipStatusID);
			modelBuilder.Entity<tblVehicleRipStatus>().Property(x=>x.VehicleRipStatusID).HasColumnName("VehicleRipStatusID").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblVehicleRipStatus>().Property(x=>x.Name).HasColumnName("Name").HasColumnType("NVarChar(50)").IsRequired().ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<tblVehicleRipStatus>().Property(x=>x.Description).HasColumnName("Description").HasColumnType("NVarChar(100)").ValueGeneratedNever().HasMaxLength(100);
			modelBuilder.Entity<tblVehicleRipStatus>().Property(x=>x.Color).HasColumnName("Color").HasColumnType("VarChar(20)").ValueGeneratedNever().HasMaxLength(20);
		}

		partial void Customize_tblVehicleRipStatus(ModelBuilder modelBuilder);
		#endregion

		#region viewRandom
		private void Map_viewRandom(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<viewRandom>().ToTable("viewRandom", "dbCalystoUnittest");
			modelBuilder.Entity<viewRandom>().HasNoKey();
			modelBuilder.Entity<viewRandom>().Property(x=>x.Random).HasColumnName("Random").HasColumnType("Float").ValueGeneratedNever();
		}

		partial void Customize_viewRandom(ModelBuilder modelBuilder);
		#endregion

		#endregion

		#region Relationships mapping
		private void RelationshipsMapping(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<tblAppMember>().HasOne(x=>x.tblAppMemberStatus).WithMany(x=>x.tblAppMemberList).IsRequired(true).HasForeignKey(x=>x.AppMemberStatusID);
			modelBuilder.Entity<tblAppMember>().HasMany(x=>x.tblAppMemberPermissionList).WithOne(x=>x.tblAppMember).IsRequired(true).HasForeignKey(x=>x.AppMemberID);
			modelBuilder.Entity<tblAppMember>().HasMany(x=>x.tblAppMemberPictureList).WithOne(x=>x.tblAppMember).OnDelete(DeleteBehavior.Cascade).IsRequired(false).HasForeignKey(x=>x.AppMemberID);
			modelBuilder.Entity<tblAppMember>().HasMany(x=>x.tblAppMemberPicture2List).WithOne(x=>x.tblAppMember).IsRequired(false).HasForeignKey(x=>x.AppMemberID);
			modelBuilder.Entity<tblAppMember>().HasOne(x=>x.HomeMemberAddress).WithMany(x=>x.HomeMemberAddressList).IsRequired(false).HasForeignKey(x=>x.HomeMemberAddressID);
			modelBuilder.Entity<tblAppMember>().HasOne(x=>x.PrimaryMemberAddress).WithMany(x=>x.PrimaryMemberAddressList).OnDelete(DeleteBehavior.SetNull).IsRequired(false).HasForeignKey(x=>x.PrimaryMemberAddressID);
			modelBuilder.Entity<tblAppMember>().HasOne(x=>x.WorkMemberAddress).WithMany(x=>x.WorkMemberAddressList).IsRequired(false).HasForeignKey(x=>x.WorkMemberAddressID);

			modelBuilder.Entity<tblAppMemberPermission>().HasOne(x=>x.tblAppMember).WithMany(x=>x.tblAppMemberPermissionList).IsRequired(true).HasForeignKey(x=>x.AppMemberID);
			modelBuilder.Entity<tblAppMemberPermission>().HasOne(x=>x.tblAppPermission).WithMany(x=>x.tblAppMemberPermissionList).IsRequired(true).HasForeignKey(x=>x.AppPermissionID);

			modelBuilder.Entity<tblAppMemberPicture>().HasOne(x=>x.tblAppMember).WithMany(x=>x.tblAppMemberPictureList).OnDelete(DeleteBehavior.Cascade).IsRequired(false).HasForeignKey(x=>x.AppMemberID);

			modelBuilder.Entity<tblAppMemberPicture2>().HasOne(x=>x.tblAppMember).WithMany(x=>x.tblAppMemberPicture2List).IsRequired(false).HasForeignKey(x=>x.AppMemberID);

			modelBuilder.Entity<tblAppMemberStatus>().HasMany(x=>x.tblAppMemberList).WithOne(x=>x.tblAppMemberStatus).IsRequired(true).HasForeignKey(x=>x.AppMemberStatusID);

			modelBuilder.Entity<tblAppPermission>().HasMany(x=>x.tblAppMemberPermissionList).WithOne(x=>x.tblAppPermission).IsRequired(true).HasForeignKey(x=>x.AppPermissionID);

			modelBuilder.Entity<tblMemberAddress>().HasMany(x=>x.HomeMemberAddressList).WithOne(x=>x.HomeMemberAddress).IsRequired(false).HasForeignKey(x=>x.HomeMemberAddressID);
			modelBuilder.Entity<tblMemberAddress>().HasMany(x=>x.PrimaryMemberAddressList).WithOne(x=>x.PrimaryMemberAddress).OnDelete(DeleteBehavior.SetNull).IsRequired(false).HasForeignKey(x=>x.PrimaryMemberAddressID);
			modelBuilder.Entity<tblMemberAddress>().HasMany(x=>x.WorkMemberAddressList).WithOne(x=>x.WorkMemberAddress).IsRequired(false).HasForeignKey(x=>x.WorkMemberAddressID);

			modelBuilder.Entity<tblVehicle>().HasOne(x=>x.tblVehicleRip).WithMany(x=>x.tblVehicleList).IsRequired(true).HasForeignKey(x=>x.VehicleRipID);

			modelBuilder.Entity<tblVehicleOverview>().HasOne(x=>x.tblVehicleRip).WithOne(x=>x.tblVehicleOverview).IsRequired(true).HasForeignKey<tblVehicleOverview>(x=>x.VehicleRipID);
			modelBuilder.Entity<tblVehicleOverview>().HasMany(x=>x.tblVehicleOverviewImageList).WithOne(x=>x.tblVehicleOverview).IsRequired(true).HasForeignKey(x=>x.VehicleRipID);

			modelBuilder.Entity<tblVehicleOverviewImage>().HasOne(x=>x.tblVehicleOverview).WithMany(x=>x.tblVehicleOverviewImageList).IsRequired(true).HasForeignKey(x=>x.VehicleRipID);

			modelBuilder.Entity<tblVehicleRip>().HasMany(x=>x.tblVehicleList).WithOne(x=>x.tblVehicleRip).IsRequired(true).HasForeignKey(x=>x.VehicleRipID);
			modelBuilder.Entity<tblVehicleRip>().HasOne(x=>x.tblVehicleOverview).WithOne(x=>x.tblVehicleRip).IsRequired(true).HasForeignKey<tblVehicleOverview>(x=>x.VehicleRipID);
			modelBuilder.Entity<tblVehicleRip>().HasOne(x=>x.tblVehicleRipStatus).WithMany(x=>x.tblVehicleRipList).IsRequired(false).HasForeignKey(x=>x.VehicleRipStatusID);

			modelBuilder.Entity<tblVehicleRipStatus>().HasMany(x=>x.tblVehicleRipList).WithOne(x=>x.tblVehicleRipStatus).IsRequired(false).HasForeignKey(x=>x.VehicleRipStatusID);

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
		/// DbType = "TinyInt(1)", DefaultValue = true
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

		/// <summary>
		/// Association <br/>
		/// [FK][Many]tblAppMember.HomeMemberAddressID --- [PK][One]tblMemberAddress.MemberAddressID <br/>
		/// </summary>
		public virtual tblMemberAddress HomeMemberAddress { get; set; }

		/// <summary>
		/// Association <br/>
		/// [FK][Many]tblAppMember.PrimaryMemberAddressID --- [PK][One]tblMemberAddress.MemberAddressID <br/>
		/// </summary>
		public virtual tblMemberAddress PrimaryMemberAddress { get; set; }

		/// <summary>
		/// Association <br/>
		/// [FK][Many]tblAppMember.WorkMemberAddressID --- [PK][One]tblMemberAddress.MemberAddressID <br/>
		/// </summary>
		public virtual tblMemberAddress WorkMemberAddress { get; set; }
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
		/// DbType = "TinyInt(1)"
		/// </summary>
		public bool? IsQuizQuestionsEditor { get; set; }

		#endregion Columns

		#region Associations
		#endregion Associations

		partial void OnCreated();
	}
	#endregion dbo.tblAppMember2

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

		/// <summary>
		/// Association <br/>
		/// [FK][Many]tblAppMemberPermission.AppPermissionID --- [PK][One]tblAppPermission.AppPermissionID <br/>
		/// </summary>
		public virtual tblAppPermission tblAppPermission { get; set; }
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
		/// DbType = "TinyInt(1) NOT NULL", DefaultValue = false
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

	#region dbo.tblAppMobileLog
	public partial class tblAppMobileLog : EFCoreEntityBase<tblAppMobileLog>
	{
		public tblAppMobileLog()
		{
			OnCreated();
		}

		public tblAppMobileLog(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "DateTime NOT NULL"
		/// </summary>
		public DateTime ServerDate { get; set; }

		/// <summary>
		/// DbType = "DateTime"
		/// </summary>
		public DateTime? MobileDate { get; set; }

		/// <summary>
		/// DbType = "VarChar(50)"
		/// </summary>
		public string IMEI { get; set; }

		/// <summary>
		/// DbType = "VarChar(20)"
		/// </summary>
		public string MSISDN { get; set; }

		/// <summary>
		/// DbType = "Int"
		/// </summary>
		public int? AppMobileLogKindID { get; set; }

		/// <summary>
		/// DbType = "Int"
		/// </summary>
		public int? AppMemberID { get; set; }

		/// <summary>
		/// DbType = "VarChar(255)"
		/// </summary>
		public string CurrentUrl { get; set; }

		/// <summary>
		/// DbType = "Int"
		/// </summary>
		public int? RemainingChargePercent { get; set; }

		/// <summary>
		/// DbType = "VarChar(50)"
		/// </summary>
		public string PowerSource { get; set; }

		/// <summary>
		/// DbType = "VarChar(50)"
		/// </summary>
		public string BatteryStatus { get; set; }

		/// <summary>
		/// DbType = "VarChar(50)"
		/// </summary>
		public string SubscriberId { get; set; }

		/// <summary>
		/// DbType = "VarChar(50)"
		/// </summary>
		public string NetworkType { get; set; }

		/// <summary>
		/// DbType = "VarChar(50)"
		/// </summary>
		public string PhoneType { get; set; }

		/// <summary>
		/// DbType = "VarChar(50)"
		/// </summary>
		public string SimState { get; set; }

		/// <summary>
		/// DbType = "VarChar(50)"
		/// </summary>
		public string NetworkOperator { get; set; }

		/// <summary>
		/// DbType = "DateTime"
		/// </summary>
		public DateTime? LocationDate { get; set; }

		/// <summary>
		/// DbType = "VarChar(200)"
		/// </summary>
		public string LocationError { get; set; }

		/// <summary>
		/// DbType = "Float"
		/// </summary>
		public double? Latitude { get; set; }

		/// <summary>
		/// DbType = "Float"
		/// </summary>
		public double? Longitude { get; set; }

		/// <summary>
		/// DbType = "Float"
		/// </summary>
		public double? AccuracyMeters { get; set; }

		/// <summary>
		/// DbType = "NVarChar(200)"
		/// </summary>
		public string Address { get; set; }

		#endregion Columns

		#region Associations
		#endregion Associations

		partial void OnCreated();
	}
	#endregion dbo.tblAppMobileLog

	#region dbo.tblAppMobileLogKind
	public partial class tblAppMobileLogKind : EFCoreEntityBase<tblAppMobileLogKind>
	{
		public tblAppMobileLogKind()
		{
			OnCreated();
		}

		public tblAppMobileLogKind(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "Int NOT NULL", IsPrimaryKey = true
		/// </summary>
		public int AppMobileLogKindID { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50) NOT NULL"
		/// </summary>
		public string Name { get; set; }

		#endregion Columns

		#region Associations
		#endregion Associations

		partial void OnCreated();
	}
	#endregion dbo.tblAppMobileLogKind

	#region dbo.tblAppNewsletter
	public partial class tblAppNewsletter : EFCoreEntityBase<tblAppNewsletter>
	{
		public tblAppNewsletter()
		{
			OnCreated();
		}

		public tblAppNewsletter(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "VarChar(150) NOT NULL", IsPrimaryKey = true
		/// </summary>
		public string Email { get; set; }

		/// <summary>
		/// DbType = "DateTime NOT NULL"
		/// </summary>
		public DateTime InsertionDate { get; set; }

		/// <summary>
		/// DbType = "DateTime"
		/// </summary>
		public DateTime? SubscribeDate { get; set; }

		/// <summary>
		/// DbType = "DateTime"
		/// </summary>
		public DateTime? UnsubscribeDate { get; set; }

		/// <summary>
		/// DbType = "TinyInt(1) NOT NULL"
		/// </summary>
		public bool IsSubscribed { get; set; }

		#endregion Columns

		#region Associations
		#endregion Associations

		partial void OnCreated();
	}
	#endregion dbo.tblAppNewsletter

	#region dbo.tblAppPermission
	public partial class tblAppPermission : EFCoreEntityBase<tblAppPermission>
	{
		public tblAppPermission()
		{
			OnCreated();
		}

		public tblAppPermission(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert
		/// </summary>
		public int AppPermissionID { get; set; }

		/// <summary>
		/// DbType = "TinyInt(1) NOT NULL"
		/// </summary>
		public bool IsActive { get; set; }

		/// <summary>
		/// DbType = "NVarChar(100) NOT NULL"
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// DbType = "NVarChar(500)"
		/// </summary>
		public string Description { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50)"
		/// </summary>
		public string GroupName { get; set; }

		/// <summary>
		/// DbType = "Int"
		/// </summary>
		public int? Ordinal { get; set; }

		#endregion Columns

		#region Associations

		/// <summary>
		/// Association <br/>
		/// [PK][One]tblAppPermission.AppPermissionID --- [FK][Many]tblAppMemberPermission.AppPermissionID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<tblAppMemberPermission> tblAppMemberPermissionList { get; set; } = new List<tblAppMemberPermission>();
		#endregion Associations

		partial void OnCreated();
	}
	#endregion dbo.tblAppPermission

	#region dbo.tblMemberAddress
	public partial class tblMemberAddress : EFCoreEntityBase<tblMemberAddress>
	{
		public tblMemberAddress()
		{
			OnCreated();
		}

		public tblMemberAddress(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert
		/// </summary>
		public int MemberAddressID { get; set; }

		/// <summary>
		/// DbType = "NChar(10)"
		/// </summary>
		public string Street { get; set; }

		/// <summary>
		/// DbType = "NChar(10)"
		/// </summary>
		public string City { get; set; }

		#endregion Columns

		#region Associations

		/// <summary>
		/// Association <br/>
		/// [PK][One]tblMemberAddress.MemberAddressID --- [FK][Many]tblAppMember.HomeMemberAddressID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<tblAppMember> HomeMemberAddressList { get; set; } = new List<tblAppMember>();

		/// <summary>
		/// Association <br/>
		/// [PK][One]tblMemberAddress.MemberAddressID --- [FK][Many]tblAppMember.PrimaryMemberAddressID <br/>
		/// DeleteRule = SetNull <br/>
		/// </summary>
		public virtual List<tblAppMember> PrimaryMemberAddressList { get; set; } = new List<tblAppMember>();

		/// <summary>
		/// Association <br/>
		/// [PK][One]tblMemberAddress.MemberAddressID --- [FK][Many]tblAppMember.WorkMemberAddressID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<tblAppMember> WorkMemberAddressList { get; set; } = new List<tblAppMember>();
		#endregion Associations

		partial void OnCreated();
	}
	#endregion dbo.tblMemberAddress

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

		/// <summary>
		/// Association <br/>
		/// [FK][Many]tblVehicle.VehicleRipID --- [PK][One]tblVehicleRip.VehicleRipID <br/>
		/// </summary>
		public virtual tblVehicleRip tblVehicleRip { get; set; }
		#endregion Associations

		partial void OnCreated();
	}
	#endregion dbo.tblVehicle

	#region dbo.tblVehicleOverview
	public partial class tblVehicleOverview : EFCoreEntityBase<tblVehicleOverview>
	{
		public tblVehicleOverview()
		{
			OnCreated();
		}

		public tblVehicleOverview(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "Int NOT NULL", IsPrimaryKey = true
		/// </summary>
		public int VehicleRipID { get; set; }

		/// <summary>
		/// DbType = "DateTime"
		/// </summary>
		public DateTime? LastUpdateDate { get; set; }

		/// <summary>
		/// DbType = "VarChar(10)"
		/// </summary>
		public string countryCode { get; set; }

		/// <summary>
		/// DbType = "VarChar(10)"
		/// </summary>
		public string sourceCountry { get; set; }

		/// <summary>
		/// DbType = "Float"
		/// </summary>
		public double? locationLat { get; set; }

		/// <summary>
		/// DbType = "Float"
		/// </summary>
		public double? locationLong { get; set; }

		/// <summary>
		/// DbType = "TinyInt(1)"
		/// </summary>
		public bool? multiRound { get; set; }

		/// <summary>
		/// DbType = "TinyInt(1)"
		/// </summary>
		public bool? hasPainPriceAgreement { get; set; }

		/// <summary>
		/// DbType = "VarChar(20)"
		/// </summary>
		public string bodyType { get; set; }

		/// <summary>
		/// DbType = "VarChar(20)"
		/// </summary>
		public string colour { get; set; }

		/// <summary>
		/// DbType = "Int"
		/// </summary>
		public int? doors { get; set; }

		/// <summary>
		/// DbType = "DateTime"
		/// </summary>
		public DateTime? firstRegistrationDate { get; set; }

		/// <summary>
		/// DbType = "VarChar(20)"
		/// </summary>
		public string fuelType { get; set; }

		/// <summary>
		/// DbType = "Int"
		/// </summary>
		public int? hp { get; set; }

		/// <summary>
		/// DbType = "TinyInt(1)"
		/// </summary>
		public bool? hasVideo { get; set; }

		/// <summary>
		/// DbType = "Int"
		/// </summary>
		public int? km { get; set; }

		/// <summary>
		/// DbType = "Int"
		/// </summary>
		public int? kw { get; set; }

		/// <summary>
		/// DbType = "VarChar(20)"
		/// </summary>
		public string gearType { get; set; }

		/// <summary>
		/// DbType = "VarChar(20)"
		/// </summary>
		public string stockNumber { get; set; }

		/// <summary>
		/// DbType = "Int"
		/// </summary>
		public int? manufacturer { get; set; }

		/// <summary>
		/// DbType = "VarChar(50)"
		/// </summary>
		public string manufacturerName { get; set; }

		/// <summary>
		/// DbType = "VarChar(50)"
		/// </summary>
		public string mainType { get; set; }

		/// <summary>
		/// DbType = "VarChar(50)"
		/// </summary>
		public string subType { get; set; }

		/// <summary>
		/// DbType = "VarChar(100)"
		/// </summary>
		public string modelDescription { get; set; }

		/// <summary>
		/// DbType = "TinyInt(1)"
		/// </summary>
		public bool? isUnroadworthy { get; set; }

		/// <summary>
		/// DbType = "VarChar(20)"
		/// </summary>
		public string emissionStandard { get; set; }

		/// <summary>
		/// DbType = "TinyInt(1)"
		/// </summary>
		public bool? ac { get; set; }

		/// <summary>
		/// DbType = "TinyInt(1)"
		/// </summary>
		public bool? allWheelDrive { get; set; }

		/// <summary>
		/// DbType = "TinyInt(1)"
		/// </summary>
		public bool? automatic { get; set; }

		/// <summary>
		/// DbType = "TinyInt(1)"
		/// </summary>
		public bool? backupCamera { get; set; }

		/// <summary>
		/// DbType = "TinyInt(1)"
		/// </summary>
		public bool? heatedSeats { get; set; }

		/// <summary>
		/// DbType = "TinyInt(1)"
		/// </summary>
		public bool? leather { get; set; }

		/// <summary>
		/// DbType = "TinyInt(1)"
		/// </summary>
		public bool? navigationSystem { get; set; }

		/// <summary>
		/// DbType = "TinyInt(1)"
		/// </summary>
		public bool? parkHeating { get; set; }

		/// <summary>
		/// DbType = "TinyInt(1)"
		/// </summary>
		public bool? pdc { get; set; }

		/// <summary>
		/// DbType = "TinyInt(1)"
		/// </summary>
		public bool? rearEntertainment { get; set; }

		/// <summary>
		/// DbType = "TinyInt(1)"
		/// </summary>
		public bool? sunroof { get; set; }

		/// <summary>
		/// DbType = "TinyInt(1)"
		/// </summary>
		public bool? xenon { get; set; }

		/// <summary>
		/// DbType = "TinyInt(1)"
		/// </summary>
		public bool? cashbackEligible { get; set; }

		/// <summary>
		/// DbType = "Float"
		/// </summary>
		public double? exportAdvantageAmount { get; set; }

		/// <summary>
		/// DbType = "TinyInt(1)"
		/// </summary>
		public bool? exportAdvantageEligible { get; set; }

		/// <summary>
		/// DbType = "TinyInt(1)"
		/// </summary>
		public bool? guaranteedSalesEligible { get; set; }

		/// <summary>
		/// DbType = "VarChar(50)"
		/// </summary>
		public string premiumHandlingEligible { get; set; }

		/// <summary>
		/// DbType = "VarChar(50)"
		/// </summary>
		public string packageDealEligibleSince { get; set; }

		/// <summary>
		/// DbType = "TinyInt(1)"
		/// </summary>
		public bool? taxDeduction { get; set; }

		/// <summary>
		/// DbType = "TinyInt(1)"
		/// </summary>
		public bool? lastRun { get; set; }

		/// <summary>
		/// DbType = "VarChar(50)"
		/// </summary>
		public string lrcCountry { get; set; }

		/// <summary>
		/// DbType = "VarChar(20)"
		/// </summary>
		public string exportAdvantageType { get; set; }

		/// <summary>
		/// DbType = "VarChar(20)"
		/// </summary>
		public string exportAdvantageWarningType { get; set; }

		/// <summary>
		/// DbType = "VarChar(20)"
		/// </summary>
		public string inspectionCompanyId { get; set; }

		/// <summary>
		/// DbType = "VarChar(255)"
		/// </summary>
		public string inspectionReportPath { get; set; }

		/// <summary>
		/// DbType = "Int"
		/// </summary>
		public int? inspectionStatus { get; set; }

		/// <summary>
		/// DbType = "Int"
		/// </summary>
		public int? auctionDisplayChannelId { get; set; }

		/// <summary>
		/// DbType = "DateTime"
		/// </summary>
		public DateTime? auctionStartDatetime { get; set; }

		/// <summary>
		/// DbType = "DateTime"
		/// </summary>
		public DateTime? auctionEndDatetime { get; set; }

		/// <summary>
		/// DbType = "DateTime"
		/// </summary>
		public DateTime? evaluationEnd { get; set; }

		/// <summary>
		/// DbType = "TinyInt(1)"
		/// </summary>
		public bool? isInstantPurchaseOfferEnabled { get; set; }

		/// <summary>
		/// DbType = "TinyInt(1)"
		/// </summary>
		public bool? noBiddingEligible { get; set; }

		/// <summary>
		/// DbType = "DateTime"
		/// </summary>
		public DateTime? biddingStartDateTime { get; set; }

		/// <summary>
		/// DbType = "Float"
		/// </summary>
		public double? buyNowPrice { get; set; }

		/// <summary>
		/// DbType = "VarChar(20)"
		/// </summary>
		public string discount { get; set; }

		/// <summary>
		/// DbType = "VarChar(20)"
		/// </summary>
		public string expectedPriceDisplay { get; set; }

		/// <summary>
		/// DbType = "VarChar(20)"
		/// </summary>
		public string expectedPriceTarget { get; set; }

		/// <summary>
		/// DbType = "Int"
		/// </summary>
		public int? minimumBid { get; set; }

		/// <summary>
		/// DbType = "Float"
		/// </summary>
		public double? mpPrice { get; set; }

		/// <summary>
		/// DbType = "Float"
		/// </summary>
		public double? percentOff { get; set; }

		/// <summary>
		/// DbType = "Float"
		/// </summary>
		public double? priceWithoutDiscount { get; set; }

		/// <summary>
		/// DbType = "Int"
		/// </summary>
		public int? searchPrice { get; set; }

		/// <summary>
		/// DbType = "Int"
		/// </summary>
		public int? lastTopBidValue { get; set; }

		/// <summary>
		/// DbType = "Int"
		/// </summary>
		public int? lastRunSaving { get; set; }

		/// <summary>
		/// DbType = "TinyInt(1)"
		/// </summary>
		public bool? isBuyNowEligible { get; set; }

		/// <summary>
		/// DbType = "TinyInt(1)"
		/// </summary>
		public bool? reservePriceHidden { get; set; }

		/// <summary>
		/// DbType = "VarChar(250)"
		/// </summary>
		public string customChannelUrl { get; set; }

		/// <summary>
		/// DbType = "VarChar(50)"
		/// </summary>
		public string source { get; set; }

		/// <summary>
		/// DbType = "Int"
		/// </summary>
		public int? auctionSecLeft { get; set; }

		/// <summary>
		/// DbType = "TinyInt(1)"
		/// </summary>
		public bool? localReverseCharge { get; set; }

		/// <summary>
		/// DbType = "TinyInt(1)"
		/// </summary>
		public bool? watchlisted { get; set; }

		/// <summary>
		/// DbType = "TinyInt(1)"
		/// </summary>
		public bool? isInPackageDeal { get; set; }

		/// <summary>
		/// DbType = "TinyInt(1)"
		/// </summary>
		public bool? isPackageDealEligible { get; set; }

		/// <summary>
		/// DbType = "Int"
		/// </summary>
		public int? noBiddingWindowSecLeft { get; set; }

		/// <summary>
		/// DbType = "VarChar(20)"
		/// </summary>
		public string limitedTimeDiscount { get; set; }

		#endregion Columns

		#region Associations

		/// <summary>
		/// Association <br/>
		/// [FK][One]tblVehicleOverview.VehicleRipID --- [PK][One]tblVehicleRip.VehicleRipID <br/>
		/// </summary>
		public virtual tblVehicleRip tblVehicleRip { get; set; }

		/// <summary>
		/// Association <br/>
		/// [PK][One]tblVehicleOverview.VehicleRipID --- [FK][Many]tblVehicleOverviewImage.VehicleRipID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<tblVehicleOverviewImage> tblVehicleOverviewImageList { get; set; } = new List<tblVehicleOverviewImage>();
		#endregion Associations

		partial void OnCreated();
	}
	#endregion dbo.tblVehicleOverview

	#region dbo.tblVehicleOverviewImage
	public partial class tblVehicleOverviewImage : EFCoreEntityBase<tblVehicleOverviewImage>
	{
		public tblVehicleOverviewImage()
		{
			OnCreated();
		}

		public tblVehicleOverviewImage(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert
		/// </summary>
		public int VehicleOverviewImageID { get; set; }

		/// <summary>
		/// DbType = "Int NOT NULL"
		/// </summary>
		public int VehicleRipID { get; set; }

		/// <summary>
		/// DbType = "VarChar(250)"
		/// </summary>
		public string fullUrl { get; set; }

		/// <summary>
		/// DbType = "DateTime"
		/// </summary>
		public DateTime? ImageDownloadDate { get; set; }

		#endregion Columns

		#region Associations

		/// <summary>
		/// Association <br/>
		/// [FK][Many]tblVehicleOverviewImage.VehicleRipID --- [PK][One]tblVehicleOverview.VehicleRipID <br/>
		/// </summary>
		public virtual tblVehicleOverview tblVehicleOverview { get; set; }
		#endregion Associations

		partial void OnCreated();
	}
	#endregion dbo.tblVehicleOverviewImage

	#region dbo.tblVehicleRip
	public partial class tblVehicleRip : EFCoreEntityBase<tblVehicleRip>
	{
		public tblVehicleRip()
		{
			OnCreated();
		}

		public tblVehicleRip(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert
		/// </summary>
		public int VehicleRipID { get; set; }

		/// <summary>
		/// DbType = "VarChar(50)"
		/// </summary>
		public string AutoOneStockNumber { get; set; }

		/// <summary>
		/// DbType = "Int"
		/// </summary>
		public int? VehicleRipStatusID { get; set; }

		/// <summary>
		/// DbType = "DateTime"
		/// </summary>
		public DateTime? LastUpdateDate { get; set; }

		#endregion Columns

		#region Associations

		/// <summary>
		/// Association <br/>
		/// [PK][One]tblVehicleRip.VehicleRipID --- [FK][Many]tblVehicle.VehicleRipID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<tblVehicle> tblVehicleList { get; set; } = new List<tblVehicle>();

		/// <summary>
		/// Association <br/>
		/// [PK][One]tblVehicleRip.VehicleRipID --- [FK][One]tblVehicleOverview.VehicleRipID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual tblVehicleOverview tblVehicleOverview { get; set; }

		/// <summary>
		/// Association <br/>
		/// [FK][Many]tblVehicleRip.VehicleRipStatusID --- [PK][One]tblVehicleRipStatus.VehicleRipStatusID <br/>
		/// </summary>
		public virtual tblVehicleRipStatus tblVehicleRipStatus { get; set; }
		#endregion Associations

		partial void OnCreated();
	}
	#endregion dbo.tblVehicleRip

	#region dbo.tblVehicleRipStatus
	public partial class tblVehicleRipStatus : EFCoreEntityBase<tblVehicleRipStatus>
	{
		public tblVehicleRipStatus()
		{
			OnCreated();
		}

		public tblVehicleRipStatus(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "Int NOT NULL", IsPrimaryKey = true
		/// </summary>
		public int VehicleRipStatusID { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50) NOT NULL"
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// DbType = "NVarChar(100)"
		/// </summary>
		public string Description { get; set; }

		/// <summary>
		/// DbType = "VarChar(20)"
		/// </summary>
		public string Color { get; set; }

		#endregion Columns

		#region Associations

		/// <summary>
		/// Association <br/>
		/// [PK][One]tblVehicleRipStatus.VehicleRipStatusID --- [FK][Many]tblVehicleRip.VehicleRipStatusID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<tblVehicleRip> tblVehicleRipList { get; set; } = new List<tblVehicleRip>();
		#endregion Associations

		partial void OnCreated();
	}
	#endregion dbo.tblVehicleRipStatus

	#region dbo.viewRandom
	public partial class viewRandom : EFCoreEntityBase<viewRandom>
	{
		public viewRandom()
		{
			OnCreated();
		}

		public viewRandom(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "Float"
		/// </summary>
		public double? Random { get; set; }

		#endregion Columns

		#region Associations
		#endregion Associations

		partial void OnCreated();
	}
	#endregion dbo.viewRandom


	#endregion

	#region Functions Return types

	#region fnCalculateDatumValuteRokPlacanjaResult
	public partial class fnCalculateDatumValuteRokPlacanjaResult
	{
		public fnCalculateDatumValuteRokPlacanjaResult(){ }

		/// <summary>
		/// DbType = "DateTime NOT NULL"
		/// </summary>
		public DateTime DatumDokumenta { get; set; }

		/// <summary>
		/// DbType = "DateTime NOT NULL"
		/// </summary>
		public DateTime DatumValute { get; set; }

		/// <summary>
		/// DbType = "DateTime NOT NULL"
		/// </summary>
		public DateTime DatumDospijeca { get; set; }

	}
	#endregion fnCalculateDatumValuteRokPlacanjaResult

	#region fnConvertCsvArgsToIntTableResult
	public partial class fnConvertCsvArgsToIntTableResult
	{
		public fnConvertCsvArgsToIntTableResult(){ }

		/// <summary>
		/// DbType = "Int NOT NULL"
		/// </summary>
		public int number { get; set; }

	}
	#endregion fnConvertCsvArgsToIntTableResult

	#region fnGetBankaValutaTecajResult
	public partial class fnGetBankaValutaTecajResult
	{
		public fnGetBankaValutaTecajResult(){ }

		/// <summary>
		/// DbType = "DateTime"
		/// </summary>
		public DateTime? Datum { get; set; }

		/// <summary>
		/// DbType = "VarChar(50)"
		/// </summary>
		public string Valuta { get; set; }

	}
	#endregion fnGetBankaValutaTecajResult

	#region fnGetStariNoviGranicaResult
	public partial class fnGetStariNoviGranicaResult
	{
		public fnGetStariNoviGranicaResult(){ }

		/// <summary>
		/// DbType = "DateTime NOT NULL"
		/// </summary>
		public DateTime StartDate { get; set; }

		/// <summary>
		/// DbType = "DateTime NOT NULL"
		/// </summary>
		public DateTime EndDate { get; set; }

	}
	#endregion fnGetStariNoviGranicaResult

	#region fnSplitStringByPatternResult
	public partial class fnSplitStringByPatternResult
	{
		public fnSplitStringByPatternResult(){ }

		/// <summary>
		/// DbType = "Int NOT NULL"
		/// </summary>
		public int position { get; set; }

		/// <summary>
		/// DbType = "VarChar(MAX)"
		/// </summary>
		public string part { get; set; }

	}
	#endregion fnSplitStringByPatternResult

	#region sp_alterdiagramMultipleResults
	public partial class sp_alterdiagramMultipleResults
	{
		public sp_alterdiagramMultipleResults(){ }

		public int ReturnValue { get; set; }

	}
	#endregion sp_alterdiagramMultipleResults

	#region sp_creatediagramMultipleResults
	public partial class sp_creatediagramMultipleResults
	{
		public sp_creatediagramMultipleResults(){ }

		public int ReturnValue { get; set; }

	}
	#endregion sp_creatediagramMultipleResults

	#region sp_dropdiagramMultipleResults
	public partial class sp_dropdiagramMultipleResults
	{
		public sp_dropdiagramMultipleResults(){ }

		public int ReturnValue { get; set; }

	}
	#endregion sp_dropdiagramMultipleResults

	#region sp_helpdiagramdefinitionMultipleResults
	public partial class sp_helpdiagramdefinitionMultipleResults
	{
		public sp_helpdiagramdefinitionMultipleResults(){ }

		public List<sp_helpdiagramdefinitionResult> Result1 { get; set; }

		public int ReturnValue { get; set; }

	}
	#endregion sp_helpdiagramdefinitionMultipleResults

	#region sp_helpdiagramsMultipleResults
	public partial class sp_helpdiagramsMultipleResults
	{
		public sp_helpdiagramsMultipleResults(){ }

		public List<sp_helpdiagramsResult> Result1 { get; set; }

		public int ReturnValue { get; set; }

	}
	#endregion sp_helpdiagramsMultipleResults

	#region sp_renamediagramMultipleResults
	public partial class sp_renamediagramMultipleResults
	{
		public sp_renamediagramMultipleResults(){ }

		public int ReturnValue { get; set; }

	}
	#endregion sp_renamediagramMultipleResults

	#region spGetAppMembersMultipleResults
	public partial class spGetAppMembersMultipleResults
	{
		public spGetAppMembersMultipleResults(){ }

		public List<spGetAppMembersResult1> Result1 { get; set; }

		public List<spGetAppMembersResult2> Result2 { get; set; }

		public int ReturnValue { get; set; }

	}
	#endregion spGetAppMembersMultipleResults

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

		public List<spMultiResults2Result1> Result1 { get; set; }

		public List<spMultiResults2Result2> Result2 { get; set; }

		public List<spMultiResults2Result1> Result3 { get; set; }

		public List<spMultiResults2Result2> Result4 { get; set; }

		public int ReturnValue { get; set; }

	}
	#endregion spMultiResults2MultipleResults

	#region spNoTablesResultsMultipleResults
	public partial class spNoTablesResultsMultipleResults
	{
		public spNoTablesResultsMultipleResults(){ }

		public int ReturnValue { get; set; }

	}
	#endregion spNoTablesResultsMultipleResults

	#region spNoTablesResults2MultipleResults
	public partial class spNoTablesResults2MultipleResults
	{
		public spNoTablesResults2MultipleResults(){ }

		public int ReturnValue { get; set; }

	}
	#endregion spNoTablesResults2MultipleResults

	#region spRandomNumberMultipleResults
	public partial class spRandomNumberMultipleResults
	{
		public spRandomNumberMultipleResults(){ }

		public List<spRandomNumberResult> Result1 { get; set; }

		public int ReturnValue { get; set; }

	}
	#endregion spRandomNumberMultipleResults

	#region spSpiderExtractVehicleModelMultipleResults
	public partial class spSpiderExtractVehicleModelMultipleResults
	{
		public spSpiderExtractVehicleModelMultipleResults(){ }

		public int ReturnValue { get; set; }

	}
	#endregion spSpiderExtractVehicleModelMultipleResults

	#region spSysRebuildAllIndexesMultipleResults
	public partial class spSysRebuildAllIndexesMultipleResults
	{
		public spSysRebuildAllIndexesMultipleResults(){ }

		public List<spSysRebuildAllIndexesResult> Result1 { get; set; }

		public int ReturnValue { get; set; }

	}
	#endregion spSysRebuildAllIndexesMultipleResults

	#region sp_helpdiagramdefinitionResult
	public partial class sp_helpdiagramdefinitionResult
	{
		public sp_helpdiagramdefinitionResult(){ }

		/// <summary>
		/// DbType = "Int"
		/// </summary>
		public int? version { get; set; }

		/// <summary>
		/// DbType = "VarBinary(MAX)"
		/// </summary>
		public byte[] definition { get; set; }

	}
	#endregion sp_helpdiagramdefinitionResult

	#region sp_helpdiagramsResult
	public partial class sp_helpdiagramsResult
	{
		public sp_helpdiagramsResult(){ }

		/// <summary>
		/// DbType = "NVarChar(128)"
		/// </summary>
		public string Database { get; set; }

		/// <summary>
		/// DbType = "NVarChar(128) NOT NULL"
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// DbType = "Int NOT NULL"
		/// </summary>
		public int ID { get; set; }

		/// <summary>
		/// DbType = "NVarChar(128)"
		/// </summary>
		public string Owner { get; set; }

		/// <summary>
		/// DbType = "Int NOT NULL"
		/// </summary>
		public int OwnerID { get; set; }

	}
	#endregion sp_helpdiagramsResult

	#region spGetAppMembersResult1
	public partial class spGetAppMembersResult1
	{
		public spGetAppMembersResult1(){ }

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
		/// DbType = "TinyInt(1)"
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
	#endregion spGetAppMembersResult1

	#region spGetAppMembersResult2
	public partial class spGetAppMembersResult2
	{
		public spGetAppMembersResult2(){ }

		/// <summary>
		/// DbType = "Int"
		/// </summary>
		public int? TotalCount { get; set; }

	}
	#endregion spGetAppMembersResult2

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

	#region spMultiResults2Result1
	public partial class spMultiResults2Result1
	{
		public spMultiResults2Result1(){ }

		/// <summary>
		/// DbType = "DateTime NOT NULL"
		/// </summary>
		public DateTime StartDate { get; set; }

		/// <summary>
		/// DbType = "DateTime NOT NULL"
		/// </summary>
		public DateTime EndDate { get; set; }

	}
	#endregion spMultiResults2Result1

	#region spMultiResults2Result2
	public partial class spMultiResults2Result2
	{
		public spMultiResults2Result2(){ }

		/// <summary>
		/// DbType = "Int NOT NULL"
		/// </summary>
		public int Ordinal { get; set; }

		/// <summary>
		/// DbType = "VarChar(6) NOT NULL"
		/// </summary>
		public string Name { get; set; }

	}
	#endregion spMultiResults2Result2

	#region spRandomNumberResult
	public partial class spRandomNumberResult
	{
		public spRandomNumberResult(){ }

		/// <summary>
		/// DbType = "Float"
		/// </summary>
		public double? Random { get; set; }

	}
	#endregion spRandomNumberResult

	#region spSysRebuildAllIndexesResult
	public partial class spSysRebuildAllIndexesResult
	{
		public spSysRebuildAllIndexesResult(){ }

		/// <summary>
		/// DbType = "NVarChar(128) NOT NULL"
		/// </summary>
		public string Schema { get; set; }

		/// <summary>
		/// DbType = "NVarChar(128) NOT NULL"
		/// </summary>
		public string Table { get; set; }

		/// <summary>
		/// DbType = "NVarChar(128)"
		/// </summary>
		public string Index { get; set; }

		/// <summary>
		/// DbType = "Float"
		/// </summary>
		public double? avg_fragmentation_in_percent { get; set; }

		/// <summary>
		/// DbType = "BigInt"
		/// </summary>
		public long? page_count { get; set; }

	}
	#endregion spSysRebuildAllIndexesResult

	#endregion

}
