using Calysto.Globalization;

namespace CalystoWebTests.Calysto.Web.UI.Direct.Models
{
    public class Registar : ICalystoResx
    {
		private Registar(){ }

		static string[] _columns = new string[] { "property", "en-US", "hr-HR", "eRegistarHR_hr-HR", "ePoduzetnikHR_hr-HR", "DigitalnaPlatformaHR_hr-HR" };

		const string _json = "{\"__calystotype\":\"Calysto_DataTable\",\"TotalCount\":null,\"TableName\":\"\",\"Columns\":[\"property\",\"en-US\",\"hr-HR\",\"eRegistarHR_hr-HR\",\"ePoduzetnikHR_hr-HR\",\"DigitalnaPlatformaHR_hr-HR\"],\"Rows\":[[\"Accept\",\"Accept\",\"Prihvaćam\",null,null,null],[\"AddDocumentButton\",\"Add document\",\"Dodaj dokument\",null,null,null],[\"AdditionalInformations\",\"Additional informations\",\"Dodatne informacije\",null,null,null],[\"AddPhotoButton\",\"Add photo\",\"Dodaj foto\",null,null,null],[\"Address\",\"Address\",\"Adresa\",null,null,null],[\"AktivacijaFiskalneBlagajne\",\"POS Activation\",\"Aktivacija blagajne\",null,null,null],[\"AllRightsReservedText\",\"All rights reserved.\",\"Sva prava pridržana.\",null,null,null],[\"Amount\",\"Amount\",\"Iznos\",null,null,null],[\"AtLeastOnePhotoIsRequired\",\"At least one photo is required\",\"Najmanje jedna fotografija je obavezna\",null,null,null],[\"BadgesAssigned\",\"Badges assigned\",\"Dodijeljeni bedževi\",null,null,null],[\"BadgesAssignmentAndSearcEnginesRankingExplanation\",\"Badgets assignement and search engines ranking is in relation with data entered. For better result, all data should be entered and you should have quality photos, recommended 600 x 600 pixels.\",\"Dodjela bedževa i rangiranje na tražilicama direktno ovisi o popunjenosti podataka, stoga je preporučljivo da svi podaci budu popunjeni te da budu dodane kvalitetne fotografije, najmanje 600 x 600 pixela.\",null,null,null],[\"BadgetsExplanation\",\"Badges are shown in search results and at your public page.\",\"Bedževi se prikazuju na rezultatima pretrage, kao i na Vašoj javnoj stranici na portalu.\",null,null,null],[\"BirthDateInvalid\",\"Birth date is not valid\",\"Datum rođenja nije ispravan\",null,null,null],[\"BirthDateOutOfRange\",\"Birth data is out of range\",\"Datum rođenja je izvan dopuštenih vrijednosti\",null,null,null],[\"BlagajnaInfoLinkName\",\"POS info\",\"Fiskalna blagajna\",null,null,null],[\"BlagajnaInfoPageTitle\",\"POS info\",\"Fiskalna blagajna\",null,null,null],[\"BlagajnaInfoUrlPath\",\"/pos\",\"/blagajna\",null,null,null],[\"BlagajnaRegistrationLinkName\",\"POS - registration\",\"Fiskalna blagajna - registracija\",null,null,null],[\"BlagajnaRegistrationPageTitle\",\"POS - registration\",\"Fiskalna blagajna - registracija\",null,null,null],[\"BlagajnaRegistrationUrlPath\",\"/pos-registration\",\"/blagajna-registracija\",null,null,null],[\"BusinessData\",\"Business data\",\"Poslovni podaci\",null,null,null],[\"BusinessList\",\"Business list\",\"Popis\",null,null,null],[\"BusinessListLinkName\",\"Business list\",\"Popis\",null,null,null],[\"BusinessListPageTitle\",\"Business list\",\"Popis\",null,null,null],[\"BusinessListUrlPath\",\"/business\",\"/popis\",null,null,null],[\"ByBusiness\",\"By business\",\"Prema djelatnosti\",null,null,null],[\"ChangeCity\",\"Change City\",\"Promijeni grad\",null,null,null],[\"CheckDetails\",\"Check details\",\"Pogledaj detalje\",null,null,null],[\"CheckingPleaseWait\",\"Checking, please wait...\",\"Provjera u tijeku, pričekajte...\",null,null,null],[\"CityWhereYouAreLivingForReal\",\"CityWhereYouAreLivingForReal\",\"Grad ili mjesto gdje zaista stanujete, neovisno o adresi u osobnoj iskaznici.\",null,null,null],[\"Close\",\"Close\",\"Zatvori\",null,null,null],[\"Companies\",\"Companies\",\"Tvrtke/obrti\",null,null,null],[\"CompaniesByCategories\",\"Companies by categories\",\"Poduzetnici po djelatnostima\",\"Gospodarstvenici po djelatnostima\",\"Poduzetnici po djelatnostima\",\"Poduzetnici po djelatnostima\"],[\"CompaniesListButtonText\",\"BUSINESS LIST\",\"POPIS DJELATNOSTI\",null,null,null],[\"CompaniesListLinkName\",\"Companies list\",\"Popis djelatnosti\",null,null,null],[\"CompaniesListPageTitle\",\"Companies list\",\"Popis djelatnosti\",null,null,null],[\"CompaniesListUrlPath\",\"/companies-list\",\"/djelatnost\",null,null,null],[\"CompanyCantBeFoundByEnteredData\",\"Company can\\u0027t be found by entered data.\\r\\nPlease check your data or send e-mail to customer support.\",\"Tvtku s navedenim OIB-om ne pronalazimo nigdje.\\r\\nMolimo provjerite OIB ili pošaljite obavijest na e-mail korisničke podrške.\",null,null,null],[\"CompanyDataLinkName\",\"Company data\",\"Podaci\",null,null,null],[\"CompanyDataPageTitle\",\"Company data\",\"Uređivanje podataka\",null,null,null],[\"CompanyDataUrlPath\",\"/company-data\",\"/podaci\",null,null,null],[\"CompanyLinkName\",\"Company\",\"Tvrtka\",null,null,null],[\"CompanyLogin\",\"Company login\",\"Prijava tvrtke\",null,null,null],[\"CompanyLogout\",\"Company logout\",\"Odjava tvrtke\",null,null,null],[\"CompanyName\",\"Company Name\",\"Naziv tvrtke ili obrta\",null,null,null],[\"CompanyPageTitle\",\"Company\",\"Tvrtka\",null,null,null],[\"CompanyRegistrationDescription\",null,null,\"\\u003cp\\u003e\\n\\tVaša tvrtka još nije upisana u sustav eRegistar.hr?\\n\\u003c/p\\u003e\\n\\u003cp\\u003e\\n\\tMolimo popunite podatke o gospodarstveniku (tvrtci ili obrtu). Po unesenim i poslanim podacima, odmah će se generirati i prikazati ponuda s uputom za plaćanje.\\n\\u003c/p\\u003e\\n\\u003cp\\u003e\\n\\tUpis gospodarstvenika u sustav eRegistar.hr biti će proveden po zaprimljenoj uplati te će se aktivirati sljedeće usluge:\\n\\u003cul\\u003e\\n\\t\\u003cli\\u003einternetska stranica gospodarstvenika unutar portala eRegistar.hr\\u003c/li\\u003e\\n\\t\\u003cli\\u003emogućnost samostalnog ažuriranja podataka o tvrtci\\u003c/li\\u003e\\n\\t\\u003cli\\u003eSEO stranice gospodarstvenika unutar portala eRegistar.hr\\u003c/li\\u003e\\n\\t\\u003cli\\u003edostupnost podataka o gospodarstveniku putem internetskih tražilica\\u003c/li\\u003e\\n\\t\\u003cli\\u003efiskalna blagajna, sukladno Zakonu o fiskalizaciji\\u003c/li\\u003e\\n\\u003c/ul\\u003e\\n\\u003c/p\\u003e\",\"\\u003cp\\u003e\\n\\tVaša tvrtka još nije upisana u sustav ePoduzetnik.hr?\\n\\u003c/p\\u003e\\n\\u003cp\\u003e\\n\\tMolimo popunite podatke o poduzetniku (tvrtci ili obrtu). Po unesenim i poslanim podacima, odmah će se generirati i prikazati ponuda s uputom za plaćanje.\\n\\u003c/p\\u003e\\n\\u003cp\\u003e\\n\\tUpis poduzetnika u sustav ePoduzetnik.hr biti će proveden po zaprimljenoj uplati te će se aktivirati sljedeće usluge:\\n\\u003cul\\u003e\\n\\t\\u003cli\\u003einternetska stranica poduzetnika unutar portala ePoduzetnik.hr\\u003c/li\\u003e\\n\\t\\u003cli\\u003emogućnost samostalnog ažuriranja podataka o tvrtci\\u003c/li\\u003e\\n\\t\\u003cli\\u003eSEO stranice poduzetnika unutar portala ePoduzetnik.hr\\u003c/li\\u003e\\n\\t\\u003cli\\u003edostupnost podataka o poduzetniku putem internetskih tražilica\\u003c/li\\u003e\\n\\t\\u003cli\\u003efiskalna blagajna, sukladno Zakonu o fiskalizaciji\\u003c/li\\u003e\\n\\u003c/ul\\u003e\\n\\u003c/p\\u003e\",\"\\u003cp\\u003e\\n\\tVaša tvrtka još nije upisana u sustav DigitalnaPlatforma.hr?\\n\\u003c/p\\u003e\\n\\u003cp\\u003e\\n\\tMolimo popunite podatke o poduzetniku (tvrtci ili obrtu). Po unesenim i poslanim podacima, odmah će se generirati i prikazati ponuda s uputom za plaćanje.\\n\\u003c/p\\u003e\\n\\u003cp\\u003e\\n\\tUpis poduzetnika u sustav DigitalnaPlatforma.hr biti će proveden po zaprimljenoj uplati te će se aktivirati sljedeće usluge:\\n\\u003cul\\u003e\\n\\t\\u003cli\\u003einternetska stranica poduzetnika unutar portala DigitalnaPlatforma.hr\\u003c/li\\u003e\\n\\t\\u003cli\\u003emogućnost samostalnog ažuriranja podataka o tvrtci\\u003c/li\\u003e\\n\\t\\u003cli\\u003eSEO stranice poduzetnika unutar portala DigitalnaPlatforma.hr\\u003c/li\\u003e\\n\\t\\u003cli\\u003edostupnost podataka o poduzetniku putem internetskih tražilica\\u003c/li\\u003e\\n\\t\\u003cli\\u003efiskalna blagajna, sukladno Zakonu o fiskalizaciji\\u003c/li\\u003e\\n\\u003c/ul\\u003e\\n\\u003c/p\\u003e\"],[\"CompanyUniqueNumber\",\"Company unique number\",\"OIB tvrtke ili obrta\",null,null,null],[\"CompanyUniqueNumberShort\",\"OIB\",\"OIB\",null,null,null],[\"CompanyUrlPath\",\"/company\",\"/tvrtka\",null,null,null],[\"CompanyWithEnteredOibAlreadyExistsContactSupport\",\"Company already exists.\\r\\nIf you don\\u0027t know how to login, please send e-mail to customer support.\",\"Tvrtka s navedenim OIB-om već je upisana.\\r\\nAko imate problema s prijavom, molimo da kontaktirate korisničku podršku putem e-maila.\",null,null,null],[\"ContactData\",\"Contact data\",\"Kontakt podaci\",null,null,null],[\"ContactForm\",\"Contact form\",\"Kontakt obrazac\",null,null,null],[\"ContactLinkName\",\"Contact\",\"Kontakt\",null,null,null],[\"ContactUrlPath\",\"/contact\",\"/kontakt\",null,null,null],[\"CookiePolicy\",\"Cookie Policy\",\"Uporaba kolačića (cookies)\",null,null,null],[\"CookiesWarningText\",\"We are using cookies for better customer experience. By continuing using the portal, you agree to the\",\"Koristimo kolačiće za ispravno funkcioniranje portala te za bolje korisničko iskustvo. Nastavkom uporabe portala, prihvaćate \",null,null,null],[\"Current\",\"Current\",\"Trenutno\",null,null,null],[\"CurrentlyThereIsNoDataAvailable\",\"Currently there is no data available\",\"Trenutno nema podataka\",null,null,null],[\"CustomerNotFound\",\"Customer not found\",\"Korisnik nije pronađen\",null,null,null],[\"CustomerSupport\",\"Customer support\",\"korisničku podršku\",null,null,null],[\"Daily\",\"Daily\",\"Po danu\",null,null,null],[\"DailyWeatherForecastLinkName\",\"Weather Forecast by Day\",\"Vremenska prognoza po danu\",null,null,null],[\"DailyWeatherForecastPageTitle\",\"Weather Forecast by Day\",\"Vremenska prognoza po danu\",null,null,null],[\"DailyWeatherForecastUrlPath\",\"/weather-forecast-by-day\",\"/vremenska-prognoza-po-danu\",null,\"/detaljna-vremenska-prognoza-po-danu\",\"/najbolja-vremenska-prognoza-po-danu\"],[\"DataSavedSucessfulyResultsDataWillBeRefreshedInFewMinutes\",\"Data saved successfuly. Search results data will be refreshed in few minutes.\",\"Podaci su uspješno spremljeni. Podaci u rezultatima pretrage će biti osvježeni kroz nekoliko minuta.\",null,null,null],[\"Date\",\"Date\",\"Datum\",null,null,null],[\"Day\",\"Day\",\"Dan\",null,null,null],[\"DeleteAreYouSure\",\"Delete, are you sure?\",\"Obrisati, jeste li sigurni?\",null,null,null],[\"Description\",\"Description\",\"Opis\",null,null,null],[\"DetailedWeatherForecast\",\"Detailed Weather Forecast\",\"Detaljna vremenska prognoza\",null,null,null],[\"Details\",\"Details\",\"Detalji\",null,null,null],[\"Djelatnosti\",\"Business\",\"Djelatnosti\",null,null,null],[\"DocumentRefNumber\",\"Document reference\",\"Poziv na broj\",null,null,null],[\"DocumentsAreInPdfFormatNotification\",\"Documents are in \\\"pdf\\\" format. To open and read it, it is required to have Adobe Reader installed.\",\"Dokumenti su u \\\"pdf\\\" formatu te je za otvaranje istih potrebno imati instaliran Adobe Reader ili neku drugu aplikaciju namijenjenju otvaranju i pregledavanju \\\"pdf\\\" formata.\",null,null,null],[\"DocumentsDownloadBlock2\",\"Bill is generated after payment is received and processed by our stuff and becomes available for download {0} working days after the payment is made. If bill is not visible after that period, please contact\",\"Račun se generira automatski po zaprimljenoj i obrađenoj uplati, te postaje dostupan za preuzimanje nakon {0} radnih dana od uplate. Ukoliko nakon tog roka račun nije vidljiv, molimo da kontaktirate\",null,null,null],[\"DocumentsFound\",\"Documents found\",\"Pronađeni dokumenti\",null,null,null],[\"DocumentsLinkName\",\"Documents\",\"Računi i dokumenti\",null,null,null],[\"DocumentsPageTitle\",\"Documents\",\"Preuzimanje računa i dokumenata\",null,null,null],[\"DocumentsUrlPath\",\"/documents\",\"/dokumenti\",null,null,null],[\"Download\",\"Download\",\"Preuzmi\",null,null,null],[\"DrzavaNaziv\",\"United Emirates\",\"Hrvatska\",null,null,null],[\"Duration\",\"Duration\",\"Trajanje\",null,null,null],[\"Email\",\"E-mail\",\"E-mail\",null,null,null],[\"EmailAddress\",\"Email Address\",\"E-mail adresa\",null,null,null],[\"EmailAddressCanNotBeRetrievedTryDifferentLoginMethod\",\"E-mail address can\\u0027t be retrieved, please try different login method.\",\"E-mail adresu nije moguće dohvatiti, molimo pokušajte neku drugu metodu za prijavu.\",null,null,null],[\"EmailHasToBeEntered\",\"Email has to be entered\",\"E-mail adresa mora biti upisana\",null,null,null],[\"EmailIsAlreadySubscribed\",\"E-mail is already subscribed\",\"E-mail je već predbilježen\",null,null,null],[\"EmailNotInValidFormat\",\"Not in valid format for an e-mail address\",\"Format nije ispravan za e-mail adresu\",null,null,null],[\"Employed\",\"Employed\",\"Zaposlen-a\",null,null,null],[\"EmploymentStatusOptions\",\"\\u003coption\\u003eStudent\\u003c/option\\u003e\\r\\n\\u003coption\\u003eUnemployed\\u003c/option\\u003e\\r\\n\\u003coption\\u003eEmployed\\u003c/option\\u003e\\r\\n\\u003coption\\u003eRetired\\u003c/option\\u003e\",\"\\u003coption\\u003eStudent-ica\\u003c/option\\u003e\\r\\n\\u003coption\\u003eNezaposlen-a\\u003c/option\\u003e\\r\\n\\u003coption\\u003eZaposlen-a\\u003c/option\\u003e\\r\\n\\u003coption\\u003eUmirovljenik-ica\\u003c/option\\u003e\",null,null,null],[\"EnterPassword\",\"Enter password\",\"Unesite lozinku\",null,null,null],[\"ErrorMobilePhoneEnterDigits\",\"Mobile phone, enter digits only\",\"Mobitel, upišite samo brojke\",null,null,null],[\"ErrorPleaseChangeYourWebBrowserAndTryAgain\",\"Error! Please use different web browser.\",\"Greška! Promijenite internet preglednik i pokušajte ponovo.\",null,null,null],[\"ErrorPostOfficeZIPDigitsOnly\",\"ZIP code, enter digits only\",\"Poštanski broj, upišite samo brojke\",null,null,null],[\"ErrorStreetNumberEnterDigits\",\"Street number, enter digits only\",\"Kućni broj, upišite samo brojke\",null,null,null],[\"EyeSightOptions\",\"\\u003coption\\u003eExcellent sight\\u003c/option\\u003e\\r\\n\\u003coption\\u003eNot so brilliant\\u003c/option\\u003e\\r\\n\\u003coption\\u003eBad sight\\u003c/option\\u003e\\r\\n\\u003coption\\u003eHave glasses\\u003c/option\\u003e\\r\\n\\u003coption\\u003eHave lens\\u003c/option\\u003e\",\"\\u003coption\\u003eOdično vidim\\u003c/option\\u003e\\r\\n\\u003coption\\u003eNe vidim baš dobro\\u003c/option\\u003e\\r\\n\\u003coption\\u003eLoše vidim\\u003c/option\\u003e\\r\\n\\u003coption\\u003eNosim naočale\\u003c/option\\u003e\\r\\n\\u003coption\\u003eNosim leće\\u003c/option\\u003e\",null,null,null],[\"FeelFreeToSendUsEmail\",\"Feel free to send us email to\",\"Uvijek nam možete poslati e-mail na\",null,null,null],[\"FiskalInfoLinkName\",\"Fiscalization\",\"Fiskalizacija\",null,null,null],[\"FiskalInfoPageTitle\",\"Fiscalization\",\"Fiskalna blagajna\",null,null,null],[\"FiskalInfoUrlPath\",\"/fiskal\",\"/fiskal\",null,null,null],[\"FiskalnaBlagajnaVideoTutorials\",null,null,\"\\u003cdiv\\u003e\\n\\t\\u003ch3\\u003eVIDEO UPUTE\\u003c/h3\\u003e\\n\\t\\u003cdiv\\u003e\\u003ca target=\\\"_blank\\\" href=\\\"https://www.youtube.com/watch?v=KRG8w9Uc83U\u0026list=PL8fNf757eZkW2dpn1hiCiKckl4YtlXmjA\\\"\\u003evideo upute - Youtube\\u003c/a\\u003e\\u003c/div\\u003e\\n\\u003c/div\\u003e\",\"\\u003cdiv\\u003e\\u003c/div\\u003e\",\"\\u003cdiv\\u003e\\n\\t\\u003ch3\\u003eVIDEO UPUTE\\u003c/h3\\u003e\\n\\t\\u003cdiv\\u003e\\u003ca target=\\\"_blank\\\" href=\\\"https://www.youtube.com/watch?v=KRG8w9Uc83U\u0026list=PL8fNf757eZkW2dpn1hiCiKckl4YtlXmjA\\\"\\u003evideo upute - Youtube\\u003c/a\\u003e\\u003c/div\\u003e\\n\\u003c/div\\u003e\"],[\"FiskalRegistrationLinkName\",\"Fiskal registration\",\"Aktivacija fiskalne blagajne\",null,null,null],[\"FiskalRegistrationPageTitle\",\"Fiskal registration\",\"Aktivacija fiskalne blagajne\",null,null,null],[\"FiskalRegistrationUrlPath\",\"/fiskal-registration\",\"/fiskal-registracija\",null,null,null],[\"FooterDescription\",null,null,\"Portalom eRegistar.hr upravlja trgovačko društvo Digitalna platforma d.o.o. registrirano pri Trgovačkom sudu u Zagrebu. Društvo Digitalna platforma d.o.o. u cijelosti je u privatnom vlasništvu te ni na koji način ne predstavlja i ne zastupa državne institucije. Podaci o gospodarstvenicima na portalu eRegistar.hr preuzeti su s javno dostupnih medija ili su uređivani od strane ovlaštenih osoba samih gospodarstvenika. Društvo Digitalna platforma d.o.o. podatke objavljuje na portalu eRegistar.hr u svrhu informiranja te ni na koji način ne može biti odgovorno za uporabu ili zlouporabu istih.\",\"Portalom ePoduzetnik.hr upravlja trgovačko društvo Adore Media d.o.o. registrirano pri Trgovačkom sudu u Zagrebu. Društvo Adore Media d.o.o. u cijelosti je u privatnom vlasništvu te ni na koji način ne predstavlja i ne zastupa državne institucije. Podaci o poduzetnicima na portalu ePoduzetnik.hr preuzeti su s javno dostupnih medija ili su uređivani od strane ovlaštenih osoba samih poduzetnika. Društvo Adore Media d.o.o. podatke objavljuje na portalu ePoduzetnik.hr u svrhu informiranja te ni na koji način ne može biti odgovorno za uporabu ili zlouporabu istih.\",\"Portalom DigitalnaPlatforma.hr upravlja trgovačko društvo Digitalna platforma d.o.o. registrirano pri Trgovačkom sudu u Zagrebu. Društvo Digitalna platforma d.o.o. u cijelosti je u privatnom vlasništvu te ni na koji način ne predstavlja i ne zastupa državne institucije. Podaci o gospodarstvenicima na portalu DigitalnaPlatforma.hr preuzeti su s javno dostupnih medija ili su uređivani od strane ovlaštenih osoba samih gospodarstvenika. Društvo Digitalna platforma d.o.o. podatke objavljuje na portalu DigitalnaPlatforma.hr u svrhu informiranja te ni na koji način ne može biti odgovorno za uporabu ili zlouporabu istih.\"],[\"For\",\"for\",\"za\",null,null,null],[\"GenderFemale\",\"Female\",\"Žensko\",null,null,null],[\"GenderMale\",\"Male\",\"Muško\",null,null,null],[\"GlobalCompanyMetaKeywords\",\"address, telephone, mobile phone, e-mail, email address, working time, map, location on map\",\"adresa, telefon, mobitel, e-mail, email, radno vrijeme, karta, mapa, lokacija na karti, lokacija na mapi\",null,null,null],[\"HairlengthOptions\",\"\\u003coption\\u003eVery short\\u003c/option\\u003e\\r\\n\\u003coption\\u003eShort\\u003c/option\\u003e\\r\\n\\u003coption\\u003eMid length\\u003c/option\\u003e\\r\\n\\u003coption\\u003eVery length\\u003c/option\\u003e\",\"\\u003coption\\u003eUltrakratka\\u003c/option\\u003e\\r\\n\\u003coption\\u003eKratka\\u003c/option\\u003e\\r\\n\\u003coption\\u003eSrednja\\u003c/option\\u003e\\r\\n\\u003coption\\u003eDugačka\\u003c/option\\u003e\",null,null,null],[\"Here\",\"Here\",\"Ovdje\",null,null,null],[\"HomeLinkName\",\"Home\",\"Naslovna\",null,null,null],[\"HomePageTitle\",\"HomePageTitle\",null,\"POSLOVNA TRAŽILICA - Elektronički registar gospodarstvenika\",\"E-TRAŽILICA - ePoduzetnik.hr\",\"DIGITALNA PLATFORMA - DigitalnaPlatforma.hr\"],[\"HomeUrlPath\",\"/\",\"/\",null,null,null],[\"Hourly\",\"Hourly\",\"Po satu\",null,null,null],[\"HourlyWeatherForecastLinkName\",\"Weather Forecast by Hour\",\"Vremenska prognoza po satu\",null,null,null],[\"HourlyWeatherForecastPageTitle\",\"Weather Forecast by Hour\",\"Vremenska prognoza po satu\",null,null,null],[\"HourlyWeatherForecastUrlPath\",\"/weather-forecast-by-hour\",\"/vremenska-prognoza-po-satu\",null,\"/detaljna-vremenska-prognoza-po-satu\",\"/najbolja-vremenska-prognoza-po-satu\"],[\"IfYouCanNotSaveDataChangeWebBrowser\",\"If you have problem saving the data, please try with different browser. The latest version of any mager web browser is supported.\",\"Ukoliko spremanje ne prolazi, pokušajte s drugim internetskim preglednikom ili s drugim računalom. Podržane su najnovije verzije svih relevantnih internetskih preglednika.\",null,null,null],[\"IfYouHaveAnyQuestion\",\"If you have any question\",\"Imate li pitanja?\",null,null,null],[\"InvoiceTo\",\"Invoice to\",\"Naručitelj\",null,null,null],[\"IWishToBeContactedForSimilarJobs\",\"I wish to be contacted for similar jobs\",\"želim da me se kontaktira za slične poslove\",null,null,null],[\"JobApplicationFailedMessage\",\"Job application failed. Please try with different web browser.\",\"Greška! Prijava nije uspjela. Promijenite internet preglednik i pokušajte ponovo.\",null,null,null],[\"JobApplicationForm\",\"Job Application Form\",\"Prijavnica za posao\",null,null,null],[\"JobApplicationPhotoIsRequiredPart1\",\"Photo is required. You may add up to\",\"Fotografija, portret, kao za osobnu iskaznicu. Prema želji, možete dodati ukupno do\",null,null,null],[\"JobApplicationPhotoIsRequiredPart2\",\"photos which describes you the best.\",\"fotografija koje vas najbolje opisuju.\",null,null,null],[\"JobApplicationSubtitleDescription\",\"JobApplicationSubtitleDescription\",\"Molimo popunite sve podatke u formi. Podaci prikupljeni ovim putem, koriste se isključivo u selekcijskom postupku te se brišu po završetku istog.\",null,null,null],[\"JobApplicatoinAddCVDescription\",\"Add your CV, motivation letter, recommendations etc.\",\"Dodajte svoj životopis (pdf, doc ili rtf), motivacijsko pismo, preporuke i sl. Ukoliko ste već poslali na e-mail, nije potrebno ponovo slati.\",null,null,null],[\"JobApplicatoinSuccessfulMessage\",\"Job application succesful! Thank you.\",\"Vaša prijava je uspješno spremljena! Zahvaljujemo.\",null,null,null],[\"JobLinkName\",\"Job\",\"Posao\",null,null,null],[\"JobPageTitle\",\"Job Application\",\"Prijava za posao\",null,null,null],[\"JobPosition\",\"Job position\",\"Pozicija\",null,null,null],[\"JobUrlPath\",\"/job\",\"/posao\",null,null,null],[\"JoinUs\",\"Join us\",\"Pridruži nam se\",null,null,null],[\"Keywords\",\"Keywords\",\"Ključne riječi\",null,null,null],[\"LabelAddress\",\"Address\",\"Adresa\",null,null,null],[\"LabelBirthDate\",\"Birth date\",\"Datum rođenja\",null,null,null],[\"LabelBusinessArea\",\"Business area\",\"Područje djelovanja\",null,null,null],[\"LabelCity\",\"City\",\"Grad\",null,null,null],[\"LabelDescription\",\"Description\",\"Opis\",null,null,null],[\"LabelDocuments\",\"Documents\",\"Dokumenti\",null,null,null],[\"LabelEducation\",\"Education\",\"Obrazovanje\",null,null,null],[\"LabelEmailAddress\",\"E-mail address\",\"E-mail adresa\",null,null,null],[\"LabelEyesSight\",\"Eyes - sigth\",\"Oči - vid\",null,null,null],[\"LabelFirstName\",\"First name\",\"Ime\",null,null,null],[\"LabelGender\",\"Gender\",\"Spol\",null,null,null],[\"LabelHairLength\",\"Hair length\",\"Duljina kose\",null,null,null],[\"LabelHeightCM\",\"Height (cm)\",\"Visina (cm)\",null,null,null],[\"LabelIActivelyDriveACar\",\"I actively drive a car\",\"Aktivno vozim automobil\",null,null,null],[\"LabelIHaveDrivingLicense\",\"I have driving license\",\"Imam vozačku dozvolu\",null,null,null],[\"LabelIOwnACar\",\"I own a car\",\"Posjedujem osobni automobil\",null,null,null],[\"LabelIWantProfessionalTraining\",\"I want use professional training\",\"Želim koristiti mjeru stručno osposobljavanje\",null,null,null],[\"LabelKeywords\",\"Keywords\",\"Ključne riječi\",null,null,null],[\"LabelLastName\",\"Last name\",\"Prezime\",null,null,null],[\"LabelMainBusinessCategory\",\"Main business category\",\"Pretežita djelatnost\",null,null,null],[\"LabelMainBusinessSubCategory\",\"Main business subcategory\",\"Poddjelatnost\",null,null,null],[\"LabelMobileNumber\",\"Mobile phone\",\"Mobitel\",null,null,null],[\"LabelNeighborhood\",\"Neighborhood\",\"Kvart\",null,null,null],[\"LabelPhotos\",\"Photos\",\"Fotografije\",null,null,null],[\"LabelPostOffice\",\"Post office\",\"Poštanski ured\",null,null,null],[\"LabelPostOfficeZIP\",\"Post office ZIP\",\"Poštanski broj\",null,null,null],[\"LabelReadyMadeNumber\",\"Ready-made number\",\"Konfekcijski broj\",null,null,null],[\"LabelSettlement\",\"Settlement\",\"Naselje\",null,null,null],[\"LabelShoeSize\",\"Shoe size\",\"Veličina obuće\",null,null,null],[\"LabelStatus\",\"Status\",\"Status\",null,null,null],[\"LabelStreet\",\"Street\",\"Ulica\",null,null,null],[\"LabelStreetNumber\",\"Street number\",\"Kućni broj\",null,null,null],[\"LabelSummary\",\"Summary\",\"Sažetak\",null,null,null],[\"LabelTelephone1\",\"Telephone 1\",\"Telefon 1\",null,null,null],[\"LabelTelephone2\",\"Telephone 2\",\"Telefon 2\",null,null,null],[\"LabelWebSite\",\"Web site\",\"Web stranica\",null,null,null],[\"LabelWeightKG\",\"Weight (kg)\",\"Težina (kg)\",null,null,null],[\"LabelWhereDidYouFindUs\",\"Where did you find us\",\"Gdje ste saznali za nas\",null,null,null],[\"LabelWorkingExperience\",\"Working experience\",\"Radno iskustvo\",null,null,null],[\"LabelWorkingTime\",\"Working time\",\"Radno vrijeme\",null,null,null],[\"LastChangeDate\",\"Last change date\",\"Datum zadnje promjene\",null,null,null],[\"ListingUrlPath\",\"/listing\",\"/popis\",null,null,null],[\"LocationOnMap\",\"Location on map\",\"Lokacija na karti\",null,null,null],[\"Login\",\"Login\",\"Prijava\",null,null,null],[\"LoginLinkName\",\"Login\",\"Prijava\",null,null,null],[\"LoginPageTitle\",\"Login\",\"Prijava\",null,null,null],[\"LoginUrlPath\",\"/login\",\"/login\",null,null,null],[\"LogoImage\",\"Logo image\",\"Logo\",null,null,null],[\"Logout\",\"Logout\",\"Odjava\",null,null,null],[\"MainAndLogoExplanation\",\"Main image is shown in company list and recommendation list. Logo is shown at client\\u0027s page if implemented by design. Logo is not visible in gallery with other pictures.\",\"Glavna slika se prikazuje na popisu tvrtki kao i na listi prepručenih tvrtki. Logo se prikazuje na stranici klijenta, ako je implementirano u dizajnu. Logo se ne prikazuje u galeriji s ostalim slikama.\",null,null,null],[\"MainImage\",\"Main image\",\"Glavna\",null,null,null],[\"Menu\",\"Menu\",\"Izbornik\",\"Opcije\",\"Menu\",\"Opcije\"],[\"Message\",\"Message\",\"Poruka\",null,null,null],[\"MessageContent\",\"Message content\",\"Sadržaj poruke\",null,null,null],[\"MissingAddress\",\"Missing address\",\"Nedostaje adresa\",null,null,null],[\"MissingDescriptions\",\"Missing description\",\"Nedostaje opis\",null,null,null],[\"MissingEmail\",\"Missing e-mail\",\"Nedostaje e-mail\",null,null,null],[\"MissingKeywords\",\"Missing keywords\",\"Nedostaju ključne riječi\",null,null,null],[\"MissingPhone\",\"Missing phone\",\"Nedostaje telefon\",null,null,null],[\"MissingPhotos\",\"Missing photos\",\"Nedostaju fotografije\",null,null,null],[\"MissingWebPage\",\"Missing web page\",\"Nedostaje web stranica\",null,null,null],[\"MissingWorkingTime\",\"Missing working time\",\"Nedostaje radno vrijeme\",null,null,null],[\"MobilePhone\",\"Mobile Phone\",\"Mobitel\",null,null,null],[\"Months\",\"Months\",\"Mjeseci\",null,null,null],[\"MyCompany\",\"My company\",\"Moja tvrtka\",null,null,null],[\"MyProfile\",\"My profile\",\"Moj profil\",null,null,null],[\"Name\",\"Name\",\"Naziv\",null,null,null],[\"NapomenaSUplatniceIliPonudeZaUpis\",\"*use invoice ref number\",null,\"*s uplatnice ili ponude za upis u eRegistar.hr\",\"*s uplatnice ili ponude za upis u ePoduzetnik.hr\",\"*s ponude za upis u sustav DigitalnaPlatforma.hr\"],[\"NewsletterSubscriptionSuccessful\",\"Newsletter subscription successful\",\"Uspješno ste se predbilježili\",null,null,null],[\"Night\",\"Night\",\"Noć\",null,null,null],[\"No\",\"No\",\"Ne\",null,null,null],[\"NoDocuments\",\"NoDocuments\",\"Nema dokumenata\",null,null,null],[\"NoDoubleclicksPlease\",\"No doubleclicks, please!\",\"Bez duplih klikova, molim!\",null,null,null],[\"NoLogoImage\",\"No logo image\",\"Bez logo-a\",null,null,null],[\"NoMainImage\",\"No main image\",\"Bez glavne\",null,null,null],[\"NoOpenedPositionsTitle\",\"No positions opened\",\"Trenutno nema otvorenih pozicija\",null,null,null],[\"NoResults\",\"No results\",\"Nema rezultata\",null,null,null],[\"Notification\",\"NOTE\",\"NAPOMENA\",null,null,null],[\"NotificationsAboutTopOffersViaEmail\",\"receive top offers to your e-mail account.\",\"primajte obavijesti o vrhunskim ponudama putem e-pošte.\",null,null,null],[\"OfferCreationFailedPleaseSendEmailToCustomerSupport\",\"Offer creation failed.\\r\\nPlease send e-mail to customer support.\",\"Kreiranje ponude nije uspjelo.\\r\\nMolimo pošaljite obavijest na e-mail korisničke podrške.\",null,null,null],[\"Options\",\"Options\",\"Opcije\",null,null,null],[\"PageMayBeAccessedByRegisteredClient\",\"This page may be accessed by registerd customer only.\",\"Stranica je dostupna samo registriranim korisnicima.\",null,null,null],[\"PlacehodlerPostOfficeZip\",\"post office ZIP?\",\"poštanski broj?\",null,null,null],[\"PlaceholderAddress\",\"address\",\"adresa?\",null,null,null],[\"PlaceholderCity\",\"city?\",\"grad ili mjesto?\",null,null,null],[\"PlaceholderDescriptionExplanation\",\"describe your company\",\"predstavite tvrtku u nekoliko rečenica, dodajte radno vrijeme\",null,null,null],[\"PlaceholderEducationHistory\",\"what is your education history?\",\"koje škole i koje godine ste završili ili još pohađate?\",null,null,null],[\"PlaceholderEmailAddress\",\"e-mail address?\",\"e-mail adresa?\",null,null,null],[\"PlaceholderFirstName\",\"first name?\",\"ime?\",null,null,null],[\"PlaceholderKeywords\",\"keywords for search?\",\"ključne riječi za pretragu? (npr. frizer, kopiranje ključeva, popravak vozila...)\",null,null,null],[\"PlaceholderLastName\",\"last name?\",\"prezime?\",null,null,null],[\"PlaceholderMobilePhoneNumber\",\"mobile phone number?\",\"broj mobitela?  (npr. 0991234123)\",null,null,null],[\"PlaceholderNeighborhoodOrSettlement\",\"neighborhood or settlement?\",\"kvart ili naselje?\",null,null,null],[\"PlaceholderPostOfficeZIP\",\"post office ZIP?\",\"poštanski broj?\",null,null,null],[\"PlaceholderPreviousWorkingExperience\",\"previous working experience?\",\"kakva imate dosadašnja radna iskustva?\",null,null,null],[\"PlaceholderSettlement\",\"settlement?\",\"naselje?\",null,null,null],[\"PlaceholderStreet\",\"street?\",\"ulica?\",null,null,null],[\"PlaceholderTelephone1\",\"telephone 1? (e.g. 0991234123)\",\"telefon 1? (npr. 0991234123)\",null,null,null],[\"PlaceholderTelephone2\",\"telephone 2?\",\"telefon 2?\",null,null,null],[\"PlaceholderWebSite\",\"web site (e.g. http://www.site.com)\",\"web stranica? (npr. https://www.site.hr)\",null,null,null],[\"PlaceholderWhatMakesYourTheBestCandidate\",\"what makes you the best candidate?\",\"koje kvalitete vas čine najboljom osobom za ovaj posao?\",null,null,null],[\"PlaceholderWorkingTime\",\"working time?\",\"radno vrijeme?\",null,null,null],[\"PlaceOrder\",\"Place order\",\"Završi narudžbu\",null,null,null],[\"PleaseEnterTheCompanyData\",\"Please enter the company data.\",\"Molimo unesite podatke o tvrtci ili obrtu.\",null,null,null],[\"PleaseFillInTheDataWhichYouWantToShowAtYourPublicWebSite\",\"Please fill in the data which you want to show at your public company web site. Business category is mandatory.\",\"Ovdje popunite podatke koje želite prikazivati na Vašoj javnog stranici na portalu. Osim djelatnosti, ni jedan od podataka nije obavezan.\",null,null,null],[\"PleaseRegisterToFinalizeYourOrder\",\"Please register to finalize your order.\",\"Završavanje narudžbe omogućeno je samo registriranim korisnicima.\",null,null,null],[\"PleaseSelect\",\"please select\",\"odaberite\",null,null,null],[\"PleaseSelectPosition\",\"Please select the position\",\"Odaberite poziciju\",null,null,null],[\"PleaseSelectPositionsToApplyFor\",\"PleaseSelectPositionsToApplyFor\",\"Odaberite jednu ili više pozicija za koje se želite prijaviti.\",null,null,null],[\"PleaseSendEmailToCustomerSupport\",\"Please send e-mail to customer support.\",\"Molimo pošaljite e-mail korisničkoj podršci.\",null,null,null],[\"PleaseWaitSavingInProgress\",\"Please wait, saving in progress:\",\"Pričekajte, spremanje u tijeku:\",null,null,null],[\"PleaseWaitWhileOfferIsCreated\",\"Please wait while offer is created...\",\"Molimo pričekajte, kreiranje ponude u tijeku...\",null,null,null],[\"PostalAddress\",\"Postal address\",\"Poštanska adresa\",null,null,null],[\"PostalOffice\",\"Postal office\",\"Poštanski ured\",null,null,null],[\"PostalOfficeZipCode\",\"Zip code\",\"Poštanski broj\",null,null,null],[\"PostanskaAdresaOibNadleznost\",null,null,\"\\u003cdd\\u003eDigitalna platforma d.o.o.\\u003c/dd\\u003e\\n\\u003cdd\\u003eSavska cesta 32\\u003c/dd\\u003e\\n\\u003cdd\\u003e10000 Zagreb\\u003c/dd\\u003e\\n\\n\\u003cdd\\u003e\u0026nbsp;\\u003c/dd\\u003e\\n\\u003cdd\\u003eOIB: 69801158567\\u003c/dd\\u003e\\n\\u003cdd\\u003eMBS: 081122600\\u003c/dd\\u003e\\n\\n\\u003cdd\\u003e\u0026nbsp;\\u003c/dd\\u003e\\n\\u003cdd\\u003eNadležni sud: Trgovački sud u Zagrebu\\u003c/dd\\u003e\",\"\\u003cdd\\u003eAdore Media d.o.o.\\u003c/dd\\u003e\\n\\u003cdd\\u003eGrančarska ulica 8\\u003c/dd\\u003e\\n\\u003cdd\\u003eGrančari, Zagreb\\u003c/dd\\u003e\\n\\n\\u003cdd\\u003e\u0026nbsp;\\u003c/dd\\u003e\\n\\u003cdd\\u003eOIB: 35181377465\\u003c/dd\\u003e\\n\\u003cdd\\u003eMBS: 081222735\\u003c/dd\\u003e\\n\\n\\u003cdd\\u003e\u0026nbsp;\\u003c/dd\\u003e\\n\\u003cdd\\u003eNadležni sud: Trgovački sud u Zagrebu\\u003c/dd\\u003e\",\"\\u003cdd\\u003eDigitalna platforma d.o.o.\\u003c/dd\\u003e\\n\\u003cdd\\u003eSavska cesta 32\\u003c/dd\\u003e\\n\\u003cdd\\u003e10000 Zagreb\\u003c/dd\\u003e\\n\\n\\u003cdd\\u003e\u0026nbsp;\\u003c/dd\\u003e\\n\\u003cdd\\u003eOIB: 69801158567\\u003c/dd\\u003e\\n\\u003cdd\\u003eMBS: 081122600\\u003c/dd\\u003e\\n\\n\\u003cdd\\u003e\u0026nbsp;\\u003c/dd\\u003e\\n\\u003cdd\\u003eNadležni sud: Trgovački sud u Zagrebu\\u003c/dd\\u003e\"],[\"PostOffice\",\"post office?\",\"poštanski ured?\",null,null,null],[\"PrivacyPolicy\",\"Privacy Policy\",\"Zaštita osobnih podataka (GDPR)\",null,null,null],[\"PublicPageNotVisibleToPublic\",\"WARNING: Your public page is not visible to public! Page becomes visible to public after the payment is confirmed.\",\"UPOZORENJE: Vaša javna stranica nije javno vidljiva! Stranica postaje javno vidljiva po zaprimljenoj cjelokupnoj uplati naknade za upis.\",null,null,null],[\"Question\",\"Question\",\"Pitanje\",null,null,null],[\"QuestionCantBeSentPleaseTryLater\",\"Question can\\u0027t be sent right now. Please try again later.\",\"Upit ne može biti poslan sada. Ispričavamo se i pokušajte kasnije.\",null,null,null],[\"QuestionSentThankYou\",\"Question sent! Thank You.\",\"Upit je poslan! Hvala.\",null,null,null],[\"ReceiveBillsOrderServicesDataEdit\",\"receive bills, order services, edit data, services controll...\",\"preuzimanje računa, naručivanje usluga, uređivanje podataka o tvrtci/obrtu, fiskalizacija, upravljanje uslugama...\",null,null,null],[\"RegistrationIsSimpleAndQuick\",\"Registration is simple and quick.\",\"Registracija je izuzetno jednostavna i brza.\",null,null,null],[\"RegistrationLinkName\",\"Company registration\",\"Zatraži upis tvrtke\",null,null,null],[\"RegistrationPageTitle\",\"Company registration\",\"Zatraži upis tvrtke\",null,null,null],[\"RegistrationUrlPath\",\"/registration\",\"/registracija\",null,null,null],[\"RememberMe\",\"Remember me\",\"Zapamti me\",null,null,null],[\"RepeatPassword\",\"Repeat password\",\"Lozinka ponovo\",null,null,null],[\"ResultMultiple\",\"results\",\"rezultata\",null,null,null],[\"ResultSingle\",\"result\",\"rezultat\",null,null,null],[\"Retired\",\"Retired\",\"Umirovljenik-ca\",null,null,null],[\"SaveData\",\"Save data\",\"Spremi podatke\",null,null,null],[\"Saving\",\"Saving\",\"Spremam\",null,null,null],[\"SavingInProgress\",\"Saving in progress...\",\"Spremanje u tijeku...\",null,null,null],[\"Search\",\"Search\",\"Traži\",null,null,null],[\"SearchFieldTip\",\"Search...\",\"Pojam za pretragu\",\"Pojam za pretragu\",null,\"Pojam za pretragu\"],[\"SearchPageDescription\",\"Find the best, the most reliable company by name, address or service.\",null,\"Pronađite najbolju, najpouzdaniju tvrtku, obrt ili uslugu, prema nazivu, adresi ili djelatnosti.\",\"| pretraga poduzetnika prema nazivu, adresi ili djelatnosti |\",\"| pretraga poduzetnika prema nazivu, adresi ili djelatnosti |\"],[\"SearchPageTitle\",\"SearchPageTitle\",null,\"POSLOVNA TRAŽILICA\",\"E-TRAŽILICA\",\"DIGITALNA PLATFORMA\"],[\"SelectedFileIsNotAnImage\",\"Selected file is not an image!\",\"Datoteka nije fotografija!\",null,null,null],[\"SelectedFileIsTooLargeLimitSize\",\"Selected file is too large (limit 10MB)\",\"Datoteka je prevelika (limit 10MB)\",null,null,null],[\"Send\",\"Send\",\"Pošalji\",null,null,null],[\"SendApplication\",\"Send Application\",\"Pošalji prijavnicu\",null,null,null],[\"SendingPleaseWait\",\"Sending, please wait...\",\"Slanje u tijeku, molimo pričekajte....\",null,null,null],[\"ServicesLinkName\",\"Services\",\"Usluge\",null,null,null],[\"ServicesPageTitle\",\"Services\",\"Usluge\",null,null,null],[\"ServicesUrlPath\",\"/services\",\"/usluge\",null,null,null],[\"Settlement\",\"Settlement\",\"Naselje\",null,null,null],[\"Show90Days\",\"Show 90 Days\",\"Prikaži 90 dana\",null,null,null],[\"ShowDocumentLinkName\",\"Document\",\"Dokument\",null,null,null],[\"ShowDocumentPageTitle\",\"Document\",\"Dokument\",null,null,null],[\"ShowDocumentUrlPath\",\"/document\",\"/dokument\",null,null,null],[\"ShowHourly\",\"Show Hourly\",\"Prikaži po satu\",null,null,null],[\"ShowMoreResults\",\"Show more results\",\"Prikaži više rezultata\",null,null,null],[\"SitemapLinkName\",\"Sitemap\",\"Sitemap\",null,null,null],[\"SitemapPageTitle\",\"Sitemap\",\"Sitemap\",null,null,null],[\"SitemapUrlPath\",\"/sitemap\",\"/sitemap\",null,null,null],[\"SortByNameAZ\",\"name A-Z\",\"naziv A-Z\",null,null,null],[\"SortByNameZA\",\"name Z-A\",\"naziv Z-A\",null,null,null],[\"SortByRelevance\",\"relevance\",\"relevantnost\",null,null,null],[\"SortFromLatest\",\"from latest\",\"od najnovijeg\",null,null,null],[\"SortFromOldest\",\"from oldest\",\"od najstarijeg\",null,null,null],[\"Sorting\",\"Sorting\",\"Poredak\",null,null,null],[\"Student\",\"Student\",\"Student-ica\",null,null,null],[\"Subject\",\"Subject\",\"Naslov poruke\",null,null,null],[\"SuccessRedirecting\",\"Success, redirecting...\",\"Uspješno, preusmjeravam...\",null,null,null],[\"SupportEmailAddress\",\"support@site.com\",null,\"pitanja@eregistar.hr\",\"podrska@epoduzetnik.hr\",\"pitanja@DigitalnaPlatforma.hr\"],[\"SupportPhoneNumber\",\"-\",null,\"01/5499-454\",\"-\",\"-\"],[\"SystemErrorPleaseTryAgainLater\",\"System error occured. Please try again later.\",\"Greška u sistemu. Molimo pokušajte malo kasnije ili pošaljite e-mail na korisničku podršku. Hvala na razumijenvanju.\",null,null,null],[\"Telephone\",\"Telephone\",\"Telefon\",null,null,null],[\"Terms\",\"Terms\",\"Pravila\",null,null,null],[\"TermsDescription\",\"Document containing Terms of service is available on the link below.\",\"Dokument s važećim općim uvjetima dostupan je na poveznici ispod.\",null,null,null],[\"TermsFileLinkName\",\"Terms content\",\"Uvjeti sadržaj\",null,null,null],[\"TermsFilePageTitle\",\"Terms Content\",\"Uvjeti sadržaj\",null,null,null],[\"TermsFileUrlPath\",\"/terms-file\",\"/uvjeti-sadrzaj\",null,null,null],[\"TermsLinkName\",\"Terms\",\"Uvjeti\",null,null,null],[\"TermsOfUse\",\"Terms Of Use\",\"Opći uvjeti\",null,null,null],[\"TermsPageTitle\",\"Terms Of Service\",\"Opći uvjeti\",null,null,null],[\"TermsUrlPath\",\"/terms\",\"/uvjeti\",null,null,null],[\"Today\",\"Today\",\"Danas\",null,null,null],[\"Tomorrow\",\"Tomorrow\",\"Sutra\",null,null,null],[\"TomrrowPlusOne\",\"Tomorrow + 1\",\"Prekosutra\",null,null,null],[\"TopSlogan\",\"TOP SLOGAN\",null,\"ELEKTRONIČKI REGISTAR GOSPODARSTVENIKA\",\"E-TRAŽILICA PODUZETNIKA\",\"DIGITALNA PLATFORMA\"],[\"Unemployed\",\"Unemployed\",\"Nezaposlen-a\",null,null,null],[\"ValidationTelephoneError\",\"Please enter digits only for telephone number\",\"Upišite samo brojke za telefonski broj\",null,null,null],[\"ValidEmailAddressHasToBeEntered\",\"Valid e-mail address has to be entered.\",\"Valjana e-mail adresa mora biti upisana.\",null,null,null],[\"VAT\",\"VAT\",\"PDV\",null,null,null],[\"VATIncluded\",\"VAT included\",\"PDV uključen\",null,null,null],[\"Visitors\",\"Visitors\",\"Posjetitelji\",null,null,null],[\"WeatherForecast\",\"Weather Forecast\",\"Vremenska prognoza\",null,null,null],[\"WeatherForecastByCities\",\"Weather Forecast by City\",null,\"Najtočnija vremenska prognoza po gradovima, cijela Hrvatska\",\"Najtočnija vremenska prognoza po gradovima, cijela Hrvatska\",\"Najtočnija vremenska prognoza po gradovima, cijela Hrvatska\"],[\"WeatherForecastDailyNext90DaysLinkName\",\"Weather Forecast 90 Day\",\"Vremenska prognoza za 90 dana\",null,null,null],[\"WeatherForecastHourlyNext3DaysLinkName\",\"Weather Forecast Hourly\",\"Vremenska prognoza po satu\",null,null,null],[\"WeatherForecastLinkName\",\"Weather Forecast\",\"Vremenska prognoza\",null,null,null],[\"WeatherForecastNext3Days\",\"weather forecast hourly next 3 days\",\"vremenska prognoza po satu za sljedeća 3 dana\",null,null,null],[\"WeatherForecastNext90Days\",\"weather forecast daily next 90 days\",\"vremenska prognoza po danu za 7, 15, 30, 60, 90 dana\",null,null,null],[\"WeatherForecastPageTitle\",\"Weather Forecast\",\"Vremenska prognoza\",null,null,null],[\"WeatherForecastUrlPath\",\"/weather-forecast\",\"/vremenska-prognoza\",null,\"/detaljna-vremenska-prognoza\",\"/najbolja-vremenska-prognoza\"],[\"WebFormInquiry\",\"Web form inquiry\",\"Upit iz web forme\",null,null,null],[\"WebSiteAddress\",\"Web site\",\"Web stranica\",null,null,null],[\"WeWillSaveYourApplicationForFutureDescription\",\"If you wish, we may save your application and send you notifications for similar jobs.\",\"Ukoliko želite, vašu prijavu ćemo spremiti u bazu te ćemo vas kontaktirati u budućnosti za slične poslove, bez potrebe da se ponovo prijavljujete.\",null,null,null],[\"WhereFoundUsOptions\",\"\\u003coption\\u003eWon\\u0027t say\\u003c/option\\u003e\",\"\\u003coption\\u003eStudentski centar\\u003c/option\\u003e\\r\\n\\u003coption\\u003eFacebook\\u003c/option\\u003e\\r\\n\\u003coption\\u003eZavod za zapošljavanje\\u003c/option\\u003e\\r\\n\\u003coption\\u003eMojposao.hr\\u003c/option\\u003e\\r\\n\\u003coption\\u003ePosao.hr\\u003c/option\\u003e\\r\\n\\u003coption\\u003eOglasnik.hr\\u003c/option\\u003e\\r\\n\\u003coption\\u003eBika.net\\u003c/option\\u003e\\r\\n\\u003coption\\u003ePreporuka prijatelja-ice\\u003c/option\\u003e\\r\\n\\u003coption\\u003eOglas na nekom drugom portalu\\u003c/option\\u003e\\r\\n\\u003coption\\u003eNegdje drugdje\\u003c/option\\u003e\",null,null,null],[\"WorkingTime\",\"Working time\",\"Radno vrijeme\",null,null,null],[\"Yes\",\"Yes\",\"Da\",null,null,null],[\"YourName\",\"Your Name\",\"Ime i prezime\",null,null,null],[\"YourPublicPageAddress\",\"Your public page address:\",\"Adresa Vaše javne stranice na portalu:\",null,null,null],[\"YourPublicPageShortAddress\",\"Your public page short address:\",\"Skraćena adresa Vaše javne stranice na portalu:\",null,null,null],[\"MobitelWithExamplePrompt\",\"Mobile phone number with country prefix\",\"Mobitel (3859xxxxxxxx)\",null,null,null],[\"OibOdgovorneOsobe\",\"Company owner unique number\",\"OIB odgovorne osobe\",null,null,null],[\"OibOdgovorneOsobePrompt\",\"Enter company owner unique number\",\"Unesite OIB odgovorne osobe\",null,null,null]]}";

