using Calysto.Globalization;

namespace Calysto.Genesis.Tests.Calysto.DataAnnotations.ValidationService.Models
{
    public class Arizona : ICalystoResx
    {
		private Arizona(){ }

		static string[] _columns = new string[] { "property", "en-US", "hr-HR" };

		const string _json = "{\"__calystotype\":\"Calysto_DataTable\",\"TotalCount\":null,\"TableName\":\"\",\"Columns\":[\"property\",\"en-US\",\"hr-HR\"],\"Rows\":[[\"AccessControl\",\"Access Control\",\"Prava pristupa\"],[\"AccountSettingLinkName\",\"Account setting\",\"Postavke profila\"],[\"AccountSettingPageTitle\",\"Account setting\",\"Postavke profila\"],[\"AccountSettingUrlPath\",\"/account-setting\",\"/profil-postavke\"],[\"Action\",\"Action\",\"Akcija\"],[\"ActionFailed\",\"Action failed\",\"Akcija nije uspjela\"],[\"ActionSuccessful\",\"Action successful\",\"Akcija uspješna\"],[\"Active\",\"Active\",\"Aktivno\"],[\"ActiveAdverts\",\"Active Adverts\",\"Aktivni\"],[\"Add\",\"Add\",\"Dodaj\"],[\"AddBillOperator\",\"Add operator\",\"Dodaj operatora\"],[\"AddBusinessSpace\",\"Add business space\",\"Dodaj poslovni prostor\"],[\"AddCategory\",\"Add category\",\"Dodaj kategoriju\"],[\"AddCertificate\",\"Add certificate\",\"Dodaj certifikat\"],[\"AddChargingDevice\",\"Add charging device\",\"Dodaj naplatni uređaj\"],[\"AddItem\",\"Add item\",\"Dodaj stavku\"],[\"AddNewAdvert\",\"Add New Advert\",\"Dodaj novi oglas\"],[\"AddNewCategory\",\"Add new category\",\"Dodaj novu kategoriju\"],[\"AddNewCertificate\",\"Add new certificate\",\"Dodavanje novog certifikata\"],[\"AddNewMember\",\"Add New Member\",\"Dodaj novog korisnika\"],[\"AddNewSchedule\",\"Add New Schedule\",\"Dodaj novi sastanak\"],[\"AddNewScheduleType\",\"Add New Schedule Type\",\"Dodaj naziv termina\"],[\"AddNewStatus\",\"Add New Status\",\"Dodaj novi status\"],[\"AddNewSubCategory\",\"Add subcategory\",\"Dodaj podkategoriju\"],[\"AddNewTemplate\",\"Add new template\",\"Dodaj template\"],[\"AddNormativ\",\"Add normativ\",\"Dodavanje normativa\"],[\"AddOrSelectBranchOffice\",\"Please add or select branch office\",\"Dodajte ili odaberite poslovni prostor\"],[\"AddOrSelectPaymentType\",\"Add or select payment type\",\"Dodajte ili odaberite način plaćanja\"],[\"AddPoreznaGrupa\",\"Add tax group\",\"Dodaj poreznu grupu\"],[\"AddPoreznaGrupaFirst\",\"Tax group has to be added first\",\"Morate kreirati barem jednu poreznu grupu prvo\"],[\"AddProduct\",\"Add product\",\"Dodaj produkt\"],[\"Address\",\"Address\",\"Adresa\"],[\"Administrative\",\"Administrative\",\"Administrativno\"],[\"AdminLinkName\",\"Admin\",\"Admin\"],[\"AdminLoginTitle\",\"WebSite Admin\",\"eAdmin backend\"],[\"AdminPageTitle\",\"Admin\",\"Admin\"],[\"AdminToolsLinkName\",\"Admin tools\",\"Admin tools\"],[\"AdminToolsPageTitle\",\"Admin tools\",\"Admin tools\"],[\"AdminToolsUrlPath\",\"/admin-tools\",\"/admin-tools\"],[\"Advert\",\"Advert\",\"Oglas\"],[\"AdvertDataUpdated\",\"Advert data updated\",\"Oglas je ažuriran\"],[\"AdvertID\",\"Advert ID\",\"Oglas ID\"],[\"Aktivno\",\"Active\",\"Aktivno\"],[\"All\",\"All\",\"Svi\"],[\"AllAdverts\",\"All Adverts\",\"Svi oglasi\"],[\"AllStatuses\",\"All Statuses\",\"Svi statusi\"],[\"AmountWithTax\",\"Amount+Tax\",\"Iznos+PDV\"],[\"ApplicantDetails\",\"Applicant Details\",\"Detalji o kandidatu\"],[\"Applicants\",\"Applicants\",\"Kandidati\"],[\"ApplicantsCount\",\"Applicants Count\",\"Broj prijava\"],[\"ApplicantStatus\",\"Applicant Status\",\"Status kandidata\"],[\"ApplyFilter\",\"Apply Filter\",\"Primijeni filter\"],[\"ArizonaReferentiLinkName\",\"Account managers\",\"Referenti\"],[\"ArizonaReferentiPageTitle\",\"Account managers\",\"Referenti\"],[\"ArizonaReferentiUrlPath\",\"/account-manager\",\"/referenti\"],[\"ArticleVisibleInPOS\",\"Article (for sale, visible in POS)\",\"Artikl (za prodaju, vidljiv u blagajni)\"],[\"Artikl\",\"Article\",\"Artikl\"],[\"Available\",\"Available\",\"Dostupno\"],[\"BankAccountIBAN\",\"Bank account IBAN\",\"IBAN\"],[\"Barcode\",\"Barcode\",\"Barkod\"],[\"BezKategorije\",\"Without category\",\"Bez kategorije\"],[\"BillClientID\",\"BillClientID\",\"BillClientID\"],[\"BillDate\",\"Bill date\",\"Datum računa\"],[\"BillOperatorData\",\"Bill operator data\",\"Podaci o operatoru za račune\"],[\"BillOperatorMark\",\"Operator mark\",\"Oznaka operatora\"],[\"BillOperatorUniqueNumber\",\"Operator unique number\",\"OIB operatora\"],[\"Bills\",\"Bills\",\"Računi\"],[\"BillsAndNonPaidOffers\",\"Bills and non-paid offers\",\"Računi i neplaćene ponude\"],[\"BillsExport\",\"Bills Export\",\"Izvoz računa\"],[\"BillsLinkName\",\"Bills\",\"Računi\"],[\"BillsPageTitle\",\"Bills\",\"Računi\"],[\"BillsUrlPath\",\"/bills\",\"/racuni\"],[\"BirthDate\",\"Birth Date\",\"Datum rođenja\"],[\"Bookkeeping\",\"Bookkeeping\",\"Knjigovodstvo\"],[\"BrisanjeArtiklaNijeMoguce\",\"Product can not be deleted\",\"Brisanje artikla nije moguće\"],[\"BrojAktivnihUsluga\",\"Active services count\",\"Broj aktivnih usluga\"],[\"ButtonA4\",\"A4\",\"A4\"],[\"ButtonPDF\",\"PDF\",\"PDF\"],[\"ButtonPOS\",\"POS\",\"POS\"],[\"ButtonSend\",\"Send\",\"Pošalji\"],[\"CalendarIsEmptyForSelectedDate\",\"Calendar is emtpy for selected date\",\"Kalendar je prazan za odabrani datum\"],[\"CallCenter\",\"Call Center\",\"Pozivni centar\"],[\"CallsLinkName\",\"Calls\",\"Pozivi\"],[\"CallsPageTitle\",\"Calls\",\"Pozivi\"],[\"CallsUrlPath\",\"/calls\",\"/pozivi\"],[\"Cancel\",\"Cancel\",\"Odustani\"],[\"Canceled\",\"Canceled\",\"Otkazano\"],[\"CancelSelected\",\"Cancel selected\",\"Otkaži odabrano\"],[\"CanNotAddMoreItemsLimitReached\",\"Adding is not possible - the limit is reached\",\"Limit postignut\"],[\"CartIsEmpty\",\"Cart is empty\",\"Košarica je prazna\"],[\"Categories\",\"Categories\",\"Kategorije\"],[\"CategoriesMax\",\"Categories max\",\"Kategorije max\"],[\"CategoriesSpent\",\"Categories\",\"Kategorije\"],[\"Category\",\"Category\",\"Kategorija\"],[\"CategoryList\",\"Category list\",\"Popis kategorija\"],[\"CekaStart\",\"Start pending\",\"Čeka start\"],[\"CertificateDeletedRefreshing\",\"Certificate deleted, refreshing\",\"Certifikat je obrisan, osvježavam\"],[\"CertifikatIspravan\",\"Certifikat ispravan\",\"Certifikat ispravan\"],[\"CertifikatIzdavac\",\"Publisher\",\"Izdavač\"],[\"CertifikatJeUspjesnoSpremljenOsvjezavam\",\"The certificate has been successfully saved, refreshing\",\"Certifikat je uspješno spremljen, osvježavam\"],[\"CertifikatJeVecUnesenPonovniUnosNijeMoguc\",\"Certificate already entered, re-entry is not possible.\",\"Certifikat je već unešen, ponovni unos nije moguć.\"],[\"CertifikatNijeIspravan\",\"The certificate is incorrect.\",\"Certifikat nije ispravan.\"],[\"CertifikatNijeIspravanNedostajePrivatniKljuc\",\"The certificate is incorrect, the private key is missing.\",\"Certifikat nije ispravan, nedostaje privatni ključ.\"],[\"CertifikatSubjekt\",\"Subject\",\"Subjekt\"],[\"CertifikatTip\",\"Type\",\"Tip\"],[\"Checking\",\"Checking...\",\"Provjeravam...\"],[\"City\",\"City\",\"Grad ili mjesto\"],[\"ClientName\",\"Client Name\",\"Naziv klijenta\"],[\"Close\",\"Close\",\"Zatvori\"],[\"CompanyName\",\"Company Name\",\"Naziv tvrtke ili obrta\"],[\"CompanyUniqueNumber\",\"Company unique number\",\"OIB tvrtke ili obrta\"],[\"ContactData\",\"Contact data\",\"Podaci za kontakt\"],[\"ConversionAll\",\"Conversion all\",\"Konverzija svi\"],[\"ConversionCheck\",\"Conversion check\",\"Provjera konverzije\"],[\"ConversionDueExpired\",\"Conversion due expired\",\"Konverzija dospjeli\"],[\"CopyrightText\",\"Finance Group\",\"eAdmin\"],[\"CRM\",\"CRM\",\"CRM\"],[\"CrmOglasnikLinkName\",\"Yellow pages\",\"Oglasnik\"],[\"CrmOglasnikPageTitle\",\"Yellow pages\",\"Oglasnik\"],[\"CrmOglasnikUrlPath\",\"/crm-yellow-pages\",\"/crm-oglasnik\"],[\"CrmRadnoVrijemeLinkName\",\"Work time\",\"Radno vrijeme\"],[\"CrmRadnoVrijemePageTitle\",\"Work time\",\"Radno vrijeme\"],[\"CrmRadnoVrijemeUrlPath\",\"/crm-work-time\",\"/crm-radno-vrijeme\"],[\"Currency\",\"Currency\",\"Valuta\"],[\"Customer\",\"Customer\",\"Kupac\"],[\"CustomerEditor\",\"Customer editor\",\"Uredi kupca\"],[\"CustomerSearch\",\"Customer search\",\"Traži kupca\"],[\"CustomerUniqueNumberOrName\",\"Unique nuber or name\",\"OIB ili naziv kupca\"],[\"DataCopiedToClipboard\",\"Data copied to clipboard\",\"Podaci su prekopirani u clipboard\"],[\"DataSaved\",\"Data saved\",\"Podaci su spremljeni\"],[\"DataSavedReloading\",\"Data saved, reloading\",\"Podaci su spremljeni, osvježavam\"],[\"Date\",\"Date\",\"Datum\"],[\"DateHasToBeSelected\",\"Date has to be selected\",\"Datum mora biti odabran\"],[\"Datum\",\"Date\",\"Datum\"],[\"DatumDospijeca\",\"Due date\",\"Datum dospijeća\"],[\"DatumiDokumenta\",\"Document dates\",\"Datumi dokumenta\"],[\"DatumPonude\",\"Offer date\",\"Datum ponude\"],[\"DatumRacuna\",\"Bill date\",\"Datum računa\"],[\"DatumStornoRacuna\",\"Cancellation bill date\",\"Datum storno računa\"],[\"DatumValute\",\"Currency date\",\"Datum valute\"],[\"DatumZadnjegRacuna\",\"Last bill date\",\"Datum zadnjeg računa\"],[\"DecimalniSeparator\",\"decimal separator\",\"decimalni separator\"],[\"Delete\",\"Delete\",\"Obriši\"],[\"DeleteAreYouSure\",\"Delete, are you sure?\",\"Obrisati, jeste li sigurni?\"],[\"DeleteCart\",\"Delete cart\",\"Obriši košaricu\"],[\"DeleteCategory\",\"Delete category\",\"Obriši kategoriju\"],[\"DeleteCertificate\",\"Delete certificate\",\"Obrisati certifikat\"],[\"DeleteDocumentConfirmation\",\"Delete document, are you sure?\",\"Obrisati dokument, jeste li sigurni?\"],[\"DeleteImageConfirmation\",\"Delete image, are you sure?\",\"Obrisati sliku, jeste li sigurni?\"],[\"DeleteProduct\",\"Delete product\",\"Obriši artikl\"],[\"DeleteSelected\",\"Delete Selected\",\"Obriši odabrano\"],[\"DeleteSelectedScheduleAreYouSure\",\"Delete selected schedule. Are you sure?\",\"Obrisati odabrani termin. Jeste li sigurni?\"],[\"DeleteTheLatestAreYouSure\",\"Delete the latest one, are you sure?\",\"Obrisati najnovijeg, jeste li sigurni?\"],[\"Description\",\"Description\",\"Opis\"],[\"Details\",\"Details\",\"Detalji\"],[\"DnevniObracunLinkName\",\"Daily calculation\",\"Dnevni obračun\"],[\"DnevniObracunPageTitle\",\"Daily calculation\",\"Dnevni obračun\"],[\"DnevniObracunUrlPath\",\"/dnevni-obracun\",\"/dnevni-obracun\"],[\"DocumentDate\",\"Document date\",\"Datum dokumenta\"],[\"Documents\",\"Documents\",\"Dokumenti\"],[\"DocumentsCount\",\"Documents count\",\"Broj dokumenata\"],[\"DocumentsForPrinting\",\"Documents for printing\",\"Dokumenti za ispis\"],[\"DocumentsLeft\",\"Documents left\",\"Preostalo dokumenata\"],[\"DocumentsLinkName\",\"Documents\",\"Dokumenti\"],[\"DocumentsMax\",\"Documents max\",\"Dokumenti max\"],[\"DocumentsPageTitle\",\"Documents\",\"Dokumenti\"],[\"DocumentsUrlPath\",\"/documents\",\"/dokumenti\"],[\"DocumentType\",\"DocumentType\",\"Tip dokumenta\"],[\"DodajPoreznuGrupu\",\"Add tax group\",\"Dodaj poreznu grupu\"],[\"DodatakKucnomBroju\",\"House number addition\",\"Dodatak kućnom broju\"],[\"DokumentiRacuniPonude\",\"Documents (bills and offers)\",\"Dokumenti (računi i ponude)\"],[\"Duplicate\",\"Duplicate\",\"Dupliciraj\"],[\"DuplicatedNamesFound\",\"Duplicated names found\",\"Duplicirani naziv\"],[\"DuplicateOfferAreYouSure\",\"Duplicate offer. Are you sure?\",\"Duplicirati ponudu. Jeste li sigurni?\"],[\"DupliciranjeNijeMoguceNijePlaceno\",\"Duplication is not possible, document is not offer or offer is not paid\",\"Dupliciranje nije moguće, dokument nije ponuda ili ponuda nije plaćena\"],[\"DupliciranjeNijeMogucePonudaNijePlacena\",\"Duplication is not possible, offer is not paid\",\"Dupliciranje nije moguće, ponuda nije plaćena\"],[\"DurationHasToBeLargerThanZero\",\"Duration has to be larger than 0\",\"Trajanje mora biti veće od 0\"],[\"DurationMinutes\",\"Duration minutes\",\"Trajanje minuta\"],[\"DurationTime\",\"Duration Time\",\"Trajanje\"],[\"Edit\",\"Edit\",\"Uredi\"],[\"EditCategory\",\"Edit category\",\"Uredi kategoriju\"],[\"EditNormativ\",\"Edit normativ\",\"Izmjena normativa\"],[\"EditProduct\",\"Edit product\",\"Uredi produkt\"],[\"EditScheduleTypeName\",\"Edit Schedule Type Name\",\"Uredi naziv termina\"],[\"EditStatus\",\"Edit Status\",\"Uredi status\"],[\"Education\",\"Education\",\"Obrazovanje\"],[\"Email\",\"E-mail\",\"E-mail\"],[\"EmailAddress\",\"Email Address\",\"E-mail adresa\"],[\"EmploymentStatus\",\"Employment Status\",\"Status\"],[\"EmptyNamesCanNotBeSaved\",\"Empty names can not be saved\",\"Prazni naziv ne može biti spremljen\"],[\"EndDate\",\"End Date\",\"Datum završetka\"],[\"EndDateHasToBeLargerThanStartDate\",\"End date has to be larger than start date\",\"Datum završetka mora biti veći od datuma početka\"],[\"EndDateIsOutOfRange\",\"End date is out of range\",\"Datum završetka je izvan valjanog intervala\"],[\"EndDateYearHasToBeGreaterThan\",\"End Date year has to be greater than 1900\",\"Datum završetka mora biti veći od 1900\"],[\"EnterThePartOfTheName\",\"Enter the partial name\",\"Unesite dio naziva\"],[\"ErrorInApplicationReloadThePage\",\"Error in application, reload the page\",\"Greška u aplikaciji, osvježite stranicu\"],[\"Evaluation\",\"Evaluation\",\"Ocjena\"],[\"EvaluationAskingQuestions\",\"Asking Questions\",\"Postavljanje pitanja\"],[\"EvaluationAttitude\",\"Attitude\",\"Stav\"],[\"EvaluationClothing\",\"Clothing\",\"Odjeća\"],[\"EvaluationCommunicationNonVerbal\",\"Communication Non Verbal\",\"Neverbalna komunikacija\"],[\"EvaluationCommunicationVerbal\",\"Communication Verbal\",\"Verbalna komunikacija\"],[\"EvaluationGeneral\",\"Evaluation General\",\"Opća ocjena\"],[\"EvaluationSaved\",\"Evaluation Saved\",\"Ocjena je spremljena\"],[\"EvaluationTechicalKnowledge\",\"Technical Knowledge\",\"Tehničko znanje\"],[\"EvidencijaGotovineLinkName\",\"Cash flow\",\"Evidencija gotovine\"],[\"EvidencijaGotovinePageTitle\",\"Cash flow\",\"Evidencija gotovine\"],[\"EvidencijaGotovineUrlPath\",\"/cash-flow\",\"/evidencija-gotovine\"],[\"Expired\",\"Expired\",\"Isteklo\"],[\"ExpiredAdverts\",\"Expired Adverts\",\"Istekli\"],[\"ExportEmails\",\"Export Emails\",\"Dohvati emailove\"],[\"ExportPhones\",\"Export phones\",\"Dohvati telefone\"],[\"FiduciaLinkName\",\"Fiducia\",\"Fiducia\"],[\"FiduciaPageTitle\",\"Fiducia\",\"Fiducia\"],[\"FiduciaUrlPath\",\"/fiducia\",\"/fiducia\"],[\"FilterByAdvert\",\"Filter by Advert\",\"Filter prema oglasu\"],[\"Finances\",\"Finances\",\"Financije\"],[\"FirstName\",\"Frist Name\",\"Ime\"],[\"FiskalCertificate\",\"Fiskal certificate\",\"Fiskalni certifikat\"],[\"FiskalniRacun\",\"Fiskal bill\",\"Fiskalni račun\"],[\"FromHighestEvaluation\",\"From Highest Evaluation\",\"Od najviše ocjene\"],[\"FromNewestApplication\",\"From Newest Application\",\"Od najnovije prijave\"],[\"FromOldestApplication\",\"From Oldest Application\",\"Od najstarije prijave\"],[\"Generate\",\"Generate\",\"Generiraj\"],[\"GenerateAreYouSure\",\"Generate, are you sure?\",\"Generirati, jeste li sigurni?\"],[\"GeneratePdf\",\"Generate Pdf\",\"Generiraj pdf\"],[\"GeolocationToolsLinkName\",\"Geolocation tools\",\"Geolocation tools\"],[\"GeolocationToolsPageTitle\",\"Geolocation tools\",\"Geolocation tools\"],[\"GeolocationToolsUrlPath\",\"/gelocation-tools\",\"/gelocation-tools\"],[\"GetMoreItems\",\"Get more items\",\"Dohvati još\"],[\"Greska\",\"Error\",\"Greška\"],[\"GreskaKosaricaObrisana\",\"Error! Cart deleted.\",\"Greška! Košarica je obrisana.\"],[\"GrupiranjePrema\",\"Group by\",\"Grupiranje prema\"],[\"Held\",\"Held\",\"Održan\"],[\"IBANAlreadyExists\",\"IBAN already exists\",\"IBAN već postoji\"],[\"ImportErsteCsv\",\"Import Erste CSV\",\"Import Erste CSV\"],[\"ImportPbzExcelXls\",\"Import PBZ Excel xls\",\"Import PBZ Excel xls\"],[\"ImportPbzXml\",\"Import PBZ XML\",\"Import PBZ XML\"],[\"ImportTransactionFile\",\"Import transactions file\",\"Import transakcije\"],[\"Info\",\"Info\",\"Info\"],[\"InfoTelephone\",\"Info telephone\",\"Info-telefon\"],[\"InvalidAdverts\",\"Invalid Adverts\",\"Neispravni\"],[\"InvalidData\",\"Invalid data\",\"Podaci nisu ispravni\"],[\"InvalidIBAN\",\"Invalid IBAN\",\"Neispravan IBAN\"],[\"Iskoristeno\",\"Used\",\"Iskorišteno\"],[\"IsMain\",\"Main\",\"Glavni\"],[\"IspisiNaA4\",\"Write to A4\",\"Ispiši na A4\"],[\"IspisiNaPOS\",\"Write to POS\",\"Ispiši na POS\"],[\"Isteklo\",\"Expired\",\"Isteklo\"],[\"IsVisible\",\"Is visible\",\"Vidljiv\"],[\"IzdajeSeRacunSaSadasnjimDatumomTeSeFiskalizira\",\"Will create fiskal bill with current date\",\"Izdaje se račun sa sadašnjim datumom te se fiskalizira.\"],[\"IznosNaknadeLabel\",\"Iznos naknade\",\"Iznos naknade\"],[\"JedinicnaCijena\",\"Single price\",\"Jedinična cijena\"],[\"Job\",\"Job\",\"Posao\"],[\"JobAdverts\",\"Job Adverts\",\"Oglasi\"],[\"JobAdvertsLinkName\",\"Job adverts\",\"Oglasi\"],[\"JobAdvertsPageTitle\",\"Job adverts\",\"Oglasi\"],[\"JobAdvertsUrlPath\",\"/job-adverts\",\"/posao-oglasi\"],[\"JobApplicantsLinkName\",\"Job applicants\",\"Kandidati\"],[\"JobApplicantsPageTitle\",\"Job applicants\",\"Kandidati\"],[\"JobApplicantsUrlPath\",\"/job-applicants\",\"/posao-kandidati\"],[\"JobCalendar\",\"Job Calendar\",\"Kalendar\"],[\"JobCalendarLinkName\",\"Job calendar\",\"Kalendar\"],[\"JobCalendarPageTitle\",\"Job calendar\",\"Kalendar\"],[\"JobCalendarUrlPath\",\"/job-calendar\",\"/posao-kalendar\"],[\"JobCompanies\",\"Companies\",\"Tvrtke\"],[\"JobTemplatesLinkName\",\"Templates\",\"Predlošci\"],[\"JobTemplatesPageTitle\",\"Templates\",\"Predlošci\"],[\"JobTemplatesUrlPath\",\"/job-templates\",\"/posao-predlosci\"],[\"KaoDatumPonude\",\"Same as offer date\",\"Kao datum ponude\"],[\"KaoDatumRacuna\",\"Same as bill date\",\"Kao datum računa\"],[\"KategorijaImaArtikleBrisanjeNijeMoguce\",\"Category has articles, it can\\u0027t be deleted!\",\"Kategorija ima artikle, brisanje nije moguće!\"],[\"KategorijaImaPodkategorijeBrisanjeNijeMoguce\",\"Category has subcategories, it can\\u0027t be deleted!\",\"Kategorija ima podkategorije, brisanje nije moguće!\"],[\"KategorijaVecPostojiDodavanjeNijeMoguce\",\"Category already exists, can\\u0027t be added.\",\"Kategorija već postoji, dodavanje nije moguće.\"],[\"Kategorije\",\"Categories\",\"Kategorije\"],[\"Kolicina\",\"Quantity\",\"Količina\"],[\"KrajPrimjene\",\"Service end\",\"Kraj primjene\"],[\"KreiraSeAutomatskiNaSpremanju\",\"Created automatically\",\"Kreira se automatski\"],[\"KucniBroj\",\"House number\",\"Kućni broj\"],[\"LastName\",\"Last Name\",\"Prezime\"],[\"Litmits\",\"Litmits\",\"Limiti\"],[\"Loading\",\"Loading\",\"Učitavam\"],[\"LoadMoreItems\",\"Load more items\",\"Dohvati još\"],[\"Login\",\"Login\",\"Prijava\"],[\"LoginData\",\"Login Data\",\"Podaci za prijavu\"],[\"LoginLinkName\",\"Login\",\"Login\"],[\"LoginPageTitle\",\"Login\",\"Login\"],[\"LoginUrlPath\",\"/login\",\"/login\"],[\"Logout\",\"Logout\",\"Odjava\"],[\"LozinkaNeOdgovaraOdabranomCertifikatu\",\"The password does not match the selected certificate.\",\"Lozinka ne odgovara odabranom certifikatu.\"],[\"MainData\",\"Main Data\",\"Osnovni podaci\"],[\"MaloprodajnaMPC\",\"Retail (MPC)\",\"Maloprodajna (MPC)\"],[\"MarkPaymentDone\",\"Mark paid\",\"Proknjiži\"],[\"MessageFailed\",\"Message failed\",\"Slanje poruke nije uspjelo\"],[\"MessageSent\",\"Message sent\",\"Poruka poslana\"],[\"Mjera\",\"Units\",\"Mjera\"],[\"Mjesto\",\"City\",\"Mjesto\"],[\"MobilePhone\",\"Mobile Phone\",\"Mobitel\"],[\"MobitelLabelWithExample\",\"Mobitel (3859xxxxxxxx)\",\"Mobitel (3859xxxxxxxx)\"],[\"MobitelNijeIspravan\",\"The cell phone is not correct\",\"Mobitel nije ispravan\"],[\"ModifyAdvert\",\"Modify Advert\",\"Uredi oglas\"],[\"ModifyBillOperator\",\"Modify operator\",\"Uređivanje operatora\"],[\"ModifySchedule\",\"Modify Schedule\",\"Uredi sastanak\"],[\"ModifyTemplate\",\"Modify template\",\"Izmijeni template\"],[\"MolimoUpisiteNajmanjeXZnamenki\",\"Please enter 2 chars min.\",\"Molimo upišite najmanje 2 znamenke\"],[\"MPC\",\"MPC\",\"MPC\"],[\"NaknadnoMijenjanjeNijeMoguce\",\"Subsequent modification is not possible.\",\"Naknadno mijenjanje nije moguće.\"],[\"Name\",\"Name\",\"Naziv\"],[\"NameCanNotBeEmpty\",\"Name can not be empty\",\"Naziv ne može biti prazan\"],[\"NameHasToBeEntered\",\"Name has to be entered\",\"Naziv mora biti unesen\"],[\"Naplaceno\",\"Charged\",\"Naplaćeno\"],[\"NaplatniUredjaj\",\"Payment type\",\"Naplatni uređaj\"],[\"NaplatniUredjaji\",\"Payment types\",\"Naplatni uređaji\"],[\"NaplatniUredjajiMax\",\"Payment types max\",\"Naplatni uređaji max\"],[\"Napomena\",\"Note\",\"Napomena\"],[\"NazivArtiklaNaRacunu\",\"Article name (at bill)\",\"Naziv artikla (na računu)\"],[\"NazivGrupe\",\"Group name\",\"Naziv grupe\"],[\"NazivKategorije\",\"Category name\",\"Naziv kategorije\"],[\"NazivNaknadeLabel\",\"Name of compensation\",\"Naziv naknade\"],[\"NazivNaplatnogUredjaja\",\"Name of tolling device\",\"Naziv naplatnog uređaja\"],[\"NazivProstora\",\"Space name\",\"Naziv prostora\"],[\"NazivStavke\",\"Item name\",\"Naziv stavke\"],[\"NedostajeAdresaKupca\",\"Missing customer address\",\"Nedostaje adresa kupca\"],[\"NedostajeNazivKupca\",\"Missing customer name\",\"Nedostaje naziv kupca\"],[\"NedostajeOIBKupca\",\"Missing unique number\",\"Nedostaje OIB kupca\"],[\"NedovrseniProdukti\",\"Pending products\",\"Nedovršeni produkti\"],[\"NemaAktivnihUsluga\",\"No active services\",\"Nema aktivnih usluga\"],[\"NemaArtikala\",\"No articles\",\"Nema artikala\"],[\"NemateAktivnuUsluguFiskalneBlagajne\",\"You have no active POS services.\",\"Nemate aktivnu uslugu fiskalne blagajne.\"],[\"NematePravaZaDodjeljivanjeOveKategorije\",\"You have no right to assign current category.\",\"Nemate prava za dodjeljivanje ove kategorije.\"],[\"Nerasporedjeni\",\"Unsorted\",\"Neraspoređeni\"],[\"NeScheduleIsSaved\",\"New schedule is saved\",\"Novi termin je spremljen\"],[\"New\",\"New\",\"Novo\"],[\"NewAdvertSaved\",\"New advert saved\",\"Novi oglas je spremljen\"],[\"NewApplication\",\"New Application\",\"Nova prijava\"],[\"NewBillOperator\",\"New operator\",\"Novi operator\"],[\"NewCart\",\"New cart\",\"Nova košarica\"],[\"NewCertificate\",\"New certificate\",\"Novi certifikat\"],[\"NewInterviewSchedule\",\"New Interview Schedule\",\"Novi termin\"],[\"NewItem\",\"New Item\",\"Novi item\"],[\"NewItemsCount\",\"New Items Count\",\"Broj novih itema\"],[\"NewStatusAdded\",\"New status added\",\"Novi status je dodan\"],[\"NijePronadjenIspravanCertifikat\",\"No valid certificate found\",\"Nije pronađen ispravan certifikat\"],[\"NijePronadjenIspravanNaplatniUredjaj\",\"Did not find the correct charging device\",\"Nije pronađen ispravan naplatni uređaj\"],[\"NijePronadjenValjaniFiskalniCertifikat\",\"Certificate not found.\",\"Nije pronađen valjani fiskalni certifikat.\"],[\"No\",\"No\",\"Ne\"],[\"NoDocuments\",\"No documents\",\"Nema dokumenata\"],[\"NoPictures\",\"No pictures\",\"Nema slika\"],[\"NoResults\",\"No results\",\"Nema rezultata\"],[\"Normativ\",\"Normative\",\"Normativ\"],[\"Normativi\",\"Normatives\",\"Normativi\"],[\"NormativSastojakDrugogArtikla\",\"Normative (component of another article)\",\"Normativ (sastojak drugog artikla)\"],[\"Note\",\"Note\",\"Bilješka\"],[\"NoteHistory\",\"Note history\",\"Povijest bilješki\"],[\"NotHeld\",\"Not held\",\"Nije održan\"],[\"NothingSelected\",\"Nothing selected\",\"Ništa nije odabrano\"],[\"NovaKosarica\",\"New cart\",\"Nova košarica\"],[\"NovaStavka\",\"New item\",\"Nova stavka\"],[\"NovaUsluga\",\"New service\",\"Nova usluga\"],[\"NoviArtikl\",\"New article\",\"Novi artikl\"],[\"NowOrEnterValue\",\"now or enter value\",\"sadašnji ili upišite\"],[\"ObrisatiStavku\",\"Remove item?\",\"Obrisati stavku?\"],[\"Odaberite\",\"Select\",\"Odaberite\"],[\"OdaberiteDatumStornoRacuna\",\"Select the date of the cancellation account!\",\"Odaberite datum storno računa!\"],[\"OdaberiteNacinPlacanja\",\"select payment type\",\"odaberite način plaćanja\"],[\"OdaberitePoslovniProstor\",\"select working place\",\"odaberite poslovni prostor\"],[\"OdabraniDokumentiPdfFileName\",\"selected_documents.pdf\",\"odabrani_dokumenti.pdf\"],[\"OdabranuKategorijuNijeMoguceObrisati\",\"Category can not be deleted!\",\"Odabranu kategoriju nije moguće obrisati!\"],[\"Offers\",\"Offers\",\"Ponude\"],[\"OibOperatoraNijeIspravan\",\"Operator OIB invalid\",\"OIB operatora nije ispravan\"],[\"OibTvrtkeMoraBitiUpisan\",\"Company OIB has to be entered\",\"OIB tvrtke mora biti upisan.\"],[\"OibTvrtkeNijeIspravan\",\"Company OIB invalid\",\"OIB tvrtke nije ispravan\"],[\"OibUCertifikatuJeDrugacijiOdUpisanogOibaTvrtke\",\"The OIB in the certificate is different from the registered company OIB.\",\"OIB u certifikatu je drugačiji od upisanog OIB-a tvrtke.\"],[\"Opcina\",\"Township\",\"Općina\"],[\"Open\",\"Open\",\"Otvori\"],[\"OpenPublicSite\",\"Open public site\",\"Otvori javnu stranicu\"],[\"OpenSelected\",\"Open selected\",\"Otvori odabrano\"],[\"Operator\",\"Operator\",\"Operator\"],[\"Operatori\",\"Operators\",\"Operatori\"],[\"OperatoriMax\",\"Operators max\",\"Operatori max\"],[\"OperatorImePrezime\",\"Operator first last name\",\"Operator ime i prezime\"],[\"OperatorIsActive\",\"Operator is active\",\"Operator aktivan\"],[\"OperatorOIB\",\"Operator OIB\",\"Operator OIB\"],[\"Opis\",\"Description\",\"Opis\"],[\"OpisZaPretragu\",\"Description (for search)\",\"Opis (za pretragu)\"],[\"OrderBySelection\",\"Order by selection\",\"Prema selekciji\"],[\"OrEnterValue\",\"or enter value\",\"ili upišite\"],[\"OslobodjenoPdvaLabel\",\"Exempt VAT note\",\"Oslobođeno PDV-a napomena\"],[\"OslobodjenoPdvaNapomena\",\"Exempt VAT note\",\"Oslobođeno PDV-a prema članku 90., Zakona o PDV-u.\"],[\"OslobodjenoPDVaPoClanku90\",\"VAT exempted under Article 90 of the VAT Act.\",\"Oslobođeno PDV-a prema članku 90., Zakona o PDV-u.\"],[\"OstaliPorezAndPosto\",\"Other taxes (%)\",\"Ostali porez (%)\"],[\"OstaliPorezNazivLabel\",\"Other tax name\",\"Ostali porez naziv\"],[\"OtherApplications\",\"Other applications\",\"Druge prijave s istim imenom\"],[\"OznakaJeVecZauzeta\",\"The tag is already taken\",\"Oznaka je već zauzeta\"],[\"OznakaNaplatnogUredjaja\",\"Tolling device tag\",\"Oznaka naplatnog uređaja\"],[\"OznakaPoslovnogProstora\",\"Business space tag\",\"Oznaka poslovnog prostora\"],[\"Password\",\"Password\",\"Lozinka\"],[\"PasswordHasToBeEnterd\",\"Password has to be entered\",\"Lozinka mora biti upisana\"],[\"PasswordIsRequired\",\"Password is required\",\"Password is required\"],[\"PaymentDate\",\"Payment Date\",\"Datum uplate\"],[\"PaymentMethod\",\"Payment method\",\"Način plaćanja\"],[\"Payments\",\"Payments\",\"Knjiži uplatu\"],[\"PaymentsLinkName\",\"Payments\",\"Knjiženje\"],[\"PaymentsPageTitle\",\"Payments\",\"Knjiženje\"],[\"PaymentsUrlPath\",\"/payments\",\"/knjizenje\"],[\"PaymentType\",\"Payment type\",\"Način plaćanja\"],[\"PdfFileGenerated\",\"Pdf file generated\",\"Pdf file generiran\"],[\"PdfGeneralPayment\",\"Pdf general payment\",\"Pdf opća uplatnica\"],[\"PdfMemoPayment\",\"Pdf memo payment\",\"Pdf memo uplatnica\"],[\"PdfWhite\",\"Pdf white\",\"Pdf bijeli\"],[\"PdvLabelAndPosto\",\"VAT (%)\",\"PDV (%)\"],[\"PdvSustavEnd\",\"VAT system end\",\"Datum izlaska iz sustava PDV-a\"],[\"PdvSustavStart\",\"VAT system start\",\"Datum ulaska u sustav PDV-a\"],[\"PendingAdverts\",\"Pending adverts\",\"Na čekanju\"],[\"PersonalData\",\"Personal aata\",\"Osobni podaci\"],[\"Picture\",\"Picture\",\"Slika\"],[\"Pictures\",\"Pictures\",\"Slike\"],[\"Placeno\",\"Paid\",\"Plaćeno\"],[\"PleaseConfirm\",\"Confirmation required\",\"Molimo potvrdite\"],[\"PleaseEnterTheData\",\"Please enter the data\",\"Molimo unesite podatke\"],[\"PleaseWait\",\"Please wait\",\"Molim pričekajte\"],[\"PocetakPrimjene\",\"Service start\",\"Početak primjene\"],[\"PopustPosto\",\"Discount (%)\",\"Popust (%)\"],[\"PoreznaGrupa\",\"Tax group\",\"Porezna grupa\"],[\"PorezNaPotrosnjuLabelAndPosto\",\"Consumption tax (%)\",\"Porez na potrošnju (%)\"],[\"PorezneGrupe\",\"Tax groups\",\"Porezne grupe\"],[\"PorezneGrupeLinkName\",\"Tax groups\",\"Porezne grupe\"],[\"PorezneGrupeMax\",\"Tax groups max\",\"Porezne grupe max\"],[\"PorezneGrupePageTitle\",\"Tax groups\",\"Porezne grupe\"],[\"PorezneGrupeUrlPath\",\"/tax-groups\",\"/porezne-grupe\"],[\"Pos\",\"POS\",\"Blagajna\"],[\"PosaljiLink\",\"Send link\",\"Pošalji link\"],[\"PosBranchOfficesLinkName\",\"Branch offices\",\"Poslovni prostori\"],[\"PosBranchOfficesPageTitle\",\"Branch offices\",\"Poslovni prostori\"],[\"PosBranchOfficesUrlPath\",\"/pos-branch-offices\",\"/poslovni-prostori\"],[\"PosChargingDevicesLinkName\",\"Charging devices\",\"Naplatni uređaji\"],[\"PosChargingDevicesPageTitle\",\"Charging devices\",\"Naplatni uređaji\"],[\"PosChargingDevicesUrlPath\",\"/pos-charging-devices\",\"/naplatni-uredjaji\"],[\"PosCompanies\",\"POS Companies\",\"Blagajna tvrtke\"],[\"PosCompaniesLinkName\",\"POS Companies\",\"Blagajna tvrtke\"],[\"PosCompaniesPageTitle\",\"POS Companies\",\"Blagajna tvrtke\"],[\"PosCompaniesUrlPath\",\"/pos-companies\",\"/tvrtke\"],[\"PosCompanyLinkName\",\"Company\",\"Tvrtka\"],[\"PosCompanyPageTitle\",\"Company\",\"Tvrtka\"],[\"PosCompanyUrlPath\",\"/company\",\"/tvrtka\"],[\"PoslovniProstor\",\"Branch office\",\"Poslovni prostor\"],[\"PoslovniProstori\",\"Working places\",\"Poslovni prostori\"],[\"PoslovniProstoriMax\",\"Working places max\",\"Poslovni prostori max\"],[\"PosMainLinkName\",\"POS\",\"Prodajno mjesto\"],[\"PosMainPageTitle\",\"POS\",\"Prodajno mjesto\"],[\"PosMainUrlPath\",\"/pos-main\",\"/prodajno-mjesto\"],[\"PosOperators\",\"Operators\",\"Operatori\"],[\"PosOperatorsLinkName\",\"Operators\",\"Operatori\"],[\"PosOperatorsPageTitle\",\"Operators\",\"Operatori\"],[\"PosOperatorsUrlPath\",\"/pos-operators\",\"/operatori\"],[\"PosPisacMargine\",\"POS printer margins (mm)\",\"POS pisač margine (mm)\"],[\"PosSettings\",\"POS settings\",\"Postavke blagajne\"],[\"PostalNumber\",\"Postal number\",\"Poštanski broj\"],[\"PostanskiBroj\",\"Zip code\",\"Poštanski broj\"],[\"PostLetter\",\"Post letter\",\"Dopis poštom\"],[\"PozivNaBroj\",\"Document Number\",\"Poziv na broj\"],[\"PredefinedInterviewSchedule\",\"Predefined Interview Schedule\",\"Preddefinirani termin\"],[\"Pretraga\",\"Search\",\"Pretraga\"],[\"PriceKind\",\"Price kind\",\"Vrsta cijene\"],[\"PrintingHistory\",\"Printing History\",\"Povijest ispisa\"],[\"PrintingHistoryLinkName\",\"Print history\",\"Povijest ispisa\"],[\"PrintingHistoryPageTitle\",\"Print history\",\"Povijest ispisa\"],[\"PrintingHistoryUrlPath\",\"/print-history\",\"/povijest-ispisa\"],[\"PrintingLinkName\",\"Printing\",\"Ispis\"],[\"PrintingPageTitle\",\"Printing\",\"Ispis\"],[\"PrintingUrlPath\",\"/printing\",\"/ispis\"],[\"ProductCategory\",\"Product category\",\"Kategorija\"],[\"ProductID\",\"ProductID\",\"ProductID\"],[\"ProductsInCategory\",\"Products in category\",\"Produkti u kategoriji\"],[\"ProductsLinkName\",\"Products\",\"Produkti\"],[\"ProductsMax\",\"Products max\",\"Produkti max\"],[\"ProductsPageTitle\",\"Products\",\"Produkti\"],[\"ProductsSpent\",\"Products spent\",\"Produkti\"],[\"ProductsUrlPath\",\"/products\",\"/produkti\"],[\"ProductsWithoutCategory\",\"Products without category\",\"Produkti bez kategorije\"],[\"Produkti\",\"Products\",\"Produkti\"],[\"Profile\",\"Profile\",\"Profil\"],[\"ProfilePicture\",\"Profile Picture\",\"Profilna slika\"],[\"ProknjizitiSaSadasnjimDatumomIVremenomSigurno\",\"Record with the current date and time, sure?\",\"Proknjižiti sa sadašnjim datumom i vremenom, sigurno?\"],[\"Quantity\",\"Quantity\",\"Količina\"],[\"Question\",\"Question\",\"Pitanje\"],[\"RacunIzradjenNaRacunaluLabel\",\"Bill made on computer note\",\"Račun izrađen na računalu napomena\"],[\"RacunIzradjenNaRacunaluNapomena\",\"-\",\"Račun je izrađen na računalu i pravovaljan je bez žiga i potpisa.\"],[\"RadnoVrijeme\",\"Working hours\",\"Radno vrijeme\"],[\"ReleaseSelected\",\"Release selected\",\"Oslobodi odabrano\"],[\"RememberMe\",\"Remember me\",\"Zapamti me\"],[\"RequiredData\",\"required\",\"obavezno\"],[\"Reserved\",\"Reserved\",\"Rezervirano\"],[\"ResourcesSpent\",\"Spent\",\"Iskorištenost\"],[\"SadasnjiDatum\",\"current date\",\"sadašnji datum\"],[\"Save\",\"Save\",\"Spremi\"],[\"SaveAccessRights\",\"Save Access Rights\",\"Spremi Prava Pristupa\"],[\"Saving\",\"Saving\",\"Spremam\"],[\"ScheduleAdded\",\"Schedule Added\",\"Sastanak dodan\"],[\"ScheduleDateCanNotBeSetInPast\",\"Schedule date can not be set in past time\",\"Datum termina ne može biti u prošlosti\"],[\"ScheduleDateHasToBeSelected\",\"Schedule date has to be selected\",\"Datum termina mora biti odabran\"],[\"ScheduleDateOrTimeIsNotValid\",\"Schedule date or time is not valid\",\"Datum ili vrijeme termina nije ispravno\"],[\"ScheduleHasToBeSelected\",\"Schedule has to be selected\",\"Termin mora biti odabran\"],[\"ScheduleIsAlreadyAppliedToCurrentPerson\",\"Schedule is already applied to current person\",\"Termin je već dodijeljen ovom osobi\"],[\"ScheduleIsCanceled\",\"Schedule is canceled\",\"Termin je otkazan\"],[\"ScheduleIsTakenInTheMeanTime\",\"Schedule is taken in the mean time by someone else\",\"Termin je zauzet u međuvremenu\"],[\"ScheduleIsUpdated\",\"Schedule is updated\",\"Termin je ažuriran\"],[\"SchedulesHistory\",\"Schedules History\",\"Povijest termina\"],[\"ScheduleTimeHasToBeSelected\",\"Schedule time has to be selected\",\"Vrijeme termina mora biti odabrano\"],[\"ScheduleType\",\"Schedule Type\",\"Tip sastanka\"],[\"ScheduleTypeHasToBeSelected\",\"Schedule type has to be selected\",\"Tip termina mora biti odabran\"],[\"ScheduleTypeName\",\"Schedule Type Name\",\"Naziv termina\"],[\"ScheduleUpdated\",\"Schedule Updated\",\"Sastanak ažuriran\"],[\"Search\",\"Search\",\"Traži\"],[\"Searching\",\"Searching\",\"Tražim\"],[\"Select\",\"Select\",\"Odaberi\"],[\"SelectAllLoaded\",\"Select All Loaded\",\"Odaberi sve učitane\"],[\"SelectCertificate\",\"Select certificate\",\"Odaberi certifikat\"],[\"SelectedGeneratePdf\",\"Selected generate pdf\",\"Odabrani generiraj pdf\"],[\"SelectedScheduleIsSaved\",\"Selected schedule is saved\",\"Odabrani termin je spremljen\"],[\"Send\",\"Send\",\"Pošalji\"],[\"Series\",\"Serial\",\"Serija\"],[\"Service\",\"Service\",\"Usluga\"],[\"ShoppingCartClosingError\",\"Error! Invalid data.. \\r\\nPossible actions:\\r\\n- refresht the page\\r\\n- delete cart\\r\\n- logout than login\\r\\n- delete cookies\\r\\n- change internet browser\\r\\n- restart computer\",\"Greška! Neispravni podaci. \\r\\nDa biste popravili problem, moguće su sljedeće akcije:\\r\\n- osvježite stranicu\\r\\n- obrišite košaricu\\r\\n- odjavite se i ponovo se prijavite\\r\\n- obrišite cookie\\r\\n- promijenite internetski preglednik\\r\\n- promijenite računalo\"],[\"ShortCompanyName\",\"Short compnay name\",\"Kratki naziv tvrtke\"],[\"ShowRange\",\"Show Range\",\"Prikaži interval\"],[\"SignInToYourAccount\",\"Login To Your Account\",\"Molimo prijavite se\"],[\"SortKind\",\"Sort Kind\",\"Način poretka\"],[\"SpremanjeNijeUspjeloOsvjeziteStranicu\",\"Saving failed! Refresh the page.\",\"Spremanje nije uspjelo. Osvježite stranicu.\"],[\"StartDate\",\"Start Date\",\"Datum početka\"],[\"StartDateIsOutOfRange\",\"Start date is out of range\",\"Datum početka je izvan valjanog intervala\"],[\"StartDateYearHasToBeGreaterThan\",\"Start Date year has to be greater than 1900\",\"Datum početka mora biti veći od 1900\"],[\"StartTime\",\"Start Time\",\"Vrijeme početka\"],[\"StatistikaArtikala\",\"Articles statistics\",\"Statistika artikala\"],[\"Status\",\"Status\",\"Status\"],[\"StatusAlreadyExists\",\"Status already exists\",\"Status već postoji\"],[\"StatusHasToBeSelected\",\"Status has to be selected\",\"Status mora biti odabran\"],[\"StatusName\",\"Status Name\",\"Status naziv\"],[\"StatusNameChanged\",\"Status name changed\",\"Naziv statusa je promijenjen\"],[\"StatusSaved\",\"Status saved\",\"Status je spremljen\"],[\"StatusUsluga\",\"Status usluga\",\"Status usluga\"],[\"Storno\",\"Storno\",\"Storno\"],[\"StornoCompleted\",\"Storno completed\",\"Storno računa uspješno kreiran\"],[\"SuccessRedirecting\",\"Success, redirecting...\",\"Uspješno, preusmjeravam...\"],[\"SuccessReloading\",\"Success, reloading...\",\"Izvršeno, osvježavam...\"],[\"SveKategorije\",\"All categories\",\"Sve kategorije\"],[\"SviArtikli\",\"All articles\",\"Svi artikli\"],[\"SviNormativi\",\"All normatives\",\"Svi normativi\"],[\"SynesisLinkName\",\"Synesis\",\"Synesis\"],[\"SynesisPageTitle\",\"Synesis\",\"Synesis\"],[\"SynesisUrlPath\",\"/synesis\",\"/synesis\"],[\"Tax\",\"Tax\",\"Porez\"],[\"TelephoneNumber\",\"Telephone number\",\"Telefonski broj\"],[\"TemplateContent\",\"Template content\",\"Sadržaj predloška\"],[\"TemplateKind\",\"Template kind\",\"Vrsta predloška\"],[\"TemplateSubject\",\"Template subject\",\"Naslov predloška\"],[\"TextLog\",\"Text log\",\"Text log\"],[\"TextUFooteruRacunaLabel\",\"Text in a footer\",\"Text u footeru računa\"],[\"ThisTypeCanNotBeDeleted\",\"This type can\\u0027t be deleted. It is already used.\",\"Ovaj tip nije moguće obrisati - već je u upotrebi\"],[\"Time\",\"Time\",\"Vrijeme\"],[\"Tocka\",\"dot\",\"tocka\"],[\"Tools\",\"Tools\",\"Alati\"],[\"ToolsLinkName\",\"Tools\",\"Alati\"],[\"ToolsPageTitle\",\"Tools\",\"Alati\"],[\"ToolsUrlPath\",\"/tools\",\"/alati\"],[\"Total\",\"Total\",\"Ukupno\"],[\"TotalAdverts\",\"Total Adverts\",\"Ukupno oglasa\"],[\"TotalAmount\",\"Total amount\",\"Sveukupno\"],[\"Transactions\",\"Transactions\",\"Transakcije\"],[\"TransactionsLinkName\",\"Transactions\",\"Transakcije\"],[\"TransactionsPageTitle\",\"Transactions\",\"Transakcije\"],[\"TransactionsUrlPath\",\"/transactions\",\"/transakcije\"],[\"Type\",\"Type\",\"Tip\"],[\"UKosaricu\",\"To shopping cart\",\"U košaricu\"],[\"Ulica\",\"Ulica\",\"Ulica\"],[\"Unit\",\"Unit\",\"Mjera\"],[\"UpdateViewStatus\",\"Update view status\",\"Ažuriraj prikaz status\"],[\"UrediPoreznuGrupu\",\"Uredi poreznu grupu\",\"Uredi poreznu grupu\"],[\"UrediStavku\",\"Edit item\",\"Uredi stavku\"],[\"UredjivanjeOdabraneKategorijeNijeMoguce\",\"Category can not be edited!\",\"Uređivanje odabrane kategorije nije moguće!\"],[\"UredjivanjeUsluge\",\"Edit service\",\"Uređivanje usluge\"],[\"UsePredefinedSchedules\",\"Use predefined schedules\",\"Koristiti preddefinirane termine\"],[\"Username\",\"Username\",\"Korisničko ime\"],[\"UsernameIsRequired\",\"Username is required\",\"Molimo unesite korisničko ime\"],[\"UspjesnoZavrseno\",\"Completed successfuly\",\"Uspješno završeno\"],[\"UtrzakBlagajne\",\"POS income\",\"Utržak blagajne\"],[\"VariantID\",\"VariantID\",\"VariantID\"],[\"VeleprodajnaVPC\",\"Wholesale (VPC)\",\"Veleprodajna (VPC)\"],[\"VerifyIntegrity\",\"Verify integrity\",\"Verify integrity\"],[\"VisibleAtPOS\",\"Visible at POS\",\"Vidljivo u blagajni\"],[\"VPC\",\"VPC\",\"VPC\"],[\"WebSite\",\"Web Site\",\"Web stranica\"],[\"WorkingPleaseWait\",\"Working, please wait\",\"Izvršavam, molim pričekajte\"],[\"WorkingTime\",\"Working time\",\"Radno vrijeme\"],[\"Yes\",\"Yes\",\"Da\"],[\"YouHaveNoAccessRight\",\"You have no access rights\",\"Nemate dozvolu za odabranu akciju.\"],[\"Zakljuceno\",\"Completed\",\"Zaključeno\"],[\"Zakljuci\",\"Complete\",\"Zaključi\"],[\"Zakupljeno\",\"Ordered\",\"Zakupljeno\"],[\"Zarez\",\"comma\",\"zarez\"],[\"ZeliteLiZaistaKreiratiStornoSaSadasnjimDatumomIVremenom\",\"Do you really want to create cancellation bill with the current date and time?\",\"Želite li zaista kreirati storno sa sadašnjim datumom i vremenom?\"],[\"ZeliteLiZasitaKreiratiStornoRacun\",\"Do you really want to create a cancellation bill?\",\"Želite li zaista kreirati storno račun?\"],[\"ZeliteLiZasitaKreiratiStornoSaDatumomZadnjegRacuna\",\"Do you really want to create a cancellation with the date of the last bill?\",\"Želite li zaista kreirati storno sa datumom zadnjeg računa?\"],[\"NothingToPrint\",\"Nothing to print\",\"Nema ništa za ispis\"],[\"HomeLinkName\",\"Home\",\"Naslovnica\"],[\"HomeUrlPath\",\"/\",\"/\"],[\"HomePageTitle\",\"Admin\",\"Admin\"],[\"ShowDocumentUrlPath\",\"/showdoc\",\"/dokument\"],[\"ShowDocumentLinkName\",\"Document\",\"Dokument\"],[\"ShowDocumentPageTitle\",\"Dokument\",\"Dokument\"]]}";

