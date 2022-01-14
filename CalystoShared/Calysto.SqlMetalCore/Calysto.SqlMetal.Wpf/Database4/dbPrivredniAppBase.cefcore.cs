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

namespace PrivredniDatabases.PrivredniApp.Database
{
	/// <summary>
	/// CalystoEFCoreFluent for MSSQL
	/// </summary>
	public partial class dbPrivredniAppBaseDataContext : DbContext
	{
		#region Context constructors
		
		public dbPrivredniAppBaseDataContext(bool useLazyLoadingProxies)
			: base(new DbContextOptionsBuilder<dbPrivredniAppBaseDataContext>()
				.UsingThis(builder => { if (useLazyLoadingProxies) builder.UseLazyLoadingProxies(); })
				.Options)
		{
			OnCreated();
		}
		
		public dbPrivredniAppBaseDataContext(Action<DbContextOptionsBuilder<dbPrivredniAppBaseDataContext>> configure)
			: base(new DbContextOptionsBuilder<dbPrivredniAppBaseDataContext>()
				.UsingThis(builder => configure(builder))
				.Options)
		{
			OnCreated();
		}

		public dbPrivredniAppBaseDataContext(DbContextOptions<dbPrivredniAppBaseDataContext> options) : base(options)
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
				optionsBuilder.UseSqlServer(@"Data Source=.\MSSQL2019;Initial Catalog=dbPrivredniAppSrb;Integrated Security=True;Connect Timeout=30;");
			}
			CustomizeConfiguration(ref optionsBuilder);
			base.OnConfiguring(optionsBuilder);
		}

		partial void CustomizeConfiguration(ref DbContextOptionsBuilder optionsBuilder);

		#endregion OnConfiguring

		#region Context properties for tables

		public virtual DbSet<tblAppCache> tblAppCache { get; set; }
		public virtual DbSet<tblAppConfig> tblAppConfig { get; set; }
		public virtual DbSet<tblAppMember> tblAppMember { get; set; }
		public virtual DbSet<tblAppMemberPermission> tblAppMemberPermission { get; set; }
		public virtual DbSet<tblAppMemberPicture> tblAppMemberPicture { get; set; }
		public virtual DbSet<tblAppMemberStatus> tblAppMemberStatus { get; set; }
		public virtual DbSet<tblAppNewsletter> tblAppNewsletter { get; set; }
		public virtual DbSet<tblBanka> tblBanka { get; set; }
		public virtual DbSet<tblBankaPromet> tblBankaPromet { get; set; }
		public virtual DbSet<tblBankaPrometDocument> tblBankaPrometDocument { get; set; }
		public virtual DbSet<tblBankaPrometVrsta> tblBankaPrometVrsta { get; set; }
		public virtual DbSet<tblBankaValuta> tblBankaValuta { get; set; }
		public virtual DbSet<tblBankaValutaTecaj> tblBankaValutaTecaj { get; set; }
		public virtual DbSet<tblBillCategory> tblBillCategory { get; set; }
		public virtual DbSet<tblBillClient> tblBillClient { get; set; }
		public virtual DbSet<tblBillClientFullText> tblBillClientFullText { get; set; }
		public virtual DbSet<tblBillDocument> tblBillDocument { get; set; }
		public virtual DbSet<tblBillDocumentCalculated> tblBillDocumentCalculated { get; set; }
		public virtual DbSet<tblBillDocumentStavka> tblBillDocumentStavka { get; set; }
		public virtual DbSet<tblBillDocumentTip> tblBillDocumentTip { get; set; }
		public virtual DbSet<tblBillDocumentVariant> tblBillDocumentVariant { get; set; }
		public virtual DbSet<tblBillDownloadLog> tblBillDownloadLog { get; set; }
		public virtual DbSet<tblBillFirma> tblBillFirma { get; set; }
		public virtual DbSet<tblBillFirmaCertificate> tblBillFirmaCertificate { get; set; }
		public virtual DbSet<tblBillFirmaCertificateMode> tblBillFirmaCertificateMode { get; set; }
		public virtual DbSet<tblBillFirmaPos> tblBillFirmaPos { get; set; }
		public virtual DbSet<tblBillFirmaTransakcijskiRacun> tblBillFirmaTransakcijskiRacun { get; set; }
		public virtual DbSet<tblBillFirmaTransakcijskiRacunEmail> tblBillFirmaTransakcijskiRacunEmail { get; set; }
		public virtual DbSet<tblBillMjera> tblBillMjera { get; set; }
		public virtual DbSet<tblBillNaplatniUredjaj> tblBillNaplatniUredjaj { get; set; }
		public virtual DbSet<tblBillOperator> tblBillOperator { get; set; }
		public virtual DbSet<tblBillPaymentMethod> tblBillPaymentMethod { get; set; }
		public virtual DbSet<tblBillPoreznaGrupa> tblBillPoreznaGrupa { get; set; }
		public virtual DbSet<tblBillPoslovniProstor> tblBillPoslovniProstor { get; set; }
		public virtual DbSet<tblBillPrintLog> tblBillPrintLog { get; set; }
		public virtual DbSet<tblBillProduct> tblBillProduct { get; set; }
		public virtual DbSet<tblBillProductCategory> tblBillProductCategory { get; set; }
		public virtual DbSet<tblBillProductNormativ> tblBillProductNormativ { get; set; }
		public virtual DbSet<tblBillUslugaTip> tblBillUslugaTip { get; set; }
		public virtual DbSet<tblBookkeepingFiduciaExport> tblBookkeepingFiduciaExport { get; set; }
		public virtual DbSet<tblBookkeepingSynesisExport> tblBookkeepingSynesisExport { get; set; }
		public virtual DbSet<tblDirClient> tblDirClient { get; set; }
		public virtual DbSet<tblDirClientBlacklist> tblDirClientBlacklist { get; set; }
		public virtual DbSet<tblDirClientFullText> tblDirClientFullText { get; set; }
		public virtual DbSet<tblDirClientGratis> tblDirClientGratis { get; set; }
		public virtual DbSet<tblDirClientPicture> tblDirClientPicture { get; set; }
		public virtual DbSet<tblDirClientPrikazStatus> tblDirClientPrikazStatus { get; set; }
		public virtual DbSet<tblDirClientSource> tblDirClientSource { get; set; }
		public virtual DbSet<tblDirClientVracenaPosta> tblDirClientVracenaPosta { get; set; }
		public virtual DbSet<tblDirNkd2007> tblDirNkd2007 { get; set; }
		public virtual DbSet<tblDirPrikazStatus> tblDirPrikazStatus { get; set; }
		public virtual DbSet<tblDirRegistration> tblDirRegistration { get; set; }
		public virtual DbSet<tblFiskalRacunZahtjevLog> tblFiskalRacunZahtjevLog { get; set; }
		public virtual DbSet<tblPorezPdv> tblPorezPdv { get; set; }
		public virtual DbSet<tblPorezPdvPostotak> tblPorezPdvPostotak { get; set; }
		public virtual DbSet<tblPorezPotrosnja> tblPorezPotrosnja { get; set; }
		public virtual DbSet<tblPorezPotrosnjaPostotak> tblPorezPotrosnjaPostotak { get; set; }
		public virtual DbSet<tblSocialMember> tblSocialMember { get; set; }
		public virtual DbSet<tblSocialMemberStatus> tblSocialMemberStatus { get; set; }
		public virtual DbSet<tblSocialProvider> tblSocialProvider { get; set; }
		public virtual DbSet<tblWeatherCity> tblWeatherCity { get; set; }
		public virtual DbSet<tblWeatherDayInfo> tblWeatherDayInfo { get; set; }
		public virtual DbSet<tblWeatherInfo> tblWeatherInfo { get; set; }
		public virtual DbSet<tblWeatherKind> tblWeatherKind { get; set; }
		public virtual DbSet<viewBookkeepingFiduciaExport> viewBookkeepingFiduciaExport { get; set; }
		public virtual DbSet<viewBookkeepingSynesisExport> viewBookkeepingSynesisExport { get; set; }
		public virtual DbSet<viewRandom> viewRandom { get; set; }

		#endregion Context properties for tables

		#region Context database functions

		/// <param name="str">NVarChar(MAX)</param>
		/// <param name="expectedLength">Int</param>
		/// <param name="addPrefix">Bit</param>
		/// <returns>Scalar value from function</returns>
		public string fnAddPaddingSpace(
			string str, 
			int? expectedLength, 
			bool? addPrefix)
		{
			return this.ExecuteList<string>($@"select dbo.fnAddPaddingSpace({{0}}, {{1}}, {{2}})", str, expectedLength, addPrefix).First();
		}

		/// <param name="billFirmaID">BigInt</param>
		/// <param name="datum">DateTime</param>
		/// <param name="iznos">Money</param>
		/// <returns>Sequence from function</returns>
		public List<fnCalculateBankaPrometOsnovicaAndPdvResult> fnCalculateBankaPrometOsnovicaAndPdv(
			long? billFirmaID, 
			DateTime? datum, 
			decimal? iznos)
		{
			return this.ExecuteList<fnCalculateBankaPrometOsnovicaAndPdvResult>($@"select * from dbo.fnCalculateBankaPrometOsnovicaAndPdv({{0}}, {{1}}, {{2}})", billFirmaID, datum, iznos).ToList();
		}

		/// <param name="nowDate">DateTime</param>
		/// <param name="brojDanaZaUplatu">Int</param>
		/// <returns>Sequence from function</returns>
		public List<fnCalculateDatumValuteRokPlacanjaResult> fnCalculateDatumValuteRokPlacanja(
			DateTime? nowDate, 
			int? brojDanaZaUplatu)
		{
			return this.ExecuteList<fnCalculateDatumValuteRokPlacanjaResult>($@"select * from dbo.fnCalculateDatumValuteRokPlacanja({{0}}, {{1}})", nowDate, brojDanaZaUplatu).ToList();
		}

		/// <param name="billDocumentID">BigInt</param>
		/// <returns>Sequence from function</returns>
		public List<fnCalculateDocumentNaknadeResult> fnCalculateDocumentNaknade(long? billDocumentID)
		{
			return this.ExecuteList<fnCalculateDocumentNaknadeResult>($@"select * from dbo.fnCalculateDocumentNaknade({{0}})", billDocumentID).ToList();
		}

		/// <param name="billDocumentID">BigInt</param>
		/// <returns>Sequence from function</returns>
		public List<fnCalculateDocumentPorezOstaliResult> fnCalculateDocumentPorezOstali(long? billDocumentID)
		{
			return this.ExecuteList<fnCalculateDocumentPorezOstaliResult>($@"select * from dbo.fnCalculateDocumentPorezOstali({{0}})", billDocumentID).ToList();
		}

		/// <param name="billDocumentID">BigInt</param>
		/// <returns>Sequence from function</returns>
		public List<fnCalculateDocumentPorezPdvResult> fnCalculateDocumentPorezPdv(long? billDocumentID)
		{
			return this.ExecuteList<fnCalculateDocumentPorezPdvResult>($@"select * from dbo.fnCalculateDocumentPorezPdv({{0}})", billDocumentID).ToList();
		}

		/// <param name="billDocumentID">BigInt</param>
		/// <returns>Sequence from function</returns>
		public List<fnCalculateDocumentPorezPotrosnjaResult> fnCalculateDocumentPorezPotrosnja(long? billDocumentID)
		{
			return this.ExecuteList<fnCalculateDocumentPorezPotrosnjaResult>($@"select * from dbo.fnCalculateDocumentPorezPotrosnja({{0}})", billDocumentID).ToList();
		}

		/// <param name="billDocumentID">BigInt</param>
		/// <returns>Sequence from function</returns>
		public List<fnCalculateDocumentStavkeResult> fnCalculateDocumentStavke(long? billDocumentID)
		{
			return this.ExecuteList<fnCalculateDocumentStavkeResult>($@"select * from dbo.fnCalculateDocumentStavke({{0}})", billDocumentID).ToList();
		}

		/// <param name="billDocumentID">BigInt</param>
		/// <returns>Sequence from function</returns>
		public List<fnCalculateDocumentTotalsResult> fnCalculateDocumentTotals(long? billDocumentID)
		{
			return this.ExecuteList<fnCalculateDocumentTotalsResult>($@"select * from dbo.fnCalculateDocumentTotals({{0}})", billDocumentID).ToList();
		}

		/// <param name="pozivNaBroj">NVarChar(30)</param>
		/// <returns>Scalar value from function</returns>
		public string fnCalculateFiskalniBrojRacuna(string pozivNaBroj)
		{
			return this.ExecuteList<string>($@"select dbo.fnCalculateFiskalniBrojRacuna({{0}})", pozivNaBroj).First();
		}

		/// <param name="billNaplatniUredjajID">BigInt</param>
		/// <param name="datumDokumenta">DateTime</param>
		/// <param name="redniBroj">Int</param>
		/// <returns>Sequence from function</returns>
		public List<fnCalculatePozivNaBrojResult> fnCalculatePozivNaBroj(
			long? billNaplatniUredjajID, 
			DateTime? datumDokumenta, 
			int? redniBroj)
		{
			return this.ExecuteList<fnCalculatePozivNaBrojResult>($@"select * from dbo.fnCalculatePozivNaBroj({{0}}, {{1}}, {{2}})", billNaplatniUredjajID, datumDokumenta, redniBroj).ToList();
		}

		/// <param name="pozivNaBrojBezChecksuma">NVarChar(100)</param>
		/// <returns>Scalar value from function</returns>
		public string fnCalculatePozivNaBrojChecksum(string pozivNaBrojBezChecksuma)
		{
			return this.ExecuteList<string>($@"select dbo.fnCalculatePozivNaBrojChecksum({{0}})", pozivNaBrojBezChecksuma).First();
		}

		/// <param name="str1">NVarChar(MAX)</param>
		/// <returns>Sequence from function</returns>
		public List<fnCLRCsvArgsToIntTableResult> fnCLRCsvArgsToIntTable(string str1)
		{
			return this.ExecuteList<fnCLRCsvArgsToIntTableResult>($@"select * from dbo.fnCLRCsvArgsToIntTable({{0}})", str1).ToList();
		}

		/// <param name="str1">NVarChar(MAX)</param>
		/// <returns>Sequence from function</returns>
		public List<fnCLRCsvArgsToWordsTableResult> fnCLRCsvArgsToWordsTable(string str1)
		{
			return this.ExecuteList<fnCLRCsvArgsToWordsTableResult>($@"select * from dbo.fnCLRCsvArgsToWordsTable({{0}})", str1).ToList();
		}

		/// <param name="str1">NVarChar(MAX)</param>
		/// <param name="wordMinlength">Int</param>
		/// <param name="finalMaxlength">Int</param>
		/// <returns>Scalar value from function</returns>
		public string fnCLRGetDistinctWordsString(
			string str1, 
			int? wordMinlength, 
			int? finalMaxlength)
		{
			return this.ExecuteList<string>($@"select dbo.fnCLRGetDistinctWordsString({{0}}, {{1}}, {{2}})", str1, wordMinlength, finalMaxlength).First();
		}

		/// <param name="str1">NVarChar(MAX)</param>
		/// <param name="patternStr">NVarChar(MAX)</param>
		/// <returns>Sequence from function</returns>
		public List<fnCLRSplitStringByPatternResult> fnCLRSplitStringByPattern(
			string str1, 
			string patternStr)
		{
			return this.ExecuteList<fnCLRSplitStringByPatternResult>($@"select * from dbo.fnCLRSplitStringByPattern({{0}}, {{1}})", str1, patternStr).ToList();
		}

		/// <param name="str1">NVarChar(MAX)</param>
		/// <returns>Sequence from function</returns>
		public List<fnCLRSplitStringToDistinctWordsResult> fnCLRSplitStringToDistinctWords(string str1)
		{
			return this.ExecuteList<fnCLRSplitStringToDistinctWordsResult>($@"select * from dbo.fnCLRSplitStringToDistinctWords({{0}})", str1).ToList();
		}

		/// <param name="str1">NVarChar(MAX)</param>
		/// <returns>Sequence from function</returns>
		public List<fnCLRSplitStringToWordsResult> fnCLRSplitStringToWords(string str1)
		{
			return this.ExecuteList<fnCLRSplitStringToWordsResult>($@"select * from dbo.fnCLRSplitStringToWords({{0}})", str1).ToList();
		}

		/// <param name="list">NVarChar(MAX)</param>
		/// <returns>Sequence from function</returns>
		public List<fnConvertCsvArgsToIntTableResult> fnConvertCsvArgsToIntTable(string list)
		{
			return this.ExecuteList<fnConvertCsvArgsToIntTableResult>($@"select * from dbo.fnConvertCsvArgsToIntTable({{0}})", list).ToList();
		}

		/// <param name="list">NVarChar(MAX)</param>
		/// <returns>Sequence from function</returns>
		public List<fnConvertCsvArgsToWordsTableResult> fnConvertCsvArgsToWordsTable(string list)
		{
			return this.ExecuteList<fnConvertCsvArgsToWordsTableResult>($@"select * from dbo.fnConvertCsvArgsToWordsTable({{0}})", list).ToList();
		}

		/// <param name="amount">Float</param>
		/// <param name="fromCurrency">VarChar(10)</param>
		/// <param name="toCurrency">VarChar(10)</param>
		/// <param name="exchangeRateDate">DateTime, DefaultValue = null</param>
		/// <returns>Scalar value from function</returns>
		public double? fnConvertCurrency(
			double? amount, 
			string fromCurrency, 
			string toCurrency, 
			DateTime? exchangeRateDate = null)
		{
			return this.ExecuteList<double?>($@"select dbo.fnConvertCurrency({{0}}, {{1}}, {{2}}, {{3}})", amount, fromCurrency, toCurrency, exchangeRateDate).First();
		}

		/// <param name="value">DateTime</param>
		/// <returns>Scalar value from function</returns>
		public string fnFormatDateToStringISO(DateTime? value)
		{
			return this.ExecuteList<string>($@"select dbo.fnFormatDateToStringISO({{0}})", value).First();
		}

		/// <param name="value">DateTime</param>
		/// <returns>Scalar value from function</returns>
		public string fnFormatDateToStringLocal(DateTime? value)
		{
			return this.ExecuteList<string>($@"select dbo.fnFormatDateToStringLocal({{0}})", value).First();
		}

		/// <param name="flvalue">Money</param>
		/// <returns>Scalar value from function</returns>
		public string fnFormatMoneyToStringLocal(decimal? flvalue)
		{
			return this.ExecuteList<string>($@"select dbo.fnFormatMoneyToStringLocal({{0}})", flvalue).First();
		}

		/// <param name="BankaPrometVrstaID">Int</param>
		/// <returns>Scalar value from function</returns>
		public string fnGetBankaPrometVrstaDescriptiveName(int? BankaPrometVrstaID)
		{
			return this.ExecuteList<string>($@"select dbo.fnGetBankaPrometVrstaDescriptiveName({{0}})", BankaPrometVrstaID).First();
		}

		/// <returns>Sequence from function</returns>
		public List<fnGetBankaPrometVrsteResult> fnGetBankaPrometVrste()
		{
			return this.ExecuteList<fnGetBankaPrometVrsteResult>($@"select * from dbo.fnGetBankaPrometVrste()").ToList();
		}

		/// <returns>Sequence from function</returns>
		public List<fnGetBankaPrometVrsteDatumaResult> fnGetBankaPrometVrsteDatuma()
		{
			return this.ExecuteList<fnGetBankaPrometVrsteDatumaResult>($@"select * from dbo.fnGetBankaPrometVrsteDatuma()").ToList();
		}

		/// <param name="validOnDate">DateTime, DefaultValue = null</param>
		/// <param name="valuta">VarChar(50), DefaultValue = null</param>
		/// <returns>Sequence from function</returns>
		public List<fnGetBankaValutaTecajResult> fnGetBankaValutaTecaj(
			DateTime? validOnDate = null, 
			string valuta = null)
		{
			return this.ExecuteList<fnGetBankaValutaTecajResult>($@"select * from dbo.fnGetBankaValutaTecaj({{0}}, {{1}})", validOnDate, valuta).ToList();
		}

		/// <param name="pozivNaBrojCSV">VarChar(MAX)</param>
		/// <returns>Sequence from function</returns>
		public List<fnGetBillClientsFromPoziviNaBrojResult> fnGetBillClientsFromPoziviNaBroj(string pozivNaBrojCSV)
		{
			return this.ExecuteList<fnGetBillClientsFromPoziviNaBrojResult>($@"select * from dbo.fnGetBillClientsFromPoziviNaBroj({{0}})", pozivNaBrojCSV).ToList();
		}

		/// <param name="billFirmaID">BigInt</param>
		/// <param name="billClientsIdsCSV">VarChar(MAX), DefaultValue = null</param>
		/// <returns>Sequence from function</returns>
		public List<fnGetBillClientUplateResult> fnGetBillClientUplate(
			long? billFirmaID, 
			string billClientsIdsCSV = null)
		{
			return this.ExecuteList<fnGetBillClientUplateResult>($@"select * from dbo.fnGetBillClientUplate({{0}}, {{1}})", billFirmaID, billClientsIdsCSV).ToList();
		}

		/// <returns>Sequence from function</returns>
		public List<fnGetDbPairNamesResult> fnGetDbPairNames()
		{
			return this.ExecuteList<fnGetDbPairNamesResult>($@"select * from dbo.fnGetDbPairNames()").ToList();
		}

		/// <param name="billFirmaID">BigInt</param>
		/// <param name="billNaplatniUredjajID">BigInt, DefaultValue = null</param>
		/// <returns>Scalar value from function</returns>
		public DateTime? fnGetMaxDocumentDate(
			long? billFirmaID, 
			long? billNaplatniUredjajID = null)
		{
			return this.ExecuteList<DateTime?>($@"select dbo.fnGetMaxDocumentDate({{0}}, {{1}})", billFirmaID, billNaplatniUredjajID).First();
		}

		/// <param name="date">DateTime</param>
		/// <returns>Sequence from function</returns>
		public List<fnGetMonthStartEndResult> fnGetMonthStartEnd(DateTime? date)
		{
			return this.ExecuteList<fnGetMonthStartEndResult>($@"select * from dbo.fnGetMonthStartEnd({{0}})", date).ToList();
		}

		/// <param name="nkdRowID">Int</param>
		/// <param name="maxStringLength">Int, DefaultValue = (int)(4000)</param>
		/// <returns>Sequence from function</returns>
		public List<fnGetNKDFullPathInfoResult> fnGetNKDFullPathInfo(
			int? nkdRowID, 
			int? maxStringLength = (int)(4000))
		{
			return this.ExecuteList<fnGetNKDFullPathInfoResult>($@"select * from dbo.fnGetNKDFullPathInfo({{0}}, {{1}})", nkdRowID, maxStringLength).ToList();
		}

		/// <param name="datumValute">DateTime, DefaultValue = null</param>
		/// <returns>Sequence from function</returns>
		public List<fnGetPorezPdvNaDatumResult> fnGetPorezPdvNaDatum(DateTime? datumValute = null)
		{
			return this.ExecuteList<fnGetPorezPdvNaDatumResult>($@"select * from dbo.fnGetPorezPdvNaDatum({{0}})", datumValute).ToList();
		}

		/// <param name="datumValute">DateTime, DefaultValue = null</param>
		/// <returns>Sequence from function</returns>
		public List<fnGetPorezPotrosnjaNaDatumResult> fnGetPorezPotrosnjaNaDatum(DateTime? datumValute = null)
		{
			return this.ExecuteList<fnGetPorezPotrosnjaNaDatumResult>($@"select * from dbo.fnGetPorezPotrosnjaNaDatum({{0}})", datumValute).ToList();
		}

		/// <param name="dirClientID">BigInt</param>
		/// <param name="prikazStatus">Int, DefaultValue = null</param>
		/// <param name="startDate">DateTime, DefaultValue = null</param>
		/// <param name="endDate">DateTime, DefaultValue = null</param>
		/// <returns>Sequence from function</returns>
		public List<fnGetPrikazStatusInfoResult> fnGetPrikazStatusInfo(
			long? dirClientID, 
			int? prikazStatus = null, 
			DateTime? startDate = null, 
			DateTime? endDate = null)
		{
			return this.ExecuteList<fnGetPrikazStatusInfoResult>($@"select * from dbo.fnGetPrikazStatusInfo({{0}}, {{1}}, {{2}}, {{3}})", dirClientID, prikazStatus, startDate, endDate).ToList();
		}

		/// <param name="billProductID">BigInt</param>
		/// <returns>Sequence from function</returns>
		public List<fnGetProductInfoExtendedResult> fnGetProductInfoExtended(long? billProductID)
		{
			return this.ExecuteList<fnGetProductInfoExtendedResult>($@"select * from dbo.fnGetProductInfoExtended({{0}})", billProductID).ToList();
		}

		/// <param name="csvValues">VarChar(MAX)</param>
		/// <returns>Scalar value from function</returns>
		public int? fnGetRandomIntegerValue(string csvValues)
		{
			return this.ExecuteList<int?>($@"select dbo.fnGetRandomIntegerValue({{0}})", csvValues).First();
		}

		/// <returns>Sequence from function</returns>
		public List<fnGetStariNoviGranicaResult> fnGetStariNoviGranica()
		{
			return this.ExecuteList<fnGetStariNoviGranicaResult>($@"select * from dbo.fnGetStariNoviGranica()").ToList();
		}

		/// <param name="billFirmaID">BigInt</param>
		/// <returns>Sequence from function</returns>
		public List<fnGetUplateWithDocumentsResult> fnGetUplateWithDocuments(long? billFirmaID)
		{
			return this.ExecuteList<fnGetUplateWithDocumentsResult>($@"select * from dbo.fnGetUplateWithDocuments({{0}})", billFirmaID).ToList();
		}

		/// <param name="billDocumentID">BigInt</param>
		/// <returns>Scalar value from function</returns>
		public bool? fnIsDocumentFiskalizacijaRequired(long? billDocumentID)
		{
			return this.ExecuteList<bool?>($@"select dbo.fnIsDocumentFiskalizacijaRequired({{0}})", billDocumentID).First();
		}

		/// <param name="billNaplatniUredjajID">BigInt</param>
		/// <returns>Scalar value from function</returns>
		public bool? fnIsNaplatniUredjajFiskalizacijaRequired(long? billNaplatniUredjajID)
		{
			return this.ExecuteList<bool?>($@"select dbo.fnIsNaplatniUredjajFiskalizacijaRequired({{0}})", billNaplatniUredjajID).First();
		}

		/// <param name="billNaplatniUredjajID">BigInt</param>
		/// <returns>Scalar value from function</returns>
		public bool? fnIsRacunType(long? billNaplatniUredjajID)
		{
			return this.ExecuteList<bool?>($@"select dbo.fnIsRacunType({{0}})", billNaplatniUredjajID).First();
		}

		/// <param name="billFirmaID">BigInt</param>
		/// <param name="datum">DateTime</param>
		/// <returns>Scalar value from function</returns>
		public bool? fnIsUPdvSustavu(
			long? billFirmaID, 
			DateTime? datum)
		{
			return this.ExecuteList<bool?>($@"select dbo.fnIsUPdvSustavu({{0}}, {{1}})", billFirmaID, datum).First();
		}

		/// <param name="billFirmaID">BigInt</param>
		/// <returns>Sequence from function</returns>
		public List<fnPosGetFirmaSettingsResult> fnPosGetFirmaSettings(long? billFirmaID)
		{
			return this.ExecuteList<fnPosGetFirmaSettingsResult>($@"select * from dbo.fnPosGetFirmaSettings({{0}})", billFirmaID).ToList();
		}

		/// <param name="billFirmaID">BigInt</param>
		/// <returns>Sequence from function</returns>
		public List<fnPosGetFirmaStatisticsResult> fnPosGetFirmaStatistics(long? billFirmaID)
		{
			return this.ExecuteList<fnPosGetFirmaStatisticsResult>($@"select * from dbo.fnPosGetFirmaStatistics({{0}})", billFirmaID).ToList();
		}

		/// <param name="uPdvSustavu">Bit</param>
		/// <param name="jedinicnaCijena">Float</param>
		/// <param name="cijenaJeMaloprodajna">Bit</param>
		/// <param name="popustPosto">Float</param>
		/// <param name="pdvPosto">Float</param>
		/// <param name="porezPotrosnjaPosto">Float</param>
		/// <param name="ostaliPorezPosto">Float</param>
		/// <param name="iznosNaknade">Float</param>
		/// <returns>Sequence from function</returns>
		public List<fnRazradaIznosaResult> fnRazradaIznosa(
			bool? uPdvSustavu, 
			double? jedinicnaCijena, 
			bool? cijenaJeMaloprodajna, 
			double? popustPosto, 
			double? pdvPosto, 
			double? porezPotrosnjaPosto, 
			double? ostaliPorezPosto, 
			double? iznosNaknade)
		{
			return this.ExecuteList<fnRazradaIznosaResult>($@"select * from dbo.fnRazradaIznosa({{0}}, {{1}}, {{2}}, {{3}}, {{4}}, {{5}}, {{6}}, {{7}})", uPdvSustavu, jedinicnaCijena, cijenaJeMaloprodajna, popustPosto, pdvPosto, porezPotrosnjaPosto, ostaliPorezPosto, iznosNaknade).ToList();
		}

		/// <param name="knjizeniBillDocumentID">BigInt, DefaultValue = null</param>
		/// <param name="zadaniBillNaplatniUredjajID">BigInt, DefaultValue = null</param>
		/// <returns>Scalar value from function</returns>
		public long? fnResolveNaplatniUredjajZaKnjizenje(
			long? knjizeniBillDocumentID = null, 
			long? zadaniBillNaplatniUredjajID = null)
		{
			return this.ExecuteList<long?>($@"select dbo.fnResolveNaplatniUredjajZaKnjizenje({{0}}, {{1}})", knjizeniBillDocumentID, zadaniBillNaplatniUredjajID).First();
		}

		/// <param name="strToSplit">VarChar(MAX)</param>
		/// <param name="pattern">VarChar(100)</param>
		/// <returns>Sequence from function</returns>
		public List<fnSplitStringByPatternResult> fnSplitStringByPattern(
			string strToSplit, 
			string pattern)
		{
			return this.ExecuteList<fnSplitStringByPatternResult>($@"select * from dbo.fnSplitStringByPattern({{0}}, {{1}})", strToSplit, pattern).ToList();
		}

		/// <returns>Scalar value from function</returns>
		public int? fnThrowErrorIfAppDatabase()
		{
			return this.ExecuteList<int?>($@"select dbo.fnThrowErrorIfAppDatabase()").First();
		}

		/// <returns>Scalar value from function</returns>
		public int? fnThrowErrorIfPosDatabase()
		{
			return this.ExecuteList<int?>($@"select dbo.fnThrowErrorIfPosDatabase()").First();
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
			return this.ExecuteList<int?>($@"select dbo.fnThrowErrorMessage({{0}}, {{1}}, {{2}})", errorCode, systemMessage, customerMessage).First();
		}

		/// <param name="billClientID">BigInt, DefaultValue = null</param>
		/// <returns>MultipleResults from stored procedure</returns>
		public spGetAktivneUslugeMultipleResults spGetAktivneUsluge(long? billClientID = null)
		{
			var multiple_results_1 = this.ExecuteMultipleResults($@"declare @return_value int; 
					exec @return_value = dbo.spGetAktivneUsluge {{0}}; 
					select @return_value as ReturnValue;", billClientID);
			var final_result_1 = multiple_results_1.ReadResults(res => new spGetAktivneUslugeMultipleResults()
			{
				Result1 = res.GetSequence<spGetAktivneUslugeResult>().ToList(),
				ReturnValue = res.GetSequence<int>().Single(),
			});
			return final_result_1;
		}

		/// <param name="billFirmaID">BigInt</param>
		/// <param name="billClientsIdsCSV">VarChar(MAX), DefaultValue = null</param>
		/// <returns>MultipleResults from stored procedure</returns>
		public spGetBillClientSaldoMultipleResults spGetBillClientSaldo(
			long? billFirmaID, 
			string billClientsIdsCSV = null)
		{
			var multiple_results_1 = this.ExecuteMultipleResults($@"declare @return_value int; 
					exec @return_value = dbo.spGetBillClientSaldo {{0}}, {{1}}; 
					select @return_value as ReturnValue;", billFirmaID, billClientsIdsCSV);
			var final_result_1 = multiple_results_1.ReadResults(res => new spGetBillClientSaldoMultipleResults()
			{
				Result1 = res.GetSequence<spGetBillClientSaldoResult>().ToList(),
				ReturnValue = res.GetSequence<int>().Single(),
			});
			return final_result_1;
		}

		/// <param name="billFirmaID">BigInt, DefaultValue = null</param>
		/// <returns>MultipleResults from stored procedure</returns>
		public spGetBillMinMaxDateMultipleResults spGetBillMinMaxDate(long? billFirmaID = null)
		{
			var multiple_results_1 = this.ExecuteMultipleResults($@"declare @return_value int; 
					exec @return_value = dbo.spGetBillMinMaxDate {{0}}; 
					select @return_value as ReturnValue;", billFirmaID);
			var final_result_1 = multiple_results_1.ReadResults(res => new spGetBillMinMaxDateMultipleResults()
			{
				Dates = res.GetSequence<BillDates>().ToList(),
				ReturnValue = res.GetSequence<int>().Single(),
			});
			return final_result_1;
		}

		/// <returns>MultipleResults from stored procedure</returns>
		public spGetDbccValuesMultipleResults spGetDbccValues()
		{
			var multiple_results_1 = this.ExecuteMultipleResults($@"declare @return_value int; 
					exec @return_value = dbo.spGetDbccValues; 
					select @return_value as ReturnValue;");
			var final_result_1 = multiple_results_1.ReadResults(res => new spGetDbccValuesMultipleResults()
			{
				Result1 = res.GetSequence<spGetDbccValuesResult>().ToList(),
				ReturnValue = res.GetSequence<int>().Single(),
			});
			return final_result_1;
		}

		/// <param name="csvDirClients">VarChar(MAX), DefaultValue = null</param>
		/// <returns>MultipleResults from stored procedure</returns>
		public spGetDirClientsExtendedMultipleResults spGetDirClientsExtended(string csvDirClients = null)
		{
			var multiple_results_1 = this.ExecuteMultipleResults($@"declare @return_value int; 
					exec @return_value = dbo.spGetDirClientsExtended {{0}}; 
					select @return_value as ReturnValue;", csvDirClients);
			var final_result_1 = multiple_results_1.ReadResults(res => new spGetDirClientsExtendedMultipleResults()
			{
				Clients = res.GetSequence<DirClientExtended>().ToList(),
				ReturnValue = res.GetSequence<int>().Single(),
			});
			return final_result_1;
		}

		/// <param name="billProductID">BigInt</param>
		/// <returns>MultipleResults from stored procedure</returns>
		public spGetProductAdditionaInfoMultipleResults spGetProductAdditionaInfo(long? billProductID)
		{
			var multiple_results_1 = this.ExecuteMultipleResults($@"declare @return_value int; 
					exec @return_value = dbo.spGetProductAdditionaInfo {{0}}; 
					select @return_value as ReturnValue;", billProductID);
			var final_result_1 = multiple_results_1.ReadResults(res => new spGetProductAdditionaInfoMultipleResults()
			{
				Result1 = res.GetSequence<spGetProductAdditionaInfoResult>().ToList(),
				ReturnValue = res.GetSequence<int>().Single(),
			});
			return final_result_1;
		}

		/// <returns>MultipleResults from stored procedure</returns>
		public spWeatherGetAccuweatherCitiesMultipleResults spWeatherGetAccuweatherCities()
		{
			var multiple_results_1 = this.ExecuteMultipleResults($@"declare @return_value int; 
					exec @return_value = dbo.spWeatherGetAccuweatherCities; 
					select @return_value as ReturnValue;");
			var final_result_1 = multiple_results_1.ReadResults(res => new spWeatherGetAccuweatherCitiesMultipleResults()
			{
				Result1 = res.GetSequence<spWeatherGetAccuweatherCitiesResult>().ToList(),
				ReturnValue = res.GetSequence<int>().Single(),
			});
			return final_result_1;
		}

		/// <param name="cityID">Int</param>
		/// <returns>MultipleResults from stored procedure</returns>
		public spWeatherGetCurrentWeatherMultipleResults spWeatherGetCurrentWeather(int? cityID)
		{
			var multiple_results_1 = this.ExecuteMultipleResults($@"declare @return_value int; 
					exec @return_value = dbo.spWeatherGetCurrentWeather {{0}}; 
					select @return_value as ReturnValue;", cityID);
			var final_result_1 = multiple_results_1.ReadResults(res => new spWeatherGetCurrentWeatherMultipleResults()
			{
				Result1 = res.GetSequence<spWeatherGetCurrentWeatherResult>().ToList(),
				ReturnValue = res.GetSequence<int>().Single(),
			});
			return final_result_1;
		}

		/// <param name="cityID">Int</param>
		/// <param name="nextDays">Int, DefaultValue = (int)(12)</param>
		/// <param name="sqlFirstDayOfWeek">Int, DefaultValue = null</param>
		/// <returns>MultipleResults from stored procedure</returns>
		public spWeatherGetDailyWeatherMultipleResults spWeatherGetDailyWeather(
			int? cityID, 
			int? nextDays = (int)(12), 
			int? sqlFirstDayOfWeek = null)
		{
			var multiple_results_1 = this.ExecuteMultipleResults($@"declare @return_value int; 
					exec @return_value = dbo.spWeatherGetDailyWeather {{0}}, {{1}}, {{2}}; 
					select @return_value as ReturnValue;", cityID, nextDays, sqlFirstDayOfWeek);
			var final_result_1 = multiple_results_1.ReadResults(res => new spWeatherGetDailyWeatherMultipleResults()
			{
				Result1 = res.GetSequence<spWeatherGetDailyWeatherResult>().ToList(),
				ReturnValue = res.GetSequence<int>().Single(),
			});
			return final_result_1;
		}

		/// <param name="cityID">Int</param>
		/// <returns>MultipleResults from stored procedure</returns>
		public spWeatherGetHourlyWeatherMultipleResults spWeatherGetHourlyWeather(int? cityID)
		{
			var multiple_results_1 = this.ExecuteMultipleResults($@"declare @return_value int; 
					exec @return_value = dbo.spWeatherGetHourlyWeather {{0}}; 
					select @return_value as ReturnValue;", cityID);
			var final_result_1 = multiple_results_1.ReadResults(res => new spWeatherGetHourlyWeatherMultipleResults()
			{
				Result1 = res.GetSequence<spWeatherGetHourlyWeatherResult>().ToList(),
				ReturnValue = res.GetSequence<int>().Single(),
			});
			return final_result_1;
		}

		/// <param name="cityID">Int, DefaultValue = null</param>
		/// <param name="weatherKindID">Int, DefaultValue = null</param>
		/// <returns>MultipleResults from stored procedure</returns>
		public spWeatherGetMaxLastUpdateDateMultipleResults spWeatherGetMaxLastUpdateDate(
			int? cityID = null, 
			int? weatherKindID = null)
		{
			var multiple_results_1 = this.ExecuteMultipleResults($@"declare @return_value int; 
					exec @return_value = dbo.spWeatherGetMaxLastUpdateDate {{0}}, {{1}}; 
					select @return_value as ReturnValue;", cityID, weatherKindID);
			var final_result_1 = multiple_results_1.ReadResults(res => new spWeatherGetMaxLastUpdateDateMultipleResults()
			{
				Result1 = res.GetSequence<spWeatherGetMaxLastUpdateDateResult>().ToList(),
				ReturnValue = res.GetSequence<int>().Single(),
			});
			return final_result_1;
		}

		/// <param name="cityID">Int, DefaultValue = null</param>
		/// <returns>MultipleResults from stored procedure</returns>
		public spWeatherGetWeatherStatisticsMultipleResults spWeatherGetWeatherStatistics(int? cityID = null)
		{
			var multiple_results_1 = this.ExecuteMultipleResults($@"declare @return_value int; 
					exec @return_value = dbo.spWeatherGetWeatherStatistics {{0}}; 
					select @return_value as ReturnValue;", cityID);
			var final_result_1 = multiple_results_1.ReadResults(res => new spWeatherGetWeatherStatisticsMultipleResults()
			{
				Result1 = res.GetSequence<spWeatherGetWeatherStatisticsResult>().ToList(),
				ReturnValue = res.GetSequence<int>().Single(),
			});
			return final_result_1;
		}


		#endregion Context database functions

		#region OnModelCreating

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			this.Map_tblAppCache(modelBuilder);
			this.Customize_tblAppCache(modelBuilder);

			this.Map_tblAppConfig(modelBuilder);
			this.Customize_tblAppConfig(modelBuilder);

			this.Map_tblAppMember(modelBuilder);
			this.Customize_tblAppMember(modelBuilder);

			this.Map_tblAppMemberPermission(modelBuilder);
			this.Customize_tblAppMemberPermission(modelBuilder);

			this.Map_tblAppMemberPicture(modelBuilder);
			this.Customize_tblAppMemberPicture(modelBuilder);

			this.Map_tblAppMemberStatus(modelBuilder);
			this.Customize_tblAppMemberStatus(modelBuilder);

			this.Map_tblAppNewsletter(modelBuilder);
			this.Customize_tblAppNewsletter(modelBuilder);

			this.Map_tblBanka(modelBuilder);
			this.Customize_tblBanka(modelBuilder);

			this.Map_tblBankaPromet(modelBuilder);
			this.Customize_tblBankaPromet(modelBuilder);

			this.Map_tblBankaPrometDocument(modelBuilder);
			this.Customize_tblBankaPrometDocument(modelBuilder);

			this.Map_tblBankaPrometVrsta(modelBuilder);
			this.Customize_tblBankaPrometVrsta(modelBuilder);

			this.Map_tblBankaValuta(modelBuilder);
			this.Customize_tblBankaValuta(modelBuilder);

			this.Map_tblBankaValutaTecaj(modelBuilder);
			this.Customize_tblBankaValutaTecaj(modelBuilder);

			this.Map_tblBillCategory(modelBuilder);
			this.Customize_tblBillCategory(modelBuilder);

			this.Map_tblBillClient(modelBuilder);
			this.Customize_tblBillClient(modelBuilder);

			this.Map_tblBillClientFullText(modelBuilder);
			this.Customize_tblBillClientFullText(modelBuilder);

			this.Map_tblBillDocument(modelBuilder);
			this.Customize_tblBillDocument(modelBuilder);

			this.Map_tblBillDocumentCalculated(modelBuilder);
			this.Customize_tblBillDocumentCalculated(modelBuilder);

			this.Map_tblBillDocumentStavka(modelBuilder);
			this.Customize_tblBillDocumentStavka(modelBuilder);

			this.Map_tblBillDocumentTip(modelBuilder);
			this.Customize_tblBillDocumentTip(modelBuilder);

			this.Map_tblBillDocumentVariant(modelBuilder);
			this.Customize_tblBillDocumentVariant(modelBuilder);

			this.Map_tblBillDownloadLog(modelBuilder);
			this.Customize_tblBillDownloadLog(modelBuilder);

			this.Map_tblBillFirma(modelBuilder);
			this.Customize_tblBillFirma(modelBuilder);

			this.Map_tblBillFirmaCertificate(modelBuilder);
			this.Customize_tblBillFirmaCertificate(modelBuilder);

			this.Map_tblBillFirmaCertificateMode(modelBuilder);
			this.Customize_tblBillFirmaCertificateMode(modelBuilder);

			this.Map_tblBillFirmaPos(modelBuilder);
			this.Customize_tblBillFirmaPos(modelBuilder);

			this.Map_tblBillFirmaTransakcijskiRacun(modelBuilder);
			this.Customize_tblBillFirmaTransakcijskiRacun(modelBuilder);

			this.Map_tblBillFirmaTransakcijskiRacunEmail(modelBuilder);
			this.Customize_tblBillFirmaTransakcijskiRacunEmail(modelBuilder);

			this.Map_tblBillMjera(modelBuilder);
			this.Customize_tblBillMjera(modelBuilder);

			this.Map_tblBillNaplatniUredjaj(modelBuilder);
			this.Customize_tblBillNaplatniUredjaj(modelBuilder);

			this.Map_tblBillOperator(modelBuilder);
			this.Customize_tblBillOperator(modelBuilder);

			this.Map_tblBillPaymentMethod(modelBuilder);
			this.Customize_tblBillPaymentMethod(modelBuilder);

			this.Map_tblBillPoreznaGrupa(modelBuilder);
			this.Customize_tblBillPoreznaGrupa(modelBuilder);

			this.Map_tblBillPoslovniProstor(modelBuilder);
			this.Customize_tblBillPoslovniProstor(modelBuilder);

			this.Map_tblBillPrintLog(modelBuilder);
			this.Customize_tblBillPrintLog(modelBuilder);

			this.Map_tblBillProduct(modelBuilder);
			this.Customize_tblBillProduct(modelBuilder);

			this.Map_tblBillProductCategory(modelBuilder);
			this.Customize_tblBillProductCategory(modelBuilder);

			this.Map_tblBillProductNormativ(modelBuilder);
			this.Customize_tblBillProductNormativ(modelBuilder);

			this.Map_tblBillUslugaTip(modelBuilder);
			this.Customize_tblBillUslugaTip(modelBuilder);

			this.Map_tblBookkeepingFiduciaExport(modelBuilder);
			this.Customize_tblBookkeepingFiduciaExport(modelBuilder);

			this.Map_tblBookkeepingSynesisExport(modelBuilder);
			this.Customize_tblBookkeepingSynesisExport(modelBuilder);

			this.Map_tblDirClient(modelBuilder);
			this.Customize_tblDirClient(modelBuilder);

			this.Map_tblDirClientBlacklist(modelBuilder);
			this.Customize_tblDirClientBlacklist(modelBuilder);

			this.Map_tblDirClientFullText(modelBuilder);
			this.Customize_tblDirClientFullText(modelBuilder);

			this.Map_tblDirClientGratis(modelBuilder);
			this.Customize_tblDirClientGratis(modelBuilder);

			this.Map_tblDirClientPicture(modelBuilder);
			this.Customize_tblDirClientPicture(modelBuilder);

			this.Map_tblDirClientPrikazStatus(modelBuilder);
			this.Customize_tblDirClientPrikazStatus(modelBuilder);

			this.Map_tblDirClientSource(modelBuilder);
			this.Customize_tblDirClientSource(modelBuilder);

			this.Map_tblDirClientVracenaPosta(modelBuilder);
			this.Customize_tblDirClientVracenaPosta(modelBuilder);

			this.Map_tblDirNkd2007(modelBuilder);
			this.Customize_tblDirNkd2007(modelBuilder);

			this.Map_tblDirPrikazStatus(modelBuilder);
			this.Customize_tblDirPrikazStatus(modelBuilder);

			this.Map_tblDirRegistration(modelBuilder);
			this.Customize_tblDirRegistration(modelBuilder);

			this.Map_tblFiskalRacunZahtjevLog(modelBuilder);
			this.Customize_tblFiskalRacunZahtjevLog(modelBuilder);

			this.Map_tblPorezPdv(modelBuilder);
			this.Customize_tblPorezPdv(modelBuilder);

			this.Map_tblPorezPdvPostotak(modelBuilder);
			this.Customize_tblPorezPdvPostotak(modelBuilder);

			this.Map_tblPorezPotrosnja(modelBuilder);
			this.Customize_tblPorezPotrosnja(modelBuilder);

			this.Map_tblPorezPotrosnjaPostotak(modelBuilder);
			this.Customize_tblPorezPotrosnjaPostotak(modelBuilder);

			this.Map_tblSocialMember(modelBuilder);
			this.Customize_tblSocialMember(modelBuilder);

			this.Map_tblSocialMemberStatus(modelBuilder);
			this.Customize_tblSocialMemberStatus(modelBuilder);

			this.Map_tblSocialProvider(modelBuilder);
			this.Customize_tblSocialProvider(modelBuilder);

			this.Map_tblWeatherCity(modelBuilder);
			this.Customize_tblWeatherCity(modelBuilder);

			this.Map_tblWeatherDayInfo(modelBuilder);
			this.Customize_tblWeatherDayInfo(modelBuilder);

			this.Map_tblWeatherInfo(modelBuilder);
			this.Customize_tblWeatherInfo(modelBuilder);

			this.Map_tblWeatherKind(modelBuilder);
			this.Customize_tblWeatherKind(modelBuilder);

			this.Map_viewBookkeepingFiduciaExport(modelBuilder);
			this.Customize_viewBookkeepingFiduciaExport(modelBuilder);

			this.Map_viewBookkeepingSynesisExport(modelBuilder);
			this.Customize_viewBookkeepingSynesisExport(modelBuilder);

			this.Map_viewRandom(modelBuilder);
			this.Customize_viewRandom(modelBuilder);

			RelationshipsMapping(modelBuilder);
			CustomizeMapping(ref modelBuilder);
		}

		#endregion

		#region TablesMappingDetails

		#region tblAppCache
		private void Map_tblAppCache(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<tblAppCache>().ToTable("tblAppCache", "dbo");
			modelBuilder.Entity<tblAppCache>().HasKey(x=>x.CacheKey);
			modelBuilder.Entity<tblAppCache>().Property(x=>x.CacheKey).HasColumnName("CacheKey").HasColumnType("VarChar(900)").IsRequired().ValueGeneratedNever().HasMaxLength(900);
			modelBuilder.Entity<tblAppCache>().Property(x=>x.InsertionDate).HasColumnName("InsertionDate").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblAppCache>().Property(x=>x.ExpirationDate).HasColumnName("ExpirationDate").HasColumnType("DateTime").ValueGeneratedNever();
			modelBuilder.Entity<tblAppCache>().Property(x=>x.CachedValue).HasColumnName("CachedValue").HasColumnType("VarBinary(MAX)").ValueGeneratedNever();
		}

		partial void Customize_tblAppCache(ModelBuilder modelBuilder);
		#endregion

		#region tblAppConfig
		private void Map_tblAppConfig(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<tblAppConfig>().ToTable("tblAppConfig", "dbo");
			modelBuilder.Entity<tblAppConfig>().HasKey(x=>x.AppConfigID);
			modelBuilder.Entity<tblAppConfig>().Property(x=>x.AppConfigID).HasColumnName("AppConfigID").HasColumnType("Int").IsRequired().ValueGeneratedOnAdd();
			modelBuilder.Entity<tblAppConfig>().Property(x=>x.GroupName).HasColumnName("GroupName").HasColumnType("VarChar(50)").IsRequired().ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<tblAppConfig>().Property(x=>x.IsActive).HasColumnName("IsActive").HasColumnType("Bit").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblAppConfig>().Property(x=>x.IsDefault).HasColumnName("IsDefault").HasColumnType("Bit").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblAppConfig>().Property(x=>x.Note).HasColumnName("Note").HasColumnType("NVarChar(500)").ValueGeneratedNever().HasMaxLength(500);
			modelBuilder.Entity<tblAppConfig>().Property(x=>x.SmtpHost).HasColumnName("SmtpHost").HasColumnType("VarChar(100)").ValueGeneratedNever().HasMaxLength(100);
			modelBuilder.Entity<tblAppConfig>().Property(x=>x.SmtpPort).HasColumnName("SmtpPort").HasColumnType("Int").ValueGeneratedNever();
			modelBuilder.Entity<tblAppConfig>().Property(x=>x.SmtpSSL).HasColumnName("SmtpSSL").HasColumnType("Bit").ValueGeneratedNever();
			modelBuilder.Entity<tblAppConfig>().Property(x=>x.SmtpUsername).HasColumnName("SmtpUsername").HasColumnType("NVarChar(50)").ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<tblAppConfig>().Property(x=>x.SmtpPassword).HasColumnName("SmtpPassword").HasColumnType("NVarChar(50)").ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<tblAppConfig>().Property(x=>x.DefaultEmailFrom).HasColumnName("DefaultEmailFrom").HasColumnType("VarChar(100)").ValueGeneratedNever().HasMaxLength(100);
			modelBuilder.Entity<tblAppConfig>().Property(x=>x.DefaultEmailTo).HasColumnName("DefaultEmailTo").HasColumnType("VarChar(100)").ValueGeneratedNever().HasMaxLength(100);
			modelBuilder.Entity<tblAppConfig>().Property(x=>x.ContactFormEmailTo).HasColumnName("ContactFormEmailTo").HasColumnType("VarChar(100)").ValueGeneratedNever().HasMaxLength(100);
		}

		partial void Customize_tblAppConfig(ModelBuilder modelBuilder);
		#endregion

		#region tblAppMember
		private void Map_tblAppMember(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<tblAppMember>().ToTable("tblAppMember", "dbo");
			modelBuilder.Entity<tblAppMember>().HasKey(x=>x.AppMemberID);
			modelBuilder.Entity<tblAppMember>().Property(x=>x.AppMemberID).HasColumnName("AppMemberID").HasColumnType("BigInt").IsRequired().ValueGeneratedOnAdd();
			modelBuilder.Entity<tblAppMember>().Property(x=>x.AppMemberStatusID).HasColumnName("AppMemberStatusID").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblAppMember>().Property(x=>x.MSISDN).HasColumnName("MSISDN").HasColumnType("VarChar(15)").ValueGeneratedNever().HasMaxLength(15);
			modelBuilder.Entity<tblAppMember>().Property(x=>x.FacebookId).HasColumnName("FacebookId").HasColumnType("VarChar(50)").ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<tblAppMember>().Property(x=>x.GoogleId).HasColumnName("GoogleId").HasColumnType("VarChar(50)").ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<tblAppMember>().Property(x=>x.Email).HasColumnName("Email").HasColumnType("VarChar(150)").ValueGeneratedNever().HasMaxLength(150);
			modelBuilder.Entity<tblAppMember>().Property(x=>x.Data2).HasColumnName("Data2").HasColumnType("NVarChar(200)").ValueGeneratedNever().HasMaxLength(200);
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
			modelBuilder.Entity<tblAppMember>().Property(x=>x.ReferentNote).HasColumnName("ReferentNote").HasColumnType("NVarChar(1000)").ValueGeneratedNever().HasMaxLength(1000);
			modelBuilder.Entity<tblAppMember>().Property(x=>x.BillFirmaID).HasColumnName("BillFirmaID").HasColumnType("BigInt").ValueGeneratedNever();
			modelBuilder.Entity<tblAppMember>().Property(x=>x.BillOperatorID).HasColumnName("BillOperatorID").HasColumnType("BigInt").ValueGeneratedNever();
		}

		partial void Customize_tblAppMember(ModelBuilder modelBuilder);
		#endregion

		#region tblAppMemberPermission
		private void Map_tblAppMemberPermission(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<tblAppMemberPermission>().ToTable("tblAppMemberPermission", "dbo");
			modelBuilder.Entity<tblAppMemberPermission>().HasKey(x=>x.AppMemberID);
			modelBuilder.Entity<tblAppMemberPermission>().Property(x=>x.AppMemberID).HasColumnName("AppMemberID").HasColumnType("BigInt").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblAppMemberPermission>().Property(x=>x.IsActive).HasColumnName("IsActive").HasColumnType("Bit").ValueGeneratedNever();
			modelBuilder.Entity<tblAppMemberPermission>().Property(x=>x.WritePermission).HasColumnName("WritePermission").HasColumnType("Bit").ValueGeneratedNever();
			modelBuilder.Entity<tblAppMemberPermission>().Property(x=>x.ArizonaReferenti).HasColumnName("ArizonaReferenti").HasColumnType("Bit").ValueGeneratedNever();
			modelBuilder.Entity<tblAppMemberPermission>().Property(x=>x.PosCompanies).HasColumnName("PosCompanies").HasColumnType("Bit").ValueGeneratedNever();
			modelBuilder.Entity<tblAppMemberPermission>().Property(x=>x.AdminTools).HasColumnName("AdminTools").HasColumnType("Bit").ValueGeneratedNever();
			modelBuilder.Entity<tblAppMemberPermission>().Property(x=>x.PosMain).HasColumnName("PosMain").HasColumnType("Bit").ValueGeneratedNever();
			modelBuilder.Entity<tblAppMemberPermission>().Property(x=>x.PosOperators).HasColumnName("PosOperators").HasColumnType("Bit").ValueGeneratedNever();
			modelBuilder.Entity<tblAppMemberPermission>().Property(x=>x.PosCompany).HasColumnName("PosCompany").HasColumnType("Bit").ValueGeneratedNever();
			modelBuilder.Entity<tblAppMemberPermission>().Property(x=>x.PosPoslovniProstori).HasColumnName("PosPoslovniProstori").HasColumnType("Bit").ValueGeneratedNever();
			modelBuilder.Entity<tblAppMemberPermission>().Property(x=>x.PosNaplatniUredjaji).HasColumnName("PosNaplatniUredjaji").HasColumnType("Bit").ValueGeneratedNever();
			modelBuilder.Entity<tblAppMemberPermission>().Property(x=>x.PosDnevniObracun).HasColumnName("PosDnevniObracun").HasColumnType("Bit").ValueGeneratedNever();
			modelBuilder.Entity<tblAppMemberPermission>().Property(x=>x.PosEvidencijaGotovine).HasColumnName("PosEvidencijaGotovine").HasColumnType("Bit").ValueGeneratedNever();
			modelBuilder.Entity<tblAppMemberPermission>().Property(x=>x.PosPorezneGrupe).HasColumnName("PosPorezneGrupe").HasColumnType("Bit").ValueGeneratedNever();
			modelBuilder.Entity<tblAppMemberPermission>().Property(x=>x.PosProducts).HasColumnName("PosProducts").HasColumnType("Bit").ValueGeneratedNever();
			modelBuilder.Entity<tblAppMemberPermission>().Property(x=>x.Documents).HasColumnName("Documents").HasColumnType("Bit").ValueGeneratedNever();
			modelBuilder.Entity<tblAppMemberPermission>().Property(x=>x.Payments).HasColumnName("Payments").HasColumnType("Bit").ValueGeneratedNever();
			modelBuilder.Entity<tblAppMemberPermission>().Property(x=>x.JobAdverts).HasColumnName("JobAdverts").HasColumnType("Bit").ValueGeneratedNever();
			modelBuilder.Entity<tblAppMemberPermission>().Property(x=>x.JobCalendar).HasColumnName("JobCalendar").HasColumnType("Bit").ValueGeneratedNever();
			modelBuilder.Entity<tblAppMemberPermission>().Property(x=>x.JobApplicants).HasColumnName("JobApplicants").HasColumnType("Bit").ValueGeneratedNever();
			modelBuilder.Entity<tblAppMemberPermission>().Property(x=>x.JobTemplates).HasColumnName("JobTemplates").HasColumnType("Bit").ValueGeneratedNever();
			modelBuilder.Entity<tblAppMemberPermission>().Property(x=>x.BillsExport).HasColumnName("BillsExport").HasColumnType("Bit").ValueGeneratedNever();
			modelBuilder.Entity<tblAppMemberPermission>().Property(x=>x.SynesisExport).HasColumnName("SynesisExport").HasColumnType("Bit").ValueGeneratedNever();
			modelBuilder.Entity<tblAppMemberPermission>().Property(x=>x.FiduciaExport).HasColumnName("FiduciaExport").HasColumnType("Bit").ValueGeneratedNever();
			modelBuilder.Entity<tblAppMemberPermission>().Property(x=>x.Printing).HasColumnName("Printing").HasColumnType("Bit").ValueGeneratedNever();
			modelBuilder.Entity<tblAppMemberPermission>().Property(x=>x.PrintingHistory).HasColumnName("PrintingHistory").HasColumnType("Bit").ValueGeneratedNever();
			modelBuilder.Entity<tblAppMemberPermission>().Property(x=>x.Balances).HasColumnName("Balances").HasColumnType("Bit").ValueGeneratedNever();
			modelBuilder.Entity<tblAppMemberPermission>().Property(x=>x.Transactions).HasColumnName("Transactions").HasColumnType("Bit").ValueGeneratedNever();
			modelBuilder.Entity<tblAppMemberPermission>().Property(x=>x.FirmaCalls).HasColumnName("FirmaCalls").HasColumnType("Bit").ValueGeneratedNever();
			modelBuilder.Entity<tblAppMemberPermission>().Property(x=>x.FirmaTools).HasColumnName("FirmaTools").HasColumnType("Bit").ValueGeneratedNever();
			modelBuilder.Entity<tblAppMemberPermission>().Property(x=>x.GeolocationTools).HasColumnName("GeolocationTools").HasColumnType("Bit").ValueGeneratedNever();
			modelBuilder.Entity<tblAppMemberPermission>().Property(x=>x.CrmOglasnik).HasColumnName("CrmOglasnik").HasColumnType("Bit").ValueGeneratedNever();
			modelBuilder.Entity<tblAppMemberPermission>().Property(x=>x.CrmRadnoVrijeme).HasColumnName("CrmRadnoVrijeme").HasColumnType("Bit").ValueGeneratedNever();
			modelBuilder.Entity<tblAppMemberPermission>().Property(x=>x.KnjigovodstvoObradilo).HasColumnName("KnjigovodstvoObradilo").HasColumnType("Bit").ValueGeneratedNever();
		}

		partial void Customize_tblAppMemberPermission(ModelBuilder modelBuilder);
		#endregion

		#region tblAppMemberPicture
		private void Map_tblAppMemberPicture(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<tblAppMemberPicture>().ToTable("tblAppMemberPicture", "dbo");
			modelBuilder.Entity<tblAppMemberPicture>().HasKey(x=>x.AppMemberPictureID);
			modelBuilder.Entity<tblAppMemberPicture>().Property(x=>x.AppMemberPictureID).HasColumnName("AppMemberPictureID").HasColumnType("BigInt").IsRequired().ValueGeneratedOnAdd();
			modelBuilder.Entity<tblAppMemberPicture>().Property(x=>x.AppMemberID).HasColumnName("AppMemberID").HasColumnType("BigInt").ValueGeneratedNever();
			modelBuilder.Entity<tblAppMemberPicture>().Property(x=>x.InsertionDate).HasColumnName("InsertionDate").HasColumnType("DateTime").ValueGeneratedNever();
			modelBuilder.Entity<tblAppMemberPicture>().Property(x=>x.FileName).HasColumnName("FileName").HasColumnType("NVarChar(500)").ValueGeneratedNever().HasMaxLength(500);
			modelBuilder.Entity<tblAppMemberPicture>().Property(x=>x.ImageData).HasColumnName("ImageData").HasColumnType("VarBinary(MAX)").ValueGeneratedNever();
			modelBuilder.Entity<tblAppMemberPicture>().Property(x=>x.ImageMimeType).HasColumnName("ImageMimeType").HasColumnType("VarChar(20)").ValueGeneratedNever().HasMaxLength(20);
			modelBuilder.Entity<tblAppMemberPicture>().Property(x=>x.ThumbData).HasColumnName("ThumbData").HasColumnType("VarBinary(MAX)").ValueGeneratedNever();
			modelBuilder.Entity<tblAppMemberPicture>().Property(x=>x.ThumbMimeType).HasColumnName("ThumbMimeType").HasColumnType("VarChar(20)").ValueGeneratedNever().HasMaxLength(20);
		}

		partial void Customize_tblAppMemberPicture(ModelBuilder modelBuilder);
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

		#region tblAppNewsletter
		private void Map_tblAppNewsletter(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<tblAppNewsletter>().ToTable("tblAppNewsletter", "dbo");
			modelBuilder.Entity<tblAppNewsletter>().HasKey(x=>x.Email);
			modelBuilder.Entity<tblAppNewsletter>().Property(x=>x.Email).HasColumnName("Email").HasColumnType("VarChar(150)").IsRequired().ValueGeneratedNever().HasMaxLength(150);
			modelBuilder.Entity<tblAppNewsletter>().Property(x=>x.InsertionDate).HasColumnName("InsertionDate").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblAppNewsletter>().Property(x=>x.SubscribeDate).HasColumnName("SubscribeDate").HasColumnType("DateTime").ValueGeneratedNever();
			modelBuilder.Entity<tblAppNewsletter>().Property(x=>x.UnsubscribeDate).HasColumnName("UnsubscribeDate").HasColumnType("DateTime").ValueGeneratedNever();
			modelBuilder.Entity<tblAppNewsletter>().Property(x=>x.IsSubscribed).HasColumnName("IsSubscribed").HasColumnType("Bit").IsRequired().ValueGeneratedNever();
		}

		partial void Customize_tblAppNewsletter(ModelBuilder modelBuilder);
		#endregion

		#region tblBanka
		private void Map_tblBanka(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<tblBanka>().ToTable("tblBanka", "dbo");
			modelBuilder.Entity<tblBanka>().HasKey(x=>x.BankaID);
			modelBuilder.Entity<tblBanka>().Property(x=>x.BankaID).HasColumnName("BankaID").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblBanka>().Property(x=>x.Naziv).HasColumnName("Naziv").HasColumnType("NVarChar(500)").IsRequired().ValueGeneratedNever().HasMaxLength(500);
			modelBuilder.Entity<tblBanka>().Property(x=>x.IbanPrefix).HasColumnName("IbanPrefix").HasColumnType("VarChar(50)").ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<tblBanka>().Property(x=>x.Swift).HasColumnName("Swift").HasColumnType("VarChar(50)").ValueGeneratedNever().HasMaxLength(50);
		}

		partial void Customize_tblBanka(ModelBuilder modelBuilder);
		#endregion

		#region tblBankaPromet
		private void Map_tblBankaPromet(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<tblBankaPromet>().ToTable("tblBankaPromet", "dbo");
			modelBuilder.Entity<tblBankaPromet>().HasKey(x=>x.BankaPrometID);
			modelBuilder.Entity<tblBankaPromet>().Property(x=>x.BankaPrometID).HasColumnName("BankaPrometID").HasColumnType("BigInt").IsRequired().ValueGeneratedOnAdd();
			modelBuilder.Entity<tblBankaPromet>().Property(x=>x.BillFirmaTransakcijskiRacunID).HasColumnName("BillFirmaTransakcijskiRacunID").HasColumnType("BigInt").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblBankaPromet>().Property(x=>x.AppMemberID).HasColumnName("AppMemberID").HasColumnType("BigInt").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblBankaPromet>().Property(x=>x.InsertionDate).HasColumnName("InsertionDate").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblBankaPromet>().Property(x=>x.DatumTransakcije).HasColumnName("DatumTransakcije").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblBankaPromet>().Property(x=>x.PlatiteljPrimatelj).HasColumnName("PlatiteljPrimatelj").HasColumnType("NVarChar(500)").ValueGeneratedNever().HasMaxLength(500);
			modelBuilder.Entity<tblBankaPromet>().Property(x=>x.IbanPlatiteljaPrimatelja).HasColumnName("IbanPlatiteljaPrimatelja").HasColumnType("VarChar(100)").ValueGeneratedNever().HasMaxLength(100);
			modelBuilder.Entity<tblBankaPromet>().Property(x=>x.PlatiteljModel).HasColumnName("PlatiteljModel").HasColumnType("VarChar(50)").ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<tblBankaPromet>().Property(x=>x.PlatiteljPozivNaBroj).HasColumnName("PlatiteljPozivNaBroj").HasColumnType("VarChar(100)").ValueGeneratedNever().HasMaxLength(100);
			modelBuilder.Entity<tblBankaPromet>().Property(x=>x.PrimateljModel).HasColumnName("PrimateljModel").HasColumnType("VarChar(50)").ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<tblBankaPromet>().Property(x=>x.PrimateljPozivNaBroj).HasColumnName("PrimateljPozivNaBroj").HasColumnType("VarChar(100)").ValueGeneratedNever().HasMaxLength(100);
			modelBuilder.Entity<tblBankaPromet>().Property(x=>x.Mjesto).HasColumnName("Mjesto").HasColumnType("NVarChar(500)").ValueGeneratedNever().HasMaxLength(500);
			modelBuilder.Entity<tblBankaPromet>().Property(x=>x.OpisPlacanja).HasColumnName("OpisPlacanja").HasColumnType("NVarChar(500)").ValueGeneratedNever().HasMaxLength(500);
			modelBuilder.Entity<tblBankaPromet>().Property(x=>x.RedniBroj).HasColumnName("RedniBroj").HasColumnType("Int").ValueGeneratedNever();
			modelBuilder.Entity<tblBankaPromet>().Property(x=>x.SifraNamjene).HasColumnName("SifraNamjene").HasColumnType("NVarChar(100)").ValueGeneratedNever().HasMaxLength(100);
			modelBuilder.Entity<tblBankaPromet>().Property(x=>x.Isplata).HasColumnName("Isplata").HasColumnType("Money").ValueGeneratedNever();
			modelBuilder.Entity<tblBankaPromet>().Property(x=>x.Uplata).HasColumnName("Uplata").HasColumnType("Money").ValueGeneratedNever();
			modelBuilder.Entity<tblBankaPromet>().Property(x=>x.Stanje).HasColumnName("Stanje").HasColumnType("Money").ValueGeneratedNever();
			modelBuilder.Entity<tblBankaPromet>().Property(x=>x.ReferencaPlacanja).HasColumnName("ReferencaPlacanja").HasColumnType("VarChar(100)").ValueGeneratedNever().HasMaxLength(100);
			modelBuilder.Entity<tblBankaPromet>().Property(x=>x.Napomena).HasColumnName("Napomena").HasColumnType("NVarChar(500)").ValueGeneratedNever().HasMaxLength(500);
			modelBuilder.Entity<tblBankaPromet>().Property(x=>x.PoreznaOsnovica).HasColumnName("PoreznaOsnovica").HasColumnType("Money").ValueGeneratedNever();
			modelBuilder.Entity<tblBankaPromet>().Property(x=>x.Pdv).HasColumnName("Pdv").HasColumnType("Money").ValueGeneratedNever();
			modelBuilder.Entity<tblBankaPromet>().Property(x=>x.BankaPrometVrstaID).HasColumnName("BankaPrometVrstaID").HasColumnType("Int").ValueGeneratedNever();
			modelBuilder.Entity<tblBankaPromet>().Property(x=>x.DatumRacuna).HasColumnName("DatumRacuna").HasColumnType("DateTime").ValueGeneratedNever();
			modelBuilder.Entity<tblBankaPromet>().Property(x=>x.KnjigovodstvoObradilo).HasColumnName("KnjigovodstvoObradilo").HasColumnType("DateTime").ValueGeneratedNever();
		}

		partial void Customize_tblBankaPromet(ModelBuilder modelBuilder);
		#endregion

		#region tblBankaPrometDocument
		private void Map_tblBankaPrometDocument(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<tblBankaPrometDocument>().ToTable("tblBankaPrometDocument", "dbo");
			modelBuilder.Entity<tblBankaPrometDocument>().HasKey(x=>x.BankaPrometDocumentID);
			modelBuilder.Entity<tblBankaPrometDocument>().Property(x=>x.BankaPrometDocumentID).HasColumnName("BankaPrometDocumentID").HasColumnType("BigInt").IsRequired().ValueGeneratedOnAdd();
			modelBuilder.Entity<tblBankaPrometDocument>().Property(x=>x.BankaPrometID).HasColumnName("BankaPrometID").HasColumnType("BigInt").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblBankaPrometDocument>().Property(x=>x.FileName).HasColumnName("FileName").HasColumnType("NVarChar(100)").ValueGeneratedNever().HasMaxLength(100);
			modelBuilder.Entity<tblBankaPrometDocument>().Property(x=>x.FileContent).HasColumnName("FileContent").HasColumnType("VarBinary(MAX)").ValueGeneratedNever();
		}

		partial void Customize_tblBankaPrometDocument(ModelBuilder modelBuilder);
		#endregion

		#region tblBankaPrometVrsta
		private void Map_tblBankaPrometVrsta(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<tblBankaPrometVrsta>().ToTable("tblBankaPrometVrsta", "dbo");
			modelBuilder.Entity<tblBankaPrometVrsta>().HasKey(x=>x.BankaPrometVrstaID);
			modelBuilder.Entity<tblBankaPrometVrsta>().Property(x=>x.BankaPrometVrstaID).HasColumnName("BankaPrometVrstaID").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblBankaPrometVrsta>().Property(x=>x.Name).HasColumnName("Name").HasColumnType("NVarChar(150)").IsRequired().ValueGeneratedNever().HasMaxLength(150);
			modelBuilder.Entity<tblBankaPrometVrsta>().Property(x=>x.IsPrihod).HasColumnName("IsPrihod").HasColumnType("Bit").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblBankaPrometVrsta>().Property(x=>x.IsRashod).HasColumnName("IsRashod").HasColumnType("Bit").IsRequired().ValueGeneratedNever();
		}

		partial void Customize_tblBankaPrometVrsta(ModelBuilder modelBuilder);
		#endregion

		#region tblBankaValuta
		private void Map_tblBankaValuta(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<tblBankaValuta>().ToTable("tblBankaValuta", "dbo");
			modelBuilder.Entity<tblBankaValuta>().HasKey(x=>x.BankaValutaID);
			modelBuilder.Entity<tblBankaValuta>().Property(x=>x.BankaValutaID).HasColumnName("BankaValutaID").HasColumnType("Int").IsRequired().ValueGeneratedOnAdd();
			modelBuilder.Entity<tblBankaValuta>().Property(x=>x.DrzavaNaziv).HasColumnName("DrzavaNaziv").HasColumnType("NVarChar(100)").ValueGeneratedNever().HasMaxLength(100);
			modelBuilder.Entity<tblBankaValuta>().Property(x=>x.DrzavaISO).HasColumnName("DrzavaISO").HasColumnType("VarChar(50)").ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<tblBankaValuta>().Property(x=>x.SifraValute).HasColumnName("SifraValute").HasColumnType("VarChar(50)").ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<tblBankaValuta>().Property(x=>x.Valuta).HasColumnName("Valuta").HasColumnType("VarChar(50)").ValueGeneratedNever().HasMaxLength(50);
		}

		partial void Customize_tblBankaValuta(ModelBuilder modelBuilder);
		#endregion

		#region tblBankaValutaTecaj
		private void Map_tblBankaValutaTecaj(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<tblBankaValutaTecaj>().ToTable("tblBankaValutaTecaj", "dbo");
			modelBuilder.Entity<tblBankaValutaTecaj>().HasKey(x=>x.BankaValutaTecajID);
			modelBuilder.Entity<tblBankaValutaTecaj>().Property(x=>x.BankaValutaTecajID).HasColumnName("BankaValutaTecajID").HasColumnType("BigInt").IsRequired().ValueGeneratedOnAdd();
			modelBuilder.Entity<tblBankaValutaTecaj>().Property(x=>x.OsnovnaValuta).HasColumnName("OsnovnaValuta").HasColumnType("VarChar(10)").IsRequired().ValueGeneratedNever().HasMaxLength(10);
			modelBuilder.Entity<tblBankaValutaTecaj>().Property(x=>x.Valuta).HasColumnName("Valuta").HasColumnType("VarChar(10)").IsRequired().ValueGeneratedNever().HasMaxLength(10);
			modelBuilder.Entity<tblBankaValutaTecaj>().Property(x=>x.DatumPrimjene).HasColumnName("DatumPrimjene").HasColumnType("SmallDateTime").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblBankaValutaTecaj>().Property(x=>x.JedinicniIznos).HasColumnName("JedinicniIznos").HasColumnType("Decimal(18,10)").ValueGeneratedNever().HasMaxLength(18);
			modelBuilder.Entity<tblBankaValutaTecaj>().Property(x=>x.KupovniTecaj).HasColumnName("KupovniTecaj").HasColumnType("Decimal(18,10)").ValueGeneratedNever().HasMaxLength(18);
			modelBuilder.Entity<tblBankaValutaTecaj>().Property(x=>x.SrednjiTecaj).HasColumnName("SrednjiTecaj").HasColumnType("Decimal(18,10)").ValueGeneratedNever().HasMaxLength(18);
			modelBuilder.Entity<tblBankaValutaTecaj>().Property(x=>x.ProdajniTecaj).HasColumnName("ProdajniTecaj").HasColumnType("Decimal(18,10)").ValueGeneratedNever().HasMaxLength(18);
		}

		partial void Customize_tblBankaValutaTecaj(ModelBuilder modelBuilder);
		#endregion

		#region tblBillCategory
		private void Map_tblBillCategory(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<tblBillCategory>().ToTable("tblBillCategory", "dbo");
			modelBuilder.Entity<tblBillCategory>().HasKey(x=>x.BillCategoryID);
			modelBuilder.Entity<tblBillCategory>().Property(x=>x.BillCategoryID).HasColumnName("BillCategoryID").HasColumnType("BigInt").IsRequired().ValueGeneratedOnAdd();
			modelBuilder.Entity<tblBillCategory>().Property(x=>x.ParentBillCategoryID).HasColumnName("ParentBillCategoryID").HasColumnType("BigInt").ValueGeneratedNever();
			modelBuilder.Entity<tblBillCategory>().Property(x=>x.BillPoslovniProstorID).HasColumnName("BillPoslovniProstorID").HasColumnType("BigInt").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblBillCategory>().Property(x=>x.Naziv).HasColumnName("Naziv").HasColumnType("NVarChar(250)").IsRequired().ValueGeneratedNever().HasMaxLength(250);
			modelBuilder.Entity<tblBillCategory>().Property(x=>x.Ordinal).HasColumnName("Ordinal").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblBillCategory>().Property(x=>x.IsPosVisible).HasColumnName("IsPosVisible").HasColumnType("Bit").IsRequired().ValueGeneratedNever();
		}

		partial void Customize_tblBillCategory(ModelBuilder modelBuilder);
		#endregion

		#region tblBillClient
		private void Map_tblBillClient(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<tblBillClient>().ToTable("tblBillClient", "dbo");
			modelBuilder.Entity<tblBillClient>().HasKey(x=>x.BillClientID);
			modelBuilder.Entity<tblBillClient>().Property(x=>x.BillClientID).HasColumnName("BillClientID").HasColumnType("BigInt").IsRequired().ValueGeneratedOnAdd();
			modelBuilder.Entity<tblBillClient>().Property(x=>x.InsertionDate).HasColumnName("InsertionDate").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblBillClient>().Property(x=>x.BillFirmaID).HasColumnName("BillFirmaID").HasColumnType("BigInt").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblBillClient>().Property(x=>x.DirClientID).HasColumnName("DirClientID").HasColumnType("BigInt").ValueGeneratedNever();
			modelBuilder.Entity<tblBillClient>().Property(x=>x.MaticniBroj).HasColumnName("MaticniBroj").HasColumnType("VarChar(20)").ValueGeneratedNever().HasMaxLength(20);
			modelBuilder.Entity<tblBillClient>().Property(x=>x.PorezniBroj).HasColumnName("PorezniBroj").HasColumnType("VarChar(20)").ValueGeneratedNever().HasMaxLength(20);
			modelBuilder.Entity<tblBillClient>().Property(x=>x.Naziv).HasColumnName("Naziv").HasColumnType("NVarChar(250)").ValueGeneratedNever().HasMaxLength(250);
			modelBuilder.Entity<tblBillClient>().Property(x=>x.Adresa).HasColumnName("Adresa").HasColumnType("NVarChar(250)").ValueGeneratedNever().HasMaxLength(250);
			modelBuilder.Entity<tblBillClient>().Property(x=>x.Naselje).HasColumnName("Naselje").HasColumnType("NVarChar(250)").ValueGeneratedNever().HasMaxLength(250);
			modelBuilder.Entity<tblBillClient>().Property(x=>x.PostanskiBroj).HasColumnName("PostanskiBroj").HasColumnType("NVarChar(50)").ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<tblBillClient>().Property(x=>x.PostanskiUred).HasColumnName("PostanskiUred").HasColumnType("NVarChar(250)").ValueGeneratedNever().HasMaxLength(250);
			modelBuilder.Entity<tblBillClient>().Property(x=>x.OdgovornaOsoba).HasColumnName("OdgovornaOsoba").HasColumnType("NVarChar(100)").ValueGeneratedNever().HasMaxLength(100);
			modelBuilder.Entity<tblBillClient>().Property(x=>x.IsVlasnik).HasColumnName("IsVlasnik").HasColumnType("Bit").ValueGeneratedNever();
			modelBuilder.Entity<tblBillClient>().Property(x=>x.IBAN).HasColumnName("IBAN").HasColumnType("VarChar(50)").ValueGeneratedNever().HasMaxLength(50);
		}

		partial void Customize_tblBillClient(ModelBuilder modelBuilder);
		#endregion

		#region tblBillClientFullText
		private void Map_tblBillClientFullText(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<tblBillClientFullText>().ToTable("tblBillClientFullText", "dbo");
			modelBuilder.Entity<tblBillClientFullText>().HasKey(x=>x.BillClientID);
			modelBuilder.Entity<tblBillClientFullText>().Property(x=>x.BillClientID).HasColumnName("BillClientID").HasColumnType("BigInt").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblBillClientFullText>().Property(x=>x.fullTextIndexBasic).HasColumnName("fullTextIndexBasic").HasColumnType("NVarChar(MAX)").ValueGeneratedNever();
		}

		partial void Customize_tblBillClientFullText(ModelBuilder modelBuilder);
		#endregion

		#region tblBillDocument
		private void Map_tblBillDocument(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<tblBillDocument>().ToTable("tblBillDocument", "dbo");
			modelBuilder.Entity<tblBillDocument>().HasKey(x=>x.BillDocumentID);
			modelBuilder.Entity<tblBillDocument>().Property(x=>x.BillDocumentID).HasColumnName("BillDocumentID").HasColumnType("BigInt").IsRequired().ValueGeneratedOnAdd();
			modelBuilder.Entity<tblBillDocument>().Property(x=>x.BillClientID).HasColumnName("BillClientID").HasColumnType("BigInt").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblBillDocument>().Property(x=>x.ParentBillDocumentID).HasColumnName("ParentBillDocumentID").HasColumnType("BigInt").ValueGeneratedNever();
			modelBuilder.Entity<tblBillDocument>().Property(x=>x.BillNaplatniUredjajID).HasColumnName("BillNaplatniUredjajID").HasColumnType("BigInt").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblBillDocument>().Property(x=>x.RedniBroj).HasColumnName("RedniBroj").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblBillDocument>().Property(x=>x.ModelPlacanja).HasColumnName("ModelPlacanja").HasColumnType("VarChar(10)").IsRequired().ValueGeneratedNever().HasMaxLength(10);
			modelBuilder.Entity<tblBillDocument>().Property(x=>x.PozivNaBroj).HasColumnName("PozivNaBroj").HasColumnType("VarChar(50)").IsRequired().ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<tblBillDocument>().Property(x=>x.DatumDokumenta).HasColumnName("DatumDokumenta").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblBillDocument>().Property(x=>x.DatumValute).HasColumnName("DatumValute").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblBillDocument>().Property(x=>x.DatumDospijeca).HasColumnName("DatumDospijeca").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblBillDocument>().Property(x=>x.BrojDanaZaUplatu).HasColumnName("BrojDanaZaUplatu").HasColumnType("Int").ValueGeneratedNever();
			modelBuilder.Entity<tblBillDocument>().Property(x=>x.DatumUplate).HasColumnName("DatumUplate").HasColumnType("DateTime").ValueGeneratedNever();
			modelBuilder.Entity<tblBillDocument>().Property(x=>x.PoslanKupcuDatum).HasColumnName("PoslanKupcuDatum").HasColumnType("DateTime").ValueGeneratedNever();
			modelBuilder.Entity<tblBillDocument>().Property(x=>x.ZKI).HasColumnName("ZKI").HasColumnType("VarChar(100)").ValueGeneratedNever().HasMaxLength(100);
			modelBuilder.Entity<tblBillDocument>().Property(x=>x.JIR).HasColumnName("JIR").HasColumnType("VarChar(100)").ValueGeneratedNever().HasMaxLength(100);
			modelBuilder.Entity<tblBillDocument>().Property(x=>x.VariantID).HasColumnName("VariantID").HasColumnType("Int").ValueGeneratedNever();
			modelBuilder.Entity<tblBillDocument>().Property(x=>x.IsInPdvSustav).HasColumnName("IsInPdvSustav").HasColumnType("Bit").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblBillDocument>().Property(x=>x.AppMemberID).HasColumnName("AppMemberID").HasColumnType("BigInt").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblBillDocument>().Property(x=>x.IsDeleted).HasColumnName("IsDeleted").HasColumnType("Bit").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblBillDocument>().Property(x=>x.Napomena).HasColumnName("Napomena").HasColumnType("NVarChar(500)").ValueGeneratedNever().HasMaxLength(500);
			modelBuilder.Entity<tblBillDocument>().Property(x=>x.FiskalTryCount).HasColumnName("FiskalTryCount").HasColumnType("Int").ValueGeneratedNever();
			modelBuilder.Entity<tblBillDocument>().Property(x=>x.IsFiskalizacijaRequired).HasColumnName("IsFiskalizacijaRequired").HasColumnType("Bit").IsRequired().ValueGeneratedNever();
		}

		partial void Customize_tblBillDocument(ModelBuilder modelBuilder);
		#endregion

		#region tblBillDocumentCalculated
		private void Map_tblBillDocumentCalculated(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<tblBillDocumentCalculated>().ToTable("tblBillDocumentCalculated", "dbo");
			modelBuilder.Entity<tblBillDocumentCalculated>().HasKey(x=>x.BillDocumentID);
			modelBuilder.Entity<tblBillDocumentCalculated>().Property(x=>x.BillDocumentID).HasColumnName("BillDocumentID").HasColumnType("BigInt").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblBillDocumentCalculated>().Property(x=>x.SumPoreznaOsnovica).HasColumnName("SumPoreznaOsnovica").HasColumnType("Decimal(18,8)").IsRequired().ValueGeneratedNever().HasMaxLength(18);
			modelBuilder.Entity<tblBillDocumentCalculated>().Property(x=>x.SumIznosPdva).HasColumnName("SumIznosPdva").HasColumnType("Decimal(18,8)").IsRequired().ValueGeneratedNever().HasMaxLength(18);
			modelBuilder.Entity<tblBillDocumentCalculated>().Property(x=>x.SumIznosPorezPotrosnja).HasColumnName("SumIznosPorezPotrosnja").HasColumnType("Decimal(18,8)").IsRequired().ValueGeneratedNever().HasMaxLength(18);
			modelBuilder.Entity<tblBillDocumentCalculated>().Property(x=>x.SumIznosOstaliPorez).HasColumnName("SumIznosOstaliPorez").HasColumnType("Decimal(18,8)").IsRequired().ValueGeneratedNever().HasMaxLength(18);
			modelBuilder.Entity<tblBillDocumentCalculated>().Property(x=>x.SumUkupno).HasColumnName("SumUkupno").HasColumnType("Decimal(18,8)").IsRequired().ValueGeneratedNever().HasMaxLength(18);
		}

		partial void Customize_tblBillDocumentCalculated(ModelBuilder modelBuilder);
		#endregion

		#region tblBillDocumentStavka
		private void Map_tblBillDocumentStavka(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<tblBillDocumentStavka>().ToTable("tblBillDocumentStavka", "dbo");
			modelBuilder.Entity<tblBillDocumentStavka>().HasKey(x=>x.BillDocumentStavkaID);
			modelBuilder.Entity<tblBillDocumentStavka>().Property(x=>x.BillDocumentStavkaID).HasColumnName("BillDocumentStavkaID").HasColumnType("BigInt").IsRequired().ValueGeneratedOnAdd();
			modelBuilder.Entity<tblBillDocumentStavka>().Property(x=>x.BillDocumentID).HasColumnName("BillDocumentID").HasColumnType("BigInt").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblBillDocumentStavka>().Property(x=>x.BillProductID).HasColumnName("BillProductID").HasColumnType("BigInt").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblBillDocumentStavka>().Property(x=>x.ProductNaziv).HasColumnName("ProductNaziv").HasColumnType("NVarChar(150)").IsRequired().ValueGeneratedNever().HasMaxLength(150);
			modelBuilder.Entity<tblBillDocumentStavka>().Property(x=>x.JedinicnaCijena).HasColumnName("JedinicnaCijena").HasColumnType("Money").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblBillDocumentStavka>().Property(x=>x.CijenaJeMPC).HasColumnName("CijenaJeMPC").HasColumnType("Bit").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblBillDocumentStavka>().Property(x=>x.BillMjeraID).HasColumnName("BillMjeraID").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblBillDocumentStavka>().Property(x=>x.Kolicina).HasColumnName("Kolicina").HasColumnType("Decimal(18,8)").IsRequired().ValueGeneratedNever().HasMaxLength(18);
			modelBuilder.Entity<tblBillDocumentStavka>().Property(x=>x.PopustPosto).HasColumnName("PopustPosto").HasColumnType("Money").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblBillDocumentStavka>().Property(x=>x.BillPoreznaGrupaID).HasColumnName("BillPoreznaGrupaID").HasColumnType("BigInt").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblBillDocumentStavka>().Property(x=>x.PoreznaGrupaNaziv).HasColumnName("PoreznaGrupaNaziv").HasColumnType("NVarChar(100)").IsRequired().ValueGeneratedNever().HasMaxLength(100);
			modelBuilder.Entity<tblBillDocumentStavka>().Property(x=>x.IsInPdvSustav).HasColumnName("IsInPdvSustav").HasColumnType("Bit").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblBillDocumentStavka>().Property(x=>x.PdvPosto).HasColumnName("PdvPosto").HasColumnType("Decimal(5,2)").IsRequired().ValueGeneratedNever().HasMaxLength(5);
			modelBuilder.Entity<tblBillDocumentStavka>().Property(x=>x.PorezPotrosnjaPosto).HasColumnName("PorezPotrosnjaPosto").HasColumnType("Decimal(5,2)").IsRequired().ValueGeneratedNever().HasMaxLength(5);
			modelBuilder.Entity<tblBillDocumentStavka>().Property(x=>x.OstaliPorezNaziv).HasColumnName("OstaliPorezNaziv").HasColumnType("NVarChar(50)").ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<tblBillDocumentStavka>().Property(x=>x.OstaliPorezPosto).HasColumnName("OstaliPorezPosto").HasColumnType("Decimal(5,2)").IsRequired().ValueGeneratedNever().HasMaxLength(5);
			modelBuilder.Entity<tblBillDocumentStavka>().Property(x=>x.NaknadaNaziv).HasColumnName("NaknadaNaziv").HasColumnType("NVarChar(50)").ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<tblBillDocumentStavka>().Property(x=>x.IznosNaknade).HasColumnName("IznosNaknade").HasColumnType("Money").IsRequired().ValueGeneratedNever();
		}

		partial void Customize_tblBillDocumentStavka(ModelBuilder modelBuilder);
		#endregion

		#region tblBillDocumentTip
		private void Map_tblBillDocumentTip(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<tblBillDocumentTip>().ToTable("tblBillDocumentTip", "dbo");
			modelBuilder.Entity<tblBillDocumentTip>().HasKey(x=>x.BillDocumentTipID);
			modelBuilder.Entity<tblBillDocumentTip>().Property(x=>x.BillDocumentTipID).HasColumnName("BillDocumentTipID").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblBillDocumentTip>().Property(x=>x.IsActive).HasColumnName("IsActive").HasColumnType("Bit").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblBillDocumentTip>().Property(x=>x.Ordinal).HasColumnName("Ordinal").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblBillDocumentTip>().Property(x=>x.IsDefault).HasColumnName("IsDefault").HasColumnType("Bit").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblBillDocumentTip>().Property(x=>x.PropertyName).HasColumnName("PropertyName").HasColumnType("VarChar(100)").ValueGeneratedNever().HasMaxLength(100);
			modelBuilder.Entity<tblBillDocumentTip>().Property(x=>x.IsRacunType).HasColumnName("IsRacunType").HasColumnType("Bit").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblBillDocumentTip>().Property(x=>x.IsMaloprodajniRacun).HasColumnName("IsMaloprodajniRacun").HasColumnType("Bit").IsRequired().ValueGeneratedNever();
		}

		partial void Customize_tblBillDocumentTip(ModelBuilder modelBuilder);
		#endregion

		#region tblBillDocumentVariant
		private void Map_tblBillDocumentVariant(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<tblBillDocumentVariant>().ToTable("tblBillDocumentVariant", "dbo");
			modelBuilder.Entity<tblBillDocumentVariant>().HasKey(x=>x.VariantID);
			modelBuilder.Entity<tblBillDocumentVariant>().Property(x=>x.VariantID).HasColumnName("VariantID").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblBillDocumentVariant>().Property(x=>x.MarkBillAsSent).HasColumnName("MarkBillAsSent").HasColumnType("Bit").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblBillDocumentVariant>().Property(x=>x.Name).HasColumnName("Name").HasColumnType("VarChar(255)").ValueGeneratedNever().HasMaxLength(255);
			modelBuilder.Entity<tblBillDocumentVariant>().Property(x=>x.Description).HasColumnName("Description").HasColumnType("VarChar(1000)").ValueGeneratedNever().HasMaxLength(1000);
		}

		partial void Customize_tblBillDocumentVariant(ModelBuilder modelBuilder);
		#endregion

		#region tblBillDownloadLog
		private void Map_tblBillDownloadLog(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<tblBillDownloadLog>().ToTable("tblBillDownloadLog", "dbo");
			modelBuilder.Entity<tblBillDownloadLog>().HasKey(x=>x.BillDownloadLogID);
			modelBuilder.Entity<tblBillDownloadLog>().Property(x=>x.BillDownloadLogID).HasColumnName("BillDownloadLogID").HasColumnType("BigInt").IsRequired().ValueGeneratedOnAdd();
			modelBuilder.Entity<tblBillDownloadLog>().Property(x=>x.InsertionDate).HasColumnName("InsertionDate").HasColumnType("DateTime").ValueGeneratedNever();
			modelBuilder.Entity<tblBillDownloadLog>().Property(x=>x.PorezniBroj).HasColumnName("PorezniBroj").HasColumnType("VarChar(20)").ValueGeneratedNever().HasMaxLength(20);
			modelBuilder.Entity<tblBillDownloadLog>().Property(x=>x.MaticniBroj).HasColumnName("MaticniBroj").HasColumnType("VarChar(20)").ValueGeneratedNever().HasMaxLength(20);
			modelBuilder.Entity<tblBillDownloadLog>().Property(x=>x.PozivNaBroj).HasColumnName("PozivNaBroj").HasColumnType("VarChar(50)").ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<tblBillDownloadLog>().Property(x=>x.BillDocumentID).HasColumnName("BillDocumentID").HasColumnType("BigInt").ValueGeneratedNever();
		}

		partial void Customize_tblBillDownloadLog(ModelBuilder modelBuilder);
		#endregion

		#region tblBillFirma
		private void Map_tblBillFirma(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<tblBillFirma>().ToTable("tblBillFirma", "dbo");
			modelBuilder.Entity<tblBillFirma>().HasKey(x=>x.BillFirmaID);
			modelBuilder.Entity<tblBillFirma>().Property(x=>x.BillFirmaID).HasColumnName("BillFirmaID").HasColumnType("BigInt").IsRequired().ValueGeneratedOnAdd();
			modelBuilder.Entity<tblBillFirma>().Property(x=>x.PdvSustavStartDate).HasColumnName("PdvSustavStartDate").HasColumnType("DateTime").ValueGeneratedNever();
			modelBuilder.Entity<tblBillFirma>().Property(x=>x.PdvSustavEndDate).HasColumnName("PdvSustavEndDate").HasColumnType("DateTime").ValueGeneratedNever();
			modelBuilder.Entity<tblBillFirma>().Property(x=>x.PorezniBroj).HasColumnName("PorezniBroj").HasColumnType("VarChar(15)").IsRequired().ValueGeneratedNever().HasMaxLength(15);
			modelBuilder.Entity<tblBillFirma>().Property(x=>x.Naziv).HasColumnName("Naziv").HasColumnType("NVarChar(255)").ValueGeneratedNever().HasMaxLength(255);
			modelBuilder.Entity<tblBillFirma>().Property(x=>x.Adresa).HasColumnName("Adresa").HasColumnType("NVarChar(255)").ValueGeneratedNever().HasMaxLength(255);
			modelBuilder.Entity<tblBillFirma>().Property(x=>x.PostanskiBroj).HasColumnName("PostanskiBroj").HasColumnType("VarChar(10)").ValueGeneratedNever().HasMaxLength(10);
			modelBuilder.Entity<tblBillFirma>().Property(x=>x.Mjesto).HasColumnName("Mjesto").HasColumnType("NVarChar(100)").ValueGeneratedNever().HasMaxLength(100);
			modelBuilder.Entity<tblBillFirma>().Property(x=>x.OslobodjenoPdvaNapomena).HasColumnName("OslobodjenoPdvaNapomena").HasColumnType("NVarChar(255)").ValueGeneratedNever().HasMaxLength(255);
			modelBuilder.Entity<tblBillFirma>().Property(x=>x.RacunIzradjenNaRacunaluNapomena).HasColumnName("RacunIzradjenNaRacunaluNapomena").HasColumnType("NVarChar(255)").ValueGeneratedNever().HasMaxLength(255);
			modelBuilder.Entity<tblBillFirma>().Property(x=>x.Email).HasColumnName("Email").HasColumnType("VarChar(150)").ValueGeneratedNever().HasMaxLength(150);
			modelBuilder.Entity<tblBillFirma>().Property(x=>x.WebSite).HasColumnName("WebSite").HasColumnType("VarChar(255)").ValueGeneratedNever().HasMaxLength(255);
			modelBuilder.Entity<tblBillFirma>().Property(x=>x.Telefon).HasColumnName("Telefon").HasColumnType("VarChar(20)").ValueGeneratedNever().HasMaxLength(20);
			modelBuilder.Entity<tblBillFirma>().Property(x=>x.Mobitel).HasColumnName("Mobitel").HasColumnType("VarChar(20)").ValueGeneratedNever().HasMaxLength(20);
			modelBuilder.Entity<tblBillFirma>().Property(x=>x.Fax).HasColumnName("Fax").HasColumnType("VarChar(20)").ValueGeneratedNever().HasMaxLength(20);
			modelBuilder.Entity<tblBillFirma>().Property(x=>x.BillFirmaCertificateModeID).HasColumnName("BillFirmaCertificateModeID").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblBillFirma>().Property(x=>x.FooterText).HasColumnName("FooterText").HasColumnType("NVarChar(500)").ValueGeneratedNever().HasMaxLength(500);
			modelBuilder.Entity<tblBillFirma>().Property(x=>x.HidePoweredByFooter).HasColumnName("HidePoweredByFooter").HasColumnType("Bit").ValueGeneratedNever();
		}

		partial void Customize_tblBillFirma(ModelBuilder modelBuilder);
		#endregion

		#region tblBillFirmaCertificate
		private void Map_tblBillFirmaCertificate(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<tblBillFirmaCertificate>().ToTable("tblBillFirmaCertificate", "dbo");
			modelBuilder.Entity<tblBillFirmaCertificate>().HasKey(x=>x.BillFirmaCertificateID);
			modelBuilder.Entity<tblBillFirmaCertificate>().Property(x=>x.BillFirmaCertificateID).HasColumnName("BillFirmaCertificateID").HasColumnType("BigInt").IsRequired().ValueGeneratedOnAdd();
			modelBuilder.Entity<tblBillFirmaCertificate>().Property(x=>x.BillFirmaID).HasColumnName("BillFirmaID").HasColumnType("BigInt").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblBillFirmaCertificate>().Property(x=>x.InsertionDate).HasColumnName("InsertionDate").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblBillFirmaCertificate>().Property(x=>x.CertSerial).HasColumnName("CertSerial").HasColumnType("VarChar(100)").IsRequired().ValueGeneratedNever().HasMaxLength(100);
			modelBuilder.Entity<tblBillFirmaCertificate>().Property(x=>x.CertData1).HasColumnName("CertData1").HasColumnType("VarBinary(MAX)").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblBillFirmaCertificate>().Property(x=>x.CertData2).HasColumnName("CertData2").HasColumnType("VarBinary(MAX)").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblBillFirmaCertificate>().Property(x=>x.CertIssuer).HasColumnName("CertIssuer").HasColumnType("VarChar(255)").ValueGeneratedNever().HasMaxLength(255);
			modelBuilder.Entity<tblBillFirmaCertificate>().Property(x=>x.CertSubject).HasColumnName("CertSubject").HasColumnType("VarChar(255)").ValueGeneratedNever().HasMaxLength(255);
			modelBuilder.Entity<tblBillFirmaCertificate>().Property(x=>x.NotBefore).HasColumnName("NotBefore").HasColumnType("DateTime").ValueGeneratedNever();
			modelBuilder.Entity<tblBillFirmaCertificate>().Property(x=>x.NotAfter).HasColumnName("NotAfter").HasColumnType("DateTime").ValueGeneratedNever();
			modelBuilder.Entity<tblBillFirmaCertificate>().Property(x=>x.BillFirmaCertificateModeID).HasColumnName("BillFirmaCertificateModeID").HasColumnType("Int").ValueGeneratedNever();
		}

		partial void Customize_tblBillFirmaCertificate(ModelBuilder modelBuilder);
		#endregion

		#region tblBillFirmaCertificateMode
		private void Map_tblBillFirmaCertificateMode(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<tblBillFirmaCertificateMode>().ToTable("tblBillFirmaCertificateMode", "dbo");
			modelBuilder.Entity<tblBillFirmaCertificateMode>().HasKey(x=>x.BillFirmaCertificateModeID);
			modelBuilder.Entity<tblBillFirmaCertificateMode>().Property(x=>x.BillFirmaCertificateModeID).HasColumnName("BillFirmaCertificateModeID").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblBillFirmaCertificateMode>().Property(x=>x.PropertyName).HasColumnName("PropertyName").HasColumnType("VarChar(100)").ValueGeneratedNever().HasMaxLength(100);
		}

		partial void Customize_tblBillFirmaCertificateMode(ModelBuilder modelBuilder);
		#endregion

		#region tblBillFirmaPos
		private void Map_tblBillFirmaPos(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<tblBillFirmaPos>().ToTable("tblBillFirmaPos", "dbo");
			modelBuilder.Entity<tblBillFirmaPos>().HasKey(x=>x.BillFirmaPosID);
			modelBuilder.Entity<tblBillFirmaPos>().Property(x=>x.BillFirmaPosID).HasColumnName("BillFirmaPosID").HasColumnType("BigInt").IsRequired().ValueGeneratedOnAdd();
			modelBuilder.Entity<tblBillFirmaPos>().Property(x=>x.BillFirmaID).HasColumnName("BillFirmaID").HasColumnType("BigInt").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblBillFirmaPos>().Property(x=>x.ReferenceBillDocumentID).HasColumnName("ReferenceBillDocumentID").HasColumnType("BigInt").ValueGeneratedNever();
			modelBuilder.Entity<tblBillFirmaPos>().Property(x=>x.StartDate).HasColumnName("StartDate").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblBillFirmaPos>().Property(x=>x.EndDate).HasColumnName("EndDate").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblBillFirmaPos>().Property(x=>x.IsActive).HasColumnName("IsActive").HasColumnType("Bit").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblBillFirmaPos>().Property(x=>x.PoslovniProstoriMax).HasColumnName("PoslovniProstoriMax").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblBillFirmaPos>().Property(x=>x.NaplatniUredjajiMax).HasColumnName("NaplatniUredjajiMax").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblBillFirmaPos>().Property(x=>x.DocumentsMax).HasColumnName("DocumentsMax").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblBillFirmaPos>().Property(x=>x.DocumentsCount).HasColumnName("DocumentsCount").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblBillFirmaPos>().Property(x=>x.CategoriesMax).HasColumnName("CategoriesMax").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblBillFirmaPos>().Property(x=>x.ProductsMax).HasColumnName("ProductsMax").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblBillFirmaPos>().Property(x=>x.PorezneGrupeMax).HasColumnName("PorezneGrupeMax").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblBillFirmaPos>().Property(x=>x.OperatoriMax).HasColumnName("OperatoriMax").HasColumnType("Int").IsRequired().ValueGeneratedNever();
		}

		partial void Customize_tblBillFirmaPos(ModelBuilder modelBuilder);
		#endregion

		#region tblBillFirmaTransakcijskiRacun
		private void Map_tblBillFirmaTransakcijskiRacun(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<tblBillFirmaTransakcijskiRacun>().ToTable("tblBillFirmaTransakcijskiRacun", "dbo");
			modelBuilder.Entity<tblBillFirmaTransakcijskiRacun>().HasKey(x=>x.BillFirmaTransakcijskiRacunID);
			modelBuilder.Entity<tblBillFirmaTransakcijskiRacun>().Property(x=>x.BillFirmaTransakcijskiRacunID).HasColumnName("BillFirmaTransakcijskiRacunID").HasColumnType("BigInt").IsRequired().ValueGeneratedOnAdd();
			modelBuilder.Entity<tblBillFirmaTransakcijskiRacun>().Property(x=>x.BankaID).HasColumnName("BankaID").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblBillFirmaTransakcijskiRacun>().Property(x=>x.IsPersonalAccount).HasColumnName("IsPersonalAccount").HasColumnType("Bit").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblBillFirmaTransakcijskiRacun>().Property(x=>x.BillFirmaID).HasColumnName("BillFirmaID").HasColumnType("BigInt").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblBillFirmaTransakcijskiRacun>().Property(x=>x.IBAN).HasColumnName("IBAN").HasColumnType("VarChar(50)").IsRequired().ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<tblBillFirmaTransakcijskiRacun>().Property(x=>x.Valuta).HasColumnName("Valuta").HasColumnType("VarChar(10)").ValueGeneratedNever().HasMaxLength(10);
			modelBuilder.Entity<tblBillFirmaTransakcijskiRacun>().Property(x=>x.Naziv).HasColumnName("Naziv").HasColumnType("NVarChar(50)").ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<tblBillFirmaTransakcijskiRacun>().Property(x=>x.VidljivNaPonudama).HasColumnName("VidljivNaPonudama").HasColumnType("Bit").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblBillFirmaTransakcijskiRacun>().Property(x=>x.BillFirmaTransakcijskiRacunEmailID).HasColumnName("BillFirmaTransakcijskiRacunEmailID").HasColumnType("BigInt").ValueGeneratedNever();
		}

		partial void Customize_tblBillFirmaTransakcijskiRacun(ModelBuilder modelBuilder);
		#endregion

		#region tblBillFirmaTransakcijskiRacunEmail
		private void Map_tblBillFirmaTransakcijskiRacunEmail(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<tblBillFirmaTransakcijskiRacunEmail>().ToTable("tblBillFirmaTransakcijskiRacunEmail", "dbo");
			modelBuilder.Entity<tblBillFirmaTransakcijskiRacunEmail>().HasKey(x=>x.BillFirmaTransakcijskiRacunEmailID);
			modelBuilder.Entity<tblBillFirmaTransakcijskiRacunEmail>().Property(x=>x.BillFirmaTransakcijskiRacunEmailID).HasColumnName("BillFirmaTransakcijskiRacunEmailID").HasColumnType("BigInt").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblBillFirmaTransakcijskiRacunEmail>().Property(x=>x.Host).HasColumnName("Host").HasColumnType("NVarChar(50)").ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<tblBillFirmaTransakcijskiRacunEmail>().Property(x=>x.User).HasColumnName("User").HasColumnType("NVarChar(50)").ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<tblBillFirmaTransakcijskiRacunEmail>().Property(x=>x.Pass).HasColumnName("Pass").HasColumnType("NVarChar(50)").ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<tblBillFirmaTransakcijskiRacunEmail>().Property(x=>x.Port).HasColumnName("Port").HasColumnType("Int").ValueGeneratedNever();
			modelBuilder.Entity<tblBillFirmaTransakcijskiRacunEmail>().Property(x=>x.UseSSL).HasColumnName("UseSSL").HasColumnType("Bit").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblBillFirmaTransakcijskiRacunEmail>().Property(x=>x.ReceivedEmailUIDLS).HasColumnName("ReceivedEmailUIDLS").HasColumnType("VarChar(MAX)").ValueGeneratedNever();
		}

		partial void Customize_tblBillFirmaTransakcijskiRacunEmail(ModelBuilder modelBuilder);
		#endregion

		#region tblBillMjera
		private void Map_tblBillMjera(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<tblBillMjera>().ToTable("tblBillMjera", "dbo");
			modelBuilder.Entity<tblBillMjera>().HasKey(x=>x.BillMjeraID);
			modelBuilder.Entity<tblBillMjera>().Property(x=>x.BillMjeraID).HasColumnName("BillMjeraID").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblBillMjera>().Property(x=>x.IsActive).HasColumnName("IsActive").HasColumnType("Bit").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblBillMjera>().Property(x=>x.Ordinal).HasColumnName("Ordinal").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblBillMjera>().Property(x=>x.IsDefault).HasColumnName("IsDefault").HasColumnType("Bit").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblBillMjera>().Property(x=>x.PropertyName).HasColumnName("PropertyName").HasColumnType("VarChar(100)").ValueGeneratedNever().HasMaxLength(100);
			modelBuilder.Entity<tblBillMjera>().Property(x=>x.KratkiNazivPropertyName).HasColumnName("KratkiNazivPropertyName").HasColumnType("VarChar(100)").ValueGeneratedNever().HasMaxLength(100);
			modelBuilder.Entity<tblBillMjera>().Property(x=>x.OsnovnaBillMjeraID).HasColumnName("OsnovnaBillMjeraID").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblBillMjera>().Property(x=>x.DioOsnovneMjere).HasColumnName("DioOsnovneMjere").HasColumnType("Float").IsRequired().ValueGeneratedNever();
		}

		partial void Customize_tblBillMjera(ModelBuilder modelBuilder);
		#endregion

		#region tblBillNaplatniUredjaj
		private void Map_tblBillNaplatniUredjaj(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<tblBillNaplatniUredjaj>().ToTable("tblBillNaplatniUredjaj", "dbo");
			modelBuilder.Entity<tblBillNaplatniUredjaj>().HasKey(x=>x.BillNaplatniUredjajID);
			modelBuilder.Entity<tblBillNaplatniUredjaj>().Property(x=>x.BillNaplatniUredjajID).HasColumnName("BillNaplatniUredjajID").HasColumnType("BigInt").IsRequired().ValueGeneratedOnAdd();
			modelBuilder.Entity<tblBillNaplatniUredjaj>().Property(x=>x.BillPoslovniProstorID).HasColumnName("BillPoslovniProstorID").HasColumnType("BigInt").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblBillNaplatniUredjaj>().Property(x=>x.IsActive).HasColumnName("IsActive").HasColumnType("Bit").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblBillNaplatniUredjaj>().Property(x=>x.OznakaNaplatnogUredjaja).HasColumnName("OznakaNaplatnogUredjaja").HasColumnType("Int").ValueGeneratedNever();
			modelBuilder.Entity<tblBillNaplatniUredjaj>().Property(x=>x.Naziv).HasColumnName("Naziv").HasColumnType("NVarChar(255)").ValueGeneratedNever().HasMaxLength(255);
			modelBuilder.Entity<tblBillNaplatniUredjaj>().Property(x=>x.Napomena).HasColumnName("Napomena").HasColumnType("NVarChar(500)").ValueGeneratedNever().HasMaxLength(500);
			modelBuilder.Entity<tblBillNaplatniUredjaj>().Property(x=>x.BillPaymentMethodID).HasColumnName("BillPaymentMethodID").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblBillNaplatniUredjaj>().Property(x=>x.CreatesRacunBillNaplatniUredjajID).HasColumnName("CreatesRacunBillNaplatniUredjajID").HasColumnType("BigInt").ValueGeneratedNever();
			modelBuilder.Entity<tblBillNaplatniUredjaj>().Property(x=>x.BillDocumentTipID).HasColumnName("BillDocumentTipID").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblBillNaplatniUredjaj>().Property(x=>x.POSMargineTRBL).HasColumnName("POSMargineTRBL").HasColumnType("VarChar(50)").ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<tblBillNaplatniUredjaj>().Property(x=>x.FooterText).HasColumnName("FooterText").HasColumnType("NVarChar(500)").ValueGeneratedNever().HasMaxLength(500);
		}

		partial void Customize_tblBillNaplatniUredjaj(ModelBuilder modelBuilder);
		#endregion

		#region tblBillOperator
		private void Map_tblBillOperator(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<tblBillOperator>().ToTable("tblBillOperator", "dbo");
			modelBuilder.Entity<tblBillOperator>().HasKey(x=>x.BillOperatorID);
			modelBuilder.Entity<tblBillOperator>().Property(x=>x.BillOperatorID).HasColumnName("BillOperatorID").HasColumnType("BigInt").IsRequired().ValueGeneratedOnAdd();
			modelBuilder.Entity<tblBillOperator>().Property(x=>x.Ime).HasColumnName("Ime").HasColumnType("NVarChar(100)").IsRequired().ValueGeneratedNever().HasMaxLength(100);
			modelBuilder.Entity<tblBillOperator>().Property(x=>x.Prezime).HasColumnName("Prezime").HasColumnType("NVarChar(100)").IsRequired().ValueGeneratedNever().HasMaxLength(100);
			modelBuilder.Entity<tblBillOperator>().Property(x=>x.OperatorPorezniBroj).HasColumnName("OperatorPorezniBroj").HasColumnType("VarChar(50)").IsRequired().ValueGeneratedNever().HasMaxLength(50);
		}

		partial void Customize_tblBillOperator(ModelBuilder modelBuilder);
		#endregion

		#region tblBillPaymentMethod
		private void Map_tblBillPaymentMethod(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<tblBillPaymentMethod>().ToTable("tblBillPaymentMethod", "dbo");
			modelBuilder.Entity<tblBillPaymentMethod>().HasKey(x=>x.BillPaymentMethodID);
			modelBuilder.Entity<tblBillPaymentMethod>().Property(x=>x.BillPaymentMethodID).HasColumnName("BillPaymentMethodID").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblBillPaymentMethod>().Property(x=>x.IsActive).HasColumnName("IsActive").HasColumnType("Bit").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblBillPaymentMethod>().Property(x=>x.Ordinal).HasColumnName("Ordinal").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblBillPaymentMethod>().Property(x=>x.IsDefault).HasColumnName("IsDefault").HasColumnType("Bit").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblBillPaymentMethod>().Property(x=>x.PropertyName).HasColumnName("PropertyName").HasColumnType("VarChar(100)").ValueGeneratedNever().HasMaxLength(100);
			modelBuilder.Entity<tblBillPaymentMethod>().Property(x=>x.IsFiskalizacijaRequired).HasColumnName("IsFiskalizacijaRequired").HasColumnType("Bit").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblBillPaymentMethod>().Property(x=>x.OznakaZaFiskalizaciju).HasColumnName("OznakaZaFiskalizaciju").HasColumnType("VarChar(10)").ValueGeneratedNever().HasMaxLength(10);
		}

		partial void Customize_tblBillPaymentMethod(ModelBuilder modelBuilder);
		#endregion

		#region tblBillPoreznaGrupa
		private void Map_tblBillPoreznaGrupa(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<tblBillPoreznaGrupa>().ToTable("tblBillPoreznaGrupa", "dbo");
			modelBuilder.Entity<tblBillPoreznaGrupa>().HasKey(x=>x.BillPoreznaGrupaID);
			modelBuilder.Entity<tblBillPoreznaGrupa>().Property(x=>x.BillPoreznaGrupaID).HasColumnName("BillPoreznaGrupaID").HasColumnType("BigInt").IsRequired().ValueGeneratedOnAdd();
			modelBuilder.Entity<tblBillPoreznaGrupa>().Property(x=>x.BillPoslovniProstorID).HasColumnName("BillPoslovniProstorID").HasColumnType("BigInt").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblBillPoreznaGrupa>().Property(x=>x.Naziv).HasColumnName("Naziv").HasColumnType("NVarChar(100)").IsRequired().ValueGeneratedNever().HasMaxLength(100);
			modelBuilder.Entity<tblBillPoreznaGrupa>().Property(x=>x.Opis).HasColumnName("Opis").HasColumnType("NVarChar(250)").ValueGeneratedNever().HasMaxLength(250);
			modelBuilder.Entity<tblBillPoreznaGrupa>().Property(x=>x.PdvPosto).HasColumnName("PdvPosto").HasColumnType("Decimal(5,2)").IsRequired().ValueGeneratedNever().HasMaxLength(5);
			modelBuilder.Entity<tblBillPoreznaGrupa>().Property(x=>x.PorezPotrosnjaPosto).HasColumnName("PorezPotrosnjaPosto").HasColumnType("Decimal(5,2)").IsRequired().ValueGeneratedNever().HasMaxLength(5);
			modelBuilder.Entity<tblBillPoreznaGrupa>().Property(x=>x.OstaliPorezNaziv).HasColumnName("OstaliPorezNaziv").HasColumnType("NVarChar(50)").ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<tblBillPoreznaGrupa>().Property(x=>x.OstaliPorezPosto).HasColumnName("OstaliPorezPosto").HasColumnType("Decimal(5,2)").IsRequired().ValueGeneratedNever().HasMaxLength(5);
			modelBuilder.Entity<tblBillPoreznaGrupa>().Property(x=>x.NaknadaNaziv).HasColumnName("NaknadaNaziv").HasColumnType("NVarChar(50)").ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<tblBillPoreznaGrupa>().Property(x=>x.IznosNaknade).HasColumnName("IznosNaknade").HasColumnType("Money").IsRequired().ValueGeneratedNever();
		}

		partial void Customize_tblBillPoreznaGrupa(ModelBuilder modelBuilder);
		#endregion

		#region tblBillPoslovniProstor
		private void Map_tblBillPoslovniProstor(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<tblBillPoslovniProstor>().ToTable("tblBillPoslovniProstor", "dbo");
			modelBuilder.Entity<tblBillPoslovniProstor>().HasKey(x=>x.BillPoslovniProstorID);
			modelBuilder.Entity<tblBillPoslovniProstor>().Property(x=>x.BillPoslovniProstorID).HasColumnName("BillPoslovniProstorID").HasColumnType("BigInt").IsRequired().ValueGeneratedOnAdd();
			modelBuilder.Entity<tblBillPoslovniProstor>().Property(x=>x.BillFirmaID).HasColumnName("BillFirmaID").HasColumnType("BigInt").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblBillPoslovniProstor>().Property(x=>x.IsActive).HasColumnName("IsActive").HasColumnType("Bit").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblBillPoslovniProstor>().Property(x=>x.OznakaPoslovnogProstora).HasColumnName("OznakaPoslovnogProstora").HasColumnType("Int").ValueGeneratedNever();
			modelBuilder.Entity<tblBillPoslovniProstor>().Property(x=>x.Naziv).HasColumnName("Naziv").HasColumnType("NVarChar(255)").ValueGeneratedNever().HasMaxLength(255);
			modelBuilder.Entity<tblBillPoslovniProstor>().Property(x=>x.Ulica).HasColumnName("Ulica").HasColumnType("NVarChar(255)").ValueGeneratedNever().HasMaxLength(255);
			modelBuilder.Entity<tblBillPoslovniProstor>().Property(x=>x.KucniBroj).HasColumnName("KucniBroj").HasColumnType("Int").ValueGeneratedNever();
			modelBuilder.Entity<tblBillPoslovniProstor>().Property(x=>x.DodatakKucnomBroju).HasColumnName("DodatakKucnomBroju").HasColumnType("NVarChar(50)").ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<tblBillPoslovniProstor>().Property(x=>x.PostanskiBroj).HasColumnName("PostanskiBroj").HasColumnType("VarChar(50)").ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<tblBillPoslovniProstor>().Property(x=>x.Mjesto).HasColumnName("Mjesto").HasColumnType("NVarChar(255)").ValueGeneratedNever().HasMaxLength(255);
			modelBuilder.Entity<tblBillPoslovniProstor>().Property(x=>x.Opcina).HasColumnName("Opcina").HasColumnType("NVarChar(255)").ValueGeneratedNever().HasMaxLength(255);
			modelBuilder.Entity<tblBillPoslovniProstor>().Property(x=>x.RadnoVrijeme).HasColumnName("RadnoVrijeme").HasColumnType("NVarChar(50)").ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<tblBillPoslovniProstor>().Property(x=>x.PocetakPrimjene).HasColumnName("PocetakPrimjene").HasColumnType("DateTime").ValueGeneratedNever();
			modelBuilder.Entity<tblBillPoslovniProstor>().Property(x=>x.KrajPrimjene).HasColumnName("KrajPrimjene").HasColumnType("DateTime").ValueGeneratedNever();
			modelBuilder.Entity<tblBillPoslovniProstor>().Property(x=>x.DatumPrijavePoreznoj).HasColumnName("DatumPrijavePoreznoj").HasColumnType("DateTime").ValueGeneratedNever();
			modelBuilder.Entity<tblBillPoslovniProstor>().Property(x=>x.DatumOdjavePoreznoj).HasColumnName("DatumOdjavePoreznoj").HasColumnType("DateTime").ValueGeneratedNever();
			modelBuilder.Entity<tblBillPoslovniProstor>().Property(x=>x.Napomena).HasColumnName("Napomena").HasColumnType("NVarChar(500)").ValueGeneratedNever().HasMaxLength(500);
		}

		partial void Customize_tblBillPoslovniProstor(ModelBuilder modelBuilder);
		#endregion

		#region tblBillPrintLog
		private void Map_tblBillPrintLog(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<tblBillPrintLog>().ToTable("tblBillPrintLog", "dbo");
			modelBuilder.Entity<tblBillPrintLog>().HasKey(x=>x.BillPrintLogID);
			modelBuilder.Entity<tblBillPrintLog>().Property(x=>x.BillPrintLogID).HasColumnName("BillPrintLogID").HasColumnType("BigInt").IsRequired().ValueGeneratedOnAdd();
			modelBuilder.Entity<tblBillPrintLog>().Property(x=>x.AppMemberID).HasColumnName("AppMemberID").HasColumnType("BigInt").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblBillPrintLog>().Property(x=>x.InsertedDate).HasColumnName("InsertedDate").HasColumnType("DateTime").ValueGeneratedNever();
			modelBuilder.Entity<tblBillPrintLog>().Property(x=>x.PdfBijeliPapir).HasColumnName("PdfBijeliPapir").HasColumnType("Image").ValueGeneratedNever();
			modelBuilder.Entity<tblBillPrintLog>().Property(x=>x.PdfOpcaUplatnica).HasColumnName("PdfOpcaUplatnica").HasColumnType("Image").ValueGeneratedNever();
			modelBuilder.Entity<tblBillPrintLog>().Property(x=>x.PdfMemoUplatnica).HasColumnName("PdfMemoUplatnica").HasColumnType("Image").ValueGeneratedNever();
			modelBuilder.Entity<tblBillPrintLog>().Property(x=>x.TextLog).HasColumnName("TextLog").HasColumnType("NText").ValueGeneratedNever();
		}

		partial void Customize_tblBillPrintLog(ModelBuilder modelBuilder);
		#endregion

		#region tblBillProduct
		private void Map_tblBillProduct(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<tblBillProduct>().ToTable("tblBillProduct", "dbo");
			modelBuilder.Entity<tblBillProduct>().HasKey(x=>x.BillProductID);
			modelBuilder.Entity<tblBillProduct>().Property(x=>x.BillProductID).HasColumnName("BillProductID").HasColumnType("BigInt").IsRequired().ValueGeneratedOnAdd();
			modelBuilder.Entity<tblBillProduct>().Property(x=>x.BillPoslovniProstorID).HasColumnName("BillPoslovniProstorID").HasColumnType("BigInt").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblBillProduct>().Property(x=>x.Naziv).HasColumnName("Naziv").HasColumnType("NVarChar(50)").IsRequired().ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<tblBillProduct>().Property(x=>x.Opis).HasColumnName("Opis").HasColumnType("NVarChar(250)").ValueGeneratedNever().HasMaxLength(250);
			modelBuilder.Entity<tblBillProduct>().Property(x=>x.Barcode).HasColumnName("Barcode").HasColumnType("VarChar(50)").ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<tblBillProduct>().Property(x=>x.JedinicnaCijena).HasColumnName("JedinicnaCijena").HasColumnType("Money").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblBillProduct>().Property(x=>x.CijenaJeMPC).HasColumnName("CijenaJeMPC").HasColumnType("Bit").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblBillProduct>().Property(x=>x.BillMjeraID).HasColumnName("BillMjeraID").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblBillProduct>().Property(x=>x.Ordinal).HasColumnName("Ordinal").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblBillProduct>().Property(x=>x.IsArtikl).HasColumnName("IsArtikl").HasColumnType("Bit").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblBillProduct>().Property(x=>x.IsNormativ).HasColumnName("IsNormativ").HasColumnType("Bit").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblBillProduct>().Property(x=>x.BillPoreznaGrupaID).HasColumnName("BillPoreznaGrupaID").HasColumnType("BigInt").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblBillProduct>().Property(x=>x.CijenaNakonRoka).HasColumnName("CijenaNakonRoka").HasColumnType("Money").ValueGeneratedNever();
			modelBuilder.Entity<tblBillProduct>().Property(x=>x.BillUslugaTipID).HasColumnName("BillUslugaTipID").HasColumnType("Int").ValueGeneratedNever();
		}

		partial void Customize_tblBillProduct(ModelBuilder modelBuilder);
		#endregion

		#region tblBillProductCategory
		private void Map_tblBillProductCategory(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<tblBillProductCategory>().ToTable("tblBillProductCategory", "dbo");
			modelBuilder.Entity<tblBillProductCategory>().HasKey("BillProductID", "BillCategoryID");
			modelBuilder.Entity<tblBillProductCategory>().Property(x=>x.BillProductID).HasColumnName("BillProductID").HasColumnType("BigInt").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblBillProductCategory>().Property(x=>x.BillCategoryID).HasColumnName("BillCategoryID").HasColumnType("BigInt").IsRequired().ValueGeneratedNever();
		}

		partial void Customize_tblBillProductCategory(ModelBuilder modelBuilder);
		#endregion

		#region tblBillProductNormativ
		private void Map_tblBillProductNormativ(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<tblBillProductNormativ>().ToTable("tblBillProductNormativ", "dbo");
			modelBuilder.Entity<tblBillProductNormativ>().HasKey("ArtiklBillProductID", "NormativBillProductID");
			modelBuilder.Entity<tblBillProductNormativ>().Property(x=>x.ArtiklBillProductID).HasColumnName("ArtiklBillProductID").HasColumnType("BigInt").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblBillProductNormativ>().Property(x=>x.NormativBillProductID).HasColumnName("NormativBillProductID").HasColumnType("BigInt").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblBillProductNormativ>().Property(x=>x.Kolicina).HasColumnName("Kolicina").HasColumnType("Decimal(18,8)").IsRequired().ValueGeneratedNever().HasMaxLength(18);
			modelBuilder.Entity<tblBillProductNormativ>().Property(x=>x.Opis).HasColumnName("Opis").HasColumnType("NVarChar(250)").ValueGeneratedNever().HasMaxLength(250);
		}

		partial void Customize_tblBillProductNormativ(ModelBuilder modelBuilder);
		#endregion

		#region tblBillUslugaTip
		private void Map_tblBillUslugaTip(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<tblBillUslugaTip>().ToTable("tblBillUslugaTip", "dbo");
			modelBuilder.Entity<tblBillUslugaTip>().HasKey(x=>x.BillUslugaTipID);
			modelBuilder.Entity<tblBillUslugaTip>().Property(x=>x.BillUslugaTipID).HasColumnName("BillUslugaTipID").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblBillUslugaTip>().Property(x=>x.Naziv).HasColumnName("Naziv").HasColumnType("NVarChar(50)").IsRequired().ValueGeneratedNever().HasMaxLength(50);
		}

		partial void Customize_tblBillUslugaTip(ModelBuilder modelBuilder);
		#endregion

		#region tblBookkeepingFiduciaExport
		private void Map_tblBookkeepingFiduciaExport(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<tblBookkeepingFiduciaExport>().ToTable("tblBookkeepingFiduciaExport", "dbo");
			modelBuilder.Entity<tblBookkeepingFiduciaExport>().HasKey("BillFirmaID", "StartDateIncluded", "EndDateExcluded");
			modelBuilder.Entity<tblBookkeepingFiduciaExport>().Property(x=>x.FiduciaExportID).HasColumnName("FiduciaExportID").HasColumnType("BigInt").IsRequired().ValueGeneratedOnAdd();
			modelBuilder.Entity<tblBookkeepingFiduciaExport>().Property(x=>x.DatumGeneriranja).HasColumnName("DatumGeneriranja").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblBookkeepingFiduciaExport>().Property(x=>x.BillFirmaID).HasColumnName("BillFirmaID").HasColumnType("BigInt").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblBookkeepingFiduciaExport>().Property(x=>x.StartDateIncluded).HasColumnName("StartDateIncluded").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblBookkeepingFiduciaExport>().Property(x=>x.EndDateExcluded).HasColumnName("EndDateExcluded").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblBookkeepingFiduciaExport>().Property(x=>x.AllData).HasColumnName("AllData").HasColumnType("Image").ValueGeneratedNever();
			modelBuilder.Entity<tblBookkeepingFiduciaExport>().Property(x=>x.Klijenti).HasColumnName("Klijenti").HasColumnType("Image").ValueGeneratedNever();
			modelBuilder.Entity<tblBookkeepingFiduciaExport>().Property(x=>x.RacuniKonta).HasColumnName("RacuniKonta").HasColumnType("Image").ValueGeneratedNever();
			modelBuilder.Entity<tblBookkeepingFiduciaExport>().Property(x=>x.RacuniKnjiga).HasColumnName("RacuniKnjiga").HasColumnType("Image").ValueGeneratedNever();
			modelBuilder.Entity<tblBookkeepingFiduciaExport>().Property(x=>x.Preknjizenja).HasColumnName("Preknjizenja").HasColumnType("Image").ValueGeneratedNever();
		}

		partial void Customize_tblBookkeepingFiduciaExport(ModelBuilder modelBuilder);
		#endregion

		#region tblBookkeepingSynesisExport
		private void Map_tblBookkeepingSynesisExport(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<tblBookkeepingSynesisExport>().ToTable("tblBookkeepingSynesisExport", "dbo");
			modelBuilder.Entity<tblBookkeepingSynesisExport>().HasKey("BillFirmaID", "StartDateIncluded", "EndDateExcluded");
			modelBuilder.Entity<tblBookkeepingSynesisExport>().Property(x=>x.SynesisExportID).HasColumnName("SynesisExportID").HasColumnType("BigInt").IsRequired().ValueGeneratedOnAdd();
			modelBuilder.Entity<tblBookkeepingSynesisExport>().Property(x=>x.DatumGeneriranja).HasColumnName("DatumGeneriranja").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblBookkeepingSynesisExport>().Property(x=>x.BillFirmaID).HasColumnName("BillFirmaID").HasColumnType("BigInt").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblBookkeepingSynesisExport>().Property(x=>x.StartDateIncluded).HasColumnName("StartDateIncluded").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblBookkeepingSynesisExport>().Property(x=>x.EndDateExcluded).HasColumnName("EndDateExcluded").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblBookkeepingSynesisExport>().Property(x=>x.AllData).HasColumnName("AllData").HasColumnType("Image").ValueGeneratedNever();
			modelBuilder.Entity<tblBookkeepingSynesisExport>().Property(x=>x.Klijenti).HasColumnName("Klijenti").HasColumnType("Image").ValueGeneratedNever();
			modelBuilder.Entity<tblBookkeepingSynesisExport>().Property(x=>x.FinancKnjig).HasColumnName("FinancKnjig").HasColumnType("Image").ValueGeneratedNever();
			modelBuilder.Entity<tblBookkeepingSynesisExport>().Property(x=>x.UlazniRacuni).HasColumnName("UlazniRacuni").HasColumnType("Image").ValueGeneratedNever();
			modelBuilder.Entity<tblBookkeepingSynesisExport>().Property(x=>x.IzlazniRacuni).HasColumnName("IzlazniRacuni").HasColumnType("Image").ValueGeneratedNever();
		}

		partial void Customize_tblBookkeepingSynesisExport(ModelBuilder modelBuilder);
		#endregion

		#region tblDirClient
		private void Map_tblDirClient(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<tblDirClient>().ToTable("tblDirClient", "dbo");
			modelBuilder.Entity<tblDirClient>().HasKey(x=>x.DirClientID);
			modelBuilder.Entity<tblDirClient>().Property(x=>x.DirClientID).HasColumnName("DirClientID").HasColumnType("BigInt").IsRequired().ValueGeneratedOnAdd();
			modelBuilder.Entity<tblDirClient>().Property(x=>x.DirClientSourceID).HasColumnName("DirClientSourceID").HasColumnType("Int").ValueGeneratedNever();
			modelBuilder.Entity<tblDirClient>().Property(x=>x.MaticniBroj).HasColumnName("MaticniBroj").HasColumnType("VarChar(20)").ValueGeneratedNever().HasMaxLength(20);
			modelBuilder.Entity<tblDirClient>().Property(x=>x.PorezniBroj).HasColumnName("PorezniBroj").HasColumnType("VarChar(20)").ValueGeneratedNever().HasMaxLength(20);
			modelBuilder.Entity<tblDirClient>().Property(x=>x.datumObjave).HasColumnName("datumObjave").HasColumnType("DateTime").ValueGeneratedNever();
			modelBuilder.Entity<tblDirClient>().Property(x=>x.datumOsnivanja).HasColumnName("datumOsnivanja").HasColumnType("DateTime").ValueGeneratedNever();
			modelBuilder.Entity<tblDirClient>().Property(x=>x.datumZatvaranja).HasColumnName("datumZatvaranja").HasColumnType("DateTime").ValueGeneratedNever();
			modelBuilder.Entity<tblDirClient>().Property(x=>x.insertionDate).HasColumnName("insertionDate").HasColumnType("DateTime").ValueGeneratedNever();
			modelBuilder.Entity<tblDirClient>().Property(x=>x.Naziv).HasColumnName("Naziv").HasColumnType("NVarChar(250)").ValueGeneratedNever().HasMaxLength(250);
			modelBuilder.Entity<tblDirClient>().Property(x=>x.Adresa).HasColumnName("Adresa").HasColumnType("NVarChar(250)").ValueGeneratedNever().HasMaxLength(250);
			modelBuilder.Entity<tblDirClient>().Property(x=>x.Naselje).HasColumnName("Naselje").HasColumnType("NVarChar(250)").ValueGeneratedNever().HasMaxLength(250);
			modelBuilder.Entity<tblDirClient>().Property(x=>x.PostanskiBroj).HasColumnName("PostanskiBroj").HasColumnType("NVarChar(50)").ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<tblDirClient>().Property(x=>x.PostanskiUred).HasColumnName("PostanskiUred").HasColumnType("NVarChar(200)").ValueGeneratedNever().HasMaxLength(200);
			modelBuilder.Entity<tblDirClient>().Property(x=>x.Provincia).HasColumnName("Provincia").HasColumnType("NVarChar(200)").ValueGeneratedNever().HasMaxLength(200);
			modelBuilder.Entity<tblDirClient>().Property(x=>x.Web).HasColumnName("Web").HasColumnType("NVarChar(500)").ValueGeneratedNever().HasMaxLength(500);
			modelBuilder.Entity<tblDirClient>().Property(x=>x.Email).HasColumnName("Email").HasColumnType("NVarChar(200)").ValueGeneratedNever().HasMaxLength(200);
			modelBuilder.Entity<tblDirClient>().Property(x=>x.Telefon1).HasColumnName("Telefon1").HasColumnType("VarChar(20)").ValueGeneratedNever().HasMaxLength(20);
			modelBuilder.Entity<tblDirClient>().Property(x=>x.Telefon2).HasColumnName("Telefon2").HasColumnType("VarChar(20)").ValueGeneratedNever().HasMaxLength(20);
			modelBuilder.Entity<tblDirClient>().Property(x=>x.NkdRowID).HasColumnName("NkdRowID").HasColumnType("Int").ValueGeneratedNever();
			modelBuilder.Entity<tblDirClient>().Property(x=>x.KljucneRijeci).HasColumnName("KljucneRijeci").HasColumnType("NVarChar(500)").ValueGeneratedNever().HasMaxLength(500);
			modelBuilder.Entity<tblDirClient>().Property(x=>x.Opis).HasColumnName("Opis").HasColumnType("NVarChar(MAX)").ValueGeneratedNever();
			modelBuilder.Entity<tblDirClient>().Property(x=>x.RadnoVrijeme).HasColumnName("RadnoVrijeme").HasColumnType("NVarChar(500)").ValueGeneratedNever().HasMaxLength(500);
			modelBuilder.Entity<tblDirClient>().Property(x=>x.odgovornaOsoba).HasColumnName("odgovornaOsoba").HasColumnType("NVarChar(250)").ValueGeneratedNever().HasMaxLength(250);
			modelBuilder.Entity<tblDirClient>().Property(x=>x.isVlasnik).HasColumnName("isVlasnik").HasColumnType("Bit").ValueGeneratedNever();
			modelBuilder.Entity<tblDirClient>().Property(x=>x.FormattedAddress).HasColumnName("FormattedAddress").HasColumnType("NVarChar(500)").ValueGeneratedNever().HasMaxLength(500);
			modelBuilder.Entity<tblDirClient>().Property(x=>x.LocationType).HasColumnName("LocationType").HasColumnType("VarChar(100)").ValueGeneratedNever().HasMaxLength(100);
			modelBuilder.Entity<tblDirClient>().Property(x=>x.Latitude).HasColumnName("Latitude").HasColumnType("Decimal(18,10)").ValueGeneratedNever().HasMaxLength(18);
			modelBuilder.Entity<tblDirClient>().Property(x=>x.Longitude).HasColumnName("Longitude").HasColumnType("Decimal(18,10)").ValueGeneratedNever().HasMaxLength(18);
			modelBuilder.Entity<tblDirClient>().Property(x=>x.LocationStatus).HasColumnName("LocationStatus").HasColumnType("VarChar(50)").ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<tblDirClient>().Property(x=>x.LastModifiedDate).HasColumnName("LastModifiedDate").HasColumnType("DateTime").ValueGeneratedNever();
			modelBuilder.Entity<tblDirClient>().Property(x=>x.IsClientVisible).HasColumnName("IsClientVisible").HasColumnType("Bit").IsRequired().ValueGeneratedNever();
		}

		partial void Customize_tblDirClient(ModelBuilder modelBuilder);
		#endregion

		#region tblDirClientBlacklist
		private void Map_tblDirClientBlacklist(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<tblDirClientBlacklist>().ToTable("tblDirClientBlacklist", "dbo");
			modelBuilder.Entity<tblDirClientBlacklist>().HasKey(x=>x.PorezniBroj);
			modelBuilder.Entity<tblDirClientBlacklist>().Property(x=>x.PorezniBroj).HasColumnName("PorezniBroj").HasColumnType("VarChar(20)").IsRequired().ValueGeneratedNever().HasMaxLength(20);
			modelBuilder.Entity<tblDirClientBlacklist>().Property(x=>x.MaticniBroj).HasColumnName("MaticniBroj").HasColumnType("VarChar(20)").ValueGeneratedNever().HasMaxLength(20);
			modelBuilder.Entity<tblDirClientBlacklist>().Property(x=>x.BillFirmaID).HasColumnName("BillFirmaID").HasColumnType("BigInt").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblDirClientBlacklist>().Property(x=>x.InsertionDate).HasColumnName("InsertionDate").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblDirClientBlacklist>().Property(x=>x.Napomena).HasColumnName("Napomena").HasColumnType("NVarChar(500)").ValueGeneratedNever().HasMaxLength(500);
			modelBuilder.Entity<tblDirClientBlacklist>().Property(x=>x.AppMemberID).HasColumnName("AppMemberID").HasColumnType("BigInt").IsRequired().ValueGeneratedNever();
		}

		partial void Customize_tblDirClientBlacklist(ModelBuilder modelBuilder);
		#endregion

		#region tblDirClientFullText
		private void Map_tblDirClientFullText(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<tblDirClientFullText>().ToTable("tblDirClientFullText", "dbo");
			modelBuilder.Entity<tblDirClientFullText>().HasKey(x=>x.DirClientID);
			modelBuilder.Entity<tblDirClientFullText>().Property(x=>x.DirClientID).HasColumnName("DirClientID").HasColumnType("BigInt").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblDirClientFullText>().Property(x=>x.fullTextIndexBasic).HasColumnName("fullTextIndexBasic").HasColumnType("NVarChar(MAX)").ValueGeneratedNever();
			modelBuilder.Entity<tblDirClientFullText>().Property(x=>x.fullTextIndexFull).HasColumnName("fullTextIndexFull").HasColumnType("NVarChar(MAX)").ValueGeneratedNever();
		}

		partial void Customize_tblDirClientFullText(ModelBuilder modelBuilder);
		#endregion

		#region tblDirClientGratis
		private void Map_tblDirClientGratis(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<tblDirClientGratis>().ToTable("tblDirClientGratis", "dbo");
			modelBuilder.Entity<tblDirClientGratis>().HasKey(x=>x.DirClientID);
			modelBuilder.Entity<tblDirClientGratis>().Property(x=>x.DirClientID).HasColumnName("DirClientID").HasColumnType("BigInt").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblDirClientGratis>().Property(x=>x.BillUslugaTipID).HasColumnName("BillUslugaTipID").HasColumnType("Int").ValueGeneratedNever();
			modelBuilder.Entity<tblDirClientGratis>().Property(x=>x.PrikazStatus).HasColumnName("PrikazStatus").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblDirClientGratis>().Property(x=>x.StartDate).HasColumnName("StartDate").HasColumnType("DateTime").ValueGeneratedNever();
			modelBuilder.Entity<tblDirClientGratis>().Property(x=>x.EndDate).HasColumnName("EndDate").HasColumnType("DateTime").ValueGeneratedNever();
		}

		partial void Customize_tblDirClientGratis(ModelBuilder modelBuilder);
		#endregion

		#region tblDirClientPicture
		private void Map_tblDirClientPicture(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<tblDirClientPicture>().ToTable("tblDirClientPicture", "dbo");
			modelBuilder.Entity<tblDirClientPicture>().HasKey(x=>x.DirClientPictureID);
			modelBuilder.Entity<tblDirClientPicture>().Property(x=>x.DirClientPictureID).HasColumnName("DirClientPictureID").HasColumnType("BigInt").IsRequired().ValueGeneratedOnAdd();
			modelBuilder.Entity<tblDirClientPicture>().Property(x=>x.DirClientID).HasColumnName("DirClientID").HasColumnType("BigInt").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblDirClientPicture>().Property(x=>x.InsertionDate).HasColumnName("InsertionDate").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblDirClientPicture>().Property(x=>x.FileName).HasColumnName("FileName").HasColumnType("NVarChar(500)").ValueGeneratedNever().HasMaxLength(500);
			modelBuilder.Entity<tblDirClientPicture>().Property(x=>x.ImageData).HasColumnName("ImageData").HasColumnType("VarBinary(MAX)").ValueGeneratedNever();
			modelBuilder.Entity<tblDirClientPicture>().Property(x=>x.ImageMimeType).HasColumnName("ImageMimeType").HasColumnType("VarChar(20)").ValueGeneratedNever().HasMaxLength(20);
			modelBuilder.Entity<tblDirClientPicture>().Property(x=>x.ThumbData).HasColumnName("ThumbData").HasColumnType("VarBinary(MAX)").ValueGeneratedNever();
			modelBuilder.Entity<tblDirClientPicture>().Property(x=>x.ThumbMimeType).HasColumnName("ThumbMimeType").HasColumnType("VarChar(20)").ValueGeneratedNever().HasMaxLength(20);
			modelBuilder.Entity<tblDirClientPicture>().Property(x=>x.IsNaslovna).HasColumnName("IsNaslovna").HasColumnType("Bit").ValueGeneratedNever();
			modelBuilder.Entity<tblDirClientPicture>().Property(x=>x.IsLogo).HasColumnName("IsLogo").HasColumnType("Bit").ValueGeneratedNever();
		}

		partial void Customize_tblDirClientPicture(ModelBuilder modelBuilder);
		#endregion

		#region tblDirClientPrikazStatus
		private void Map_tblDirClientPrikazStatus(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<tblDirClientPrikazStatus>().ToTable("tblDirClientPrikazStatus", "dbo");
			modelBuilder.Entity<tblDirClientPrikazStatus>().HasKey(x=>x.DirClientID);
			modelBuilder.Entity<tblDirClientPrikazStatus>().Property(x=>x.DirClientID).HasColumnName("DirClientID").HasColumnType("BigInt").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblDirClientPrikazStatus>().Property(x=>x.PrikazStatus).HasColumnName("PrikazStatus").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblDirClientPrikazStatus>().Property(x=>x.StartDate).HasColumnName("StartDate").HasColumnType("DateTime").ValueGeneratedNever();
			modelBuilder.Entity<tblDirClientPrikazStatus>().Property(x=>x.EndDate).HasColumnName("EndDate").HasColumnType("DateTime").ValueGeneratedNever();
		}

		partial void Customize_tblDirClientPrikazStatus(ModelBuilder modelBuilder);
		#endregion

		#region tblDirClientSource
		private void Map_tblDirClientSource(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<tblDirClientSource>().ToTable("tblDirClientSource", "dbo");
			modelBuilder.Entity<tblDirClientSource>().HasKey(x=>x.DirClientSourceID);
			modelBuilder.Entity<tblDirClientSource>().Property(x=>x.DirClientSourceID).HasColumnName("DirClientSourceID").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblDirClientSource>().Property(x=>x.IsWebVisible).HasColumnName("IsWebVisible").HasColumnType("Bit").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblDirClientSource>().Property(x=>x.Name).HasColumnName("Name").HasColumnType("NVarChar(500)").ValueGeneratedNever().HasMaxLength(500);
		}

		partial void Customize_tblDirClientSource(ModelBuilder modelBuilder);
		#endregion

		#region tblDirClientVracenaPosta
		private void Map_tblDirClientVracenaPosta(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<tblDirClientVracenaPosta>().ToTable("tblDirClientVracenaPosta", "dbo");
			modelBuilder.Entity<tblDirClientVracenaPosta>().HasNoKey();
			modelBuilder.Entity<tblDirClientVracenaPosta>().Property(x=>x.PorezniBroj).HasColumnName("PorezniBroj").HasColumnType("VarChar(20)").ValueGeneratedNever().HasMaxLength(20);
			modelBuilder.Entity<tblDirClientVracenaPosta>().Property(x=>x.MaticniBroj).HasColumnName("MaticniBroj").HasColumnType("VarChar(20)").ValueGeneratedNever().HasMaxLength(20);
			modelBuilder.Entity<tblDirClientVracenaPosta>().Property(x=>x.BillFirmaID).HasColumnName("BillFirmaID").HasColumnType("BigInt").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblDirClientVracenaPosta>().Property(x=>x.InsertionDate).HasColumnName("InsertionDate").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblDirClientVracenaPosta>().Property(x=>x.Napomena).HasColumnName("Napomena").HasColumnType("NVarChar(500)").ValueGeneratedNever().HasMaxLength(500);
			modelBuilder.Entity<tblDirClientVracenaPosta>().Property(x=>x.AppMemberID).HasColumnName("AppMemberID").HasColumnType("BigInt").IsRequired().ValueGeneratedNever();
		}

		partial void Customize_tblDirClientVracenaPosta(ModelBuilder modelBuilder);
		#endregion

		#region tblDirNkd2007
		private void Map_tblDirNkd2007(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<tblDirNkd2007>().ToTable("tblDirNkd2007", "dbo");
			modelBuilder.Entity<tblDirNkd2007>().HasKey(x=>x.NkdRowID);
			modelBuilder.Entity<tblDirNkd2007>().Property(x=>x.NkdRowID).HasColumnName("NkdRowID").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblDirNkd2007>().Property(x=>x.ParentNkdRowID).HasColumnName("ParentNkdRowID").HasColumnType("Int").ValueGeneratedNever();
			modelBuilder.Entity<tblDirNkd2007>().Property(x=>x.InsertionDate).HasColumnName("InsertionDate").HasColumnType("DateTime").ValueGeneratedNever();
			modelBuilder.Entity<tblDirNkd2007>().Property(x=>x.Podrucje).HasColumnName("Podrucje").HasColumnType("NVarChar(50)").ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<tblDirNkd2007>().Property(x=>x.Odjeljak).HasColumnName("Odjeljak").HasColumnType("NVarChar(50)").ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<tblDirNkd2007>().Property(x=>x.Skupina).HasColumnName("Skupina").HasColumnType("NVarChar(50)").ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<tblDirNkd2007>().Property(x=>x.Razred).HasColumnName("Razred").HasColumnType("NVarChar(50)").ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<tblDirNkd2007>().Property(x=>x.SimpleRazred).HasColumnName("SimpleRazred").HasColumnType("NVarChar(50)").ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<tblDirNkd2007>().Property(x=>x.NkdDjelatnostNaziv).HasColumnName("NkdDjelatnostNaziv").HasColumnType("NVarChar(500)").ValueGeneratedNever().HasMaxLength(500);
			modelBuilder.Entity<tblDirNkd2007>().Property(x=>x.NkdKljucneRijeci).HasColumnName("NkdKljucneRijeci").HasColumnType("NVarChar(500)").ValueGeneratedNever().HasMaxLength(500);
			modelBuilder.Entity<tblDirNkd2007>().Property(x=>x.Nkd2007Sifra).HasColumnName("Nkd2007Sifra").HasColumnType("VarChar(20)").ValueGeneratedNever().HasMaxLength(20);
			modelBuilder.Entity<tblDirNkd2007>().Property(x=>x.DescriptionLines).HasColumnName("DescriptionLines").HasColumnType("NVarChar(MAX)").ValueGeneratedNever();
			modelBuilder.Entity<tblDirNkd2007>().Property(x=>x.LastModifiedDate).HasColumnName("LastModifiedDate").HasColumnType("DateTime").ValueGeneratedNever();
		}

		partial void Customize_tblDirNkd2007(ModelBuilder modelBuilder);
		#endregion

		#region tblDirPrikazStatus
		private void Map_tblDirPrikazStatus(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<tblDirPrikazStatus>().ToTable("tblDirPrikazStatus", "dbo");
			modelBuilder.Entity<tblDirPrikazStatus>().HasNoKey();
			modelBuilder.Entity<tblDirPrikazStatus>().Property(x=>x.PrikazStatus).HasColumnName("PrikazStatus").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblDirPrikazStatus>().Property(x=>x.Description).HasColumnName("Description").HasColumnType("NVarChar(500)").ValueGeneratedNever().HasMaxLength(500);
		}

		partial void Customize_tblDirPrikazStatus(ModelBuilder modelBuilder);
		#endregion

		#region tblDirRegistration
		private void Map_tblDirRegistration(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<tblDirRegistration>().ToTable("tblDirRegistration", "dbo");
			modelBuilder.Entity<tblDirRegistration>().HasKey(x=>x.DirRegistrationID);
			modelBuilder.Entity<tblDirRegistration>().Property(x=>x.DirRegistrationID).HasColumnName("DirRegistrationID").HasColumnType("BigInt").IsRequired().ValueGeneratedOnAdd();
			modelBuilder.Entity<tblDirRegistration>().Property(x=>x.IP).HasColumnName("IP").HasColumnType("VarChar(50)").IsRequired().ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<tblDirRegistration>().Property(x=>x.InsertionDate).HasColumnName("InsertionDate").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblDirRegistration>().Property(x=>x.ProcessedDate).HasColumnName("ProcessedDate").HasColumnType("DateTime").ValueGeneratedNever();
			modelBuilder.Entity<tblDirRegistration>().Property(x=>x.PorezniBroj).HasColumnName("PorezniBroj").HasColumnType("VarChar(20)").IsRequired().ValueGeneratedNever().HasMaxLength(20);
			modelBuilder.Entity<tblDirRegistration>().Property(x=>x.Naziv).HasColumnName("Naziv").HasColumnType("NVarChar(255)").IsRequired().ValueGeneratedNever().HasMaxLength(255);
			modelBuilder.Entity<tblDirRegistration>().Property(x=>x.Adresa).HasColumnName("Adresa").HasColumnType("NVarChar(255)").IsRequired().ValueGeneratedNever().HasMaxLength(255);
			modelBuilder.Entity<tblDirRegistration>().Property(x=>x.PostanskiBroj).HasColumnName("PostanskiBroj").HasColumnType("VarChar(10)").IsRequired().ValueGeneratedNever().HasMaxLength(10);
			modelBuilder.Entity<tblDirRegistration>().Property(x=>x.PostanskiUred).HasColumnName("PostanskiUred").HasColumnType("NVarChar(100)").IsRequired().ValueGeneratedNever().HasMaxLength(100);
			modelBuilder.Entity<tblDirRegistration>().Property(x=>x.Email).HasColumnName("Email").HasColumnType("VarChar(150)").IsRequired().ValueGeneratedNever().HasMaxLength(150);
			modelBuilder.Entity<tblDirRegistration>().Property(x=>x.WebSite).HasColumnName("WebSite").HasColumnType("VarChar(255)").IsRequired().ValueGeneratedNever().HasMaxLength(255);
			modelBuilder.Entity<tblDirRegistration>().Property(x=>x.Telefon).HasColumnName("Telefon").HasColumnType("VarChar(20)").IsRequired().ValueGeneratedNever().HasMaxLength(20);
			modelBuilder.Entity<tblDirRegistration>().Property(x=>x.Mobitel).HasColumnName("Mobitel").HasColumnType("VarChar(20)").IsRequired().ValueGeneratedNever().HasMaxLength(20);
		}

		partial void Customize_tblDirRegistration(ModelBuilder modelBuilder);
		#endregion

		#region tblFiskalRacunZahtjevLog
		private void Map_tblFiskalRacunZahtjevLog(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<tblFiskalRacunZahtjevLog>().ToTable("tblFiskalRacunZahtjevLog", "dbo");
			modelBuilder.Entity<tblFiskalRacunZahtjevLog>().HasKey(x=>x.FiskalRacunZahtjevLogID);
			modelBuilder.Entity<tblFiskalRacunZahtjevLog>().Property(x=>x.FiskalRacunZahtjevLogID).HasColumnName("FiskalRacunZahtjevLogID").HasColumnType("BigInt").IsRequired().ValueGeneratedOnAdd();
			modelBuilder.Entity<tblFiskalRacunZahtjevLog>().Property(x=>x.AppMemberID).HasColumnName("AppMemberID").HasColumnType("BigInt").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblFiskalRacunZahtjevLog>().Property(x=>x.IsProdukcija).HasColumnName("IsProdukcija").HasColumnType("Bit").ValueGeneratedNever();
			modelBuilder.Entity<tblFiskalRacunZahtjevLog>().Property(x=>x.BillDocumentID).HasColumnName("BillDocumentID").HasColumnType("BigInt").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblFiskalRacunZahtjevLog>().Property(x=>x.InsertionDate).HasColumnName("InsertionDate").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblFiskalRacunZahtjevLog>().Property(x=>x.FiskalniBrojRacuna).HasColumnName("FiskalniBrojRacuna").HasColumnType("VarChar(50)").IsRequired().ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<tblFiskalRacunZahtjevLog>().Property(x=>x.OIBOperatora).HasColumnName("OIBOperatora").HasColumnType("VarChar(15)").ValueGeneratedNever().HasMaxLength(15);
			modelBuilder.Entity<tblFiskalRacunZahtjevLog>().Property(x=>x.IsInPdvSustav).HasColumnName("IsInPdvSustav").HasColumnType("Bit").ValueGeneratedNever();
			modelBuilder.Entity<tblFiskalRacunZahtjevLog>().Property(x=>x.DatumDokumenta).HasColumnName("DatumDokumenta").HasColumnType("DateTime").ValueGeneratedNever();
			modelBuilder.Entity<tblFiskalRacunZahtjevLog>().Property(x=>x.PoreznaOsnovica).HasColumnName("PoreznaOsnovica").HasColumnType("Money").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblFiskalRacunZahtjevLog>().Property(x=>x.IznosPdva).HasColumnName("IznosPdva").HasColumnType("Money").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblFiskalRacunZahtjevLog>().Property(x=>x.IznosPorezPotrosnja).HasColumnName("IznosPorezPotrosnja").HasColumnType("Money").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblFiskalRacunZahtjevLog>().Property(x=>x.SveukupniIznos).HasColumnName("SveukupniIznos").HasColumnType("Money").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblFiskalRacunZahtjevLog>().Property(x=>x.ZKI).HasColumnName("ZKI").HasColumnType("VarChar(100)").ValueGeneratedNever().HasMaxLength(100);
			modelBuilder.Entity<tblFiskalRacunZahtjevLog>().Property(x=>x.OdgovorJIR).HasColumnName("OdgovorJIR").HasColumnType("VarChar(100)").ValueGeneratedNever().HasMaxLength(100);
			modelBuilder.Entity<tblFiskalRacunZahtjevLog>().Property(x=>x.OdgovorOpisGreske).HasColumnName("OdgovorOpisGreske").HasColumnType("VarChar(MAX)").ValueGeneratedNever();
		}

		partial void Customize_tblFiskalRacunZahtjevLog(ModelBuilder modelBuilder);
		#endregion

		#region tblPorezPdv
		private void Map_tblPorezPdv(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<tblPorezPdv>().ToTable("tblPorezPdv", "dbo");
			modelBuilder.Entity<tblPorezPdv>().HasKey(x=>x.BillPorezPdvID);
			modelBuilder.Entity<tblPorezPdv>().Property(x=>x.BillPorezPdvID).HasColumnName("BillPorezPdvID").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblPorezPdv>().Property(x=>x.IsActive).HasColumnName("IsActive").HasColumnType("Bit").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblPorezPdv>().Property(x=>x.Ordinal).HasColumnName("Ordinal").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblPorezPdv>().Property(x=>x.IsDefault).HasColumnName("IsDefault").HasColumnType("Bit").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblPorezPdv>().Property(x=>x.Naziv).HasColumnName("Naziv").HasColumnType("NVarChar(150)").IsRequired().ValueGeneratedNever().HasMaxLength(150);
			modelBuilder.Entity<tblPorezPdv>().Property(x=>x.PrintableText).HasColumnName("PrintableText").HasColumnType("NVarChar(250)").ValueGeneratedNever().HasMaxLength(250);
			modelBuilder.Entity<tblPorezPdv>().Property(x=>x.Opis).HasColumnName("Opis").HasColumnType("NVarChar(MAX)").ValueGeneratedNever();
		}

		partial void Customize_tblPorezPdv(ModelBuilder modelBuilder);
		#endregion

		#region tblPorezPdvPostotak
		private void Map_tblPorezPdvPostotak(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<tblPorezPdvPostotak>().ToTable("tblPorezPdvPostotak", "dbo");
			modelBuilder.Entity<tblPorezPdvPostotak>().HasKey(x=>x.BillPorezPdvPostotakID);
			modelBuilder.Entity<tblPorezPdvPostotak>().Property(x=>x.BillPorezPdvPostotakID).HasColumnName("BillPorezPdvPostotakID").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblPorezPdvPostotak>().Property(x=>x.BillPorezPdvID).HasColumnName("BillPorezPdvID").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblPorezPdvPostotak>().Property(x=>x.PdvPosto).HasColumnName("PdvPosto").HasColumnType("Money").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblPorezPdvPostotak>().Property(x=>x.StartDatum).HasColumnName("StartDatum").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblPorezPdvPostotak>().Property(x=>x.EndDatum).HasColumnName("EndDatum").HasColumnType("DateTime").ValueGeneratedNever();
		}

		partial void Customize_tblPorezPdvPostotak(ModelBuilder modelBuilder);
		#endregion

		#region tblPorezPotrosnja
		private void Map_tblPorezPotrosnja(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<tblPorezPotrosnja>().ToTable("tblPorezPotrosnja", "dbo");
			modelBuilder.Entity<tblPorezPotrosnja>().HasKey(x=>x.BillPorezPotrosnjaID);
			modelBuilder.Entity<tblPorezPotrosnja>().Property(x=>x.BillPorezPotrosnjaID).HasColumnName("BillPorezPotrosnjaID").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblPorezPotrosnja>().Property(x=>x.IsActive).HasColumnName("IsActive").HasColumnType("Bit").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblPorezPotrosnja>().Property(x=>x.Ordinal).HasColumnName("Ordinal").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblPorezPotrosnja>().Property(x=>x.IsDefault).HasColumnName("IsDefault").HasColumnType("Bit").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblPorezPotrosnja>().Property(x=>x.Naziv).HasColumnName("Naziv").HasColumnType("NVarChar(150)").IsRequired().ValueGeneratedNever().HasMaxLength(150);
			modelBuilder.Entity<tblPorezPotrosnja>().Property(x=>x.PrintableText).HasColumnName("PrintableText").HasColumnType("NVarChar(250)").IsRequired().ValueGeneratedNever().HasMaxLength(250);
			modelBuilder.Entity<tblPorezPotrosnja>().Property(x=>x.Opis).HasColumnName("Opis").HasColumnType("NVarChar(MAX)").IsRequired().ValueGeneratedNever();
		}

		partial void Customize_tblPorezPotrosnja(ModelBuilder modelBuilder);
		#endregion

		#region tblPorezPotrosnjaPostotak
		private void Map_tblPorezPotrosnjaPostotak(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<tblPorezPotrosnjaPostotak>().ToTable("tblPorezPotrosnjaPostotak", "dbo");
			modelBuilder.Entity<tblPorezPotrosnjaPostotak>().HasKey(x=>x.BillPorezPotrosnjaPostotakID);
			modelBuilder.Entity<tblPorezPotrosnjaPostotak>().Property(x=>x.BillPorezPotrosnjaPostotakID).HasColumnName("BillPorezPotrosnjaPostotakID").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblPorezPotrosnjaPostotak>().Property(x=>x.BillPorezPotrosnjaID).HasColumnName("BillPorezPotrosnjaID").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblPorezPotrosnjaPostotak>().Property(x=>x.PorezPosto).HasColumnName("PorezPosto").HasColumnType("Money").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblPorezPotrosnjaPostotak>().Property(x=>x.StartDatum).HasColumnName("StartDatum").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblPorezPotrosnjaPostotak>().Property(x=>x.EndDatum).HasColumnName("EndDatum").HasColumnType("DateTime").ValueGeneratedNever();
		}

		partial void Customize_tblPorezPotrosnjaPostotak(ModelBuilder modelBuilder);
		#endregion

		#region tblSocialMember
		private void Map_tblSocialMember(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<tblSocialMember>().ToTable("tblSocialMember", "dbo");
			modelBuilder.Entity<tblSocialMember>().HasKey(x=>x.SocialMemberID);
			modelBuilder.Entity<tblSocialMember>().Property(x=>x.SocialMemberID).HasColumnName("SocialMemberID").HasColumnType("BigInt").IsRequired().ValueGeneratedOnAdd();
			modelBuilder.Entity<tblSocialMember>().Property(x=>x.SocialProviderID).HasColumnName("SocialProviderID").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblSocialMember>().Property(x=>x.InsertionDate).HasColumnName("InsertionDate").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblSocialMember>().Property(x=>x.LastLoginDate).HasColumnName("LastLoginDate").HasColumnType("DateTime").ValueGeneratedNever();
			modelBuilder.Entity<tblSocialMember>().Property(x=>x.SocialId).HasColumnName("SocialId").HasColumnType("VarChar(200)").ValueGeneratedNever().HasMaxLength(200);
			modelBuilder.Entity<tblSocialMember>().Property(x=>x.EmailAddress).HasColumnName("EmailAddress").HasColumnType("NVarChar(250)").ValueGeneratedNever().HasMaxLength(250);
			modelBuilder.Entity<tblSocialMember>().Property(x=>x.Password).HasColumnName("Password").HasColumnType("NVarChar(100)").ValueGeneratedNever().HasMaxLength(100);
			modelBuilder.Entity<tblSocialMember>().Property(x=>x.PasswordRecoverySentDate).HasColumnName("PasswordRecoverySentDate").HasColumnType("DateTime").ValueGeneratedNever();
			modelBuilder.Entity<tblSocialMember>().Property(x=>x.ConfirmationEmailSentDate).HasColumnName("ConfirmationEmailSentDate").HasColumnType("DateTime").ValueGeneratedNever();
			modelBuilder.Entity<tblSocialMember>().Property(x=>x.EmailConfirmedDate).HasColumnName("EmailConfirmedDate").HasColumnType("DateTime").ValueGeneratedNever();
			modelBuilder.Entity<tblSocialMember>().Property(x=>x.PhoneNumber).HasColumnName("PhoneNumber").HasColumnType("VarChar(20)").ValueGeneratedNever().HasMaxLength(20);
			modelBuilder.Entity<tblSocialMember>().Property(x=>x.FullName).HasColumnName("FullName").HasColumnType("NVarChar(200)").ValueGeneratedNever().HasMaxLength(200);
			modelBuilder.Entity<tblSocialMember>().Property(x=>x.FirstName).HasColumnName("FirstName").HasColumnType("NVarChar(100)").ValueGeneratedNever().HasMaxLength(100);
			modelBuilder.Entity<tblSocialMember>().Property(x=>x.LastName).HasColumnName("LastName").HasColumnType("NVarChar(100)").ValueGeneratedNever().HasMaxLength(100);
			modelBuilder.Entity<tblSocialMember>().Property(x=>x.PictureUrl).HasColumnName("PictureUrl").HasColumnType("VarChar(500)").ValueGeneratedNever().HasMaxLength(500);
			modelBuilder.Entity<tblSocialMember>().Property(x=>x.SocialMemberStatusID).HasColumnName("SocialMemberStatusID").HasColumnType("Int").ValueGeneratedNever();
			modelBuilder.Entity<tblSocialMember>().Property(x=>x.BillClientID).HasColumnName("BillClientID").HasColumnType("BigInt").ValueGeneratedNever();
			modelBuilder.Entity<tblSocialMember>().Property(x=>x.DirClientID).HasColumnName("DirClientID").HasColumnType("BigInt").ValueGeneratedNever();
		}

		partial void Customize_tblSocialMember(ModelBuilder modelBuilder);
		#endregion

		#region tblSocialMemberStatus
		private void Map_tblSocialMemberStatus(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<tblSocialMemberStatus>().ToTable("tblSocialMemberStatus", "dbo");
			modelBuilder.Entity<tblSocialMemberStatus>().HasKey(x=>x.SocialMemberStatusID);
			modelBuilder.Entity<tblSocialMemberStatus>().Property(x=>x.SocialMemberStatusID).HasColumnName("SocialMemberStatusID").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblSocialMemberStatus>().Property(x=>x.Ordinal).HasColumnName("Ordinal").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblSocialMemberStatus>().Property(x=>x.PropertyName).HasColumnName("PropertyName").HasColumnType("NVarChar(100)").ValueGeneratedNever().HasMaxLength(100);
		}

		partial void Customize_tblSocialMemberStatus(ModelBuilder modelBuilder);
		#endregion

		#region tblSocialProvider
		private void Map_tblSocialProvider(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<tblSocialProvider>().ToTable("tblSocialProvider", "dbo");
			modelBuilder.Entity<tblSocialProvider>().HasKey(x=>x.SocialProviderID);
			modelBuilder.Entity<tblSocialProvider>().Property(x=>x.SocialProviderID).HasColumnName("SocialProviderID").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblSocialProvider>().Property(x=>x.PropertyName).HasColumnName("PropertyName").HasColumnType("VarChar(100)").ValueGeneratedNever().HasMaxLength(100);
		}

		partial void Customize_tblSocialProvider(ModelBuilder modelBuilder);
		#endregion

		#region tblWeatherCity
		private void Map_tblWeatherCity(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<tblWeatherCity>().ToTable("tblWeatherCity", "dbo");
			modelBuilder.Entity<tblWeatherCity>().HasKey(x=>x.WeatherCityID);
			modelBuilder.Entity<tblWeatherCity>().Property(x=>x.WeatherCityID).HasColumnName("WeatherCityID").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblWeatherCity>().Property(x=>x.Name).HasColumnName("Name").HasColumnType("NVarChar(100)").IsRequired().ValueGeneratedNever().HasMaxLength(100);
			modelBuilder.Entity<tblWeatherCity>().Property(x=>x.LongName).HasColumnName("LongName").HasColumnType("NVarChar(200)").ValueGeneratedNever().HasMaxLength(200);
			modelBuilder.Entity<tblWeatherCity>().Property(x=>x.AccuweatherCode).HasColumnName("AccuweatherCode").HasColumnType("VarChar(50)").ValueGeneratedNever().HasMaxLength(50);
			modelBuilder.Entity<tblWeatherCity>().Property(x=>x.Language).HasColumnName("Language").HasColumnType("VarChar(10)").IsRequired().ValueGeneratedNever().HasMaxLength(10);
			modelBuilder.Entity<tblWeatherCity>().Property(x=>x.DownloadAccuweather).HasColumnName("DownloadAccuweather").HasColumnType("Bit").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblWeatherCity>().Property(x=>x.UrlName).HasColumnName("UrlName").HasColumnType("VarChar(100)").IsRequired().ValueGeneratedNever().HasMaxLength(100);
			modelBuilder.Entity<tblWeatherCity>().Property(x=>x.Population).HasColumnName("Population").HasColumnType("Int").ValueGeneratedNever();
			modelBuilder.Entity<tblWeatherCity>().Property(x=>x.Latitude).HasColumnName("Latitude").HasColumnType("Decimal(18,10)").ValueGeneratedNever().HasMaxLength(18);
			modelBuilder.Entity<tblWeatherCity>().Property(x=>x.Longitude).HasColumnName("Longitude").HasColumnType("Decimal(18,10)").ValueGeneratedNever().HasMaxLength(18);
		}

		partial void Customize_tblWeatherCity(ModelBuilder modelBuilder);
		#endregion

		#region tblWeatherDayInfo
		private void Map_tblWeatherDayInfo(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<tblWeatherDayInfo>().ToTable("tblWeatherDayInfo", "dbo");
			modelBuilder.Entity<tblWeatherDayInfo>().HasKey(x=>x.WeatherDayInfoID);
			modelBuilder.Entity<tblWeatherDayInfo>().Property(x=>x.WeatherDayInfoID).HasColumnName("WeatherDayInfoID").HasColumnType("BigInt").IsRequired().ValueGeneratedOnAdd();
			modelBuilder.Entity<tblWeatherDayInfo>().Property(x=>x.WeatherCityID).HasColumnName("WeatherCityID").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblWeatherDayInfo>().Property(x=>x.LastUpdateDate).HasColumnName("LastUpdateDate").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblWeatherDayInfo>().Property(x=>x.WeatherDate).HasColumnName("WeatherDate").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblWeatherDayInfo>().Property(x=>x.Sunrise).HasColumnName("Sunrise").HasColumnType("Time(7)").ValueGeneratedNever().HasMaxLength(7);
			modelBuilder.Entity<tblWeatherDayInfo>().Property(x=>x.Sunset).HasColumnName("Sunset").HasColumnType("Time(7)").ValueGeneratedNever().HasMaxLength(7);
			modelBuilder.Entity<tblWeatherDayInfo>().Property(x=>x.SunDuration).HasColumnName("SunDuration").HasColumnType("Time(7)").ValueGeneratedNever().HasMaxLength(7);
			modelBuilder.Entity<tblWeatherDayInfo>().Property(x=>x.Moonrise).HasColumnName("Moonrise").HasColumnType("Time(7)").ValueGeneratedNever().HasMaxLength(7);
			modelBuilder.Entity<tblWeatherDayInfo>().Property(x=>x.Moonset).HasColumnName("Moonset").HasColumnType("Time(7)").ValueGeneratedNever().HasMaxLength(7);
			modelBuilder.Entity<tblWeatherDayInfo>().Property(x=>x.MoonDuration).HasColumnName("MoonDuration").HasColumnType("Time(7)").ValueGeneratedNever().HasMaxLength(7);
		}

		partial void Customize_tblWeatherDayInfo(ModelBuilder modelBuilder);
		#endregion

		#region tblWeatherInfo
		private void Map_tblWeatherInfo(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<tblWeatherInfo>().ToTable("tblWeatherInfo", "dbo");
			modelBuilder.Entity<tblWeatherInfo>().HasKey(x=>x.WeatherInfoID);
			modelBuilder.Entity<tblWeatherInfo>().Property(x=>x.WeatherInfoID).HasColumnName("WeatherInfoID").HasColumnType("BigInt").IsRequired().ValueGeneratedOnAdd();
			modelBuilder.Entity<tblWeatherInfo>().Property(x=>x.WeatherCityID).HasColumnName("WeatherCityID").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblWeatherInfo>().Property(x=>x.Language).HasColumnName("Language").HasColumnType("NVarChar(10)").IsRequired().ValueGeneratedNever().HasMaxLength(10);
			modelBuilder.Entity<tblWeatherInfo>().Property(x=>x.LastUpdateDate).HasColumnName("LastUpdateDate").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblWeatherInfo>().Property(x=>x.WeatherDate).HasColumnName("WeatherDate").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblWeatherInfo>().Property(x=>x.WeatherKindID).HasColumnName("WeatherKindID").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblWeatherInfo>().Property(x=>x.Temperature).HasColumnName("Temperature").HasColumnType("Decimal(5,2)").ValueGeneratedNever().HasMaxLength(5);
			modelBuilder.Entity<tblWeatherInfo>().Property(x=>x.TemperatureUnits).HasColumnName("TemperatureUnits").HasColumnType("Char(1)").ValueGeneratedNever().HasMaxLength(1);
			modelBuilder.Entity<tblWeatherInfo>().Property(x=>x.RealFeel).HasColumnName("RealFeel").HasColumnType("Decimal(5,2)").ValueGeneratedNever().HasMaxLength(5);
			modelBuilder.Entity<tblWeatherInfo>().Property(x=>x.RealFeelShade).HasColumnName("RealFeelShade").HasColumnType("Decimal(5,2)").ValueGeneratedNever().HasMaxLength(5);
			modelBuilder.Entity<tblWeatherInfo>().Property(x=>x.IconValue).HasColumnName("IconValue").HasColumnType("Int").ValueGeneratedNever();
			modelBuilder.Entity<tblWeatherInfo>().Property(x=>x.ShortDescription).HasColumnName("ShortDescription").HasColumnType("NVarChar(500)").ValueGeneratedNever().HasMaxLength(500);
			modelBuilder.Entity<tblWeatherInfo>().Property(x=>x.UVIndex).HasColumnName("UVIndex").HasColumnType("NVarChar(20)").ValueGeneratedNever().HasMaxLength(20);
			modelBuilder.Entity<tblWeatherInfo>().Property(x=>x.Wind).HasColumnName("Wind").HasColumnType("NVarChar(20)").ValueGeneratedNever().HasMaxLength(20);
			modelBuilder.Entity<tblWeatherInfo>().Property(x=>x.WindGusts).HasColumnName("WindGusts").HasColumnType("VarChar(20)").ValueGeneratedNever().HasMaxLength(20);
			modelBuilder.Entity<tblWeatherInfo>().Property(x=>x.ProbabilityOfPrecipitation).HasColumnName("ProbabilityOfPrecipitation").HasColumnType("VarChar(20)").ValueGeneratedNever().HasMaxLength(20);
			modelBuilder.Entity<tblWeatherInfo>().Property(x=>x.ProbabilityOfThunderstorms).HasColumnName("ProbabilityOfThunderstorms").HasColumnType("VarChar(20)").ValueGeneratedNever().HasMaxLength(20);
			modelBuilder.Entity<tblWeatherInfo>().Property(x=>x.Precipitation).HasColumnName("Precipitation").HasColumnType("VarChar(20)").ValueGeneratedNever().HasMaxLength(20);
			modelBuilder.Entity<tblWeatherInfo>().Property(x=>x.Rain).HasColumnName("Rain").HasColumnType("VarChar(20)").ValueGeneratedNever().HasMaxLength(20);
			modelBuilder.Entity<tblWeatherInfo>().Property(x=>x.Snow).HasColumnName("Snow").HasColumnType("VarChar(20)").ValueGeneratedNever().HasMaxLength(20);
			modelBuilder.Entity<tblWeatherInfo>().Property(x=>x.Ice).HasColumnName("Ice").HasColumnType("VarChar(20)").ValueGeneratedNever().HasMaxLength(20);
			modelBuilder.Entity<tblWeatherInfo>().Property(x=>x.HoursOfPrecipitation).HasColumnName("HoursOfPrecipitation").HasColumnType("VarChar(20)").ValueGeneratedNever().HasMaxLength(20);
			modelBuilder.Entity<tblWeatherInfo>().Property(x=>x.HoursOfRain).HasColumnName("HoursOfRain").HasColumnType("VarChar(20)").ValueGeneratedNever().HasMaxLength(20);
			modelBuilder.Entity<tblWeatherInfo>().Property(x=>x.Humidity).HasColumnName("Humidity").HasColumnType("VarChar(20)").ValueGeneratedNever().HasMaxLength(20);
			modelBuilder.Entity<tblWeatherInfo>().Property(x=>x.DewPoint).HasColumnName("DewPoint").HasColumnType("VarChar(20)").ValueGeneratedNever().HasMaxLength(20);
			modelBuilder.Entity<tblWeatherInfo>().Property(x=>x.Pressure).HasColumnName("Pressure").HasColumnType("VarChar(20)").ValueGeneratedNever().HasMaxLength(20);
			modelBuilder.Entity<tblWeatherInfo>().Property(x=>x.CloudCover).HasColumnName("CloudCover").HasColumnType("VarChar(20)").ValueGeneratedNever().HasMaxLength(20);
			modelBuilder.Entity<tblWeatherInfo>().Property(x=>x.Visibility).HasColumnName("Visibility").HasColumnType("VarChar(20)").ValueGeneratedNever().HasMaxLength(20);
			modelBuilder.Entity<tblWeatherInfo>().Property(x=>x.Ceiling).HasColumnName("Ceiling").HasColumnType("VarChar(20)").ValueGeneratedNever().HasMaxLength(20);
			modelBuilder.Entity<tblWeatherInfo>().Property(x=>x.AirQuality).HasColumnName("AirQuality").HasColumnType("VarChar(20)").ValueGeneratedNever().HasMaxLength(20);
		}

		partial void Customize_tblWeatherInfo(ModelBuilder modelBuilder);
		#endregion

		#region tblWeatherKind
		private void Map_tblWeatherKind(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<tblWeatherKind>().ToTable("tblWeatherKind", "dbo");
			modelBuilder.Entity<tblWeatherKind>().HasKey(x=>x.WeatherKindID);
			modelBuilder.Entity<tblWeatherKind>().Property(x=>x.WeatherKindID).HasColumnName("WeatherKindID").HasColumnType("Int").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<tblWeatherKind>().Property(x=>x.Name).HasColumnName("Name").HasColumnType("VarChar(50)").IsRequired().ValueGeneratedNever().HasMaxLength(50);
		}

		partial void Customize_tblWeatherKind(ModelBuilder modelBuilder);
		#endregion

		#region viewBookkeepingFiduciaExport
		private void Map_viewBookkeepingFiduciaExport(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<viewBookkeepingFiduciaExport>().ToTable("viewBookkeepingFiduciaExport", "dbo");
			modelBuilder.Entity<viewBookkeepingFiduciaExport>().HasNoKey();
			modelBuilder.Entity<viewBookkeepingFiduciaExport>().Property(x=>x.FiduciaExportID).HasColumnName("FiduciaExportID").HasColumnType("BigInt").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<viewBookkeepingFiduciaExport>().Property(x=>x.DatumGeneriranja).HasColumnName("DatumGeneriranja").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<viewBookkeepingFiduciaExport>().Property(x=>x.BillFirmaID).HasColumnName("BillFirmaID").HasColumnType("BigInt").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<viewBookkeepingFiduciaExport>().Property(x=>x.StartDateIncluded).HasColumnName("StartDateIncluded").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<viewBookkeepingFiduciaExport>().Property(x=>x.EndDateExcluded).HasColumnName("EndDateExcluded").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<viewBookkeepingFiduciaExport>().Property(x=>x.HasAllData).HasColumnName("HasAllData").HasColumnType("Bit").ValueGeneratedNever();
			modelBuilder.Entity<viewBookkeepingFiduciaExport>().Property(x=>x.HasKlijenti).HasColumnName("HasKlijenti").HasColumnType("Bit").ValueGeneratedNever();
			modelBuilder.Entity<viewBookkeepingFiduciaExport>().Property(x=>x.HasRacuniKonta).HasColumnName("HasRacuniKonta").HasColumnType("Bit").ValueGeneratedNever();
			modelBuilder.Entity<viewBookkeepingFiduciaExport>().Property(x=>x.HasRacuniKnjiga).HasColumnName("HasRacuniKnjiga").HasColumnType("Bit").ValueGeneratedNever();
			modelBuilder.Entity<viewBookkeepingFiduciaExport>().Property(x=>x.HasPreknjizenja).HasColumnName("HasPreknjizenja").HasColumnType("Bit").ValueGeneratedNever();
		}

		partial void Customize_viewBookkeepingFiduciaExport(ModelBuilder modelBuilder);
		#endregion

		#region viewBookkeepingSynesisExport
		private void Map_viewBookkeepingSynesisExport(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<viewBookkeepingSynesisExport>().ToTable("viewBookkeepingSynesisExport", "dbo");
			modelBuilder.Entity<viewBookkeepingSynesisExport>().HasNoKey();
			modelBuilder.Entity<viewBookkeepingSynesisExport>().Property(x=>x.SynesisExportID).HasColumnName("SynesisExportID").HasColumnType("BigInt").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<viewBookkeepingSynesisExport>().Property(x=>x.DatumGeneriranja).HasColumnName("DatumGeneriranja").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<viewBookkeepingSynesisExport>().Property(x=>x.BillFirmaID).HasColumnName("BillFirmaID").HasColumnType("BigInt").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<viewBookkeepingSynesisExport>().Property(x=>x.StartDateIncluded).HasColumnName("StartDateIncluded").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<viewBookkeepingSynesisExport>().Property(x=>x.EndDateExcluded).HasColumnName("EndDateExcluded").HasColumnType("DateTime").IsRequired().ValueGeneratedNever();
			modelBuilder.Entity<viewBookkeepingSynesisExport>().Property(x=>x.HasAllData).HasColumnName("HasAllData").HasColumnType("Bit").ValueGeneratedNever();
			modelBuilder.Entity<viewBookkeepingSynesisExport>().Property(x=>x.HasKlijenti).HasColumnName("HasKlijenti").HasColumnType("Bit").ValueGeneratedNever();
			modelBuilder.Entity<viewBookkeepingSynesisExport>().Property(x=>x.HasFinancKnjig).HasColumnName("HasFinancKnjig").HasColumnType("Bit").ValueGeneratedNever();
			modelBuilder.Entity<viewBookkeepingSynesisExport>().Property(x=>x.HasUlazniRacuni).HasColumnName("HasUlazniRacuni").HasColumnType("Bit").ValueGeneratedNever();
			modelBuilder.Entity<viewBookkeepingSynesisExport>().Property(x=>x.HasIzlazniRacuni).HasColumnName("HasIzlazniRacuni").HasColumnType("Bit").ValueGeneratedNever();
		}

		partial void Customize_viewBookkeepingSynesisExport(ModelBuilder modelBuilder);
		#endregion

		#region viewRandom
		private void Map_viewRandom(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<viewRandom>().ToTable("viewRandom", "dbo");
			modelBuilder.Entity<viewRandom>().HasNoKey();
			modelBuilder.Entity<viewRandom>().Property(x=>x.Random).HasColumnName("Random").HasColumnType("Float").ValueGeneratedNever();
		}

		partial void Customize_viewRandom(ModelBuilder modelBuilder);
		#endregion

		#endregion

		#region Relationships mapping
		private void RelationshipsMapping(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<tblAppMember>().HasOne(x=>x.tblAppMemberStatus).WithMany(x=>x.tblAppMemberList).HasForeignKey(x=>x.AppMemberStatusID).IsRequired(true);
			modelBuilder.Entity<tblAppMember>().HasMany(x=>x.tblAppMemberPictureList).WithOne(x=>x.tblAppMember).HasForeignKey(x=>x.AppMemberID).IsRequired(false);
			modelBuilder.Entity<tblAppMember>().HasOne(x=>x.tblBillFirma).WithMany(x=>x.tblAppMemberList).HasForeignKey(x=>x.BillFirmaID).IsRequired(false);
			modelBuilder.Entity<tblAppMember>().HasOne(x=>x.tblBillOperator).WithMany(x=>x.tblAppMemberList).HasForeignKey(x=>x.BillOperatorID).IsRequired(false);
			modelBuilder.Entity<tblAppMember>().HasOne(x=>x.tblAppMemberPermission).WithOne(x=>x.tblAppMember).HasForeignKey<tblAppMemberPermission>(x=>x.AppMemberID).IsRequired(true).OnDelete(DeleteBehavior.Cascade);
			modelBuilder.Entity<tblAppMember>().HasMany(x=>x.tblBankaPrometList).WithOne(x=>x.tblAppMember).HasForeignKey(x=>x.AppMemberID).IsRequired(true);
			modelBuilder.Entity<tblAppMember>().HasMany(x=>x.tblBillDocumentList).WithOne(x=>x.tblAppMember).HasForeignKey(x=>x.AppMemberID).IsRequired(true);
			modelBuilder.Entity<tblAppMember>().HasMany(x=>x.tblBillPrintLogList).WithOne(x=>x.tblAppMember).HasForeignKey(x=>x.AppMemberID).IsRequired(true);
			modelBuilder.Entity<tblAppMember>().HasMany(x=>x.tblDirClientBlacklistList).WithOne(x=>x.tblAppMember).HasForeignKey(x=>x.AppMemberID).IsRequired(true);
			modelBuilder.Entity<tblAppMember>().HasMany(x=>x.tblFiskalRacunZahtjevLogList).WithOne(x=>x.tblAppMember).HasForeignKey(x=>x.AppMemberID).IsRequired(true);

			modelBuilder.Entity<tblAppMemberPermission>().HasOne(x=>x.tblAppMember).WithOne(x=>x.tblAppMemberPermission).HasForeignKey<tblAppMember>(x=>x.AppMemberID).IsRequired(true).OnDelete(DeleteBehavior.Cascade);

			modelBuilder.Entity<tblAppMemberPicture>().HasOne(x=>x.tblAppMember).WithMany(x=>x.tblAppMemberPictureList).HasForeignKey(x=>x.AppMemberID).IsRequired(false);

			modelBuilder.Entity<tblAppMemberStatus>().HasMany(x=>x.tblAppMemberList).WithOne(x=>x.tblAppMemberStatus).HasForeignKey(x=>x.AppMemberStatusID).IsRequired(true);

			modelBuilder.Entity<tblBanka>().HasMany(x=>x.tblBillFirmaTransakcijskiRacunList).WithOne(x=>x.tblBanka).HasForeignKey(x=>x.BankaID).IsRequired(true);

			modelBuilder.Entity<tblBankaPromet>().HasOne(x=>x.tblAppMember).WithMany(x=>x.tblBankaPrometList).HasForeignKey(x=>x.AppMemberID).IsRequired(true);
			modelBuilder.Entity<tblBankaPromet>().HasOne(x=>x.tblBankaPrometVrsta).WithMany(x=>x.tblBankaPrometList).HasForeignKey(x=>x.BankaPrometVrstaID).IsRequired(false);
			modelBuilder.Entity<tblBankaPromet>().HasOne(x=>x.tblBillFirmaTransakcijskiRacun).WithMany(x=>x.tblBankaPrometList).HasForeignKey(x=>x.BillFirmaTransakcijskiRacunID).IsRequired(true);
			modelBuilder.Entity<tblBankaPromet>().HasMany(x=>x.tblBankaPrometDocumentList).WithOne(x=>x.tblBankaPromet).HasForeignKey(x=>x.BankaPrometID).IsRequired(true);

			modelBuilder.Entity<tblBankaPrometDocument>().HasOne(x=>x.tblBankaPromet).WithMany(x=>x.tblBankaPrometDocumentList).HasForeignKey(x=>x.BankaPrometID).IsRequired(true);

			modelBuilder.Entity<tblBankaPrometVrsta>().HasMany(x=>x.tblBankaPrometList).WithOne(x=>x.tblBankaPrometVrsta).HasForeignKey(x=>x.BankaPrometVrstaID).IsRequired(false);

			modelBuilder.Entity<tblBillCategory>().HasOne(x=>x.ParentBillCategory).WithMany(x=>x.BillCategoryList).HasForeignKey(x=>x.ParentBillCategoryID).IsRequired(false);
			modelBuilder.Entity<tblBillCategory>().HasMany(x=>x.BillCategoryList).WithOne(x=>x.ParentBillCategory).HasForeignKey(x=>x.ParentBillCategoryID).IsRequired(false);
			modelBuilder.Entity<tblBillCategory>().HasOne(x=>x.tblBillPoslovniProstor).WithMany(x=>x.tblBillCategoryList).HasForeignKey(x=>x.BillPoslovniProstorID).IsRequired(true);
			modelBuilder.Entity<tblBillCategory>().HasMany(x=>x.tblBillProductCategoryList).WithOne(x=>x.tblBillCategory).HasForeignKey(x=>x.BillCategoryID).IsRequired(true);

			modelBuilder.Entity<tblBillClient>().HasOne(x=>x.tblBillFirma).WithMany(x=>x.tblBillClientList).HasForeignKey(x=>x.BillFirmaID).IsRequired(true);
			modelBuilder.Entity<tblBillClient>().HasOne(x=>x.tblDirClient).WithMany(x=>x.tblBillClientList).HasForeignKey(x=>x.DirClientID).IsRequired(false);
			modelBuilder.Entity<tblBillClient>().HasOne(x=>x.tblBillClientFullText).WithOne(x=>x.tblBillClient).HasForeignKey<tblBillClientFullText>(x=>x.BillClientID).IsRequired(true).OnDelete(DeleteBehavior.Cascade);
			modelBuilder.Entity<tblBillClient>().HasMany(x=>x.tblBillDocumentList).WithOne(x=>x.tblBillClient).HasForeignKey(x=>x.BillClientID).IsRequired(true);
			modelBuilder.Entity<tblBillClient>().HasMany(x=>x.tblSocialMemberList).WithOne(x=>x.tblBillClient).HasForeignKey(x=>x.BillClientID).IsRequired(false);

			modelBuilder.Entity<tblBillClientFullText>().HasOne(x=>x.tblBillClient).WithOne(x=>x.tblBillClientFullText).HasForeignKey<tblBillClient>(x=>x.BillClientID).IsRequired(true).OnDelete(DeleteBehavior.Cascade);

			modelBuilder.Entity<tblBillDocument>().HasOne(x=>x.tblAppMember).WithMany(x=>x.tblBillDocumentList).HasForeignKey(x=>x.AppMemberID).IsRequired(true);
			modelBuilder.Entity<tblBillDocument>().HasOne(x=>x.tblBillClient).WithMany(x=>x.tblBillDocumentList).HasForeignKey(x=>x.BillClientID).IsRequired(true);
			modelBuilder.Entity<tblBillDocument>().HasOne(x=>x.ParentBillDocument).WithMany(x=>x.BillDocumentList).HasForeignKey(x=>x.ParentBillDocumentID).IsRequired(false);
			modelBuilder.Entity<tblBillDocument>().HasMany(x=>x.BillDocumentList).WithOne(x=>x.ParentBillDocument).HasForeignKey(x=>x.ParentBillDocumentID).IsRequired(false);
			modelBuilder.Entity<tblBillDocument>().HasOne(x=>x.tblBillDocumentVariant).WithMany(x=>x.tblBillDocumentList).HasForeignKey(x=>x.VariantID).IsRequired(false);
			modelBuilder.Entity<tblBillDocument>().HasOne(x=>x.tblBillNaplatniUredjaj).WithMany(x=>x.tblBillDocumentList).HasForeignKey(x=>x.BillNaplatniUredjajID).IsRequired(true);
			modelBuilder.Entity<tblBillDocument>().HasOne(x=>x.tblBillDocumentCalculated).WithOne(x=>x.tblBillDocument).HasForeignKey<tblBillDocumentCalculated>(x=>x.BillDocumentID).IsRequired(true).OnDelete(DeleteBehavior.Cascade);
			modelBuilder.Entity<tblBillDocument>().HasMany(x=>x.tblBillDocumentStavkaList).WithOne(x=>x.tblBillDocument).HasForeignKey(x=>x.BillDocumentID).IsRequired(true).OnDelete(DeleteBehavior.Cascade);
			modelBuilder.Entity<tblBillDocument>().HasMany(x=>x.tblBillDownloadLogList).WithOne(x=>x.tblBillDocument).HasForeignKey(x=>x.BillDocumentID).IsRequired(false);
			modelBuilder.Entity<tblBillDocument>().HasMany(x=>x.tblFiskalRacunZahtjevLogList).WithOne(x=>x.tblBillDocument).HasForeignKey(x=>x.BillDocumentID).IsRequired(true);

			modelBuilder.Entity<tblBillDocumentCalculated>().HasOne(x=>x.tblBillDocument).WithOne(x=>x.tblBillDocumentCalculated).HasForeignKey<tblBillDocument>(x=>x.BillDocumentID).IsRequired(true).OnDelete(DeleteBehavior.Cascade);

			modelBuilder.Entity<tblBillDocumentStavka>().HasOne(x=>x.tblBillDocument).WithMany(x=>x.tblBillDocumentStavkaList).HasForeignKey(x=>x.BillDocumentID).IsRequired(true).OnDelete(DeleteBehavior.Cascade);
			modelBuilder.Entity<tblBillDocumentStavka>().HasOne(x=>x.tblBillMjera).WithMany(x=>x.tblBillDocumentStavkaList).HasForeignKey(x=>x.BillMjeraID).IsRequired(true);
			modelBuilder.Entity<tblBillDocumentStavka>().HasOne(x=>x.tblBillPoreznaGrupa).WithMany(x=>x.tblBillDocumentStavkaList).HasForeignKey(x=>x.BillPoreznaGrupaID).IsRequired(true);
			modelBuilder.Entity<tblBillDocumentStavka>().HasOne(x=>x.tblBillProduct).WithMany(x=>x.tblBillDocumentStavkaList).HasForeignKey(x=>x.BillProductID).IsRequired(true);

			modelBuilder.Entity<tblBillDocumentTip>().HasMany(x=>x.tblBillNaplatniUredjajList).WithOne(x=>x.tblBillDocumentTip).HasForeignKey(x=>x.BillDocumentTipID).IsRequired(true);

			modelBuilder.Entity<tblBillDocumentVariant>().HasMany(x=>x.tblBillDocumentList).WithOne(x=>x.tblBillDocumentVariant).HasForeignKey(x=>x.VariantID).IsRequired(false);

			modelBuilder.Entity<tblBillDownloadLog>().HasOne(x=>x.tblBillDocument).WithMany(x=>x.tblBillDownloadLogList).HasForeignKey(x=>x.BillDocumentID).IsRequired(false);

			modelBuilder.Entity<tblBillFirma>().HasMany(x=>x.tblAppMemberList).WithOne(x=>x.tblBillFirma).HasForeignKey(x=>x.BillFirmaID).IsRequired(false);
			modelBuilder.Entity<tblBillFirma>().HasMany(x=>x.tblBillClientList).WithOne(x=>x.tblBillFirma).HasForeignKey(x=>x.BillFirmaID).IsRequired(true);
			modelBuilder.Entity<tblBillFirma>().HasOne(x=>x.tblBillFirmaCertificateMode).WithMany(x=>x.tblBillFirmaList).HasForeignKey(x=>x.BillFirmaCertificateModeID).IsRequired(true);
			modelBuilder.Entity<tblBillFirma>().HasMany(x=>x.tblBillFirmaCertificateList).WithOne(x=>x.tblBillFirma).HasForeignKey(x=>x.BillFirmaID).IsRequired(true);
			modelBuilder.Entity<tblBillFirma>().HasMany(x=>x.tblBillFirmaPosList).WithOne(x=>x.tblBillFirma).HasForeignKey(x=>x.BillFirmaID).IsRequired(true);
			modelBuilder.Entity<tblBillFirma>().HasMany(x=>x.tblBillFirmaTransakcijskiRacunList).WithOne(x=>x.tblBillFirma).HasForeignKey(x=>x.BillFirmaID).IsRequired(true);
			modelBuilder.Entity<tblBillFirma>().HasMany(x=>x.tblBillPoslovniProstorList).WithOne(x=>x.tblBillFirma).HasForeignKey(x=>x.BillFirmaID).IsRequired(true);
			modelBuilder.Entity<tblBillFirma>().HasMany(x=>x.tblBookkeepingFiduciaExportList).WithOne(x=>x.tblBillFirma).HasForeignKey(x=>x.BillFirmaID).IsRequired(true);
			modelBuilder.Entity<tblBillFirma>().HasMany(x=>x.tblBookkeepingSynesisExportList).WithOne(x=>x.tblBillFirma).HasForeignKey(x=>x.BillFirmaID).IsRequired(true);
			modelBuilder.Entity<tblBillFirma>().HasMany(x=>x.tblDirClientBlacklistList).WithOne(x=>x.tblBillFirma).HasForeignKey(x=>x.BillFirmaID).IsRequired(true);

			modelBuilder.Entity<tblBillFirmaCertificate>().HasOne(x=>x.tblBillFirma).WithMany(x=>x.tblBillFirmaCertificateList).HasForeignKey(x=>x.BillFirmaID).IsRequired(true);
			modelBuilder.Entity<tblBillFirmaCertificate>().HasOne(x=>x.tblBillFirmaCertificateMode).WithMany(x=>x.tblBillFirmaCertificateList).HasForeignKey(x=>x.BillFirmaCertificateModeID).IsRequired(false);

			modelBuilder.Entity<tblBillFirmaCertificateMode>().HasMany(x=>x.tblBillFirmaList).WithOne(x=>x.tblBillFirmaCertificateMode).HasForeignKey(x=>x.BillFirmaCertificateModeID).IsRequired(true);
			modelBuilder.Entity<tblBillFirmaCertificateMode>().HasMany(x=>x.tblBillFirmaCertificateList).WithOne(x=>x.tblBillFirmaCertificateMode).HasForeignKey(x=>x.BillFirmaCertificateModeID).IsRequired(false);

			modelBuilder.Entity<tblBillFirmaPos>().HasOne(x=>x.tblBillFirma).WithMany(x=>x.tblBillFirmaPosList).HasForeignKey(x=>x.BillFirmaID).IsRequired(true);

			modelBuilder.Entity<tblBillFirmaTransakcijskiRacun>().HasMany(x=>x.tblBankaPrometList).WithOne(x=>x.tblBillFirmaTransakcijskiRacun).HasForeignKey(x=>x.BillFirmaTransakcijskiRacunID).IsRequired(true);
			modelBuilder.Entity<tblBillFirmaTransakcijskiRacun>().HasOne(x=>x.tblBanka).WithMany(x=>x.tblBillFirmaTransakcijskiRacunList).HasForeignKey(x=>x.BankaID).IsRequired(true);
			modelBuilder.Entity<tblBillFirmaTransakcijskiRacun>().HasOne(x=>x.tblBillFirma).WithMany(x=>x.tblBillFirmaTransakcijskiRacunList).HasForeignKey(x=>x.BillFirmaID).IsRequired(true);
			modelBuilder.Entity<tblBillFirmaTransakcijskiRacun>().HasOne(x=>x.tblBillFirmaTransakcijskiRacunEmail).WithMany(x=>x.tblBillFirmaTransakcijskiRacunList).HasForeignKey(x=>x.BillFirmaTransakcijskiRacunEmailID).IsRequired(false);

			modelBuilder.Entity<tblBillFirmaTransakcijskiRacunEmail>().HasMany(x=>x.tblBillFirmaTransakcijskiRacunList).WithOne(x=>x.tblBillFirmaTransakcijskiRacunEmail).HasForeignKey(x=>x.BillFirmaTransakcijskiRacunEmailID).IsRequired(false);

			modelBuilder.Entity<tblBillMjera>().HasMany(x=>x.tblBillDocumentStavkaList).WithOne(x=>x.tblBillMjera).HasForeignKey(x=>x.BillMjeraID).IsRequired(true);
			modelBuilder.Entity<tblBillMjera>().HasOne(x=>x.OsnovnaBillMjera).WithMany(x=>x.BillMjeraList).HasForeignKey(x=>x.OsnovnaBillMjeraID).IsRequired(true);
			modelBuilder.Entity<tblBillMjera>().HasMany(x=>x.BillMjeraList).WithOne(x=>x.OsnovnaBillMjera).HasForeignKey(x=>x.OsnovnaBillMjeraID).IsRequired(true);
			modelBuilder.Entity<tblBillMjera>().HasMany(x=>x.tblBillProductList).WithOne(x=>x.tblBillMjera).HasForeignKey(x=>x.BillMjeraID).IsRequired(true);

			modelBuilder.Entity<tblBillNaplatniUredjaj>().HasMany(x=>x.tblBillDocumentList).WithOne(x=>x.tblBillNaplatniUredjaj).HasForeignKey(x=>x.BillNaplatniUredjajID).IsRequired(true);
			modelBuilder.Entity<tblBillNaplatniUredjaj>().HasOne(x=>x.tblBillDocumentTip).WithMany(x=>x.tblBillNaplatniUredjajList).HasForeignKey(x=>x.BillDocumentTipID).IsRequired(true);
			modelBuilder.Entity<tblBillNaplatniUredjaj>().HasOne(x=>x.CreatesRacunBillNaplatniUredjaj).WithMany(x=>x.BillNaplatniUredjajList).HasForeignKey(x=>x.CreatesRacunBillNaplatniUredjajID).IsRequired(false);
			modelBuilder.Entity<tblBillNaplatniUredjaj>().HasMany(x=>x.BillNaplatniUredjajList).WithOne(x=>x.CreatesRacunBillNaplatniUredjaj).HasForeignKey(x=>x.CreatesRacunBillNaplatniUredjajID).IsRequired(false);
			modelBuilder.Entity<tblBillNaplatniUredjaj>().HasOne(x=>x.tblBillPaymentMethod).WithMany(x=>x.tblBillNaplatniUredjajList).HasForeignKey(x=>x.BillPaymentMethodID).IsRequired(true);
			modelBuilder.Entity<tblBillNaplatniUredjaj>().HasOne(x=>x.tblBillPoslovniProstor).WithMany(x=>x.tblBillNaplatniUredjajList).HasForeignKey(x=>x.BillPoslovniProstorID).IsRequired(true);

			modelBuilder.Entity<tblBillOperator>().HasMany(x=>x.tblAppMemberList).WithOne(x=>x.tblBillOperator).HasForeignKey(x=>x.BillOperatorID).IsRequired(false);

			modelBuilder.Entity<tblBillPaymentMethod>().HasMany(x=>x.tblBillNaplatniUredjajList).WithOne(x=>x.tblBillPaymentMethod).HasForeignKey(x=>x.BillPaymentMethodID).IsRequired(true);

			modelBuilder.Entity<tblBillPoreznaGrupa>().HasMany(x=>x.tblBillDocumentStavkaList).WithOne(x=>x.tblBillPoreznaGrupa).HasForeignKey(x=>x.BillPoreznaGrupaID).IsRequired(true);
			modelBuilder.Entity<tblBillPoreznaGrupa>().HasOne(x=>x.tblBillPoslovniProstor).WithMany(x=>x.tblBillPoreznaGrupaList).HasForeignKey(x=>x.BillPoslovniProstorID).IsRequired(true);
			modelBuilder.Entity<tblBillPoreznaGrupa>().HasMany(x=>x.tblBillProductList).WithOne(x=>x.tblBillPoreznaGrupa).HasForeignKey(x=>x.BillPoreznaGrupaID).IsRequired(true);

			modelBuilder.Entity<tblBillPoslovniProstor>().HasMany(x=>x.tblBillCategoryList).WithOne(x=>x.tblBillPoslovniProstor).HasForeignKey(x=>x.BillPoslovniProstorID).IsRequired(true);
			modelBuilder.Entity<tblBillPoslovniProstor>().HasMany(x=>x.tblBillNaplatniUredjajList).WithOne(x=>x.tblBillPoslovniProstor).HasForeignKey(x=>x.BillPoslovniProstorID).IsRequired(true);
			modelBuilder.Entity<tblBillPoslovniProstor>().HasMany(x=>x.tblBillPoreznaGrupaList).WithOne(x=>x.tblBillPoslovniProstor).HasForeignKey(x=>x.BillPoslovniProstorID).IsRequired(true);
			modelBuilder.Entity<tblBillPoslovniProstor>().HasOne(x=>x.tblBillFirma).WithMany(x=>x.tblBillPoslovniProstorList).HasForeignKey(x=>x.BillFirmaID).IsRequired(true);
			modelBuilder.Entity<tblBillPoslovniProstor>().HasMany(x=>x.tblBillProductList).WithOne(x=>x.tblBillPoslovniProstor).HasForeignKey(x=>x.BillPoslovniProstorID).IsRequired(true);

			modelBuilder.Entity<tblBillPrintLog>().HasOne(x=>x.tblAppMember).WithMany(x=>x.tblBillPrintLogList).HasForeignKey(x=>x.AppMemberID).IsRequired(true);

			modelBuilder.Entity<tblBillProduct>().HasMany(x=>x.tblBillDocumentStavkaList).WithOne(x=>x.tblBillProduct).HasForeignKey(x=>x.BillProductID).IsRequired(true);
			modelBuilder.Entity<tblBillProduct>().HasOne(x=>x.tblBillMjera).WithMany(x=>x.tblBillProductList).HasForeignKey(x=>x.BillMjeraID).IsRequired(true);
			modelBuilder.Entity<tblBillProduct>().HasOne(x=>x.tblBillPoreznaGrupa).WithMany(x=>x.tblBillProductList).HasForeignKey(x=>x.BillPoreznaGrupaID).IsRequired(true);
			modelBuilder.Entity<tblBillProduct>().HasOne(x=>x.tblBillPoslovniProstor).WithMany(x=>x.tblBillProductList).HasForeignKey(x=>x.BillPoslovniProstorID).IsRequired(true);
			modelBuilder.Entity<tblBillProduct>().HasOne(x=>x.tblBillUslugaTip).WithMany(x=>x.tblBillProductList).HasForeignKey(x=>x.BillUslugaTipID).IsRequired(false);
			modelBuilder.Entity<tblBillProduct>().HasMany(x=>x.tblBillProductCategoryList).WithOne(x=>x.tblBillProduct).HasForeignKey(x=>x.BillProductID).IsRequired(true);
			modelBuilder.Entity<tblBillProduct>().HasMany(x=>x.tblBillProductNormativList).WithOne(x=>x.tblBillProduct).HasForeignKey(x=>x.ArtiklBillProductID).IsRequired(true);
			modelBuilder.Entity<tblBillProduct>().HasMany(x=>x.BillProductList).WithOne(x=>x.NormativBillProduct).HasForeignKey(x=>x.NormativBillProductID).IsRequired(true);

			modelBuilder.Entity<tblBillProductCategory>().HasOne(x=>x.tblBillCategory).WithMany(x=>x.tblBillProductCategoryList).HasForeignKey(x=>x.BillCategoryID).IsRequired(true);
			modelBuilder.Entity<tblBillProductCategory>().HasOne(x=>x.tblBillProduct).WithMany(x=>x.tblBillProductCategoryList).HasForeignKey(x=>x.BillProductID).IsRequired(true);

			modelBuilder.Entity<tblBillProductNormativ>().HasOne(x=>x.tblBillProduct).WithMany(x=>x.tblBillProductNormativList).HasForeignKey(x=>x.ArtiklBillProductID).IsRequired(true);
			modelBuilder.Entity<tblBillProductNormativ>().HasOne(x=>x.NormativBillProduct).WithMany(x=>x.BillProductList).HasForeignKey(x=>x.NormativBillProductID).IsRequired(true);

			modelBuilder.Entity<tblBillUslugaTip>().HasMany(x=>x.tblBillProductList).WithOne(x=>x.tblBillUslugaTip).HasForeignKey(x=>x.BillUslugaTipID).IsRequired(false);
			modelBuilder.Entity<tblBillUslugaTip>().HasMany(x=>x.tblDirClientGratisList).WithOne(x=>x.tblBillUslugaTip).HasForeignKey(x=>x.BillUslugaTipID).IsRequired(false);

			modelBuilder.Entity<tblBookkeepingFiduciaExport>().HasOne(x=>x.tblBillFirma).WithMany(x=>x.tblBookkeepingFiduciaExportList).HasForeignKey(x=>x.BillFirmaID).IsRequired(true);

			modelBuilder.Entity<tblBookkeepingSynesisExport>().HasOne(x=>x.tblBillFirma).WithMany(x=>x.tblBookkeepingSynesisExportList).HasForeignKey(x=>x.BillFirmaID).IsRequired(true);

			modelBuilder.Entity<tblDirClient>().HasMany(x=>x.tblBillClientList).WithOne(x=>x.tblDirClient).HasForeignKey(x=>x.DirClientID).IsRequired(false);
			modelBuilder.Entity<tblDirClient>().HasOne(x=>x.tblDirClientSource).WithMany(x=>x.tblDirClientList).HasForeignKey(x=>x.DirClientSourceID).IsRequired(false);
			modelBuilder.Entity<tblDirClient>().HasOne(x=>x.tblDirClientFullText).WithOne(x=>x.tblDirClient).HasForeignKey<tblDirClientFullText>(x=>x.DirClientID).IsRequired(true).OnDelete(DeleteBehavior.Cascade);
			modelBuilder.Entity<tblDirClient>().HasOne(x=>x.tblDirClientGratis).WithOne(x=>x.tblDirClient).HasForeignKey<tblDirClientGratis>(x=>x.DirClientID).IsRequired(true);
			modelBuilder.Entity<tblDirClient>().HasMany(x=>x.tblDirClientPictureList).WithOne(x=>x.tblDirClient).HasForeignKey(x=>x.DirClientID).IsRequired(true);
			modelBuilder.Entity<tblDirClient>().HasOne(x=>x.tblDirClientPrikazStatus).WithOne(x=>x.tblDirClient).HasForeignKey<tblDirClientPrikazStatus>(x=>x.DirClientID).IsRequired(true).OnDelete(DeleteBehavior.Cascade);
			modelBuilder.Entity<tblDirClient>().HasMany(x=>x.tblSocialMemberList).WithOne(x=>x.tblDirClient).HasForeignKey(x=>x.DirClientID).IsRequired(false).OnDelete(DeleteBehavior.Cascade);

			modelBuilder.Entity<tblDirClientBlacklist>().HasOne(x=>x.tblAppMember).WithMany(x=>x.tblDirClientBlacklistList).HasForeignKey(x=>x.AppMemberID).IsRequired(true);
			modelBuilder.Entity<tblDirClientBlacklist>().HasOne(x=>x.tblBillFirma).WithMany(x=>x.tblDirClientBlacklistList).HasForeignKey(x=>x.BillFirmaID).IsRequired(true);

			modelBuilder.Entity<tblDirClientFullText>().HasOne(x=>x.tblDirClient).WithOne(x=>x.tblDirClientFullText).HasForeignKey<tblDirClient>(x=>x.DirClientID).IsRequired(true).OnDelete(DeleteBehavior.Cascade);

			modelBuilder.Entity<tblDirClientGratis>().HasOne(x=>x.tblBillUslugaTip).WithMany(x=>x.tblDirClientGratisList).HasForeignKey(x=>x.BillUslugaTipID).IsRequired(false);
			modelBuilder.Entity<tblDirClientGratis>().HasOne(x=>x.tblDirClient).WithOne(x=>x.tblDirClientGratis).HasForeignKey<tblDirClient>(x=>x.DirClientID).IsRequired(true);

			modelBuilder.Entity<tblDirClientPicture>().HasOne(x=>x.tblDirClient).WithMany(x=>x.tblDirClientPictureList).HasForeignKey(x=>x.DirClientID).IsRequired(true);

			modelBuilder.Entity<tblDirClientPrikazStatus>().HasOne(x=>x.tblDirClient).WithOne(x=>x.tblDirClientPrikazStatus).HasForeignKey<tblDirClient>(x=>x.DirClientID).IsRequired(true).OnDelete(DeleteBehavior.Cascade);

			modelBuilder.Entity<tblDirClientSource>().HasMany(x=>x.tblDirClientList).WithOne(x=>x.tblDirClientSource).HasForeignKey(x=>x.DirClientSourceID).IsRequired(false);

			modelBuilder.Entity<tblDirNkd2007>().HasOne(x=>x.ParentNkdRow).WithMany(x=>x.NkdRowList).HasForeignKey(x=>x.ParentNkdRowID).IsRequired(false);
			modelBuilder.Entity<tblDirNkd2007>().HasMany(x=>x.NkdRowList).WithOne(x=>x.ParentNkdRow).HasForeignKey(x=>x.ParentNkdRowID).IsRequired(false);

			modelBuilder.Entity<tblFiskalRacunZahtjevLog>().HasOne(x=>x.tblAppMember).WithMany(x=>x.tblFiskalRacunZahtjevLogList).HasForeignKey(x=>x.AppMemberID).IsRequired(true);
			modelBuilder.Entity<tblFiskalRacunZahtjevLog>().HasOne(x=>x.tblBillDocument).WithMany(x=>x.tblFiskalRacunZahtjevLogList).HasForeignKey(x=>x.BillDocumentID).IsRequired(true);

			modelBuilder.Entity<tblPorezPdv>().HasMany(x=>x.tblPorezPdvPostotakList).WithOne(x=>x.tblPorezPdv).HasForeignKey(x=>x.BillPorezPdvID).IsRequired(true);

			modelBuilder.Entity<tblPorezPdvPostotak>().HasOne(x=>x.tblPorezPdv).WithMany(x=>x.tblPorezPdvPostotakList).HasForeignKey(x=>x.BillPorezPdvID).IsRequired(true);

			modelBuilder.Entity<tblPorezPotrosnja>().HasMany(x=>x.tblPorezPotrosnjaPostotakList).WithOne(x=>x.tblPorezPotrosnja).HasForeignKey(x=>x.BillPorezPotrosnjaID).IsRequired(true);

			modelBuilder.Entity<tblPorezPotrosnjaPostotak>().HasOne(x=>x.tblPorezPotrosnja).WithMany(x=>x.tblPorezPotrosnjaPostotakList).HasForeignKey(x=>x.BillPorezPotrosnjaID).IsRequired(true);

			modelBuilder.Entity<tblSocialMember>().HasOne(x=>x.tblBillClient).WithMany(x=>x.tblSocialMemberList).HasForeignKey(x=>x.BillClientID).IsRequired(false);
			modelBuilder.Entity<tblSocialMember>().HasOne(x=>x.tblDirClient).WithMany(x=>x.tblSocialMemberList).HasForeignKey(x=>x.DirClientID).IsRequired(false).OnDelete(DeleteBehavior.Cascade);
			modelBuilder.Entity<tblSocialMember>().HasOne(x=>x.tblSocialMemberStatus).WithMany(x=>x.tblSocialMemberList).HasForeignKey(x=>x.SocialMemberStatusID).IsRequired(false);
			modelBuilder.Entity<tblSocialMember>().HasOne(x=>x.tblSocialProvider).WithMany(x=>x.tblSocialMemberList).HasForeignKey(x=>x.SocialProviderID).IsRequired(true);

			modelBuilder.Entity<tblSocialMemberStatus>().HasMany(x=>x.tblSocialMemberList).WithOne(x=>x.tblSocialMemberStatus).HasForeignKey(x=>x.SocialMemberStatusID).IsRequired(false);

			modelBuilder.Entity<tblSocialProvider>().HasMany(x=>x.tblSocialMemberList).WithOne(x=>x.tblSocialProvider).HasForeignKey(x=>x.SocialProviderID).IsRequired(true);

			modelBuilder.Entity<tblWeatherCity>().HasMany(x=>x.tblWeatherDayInfoList).WithOne(x=>x.tblWeatherCity).HasForeignKey(x=>x.WeatherCityID).IsRequired(true);
			modelBuilder.Entity<tblWeatherCity>().HasMany(x=>x.tblWeatherInfoList).WithOne(x=>x.tblWeatherCity).HasForeignKey(x=>x.WeatherCityID).IsRequired(true);

			modelBuilder.Entity<tblWeatherDayInfo>().HasOne(x=>x.tblWeatherCity).WithMany(x=>x.tblWeatherDayInfoList).HasForeignKey(x=>x.WeatherCityID).IsRequired(true);

			modelBuilder.Entity<tblWeatherInfo>().HasOne(x=>x.tblWeatherCity).WithMany(x=>x.tblWeatherInfoList).HasForeignKey(x=>x.WeatherCityID).IsRequired(true);
			modelBuilder.Entity<tblWeatherInfo>().HasOne(x=>x.tblWeatherKind).WithMany(x=>x.tblWeatherInfoList).HasForeignKey(x=>x.WeatherKindID).IsRequired(true);

			modelBuilder.Entity<tblWeatherKind>().HasMany(x=>x.tblWeatherInfoList).WithOne(x=>x.tblWeatherKind).HasForeignKey(x=>x.WeatherKindID).IsRequired(true);

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

	#region dbo.tblAppCache
	public partial class tblAppCache : EFCoreEntityBase<tblAppCache>
	{
		public tblAppCache()
		{
			OnCreated();
		}

		public tblAppCache(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "VarChar(900) NOT NULL", IsPrimaryKey = true
		/// </summary>
		public string CacheKey { get; set; }

		/// <summary>
		/// DbType = "DateTime NOT NULL"
		/// </summary>
		public DateTime InsertionDate { get; set; }

		/// <summary>
		/// DbType = "DateTime"
		/// </summary>
		public DateTime? ExpirationDate { get; set; }

		/// <summary>
		/// DbType = "VarBinary(MAX)"
		/// </summary>
		public byte[] CachedValue { get; set; }

		#endregion Columns

		#region Associations
		#endregion Associations

		partial void OnCreated();
	}
	#endregion dbo.tblAppCache

	#region dbo.tblAppConfig
	public partial class tblAppConfig : EFCoreEntityBase<tblAppConfig>
	{
		public tblAppConfig()
		{
			OnCreated();
		}

		public tblAppConfig(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert
		/// </summary>
		public int AppConfigID { get; set; }

		/// <summary>
		/// DbType = "VarChar(50) NOT NULL"
		/// </summary>
		public string GroupName { get; set; }

		/// <summary>
		/// DbType = "Bit NOT NULL"
		/// </summary>
		public bool IsActive { get; set; }

		/// <summary>
		/// DbType = "Bit NOT NULL", DefaultValue = false
		/// </summary>
		public bool IsDefault { get; set; } = false;

		/// <summary>
		/// DbType = "NVarChar(500)"
		/// </summary>
		public string Note { get; set; }

		/// <summary>
		/// DbType = "VarChar(100)"
		/// </summary>
		public string SmtpHost { get; set; }

		/// <summary>
		/// DbType = "Int"
		/// </summary>
		public int? SmtpPort { get; set; }

		/// <summary>
		/// DbType = "Bit"
		/// </summary>
		public bool? SmtpSSL { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50)"
		/// </summary>
		public string SmtpUsername { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50)"
		/// </summary>
		public string SmtpPassword { get; set; }

		/// <summary>
		/// DbType = "VarChar(100)"
		/// </summary>
		public string DefaultEmailFrom { get; set; }

		/// <summary>
		/// DbType = "VarChar(100)"
		/// </summary>
		public string DefaultEmailTo { get; set; }

		/// <summary>
		/// DbType = "VarChar(100)"
		/// </summary>
		public string ContactFormEmailTo { get; set; }

		#endregion Columns

		#region Associations
		#endregion Associations

		partial void OnCreated();
	}
	#endregion dbo.tblAppConfig

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
		/// DbType = "BigInt NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert
		/// </summary>
		public long AppMemberID { get; set; }

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
		/// DbType = "NVarChar(200)"
		/// </summary>
		public string Data2 { get; set; }

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
		/// DbType = "NVarChar(1000)"
		/// </summary>
		public string ReferentNote { get; set; }

		/// <summary>
		/// DbType = "BigInt"
		/// </summary>
		public long? BillFirmaID { get; set; }

		/// <summary>
		/// DbType = "BigInt"
		/// </summary>
		public long? BillOperatorID { get; set; }

		#endregion Columns

		#region Associations

		/// <summary>
		/// Association <br/>
		/// [FK][Many]tblAppMember.AppMemberStatusID --- [PK][One]tblAppMemberStatus.AppMemberStatusID <br/>
		/// </summary>
		public virtual tblAppMemberStatus tblAppMemberStatus { get; set; }

		/// <summary>
		/// Association <br/>
		/// [PK][One]tblAppMember.AppMemberID --- [FK][Many]tblAppMemberPicture.AppMemberID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<tblAppMemberPicture> tblAppMemberPictureList { get; set; } = new List<tblAppMemberPicture>();

		/// <summary>
		/// Association <br/>
		/// [FK][Many]tblAppMember.BillFirmaID --- [PK][One]tblBillFirma.BillFirmaID <br/>
		/// </summary>
		public virtual tblBillFirma tblBillFirma { get; set; }

		/// <summary>
		/// Association <br/>
		/// [FK][Many]tblAppMember.BillOperatorID --- [PK][One]tblBillOperator.BillOperatorID <br/>
		/// </summary>
		public virtual tblBillOperator tblBillOperator { get; set; }

		/// <summary>
		/// Association <br/>
		/// [PK][One]tblAppMember.AppMemberID --- [FK][One]tblAppMemberPermission.AppMemberID <br/>
		/// DeleteRule = Cascade <br/>
		/// </summary>
		public virtual tblAppMemberPermission tblAppMemberPermission { get; set; }

		/// <summary>
		/// Association <br/>
		/// [PK][One]tblAppMember.AppMemberID --- [FK][Many]tblBankaPromet.AppMemberID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<tblBankaPromet> tblBankaPrometList { get; set; } = new List<tblBankaPromet>();

		/// <summary>
		/// Association <br/>
		/// [PK][One]tblAppMember.AppMemberID --- [FK][Many]tblBillDocument.AppMemberID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<tblBillDocument> tblBillDocumentList { get; set; } = new List<tblBillDocument>();

		/// <summary>
		/// Association <br/>
		/// [PK][One]tblAppMember.AppMemberID --- [FK][Many]tblBillPrintLog.AppMemberID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<tblBillPrintLog> tblBillPrintLogList { get; set; } = new List<tblBillPrintLog>();

		/// <summary>
		/// Association <br/>
		/// [PK][One]tblAppMember.AppMemberID --- [FK][Many]tblDirClientBlacklist.AppMemberID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<tblDirClientBlacklist> tblDirClientBlacklistList { get; set; } = new List<tblDirClientBlacklist>();

		/// <summary>
		/// Association <br/>
		/// [PK][One]tblAppMember.AppMemberID --- [FK][Many]tblFiskalRacunZahtjevLog.AppMemberID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<tblFiskalRacunZahtjevLog> tblFiskalRacunZahtjevLogList { get; set; } = new List<tblFiskalRacunZahtjevLog>();
		#endregion Associations

		partial void OnCreated();
	}
	#endregion dbo.tblAppMember

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
		/// DbType = "BigInt NOT NULL", IsPrimaryKey = true
		/// </summary>
		public long AppMemberID { get; set; }

		/// <summary>
		/// DbType = "Bit"
		/// </summary>
		public bool? IsActive { get; set; }

		/// <summary>
		/// DbType = "Bit"
		/// </summary>
		public bool? WritePermission { get; set; }

		/// <summary>
		/// DbType = "Bit"
		/// </summary>
		public bool? ArizonaReferenti { get; set; }

		/// <summary>
		/// DbType = "Bit"
		/// </summary>
		public bool? PosCompanies { get; set; }

		/// <summary>
		/// DbType = "Bit"
		/// </summary>
		public bool? AdminTools { get; set; }

		/// <summary>
		/// DbType = "Bit"
		/// </summary>
		public bool? PosMain { get; set; }

		/// <summary>
		/// DbType = "Bit"
		/// </summary>
		public bool? PosOperators { get; set; }

		/// <summary>
		/// DbType = "Bit"
		/// </summary>
		public bool? PosCompany { get; set; }

		/// <summary>
		/// DbType = "Bit"
		/// </summary>
		public bool? PosPoslovniProstori { get; set; }

		/// <summary>
		/// DbType = "Bit"
		/// </summary>
		public bool? PosNaplatniUredjaji { get; set; }

		/// <summary>
		/// DbType = "Bit"
		/// </summary>
		public bool? PosDnevniObracun { get; set; }

		/// <summary>
		/// DbType = "Bit"
		/// </summary>
		public bool? PosEvidencijaGotovine { get; set; }

		/// <summary>
		/// DbType = "Bit"
		/// </summary>
		public bool? PosPorezneGrupe { get; set; }

		/// <summary>
		/// DbType = "Bit"
		/// </summary>
		public bool? PosProducts { get; set; }

		/// <summary>
		/// DbType = "Bit"
		/// </summary>
		public bool? Documents { get; set; }

		/// <summary>
		/// DbType = "Bit"
		/// </summary>
		public bool? Payments { get; set; }

		/// <summary>
		/// DbType = "Bit"
		/// </summary>
		public bool? JobAdverts { get; set; }

		/// <summary>
		/// DbType = "Bit"
		/// </summary>
		public bool? JobCalendar { get; set; }

		/// <summary>
		/// DbType = "Bit"
		/// </summary>
		public bool? JobApplicants { get; set; }

		/// <summary>
		/// DbType = "Bit"
		/// </summary>
		public bool? JobTemplates { get; set; }

		/// <summary>
		/// DbType = "Bit"
		/// </summary>
		public bool? BillsExport { get; set; }

		/// <summary>
		/// DbType = "Bit"
		/// </summary>
		public bool? SynesisExport { get; set; }

		/// <summary>
		/// DbType = "Bit"
		/// </summary>
		public bool? FiduciaExport { get; set; }

		/// <summary>
		/// DbType = "Bit"
		/// </summary>
		public bool? Printing { get; set; }

		/// <summary>
		/// DbType = "Bit"
		/// </summary>
		public bool? PrintingHistory { get; set; }

		/// <summary>
		/// DbType = "Bit"
		/// </summary>
		public bool? Balances { get; set; }

		/// <summary>
		/// DbType = "Bit"
		/// </summary>
		public bool? Transactions { get; set; }

		/// <summary>
		/// DbType = "Bit"
		/// </summary>
		public bool? FirmaCalls { get; set; }

		/// <summary>
		/// DbType = "Bit"
		/// </summary>
		public bool? FirmaTools { get; set; }

		/// <summary>
		/// DbType = "Bit"
		/// </summary>
		public bool? GeolocationTools { get; set; }

		/// <summary>
		/// DbType = "Bit"
		/// </summary>
		public bool? CrmOglasnik { get; set; }

		/// <summary>
		/// DbType = "Bit"
		/// </summary>
		public bool? CrmRadnoVrijeme { get; set; }

		/// <summary>
		/// DbType = "Bit"
		/// </summary>
		public bool? KnjigovodstvoObradilo { get; set; }

		#endregion Columns

		#region Associations

		/// <summary>
		/// Association <br/>
		/// [FK][One]tblAppMemberPermission.AppMemberID --- [PK][One]tblAppMember.AppMemberID <br/>
		/// DeleteOnNull = true <br/>
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
		/// DbType = "BigInt NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert
		/// </summary>
		public long AppMemberPictureID { get; set; }

		/// <summary>
		/// DbType = "BigInt"
		/// </summary>
		public long? AppMemberID { get; set; }

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
		/// DbType = "Bit NOT NULL"
		/// </summary>
		public bool IsSubscribed { get; set; }

		#endregion Columns

		#region Associations
		#endregion Associations

		partial void OnCreated();
	}
	#endregion dbo.tblAppNewsletter

	#region dbo.tblBanka
	public partial class tblBanka : EFCoreEntityBase<tblBanka>
	{
		public tblBanka()
		{
			OnCreated();
		}

		public tblBanka(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "Int NOT NULL", IsPrimaryKey = true
		/// </summary>
		public int BankaID { get; set; }

		/// <summary>
		/// DbType = "NVarChar(500) NOT NULL"
		/// </summary>
		public string Naziv { get; set; }

		/// <summary>
		/// DbType = "VarChar(50)"
		/// </summary>
		public string IbanPrefix { get; set; }

		/// <summary>
		/// DbType = "VarChar(50)"
		/// </summary>
		public string Swift { get; set; }

		#endregion Columns

		#region Associations

		/// <summary>
		/// Association <br/>
		/// [PK][One]tblBanka.BankaID --- [FK][Many]tblBillFirmaTransakcijskiRacun.BankaID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<tblBillFirmaTransakcijskiRacun> tblBillFirmaTransakcijskiRacunList { get; set; } = new List<tblBillFirmaTransakcijskiRacun>();
		#endregion Associations

		partial void OnCreated();
	}
	#endregion dbo.tblBanka

	#region dbo.tblBankaPromet
	public partial class tblBankaPromet : EFCoreEntityBase<tblBankaPromet>
	{
		public tblBankaPromet()
		{
			OnCreated();
		}

		public tblBankaPromet(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "BigInt NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert
		/// </summary>
		public long BankaPrometID { get; set; }

		/// <summary>
		/// DbType = "BigInt NOT NULL"
		/// </summary>
		public long BillFirmaTransakcijskiRacunID { get; set; }

		/// <summary>
		/// DbType = "BigInt NOT NULL"
		/// </summary>
		public long AppMemberID { get; set; }

		/// <summary>
		/// DbType = "DateTime NOT NULL"
		/// </summary>
		public DateTime InsertionDate { get; set; }

		/// <summary>
		/// DbType = "DateTime NOT NULL"
		/// </summary>
		public DateTime DatumTransakcije { get; set; }

		/// <summary>
		/// DbType = "NVarChar(500)"
		/// </summary>
		public string PlatiteljPrimatelj { get; set; }

		/// <summary>
		/// DbType = "VarChar(100)"
		/// </summary>
		public string IbanPlatiteljaPrimatelja { get; set; }

		/// <summary>
		/// DbType = "VarChar(50)"
		/// </summary>
		public string PlatiteljModel { get; set; }

		/// <summary>
		/// DbType = "VarChar(100)"
		/// </summary>
		public string PlatiteljPozivNaBroj { get; set; }

		/// <summary>
		/// DbType = "VarChar(50)"
		/// </summary>
		public string PrimateljModel { get; set; }

		/// <summary>
		/// DbType = "VarChar(100)"
		/// </summary>
		public string PrimateljPozivNaBroj { get; set; }

		/// <summary>
		/// DbType = "NVarChar(500)"
		/// </summary>
		public string Mjesto { get; set; }

		/// <summary>
		/// DbType = "NVarChar(500)"
		/// </summary>
		public string OpisPlacanja { get; set; }

		/// <summary>
		/// DbType = "Int"
		/// </summary>
		public int? RedniBroj { get; set; }

		/// <summary>
		/// DbType = "NVarChar(100)"
		/// </summary>
		public string SifraNamjene { get; set; }

		/// <summary>
		/// DbType = "Money"
		/// </summary>
		public decimal? Isplata { get; set; }

		/// <summary>
		/// DbType = "Money"
		/// </summary>
		public decimal? Uplata { get; set; }

		/// <summary>
		/// DbType = "Money"
		/// </summary>
		public decimal? Stanje { get; set; }

		/// <summary>
		/// DbType = "VarChar(100)"
		/// </summary>
		public string ReferencaPlacanja { get; set; }

		/// <summary>
		/// DbType = "NVarChar(500)"
		/// </summary>
		public string Napomena { get; set; }

		/// <summary>
		/// DbType = "Money"
		/// </summary>
		public decimal? PoreznaOsnovica { get; set; }

		/// <summary>
		/// DbType = "Money"
		/// </summary>
		public decimal? Pdv { get; set; }

		/// <summary>
		/// DbType = "Int"
		/// </summary>
		public int? BankaPrometVrstaID { get; set; }

		/// <summary>
		/// DbType = "DateTime"
		/// </summary>
		public DateTime? DatumRacuna { get; set; }

		/// <summary>
		/// DbType = "DateTime"
		/// </summary>
		public DateTime? KnjigovodstvoObradilo { get; set; }

		#endregion Columns

		#region Associations

		/// <summary>
		/// Association <br/>
		/// [FK][Many]tblBankaPromet.AppMemberID --- [PK][One]tblAppMember.AppMemberID <br/>
		/// </summary>
		public virtual tblAppMember tblAppMember { get; set; }

		/// <summary>
		/// Association <br/>
		/// [FK][Many]tblBankaPromet.BankaPrometVrstaID --- [PK][One]tblBankaPrometVrsta.BankaPrometVrstaID <br/>
		/// </summary>
		public virtual tblBankaPrometVrsta tblBankaPrometVrsta { get; set; }

		/// <summary>
		/// Association <br/>
		/// [FK][Many]tblBankaPromet.BillFirmaTransakcijskiRacunID --- [PK][One]tblBillFirmaTransakcijskiRacun.BillFirmaTransakcijskiRacunID <br/>
		/// </summary>
		public virtual tblBillFirmaTransakcijskiRacun tblBillFirmaTransakcijskiRacun { get; set; }

		/// <summary>
		/// Association <br/>
		/// [PK][One]tblBankaPromet.BankaPrometID --- [FK][Many]tblBankaPrometDocument.BankaPrometID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<tblBankaPrometDocument> tblBankaPrometDocumentList { get; set; } = new List<tblBankaPrometDocument>();
		#endregion Associations

		partial void OnCreated();
	}
	#endregion dbo.tblBankaPromet

	#region dbo.tblBankaPrometDocument
	public partial class tblBankaPrometDocument : EFCoreEntityBase<tblBankaPrometDocument>
	{
		public tblBankaPrometDocument()
		{
			OnCreated();
		}

		public tblBankaPrometDocument(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "BigInt NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert
		/// </summary>
		public long BankaPrometDocumentID { get; set; }

		/// <summary>
		/// DbType = "BigInt NOT NULL"
		/// </summary>
		public long BankaPrometID { get; set; }

		/// <summary>
		/// DbType = "NVarChar(100)"
		/// </summary>
		public string FileName { get; set; }

		/// <summary>
		/// DbType = "VarBinary(MAX)"
		/// </summary>
		public byte[] FileContent { get; set; }

		#endregion Columns

		#region Associations

		/// <summary>
		/// Association <br/>
		/// [FK][Many]tblBankaPrometDocument.BankaPrometID --- [PK][One]tblBankaPromet.BankaPrometID <br/>
		/// </summary>
		public virtual tblBankaPromet tblBankaPromet { get; set; }
		#endregion Associations

		partial void OnCreated();
	}
	#endregion dbo.tblBankaPrometDocument

	#region dbo.tblBankaPrometVrsta
	public partial class tblBankaPrometVrsta : EFCoreEntityBase<tblBankaPrometVrsta>
	{
		public tblBankaPrometVrsta()
		{
			OnCreated();
		}

		public tblBankaPrometVrsta(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "Int NOT NULL", IsPrimaryKey = true
		/// </summary>
		public int BankaPrometVrstaID { get; set; }

		/// <summary>
		/// DbType = "NVarChar(150) NOT NULL"
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// DbType = "Bit NOT NULL"
		/// </summary>
		public bool IsPrihod { get; set; }

		/// <summary>
		/// DbType = "Bit NOT NULL"
		/// </summary>
		public bool IsRashod { get; set; }

		#endregion Columns

		#region Associations

		/// <summary>
		/// Association <br/>
		/// [PK][One]tblBankaPrometVrsta.BankaPrometVrstaID --- [FK][Many]tblBankaPromet.BankaPrometVrstaID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<tblBankaPromet> tblBankaPrometList { get; set; } = new List<tblBankaPromet>();
		#endregion Associations

		partial void OnCreated();
	}
	#endregion dbo.tblBankaPrometVrsta

	#region dbo.tblBankaValuta
	public partial class tblBankaValuta : EFCoreEntityBase<tblBankaValuta>
	{
		public tblBankaValuta()
		{
			OnCreated();
		}

		public tblBankaValuta(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert
		/// </summary>
		public int BankaValutaID { get; set; }

		/// <summary>
		/// DbType = "NVarChar(100)"
		/// </summary>
		public string DrzavaNaziv { get; set; }

		/// <summary>
		/// DbType = "VarChar(50)"
		/// </summary>
		public string DrzavaISO { get; set; }

		/// <summary>
		/// DbType = "VarChar(50)"
		/// </summary>
		public string SifraValute { get; set; }

		/// <summary>
		/// DbType = "VarChar(50)"
		/// </summary>
		public string Valuta { get; set; }

		#endregion Columns

		#region Associations
		#endregion Associations

		partial void OnCreated();
	}
	#endregion dbo.tblBankaValuta

	#region dbo.tblBankaValutaTecaj
	public partial class tblBankaValutaTecaj : EFCoreEntityBase<tblBankaValutaTecaj>
	{
		public tblBankaValutaTecaj()
		{
			OnCreated();
		}

		public tblBankaValutaTecaj(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "BigInt NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert
		/// </summary>
		public long BankaValutaTecajID { get; set; }

		/// <summary>
		/// DbType = "VarChar(10) NOT NULL"
		/// </summary>
		public string OsnovnaValuta { get; set; }

		/// <summary>
		/// DbType = "VarChar(10) NOT NULL"
		/// </summary>
		public string Valuta { get; set; }

		/// <summary>
		/// DbType = "SmallDateTime NOT NULL"
		/// </summary>
		public DateTime DatumPrimjene { get; set; }

		/// <summary>
		/// DbType = "Decimal(18,10)"
		/// </summary>
		public decimal? JedinicniIznos { get; set; }

		/// <summary>
		/// DbType = "Decimal(18,10)"
		/// </summary>
		public decimal? KupovniTecaj { get; set; }

		/// <summary>
		/// DbType = "Decimal(18,10)"
		/// </summary>
		public decimal? SrednjiTecaj { get; set; }

		/// <summary>
		/// DbType = "Decimal(18,10)"
		/// </summary>
		public decimal? ProdajniTecaj { get; set; }

		#endregion Columns

		#region Associations
		#endregion Associations

		partial void OnCreated();
	}
	#endregion dbo.tblBankaValutaTecaj

	#region dbo.tblBillCategory
	public partial class tblBillCategory : EFCoreEntityBase<tblBillCategory>
	{
		public tblBillCategory()
		{
			OnCreated();
		}

		public tblBillCategory(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "BigInt NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert
		/// </summary>
		public long BillCategoryID { get; set; }

		/// <summary>
		/// DbType = "BigInt"
		/// </summary>
		public long? ParentBillCategoryID { get; set; }

		/// <summary>
		/// DbType = "BigInt NOT NULL"
		/// </summary>
		public long BillPoslovniProstorID { get; set; }

		/// <summary>
		/// DbType = "NVarChar(250) NOT NULL"
		/// </summary>
		public string Naziv { get; set; }

		/// <summary>
		/// DbType = "Int NOT NULL"
		/// </summary>
		public int Ordinal { get; set; }

		/// <summary>
		/// DbType = "Bit NOT NULL"
		/// </summary>
		public bool IsPosVisible { get; set; }

		#endregion Columns

		#region Associations

		/// <summary>
		/// Association <br/>
		/// [FK][Many]tblBillCategory.ParentBillCategoryID --- [PK][One]tblBillCategory.BillCategoryID <br/>
		/// </summary>
		public virtual tblBillCategory ParentBillCategory { get; set; }

		/// <summary>
		/// Association <br/>
		/// [PK][One]tblBillCategory.BillCategoryID --- [FK][Many]tblBillCategory.ParentBillCategoryID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<tblBillCategory> BillCategoryList { get; set; } = new List<tblBillCategory>();

		/// <summary>
		/// Association <br/>
		/// [FK][Many]tblBillCategory.BillPoslovniProstorID --- [PK][One]tblBillPoslovniProstor.BillPoslovniProstorID <br/>
		/// </summary>
		public virtual tblBillPoslovniProstor tblBillPoslovniProstor { get; set; }

		/// <summary>
		/// Association <br/>
		/// [PK][One]tblBillCategory.BillCategoryID --- [FK][Many]tblBillProductCategory.BillCategoryID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<tblBillProductCategory> tblBillProductCategoryList { get; set; } = new List<tblBillProductCategory>();
		#endregion Associations

		partial void OnCreated();
	}
	#endregion dbo.tblBillCategory

	#region dbo.tblBillClient
	public partial class tblBillClient : EFCoreEntityBase<tblBillClient>
	{
		public tblBillClient()
		{
			OnCreated();
		}

		public tblBillClient(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "BigInt NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert
		/// </summary>
		public long BillClientID { get; set; }

		/// <summary>
		/// DbType = "DateTime NOT NULL", DefaultValue = /*getdate()*/ DateTime.Now
		/// </summary>
		public DateTime InsertionDate { get; set; } = /*getdate()*/ DateTime.Now;

		/// <summary>
		/// DbType = "BigInt NOT NULL"
		/// </summary>
		public long BillFirmaID { get; set; }

		/// <summary>
		/// DbType = "BigInt"
		/// </summary>
		public long? DirClientID { get; set; }

		/// <summary>
		/// DbType = "VarChar(20)"
		/// </summary>
		public string MaticniBroj { get; set; }

		/// <summary>
		/// DbType = "VarChar(20)"
		/// </summary>
		public string PorezniBroj { get; set; }

		/// <summary>
		/// DbType = "NVarChar(250)"
		/// </summary>
		public string Naziv { get; set; }

		/// <summary>
		/// DbType = "NVarChar(250)"
		/// </summary>
		public string Adresa { get; set; }

		/// <summary>
		/// DbType = "NVarChar(250)"
		/// </summary>
		public string Naselje { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50)"
		/// </summary>
		public string PostanskiBroj { get; set; }

		/// <summary>
		/// DbType = "NVarChar(250)"
		/// </summary>
		public string PostanskiUred { get; set; }

		/// <summary>
		/// DbType = "NVarChar(100)"
		/// </summary>
		public string OdgovornaOsoba { get; set; }

		/// <summary>
		/// DbType = "Bit"
		/// </summary>
		public bool? IsVlasnik { get; set; }

		/// <summary>
		/// DbType = "VarChar(50)"
		/// </summary>
		public string IBAN { get; set; }

		#endregion Columns

		#region Associations

		/// <summary>
		/// Association <br/>
		/// [FK][Many]tblBillClient.BillFirmaID --- [PK][One]tblBillFirma.BillFirmaID <br/>
		/// </summary>
		public virtual tblBillFirma tblBillFirma { get; set; }

		/// <summary>
		/// Association <br/>
		/// [FK][Many]tblBillClient.DirClientID --- [PK][One]tblDirClient.DirClientID <br/>
		/// </summary>
		public virtual tblDirClient tblDirClient { get; set; }

		/// <summary>
		/// Association <br/>
		/// [PK][One]tblBillClient.BillClientID --- [FK][One]tblBillClientFullText.BillClientID <br/>
		/// DeleteRule = Cascade <br/>
		/// </summary>
		public virtual tblBillClientFullText tblBillClientFullText { get; set; }

		/// <summary>
		/// Association <br/>
		/// [PK][One]tblBillClient.BillClientID --- [FK][Many]tblBillDocument.BillClientID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<tblBillDocument> tblBillDocumentList { get; set; } = new List<tblBillDocument>();

		/// <summary>
		/// Association <br/>
		/// [PK][One]tblBillClient.BillClientID --- [FK][Many]tblSocialMember.BillClientID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<tblSocialMember> tblSocialMemberList { get; set; } = new List<tblSocialMember>();
		#endregion Associations

		partial void OnCreated();
	}
	#endregion dbo.tblBillClient

	#region dbo.tblBillClientFullText
	public partial class tblBillClientFullText : EFCoreEntityBase<tblBillClientFullText>
	{
		public tblBillClientFullText()
		{
			OnCreated();
		}

		public tblBillClientFullText(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "BigInt NOT NULL", IsPrimaryKey = true
		/// </summary>
		public long BillClientID { get; set; }

		/// <summary>
		/// DbType = "NVarChar(MAX)"
		/// </summary>
		public string fullTextIndexBasic { get; set; }

		#endregion Columns

		#region Associations

		/// <summary>
		/// Association <br/>
		/// [FK][One]tblBillClientFullText.BillClientID --- [PK][One]tblBillClient.BillClientID <br/>
		/// DeleteOnNull = true <br/>
		/// </summary>
		public virtual tblBillClient tblBillClient { get; set; }
		#endregion Associations

		partial void OnCreated();
	}
	#endregion dbo.tblBillClientFullText

	#region dbo.tblBillDocument
	public partial class tblBillDocument : EFCoreEntityBase<tblBillDocument>
	{
		public tblBillDocument()
		{
			OnCreated();
		}

		public tblBillDocument(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "BigInt NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert
		/// </summary>
		public long BillDocumentID { get; set; }

		/// <summary>
		/// DbType = "BigInt NOT NULL"
		/// </summary>
		public long BillClientID { get; set; }

		/// <summary>
		/// DbType = "BigInt"
		/// </summary>
		public long? ParentBillDocumentID { get; set; }

		/// <summary>
		/// DbType = "BigInt NOT NULL"
		/// </summary>
		public long BillNaplatniUredjajID { get; set; }

		/// <summary>
		/// DbType = "Int NOT NULL"
		/// </summary>
		public int RedniBroj { get; set; }

		/// <summary>
		/// DbType = "VarChar(10) NOT NULL"
		/// </summary>
		public string ModelPlacanja { get; set; }

		/// <summary>
		/// DbType = "VarChar(50) NOT NULL"
		/// </summary>
		public string PozivNaBroj { get; set; }

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

		/// <summary>
		/// DbType = "Int"
		/// </summary>
		public int? BrojDanaZaUplatu { get; set; }

		/// <summary>
		/// DbType = "DateTime"
		/// </summary>
		public DateTime? DatumUplate { get; set; }

		/// <summary>
		/// DbType = "DateTime"
		/// </summary>
		public DateTime? PoslanKupcuDatum { get; set; }

		/// <summary>
		/// DbType = "VarChar(100)"
		/// </summary>
		public string ZKI { get; set; }

		/// <summary>
		/// DbType = "VarChar(100)"
		/// </summary>
		public string JIR { get; set; }

		/// <summary>
		/// DbType = "Int"
		/// </summary>
		public int? VariantID { get; set; }

		/// <summary>
		/// DbType = "Bit NOT NULL"
		/// </summary>
		public bool IsInPdvSustav { get; set; }

		/// <summary>
		/// DbType = "BigInt NOT NULL"
		/// </summary>
		public long AppMemberID { get; set; }

		/// <summary>
		/// DbType = "Bit NOT NULL"
		/// </summary>
		public bool IsDeleted { get; set; }

		/// <summary>
		/// DbType = "NVarChar(500)"
		/// </summary>
		public string Napomena { get; set; }

		/// <summary>
		/// DbType = "Int"
		/// </summary>
		public int? FiskalTryCount { get; set; }

		/// <summary>
		/// DbType = "Bit NOT NULL"
		/// </summary>
		public bool IsFiskalizacijaRequired { get; set; }

		#endregion Columns

		#region Associations

		/// <summary>
		/// Association <br/>
		/// [FK][Many]tblBillDocument.AppMemberID --- [PK][One]tblAppMember.AppMemberID <br/>
		/// </summary>
		public virtual tblAppMember tblAppMember { get; set; }

		/// <summary>
		/// Association <br/>
		/// [FK][Many]tblBillDocument.BillClientID --- [PK][One]tblBillClient.BillClientID <br/>
		/// </summary>
		public virtual tblBillClient tblBillClient { get; set; }

		/// <summary>
		/// Association <br/>
		/// [FK][Many]tblBillDocument.ParentBillDocumentID --- [PK][One]tblBillDocument.BillDocumentID <br/>
		/// </summary>
		public virtual tblBillDocument ParentBillDocument { get; set; }

		/// <summary>
		/// Association <br/>
		/// [PK][One]tblBillDocument.BillDocumentID --- [FK][Many]tblBillDocument.ParentBillDocumentID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<tblBillDocument> BillDocumentList { get; set; } = new List<tblBillDocument>();

		/// <summary>
		/// Association <br/>
		/// [FK][Many]tblBillDocument.VariantID --- [PK][One]tblBillDocumentVariant.VariantID <br/>
		/// </summary>
		public virtual tblBillDocumentVariant tblBillDocumentVariant { get; set; }

		/// <summary>
		/// Association <br/>
		/// [FK][Many]tblBillDocument.BillNaplatniUredjajID --- [PK][One]tblBillNaplatniUredjaj.BillNaplatniUredjajID <br/>
		/// </summary>
		public virtual tblBillNaplatniUredjaj tblBillNaplatniUredjaj { get; set; }

		/// <summary>
		/// Association <br/>
		/// [PK][One]tblBillDocument.BillDocumentID --- [FK][One]tblBillDocumentCalculated.BillDocumentID <br/>
		/// DeleteRule = Cascade <br/>
		/// </summary>
		public virtual tblBillDocumentCalculated tblBillDocumentCalculated { get; set; }

		/// <summary>
		/// Association <br/>
		/// [PK][One]tblBillDocument.BillDocumentID --- [FK][Many]tblBillDocumentStavka.BillDocumentID <br/>
		/// DeleteRule = Cascade <br/>
		/// </summary>
		public virtual List<tblBillDocumentStavka> tblBillDocumentStavkaList { get; set; } = new List<tblBillDocumentStavka>();

		/// <summary>
		/// Association <br/>
		/// [PK][One]tblBillDocument.BillDocumentID --- [FK][Many]tblBillDownloadLog.BillDocumentID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<tblBillDownloadLog> tblBillDownloadLogList { get; set; } = new List<tblBillDownloadLog>();

		/// <summary>
		/// Association <br/>
		/// [PK][One]tblBillDocument.BillDocumentID --- [FK][Many]tblFiskalRacunZahtjevLog.BillDocumentID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<tblFiskalRacunZahtjevLog> tblFiskalRacunZahtjevLogList { get; set; } = new List<tblFiskalRacunZahtjevLog>();
		#endregion Associations

		partial void OnCreated();
	}
	#endregion dbo.tblBillDocument

	#region dbo.tblBillDocumentCalculated
	public partial class tblBillDocumentCalculated : EFCoreEntityBase<tblBillDocumentCalculated>
	{
		public tblBillDocumentCalculated()
		{
			OnCreated();
		}

		public tblBillDocumentCalculated(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "BigInt NOT NULL", IsPrimaryKey = true
		/// </summary>
		public long BillDocumentID { get; set; }

		/// <summary>
		/// DbType = "Decimal(18,8) NOT NULL"
		/// </summary>
		public decimal SumPoreznaOsnovica { get; set; }

		/// <summary>
		/// DbType = "Decimal(18,8) NOT NULL"
		/// </summary>
		public decimal SumIznosPdva { get; set; }

		/// <summary>
		/// DbType = "Decimal(18,8) NOT NULL"
		/// </summary>
		public decimal SumIznosPorezPotrosnja { get; set; }

		/// <summary>
		/// DbType = "Decimal(18,8) NOT NULL"
		/// </summary>
		public decimal SumIznosOstaliPorez { get; set; }

		/// <summary>
		/// DbType = "Decimal(18,8) NOT NULL"
		/// </summary>
		public decimal SumUkupno { get; set; }

		#endregion Columns

		#region Associations

		/// <summary>
		/// Association <br/>
		/// [FK][One]tblBillDocumentCalculated.BillDocumentID --- [PK][One]tblBillDocument.BillDocumentID <br/>
		/// DeleteOnNull = true <br/>
		/// </summary>
		public virtual tblBillDocument tblBillDocument { get; set; }
		#endregion Associations

		partial void OnCreated();
	}
	#endregion dbo.tblBillDocumentCalculated

	#region dbo.tblBillDocumentStavka
	public partial class tblBillDocumentStavka : EFCoreEntityBase<tblBillDocumentStavka>
	{
		public tblBillDocumentStavka()
		{
			OnCreated();
		}

		public tblBillDocumentStavka(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "BigInt NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert
		/// </summary>
		public long BillDocumentStavkaID { get; set; }

		/// <summary>
		/// DbType = "BigInt NOT NULL"
		/// </summary>
		public long BillDocumentID { get; set; }

		/// <summary>
		/// DbType = "BigInt NOT NULL"
		/// </summary>
		public long BillProductID { get; set; }

		/// <summary>
		/// DbType = "NVarChar(150) NOT NULL"
		/// </summary>
		public string ProductNaziv { get; set; }

		/// <summary>
		/// DbType = "Money NOT NULL"
		/// </summary>
		public decimal JedinicnaCijena { get; set; }

		/// <summary>
		/// DbType = "Bit NOT NULL"
		/// </summary>
		public bool CijenaJeMPC { get; set; }

		/// <summary>
		/// DbType = "Int NOT NULL"
		/// </summary>
		public int BillMjeraID { get; set; }

		/// <summary>
		/// DbType = "Decimal(18,8) NOT NULL"
		/// </summary>
		public decimal Kolicina { get; set; }

		/// <summary>
		/// DbType = "Money NOT NULL"
		/// </summary>
		public decimal PopustPosto { get; set; }

		/// <summary>
		/// DbType = "BigInt NOT NULL"
		/// </summary>
		public long BillPoreznaGrupaID { get; set; }

		/// <summary>
		/// DbType = "NVarChar(100) NOT NULL"
		/// </summary>
		public string PoreznaGrupaNaziv { get; set; }

		/// <summary>
		/// DbType = "Bit NOT NULL"
		/// </summary>
		public bool IsInPdvSustav { get; set; }

		/// <summary>
		/// DbType = "Decimal(5,2) NOT NULL"
		/// </summary>
		public decimal PdvPosto { get; set; }

		/// <summary>
		/// DbType = "Decimal(5,2) NOT NULL"
		/// </summary>
		public decimal PorezPotrosnjaPosto { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50)"
		/// </summary>
		public string OstaliPorezNaziv { get; set; }

		/// <summary>
		/// DbType = "Decimal(5,2) NOT NULL"
		/// </summary>
		public decimal OstaliPorezPosto { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50)"
		/// </summary>
		public string NaknadaNaziv { get; set; }

		/// <summary>
		/// DbType = "Money NOT NULL"
		/// </summary>
		public decimal IznosNaknade { get; set; }

		#endregion Columns

		#region Associations

		/// <summary>
		/// Association <br/>
		/// [FK][Many]tblBillDocumentStavka.BillDocumentID --- [PK][One]tblBillDocument.BillDocumentID <br/>
		/// DeleteOnNull = true <br/>
		/// </summary>
		public virtual tblBillDocument tblBillDocument { get; set; }

		/// <summary>
		/// Association <br/>
		/// [FK][Many]tblBillDocumentStavka.BillMjeraID --- [PK][One]tblBillMjera.BillMjeraID <br/>
		/// </summary>
		public virtual tblBillMjera tblBillMjera { get; set; }

		/// <summary>
		/// Association <br/>
		/// [FK][Many]tblBillDocumentStavka.BillPoreznaGrupaID --- [PK][One]tblBillPoreznaGrupa.BillPoreznaGrupaID <br/>
		/// </summary>
		public virtual tblBillPoreznaGrupa tblBillPoreznaGrupa { get; set; }

		/// <summary>
		/// Association <br/>
		/// [FK][Many]tblBillDocumentStavka.BillProductID --- [PK][One]tblBillProduct.BillProductID <br/>
		/// </summary>
		public virtual tblBillProduct tblBillProduct { get; set; }
		#endregion Associations

		partial void OnCreated();
	}
	#endregion dbo.tblBillDocumentStavka

	#region dbo.tblBillDocumentTip
	public partial class tblBillDocumentTip : EFCoreEntityBase<tblBillDocumentTip>
	{
		public tblBillDocumentTip()
		{
			OnCreated();
		}

		public tblBillDocumentTip(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "Int NOT NULL", IsPrimaryKey = true
		/// </summary>
		public int BillDocumentTipID { get; set; }

		/// <summary>
		/// DbType = "Bit NOT NULL"
		/// </summary>
		public bool IsActive { get; set; }

		/// <summary>
		/// DbType = "Int NOT NULL"
		/// </summary>
		public int Ordinal { get; set; }

		/// <summary>
		/// DbType = "Bit NOT NULL"
		/// </summary>
		public bool IsDefault { get; set; }

		/// <summary>
		/// DbType = "VarChar(100)"
		/// </summary>
		public string PropertyName { get; set; }

		/// <summary>
		/// DbType = "Bit NOT NULL"
		/// </summary>
		public bool IsRacunType { get; set; }

		/// <summary>
		/// DbType = "Bit NOT NULL"
		/// </summary>
		public bool IsMaloprodajniRacun { get; set; }

		#endregion Columns

		#region Associations

		/// <summary>
		/// Association <br/>
		/// [PK][One]tblBillDocumentTip.BillDocumentTipID --- [FK][Many]tblBillNaplatniUredjaj.BillDocumentTipID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<tblBillNaplatniUredjaj> tblBillNaplatniUredjajList { get; set; } = new List<tblBillNaplatniUredjaj>();
		#endregion Associations

		partial void OnCreated();
	}
	#endregion dbo.tblBillDocumentTip

	#region dbo.tblBillDocumentVariant
	public partial class tblBillDocumentVariant : EFCoreEntityBase<tblBillDocumentVariant>
	{
		public tblBillDocumentVariant()
		{
			OnCreated();
		}

		public tblBillDocumentVariant(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "Int NOT NULL", IsPrimaryKey = true
		/// </summary>
		public int VariantID { get; set; }

		/// <summary>
		/// DbType = "Bit NOT NULL", DefaultValue = false
		/// </summary>
		public bool MarkBillAsSent { get; set; } = false;

		/// <summary>
		/// DbType = "VarChar(255)"
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// DbType = "VarChar(1000)"
		/// </summary>
		public string Description { get; set; }

		#endregion Columns

		#region Associations

		/// <summary>
		/// Association <br/>
		/// [PK][One]tblBillDocumentVariant.VariantID --- [FK][Many]tblBillDocument.VariantID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<tblBillDocument> tblBillDocumentList { get; set; } = new List<tblBillDocument>();
		#endregion Associations

		partial void OnCreated();
	}
	#endregion dbo.tblBillDocumentVariant

	#region dbo.tblBillDownloadLog
	public partial class tblBillDownloadLog : EFCoreEntityBase<tblBillDownloadLog>
	{
		public tblBillDownloadLog()
		{
			OnCreated();
		}

		public tblBillDownloadLog(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "BigInt NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert
		/// </summary>
		public long BillDownloadLogID { get; set; }

		/// <summary>
		/// DbType = "DateTime"
		/// </summary>
		public DateTime? InsertionDate { get; set; }

		/// <summary>
		/// DbType = "VarChar(20)"
		/// </summary>
		public string PorezniBroj { get; set; }

		/// <summary>
		/// DbType = "VarChar(20)"
		/// </summary>
		public string MaticniBroj { get; set; }

		/// <summary>
		/// DbType = "VarChar(50)"
		/// </summary>
		public string PozivNaBroj { get; set; }

		/// <summary>
		/// DbType = "BigInt"
		/// </summary>
		public long? BillDocumentID { get; set; }

		#endregion Columns

		#region Associations

		/// <summary>
		/// Association <br/>
		/// [FK][Many]tblBillDownloadLog.BillDocumentID --- [PK][One]tblBillDocument.BillDocumentID <br/>
		/// </summary>
		public virtual tblBillDocument tblBillDocument { get; set; }
		#endregion Associations

		partial void OnCreated();
	}
	#endregion dbo.tblBillDownloadLog

	#region dbo.tblBillFirma
	public partial class tblBillFirma : EFCoreEntityBase<tblBillFirma>
	{
		public tblBillFirma()
		{
			OnCreated();
		}

		public tblBillFirma(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "BigInt NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert
		/// </summary>
		public long BillFirmaID { get; set; }

		/// <summary>
		/// DbType = "DateTime"
		/// </summary>
		public DateTime? PdvSustavStartDate { get; set; }

		/// <summary>
		/// DbType = "DateTime"
		/// </summary>
		public DateTime? PdvSustavEndDate { get; set; }

		/// <summary>
		/// DbType = "VarChar(15) NOT NULL"
		/// </summary>
		public string PorezniBroj { get; set; }

		/// <summary>
		/// DbType = "NVarChar(255)"
		/// </summary>
		public string Naziv { get; set; }

		/// <summary>
		/// DbType = "NVarChar(255)"
		/// </summary>
		public string Adresa { get; set; }

		/// <summary>
		/// DbType = "VarChar(10)"
		/// </summary>
		public string PostanskiBroj { get; set; }

		/// <summary>
		/// DbType = "NVarChar(100)"
		/// </summary>
		public string Mjesto { get; set; }

		/// <summary>
		/// DbType = "NVarChar(255)"
		/// </summary>
		public string OslobodjenoPdvaNapomena { get; set; }

		/// <summary>
		/// DbType = "NVarChar(255)"
		/// </summary>
		public string RacunIzradjenNaRacunaluNapomena { get; set; }

		/// <summary>
		/// DbType = "VarChar(150)"
		/// </summary>
		public string Email { get; set; }

		/// <summary>
		/// DbType = "VarChar(255)"
		/// </summary>
		public string WebSite { get; set; }

		/// <summary>
		/// DbType = "VarChar(20)"
		/// </summary>
		public string Telefon { get; set; }

		/// <summary>
		/// DbType = "VarChar(20)"
		/// </summary>
		public string Mobitel { get; set; }

		/// <summary>
		/// DbType = "VarChar(20)"
		/// </summary>
		public string Fax { get; set; }

		/// <summary>
		/// DbType = "Int NOT NULL"
		/// </summary>
		public int BillFirmaCertificateModeID { get; set; }

		/// <summary>
		/// DbType = "NVarChar(500)"
		/// </summary>
		public string FooterText { get; set; }

		/// <summary>
		/// DbType = "Bit"
		/// </summary>
		public bool? HidePoweredByFooter { get; set; }

		#endregion Columns

		#region Associations

		/// <summary>
		/// Association <br/>
		/// [PK][One]tblBillFirma.BillFirmaID --- [FK][Many]tblAppMember.BillFirmaID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<tblAppMember> tblAppMemberList { get; set; } = new List<tblAppMember>();

		/// <summary>
		/// Association <br/>
		/// [PK][One]tblBillFirma.BillFirmaID --- [FK][Many]tblBillClient.BillFirmaID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<tblBillClient> tblBillClientList { get; set; } = new List<tblBillClient>();

		/// <summary>
		/// Association <br/>
		/// [FK][Many]tblBillFirma.BillFirmaCertificateModeID --- [PK][One]tblBillFirmaCertificateMode.BillFirmaCertificateModeID <br/>
		/// </summary>
		public virtual tblBillFirmaCertificateMode tblBillFirmaCertificateMode { get; set; }

		/// <summary>
		/// Association <br/>
		/// [PK][One]tblBillFirma.BillFirmaID --- [FK][Many]tblBillFirmaCertificate.BillFirmaID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<tblBillFirmaCertificate> tblBillFirmaCertificateList { get; set; } = new List<tblBillFirmaCertificate>();

		/// <summary>
		/// Association <br/>
		/// [PK][One]tblBillFirma.BillFirmaID --- [FK][Many]tblBillFirmaPos.BillFirmaID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<tblBillFirmaPos> tblBillFirmaPosList { get; set; } = new List<tblBillFirmaPos>();

		/// <summary>
		/// Association <br/>
		/// [PK][One]tblBillFirma.BillFirmaID --- [FK][Many]tblBillFirmaTransakcijskiRacun.BillFirmaID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<tblBillFirmaTransakcijskiRacun> tblBillFirmaTransakcijskiRacunList { get; set; } = new List<tblBillFirmaTransakcijskiRacun>();

		/// <summary>
		/// Association <br/>
		/// [PK][One]tblBillFirma.BillFirmaID --- [FK][Many]tblBillPoslovniProstor.BillFirmaID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<tblBillPoslovniProstor> tblBillPoslovniProstorList { get; set; } = new List<tblBillPoslovniProstor>();

		/// <summary>
		/// Association <br/>
		/// [PK][One]tblBillFirma.BillFirmaID --- [FK][Many]tblBookkeepingFiduciaExport.BillFirmaID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<tblBookkeepingFiduciaExport> tblBookkeepingFiduciaExportList { get; set; } = new List<tblBookkeepingFiduciaExport>();

		/// <summary>
		/// Association <br/>
		/// [PK][One]tblBillFirma.BillFirmaID --- [FK][Many]tblBookkeepingSynesisExport.BillFirmaID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<tblBookkeepingSynesisExport> tblBookkeepingSynesisExportList { get; set; } = new List<tblBookkeepingSynesisExport>();

		/// <summary>
		/// Association <br/>
		/// [PK][One]tblBillFirma.BillFirmaID --- [FK][Many]tblDirClientBlacklist.BillFirmaID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<tblDirClientBlacklist> tblDirClientBlacklistList { get; set; } = new List<tblDirClientBlacklist>();
		#endregion Associations

		partial void OnCreated();
	}
	#endregion dbo.tblBillFirma

	#region dbo.tblBillFirmaCertificate
	public partial class tblBillFirmaCertificate : EFCoreEntityBase<tblBillFirmaCertificate>
	{
		public tblBillFirmaCertificate()
		{
			OnCreated();
		}

		public tblBillFirmaCertificate(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "BigInt NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert
		/// </summary>
		public long BillFirmaCertificateID { get; set; }

		/// <summary>
		/// DbType = "BigInt NOT NULL"
		/// </summary>
		public long BillFirmaID { get; set; }

		/// <summary>
		/// DbType = "DateTime NOT NULL"
		/// </summary>
		public DateTime InsertionDate { get; set; }

		/// <summary>
		/// DbType = "VarChar(100) NOT NULL"
		/// </summary>
		public string CertSerial { get; set; }

		/// <summary>
		/// DbType = "VarBinary(MAX) NOT NULL"
		/// </summary>
		public byte[] CertData1 { get; set; }

		/// <summary>
		/// DbType = "VarBinary(MAX) NOT NULL"
		/// </summary>
		public byte[] CertData2 { get; set; }

		/// <summary>
		/// DbType = "VarChar(255)"
		/// </summary>
		public string CertIssuer { get; set; }

		/// <summary>
		/// DbType = "VarChar(255)"
		/// </summary>
		public string CertSubject { get; set; }

		/// <summary>
		/// DbType = "DateTime"
		/// </summary>
		public DateTime? NotBefore { get; set; }

		/// <summary>
		/// DbType = "DateTime"
		/// </summary>
		public DateTime? NotAfter { get; set; }

		/// <summary>
		/// DbType = "Int"
		/// </summary>
		public int? BillFirmaCertificateModeID { get; set; }

		#endregion Columns

		#region Associations

		/// <summary>
		/// Association <br/>
		/// [FK][Many]tblBillFirmaCertificate.BillFirmaID --- [PK][One]tblBillFirma.BillFirmaID <br/>
		/// </summary>
		public virtual tblBillFirma tblBillFirma { get; set; }

		/// <summary>
		/// Association <br/>
		/// [FK][Many]tblBillFirmaCertificate.BillFirmaCertificateModeID --- [PK][One]tblBillFirmaCertificateMode.BillFirmaCertificateModeID <br/>
		/// </summary>
		public virtual tblBillFirmaCertificateMode tblBillFirmaCertificateMode { get; set; }
		#endregion Associations

		partial void OnCreated();
	}
	#endregion dbo.tblBillFirmaCertificate

	#region dbo.tblBillFirmaCertificateMode
	public partial class tblBillFirmaCertificateMode : EFCoreEntityBase<tblBillFirmaCertificateMode>
	{
		public tblBillFirmaCertificateMode()
		{
			OnCreated();
		}

		public tblBillFirmaCertificateMode(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "Int NOT NULL", IsPrimaryKey = true
		/// </summary>
		public int BillFirmaCertificateModeID { get; set; }

		/// <summary>
		/// DbType = "VarChar(100)"
		/// </summary>
		public string PropertyName { get; set; }

		#endregion Columns

		#region Associations

		/// <summary>
		/// Association <br/>
		/// [PK][One]tblBillFirmaCertificateMode.BillFirmaCertificateModeID --- [FK][Many]tblBillFirma.BillFirmaCertificateModeID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<tblBillFirma> tblBillFirmaList { get; set; } = new List<tblBillFirma>();

		/// <summary>
		/// Association <br/>
		/// [PK][One]tblBillFirmaCertificateMode.BillFirmaCertificateModeID --- [FK][Many]tblBillFirmaCertificate.BillFirmaCertificateModeID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<tblBillFirmaCertificate> tblBillFirmaCertificateList { get; set; } = new List<tblBillFirmaCertificate>();
		#endregion Associations

		partial void OnCreated();
	}
	#endregion dbo.tblBillFirmaCertificateMode

	#region dbo.tblBillFirmaPos
	public partial class tblBillFirmaPos : EFCoreEntityBase<tblBillFirmaPos>
	{
		public tblBillFirmaPos()
		{
			OnCreated();
		}

		public tblBillFirmaPos(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "BigInt NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert
		/// </summary>
		public long BillFirmaPosID { get; set; }

		/// <summary>
		/// DbType = "BigInt NOT NULL"
		/// </summary>
		public long BillFirmaID { get; set; }

		/// <summary>
		/// DbType = "BigInt"
		/// </summary>
		public long? ReferenceBillDocumentID { get; set; }

		/// <summary>
		/// DbType = "DateTime NOT NULL"
		/// </summary>
		public DateTime StartDate { get; set; }

		/// <summary>
		/// DbType = "DateTime NOT NULL"
		/// </summary>
		public DateTime EndDate { get; set; }

		/// <summary>
		/// DbType = "Bit NOT NULL"
		/// </summary>
		public bool IsActive { get; set; }

		/// <summary>
		/// DbType = "Int NOT NULL"
		/// </summary>
		public int PoslovniProstoriMax { get; set; }

		/// <summary>
		/// DbType = "Int NOT NULL"
		/// </summary>
		public int NaplatniUredjajiMax { get; set; }

		/// <summary>
		/// DbType = "Int NOT NULL"
		/// </summary>
		public int DocumentsMax { get; set; }

		/// <summary>
		/// DbType = "Int NOT NULL"
		/// </summary>
		public int DocumentsCount { get; set; }

		/// <summary>
		/// DbType = "Int NOT NULL"
		/// </summary>
		public int CategoriesMax { get; set; }

		/// <summary>
		/// DbType = "Int NOT NULL"
		/// </summary>
		public int ProductsMax { get; set; }

		/// <summary>
		/// DbType = "Int NOT NULL"
		/// </summary>
		public int PorezneGrupeMax { get; set; }

		/// <summary>
		/// DbType = "Int NOT NULL"
		/// </summary>
		public int OperatoriMax { get; set; }

		#endregion Columns

		#region Associations

		/// <summary>
		/// Association <br/>
		/// [FK][Many]tblBillFirmaPos.BillFirmaID --- [PK][One]tblBillFirma.BillFirmaID <br/>
		/// </summary>
		public virtual tblBillFirma tblBillFirma { get; set; }
		#endregion Associations

		partial void OnCreated();
	}
	#endregion dbo.tblBillFirmaPos

	#region dbo.tblBillFirmaTransakcijskiRacun
	public partial class tblBillFirmaTransakcijskiRacun : EFCoreEntityBase<tblBillFirmaTransakcijskiRacun>
	{
		public tblBillFirmaTransakcijskiRacun()
		{
			OnCreated();
		}

		public tblBillFirmaTransakcijskiRacun(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "BigInt NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert
		/// </summary>
		public long BillFirmaTransakcijskiRacunID { get; set; }

		/// <summary>
		/// DbType = "Int NOT NULL"
		/// </summary>
		public int BankaID { get; set; }

		/// <summary>
		/// DbType = "Bit NOT NULL", DefaultValue = false
		/// </summary>
		public bool IsPersonalAccount { get; set; } = false;

		/// <summary>
		/// DbType = "BigInt NOT NULL"
		/// </summary>
		public long BillFirmaID { get; set; }

		/// <summary>
		/// DbType = "VarChar(50) NOT NULL"
		/// </summary>
		public string IBAN { get; set; }

		/// <summary>
		/// DbType = "VarChar(10)", DefaultValue = "HRK"
		/// </summary>
		public string Valuta { get; set; } = "HRK";

		/// <summary>
		/// DbType = "NVarChar(50)"
		/// </summary>
		public string Naziv { get; set; }

		/// <summary>
		/// DbType = "Bit NOT NULL", DefaultValue = false
		/// </summary>
		public bool VidljivNaPonudama { get; set; } = false;

		/// <summary>
		/// DbType = "BigInt"
		/// </summary>
		public long? BillFirmaTransakcijskiRacunEmailID { get; set; }

		#endregion Columns

		#region Associations

		/// <summary>
		/// Association <br/>
		/// [PK][One]tblBillFirmaTransakcijskiRacun.BillFirmaTransakcijskiRacunID --- [FK][Many]tblBankaPromet.BillFirmaTransakcijskiRacunID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<tblBankaPromet> tblBankaPrometList { get; set; } = new List<tblBankaPromet>();

		/// <summary>
		/// Association <br/>
		/// [FK][Many]tblBillFirmaTransakcijskiRacun.BankaID --- [PK][One]tblBanka.BankaID <br/>
		/// </summary>
		public virtual tblBanka tblBanka { get; set; }

		/// <summary>
		/// Association <br/>
		/// [FK][Many]tblBillFirmaTransakcijskiRacun.BillFirmaID --- [PK][One]tblBillFirma.BillFirmaID <br/>
		/// </summary>
		public virtual tblBillFirma tblBillFirma { get; set; }

		/// <summary>
		/// Association <br/>
		/// [FK][Many]tblBillFirmaTransakcijskiRacun.BillFirmaTransakcijskiRacunEmailID --- [PK][One]tblBillFirmaTransakcijskiRacunEmail.BillFirmaTransakcijskiRacunEmailID <br/>
		/// </summary>
		public virtual tblBillFirmaTransakcijskiRacunEmail tblBillFirmaTransakcijskiRacunEmail { get; set; }
		#endregion Associations

		partial void OnCreated();
	}
	#endregion dbo.tblBillFirmaTransakcijskiRacun

	#region dbo.tblBillFirmaTransakcijskiRacunEmail
	public partial class tblBillFirmaTransakcijskiRacunEmail : EFCoreEntityBase<tblBillFirmaTransakcijskiRacunEmail>
	{
		public tblBillFirmaTransakcijskiRacunEmail()
		{
			OnCreated();
		}

		public tblBillFirmaTransakcijskiRacunEmail(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "BigInt NOT NULL", IsPrimaryKey = true
		/// </summary>
		public long BillFirmaTransakcijskiRacunEmailID { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50)"
		/// </summary>
		public string Host { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50)"
		/// </summary>
		public string User { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50)"
		/// </summary>
		public string Pass { get; set; }

		/// <summary>
		/// DbType = "Int"
		/// </summary>
		public int? Port { get; set; }

		/// <summary>
		/// DbType = "Bit NOT NULL"
		/// </summary>
		public bool UseSSL { get; set; }

		/// <summary>
		/// DbType = "VarChar(MAX)"
		/// </summary>
		public string ReceivedEmailUIDLS { get; set; }

		#endregion Columns

		#region Associations

		/// <summary>
		/// Association <br/>
		/// [PK][One]tblBillFirmaTransakcijskiRacunEmail.BillFirmaTransakcijskiRacunEmailID --- [FK][Many]tblBillFirmaTransakcijskiRacun.BillFirmaTransakcijskiRacunEmailID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<tblBillFirmaTransakcijskiRacun> tblBillFirmaTransakcijskiRacunList { get; set; } = new List<tblBillFirmaTransakcijskiRacun>();
		#endregion Associations

		partial void OnCreated();
	}
	#endregion dbo.tblBillFirmaTransakcijskiRacunEmail

	#region dbo.tblBillMjera
	public partial class tblBillMjera : EFCoreEntityBase<tblBillMjera>
	{
		public tblBillMjera()
		{
			OnCreated();
		}

		public tblBillMjera(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "Int NOT NULL", IsPrimaryKey = true
		/// </summary>
		public int BillMjeraID { get; set; }

		/// <summary>
		/// DbType = "Bit NOT NULL"
		/// </summary>
		public bool IsActive { get; set; }

		/// <summary>
		/// DbType = "Int NOT NULL"
		/// </summary>
		public int Ordinal { get; set; }

		/// <summary>
		/// DbType = "Bit NOT NULL"
		/// </summary>
		public bool IsDefault { get; set; }

		/// <summary>
		/// DbType = "VarChar(100)"
		/// </summary>
		public string PropertyName { get; set; }

		/// <summary>
		/// DbType = "VarChar(100)"
		/// </summary>
		public string KratkiNazivPropertyName { get; set; }

		/// <summary>
		/// DbType = "Int NOT NULL"
		/// </summary>
		public int OsnovnaBillMjeraID { get; set; }

		/// <summary>
		/// DbType = "Float NOT NULL"
		/// </summary>
		public double DioOsnovneMjere { get; set; }

		#endregion Columns

		#region Associations

		/// <summary>
		/// Association <br/>
		/// [PK][One]tblBillMjera.BillMjeraID --- [FK][Many]tblBillDocumentStavka.BillMjeraID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<tblBillDocumentStavka> tblBillDocumentStavkaList { get; set; } = new List<tblBillDocumentStavka>();

		/// <summary>
		/// Association <br/>
		/// [FK][Many]tblBillMjera.OsnovnaBillMjeraID --- [PK][One]tblBillMjera.BillMjeraID <br/>
		/// </summary>
		public virtual tblBillMjera OsnovnaBillMjera { get; set; }

		/// <summary>
		/// Association <br/>
		/// [PK][One]tblBillMjera.BillMjeraID --- [FK][Many]tblBillMjera.OsnovnaBillMjeraID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<tblBillMjera> BillMjeraList { get; set; } = new List<tblBillMjera>();

		/// <summary>
		/// Association <br/>
		/// [PK][One]tblBillMjera.BillMjeraID --- [FK][Many]tblBillProduct.BillMjeraID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<tblBillProduct> tblBillProductList { get; set; } = new List<tblBillProduct>();
		#endregion Associations

		partial void OnCreated();
	}
	#endregion dbo.tblBillMjera

	#region dbo.tblBillNaplatniUredjaj
	public partial class tblBillNaplatniUredjaj : EFCoreEntityBase<tblBillNaplatniUredjaj>
	{
		public tblBillNaplatniUredjaj()
		{
			OnCreated();
		}

		public tblBillNaplatniUredjaj(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "BigInt NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert
		/// </summary>
		public long BillNaplatniUredjajID { get; set; }

		/// <summary>
		/// DbType = "BigInt NOT NULL"
		/// </summary>
		public long BillPoslovniProstorID { get; set; }

		/// <summary>
		/// DbType = "Bit NOT NULL", DefaultValue = true
		/// </summary>
		public bool IsActive { get; set; } = true;

		/// <summary>
		/// DbType = "Int"
		/// </summary>
		public int? OznakaNaplatnogUredjaja { get; set; }

		/// <summary>
		/// DbType = "NVarChar(255)"
		/// </summary>
		public string Naziv { get; set; }

		/// <summary>
		/// DbType = "NVarChar(500)"
		/// </summary>
		public string Napomena { get; set; }

		/// <summary>
		/// DbType = "Int NOT NULL"
		/// </summary>
		public int BillPaymentMethodID { get; set; }

		/// <summary>
		/// DbType = "BigInt"
		/// </summary>
		public long? CreatesRacunBillNaplatniUredjajID { get; set; }

		/// <summary>
		/// DbType = "Int NOT NULL"
		/// </summary>
		public int BillDocumentTipID { get; set; }

		/// <summary>
		/// DbType = "VarChar(50)"
		/// </summary>
		public string POSMargineTRBL { get; set; }

		/// <summary>
		/// DbType = "NVarChar(500)"
		/// </summary>
		public string FooterText { get; set; }

		#endregion Columns

		#region Associations

		/// <summary>
		/// Association <br/>
		/// [PK][One]tblBillNaplatniUredjaj.BillNaplatniUredjajID --- [FK][Many]tblBillDocument.BillNaplatniUredjajID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<tblBillDocument> tblBillDocumentList { get; set; } = new List<tblBillDocument>();

		/// <summary>
		/// Association <br/>
		/// [FK][Many]tblBillNaplatniUredjaj.BillDocumentTipID --- [PK][One]tblBillDocumentTip.BillDocumentTipID <br/>
		/// </summary>
		public virtual tblBillDocumentTip tblBillDocumentTip { get; set; }

		/// <summary>
		/// Association <br/>
		/// [FK][Many]tblBillNaplatniUredjaj.CreatesRacunBillNaplatniUredjajID --- [PK][One]tblBillNaplatniUredjaj.BillNaplatniUredjajID <br/>
		/// </summary>
		public virtual tblBillNaplatniUredjaj CreatesRacunBillNaplatniUredjaj { get; set; }

		/// <summary>
		/// Association <br/>
		/// [PK][One]tblBillNaplatniUredjaj.BillNaplatniUredjajID --- [FK][Many]tblBillNaplatniUredjaj.CreatesRacunBillNaplatniUredjajID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<tblBillNaplatniUredjaj> BillNaplatniUredjajList { get; set; } = new List<tblBillNaplatniUredjaj>();

		/// <summary>
		/// Association <br/>
		/// [FK][Many]tblBillNaplatniUredjaj.BillPaymentMethodID --- [PK][One]tblBillPaymentMethod.BillPaymentMethodID <br/>
		/// </summary>
		public virtual tblBillPaymentMethod tblBillPaymentMethod { get; set; }

		/// <summary>
		/// Association <br/>
		/// [FK][Many]tblBillNaplatniUredjaj.BillPoslovniProstorID --- [PK][One]tblBillPoslovniProstor.BillPoslovniProstorID <br/>
		/// </summary>
		public virtual tblBillPoslovniProstor tblBillPoslovniProstor { get; set; }
		#endregion Associations

		partial void OnCreated();
	}
	#endregion dbo.tblBillNaplatniUredjaj

	#region dbo.tblBillOperator
	public partial class tblBillOperator : EFCoreEntityBase<tblBillOperator>
	{
		public tblBillOperator()
		{
			OnCreated();
		}

		public tblBillOperator(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "BigInt NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert
		/// </summary>
		public long BillOperatorID { get; set; }

		/// <summary>
		/// DbType = "NVarChar(100) NOT NULL"
		/// </summary>
		public string Ime { get; set; }

		/// <summary>
		/// DbType = "NVarChar(100) NOT NULL"
		/// </summary>
		public string Prezime { get; set; }

		/// <summary>
		/// DbType = "VarChar(50) NOT NULL"
		/// </summary>
		public string OperatorPorezniBroj { get; set; }

		#endregion Columns

		#region Associations

		/// <summary>
		/// Association <br/>
		/// [PK][One]tblBillOperator.BillOperatorID --- [FK][Many]tblAppMember.BillOperatorID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<tblAppMember> tblAppMemberList { get; set; } = new List<tblAppMember>();
		#endregion Associations

		partial void OnCreated();
	}
	#endregion dbo.tblBillOperator

	#region dbo.tblBillPaymentMethod
	public partial class tblBillPaymentMethod : EFCoreEntityBase<tblBillPaymentMethod>
	{
		public tblBillPaymentMethod()
		{
			OnCreated();
		}

		public tblBillPaymentMethod(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "Int NOT NULL", IsPrimaryKey = true
		/// </summary>
		public int BillPaymentMethodID { get; set; }

		/// <summary>
		/// DbType = "Bit NOT NULL"
		/// </summary>
		public bool IsActive { get; set; }

		/// <summary>
		/// DbType = "Int NOT NULL"
		/// </summary>
		public int Ordinal { get; set; }

		/// <summary>
		/// DbType = "Bit NOT NULL"
		/// </summary>
		public bool IsDefault { get; set; }

		/// <summary>
		/// DbType = "VarChar(100)"
		/// </summary>
		public string PropertyName { get; set; }

		/// <summary>
		/// DbType = "Bit NOT NULL"
		/// </summary>
		public bool IsFiskalizacijaRequired { get; set; }

		/// <summary>
		/// DbType = "VarChar(10)"
		/// </summary>
		public string OznakaZaFiskalizaciju { get; set; }

		#endregion Columns

		#region Associations

		/// <summary>
		/// Association <br/>
		/// [PK][One]tblBillPaymentMethod.BillPaymentMethodID --- [FK][Many]tblBillNaplatniUredjaj.BillPaymentMethodID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<tblBillNaplatniUredjaj> tblBillNaplatniUredjajList { get; set; } = new List<tblBillNaplatniUredjaj>();
		#endregion Associations

		partial void OnCreated();
	}
	#endregion dbo.tblBillPaymentMethod

	#region dbo.tblBillPoreznaGrupa
	public partial class tblBillPoreznaGrupa : EFCoreEntityBase<tblBillPoreznaGrupa>
	{
		public tblBillPoreznaGrupa()
		{
			OnCreated();
		}

		public tblBillPoreznaGrupa(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "BigInt NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert
		/// </summary>
		public long BillPoreznaGrupaID { get; set; }

		/// <summary>
		/// DbType = "BigInt NOT NULL"
		/// </summary>
		public long BillPoslovniProstorID { get; set; }

		/// <summary>
		/// DbType = "NVarChar(100) NOT NULL"
		/// </summary>
		public string Naziv { get; set; }

		/// <summary>
		/// DbType = "NVarChar(250)"
		/// </summary>
		public string Opis { get; set; }

		/// <summary>
		/// DbType = "Decimal(5,2) NOT NULL"
		/// </summary>
		public decimal PdvPosto { get; set; }

		/// <summary>
		/// DbType = "Decimal(5,2) NOT NULL"
		/// </summary>
		public decimal PorezPotrosnjaPosto { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50)"
		/// </summary>
		public string OstaliPorezNaziv { get; set; }

		/// <summary>
		/// DbType = "Decimal(5,2) NOT NULL"
		/// </summary>
		public decimal OstaliPorezPosto { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50)"
		/// </summary>
		public string NaknadaNaziv { get; set; }

		/// <summary>
		/// DbType = "Money NOT NULL"
		/// </summary>
		public decimal IznosNaknade { get; set; }

		#endregion Columns

		#region Associations

		/// <summary>
		/// Association <br/>
		/// [PK][One]tblBillPoreznaGrupa.BillPoreznaGrupaID --- [FK][Many]tblBillDocumentStavka.BillPoreznaGrupaID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<tblBillDocumentStavka> tblBillDocumentStavkaList { get; set; } = new List<tblBillDocumentStavka>();

		/// <summary>
		/// Association <br/>
		/// [FK][Many]tblBillPoreznaGrupa.BillPoslovniProstorID --- [PK][One]tblBillPoslovniProstor.BillPoslovniProstorID <br/>
		/// </summary>
		public virtual tblBillPoslovniProstor tblBillPoslovniProstor { get; set; }

		/// <summary>
		/// Association <br/>
		/// [PK][One]tblBillPoreznaGrupa.BillPoreznaGrupaID --- [FK][Many]tblBillProduct.BillPoreznaGrupaID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<tblBillProduct> tblBillProductList { get; set; } = new List<tblBillProduct>();
		#endregion Associations

		partial void OnCreated();
	}
	#endregion dbo.tblBillPoreznaGrupa

	#region dbo.tblBillPoslovniProstor
	public partial class tblBillPoslovniProstor : EFCoreEntityBase<tblBillPoslovniProstor>
	{
		public tblBillPoslovniProstor()
		{
			OnCreated();
		}

		public tblBillPoslovniProstor(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "BigInt NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert
		/// </summary>
		public long BillPoslovniProstorID { get; set; }

		/// <summary>
		/// DbType = "BigInt NOT NULL"
		/// </summary>
		public long BillFirmaID { get; set; }

		/// <summary>
		/// DbType = "Bit NOT NULL"
		/// </summary>
		public bool IsActive { get; set; }

		/// <summary>
		/// DbType = "Int"
		/// </summary>
		public int? OznakaPoslovnogProstora { get; set; }

		/// <summary>
		/// DbType = "NVarChar(255)"
		/// </summary>
		public string Naziv { get; set; }

		/// <summary>
		/// DbType = "NVarChar(255)"
		/// </summary>
		public string Ulica { get; set; }

		/// <summary>
		/// DbType = "Int"
		/// </summary>
		public int? KucniBroj { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50)"
		/// </summary>
		public string DodatakKucnomBroju { get; set; }

		/// <summary>
		/// DbType = "VarChar(50)"
		/// </summary>
		public string PostanskiBroj { get; set; }

		/// <summary>
		/// DbType = "NVarChar(255)"
		/// </summary>
		public string Mjesto { get; set; }

		/// <summary>
		/// DbType = "NVarChar(255)"
		/// </summary>
		public string Opcina { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50)"
		/// </summary>
		public string RadnoVrijeme { get; set; }

		/// <summary>
		/// DbType = "DateTime"
		/// </summary>
		public DateTime? PocetakPrimjene { get; set; }

		/// <summary>
		/// DbType = "DateTime"
		/// </summary>
		public DateTime? KrajPrimjene { get; set; }

		/// <summary>
		/// DbType = "DateTime"
		/// </summary>
		public DateTime? DatumPrijavePoreznoj { get; set; }

		/// <summary>
		/// DbType = "DateTime"
		/// </summary>
		public DateTime? DatumOdjavePoreznoj { get; set; }

		/// <summary>
		/// DbType = "NVarChar(500)"
		/// </summary>
		public string Napomena { get; set; }

		#endregion Columns

		#region Associations

		/// <summary>
		/// Association <br/>
		/// [PK][One]tblBillPoslovniProstor.BillPoslovniProstorID --- [FK][Many]tblBillCategory.BillPoslovniProstorID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<tblBillCategory> tblBillCategoryList { get; set; } = new List<tblBillCategory>();

		/// <summary>
		/// Association <br/>
		/// [PK][One]tblBillPoslovniProstor.BillPoslovniProstorID --- [FK][Many]tblBillNaplatniUredjaj.BillPoslovniProstorID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<tblBillNaplatniUredjaj> tblBillNaplatniUredjajList { get; set; } = new List<tblBillNaplatniUredjaj>();

		/// <summary>
		/// Association <br/>
		/// [PK][One]tblBillPoslovniProstor.BillPoslovniProstorID --- [FK][Many]tblBillPoreznaGrupa.BillPoslovniProstorID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<tblBillPoreznaGrupa> tblBillPoreznaGrupaList { get; set; } = new List<tblBillPoreznaGrupa>();

		/// <summary>
		/// Association <br/>
		/// [FK][Many]tblBillPoslovniProstor.BillFirmaID --- [PK][One]tblBillFirma.BillFirmaID <br/>
		/// </summary>
		public virtual tblBillFirma tblBillFirma { get; set; }

		/// <summary>
		/// Association <br/>
		/// [PK][One]tblBillPoslovniProstor.BillPoslovniProstorID --- [FK][Many]tblBillProduct.BillPoslovniProstorID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<tblBillProduct> tblBillProductList { get; set; } = new List<tblBillProduct>();
		#endregion Associations

		partial void OnCreated();
	}
	#endregion dbo.tblBillPoslovniProstor

	#region dbo.tblBillPrintLog
	public partial class tblBillPrintLog : EFCoreEntityBase<tblBillPrintLog>
	{
		public tblBillPrintLog()
		{
			OnCreated();
		}

		public tblBillPrintLog(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "BigInt NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert
		/// </summary>
		public long BillPrintLogID { get; set; }

		/// <summary>
		/// DbType = "BigInt NOT NULL"
		/// </summary>
		public long AppMemberID { get; set; }

		/// <summary>
		/// DbType = "DateTime"
		/// </summary>
		public DateTime? InsertedDate { get; set; }

		/// <summary>
		/// DbType = "Image"
		/// </summary>
		public byte[] PdfBijeliPapir { get; set; }

		/// <summary>
		/// DbType = "Image"
		/// </summary>
		public byte[] PdfOpcaUplatnica { get; set; }

		/// <summary>
		/// DbType = "Image"
		/// </summary>
		public byte[] PdfMemoUplatnica { get; set; }

		/// <summary>
		/// DbType = "NText"
		/// </summary>
		public string TextLog { get; set; }

		#endregion Columns

		#region Associations

		/// <summary>
		/// Association <br/>
		/// [FK][Many]tblBillPrintLog.AppMemberID --- [PK][One]tblAppMember.AppMemberID <br/>
		/// </summary>
		public virtual tblAppMember tblAppMember { get; set; }
		#endregion Associations

		partial void OnCreated();
	}
	#endregion dbo.tblBillPrintLog

	#region dbo.tblBillProduct
	public partial class tblBillProduct : EFCoreEntityBase<tblBillProduct>
	{
		public tblBillProduct()
		{
			OnCreated();
		}

		public tblBillProduct(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "BigInt NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert
		/// </summary>
		public long BillProductID { get; set; }

		/// <summary>
		/// DbType = "BigInt NOT NULL"
		/// </summary>
		public long BillPoslovniProstorID { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50) NOT NULL"
		/// </summary>
		public string Naziv { get; set; }

		/// <summary>
		/// DbType = "NVarChar(250)"
		/// </summary>
		public string Opis { get; set; }

		/// <summary>
		/// DbType = "VarChar(50)"
		/// </summary>
		public string Barcode { get; set; }

		/// <summary>
		/// DbType = "Money NOT NULL"
		/// </summary>
		public decimal JedinicnaCijena { get; set; }

		/// <summary>
		/// DbType = "Bit NOT NULL"
		/// </summary>
		public bool CijenaJeMPC { get; set; }

		/// <summary>
		/// DbType = "Int NOT NULL"
		/// </summary>
		public int BillMjeraID { get; set; }

		/// <summary>
		/// DbType = "Int NOT NULL"
		/// </summary>
		public int Ordinal { get; set; }

		/// <summary>
		/// DbType = "Bit NOT NULL"
		/// </summary>
		public bool IsArtikl { get; set; }

		/// <summary>
		/// DbType = "Bit NOT NULL"
		/// </summary>
		public bool IsNormativ { get; set; }

		/// <summary>
		/// DbType = "BigInt NOT NULL"
		/// </summary>
		public long BillPoreznaGrupaID { get; set; }

		/// <summary>
		/// DbType = "Money"
		/// </summary>
		public decimal? CijenaNakonRoka { get; set; }

		/// <summary>
		/// DbType = "Int"
		/// </summary>
		public int? BillUslugaTipID { get; set; }

		#endregion Columns

		#region Associations

		/// <summary>
		/// Association <br/>
		/// [PK][One]tblBillProduct.BillProductID --- [FK][Many]tblBillDocumentStavka.BillProductID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<tblBillDocumentStavka> tblBillDocumentStavkaList { get; set; } = new List<tblBillDocumentStavka>();

		/// <summary>
		/// Association <br/>
		/// [FK][Many]tblBillProduct.BillMjeraID --- [PK][One]tblBillMjera.BillMjeraID <br/>
		/// </summary>
		public virtual tblBillMjera tblBillMjera { get; set; }

		/// <summary>
		/// Association <br/>
		/// [FK][Many]tblBillProduct.BillPoreznaGrupaID --- [PK][One]tblBillPoreznaGrupa.BillPoreznaGrupaID <br/>
		/// </summary>
		public virtual tblBillPoreznaGrupa tblBillPoreznaGrupa { get; set; }

		/// <summary>
		/// Association <br/>
		/// [FK][Many]tblBillProduct.BillPoslovniProstorID --- [PK][One]tblBillPoslovniProstor.BillPoslovniProstorID <br/>
		/// </summary>
		public virtual tblBillPoslovniProstor tblBillPoslovniProstor { get; set; }

		/// <summary>
		/// Association <br/>
		/// [FK][Many]tblBillProduct.BillUslugaTipID --- [PK][One]tblBillUslugaTip.BillUslugaTipID <br/>
		/// </summary>
		public virtual tblBillUslugaTip tblBillUslugaTip { get; set; }

		/// <summary>
		/// Association <br/>
		/// [PK][One]tblBillProduct.BillProductID --- [FK][Many]tblBillProductCategory.BillProductID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<tblBillProductCategory> tblBillProductCategoryList { get; set; } = new List<tblBillProductCategory>();

		/// <summary>
		/// Association <br/>
		/// [PK][One]tblBillProduct.BillProductID --- [FK][Many]tblBillProductNormativ.ArtiklBillProductID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<tblBillProductNormativ> tblBillProductNormativList { get; set; } = new List<tblBillProductNormativ>();

		/// <summary>
		/// Association <br/>
		/// [PK][One]tblBillProduct.BillProductID --- [FK][Many]tblBillProductNormativ.NormativBillProductID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<tblBillProductNormativ> BillProductList { get; set; } = new List<tblBillProductNormativ>();
		#endregion Associations

		partial void OnCreated();
	}
	#endregion dbo.tblBillProduct

	#region dbo.tblBillProductCategory
	public partial class tblBillProductCategory : EFCoreEntityBase<tblBillProductCategory>
	{
		public tblBillProductCategory()
		{
			OnCreated();
		}

		public tblBillProductCategory(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "BigInt NOT NULL", IsPrimaryKey = true
		/// </summary>
		public long BillProductID { get; set; }

		/// <summary>
		/// DbType = "BigInt NOT NULL", IsPrimaryKey = true
		/// </summary>
		public long BillCategoryID { get; set; }

		#endregion Columns

		#region Associations

		/// <summary>
		/// Association <br/>
		/// [FK][Many]tblBillProductCategory.BillCategoryID --- [PK][One]tblBillCategory.BillCategoryID <br/>
		/// </summary>
		public virtual tblBillCategory tblBillCategory { get; set; }

		/// <summary>
		/// Association <br/>
		/// [FK][Many]tblBillProductCategory.BillProductID --- [PK][One]tblBillProduct.BillProductID <br/>
		/// </summary>
		public virtual tblBillProduct tblBillProduct { get; set; }
		#endregion Associations

		partial void OnCreated();
	}
	#endregion dbo.tblBillProductCategory

	#region dbo.tblBillProductNormativ
	public partial class tblBillProductNormativ : EFCoreEntityBase<tblBillProductNormativ>
	{
		public tblBillProductNormativ()
		{
			OnCreated();
		}

		public tblBillProductNormativ(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "BigInt NOT NULL", IsPrimaryKey = true
		/// </summary>
		public long ArtiklBillProductID { get; set; }

		/// <summary>
		/// DbType = "BigInt NOT NULL", IsPrimaryKey = true
		/// </summary>
		public long NormativBillProductID { get; set; }

		/// <summary>
		/// DbType = "Decimal(18,8) NOT NULL"
		/// </summary>
		public decimal Kolicina { get; set; }

		/// <summary>
		/// DbType = "NVarChar(250)"
		/// </summary>
		public string Opis { get; set; }

		#endregion Columns

		#region Associations

		/// <summary>
		/// Association <br/>
		/// [FK][Many]tblBillProductNormativ.ArtiklBillProductID --- [PK][One]tblBillProduct.BillProductID <br/>
		/// </summary>
		public virtual tblBillProduct tblBillProduct { get; set; }

		/// <summary>
		/// Association <br/>
		/// [FK][Many]tblBillProductNormativ.NormativBillProductID --- [PK][One]tblBillProduct.BillProductID <br/>
		/// </summary>
		public virtual tblBillProduct NormativBillProduct { get; set; }
		#endregion Associations

		partial void OnCreated();
	}
	#endregion dbo.tblBillProductNormativ

	#region dbo.tblBillUslugaTip
	public partial class tblBillUslugaTip : EFCoreEntityBase<tblBillUslugaTip>
	{
		public tblBillUslugaTip()
		{
			OnCreated();
		}

		public tblBillUslugaTip(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "Int NOT NULL", IsPrimaryKey = true
		/// </summary>
		public int BillUslugaTipID { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50) NOT NULL"
		/// </summary>
		public string Naziv { get; set; }

		#endregion Columns

		#region Associations

		/// <summary>
		/// Association <br/>
		/// [PK][One]tblBillUslugaTip.BillUslugaTipID --- [FK][Many]tblBillProduct.BillUslugaTipID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<tblBillProduct> tblBillProductList { get; set; } = new List<tblBillProduct>();

		/// <summary>
		/// Association <br/>
		/// [PK][One]tblBillUslugaTip.BillUslugaTipID --- [FK][Many]tblDirClientGratis.BillUslugaTipID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<tblDirClientGratis> tblDirClientGratisList { get; set; } = new List<tblDirClientGratis>();
		#endregion Associations

		partial void OnCreated();
	}
	#endregion dbo.tblBillUslugaTip

	#region dbo.tblBookkeepingFiduciaExport
	public partial class tblBookkeepingFiduciaExport : EFCoreEntityBase<tblBookkeepingFiduciaExport>
	{
		public tblBookkeepingFiduciaExport()
		{
			OnCreated();
		}

		public tblBookkeepingFiduciaExport(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "BigInt NOT NULL IDENTITY", IsDbGenerated = true, AutoSync = AutoSync.Always
		/// </summary>
		public long FiduciaExportID { get; set; }

		/// <summary>
		/// DbType = "DateTime NOT NULL", DefaultValue = /*getdate()*/ DateTime.Now
		/// </summary>
		public DateTime DatumGeneriranja { get; set; } = /*getdate()*/ DateTime.Now;

		/// <summary>
		/// DbType = "BigInt NOT NULL", IsPrimaryKey = true
		/// </summary>
		public long BillFirmaID { get; set; }

		/// <summary>
		/// DbType = "DateTime NOT NULL", IsPrimaryKey = true
		/// </summary>
		public DateTime StartDateIncluded { get; set; }

		/// <summary>
		/// DbType = "DateTime NOT NULL", IsPrimaryKey = true
		/// </summary>
		public DateTime EndDateExcluded { get; set; }

		/// <summary>
		/// DbType = "Image"
		/// </summary>
		public byte[] AllData { get; set; }

		/// <summary>
		/// DbType = "Image"
		/// </summary>
		public byte[] Klijenti { get; set; }

		/// <summary>
		/// DbType = "Image"
		/// </summary>
		public byte[] RacuniKonta { get; set; }

		/// <summary>
		/// DbType = "Image"
		/// </summary>
		public byte[] RacuniKnjiga { get; set; }

		/// <summary>
		/// DbType = "Image"
		/// </summary>
		public byte[] Preknjizenja { get; set; }

		#endregion Columns

		#region Associations

		/// <summary>
		/// Association <br/>
		/// [FK][Many]tblBookkeepingFiduciaExport.BillFirmaID --- [PK][One]tblBillFirma.BillFirmaID <br/>
		/// </summary>
		public virtual tblBillFirma tblBillFirma { get; set; }
		#endregion Associations

		partial void OnCreated();
	}
	#endregion dbo.tblBookkeepingFiduciaExport

	#region dbo.tblBookkeepingSynesisExport
	public partial class tblBookkeepingSynesisExport : EFCoreEntityBase<tblBookkeepingSynesisExport>
	{
		public tblBookkeepingSynesisExport()
		{
			OnCreated();
		}

		public tblBookkeepingSynesisExport(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "BigInt NOT NULL IDENTITY", IsDbGenerated = true, AutoSync = AutoSync.Always
		/// </summary>
		public long SynesisExportID { get; set; }

		/// <summary>
		/// DbType = "DateTime NOT NULL"
		/// </summary>
		public DateTime DatumGeneriranja { get; set; }

		/// <summary>
		/// DbType = "BigInt NOT NULL", IsPrimaryKey = true
		/// </summary>
		public long BillFirmaID { get; set; }

		/// <summary>
		/// DbType = "DateTime NOT NULL", IsPrimaryKey = true
		/// </summary>
		public DateTime StartDateIncluded { get; set; }

		/// <summary>
		/// DbType = "DateTime NOT NULL", IsPrimaryKey = true
		/// </summary>
		public DateTime EndDateExcluded { get; set; }

		/// <summary>
		/// DbType = "Image"
		/// </summary>
		public byte[] AllData { get; set; }

		/// <summary>
		/// DbType = "Image"
		/// </summary>
		public byte[] Klijenti { get; set; }

		/// <summary>
		/// DbType = "Image"
		/// </summary>
		public byte[] FinancKnjig { get; set; }

		/// <summary>
		/// DbType = "Image"
		/// </summary>
		public byte[] UlazniRacuni { get; set; }

		/// <summary>
		/// DbType = "Image"
		/// </summary>
		public byte[] IzlazniRacuni { get; set; }

		#endregion Columns

		#region Associations

		/// <summary>
		/// Association <br/>
		/// [FK][Many]tblBookkeepingSynesisExport.BillFirmaID --- [PK][One]tblBillFirma.BillFirmaID <br/>
		/// </summary>
		public virtual tblBillFirma tblBillFirma { get; set; }
		#endregion Associations

		partial void OnCreated();
	}
	#endregion dbo.tblBookkeepingSynesisExport

	#region dbo.tblDirClient
	public partial class tblDirClient : EFCoreEntityBase<tblDirClient>
	{
		public tblDirClient()
		{
			OnCreated();
		}

		public tblDirClient(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "BigInt NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert
		/// </summary>
		public long DirClientID { get; set; }

		/// <summary>
		/// DbType = "Int"
		/// </summary>
		public int? DirClientSourceID { get; set; }

		/// <summary>
		/// DbType = "VarChar(20)"
		/// </summary>
		public string MaticniBroj { get; set; }

		/// <summary>
		/// DbType = "VarChar(20)"
		/// </summary>
		public string PorezniBroj { get; set; }

		/// <summary>
		/// DbType = "DateTime"
		/// </summary>
		public DateTime? datumObjave { get; set; }

		/// <summary>
		/// DbType = "DateTime"
		/// </summary>
		public DateTime? datumOsnivanja { get; set; }

		/// <summary>
		/// DbType = "DateTime"
		/// </summary>
		public DateTime? datumZatvaranja { get; set; }

		/// <summary>
		/// DbType = "DateTime"
		/// </summary>
		public DateTime? insertionDate { get; set; }

		/// <summary>
		/// DbType = "NVarChar(250)"
		/// </summary>
		public string Naziv { get; set; }

		/// <summary>
		/// DbType = "NVarChar(250)"
		/// </summary>
		public string Adresa { get; set; }

		/// <summary>
		/// DbType = "NVarChar(250)"
		/// </summary>
		public string Naselje { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50)"
		/// </summary>
		public string PostanskiBroj { get; set; }

		/// <summary>
		/// DbType = "NVarChar(200)"
		/// </summary>
		public string PostanskiUred { get; set; }

		/// <summary>
		/// DbType = "NVarChar(200)"
		/// </summary>
		public string Provincia { get; set; }

		/// <summary>
		/// DbType = "NVarChar(500)"
		/// </summary>
		public string Web { get; set; }

		/// <summary>
		/// DbType = "NVarChar(200)"
		/// </summary>
		public string Email { get; set; }

		/// <summary>
		/// DbType = "VarChar(20)"
		/// </summary>
		public string Telefon1 { get; set; }

		/// <summary>
		/// DbType = "VarChar(20)"
		/// </summary>
		public string Telefon2 { get; set; }

		/// <summary>
		/// DbType = "Int"
		/// </summary>
		public int? NkdRowID { get; set; }

		/// <summary>
		/// DbType = "NVarChar(500)"
		/// </summary>
		public string KljucneRijeci { get; set; }

		/// <summary>
		/// DbType = "NVarChar(MAX)"
		/// </summary>
		public string Opis { get; set; }

		/// <summary>
		/// DbType = "NVarChar(500)"
		/// </summary>
		public string RadnoVrijeme { get; set; }

		/// <summary>
		/// DbType = "NVarChar(250)"
		/// </summary>
		public string odgovornaOsoba { get; set; }

		/// <summary>
		/// DbType = "Bit"
		/// </summary>
		public bool? isVlasnik { get; set; }

		/// <summary>
		/// DbType = "NVarChar(500)"
		/// </summary>
		public string FormattedAddress { get; set; }

		/// <summary>
		/// DbType = "VarChar(100)"
		/// </summary>
		public string LocationType { get; set; }

		/// <summary>
		/// DbType = "Decimal(18,10)"
		/// </summary>
		public decimal? Latitude { get; set; }

		/// <summary>
		/// DbType = "Decimal(18,10)"
		/// </summary>
		public decimal? Longitude { get; set; }

		/// <summary>
		/// DbType = "VarChar(50)"
		/// </summary>
		public string LocationStatus { get; set; }

		/// <summary>
		/// DbType = "DateTime"
		/// </summary>
		public DateTime? LastModifiedDate { get; set; }

		/// <summary>
		/// DbType = "Bit NOT NULL", DefaultValue = true
		/// </summary>
		public bool IsClientVisible { get; set; } = true;

		#endregion Columns

		#region Associations

		/// <summary>
		/// Association <br/>
		/// [PK][One]tblDirClient.DirClientID --- [FK][Many]tblBillClient.DirClientID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<tblBillClient> tblBillClientList { get; set; } = new List<tblBillClient>();

		/// <summary>
		/// Association <br/>
		/// [FK][Many]tblDirClient.DirClientSourceID --- [PK][One]tblDirClientSource.DirClientSourceID <br/>
		/// </summary>
		public virtual tblDirClientSource tblDirClientSource { get; set; }

		/// <summary>
		/// Association <br/>
		/// [PK][One]tblDirClient.DirClientID --- [FK][One]tblDirClientFullText.DirClientID <br/>
		/// DeleteRule = Cascade <br/>
		/// </summary>
		public virtual tblDirClientFullText tblDirClientFullText { get; set; }

		/// <summary>
		/// Association <br/>
		/// [PK][One]tblDirClient.DirClientID --- [FK][One]tblDirClientGratis.DirClientID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual tblDirClientGratis tblDirClientGratis { get; set; }

		/// <summary>
		/// Association <br/>
		/// [PK][One]tblDirClient.DirClientID --- [FK][Many]tblDirClientPicture.DirClientID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<tblDirClientPicture> tblDirClientPictureList { get; set; } = new List<tblDirClientPicture>();

		/// <summary>
		/// Association <br/>
		/// [PK][One]tblDirClient.DirClientID --- [FK][One]tblDirClientPrikazStatus.DirClientID <br/>
		/// DeleteRule = Cascade <br/>
		/// </summary>
		public virtual tblDirClientPrikazStatus tblDirClientPrikazStatus { get; set; }

		/// <summary>
		/// Association <br/>
		/// [PK][One]tblDirClient.DirClientID --- [FK][Many]tblSocialMember.DirClientID <br/>
		/// DeleteRule = Cascade <br/>
		/// </summary>
		public virtual List<tblSocialMember> tblSocialMemberList { get; set; } = new List<tblSocialMember>();
		#endregion Associations

		partial void OnCreated();
	}
	#endregion dbo.tblDirClient

	#region dbo.tblDirClientBlacklist
	public partial class tblDirClientBlacklist : EFCoreEntityBase<tblDirClientBlacklist>
	{
		public tblDirClientBlacklist()
		{
			OnCreated();
		}

		public tblDirClientBlacklist(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "VarChar(20) NOT NULL", IsPrimaryKey = true
		/// </summary>
		public string PorezniBroj { get; set; }

		/// <summary>
		/// DbType = "VarChar(20)"
		/// </summary>
		public string MaticniBroj { get; set; }

		/// <summary>
		/// DbType = "BigInt NOT NULL"
		/// </summary>
		public long BillFirmaID { get; set; }

		/// <summary>
		/// DbType = "DateTime NOT NULL", DefaultValue = /*getdate()*/ DateTime.Now
		/// </summary>
		public DateTime InsertionDate { get; set; } = /*getdate()*/ DateTime.Now;

		/// <summary>
		/// DbType = "NVarChar(500)"
		/// </summary>
		public string Napomena { get; set; }

		/// <summary>
		/// DbType = "BigInt NOT NULL"
		/// </summary>
		public long AppMemberID { get; set; }

		#endregion Columns

		#region Associations

		/// <summary>
		/// Association <br/>
		/// [FK][Many]tblDirClientBlacklist.AppMemberID --- [PK][One]tblAppMember.AppMemberID <br/>
		/// </summary>
		public virtual tblAppMember tblAppMember { get; set; }

		/// <summary>
		/// Association <br/>
		/// [FK][Many]tblDirClientBlacklist.BillFirmaID --- [PK][One]tblBillFirma.BillFirmaID <br/>
		/// </summary>
		public virtual tblBillFirma tblBillFirma { get; set; }
		#endregion Associations

		partial void OnCreated();
	}
	#endregion dbo.tblDirClientBlacklist

	#region dbo.tblDirClientFullText
	public partial class tblDirClientFullText : EFCoreEntityBase<tblDirClientFullText>
	{
		public tblDirClientFullText()
		{
			OnCreated();
		}

		public tblDirClientFullText(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "BigInt NOT NULL", IsPrimaryKey = true
		/// </summary>
		public long DirClientID { get; set; }

		/// <summary>
		/// DbType = "NVarChar(MAX)"
		/// </summary>
		public string fullTextIndexBasic { get; set; }

		/// <summary>
		/// DbType = "NVarChar(MAX)"
		/// </summary>
		public string fullTextIndexFull { get; set; }

		#endregion Columns

		#region Associations

		/// <summary>
		/// Association <br/>
		/// [FK][One]tblDirClientFullText.DirClientID --- [PK][One]tblDirClient.DirClientID <br/>
		/// DeleteOnNull = true <br/>
		/// </summary>
		public virtual tblDirClient tblDirClient { get; set; }
		#endregion Associations

		partial void OnCreated();
	}
	#endregion dbo.tblDirClientFullText

	#region dbo.tblDirClientGratis
	public partial class tblDirClientGratis : EFCoreEntityBase<tblDirClientGratis>
	{
		public tblDirClientGratis()
		{
			OnCreated();
		}

		public tblDirClientGratis(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "BigInt NOT NULL", IsPrimaryKey = true
		/// </summary>
		public long DirClientID { get; set; }

		/// <summary>
		/// DbType = "Int"
		/// </summary>
		public int? BillUslugaTipID { get; set; }

		/// <summary>
		/// DbType = "Int NOT NULL"
		/// </summary>
		public int PrikazStatus { get; set; }

		/// <summary>
		/// DbType = "DateTime"
		/// </summary>
		public DateTime? StartDate { get; set; }

		/// <summary>
		/// DbType = "DateTime"
		/// </summary>
		public DateTime? EndDate { get; set; }

		#endregion Columns

		#region Associations

		/// <summary>
		/// Association <br/>
		/// [FK][Many]tblDirClientGratis.BillUslugaTipID --- [PK][One]tblBillUslugaTip.BillUslugaTipID <br/>
		/// </summary>
		public virtual tblBillUslugaTip tblBillUslugaTip { get; set; }

		/// <summary>
		/// Association <br/>
		/// [FK][One]tblDirClientGratis.DirClientID --- [PK][One]tblDirClient.DirClientID <br/>
		/// </summary>
		public virtual tblDirClient tblDirClient { get; set; }
		#endregion Associations

		partial void OnCreated();
	}
	#endregion dbo.tblDirClientGratis

	#region dbo.tblDirClientPicture
	public partial class tblDirClientPicture : EFCoreEntityBase<tblDirClientPicture>
	{
		public tblDirClientPicture()
		{
			OnCreated();
		}

		public tblDirClientPicture(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "BigInt NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert
		/// </summary>
		public long DirClientPictureID { get; set; }

		/// <summary>
		/// DbType = "BigInt NOT NULL"
		/// </summary>
		public long DirClientID { get; set; }

		/// <summary>
		/// DbType = "DateTime NOT NULL", DefaultValue = /*getdate()*/ DateTime.Now
		/// </summary>
		public DateTime InsertionDate { get; set; } = /*getdate()*/ DateTime.Now;

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

		/// <summary>
		/// DbType = "Bit"
		/// </summary>
		public bool? IsNaslovna { get; set; }

		/// <summary>
		/// DbType = "Bit"
		/// </summary>
		public bool? IsLogo { get; set; }

		#endregion Columns

		#region Associations

		/// <summary>
		/// Association <br/>
		/// [FK][Many]tblDirClientPicture.DirClientID --- [PK][One]tblDirClient.DirClientID <br/>
		/// </summary>
		public virtual tblDirClient tblDirClient { get; set; }
		#endregion Associations

		partial void OnCreated();
	}
	#endregion dbo.tblDirClientPicture

	#region dbo.tblDirClientPrikazStatus
	public partial class tblDirClientPrikazStatus : EFCoreEntityBase<tblDirClientPrikazStatus>
	{
		public tblDirClientPrikazStatus()
		{
			OnCreated();
		}

		public tblDirClientPrikazStatus(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "BigInt NOT NULL", IsPrimaryKey = true
		/// </summary>
		public long DirClientID { get; set; }

		/// <summary>
		/// DbType = "Int NOT NULL"
		/// </summary>
		public int PrikazStatus { get; set; }

		/// <summary>
		/// DbType = "DateTime"
		/// </summary>
		public DateTime? StartDate { get; set; }

		/// <summary>
		/// DbType = "DateTime"
		/// </summary>
		public DateTime? EndDate { get; set; }

		#endregion Columns

		#region Associations

		/// <summary>
		/// Association <br/>
		/// [FK][One]tblDirClientPrikazStatus.DirClientID --- [PK][One]tblDirClient.DirClientID <br/>
		/// DeleteOnNull = true <br/>
		/// </summary>
		public virtual tblDirClient tblDirClient { get; set; }
		#endregion Associations

		partial void OnCreated();
	}
	#endregion dbo.tblDirClientPrikazStatus

	#region dbo.tblDirClientSource
	public partial class tblDirClientSource : EFCoreEntityBase<tblDirClientSource>
	{
		public tblDirClientSource()
		{
			OnCreated();
		}

		public tblDirClientSource(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "Int NOT NULL", IsPrimaryKey = true
		/// </summary>
		public int DirClientSourceID { get; set; }

		/// <summary>
		/// DbType = "Bit NOT NULL", DefaultValue = false
		/// </summary>
		public bool IsWebVisible { get; set; } = false;

		/// <summary>
		/// DbType = "NVarChar(500)"
		/// </summary>
		public string Name { get; set; }

		#endregion Columns

		#region Associations

		/// <summary>
		/// Association <br/>
		/// [PK][One]tblDirClientSource.DirClientSourceID --- [FK][Many]tblDirClient.DirClientSourceID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<tblDirClient> tblDirClientList { get; set; } = new List<tblDirClient>();
		#endregion Associations

		partial void OnCreated();
	}
	#endregion dbo.tblDirClientSource

	#region dbo.tblDirClientVracenaPosta
	public partial class tblDirClientVracenaPosta : EFCoreEntityBase<tblDirClientVracenaPosta>
	{
		public tblDirClientVracenaPosta()
		{
			OnCreated();
		}

		public tblDirClientVracenaPosta(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "VarChar(20)"
		/// </summary>
		public string PorezniBroj { get; set; }

		/// <summary>
		/// DbType = "VarChar(20)"
		/// </summary>
		public string MaticniBroj { get; set; }

		/// <summary>
		/// DbType = "BigInt NOT NULL"
		/// </summary>
		public long BillFirmaID { get; set; }

		/// <summary>
		/// DbType = "DateTime NOT NULL"
		/// </summary>
		public DateTime InsertionDate { get; set; }

		/// <summary>
		/// DbType = "NVarChar(500)"
		/// </summary>
		public string Napomena { get; set; }

		/// <summary>
		/// DbType = "BigInt NOT NULL"
		/// </summary>
		public long AppMemberID { get; set; }

		#endregion Columns

		#region Associations
		#endregion Associations

		partial void OnCreated();
	}
	#endregion dbo.tblDirClientVracenaPosta

	#region dbo.tblDirNkd2007
	public partial class tblDirNkd2007 : EFCoreEntityBase<tblDirNkd2007>
	{
		public tblDirNkd2007()
		{
			OnCreated();
		}

		public tblDirNkd2007(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "Int NOT NULL", IsPrimaryKey = true
		/// </summary>
		public int NkdRowID { get; set; }

		/// <summary>
		/// DbType = "Int"
		/// </summary>
		public int? ParentNkdRowID { get; set; }

		/// <summary>
		/// DbType = "DateTime"
		/// </summary>
		public DateTime? InsertionDate { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50)"
		/// </summary>
		public string Podrucje { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50)"
		/// </summary>
		public string Odjeljak { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50)"
		/// </summary>
		public string Skupina { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50)"
		/// </summary>
		public string Razred { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50)"
		/// </summary>
		public string SimpleRazred { get; set; }

		/// <summary>
		/// DbType = "NVarChar(500)"
		/// </summary>
		public string NkdDjelatnostNaziv { get; set; }

		/// <summary>
		/// DbType = "NVarChar(500)"
		/// </summary>
		public string NkdKljucneRijeci { get; set; }

		/// <summary>
		/// DbType = "VarChar(20)"
		/// </summary>
		public string Nkd2007Sifra { get; set; }

		/// <summary>
		/// DbType = "NVarChar(MAX)"
		/// </summary>
		public string DescriptionLines { get; set; }

		/// <summary>
		/// DbType = "DateTime"
		/// </summary>
		public DateTime? LastModifiedDate { get; set; }

		#endregion Columns

		#region Associations

		/// <summary>
		/// Association <br/>
		/// [FK][Many]tblDirNkd2007.ParentNkdRowID --- [PK][One]tblDirNkd2007.NkdRowID <br/>
		/// </summary>
		public virtual tblDirNkd2007 ParentNkdRow { get; set; }

		/// <summary>
		/// Association <br/>
		/// [PK][One]tblDirNkd2007.NkdRowID --- [FK][Many]tblDirNkd2007.ParentNkdRowID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<tblDirNkd2007> NkdRowList { get; set; } = new List<tblDirNkd2007>();
		#endregion Associations

		partial void OnCreated();
	}
	#endregion dbo.tblDirNkd2007

	#region dbo.tblDirPrikazStatus
	public partial class tblDirPrikazStatus : EFCoreEntityBase<tblDirPrikazStatus>
	{
		public tblDirPrikazStatus()
		{
			OnCreated();
		}

		public tblDirPrikazStatus(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "Int NOT NULL"
		/// </summary>
		public int PrikazStatus { get; set; }

		/// <summary>
		/// DbType = "NVarChar(500)"
		/// </summary>
		public string Description { get; set; }

		#endregion Columns

		#region Associations
		#endregion Associations

		partial void OnCreated();
	}
	#endregion dbo.tblDirPrikazStatus

	#region dbo.tblDirRegistration
	public partial class tblDirRegistration : EFCoreEntityBase<tblDirRegistration>
	{
		public tblDirRegistration()
		{
			OnCreated();
		}

		public tblDirRegistration(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "BigInt NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert
		/// </summary>
		public long DirRegistrationID { get; set; }

		/// <summary>
		/// DbType = "VarChar(50) NOT NULL"
		/// </summary>
		public string IP { get; set; }

		/// <summary>
		/// DbType = "DateTime NOT NULL"
		/// </summary>
		public DateTime InsertionDate { get; set; }

		/// <summary>
		/// DbType = "DateTime"
		/// </summary>
		public DateTime? ProcessedDate { get; set; }

		/// <summary>
		/// DbType = "VarChar(20) NOT NULL"
		/// </summary>
		public string PorezniBroj { get; set; }

		/// <summary>
		/// DbType = "NVarChar(255) NOT NULL"
		/// </summary>
		public string Naziv { get; set; }

		/// <summary>
		/// DbType = "NVarChar(255) NOT NULL"
		/// </summary>
		public string Adresa { get; set; }

		/// <summary>
		/// DbType = "VarChar(10) NOT NULL"
		/// </summary>
		public string PostanskiBroj { get; set; }

		/// <summary>
		/// DbType = "NVarChar(100) NOT NULL"
		/// </summary>
		public string PostanskiUred { get; set; }

		/// <summary>
		/// DbType = "VarChar(150) NOT NULL"
		/// </summary>
		public string Email { get; set; }

		/// <summary>
		/// DbType = "VarChar(255) NOT NULL"
		/// </summary>
		public string WebSite { get; set; }

		/// <summary>
		/// DbType = "VarChar(20) NOT NULL"
		/// </summary>
		public string Telefon { get; set; }

		/// <summary>
		/// DbType = "VarChar(20) NOT NULL"
		/// </summary>
		public string Mobitel { get; set; }

		#endregion Columns

		#region Associations
		#endregion Associations

		partial void OnCreated();
	}
	#endregion dbo.tblDirRegistration

	#region dbo.tblFiskalRacunZahtjevLog
	public partial class tblFiskalRacunZahtjevLog : EFCoreEntityBase<tblFiskalRacunZahtjevLog>
	{
		public tblFiskalRacunZahtjevLog()
		{
			OnCreated();
		}

		public tblFiskalRacunZahtjevLog(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "BigInt NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert
		/// </summary>
		public long FiskalRacunZahtjevLogID { get; set; }

		/// <summary>
		/// DbType = "BigInt NOT NULL"
		/// </summary>
		public long AppMemberID { get; set; }

		/// <summary>
		/// DbType = "Bit"
		/// </summary>
		public bool? IsProdukcija { get; set; }

		/// <summary>
		/// DbType = "BigInt NOT NULL"
		/// </summary>
		public long BillDocumentID { get; set; }

		/// <summary>
		/// DbType = "DateTime NOT NULL"
		/// </summary>
		public DateTime InsertionDate { get; set; }

		/// <summary>
		/// DbType = "VarChar(50) NOT NULL"
		/// </summary>
		public string FiskalniBrojRacuna { get; set; }

		/// <summary>
		/// DbType = "VarChar(15)"
		/// </summary>
		public string OIBOperatora { get; set; }

		/// <summary>
		/// DbType = "Bit"
		/// </summary>
		public bool? IsInPdvSustav { get; set; }

		/// <summary>
		/// DbType = "DateTime"
		/// </summary>
		public DateTime? DatumDokumenta { get; set; }

		/// <summary>
		/// DbType = "Money NOT NULL"
		/// </summary>
		public decimal PoreznaOsnovica { get; set; }

		/// <summary>
		/// DbType = "Money NOT NULL"
		/// </summary>
		public decimal IznosPdva { get; set; }

		/// <summary>
		/// DbType = "Money NOT NULL"
		/// </summary>
		public decimal IznosPorezPotrosnja { get; set; }

		/// <summary>
		/// DbType = "Money NOT NULL"
		/// </summary>
		public decimal SveukupniIznos { get; set; }

		/// <summary>
		/// DbType = "VarChar(100)"
		/// </summary>
		public string ZKI { get; set; }

		/// <summary>
		/// DbType = "VarChar(100)"
		/// </summary>
		public string OdgovorJIR { get; set; }

		/// <summary>
		/// DbType = "VarChar(MAX)"
		/// </summary>
		public string OdgovorOpisGreske { get; set; }

		#endregion Columns

		#region Associations

		/// <summary>
		/// Association <br/>
		/// [FK][Many]tblFiskalRacunZahtjevLog.AppMemberID --- [PK][One]tblAppMember.AppMemberID <br/>
		/// </summary>
		public virtual tblAppMember tblAppMember { get; set; }

		/// <summary>
		/// Association <br/>
		/// [FK][Many]tblFiskalRacunZahtjevLog.BillDocumentID --- [PK][One]tblBillDocument.BillDocumentID <br/>
		/// </summary>
		public virtual tblBillDocument tblBillDocument { get; set; }
		#endregion Associations

		partial void OnCreated();
	}
	#endregion dbo.tblFiskalRacunZahtjevLog

	#region dbo.tblPorezPdv
	public partial class tblPorezPdv : EFCoreEntityBase<tblPorezPdv>
	{
		public tblPorezPdv()
		{
			OnCreated();
		}

		public tblPorezPdv(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "Int NOT NULL", IsPrimaryKey = true
		/// </summary>
		public int BillPorezPdvID { get; set; }

		/// <summary>
		/// DbType = "Bit NOT NULL"
		/// </summary>
		public bool IsActive { get; set; }

		/// <summary>
		/// DbType = "Int NOT NULL"
		/// </summary>
		public int Ordinal { get; set; }

		/// <summary>
		/// DbType = "Bit NOT NULL"
		/// </summary>
		public bool IsDefault { get; set; }

		/// <summary>
		/// DbType = "NVarChar(150) NOT NULL"
		/// </summary>
		public string Naziv { get; set; }

		/// <summary>
		/// DbType = "NVarChar(250)"
		/// </summary>
		public string PrintableText { get; set; }

		/// <summary>
		/// DbType = "NVarChar(MAX)"
		/// </summary>
		public string Opis { get; set; }

		#endregion Columns

		#region Associations

		/// <summary>
		/// Association <br/>
		/// [PK][One]tblPorezPdv.BillPorezPdvID --- [FK][Many]tblPorezPdvPostotak.BillPorezPdvID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<tblPorezPdvPostotak> tblPorezPdvPostotakList { get; set; } = new List<tblPorezPdvPostotak>();
		#endregion Associations

		partial void OnCreated();
	}
	#endregion dbo.tblPorezPdv

	#region dbo.tblPorezPdvPostotak
	public partial class tblPorezPdvPostotak : EFCoreEntityBase<tblPorezPdvPostotak>
	{
		public tblPorezPdvPostotak()
		{
			OnCreated();
		}

		public tblPorezPdvPostotak(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "Int NOT NULL", IsPrimaryKey = true
		/// </summary>
		public int BillPorezPdvPostotakID { get; set; }

		/// <summary>
		/// DbType = "Int NOT NULL"
		/// </summary>
		public int BillPorezPdvID { get; set; }

		/// <summary>
		/// DbType = "Money NOT NULL"
		/// </summary>
		public decimal PdvPosto { get; set; }

		/// <summary>
		/// DbType = "DateTime NOT NULL"
		/// </summary>
		public DateTime StartDatum { get; set; }

		/// <summary>
		/// DbType = "DateTime"
		/// </summary>
		public DateTime? EndDatum { get; set; }

		#endregion Columns

		#region Associations

		/// <summary>
		/// Association <br/>
		/// [FK][Many]tblPorezPdvPostotak.BillPorezPdvID --- [PK][One]tblPorezPdv.BillPorezPdvID <br/>
		/// </summary>
		public virtual tblPorezPdv tblPorezPdv { get; set; }
		#endregion Associations

		partial void OnCreated();
	}
	#endregion dbo.tblPorezPdvPostotak

	#region dbo.tblPorezPotrosnja
	public partial class tblPorezPotrosnja : EFCoreEntityBase<tblPorezPotrosnja>
	{
		public tblPorezPotrosnja()
		{
			OnCreated();
		}

		public tblPorezPotrosnja(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "Int NOT NULL", IsPrimaryKey = true
		/// </summary>
		public int BillPorezPotrosnjaID { get; set; }

		/// <summary>
		/// DbType = "Bit NOT NULL"
		/// </summary>
		public bool IsActive { get; set; }

		/// <summary>
		/// DbType = "Int NOT NULL"
		/// </summary>
		public int Ordinal { get; set; }

		/// <summary>
		/// DbType = "Bit NOT NULL"
		/// </summary>
		public bool IsDefault { get; set; }

		/// <summary>
		/// DbType = "NVarChar(150) NOT NULL"
		/// </summary>
		public string Naziv { get; set; }

		/// <summary>
		/// DbType = "NVarChar(250) NOT NULL"
		/// </summary>
		public string PrintableText { get; set; }

		/// <summary>
		/// DbType = "NVarChar(MAX) NOT NULL"
		/// </summary>
		public string Opis { get; set; }

		#endregion Columns

		#region Associations

		/// <summary>
		/// Association <br/>
		/// [PK][One]tblPorezPotrosnja.BillPorezPotrosnjaID --- [FK][Many]tblPorezPotrosnjaPostotak.BillPorezPotrosnjaID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<tblPorezPotrosnjaPostotak> tblPorezPotrosnjaPostotakList { get; set; } = new List<tblPorezPotrosnjaPostotak>();
		#endregion Associations

		partial void OnCreated();
	}
	#endregion dbo.tblPorezPotrosnja

	#region dbo.tblPorezPotrosnjaPostotak
	public partial class tblPorezPotrosnjaPostotak : EFCoreEntityBase<tblPorezPotrosnjaPostotak>
	{
		public tblPorezPotrosnjaPostotak()
		{
			OnCreated();
		}

		public tblPorezPotrosnjaPostotak(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "Int NOT NULL", IsPrimaryKey = true
		/// </summary>
		public int BillPorezPotrosnjaPostotakID { get; set; }

		/// <summary>
		/// DbType = "Int NOT NULL"
		/// </summary>
		public int BillPorezPotrosnjaID { get; set; }

		/// <summary>
		/// DbType = "Money NOT NULL"
		/// </summary>
		public decimal PorezPosto { get; set; }

		/// <summary>
		/// DbType = "DateTime NOT NULL"
		/// </summary>
		public DateTime StartDatum { get; set; }

		/// <summary>
		/// DbType = "DateTime"
		/// </summary>
		public DateTime? EndDatum { get; set; }

		#endregion Columns

		#region Associations

		/// <summary>
		/// Association <br/>
		/// [FK][Many]tblPorezPotrosnjaPostotak.BillPorezPotrosnjaID --- [PK][One]tblPorezPotrosnja.BillPorezPotrosnjaID <br/>
		/// </summary>
		public virtual tblPorezPotrosnja tblPorezPotrosnja { get; set; }
		#endregion Associations

		partial void OnCreated();
	}
	#endregion dbo.tblPorezPotrosnjaPostotak

	#region dbo.tblSocialMember
	public partial class tblSocialMember : EFCoreEntityBase<tblSocialMember>
	{
		public tblSocialMember()
		{
			OnCreated();
		}

		public tblSocialMember(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "BigInt NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert
		/// </summary>
		public long SocialMemberID { get; set; }

		/// <summary>
		/// DbType = "Int NOT NULL"
		/// </summary>
		public int SocialProviderID { get; set; }

		/// <summary>
		/// DbType = "DateTime NOT NULL"
		/// </summary>
		public DateTime InsertionDate { get; set; }

		/// <summary>
		/// DbType = "DateTime"
		/// </summary>
		public DateTime? LastLoginDate { get; set; }

		/// <summary>
		/// DbType = "VarChar(200)"
		/// </summary>
		public string SocialId { get; set; }

		/// <summary>
		/// DbType = "NVarChar(250)"
		/// </summary>
		public string EmailAddress { get; set; }

		/// <summary>
		/// DbType = "NVarChar(100)"
		/// </summary>
		public string Password { get; set; }

		/// <summary>
		/// DbType = "DateTime"
		/// </summary>
		public DateTime? PasswordRecoverySentDate { get; set; }

		/// <summary>
		/// DbType = "DateTime"
		/// </summary>
		public DateTime? ConfirmationEmailSentDate { get; set; }

		/// <summary>
		/// DbType = "DateTime"
		/// </summary>
		public DateTime? EmailConfirmedDate { get; set; }

		/// <summary>
		/// DbType = "VarChar(20)"
		/// </summary>
		public string PhoneNumber { get; set; }

		/// <summary>
		/// DbType = "NVarChar(200)"
		/// </summary>
		public string FullName { get; set; }

		/// <summary>
		/// DbType = "NVarChar(100)"
		/// </summary>
		public string FirstName { get; set; }

		/// <summary>
		/// DbType = "NVarChar(100)"
		/// </summary>
		public string LastName { get; set; }

		/// <summary>
		/// DbType = "VarChar(500)"
		/// </summary>
		public string PictureUrl { get; set; }

		/// <summary>
		/// DbType = "Int"
		/// </summary>
		public int? SocialMemberStatusID { get; set; }

		/// <summary>
		/// DbType = "BigInt"
		/// </summary>
		public long? BillClientID { get; set; }

		/// <summary>
		/// DbType = "BigInt"
		/// </summary>
		public long? DirClientID { get; set; }

		#endregion Columns

		#region Associations

		/// <summary>
		/// Association <br/>
		/// [FK][Many]tblSocialMember.BillClientID --- [PK][One]tblBillClient.BillClientID <br/>
		/// </summary>
		public virtual tblBillClient tblBillClient { get; set; }

		/// <summary>
		/// Association <br/>
		/// [FK][Many]tblSocialMember.DirClientID --- [PK][One]tblDirClient.DirClientID <br/>
		/// </summary>
		public virtual tblDirClient tblDirClient { get; set; }

		/// <summary>
		/// Association <br/>
		/// [FK][Many]tblSocialMember.SocialMemberStatusID --- [PK][One]tblSocialMemberStatus.SocialMemberStatusID <br/>
		/// </summary>
		public virtual tblSocialMemberStatus tblSocialMemberStatus { get; set; }

		/// <summary>
		/// Association <br/>
		/// [FK][Many]tblSocialMember.SocialProviderID --- [PK][One]tblSocialProvider.SocialProviderID <br/>
		/// </summary>
		public virtual tblSocialProvider tblSocialProvider { get; set; }
		#endregion Associations

		partial void OnCreated();
	}
	#endregion dbo.tblSocialMember

	#region dbo.tblSocialMemberStatus
	public partial class tblSocialMemberStatus : EFCoreEntityBase<tblSocialMemberStatus>
	{
		public tblSocialMemberStatus()
		{
			OnCreated();
		}

		public tblSocialMemberStatus(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "Int NOT NULL", IsPrimaryKey = true
		/// </summary>
		public int SocialMemberStatusID { get; set; }

		/// <summary>
		/// DbType = "Int NOT NULL"
		/// </summary>
		public int Ordinal { get; set; }

		/// <summary>
		/// DbType = "NVarChar(100)"
		/// </summary>
		public string PropertyName { get; set; }

		#endregion Columns

		#region Associations

		/// <summary>
		/// Association <br/>
		/// [PK][One]tblSocialMemberStatus.SocialMemberStatusID --- [FK][Many]tblSocialMember.SocialMemberStatusID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<tblSocialMember> tblSocialMemberList { get; set; } = new List<tblSocialMember>();
		#endregion Associations

		partial void OnCreated();
	}
	#endregion dbo.tblSocialMemberStatus

	#region dbo.tblSocialProvider
	public partial class tblSocialProvider : EFCoreEntityBase<tblSocialProvider>
	{
		public tblSocialProvider()
		{
			OnCreated();
		}

		public tblSocialProvider(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "Int NOT NULL", IsPrimaryKey = true
		/// </summary>
		public int SocialProviderID { get; set; }

		/// <summary>
		/// DbType = "VarChar(100)"
		/// </summary>
		public string PropertyName { get; set; }

		#endregion Columns

		#region Associations

		/// <summary>
		/// Association <br/>
		/// [PK][One]tblSocialProvider.SocialProviderID --- [FK][Many]tblSocialMember.SocialProviderID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<tblSocialMember> tblSocialMemberList { get; set; } = new List<tblSocialMember>();
		#endregion Associations

		partial void OnCreated();
	}
	#endregion dbo.tblSocialProvider

	#region dbo.tblWeatherCity
	public partial class tblWeatherCity : EFCoreEntityBase<tblWeatherCity>
	{
		public tblWeatherCity()
		{
			OnCreated();
		}

		public tblWeatherCity(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "Int NOT NULL", IsPrimaryKey = true
		/// </summary>
		public int WeatherCityID { get; set; }

		/// <summary>
		/// DbType = "NVarChar(100) NOT NULL"
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// DbType = "NVarChar(200)"
		/// </summary>
		public string LongName { get; set; }

		/// <summary>
		/// DbType = "VarChar(50)"
		/// </summary>
		public string AccuweatherCode { get; set; }

		/// <summary>
		/// DbType = "VarChar(10) NOT NULL", DefaultValue = "hr"
		/// </summary>
		public string Language { get; set; } = "hr";

		/// <summary>
		/// DbType = "Bit NOT NULL", DefaultValue = false
		/// </summary>
		public bool DownloadAccuweather { get; set; } = false;

		/// <summary>
		/// DbType = "VarChar(100) NOT NULL"
		/// </summary>
		public string UrlName { get; set; }

		/// <summary>
		/// DbType = "Int"
		/// </summary>
		public int? Population { get; set; }

		/// <summary>
		/// DbType = "Decimal(18,10)"
		/// </summary>
		public decimal? Latitude { get; set; }

		/// <summary>
		/// DbType = "Decimal(18,10)"
		/// </summary>
		public decimal? Longitude { get; set; }

		#endregion Columns

		#region Associations

		/// <summary>
		/// Association <br/>
		/// [PK][One]tblWeatherCity.WeatherCityID --- [FK][Many]tblWeatherDayInfo.WeatherCityID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<tblWeatherDayInfo> tblWeatherDayInfoList { get; set; } = new List<tblWeatherDayInfo>();

		/// <summary>
		/// Association <br/>
		/// [PK][One]tblWeatherCity.WeatherCityID --- [FK][Many]tblWeatherInfo.WeatherCityID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<tblWeatherInfo> tblWeatherInfoList { get; set; } = new List<tblWeatherInfo>();
		#endregion Associations

		partial void OnCreated();
	}
	#endregion dbo.tblWeatherCity

	#region dbo.tblWeatherDayInfo
	public partial class tblWeatherDayInfo : EFCoreEntityBase<tblWeatherDayInfo>
	{
		public tblWeatherDayInfo()
		{
			OnCreated();
		}

		public tblWeatherDayInfo(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "BigInt NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert
		/// </summary>
		public long WeatherDayInfoID { get; set; }

		/// <summary>
		/// DbType = "Int NOT NULL"
		/// </summary>
		public int WeatherCityID { get; set; }

		/// <summary>
		/// DbType = "DateTime NOT NULL"
		/// </summary>
		public DateTime LastUpdateDate { get; set; }

		/// <summary>
		/// DbType = "DateTime NOT NULL"
		/// </summary>
		public DateTime WeatherDate { get; set; }

		/// <summary>
		/// DbType = "Time(7)"
		/// </summary>
		public System.TimeSpan? Sunrise { get; set; }

		/// <summary>
		/// DbType = "Time(7)"
		/// </summary>
		public System.TimeSpan? Sunset { get; set; }

		/// <summary>
		/// DbType = "Time(7)"
		/// </summary>
		public System.TimeSpan? SunDuration { get; set; }

		/// <summary>
		/// DbType = "Time(7)"
		/// </summary>
		public System.TimeSpan? Moonrise { get; set; }

		/// <summary>
		/// DbType = "Time(7)"
		/// </summary>
		public System.TimeSpan? Moonset { get; set; }

		/// <summary>
		/// DbType = "Time(7)"
		/// </summary>
		public System.TimeSpan? MoonDuration { get; set; }

		#endregion Columns

		#region Associations

		/// <summary>
		/// Association <br/>
		/// [FK][Many]tblWeatherDayInfo.WeatherCityID --- [PK][One]tblWeatherCity.WeatherCityID <br/>
		/// </summary>
		public virtual tblWeatherCity tblWeatherCity { get; set; }
		#endregion Associations

		partial void OnCreated();
	}
	#endregion dbo.tblWeatherDayInfo

	#region dbo.tblWeatherInfo
	public partial class tblWeatherInfo : EFCoreEntityBase<tblWeatherInfo>
	{
		public tblWeatherInfo()
		{
			OnCreated();
		}

		public tblWeatherInfo(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "BigInt NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert
		/// </summary>
		public long WeatherInfoID { get; set; }

		/// <summary>
		/// DbType = "Int NOT NULL"
		/// </summary>
		public int WeatherCityID { get; set; }

		/// <summary>
		/// DbType = "NVarChar(10) NOT NULL"
		/// </summary>
		public string Language { get; set; }

		/// <summary>
		/// DbType = "DateTime NOT NULL"
		/// </summary>
		public DateTime LastUpdateDate { get; set; }

		/// <summary>
		/// DbType = "DateTime NOT NULL"
		/// </summary>
		public DateTime WeatherDate { get; set; }

		/// <summary>
		/// DbType = "Int NOT NULL"
		/// </summary>
		public int WeatherKindID { get; set; }

		/// <summary>
		/// DbType = "Decimal(5,2)"
		/// </summary>
		public decimal? Temperature { get; set; }

		/// <summary>
		/// DbType = "Char(1)"
		/// </summary>
		public string TemperatureUnits { get; set; }

		/// <summary>
		/// DbType = "Decimal(5,2)"
		/// </summary>
		public decimal? RealFeel { get; set; }

		/// <summary>
		/// DbType = "Decimal(5,2)"
		/// </summary>
		public decimal? RealFeelShade { get; set; }

		/// <summary>
		/// DbType = "Int"
		/// </summary>
		public int? IconValue { get; set; }

		/// <summary>
		/// DbType = "NVarChar(500)"
		/// </summary>
		public string ShortDescription { get; set; }

		/// <summary>
		/// DbType = "NVarChar(20)"
		/// </summary>
		public string UVIndex { get; set; }

		/// <summary>
		/// DbType = "NVarChar(20)"
		/// </summary>
		public string Wind { get; set; }

		/// <summary>
		/// DbType = "VarChar(20)"
		/// </summary>
		public string WindGusts { get; set; }

		/// <summary>
		/// DbType = "VarChar(20)"
		/// </summary>
		public string ProbabilityOfPrecipitation { get; set; }

		/// <summary>
		/// DbType = "VarChar(20)"
		/// </summary>
		public string ProbabilityOfThunderstorms { get; set; }

		/// <summary>
		/// DbType = "VarChar(20)"
		/// </summary>
		public string Precipitation { get; set; }

		/// <summary>
		/// DbType = "VarChar(20)"
		/// </summary>
		public string Rain { get; set; }

		/// <summary>
		/// DbType = "VarChar(20)"
		/// </summary>
		public string Snow { get; set; }

		/// <summary>
		/// DbType = "VarChar(20)"
		/// </summary>
		public string Ice { get; set; }

		/// <summary>
		/// DbType = "VarChar(20)"
		/// </summary>
		public string HoursOfPrecipitation { get; set; }

		/// <summary>
		/// DbType = "VarChar(20)"
		/// </summary>
		public string HoursOfRain { get; set; }

		/// <summary>
		/// DbType = "VarChar(20)"
		/// </summary>
		public string Humidity { get; set; }

		/// <summary>
		/// DbType = "VarChar(20)"
		/// </summary>
		public string DewPoint { get; set; }

		/// <summary>
		/// DbType = "VarChar(20)"
		/// </summary>
		public string Pressure { get; set; }

		/// <summary>
		/// DbType = "VarChar(20)"
		/// </summary>
		public string CloudCover { get; set; }

		/// <summary>
		/// DbType = "VarChar(20)"
		/// </summary>
		public string Visibility { get; set; }

		/// <summary>
		/// DbType = "VarChar(20)"
		/// </summary>
		public string Ceiling { get; set; }

		/// <summary>
		/// DbType = "VarChar(20)"
		/// </summary>
		public string AirQuality { get; set; }

		#endregion Columns

		#region Associations

		/// <summary>
		/// Association <br/>
		/// [FK][Many]tblWeatherInfo.WeatherCityID --- [PK][One]tblWeatherCity.WeatherCityID <br/>
		/// </summary>
		public virtual tblWeatherCity tblWeatherCity { get; set; }

		/// <summary>
		/// Association <br/>
		/// [FK][Many]tblWeatherInfo.WeatherKindID --- [PK][One]tblWeatherKind.WeatherKindID <br/>
		/// </summary>
		public virtual tblWeatherKind tblWeatherKind { get; set; }
		#endregion Associations

		partial void OnCreated();
	}
	#endregion dbo.tblWeatherInfo

	#region dbo.tblWeatherKind
	public partial class tblWeatherKind : EFCoreEntityBase<tblWeatherKind>
	{
		public tblWeatherKind()
		{
			OnCreated();
		}

		public tblWeatherKind(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "Int NOT NULL", IsPrimaryKey = true
		/// </summary>
		public int WeatherKindID { get; set; }

		/// <summary>
		/// DbType = "VarChar(50) NOT NULL"
		/// </summary>
		public string Name { get; set; }

		#endregion Columns

		#region Associations

		/// <summary>
		/// Association <br/>
		/// [PK][One]tblWeatherKind.WeatherKindID --- [FK][Many]tblWeatherInfo.WeatherKindID <br/>
		/// DeleteRule = NoAction <br/>
		/// </summary>
		public virtual List<tblWeatherInfo> tblWeatherInfoList { get; set; } = new List<tblWeatherInfo>();
		#endregion Associations

		partial void OnCreated();
	}
	#endregion dbo.tblWeatherKind

	#region dbo.viewBookkeepingFiduciaExport
	public partial class viewBookkeepingFiduciaExport : EFCoreEntityBase<viewBookkeepingFiduciaExport>
	{
		public viewBookkeepingFiduciaExport()
		{
			OnCreated();
		}

		public viewBookkeepingFiduciaExport(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "BigInt NOT NULL IDENTITY"
		/// </summary>
		public long FiduciaExportID { get; set; }

		/// <summary>
		/// DbType = "DateTime NOT NULL"
		/// </summary>
		public DateTime DatumGeneriranja { get; set; }

		/// <summary>
		/// DbType = "BigInt NOT NULL"
		/// </summary>
		public long BillFirmaID { get; set; }

		/// <summary>
		/// DbType = "DateTime NOT NULL"
		/// </summary>
		public DateTime StartDateIncluded { get; set; }

		/// <summary>
		/// DbType = "DateTime NOT NULL"
		/// </summary>
		public DateTime EndDateExcluded { get; set; }

		/// <summary>
		/// DbType = "Bit"
		/// </summary>
		public bool? HasAllData { get; set; }

		/// <summary>
		/// DbType = "Bit"
		/// </summary>
		public bool? HasKlijenti { get; set; }

		/// <summary>
		/// DbType = "Bit"
		/// </summary>
		public bool? HasRacuniKonta { get; set; }

		/// <summary>
		/// DbType = "Bit"
		/// </summary>
		public bool? HasRacuniKnjiga { get; set; }

		/// <summary>
		/// DbType = "Bit"
		/// </summary>
		public bool? HasPreknjizenja { get; set; }

		#endregion Columns

		#region Associations
		#endregion Associations

		partial void OnCreated();
	}
	#endregion dbo.viewBookkeepingFiduciaExport

	#region dbo.viewBookkeepingSynesisExport
	public partial class viewBookkeepingSynesisExport : EFCoreEntityBase<viewBookkeepingSynesisExport>
	{
		public viewBookkeepingSynesisExport()
		{
			OnCreated();
		}

		public viewBookkeepingSynesisExport(DbContext context) : base(context)
		{
			OnCreated();
		}

		#region Columns
		/// <summary>
		/// DbType = "BigInt NOT NULL IDENTITY"
		/// </summary>
		public long SynesisExportID { get; set; }

		/// <summary>
		/// DbType = "DateTime NOT NULL"
		/// </summary>
		public DateTime DatumGeneriranja { get; set; }

		/// <summary>
		/// DbType = "BigInt NOT NULL"
		/// </summary>
		public long BillFirmaID { get; set; }

		/// <summary>
		/// DbType = "DateTime NOT NULL"
		/// </summary>
		public DateTime StartDateIncluded { get; set; }

		/// <summary>
		/// DbType = "DateTime NOT NULL"
		/// </summary>
		public DateTime EndDateExcluded { get; set; }

		/// <summary>
		/// DbType = "Bit"
		/// </summary>
		public bool? HasAllData { get; set; }

		/// <summary>
		/// DbType = "Bit"
		/// </summary>
		public bool? HasKlijenti { get; set; }

		/// <summary>
		/// DbType = "Bit"
		/// </summary>
		public bool? HasFinancKnjig { get; set; }

		/// <summary>
		/// DbType = "Bit"
		/// </summary>
		public bool? HasUlazniRacuni { get; set; }

		/// <summary>
		/// DbType = "Bit"
		/// </summary>
		public bool? HasIzlazniRacuni { get; set; }

		#endregion Columns

		#region Associations
		#endregion Associations

		partial void OnCreated();
	}
	#endregion dbo.viewBookkeepingSynesisExport

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

	#region fnCalculateBankaPrometOsnovicaAndPdvResult
	public partial class fnCalculateBankaPrometOsnovicaAndPdvResult
	{
		public fnCalculateBankaPrometOsnovicaAndPdvResult(){ }

		/// <summary>
		/// DbType = "Money NOT NULL"
		/// </summary>
		public decimal PoreznaOsnovica { get; set; }

		/// <summary>
		/// DbType = "Money NOT NULL"
		/// </summary>
		public decimal PdvIznos { get; set; }

		/// <summary>
		/// DbType = "Money NOT NULL"
		/// </summary>
		public decimal PdvPosto { get; set; }

	}
	#endregion fnCalculateBankaPrometOsnovicaAndPdvResult

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

	#region fnCalculateDocumentNaknadeResult
	public partial class fnCalculateDocumentNaknadeResult
	{
		public fnCalculateDocumentNaknadeResult(){ }

		/// <summary>
		/// DbType = "NVarChar(50) NOT NULL"
		/// </summary>
		public string NaknadaNaziv { get; set; }

		/// <summary>
		/// DbType = "Float NOT NULL"
		/// </summary>
		public double IznosNaknade { get; set; }

	}
	#endregion fnCalculateDocumentNaknadeResult

	#region fnCalculateDocumentPorezOstaliResult
	public partial class fnCalculateDocumentPorezOstaliResult
	{
		public fnCalculateDocumentPorezOstaliResult(){ }

		/// <summary>
		/// DbType = "NVarChar(50) NOT NULL"
		/// </summary>
		public string PorezNaziv { get; set; }

		/// <summary>
		/// DbType = "NVarChar(82)"
		/// </summary>
		public string PorezDesc { get; set; }

		/// <summary>
		/// DbType = "Float NOT NULL"
		/// </summary>
		public double PostotakPoreza { get; set; }

		/// <summary>
		/// DbType = "Float NOT NULL"
		/// </summary>
		public double SumPoreznaOsnovica { get; set; }

		/// <summary>
		/// DbType = "Float NOT NULL"
		/// </summary>
		public double SumIznosPoreza { get; set; }

	}
	#endregion fnCalculateDocumentPorezOstaliResult

	#region fnCalculateDocumentPorezPdvResult
	public partial class fnCalculateDocumentPorezPdvResult
	{
		public fnCalculateDocumentPorezPdvResult(){ }

		/// <summary>
		/// DbType = "VarChar(3) NOT NULL"
		/// </summary>
		public string PorezNaziv { get; set; }

		/// <summary>
		/// DbType = "VarChar(35)"
		/// </summary>
		public string PorezDesc { get; set; }

		/// <summary>
		/// DbType = "Float NOT NULL"
		/// </summary>
		public double PostotakPoreza { get; set; }

		/// <summary>
		/// DbType = "Float NOT NULL"
		/// </summary>
		public double SumPoreznaOsnovica { get; set; }

		/// <summary>
		/// DbType = "Float NOT NULL"
		/// </summary>
		public double SumIznosPoreza { get; set; }

	}
	#endregion fnCalculateDocumentPorezPdvResult

	#region fnCalculateDocumentPorezPotrosnjaResult
	public partial class fnCalculateDocumentPorezPotrosnjaResult
	{
		public fnCalculateDocumentPorezPotrosnjaResult(){ }

		/// <summary>
		/// DbType = "VarChar(3) NOT NULL"
		/// </summary>
		public string PorezNaziv { get; set; }

		/// <summary>
		/// DbType = "VarChar(35)"
		/// </summary>
		public string PorezDesc { get; set; }

		/// <summary>
		/// DbType = "Float NOT NULL"
		/// </summary>
		public double PostotakPoreza { get; set; }

		/// <summary>
		/// DbType = "Float NOT NULL"
		/// </summary>
		public double SumPoreznaOsnovica { get; set; }

		/// <summary>
		/// DbType = "Float NOT NULL"
		/// </summary>
		public double SumIznosPoreza { get; set; }

	}
	#endregion fnCalculateDocumentPorezPotrosnjaResult

	#region fnCalculateDocumentStavkeResult
	public partial class fnCalculateDocumentStavkeResult
	{
		public fnCalculateDocumentStavkeResult(){ }

		/// <summary>
		/// DbType = "BigInt NOT NULL"
		/// </summary>
		public long BillDocumentStavkaID { get; set; }

		/// <summary>
		/// DbType = "BigInt NOT NULL"
		/// </summary>
		public long BillDocumentID { get; set; }

		/// <summary>
		/// DbType = "BigInt NOT NULL"
		/// </summary>
		public long BillProductID { get; set; }

		/// <summary>
		/// DbType = "NVarChar(150) NOT NULL"
		/// </summary>
		public string ProductNaziv { get; set; }

		/// <summary>
		/// DbType = "Money NOT NULL"
		/// </summary>
		public decimal JedinicnaCijena { get; set; }

		/// <summary>
		/// DbType = "Bit NOT NULL"
		/// </summary>
		public bool CijenaJeMPC { get; set; }

		/// <summary>
		/// DbType = "Int NOT NULL"
		/// </summary>
		public int BillMjeraID { get; set; }

		/// <summary>
		/// DbType = "Float NOT NULL"
		/// </summary>
		public double Kolicina { get; set; }

		/// <summary>
		/// DbType = "Money NOT NULL"
		/// </summary>
		public decimal PopustPosto { get; set; }

		/// <summary>
		/// DbType = "BigInt NOT NULL"
		/// </summary>
		public long BillPoreznaGrupaID { get; set; }

		/// <summary>
		/// DbType = "NVarChar(100) NOT NULL"
		/// </summary>
		public string PoreznaGrupaNaziv { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50)"
		/// </summary>
		public string NaknadaNaziv { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50)"
		/// </summary>
		public string OstaliPorezNaziv { get; set; }

		/// <summary>
		/// DbType = "Float NOT NULL"
		/// </summary>
		public double JedinicnaVPC { get; set; }

		/// <summary>
		/// DbType = "Float NOT NULL"
		/// </summary>
		public double JedinicnaMPC { get; set; }

		/// <summary>
		/// DbType = "Float NOT NULL"
		/// </summary>
		public double VPCsPopustom { get; set; }

		/// <summary>
		/// DbType = "Float NOT NULL"
		/// </summary>
		public double MPCsPopustom { get; set; }

		/// <summary>
		/// DbType = "Float NOT NULL"
		/// </summary>
		public double SumPoreznaOsnovica { get; set; }

		/// <summary>
		/// DbType = "Float NOT NULL"
		/// </summary>
		public double PdvPosto { get; set; }

		/// <summary>
		/// DbType = "Bit NOT NULL"
		/// </summary>
		public bool UPdvSustavu { get; set; }

		/// <summary>
		/// DbType = "Float NOT NULL"
		/// </summary>
		public double SumIznosPdva { get; set; }

		/// <summary>
		/// DbType = "Float NOT NULL"
		/// </summary>
		public double PorezPotrosnjaPosto { get; set; }

		/// <summary>
		/// DbType = "Float NOT NULL"
		/// </summary>
		public double SumIznosPorezPotrosnja { get; set; }

		/// <summary>
		/// DbType = "Float NOT NULL"
		/// </summary>
		public double OstaliPorezPosto { get; set; }

		/// <summary>
		/// DbType = "Float NOT NULL"
		/// </summary>
		public double SumIznosOstaliPorez { get; set; }

		/// <summary>
		/// DbType = "Float NOT NULL"
		/// </summary>
		public double SumIznosNaknade { get; set; }

		/// <summary>
		/// DbType = "Float NOT NULL"
		/// </summary>
		public double SumVPCsPopustom { get; set; }

		/// <summary>
		/// DbType = "Float NOT NULL"
		/// </summary>
		public double SumMPCsPopustom { get; set; }

	}
	#endregion fnCalculateDocumentStavkeResult

	#region fnCalculateDocumentTotalsResult
	public partial class fnCalculateDocumentTotalsResult
	{
		public fnCalculateDocumentTotalsResult(){ }

		/// <summary>
		/// DbType = "BigInt NOT NULL"
		/// </summary>
		public long BillDocumentID { get; set; }

		/// <summary>
		/// DbType = "Float NOT NULL"
		/// </summary>
		public double SumPoreznaOsnovica { get; set; }

		/// <summary>
		/// DbType = "Float NOT NULL"
		/// </summary>
		public double SumIznosPdva { get; set; }

		/// <summary>
		/// DbType = "Float NOT NULL"
		/// </summary>
		public double SumIznosPorezPotrosnja { get; set; }

		/// <summary>
		/// DbType = "Float NOT NULL"
		/// </summary>
		public double SumIznosOstaliPorez { get; set; }

		/// <summary>
		/// DbType = "Float NOT NULL"
		/// </summary>
		public double SumUkupno { get; set; }

	}
	#endregion fnCalculateDocumentTotalsResult

	#region fnCalculatePozivNaBrojResult
	public partial class fnCalculatePozivNaBrojResult
	{
		public fnCalculatePozivNaBrojResult(){ }

		/// <summary>
		/// DbType = "VarChar(10)"
		/// </summary>
		public string ModelPlacanja { get; set; }

		/// <summary>
		/// DbType = "VarChar(50)"
		/// </summary>
		public string PozivNaBroj { get; set; }

	}
	#endregion fnCalculatePozivNaBrojResult

	#region fnCLRCsvArgsToIntTableResult
	public partial class fnCLRCsvArgsToIntTableResult
	{
		public fnCLRCsvArgsToIntTableResult(){ }

		/// <summary>
		/// DbType = "BigInt"
		/// </summary>
		public long? part { get; set; }

	}
	#endregion fnCLRCsvArgsToIntTableResult

	#region fnCLRCsvArgsToWordsTableResult
	public partial class fnCLRCsvArgsToWordsTableResult
	{
		public fnCLRCsvArgsToWordsTableResult(){ }

		/// <summary>
		/// DbType = "NVarChar(MAX)"
		/// </summary>
		public string part { get; set; }

	}
	#endregion fnCLRCsvArgsToWordsTableResult

	#region fnCLRSplitStringByPatternResult
	public partial class fnCLRSplitStringByPatternResult
	{
		public fnCLRSplitStringByPatternResult(){ }

		/// <summary>
		/// DbType = "Int"
		/// </summary>
		public int? position { get; set; }

		/// <summary>
		/// DbType = "NVarChar(MAX)"
		/// </summary>
		public string part { get; set; }

	}
	#endregion fnCLRSplitStringByPatternResult

	#region fnCLRSplitStringToDistinctWordsResult
	public partial class fnCLRSplitStringToDistinctWordsResult
	{
		public fnCLRSplitStringToDistinctWordsResult(){ }

		/// <summary>
		/// DbType = "Int"
		/// </summary>
		public int? position { get; set; }

		/// <summary>
		/// DbType = "NVarChar(MAX)"
		/// </summary>
		public string part { get; set; }

	}
	#endregion fnCLRSplitStringToDistinctWordsResult

	#region fnCLRSplitStringToWordsResult
	public partial class fnCLRSplitStringToWordsResult
	{
		public fnCLRSplitStringToWordsResult(){ }

		/// <summary>
		/// DbType = "Int"
		/// </summary>
		public int? position { get; set; }

		/// <summary>
		/// DbType = "NVarChar(MAX)"
		/// </summary>
		public string part { get; set; }

	}
	#endregion fnCLRSplitStringToWordsResult

	#region fnConvertCsvArgsToIntTableResult
	public partial class fnConvertCsvArgsToIntTableResult
	{
		public fnConvertCsvArgsToIntTableResult(){ }

		/// <summary>
		/// DbType = "BigInt NOT NULL"
		/// </summary>
		public long number { get; set; }

	}
	#endregion fnConvertCsvArgsToIntTableResult

	#region fnConvertCsvArgsToWordsTableResult
	public partial class fnConvertCsvArgsToWordsTableResult
	{
		public fnConvertCsvArgsToWordsTableResult(){ }

		/// <summary>
		/// DbType = "NVarChar(MAX)"
		/// </summary>
		public string word { get; set; }

	}
	#endregion fnConvertCsvArgsToWordsTableResult

	#region fnGetBankaPrometVrsteResult
	public partial class fnGetBankaPrometVrsteResult
	{
		public fnGetBankaPrometVrsteResult(){ }

		/// <summary>
		/// DbType = "Int NOT NULL"
		/// </summary>
		public int BankaPrometVrstaID { get; set; }

		/// <summary>
		/// DbType = "NVarChar(150) NOT NULL"
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// DbType = "Bit NOT NULL"
		/// </summary>
		public bool IsPrihod { get; set; }

		/// <summary>
		/// DbType = "Bit NOT NULL"
		/// </summary>
		public bool IsRashod { get; set; }

		/// <summary>
		/// DbType = "NVarChar(100)"
		/// </summary>
		public string PrometVrstaName { get; set; }

	}
	#endregion fnGetBankaPrometVrsteResult

	#region fnGetBankaPrometVrsteDatumaResult
	public partial class fnGetBankaPrometVrsteDatumaResult
	{
		public fnGetBankaPrometVrsteDatumaResult(){ }

		/// <summary>
		/// DbType = "VarChar(16) NOT NULL"
		/// </summary>
		public string Naziv { get; set; }

		/// <summary>
		/// DbType = "Int NOT NULL"
		/// </summary>
		public int Vrijednost { get; set; }

	}
	#endregion fnGetBankaPrometVrsteDatumaResult

	#region fnGetBankaValutaTecajResult
	public partial class fnGetBankaValutaTecajResult
	{
		public fnGetBankaValutaTecajResult(){ }

		/// <summary>
		/// DbType = "NVarChar(100)"
		/// </summary>
		public string DrzavaNaziv { get; set; }

		/// <summary>
		/// DbType = "VarChar(50)"
		/// </summary>
		public string DrzavaISO { get; set; }

		/// <summary>
		/// DbType = "BigInt NOT NULL"
		/// </summary>
		public long BankaValutaTecajID { get; set; }

		/// <summary>
		/// DbType = "VarChar(10) NOT NULL"
		/// </summary>
		public string OsnovnaValuta { get; set; }

		/// <summary>
		/// DbType = "VarChar(10) NOT NULL"
		/// </summary>
		public string Valuta { get; set; }

		/// <summary>
		/// DbType = "SmallDateTime NOT NULL"
		/// </summary>
		public DateTime DatumPrimjene { get; set; }

		/// <summary>
		/// DbType = "Decimal(18,10)"
		/// </summary>
		public decimal? JedinicniIznos { get; set; }

		/// <summary>
		/// DbType = "Decimal(18,10)"
		/// </summary>
		public decimal? KupovniTecaj { get; set; }

		/// <summary>
		/// DbType = "Decimal(18,10)"
		/// </summary>
		public decimal? SrednjiTecaj { get; set; }

		/// <summary>
		/// DbType = "Decimal(18,10)"
		/// </summary>
		public decimal? ProdajniTecaj { get; set; }

	}
	#endregion fnGetBankaValutaTecajResult

	#region fnGetBillClientsFromPoziviNaBrojResult
	public partial class fnGetBillClientsFromPoziviNaBrojResult
	{
		public fnGetBillClientsFromPoziviNaBrojResult(){ }

		/// <summary>
		/// DbType = "BigInt NOT NULL"
		/// </summary>
		public long BillClientID { get; set; }

	}
	#endregion fnGetBillClientsFromPoziviNaBrojResult

	#region fnGetBillClientUplateResult
	public partial class fnGetBillClientUplateResult
	{
		public fnGetBillClientUplateResult(){ }

		/// <summary>
		/// DbType = "BigInt NOT NULL"
		/// </summary>
		public long BillDocumentID { get; set; }

		/// <summary>
		/// DbType = "VarChar(50) NOT NULL"
		/// </summary>
		public string PozivNaBroj { get; set; }

		/// <summary>
		/// DbType = "Int NOT NULL"
		/// </summary>
		public int BillDocumentTipID { get; set; }

		/// <summary>
		/// DbType = "Bit NOT NULL"
		/// </summary>
		public bool IsRacunType { get; set; }

		/// <summary>
		/// DbType = "BigInt NOT NULL"
		/// </summary>
		public long BillClientID { get; set; }

		/// <summary>
		/// DbType = "Decimal(18,8)"
		/// </summary>
		public decimal? IznosDokumenta { get; set; }

		/// <summary>
		/// DbType = "BigInt"
		/// </summary>
		public long? BankaPrometID { get; set; }

		/// <summary>
		/// DbType = "DateTime"
		/// </summary>
		public DateTime? BankaDatumTransakcije { get; set; }

		/// <summary>
		/// DbType = "Money"
		/// </summary>
		public decimal? BankaUplata { get; set; }

		/// <summary>
		/// DbType = "Money"
		/// </summary>
		public decimal? BankaIsplata { get; set; }

	}
	#endregion fnGetBillClientUplateResult

	#region fnGetDbPairNamesResult
	public partial class fnGetDbPairNamesResult
	{
		public fnGetDbPairNamesResult(){ }

		/// <summary>
		/// DbType = "VarChar(100)"
		/// </summary>
		public string CurrentDatabase { get; set; }

		/// <summary>
		/// DbType = "VarChar(100)"
		/// </summary>
		public string AppDatabase { get; set; }

		/// <summary>
		/// DbType = "VarChar(100)"
		/// </summary>
		public string PosDatabase { get; set; }

	}
	#endregion fnGetDbPairNamesResult

	#region fnGetMonthStartEndResult
	public partial class fnGetMonthStartEndResult
	{
		public fnGetMonthStartEndResult(){ }

		/// <summary>
		/// DbType = "DateTime"
		/// </summary>
		public DateTime? InputDate { get; set; }

		/// <summary>
		/// DbType = "DateTime"
		/// </summary>
		public DateTime? MonthFirstDate { get; set; }

		/// <summary>
		/// DbType = "DateTime"
		/// </summary>
		public DateTime? MonthLastDate { get; set; }

		/// <summary>
		/// DbType = "Int"
		/// </summary>
		public int? DaysInMonth { get; set; }

	}
	#endregion fnGetMonthStartEndResult

	#region fnGetNKDFullPathInfoResult
	public partial class fnGetNKDFullPathInfoResult
	{
		public fnGetNKDFullPathInfoResult(){ }

		/// <summary>
		/// DbType = "NVarChar(MAX)"
		/// </summary>
		public string FullNazivString { get; set; }

		/// <summary>
		/// DbType = "NVarChar(MAX)"
		/// </summary>
		public string FullKeywordsString { get; set; }

	}
	#endregion fnGetNKDFullPathInfoResult

	#region fnGetPorezPdvNaDatumResult
	public partial class fnGetPorezPdvNaDatumResult
	{
		public fnGetPorezPdvNaDatumResult(){ }

		/// <summary>
		/// DbType = "DateTime NOT NULL"
		/// </summary>
		public DateTime DatumValute { get; set; }

		/// <summary>
		/// DbType = "Int NOT NULL"
		/// </summary>
		public int BillPorezPdvID { get; set; }

		/// <summary>
		/// DbType = "Bit NOT NULL"
		/// </summary>
		public bool IsActive { get; set; }

		/// <summary>
		/// DbType = "Int"
		/// </summary>
		public int? Ordinal { get; set; }

		/// <summary>
		/// DbType = "Bit NOT NULL"
		/// </summary>
		public bool IsDefault { get; set; }

		/// <summary>
		/// DbType = "NVarChar(150) NOT NULL"
		/// </summary>
		public string Naziv { get; set; }

		/// <summary>
		/// DbType = "NVarChar(250)"
		/// </summary>
		public string PrintableText { get; set; }

		/// <summary>
		/// DbType = "NVarChar(MAX)"
		/// </summary>
		public string Opis { get; set; }

		/// <summary>
		/// DbType = "NVarChar(200)"
		/// </summary>
		public string PrintableTextPercent { get; set; }

		/// <summary>
		/// DbType = "Int NOT NULL"
		/// </summary>
		public int BillPorezPdvPostotakID { get; set; }

		/// <summary>
		/// DbType = "Money NOT NULL"
		/// </summary>
		public decimal PdvPosto { get; set; }

		/// <summary>
		/// DbType = "DateTime NOT NULL"
		/// </summary>
		public DateTime StartDatum { get; set; }

		/// <summary>
		/// DbType = "DateTime"
		/// </summary>
		public DateTime? EndDatum { get; set; }

	}
	#endregion fnGetPorezPdvNaDatumResult

	#region fnGetPorezPotrosnjaNaDatumResult
	public partial class fnGetPorezPotrosnjaNaDatumResult
	{
		public fnGetPorezPotrosnjaNaDatumResult(){ }

		/// <summary>
		/// DbType = "DateTime NOT NULL"
		/// </summary>
		public DateTime DatumValute { get; set; }

		/// <summary>
		/// DbType = "Int NOT NULL"
		/// </summary>
		public int BillPorezPotrosnjaID { get; set; }

		/// <summary>
		/// DbType = "Bit NOT NULL"
		/// </summary>
		public bool IsActive { get; set; }

		/// <summary>
		/// DbType = "Int"
		/// </summary>
		public int? Ordinal { get; set; }

		/// <summary>
		/// DbType = "Bit NOT NULL"
		/// </summary>
		public bool IsDefault { get; set; }

		/// <summary>
		/// DbType = "NVarChar(150) NOT NULL"
		/// </summary>
		public string Naziv { get; set; }

		/// <summary>
		/// DbType = "NVarChar(250)"
		/// </summary>
		public string PrintableText { get; set; }

		/// <summary>
		/// DbType = "NVarChar(MAX)"
		/// </summary>
		public string Opis { get; set; }

		/// <summary>
		/// DbType = "NVarChar(200)"
		/// </summary>
		public string PrintableTextPercent { get; set; }

		/// <summary>
		/// DbType = "Int NOT NULL"
		/// </summary>
		public int BillPorezPotrosnjaPostotakID { get; set; }

		/// <summary>
		/// DbType = "Money NOT NULL"
		/// </summary>
		public decimal PorezPosto { get; set; }

		/// <summary>
		/// DbType = "DateTime NOT NULL"
		/// </summary>
		public DateTime StartDatum { get; set; }

		/// <summary>
		/// DbType = "DateTime"
		/// </summary>
		public DateTime? EndDatum { get; set; }

	}
	#endregion fnGetPorezPotrosnjaNaDatumResult

	#region fnGetPrikazStatusInfoResult
	public partial class fnGetPrikazStatusInfoResult
	{
		public fnGetPrikazStatusInfoResult(){ }

		/// <summary>
		/// DbType = "Int"
		/// </summary>
		public int? PrikazStatus { get; set; }

		/// <summary>
		/// DbType = "DateTime"
		/// </summary>
		public DateTime? StartDate { get; set; }

		/// <summary>
		/// DbType = "DateTime"
		/// </summary>
		public DateTime? EndDate { get; set; }

		/// <summary>
		/// DbType = "Bit NOT NULL"
		/// </summary>
		public bool IsVisible { get; set; }

		/// <summary>
		/// DbType = "Bit NOT NULL"
		/// </summary>
		public bool IsPaid { get; set; }

	}
	#endregion fnGetPrikazStatusInfoResult

	#region fnGetProductInfoExtendedResult
	public partial class fnGetProductInfoExtendedResult
	{
		public fnGetProductInfoExtendedResult(){ }

		/// <summary>
		/// DbType = "BigInt NOT NULL"
		/// </summary>
		public long BillPoslovniProstorID { get; set; }

		/// <summary>
		/// DbType = "BigInt NOT NULL"
		/// </summary>
		public long BillFirmaID { get; set; }

		/// <summary>
		/// DbType = "BigInt NOT NULL"
		/// </summary>
		public long BillProductID { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50) NOT NULL"
		/// </summary>
		public string ProductNaziv { get; set; }

		/// <summary>
		/// DbType = "Money NOT NULL"
		/// </summary>
		public decimal JedinicnaCijena { get; set; }

		/// <summary>
		/// DbType = "Bit NOT NULL"
		/// </summary>
		public bool CijenaJeMPC { get; set; }

		/// <summary>
		/// DbType = "Int NOT NULL"
		/// </summary>
		public int BillMjeraID { get; set; }

		/// <summary>
		/// DbType = "BigInt NOT NULL"
		/// </summary>
		public long BillPoreznaGrupaID { get; set; }

		/// <summary>
		/// DbType = "NVarChar(100) NOT NULL"
		/// </summary>
		public string PoreznaGrupaNaziv { get; set; }

		/// <summary>
		/// DbType = "Decimal(5,2) NOT NULL"
		/// </summary>
		public decimal PdvPosto { get; set; }

		/// <summary>
		/// DbType = "Decimal(5,2) NOT NULL"
		/// </summary>
		public decimal PorezPotrosnjaPosto { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50)"
		/// </summary>
		public string OstaliPorezNaziv { get; set; }

		/// <summary>
		/// DbType = "Decimal(5,2) NOT NULL"
		/// </summary>
		public decimal OstaliPorezPosto { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50)"
		/// </summary>
		public string NaknadaNaziv { get; set; }

		/// <summary>
		/// DbType = "Money NOT NULL"
		/// </summary>
		public decimal IznosNaknade { get; set; }

	}
	#endregion fnGetProductInfoExtendedResult

	#region fnGetStariNoviGranicaResult
	public partial class fnGetStariNoviGranicaResult
	{
		public fnGetStariNoviGranicaResult(){ }

		/// <summary>
		/// DbType = "DateTime NOT NULL"
		/// </summary>
		public DateTime StariStart { get; set; }

		/// <summary>
		/// DbType = "DateTime NOT NULL"
		/// </summary>
		public DateTime NoviStart { get; set; }

		/// <summary>
		/// DbType = "DateTime NOT NULL"
		/// </summary>
		public DateTime NoviEnd { get; set; }

	}
	#endregion fnGetStariNoviGranicaResult

	#region fnGetUplateWithDocumentsResult
	public partial class fnGetUplateWithDocumentsResult
	{
		public fnGetUplateWithDocumentsResult(){ }

		/// <summary>
		/// DbType = "BigInt NOT NULL"
		/// </summary>
		public long BankaPrometID { get; set; }

		/// <summary>
		/// DbType = "DateTime NOT NULL"
		/// </summary>
		public DateTime BankaDatumTransakcije { get; set; }

		/// <summary>
		/// DbType = "Money"
		/// </summary>
		public decimal? BankaUplata { get; set; }

		/// <summary>
		/// DbType = "Money"
		/// </summary>
		public decimal? BankaIsplata { get; set; }

		/// <summary>
		/// DbType = "BigInt"
		/// </summary>
		public long? MinBillDocumentID { get; set; }

		/// <summary>
		/// DbType = "BigInt"
		/// </summary>
		public long? BillClientID { get; set; }

	}
	#endregion fnGetUplateWithDocumentsResult

	#region fnPosGetFirmaSettingsResult
	public partial class fnPosGetFirmaSettingsResult
	{
		public fnPosGetFirmaSettingsResult(){ }

		/// <summary>
		/// DbType = "BigInt NOT NULL"
		/// </summary>
		public long BillFirmaPosID { get; set; }

		/// <summary>
		/// DbType = "BigInt NOT NULL"
		/// </summary>
		public long BillFirmaID { get; set; }

		/// <summary>
		/// DbType = "BigInt"
		/// </summary>
		public long? ReferenceBillDocumentID { get; set; }

		/// <summary>
		/// DbType = "DateTime NOT NULL"
		/// </summary>
		public DateTime StartDate { get; set; }

		/// <summary>
		/// DbType = "DateTime NOT NULL"
		/// </summary>
		public DateTime EndDate { get; set; }

		/// <summary>
		/// DbType = "Bit NOT NULL"
		/// </summary>
		public bool IsActive { get; set; }

		/// <summary>
		/// DbType = "Int NOT NULL"
		/// </summary>
		public int PoslovniProstoriMax { get; set; }

		/// <summary>
		/// DbType = "Int NOT NULL"
		/// </summary>
		public int NaplatniUredjajiMax { get; set; }

		/// <summary>
		/// DbType = "Int NOT NULL"
		/// </summary>
		public int DocumentsMax { get; set; }

		/// <summary>
		/// DbType = "Int NOT NULL"
		/// </summary>
		public int DocumentsCount { get; set; }

		/// <summary>
		/// DbType = "Int NOT NULL"
		/// </summary>
		public int CategoriesMax { get; set; }

		/// <summary>
		/// DbType = "Int NOT NULL"
		/// </summary>
		public int ProductsMax { get; set; }

		/// <summary>
		/// DbType = "Int NOT NULL"
		/// </summary>
		public int PorezneGrupeMax { get; set; }

		/// <summary>
		/// DbType = "Int NOT NULL"
		/// </summary>
		public int OperatoriMax { get; set; }

		/// <summary>
		/// DbType = "Int"
		/// </summary>
		public int? DocumentsLeft { get; set; }

	}
	#endregion fnPosGetFirmaSettingsResult

	#region fnPosGetFirmaStatisticsResult
	public partial class fnPosGetFirmaStatisticsResult
	{
		public fnPosGetFirmaStatisticsResult(){ }

		/// <summary>
		/// DbType = "BigInt NOT NULL"
		/// </summary>
		public long BillFirmaID { get; set; }

		/// <summary>
		/// DbType = "Int"
		/// </summary>
		public int? AktivnePretplateCount { get; set; }

		/// <summary>
		/// DbType = "BigInt"
		/// </summary>
		public long? BillFirmaPosID { get; set; }

		/// <summary>
		/// DbType = "DateTime"
		/// </summary>
		public DateTime? StartDate { get; set; }

		/// <summary>
		/// DbType = "BigInt"
		/// </summary>
		public long? CategoriesMax { get; set; }

		/// <summary>
		/// DbType = "BigInt"
		/// </summary>
		public long? DocumentsMax { get; set; }

		/// <summary>
		/// DbType = "BigInt"
		/// </summary>
		public long? DocumentsCount { get; set; }

		/// <summary>
		/// DbType = "BigInt"
		/// </summary>
		public long? NaplatniUredjajiMax { get; set; }

		/// <summary>
		/// DbType = "BigInt"
		/// </summary>
		public long? OperatoriMax { get; set; }

		/// <summary>
		/// DbType = "BigInt"
		/// </summary>
		public long? PorezneGrupeMax { get; set; }

		/// <summary>
		/// DbType = "BigInt"
		/// </summary>
		public long? PoslovniProstoriMax { get; set; }

		/// <summary>
		/// DbType = "BigInt"
		/// </summary>
		public long? ProductsMax { get; set; }

		/// <summary>
		/// DbType = "DateTime"
		/// </summary>
		public DateTime? EndDate { get; set; }

		/// <summary>
		/// DbType = "Int"
		/// </summary>
		public int? OperatoriCount { get; set; }

		/// <summary>
		/// DbType = "Int"
		/// </summary>
		public int? PoslovniProstoriCount { get; set; }

		/// <summary>
		/// DbType = "Int"
		/// </summary>
		public int? NaplatniUredjajiCount { get; set; }

		/// <summary>
		/// DbType = "Int"
		/// </summary>
		public int? CategoriesCount { get; set; }

		/// <summary>
		/// DbType = "Int"
		/// </summary>
		public int? ProductsCount { get; set; }

		/// <summary>
		/// DbType = "Int"
		/// </summary>
		public int? PorezneGrupeCount { get; set; }

		/// <summary>
		/// DbType = "Bit"
		/// </summary>
		public bool? IsOperating { get; set; }

		/// <summary>
		/// DbType = "Bit"
		/// </summary>
		public bool? AllowNewCategory { get; set; }

		/// <summary>
		/// DbType = "Bit"
		/// </summary>
		public bool? AllowNewNaplatniUredjaj { get; set; }

		/// <summary>
		/// DbType = "Bit"
		/// </summary>
		public bool? AllowNewOperator { get; set; }

		/// <summary>
		/// DbType = "Bit"
		/// </summary>
		public bool? AllowNewPoreznaGrupa { get; set; }

		/// <summary>
		/// DbType = "Bit"
		/// </summary>
		public bool? AllowNewPoslovniProstor { get; set; }

		/// <summary>
		/// DbType = "Bit"
		/// </summary>
		public bool? AllowNewProduct { get; set; }

	}
	#endregion fnPosGetFirmaStatisticsResult

	#region fnRazradaIznosaResult
	public partial class fnRazradaIznosaResult
	{
		public fnRazradaIznosaResult(){ }

		/// <summary>
		/// DbType = "Float NOT NULL"
		/// </summary>
		public double JedinicnaVPC { get; set; }

		/// <summary>
		/// DbType = "Float NOT NULL"
		/// </summary>
		public double JedinicnaMPC { get; set; }

		/// <summary>
		/// DbType = "Float NOT NULL"
		/// </summary>
		public double PopustPosto { get; set; }

		/// <summary>
		/// DbType = "Float NOT NULL"
		/// </summary>
		public double VPCsPopustom { get; set; }

		/// <summary>
		/// DbType = "Float NOT NULL"
		/// </summary>
		public double IznosNaknade { get; set; }

		/// <summary>
		/// DbType = "Bit NOT NULL"
		/// </summary>
		public bool UPdvSustavu { get; set; }

		/// <summary>
		/// DbType = "Float NOT NULL"
		/// </summary>
		public double PdvPosto { get; set; }

		/// <summary>
		/// DbType = "Float NOT NULL"
		/// </summary>
		public double IznosPdva { get; set; }

		/// <summary>
		/// DbType = "Float NOT NULL"
		/// </summary>
		public double PorezPotrosnjaPosto { get; set; }

		/// <summary>
		/// DbType = "Float NOT NULL"
		/// </summary>
		public double IznosPorezPotrosnja { get; set; }

		/// <summary>
		/// DbType = "Float NOT NULL"
		/// </summary>
		public double OstaliPorezPosto { get; set; }

		/// <summary>
		/// DbType = "Float NOT NULL"
		/// </summary>
		public double IznosOstaliPorez { get; set; }

		/// <summary>
		/// DbType = "Float NOT NULL"
		/// </summary>
		public double MPCsPopustom { get; set; }

	}
	#endregion fnRazradaIznosaResult

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

	#region spGetAktivneUslugeMultipleResults
	public partial class spGetAktivneUslugeMultipleResults
	{
		public spGetAktivneUslugeMultipleResults(){ }

		public List<spGetAktivneUslugeResult> Result1 { get; set; }

		public int ReturnValue { get; set; }

	}
	#endregion spGetAktivneUslugeMultipleResults

	#region spGetBillClientSaldoMultipleResults
	public partial class spGetBillClientSaldoMultipleResults
	{
		public spGetBillClientSaldoMultipleResults(){ }

		public List<spGetBillClientSaldoResult> Result1 { get; set; }

		public int ReturnValue { get; set; }

	}
	#endregion spGetBillClientSaldoMultipleResults

	#region spGetBillMinMaxDateMultipleResults
	public partial class spGetBillMinMaxDateMultipleResults
	{
		public spGetBillMinMaxDateMultipleResults(){ }

		public List<BillDates> Dates { get; set; }

		public int ReturnValue { get; set; }

	}
	#endregion spGetBillMinMaxDateMultipleResults

	#region spGetDbccValuesMultipleResults
	public partial class spGetDbccValuesMultipleResults
	{
		public spGetDbccValuesMultipleResults(){ }

		public List<spGetDbccValuesResult> Result1 { get; set; }

		public int ReturnValue { get; set; }

	}
	#endregion spGetDbccValuesMultipleResults

	#region spGetDirClientsExtendedMultipleResults
	public partial class spGetDirClientsExtendedMultipleResults
	{
		public spGetDirClientsExtendedMultipleResults(){ }

		public List<DirClientExtended> Clients { get; set; }

		public int ReturnValue { get; set; }

	}
	#endregion spGetDirClientsExtendedMultipleResults

	#region spGetProductAdditionaInfoMultipleResults
	public partial class spGetProductAdditionaInfoMultipleResults
	{
		public spGetProductAdditionaInfoMultipleResults(){ }

		public List<spGetProductAdditionaInfoResult> Result1 { get; set; }

		public int ReturnValue { get; set; }

	}
	#endregion spGetProductAdditionaInfoMultipleResults

	#region spWeatherGetAccuweatherCitiesMultipleResults
	public partial class spWeatherGetAccuweatherCitiesMultipleResults
	{
		public spWeatherGetAccuweatherCitiesMultipleResults(){ }

		public List<spWeatherGetAccuweatherCitiesResult> Result1 { get; set; }

		public int ReturnValue { get; set; }

	}
	#endregion spWeatherGetAccuweatherCitiesMultipleResults

	#region spWeatherGetCurrentWeatherMultipleResults
	public partial class spWeatherGetCurrentWeatherMultipleResults
	{
		public spWeatherGetCurrentWeatherMultipleResults(){ }

		public List<spWeatherGetCurrentWeatherResult> Result1 { get; set; }

		public int ReturnValue { get; set; }

	}
	#endregion spWeatherGetCurrentWeatherMultipleResults

	#region spWeatherGetDailyWeatherMultipleResults
	public partial class spWeatherGetDailyWeatherMultipleResults
	{
		public spWeatherGetDailyWeatherMultipleResults(){ }

		public List<spWeatherGetDailyWeatherResult> Result1 { get; set; }

		public int ReturnValue { get; set; }

	}
	#endregion spWeatherGetDailyWeatherMultipleResults

	#region spWeatherGetHourlyWeatherMultipleResults
	public partial class spWeatherGetHourlyWeatherMultipleResults
	{
		public spWeatherGetHourlyWeatherMultipleResults(){ }

		public List<spWeatherGetHourlyWeatherResult> Result1 { get; set; }

		public int ReturnValue { get; set; }

	}
	#endregion spWeatherGetHourlyWeatherMultipleResults

	#region spWeatherGetMaxLastUpdateDateMultipleResults
	public partial class spWeatherGetMaxLastUpdateDateMultipleResults
	{
		public spWeatherGetMaxLastUpdateDateMultipleResults(){ }

		public List<spWeatherGetMaxLastUpdateDateResult> Result1 { get; set; }

		public int ReturnValue { get; set; }

	}
	#endregion spWeatherGetMaxLastUpdateDateMultipleResults

	#region spWeatherGetWeatherStatisticsMultipleResults
	public partial class spWeatherGetWeatherStatisticsMultipleResults
	{
		public spWeatherGetWeatherStatisticsMultipleResults(){ }

		public List<spWeatherGetWeatherStatisticsResult> Result1 { get; set; }

		public int ReturnValue { get; set; }

	}
	#endregion spWeatherGetWeatherStatisticsMultipleResults

	#region spGetAktivneUslugeResult
	public partial class spGetAktivneUslugeResult
	{
		public spGetAktivneUslugeResult(){ }

		/// <summary>
		/// DbType = "BigInt"
		/// </summary>
		public long? rowid { get; set; }

		/// <summary>
		/// DbType = "BigInt NOT NULL"
		/// </summary>
		public long BillFirmaID { get; set; }

		/// <summary>
		/// DbType = "BigInt NOT NULL"
		/// </summary>
		public long BillDocumentID { get; set; }

		/// <summary>
		/// DbType = "BigInt"
		/// </summary>
		public long? ParentBillDocumentID { get; set; }

		/// <summary>
		/// DbType = "BigInt"
		/// </summary>
		public long? DirClientID { get; set; }

		/// <summary>
		/// DbType = "BigInt NOT NULL"
		/// </summary>
		public long BillClientID { get; set; }

		/// <summary>
		/// DbType = "BigInt NOT NULL"
		/// </summary>
		public long BillNaplatniUredjajID { get; set; }

		/// <summary>
		/// DbType = "BigInt NOT NULL"
		/// </summary>
		public long BillProductID { get; set; }

		/// <summary>
		/// DbType = "Decimal(18,8) NOT NULL"
		/// </summary>
		public decimal Kolicina { get; set; }

		/// <summary>
		/// DbType = "Int NOT NULL"
		/// </summary>
		public int BillUslugaTipID { get; set; }

		/// <summary>
		/// DbType = "NVarChar(50) NOT NULL"
		/// </summary>
		public string UslugaNaziv { get; set; }

		/// <summary>
		/// DbType = "DateTime"
		/// </summary>
		public DateTime? DatumUplate { get; set; }

		/// <summary>
		/// DbType = "DateTime"
		/// </summary>
		public DateTime? StartDate { get; set; }

		/// <summary>
		/// DbType = "DateTime"
		/// </summary>
		public DateTime? EndDate { get; set; }

		/// <summary>
		/// DbType = "Int"
		/// </summary>
		public int? PrikazStatus { get; set; }

	}
	#endregion spGetAktivneUslugeResult

	#region spGetBillClientSaldoResult
	public partial class spGetBillClientSaldoResult
	{
		public spGetBillClientSaldoResult(){ }

		/// <summary>
		/// DbType = "BigInt NOT NULL"
		/// </summary>
		public long BillClientID { get; set; }

		/// <summary>
		/// DbType = "Money"
		/// </summary>
		public decimal? UkupnoUplata { get; set; }

		/// <summary>
		/// DbType = "Money"
		/// </summary>
		public decimal? UkupnoIsplata { get; set; }

		/// <summary>
		/// DbType = "Money"
		/// </summary>
		public decimal? Ballance { get; set; }

		/// <summary>
		/// DbType = "Decimal(38,8)"
		/// </summary>
		public decimal? IzdaniNaplatniRacuni { get; set; }

		/// <summary>
		/// DbType = "Decimal(38,8)"
		/// </summary>
		public decimal? IzdaniStornoRacuni { get; set; }

		/// <summary>
		/// DbType = "Decimal(38,8)"
		/// </summary>
		public decimal? Neproknjizeno { get; set; }

		/// <summary>
		/// DbType = "Decimal(38,8)"
		/// </summary>
		public decimal? ZaduzenjePonude { get; set; }

		/// <summary>
		/// DbType = "Decimal(38,8)"
		/// </summary>
		public decimal? ZaduzenjeRacuni { get; set; }

		/// <summary>
		/// DbType = "Decimal(38,8)"
		/// </summary>
		public decimal? ZaduzenjeStorno { get; set; }

		/// <summary>
		/// DbType = "Decimal(38,8)"
		/// </summary>
		public decimal? ZaduzenjeUkupno { get; set; }

		/// <summary>
		/// DbType = "Decimal(38,8)"
		/// </summary>
		public decimal? Dug { get; set; }

		/// <summary>
		/// DbType = "Bit"
		/// </summary>
		public bool? AllowKnjizenje { get; set; }

	}
	#endregion spGetBillClientSaldoResult

	#region spGetDbccValuesResult
	public partial class spGetDbccValuesResult
	{
		public spGetDbccValuesResult(){ }

		/// <summary>
		/// DbType = "NVarChar(100)"
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// DbType = "NVarChar(100)"
		/// </summary>
		public string Value { get; set; }

	}
	#endregion spGetDbccValuesResult

	#region spGetProductAdditionaInfoResult
	public partial class spGetProductAdditionaInfoResult
	{
		public spGetProductAdditionaInfoResult(){ }

		/// <summary>
		/// DbType = "BigInt NOT NULL"
		/// </summary>
		public long BillProductID { get; set; }

		/// <summary>
		/// DbType = "BigInt"
		/// </summary>
		public long? BillCategoryID { get; set; }

		/// <summary>
		/// DbType = "VarChar(100)"
		/// </summary>
		public string MjeraNaziv { get; set; }

		/// <summary>
		/// DbType = "VarChar(100)"
		/// </summary>
		public string MjeraKratkiNaziv { get; set; }

		/// <summary>
		/// DbType = "NVarChar(100)"
		/// </summary>
		public string PoreznaGrupaNaziv { get; set; }

	}
	#endregion spGetProductAdditionaInfoResult

	#region spWeatherGetAccuweatherCitiesResult
	public partial class spWeatherGetAccuweatherCitiesResult
	{
		public spWeatherGetAccuweatherCitiesResult(){ }

		/// <summary>
		/// DbType = "Int NOT NULL"
		/// </summary>
		public int WeatherCityID { get; set; }

		/// <summary>
		/// DbType = "NVarChar(100) NOT NULL"
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// DbType = "NVarChar(200)"
		/// </summary>
		public string LongName { get; set; }

		/// <summary>
		/// DbType = "VarChar(50)"
		/// </summary>
		public string AccuweatherCode { get; set; }

		/// <summary>
		/// DbType = "VarChar(10) NOT NULL"
		/// </summary>
		public string Language { get; set; }

		/// <summary>
		/// DbType = "Bit NOT NULL"
		/// </summary>
		public bool DownloadAccuweather { get; set; }

		/// <summary>
		/// DbType = "VarChar(100) NOT NULL"
		/// </summary>
		public string UrlName { get; set; }

		/// <summary>
		/// DbType = "Int"
		/// </summary>
		public int? Population { get; set; }

		/// <summary>
		/// DbType = "Decimal(18,10)"
		/// </summary>
		public decimal? Latitude { get; set; }

		/// <summary>
		/// DbType = "Decimal(18,10)"
		/// </summary>
		public decimal? Longitude { get; set; }

	}
	#endregion spWeatherGetAccuweatherCitiesResult

	#region spWeatherGetCurrentWeatherResult
	public partial class spWeatherGetCurrentWeatherResult
	{
		public spWeatherGetCurrentWeatherResult(){ }

		/// <summary>
		/// DbType = "BigInt NOT NULL"
		/// </summary>
		public long WeatherInfoID { get; set; }

		/// <summary>
		/// DbType = "Int NOT NULL"
		/// </summary>
		public int WeatherCityID { get; set; }

		/// <summary>
		/// DbType = "NVarChar(10) NOT NULL"
		/// </summary>
		public string Language { get; set; }

		/// <summary>
		/// DbType = "DateTime NOT NULL"
		/// </summary>
		public DateTime LastUpdateDate { get; set; }

		/// <summary>
		/// DbType = "DateTime NOT NULL"
		/// </summary>
		public DateTime WeatherDate { get; set; }

		/// <summary>
		/// DbType = "Int NOT NULL"
		/// </summary>
		public int WeatherKindID { get; set; }

		/// <summary>
		/// DbType = "Decimal(5,2)"
		/// </summary>
		public decimal? Temperature { get; set; }

		/// <summary>
		/// DbType = "Char(1)"
		/// </summary>
		public string TemperatureUnits { get; set; }

		/// <summary>
		/// DbType = "Decimal(5,2)"
		/// </summary>
		public decimal? RealFeel { get; set; }

		/// <summary>
		/// DbType = "Decimal(5,2)"
		/// </summary>
		public decimal? RealFeelShade { get; set; }

		/// <summary>
		/// DbType = "Int"
		/// </summary>
		public int? IconValue { get; set; }

		/// <summary>
		/// DbType = "NVarChar(500)"
		/// </summary>
		public string ShortDescription { get; set; }

		/// <summary>
		/// DbType = "NVarChar(20)"
		/// </summary>
		public string UVIndex { get; set; }

		/// <summary>
		/// DbType = "NVarChar(20)"
		/// </summary>
		public string Wind { get; set; }

		/// <summary>
		/// DbType = "VarChar(20)"
		/// </summary>
		public string WindGusts { get; set; }

		/// <summary>
		/// DbType = "VarChar(20)"
		/// </summary>
		public string ProbabilityOfPrecipitation { get; set; }

		/// <summary>
		/// DbType = "VarChar(20)"
		/// </summary>
		public string ProbabilityOfThunderstorms { get; set; }

		/// <summary>
		/// DbType = "VarChar(20)"
		/// </summary>
		public string Precipitation { get; set; }

		/// <summary>
		/// DbType = "VarChar(20)"
		/// </summary>
		public string Rain { get; set; }

		/// <summary>
		/// DbType = "VarChar(20)"
		/// </summary>
		public string Snow { get; set; }

		/// <summary>
		/// DbType = "VarChar(20)"
		/// </summary>
		public string Ice { get; set; }

		/// <summary>
		/// DbType = "VarChar(20)"
		/// </summary>
		public string HoursOfPrecipitation { get; set; }

		/// <summary>
		/// DbType = "VarChar(20)"
		/// </summary>
		public string HoursOfRain { get; set; }

		/// <summary>
		/// DbType = "VarChar(20)"
		/// </summary>
		public string Humidity { get; set; }

		/// <summary>
		/// DbType = "VarChar(20)"
		/// </summary>
		public string DewPoint { get; set; }

		/// <summary>
		/// DbType = "VarChar(20)"
		/// </summary>
		public string Pressure { get; set; }

		/// <summary>
		/// DbType = "VarChar(20)"
		/// </summary>
		public string CloudCover { get; set; }

		/// <summary>
		/// DbType = "VarChar(20)"
		/// </summary>
		public string Visibility { get; set; }

		/// <summary>
		/// DbType = "VarChar(20)"
		/// </summary>
		public string Ceiling { get; set; }

		/// <summary>
		/// DbType = "VarChar(20)"
		/// </summary>
		public string AirQuality { get; set; }

	}
	#endregion spWeatherGetCurrentWeatherResult

	#region spWeatherGetDailyWeatherResult
	public partial class spWeatherGetDailyWeatherResult
	{
		public spWeatherGetDailyWeatherResult(){ }

		/// <summary>
		/// DbType = "BigInt NOT NULL"
		/// </summary>
		public long WeatherInfoID { get; set; }

		/// <summary>
		/// DbType = "Int NOT NULL"
		/// </summary>
		public int WeatherCityID { get; set; }

		/// <summary>
		/// DbType = "NVarChar(10) NOT NULL"
		/// </summary>
		public string Language { get; set; }

		/// <summary>
		/// DbType = "DateTime NOT NULL"
		/// </summary>
		public DateTime LastUpdateDate { get; set; }

		/// <summary>
		/// DbType = "DateTime NOT NULL"
		/// </summary>
		public DateTime WeatherDate { get; set; }

		/// <summary>
		/// DbType = "Int NOT NULL"
		/// </summary>
		public int WeatherKindID { get; set; }

		/// <summary>
		/// DbType = "Decimal(5,2)"
		/// </summary>
		public decimal? Temperature { get; set; }

		/// <summary>
		/// DbType = "Char(1)"
		/// </summary>
		public string TemperatureUnits { get; set; }

		/// <summary>
		/// DbType = "Decimal(5,2)"
		/// </summary>
		public decimal? RealFeel { get; set; }

		/// <summary>
		/// DbType = "Decimal(5,2)"
		/// </summary>
		public decimal? RealFeelShade { get; set; }

		/// <summary>
		/// DbType = "Int"
		/// </summary>
		public int? IconValue { get; set; }

		/// <summary>
		/// DbType = "NVarChar(500)"
		/// </summary>
		public string ShortDescription { get; set; }

		/// <summary>
		/// DbType = "NVarChar(20)"
		/// </summary>
		public string UVIndex { get; set; }

		/// <summary>
		/// DbType = "NVarChar(20)"
		/// </summary>
		public string Wind { get; set; }

		/// <summary>
		/// DbType = "VarChar(20)"
		/// </summary>
		public string WindGusts { get; set; }

		/// <summary>
		/// DbType = "VarChar(20)"
		/// </summary>
		public string ProbabilityOfPrecipitation { get; set; }

		/// <summary>
		/// DbType = "VarChar(20)"
		/// </summary>
		public string ProbabilityOfThunderstorms { get; set; }

		/// <summary>
		/// DbType = "VarChar(20)"
		/// </summary>
		public string Precipitation { get; set; }

		/// <summary>
		/// DbType = "VarChar(20)"
		/// </summary>
		public string Rain { get; set; }

		/// <summary>
		/// DbType = "VarChar(20)"
		/// </summary>
		public string Snow { get; set; }

		/// <summary>
		/// DbType = "VarChar(20)"
		/// </summary>
		public string Ice { get; set; }

		/// <summary>
		/// DbType = "VarChar(20)"
		/// </summary>
		public string HoursOfPrecipitation { get; set; }

		/// <summary>
		/// DbType = "VarChar(20)"
		/// </summary>
		public string HoursOfRain { get; set; }

		/// <summary>
		/// DbType = "VarChar(20)"
		/// </summary>
		public string Humidity { get; set; }

		/// <summary>
		/// DbType = "VarChar(20)"
		/// </summary>
		public string DewPoint { get; set; }

		/// <summary>
		/// DbType = "VarChar(20)"
		/// </summary>
		public string Pressure { get; set; }

		/// <summary>
		/// DbType = "VarChar(20)"
		/// </summary>
		public string CloudCover { get; set; }

		/// <summary>
		/// DbType = "VarChar(20)"
		/// </summary>
		public string Visibility { get; set; }

		/// <summary>
		/// DbType = "VarChar(20)"
		/// </summary>
		public string Ceiling { get; set; }

		/// <summary>
		/// DbType = "VarChar(20)"
		/// </summary>
		public string AirQuality { get; set; }

	}
	#endregion spWeatherGetDailyWeatherResult

	#region spWeatherGetHourlyWeatherResult
	public partial class spWeatherGetHourlyWeatherResult
	{
		public spWeatherGetHourlyWeatherResult(){ }

		/// <summary>
		/// DbType = "BigInt NOT NULL"
		/// </summary>
		public long WeatherInfoID { get; set; }

		/// <summary>
		/// DbType = "Int NOT NULL"
		/// </summary>
		public int WeatherCityID { get; set; }

		/// <summary>
		/// DbType = "NVarChar(10) NOT NULL"
		/// </summary>
		public string Language { get; set; }

		/// <summary>
		/// DbType = "DateTime NOT NULL"
		/// </summary>
		public DateTime LastUpdateDate { get; set; }

		/// <summary>
		/// DbType = "DateTime NOT NULL"
		/// </summary>
		public DateTime WeatherDate { get; set; }

		/// <summary>
		/// DbType = "Int NOT NULL"
		/// </summary>
		public int WeatherKindID { get; set; }

		/// <summary>
		/// DbType = "Decimal(5,2)"
		/// </summary>
		public decimal? Temperature { get; set; }

		/// <summary>
		/// DbType = "Char(1)"
		/// </summary>
		public string TemperatureUnits { get; set; }

		/// <summary>
		/// DbType = "Decimal(5,2)"
		/// </summary>
		public decimal? RealFeel { get; set; }

		/// <summary>
		/// DbType = "Decimal(5,2)"
		/// </summary>
		public decimal? RealFeelShade { get; set; }

		/// <summary>
		/// DbType = "Int"
		/// </summary>
		public int? IconValue { get; set; }

		/// <summary>
		/// DbType = "NVarChar(500)"
		/// </summary>
		public string ShortDescription { get; set; }

		/// <summary>
		/// DbType = "NVarChar(20)"
		/// </summary>
		public string UVIndex { get; set; }

		/// <summary>
		/// DbType = "NVarChar(20)"
		/// </summary>
		public string Wind { get; set; }

		/// <summary>
		/// DbType = "VarChar(20)"
		/// </summary>
		public string WindGusts { get; set; }

		/// <summary>
		/// DbType = "VarChar(20)"
		/// </summary>
		public string ProbabilityOfPrecipitation { get; set; }

		/// <summary>
		/// DbType = "VarChar(20)"
		/// </summary>
		public string ProbabilityOfThunderstorms { get; set; }

		/// <summary>
		/// DbType = "VarChar(20)"
		/// </summary>
		public string Precipitation { get; set; }

		/// <summary>
		/// DbType = "VarChar(20)"
		/// </summary>
		public string Rain { get; set; }

		/// <summary>
		/// DbType = "VarChar(20)"
		/// </summary>
		public string Snow { get; set; }

		/// <summary>
		/// DbType = "VarChar(20)"
		/// </summary>
		public string Ice { get; set; }

		/// <summary>
		/// DbType = "VarChar(20)"
		/// </summary>
		public string HoursOfPrecipitation { get; set; }

		/// <summary>
		/// DbType = "VarChar(20)"
		/// </summary>
		public string HoursOfRain { get; set; }

		/// <summary>
		/// DbType = "VarChar(20)"
		/// </summary>
		public string Humidity { get; set; }

		/// <summary>
		/// DbType = "VarChar(20)"
		/// </summary>
		public string DewPoint { get; set; }

		/// <summary>
		/// DbType = "VarChar(20)"
		/// </summary>
		public string Pressure { get; set; }

		/// <summary>
		/// DbType = "VarChar(20)"
		/// </summary>
		public string CloudCover { get; set; }

		/// <summary>
		/// DbType = "VarChar(20)"
		/// </summary>
		public string Visibility { get; set; }

		/// <summary>
		/// DbType = "VarChar(20)"
		/// </summary>
		public string Ceiling { get; set; }

		/// <summary>
		/// DbType = "VarChar(20)"
		/// </summary>
		public string AirQuality { get; set; }

	}
	#endregion spWeatherGetHourlyWeatherResult

	#region spWeatherGetMaxLastUpdateDateResult
	public partial class spWeatherGetMaxLastUpdateDateResult
	{
		public spWeatherGetMaxLastUpdateDateResult(){ }

		/// <summary>
		/// DbType = "Int NOT NULL"
		/// </summary>
		public int WeatherCityID { get; set; }

		/// <summary>
		/// DbType = "Int NOT NULL"
		/// </summary>
		public int WeatherKindID { get; set; }

		/// <summary>
		/// DbType = "DateTime"
		/// </summary>
		public DateTime? MaxLastUpdateDate { get; set; }

	}
	#endregion spWeatherGetMaxLastUpdateDateResult

	#region spWeatherGetWeatherStatisticsResult
	public partial class spWeatherGetWeatherStatisticsResult
	{
		public spWeatherGetWeatherStatisticsResult(){ }

		/// <summary>
		/// DbType = "Int NOT NULL"
		/// </summary>
		public int WeatherCityID { get; set; }

		/// <summary>
		/// DbType = "NVarChar(100) NOT NULL"
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// DbType = "NVarChar(200)"
		/// </summary>
		public string LongName { get; set; }

		/// <summary>
		/// DbType = "VarChar(50)"
		/// </summary>
		public string AccuweatherCode { get; set; }

		/// <summary>
		/// DbType = "Bit NOT NULL"
		/// </summary>
		public bool DownloadAccuweather { get; set; }

		/// <summary>
		/// DbType = "Int"
		/// </summary>
		public int? CurrentCnt { get; set; }

		/// <summary>
		/// DbType = "Int"
		/// </summary>
		public int? CurrentValid { get; set; }

		/// <summary>
		/// DbType = "Int"
		/// </summary>
		public int? HourlyCnt { get; set; }

		/// <summary>
		/// DbType = "Int"
		/// </summary>
		public int? HourlyValid { get; set; }

		/// <summary>
		/// DbType = "Int"
		/// </summary>
		public int? DailyCnt { get; set; }

		/// <summary>
		/// DbType = "Int"
		/// </summary>
		public int? DailyValid { get; set; }

	}
	#endregion spWeatherGetWeatherStatisticsResult

	#endregion

}