        public static readonly ResxExcelProvider ResourceProvider = ResxExcelProvider.FromJson(_json);


        /// <summary>
        /// Accept 
        /// </summary>
		public static string Accept => ResourceProvider.GetString("Accept");

        /// <summary>
        /// Add document 
        /// </summary>
		public static string AddDocumentButton => ResourceProvider.GetString("AddDocumentButton");

        /// <summary>
        /// Additional informations 
        /// </summary>
		public static string AdditionalInformations => ResourceProvider.GetString("AdditionalInformations");

        /// <summary>
        /// Add photo 
        /// </summary>
		public static string AddPhotoButton => ResourceProvider.GetString("AddPhotoButton");

        /// <summary>
        /// Address 
        /// </summary>
		public static string Address => ResourceProvider.GetString("Address");

        /// <summary>
        /// POS Activation 
        /// </summary>
		public static string AktivacijaFiskalneBlagajne => ResourceProvider.GetString("AktivacijaFiskalneBlagajne");

        /// <summary>
        /// All rights reserved. 
        /// </summary>
		public static string AllRightsReservedText => ResourceProvider.GetString("AllRightsReservedText");

        /// <summary>
        /// Amount 
        /// </summary>
		public static string Amount => ResourceProvider.GetString("Amount");

        /// <summary>
        /// At least one photo is required 
        /// </summary>
		public static string AtLeastOnePhotoIsRequired => ResourceProvider.GetString("AtLeastOnePhotoIsRequired");