        public static readonly ResxExcelProvider ResourceProvider = ResxExcelProvider.FromJson<ResxExcelProvider>(_json);


        /// <summary>
        /// Access Control 
        /// </summary>
		public static string AccessControl => ResourceProvider.GetString("AccessControl");

        /// <summary>
        /// Account setting 
        /// </summary>
		public static string AccountSettingLinkName => ResourceProvider.GetString("AccountSettingLinkName");

        /// <summary>
        /// Account setting 
        /// </summary>
		public static string AccountSettingPageTitle => ResourceProvider.GetString("AccountSettingPageTitle");

        /// <summary>
        /// /account-setting 
        /// </summary>
		public static string AccountSettingUrlPath => ResourceProvider.GetString("AccountSettingUrlPath");

        /// <summary>
        /// Action 
        /// </summary>
		public static string Action => ResourceProvider.GetString("Action");

        /// <summary>
        /// Action failed 
        /// </summary>
		public static string ActionFailed => ResourceProvider.GetString("ActionFailed");

        /// <summary>
        /// Action successful 
        /// </summary>
		public static string ActionSuccessful => ResourceProvider.GetString("ActionSuccessful");

        /// <summary>
        /// Active 
        /// </summary>
		public static string Active => ResourceProvider.GetString("Active");

