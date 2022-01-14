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
		public virtual DbSet<tblAppMemberAssignedPermission> tblAppMemberAssignedPermission { get; set; }
		public virtual DbSet<tblAppPermission> tblAppPermission { get; set; }

		#endregion Context properties for tables

		#region Context database functions


		#endregion Context database functions

		#region OnModelCreating

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			this.Map_tblAppMember(modelBuilder);
			this.Customize_tblAppMember(modelBuilder);

			this.Map_tblAppMemberAssignedPermission(modelBuilder);
			this.Customize_tblAppMemberAssignedPermission(modelBuilder);

			this.Map_tblAppPermission(modelBuilder);
			this.Customize_tblAppPermission(modelBuilder);

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

		#region tblAppMemberAssignedPermission
		private void Map_tblAppMemberAssignedPermission(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<tblAppMemberAssignedPermission>().ToTable("tblAppMemberAssignedPermission", "dbo");
			modelBuilder.Entity<tblAppMemberAssignedPermission>().HasNoKey();
			modelBuilder.Entity<tblAppMemberAssignedPermission>().Property(x=>x.AppMemberID).HasColumnName("AppMemberID").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblAppMemberAssignedPermission>().Property(x=>x.AppPermissionID).HasColumnName("AppPermissionID").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblAppMemberAssignedPermission>().Property(x=>x.AssignedDate).HasColumnName("AssignedDate").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblAppMemberAssignedPermission>().Property(x=>x.AssignedByAppMemberID).HasColumnName("AssignedByAppMemberID").HasColumnType("Int").ValueGeneratedNever();
		}

		partial void Customize_tblAppMemberAssignedPermission(ModelBuilder modelBuilder);
		#endregion

		#region tblAppPermission
		private void Map_tblAppPermission(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<tblAppPermission>().ToTable("tblAppPermission", "dbo");
			modelBuilder.Entity<tblAppPermission>().HasKey(x=>x.AppPermissionID);
			modelBuilder.Entity<tblAppPermission>().Property(x=>x.AppPermissionID).HasColumnName("AppPermissionID").HasColumnType("Int").IsRequired().ValueGeneratedOnAdd();
			modelBuilder.Entity<tblAppPermission>().Property(x=>x.IsActive).HasColumnName("IsActive").HasColumnType("Bit").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblAppPermission>().Property(x=>x.Name).HasColumnName("Name").HasColumnType("NVarChar(100)").IsRequired().ValueGeneratedNever().HasMaxLength(100);
			modelBuilder.Entity<tblAppPermission>().Property(x=>x.Description).HasColumnName("Description").HasColumnType("NVarChar(500)").ValueGeneratedNever().HasMaxLength(500);
			modelBuilder.Entity<tblAppPermission>().Property(x=>x.GroupName).HasColumnName("GroupName").HasColumnType("NVarChar(50)").ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<tblAppPermission>().Property(x=>x.Ordinal).HasColumnName("Ordinal").HasColumnType("Int").ValueGeneratedNever();
		}

		partial void Customize_tblAppPermission(ModelBuilder modelBuilder);
		#endregion

		#endregion

		#region Relationships mapping
		private void RelationshipsMapping(ModelBuilder modelBuilder)
		{
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
		#endregion Associations

		partial void OnCreated();
	}
	#endregion dbo.tblAppMember

	#region dbo.tblAppMemberAssignedPermission
	public partial class tblAppMemberAssignedPermission : EFCoreEntityBase<tblAppMemberAssignedPermission>
	{
		public tblAppMemberAssignedPermission()
		{
			OnCreated();
		}

		public tblAppMemberAssignedPermission(DbContext context) : base(context)
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
		public int AppPermissionID { get; set; }

		/// <summary>
		/// DbType = "DateTime NOT NULL", DefaultValue = /*getdate()*/ DateTime.Now
		/// </summary>
		public DateTime AssignedDate { get; set; } = /*getdate()*/ DateTime.Now;

		/// <summary>
		/// DbType = "Int"
		/// </summary>
		public int? AssignedByAppMemberID { get; set; }

		#endregion Columns

		#region Associations
		#endregion Associations

		partial void OnCreated();
	}
	#endregion dbo.tblAppMemberAssignedPermission

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
		/// DbType = "Bit NOT NULL"
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
		#endregion Associations

		partial void OnCreated();
	}
	#endregion dbo.tblAppPermission


	#endregion

	#region Functions Return types

	#endregion

}