        /// <summary>
        /// Badges assigned 
        /// </summary>
		public static string BadgesAssigned => ResourceProvider.GetString("BadgesAssigned");

        /// <summary>
        /// Badgets assignement and search engines ranking is in relation with data entered. For better result, all data should be entered and you should have quality photos, recommended 600 x 600 pixels. 
        /// </summary>
		public static string BadgesAssignmentAndSearcEnginesRankingExplanation => ResourceProvider.GetString("BadgesAssignmentAndSearcEnginesRankingExplanation");

        /// <summary>
        /// Badges are shown in search results and at your public page. 
        /// </summary>
		public static string BadgetsExplanation => ResourceProvider.GetString("BadgetsExplanation");

        /// <summary>
        /// Birth date is not valid 
        /// </summary>
		public static string BirthDateInvalid => ResourceProvider.GetString("BirthDateInvalid");

        /// <summary>
        /// Birth data is out of range 
        /// </summary>
		public static string BirthDateOutOfRange => ResourceProvider.GetString("BirthDateOutOfRange");

        /// <summary>
        /// POS info 
        /// </summary>
		public static string BlagajnaInfoLinkName => ResourceProvider.GetString("BlagajnaInfoLinkName");

        /// <summary>
        /// POS info 
        /// </summary>
		public static string BlagajnaInfoPageTitle => ResourceProvider.GetString("BlagajnaInfoPageTitle");