        /// <summary>
        /// Active Adverts 
        /// </summary>
		public static string ActiveAdverts => ResourceProvider.GetString("ActiveAdverts");

        /// <summary>
        /// Add 
        /// </summary>
		public static string Add => ResourceProvider.GetString("Add");

        /// <summary>
        /// Add operator 
        /// </summary>
		public static string AddBillOperator => ResourceProvider.GetString("AddBillOperator");

        /// <summary>
        /// Add business space 
        /// </summary>
		public static string AddBusinessSpace => ResourceProvider.GetString("AddBusinessSpace");

        /// <summary>
        /// Add category 
        /// </summary>
		public static string AddCategory => ResourceProvider.GetString("AddCategory");

        /// <summary>
        /// Add certificate 
        /// </summary>
		public static string AddCertificate => ResourceProvider.GetString("AddCertificate");

        /// <summary>
        /// Add charging device 
        /// </summary>
		public static string AddChargingDevice => ResourceProvider.GetString("AddChargingDevice");

        /// <summary>
        /// Add item 
        /// </summary>
		public static string AddItem => ResourceProvider.GetString("AddItem");

        /// <summary>
        /// Add New Advert 
        /// </summary>
		public static string AddNewAdvert => ResourceProvider.GetString("AddNewAdvert");

