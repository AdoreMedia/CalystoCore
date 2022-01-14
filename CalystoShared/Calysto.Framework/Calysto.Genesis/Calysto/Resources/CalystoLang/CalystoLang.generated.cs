using Calysto.Globalization;

namespace Calysto.Resources
{
    public class CalystoLang : ICalystoResx
    {
		private CalystoLang(){ }

		static string[] _columns = new string[] { "property", "en-US", "hr-HR", "sr-RS", "it-IT" };

		const string _json = "{\"__calystotype\":\"Calysto_DataTable\",\"TotalCount\":null,\"TableName\":\"\",\"Columns\":[\"property\",\"en-US\",\"hr-HR\",\"sr-RS\",\"it-IT\"],\"Rows\":[[\"Cancel\",\"Cancel\",\"Otkaži\",\"Otkaži\",\"Annulla\"],[\"Close\",\"Close\",\"Zatvori\",\"Zatvori\",\"Vicino\"],[\"Day\",\"Day\",\"Dan\",\"Dan\",\"Giorno\"],[\"Error\",\"Error\",\"Greška\",\"Greška\",\"Errore\"],[\"Information\",\"Information\",\"Informacija\",\"Informacija\",\"Informazione\"],[\"JavascriptEngineIsOutdatedInformation\",\"New version of this page found!\\nPlease click:\\n    - Reload to reload page and new engine\\n    - Cancel to keep the current page\",\"Pronađena je novija verzija stranice.\\nKliknite:\\n    - Osvježi za osvježavanje i dohvat nove verzije\\n    - Otkaži za zadržavanje na trenutnoj verziji\",\"Pronađena je novija verzija stranice.\\nKliknite:\\n    - Osveži za osvežavanje i dohvat nove verzije\\n    - Otkaži za zadržavanje na trenutnoj verziji\",\"Nuova versione di questa pagina trovata!\\nFare clic su:\\n     - Ricarica per ricaricare la pagina e il nuovo motore\\n     - Annulla per mantenere la pagina corrente \"],[\"Message\",\"Message\",\"Poruka\",\"Poruka\",\"Messaggio\"],[\"Month\",\"Month\",\"Mjesec\",\"Mesec\",\"Mese\"],[\"NewVersionFoundPageIsReloading\",\"New version found, page is reloading...\",\"Pronađena je novija verzija, stranica se osvježava...\",\"Pronađena je novija verzija, stranica se osvežava...\",\"Nuova versione trovati, pagina sta caricando ...\"],[\"No\",\"No\",\"Ne\",\"Ne\",\"No\"],[\"OK\",\"OK\",\"U redu\",\"U redu\",\"Bene\"],[\"Open\",\"Open\",\"Otvori\",\"Otvori\",\"Aperto\"],[\"PageIsReloadingPleaseWait\",\"Please wait, page is reloading...\",\"Molimo pričekajte, stranica se osvježava...\",\"Molimo pričekajte, stranica se osvežava...\",\"Si prega di attendere, la pagina sta caricando ...\"],[\"PleaseConfirm\",\"Please confirm\",\"Molimo potvrdite\",\"Molimo potvrdite\",\"Si prega di confermare\"],[\"Question\",\"Question\",\"Pitanje\",\"Pitanje\",\"Domanda\"],[\"Reload\",\"Reload\",\"Osvježi\",\"Osveži\",\"Ricaricare\"],[\"Save\",\"Save\",\"Spremi\",\"Spremi\",\"Salva\"],[\"Success\",\"Success\",\"Uspješno\",\"Uspešno\",\"Successo\"],[\"Today\",\"Today\",\"Danas\",\"Danas\",\"Oggi\"],[\"Warning\",\"Warning\",\"Upozorenje\",\"Upozorenje\",\"avvertimento\"],[\"Week\",\"Week\",\"Tjedan\",\"Tjedan\",\"Settimana\"],[\"Year\",\"Year\",\"Godina\",\"Godina\",\"Anno\"],[\"Yes\",\"Yes\",\"Da\",\"Da\",\"Sì\"],[\"MethodInvocationFobidden\",\"Invocation forbidden\",\"Nemate dozvolu za ovu akciju\",\"Nemate dozvolu za ovu akciju\",\"Invocazione proibito\"],[\"File\",\"File\",\"Datoteka\",\"Datoteka\",\"File\"],[\"Edit\",\"Edit\",\"Uredi\",\"Uredi\",\"Modificare\"],[\"Delete\",\"Delete\",\"Obriši\",\"Obriši\",\"Elimina\"],[\"AreYouSure\",\"Are you sure?\",\"Jeste li sigurni?\",\"Jeste li sigurni?\",\"Sei sicuro?\"]]}";