        /// <summary>
        /// /pos 
        /// </summary>
		public static string BlagajnaInfoUrlPath => ResourceProvider.GetString("BlagajnaInfoUrlPath");

        /// <summary>
        /// POS - registration 
        /// </summary>
		public static string BlagajnaRegistrationLinkName => ResourceProvider.GetString("BlagajnaRegistrationLinkName");

        /// <summary>
        /// POS - registration 
        /// </summary>
		public static string BlagajnaRegistrationPageTitle => ResourceProvider.GetString("BlagajnaRegistrationPageTitle");

        /// <summary>
        /// /pos-registration 
        /// </summary>
		public static string BlagajnaRegistrationUrlPath => ResourceProvider.GetString("BlagajnaRegistrationUrlPath");

        /// <summary>
        /// Business data 
        /// </summary>
		public static string BusinessData => ResourceProvider.GetString("BusinessData");

        /// <summary>
        /// Business list 
        /// </summary>
		public static string BusinessList => ResourceProvider.GetString("BusinessList");

        /// <summary>
        /// Business list 
        /// </summary>
		public static string BusinessListLinkName => ResourceProvider.GetString("BusinessListLinkName");

        /// <summary>
        /// Business list 
        /// </summary>
		public static string BusinessListPageTitle => ResourceProvider.GetString("BusinessListPageTitle");