        /// <summary>
        /// Add new category 
        /// </summary>
		public static string AddNewCategory => ResourceProvider.GetString("AddNewCategory");

        /// <summary>
        /// Add new certificate 
        /// </summary>
		public static string AddNewCertificate => ResourceProvider.GetString("AddNewCertificate");

        /// <summary>
        /// Add New Member 
        /// </summary>
		public static string AddNewMember => ResourceProvider.GetString("AddNewMember");

        /// <summary>
        /// Add New Schedule 
        /// </summary>
		public static string AddNewSchedule => ResourceProvider.GetString("AddNewSchedule");

        /// <summary>
        /// Add New Schedule Type 
        /// </summary>
		public static string AddNewScheduleType => ResourceProvider.GetString("AddNewScheduleType");

        /// <summary>
        /// Add New Status 
        /// </summary>
		public static string AddNewStatus => ResourceProvider.GetString("AddNewStatus");

        /// <summary>
        /// Add subcategory 
        /// </summary>
		public static string AddNewSubCategory => ResourceProvider.GetString("AddNewSubCategory");

        /// <summary>
        /// Add new template 
        /// </summary>
		public static string AddNewTemplate => ResourceProvider.GetString("AddNewTemplate");

        /// <summary>
        /// Add normativ 
        /// </summary>
		public static string AddNormativ => ResourceProvider.GetString("AddNormativ");

        /// <summary>
        /// Please add or select branch office 
        /// </summary>
		public static string AddOrSelectBranchOffice => ResourceProvider.GetString("AddOrSelectBranchOffice");

        /// <summary>
        /// Add or select payment type 
        /// </summary>
		public static string AddOrSelectPaymentType => ResourceProvider.GetString("AddOrSelectPaymentType");

        /// <summary>
        /// Add tax group 
        /// </summary>
		public static string AddPoreznaGrupa => ResourceProvider.GetString("AddPoreznaGrupa");

        /// <summary>
        /// Tax group has to be added first 
        /// </summary>
		public static string AddPoreznaGrupaFirst => ResourceProvider.GetString("AddPoreznaGrupaFirst");

        /// <summary>
        /// Add product 
        /// </summary>
		public static string AddProduct => ResourceProvider.GetString("AddProduct");

        /// <summary>
        /// Address 
        /// </summary>
		public static string Address => ResourceProvider.GetString("Address");

        /// <summary>
        /// Administrative 
        /// </summary>
		public static string Administrative => ResourceProvider.GetString("Administrative");

        /// <summary>
        /// Admin 
        /// </summary>
		public static string AdminLinkName => ResourceProvider.GetString("AdminLinkName");

        /// <summary>
        /// WebSite Admin 
        /// </summary>
		public static string AdminLoginTitle => ResourceProvider.GetString("AdminLoginTitle");

        /// <summary>
        /// Admin 
        /// </summary>
		public static string AdminPageTitle => ResourceProvider.GetString("AdminPageTitle");

        /// <summary>
        /// Admin tools 
        /// </summary>
		public static string AdminToolsLinkName => ResourceProvider.GetString("AdminToolsLinkName");

        /// <summary>
        /// Admin tools 
        /// </summary>
		public static string AdminToolsPageTitle => ResourceProvider.GetString("AdminToolsPageTitle");

        /// <summary>
        /// /admin-tools 
        /// </summary>
		public static string AdminToolsUrlPath => ResourceProvider.GetString("AdminToolsUrlPath");

        /// <summary>
        /// Advert 
        /// </summary>
		public static string Advert => ResourceProvider.GetString("Advert");

        /// <summary>
        /// Advert data updated 
        /// </summary>
		public static string AdvertDataUpdated => ResourceProvider.GetString("AdvertDataUpdated");

        /// <summary>
        /// Advert ID 
        /// </summary>
		public static string AdvertID => ResourceProvider.GetString("AdvertID");

        /// <summary>
        /// Active 
        /// </summary>
		public static string Aktivno => ResourceProvider.GetString("Aktivno");

        /// <summary>
        /// All 
        /// </summary>
		public static string All => ResourceProvider.GetString("All");

        /// <summary>
        /// All Adverts 
        /// </summary>
		public static string AllAdverts => ResourceProvider.GetString("AllAdverts");

        /// <summary>
        /// All Statuses 
        /// </summary>
		public static string AllStatuses => ResourceProvider.GetString("AllStatuses");

        /// <summary>
        /// Amount+Tax 
        /// </summary>
		public static string AmountWithTax => ResourceProvider.GetString("AmountWithTax");

        /// <summary>
        /// Applicant Details 
        /// </summary>
		public static string ApplicantDetails => ResourceProvider.GetString("ApplicantDetails");

        /// <summary>
        /// Applicants 
        /// </summary>
		public static string Applicants => ResourceProvider.GetString("Applicants");

        /// <summary>
        /// Applicants Count 
        /// </summary>
		public static string ApplicantsCount => ResourceProvider.GetString("ApplicantsCount");

        /// <summary>
        /// Applicant Status 
        /// </summary>
		public static string ApplicantStatus => ResourceProvider.GetString("ApplicantStatus");

        /// <summary>
        /// Apply Filter 
        /// </summary>
		public static string ApplyFilter => ResourceProvider.GetString("ApplyFilter");

        /// <summary>
        /// Account managers 
        /// </summary>
		public static string ArizonaReferentiLinkName => ResourceProvider.GetString("ArizonaReferentiLinkName");

        /// <summary>
        /// Account managers 
        /// </summary>
		public static string ArizonaReferentiPageTitle => ResourceProvider.GetString("ArizonaReferentiPageTitle");

        /// <summary>
        /// /account-manager 
        /// </summary>
		public static string ArizonaReferentiUrlPath => ResourceProvider.GetString("ArizonaReferentiUrlPath");

        /// <summary>
        /// Article (for sale, visible in POS) 
        /// </summary>
		public static string ArticleVisibleInPOS => ResourceProvider.GetString("ArticleVisibleInPOS");

        /// <summary>
        /// Article 
        /// </summary>
		public static string Artikl => ResourceProvider.GetString("Artikl");

        /// <summary>
        /// Available 
        /// </summary>
		public static string Available => ResourceProvider.GetString("Available");

        /// <summary>
        /// Bank account IBAN 
        /// </summary>
		public static string BankAccountIBAN => ResourceProvider.GetString("BankAccountIBAN");

        /// <summary>
        /// Barcode 
        /// </summary>
		public static string Barcode => ResourceProvider.GetString("Barcode");

        /// <summary>
        /// Without category 
        /// </summary>
		public static string BezKategorije => ResourceProvider.GetString("BezKategorije");

        /// <summary>
        /// BillClientID 
        /// </summary>
		public static string BillClientID => ResourceProvider.GetString("BillClientID");

        /// <summary>
        /// Bill date 
        /// </summary>
		public static string BillDate => ResourceProvider.GetString("BillDate");

        /// <summary>
        /// Bill operator data 
        /// </summary>
		public static string BillOperatorData => ResourceProvider.GetString("BillOperatorData");

        /// <summary>
        /// Operator mark 
        /// </summary>
		public static string BillOperatorMark => ResourceProvider.GetString("BillOperatorMark");

        /// <summary>
        /// Operator unique number 
        /// </summary>
		public static string BillOperatorUniqueNumber => ResourceProvider.GetString("BillOperatorUniqueNumber");

        /// <summary>
        /// Bills 
        /// </summary>
		public static string Bills => ResourceProvider.GetString("Bills");

        /// <summary>
        /// Bills and non-paid offers 
        /// </summary>
		public static string BillsAndNonPaidOffers => ResourceProvider.GetString("BillsAndNonPaidOffers");

        /// <summary>
        /// Bills Export 
        /// </summary>
		public static string BillsExport => ResourceProvider.GetString("BillsExport");

        /// <summary>
        /// Bills 
        /// </summary>
		public static string BillsLinkName => ResourceProvider.GetString("BillsLinkName");

        /// <summary>
        /// Bills 
        /// </summary>
		public static string BillsPageTitle => ResourceProvider.GetString("BillsPageTitle");

        /// <summary>
        /// /bills 
        /// </summary>
		public static string BillsUrlPath => ResourceProvider.GetString("BillsUrlPath");

        /// <summary>
        /// Birth Date 
        /// </summary>
		public static string BirthDate => ResourceProvider.GetString("BirthDate");

        /// <summary>
        /// Bookkeeping 
        /// </summary>
		public static string Bookkeeping => ResourceProvider.GetString("Bookkeeping");

        /// <summary>
        /// Product can not be deleted 
        /// </summary>
		public static string BrisanjeArtiklaNijeMoguce => ResourceProvider.GetString("BrisanjeArtiklaNijeMoguce");

        /// <summary>
        /// Active services count 
        /// </summary>
		public static string BrojAktivnihUsluga => ResourceProvider.GetString("BrojAktivnihUsluga");

        /// <summary>
        /// A4 
        /// </summary>
		public static string ButtonA4 => ResourceProvider.GetString("ButtonA4");

        /// <summary>
        /// PDF 
        /// </summary>
		public static string ButtonPDF => ResourceProvider.GetString("ButtonPDF");

        /// <summary>
        /// POS 
        /// </summary>
		public static string ButtonPOS => ResourceProvider.GetString("ButtonPOS");

        /// <summary>
        /// Send 
        /// </summary>
		public static string ButtonSend => ResourceProvider.GetString("ButtonSend");

        /// <summary>
        /// Calendar is emtpy for selected date 
        /// </summary>
		public static string CalendarIsEmptyForSelectedDate => ResourceProvider.GetString("CalendarIsEmptyForSelectedDate");

        /// <summary>
        /// Call Center 
        /// </summary>
		public static string CallCenter => ResourceProvider.GetString("CallCenter");

        /// <summary>
        /// Calls 
        /// </summary>
		public static string CallsLinkName => ResourceProvider.GetString("CallsLinkName");

        /// <summary>
        /// Calls 
        /// </summary>
		public static string CallsPageTitle => ResourceProvider.GetString("CallsPageTitle");

        /// <summary>
        /// /calls 
        /// </summary>
		public static string CallsUrlPath => ResourceProvider.GetString("CallsUrlPath");

        /// <summary>
        /// Cancel 
        /// </summary>
		public static string Cancel => ResourceProvider.GetString("Cancel");

        /// <summary>
        /// Canceled 
        /// </summary>
		public static string Canceled => ResourceProvider.GetString("Canceled");

        /// <summary>
        /// Cancel selected 
        /// </summary>
		public static string CancelSelected => ResourceProvider.GetString("CancelSelected");

        /// <summary>
        /// Adding is not possible - the limit is reached 
        /// </summary>
		public static string CanNotAddMoreItemsLimitReached => ResourceProvider.GetString("CanNotAddMoreItemsLimitReached");

        /// <summary>
        /// Cart is empty 
        /// </summary>
		public static string CartIsEmpty => ResourceProvider.GetString("CartIsEmpty");

        /// <summary>
        /// Categories 
        /// </summary>
		public static string Categories => ResourceProvider.GetString("Categories");

        /// <summary>
        /// Categories max 
        /// </summary>
		public static string CategoriesMax => ResourceProvider.GetString("CategoriesMax");

        /// <summary>
        /// Categories 
        /// </summary>
		public static string CategoriesSpent => ResourceProvider.GetString("CategoriesSpent");

        /// <summary>
        /// Category 
        /// </summary>
		public static string Category => ResourceProvider.GetString("Category");

        /// <summary>
        /// Category list 
        /// </summary>
		public static string CategoryList => ResourceProvider.GetString("CategoryList");

        /// <summary>
        /// Start pending 
        /// </summary>
		public static string CekaStart => ResourceProvider.GetString("CekaStart");

        /// <summary>
        /// Certificate deleted, refreshing 
        /// </summary>
		public static string CertificateDeletedRefreshing => ResourceProvider.GetString("CertificateDeletedRefreshing");

        /// <summary>
        /// Certifikat ispravan 
        /// </summary>
		public static string CertifikatIspravan => ResourceProvider.GetString("CertifikatIspravan");

        /// <summary>
        /// Publisher 
        /// </summary>
		public static string CertifikatIzdavac => ResourceProvider.GetString("CertifikatIzdavac");

        /// <summary>
        /// The certificate has been successfully saved, refreshing 
        /// </summary>
		public static string CertifikatJeUspjesnoSpremljenOsvjezavam => ResourceProvider.GetString("CertifikatJeUspjesnoSpremljenOsvjezavam");

        /// <summary>
        /// Certificate already entered, re-entry is not possible. 
        /// </summary>
		public static string CertifikatJeVecUnesenPonovniUnosNijeMoguc => ResourceProvider.GetString("CertifikatJeVecUnesenPonovniUnosNijeMoguc");

        /// <summary>
        /// The certificate is incorrect. 
        /// </summary>
		public static string CertifikatNijeIspravan => ResourceProvider.GetString("CertifikatNijeIspravan");

        /// <summary>
        /// The certificate is incorrect, the private key is missing. 
        /// </summary>
		public static string CertifikatNijeIspravanNedostajePrivatniKljuc => ResourceProvider.GetString("CertifikatNijeIspravanNedostajePrivatniKljuc");

        /// <summary>
        /// Subject 
        /// </summary>
		public static string CertifikatSubjekt => ResourceProvider.GetString("CertifikatSubjekt");

        /// <summary>
        /// Type 
        /// </summary>
		public static string CertifikatTip => ResourceProvider.GetString("CertifikatTip");

        /// <summary>
        /// Checking... 
        /// </summary>
		public static string Checking => ResourceProvider.GetString("Checking");

        /// <summary>
        /// City 
        /// </summary>
		public static string City => ResourceProvider.GetString("City");

        /// <summary>
        /// Client Name 
        /// </summary>
		public static string ClientName => ResourceProvider.GetString("ClientName");

        /// <summary>
        /// Close 
        /// </summary>
		public static string Close => ResourceProvider.GetString("Close");

        /// <summary>
        /// Company Name 
        /// </summary>
		public static string CompanyName => ResourceProvider.GetString("CompanyName");

        /// <summary>
        /// Company unique number 
        /// </summary>
		public static string CompanyUniqueNumber => ResourceProvider.GetString("CompanyUniqueNumber");

        /// <summary>
        /// Contact data 
        /// </summary>
		public static string ContactData => ResourceProvider.GetString("ContactData");

        /// <summary>
        /// Conversion all 
        /// </summary>
		public static string ConversionAll => ResourceProvider.GetString("ConversionAll");

        /// <summary>
        /// Conversion check 
        /// </summary>
		public static string ConversionCheck => ResourceProvider.GetString("ConversionCheck");

        /// <summary>
        /// Conversion due expired 
        /// </summary>
		public static string ConversionDueExpired => ResourceProvider.GetString("ConversionDueExpired");

        /// <summary>
        /// Finance Group 
        /// </summary>
		public static string CopyrightText => ResourceProvider.GetString("CopyrightText");

        /// <summary>
        /// CRM 
        /// </summary>
		public static string CRM => ResourceProvider.GetString("CRM");

        /// <summary>
        /// Yellow pages 
        /// </summary>
		public static string CrmOglasnikLinkName => ResourceProvider.GetString("CrmOglasnikLinkName");

        /// <summary>
        /// Yellow pages 
        /// </summary>
		public static string CrmOglasnikPageTitle => ResourceProvider.GetString("CrmOglasnikPageTitle");

        /// <summary>
        /// /crm-yellow-pages 
        /// </summary>
		public static string CrmOglasnikUrlPath => ResourceProvider.GetString("CrmOglasnikUrlPath");

        /// <summary>
        /// Work time 
        /// </summary>
		public static string CrmRadnoVrijemeLinkName => ResourceProvider.GetString("CrmRadnoVrijemeLinkName");

        /// <summary>
        /// Work time 
        /// </summary>
		public static string CrmRadnoVrijemePageTitle => ResourceProvider.GetString("CrmRadnoVrijemePageTitle");

        /// <summary>
        /// /crm-work-time 
        /// </summary>
		public static string CrmRadnoVrijemeUrlPath => ResourceProvider.GetString("CrmRadnoVrijemeUrlPath");

        /// <summary>
        /// Currency 
        /// </summary>
		public static string Currency => ResourceProvider.GetString("Currency");

        /// <summary>
        /// Customer 
        /// </summary>
		public static string Customer => ResourceProvider.GetString("Customer");

        /// <summary>
        /// Customer editor 
        /// </summary>
		public static string CustomerEditor => ResourceProvider.GetString("CustomerEditor");

        /// <summary>
        /// Customer search 
        /// </summary>
		public static string CustomerSearch => ResourceProvider.GetString("CustomerSearch");