        public static readonly ResxExcelProvider ResourceProvider = ResxExcelProvider.FromJson<ResxExcelProvider>(_json);


        /// <summary>
        /// Jeste li sigurni? 
        /// </summary>
		public static string AreYouSure => ResourceProvider.GetString("AreYouSure");

        /// <summary>
        /// Otkaži 
        /// </summary>
		public static string Cancel => ResourceProvider.GetString("Cancel");

        /// <summary>
        /// Zatvori 
        /// </summary>
		public static string Close => ResourceProvider.GetString("Close");

        /// <summary>
        /// Dan 
        /// </summary>
		public static string Day => ResourceProvider.GetString("Day");

        /// <summary>
        /// Obriši 
        /// </summary>
		public static string Delete => ResourceProvider.GetString("Delete");

        /// <summary>
        /// Uredi 
        /// </summary>
		public static string Edit => ResourceProvider.GetString("Edit");

        /// <summary>
        /// Greška 
        /// </summary>
		public static string Error => ResourceProvider.GetString("Error");

        /// <summary>
        /// Datoteka 
        /// </summary>
		public static string File => ResourceProvider.GetString("File");

        /// <summary>
        /// Informacija 
        /// </summary>
		public static string Information => ResourceProvider.GetString("Information");

        /// <summary>
        /// Pronađena je novija verzija stranice.<br/>
        /// Kliknite:<br/>
        /// - Osvježi za osvježavanje i dohvat nove verzije<br/>
        /// - Otkaži za zadržavanje na trenutnoj verziji 
        /// </summary>
		public static string JavascriptEngineIsOutdatedInformation => ResourceProvider.GetString("JavascriptEngineIsOutdatedInformation");

        /// <summary>
        /// Poruka 
        /// </summary>
		public static string Message => ResourceProvider.GetString("Message");

        /// <summary>
        /// Nemate dozvolu za ovu akciju 
        /// </summary>
		public static string MethodInvocationFobidden => ResourceProvider.GetString("MethodInvocationFobidden");

        /// <summary>
        /// Mjesec 
        /// </summary>
		public static string Month => ResourceProvider.GetString("Month");

        /// <summary>
        /// Pronađena je novija verzija, stranica se osvježava... 
        /// </summary>
		public static string NewVersionFoundPageIsReloading => ResourceProvider.GetString("NewVersionFoundPageIsReloading");

        /// <summary>
        /// Ne 
        /// </summary>
		public static string No => ResourceProvider.GetString("No");

        /// <summary>
        /// U redu 
        /// </summary>
		public static string OK => ResourceProvider.GetString("OK");

        /// <summary>
        /// Otvori 
        /// </summary>
		public static string Open => ResourceProvider.GetString("Open");

        /// <summary>
        /// Molimo pričekajte, stranica se osvježava... 
        /// </summary>
		public static string PageIsReloadingPleaseWait => ResourceProvider.GetString("PageIsReloadingPleaseWait");

        /// <summary>
        /// Molimo potvrdite 
        /// </summary>
		public static string PleaseConfirm => ResourceProvider.GetString("PleaseConfirm");

        /// <summary>
        /// Pitanje 
        /// </summary>
		public static string Question => ResourceProvider.GetString("Question");

        /// <summary>
        /// Osvježi 
        /// </summary>
		public static string Reload => ResourceProvider.GetString("Reload");

        /// <summary>
        /// Spremi 
        /// </summary>
		public static string Save => ResourceProvider.GetString("Save");

        /// <summary>
        /// Uspješno 
        /// </summary>
		public static string Success => ResourceProvider.GetString("Success");

        /// <summary>
        /// Danas 
        /// </summary>
		public static string Today => ResourceProvider.GetString("Today");

        /// <summary>
        /// Upozorenje 
        /// </summary>
		public static string Warning => ResourceProvider.GetString("Warning");

        /// <summary>
        /// Tjedan 
        /// </summary>
		public static string Week => ResourceProvider.GetString("Week");

        /// <summary>
        /// Godina 
        /// </summary>
		public static string Year => ResourceProvider.GetString("Year");

        /// <summary>
        /// Da 
        /// </summary>
		public static string Yes => ResourceProvider.GetString("Yes");

	}
}