        /// <summary>
        /// /business 
        /// </summary>
		public static string BusinessListUrlPath => ResourceProvider.GetString("BusinessListUrlPath");

        /// <summary>
        /// By business 
        /// </summary>
		public static string ByBusiness => ResourceProvider.GetString("ByBusiness");

        /// <summary>
        /// Change City 
        /// </summary>
		public static string ChangeCity => ResourceProvider.GetString("ChangeCity");

        /// <summary>
        /// Check details 
        /// </summary>
		public static string CheckDetails => ResourceProvider.GetString("CheckDetails");

        /// <summary>
        /// Checking, please wait... 
        /// </summary>
		public static string CheckingPleaseWait => ResourceProvider.GetString("CheckingPleaseWait");

        /// <summary>
        /// CityWhereYouAreLivingForReal 
        /// </summary>
		public static string CityWhereYouAreLivingForReal => ResourceProvider.GetString("CityWhereYouAreLivingForReal");

        /// <summary>
        /// Close 
        /// </summary>
		public static string Close => ResourceProvider.GetString("Close");

        /// <summary>
        /// Companies 
        /// </summary>
		public static string Companies => ResourceProvider.GetString("Companies");

        /// <summary>
        /// Companies by categories 
        /// </summary>
		public static string CompaniesByCategories => ResourceProvider.GetString("CompaniesByCategories");

        /// <summary>
        /// BUSINESS LIST 
        /// </summary>
		public static string CompaniesListButtonText => ResourceProvider.GetString("CompaniesListButtonText");

        /// <summary>
        /// Companies list 
        /// </summary>
		public static string CompaniesListLinkName => ResourceProvider.GetString("CompaniesListLinkName");

        /// <summary>
        /// Companies list 
        /// </summary>
		public static string CompaniesListPageTitle => ResourceProvider.GetString("CompaniesListPageTitle");

        /// <summary>
        /// /companies-list 
        /// </summary>
		public static string CompaniesListUrlPath => ResourceProvider.GetString("CompaniesListUrlPath");

        /// <summary>
        /// Company can't be found by entered data.<br/>
        /// Please check your data or send e-mail to customer support. 
        /// </summary>
		public static string CompanyCantBeFoundByEnteredData => ResourceProvider.GetString("CompanyCantBeFoundByEnteredData");

        /// <summary>
        /// Company data 
        /// </summary>
		public static string CompanyDataLinkName => ResourceProvider.GetString("CompanyDataLinkName");

        /// <summary>
        /// Company data 
        /// </summary>
		public static string CompanyDataPageTitle => ResourceProvider.GetString("CompanyDataPageTitle");

        /// <summary>
        /// /company-data 
        /// </summary>
		public static string CompanyDataUrlPath => ResourceProvider.GetString("CompanyDataUrlPath");

        /// <summary>
        /// Company 
        /// </summary>
		public static string CompanyLinkName => ResourceProvider.GetString("CompanyLinkName");

        /// <summary>
        /// Company login 
        /// </summary>
		public static string CompanyLogin => ResourceProvider.GetString("CompanyLogin");

        /// <summary>
        /// Company logout 
        /// </summary>
		public static string CompanyLogout => ResourceProvider.GetString("CompanyLogout");

        /// <summary>
        /// Company Name 
        /// </summary>
		public static string CompanyName => ResourceProvider.GetString("CompanyName");

        /// <summary>
        /// Company 
        /// </summary>
		public static string CompanyPageTitle => ResourceProvider.GetString("CompanyPageTitle");

        /// <summary> 
        /// </summary>
		public static string CompanyRegistrationDescription => ResourceProvider.GetString("CompanyRegistrationDescription");

        /// <summary>
        /// Company unique number 
        /// </summary>
		public static string CompanyUniqueNumber => ResourceProvider.GetString("CompanyUniqueNumber");

        /// <summary>
        /// OIB 
        /// </summary>
		public static string CompanyUniqueNumberShort => ResourceProvider.GetString("CompanyUniqueNumberShort");

        /// <summary>
        /// /company 
        /// </summary>
		public static string CompanyUrlPath => ResourceProvider.GetString("CompanyUrlPath");

        /// <summary>
        /// Company already exists.<br/>
        /// If you don't know how to login, please send e-mail to customer support. 
        /// </summary>
		public static string CompanyWithEnteredOibAlreadyExistsContactSupport => ResourceProvider.GetString("CompanyWithEnteredOibAlreadyExistsContactSupport");

        /// <summary>
        /// Contact data 
        /// </summary>
		public static string ContactData => ResourceProvider.GetString("ContactData");

        /// <summary>
        /// Contact form 
        /// </summary>
		public static string ContactForm => ResourceProvider.GetString("ContactForm");

        /// <summary>
        /// Contact 
        /// </summary>
		public static string ContactLinkName => ResourceProvider.GetString("ContactLinkName");

        /// <summary>
        /// /contact 
        /// </summary>
		public static string ContactUrlPath => ResourceProvider.GetString("ContactUrlPath");

        /// <summary>
        /// Cookie Policy 
        /// </summary>
		public static string CookiePolicy => ResourceProvider.GetString("CookiePolicy");

        /// <summary>
        /// We are using cookies for better customer experience. By continuing using the portal, you agree to the 
        /// </summary>
		public static string CookiesWarningText => ResourceProvider.GetString("CookiesWarningText");

        /// <summary>
        /// Current 
        /// </summary>
		public static string Current => ResourceProvider.GetString("Current");

        /// <summary>
        /// Currently there is no data available 
        /// </summary>
		public static string CurrentlyThereIsNoDataAvailable => ResourceProvider.GetString("CurrentlyThereIsNoDataAvailable");

        /// <summary>
        /// Customer not found 
        /// </summary>
		public static string CustomerNotFound => ResourceProvider.GetString("CustomerNotFound");

        /// <summary>
        /// Customer support 
        /// </summary>
		public static string CustomerSupport => ResourceProvider.GetString("CustomerSupport");

        /// <summary>
        /// Daily 
        /// </summary>
		public static string Daily => ResourceProvider.GetString("Daily");

        /// <summary>
        /// Weather Forecast by Day 
        /// </summary>
		public static string DailyWeatherForecastLinkName => ResourceProvider.GetString("DailyWeatherForecastLinkName");

        /// <summary>
        /// Weather Forecast by Day 
        /// </summary>
		public static string DailyWeatherForecastPageTitle => ResourceProvider.GetString("DailyWeatherForecastPageTitle");

        /// <summary>
        /// /weather-forecast-by-day 
        /// </summary>
		public static string DailyWeatherForecastUrlPath => ResourceProvider.GetString("DailyWeatherForecastUrlPath");

        /// <summary>
        /// Data saved successfuly. Search results data will be refreshed in few minutes. 
        /// </summary>
		public static string DataSavedSucessfulyResultsDataWillBeRefreshedInFewMinutes => ResourceProvider.GetString("DataSavedSucessfulyResultsDataWillBeRefreshedInFewMinutes");

        /// <summary>
        /// Date 
        /// </summary>
		public static string Date => ResourceProvider.GetString("Date");

        /// <summary>
        /// Day 
        /// </summary>
		public static string Day => ResourceProvider.GetString("Day");

        /// <summary>
        /// Delete, are you sure? 
        /// </summary>
		public static string DeleteAreYouSure => ResourceProvider.GetString("DeleteAreYouSure");

        /// <summary>
        /// Description 
        /// </summary>
		public static string Description => ResourceProvider.GetString("Description");

        /// <summary>
        /// Detailed Weather Forecast 
        /// </summary>
		public static string DetailedWeatherForecast => ResourceProvider.GetString("DetailedWeatherForecast");

        /// <summary>
        /// Details 
        /// </summary>
		public static string Details => ResourceProvider.GetString("Details");

        /// <summary>
        /// Business 
        /// </summary>
		public static string Djelatnosti => ResourceProvider.GetString("Djelatnosti");

        /// <summary>
        /// Document reference 
        /// </summary>
		public static string DocumentRefNumber => ResourceProvider.GetString("DocumentRefNumber");

        /// <summary>
        /// Documents are in "pdf" format. To open and read it, it is required to have Adobe Reader installed. 
        /// </summary>
		public static string DocumentsAreInPdfFormatNotification => ResourceProvider.GetString("DocumentsAreInPdfFormatNotification");

        /// <summary>
        /// Bill is generated after payment is received and processed by our stuff and becomes available for download {0} working days after the payment is made. If bill is not visible after that period, please contact 
        /// </summary>
		public static string DocumentsDownloadBlock2 => ResourceProvider.GetString("DocumentsDownloadBlock2");

        /// <summary>
        /// Documents found 
        /// </summary>
		public static string DocumentsFound => ResourceProvider.GetString("DocumentsFound");

        /// <summary>
        /// Documents 
        /// </summary>
		public static string DocumentsLinkName => ResourceProvider.GetString("DocumentsLinkName");

        /// <summary>
        /// Documents 
        /// </summary>
		public static string DocumentsPageTitle => ResourceProvider.GetString("DocumentsPageTitle");

        /// <summary>
        /// /documents 
        /// </summary>
		public static string DocumentsUrlPath => ResourceProvider.GetString("DocumentsUrlPath");

        /// <summary>
        /// Download 
        /// </summary>
		public static string Download => ResourceProvider.GetString("Download");

        /// <summary>
        /// United Emirates 
        /// </summary>
		public static string DrzavaNaziv => ResourceProvider.GetString("DrzavaNaziv");

        /// <summary>
        /// Duration 
        /// </summary>
		public static string Duration => ResourceProvider.GetString("Duration");

        /// <summary>
        /// E-mail 
        /// </summary>
		public static string Email => ResourceProvider.GetString("Email");

        /// <summary>
        /// Email Address 
        /// </summary>
		public static string EmailAddress => ResourceProvider.GetString("EmailAddress");

        /// <summary>
        /// E-mail address can't be retrieved, please try different login method. 
        /// </summary>
		public static string EmailAddressCanNotBeRetrievedTryDifferentLoginMethod => ResourceProvider.GetString("EmailAddressCanNotBeRetrievedTryDifferentLoginMethod");

        /// <summary>
        /// Email has to be entered 
        /// </summary>
		public static string EmailHasToBeEntered => ResourceProvider.GetString("EmailHasToBeEntered");