        /// <summary>
        /// Unique nuber or name 
        /// </summary>
		public static string CustomerUniqueNumberOrName => ResourceProvider.GetString("CustomerUniqueNumberOrName");

        /// <summary>
        /// Data copied to clipboard 
        /// </summary>
		public static string DataCopiedToClipboard => ResourceProvider.GetString("DataCopiedToClipboard");

        /// <summary>
        /// Data saved 
        /// </summary>
		public static string DataSaved => ResourceProvider.GetString("DataSaved");

        /// <summary>
        /// Data saved, reloading 
        /// </summary>
		public static string DataSavedReloading => ResourceProvider.GetString("DataSavedReloading");

        /// <summary>
        /// Date 
        /// </summary>
		public static string Date => ResourceProvider.GetString("Date");

        /// <summary>
        /// Date has to be selected 
        /// </summary>
		public static string DateHasToBeSelected => ResourceProvider.GetString("DateHasToBeSelected");

        /// <summary>
        /// Date 
        /// </summary>
		public static string Datum => ResourceProvider.GetString("Datum");

        /// <summary>
        /// Due date 
        /// </summary>
		public static string DatumDospijeca => ResourceProvider.GetString("DatumDospijeca");

        /// <summary>
        /// Document dates 
        /// </summary>
		public static string DatumiDokumenta => ResourceProvider.GetString("DatumiDokumenta");

        /// <summary>
        /// Offer date 
        /// </summary>
		public static string DatumPonude => ResourceProvider.GetString("DatumPonude");

        /// <summary>
        /// Bill date 
        /// </summary>
		public static string DatumRacuna => ResourceProvider.GetString("DatumRacuna");

        /// <summary>
        /// Cancellation bill date 
        /// </summary>
		public static string DatumStornoRacuna => ResourceProvider.GetString("DatumStornoRacuna");

        /// <summary>
        /// Currency date 
        /// </summary>
		public static string DatumValute => ResourceProvider.GetString("DatumValute");

        /// <summary>
        /// Last bill date 
        /// </summary>
		public static string DatumZadnjegRacuna => ResourceProvider.GetString("DatumZadnjegRacuna");

        /// <summary>
        /// decimal separator 
        /// </summary>
		public static string DecimalniSeparator => ResourceProvider.GetString("DecimalniSeparator");

        /// <summary>
        /// Delete 
        /// </summary>
		public static string Delete => ResourceProvider.GetString("Delete");

        /// <summary>
        /// Delete, are you sure? 
        /// </summary>
		public static string DeleteAreYouSure => ResourceProvider.GetString("DeleteAreYouSure");

        /// <summary>
        /// Delete cart 
        /// </summary>
		public static string DeleteCart => ResourceProvider.GetString("DeleteCart");

        /// <summary>
        /// Delete category 
        /// </summary>
		public static string DeleteCategory => ResourceProvider.GetString("DeleteCategory");

        /// <summary>
        /// Delete certificate 
        /// </summary>
		public static string DeleteCertificate => ResourceProvider.GetString("DeleteCertificate");

        /// <summary>
        /// Delete document, are you sure? 
        /// </summary>
		public static string DeleteDocumentConfirmation => ResourceProvider.GetString("DeleteDocumentConfirmation");

        /// <summary>
        /// Delete image, are you sure? 
        /// </summary>
		public static string DeleteImageConfirmation => ResourceProvider.GetString("DeleteImageConfirmation");

        /// <summary>
        /// Delete product 
        /// </summary>
		public static string DeleteProduct => ResourceProvider.GetString("DeleteProduct");

        /// <summary>
        /// Delete Selected 
        /// </summary>
		public static string DeleteSelected => ResourceProvider.GetString("DeleteSelected");

        /// <summary>
        /// Delete selected schedule. Are you sure? 
        /// </summary>
		public static string DeleteSelectedScheduleAreYouSure => ResourceProvider.GetString("DeleteSelectedScheduleAreYouSure");

        /// <summary>
        /// Delete the latest one, are you sure? 
        /// </summary>
		public static string DeleteTheLatestAreYouSure => ResourceProvider.GetString("DeleteTheLatestAreYouSure");

        /// <summary>
        /// Description 
        /// </summary>
		public static string Description => ResourceProvider.GetString("Description");

        /// <summary>
        /// Details 
        /// </summary>
		public static string Details => ResourceProvider.GetString("Details");

        /// <summary>
        /// Daily calculation 
        /// </summary>
		public static string DnevniObracunLinkName => ResourceProvider.GetString("DnevniObracunLinkName");

        /// <summary>
        /// Daily calculation 
        /// </summary>
		public static string DnevniObracunPageTitle => ResourceProvider.GetString("DnevniObracunPageTitle");

        /// <summary>
        /// /dnevni-obracun 
        /// </summary>
		public static string DnevniObracunUrlPath => ResourceProvider.GetString("DnevniObracunUrlPath");

        /// <summary>
        /// Document date 
        /// </summary>
		public static string DocumentDate => ResourceProvider.GetString("DocumentDate");

        /// <summary>
        /// Documents 
        /// </summary>
		public static string Documents => ResourceProvider.GetString("Documents");

        /// <summary>
        /// Documents count 
        /// </summary>
		public static string DocumentsCount => ResourceProvider.GetString("DocumentsCount");

        /// <summary>
        /// Documents for printing 
        /// </summary>
		public static string DocumentsForPrinting => ResourceProvider.GetString("DocumentsForPrinting");

        /// <summary>
        /// Documents left 
        /// </summary>
		public static string DocumentsLeft => ResourceProvider.GetString("DocumentsLeft");

        /// <summary>
        /// Documents 
        /// </summary>
		public static string DocumentsLinkName => ResourceProvider.GetString("DocumentsLinkName");

        /// <summary>
        /// Documents max 
        /// </summary>
		public static string DocumentsMax => ResourceProvider.GetString("DocumentsMax");

        /// <summary>
        /// Documents 
        /// </summary>
		public static string DocumentsPageTitle => ResourceProvider.GetString("DocumentsPageTitle");

        /// <summary>
        /// /documents 
        /// </summary>
		public static string DocumentsUrlPath => ResourceProvider.GetString("DocumentsUrlPath");

        /// <summary>
        /// DocumentType 
        /// </summary>
		public static string DocumentType => ResourceProvider.GetString("DocumentType");

        /// <summary>
        /// Add tax group 
        /// </summary>
		public static string DodajPoreznuGrupu => ResourceProvider.GetString("DodajPoreznuGrupu");

        /// <summary>
        /// House number addition 
        /// </summary>
		public static string DodatakKucnomBroju => ResourceProvider.GetString("DodatakKucnomBroju");

        /// <summary>
        /// Documents (bills and offers) 
        /// </summary>
		public static string DokumentiRacuniPonude => ResourceProvider.GetString("DokumentiRacuniPonude");

        /// <summary>
        /// Duplicate 
        /// </summary>
		public static string Duplicate => ResourceProvider.GetString("Duplicate");

        /// <summary>
        /// Duplicated names found 
        /// </summary>
		public static string DuplicatedNamesFound => ResourceProvider.GetString("DuplicatedNamesFound");

        /// <summary>
        /// Duplicate offer. Are you sure? 
        /// </summary>
		public static string DuplicateOfferAreYouSure => ResourceProvider.GetString("DuplicateOfferAreYouSure");

        /// <summary>
        /// Duplication is not possible, document is not offer or offer is not paid 
        /// </summary>
		public static string DupliciranjeNijeMoguceNijePlaceno => ResourceProvider.GetString("DupliciranjeNijeMoguceNijePlaceno");

        /// <summary>
        /// Duplication is not possible, offer is not paid 
        /// </summary>
		public static string DupliciranjeNijeMogucePonudaNijePlacena => ResourceProvider.GetString("DupliciranjeNijeMogucePonudaNijePlacena");

        /// <summary>
        /// Duration has to be larger than 0 
        /// </summary>
		public static string DurationHasToBeLargerThanZero => ResourceProvider.GetString("DurationHasToBeLargerThanZero");

        /// <summary>
        /// Duration minutes 
        /// </summary>
		public static string DurationMinutes => ResourceProvider.GetString("DurationMinutes");

        /// <summary>
        /// Duration Time 
        /// </summary>
		public static string DurationTime => ResourceProvider.GetString("DurationTime");

        /// <summary>
        /// Edit 
        /// </summary>
		public static string Edit => ResourceProvider.GetString("Edit");

        /// <summary>
        /// Edit category 
        /// </summary>
		public static string EditCategory => ResourceProvider.GetString("EditCategory");

        /// <summary>
        /// Edit normativ 
        /// </summary>
		public static string EditNormativ => ResourceProvider.GetString("EditNormativ");

        /// <summary>
        /// Edit product 
        /// </summary>
		public static string EditProduct => ResourceProvider.GetString("EditProduct");

        /// <summary>
        /// Edit Schedule Type Name 
        /// </summary>
		public static string EditScheduleTypeName => ResourceProvider.GetString("EditScheduleTypeName");

        /// <summary>
        /// Edit Status 
        /// </summary>
		public static string EditStatus => ResourceProvider.GetString("EditStatus");

        /// <summary>
        /// Education 
        /// </summary>
		public static string Education => ResourceProvider.GetString("Education");

        /// <summary>
        /// E-mail 
        /// </summary>
		public static string Email => ResourceProvider.GetString("Email");

        /// <summary>
        /// Email Address 
        /// </summary>
		public static string EmailAddress => ResourceProvider.GetString("EmailAddress");

        /// <summary>
        /// Employment Status 
        /// </summary>
		public static string EmploymentStatus => ResourceProvider.GetString("EmploymentStatus");

        /// <summary>
        /// Empty names can not be saved 
        /// </summary>
		public static string EmptyNamesCanNotBeSaved => ResourceProvider.GetString("EmptyNamesCanNotBeSaved");

        /// <summary>
        /// End Date 
        /// </summary>
		public static string EndDate => ResourceProvider.GetString("EndDate");

        /// <summary>
        /// End date has to be larger than start date 
        /// </summary>
		public static string EndDateHasToBeLargerThanStartDate => ResourceProvider.GetString("EndDateHasToBeLargerThanStartDate");

        /// <summary>
        /// End date is out of range 
        /// </summary>
		public static string EndDateIsOutOfRange => ResourceProvider.GetString("EndDateIsOutOfRange");

        /// <summary>
        /// End Date year has to be greater than 1900 
        /// </summary>
		public static string EndDateYearHasToBeGreaterThan => ResourceProvider.GetString("EndDateYearHasToBeGreaterThan");

        /// <summary>
        /// Enter the partial name 
        /// </summary>
		public static string EnterThePartOfTheName => ResourceProvider.GetString("EnterThePartOfTheName");

        /// <summary>
        /// Error in application, reload the page 
        /// </summary>
		public static string ErrorInApplicationReloadThePage => ResourceProvider.GetString("ErrorInApplicationReloadThePage");

        /// <summary>
        /// Evaluation 
        /// </summary>
		public static string Evaluation => ResourceProvider.GetString("Evaluation");

        /// <summary>
        /// Asking Questions 
        /// </summary>
		public static string EvaluationAskingQuestions => ResourceProvider.GetString("EvaluationAskingQuestions");

        /// <summary>
        /// Attitude 
        /// </summary>
		public static string EvaluationAttitude => ResourceProvider.GetString("EvaluationAttitude");

        /// <summary>
        /// Clothing 
        /// </summary>
		public static string EvaluationClothing => ResourceProvider.GetString("EvaluationClothing");

        /// <summary>
        /// Communication Non Verbal 
        /// </summary>
		public static string EvaluationCommunicationNonVerbal => ResourceProvider.GetString("EvaluationCommunicationNonVerbal");

        /// <summary>
        /// Communication Verbal 
        /// </summary>
		public static string EvaluationCommunicationVerbal => ResourceProvider.GetString("EvaluationCommunicationVerbal");

        /// <summary>
        /// Evaluation General 
        /// </summary>
		public static string EvaluationGeneral => ResourceProvider.GetString("EvaluationGeneral");

        /// <summary>
        /// Evaluation Saved 
        /// </summary>
		public static string EvaluationSaved => ResourceProvider.GetString("EvaluationSaved");

        /// <summary>
        /// Technical Knowledge 
        /// </summary>
		public static string EvaluationTechicalKnowledge => ResourceProvider.GetString("EvaluationTechicalKnowledge");

        /// <summary>
        /// Cash flow 
        /// </summary>
		public static string EvidencijaGotovineLinkName => ResourceProvider.GetString("EvidencijaGotovineLinkName");

        /// <summary>
        /// Cash flow 
        /// </summary>
		public static string EvidencijaGotovinePageTitle => ResourceProvider.GetString("EvidencijaGotovinePageTitle");

        /// <summary>
        /// /cash-flow 
        /// </summary>
		public static string EvidencijaGotovineUrlPath => ResourceProvider.GetString("EvidencijaGotovineUrlPath");

        /// <summary>
        /// Expired 
        /// </summary>
		public static string Expired => ResourceProvider.GetString("Expired");

        /// <summary>
        /// Expired Adverts 
        /// </summary>
		public static string ExpiredAdverts => ResourceProvider.GetString("ExpiredAdverts");

        /// <summary>
        /// Export Emails 
        /// </summary>
		public static string ExportEmails => ResourceProvider.GetString("ExportEmails");

        /// <summary>
        /// Export phones 
        /// </summary>
		public static string ExportPhones => ResourceProvider.GetString("ExportPhones");

        /// <summary>
        /// Fiducia 
        /// </summary>
		public static string FiduciaLinkName => ResourceProvider.GetString("FiduciaLinkName");

        /// <summary>
        /// Fiducia 
        /// </summary>
		public static string FiduciaPageTitle => ResourceProvider.GetString("FiduciaPageTitle");

        /// <summary>
        /// /fiducia 
        /// </summary>
		public static string FiduciaUrlPath => ResourceProvider.GetString("FiduciaUrlPath");

        /// <summary>
        /// Filter by Advert 
        /// </summary>
		public static string FilterByAdvert => ResourceProvider.GetString("FilterByAdvert");

        /// <summary>
        /// Finances 
        /// </summary>
		public static string Finances => ResourceProvider.GetString("Finances");

        /// <summary>
        /// Frist Name 
        /// </summary>
		public static string FirstName => ResourceProvider.GetString("FirstName");

        /// <summary>
        /// Fiskal certificate 
        /// </summary>
		public static string FiskalCertificate => ResourceProvider.GetString("FiskalCertificate");

        /// <summary>
        /// Fiskal bill 
        /// </summary>
		public static string FiskalniRacun => ResourceProvider.GetString("FiskalniRacun");

        /// <summary>
        /// From Highest Evaluation 
        /// </summary>
		public static string FromHighestEvaluation => ResourceProvider.GetString("FromHighestEvaluation");

        /// <summary>
        /// From Newest Application 
        /// </summary>
		public static string FromNewestApplication => ResourceProvider.GetString("FromNewestApplication");

        /// <summary>
        /// From Oldest Application 
        /// </summary>
		public static string FromOldestApplication => ResourceProvider.GetString("FromOldestApplication");

        /// <summary>
        /// Generate 
        /// </summary>
		public static string Generate => ResourceProvider.GetString("Generate");

        /// <summary>
        /// Generate, are you sure? 
        /// </summary>
		public static string GenerateAreYouSure => ResourceProvider.GetString("GenerateAreYouSure");

        /// <summary>
        /// Generate Pdf 
        /// </summary>
		public static string GeneratePdf => ResourceProvider.GetString("GeneratePdf");

        /// <summary>
        /// Geolocation tools 
        /// </summary>
		public static string GeolocationToolsLinkName => ResourceProvider.GetString("GeolocationToolsLinkName");

        /// <summary>
        /// Geolocation tools 
        /// </summary>
		public static string GeolocationToolsPageTitle => ResourceProvider.GetString("GeolocationToolsPageTitle");

        /// <summary>
        /// /gelocation-tools 
        /// </summary>
		public static string GeolocationToolsUrlPath => ResourceProvider.GetString("GeolocationToolsUrlPath");

        /// <summary>
        /// Get more items 
        /// </summary>
		public static string GetMoreItems => ResourceProvider.GetString("GetMoreItems");

        /// <summary>
        /// Error 
        /// </summary>
		public static string Greska => ResourceProvider.GetString("Greska");

        /// <summary>
        /// Error! Cart deleted. 
        /// </summary>
		public static string GreskaKosaricaObrisana => ResourceProvider.GetString("GreskaKosaricaObrisana");

        /// <summary>
        /// Group by 
        /// </summary>
		public static string GrupiranjePrema => ResourceProvider.GetString("GrupiranjePrema");

        /// <summary>
        /// Held 
        /// </summary>
		public static string Held => ResourceProvider.GetString("Held");

        /// <summary>
        /// Home 
        /// </summary>
		public static string HomeLinkName => ResourceProvider.GetString("HomeLinkName");

        /// <summary>
        /// Admin 
        /// </summary>
		public static string HomePageTitle => ResourceProvider.GetString("HomePageTitle");

        /// <summary>
        /// / 
        /// </summary>
		public static string HomeUrlPath => ResourceProvider.GetString("HomeUrlPath");

        /// <summary>
        /// IBAN already exists 
        /// </summary>
		public static string IBANAlreadyExists => ResourceProvider.GetString("IBANAlreadyExists");

        /// <summary>
        /// Import Erste CSV 
        /// </summary>
		public static string ImportErsteCsv => ResourceProvider.GetString("ImportErsteCsv");

        /// <summary>
        /// Import PBZ Excel xls 
        /// </summary>
		public static string ImportPbzExcelXls => ResourceProvider.GetString("ImportPbzExcelXls");

        /// <summary>
        /// Import PBZ XML 
        /// </summary>
		public static string ImportPbzXml => ResourceProvider.GetString("ImportPbzXml");

        /// <summary>
        /// Import transactions file 
        /// </summary>
		public static string ImportTransactionFile => ResourceProvider.GetString("ImportTransactionFile");

        /// <summary>
        /// Info 
        /// </summary>
		public static string Info => ResourceProvider.GetString("Info");

        /// <summary>
        /// Info telephone 
        /// </summary>
		public static string InfoTelephone => ResourceProvider.GetString("InfoTelephone");

        /// <summary>
        /// Invalid Adverts 
        /// </summary>
		public static string InvalidAdverts => ResourceProvider.GetString("InvalidAdverts");

        /// <summary>
        /// Invalid data 
        /// </summary>
		public static string InvalidData => ResourceProvider.GetString("InvalidData");

        /// <summary>
        /// Invalid IBAN 
        /// </summary>
		public static string InvalidIBAN => ResourceProvider.GetString("InvalidIBAN");

