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

namespace ArizonaDatabases.ArizonaApp.Database
{
	[DatabaseAttribute(Name="dbArizonaApp")]
	public partial class dbArizonaAppDataContext : Calysto.Data.Linq.DataContext
	{
		private static MappingSource mappingSource = new AttributeMappingSource();

		#region Extensibility Method Definitions
		partial void OnCreated();
		#endregion Extensibility Method Definitions

		#region Context constructors

		public dbArizonaAppDataContext(string connection) : base(connection, mappingSource)
		{
			OnCreated();
		}

		public dbArizonaAppDataContext(IDbConnection connection) : base(connection, mappingSource)
		{
			OnCreated();
		}

		public dbArizonaAppDataContext(string connection, MappingSource mappingSource) : base(connection, mappingSource)
		{
			OnCreated();
		}

		public dbArizonaAppDataContext(IDbConnection connection, MappingSource mappingSource) : base(connection, mappingSource)
		{
			OnCreated();
		}
		#endregion Context constructors

		#region Context properties for tables
		public Calysto.Data.Linq.Table<tblAppConfig> tblAppConfig { get { return this.GetTable<tblAppConfig>(); } }
		public Calysto.Data.Linq.Table<tblAppMember> tblAppMember { get { return this.GetTable<tblAppMember>(); } }
		public Calysto.Data.Linq.Table<tblAppMemberPermission> tblAppMemberPermission { get { return this.GetTable<tblAppMemberPermission>(); } }
		public Calysto.Data.Linq.Table<tblAppMemberPicture> tblAppMemberPicture { get { return this.GetTable<tblAppMemberPicture>(); } }
		public Calysto.Data.Linq.Table<tblAppMemberStatus> tblAppMemberStatus { get { return this.GetTable<tblAppMemberStatus>(); } }
		public Calysto.Data.Linq.Table<tblAppNewsletter> tblAppNewsletter { get { return this.GetTable<tblAppNewsletter>(); } }
		public Calysto.Data.Linq.Table<tblAppSchedule> tblAppSchedule { get { return this.GetTable<tblAppSchedule>(); } }
		public Calysto.Data.Linq.Table<tblAppScheduleType> tblAppScheduleType { get { return this.GetTable<tblAppScheduleType>(); } }
		public Calysto.Data.Linq.Table<tblBanka> tblBanka { get { return this.GetTable<tblBanka>(); } }
		public Calysto.Data.Linq.Table<tblBankaPromet> tblBankaPromet { get { return this.GetTable<tblBankaPromet>(); } }
		public Calysto.Data.Linq.Table<tblBankaPrometDocument> tblBankaPrometDocument { get { return this.GetTable<tblBankaPrometDocument>(); } }
		public Calysto.Data.Linq.Table<tblBankaPrometVrsta> tblBankaPrometVrsta { get { return this.GetTable<tblBankaPrometVrsta>(); } }
		public Calysto.Data.Linq.Table<tblBillCategory> tblBillCategory { get { return this.GetTable<tblBillCategory>(); } }
		public Calysto.Data.Linq.Table<tblBillClient> tblBillClient { get { return this.GetTable<tblBillClient>(); } }
		public Calysto.Data.Linq.Table<tblBillClientFullText> tblBillClientFullText { get { return this.GetTable<tblBillClientFullText>(); } }
		public Calysto.Data.Linq.Table<tblBillDocument> tblBillDocument { get { return this.GetTable<tblBillDocument>(); } }
		public Calysto.Data.Linq.Table<tblBillDocumentCalculated> tblBillDocumentCalculated { get { return this.GetTable<tblBillDocumentCalculated>(); } }
		public Calysto.Data.Linq.Table<tblBillDocumentRedniBroj> tblBillDocumentRedniBroj { get { return this.GetTable<tblBillDocumentRedniBroj>(); } }
		public Calysto.Data.Linq.Table<tblBillDocumentStavka> tblBillDocumentStavka { get { return this.GetTable<tblBillDocumentStavka>(); } }
		public Calysto.Data.Linq.Table<tblBillDocumentTip> tblBillDocumentTip { get { return this.GetTable<tblBillDocumentTip>(); } }
		public Calysto.Data.Linq.Table<tblBillDocumentVariant> tblBillDocumentVariant { get { return this.GetTable<tblBillDocumentVariant>(); } }
		public Calysto.Data.Linq.Table<tblBillDownloadLog> tblBillDownloadLog { get { return this.GetTable<tblBillDownloadLog>(); } }
		public Calysto.Data.Linq.Table<tblBillFirma> tblBillFirma { get { return this.GetTable<tblBillFirma>(); } }
		public Calysto.Data.Linq.Table<tblBillFirmaCertificate> tblBillFirmaCertificate { get { return this.GetTable<tblBillFirmaCertificate>(); } }
		public Calysto.Data.Linq.Table<tblBillFirmaCertificateMode> tblBillFirmaCertificateMode { get { return this.GetTable<tblBillFirmaCertificateMode>(); } }
		public Calysto.Data.Linq.Table<tblBillFirmaPos> tblBillFirmaPos { get { return this.GetTable<tblBillFirmaPos>(); } }
		public Calysto.Data.Linq.Table<tblBillFirmaTransakcijskiRacun> tblBillFirmaTransakcijskiRacun { get { return this.GetTable<tblBillFirmaTransakcijskiRacun>(); } }
		public Calysto.Data.Linq.Table<tblBillFirmaTransakcijskiRacunEmail> tblBillFirmaTransakcijskiRacunEmail { get { return this.GetTable<tblBillFirmaTransakcijskiRacunEmail>(); } }
		public Calysto.Data.Linq.Table<tblBillMjera> tblBillMjera { get { return this.GetTable<tblBillMjera>(); } }
		public Calysto.Data.Linq.Table<tblBillNaplatniUredjaj> tblBillNaplatniUredjaj { get { return this.GetTable<tblBillNaplatniUredjaj>(); } }
		public Calysto.Data.Linq.Table<tblBillOperator> tblBillOperator { get { return this.GetTable<tblBillOperator>(); } }
		public Calysto.Data.Linq.Table<tblBillPaymentMethod> tblBillPaymentMethod { get { return this.GetTable<tblBillPaymentMethod>(); } }
		public Calysto.Data.Linq.Table<tblBillPoreznaGrupa> tblBillPoreznaGrupa { get { return this.GetTable<tblBillPoreznaGrupa>(); } }
		public Calysto.Data.Linq.Table<tblBillPoslovniProstor> tblBillPoslovniProstor { get { return this.GetTable<tblBillPoslovniProstor>(); } }
		public Calysto.Data.Linq.Table<tblBillPrintLog> tblBillPrintLog { get { return this.GetTable<tblBillPrintLog>(); } }
		public Calysto.Data.Linq.Table<tblBillProduct> tblBillProduct { get { return this.GetTable<tblBillProduct>(); } }
		public Calysto.Data.Linq.Table<tblBillProductCategory> tblBillProductCategory { get { return this.GetTable<tblBillProductCategory>(); } }
		public Calysto.Data.Linq.Table<tblBillProductNormativ> tblBillProductNormativ { get { return this.GetTable<tblBillProductNormativ>(); } }
		public Calysto.Data.Linq.Table<tblBillUslugaTip> tblBillUslugaTip { get { return this.GetTable<tblBillUslugaTip>(); } }
		public Calysto.Data.Linq.Table<tblBookkeepingFiduciaExport> tblBookkeepingFiduciaExport { get { return this.GetTable<tblBookkeepingFiduciaExport>(); } }
		public Calysto.Data.Linq.Table<tblBookkeepingSynesisExport> tblBookkeepingSynesisExport { get { return this.GetTable<tblBookkeepingSynesisExport>(); } }
		public Calysto.Data.Linq.Table<tblCache> tblCache { get { return this.GetTable<tblCache>(); } }
		public Calysto.Data.Linq.Table<tblDirClient> tblDirClient { get { return this.GetTable<tblDirClient>(); } }
		public Calysto.Data.Linq.Table<tblDirClientBlacklist> tblDirClientBlacklist { get { return this.GetTable<tblDirClientBlacklist>(); } }
		public Calysto.Data.Linq.Table<tblDirClientFullText> tblDirClientFullText { get { return this.GetTable<tblDirClientFullText>(); } }
		public Calysto.Data.Linq.Table<tblDirClientGratis> tblDirClientGratis { get { return this.GetTable<tblDirClientGratis>(); } }
		public Calysto.Data.Linq.Table<tblDirClientPhone> tblDirClientPhone { get { return this.GetTable<tblDirClientPhone>(); } }
		public Calysto.Data.Linq.Table<tblDirClientPicture> tblDirClientPicture { get { return this.GetTable<tblDirClientPicture>(); } }
		public Calysto.Data.Linq.Table<tblDirClientPrikazStatus> tblDirClientPrikazStatus { get { return this.GetTable<tblDirClientPrikazStatus>(); } }
		public Calysto.Data.Linq.Table<tblDirClientVracenaPosta> tblDirClientVracenaPosta { get { return this.GetTable<tblDirClientVracenaPosta>(); } }
		public Calysto.Data.Linq.Table<tblDirPrikazStatus> tblDirPrikazStatus { get { return this.GetTable<tblDirPrikazStatus>(); } }
		public Calysto.Data.Linq.Table<tblDirRegistration> tblDirRegistration { get { return this.GetTable<tblDirRegistration>(); } }
		public Calysto.Data.Linq.Table<tblEmailOutbox> tblEmailOutbox { get { return this.GetTable<tblEmailOutbox>(); } }
		public Calysto.Data.Linq.Table<tblFiskalRacunZahtjevLog> tblFiskalRacunZahtjevLog { get { return this.GetTable<tblFiskalRacunZahtjevLog>(); } }
		public Calysto.Data.Linq.Table<tblJobAdvert> tblJobAdvert { get { return this.GetTable<tblJobAdvert>(); } }
		public Calysto.Data.Linq.Table<tblJobApplication> tblJobApplication { get { return this.GetTable<tblJobApplication>(); } }
		public Calysto.Data.Linq.Table<tblJobApplicationDocument> tblJobApplicationDocument { get { return this.GetTable<tblJobApplicationDocument>(); } }
		public Calysto.Data.Linq.Table<tblJobApplicationImage> tblJobApplicationImage { get { return this.GetTable<tblJobApplicationImage>(); } }
		public Calysto.Data.Linq.Table<tblJobApplicationNote> tblJobApplicationNote { get { return this.GetTable<tblJobApplicationNote>(); } }
		public Calysto.Data.Linq.Table<tblJobApplicationSchedule> tblJobApplicationSchedule { get { return this.GetTable<tblJobApplicationSchedule>(); } }
		public Calysto.Data.Linq.Table<tblJobApplicationStatus> tblJobApplicationStatus { get { return this.GetTable<tblJobApplicationStatus>(); } }
		public Calysto.Data.Linq.Table<tblJobTemplate> tblJobTemplate { get { return this.GetTable<tblJobTemplate>(); } }
		public Calysto.Data.Linq.Table<tblJobTemplateKind> tblJobTemplateKind { get { return this.GetTable<tblJobTemplateKind>(); } }
		public Calysto.Data.Linq.Table<tblPorezPdv> tblPorezPdv { get { return this.GetTable<tblPorezPdv>(); } }
		public Calysto.Data.Linq.Table<tblPorezPdvPostotak> tblPorezPdvPostotak { get { return this.GetTable<tblPorezPdvPostotak>(); } }
		public Calysto.Data.Linq.Table<tblPorezPotrosnja> tblPorezPotrosnja { get { return this.GetTable<tblPorezPotrosnja>(); } }
		public Calysto.Data.Linq.Table<tblPorezPotrosnjaPostotak> tblPorezPotrosnjaPostotak { get { return this.GetTable<tblPorezPotrosnjaPostotak>(); } }
		public Calysto.Data.Linq.Table<tblPozivLog> tblPozivLog { get { return this.GetTable<tblPozivLog>(); } }
		public Calysto.Data.Linq.Table<tblSmsOutbox> tblSmsOutbox { get { return this.GetTable<tblSmsOutbox>(); } }
		public Calysto.Data.Linq.Table<tblSocialMember> tblSocialMember { get { return this.GetTable<tblSocialMember>(); } }
		public Calysto.Data.Linq.Table<tblSocialMemberBillClient> tblSocialMemberBillClient { get { return this.GetTable<tblSocialMemberBillClient>(); } }
		public Calysto.Data.Linq.Table<tblSocialMemberStatus> tblSocialMemberStatus { get { return this.GetTable<tblSocialMemberStatus>(); } }
		public Calysto.Data.Linq.Table<tblSocialProvider> tblSocialProvider { get { return this.GetTable<tblSocialProvider>(); } }
		public Calysto.Data.Linq.Table<tblTask> tblTask { get { return this.GetTable<tblTask>(); } }
		public Calysto.Data.Linq.Table<tblTaskSchedule> tblTaskSchedule { get { return this.GetTable<tblTaskSchedule>(); } }
		public Calysto.Data.Linq.Table<tblTaskScheduleLog> tblTaskScheduleLog { get { return this.GetTable<tblTaskScheduleLog>(); } }
		public Calysto.Data.Linq.Table<viewBookkeepingFiduciaExport> viewBookkeepingFiduciaExport { get { return this.GetTable<viewBookkeepingFiduciaExport>(); } }
		public Calysto.Data.Linq.Table<viewBookkeepingSynesisExport> viewBookkeepingSynesisExport { get { return this.GetTable<viewBookkeepingSynesisExport>(); } }
		public Calysto.Data.Linq.Table<viewRandom> viewRandom { get { return this.GetTable<viewRandom>(); } }
		#endregion Context properties for tables

		#region Context database functions
		[FunctionAttribute(Name="dbo.fnAddPaddingSpace", IsComposable=true)]
		public string fnAddPaddingSpace(
			[ParameterAttribute(DbType="NVarChar(MAX)")] string str,
			[ParameterAttribute(DbType="Int")] int? expectedLength,
			[ParameterAttribute(DbType="Bit")] bool? addPrefix
		)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), str, expectedLength, addPrefix);
			return ((string) result.ReturnValue);
		}

		[FunctionAttribute(Name="dbo.fnCalculateBankaPrometOsnovicaAndPdv", IsComposable=true)]
		public ISingleResult<fnCalculateBankaPrometOsnovicaAndPdvResult> fnCalculateBankaPrometOsnovicaAndPdv(
			[ParameterAttribute(DbType="BigInt")] long? billFirmaID,
			[ParameterAttribute(DbType="DateTime")] DateTime? datum,
			[ParameterAttribute(DbType="Money")] decimal? iznos
		)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), billFirmaID, datum, iznos);
			return ((ISingleResult<fnCalculateBankaPrometOsnovicaAndPdvResult>) result.ReturnValue);
		}

		[FunctionAttribute(Name="dbo.fnCalculateDatumValuteRokPlacanja", IsComposable=true)]
		public ISingleResult<fnCalculateDatumValuteRokPlacanjaResult> fnCalculateDatumValuteRokPlacanja(
			[ParameterAttribute(DbType="DateTime")] DateTime? nowDate,
			[ParameterAttribute(DbType="Int")] int? brojDanaZaUplatu
		)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), nowDate, brojDanaZaUplatu);
			return ((ISingleResult<fnCalculateDatumValuteRokPlacanjaResult>) result.ReturnValue);
		}

		[FunctionAttribute(Name="dbo.fnCalculateDocumentNaknade", IsComposable=true)]
		public ISingleResult<fnCalculateDocumentNaknadeResult> fnCalculateDocumentNaknade(
			[ParameterAttribute(DbType="BigInt")] long? billDocumentID
		)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), billDocumentID);
			return ((ISingleResult<fnCalculateDocumentNaknadeResult>) result.ReturnValue);
		}

		[FunctionAttribute(Name="dbo.fnCalculateDocumentPorezOstali", IsComposable=true)]
		public ISingleResult<fnCalculateDocumentPorezOstaliResult> fnCalculateDocumentPorezOstali(
			[ParameterAttribute(DbType="BigInt")] long? billDocumentID
		)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), billDocumentID);
			return ((ISingleResult<fnCalculateDocumentPorezOstaliResult>) result.ReturnValue);
		}

		[FunctionAttribute(Name="dbo.fnCalculateDocumentPorezPdv", IsComposable=true)]
		public ISingleResult<fnCalculateDocumentPorezPdvResult> fnCalculateDocumentPorezPdv(
			[ParameterAttribute(DbType="BigInt")] long? billDocumentID
		)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), billDocumentID);
			return ((ISingleResult<fnCalculateDocumentPorezPdvResult>) result.ReturnValue);
		}

		[FunctionAttribute(Name="dbo.fnCalculateDocumentPorezPotrosnja", IsComposable=true)]
		public ISingleResult<fnCalculateDocumentPorezPotrosnjaResult> fnCalculateDocumentPorezPotrosnja(
			[ParameterAttribute(DbType="BigInt")] long? billDocumentID
		)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), billDocumentID);
			return ((ISingleResult<fnCalculateDocumentPorezPotrosnjaResult>) result.ReturnValue);
		}

		[FunctionAttribute(Name="dbo.fnCalculateDocumentStavke", IsComposable=true)]
		public ISingleResult<fnCalculateDocumentStavkeResult> fnCalculateDocumentStavke(
			[ParameterAttribute(DbType="BigInt")] long? billDocumentID
		)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), billDocumentID);
			return ((ISingleResult<fnCalculateDocumentStavkeResult>) result.ReturnValue);
		}

		[FunctionAttribute(Name="dbo.fnCalculateDocumentTotals", IsComposable=true)]
		public ISingleResult<fnCalculateDocumentTotalsResult> fnCalculateDocumentTotals(
			[ParameterAttribute(DbType="BigInt")] long? billDocumentID
		)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), billDocumentID);
			return ((ISingleResult<fnCalculateDocumentTotalsResult>) result.ReturnValue);
		}

		[FunctionAttribute(Name="dbo.fnCalculateFiskalniBrojRacuna", IsComposable=true)]
		public string fnCalculateFiskalniBrojRacuna(
			[ParameterAttribute(DbType="NVarChar(30)")] string pozivNaBroj
		)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), pozivNaBroj);
			return ((string) result.ReturnValue);
		}

		[FunctionAttribute(Name="dbo.fnCalculatePozivNaBroj", IsComposable=true)]
		public string fnCalculatePozivNaBroj(
			[ParameterAttribute(DbType="BigInt")] long? billNaplatniUredjajID,
			[ParameterAttribute(DbType="DateTime")] DateTime? datumDokumenta,
			[ParameterAttribute(DbType="Int")] int? redniBroj
		)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), billNaplatniUredjajID, datumDokumenta, redniBroj);
			return ((string) result.ReturnValue);
		}

		[FunctionAttribute(Name="dbo.fnCalculatePozivNaBrojChecksum", IsComposable=true)]
		public string fnCalculatePozivNaBrojChecksum(
			[ParameterAttribute(DbType="NVarChar(100)")] string pozivNaBrojBezChecksuma
		)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), pozivNaBrojBezChecksuma);
			return ((string) result.ReturnValue);
		}

		[FunctionAttribute(Name="dbo.fnCLRCsvArgsToIntTable", IsComposable=true)]
		public ISingleResult<fnCLRCsvArgsToIntTableResult> fnCLRCsvArgsToIntTable(
			[ParameterAttribute(DbType="NVarChar(MAX)")] string str1
		)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), str1);
			return ((ISingleResult<fnCLRCsvArgsToIntTableResult>) result.ReturnValue);
		}

		[FunctionAttribute(Name="dbo.fnCLRCsvArgsToWordsTable", IsComposable=true)]
		public ISingleResult<fnCLRCsvArgsToWordsTableResult> fnCLRCsvArgsToWordsTable(
			[ParameterAttribute(DbType="NVarChar(MAX)")] string str1
		)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), str1);
			return ((ISingleResult<fnCLRCsvArgsToWordsTableResult>) result.ReturnValue);
		}

		[FunctionAttribute(Name="dbo.fnCLRGetDistinctWordsString", IsComposable=true)]
		public string fnCLRGetDistinctWordsString(
			[ParameterAttribute(DbType="NVarChar(MAX)")] string str1,
			[ParameterAttribute(DbType="Int")] int? wordMinlength,
			[ParameterAttribute(DbType="Int")] int? finalMaxlength
		)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), str1, wordMinlength, finalMaxlength);
			return ((string) result.ReturnValue);
		}

		[FunctionAttribute(Name="dbo.fnCLRSplitStringByPattern", IsComposable=true)]
		public ISingleResult<fnCLRSplitStringByPatternResult> fnCLRSplitStringByPattern(
			[ParameterAttribute(DbType="NVarChar(MAX)")] string str1,
			[ParameterAttribute(DbType="NVarChar(MAX)")] string patternStr
		)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), str1, patternStr);
			return ((ISingleResult<fnCLRSplitStringByPatternResult>) result.ReturnValue);
		}

		[FunctionAttribute(Name="dbo.fnCLRSplitStringToDistinctWords", IsComposable=true)]
		public ISingleResult<fnCLRSplitStringToDistinctWordsResult> fnCLRSplitStringToDistinctWords(
			[ParameterAttribute(DbType="NVarChar(MAX)")] string str1
		)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), str1);
			return ((ISingleResult<fnCLRSplitStringToDistinctWordsResult>) result.ReturnValue);
		}

		[FunctionAttribute(Name="dbo.fnCLRSplitStringToWords", IsComposable=true)]
		public ISingleResult<fnCLRSplitStringToWordsResult> fnCLRSplitStringToWords(
			[ParameterAttribute(DbType="NVarChar(MAX)")] string str1
		)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), str1);
			return ((ISingleResult<fnCLRSplitStringToWordsResult>) result.ReturnValue);
		}

		[FunctionAttribute(Name="dbo.fnConvertCsvArgsToIntTable", IsComposable=true)]
		public ISingleResult<fnConvertCsvArgsToIntTableResult> fnConvertCsvArgsToIntTable(
			[ParameterAttribute(DbType="NVarChar(MAX)")] string list
		)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), list);
			return ((ISingleResult<fnConvertCsvArgsToIntTableResult>) result.ReturnValue);
		}

		[FunctionAttribute(Name="dbo.fnConvertCsvArgsToWordsTable", IsComposable=true)]
		public ISingleResult<fnConvertCsvArgsToWordsTableResult> fnConvertCsvArgsToWordsTable(
			[ParameterAttribute(DbType="NVarChar(MAX)")] string list
		)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), list);
			return ((ISingleResult<fnConvertCsvArgsToWordsTableResult>) result.ReturnValue);
		}

		[FunctionAttribute(Name="dbo.fnFormatDateToStringHR", IsComposable=true)]
		public string fnFormatDateToStringHR(
			[ParameterAttribute(DbType="DateTime")] DateTime? value
		)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), value);
			return ((string) result.ReturnValue);
		}

		[FunctionAttribute(Name="dbo.fnFormatDateToStringISO", IsComposable=true)]
		public string fnFormatDateToStringISO(
			[ParameterAttribute(DbType="DateTime")] DateTime? value
		)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), value);
			return ((string) result.ReturnValue);
		}

		[FunctionAttribute(Name="dbo.fnFormatMoneyToStringHR", IsComposable=true)]
		public string fnFormatMoneyToStringHR(
			[ParameterAttribute(DbType="Money")] decimal? flvalue
		)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), flvalue);
			return ((string) result.ReturnValue);
		}

		[FunctionAttribute(Name="dbo.fnGetBankaPrometVrstaDescriptiveName", IsComposable=true)]
		public string fnGetBankaPrometVrstaDescriptiveName(
			[ParameterAttribute(DbType="Int")] int? BankaPrometVrstaID
		)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), BankaPrometVrstaID);
			return ((string) result.ReturnValue);
		}

		[FunctionAttribute(Name="dbo.fnGetBankaPrometVrste", IsComposable=true)]
		public ISingleResult<fnGetBankaPrometVrsteResult> fnGetBankaPrometVrste(
		)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())));
			return ((ISingleResult<fnGetBankaPrometVrsteResult>) result.ReturnValue);
		}

		[FunctionAttribute(Name="dbo.fnGetBankaPrometVrsteDatuma", IsComposable=true)]
		public ISingleResult<fnGetBankaPrometVrsteDatumaResult> fnGetBankaPrometVrsteDatuma(
		)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())));
			return ((ISingleResult<fnGetBankaPrometVrsteDatumaResult>) result.ReturnValue);
		}

		[FunctionAttribute(Name="dbo.fnGetBillClientsFromPoziviNaBroj", IsComposable=true)]
		public ISingleResult<fnGetBillClientsFromPoziviNaBrojResult> fnGetBillClientsFromPoziviNaBroj(
			[ParameterAttribute(DbType="VarChar(MAX)")] string pozivNaBrojCSV
		)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), pozivNaBrojCSV);
			return ((ISingleResult<fnGetBillClientsFromPoziviNaBrojResult>) result.ReturnValue);
		}

		[FunctionAttribute(Name="dbo.fnGetBillClientUplate", IsComposable=true)]
		public ISingleResult<fnGetBillClientUplateResult> fnGetBillClientUplate(
			[ParameterAttribute(DbType="BigInt")] long? billFirmaID,
			[ParameterAttribute(DbType="VarChar(MAX)")] string billClientsIdsCSV = null
		)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), billFirmaID, billClientsIdsCSV);
			return ((ISingleResult<fnGetBillClientUplateResult>) result.ReturnValue);
		}

		[FunctionAttribute(Name="dbo.fnGetDbPairNames", IsComposable=true)]
		public ISingleResult<fnGetDbPairNamesResult> fnGetDbPairNames(
		)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())));
			return ((ISingleResult<fnGetDbPairNamesResult>) result.ReturnValue);
		}

		[FunctionAttribute(Name="dbo.fnGetMaxDocumentDate", IsComposable=true)]
		public DateTime? fnGetMaxDocumentDate(
			[ParameterAttribute(DbType="BigInt")] long? billFirmaID,
			[ParameterAttribute(DbType="BigInt")] long? billNaplatniUredjajID = null
		)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), billFirmaID, billNaplatniUredjajID);
			return ((DateTime?) result.ReturnValue);
		}

		[FunctionAttribute(Name="dbo.fnGetMonthStartEnd", IsComposable=true)]
		public ISingleResult<fnGetMonthStartEndResult> fnGetMonthStartEnd(
			[ParameterAttribute(DbType="DateTime")] DateTime? date
		)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), date);
			return ((ISingleResult<fnGetMonthStartEndResult>) result.ReturnValue);
		}

		[FunctionAttribute(Name="dbo.fnGetPorezPdvNaDatum", IsComposable=true)]
		public ISingleResult<fnGetPorezPdvNaDatumResult> fnGetPorezPdvNaDatum(
			[ParameterAttribute(DbType="DateTime")] DateTime? datumValute = null
		)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), datumValute);
			return ((ISingleResult<fnGetPorezPdvNaDatumResult>) result.ReturnValue);
		}

		[FunctionAttribute(Name="dbo.fnGetPorezPotrosnjaNaDatum", IsComposable=true)]
		public ISingleResult<fnGetPorezPotrosnjaNaDatumResult> fnGetPorezPotrosnjaNaDatum(
			[ParameterAttribute(DbType="DateTime")] DateTime? datumValute = null
		)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), datumValute);
			return ((ISingleResult<fnGetPorezPotrosnjaNaDatumResult>) result.ReturnValue);
		}

		[FunctionAttribute(Name="dbo.fnGetPrikazStatusInfo", IsComposable=true)]
		public ISingleResult<fnGetPrikazStatusInfoResult> fnGetPrikazStatusInfo(
			[ParameterAttribute(DbType="Int")] int? arizonaClientID,
			[ParameterAttribute(DbType="Int")] int? prikazStatus,
			[ParameterAttribute(DbType="DateTime")] DateTime? startDate,
			[ParameterAttribute(DbType="DateTime")] DateTime? endDate
		)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), arizonaClientID, prikazStatus, startDate, endDate);
			return ((ISingleResult<fnGetPrikazStatusInfoResult>) result.ReturnValue);
		}

		[FunctionAttribute(Name="dbo.fnGetProductInfoExtended", IsComposable=true)]
		public ISingleResult<fnGetProductInfoExtendedResult> fnGetProductInfoExtended(
			[ParameterAttribute(DbType="BigInt")] long? billProductID
		)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), billProductID);
			return ((ISingleResult<fnGetProductInfoExtendedResult>) result.ReturnValue);
		}

		[FunctionAttribute(Name="dbo.fnGetRandomIntegerValue", IsComposable=true)]
		public int? fnGetRandomIntegerValue(
			[ParameterAttribute(DbType="VarChar(MAX)")] string csvValues
		)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), csvValues);
			return ((int?) result.ReturnValue);
		}

		[FunctionAttribute(Name="dbo.fnGetStariNoviGranica", IsComposable=true)]
		public ISingleResult<fnGetStariNoviGranicaResult> fnGetStariNoviGranica(
		)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())));
			return ((ISingleResult<fnGetStariNoviGranicaResult>) result.ReturnValue);
		}

		[FunctionAttribute(Name="dbo.fnGetUplateWithDocuments", IsComposable=true)]
		public ISingleResult<fnGetUplateWithDocumentsResult> fnGetUplateWithDocuments(
			[ParameterAttribute(DbType="BigInt")] long? billFirmaID
		)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), billFirmaID);
			return ((ISingleResult<fnGetUplateWithDocumentsResult>) result.ReturnValue);
		}

		[FunctionAttribute(Name="dbo.fnIsDocumentFiskalizacijaRequired", IsComposable=true)]
		public bool? fnIsDocumentFiskalizacijaRequired(
			[ParameterAttribute(DbType="BigInt")] long? billDocumentID
		)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), billDocumentID);
			return ((bool?) result.ReturnValue);
		}

		[FunctionAttribute(Name="dbo.fnIsNaplatniUredjajFiskalizacijaRequired", IsComposable=true)]
		public bool? fnIsNaplatniUredjajFiskalizacijaRequired(
			[ParameterAttribute(DbType="BigInt")] long? billNaplatniUredjajID
		)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), billNaplatniUredjajID);
			return ((bool?) result.ReturnValue);
		}

		[FunctionAttribute(Name="dbo.fnIsRacunType", IsComposable=true)]
		public bool? fnIsRacunType(
			[ParameterAttribute(DbType="BigInt")] long? billNaplatniUredjajID
		)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), billNaplatniUredjajID);
			return ((bool?) result.ReturnValue);
		}

		[FunctionAttribute(Name="dbo.fnIsUPdvSustavu", IsComposable=true)]
		public bool? fnIsUPdvSustavu(
			[ParameterAttribute(DbType="BigInt")] long? billFirmaID,
			[ParameterAttribute(DbType="DateTime")] DateTime? datum
		)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), billFirmaID, datum);
			return ((bool?) result.ReturnValue);
		}

		[FunctionAttribute(Name="dbo.fnPosGetFirmaSettings", IsComposable=true)]
		public ISingleResult<fnPosGetFirmaSettingsResult> fnPosGetFirmaSettings(
			[ParameterAttribute(DbType="BigInt")] long? billFirmaID
		)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), billFirmaID);
			return ((ISingleResult<fnPosGetFirmaSettingsResult>) result.ReturnValue);
		}

		[FunctionAttribute(Name="dbo.fnPosGetFirmaStatistics", IsComposable=true)]
		public ISingleResult<fnPosGetFirmaStatisticsResult> fnPosGetFirmaStatistics(
			[ParameterAttribute(DbType="BigInt")] long? billFirmaID
		)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), billFirmaID);
			return ((ISingleResult<fnPosGetFirmaStatisticsResult>) result.ReturnValue);
		}

		[FunctionAttribute(Name="dbo.fnRazradaIznosa", IsComposable=true)]
		public ISingleResult<fnRazradaIznosaResult> fnRazradaIznosa(
			[ParameterAttribute(DbType="Bit")] bool? uPdvSustavu,
			[ParameterAttribute(DbType="Float")] double? jedinicnaCijena,
			[ParameterAttribute(DbType="Bit")] bool? cijenaJeMaloprodajna,
			[ParameterAttribute(DbType="Float")] double? popustPosto,
			[ParameterAttribute(DbType="Float")] double? pdvPosto,
			[ParameterAttribute(DbType="Float")] double? porezPotrosnjaPosto,
			[ParameterAttribute(DbType="Float")] double? ostaliPorezPosto,
			[ParameterAttribute(DbType="Float")] double? iznosNaknade
		)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), uPdvSustavu, jedinicnaCijena, cijenaJeMaloprodajna, popustPosto, pdvPosto, porezPotrosnjaPosto, ostaliPorezPosto, iznosNaknade);
			return ((ISingleResult<fnRazradaIznosaResult>) result.ReturnValue);
		}

		[FunctionAttribute(Name="dbo.fnResolveNaplatniUredjajZaKnjizenje", IsComposable=true)]
		public int? fnResolveNaplatniUredjajZaKnjizenje(
			[ParameterAttribute(DbType="BigInt")] long? knjizeniBillDocumentID = null,
			[ParameterAttribute(DbType="BigInt")] long? zadaniBillNaplatniUredjajID = null
		)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), knjizeniBillDocumentID, zadaniBillNaplatniUredjajID);
			return ((int?) result.ReturnValue);
		}

		[FunctionAttribute(Name="dbo.fnSplitStringByPattern", IsComposable=true)]
		public ISingleResult<fnSplitStringByPatternResult> fnSplitStringByPattern(
			[ParameterAttribute(DbType="VarChar(MAX)")] string strToSplit,
			[ParameterAttribute(DbType="VarChar(100)")] string pattern
		)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), strToSplit, pattern);
			return ((ISingleResult<fnSplitStringByPatternResult>) result.ReturnValue);
		}

		[FunctionAttribute(Name="dbo.fnThrowErrorIfAppDatabase", IsComposable=true)]
		public int? fnThrowErrorIfAppDatabase(
		)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())));
			return ((int?) result.ReturnValue);
		}

		[FunctionAttribute(Name="dbo.fnThrowErrorIfPosDatabase", IsComposable=true)]
		public int? fnThrowErrorIfPosDatabase(
		)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())));
			return ((int?) result.ReturnValue);
		}

		[FunctionAttribute(Name="dbo.fnThrowErrorMessage", IsComposable=true)]
		public int? fnThrowErrorMessage(
			[ParameterAttribute(DbType="Int")] int? errorCode,
			[ParameterAttribute(DbType="NVarChar(MAX)")] string systemMessage,
			[ParameterAttribute(DbType="NVarChar(MAX)")] string customerMessage
		)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), errorCode, systemMessage, customerMessage);
			return ((int?) result.ReturnValue);
		}

		#endregion Context database functions

	}

	#region Entity Tables

		#region dbo.tblAppConfig
		[TableAttribute(Name="dbo.tblAppConfig")]
		public partial class tblAppConfig : EntityBase<tblAppConfig, dbArizonaAppDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private int _AppConfigID;
			private string _GroupName;
			private bool _IsActive;
			private bool _IsDefault;
			private string _Note;
			private string _SmtpHost;
			private int? _SmtpPort;
			private bool? _SmtpSSL;
			private string _SmtpUsername;
			private string _SmtpPassword;
			private string _DefaultEmailFrom;
			private string _DefaultEmailTo;
			private string _ContactFormEmailTo;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnAppConfigIDChanging(int value);
			partial void OnAppConfigIDChanged();
			partial void OnGroupNameChanging(string value);
			partial void OnGroupNameChanged();
			partial void OnIsActiveChanging(bool value);
			partial void OnIsActiveChanged();
			partial void OnIsDefaultChanging(bool value);
			partial void OnIsDefaultChanged();
			partial void OnNoteChanging(string value);
			partial void OnNoteChanged();
			partial void OnSmtpHostChanging(string value);
			partial void OnSmtpHostChanged();
			partial void OnSmtpPortChanging(int? value);
			partial void OnSmtpPortChanged();
			partial void OnSmtpSSLChanging(bool? value);
			partial void OnSmtpSSLChanged();
			partial void OnSmtpUsernameChanging(string value);
			partial void OnSmtpUsernameChanged();
			partial void OnSmtpPasswordChanging(string value);
			partial void OnSmtpPasswordChanged();
			partial void OnDefaultEmailFromChanging(string value);
			partial void OnDefaultEmailFromChanged();
			partial void OnDefaultEmailToChanging(string value);
			partial void OnDefaultEmailToChanged();
			partial void OnContactFormEmailToChanging(string value);
			partial void OnContactFormEmailToChanged();
			#endregion

			public tblAppConfig()
			{
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=Int NOT NULL IDENTITY
			/// </summary>
			[ColumnAttribute(Storage="_AppConfigID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", CanBeNull=false, IsPrimaryKey=true, IsDbGenerated=true)]
			public int AppConfigID
			{
				get
				{
					return this._AppConfigID;
				}
				set
				{
					if (this._AppConfigID != value)
					{
						this.OnAppConfigIDChanging(value);
						this.SendPropertyChanging();
						this._AppConfigID = value;
						this.SendPropertyChanged("AppConfigID");
						this.OnAppConfigIDChanged();
					}
					this.SendPropertySetterInvoked("AppConfigID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=VarChar(50) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_GroupName", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
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
			/// Column DbType=Bit NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_IsDefault", DbType="Bit NOT NULL", CanBeNull=false)]
			public bool IsDefault
			{
				get
				{
					return this._IsDefault;
				}
				set
				{
					if (this._IsDefault != value)
					{
						this.OnIsDefaultChanging(value);
						this.SendPropertyChanging();
						this._IsDefault = value;
						this.SendPropertyChanged("IsDefault");
						this.OnIsDefaultChanged();
					}
					this.SendPropertySetterInvoked("IsDefault", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(500)
			/// </summary>
			[ColumnAttribute(Storage="_Note", DbType="NVarChar(500)", CanBeNull=true)]
			public string Note
			{
				get
				{
					return this._Note;
				}
				set
				{
					if (this._Note != value)
					{
						this.OnNoteChanging(value);
						this.SendPropertyChanging();
						this._Note = value;
						this.SendPropertyChanged("Note");
						this.OnNoteChanged();
					}
					this.SendPropertySetterInvoked("Note", value);
				}
			}
			
			/// <summary>
			/// Column DbType=VarChar(100)
			/// </summary>
			[ColumnAttribute(Storage="_SmtpHost", DbType="VarChar(100)", CanBeNull=true)]
			public string SmtpHost
			{
				get
				{
					return this._SmtpHost;
				}
				set
				{
					if (this._SmtpHost != value)
					{
						this.OnSmtpHostChanging(value);
						this.SendPropertyChanging();
						this._SmtpHost = value;
						this.SendPropertyChanged("SmtpHost");
						this.OnSmtpHostChanged();
					}
					this.SendPropertySetterInvoked("SmtpHost", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int
			/// </summary>
			[ColumnAttribute(Storage="_SmtpPort", DbType="Int", CanBeNull=true)]
			public int? SmtpPort
			{
				get
				{
					return this._SmtpPort;
				}
				set
				{
					if (this._SmtpPort != value)
					{
						this.OnSmtpPortChanging(value);
						this.SendPropertyChanging();
						this._SmtpPort = value;
						this.SendPropertyChanged("SmtpPort");
						this.OnSmtpPortChanged();
					}
					this.SendPropertySetterInvoked("SmtpPort", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Bit
			/// </summary>
			[ColumnAttribute(Storage="_SmtpSSL", DbType="Bit", CanBeNull=true)]
			public bool? SmtpSSL
			{
				get
				{
					return this._SmtpSSL;
				}
				set
				{
					if (this._SmtpSSL != value)
					{
						this.OnSmtpSSLChanging(value);
						this.SendPropertyChanging();
						this._SmtpSSL = value;
						this.SendPropertyChanged("SmtpSSL");
						this.OnSmtpSSLChanged();
					}
					this.SendPropertySetterInvoked("SmtpSSL", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(50)
			/// </summary>
			[ColumnAttribute(Storage="_SmtpUsername", DbType="NVarChar(50)", CanBeNull=true)]
			public string SmtpUsername
			{
				get
				{
					return this._SmtpUsername;
				}
				set
				{
					if (this._SmtpUsername != value)
					{
						this.OnSmtpUsernameChanging(value);
						this.SendPropertyChanging();
						this._SmtpUsername = value;
						this.SendPropertyChanged("SmtpUsername");
						this.OnSmtpUsernameChanged();
					}
					this.SendPropertySetterInvoked("SmtpUsername", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(50)
			/// </summary>
			[ColumnAttribute(Storage="_SmtpPassword", DbType="NVarChar(50)", CanBeNull=true)]
			public string SmtpPassword
			{
				get
				{
					return this._SmtpPassword;
				}
				set
				{
					if (this._SmtpPassword != value)
					{
						this.OnSmtpPasswordChanging(value);
						this.SendPropertyChanging();
						this._SmtpPassword = value;
						this.SendPropertyChanged("SmtpPassword");
						this.OnSmtpPasswordChanged();
					}
					this.SendPropertySetterInvoked("SmtpPassword", value);
				}
			}
			
			/// <summary>
			/// Column DbType=VarChar(100)
			/// </summary>
			[ColumnAttribute(Storage="_DefaultEmailFrom", DbType="VarChar(100)", CanBeNull=true)]
			public string DefaultEmailFrom
			{
				get
				{
					return this._DefaultEmailFrom;
				}
				set
				{
					if (this._DefaultEmailFrom != value)
					{
						this.OnDefaultEmailFromChanging(value);
						this.SendPropertyChanging();
						this._DefaultEmailFrom = value;
						this.SendPropertyChanged("DefaultEmailFrom");
						this.OnDefaultEmailFromChanged();
					}
					this.SendPropertySetterInvoked("DefaultEmailFrom", value);
				}
			}
			
			/// <summary>
			/// Column DbType=VarChar(100)
			/// </summary>
			[ColumnAttribute(Storage="_DefaultEmailTo", DbType="VarChar(100)", CanBeNull=true)]
			public string DefaultEmailTo
			{
				get
				{
					return this._DefaultEmailTo;
				}
				set
				{
					if (this._DefaultEmailTo != value)
					{
						this.OnDefaultEmailToChanging(value);
						this.SendPropertyChanging();
						this._DefaultEmailTo = value;
						this.SendPropertyChanged("DefaultEmailTo");
						this.OnDefaultEmailToChanged();
					}
					this.SendPropertySetterInvoked("DefaultEmailTo", value);
				}
			}
			
			/// <summary>
			/// Column DbType=VarChar(100)
			/// </summary>
			[ColumnAttribute(Storage="_ContactFormEmailTo", DbType="VarChar(100)", CanBeNull=true)]
			public string ContactFormEmailTo
			{
				get
				{
					return this._ContactFormEmailTo;
				}
				set
				{
					if (this._ContactFormEmailTo != value)
					{
						this.OnContactFormEmailToChanging(value);
						this.SendPropertyChanging();
						this._ContactFormEmailTo = value;
						this.SendPropertyChanged("ContactFormEmailTo");
						this.OnContactFormEmailToChanged();
					}
					this.SendPropertySetterInvoked("ContactFormEmailTo", value);
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
		#endregion dbo.tblAppConfig

		#region dbo.tblAppMember
		[TableAttribute(Name="dbo.tblAppMember")]
		public partial class tblAppMember : EntityBase<tblAppMember, dbArizonaAppDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private long _AppMemberID;
			private int _AppMemberStatusID;
			private string _MSISDN;
			private string _FacebookId;
			private string _GoogleId;
			private string _Email;
			private string _Data2;
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
			private string _ReferentNote;
			private int? _BillFirmaID;
			private long? _BillOperatorID;
			private EntityRef<tblAppMemberStatus> _tblAppMemberStatus;
			private EntitySet<tblAppMemberPicture> _tblAppMemberPictureList;
			private EntityRef<tblBillFirma> _tblBillFirma;
			private EntityRef<tblBillOperator> _tblBillOperator;
			private EntityRef<tblAppMemberPermission> _tblAppMemberPermission;
			private EntitySet<tblBankaPromet> _tblBankaPrometList;
			private EntitySet<tblBillDocument> _tblBillDocumentList;
			private EntitySet<tblBillPrintLog> _tblBillPrintLogList;
			private EntitySet<tblDirClientBlacklist> _tblDirClientBlacklistList;
			private EntitySet<tblDirClientVracenaPosta> _tblDirClientVracenaPostaList;
			private EntitySet<tblFiskalRacunZahtjevLog> _tblFiskalRacunZahtjevLogList;
			private EntitySet<tblJobApplicationNote> _tblJobApplicationNoteList;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnAppMemberIDChanging(long value);
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
			partial void OnData2Changing(string value);
			partial void OnData2Changed();
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
			partial void OnReferentNoteChanging(string value);
			partial void OnReferentNoteChanged();
			partial void OnBillFirmaIDChanging(int? value);
			partial void OnBillFirmaIDChanged();
			partial void OnBillOperatorIDChanging(long? value);
			partial void OnBillOperatorIDChanged();
			#endregion

			public tblAppMember()
			{
				_tblAppMemberStatus = default(EntityRef<tblAppMemberStatus>);
				_tblAppMemberPictureList = new EntitySet<tblAppMemberPicture>(
					new Action<tblAppMemberPicture>(item=>{this.SendPropertyChanging(); item.tblAppMember=this;}), 
					new Action<tblAppMemberPicture>(item=>{this.SendPropertyChanging(); item.tblAppMember=null;}));
				_tblBillFirma = default(EntityRef<tblBillFirma>);
				_tblBillOperator = default(EntityRef<tblBillOperator>);
				_tblAppMemberPermission = default(EntityRef<tblAppMemberPermission>);
				_tblBankaPrometList = new EntitySet<tblBankaPromet>(
					new Action<tblBankaPromet>(item=>{this.SendPropertyChanging(); item.tblAppMember=this;}), 
					new Action<tblBankaPromet>(item=>{this.SendPropertyChanging(); item.tblAppMember=null;}));
				_tblBillDocumentList = new EntitySet<tblBillDocument>(
					new Action<tblBillDocument>(item=>{this.SendPropertyChanging(); item.tblAppMember=this;}), 
					new Action<tblBillDocument>(item=>{this.SendPropertyChanging(); item.tblAppMember=null;}));
				_tblBillPrintLogList = new EntitySet<tblBillPrintLog>(
					new Action<tblBillPrintLog>(item=>{this.SendPropertyChanging(); item.tblAppMember=this;}), 
					new Action<tblBillPrintLog>(item=>{this.SendPropertyChanging(); item.tblAppMember=null;}));
				_tblDirClientBlacklistList = new EntitySet<tblDirClientBlacklist>(
					new Action<tblDirClientBlacklist>(item=>{this.SendPropertyChanging(); item.tblAppMember=this;}), 
					new Action<tblDirClientBlacklist>(item=>{this.SendPropertyChanging(); item.tblAppMember=null;}));
				_tblDirClientVracenaPostaList = new EntitySet<tblDirClientVracenaPosta>(
					new Action<tblDirClientVracenaPosta>(item=>{this.SendPropertyChanging(); item.tblAppMember=this;}), 
					new Action<tblDirClientVracenaPosta>(item=>{this.SendPropertyChanging(); item.tblAppMember=null;}));
				_tblFiskalRacunZahtjevLogList = new EntitySet<tblFiskalRacunZahtjevLog>(
					new Action<tblFiskalRacunZahtjevLog>(item=>{this.SendPropertyChanging(); item.tblAppMember=this;}), 
					new Action<tblFiskalRacunZahtjevLog>(item=>{this.SendPropertyChanging(); item.tblAppMember=null;}));
				_tblJobApplicationNoteList = new EntitySet<tblJobApplicationNote>(
					new Action<tblJobApplicationNote>(item=>{this.SendPropertyChanging(); item.tblAppMember=this;}), 
					new Action<tblJobApplicationNote>(item=>{this.SendPropertyChanging(); item.tblAppMember=null;}));
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=BigInt NOT NULL IDENTITY
			/// </summary>
			[ColumnAttribute(Storage="_AppMemberID", AutoSync=AutoSync.OnInsert, DbType="BigInt NOT NULL IDENTITY", CanBeNull=false, IsPrimaryKey=true, IsDbGenerated=true)]
			public long AppMemberID
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
			/// Column DbType=NVarChar(200)
			/// </summary>
			[ColumnAttribute(Storage="_Data2", DbType="NVarChar(200)", CanBeNull=true)]
			public string Data2
			{
				get
				{
					return this._Data2;
				}
				set
				{
					if (this._Data2 != value)
					{
						this.OnData2Changing(value);
						this.SendPropertyChanging();
						this._Data2 = value;
						this.SendPropertyChanged("Data2");
						this.OnData2Changed();
					}
					this.SendPropertySetterInvoked("Data2", value);
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
			/// Column DbType=Int
			/// </summary>
			[ColumnAttribute(Storage="_BillFirmaID", DbType="Int", CanBeNull=true)]
			public int? BillFirmaID
			{
				get
				{
					return this._BillFirmaID;
				}
				set
				{
					if (this._BillFirmaID != value)
					{
						this.OnBillFirmaIDChanging(value);
						this.SendPropertyChanging();
						this._BillFirmaID = value;
						this.SendPropertyChanged("BillFirmaID");
						this.OnBillFirmaIDChanged();
					}
					this.SendPropertySetterInvoked("BillFirmaID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=BigInt
			/// </summary>
			[ColumnAttribute(Storage="_BillOperatorID", DbType="BigInt", CanBeNull=true)]
			public long? BillOperatorID
			{
				get
				{
					return this._BillOperatorID;
				}
				set
				{
					if (this._BillOperatorID != value)
					{
						this.OnBillOperatorIDChanging(value);
						this.SendPropertyChanging();
						this._BillOperatorID = value;
						this.SendPropertyChanged("BillOperatorID");
						this.OnBillOperatorIDChanged();
					}
					this.SendPropertySetterInvoked("BillOperatorID", value);
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
			/// Association [PK][One]tblAppMember.AppMemberID --- [FK][Many]tblAppMemberPicture.AppMemberID
			/// </summary>
			[AssociationAttribute(Name="FK_AppMemberPicture_AppMember", Storage="_tblAppMemberPictureList", ThisKey="AppMemberID", OtherKey="AppMemberID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<tblAppMemberPicture> tblAppMemberPictureList
			{
				get { return this._tblAppMemberPictureList; }
				set { this._tblAppMemberPictureList.Assign(value); }
			}
			
			/// <summary>
			/// Association [FK][Many]tblAppMember.BillFirmaID --- [PK][One]tblBillFirma.BillFirmaID
			/// </summary>
			[AssociationAttribute(Name="FK_tblAppMember_tblBillFirma", Storage="_tblBillFirma", ThisKey="BillFirmaID", OtherKey="BillFirmaID", IsUnique=false, IsForeignKey=true)]
			public tblBillFirma tblBillFirma
			{
				get
				{
					return this._tblBillFirma.Entity;
				}
				set
				{
					tblBillFirma previousValue = this._tblBillFirma.Entity;
					if ((previousValue != value) || (this._tblBillFirma.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._tblBillFirma.Entity = null;
							previousValue.tblAppMemberList.Remove(this);
						}
						this._tblBillFirma.Entity = value;
						if (value != null)
						{
							value.tblAppMemberList.Add(this);
							this._BillFirmaID = value.BillFirmaID;
						}
						else
						{
							this._BillFirmaID = default(int?);
						}
						this.SendPropertyChanged("tblBillFirma");
					}
					this.SendPropertySetterInvoked("tblBillFirma", value);
				}
			}
			
			/// <summary>
			/// Association [FK][Many]tblAppMember.BillOperatorID --- [PK][One]tblBillOperator.BillOperatorID
			/// </summary>
			[AssociationAttribute(Name="FK_tblAppMember_tblBillOperator", Storage="_tblBillOperator", ThisKey="BillOperatorID", OtherKey="BillOperatorID", IsUnique=false, IsForeignKey=true)]
			public tblBillOperator tblBillOperator
			{
				get
				{
					return this._tblBillOperator.Entity;
				}
				set
				{
					tblBillOperator previousValue = this._tblBillOperator.Entity;
					if ((previousValue != value) || (this._tblBillOperator.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._tblBillOperator.Entity = null;
							previousValue.tblAppMemberList.Remove(this);
						}
						this._tblBillOperator.Entity = value;
						if (value != null)
						{
							value.tblAppMemberList.Add(this);
							this._BillOperatorID = value.BillOperatorID;
						}
						else
						{
							this._BillOperatorID = default(long?);
						}
						this.SendPropertyChanged("tblBillOperator");
					}
					this.SendPropertySetterInvoked("tblBillOperator", value);
				}
			}
			
			/// <summary>
			/// Association [PK][One]tblAppMember.AppMemberID --- [FK][One]tblAppMemberPermission.AppMemberID
			/// </summary>
			[AssociationAttribute(Name="FK_tblAppMemberPermission_tblAppMember", Storage="_tblAppMemberPermission", ThisKey="AppMemberID", OtherKey="AppMemberID", IsUnique=true, IsForeignKey=false, DeleteRule="Cascade")]
			public tblAppMemberPermission tblAppMemberPermission
			{
				get
				{
					return this._tblAppMemberPermission.Entity;
				}
				set
				{
					tblAppMemberPermission previousValue = this._tblAppMemberPermission.Entity;
					if ((previousValue != value) || (this._tblAppMemberPermission.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._tblAppMemberPermission.Entity = null;
							previousValue.tblAppMember = null;
						}
						this._tblAppMemberPermission.Entity = value;
						if (value != null)
						{
							value.tblAppMember = this;
						}
						this.SendPropertyChanged("tblAppMemberPermission");
					}
					this.SendPropertySetterInvoked("tblAppMemberPermission", value);
				}
			}
			
			/// <summary>
			/// Association [PK][One]tblAppMember.AppMemberID --- [FK][Many]tblBankaPromet.AppMemberID
			/// </summary>
			[AssociationAttribute(Name="FK_tblBankaPromet_tblAppMember", Storage="_tblBankaPrometList", ThisKey="AppMemberID", OtherKey="AppMemberID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<tblBankaPromet> tblBankaPrometList
			{
				get { return this._tblBankaPrometList; }
				set { this._tblBankaPrometList.Assign(value); }
			}
			
			/// <summary>
			/// Association [PK][One]tblAppMember.AppMemberID --- [FK][Many]tblBillDocument.AppMemberID
			/// </summary>
			[AssociationAttribute(Name="FK_tblBillDocument_tblAppMember", Storage="_tblBillDocumentList", ThisKey="AppMemberID", OtherKey="AppMemberID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<tblBillDocument> tblBillDocumentList
			{
				get { return this._tblBillDocumentList; }
				set { this._tblBillDocumentList.Assign(value); }
			}
			
			/// <summary>
			/// Association [PK][One]tblAppMember.AppMemberID --- [FK][Many]tblBillPrintLog.AppMemberID
			/// </summary>
			[AssociationAttribute(Name="FK_tblBillPrintLog_tblAppMember", Storage="_tblBillPrintLogList", ThisKey="AppMemberID", OtherKey="AppMemberID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<tblBillPrintLog> tblBillPrintLogList
			{
				get { return this._tblBillPrintLogList; }
				set { this._tblBillPrintLogList.Assign(value); }
			}
			
			/// <summary>
			/// Association [PK][One]tblAppMember.AppMemberID --- [FK][Many]tblDirClientBlacklist.AppMemberID
			/// </summary>
			[AssociationAttribute(Name="FK_tblDirClientBlacklist_tblAppMember", Storage="_tblDirClientBlacklistList", ThisKey="AppMemberID", OtherKey="AppMemberID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<tblDirClientBlacklist> tblDirClientBlacklistList
			{
				get { return this._tblDirClientBlacklistList; }
				set { this._tblDirClientBlacklistList.Assign(value); }
			}
			
			/// <summary>
			/// Association [PK][One]tblAppMember.AppMemberID --- [FK][Many]tblDirClientVracenaPosta.AppMemberID
			/// </summary>
			[AssociationAttribute(Name="FK_tblDirClientVracenaPosta_tblAppMember", Storage="_tblDirClientVracenaPostaList", ThisKey="AppMemberID", OtherKey="AppMemberID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<tblDirClientVracenaPosta> tblDirClientVracenaPostaList
			{
				get { return this._tblDirClientVracenaPostaList; }
				set { this._tblDirClientVracenaPostaList.Assign(value); }
			}
			
			/// <summary>
			/// Association [PK][One]tblAppMember.AppMemberID --- [FK][Many]tblFiskalRacunZahtjevLog.AppMemberID
			/// </summary>
			[AssociationAttribute(Name="FK_tblFiskalRacunZahtjevLog_tblAppMember", Storage="_tblFiskalRacunZahtjevLogList", ThisKey="AppMemberID", OtherKey="AppMemberID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<tblFiskalRacunZahtjevLog> tblFiskalRacunZahtjevLogList
			{
				get { return this._tblFiskalRacunZahtjevLogList; }
				set { this._tblFiskalRacunZahtjevLogList.Assign(value); }
			}
			
			/// <summary>
			/// Association [PK][One]tblAppMember.AppMemberID --- [FK][Many]tblJobApplicationNote.AppMemberID
			/// </summary>
			[AssociationAttribute(Name="FK_tblJobApplicationLog_tblAppMember", Storage="_tblJobApplicationNoteList", ThisKey="AppMemberID", OtherKey="AppMemberID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<tblJobApplicationNote> tblJobApplicationNoteList
			{
				get { return this._tblJobApplicationNoteList; }
				set { this._tblJobApplicationNoteList.Assign(value); }
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

		#region dbo.tblAppMemberPermission
		[TableAttribute(Name="dbo.tblAppMemberPermission")]
		public partial class tblAppMemberPermission : EntityBase<tblAppMemberPermission, dbArizonaAppDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private long _AppMemberID;
			private bool? _IsActive;
			private bool? _WritePermission;
			private bool? _ArizonaReferenti;
			private bool? _PosCompanies;
			private bool? _AdminTools;
			private bool? _PosMain;
			private bool? _PosOperators;
			private bool? _PosCompany;
			private bool? _PosPoslovniProstori;
			private bool? _PosNaplatniUredjaji;
			private bool? _PosDnevniObracun;
			private bool? _PosEvidencijaGotovine;
			private bool? _PosPorezneGrupe;
			private bool? _PosProducts;
			private bool? _Documents;
			private bool? _Payments;
			private bool? _JobAdverts;
			private bool? _JobCalendar;
			private bool? _JobApplicants;
			private bool? _JobTemplates;
			private bool? _BillsExport;
			private bool? _SynesisExport;
			private bool? _FiduciaExport;
			private bool? _Printing;
			private bool? _PrintingHistory;
			private bool? _Balances;
			private bool? _Transactions;
			private bool? _FirmaCalls;
			private bool? _FirmaTools;
			private bool? _GeolocationTools;
			private bool? _CrmOglasnik;
			private bool? _CrmRadnoVrijeme;
			private EntityRef<tblAppMember> _tblAppMember;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnAppMemberIDChanging(long value);
			partial void OnAppMemberIDChanged();
			partial void OnIsActiveChanging(bool? value);
			partial void OnIsActiveChanged();
			partial void OnWritePermissionChanging(bool? value);
			partial void OnWritePermissionChanged();
			partial void OnArizonaReferentiChanging(bool? value);
			partial void OnArizonaReferentiChanged();
			partial void OnPosCompaniesChanging(bool? value);
			partial void OnPosCompaniesChanged();
			partial void OnAdminToolsChanging(bool? value);
			partial void OnAdminToolsChanged();
			partial void OnPosMainChanging(bool? value);
			partial void OnPosMainChanged();
			partial void OnPosOperatorsChanging(bool? value);
			partial void OnPosOperatorsChanged();
			partial void OnPosCompanyChanging(bool? value);
			partial void OnPosCompanyChanged();
			partial void OnPosPoslovniProstoriChanging(bool? value);
			partial void OnPosPoslovniProstoriChanged();
			partial void OnPosNaplatniUredjajiChanging(bool? value);
			partial void OnPosNaplatniUredjajiChanged();
			partial void OnPosDnevniObracunChanging(bool? value);
			partial void OnPosDnevniObracunChanged();
			partial void OnPosEvidencijaGotovineChanging(bool? value);
			partial void OnPosEvidencijaGotovineChanged();
			partial void OnPosPorezneGrupeChanging(bool? value);
			partial void OnPosPorezneGrupeChanged();
			partial void OnPosProductsChanging(bool? value);
			partial void OnPosProductsChanged();
			partial void OnDocumentsChanging(bool? value);
			partial void OnDocumentsChanged();
			partial void OnPaymentsChanging(bool? value);
			partial void OnPaymentsChanged();
			partial void OnJobAdvertsChanging(bool? value);
			partial void OnJobAdvertsChanged();
			partial void OnJobCalendarChanging(bool? value);
			partial void OnJobCalendarChanged();
			partial void OnJobApplicantsChanging(bool? value);
			partial void OnJobApplicantsChanged();
			partial void OnJobTemplatesChanging(bool? value);
			partial void OnJobTemplatesChanged();
			partial void OnBillsExportChanging(bool? value);
			partial void OnBillsExportChanged();
			partial void OnSynesisExportChanging(bool? value);
			partial void OnSynesisExportChanged();
			partial void OnFiduciaExportChanging(bool? value);
			partial void OnFiduciaExportChanged();
			partial void OnPrintingChanging(bool? value);
			partial void OnPrintingChanged();
			partial void OnPrintingHistoryChanging(bool? value);
			partial void OnPrintingHistoryChanged();
			partial void OnBalancesChanging(bool? value);
			partial void OnBalancesChanged();
			partial void OnTransactionsChanging(bool? value);
			partial void OnTransactionsChanged();
			partial void OnFirmaCallsChanging(bool? value);
			partial void OnFirmaCallsChanged();
			partial void OnFirmaToolsChanging(bool? value);
			partial void OnFirmaToolsChanged();
			partial void OnGeolocationToolsChanging(bool? value);
			partial void OnGeolocationToolsChanged();
			partial void OnCrmOglasnikChanging(bool? value);
			partial void OnCrmOglasnikChanged();
			partial void OnCrmRadnoVrijemeChanging(bool? value);
			partial void OnCrmRadnoVrijemeChanged();
			#endregion

			public tblAppMemberPermission()
			{
				_tblAppMember = default(EntityRef<tblAppMember>);
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=BigInt NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_AppMemberID", DbType="BigInt NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
			public long AppMemberID
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
			/// Column DbType=Bit
			/// </summary>
			[ColumnAttribute(Storage="_IsActive", DbType="Bit", CanBeNull=true)]
			public bool? IsActive
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
			/// Column DbType=Bit
			/// </summary>
			[ColumnAttribute(Storage="_WritePermission", DbType="Bit", CanBeNull=true)]
			public bool? WritePermission
			{
				get
				{
					return this._WritePermission;
				}
				set
				{
					if (this._WritePermission != value)
					{
						this.OnWritePermissionChanging(value);
						this.SendPropertyChanging();
						this._WritePermission = value;
						this.SendPropertyChanged("WritePermission");
						this.OnWritePermissionChanged();
					}
					this.SendPropertySetterInvoked("WritePermission", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Bit
			/// </summary>
			[ColumnAttribute(Storage="_ArizonaReferenti", DbType="Bit", CanBeNull=true)]
			public bool? ArizonaReferenti
			{
				get
				{
					return this._ArizonaReferenti;
				}
				set
				{
					if (this._ArizonaReferenti != value)
					{
						this.OnArizonaReferentiChanging(value);
						this.SendPropertyChanging();
						this._ArizonaReferenti = value;
						this.SendPropertyChanged("ArizonaReferenti");
						this.OnArizonaReferentiChanged();
					}
					this.SendPropertySetterInvoked("ArizonaReferenti", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Bit
			/// </summary>
			[ColumnAttribute(Storage="_PosCompanies", DbType="Bit", CanBeNull=true)]
			public bool? PosCompanies
			{
				get
				{
					return this._PosCompanies;
				}
				set
				{
					if (this._PosCompanies != value)
					{
						this.OnPosCompaniesChanging(value);
						this.SendPropertyChanging();
						this._PosCompanies = value;
						this.SendPropertyChanged("PosCompanies");
						this.OnPosCompaniesChanged();
					}
					this.SendPropertySetterInvoked("PosCompanies", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Bit
			/// </summary>
			[ColumnAttribute(Storage="_AdminTools", DbType="Bit", CanBeNull=true)]
			public bool? AdminTools
			{
				get
				{
					return this._AdminTools;
				}
				set
				{
					if (this._AdminTools != value)
					{
						this.OnAdminToolsChanging(value);
						this.SendPropertyChanging();
						this._AdminTools = value;
						this.SendPropertyChanged("AdminTools");
						this.OnAdminToolsChanged();
					}
					this.SendPropertySetterInvoked("AdminTools", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Bit
			/// </summary>
			[ColumnAttribute(Storage="_PosMain", DbType="Bit", CanBeNull=true)]
			public bool? PosMain
			{
				get
				{
					return this._PosMain;
				}
				set
				{
					if (this._PosMain != value)
					{
						this.OnPosMainChanging(value);
						this.SendPropertyChanging();
						this._PosMain = value;
						this.SendPropertyChanged("PosMain");
						this.OnPosMainChanged();
					}
					this.SendPropertySetterInvoked("PosMain", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Bit
			/// </summary>
			[ColumnAttribute(Storage="_PosOperators", DbType="Bit", CanBeNull=true)]
			public bool? PosOperators
			{
				get
				{
					return this._PosOperators;
				}
				set
				{
					if (this._PosOperators != value)
					{
						this.OnPosOperatorsChanging(value);
						this.SendPropertyChanging();
						this._PosOperators = value;
						this.SendPropertyChanged("PosOperators");
						this.OnPosOperatorsChanged();
					}
					this.SendPropertySetterInvoked("PosOperators", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Bit
			/// </summary>
			[ColumnAttribute(Storage="_PosCompany", DbType="Bit", CanBeNull=true)]
			public bool? PosCompany
			{
				get
				{
					return this._PosCompany;
				}
				set
				{
					if (this._PosCompany != value)
					{
						this.OnPosCompanyChanging(value);
						this.SendPropertyChanging();
						this._PosCompany = value;
						this.SendPropertyChanged("PosCompany");
						this.OnPosCompanyChanged();
					}
					this.SendPropertySetterInvoked("PosCompany", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Bit
			/// </summary>
			[ColumnAttribute(Storage="_PosPoslovniProstori", DbType="Bit", CanBeNull=true)]
			public bool? PosPoslovniProstori
			{
				get
				{
					return this._PosPoslovniProstori;
				}
				set
				{
					if (this._PosPoslovniProstori != value)
					{
						this.OnPosPoslovniProstoriChanging(value);
						this.SendPropertyChanging();
						this._PosPoslovniProstori = value;
						this.SendPropertyChanged("PosPoslovniProstori");
						this.OnPosPoslovniProstoriChanged();
					}
					this.SendPropertySetterInvoked("PosPoslovniProstori", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Bit
			/// </summary>
			[ColumnAttribute(Storage="_PosNaplatniUredjaji", DbType="Bit", CanBeNull=true)]
			public bool? PosNaplatniUredjaji
			{
				get
				{
					return this._PosNaplatniUredjaji;
				}
				set
				{
					if (this._PosNaplatniUredjaji != value)
					{
						this.OnPosNaplatniUredjajiChanging(value);
						this.SendPropertyChanging();
						this._PosNaplatniUredjaji = value;
						this.SendPropertyChanged("PosNaplatniUredjaji");
						this.OnPosNaplatniUredjajiChanged();
					}
					this.SendPropertySetterInvoked("PosNaplatniUredjaji", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Bit
			/// </summary>
			[ColumnAttribute(Storage="_PosDnevniObracun", DbType="Bit", CanBeNull=true)]
			public bool? PosDnevniObracun
			{
				get
				{
					return this._PosDnevniObracun;
				}
				set
				{
					if (this._PosDnevniObracun != value)
					{
						this.OnPosDnevniObracunChanging(value);
						this.SendPropertyChanging();
						this._PosDnevniObracun = value;
						this.SendPropertyChanged("PosDnevniObracun");
						this.OnPosDnevniObracunChanged();
					}
					this.SendPropertySetterInvoked("PosDnevniObracun", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Bit
			/// </summary>
			[ColumnAttribute(Storage="_PosEvidencijaGotovine", DbType="Bit", CanBeNull=true)]
			public bool? PosEvidencijaGotovine
			{
				get
				{
					return this._PosEvidencijaGotovine;
				}
				set
				{
					if (this._PosEvidencijaGotovine != value)
					{
						this.OnPosEvidencijaGotovineChanging(value);
						this.SendPropertyChanging();
						this._PosEvidencijaGotovine = value;
						this.SendPropertyChanged("PosEvidencijaGotovine");
						this.OnPosEvidencijaGotovineChanged();
					}
					this.SendPropertySetterInvoked("PosEvidencijaGotovine", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Bit
			/// </summary>
			[ColumnAttribute(Storage="_PosPorezneGrupe", DbType="Bit", CanBeNull=true)]
			public bool? PosPorezneGrupe
			{
				get
				{
					return this._PosPorezneGrupe;
				}
				set
				{
					if (this._PosPorezneGrupe != value)
					{
						this.OnPosPorezneGrupeChanging(value);
						this.SendPropertyChanging();
						this._PosPorezneGrupe = value;
						this.SendPropertyChanged("PosPorezneGrupe");
						this.OnPosPorezneGrupeChanged();
					}
					this.SendPropertySetterInvoked("PosPorezneGrupe", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Bit
			/// </summary>
			[ColumnAttribute(Storage="_PosProducts", DbType="Bit", CanBeNull=true)]
			public bool? PosProducts
			{
				get
				{
					return this._PosProducts;
				}
				set
				{
					if (this._PosProducts != value)
					{
						this.OnPosProductsChanging(value);
						this.SendPropertyChanging();
						this._PosProducts = value;
						this.SendPropertyChanged("PosProducts");
						this.OnPosProductsChanged();
					}
					this.SendPropertySetterInvoked("PosProducts", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Bit
			/// </summary>
			[ColumnAttribute(Storage="_Documents", DbType="Bit", CanBeNull=true)]
			public bool? Documents
			{
				get
				{
					return this._Documents;
				}
				set
				{
					if (this._Documents != value)
					{
						this.OnDocumentsChanging(value);
						this.SendPropertyChanging();
						this._Documents = value;
						this.SendPropertyChanged("Documents");
						this.OnDocumentsChanged();
					}
					this.SendPropertySetterInvoked("Documents", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Bit
			/// </summary>
			[ColumnAttribute(Storage="_Payments", DbType="Bit", CanBeNull=true)]
			public bool? Payments
			{
				get
				{
					return this._Payments;
				}
				set
				{
					if (this._Payments != value)
					{
						this.OnPaymentsChanging(value);
						this.SendPropertyChanging();
						this._Payments = value;
						this.SendPropertyChanged("Payments");
						this.OnPaymentsChanged();
					}
					this.SendPropertySetterInvoked("Payments", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Bit
			/// </summary>
			[ColumnAttribute(Storage="_JobAdverts", DbType="Bit", CanBeNull=true)]
			public bool? JobAdverts
			{
				get
				{
					return this._JobAdverts;
				}
				set
				{
					if (this._JobAdverts != value)
					{
						this.OnJobAdvertsChanging(value);
						this.SendPropertyChanging();
						this._JobAdverts = value;
						this.SendPropertyChanged("JobAdverts");
						this.OnJobAdvertsChanged();
					}
					this.SendPropertySetterInvoked("JobAdverts", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Bit
			/// </summary>
			[ColumnAttribute(Storage="_JobCalendar", DbType="Bit", CanBeNull=true)]
			public bool? JobCalendar
			{
				get
				{
					return this._JobCalendar;
				}
				set
				{
					if (this._JobCalendar != value)
					{
						this.OnJobCalendarChanging(value);
						this.SendPropertyChanging();
						this._JobCalendar = value;
						this.SendPropertyChanged("JobCalendar");
						this.OnJobCalendarChanged();
					}
					this.SendPropertySetterInvoked("JobCalendar", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Bit
			/// </summary>
			[ColumnAttribute(Storage="_JobApplicants", DbType="Bit", CanBeNull=true)]
			public bool? JobApplicants
			{
				get
				{
					return this._JobApplicants;
				}
				set
				{
					if (this._JobApplicants != value)
					{
						this.OnJobApplicantsChanging(value);
						this.SendPropertyChanging();
						this._JobApplicants = value;
						this.SendPropertyChanged("JobApplicants");
						this.OnJobApplicantsChanged();
					}
					this.SendPropertySetterInvoked("JobApplicants", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Bit
			/// </summary>
			[ColumnAttribute(Storage="_JobTemplates", DbType="Bit", CanBeNull=true)]
			public bool? JobTemplates
			{
				get
				{
					return this._JobTemplates;
				}
				set
				{
					if (this._JobTemplates != value)
					{
						this.OnJobTemplatesChanging(value);
						this.SendPropertyChanging();
						this._JobTemplates = value;
						this.SendPropertyChanged("JobTemplates");
						this.OnJobTemplatesChanged();
					}
					this.SendPropertySetterInvoked("JobTemplates", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Bit
			/// </summary>
			[ColumnAttribute(Storage="_BillsExport", DbType="Bit", CanBeNull=true)]
			public bool? BillsExport
			{
				get
				{
					return this._BillsExport;
				}
				set
				{
					if (this._BillsExport != value)
					{
						this.OnBillsExportChanging(value);
						this.SendPropertyChanging();
						this._BillsExport = value;
						this.SendPropertyChanged("BillsExport");
						this.OnBillsExportChanged();
					}
					this.SendPropertySetterInvoked("BillsExport", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Bit
			/// </summary>
			[ColumnAttribute(Storage="_SynesisExport", DbType="Bit", CanBeNull=true)]
			public bool? SynesisExport
			{
				get
				{
					return this._SynesisExport;
				}
				set
				{
					if (this._SynesisExport != value)
					{
						this.OnSynesisExportChanging(value);
						this.SendPropertyChanging();
						this._SynesisExport = value;
						this.SendPropertyChanged("SynesisExport");
						this.OnSynesisExportChanged();
					}
					this.SendPropertySetterInvoked("SynesisExport", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Bit
			/// </summary>
			[ColumnAttribute(Storage="_FiduciaExport", DbType="Bit", CanBeNull=true)]
			public bool? FiduciaExport
			{
				get
				{
					return this._FiduciaExport;
				}
				set
				{
					if (this._FiduciaExport != value)
					{
						this.OnFiduciaExportChanging(value);
						this.SendPropertyChanging();
						this._FiduciaExport = value;
						this.SendPropertyChanged("FiduciaExport");
						this.OnFiduciaExportChanged();
					}
					this.SendPropertySetterInvoked("FiduciaExport", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Bit
			/// </summary>
			[ColumnAttribute(Storage="_Printing", DbType="Bit", CanBeNull=true)]
			public bool? Printing
			{
				get
				{
					return this._Printing;
				}
				set
				{
					if (this._Printing != value)
					{
						this.OnPrintingChanging(value);
						this.SendPropertyChanging();
						this._Printing = value;
						this.SendPropertyChanged("Printing");
						this.OnPrintingChanged();
					}
					this.SendPropertySetterInvoked("Printing", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Bit
			/// </summary>
			[ColumnAttribute(Storage="_PrintingHistory", DbType="Bit", CanBeNull=true)]
			public bool? PrintingHistory
			{
				get
				{
					return this._PrintingHistory;
				}
				set
				{
					if (this._PrintingHistory != value)
					{
						this.OnPrintingHistoryChanging(value);
						this.SendPropertyChanging();
						this._PrintingHistory = value;
						this.SendPropertyChanged("PrintingHistory");
						this.OnPrintingHistoryChanged();
					}
					this.SendPropertySetterInvoked("PrintingHistory", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Bit
			/// </summary>
			[ColumnAttribute(Storage="_Balances", DbType="Bit", CanBeNull=true)]
			public bool? Balances
			{
				get
				{
					return this._Balances;
				}
				set
				{
					if (this._Balances != value)
					{
						this.OnBalancesChanging(value);
						this.SendPropertyChanging();
						this._Balances = value;
						this.SendPropertyChanged("Balances");
						this.OnBalancesChanged();
					}
					this.SendPropertySetterInvoked("Balances", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Bit
			/// </summary>
			[ColumnAttribute(Storage="_Transactions", DbType="Bit", CanBeNull=true)]
			public bool? Transactions
			{
				get
				{
					return this._Transactions;
				}
				set
				{
					if (this._Transactions != value)
					{
						this.OnTransactionsChanging(value);
						this.SendPropertyChanging();
						this._Transactions = value;
						this.SendPropertyChanged("Transactions");
						this.OnTransactionsChanged();
					}
					this.SendPropertySetterInvoked("Transactions", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Bit
			/// </summary>
			[ColumnAttribute(Storage="_FirmaCalls", DbType="Bit", CanBeNull=true)]
			public bool? FirmaCalls
			{
				get
				{
					return this._FirmaCalls;
				}
				set
				{
					if (this._FirmaCalls != value)
					{
						this.OnFirmaCallsChanging(value);
						this.SendPropertyChanging();
						this._FirmaCalls = value;
						this.SendPropertyChanged("FirmaCalls");
						this.OnFirmaCallsChanged();
					}
					this.SendPropertySetterInvoked("FirmaCalls", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Bit
			/// </summary>
			[ColumnAttribute(Storage="_FirmaTools", DbType="Bit", CanBeNull=true)]
			public bool? FirmaTools
			{
				get
				{
					return this._FirmaTools;
				}
				set
				{
					if (this._FirmaTools != value)
					{
						this.OnFirmaToolsChanging(value);
						this.SendPropertyChanging();
						this._FirmaTools = value;
						this.SendPropertyChanged("FirmaTools");
						this.OnFirmaToolsChanged();
					}
					this.SendPropertySetterInvoked("FirmaTools", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Bit
			/// </summary>
			[ColumnAttribute(Storage="_GeolocationTools", DbType="Bit", CanBeNull=true)]
			public bool? GeolocationTools
			{
				get
				{
					return this._GeolocationTools;
				}
				set
				{
					if (this._GeolocationTools != value)
					{
						this.OnGeolocationToolsChanging(value);
						this.SendPropertyChanging();
						this._GeolocationTools = value;
						this.SendPropertyChanged("GeolocationTools");
						this.OnGeolocationToolsChanged();
					}
					this.SendPropertySetterInvoked("GeolocationTools", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Bit
			/// </summary>
			[ColumnAttribute(Storage="_CrmOglasnik", DbType="Bit", CanBeNull=true)]
			public bool? CrmOglasnik
			{
				get
				{
					return this._CrmOglasnik;
				}
				set
				{
					if (this._CrmOglasnik != value)
					{
						this.OnCrmOglasnikChanging(value);
						this.SendPropertyChanging();
						this._CrmOglasnik = value;
						this.SendPropertyChanged("CrmOglasnik");
						this.OnCrmOglasnikChanged();
					}
					this.SendPropertySetterInvoked("CrmOglasnik", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Bit
			/// </summary>
			[ColumnAttribute(Storage="_CrmRadnoVrijeme", DbType="Bit", CanBeNull=true)]
			public bool? CrmRadnoVrijeme
			{
				get
				{
					return this._CrmRadnoVrijeme;
				}
				set
				{
					if (this._CrmRadnoVrijeme != value)
					{
						this.OnCrmRadnoVrijemeChanging(value);
						this.SendPropertyChanging();
						this._CrmRadnoVrijeme = value;
						this.SendPropertyChanged("CrmRadnoVrijeme");
						this.OnCrmRadnoVrijemeChanged();
					}
					this.SendPropertySetterInvoked("CrmRadnoVrijeme", value);
				}
			}
			
			#endregion Columns

			#region Associations
			/// <summary>
			/// Association [FK][One]tblAppMemberPermission.AppMemberID --- [PK][One]tblAppMember.AppMemberID
			/// </summary>
			[AssociationAttribute(Name="FK_tblAppMemberPermission_tblAppMember", Storage="_tblAppMember", ThisKey="AppMemberID", OtherKey="AppMemberID", IsUnique=true, IsForeignKey=true, DeleteOnNull=true)]
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
							previousValue.tblAppMemberPermission = null;
						}
						this._tblAppMember.Entity = value;
						if (value != null)
						{
							value.tblAppMemberPermission = this;
							this._AppMemberID = value.AppMemberID;
						}
						else
						{
							this._AppMemberID = default(long);
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
		public partial class tblAppMemberPicture : EntityBase<tblAppMemberPicture, dbArizonaAppDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private long _AppMemberPictureID;
			private long? _AppMemberID;
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
			partial void OnAppMemberPictureIDChanging(long value);
			partial void OnAppMemberPictureIDChanged();
			partial void OnAppMemberIDChanging(long? value);
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
			/// Column DbType=BigInt NOT NULL IDENTITY
			/// </summary>
			[ColumnAttribute(Storage="_AppMemberPictureID", AutoSync=AutoSync.OnInsert, DbType="BigInt NOT NULL IDENTITY", CanBeNull=false, IsPrimaryKey=true, IsDbGenerated=true)]
			public long AppMemberPictureID
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
			/// Column DbType=BigInt
			/// </summary>
			[ColumnAttribute(Storage="_AppMemberID", DbType="BigInt", CanBeNull=true)]
			public long? AppMemberID
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
							this._AppMemberID = default(long?);
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

		#region dbo.tblAppMemberStatus
		[TableAttribute(Name="dbo.tblAppMemberStatus")]
		public partial class tblAppMemberStatus : EntityBase<tblAppMemberStatus, dbArizonaAppDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
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

		#region dbo.tblAppNewsletter
		[TableAttribute(Name="dbo.tblAppNewsletter")]
		public partial class tblAppNewsletter : EntityBase<tblAppNewsletter, dbArizonaAppDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private string _Email;
			private DateTime _InsertionDate;
			private DateTime? _SubscribeDate;
			private DateTime? _UnsubscribeDate;
			private bool _IsSubscribed;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnEmailChanging(string value);
			partial void OnEmailChanged();
			partial void OnInsertionDateChanging(DateTime value);
			partial void OnInsertionDateChanged();
			partial void OnSubscribeDateChanging(DateTime? value);
			partial void OnSubscribeDateChanged();
			partial void OnUnsubscribeDateChanging(DateTime? value);
			partial void OnUnsubscribeDateChanged();
			partial void OnIsSubscribedChanging(bool value);
			partial void OnIsSubscribedChanged();
			#endregion

			public tblAppNewsletter()
			{
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=VarChar(150) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_Email", DbType="VarChar(150) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
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
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_InsertionDate", DbType="DateTime NOT NULL", CanBeNull=false)]
			public DateTime InsertionDate
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
			/// Column DbType=DateTime
			/// </summary>
			[ColumnAttribute(Storage="_SubscribeDate", DbType="DateTime", CanBeNull=true)]
			public DateTime? SubscribeDate
			{
				get
				{
					return this._SubscribeDate;
				}
				set
				{
					if (this._SubscribeDate != value)
					{
						this.OnSubscribeDateChanging(value);
						this.SendPropertyChanging();
						this._SubscribeDate = value;
						this.SendPropertyChanged("SubscribeDate");
						this.OnSubscribeDateChanged();
					}
					this.SendPropertySetterInvoked("SubscribeDate", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime
			/// </summary>
			[ColumnAttribute(Storage="_UnsubscribeDate", DbType="DateTime", CanBeNull=true)]
			public DateTime? UnsubscribeDate
			{
				get
				{
					return this._UnsubscribeDate;
				}
				set
				{
					if (this._UnsubscribeDate != value)
					{
						this.OnUnsubscribeDateChanging(value);
						this.SendPropertyChanging();
						this._UnsubscribeDate = value;
						this.SendPropertyChanged("UnsubscribeDate");
						this.OnUnsubscribeDateChanged();
					}
					this.SendPropertySetterInvoked("UnsubscribeDate", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Bit NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_IsSubscribed", DbType="Bit NOT NULL", CanBeNull=false)]
			public bool IsSubscribed
			{
				get
				{
					return this._IsSubscribed;
				}
				set
				{
					if (this._IsSubscribed != value)
					{
						this.OnIsSubscribedChanging(value);
						this.SendPropertyChanging();
						this._IsSubscribed = value;
						this.SendPropertyChanged("IsSubscribed");
						this.OnIsSubscribedChanged();
					}
					this.SendPropertySetterInvoked("IsSubscribed", value);
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
		#endregion dbo.tblAppNewsletter

		#region dbo.tblAppSchedule
		[TableAttribute(Name="dbo.tblAppSchedule")]
		public partial class tblAppSchedule : EntityBase<tblAppSchedule, dbArizonaAppDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private int _AppScheduleID;
			private int? _AppScheduleTypeID;
			private int _BillFirmaID;
			private DateTime _StartDate;
			private int _DurationMinutes;
			private string _Subject;
			private string _Description;
			private int? _JobApplicationID;
			private bool? _IsPredefined;
			private bool? _IsHeld;
			private EntityRef<tblJobApplication> _tblJobApplication;
			private EntityRef<tblAppScheduleType> _tblAppScheduleType;
			private EntityRef<tblBillFirma> _tblBillFirma;
			private EntitySet<tblJobApplicationSchedule> _tblJobApplicationScheduleList;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnAppScheduleIDChanging(int value);
			partial void OnAppScheduleIDChanged();
			partial void OnAppScheduleTypeIDChanging(int? value);
			partial void OnAppScheduleTypeIDChanged();
			partial void OnBillFirmaIDChanging(int value);
			partial void OnBillFirmaIDChanged();
			partial void OnStartDateChanging(DateTime value);
			partial void OnStartDateChanged();
			partial void OnDurationMinutesChanging(int value);
			partial void OnDurationMinutesChanged();
			partial void OnSubjectChanging(string value);
			partial void OnSubjectChanged();
			partial void OnDescriptionChanging(string value);
			partial void OnDescriptionChanged();
			partial void OnJobApplicationIDChanging(int? value);
			partial void OnJobApplicationIDChanged();
			partial void OnIsPredefinedChanging(bool? value);
			partial void OnIsPredefinedChanged();
			partial void OnIsHeldChanging(bool? value);
			partial void OnIsHeldChanged();
			#endregion

			public tblAppSchedule()
			{
				_tblJobApplication = default(EntityRef<tblJobApplication>);
				_tblAppScheduleType = default(EntityRef<tblAppScheduleType>);
				_tblBillFirma = default(EntityRef<tblBillFirma>);
				_tblJobApplicationScheduleList = new EntitySet<tblJobApplicationSchedule>(
					new Action<tblJobApplicationSchedule>(item=>{this.SendPropertyChanging(); item.tblAppSchedule=this;}), 
					new Action<tblJobApplicationSchedule>(item=>{this.SendPropertyChanging(); item.tblAppSchedule=null;}));
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=Int NOT NULL IDENTITY
			/// </summary>
			[ColumnAttribute(Storage="_AppScheduleID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", CanBeNull=false, IsPrimaryKey=true, IsDbGenerated=true)]
			public int AppScheduleID
			{
				get
				{
					return this._AppScheduleID;
				}
				set
				{
					if (this._AppScheduleID != value)
					{
						this.OnAppScheduleIDChanging(value);
						this.SendPropertyChanging();
						this._AppScheduleID = value;
						this.SendPropertyChanged("AppScheduleID");
						this.OnAppScheduleIDChanged();
					}
					this.SendPropertySetterInvoked("AppScheduleID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int
			/// </summary>
			[ColumnAttribute(Storage="_AppScheduleTypeID", DbType="Int", CanBeNull=true)]
			public int? AppScheduleTypeID
			{
				get
				{
					return this._AppScheduleTypeID;
				}
				set
				{
					if (this._AppScheduleTypeID != value)
					{
						this.OnAppScheduleTypeIDChanging(value);
						this.SendPropertyChanging();
						this._AppScheduleTypeID = value;
						this.SendPropertyChanged("AppScheduleTypeID");
						this.OnAppScheduleTypeIDChanged();
					}
					this.SendPropertySetterInvoked("AppScheduleTypeID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_BillFirmaID", DbType="Int NOT NULL", CanBeNull=false)]
			public int BillFirmaID
			{
				get
				{
					return this._BillFirmaID;
				}
				set
				{
					if (this._BillFirmaID != value)
					{
						this.OnBillFirmaIDChanging(value);
						this.SendPropertyChanging();
						this._BillFirmaID = value;
						this.SendPropertyChanged("BillFirmaID");
						this.OnBillFirmaIDChanged();
					}
					this.SendPropertySetterInvoked("BillFirmaID", value);
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
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_DurationMinutes", DbType="Int NOT NULL", CanBeNull=false)]
			public int DurationMinutes
			{
				get
				{
					return this._DurationMinutes;
				}
				set
				{
					if (this._DurationMinutes != value)
					{
						this.OnDurationMinutesChanging(value);
						this.SendPropertyChanging();
						this._DurationMinutes = value;
						this.SendPropertyChanged("DurationMinutes");
						this.OnDurationMinutesChanged();
					}
					this.SendPropertySetterInvoked("DurationMinutes", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(255)
			/// </summary>
			[ColumnAttribute(Storage="_Subject", DbType="NVarChar(255)", CanBeNull=true)]
			public string Subject
			{
				get
				{
					return this._Subject;
				}
				set
				{
					if (this._Subject != value)
					{
						this.OnSubjectChanging(value);
						this.SendPropertyChanging();
						this._Subject = value;
						this.SendPropertyChanged("Subject");
						this.OnSubjectChanged();
					}
					this.SendPropertySetterInvoked("Subject", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(2000)
			/// </summary>
			[ColumnAttribute(Storage="_Description", DbType="NVarChar(2000)", CanBeNull=true)]
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
			/// Column DbType=Int
			/// </summary>
			[ColumnAttribute(Storage="_JobApplicationID", DbType="Int", CanBeNull=true)]
			public int? JobApplicationID
			{
				get
				{
					return this._JobApplicationID;
				}
				set
				{
					if (this._JobApplicationID != value)
					{
						this.OnJobApplicationIDChanging(value);
						this.SendPropertyChanging();
						this._JobApplicationID = value;
						this.SendPropertyChanged("JobApplicationID");
						this.OnJobApplicationIDChanged();
					}
					this.SendPropertySetterInvoked("JobApplicationID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Bit
			/// </summary>
			[ColumnAttribute(Storage="_IsPredefined", DbType="Bit", CanBeNull=true)]
			public bool? IsPredefined
			{
				get
				{
					return this._IsPredefined;
				}
				set
				{
					if (this._IsPredefined != value)
					{
						this.OnIsPredefinedChanging(value);
						this.SendPropertyChanging();
						this._IsPredefined = value;
						this.SendPropertyChanged("IsPredefined");
						this.OnIsPredefinedChanged();
					}
					this.SendPropertySetterInvoked("IsPredefined", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Bit
			/// </summary>
			[ColumnAttribute(Storage="_IsHeld", DbType="Bit", CanBeNull=true)]
			public bool? IsHeld
			{
				get
				{
					return this._IsHeld;
				}
				set
				{
					if (this._IsHeld != value)
					{
						this.OnIsHeldChanging(value);
						this.SendPropertyChanging();
						this._IsHeld = value;
						this.SendPropertyChanged("IsHeld");
						this.OnIsHeldChanged();
					}
					this.SendPropertySetterInvoked("IsHeld", value);
				}
			}
			
			#endregion Columns

			#region Associations
			/// <summary>
			/// Association [FK][Many]tblAppSchedule.JobApplicationID --- [PK][One]tblJobApplication.JobApplicationID
			/// </summary>
			[AssociationAttribute(Name="FK_AppJobSchedule_AppJobApplication", Storage="_tblJobApplication", ThisKey="JobApplicationID", OtherKey="JobApplicationID", IsUnique=false, IsForeignKey=true)]
			public tblJobApplication tblJobApplication
			{
				get
				{
					return this._tblJobApplication.Entity;
				}
				set
				{
					tblJobApplication previousValue = this._tblJobApplication.Entity;
					if ((previousValue != value) || (this._tblJobApplication.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._tblJobApplication.Entity = null;
							previousValue.tblAppScheduleList.Remove(this);
						}
						this._tblJobApplication.Entity = value;
						if (value != null)
						{
							value.tblAppScheduleList.Add(this);
							this._JobApplicationID = value.JobApplicationID;
						}
						else
						{
							this._JobApplicationID = default(int?);
						}
						this.SendPropertyChanged("tblJobApplication");
					}
					this.SendPropertySetterInvoked("tblJobApplication", value);
				}
			}
			
			/// <summary>
			/// Association [FK][Many]tblAppSchedule.AppScheduleTypeID --- [PK][One]tblAppScheduleType.AppScheduleTypeID
			/// </summary>
			[AssociationAttribute(Name="FK_AppSchedule_AppScheduleType", Storage="_tblAppScheduleType", ThisKey="AppScheduleTypeID", OtherKey="AppScheduleTypeID", IsUnique=false, IsForeignKey=true)]
			public tblAppScheduleType tblAppScheduleType
			{
				get
				{
					return this._tblAppScheduleType.Entity;
				}
				set
				{
					tblAppScheduleType previousValue = this._tblAppScheduleType.Entity;
					if ((previousValue != value) || (this._tblAppScheduleType.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._tblAppScheduleType.Entity = null;
							previousValue.tblAppScheduleList.Remove(this);
						}
						this._tblAppScheduleType.Entity = value;
						if (value != null)
						{
							value.tblAppScheduleList.Add(this);
							this._AppScheduleTypeID = value.AppScheduleTypeID;
						}
						else
						{
							this._AppScheduleTypeID = default(int?);
						}
						this.SendPropertyChanged("tblAppScheduleType");
					}
					this.SendPropertySetterInvoked("tblAppScheduleType", value);
				}
			}
			
			/// <summary>
			/// Association [FK][Many]tblAppSchedule.BillFirmaID --- [PK][One]tblBillFirma.BillFirmaID
			/// </summary>
			[AssociationAttribute(Name="FK_tblAppSchedule_tblBillFirma", Storage="_tblBillFirma", ThisKey="BillFirmaID", OtherKey="BillFirmaID", IsUnique=false, IsForeignKey=true)]
			public tblBillFirma tblBillFirma
			{
				get
				{
					return this._tblBillFirma.Entity;
				}
				set
				{
					tblBillFirma previousValue = this._tblBillFirma.Entity;
					if ((previousValue != value) || (this._tblBillFirma.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._tblBillFirma.Entity = null;
							previousValue.tblAppScheduleList.Remove(this);
						}
						this._tblBillFirma.Entity = value;
						if (value != null)
						{
							value.tblAppScheduleList.Add(this);
							this._BillFirmaID = value.BillFirmaID;
						}
						else
						{
							this._BillFirmaID = default(int);
						}
						this.SendPropertyChanged("tblBillFirma");
					}
					this.SendPropertySetterInvoked("tblBillFirma", value);
				}
			}
			
			/// <summary>
			/// Association [PK][One]tblAppSchedule.AppScheduleID --- [FK][Many]tblJobApplicationSchedule.AppScheduleID
			/// </summary>
			[AssociationAttribute(Name="FK_tblJobApplicationSchedule_tblAppSchedule", Storage="_tblJobApplicationScheduleList", ThisKey="AppScheduleID", OtherKey="AppScheduleID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<tblJobApplicationSchedule> tblJobApplicationScheduleList
			{
				get { return this._tblJobApplicationScheduleList; }
				set { this._tblJobApplicationScheduleList.Assign(value); }
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
		#endregion dbo.tblAppSchedule

		#region dbo.tblAppScheduleType
		[TableAttribute(Name="dbo.tblAppScheduleType")]
		public partial class tblAppScheduleType : EntityBase<tblAppScheduleType, dbArizonaAppDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private int _AppScheduleTypeID;
			private int _BillFirmaID;
			private string _Name;
			private bool _VisibleInNewSchedule;
			private bool _VisibleInFilter;
			private EntitySet<tblAppSchedule> _tblAppScheduleList;
			private EntityRef<tblBillFirma> _tblBillFirma;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnAppScheduleTypeIDChanging(int value);
			partial void OnAppScheduleTypeIDChanged();
			partial void OnBillFirmaIDChanging(int value);
			partial void OnBillFirmaIDChanged();
			partial void OnNameChanging(string value);
			partial void OnNameChanged();
			partial void OnVisibleInNewScheduleChanging(bool value);
			partial void OnVisibleInNewScheduleChanged();
			partial void OnVisibleInFilterChanging(bool value);
			partial void OnVisibleInFilterChanged();
			#endregion

			public tblAppScheduleType()
			{
				_tblAppScheduleList = new EntitySet<tblAppSchedule>(
					new Action<tblAppSchedule>(item=>{this.SendPropertyChanging(); item.tblAppScheduleType=this;}), 
					new Action<tblAppSchedule>(item=>{this.SendPropertyChanging(); item.tblAppScheduleType=null;}));
				_tblBillFirma = default(EntityRef<tblBillFirma>);
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=Int NOT NULL IDENTITY
			/// </summary>
			[ColumnAttribute(Storage="_AppScheduleTypeID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", CanBeNull=false, IsPrimaryKey=true, IsDbGenerated=true)]
			public int AppScheduleTypeID
			{
				get
				{
					return this._AppScheduleTypeID;
				}
				set
				{
					if (this._AppScheduleTypeID != value)
					{
						this.OnAppScheduleTypeIDChanging(value);
						this.SendPropertyChanging();
						this._AppScheduleTypeID = value;
						this.SendPropertyChanged("AppScheduleTypeID");
						this.OnAppScheduleTypeIDChanged();
					}
					this.SendPropertySetterInvoked("AppScheduleTypeID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_BillFirmaID", DbType="Int NOT NULL", CanBeNull=false)]
			public int BillFirmaID
			{
				get
				{
					return this._BillFirmaID;
				}
				set
				{
					if (this._BillFirmaID != value)
					{
						this.OnBillFirmaIDChanging(value);
						this.SendPropertyChanging();
						this._BillFirmaID = value;
						this.SendPropertyChanged("BillFirmaID");
						this.OnBillFirmaIDChanged();
					}
					this.SendPropertySetterInvoked("BillFirmaID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(150) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_Name", DbType="NVarChar(150) NOT NULL", CanBeNull=false)]
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
			/// Column DbType=Bit NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_VisibleInNewSchedule", DbType="Bit NOT NULL", CanBeNull=false)]
			public bool VisibleInNewSchedule
			{
				get
				{
					return this._VisibleInNewSchedule;
				}
				set
				{
					if (this._VisibleInNewSchedule != value)
					{
						this.OnVisibleInNewScheduleChanging(value);
						this.SendPropertyChanging();
						this._VisibleInNewSchedule = value;
						this.SendPropertyChanged("VisibleInNewSchedule");
						this.OnVisibleInNewScheduleChanged();
					}
					this.SendPropertySetterInvoked("VisibleInNewSchedule", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Bit NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_VisibleInFilter", DbType="Bit NOT NULL", CanBeNull=false)]
			public bool VisibleInFilter
			{
				get
				{
					return this._VisibleInFilter;
				}
				set
				{
					if (this._VisibleInFilter != value)
					{
						this.OnVisibleInFilterChanging(value);
						this.SendPropertyChanging();
						this._VisibleInFilter = value;
						this.SendPropertyChanged("VisibleInFilter");
						this.OnVisibleInFilterChanged();
					}
					this.SendPropertySetterInvoked("VisibleInFilter", value);
				}
			}
			
			#endregion Columns

			#region Associations
			/// <summary>
			/// Association [PK][One]tblAppScheduleType.AppScheduleTypeID --- [FK][Many]tblAppSchedule.AppScheduleTypeID
			/// </summary>
			[AssociationAttribute(Name="FK_AppSchedule_AppScheduleType", Storage="_tblAppScheduleList", ThisKey="AppScheduleTypeID", OtherKey="AppScheduleTypeID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<tblAppSchedule> tblAppScheduleList
			{
				get { return this._tblAppScheduleList; }
				set { this._tblAppScheduleList.Assign(value); }
			}
			
			/// <summary>
			/// Association [FK][Many]tblAppScheduleType.BillFirmaID --- [PK][One]tblBillFirma.BillFirmaID
			/// </summary>
			[AssociationAttribute(Name="FK_tblAppScheduleType_tblBillFirma", Storage="_tblBillFirma", ThisKey="BillFirmaID", OtherKey="BillFirmaID", IsUnique=false, IsForeignKey=true)]
			public tblBillFirma tblBillFirma
			{
				get
				{
					return this._tblBillFirma.Entity;
				}
				set
				{
					tblBillFirma previousValue = this._tblBillFirma.Entity;
					if ((previousValue != value) || (this._tblBillFirma.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._tblBillFirma.Entity = null;
							previousValue.tblAppScheduleTypeList.Remove(this);
						}
						this._tblBillFirma.Entity = value;
						if (value != null)
						{
							value.tblAppScheduleTypeList.Add(this);
							this._BillFirmaID = value.BillFirmaID;
						}
						else
						{
							this._BillFirmaID = default(int);
						}
						this.SendPropertyChanged("tblBillFirma");
					}
					this.SendPropertySetterInvoked("tblBillFirma", value);
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
		#endregion dbo.tblAppScheduleType

		#region dbo.tblBanka
		[TableAttribute(Name="dbo.tblBanka")]
		public partial class tblBanka : EntityBase<tblBanka, dbArizonaAppDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private int _BankaID;
			private string _Naziv;
			private string _IbanPrefix;
			private string _Swift;
			private EntitySet<tblBillFirmaTransakcijskiRacun> _tblBillFirmaTransakcijskiRacunList;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnBankaIDChanging(int value);
			partial void OnBankaIDChanged();
			partial void OnNazivChanging(string value);
			partial void OnNazivChanged();
			partial void OnIbanPrefixChanging(string value);
			partial void OnIbanPrefixChanged();
			partial void OnSwiftChanging(string value);
			partial void OnSwiftChanged();
			#endregion

			public tblBanka()
			{
				_tblBillFirmaTransakcijskiRacunList = new EntitySet<tblBillFirmaTransakcijskiRacun>(
					new Action<tblBillFirmaTransakcijskiRacun>(item=>{this.SendPropertyChanging(); item.tblBanka=this;}), 
					new Action<tblBillFirmaTransakcijskiRacun>(item=>{this.SendPropertyChanging(); item.tblBanka=null;}));
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_BankaID", DbType="Int NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
			public int BankaID
			{
				get
				{
					return this._BankaID;
				}
				set
				{
					if (this._BankaID != value)
					{
						this.OnBankaIDChanging(value);
						this.SendPropertyChanging();
						this._BankaID = value;
						this.SendPropertyChanged("BankaID");
						this.OnBankaIDChanged();
					}
					this.SendPropertySetterInvoked("BankaID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(500) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_Naziv", DbType="NVarChar(500) NOT NULL", CanBeNull=false)]
			public string Naziv
			{
				get
				{
					return this._Naziv;
				}
				set
				{
					if (this._Naziv != value)
					{
						this.OnNazivChanging(value);
						this.SendPropertyChanging();
						this._Naziv = value;
						this.SendPropertyChanged("Naziv");
						this.OnNazivChanged();
					}
					this.SendPropertySetterInvoked("Naziv", value);
				}
			}
			
			/// <summary>
			/// Column DbType=VarChar(50)
			/// </summary>
			[ColumnAttribute(Storage="_IbanPrefix", DbType="VarChar(50)", CanBeNull=true)]
			public string IbanPrefix
			{
				get
				{
					return this._IbanPrefix;
				}
				set
				{
					if (this._IbanPrefix != value)
					{
						this.OnIbanPrefixChanging(value);
						this.SendPropertyChanging();
						this._IbanPrefix = value;
						this.SendPropertyChanged("IbanPrefix");
						this.OnIbanPrefixChanged();
					}
					this.SendPropertySetterInvoked("IbanPrefix", value);
				}
			}
			
			/// <summary>
			/// Column DbType=VarChar(50)
			/// </summary>
			[ColumnAttribute(Storage="_Swift", DbType="VarChar(50)", CanBeNull=true)]
			public string Swift
			{
				get
				{
					return this._Swift;
				}
				set
				{
					if (this._Swift != value)
					{
						this.OnSwiftChanging(value);
						this.SendPropertyChanging();
						this._Swift = value;
						this.SendPropertyChanged("Swift");
						this.OnSwiftChanged();
					}
					this.SendPropertySetterInvoked("Swift", value);
				}
			}
			
			#endregion Columns

			#region Associations
			/// <summary>
			/// Association [PK][One]tblBanka.BankaID --- [FK][Many]tblBillFirmaTransakcijskiRacun.BankaID
			/// </summary>
			[AssociationAttribute(Name="FK_tblBillFirmaTransakcijskiRacun_tblBanka", Storage="_tblBillFirmaTransakcijskiRacunList", ThisKey="BankaID", OtherKey="BankaID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<tblBillFirmaTransakcijskiRacun> tblBillFirmaTransakcijskiRacunList
			{
				get { return this._tblBillFirmaTransakcijskiRacunList; }
				set { this._tblBillFirmaTransakcijskiRacunList.Assign(value); }
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
		#endregion dbo.tblBanka

		#region dbo.tblBankaPromet
		[TableAttribute(Name="dbo.tblBankaPromet")]
		public partial class tblBankaPromet : EntityBase<tblBankaPromet, dbArizonaAppDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private int _BankaPrometID;
			private int _BillFirmaTransakcijskiRacunID;
			private long _AppMemberID;
			private DateTime _InsertionDate;
			private DateTime _DatumTransakcije;
			private string _PlatiteljPrimatelj;
			private string _IbanPlatiteljaPrimatelja;
			private string _PlatiteljModel;
			private string _PlatiteljPozivNaBroj;
			private string _PrimateljModel;
			private string _PrimateljPozivNaBroj;
			private string _Mjesto;
			private string _OpisPlacanja;
			private int? _RedniBroj;
			private string _SifraNamjene;
			private decimal? _Isplata;
			private decimal? _Uplata;
			private decimal? _Stanje;
			private string _ReferencaPlacanja;
			private string _Napomena;
			private decimal? _PoreznaOsnovica;
			private decimal? _Pdv;
			private int? _BankaPrometVrstaID;
			private DateTime? _DatumRacuna;
			private EntityRef<tblAppMember> _tblAppMember;
			private EntityRef<tblBankaPrometVrsta> _tblBankaPrometVrsta;
			private EntityRef<tblBillFirmaTransakcijskiRacun> _tblBillFirmaTransakcijskiRacun;
			private EntitySet<tblBankaPrometDocument> _tblBankaPrometDocumentList;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnBankaPrometIDChanging(int value);
			partial void OnBankaPrometIDChanged();
			partial void OnBillFirmaTransakcijskiRacunIDChanging(int value);
			partial void OnBillFirmaTransakcijskiRacunIDChanged();
			partial void OnAppMemberIDChanging(long value);
			partial void OnAppMemberIDChanged();
			partial void OnInsertionDateChanging(DateTime value);
			partial void OnInsertionDateChanged();
			partial void OnDatumTransakcijeChanging(DateTime value);
			partial void OnDatumTransakcijeChanged();
			partial void OnPlatiteljPrimateljChanging(string value);
			partial void OnPlatiteljPrimateljChanged();
			partial void OnIbanPlatiteljaPrimateljaChanging(string value);
			partial void OnIbanPlatiteljaPrimateljaChanged();
			partial void OnPlatiteljModelChanging(string value);
			partial void OnPlatiteljModelChanged();
			partial void OnPlatiteljPozivNaBrojChanging(string value);
			partial void OnPlatiteljPozivNaBrojChanged();
			partial void OnPrimateljModelChanging(string value);
			partial void OnPrimateljModelChanged();
			partial void OnPrimateljPozivNaBrojChanging(string value);
			partial void OnPrimateljPozivNaBrojChanged();
			partial void OnMjestoChanging(string value);
			partial void OnMjestoChanged();
			partial void OnOpisPlacanjaChanging(string value);
			partial void OnOpisPlacanjaChanged();
			partial void OnRedniBrojChanging(int? value);
			partial void OnRedniBrojChanged();
			partial void OnSifraNamjeneChanging(string value);
			partial void OnSifraNamjeneChanged();
			partial void OnIsplataChanging(decimal? value);
			partial void OnIsplataChanged();
			partial void OnUplataChanging(decimal? value);
			partial void OnUplataChanged();
			partial void OnStanjeChanging(decimal? value);
			partial void OnStanjeChanged();
			partial void OnReferencaPlacanjaChanging(string value);
			partial void OnReferencaPlacanjaChanged();
			partial void OnNapomenaChanging(string value);
			partial void OnNapomenaChanged();
			partial void OnPoreznaOsnovicaChanging(decimal? value);
			partial void OnPoreznaOsnovicaChanged();
			partial void OnPdvChanging(decimal? value);
			partial void OnPdvChanged();
			partial void OnBankaPrometVrstaIDChanging(int? value);
			partial void OnBankaPrometVrstaIDChanged();
			partial void OnDatumRacunaChanging(DateTime? value);
			partial void OnDatumRacunaChanged();
			#endregion

			public tblBankaPromet()
			{
				_tblAppMember = default(EntityRef<tblAppMember>);
				_tblBankaPrometVrsta = default(EntityRef<tblBankaPrometVrsta>);
				_tblBillFirmaTransakcijskiRacun = default(EntityRef<tblBillFirmaTransakcijskiRacun>);
				_tblBankaPrometDocumentList = new EntitySet<tblBankaPrometDocument>(
					new Action<tblBankaPrometDocument>(item=>{this.SendPropertyChanging(); item.tblBankaPromet=this;}), 
					new Action<tblBankaPrometDocument>(item=>{this.SendPropertyChanging(); item.tblBankaPromet=null;}));
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=Int NOT NULL IDENTITY
			/// </summary>
			[ColumnAttribute(Storage="_BankaPrometID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", CanBeNull=false, IsPrimaryKey=true, IsDbGenerated=true)]
			public int BankaPrometID
			{
				get
				{
					return this._BankaPrometID;
				}
				set
				{
					if (this._BankaPrometID != value)
					{
						this.OnBankaPrometIDChanging(value);
						this.SendPropertyChanging();
						this._BankaPrometID = value;
						this.SendPropertyChanged("BankaPrometID");
						this.OnBankaPrometIDChanged();
					}
					this.SendPropertySetterInvoked("BankaPrometID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_BillFirmaTransakcijskiRacunID", DbType="Int NOT NULL", CanBeNull=false)]
			public int BillFirmaTransakcijskiRacunID
			{
				get
				{
					return this._BillFirmaTransakcijskiRacunID;
				}
				set
				{
					if (this._BillFirmaTransakcijskiRacunID != value)
					{
						this.OnBillFirmaTransakcijskiRacunIDChanging(value);
						this.SendPropertyChanging();
						this._BillFirmaTransakcijskiRacunID = value;
						this.SendPropertyChanged("BillFirmaTransakcijskiRacunID");
						this.OnBillFirmaTransakcijskiRacunIDChanged();
					}
					this.SendPropertySetterInvoked("BillFirmaTransakcijskiRacunID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=BigInt NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_AppMemberID", DbType="BigInt NOT NULL", CanBeNull=false)]
			public long AppMemberID
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
			[ColumnAttribute(Storage="_InsertionDate", DbType="DateTime NOT NULL", CanBeNull=false)]
			public DateTime InsertionDate
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
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_DatumTransakcije", DbType="DateTime NOT NULL", CanBeNull=false)]
			public DateTime DatumTransakcije
			{
				get
				{
					return this._DatumTransakcije;
				}
				set
				{
					if (this._DatumTransakcije != value)
					{
						this.OnDatumTransakcijeChanging(value);
						this.SendPropertyChanging();
						this._DatumTransakcije = value;
						this.SendPropertyChanged("DatumTransakcije");
						this.OnDatumTransakcijeChanged();
					}
					this.SendPropertySetterInvoked("DatumTransakcije", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(500)
			/// </summary>
			[ColumnAttribute(Storage="_PlatiteljPrimatelj", DbType="NVarChar(500)", CanBeNull=true)]
			public string PlatiteljPrimatelj
			{
				get
				{
					return this._PlatiteljPrimatelj;
				}
				set
				{
					if (this._PlatiteljPrimatelj != value)
					{
						this.OnPlatiteljPrimateljChanging(value);
						this.SendPropertyChanging();
						this._PlatiteljPrimatelj = value;
						this.SendPropertyChanged("PlatiteljPrimatelj");
						this.OnPlatiteljPrimateljChanged();
					}
					this.SendPropertySetterInvoked("PlatiteljPrimatelj", value);
				}
			}
			
			/// <summary>
			/// Column DbType=VarChar(100)
			/// </summary>
			[ColumnAttribute(Storage="_IbanPlatiteljaPrimatelja", DbType="VarChar(100)", CanBeNull=true)]
			public string IbanPlatiteljaPrimatelja
			{
				get
				{
					return this._IbanPlatiteljaPrimatelja;
				}
				set
				{
					if (this._IbanPlatiteljaPrimatelja != value)
					{
						this.OnIbanPlatiteljaPrimateljaChanging(value);
						this.SendPropertyChanging();
						this._IbanPlatiteljaPrimatelja = value;
						this.SendPropertyChanged("IbanPlatiteljaPrimatelja");
						this.OnIbanPlatiteljaPrimateljaChanged();
					}
					this.SendPropertySetterInvoked("IbanPlatiteljaPrimatelja", value);
				}
			}
			
			/// <summary>
			/// Column DbType=VarChar(50)
			/// </summary>
			[ColumnAttribute(Storage="_PlatiteljModel", DbType="VarChar(50)", CanBeNull=true)]
			public string PlatiteljModel
			{
				get
				{
					return this._PlatiteljModel;
				}
				set
				{
					if (this._PlatiteljModel != value)
					{
						this.OnPlatiteljModelChanging(value);
						this.SendPropertyChanging();
						this._PlatiteljModel = value;
						this.SendPropertyChanged("PlatiteljModel");
						this.OnPlatiteljModelChanged();
					}
					this.SendPropertySetterInvoked("PlatiteljModel", value);
				}
			}
			
			/// <summary>
			/// Column DbType=VarChar(100)
			/// </summary>
			[ColumnAttribute(Storage="_PlatiteljPozivNaBroj", DbType="VarChar(100)", CanBeNull=true)]
			public string PlatiteljPozivNaBroj
			{
				get
				{
					return this._PlatiteljPozivNaBroj;
				}
				set
				{
					if (this._PlatiteljPozivNaBroj != value)
					{
						this.OnPlatiteljPozivNaBrojChanging(value);
						this.SendPropertyChanging();
						this._PlatiteljPozivNaBroj = value;
						this.SendPropertyChanged("PlatiteljPozivNaBroj");
						this.OnPlatiteljPozivNaBrojChanged();
					}
					this.SendPropertySetterInvoked("PlatiteljPozivNaBroj", value);
				}
			}
			
			/// <summary>
			/// Column DbType=VarChar(50)
			/// </summary>
			[ColumnAttribute(Storage="_PrimateljModel", DbType="VarChar(50)", CanBeNull=true)]
			public string PrimateljModel
			{
				get
				{
					return this._PrimateljModel;
				}
				set
				{
					if (this._PrimateljModel != value)
					{
						this.OnPrimateljModelChanging(value);
						this.SendPropertyChanging();
						this._PrimateljModel = value;
						this.SendPropertyChanged("PrimateljModel");
						this.OnPrimateljModelChanged();
					}
					this.SendPropertySetterInvoked("PrimateljModel", value);
				}
			}
			
			/// <summary>
			/// Column DbType=VarChar(100)
			/// </summary>
			[ColumnAttribute(Storage="_PrimateljPozivNaBroj", DbType="VarChar(100)", CanBeNull=true)]
			public string PrimateljPozivNaBroj
			{
				get
				{
					return this._PrimateljPozivNaBroj;
				}
				set
				{
					if (this._PrimateljPozivNaBroj != value)
					{
						this.OnPrimateljPozivNaBrojChanging(value);
						this.SendPropertyChanging();
						this._PrimateljPozivNaBroj = value;
						this.SendPropertyChanged("PrimateljPozivNaBroj");
						this.OnPrimateljPozivNaBrojChanged();
					}
					this.SendPropertySetterInvoked("PrimateljPozivNaBroj", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(500)
			/// </summary>
			[ColumnAttribute(Storage="_Mjesto", DbType="NVarChar(500)", CanBeNull=true)]
			public string Mjesto
			{
				get
				{
					return this._Mjesto;
				}
				set
				{
					if (this._Mjesto != value)
					{
						this.OnMjestoChanging(value);
						this.SendPropertyChanging();
						this._Mjesto = value;
						this.SendPropertyChanged("Mjesto");
						this.OnMjestoChanged();
					}
					this.SendPropertySetterInvoked("Mjesto", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(500)
			/// </summary>
			[ColumnAttribute(Storage="_OpisPlacanja", DbType="NVarChar(500)", CanBeNull=true)]
			public string OpisPlacanja
			{
				get
				{
					return this._OpisPlacanja;
				}
				set
				{
					if (this._OpisPlacanja != value)
					{
						this.OnOpisPlacanjaChanging(value);
						this.SendPropertyChanging();
						this._OpisPlacanja = value;
						this.SendPropertyChanged("OpisPlacanja");
						this.OnOpisPlacanjaChanged();
					}
					this.SendPropertySetterInvoked("OpisPlacanja", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int
			/// </summary>
			[ColumnAttribute(Storage="_RedniBroj", DbType="Int", CanBeNull=true)]
			public int? RedniBroj
			{
				get
				{
					return this._RedniBroj;
				}
				set
				{
					if (this._RedniBroj != value)
					{
						this.OnRedniBrojChanging(value);
						this.SendPropertyChanging();
						this._RedniBroj = value;
						this.SendPropertyChanged("RedniBroj");
						this.OnRedniBrojChanged();
					}
					this.SendPropertySetterInvoked("RedniBroj", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(100)
			/// </summary>
			[ColumnAttribute(Storage="_SifraNamjene", DbType="NVarChar(100)", CanBeNull=true)]
			public string SifraNamjene
			{
				get
				{
					return this._SifraNamjene;
				}
				set
				{
					if (this._SifraNamjene != value)
					{
						this.OnSifraNamjeneChanging(value);
						this.SendPropertyChanging();
						this._SifraNamjene = value;
						this.SendPropertyChanged("SifraNamjene");
						this.OnSifraNamjeneChanged();
					}
					this.SendPropertySetterInvoked("SifraNamjene", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Money
			/// </summary>
			[ColumnAttribute(Storage="_Isplata", DbType="Money", CanBeNull=true)]
			public decimal? Isplata
			{
				get
				{
					return this._Isplata;
				}
				set
				{
					if (this._Isplata != value)
					{
						this.OnIsplataChanging(value);
						this.SendPropertyChanging();
						this._Isplata = value;
						this.SendPropertyChanged("Isplata");
						this.OnIsplataChanged();
					}
					this.SendPropertySetterInvoked("Isplata", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Money
			/// </summary>
			[ColumnAttribute(Storage="_Uplata", DbType="Money", CanBeNull=true)]
			public decimal? Uplata
			{
				get
				{
					return this._Uplata;
				}
				set
				{
					if (this._Uplata != value)
					{
						this.OnUplataChanging(value);
						this.SendPropertyChanging();
						this._Uplata = value;
						this.SendPropertyChanged("Uplata");
						this.OnUplataChanged();
					}
					this.SendPropertySetterInvoked("Uplata", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Money
			/// </summary>
			[ColumnAttribute(Storage="_Stanje", DbType="Money", CanBeNull=true)]
			public decimal? Stanje
			{
				get
				{
					return this._Stanje;
				}
				set
				{
					if (this._Stanje != value)
					{
						this.OnStanjeChanging(value);
						this.SendPropertyChanging();
						this._Stanje = value;
						this.SendPropertyChanged("Stanje");
						this.OnStanjeChanged();
					}
					this.SendPropertySetterInvoked("Stanje", value);
				}
			}
			
			/// <summary>
			/// Column DbType=VarChar(100)
			/// </summary>
			[ColumnAttribute(Storage="_ReferencaPlacanja", DbType="VarChar(100)", CanBeNull=true)]
			public string ReferencaPlacanja
			{
				get
				{
					return this._ReferencaPlacanja;
				}
				set
				{
					if (this._ReferencaPlacanja != value)
					{
						this.OnReferencaPlacanjaChanging(value);
						this.SendPropertyChanging();
						this._ReferencaPlacanja = value;
						this.SendPropertyChanged("ReferencaPlacanja");
						this.OnReferencaPlacanjaChanged();
					}
					this.SendPropertySetterInvoked("ReferencaPlacanja", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(500)
			/// </summary>
			[ColumnAttribute(Storage="_Napomena", DbType="NVarChar(500)", CanBeNull=true)]
			public string Napomena
			{
				get
				{
					return this._Napomena;
				}
				set
				{
					if (this._Napomena != value)
					{
						this.OnNapomenaChanging(value);
						this.SendPropertyChanging();
						this._Napomena = value;
						this.SendPropertyChanged("Napomena");
						this.OnNapomenaChanged();
					}
					this.SendPropertySetterInvoked("Napomena", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Money
			/// </summary>
			[ColumnAttribute(Storage="_PoreznaOsnovica", DbType="Money", CanBeNull=true)]
			public decimal? PoreznaOsnovica
			{
				get
				{
					return this._PoreznaOsnovica;
				}
				set
				{
					if (this._PoreznaOsnovica != value)
					{
						this.OnPoreznaOsnovicaChanging(value);
						this.SendPropertyChanging();
						this._PoreznaOsnovica = value;
						this.SendPropertyChanged("PoreznaOsnovica");
						this.OnPoreznaOsnovicaChanged();
					}
					this.SendPropertySetterInvoked("PoreznaOsnovica", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Money
			/// </summary>
			[ColumnAttribute(Storage="_Pdv", DbType="Money", CanBeNull=true)]
			public decimal? Pdv
			{
				get
				{
					return this._Pdv;
				}
				set
				{
					if (this._Pdv != value)
					{
						this.OnPdvChanging(value);
						this.SendPropertyChanging();
						this._Pdv = value;
						this.SendPropertyChanged("Pdv");
						this.OnPdvChanged();
					}
					this.SendPropertySetterInvoked("Pdv", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int
			/// </summary>
			[ColumnAttribute(Storage="_BankaPrometVrstaID", DbType="Int", CanBeNull=true)]
			public int? BankaPrometVrstaID
			{
				get
				{
					return this._BankaPrometVrstaID;
				}
				set
				{
					if (this._BankaPrometVrstaID != value)
					{
						this.OnBankaPrometVrstaIDChanging(value);
						this.SendPropertyChanging();
						this._BankaPrometVrstaID = value;
						this.SendPropertyChanged("BankaPrometVrstaID");
						this.OnBankaPrometVrstaIDChanged();
					}
					this.SendPropertySetterInvoked("BankaPrometVrstaID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime
			/// </summary>
			[ColumnAttribute(Storage="_DatumRacuna", DbType="DateTime", CanBeNull=true)]
			public DateTime? DatumRacuna
			{
				get
				{
					return this._DatumRacuna;
				}
				set
				{
					if (this._DatumRacuna != value)
					{
						this.OnDatumRacunaChanging(value);
						this.SendPropertyChanging();
						this._DatumRacuna = value;
						this.SendPropertyChanged("DatumRacuna");
						this.OnDatumRacunaChanged();
					}
					this.SendPropertySetterInvoked("DatumRacuna", value);
				}
			}
			
			#endregion Columns

			#region Associations
			/// <summary>
			/// Association [FK][Many]tblBankaPromet.AppMemberID --- [PK][One]tblAppMember.AppMemberID
			/// </summary>
			[AssociationAttribute(Name="FK_tblBankaPromet_tblAppMember", Storage="_tblAppMember", ThisKey="AppMemberID", OtherKey="AppMemberID", IsUnique=false, IsForeignKey=true)]
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
							previousValue.tblBankaPrometList.Remove(this);
						}
						this._tblAppMember.Entity = value;
						if (value != null)
						{
							value.tblBankaPrometList.Add(this);
							this._AppMemberID = value.AppMemberID;
						}
						else
						{
							this._AppMemberID = default(long);
						}
						this.SendPropertyChanged("tblAppMember");
					}
					this.SendPropertySetterInvoked("tblAppMember", value);
				}
			}
			
			/// <summary>
			/// Association [FK][Many]tblBankaPromet.BankaPrometVrstaID --- [PK][One]tblBankaPrometVrsta.BankaPrometVrstaID
			/// </summary>
			[AssociationAttribute(Name="FK_tblBankaPromet_tblBankaPrometVrsta", Storage="_tblBankaPrometVrsta", ThisKey="BankaPrometVrstaID", OtherKey="BankaPrometVrstaID", IsUnique=false, IsForeignKey=true)]
			public tblBankaPrometVrsta tblBankaPrometVrsta
			{
				get
				{
					return this._tblBankaPrometVrsta.Entity;
				}
				set
				{
					tblBankaPrometVrsta previousValue = this._tblBankaPrometVrsta.Entity;
					if ((previousValue != value) || (this._tblBankaPrometVrsta.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._tblBankaPrometVrsta.Entity = null;
							previousValue.tblBankaPrometList.Remove(this);
						}
						this._tblBankaPrometVrsta.Entity = value;
						if (value != null)
						{
							value.tblBankaPrometList.Add(this);
							this._BankaPrometVrstaID = value.BankaPrometVrstaID;
						}
						else
						{
							this._BankaPrometVrstaID = default(int?);
						}
						this.SendPropertyChanged("tblBankaPrometVrsta");
					}
					this.SendPropertySetterInvoked("tblBankaPrometVrsta", value);
				}
			}
			
			/// <summary>
			/// Association [FK][Many]tblBankaPromet.BillFirmaTransakcijskiRacunID --- [PK][One]tblBillFirmaTransakcijskiRacun.BillFirmaTransakcijskiRacunID
			/// </summary>
			[AssociationAttribute(Name="FK_tblBankaPromet_tblBillFirmaTransakcijskiRacun", Storage="_tblBillFirmaTransakcijskiRacun", ThisKey="BillFirmaTransakcijskiRacunID", OtherKey="BillFirmaTransakcijskiRacunID", IsUnique=false, IsForeignKey=true)]
			public tblBillFirmaTransakcijskiRacun tblBillFirmaTransakcijskiRacun
			{
				get
				{
					return this._tblBillFirmaTransakcijskiRacun.Entity;
				}
				set
				{
					tblBillFirmaTransakcijskiRacun previousValue = this._tblBillFirmaTransakcijskiRacun.Entity;
					if ((previousValue != value) || (this._tblBillFirmaTransakcijskiRacun.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._tblBillFirmaTransakcijskiRacun.Entity = null;
							previousValue.tblBankaPrometList.Remove(this);
						}
						this._tblBillFirmaTransakcijskiRacun.Entity = value;
						if (value != null)
						{
							value.tblBankaPrometList.Add(this);
							this._BillFirmaTransakcijskiRacunID = value.BillFirmaTransakcijskiRacunID;
						}
						else
						{
							this._BillFirmaTransakcijskiRacunID = default(int);
						}
						this.SendPropertyChanged("tblBillFirmaTransakcijskiRacun");
					}
					this.SendPropertySetterInvoked("tblBillFirmaTransakcijskiRacun", value);
				}
			}
			
			/// <summary>
			/// Association [PK][One]tblBankaPromet.BankaPrometID --- [FK][Many]tblBankaPrometDocument.BankaPrometID
			/// </summary>
			[AssociationAttribute(Name="FK_tblBankaPrometDocument_tblBankaPromet", Storage="_tblBankaPrometDocumentList", ThisKey="BankaPrometID", OtherKey="BankaPrometID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<tblBankaPrometDocument> tblBankaPrometDocumentList
			{
				get { return this._tblBankaPrometDocumentList; }
				set { this._tblBankaPrometDocumentList.Assign(value); }
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
		#endregion dbo.tblBankaPromet

		#region dbo.tblBankaPrometDocument
		[TableAttribute(Name="dbo.tblBankaPrometDocument")]
		public partial class tblBankaPrometDocument : EntityBase<tblBankaPrometDocument, dbArizonaAppDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private int _BankaPrometDocumentID;
			private int _BankaPrometID;
			private string _FileName;
			private byte[] _FileContent;
			private EntityRef<tblBankaPromet> _tblBankaPromet;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnBankaPrometDocumentIDChanging(int value);
			partial void OnBankaPrometDocumentIDChanged();
			partial void OnBankaPrometIDChanging(int value);
			partial void OnBankaPrometIDChanged();
			partial void OnFileNameChanging(string value);
			partial void OnFileNameChanged();
			partial void OnFileContentChanging(byte[] value);
			partial void OnFileContentChanged();
			#endregion

			public tblBankaPrometDocument()
			{
				_tblBankaPromet = default(EntityRef<tblBankaPromet>);
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=Int NOT NULL IDENTITY
			/// </summary>
			[ColumnAttribute(Storage="_BankaPrometDocumentID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", CanBeNull=false, IsPrimaryKey=true, IsDbGenerated=true)]
			public int BankaPrometDocumentID
			{
				get
				{
					return this._BankaPrometDocumentID;
				}
				set
				{
					if (this._BankaPrometDocumentID != value)
					{
						this.OnBankaPrometDocumentIDChanging(value);
						this.SendPropertyChanging();
						this._BankaPrometDocumentID = value;
						this.SendPropertyChanged("BankaPrometDocumentID");
						this.OnBankaPrometDocumentIDChanged();
					}
					this.SendPropertySetterInvoked("BankaPrometDocumentID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_BankaPrometID", DbType="Int NOT NULL", CanBeNull=false)]
			public int BankaPrometID
			{
				get
				{
					return this._BankaPrometID;
				}
				set
				{
					if (this._BankaPrometID != value)
					{
						this.OnBankaPrometIDChanging(value);
						this.SendPropertyChanging();
						this._BankaPrometID = value;
						this.SendPropertyChanged("BankaPrometID");
						this.OnBankaPrometIDChanged();
					}
					this.SendPropertySetterInvoked("BankaPrometID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(100)
			/// </summary>
			[ColumnAttribute(Storage="_FileName", DbType="NVarChar(100)", CanBeNull=true)]
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
			[ColumnAttribute(Storage="_FileContent", DbType="VarBinary(MAX)", CanBeNull=true)]
			public byte[] FileContent
			{
				get
				{
					return this._FileContent;
				}
				set
				{
					if (this._FileContent != value)
					{
						this.OnFileContentChanging(value);
						this.SendPropertyChanging();
						this._FileContent = value;
						this.SendPropertyChanged("FileContent");
						this.OnFileContentChanged();
					}
					this.SendPropertySetterInvoked("FileContent", value);
				}
			}
			
			#endregion Columns

			#region Associations
			/// <summary>
			/// Association [FK][Many]tblBankaPrometDocument.BankaPrometID --- [PK][One]tblBankaPromet.BankaPrometID
			/// </summary>
			[AssociationAttribute(Name="FK_tblBankaPrometDocument_tblBankaPromet", Storage="_tblBankaPromet", ThisKey="BankaPrometID", OtherKey="BankaPrometID", IsUnique=false, IsForeignKey=true)]
			public tblBankaPromet tblBankaPromet
			{
				get
				{
					return this._tblBankaPromet.Entity;
				}
				set
				{
					tblBankaPromet previousValue = this._tblBankaPromet.Entity;
					if ((previousValue != value) || (this._tblBankaPromet.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._tblBankaPromet.Entity = null;
							previousValue.tblBankaPrometDocumentList.Remove(this);
						}
						this._tblBankaPromet.Entity = value;
						if (value != null)
						{
							value.tblBankaPrometDocumentList.Add(this);
							this._BankaPrometID = value.BankaPrometID;
						}
						else
						{
							this._BankaPrometID = default(int);
						}
						this.SendPropertyChanged("tblBankaPromet");
					}
					this.SendPropertySetterInvoked("tblBankaPromet", value);
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
		#endregion dbo.tblBankaPrometDocument

		#region dbo.tblBankaPrometVrsta
		[TableAttribute(Name="dbo.tblBankaPrometVrsta")]
		public partial class tblBankaPrometVrsta : EntityBase<tblBankaPrometVrsta, dbArizonaAppDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private int _BankaPrometVrstaID;
			private string _Name;
			private bool _IsPrihod;
			private bool _IsRashod;
			private EntitySet<tblBankaPromet> _tblBankaPrometList;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnBankaPrometVrstaIDChanging(int value);
			partial void OnBankaPrometVrstaIDChanged();
			partial void OnNameChanging(string value);
			partial void OnNameChanged();
			partial void OnIsPrihodChanging(bool value);
			partial void OnIsPrihodChanged();
			partial void OnIsRashodChanging(bool value);
			partial void OnIsRashodChanged();
			#endregion

			public tblBankaPrometVrsta()
			{
				_tblBankaPrometList = new EntitySet<tblBankaPromet>(
					new Action<tblBankaPromet>(item=>{this.SendPropertyChanging(); item.tblBankaPrometVrsta=this;}), 
					new Action<tblBankaPromet>(item=>{this.SendPropertyChanging(); item.tblBankaPrometVrsta=null;}));
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_BankaPrometVrstaID", DbType="Int NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
			public int BankaPrometVrstaID
			{
				get
				{
					return this._BankaPrometVrstaID;
				}
				set
				{
					if (this._BankaPrometVrstaID != value)
					{
						this.OnBankaPrometVrstaIDChanging(value);
						this.SendPropertyChanging();
						this._BankaPrometVrstaID = value;
						this.SendPropertyChanged("BankaPrometVrstaID");
						this.OnBankaPrometVrstaIDChanged();
					}
					this.SendPropertySetterInvoked("BankaPrometVrstaID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(150) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_Name", DbType="NVarChar(150) NOT NULL", CanBeNull=false)]
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
			/// Column DbType=Bit NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_IsPrihod", DbType="Bit NOT NULL", CanBeNull=false)]
			public bool IsPrihod
			{
				get
				{
					return this._IsPrihod;
				}
				set
				{
					if (this._IsPrihod != value)
					{
						this.OnIsPrihodChanging(value);
						this.SendPropertyChanging();
						this._IsPrihod = value;
						this.SendPropertyChanged("IsPrihod");
						this.OnIsPrihodChanged();
					}
					this.SendPropertySetterInvoked("IsPrihod", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Bit NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_IsRashod", DbType="Bit NOT NULL", CanBeNull=false)]
			public bool IsRashod
			{
				get
				{
					return this._IsRashod;
				}
				set
				{
					if (this._IsRashod != value)
					{
						this.OnIsRashodChanging(value);
						this.SendPropertyChanging();
						this._IsRashod = value;
						this.SendPropertyChanged("IsRashod");
						this.OnIsRashodChanged();
					}
					this.SendPropertySetterInvoked("IsRashod", value);
				}
			}
			
			#endregion Columns

			#region Associations
			/// <summary>
			/// Association [PK][One]tblBankaPrometVrsta.BankaPrometVrstaID --- [FK][Many]tblBankaPromet.BankaPrometVrstaID
			/// </summary>
			[AssociationAttribute(Name="FK_tblBankaPromet_tblBankaPrometVrsta", Storage="_tblBankaPrometList", ThisKey="BankaPrometVrstaID", OtherKey="BankaPrometVrstaID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<tblBankaPromet> tblBankaPrometList
			{
				get { return this._tblBankaPrometList; }
				set { this._tblBankaPrometList.Assign(value); }
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
		#endregion dbo.tblBankaPrometVrsta

		#region dbo.tblBillCategory
		[TableAttribute(Name="dbo.tblBillCategory")]
		public partial class tblBillCategory : EntityBase<tblBillCategory, dbArizonaAppDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private long _BillCategoryID;
			private long? _ParentBillCategoryID;
			private long _BillPoslovniProstorID;
			private string _Naziv;
			private int _Ordinal;
			private bool _IsPosVisible;
			private EntityRef<tblBillCategory> _ParentBillCategory;
			private EntitySet<tblBillCategory> _BillCategoryList;
			private EntityRef<tblBillPoslovniProstor> _tblBillPoslovniProstor;
			private EntitySet<tblBillProductCategory> _tblBillProductCategoryList;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnBillCategoryIDChanging(long value);
			partial void OnBillCategoryIDChanged();
			partial void OnParentBillCategoryIDChanging(long? value);
			partial void OnParentBillCategoryIDChanged();
			partial void OnBillPoslovniProstorIDChanging(long value);
			partial void OnBillPoslovniProstorIDChanged();
			partial void OnNazivChanging(string value);
			partial void OnNazivChanged();
			partial void OnOrdinalChanging(int value);
			partial void OnOrdinalChanged();
			partial void OnIsPosVisibleChanging(bool value);
			partial void OnIsPosVisibleChanged();
			#endregion

			public tblBillCategory()
			{
				_ParentBillCategory = default(EntityRef<tblBillCategory>);
				_BillCategoryList = new EntitySet<tblBillCategory>(
					new Action<tblBillCategory>(item=>{this.SendPropertyChanging(); item.ParentBillCategory=this;}), 
					new Action<tblBillCategory>(item=>{this.SendPropertyChanging(); item.ParentBillCategory=null;}));
				_tblBillPoslovniProstor = default(EntityRef<tblBillPoslovniProstor>);
				_tblBillProductCategoryList = new EntitySet<tblBillProductCategory>(
					new Action<tblBillProductCategory>(item=>{this.SendPropertyChanging(); item.tblBillCategory=this;}), 
					new Action<tblBillProductCategory>(item=>{this.SendPropertyChanging(); item.tblBillCategory=null;}));
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=BigInt NOT NULL IDENTITY
			/// </summary>
			[ColumnAttribute(Storage="_BillCategoryID", AutoSync=AutoSync.OnInsert, DbType="BigInt NOT NULL IDENTITY", CanBeNull=false, IsPrimaryKey=true, IsDbGenerated=true)]
			public long BillCategoryID
			{
				get
				{
					return this._BillCategoryID;
				}
				set
				{
					if (this._BillCategoryID != value)
					{
						this.OnBillCategoryIDChanging(value);
						this.SendPropertyChanging();
						this._BillCategoryID = value;
						this.SendPropertyChanged("BillCategoryID");
						this.OnBillCategoryIDChanged();
					}
					this.SendPropertySetterInvoked("BillCategoryID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=BigInt
			/// </summary>
			[ColumnAttribute(Storage="_ParentBillCategoryID", DbType="BigInt", CanBeNull=true)]
			public long? ParentBillCategoryID
			{
				get
				{
					return this._ParentBillCategoryID;
				}
				set
				{
					if (this._ParentBillCategoryID != value)
					{
						this.OnParentBillCategoryIDChanging(value);
						this.SendPropertyChanging();
						this._ParentBillCategoryID = value;
						this.SendPropertyChanged("ParentBillCategoryID");
						this.OnParentBillCategoryIDChanged();
					}
					this.SendPropertySetterInvoked("ParentBillCategoryID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=BigInt NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_BillPoslovniProstorID", DbType="BigInt NOT NULL", CanBeNull=false)]
			public long BillPoslovniProstorID
			{
				get
				{
					return this._BillPoslovniProstorID;
				}
				set
				{
					if (this._BillPoslovniProstorID != value)
					{
						this.OnBillPoslovniProstorIDChanging(value);
						this.SendPropertyChanging();
						this._BillPoslovniProstorID = value;
						this.SendPropertyChanged("BillPoslovniProstorID");
						this.OnBillPoslovniProstorIDChanged();
					}
					this.SendPropertySetterInvoked("BillPoslovniProstorID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(250) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_Naziv", DbType="NVarChar(250) NOT NULL", CanBeNull=false)]
			public string Naziv
			{
				get
				{
					return this._Naziv;
				}
				set
				{
					if (this._Naziv != value)
					{
						this.OnNazivChanging(value);
						this.SendPropertyChanging();
						this._Naziv = value;
						this.SendPropertyChanged("Naziv");
						this.OnNazivChanged();
					}
					this.SendPropertySetterInvoked("Naziv", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_Ordinal", DbType="Int NOT NULL", CanBeNull=false)]
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
						this.OnOrdinalChanging(value);
						this.SendPropertyChanging();
						this._Ordinal = value;
						this.SendPropertyChanged("Ordinal");
						this.OnOrdinalChanged();
					}
					this.SendPropertySetterInvoked("Ordinal", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Bit NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_IsPosVisible", DbType="Bit NOT NULL", CanBeNull=false)]
			public bool IsPosVisible
			{
				get
				{
					return this._IsPosVisible;
				}
				set
				{
					if (this._IsPosVisible != value)
					{
						this.OnIsPosVisibleChanging(value);
						this.SendPropertyChanging();
						this._IsPosVisible = value;
						this.SendPropertyChanged("IsPosVisible");
						this.OnIsPosVisibleChanged();
					}
					this.SendPropertySetterInvoked("IsPosVisible", value);
				}
			}
			
			#endregion Columns

			#region Associations
			/// <summary>
			/// Association [FK][Many]tblBillCategory.ParentBillCategoryID --- [PK][One]tblBillCategory.BillCategoryID
			/// </summary>
			[AssociationAttribute(Name="FK_tblBillCategory_tblBillCategory", Storage="_ParentBillCategory", ThisKey="ParentBillCategoryID", OtherKey="BillCategoryID", IsUnique=false, IsForeignKey=true)]
			public tblBillCategory ParentBillCategory
			{
				get
				{
					return this._ParentBillCategory.Entity;
				}
				set
				{
					tblBillCategory previousValue = this._ParentBillCategory.Entity;
					if ((previousValue != value) || (this._ParentBillCategory.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._ParentBillCategory.Entity = null;
							previousValue.BillCategoryList.Remove(this);
						}
						this._ParentBillCategory.Entity = value;
						if (value != null)
						{
							value.BillCategoryList.Add(this);
							this._ParentBillCategoryID = value.BillCategoryID;
						}
						else
						{
							this._ParentBillCategoryID = default(long?);
						}
						this.SendPropertyChanged("ParentBillCategory");
					}
					this.SendPropertySetterInvoked("ParentBillCategory", value);
				}
			}
			
			/// <summary>
			/// Association [PK][One]tblBillCategory.BillCategoryID --- [FK][Many]tblBillCategory.ParentBillCategoryID
			/// </summary>
			[AssociationAttribute(Name="FK_tblBillCategory_tblBillCategory", Storage="_BillCategoryList", ThisKey="BillCategoryID", OtherKey="ParentBillCategoryID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<tblBillCategory> BillCategoryList
			{
				get { return this._BillCategoryList; }
				set { this._BillCategoryList.Assign(value); }
			}
			
			/// <summary>
			/// Association [FK][Many]tblBillCategory.BillPoslovniProstorID --- [PK][One]tblBillPoslovniProstor.BillPoslovniProstorID
			/// </summary>
			[AssociationAttribute(Name="FK_tblBillCategory_tblBillPoslovniProstor", Storage="_tblBillPoslovniProstor", ThisKey="BillPoslovniProstorID", OtherKey="BillPoslovniProstorID", IsUnique=false, IsForeignKey=true)]
			public tblBillPoslovniProstor tblBillPoslovniProstor
			{
				get
				{
					return this._tblBillPoslovniProstor.Entity;
				}
				set
				{
					tblBillPoslovniProstor previousValue = this._tblBillPoslovniProstor.Entity;
					if ((previousValue != value) || (this._tblBillPoslovniProstor.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._tblBillPoslovniProstor.Entity = null;
							previousValue.tblBillCategoryList.Remove(this);
						}
						this._tblBillPoslovniProstor.Entity = value;
						if (value != null)
						{
							value.tblBillCategoryList.Add(this);
							this._BillPoslovniProstorID = value.BillPoslovniProstorID;
						}
						else
						{
							this._BillPoslovniProstorID = default(long);
						}
						this.SendPropertyChanged("tblBillPoslovniProstor");
					}
					this.SendPropertySetterInvoked("tblBillPoslovniProstor", value);
				}
			}
			
			/// <summary>
			/// Association [PK][One]tblBillCategory.BillCategoryID --- [FK][Many]tblBillProductCategory.BillCategoryID
			/// </summary>
			[AssociationAttribute(Name="FK_tblBillProductCategory_tblBillCategory", Storage="_tblBillProductCategoryList", ThisKey="BillCategoryID", OtherKey="BillCategoryID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<tblBillProductCategory> tblBillProductCategoryList
			{
				get { return this._tblBillProductCategoryList; }
				set { this._tblBillProductCategoryList.Assign(value); }
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
		#endregion dbo.tblBillCategory

		#region dbo.tblBillClient
		[TableAttribute(Name="dbo.tblBillClient")]
		public partial class tblBillClient : EntityBase<tblBillClient, dbArizonaAppDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private long _BillClientID;
			private DateTime _InsertionDate;
			private int _BillFirmaID;
			private int? _ArizonaClientID;
			private string _MBO;
			private string _MBS;
			private string _OIB;
			private string _Naziv;
			private string _Adresa;
			private string _Naselje;
			private string _PostanskiBroj;
			private string _PostanskiUred;
			private string _OdgovornaOsoba;
			private bool? _IsVlasnik;
			private string _IBAN;
			private EntityRef<tblBillFirma> _tblBillFirma;
			private EntityRef<tblDirClient> _tblDirClient;
			private EntityRef<tblBillClientFullText> _tblBillClientFullText;
			private EntitySet<tblBillDocument> _tblBillDocumentList;
			private EntitySet<tblSocialMember> _tblSocialMemberList;
			private EntitySet<tblSocialMemberBillClient> _tblSocialMemberBillClientList;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnBillClientIDChanging(long value);
			partial void OnBillClientIDChanged();
			partial void OnInsertionDateChanging(DateTime value);
			partial void OnInsertionDateChanged();
			partial void OnBillFirmaIDChanging(int value);
			partial void OnBillFirmaIDChanged();
			partial void OnArizonaClientIDChanging(int? value);
			partial void OnArizonaClientIDChanged();
			partial void OnMBOChanging(string value);
			partial void OnMBOChanged();
			partial void OnMBSChanging(string value);
			partial void OnMBSChanged();
			partial void OnOIBChanging(string value);
			partial void OnOIBChanged();
			partial void OnNazivChanging(string value);
			partial void OnNazivChanged();
			partial void OnAdresaChanging(string value);
			partial void OnAdresaChanged();
			partial void OnNaseljeChanging(string value);
			partial void OnNaseljeChanged();
			partial void OnPostanskiBrojChanging(string value);
			partial void OnPostanskiBrojChanged();
			partial void OnPostanskiUredChanging(string value);
			partial void OnPostanskiUredChanged();
			partial void OnOdgovornaOsobaChanging(string value);
			partial void OnOdgovornaOsobaChanged();
			partial void OnIsVlasnikChanging(bool? value);
			partial void OnIsVlasnikChanged();
			partial void OnIBANChanging(string value);
			partial void OnIBANChanged();
			#endregion

			public tblBillClient()
			{
				_tblBillFirma = default(EntityRef<tblBillFirma>);
				_tblDirClient = default(EntityRef<tblDirClient>);
				_tblBillClientFullText = default(EntityRef<tblBillClientFullText>);
				_tblBillDocumentList = new EntitySet<tblBillDocument>(
					new Action<tblBillDocument>(item=>{this.SendPropertyChanging(); item.tblBillClient=this;}), 
					new Action<tblBillDocument>(item=>{this.SendPropertyChanging(); item.tblBillClient=null;}));
				_tblSocialMemberList = new EntitySet<tblSocialMember>(
					new Action<tblSocialMember>(item=>{this.SendPropertyChanging(); item.tblBillClient=this;}), 
					new Action<tblSocialMember>(item=>{this.SendPropertyChanging(); item.tblBillClient=null;}));
				_tblSocialMemberBillClientList = new EntitySet<tblSocialMemberBillClient>(
					new Action<tblSocialMemberBillClient>(item=>{this.SendPropertyChanging(); item.tblBillClient=this;}), 
					new Action<tblSocialMemberBillClient>(item=>{this.SendPropertyChanging(); item.tblBillClient=null;}));
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=BigInt NOT NULL IDENTITY
			/// </summary>
			[ColumnAttribute(Storage="_BillClientID", AutoSync=AutoSync.OnInsert, DbType="BigInt NOT NULL IDENTITY", CanBeNull=false, IsPrimaryKey=true, IsDbGenerated=true)]
			public long BillClientID
			{
				get
				{
					return this._BillClientID;
				}
				set
				{
					if (this._BillClientID != value)
					{
						this.OnBillClientIDChanging(value);
						this.SendPropertyChanging();
						this._BillClientID = value;
						this.SendPropertyChanged("BillClientID");
						this.OnBillClientIDChanged();
					}
					this.SendPropertySetterInvoked("BillClientID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_InsertionDate", DbType="DateTime NOT NULL", CanBeNull=false)]
			public DateTime InsertionDate
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
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_BillFirmaID", DbType="Int NOT NULL", CanBeNull=false)]
			public int BillFirmaID
			{
				get
				{
					return this._BillFirmaID;
				}
				set
				{
					if (this._BillFirmaID != value)
					{
						this.OnBillFirmaIDChanging(value);
						this.SendPropertyChanging();
						this._BillFirmaID = value;
						this.SendPropertyChanged("BillFirmaID");
						this.OnBillFirmaIDChanged();
					}
					this.SendPropertySetterInvoked("BillFirmaID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int
			/// </summary>
			[ColumnAttribute(Storage="_ArizonaClientID", DbType="Int", CanBeNull=true)]
			public int? ArizonaClientID
			{
				get
				{
					return this._ArizonaClientID;
				}
				set
				{
					if (this._ArizonaClientID != value)
					{
						this.OnArizonaClientIDChanging(value);
						this.SendPropertyChanging();
						this._ArizonaClientID = value;
						this.SendPropertyChanged("ArizonaClientID");
						this.OnArizonaClientIDChanged();
					}
					this.SendPropertySetterInvoked("ArizonaClientID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=VarChar(20)
			/// </summary>
			[ColumnAttribute(Storage="_MBO", DbType="VarChar(20)", CanBeNull=true)]
			public string MBO
			{
				get
				{
					return this._MBO;
				}
				set
				{
					if (this._MBO != value)
					{
						this.OnMBOChanging(value);
						this.SendPropertyChanging();
						this._MBO = value;
						this.SendPropertyChanged("MBO");
						this.OnMBOChanged();
					}
					this.SendPropertySetterInvoked("MBO", value);
				}
			}
			
			/// <summary>
			/// Column DbType=VarChar(20)
			/// </summary>
			[ColumnAttribute(Storage="_MBS", DbType="VarChar(20)", CanBeNull=true)]
			public string MBS
			{
				get
				{
					return this._MBS;
				}
				set
				{
					if (this._MBS != value)
					{
						this.OnMBSChanging(value);
						this.SendPropertyChanging();
						this._MBS = value;
						this.SendPropertyChanged("MBS");
						this.OnMBSChanged();
					}
					this.SendPropertySetterInvoked("MBS", value);
				}
			}
			
			/// <summary>
			/// Column DbType=VarChar(20)
			/// </summary>
			[ColumnAttribute(Storage="_OIB", DbType="VarChar(20)", CanBeNull=true)]
			public string OIB
			{
				get
				{
					return this._OIB;
				}
				set
				{
					if (this._OIB != value)
					{
						this.OnOIBChanging(value);
						this.SendPropertyChanging();
						this._OIB = value;
						this.SendPropertyChanged("OIB");
						this.OnOIBChanged();
					}
					this.SendPropertySetterInvoked("OIB", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(250)
			/// </summary>
			[ColumnAttribute(Storage="_Naziv", DbType="NVarChar(250)", CanBeNull=true)]
			public string Naziv
			{
				get
				{
					return this._Naziv;
				}
				set
				{
					if (this._Naziv != value)
					{
						this.OnNazivChanging(value);
						this.SendPropertyChanging();
						this._Naziv = value;
						this.SendPropertyChanged("Naziv");
						this.OnNazivChanged();
					}
					this.SendPropertySetterInvoked("Naziv", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(250)
			/// </summary>
			[ColumnAttribute(Storage="_Adresa", DbType="NVarChar(250)", CanBeNull=true)]
			public string Adresa
			{
				get
				{
					return this._Adresa;
				}
				set
				{
					if (this._Adresa != value)
					{
						this.OnAdresaChanging(value);
						this.SendPropertyChanging();
						this._Adresa = value;
						this.SendPropertyChanged("Adresa");
						this.OnAdresaChanged();
					}
					this.SendPropertySetterInvoked("Adresa", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(250)
			/// </summary>
			[ColumnAttribute(Storage="_Naselje", DbType="NVarChar(250)", CanBeNull=true)]
			public string Naselje
			{
				get
				{
					return this._Naselje;
				}
				set
				{
					if (this._Naselje != value)
					{
						this.OnNaseljeChanging(value);
						this.SendPropertyChanging();
						this._Naselje = value;
						this.SendPropertyChanged("Naselje");
						this.OnNaseljeChanged();
					}
					this.SendPropertySetterInvoked("Naselje", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(50)
			/// </summary>
			[ColumnAttribute(Storage="_PostanskiBroj", DbType="NVarChar(50)", CanBeNull=true)]
			public string PostanskiBroj
			{
				get
				{
					return this._PostanskiBroj;
				}
				set
				{
					if (this._PostanskiBroj != value)
					{
						this.OnPostanskiBrojChanging(value);
						this.SendPropertyChanging();
						this._PostanskiBroj = value;
						this.SendPropertyChanged("PostanskiBroj");
						this.OnPostanskiBrojChanged();
					}
					this.SendPropertySetterInvoked("PostanskiBroj", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(250)
			/// </summary>
			[ColumnAttribute(Storage="_PostanskiUred", DbType="NVarChar(250)", CanBeNull=true)]
			public string PostanskiUred
			{
				get
				{
					return this._PostanskiUred;
				}
				set
				{
					if (this._PostanskiUred != value)
					{
						this.OnPostanskiUredChanging(value);
						this.SendPropertyChanging();
						this._PostanskiUred = value;
						this.SendPropertyChanged("PostanskiUred");
						this.OnPostanskiUredChanged();
					}
					this.SendPropertySetterInvoked("PostanskiUred", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(100)
			/// </summary>
			[ColumnAttribute(Storage="_OdgovornaOsoba", DbType="NVarChar(100)", CanBeNull=true)]
			public string OdgovornaOsoba
			{
				get
				{
					return this._OdgovornaOsoba;
				}
				set
				{
					if (this._OdgovornaOsoba != value)
					{
						this.OnOdgovornaOsobaChanging(value);
						this.SendPropertyChanging();
						this._OdgovornaOsoba = value;
						this.SendPropertyChanged("OdgovornaOsoba");
						this.OnOdgovornaOsobaChanged();
					}
					this.SendPropertySetterInvoked("OdgovornaOsoba", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Bit
			/// </summary>
			[ColumnAttribute(Storage="_IsVlasnik", DbType="Bit", CanBeNull=true)]
			public bool? IsVlasnik
			{
				get
				{
					return this._IsVlasnik;
				}
				set
				{
					if (this._IsVlasnik != value)
					{
						this.OnIsVlasnikChanging(value);
						this.SendPropertyChanging();
						this._IsVlasnik = value;
						this.SendPropertyChanged("IsVlasnik");
						this.OnIsVlasnikChanged();
					}
					this.SendPropertySetterInvoked("IsVlasnik", value);
				}
			}
			
			/// <summary>
			/// Column DbType=VarChar(50)
			/// </summary>
			[ColumnAttribute(Storage="_IBAN", DbType="VarChar(50)", CanBeNull=true)]
			public string IBAN
			{
				get
				{
					return this._IBAN;
				}
				set
				{
					if (this._IBAN != value)
					{
						this.OnIBANChanging(value);
						this.SendPropertyChanging();
						this._IBAN = value;
						this.SendPropertyChanged("IBAN");
						this.OnIBANChanged();
					}
					this.SendPropertySetterInvoked("IBAN", value);
				}
			}
			
			#endregion Columns

			#region Associations
			/// <summary>
			/// Association [FK][Many]tblBillClient.BillFirmaID --- [PK][One]tblBillFirma.BillFirmaID
			/// </summary>
			[AssociationAttribute(Name="FK_tblBillClient_tblBillFirma", Storage="_tblBillFirma", ThisKey="BillFirmaID", OtherKey="BillFirmaID", IsUnique=false, IsForeignKey=true)]
			public tblBillFirma tblBillFirma
			{
				get
				{
					return this._tblBillFirma.Entity;
				}
				set
				{
					tblBillFirma previousValue = this._tblBillFirma.Entity;
					if ((previousValue != value) || (this._tblBillFirma.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._tblBillFirma.Entity = null;
							previousValue.tblBillClientList.Remove(this);
						}
						this._tblBillFirma.Entity = value;
						if (value != null)
						{
							value.tblBillClientList.Add(this);
							this._BillFirmaID = value.BillFirmaID;
						}
						else
						{
							this._BillFirmaID = default(int);
						}
						this.SendPropertyChanged("tblBillFirma");
					}
					this.SendPropertySetterInvoked("tblBillFirma", value);
				}
			}
			
			/// <summary>
			/// Association [FK][Many]tblBillClient.ArizonaClientID --- [PK][One]tblDirClient.ArizonaClientID
			/// </summary>
			[AssociationAttribute(Name="FK_tblBillClient_tblDirClient", Storage="_tblDirClient", ThisKey="ArizonaClientID", OtherKey="ArizonaClientID", IsUnique=false, IsForeignKey=true)]
			public tblDirClient tblDirClient
			{
				get
				{
					return this._tblDirClient.Entity;
				}
				set
				{
					tblDirClient previousValue = this._tblDirClient.Entity;
					if ((previousValue != value) || (this._tblDirClient.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._tblDirClient.Entity = null;
							previousValue.tblBillClientList.Remove(this);
						}
						this._tblDirClient.Entity = value;
						if (value != null)
						{
							value.tblBillClientList.Add(this);
							this._ArizonaClientID = value.ArizonaClientID;
						}
						else
						{
							this._ArizonaClientID = default(int?);
						}
						this.SendPropertyChanged("tblDirClient");
					}
					this.SendPropertySetterInvoked("tblDirClient", value);
				}
			}
			
			/// <summary>
			/// Association [PK][One]tblBillClient.BillClientID --- [FK][One]tblBillClientFullText.BillClientID
			/// </summary>
			[AssociationAttribute(Name="FK_tblBillClientFullText_tblBillClient", Storage="_tblBillClientFullText", ThisKey="BillClientID", OtherKey="BillClientID", IsUnique=true, IsForeignKey=false, DeleteRule="NoAction")]
			public tblBillClientFullText tblBillClientFullText
			{
				get
				{
					return this._tblBillClientFullText.Entity;
				}
				set
				{
					tblBillClientFullText previousValue = this._tblBillClientFullText.Entity;
					if ((previousValue != value) || (this._tblBillClientFullText.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._tblBillClientFullText.Entity = null;
							previousValue.tblBillClient = null;
						}
						this._tblBillClientFullText.Entity = value;
						if (value != null)
						{
							value.tblBillClient = this;
						}
						this.SendPropertyChanged("tblBillClientFullText");
					}
					this.SendPropertySetterInvoked("tblBillClientFullText", value);
				}
			}
			
			/// <summary>
			/// Association [PK][One]tblBillClient.BillClientID --- [FK][Many]tblBillDocument.BillClientID
			/// </summary>
			[AssociationAttribute(Name="FK_tblBillDocument_tblBillClient", Storage="_tblBillDocumentList", ThisKey="BillClientID", OtherKey="BillClientID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<tblBillDocument> tblBillDocumentList
			{
				get { return this._tblBillDocumentList; }
				set { this._tblBillDocumentList.Assign(value); }
			}
			
			/// <summary>
			/// Association [PK][One]tblBillClient.BillClientID --- [FK][Many]tblSocialMember.BillClientID
			/// </summary>
			[AssociationAttribute(Name="FK_tblSocialMember_tblBillClient", Storage="_tblSocialMemberList", ThisKey="BillClientID", OtherKey="BillClientID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<tblSocialMember> tblSocialMemberList
			{
				get { return this._tblSocialMemberList; }
				set { this._tblSocialMemberList.Assign(value); }
			}
			
			/// <summary>
			/// Association [PK][One]tblBillClient.BillClientID --- [FK][Many]tblSocialMemberBillClient.BillClientID
			/// </summary>
			[AssociationAttribute(Name="FK_tblSocialMemberBillClient_tblBillClient", Storage="_tblSocialMemberBillClientList", ThisKey="BillClientID", OtherKey="BillClientID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<tblSocialMemberBillClient> tblSocialMemberBillClientList
			{
				get { return this._tblSocialMemberBillClientList; }
				set { this._tblSocialMemberBillClientList.Assign(value); }
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
		#endregion dbo.tblBillClient

		#region dbo.tblBillClientFullText
		[TableAttribute(Name="dbo.tblBillClientFullText")]
		public partial class tblBillClientFullText : EntityBase<tblBillClientFullText, dbArizonaAppDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private long _BillClientID;
			private string _fullTextIndexBasic;
			private EntityRef<tblBillClient> _tblBillClient;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnBillClientIDChanging(long value);
			partial void OnBillClientIDChanged();
			partial void OnfullTextIndexBasicChanging(string value);
			partial void OnfullTextIndexBasicChanged();
			#endregion

			public tblBillClientFullText()
			{
				_tblBillClient = default(EntityRef<tblBillClient>);
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=BigInt NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_BillClientID", DbType="BigInt NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
			public long BillClientID
			{
				get
				{
					return this._BillClientID;
				}
				set
				{
					if (this._BillClientID != value)
					{
						this.OnBillClientIDChanging(value);
						this.SendPropertyChanging();
						this._BillClientID = value;
						this.SendPropertyChanged("BillClientID");
						this.OnBillClientIDChanged();
					}
					this.SendPropertySetterInvoked("BillClientID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(MAX)
			/// </summary>
			[ColumnAttribute(Storage="_fullTextIndexBasic", DbType="NVarChar(MAX)", CanBeNull=true)]
			public string fullTextIndexBasic
			{
				get
				{
					return this._fullTextIndexBasic;
				}
				set
				{
					if (this._fullTextIndexBasic != value)
					{
						this.OnfullTextIndexBasicChanging(value);
						this.SendPropertyChanging();
						this._fullTextIndexBasic = value;
						this.SendPropertyChanged("fullTextIndexBasic");
						this.OnfullTextIndexBasicChanged();
					}
					this.SendPropertySetterInvoked("fullTextIndexBasic", value);
				}
			}
			
			#endregion Columns

			#region Associations
			/// <summary>
			/// Association [FK][One]tblBillClientFullText.BillClientID --- [PK][One]tblBillClient.BillClientID
			/// </summary>
			[AssociationAttribute(Name="FK_tblBillClientFullText_tblBillClient", Storage="_tblBillClient", ThisKey="BillClientID", OtherKey="BillClientID", IsUnique=true, IsForeignKey=true)]
			public tblBillClient tblBillClient
			{
				get
				{
					return this._tblBillClient.Entity;
				}
				set
				{
					tblBillClient previousValue = this._tblBillClient.Entity;
					if ((previousValue != value) || (this._tblBillClient.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._tblBillClient.Entity = null;
							previousValue.tblBillClientFullText = null;
						}
						this._tblBillClient.Entity = value;
						if (value != null)
						{
							value.tblBillClientFullText = this;
							this._BillClientID = value.BillClientID;
						}
						else
						{
							this._BillClientID = default(long);
						}
						this.SendPropertyChanged("tblBillClient");
					}
					this.SendPropertySetterInvoked("tblBillClient", value);
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
		#endregion dbo.tblBillClientFullText

		#region dbo.tblBillDocument
		[TableAttribute(Name="dbo.tblBillDocument")]
		public partial class tblBillDocument : EntityBase<tblBillDocument, dbArizonaAppDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private long _BillDocumentID;
			private long _BillClientID;
			private long? _ParentBillDocumentID;
			private long _BillNaplatniUredjajID;
			private int _RedniBroj;
			private string _PozivNaBroj;
			private DateTime _DatumDokumenta;
			private DateTime _DatumValute;
			private DateTime _DatumDospijeca;
			private int? _BrojDanaZaUplatu;
			private DateTime? _DatumUplate;
			private DateTime? _PoslanKupcuDatum;
			private string _ZKI;
			private string _JIR;
			private int? _VariantID;
			private bool _IsInPdvSustav;
			private long _AppMemberID;
			private bool _IsDeleted;
			private string _Napomena;
			private int? _FiskalTryCount;
			private bool _IsFiskalizacijaRequired;
			private EntityRef<tblAppMember> _tblAppMember;
			private EntityRef<tblBillClient> _tblBillClient;
			private EntityRef<tblBillDocument> _ParentBillDocument;
			private EntitySet<tblBillDocument> _BillDocumentList;
			private EntityRef<tblBillDocumentVariant> _tblBillDocumentVariant;
			private EntityRef<tblBillNaplatniUredjaj> _tblBillNaplatniUredjaj;
			private EntityRef<tblBillDocumentCalculated> _tblBillDocumentCalculated;
			private EntitySet<tblBillDocumentStavka> _tblBillDocumentStavkaList;
			private EntitySet<tblBillDownloadLog> _tblBillDownloadLogList;
			private EntitySet<tblFiskalRacunZahtjevLog> _tblFiskalRacunZahtjevLogList;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnBillDocumentIDChanging(long value);
			partial void OnBillDocumentIDChanged();
			partial void OnBillClientIDChanging(long value);
			partial void OnBillClientIDChanged();
			partial void OnParentBillDocumentIDChanging(long? value);
			partial void OnParentBillDocumentIDChanged();
			partial void OnBillNaplatniUredjajIDChanging(long value);
			partial void OnBillNaplatniUredjajIDChanged();
			partial void OnRedniBrojChanging(int value);
			partial void OnRedniBrojChanged();
			partial void OnPozivNaBrojChanging(string value);
			partial void OnPozivNaBrojChanged();
			partial void OnDatumDokumentaChanging(DateTime value);
			partial void OnDatumDokumentaChanged();
			partial void OnDatumValuteChanging(DateTime value);
			partial void OnDatumValuteChanged();
			partial void OnDatumDospijecaChanging(DateTime value);
			partial void OnDatumDospijecaChanged();
			partial void OnBrojDanaZaUplatuChanging(int? value);
			partial void OnBrojDanaZaUplatuChanged();
			partial void OnDatumUplateChanging(DateTime? value);
			partial void OnDatumUplateChanged();
			partial void OnPoslanKupcuDatumChanging(DateTime? value);
			partial void OnPoslanKupcuDatumChanged();
			partial void OnZKIChanging(string value);
			partial void OnZKIChanged();
			partial void OnJIRChanging(string value);
			partial void OnJIRChanged();
			partial void OnVariantIDChanging(int? value);
			partial void OnVariantIDChanged();
			partial void OnIsInPdvSustavChanging(bool value);
			partial void OnIsInPdvSustavChanged();
			partial void OnAppMemberIDChanging(long value);
			partial void OnAppMemberIDChanged();
			partial void OnIsDeletedChanging(bool value);
			partial void OnIsDeletedChanged();
			partial void OnNapomenaChanging(string value);
			partial void OnNapomenaChanged();
			partial void OnFiskalTryCountChanging(int? value);
			partial void OnFiskalTryCountChanged();
			partial void OnIsFiskalizacijaRequiredChanging(bool value);
			partial void OnIsFiskalizacijaRequiredChanged();
			#endregion

			public tblBillDocument()
			{
				_tblAppMember = default(EntityRef<tblAppMember>);
				_tblBillClient = default(EntityRef<tblBillClient>);
				_ParentBillDocument = default(EntityRef<tblBillDocument>);
				_BillDocumentList = new EntitySet<tblBillDocument>(
					new Action<tblBillDocument>(item=>{this.SendPropertyChanging(); item.ParentBillDocument=this;}), 
					new Action<tblBillDocument>(item=>{this.SendPropertyChanging(); item.ParentBillDocument=null;}));
				_tblBillDocumentVariant = default(EntityRef<tblBillDocumentVariant>);
				_tblBillNaplatniUredjaj = default(EntityRef<tblBillNaplatniUredjaj>);
				_tblBillDocumentCalculated = default(EntityRef<tblBillDocumentCalculated>);
				_tblBillDocumentStavkaList = new EntitySet<tblBillDocumentStavka>(
					new Action<tblBillDocumentStavka>(item=>{this.SendPropertyChanging(); item.tblBillDocument=this;}), 
					new Action<tblBillDocumentStavka>(item=>{this.SendPropertyChanging(); item.tblBillDocument=null;}));
				_tblBillDownloadLogList = new EntitySet<tblBillDownloadLog>(
					new Action<tblBillDownloadLog>(item=>{this.SendPropertyChanging(); item.tblBillDocument=this;}), 
					new Action<tblBillDownloadLog>(item=>{this.SendPropertyChanging(); item.tblBillDocument=null;}));
				_tblFiskalRacunZahtjevLogList = new EntitySet<tblFiskalRacunZahtjevLog>(
					new Action<tblFiskalRacunZahtjevLog>(item=>{this.SendPropertyChanging(); item.tblBillDocument=this;}), 
					new Action<tblFiskalRacunZahtjevLog>(item=>{this.SendPropertyChanging(); item.tblBillDocument=null;}));
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=BigInt NOT NULL IDENTITY
			/// </summary>
			[ColumnAttribute(Storage="_BillDocumentID", AutoSync=AutoSync.OnInsert, DbType="BigInt NOT NULL IDENTITY", CanBeNull=false, IsPrimaryKey=true, IsDbGenerated=true)]
			public long BillDocumentID
			{
				get
				{
					return this._BillDocumentID;
				}
				set
				{
					if (this._BillDocumentID != value)
					{
						this.OnBillDocumentIDChanging(value);
						this.SendPropertyChanging();
						this._BillDocumentID = value;
						this.SendPropertyChanged("BillDocumentID");
						this.OnBillDocumentIDChanged();
					}
					this.SendPropertySetterInvoked("BillDocumentID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=BigInt NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_BillClientID", DbType="BigInt NOT NULL", CanBeNull=false)]
			public long BillClientID
			{
				get
				{
					return this._BillClientID;
				}
				set
				{
					if (this._BillClientID != value)
					{
						this.OnBillClientIDChanging(value);
						this.SendPropertyChanging();
						this._BillClientID = value;
						this.SendPropertyChanged("BillClientID");
						this.OnBillClientIDChanged();
					}
					this.SendPropertySetterInvoked("BillClientID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=BigInt
			/// </summary>
			[ColumnAttribute(Storage="_ParentBillDocumentID", DbType="BigInt", CanBeNull=true)]
			public long? ParentBillDocumentID
			{
				get
				{
					return this._ParentBillDocumentID;
				}
				set
				{
					if (this._ParentBillDocumentID != value)
					{
						this.OnParentBillDocumentIDChanging(value);
						this.SendPropertyChanging();
						this._ParentBillDocumentID = value;
						this.SendPropertyChanged("ParentBillDocumentID");
						this.OnParentBillDocumentIDChanged();
					}
					this.SendPropertySetterInvoked("ParentBillDocumentID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=BigInt NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_BillNaplatniUredjajID", DbType="BigInt NOT NULL", CanBeNull=false)]
			public long BillNaplatniUredjajID
			{
				get
				{
					return this._BillNaplatniUredjajID;
				}
				set
				{
					if (this._BillNaplatniUredjajID != value)
					{
						this.OnBillNaplatniUredjajIDChanging(value);
						this.SendPropertyChanging();
						this._BillNaplatniUredjajID = value;
						this.SendPropertyChanged("BillNaplatniUredjajID");
						this.OnBillNaplatniUredjajIDChanged();
					}
					this.SendPropertySetterInvoked("BillNaplatniUredjajID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_RedniBroj", DbType="Int NOT NULL", CanBeNull=false)]
			public int RedniBroj
			{
				get
				{
					return this._RedniBroj;
				}
				set
				{
					if (this._RedniBroj != value)
					{
						this.OnRedniBrojChanging(value);
						this.SendPropertyChanging();
						this._RedniBroj = value;
						this.SendPropertyChanged("RedniBroj");
						this.OnRedniBrojChanged();
					}
					this.SendPropertySetterInvoked("RedniBroj", value);
				}
			}
			
			/// <summary>
			/// Column DbType=VarChar(50) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_PozivNaBroj", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
			public string PozivNaBroj
			{
				get
				{
					return this._PozivNaBroj;
				}
				set
				{
					if (this._PozivNaBroj != value)
					{
						this.OnPozivNaBrojChanging(value);
						this.SendPropertyChanging();
						this._PozivNaBroj = value;
						this.SendPropertyChanged("PozivNaBroj");
						this.OnPozivNaBrojChanged();
					}
					this.SendPropertySetterInvoked("PozivNaBroj", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_DatumDokumenta", DbType="DateTime NOT NULL", CanBeNull=false)]
			public DateTime DatumDokumenta
			{
				get
				{
					return this._DatumDokumenta;
				}
				set
				{
					if (this._DatumDokumenta != value)
					{
						this.OnDatumDokumentaChanging(value);
						this.SendPropertyChanging();
						this._DatumDokumenta = value;
						this.SendPropertyChanged("DatumDokumenta");
						this.OnDatumDokumentaChanged();
					}
					this.SendPropertySetterInvoked("DatumDokumenta", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_DatumValute", DbType="DateTime NOT NULL", CanBeNull=false)]
			public DateTime DatumValute
			{
				get
				{
					return this._DatumValute;
				}
				set
				{
					if (this._DatumValute != value)
					{
						this.OnDatumValuteChanging(value);
						this.SendPropertyChanging();
						this._DatumValute = value;
						this.SendPropertyChanged("DatumValute");
						this.OnDatumValuteChanged();
					}
					this.SendPropertySetterInvoked("DatumValute", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_DatumDospijeca", DbType="DateTime NOT NULL", CanBeNull=false)]
			public DateTime DatumDospijeca
			{
				get
				{
					return this._DatumDospijeca;
				}
				set
				{
					if (this._DatumDospijeca != value)
					{
						this.OnDatumDospijecaChanging(value);
						this.SendPropertyChanging();
						this._DatumDospijeca = value;
						this.SendPropertyChanged("DatumDospijeca");
						this.OnDatumDospijecaChanged();
					}
					this.SendPropertySetterInvoked("DatumDospijeca", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int
			/// </summary>
			[ColumnAttribute(Storage="_BrojDanaZaUplatu", DbType="Int", CanBeNull=true)]
			public int? BrojDanaZaUplatu
			{
				get
				{
					return this._BrojDanaZaUplatu;
				}
				set
				{
					if (this._BrojDanaZaUplatu != value)
					{
						this.OnBrojDanaZaUplatuChanging(value);
						this.SendPropertyChanging();
						this._BrojDanaZaUplatu = value;
						this.SendPropertyChanged("BrojDanaZaUplatu");
						this.OnBrojDanaZaUplatuChanged();
					}
					this.SendPropertySetterInvoked("BrojDanaZaUplatu", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime
			/// </summary>
			[ColumnAttribute(Storage="_DatumUplate", DbType="DateTime", CanBeNull=true)]
			public DateTime? DatumUplate
			{
				get
				{
					return this._DatumUplate;
				}
				set
				{
					if (this._DatumUplate != value)
					{
						this.OnDatumUplateChanging(value);
						this.SendPropertyChanging();
						this._DatumUplate = value;
						this.SendPropertyChanged("DatumUplate");
						this.OnDatumUplateChanged();
					}
					this.SendPropertySetterInvoked("DatumUplate", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime
			/// </summary>
			[ColumnAttribute(Storage="_PoslanKupcuDatum", DbType="DateTime", CanBeNull=true)]
			public DateTime? PoslanKupcuDatum
			{
				get
				{
					return this._PoslanKupcuDatum;
				}
				set
				{
					if (this._PoslanKupcuDatum != value)
					{
						this.OnPoslanKupcuDatumChanging(value);
						this.SendPropertyChanging();
						this._PoslanKupcuDatum = value;
						this.SendPropertyChanged("PoslanKupcuDatum");
						this.OnPoslanKupcuDatumChanged();
					}
					this.SendPropertySetterInvoked("PoslanKupcuDatum", value);
				}
			}
			
			/// <summary>
			/// Column DbType=VarChar(100)
			/// </summary>
			[ColumnAttribute(Storage="_ZKI", DbType="VarChar(100)", CanBeNull=true)]
			public string ZKI
			{
				get
				{
					return this._ZKI;
				}
				set
				{
					if (this._ZKI != value)
					{
						this.OnZKIChanging(value);
						this.SendPropertyChanging();
						this._ZKI = value;
						this.SendPropertyChanged("ZKI");
						this.OnZKIChanged();
					}
					this.SendPropertySetterInvoked("ZKI", value);
				}
			}
			
			/// <summary>
			/// Column DbType=VarChar(100)
			/// </summary>
			[ColumnAttribute(Storage="_JIR", DbType="VarChar(100)", CanBeNull=true)]
			public string JIR
			{
				get
				{
					return this._JIR;
				}
				set
				{
					if (this._JIR != value)
					{
						this.OnJIRChanging(value);
						this.SendPropertyChanging();
						this._JIR = value;
						this.SendPropertyChanged("JIR");
						this.OnJIRChanged();
					}
					this.SendPropertySetterInvoked("JIR", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int
			/// </summary>
			[ColumnAttribute(Storage="_VariantID", DbType="Int", CanBeNull=true)]
			public int? VariantID
			{
				get
				{
					return this._VariantID;
				}
				set
				{
					if (this._VariantID != value)
					{
						this.OnVariantIDChanging(value);
						this.SendPropertyChanging();
						this._VariantID = value;
						this.SendPropertyChanged("VariantID");
						this.OnVariantIDChanged();
					}
					this.SendPropertySetterInvoked("VariantID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Bit NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_IsInPdvSustav", DbType="Bit NOT NULL", CanBeNull=false)]
			public bool IsInPdvSustav
			{
				get
				{
					return this._IsInPdvSustav;
				}
				set
				{
					if (this._IsInPdvSustav != value)
					{
						this.OnIsInPdvSustavChanging(value);
						this.SendPropertyChanging();
						this._IsInPdvSustav = value;
						this.SendPropertyChanged("IsInPdvSustav");
						this.OnIsInPdvSustavChanged();
					}
					this.SendPropertySetterInvoked("IsInPdvSustav", value);
				}
			}
			
			/// <summary>
			/// Column DbType=BigInt NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_AppMemberID", DbType="BigInt NOT NULL", CanBeNull=false)]
			public long AppMemberID
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
			/// Column DbType=Bit NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_IsDeleted", DbType="Bit NOT NULL", CanBeNull=false)]
			public bool IsDeleted
			{
				get
				{
					return this._IsDeleted;
				}
				set
				{
					if (this._IsDeleted != value)
					{
						this.OnIsDeletedChanging(value);
						this.SendPropertyChanging();
						this._IsDeleted = value;
						this.SendPropertyChanged("IsDeleted");
						this.OnIsDeletedChanged();
					}
					this.SendPropertySetterInvoked("IsDeleted", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(500)
			/// </summary>
			[ColumnAttribute(Storage="_Napomena", DbType="NVarChar(500)", CanBeNull=true)]
			public string Napomena
			{
				get
				{
					return this._Napomena;
				}
				set
				{
					if (this._Napomena != value)
					{
						this.OnNapomenaChanging(value);
						this.SendPropertyChanging();
						this._Napomena = value;
						this.SendPropertyChanged("Napomena");
						this.OnNapomenaChanged();
					}
					this.SendPropertySetterInvoked("Napomena", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int
			/// </summary>
			[ColumnAttribute(Storage="_FiskalTryCount", DbType="Int", CanBeNull=true)]
			public int? FiskalTryCount
			{
				get
				{
					return this._FiskalTryCount;
				}
				set
				{
					if (this._FiskalTryCount != value)
					{
						this.OnFiskalTryCountChanging(value);
						this.SendPropertyChanging();
						this._FiskalTryCount = value;
						this.SendPropertyChanged("FiskalTryCount");
						this.OnFiskalTryCountChanged();
					}
					this.SendPropertySetterInvoked("FiskalTryCount", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Bit NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_IsFiskalizacijaRequired", DbType="Bit NOT NULL", CanBeNull=false)]
			public bool IsFiskalizacijaRequired
			{
				get
				{
					return this._IsFiskalizacijaRequired;
				}
				set
				{
					if (this._IsFiskalizacijaRequired != value)
					{
						this.OnIsFiskalizacijaRequiredChanging(value);
						this.SendPropertyChanging();
						this._IsFiskalizacijaRequired = value;
						this.SendPropertyChanged("IsFiskalizacijaRequired");
						this.OnIsFiskalizacijaRequiredChanged();
					}
					this.SendPropertySetterInvoked("IsFiskalizacijaRequired", value);
				}
			}
			
			#endregion Columns

			#region Associations
			/// <summary>
			/// Association [FK][Many]tblBillDocument.AppMemberID --- [PK][One]tblAppMember.AppMemberID
			/// </summary>
			[AssociationAttribute(Name="FK_tblBillDocument_tblAppMember", Storage="_tblAppMember", ThisKey="AppMemberID", OtherKey="AppMemberID", IsUnique=false, IsForeignKey=true)]
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
							previousValue.tblBillDocumentList.Remove(this);
						}
						this._tblAppMember.Entity = value;
						if (value != null)
						{
							value.tblBillDocumentList.Add(this);
							this._AppMemberID = value.AppMemberID;
						}
						else
						{
							this._AppMemberID = default(long);
						}
						this.SendPropertyChanged("tblAppMember");
					}
					this.SendPropertySetterInvoked("tblAppMember", value);
				}
			}
			
			/// <summary>
			/// Association [FK][Many]tblBillDocument.BillClientID --- [PK][One]tblBillClient.BillClientID
			/// </summary>
			[AssociationAttribute(Name="FK_tblBillDocument_tblBillClient", Storage="_tblBillClient", ThisKey="BillClientID", OtherKey="BillClientID", IsUnique=false, IsForeignKey=true)]
			public tblBillClient tblBillClient
			{
				get
				{
					return this._tblBillClient.Entity;
				}
				set
				{
					tblBillClient previousValue = this._tblBillClient.Entity;
					if ((previousValue != value) || (this._tblBillClient.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._tblBillClient.Entity = null;
							previousValue.tblBillDocumentList.Remove(this);
						}
						this._tblBillClient.Entity = value;
						if (value != null)
						{
							value.tblBillDocumentList.Add(this);
							this._BillClientID = value.BillClientID;
						}
						else
						{
							this._BillClientID = default(long);
						}
						this.SendPropertyChanged("tblBillClient");
					}
					this.SendPropertySetterInvoked("tblBillClient", value);
				}
			}
			
			/// <summary>
			/// Association [FK][Many]tblBillDocument.ParentBillDocumentID --- [PK][One]tblBillDocument.BillDocumentID
			/// </summary>
			[AssociationAttribute(Name="FK_tblBillDocument_tblBillDocument", Storage="_ParentBillDocument", ThisKey="ParentBillDocumentID", OtherKey="BillDocumentID", IsUnique=false, IsForeignKey=true)]
			public tblBillDocument ParentBillDocument
			{
				get
				{
					return this._ParentBillDocument.Entity;
				}
				set
				{
					tblBillDocument previousValue = this._ParentBillDocument.Entity;
					if ((previousValue != value) || (this._ParentBillDocument.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._ParentBillDocument.Entity = null;
							previousValue.BillDocumentList.Remove(this);
						}
						this._ParentBillDocument.Entity = value;
						if (value != null)
						{
							value.BillDocumentList.Add(this);
							this._ParentBillDocumentID = value.BillDocumentID;
						}
						else
						{
							this._ParentBillDocumentID = default(long?);
						}
						this.SendPropertyChanged("ParentBillDocument");
					}
					this.SendPropertySetterInvoked("ParentBillDocument", value);
				}
			}
			
			/// <summary>
			/// Association [PK][One]tblBillDocument.BillDocumentID --- [FK][Many]tblBillDocument.ParentBillDocumentID
			/// </summary>
			[AssociationAttribute(Name="FK_tblBillDocument_tblBillDocument", Storage="_BillDocumentList", ThisKey="BillDocumentID", OtherKey="ParentBillDocumentID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<tblBillDocument> BillDocumentList
			{
				get { return this._BillDocumentList; }
				set { this._BillDocumentList.Assign(value); }
			}
			
			/// <summary>
			/// Association [FK][Many]tblBillDocument.VariantID --- [PK][One]tblBillDocumentVariant.VariantID
			/// </summary>
			[AssociationAttribute(Name="FK_tblBillDocument_tblBillDocumentVariant", Storage="_tblBillDocumentVariant", ThisKey="VariantID", OtherKey="VariantID", IsUnique=false, IsForeignKey=true)]
			public tblBillDocumentVariant tblBillDocumentVariant
			{
				get
				{
					return this._tblBillDocumentVariant.Entity;
				}
				set
				{
					tblBillDocumentVariant previousValue = this._tblBillDocumentVariant.Entity;
					if ((previousValue != value) || (this._tblBillDocumentVariant.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._tblBillDocumentVariant.Entity = null;
							previousValue.tblBillDocumentList.Remove(this);
						}
						this._tblBillDocumentVariant.Entity = value;
						if (value != null)
						{
							value.tblBillDocumentList.Add(this);
							this._VariantID = value.VariantID;
						}
						else
						{
							this._VariantID = default(int?);
						}
						this.SendPropertyChanged("tblBillDocumentVariant");
					}
					this.SendPropertySetterInvoked("tblBillDocumentVariant", value);
				}
			}
			
			/// <summary>
			/// Association [FK][Many]tblBillDocument.BillNaplatniUredjajID --- [PK][One]tblBillNaplatniUredjaj.BillNaplatniUredjajID
			/// </summary>
			[AssociationAttribute(Name="FK_tblBillDocument_tblBillNaplatniUredjaj", Storage="_tblBillNaplatniUredjaj", ThisKey="BillNaplatniUredjajID", OtherKey="BillNaplatniUredjajID", IsUnique=false, IsForeignKey=true)]
			public tblBillNaplatniUredjaj tblBillNaplatniUredjaj
			{
				get
				{
					return this._tblBillNaplatniUredjaj.Entity;
				}
				set
				{
					tblBillNaplatniUredjaj previousValue = this._tblBillNaplatniUredjaj.Entity;
					if ((previousValue != value) || (this._tblBillNaplatniUredjaj.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._tblBillNaplatniUredjaj.Entity = null;
							previousValue.tblBillDocumentList.Remove(this);
						}
						this._tblBillNaplatniUredjaj.Entity = value;
						if (value != null)
						{
							value.tblBillDocumentList.Add(this);
							this._BillNaplatniUredjajID = value.BillNaplatniUredjajID;
						}
						else
						{
							this._BillNaplatniUredjajID = default(long);
						}
						this.SendPropertyChanged("tblBillNaplatniUredjaj");
					}
					this.SendPropertySetterInvoked("tblBillNaplatniUredjaj", value);
				}
			}
			
			/// <summary>
			/// Association [PK][One]tblBillDocument.BillDocumentID --- [FK][One]tblBillDocumentCalculated.BillDocumentID
			/// </summary>
			[AssociationAttribute(Name="FK_tblBillDocumentCalculated_tblBillDocument", Storage="_tblBillDocumentCalculated", ThisKey="BillDocumentID", OtherKey="BillDocumentID", IsUnique=true, IsForeignKey=false, DeleteRule="Cascade")]
			public tblBillDocumentCalculated tblBillDocumentCalculated
			{
				get
				{
					return this._tblBillDocumentCalculated.Entity;
				}
				set
				{
					tblBillDocumentCalculated previousValue = this._tblBillDocumentCalculated.Entity;
					if ((previousValue != value) || (this._tblBillDocumentCalculated.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._tblBillDocumentCalculated.Entity = null;
							previousValue.tblBillDocument = null;
						}
						this._tblBillDocumentCalculated.Entity = value;
						if (value != null)
						{
							value.tblBillDocument = this;
						}
						this.SendPropertyChanged("tblBillDocumentCalculated");
					}
					this.SendPropertySetterInvoked("tblBillDocumentCalculated", value);
				}
			}
			
			/// <summary>
			/// Association [PK][One]tblBillDocument.BillDocumentID --- [FK][Many]tblBillDocumentStavka.BillDocumentID
			/// </summary>
			[AssociationAttribute(Name="FK_tblBillDocumentStavka_tblBillDocument", Storage="_tblBillDocumentStavkaList", ThisKey="BillDocumentID", OtherKey="BillDocumentID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<tblBillDocumentStavka> tblBillDocumentStavkaList
			{
				get { return this._tblBillDocumentStavkaList; }
				set { this._tblBillDocumentStavkaList.Assign(value); }
			}
			
			/// <summary>
			/// Association [PK][One]tblBillDocument.BillDocumentID --- [FK][Many]tblBillDownloadLog.BillDocumentID
			/// </summary>
			[AssociationAttribute(Name="FK_tblBillDownloadLog_tblBillDocument", Storage="_tblBillDownloadLogList", ThisKey="BillDocumentID", OtherKey="BillDocumentID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<tblBillDownloadLog> tblBillDownloadLogList
			{
				get { return this._tblBillDownloadLogList; }
				set { this._tblBillDownloadLogList.Assign(value); }
			}
			
			/// <summary>
			/// Association [PK][One]tblBillDocument.BillDocumentID --- [FK][Many]tblFiskalRacunZahtjevLog.BillDocumentID
			/// </summary>
			[AssociationAttribute(Name="FK_tblFiskalRacunZahtjevLog_tblBillDocument", Storage="_tblFiskalRacunZahtjevLogList", ThisKey="BillDocumentID", OtherKey="BillDocumentID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<tblFiskalRacunZahtjevLog> tblFiskalRacunZahtjevLogList
			{
				get { return this._tblFiskalRacunZahtjevLogList; }
				set { this._tblFiskalRacunZahtjevLogList.Assign(value); }
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
		#endregion dbo.tblBillDocument

		#region dbo.tblBillDocumentCalculated
		[TableAttribute(Name="dbo.tblBillDocumentCalculated")]
		public partial class tblBillDocumentCalculated : EntityBase<tblBillDocumentCalculated, dbArizonaAppDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private long _BillDocumentID;
			private decimal _SumPoreznaOsnovica;
			private decimal _SumIznosPdva;
			private decimal _SumIznosPorezPotrosnja;
			private decimal _SumIznosOstaliPorez;
			private decimal _SumUkupno;
			private EntityRef<tblBillDocument> _tblBillDocument;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnBillDocumentIDChanging(long value);
			partial void OnBillDocumentIDChanged();
			partial void OnSumPoreznaOsnovicaChanging(decimal value);
			partial void OnSumPoreznaOsnovicaChanged();
			partial void OnSumIznosPdvaChanging(decimal value);
			partial void OnSumIznosPdvaChanged();
			partial void OnSumIznosPorezPotrosnjaChanging(decimal value);
			partial void OnSumIznosPorezPotrosnjaChanged();
			partial void OnSumIznosOstaliPorezChanging(decimal value);
			partial void OnSumIznosOstaliPorezChanged();
			partial void OnSumUkupnoChanging(decimal value);
			partial void OnSumUkupnoChanged();
			#endregion

			public tblBillDocumentCalculated()
			{
				_tblBillDocument = default(EntityRef<tblBillDocument>);
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=BigInt NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_BillDocumentID", DbType="BigInt NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
			public long BillDocumentID
			{
				get
				{
					return this._BillDocumentID;
				}
				set
				{
					if (this._BillDocumentID != value)
					{
						this.OnBillDocumentIDChanging(value);
						this.SendPropertyChanging();
						this._BillDocumentID = value;
						this.SendPropertyChanged("BillDocumentID");
						this.OnBillDocumentIDChanged();
					}
					this.SendPropertySetterInvoked("BillDocumentID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Decimal(18,8) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_SumPoreznaOsnovica", DbType="Decimal(18,8) NOT NULL", CanBeNull=false)]
			public decimal SumPoreznaOsnovica
			{
				get
				{
					return this._SumPoreznaOsnovica;
				}
				set
				{
					if (this._SumPoreznaOsnovica != value)
					{
						this.OnSumPoreznaOsnovicaChanging(value);
						this.SendPropertyChanging();
						this._SumPoreznaOsnovica = value;
						this.SendPropertyChanged("SumPoreznaOsnovica");
						this.OnSumPoreznaOsnovicaChanged();
					}
					this.SendPropertySetterInvoked("SumPoreznaOsnovica", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Decimal(18,8) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_SumIznosPdva", DbType="Decimal(18,8) NOT NULL", CanBeNull=false)]
			public decimal SumIznosPdva
			{
				get
				{
					return this._SumIznosPdva;
				}
				set
				{
					if (this._SumIznosPdva != value)
					{
						this.OnSumIznosPdvaChanging(value);
						this.SendPropertyChanging();
						this._SumIznosPdva = value;
						this.SendPropertyChanged("SumIznosPdva");
						this.OnSumIznosPdvaChanged();
					}
					this.SendPropertySetterInvoked("SumIznosPdva", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Decimal(18,8) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_SumIznosPorezPotrosnja", DbType="Decimal(18,8) NOT NULL", CanBeNull=false)]
			public decimal SumIznosPorezPotrosnja
			{
				get
				{
					return this._SumIznosPorezPotrosnja;
				}
				set
				{
					if (this._SumIznosPorezPotrosnja != value)
					{
						this.OnSumIznosPorezPotrosnjaChanging(value);
						this.SendPropertyChanging();
						this._SumIznosPorezPotrosnja = value;
						this.SendPropertyChanged("SumIznosPorezPotrosnja");
						this.OnSumIznosPorezPotrosnjaChanged();
					}
					this.SendPropertySetterInvoked("SumIznosPorezPotrosnja", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Decimal(18,8) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_SumIznosOstaliPorez", DbType="Decimal(18,8) NOT NULL", CanBeNull=false)]
			public decimal SumIznosOstaliPorez
			{
				get
				{
					return this._SumIznosOstaliPorez;
				}
				set
				{
					if (this._SumIznosOstaliPorez != value)
					{
						this.OnSumIznosOstaliPorezChanging(value);
						this.SendPropertyChanging();
						this._SumIznosOstaliPorez = value;
						this.SendPropertyChanged("SumIznosOstaliPorez");
						this.OnSumIznosOstaliPorezChanged();
					}
					this.SendPropertySetterInvoked("SumIznosOstaliPorez", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Decimal(18,8) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_SumUkupno", DbType="Decimal(18,8) NOT NULL", CanBeNull=false)]
			public decimal SumUkupno
			{
				get
				{
					return this._SumUkupno;
				}
				set
				{
					if (this._SumUkupno != value)
					{
						this.OnSumUkupnoChanging(value);
						this.SendPropertyChanging();
						this._SumUkupno = value;
						this.SendPropertyChanged("SumUkupno");
						this.OnSumUkupnoChanged();
					}
					this.SendPropertySetterInvoked("SumUkupno", value);
				}
			}
			
			#endregion Columns

			#region Associations
			/// <summary>
			/// Association [FK][One]tblBillDocumentCalculated.BillDocumentID --- [PK][One]tblBillDocument.BillDocumentID
			/// </summary>
			[AssociationAttribute(Name="FK_tblBillDocumentCalculated_tblBillDocument", Storage="_tblBillDocument", ThisKey="BillDocumentID", OtherKey="BillDocumentID", IsUnique=true, IsForeignKey=true, DeleteOnNull=true)]
			public tblBillDocument tblBillDocument
			{
				get
				{
					return this._tblBillDocument.Entity;
				}
				set
				{
					tblBillDocument previousValue = this._tblBillDocument.Entity;
					if ((previousValue != value) || (this._tblBillDocument.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._tblBillDocument.Entity = null;
							previousValue.tblBillDocumentCalculated = null;
						}
						this._tblBillDocument.Entity = value;
						if (value != null)
						{
							value.tblBillDocumentCalculated = this;
							this._BillDocumentID = value.BillDocumentID;
						}
						else
						{
							this._BillDocumentID = default(long);
						}
						this.SendPropertyChanged("tblBillDocument");
					}
					this.SendPropertySetterInvoked("tblBillDocument", value);
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
		#endregion dbo.tblBillDocumentCalculated

		#region dbo.tblBillDocumentRedniBroj
		[TableAttribute(Name="dbo.tblBillDocumentRedniBroj")]
		public partial class tblBillDocumentRedniBroj : EntityBase<tblBillDocumentRedniBroj, dbArizonaAppDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private long _BillNaplatniUredjajID;
			private System.Int16 _GodinaDokumenta;
			private int _MaxRedniBroj;
			private DateTime _MaxDatumDokumenta;
			private EntityRef<tblBillNaplatniUredjaj> _tblBillNaplatniUredjaj;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnBillNaplatniUredjajIDChanging(long value);
			partial void OnBillNaplatniUredjajIDChanged();
			partial void OnGodinaDokumentaChanging(System.Int16 value);
			partial void OnGodinaDokumentaChanged();
			partial void OnMaxRedniBrojChanging(int value);
			partial void OnMaxRedniBrojChanged();
			partial void OnMaxDatumDokumentaChanging(DateTime value);
			partial void OnMaxDatumDokumentaChanged();
			#endregion

			public tblBillDocumentRedniBroj()
			{
				_tblBillNaplatniUredjaj = default(EntityRef<tblBillNaplatniUredjaj>);
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=BigInt NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_BillNaplatniUredjajID", DbType="BigInt NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
			public long BillNaplatniUredjajID
			{
				get
				{
					return this._BillNaplatniUredjajID;
				}
				set
				{
					if (this._BillNaplatniUredjajID != value)
					{
						this.OnBillNaplatniUredjajIDChanging(value);
						this.SendPropertyChanging();
						this._BillNaplatniUredjajID = value;
						this.SendPropertyChanged("BillNaplatniUredjajID");
						this.OnBillNaplatniUredjajIDChanged();
					}
					this.SendPropertySetterInvoked("BillNaplatniUredjajID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=SmallInt NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_GodinaDokumenta", DbType="SmallInt NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
			public System.Int16 GodinaDokumenta
			{
				get
				{
					return this._GodinaDokumenta;
				}
				set
				{
					if (this._GodinaDokumenta != value)
					{
						this.OnGodinaDokumentaChanging(value);
						this.SendPropertyChanging();
						this._GodinaDokumenta = value;
						this.SendPropertyChanged("GodinaDokumenta");
						this.OnGodinaDokumentaChanged();
					}
					this.SendPropertySetterInvoked("GodinaDokumenta", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_MaxRedniBroj", DbType="Int NOT NULL", CanBeNull=false)]
			public int MaxRedniBroj
			{
				get
				{
					return this._MaxRedniBroj;
				}
				set
				{
					if (this._MaxRedniBroj != value)
					{
						this.OnMaxRedniBrojChanging(value);
						this.SendPropertyChanging();
						this._MaxRedniBroj = value;
						this.SendPropertyChanged("MaxRedniBroj");
						this.OnMaxRedniBrojChanged();
					}
					this.SendPropertySetterInvoked("MaxRedniBroj", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_MaxDatumDokumenta", DbType="DateTime NOT NULL", CanBeNull=false)]
			public DateTime MaxDatumDokumenta
			{
				get
				{
					return this._MaxDatumDokumenta;
				}
				set
				{
					if (this._MaxDatumDokumenta != value)
					{
						this.OnMaxDatumDokumentaChanging(value);
						this.SendPropertyChanging();
						this._MaxDatumDokumenta = value;
						this.SendPropertyChanged("MaxDatumDokumenta");
						this.OnMaxDatumDokumentaChanged();
					}
					this.SendPropertySetterInvoked("MaxDatumDokumenta", value);
				}
			}
			
			#endregion Columns

			#region Associations
			/// <summary>
			/// Association [FK][Many]tblBillDocumentRedniBroj.BillNaplatniUredjajID --- [PK][One]tblBillNaplatniUredjaj.BillNaplatniUredjajID
			/// </summary>
			[AssociationAttribute(Name="FK_tblBillDocumentRedniBroj_tblBillNaplatniUredjaj", Storage="_tblBillNaplatniUredjaj", ThisKey="BillNaplatniUredjajID", OtherKey="BillNaplatniUredjajID", IsUnique=false, IsForeignKey=true)]
			public tblBillNaplatniUredjaj tblBillNaplatniUredjaj
			{
				get
				{
					return this._tblBillNaplatniUredjaj.Entity;
				}
				set
				{
					tblBillNaplatniUredjaj previousValue = this._tblBillNaplatniUredjaj.Entity;
					if ((previousValue != value) || (this._tblBillNaplatniUredjaj.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._tblBillNaplatniUredjaj.Entity = null;
							previousValue.tblBillDocumentRedniBrojList.Remove(this);
						}
						this._tblBillNaplatniUredjaj.Entity = value;
						if (value != null)
						{
							value.tblBillDocumentRedniBrojList.Add(this);
							this._BillNaplatniUredjajID = value.BillNaplatniUredjajID;
						}
						else
						{
							this._BillNaplatniUredjajID = default(long);
						}
						this.SendPropertyChanged("tblBillNaplatniUredjaj");
					}
					this.SendPropertySetterInvoked("tblBillNaplatniUredjaj", value);
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
		#endregion dbo.tblBillDocumentRedniBroj

		#region dbo.tblBillDocumentStavka
		[TableAttribute(Name="dbo.tblBillDocumentStavka")]
		public partial class tblBillDocumentStavka : EntityBase<tblBillDocumentStavka, dbArizonaAppDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private long _BillDocumentStavkaID;
			private long _BillDocumentID;
			private long _BillProductID;
			private string _ProductNaziv;
			private decimal _JedinicnaCijena;
			private bool _CijenaJeMPC;
			private int _BillMjeraID;
			private decimal _Kolicina;
			private decimal _PopustPosto;
			private long _BillPoreznaGrupaID;
			private string _PoreznaGrupaNaziv;
			private bool _IsInPdvSustav;
			private decimal _PdvPosto;
			private decimal _PorezPotrosnjaPosto;
			private string _OstaliPorezNaziv;
			private decimal _OstaliPorezPosto;
			private string _NaknadaNaziv;
			private decimal _IznosNaknade;
			private EntityRef<tblBillDocument> _tblBillDocument;
			private EntityRef<tblBillMjera> _tblBillMjera;
			private EntityRef<tblBillPoreznaGrupa> _tblBillPoreznaGrupa;
			private EntityRef<tblBillProduct> _tblBillProduct;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnBillDocumentStavkaIDChanging(long value);
			partial void OnBillDocumentStavkaIDChanged();
			partial void OnBillDocumentIDChanging(long value);
			partial void OnBillDocumentIDChanged();
			partial void OnBillProductIDChanging(long value);
			partial void OnBillProductIDChanged();
			partial void OnProductNazivChanging(string value);
			partial void OnProductNazivChanged();
			partial void OnJedinicnaCijenaChanging(decimal value);
			partial void OnJedinicnaCijenaChanged();
			partial void OnCijenaJeMPCChanging(bool value);
			partial void OnCijenaJeMPCChanged();
			partial void OnBillMjeraIDChanging(int value);
			partial void OnBillMjeraIDChanged();
			partial void OnKolicinaChanging(decimal value);
			partial void OnKolicinaChanged();
			partial void OnPopustPostoChanging(decimal value);
			partial void OnPopustPostoChanged();
			partial void OnBillPoreznaGrupaIDChanging(long value);
			partial void OnBillPoreznaGrupaIDChanged();
			partial void OnPoreznaGrupaNazivChanging(string value);
			partial void OnPoreznaGrupaNazivChanged();
			partial void OnIsInPdvSustavChanging(bool value);
			partial void OnIsInPdvSustavChanged();
			partial void OnPdvPostoChanging(decimal value);
			partial void OnPdvPostoChanged();
			partial void OnPorezPotrosnjaPostoChanging(decimal value);
			partial void OnPorezPotrosnjaPostoChanged();
			partial void OnOstaliPorezNazivChanging(string value);
			partial void OnOstaliPorezNazivChanged();
			partial void OnOstaliPorezPostoChanging(decimal value);
			partial void OnOstaliPorezPostoChanged();
			partial void OnNaknadaNazivChanging(string value);
			partial void OnNaknadaNazivChanged();
			partial void OnIznosNaknadeChanging(decimal value);
			partial void OnIznosNaknadeChanged();
			#endregion

			public tblBillDocumentStavka()
			{
				_tblBillDocument = default(EntityRef<tblBillDocument>);
				_tblBillMjera = default(EntityRef<tblBillMjera>);
				_tblBillPoreznaGrupa = default(EntityRef<tblBillPoreznaGrupa>);
				_tblBillProduct = default(EntityRef<tblBillProduct>);
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=BigInt NOT NULL IDENTITY
			/// </summary>
			[ColumnAttribute(Storage="_BillDocumentStavkaID", AutoSync=AutoSync.OnInsert, DbType="BigInt NOT NULL IDENTITY", CanBeNull=false, IsPrimaryKey=true, IsDbGenerated=true)]
			public long BillDocumentStavkaID
			{
				get
				{
					return this._BillDocumentStavkaID;
				}
				set
				{
					if (this._BillDocumentStavkaID != value)
					{
						this.OnBillDocumentStavkaIDChanging(value);
						this.SendPropertyChanging();
						this._BillDocumentStavkaID = value;
						this.SendPropertyChanged("BillDocumentStavkaID");
						this.OnBillDocumentStavkaIDChanged();
					}
					this.SendPropertySetterInvoked("BillDocumentStavkaID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=BigInt NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_BillDocumentID", DbType="BigInt NOT NULL", CanBeNull=false)]
			public long BillDocumentID
			{
				get
				{
					return this._BillDocumentID;
				}
				set
				{
					if (this._BillDocumentID != value)
					{
						this.OnBillDocumentIDChanging(value);
						this.SendPropertyChanging();
						this._BillDocumentID = value;
						this.SendPropertyChanged("BillDocumentID");
						this.OnBillDocumentIDChanged();
					}
					this.SendPropertySetterInvoked("BillDocumentID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=BigInt NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_BillProductID", DbType="BigInt NOT NULL", CanBeNull=false)]
			public long BillProductID
			{
				get
				{
					return this._BillProductID;
				}
				set
				{
					if (this._BillProductID != value)
					{
						this.OnBillProductIDChanging(value);
						this.SendPropertyChanging();
						this._BillProductID = value;
						this.SendPropertyChanged("BillProductID");
						this.OnBillProductIDChanged();
					}
					this.SendPropertySetterInvoked("BillProductID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(150) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ProductNaziv", DbType="NVarChar(150) NOT NULL", CanBeNull=false)]
			public string ProductNaziv
			{
				get
				{
					return this._ProductNaziv;
				}
				set
				{
					if (this._ProductNaziv != value)
					{
						this.OnProductNazivChanging(value);
						this.SendPropertyChanging();
						this._ProductNaziv = value;
						this.SendPropertyChanged("ProductNaziv");
						this.OnProductNazivChanged();
					}
					this.SendPropertySetterInvoked("ProductNaziv", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Money NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_JedinicnaCijena", DbType="Money NOT NULL", CanBeNull=false)]
			public decimal JedinicnaCijena
			{
				get
				{
					return this._JedinicnaCijena;
				}
				set
				{
					if (this._JedinicnaCijena != value)
					{
						this.OnJedinicnaCijenaChanging(value);
						this.SendPropertyChanging();
						this._JedinicnaCijena = value;
						this.SendPropertyChanged("JedinicnaCijena");
						this.OnJedinicnaCijenaChanged();
					}
					this.SendPropertySetterInvoked("JedinicnaCijena", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Bit NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_CijenaJeMPC", DbType="Bit NOT NULL", CanBeNull=false)]
			public bool CijenaJeMPC
			{
				get
				{
					return this._CijenaJeMPC;
				}
				set
				{
					if (this._CijenaJeMPC != value)
					{
						this.OnCijenaJeMPCChanging(value);
						this.SendPropertyChanging();
						this._CijenaJeMPC = value;
						this.SendPropertyChanged("CijenaJeMPC");
						this.OnCijenaJeMPCChanged();
					}
					this.SendPropertySetterInvoked("CijenaJeMPC", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_BillMjeraID", DbType="Int NOT NULL", CanBeNull=false)]
			public int BillMjeraID
			{
				get
				{
					return this._BillMjeraID;
				}
				set
				{
					if (this._BillMjeraID != value)
					{
						this.OnBillMjeraIDChanging(value);
						this.SendPropertyChanging();
						this._BillMjeraID = value;
						this.SendPropertyChanged("BillMjeraID");
						this.OnBillMjeraIDChanged();
					}
					this.SendPropertySetterInvoked("BillMjeraID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Decimal(18,8) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_Kolicina", DbType="Decimal(18,8) NOT NULL", CanBeNull=false)]
			public decimal Kolicina
			{
				get
				{
					return this._Kolicina;
				}
				set
				{
					if (this._Kolicina != value)
					{
						this.OnKolicinaChanging(value);
						this.SendPropertyChanging();
						this._Kolicina = value;
						this.SendPropertyChanged("Kolicina");
						this.OnKolicinaChanged();
					}
					this.SendPropertySetterInvoked("Kolicina", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Money NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_PopustPosto", DbType="Money NOT NULL", CanBeNull=false)]
			public decimal PopustPosto
			{
				get
				{
					return this._PopustPosto;
				}
				set
				{
					if (this._PopustPosto != value)
					{
						this.OnPopustPostoChanging(value);
						this.SendPropertyChanging();
						this._PopustPosto = value;
						this.SendPropertyChanged("PopustPosto");
						this.OnPopustPostoChanged();
					}
					this.SendPropertySetterInvoked("PopustPosto", value);
				}
			}
			
			/// <summary>
			/// Column DbType=BigInt NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_BillPoreznaGrupaID", DbType="BigInt NOT NULL", CanBeNull=false)]
			public long BillPoreznaGrupaID
			{
				get
				{
					return this._BillPoreznaGrupaID;
				}
				set
				{
					if (this._BillPoreznaGrupaID != value)
					{
						this.OnBillPoreznaGrupaIDChanging(value);
						this.SendPropertyChanging();
						this._BillPoreznaGrupaID = value;
						this.SendPropertyChanged("BillPoreznaGrupaID");
						this.OnBillPoreznaGrupaIDChanged();
					}
					this.SendPropertySetterInvoked("BillPoreznaGrupaID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(100) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_PoreznaGrupaNaziv", DbType="NVarChar(100) NOT NULL", CanBeNull=false)]
			public string PoreznaGrupaNaziv
			{
				get
				{
					return this._PoreznaGrupaNaziv;
				}
				set
				{
					if (this._PoreznaGrupaNaziv != value)
					{
						this.OnPoreznaGrupaNazivChanging(value);
						this.SendPropertyChanging();
						this._PoreznaGrupaNaziv = value;
						this.SendPropertyChanged("PoreznaGrupaNaziv");
						this.OnPoreznaGrupaNazivChanged();
					}
					this.SendPropertySetterInvoked("PoreznaGrupaNaziv", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Bit NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_IsInPdvSustav", DbType="Bit NOT NULL", CanBeNull=false)]
			public bool IsInPdvSustav
			{
				get
				{
					return this._IsInPdvSustav;
				}
				set
				{
					if (this._IsInPdvSustav != value)
					{
						this.OnIsInPdvSustavChanging(value);
						this.SendPropertyChanging();
						this._IsInPdvSustav = value;
						this.SendPropertyChanged("IsInPdvSustav");
						this.OnIsInPdvSustavChanged();
					}
					this.SendPropertySetterInvoked("IsInPdvSustav", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Decimal(5,2) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_PdvPosto", DbType="Decimal(5,2) NOT NULL", CanBeNull=false)]
			public decimal PdvPosto
			{
				get
				{
					return this._PdvPosto;
				}
				set
				{
					if (this._PdvPosto != value)
					{
						this.OnPdvPostoChanging(value);
						this.SendPropertyChanging();
						this._PdvPosto = value;
						this.SendPropertyChanged("PdvPosto");
						this.OnPdvPostoChanged();
					}
					this.SendPropertySetterInvoked("PdvPosto", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Decimal(5,2) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_PorezPotrosnjaPosto", DbType="Decimal(5,2) NOT NULL", CanBeNull=false)]
			public decimal PorezPotrosnjaPosto
			{
				get
				{
					return this._PorezPotrosnjaPosto;
				}
				set
				{
					if (this._PorezPotrosnjaPosto != value)
					{
						this.OnPorezPotrosnjaPostoChanging(value);
						this.SendPropertyChanging();
						this._PorezPotrosnjaPosto = value;
						this.SendPropertyChanged("PorezPotrosnjaPosto");
						this.OnPorezPotrosnjaPostoChanged();
					}
					this.SendPropertySetterInvoked("PorezPotrosnjaPosto", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(50)
			/// </summary>
			[ColumnAttribute(Storage="_OstaliPorezNaziv", DbType="NVarChar(50)", CanBeNull=true)]
			public string OstaliPorezNaziv
			{
				get
				{
					return this._OstaliPorezNaziv;
				}
				set
				{
					if (this._OstaliPorezNaziv != value)
					{
						this.OnOstaliPorezNazivChanging(value);
						this.SendPropertyChanging();
						this._OstaliPorezNaziv = value;
						this.SendPropertyChanged("OstaliPorezNaziv");
						this.OnOstaliPorezNazivChanged();
					}
					this.SendPropertySetterInvoked("OstaliPorezNaziv", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Decimal(5,2) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_OstaliPorezPosto", DbType="Decimal(5,2) NOT NULL", CanBeNull=false)]
			public decimal OstaliPorezPosto
			{
				get
				{
					return this._OstaliPorezPosto;
				}
				set
				{
					if (this._OstaliPorezPosto != value)
					{
						this.OnOstaliPorezPostoChanging(value);
						this.SendPropertyChanging();
						this._OstaliPorezPosto = value;
						this.SendPropertyChanged("OstaliPorezPosto");
						this.OnOstaliPorezPostoChanged();
					}
					this.SendPropertySetterInvoked("OstaliPorezPosto", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(50)
			/// </summary>
			[ColumnAttribute(Storage="_NaknadaNaziv", DbType="NVarChar(50)", CanBeNull=true)]
			public string NaknadaNaziv
			{
				get
				{
					return this._NaknadaNaziv;
				}
				set
				{
					if (this._NaknadaNaziv != value)
					{
						this.OnNaknadaNazivChanging(value);
						this.SendPropertyChanging();
						this._NaknadaNaziv = value;
						this.SendPropertyChanged("NaknadaNaziv");
						this.OnNaknadaNazivChanged();
					}
					this.SendPropertySetterInvoked("NaknadaNaziv", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Money NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_IznosNaknade", DbType="Money NOT NULL", CanBeNull=false)]
			public decimal IznosNaknade
			{
				get
				{
					return this._IznosNaknade;
				}
				set
				{
					if (this._IznosNaknade != value)
					{
						this.OnIznosNaknadeChanging(value);
						this.SendPropertyChanging();
						this._IznosNaknade = value;
						this.SendPropertyChanged("IznosNaknade");
						this.OnIznosNaknadeChanged();
					}
					this.SendPropertySetterInvoked("IznosNaknade", value);
				}
			}
			
			#endregion Columns

			#region Associations
			/// <summary>
			/// Association [FK][Many]tblBillDocumentStavka.BillDocumentID --- [PK][One]tblBillDocument.BillDocumentID
			/// </summary>
			[AssociationAttribute(Name="FK_tblBillDocumentStavka_tblBillDocument", Storage="_tblBillDocument", ThisKey="BillDocumentID", OtherKey="BillDocumentID", IsUnique=false, IsForeignKey=true)]
			public tblBillDocument tblBillDocument
			{
				get
				{
					return this._tblBillDocument.Entity;
				}
				set
				{
					tblBillDocument previousValue = this._tblBillDocument.Entity;
					if ((previousValue != value) || (this._tblBillDocument.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._tblBillDocument.Entity = null;
							previousValue.tblBillDocumentStavkaList.Remove(this);
						}
						this._tblBillDocument.Entity = value;
						if (value != null)
						{
							value.tblBillDocumentStavkaList.Add(this);
							this._BillDocumentID = value.BillDocumentID;
						}
						else
						{
							this._BillDocumentID = default(long);
						}
						this.SendPropertyChanged("tblBillDocument");
					}
					this.SendPropertySetterInvoked("tblBillDocument", value);
				}
			}
			
			/// <summary>
			/// Association [FK][Many]tblBillDocumentStavka.BillMjeraID --- [PK][One]tblBillMjera.BillMjeraID
			/// </summary>
			[AssociationAttribute(Name="FK_tblBillDocumentStavka_tblBillMjera", Storage="_tblBillMjera", ThisKey="BillMjeraID", OtherKey="BillMjeraID", IsUnique=false, IsForeignKey=true)]
			public tblBillMjera tblBillMjera
			{
				get
				{
					return this._tblBillMjera.Entity;
				}
				set
				{
					tblBillMjera previousValue = this._tblBillMjera.Entity;
					if ((previousValue != value) || (this._tblBillMjera.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._tblBillMjera.Entity = null;
							previousValue.tblBillDocumentStavkaList.Remove(this);
						}
						this._tblBillMjera.Entity = value;
						if (value != null)
						{
							value.tblBillDocumentStavkaList.Add(this);
							this._BillMjeraID = value.BillMjeraID;
						}
						else
						{
							this._BillMjeraID = default(int);
						}
						this.SendPropertyChanged("tblBillMjera");
					}
					this.SendPropertySetterInvoked("tblBillMjera", value);
				}
			}
			
			/// <summary>
			/// Association [FK][Many]tblBillDocumentStavka.BillPoreznaGrupaID --- [PK][One]tblBillPoreznaGrupa.BillPoreznaGrupaID
			/// </summary>
			[AssociationAttribute(Name="FK_tblBillDocumentStavka_tblBillPoreznaGrupa", Storage="_tblBillPoreznaGrupa", ThisKey="BillPoreznaGrupaID", OtherKey="BillPoreznaGrupaID", IsUnique=false, IsForeignKey=true)]
			public tblBillPoreznaGrupa tblBillPoreznaGrupa
			{
				get
				{
					return this._tblBillPoreznaGrupa.Entity;
				}
				set
				{
					tblBillPoreznaGrupa previousValue = this._tblBillPoreznaGrupa.Entity;
					if ((previousValue != value) || (this._tblBillPoreznaGrupa.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._tblBillPoreznaGrupa.Entity = null;
							previousValue.tblBillDocumentStavkaList.Remove(this);
						}
						this._tblBillPoreznaGrupa.Entity = value;
						if (value != null)
						{
							value.tblBillDocumentStavkaList.Add(this);
							this._BillPoreznaGrupaID = value.BillPoreznaGrupaID;
						}
						else
						{
							this._BillPoreznaGrupaID = default(long);
						}
						this.SendPropertyChanged("tblBillPoreznaGrupa");
					}
					this.SendPropertySetterInvoked("tblBillPoreznaGrupa", value);
				}
			}
			
			/// <summary>
			/// Association [FK][Many]tblBillDocumentStavka.BillProductID --- [PK][One]tblBillProduct.BillProductID
			/// </summary>
			[AssociationAttribute(Name="FK_tblBillDocumentStavka_tblBillProduct", Storage="_tblBillProduct", ThisKey="BillProductID", OtherKey="BillProductID", IsUnique=false, IsForeignKey=true)]
			public tblBillProduct tblBillProduct
			{
				get
				{
					return this._tblBillProduct.Entity;
				}
				set
				{
					tblBillProduct previousValue = this._tblBillProduct.Entity;
					if ((previousValue != value) || (this._tblBillProduct.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._tblBillProduct.Entity = null;
							previousValue.tblBillDocumentStavkaList.Remove(this);
						}
						this._tblBillProduct.Entity = value;
						if (value != null)
						{
							value.tblBillDocumentStavkaList.Add(this);
							this._BillProductID = value.BillProductID;
						}
						else
						{
							this._BillProductID = default(long);
						}
						this.SendPropertyChanged("tblBillProduct");
					}
					this.SendPropertySetterInvoked("tblBillProduct", value);
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
		#endregion dbo.tblBillDocumentStavka

		#region dbo.tblBillDocumentTip
		[TableAttribute(Name="dbo.tblBillDocumentTip")]
		public partial class tblBillDocumentTip : EntityBase<tblBillDocumentTip, dbArizonaAppDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private int _BillDocumentTipID;
			private bool _IsActive;
			private int _Ordinal;
			private bool _IsDefault;
			private string _Naziv;
			private bool _IsRacunType;
			private bool _IsMaloprodajniRacun;
			private EntitySet<tblBillNaplatniUredjaj> _tblBillNaplatniUredjajList;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnBillDocumentTipIDChanging(int value);
			partial void OnBillDocumentTipIDChanged();
			partial void OnIsActiveChanging(bool value);
			partial void OnIsActiveChanged();
			partial void OnOrdinalChanging(int value);
			partial void OnOrdinalChanged();
			partial void OnIsDefaultChanging(bool value);
			partial void OnIsDefaultChanged();
			partial void OnNazivChanging(string value);
			partial void OnNazivChanged();
			partial void OnIsRacunTypeChanging(bool value);
			partial void OnIsRacunTypeChanged();
			partial void OnIsMaloprodajniRacunChanging(bool value);
			partial void OnIsMaloprodajniRacunChanged();
			#endregion

			public tblBillDocumentTip()
			{
				_tblBillNaplatniUredjajList = new EntitySet<tblBillNaplatniUredjaj>(
					new Action<tblBillNaplatniUredjaj>(item=>{this.SendPropertyChanging(); item.tblBillDocumentTip=this;}), 
					new Action<tblBillNaplatniUredjaj>(item=>{this.SendPropertyChanging(); item.tblBillDocumentTip=null;}));
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_BillDocumentTipID", DbType="Int NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
			public int BillDocumentTipID
			{
				get
				{
					return this._BillDocumentTipID;
				}
				set
				{
					if (this._BillDocumentTipID != value)
					{
						this.OnBillDocumentTipIDChanging(value);
						this.SendPropertyChanging();
						this._BillDocumentTipID = value;
						this.SendPropertyChanged("BillDocumentTipID");
						this.OnBillDocumentTipIDChanged();
					}
					this.SendPropertySetterInvoked("BillDocumentTipID", value);
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
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_Ordinal", DbType="Int NOT NULL", CanBeNull=false)]
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
						this.OnOrdinalChanging(value);
						this.SendPropertyChanging();
						this._Ordinal = value;
						this.SendPropertyChanged("Ordinal");
						this.OnOrdinalChanged();
					}
					this.SendPropertySetterInvoked("Ordinal", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Bit NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_IsDefault", DbType="Bit NOT NULL", CanBeNull=false)]
			public bool IsDefault
			{
				get
				{
					return this._IsDefault;
				}
				set
				{
					if (this._IsDefault != value)
					{
						this.OnIsDefaultChanging(value);
						this.SendPropertyChanging();
						this._IsDefault = value;
						this.SendPropertyChanged("IsDefault");
						this.OnIsDefaultChanged();
					}
					this.SendPropertySetterInvoked("IsDefault", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(100) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_Naziv", DbType="NVarChar(100) NOT NULL", CanBeNull=false)]
			public string Naziv
			{
				get
				{
					return this._Naziv;
				}
				set
				{
					if (this._Naziv != value)
					{
						this.OnNazivChanging(value);
						this.SendPropertyChanging();
						this._Naziv = value;
						this.SendPropertyChanged("Naziv");
						this.OnNazivChanged();
					}
					this.SendPropertySetterInvoked("Naziv", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Bit NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_IsRacunType", DbType="Bit NOT NULL", CanBeNull=false)]
			public bool IsRacunType
			{
				get
				{
					return this._IsRacunType;
				}
				set
				{
					if (this._IsRacunType != value)
					{
						this.OnIsRacunTypeChanging(value);
						this.SendPropertyChanging();
						this._IsRacunType = value;
						this.SendPropertyChanged("IsRacunType");
						this.OnIsRacunTypeChanged();
					}
					this.SendPropertySetterInvoked("IsRacunType", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Bit NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_IsMaloprodajniRacun", DbType="Bit NOT NULL", CanBeNull=false)]
			public bool IsMaloprodajniRacun
			{
				get
				{
					return this._IsMaloprodajniRacun;
				}
				set
				{
					if (this._IsMaloprodajniRacun != value)
					{
						this.OnIsMaloprodajniRacunChanging(value);
						this.SendPropertyChanging();
						this._IsMaloprodajniRacun = value;
						this.SendPropertyChanged("IsMaloprodajniRacun");
						this.OnIsMaloprodajniRacunChanged();
					}
					this.SendPropertySetterInvoked("IsMaloprodajniRacun", value);
				}
			}
			
			#endregion Columns

			#region Associations
			/// <summary>
			/// Association [PK][One]tblBillDocumentTip.BillDocumentTipID --- [FK][Many]tblBillNaplatniUredjaj.BillDocumentTipID
			/// </summary>
			[AssociationAttribute(Name="FK_tblBillNaplatniUredjaj_tblBillDocumentTip", Storage="_tblBillNaplatniUredjajList", ThisKey="BillDocumentTipID", OtherKey="BillDocumentTipID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<tblBillNaplatniUredjaj> tblBillNaplatniUredjajList
			{
				get { return this._tblBillNaplatniUredjajList; }
				set { this._tblBillNaplatniUredjajList.Assign(value); }
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
		#endregion dbo.tblBillDocumentTip

		#region dbo.tblBillDocumentVariant
		[TableAttribute(Name="dbo.tblBillDocumentVariant")]
		public partial class tblBillDocumentVariant : EntityBase<tblBillDocumentVariant, dbArizonaAppDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private int _VariantID;
			private bool _MarkBillAsSent;
			private string _Name;
			private string _Description;
			private EntitySet<tblBillDocument> _tblBillDocumentList;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnVariantIDChanging(int value);
			partial void OnVariantIDChanged();
			partial void OnMarkBillAsSentChanging(bool value);
			partial void OnMarkBillAsSentChanged();
			partial void OnNameChanging(string value);
			partial void OnNameChanged();
			partial void OnDescriptionChanging(string value);
			partial void OnDescriptionChanged();
			#endregion

			public tblBillDocumentVariant()
			{
				_tblBillDocumentList = new EntitySet<tblBillDocument>(
					new Action<tblBillDocument>(item=>{this.SendPropertyChanging(); item.tblBillDocumentVariant=this;}), 
					new Action<tblBillDocument>(item=>{this.SendPropertyChanging(); item.tblBillDocumentVariant=null;}));
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_VariantID", DbType="Int NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
			public int VariantID
			{
				get
				{
					return this._VariantID;
				}
				set
				{
					if (this._VariantID != value)
					{
						this.OnVariantIDChanging(value);
						this.SendPropertyChanging();
						this._VariantID = value;
						this.SendPropertyChanged("VariantID");
						this.OnVariantIDChanged();
					}
					this.SendPropertySetterInvoked("VariantID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Bit NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_MarkBillAsSent", DbType="Bit NOT NULL", CanBeNull=false)]
			public bool MarkBillAsSent
			{
				get
				{
					return this._MarkBillAsSent;
				}
				set
				{
					if (this._MarkBillAsSent != value)
					{
						this.OnMarkBillAsSentChanging(value);
						this.SendPropertyChanging();
						this._MarkBillAsSent = value;
						this.SendPropertyChanged("MarkBillAsSent");
						this.OnMarkBillAsSentChanged();
					}
					this.SendPropertySetterInvoked("MarkBillAsSent", value);
				}
			}
			
			/// <summary>
			/// Column DbType=VarChar(255)
			/// </summary>
			[ColumnAttribute(Storage="_Name", DbType="VarChar(255)", CanBeNull=true)]
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
			/// Column DbType=VarChar(1000)
			/// </summary>
			[ColumnAttribute(Storage="_Description", DbType="VarChar(1000)", CanBeNull=true)]
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
			/// Association [PK][One]tblBillDocumentVariant.VariantID --- [FK][Many]tblBillDocument.VariantID
			/// </summary>
			[AssociationAttribute(Name="FK_tblBillDocument_tblBillDocumentVariant", Storage="_tblBillDocumentList", ThisKey="VariantID", OtherKey="VariantID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<tblBillDocument> tblBillDocumentList
			{
				get { return this._tblBillDocumentList; }
				set { this._tblBillDocumentList.Assign(value); }
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
		#endregion dbo.tblBillDocumentVariant

		#region dbo.tblBillDownloadLog
		[TableAttribute(Name="dbo.tblBillDownloadLog")]
		public partial class tblBillDownloadLog : EntityBase<tblBillDownloadLog, dbArizonaAppDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private long _BillDownloadLog;
			private DateTime? _InsertionDate;
			private string _OIB;
			private string _PozivNaBroj;
			private long? _BillDocumentID;
			private EntityRef<tblBillDocument> _tblBillDocument;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnBillDownloadLogChanging(long value);
			partial void OnBillDownloadLogChanged();
			partial void OnInsertionDateChanging(DateTime? value);
			partial void OnInsertionDateChanged();
			partial void OnOIBChanging(string value);
			partial void OnOIBChanged();
			partial void OnPozivNaBrojChanging(string value);
			partial void OnPozivNaBrojChanged();
			partial void OnBillDocumentIDChanging(long? value);
			partial void OnBillDocumentIDChanged();
			#endregion

			public tblBillDownloadLog()
			{
				_tblBillDocument = default(EntityRef<tblBillDocument>);
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=BigInt NOT NULL IDENTITY
			/// </summary>
			[ColumnAttribute(Storage="_BillDownloadLog", AutoSync=AutoSync.OnInsert, DbType="BigInt NOT NULL IDENTITY", CanBeNull=false, IsPrimaryKey=true, IsDbGenerated=true)]
			public long BillDownloadLog
			{
				get
				{
					return this._BillDownloadLog;
				}
				set
				{
					if (this._BillDownloadLog != value)
					{
						this.OnBillDownloadLogChanging(value);
						this.SendPropertyChanging();
						this._BillDownloadLog = value;
						this.SendPropertyChanged("BillDownloadLog");
						this.OnBillDownloadLogChanged();
					}
					this.SendPropertySetterInvoked("BillDownloadLog", value);
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
			/// Column DbType=VarChar(20)
			/// </summary>
			[ColumnAttribute(Storage="_OIB", DbType="VarChar(20)", CanBeNull=true)]
			public string OIB
			{
				get
				{
					return this._OIB;
				}
				set
				{
					if (this._OIB != value)
					{
						this.OnOIBChanging(value);
						this.SendPropertyChanging();
						this._OIB = value;
						this.SendPropertyChanged("OIB");
						this.OnOIBChanged();
					}
					this.SendPropertySetterInvoked("OIB", value);
				}
			}
			
			/// <summary>
			/// Column DbType=VarChar(50)
			/// </summary>
			[ColumnAttribute(Storage="_PozivNaBroj", DbType="VarChar(50)", CanBeNull=true)]
			public string PozivNaBroj
			{
				get
				{
					return this._PozivNaBroj;
				}
				set
				{
					if (this._PozivNaBroj != value)
					{
						this.OnPozivNaBrojChanging(value);
						this.SendPropertyChanging();
						this._PozivNaBroj = value;
						this.SendPropertyChanged("PozivNaBroj");
						this.OnPozivNaBrojChanged();
					}
					this.SendPropertySetterInvoked("PozivNaBroj", value);
				}
			}
			
			/// <summary>
			/// Column DbType=BigInt
			/// </summary>
			[ColumnAttribute(Storage="_BillDocumentID", DbType="BigInt", CanBeNull=true)]
			public long? BillDocumentID
			{
				get
				{
					return this._BillDocumentID;
				}
				set
				{
					if (this._BillDocumentID != value)
					{
						this.OnBillDocumentIDChanging(value);
						this.SendPropertyChanging();
						this._BillDocumentID = value;
						this.SendPropertyChanged("BillDocumentID");
						this.OnBillDocumentIDChanged();
					}
					this.SendPropertySetterInvoked("BillDocumentID", value);
				}
			}
			
			#endregion Columns

			#region Associations
			/// <summary>
			/// Association [FK][Many]tblBillDownloadLog.BillDocumentID --- [PK][One]tblBillDocument.BillDocumentID
			/// </summary>
			[AssociationAttribute(Name="FK_tblBillDownloadLog_tblBillDocument", Storage="_tblBillDocument", ThisKey="BillDocumentID", OtherKey="BillDocumentID", IsUnique=false, IsForeignKey=true)]
			public tblBillDocument tblBillDocument
			{
				get
				{
					return this._tblBillDocument.Entity;
				}
				set
				{
					tblBillDocument previousValue = this._tblBillDocument.Entity;
					if ((previousValue != value) || (this._tblBillDocument.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._tblBillDocument.Entity = null;
							previousValue.tblBillDownloadLogList.Remove(this);
						}
						this._tblBillDocument.Entity = value;
						if (value != null)
						{
							value.tblBillDownloadLogList.Add(this);
							this._BillDocumentID = value.BillDocumentID;
						}
						else
						{
							this._BillDocumentID = default(long?);
						}
						this.SendPropertyChanged("tblBillDocument");
					}
					this.SendPropertySetterInvoked("tblBillDocument", value);
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
		#endregion dbo.tblBillDownloadLog

		#region dbo.tblBillFirma
		[TableAttribute(Name="dbo.tblBillFirma")]
		public partial class tblBillFirma : EntityBase<tblBillFirma, dbArizonaAppDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private int _BillFirmaID;
			private DateTime? _PdvSustavStartDate;
			private DateTime? _PdvSustavEndDate;
			private string _OIB;
			private string _Naziv;
			private string _Adresa;
			private string _PostanskiBroj;
			private string _Mjesto;
			private string _OslobodjenoPdvaNapomena;
			private string _RacunIzradjenNaRacunaluNapomena;
			private string _Email;
			private string _WebSite;
			private string _Telefon;
			private string _Mobitel;
			private string _Fax;
			private int _BillFirmaCertificateModeID;
			private string _FooterText;
			private bool? _HidePoweredByFooter;
			private EntitySet<tblAppMember> _tblAppMemberList;
			private EntitySet<tblAppSchedule> _tblAppScheduleList;
			private EntitySet<tblAppScheduleType> _tblAppScheduleTypeList;
			private EntitySet<tblBillClient> _tblBillClientList;
			private EntityRef<tblBillFirmaCertificateMode> _tblBillFirmaCertificateMode;
			private EntitySet<tblBillFirmaCertificate> _tblBillFirmaCertificateList;
			private EntitySet<tblBillFirmaPos> _tblBillFirmaPosList;
			private EntitySet<tblBillFirmaTransakcijskiRacun> _tblBillFirmaTransakcijskiRacunList;
			private EntitySet<tblBillPoslovniProstor> _tblBillPoslovniProstorList;
			private EntitySet<tblBookkeepingFiduciaExport> _tblBookkeepingFiduciaExportList;
			private EntitySet<tblBookkeepingSynesisExport> _tblBookkeepingSynesisExportList;
			private EntitySet<tblDirClientBlacklist> _tblDirClientBlacklistList;
			private EntitySet<tblDirClientVracenaPosta> _tblDirClientVracenaPostaList;
			private EntitySet<tblJobAdvert> _tblJobAdvertList;
			private EntitySet<tblJobTemplate> _tblJobTemplateList;
			private EntitySet<tblPozivLog> _tblPozivLogList;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnBillFirmaIDChanging(int value);
			partial void OnBillFirmaIDChanged();
			partial void OnPdvSustavStartDateChanging(DateTime? value);
			partial void OnPdvSustavStartDateChanged();
			partial void OnPdvSustavEndDateChanging(DateTime? value);
			partial void OnPdvSustavEndDateChanged();
			partial void OnOIBChanging(string value);
			partial void OnOIBChanged();
			partial void OnNazivChanging(string value);
			partial void OnNazivChanged();
			partial void OnAdresaChanging(string value);
			partial void OnAdresaChanged();
			partial void OnPostanskiBrojChanging(string value);
			partial void OnPostanskiBrojChanged();
			partial void OnMjestoChanging(string value);
			partial void OnMjestoChanged();
			partial void OnOslobodjenoPdvaNapomenaChanging(string value);
			partial void OnOslobodjenoPdvaNapomenaChanged();
			partial void OnRacunIzradjenNaRacunaluNapomenaChanging(string value);
			partial void OnRacunIzradjenNaRacunaluNapomenaChanged();
			partial void OnEmailChanging(string value);
			partial void OnEmailChanged();
			partial void OnWebSiteChanging(string value);
			partial void OnWebSiteChanged();
			partial void OnTelefonChanging(string value);
			partial void OnTelefonChanged();
			partial void OnMobitelChanging(string value);
			partial void OnMobitelChanged();
			partial void OnFaxChanging(string value);
			partial void OnFaxChanged();
			partial void OnBillFirmaCertificateModeIDChanging(int value);
			partial void OnBillFirmaCertificateModeIDChanged();
			partial void OnFooterTextChanging(string value);
			partial void OnFooterTextChanged();
			partial void OnHidePoweredByFooterChanging(bool? value);
			partial void OnHidePoweredByFooterChanged();
			#endregion

			public tblBillFirma()
			{
				_tblAppMemberList = new EntitySet<tblAppMember>(
					new Action<tblAppMember>(item=>{this.SendPropertyChanging(); item.tblBillFirma=this;}), 
					new Action<tblAppMember>(item=>{this.SendPropertyChanging(); item.tblBillFirma=null;}));
				_tblAppScheduleList = new EntitySet<tblAppSchedule>(
					new Action<tblAppSchedule>(item=>{this.SendPropertyChanging(); item.tblBillFirma=this;}), 
					new Action<tblAppSchedule>(item=>{this.SendPropertyChanging(); item.tblBillFirma=null;}));
				_tblAppScheduleTypeList = new EntitySet<tblAppScheduleType>(
					new Action<tblAppScheduleType>(item=>{this.SendPropertyChanging(); item.tblBillFirma=this;}), 
					new Action<tblAppScheduleType>(item=>{this.SendPropertyChanging(); item.tblBillFirma=null;}));
				_tblBillClientList = new EntitySet<tblBillClient>(
					new Action<tblBillClient>(item=>{this.SendPropertyChanging(); item.tblBillFirma=this;}), 
					new Action<tblBillClient>(item=>{this.SendPropertyChanging(); item.tblBillFirma=null;}));
				_tblBillFirmaCertificateMode = default(EntityRef<tblBillFirmaCertificateMode>);
				_tblBillFirmaCertificateList = new EntitySet<tblBillFirmaCertificate>(
					new Action<tblBillFirmaCertificate>(item=>{this.SendPropertyChanging(); item.tblBillFirma=this;}), 
					new Action<tblBillFirmaCertificate>(item=>{this.SendPropertyChanging(); item.tblBillFirma=null;}));
				_tblBillFirmaPosList = new EntitySet<tblBillFirmaPos>(
					new Action<tblBillFirmaPos>(item=>{this.SendPropertyChanging(); item.tblBillFirma=this;}), 
					new Action<tblBillFirmaPos>(item=>{this.SendPropertyChanging(); item.tblBillFirma=null;}));
				_tblBillFirmaTransakcijskiRacunList = new EntitySet<tblBillFirmaTransakcijskiRacun>(
					new Action<tblBillFirmaTransakcijskiRacun>(item=>{this.SendPropertyChanging(); item.tblBillFirma=this;}), 
					new Action<tblBillFirmaTransakcijskiRacun>(item=>{this.SendPropertyChanging(); item.tblBillFirma=null;}));
				_tblBillPoslovniProstorList = new EntitySet<tblBillPoslovniProstor>(
					new Action<tblBillPoslovniProstor>(item=>{this.SendPropertyChanging(); item.tblBillFirma=this;}), 
					new Action<tblBillPoslovniProstor>(item=>{this.SendPropertyChanging(); item.tblBillFirma=null;}));
				_tblBookkeepingFiduciaExportList = new EntitySet<tblBookkeepingFiduciaExport>(
					new Action<tblBookkeepingFiduciaExport>(item=>{this.SendPropertyChanging(); item.tblBillFirma=this;}), 
					new Action<tblBookkeepingFiduciaExport>(item=>{this.SendPropertyChanging(); item.tblBillFirma=null;}));
				_tblBookkeepingSynesisExportList = new EntitySet<tblBookkeepingSynesisExport>(
					new Action<tblBookkeepingSynesisExport>(item=>{this.SendPropertyChanging(); item.tblBillFirma=this;}), 
					new Action<tblBookkeepingSynesisExport>(item=>{this.SendPropertyChanging(); item.tblBillFirma=null;}));
				_tblDirClientBlacklistList = new EntitySet<tblDirClientBlacklist>(
					new Action<tblDirClientBlacklist>(item=>{this.SendPropertyChanging(); item.tblBillFirma=this;}), 
					new Action<tblDirClientBlacklist>(item=>{this.SendPropertyChanging(); item.tblBillFirma=null;}));
				_tblDirClientVracenaPostaList = new EntitySet<tblDirClientVracenaPosta>(
					new Action<tblDirClientVracenaPosta>(item=>{this.SendPropertyChanging(); item.tblBillFirma=this;}), 
					new Action<tblDirClientVracenaPosta>(item=>{this.SendPropertyChanging(); item.tblBillFirma=null;}));
				_tblJobAdvertList = new EntitySet<tblJobAdvert>(
					new Action<tblJobAdvert>(item=>{this.SendPropertyChanging(); item.tblBillFirma=this;}), 
					new Action<tblJobAdvert>(item=>{this.SendPropertyChanging(); item.tblBillFirma=null;}));
				_tblJobTemplateList = new EntitySet<tblJobTemplate>(
					new Action<tblJobTemplate>(item=>{this.SendPropertyChanging(); item.tblBillFirma=this;}), 
					new Action<tblJobTemplate>(item=>{this.SendPropertyChanging(); item.tblBillFirma=null;}));
				_tblPozivLogList = new EntitySet<tblPozivLog>(
					new Action<tblPozivLog>(item=>{this.SendPropertyChanging(); item.tblBillFirma=this;}), 
					new Action<tblPozivLog>(item=>{this.SendPropertyChanging(); item.tblBillFirma=null;}));
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=Int NOT NULL IDENTITY
			/// </summary>
			[ColumnAttribute(Storage="_BillFirmaID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", CanBeNull=false, IsPrimaryKey=true, IsDbGenerated=true)]
			public int BillFirmaID
			{
				get
				{
					return this._BillFirmaID;
				}
				set
				{
					if (this._BillFirmaID != value)
					{
						this.OnBillFirmaIDChanging(value);
						this.SendPropertyChanging();
						this._BillFirmaID = value;
						this.SendPropertyChanged("BillFirmaID");
						this.OnBillFirmaIDChanged();
					}
					this.SendPropertySetterInvoked("BillFirmaID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime
			/// </summary>
			[ColumnAttribute(Storage="_PdvSustavStartDate", DbType="DateTime", CanBeNull=true)]
			public DateTime? PdvSustavStartDate
			{
				get
				{
					return this._PdvSustavStartDate;
				}
				set
				{
					if (this._PdvSustavStartDate != value)
					{
						this.OnPdvSustavStartDateChanging(value);
						this.SendPropertyChanging();
						this._PdvSustavStartDate = value;
						this.SendPropertyChanged("PdvSustavStartDate");
						this.OnPdvSustavStartDateChanged();
					}
					this.SendPropertySetterInvoked("PdvSustavStartDate", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime
			/// </summary>
			[ColumnAttribute(Storage="_PdvSustavEndDate", DbType="DateTime", CanBeNull=true)]
			public DateTime? PdvSustavEndDate
			{
				get
				{
					return this._PdvSustavEndDate;
				}
				set
				{
					if (this._PdvSustavEndDate != value)
					{
						this.OnPdvSustavEndDateChanging(value);
						this.SendPropertyChanging();
						this._PdvSustavEndDate = value;
						this.SendPropertyChanged("PdvSustavEndDate");
						this.OnPdvSustavEndDateChanged();
					}
					this.SendPropertySetterInvoked("PdvSustavEndDate", value);
				}
			}
			
			/// <summary>
			/// Column DbType=VarChar(15) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_OIB", DbType="VarChar(15) NOT NULL", CanBeNull=false)]
			public string OIB
			{
				get
				{
					return this._OIB;
				}
				set
				{
					if (this._OIB != value)
					{
						this.OnOIBChanging(value);
						this.SendPropertyChanging();
						this._OIB = value;
						this.SendPropertyChanged("OIB");
						this.OnOIBChanged();
					}
					this.SendPropertySetterInvoked("OIB", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(255)
			/// </summary>
			[ColumnAttribute(Storage="_Naziv", DbType="NVarChar(255)", CanBeNull=true)]
			public string Naziv
			{
				get
				{
					return this._Naziv;
				}
				set
				{
					if (this._Naziv != value)
					{
						this.OnNazivChanging(value);
						this.SendPropertyChanging();
						this._Naziv = value;
						this.SendPropertyChanged("Naziv");
						this.OnNazivChanged();
					}
					this.SendPropertySetterInvoked("Naziv", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(255)
			/// </summary>
			[ColumnAttribute(Storage="_Adresa", DbType="NVarChar(255)", CanBeNull=true)]
			public string Adresa
			{
				get
				{
					return this._Adresa;
				}
				set
				{
					if (this._Adresa != value)
					{
						this.OnAdresaChanging(value);
						this.SendPropertyChanging();
						this._Adresa = value;
						this.SendPropertyChanged("Adresa");
						this.OnAdresaChanged();
					}
					this.SendPropertySetterInvoked("Adresa", value);
				}
			}
			
			/// <summary>
			/// Column DbType=VarChar(10)
			/// </summary>
			[ColumnAttribute(Storage="_PostanskiBroj", DbType="VarChar(10)", CanBeNull=true)]
			public string PostanskiBroj
			{
				get
				{
					return this._PostanskiBroj;
				}
				set
				{
					if (this._PostanskiBroj != value)
					{
						this.OnPostanskiBrojChanging(value);
						this.SendPropertyChanging();
						this._PostanskiBroj = value;
						this.SendPropertyChanged("PostanskiBroj");
						this.OnPostanskiBrojChanged();
					}
					this.SendPropertySetterInvoked("PostanskiBroj", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(100)
			/// </summary>
			[ColumnAttribute(Storage="_Mjesto", DbType="NVarChar(100)", CanBeNull=true)]
			public string Mjesto
			{
				get
				{
					return this._Mjesto;
				}
				set
				{
					if (this._Mjesto != value)
					{
						this.OnMjestoChanging(value);
						this.SendPropertyChanging();
						this._Mjesto = value;
						this.SendPropertyChanged("Mjesto");
						this.OnMjestoChanged();
					}
					this.SendPropertySetterInvoked("Mjesto", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(255)
			/// </summary>
			[ColumnAttribute(Storage="_OslobodjenoPdvaNapomena", DbType="NVarChar(255)", CanBeNull=true)]
			public string OslobodjenoPdvaNapomena
			{
				get
				{
					return this._OslobodjenoPdvaNapomena;
				}
				set
				{
					if (this._OslobodjenoPdvaNapomena != value)
					{
						this.OnOslobodjenoPdvaNapomenaChanging(value);
						this.SendPropertyChanging();
						this._OslobodjenoPdvaNapomena = value;
						this.SendPropertyChanged("OslobodjenoPdvaNapomena");
						this.OnOslobodjenoPdvaNapomenaChanged();
					}
					this.SendPropertySetterInvoked("OslobodjenoPdvaNapomena", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(255)
			/// </summary>
			[ColumnAttribute(Storage="_RacunIzradjenNaRacunaluNapomena", DbType="NVarChar(255)", CanBeNull=true)]
			public string RacunIzradjenNaRacunaluNapomena
			{
				get
				{
					return this._RacunIzradjenNaRacunaluNapomena;
				}
				set
				{
					if (this._RacunIzradjenNaRacunaluNapomena != value)
					{
						this.OnRacunIzradjenNaRacunaluNapomenaChanging(value);
						this.SendPropertyChanging();
						this._RacunIzradjenNaRacunaluNapomena = value;
						this.SendPropertyChanged("RacunIzradjenNaRacunaluNapomena");
						this.OnRacunIzradjenNaRacunaluNapomenaChanged();
					}
					this.SendPropertySetterInvoked("RacunIzradjenNaRacunaluNapomena", value);
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
			/// Column DbType=VarChar(255)
			/// </summary>
			[ColumnAttribute(Storage="_WebSite", DbType="VarChar(255)", CanBeNull=true)]
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
			/// Column DbType=VarChar(20)
			/// </summary>
			[ColumnAttribute(Storage="_Telefon", DbType="VarChar(20)", CanBeNull=true)]
			public string Telefon
			{
				get
				{
					return this._Telefon;
				}
				set
				{
					if (this._Telefon != value)
					{
						this.OnTelefonChanging(value);
						this.SendPropertyChanging();
						this._Telefon = value;
						this.SendPropertyChanged("Telefon");
						this.OnTelefonChanged();
					}
					this.SendPropertySetterInvoked("Telefon", value);
				}
			}
			
			/// <summary>
			/// Column DbType=VarChar(20)
			/// </summary>
			[ColumnAttribute(Storage="_Mobitel", DbType="VarChar(20)", CanBeNull=true)]
			public string Mobitel
			{
				get
				{
					return this._Mobitel;
				}
				set
				{
					if (this._Mobitel != value)
					{
						this.OnMobitelChanging(value);
						this.SendPropertyChanging();
						this._Mobitel = value;
						this.SendPropertyChanged("Mobitel");
						this.OnMobitelChanged();
					}
					this.SendPropertySetterInvoked("Mobitel", value);
				}
			}
			
			/// <summary>
			/// Column DbType=VarChar(20)
			/// </summary>
			[ColumnAttribute(Storage="_Fax", DbType="VarChar(20)", CanBeNull=true)]
			public string Fax
			{
				get
				{
					return this._Fax;
				}
				set
				{
					if (this._Fax != value)
					{
						this.OnFaxChanging(value);
						this.SendPropertyChanging();
						this._Fax = value;
						this.SendPropertyChanged("Fax");
						this.OnFaxChanged();
					}
					this.SendPropertySetterInvoked("Fax", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_BillFirmaCertificateModeID", DbType="Int NOT NULL", CanBeNull=false)]
			public int BillFirmaCertificateModeID
			{
				get
				{
					return this._BillFirmaCertificateModeID;
				}
				set
				{
					if (this._BillFirmaCertificateModeID != value)
					{
						this.OnBillFirmaCertificateModeIDChanging(value);
						this.SendPropertyChanging();
						this._BillFirmaCertificateModeID = value;
						this.SendPropertyChanged("BillFirmaCertificateModeID");
						this.OnBillFirmaCertificateModeIDChanged();
					}
					this.SendPropertySetterInvoked("BillFirmaCertificateModeID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(500)
			/// </summary>
			[ColumnAttribute(Storage="_FooterText", DbType="NVarChar(500)", CanBeNull=true)]
			public string FooterText
			{
				get
				{
					return this._FooterText;
				}
				set
				{
					if (this._FooterText != value)
					{
						this.OnFooterTextChanging(value);
						this.SendPropertyChanging();
						this._FooterText = value;
						this.SendPropertyChanged("FooterText");
						this.OnFooterTextChanged();
					}
					this.SendPropertySetterInvoked("FooterText", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Bit
			/// </summary>
			[ColumnAttribute(Storage="_HidePoweredByFooter", DbType="Bit", CanBeNull=true)]
			public bool? HidePoweredByFooter
			{
				get
				{
					return this._HidePoweredByFooter;
				}
				set
				{
					if (this._HidePoweredByFooter != value)
					{
						this.OnHidePoweredByFooterChanging(value);
						this.SendPropertyChanging();
						this._HidePoweredByFooter = value;
						this.SendPropertyChanged("HidePoweredByFooter");
						this.OnHidePoweredByFooterChanged();
					}
					this.SendPropertySetterInvoked("HidePoweredByFooter", value);
				}
			}
			
			#endregion Columns

			#region Associations
			/// <summary>
			/// Association [PK][One]tblBillFirma.BillFirmaID --- [FK][Many]tblAppMember.BillFirmaID
			/// </summary>
			[AssociationAttribute(Name="FK_tblAppMember_tblBillFirma", Storage="_tblAppMemberList", ThisKey="BillFirmaID", OtherKey="BillFirmaID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<tblAppMember> tblAppMemberList
			{
				get { return this._tblAppMemberList; }
				set { this._tblAppMemberList.Assign(value); }
			}
			
			/// <summary>
			/// Association [PK][One]tblBillFirma.BillFirmaID --- [FK][Many]tblAppSchedule.BillFirmaID
			/// </summary>
			[AssociationAttribute(Name="FK_tblAppSchedule_tblBillFirma", Storage="_tblAppScheduleList", ThisKey="BillFirmaID", OtherKey="BillFirmaID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<tblAppSchedule> tblAppScheduleList
			{
				get { return this._tblAppScheduleList; }
				set { this._tblAppScheduleList.Assign(value); }
			}
			
			/// <summary>
			/// Association [PK][One]tblBillFirma.BillFirmaID --- [FK][Many]tblAppScheduleType.BillFirmaID
			/// </summary>
			[AssociationAttribute(Name="FK_tblAppScheduleType_tblBillFirma", Storage="_tblAppScheduleTypeList", ThisKey="BillFirmaID", OtherKey="BillFirmaID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<tblAppScheduleType> tblAppScheduleTypeList
			{
				get { return this._tblAppScheduleTypeList; }
				set { this._tblAppScheduleTypeList.Assign(value); }
			}
			
			/// <summary>
			/// Association [PK][One]tblBillFirma.BillFirmaID --- [FK][Many]tblBillClient.BillFirmaID
			/// </summary>
			[AssociationAttribute(Name="FK_tblBillClient_tblBillFirma", Storage="_tblBillClientList", ThisKey="BillFirmaID", OtherKey="BillFirmaID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<tblBillClient> tblBillClientList
			{
				get { return this._tblBillClientList; }
				set { this._tblBillClientList.Assign(value); }
			}
			
			/// <summary>
			/// Association [FK][Many]tblBillFirma.BillFirmaCertificateModeID --- [PK][One]tblBillFirmaCertificateMode.BillFirmaCertificateModeID
			/// </summary>
			[AssociationAttribute(Name="FK_tblBillFirma_tblBillFirmaCertificateMode", Storage="_tblBillFirmaCertificateMode", ThisKey="BillFirmaCertificateModeID", OtherKey="BillFirmaCertificateModeID", IsUnique=false, IsForeignKey=true)]
			public tblBillFirmaCertificateMode tblBillFirmaCertificateMode
			{
				get
				{
					return this._tblBillFirmaCertificateMode.Entity;
				}
				set
				{
					tblBillFirmaCertificateMode previousValue = this._tblBillFirmaCertificateMode.Entity;
					if ((previousValue != value) || (this._tblBillFirmaCertificateMode.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._tblBillFirmaCertificateMode.Entity = null;
							previousValue.tblBillFirmaList.Remove(this);
						}
						this._tblBillFirmaCertificateMode.Entity = value;
						if (value != null)
						{
							value.tblBillFirmaList.Add(this);
							this._BillFirmaCertificateModeID = value.BillFirmaCertificateModeID;
						}
						else
						{
							this._BillFirmaCertificateModeID = default(int);
						}
						this.SendPropertyChanged("tblBillFirmaCertificateMode");
					}
					this.SendPropertySetterInvoked("tblBillFirmaCertificateMode", value);
				}
			}
			
			/// <summary>
			/// Association [PK][One]tblBillFirma.BillFirmaID --- [FK][Many]tblBillFirmaCertificate.BillFirmaID
			/// </summary>
			[AssociationAttribute(Name="FK_tblBillFirmaCertificate_tblBillFirma", Storage="_tblBillFirmaCertificateList", ThisKey="BillFirmaID", OtherKey="BillFirmaID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<tblBillFirmaCertificate> tblBillFirmaCertificateList
			{
				get { return this._tblBillFirmaCertificateList; }
				set { this._tblBillFirmaCertificateList.Assign(value); }
			}
			
			/// <summary>
			/// Association [PK][One]tblBillFirma.BillFirmaID --- [FK][Many]tblBillFirmaPos.BillFirmaID
			/// </summary>
			[AssociationAttribute(Name="FK_tblBillFirmaPos_tblBillFirma", Storage="_tblBillFirmaPosList", ThisKey="BillFirmaID", OtherKey="BillFirmaID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<tblBillFirmaPos> tblBillFirmaPosList
			{
				get { return this._tblBillFirmaPosList; }
				set { this._tblBillFirmaPosList.Assign(value); }
			}
			
			/// <summary>
			/// Association [PK][One]tblBillFirma.BillFirmaID --- [FK][Many]tblBillFirmaTransakcijskiRacun.BillFirmaID
			/// </summary>
			[AssociationAttribute(Name="FK_tblBillFirmaTransakcijskiRacun_tblBillFirma", Storage="_tblBillFirmaTransakcijskiRacunList", ThisKey="BillFirmaID", OtherKey="BillFirmaID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<tblBillFirmaTransakcijskiRacun> tblBillFirmaTransakcijskiRacunList
			{
				get { return this._tblBillFirmaTransakcijskiRacunList; }
				set { this._tblBillFirmaTransakcijskiRacunList.Assign(value); }
			}
			
			/// <summary>
			/// Association [PK][One]tblBillFirma.BillFirmaID --- [FK][Many]tblBillPoslovniProstor.BillFirmaID
			/// </summary>
			[AssociationAttribute(Name="FK_tblBillPoslovniProstor_tblBillFirma", Storage="_tblBillPoslovniProstorList", ThisKey="BillFirmaID", OtherKey="BillFirmaID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<tblBillPoslovniProstor> tblBillPoslovniProstorList
			{
				get { return this._tblBillPoslovniProstorList; }
				set { this._tblBillPoslovniProstorList.Assign(value); }
			}
			
			/// <summary>
			/// Association [PK][One]tblBillFirma.BillFirmaID --- [FK][Many]tblBookkeepingFiduciaExport.BillFirmaID
			/// </summary>
			[AssociationAttribute(Name="FK_tblBookkeepinglFiduciaExport_tblBillFirma", Storage="_tblBookkeepingFiduciaExportList", ThisKey="BillFirmaID", OtherKey="BillFirmaID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<tblBookkeepingFiduciaExport> tblBookkeepingFiduciaExportList
			{
				get { return this._tblBookkeepingFiduciaExportList; }
				set { this._tblBookkeepingFiduciaExportList.Assign(value); }
			}
			
			/// <summary>
			/// Association [PK][One]tblBillFirma.BillFirmaID --- [FK][Many]tblBookkeepingSynesisExport.BillFirmaID
			/// </summary>
			[AssociationAttribute(Name="FK_tblBookkeepingSynesisExport_tblBillFirma", Storage="_tblBookkeepingSynesisExportList", ThisKey="BillFirmaID", OtherKey="BillFirmaID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<tblBookkeepingSynesisExport> tblBookkeepingSynesisExportList
			{
				get { return this._tblBookkeepingSynesisExportList; }
				set { this._tblBookkeepingSynesisExportList.Assign(value); }
			}
			
			/// <summary>
			/// Association [PK][One]tblBillFirma.BillFirmaID --- [FK][Many]tblDirClientBlacklist.BillFirmaID
			/// </summary>
			[AssociationAttribute(Name="FK_tblDirClientBlacklist_tblBillFirma", Storage="_tblDirClientBlacklistList", ThisKey="BillFirmaID", OtherKey="BillFirmaID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<tblDirClientBlacklist> tblDirClientBlacklistList
			{
				get { return this._tblDirClientBlacklistList; }
				set { this._tblDirClientBlacklistList.Assign(value); }
			}
			
			/// <summary>
			/// Association [PK][One]tblBillFirma.BillFirmaID --- [FK][Many]tblDirClientVracenaPosta.BillFirmaID
			/// </summary>
			[AssociationAttribute(Name="FK_tblDirClientVracenaPosta_tblBillFirma", Storage="_tblDirClientVracenaPostaList", ThisKey="BillFirmaID", OtherKey="BillFirmaID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<tblDirClientVracenaPosta> tblDirClientVracenaPostaList
			{
				get { return this._tblDirClientVracenaPostaList; }
				set { this._tblDirClientVracenaPostaList.Assign(value); }
			}
			
			/// <summary>
			/// Association [PK][One]tblBillFirma.BillFirmaID --- [FK][Many]tblJobAdvert.BillFirmaID
			/// </summary>
			[AssociationAttribute(Name="FK_tblJobAdvert_tblBillFirma", Storage="_tblJobAdvertList", ThisKey="BillFirmaID", OtherKey="BillFirmaID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<tblJobAdvert> tblJobAdvertList
			{
				get { return this._tblJobAdvertList; }
				set { this._tblJobAdvertList.Assign(value); }
			}
			
			/// <summary>
			/// Association [PK][One]tblBillFirma.BillFirmaID --- [FK][Many]tblJobTemplate.BillFirmaID
			/// </summary>
			[AssociationAttribute(Name="FK_tblJobTemplate_tblBillFirma", Storage="_tblJobTemplateList", ThisKey="BillFirmaID", OtherKey="BillFirmaID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<tblJobTemplate> tblJobTemplateList
			{
				get { return this._tblJobTemplateList; }
				set { this._tblJobTemplateList.Assign(value); }
			}
			
			/// <summary>
			/// Association [PK][One]tblBillFirma.BillFirmaID --- [FK][Many]tblPozivLog.BillFirmaID
			/// </summary>
			[AssociationAttribute(Name="FK_tblPozivLog_tblBillFirma", Storage="_tblPozivLogList", ThisKey="BillFirmaID", OtherKey="BillFirmaID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<tblPozivLog> tblPozivLogList
			{
				get { return this._tblPozivLogList; }
				set { this._tblPozivLogList.Assign(value); }
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
		#endregion dbo.tblBillFirma

		#region dbo.tblBillFirmaCertificate
		[TableAttribute(Name="dbo.tblBillFirmaCertificate")]
		public partial class tblBillFirmaCertificate : EntityBase<tblBillFirmaCertificate, dbArizonaAppDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private int _BillFirmaCertificateID;
			private int _BillFirmaID;
			private DateTime _InsertionDate;
			private string _CertSerial;
			private byte[] _CertData1;
			private byte[] _CertData2;
			private string _CertIssuer;
			private string _CertSubject;
			private DateTime? _NotBefore;
			private DateTime? _NotAfter;
			private int? _BillFirmaCertificateModeID;
			private EntityRef<tblBillFirma> _tblBillFirma;
			private EntityRef<tblBillFirmaCertificateMode> _tblBillFirmaCertificateMode;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnBillFirmaCertificateIDChanging(int value);
			partial void OnBillFirmaCertificateIDChanged();
			partial void OnBillFirmaIDChanging(int value);
			partial void OnBillFirmaIDChanged();
			partial void OnInsertionDateChanging(DateTime value);
			partial void OnInsertionDateChanged();
			partial void OnCertSerialChanging(string value);
			partial void OnCertSerialChanged();
			partial void OnCertData1Changing(byte[] value);
			partial void OnCertData1Changed();
			partial void OnCertData2Changing(byte[] value);
			partial void OnCertData2Changed();
			partial void OnCertIssuerChanging(string value);
			partial void OnCertIssuerChanged();
			partial void OnCertSubjectChanging(string value);
			partial void OnCertSubjectChanged();
			partial void OnNotBeforeChanging(DateTime? value);
			partial void OnNotBeforeChanged();
			partial void OnNotAfterChanging(DateTime? value);
			partial void OnNotAfterChanged();
			partial void OnBillFirmaCertificateModeIDChanging(int? value);
			partial void OnBillFirmaCertificateModeIDChanged();
			#endregion

			public tblBillFirmaCertificate()
			{
				_tblBillFirma = default(EntityRef<tblBillFirma>);
				_tblBillFirmaCertificateMode = default(EntityRef<tblBillFirmaCertificateMode>);
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=Int NOT NULL IDENTITY
			/// </summary>
			[ColumnAttribute(Storage="_BillFirmaCertificateID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", CanBeNull=false, IsPrimaryKey=true, IsDbGenerated=true)]
			public int BillFirmaCertificateID
			{
				get
				{
					return this._BillFirmaCertificateID;
				}
				set
				{
					if (this._BillFirmaCertificateID != value)
					{
						this.OnBillFirmaCertificateIDChanging(value);
						this.SendPropertyChanging();
						this._BillFirmaCertificateID = value;
						this.SendPropertyChanged("BillFirmaCertificateID");
						this.OnBillFirmaCertificateIDChanged();
					}
					this.SendPropertySetterInvoked("BillFirmaCertificateID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_BillFirmaID", DbType="Int NOT NULL", CanBeNull=false)]
			public int BillFirmaID
			{
				get
				{
					return this._BillFirmaID;
				}
				set
				{
					if (this._BillFirmaID != value)
					{
						this.OnBillFirmaIDChanging(value);
						this.SendPropertyChanging();
						this._BillFirmaID = value;
						this.SendPropertyChanged("BillFirmaID");
						this.OnBillFirmaIDChanged();
					}
					this.SendPropertySetterInvoked("BillFirmaID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_InsertionDate", DbType="DateTime NOT NULL", CanBeNull=false)]
			public DateTime InsertionDate
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
			/// Column DbType=VarChar(100) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_CertSerial", DbType="VarChar(100) NOT NULL", CanBeNull=false)]
			public string CertSerial
			{
				get
				{
					return this._CertSerial;
				}
				set
				{
					if (this._CertSerial != value)
					{
						this.OnCertSerialChanging(value);
						this.SendPropertyChanging();
						this._CertSerial = value;
						this.SendPropertyChanged("CertSerial");
						this.OnCertSerialChanged();
					}
					this.SendPropertySetterInvoked("CertSerial", value);
				}
			}
			
			/// <summary>
			/// Column DbType=VarBinary(MAX) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_CertData1", DbType="VarBinary(MAX) NOT NULL", CanBeNull=false)]
			public byte[] CertData1
			{
				get
				{
					return this._CertData1;
				}
				set
				{
					if (this._CertData1 != value)
					{
						this.OnCertData1Changing(value);
						this.SendPropertyChanging();
						this._CertData1 = value;
						this.SendPropertyChanged("CertData1");
						this.OnCertData1Changed();
					}
					this.SendPropertySetterInvoked("CertData1", value);
				}
			}
			
			/// <summary>
			/// Column DbType=VarBinary(MAX) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_CertData2", DbType="VarBinary(MAX) NOT NULL", CanBeNull=false)]
			public byte[] CertData2
			{
				get
				{
					return this._CertData2;
				}
				set
				{
					if (this._CertData2 != value)
					{
						this.OnCertData2Changing(value);
						this.SendPropertyChanging();
						this._CertData2 = value;
						this.SendPropertyChanged("CertData2");
						this.OnCertData2Changed();
					}
					this.SendPropertySetterInvoked("CertData2", value);
				}
			}
			
			/// <summary>
			/// Column DbType=VarChar(255)
			/// </summary>
			[ColumnAttribute(Storage="_CertIssuer", DbType="VarChar(255)", CanBeNull=true)]
			public string CertIssuer
			{
				get
				{
					return this._CertIssuer;
				}
				set
				{
					if (this._CertIssuer != value)
					{
						this.OnCertIssuerChanging(value);
						this.SendPropertyChanging();
						this._CertIssuer = value;
						this.SendPropertyChanged("CertIssuer");
						this.OnCertIssuerChanged();
					}
					this.SendPropertySetterInvoked("CertIssuer", value);
				}
			}
			
			/// <summary>
			/// Column DbType=VarChar(255)
			/// </summary>
			[ColumnAttribute(Storage="_CertSubject", DbType="VarChar(255)", CanBeNull=true)]
			public string CertSubject
			{
				get
				{
					return this._CertSubject;
				}
				set
				{
					if (this._CertSubject != value)
					{
						this.OnCertSubjectChanging(value);
						this.SendPropertyChanging();
						this._CertSubject = value;
						this.SendPropertyChanged("CertSubject");
						this.OnCertSubjectChanged();
					}
					this.SendPropertySetterInvoked("CertSubject", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime
			/// </summary>
			[ColumnAttribute(Storage="_NotBefore", DbType="DateTime", CanBeNull=true)]
			public DateTime? NotBefore
			{
				get
				{
					return this._NotBefore;
				}
				set
				{
					if (this._NotBefore != value)
					{
						this.OnNotBeforeChanging(value);
						this.SendPropertyChanging();
						this._NotBefore = value;
						this.SendPropertyChanged("NotBefore");
						this.OnNotBeforeChanged();
					}
					this.SendPropertySetterInvoked("NotBefore", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime
			/// </summary>
			[ColumnAttribute(Storage="_NotAfter", DbType="DateTime", CanBeNull=true)]
			public DateTime? NotAfter
			{
				get
				{
					return this._NotAfter;
				}
				set
				{
					if (this._NotAfter != value)
					{
						this.OnNotAfterChanging(value);
						this.SendPropertyChanging();
						this._NotAfter = value;
						this.SendPropertyChanged("NotAfter");
						this.OnNotAfterChanged();
					}
					this.SendPropertySetterInvoked("NotAfter", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int
			/// </summary>
			[ColumnAttribute(Storage="_BillFirmaCertificateModeID", DbType="Int", CanBeNull=true)]
			public int? BillFirmaCertificateModeID
			{
				get
				{
					return this._BillFirmaCertificateModeID;
				}
				set
				{
					if (this._BillFirmaCertificateModeID != value)
					{
						this.OnBillFirmaCertificateModeIDChanging(value);
						this.SendPropertyChanging();
						this._BillFirmaCertificateModeID = value;
						this.SendPropertyChanged("BillFirmaCertificateModeID");
						this.OnBillFirmaCertificateModeIDChanged();
					}
					this.SendPropertySetterInvoked("BillFirmaCertificateModeID", value);
				}
			}
			
			#endregion Columns

			#region Associations
			/// <summary>
			/// Association [FK][Many]tblBillFirmaCertificate.BillFirmaID --- [PK][One]tblBillFirma.BillFirmaID
			/// </summary>
			[AssociationAttribute(Name="FK_tblBillFirmaCertificate_tblBillFirma", Storage="_tblBillFirma", ThisKey="BillFirmaID", OtherKey="BillFirmaID", IsUnique=false, IsForeignKey=true)]
			public tblBillFirma tblBillFirma
			{
				get
				{
					return this._tblBillFirma.Entity;
				}
				set
				{
					tblBillFirma previousValue = this._tblBillFirma.Entity;
					if ((previousValue != value) || (this._tblBillFirma.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._tblBillFirma.Entity = null;
							previousValue.tblBillFirmaCertificateList.Remove(this);
						}
						this._tblBillFirma.Entity = value;
						if (value != null)
						{
							value.tblBillFirmaCertificateList.Add(this);
							this._BillFirmaID = value.BillFirmaID;
						}
						else
						{
							this._BillFirmaID = default(int);
						}
						this.SendPropertyChanged("tblBillFirma");
					}
					this.SendPropertySetterInvoked("tblBillFirma", value);
				}
			}
			
			/// <summary>
			/// Association [FK][Many]tblBillFirmaCertificate.BillFirmaCertificateModeID --- [PK][One]tblBillFirmaCertificateMode.BillFirmaCertificateModeID
			/// </summary>
			[AssociationAttribute(Name="FK_tblBillFirmaCertificate_tblBillFirmaCertificateMode", Storage="_tblBillFirmaCertificateMode", ThisKey="BillFirmaCertificateModeID", OtherKey="BillFirmaCertificateModeID", IsUnique=false, IsForeignKey=true)]
			public tblBillFirmaCertificateMode tblBillFirmaCertificateMode
			{
				get
				{
					return this._tblBillFirmaCertificateMode.Entity;
				}
				set
				{
					tblBillFirmaCertificateMode previousValue = this._tblBillFirmaCertificateMode.Entity;
					if ((previousValue != value) || (this._tblBillFirmaCertificateMode.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._tblBillFirmaCertificateMode.Entity = null;
							previousValue.tblBillFirmaCertificateList.Remove(this);
						}
						this._tblBillFirmaCertificateMode.Entity = value;
						if (value != null)
						{
							value.tblBillFirmaCertificateList.Add(this);
							this._BillFirmaCertificateModeID = value.BillFirmaCertificateModeID;
						}
						else
						{
							this._BillFirmaCertificateModeID = default(int?);
						}
						this.SendPropertyChanged("tblBillFirmaCertificateMode");
					}
					this.SendPropertySetterInvoked("tblBillFirmaCertificateMode", value);
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
		#endregion dbo.tblBillFirmaCertificate

		#region dbo.tblBillFirmaCertificateMode
		[TableAttribute(Name="dbo.tblBillFirmaCertificateMode")]
		public partial class tblBillFirmaCertificateMode : EntityBase<tblBillFirmaCertificateMode, dbArizonaAppDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private int _BillFirmaCertificateModeID;
			private string _Name;
			private EntitySet<tblBillFirma> _tblBillFirmaList;
			private EntitySet<tblBillFirmaCertificate> _tblBillFirmaCertificateList;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnBillFirmaCertificateModeIDChanging(int value);
			partial void OnBillFirmaCertificateModeIDChanged();
			partial void OnNameChanging(string value);
			partial void OnNameChanged();
			#endregion

			public tblBillFirmaCertificateMode()
			{
				_tblBillFirmaList = new EntitySet<tblBillFirma>(
					new Action<tblBillFirma>(item=>{this.SendPropertyChanging(); item.tblBillFirmaCertificateMode=this;}), 
					new Action<tblBillFirma>(item=>{this.SendPropertyChanging(); item.tblBillFirmaCertificateMode=null;}));
				_tblBillFirmaCertificateList = new EntitySet<tblBillFirmaCertificate>(
					new Action<tblBillFirmaCertificate>(item=>{this.SendPropertyChanging(); item.tblBillFirmaCertificateMode=this;}), 
					new Action<tblBillFirmaCertificate>(item=>{this.SendPropertyChanging(); item.tblBillFirmaCertificateMode=null;}));
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_BillFirmaCertificateModeID", DbType="Int NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
			public int BillFirmaCertificateModeID
			{
				get
				{
					return this._BillFirmaCertificateModeID;
				}
				set
				{
					if (this._BillFirmaCertificateModeID != value)
					{
						this.OnBillFirmaCertificateModeIDChanging(value);
						this.SendPropertyChanging();
						this._BillFirmaCertificateModeID = value;
						this.SendPropertyChanged("BillFirmaCertificateModeID");
						this.OnBillFirmaCertificateModeIDChanged();
					}
					this.SendPropertySetterInvoked("BillFirmaCertificateModeID", value);
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
			
			#endregion Columns

			#region Associations
			/// <summary>
			/// Association [PK][One]tblBillFirmaCertificateMode.BillFirmaCertificateModeID --- [FK][Many]tblBillFirma.BillFirmaCertificateModeID
			/// </summary>
			[AssociationAttribute(Name="FK_tblBillFirma_tblBillFirmaCertificateMode", Storage="_tblBillFirmaList", ThisKey="BillFirmaCertificateModeID", OtherKey="BillFirmaCertificateModeID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<tblBillFirma> tblBillFirmaList
			{
				get { return this._tblBillFirmaList; }
				set { this._tblBillFirmaList.Assign(value); }
			}
			
			/// <summary>
			/// Association [PK][One]tblBillFirmaCertificateMode.BillFirmaCertificateModeID --- [FK][Many]tblBillFirmaCertificate.BillFirmaCertificateModeID
			/// </summary>
			[AssociationAttribute(Name="FK_tblBillFirmaCertificate_tblBillFirmaCertificateMode", Storage="_tblBillFirmaCertificateList", ThisKey="BillFirmaCertificateModeID", OtherKey="BillFirmaCertificateModeID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<tblBillFirmaCertificate> tblBillFirmaCertificateList
			{
				get { return this._tblBillFirmaCertificateList; }
				set { this._tblBillFirmaCertificateList.Assign(value); }
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
		#endregion dbo.tblBillFirmaCertificateMode

		#region dbo.tblBillFirmaPos
		[TableAttribute(Name="dbo.tblBillFirmaPos")]
		public partial class tblBillFirmaPos : EntityBase<tblBillFirmaPos, dbArizonaAppDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private long _BillFirmaPosID;
			private int _BillFirmaID;
			private long? _ReferenceBillDocumentID;
			private DateTime _StartDate;
			private DateTime _EndDate;
			private bool _IsActive;
			private int _PoslovniProstoriMax;
			private int _NaplatniUredjajiMax;
			private int _DocumentsMax;
			private int _DocumentsCount;
			private int _CategoriesMax;
			private int _ProductsMax;
			private int _PorezneGrupeMax;
			private int _OperatoriMax;
			private EntityRef<tblBillFirma> _tblBillFirma;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnBillFirmaPosIDChanging(long value);
			partial void OnBillFirmaPosIDChanged();
			partial void OnBillFirmaIDChanging(int value);
			partial void OnBillFirmaIDChanged();
			partial void OnReferenceBillDocumentIDChanging(long? value);
			partial void OnReferenceBillDocumentIDChanged();
			partial void OnStartDateChanging(DateTime value);
			partial void OnStartDateChanged();
			partial void OnEndDateChanging(DateTime value);
			partial void OnEndDateChanged();
			partial void OnIsActiveChanging(bool value);
			partial void OnIsActiveChanged();
			partial void OnPoslovniProstoriMaxChanging(int value);
			partial void OnPoslovniProstoriMaxChanged();
			partial void OnNaplatniUredjajiMaxChanging(int value);
			partial void OnNaplatniUredjajiMaxChanged();
			partial void OnDocumentsMaxChanging(int value);
			partial void OnDocumentsMaxChanged();
			partial void OnDocumentsCountChanging(int value);
			partial void OnDocumentsCountChanged();
			partial void OnCategoriesMaxChanging(int value);
			partial void OnCategoriesMaxChanged();
			partial void OnProductsMaxChanging(int value);
			partial void OnProductsMaxChanged();
			partial void OnPorezneGrupeMaxChanging(int value);
			partial void OnPorezneGrupeMaxChanged();
			partial void OnOperatoriMaxChanging(int value);
			partial void OnOperatoriMaxChanged();
			#endregion

			public tblBillFirmaPos()
			{
				_tblBillFirma = default(EntityRef<tblBillFirma>);
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=BigInt NOT NULL IDENTITY
			/// </summary>
			[ColumnAttribute(Storage="_BillFirmaPosID", AutoSync=AutoSync.OnInsert, DbType="BigInt NOT NULL IDENTITY", CanBeNull=false, IsPrimaryKey=true, IsDbGenerated=true)]
			public long BillFirmaPosID
			{
				get
				{
					return this._BillFirmaPosID;
				}
				set
				{
					if (this._BillFirmaPosID != value)
					{
						this.OnBillFirmaPosIDChanging(value);
						this.SendPropertyChanging();
						this._BillFirmaPosID = value;
						this.SendPropertyChanged("BillFirmaPosID");
						this.OnBillFirmaPosIDChanged();
					}
					this.SendPropertySetterInvoked("BillFirmaPosID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_BillFirmaID", DbType="Int NOT NULL", CanBeNull=false)]
			public int BillFirmaID
			{
				get
				{
					return this._BillFirmaID;
				}
				set
				{
					if (this._BillFirmaID != value)
					{
						this.OnBillFirmaIDChanging(value);
						this.SendPropertyChanging();
						this._BillFirmaID = value;
						this.SendPropertyChanged("BillFirmaID");
						this.OnBillFirmaIDChanged();
					}
					this.SendPropertySetterInvoked("BillFirmaID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=BigInt
			/// </summary>
			[ColumnAttribute(Storage="_ReferenceBillDocumentID", DbType="BigInt", CanBeNull=true)]
			public long? ReferenceBillDocumentID
			{
				get
				{
					return this._ReferenceBillDocumentID;
				}
				set
				{
					if (this._ReferenceBillDocumentID != value)
					{
						this.OnReferenceBillDocumentIDChanging(value);
						this.SendPropertyChanging();
						this._ReferenceBillDocumentID = value;
						this.SendPropertyChanged("ReferenceBillDocumentID");
						this.OnReferenceBillDocumentIDChanged();
					}
					this.SendPropertySetterInvoked("ReferenceBillDocumentID", value);
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
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_PoslovniProstoriMax", DbType="Int NOT NULL", CanBeNull=false)]
			public int PoslovniProstoriMax
			{
				get
				{
					return this._PoslovniProstoriMax;
				}
				set
				{
					if (this._PoslovniProstoriMax != value)
					{
						this.OnPoslovniProstoriMaxChanging(value);
						this.SendPropertyChanging();
						this._PoslovniProstoriMax = value;
						this.SendPropertyChanged("PoslovniProstoriMax");
						this.OnPoslovniProstoriMaxChanged();
					}
					this.SendPropertySetterInvoked("PoslovniProstoriMax", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_NaplatniUredjajiMax", DbType="Int NOT NULL", CanBeNull=false)]
			public int NaplatniUredjajiMax
			{
				get
				{
					return this._NaplatniUredjajiMax;
				}
				set
				{
					if (this._NaplatniUredjajiMax != value)
					{
						this.OnNaplatniUredjajiMaxChanging(value);
						this.SendPropertyChanging();
						this._NaplatniUredjajiMax = value;
						this.SendPropertyChanged("NaplatniUredjajiMax");
						this.OnNaplatniUredjajiMaxChanged();
					}
					this.SendPropertySetterInvoked("NaplatniUredjajiMax", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_DocumentsMax", DbType="Int NOT NULL", CanBeNull=false)]
			public int DocumentsMax
			{
				get
				{
					return this._DocumentsMax;
				}
				set
				{
					if (this._DocumentsMax != value)
					{
						this.OnDocumentsMaxChanging(value);
						this.SendPropertyChanging();
						this._DocumentsMax = value;
						this.SendPropertyChanged("DocumentsMax");
						this.OnDocumentsMaxChanged();
					}
					this.SendPropertySetterInvoked("DocumentsMax", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_DocumentsCount", DbType="Int NOT NULL", CanBeNull=false)]
			public int DocumentsCount
			{
				get
				{
					return this._DocumentsCount;
				}
				set
				{
					if (this._DocumentsCount != value)
					{
						this.OnDocumentsCountChanging(value);
						this.SendPropertyChanging();
						this._DocumentsCount = value;
						this.SendPropertyChanged("DocumentsCount");
						this.OnDocumentsCountChanged();
					}
					this.SendPropertySetterInvoked("DocumentsCount", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_CategoriesMax", DbType="Int NOT NULL", CanBeNull=false)]
			public int CategoriesMax
			{
				get
				{
					return this._CategoriesMax;
				}
				set
				{
					if (this._CategoriesMax != value)
					{
						this.OnCategoriesMaxChanging(value);
						this.SendPropertyChanging();
						this._CategoriesMax = value;
						this.SendPropertyChanged("CategoriesMax");
						this.OnCategoriesMaxChanged();
					}
					this.SendPropertySetterInvoked("CategoriesMax", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ProductsMax", DbType="Int NOT NULL", CanBeNull=false)]
			public int ProductsMax
			{
				get
				{
					return this._ProductsMax;
				}
				set
				{
					if (this._ProductsMax != value)
					{
						this.OnProductsMaxChanging(value);
						this.SendPropertyChanging();
						this._ProductsMax = value;
						this.SendPropertyChanged("ProductsMax");
						this.OnProductsMaxChanged();
					}
					this.SendPropertySetterInvoked("ProductsMax", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_PorezneGrupeMax", DbType="Int NOT NULL", CanBeNull=false)]
			public int PorezneGrupeMax
			{
				get
				{
					return this._PorezneGrupeMax;
				}
				set
				{
					if (this._PorezneGrupeMax != value)
					{
						this.OnPorezneGrupeMaxChanging(value);
						this.SendPropertyChanging();
						this._PorezneGrupeMax = value;
						this.SendPropertyChanged("PorezneGrupeMax");
						this.OnPorezneGrupeMaxChanged();
					}
					this.SendPropertySetterInvoked("PorezneGrupeMax", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_OperatoriMax", DbType="Int NOT NULL", CanBeNull=false)]
			public int OperatoriMax
			{
				get
				{
					return this._OperatoriMax;
				}
				set
				{
					if (this._OperatoriMax != value)
					{
						this.OnOperatoriMaxChanging(value);
						this.SendPropertyChanging();
						this._OperatoriMax = value;
						this.SendPropertyChanged("OperatoriMax");
						this.OnOperatoriMaxChanged();
					}
					this.SendPropertySetterInvoked("OperatoriMax", value);
				}
			}
			
			#endregion Columns

			#region Associations
			/// <summary>
			/// Association [FK][Many]tblBillFirmaPos.BillFirmaID --- [PK][One]tblBillFirma.BillFirmaID
			/// </summary>
			[AssociationAttribute(Name="FK_tblBillFirmaPos_tblBillFirma", Storage="_tblBillFirma", ThisKey="BillFirmaID", OtherKey="BillFirmaID", IsUnique=false, IsForeignKey=true)]
			public tblBillFirma tblBillFirma
			{
				get
				{
					return this._tblBillFirma.Entity;
				}
				set
				{
					tblBillFirma previousValue = this._tblBillFirma.Entity;
					if ((previousValue != value) || (this._tblBillFirma.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._tblBillFirma.Entity = null;
							previousValue.tblBillFirmaPosList.Remove(this);
						}
						this._tblBillFirma.Entity = value;
						if (value != null)
						{
							value.tblBillFirmaPosList.Add(this);
							this._BillFirmaID = value.BillFirmaID;
						}
						else
						{
							this._BillFirmaID = default(int);
						}
						this.SendPropertyChanged("tblBillFirma");
					}
					this.SendPropertySetterInvoked("tblBillFirma", value);
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
		#endregion dbo.tblBillFirmaPos

		#region dbo.tblBillFirmaTransakcijskiRacun
		[TableAttribute(Name="dbo.tblBillFirmaTransakcijskiRacun")]
		public partial class tblBillFirmaTransakcijskiRacun : EntityBase<tblBillFirmaTransakcijskiRacun, dbArizonaAppDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private int _BillFirmaTransakcijskiRacunID;
			private int _BankaID;
			private bool _IsPersonalAccount;
			private int _BillFirmaID;
			private string _IBAN;
			private string _Valuta;
			private string _Naziv;
			private bool _VidljivNaPonudama;
			private int? _BillFirmaTransakcijskiRacunEmailID;
			private EntitySet<tblBankaPromet> _tblBankaPrometList;
			private EntityRef<tblBanka> _tblBanka;
			private EntityRef<tblBillFirma> _tblBillFirma;
			private EntityRef<tblBillFirmaTransakcijskiRacunEmail> _tblBillFirmaTransakcijskiRacunEmail;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnBillFirmaTransakcijskiRacunIDChanging(int value);
			partial void OnBillFirmaTransakcijskiRacunIDChanged();
			partial void OnBankaIDChanging(int value);
			partial void OnBankaIDChanged();
			partial void OnIsPersonalAccountChanging(bool value);
			partial void OnIsPersonalAccountChanged();
			partial void OnBillFirmaIDChanging(int value);
			partial void OnBillFirmaIDChanged();
			partial void OnIBANChanging(string value);
			partial void OnIBANChanged();
			partial void OnValutaChanging(string value);
			partial void OnValutaChanged();
			partial void OnNazivChanging(string value);
			partial void OnNazivChanged();
			partial void OnVidljivNaPonudamaChanging(bool value);
			partial void OnVidljivNaPonudamaChanged();
			partial void OnBillFirmaTransakcijskiRacunEmailIDChanging(int? value);
			partial void OnBillFirmaTransakcijskiRacunEmailIDChanged();
			#endregion

			public tblBillFirmaTransakcijskiRacun()
			{
				_tblBankaPrometList = new EntitySet<tblBankaPromet>(
					new Action<tblBankaPromet>(item=>{this.SendPropertyChanging(); item.tblBillFirmaTransakcijskiRacun=this;}), 
					new Action<tblBankaPromet>(item=>{this.SendPropertyChanging(); item.tblBillFirmaTransakcijskiRacun=null;}));
				_tblBanka = default(EntityRef<tblBanka>);
				_tblBillFirma = default(EntityRef<tblBillFirma>);
				_tblBillFirmaTransakcijskiRacunEmail = default(EntityRef<tblBillFirmaTransakcijskiRacunEmail>);
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=Int NOT NULL IDENTITY
			/// </summary>
			[ColumnAttribute(Storage="_BillFirmaTransakcijskiRacunID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", CanBeNull=false, IsPrimaryKey=true, IsDbGenerated=true)]
			public int BillFirmaTransakcijskiRacunID
			{
				get
				{
					return this._BillFirmaTransakcijskiRacunID;
				}
				set
				{
					if (this._BillFirmaTransakcijskiRacunID != value)
					{
						this.OnBillFirmaTransakcijskiRacunIDChanging(value);
						this.SendPropertyChanging();
						this._BillFirmaTransakcijskiRacunID = value;
						this.SendPropertyChanged("BillFirmaTransakcijskiRacunID");
						this.OnBillFirmaTransakcijskiRacunIDChanged();
					}
					this.SendPropertySetterInvoked("BillFirmaTransakcijskiRacunID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_BankaID", DbType="Int NOT NULL", CanBeNull=false)]
			public int BankaID
			{
				get
				{
					return this._BankaID;
				}
				set
				{
					if (this._BankaID != value)
					{
						this.OnBankaIDChanging(value);
						this.SendPropertyChanging();
						this._BankaID = value;
						this.SendPropertyChanged("BankaID");
						this.OnBankaIDChanged();
					}
					this.SendPropertySetterInvoked("BankaID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Bit NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_IsPersonalAccount", DbType="Bit NOT NULL", CanBeNull=false)]
			public bool IsPersonalAccount
			{
				get
				{
					return this._IsPersonalAccount;
				}
				set
				{
					if (this._IsPersonalAccount != value)
					{
						this.OnIsPersonalAccountChanging(value);
						this.SendPropertyChanging();
						this._IsPersonalAccount = value;
						this.SendPropertyChanged("IsPersonalAccount");
						this.OnIsPersonalAccountChanged();
					}
					this.SendPropertySetterInvoked("IsPersonalAccount", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_BillFirmaID", DbType="Int NOT NULL", CanBeNull=false)]
			public int BillFirmaID
			{
				get
				{
					return this._BillFirmaID;
				}
				set
				{
					if (this._BillFirmaID != value)
					{
						this.OnBillFirmaIDChanging(value);
						this.SendPropertyChanging();
						this._BillFirmaID = value;
						this.SendPropertyChanged("BillFirmaID");
						this.OnBillFirmaIDChanged();
					}
					this.SendPropertySetterInvoked("BillFirmaID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=VarChar(50) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_IBAN", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
			public string IBAN
			{
				get
				{
					return this._IBAN;
				}
				set
				{
					if (this._IBAN != value)
					{
						this.OnIBANChanging(value);
						this.SendPropertyChanging();
						this._IBAN = value;
						this.SendPropertyChanged("IBAN");
						this.OnIBANChanged();
					}
					this.SendPropertySetterInvoked("IBAN", value);
				}
			}
			
			/// <summary>
			/// Column DbType=VarChar(10)
			/// </summary>
			[ColumnAttribute(Storage="_Valuta", DbType="VarChar(10)", CanBeNull=true)]
			public string Valuta
			{
				get
				{
					return this._Valuta;
				}
				set
				{
					if (this._Valuta != value)
					{
						this.OnValutaChanging(value);
						this.SendPropertyChanging();
						this._Valuta = value;
						this.SendPropertyChanged("Valuta");
						this.OnValutaChanged();
					}
					this.SendPropertySetterInvoked("Valuta", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(50)
			/// </summary>
			[ColumnAttribute(Storage="_Naziv", DbType="NVarChar(50)", CanBeNull=true)]
			public string Naziv
			{
				get
				{
					return this._Naziv;
				}
				set
				{
					if (this._Naziv != value)
					{
						this.OnNazivChanging(value);
						this.SendPropertyChanging();
						this._Naziv = value;
						this.SendPropertyChanged("Naziv");
						this.OnNazivChanged();
					}
					this.SendPropertySetterInvoked("Naziv", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Bit NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_VidljivNaPonudama", DbType="Bit NOT NULL", CanBeNull=false)]
			public bool VidljivNaPonudama
			{
				get
				{
					return this._VidljivNaPonudama;
				}
				set
				{
					if (this._VidljivNaPonudama != value)
					{
						this.OnVidljivNaPonudamaChanging(value);
						this.SendPropertyChanging();
						this._VidljivNaPonudama = value;
						this.SendPropertyChanged("VidljivNaPonudama");
						this.OnVidljivNaPonudamaChanged();
					}
					this.SendPropertySetterInvoked("VidljivNaPonudama", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int
			/// </summary>
			[ColumnAttribute(Storage="_BillFirmaTransakcijskiRacunEmailID", DbType="Int", CanBeNull=true)]
			public int? BillFirmaTransakcijskiRacunEmailID
			{
				get
				{
					return this._BillFirmaTransakcijskiRacunEmailID;
				}
				set
				{
					if (this._BillFirmaTransakcijskiRacunEmailID != value)
					{
						this.OnBillFirmaTransakcijskiRacunEmailIDChanging(value);
						this.SendPropertyChanging();
						this._BillFirmaTransakcijskiRacunEmailID = value;
						this.SendPropertyChanged("BillFirmaTransakcijskiRacunEmailID");
						this.OnBillFirmaTransakcijskiRacunEmailIDChanged();
					}
					this.SendPropertySetterInvoked("BillFirmaTransakcijskiRacunEmailID", value);
				}
			}
			
			#endregion Columns

			#region Associations
			/// <summary>
			/// Association [PK][One]tblBillFirmaTransakcijskiRacun.BillFirmaTransakcijskiRacunID --- [FK][Many]tblBankaPromet.BillFirmaTransakcijskiRacunID
			/// </summary>
			[AssociationAttribute(Name="FK_tblBankaPromet_tblBillFirmaTransakcijskiRacun", Storage="_tblBankaPrometList", ThisKey="BillFirmaTransakcijskiRacunID", OtherKey="BillFirmaTransakcijskiRacunID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<tblBankaPromet> tblBankaPrometList
			{
				get { return this._tblBankaPrometList; }
				set { this._tblBankaPrometList.Assign(value); }
			}
			
			/// <summary>
			/// Association [FK][Many]tblBillFirmaTransakcijskiRacun.BankaID --- [PK][One]tblBanka.BankaID
			/// </summary>
			[AssociationAttribute(Name="FK_tblBillFirmaTransakcijskiRacun_tblBanka", Storage="_tblBanka", ThisKey="BankaID", OtherKey="BankaID", IsUnique=false, IsForeignKey=true)]
			public tblBanka tblBanka
			{
				get
				{
					return this._tblBanka.Entity;
				}
				set
				{
					tblBanka previousValue = this._tblBanka.Entity;
					if ((previousValue != value) || (this._tblBanka.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._tblBanka.Entity = null;
							previousValue.tblBillFirmaTransakcijskiRacunList.Remove(this);
						}
						this._tblBanka.Entity = value;
						if (value != null)
						{
							value.tblBillFirmaTransakcijskiRacunList.Add(this);
							this._BankaID = value.BankaID;
						}
						else
						{
							this._BankaID = default(int);
						}
						this.SendPropertyChanged("tblBanka");
					}
					this.SendPropertySetterInvoked("tblBanka", value);
				}
			}
			
			/// <summary>
			/// Association [FK][Many]tblBillFirmaTransakcijskiRacun.BillFirmaID --- [PK][One]tblBillFirma.BillFirmaID
			/// </summary>
			[AssociationAttribute(Name="FK_tblBillFirmaTransakcijskiRacun_tblBillFirma", Storage="_tblBillFirma", ThisKey="BillFirmaID", OtherKey="BillFirmaID", IsUnique=false, IsForeignKey=true)]
			public tblBillFirma tblBillFirma
			{
				get
				{
					return this._tblBillFirma.Entity;
				}
				set
				{
					tblBillFirma previousValue = this._tblBillFirma.Entity;
					if ((previousValue != value) || (this._tblBillFirma.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._tblBillFirma.Entity = null;
							previousValue.tblBillFirmaTransakcijskiRacunList.Remove(this);
						}
						this._tblBillFirma.Entity = value;
						if (value != null)
						{
							value.tblBillFirmaTransakcijskiRacunList.Add(this);
							this._BillFirmaID = value.BillFirmaID;
						}
						else
						{
							this._BillFirmaID = default(int);
						}
						this.SendPropertyChanged("tblBillFirma");
					}
					this.SendPropertySetterInvoked("tblBillFirma", value);
				}
			}
			
			/// <summary>
			/// Association [FK][Many]tblBillFirmaTransakcijskiRacun.BillFirmaTransakcijskiRacunEmailID --- [PK][One]tblBillFirmaTransakcijskiRacunEmail.BillFirmaTransakcijskiRacunEmailID
			/// </summary>
			[AssociationAttribute(Name="FK_tblBillFirmaTransakcijskiRacun_tblBillFirmaTransakcijskiRacunEmail", Storage="_tblBillFirmaTransakcijskiRacunEmail", ThisKey="BillFirmaTransakcijskiRacunEmailID", OtherKey="BillFirmaTransakcijskiRacunEmailID", IsUnique=false, IsForeignKey=true)]
			public tblBillFirmaTransakcijskiRacunEmail tblBillFirmaTransakcijskiRacunEmail
			{
				get
				{
					return this._tblBillFirmaTransakcijskiRacunEmail.Entity;
				}
				set
				{
					tblBillFirmaTransakcijskiRacunEmail previousValue = this._tblBillFirmaTransakcijskiRacunEmail.Entity;
					if ((previousValue != value) || (this._tblBillFirmaTransakcijskiRacunEmail.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._tblBillFirmaTransakcijskiRacunEmail.Entity = null;
							previousValue.tblBillFirmaTransakcijskiRacunList.Remove(this);
						}
						this._tblBillFirmaTransakcijskiRacunEmail.Entity = value;
						if (value != null)
						{
							value.tblBillFirmaTransakcijskiRacunList.Add(this);
							this._BillFirmaTransakcijskiRacunEmailID = value.BillFirmaTransakcijskiRacunEmailID;
						}
						else
						{
							this._BillFirmaTransakcijskiRacunEmailID = default(int?);
						}
						this.SendPropertyChanged("tblBillFirmaTransakcijskiRacunEmail");
					}
					this.SendPropertySetterInvoked("tblBillFirmaTransakcijskiRacunEmail", value);
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
		#endregion dbo.tblBillFirmaTransakcijskiRacun

		#region dbo.tblBillFirmaTransakcijskiRacunEmail
		[TableAttribute(Name="dbo.tblBillFirmaTransakcijskiRacunEmail")]
		public partial class tblBillFirmaTransakcijskiRacunEmail : EntityBase<tblBillFirmaTransakcijskiRacunEmail, dbArizonaAppDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private int _BillFirmaTransakcijskiRacunEmailID;
			private string _Host;
			private string _User;
			private string _Pass;
			private int? _Port;
			private bool _UseSSL;
			private string _ReceivedEmailUIDLS;
			private EntitySet<tblBillFirmaTransakcijskiRacun> _tblBillFirmaTransakcijskiRacunList;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnBillFirmaTransakcijskiRacunEmailIDChanging(int value);
			partial void OnBillFirmaTransakcijskiRacunEmailIDChanged();
			partial void OnHostChanging(string value);
			partial void OnHostChanged();
			partial void OnUserChanging(string value);
			partial void OnUserChanged();
			partial void OnPassChanging(string value);
			partial void OnPassChanged();
			partial void OnPortChanging(int? value);
			partial void OnPortChanged();
			partial void OnUseSSLChanging(bool value);
			partial void OnUseSSLChanged();
			partial void OnReceivedEmailUIDLSChanging(string value);
			partial void OnReceivedEmailUIDLSChanged();
			#endregion

			public tblBillFirmaTransakcijskiRacunEmail()
			{
				_tblBillFirmaTransakcijskiRacunList = new EntitySet<tblBillFirmaTransakcijskiRacun>(
					new Action<tblBillFirmaTransakcijskiRacun>(item=>{this.SendPropertyChanging(); item.tblBillFirmaTransakcijskiRacunEmail=this;}), 
					new Action<tblBillFirmaTransakcijskiRacun>(item=>{this.SendPropertyChanging(); item.tblBillFirmaTransakcijskiRacunEmail=null;}));
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_BillFirmaTransakcijskiRacunEmailID", DbType="Int NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
			public int BillFirmaTransakcijskiRacunEmailID
			{
				get
				{
					return this._BillFirmaTransakcijskiRacunEmailID;
				}
				set
				{
					if (this._BillFirmaTransakcijskiRacunEmailID != value)
					{
						this.OnBillFirmaTransakcijskiRacunEmailIDChanging(value);
						this.SendPropertyChanging();
						this._BillFirmaTransakcijskiRacunEmailID = value;
						this.SendPropertyChanged("BillFirmaTransakcijskiRacunEmailID");
						this.OnBillFirmaTransakcijskiRacunEmailIDChanged();
					}
					this.SendPropertySetterInvoked("BillFirmaTransakcijskiRacunEmailID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(50)
			/// </summary>
			[ColumnAttribute(Storage="_Host", DbType="NVarChar(50)", CanBeNull=true)]
			public string Host
			{
				get
				{
					return this._Host;
				}
				set
				{
					if (this._Host != value)
					{
						this.OnHostChanging(value);
						this.SendPropertyChanging();
						this._Host = value;
						this.SendPropertyChanged("Host");
						this.OnHostChanged();
					}
					this.SendPropertySetterInvoked("Host", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(50)
			/// </summary>
			[ColumnAttribute(Storage="_User", DbType="NVarChar(50)", CanBeNull=true)]
			public string User
			{
				get
				{
					return this._User;
				}
				set
				{
					if (this._User != value)
					{
						this.OnUserChanging(value);
						this.SendPropertyChanging();
						this._User = value;
						this.SendPropertyChanged("User");
						this.OnUserChanged();
					}
					this.SendPropertySetterInvoked("User", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(50)
			/// </summary>
			[ColumnAttribute(Storage="_Pass", DbType="NVarChar(50)", CanBeNull=true)]
			public string Pass
			{
				get
				{
					return this._Pass;
				}
				set
				{
					if (this._Pass != value)
					{
						this.OnPassChanging(value);
						this.SendPropertyChanging();
						this._Pass = value;
						this.SendPropertyChanged("Pass");
						this.OnPassChanged();
					}
					this.SendPropertySetterInvoked("Pass", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int
			/// </summary>
			[ColumnAttribute(Storage="_Port", DbType="Int", CanBeNull=true)]
			public int? Port
			{
				get
				{
					return this._Port;
				}
				set
				{
					if (this._Port != value)
					{
						this.OnPortChanging(value);
						this.SendPropertyChanging();
						this._Port = value;
						this.SendPropertyChanged("Port");
						this.OnPortChanged();
					}
					this.SendPropertySetterInvoked("Port", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Bit NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_UseSSL", DbType="Bit NOT NULL", CanBeNull=false)]
			public bool UseSSL
			{
				get
				{
					return this._UseSSL;
				}
				set
				{
					if (this._UseSSL != value)
					{
						this.OnUseSSLChanging(value);
						this.SendPropertyChanging();
						this._UseSSL = value;
						this.SendPropertyChanged("UseSSL");
						this.OnUseSSLChanged();
					}
					this.SendPropertySetterInvoked("UseSSL", value);
				}
			}
			
			/// <summary>
			/// Column DbType=VarChar(MAX)
			/// </summary>
			[ColumnAttribute(Storage="_ReceivedEmailUIDLS", DbType="VarChar(MAX)", CanBeNull=true)]
			public string ReceivedEmailUIDLS
			{
				get
				{
					return this._ReceivedEmailUIDLS;
				}
				set
				{
					if (this._ReceivedEmailUIDLS != value)
					{
						this.OnReceivedEmailUIDLSChanging(value);
						this.SendPropertyChanging();
						this._ReceivedEmailUIDLS = value;
						this.SendPropertyChanged("ReceivedEmailUIDLS");
						this.OnReceivedEmailUIDLSChanged();
					}
					this.SendPropertySetterInvoked("ReceivedEmailUIDLS", value);
				}
			}
			
			#endregion Columns

			#region Associations
			/// <summary>
			/// Association [PK][One]tblBillFirmaTransakcijskiRacunEmail.BillFirmaTransakcijskiRacunEmailID --- [FK][Many]tblBillFirmaTransakcijskiRacun.BillFirmaTransakcijskiRacunEmailID
			/// </summary>
			[AssociationAttribute(Name="FK_tblBillFirmaTransakcijskiRacun_tblBillFirmaTransakcijskiRacunEmail", Storage="_tblBillFirmaTransakcijskiRacunList", ThisKey="BillFirmaTransakcijskiRacunEmailID", OtherKey="BillFirmaTransakcijskiRacunEmailID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<tblBillFirmaTransakcijskiRacun> tblBillFirmaTransakcijskiRacunList
			{
				get { return this._tblBillFirmaTransakcijskiRacunList; }
				set { this._tblBillFirmaTransakcijskiRacunList.Assign(value); }
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
		#endregion dbo.tblBillFirmaTransakcijskiRacunEmail

		#region dbo.tblBillMjera
		[TableAttribute(Name="dbo.tblBillMjera")]
		public partial class tblBillMjera : EntityBase<tblBillMjera, dbArizonaAppDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private int _BillMjeraID;
			private bool _IsActive;
			private int _Ordinal;
			private bool _IsDefault;
			private string _Naziv;
			private string _KratkiNaziv;
			private int _OsnovnaBillMjeraID;
			private double _DioOsnovneMjere;
			private EntitySet<tblBillDocumentStavka> _tblBillDocumentStavkaList;
			private EntityRef<tblBillMjera> _OsnovnaBillMjera;
			private EntitySet<tblBillMjera> _BillMjeraList;
			private EntitySet<tblBillProduct> _tblBillProductList;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnBillMjeraIDChanging(int value);
			partial void OnBillMjeraIDChanged();
			partial void OnIsActiveChanging(bool value);
			partial void OnIsActiveChanged();
			partial void OnOrdinalChanging(int value);
			partial void OnOrdinalChanged();
			partial void OnIsDefaultChanging(bool value);
			partial void OnIsDefaultChanged();
			partial void OnNazivChanging(string value);
			partial void OnNazivChanged();
			partial void OnKratkiNazivChanging(string value);
			partial void OnKratkiNazivChanged();
			partial void OnOsnovnaBillMjeraIDChanging(int value);
			partial void OnOsnovnaBillMjeraIDChanged();
			partial void OnDioOsnovneMjereChanging(double value);
			partial void OnDioOsnovneMjereChanged();
			#endregion

			public tblBillMjera()
			{
				_tblBillDocumentStavkaList = new EntitySet<tblBillDocumentStavka>(
					new Action<tblBillDocumentStavka>(item=>{this.SendPropertyChanging(); item.tblBillMjera=this;}), 
					new Action<tblBillDocumentStavka>(item=>{this.SendPropertyChanging(); item.tblBillMjera=null;}));
				_OsnovnaBillMjera = default(EntityRef<tblBillMjera>);
				_BillMjeraList = new EntitySet<tblBillMjera>(
					new Action<tblBillMjera>(item=>{this.SendPropertyChanging(); item.OsnovnaBillMjera=this;}), 
					new Action<tblBillMjera>(item=>{this.SendPropertyChanging(); item.OsnovnaBillMjera=null;}));
				_tblBillProductList = new EntitySet<tblBillProduct>(
					new Action<tblBillProduct>(item=>{this.SendPropertyChanging(); item.tblBillMjera=this;}), 
					new Action<tblBillProduct>(item=>{this.SendPropertyChanging(); item.tblBillMjera=null;}));
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_BillMjeraID", DbType="Int NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
			public int BillMjeraID
			{
				get
				{
					return this._BillMjeraID;
				}
				set
				{
					if (this._BillMjeraID != value)
					{
						this.OnBillMjeraIDChanging(value);
						this.SendPropertyChanging();
						this._BillMjeraID = value;
						this.SendPropertyChanged("BillMjeraID");
						this.OnBillMjeraIDChanged();
					}
					this.SendPropertySetterInvoked("BillMjeraID", value);
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
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_Ordinal", DbType="Int NOT NULL", CanBeNull=false)]
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
						this.OnOrdinalChanging(value);
						this.SendPropertyChanging();
						this._Ordinal = value;
						this.SendPropertyChanged("Ordinal");
						this.OnOrdinalChanged();
					}
					this.SendPropertySetterInvoked("Ordinal", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Bit NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_IsDefault", DbType="Bit NOT NULL", CanBeNull=false)]
			public bool IsDefault
			{
				get
				{
					return this._IsDefault;
				}
				set
				{
					if (this._IsDefault != value)
					{
						this.OnIsDefaultChanging(value);
						this.SendPropertyChanging();
						this._IsDefault = value;
						this.SendPropertyChanged("IsDefault");
						this.OnIsDefaultChanged();
					}
					this.SendPropertySetterInvoked("IsDefault", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(50) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_Naziv", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
			public string Naziv
			{
				get
				{
					return this._Naziv;
				}
				set
				{
					if (this._Naziv != value)
					{
						this.OnNazivChanging(value);
						this.SendPropertyChanging();
						this._Naziv = value;
						this.SendPropertyChanged("Naziv");
						this.OnNazivChanged();
					}
					this.SendPropertySetterInvoked("Naziv", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(10) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_KratkiNaziv", DbType="NVarChar(10) NOT NULL", CanBeNull=false)]
			public string KratkiNaziv
			{
				get
				{
					return this._KratkiNaziv;
				}
				set
				{
					if (this._KratkiNaziv != value)
					{
						this.OnKratkiNazivChanging(value);
						this.SendPropertyChanging();
						this._KratkiNaziv = value;
						this.SendPropertyChanged("KratkiNaziv");
						this.OnKratkiNazivChanged();
					}
					this.SendPropertySetterInvoked("KratkiNaziv", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_OsnovnaBillMjeraID", DbType="Int NOT NULL", CanBeNull=false)]
			public int OsnovnaBillMjeraID
			{
				get
				{
					return this._OsnovnaBillMjeraID;
				}
				set
				{
					if (this._OsnovnaBillMjeraID != value)
					{
						this.OnOsnovnaBillMjeraIDChanging(value);
						this.SendPropertyChanging();
						this._OsnovnaBillMjeraID = value;
						this.SendPropertyChanged("OsnovnaBillMjeraID");
						this.OnOsnovnaBillMjeraIDChanged();
					}
					this.SendPropertySetterInvoked("OsnovnaBillMjeraID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Float NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_DioOsnovneMjere", DbType="Float NOT NULL", CanBeNull=false)]
			public double DioOsnovneMjere
			{
				get
				{
					return this._DioOsnovneMjere;
				}
				set
				{
					if (this._DioOsnovneMjere != value)
					{
						this.OnDioOsnovneMjereChanging(value);
						this.SendPropertyChanging();
						this._DioOsnovneMjere = value;
						this.SendPropertyChanged("DioOsnovneMjere");
						this.OnDioOsnovneMjereChanged();
					}
					this.SendPropertySetterInvoked("DioOsnovneMjere", value);
				}
			}
			
			#endregion Columns

			#region Associations
			/// <summary>
			/// Association [PK][One]tblBillMjera.BillMjeraID --- [FK][Many]tblBillDocumentStavka.BillMjeraID
			/// </summary>
			[AssociationAttribute(Name="FK_tblBillDocumentStavka_tblBillMjera", Storage="_tblBillDocumentStavkaList", ThisKey="BillMjeraID", OtherKey="BillMjeraID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<tblBillDocumentStavka> tblBillDocumentStavkaList
			{
				get { return this._tblBillDocumentStavkaList; }
				set { this._tblBillDocumentStavkaList.Assign(value); }
			}
			
			/// <summary>
			/// Association [FK][Many]tblBillMjera.OsnovnaBillMjeraID --- [PK][One]tblBillMjera.BillMjeraID
			/// </summary>
			[AssociationAttribute(Name="FK_tblBillMjera_tblBillMjera", Storage="_OsnovnaBillMjera", ThisKey="OsnovnaBillMjeraID", OtherKey="BillMjeraID", IsUnique=false, IsForeignKey=true)]
			public tblBillMjera OsnovnaBillMjera
			{
				get
				{
					return this._OsnovnaBillMjera.Entity;
				}
				set
				{
					tblBillMjera previousValue = this._OsnovnaBillMjera.Entity;
					if ((previousValue != value) || (this._OsnovnaBillMjera.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._OsnovnaBillMjera.Entity = null;
							previousValue.BillMjeraList.Remove(this);
						}
						this._OsnovnaBillMjera.Entity = value;
						if (value != null)
						{
							value.BillMjeraList.Add(this);
							this._OsnovnaBillMjeraID = value.BillMjeraID;
						}
						else
						{
							this._OsnovnaBillMjeraID = default(int);
						}
						this.SendPropertyChanged("OsnovnaBillMjera");
					}
					this.SendPropertySetterInvoked("OsnovnaBillMjera", value);
				}
			}
			
			/// <summary>
			/// Association [PK][One]tblBillMjera.BillMjeraID --- [FK][Many]tblBillMjera.OsnovnaBillMjeraID
			/// </summary>
			[AssociationAttribute(Name="FK_tblBillMjera_tblBillMjera", Storage="_BillMjeraList", ThisKey="BillMjeraID", OtherKey="OsnovnaBillMjeraID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<tblBillMjera> BillMjeraList
			{
				get { return this._BillMjeraList; }
				set { this._BillMjeraList.Assign(value); }
			}
			
			/// <summary>
			/// Association [PK][One]tblBillMjera.BillMjeraID --- [FK][Many]tblBillProduct.BillMjeraID
			/// </summary>
			[AssociationAttribute(Name="FK_tblBillProduct_tblBillMjera", Storage="_tblBillProductList", ThisKey="BillMjeraID", OtherKey="BillMjeraID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<tblBillProduct> tblBillProductList
			{
				get { return this._tblBillProductList; }
				set { this._tblBillProductList.Assign(value); }
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
		#endregion dbo.tblBillMjera

		#region dbo.tblBillNaplatniUredjaj
		[TableAttribute(Name="dbo.tblBillNaplatniUredjaj")]
		public partial class tblBillNaplatniUredjaj : EntityBase<tblBillNaplatniUredjaj, dbArizonaAppDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private long _BillNaplatniUredjajID;
			private long _BillPoslovniProstorID;
			private bool _IsActive;
			private int? _OznakaNaplatnogUredjaja;
			private string _Naziv;
			private string _Napomena;
			private int _BillPaymentMethodID;
			private long? _CreatesRacunBillNaplatniUredjajID;
			private int _BillDocumentTipID;
			private string _POSMargineTRBL;
			private string _FooterText;
			private EntitySet<tblBillDocument> _tblBillDocumentList;
			private EntitySet<tblBillDocumentRedniBroj> _tblBillDocumentRedniBrojList;
			private EntityRef<tblBillDocumentTip> _tblBillDocumentTip;
			private EntityRef<tblBillNaplatniUredjaj> _CreatesRacunBillNaplatniUredjaj;
			private EntitySet<tblBillNaplatniUredjaj> _BillNaplatniUredjajList;
			private EntityRef<tblBillPaymentMethod> _tblBillPaymentMethod;
			private EntityRef<tblBillPoslovniProstor> _tblBillPoslovniProstor;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnBillNaplatniUredjajIDChanging(long value);
			partial void OnBillNaplatniUredjajIDChanged();
			partial void OnBillPoslovniProstorIDChanging(long value);
			partial void OnBillPoslovniProstorIDChanged();
			partial void OnIsActiveChanging(bool value);
			partial void OnIsActiveChanged();
			partial void OnOznakaNaplatnogUredjajaChanging(int? value);
			partial void OnOznakaNaplatnogUredjajaChanged();
			partial void OnNazivChanging(string value);
			partial void OnNazivChanged();
			partial void OnNapomenaChanging(string value);
			partial void OnNapomenaChanged();
			partial void OnBillPaymentMethodIDChanging(int value);
			partial void OnBillPaymentMethodIDChanged();
			partial void OnCreatesRacunBillNaplatniUredjajIDChanging(long? value);
			partial void OnCreatesRacunBillNaplatniUredjajIDChanged();
			partial void OnBillDocumentTipIDChanging(int value);
			partial void OnBillDocumentTipIDChanged();
			partial void OnPOSMargineTRBLChanging(string value);
			partial void OnPOSMargineTRBLChanged();
			partial void OnFooterTextChanging(string value);
			partial void OnFooterTextChanged();
			#endregion

			public tblBillNaplatniUredjaj()
			{
				_tblBillDocumentList = new EntitySet<tblBillDocument>(
					new Action<tblBillDocument>(item=>{this.SendPropertyChanging(); item.tblBillNaplatniUredjaj=this;}), 
					new Action<tblBillDocument>(item=>{this.SendPropertyChanging(); item.tblBillNaplatniUredjaj=null;}));
				_tblBillDocumentRedniBrojList = new EntitySet<tblBillDocumentRedniBroj>(
					new Action<tblBillDocumentRedniBroj>(item=>{this.SendPropertyChanging(); item.tblBillNaplatniUredjaj=this;}), 
					new Action<tblBillDocumentRedniBroj>(item=>{this.SendPropertyChanging(); item.tblBillNaplatniUredjaj=null;}));
				_tblBillDocumentTip = default(EntityRef<tblBillDocumentTip>);
				_CreatesRacunBillNaplatniUredjaj = default(EntityRef<tblBillNaplatniUredjaj>);
				_BillNaplatniUredjajList = new EntitySet<tblBillNaplatniUredjaj>(
					new Action<tblBillNaplatniUredjaj>(item=>{this.SendPropertyChanging(); item.CreatesRacunBillNaplatniUredjaj=this;}), 
					new Action<tblBillNaplatniUredjaj>(item=>{this.SendPropertyChanging(); item.CreatesRacunBillNaplatniUredjaj=null;}));
				_tblBillPaymentMethod = default(EntityRef<tblBillPaymentMethod>);
				_tblBillPoslovniProstor = default(EntityRef<tblBillPoslovniProstor>);
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=BigInt NOT NULL IDENTITY
			/// </summary>
			[ColumnAttribute(Storage="_BillNaplatniUredjajID", AutoSync=AutoSync.OnInsert, DbType="BigInt NOT NULL IDENTITY", CanBeNull=false, IsPrimaryKey=true, IsDbGenerated=true)]
			public long BillNaplatniUredjajID
			{
				get
				{
					return this._BillNaplatniUredjajID;
				}
				set
				{
					if (this._BillNaplatniUredjajID != value)
					{
						this.OnBillNaplatniUredjajIDChanging(value);
						this.SendPropertyChanging();
						this._BillNaplatniUredjajID = value;
						this.SendPropertyChanged("BillNaplatniUredjajID");
						this.OnBillNaplatniUredjajIDChanged();
					}
					this.SendPropertySetterInvoked("BillNaplatniUredjajID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=BigInt NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_BillPoslovniProstorID", DbType="BigInt NOT NULL", CanBeNull=false)]
			public long BillPoslovniProstorID
			{
				get
				{
					return this._BillPoslovniProstorID;
				}
				set
				{
					if (this._BillPoslovniProstorID != value)
					{
						this.OnBillPoslovniProstorIDChanging(value);
						this.SendPropertyChanging();
						this._BillPoslovniProstorID = value;
						this.SendPropertyChanged("BillPoslovniProstorID");
						this.OnBillPoslovniProstorIDChanged();
					}
					this.SendPropertySetterInvoked("BillPoslovniProstorID", value);
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
			/// Column DbType=Int
			/// </summary>
			[ColumnAttribute(Storage="_OznakaNaplatnogUredjaja", DbType="Int", CanBeNull=true)]
			public int? OznakaNaplatnogUredjaja
			{
				get
				{
					return this._OznakaNaplatnogUredjaja;
				}
				set
				{
					if (this._OznakaNaplatnogUredjaja != value)
					{
						this.OnOznakaNaplatnogUredjajaChanging(value);
						this.SendPropertyChanging();
						this._OznakaNaplatnogUredjaja = value;
						this.SendPropertyChanged("OznakaNaplatnogUredjaja");
						this.OnOznakaNaplatnogUredjajaChanged();
					}
					this.SendPropertySetterInvoked("OznakaNaplatnogUredjaja", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(255)
			/// </summary>
			[ColumnAttribute(Storage="_Naziv", DbType="NVarChar(255)", CanBeNull=true)]
			public string Naziv
			{
				get
				{
					return this._Naziv;
				}
				set
				{
					if (this._Naziv != value)
					{
						this.OnNazivChanging(value);
						this.SendPropertyChanging();
						this._Naziv = value;
						this.SendPropertyChanged("Naziv");
						this.OnNazivChanged();
					}
					this.SendPropertySetterInvoked("Naziv", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(500)
			/// </summary>
			[ColumnAttribute(Storage="_Napomena", DbType="NVarChar(500)", CanBeNull=true)]
			public string Napomena
			{
				get
				{
					return this._Napomena;
				}
				set
				{
					if (this._Napomena != value)
					{
						this.OnNapomenaChanging(value);
						this.SendPropertyChanging();
						this._Napomena = value;
						this.SendPropertyChanged("Napomena");
						this.OnNapomenaChanged();
					}
					this.SendPropertySetterInvoked("Napomena", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_BillPaymentMethodID", DbType="Int NOT NULL", CanBeNull=false)]
			public int BillPaymentMethodID
			{
				get
				{
					return this._BillPaymentMethodID;
				}
				set
				{
					if (this._BillPaymentMethodID != value)
					{
						this.OnBillPaymentMethodIDChanging(value);
						this.SendPropertyChanging();
						this._BillPaymentMethodID = value;
						this.SendPropertyChanged("BillPaymentMethodID");
						this.OnBillPaymentMethodIDChanged();
					}
					this.SendPropertySetterInvoked("BillPaymentMethodID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=BigInt
			/// </summary>
			[ColumnAttribute(Storage="_CreatesRacunBillNaplatniUredjajID", DbType="BigInt", CanBeNull=true)]
			public long? CreatesRacunBillNaplatniUredjajID
			{
				get
				{
					return this._CreatesRacunBillNaplatniUredjajID;
				}
				set
				{
					if (this._CreatesRacunBillNaplatniUredjajID != value)
					{
						this.OnCreatesRacunBillNaplatniUredjajIDChanging(value);
						this.SendPropertyChanging();
						this._CreatesRacunBillNaplatniUredjajID = value;
						this.SendPropertyChanged("CreatesRacunBillNaplatniUredjajID");
						this.OnCreatesRacunBillNaplatniUredjajIDChanged();
					}
					this.SendPropertySetterInvoked("CreatesRacunBillNaplatniUredjajID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_BillDocumentTipID", DbType="Int NOT NULL", CanBeNull=false)]
			public int BillDocumentTipID
			{
				get
				{
					return this._BillDocumentTipID;
				}
				set
				{
					if (this._BillDocumentTipID != value)
					{
						this.OnBillDocumentTipIDChanging(value);
						this.SendPropertyChanging();
						this._BillDocumentTipID = value;
						this.SendPropertyChanged("BillDocumentTipID");
						this.OnBillDocumentTipIDChanged();
					}
					this.SendPropertySetterInvoked("BillDocumentTipID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=VarChar(50)
			/// </summary>
			[ColumnAttribute(Storage="_POSMargineTRBL", DbType="VarChar(50)", CanBeNull=true)]
			public string POSMargineTRBL
			{
				get
				{
					return this._POSMargineTRBL;
				}
				set
				{
					if (this._POSMargineTRBL != value)
					{
						this.OnPOSMargineTRBLChanging(value);
						this.SendPropertyChanging();
						this._POSMargineTRBL = value;
						this.SendPropertyChanged("POSMargineTRBL");
						this.OnPOSMargineTRBLChanged();
					}
					this.SendPropertySetterInvoked("POSMargineTRBL", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(500)
			/// </summary>
			[ColumnAttribute(Storage="_FooterText", DbType="NVarChar(500)", CanBeNull=true)]
			public string FooterText
			{
				get
				{
					return this._FooterText;
				}
				set
				{
					if (this._FooterText != value)
					{
						this.OnFooterTextChanging(value);
						this.SendPropertyChanging();
						this._FooterText = value;
						this.SendPropertyChanged("FooterText");
						this.OnFooterTextChanged();
					}
					this.SendPropertySetterInvoked("FooterText", value);
				}
			}
			
			#endregion Columns

			#region Associations
			/// <summary>
			/// Association [PK][One]tblBillNaplatniUredjaj.BillNaplatniUredjajID --- [FK][Many]tblBillDocument.BillNaplatniUredjajID
			/// </summary>
			[AssociationAttribute(Name="FK_tblBillDocument_tblBillNaplatniUredjaj", Storage="_tblBillDocumentList", ThisKey="BillNaplatniUredjajID", OtherKey="BillNaplatniUredjajID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<tblBillDocument> tblBillDocumentList
			{
				get { return this._tblBillDocumentList; }
				set { this._tblBillDocumentList.Assign(value); }
			}
			
			/// <summary>
			/// Association [PK][One]tblBillNaplatniUredjaj.BillNaplatniUredjajID --- [FK][Many]tblBillDocumentRedniBroj.BillNaplatniUredjajID
			/// </summary>
			[AssociationAttribute(Name="FK_tblBillDocumentRedniBroj_tblBillNaplatniUredjaj", Storage="_tblBillDocumentRedniBrojList", ThisKey="BillNaplatniUredjajID", OtherKey="BillNaplatniUredjajID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<tblBillDocumentRedniBroj> tblBillDocumentRedniBrojList
			{
				get { return this._tblBillDocumentRedniBrojList; }
				set { this._tblBillDocumentRedniBrojList.Assign(value); }
			}
			
			/// <summary>
			/// Association [FK][Many]tblBillNaplatniUredjaj.BillDocumentTipID --- [PK][One]tblBillDocumentTip.BillDocumentTipID
			/// </summary>
			[AssociationAttribute(Name="FK_tblBillNaplatniUredjaj_tblBillDocumentTip", Storage="_tblBillDocumentTip", ThisKey="BillDocumentTipID", OtherKey="BillDocumentTipID", IsUnique=false, IsForeignKey=true)]
			public tblBillDocumentTip tblBillDocumentTip
			{
				get
				{
					return this._tblBillDocumentTip.Entity;
				}
				set
				{
					tblBillDocumentTip previousValue = this._tblBillDocumentTip.Entity;
					if ((previousValue != value) || (this._tblBillDocumentTip.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._tblBillDocumentTip.Entity = null;
							previousValue.tblBillNaplatniUredjajList.Remove(this);
						}
						this._tblBillDocumentTip.Entity = value;
						if (value != null)
						{
							value.tblBillNaplatniUredjajList.Add(this);
							this._BillDocumentTipID = value.BillDocumentTipID;
						}
						else
						{
							this._BillDocumentTipID = default(int);
						}
						this.SendPropertyChanged("tblBillDocumentTip");
					}
					this.SendPropertySetterInvoked("tblBillDocumentTip", value);
				}
			}
			
			/// <summary>
			/// Association [FK][Many]tblBillNaplatniUredjaj.CreatesRacunBillNaplatniUredjajID --- [PK][One]tblBillNaplatniUredjaj.BillNaplatniUredjajID
			/// </summary>
			[AssociationAttribute(Name="FK_tblBillNaplatniUredjaj_tblBillNaplatniUredjaj", Storage="_CreatesRacunBillNaplatniUredjaj", ThisKey="CreatesRacunBillNaplatniUredjajID", OtherKey="BillNaplatniUredjajID", IsUnique=false, IsForeignKey=true)]
			public tblBillNaplatniUredjaj CreatesRacunBillNaplatniUredjaj
			{
				get
				{
					return this._CreatesRacunBillNaplatniUredjaj.Entity;
				}
				set
				{
					tblBillNaplatniUredjaj previousValue = this._CreatesRacunBillNaplatniUredjaj.Entity;
					if ((previousValue != value) || (this._CreatesRacunBillNaplatniUredjaj.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._CreatesRacunBillNaplatniUredjaj.Entity = null;
							previousValue.BillNaplatniUredjajList.Remove(this);
						}
						this._CreatesRacunBillNaplatniUredjaj.Entity = value;
						if (value != null)
						{
							value.BillNaplatniUredjajList.Add(this);
							this._CreatesRacunBillNaplatniUredjajID = value.BillNaplatniUredjajID;
						}
						else
						{
							this._CreatesRacunBillNaplatniUredjajID = default(long?);
						}
						this.SendPropertyChanged("CreatesRacunBillNaplatniUredjaj");
					}
					this.SendPropertySetterInvoked("CreatesRacunBillNaplatniUredjaj", value);
				}
			}
			
			/// <summary>
			/// Association [PK][One]tblBillNaplatniUredjaj.BillNaplatniUredjajID --- [FK][Many]tblBillNaplatniUredjaj.CreatesRacunBillNaplatniUredjajID
			/// </summary>
			[AssociationAttribute(Name="FK_tblBillNaplatniUredjaj_tblBillNaplatniUredjaj", Storage="_BillNaplatniUredjajList", ThisKey="BillNaplatniUredjajID", OtherKey="CreatesRacunBillNaplatniUredjajID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<tblBillNaplatniUredjaj> BillNaplatniUredjajList
			{
				get { return this._BillNaplatniUredjajList; }
				set { this._BillNaplatniUredjajList.Assign(value); }
			}
			
			/// <summary>
			/// Association [FK][Many]tblBillNaplatniUredjaj.BillPaymentMethodID --- [PK][One]tblBillPaymentMethod.BillPaymentMethodID
			/// </summary>
			[AssociationAttribute(Name="FK_tblBillNaplatniUredjaj_tblBillPaymentMethod", Storage="_tblBillPaymentMethod", ThisKey="BillPaymentMethodID", OtherKey="BillPaymentMethodID", IsUnique=false, IsForeignKey=true)]
			public tblBillPaymentMethod tblBillPaymentMethod
			{
				get
				{
					return this._tblBillPaymentMethod.Entity;
				}
				set
				{
					tblBillPaymentMethod previousValue = this._tblBillPaymentMethod.Entity;
					if ((previousValue != value) || (this._tblBillPaymentMethod.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._tblBillPaymentMethod.Entity = null;
							previousValue.tblBillNaplatniUredjajList.Remove(this);
						}
						this._tblBillPaymentMethod.Entity = value;
						if (value != null)
						{
							value.tblBillNaplatniUredjajList.Add(this);
							this._BillPaymentMethodID = value.BillPaymentMethodID;
						}
						else
						{
							this._BillPaymentMethodID = default(int);
						}
						this.SendPropertyChanged("tblBillPaymentMethod");
					}
					this.SendPropertySetterInvoked("tblBillPaymentMethod", value);
				}
			}
			
			/// <summary>
			/// Association [FK][Many]tblBillNaplatniUredjaj.BillPoslovniProstorID --- [PK][One]tblBillPoslovniProstor.BillPoslovniProstorID
			/// </summary>
			[AssociationAttribute(Name="FK_tblBillNaplatniUredjaj_tblBillPoslovniProstor", Storage="_tblBillPoslovniProstor", ThisKey="BillPoslovniProstorID", OtherKey="BillPoslovniProstorID", IsUnique=false, IsForeignKey=true)]
			public tblBillPoslovniProstor tblBillPoslovniProstor
			{
				get
				{
					return this._tblBillPoslovniProstor.Entity;
				}
				set
				{
					tblBillPoslovniProstor previousValue = this._tblBillPoslovniProstor.Entity;
					if ((previousValue != value) || (this._tblBillPoslovniProstor.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._tblBillPoslovniProstor.Entity = null;
							previousValue.tblBillNaplatniUredjajList.Remove(this);
						}
						this._tblBillPoslovniProstor.Entity = value;
						if (value != null)
						{
							value.tblBillNaplatniUredjajList.Add(this);
							this._BillPoslovniProstorID = value.BillPoslovniProstorID;
						}
						else
						{
							this._BillPoslovniProstorID = default(long);
						}
						this.SendPropertyChanged("tblBillPoslovniProstor");
					}
					this.SendPropertySetterInvoked("tblBillPoslovniProstor", value);
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
		#endregion dbo.tblBillNaplatniUredjaj

		#region dbo.tblBillOperator
		[TableAttribute(Name="dbo.tblBillOperator")]
		public partial class tblBillOperator : EntityBase<tblBillOperator, dbArizonaAppDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private long _BillOperatorID;
			private string _Ime;
			private string _Prezime;
			private string _OIB;
			private EntitySet<tblAppMember> _tblAppMemberList;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnBillOperatorIDChanging(long value);
			partial void OnBillOperatorIDChanged();
			partial void OnImeChanging(string value);
			partial void OnImeChanged();
			partial void OnPrezimeChanging(string value);
			partial void OnPrezimeChanged();
			partial void OnOIBChanging(string value);
			partial void OnOIBChanged();
			#endregion

			public tblBillOperator()
			{
				_tblAppMemberList = new EntitySet<tblAppMember>(
					new Action<tblAppMember>(item=>{this.SendPropertyChanging(); item.tblBillOperator=this;}), 
					new Action<tblAppMember>(item=>{this.SendPropertyChanging(); item.tblBillOperator=null;}));
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=BigInt NOT NULL IDENTITY
			/// </summary>
			[ColumnAttribute(Storage="_BillOperatorID", AutoSync=AutoSync.OnInsert, DbType="BigInt NOT NULL IDENTITY", CanBeNull=false, IsPrimaryKey=true, IsDbGenerated=true)]
			public long BillOperatorID
			{
				get
				{
					return this._BillOperatorID;
				}
				set
				{
					if (this._BillOperatorID != value)
					{
						this.OnBillOperatorIDChanging(value);
						this.SendPropertyChanging();
						this._BillOperatorID = value;
						this.SendPropertyChanged("BillOperatorID");
						this.OnBillOperatorIDChanged();
					}
					this.SendPropertySetterInvoked("BillOperatorID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(100) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_Ime", DbType="NVarChar(100) NOT NULL", CanBeNull=false)]
			public string Ime
			{
				get
				{
					return this._Ime;
				}
				set
				{
					if (this._Ime != value)
					{
						this.OnImeChanging(value);
						this.SendPropertyChanging();
						this._Ime = value;
						this.SendPropertyChanged("Ime");
						this.OnImeChanged();
					}
					this.SendPropertySetterInvoked("Ime", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(100) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_Prezime", DbType="NVarChar(100) NOT NULL", CanBeNull=false)]
			public string Prezime
			{
				get
				{
					return this._Prezime;
				}
				set
				{
					if (this._Prezime != value)
					{
						this.OnPrezimeChanging(value);
						this.SendPropertyChanging();
						this._Prezime = value;
						this.SendPropertyChanged("Prezime");
						this.OnPrezimeChanged();
					}
					this.SendPropertySetterInvoked("Prezime", value);
				}
			}
			
			/// <summary>
			/// Column DbType=VarChar(20) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_OIB", DbType="VarChar(20) NOT NULL", CanBeNull=false)]
			public string OIB
			{
				get
				{
					return this._OIB;
				}
				set
				{
					if (this._OIB != value)
					{
						this.OnOIBChanging(value);
						this.SendPropertyChanging();
						this._OIB = value;
						this.SendPropertyChanged("OIB");
						this.OnOIBChanged();
					}
					this.SendPropertySetterInvoked("OIB", value);
				}
			}
			
			#endregion Columns

			#region Associations
			/// <summary>
			/// Association [PK][One]tblBillOperator.BillOperatorID --- [FK][Many]tblAppMember.BillOperatorID
			/// </summary>
			[AssociationAttribute(Name="FK_tblAppMember_tblBillOperator", Storage="_tblAppMemberList", ThisKey="BillOperatorID", OtherKey="BillOperatorID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
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
		#endregion dbo.tblBillOperator

		#region dbo.tblBillPaymentMethod
		[TableAttribute(Name="dbo.tblBillPaymentMethod")]
		public partial class tblBillPaymentMethod : EntityBase<tblBillPaymentMethod, dbArizonaAppDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private int _BillPaymentMethodID;
			private bool _IsActive;
			private int _Ordinal;
			private bool _IsDefault;
			private string _Name;
			private bool _IsFiskalizacijaRequired;
			private string _OznakaZaFiskalizaciju;
			private EntitySet<tblBillNaplatniUredjaj> _tblBillNaplatniUredjajList;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnBillPaymentMethodIDChanging(int value);
			partial void OnBillPaymentMethodIDChanged();
			partial void OnIsActiveChanging(bool value);
			partial void OnIsActiveChanged();
			partial void OnOrdinalChanging(int value);
			partial void OnOrdinalChanged();
			partial void OnIsDefaultChanging(bool value);
			partial void OnIsDefaultChanged();
			partial void OnNameChanging(string value);
			partial void OnNameChanged();
			partial void OnIsFiskalizacijaRequiredChanging(bool value);
			partial void OnIsFiskalizacijaRequiredChanged();
			partial void OnOznakaZaFiskalizacijuChanging(string value);
			partial void OnOznakaZaFiskalizacijuChanged();
			#endregion

			public tblBillPaymentMethod()
			{
				_tblBillNaplatniUredjajList = new EntitySet<tblBillNaplatniUredjaj>(
					new Action<tblBillNaplatniUredjaj>(item=>{this.SendPropertyChanging(); item.tblBillPaymentMethod=this;}), 
					new Action<tblBillNaplatniUredjaj>(item=>{this.SendPropertyChanging(); item.tblBillPaymentMethod=null;}));
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_BillPaymentMethodID", DbType="Int NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
			public int BillPaymentMethodID
			{
				get
				{
					return this._BillPaymentMethodID;
				}
				set
				{
					if (this._BillPaymentMethodID != value)
					{
						this.OnBillPaymentMethodIDChanging(value);
						this.SendPropertyChanging();
						this._BillPaymentMethodID = value;
						this.SendPropertyChanged("BillPaymentMethodID");
						this.OnBillPaymentMethodIDChanged();
					}
					this.SendPropertySetterInvoked("BillPaymentMethodID", value);
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
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_Ordinal", DbType="Int NOT NULL", CanBeNull=false)]
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
						this.OnOrdinalChanging(value);
						this.SendPropertyChanging();
						this._Ordinal = value;
						this.SendPropertyChanged("Ordinal");
						this.OnOrdinalChanged();
					}
					this.SendPropertySetterInvoked("Ordinal", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Bit NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_IsDefault", DbType="Bit NOT NULL", CanBeNull=false)]
			public bool IsDefault
			{
				get
				{
					return this._IsDefault;
				}
				set
				{
					if (this._IsDefault != value)
					{
						this.OnIsDefaultChanging(value);
						this.SendPropertyChanging();
						this._IsDefault = value;
						this.SendPropertyChanged("IsDefault");
						this.OnIsDefaultChanged();
					}
					this.SendPropertySetterInvoked("IsDefault", value);
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
			/// Column DbType=Bit NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_IsFiskalizacijaRequired", DbType="Bit NOT NULL", CanBeNull=false)]
			public bool IsFiskalizacijaRequired
			{
				get
				{
					return this._IsFiskalizacijaRequired;
				}
				set
				{
					if (this._IsFiskalizacijaRequired != value)
					{
						this.OnIsFiskalizacijaRequiredChanging(value);
						this.SendPropertyChanging();
						this._IsFiskalizacijaRequired = value;
						this.SendPropertyChanged("IsFiskalizacijaRequired");
						this.OnIsFiskalizacijaRequiredChanged();
					}
					this.SendPropertySetterInvoked("IsFiskalizacijaRequired", value);
				}
			}
			
			/// <summary>
			/// Column DbType=VarChar(10)
			/// </summary>
			[ColumnAttribute(Storage="_OznakaZaFiskalizaciju", DbType="VarChar(10)", CanBeNull=true)]
			public string OznakaZaFiskalizaciju
			{
				get
				{
					return this._OznakaZaFiskalizaciju;
				}
				set
				{
					if (this._OznakaZaFiskalizaciju != value)
					{
						this.OnOznakaZaFiskalizacijuChanging(value);
						this.SendPropertyChanging();
						this._OznakaZaFiskalizaciju = value;
						this.SendPropertyChanged("OznakaZaFiskalizaciju");
						this.OnOznakaZaFiskalizacijuChanged();
					}
					this.SendPropertySetterInvoked("OznakaZaFiskalizaciju", value);
				}
			}
			
			#endregion Columns

			#region Associations
			/// <summary>
			/// Association [PK][One]tblBillPaymentMethod.BillPaymentMethodID --- [FK][Many]tblBillNaplatniUredjaj.BillPaymentMethodID
			/// </summary>
			[AssociationAttribute(Name="FK_tblBillNaplatniUredjaj_tblBillPaymentMethod", Storage="_tblBillNaplatniUredjajList", ThisKey="BillPaymentMethodID", OtherKey="BillPaymentMethodID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<tblBillNaplatniUredjaj> tblBillNaplatniUredjajList
			{
				get { return this._tblBillNaplatniUredjajList; }
				set { this._tblBillNaplatniUredjajList.Assign(value); }
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
		#endregion dbo.tblBillPaymentMethod

		#region dbo.tblBillPoreznaGrupa
		[TableAttribute(Name="dbo.tblBillPoreznaGrupa")]
		public partial class tblBillPoreznaGrupa : EntityBase<tblBillPoreznaGrupa, dbArizonaAppDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private long _BillPoreznaGrupaID;
			private long _BillPoslovniProstorID;
			private string _Naziv;
			private string _Opis;
			private decimal _PdvPosto;
			private decimal _PorezPotrosnjaPosto;
			private string _OstaliPorezNaziv;
			private decimal _OstaliPorezPosto;
			private string _NaknadaNaziv;
			private decimal _IznosNaknade;
			private EntitySet<tblBillDocumentStavka> _tblBillDocumentStavkaList;
			private EntityRef<tblBillPoslovniProstor> _tblBillPoslovniProstor;
			private EntitySet<tblBillProduct> _tblBillProductList;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnBillPoreznaGrupaIDChanging(long value);
			partial void OnBillPoreznaGrupaIDChanged();
			partial void OnBillPoslovniProstorIDChanging(long value);
			partial void OnBillPoslovniProstorIDChanged();
			partial void OnNazivChanging(string value);
			partial void OnNazivChanged();
			partial void OnOpisChanging(string value);
			partial void OnOpisChanged();
			partial void OnPdvPostoChanging(decimal value);
			partial void OnPdvPostoChanged();
			partial void OnPorezPotrosnjaPostoChanging(decimal value);
			partial void OnPorezPotrosnjaPostoChanged();
			partial void OnOstaliPorezNazivChanging(string value);
			partial void OnOstaliPorezNazivChanged();
			partial void OnOstaliPorezPostoChanging(decimal value);
			partial void OnOstaliPorezPostoChanged();
			partial void OnNaknadaNazivChanging(string value);
			partial void OnNaknadaNazivChanged();
			partial void OnIznosNaknadeChanging(decimal value);
			partial void OnIznosNaknadeChanged();
			#endregion

			public tblBillPoreznaGrupa()
			{
				_tblBillDocumentStavkaList = new EntitySet<tblBillDocumentStavka>(
					new Action<tblBillDocumentStavka>(item=>{this.SendPropertyChanging(); item.tblBillPoreznaGrupa=this;}), 
					new Action<tblBillDocumentStavka>(item=>{this.SendPropertyChanging(); item.tblBillPoreznaGrupa=null;}));
				_tblBillPoslovniProstor = default(EntityRef<tblBillPoslovniProstor>);
				_tblBillProductList = new EntitySet<tblBillProduct>(
					new Action<tblBillProduct>(item=>{this.SendPropertyChanging(); item.tblBillPoreznaGrupa=this;}), 
					new Action<tblBillProduct>(item=>{this.SendPropertyChanging(); item.tblBillPoreznaGrupa=null;}));
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=BigInt NOT NULL IDENTITY
			/// </summary>
			[ColumnAttribute(Storage="_BillPoreznaGrupaID", AutoSync=AutoSync.OnInsert, DbType="BigInt NOT NULL IDENTITY", CanBeNull=false, IsPrimaryKey=true, IsDbGenerated=true)]
			public long BillPoreznaGrupaID
			{
				get
				{
					return this._BillPoreznaGrupaID;
				}
				set
				{
					if (this._BillPoreznaGrupaID != value)
					{
						this.OnBillPoreznaGrupaIDChanging(value);
						this.SendPropertyChanging();
						this._BillPoreznaGrupaID = value;
						this.SendPropertyChanged("BillPoreznaGrupaID");
						this.OnBillPoreznaGrupaIDChanged();
					}
					this.SendPropertySetterInvoked("BillPoreznaGrupaID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=BigInt NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_BillPoslovniProstorID", DbType="BigInt NOT NULL", CanBeNull=false)]
			public long BillPoslovniProstorID
			{
				get
				{
					return this._BillPoslovniProstorID;
				}
				set
				{
					if (this._BillPoslovniProstorID != value)
					{
						this.OnBillPoslovniProstorIDChanging(value);
						this.SendPropertyChanging();
						this._BillPoslovniProstorID = value;
						this.SendPropertyChanged("BillPoslovniProstorID");
						this.OnBillPoslovniProstorIDChanged();
					}
					this.SendPropertySetterInvoked("BillPoslovniProstorID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(100) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_Naziv", DbType="NVarChar(100) NOT NULL", CanBeNull=false)]
			public string Naziv
			{
				get
				{
					return this._Naziv;
				}
				set
				{
					if (this._Naziv != value)
					{
						this.OnNazivChanging(value);
						this.SendPropertyChanging();
						this._Naziv = value;
						this.SendPropertyChanged("Naziv");
						this.OnNazivChanged();
					}
					this.SendPropertySetterInvoked("Naziv", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(250)
			/// </summary>
			[ColumnAttribute(Storage="_Opis", DbType="NVarChar(250)", CanBeNull=true)]
			public string Opis
			{
				get
				{
					return this._Opis;
				}
				set
				{
					if (this._Opis != value)
					{
						this.OnOpisChanging(value);
						this.SendPropertyChanging();
						this._Opis = value;
						this.SendPropertyChanged("Opis");
						this.OnOpisChanged();
					}
					this.SendPropertySetterInvoked("Opis", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Decimal(5,2) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_PdvPosto", DbType="Decimal(5,2) NOT NULL", CanBeNull=false)]
			public decimal PdvPosto
			{
				get
				{
					return this._PdvPosto;
				}
				set
				{
					if (this._PdvPosto != value)
					{
						this.OnPdvPostoChanging(value);
						this.SendPropertyChanging();
						this._PdvPosto = value;
						this.SendPropertyChanged("PdvPosto");
						this.OnPdvPostoChanged();
					}
					this.SendPropertySetterInvoked("PdvPosto", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Decimal(5,2) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_PorezPotrosnjaPosto", DbType="Decimal(5,2) NOT NULL", CanBeNull=false)]
			public decimal PorezPotrosnjaPosto
			{
				get
				{
					return this._PorezPotrosnjaPosto;
				}
				set
				{
					if (this._PorezPotrosnjaPosto != value)
					{
						this.OnPorezPotrosnjaPostoChanging(value);
						this.SendPropertyChanging();
						this._PorezPotrosnjaPosto = value;
						this.SendPropertyChanged("PorezPotrosnjaPosto");
						this.OnPorezPotrosnjaPostoChanged();
					}
					this.SendPropertySetterInvoked("PorezPotrosnjaPosto", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(50)
			/// </summary>
			[ColumnAttribute(Storage="_OstaliPorezNaziv", DbType="NVarChar(50)", CanBeNull=true)]
			public string OstaliPorezNaziv
			{
				get
				{
					return this._OstaliPorezNaziv;
				}
				set
				{
					if (this._OstaliPorezNaziv != value)
					{
						this.OnOstaliPorezNazivChanging(value);
						this.SendPropertyChanging();
						this._OstaliPorezNaziv = value;
						this.SendPropertyChanged("OstaliPorezNaziv");
						this.OnOstaliPorezNazivChanged();
					}
					this.SendPropertySetterInvoked("OstaliPorezNaziv", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Decimal(5,2) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_OstaliPorezPosto", DbType="Decimal(5,2) NOT NULL", CanBeNull=false)]
			public decimal OstaliPorezPosto
			{
				get
				{
					return this._OstaliPorezPosto;
				}
				set
				{
					if (this._OstaliPorezPosto != value)
					{
						this.OnOstaliPorezPostoChanging(value);
						this.SendPropertyChanging();
						this._OstaliPorezPosto = value;
						this.SendPropertyChanged("OstaliPorezPosto");
						this.OnOstaliPorezPostoChanged();
					}
					this.SendPropertySetterInvoked("OstaliPorezPosto", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(50)
			/// </summary>
			[ColumnAttribute(Storage="_NaknadaNaziv", DbType="NVarChar(50)", CanBeNull=true)]
			public string NaknadaNaziv
			{
				get
				{
					return this._NaknadaNaziv;
				}
				set
				{
					if (this._NaknadaNaziv != value)
					{
						this.OnNaknadaNazivChanging(value);
						this.SendPropertyChanging();
						this._NaknadaNaziv = value;
						this.SendPropertyChanged("NaknadaNaziv");
						this.OnNaknadaNazivChanged();
					}
					this.SendPropertySetterInvoked("NaknadaNaziv", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Money NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_IznosNaknade", DbType="Money NOT NULL", CanBeNull=false)]
			public decimal IznosNaknade
			{
				get
				{
					return this._IznosNaknade;
				}
				set
				{
					if (this._IznosNaknade != value)
					{
						this.OnIznosNaknadeChanging(value);
						this.SendPropertyChanging();
						this._IznosNaknade = value;
						this.SendPropertyChanged("IznosNaknade");
						this.OnIznosNaknadeChanged();
					}
					this.SendPropertySetterInvoked("IznosNaknade", value);
				}
			}
			
			#endregion Columns

			#region Associations
			/// <summary>
			/// Association [PK][One]tblBillPoreznaGrupa.BillPoreznaGrupaID --- [FK][Many]tblBillDocumentStavka.BillPoreznaGrupaID
			/// </summary>
			[AssociationAttribute(Name="FK_tblBillDocumentStavka_tblBillPoreznaGrupa", Storage="_tblBillDocumentStavkaList", ThisKey="BillPoreznaGrupaID", OtherKey="BillPoreznaGrupaID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<tblBillDocumentStavka> tblBillDocumentStavkaList
			{
				get { return this._tblBillDocumentStavkaList; }
				set { this._tblBillDocumentStavkaList.Assign(value); }
			}
			
			/// <summary>
			/// Association [FK][Many]tblBillPoreznaGrupa.BillPoslovniProstorID --- [PK][One]tblBillPoslovniProstor.BillPoslovniProstorID
			/// </summary>
			[AssociationAttribute(Name="FK_tblBillPoreznaGrupa_tblBillPoslovniProstor", Storage="_tblBillPoslovniProstor", ThisKey="BillPoslovniProstorID", OtherKey="BillPoslovniProstorID", IsUnique=false, IsForeignKey=true)]
			public tblBillPoslovniProstor tblBillPoslovniProstor
			{
				get
				{
					return this._tblBillPoslovniProstor.Entity;
				}
				set
				{
					tblBillPoslovniProstor previousValue = this._tblBillPoslovniProstor.Entity;
					if ((previousValue != value) || (this._tblBillPoslovniProstor.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._tblBillPoslovniProstor.Entity = null;
							previousValue.tblBillPoreznaGrupaList.Remove(this);
						}
						this._tblBillPoslovniProstor.Entity = value;
						if (value != null)
						{
							value.tblBillPoreznaGrupaList.Add(this);
							this._BillPoslovniProstorID = value.BillPoslovniProstorID;
						}
						else
						{
							this._BillPoslovniProstorID = default(long);
						}
						this.SendPropertyChanged("tblBillPoslovniProstor");
					}
					this.SendPropertySetterInvoked("tblBillPoslovniProstor", value);
				}
			}
			
			/// <summary>
			/// Association [PK][One]tblBillPoreznaGrupa.BillPoreznaGrupaID --- [FK][Many]tblBillProduct.BillPoreznaGrupaID
			/// </summary>
			[AssociationAttribute(Name="FK_tblBillProduct_tblBillPoreznaGrupa", Storage="_tblBillProductList", ThisKey="BillPoreznaGrupaID", OtherKey="BillPoreznaGrupaID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<tblBillProduct> tblBillProductList
			{
				get { return this._tblBillProductList; }
				set { this._tblBillProductList.Assign(value); }
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
		#endregion dbo.tblBillPoreznaGrupa

		#region dbo.tblBillPoslovniProstor
		[TableAttribute(Name="dbo.tblBillPoslovniProstor")]
		public partial class tblBillPoslovniProstor : EntityBase<tblBillPoslovniProstor, dbArizonaAppDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private long _BillPoslovniProstorID;
			private int _BillFirmaID;
			private bool _IsActive;
			private int? _OznakaPoslovnogProstora;
			private string _Naziv;
			private string _Ulica;
			private int? _KucniBroj;
			private string _DodatakKucnomBroju;
			private string _PostanskiBroj;
			private string _Mjesto;
			private string _Opcina;
			private string _RadnoVrijeme;
			private DateTime? _PocetakPrimjene;
			private DateTime? _KrajPrimjene;
			private DateTime? _DatumPrijavePoreznoj;
			private DateTime? _DatumOdjavePoreznoj;
			private string _Napomena;
			private EntitySet<tblBillCategory> _tblBillCategoryList;
			private EntitySet<tblBillNaplatniUredjaj> _tblBillNaplatniUredjajList;
			private EntitySet<tblBillPoreznaGrupa> _tblBillPoreznaGrupaList;
			private EntityRef<tblBillFirma> _tblBillFirma;
			private EntitySet<tblBillProduct> _tblBillProductList;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnBillPoslovniProstorIDChanging(long value);
			partial void OnBillPoslovniProstorIDChanged();
			partial void OnBillFirmaIDChanging(int value);
			partial void OnBillFirmaIDChanged();
			partial void OnIsActiveChanging(bool value);
			partial void OnIsActiveChanged();
			partial void OnOznakaPoslovnogProstoraChanging(int? value);
			partial void OnOznakaPoslovnogProstoraChanged();
			partial void OnNazivChanging(string value);
			partial void OnNazivChanged();
			partial void OnUlicaChanging(string value);
			partial void OnUlicaChanged();
			partial void OnKucniBrojChanging(int? value);
			partial void OnKucniBrojChanged();
			partial void OnDodatakKucnomBrojuChanging(string value);
			partial void OnDodatakKucnomBrojuChanged();
			partial void OnPostanskiBrojChanging(string value);
			partial void OnPostanskiBrojChanged();
			partial void OnMjestoChanging(string value);
			partial void OnMjestoChanged();
			partial void OnOpcinaChanging(string value);
			partial void OnOpcinaChanged();
			partial void OnRadnoVrijemeChanging(string value);
			partial void OnRadnoVrijemeChanged();
			partial void OnPocetakPrimjeneChanging(DateTime? value);
			partial void OnPocetakPrimjeneChanged();
			partial void OnKrajPrimjeneChanging(DateTime? value);
			partial void OnKrajPrimjeneChanged();
			partial void OnDatumPrijavePoreznojChanging(DateTime? value);
			partial void OnDatumPrijavePoreznojChanged();
			partial void OnDatumOdjavePoreznojChanging(DateTime? value);
			partial void OnDatumOdjavePoreznojChanged();
			partial void OnNapomenaChanging(string value);
			partial void OnNapomenaChanged();
			#endregion

			public tblBillPoslovniProstor()
			{
				_tblBillCategoryList = new EntitySet<tblBillCategory>(
					new Action<tblBillCategory>(item=>{this.SendPropertyChanging(); item.tblBillPoslovniProstor=this;}), 
					new Action<tblBillCategory>(item=>{this.SendPropertyChanging(); item.tblBillPoslovniProstor=null;}));
				_tblBillNaplatniUredjajList = new EntitySet<tblBillNaplatniUredjaj>(
					new Action<tblBillNaplatniUredjaj>(item=>{this.SendPropertyChanging(); item.tblBillPoslovniProstor=this;}), 
					new Action<tblBillNaplatniUredjaj>(item=>{this.SendPropertyChanging(); item.tblBillPoslovniProstor=null;}));
				_tblBillPoreznaGrupaList = new EntitySet<tblBillPoreznaGrupa>(
					new Action<tblBillPoreznaGrupa>(item=>{this.SendPropertyChanging(); item.tblBillPoslovniProstor=this;}), 
					new Action<tblBillPoreznaGrupa>(item=>{this.SendPropertyChanging(); item.tblBillPoslovniProstor=null;}));
				_tblBillFirma = default(EntityRef<tblBillFirma>);
				_tblBillProductList = new EntitySet<tblBillProduct>(
					new Action<tblBillProduct>(item=>{this.SendPropertyChanging(); item.tblBillPoslovniProstor=this;}), 
					new Action<tblBillProduct>(item=>{this.SendPropertyChanging(); item.tblBillPoslovniProstor=null;}));
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=BigInt NOT NULL IDENTITY
			/// </summary>
			[ColumnAttribute(Storage="_BillPoslovniProstorID", AutoSync=AutoSync.OnInsert, DbType="BigInt NOT NULL IDENTITY", CanBeNull=false, IsPrimaryKey=true, IsDbGenerated=true)]
			public long BillPoslovniProstorID
			{
				get
				{
					return this._BillPoslovniProstorID;
				}
				set
				{
					if (this._BillPoslovniProstorID != value)
					{
						this.OnBillPoslovniProstorIDChanging(value);
						this.SendPropertyChanging();
						this._BillPoslovniProstorID = value;
						this.SendPropertyChanged("BillPoslovniProstorID");
						this.OnBillPoslovniProstorIDChanged();
					}
					this.SendPropertySetterInvoked("BillPoslovniProstorID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_BillFirmaID", DbType="Int NOT NULL", CanBeNull=false)]
			public int BillFirmaID
			{
				get
				{
					return this._BillFirmaID;
				}
				set
				{
					if (this._BillFirmaID != value)
					{
						this.OnBillFirmaIDChanging(value);
						this.SendPropertyChanging();
						this._BillFirmaID = value;
						this.SendPropertyChanged("BillFirmaID");
						this.OnBillFirmaIDChanged();
					}
					this.SendPropertySetterInvoked("BillFirmaID", value);
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
			/// Column DbType=Int
			/// </summary>
			[ColumnAttribute(Storage="_OznakaPoslovnogProstora", DbType="Int", CanBeNull=true)]
			public int? OznakaPoslovnogProstora
			{
				get
				{
					return this._OznakaPoslovnogProstora;
				}
				set
				{
					if (this._OznakaPoslovnogProstora != value)
					{
						this.OnOznakaPoslovnogProstoraChanging(value);
						this.SendPropertyChanging();
						this._OznakaPoslovnogProstora = value;
						this.SendPropertyChanged("OznakaPoslovnogProstora");
						this.OnOznakaPoslovnogProstoraChanged();
					}
					this.SendPropertySetterInvoked("OznakaPoslovnogProstora", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(255)
			/// </summary>
			[ColumnAttribute(Storage="_Naziv", DbType="NVarChar(255)", CanBeNull=true)]
			public string Naziv
			{
				get
				{
					return this._Naziv;
				}
				set
				{
					if (this._Naziv != value)
					{
						this.OnNazivChanging(value);
						this.SendPropertyChanging();
						this._Naziv = value;
						this.SendPropertyChanged("Naziv");
						this.OnNazivChanged();
					}
					this.SendPropertySetterInvoked("Naziv", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(255)
			/// </summary>
			[ColumnAttribute(Storage="_Ulica", DbType="NVarChar(255)", CanBeNull=true)]
			public string Ulica
			{
				get
				{
					return this._Ulica;
				}
				set
				{
					if (this._Ulica != value)
					{
						this.OnUlicaChanging(value);
						this.SendPropertyChanging();
						this._Ulica = value;
						this.SendPropertyChanged("Ulica");
						this.OnUlicaChanged();
					}
					this.SendPropertySetterInvoked("Ulica", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int
			/// </summary>
			[ColumnAttribute(Storage="_KucniBroj", DbType="Int", CanBeNull=true)]
			public int? KucniBroj
			{
				get
				{
					return this._KucniBroj;
				}
				set
				{
					if (this._KucniBroj != value)
					{
						this.OnKucniBrojChanging(value);
						this.SendPropertyChanging();
						this._KucniBroj = value;
						this.SendPropertyChanged("KucniBroj");
						this.OnKucniBrojChanged();
					}
					this.SendPropertySetterInvoked("KucniBroj", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(50)
			/// </summary>
			[ColumnAttribute(Storage="_DodatakKucnomBroju", DbType="NVarChar(50)", CanBeNull=true)]
			public string DodatakKucnomBroju
			{
				get
				{
					return this._DodatakKucnomBroju;
				}
				set
				{
					if (this._DodatakKucnomBroju != value)
					{
						this.OnDodatakKucnomBrojuChanging(value);
						this.SendPropertyChanging();
						this._DodatakKucnomBroju = value;
						this.SendPropertyChanged("DodatakKucnomBroju");
						this.OnDodatakKucnomBrojuChanged();
					}
					this.SendPropertySetterInvoked("DodatakKucnomBroju", value);
				}
			}
			
			/// <summary>
			/// Column DbType=VarChar(50)
			/// </summary>
			[ColumnAttribute(Storage="_PostanskiBroj", DbType="VarChar(50)", CanBeNull=true)]
			public string PostanskiBroj
			{
				get
				{
					return this._PostanskiBroj;
				}
				set
				{
					if (this._PostanskiBroj != value)
					{
						this.OnPostanskiBrojChanging(value);
						this.SendPropertyChanging();
						this._PostanskiBroj = value;
						this.SendPropertyChanged("PostanskiBroj");
						this.OnPostanskiBrojChanged();
					}
					this.SendPropertySetterInvoked("PostanskiBroj", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(255)
			/// </summary>
			[ColumnAttribute(Storage="_Mjesto", DbType="NVarChar(255)", CanBeNull=true)]
			public string Mjesto
			{
				get
				{
					return this._Mjesto;
				}
				set
				{
					if (this._Mjesto != value)
					{
						this.OnMjestoChanging(value);
						this.SendPropertyChanging();
						this._Mjesto = value;
						this.SendPropertyChanged("Mjesto");
						this.OnMjestoChanged();
					}
					this.SendPropertySetterInvoked("Mjesto", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(255)
			/// </summary>
			[ColumnAttribute(Storage="_Opcina", DbType="NVarChar(255)", CanBeNull=true)]
			public string Opcina
			{
				get
				{
					return this._Opcina;
				}
				set
				{
					if (this._Opcina != value)
					{
						this.OnOpcinaChanging(value);
						this.SendPropertyChanging();
						this._Opcina = value;
						this.SendPropertyChanged("Opcina");
						this.OnOpcinaChanged();
					}
					this.SendPropertySetterInvoked("Opcina", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(50)
			/// </summary>
			[ColumnAttribute(Storage="_RadnoVrijeme", DbType="NVarChar(50)", CanBeNull=true)]
			public string RadnoVrijeme
			{
				get
				{
					return this._RadnoVrijeme;
				}
				set
				{
					if (this._RadnoVrijeme != value)
					{
						this.OnRadnoVrijemeChanging(value);
						this.SendPropertyChanging();
						this._RadnoVrijeme = value;
						this.SendPropertyChanged("RadnoVrijeme");
						this.OnRadnoVrijemeChanged();
					}
					this.SendPropertySetterInvoked("RadnoVrijeme", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime
			/// </summary>
			[ColumnAttribute(Storage="_PocetakPrimjene", DbType="DateTime", CanBeNull=true)]
			public DateTime? PocetakPrimjene
			{
				get
				{
					return this._PocetakPrimjene;
				}
				set
				{
					if (this._PocetakPrimjene != value)
					{
						this.OnPocetakPrimjeneChanging(value);
						this.SendPropertyChanging();
						this._PocetakPrimjene = value;
						this.SendPropertyChanged("PocetakPrimjene");
						this.OnPocetakPrimjeneChanged();
					}
					this.SendPropertySetterInvoked("PocetakPrimjene", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime
			/// </summary>
			[ColumnAttribute(Storage="_KrajPrimjene", DbType="DateTime", CanBeNull=true)]
			public DateTime? KrajPrimjene
			{
				get
				{
					return this._KrajPrimjene;
				}
				set
				{
					if (this._KrajPrimjene != value)
					{
						this.OnKrajPrimjeneChanging(value);
						this.SendPropertyChanging();
						this._KrajPrimjene = value;
						this.SendPropertyChanged("KrajPrimjene");
						this.OnKrajPrimjeneChanged();
					}
					this.SendPropertySetterInvoked("KrajPrimjene", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime
			/// </summary>
			[ColumnAttribute(Storage="_DatumPrijavePoreznoj", DbType="DateTime", CanBeNull=true)]
			public DateTime? DatumPrijavePoreznoj
			{
				get
				{
					return this._DatumPrijavePoreznoj;
				}
				set
				{
					if (this._DatumPrijavePoreznoj != value)
					{
						this.OnDatumPrijavePoreznojChanging(value);
						this.SendPropertyChanging();
						this._DatumPrijavePoreznoj = value;
						this.SendPropertyChanged("DatumPrijavePoreznoj");
						this.OnDatumPrijavePoreznojChanged();
					}
					this.SendPropertySetterInvoked("DatumPrijavePoreznoj", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime
			/// </summary>
			[ColumnAttribute(Storage="_DatumOdjavePoreznoj", DbType="DateTime", CanBeNull=true)]
			public DateTime? DatumOdjavePoreznoj
			{
				get
				{
					return this._DatumOdjavePoreznoj;
				}
				set
				{
					if (this._DatumOdjavePoreznoj != value)
					{
						this.OnDatumOdjavePoreznojChanging(value);
						this.SendPropertyChanging();
						this._DatumOdjavePoreznoj = value;
						this.SendPropertyChanged("DatumOdjavePoreznoj");
						this.OnDatumOdjavePoreznojChanged();
					}
					this.SendPropertySetterInvoked("DatumOdjavePoreznoj", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(500)
			/// </summary>
			[ColumnAttribute(Storage="_Napomena", DbType="NVarChar(500)", CanBeNull=true)]
			public string Napomena
			{
				get
				{
					return this._Napomena;
				}
				set
				{
					if (this._Napomena != value)
					{
						this.OnNapomenaChanging(value);
						this.SendPropertyChanging();
						this._Napomena = value;
						this.SendPropertyChanged("Napomena");
						this.OnNapomenaChanged();
					}
					this.SendPropertySetterInvoked("Napomena", value);
				}
			}
			
			#endregion Columns

			#region Associations
			/// <summary>
			/// Association [PK][One]tblBillPoslovniProstor.BillPoslovniProstorID --- [FK][Many]tblBillCategory.BillPoslovniProstorID
			/// </summary>
			[AssociationAttribute(Name="FK_tblBillCategory_tblBillPoslovniProstor", Storage="_tblBillCategoryList", ThisKey="BillPoslovniProstorID", OtherKey="BillPoslovniProstorID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<tblBillCategory> tblBillCategoryList
			{
				get { return this._tblBillCategoryList; }
				set { this._tblBillCategoryList.Assign(value); }
			}
			
			/// <summary>
			/// Association [PK][One]tblBillPoslovniProstor.BillPoslovniProstorID --- [FK][Many]tblBillNaplatniUredjaj.BillPoslovniProstorID
			/// </summary>
			[AssociationAttribute(Name="FK_tblBillNaplatniUredjaj_tblBillPoslovniProstor", Storage="_tblBillNaplatniUredjajList", ThisKey="BillPoslovniProstorID", OtherKey="BillPoslovniProstorID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<tblBillNaplatniUredjaj> tblBillNaplatniUredjajList
			{
				get { return this._tblBillNaplatniUredjajList; }
				set { this._tblBillNaplatniUredjajList.Assign(value); }
			}
			
			/// <summary>
			/// Association [PK][One]tblBillPoslovniProstor.BillPoslovniProstorID --- [FK][Many]tblBillPoreznaGrupa.BillPoslovniProstorID
			/// </summary>
			[AssociationAttribute(Name="FK_tblBillPoreznaGrupa_tblBillPoslovniProstor", Storage="_tblBillPoreznaGrupaList", ThisKey="BillPoslovniProstorID", OtherKey="BillPoslovniProstorID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<tblBillPoreznaGrupa> tblBillPoreznaGrupaList
			{
				get { return this._tblBillPoreznaGrupaList; }
				set { this._tblBillPoreznaGrupaList.Assign(value); }
			}
			
			/// <summary>
			/// Association [FK][Many]tblBillPoslovniProstor.BillFirmaID --- [PK][One]tblBillFirma.BillFirmaID
			/// </summary>
			[AssociationAttribute(Name="FK_tblBillPoslovniProstor_tblBillFirma", Storage="_tblBillFirma", ThisKey="BillFirmaID", OtherKey="BillFirmaID", IsUnique=false, IsForeignKey=true)]
			public tblBillFirma tblBillFirma
			{
				get
				{
					return this._tblBillFirma.Entity;
				}
				set
				{
					tblBillFirma previousValue = this._tblBillFirma.Entity;
					if ((previousValue != value) || (this._tblBillFirma.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._tblBillFirma.Entity = null;
							previousValue.tblBillPoslovniProstorList.Remove(this);
						}
						this._tblBillFirma.Entity = value;
						if (value != null)
						{
							value.tblBillPoslovniProstorList.Add(this);
							this._BillFirmaID = value.BillFirmaID;
						}
						else
						{
							this._BillFirmaID = default(int);
						}
						this.SendPropertyChanged("tblBillFirma");
					}
					this.SendPropertySetterInvoked("tblBillFirma", value);
				}
			}
			
			/// <summary>
			/// Association [PK][One]tblBillPoslovniProstor.BillPoslovniProstorID --- [FK][Many]tblBillProduct.BillPoslovniProstorID
			/// </summary>
			[AssociationAttribute(Name="FK_tblBillProduct_tblBillPoslovniProstor", Storage="_tblBillProductList", ThisKey="BillPoslovniProstorID", OtherKey="BillPoslovniProstorID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<tblBillProduct> tblBillProductList
			{
				get { return this._tblBillProductList; }
				set { this._tblBillProductList.Assign(value); }
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
		#endregion dbo.tblBillPoslovniProstor

		#region dbo.tblBillPrintLog
		[TableAttribute(Name="dbo.tblBillPrintLog")]
		public partial class tblBillPrintLog : EntityBase<tblBillPrintLog, dbArizonaAppDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private int _BillPrintLogID;
			private long _AppMemberID;
			private DateTime? _InsertedDate;
			private byte[] _PdfBijeliPapir;
			private byte[] _PdfOpcaUplatnica;
			private byte[] _PdfMemoUplatnica;
			private string _TextLog;
			private EntityRef<tblAppMember> _tblAppMember;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnBillPrintLogIDChanging(int value);
			partial void OnBillPrintLogIDChanged();
			partial void OnAppMemberIDChanging(long value);
			partial void OnAppMemberIDChanged();
			partial void OnInsertedDateChanging(DateTime? value);
			partial void OnInsertedDateChanged();
			partial void OnPdfBijeliPapirChanging(byte[] value);
			partial void OnPdfBijeliPapirChanged();
			partial void OnPdfOpcaUplatnicaChanging(byte[] value);
			partial void OnPdfOpcaUplatnicaChanged();
			partial void OnPdfMemoUplatnicaChanging(byte[] value);
			partial void OnPdfMemoUplatnicaChanged();
			partial void OnTextLogChanging(string value);
			partial void OnTextLogChanged();
			#endregion

			public tblBillPrintLog()
			{
				_tblAppMember = default(EntityRef<tblAppMember>);
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=Int NOT NULL IDENTITY
			/// </summary>
			[ColumnAttribute(Storage="_BillPrintLogID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", CanBeNull=false, IsPrimaryKey=true, IsDbGenerated=true)]
			public int BillPrintLogID
			{
				get
				{
					return this._BillPrintLogID;
				}
				set
				{
					if (this._BillPrintLogID != value)
					{
						this.OnBillPrintLogIDChanging(value);
						this.SendPropertyChanging();
						this._BillPrintLogID = value;
						this.SendPropertyChanged("BillPrintLogID");
						this.OnBillPrintLogIDChanged();
					}
					this.SendPropertySetterInvoked("BillPrintLogID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=BigInt NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_AppMemberID", DbType="BigInt NOT NULL", CanBeNull=false)]
			public long AppMemberID
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
			[ColumnAttribute(Storage="_InsertedDate", DbType="DateTime", CanBeNull=true)]
			public DateTime? InsertedDate
			{
				get
				{
					return this._InsertedDate;
				}
				set
				{
					if (this._InsertedDate != value)
					{
						this.OnInsertedDateChanging(value);
						this.SendPropertyChanging();
						this._InsertedDate = value;
						this.SendPropertyChanged("InsertedDate");
						this.OnInsertedDateChanged();
					}
					this.SendPropertySetterInvoked("InsertedDate", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Image
			/// </summary>
			[ColumnAttribute(Storage="_PdfBijeliPapir", DbType="Image", CanBeNull=true)]
			public byte[] PdfBijeliPapir
			{
				get
				{
					return this._PdfBijeliPapir;
				}
				set
				{
					if (this._PdfBijeliPapir != value)
					{
						this.OnPdfBijeliPapirChanging(value);
						this.SendPropertyChanging();
						this._PdfBijeliPapir = value;
						this.SendPropertyChanged("PdfBijeliPapir");
						this.OnPdfBijeliPapirChanged();
					}
					this.SendPropertySetterInvoked("PdfBijeliPapir", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Image
			/// </summary>
			[ColumnAttribute(Storage="_PdfOpcaUplatnica", DbType="Image", CanBeNull=true)]
			public byte[] PdfOpcaUplatnica
			{
				get
				{
					return this._PdfOpcaUplatnica;
				}
				set
				{
					if (this._PdfOpcaUplatnica != value)
					{
						this.OnPdfOpcaUplatnicaChanging(value);
						this.SendPropertyChanging();
						this._PdfOpcaUplatnica = value;
						this.SendPropertyChanged("PdfOpcaUplatnica");
						this.OnPdfOpcaUplatnicaChanged();
					}
					this.SendPropertySetterInvoked("PdfOpcaUplatnica", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Image
			/// </summary>
			[ColumnAttribute(Storage="_PdfMemoUplatnica", DbType="Image", CanBeNull=true)]
			public byte[] PdfMemoUplatnica
			{
				get
				{
					return this._PdfMemoUplatnica;
				}
				set
				{
					if (this._PdfMemoUplatnica != value)
					{
						this.OnPdfMemoUplatnicaChanging(value);
						this.SendPropertyChanging();
						this._PdfMemoUplatnica = value;
						this.SendPropertyChanged("PdfMemoUplatnica");
						this.OnPdfMemoUplatnicaChanged();
					}
					this.SendPropertySetterInvoked("PdfMemoUplatnica", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NText
			/// </summary>
			[ColumnAttribute(Storage="_TextLog", DbType="NText", CanBeNull=true)]
			public string TextLog
			{
				get
				{
					return this._TextLog;
				}
				set
				{
					if (this._TextLog != value)
					{
						this.OnTextLogChanging(value);
						this.SendPropertyChanging();
						this._TextLog = value;
						this.SendPropertyChanged("TextLog");
						this.OnTextLogChanged();
					}
					this.SendPropertySetterInvoked("TextLog", value);
				}
			}
			
			#endregion Columns

			#region Associations
			/// <summary>
			/// Association [FK][Many]tblBillPrintLog.AppMemberID --- [PK][One]tblAppMember.AppMemberID
			/// </summary>
			[AssociationAttribute(Name="FK_tblBillPrintLog_tblAppMember", Storage="_tblAppMember", ThisKey="AppMemberID", OtherKey="AppMemberID", IsUnique=false, IsForeignKey=true)]
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
							previousValue.tblBillPrintLogList.Remove(this);
						}
						this._tblAppMember.Entity = value;
						if (value != null)
						{
							value.tblBillPrintLogList.Add(this);
							this._AppMemberID = value.AppMemberID;
						}
						else
						{
							this._AppMemberID = default(long);
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
		#endregion dbo.tblBillPrintLog

		#region dbo.tblBillProduct
		[TableAttribute(Name="dbo.tblBillProduct")]
		public partial class tblBillProduct : EntityBase<tblBillProduct, dbArizonaAppDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private long _BillProductID;
			private long _BillPoslovniProstorID;
			private string _Naziv;
			private string _Opis;
			private string _Barcode;
			private decimal _JedinicnaCijena;
			private bool _CijenaJeMPC;
			private int _BillMjeraID;
			private int _Ordinal;
			private bool _IsArtikl;
			private bool _IsNormativ;
			private long _BillPoreznaGrupaID;
			private decimal? _CijenaNakonRoka;
			private int? _BillUslugaTipID;
			private EntitySet<tblBillDocumentStavka> _tblBillDocumentStavkaList;
			private EntityRef<tblBillMjera> _tblBillMjera;
			private EntityRef<tblBillPoreznaGrupa> _tblBillPoreznaGrupa;
			private EntityRef<tblBillPoslovniProstor> _tblBillPoslovniProstor;
			private EntityRef<tblBillUslugaTip> _tblBillUslugaTip;
			private EntitySet<tblBillProductCategory> _tblBillProductCategoryList;
			private EntitySet<tblBillProductNormativ> _tblBillProductNormativList;
			private EntitySet<tblBillProductNormativ> _BillProductList;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnBillProductIDChanging(long value);
			partial void OnBillProductIDChanged();
			partial void OnBillPoslovniProstorIDChanging(long value);
			partial void OnBillPoslovniProstorIDChanged();
			partial void OnNazivChanging(string value);
			partial void OnNazivChanged();
			partial void OnOpisChanging(string value);
			partial void OnOpisChanged();
			partial void OnBarcodeChanging(string value);
			partial void OnBarcodeChanged();
			partial void OnJedinicnaCijenaChanging(decimal value);
			partial void OnJedinicnaCijenaChanged();
			partial void OnCijenaJeMPCChanging(bool value);
			partial void OnCijenaJeMPCChanged();
			partial void OnBillMjeraIDChanging(int value);
			partial void OnBillMjeraIDChanged();
			partial void OnOrdinalChanging(int value);
			partial void OnOrdinalChanged();
			partial void OnIsArtiklChanging(bool value);
			partial void OnIsArtiklChanged();
			partial void OnIsNormativChanging(bool value);
			partial void OnIsNormativChanged();
			partial void OnBillPoreznaGrupaIDChanging(long value);
			partial void OnBillPoreznaGrupaIDChanged();
			partial void OnCijenaNakonRokaChanging(decimal? value);
			partial void OnCijenaNakonRokaChanged();
			partial void OnBillUslugaTipIDChanging(int? value);
			partial void OnBillUslugaTipIDChanged();
			#endregion

			public tblBillProduct()
			{
				_tblBillDocumentStavkaList = new EntitySet<tblBillDocumentStavka>(
					new Action<tblBillDocumentStavka>(item=>{this.SendPropertyChanging(); item.tblBillProduct=this;}), 
					new Action<tblBillDocumentStavka>(item=>{this.SendPropertyChanging(); item.tblBillProduct=null;}));
				_tblBillMjera = default(EntityRef<tblBillMjera>);
				_tblBillPoreznaGrupa = default(EntityRef<tblBillPoreznaGrupa>);
				_tblBillPoslovniProstor = default(EntityRef<tblBillPoslovniProstor>);
				_tblBillUslugaTip = default(EntityRef<tblBillUslugaTip>);
				_tblBillProductCategoryList = new EntitySet<tblBillProductCategory>(
					new Action<tblBillProductCategory>(item=>{this.SendPropertyChanging(); item.tblBillProduct=this;}), 
					new Action<tblBillProductCategory>(item=>{this.SendPropertyChanging(); item.tblBillProduct=null;}));
				_tblBillProductNormativList = new EntitySet<tblBillProductNormativ>(
					new Action<tblBillProductNormativ>(item=>{this.SendPropertyChanging(); item.tblBillProduct=this;}), 
					new Action<tblBillProductNormativ>(item=>{this.SendPropertyChanging(); item.tblBillProduct=null;}));
				_BillProductList = new EntitySet<tblBillProductNormativ>(
					new Action<tblBillProductNormativ>(item=>{this.SendPropertyChanging(); item.NormativBillProduct=this;}), 
					new Action<tblBillProductNormativ>(item=>{this.SendPropertyChanging(); item.NormativBillProduct=null;}));
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=BigInt NOT NULL IDENTITY
			/// </summary>
			[ColumnAttribute(Storage="_BillProductID", AutoSync=AutoSync.OnInsert, DbType="BigInt NOT NULL IDENTITY", CanBeNull=false, IsPrimaryKey=true, IsDbGenerated=true)]
			public long BillProductID
			{
				get
				{
					return this._BillProductID;
				}
				set
				{
					if (this._BillProductID != value)
					{
						this.OnBillProductIDChanging(value);
						this.SendPropertyChanging();
						this._BillProductID = value;
						this.SendPropertyChanged("BillProductID");
						this.OnBillProductIDChanged();
					}
					this.SendPropertySetterInvoked("BillProductID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=BigInt NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_BillPoslovniProstorID", DbType="BigInt NOT NULL", CanBeNull=false)]
			public long BillPoslovniProstorID
			{
				get
				{
					return this._BillPoslovniProstorID;
				}
				set
				{
					if (this._BillPoslovniProstorID != value)
					{
						this.OnBillPoslovniProstorIDChanging(value);
						this.SendPropertyChanging();
						this._BillPoslovniProstorID = value;
						this.SendPropertyChanged("BillPoslovniProstorID");
						this.OnBillPoslovniProstorIDChanged();
					}
					this.SendPropertySetterInvoked("BillPoslovniProstorID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(50) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_Naziv", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
			public string Naziv
			{
				get
				{
					return this._Naziv;
				}
				set
				{
					if (this._Naziv != value)
					{
						this.OnNazivChanging(value);
						this.SendPropertyChanging();
						this._Naziv = value;
						this.SendPropertyChanged("Naziv");
						this.OnNazivChanged();
					}
					this.SendPropertySetterInvoked("Naziv", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(250)
			/// </summary>
			[ColumnAttribute(Storage="_Opis", DbType="NVarChar(250)", CanBeNull=true)]
			public string Opis
			{
				get
				{
					return this._Opis;
				}
				set
				{
					if (this._Opis != value)
					{
						this.OnOpisChanging(value);
						this.SendPropertyChanging();
						this._Opis = value;
						this.SendPropertyChanged("Opis");
						this.OnOpisChanged();
					}
					this.SendPropertySetterInvoked("Opis", value);
				}
			}
			
			/// <summary>
			/// Column DbType=VarChar(50)
			/// </summary>
			[ColumnAttribute(Storage="_Barcode", DbType="VarChar(50)", CanBeNull=true)]
			public string Barcode
			{
				get
				{
					return this._Barcode;
				}
				set
				{
					if (this._Barcode != value)
					{
						this.OnBarcodeChanging(value);
						this.SendPropertyChanging();
						this._Barcode = value;
						this.SendPropertyChanged("Barcode");
						this.OnBarcodeChanged();
					}
					this.SendPropertySetterInvoked("Barcode", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Money NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_JedinicnaCijena", DbType="Money NOT NULL", CanBeNull=false)]
			public decimal JedinicnaCijena
			{
				get
				{
					return this._JedinicnaCijena;
				}
				set
				{
					if (this._JedinicnaCijena != value)
					{
						this.OnJedinicnaCijenaChanging(value);
						this.SendPropertyChanging();
						this._JedinicnaCijena = value;
						this.SendPropertyChanged("JedinicnaCijena");
						this.OnJedinicnaCijenaChanged();
					}
					this.SendPropertySetterInvoked("JedinicnaCijena", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Bit NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_CijenaJeMPC", DbType="Bit NOT NULL", CanBeNull=false)]
			public bool CijenaJeMPC
			{
				get
				{
					return this._CijenaJeMPC;
				}
				set
				{
					if (this._CijenaJeMPC != value)
					{
						this.OnCijenaJeMPCChanging(value);
						this.SendPropertyChanging();
						this._CijenaJeMPC = value;
						this.SendPropertyChanged("CijenaJeMPC");
						this.OnCijenaJeMPCChanged();
					}
					this.SendPropertySetterInvoked("CijenaJeMPC", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_BillMjeraID", DbType="Int NOT NULL", CanBeNull=false)]
			public int BillMjeraID
			{
				get
				{
					return this._BillMjeraID;
				}
				set
				{
					if (this._BillMjeraID != value)
					{
						this.OnBillMjeraIDChanging(value);
						this.SendPropertyChanging();
						this._BillMjeraID = value;
						this.SendPropertyChanged("BillMjeraID");
						this.OnBillMjeraIDChanged();
					}
					this.SendPropertySetterInvoked("BillMjeraID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_Ordinal", DbType="Int NOT NULL", CanBeNull=false)]
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
						this.OnOrdinalChanging(value);
						this.SendPropertyChanging();
						this._Ordinal = value;
						this.SendPropertyChanged("Ordinal");
						this.OnOrdinalChanged();
					}
					this.SendPropertySetterInvoked("Ordinal", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Bit NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_IsArtikl", DbType="Bit NOT NULL", CanBeNull=false)]
			public bool IsArtikl
			{
				get
				{
					return this._IsArtikl;
				}
				set
				{
					if (this._IsArtikl != value)
					{
						this.OnIsArtiklChanging(value);
						this.SendPropertyChanging();
						this._IsArtikl = value;
						this.SendPropertyChanged("IsArtikl");
						this.OnIsArtiklChanged();
					}
					this.SendPropertySetterInvoked("IsArtikl", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Bit NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_IsNormativ", DbType="Bit NOT NULL", CanBeNull=false)]
			public bool IsNormativ
			{
				get
				{
					return this._IsNormativ;
				}
				set
				{
					if (this._IsNormativ != value)
					{
						this.OnIsNormativChanging(value);
						this.SendPropertyChanging();
						this._IsNormativ = value;
						this.SendPropertyChanged("IsNormativ");
						this.OnIsNormativChanged();
					}
					this.SendPropertySetterInvoked("IsNormativ", value);
				}
			}
			
			/// <summary>
			/// Column DbType=BigInt NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_BillPoreznaGrupaID", DbType="BigInt NOT NULL", CanBeNull=false)]
			public long BillPoreznaGrupaID
			{
				get
				{
					return this._BillPoreznaGrupaID;
				}
				set
				{
					if (this._BillPoreznaGrupaID != value)
					{
						this.OnBillPoreznaGrupaIDChanging(value);
						this.SendPropertyChanging();
						this._BillPoreznaGrupaID = value;
						this.SendPropertyChanged("BillPoreznaGrupaID");
						this.OnBillPoreznaGrupaIDChanged();
					}
					this.SendPropertySetterInvoked("BillPoreznaGrupaID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Money
			/// </summary>
			[ColumnAttribute(Storage="_CijenaNakonRoka", DbType="Money", CanBeNull=true)]
			public decimal? CijenaNakonRoka
			{
				get
				{
					return this._CijenaNakonRoka;
				}
				set
				{
					if (this._CijenaNakonRoka != value)
					{
						this.OnCijenaNakonRokaChanging(value);
						this.SendPropertyChanging();
						this._CijenaNakonRoka = value;
						this.SendPropertyChanged("CijenaNakonRoka");
						this.OnCijenaNakonRokaChanged();
					}
					this.SendPropertySetterInvoked("CijenaNakonRoka", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int
			/// </summary>
			[ColumnAttribute(Storage="_BillUslugaTipID", DbType="Int", CanBeNull=true)]
			public int? BillUslugaTipID
			{
				get
				{
					return this._BillUslugaTipID;
				}
				set
				{
					if (this._BillUslugaTipID != value)
					{
						this.OnBillUslugaTipIDChanging(value);
						this.SendPropertyChanging();
						this._BillUslugaTipID = value;
						this.SendPropertyChanged("BillUslugaTipID");
						this.OnBillUslugaTipIDChanged();
					}
					this.SendPropertySetterInvoked("BillUslugaTipID", value);
				}
			}
			
			#endregion Columns

			#region Associations
			/// <summary>
			/// Association [PK][One]tblBillProduct.BillProductID --- [FK][Many]tblBillDocumentStavka.BillProductID
			/// </summary>
			[AssociationAttribute(Name="FK_tblBillDocumentStavka_tblBillProduct", Storage="_tblBillDocumentStavkaList", ThisKey="BillProductID", OtherKey="BillProductID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<tblBillDocumentStavka> tblBillDocumentStavkaList
			{
				get { return this._tblBillDocumentStavkaList; }
				set { this._tblBillDocumentStavkaList.Assign(value); }
			}
			
			/// <summary>
			/// Association [FK][Many]tblBillProduct.BillMjeraID --- [PK][One]tblBillMjera.BillMjeraID
			/// </summary>
			[AssociationAttribute(Name="FK_tblBillProduct_tblBillMjera", Storage="_tblBillMjera", ThisKey="BillMjeraID", OtherKey="BillMjeraID", IsUnique=false, IsForeignKey=true)]
			public tblBillMjera tblBillMjera
			{
				get
				{
					return this._tblBillMjera.Entity;
				}
				set
				{
					tblBillMjera previousValue = this._tblBillMjera.Entity;
					if ((previousValue != value) || (this._tblBillMjera.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._tblBillMjera.Entity = null;
							previousValue.tblBillProductList.Remove(this);
						}
						this._tblBillMjera.Entity = value;
						if (value != null)
						{
							value.tblBillProductList.Add(this);
							this._BillMjeraID = value.BillMjeraID;
						}
						else
						{
							this._BillMjeraID = default(int);
						}
						this.SendPropertyChanged("tblBillMjera");
					}
					this.SendPropertySetterInvoked("tblBillMjera", value);
				}
			}
			
			/// <summary>
			/// Association [FK][Many]tblBillProduct.BillPoreznaGrupaID --- [PK][One]tblBillPoreznaGrupa.BillPoreznaGrupaID
			/// </summary>
			[AssociationAttribute(Name="FK_tblBillProduct_tblBillPoreznaGrupa", Storage="_tblBillPoreznaGrupa", ThisKey="BillPoreznaGrupaID", OtherKey="BillPoreznaGrupaID", IsUnique=false, IsForeignKey=true)]
			public tblBillPoreznaGrupa tblBillPoreznaGrupa
			{
				get
				{
					return this._tblBillPoreznaGrupa.Entity;
				}
				set
				{
					tblBillPoreznaGrupa previousValue = this._tblBillPoreznaGrupa.Entity;
					if ((previousValue != value) || (this._tblBillPoreznaGrupa.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._tblBillPoreznaGrupa.Entity = null;
							previousValue.tblBillProductList.Remove(this);
						}
						this._tblBillPoreznaGrupa.Entity = value;
						if (value != null)
						{
							value.tblBillProductList.Add(this);
							this._BillPoreznaGrupaID = value.BillPoreznaGrupaID;
						}
						else
						{
							this._BillPoreznaGrupaID = default(long);
						}
						this.SendPropertyChanged("tblBillPoreznaGrupa");
					}
					this.SendPropertySetterInvoked("tblBillPoreznaGrupa", value);
				}
			}
			
			/// <summary>
			/// Association [FK][Many]tblBillProduct.BillPoslovniProstorID --- [PK][One]tblBillPoslovniProstor.BillPoslovniProstorID
			/// </summary>
			[AssociationAttribute(Name="FK_tblBillProduct_tblBillPoslovniProstor", Storage="_tblBillPoslovniProstor", ThisKey="BillPoslovniProstorID", OtherKey="BillPoslovniProstorID", IsUnique=false, IsForeignKey=true)]
			public tblBillPoslovniProstor tblBillPoslovniProstor
			{
				get
				{
					return this._tblBillPoslovniProstor.Entity;
				}
				set
				{
					tblBillPoslovniProstor previousValue = this._tblBillPoslovniProstor.Entity;
					if ((previousValue != value) || (this._tblBillPoslovniProstor.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._tblBillPoslovniProstor.Entity = null;
							previousValue.tblBillProductList.Remove(this);
						}
						this._tblBillPoslovniProstor.Entity = value;
						if (value != null)
						{
							value.tblBillProductList.Add(this);
							this._BillPoslovniProstorID = value.BillPoslovniProstorID;
						}
						else
						{
							this._BillPoslovniProstorID = default(long);
						}
						this.SendPropertyChanged("tblBillPoslovniProstor");
					}
					this.SendPropertySetterInvoked("tblBillPoslovniProstor", value);
				}
			}
			
			/// <summary>
			/// Association [FK][Many]tblBillProduct.BillUslugaTipID --- [PK][One]tblBillUslugaTip.BillUslugaTipID
			/// </summary>
			[AssociationAttribute(Name="FK_tblBillProduct_tblBillUslugaTip", Storage="_tblBillUslugaTip", ThisKey="BillUslugaTipID", OtherKey="BillUslugaTipID", IsUnique=false, IsForeignKey=true)]
			public tblBillUslugaTip tblBillUslugaTip
			{
				get
				{
					return this._tblBillUslugaTip.Entity;
				}
				set
				{
					tblBillUslugaTip previousValue = this._tblBillUslugaTip.Entity;
					if ((previousValue != value) || (this._tblBillUslugaTip.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._tblBillUslugaTip.Entity = null;
							previousValue.tblBillProductList.Remove(this);
						}
						this._tblBillUslugaTip.Entity = value;
						if (value != null)
						{
							value.tblBillProductList.Add(this);
							this._BillUslugaTipID = value.BillUslugaTipID;
						}
						else
						{
							this._BillUslugaTipID = default(int?);
						}
						this.SendPropertyChanged("tblBillUslugaTip");
					}
					this.SendPropertySetterInvoked("tblBillUslugaTip", value);
				}
			}
			
			/// <summary>
			/// Association [PK][One]tblBillProduct.BillProductID --- [FK][Many]tblBillProductCategory.BillProductID
			/// </summary>
			[AssociationAttribute(Name="FK_tblBillProductCategory_tblBillProduct", Storage="_tblBillProductCategoryList", ThisKey="BillProductID", OtherKey="BillProductID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<tblBillProductCategory> tblBillProductCategoryList
			{
				get { return this._tblBillProductCategoryList; }
				set { this._tblBillProductCategoryList.Assign(value); }
			}
			
			/// <summary>
			/// Association [PK][One]tblBillProduct.BillProductID --- [FK][Many]tblBillProductNormativ.ArtiklBillProductID
			/// </summary>
			[AssociationAttribute(Name="FK_tblBillProductNormativ_tblBillProduct1", Storage="_tblBillProductNormativList", ThisKey="BillProductID", OtherKey="ArtiklBillProductID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<tblBillProductNormativ> tblBillProductNormativList
			{
				get { return this._tblBillProductNormativList; }
				set { this._tblBillProductNormativList.Assign(value); }
			}
			
			/// <summary>
			/// Association [PK][One]tblBillProduct.BillProductID --- [FK][Many]tblBillProductNormativ.NormativBillProductID
			/// </summary>
			[AssociationAttribute(Name="FK_tblBillProductNormativ_tblBillProduct2", Storage="_BillProductList", ThisKey="BillProductID", OtherKey="NormativBillProductID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<tblBillProductNormativ> BillProductList
			{
				get { return this._BillProductList; }
				set { this._BillProductList.Assign(value); }
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
		#endregion dbo.tblBillProduct

		#region dbo.tblBillProductCategory
		[TableAttribute(Name="dbo.tblBillProductCategory")]
		public partial class tblBillProductCategory : EntityBase<tblBillProductCategory, dbArizonaAppDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private long _BillProductID;
			private long _BillCategoryID;
			private EntityRef<tblBillCategory> _tblBillCategory;
			private EntityRef<tblBillProduct> _tblBillProduct;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnBillProductIDChanging(long value);
			partial void OnBillProductIDChanged();
			partial void OnBillCategoryIDChanging(long value);
			partial void OnBillCategoryIDChanged();
			#endregion

			public tblBillProductCategory()
			{
				_tblBillCategory = default(EntityRef<tblBillCategory>);
				_tblBillProduct = default(EntityRef<tblBillProduct>);
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=BigInt NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_BillProductID", DbType="BigInt NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
			public long BillProductID
			{
				get
				{
					return this._BillProductID;
				}
				set
				{
					if (this._BillProductID != value)
					{
						this.OnBillProductIDChanging(value);
						this.SendPropertyChanging();
						this._BillProductID = value;
						this.SendPropertyChanged("BillProductID");
						this.OnBillProductIDChanged();
					}
					this.SendPropertySetterInvoked("BillProductID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=BigInt NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_BillCategoryID", DbType="BigInt NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
			public long BillCategoryID
			{
				get
				{
					return this._BillCategoryID;
				}
				set
				{
					if (this._BillCategoryID != value)
					{
						this.OnBillCategoryIDChanging(value);
						this.SendPropertyChanging();
						this._BillCategoryID = value;
						this.SendPropertyChanged("BillCategoryID");
						this.OnBillCategoryIDChanged();
					}
					this.SendPropertySetterInvoked("BillCategoryID", value);
				}
			}
			
			#endregion Columns

			#region Associations
			/// <summary>
			/// Association [FK][Many]tblBillProductCategory.BillCategoryID --- [PK][One]tblBillCategory.BillCategoryID
			/// </summary>
			[AssociationAttribute(Name="FK_tblBillProductCategory_tblBillCategory", Storage="_tblBillCategory", ThisKey="BillCategoryID", OtherKey="BillCategoryID", IsUnique=false, IsForeignKey=true)]
			public tblBillCategory tblBillCategory
			{
				get
				{
					return this._tblBillCategory.Entity;
				}
				set
				{
					tblBillCategory previousValue = this._tblBillCategory.Entity;
					if ((previousValue != value) || (this._tblBillCategory.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._tblBillCategory.Entity = null;
							previousValue.tblBillProductCategoryList.Remove(this);
						}
						this._tblBillCategory.Entity = value;
						if (value != null)
						{
							value.tblBillProductCategoryList.Add(this);
							this._BillCategoryID = value.BillCategoryID;
						}
						else
						{
							this._BillCategoryID = default(long);
						}
						this.SendPropertyChanged("tblBillCategory");
					}
					this.SendPropertySetterInvoked("tblBillCategory", value);
				}
			}
			
			/// <summary>
			/// Association [FK][Many]tblBillProductCategory.BillProductID --- [PK][One]tblBillProduct.BillProductID
			/// </summary>
			[AssociationAttribute(Name="FK_tblBillProductCategory_tblBillProduct", Storage="_tblBillProduct", ThisKey="BillProductID", OtherKey="BillProductID", IsUnique=false, IsForeignKey=true)]
			public tblBillProduct tblBillProduct
			{
				get
				{
					return this._tblBillProduct.Entity;
				}
				set
				{
					tblBillProduct previousValue = this._tblBillProduct.Entity;
					if ((previousValue != value) || (this._tblBillProduct.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._tblBillProduct.Entity = null;
							previousValue.tblBillProductCategoryList.Remove(this);
						}
						this._tblBillProduct.Entity = value;
						if (value != null)
						{
							value.tblBillProductCategoryList.Add(this);
							this._BillProductID = value.BillProductID;
						}
						else
						{
							this._BillProductID = default(long);
						}
						this.SendPropertyChanged("tblBillProduct");
					}
					this.SendPropertySetterInvoked("tblBillProduct", value);
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
		#endregion dbo.tblBillProductCategory

		#region dbo.tblBillProductNormativ
		[TableAttribute(Name="dbo.tblBillProductNormativ")]
		public partial class tblBillProductNormativ : EntityBase<tblBillProductNormativ, dbArizonaAppDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private long _ArtiklBillProductID;
			private long _NormativBillProductID;
			private decimal _Kolicina;
			private string _Opis;
			private EntityRef<tblBillProduct> _tblBillProduct;
			private EntityRef<tblBillProduct> _NormativBillProduct;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnArtiklBillProductIDChanging(long value);
			partial void OnArtiklBillProductIDChanged();
			partial void OnNormativBillProductIDChanging(long value);
			partial void OnNormativBillProductIDChanged();
			partial void OnKolicinaChanging(decimal value);
			partial void OnKolicinaChanged();
			partial void OnOpisChanging(string value);
			partial void OnOpisChanged();
			#endregion

			public tblBillProductNormativ()
			{
				_tblBillProduct = default(EntityRef<tblBillProduct>);
				_NormativBillProduct = default(EntityRef<tblBillProduct>);
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=BigInt NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ArtiklBillProductID", DbType="BigInt NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
			public long ArtiklBillProductID
			{
				get
				{
					return this._ArtiklBillProductID;
				}
				set
				{
					if (this._ArtiklBillProductID != value)
					{
						this.OnArtiklBillProductIDChanging(value);
						this.SendPropertyChanging();
						this._ArtiklBillProductID = value;
						this.SendPropertyChanged("ArtiklBillProductID");
						this.OnArtiklBillProductIDChanged();
					}
					this.SendPropertySetterInvoked("ArtiklBillProductID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=BigInt NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_NormativBillProductID", DbType="BigInt NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
			public long NormativBillProductID
			{
				get
				{
					return this._NormativBillProductID;
				}
				set
				{
					if (this._NormativBillProductID != value)
					{
						this.OnNormativBillProductIDChanging(value);
						this.SendPropertyChanging();
						this._NormativBillProductID = value;
						this.SendPropertyChanged("NormativBillProductID");
						this.OnNormativBillProductIDChanged();
					}
					this.SendPropertySetterInvoked("NormativBillProductID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Decimal(18,8) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_Kolicina", DbType="Decimal(18,8) NOT NULL", CanBeNull=false)]
			public decimal Kolicina
			{
				get
				{
					return this._Kolicina;
				}
				set
				{
					if (this._Kolicina != value)
					{
						this.OnKolicinaChanging(value);
						this.SendPropertyChanging();
						this._Kolicina = value;
						this.SendPropertyChanged("Kolicina");
						this.OnKolicinaChanged();
					}
					this.SendPropertySetterInvoked("Kolicina", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(250)
			/// </summary>
			[ColumnAttribute(Storage="_Opis", DbType="NVarChar(250)", CanBeNull=true)]
			public string Opis
			{
				get
				{
					return this._Opis;
				}
				set
				{
					if (this._Opis != value)
					{
						this.OnOpisChanging(value);
						this.SendPropertyChanging();
						this._Opis = value;
						this.SendPropertyChanged("Opis");
						this.OnOpisChanged();
					}
					this.SendPropertySetterInvoked("Opis", value);
				}
			}
			
			#endregion Columns

			#region Associations
			/// <summary>
			/// Association [FK][Many]tblBillProductNormativ.ArtiklBillProductID --- [PK][One]tblBillProduct.BillProductID
			/// </summary>
			[AssociationAttribute(Name="FK_tblBillProductNormativ_tblBillProduct1", Storage="_tblBillProduct", ThisKey="ArtiklBillProductID", OtherKey="BillProductID", IsUnique=false, IsForeignKey=true)]
			public tblBillProduct tblBillProduct
			{
				get
				{
					return this._tblBillProduct.Entity;
				}
				set
				{
					tblBillProduct previousValue = this._tblBillProduct.Entity;
					if ((previousValue != value) || (this._tblBillProduct.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._tblBillProduct.Entity = null;
							previousValue.tblBillProductNormativList.Remove(this);
						}
						this._tblBillProduct.Entity = value;
						if (value != null)
						{
							value.tblBillProductNormativList.Add(this);
							this._ArtiklBillProductID = value.BillProductID;
						}
						else
						{
							this._ArtiklBillProductID = default(long);
						}
						this.SendPropertyChanged("tblBillProduct");
					}
					this.SendPropertySetterInvoked("tblBillProduct", value);
				}
			}
			
			/// <summary>
			/// Association [FK][Many]tblBillProductNormativ.NormativBillProductID --- [PK][One]tblBillProduct.BillProductID
			/// </summary>
			[AssociationAttribute(Name="FK_tblBillProductNormativ_tblBillProduct2", Storage="_NormativBillProduct", ThisKey="NormativBillProductID", OtherKey="BillProductID", IsUnique=false, IsForeignKey=true)]
			public tblBillProduct NormativBillProduct
			{
				get
				{
					return this._NormativBillProduct.Entity;
				}
				set
				{
					tblBillProduct previousValue = this._NormativBillProduct.Entity;
					if ((previousValue != value) || (this._NormativBillProduct.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._NormativBillProduct.Entity = null;
							previousValue.BillProductList.Remove(this);
						}
						this._NormativBillProduct.Entity = value;
						if (value != null)
						{
							value.BillProductList.Add(this);
							this._NormativBillProductID = value.BillProductID;
						}
						else
						{
							this._NormativBillProductID = default(long);
						}
						this.SendPropertyChanged("NormativBillProduct");
					}
					this.SendPropertySetterInvoked("NormativBillProduct", value);
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
		#endregion dbo.tblBillProductNormativ

		#region dbo.tblBillUslugaTip
		[TableAttribute(Name="dbo.tblBillUslugaTip")]
		public partial class tblBillUslugaTip : EntityBase<tblBillUslugaTip, dbArizonaAppDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private int _BillUslugaTipID;
			private string _Naziv;
			private EntitySet<tblBillProduct> _tblBillProductList;
			private EntitySet<tblDirClientGratis> _tblDirClientGratisList;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnBillUslugaTipIDChanging(int value);
			partial void OnBillUslugaTipIDChanged();
			partial void OnNazivChanging(string value);
			partial void OnNazivChanged();
			#endregion

			public tblBillUslugaTip()
			{
				_tblBillProductList = new EntitySet<tblBillProduct>(
					new Action<tblBillProduct>(item=>{this.SendPropertyChanging(); item.tblBillUslugaTip=this;}), 
					new Action<tblBillProduct>(item=>{this.SendPropertyChanging(); item.tblBillUslugaTip=null;}));
				_tblDirClientGratisList = new EntitySet<tblDirClientGratis>(
					new Action<tblDirClientGratis>(item=>{this.SendPropertyChanging(); item.tblBillUslugaTip=this;}), 
					new Action<tblDirClientGratis>(item=>{this.SendPropertyChanging(); item.tblBillUslugaTip=null;}));
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_BillUslugaTipID", DbType="Int NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
			public int BillUslugaTipID
			{
				get
				{
					return this._BillUslugaTipID;
				}
				set
				{
					if (this._BillUslugaTipID != value)
					{
						this.OnBillUslugaTipIDChanging(value);
						this.SendPropertyChanging();
						this._BillUslugaTipID = value;
						this.SendPropertyChanged("BillUslugaTipID");
						this.OnBillUslugaTipIDChanged();
					}
					this.SendPropertySetterInvoked("BillUslugaTipID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(50) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_Naziv", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
			public string Naziv
			{
				get
				{
					return this._Naziv;
				}
				set
				{
					if (this._Naziv != value)
					{
						this.OnNazivChanging(value);
						this.SendPropertyChanging();
						this._Naziv = value;
						this.SendPropertyChanged("Naziv");
						this.OnNazivChanged();
					}
					this.SendPropertySetterInvoked("Naziv", value);
				}
			}
			
			#endregion Columns

			#region Associations
			/// <summary>
			/// Association [PK][One]tblBillUslugaTip.BillUslugaTipID --- [FK][Many]tblBillProduct.BillUslugaTipID
			/// </summary>
			[AssociationAttribute(Name="FK_tblBillProduct_tblBillUslugaTip", Storage="_tblBillProductList", ThisKey="BillUslugaTipID", OtherKey="BillUslugaTipID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<tblBillProduct> tblBillProductList
			{
				get { return this._tblBillProductList; }
				set { this._tblBillProductList.Assign(value); }
			}
			
			/// <summary>
			/// Association [PK][One]tblBillUslugaTip.BillUslugaTipID --- [FK][Many]tblDirClientGratis.BillUslugaTipID
			/// </summary>
			[AssociationAttribute(Name="FK_tblDirClientGratis_tblBillUslugaTip", Storage="_tblDirClientGratisList", ThisKey="BillUslugaTipID", OtherKey="BillUslugaTipID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<tblDirClientGratis> tblDirClientGratisList
			{
				get { return this._tblDirClientGratisList; }
				set { this._tblDirClientGratisList.Assign(value); }
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
		#endregion dbo.tblBillUslugaTip

		#region dbo.tblBookkeepingFiduciaExport
		[TableAttribute(Name="dbo.tblBookkeepingFiduciaExport")]
		public partial class tblBookkeepingFiduciaExport : EntityBase<tblBookkeepingFiduciaExport, dbArizonaAppDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private int _FiduciaExportID;
			private DateTime _DatumGeneriranja;
			private int _BillFirmaID;
			private DateTime _StartDateIncluded;
			private DateTime _EndDateExcluded;
			private byte[] _AllData;
			private byte[] _Klijenti;
			private byte[] _RacuniKonta;
			private byte[] _RacuniKnjiga;
			private byte[] _Preknjizenja;
			private EntityRef<tblBillFirma> _tblBillFirma;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnFiduciaExportIDChanging(int value);
			partial void OnFiduciaExportIDChanged();
			partial void OnDatumGeneriranjaChanging(DateTime value);
			partial void OnDatumGeneriranjaChanged();
			partial void OnBillFirmaIDChanging(int value);
			partial void OnBillFirmaIDChanged();
			partial void OnStartDateIncludedChanging(DateTime value);
			partial void OnStartDateIncludedChanged();
			partial void OnEndDateExcludedChanging(DateTime value);
			partial void OnEndDateExcludedChanged();
			partial void OnAllDataChanging(byte[] value);
			partial void OnAllDataChanged();
			partial void OnKlijentiChanging(byte[] value);
			partial void OnKlijentiChanged();
			partial void OnRacuniKontaChanging(byte[] value);
			partial void OnRacuniKontaChanged();
			partial void OnRacuniKnjigaChanging(byte[] value);
			partial void OnRacuniKnjigaChanged();
			partial void OnPreknjizenjaChanging(byte[] value);
			partial void OnPreknjizenjaChanged();
			#endregion

			public tblBookkeepingFiduciaExport()
			{
				_tblBillFirma = default(EntityRef<tblBillFirma>);
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=Int NOT NULL IDENTITY
			/// </summary>
			[ColumnAttribute(Storage="_FiduciaExportID", AutoSync=AutoSync.Always, DbType="Int NOT NULL IDENTITY", CanBeNull=false, IsDbGenerated=true)]
			public int FiduciaExportID
			{
				get
				{
					return this._FiduciaExportID;
				}
				set
				{
					if (this._FiduciaExportID != value)
					{
						this.OnFiduciaExportIDChanging(value);
						this.SendPropertyChanging();
						this._FiduciaExportID = value;
						this.SendPropertyChanged("FiduciaExportID");
						this.OnFiduciaExportIDChanged();
					}
					this.SendPropertySetterInvoked("FiduciaExportID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_DatumGeneriranja", DbType="DateTime NOT NULL", CanBeNull=false)]
			public DateTime DatumGeneriranja
			{
				get
				{
					return this._DatumGeneriranja;
				}
				set
				{
					if (this._DatumGeneriranja != value)
					{
						this.OnDatumGeneriranjaChanging(value);
						this.SendPropertyChanging();
						this._DatumGeneriranja = value;
						this.SendPropertyChanged("DatumGeneriranja");
						this.OnDatumGeneriranjaChanged();
					}
					this.SendPropertySetterInvoked("DatumGeneriranja", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_BillFirmaID", DbType="Int NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
			public int BillFirmaID
			{
				get
				{
					return this._BillFirmaID;
				}
				set
				{
					if (this._BillFirmaID != value)
					{
						this.OnBillFirmaIDChanging(value);
						this.SendPropertyChanging();
						this._BillFirmaID = value;
						this.SendPropertyChanged("BillFirmaID");
						this.OnBillFirmaIDChanged();
					}
					this.SendPropertySetterInvoked("BillFirmaID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_StartDateIncluded", DbType="DateTime NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
			public DateTime StartDateIncluded
			{
				get
				{
					return this._StartDateIncluded;
				}
				set
				{
					if (this._StartDateIncluded != value)
					{
						this.OnStartDateIncludedChanging(value);
						this.SendPropertyChanging();
						this._StartDateIncluded = value;
						this.SendPropertyChanged("StartDateIncluded");
						this.OnStartDateIncludedChanged();
					}
					this.SendPropertySetterInvoked("StartDateIncluded", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_EndDateExcluded", DbType="DateTime NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
			public DateTime EndDateExcluded
			{
				get
				{
					return this._EndDateExcluded;
				}
				set
				{
					if (this._EndDateExcluded != value)
					{
						this.OnEndDateExcludedChanging(value);
						this.SendPropertyChanging();
						this._EndDateExcluded = value;
						this.SendPropertyChanged("EndDateExcluded");
						this.OnEndDateExcludedChanged();
					}
					this.SendPropertySetterInvoked("EndDateExcluded", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Image
			/// </summary>
			[ColumnAttribute(Storage="_AllData", DbType="Image", CanBeNull=true)]
			public byte[] AllData
			{
				get
				{
					return this._AllData;
				}
				set
				{
					if (this._AllData != value)
					{
						this.OnAllDataChanging(value);
						this.SendPropertyChanging();
						this._AllData = value;
						this.SendPropertyChanged("AllData");
						this.OnAllDataChanged();
					}
					this.SendPropertySetterInvoked("AllData", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Image
			/// </summary>
			[ColumnAttribute(Storage="_Klijenti", DbType="Image", CanBeNull=true)]
			public byte[] Klijenti
			{
				get
				{
					return this._Klijenti;
				}
				set
				{
					if (this._Klijenti != value)
					{
						this.OnKlijentiChanging(value);
						this.SendPropertyChanging();
						this._Klijenti = value;
						this.SendPropertyChanged("Klijenti");
						this.OnKlijentiChanged();
					}
					this.SendPropertySetterInvoked("Klijenti", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Image
			/// </summary>
			[ColumnAttribute(Storage="_RacuniKonta", DbType="Image", CanBeNull=true)]
			public byte[] RacuniKonta
			{
				get
				{
					return this._RacuniKonta;
				}
				set
				{
					if (this._RacuniKonta != value)
					{
						this.OnRacuniKontaChanging(value);
						this.SendPropertyChanging();
						this._RacuniKonta = value;
						this.SendPropertyChanged("RacuniKonta");
						this.OnRacuniKontaChanged();
					}
					this.SendPropertySetterInvoked("RacuniKonta", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Image
			/// </summary>
			[ColumnAttribute(Storage="_RacuniKnjiga", DbType="Image", CanBeNull=true)]
			public byte[] RacuniKnjiga
			{
				get
				{
					return this._RacuniKnjiga;
				}
				set
				{
					if (this._RacuniKnjiga != value)
					{
						this.OnRacuniKnjigaChanging(value);
						this.SendPropertyChanging();
						this._RacuniKnjiga = value;
						this.SendPropertyChanged("RacuniKnjiga");
						this.OnRacuniKnjigaChanged();
					}
					this.SendPropertySetterInvoked("RacuniKnjiga", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Image
			/// </summary>
			[ColumnAttribute(Storage="_Preknjizenja", DbType="Image", CanBeNull=true)]
			public byte[] Preknjizenja
			{
				get
				{
					return this._Preknjizenja;
				}
				set
				{
					if (this._Preknjizenja != value)
					{
						this.OnPreknjizenjaChanging(value);
						this.SendPropertyChanging();
						this._Preknjizenja = value;
						this.SendPropertyChanged("Preknjizenja");
						this.OnPreknjizenjaChanged();
					}
					this.SendPropertySetterInvoked("Preknjizenja", value);
				}
			}
			
			#endregion Columns

			#region Associations
			/// <summary>
			/// Association [FK][Many]tblBookkeepingFiduciaExport.BillFirmaID --- [PK][One]tblBillFirma.BillFirmaID
			/// </summary>
			[AssociationAttribute(Name="FK_tblBookkeepinglFiduciaExport_tblBillFirma", Storage="_tblBillFirma", ThisKey="BillFirmaID", OtherKey="BillFirmaID", IsUnique=false, IsForeignKey=true)]
			public tblBillFirma tblBillFirma
			{
				get
				{
					return this._tblBillFirma.Entity;
				}
				set
				{
					tblBillFirma previousValue = this._tblBillFirma.Entity;
					if ((previousValue != value) || (this._tblBillFirma.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._tblBillFirma.Entity = null;
							previousValue.tblBookkeepingFiduciaExportList.Remove(this);
						}
						this._tblBillFirma.Entity = value;
						if (value != null)
						{
							value.tblBookkeepingFiduciaExportList.Add(this);
							this._BillFirmaID = value.BillFirmaID;
						}
						else
						{
							this._BillFirmaID = default(int);
						}
						this.SendPropertyChanged("tblBillFirma");
					}
					this.SendPropertySetterInvoked("tblBillFirma", value);
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
		#endregion dbo.tblBookkeepingFiduciaExport

		#region dbo.tblBookkeepingSynesisExport
		[TableAttribute(Name="dbo.tblBookkeepingSynesisExport")]
		public partial class tblBookkeepingSynesisExport : EntityBase<tblBookkeepingSynesisExport, dbArizonaAppDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private int _SynesisExportID;
			private DateTime _DatumGeneriranja;
			private int _BillFirmaID;
			private DateTime _StartDateIncluded;
			private DateTime _EndDateExcluded;
			private byte[] _AllData;
			private byte[] _Klijenti;
			private byte[] _FinancKnjig;
			private byte[] _UlazniRacuni;
			private byte[] _IzlazniRacuni;
			private EntityRef<tblBillFirma> _tblBillFirma;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnSynesisExportIDChanging(int value);
			partial void OnSynesisExportIDChanged();
			partial void OnDatumGeneriranjaChanging(DateTime value);
			partial void OnDatumGeneriranjaChanged();
			partial void OnBillFirmaIDChanging(int value);
			partial void OnBillFirmaIDChanged();
			partial void OnStartDateIncludedChanging(DateTime value);
			partial void OnStartDateIncludedChanged();
			partial void OnEndDateExcludedChanging(DateTime value);
			partial void OnEndDateExcludedChanged();
			partial void OnAllDataChanging(byte[] value);
			partial void OnAllDataChanged();
			partial void OnKlijentiChanging(byte[] value);
			partial void OnKlijentiChanged();
			partial void OnFinancKnjigChanging(byte[] value);
			partial void OnFinancKnjigChanged();
			partial void OnUlazniRacuniChanging(byte[] value);
			partial void OnUlazniRacuniChanged();
			partial void OnIzlazniRacuniChanging(byte[] value);
			partial void OnIzlazniRacuniChanged();
			#endregion

			public tblBookkeepingSynesisExport()
			{
				_tblBillFirma = default(EntityRef<tblBillFirma>);
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=Int NOT NULL IDENTITY
			/// </summary>
			[ColumnAttribute(Storage="_SynesisExportID", AutoSync=AutoSync.Always, DbType="Int NOT NULL IDENTITY", CanBeNull=false, IsDbGenerated=true)]
			public int SynesisExportID
			{
				get
				{
					return this._SynesisExportID;
				}
				set
				{
					if (this._SynesisExportID != value)
					{
						this.OnSynesisExportIDChanging(value);
						this.SendPropertyChanging();
						this._SynesisExportID = value;
						this.SendPropertyChanged("SynesisExportID");
						this.OnSynesisExportIDChanged();
					}
					this.SendPropertySetterInvoked("SynesisExportID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_DatumGeneriranja", DbType="DateTime NOT NULL", CanBeNull=false)]
			public DateTime DatumGeneriranja
			{
				get
				{
					return this._DatumGeneriranja;
				}
				set
				{
					if (this._DatumGeneriranja != value)
					{
						this.OnDatumGeneriranjaChanging(value);
						this.SendPropertyChanging();
						this._DatumGeneriranja = value;
						this.SendPropertyChanged("DatumGeneriranja");
						this.OnDatumGeneriranjaChanged();
					}
					this.SendPropertySetterInvoked("DatumGeneriranja", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_BillFirmaID", DbType="Int NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
			public int BillFirmaID
			{
				get
				{
					return this._BillFirmaID;
				}
				set
				{
					if (this._BillFirmaID != value)
					{
						this.OnBillFirmaIDChanging(value);
						this.SendPropertyChanging();
						this._BillFirmaID = value;
						this.SendPropertyChanged("BillFirmaID");
						this.OnBillFirmaIDChanged();
					}
					this.SendPropertySetterInvoked("BillFirmaID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_StartDateIncluded", DbType="DateTime NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
			public DateTime StartDateIncluded
			{
				get
				{
					return this._StartDateIncluded;
				}
				set
				{
					if (this._StartDateIncluded != value)
					{
						this.OnStartDateIncludedChanging(value);
						this.SendPropertyChanging();
						this._StartDateIncluded = value;
						this.SendPropertyChanged("StartDateIncluded");
						this.OnStartDateIncludedChanged();
					}
					this.SendPropertySetterInvoked("StartDateIncluded", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_EndDateExcluded", DbType="DateTime NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
			public DateTime EndDateExcluded
			{
				get
				{
					return this._EndDateExcluded;
				}
				set
				{
					if (this._EndDateExcluded != value)
					{
						this.OnEndDateExcludedChanging(value);
						this.SendPropertyChanging();
						this._EndDateExcluded = value;
						this.SendPropertyChanged("EndDateExcluded");
						this.OnEndDateExcludedChanged();
					}
					this.SendPropertySetterInvoked("EndDateExcluded", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Image
			/// </summary>
			[ColumnAttribute(Storage="_AllData", DbType="Image", CanBeNull=true)]
			public byte[] AllData
			{
				get
				{
					return this._AllData;
				}
				set
				{
					if (this._AllData != value)
					{
						this.OnAllDataChanging(value);
						this.SendPropertyChanging();
						this._AllData = value;
						this.SendPropertyChanged("AllData");
						this.OnAllDataChanged();
					}
					this.SendPropertySetterInvoked("AllData", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Image
			/// </summary>
			[ColumnAttribute(Storage="_Klijenti", DbType="Image", CanBeNull=true)]
			public byte[] Klijenti
			{
				get
				{
					return this._Klijenti;
				}
				set
				{
					if (this._Klijenti != value)
					{
						this.OnKlijentiChanging(value);
						this.SendPropertyChanging();
						this._Klijenti = value;
						this.SendPropertyChanged("Klijenti");
						this.OnKlijentiChanged();
					}
					this.SendPropertySetterInvoked("Klijenti", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Image
			/// </summary>
			[ColumnAttribute(Storage="_FinancKnjig", DbType="Image", CanBeNull=true)]
			public byte[] FinancKnjig
			{
				get
				{
					return this._FinancKnjig;
				}
				set
				{
					if (this._FinancKnjig != value)
					{
						this.OnFinancKnjigChanging(value);
						this.SendPropertyChanging();
						this._FinancKnjig = value;
						this.SendPropertyChanged("FinancKnjig");
						this.OnFinancKnjigChanged();
					}
					this.SendPropertySetterInvoked("FinancKnjig", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Image
			/// </summary>
			[ColumnAttribute(Storage="_UlazniRacuni", DbType="Image", CanBeNull=true)]
			public byte[] UlazniRacuni
			{
				get
				{
					return this._UlazniRacuni;
				}
				set
				{
					if (this._UlazniRacuni != value)
					{
						this.OnUlazniRacuniChanging(value);
						this.SendPropertyChanging();
						this._UlazniRacuni = value;
						this.SendPropertyChanged("UlazniRacuni");
						this.OnUlazniRacuniChanged();
					}
					this.SendPropertySetterInvoked("UlazniRacuni", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Image
			/// </summary>
			[ColumnAttribute(Storage="_IzlazniRacuni", DbType="Image", CanBeNull=true)]
			public byte[] IzlazniRacuni
			{
				get
				{
					return this._IzlazniRacuni;
				}
				set
				{
					if (this._IzlazniRacuni != value)
					{
						this.OnIzlazniRacuniChanging(value);
						this.SendPropertyChanging();
						this._IzlazniRacuni = value;
						this.SendPropertyChanged("IzlazniRacuni");
						this.OnIzlazniRacuniChanged();
					}
					this.SendPropertySetterInvoked("IzlazniRacuni", value);
				}
			}
			
			#endregion Columns

			#region Associations
			/// <summary>
			/// Association [FK][Many]tblBookkeepingSynesisExport.BillFirmaID --- [PK][One]tblBillFirma.BillFirmaID
			/// </summary>
			[AssociationAttribute(Name="FK_tblBookkeepingSynesisExport_tblBillFirma", Storage="_tblBillFirma", ThisKey="BillFirmaID", OtherKey="BillFirmaID", IsUnique=false, IsForeignKey=true)]
			public tblBillFirma tblBillFirma
			{
				get
				{
					return this._tblBillFirma.Entity;
				}
				set
				{
					tblBillFirma previousValue = this._tblBillFirma.Entity;
					if ((previousValue != value) || (this._tblBillFirma.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._tblBillFirma.Entity = null;
							previousValue.tblBookkeepingSynesisExportList.Remove(this);
						}
						this._tblBillFirma.Entity = value;
						if (value != null)
						{
							value.tblBookkeepingSynesisExportList.Add(this);
							this._BillFirmaID = value.BillFirmaID;
						}
						else
						{
							this._BillFirmaID = default(int);
						}
						this.SendPropertyChanged("tblBillFirma");
					}
					this.SendPropertySetterInvoked("tblBillFirma", value);
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
		#endregion dbo.tblBookkeepingSynesisExport

		#region dbo.tblCache
		[TableAttribute(Name="dbo.tblCache")]
		public partial class tblCache : EntityBase<tblCache, dbArizonaAppDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private string _CacheKey;
			private DateTime _InsertionDate;
			private DateTime? _ExpirationDate;
			private byte[] _CachedValue;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnCacheKeyChanging(string value);
			partial void OnCacheKeyChanged();
			partial void OnInsertionDateChanging(DateTime value);
			partial void OnInsertionDateChanged();
			partial void OnExpirationDateChanging(DateTime? value);
			partial void OnExpirationDateChanged();
			partial void OnCachedValueChanging(byte[] value);
			partial void OnCachedValueChanged();
			#endregion

			public tblCache()
			{
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=VarChar(900) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_CacheKey", DbType="VarChar(900) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
			public string CacheKey
			{
				get
				{
					return this._CacheKey;
				}
				set
				{
					if (this._CacheKey != value)
					{
						this.OnCacheKeyChanging(value);
						this.SendPropertyChanging();
						this._CacheKey = value;
						this.SendPropertyChanged("CacheKey");
						this.OnCacheKeyChanged();
					}
					this.SendPropertySetterInvoked("CacheKey", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_InsertionDate", DbType="DateTime NOT NULL", CanBeNull=false)]
			public DateTime InsertionDate
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
			/// Column DbType=DateTime
			/// </summary>
			[ColumnAttribute(Storage="_ExpirationDate", DbType="DateTime", CanBeNull=true)]
			public DateTime? ExpirationDate
			{
				get
				{
					return this._ExpirationDate;
				}
				set
				{
					if (this._ExpirationDate != value)
					{
						this.OnExpirationDateChanging(value);
						this.SendPropertyChanging();
						this._ExpirationDate = value;
						this.SendPropertyChanged("ExpirationDate");
						this.OnExpirationDateChanged();
					}
					this.SendPropertySetterInvoked("ExpirationDate", value);
				}
			}
			
			/// <summary>
			/// Column DbType=VarBinary(MAX)
			/// </summary>
			[ColumnAttribute(Storage="_CachedValue", DbType="VarBinary(MAX)", CanBeNull=true)]
			public byte[] CachedValue
			{
				get
				{
					return this._CachedValue;
				}
				set
				{
					if (this._CachedValue != value)
					{
						this.OnCachedValueChanging(value);
						this.SendPropertyChanging();
						this._CachedValue = value;
						this.SendPropertyChanged("CachedValue");
						this.OnCachedValueChanged();
					}
					this.SendPropertySetterInvoked("CachedValue", value);
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
		#endregion dbo.tblCache

		#region dbo.tblDirClient
		[TableAttribute(Name="dbo.tblDirClient")]
		public partial class tblDirClient : EntityBase<tblDirClient, dbArizonaAppDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private int _ArizonaClientID;
			private string _MBO;
			private string _MBS;
			private string _OIB;
			private DateTime? _datumObjave;
			private DateTime? _datumOsnivanja;
			private DateTime? _datumZatvaranja;
			private DateTime? _insertionDate;
			private string _Naziv;
			private string _Adresa;
			private string _Naselje;
			private string _PostanskiBroj;
			private string _PostanskiUred;
			private string _Web;
			private string _Email;
			private string _Telefon1;
			private string _Telefon2;
			private int? _NkdRowID;
			private string _KljucneRijeci;
			private string _Opis;
			private string _RadnoVrijeme;
			private DateTime? _LastModified;
			private string _odgovornaOsoba;
			private bool? _isVlasnik;
			private EntitySet<tblBillClient> _tblBillClientList;
			private EntityRef<tblDirClientFullText> _tblDirClientFullText;
			private EntityRef<tblDirClientGratis> _tblDirClientGratis;
			private EntitySet<tblDirClientPhone> _tblDirClientPhoneList;
			private EntitySet<tblDirClientPicture> _tblDirClientPictureList;
			private EntityRef<tblDirClientPrikazStatus> _tblDirClientPrikazStatus;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnArizonaClientIDChanging(int value);
			partial void OnArizonaClientIDChanged();
			partial void OnMBOChanging(string value);
			partial void OnMBOChanged();
			partial void OnMBSChanging(string value);
			partial void OnMBSChanged();
			partial void OnOIBChanging(string value);
			partial void OnOIBChanged();
			partial void OndatumObjaveChanging(DateTime? value);
			partial void OndatumObjaveChanged();
			partial void OndatumOsnivanjaChanging(DateTime? value);
			partial void OndatumOsnivanjaChanged();
			partial void OndatumZatvaranjaChanging(DateTime? value);
			partial void OndatumZatvaranjaChanged();
			partial void OninsertionDateChanging(DateTime? value);
			partial void OninsertionDateChanged();
			partial void OnNazivChanging(string value);
			partial void OnNazivChanged();
			partial void OnAdresaChanging(string value);
			partial void OnAdresaChanged();
			partial void OnNaseljeChanging(string value);
			partial void OnNaseljeChanged();
			partial void OnPostanskiBrojChanging(string value);
			partial void OnPostanskiBrojChanged();
			partial void OnPostanskiUredChanging(string value);
			partial void OnPostanskiUredChanged();
			partial void OnWebChanging(string value);
			partial void OnWebChanged();
			partial void OnEmailChanging(string value);
			partial void OnEmailChanged();
			partial void OnTelefon1Changing(string value);
			partial void OnTelefon1Changed();
			partial void OnTelefon2Changing(string value);
			partial void OnTelefon2Changed();
			partial void OnNkdRowIDChanging(int? value);
			partial void OnNkdRowIDChanged();
			partial void OnKljucneRijeciChanging(string value);
			partial void OnKljucneRijeciChanged();
			partial void OnOpisChanging(string value);
			partial void OnOpisChanged();
			partial void OnRadnoVrijemeChanging(string value);
			partial void OnRadnoVrijemeChanged();
			partial void OnLastModifiedChanging(DateTime? value);
			partial void OnLastModifiedChanged();
			partial void OnodgovornaOsobaChanging(string value);
			partial void OnodgovornaOsobaChanged();
			partial void OnisVlasnikChanging(bool? value);
			partial void OnisVlasnikChanged();
			#endregion

			public tblDirClient()
			{
				_tblBillClientList = new EntitySet<tblBillClient>(
					new Action<tblBillClient>(item=>{this.SendPropertyChanging(); item.tblDirClient=this;}), 
					new Action<tblBillClient>(item=>{this.SendPropertyChanging(); item.tblDirClient=null;}));
				_tblDirClientFullText = default(EntityRef<tblDirClientFullText>);
				_tblDirClientGratis = default(EntityRef<tblDirClientGratis>);
				_tblDirClientPhoneList = new EntitySet<tblDirClientPhone>(
					new Action<tblDirClientPhone>(item=>{this.SendPropertyChanging(); item.tblDirClient=this;}), 
					new Action<tblDirClientPhone>(item=>{this.SendPropertyChanging(); item.tblDirClient=null;}));
				_tblDirClientPictureList = new EntitySet<tblDirClientPicture>(
					new Action<tblDirClientPicture>(item=>{this.SendPropertyChanging(); item.tblDirClient=this;}), 
					new Action<tblDirClientPicture>(item=>{this.SendPropertyChanging(); item.tblDirClient=null;}));
				_tblDirClientPrikazStatus = default(EntityRef<tblDirClientPrikazStatus>);
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ArizonaClientID", DbType="Int NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
			public int ArizonaClientID
			{
				get
				{
					return this._ArizonaClientID;
				}
				set
				{
					if (this._ArizonaClientID != value)
					{
						this.OnArizonaClientIDChanging(value);
						this.SendPropertyChanging();
						this._ArizonaClientID = value;
						this.SendPropertyChanged("ArizonaClientID");
						this.OnArizonaClientIDChanged();
					}
					this.SendPropertySetterInvoked("ArizonaClientID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=VarChar(20)
			/// </summary>
			[ColumnAttribute(Storage="_MBO", DbType="VarChar(20)", CanBeNull=true)]
			public string MBO
			{
				get
				{
					return this._MBO;
				}
				set
				{
					if (this._MBO != value)
					{
						this.OnMBOChanging(value);
						this.SendPropertyChanging();
						this._MBO = value;
						this.SendPropertyChanged("MBO");
						this.OnMBOChanged();
					}
					this.SendPropertySetterInvoked("MBO", value);
				}
			}
			
			/// <summary>
			/// Column DbType=VarChar(20)
			/// </summary>
			[ColumnAttribute(Storage="_MBS", DbType="VarChar(20)", CanBeNull=true)]
			public string MBS
			{
				get
				{
					return this._MBS;
				}
				set
				{
					if (this._MBS != value)
					{
						this.OnMBSChanging(value);
						this.SendPropertyChanging();
						this._MBS = value;
						this.SendPropertyChanged("MBS");
						this.OnMBSChanged();
					}
					this.SendPropertySetterInvoked("MBS", value);
				}
			}
			
			/// <summary>
			/// Column DbType=VarChar(20)
			/// </summary>
			[ColumnAttribute(Storage="_OIB", DbType="VarChar(20)", CanBeNull=true)]
			public string OIB
			{
				get
				{
					return this._OIB;
				}
				set
				{
					if (this._OIB != value)
					{
						this.OnOIBChanging(value);
						this.SendPropertyChanging();
						this._OIB = value;
						this.SendPropertyChanged("OIB");
						this.OnOIBChanged();
					}
					this.SendPropertySetterInvoked("OIB", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime
			/// </summary>
			[ColumnAttribute(Storage="_datumObjave", DbType="DateTime", CanBeNull=true)]
			public DateTime? datumObjave
			{
				get
				{
					return this._datumObjave;
				}
				set
				{
					if (this._datumObjave != value)
					{
						this.OndatumObjaveChanging(value);
						this.SendPropertyChanging();
						this._datumObjave = value;
						this.SendPropertyChanged("datumObjave");
						this.OndatumObjaveChanged();
					}
					this.SendPropertySetterInvoked("datumObjave", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime
			/// </summary>
			[ColumnAttribute(Storage="_datumOsnivanja", DbType="DateTime", CanBeNull=true)]
			public DateTime? datumOsnivanja
			{
				get
				{
					return this._datumOsnivanja;
				}
				set
				{
					if (this._datumOsnivanja != value)
					{
						this.OndatumOsnivanjaChanging(value);
						this.SendPropertyChanging();
						this._datumOsnivanja = value;
						this.SendPropertyChanged("datumOsnivanja");
						this.OndatumOsnivanjaChanged();
					}
					this.SendPropertySetterInvoked("datumOsnivanja", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime
			/// </summary>
			[ColumnAttribute(Storage="_datumZatvaranja", DbType="DateTime", CanBeNull=true)]
			public DateTime? datumZatvaranja
			{
				get
				{
					return this._datumZatvaranja;
				}
				set
				{
					if (this._datumZatvaranja != value)
					{
						this.OndatumZatvaranjaChanging(value);
						this.SendPropertyChanging();
						this._datumZatvaranja = value;
						this.SendPropertyChanged("datumZatvaranja");
						this.OndatumZatvaranjaChanged();
					}
					this.SendPropertySetterInvoked("datumZatvaranja", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime
			/// </summary>
			[ColumnAttribute(Storage="_insertionDate", DbType="DateTime", CanBeNull=true)]
			public DateTime? insertionDate
			{
				get
				{
					return this._insertionDate;
				}
				set
				{
					if (this._insertionDate != value)
					{
						this.OninsertionDateChanging(value);
						this.SendPropertyChanging();
						this._insertionDate = value;
						this.SendPropertyChanged("insertionDate");
						this.OninsertionDateChanged();
					}
					this.SendPropertySetterInvoked("insertionDate", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(250)
			/// </summary>
			[ColumnAttribute(Storage="_Naziv", DbType="NVarChar(250)", CanBeNull=true)]
			public string Naziv
			{
				get
				{
					return this._Naziv;
				}
				set
				{
					if (this._Naziv != value)
					{
						this.OnNazivChanging(value);
						this.SendPropertyChanging();
						this._Naziv = value;
						this.SendPropertyChanged("Naziv");
						this.OnNazivChanged();
					}
					this.SendPropertySetterInvoked("Naziv", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(250)
			/// </summary>
			[ColumnAttribute(Storage="_Adresa", DbType="NVarChar(250)", CanBeNull=true)]
			public string Adresa
			{
				get
				{
					return this._Adresa;
				}
				set
				{
					if (this._Adresa != value)
					{
						this.OnAdresaChanging(value);
						this.SendPropertyChanging();
						this._Adresa = value;
						this.SendPropertyChanged("Adresa");
						this.OnAdresaChanged();
					}
					this.SendPropertySetterInvoked("Adresa", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(250)
			/// </summary>
			[ColumnAttribute(Storage="_Naselje", DbType="NVarChar(250)", CanBeNull=true)]
			public string Naselje
			{
				get
				{
					return this._Naselje;
				}
				set
				{
					if (this._Naselje != value)
					{
						this.OnNaseljeChanging(value);
						this.SendPropertyChanging();
						this._Naselje = value;
						this.SendPropertyChanged("Naselje");
						this.OnNaseljeChanged();
					}
					this.SendPropertySetterInvoked("Naselje", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(50)
			/// </summary>
			[ColumnAttribute(Storage="_PostanskiBroj", DbType="NVarChar(50)", CanBeNull=true)]
			public string PostanskiBroj
			{
				get
				{
					return this._PostanskiBroj;
				}
				set
				{
					if (this._PostanskiBroj != value)
					{
						this.OnPostanskiBrojChanging(value);
						this.SendPropertyChanging();
						this._PostanskiBroj = value;
						this.SendPropertyChanged("PostanskiBroj");
						this.OnPostanskiBrojChanged();
					}
					this.SendPropertySetterInvoked("PostanskiBroj", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(200)
			/// </summary>
			[ColumnAttribute(Storage="_PostanskiUred", DbType="NVarChar(200)", CanBeNull=true)]
			public string PostanskiUred
			{
				get
				{
					return this._PostanskiUred;
				}
				set
				{
					if (this._PostanskiUred != value)
					{
						this.OnPostanskiUredChanging(value);
						this.SendPropertyChanging();
						this._PostanskiUred = value;
						this.SendPropertyChanged("PostanskiUred");
						this.OnPostanskiUredChanged();
					}
					this.SendPropertySetterInvoked("PostanskiUred", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(500)
			/// </summary>
			[ColumnAttribute(Storage="_Web", DbType="NVarChar(500)", CanBeNull=true)]
			public string Web
			{
				get
				{
					return this._Web;
				}
				set
				{
					if (this._Web != value)
					{
						this.OnWebChanging(value);
						this.SendPropertyChanging();
						this._Web = value;
						this.SendPropertyChanged("Web");
						this.OnWebChanged();
					}
					this.SendPropertySetterInvoked("Web", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(200)
			/// </summary>
			[ColumnAttribute(Storage="_Email", DbType="NVarChar(200)", CanBeNull=true)]
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
			/// Column DbType=VarChar(20)
			/// </summary>
			[ColumnAttribute(Storage="_Telefon1", DbType="VarChar(20)", CanBeNull=true)]
			public string Telefon1
			{
				get
				{
					return this._Telefon1;
				}
				set
				{
					if (this._Telefon1 != value)
					{
						this.OnTelefon1Changing(value);
						this.SendPropertyChanging();
						this._Telefon1 = value;
						this.SendPropertyChanged("Telefon1");
						this.OnTelefon1Changed();
					}
					this.SendPropertySetterInvoked("Telefon1", value);
				}
			}
			
			/// <summary>
			/// Column DbType=VarChar(20)
			/// </summary>
			[ColumnAttribute(Storage="_Telefon2", DbType="VarChar(20)", CanBeNull=true)]
			public string Telefon2
			{
				get
				{
					return this._Telefon2;
				}
				set
				{
					if (this._Telefon2 != value)
					{
						this.OnTelefon2Changing(value);
						this.SendPropertyChanging();
						this._Telefon2 = value;
						this.SendPropertyChanged("Telefon2");
						this.OnTelefon2Changed();
					}
					this.SendPropertySetterInvoked("Telefon2", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int
			/// </summary>
			[ColumnAttribute(Storage="_NkdRowID", DbType="Int", CanBeNull=true)]
			public int? NkdRowID
			{
				get
				{
					return this._NkdRowID;
				}
				set
				{
					if (this._NkdRowID != value)
					{
						this.OnNkdRowIDChanging(value);
						this.SendPropertyChanging();
						this._NkdRowID = value;
						this.SendPropertyChanged("NkdRowID");
						this.OnNkdRowIDChanged();
					}
					this.SendPropertySetterInvoked("NkdRowID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(500)
			/// </summary>
			[ColumnAttribute(Storage="_KljucneRijeci", DbType="NVarChar(500)", CanBeNull=true)]
			public string KljucneRijeci
			{
				get
				{
					return this._KljucneRijeci;
				}
				set
				{
					if (this._KljucneRijeci != value)
					{
						this.OnKljucneRijeciChanging(value);
						this.SendPropertyChanging();
						this._KljucneRijeci = value;
						this.SendPropertyChanged("KljucneRijeci");
						this.OnKljucneRijeciChanged();
					}
					this.SendPropertySetterInvoked("KljucneRijeci", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(MAX)
			/// </summary>
			[ColumnAttribute(Storage="_Opis", DbType="NVarChar(MAX)", CanBeNull=true)]
			public string Opis
			{
				get
				{
					return this._Opis;
				}
				set
				{
					if (this._Opis != value)
					{
						this.OnOpisChanging(value);
						this.SendPropertyChanging();
						this._Opis = value;
						this.SendPropertyChanged("Opis");
						this.OnOpisChanged();
					}
					this.SendPropertySetterInvoked("Opis", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(500)
			/// </summary>
			[ColumnAttribute(Storage="_RadnoVrijeme", DbType="NVarChar(500)", CanBeNull=true)]
			public string RadnoVrijeme
			{
				get
				{
					return this._RadnoVrijeme;
				}
				set
				{
					if (this._RadnoVrijeme != value)
					{
						this.OnRadnoVrijemeChanging(value);
						this.SendPropertyChanging();
						this._RadnoVrijeme = value;
						this.SendPropertyChanged("RadnoVrijeme");
						this.OnRadnoVrijemeChanged();
					}
					this.SendPropertySetterInvoked("RadnoVrijeme", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime
			/// </summary>
			[ColumnAttribute(Storage="_LastModified", DbType="DateTime", CanBeNull=true)]
			public DateTime? LastModified
			{
				get
				{
					return this._LastModified;
				}
				set
				{
					if (this._LastModified != value)
					{
						this.OnLastModifiedChanging(value);
						this.SendPropertyChanging();
						this._LastModified = value;
						this.SendPropertyChanged("LastModified");
						this.OnLastModifiedChanged();
					}
					this.SendPropertySetterInvoked("LastModified", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(100)
			/// </summary>
			[ColumnAttribute(Storage="_odgovornaOsoba", DbType="NVarChar(100)", CanBeNull=true)]
			public string odgovornaOsoba
			{
				get
				{
					return this._odgovornaOsoba;
				}
				set
				{
					if (this._odgovornaOsoba != value)
					{
						this.OnodgovornaOsobaChanging(value);
						this.SendPropertyChanging();
						this._odgovornaOsoba = value;
						this.SendPropertyChanged("odgovornaOsoba");
						this.OnodgovornaOsobaChanged();
					}
					this.SendPropertySetterInvoked("odgovornaOsoba", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Bit
			/// </summary>
			[ColumnAttribute(Storage="_isVlasnik", DbType="Bit", CanBeNull=true)]
			public bool? isVlasnik
			{
				get
				{
					return this._isVlasnik;
				}
				set
				{
					if (this._isVlasnik != value)
					{
						this.OnisVlasnikChanging(value);
						this.SendPropertyChanging();
						this._isVlasnik = value;
						this.SendPropertyChanged("isVlasnik");
						this.OnisVlasnikChanged();
					}
					this.SendPropertySetterInvoked("isVlasnik", value);
				}
			}
			
			#endregion Columns

			#region Associations
			/// <summary>
			/// Association [PK][One]tblDirClient.ArizonaClientID --- [FK][Many]tblBillClient.ArizonaClientID
			/// </summary>
			[AssociationAttribute(Name="FK_tblBillClient_tblDirClient", Storage="_tblBillClientList", ThisKey="ArizonaClientID", OtherKey="ArizonaClientID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<tblBillClient> tblBillClientList
			{
				get { return this._tblBillClientList; }
				set { this._tblBillClientList.Assign(value); }
			}
			
			/// <summary>
			/// Association [PK][One]tblDirClient.ArizonaClientID --- [FK][One]tblDirClientFullText.ArizonaClientID
			/// </summary>
			[AssociationAttribute(Name="FK_tblDirClientFullText_tblDirClient", Storage="_tblDirClientFullText", ThisKey="ArizonaClientID", OtherKey="ArizonaClientID", IsUnique=true, IsForeignKey=false, DeleteRule="NoAction")]
			public tblDirClientFullText tblDirClientFullText
			{
				get
				{
					return this._tblDirClientFullText.Entity;
				}
				set
				{
					tblDirClientFullText previousValue = this._tblDirClientFullText.Entity;
					if ((previousValue != value) || (this._tblDirClientFullText.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._tblDirClientFullText.Entity = null;
							previousValue.tblDirClient = null;
						}
						this._tblDirClientFullText.Entity = value;
						if (value != null)
						{
							value.tblDirClient = this;
						}
						this.SendPropertyChanged("tblDirClientFullText");
					}
					this.SendPropertySetterInvoked("tblDirClientFullText", value);
				}
			}
			
			/// <summary>
			/// Association [PK][One]tblDirClient.ArizonaClientID --- [FK][One]tblDirClientGratis.ArizonaClientID
			/// </summary>
			[AssociationAttribute(Name="FK_tblDirClientGratis_tblDirClient", Storage="_tblDirClientGratis", ThisKey="ArizonaClientID", OtherKey="ArizonaClientID", IsUnique=true, IsForeignKey=false, DeleteRule="NoAction")]
			public tblDirClientGratis tblDirClientGratis
			{
				get
				{
					return this._tblDirClientGratis.Entity;
				}
				set
				{
					tblDirClientGratis previousValue = this._tblDirClientGratis.Entity;
					if ((previousValue != value) || (this._tblDirClientGratis.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._tblDirClientGratis.Entity = null;
							previousValue.tblDirClient = null;
						}
						this._tblDirClientGratis.Entity = value;
						if (value != null)
						{
							value.tblDirClient = this;
						}
						this.SendPropertyChanged("tblDirClientGratis");
					}
					this.SendPropertySetterInvoked("tblDirClientGratis", value);
				}
			}
			
			/// <summary>
			/// Association [PK][One]tblDirClient.ArizonaClientID --- [FK][Many]tblDirClientPhone.ArizonaClientID
			/// </summary>
			[AssociationAttribute(Name="FK_tblDirClientPhone_tblDirClient", Storage="_tblDirClientPhoneList", ThisKey="ArizonaClientID", OtherKey="ArizonaClientID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<tblDirClientPhone> tblDirClientPhoneList
			{
				get { return this._tblDirClientPhoneList; }
				set { this._tblDirClientPhoneList.Assign(value); }
			}
			
			/// <summary>
			/// Association [PK][One]tblDirClient.ArizonaClientID --- [FK][Many]tblDirClientPicture.ArizonaClientID
			/// </summary>
			[AssociationAttribute(Name="FK_tblDirClientPicture_tblDirClient", Storage="_tblDirClientPictureList", ThisKey="ArizonaClientID", OtherKey="ArizonaClientID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<tblDirClientPicture> tblDirClientPictureList
			{
				get { return this._tblDirClientPictureList; }
				set { this._tblDirClientPictureList.Assign(value); }
			}
			
			/// <summary>
			/// Association [PK][One]tblDirClient.ArizonaClientID --- [FK][One]tblDirClientPrikazStatus.ArizonaClientID
			/// </summary>
			[AssociationAttribute(Name="FK_tblDirClientPrikazStatus_tblDirClient", Storage="_tblDirClientPrikazStatus", ThisKey="ArizonaClientID", OtherKey="ArizonaClientID", IsUnique=true, IsForeignKey=false, DeleteRule="NoAction")]
			public tblDirClientPrikazStatus tblDirClientPrikazStatus
			{
				get
				{
					return this._tblDirClientPrikazStatus.Entity;
				}
				set
				{
					tblDirClientPrikazStatus previousValue = this._tblDirClientPrikazStatus.Entity;
					if ((previousValue != value) || (this._tblDirClientPrikazStatus.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._tblDirClientPrikazStatus.Entity = null;
							previousValue.tblDirClient = null;
						}
						this._tblDirClientPrikazStatus.Entity = value;
						if (value != null)
						{
							value.tblDirClient = this;
						}
						this.SendPropertyChanged("tblDirClientPrikazStatus");
					}
					this.SendPropertySetterInvoked("tblDirClientPrikazStatus", value);
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
		#endregion dbo.tblDirClient

		#region dbo.tblDirClientBlacklist
		[TableAttribute(Name="dbo.tblDirClientBlacklist")]
		public partial class tblDirClientBlacklist : EntityBase<tblDirClientBlacklist, dbArizonaAppDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private string _OIB;
			private int _BillFirmaID;
			private DateTime _InsertionDate;
			private string _Napomena;
			private long _AppMemberID;
			private EntityRef<tblAppMember> _tblAppMember;
			private EntityRef<tblBillFirma> _tblBillFirma;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnOIBChanging(string value);
			partial void OnOIBChanged();
			partial void OnBillFirmaIDChanging(int value);
			partial void OnBillFirmaIDChanged();
			partial void OnInsertionDateChanging(DateTime value);
			partial void OnInsertionDateChanged();
			partial void OnNapomenaChanging(string value);
			partial void OnNapomenaChanged();
			partial void OnAppMemberIDChanging(long value);
			partial void OnAppMemberIDChanged();
			#endregion

			public tblDirClientBlacklist()
			{
				_tblAppMember = default(EntityRef<tblAppMember>);
				_tblBillFirma = default(EntityRef<tblBillFirma>);
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=VarChar(20) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_OIB", DbType="VarChar(20) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
			public string OIB
			{
				get
				{
					return this._OIB;
				}
				set
				{
					if (this._OIB != value)
					{
						this.OnOIBChanging(value);
						this.SendPropertyChanging();
						this._OIB = value;
						this.SendPropertyChanged("OIB");
						this.OnOIBChanged();
					}
					this.SendPropertySetterInvoked("OIB", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_BillFirmaID", DbType="Int NOT NULL", CanBeNull=false)]
			public int BillFirmaID
			{
				get
				{
					return this._BillFirmaID;
				}
				set
				{
					if (this._BillFirmaID != value)
					{
						this.OnBillFirmaIDChanging(value);
						this.SendPropertyChanging();
						this._BillFirmaID = value;
						this.SendPropertyChanged("BillFirmaID");
						this.OnBillFirmaIDChanged();
					}
					this.SendPropertySetterInvoked("BillFirmaID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_InsertionDate", DbType="DateTime NOT NULL", CanBeNull=false)]
			public DateTime InsertionDate
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
			[ColumnAttribute(Storage="_Napomena", DbType="NVarChar(500)", CanBeNull=true)]
			public string Napomena
			{
				get
				{
					return this._Napomena;
				}
				set
				{
					if (this._Napomena != value)
					{
						this.OnNapomenaChanging(value);
						this.SendPropertyChanging();
						this._Napomena = value;
						this.SendPropertyChanged("Napomena");
						this.OnNapomenaChanged();
					}
					this.SendPropertySetterInvoked("Napomena", value);
				}
			}
			
			/// <summary>
			/// Column DbType=BigInt NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_AppMemberID", DbType="BigInt NOT NULL", CanBeNull=false)]
			public long AppMemberID
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
			
			#endregion Columns

			#region Associations
			/// <summary>
			/// Association [FK][Many]tblDirClientBlacklist.AppMemberID --- [PK][One]tblAppMember.AppMemberID
			/// </summary>
			[AssociationAttribute(Name="FK_tblDirClientBlacklist_tblAppMember", Storage="_tblAppMember", ThisKey="AppMemberID", OtherKey="AppMemberID", IsUnique=false, IsForeignKey=true)]
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
							previousValue.tblDirClientBlacklistList.Remove(this);
						}
						this._tblAppMember.Entity = value;
						if (value != null)
						{
							value.tblDirClientBlacklistList.Add(this);
							this._AppMemberID = value.AppMemberID;
						}
						else
						{
							this._AppMemberID = default(long);
						}
						this.SendPropertyChanged("tblAppMember");
					}
					this.SendPropertySetterInvoked("tblAppMember", value);
				}
			}
			
			/// <summary>
			/// Association [FK][Many]tblDirClientBlacklist.BillFirmaID --- [PK][One]tblBillFirma.BillFirmaID
			/// </summary>
			[AssociationAttribute(Name="FK_tblDirClientBlacklist_tblBillFirma", Storage="_tblBillFirma", ThisKey="BillFirmaID", OtherKey="BillFirmaID", IsUnique=false, IsForeignKey=true)]
			public tblBillFirma tblBillFirma
			{
				get
				{
					return this._tblBillFirma.Entity;
				}
				set
				{
					tblBillFirma previousValue = this._tblBillFirma.Entity;
					if ((previousValue != value) || (this._tblBillFirma.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._tblBillFirma.Entity = null;
							previousValue.tblDirClientBlacklistList.Remove(this);
						}
						this._tblBillFirma.Entity = value;
						if (value != null)
						{
							value.tblDirClientBlacklistList.Add(this);
							this._BillFirmaID = value.BillFirmaID;
						}
						else
						{
							this._BillFirmaID = default(int);
						}
						this.SendPropertyChanged("tblBillFirma");
					}
					this.SendPropertySetterInvoked("tblBillFirma", value);
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
		#endregion dbo.tblDirClientBlacklist

		#region dbo.tblDirClientFullText
		[TableAttribute(Name="dbo.tblDirClientFullText")]
		public partial class tblDirClientFullText : EntityBase<tblDirClientFullText, dbArizonaAppDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private int _ArizonaClientID;
			private string _fullTextIndexBasic;
			private string _fullTextIndexFull;
			private EntityRef<tblDirClient> _tblDirClient;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnArizonaClientIDChanging(int value);
			partial void OnArizonaClientIDChanged();
			partial void OnfullTextIndexBasicChanging(string value);
			partial void OnfullTextIndexBasicChanged();
			partial void OnfullTextIndexFullChanging(string value);
			partial void OnfullTextIndexFullChanged();
			#endregion

			public tblDirClientFullText()
			{
				_tblDirClient = default(EntityRef<tblDirClient>);
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ArizonaClientID", DbType="Int NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
			public int ArizonaClientID
			{
				get
				{
					return this._ArizonaClientID;
				}
				set
				{
					if (this._ArizonaClientID != value)
					{
						this.OnArizonaClientIDChanging(value);
						this.SendPropertyChanging();
						this._ArizonaClientID = value;
						this.SendPropertyChanged("ArizonaClientID");
						this.OnArizonaClientIDChanged();
					}
					this.SendPropertySetterInvoked("ArizonaClientID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(MAX)
			/// </summary>
			[ColumnAttribute(Storage="_fullTextIndexBasic", DbType="NVarChar(MAX)", CanBeNull=true)]
			public string fullTextIndexBasic
			{
				get
				{
					return this._fullTextIndexBasic;
				}
				set
				{
					if (this._fullTextIndexBasic != value)
					{
						this.OnfullTextIndexBasicChanging(value);
						this.SendPropertyChanging();
						this._fullTextIndexBasic = value;
						this.SendPropertyChanged("fullTextIndexBasic");
						this.OnfullTextIndexBasicChanged();
					}
					this.SendPropertySetterInvoked("fullTextIndexBasic", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(MAX)
			/// </summary>
			[ColumnAttribute(Storage="_fullTextIndexFull", DbType="NVarChar(MAX)", CanBeNull=true)]
			public string fullTextIndexFull
			{
				get
				{
					return this._fullTextIndexFull;
				}
				set
				{
					if (this._fullTextIndexFull != value)
					{
						this.OnfullTextIndexFullChanging(value);
						this.SendPropertyChanging();
						this._fullTextIndexFull = value;
						this.SendPropertyChanged("fullTextIndexFull");
						this.OnfullTextIndexFullChanged();
					}
					this.SendPropertySetterInvoked("fullTextIndexFull", value);
				}
			}
			
			#endregion Columns

			#region Associations
			/// <summary>
			/// Association [FK][One]tblDirClientFullText.ArizonaClientID --- [PK][One]tblDirClient.ArizonaClientID
			/// </summary>
			[AssociationAttribute(Name="FK_tblDirClientFullText_tblDirClient", Storage="_tblDirClient", ThisKey="ArizonaClientID", OtherKey="ArizonaClientID", IsUnique=true, IsForeignKey=true)]
			public tblDirClient tblDirClient
			{
				get
				{
					return this._tblDirClient.Entity;
				}
				set
				{
					tblDirClient previousValue = this._tblDirClient.Entity;
					if ((previousValue != value) || (this._tblDirClient.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._tblDirClient.Entity = null;
							previousValue.tblDirClientFullText = null;
						}
						this._tblDirClient.Entity = value;
						if (value != null)
						{
							value.tblDirClientFullText = this;
							this._ArizonaClientID = value.ArizonaClientID;
						}
						else
						{
							this._ArizonaClientID = default(int);
						}
						this.SendPropertyChanged("tblDirClient");
					}
					this.SendPropertySetterInvoked("tblDirClient", value);
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
		#endregion dbo.tblDirClientFullText

		#region dbo.tblDirClientGratis
		[TableAttribute(Name="dbo.tblDirClientGratis")]
		public partial class tblDirClientGratis : EntityBase<tblDirClientGratis, dbArizonaAppDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private int _ArizonaClientID;
			private int? _BillUslugaTipID;
			private int _PrikazStatus;
			private DateTime? _StartDate;
			private DateTime? _EndDate;
			private EntityRef<tblBillUslugaTip> _tblBillUslugaTip;
			private EntityRef<tblDirClient> _tblDirClient;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnArizonaClientIDChanging(int value);
			partial void OnArizonaClientIDChanged();
			partial void OnBillUslugaTipIDChanging(int? value);
			partial void OnBillUslugaTipIDChanged();
			partial void OnPrikazStatusChanging(int value);
			partial void OnPrikazStatusChanged();
			partial void OnStartDateChanging(DateTime? value);
			partial void OnStartDateChanged();
			partial void OnEndDateChanging(DateTime? value);
			partial void OnEndDateChanged();
			#endregion

			public tblDirClientGratis()
			{
				_tblBillUslugaTip = default(EntityRef<tblBillUslugaTip>);
				_tblDirClient = default(EntityRef<tblDirClient>);
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ArizonaClientID", DbType="Int NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
			public int ArizonaClientID
			{
				get
				{
					return this._ArizonaClientID;
				}
				set
				{
					if (this._ArizonaClientID != value)
					{
						this.OnArizonaClientIDChanging(value);
						this.SendPropertyChanging();
						this._ArizonaClientID = value;
						this.SendPropertyChanged("ArizonaClientID");
						this.OnArizonaClientIDChanged();
					}
					this.SendPropertySetterInvoked("ArizonaClientID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int
			/// </summary>
			[ColumnAttribute(Storage="_BillUslugaTipID", DbType="Int", CanBeNull=true)]
			public int? BillUslugaTipID
			{
				get
				{
					return this._BillUslugaTipID;
				}
				set
				{
					if (this._BillUslugaTipID != value)
					{
						this.OnBillUslugaTipIDChanging(value);
						this.SendPropertyChanging();
						this._BillUslugaTipID = value;
						this.SendPropertyChanged("BillUslugaTipID");
						this.OnBillUslugaTipIDChanged();
					}
					this.SendPropertySetterInvoked("BillUslugaTipID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_PrikazStatus", DbType="Int NOT NULL", CanBeNull=false)]
			public int PrikazStatus
			{
				get
				{
					return this._PrikazStatus;
				}
				set
				{
					if (this._PrikazStatus != value)
					{
						this.OnPrikazStatusChanging(value);
						this.SendPropertyChanging();
						this._PrikazStatus = value;
						this.SendPropertyChanged("PrikazStatus");
						this.OnPrikazStatusChanged();
					}
					this.SendPropertySetterInvoked("PrikazStatus", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime
			/// </summary>
			[ColumnAttribute(Storage="_StartDate", DbType="DateTime", CanBeNull=true)]
			public DateTime? StartDate
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
			/// <summary>
			/// Association [FK][Many]tblDirClientGratis.BillUslugaTipID --- [PK][One]tblBillUslugaTip.BillUslugaTipID
			/// </summary>
			[AssociationAttribute(Name="FK_tblDirClientGratis_tblBillUslugaTip", Storage="_tblBillUslugaTip", ThisKey="BillUslugaTipID", OtherKey="BillUslugaTipID", IsUnique=false, IsForeignKey=true)]
			public tblBillUslugaTip tblBillUslugaTip
			{
				get
				{
					return this._tblBillUslugaTip.Entity;
				}
				set
				{
					tblBillUslugaTip previousValue = this._tblBillUslugaTip.Entity;
					if ((previousValue != value) || (this._tblBillUslugaTip.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._tblBillUslugaTip.Entity = null;
							previousValue.tblDirClientGratisList.Remove(this);
						}
						this._tblBillUslugaTip.Entity = value;
						if (value != null)
						{
							value.tblDirClientGratisList.Add(this);
							this._BillUslugaTipID = value.BillUslugaTipID;
						}
						else
						{
							this._BillUslugaTipID = default(int?);
						}
						this.SendPropertyChanged("tblBillUslugaTip");
					}
					this.SendPropertySetterInvoked("tblBillUslugaTip", value);
				}
			}
			
			/// <summary>
			/// Association [FK][One]tblDirClientGratis.ArizonaClientID --- [PK][One]tblDirClient.ArizonaClientID
			/// </summary>
			[AssociationAttribute(Name="FK_tblDirClientGratis_tblDirClient", Storage="_tblDirClient", ThisKey="ArizonaClientID", OtherKey="ArizonaClientID", IsUnique=true, IsForeignKey=true)]
			public tblDirClient tblDirClient
			{
				get
				{
					return this._tblDirClient.Entity;
				}
				set
				{
					tblDirClient previousValue = this._tblDirClient.Entity;
					if ((previousValue != value) || (this._tblDirClient.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._tblDirClient.Entity = null;
							previousValue.tblDirClientGratis = null;
						}
						this._tblDirClient.Entity = value;
						if (value != null)
						{
							value.tblDirClientGratis = this;
							this._ArizonaClientID = value.ArizonaClientID;
						}
						else
						{
							this._ArizonaClientID = default(int);
						}
						this.SendPropertyChanged("tblDirClient");
					}
					this.SendPropertySetterInvoked("tblDirClient", value);
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
		#endregion dbo.tblDirClientGratis

		#region dbo.tblDirClientPhone
		[TableAttribute(Name="dbo.tblDirClientPhone")]
		public partial class tblDirClientPhone : EntityBase<tblDirClientPhone, dbArizonaAppDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private int _ArizonaClientPhoneID;
			private int _ArizonaClientID;
			private string _naziv;
			private string _telBroj;
			private DateTime _insertionDate;
			private EntityRef<tblDirClient> _tblDirClient;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnArizonaClientPhoneIDChanging(int value);
			partial void OnArizonaClientPhoneIDChanged();
			partial void OnArizonaClientIDChanging(int value);
			partial void OnArizonaClientIDChanged();
			partial void OnnazivChanging(string value);
			partial void OnnazivChanged();
			partial void OntelBrojChanging(string value);
			partial void OntelBrojChanged();
			partial void OninsertionDateChanging(DateTime value);
			partial void OninsertionDateChanged();
			#endregion

			public tblDirClientPhone()
			{
				_tblDirClient = default(EntityRef<tblDirClient>);
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=Int NOT NULL IDENTITY
			/// </summary>
			[ColumnAttribute(Storage="_ArizonaClientPhoneID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", CanBeNull=false, IsPrimaryKey=true, IsDbGenerated=true)]
			public int ArizonaClientPhoneID
			{
				get
				{
					return this._ArizonaClientPhoneID;
				}
				set
				{
					if (this._ArizonaClientPhoneID != value)
					{
						this.OnArizonaClientPhoneIDChanging(value);
						this.SendPropertyChanging();
						this._ArizonaClientPhoneID = value;
						this.SendPropertyChanged("ArizonaClientPhoneID");
						this.OnArizonaClientPhoneIDChanged();
					}
					this.SendPropertySetterInvoked("ArizonaClientPhoneID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ArizonaClientID", DbType="Int NOT NULL", CanBeNull=false)]
			public int ArizonaClientID
			{
				get
				{
					return this._ArizonaClientID;
				}
				set
				{
					if (this._ArizonaClientID != value)
					{
						this.OnArizonaClientIDChanging(value);
						this.SendPropertyChanging();
						this._ArizonaClientID = value;
						this.SendPropertyChanged("ArizonaClientID");
						this.OnArizonaClientIDChanged();
					}
					this.SendPropertySetterInvoked("ArizonaClientID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(200) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_naziv", DbType="NVarChar(200) NOT NULL", CanBeNull=false)]
			public string naziv
			{
				get
				{
					return this._naziv;
				}
				set
				{
					if (this._naziv != value)
					{
						this.OnnazivChanging(value);
						this.SendPropertyChanging();
						this._naziv = value;
						this.SendPropertyChanged("naziv");
						this.OnnazivChanged();
					}
					this.SendPropertySetterInvoked("naziv", value);
				}
			}
			
			/// <summary>
			/// Column DbType=VarChar(200) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_telBroj", DbType="VarChar(200) NOT NULL", CanBeNull=false)]
			public string telBroj
			{
				get
				{
					return this._telBroj;
				}
				set
				{
					if (this._telBroj != value)
					{
						this.OntelBrojChanging(value);
						this.SendPropertyChanging();
						this._telBroj = value;
						this.SendPropertyChanged("telBroj");
						this.OntelBrojChanged();
					}
					this.SendPropertySetterInvoked("telBroj", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_insertionDate", DbType="DateTime NOT NULL", CanBeNull=false)]
			public DateTime insertionDate
			{
				get
				{
					return this._insertionDate;
				}
				set
				{
					if (this._insertionDate != value)
					{
						this.OninsertionDateChanging(value);
						this.SendPropertyChanging();
						this._insertionDate = value;
						this.SendPropertyChanged("insertionDate");
						this.OninsertionDateChanged();
					}
					this.SendPropertySetterInvoked("insertionDate", value);
				}
			}
			
			#endregion Columns

			#region Associations
			/// <summary>
			/// Association [FK][Many]tblDirClientPhone.ArizonaClientID --- [PK][One]tblDirClient.ArizonaClientID
			/// </summary>
			[AssociationAttribute(Name="FK_tblDirClientPhone_tblDirClient", Storage="_tblDirClient", ThisKey="ArizonaClientID", OtherKey="ArizonaClientID", IsUnique=false, IsForeignKey=true)]
			public tblDirClient tblDirClient
			{
				get
				{
					return this._tblDirClient.Entity;
				}
				set
				{
					tblDirClient previousValue = this._tblDirClient.Entity;
					if ((previousValue != value) || (this._tblDirClient.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._tblDirClient.Entity = null;
							previousValue.tblDirClientPhoneList.Remove(this);
						}
						this._tblDirClient.Entity = value;
						if (value != null)
						{
							value.tblDirClientPhoneList.Add(this);
							this._ArizonaClientID = value.ArizonaClientID;
						}
						else
						{
							this._ArizonaClientID = default(int);
						}
						this.SendPropertyChanged("tblDirClient");
					}
					this.SendPropertySetterInvoked("tblDirClient", value);
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
		#endregion dbo.tblDirClientPhone

		#region dbo.tblDirClientPicture
		[TableAttribute(Name="dbo.tblDirClientPicture")]
		public partial class tblDirClientPicture : EntityBase<tblDirClientPicture, dbArizonaAppDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private int _DirClientPictureID;
			private int _ArizonaClientID;
			private DateTime _InsertionDate;
			private string _FileName;
			private byte[] _ImageData;
			private string _ImageMimeType;
			private byte[] _ThumbData;
			private string _ThumbMimeType;
			private bool? _IsNaslovna;
			private bool? _IsLogo;
			private EntityRef<tblDirClient> _tblDirClient;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnDirClientPictureIDChanging(int value);
			partial void OnDirClientPictureIDChanged();
			partial void OnArizonaClientIDChanging(int value);
			partial void OnArizonaClientIDChanged();
			partial void OnInsertionDateChanging(DateTime value);
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
			partial void OnIsNaslovnaChanging(bool? value);
			partial void OnIsNaslovnaChanged();
			partial void OnIsLogoChanging(bool? value);
			partial void OnIsLogoChanged();
			#endregion

			public tblDirClientPicture()
			{
				_tblDirClient = default(EntityRef<tblDirClient>);
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=Int NOT NULL IDENTITY
			/// </summary>
			[ColumnAttribute(Storage="_DirClientPictureID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", CanBeNull=false, IsPrimaryKey=true, IsDbGenerated=true)]
			public int DirClientPictureID
			{
				get
				{
					return this._DirClientPictureID;
				}
				set
				{
					if (this._DirClientPictureID != value)
					{
						this.OnDirClientPictureIDChanging(value);
						this.SendPropertyChanging();
						this._DirClientPictureID = value;
						this.SendPropertyChanged("DirClientPictureID");
						this.OnDirClientPictureIDChanged();
					}
					this.SendPropertySetterInvoked("DirClientPictureID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ArizonaClientID", DbType="Int NOT NULL", CanBeNull=false)]
			public int ArizonaClientID
			{
				get
				{
					return this._ArizonaClientID;
				}
				set
				{
					if (this._ArizonaClientID != value)
					{
						this.OnArizonaClientIDChanging(value);
						this.SendPropertyChanging();
						this._ArizonaClientID = value;
						this.SendPropertyChanged("ArizonaClientID");
						this.OnArizonaClientIDChanged();
					}
					this.SendPropertySetterInvoked("ArizonaClientID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_InsertionDate", DbType="DateTime NOT NULL", CanBeNull=false)]
			public DateTime InsertionDate
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
			
			/// <summary>
			/// Column DbType=Bit
			/// </summary>
			[ColumnAttribute(Storage="_IsNaslovna", DbType="Bit", CanBeNull=true)]
			public bool? IsNaslovna
			{
				get
				{
					return this._IsNaslovna;
				}
				set
				{
					if (this._IsNaslovna != value)
					{
						this.OnIsNaslovnaChanging(value);
						this.SendPropertyChanging();
						this._IsNaslovna = value;
						this.SendPropertyChanged("IsNaslovna");
						this.OnIsNaslovnaChanged();
					}
					this.SendPropertySetterInvoked("IsNaslovna", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Bit
			/// </summary>
			[ColumnAttribute(Storage="_IsLogo", DbType="Bit", CanBeNull=true)]
			public bool? IsLogo
			{
				get
				{
					return this._IsLogo;
				}
				set
				{
					if (this._IsLogo != value)
					{
						this.OnIsLogoChanging(value);
						this.SendPropertyChanging();
						this._IsLogo = value;
						this.SendPropertyChanged("IsLogo");
						this.OnIsLogoChanged();
					}
					this.SendPropertySetterInvoked("IsLogo", value);
				}
			}
			
			#endregion Columns

			#region Associations
			/// <summary>
			/// Association [FK][Many]tblDirClientPicture.ArizonaClientID --- [PK][One]tblDirClient.ArizonaClientID
			/// </summary>
			[AssociationAttribute(Name="FK_tblDirClientPicture_tblDirClient", Storage="_tblDirClient", ThisKey="ArizonaClientID", OtherKey="ArizonaClientID", IsUnique=false, IsForeignKey=true)]
			public tblDirClient tblDirClient
			{
				get
				{
					return this._tblDirClient.Entity;
				}
				set
				{
					tblDirClient previousValue = this._tblDirClient.Entity;
					if ((previousValue != value) || (this._tblDirClient.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._tblDirClient.Entity = null;
							previousValue.tblDirClientPictureList.Remove(this);
						}
						this._tblDirClient.Entity = value;
						if (value != null)
						{
							value.tblDirClientPictureList.Add(this);
							this._ArizonaClientID = value.ArizonaClientID;
						}
						else
						{
							this._ArizonaClientID = default(int);
						}
						this.SendPropertyChanged("tblDirClient");
					}
					this.SendPropertySetterInvoked("tblDirClient", value);
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
		#endregion dbo.tblDirClientPicture

		#region dbo.tblDirClientPrikazStatus
		[TableAttribute(Name="dbo.tblDirClientPrikazStatus")]
		public partial class tblDirClientPrikazStatus : EntityBase<tblDirClientPrikazStatus, dbArizonaAppDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private int _ArizonaClientID;
			private int _PrikazStatus;
			private DateTime? _StartDate;
			private DateTime? _EndDate;
			private EntityRef<tblDirClient> _tblDirClient;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnArizonaClientIDChanging(int value);
			partial void OnArizonaClientIDChanged();
			partial void OnPrikazStatusChanging(int value);
			partial void OnPrikazStatusChanged();
			partial void OnStartDateChanging(DateTime? value);
			partial void OnStartDateChanged();
			partial void OnEndDateChanging(DateTime? value);
			partial void OnEndDateChanged();
			#endregion

			public tblDirClientPrikazStatus()
			{
				_tblDirClient = default(EntityRef<tblDirClient>);
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ArizonaClientID", DbType="Int NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
			public int ArizonaClientID
			{
				get
				{
					return this._ArizonaClientID;
				}
				set
				{
					if (this._ArizonaClientID != value)
					{
						this.OnArizonaClientIDChanging(value);
						this.SendPropertyChanging();
						this._ArizonaClientID = value;
						this.SendPropertyChanged("ArizonaClientID");
						this.OnArizonaClientIDChanged();
					}
					this.SendPropertySetterInvoked("ArizonaClientID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_PrikazStatus", DbType="Int NOT NULL", CanBeNull=false)]
			public int PrikazStatus
			{
				get
				{
					return this._PrikazStatus;
				}
				set
				{
					if (this._PrikazStatus != value)
					{
						this.OnPrikazStatusChanging(value);
						this.SendPropertyChanging();
						this._PrikazStatus = value;
						this.SendPropertyChanged("PrikazStatus");
						this.OnPrikazStatusChanged();
					}
					this.SendPropertySetterInvoked("PrikazStatus", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime
			/// </summary>
			[ColumnAttribute(Storage="_StartDate", DbType="DateTime", CanBeNull=true)]
			public DateTime? StartDate
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
			/// <summary>
			/// Association [FK][One]tblDirClientPrikazStatus.ArizonaClientID --- [PK][One]tblDirClient.ArizonaClientID
			/// </summary>
			[AssociationAttribute(Name="FK_tblDirClientPrikazStatus_tblDirClient", Storage="_tblDirClient", ThisKey="ArizonaClientID", OtherKey="ArizonaClientID", IsUnique=true, IsForeignKey=true)]
			public tblDirClient tblDirClient
			{
				get
				{
					return this._tblDirClient.Entity;
				}
				set
				{
					tblDirClient previousValue = this._tblDirClient.Entity;
					if ((previousValue != value) || (this._tblDirClient.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._tblDirClient.Entity = null;
							previousValue.tblDirClientPrikazStatus = null;
						}
						this._tblDirClient.Entity = value;
						if (value != null)
						{
							value.tblDirClientPrikazStatus = this;
							this._ArizonaClientID = value.ArizonaClientID;
						}
						else
						{
							this._ArizonaClientID = default(int);
						}
						this.SendPropertyChanged("tblDirClient");
					}
					this.SendPropertySetterInvoked("tblDirClient", value);
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
		#endregion dbo.tblDirClientPrikazStatus

		#region dbo.tblDirClientVracenaPosta
		[TableAttribute(Name="dbo.tblDirClientVracenaPosta")]
		public partial class tblDirClientVracenaPosta : EntityBase<tblDirClientVracenaPosta, dbArizonaAppDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private string _OIB;
			private int _BillFirmaID;
			private DateTime _InsertionDate;
			private string _Napomena;
			private long _AppMemberID;
			private EntityRef<tblAppMember> _tblAppMember;
			private EntityRef<tblBillFirma> _tblBillFirma;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnOIBChanging(string value);
			partial void OnOIBChanged();
			partial void OnBillFirmaIDChanging(int value);
			partial void OnBillFirmaIDChanged();
			partial void OnInsertionDateChanging(DateTime value);
			partial void OnInsertionDateChanged();
			partial void OnNapomenaChanging(string value);
			partial void OnNapomenaChanged();
			partial void OnAppMemberIDChanging(long value);
			partial void OnAppMemberIDChanged();
			#endregion

			public tblDirClientVracenaPosta()
			{
				_tblAppMember = default(EntityRef<tblAppMember>);
				_tblBillFirma = default(EntityRef<tblBillFirma>);
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=VarChar(20) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_OIB", DbType="VarChar(20) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
			public string OIB
			{
				get
				{
					return this._OIB;
				}
				set
				{
					if (this._OIB != value)
					{
						this.OnOIBChanging(value);
						this.SendPropertyChanging();
						this._OIB = value;
						this.SendPropertyChanged("OIB");
						this.OnOIBChanged();
					}
					this.SendPropertySetterInvoked("OIB", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_BillFirmaID", DbType="Int NOT NULL", CanBeNull=false)]
			public int BillFirmaID
			{
				get
				{
					return this._BillFirmaID;
				}
				set
				{
					if (this._BillFirmaID != value)
					{
						this.OnBillFirmaIDChanging(value);
						this.SendPropertyChanging();
						this._BillFirmaID = value;
						this.SendPropertyChanged("BillFirmaID");
						this.OnBillFirmaIDChanged();
					}
					this.SendPropertySetterInvoked("BillFirmaID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_InsertionDate", DbType="DateTime NOT NULL", CanBeNull=false)]
			public DateTime InsertionDate
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
			[ColumnAttribute(Storage="_Napomena", DbType="NVarChar(500)", CanBeNull=true)]
			public string Napomena
			{
				get
				{
					return this._Napomena;
				}
				set
				{
					if (this._Napomena != value)
					{
						this.OnNapomenaChanging(value);
						this.SendPropertyChanging();
						this._Napomena = value;
						this.SendPropertyChanged("Napomena");
						this.OnNapomenaChanged();
					}
					this.SendPropertySetterInvoked("Napomena", value);
				}
			}
			
			/// <summary>
			/// Column DbType=BigInt NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_AppMemberID", DbType="BigInt NOT NULL", CanBeNull=false)]
			public long AppMemberID
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
			
			#endregion Columns

			#region Associations
			/// <summary>
			/// Association [FK][Many]tblDirClientVracenaPosta.AppMemberID --- [PK][One]tblAppMember.AppMemberID
			/// </summary>
			[AssociationAttribute(Name="FK_tblDirClientVracenaPosta_tblAppMember", Storage="_tblAppMember", ThisKey="AppMemberID", OtherKey="AppMemberID", IsUnique=false, IsForeignKey=true)]
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
							previousValue.tblDirClientVracenaPostaList.Remove(this);
						}
						this._tblAppMember.Entity = value;
						if (value != null)
						{
							value.tblDirClientVracenaPostaList.Add(this);
							this._AppMemberID = value.AppMemberID;
						}
						else
						{
							this._AppMemberID = default(long);
						}
						this.SendPropertyChanged("tblAppMember");
					}
					this.SendPropertySetterInvoked("tblAppMember", value);
				}
			}
			
			/// <summary>
			/// Association [FK][Many]tblDirClientVracenaPosta.BillFirmaID --- [PK][One]tblBillFirma.BillFirmaID
			/// </summary>
			[AssociationAttribute(Name="FK_tblDirClientVracenaPosta_tblBillFirma", Storage="_tblBillFirma", ThisKey="BillFirmaID", OtherKey="BillFirmaID", IsUnique=false, IsForeignKey=true)]
			public tblBillFirma tblBillFirma
			{
				get
				{
					return this._tblBillFirma.Entity;
				}
				set
				{
					tblBillFirma previousValue = this._tblBillFirma.Entity;
					if ((previousValue != value) || (this._tblBillFirma.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._tblBillFirma.Entity = null;
							previousValue.tblDirClientVracenaPostaList.Remove(this);
						}
						this._tblBillFirma.Entity = value;
						if (value != null)
						{
							value.tblDirClientVracenaPostaList.Add(this);
							this._BillFirmaID = value.BillFirmaID;
						}
						else
						{
							this._BillFirmaID = default(int);
						}
						this.SendPropertyChanged("tblBillFirma");
					}
					this.SendPropertySetterInvoked("tblBillFirma", value);
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
		#endregion dbo.tblDirClientVracenaPosta

		#region dbo.tblDirPrikazStatus
		[TableAttribute(Name="dbo.tblDirPrikazStatus")]
		public partial class tblDirPrikazStatus : EntityBase<tblDirPrikazStatus, dbArizonaAppDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private int _PrikazStatus;
			private string _Description;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnPrikazStatusChanging(int value);
			partial void OnPrikazStatusChanged();
			partial void OnDescriptionChanging(string value);
			partial void OnDescriptionChanged();
			#endregion

			public tblDirPrikazStatus()
			{
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_PrikazStatus", DbType="Int NOT NULL", CanBeNull=false)]
			public int PrikazStatus
			{
				get
				{
					return this._PrikazStatus;
				}
				set
				{
					if (this._PrikazStatus != value)
					{
						this.OnPrikazStatusChanging(value);
						this.SendPropertyChanging();
						this._PrikazStatus = value;
						this.SendPropertyChanged("PrikazStatus");
						this.OnPrikazStatusChanged();
					}
					this.SendPropertySetterInvoked("PrikazStatus", value);
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
		#endregion dbo.tblDirPrikazStatus

		#region dbo.tblDirRegistration
		[TableAttribute(Name="dbo.tblDirRegistration")]
		public partial class tblDirRegistration : EntityBase<tblDirRegistration, dbArizonaAppDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private int _DirRegistrationID;
			private string _IP;
			private DateTime _InsertionDate;
			private DateTime? _ProcessedDate;
			private string _OIB;
			private string _Naziv;
			private string _Adresa;
			private string _PostanskiBroj;
			private string _PostanskiUred;
			private string _Email;
			private string _WebSite;
			private string _Telefon;
			private string _Mobitel;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnDirRegistrationIDChanging(int value);
			partial void OnDirRegistrationIDChanged();
			partial void OnIPChanging(string value);
			partial void OnIPChanged();
			partial void OnInsertionDateChanging(DateTime value);
			partial void OnInsertionDateChanged();
			partial void OnProcessedDateChanging(DateTime? value);
			partial void OnProcessedDateChanged();
			partial void OnOIBChanging(string value);
			partial void OnOIBChanged();
			partial void OnNazivChanging(string value);
			partial void OnNazivChanged();
			partial void OnAdresaChanging(string value);
			partial void OnAdresaChanged();
			partial void OnPostanskiBrojChanging(string value);
			partial void OnPostanskiBrojChanged();
			partial void OnPostanskiUredChanging(string value);
			partial void OnPostanskiUredChanged();
			partial void OnEmailChanging(string value);
			partial void OnEmailChanged();
			partial void OnWebSiteChanging(string value);
			partial void OnWebSiteChanged();
			partial void OnTelefonChanging(string value);
			partial void OnTelefonChanged();
			partial void OnMobitelChanging(string value);
			partial void OnMobitelChanged();
			#endregion

			public tblDirRegistration()
			{
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=Int NOT NULL IDENTITY
			/// </summary>
			[ColumnAttribute(Storage="_DirRegistrationID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", CanBeNull=false, IsPrimaryKey=true, IsDbGenerated=true)]
			public int DirRegistrationID
			{
				get
				{
					return this._DirRegistrationID;
				}
				set
				{
					if (this._DirRegistrationID != value)
					{
						this.OnDirRegistrationIDChanging(value);
						this.SendPropertyChanging();
						this._DirRegistrationID = value;
						this.SendPropertyChanged("DirRegistrationID");
						this.OnDirRegistrationIDChanged();
					}
					this.SendPropertySetterInvoked("DirRegistrationID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=VarChar(50) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_IP", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
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
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_InsertionDate", DbType="DateTime NOT NULL", CanBeNull=false)]
			public DateTime InsertionDate
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
			/// Column DbType=DateTime
			/// </summary>
			[ColumnAttribute(Storage="_ProcessedDate", DbType="DateTime", CanBeNull=true)]
			public DateTime? ProcessedDate
			{
				get
				{
					return this._ProcessedDate;
				}
				set
				{
					if (this._ProcessedDate != value)
					{
						this.OnProcessedDateChanging(value);
						this.SendPropertyChanging();
						this._ProcessedDate = value;
						this.SendPropertyChanged("ProcessedDate");
						this.OnProcessedDateChanged();
					}
					this.SendPropertySetterInvoked("ProcessedDate", value);
				}
			}
			
			/// <summary>
			/// Column DbType=VarChar(15) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_OIB", DbType="VarChar(15) NOT NULL", CanBeNull=false)]
			public string OIB
			{
				get
				{
					return this._OIB;
				}
				set
				{
					if (this._OIB != value)
					{
						this.OnOIBChanging(value);
						this.SendPropertyChanging();
						this._OIB = value;
						this.SendPropertyChanged("OIB");
						this.OnOIBChanged();
					}
					this.SendPropertySetterInvoked("OIB", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(255) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_Naziv", DbType="NVarChar(255) NOT NULL", CanBeNull=false)]
			public string Naziv
			{
				get
				{
					return this._Naziv;
				}
				set
				{
					if (this._Naziv != value)
					{
						this.OnNazivChanging(value);
						this.SendPropertyChanging();
						this._Naziv = value;
						this.SendPropertyChanged("Naziv");
						this.OnNazivChanged();
					}
					this.SendPropertySetterInvoked("Naziv", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(255) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_Adresa", DbType="NVarChar(255) NOT NULL", CanBeNull=false)]
			public string Adresa
			{
				get
				{
					return this._Adresa;
				}
				set
				{
					if (this._Adresa != value)
					{
						this.OnAdresaChanging(value);
						this.SendPropertyChanging();
						this._Adresa = value;
						this.SendPropertyChanged("Adresa");
						this.OnAdresaChanged();
					}
					this.SendPropertySetterInvoked("Adresa", value);
				}
			}
			
			/// <summary>
			/// Column DbType=VarChar(10) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_PostanskiBroj", DbType="VarChar(10) NOT NULL", CanBeNull=false)]
			public string PostanskiBroj
			{
				get
				{
					return this._PostanskiBroj;
				}
				set
				{
					if (this._PostanskiBroj != value)
					{
						this.OnPostanskiBrojChanging(value);
						this.SendPropertyChanging();
						this._PostanskiBroj = value;
						this.SendPropertyChanged("PostanskiBroj");
						this.OnPostanskiBrojChanged();
					}
					this.SendPropertySetterInvoked("PostanskiBroj", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(100) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_PostanskiUred", DbType="NVarChar(100) NOT NULL", CanBeNull=false)]
			public string PostanskiUred
			{
				get
				{
					return this._PostanskiUred;
				}
				set
				{
					if (this._PostanskiUred != value)
					{
						this.OnPostanskiUredChanging(value);
						this.SendPropertyChanging();
						this._PostanskiUred = value;
						this.SendPropertyChanged("PostanskiUred");
						this.OnPostanskiUredChanged();
					}
					this.SendPropertySetterInvoked("PostanskiUred", value);
				}
			}
			
			/// <summary>
			/// Column DbType=VarChar(150) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_Email", DbType="VarChar(150) NOT NULL", CanBeNull=false)]
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
			/// Column DbType=VarChar(255) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_WebSite", DbType="VarChar(255) NOT NULL", CanBeNull=false)]
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
			/// Column DbType=VarChar(20) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_Telefon", DbType="VarChar(20) NOT NULL", CanBeNull=false)]
			public string Telefon
			{
				get
				{
					return this._Telefon;
				}
				set
				{
					if (this._Telefon != value)
					{
						this.OnTelefonChanging(value);
						this.SendPropertyChanging();
						this._Telefon = value;
						this.SendPropertyChanged("Telefon");
						this.OnTelefonChanged();
					}
					this.SendPropertySetterInvoked("Telefon", value);
				}
			}
			
			/// <summary>
			/// Column DbType=VarChar(20) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_Mobitel", DbType="VarChar(20) NOT NULL", CanBeNull=false)]
			public string Mobitel
			{
				get
				{
					return this._Mobitel;
				}
				set
				{
					if (this._Mobitel != value)
					{
						this.OnMobitelChanging(value);
						this.SendPropertyChanging();
						this._Mobitel = value;
						this.SendPropertyChanged("Mobitel");
						this.OnMobitelChanged();
					}
					this.SendPropertySetterInvoked("Mobitel", value);
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
		#endregion dbo.tblDirRegistration

		#region dbo.tblEmailOutbox
		[TableAttribute(Name="dbo.tblEmailOutbox")]
		public partial class tblEmailOutbox : EntityBase<tblEmailOutbox, dbArizonaAppDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private int _EmailOutboxID;
			private DateTime _InsertionDate;
			private string _FromEmail;
			private string _FromName;
			private string _ToEmail;
			private string _Subject;
			private string _BodyContent;
			private bool _IsBodyHtml;
			private DateTime? _SendDate;
			private string _Result;
			private int? _JobApplicationID;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnEmailOutboxIDChanging(int value);
			partial void OnEmailOutboxIDChanged();
			partial void OnInsertionDateChanging(DateTime value);
			partial void OnInsertionDateChanged();
			partial void OnFromEmailChanging(string value);
			partial void OnFromEmailChanged();
			partial void OnFromNameChanging(string value);
			partial void OnFromNameChanged();
			partial void OnToEmailChanging(string value);
			partial void OnToEmailChanged();
			partial void OnSubjectChanging(string value);
			partial void OnSubjectChanged();
			partial void OnBodyContentChanging(string value);
			partial void OnBodyContentChanged();
			partial void OnIsBodyHtmlChanging(bool value);
			partial void OnIsBodyHtmlChanged();
			partial void OnSendDateChanging(DateTime? value);
			partial void OnSendDateChanged();
			partial void OnResultChanging(string value);
			partial void OnResultChanged();
			partial void OnJobApplicationIDChanging(int? value);
			partial void OnJobApplicationIDChanged();
			#endregion

			public tblEmailOutbox()
			{
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=Int NOT NULL IDENTITY
			/// </summary>
			[ColumnAttribute(Storage="_EmailOutboxID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", CanBeNull=false, IsPrimaryKey=true, IsDbGenerated=true)]
			public int EmailOutboxID
			{
				get
				{
					return this._EmailOutboxID;
				}
				set
				{
					if (this._EmailOutboxID != value)
					{
						this.OnEmailOutboxIDChanging(value);
						this.SendPropertyChanging();
						this._EmailOutboxID = value;
						this.SendPropertyChanged("EmailOutboxID");
						this.OnEmailOutboxIDChanged();
					}
					this.SendPropertySetterInvoked("EmailOutboxID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_InsertionDate", DbType="DateTime NOT NULL", CanBeNull=false)]
			public DateTime InsertionDate
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
			/// Column DbType=VarChar(100) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_FromEmail", DbType="VarChar(100) NOT NULL", CanBeNull=false)]
			public string FromEmail
			{
				get
				{
					return this._FromEmail;
				}
				set
				{
					if (this._FromEmail != value)
					{
						this.OnFromEmailChanging(value);
						this.SendPropertyChanging();
						this._FromEmail = value;
						this.SendPropertyChanged("FromEmail");
						this.OnFromEmailChanged();
					}
					this.SendPropertySetterInvoked("FromEmail", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(100)
			/// </summary>
			[ColumnAttribute(Storage="_FromName", DbType="NVarChar(100)", CanBeNull=true)]
			public string FromName
			{
				get
				{
					return this._FromName;
				}
				set
				{
					if (this._FromName != value)
					{
						this.OnFromNameChanging(value);
						this.SendPropertyChanging();
						this._FromName = value;
						this.SendPropertyChanged("FromName");
						this.OnFromNameChanged();
					}
					this.SendPropertySetterInvoked("FromName", value);
				}
			}
			
			/// <summary>
			/// Column DbType=VarChar(100) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_ToEmail", DbType="VarChar(100) NOT NULL", CanBeNull=false)]
			public string ToEmail
			{
				get
				{
					return this._ToEmail;
				}
				set
				{
					if (this._ToEmail != value)
					{
						this.OnToEmailChanging(value);
						this.SendPropertyChanging();
						this._ToEmail = value;
						this.SendPropertyChanged("ToEmail");
						this.OnToEmailChanged();
					}
					this.SendPropertySetterInvoked("ToEmail", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(500) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_Subject", DbType="NVarChar(500) NOT NULL", CanBeNull=false)]
			public string Subject
			{
				get
				{
					return this._Subject;
				}
				set
				{
					if (this._Subject != value)
					{
						this.OnSubjectChanging(value);
						this.SendPropertyChanging();
						this._Subject = value;
						this.SendPropertyChanged("Subject");
						this.OnSubjectChanged();
					}
					this.SendPropertySetterInvoked("Subject", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(MAX) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_BodyContent", DbType="NVarChar(MAX) NOT NULL", CanBeNull=false)]
			public string BodyContent
			{
				get
				{
					return this._BodyContent;
				}
				set
				{
					if (this._BodyContent != value)
					{
						this.OnBodyContentChanging(value);
						this.SendPropertyChanging();
						this._BodyContent = value;
						this.SendPropertyChanged("BodyContent");
						this.OnBodyContentChanged();
					}
					this.SendPropertySetterInvoked("BodyContent", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Bit NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_IsBodyHtml", DbType="Bit NOT NULL", CanBeNull=false)]
			public bool IsBodyHtml
			{
				get
				{
					return this._IsBodyHtml;
				}
				set
				{
					if (this._IsBodyHtml != value)
					{
						this.OnIsBodyHtmlChanging(value);
						this.SendPropertyChanging();
						this._IsBodyHtml = value;
						this.SendPropertyChanged("IsBodyHtml");
						this.OnIsBodyHtmlChanged();
					}
					this.SendPropertySetterInvoked("IsBodyHtml", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime
			/// </summary>
			[ColumnAttribute(Storage="_SendDate", DbType="DateTime", CanBeNull=true)]
			public DateTime? SendDate
			{
				get
				{
					return this._SendDate;
				}
				set
				{
					if (this._SendDate != value)
					{
						this.OnSendDateChanging(value);
						this.SendPropertyChanging();
						this._SendDate = value;
						this.SendPropertyChanged("SendDate");
						this.OnSendDateChanged();
					}
					this.SendPropertySetterInvoked("SendDate", value);
				}
			}
			
			/// <summary>
			/// Column DbType=VarChar(50)
			/// </summary>
			[ColumnAttribute(Storage="_Result", DbType="VarChar(50)", CanBeNull=true)]
			public string Result
			{
				get
				{
					return this._Result;
				}
				set
				{
					if (this._Result != value)
					{
						this.OnResultChanging(value);
						this.SendPropertyChanging();
						this._Result = value;
						this.SendPropertyChanged("Result");
						this.OnResultChanged();
					}
					this.SendPropertySetterInvoked("Result", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int
			/// </summary>
			[ColumnAttribute(Storage="_JobApplicationID", DbType="Int", CanBeNull=true)]
			public int? JobApplicationID
			{
				get
				{
					return this._JobApplicationID;
				}
				set
				{
					if (this._JobApplicationID != value)
					{
						this.OnJobApplicationIDChanging(value);
						this.SendPropertyChanging();
						this._JobApplicationID = value;
						this.SendPropertyChanged("JobApplicationID");
						this.OnJobApplicationIDChanged();
					}
					this.SendPropertySetterInvoked("JobApplicationID", value);
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
		#endregion dbo.tblEmailOutbox

		#region dbo.tblFiskalRacunZahtjevLog
		[TableAttribute(Name="dbo.tblFiskalRacunZahtjevLog")]
		public partial class tblFiskalRacunZahtjevLog : EntityBase<tblFiskalRacunZahtjevLog, dbArizonaAppDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private long _FiskalRacunZahtjevLogID;
			private long _AppMemberID;
			private bool? _IsProdukcija;
			private long _BillDocumentID;
			private DateTime _InsertionDate;
			private string _FiskalniBrojRacuna;
			private string _OIBOperatora;
			private bool? _IsInPdvSustav;
			private DateTime? _DatumDokumenta;
			private decimal _PoreznaOsnovica;
			private decimal _IznosPdva;
			private decimal _IznosPorezPotrosnja;
			private decimal _SveukupniIznos;
			private string _ZKI;
			private string _OdgovorJIR;
			private string _OdgovorOpisGreske;
			private EntityRef<tblAppMember> _tblAppMember;
			private EntityRef<tblBillDocument> _tblBillDocument;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnFiskalRacunZahtjevLogIDChanging(long value);
			partial void OnFiskalRacunZahtjevLogIDChanged();
			partial void OnAppMemberIDChanging(long value);
			partial void OnAppMemberIDChanged();
			partial void OnIsProdukcijaChanging(bool? value);
			partial void OnIsProdukcijaChanged();
			partial void OnBillDocumentIDChanging(long value);
			partial void OnBillDocumentIDChanged();
			partial void OnInsertionDateChanging(DateTime value);
			partial void OnInsertionDateChanged();
			partial void OnFiskalniBrojRacunaChanging(string value);
			partial void OnFiskalniBrojRacunaChanged();
			partial void OnOIBOperatoraChanging(string value);
			partial void OnOIBOperatoraChanged();
			partial void OnIsInPdvSustavChanging(bool? value);
			partial void OnIsInPdvSustavChanged();
			partial void OnDatumDokumentaChanging(DateTime? value);
			partial void OnDatumDokumentaChanged();
			partial void OnPoreznaOsnovicaChanging(decimal value);
			partial void OnPoreznaOsnovicaChanged();
			partial void OnIznosPdvaChanging(decimal value);
			partial void OnIznosPdvaChanged();
			partial void OnIznosPorezPotrosnjaChanging(decimal value);
			partial void OnIznosPorezPotrosnjaChanged();
			partial void OnSveukupniIznosChanging(decimal value);
			partial void OnSveukupniIznosChanged();
			partial void OnZKIChanging(string value);
			partial void OnZKIChanged();
			partial void OnOdgovorJIRChanging(string value);
			partial void OnOdgovorJIRChanged();
			partial void OnOdgovorOpisGreskeChanging(string value);
			partial void OnOdgovorOpisGreskeChanged();
			#endregion

			public tblFiskalRacunZahtjevLog()
			{
				_tblAppMember = default(EntityRef<tblAppMember>);
				_tblBillDocument = default(EntityRef<tblBillDocument>);
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=BigInt NOT NULL IDENTITY
			/// </summary>
			[ColumnAttribute(Storage="_FiskalRacunZahtjevLogID", AutoSync=AutoSync.OnInsert, DbType="BigInt NOT NULL IDENTITY", CanBeNull=false, IsPrimaryKey=true, IsDbGenerated=true)]
			public long FiskalRacunZahtjevLogID
			{
				get
				{
					return this._FiskalRacunZahtjevLogID;
				}
				set
				{
					if (this._FiskalRacunZahtjevLogID != value)
					{
						this.OnFiskalRacunZahtjevLogIDChanging(value);
						this.SendPropertyChanging();
						this._FiskalRacunZahtjevLogID = value;
						this.SendPropertyChanged("FiskalRacunZahtjevLogID");
						this.OnFiskalRacunZahtjevLogIDChanged();
					}
					this.SendPropertySetterInvoked("FiskalRacunZahtjevLogID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=BigInt NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_AppMemberID", DbType="BigInt NOT NULL", CanBeNull=false)]
			public long AppMemberID
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
			/// Column DbType=Bit
			/// </summary>
			[ColumnAttribute(Storage="_IsProdukcija", DbType="Bit", CanBeNull=true)]
			public bool? IsProdukcija
			{
				get
				{
					return this._IsProdukcija;
				}
				set
				{
					if (this._IsProdukcija != value)
					{
						this.OnIsProdukcijaChanging(value);
						this.SendPropertyChanging();
						this._IsProdukcija = value;
						this.SendPropertyChanged("IsProdukcija");
						this.OnIsProdukcijaChanged();
					}
					this.SendPropertySetterInvoked("IsProdukcija", value);
				}
			}
			
			/// <summary>
			/// Column DbType=BigInt NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_BillDocumentID", DbType="BigInt NOT NULL", CanBeNull=false)]
			public long BillDocumentID
			{
				get
				{
					return this._BillDocumentID;
				}
				set
				{
					if (this._BillDocumentID != value)
					{
						this.OnBillDocumentIDChanging(value);
						this.SendPropertyChanging();
						this._BillDocumentID = value;
						this.SendPropertyChanged("BillDocumentID");
						this.OnBillDocumentIDChanged();
					}
					this.SendPropertySetterInvoked("BillDocumentID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_InsertionDate", DbType="DateTime NOT NULL", CanBeNull=false)]
			public DateTime InsertionDate
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
			/// Column DbType=VarChar(50) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_FiskalniBrojRacuna", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
			public string FiskalniBrojRacuna
			{
				get
				{
					return this._FiskalniBrojRacuna;
				}
				set
				{
					if (this._FiskalniBrojRacuna != value)
					{
						this.OnFiskalniBrojRacunaChanging(value);
						this.SendPropertyChanging();
						this._FiskalniBrojRacuna = value;
						this.SendPropertyChanged("FiskalniBrojRacuna");
						this.OnFiskalniBrojRacunaChanged();
					}
					this.SendPropertySetterInvoked("FiskalniBrojRacuna", value);
				}
			}
			
			/// <summary>
			/// Column DbType=VarChar(15)
			/// </summary>
			[ColumnAttribute(Storage="_OIBOperatora", DbType="VarChar(15)", CanBeNull=true)]
			public string OIBOperatora
			{
				get
				{
					return this._OIBOperatora;
				}
				set
				{
					if (this._OIBOperatora != value)
					{
						this.OnOIBOperatoraChanging(value);
						this.SendPropertyChanging();
						this._OIBOperatora = value;
						this.SendPropertyChanged("OIBOperatora");
						this.OnOIBOperatoraChanged();
					}
					this.SendPropertySetterInvoked("OIBOperatora", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Bit
			/// </summary>
			[ColumnAttribute(Storage="_IsInPdvSustav", DbType="Bit", CanBeNull=true)]
			public bool? IsInPdvSustav
			{
				get
				{
					return this._IsInPdvSustav;
				}
				set
				{
					if (this._IsInPdvSustav != value)
					{
						this.OnIsInPdvSustavChanging(value);
						this.SendPropertyChanging();
						this._IsInPdvSustav = value;
						this.SendPropertyChanged("IsInPdvSustav");
						this.OnIsInPdvSustavChanged();
					}
					this.SendPropertySetterInvoked("IsInPdvSustav", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime
			/// </summary>
			[ColumnAttribute(Storage="_DatumDokumenta", DbType="DateTime", CanBeNull=true)]
			public DateTime? DatumDokumenta
			{
				get
				{
					return this._DatumDokumenta;
				}
				set
				{
					if (this._DatumDokumenta != value)
					{
						this.OnDatumDokumentaChanging(value);
						this.SendPropertyChanging();
						this._DatumDokumenta = value;
						this.SendPropertyChanged("DatumDokumenta");
						this.OnDatumDokumentaChanged();
					}
					this.SendPropertySetterInvoked("DatumDokumenta", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Money NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_PoreznaOsnovica", DbType="Money NOT NULL", CanBeNull=false)]
			public decimal PoreznaOsnovica
			{
				get
				{
					return this._PoreznaOsnovica;
				}
				set
				{
					if (this._PoreznaOsnovica != value)
					{
						this.OnPoreznaOsnovicaChanging(value);
						this.SendPropertyChanging();
						this._PoreznaOsnovica = value;
						this.SendPropertyChanged("PoreznaOsnovica");
						this.OnPoreznaOsnovicaChanged();
					}
					this.SendPropertySetterInvoked("PoreznaOsnovica", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Money NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_IznosPdva", DbType="Money NOT NULL", CanBeNull=false)]
			public decimal IznosPdva
			{
				get
				{
					return this._IznosPdva;
				}
				set
				{
					if (this._IznosPdva != value)
					{
						this.OnIznosPdvaChanging(value);
						this.SendPropertyChanging();
						this._IznosPdva = value;
						this.SendPropertyChanged("IznosPdva");
						this.OnIznosPdvaChanged();
					}
					this.SendPropertySetterInvoked("IznosPdva", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Money NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_IznosPorezPotrosnja", DbType="Money NOT NULL", CanBeNull=false)]
			public decimal IznosPorezPotrosnja
			{
				get
				{
					return this._IznosPorezPotrosnja;
				}
				set
				{
					if (this._IznosPorezPotrosnja != value)
					{
						this.OnIznosPorezPotrosnjaChanging(value);
						this.SendPropertyChanging();
						this._IznosPorezPotrosnja = value;
						this.SendPropertyChanged("IznosPorezPotrosnja");
						this.OnIznosPorezPotrosnjaChanged();
					}
					this.SendPropertySetterInvoked("IznosPorezPotrosnja", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Money NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_SveukupniIznos", DbType="Money NOT NULL", CanBeNull=false)]
			public decimal SveukupniIznos
			{
				get
				{
					return this._SveukupniIznos;
				}
				set
				{
					if (this._SveukupniIznos != value)
					{
						this.OnSveukupniIznosChanging(value);
						this.SendPropertyChanging();
						this._SveukupniIznos = value;
						this.SendPropertyChanged("SveukupniIznos");
						this.OnSveukupniIznosChanged();
					}
					this.SendPropertySetterInvoked("SveukupniIznos", value);
				}
			}
			
			/// <summary>
			/// Column DbType=VarChar(100)
			/// </summary>
			[ColumnAttribute(Storage="_ZKI", DbType="VarChar(100)", CanBeNull=true)]
			public string ZKI
			{
				get
				{
					return this._ZKI;
				}
				set
				{
					if (this._ZKI != value)
					{
						this.OnZKIChanging(value);
						this.SendPropertyChanging();
						this._ZKI = value;
						this.SendPropertyChanged("ZKI");
						this.OnZKIChanged();
					}
					this.SendPropertySetterInvoked("ZKI", value);
				}
			}
			
			/// <summary>
			/// Column DbType=VarChar(100)
			/// </summary>
			[ColumnAttribute(Storage="_OdgovorJIR", DbType="VarChar(100)", CanBeNull=true)]
			public string OdgovorJIR
			{
				get
				{
					return this._OdgovorJIR;
				}
				set
				{
					if (this._OdgovorJIR != value)
					{
						this.OnOdgovorJIRChanging(value);
						this.SendPropertyChanging();
						this._OdgovorJIR = value;
						this.SendPropertyChanged("OdgovorJIR");
						this.OnOdgovorJIRChanged();
					}
					this.SendPropertySetterInvoked("OdgovorJIR", value);
				}
			}
			
			/// <summary>
			/// Column DbType=VarChar(MAX)
			/// </summary>
			[ColumnAttribute(Storage="_OdgovorOpisGreske", DbType="VarChar(MAX)", CanBeNull=true)]
			public string OdgovorOpisGreske
			{
				get
				{
					return this._OdgovorOpisGreske;
				}
				set
				{
					if (this._OdgovorOpisGreske != value)
					{
						this.OnOdgovorOpisGreskeChanging(value);
						this.SendPropertyChanging();
						this._OdgovorOpisGreske = value;
						this.SendPropertyChanged("OdgovorOpisGreske");
						this.OnOdgovorOpisGreskeChanged();
					}
					this.SendPropertySetterInvoked("OdgovorOpisGreske", value);
				}
			}
			
			#endregion Columns

			#region Associations
			/// <summary>
			/// Association [FK][Many]tblFiskalRacunZahtjevLog.AppMemberID --- [PK][One]tblAppMember.AppMemberID
			/// </summary>
			[AssociationAttribute(Name="FK_tblFiskalRacunZahtjevLog_tblAppMember", Storage="_tblAppMember", ThisKey="AppMemberID", OtherKey="AppMemberID", IsUnique=false, IsForeignKey=true)]
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
							previousValue.tblFiskalRacunZahtjevLogList.Remove(this);
						}
						this._tblAppMember.Entity = value;
						if (value != null)
						{
							value.tblFiskalRacunZahtjevLogList.Add(this);
							this._AppMemberID = value.AppMemberID;
						}
						else
						{
							this._AppMemberID = default(long);
						}
						this.SendPropertyChanged("tblAppMember");
					}
					this.SendPropertySetterInvoked("tblAppMember", value);
				}
			}
			
			/// <summary>
			/// Association [FK][Many]tblFiskalRacunZahtjevLog.BillDocumentID --- [PK][One]tblBillDocument.BillDocumentID
			/// </summary>
			[AssociationAttribute(Name="FK_tblFiskalRacunZahtjevLog_tblBillDocument", Storage="_tblBillDocument", ThisKey="BillDocumentID", OtherKey="BillDocumentID", IsUnique=false, IsForeignKey=true)]
			public tblBillDocument tblBillDocument
			{
				get
				{
					return this._tblBillDocument.Entity;
				}
				set
				{
					tblBillDocument previousValue = this._tblBillDocument.Entity;
					if ((previousValue != value) || (this._tblBillDocument.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._tblBillDocument.Entity = null;
							previousValue.tblFiskalRacunZahtjevLogList.Remove(this);
						}
						this._tblBillDocument.Entity = value;
						if (value != null)
						{
							value.tblFiskalRacunZahtjevLogList.Add(this);
							this._BillDocumentID = value.BillDocumentID;
						}
						else
						{
							this._BillDocumentID = default(long);
						}
						this.SendPropertyChanged("tblBillDocument");
					}
					this.SendPropertySetterInvoked("tblBillDocument", value);
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
		#endregion dbo.tblFiskalRacunZahtjevLog

		#region dbo.tblJobAdvert
		[TableAttribute(Name="dbo.tblJobAdvert")]
		public partial class tblJobAdvert : EntityBase<tblJobAdvert, dbArizonaAppDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private int _JobAdvertID;
			private int _BillFirmaID;
			private DateTime _InsertionDate;
			private DateTime? _StartDate;
			private DateTime? _EndDate;
			private string _Name;
			private int _ViewsCount;
			private string _Email;
			private string _JobDetails;
			private EntitySet<tblJobApplication> _tblJobApplicationList;
			private EntitySet<tblJobApplicationStatus> _tblJobApplicationStatusList;
			private EntityRef<tblBillFirma> _tblBillFirma;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnJobAdvertIDChanging(int value);
			partial void OnJobAdvertIDChanged();
			partial void OnBillFirmaIDChanging(int value);
			partial void OnBillFirmaIDChanged();
			partial void OnInsertionDateChanging(DateTime value);
			partial void OnInsertionDateChanged();
			partial void OnStartDateChanging(DateTime? value);
			partial void OnStartDateChanged();
			partial void OnEndDateChanging(DateTime? value);
			partial void OnEndDateChanged();
			partial void OnNameChanging(string value);
			partial void OnNameChanged();
			partial void OnViewsCountChanging(int value);
			partial void OnViewsCountChanged();
			partial void OnEmailChanging(string value);
			partial void OnEmailChanged();
			partial void OnJobDetailsChanging(string value);
			partial void OnJobDetailsChanged();
			#endregion

			public tblJobAdvert()
			{
				_tblJobApplicationList = new EntitySet<tblJobApplication>(
					new Action<tblJobApplication>(item=>{this.SendPropertyChanging(); item.tblJobAdvert=this;}), 
					new Action<tblJobApplication>(item=>{this.SendPropertyChanging(); item.tblJobAdvert=null;}));
				_tblJobApplicationStatusList = new EntitySet<tblJobApplicationStatus>(
					new Action<tblJobApplicationStatus>(item=>{this.SendPropertyChanging(); item.tblJobAdvert=this;}), 
					new Action<tblJobApplicationStatus>(item=>{this.SendPropertyChanging(); item.tblJobAdvert=null;}));
				_tblBillFirma = default(EntityRef<tblBillFirma>);
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=Int NOT NULL IDENTITY
			/// </summary>
			[ColumnAttribute(Storage="_JobAdvertID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", CanBeNull=false, IsPrimaryKey=true, IsDbGenerated=true)]
			public int JobAdvertID
			{
				get
				{
					return this._JobAdvertID;
				}
				set
				{
					if (this._JobAdvertID != value)
					{
						this.OnJobAdvertIDChanging(value);
						this.SendPropertyChanging();
						this._JobAdvertID = value;
						this.SendPropertyChanged("JobAdvertID");
						this.OnJobAdvertIDChanged();
					}
					this.SendPropertySetterInvoked("JobAdvertID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_BillFirmaID", DbType="Int NOT NULL", CanBeNull=false)]
			public int BillFirmaID
			{
				get
				{
					return this._BillFirmaID;
				}
				set
				{
					if (this._BillFirmaID != value)
					{
						this.OnBillFirmaIDChanging(value);
						this.SendPropertyChanging();
						this._BillFirmaID = value;
						this.SendPropertyChanged("BillFirmaID");
						this.OnBillFirmaIDChanged();
					}
					this.SendPropertySetterInvoked("BillFirmaID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_InsertionDate", DbType="DateTime NOT NULL", CanBeNull=false)]
			public DateTime InsertionDate
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
			/// Column DbType=DateTime
			/// </summary>
			[ColumnAttribute(Storage="_StartDate", DbType="DateTime", CanBeNull=true)]
			public DateTime? StartDate
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
			/// Column DbType=NVarChar(150)
			/// </summary>
			[ColumnAttribute(Storage="_Name", DbType="NVarChar(150)", CanBeNull=true)]
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
			[ColumnAttribute(Storage="_ViewsCount", DbType="Int NOT NULL", CanBeNull=false)]
			public int ViewsCount
			{
				get
				{
					return this._ViewsCount;
				}
				set
				{
					if (this._ViewsCount != value)
					{
						this.OnViewsCountChanging(value);
						this.SendPropertyChanging();
						this._ViewsCount = value;
						this.SendPropertyChanged("ViewsCount");
						this.OnViewsCountChanged();
					}
					this.SendPropertySetterInvoked("ViewsCount", value);
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
			/// Column DbType=NVarChar(MAX)
			/// </summary>
			[ColumnAttribute(Storage="_JobDetails", DbType="NVarChar(MAX)", CanBeNull=true)]
			public string JobDetails
			{
				get
				{
					return this._JobDetails;
				}
				set
				{
					if (this._JobDetails != value)
					{
						this.OnJobDetailsChanging(value);
						this.SendPropertyChanging();
						this._JobDetails = value;
						this.SendPropertyChanged("JobDetails");
						this.OnJobDetailsChanged();
					}
					this.SendPropertySetterInvoked("JobDetails", value);
				}
			}
			
			#endregion Columns

			#region Associations
			/// <summary>
			/// Association [PK][One]tblJobAdvert.JobAdvertID --- [FK][Many]tblJobApplication.JobAdvertID
			/// </summary>
			[AssociationAttribute(Name="FK_AppJobApplication_AppJobAdvert", Storage="_tblJobApplicationList", ThisKey="JobAdvertID", OtherKey="JobAdvertID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<tblJobApplication> tblJobApplicationList
			{
				get { return this._tblJobApplicationList; }
				set { this._tblJobApplicationList.Assign(value); }
			}
			
			/// <summary>
			/// Association [PK][One]tblJobAdvert.JobAdvertID --- [FK][Many]tblJobApplicationStatus.JobAdvertID
			/// </summary>
			[AssociationAttribute(Name="FK_JobApplicationStatus_JobAdvert", Storage="_tblJobApplicationStatusList", ThisKey="JobAdvertID", OtherKey="JobAdvertID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<tblJobApplicationStatus> tblJobApplicationStatusList
			{
				get { return this._tblJobApplicationStatusList; }
				set { this._tblJobApplicationStatusList.Assign(value); }
			}
			
			/// <summary>
			/// Association [FK][Many]tblJobAdvert.BillFirmaID --- [PK][One]tblBillFirma.BillFirmaID
			/// </summary>
			[AssociationAttribute(Name="FK_tblJobAdvert_tblBillFirma", Storage="_tblBillFirma", ThisKey="BillFirmaID", OtherKey="BillFirmaID", IsUnique=false, IsForeignKey=true)]
			public tblBillFirma tblBillFirma
			{
				get
				{
					return this._tblBillFirma.Entity;
				}
				set
				{
					tblBillFirma previousValue = this._tblBillFirma.Entity;
					if ((previousValue != value) || (this._tblBillFirma.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._tblBillFirma.Entity = null;
							previousValue.tblJobAdvertList.Remove(this);
						}
						this._tblBillFirma.Entity = value;
						if (value != null)
						{
							value.tblJobAdvertList.Add(this);
							this._BillFirmaID = value.BillFirmaID;
						}
						else
						{
							this._BillFirmaID = default(int);
						}
						this.SendPropertyChanged("tblBillFirma");
					}
					this.SendPropertySetterInvoked("tblBillFirma", value);
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
		#endregion dbo.tblJobAdvert

		#region dbo.tblJobApplication
		[TableAttribute(Name="dbo.tblJobApplication")]
		public partial class tblJobApplication : EntityBase<tblJobApplication, dbArizonaAppDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private int _JobApplicationID;
			private int _JobAdvertID;
			private int? _JobApplicationStatusID;
			private DateTime _InsertionDate;
			private string _FirstName;
			private string _LastName;
			private string _Email;
			private DateTime? _BirthDate;
			private string _Gender;
			private string _MobileNumber;
			private string _EmploymentStatus;
			private string _StreetName;
			private int? _StreetNumber;
			private string _CityBlock;
			private int? _PostCode;
			private string _City;
			private bool? _HasDrivingLicense;
			private bool? _HasCar;
			private bool? _ActiveCarDriver;
			private bool? _MjeraStrucnoOsposobljavanje;
			private string _Education;
			private string _WorkExperience;
			private string _PersonalDescription;
			private string _WhereFoundUs;
			private bool? _IncludeSimilarJobs;
			private string _JobTitle;
			private int? _Score;
			private bool? _IsDisabled;
			private DateTime? _MaxInterviewDate;
			private int? _EvaluationGeneral;
			private int? _EvaluationClothing;
			private int? _EvaluationAttitude;
			private int? _EvaluationAskingQuestions;
			private int? _EvaluationTechicalKnowledge;
			private int? _EvaluationCommunicationVerbal;
			private int? _EvaluationCommunicationNonVerbal;
			private int? _HeightCm;
			private int? _WeightKg;
			private string _ClothingSize;
			private string _ShoeSize;
			private string _HairLength;
			private string _EyeSight;
			private EntityRef<tblJobAdvert> _tblJobAdvert;
			private EntitySet<tblJobApplicationDocument> _tblJobApplicationDocumentList;
			private EntitySet<tblJobApplicationImage> _tblJobApplicationImageList;
			private EntitySet<tblJobApplicationSchedule> _tblJobApplicationScheduleList;
			private EntitySet<tblAppSchedule> _tblAppScheduleList;
			private EntityRef<tblJobApplicationStatus> _tblJobApplicationStatus;
			private EntitySet<tblJobApplicationNote> _tblJobApplicationNoteList;
			private EntitySet<tblSmsOutbox> _tblSmsOutboxList;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnJobApplicationIDChanging(int value);
			partial void OnJobApplicationIDChanged();
			partial void OnJobAdvertIDChanging(int value);
			partial void OnJobAdvertIDChanged();
			partial void OnJobApplicationStatusIDChanging(int? value);
			partial void OnJobApplicationStatusIDChanged();
			partial void OnInsertionDateChanging(DateTime value);
			partial void OnInsertionDateChanged();
			partial void OnFirstNameChanging(string value);
			partial void OnFirstNameChanged();
			partial void OnLastNameChanging(string value);
			partial void OnLastNameChanged();
			partial void OnEmailChanging(string value);
			partial void OnEmailChanged();
			partial void OnBirthDateChanging(DateTime? value);
			partial void OnBirthDateChanged();
			partial void OnGenderChanging(string value);
			partial void OnGenderChanged();
			partial void OnMobileNumberChanging(string value);
			partial void OnMobileNumberChanged();
			partial void OnEmploymentStatusChanging(string value);
			partial void OnEmploymentStatusChanged();
			partial void OnStreetNameChanging(string value);
			partial void OnStreetNameChanged();
			partial void OnStreetNumberChanging(int? value);
			partial void OnStreetNumberChanged();
			partial void OnCityBlockChanging(string value);
			partial void OnCityBlockChanged();
			partial void OnPostCodeChanging(int? value);
			partial void OnPostCodeChanged();
			partial void OnCityChanging(string value);
			partial void OnCityChanged();
			partial void OnHasDrivingLicenseChanging(bool? value);
			partial void OnHasDrivingLicenseChanged();
			partial void OnHasCarChanging(bool? value);
			partial void OnHasCarChanged();
			partial void OnActiveCarDriverChanging(bool? value);
			partial void OnActiveCarDriverChanged();
			partial void OnMjeraStrucnoOsposobljavanjeChanging(bool? value);
			partial void OnMjeraStrucnoOsposobljavanjeChanged();
			partial void OnEducationChanging(string value);
			partial void OnEducationChanged();
			partial void OnWorkExperienceChanging(string value);
			partial void OnWorkExperienceChanged();
			partial void OnPersonalDescriptionChanging(string value);
			partial void OnPersonalDescriptionChanged();
			partial void OnWhereFoundUsChanging(string value);
			partial void OnWhereFoundUsChanged();
			partial void OnIncludeSimilarJobsChanging(bool? value);
			partial void OnIncludeSimilarJobsChanged();
			partial void OnJobTitleChanging(string value);
			partial void OnJobTitleChanged();
			partial void OnScoreChanging(int? value);
			partial void OnScoreChanged();
			partial void OnIsDisabledChanging(bool? value);
			partial void OnIsDisabledChanged();
			partial void OnMaxInterviewDateChanging(DateTime? value);
			partial void OnMaxInterviewDateChanged();
			partial void OnEvaluationGeneralChanging(int? value);
			partial void OnEvaluationGeneralChanged();
			partial void OnEvaluationClothingChanging(int? value);
			partial void OnEvaluationClothingChanged();
			partial void OnEvaluationAttitudeChanging(int? value);
			partial void OnEvaluationAttitudeChanged();
			partial void OnEvaluationAskingQuestionsChanging(int? value);
			partial void OnEvaluationAskingQuestionsChanged();
			partial void OnEvaluationTechicalKnowledgeChanging(int? value);
			partial void OnEvaluationTechicalKnowledgeChanged();
			partial void OnEvaluationCommunicationVerbalChanging(int? value);
			partial void OnEvaluationCommunicationVerbalChanged();
			partial void OnEvaluationCommunicationNonVerbalChanging(int? value);
			partial void OnEvaluationCommunicationNonVerbalChanged();
			partial void OnHeightCmChanging(int? value);
			partial void OnHeightCmChanged();
			partial void OnWeightKgChanging(int? value);
			partial void OnWeightKgChanged();
			partial void OnClothingSizeChanging(string value);
			partial void OnClothingSizeChanged();
			partial void OnShoeSizeChanging(string value);
			partial void OnShoeSizeChanged();
			partial void OnHairLengthChanging(string value);
			partial void OnHairLengthChanged();
			partial void OnEyeSightChanging(string value);
			partial void OnEyeSightChanged();
			#endregion

			public tblJobApplication()
			{
				_tblJobAdvert = default(EntityRef<tblJobAdvert>);
				_tblJobApplicationDocumentList = new EntitySet<tblJobApplicationDocument>(
					new Action<tblJobApplicationDocument>(item=>{this.SendPropertyChanging(); item.tblJobApplication=this;}), 
					new Action<tblJobApplicationDocument>(item=>{this.SendPropertyChanging(); item.tblJobApplication=null;}));
				_tblJobApplicationImageList = new EntitySet<tblJobApplicationImage>(
					new Action<tblJobApplicationImage>(item=>{this.SendPropertyChanging(); item.tblJobApplication=this;}), 
					new Action<tblJobApplicationImage>(item=>{this.SendPropertyChanging(); item.tblJobApplication=null;}));
				_tblJobApplicationScheduleList = new EntitySet<tblJobApplicationSchedule>(
					new Action<tblJobApplicationSchedule>(item=>{this.SendPropertyChanging(); item.tblJobApplication=this;}), 
					new Action<tblJobApplicationSchedule>(item=>{this.SendPropertyChanging(); item.tblJobApplication=null;}));
				_tblAppScheduleList = new EntitySet<tblAppSchedule>(
					new Action<tblAppSchedule>(item=>{this.SendPropertyChanging(); item.tblJobApplication=this;}), 
					new Action<tblAppSchedule>(item=>{this.SendPropertyChanging(); item.tblJobApplication=null;}));
				_tblJobApplicationStatus = default(EntityRef<tblJobApplicationStatus>);
				_tblJobApplicationNoteList = new EntitySet<tblJobApplicationNote>(
					new Action<tblJobApplicationNote>(item=>{this.SendPropertyChanging(); item.tblJobApplication=this;}), 
					new Action<tblJobApplicationNote>(item=>{this.SendPropertyChanging(); item.tblJobApplication=null;}));
				_tblSmsOutboxList = new EntitySet<tblSmsOutbox>(
					new Action<tblSmsOutbox>(item=>{this.SendPropertyChanging(); item.tblJobApplication=this;}), 
					new Action<tblSmsOutbox>(item=>{this.SendPropertyChanging(); item.tblJobApplication=null;}));
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=Int NOT NULL IDENTITY
			/// </summary>
			[ColumnAttribute(Storage="_JobApplicationID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", CanBeNull=false, IsPrimaryKey=true, IsDbGenerated=true)]
			public int JobApplicationID
			{
				get
				{
					return this._JobApplicationID;
				}
				set
				{
					if (this._JobApplicationID != value)
					{
						this.OnJobApplicationIDChanging(value);
						this.SendPropertyChanging();
						this._JobApplicationID = value;
						this.SendPropertyChanged("JobApplicationID");
						this.OnJobApplicationIDChanged();
					}
					this.SendPropertySetterInvoked("JobApplicationID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_JobAdvertID", DbType="Int NOT NULL", CanBeNull=false)]
			public int JobAdvertID
			{
				get
				{
					return this._JobAdvertID;
				}
				set
				{
					if (this._JobAdvertID != value)
					{
						this.OnJobAdvertIDChanging(value);
						this.SendPropertyChanging();
						this._JobAdvertID = value;
						this.SendPropertyChanged("JobAdvertID");
						this.OnJobAdvertIDChanged();
					}
					this.SendPropertySetterInvoked("JobAdvertID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int
			/// </summary>
			[ColumnAttribute(Storage="_JobApplicationStatusID", DbType="Int", CanBeNull=true)]
			public int? JobApplicationStatusID
			{
				get
				{
					return this._JobApplicationStatusID;
				}
				set
				{
					if (this._JobApplicationStatusID != value)
					{
						this.OnJobApplicationStatusIDChanging(value);
						this.SendPropertyChanging();
						this._JobApplicationStatusID = value;
						this.SendPropertyChanged("JobApplicationStatusID");
						this.OnJobApplicationStatusIDChanged();
					}
					this.SendPropertySetterInvoked("JobApplicationStatusID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_InsertionDate", DbType="DateTime NOT NULL", CanBeNull=false)]
			public DateTime InsertionDate
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
			/// Column DbType=NVarChar(150)
			/// </summary>
			[ColumnAttribute(Storage="_Email", DbType="NVarChar(150)", CanBeNull=true)]
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
			/// Column DbType=NVarChar(50)
			/// </summary>
			[ColumnAttribute(Storage="_Gender", DbType="NVarChar(50)", CanBeNull=true)]
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
			/// Column DbType=VarChar(50)
			/// </summary>
			[ColumnAttribute(Storage="_MobileNumber", DbType="VarChar(50)", CanBeNull=true)]
			public string MobileNumber
			{
				get
				{
					return this._MobileNumber;
				}
				set
				{
					if (this._MobileNumber != value)
					{
						this.OnMobileNumberChanging(value);
						this.SendPropertyChanging();
						this._MobileNumber = value;
						this.SendPropertyChanged("MobileNumber");
						this.OnMobileNumberChanged();
					}
					this.SendPropertySetterInvoked("MobileNumber", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(100)
			/// </summary>
			[ColumnAttribute(Storage="_EmploymentStatus", DbType="NVarChar(100)", CanBeNull=true)]
			public string EmploymentStatus
			{
				get
				{
					return this._EmploymentStatus;
				}
				set
				{
					if (this._EmploymentStatus != value)
					{
						this.OnEmploymentStatusChanging(value);
						this.SendPropertyChanging();
						this._EmploymentStatus = value;
						this.SendPropertyChanged("EmploymentStatus");
						this.OnEmploymentStatusChanged();
					}
					this.SendPropertySetterInvoked("EmploymentStatus", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(150)
			/// </summary>
			[ColumnAttribute(Storage="_StreetName", DbType="NVarChar(150)", CanBeNull=true)]
			public string StreetName
			{
				get
				{
					return this._StreetName;
				}
				set
				{
					if (this._StreetName != value)
					{
						this.OnStreetNameChanging(value);
						this.SendPropertyChanging();
						this._StreetName = value;
						this.SendPropertyChanged("StreetName");
						this.OnStreetNameChanged();
					}
					this.SendPropertySetterInvoked("StreetName", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int
			/// </summary>
			[ColumnAttribute(Storage="_StreetNumber", DbType="Int", CanBeNull=true)]
			public int? StreetNumber
			{
				get
				{
					return this._StreetNumber;
				}
				set
				{
					if (this._StreetNumber != value)
					{
						this.OnStreetNumberChanging(value);
						this.SendPropertyChanging();
						this._StreetNumber = value;
						this.SendPropertyChanged("StreetNumber");
						this.OnStreetNumberChanged();
					}
					this.SendPropertySetterInvoked("StreetNumber", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(150)
			/// </summary>
			[ColumnAttribute(Storage="_CityBlock", DbType="NVarChar(150)", CanBeNull=true)]
			public string CityBlock
			{
				get
				{
					return this._CityBlock;
				}
				set
				{
					if (this._CityBlock != value)
					{
						this.OnCityBlockChanging(value);
						this.SendPropertyChanging();
						this._CityBlock = value;
						this.SendPropertyChanged("CityBlock");
						this.OnCityBlockChanged();
					}
					this.SendPropertySetterInvoked("CityBlock", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int
			/// </summary>
			[ColumnAttribute(Storage="_PostCode", DbType="Int", CanBeNull=true)]
			public int? PostCode
			{
				get
				{
					return this._PostCode;
				}
				set
				{
					if (this._PostCode != value)
					{
						this.OnPostCodeChanging(value);
						this.SendPropertyChanging();
						this._PostCode = value;
						this.SendPropertyChanged("PostCode");
						this.OnPostCodeChanged();
					}
					this.SendPropertySetterInvoked("PostCode", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(150)
			/// </summary>
			[ColumnAttribute(Storage="_City", DbType="NVarChar(150)", CanBeNull=true)]
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
			/// Column DbType=Bit
			/// </summary>
			[ColumnAttribute(Storage="_HasDrivingLicense", DbType="Bit", CanBeNull=true)]
			public bool? HasDrivingLicense
			{
				get
				{
					return this._HasDrivingLicense;
				}
				set
				{
					if (this._HasDrivingLicense != value)
					{
						this.OnHasDrivingLicenseChanging(value);
						this.SendPropertyChanging();
						this._HasDrivingLicense = value;
						this.SendPropertyChanged("HasDrivingLicense");
						this.OnHasDrivingLicenseChanged();
					}
					this.SendPropertySetterInvoked("HasDrivingLicense", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Bit
			/// </summary>
			[ColumnAttribute(Storage="_HasCar", DbType="Bit", CanBeNull=true)]
			public bool? HasCar
			{
				get
				{
					return this._HasCar;
				}
				set
				{
					if (this._HasCar != value)
					{
						this.OnHasCarChanging(value);
						this.SendPropertyChanging();
						this._HasCar = value;
						this.SendPropertyChanged("HasCar");
						this.OnHasCarChanged();
					}
					this.SendPropertySetterInvoked("HasCar", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Bit
			/// </summary>
			[ColumnAttribute(Storage="_ActiveCarDriver", DbType="Bit", CanBeNull=true)]
			public bool? ActiveCarDriver
			{
				get
				{
					return this._ActiveCarDriver;
				}
				set
				{
					if (this._ActiveCarDriver != value)
					{
						this.OnActiveCarDriverChanging(value);
						this.SendPropertyChanging();
						this._ActiveCarDriver = value;
						this.SendPropertyChanged("ActiveCarDriver");
						this.OnActiveCarDriverChanged();
					}
					this.SendPropertySetterInvoked("ActiveCarDriver", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Bit
			/// </summary>
			[ColumnAttribute(Storage="_MjeraStrucnoOsposobljavanje", DbType="Bit", CanBeNull=true)]
			public bool? MjeraStrucnoOsposobljavanje
			{
				get
				{
					return this._MjeraStrucnoOsposobljavanje;
				}
				set
				{
					if (this._MjeraStrucnoOsposobljavanje != value)
					{
						this.OnMjeraStrucnoOsposobljavanjeChanging(value);
						this.SendPropertyChanging();
						this._MjeraStrucnoOsposobljavanje = value;
						this.SendPropertyChanged("MjeraStrucnoOsposobljavanje");
						this.OnMjeraStrucnoOsposobljavanjeChanged();
					}
					this.SendPropertySetterInvoked("MjeraStrucnoOsposobljavanje", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(2000)
			/// </summary>
			[ColumnAttribute(Storage="_Education", DbType="NVarChar(2000)", CanBeNull=true)]
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
			/// Column DbType=NVarChar(2000)
			/// </summary>
			[ColumnAttribute(Storage="_WorkExperience", DbType="NVarChar(2000)", CanBeNull=true)]
			public string WorkExperience
			{
				get
				{
					return this._WorkExperience;
				}
				set
				{
					if (this._WorkExperience != value)
					{
						this.OnWorkExperienceChanging(value);
						this.SendPropertyChanging();
						this._WorkExperience = value;
						this.SendPropertyChanged("WorkExperience");
						this.OnWorkExperienceChanged();
					}
					this.SendPropertySetterInvoked("WorkExperience", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(2000)
			/// </summary>
			[ColumnAttribute(Storage="_PersonalDescription", DbType="NVarChar(2000)", CanBeNull=true)]
			public string PersonalDescription
			{
				get
				{
					return this._PersonalDescription;
				}
				set
				{
					if (this._PersonalDescription != value)
					{
						this.OnPersonalDescriptionChanging(value);
						this.SendPropertyChanging();
						this._PersonalDescription = value;
						this.SendPropertyChanged("PersonalDescription");
						this.OnPersonalDescriptionChanged();
					}
					this.SendPropertySetterInvoked("PersonalDescription", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(100)
			/// </summary>
			[ColumnAttribute(Storage="_WhereFoundUs", DbType="NVarChar(100)", CanBeNull=true)]
			public string WhereFoundUs
			{
				get
				{
					return this._WhereFoundUs;
				}
				set
				{
					if (this._WhereFoundUs != value)
					{
						this.OnWhereFoundUsChanging(value);
						this.SendPropertyChanging();
						this._WhereFoundUs = value;
						this.SendPropertyChanged("WhereFoundUs");
						this.OnWhereFoundUsChanged();
					}
					this.SendPropertySetterInvoked("WhereFoundUs", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Bit
			/// </summary>
			[ColumnAttribute(Storage="_IncludeSimilarJobs", DbType="Bit", CanBeNull=true)]
			public bool? IncludeSimilarJobs
			{
				get
				{
					return this._IncludeSimilarJobs;
				}
				set
				{
					if (this._IncludeSimilarJobs != value)
					{
						this.OnIncludeSimilarJobsChanging(value);
						this.SendPropertyChanging();
						this._IncludeSimilarJobs = value;
						this.SendPropertyChanged("IncludeSimilarJobs");
						this.OnIncludeSimilarJobsChanged();
					}
					this.SendPropertySetterInvoked("IncludeSimilarJobs", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(255)
			/// </summary>
			[ColumnAttribute(Storage="_JobTitle", DbType="NVarChar(255)", CanBeNull=true)]
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
			/// Column DbType=Int
			/// </summary>
			[ColumnAttribute(Storage="_Score", DbType="Int", CanBeNull=true)]
			public int? Score
			{
				get
				{
					return this._Score;
				}
				set
				{
					if (this._Score != value)
					{
						this.OnScoreChanging(value);
						this.SendPropertyChanging();
						this._Score = value;
						this.SendPropertyChanged("Score");
						this.OnScoreChanged();
					}
					this.SendPropertySetterInvoked("Score", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Bit
			/// </summary>
			[ColumnAttribute(Storage="_IsDisabled", DbType="Bit", CanBeNull=true)]
			public bool? IsDisabled
			{
				get
				{
					return this._IsDisabled;
				}
				set
				{
					if (this._IsDisabled != value)
					{
						this.OnIsDisabledChanging(value);
						this.SendPropertyChanging();
						this._IsDisabled = value;
						this.SendPropertyChanged("IsDisabled");
						this.OnIsDisabledChanged();
					}
					this.SendPropertySetterInvoked("IsDisabled", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime
			/// </summary>
			[ColumnAttribute(Storage="_MaxInterviewDate", DbType="DateTime", CanBeNull=true)]
			public DateTime? MaxInterviewDate
			{
				get
				{
					return this._MaxInterviewDate;
				}
				set
				{
					if (this._MaxInterviewDate != value)
					{
						this.OnMaxInterviewDateChanging(value);
						this.SendPropertyChanging();
						this._MaxInterviewDate = value;
						this.SendPropertyChanged("MaxInterviewDate");
						this.OnMaxInterviewDateChanged();
					}
					this.SendPropertySetterInvoked("MaxInterviewDate", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int
			/// </summary>
			[ColumnAttribute(Storage="_EvaluationGeneral", DbType="Int", CanBeNull=true)]
			public int? EvaluationGeneral
			{
				get
				{
					return this._EvaluationGeneral;
				}
				set
				{
					if (this._EvaluationGeneral != value)
					{
						this.OnEvaluationGeneralChanging(value);
						this.SendPropertyChanging();
						this._EvaluationGeneral = value;
						this.SendPropertyChanged("EvaluationGeneral");
						this.OnEvaluationGeneralChanged();
					}
					this.SendPropertySetterInvoked("EvaluationGeneral", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int
			/// </summary>
			[ColumnAttribute(Storage="_EvaluationClothing", DbType="Int", CanBeNull=true)]
			public int? EvaluationClothing
			{
				get
				{
					return this._EvaluationClothing;
				}
				set
				{
					if (this._EvaluationClothing != value)
					{
						this.OnEvaluationClothingChanging(value);
						this.SendPropertyChanging();
						this._EvaluationClothing = value;
						this.SendPropertyChanged("EvaluationClothing");
						this.OnEvaluationClothingChanged();
					}
					this.SendPropertySetterInvoked("EvaluationClothing", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int
			/// </summary>
			[ColumnAttribute(Storage="_EvaluationAttitude", DbType="Int", CanBeNull=true)]
			public int? EvaluationAttitude
			{
				get
				{
					return this._EvaluationAttitude;
				}
				set
				{
					if (this._EvaluationAttitude != value)
					{
						this.OnEvaluationAttitudeChanging(value);
						this.SendPropertyChanging();
						this._EvaluationAttitude = value;
						this.SendPropertyChanged("EvaluationAttitude");
						this.OnEvaluationAttitudeChanged();
					}
					this.SendPropertySetterInvoked("EvaluationAttitude", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int
			/// </summary>
			[ColumnAttribute(Storage="_EvaluationAskingQuestions", DbType="Int", CanBeNull=true)]
			public int? EvaluationAskingQuestions
			{
				get
				{
					return this._EvaluationAskingQuestions;
				}
				set
				{
					if (this._EvaluationAskingQuestions != value)
					{
						this.OnEvaluationAskingQuestionsChanging(value);
						this.SendPropertyChanging();
						this._EvaluationAskingQuestions = value;
						this.SendPropertyChanged("EvaluationAskingQuestions");
						this.OnEvaluationAskingQuestionsChanged();
					}
					this.SendPropertySetterInvoked("EvaluationAskingQuestions", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int
			/// </summary>
			[ColumnAttribute(Storage="_EvaluationTechicalKnowledge", DbType="Int", CanBeNull=true)]
			public int? EvaluationTechicalKnowledge
			{
				get
				{
					return this._EvaluationTechicalKnowledge;
				}
				set
				{
					if (this._EvaluationTechicalKnowledge != value)
					{
						this.OnEvaluationTechicalKnowledgeChanging(value);
						this.SendPropertyChanging();
						this._EvaluationTechicalKnowledge = value;
						this.SendPropertyChanged("EvaluationTechicalKnowledge");
						this.OnEvaluationTechicalKnowledgeChanged();
					}
					this.SendPropertySetterInvoked("EvaluationTechicalKnowledge", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int
			/// </summary>
			[ColumnAttribute(Storage="_EvaluationCommunicationVerbal", DbType="Int", CanBeNull=true)]
			public int? EvaluationCommunicationVerbal
			{
				get
				{
					return this._EvaluationCommunicationVerbal;
				}
				set
				{
					if (this._EvaluationCommunicationVerbal != value)
					{
						this.OnEvaluationCommunicationVerbalChanging(value);
						this.SendPropertyChanging();
						this._EvaluationCommunicationVerbal = value;
						this.SendPropertyChanged("EvaluationCommunicationVerbal");
						this.OnEvaluationCommunicationVerbalChanged();
					}
					this.SendPropertySetterInvoked("EvaluationCommunicationVerbal", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int
			/// </summary>
			[ColumnAttribute(Storage="_EvaluationCommunicationNonVerbal", DbType="Int", CanBeNull=true)]
			public int? EvaluationCommunicationNonVerbal
			{
				get
				{
					return this._EvaluationCommunicationNonVerbal;
				}
				set
				{
					if (this._EvaluationCommunicationNonVerbal != value)
					{
						this.OnEvaluationCommunicationNonVerbalChanging(value);
						this.SendPropertyChanging();
						this._EvaluationCommunicationNonVerbal = value;
						this.SendPropertyChanged("EvaluationCommunicationNonVerbal");
						this.OnEvaluationCommunicationNonVerbalChanged();
					}
					this.SendPropertySetterInvoked("EvaluationCommunicationNonVerbal", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int
			/// </summary>
			[ColumnAttribute(Storage="_HeightCm", DbType="Int", CanBeNull=true)]
			public int? HeightCm
			{
				get
				{
					return this._HeightCm;
				}
				set
				{
					if (this._HeightCm != value)
					{
						this.OnHeightCmChanging(value);
						this.SendPropertyChanging();
						this._HeightCm = value;
						this.SendPropertyChanged("HeightCm");
						this.OnHeightCmChanged();
					}
					this.SendPropertySetterInvoked("HeightCm", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int
			/// </summary>
			[ColumnAttribute(Storage="_WeightKg", DbType="Int", CanBeNull=true)]
			public int? WeightKg
			{
				get
				{
					return this._WeightKg;
				}
				set
				{
					if (this._WeightKg != value)
					{
						this.OnWeightKgChanging(value);
						this.SendPropertyChanging();
						this._WeightKg = value;
						this.SendPropertyChanged("WeightKg");
						this.OnWeightKgChanged();
					}
					this.SendPropertySetterInvoked("WeightKg", value);
				}
			}
			
			/// <summary>
			/// Column DbType=VarChar(50)
			/// </summary>
			[ColumnAttribute(Storage="_ClothingSize", DbType="VarChar(50)", CanBeNull=true)]
			public string ClothingSize
			{
				get
				{
					return this._ClothingSize;
				}
				set
				{
					if (this._ClothingSize != value)
					{
						this.OnClothingSizeChanging(value);
						this.SendPropertyChanging();
						this._ClothingSize = value;
						this.SendPropertyChanged("ClothingSize");
						this.OnClothingSizeChanged();
					}
					this.SendPropertySetterInvoked("ClothingSize", value);
				}
			}
			
			/// <summary>
			/// Column DbType=VarChar(50)
			/// </summary>
			[ColumnAttribute(Storage="_ShoeSize", DbType="VarChar(50)", CanBeNull=true)]
			public string ShoeSize
			{
				get
				{
					return this._ShoeSize;
				}
				set
				{
					if (this._ShoeSize != value)
					{
						this.OnShoeSizeChanging(value);
						this.SendPropertyChanging();
						this._ShoeSize = value;
						this.SendPropertyChanged("ShoeSize");
						this.OnShoeSizeChanged();
					}
					this.SendPropertySetterInvoked("ShoeSize", value);
				}
			}
			
			/// <summary>
			/// Column DbType=VarChar(50)
			/// </summary>
			[ColumnAttribute(Storage="_HairLength", DbType="VarChar(50)", CanBeNull=true)]
			public string HairLength
			{
				get
				{
					return this._HairLength;
				}
				set
				{
					if (this._HairLength != value)
					{
						this.OnHairLengthChanging(value);
						this.SendPropertyChanging();
						this._HairLength = value;
						this.SendPropertyChanged("HairLength");
						this.OnHairLengthChanged();
					}
					this.SendPropertySetterInvoked("HairLength", value);
				}
			}
			
			/// <summary>
			/// Column DbType=VarChar(50)
			/// </summary>
			[ColumnAttribute(Storage="_EyeSight", DbType="VarChar(50)", CanBeNull=true)]
			public string EyeSight
			{
				get
				{
					return this._EyeSight;
				}
				set
				{
					if (this._EyeSight != value)
					{
						this.OnEyeSightChanging(value);
						this.SendPropertyChanging();
						this._EyeSight = value;
						this.SendPropertyChanged("EyeSight");
						this.OnEyeSightChanged();
					}
					this.SendPropertySetterInvoked("EyeSight", value);
				}
			}
			
			#endregion Columns

			#region Associations
			/// <summary>
			/// Association [FK][Many]tblJobApplication.JobAdvertID --- [PK][One]tblJobAdvert.JobAdvertID
			/// </summary>
			[AssociationAttribute(Name="FK_AppJobApplication_AppJobAdvert", Storage="_tblJobAdvert", ThisKey="JobAdvertID", OtherKey="JobAdvertID", IsUnique=false, IsForeignKey=true)]
			public tblJobAdvert tblJobAdvert
			{
				get
				{
					return this._tblJobAdvert.Entity;
				}
				set
				{
					tblJobAdvert previousValue = this._tblJobAdvert.Entity;
					if ((previousValue != value) || (this._tblJobAdvert.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._tblJobAdvert.Entity = null;
							previousValue.tblJobApplicationList.Remove(this);
						}
						this._tblJobAdvert.Entity = value;
						if (value != null)
						{
							value.tblJobApplicationList.Add(this);
							this._JobAdvertID = value.JobAdvertID;
						}
						else
						{
							this._JobAdvertID = default(int);
						}
						this.SendPropertyChanged("tblJobAdvert");
					}
					this.SendPropertySetterInvoked("tblJobAdvert", value);
				}
			}
			
			/// <summary>
			/// Association [PK][One]tblJobApplication.JobApplicationID --- [FK][Many]tblJobApplicationDocument.JobApplicationID
			/// </summary>
			[AssociationAttribute(Name="FK_AppJobApplicationDocument_AppJobApplication", Storage="_tblJobApplicationDocumentList", ThisKey="JobApplicationID", OtherKey="JobApplicationID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<tblJobApplicationDocument> tblJobApplicationDocumentList
			{
				get { return this._tblJobApplicationDocumentList; }
				set { this._tblJobApplicationDocumentList.Assign(value); }
			}
			
			/// <summary>
			/// Association [PK][One]tblJobApplication.JobApplicationID --- [FK][Many]tblJobApplicationImage.JobApplicationID
			/// </summary>
			[AssociationAttribute(Name="FK_AppJobApplicationImage_AppJobApplication", Storage="_tblJobApplicationImageList", ThisKey="JobApplicationID", OtherKey="JobApplicationID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<tblJobApplicationImage> tblJobApplicationImageList
			{
				get { return this._tblJobApplicationImageList; }
				set { this._tblJobApplicationImageList.Assign(value); }
			}
			
			/// <summary>
			/// Association [PK][One]tblJobApplication.JobApplicationID --- [FK][Many]tblJobApplicationSchedule.JobApplicationID
			/// </summary>
			[AssociationAttribute(Name="FK_AppJobApplicationScheduleLog_AppJobApplication", Storage="_tblJobApplicationScheduleList", ThisKey="JobApplicationID", OtherKey="JobApplicationID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<tblJobApplicationSchedule> tblJobApplicationScheduleList
			{
				get { return this._tblJobApplicationScheduleList; }
				set { this._tblJobApplicationScheduleList.Assign(value); }
			}
			
			/// <summary>
			/// Association [PK][One]tblJobApplication.JobApplicationID --- [FK][Many]tblAppSchedule.JobApplicationID
			/// </summary>
			[AssociationAttribute(Name="FK_AppJobSchedule_AppJobApplication", Storage="_tblAppScheduleList", ThisKey="JobApplicationID", OtherKey="JobApplicationID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<tblAppSchedule> tblAppScheduleList
			{
				get { return this._tblAppScheduleList; }
				set { this._tblAppScheduleList.Assign(value); }
			}
			
			/// <summary>
			/// Association [FK][Many]tblJobApplication.JobApplicationStatusID --- [PK][One]tblJobApplicationStatus.JobApplicationStatusID
			/// </summary>
			[AssociationAttribute(Name="FK_JobApplication_JobApplicationStatus", Storage="_tblJobApplicationStatus", ThisKey="JobApplicationStatusID", OtherKey="JobApplicationStatusID", IsUnique=false, IsForeignKey=true)]
			public tblJobApplicationStatus tblJobApplicationStatus
			{
				get
				{
					return this._tblJobApplicationStatus.Entity;
				}
				set
				{
					tblJobApplicationStatus previousValue = this._tblJobApplicationStatus.Entity;
					if ((previousValue != value) || (this._tblJobApplicationStatus.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._tblJobApplicationStatus.Entity = null;
							previousValue.tblJobApplicationList.Remove(this);
						}
						this._tblJobApplicationStatus.Entity = value;
						if (value != null)
						{
							value.tblJobApplicationList.Add(this);
							this._JobApplicationStatusID = value.JobApplicationStatusID;
						}
						else
						{
							this._JobApplicationStatusID = default(int?);
						}
						this.SendPropertyChanged("tblJobApplicationStatus");
					}
					this.SendPropertySetterInvoked("tblJobApplicationStatus", value);
				}
			}
			
			/// <summary>
			/// Association [PK][One]tblJobApplication.JobApplicationID --- [FK][Many]tblJobApplicationNote.JobApplicationID
			/// </summary>
			[AssociationAttribute(Name="FK_tblJobApplicationLog_tblJobApplication", Storage="_tblJobApplicationNoteList", ThisKey="JobApplicationID", OtherKey="JobApplicationID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<tblJobApplicationNote> tblJobApplicationNoteList
			{
				get { return this._tblJobApplicationNoteList; }
				set { this._tblJobApplicationNoteList.Assign(value); }
			}
			
			/// <summary>
			/// Association [PK][One]tblJobApplication.JobApplicationID --- [FK][Many]tblSmsOutbox.JobApplicationID
			/// </summary>
			[AssociationAttribute(Name="FK_tblJobSms_tblJobApplication", Storage="_tblSmsOutboxList", ThisKey="JobApplicationID", OtherKey="JobApplicationID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<tblSmsOutbox> tblSmsOutboxList
			{
				get { return this._tblSmsOutboxList; }
				set { this._tblSmsOutboxList.Assign(value); }
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
		#endregion dbo.tblJobApplication

		#region dbo.tblJobApplicationDocument
		[TableAttribute(Name="dbo.tblJobApplicationDocument")]
		public partial class tblJobApplicationDocument : EntityBase<tblJobApplicationDocument, dbArizonaAppDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private int _JobApplicationDocumentID;
			private int _JobApplicationID;
			private DateTime _InsertionDate;
			private string _FileName;
			private string _FileExtension;
			private byte[] _FileData;
			private string _MimeType;
			private EntityRef<tblJobApplication> _tblJobApplication;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnJobApplicationDocumentIDChanging(int value);
			partial void OnJobApplicationDocumentIDChanged();
			partial void OnJobApplicationIDChanging(int value);
			partial void OnJobApplicationIDChanged();
			partial void OnInsertionDateChanging(DateTime value);
			partial void OnInsertionDateChanged();
			partial void OnFileNameChanging(string value);
			partial void OnFileNameChanged();
			partial void OnFileExtensionChanging(string value);
			partial void OnFileExtensionChanged();
			partial void OnFileDataChanging(byte[] value);
			partial void OnFileDataChanged();
			partial void OnMimeTypeChanging(string value);
			partial void OnMimeTypeChanged();
			#endregion

			public tblJobApplicationDocument()
			{
				_tblJobApplication = default(EntityRef<tblJobApplication>);
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=Int NOT NULL IDENTITY
			/// </summary>
			[ColumnAttribute(Storage="_JobApplicationDocumentID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", CanBeNull=false, IsPrimaryKey=true, IsDbGenerated=true)]
			public int JobApplicationDocumentID
			{
				get
				{
					return this._JobApplicationDocumentID;
				}
				set
				{
					if (this._JobApplicationDocumentID != value)
					{
						this.OnJobApplicationDocumentIDChanging(value);
						this.SendPropertyChanging();
						this._JobApplicationDocumentID = value;
						this.SendPropertyChanged("JobApplicationDocumentID");
						this.OnJobApplicationDocumentIDChanged();
					}
					this.SendPropertySetterInvoked("JobApplicationDocumentID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_JobApplicationID", DbType="Int NOT NULL", CanBeNull=false)]
			public int JobApplicationID
			{
				get
				{
					return this._JobApplicationID;
				}
				set
				{
					if (this._JobApplicationID != value)
					{
						this.OnJobApplicationIDChanging(value);
						this.SendPropertyChanging();
						this._JobApplicationID = value;
						this.SendPropertyChanged("JobApplicationID");
						this.OnJobApplicationIDChanged();
					}
					this.SendPropertySetterInvoked("JobApplicationID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_InsertionDate", DbType="DateTime NOT NULL", CanBeNull=false)]
			public DateTime InsertionDate
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
			/// Column DbType=VarChar(20)
			/// </summary>
			[ColumnAttribute(Storage="_FileExtension", DbType="VarChar(20)", CanBeNull=true)]
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
			/// Column DbType=VarBinary(MAX)
			/// </summary>
			[ColumnAttribute(Storage="_FileData", DbType="VarBinary(MAX)", CanBeNull=true)]
			public byte[] FileData
			{
				get
				{
					return this._FileData;
				}
				set
				{
					if (this._FileData != value)
					{
						this.OnFileDataChanging(value);
						this.SendPropertyChanging();
						this._FileData = value;
						this.SendPropertyChanged("FileData");
						this.OnFileDataChanged();
					}
					this.SendPropertySetterInvoked("FileData", value);
				}
			}
			
			/// <summary>
			/// Column DbType=VarChar(50)
			/// </summary>
			[ColumnAttribute(Storage="_MimeType", DbType="VarChar(50)", CanBeNull=true)]
			public string MimeType
			{
				get
				{
					return this._MimeType;
				}
				set
				{
					if (this._MimeType != value)
					{
						this.OnMimeTypeChanging(value);
						this.SendPropertyChanging();
						this._MimeType = value;
						this.SendPropertyChanged("MimeType");
						this.OnMimeTypeChanged();
					}
					this.SendPropertySetterInvoked("MimeType", value);
				}
			}
			
			#endregion Columns

			#region Associations
			/// <summary>
			/// Association [FK][Many]tblJobApplicationDocument.JobApplicationID --- [PK][One]tblJobApplication.JobApplicationID
			/// </summary>
			[AssociationAttribute(Name="FK_AppJobApplicationDocument_AppJobApplication", Storage="_tblJobApplication", ThisKey="JobApplicationID", OtherKey="JobApplicationID", IsUnique=false, IsForeignKey=true)]
			public tblJobApplication tblJobApplication
			{
				get
				{
					return this._tblJobApplication.Entity;
				}
				set
				{
					tblJobApplication previousValue = this._tblJobApplication.Entity;
					if ((previousValue != value) || (this._tblJobApplication.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._tblJobApplication.Entity = null;
							previousValue.tblJobApplicationDocumentList.Remove(this);
						}
						this._tblJobApplication.Entity = value;
						if (value != null)
						{
							value.tblJobApplicationDocumentList.Add(this);
							this._JobApplicationID = value.JobApplicationID;
						}
						else
						{
							this._JobApplicationID = default(int);
						}
						this.SendPropertyChanged("tblJobApplication");
					}
					this.SendPropertySetterInvoked("tblJobApplication", value);
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
		#endregion dbo.tblJobApplicationDocument

		#region dbo.tblJobApplicationImage
		[TableAttribute(Name="dbo.tblJobApplicationImage")]
		public partial class tblJobApplicationImage : EntityBase<tblJobApplicationImage, dbArizonaAppDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private int _JobApplicationImageID;
			private int _JobApplicationID;
			private DateTime _InsertionDate;
			private string _FileName;
			private byte[] _ImageData;
			private string _ImageMimeType;
			private byte[] _ThumbData;
			private string _ThumbMimeType;
			private EntityRef<tblJobApplication> _tblJobApplication;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnJobApplicationImageIDChanging(int value);
			partial void OnJobApplicationImageIDChanged();
			partial void OnJobApplicationIDChanging(int value);
			partial void OnJobApplicationIDChanged();
			partial void OnInsertionDateChanging(DateTime value);
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

			public tblJobApplicationImage()
			{
				_tblJobApplication = default(EntityRef<tblJobApplication>);
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=Int NOT NULL IDENTITY
			/// </summary>
			[ColumnAttribute(Storage="_JobApplicationImageID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", CanBeNull=false, IsPrimaryKey=true, IsDbGenerated=true)]
			public int JobApplicationImageID
			{
				get
				{
					return this._JobApplicationImageID;
				}
				set
				{
					if (this._JobApplicationImageID != value)
					{
						this.OnJobApplicationImageIDChanging(value);
						this.SendPropertyChanging();
						this._JobApplicationImageID = value;
						this.SendPropertyChanged("JobApplicationImageID");
						this.OnJobApplicationImageIDChanged();
					}
					this.SendPropertySetterInvoked("JobApplicationImageID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_JobApplicationID", DbType="Int NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
			public int JobApplicationID
			{
				get
				{
					return this._JobApplicationID;
				}
				set
				{
					if (this._JobApplicationID != value)
					{
						this.OnJobApplicationIDChanging(value);
						this.SendPropertyChanging();
						this._JobApplicationID = value;
						this.SendPropertyChanged("JobApplicationID");
						this.OnJobApplicationIDChanged();
					}
					this.SendPropertySetterInvoked("JobApplicationID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_InsertionDate", DbType="DateTime NOT NULL", CanBeNull=false)]
			public DateTime InsertionDate
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
			/// Association [FK][Many]tblJobApplicationImage.JobApplicationID --- [PK][One]tblJobApplication.JobApplicationID
			/// </summary>
			[AssociationAttribute(Name="FK_AppJobApplicationImage_AppJobApplication", Storage="_tblJobApplication", ThisKey="JobApplicationID", OtherKey="JobApplicationID", IsUnique=false, IsForeignKey=true)]
			public tblJobApplication tblJobApplication
			{
				get
				{
					return this._tblJobApplication.Entity;
				}
				set
				{
					tblJobApplication previousValue = this._tblJobApplication.Entity;
					if ((previousValue != value) || (this._tblJobApplication.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._tblJobApplication.Entity = null;
							previousValue.tblJobApplicationImageList.Remove(this);
						}
						this._tblJobApplication.Entity = value;
						if (value != null)
						{
							value.tblJobApplicationImageList.Add(this);
							this._JobApplicationID = value.JobApplicationID;
						}
						else
						{
							this._JobApplicationID = default(int);
						}
						this.SendPropertyChanged("tblJobApplication");
					}
					this.SendPropertySetterInvoked("tblJobApplication", value);
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
		#endregion dbo.tblJobApplicationImage

		#region dbo.tblJobApplicationNote
		[TableAttribute(Name="dbo.tblJobApplicationNote")]
		public partial class tblJobApplicationNote : EntityBase<tblJobApplicationNote, dbArizonaAppDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private int _JobApplicationNoteID;
			private long _AppMemberID;
			private int _JobApplicationID;
			private DateTime _InsertionDate;
			private string _TextContent;
			private EntityRef<tblAppMember> _tblAppMember;
			private EntityRef<tblJobApplication> _tblJobApplication;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnJobApplicationNoteIDChanging(int value);
			partial void OnJobApplicationNoteIDChanged();
			partial void OnAppMemberIDChanging(long value);
			partial void OnAppMemberIDChanged();
			partial void OnJobApplicationIDChanging(int value);
			partial void OnJobApplicationIDChanged();
			partial void OnInsertionDateChanging(DateTime value);
			partial void OnInsertionDateChanged();
			partial void OnTextContentChanging(string value);
			partial void OnTextContentChanged();
			#endregion

			public tblJobApplicationNote()
			{
				_tblAppMember = default(EntityRef<tblAppMember>);
				_tblJobApplication = default(EntityRef<tblJobApplication>);
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=Int NOT NULL IDENTITY
			/// </summary>
			[ColumnAttribute(Storage="_JobApplicationNoteID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", CanBeNull=false, IsPrimaryKey=true, IsDbGenerated=true)]
			public int JobApplicationNoteID
			{
				get
				{
					return this._JobApplicationNoteID;
				}
				set
				{
					if (this._JobApplicationNoteID != value)
					{
						this.OnJobApplicationNoteIDChanging(value);
						this.SendPropertyChanging();
						this._JobApplicationNoteID = value;
						this.SendPropertyChanged("JobApplicationNoteID");
						this.OnJobApplicationNoteIDChanged();
					}
					this.SendPropertySetterInvoked("JobApplicationNoteID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=BigInt NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_AppMemberID", DbType="BigInt NOT NULL", CanBeNull=false)]
			public long AppMemberID
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
			[ColumnAttribute(Storage="_JobApplicationID", DbType="Int NOT NULL", CanBeNull=false)]
			public int JobApplicationID
			{
				get
				{
					return this._JobApplicationID;
				}
				set
				{
					if (this._JobApplicationID != value)
					{
						this.OnJobApplicationIDChanging(value);
						this.SendPropertyChanging();
						this._JobApplicationID = value;
						this.SendPropertyChanged("JobApplicationID");
						this.OnJobApplicationIDChanged();
					}
					this.SendPropertySetterInvoked("JobApplicationID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_InsertionDate", DbType="DateTime NOT NULL", CanBeNull=false)]
			public DateTime InsertionDate
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
			/// Column DbType=NVarChar(MAX)
			/// </summary>
			[ColumnAttribute(Storage="_TextContent", DbType="NVarChar(MAX)", CanBeNull=true)]
			public string TextContent
			{
				get
				{
					return this._TextContent;
				}
				set
				{
					if (this._TextContent != value)
					{
						this.OnTextContentChanging(value);
						this.SendPropertyChanging();
						this._TextContent = value;
						this.SendPropertyChanged("TextContent");
						this.OnTextContentChanged();
					}
					this.SendPropertySetterInvoked("TextContent", value);
				}
			}
			
			#endregion Columns

			#region Associations
			/// <summary>
			/// Association [FK][Many]tblJobApplicationNote.AppMemberID --- [PK][One]tblAppMember.AppMemberID
			/// </summary>
			[AssociationAttribute(Name="FK_tblJobApplicationLog_tblAppMember", Storage="_tblAppMember", ThisKey="AppMemberID", OtherKey="AppMemberID", IsUnique=false, IsForeignKey=true)]
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
							previousValue.tblJobApplicationNoteList.Remove(this);
						}
						this._tblAppMember.Entity = value;
						if (value != null)
						{
							value.tblJobApplicationNoteList.Add(this);
							this._AppMemberID = value.AppMemberID;
						}
						else
						{
							this._AppMemberID = default(long);
						}
						this.SendPropertyChanged("tblAppMember");
					}
					this.SendPropertySetterInvoked("tblAppMember", value);
				}
			}
			
			/// <summary>
			/// Association [FK][Many]tblJobApplicationNote.JobApplicationID --- [PK][One]tblJobApplication.JobApplicationID
			/// </summary>
			[AssociationAttribute(Name="FK_tblJobApplicationLog_tblJobApplication", Storage="_tblJobApplication", ThisKey="JobApplicationID", OtherKey="JobApplicationID", IsUnique=false, IsForeignKey=true)]
			public tblJobApplication tblJobApplication
			{
				get
				{
					return this._tblJobApplication.Entity;
				}
				set
				{
					tblJobApplication previousValue = this._tblJobApplication.Entity;
					if ((previousValue != value) || (this._tblJobApplication.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._tblJobApplication.Entity = null;
							previousValue.tblJobApplicationNoteList.Remove(this);
						}
						this._tblJobApplication.Entity = value;
						if (value != null)
						{
							value.tblJobApplicationNoteList.Add(this);
							this._JobApplicationID = value.JobApplicationID;
						}
						else
						{
							this._JobApplicationID = default(int);
						}
						this.SendPropertyChanged("tblJobApplication");
					}
					this.SendPropertySetterInvoked("tblJobApplication", value);
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
		#endregion dbo.tblJobApplicationNote

		#region dbo.tblJobApplicationSchedule
		[TableAttribute(Name="dbo.tblJobApplicationSchedule")]
		public partial class tblJobApplicationSchedule : EntityBase<tblJobApplicationSchedule, dbArizonaAppDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private int _JobApplicationScheduleID;
			private int _JobApplicationID;
			private int? _AppScheduleID;
			private DateTime _StartDate;
			private DateTime _InsertionDate;
			private DateTime? _CanceledDate;
			private EntityRef<tblJobApplication> _tblJobApplication;
			private EntityRef<tblAppSchedule> _tblAppSchedule;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnJobApplicationScheduleIDChanging(int value);
			partial void OnJobApplicationScheduleIDChanged();
			partial void OnJobApplicationIDChanging(int value);
			partial void OnJobApplicationIDChanged();
			partial void OnAppScheduleIDChanging(int? value);
			partial void OnAppScheduleIDChanged();
			partial void OnStartDateChanging(DateTime value);
			partial void OnStartDateChanged();
			partial void OnInsertionDateChanging(DateTime value);
			partial void OnInsertionDateChanged();
			partial void OnCanceledDateChanging(DateTime? value);
			partial void OnCanceledDateChanged();
			#endregion

			public tblJobApplicationSchedule()
			{
				_tblJobApplication = default(EntityRef<tblJobApplication>);
				_tblAppSchedule = default(EntityRef<tblAppSchedule>);
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=Int NOT NULL IDENTITY
			/// </summary>
			[ColumnAttribute(Storage="_JobApplicationScheduleID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", CanBeNull=false, IsPrimaryKey=true, IsDbGenerated=true)]
			public int JobApplicationScheduleID
			{
				get
				{
					return this._JobApplicationScheduleID;
				}
				set
				{
					if (this._JobApplicationScheduleID != value)
					{
						this.OnJobApplicationScheduleIDChanging(value);
						this.SendPropertyChanging();
						this._JobApplicationScheduleID = value;
						this.SendPropertyChanged("JobApplicationScheduleID");
						this.OnJobApplicationScheduleIDChanged();
					}
					this.SendPropertySetterInvoked("JobApplicationScheduleID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_JobApplicationID", DbType="Int NOT NULL", CanBeNull=false)]
			public int JobApplicationID
			{
				get
				{
					return this._JobApplicationID;
				}
				set
				{
					if (this._JobApplicationID != value)
					{
						this.OnJobApplicationIDChanging(value);
						this.SendPropertyChanging();
						this._JobApplicationID = value;
						this.SendPropertyChanged("JobApplicationID");
						this.OnJobApplicationIDChanged();
					}
					this.SendPropertySetterInvoked("JobApplicationID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int
			/// </summary>
			[ColumnAttribute(Storage="_AppScheduleID", DbType="Int", CanBeNull=true)]
			public int? AppScheduleID
			{
				get
				{
					return this._AppScheduleID;
				}
				set
				{
					if (this._AppScheduleID != value)
					{
						this.OnAppScheduleIDChanging(value);
						this.SendPropertyChanging();
						this._AppScheduleID = value;
						this.SendPropertyChanged("AppScheduleID");
						this.OnAppScheduleIDChanged();
					}
					this.SendPropertySetterInvoked("AppScheduleID", value);
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
			[ColumnAttribute(Storage="_InsertionDate", DbType="DateTime NOT NULL", CanBeNull=false)]
			public DateTime InsertionDate
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
			/// Column DbType=DateTime
			/// </summary>
			[ColumnAttribute(Storage="_CanceledDate", DbType="DateTime", CanBeNull=true)]
			public DateTime? CanceledDate
			{
				get
				{
					return this._CanceledDate;
				}
				set
				{
					if (this._CanceledDate != value)
					{
						this.OnCanceledDateChanging(value);
						this.SendPropertyChanging();
						this._CanceledDate = value;
						this.SendPropertyChanged("CanceledDate");
						this.OnCanceledDateChanged();
					}
					this.SendPropertySetterInvoked("CanceledDate", value);
				}
			}
			
			#endregion Columns

			#region Associations
			/// <summary>
			/// Association [FK][Many]tblJobApplicationSchedule.JobApplicationID --- [PK][One]tblJobApplication.JobApplicationID
			/// </summary>
			[AssociationAttribute(Name="FK_AppJobApplicationScheduleLog_AppJobApplication", Storage="_tblJobApplication", ThisKey="JobApplicationID", OtherKey="JobApplicationID", IsUnique=false, IsForeignKey=true)]
			public tblJobApplication tblJobApplication
			{
				get
				{
					return this._tblJobApplication.Entity;
				}
				set
				{
					tblJobApplication previousValue = this._tblJobApplication.Entity;
					if ((previousValue != value) || (this._tblJobApplication.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._tblJobApplication.Entity = null;
							previousValue.tblJobApplicationScheduleList.Remove(this);
						}
						this._tblJobApplication.Entity = value;
						if (value != null)
						{
							value.tblJobApplicationScheduleList.Add(this);
							this._JobApplicationID = value.JobApplicationID;
						}
						else
						{
							this._JobApplicationID = default(int);
						}
						this.SendPropertyChanged("tblJobApplication");
					}
					this.SendPropertySetterInvoked("tblJobApplication", value);
				}
			}
			
			/// <summary>
			/// Association [FK][Many]tblJobApplicationSchedule.AppScheduleID --- [PK][One]tblAppSchedule.AppScheduleID
			/// </summary>
			[AssociationAttribute(Name="FK_tblJobApplicationSchedule_tblAppSchedule", Storage="_tblAppSchedule", ThisKey="AppScheduleID", OtherKey="AppScheduleID", IsUnique=false, IsForeignKey=true)]
			public tblAppSchedule tblAppSchedule
			{
				get
				{
					return this._tblAppSchedule.Entity;
				}
				set
				{
					tblAppSchedule previousValue = this._tblAppSchedule.Entity;
					if ((previousValue != value) || (this._tblAppSchedule.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._tblAppSchedule.Entity = null;
							previousValue.tblJobApplicationScheduleList.Remove(this);
						}
						this._tblAppSchedule.Entity = value;
						if (value != null)
						{
							value.tblJobApplicationScheduleList.Add(this);
							this._AppScheduleID = value.AppScheduleID;
						}
						else
						{
							this._AppScheduleID = default(int?);
						}
						this.SendPropertyChanged("tblAppSchedule");
					}
					this.SendPropertySetterInvoked("tblAppSchedule", value);
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
		#endregion dbo.tblJobApplicationSchedule

		#region dbo.tblJobApplicationStatus
		[TableAttribute(Name="dbo.tblJobApplicationStatus")]
		public partial class tblJobApplicationStatus : EntityBase<tblJobApplicationStatus, dbArizonaAppDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private int _JobApplicationStatusID;
			private int _JobAdvertID;
			private string _Name;
			private string _Description;
			private bool _IsNewApplication;
			private EntitySet<tblJobApplication> _tblJobApplicationList;
			private EntityRef<tblJobAdvert> _tblJobAdvert;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnJobApplicationStatusIDChanging(int value);
			partial void OnJobApplicationStatusIDChanged();
			partial void OnJobAdvertIDChanging(int value);
			partial void OnJobAdvertIDChanged();
			partial void OnNameChanging(string value);
			partial void OnNameChanged();
			partial void OnDescriptionChanging(string value);
			partial void OnDescriptionChanged();
			partial void OnIsNewApplicationChanging(bool value);
			partial void OnIsNewApplicationChanged();
			#endregion

			public tblJobApplicationStatus()
			{
				_tblJobApplicationList = new EntitySet<tblJobApplication>(
					new Action<tblJobApplication>(item=>{this.SendPropertyChanging(); item.tblJobApplicationStatus=this;}), 
					new Action<tblJobApplication>(item=>{this.SendPropertyChanging(); item.tblJobApplicationStatus=null;}));
				_tblJobAdvert = default(EntityRef<tblJobAdvert>);
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=Int NOT NULL IDENTITY
			/// </summary>
			[ColumnAttribute(Storage="_JobApplicationStatusID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", CanBeNull=false, IsPrimaryKey=true, IsDbGenerated=true)]
			public int JobApplicationStatusID
			{
				get
				{
					return this._JobApplicationStatusID;
				}
				set
				{
					if (this._JobApplicationStatusID != value)
					{
						this.OnJobApplicationStatusIDChanging(value);
						this.SendPropertyChanging();
						this._JobApplicationStatusID = value;
						this.SendPropertyChanged("JobApplicationStatusID");
						this.OnJobApplicationStatusIDChanged();
					}
					this.SendPropertySetterInvoked("JobApplicationStatusID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_JobAdvertID", DbType="Int NOT NULL", CanBeNull=false)]
			public int JobAdvertID
			{
				get
				{
					return this._JobAdvertID;
				}
				set
				{
					if (this._JobAdvertID != value)
					{
						this.OnJobAdvertIDChanging(value);
						this.SendPropertyChanging();
						this._JobAdvertID = value;
						this.SendPropertyChanged("JobAdvertID");
						this.OnJobAdvertIDChanged();
					}
					this.SendPropertySetterInvoked("JobAdvertID", value);
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
			/// Column DbType=Bit NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_IsNewApplication", DbType="Bit NOT NULL", CanBeNull=false)]
			public bool IsNewApplication
			{
				get
				{
					return this._IsNewApplication;
				}
				set
				{
					if (this._IsNewApplication != value)
					{
						this.OnIsNewApplicationChanging(value);
						this.SendPropertyChanging();
						this._IsNewApplication = value;
						this.SendPropertyChanged("IsNewApplication");
						this.OnIsNewApplicationChanged();
					}
					this.SendPropertySetterInvoked("IsNewApplication", value);
				}
			}
			
			#endregion Columns

			#region Associations
			/// <summary>
			/// Association [PK][One]tblJobApplicationStatus.JobApplicationStatusID --- [FK][Many]tblJobApplication.JobApplicationStatusID
			/// </summary>
			[AssociationAttribute(Name="FK_JobApplication_JobApplicationStatus", Storage="_tblJobApplicationList", ThisKey="JobApplicationStatusID", OtherKey="JobApplicationStatusID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<tblJobApplication> tblJobApplicationList
			{
				get { return this._tblJobApplicationList; }
				set { this._tblJobApplicationList.Assign(value); }
			}
			
			/// <summary>
			/// Association [FK][Many]tblJobApplicationStatus.JobAdvertID --- [PK][One]tblJobAdvert.JobAdvertID
			/// </summary>
			[AssociationAttribute(Name="FK_JobApplicationStatus_JobAdvert", Storage="_tblJobAdvert", ThisKey="JobAdvertID", OtherKey="JobAdvertID", IsUnique=false, IsForeignKey=true)]
			public tblJobAdvert tblJobAdvert
			{
				get
				{
					return this._tblJobAdvert.Entity;
				}
				set
				{
					tblJobAdvert previousValue = this._tblJobAdvert.Entity;
					if ((previousValue != value) || (this._tblJobAdvert.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._tblJobAdvert.Entity = null;
							previousValue.tblJobApplicationStatusList.Remove(this);
						}
						this._tblJobAdvert.Entity = value;
						if (value != null)
						{
							value.tblJobApplicationStatusList.Add(this);
							this._JobAdvertID = value.JobAdvertID;
						}
						else
						{
							this._JobAdvertID = default(int);
						}
						this.SendPropertyChanged("tblJobAdvert");
					}
					this.SendPropertySetterInvoked("tblJobAdvert", value);
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
		#endregion dbo.tblJobApplicationStatus

		#region dbo.tblJobTemplate
		[TableAttribute(Name="dbo.tblJobTemplate")]
		public partial class tblJobTemplate : EntityBase<tblJobTemplate, dbArizonaAppDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private int _JobTemplateID;
			private int _BillFirmaID;
			private int? _JobTemplateKindID;
			private string _TemplateSubject;
			private string _TemplateContent;
			private bool? _IsActive;
			private EntityRef<tblBillFirma> _tblBillFirma;
			private EntityRef<tblJobTemplateKind> _tblJobTemplateKind;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnJobTemplateIDChanging(int value);
			partial void OnJobTemplateIDChanged();
			partial void OnBillFirmaIDChanging(int value);
			partial void OnBillFirmaIDChanged();
			partial void OnJobTemplateKindIDChanging(int? value);
			partial void OnJobTemplateKindIDChanged();
			partial void OnTemplateSubjectChanging(string value);
			partial void OnTemplateSubjectChanged();
			partial void OnTemplateContentChanging(string value);
			partial void OnTemplateContentChanged();
			partial void OnIsActiveChanging(bool? value);
			partial void OnIsActiveChanged();
			#endregion

			public tblJobTemplate()
			{
				_tblBillFirma = default(EntityRef<tblBillFirma>);
				_tblJobTemplateKind = default(EntityRef<tblJobTemplateKind>);
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=Int NOT NULL IDENTITY
			/// </summary>
			[ColumnAttribute(Storage="_JobTemplateID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", CanBeNull=false, IsPrimaryKey=true, IsDbGenerated=true)]
			public int JobTemplateID
			{
				get
				{
					return this._JobTemplateID;
				}
				set
				{
					if (this._JobTemplateID != value)
					{
						this.OnJobTemplateIDChanging(value);
						this.SendPropertyChanging();
						this._JobTemplateID = value;
						this.SendPropertyChanged("JobTemplateID");
						this.OnJobTemplateIDChanged();
					}
					this.SendPropertySetterInvoked("JobTemplateID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_BillFirmaID", DbType="Int NOT NULL", CanBeNull=false)]
			public int BillFirmaID
			{
				get
				{
					return this._BillFirmaID;
				}
				set
				{
					if (this._BillFirmaID != value)
					{
						this.OnBillFirmaIDChanging(value);
						this.SendPropertyChanging();
						this._BillFirmaID = value;
						this.SendPropertyChanged("BillFirmaID");
						this.OnBillFirmaIDChanged();
					}
					this.SendPropertySetterInvoked("BillFirmaID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int
			/// </summary>
			[ColumnAttribute(Storage="_JobTemplateKindID", DbType="Int", CanBeNull=true)]
			public int? JobTemplateKindID
			{
				get
				{
					return this._JobTemplateKindID;
				}
				set
				{
					if (this._JobTemplateKindID != value)
					{
						this.OnJobTemplateKindIDChanging(value);
						this.SendPropertyChanging();
						this._JobTemplateKindID = value;
						this.SendPropertyChanged("JobTemplateKindID");
						this.OnJobTemplateKindIDChanged();
					}
					this.SendPropertySetterInvoked("JobTemplateKindID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(500)
			/// </summary>
			[ColumnAttribute(Storage="_TemplateSubject", DbType="NVarChar(500)", CanBeNull=true)]
			public string TemplateSubject
			{
				get
				{
					return this._TemplateSubject;
				}
				set
				{
					if (this._TemplateSubject != value)
					{
						this.OnTemplateSubjectChanging(value);
						this.SendPropertyChanging();
						this._TemplateSubject = value;
						this.SendPropertyChanged("TemplateSubject");
						this.OnTemplateSubjectChanged();
					}
					this.SendPropertySetterInvoked("TemplateSubject", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(MAX)
			/// </summary>
			[ColumnAttribute(Storage="_TemplateContent", DbType="NVarChar(MAX)", CanBeNull=true)]
			public string TemplateContent
			{
				get
				{
					return this._TemplateContent;
				}
				set
				{
					if (this._TemplateContent != value)
					{
						this.OnTemplateContentChanging(value);
						this.SendPropertyChanging();
						this._TemplateContent = value;
						this.SendPropertyChanged("TemplateContent");
						this.OnTemplateContentChanged();
					}
					this.SendPropertySetterInvoked("TemplateContent", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Bit
			/// </summary>
			[ColumnAttribute(Storage="_IsActive", DbType="Bit", CanBeNull=true)]
			public bool? IsActive
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
			
			#endregion Columns

			#region Associations
			/// <summary>
			/// Association [FK][Many]tblJobTemplate.BillFirmaID --- [PK][One]tblBillFirma.BillFirmaID
			/// </summary>
			[AssociationAttribute(Name="FK_tblJobTemplate_tblBillFirma", Storage="_tblBillFirma", ThisKey="BillFirmaID", OtherKey="BillFirmaID", IsUnique=false, IsForeignKey=true)]
			public tblBillFirma tblBillFirma
			{
				get
				{
					return this._tblBillFirma.Entity;
				}
				set
				{
					tblBillFirma previousValue = this._tblBillFirma.Entity;
					if ((previousValue != value) || (this._tblBillFirma.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._tblBillFirma.Entity = null;
							previousValue.tblJobTemplateList.Remove(this);
						}
						this._tblBillFirma.Entity = value;
						if (value != null)
						{
							value.tblJobTemplateList.Add(this);
							this._BillFirmaID = value.BillFirmaID;
						}
						else
						{
							this._BillFirmaID = default(int);
						}
						this.SendPropertyChanged("tblBillFirma");
					}
					this.SendPropertySetterInvoked("tblBillFirma", value);
				}
			}
			
			/// <summary>
			/// Association [FK][Many]tblJobTemplate.JobTemplateKindID --- [PK][One]tblJobTemplateKind.JobTemplateKindID
			/// </summary>
			[AssociationAttribute(Name="FK_tblJobTemplate_tblJobTemplateKind", Storage="_tblJobTemplateKind", ThisKey="JobTemplateKindID", OtherKey="JobTemplateKindID", IsUnique=false, IsForeignKey=true)]
			public tblJobTemplateKind tblJobTemplateKind
			{
				get
				{
					return this._tblJobTemplateKind.Entity;
				}
				set
				{
					tblJobTemplateKind previousValue = this._tblJobTemplateKind.Entity;
					if ((previousValue != value) || (this._tblJobTemplateKind.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._tblJobTemplateKind.Entity = null;
							previousValue.tblJobTemplateList.Remove(this);
						}
						this._tblJobTemplateKind.Entity = value;
						if (value != null)
						{
							value.tblJobTemplateList.Add(this);
							this._JobTemplateKindID = value.JobTemplateKindID;
						}
						else
						{
							this._JobTemplateKindID = default(int?);
						}
						this.SendPropertyChanged("tblJobTemplateKind");
					}
					this.SendPropertySetterInvoked("tblJobTemplateKind", value);
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
		#endregion dbo.tblJobTemplate

		#region dbo.tblJobTemplateKind
		[TableAttribute(Name="dbo.tblJobTemplateKind")]
		public partial class tblJobTemplateKind : EntityBase<tblJobTemplateKind, dbArizonaAppDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private int _JobTemplateKindID;
			private string _Name;
			private string _IconCssClass;
			private int _EditorHeight;
			private EntitySet<tblJobTemplate> _tblJobTemplateList;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnJobTemplateKindIDChanging(int value);
			partial void OnJobTemplateKindIDChanged();
			partial void OnNameChanging(string value);
			partial void OnNameChanged();
			partial void OnIconCssClassChanging(string value);
			partial void OnIconCssClassChanged();
			partial void OnEditorHeightChanging(int value);
			partial void OnEditorHeightChanged();
			#endregion

			public tblJobTemplateKind()
			{
				_tblJobTemplateList = new EntitySet<tblJobTemplate>(
					new Action<tblJobTemplate>(item=>{this.SendPropertyChanging(); item.tblJobTemplateKind=this;}), 
					new Action<tblJobTemplate>(item=>{this.SendPropertyChanging(); item.tblJobTemplateKind=null;}));
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_JobTemplateKindID", DbType="Int NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
			public int JobTemplateKindID
			{
				get
				{
					return this._JobTemplateKindID;
				}
				set
				{
					if (this._JobTemplateKindID != value)
					{
						this.OnJobTemplateKindIDChanging(value);
						this.SendPropertyChanging();
						this._JobTemplateKindID = value;
						this.SendPropertyChanged("JobTemplateKindID");
						this.OnJobTemplateKindIDChanged();
					}
					this.SendPropertySetterInvoked("JobTemplateKindID", value);
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
			/// Column DbType=VarChar(50) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_IconCssClass", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
			public string IconCssClass
			{
				get
				{
					return this._IconCssClass;
				}
				set
				{
					if (this._IconCssClass != value)
					{
						this.OnIconCssClassChanging(value);
						this.SendPropertyChanging();
						this._IconCssClass = value;
						this.SendPropertyChanged("IconCssClass");
						this.OnIconCssClassChanged();
					}
					this.SendPropertySetterInvoked("IconCssClass", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_EditorHeight", DbType="Int NOT NULL", CanBeNull=false)]
			public int EditorHeight
			{
				get
				{
					return this._EditorHeight;
				}
				set
				{
					if (this._EditorHeight != value)
					{
						this.OnEditorHeightChanging(value);
						this.SendPropertyChanging();
						this._EditorHeight = value;
						this.SendPropertyChanged("EditorHeight");
						this.OnEditorHeightChanged();
					}
					this.SendPropertySetterInvoked("EditorHeight", value);
				}
			}
			
			#endregion Columns

			#region Associations
			/// <summary>
			/// Association [PK][One]tblJobTemplateKind.JobTemplateKindID --- [FK][Many]tblJobTemplate.JobTemplateKindID
			/// </summary>
			[AssociationAttribute(Name="FK_tblJobTemplate_tblJobTemplateKind", Storage="_tblJobTemplateList", ThisKey="JobTemplateKindID", OtherKey="JobTemplateKindID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<tblJobTemplate> tblJobTemplateList
			{
				get { return this._tblJobTemplateList; }
				set { this._tblJobTemplateList.Assign(value); }
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
		#endregion dbo.tblJobTemplateKind

		#region dbo.tblPorezPdv
		[TableAttribute(Name="dbo.tblPorezPdv")]
		public partial class tblPorezPdv : EntityBase<tblPorezPdv, dbArizonaAppDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private int _BillPorezPdvID;
			private bool _IsActive;
			private int _Ordinal;
			private bool _IsDefault;
			private string _Naziv;
			private string _PrintableText;
			private string _Opis;
			private EntitySet<tblPorezPdvPostotak> _tblPorezPdvPostotakList;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnBillPorezPdvIDChanging(int value);
			partial void OnBillPorezPdvIDChanged();
			partial void OnIsActiveChanging(bool value);
			partial void OnIsActiveChanged();
			partial void OnOrdinalChanging(int value);
			partial void OnOrdinalChanged();
			partial void OnIsDefaultChanging(bool value);
			partial void OnIsDefaultChanged();
			partial void OnNazivChanging(string value);
			partial void OnNazivChanged();
			partial void OnPrintableTextChanging(string value);
			partial void OnPrintableTextChanged();
			partial void OnOpisChanging(string value);
			partial void OnOpisChanged();
			#endregion

			public tblPorezPdv()
			{
				_tblPorezPdvPostotakList = new EntitySet<tblPorezPdvPostotak>(
					new Action<tblPorezPdvPostotak>(item=>{this.SendPropertyChanging(); item.tblPorezPdv=this;}), 
					new Action<tblPorezPdvPostotak>(item=>{this.SendPropertyChanging(); item.tblPorezPdv=null;}));
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_BillPorezPdvID", DbType="Int NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
			public int BillPorezPdvID
			{
				get
				{
					return this._BillPorezPdvID;
				}
				set
				{
					if (this._BillPorezPdvID != value)
					{
						this.OnBillPorezPdvIDChanging(value);
						this.SendPropertyChanging();
						this._BillPorezPdvID = value;
						this.SendPropertyChanged("BillPorezPdvID");
						this.OnBillPorezPdvIDChanged();
					}
					this.SendPropertySetterInvoked("BillPorezPdvID", value);
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
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_Ordinal", DbType="Int NOT NULL", CanBeNull=false)]
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
						this.OnOrdinalChanging(value);
						this.SendPropertyChanging();
						this._Ordinal = value;
						this.SendPropertyChanged("Ordinal");
						this.OnOrdinalChanged();
					}
					this.SendPropertySetterInvoked("Ordinal", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Bit NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_IsDefault", DbType="Bit NOT NULL", CanBeNull=false)]
			public bool IsDefault
			{
				get
				{
					return this._IsDefault;
				}
				set
				{
					if (this._IsDefault != value)
					{
						this.OnIsDefaultChanging(value);
						this.SendPropertyChanging();
						this._IsDefault = value;
						this.SendPropertyChanged("IsDefault");
						this.OnIsDefaultChanged();
					}
					this.SendPropertySetterInvoked("IsDefault", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(150) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_Naziv", DbType="NVarChar(150) NOT NULL", CanBeNull=false)]
			public string Naziv
			{
				get
				{
					return this._Naziv;
				}
				set
				{
					if (this._Naziv != value)
					{
						this.OnNazivChanging(value);
						this.SendPropertyChanging();
						this._Naziv = value;
						this.SendPropertyChanged("Naziv");
						this.OnNazivChanged();
					}
					this.SendPropertySetterInvoked("Naziv", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(250)
			/// </summary>
			[ColumnAttribute(Storage="_PrintableText", DbType="NVarChar(250)", CanBeNull=true)]
			public string PrintableText
			{
				get
				{
					return this._PrintableText;
				}
				set
				{
					if (this._PrintableText != value)
					{
						this.OnPrintableTextChanging(value);
						this.SendPropertyChanging();
						this._PrintableText = value;
						this.SendPropertyChanged("PrintableText");
						this.OnPrintableTextChanged();
					}
					this.SendPropertySetterInvoked("PrintableText", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(MAX)
			/// </summary>
			[ColumnAttribute(Storage="_Opis", DbType="NVarChar(MAX)", CanBeNull=true)]
			public string Opis
			{
				get
				{
					return this._Opis;
				}
				set
				{
					if (this._Opis != value)
					{
						this.OnOpisChanging(value);
						this.SendPropertyChanging();
						this._Opis = value;
						this.SendPropertyChanged("Opis");
						this.OnOpisChanged();
					}
					this.SendPropertySetterInvoked("Opis", value);
				}
			}
			
			#endregion Columns

			#region Associations
			/// <summary>
			/// Association [PK][One]tblPorezPdv.BillPorezPdvID --- [FK][Many]tblPorezPdvPostotak.BillPorezPdvID
			/// </summary>
			[AssociationAttribute(Name="FK_tblPorezPdvPostotak_tblPorezPdv", Storage="_tblPorezPdvPostotakList", ThisKey="BillPorezPdvID", OtherKey="BillPorezPdvID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<tblPorezPdvPostotak> tblPorezPdvPostotakList
			{
				get { return this._tblPorezPdvPostotakList; }
				set { this._tblPorezPdvPostotakList.Assign(value); }
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
		#endregion dbo.tblPorezPdv

		#region dbo.tblPorezPdvPostotak
		[TableAttribute(Name="dbo.tblPorezPdvPostotak")]
		public partial class tblPorezPdvPostotak : EntityBase<tblPorezPdvPostotak, dbArizonaAppDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private int _BillPorezPdvPostotakID;
			private int _BillPorezPdvID;
			private decimal _PdvPosto;
			private DateTime _StartDatum;
			private DateTime? _EndDatum;
			private EntityRef<tblPorezPdv> _tblPorezPdv;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnBillPorezPdvPostotakIDChanging(int value);
			partial void OnBillPorezPdvPostotakIDChanged();
			partial void OnBillPorezPdvIDChanging(int value);
			partial void OnBillPorezPdvIDChanged();
			partial void OnPdvPostoChanging(decimal value);
			partial void OnPdvPostoChanged();
			partial void OnStartDatumChanging(DateTime value);
			partial void OnStartDatumChanged();
			partial void OnEndDatumChanging(DateTime? value);
			partial void OnEndDatumChanged();
			#endregion

			public tblPorezPdvPostotak()
			{
				_tblPorezPdv = default(EntityRef<tblPorezPdv>);
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_BillPorezPdvPostotakID", DbType="Int NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
			public int BillPorezPdvPostotakID
			{
				get
				{
					return this._BillPorezPdvPostotakID;
				}
				set
				{
					if (this._BillPorezPdvPostotakID != value)
					{
						this.OnBillPorezPdvPostotakIDChanging(value);
						this.SendPropertyChanging();
						this._BillPorezPdvPostotakID = value;
						this.SendPropertyChanged("BillPorezPdvPostotakID");
						this.OnBillPorezPdvPostotakIDChanged();
					}
					this.SendPropertySetterInvoked("BillPorezPdvPostotakID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_BillPorezPdvID", DbType="Int NOT NULL", CanBeNull=false)]
			public int BillPorezPdvID
			{
				get
				{
					return this._BillPorezPdvID;
				}
				set
				{
					if (this._BillPorezPdvID != value)
					{
						this.OnBillPorezPdvIDChanging(value);
						this.SendPropertyChanging();
						this._BillPorezPdvID = value;
						this.SendPropertyChanged("BillPorezPdvID");
						this.OnBillPorezPdvIDChanged();
					}
					this.SendPropertySetterInvoked("BillPorezPdvID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Money NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_PdvPosto", DbType="Money NOT NULL", CanBeNull=false)]
			public decimal PdvPosto
			{
				get
				{
					return this._PdvPosto;
				}
				set
				{
					if (this._PdvPosto != value)
					{
						this.OnPdvPostoChanging(value);
						this.SendPropertyChanging();
						this._PdvPosto = value;
						this.SendPropertyChanged("PdvPosto");
						this.OnPdvPostoChanged();
					}
					this.SendPropertySetterInvoked("PdvPosto", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_StartDatum", DbType="DateTime NOT NULL", CanBeNull=false)]
			public DateTime StartDatum
			{
				get
				{
					return this._StartDatum;
				}
				set
				{
					if (this._StartDatum != value)
					{
						this.OnStartDatumChanging(value);
						this.SendPropertyChanging();
						this._StartDatum = value;
						this.SendPropertyChanged("StartDatum");
						this.OnStartDatumChanged();
					}
					this.SendPropertySetterInvoked("StartDatum", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime
			/// </summary>
			[ColumnAttribute(Storage="_EndDatum", DbType="DateTime", CanBeNull=true)]
			public DateTime? EndDatum
			{
				get
				{
					return this._EndDatum;
				}
				set
				{
					if (this._EndDatum != value)
					{
						this.OnEndDatumChanging(value);
						this.SendPropertyChanging();
						this._EndDatum = value;
						this.SendPropertyChanged("EndDatum");
						this.OnEndDatumChanged();
					}
					this.SendPropertySetterInvoked("EndDatum", value);
				}
			}
			
			#endregion Columns

			#region Associations
			/// <summary>
			/// Association [FK][Many]tblPorezPdvPostotak.BillPorezPdvID --- [PK][One]tblPorezPdv.BillPorezPdvID
			/// </summary>
			[AssociationAttribute(Name="FK_tblPorezPdvPostotak_tblPorezPdv", Storage="_tblPorezPdv", ThisKey="BillPorezPdvID", OtherKey="BillPorezPdvID", IsUnique=false, IsForeignKey=true)]
			public tblPorezPdv tblPorezPdv
			{
				get
				{
					return this._tblPorezPdv.Entity;
				}
				set
				{
					tblPorezPdv previousValue = this._tblPorezPdv.Entity;
					if ((previousValue != value) || (this._tblPorezPdv.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._tblPorezPdv.Entity = null;
							previousValue.tblPorezPdvPostotakList.Remove(this);
						}
						this._tblPorezPdv.Entity = value;
						if (value != null)
						{
							value.tblPorezPdvPostotakList.Add(this);
							this._BillPorezPdvID = value.BillPorezPdvID;
						}
						else
						{
							this._BillPorezPdvID = default(int);
						}
						this.SendPropertyChanged("tblPorezPdv");
					}
					this.SendPropertySetterInvoked("tblPorezPdv", value);
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
		#endregion dbo.tblPorezPdvPostotak

		#region dbo.tblPorezPotrosnja
		[TableAttribute(Name="dbo.tblPorezPotrosnja")]
		public partial class tblPorezPotrosnja : EntityBase<tblPorezPotrosnja, dbArizonaAppDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private int _BillPorezPotrosnjaID;
			private bool _IsActive;
			private int _Ordinal;
			private bool _IsDefault;
			private string _Naziv;
			private string _PrintableText;
			private string _Opis;
			private EntitySet<tblPorezPotrosnjaPostotak> _tblPorezPotrosnjaPostotakList;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnBillPorezPotrosnjaIDChanging(int value);
			partial void OnBillPorezPotrosnjaIDChanged();
			partial void OnIsActiveChanging(bool value);
			partial void OnIsActiveChanged();
			partial void OnOrdinalChanging(int value);
			partial void OnOrdinalChanged();
			partial void OnIsDefaultChanging(bool value);
			partial void OnIsDefaultChanged();
			partial void OnNazivChanging(string value);
			partial void OnNazivChanged();
			partial void OnPrintableTextChanging(string value);
			partial void OnPrintableTextChanged();
			partial void OnOpisChanging(string value);
			partial void OnOpisChanged();
			#endregion

			public tblPorezPotrosnja()
			{
				_tblPorezPotrosnjaPostotakList = new EntitySet<tblPorezPotrosnjaPostotak>(
					new Action<tblPorezPotrosnjaPostotak>(item=>{this.SendPropertyChanging(); item.tblPorezPotrosnja=this;}), 
					new Action<tblPorezPotrosnjaPostotak>(item=>{this.SendPropertyChanging(); item.tblPorezPotrosnja=null;}));
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_BillPorezPotrosnjaID", DbType="Int NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
			public int BillPorezPotrosnjaID
			{
				get
				{
					return this._BillPorezPotrosnjaID;
				}
				set
				{
					if (this._BillPorezPotrosnjaID != value)
					{
						this.OnBillPorezPotrosnjaIDChanging(value);
						this.SendPropertyChanging();
						this._BillPorezPotrosnjaID = value;
						this.SendPropertyChanged("BillPorezPotrosnjaID");
						this.OnBillPorezPotrosnjaIDChanged();
					}
					this.SendPropertySetterInvoked("BillPorezPotrosnjaID", value);
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
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_Ordinal", DbType="Int NOT NULL", CanBeNull=false)]
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
						this.OnOrdinalChanging(value);
						this.SendPropertyChanging();
						this._Ordinal = value;
						this.SendPropertyChanged("Ordinal");
						this.OnOrdinalChanged();
					}
					this.SendPropertySetterInvoked("Ordinal", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Bit NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_IsDefault", DbType="Bit NOT NULL", CanBeNull=false)]
			public bool IsDefault
			{
				get
				{
					return this._IsDefault;
				}
				set
				{
					if (this._IsDefault != value)
					{
						this.OnIsDefaultChanging(value);
						this.SendPropertyChanging();
						this._IsDefault = value;
						this.SendPropertyChanged("IsDefault");
						this.OnIsDefaultChanged();
					}
					this.SendPropertySetterInvoked("IsDefault", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(150) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_Naziv", DbType="NVarChar(150) NOT NULL", CanBeNull=false)]
			public string Naziv
			{
				get
				{
					return this._Naziv;
				}
				set
				{
					if (this._Naziv != value)
					{
						this.OnNazivChanging(value);
						this.SendPropertyChanging();
						this._Naziv = value;
						this.SendPropertyChanged("Naziv");
						this.OnNazivChanged();
					}
					this.SendPropertySetterInvoked("Naziv", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(250) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_PrintableText", DbType="NVarChar(250) NOT NULL", CanBeNull=false)]
			public string PrintableText
			{
				get
				{
					return this._PrintableText;
				}
				set
				{
					if (this._PrintableText != value)
					{
						this.OnPrintableTextChanging(value);
						this.SendPropertyChanging();
						this._PrintableText = value;
						this.SendPropertyChanged("PrintableText");
						this.OnPrintableTextChanged();
					}
					this.SendPropertySetterInvoked("PrintableText", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(MAX) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_Opis", DbType="NVarChar(MAX) NOT NULL", CanBeNull=false)]
			public string Opis
			{
				get
				{
					return this._Opis;
				}
				set
				{
					if (this._Opis != value)
					{
						this.OnOpisChanging(value);
						this.SendPropertyChanging();
						this._Opis = value;
						this.SendPropertyChanged("Opis");
						this.OnOpisChanged();
					}
					this.SendPropertySetterInvoked("Opis", value);
				}
			}
			
			#endregion Columns

			#region Associations
			/// <summary>
			/// Association [PK][One]tblPorezPotrosnja.BillPorezPotrosnjaID --- [FK][Many]tblPorezPotrosnjaPostotak.BillPorezPotrosnjaID
			/// </summary>
			[AssociationAttribute(Name="FK_tblPorezPotrosnjaPostotak_tblPorezPotrosnja", Storage="_tblPorezPotrosnjaPostotakList", ThisKey="BillPorezPotrosnjaID", OtherKey="BillPorezPotrosnjaID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<tblPorezPotrosnjaPostotak> tblPorezPotrosnjaPostotakList
			{
				get { return this._tblPorezPotrosnjaPostotakList; }
				set { this._tblPorezPotrosnjaPostotakList.Assign(value); }
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
		#endregion dbo.tblPorezPotrosnja

		#region dbo.tblPorezPotrosnjaPostotak
		[TableAttribute(Name="dbo.tblPorezPotrosnjaPostotak")]
		public partial class tblPorezPotrosnjaPostotak : EntityBase<tblPorezPotrosnjaPostotak, dbArizonaAppDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private int _BillPorezPotrosnjaPostotakID;
			private int _BillPorezPotrosnjaID;
			private decimal _PorezPosto;
			private DateTime _StartDatum;
			private DateTime? _EndDatum;
			private EntityRef<tblPorezPotrosnja> _tblPorezPotrosnja;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnBillPorezPotrosnjaPostotakIDChanging(int value);
			partial void OnBillPorezPotrosnjaPostotakIDChanged();
			partial void OnBillPorezPotrosnjaIDChanging(int value);
			partial void OnBillPorezPotrosnjaIDChanged();
			partial void OnPorezPostoChanging(decimal value);
			partial void OnPorezPostoChanged();
			partial void OnStartDatumChanging(DateTime value);
			partial void OnStartDatumChanged();
			partial void OnEndDatumChanging(DateTime? value);
			partial void OnEndDatumChanged();
			#endregion

			public tblPorezPotrosnjaPostotak()
			{
				_tblPorezPotrosnja = default(EntityRef<tblPorezPotrosnja>);
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_BillPorezPotrosnjaPostotakID", DbType="Int NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
			public int BillPorezPotrosnjaPostotakID
			{
				get
				{
					return this._BillPorezPotrosnjaPostotakID;
				}
				set
				{
					if (this._BillPorezPotrosnjaPostotakID != value)
					{
						this.OnBillPorezPotrosnjaPostotakIDChanging(value);
						this.SendPropertyChanging();
						this._BillPorezPotrosnjaPostotakID = value;
						this.SendPropertyChanged("BillPorezPotrosnjaPostotakID");
						this.OnBillPorezPotrosnjaPostotakIDChanged();
					}
					this.SendPropertySetterInvoked("BillPorezPotrosnjaPostotakID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_BillPorezPotrosnjaID", DbType="Int NOT NULL", CanBeNull=false)]
			public int BillPorezPotrosnjaID
			{
				get
				{
					return this._BillPorezPotrosnjaID;
				}
				set
				{
					if (this._BillPorezPotrosnjaID != value)
					{
						this.OnBillPorezPotrosnjaIDChanging(value);
						this.SendPropertyChanging();
						this._BillPorezPotrosnjaID = value;
						this.SendPropertyChanged("BillPorezPotrosnjaID");
						this.OnBillPorezPotrosnjaIDChanged();
					}
					this.SendPropertySetterInvoked("BillPorezPotrosnjaID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Money NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_PorezPosto", DbType="Money NOT NULL", CanBeNull=false)]
			public decimal PorezPosto
			{
				get
				{
					return this._PorezPosto;
				}
				set
				{
					if (this._PorezPosto != value)
					{
						this.OnPorezPostoChanging(value);
						this.SendPropertyChanging();
						this._PorezPosto = value;
						this.SendPropertyChanged("PorezPosto");
						this.OnPorezPostoChanged();
					}
					this.SendPropertySetterInvoked("PorezPosto", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_StartDatum", DbType="DateTime NOT NULL", CanBeNull=false)]
			public DateTime StartDatum
			{
				get
				{
					return this._StartDatum;
				}
				set
				{
					if (this._StartDatum != value)
					{
						this.OnStartDatumChanging(value);
						this.SendPropertyChanging();
						this._StartDatum = value;
						this.SendPropertyChanged("StartDatum");
						this.OnStartDatumChanged();
					}
					this.SendPropertySetterInvoked("StartDatum", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime
			/// </summary>
			[ColumnAttribute(Storage="_EndDatum", DbType="DateTime", CanBeNull=true)]
			public DateTime? EndDatum
			{
				get
				{
					return this._EndDatum;
				}
				set
				{
					if (this._EndDatum != value)
					{
						this.OnEndDatumChanging(value);
						this.SendPropertyChanging();
						this._EndDatum = value;
						this.SendPropertyChanged("EndDatum");
						this.OnEndDatumChanged();
					}
					this.SendPropertySetterInvoked("EndDatum", value);
				}
			}
			
			#endregion Columns

			#region Associations
			/// <summary>
			/// Association [FK][Many]tblPorezPotrosnjaPostotak.BillPorezPotrosnjaID --- [PK][One]tblPorezPotrosnja.BillPorezPotrosnjaID
			/// </summary>
			[AssociationAttribute(Name="FK_tblPorezPotrosnjaPostotak_tblPorezPotrosnja", Storage="_tblPorezPotrosnja", ThisKey="BillPorezPotrosnjaID", OtherKey="BillPorezPotrosnjaID", IsUnique=false, IsForeignKey=true)]
			public tblPorezPotrosnja tblPorezPotrosnja
			{
				get
				{
					return this._tblPorezPotrosnja.Entity;
				}
				set
				{
					tblPorezPotrosnja previousValue = this._tblPorezPotrosnja.Entity;
					if ((previousValue != value) || (this._tblPorezPotrosnja.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._tblPorezPotrosnja.Entity = null;
							previousValue.tblPorezPotrosnjaPostotakList.Remove(this);
						}
						this._tblPorezPotrosnja.Entity = value;
						if (value != null)
						{
							value.tblPorezPotrosnjaPostotakList.Add(this);
							this._BillPorezPotrosnjaID = value.BillPorezPotrosnjaID;
						}
						else
						{
							this._BillPorezPotrosnjaID = default(int);
						}
						this.SendPropertyChanged("tblPorezPotrosnja");
					}
					this.SendPropertySetterInvoked("tblPorezPotrosnja", value);
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
		#endregion dbo.tblPorezPotrosnjaPostotak

		#region dbo.tblPozivLog
		[TableAttribute(Name="dbo.tblPozivLog")]
		public partial class tblPozivLog : EntityBase<tblPozivLog, dbArizonaAppDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private long _PozivLogID;
			private int _BillFirmaID;
			private DateTime _InsertionDate;
			private System.Guid? _GroupName;
			private string _PreviousValue;
			private string _Kind;
			private string _ReturnValue;
			private string _Network;
			private string _FromPhone;
			private string _ToPhone;
			private string _FromIP;
			private string _QueryString;
			private EntityRef<tblBillFirma> _tblBillFirma;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnPozivLogIDChanging(long value);
			partial void OnPozivLogIDChanged();
			partial void OnBillFirmaIDChanging(int value);
			partial void OnBillFirmaIDChanged();
			partial void OnInsertionDateChanging(DateTime value);
			partial void OnInsertionDateChanged();
			partial void OnGroupNameChanging(System.Guid? value);
			partial void OnGroupNameChanged();
			partial void OnPreviousValueChanging(string value);
			partial void OnPreviousValueChanged();
			partial void OnKindChanging(string value);
			partial void OnKindChanged();
			partial void OnReturnValueChanging(string value);
			partial void OnReturnValueChanged();
			partial void OnNetworkChanging(string value);
			partial void OnNetworkChanged();
			partial void OnFromPhoneChanging(string value);
			partial void OnFromPhoneChanged();
			partial void OnToPhoneChanging(string value);
			partial void OnToPhoneChanged();
			partial void OnFromIPChanging(string value);
			partial void OnFromIPChanged();
			partial void OnQueryStringChanging(string value);
			partial void OnQueryStringChanged();
			#endregion

			public tblPozivLog()
			{
				_tblBillFirma = default(EntityRef<tblBillFirma>);
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=BigInt NOT NULL IDENTITY
			/// </summary>
			[ColumnAttribute(Storage="_PozivLogID", AutoSync=AutoSync.OnInsert, DbType="BigInt NOT NULL IDENTITY", CanBeNull=false, IsPrimaryKey=true, IsDbGenerated=true)]
			public long PozivLogID
			{
				get
				{
					return this._PozivLogID;
				}
				set
				{
					if (this._PozivLogID != value)
					{
						this.OnPozivLogIDChanging(value);
						this.SendPropertyChanging();
						this._PozivLogID = value;
						this.SendPropertyChanged("PozivLogID");
						this.OnPozivLogIDChanged();
					}
					this.SendPropertySetterInvoked("PozivLogID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_BillFirmaID", DbType="Int NOT NULL", CanBeNull=false)]
			public int BillFirmaID
			{
				get
				{
					return this._BillFirmaID;
				}
				set
				{
					if (this._BillFirmaID != value)
					{
						this.OnBillFirmaIDChanging(value);
						this.SendPropertyChanging();
						this._BillFirmaID = value;
						this.SendPropertyChanged("BillFirmaID");
						this.OnBillFirmaIDChanged();
					}
					this.SendPropertySetterInvoked("BillFirmaID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_InsertionDate", DbType="DateTime NOT NULL", CanBeNull=false)]
			public DateTime InsertionDate
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
			/// Column DbType=UniqueIdentifier
			/// </summary>
			[ColumnAttribute(Storage="_GroupName", DbType="UniqueIdentifier", CanBeNull=true)]
			public System.Guid? GroupName
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
			/// Column DbType=VarChar(50)
			/// </summary>
			[ColumnAttribute(Storage="_PreviousValue", DbType="VarChar(50)", CanBeNull=true)]
			public string PreviousValue
			{
				get
				{
					return this._PreviousValue;
				}
				set
				{
					if (this._PreviousValue != value)
					{
						this.OnPreviousValueChanging(value);
						this.SendPropertyChanging();
						this._PreviousValue = value;
						this.SendPropertyChanged("PreviousValue");
						this.OnPreviousValueChanged();
					}
					this.SendPropertySetterInvoked("PreviousValue", value);
				}
			}
			
			/// <summary>
			/// Column DbType=VarChar(150)
			/// </summary>
			[ColumnAttribute(Storage="_Kind", DbType="VarChar(150)", CanBeNull=true)]
			public string Kind
			{
				get
				{
					return this._Kind;
				}
				set
				{
					if (this._Kind != value)
					{
						this.OnKindChanging(value);
						this.SendPropertyChanging();
						this._Kind = value;
						this.SendPropertyChanged("Kind");
						this.OnKindChanged();
					}
					this.SendPropertySetterInvoked("Kind", value);
				}
			}
			
			/// <summary>
			/// Column DbType=VarChar(50)
			/// </summary>
			[ColumnAttribute(Storage="_ReturnValue", DbType="VarChar(50)", CanBeNull=true)]
			public string ReturnValue
			{
				get
				{
					return this._ReturnValue;
				}
				set
				{
					if (this._ReturnValue != value)
					{
						this.OnReturnValueChanging(value);
						this.SendPropertyChanging();
						this._ReturnValue = value;
						this.SendPropertyChanged("ReturnValue");
						this.OnReturnValueChanged();
					}
					this.SendPropertySetterInvoked("ReturnValue", value);
				}
			}
			
			/// <summary>
			/// Column DbType=VarChar(5)
			/// </summary>
			[ColumnAttribute(Storage="_Network", DbType="VarChar(5)", CanBeNull=true)]
			public string Network
			{
				get
				{
					return this._Network;
				}
				set
				{
					if (this._Network != value)
					{
						this.OnNetworkChanging(value);
						this.SendPropertyChanging();
						this._Network = value;
						this.SendPropertyChanged("Network");
						this.OnNetworkChanged();
					}
					this.SendPropertySetterInvoked("Network", value);
				}
			}
			
			/// <summary>
			/// Column DbType=VarChar(50)
			/// </summary>
			[ColumnAttribute(Storage="_FromPhone", DbType="VarChar(50)", CanBeNull=true)]
			public string FromPhone
			{
				get
				{
					return this._FromPhone;
				}
				set
				{
					if (this._FromPhone != value)
					{
						this.OnFromPhoneChanging(value);
						this.SendPropertyChanging();
						this._FromPhone = value;
						this.SendPropertyChanged("FromPhone");
						this.OnFromPhoneChanged();
					}
					this.SendPropertySetterInvoked("FromPhone", value);
				}
			}
			
			/// <summary>
			/// Column DbType=VarChar(50)
			/// </summary>
			[ColumnAttribute(Storage="_ToPhone", DbType="VarChar(50)", CanBeNull=true)]
			public string ToPhone
			{
				get
				{
					return this._ToPhone;
				}
				set
				{
					if (this._ToPhone != value)
					{
						this.OnToPhoneChanging(value);
						this.SendPropertyChanging();
						this._ToPhone = value;
						this.SendPropertyChanged("ToPhone");
						this.OnToPhoneChanged();
					}
					this.SendPropertySetterInvoked("ToPhone", value);
				}
			}
			
			/// <summary>
			/// Column DbType=VarChar(50)
			/// </summary>
			[ColumnAttribute(Storage="_FromIP", DbType="VarChar(50)", CanBeNull=true)]
			public string FromIP
			{
				get
				{
					return this._FromIP;
				}
				set
				{
					if (this._FromIP != value)
					{
						this.OnFromIPChanging(value);
						this.SendPropertyChanging();
						this._FromIP = value;
						this.SendPropertyChanged("FromIP");
						this.OnFromIPChanged();
					}
					this.SendPropertySetterInvoked("FromIP", value);
				}
			}
			
			/// <summary>
			/// Column DbType=VarChar(255)
			/// </summary>
			[ColumnAttribute(Storage="_QueryString", DbType="VarChar(255)", CanBeNull=true)]
			public string QueryString
			{
				get
				{
					return this._QueryString;
				}
				set
				{
					if (this._QueryString != value)
					{
						this.OnQueryStringChanging(value);
						this.SendPropertyChanging();
						this._QueryString = value;
						this.SendPropertyChanged("QueryString");
						this.OnQueryStringChanged();
					}
					this.SendPropertySetterInvoked("QueryString", value);
				}
			}
			
			#endregion Columns

			#region Associations
			/// <summary>
			/// Association [FK][Many]tblPozivLog.BillFirmaID --- [PK][One]tblBillFirma.BillFirmaID
			/// </summary>
			[AssociationAttribute(Name="FK_tblPozivLog_tblBillFirma", Storage="_tblBillFirma", ThisKey="BillFirmaID", OtherKey="BillFirmaID", IsUnique=false, IsForeignKey=true)]
			public tblBillFirma tblBillFirma
			{
				get
				{
					return this._tblBillFirma.Entity;
				}
				set
				{
					tblBillFirma previousValue = this._tblBillFirma.Entity;
					if ((previousValue != value) || (this._tblBillFirma.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._tblBillFirma.Entity = null;
							previousValue.tblPozivLogList.Remove(this);
						}
						this._tblBillFirma.Entity = value;
						if (value != null)
						{
							value.tblPozivLogList.Add(this);
							this._BillFirmaID = value.BillFirmaID;
						}
						else
						{
							this._BillFirmaID = default(int);
						}
						this.SendPropertyChanged("tblBillFirma");
					}
					this.SendPropertySetterInvoked("tblBillFirma", value);
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
		#endregion dbo.tblPozivLog

		#region dbo.tblSmsOutbox
		[TableAttribute(Name="dbo.tblSmsOutbox")]
		public partial class tblSmsOutbox : EntityBase<tblSmsOutbox, dbArizonaAppDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private long _SmsOutboxID;
			private DateTime _InsertionDate;
			private string _DestinationPhone;
			private string _MessageContent;
			private DateTime? _SendDate;
			private string _Result;
			private int? _JobApplicationID;
			private EntityRef<tblJobApplication> _tblJobApplication;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnSmsOutboxIDChanging(long value);
			partial void OnSmsOutboxIDChanged();
			partial void OnInsertionDateChanging(DateTime value);
			partial void OnInsertionDateChanged();
			partial void OnDestinationPhoneChanging(string value);
			partial void OnDestinationPhoneChanged();
			partial void OnMessageContentChanging(string value);
			partial void OnMessageContentChanged();
			partial void OnSendDateChanging(DateTime? value);
			partial void OnSendDateChanged();
			partial void OnResultChanging(string value);
			partial void OnResultChanged();
			partial void OnJobApplicationIDChanging(int? value);
			partial void OnJobApplicationIDChanged();
			#endregion

			public tblSmsOutbox()
			{
				_tblJobApplication = default(EntityRef<tblJobApplication>);
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=BigInt NOT NULL IDENTITY
			/// </summary>
			[ColumnAttribute(Storage="_SmsOutboxID", AutoSync=AutoSync.OnInsert, DbType="BigInt NOT NULL IDENTITY", CanBeNull=false, IsPrimaryKey=true, IsDbGenerated=true)]
			public long SmsOutboxID
			{
				get
				{
					return this._SmsOutboxID;
				}
				set
				{
					if (this._SmsOutboxID != value)
					{
						this.OnSmsOutboxIDChanging(value);
						this.SendPropertyChanging();
						this._SmsOutboxID = value;
						this.SendPropertyChanged("SmsOutboxID");
						this.OnSmsOutboxIDChanged();
					}
					this.SendPropertySetterInvoked("SmsOutboxID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_InsertionDate", DbType="DateTime NOT NULL", CanBeNull=false)]
			public DateTime InsertionDate
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
			/// Column DbType=VarChar(20) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_DestinationPhone", DbType="VarChar(20) NOT NULL", CanBeNull=false)]
			public string DestinationPhone
			{
				get
				{
					return this._DestinationPhone;
				}
				set
				{
					if (this._DestinationPhone != value)
					{
						this.OnDestinationPhoneChanging(value);
						this.SendPropertyChanging();
						this._DestinationPhone = value;
						this.SendPropertyChanged("DestinationPhone");
						this.OnDestinationPhoneChanged();
					}
					this.SendPropertySetterInvoked("DestinationPhone", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(500) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_MessageContent", DbType="NVarChar(500) NOT NULL", CanBeNull=false)]
			public string MessageContent
			{
				get
				{
					return this._MessageContent;
				}
				set
				{
					if (this._MessageContent != value)
					{
						this.OnMessageContentChanging(value);
						this.SendPropertyChanging();
						this._MessageContent = value;
						this.SendPropertyChanged("MessageContent");
						this.OnMessageContentChanged();
					}
					this.SendPropertySetterInvoked("MessageContent", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime
			/// </summary>
			[ColumnAttribute(Storage="_SendDate", DbType="DateTime", CanBeNull=true)]
			public DateTime? SendDate
			{
				get
				{
					return this._SendDate;
				}
				set
				{
					if (this._SendDate != value)
					{
						this.OnSendDateChanging(value);
						this.SendPropertyChanging();
						this._SendDate = value;
						this.SendPropertyChanged("SendDate");
						this.OnSendDateChanged();
					}
					this.SendPropertySetterInvoked("SendDate", value);
				}
			}
			
			/// <summary>
			/// Column DbType=VarChar(50)
			/// </summary>
			[ColumnAttribute(Storage="_Result", DbType="VarChar(50)", CanBeNull=true)]
			public string Result
			{
				get
				{
					return this._Result;
				}
				set
				{
					if (this._Result != value)
					{
						this.OnResultChanging(value);
						this.SendPropertyChanging();
						this._Result = value;
						this.SendPropertyChanged("Result");
						this.OnResultChanged();
					}
					this.SendPropertySetterInvoked("Result", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int
			/// </summary>
			[ColumnAttribute(Storage="_JobApplicationID", DbType="Int", CanBeNull=true)]
			public int? JobApplicationID
			{
				get
				{
					return this._JobApplicationID;
				}
				set
				{
					if (this._JobApplicationID != value)
					{
						this.OnJobApplicationIDChanging(value);
						this.SendPropertyChanging();
						this._JobApplicationID = value;
						this.SendPropertyChanged("JobApplicationID");
						this.OnJobApplicationIDChanged();
					}
					this.SendPropertySetterInvoked("JobApplicationID", value);
				}
			}
			
			#endregion Columns

			#region Associations
			/// <summary>
			/// Association [FK][Many]tblSmsOutbox.JobApplicationID --- [PK][One]tblJobApplication.JobApplicationID
			/// </summary>
			[AssociationAttribute(Name="FK_tblJobSms_tblJobApplication", Storage="_tblJobApplication", ThisKey="JobApplicationID", OtherKey="JobApplicationID", IsUnique=false, IsForeignKey=true)]
			public tblJobApplication tblJobApplication
			{
				get
				{
					return this._tblJobApplication.Entity;
				}
				set
				{
					tblJobApplication previousValue = this._tblJobApplication.Entity;
					if ((previousValue != value) || (this._tblJobApplication.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._tblJobApplication.Entity = null;
							previousValue.tblSmsOutboxList.Remove(this);
						}
						this._tblJobApplication.Entity = value;
						if (value != null)
						{
							value.tblSmsOutboxList.Add(this);
							this._JobApplicationID = value.JobApplicationID;
						}
						else
						{
							this._JobApplicationID = default(int?);
						}
						this.SendPropertyChanged("tblJobApplication");
					}
					this.SendPropertySetterInvoked("tblJobApplication", value);
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
		#endregion dbo.tblSmsOutbox

		#region dbo.tblSocialMember
		[TableAttribute(Name="dbo.tblSocialMember")]
		public partial class tblSocialMember : EntityBase<tblSocialMember, dbArizonaAppDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private long _SocialMemberID;
			private int _SocialProviderID;
			private DateTime _InsertionDate;
			private DateTime? _LastLoginDate;
			private string _SocialId;
			private string _EmailAddress;
			private string _Password;
			private DateTime? _EmailConfirmedDate;
			private string _FullName;
			private string _FirstName;
			private string _LastName;
			private string _PictureUrl;
			private int? _SocialMemberStatusID;
			private long? _BillClientID;
			private EntityRef<tblBillClient> _tblBillClient;
			private EntityRef<tblSocialMemberStatus> _tblSocialMemberStatus;
			private EntityRef<tblSocialProvider> _tblSocialProvider;
			private EntitySet<tblSocialMemberBillClient> _tblSocialMemberBillClientList;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnSocialMemberIDChanging(long value);
			partial void OnSocialMemberIDChanged();
			partial void OnSocialProviderIDChanging(int value);
			partial void OnSocialProviderIDChanged();
			partial void OnInsertionDateChanging(DateTime value);
			partial void OnInsertionDateChanged();
			partial void OnLastLoginDateChanging(DateTime? value);
			partial void OnLastLoginDateChanged();
			partial void OnSocialIdChanging(string value);
			partial void OnSocialIdChanged();
			partial void OnEmailAddressChanging(string value);
			partial void OnEmailAddressChanged();
			partial void OnPasswordChanging(string value);
			partial void OnPasswordChanged();
			partial void OnEmailConfirmedDateChanging(DateTime? value);
			partial void OnEmailConfirmedDateChanged();
			partial void OnFullNameChanging(string value);
			partial void OnFullNameChanged();
			partial void OnFirstNameChanging(string value);
			partial void OnFirstNameChanged();
			partial void OnLastNameChanging(string value);
			partial void OnLastNameChanged();
			partial void OnPictureUrlChanging(string value);
			partial void OnPictureUrlChanged();
			partial void OnSocialMemberStatusIDChanging(int? value);
			partial void OnSocialMemberStatusIDChanged();
			partial void OnBillClientIDChanging(long? value);
			partial void OnBillClientIDChanged();
			#endregion

			public tblSocialMember()
			{
				_tblBillClient = default(EntityRef<tblBillClient>);
				_tblSocialMemberStatus = default(EntityRef<tblSocialMemberStatus>);
				_tblSocialProvider = default(EntityRef<tblSocialProvider>);
				_tblSocialMemberBillClientList = new EntitySet<tblSocialMemberBillClient>(
					new Action<tblSocialMemberBillClient>(item=>{this.SendPropertyChanging(); item.tblSocialMember=this;}), 
					new Action<tblSocialMemberBillClient>(item=>{this.SendPropertyChanging(); item.tblSocialMember=null;}));
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=BigInt NOT NULL IDENTITY
			/// </summary>
			[ColumnAttribute(Storage="_SocialMemberID", AutoSync=AutoSync.OnInsert, DbType="BigInt NOT NULL IDENTITY", CanBeNull=false, IsPrimaryKey=true, IsDbGenerated=true)]
			public long SocialMemberID
			{
				get
				{
					return this._SocialMemberID;
				}
				set
				{
					if (this._SocialMemberID != value)
					{
						this.OnSocialMemberIDChanging(value);
						this.SendPropertyChanging();
						this._SocialMemberID = value;
						this.SendPropertyChanged("SocialMemberID");
						this.OnSocialMemberIDChanged();
					}
					this.SendPropertySetterInvoked("SocialMemberID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_SocialProviderID", DbType="Int NOT NULL", CanBeNull=false)]
			public int SocialProviderID
			{
				get
				{
					return this._SocialProviderID;
				}
				set
				{
					if (this._SocialProviderID != value)
					{
						this.OnSocialProviderIDChanging(value);
						this.SendPropertyChanging();
						this._SocialProviderID = value;
						this.SendPropertyChanged("SocialProviderID");
						this.OnSocialProviderIDChanged();
					}
					this.SendPropertySetterInvoked("SocialProviderID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_InsertionDate", DbType="DateTime NOT NULL", CanBeNull=false)]
			public DateTime InsertionDate
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
			/// Column DbType=VarChar(200)
			/// </summary>
			[ColumnAttribute(Storage="_SocialId", DbType="VarChar(200)", CanBeNull=true)]
			public string SocialId
			{
				get
				{
					return this._SocialId;
				}
				set
				{
					if (this._SocialId != value)
					{
						this.OnSocialIdChanging(value);
						this.SendPropertyChanging();
						this._SocialId = value;
						this.SendPropertyChanged("SocialId");
						this.OnSocialIdChanged();
					}
					this.SendPropertySetterInvoked("SocialId", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(250)
			/// </summary>
			[ColumnAttribute(Storage="_EmailAddress", DbType="NVarChar(250)", CanBeNull=true)]
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
			/// Column DbType=NVarChar(100)
			/// </summary>
			[ColumnAttribute(Storage="_Password", DbType="NVarChar(100)", CanBeNull=true)]
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
			[ColumnAttribute(Storage="_EmailConfirmedDate", DbType="DateTime", CanBeNull=true)]
			public DateTime? EmailConfirmedDate
			{
				get
				{
					return this._EmailConfirmedDate;
				}
				set
				{
					if (this._EmailConfirmedDate != value)
					{
						this.OnEmailConfirmedDateChanging(value);
						this.SendPropertyChanging();
						this._EmailConfirmedDate = value;
						this.SendPropertyChanged("EmailConfirmedDate");
						this.OnEmailConfirmedDateChanged();
					}
					this.SendPropertySetterInvoked("EmailConfirmedDate", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(200)
			/// </summary>
			[ColumnAttribute(Storage="_FullName", DbType="NVarChar(200)", CanBeNull=true)]
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
			/// Column DbType=VarChar(500)
			/// </summary>
			[ColumnAttribute(Storage="_PictureUrl", DbType="VarChar(500)", CanBeNull=true)]
			public string PictureUrl
			{
				get
				{
					return this._PictureUrl;
				}
				set
				{
					if (this._PictureUrl != value)
					{
						this.OnPictureUrlChanging(value);
						this.SendPropertyChanging();
						this._PictureUrl = value;
						this.SendPropertyChanged("PictureUrl");
						this.OnPictureUrlChanged();
					}
					this.SendPropertySetterInvoked("PictureUrl", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int
			/// </summary>
			[ColumnAttribute(Storage="_SocialMemberStatusID", DbType="Int", CanBeNull=true)]
			public int? SocialMemberStatusID
			{
				get
				{
					return this._SocialMemberStatusID;
				}
				set
				{
					if (this._SocialMemberStatusID != value)
					{
						this.OnSocialMemberStatusIDChanging(value);
						this.SendPropertyChanging();
						this._SocialMemberStatusID = value;
						this.SendPropertyChanged("SocialMemberStatusID");
						this.OnSocialMemberStatusIDChanged();
					}
					this.SendPropertySetterInvoked("SocialMemberStatusID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=BigInt
			/// </summary>
			[ColumnAttribute(Storage="_BillClientID", DbType="BigInt", CanBeNull=true)]
			public long? BillClientID
			{
				get
				{
					return this._BillClientID;
				}
				set
				{
					if (this._BillClientID != value)
					{
						this.OnBillClientIDChanging(value);
						this.SendPropertyChanging();
						this._BillClientID = value;
						this.SendPropertyChanged("BillClientID");
						this.OnBillClientIDChanged();
					}
					this.SendPropertySetterInvoked("BillClientID", value);
				}
			}
			
			#endregion Columns

			#region Associations
			/// <summary>
			/// Association [FK][Many]tblSocialMember.BillClientID --- [PK][One]tblBillClient.BillClientID
			/// </summary>
			[AssociationAttribute(Name="FK_tblSocialMember_tblBillClient", Storage="_tblBillClient", ThisKey="BillClientID", OtherKey="BillClientID", IsUnique=false, IsForeignKey=true)]
			public tblBillClient tblBillClient
			{
				get
				{
					return this._tblBillClient.Entity;
				}
				set
				{
					tblBillClient previousValue = this._tblBillClient.Entity;
					if ((previousValue != value) || (this._tblBillClient.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._tblBillClient.Entity = null;
							previousValue.tblSocialMemberList.Remove(this);
						}
						this._tblBillClient.Entity = value;
						if (value != null)
						{
							value.tblSocialMemberList.Add(this);
							this._BillClientID = value.BillClientID;
						}
						else
						{
							this._BillClientID = default(long?);
						}
						this.SendPropertyChanged("tblBillClient");
					}
					this.SendPropertySetterInvoked("tblBillClient", value);
				}
			}
			
			/// <summary>
			/// Association [FK][Many]tblSocialMember.SocialMemberStatusID --- [PK][One]tblSocialMemberStatus.SocialMemberStatusID
			/// </summary>
			[AssociationAttribute(Name="FK_tblSocialMember_tblSocialMemberStatus", Storage="_tblSocialMemberStatus", ThisKey="SocialMemberStatusID", OtherKey="SocialMemberStatusID", IsUnique=false, IsForeignKey=true)]
			public tblSocialMemberStatus tblSocialMemberStatus
			{
				get
				{
					return this._tblSocialMemberStatus.Entity;
				}
				set
				{
					tblSocialMemberStatus previousValue = this._tblSocialMemberStatus.Entity;
					if ((previousValue != value) || (this._tblSocialMemberStatus.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._tblSocialMemberStatus.Entity = null;
							previousValue.tblSocialMemberList.Remove(this);
						}
						this._tblSocialMemberStatus.Entity = value;
						if (value != null)
						{
							value.tblSocialMemberList.Add(this);
							this._SocialMemberStatusID = value.SocialMemberStatusID;
						}
						else
						{
							this._SocialMemberStatusID = default(int?);
						}
						this.SendPropertyChanged("tblSocialMemberStatus");
					}
					this.SendPropertySetterInvoked("tblSocialMemberStatus", value);
				}
			}
			
			/// <summary>
			/// Association [FK][Many]tblSocialMember.SocialProviderID --- [PK][One]tblSocialProvider.SocialProviderID
			/// </summary>
			[AssociationAttribute(Name="FK_tblSocialMember_tblSocialProvider", Storage="_tblSocialProvider", ThisKey="SocialProviderID", OtherKey="SocialProviderID", IsUnique=false, IsForeignKey=true)]
			public tblSocialProvider tblSocialProvider
			{
				get
				{
					return this._tblSocialProvider.Entity;
				}
				set
				{
					tblSocialProvider previousValue = this._tblSocialProvider.Entity;
					if ((previousValue != value) || (this._tblSocialProvider.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._tblSocialProvider.Entity = null;
							previousValue.tblSocialMemberList.Remove(this);
						}
						this._tblSocialProvider.Entity = value;
						if (value != null)
						{
							value.tblSocialMemberList.Add(this);
							this._SocialProviderID = value.SocialProviderID;
						}
						else
						{
							this._SocialProviderID = default(int);
						}
						this.SendPropertyChanged("tblSocialProvider");
					}
					this.SendPropertySetterInvoked("tblSocialProvider", value);
				}
			}
			
			/// <summary>
			/// Association [PK][One]tblSocialMember.SocialMemberID --- [FK][Many]tblSocialMemberBillClient.SocialMemberID
			/// </summary>
			[AssociationAttribute(Name="FK_tblSocialMemberBillClient_tblSocialMember", Storage="_tblSocialMemberBillClientList", ThisKey="SocialMemberID", OtherKey="SocialMemberID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<tblSocialMemberBillClient> tblSocialMemberBillClientList
			{
				get { return this._tblSocialMemberBillClientList; }
				set { this._tblSocialMemberBillClientList.Assign(value); }
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
		#endregion dbo.tblSocialMember

		#region dbo.tblSocialMemberBillClient
		[TableAttribute(Name="dbo.tblSocialMemberBillClient")]
		public partial class tblSocialMemberBillClient : EntityBase<tblSocialMemberBillClient, dbArizonaAppDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private long _SocialMemberID;
			private long _BillClientID;
			private DateTime _InsertionDate;
			private DateTime? _LastLoginDate;
			private EntityRef<tblBillClient> _tblBillClient;
			private EntityRef<tblSocialMember> _tblSocialMember;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnSocialMemberIDChanging(long value);
			partial void OnSocialMemberIDChanged();
			partial void OnBillClientIDChanging(long value);
			partial void OnBillClientIDChanged();
			partial void OnInsertionDateChanging(DateTime value);
			partial void OnInsertionDateChanged();
			partial void OnLastLoginDateChanging(DateTime? value);
			partial void OnLastLoginDateChanged();
			#endregion

			public tblSocialMemberBillClient()
			{
				_tblBillClient = default(EntityRef<tblBillClient>);
				_tblSocialMember = default(EntityRef<tblSocialMember>);
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=BigInt NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_SocialMemberID", DbType="BigInt NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
			public long SocialMemberID
			{
				get
				{
					return this._SocialMemberID;
				}
				set
				{
					if (this._SocialMemberID != value)
					{
						this.OnSocialMemberIDChanging(value);
						this.SendPropertyChanging();
						this._SocialMemberID = value;
						this.SendPropertyChanged("SocialMemberID");
						this.OnSocialMemberIDChanged();
					}
					this.SendPropertySetterInvoked("SocialMemberID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=BigInt NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_BillClientID", DbType="BigInt NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
			public long BillClientID
			{
				get
				{
					return this._BillClientID;
				}
				set
				{
					if (this._BillClientID != value)
					{
						this.OnBillClientIDChanging(value);
						this.SendPropertyChanging();
						this._BillClientID = value;
						this.SendPropertyChanged("BillClientID");
						this.OnBillClientIDChanged();
					}
					this.SendPropertySetterInvoked("BillClientID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_InsertionDate", DbType="DateTime NOT NULL", CanBeNull=false)]
			public DateTime InsertionDate
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
			
			#endregion Columns

			#region Associations
			/// <summary>
			/// Association [FK][Many]tblSocialMemberBillClient.BillClientID --- [PK][One]tblBillClient.BillClientID
			/// </summary>
			[AssociationAttribute(Name="FK_tblSocialMemberBillClient_tblBillClient", Storage="_tblBillClient", ThisKey="BillClientID", OtherKey="BillClientID", IsUnique=false, IsForeignKey=true)]
			public tblBillClient tblBillClient
			{
				get
				{
					return this._tblBillClient.Entity;
				}
				set
				{
					tblBillClient previousValue = this._tblBillClient.Entity;
					if ((previousValue != value) || (this._tblBillClient.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._tblBillClient.Entity = null;
							previousValue.tblSocialMemberBillClientList.Remove(this);
						}
						this._tblBillClient.Entity = value;
						if (value != null)
						{
							value.tblSocialMemberBillClientList.Add(this);
							this._BillClientID = value.BillClientID;
						}
						else
						{
							this._BillClientID = default(long);
						}
						this.SendPropertyChanged("tblBillClient");
					}
					this.SendPropertySetterInvoked("tblBillClient", value);
				}
			}
			
			/// <summary>
			/// Association [FK][Many]tblSocialMemberBillClient.SocialMemberID --- [PK][One]tblSocialMember.SocialMemberID
			/// </summary>
			[AssociationAttribute(Name="FK_tblSocialMemberBillClient_tblSocialMember", Storage="_tblSocialMember", ThisKey="SocialMemberID", OtherKey="SocialMemberID", IsUnique=false, IsForeignKey=true)]
			public tblSocialMember tblSocialMember
			{
				get
				{
					return this._tblSocialMember.Entity;
				}
				set
				{
					tblSocialMember previousValue = this._tblSocialMember.Entity;
					if ((previousValue != value) || (this._tblSocialMember.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._tblSocialMember.Entity = null;
							previousValue.tblSocialMemberBillClientList.Remove(this);
						}
						this._tblSocialMember.Entity = value;
						if (value != null)
						{
							value.tblSocialMemberBillClientList.Add(this);
							this._SocialMemberID = value.SocialMemberID;
						}
						else
						{
							this._SocialMemberID = default(long);
						}
						this.SendPropertyChanged("tblSocialMember");
					}
					this.SendPropertySetterInvoked("tblSocialMember", value);
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
		#endregion dbo.tblSocialMemberBillClient

		#region dbo.tblSocialMemberStatus
		[TableAttribute(Name="dbo.tblSocialMemberStatus")]
		public partial class tblSocialMemberStatus : EntityBase<tblSocialMemberStatus, dbArizonaAppDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private int _SocialMemberStatusID;
			private int _Ordinal;
			private string _Name;
			private EntitySet<tblSocialMember> _tblSocialMemberList;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnSocialMemberStatusIDChanging(int value);
			partial void OnSocialMemberStatusIDChanged();
			partial void OnOrdinalChanging(int value);
			partial void OnOrdinalChanged();
			partial void OnNameChanging(string value);
			partial void OnNameChanged();
			#endregion

			public tblSocialMemberStatus()
			{
				_tblSocialMemberList = new EntitySet<tblSocialMember>(
					new Action<tblSocialMember>(item=>{this.SendPropertyChanging(); item.tblSocialMemberStatus=this;}), 
					new Action<tblSocialMember>(item=>{this.SendPropertyChanging(); item.tblSocialMemberStatus=null;}));
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_SocialMemberStatusID", DbType="Int NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
			public int SocialMemberStatusID
			{
				get
				{
					return this._SocialMemberStatusID;
				}
				set
				{
					if (this._SocialMemberStatusID != value)
					{
						this.OnSocialMemberStatusIDChanging(value);
						this.SendPropertyChanging();
						this._SocialMemberStatusID = value;
						this.SendPropertyChanged("SocialMemberStatusID");
						this.OnSocialMemberStatusIDChanged();
					}
					this.SendPropertySetterInvoked("SocialMemberStatusID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_Ordinal", DbType="Int NOT NULL", CanBeNull=false)]
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
						this.OnOrdinalChanging(value);
						this.SendPropertyChanging();
						this._Ordinal = value;
						this.SendPropertyChanged("Ordinal");
						this.OnOrdinalChanged();
					}
					this.SendPropertySetterInvoked("Ordinal", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(200) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_Name", DbType="NVarChar(200) NOT NULL", CanBeNull=false)]
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
			
			#endregion Columns

			#region Associations
			/// <summary>
			/// Association [PK][One]tblSocialMemberStatus.SocialMemberStatusID --- [FK][Many]tblSocialMember.SocialMemberStatusID
			/// </summary>
			[AssociationAttribute(Name="FK_tblSocialMember_tblSocialMemberStatus", Storage="_tblSocialMemberList", ThisKey="SocialMemberStatusID", OtherKey="SocialMemberStatusID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<tblSocialMember> tblSocialMemberList
			{
				get { return this._tblSocialMemberList; }
				set { this._tblSocialMemberList.Assign(value); }
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
		#endregion dbo.tblSocialMemberStatus

		#region dbo.tblSocialProvider
		[TableAttribute(Name="dbo.tblSocialProvider")]
		public partial class tblSocialProvider : EntityBase<tblSocialProvider, dbArizonaAppDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private int _SocialProviderID;
			private string _Name;
			private EntitySet<tblSocialMember> _tblSocialMemberList;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnSocialProviderIDChanging(int value);
			partial void OnSocialProviderIDChanged();
			partial void OnNameChanging(string value);
			partial void OnNameChanged();
			#endregion

			public tblSocialProvider()
			{
				_tblSocialMemberList = new EntitySet<tblSocialMember>(
					new Action<tblSocialMember>(item=>{this.SendPropertyChanging(); item.tblSocialProvider=this;}), 
					new Action<tblSocialMember>(item=>{this.SendPropertyChanging(); item.tblSocialProvider=null;}));
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_SocialProviderID", DbType="Int NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
			public int SocialProviderID
			{
				get
				{
					return this._SocialProviderID;
				}
				set
				{
					if (this._SocialProviderID != value)
					{
						this.OnSocialProviderIDChanging(value);
						this.SendPropertyChanging();
						this._SocialProviderID = value;
						this.SendPropertyChanged("SocialProviderID");
						this.OnSocialProviderIDChanged();
					}
					this.SendPropertySetterInvoked("SocialProviderID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(200) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_Name", DbType="NVarChar(200) NOT NULL", CanBeNull=false)]
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
			
			#endregion Columns

			#region Associations
			/// <summary>
			/// Association [PK][One]tblSocialProvider.SocialProviderID --- [FK][Many]tblSocialMember.SocialProviderID
			/// </summary>
			[AssociationAttribute(Name="FK_tblSocialMember_tblSocialProvider", Storage="_tblSocialMemberList", ThisKey="SocialProviderID", OtherKey="SocialProviderID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<tblSocialMember> tblSocialMemberList
			{
				get { return this._tblSocialMemberList; }
				set { this._tblSocialMemberList.Assign(value); }
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
		#endregion dbo.tblSocialProvider

		#region dbo.tblTask
		[TableAttribute(Name="dbo.tblTask")]
		public partial class tblTask : EntityBase<tblTask, dbArizonaAppDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private int _TaskID;
			private bool _IsActive;
			private string _Name;
			private string _Description;
			private EntitySet<tblTaskSchedule> _tblTaskScheduleList;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnTaskIDChanging(int value);
			partial void OnTaskIDChanged();
			partial void OnIsActiveChanging(bool value);
			partial void OnIsActiveChanged();
			partial void OnNameChanging(string value);
			partial void OnNameChanged();
			partial void OnDescriptionChanging(string value);
			partial void OnDescriptionChanged();
			#endregion

			public tblTask()
			{
				_tblTaskScheduleList = new EntitySet<tblTaskSchedule>(
					new Action<tblTaskSchedule>(item=>{this.SendPropertyChanging(); item.tblTask=this;}), 
					new Action<tblTaskSchedule>(item=>{this.SendPropertyChanging(); item.tblTask=null;}));
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_TaskID", DbType="Int NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
			public int TaskID
			{
				get
				{
					return this._TaskID;
				}
				set
				{
					if (this._TaskID != value)
					{
						this.OnTaskIDChanging(value);
						this.SendPropertyChanging();
						this._TaskID = value;
						this.SendPropertyChanged("TaskID");
						this.OnTaskIDChanged();
					}
					this.SendPropertySetterInvoked("TaskID", value);
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
			/// Column DbType=VarChar(50) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_Name", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
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
			/// Association [PK][One]tblTask.TaskID --- [FK][Many]tblTaskSchedule.TaskID
			/// </summary>
			[AssociationAttribute(Name="FK_tblTaskSchedule_tblTask", Storage="_tblTaskScheduleList", ThisKey="TaskID", OtherKey="TaskID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<tblTaskSchedule> tblTaskScheduleList
			{
				get { return this._tblTaskScheduleList; }
				set { this._tblTaskScheduleList.Assign(value); }
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
		#endregion dbo.tblTask

		#region dbo.tblTaskSchedule
		[TableAttribute(Name="dbo.tblTaskSchedule")]
		public partial class tblTaskSchedule : EntityBase<tblTaskSchedule, dbArizonaAppDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private int _TaskScheduleID;
			private int _TaskID;
			private bool _IsActive;
			private string _Name;
			private int? _RecurMinutes;
			private System.TimeSpan? _StartDailyAtTime;
			private DateTime? _LastStart;
			private DateTime? _NextStart;
			private DateTime? _LastSuccessfulEnd;
			private DateTime? _LastFailedEnd;
			private EntityRef<tblTask> _tblTask;
			private EntitySet<tblTaskScheduleLog> _tblTaskScheduleLogList;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnTaskScheduleIDChanging(int value);
			partial void OnTaskScheduleIDChanged();
			partial void OnTaskIDChanging(int value);
			partial void OnTaskIDChanged();
			partial void OnIsActiveChanging(bool value);
			partial void OnIsActiveChanged();
			partial void OnNameChanging(string value);
			partial void OnNameChanged();
			partial void OnRecurMinutesChanging(int? value);
			partial void OnRecurMinutesChanged();
			partial void OnStartDailyAtTimeChanging(System.TimeSpan? value);
			partial void OnStartDailyAtTimeChanged();
			partial void OnLastStartChanging(DateTime? value);
			partial void OnLastStartChanged();
			partial void OnNextStartChanging(DateTime? value);
			partial void OnNextStartChanged();
			partial void OnLastSuccessfulEndChanging(DateTime? value);
			partial void OnLastSuccessfulEndChanged();
			partial void OnLastFailedEndChanging(DateTime? value);
			partial void OnLastFailedEndChanged();
			#endregion

			public tblTaskSchedule()
			{
				_tblTask = default(EntityRef<tblTask>);
				_tblTaskScheduleLogList = new EntitySet<tblTaskScheduleLog>(
					new Action<tblTaskScheduleLog>(item=>{this.SendPropertyChanging(); item.tblTaskSchedule=this;}), 
					new Action<tblTaskScheduleLog>(item=>{this.SendPropertyChanging(); item.tblTaskSchedule=null;}));
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=Int NOT NULL IDENTITY
			/// </summary>
			[ColumnAttribute(Storage="_TaskScheduleID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", CanBeNull=false, IsPrimaryKey=true, IsDbGenerated=true)]
			public int TaskScheduleID
			{
				get
				{
					return this._TaskScheduleID;
				}
				set
				{
					if (this._TaskScheduleID != value)
					{
						this.OnTaskScheduleIDChanging(value);
						this.SendPropertyChanging();
						this._TaskScheduleID = value;
						this.SendPropertyChanged("TaskScheduleID");
						this.OnTaskScheduleIDChanged();
					}
					this.SendPropertySetterInvoked("TaskScheduleID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_TaskID", DbType="Int NOT NULL", CanBeNull=false)]
			public int TaskID
			{
				get
				{
					return this._TaskID;
				}
				set
				{
					if (this._TaskID != value)
					{
						this.OnTaskIDChanging(value);
						this.SendPropertyChanging();
						this._TaskID = value;
						this.SendPropertyChanged("TaskID");
						this.OnTaskIDChanged();
					}
					this.SendPropertySetterInvoked("TaskID", value);
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
			/// Column DbType=VarChar(50) NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_Name", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
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
			[ColumnAttribute(Storage="_RecurMinutes", DbType="Int", CanBeNull=true)]
			public int? RecurMinutes
			{
				get
				{
					return this._RecurMinutes;
				}
				set
				{
					if (this._RecurMinutes != value)
					{
						this.OnRecurMinutesChanging(value);
						this.SendPropertyChanging();
						this._RecurMinutes = value;
						this.SendPropertyChanged("RecurMinutes");
						this.OnRecurMinutesChanged();
					}
					this.SendPropertySetterInvoked("RecurMinutes", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Time(7)
			/// </summary>
			[ColumnAttribute(Storage="_StartDailyAtTime", DbType="Time(7)", CanBeNull=true)]
			public System.TimeSpan? StartDailyAtTime
			{
				get
				{
					return this._StartDailyAtTime;
				}
				set
				{
					if (this._StartDailyAtTime != value)
					{
						this.OnStartDailyAtTimeChanging(value);
						this.SendPropertyChanging();
						this._StartDailyAtTime = value;
						this.SendPropertyChanged("StartDailyAtTime");
						this.OnStartDailyAtTimeChanged();
					}
					this.SendPropertySetterInvoked("StartDailyAtTime", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime
			/// </summary>
			[ColumnAttribute(Storage="_LastStart", DbType="DateTime", CanBeNull=true)]
			public DateTime? LastStart
			{
				get
				{
					return this._LastStart;
				}
				set
				{
					if (this._LastStart != value)
					{
						this.OnLastStartChanging(value);
						this.SendPropertyChanging();
						this._LastStart = value;
						this.SendPropertyChanged("LastStart");
						this.OnLastStartChanged();
					}
					this.SendPropertySetterInvoked("LastStart", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime
			/// </summary>
			[ColumnAttribute(Storage="_NextStart", DbType="DateTime", CanBeNull=true)]
			public DateTime? NextStart
			{
				get
				{
					return this._NextStart;
				}
				set
				{
					if (this._NextStart != value)
					{
						this.OnNextStartChanging(value);
						this.SendPropertyChanging();
						this._NextStart = value;
						this.SendPropertyChanged("NextStart");
						this.OnNextStartChanged();
					}
					this.SendPropertySetterInvoked("NextStart", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime
			/// </summary>
			[ColumnAttribute(Storage="_LastSuccessfulEnd", DbType="DateTime", CanBeNull=true)]
			public DateTime? LastSuccessfulEnd
			{
				get
				{
					return this._LastSuccessfulEnd;
				}
				set
				{
					if (this._LastSuccessfulEnd != value)
					{
						this.OnLastSuccessfulEndChanging(value);
						this.SendPropertyChanging();
						this._LastSuccessfulEnd = value;
						this.SendPropertyChanged("LastSuccessfulEnd");
						this.OnLastSuccessfulEndChanged();
					}
					this.SendPropertySetterInvoked("LastSuccessfulEnd", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime
			/// </summary>
			[ColumnAttribute(Storage="_LastFailedEnd", DbType="DateTime", CanBeNull=true)]
			public DateTime? LastFailedEnd
			{
				get
				{
					return this._LastFailedEnd;
				}
				set
				{
					if (this._LastFailedEnd != value)
					{
						this.OnLastFailedEndChanging(value);
						this.SendPropertyChanging();
						this._LastFailedEnd = value;
						this.SendPropertyChanged("LastFailedEnd");
						this.OnLastFailedEndChanged();
					}
					this.SendPropertySetterInvoked("LastFailedEnd", value);
				}
			}
			
			#endregion Columns

			#region Associations
			/// <summary>
			/// Association [FK][Many]tblTaskSchedule.TaskID --- [PK][One]tblTask.TaskID
			/// </summary>
			[AssociationAttribute(Name="FK_tblTaskSchedule_tblTask", Storage="_tblTask", ThisKey="TaskID", OtherKey="TaskID", IsUnique=false, IsForeignKey=true)]
			public tblTask tblTask
			{
				get
				{
					return this._tblTask.Entity;
				}
				set
				{
					tblTask previousValue = this._tblTask.Entity;
					if ((previousValue != value) || (this._tblTask.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._tblTask.Entity = null;
							previousValue.tblTaskScheduleList.Remove(this);
						}
						this._tblTask.Entity = value;
						if (value != null)
						{
							value.tblTaskScheduleList.Add(this);
							this._TaskID = value.TaskID;
						}
						else
						{
							this._TaskID = default(int);
						}
						this.SendPropertyChanged("tblTask");
					}
					this.SendPropertySetterInvoked("tblTask", value);
				}
			}
			
			/// <summary>
			/// Association [PK][One]tblTaskSchedule.TaskScheduleID --- [FK][Many]tblTaskScheduleLog.TaskScheduleID
			/// </summary>
			[AssociationAttribute(Name="FK_tblTaskScheduleLog_tblTaskSchedule", Storage="_tblTaskScheduleLogList", ThisKey="TaskScheduleID", OtherKey="TaskScheduleID", IsUnique=false, IsForeignKey=false, DeleteRule="NoAction")]
			public EntitySet<tblTaskScheduleLog> tblTaskScheduleLogList
			{
				get { return this._tblTaskScheduleLogList; }
				set { this._tblTaskScheduleLogList.Assign(value); }
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
		#endregion dbo.tblTaskSchedule

		#region dbo.tblTaskScheduleLog
		[TableAttribute(Name="dbo.tblTaskScheduleLog")]
		public partial class tblTaskScheduleLog : EntityBase<tblTaskScheduleLog, dbArizonaAppDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private long _TaskScheduleLogID;
			private int _TaskScheduleID;
			private DateTime? _StartDate;
			private DateTime? _EndDate;
			private bool? _IsSuccessful;
			private string _Note;
			private EntityRef<tblTaskSchedule> _tblTaskSchedule;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnTaskScheduleLogIDChanging(long value);
			partial void OnTaskScheduleLogIDChanged();
			partial void OnTaskScheduleIDChanging(int value);
			partial void OnTaskScheduleIDChanged();
			partial void OnStartDateChanging(DateTime? value);
			partial void OnStartDateChanged();
			partial void OnEndDateChanging(DateTime? value);
			partial void OnEndDateChanged();
			partial void OnIsSuccessfulChanging(bool? value);
			partial void OnIsSuccessfulChanged();
			partial void OnNoteChanging(string value);
			partial void OnNoteChanged();
			#endregion

			public tblTaskScheduleLog()
			{
				_tblTaskSchedule = default(EntityRef<tblTaskSchedule>);
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=BigInt NOT NULL IDENTITY
			/// </summary>
			[ColumnAttribute(Storage="_TaskScheduleLogID", AutoSync=AutoSync.OnInsert, DbType="BigInt NOT NULL IDENTITY", CanBeNull=false, IsPrimaryKey=true, IsDbGenerated=true)]
			public long TaskScheduleLogID
			{
				get
				{
					return this._TaskScheduleLogID;
				}
				set
				{
					if (this._TaskScheduleLogID != value)
					{
						this.OnTaskScheduleLogIDChanging(value);
						this.SendPropertyChanging();
						this._TaskScheduleLogID = value;
						this.SendPropertyChanged("TaskScheduleLogID");
						this.OnTaskScheduleLogIDChanged();
					}
					this.SendPropertySetterInvoked("TaskScheduleLogID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_TaskScheduleID", DbType="Int NOT NULL", CanBeNull=false)]
			public int TaskScheduleID
			{
				get
				{
					return this._TaskScheduleID;
				}
				set
				{
					if (this._TaskScheduleID != value)
					{
						this.OnTaskScheduleIDChanging(value);
						this.SendPropertyChanging();
						this._TaskScheduleID = value;
						this.SendPropertyChanged("TaskScheduleID");
						this.OnTaskScheduleIDChanged();
					}
					this.SendPropertySetterInvoked("TaskScheduleID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime
			/// </summary>
			[ColumnAttribute(Storage="_StartDate", DbType="DateTime", CanBeNull=true)]
			public DateTime? StartDate
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
			/// Column DbType=Bit
			/// </summary>
			[ColumnAttribute(Storage="_IsSuccessful", DbType="Bit", CanBeNull=true)]
			public bool? IsSuccessful
			{
				get
				{
					return this._IsSuccessful;
				}
				set
				{
					if (this._IsSuccessful != value)
					{
						this.OnIsSuccessfulChanging(value);
						this.SendPropertyChanging();
						this._IsSuccessful = value;
						this.SendPropertyChanged("IsSuccessful");
						this.OnIsSuccessfulChanged();
					}
					this.SendPropertySetterInvoked("IsSuccessful", value);
				}
			}
			
			/// <summary>
			/// Column DbType=NVarChar(100)
			/// </summary>
			[ColumnAttribute(Storage="_Note", DbType="NVarChar(100)", CanBeNull=true)]
			public string Note
			{
				get
				{
					return this._Note;
				}
				set
				{
					if (this._Note != value)
					{
						this.OnNoteChanging(value);
						this.SendPropertyChanging();
						this._Note = value;
						this.SendPropertyChanged("Note");
						this.OnNoteChanged();
					}
					this.SendPropertySetterInvoked("Note", value);
				}
			}
			
			#endregion Columns

			#region Associations
			/// <summary>
			/// Association [FK][Many]tblTaskScheduleLog.TaskScheduleID --- [PK][One]tblTaskSchedule.TaskScheduleID
			/// </summary>
			[AssociationAttribute(Name="FK_tblTaskScheduleLog_tblTaskSchedule", Storage="_tblTaskSchedule", ThisKey="TaskScheduleID", OtherKey="TaskScheduleID", IsUnique=false, IsForeignKey=true)]
			public tblTaskSchedule tblTaskSchedule
			{
				get
				{
					return this._tblTaskSchedule.Entity;
				}
				set
				{
					tblTaskSchedule previousValue = this._tblTaskSchedule.Entity;
					if ((previousValue != value) || (this._tblTaskSchedule.HasLoadedOrAssignedValue == false))
					{
						this.SendPropertyChanging();
						if (previousValue != null)
						{
							this._tblTaskSchedule.Entity = null;
							previousValue.tblTaskScheduleLogList.Remove(this);
						}
						this._tblTaskSchedule.Entity = value;
						if (value != null)
						{
							value.tblTaskScheduleLogList.Add(this);
							this._TaskScheduleID = value.TaskScheduleID;
						}
						else
						{
							this._TaskScheduleID = default(int);
						}
						this.SendPropertyChanged("tblTaskSchedule");
					}
					this.SendPropertySetterInvoked("tblTaskSchedule", value);
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
		#endregion dbo.tblTaskScheduleLog

		#region dbo.viewBookkeepingFiduciaExport
		[TableAttribute(Name="dbo.viewBookkeepingFiduciaExport")]
		public partial class viewBookkeepingFiduciaExport : EntityBase<viewBookkeepingFiduciaExport, dbArizonaAppDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private int _FiduciaExportID;
			private DateTime _DatumGeneriranja;
			private int _BillFirmaID;
			private DateTime _StartDateIncluded;
			private DateTime _EndDateExcluded;
			private bool? _HasAllData;
			private bool? _HasKlijenti;
			private bool? _HasRacuniKonta;
			private bool? _HasRacuniKnjiga;
			private bool? _HasPreknjizenja;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnFiduciaExportIDChanging(int value);
			partial void OnFiduciaExportIDChanged();
			partial void OnDatumGeneriranjaChanging(DateTime value);
			partial void OnDatumGeneriranjaChanged();
			partial void OnBillFirmaIDChanging(int value);
			partial void OnBillFirmaIDChanged();
			partial void OnStartDateIncludedChanging(DateTime value);
			partial void OnStartDateIncludedChanged();
			partial void OnEndDateExcludedChanging(DateTime value);
			partial void OnEndDateExcludedChanged();
			partial void OnHasAllDataChanging(bool? value);
			partial void OnHasAllDataChanged();
			partial void OnHasKlijentiChanging(bool? value);
			partial void OnHasKlijentiChanged();
			partial void OnHasRacuniKontaChanging(bool? value);
			partial void OnHasRacuniKontaChanged();
			partial void OnHasRacuniKnjigaChanging(bool? value);
			partial void OnHasRacuniKnjigaChanged();
			partial void OnHasPreknjizenjaChanging(bool? value);
			partial void OnHasPreknjizenjaChanged();
			#endregion

			public viewBookkeepingFiduciaExport()
			{
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=Int NOT NULL IDENTITY
			/// </summary>
			[ColumnAttribute(Storage="_FiduciaExportID", DbType="Int NOT NULL IDENTITY", CanBeNull=false)]
			public int FiduciaExportID
			{
				get
				{
					return this._FiduciaExportID;
				}
				set
				{
					if (this._FiduciaExportID != value)
					{
						this.OnFiduciaExportIDChanging(value);
						this.SendPropertyChanging();
						this._FiduciaExportID = value;
						this.SendPropertyChanged("FiduciaExportID");
						this.OnFiduciaExportIDChanged();
					}
					this.SendPropertySetterInvoked("FiduciaExportID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_DatumGeneriranja", DbType="DateTime NOT NULL", CanBeNull=false)]
			public DateTime DatumGeneriranja
			{
				get
				{
					return this._DatumGeneriranja;
				}
				set
				{
					if (this._DatumGeneriranja != value)
					{
						this.OnDatumGeneriranjaChanging(value);
						this.SendPropertyChanging();
						this._DatumGeneriranja = value;
						this.SendPropertyChanged("DatumGeneriranja");
						this.OnDatumGeneriranjaChanged();
					}
					this.SendPropertySetterInvoked("DatumGeneriranja", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_BillFirmaID", DbType="Int NOT NULL", CanBeNull=false)]
			public int BillFirmaID
			{
				get
				{
					return this._BillFirmaID;
				}
				set
				{
					if (this._BillFirmaID != value)
					{
						this.OnBillFirmaIDChanging(value);
						this.SendPropertyChanging();
						this._BillFirmaID = value;
						this.SendPropertyChanged("BillFirmaID");
						this.OnBillFirmaIDChanged();
					}
					this.SendPropertySetterInvoked("BillFirmaID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_StartDateIncluded", DbType="DateTime NOT NULL", CanBeNull=false)]
			public DateTime StartDateIncluded
			{
				get
				{
					return this._StartDateIncluded;
				}
				set
				{
					if (this._StartDateIncluded != value)
					{
						this.OnStartDateIncludedChanging(value);
						this.SendPropertyChanging();
						this._StartDateIncluded = value;
						this.SendPropertyChanged("StartDateIncluded");
						this.OnStartDateIncludedChanged();
					}
					this.SendPropertySetterInvoked("StartDateIncluded", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_EndDateExcluded", DbType="DateTime NOT NULL", CanBeNull=false)]
			public DateTime EndDateExcluded
			{
				get
				{
					return this._EndDateExcluded;
				}
				set
				{
					if (this._EndDateExcluded != value)
					{
						this.OnEndDateExcludedChanging(value);
						this.SendPropertyChanging();
						this._EndDateExcluded = value;
						this.SendPropertyChanged("EndDateExcluded");
						this.OnEndDateExcludedChanged();
					}
					this.SendPropertySetterInvoked("EndDateExcluded", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Bit
			/// </summary>
			[ColumnAttribute(Storage="_HasAllData", DbType="Bit", CanBeNull=true)]
			public bool? HasAllData
			{
				get
				{
					return this._HasAllData;
				}
				set
				{
					if (this._HasAllData != value)
					{
						this.OnHasAllDataChanging(value);
						this.SendPropertyChanging();
						this._HasAllData = value;
						this.SendPropertyChanged("HasAllData");
						this.OnHasAllDataChanged();
					}
					this.SendPropertySetterInvoked("HasAllData", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Bit
			/// </summary>
			[ColumnAttribute(Storage="_HasKlijenti", DbType="Bit", CanBeNull=true)]
			public bool? HasKlijenti
			{
				get
				{
					return this._HasKlijenti;
				}
				set
				{
					if (this._HasKlijenti != value)
					{
						this.OnHasKlijentiChanging(value);
						this.SendPropertyChanging();
						this._HasKlijenti = value;
						this.SendPropertyChanged("HasKlijenti");
						this.OnHasKlijentiChanged();
					}
					this.SendPropertySetterInvoked("HasKlijenti", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Bit
			/// </summary>
			[ColumnAttribute(Storage="_HasRacuniKonta", DbType="Bit", CanBeNull=true)]
			public bool? HasRacuniKonta
			{
				get
				{
					return this._HasRacuniKonta;
				}
				set
				{
					if (this._HasRacuniKonta != value)
					{
						this.OnHasRacuniKontaChanging(value);
						this.SendPropertyChanging();
						this._HasRacuniKonta = value;
						this.SendPropertyChanged("HasRacuniKonta");
						this.OnHasRacuniKontaChanged();
					}
					this.SendPropertySetterInvoked("HasRacuniKonta", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Bit
			/// </summary>
			[ColumnAttribute(Storage="_HasRacuniKnjiga", DbType="Bit", CanBeNull=true)]
			public bool? HasRacuniKnjiga
			{
				get
				{
					return this._HasRacuniKnjiga;
				}
				set
				{
					if (this._HasRacuniKnjiga != value)
					{
						this.OnHasRacuniKnjigaChanging(value);
						this.SendPropertyChanging();
						this._HasRacuniKnjiga = value;
						this.SendPropertyChanged("HasRacuniKnjiga");
						this.OnHasRacuniKnjigaChanged();
					}
					this.SendPropertySetterInvoked("HasRacuniKnjiga", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Bit
			/// </summary>
			[ColumnAttribute(Storage="_HasPreknjizenja", DbType="Bit", CanBeNull=true)]
			public bool? HasPreknjizenja
			{
				get
				{
					return this._HasPreknjizenja;
				}
				set
				{
					if (this._HasPreknjizenja != value)
					{
						this.OnHasPreknjizenjaChanging(value);
						this.SendPropertyChanging();
						this._HasPreknjizenja = value;
						this.SendPropertyChanged("HasPreknjizenja");
						this.OnHasPreknjizenjaChanged();
					}
					this.SendPropertySetterInvoked("HasPreknjizenja", value);
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
		#endregion dbo.viewBookkeepingFiduciaExport

		#region dbo.viewBookkeepingSynesisExport
		[TableAttribute(Name="dbo.viewBookkeepingSynesisExport")]
		public partial class viewBookkeepingSynesisExport : EntityBase<viewBookkeepingSynesisExport, dbArizonaAppDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private int _SynesisExportID;
			private DateTime _DatumGeneriranja;
			private int _BillFirmaID;
			private DateTime _StartDateIncluded;
			private DateTime _EndDateExcluded;
			private bool? _HasAllData;
			private bool? _HasKlijenti;
			private bool? _HasFinancKnjig;
			private bool? _HasUlazniRacuni;
			private bool? _HasIzlazniRacuni;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnSynesisExportIDChanging(int value);
			partial void OnSynesisExportIDChanged();
			partial void OnDatumGeneriranjaChanging(DateTime value);
			partial void OnDatumGeneriranjaChanged();
			partial void OnBillFirmaIDChanging(int value);
			partial void OnBillFirmaIDChanged();
			partial void OnStartDateIncludedChanging(DateTime value);
			partial void OnStartDateIncludedChanged();
			partial void OnEndDateExcludedChanging(DateTime value);
			partial void OnEndDateExcludedChanged();
			partial void OnHasAllDataChanging(bool? value);
			partial void OnHasAllDataChanged();
			partial void OnHasKlijentiChanging(bool? value);
			partial void OnHasKlijentiChanged();
			partial void OnHasFinancKnjigChanging(bool? value);
			partial void OnHasFinancKnjigChanged();
			partial void OnHasUlazniRacuniChanging(bool? value);
			partial void OnHasUlazniRacuniChanged();
			partial void OnHasIzlazniRacuniChanging(bool? value);
			partial void OnHasIzlazniRacuniChanged();
			#endregion

			public viewBookkeepingSynesisExport()
			{
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=Int NOT NULL IDENTITY
			/// </summary>
			[ColumnAttribute(Storage="_SynesisExportID", DbType="Int NOT NULL IDENTITY", CanBeNull=false)]
			public int SynesisExportID
			{
				get
				{
					return this._SynesisExportID;
				}
				set
				{
					if (this._SynesisExportID != value)
					{
						this.OnSynesisExportIDChanging(value);
						this.SendPropertyChanging();
						this._SynesisExportID = value;
						this.SendPropertyChanged("SynesisExportID");
						this.OnSynesisExportIDChanged();
					}
					this.SendPropertySetterInvoked("SynesisExportID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_DatumGeneriranja", DbType="DateTime NOT NULL", CanBeNull=false)]
			public DateTime DatumGeneriranja
			{
				get
				{
					return this._DatumGeneriranja;
				}
				set
				{
					if (this._DatumGeneriranja != value)
					{
						this.OnDatumGeneriranjaChanging(value);
						this.SendPropertyChanging();
						this._DatumGeneriranja = value;
						this.SendPropertyChanged("DatumGeneriranja");
						this.OnDatumGeneriranjaChanged();
					}
					this.SendPropertySetterInvoked("DatumGeneriranja", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Int NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_BillFirmaID", DbType="Int NOT NULL", CanBeNull=false)]
			public int BillFirmaID
			{
				get
				{
					return this._BillFirmaID;
				}
				set
				{
					if (this._BillFirmaID != value)
					{
						this.OnBillFirmaIDChanging(value);
						this.SendPropertyChanging();
						this._BillFirmaID = value;
						this.SendPropertyChanged("BillFirmaID");
						this.OnBillFirmaIDChanged();
					}
					this.SendPropertySetterInvoked("BillFirmaID", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_StartDateIncluded", DbType="DateTime NOT NULL", CanBeNull=false)]
			public DateTime StartDateIncluded
			{
				get
				{
					return this._StartDateIncluded;
				}
				set
				{
					if (this._StartDateIncluded != value)
					{
						this.OnStartDateIncludedChanging(value);
						this.SendPropertyChanging();
						this._StartDateIncluded = value;
						this.SendPropertyChanged("StartDateIncluded");
						this.OnStartDateIncludedChanged();
					}
					this.SendPropertySetterInvoked("StartDateIncluded", value);
				}
			}
			
			/// <summary>
			/// Column DbType=DateTime NOT NULL
			/// </summary>
			[ColumnAttribute(Storage="_EndDateExcluded", DbType="DateTime NOT NULL", CanBeNull=false)]
			public DateTime EndDateExcluded
			{
				get
				{
					return this._EndDateExcluded;
				}
				set
				{
					if (this._EndDateExcluded != value)
					{
						this.OnEndDateExcludedChanging(value);
						this.SendPropertyChanging();
						this._EndDateExcluded = value;
						this.SendPropertyChanged("EndDateExcluded");
						this.OnEndDateExcludedChanged();
					}
					this.SendPropertySetterInvoked("EndDateExcluded", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Bit
			/// </summary>
			[ColumnAttribute(Storage="_HasAllData", DbType="Bit", CanBeNull=true)]
			public bool? HasAllData
			{
				get
				{
					return this._HasAllData;
				}
				set
				{
					if (this._HasAllData != value)
					{
						this.OnHasAllDataChanging(value);
						this.SendPropertyChanging();
						this._HasAllData = value;
						this.SendPropertyChanged("HasAllData");
						this.OnHasAllDataChanged();
					}
					this.SendPropertySetterInvoked("HasAllData", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Bit
			/// </summary>
			[ColumnAttribute(Storage="_HasKlijenti", DbType="Bit", CanBeNull=true)]
			public bool? HasKlijenti
			{
				get
				{
					return this._HasKlijenti;
				}
				set
				{
					if (this._HasKlijenti != value)
					{
						this.OnHasKlijentiChanging(value);
						this.SendPropertyChanging();
						this._HasKlijenti = value;
						this.SendPropertyChanged("HasKlijenti");
						this.OnHasKlijentiChanged();
					}
					this.SendPropertySetterInvoked("HasKlijenti", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Bit
			/// </summary>
			[ColumnAttribute(Storage="_HasFinancKnjig", DbType="Bit", CanBeNull=true)]
			public bool? HasFinancKnjig
			{
				get
				{
					return this._HasFinancKnjig;
				}
				set
				{
					if (this._HasFinancKnjig != value)
					{
						this.OnHasFinancKnjigChanging(value);
						this.SendPropertyChanging();
						this._HasFinancKnjig = value;
						this.SendPropertyChanged("HasFinancKnjig");
						this.OnHasFinancKnjigChanged();
					}
					this.SendPropertySetterInvoked("HasFinancKnjig", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Bit
			/// </summary>
			[ColumnAttribute(Storage="_HasUlazniRacuni", DbType="Bit", CanBeNull=true)]
			public bool? HasUlazniRacuni
			{
				get
				{
					return this._HasUlazniRacuni;
				}
				set
				{
					if (this._HasUlazniRacuni != value)
					{
						this.OnHasUlazniRacuniChanging(value);
						this.SendPropertyChanging();
						this._HasUlazniRacuni = value;
						this.SendPropertyChanged("HasUlazniRacuni");
						this.OnHasUlazniRacuniChanged();
					}
					this.SendPropertySetterInvoked("HasUlazniRacuni", value);
				}
			}
			
			/// <summary>
			/// Column DbType=Bit
			/// </summary>
			[ColumnAttribute(Storage="_HasIzlazniRacuni", DbType="Bit", CanBeNull=true)]
			public bool? HasIzlazniRacuni
			{
				get
				{
					return this._HasIzlazniRacuni;
				}
				set
				{
					if (this._HasIzlazniRacuni != value)
					{
						this.OnHasIzlazniRacuniChanging(value);
						this.SendPropertyChanging();
						this._HasIzlazniRacuni = value;
						this.SendPropertyChanged("HasIzlazniRacuni");
						this.OnHasIzlazniRacuniChanged();
					}
					this.SendPropertySetterInvoked("HasIzlazniRacuni", value);
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
		#endregion dbo.viewBookkeepingSynesisExport

		#region dbo.viewRandom
		[TableAttribute(Name="dbo.viewRandom")]
		public partial class viewRandom : EntityBase<viewRandom, dbArizonaAppDataContext>, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked
		{
			private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

			#region Storage members
			private double? _Random;
			#endregion Storage members

			#region Extensibility Method Definitions
			partial void OnLoaded();
			partial void OnValidate(Calysto.Data.Linq.ChangeAction action);
			partial void OnCreated();
			partial void OnRandomChanging(double? value);
			partial void OnRandomChanged();
			#endregion

			public viewRandom()
			{
				OnCreated();
			}

			#region Columns
			/// <summary>
			/// Column DbType=Float
			/// </summary>
			[ColumnAttribute(Storage="_Random", DbType="Float", CanBeNull=true)]
			public double? Random
			{
				get
				{
					return this._Random;
				}
				set
				{
					if (this._Random != value)
					{
						this.OnRandomChanging(value);
						this.SendPropertyChanging();
						this._Random = value;
						this.SendPropertyChanged("Random");
						this.OnRandomChanged();
					}
					this.SendPropertySetterInvoked("Random", value);
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
		#endregion dbo.viewRandom


	#endregion Entity Tables

	#region Entity Return types

	#region fnCalculateBankaPrometOsnovicaAndPdvResult
	public partial class fnCalculateBankaPrometOsnovicaAndPdvResult
	{
		#region Storage members
		private decimal _PoreznaOsnovica;
		private decimal _PdvIznos;
		private decimal _PdvPosto;
		#endregion Storage members

		public fnCalculateBankaPrometOsnovicaAndPdvResult(){ }

		/// <summary>
		/// Column DbType=Money
		/// </summary>
		[ColumnAttribute(Storage="_PoreznaOsnovica", DbType="Money", CanBeNull=false)]
		public decimal PoreznaOsnovica
		{
			get
			{
				return this._PoreznaOsnovica;
			}
			set
			{
				if (this._PoreznaOsnovica != value)
				{
					this._PoreznaOsnovica = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Money
		/// </summary>
		[ColumnAttribute(Storage="_PdvIznos", DbType="Money", CanBeNull=false)]
		public decimal PdvIznos
		{
			get
			{
				return this._PdvIznos;
			}
			set
			{
				if (this._PdvIznos != value)
				{
					this._PdvIznos = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Money
		/// </summary>
		[ColumnAttribute(Storage="_PdvPosto", DbType="Money", CanBeNull=false)]
		public decimal PdvPosto
		{
			get
			{
				return this._PdvPosto;
			}
			set
			{
				if (this._PdvPosto != value)
				{
					this._PdvPosto = value;
				}
			}
		}
		
	}
	#endregion fnCalculateBankaPrometOsnovicaAndPdvResult

	#region fnCalculateDatumValuteRokPlacanjaResult
	public partial class fnCalculateDatumValuteRokPlacanjaResult
	{
		#region Storage members
		private DateTime _DatumDokumenta;
		private DateTime _DatumValute;
		private DateTime _DatumDospijeca;
		#endregion Storage members

		public fnCalculateDatumValuteRokPlacanjaResult(){ }

		/// <summary>
		/// Column DbType=DateTime
		/// </summary>
		[ColumnAttribute(Storage="_DatumDokumenta", DbType="DateTime", CanBeNull=false)]
		public DateTime DatumDokumenta
		{
			get
			{
				return this._DatumDokumenta;
			}
			set
			{
				if (this._DatumDokumenta != value)
				{
					this._DatumDokumenta = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=DateTime
		/// </summary>
		[ColumnAttribute(Storage="_DatumValute", DbType="DateTime", CanBeNull=false)]
		public DateTime DatumValute
		{
			get
			{
				return this._DatumValute;
			}
			set
			{
				if (this._DatumValute != value)
				{
					this._DatumValute = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=DateTime
		/// </summary>
		[ColumnAttribute(Storage="_DatumDospijeca", DbType="DateTime", CanBeNull=false)]
		public DateTime DatumDospijeca
		{
			get
			{
				return this._DatumDospijeca;
			}
			set
			{
				if (this._DatumDospijeca != value)
				{
					this._DatumDospijeca = value;
				}
			}
		}
		
	}
	#endregion fnCalculateDatumValuteRokPlacanjaResult

	#region fnCalculateDocumentNaknadeResult
	public partial class fnCalculateDocumentNaknadeResult
	{
		#region Storage members
		private string _NaknadaNaziv;
		private double _IznosNaknade;
		#endregion Storage members

		public fnCalculateDocumentNaknadeResult(){ }

		/// <summary>
		/// Column DbType=NVarChar(50)
		/// </summary>
		[ColumnAttribute(Storage="_NaknadaNaziv", DbType="NVarChar(50)", CanBeNull=false)]
		public string NaknadaNaziv
		{
			get
			{
				return this._NaknadaNaziv;
			}
			set
			{
				if (this._NaknadaNaziv != value)
				{
					this._NaknadaNaziv = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Float
		/// </summary>
		[ColumnAttribute(Storage="_IznosNaknade", DbType="Float", CanBeNull=false)]
		public double IznosNaknade
		{
			get
			{
				return this._IznosNaknade;
			}
			set
			{
				if (this._IznosNaknade != value)
				{
					this._IznosNaknade = value;
				}
			}
		}
		
	}
	#endregion fnCalculateDocumentNaknadeResult

	#region fnCalculateDocumentPorezOstaliResult
	public partial class fnCalculateDocumentPorezOstaliResult
	{
		#region Storage members
		private string _PorezNaziv;
		private string _PorezDesc;
		private double _PostotakPoreza;
		private double _SumPoreznaOsnovica;
		private double _SumIznosPoreza;
		#endregion Storage members

		public fnCalculateDocumentPorezOstaliResult(){ }

		/// <summary>
		/// Column DbType=NVarChar(50)
		/// </summary>
		[ColumnAttribute(Storage="_PorezNaziv", DbType="NVarChar(50)", CanBeNull=false)]
		public string PorezNaziv
		{
			get
			{
				return this._PorezNaziv;
			}
			set
			{
				if (this._PorezNaziv != value)
				{
					this._PorezNaziv = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=NVarChar(82)
		/// </summary>
		[ColumnAttribute(Storage="_PorezDesc", DbType="NVarChar(82)", CanBeNull=true)]
		public string PorezDesc
		{
			get
			{
				return this._PorezDesc;
			}
			set
			{
				if (this._PorezDesc != value)
				{
					this._PorezDesc = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Float
		/// </summary>
		[ColumnAttribute(Storage="_PostotakPoreza", DbType="Float", CanBeNull=false)]
		public double PostotakPoreza
		{
			get
			{
				return this._PostotakPoreza;
			}
			set
			{
				if (this._PostotakPoreza != value)
				{
					this._PostotakPoreza = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Float
		/// </summary>
		[ColumnAttribute(Storage="_SumPoreznaOsnovica", DbType="Float", CanBeNull=false)]
		public double SumPoreznaOsnovica
		{
			get
			{
				return this._SumPoreznaOsnovica;
			}
			set
			{
				if (this._SumPoreznaOsnovica != value)
				{
					this._SumPoreznaOsnovica = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Float
		/// </summary>
		[ColumnAttribute(Storage="_SumIznosPoreza", DbType="Float", CanBeNull=false)]
		public double SumIznosPoreza
		{
			get
			{
				return this._SumIznosPoreza;
			}
			set
			{
				if (this._SumIznosPoreza != value)
				{
					this._SumIznosPoreza = value;
				}
			}
		}
		
	}
	#endregion fnCalculateDocumentPorezOstaliResult

	#region fnCalculateDocumentPorezPdvResult
	public partial class fnCalculateDocumentPorezPdvResult
	{
		#region Storage members
		private string _PorezNaziv;
		private string _PorezDesc;
		private double _PostotakPoreza;
		private double _SumPoreznaOsnovica;
		private double _SumIznosPoreza;
		#endregion Storage members

		public fnCalculateDocumentPorezPdvResult(){ }

		/// <summary>
		/// Column DbType=VarChar(3)
		/// </summary>
		[ColumnAttribute(Storage="_PorezNaziv", DbType="VarChar(3)", CanBeNull=false)]
		public string PorezNaziv
		{
			get
			{
				return this._PorezNaziv;
			}
			set
			{
				if (this._PorezNaziv != value)
				{
					this._PorezNaziv = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=VarChar(35)
		/// </summary>
		[ColumnAttribute(Storage="_PorezDesc", DbType="VarChar(35)", CanBeNull=true)]
		public string PorezDesc
		{
			get
			{
				return this._PorezDesc;
			}
			set
			{
				if (this._PorezDesc != value)
				{
					this._PorezDesc = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Float
		/// </summary>
		[ColumnAttribute(Storage="_PostotakPoreza", DbType="Float", CanBeNull=false)]
		public double PostotakPoreza
		{
			get
			{
				return this._PostotakPoreza;
			}
			set
			{
				if (this._PostotakPoreza != value)
				{
					this._PostotakPoreza = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Float
		/// </summary>
		[ColumnAttribute(Storage="_SumPoreznaOsnovica", DbType="Float", CanBeNull=false)]
		public double SumPoreznaOsnovica
		{
			get
			{
				return this._SumPoreznaOsnovica;
			}
			set
			{
				if (this._SumPoreznaOsnovica != value)
				{
					this._SumPoreznaOsnovica = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Float
		/// </summary>
		[ColumnAttribute(Storage="_SumIznosPoreza", DbType="Float", CanBeNull=false)]
		public double SumIznosPoreza
		{
			get
			{
				return this._SumIznosPoreza;
			}
			set
			{
				if (this._SumIznosPoreza != value)
				{
					this._SumIznosPoreza = value;
				}
			}
		}
		
	}
	#endregion fnCalculateDocumentPorezPdvResult

	#region fnCalculateDocumentPorezPotrosnjaResult
	public partial class fnCalculateDocumentPorezPotrosnjaResult
	{
		#region Storage members
		private string _PorezNaziv;
		private string _PorezDesc;
		private double _PostotakPoreza;
		private double _SumPoreznaOsnovica;
		private double _SumIznosPoreza;
		#endregion Storage members

		public fnCalculateDocumentPorezPotrosnjaResult(){ }

		/// <summary>
		/// Column DbType=VarChar(3)
		/// </summary>
		[ColumnAttribute(Storage="_PorezNaziv", DbType="VarChar(3)", CanBeNull=false)]
		public string PorezNaziv
		{
			get
			{
				return this._PorezNaziv;
			}
			set
			{
				if (this._PorezNaziv != value)
				{
					this._PorezNaziv = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=VarChar(35)
		/// </summary>
		[ColumnAttribute(Storage="_PorezDesc", DbType="VarChar(35)", CanBeNull=true)]
		public string PorezDesc
		{
			get
			{
				return this._PorezDesc;
			}
			set
			{
				if (this._PorezDesc != value)
				{
					this._PorezDesc = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Float
		/// </summary>
		[ColumnAttribute(Storage="_PostotakPoreza", DbType="Float", CanBeNull=false)]
		public double PostotakPoreza
		{
			get
			{
				return this._PostotakPoreza;
			}
			set
			{
				if (this._PostotakPoreza != value)
				{
					this._PostotakPoreza = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Float
		/// </summary>
		[ColumnAttribute(Storage="_SumPoreznaOsnovica", DbType="Float", CanBeNull=false)]
		public double SumPoreznaOsnovica
		{
			get
			{
				return this._SumPoreznaOsnovica;
			}
			set
			{
				if (this._SumPoreznaOsnovica != value)
				{
					this._SumPoreznaOsnovica = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Float
		/// </summary>
		[ColumnAttribute(Storage="_SumIznosPoreza", DbType="Float", CanBeNull=false)]
		public double SumIznosPoreza
		{
			get
			{
				return this._SumIznosPoreza;
			}
			set
			{
				if (this._SumIznosPoreza != value)
				{
					this._SumIznosPoreza = value;
				}
			}
		}
		
	}
	#endregion fnCalculateDocumentPorezPotrosnjaResult

	#region fnCalculateDocumentStavkeResult
	public partial class fnCalculateDocumentStavkeResult
	{
		#region Storage members
		private long _BillDocumentStavkaID;
		private long _BillDocumentID;
		private long _BillProductID;
		private string _ProductNaziv;
		private decimal _JedinicnaCijena;
		private bool _CijenaJeMPC;
		private int _BillMjeraID;
		private double _Kolicina;
		private decimal _PopustPosto;
		private long _BillPoreznaGrupaID;
		private string _PoreznaGrupaNaziv;
		private string _NaknadaNaziv;
		private string _OstaliPorezNaziv;
		private double _JedinicnaVPC;
		private double _JedinicnaMPC;
		private double _VPCsPopustom;
		private double _MPCsPopustom;
		private double _SumPoreznaOsnovica;
		private double _PdvPosto;
		private bool _UPdvSustavu;
		private double _SumIznosPdva;
		private double _PorezPotrosnjaPosto;
		private double _SumIznosPorezPotrosnja;
		private double _OstaliPorezPosto;
		private double _SumIznosOstaliPorez;
		private double _SumIznosNaknade;
		private double _SumVPCsPopustom;
		private double _SumMPCsPopustom;
		#endregion Storage members

		public fnCalculateDocumentStavkeResult(){ }

		/// <summary>
		/// Column DbType=BigInt
		/// </summary>
		[ColumnAttribute(Storage="_BillDocumentStavkaID", DbType="BigInt", CanBeNull=false)]
		public long BillDocumentStavkaID
		{
			get
			{
				return this._BillDocumentStavkaID;
			}
			set
			{
				if (this._BillDocumentStavkaID != value)
				{
					this._BillDocumentStavkaID = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=BigInt
		/// </summary>
		[ColumnAttribute(Storage="_BillDocumentID", DbType="BigInt", CanBeNull=false)]
		public long BillDocumentID
		{
			get
			{
				return this._BillDocumentID;
			}
			set
			{
				if (this._BillDocumentID != value)
				{
					this._BillDocumentID = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=BigInt
		/// </summary>
		[ColumnAttribute(Storage="_BillProductID", DbType="BigInt", CanBeNull=false)]
		public long BillProductID
		{
			get
			{
				return this._BillProductID;
			}
			set
			{
				if (this._BillProductID != value)
				{
					this._BillProductID = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=NVarChar(150)
		/// </summary>
		[ColumnAttribute(Storage="_ProductNaziv", DbType="NVarChar(150)", CanBeNull=false)]
		public string ProductNaziv
		{
			get
			{
				return this._ProductNaziv;
			}
			set
			{
				if (this._ProductNaziv != value)
				{
					this._ProductNaziv = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Money
		/// </summary>
		[ColumnAttribute(Storage="_JedinicnaCijena", DbType="Money", CanBeNull=false)]
		public decimal JedinicnaCijena
		{
			get
			{
				return this._JedinicnaCijena;
			}
			set
			{
				if (this._JedinicnaCijena != value)
				{
					this._JedinicnaCijena = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Bit
		/// </summary>
		[ColumnAttribute(Storage="_CijenaJeMPC", DbType="Bit", CanBeNull=false)]
		public bool CijenaJeMPC
		{
			get
			{
				return this._CijenaJeMPC;
			}
			set
			{
				if (this._CijenaJeMPC != value)
				{
					this._CijenaJeMPC = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Int
		/// </summary>
		[ColumnAttribute(Storage="_BillMjeraID", DbType="Int", CanBeNull=false)]
		public int BillMjeraID
		{
			get
			{
				return this._BillMjeraID;
			}
			set
			{
				if (this._BillMjeraID != value)
				{
					this._BillMjeraID = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Float
		/// </summary>
		[ColumnAttribute(Storage="_Kolicina", DbType="Float", CanBeNull=false)]
		public double Kolicina
		{
			get
			{
				return this._Kolicina;
			}
			set
			{
				if (this._Kolicina != value)
				{
					this._Kolicina = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Money
		/// </summary>
		[ColumnAttribute(Storage="_PopustPosto", DbType="Money", CanBeNull=false)]
		public decimal PopustPosto
		{
			get
			{
				return this._PopustPosto;
			}
			set
			{
				if (this._PopustPosto != value)
				{
					this._PopustPosto = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=BigInt
		/// </summary>
		[ColumnAttribute(Storage="_BillPoreznaGrupaID", DbType="BigInt", CanBeNull=false)]
		public long BillPoreznaGrupaID
		{
			get
			{
				return this._BillPoreznaGrupaID;
			}
			set
			{
				if (this._BillPoreznaGrupaID != value)
				{
					this._BillPoreznaGrupaID = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=NVarChar(100)
		/// </summary>
		[ColumnAttribute(Storage="_PoreznaGrupaNaziv", DbType="NVarChar(100)", CanBeNull=false)]
		public string PoreznaGrupaNaziv
		{
			get
			{
				return this._PoreznaGrupaNaziv;
			}
			set
			{
				if (this._PoreznaGrupaNaziv != value)
				{
					this._PoreznaGrupaNaziv = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=NVarChar(50)
		/// </summary>
		[ColumnAttribute(Storage="_NaknadaNaziv", DbType="NVarChar(50)", CanBeNull=true)]
		public string NaknadaNaziv
		{
			get
			{
				return this._NaknadaNaziv;
			}
			set
			{
				if (this._NaknadaNaziv != value)
				{
					this._NaknadaNaziv = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=NVarChar(50)
		/// </summary>
		[ColumnAttribute(Storage="_OstaliPorezNaziv", DbType="NVarChar(50)", CanBeNull=true)]
		public string OstaliPorezNaziv
		{
			get
			{
				return this._OstaliPorezNaziv;
			}
			set
			{
				if (this._OstaliPorezNaziv != value)
				{
					this._OstaliPorezNaziv = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Float
		/// </summary>
		[ColumnAttribute(Storage="_JedinicnaVPC", DbType="Float", CanBeNull=false)]
		public double JedinicnaVPC
		{
			get
			{
				return this._JedinicnaVPC;
			}
			set
			{
				if (this._JedinicnaVPC != value)
				{
					this._JedinicnaVPC = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Float
		/// </summary>
		[ColumnAttribute(Storage="_JedinicnaMPC", DbType="Float", CanBeNull=false)]
		public double JedinicnaMPC
		{
			get
			{
				return this._JedinicnaMPC;
			}
			set
			{
				if (this._JedinicnaMPC != value)
				{
					this._JedinicnaMPC = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Float
		/// </summary>
		[ColumnAttribute(Storage="_VPCsPopustom", DbType="Float", CanBeNull=false)]
		public double VPCsPopustom
		{
			get
			{
				return this._VPCsPopustom;
			}
			set
			{
				if (this._VPCsPopustom != value)
				{
					this._VPCsPopustom = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Float
		/// </summary>
		[ColumnAttribute(Storage="_MPCsPopustom", DbType="Float", CanBeNull=false)]
		public double MPCsPopustom
		{
			get
			{
				return this._MPCsPopustom;
			}
			set
			{
				if (this._MPCsPopustom != value)
				{
					this._MPCsPopustom = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Float
		/// </summary>
		[ColumnAttribute(Storage="_SumPoreznaOsnovica", DbType="Float", CanBeNull=false)]
		public double SumPoreznaOsnovica
		{
			get
			{
				return this._SumPoreznaOsnovica;
			}
			set
			{
				if (this._SumPoreznaOsnovica != value)
				{
					this._SumPoreznaOsnovica = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Float
		/// </summary>
		[ColumnAttribute(Storage="_PdvPosto", DbType="Float", CanBeNull=false)]
		public double PdvPosto
		{
			get
			{
				return this._PdvPosto;
			}
			set
			{
				if (this._PdvPosto != value)
				{
					this._PdvPosto = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Bit
		/// </summary>
		[ColumnAttribute(Storage="_UPdvSustavu", DbType="Bit", CanBeNull=false)]
		public bool UPdvSustavu
		{
			get
			{
				return this._UPdvSustavu;
			}
			set
			{
				if (this._UPdvSustavu != value)
				{
					this._UPdvSustavu = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Float
		/// </summary>
		[ColumnAttribute(Storage="_SumIznosPdva", DbType="Float", CanBeNull=false)]
		public double SumIznosPdva
		{
			get
			{
				return this._SumIznosPdva;
			}
			set
			{
				if (this._SumIznosPdva != value)
				{
					this._SumIznosPdva = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Float
		/// </summary>
		[ColumnAttribute(Storage="_PorezPotrosnjaPosto", DbType="Float", CanBeNull=false)]
		public double PorezPotrosnjaPosto
		{
			get
			{
				return this._PorezPotrosnjaPosto;
			}
			set
			{
				if (this._PorezPotrosnjaPosto != value)
				{
					this._PorezPotrosnjaPosto = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Float
		/// </summary>
		[ColumnAttribute(Storage="_SumIznosPorezPotrosnja", DbType="Float", CanBeNull=false)]
		public double SumIznosPorezPotrosnja
		{
			get
			{
				return this._SumIznosPorezPotrosnja;
			}
			set
			{
				if (this._SumIznosPorezPotrosnja != value)
				{
					this._SumIznosPorezPotrosnja = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Float
		/// </summary>
		[ColumnAttribute(Storage="_OstaliPorezPosto", DbType="Float", CanBeNull=false)]
		public double OstaliPorezPosto
		{
			get
			{
				return this._OstaliPorezPosto;
			}
			set
			{
				if (this._OstaliPorezPosto != value)
				{
					this._OstaliPorezPosto = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Float
		/// </summary>
		[ColumnAttribute(Storage="_SumIznosOstaliPorez", DbType="Float", CanBeNull=false)]
		public double SumIznosOstaliPorez
		{
			get
			{
				return this._SumIznosOstaliPorez;
			}
			set
			{
				if (this._SumIznosOstaliPorez != value)
				{
					this._SumIznosOstaliPorez = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Float
		/// </summary>
		[ColumnAttribute(Storage="_SumIznosNaknade", DbType="Float", CanBeNull=false)]
		public double SumIznosNaknade
		{
			get
			{
				return this._SumIznosNaknade;
			}
			set
			{
				if (this._SumIznosNaknade != value)
				{
					this._SumIznosNaknade = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Float
		/// </summary>
		[ColumnAttribute(Storage="_SumVPCsPopustom", DbType="Float", CanBeNull=false)]
		public double SumVPCsPopustom
		{
			get
			{
				return this._SumVPCsPopustom;
			}
			set
			{
				if (this._SumVPCsPopustom != value)
				{
					this._SumVPCsPopustom = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Float
		/// </summary>
		[ColumnAttribute(Storage="_SumMPCsPopustom", DbType="Float", CanBeNull=false)]
		public double SumMPCsPopustom
		{
			get
			{
				return this._SumMPCsPopustom;
			}
			set
			{
				if (this._SumMPCsPopustom != value)
				{
					this._SumMPCsPopustom = value;
				}
			}
		}
		
	}
	#endregion fnCalculateDocumentStavkeResult

	#region fnCalculateDocumentTotalsResult
	public partial class fnCalculateDocumentTotalsResult
	{
		#region Storage members
		private long _BillDocumentID;
		private double _SumPoreznaOsnovica;
		private double _SumIznosPdva;
		private double _SumIznosPorezPotrosnja;
		private double _SumIznosOstaliPorez;
		private double _SumUkupno;
		#endregion Storage members

		public fnCalculateDocumentTotalsResult(){ }

		/// <summary>
		/// Column DbType=BigInt
		/// </summary>
		[ColumnAttribute(Storage="_BillDocumentID", DbType="BigInt", CanBeNull=false)]
		public long BillDocumentID
		{
			get
			{
				return this._BillDocumentID;
			}
			set
			{
				if (this._BillDocumentID != value)
				{
					this._BillDocumentID = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Float
		/// </summary>
		[ColumnAttribute(Storage="_SumPoreznaOsnovica", DbType="Float", CanBeNull=false)]
		public double SumPoreznaOsnovica
		{
			get
			{
				return this._SumPoreznaOsnovica;
			}
			set
			{
				if (this._SumPoreznaOsnovica != value)
				{
					this._SumPoreznaOsnovica = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Float
		/// </summary>
		[ColumnAttribute(Storage="_SumIznosPdva", DbType="Float", CanBeNull=false)]
		public double SumIznosPdva
		{
			get
			{
				return this._SumIznosPdva;
			}
			set
			{
				if (this._SumIznosPdva != value)
				{
					this._SumIznosPdva = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Float
		/// </summary>
		[ColumnAttribute(Storage="_SumIznosPorezPotrosnja", DbType="Float", CanBeNull=false)]
		public double SumIznosPorezPotrosnja
		{
			get
			{
				return this._SumIznosPorezPotrosnja;
			}
			set
			{
				if (this._SumIznosPorezPotrosnja != value)
				{
					this._SumIznosPorezPotrosnja = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Float
		/// </summary>
		[ColumnAttribute(Storage="_SumIznosOstaliPorez", DbType="Float", CanBeNull=false)]
		public double SumIznosOstaliPorez
		{
			get
			{
				return this._SumIznosOstaliPorez;
			}
			set
			{
				if (this._SumIznosOstaliPorez != value)
				{
					this._SumIznosOstaliPorez = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Float
		/// </summary>
		[ColumnAttribute(Storage="_SumUkupno", DbType="Float", CanBeNull=false)]
		public double SumUkupno
		{
			get
			{
				return this._SumUkupno;
			}
			set
			{
				if (this._SumUkupno != value)
				{
					this._SumUkupno = value;
				}
			}
		}
		
	}
	#endregion fnCalculateDocumentTotalsResult

	#region fnCLRCsvArgsToIntTableResult
	public partial class fnCLRCsvArgsToIntTableResult
	{
		#region Storage members
		private long? _part;
		#endregion Storage members

		public fnCLRCsvArgsToIntTableResult(){ }

		/// <summary>
		/// Column DbType=BigInt
		/// </summary>
		[ColumnAttribute(Storage="_part", DbType="BigInt", CanBeNull=true)]
		public long? part
		{
			get
			{
				return this._part;
			}
			set
			{
				if (this._part != value)
				{
					this._part = value;
				}
			}
		}
		
	}
	#endregion fnCLRCsvArgsToIntTableResult

	#region fnCLRCsvArgsToWordsTableResult
	public partial class fnCLRCsvArgsToWordsTableResult
	{
		#region Storage members
		private string _part;
		#endregion Storage members

		public fnCLRCsvArgsToWordsTableResult(){ }

		/// <summary>
		/// Column DbType=NVarChar(MAX)
		/// </summary>
		[ColumnAttribute(Storage="_part", DbType="NVarChar(MAX)", CanBeNull=true)]
		public string part
		{
			get
			{
				return this._part;
			}
			set
			{
				if (this._part != value)
				{
					this._part = value;
				}
			}
		}
		
	}
	#endregion fnCLRCsvArgsToWordsTableResult

	#region fnCLRSplitStringByPatternResult
	public partial class fnCLRSplitStringByPatternResult
	{
		#region Storage members
		private int? _position;
		private string _part;
		#endregion Storage members

		public fnCLRSplitStringByPatternResult(){ }

		/// <summary>
		/// Column DbType=Int
		/// </summary>
		[ColumnAttribute(Storage="_position", DbType="Int", CanBeNull=true)]
		public int? position
		{
			get
			{
				return this._position;
			}
			set
			{
				if (this._position != value)
				{
					this._position = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=NVarChar(MAX)
		/// </summary>
		[ColumnAttribute(Storage="_part", DbType="NVarChar(MAX)", CanBeNull=true)]
		public string part
		{
			get
			{
				return this._part;
			}
			set
			{
				if (this._part != value)
				{
					this._part = value;
				}
			}
		}
		
	}
	#endregion fnCLRSplitStringByPatternResult

	#region fnCLRSplitStringToDistinctWordsResult
	public partial class fnCLRSplitStringToDistinctWordsResult
	{
		#region Storage members
		private int? _position;
		private string _part;
		#endregion Storage members

		public fnCLRSplitStringToDistinctWordsResult(){ }

		/// <summary>
		/// Column DbType=Int
		/// </summary>
		[ColumnAttribute(Storage="_position", DbType="Int", CanBeNull=true)]
		public int? position
		{
			get
			{
				return this._position;
			}
			set
			{
				if (this._position != value)
				{
					this._position = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=NVarChar(MAX)
		/// </summary>
		[ColumnAttribute(Storage="_part", DbType="NVarChar(MAX)", CanBeNull=true)]
		public string part
		{
			get
			{
				return this._part;
			}
			set
			{
				if (this._part != value)
				{
					this._part = value;
				}
			}
		}
		
	}
	#endregion fnCLRSplitStringToDistinctWordsResult

	#region fnCLRSplitStringToWordsResult
	public partial class fnCLRSplitStringToWordsResult
	{
		#region Storage members
		private int? _position;
		private string _part;
		#endregion Storage members

		public fnCLRSplitStringToWordsResult(){ }

		/// <summary>
		/// Column DbType=Int
		/// </summary>
		[ColumnAttribute(Storage="_position", DbType="Int", CanBeNull=true)]
		public int? position
		{
			get
			{
				return this._position;
			}
			set
			{
				if (this._position != value)
				{
					this._position = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=NVarChar(MAX)
		/// </summary>
		[ColumnAttribute(Storage="_part", DbType="NVarChar(MAX)", CanBeNull=true)]
		public string part
		{
			get
			{
				return this._part;
			}
			set
			{
				if (this._part != value)
				{
					this._part = value;
				}
			}
		}
		
	}
	#endregion fnCLRSplitStringToWordsResult

	#region fnConvertCsvArgsToIntTableResult
	public partial class fnConvertCsvArgsToIntTableResult
	{
		#region Storage members
		private long _number;
		#endregion Storage members

		public fnConvertCsvArgsToIntTableResult(){ }

		/// <summary>
		/// Column DbType=BigInt
		/// </summary>
		[ColumnAttribute(Storage="_number", DbType="BigInt", CanBeNull=false)]
		public long number
		{
			get
			{
				return this._number;
			}
			set
			{
				if (this._number != value)
				{
					this._number = value;
				}
			}
		}
		
	}
	#endregion fnConvertCsvArgsToIntTableResult

	#region fnConvertCsvArgsToWordsTableResult
	public partial class fnConvertCsvArgsToWordsTableResult
	{
		#region Storage members
		private string _word;
		#endregion Storage members

		public fnConvertCsvArgsToWordsTableResult(){ }

		/// <summary>
		/// Column DbType=NVarChar(MAX)
		/// </summary>
		[ColumnAttribute(Storage="_word", DbType="NVarChar(MAX)", CanBeNull=true)]
		public string word
		{
			get
			{
				return this._word;
			}
			set
			{
				if (this._word != value)
				{
					this._word = value;
				}
			}
		}
		
	}
	#endregion fnConvertCsvArgsToWordsTableResult

	#region fnGetBankaPrometVrsteResult
	public partial class fnGetBankaPrometVrsteResult
	{
		#region Storage members
		private int _BankaPrometVrstaID;
		private string _Name;
		private bool _IsPrihod;
		private bool _IsRashod;
		private string _PrometVrstaName;
		#endregion Storage members

		public fnGetBankaPrometVrsteResult(){ }

		/// <summary>
		/// Column DbType=Int
		/// </summary>
		[ColumnAttribute(Storage="_BankaPrometVrstaID", DbType="Int", CanBeNull=false)]
		public int BankaPrometVrstaID
		{
			get
			{
				return this._BankaPrometVrstaID;
			}
			set
			{
				if (this._BankaPrometVrstaID != value)
				{
					this._BankaPrometVrstaID = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=NVarChar(150)
		/// </summary>
		[ColumnAttribute(Storage="_Name", DbType="NVarChar(150)", CanBeNull=false)]
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
		/// Column DbType=Bit
		/// </summary>
		[ColumnAttribute(Storage="_IsPrihod", DbType="Bit", CanBeNull=false)]
		public bool IsPrihod
		{
			get
			{
				return this._IsPrihod;
			}
			set
			{
				if (this._IsPrihod != value)
				{
					this._IsPrihod = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Bit
		/// </summary>
		[ColumnAttribute(Storage="_IsRashod", DbType="Bit", CanBeNull=false)]
		public bool IsRashod
		{
			get
			{
				return this._IsRashod;
			}
			set
			{
				if (this._IsRashod != value)
				{
					this._IsRashod = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=NVarChar(100)
		/// </summary>
		[ColumnAttribute(Storage="_PrometVrstaName", DbType="NVarChar(100)", CanBeNull=true)]
		public string PrometVrstaName
		{
			get
			{
				return this._PrometVrstaName;
			}
			set
			{
				if (this._PrometVrstaName != value)
				{
					this._PrometVrstaName = value;
				}
			}
		}
		
	}
	#endregion fnGetBankaPrometVrsteResult

	#region fnGetBankaPrometVrsteDatumaResult
	public partial class fnGetBankaPrometVrsteDatumaResult
	{
		#region Storage members
		private string _Naziv;
		private int _Vrijednost;
		#endregion Storage members

		public fnGetBankaPrometVrsteDatumaResult(){ }

		/// <summary>
		/// Column DbType=VarChar(16)
		/// </summary>
		[ColumnAttribute(Storage="_Naziv", DbType="VarChar(16)", CanBeNull=false)]
		public string Naziv
		{
			get
			{
				return this._Naziv;
			}
			set
			{
				if (this._Naziv != value)
				{
					this._Naziv = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Int
		/// </summary>
		[ColumnAttribute(Storage="_Vrijednost", DbType="Int", CanBeNull=false)]
		public int Vrijednost
		{
			get
			{
				return this._Vrijednost;
			}
			set
			{
				if (this._Vrijednost != value)
				{
					this._Vrijednost = value;
				}
			}
		}
		
	}
	#endregion fnGetBankaPrometVrsteDatumaResult

	#region fnGetBillClientsFromPoziviNaBrojResult
	public partial class fnGetBillClientsFromPoziviNaBrojResult
	{
		#region Storage members
		private long _BillClientID;
		#endregion Storage members

		public fnGetBillClientsFromPoziviNaBrojResult(){ }

		/// <summary>
		/// Column DbType=BigInt
		/// </summary>
		[ColumnAttribute(Storage="_BillClientID", DbType="BigInt", CanBeNull=false)]
		public long BillClientID
		{
			get
			{
				return this._BillClientID;
			}
			set
			{
				if (this._BillClientID != value)
				{
					this._BillClientID = value;
				}
			}
		}
		
	}
	#endregion fnGetBillClientsFromPoziviNaBrojResult

	#region fnGetBillClientUplateResult
	public partial class fnGetBillClientUplateResult
	{
		#region Storage members
		private long _BillDocumentID;
		private string _PozivNaBroj;
		private int _BillDocumentTipID;
		private bool _IsRacunType;
		private long _BillClientID;
		private decimal? _IznosDokumenta;
		private int? _BankaPrometID;
		private DateTime? _BankaDatumTransakcije;
		private decimal? _BankaUplata;
		private decimal? _BankaIsplata;
		#endregion Storage members

		public fnGetBillClientUplateResult(){ }

		/// <summary>
		/// Column DbType=BigInt
		/// </summary>
		[ColumnAttribute(Storage="_BillDocumentID", DbType="BigInt", CanBeNull=false)]
		public long BillDocumentID
		{
			get
			{
				return this._BillDocumentID;
			}
			set
			{
				if (this._BillDocumentID != value)
				{
					this._BillDocumentID = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=VarChar(50)
		/// </summary>
		[ColumnAttribute(Storage="_PozivNaBroj", DbType="VarChar(50)", CanBeNull=false)]
		public string PozivNaBroj
		{
			get
			{
				return this._PozivNaBroj;
			}
			set
			{
				if (this._PozivNaBroj != value)
				{
					this._PozivNaBroj = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Int
		/// </summary>
		[ColumnAttribute(Storage="_BillDocumentTipID", DbType="Int", CanBeNull=false)]
		public int BillDocumentTipID
		{
			get
			{
				return this._BillDocumentTipID;
			}
			set
			{
				if (this._BillDocumentTipID != value)
				{
					this._BillDocumentTipID = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Bit
		/// </summary>
		[ColumnAttribute(Storage="_IsRacunType", DbType="Bit", CanBeNull=false)]
		public bool IsRacunType
		{
			get
			{
				return this._IsRacunType;
			}
			set
			{
				if (this._IsRacunType != value)
				{
					this._IsRacunType = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=BigInt
		/// </summary>
		[ColumnAttribute(Storage="_BillClientID", DbType="BigInt", CanBeNull=false)]
		public long BillClientID
		{
			get
			{
				return this._BillClientID;
			}
			set
			{
				if (this._BillClientID != value)
				{
					this._BillClientID = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Decimal(18,8)
		/// </summary>
		[ColumnAttribute(Storage="_IznosDokumenta", DbType="Decimal(18,8)", CanBeNull=true)]
		public decimal? IznosDokumenta
		{
			get
			{
				return this._IznosDokumenta;
			}
			set
			{
				if (this._IznosDokumenta != value)
				{
					this._IznosDokumenta = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Int
		/// </summary>
		[ColumnAttribute(Storage="_BankaPrometID", DbType="Int", CanBeNull=true)]
		public int? BankaPrometID
		{
			get
			{
				return this._BankaPrometID;
			}
			set
			{
				if (this._BankaPrometID != value)
				{
					this._BankaPrometID = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=DateTime
		/// </summary>
		[ColumnAttribute(Storage="_BankaDatumTransakcije", DbType="DateTime", CanBeNull=true)]
		public DateTime? BankaDatumTransakcije
		{
			get
			{
				return this._BankaDatumTransakcije;
			}
			set
			{
				if (this._BankaDatumTransakcije != value)
				{
					this._BankaDatumTransakcije = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Money
		/// </summary>
		[ColumnAttribute(Storage="_BankaUplata", DbType="Money", CanBeNull=true)]
		public decimal? BankaUplata
		{
			get
			{
				return this._BankaUplata;
			}
			set
			{
				if (this._BankaUplata != value)
				{
					this._BankaUplata = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Money
		/// </summary>
		[ColumnAttribute(Storage="_BankaIsplata", DbType="Money", CanBeNull=true)]
		public decimal? BankaIsplata
		{
			get
			{
				return this._BankaIsplata;
			}
			set
			{
				if (this._BankaIsplata != value)
				{
					this._BankaIsplata = value;
				}
			}
		}
		
	}
	#endregion fnGetBillClientUplateResult

	#region fnGetDbPairNamesResult
	public partial class fnGetDbPairNamesResult
	{
		#region Storage members
		private string _CurrentDatabase;
		private string _AppDatabase;
		private string _PosDatabase;
		#endregion Storage members

		public fnGetDbPairNamesResult(){ }

		/// <summary>
		/// Column DbType=VarChar(100)
		/// </summary>
		[ColumnAttribute(Storage="_CurrentDatabase", DbType="VarChar(100)", CanBeNull=true)]
		public string CurrentDatabase
		{
			get
			{
				return this._CurrentDatabase;
			}
			set
			{
				if (this._CurrentDatabase != value)
				{
					this._CurrentDatabase = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=VarChar(100)
		/// </summary>
		[ColumnAttribute(Storage="_AppDatabase", DbType="VarChar(100)", CanBeNull=true)]
		public string AppDatabase
		{
			get
			{
				return this._AppDatabase;
			}
			set
			{
				if (this._AppDatabase != value)
				{
					this._AppDatabase = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=VarChar(100)
		/// </summary>
		[ColumnAttribute(Storage="_PosDatabase", DbType="VarChar(100)", CanBeNull=true)]
		public string PosDatabase
		{
			get
			{
				return this._PosDatabase;
			}
			set
			{
				if (this._PosDatabase != value)
				{
					this._PosDatabase = value;
				}
			}
		}
		
	}
	#endregion fnGetDbPairNamesResult

	#region fnGetMonthStartEndResult
	public partial class fnGetMonthStartEndResult
	{
		#region Storage members
		private DateTime? _InputDate;
		private DateTime? _FirstDate;
		private DateTime? _LastDate;
		private int? _DaysInMonth;
		#endregion Storage members

		public fnGetMonthStartEndResult(){ }

		/// <summary>
		/// Column DbType=DateTime
		/// </summary>
		[ColumnAttribute(Storage="_InputDate", DbType="DateTime", CanBeNull=true)]
		public DateTime? InputDate
		{
			get
			{
				return this._InputDate;
			}
			set
			{
				if (this._InputDate != value)
				{
					this._InputDate = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=DateTime
		/// </summary>
		[ColumnAttribute(Storage="_FirstDate", DbType="DateTime", CanBeNull=true)]
		public DateTime? FirstDate
		{
			get
			{
				return this._FirstDate;
			}
			set
			{
				if (this._FirstDate != value)
				{
					this._FirstDate = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=DateTime
		/// </summary>
		[ColumnAttribute(Storage="_LastDate", DbType="DateTime", CanBeNull=true)]
		public DateTime? LastDate
		{
			get
			{
				return this._LastDate;
			}
			set
			{
				if (this._LastDate != value)
				{
					this._LastDate = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Int
		/// </summary>
		[ColumnAttribute(Storage="_DaysInMonth", DbType="Int", CanBeNull=true)]
		public int? DaysInMonth
		{
			get
			{
				return this._DaysInMonth;
			}
			set
			{
				if (this._DaysInMonth != value)
				{
					this._DaysInMonth = value;
				}
			}
		}
		
	}
	#endregion fnGetMonthStartEndResult

	#region fnGetPorezPdvNaDatumResult
	public partial class fnGetPorezPdvNaDatumResult
	{
		#region Storage members
		private DateTime _DatumValute;
		private int _BillPorezPdvID;
		private bool _IsActive;
		private int? _Ordinal;
		private bool _IsDefault;
		private string _Naziv;
		private string _PrintableText;
		private string _Opis;
		private string _PrintableTextPercent;
		private int _BillPorezPdvPostotakID;
		private decimal _PdvPosto;
		private DateTime _StartDatum;
		private DateTime? _EndDatum;
		#endregion Storage members

		public fnGetPorezPdvNaDatumResult(){ }

		/// <summary>
		/// Column DbType=DateTime
		/// </summary>
		[ColumnAttribute(Storage="_DatumValute", DbType="DateTime", CanBeNull=false)]
		public DateTime DatumValute
		{
			get
			{
				return this._DatumValute;
			}
			set
			{
				if (this._DatumValute != value)
				{
					this._DatumValute = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Int
		/// </summary>
		[ColumnAttribute(Storage="_BillPorezPdvID", DbType="Int", CanBeNull=false)]
		public int BillPorezPdvID
		{
			get
			{
				return this._BillPorezPdvID;
			}
			set
			{
				if (this._BillPorezPdvID != value)
				{
					this._BillPorezPdvID = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Bit
		/// </summary>
		[ColumnAttribute(Storage="_IsActive", DbType="Bit", CanBeNull=false)]
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
					this._IsActive = value;
				}
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
					this._Ordinal = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Bit
		/// </summary>
		[ColumnAttribute(Storage="_IsDefault", DbType="Bit", CanBeNull=false)]
		public bool IsDefault
		{
			get
			{
				return this._IsDefault;
			}
			set
			{
				if (this._IsDefault != value)
				{
					this._IsDefault = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=NVarChar(150)
		/// </summary>
		[ColumnAttribute(Storage="_Naziv", DbType="NVarChar(150)", CanBeNull=false)]
		public string Naziv
		{
			get
			{
				return this._Naziv;
			}
			set
			{
				if (this._Naziv != value)
				{
					this._Naziv = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=NVarChar(250)
		/// </summary>
		[ColumnAttribute(Storage="_PrintableText", DbType="NVarChar(250)", CanBeNull=true)]
		public string PrintableText
		{
			get
			{
				return this._PrintableText;
			}
			set
			{
				if (this._PrintableText != value)
				{
					this._PrintableText = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=NVarChar(MAX)
		/// </summary>
		[ColumnAttribute(Storage="_Opis", DbType="NVarChar(MAX)", CanBeNull=true)]
		public string Opis
		{
			get
			{
				return this._Opis;
			}
			set
			{
				if (this._Opis != value)
				{
					this._Opis = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=NVarChar(200)
		/// </summary>
		[ColumnAttribute(Storage="_PrintableTextPercent", DbType="NVarChar(200)", CanBeNull=true)]
		public string PrintableTextPercent
		{
			get
			{
				return this._PrintableTextPercent;
			}
			set
			{
				if (this._PrintableTextPercent != value)
				{
					this._PrintableTextPercent = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Int
		/// </summary>
		[ColumnAttribute(Storage="_BillPorezPdvPostotakID", DbType="Int", CanBeNull=false)]
		public int BillPorezPdvPostotakID
		{
			get
			{
				return this._BillPorezPdvPostotakID;
			}
			set
			{
				if (this._BillPorezPdvPostotakID != value)
				{
					this._BillPorezPdvPostotakID = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Money
		/// </summary>
		[ColumnAttribute(Storage="_PdvPosto", DbType="Money", CanBeNull=false)]
		public decimal PdvPosto
		{
			get
			{
				return this._PdvPosto;
			}
			set
			{
				if (this._PdvPosto != value)
				{
					this._PdvPosto = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=DateTime
		/// </summary>
		[ColumnAttribute(Storage="_StartDatum", DbType="DateTime", CanBeNull=false)]
		public DateTime StartDatum
		{
			get
			{
				return this._StartDatum;
			}
			set
			{
				if (this._StartDatum != value)
				{
					this._StartDatum = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=DateTime
		/// </summary>
		[ColumnAttribute(Storage="_EndDatum", DbType="DateTime", CanBeNull=true)]
		public DateTime? EndDatum
		{
			get
			{
				return this._EndDatum;
			}
			set
			{
				if (this._EndDatum != value)
				{
					this._EndDatum = value;
				}
			}
		}
		
	}
	#endregion fnGetPorezPdvNaDatumResult

	#region fnGetPorezPotrosnjaNaDatumResult
	public partial class fnGetPorezPotrosnjaNaDatumResult
	{
		#region Storage members
		private DateTime _DatumValute;
		private int _BillPorezPotrosnjaID;
		private bool _IsActive;
		private int? _Ordinal;
		private bool _IsDefault;
		private string _Naziv;
		private string _PrintableText;
		private string _Opis;
		private string _PrintableTextPercent;
		private int _BillPorezPotrosnjaPostotakID;
		private decimal _PorezPosto;
		private DateTime _StartDatum;
		private DateTime? _EndDatum;
		#endregion Storage members

		public fnGetPorezPotrosnjaNaDatumResult(){ }

		/// <summary>
		/// Column DbType=DateTime
		/// </summary>
		[ColumnAttribute(Storage="_DatumValute", DbType="DateTime", CanBeNull=false)]
		public DateTime DatumValute
		{
			get
			{
				return this._DatumValute;
			}
			set
			{
				if (this._DatumValute != value)
				{
					this._DatumValute = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Int
		/// </summary>
		[ColumnAttribute(Storage="_BillPorezPotrosnjaID", DbType="Int", CanBeNull=false)]
		public int BillPorezPotrosnjaID
		{
			get
			{
				return this._BillPorezPotrosnjaID;
			}
			set
			{
				if (this._BillPorezPotrosnjaID != value)
				{
					this._BillPorezPotrosnjaID = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Bit
		/// </summary>
		[ColumnAttribute(Storage="_IsActive", DbType="Bit", CanBeNull=false)]
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
					this._IsActive = value;
				}
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
					this._Ordinal = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Bit
		/// </summary>
		[ColumnAttribute(Storage="_IsDefault", DbType="Bit", CanBeNull=false)]
		public bool IsDefault
		{
			get
			{
				return this._IsDefault;
			}
			set
			{
				if (this._IsDefault != value)
				{
					this._IsDefault = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=NVarChar(150)
		/// </summary>
		[ColumnAttribute(Storage="_Naziv", DbType="NVarChar(150)", CanBeNull=false)]
		public string Naziv
		{
			get
			{
				return this._Naziv;
			}
			set
			{
				if (this._Naziv != value)
				{
					this._Naziv = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=NVarChar(250)
		/// </summary>
		[ColumnAttribute(Storage="_PrintableText", DbType="NVarChar(250)", CanBeNull=true)]
		public string PrintableText
		{
			get
			{
				return this._PrintableText;
			}
			set
			{
				if (this._PrintableText != value)
				{
					this._PrintableText = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=NVarChar(MAX)
		/// </summary>
		[ColumnAttribute(Storage="_Opis", DbType="NVarChar(MAX)", CanBeNull=true)]
		public string Opis
		{
			get
			{
				return this._Opis;
			}
			set
			{
				if (this._Opis != value)
				{
					this._Opis = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=NVarChar(200)
		/// </summary>
		[ColumnAttribute(Storage="_PrintableTextPercent", DbType="NVarChar(200)", CanBeNull=true)]
		public string PrintableTextPercent
		{
			get
			{
				return this._PrintableTextPercent;
			}
			set
			{
				if (this._PrintableTextPercent != value)
				{
					this._PrintableTextPercent = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Int
		/// </summary>
		[ColumnAttribute(Storage="_BillPorezPotrosnjaPostotakID", DbType="Int", CanBeNull=false)]
		public int BillPorezPotrosnjaPostotakID
		{
			get
			{
				return this._BillPorezPotrosnjaPostotakID;
			}
			set
			{
				if (this._BillPorezPotrosnjaPostotakID != value)
				{
					this._BillPorezPotrosnjaPostotakID = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Money
		/// </summary>
		[ColumnAttribute(Storage="_PorezPosto", DbType="Money", CanBeNull=false)]
		public decimal PorezPosto
		{
			get
			{
				return this._PorezPosto;
			}
			set
			{
				if (this._PorezPosto != value)
				{
					this._PorezPosto = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=DateTime
		/// </summary>
		[ColumnAttribute(Storage="_StartDatum", DbType="DateTime", CanBeNull=false)]
		public DateTime StartDatum
		{
			get
			{
				return this._StartDatum;
			}
			set
			{
				if (this._StartDatum != value)
				{
					this._StartDatum = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=DateTime
		/// </summary>
		[ColumnAttribute(Storage="_EndDatum", DbType="DateTime", CanBeNull=true)]
		public DateTime? EndDatum
		{
			get
			{
				return this._EndDatum;
			}
			set
			{
				if (this._EndDatum != value)
				{
					this._EndDatum = value;
				}
			}
		}
		
	}
	#endregion fnGetPorezPotrosnjaNaDatumResult

	#region fnGetPrikazStatusInfoResult
	public partial class fnGetPrikazStatusInfoResult
	{
		#region Storage members
		private int? _PrikazStatus;
		private DateTime? _StartDate;
		private DateTime? _EndDate;
		private bool _IsVisible;
		private bool _IsPaid;
		#endregion Storage members

		public fnGetPrikazStatusInfoResult(){ }

		/// <summary>
		/// Column DbType=Int
		/// </summary>
		[ColumnAttribute(Storage="_PrikazStatus", DbType="Int", CanBeNull=true)]
		public int? PrikazStatus
		{
			get
			{
				return this._PrikazStatus;
			}
			set
			{
				if (this._PrikazStatus != value)
				{
					this._PrikazStatus = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=DateTime
		/// </summary>
		[ColumnAttribute(Storage="_StartDate", DbType="DateTime", CanBeNull=true)]
		public DateTime? StartDate
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
					this._EndDate = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Bit
		/// </summary>
		[ColumnAttribute(Storage="_IsVisible", DbType="Bit", CanBeNull=false)]
		public bool IsVisible
		{
			get
			{
				return this._IsVisible;
			}
			set
			{
				if (this._IsVisible != value)
				{
					this._IsVisible = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Bit
		/// </summary>
		[ColumnAttribute(Storage="_IsPaid", DbType="Bit", CanBeNull=false)]
		public bool IsPaid
		{
			get
			{
				return this._IsPaid;
			}
			set
			{
				if (this._IsPaid != value)
				{
					this._IsPaid = value;
				}
			}
		}
		
	}
	#endregion fnGetPrikazStatusInfoResult

	#region fnGetProductInfoExtendedResult
	public partial class fnGetProductInfoExtendedResult
	{
		#region Storage members
		private long _BillPoslovniProstorID;
		private int _BillFirmaID;
		private long _BillProductID;
		private string _ProductNaziv;
		private decimal _JedinicnaCijena;
		private bool _CijenaJeMPC;
		private int _BillMjeraID;
		private long _BillPoreznaGrupaID;
		private string _PoreznaGrupaNaziv;
		private decimal _PdvPosto;
		private decimal _PorezPotrosnjaPosto;
		private string _OstaliPorezNaziv;
		private decimal _OstaliPorezPosto;
		private string _NaknadaNaziv;
		private decimal _IznosNaknade;
		#endregion Storage members

		public fnGetProductInfoExtendedResult(){ }

		/// <summary>
		/// Column DbType=BigInt
		/// </summary>
		[ColumnAttribute(Storage="_BillPoslovniProstorID", DbType="BigInt", CanBeNull=false)]
		public long BillPoslovniProstorID
		{
			get
			{
				return this._BillPoslovniProstorID;
			}
			set
			{
				if (this._BillPoslovniProstorID != value)
				{
					this._BillPoslovniProstorID = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Int
		/// </summary>
		[ColumnAttribute(Storage="_BillFirmaID", DbType="Int", CanBeNull=false)]
		public int BillFirmaID
		{
			get
			{
				return this._BillFirmaID;
			}
			set
			{
				if (this._BillFirmaID != value)
				{
					this._BillFirmaID = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=BigInt
		/// </summary>
		[ColumnAttribute(Storage="_BillProductID", DbType="BigInt", CanBeNull=false)]
		public long BillProductID
		{
			get
			{
				return this._BillProductID;
			}
			set
			{
				if (this._BillProductID != value)
				{
					this._BillProductID = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=NVarChar(50)
		/// </summary>
		[ColumnAttribute(Storage="_ProductNaziv", DbType="NVarChar(50)", CanBeNull=false)]
		public string ProductNaziv
		{
			get
			{
				return this._ProductNaziv;
			}
			set
			{
				if (this._ProductNaziv != value)
				{
					this._ProductNaziv = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Money
		/// </summary>
		[ColumnAttribute(Storage="_JedinicnaCijena", DbType="Money", CanBeNull=false)]
		public decimal JedinicnaCijena
		{
			get
			{
				return this._JedinicnaCijena;
			}
			set
			{
				if (this._JedinicnaCijena != value)
				{
					this._JedinicnaCijena = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Bit
		/// </summary>
		[ColumnAttribute(Storage="_CijenaJeMPC", DbType="Bit", CanBeNull=false)]
		public bool CijenaJeMPC
		{
			get
			{
				return this._CijenaJeMPC;
			}
			set
			{
				if (this._CijenaJeMPC != value)
				{
					this._CijenaJeMPC = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Int
		/// </summary>
		[ColumnAttribute(Storage="_BillMjeraID", DbType="Int", CanBeNull=false)]
		public int BillMjeraID
		{
			get
			{
				return this._BillMjeraID;
			}
			set
			{
				if (this._BillMjeraID != value)
				{
					this._BillMjeraID = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=BigInt
		/// </summary>
		[ColumnAttribute(Storage="_BillPoreznaGrupaID", DbType="BigInt", CanBeNull=false)]
		public long BillPoreznaGrupaID
		{
			get
			{
				return this._BillPoreznaGrupaID;
			}
			set
			{
				if (this._BillPoreznaGrupaID != value)
				{
					this._BillPoreznaGrupaID = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=NVarChar(100)
		/// </summary>
		[ColumnAttribute(Storage="_PoreznaGrupaNaziv", DbType="NVarChar(100)", CanBeNull=false)]
		public string PoreznaGrupaNaziv
		{
			get
			{
				return this._PoreznaGrupaNaziv;
			}
			set
			{
				if (this._PoreznaGrupaNaziv != value)
				{
					this._PoreznaGrupaNaziv = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Decimal(5,2)
		/// </summary>
		[ColumnAttribute(Storage="_PdvPosto", DbType="Decimal(5,2)", CanBeNull=false)]
		public decimal PdvPosto
		{
			get
			{
				return this._PdvPosto;
			}
			set
			{
				if (this._PdvPosto != value)
				{
					this._PdvPosto = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Decimal(5,2)
		/// </summary>
		[ColumnAttribute(Storage="_PorezPotrosnjaPosto", DbType="Decimal(5,2)", CanBeNull=false)]
		public decimal PorezPotrosnjaPosto
		{
			get
			{
				return this._PorezPotrosnjaPosto;
			}
			set
			{
				if (this._PorezPotrosnjaPosto != value)
				{
					this._PorezPotrosnjaPosto = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=NVarChar(50)
		/// </summary>
		[ColumnAttribute(Storage="_OstaliPorezNaziv", DbType="NVarChar(50)", CanBeNull=true)]
		public string OstaliPorezNaziv
		{
			get
			{
				return this._OstaliPorezNaziv;
			}
			set
			{
				if (this._OstaliPorezNaziv != value)
				{
					this._OstaliPorezNaziv = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Decimal(5,2)
		/// </summary>
		[ColumnAttribute(Storage="_OstaliPorezPosto", DbType="Decimal(5,2)", CanBeNull=false)]
		public decimal OstaliPorezPosto
		{
			get
			{
				return this._OstaliPorezPosto;
			}
			set
			{
				if (this._OstaliPorezPosto != value)
				{
					this._OstaliPorezPosto = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=NVarChar(50)
		/// </summary>
		[ColumnAttribute(Storage="_NaknadaNaziv", DbType="NVarChar(50)", CanBeNull=true)]
		public string NaknadaNaziv
		{
			get
			{
				return this._NaknadaNaziv;
			}
			set
			{
				if (this._NaknadaNaziv != value)
				{
					this._NaknadaNaziv = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Money
		/// </summary>
		[ColumnAttribute(Storage="_IznosNaknade", DbType="Money", CanBeNull=false)]
		public decimal IznosNaknade
		{
			get
			{
				return this._IznosNaknade;
			}
			set
			{
				if (this._IznosNaknade != value)
				{
					this._IznosNaknade = value;
				}
			}
		}
		
	}
	#endregion fnGetProductInfoExtendedResult

	#region fnGetStariNoviGranicaResult
	public partial class fnGetStariNoviGranicaResult
	{
		#region Storage members
		private DateTime _StartDate;
		private DateTime _EndDate;
		#endregion Storage members

		public fnGetStariNoviGranicaResult(){ }

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
	#endregion fnGetStariNoviGranicaResult

	#region fnGetUplateWithDocumentsResult
	public partial class fnGetUplateWithDocumentsResult
	{
		#region Storage members
		private int _BankaPrometID;
		private DateTime _BankaDatumTransakcije;
		private decimal? _BankaUplata;
		private decimal? _BankaIsplata;
		private long? _MinBillDocumentID;
		private long? _BillClientID;
		#endregion Storage members

		public fnGetUplateWithDocumentsResult(){ }

		/// <summary>
		/// Column DbType=Int
		/// </summary>
		[ColumnAttribute(Storage="_BankaPrometID", DbType="Int", CanBeNull=false)]
		public int BankaPrometID
		{
			get
			{
				return this._BankaPrometID;
			}
			set
			{
				if (this._BankaPrometID != value)
				{
					this._BankaPrometID = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=DateTime
		/// </summary>
		[ColumnAttribute(Storage="_BankaDatumTransakcije", DbType="DateTime", CanBeNull=false)]
		public DateTime BankaDatumTransakcije
		{
			get
			{
				return this._BankaDatumTransakcije;
			}
			set
			{
				if (this._BankaDatumTransakcije != value)
				{
					this._BankaDatumTransakcije = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Money
		/// </summary>
		[ColumnAttribute(Storage="_BankaUplata", DbType="Money", CanBeNull=true)]
		public decimal? BankaUplata
		{
			get
			{
				return this._BankaUplata;
			}
			set
			{
				if (this._BankaUplata != value)
				{
					this._BankaUplata = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Money
		/// </summary>
		[ColumnAttribute(Storage="_BankaIsplata", DbType="Money", CanBeNull=true)]
		public decimal? BankaIsplata
		{
			get
			{
				return this._BankaIsplata;
			}
			set
			{
				if (this._BankaIsplata != value)
				{
					this._BankaIsplata = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=BigInt
		/// </summary>
		[ColumnAttribute(Storage="_MinBillDocumentID", DbType="BigInt", CanBeNull=true)]
		public long? MinBillDocumentID
		{
			get
			{
				return this._MinBillDocumentID;
			}
			set
			{
				if (this._MinBillDocumentID != value)
				{
					this._MinBillDocumentID = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=BigInt
		/// </summary>
		[ColumnAttribute(Storage="_BillClientID", DbType="BigInt", CanBeNull=true)]
		public long? BillClientID
		{
			get
			{
				return this._BillClientID;
			}
			set
			{
				if (this._BillClientID != value)
				{
					this._BillClientID = value;
				}
			}
		}
		
	}
	#endregion fnGetUplateWithDocumentsResult

	#region fnPosGetFirmaSettingsResult
	public partial class fnPosGetFirmaSettingsResult
	{
		#region Storage members
		private long _BillFirmaPosID;
		private int _BillFirmaID;
		private long? _ReferenceBillDocumentID;
		private DateTime _StartDate;
		private DateTime _EndDate;
		private bool _IsActive;
		private int _PoslovniProstoriMax;
		private int _NaplatniUredjajiMax;
		private int _DocumentsMax;
		private int _DocumentsCount;
		private int _CategoriesMax;
		private int _ProductsMax;
		private int _PorezneGrupeMax;
		private int _OperatoriMax;
		private int? _DocumentsLeft;
		#endregion Storage members

		public fnPosGetFirmaSettingsResult(){ }

		/// <summary>
		/// Column DbType=BigInt
		/// </summary>
		[ColumnAttribute(Storage="_BillFirmaPosID", DbType="BigInt", CanBeNull=false)]
		public long BillFirmaPosID
		{
			get
			{
				return this._BillFirmaPosID;
			}
			set
			{
				if (this._BillFirmaPosID != value)
				{
					this._BillFirmaPosID = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Int
		/// </summary>
		[ColumnAttribute(Storage="_BillFirmaID", DbType="Int", CanBeNull=false)]
		public int BillFirmaID
		{
			get
			{
				return this._BillFirmaID;
			}
			set
			{
				if (this._BillFirmaID != value)
				{
					this._BillFirmaID = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=BigInt
		/// </summary>
		[ColumnAttribute(Storage="_ReferenceBillDocumentID", DbType="BigInt", CanBeNull=true)]
		public long? ReferenceBillDocumentID
		{
			get
			{
				return this._ReferenceBillDocumentID;
			}
			set
			{
				if (this._ReferenceBillDocumentID != value)
				{
					this._ReferenceBillDocumentID = value;
				}
			}
		}
		
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
		
		/// <summary>
		/// Column DbType=Bit
		/// </summary>
		[ColumnAttribute(Storage="_IsActive", DbType="Bit", CanBeNull=false)]
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
					this._IsActive = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Int
		/// </summary>
		[ColumnAttribute(Storage="_PoslovniProstoriMax", DbType="Int", CanBeNull=false)]
		public int PoslovniProstoriMax
		{
			get
			{
				return this._PoslovniProstoriMax;
			}
			set
			{
				if (this._PoslovniProstoriMax != value)
				{
					this._PoslovniProstoriMax = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Int
		/// </summary>
		[ColumnAttribute(Storage="_NaplatniUredjajiMax", DbType="Int", CanBeNull=false)]
		public int NaplatniUredjajiMax
		{
			get
			{
				return this._NaplatniUredjajiMax;
			}
			set
			{
				if (this._NaplatniUredjajiMax != value)
				{
					this._NaplatniUredjajiMax = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Int
		/// </summary>
		[ColumnAttribute(Storage="_DocumentsMax", DbType="Int", CanBeNull=false)]
		public int DocumentsMax
		{
			get
			{
				return this._DocumentsMax;
			}
			set
			{
				if (this._DocumentsMax != value)
				{
					this._DocumentsMax = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Int
		/// </summary>
		[ColumnAttribute(Storage="_DocumentsCount", DbType="Int", CanBeNull=false)]
		public int DocumentsCount
		{
			get
			{
				return this._DocumentsCount;
			}
			set
			{
				if (this._DocumentsCount != value)
				{
					this._DocumentsCount = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Int
		/// </summary>
		[ColumnAttribute(Storage="_CategoriesMax", DbType="Int", CanBeNull=false)]
		public int CategoriesMax
		{
			get
			{
				return this._CategoriesMax;
			}
			set
			{
				if (this._CategoriesMax != value)
				{
					this._CategoriesMax = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Int
		/// </summary>
		[ColumnAttribute(Storage="_ProductsMax", DbType="Int", CanBeNull=false)]
		public int ProductsMax
		{
			get
			{
				return this._ProductsMax;
			}
			set
			{
				if (this._ProductsMax != value)
				{
					this._ProductsMax = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Int
		/// </summary>
		[ColumnAttribute(Storage="_PorezneGrupeMax", DbType="Int", CanBeNull=false)]
		public int PorezneGrupeMax
		{
			get
			{
				return this._PorezneGrupeMax;
			}
			set
			{
				if (this._PorezneGrupeMax != value)
				{
					this._PorezneGrupeMax = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Int
		/// </summary>
		[ColumnAttribute(Storage="_OperatoriMax", DbType="Int", CanBeNull=false)]
		public int OperatoriMax
		{
			get
			{
				return this._OperatoriMax;
			}
			set
			{
				if (this._OperatoriMax != value)
				{
					this._OperatoriMax = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Int
		/// </summary>
		[ColumnAttribute(Storage="_DocumentsLeft", DbType="Int", CanBeNull=true)]
		public int? DocumentsLeft
		{
			get
			{
				return this._DocumentsLeft;
			}
			set
			{
				if (this._DocumentsLeft != value)
				{
					this._DocumentsLeft = value;
				}
			}
		}
		
	}
	#endregion fnPosGetFirmaSettingsResult

	#region fnPosGetFirmaStatisticsResult
	public partial class fnPosGetFirmaStatisticsResult
	{
		#region Storage members
		private int _BillFirmaID;
		private int? _AktivnePretplateCount;
		private long? _BillFirmaPosID;
		private DateTime? _StartDate;
		private long? _CategoriesMax;
		private long? _DocumentsMax;
		private long? _DocumentsCount;
		private long? _NaplatniUredjajiMax;
		private long? _OperatoriMax;
		private long? _PorezneGrupeMax;
		private long? _PoslovniProstoriMax;
		private long? _ProductsMax;
		private DateTime? _EndDate;
		private int? _OperatoriCount;
		private int? _PoslovniProstoriCount;
		private int? _NaplatniUredjajiCount;
		private int? _CategoriesCount;
		private int? _ProductsCount;
		private int? _PorezneGrupeCount;
		private bool? _IsOperating;
		private bool? _AllowNewCategory;
		private bool? _AllowNewNaplatniUredjaj;
		private bool? _AllowNewOperator;
		private bool? _AllowNewPoreznaGrupa;
		private bool? _AllowNewPoslovniProstor;
		private bool? _AllowNewProduct;
		#endregion Storage members

		public fnPosGetFirmaStatisticsResult(){ }

		/// <summary>
		/// Column DbType=Int
		/// </summary>
		[ColumnAttribute(Storage="_BillFirmaID", DbType="Int", CanBeNull=false)]
		public int BillFirmaID
		{
			get
			{
				return this._BillFirmaID;
			}
			set
			{
				if (this._BillFirmaID != value)
				{
					this._BillFirmaID = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Int
		/// </summary>
		[ColumnAttribute(Storage="_AktivnePretplateCount", DbType="Int", CanBeNull=true)]
		public int? AktivnePretplateCount
		{
			get
			{
				return this._AktivnePretplateCount;
			}
			set
			{
				if (this._AktivnePretplateCount != value)
				{
					this._AktivnePretplateCount = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=BigInt
		/// </summary>
		[ColumnAttribute(Storage="_BillFirmaPosID", DbType="BigInt", CanBeNull=true)]
		public long? BillFirmaPosID
		{
			get
			{
				return this._BillFirmaPosID;
			}
			set
			{
				if (this._BillFirmaPosID != value)
				{
					this._BillFirmaPosID = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=DateTime
		/// </summary>
		[ColumnAttribute(Storage="_StartDate", DbType="DateTime", CanBeNull=true)]
		public DateTime? StartDate
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
		/// Column DbType=BigInt
		/// </summary>
		[ColumnAttribute(Storage="_CategoriesMax", DbType="BigInt", CanBeNull=true)]
		public long? CategoriesMax
		{
			get
			{
				return this._CategoriesMax;
			}
			set
			{
				if (this._CategoriesMax != value)
				{
					this._CategoriesMax = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=BigInt
		/// </summary>
		[ColumnAttribute(Storage="_DocumentsMax", DbType="BigInt", CanBeNull=true)]
		public long? DocumentsMax
		{
			get
			{
				return this._DocumentsMax;
			}
			set
			{
				if (this._DocumentsMax != value)
				{
					this._DocumentsMax = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=BigInt
		/// </summary>
		[ColumnAttribute(Storage="_DocumentsCount", DbType="BigInt", CanBeNull=true)]
		public long? DocumentsCount
		{
			get
			{
				return this._DocumentsCount;
			}
			set
			{
				if (this._DocumentsCount != value)
				{
					this._DocumentsCount = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=BigInt
		/// </summary>
		[ColumnAttribute(Storage="_NaplatniUredjajiMax", DbType="BigInt", CanBeNull=true)]
		public long? NaplatniUredjajiMax
		{
			get
			{
				return this._NaplatniUredjajiMax;
			}
			set
			{
				if (this._NaplatniUredjajiMax != value)
				{
					this._NaplatniUredjajiMax = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=BigInt
		/// </summary>
		[ColumnAttribute(Storage="_OperatoriMax", DbType="BigInt", CanBeNull=true)]
		public long? OperatoriMax
		{
			get
			{
				return this._OperatoriMax;
			}
			set
			{
				if (this._OperatoriMax != value)
				{
					this._OperatoriMax = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=BigInt
		/// </summary>
		[ColumnAttribute(Storage="_PorezneGrupeMax", DbType="BigInt", CanBeNull=true)]
		public long? PorezneGrupeMax
		{
			get
			{
				return this._PorezneGrupeMax;
			}
			set
			{
				if (this._PorezneGrupeMax != value)
				{
					this._PorezneGrupeMax = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=BigInt
		/// </summary>
		[ColumnAttribute(Storage="_PoslovniProstoriMax", DbType="BigInt", CanBeNull=true)]
		public long? PoslovniProstoriMax
		{
			get
			{
				return this._PoslovniProstoriMax;
			}
			set
			{
				if (this._PoslovniProstoriMax != value)
				{
					this._PoslovniProstoriMax = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=BigInt
		/// </summary>
		[ColumnAttribute(Storage="_ProductsMax", DbType="BigInt", CanBeNull=true)]
		public long? ProductsMax
		{
			get
			{
				return this._ProductsMax;
			}
			set
			{
				if (this._ProductsMax != value)
				{
					this._ProductsMax = value;
				}
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
					this._EndDate = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Int
		/// </summary>
		[ColumnAttribute(Storage="_OperatoriCount", DbType="Int", CanBeNull=true)]
		public int? OperatoriCount
		{
			get
			{
				return this._OperatoriCount;
			}
			set
			{
				if (this._OperatoriCount != value)
				{
					this._OperatoriCount = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Int
		/// </summary>
		[ColumnAttribute(Storage="_PoslovniProstoriCount", DbType="Int", CanBeNull=true)]
		public int? PoslovniProstoriCount
		{
			get
			{
				return this._PoslovniProstoriCount;
			}
			set
			{
				if (this._PoslovniProstoriCount != value)
				{
					this._PoslovniProstoriCount = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Int
		/// </summary>
		[ColumnAttribute(Storage="_NaplatniUredjajiCount", DbType="Int", CanBeNull=true)]
		public int? NaplatniUredjajiCount
		{
			get
			{
				return this._NaplatniUredjajiCount;
			}
			set
			{
				if (this._NaplatniUredjajiCount != value)
				{
					this._NaplatniUredjajiCount = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Int
		/// </summary>
		[ColumnAttribute(Storage="_CategoriesCount", DbType="Int", CanBeNull=true)]
		public int? CategoriesCount
		{
			get
			{
				return this._CategoriesCount;
			}
			set
			{
				if (this._CategoriesCount != value)
				{
					this._CategoriesCount = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Int
		/// </summary>
		[ColumnAttribute(Storage="_ProductsCount", DbType="Int", CanBeNull=true)]
		public int? ProductsCount
		{
			get
			{
				return this._ProductsCount;
			}
			set
			{
				if (this._ProductsCount != value)
				{
					this._ProductsCount = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Int
		/// </summary>
		[ColumnAttribute(Storage="_PorezneGrupeCount", DbType="Int", CanBeNull=true)]
		public int? PorezneGrupeCount
		{
			get
			{
				return this._PorezneGrupeCount;
			}
			set
			{
				if (this._PorezneGrupeCount != value)
				{
					this._PorezneGrupeCount = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Bit
		/// </summary>
		[ColumnAttribute(Storage="_IsOperating", DbType="Bit", CanBeNull=true)]
		public bool? IsOperating
		{
			get
			{
				return this._IsOperating;
			}
			set
			{
				if (this._IsOperating != value)
				{
					this._IsOperating = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Bit
		/// </summary>
		[ColumnAttribute(Storage="_AllowNewCategory", DbType="Bit", CanBeNull=true)]
		public bool? AllowNewCategory
		{
			get
			{
				return this._AllowNewCategory;
			}
			set
			{
				if (this._AllowNewCategory != value)
				{
					this._AllowNewCategory = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Bit
		/// </summary>
		[ColumnAttribute(Storage="_AllowNewNaplatniUredjaj", DbType="Bit", CanBeNull=true)]
		public bool? AllowNewNaplatniUredjaj
		{
			get
			{
				return this._AllowNewNaplatniUredjaj;
			}
			set
			{
				if (this._AllowNewNaplatniUredjaj != value)
				{
					this._AllowNewNaplatniUredjaj = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Bit
		/// </summary>
		[ColumnAttribute(Storage="_AllowNewOperator", DbType="Bit", CanBeNull=true)]
		public bool? AllowNewOperator
		{
			get
			{
				return this._AllowNewOperator;
			}
			set
			{
				if (this._AllowNewOperator != value)
				{
					this._AllowNewOperator = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Bit
		/// </summary>
		[ColumnAttribute(Storage="_AllowNewPoreznaGrupa", DbType="Bit", CanBeNull=true)]
		public bool? AllowNewPoreznaGrupa
		{
			get
			{
				return this._AllowNewPoreznaGrupa;
			}
			set
			{
				if (this._AllowNewPoreznaGrupa != value)
				{
					this._AllowNewPoreznaGrupa = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Bit
		/// </summary>
		[ColumnAttribute(Storage="_AllowNewPoslovniProstor", DbType="Bit", CanBeNull=true)]
		public bool? AllowNewPoslovniProstor
		{
			get
			{
				return this._AllowNewPoslovniProstor;
			}
			set
			{
				if (this._AllowNewPoslovniProstor != value)
				{
					this._AllowNewPoslovniProstor = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Bit
		/// </summary>
		[ColumnAttribute(Storage="_AllowNewProduct", DbType="Bit", CanBeNull=true)]
		public bool? AllowNewProduct
		{
			get
			{
				return this._AllowNewProduct;
			}
			set
			{
				if (this._AllowNewProduct != value)
				{
					this._AllowNewProduct = value;
				}
			}
		}
		
	}
	#endregion fnPosGetFirmaStatisticsResult

	#region fnRazradaIznosaResult
	public partial class fnRazradaIznosaResult
	{
		#region Storage members
		private double _JedinicnaVPC;
		private double _JedinicnaMPC;
		private double _PopustPosto;
		private double _VPCsPopustom;
		private double _IznosNaknade;
		private bool _UPdvSustavu;
		private double _PdvPosto;
		private double _IznosPdva;
		private double _PorezPotrosnjaPosto;
		private double _IznosPorezPotrosnja;
		private double _OstaliPorezPosto;
		private double _IznosOstaliPorez;
		private double _MPCsPopustom;
		#endregion Storage members

		public fnRazradaIznosaResult(){ }

		/// <summary>
		/// Column DbType=Float
		/// </summary>
		[ColumnAttribute(Storage="_JedinicnaVPC", DbType="Float", CanBeNull=false)]
		public double JedinicnaVPC
		{
			get
			{
				return this._JedinicnaVPC;
			}
			set
			{
				if (this._JedinicnaVPC != value)
				{
					this._JedinicnaVPC = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Float
		/// </summary>
		[ColumnAttribute(Storage="_JedinicnaMPC", DbType="Float", CanBeNull=false)]
		public double JedinicnaMPC
		{
			get
			{
				return this._JedinicnaMPC;
			}
			set
			{
				if (this._JedinicnaMPC != value)
				{
					this._JedinicnaMPC = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Float
		/// </summary>
		[ColumnAttribute(Storage="_PopustPosto", DbType="Float", CanBeNull=false)]
		public double PopustPosto
		{
			get
			{
				return this._PopustPosto;
			}
			set
			{
				if (this._PopustPosto != value)
				{
					this._PopustPosto = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Float
		/// </summary>
		[ColumnAttribute(Storage="_VPCsPopustom", DbType="Float", CanBeNull=false)]
		public double VPCsPopustom
		{
			get
			{
				return this._VPCsPopustom;
			}
			set
			{
				if (this._VPCsPopustom != value)
				{
					this._VPCsPopustom = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Float
		/// </summary>
		[ColumnAttribute(Storage="_IznosNaknade", DbType="Float", CanBeNull=false)]
		public double IznosNaknade
		{
			get
			{
				return this._IznosNaknade;
			}
			set
			{
				if (this._IznosNaknade != value)
				{
					this._IznosNaknade = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Bit
		/// </summary>
		[ColumnAttribute(Storage="_UPdvSustavu", DbType="Bit", CanBeNull=false)]
		public bool UPdvSustavu
		{
			get
			{
				return this._UPdvSustavu;
			}
			set
			{
				if (this._UPdvSustavu != value)
				{
					this._UPdvSustavu = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Float
		/// </summary>
		[ColumnAttribute(Storage="_PdvPosto", DbType="Float", CanBeNull=false)]
		public double PdvPosto
		{
			get
			{
				return this._PdvPosto;
			}
			set
			{
				if (this._PdvPosto != value)
				{
					this._PdvPosto = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Float
		/// </summary>
		[ColumnAttribute(Storage="_IznosPdva", DbType="Float", CanBeNull=false)]
		public double IznosPdva
		{
			get
			{
				return this._IznosPdva;
			}
			set
			{
				if (this._IznosPdva != value)
				{
					this._IznosPdva = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Float
		/// </summary>
		[ColumnAttribute(Storage="_PorezPotrosnjaPosto", DbType="Float", CanBeNull=false)]
		public double PorezPotrosnjaPosto
		{
			get
			{
				return this._PorezPotrosnjaPosto;
			}
			set
			{
				if (this._PorezPotrosnjaPosto != value)
				{
					this._PorezPotrosnjaPosto = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Float
		/// </summary>
		[ColumnAttribute(Storage="_IznosPorezPotrosnja", DbType="Float", CanBeNull=false)]
		public double IznosPorezPotrosnja
		{
			get
			{
				return this._IznosPorezPotrosnja;
			}
			set
			{
				if (this._IznosPorezPotrosnja != value)
				{
					this._IznosPorezPotrosnja = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Float
		/// </summary>
		[ColumnAttribute(Storage="_OstaliPorezPosto", DbType="Float", CanBeNull=false)]
		public double OstaliPorezPosto
		{
			get
			{
				return this._OstaliPorezPosto;
			}
			set
			{
				if (this._OstaliPorezPosto != value)
				{
					this._OstaliPorezPosto = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Float
		/// </summary>
		[ColumnAttribute(Storage="_IznosOstaliPorez", DbType="Float", CanBeNull=false)]
		public double IznosOstaliPorez
		{
			get
			{
				return this._IznosOstaliPorez;
			}
			set
			{
				if (this._IznosOstaliPorez != value)
				{
					this._IznosOstaliPorez = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Float
		/// </summary>
		[ColumnAttribute(Storage="_MPCsPopustom", DbType="Float", CanBeNull=false)]
		public double MPCsPopustom
		{
			get
			{
				return this._MPCsPopustom;
			}
			set
			{
				if (this._MPCsPopustom != value)
				{
					this._MPCsPopustom = value;
				}
			}
		}
		
	}
	#endregion fnRazradaIznosaResult

	#region fnSplitStringByPatternResult
	public partial class fnSplitStringByPatternResult
	{
		#region Storage members
		private int _position;
		private string _part;
		#endregion Storage members

		public fnSplitStringByPatternResult(){ }

		/// <summary>
		/// Column DbType=Int
		/// </summary>
		[ColumnAttribute(Storage="_position", DbType="Int", CanBeNull=false)]
		public int position
		{
			get
			{
				return this._position;
			}
			set
			{
				if (this._position != value)
				{
					this._position = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=VarChar(MAX)
		/// </summary>
		[ColumnAttribute(Storage="_part", DbType="VarChar(MAX)", CanBeNull=true)]
		public string part
		{
			get
			{
				return this._part;
			}
			set
			{
				if (this._part != value)
				{
					this._part = value;
				}
			}
		}
		
	}
	#endregion fnSplitStringByPatternResult

	#region spBillClientFullTextUpdateALLMultipleResults
	public partial class spBillClientFullTextUpdateALLMultipleResults
	{
		#region Storage members
		private int _ReturnValue;
		#endregion Storage members

		public spBillClientFullTextUpdateALLMultipleResults(){ }

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
	#endregion spBillClientFullTextUpdateALLMultipleResults

	#region spBillClientFullTextUpdateSingleMultipleResults
	public partial class spBillClientFullTextUpdateSingleMultipleResults
	{
		#region Storage members
		private int _ReturnValue;
		#endregion Storage members

		public spBillClientFullTextUpdateSingleMultipleResults(){ }

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
	#endregion spBillClientFullTextUpdateSingleMultipleResults

	#region spCalculateBankaStanjeMultipleResults
	public partial class spCalculateBankaStanjeMultipleResults
	{
		#region Storage members
		private int _ReturnValue;
		#endregion Storage members

		public spCalculateBankaStanjeMultipleResults(){ }

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
	#endregion spCalculateBankaStanjeMultipleResults

	#region spCreateBillClientFromDirClientMultipleResults
	public partial class spCreateBillClientFromDirClientMultipleResults
	{
		#region Storage members
		private int _ReturnValue;
		#endregion Storage members

		public spCreateBillClientFromDirClientMultipleResults(){ }

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
	#endregion spCreateBillClientFromDirClientMultipleResults

	#region spDirClientFullTextUpdateALLMultipleResults
	public partial class spDirClientFullTextUpdateALLMultipleResults
	{
		#region Storage members
		private int _ReturnValue;
		#endregion Storage members

		public spDirClientFullTextUpdateALLMultipleResults(){ }

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
	#endregion spDirClientFullTextUpdateALLMultipleResults

	#region spDirClientFullTextUpdateSingleMultipleResults
	public partial class spDirClientFullTextUpdateSingleMultipleResults
	{
		#region Storage members
		private int _ReturnValue;
		#endregion Storage members

		public spDirClientFullTextUpdateSingleMultipleResults(){ }

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
	#endregion spDirClientFullTextUpdateSingleMultipleResults

	#region spDodajDocumentStavkuMultipleResults
	public partial class spDodajDocumentStavkuMultipleResults
	{
		#region Storage members
		private int _ReturnValue;
		#endregion Storage members

		public spDodajDocumentStavkuMultipleResults(){ }

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
	#endregion spDodajDocumentStavkuMultipleResults

	#region spEnsureFiskalizacijaOznakeMultipleResults
	public partial class spEnsureFiskalizacijaOznakeMultipleResults
	{
		#region Storage members
		private int _ReturnValue;
		#endregion Storage members

		public spEnsureFiskalizacijaOznakeMultipleResults(){ }

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
	#endregion spEnsureFiskalizacijaOznakeMultipleResults

	#region spFiskalizacijaRequiredIntegrityTestMultipleResults
	public partial class spFiskalizacijaRequiredIntegrityTestMultipleResults
	{
		#region Storage members
		private int _ReturnValue;
		#endregion Storage members

		public spFiskalizacijaRequiredIntegrityTestMultipleResults(){ }

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
	#endregion spFiskalizacijaRequiredIntegrityTestMultipleResults

	#region spGetBankaStanjeRacunaMultipleResults
	public partial class spGetBankaStanjeRacunaMultipleResults
	{
		#region Storage members
		private List<spGetBankaStanjeRacunaResult> _Result1;
		private int _ReturnValue;
		#endregion Storage members

		public spGetBankaStanjeRacunaMultipleResults(){ }

		/// <summary>
		/// Column DbType=
		/// </summary>
		[ColumnAttribute(Storage="_Result1", DbType="", CanBeNull=false)]
		public List<spGetBankaStanjeRacunaResult> Result1
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
	#endregion spGetBankaStanjeRacunaMultipleResults

	#region spGetBillClientByOibAndPozivNaBrojMultipleResults
	public partial class spGetBillClientByOibAndPozivNaBrojMultipleResults
	{
		#region Storage members
		private List<spGetBillClientByOibAndPozivNaBrojResult> _Result1;
		private int _ReturnValue;
		#endregion Storage members

		public spGetBillClientByOibAndPozivNaBrojMultipleResults(){ }

		/// <summary>
		/// Column DbType=
		/// </summary>
		[ColumnAttribute(Storage="_Result1", DbType="", CanBeNull=false)]
		public List<spGetBillClientByOibAndPozivNaBrojResult> Result1
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
	#endregion spGetBillClientByOibAndPozivNaBrojMultipleResults

	#region spGetDbccValuesMultipleResults
	public partial class spGetDbccValuesMultipleResults
	{
		#region Storage members
		private List<spGetDbccValuesResult> _Result1;
		private int _ReturnValue;
		#endregion Storage members

		public spGetDbccValuesMultipleResults(){ }

		/// <summary>
		/// Column DbType=
		/// </summary>
		[ColumnAttribute(Storage="_Result1", DbType="", CanBeNull=false)]
		public List<spGetDbccValuesResult> Result1
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
	#endregion spGetDbccValuesMultipleResults

	#region spGetDocumentsForFiskaliziranjeMultipleResults
	public partial class spGetDocumentsForFiskaliziranjeMultipleResults
	{
		#region Storage members
		private List<spGetDocumentsForFiskaliziranjeResult> _Result1;
		private int _ReturnValue;
		#endregion Storage members

		public spGetDocumentsForFiskaliziranjeMultipleResults(){ }

		/// <summary>
		/// Column DbType=
		/// </summary>
		[ColumnAttribute(Storage="_Result1", DbType="", CanBeNull=false)]
		public List<spGetDocumentsForFiskaliziranjeResult> Result1
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
	#endregion spGetDocumentsForFiskaliziranjeMultipleResults

	#region spGetDocumentsForPaymentsMultipleResults
	public partial class spGetDocumentsForPaymentsMultipleResults
	{
		#region Storage members
		private List<spGetDocumentsForPaymentsResult> _Result1;
		private int _ReturnValue;
		#endregion Storage members

		public spGetDocumentsForPaymentsMultipleResults(){ }

		/// <summary>
		/// Column DbType=
		/// </summary>
		[ColumnAttribute(Storage="_Result1", DbType="", CanBeNull=false)]
		public List<spGetDocumentsForPaymentsResult> Result1
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
	#endregion spGetDocumentsForPaymentsMultipleResults

	#region spGetJobAdvertsMultipleResults
	public partial class spGetJobAdvertsMultipleResults
	{
		#region Storage members
		private List<spGetJobAdvertsResult> _Result1;
		private int _ReturnValue;
		#endregion Storage members

		public spGetJobAdvertsMultipleResults(){ }

		/// <summary>
		/// Column DbType=
		/// </summary>
		[ColumnAttribute(Storage="_Result1", DbType="", CanBeNull=false)]
		public List<spGetJobAdvertsResult> Result1
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
	#endregion spGetJobAdvertsMultipleResults

	#region spGetPoreziInfoExtendedMultipleResults
	public partial class spGetPoreziInfoExtendedMultipleResults
	{
		#region Storage members
		private List<spGetPoreziInfoExtendedResult1> _Result1;
		private List<spGetPoreziInfoExtendedResult2> _Result2;
		private int _ReturnValue;
		#endregion Storage members

		public spGetPoreziInfoExtendedMultipleResults(){ }

		/// <summary>
		/// Column DbType=
		/// </summary>
		[ColumnAttribute(Storage="_Result1", DbType="", CanBeNull=false)]
		public List<spGetPoreziInfoExtendedResult1> Result1
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
		public List<spGetPoreziInfoExtendedResult2> Result2
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
	#endregion spGetPoreziInfoExtendedMultipleResults

	#region spGetPozivDestinationPhoneMultipleResults
	public partial class spGetPozivDestinationPhoneMultipleResults
	{
		#region Storage members
		private List<spGetPozivDestinationPhoneResult> _Result1;
		private int _ReturnValue;
		#endregion Storage members

		public spGetPozivDestinationPhoneMultipleResults(){ }

		/// <summary>
		/// Column DbType=
		/// </summary>
		[ColumnAttribute(Storage="_Result1", DbType="", CanBeNull=false)]
		public List<spGetPozivDestinationPhoneResult> Result1
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
	#endregion spGetPozivDestinationPhoneMultipleResults

	#region spPosGetDirClientMultipleResults
	public partial class spPosGetDirClientMultipleResults
	{
		#region Storage members
		private int _ReturnValue;
		#endregion Storage members

		public spPosGetDirClientMultipleResults(){ }

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
	#endregion spPosGetDirClientMultipleResults

	#region spRegistarDeleteNeposlanePonudeMultipleResults
	public partial class spRegistarDeleteNeposlanePonudeMultipleResults
	{
		#region Storage members
		private int _ReturnValue;
		#endregion Storage members

		public spRegistarDeleteNeposlanePonudeMultipleResults(){ }

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
	#endregion spRegistarDeleteNeposlanePonudeMultipleResults

	#region spUpdateBankaPrometMultipleResults
	public partial class spUpdateBankaPrometMultipleResults
	{
		#region Storage members
		private int _ReturnValue;
		#endregion Storage members

		public spUpdateBankaPrometMultipleResults(){ }

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
	#endregion spUpdateBankaPrometMultipleResults

	#region spUpdateBillDocumentCalculatedMultipleResults
	public partial class spUpdateBillDocumentCalculatedMultipleResults
	{
		#region Storage members
		private int _ReturnValue;
		#endregion Storage members

		public spUpdateBillDocumentCalculatedMultipleResults(){ }

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
	#endregion spUpdateBillDocumentCalculatedMultipleResults

	#region spUpdateBillDocumentCalculatedALLMultipleResults
	public partial class spUpdateBillDocumentCalculatedALLMultipleResults
	{
		#region Storage members
		private int _ReturnValue;
		#endregion Storage members

		public spUpdateBillDocumentCalculatedALLMultipleResults(){ }

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
	#endregion spUpdateBillDocumentCalculatedALLMultipleResults

	#region spGetBankaStanjeRacunaResult
	public partial class spGetBankaStanjeRacunaResult
	{
		#region Storage members
		private string _FirmaNaziv;
		private string _RacunNaziv;
		private bool _IsPersonal;
		private string _IBAN;
		private string _Valuta;
		private decimal? _Stanje;
		private string _StanjeFormated;
		#endregion Storage members

		public spGetBankaStanjeRacunaResult(){ }

		/// <summary>
		/// Column DbType=NVarChar(255)
		/// </summary>
		[ColumnAttribute(Storage="_FirmaNaziv", DbType="NVarChar(255)", CanBeNull=true)]
		public string FirmaNaziv
		{
			get
			{
				return this._FirmaNaziv;
			}
			set
			{
				if (this._FirmaNaziv != value)
				{
					this._FirmaNaziv = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=NVarChar(50)
		/// </summary>
		[ColumnAttribute(Storage="_RacunNaziv", DbType="NVarChar(50)", CanBeNull=true)]
		public string RacunNaziv
		{
			get
			{
				return this._RacunNaziv;
			}
			set
			{
				if (this._RacunNaziv != value)
				{
					this._RacunNaziv = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Bit
		/// </summary>
		[ColumnAttribute(Storage="_IsPersonal", DbType="Bit", CanBeNull=false)]
		public bool IsPersonal
		{
			get
			{
				return this._IsPersonal;
			}
			set
			{
				if (this._IsPersonal != value)
				{
					this._IsPersonal = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=VarChar(50)
		/// </summary>
		[ColumnAttribute(Storage="_IBAN", DbType="VarChar(50)", CanBeNull=false)]
		public string IBAN
		{
			get
			{
				return this._IBAN;
			}
			set
			{
				if (this._IBAN != value)
				{
					this._IBAN = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=VarChar(10)
		/// </summary>
		[ColumnAttribute(Storage="_Valuta", DbType="VarChar(10)", CanBeNull=true)]
		public string Valuta
		{
			get
			{
				return this._Valuta;
			}
			set
			{
				if (this._Valuta != value)
				{
					this._Valuta = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Money
		/// </summary>
		[ColumnAttribute(Storage="_Stanje", DbType="Money", CanBeNull=true)]
		public decimal? Stanje
		{
			get
			{
				return this._Stanje;
			}
			set
			{
				if (this._Stanje != value)
				{
					this._Stanje = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=NVarChar(4000)
		/// </summary>
		[ColumnAttribute(Storage="_StanjeFormated", DbType="NVarChar(4000)", CanBeNull=true)]
		public string StanjeFormated
		{
			get
			{
				return this._StanjeFormated;
			}
			set
			{
				if (this._StanjeFormated != value)
				{
					this._StanjeFormated = value;
				}
			}
		}
		
	}
	#endregion spGetBankaStanjeRacunaResult

	#region spGetBillClientByOibAndPozivNaBrojResult
	public partial class spGetBillClientByOibAndPozivNaBrojResult
	{
		#region Storage members
		private long _BillClientID;
		private DateTime _InsertionDate;
		private int _BillFirmaID;
		private int? _ArizonaClientID;
		private string _MBO;
		private string _MBS;
		private string _OIB;
		private string _Naziv;
		private string _Adresa;
		private string _Naselje;
		private string _PostanskiBroj;
		private string _PostanskiUred;
		private string _OdgovornaOsoba;
		private bool? _IsVlasnik;
		private string _IBAN;
		#endregion Storage members

		public spGetBillClientByOibAndPozivNaBrojResult(){ }

		/// <summary>
		/// Column DbType=BigInt
		/// </summary>
		[ColumnAttribute(Storage="_BillClientID", DbType="BigInt", CanBeNull=false)]
		public long BillClientID
		{
			get
			{
				return this._BillClientID;
			}
			set
			{
				if (this._BillClientID != value)
				{
					this._BillClientID = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=DateTime
		/// </summary>
		[ColumnAttribute(Storage="_InsertionDate", DbType="DateTime", CanBeNull=false)]
		public DateTime InsertionDate
		{
			get
			{
				return this._InsertionDate;
			}
			set
			{
				if (this._InsertionDate != value)
				{
					this._InsertionDate = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Int
		/// </summary>
		[ColumnAttribute(Storage="_BillFirmaID", DbType="Int", CanBeNull=false)]
		public int BillFirmaID
		{
			get
			{
				return this._BillFirmaID;
			}
			set
			{
				if (this._BillFirmaID != value)
				{
					this._BillFirmaID = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Int
		/// </summary>
		[ColumnAttribute(Storage="_ArizonaClientID", DbType="Int", CanBeNull=true)]
		public int? ArizonaClientID
		{
			get
			{
				return this._ArizonaClientID;
			}
			set
			{
				if (this._ArizonaClientID != value)
				{
					this._ArizonaClientID = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=VarChar(20)
		/// </summary>
		[ColumnAttribute(Storage="_MBO", DbType="VarChar(20)", CanBeNull=true)]
		public string MBO
		{
			get
			{
				return this._MBO;
			}
			set
			{
				if (this._MBO != value)
				{
					this._MBO = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=VarChar(20)
		/// </summary>
		[ColumnAttribute(Storage="_MBS", DbType="VarChar(20)", CanBeNull=true)]
		public string MBS
		{
			get
			{
				return this._MBS;
			}
			set
			{
				if (this._MBS != value)
				{
					this._MBS = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=VarChar(20)
		/// </summary>
		[ColumnAttribute(Storage="_OIB", DbType="VarChar(20)", CanBeNull=true)]
		public string OIB
		{
			get
			{
				return this._OIB;
			}
			set
			{
				if (this._OIB != value)
				{
					this._OIB = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=NVarChar(250)
		/// </summary>
		[ColumnAttribute(Storage="_Naziv", DbType="NVarChar(250)", CanBeNull=true)]
		public string Naziv
		{
			get
			{
				return this._Naziv;
			}
			set
			{
				if (this._Naziv != value)
				{
					this._Naziv = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=NVarChar(250)
		/// </summary>
		[ColumnAttribute(Storage="_Adresa", DbType="NVarChar(250)", CanBeNull=true)]
		public string Adresa
		{
			get
			{
				return this._Adresa;
			}
			set
			{
				if (this._Adresa != value)
				{
					this._Adresa = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=NVarChar(250)
		/// </summary>
		[ColumnAttribute(Storage="_Naselje", DbType="NVarChar(250)", CanBeNull=true)]
		public string Naselje
		{
			get
			{
				return this._Naselje;
			}
			set
			{
				if (this._Naselje != value)
				{
					this._Naselje = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=NVarChar(50)
		/// </summary>
		[ColumnAttribute(Storage="_PostanskiBroj", DbType="NVarChar(50)", CanBeNull=true)]
		public string PostanskiBroj
		{
			get
			{
				return this._PostanskiBroj;
			}
			set
			{
				if (this._PostanskiBroj != value)
				{
					this._PostanskiBroj = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=NVarChar(250)
		/// </summary>
		[ColumnAttribute(Storage="_PostanskiUred", DbType="NVarChar(250)", CanBeNull=true)]
		public string PostanskiUred
		{
			get
			{
				return this._PostanskiUred;
			}
			set
			{
				if (this._PostanskiUred != value)
				{
					this._PostanskiUred = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=NVarChar(100)
		/// </summary>
		[ColumnAttribute(Storage="_OdgovornaOsoba", DbType="NVarChar(100)", CanBeNull=true)]
		public string OdgovornaOsoba
		{
			get
			{
				return this._OdgovornaOsoba;
			}
			set
			{
				if (this._OdgovornaOsoba != value)
				{
					this._OdgovornaOsoba = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Bit
		/// </summary>
		[ColumnAttribute(Storage="_IsVlasnik", DbType="Bit", CanBeNull=true)]
		public bool? IsVlasnik
		{
			get
			{
				return this._IsVlasnik;
			}
			set
			{
				if (this._IsVlasnik != value)
				{
					this._IsVlasnik = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=VarChar(50)
		/// </summary>
		[ColumnAttribute(Storage="_IBAN", DbType="VarChar(50)", CanBeNull=true)]
		public string IBAN
		{
			get
			{
				return this._IBAN;
			}
			set
			{
				if (this._IBAN != value)
				{
					this._IBAN = value;
				}
			}
		}
		
	}
	#endregion spGetBillClientByOibAndPozivNaBrojResult

	#region spGetDbccValuesResult
	public partial class spGetDbccValuesResult
	{
		#region Storage members
		private string _Name;
		private string _Value;
		#endregion Storage members

		public spGetDbccValuesResult(){ }

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
					this._Name = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=NVarChar(100)
		/// </summary>
		[ColumnAttribute(Storage="_Value", DbType="NVarChar(100)", CanBeNull=true)]
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
	#endregion spGetDbccValuesResult

	#region spGetDocumentsForFiskaliziranjeResult
	public partial class spGetDocumentsForFiskaliziranjeResult
	{
		#region Storage members
		private long? _num;
		private long _BillDocumentID;
		private int? _BillFirmaID;
		private int _RedniBroj;
		private string _PozivNaBroj;
		private DateTime _DatumDokumenta;
		#endregion Storage members

		public spGetDocumentsForFiskaliziranjeResult(){ }

		/// <summary>
		/// Column DbType=BigInt
		/// </summary>
		[ColumnAttribute(Storage="_num", DbType="BigInt", CanBeNull=true)]
		public long? num
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
		/// Column DbType=BigInt
		/// </summary>
		[ColumnAttribute(Storage="_BillDocumentID", DbType="BigInt", CanBeNull=false)]
		public long BillDocumentID
		{
			get
			{
				return this._BillDocumentID;
			}
			set
			{
				if (this._BillDocumentID != value)
				{
					this._BillDocumentID = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Int
		/// </summary>
		[ColumnAttribute(Storage="_BillFirmaID", DbType="Int", CanBeNull=true)]
		public int? BillFirmaID
		{
			get
			{
				return this._BillFirmaID;
			}
			set
			{
				if (this._BillFirmaID != value)
				{
					this._BillFirmaID = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Int
		/// </summary>
		[ColumnAttribute(Storage="_RedniBroj", DbType="Int", CanBeNull=false)]
		public int RedniBroj
		{
			get
			{
				return this._RedniBroj;
			}
			set
			{
				if (this._RedniBroj != value)
				{
					this._RedniBroj = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=VarChar(50)
		/// </summary>
		[ColumnAttribute(Storage="_PozivNaBroj", DbType="VarChar(50)", CanBeNull=false)]
		public string PozivNaBroj
		{
			get
			{
				return this._PozivNaBroj;
			}
			set
			{
				if (this._PozivNaBroj != value)
				{
					this._PozivNaBroj = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=DateTime
		/// </summary>
		[ColumnAttribute(Storage="_DatumDokumenta", DbType="DateTime", CanBeNull=false)]
		public DateTime DatumDokumenta
		{
			get
			{
				return this._DatumDokumenta;
			}
			set
			{
				if (this._DatumDokumenta != value)
				{
					this._DatumDokumenta = value;
				}
			}
		}
		
	}
	#endregion spGetDocumentsForFiskaliziranjeResult

	#region spGetDocumentsForPaymentsResult
	public partial class spGetDocumentsForPaymentsResult
	{
		#region Storage members
		private long? _num;
		private long _BillDocumentID;
		private long _BillClientID;
		private long? _ParentBillDocumentID;
		private long _BillNaplatniUredjajID;
		private int _RedniBroj;
		private string _PozivNaBroj;
		private DateTime _DatumDokumenta;
		private DateTime _DatumValute;
		private DateTime _DatumDospijeca;
		private int? _BrojDanaZaUplatu;
		private DateTime? _DatumUplate;
		private DateTime? _PoslanKupcuDatum;
		private string _ZKI;
		private string _JIR;
		private int? _VariantID;
		private bool _IsInPdvSustav;
		private long _AppMemberID;
		private bool _IsDeleted;
		private string _Napomena;
		private int? _FiskalTryCount;
		private bool _IsFiskalizacijaRequired;
		private string _KlijentNaziv;
		private string _DokumentTipNaziv;
		private string _OIB;
		#endregion Storage members

		public spGetDocumentsForPaymentsResult(){ }

		/// <summary>
		/// Column DbType=BigInt
		/// </summary>
		[ColumnAttribute(Storage="_num", DbType="BigInt", CanBeNull=true)]
		public long? num
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
		/// Column DbType=BigInt
		/// </summary>
		[ColumnAttribute(Storage="_BillDocumentID", DbType="BigInt", CanBeNull=false)]
		public long BillDocumentID
		{
			get
			{
				return this._BillDocumentID;
			}
			set
			{
				if (this._BillDocumentID != value)
				{
					this._BillDocumentID = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=BigInt
		/// </summary>
		[ColumnAttribute(Storage="_BillClientID", DbType="BigInt", CanBeNull=false)]
		public long BillClientID
		{
			get
			{
				return this._BillClientID;
			}
			set
			{
				if (this._BillClientID != value)
				{
					this._BillClientID = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=BigInt
		/// </summary>
		[ColumnAttribute(Storage="_ParentBillDocumentID", DbType="BigInt", CanBeNull=true)]
		public long? ParentBillDocumentID
		{
			get
			{
				return this._ParentBillDocumentID;
			}
			set
			{
				if (this._ParentBillDocumentID != value)
				{
					this._ParentBillDocumentID = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=BigInt
		/// </summary>
		[ColumnAttribute(Storage="_BillNaplatniUredjajID", DbType="BigInt", CanBeNull=false)]
		public long BillNaplatniUredjajID
		{
			get
			{
				return this._BillNaplatniUredjajID;
			}
			set
			{
				if (this._BillNaplatniUredjajID != value)
				{
					this._BillNaplatniUredjajID = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Int
		/// </summary>
		[ColumnAttribute(Storage="_RedniBroj", DbType="Int", CanBeNull=false)]
		public int RedniBroj
		{
			get
			{
				return this._RedniBroj;
			}
			set
			{
				if (this._RedniBroj != value)
				{
					this._RedniBroj = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=VarChar(50)
		/// </summary>
		[ColumnAttribute(Storage="_PozivNaBroj", DbType="VarChar(50)", CanBeNull=false)]
		public string PozivNaBroj
		{
			get
			{
				return this._PozivNaBroj;
			}
			set
			{
				if (this._PozivNaBroj != value)
				{
					this._PozivNaBroj = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=DateTime
		/// </summary>
		[ColumnAttribute(Storage="_DatumDokumenta", DbType="DateTime", CanBeNull=false)]
		public DateTime DatumDokumenta
		{
			get
			{
				return this._DatumDokumenta;
			}
			set
			{
				if (this._DatumDokumenta != value)
				{
					this._DatumDokumenta = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=DateTime
		/// </summary>
		[ColumnAttribute(Storage="_DatumValute", DbType="DateTime", CanBeNull=false)]
		public DateTime DatumValute
		{
			get
			{
				return this._DatumValute;
			}
			set
			{
				if (this._DatumValute != value)
				{
					this._DatumValute = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=DateTime
		/// </summary>
		[ColumnAttribute(Storage="_DatumDospijeca", DbType="DateTime", CanBeNull=false)]
		public DateTime DatumDospijeca
		{
			get
			{
				return this._DatumDospijeca;
			}
			set
			{
				if (this._DatumDospijeca != value)
				{
					this._DatumDospijeca = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Int
		/// </summary>
		[ColumnAttribute(Storage="_BrojDanaZaUplatu", DbType="Int", CanBeNull=true)]
		public int? BrojDanaZaUplatu
		{
			get
			{
				return this._BrojDanaZaUplatu;
			}
			set
			{
				if (this._BrojDanaZaUplatu != value)
				{
					this._BrojDanaZaUplatu = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=DateTime
		/// </summary>
		[ColumnAttribute(Storage="_DatumUplate", DbType="DateTime", CanBeNull=true)]
		public DateTime? DatumUplate
		{
			get
			{
				return this._DatumUplate;
			}
			set
			{
				if (this._DatumUplate != value)
				{
					this._DatumUplate = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=DateTime
		/// </summary>
		[ColumnAttribute(Storage="_PoslanKupcuDatum", DbType="DateTime", CanBeNull=true)]
		public DateTime? PoslanKupcuDatum
		{
			get
			{
				return this._PoslanKupcuDatum;
			}
			set
			{
				if (this._PoslanKupcuDatum != value)
				{
					this._PoslanKupcuDatum = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=VarChar(100)
		/// </summary>
		[ColumnAttribute(Storage="_ZKI", DbType="VarChar(100)", CanBeNull=true)]
		public string ZKI
		{
			get
			{
				return this._ZKI;
			}
			set
			{
				if (this._ZKI != value)
				{
					this._ZKI = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=VarChar(100)
		/// </summary>
		[ColumnAttribute(Storage="_JIR", DbType="VarChar(100)", CanBeNull=true)]
		public string JIR
		{
			get
			{
				return this._JIR;
			}
			set
			{
				if (this._JIR != value)
				{
					this._JIR = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Int
		/// </summary>
		[ColumnAttribute(Storage="_VariantID", DbType="Int", CanBeNull=true)]
		public int? VariantID
		{
			get
			{
				return this._VariantID;
			}
			set
			{
				if (this._VariantID != value)
				{
					this._VariantID = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Bit
		/// </summary>
		[ColumnAttribute(Storage="_IsInPdvSustav", DbType="Bit", CanBeNull=false)]
		public bool IsInPdvSustav
		{
			get
			{
				return this._IsInPdvSustav;
			}
			set
			{
				if (this._IsInPdvSustav != value)
				{
					this._IsInPdvSustav = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=BigInt
		/// </summary>
		[ColumnAttribute(Storage="_AppMemberID", DbType="BigInt", CanBeNull=false)]
		public long AppMemberID
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
		/// Column DbType=Bit
		/// </summary>
		[ColumnAttribute(Storage="_IsDeleted", DbType="Bit", CanBeNull=false)]
		public bool IsDeleted
		{
			get
			{
				return this._IsDeleted;
			}
			set
			{
				if (this._IsDeleted != value)
				{
					this._IsDeleted = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=NVarChar(500)
		/// </summary>
		[ColumnAttribute(Storage="_Napomena", DbType="NVarChar(500)", CanBeNull=true)]
		public string Napomena
		{
			get
			{
				return this._Napomena;
			}
			set
			{
				if (this._Napomena != value)
				{
					this._Napomena = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Int
		/// </summary>
		[ColumnAttribute(Storage="_FiskalTryCount", DbType="Int", CanBeNull=true)]
		public int? FiskalTryCount
		{
			get
			{
				return this._FiskalTryCount;
			}
			set
			{
				if (this._FiskalTryCount != value)
				{
					this._FiskalTryCount = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Bit
		/// </summary>
		[ColumnAttribute(Storage="_IsFiskalizacijaRequired", DbType="Bit", CanBeNull=false)]
		public bool IsFiskalizacijaRequired
		{
			get
			{
				return this._IsFiskalizacijaRequired;
			}
			set
			{
				if (this._IsFiskalizacijaRequired != value)
				{
					this._IsFiskalizacijaRequired = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=NVarChar(250)
		/// </summary>
		[ColumnAttribute(Storage="_KlijentNaziv", DbType="NVarChar(250)", CanBeNull=true)]
		public string KlijentNaziv
		{
			get
			{
				return this._KlijentNaziv;
			}
			set
			{
				if (this._KlijentNaziv != value)
				{
					this._KlijentNaziv = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=NVarChar(255)
		/// </summary>
		[ColumnAttribute(Storage="_DokumentTipNaziv", DbType="NVarChar(255)", CanBeNull=true)]
		public string DokumentTipNaziv
		{
			get
			{
				return this._DokumentTipNaziv;
			}
			set
			{
				if (this._DokumentTipNaziv != value)
				{
					this._DokumentTipNaziv = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=VarChar(20)
		/// </summary>
		[ColumnAttribute(Storage="_OIB", DbType="VarChar(20)", CanBeNull=true)]
		public string OIB
		{
			get
			{
				return this._OIB;
			}
			set
			{
				if (this._OIB != value)
				{
					this._OIB = value;
				}
			}
		}
		
	}
	#endregion spGetDocumentsForPaymentsResult

	#region spGetJobAdvertsResult
	public partial class spGetJobAdvertsResult
	{
		#region Storage members
		private int _JobAdvertID;
		private string _JobName;
		private string _CompanyName;
		private DateTime? _StartDate;
		private DateTime? _EndDate;
		#endregion Storage members

		public spGetJobAdvertsResult(){ }

		/// <summary>
		/// Column DbType=Int
		/// </summary>
		[ColumnAttribute(Storage="_JobAdvertID", DbType="Int", CanBeNull=false)]
		public int JobAdvertID
		{
			get
			{
				return this._JobAdvertID;
			}
			set
			{
				if (this._JobAdvertID != value)
				{
					this._JobAdvertID = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=NVarChar(150)
		/// </summary>
		[ColumnAttribute(Storage="_JobName", DbType="NVarChar(150)", CanBeNull=true)]
		public string JobName
		{
			get
			{
				return this._JobName;
			}
			set
			{
				if (this._JobName != value)
				{
					this._JobName = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=NVarChar(255)
		/// </summary>
		[ColumnAttribute(Storage="_CompanyName", DbType="NVarChar(255)", CanBeNull=true)]
		public string CompanyName
		{
			get
			{
				return this._CompanyName;
			}
			set
			{
				if (this._CompanyName != value)
				{
					this._CompanyName = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=DateTime
		/// </summary>
		[ColumnAttribute(Storage="_StartDate", DbType="DateTime", CanBeNull=true)]
		public DateTime? StartDate
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
					this._EndDate = value;
				}
			}
		}
		
	}
	#endregion spGetJobAdvertsResult

	#region spGetPoreziInfoExtendedResult1
	public partial class spGetPoreziInfoExtendedResult1
	{
		#region Storage members
		private DateTime _DatumValute;
		private int _BillPorezPdvID;
		private bool _IsActive;
		private int? _Ordinal;
		private bool _IsDefault;
		private string _Naziv;
		private string _PrintableText;
		private string _Opis;
		private string _PrintableTextPercent;
		private int _BillPorezPdvPostotakID;
		private decimal _PdvPosto;
		private DateTime _StartDatum;
		private DateTime? _EndDatum;
		#endregion Storage members

		public spGetPoreziInfoExtendedResult1(){ }

		/// <summary>
		/// Column DbType=DateTime
		/// </summary>
		[ColumnAttribute(Storage="_DatumValute", DbType="DateTime", CanBeNull=false)]
		public DateTime DatumValute
		{
			get
			{
				return this._DatumValute;
			}
			set
			{
				if (this._DatumValute != value)
				{
					this._DatumValute = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Int
		/// </summary>
		[ColumnAttribute(Storage="_BillPorezPdvID", DbType="Int", CanBeNull=false)]
		public int BillPorezPdvID
		{
			get
			{
				return this._BillPorezPdvID;
			}
			set
			{
				if (this._BillPorezPdvID != value)
				{
					this._BillPorezPdvID = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Bit
		/// </summary>
		[ColumnAttribute(Storage="_IsActive", DbType="Bit", CanBeNull=false)]
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
					this._IsActive = value;
				}
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
					this._Ordinal = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Bit
		/// </summary>
		[ColumnAttribute(Storage="_IsDefault", DbType="Bit", CanBeNull=false)]
		public bool IsDefault
		{
			get
			{
				return this._IsDefault;
			}
			set
			{
				if (this._IsDefault != value)
				{
					this._IsDefault = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=NVarChar(150)
		/// </summary>
		[ColumnAttribute(Storage="_Naziv", DbType="NVarChar(150)", CanBeNull=false)]
		public string Naziv
		{
			get
			{
				return this._Naziv;
			}
			set
			{
				if (this._Naziv != value)
				{
					this._Naziv = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=NVarChar(250)
		/// </summary>
		[ColumnAttribute(Storage="_PrintableText", DbType="NVarChar(250)", CanBeNull=true)]
		public string PrintableText
		{
			get
			{
				return this._PrintableText;
			}
			set
			{
				if (this._PrintableText != value)
				{
					this._PrintableText = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=NVarChar(MAX)
		/// </summary>
		[ColumnAttribute(Storage="_Opis", DbType="NVarChar(MAX)", CanBeNull=true)]
		public string Opis
		{
			get
			{
				return this._Opis;
			}
			set
			{
				if (this._Opis != value)
				{
					this._Opis = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=NVarChar(200)
		/// </summary>
		[ColumnAttribute(Storage="_PrintableTextPercent", DbType="NVarChar(200)", CanBeNull=true)]
		public string PrintableTextPercent
		{
			get
			{
				return this._PrintableTextPercent;
			}
			set
			{
				if (this._PrintableTextPercent != value)
				{
					this._PrintableTextPercent = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Int
		/// </summary>
		[ColumnAttribute(Storage="_BillPorezPdvPostotakID", DbType="Int", CanBeNull=false)]
		public int BillPorezPdvPostotakID
		{
			get
			{
				return this._BillPorezPdvPostotakID;
			}
			set
			{
				if (this._BillPorezPdvPostotakID != value)
				{
					this._BillPorezPdvPostotakID = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Money
		/// </summary>
		[ColumnAttribute(Storage="_PdvPosto", DbType="Money", CanBeNull=false)]
		public decimal PdvPosto
		{
			get
			{
				return this._PdvPosto;
			}
			set
			{
				if (this._PdvPosto != value)
				{
					this._PdvPosto = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=DateTime
		/// </summary>
		[ColumnAttribute(Storage="_StartDatum", DbType="DateTime", CanBeNull=false)]
		public DateTime StartDatum
		{
			get
			{
				return this._StartDatum;
			}
			set
			{
				if (this._StartDatum != value)
				{
					this._StartDatum = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=DateTime
		/// </summary>
		[ColumnAttribute(Storage="_EndDatum", DbType="DateTime", CanBeNull=true)]
		public DateTime? EndDatum
		{
			get
			{
				return this._EndDatum;
			}
			set
			{
				if (this._EndDatum != value)
				{
					this._EndDatum = value;
				}
			}
		}
		
	}
	#endregion spGetPoreziInfoExtendedResult1

	#region spGetPoreziInfoExtendedResult2
	public partial class spGetPoreziInfoExtendedResult2
	{
		#region Storage members
		private DateTime _DatumValute;
		private int _BillPorezPotrosnjaID;
		private bool _IsActive;
		private int? _Ordinal;
		private bool _IsDefault;
		private string _Naziv;
		private string _PrintableText;
		private string _Opis;
		private string _PrintableTextPercent;
		private int _BillPorezPotrosnjaPostotakID;
		private decimal _PorezPosto;
		private DateTime _StartDatum;
		private DateTime? _EndDatum;
		#endregion Storage members

		public spGetPoreziInfoExtendedResult2(){ }

		/// <summary>
		/// Column DbType=DateTime
		/// </summary>
		[ColumnAttribute(Storage="_DatumValute", DbType="DateTime", CanBeNull=false)]
		public DateTime DatumValute
		{
			get
			{
				return this._DatumValute;
			}
			set
			{
				if (this._DatumValute != value)
				{
					this._DatumValute = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Int
		/// </summary>
		[ColumnAttribute(Storage="_BillPorezPotrosnjaID", DbType="Int", CanBeNull=false)]
		public int BillPorezPotrosnjaID
		{
			get
			{
				return this._BillPorezPotrosnjaID;
			}
			set
			{
				if (this._BillPorezPotrosnjaID != value)
				{
					this._BillPorezPotrosnjaID = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Bit
		/// </summary>
		[ColumnAttribute(Storage="_IsActive", DbType="Bit", CanBeNull=false)]
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
					this._IsActive = value;
				}
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
					this._Ordinal = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Bit
		/// </summary>
		[ColumnAttribute(Storage="_IsDefault", DbType="Bit", CanBeNull=false)]
		public bool IsDefault
		{
			get
			{
				return this._IsDefault;
			}
			set
			{
				if (this._IsDefault != value)
				{
					this._IsDefault = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=NVarChar(150)
		/// </summary>
		[ColumnAttribute(Storage="_Naziv", DbType="NVarChar(150)", CanBeNull=false)]
		public string Naziv
		{
			get
			{
				return this._Naziv;
			}
			set
			{
				if (this._Naziv != value)
				{
					this._Naziv = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=NVarChar(250)
		/// </summary>
		[ColumnAttribute(Storage="_PrintableText", DbType="NVarChar(250)", CanBeNull=true)]
		public string PrintableText
		{
			get
			{
				return this._PrintableText;
			}
			set
			{
				if (this._PrintableText != value)
				{
					this._PrintableText = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=NVarChar(MAX)
		/// </summary>
		[ColumnAttribute(Storage="_Opis", DbType="NVarChar(MAX)", CanBeNull=true)]
		public string Opis
		{
			get
			{
				return this._Opis;
			}
			set
			{
				if (this._Opis != value)
				{
					this._Opis = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=NVarChar(200)
		/// </summary>
		[ColumnAttribute(Storage="_PrintableTextPercent", DbType="NVarChar(200)", CanBeNull=true)]
		public string PrintableTextPercent
		{
			get
			{
				return this._PrintableTextPercent;
			}
			set
			{
				if (this._PrintableTextPercent != value)
				{
					this._PrintableTextPercent = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Int
		/// </summary>
		[ColumnAttribute(Storage="_BillPorezPotrosnjaPostotakID", DbType="Int", CanBeNull=false)]
		public int BillPorezPotrosnjaPostotakID
		{
			get
			{
				return this._BillPorezPotrosnjaPostotakID;
			}
			set
			{
				if (this._BillPorezPotrosnjaPostotakID != value)
				{
					this._BillPorezPotrosnjaPostotakID = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=Money
		/// </summary>
		[ColumnAttribute(Storage="_PorezPosto", DbType="Money", CanBeNull=false)]
		public decimal PorezPosto
		{
			get
			{
				return this._PorezPosto;
			}
			set
			{
				if (this._PorezPosto != value)
				{
					this._PorezPosto = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=DateTime
		/// </summary>
		[ColumnAttribute(Storage="_StartDatum", DbType="DateTime", CanBeNull=false)]
		public DateTime StartDatum
		{
			get
			{
				return this._StartDatum;
			}
			set
			{
				if (this._StartDatum != value)
				{
					this._StartDatum = value;
				}
			}
		}
		
		/// <summary>
		/// Column DbType=DateTime
		/// </summary>
		[ColumnAttribute(Storage="_EndDatum", DbType="DateTime", CanBeNull=true)]
		public DateTime? EndDatum
		{
			get
			{
				return this._EndDatum;
			}
			set
			{
				if (this._EndDatum != value)
				{
					this._EndDatum = value;
				}
			}
		}
		
	}
	#endregion spGetPoreziInfoExtendedResult2

	#region spGetPozivDestinationPhoneResult
	public partial class spGetPozivDestinationPhoneResult
	{
		#region Storage members
		private string _Column1;
		#endregion Storage members

		public spGetPozivDestinationPhoneResult(){ }

		/// <summary>
		/// Column DbType=VarChar(12)
		/// </summary>
		[ColumnAttribute(Storage="_Column1", DbType="VarChar(12)", CanBeNull=false)]
		public string Column1
		{
			get
			{
				return this._Column1;
			}
			set
			{
				if (this._Column1 != value)
				{
					this._Column1 = value;
				}
			}
		}
		
	}
	#endregion spGetPozivDestinationPhoneResult

	#endregion Entity Return types

}
#pragma warning restore 1591