        /// <summary>
        /// E-mail is already subscribed 
        /// </summary>
		public static string EmailIsAlreadySubscribed => ResourceProvider.GetString("EmailIsAlreadySubscribed");

        /// <summary>
        /// Not in valid format for an e-mail address 
        /// </summary>
		public static string EmailNotInValidFormat => ResourceProvider.GetString("EmailNotInValidFormat");

        /// <summary>
        /// Employed 
        /// </summary>
		public static string Employed => ResourceProvider.GetString("Employed");

        /// <summary>
        /// <option>Student</option><br/>
        /// <option>Unemployed</option><br/>
        /// <option>Employed</option><br/>
        /// <option>Retired</option> 
        /// </summary>
		public static string EmploymentStatusOptions => ResourceProvider.GetString("EmploymentStatusOptions");

        /// <summary>
        /// Enter password 
        /// </summary>
		public static string EnterPassword => ResourceProvider.GetString("EnterPassword");

        /// <summary>
        /// Mobile phone, enter digits only 
        /// </summary>
		public static string ErrorMobilePhoneEnterDigits => ResourceProvider.GetString("ErrorMobilePhoneEnterDigits");

        /// <summary>
        /// Error! Please use different web browser. 
        /// </summary>
		public static string ErrorPleaseChangeYourWebBrowserAndTryAgain => ResourceProvider.GetString("ErrorPleaseChangeYourWebBrowserAndTryAgain");

        /// <summary>
        /// ZIP code, enter digits only 
        /// </summary>
		public static string ErrorPostOfficeZIPDigitsOnly => ResourceProvider.GetString("ErrorPostOfficeZIPDigitsOnly");

        /// <summary>
        /// Street number, enter digits only 
        /// </summary>
		public static string ErrorStreetNumberEnterDigits => ResourceProvider.GetString("ErrorStreetNumberEnterDigits");

        /// <summary>
        /// <option>Excellent sight</option><br/>
        /// <option>Not so brilliant</option><br/>
        /// <option>Bad sight</option><br/>
        /// <option>Have glasses</option><br/>
        /// <option>Have lens</option> 
        /// </summary>
		public static string EyeSightOptions => ResourceProvider.GetString("EyeSightOptions");

        /// <summary>
        /// Feel free to send us email to 
        /// </summary>
		public static string FeelFreeToSendUsEmail => ResourceProvider.GetString("FeelFreeToSendUsEmail");

        /// <summary>
        /// Fiscalization 
        /// </summary>
		public static string FiskalInfoLinkName => ResourceProvider.GetString("FiskalInfoLinkName");

        /// <summary>
        /// Fiscalization 
        /// </summary>
		public static string FiskalInfoPageTitle => ResourceProvider.GetString("FiskalInfoPageTitle");

        /// <summary>
        /// /fiskal 
        /// </summary>
		public static string FiskalInfoUrlPath => ResourceProvider.GetString("FiskalInfoUrlPath");

        /// <summary> 
        /// </summary>
		public static string FiskalnaBlagajnaVideoTutorials => ResourceProvider.GetString("FiskalnaBlagajnaVideoTutorials");

        /// <summary>
        /// Fiskal registration 
        /// </summary>
		public static string FiskalRegistrationLinkName => ResourceProvider.GetString("FiskalRegistrationLinkName");

        /// <summary>
        /// Fiskal registration 
        /// </summary>
		public static string FiskalRegistrationPageTitle => ResourceProvider.GetString("FiskalRegistrationPageTitle");

        /// <summary>
        /// /fiskal-registration 
        /// </summary>
		public static string FiskalRegistrationUrlPath => ResourceProvider.GetString("FiskalRegistrationUrlPath");

        /// <summary> 
        /// </summary>
		public static string FooterDescription => ResourceProvider.GetString("FooterDescription");

        /// <summary>
        /// for 
        /// </summary>
		public static string For => ResourceProvider.GetString("For");

        /// <summary>
        /// Female 
        /// </summary>
		public static string GenderFemale => ResourceProvider.GetString("GenderFemale");

        /// <summary>
        /// Male 
        /// </summary>
		public static string GenderMale => ResourceProvider.GetString("GenderMale");

        /// <summary>
        /// address, telephone, mobile phone, e-mail, email address, working time, map, location on map 
        /// </summary>
		public static string GlobalCompanyMetaKeywords => ResourceProvider.GetString("GlobalCompanyMetaKeywords");

        /// <summary>
        /// <option>Very short</option><br/>
        /// <option>Short</option><br/>
        /// <option>Mid length</option><br/>
        /// <option>Very length</option> 
        /// </summary>
		public static string HairlengthOptions => ResourceProvider.GetString("HairlengthOptions");

        /// <summary>
        /// Here 
        /// </summary>
		public static string Here => ResourceProvider.GetString("Here");

        /// <summary>
        /// Home 
        /// </summary>
		public static string HomeLinkName => ResourceProvider.GetString("HomeLinkName");

        /// <summary>
        /// HomePageTitle 
        /// </summary>
		public static string HomePageTitle => ResourceProvider.GetString("HomePageTitle");

        /// <summary>
        /// / 
        /// </summary>
		public static string HomeUrlPath => ResourceProvider.GetString("HomeUrlPath");

        /// <summary>
        /// Hourly 
        /// </summary>
		public static string Hourly => ResourceProvider.GetString("Hourly");

        /// <summary>
        /// Weather Forecast by Hour 
        /// </summary>
		public static string HourlyWeatherForecastLinkName => ResourceProvider.GetString("HourlyWeatherForecastLinkName");

        /// <summary>
        /// Weather Forecast by Hour 
        /// </summary>
		public static string HourlyWeatherForecastPageTitle => ResourceProvider.GetString("HourlyWeatherForecastPageTitle");

        /// <summary>
        /// /weather-forecast-by-hour 
        /// </summary>
		public static string HourlyWeatherForecastUrlPath => ResourceProvider.GetString("HourlyWeatherForecastUrlPath");

        /// <summary>
        /// If you have problem saving the data, please try with different browser. The latest version of any mager web browser is supported. 
        /// </summary>
		public static string IfYouCanNotSaveDataChangeWebBrowser => ResourceProvider.GetString("IfYouCanNotSaveDataChangeWebBrowser");

        /// <summary>
        /// If you have any question 
        /// </summary>
		public static string IfYouHaveAnyQuestion => ResourceProvider.GetString("IfYouHaveAnyQuestion");

        /// <summary>
        /// Invoice to 
        /// </summary>
		public static string InvoiceTo => ResourceProvider.GetString("InvoiceTo");

        /// <summary>
        /// I wish to be contacted for similar jobs 
        /// </summary>
		public static string IWishToBeContactedForSimilarJobs => ResourceProvider.GetString("IWishToBeContactedForSimilarJobs");

        /// <summary>
        /// Job application failed. Please try with different web browser. 
        /// </summary>
		public static string JobApplicationFailedMessage => ResourceProvider.GetString("JobApplicationFailedMessage");

        /// <summary>
        /// Job Application Form 
        /// </summary>
		public static string JobApplicationForm => ResourceProvider.GetString("JobApplicationForm");

        /// <summary>
        /// Photo is required. You may add up to 
        /// </summary>
		public static string JobApplicationPhotoIsRequiredPart1 => ResourceProvider.GetString("JobApplicationPhotoIsRequiredPart1");

        /// <summary>
        /// photos which describes you the best. 
        /// </summary>
		public static string JobApplicationPhotoIsRequiredPart2 => ResourceProvider.GetString("JobApplicationPhotoIsRequiredPart2");

        /// <summary>
        /// JobApplicationSubtitleDescription 
        /// </summary>
		public static string JobApplicationSubtitleDescription => ResourceProvider.GetString("JobApplicationSubtitleDescription");

        /// <summary>
        /// Add your CV, motivation letter, recommendations etc. 
        /// </summary>
		public static string JobApplicatoinAddCVDescription => ResourceProvider.GetString("JobApplicatoinAddCVDescription");

        /// <summary>
        /// Job application succesful! Thank you. 
        /// </summary>
		public static string JobApplicatoinSuccessfulMessage => ResourceProvider.GetString("JobApplicatoinSuccessfulMessage");

        /// <summary>
        /// Job 
        /// </summary>
		public static string JobLinkName => ResourceProvider.GetString("JobLinkName");

        /// <summary>
        /// Job Application 
        /// </summary>
		public static string JobPageTitle => ResourceProvider.GetString("JobPageTitle");

        /// <summary>
        /// Job position 
        /// </summary>
		public static string JobPosition => ResourceProvider.GetString("JobPosition");

        /// <summary>
        /// /job 
        /// </summary>
		public static string JobUrlPath => ResourceProvider.GetString("JobUrlPath");

        /// <summary>
        /// Join us 
        /// </summary>
		public static string JoinUs => ResourceProvider.GetString("JoinUs");

        /// <summary>
        /// Keywords 
        /// </summary>
		public static string Keywords => ResourceProvider.GetString("Keywords");

        /// <summary>
        /// Address 
        /// </summary>
		public static string LabelAddress => ResourceProvider.GetString("LabelAddress");

        /// <summary>
        /// Birth date 
        /// </summary>
		public static string LabelBirthDate => ResourceProvider.GetString("LabelBirthDate");

        /// <summary>
        /// Business area 
        /// </summary>
		public static string LabelBusinessArea => ResourceProvider.GetString("LabelBusinessArea");

        /// <summary>
        /// City 
        /// </summary>
		public static string LabelCity => ResourceProvider.GetString("LabelCity");

        /// <summary>
        /// Description 
        /// </summary>
		public static string LabelDescription => ResourceProvider.GetString("LabelDescription");

        /// <summary>
        /// Documents 
        /// </summary>
		public static string LabelDocuments => ResourceProvider.GetString("LabelDocuments");

        /// <summary>
        /// Education 
        /// </summary>
		public static string LabelEducation => ResourceProvider.GetString("LabelEducation");

        /// <summary>
        /// E-mail address 
        /// </summary>
		public static string LabelEmailAddress => ResourceProvider.GetString("LabelEmailAddress");

        /// <summary>
        /// Eyes - sigth 
        /// </summary>
		public static string LabelEyesSight => ResourceProvider.GetString("LabelEyesSight");

        /// <summary>
        /// First name 
        /// </summary>
		public static string LabelFirstName => ResourceProvider.GetString("LabelFirstName");

        /// <summary>
        /// Gender 
        /// </summary>
		public static string LabelGender => ResourceProvider.GetString("LabelGender");

        /// <summary>
        /// Hair length 
        /// </summary>
		public static string LabelHairLength => ResourceProvider.GetString("LabelHairLength");

        /// <summary>
        /// Height (cm) 
        /// </summary>
		public static string LabelHeightCM => ResourceProvider.GetString("LabelHeightCM");

        /// <summary>
        /// I actively drive a car 
        /// </summary>
		public static string LabelIActivelyDriveACar => ResourceProvider.GetString("LabelIActivelyDriveACar");

        /// <summary>
        /// I have driving license 
        /// </summary>
		public static string LabelIHaveDrivingLicense => ResourceProvider.GetString("LabelIHaveDrivingLicense");

        /// <summary>
        /// I own a car 
        /// </summary>
		public static string LabelIOwnACar => ResourceProvider.GetString("LabelIOwnACar");

        /// <summary>
        /// I want use professional training 
        /// </summary>
		public static string LabelIWantProfessionalTraining => ResourceProvider.GetString("LabelIWantProfessionalTraining");

        /// <summary>
        /// Keywords 
        /// </summary>
		public static string LabelKeywords => ResourceProvider.GetString("LabelKeywords");

        /// <summary>
        /// Last name 
        /// </summary>
		public static string LabelLastName => ResourceProvider.GetString("LabelLastName");

        /// <summary>
        /// Main business category 
        /// </summary>
		public static string LabelMainBusinessCategory => ResourceProvider.GetString("LabelMainBusinessCategory");

        /// <summary>
        /// Main business subcategory 
        /// </summary>
		public static string LabelMainBusinessSubCategory => ResourceProvider.GetString("LabelMainBusinessSubCategory");

        /// <summary>
        /// Mobile phone 
        /// </summary>
		public static string LabelMobileNumber => ResourceProvider.GetString("LabelMobileNumber");

        /// <summary>
        /// Neighborhood 
        /// </summary>
		public static string LabelNeighborhood => ResourceProvider.GetString("LabelNeighborhood");

        /// <summary>
        /// Photos 
        /// </summary>
		public static string LabelPhotos => ResourceProvider.GetString("LabelPhotos");

        /// <summary>
        /// Post office 
        /// </summary>
		public static string LabelPostOffice => ResourceProvider.GetString("LabelPostOffice");

        /// <summary>
        /// Post office ZIP 
        /// </summary>
		public static string LabelPostOfficeZIP => ResourceProvider.GetString("LabelPostOfficeZIP");

        /// <summary>
        /// Ready-made number 
        /// </summary>
		public static string LabelReadyMadeNumber => ResourceProvider.GetString("LabelReadyMadeNumber");

        /// <summary>
        /// Settlement 
        /// </summary>
		public static string LabelSettlement => ResourceProvider.GetString("LabelSettlement");

        /// <summary>
        /// Shoe size 
        /// </summary>
		public static string LabelShoeSize => ResourceProvider.GetString("LabelShoeSize");

        /// <summary>
        /// Status 
        /// </summary>
		public static string LabelStatus => ResourceProvider.GetString("LabelStatus");

        /// <summary>
        /// Street 
        /// </summary>
		public static string LabelStreet => ResourceProvider.GetString("LabelStreet");

        /// <summary>
        /// Street number 
        /// </summary>
		public static string LabelStreetNumber => ResourceProvider.GetString("LabelStreetNumber");

        /// <summary>
        /// Summary 
        /// </summary>
		public static string LabelSummary => ResourceProvider.GetString("LabelSummary");

        /// <summary>
        /// Telephone 1 
        /// </summary>
		public static string LabelTelephone1 => ResourceProvider.GetString("LabelTelephone1");