        /// <summary>
        /// Used 
        /// </summary>
		public static string Iskoristeno => ResourceProvider.GetString("Iskoristeno");

        /// <summary>
        /// Main 
        /// </summary>
		public static string IsMain => ResourceProvider.GetString("IsMain");

        /// <summary>
        /// Write to A4 
        /// </summary>
		public static string IspisiNaA4 => ResourceProvider.GetString("IspisiNaA4");

        /// <summary>
        /// Write to POS 
        /// </summary>
		public static string IspisiNaPOS => ResourceProvider.GetString("IspisiNaPOS");

        /// <summary>
        /// Expired 
        /// </summary>
		public static string Isteklo => ResourceProvider.GetString("Isteklo");

        /// <summary>
        /// Is visible 
        /// </summary>
		public static string IsVisible => ResourceProvider.GetString("IsVisible");

        /// <summary>
        /// Will create fiskal bill with current date 
        /// </summary>
		public static string IzdajeSeRacunSaSadasnjimDatumomTeSeFiskalizira => ResourceProvider.GetString("IzdajeSeRacunSaSadasnjimDatumomTeSeFiskalizira");

        /// <summary>
        /// Iznos naknade 
        /// </summary>
		public static string IznosNaknadeLabel => ResourceProvider.GetString("IznosNaknadeLabel");

        /// <summary>
        /// Single price 
        /// </summary>
		public static string JedinicnaCijena => ResourceProvider.GetString("JedinicnaCijena");

        /// <summary>
        /// Job 
        /// </summary>
		public static string Job => ResourceProvider.GetString("Job");

        /// <summary>
        /// Job Adverts 
        /// </summary>
		public static string JobAdverts => ResourceProvider.GetString("JobAdverts");

        /// <summary>
        /// Job adverts 
        /// </summary>
		public static string JobAdvertsLinkName => ResourceProvider.GetString("JobAdvertsLinkName");

        /// <summary>
        /// Job adverts 
        /// </summary>
		public static string JobAdvertsPageTitle => ResourceProvider.GetString("JobAdvertsPageTitle");

        /// <summary>
        /// /job-adverts 
        /// </summary>
		public static string JobAdvertsUrlPath => ResourceProvider.GetString("JobAdvertsUrlPath");

        /// <summary>
        /// Job applicants 
        /// </summary>
		public static string JobApplicantsLinkName => ResourceProvider.GetString("JobApplicantsLinkName");

        /// <summary>
        /// Job applicants 
        /// </summary>
		public static string JobApplicantsPageTitle => ResourceProvider.GetString("JobApplicantsPageTitle");

        /// <summary>
        /// /job-applicants 
        /// </summary>
		public static string JobApplicantsUrlPath => ResourceProvider.GetString("JobApplicantsUrlPath");

        /// <summary>
        /// Job Calendar 
        /// </summary>
		public static string JobCalendar => ResourceProvider.GetString("JobCalendar");

        /// <summary>
        /// Job calendar 
        /// </summary>
		public static string JobCalendarLinkName => ResourceProvider.GetString("JobCalendarLinkName");

        /// <summary>
        /// Job calendar 
        /// </summary>
		public static string JobCalendarPageTitle => ResourceProvider.GetString("JobCalendarPageTitle");

        /// <summary>
        /// /job-calendar 
        /// </summary>
		public static string JobCalendarUrlPath => ResourceProvider.GetString("JobCalendarUrlPath");

        /// <summary>
        /// Companies 
        /// </summary>
		public static string JobCompanies => ResourceProvider.GetString("JobCompanies");

        /// <summary>
        /// Templates 
        /// </summary>
		public static string JobTemplatesLinkName => ResourceProvider.GetString("JobTemplatesLinkName");

        /// <summary>
        /// Templates 
        /// </summary>
		public static string JobTemplatesPageTitle => ResourceProvider.GetString("JobTemplatesPageTitle");

        /// <summary>
        /// /job-templates 
        /// </summary>
		public static string JobTemplatesUrlPath => ResourceProvider.GetString("JobTemplatesUrlPath");

        /// <summary>
        /// Same as offer date 
        /// </summary>
		public static string KaoDatumPonude => ResourceProvider.GetString("KaoDatumPonude");

        /// <summary>
        /// Same as bill date 
        /// </summary>
		public static string KaoDatumRacuna => ResourceProvider.GetString("KaoDatumRacuna");

        /// <summary>
        /// Category has articles, it can't be deleted! 
        /// </summary>
		public static string KategorijaImaArtikleBrisanjeNijeMoguce => ResourceProvider.GetString("KategorijaImaArtikleBrisanjeNijeMoguce");

        /// <summary>
        /// Category has subcategories, it can't be deleted! 
        /// </summary>
		public static string KategorijaImaPodkategorijeBrisanjeNijeMoguce => ResourceProvider.GetString("KategorijaImaPodkategorijeBrisanjeNijeMoguce");

        /// <summary>
        /// Category already exists, can't be added. 
        /// </summary>
		public static string KategorijaVecPostojiDodavanjeNijeMoguce => ResourceProvider.GetString("KategorijaVecPostojiDodavanjeNijeMoguce");

        /// <summary>
        /// Categories 
        /// </summary>
		public static string Kategorije => ResourceProvider.GetString("Kategorije");

        /// <summary>
        /// Quantity 
        /// </summary>
		public static string Kolicina => ResourceProvider.GetString("Kolicina");

        /// <summary>
        /// Service end 
        /// </summary>
		public static string KrajPrimjene => ResourceProvider.GetString("KrajPrimjene");

        /// <summary>
        /// Created automatically 
        /// </summary>
		public static string KreiraSeAutomatskiNaSpremanju => ResourceProvider.GetString("KreiraSeAutomatskiNaSpremanju");

        /// <summary>
        /// House number 
        /// </summary>
		public static string KucniBroj => ResourceProvider.GetString("KucniBroj");

        /// <summary>
        /// Last Name 
        /// </summary>
		public static string LastName => ResourceProvider.GetString("LastName");

        /// <summary>
        /// Litmits 
        /// </summary>
		public static string Litmits => ResourceProvider.GetString("Litmits");

        /// <summary>
        /// Loading 
        /// </summary>
		public static string Loading => ResourceProvider.GetString("Loading");

        /// <summary>
        /// Load more items 
        /// </summary>
		public static string LoadMoreItems => ResourceProvider.GetString("LoadMoreItems");

        /// <summary>
        /// Login 
        /// </summary>
		public static string Login => ResourceProvider.GetString("Login");

        /// <summary>
        /// Login Data 
        /// </summary>
		public static string LoginData => ResourceProvider.GetString("LoginData");

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
        /// Logout 
        /// </summary>
		public static string Logout => ResourceProvider.GetString("Logout");

        /// <summary>
        /// The password does not match the selected certificate. 
        /// </summary>
		public static string LozinkaNeOdgovaraOdabranomCertifikatu => ResourceProvider.GetString("LozinkaNeOdgovaraOdabranomCertifikatu");

        /// <summary>
        /// Main Data 
        /// </summary>
		public static string MainData => ResourceProvider.GetString("MainData");

        /// <summary>
        /// Retail (MPC) 
        /// </summary>
		public static string MaloprodajnaMPC => ResourceProvider.GetString("MaloprodajnaMPC");

        /// <summary>
        /// Mark paid 
        /// </summary>
		public static string MarkPaymentDone => ResourceProvider.GetString("MarkPaymentDone");

        /// <summary>
        /// Message failed 
        /// </summary>
		public static string MessageFailed => ResourceProvider.GetString("MessageFailed");

        /// <summary>
        /// Message sent 
        /// </summary>
		public static string MessageSent => ResourceProvider.GetString("MessageSent");

        /// <summary>
        /// Units 
        /// </summary>
		public static string Mjera => ResourceProvider.GetString("Mjera");

        /// <summary>
        /// City 
        /// </summary>
		public static string Mjesto => ResourceProvider.GetString("Mjesto");

        /// <summary>
        /// Mobile Phone 
        /// </summary>
		public static string MobilePhone => ResourceProvider.GetString("MobilePhone");

        /// <summary>
        /// Mobitel (3859xxxxxxxx) 
        /// </summary>
		public static string MobitelLabelWithExample => ResourceProvider.GetString("MobitelLabelWithExample");

        /// <summary>
        /// The cell phone is not correct 
        /// </summary>
		public static string MobitelNijeIspravan => ResourceProvider.GetString("MobitelNijeIspravan");

        /// <summary>
        /// Modify Advert 
        /// </summary>
		public static string ModifyAdvert => ResourceProvider.GetString("ModifyAdvert");

        /// <summary>
        /// Modify operator 
        /// </summary>
		public static string ModifyBillOperator => ResourceProvider.GetString("ModifyBillOperator");

        /// <summary>
        /// Modify Schedule 
        /// </summary>
		public static string ModifySchedule => ResourceProvider.GetString("ModifySchedule");

        /// <summary>
        /// Modify template 
        /// </summary>
		public static string ModifyTemplate => ResourceProvider.GetString("ModifyTemplate");

        /// <summary>
        /// Please enter 2 chars min. 
        /// </summary>
		public static string MolimoUpisiteNajmanjeXZnamenki => ResourceProvider.GetString("MolimoUpisiteNajmanjeXZnamenki");

        /// <summary>
        /// MPC 
        /// </summary>
		public static string MPC => ResourceProvider.GetString("MPC");

        /// <summary>
        /// Subsequent modification is not possible. 
        /// </summary>
		public static string NaknadnoMijenjanjeNijeMoguce => ResourceProvider.GetString("NaknadnoMijenjanjeNijeMoguce");

        /// <summary>
        /// Name 
        /// </summary>
		public static string Name => ResourceProvider.GetString("Name");

        /// <summary>
        /// Name can not be empty 
        /// </summary>
		public static string NameCanNotBeEmpty => ResourceProvider.GetString("NameCanNotBeEmpty");

        /// <summary>
        /// Name has to be entered 
        /// </summary>
		public static string NameHasToBeEntered => ResourceProvider.GetString("NameHasToBeEntered");

        /// <summary>
        /// Charged 
        /// </summary>
		public static string Naplaceno => ResourceProvider.GetString("Naplaceno");

        /// <summary>
        /// Payment type 
        /// </summary>
		public static string NaplatniUredjaj => ResourceProvider.GetString("NaplatniUredjaj");

        /// <summary>
        /// Payment types 
        /// </summary>
		public static string NaplatniUredjaji => ResourceProvider.GetString("NaplatniUredjaji");

        /// <summary>
        /// Payment types max 
        /// </summary>
		public static string NaplatniUredjajiMax => ResourceProvider.GetString("NaplatniUredjajiMax");

        /// <summary>
        /// Note 
        /// </summary>
		public static string Napomena => ResourceProvider.GetString("Napomena");

        /// <summary>
        /// Article name (at bill) 
        /// </summary>
		public static string NazivArtiklaNaRacunu => ResourceProvider.GetString("NazivArtiklaNaRacunu");

        /// <summary>
        /// Group name 
        /// </summary>
		public static string NazivGrupe => ResourceProvider.GetString("NazivGrupe");

        /// <summary>
        /// Category name 
        /// </summary>
		public static string NazivKategorije => ResourceProvider.GetString("NazivKategorije");

        /// <summary>
        /// Name of compensation 
        /// </summary>
		public static string NazivNaknadeLabel => ResourceProvider.GetString("NazivNaknadeLabel");

        /// <summary>
        /// Name of tolling device 
        /// </summary>
		public static string NazivNaplatnogUredjaja => ResourceProvider.GetString("NazivNaplatnogUredjaja");

        /// <summary>
        /// Space name 
        /// </summary>
		public static string NazivProstora => ResourceProvider.GetString("NazivProstora");

        /// <summary>
        /// Item name 
        /// </summary>
		public static string NazivStavke => ResourceProvider.GetString("NazivStavke");

        /// <summary>
        /// Missing customer address 
        /// </summary>
		public static string NedostajeAdresaKupca => ResourceProvider.GetString("NedostajeAdresaKupca");

        /// <summary>
        /// Missing customer name 
        /// </summary>
		public static string NedostajeNazivKupca => ResourceProvider.GetString("NedostajeNazivKupca");

        /// <summary>
        /// Missing unique number 
        /// </summary>
		public static string NedostajeOIBKupca => ResourceProvider.GetString("NedostajeOIBKupca");

        /// <summary>
        /// Pending products 
        /// </summary>
		public static string NedovrseniProdukti => ResourceProvider.GetString("NedovrseniProdukti");

        /// <summary>
        /// No active services 
        /// </summary>
		public static string NemaAktivnihUsluga => ResourceProvider.GetString("NemaAktivnihUsluga");

        /// <summary>
        /// No articles 
        /// </summary>
		public static string NemaArtikala => ResourceProvider.GetString("NemaArtikala");

        /// <summary>
        /// You have no active POS services. 
        /// </summary>
		public static string NemateAktivnuUsluguFiskalneBlagajne => ResourceProvider.GetString("NemateAktivnuUsluguFiskalneBlagajne");

        /// <summary>
        /// You have no right to assign current category. 
        /// </summary>
		public static string NematePravaZaDodjeljivanjeOveKategorije => ResourceProvider.GetString("NematePravaZaDodjeljivanjeOveKategorije");

        /// <summary>
        /// Unsorted 
        /// </summary>
		public static string Nerasporedjeni => ResourceProvider.GetString("Nerasporedjeni");

        /// <summary>
        /// New schedule is saved 
        /// </summary>
		public static string NeScheduleIsSaved => ResourceProvider.GetString("NeScheduleIsSaved");

        /// <summary>
        /// New 
        /// </summary>
		public static string New => ResourceProvider.GetString("New");

        /// <summary>
        /// New advert saved 
        /// </summary>
		public static string NewAdvertSaved => ResourceProvider.GetString("NewAdvertSaved");

        /// <summary>
        /// New Application 
        /// </summary>
		public static string NewApplication => ResourceProvider.GetString("NewApplication");

        /// <summary>
        /// New operator 
        /// </summary>
		public static string NewBillOperator => ResourceProvider.GetString("NewBillOperator");

        /// <summary>
        /// New cart 
        /// </summary>
		public static string NewCart => ResourceProvider.GetString("NewCart");

        /// <summary>
        /// New certificate 
        /// </summary>
		public static string NewCertificate => ResourceProvider.GetString("NewCertificate");

        /// <summary>
        /// New Interview Schedule 
        /// </summary>
		public static string NewInterviewSchedule => ResourceProvider.GetString("NewInterviewSchedule");

        /// <summary>
        /// New Item 
        /// </summary>
		public static string NewItem => ResourceProvider.GetString("NewItem");

        /// <summary>
        /// New Items Count 
        /// </summary>
		public static string NewItemsCount => ResourceProvider.GetString("NewItemsCount");

        /// <summary>
        /// New status added 
        /// </summary>
		public static string NewStatusAdded => ResourceProvider.GetString("NewStatusAdded");

        /// <summary>
        /// No valid certificate found 
        /// </summary>
		public static string NijePronadjenIspravanCertifikat => ResourceProvider.GetString("NijePronadjenIspravanCertifikat");

        /// <summary>
        /// Did not find the correct charging device 
        /// </summary>
		public static string NijePronadjenIspravanNaplatniUredjaj => ResourceProvider.GetString("NijePronadjenIspravanNaplatniUredjaj");

        /// <summary>
        /// Certificate not found. 
        /// </summary>
		public static string NijePronadjenValjaniFiskalniCertifikat => ResourceProvider.GetString("NijePronadjenValjaniFiskalniCertifikat");

        /// <summary>
        /// No 
        /// </summary>
		public static string No => ResourceProvider.GetString("No");

        /// <summary>
        /// No documents 
        /// </summary>
		public static string NoDocuments => ResourceProvider.GetString("NoDocuments");

        /// <summary>
        /// No pictures 
        /// </summary>
		public static string NoPictures => ResourceProvider.GetString("NoPictures");

        /// <summary>
        /// No results 
        /// </summary>
		public static string NoResults => ResourceProvider.GetString("NoResults");

        /// <summary>
        /// Normative 
        /// </summary>
		public static string Normativ => ResourceProvider.GetString("Normativ");

        /// <summary>
        /// Normatives 
        /// </summary>
		public static string Normativi => ResourceProvider.GetString("Normativi");

        /// <summary>
        /// Normative (component of another article) 
        /// </summary>
		public static string NormativSastojakDrugogArtikla => ResourceProvider.GetString("NormativSastojakDrugogArtikla");

        /// <summary>
        /// Note 
        /// </summary>
		public static string Note => ResourceProvider.GetString("Note");

        /// <summary>
        /// Note history 
        /// </summary>
		public static string NoteHistory => ResourceProvider.GetString("NoteHistory");

        /// <summary>
        /// Not held 
        /// </summary>
		public static string NotHeld => ResourceProvider.GetString("NotHeld");

        /// <summary>
        /// Nothing selected 
        /// </summary>
		public static string NothingSelected => ResourceProvider.GetString("NothingSelected");

        /// <summary>
        /// Nothing to print 
        /// </summary>
		public static string NothingToPrint => ResourceProvider.GetString("NothingToPrint");

        /// <summary>
        /// New cart 
        /// </summary>
		public static string NovaKosarica => ResourceProvider.GetString("NovaKosarica");

        /// <summary>
        /// New item 
        /// </summary>
		public static string NovaStavka => ResourceProvider.GetString("NovaStavka");

        /// <summary>
        /// New service 
        /// </summary>
		public static string NovaUsluga => ResourceProvider.GetString("NovaUsluga");

        /// <summary>
        /// New article 
        /// </summary>
		public static string NoviArtikl => ResourceProvider.GetString("NoviArtikl");

        /// <summary>
        /// now or enter value 
        /// </summary>
		public static string NowOrEnterValue => ResourceProvider.GetString("NowOrEnterValue");

        /// <summary>
        /// Remove item? 
        /// </summary>
		public static string ObrisatiStavku => ResourceProvider.GetString("ObrisatiStavku");

        /// <summary>
        /// Select 
        /// </summary>
		public static string Odaberite => ResourceProvider.GetString("Odaberite");

        /// <summary>
        /// Select the date of the cancellation account! 
        /// </summary>
		public static string OdaberiteDatumStornoRacuna => ResourceProvider.GetString("OdaberiteDatumStornoRacuna");

        /// <summary>
        /// select payment type 
        /// </summary>
		public static string OdaberiteNacinPlacanja => ResourceProvider.GetString("OdaberiteNacinPlacanja");

        /// <summary>
        /// select working place 
        /// </summary>
		public static string OdaberitePoslovniProstor => ResourceProvider.GetString("OdaberitePoslovniProstor");