        /// <summary>
        /// Telephone 2 
        /// </summary>
		public static string LabelTelephone2 => ResourceProvider.GetString("LabelTelephone2");

        /// <summary>
        /// Web site 
        /// </summary>
		public static string LabelWebSite => ResourceProvider.GetString("LabelWebSite");

        /// <summary>
        /// Weight (kg) 
        /// </summary>
		public static string LabelWeightKG => ResourceProvider.GetString("LabelWeightKG");

        /// <summary>
        /// Where did you find us 
        /// </summary>
		public static string LabelWhereDidYouFindUs => ResourceProvider.GetString("LabelWhereDidYouFindUs");

        /// <summary>
        /// Working experience 
        /// </summary>
		public static string LabelWorkingExperience => ResourceProvider.GetString("LabelWorkingExperience");

        /// <summary>
        /// Working time 
        /// </summary>
		public static string LabelWorkingTime => ResourceProvider.GetString("LabelWorkingTime");

        /// <summary>
        /// Last change date 
        /// </summary>
		public static string LastChangeDate => ResourceProvider.GetString("LastChangeDate");

        /// <summary>
        /// /listing 
        /// </summary>
		public static string ListingUrlPath => ResourceProvider.GetString("ListingUrlPath");

        /// <summary>
        /// Location on map 
        /// </summary>
		public static string LocationOnMap => ResourceProvider.GetString("LocationOnMap");

        /// <summary>
        /// Login 
        /// </summary>
		public static string Login => ResourceProvider.GetString("Login");

        /// <summary>
        /// Login 
        /// </summary>
		public static string LoginLinkName => ResourceProvider.GetString("LoginLinkName");

        /// <summary>
        /// Login 
        /// </summary>
		public static string LoginPageTitle => ResourceProvider.GetString("LoginPageTitle");

        /// <summary>
        /// /login 
        /// </summary>
		public static string LoginUrlPath => ResourceProvider.GetString("LoginUrlPath");

        /// <summary>
        /// Logo image 
        /// </summary>
		public static string LogoImage => ResourceProvider.GetString("LogoImage");

        /// <summary>
        /// Logout 
        /// </summary>
		public static string Logout => ResourceProvider.GetString("Logout");

        /// <summary>
        /// Main image is shown in company list and recommendation list. Logo is shown at client's page if implemented by design. Logo is not visible in gallery with other pictures. 
        /// </summary>
		public static string MainAndLogoExplanation => ResourceProvider.GetString("MainAndLogoExplanation");

        /// <summary>
        /// Main image 
        /// </summary>
		public static string MainImage => ResourceProvider.GetString("MainImage");

        /// <summary>
        /// Menu 
        /// </summary>
		public static string Menu => ResourceProvider.GetString("Menu");

        /// <summary>
        /// Message 
        /// </summary>
		public static string Message => ResourceProvider.GetString("Message");

        /// <summary>
        /// Message content 
        /// </summary>
		public static string MessageContent => ResourceProvider.GetString("MessageContent");

        /// <summary>
        /// Missing address 
        /// </summary>
		public static string MissingAddress => ResourceProvider.GetString("MissingAddress");

        /// <summary>
        /// Missing description 
        /// </summary>
		public static string MissingDescriptions => ResourceProvider.GetString("MissingDescriptions");

        /// <summary>
        /// Missing e-mail 
        /// </summary>
		public static string MissingEmail => ResourceProvider.GetString("MissingEmail");

        /// <summary>
        /// Missing keywords 
        /// </summary>
		public static string MissingKeywords => ResourceProvider.GetString("MissingKeywords");

        /// <summary>
        /// Missing phone 
        /// </summary>
		public static string MissingPhone => ResourceProvider.GetString("MissingPhone");

        /// <summary>
        /// Missing photos 
        /// </summary>
		public static string MissingPhotos => ResourceProvider.GetString("MissingPhotos");

        /// <summary>
        /// Missing web page 
        /// </summary>
		public static string MissingWebPage => ResourceProvider.GetString("MissingWebPage");

        /// <summary>
        /// Missing working time 
        /// </summary>
		public static string MissingWorkingTime => ResourceProvider.GetString("MissingWorkingTime");

        /// <summary>
        /// Mobile Phone 
        /// </summary>
		public static string MobilePhone => ResourceProvider.GetString("MobilePhone");

        /// <summary>
        /// Mobile phone number with country prefix 
        /// </summary>
		public static string MobitelWithExamplePrompt => ResourceProvider.GetString("MobitelWithExamplePrompt");

        /// <summary>
        /// Months 
        /// </summary>
		public static string Months => ResourceProvider.GetString("Months");

        /// <summary>
        /// My company 
        /// </summary>
		public static string MyCompany => ResourceProvider.GetString("MyCompany");

        /// <summary>
        /// My profile 
        /// </summary>
		public static string MyProfile => ResourceProvider.GetString("MyProfile");

        /// <summary>
        /// Name 
        /// </summary>
		public static string Name => ResourceProvider.GetString("Name");

        /// <summary>
        /// *use invoice ref number 
        /// </summary>
		public static string NapomenaSUplatniceIliPonudeZaUpis => ResourceProvider.GetString("NapomenaSUplatniceIliPonudeZaUpis");

        /// <summary>
        /// Newsletter subscription successful 
        /// </summary>
		public static string NewsletterSubscriptionSuccessful => ResourceProvider.GetString("NewsletterSubscriptionSuccessful");

        /// <summary>
        /// Night 
        /// </summary>
		public static string Night => ResourceProvider.GetString("Night");

        /// <summary>
        /// No 
        /// </summary>
		public static string No => ResourceProvider.GetString("No");

        /// <summary>
        /// NoDocuments 
        /// </summary>
		public static string NoDocuments => ResourceProvider.GetString("NoDocuments");

        /// <summary>
        /// No doubleclicks, please! 
        /// </summary>
		public static string NoDoubleclicksPlease => ResourceProvider.GetString("NoDoubleclicksPlease");

        /// <summary>
        /// No logo image 
        /// </summary>
		public static string NoLogoImage => ResourceProvider.GetString("NoLogoImage");

        /// <summary>
        /// No main image 
        /// </summary>
		public static string NoMainImage => ResourceProvider.GetString("NoMainImage");

        /// <summary>
        /// No positions opened 
        /// </summary>
		public static string NoOpenedPositionsTitle => ResourceProvider.GetString("NoOpenedPositionsTitle");

        /// <summary>
        /// No results 
        /// </summary>
		public static string NoResults => ResourceProvider.GetString("NoResults");

        /// <summary>
        /// NOTE 
        /// </summary>
		public static string Notification => ResourceProvider.GetString("Notification");

        /// <summary>
        /// receive top offers to your e-mail account. 
        /// </summary>
		public static string NotificationsAboutTopOffersViaEmail => ResourceProvider.GetString("NotificationsAboutTopOffersViaEmail");

        /// <summary>
        /// Offer creation failed.<br/>
        /// Please send e-mail to customer support. 
        /// </summary>
		public static string OfferCreationFailedPleaseSendEmailToCustomerSupport => ResourceProvider.GetString("OfferCreationFailedPleaseSendEmailToCustomerSupport");

        /// <summary>
        /// Company owner unique number 
        /// </summary>
		public static string OibOdgovorneOsobe => ResourceProvider.GetString("OibOdgovorneOsobe");

        /// <summary>
        /// Enter company owner unique number 
        /// </summary>
		public static string OibOdgovorneOsobePrompt => ResourceProvider.GetString("OibOdgovorneOsobePrompt");

        /// <summary>
        /// Options 
        /// </summary>
		public static string Options => ResourceProvider.GetString("Options");

        /// <summary>
        /// This page may be accessed by registerd customer only. 
        /// </summary>
		public static string PageMayBeAccessedByRegisteredClient => ResourceProvider.GetString("PageMayBeAccessedByRegisteredClient");

        /// <summary>
        /// post office ZIP? 
        /// </summary>
		public static string PlacehodlerPostOfficeZip => ResourceProvider.GetString("PlacehodlerPostOfficeZip");

        /// <summary>
        /// address 
        /// </summary>
		public static string PlaceholderAddress => ResourceProvider.GetString("PlaceholderAddress");

        /// <summary>
        /// city? 
        /// </summary>
		public static string PlaceholderCity => ResourceProvider.GetString("PlaceholderCity");

        /// <summary>
        /// describe your company 
        /// </summary>
		public static string PlaceholderDescriptionExplanation => ResourceProvider.GetString("PlaceholderDescriptionExplanation");

        /// <summary>
        /// what is your education history? 
        /// </summary>
		public static string PlaceholderEducationHistory => ResourceProvider.GetString("PlaceholderEducationHistory");

        /// <summary>
        /// e-mail address? 
        /// </summary>
		public static string PlaceholderEmailAddress => ResourceProvider.GetString("PlaceholderEmailAddress");

        /// <summary>
        /// first name? 
        /// </summary>
		public static string PlaceholderFirstName => ResourceProvider.GetString("PlaceholderFirstName");

        /// <summary>
        /// keywords for search? 
        /// </summary>
		public static string PlaceholderKeywords => ResourceProvider.GetString("PlaceholderKeywords");

        /// <summary>
        /// last name? 
        /// </summary>
		public static string PlaceholderLastName => ResourceProvider.GetString("PlaceholderLastName");

        /// <summary>
        /// mobile phone number? 
        /// </summary>
		public static string PlaceholderMobilePhoneNumber => ResourceProvider.GetString("PlaceholderMobilePhoneNumber");

        /// <summary>
        /// neighborhood or settlement? 
        /// </summary>
		public static string PlaceholderNeighborhoodOrSettlement => ResourceProvider.GetString("PlaceholderNeighborhoodOrSettlement");

        /// <summary>
        /// post office ZIP? 
        /// </summary>
		public static string PlaceholderPostOfficeZIP => ResourceProvider.GetString("PlaceholderPostOfficeZIP");

        /// <summary>
        /// previous working experience? 
        /// </summary>
		public static string PlaceholderPreviousWorkingExperience => ResourceProvider.GetString("PlaceholderPreviousWorkingExperience");

        /// <summary>
        /// settlement? 
        /// </summary>
		public static string PlaceholderSettlement => ResourceProvider.GetString("PlaceholderSettlement");

        /// <summary>
        /// street? 
        /// </summary>
		public static string PlaceholderStreet => ResourceProvider.GetString("PlaceholderStreet");

        /// <summary>
        /// telephone 1? (e.g. 0991234123) 
        /// </summary>
		public static string PlaceholderTelephone1 => ResourceProvider.GetString("PlaceholderTelephone1");

        /// <summary>
        /// telephone 2? 
        /// </summary>
		public static string PlaceholderTelephone2 => ResourceProvider.GetString("PlaceholderTelephone2");

        /// <summary>
        /// web site (e.g. http://www.site.com) 
        /// </summary>
		public static string PlaceholderWebSite => ResourceProvider.GetString("PlaceholderWebSite");

        /// <summary>
        /// what makes you the best candidate? 
        /// </summary>
		public static string PlaceholderWhatMakesYourTheBestCandidate => ResourceProvider.GetString("PlaceholderWhatMakesYourTheBestCandidate");

        /// <summary>
        /// working time? 
        /// </summary>
		public static string PlaceholderWorkingTime => ResourceProvider.GetString("PlaceholderWorkingTime");

        /// <summary>
        /// Place order 
        /// </summary>
		public static string PlaceOrder => ResourceProvider.GetString("PlaceOrder");

        /// <summary>
        /// Please enter the company data. 
        /// </summary>
		public static string PleaseEnterTheCompanyData => ResourceProvider.GetString("PleaseEnterTheCompanyData");

        /// <summary>
        /// Please fill in the data which you want to show at your public company web site. Business category is mandatory. 
        /// </summary>
		public static string PleaseFillInTheDataWhichYouWantToShowAtYourPublicWebSite => ResourceProvider.GetString("PleaseFillInTheDataWhichYouWantToShowAtYourPublicWebSite");

        /// <summary>
        /// Please register to finalize your order. 
        /// </summary>
		public static string PleaseRegisterToFinalizeYourOrder => ResourceProvider.GetString("PleaseRegisterToFinalizeYourOrder");

        /// <summary>
        /// please select 
        /// </summary>
		public static string PleaseSelect => ResourceProvider.GetString("PleaseSelect");

        /// <summary>
        /// Please select the position 
        /// </summary>
		public static string PleaseSelectPosition => ResourceProvider.GetString("PleaseSelectPosition");

        /// <summary>
        /// PleaseSelectPositionsToApplyFor 
        /// </summary>
		public static string PleaseSelectPositionsToApplyFor => ResourceProvider.GetString("PleaseSelectPositionsToApplyFor");

        /// <summary>
        /// Please send e-mail to customer support. 
        /// </summary>
		public static string PleaseSendEmailToCustomerSupport => ResourceProvider.GetString("PleaseSendEmailToCustomerSupport");

        /// <summary>
        /// Please wait, saving in progress: 
        /// </summary>
		public static string PleaseWaitSavingInProgress => ResourceProvider.GetString("PleaseWaitSavingInProgress");

        /// <summary>
        /// Please wait while offer is created... 
        /// </summary>
		public static string PleaseWaitWhileOfferIsCreated => ResourceProvider.GetString("PleaseWaitWhileOfferIsCreated");

        /// <summary>
        /// Postal address 
        /// </summary>
		public static string PostalAddress => ResourceProvider.GetString("PostalAddress");

        /// <summary>
        /// Postal office 
        /// </summary>
		public static string PostalOffice => ResourceProvider.GetString("PostalOffice");

        /// <summary>
        /// Zip code 
        /// </summary>
		public static string PostalOfficeZipCode => ResourceProvider.GetString("PostalOfficeZipCode");

        /// <summary> 
        /// </summary>
		public static string PostanskaAdresaOibNadleznost => ResourceProvider.GetString("PostanskaAdresaOibNadleznost");

        /// <summary>
        /// post office? 
        /// </summary>
		public static string PostOffice => ResourceProvider.GetString("PostOffice");