        /// <summary>
        /// selected_documents.pdf 
        /// </summary>
		public static string OdabraniDokumentiPdfFileName => ResourceProvider.GetString("OdabraniDokumentiPdfFileName");

        /// <summary>
        /// Category can not be deleted! 
        /// </summary>
		public static string OdabranuKategorijuNijeMoguceObrisati => ResourceProvider.GetString("OdabranuKategorijuNijeMoguceObrisati");

        /// <summary>
        /// Offers 
        /// </summary>
		public static string Offers => ResourceProvider.GetString("Offers");

        /// <summary>
        /// Operator OIB invalid 
        /// </summary>
		public static string OibOperatoraNijeIspravan => ResourceProvider.GetString("OibOperatoraNijeIspravan");

        /// <summary>
        /// Company OIB has to be entered 
        /// </summary>
		public static string OibTvrtkeMoraBitiUpisan => ResourceProvider.GetString("OibTvrtkeMoraBitiUpisan");

        /// <summary>
        /// Company OIB invalid 
        /// </summary>
		public static string OibTvrtkeNijeIspravan => ResourceProvider.GetString("OibTvrtkeNijeIspravan");

        /// <summary>
        /// The OIB in the certificate is different from the registered company OIB. 
        /// </summary>
		public static string OibUCertifikatuJeDrugacijiOdUpisanogOibaTvrtke => ResourceProvider.GetString("OibUCertifikatuJeDrugacijiOdUpisanogOibaTvrtke");

        /// <summary>
        /// Township 
        /// </summary>
		public static string Opcina => ResourceProvider.GetString("Opcina");

        /// <summary>
        /// Open 
        /// </summary>
		public static string Open => ResourceProvider.GetString("Open");

        /// <summary>
        /// Open public site 
        /// </summary>
		public static string OpenPublicSite => ResourceProvider.GetString("OpenPublicSite");

        /// <summary>
        /// Open selected 
        /// </summary>
		public static string OpenSelected => ResourceProvider.GetString("OpenSelected");

        /// <summary>
        /// Operator 
        /// </summary>
		public static string Operator => ResourceProvider.GetString("Operator");

        /// <summary>
        /// Operators 
        /// </summary>
		public static string Operatori => ResourceProvider.GetString("Operatori");

        /// <summary>
        /// Operators max 
        /// </summary>
		public static string OperatoriMax => ResourceProvider.GetString("OperatoriMax");

        /// <summary>
        /// Operator first last name 
        /// </summary>
		public static string OperatorImePrezime => ResourceProvider.GetString("OperatorImePrezime");

        /// <summary>
        /// Operator is active 
        /// </summary>
		public static string OperatorIsActive => ResourceProvider.GetString("OperatorIsActive");

        /// <summary>
        /// Operator OIB 
        /// </summary>
		public static string OperatorOIB => ResourceProvider.GetString("OperatorOIB");

        /// <summary>
        /// Description 
        /// </summary>
		public static string Opis => ResourceProvider.GetString("Opis");

        /// <summary>
        /// Description (for search) 
        /// </summary>
		public static string OpisZaPretragu => ResourceProvider.GetString("OpisZaPretragu");

        /// <summary>
        /// Order by selection 
        /// </summary>
		public static string OrderBySelection => ResourceProvider.GetString("OrderBySelection");

        /// <summary>
        /// or enter value 
        /// </summary>
		public static string OrEnterValue => ResourceProvider.GetString("OrEnterValue");

        /// <summary>
        /// Exempt VAT note 
        /// </summary>
		public static string OslobodjenoPdvaLabel => ResourceProvider.GetString("OslobodjenoPdvaLabel");

        /// <summary>
        /// Exempt VAT note 
        /// </summary>
		public static string OslobodjenoPdvaNapomena => ResourceProvider.GetString("OslobodjenoPdvaNapomena");

        /// <summary>
        /// VAT exempted under Article 90 of the VAT Act. 
        /// </summary>
		public static string OslobodjenoPDVaPoClanku90 => ResourceProvider.GetString("OslobodjenoPDVaPoClanku90");

        /// <summary>
        /// Other taxes (%) 
        /// </summary>
		public static string OstaliPorezAndPosto => ResourceProvider.GetString("OstaliPorezAndPosto");

        /// <summary>
        /// Other tax name 
        /// </summary>
		public static string OstaliPorezNazivLabel => ResourceProvider.GetString("OstaliPorezNazivLabel");

        /// <summary>
        /// Other applications 
        /// </summary>
		public static string OtherApplications => ResourceProvider.GetString("OtherApplications");

        /// <summary>
        /// The tag is already taken 
        /// </summary>
		public static string OznakaJeVecZauzeta => ResourceProvider.GetString("OznakaJeVecZauzeta");

        /// <summary>
        /// Tolling device tag 
        /// </summary>
		public static string OznakaNaplatnogUredjaja => ResourceProvider.GetString("OznakaNaplatnogUredjaja");

        /// <summary>
        /// Business space tag 
        /// </summary>
		public static string OznakaPoslovnogProstora => ResourceProvider.GetString("OznakaPoslovnogProstora");

        /// <summary>
        /// Password 
        /// </summary>
		public static string Password => ResourceProvider.GetString("Password");

        /// <summary>
        /// Password has to be entered 
        /// </summary>
		public static string PasswordHasToBeEnterd => ResourceProvider.GetString("PasswordHasToBeEnterd");

        /// <summary>
        /// Password is required 
        /// </summary>
		public static string PasswordIsRequired => ResourceProvider.GetString("PasswordIsRequired");

        /// <summary>
        /// Payment Date 
        /// </summary>
		public static string PaymentDate => ResourceProvider.GetString("PaymentDate");

        /// <summary>
        /// Payment method 
        /// </summary>
		public static string PaymentMethod => ResourceProvider.GetString("PaymentMethod");

        /// <summary>
        /// Payments 
        /// </summary>
		public static string Payments => ResourceProvider.GetString("Payments");

        /// <summary>
        /// Payments 
        /// </summary>
		public static string PaymentsLinkName => ResourceProvider.GetString("PaymentsLinkName");

        /// <summary>
        /// Payments 
        /// </summary>
		public static string PaymentsPageTitle => ResourceProvider.GetString("PaymentsPageTitle");

        /// <summary>
        /// /payments 
        /// </summary>
		public static string PaymentsUrlPath => ResourceProvider.GetString("PaymentsUrlPath");

        /// <summary>
        /// Payment type 
        /// </summary>
		public static string PaymentType => ResourceProvider.GetString("PaymentType");

        /// <summary>
        /// Pdf file generated 
        /// </summary>
		public static string PdfFileGenerated => ResourceProvider.GetString("PdfFileGenerated");

        /// <summary>
        /// Pdf general payment 
        /// </summary>
		public static string PdfGeneralPayment => ResourceProvider.GetString("PdfGeneralPayment");

        /// <summary>
        /// Pdf memo payment 
        /// </summary>
		public static string PdfMemoPayment => ResourceProvider.GetString("PdfMemoPayment");

        /// <summary>
        /// Pdf white 
        /// </summary>
		public static string PdfWhite => ResourceProvider.GetString("PdfWhite");

        /// <summary>
        /// VAT (%) 
        /// </summary>
		public static string PdvLabelAndPosto => ResourceProvider.GetString("PdvLabelAndPosto");

        /// <summary>
        /// VAT system end 
        /// </summary>
		public static string PdvSustavEnd => ResourceProvider.GetString("PdvSustavEnd");

        /// <summary>
        /// VAT system start 
        /// </summary>
		public static string PdvSustavStart => ResourceProvider.GetString("PdvSustavStart");

        /// <summary>
        /// Pending adverts 
        /// </summary>
		public static string PendingAdverts => ResourceProvider.GetString("PendingAdverts");

        /// <summary>
        /// Personal aata 
        /// </summary>
		public static string PersonalData => ResourceProvider.GetString("PersonalData");

        /// <summary>
        /// Picture 
        /// </summary>
		public static string Picture => ResourceProvider.GetString("Picture");

        /// <summary>
        /// Pictures 
        /// </summary>
		public static string Pictures => ResourceProvider.GetString("Pictures");

        /// <summary>
        /// Paid 
        /// </summary>
		public static string Placeno => ResourceProvider.GetString("Placeno");

        /// <summary>
        /// Confirmation required 
        /// </summary>
		public static string PleaseConfirm => ResourceProvider.GetString("PleaseConfirm");

        /// <summary>
        /// Please enter the data 
        /// </summary>
		public static string PleaseEnterTheData => ResourceProvider.GetString("PleaseEnterTheData");

        /// <summary>
        /// Please wait 
        /// </summary>
		public static string PleaseWait => ResourceProvider.GetString("PleaseWait");

        /// <summary>
        /// Service start 
        /// </summary>
		public static string PocetakPrimjene => ResourceProvider.GetString("PocetakPrimjene");

        /// <summary>
        /// Discount (%) 
        /// </summary>
		public static string PopustPosto => ResourceProvider.GetString("PopustPosto");

        /// <summary>
        /// Tax group 
        /// </summary>
		public static string PoreznaGrupa => ResourceProvider.GetString("PoreznaGrupa");

        /// <summary>
        /// Consumption tax (%) 
        /// </summary>
		public static string PorezNaPotrosnjuLabelAndPosto => ResourceProvider.GetString("PorezNaPotrosnjuLabelAndPosto");

        /// <summary>
        /// Tax groups 
        /// </summary>
		public static string PorezneGrupe => ResourceProvider.GetString("PorezneGrupe");

        /// <summary>
        /// Tax groups 
        /// </summary>
		public static string PorezneGrupeLinkName => ResourceProvider.GetString("PorezneGrupeLinkName");

        /// <summary>
        /// Tax groups max 
        /// </summary>
		public static string PorezneGrupeMax => ResourceProvider.GetString("PorezneGrupeMax");

        /// <summary>
        /// Tax groups 
        /// </summary>
		public static string PorezneGrupePageTitle => ResourceProvider.GetString("PorezneGrupePageTitle");

        /// <summary>
        /// /tax-groups 
        /// </summary>
		public static string PorezneGrupeUrlPath => ResourceProvider.GetString("PorezneGrupeUrlPath");

        /// <summary>
        /// POS 
        /// </summary>
		public static string Pos => ResourceProvider.GetString("Pos");

        /// <summary>
        /// Send link 
        /// </summary>
		public static string PosaljiLink => ResourceProvider.GetString("PosaljiLink");

        /// <summary>
        /// Branch offices 
        /// </summary>
		public static string PosBranchOfficesLinkName => ResourceProvider.GetString("PosBranchOfficesLinkName");

        /// <summary>
        /// Branch offices 
        /// </summary>
		public static string PosBranchOfficesPageTitle => ResourceProvider.GetString("PosBranchOfficesPageTitle");

        /// <summary>
        /// /pos-branch-offices 
        /// </summary>
		public static string PosBranchOfficesUrlPath => ResourceProvider.GetString("PosBranchOfficesUrlPath");

        /// <summary>
        /// Charging devices 
        /// </summary>
		public static string PosChargingDevicesLinkName => ResourceProvider.GetString("PosChargingDevicesLinkName");

        /// <summary>
        /// Charging devices 
        /// </summary>
		public static string PosChargingDevicesPageTitle => ResourceProvider.GetString("PosChargingDevicesPageTitle");

        /// <summary>
        /// /pos-charging-devices 
        /// </summary>
		public static string PosChargingDevicesUrlPath => ResourceProvider.GetString("PosChargingDevicesUrlPath");

        /// <summary>
        /// POS Companies 
        /// </summary>
		public static string PosCompanies => ResourceProvider.GetString("PosCompanies");

        /// <summary>
        /// POS Companies 
        /// </summary>
		public static string PosCompaniesLinkName => ResourceProvider.GetString("PosCompaniesLinkName");

        /// <summary>
        /// POS Companies 
        /// </summary>
		public static string PosCompaniesPageTitle => ResourceProvider.GetString("PosCompaniesPageTitle");

        /// <summary>
        /// /pos-companies 
        /// </summary>
		public static string PosCompaniesUrlPath => ResourceProvider.GetString("PosCompaniesUrlPath");

        /// <summary>
        /// Company 
        /// </summary>
		public static string PosCompanyLinkName => ResourceProvider.GetString("PosCompanyLinkName");

        /// <summary>
        /// Company 
        /// </summary>
		public static string PosCompanyPageTitle => ResourceProvider.GetString("PosCompanyPageTitle");

        /// <summary>
        /// /company 
        /// </summary>
		public static string PosCompanyUrlPath => ResourceProvider.GetString("PosCompanyUrlPath");

        /// <summary>
        /// Branch office 
        /// </summary>
		public static string PoslovniProstor => ResourceProvider.GetString("PoslovniProstor");

        /// <summary>
        /// Working places 
        /// </summary>
		public static string PoslovniProstori => ResourceProvider.GetString("PoslovniProstori");

        /// <summary>
        /// Working places max 
        /// </summary>
		public static string PoslovniProstoriMax => ResourceProvider.GetString("PoslovniProstoriMax");

        /// <summary>
        /// POS 
        /// </summary>
		public static string PosMainLinkName => ResourceProvider.GetString("PosMainLinkName");

        /// <summary>
        /// POS 
        /// </summary>
		public static string PosMainPageTitle => ResourceProvider.GetString("PosMainPageTitle");

        /// <summary>
        /// /pos-main 
        /// </summary>
		public static string PosMainUrlPath => ResourceProvider.GetString("PosMainUrlPath");

        /// <summary>
        /// Operators 
        /// </summary>
		public static string PosOperators => ResourceProvider.GetString("PosOperators");

        /// <summary>
        /// Operators 
        /// </summary>
		public static string PosOperatorsLinkName => ResourceProvider.GetString("PosOperatorsLinkName");

        /// <summary>
        /// Operators 
        /// </summary>
		public static string PosOperatorsPageTitle => ResourceProvider.GetString("PosOperatorsPageTitle");

        /// <summary>
        /// /pos-operators 
        /// </summary>
		public static string PosOperatorsUrlPath => ResourceProvider.GetString("PosOperatorsUrlPath");

        /// <summary>
        /// POS printer margins (mm) 
        /// </summary>
		public static string PosPisacMargine => ResourceProvider.GetString("PosPisacMargine");

        /// <summary>
        /// POS settings 
        /// </summary>
		public static string PosSettings => ResourceProvider.GetString("PosSettings");

        /// <summary>
        /// Postal number 
        /// </summary>
		public static string PostalNumber => ResourceProvider.GetString("PostalNumber");

        /// <summary>
        /// Zip code 
        /// </summary>
		public static string PostanskiBroj => ResourceProvider.GetString("PostanskiBroj");

        /// <summary>
        /// Post letter 
        /// </summary>
		public static string PostLetter => ResourceProvider.GetString("PostLetter");

        /// <summary>
        /// Document Number 
        /// </summary>
		public static string PozivNaBroj => ResourceProvider.GetString("PozivNaBroj");

        /// <summary>
        /// Predefined Interview Schedule 
        /// </summary>
		public static string PredefinedInterviewSchedule => ResourceProvider.GetString("PredefinedInterviewSchedule");

        /// <summary>
        /// Search 
        /// </summary>
		public static string Pretraga => ResourceProvider.GetString("Pretraga");

        /// <summary>
        /// Price kind 
        /// </summary>
		public static string PriceKind => ResourceProvider.GetString("PriceKind");

        /// <summary>
        /// Printing History 
        /// </summary>
		public static string PrintingHistory => ResourceProvider.GetString("PrintingHistory");

        /// <summary>
        /// Print history 
        /// </summary>
		public static string PrintingHistoryLinkName => ResourceProvider.GetString("PrintingHistoryLinkName");

        /// <summary>
        /// Print history 
        /// </summary>
		public static string PrintingHistoryPageTitle => ResourceProvider.GetString("PrintingHistoryPageTitle");

        /// <summary>
        /// /print-history 
        /// </summary>
		public static string PrintingHistoryUrlPath => ResourceProvider.GetString("PrintingHistoryUrlPath");

        /// <summary>
        /// Printing 
        /// </summary>
		public static string PrintingLinkName => ResourceProvider.GetString("PrintingLinkName");

        /// <summary>
        /// Printing 
        /// </summary>
		public static string PrintingPageTitle => ResourceProvider.GetString("PrintingPageTitle");

        /// <summary>
        /// /printing 
        /// </summary>
		public static string PrintingUrlPath => ResourceProvider.GetString("PrintingUrlPath");

        /// <summary>
        /// Product category 
        /// </summary>
		public static string ProductCategory => ResourceProvider.GetString("ProductCategory");

        /// <summary>
        /// ProductID 
        /// </summary>
		public static string ProductID => ResourceProvider.GetString("ProductID");

        /// <summary>
        /// Products in category 
        /// </summary>
		public static string ProductsInCategory => ResourceProvider.GetString("ProductsInCategory");

        /// <summary>
        /// Products 
        /// </summary>
		public static string ProductsLinkName => ResourceProvider.GetString("ProductsLinkName");

        /// <summary>
        /// Products max 
        /// </summary>
		public static string ProductsMax => ResourceProvider.GetString("ProductsMax");

        /// <summary>
        /// Products 
        /// </summary>
		public static string ProductsPageTitle => ResourceProvider.GetString("ProductsPageTitle");

        /// <summary>
        /// Products spent 
        /// </summary>
		public static string ProductsSpent => ResourceProvider.GetString("ProductsSpent");

        /// <summary>
        /// /products 
        /// </summary>
		public static string ProductsUrlPath => ResourceProvider.GetString("ProductsUrlPath");

        /// <summary>
        /// Products without category 
        /// </summary>
		public static string ProductsWithoutCategory => ResourceProvider.GetString("ProductsWithoutCategory");

        /// <summary>
        /// Products 
        /// </summary>
		public static string Produkti => ResourceProvider.GetString("Produkti");

        /// <summary>
        /// Profile 
        /// </summary>
		public static string Profile => ResourceProvider.GetString("Profile");

        /// <summary>
        /// Profile Picture 
        /// </summary>
		public static string ProfilePicture => ResourceProvider.GetString("ProfilePicture");

        /// <summary>
        /// Record with the current date and time, sure? 
        /// </summary>
		public static string ProknjizitiSaSadasnjimDatumomIVremenomSigurno => ResourceProvider.GetString("ProknjizitiSaSadasnjimDatumomIVremenomSigurno");

        /// <summary>
        /// Quantity 
        /// </summary>
		public static string Quantity => ResourceProvider.GetString("Quantity");

        /// <summary>
        /// Question 
        /// </summary>
		public static string Question => ResourceProvider.GetString("Question");

        /// <summary>
        /// Bill made on computer note 
        /// </summary>
		public static string RacunIzradjenNaRacunaluLabel => ResourceProvider.GetString("RacunIzradjenNaRacunaluLabel");

        /// <summary>
        /// - 
        /// </summary>
		public static string RacunIzradjenNaRacunaluNapomena => ResourceProvider.GetString("RacunIzradjenNaRacunaluNapomena");

        /// <summary>
        /// Working hours 
        /// </summary>
		public static string RadnoVrijeme => ResourceProvider.GetString("RadnoVrijeme");

        /// <summary>
        /// Release selected 
        /// </summary>
		public static string ReleaseSelected => ResourceProvider.GetString("ReleaseSelected");

        /// <summary>
        /// Remember me 
        /// </summary>
		public static string RememberMe => ResourceProvider.GetString("RememberMe");

        /// <summary>
        /// required 
        /// </summary>
		public static string RequiredData => ResourceProvider.GetString("RequiredData");

        /// <summary>
        /// Reserved 
        /// </summary>
		public static string Reserved => ResourceProvider.GetString("Reserved");

        /// <summary>
        /// Spent 
        /// </summary>
		public static string ResourcesSpent => ResourceProvider.GetString("ResourcesSpent");

        /// <summary>
        /// current date 
        /// </summary>
		public static string SadasnjiDatum => ResourceProvider.GetString("SadasnjiDatum");

        /// <summary>
        /// Save 
        /// </summary>
		public static string Save => ResourceProvider.GetString("Save");

        /// <summary>
        /// Save Access Rights 
        /// </summary>
		public static string SaveAccessRights => ResourceProvider.GetString("SaveAccessRights");

        /// <summary>
        /// Saving 
        /// </summary>
		public static string Saving => ResourceProvider.GetString("Saving");

        /// <summary>
        /// Schedule Added 
        /// </summary>
		public static string ScheduleAdded => ResourceProvider.GetString("ScheduleAdded");

        /// <summary>
        /// Schedule date can not be set in past time 
        /// </summary>
		public static string ScheduleDateCanNotBeSetInPast => ResourceProvider.GetString("ScheduleDateCanNotBeSetInPast");

        /// <summary>
        /// Schedule date has to be selected 
        /// </summary>
		public static string ScheduleDateHasToBeSelected => ResourceProvider.GetString("ScheduleDateHasToBeSelected");

        /// <summary>
        /// Schedule date or time is not valid 
        /// </summary>
		public static string ScheduleDateOrTimeIsNotValid => ResourceProvider.GetString("ScheduleDateOrTimeIsNotValid");

        /// <summary>
        /// Schedule has to be selected 
        /// </summary>
		public static string ScheduleHasToBeSelected => ResourceProvider.GetString("ScheduleHasToBeSelected");

        /// <summary>
        /// Schedule is already applied to current person 
        /// </summary>
		public static string ScheduleIsAlreadyAppliedToCurrentPerson => ResourceProvider.GetString("ScheduleIsAlreadyAppliedToCurrentPerson");

        /// <summary>
        /// Schedule is canceled 
        /// </summary>
		public static string ScheduleIsCanceled => ResourceProvider.GetString("ScheduleIsCanceled");

        /// <summary>
        /// Schedule is taken in the mean time by someone else 
        /// </summary>
		public static string ScheduleIsTakenInTheMeanTime => ResourceProvider.GetString("ScheduleIsTakenInTheMeanTime");

        /// <summary>
        /// Schedule is updated 
        /// </summary>
		public static string ScheduleIsUpdated => ResourceProvider.GetString("ScheduleIsUpdated");

        /// <summary>
        /// Schedules History 
        /// </summary>
		public static string SchedulesHistory => ResourceProvider.GetString("SchedulesHistory");

        /// <summary>
        /// Schedule time has to be selected 
        /// </summary>
		public static string ScheduleTimeHasToBeSelected => ResourceProvider.GetString("ScheduleTimeHasToBeSelected");

        /// <summary>
        /// Schedule Type 
        /// </summary>
		public static string ScheduleType => ResourceProvider.GetString("ScheduleType");

        /// <summary>
        /// Schedule type has to be selected 
        /// </summary>
		public static string ScheduleTypeHasToBeSelected => ResourceProvider.GetString("ScheduleTypeHasToBeSelected");

        /// <summary>
        /// Schedule Type Name 
        /// </summary>
		public static string ScheduleTypeName => ResourceProvider.GetString("ScheduleTypeName");

        /// <summary>
        /// Schedule Updated 
        /// </summary>
		public static string ScheduleUpdated => ResourceProvider.GetString("ScheduleUpdated");

        /// <summary>
        /// Search 
        /// </summary>
		public static string Search => ResourceProvider.GetString("Search");

        /// <summary>
        /// Searching 
        /// </summary>
		public static string Searching => ResourceProvider.GetString("Searching");

        /// <summary>
        /// Select 
        /// </summary>
		public static string Select => ResourceProvider.GetString("Select");

        /// <summary>
        /// Select All Loaded 
        /// </summary>
		public static string SelectAllLoaded => ResourceProvider.GetString("SelectAllLoaded");

        /// <summary>
        /// Select certificate 
        /// </summary>
		public static string SelectCertificate => ResourceProvider.GetString("SelectCertificate");

        /// <summary>
        /// Selected generate pdf 
        /// </summary>
		public static string SelectedGeneratePdf => ResourceProvider.GetString("SelectedGeneratePdf");

        /// <summary>
        /// Selected schedule is saved 
        /// </summary>
		public static string SelectedScheduleIsSaved => ResourceProvider.GetString("SelectedScheduleIsSaved");

        /// <summary>
        /// Send 
        /// </summary>
		public static string Send => ResourceProvider.GetString("Send");

        /// <summary>
        /// Serial 
        /// </summary>
		public static string Series => ResourceProvider.GetString("Series");

        /// <summary>
        /// Service 
        /// </summary>
		public static string Service => ResourceProvider.GetString("Service");

        /// <summary>
        /// Error! Invalid data..<br/>
        /// Possible actions:<br/>
        /// - refresht the page<br/>
        /// - delete cart<br/>
        /// - logout than login<br/>
        /// - delete cookies<br/>
        /// - change internet browser<br/>
        /// - restart computer 
        /// </summary>
		public static string ShoppingCartClosingError => ResourceProvider.GetString("ShoppingCartClosingError");

        /// <summary>
        /// Short compnay name 
        /// </summary>
		public static string ShortCompanyName => ResourceProvider.GetString("ShortCompanyName");

        /// <summary>
        /// Document 
        /// </summary>
		public static string ShowDocumentLinkName => ResourceProvider.GetString("ShowDocumentLinkName");

        /// <summary>
        /// Dokument 
        /// </summary>
		public static string ShowDocumentPageTitle => ResourceProvider.GetString("ShowDocumentPageTitle");

        /// <summary>
        /// /showdoc 
        /// </summary>
		public static string ShowDocumentUrlPath => ResourceProvider.GetString("ShowDocumentUrlPath");

        /// <summary>
        /// Show Range 
        /// </summary>
		public static string ShowRange => ResourceProvider.GetString("ShowRange");

        /// <summary>
        /// Login To Your Account 
        /// </summary>
		public static string SignInToYourAccount => ResourceProvider.GetString("SignInToYourAccount");

        /// <summary>
        /// Sort Kind 
        /// </summary>
		public static string SortKind => ResourceProvider.GetString("SortKind");

        /// <summary>
        /// Saving failed! Refresh the page. 
        /// </summary>
		public static string SpremanjeNijeUspjeloOsvjeziteStranicu => ResourceProvider.GetString("SpremanjeNijeUspjeloOsvjeziteStranicu");

        /// <summary>
        /// Start Date 
        /// </summary>
		public static string StartDate => ResourceProvider.GetString("StartDate");

        /// <summary>
        /// Start date is out of range 
        /// </summary>
		public static string StartDateIsOutOfRange => ResourceProvider.GetString("StartDateIsOutOfRange");

        /// <summary>
        /// Start Date year has to be greater than 1900 
        /// </summary>
		public static string StartDateYearHasToBeGreaterThan => ResourceProvider.GetString("StartDateYearHasToBeGreaterThan");

        /// <summary>
        /// Start Time 
        /// </summary>
		public static string StartTime => ResourceProvider.GetString("StartTime");

        /// <summary>
        /// Articles statistics 
        /// </summary>
		public static string StatistikaArtikala => ResourceProvider.GetString("StatistikaArtikala");

        /// <summary>
        /// Status 
        /// </summary>
		public static string Status => ResourceProvider.GetString("Status");

        /// <summary>
        /// Status already exists 
        /// </summary>
		public static string StatusAlreadyExists => ResourceProvider.GetString("StatusAlreadyExists");

        /// <summary>
        /// Status has to be selected 
        /// </summary>
		public static string StatusHasToBeSelected => ResourceProvider.GetString("StatusHasToBeSelected");

        /// <summary>
        /// Status Name 
        /// </summary>
		public static string StatusName => ResourceProvider.GetString("StatusName");

        /// <summary>
        /// Status name changed 
        /// </summary>
		public static string StatusNameChanged => ResourceProvider.GetString("StatusNameChanged");

        /// <summary>
        /// Status saved 
        /// </summary>
		public static string StatusSaved => ResourceProvider.GetString("StatusSaved");

        /// <summary>
        /// Status usluga 
        /// </summary>
		public static string StatusUsluga => ResourceProvider.GetString("StatusUsluga");

        /// <summary>
        /// Storno 
        /// </summary>
		public static string Storno => ResourceProvider.GetString("Storno");

        /// <summary>
        /// Storno completed 
        /// </summary>
		public static string StornoCompleted => ResourceProvider.GetString("StornoCompleted");

        /// <summary>
        /// Success, redirecting... 
        /// </summary>
		public static string SuccessRedirecting => ResourceProvider.GetString("SuccessRedirecting");

        /// <summary>
        /// Success, reloading... 
        /// </summary>
		public static string SuccessReloading => ResourceProvider.GetString("SuccessReloading");

        /// <summary>
        /// All categories 
        /// </summary>
		public static string SveKategorije => ResourceProvider.GetString("SveKategorije");

        /// <summary>
        /// All articles 
        /// </summary>
		public static string SviArtikli => ResourceProvider.GetString("SviArtikli");

        /// <summary>
        /// All normatives 
        /// </summary>
		public static string SviNormativi => ResourceProvider.GetString("SviNormativi");

        /// <summary>
        /// Synesis 
        /// </summary>
		public static string SynesisLinkName => ResourceProvider.GetString("SynesisLinkName");

        /// <summary>
        /// Synesis 
        /// </summary>
		public static string SynesisPageTitle => ResourceProvider.GetString("SynesisPageTitle");

        /// <summary>
        /// /synesis 
        /// </summary>
		public static string SynesisUrlPath => ResourceProvider.GetString("SynesisUrlPath");

        /// <summary>
        /// Tax 
        /// </summary>
		public static string Tax => ResourceProvider.GetString("Tax");

        /// <summary>
        /// Telephone number 
        /// </summary>
		public static string TelephoneNumber => ResourceProvider.GetString("TelephoneNumber");

        /// <summary>
        /// Template content 
        /// </summary>
		public static string TemplateContent => ResourceProvider.GetString("TemplateContent");

        /// <summary>
        /// Template kind 
        /// </summary>
		public static string TemplateKind => ResourceProvider.GetString("TemplateKind");

        /// <summary>
        /// Template subject 
        /// </summary>
		public static string TemplateSubject => ResourceProvider.GetString("TemplateSubject");

        /// <summary>
        /// Text log 
        /// </summary>
		public static string TextLog => ResourceProvider.GetString("TextLog");

        /// <summary>
        /// Text in a footer 
        /// </summary>
		public static string TextUFooteruRacunaLabel => ResourceProvider.GetString("TextUFooteruRacunaLabel");

        /// <summary>
        /// This type can't be deleted. It is already used. 
        /// </summary>
		public static string ThisTypeCanNotBeDeleted => ResourceProvider.GetString("ThisTypeCanNotBeDeleted");

        /// <summary>
        /// Time 
        /// </summary>
		public static string Time => ResourceProvider.GetString("Time");

        /// <summary>
        /// dot 
        /// </summary>
		public static string Tocka => ResourceProvider.GetString("Tocka");

        /// <summary>
        /// Tools 
        /// </summary>
		public static string Tools => ResourceProvider.GetString("Tools");

        /// <summary>
        /// Tools 
        /// </summary>
		public static string ToolsLinkName => ResourceProvider.GetString("ToolsLinkName");

        /// <summary>
        /// Tools 
        /// </summary>
		public static string ToolsPageTitle => ResourceProvider.GetString("ToolsPageTitle");

        /// <summary>
        /// /tools 
        /// </summary>
		public static string ToolsUrlPath => ResourceProvider.GetString("ToolsUrlPath");

        /// <summary>
        /// Total 
        /// </summary>
		public static string Total => ResourceProvider.GetString("Total");

        /// <summary>
        /// Total Adverts 
        /// </summary>
		public static string TotalAdverts => ResourceProvider.GetString("TotalAdverts");

        /// <summary>
        /// Total amount 
        /// </summary>
		public static string TotalAmount => ResourceProvider.GetString("TotalAmount");

        /// <summary>
        /// Transactions 
        /// </summary>
		public static string Transactions => ResourceProvider.GetString("Transactions");

        /// <summary>
        /// Transactions 
        /// </summary>
		public static string TransactionsLinkName => ResourceProvider.GetString("TransactionsLinkName");

        /// <summary>
        /// Transactions 
        /// </summary>
		public static string TransactionsPageTitle => ResourceProvider.GetString("TransactionsPageTitle");

        /// <summary>
        /// /transactions 
        /// </summary>
		public static string TransactionsUrlPath => ResourceProvider.GetString("TransactionsUrlPath");

        /// <summary>
        /// Type 
        /// </summary>
		public static string Type => ResourceProvider.GetString("Type");

        /// <summary>
        /// To shopping cart 
        /// </summary>
		public static string UKosaricu => ResourceProvider.GetString("UKosaricu");

        /// <summary>
        /// Ulica 
        /// </summary>
		public static string Ulica => ResourceProvider.GetString("Ulica");

        /// <summary>
        /// Unit 
        /// </summary>
		public static string Unit => ResourceProvider.GetString("Unit");

        /// <summary>
        /// Update view status 
        /// </summary>
		public static string UpdateViewStatus => ResourceProvider.GetString("UpdateViewStatus");

        /// <summary>
        /// Uredi poreznu grupu 
        /// </summary>
		public static string UrediPoreznuGrupu => ResourceProvider.GetString("UrediPoreznuGrupu");

        /// <summary>
        /// Edit item 
        /// </summary>
		public static string UrediStavku => ResourceProvider.GetString("UrediStavku");

        /// <summary>
        /// Category can not be edited! 
        /// </summary>
		public static string UredjivanjeOdabraneKategorijeNijeMoguce => ResourceProvider.GetString("UredjivanjeOdabraneKategorijeNijeMoguce");

        /// <summary>
        /// Edit service 
        /// </summary>
		public static string UredjivanjeUsluge => ResourceProvider.GetString("UredjivanjeUsluge");

        /// <summary>
        /// Use predefined schedules 
        /// </summary>
		public static string UsePredefinedSchedules => ResourceProvider.GetString("UsePredefinedSchedules");

        /// <summary>
        /// Username 
        /// </summary>
		public static string Username => ResourceProvider.GetString("Username");

        /// <summary>
        /// Username is required 
        /// </summary>
		public static string UsernameIsRequired => ResourceProvider.GetString("UsernameIsRequired");

        /// <summary>
        /// Completed successfuly 
        /// </summary>
		public static string UspjesnoZavrseno => ResourceProvider.GetString("UspjesnoZavrseno");

        /// <summary>
        /// POS income 
        /// </summary>
		public static string UtrzakBlagajne => ResourceProvider.GetString("UtrzakBlagajne");

        /// <summary>
        /// VariantID 
        /// </summary>
		public static string VariantID => ResourceProvider.GetString("VariantID");

        /// <summary>
        /// Wholesale (VPC) 
        /// </summary>
		public static string VeleprodajnaVPC => ResourceProvider.GetString("VeleprodajnaVPC");

        /// <summary>
        /// Verify integrity 
        /// </summary>
		public static string VerifyIntegrity => ResourceProvider.GetString("VerifyIntegrity");

        /// <summary>
        /// Visible at POS 
        /// </summary>
		public static string VisibleAtPOS => ResourceProvider.GetString("VisibleAtPOS");

        /// <summary>
        /// VPC 
        /// </summary>
		public static string VPC => ResourceProvider.GetString("VPC");

        /// <summary>
        /// Web Site 
        /// </summary>
		public static string WebSite => ResourceProvider.GetString("WebSite");

        /// <summary>
        /// Working, please wait 
        /// </summary>
		public static string WorkingPleaseWait => ResourceProvider.GetString("WorkingPleaseWait");

        /// <summary>
        /// Working time 
        /// </summary>
		public static string WorkingTime => ResourceProvider.GetString("WorkingTime");

        /// <summary>
        /// Yes 
        /// </summary>
		public static string Yes => ResourceProvider.GetString("Yes");

        /// <summary>
        /// You have no access rights 
        /// </summary>
		public static string YouHaveNoAccessRight => ResourceProvider.GetString("YouHaveNoAccessRight");

        /// <summary>
        /// Completed 
        /// </summary>
		public static string Zakljuceno => ResourceProvider.GetString("Zakljuceno");

        /// <summary>
        /// Complete 
        /// </summary>
		public static string Zakljuci => ResourceProvider.GetString("Zakljuci");

        /// <summary>
        /// Ordered 
        /// </summary>
		public static string Zakupljeno => ResourceProvider.GetString("Zakupljeno");

        /// <summary>
        /// comma 
        /// </summary>
		public static string Zarez => ResourceProvider.GetString("Zarez");

        /// <summary>
        /// Do you really want to create cancellation bill with the current date and time? 
        /// </summary>
		public static string ZeliteLiZaistaKreiratiStornoSaSadasnjimDatumomIVremenom => ResourceProvider.GetString("ZeliteLiZaistaKreiratiStornoSaSadasnjimDatumomIVremenom");

        /// <summary>
        /// Do you really want to create a cancellation bill? 
        /// </summary>
		public static string ZeliteLiZasitaKreiratiStornoRacun => ResourceProvider.GetString("ZeliteLiZasitaKreiratiStornoRacun");

        /// <summary>
        /// Do you really want to create a cancellation with the date of the last bill? 
        /// </summary>
		public static string ZeliteLiZasitaKreiratiStornoSaDatumomZadnjegRacuna => ResourceProvider.GetString("ZeliteLiZasitaKreiratiStornoSaDatumomZadnjegRacuna");

	}
}