        /// <summary>
        /// Privacy Policy 
        /// </summary>
		public static string PrivacyPolicy => ResourceProvider.GetString("PrivacyPolicy");

        /// <summary>
        /// WARNING: Your public page is not visible to public! Page becomes visible to public after the payment is confirmed. 
        /// </summary>
		public static string PublicPageNotVisibleToPublic => ResourceProvider.GetString("PublicPageNotVisibleToPublic");

        /// <summary>
        /// Question 
        /// </summary>
		public static string Question => ResourceProvider.GetString("Question");

        /// <summary>
        /// Question can't be sent right now. Please try again later. 
        /// </summary>
		public static string QuestionCantBeSentPleaseTryLater => ResourceProvider.GetString("QuestionCantBeSentPleaseTryLater");

        /// <summary>
        /// Question sent! Thank You. 
        /// </summary>
		public static string QuestionSentThankYou => ResourceProvider.GetString("QuestionSentThankYou");

        /// <summary>
        /// receive bills, order services, edit data, services controll... 
        /// </summary>
		public static string ReceiveBillsOrderServicesDataEdit => ResourceProvider.GetString("ReceiveBillsOrderServicesDataEdit");

        /// <summary>
        /// Registration is simple and quick. 
        /// </summary>
		public static string RegistrationIsSimpleAndQuick => ResourceProvider.GetString("RegistrationIsSimpleAndQuick");

        /// <summary>
        /// Company registration 
        /// </summary>
		public static string RegistrationLinkName => ResourceProvider.GetString("RegistrationLinkName");

        /// <summary>
        /// Company registration 
        /// </summary>
		public static string RegistrationPageTitle => ResourceProvider.GetString("RegistrationPageTitle");

        /// <summary>
        /// /registration 
        /// </summary>
		public static string RegistrationUrlPath => ResourceProvider.GetString("RegistrationUrlPath");

        /// <summary>
        /// Remember me 
        /// </summary>
		public static string RememberMe => ResourceProvider.GetString("RememberMe");

        /// <summary>
        /// Repeat password 
        /// </summary>
		public static string RepeatPassword => ResourceProvider.GetString("RepeatPassword");

        /// <summary>
        /// results 
        /// </summary>
		public static string ResultMultiple => ResourceProvider.GetString("ResultMultiple");

        /// <summary>
        /// result 
        /// </summary>
		public static string ResultSingle => ResourceProvider.GetString("ResultSingle");

        /// <summary>
        /// Retired 
        /// </summary>
		public static string Retired => ResourceProvider.GetString("Retired");

        /// <summary>
        /// Save data 
        /// </summary>
		public static string SaveData => ResourceProvider.GetString("SaveData");

        /// <summary>
        /// Saving 
        /// </summary>
		public static string Saving => ResourceProvider.GetString("Saving");

        /// <summary>
        /// Saving in progress... 
        /// </summary>
		public static string SavingInProgress => ResourceProvider.GetString("SavingInProgress");

        /// <summary>
        /// Search 
        /// </summary>
		public static string Search => ResourceProvider.GetString("Search");

        /// <summary>
        /// Search... 
        /// </summary>
		public static string SearchFieldTip => ResourceProvider.GetString("SearchFieldTip");

        /// <summary>
        /// Find the best, the most reliable company by name, address or service. 
        /// </summary>
		public static string SearchPageDescription => ResourceProvider.GetString("SearchPageDescription");

        /// <summary>
        /// SearchPageTitle 
        /// </summary>
		public static string SearchPageTitle => ResourceProvider.GetString("SearchPageTitle");

        /// <summary>
        /// Selected file is not an image! 
        /// </summary>
		public static string SelectedFileIsNotAnImage => ResourceProvider.GetString("SelectedFileIsNotAnImage");

        /// <summary>
        /// Selected file is too large (limit 10MB) 
        /// </summary>
		public static string SelectedFileIsTooLargeLimitSize => ResourceProvider.GetString("SelectedFileIsTooLargeLimitSize");

        /// <summary>
        /// Send 
        /// </summary>
		public static string Send => ResourceProvider.GetString("Send");

        /// <summary>
        /// Send Application 
        /// </summary>
		public static string SendApplication => ResourceProvider.GetString("SendApplication");

        /// <summary>
        /// Sending, please wait... 
        /// </summary>
		public static string SendingPleaseWait => ResourceProvider.GetString("SendingPleaseWait");

        /// <summary>
        /// Services 
        /// </summary>
		public static string ServicesLinkName => ResourceProvider.GetString("ServicesLinkName");

        /// <summary>
        /// Services 
        /// </summary>
		public static string ServicesPageTitle => ResourceProvider.GetString("ServicesPageTitle");

        /// <summary>
        /// /services 
        /// </summary>
		public static string ServicesUrlPath => ResourceProvider.GetString("ServicesUrlPath");

        /// <summary>
        /// Settlement 
        /// </summary>
		public static string Settlement => ResourceProvider.GetString("Settlement");

        /// <summary>
        /// Show 90 Days 
        /// </summary>
		public static string Show90Days => ResourceProvider.GetString("Show90Days");

        /// <summary>
        /// Document 
        /// </summary>
		public static string ShowDocumentLinkName => ResourceProvider.GetString("ShowDocumentLinkName");

        /// <summary>
        /// Document 
        /// </summary>
		public static string ShowDocumentPageTitle => ResourceProvider.GetString("ShowDocumentPageTitle");

        /// <summary>
        /// /document 
        /// </summary>
		public static string ShowDocumentUrlPath => ResourceProvider.GetString("ShowDocumentUrlPath");

        /// <summary>
        /// Show Hourly 
        /// </summary>
		public static string ShowHourly => ResourceProvider.GetString("ShowHourly");

        /// <summary>
        /// Show more results 
        /// </summary>
		public static string ShowMoreResults => ResourceProvider.GetString("ShowMoreResults");

        /// <summary>
        /// Sitemap 
        /// </summary>
		public static string SitemapLinkName => ResourceProvider.GetString("SitemapLinkName");

        /// <summary>
        /// Sitemap 
        /// </summary>
		public static string SitemapPageTitle => ResourceProvider.GetString("SitemapPageTitle");

        /// <summary>
        /// /sitemap 
        /// </summary>
		public static string SitemapUrlPath => ResourceProvider.GetString("SitemapUrlPath");

        /// <summary>
        /// name A-Z 
        /// </summary>
		public static string SortByNameAZ => ResourceProvider.GetString("SortByNameAZ");

        /// <summary>
        /// name Z-A 
        /// </summary>
		public static string SortByNameZA => ResourceProvider.GetString("SortByNameZA");

        /// <summary>
        /// relevance 
        /// </summary>
		public static string SortByRelevance => ResourceProvider.GetString("SortByRelevance");

        /// <summary>
        /// from latest 
        /// </summary>
		public static string SortFromLatest => ResourceProvider.GetString("SortFromLatest");

        /// <summary>
        /// from oldest 
        /// </summary>
		public static string SortFromOldest => ResourceProvider.GetString("SortFromOldest");

        /// <summary>
        /// Sorting 
        /// </summary>
		public static string Sorting => ResourceProvider.GetString("Sorting");

        /// <summary>
        /// Student 
        /// </summary>
		public static string Student => ResourceProvider.GetString("Student");

        /// <summary>
        /// Subject 
        /// </summary>
		public static string Subject => ResourceProvider.GetString("Subject");

        /// <summary>
        /// Success, redirecting... 
        /// </summary>
		public static string SuccessRedirecting => ResourceProvider.GetString("SuccessRedirecting");

        /// <summary>
        /// support@site.com 
        /// </summary>
		public static string SupportEmailAddress => ResourceProvider.GetString("SupportEmailAddress");

        /// <summary>
        /// - 
        /// </summary>
		public static string SupportPhoneNumber => ResourceProvider.GetString("SupportPhoneNumber");

        /// <summary>
        /// System error occured. Please try again later. 
        /// </summary>
		public static string SystemErrorPleaseTryAgainLater => ResourceProvider.GetString("SystemErrorPleaseTryAgainLater");

        /// <summary>
        /// Telephone 
        /// </summary>
		public static string Telephone => ResourceProvider.GetString("Telephone");

        /// <summary>
        /// Terms 
        /// </summary>
		public static string Terms => ResourceProvider.GetString("Terms");

        /// <summary>
        /// Document containing Terms of service is available on the link below. 
        /// </summary>
		public static string TermsDescription => ResourceProvider.GetString("TermsDescription");

        /// <summary>
        /// Terms content 
        /// </summary>
		public static string TermsFileLinkName => ResourceProvider.GetString("TermsFileLinkName");

        /// <summary>
        /// Terms Content 
        /// </summary>
		public static string TermsFilePageTitle => ResourceProvider.GetString("TermsFilePageTitle");

        /// <summary>
        /// /terms-file 
        /// </summary>
		public static string TermsFileUrlPath => ResourceProvider.GetString("TermsFileUrlPath");

        /// <summary>
        /// Terms 
        /// </summary>
		public static string TermsLinkName => ResourceProvider.GetString("TermsLinkName");

        /// <summary>
        /// Terms Of Use 
        /// </summary>
		public static string TermsOfUse => ResourceProvider.GetString("TermsOfUse");

        /// <summary>
        /// Terms Of Service 
        /// </summary>
		public static string TermsPageTitle => ResourceProvider.GetString("TermsPageTitle");

        /// <summary>
        /// /terms 
        /// </summary>
		public static string TermsUrlPath => ResourceProvider.GetString("TermsUrlPath");

        /// <summary>
        /// Today 
        /// </summary>
		public static string Today => ResourceProvider.GetString("Today");

        /// <summary>
        /// Tomorrow 
        /// </summary>
		public static string Tomorrow => ResourceProvider.GetString("Tomorrow");

        /// <summary>
        /// Tomorrow + 1 
        /// </summary>
		public static string TomrrowPlusOne => ResourceProvider.GetString("TomrrowPlusOne");

        /// <summary>
        /// TOP SLOGAN 
        /// </summary>
		public static string TopSlogan => ResourceProvider.GetString("TopSlogan");

        /// <summary>
        /// Unemployed 
        /// </summary>
		public static string Unemployed => ResourceProvider.GetString("Unemployed");

        /// <summary>
        /// Please enter digits only for telephone number 
        /// </summary>
		public static string ValidationTelephoneError => ResourceProvider.GetString("ValidationTelephoneError");

        /// <summary>
        /// Valid e-mail address has to be entered. 
        /// </summary>
		public static string ValidEmailAddressHasToBeEntered => ResourceProvider.GetString("ValidEmailAddressHasToBeEntered");

        /// <summary>
        /// VAT 
        /// </summary>
		public static string VAT => ResourceProvider.GetString("VAT");

        /// <summary>
        /// VAT included 
        /// </summary>
		public static string VATIncluded => ResourceProvider.GetString("VATIncluded");

        /// <summary>
        /// Visitors 
        /// </summary>
		public static string Visitors => ResourceProvider.GetString("Visitors");

        /// <summary>
        /// Weather Forecast 
        /// </summary>
		public static string WeatherForecast => ResourceProvider.GetString("WeatherForecast");

        /// <summary>
        /// Weather Forecast by City 
        /// </summary>
		public static string WeatherForecastByCities => ResourceProvider.GetString("WeatherForecastByCities");

        /// <summary>
        /// Weather Forecast 90 Day 
        /// </summary>
		public static string WeatherForecastDailyNext90DaysLinkName => ResourceProvider.GetString("WeatherForecastDailyNext90DaysLinkName");

        /// <summary>
        /// Weather Forecast Hourly 
        /// </summary>
		public static string WeatherForecastHourlyNext3DaysLinkName => ResourceProvider.GetString("WeatherForecastHourlyNext3DaysLinkName");

        /// <summary>
        /// Weather Forecast 
        /// </summary>
		public static string WeatherForecastLinkName => ResourceProvider.GetString("WeatherForecastLinkName");

        /// <summary>
        /// weather forecast hourly next 3 days 
        /// </summary>
		public static string WeatherForecastNext3Days => ResourceProvider.GetString("WeatherForecastNext3Days");

        /// <summary>
        /// weather forecast daily next 90 days 
        /// </summary>
		public static string WeatherForecastNext90Days => ResourceProvider.GetString("WeatherForecastNext90Days");

        /// <summary>
        /// Weather Forecast 
        /// </summary>
		public static string WeatherForecastPageTitle => ResourceProvider.GetString("WeatherForecastPageTitle");

        /// <summary>
        /// /weather-forecast 
        /// </summary>
		public static string WeatherForecastUrlPath => ResourceProvider.GetString("WeatherForecastUrlPath");

        /// <summary>
        /// Web form inquiry 
        /// </summary>
		public static string WebFormInquiry => ResourceProvider.GetString("WebFormInquiry");

        /// <summary>
        /// Web site 
        /// </summary>
		public static string WebSiteAddress => ResourceProvider.GetString("WebSiteAddress");

        /// <summary>
        /// If you wish, we may save your application and send you notifications for similar jobs. 
        /// </summary>
		public static string WeWillSaveYourApplicationForFutureDescription => ResourceProvider.GetString("WeWillSaveYourApplicationForFutureDescription");

        /// <summary>
        /// <option>Won't say</option> 
        /// </summary>
		public static string WhereFoundUsOptions => ResourceProvider.GetString("WhereFoundUsOptions");

        /// <summary>
        /// Working time 
        /// </summary>
		public static string WorkingTime => ResourceProvider.GetString("WorkingTime");

        /// <summary>
        /// Yes 
        /// </summary>
		public static string Yes => ResourceProvider.GetString("Yes");

        /// <summary>
        /// Your Name 
        /// </summary>
		public static string YourName => ResourceProvider.GetString("YourName");

        /// <summary>
        /// Your public page address: 
        /// </summary>
		public static string YourPublicPageAddress => ResourceProvider.GetString("YourPublicPageAddress");

        /// <summary>
        /// Your public page short address: 
        /// </summary>
		public static string YourPublicPageShortAddress => ResourceProvider.GetString("YourPublicPageShortAddress");

	}
}
