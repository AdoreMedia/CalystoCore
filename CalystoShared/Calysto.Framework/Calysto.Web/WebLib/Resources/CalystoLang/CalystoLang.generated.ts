namespace Calysto.Resources
{
	const _columns = [ "property", "en-US", "hr-HR", "sr-RS", "it-IT" ];

	const _json = {"__calystotype":"Calysto_DataTable","TotalCount":null,"TableName":"","Columns":["property","en-US","hr-HR","sr-RS","it-IT"],"Rows":[["Cancel","Cancel","Otkaži","Otkaži","Annulla"],["Close","Close","Zatvori","Zatvori","Vicino"],["Day","Day","Dan","Dan","Giorno"],["Error","Error","Greška","Greška","Errore"],["Information","Information","Informacija","Informacija","Informazione"],["JavascriptEngineIsOutdatedInformation","New version of this page found!\nPlease click:\n    - Reload to reload page and new engine\n    - Cancel to keep the current page","Pronađena je novija verzija stranice.\nKliknite:\n    - Osvježi za osvježavanje i dohvat nove verzije\n    - Otkaži za zadržavanje na trenutnoj verziji","Pronađena je novija verzija stranice.\nKliknite:\n    - Osveži za osvežavanje i dohvat nove verzije\n    - Otkaži za zadržavanje na trenutnoj verziji","Nuova versione di questa pagina trovata!\nFare clic su:\n     - Ricarica per ricaricare la pagina e il nuovo motore\n     - Annulla per mantenere la pagina corrente "],["Message","Message","Poruka","Poruka","Messaggio"],["Month","Month","Mjesec","Mesec","Mese"],["NewVersionFoundPageIsReloading","New version found, page is reloading...","Pronađena je novija verzija, stranica se osvježava...","Pronađena je novija verzija, stranica se osvežava...","Nuova versione trovati, pagina sta caricando ..."],["No","No","Ne","Ne","No"],["OK","OK","U redu","U redu","Bene"],["Open","Open","Otvori","Otvori","Aperto"],["PageIsReloadingPleaseWait","Please wait, page is reloading...","Molimo pričekajte, stranica se osvježava...","Molimo pričekajte, stranica se osvežava...","Si prega di attendere, la pagina sta caricando ..."],["PleaseConfirm","Please confirm","Molimo potvrdite","Molimo potvrdite","Si prega di confermare"],["Question","Question","Pitanje","Pitanje","Domanda"],["Reload","Reload","Osvježi","Osveži","Ricaricare"],["Save","Save","Spremi","Spremi","Salva"],["Success","Success","Uspješno","Uspešno","Successo"],["Today","Today","Danas","Danas","Oggi"],["Warning","Warning","Upozorenje","Upozorenje","avvertimento"],["Week","Week","Tjedan","Tjedan","Settimana"],["Year","Year","Godina","Godina","Anno"],["Yes","Yes","Da","Da","Sì"],["MethodInvocationFobidden","Invocation forbidden","Nemate dozvolu za ovu akciju","Nemate dozvolu za ovu akciju","Invocazione proibito"],["File","File","Datoteka","Datoteka","File"],["Edit","Edit","Uredi","Uredi","Modificare"],["Delete","Delete","Obriši","Obriši","Elimina"],["AreYouSure","Are you sure?","Jeste li sigurni?","Jeste li sigurni?","Sei sicuro?"]]};

	export interface CalystoLang { }

    export class CalystoLang
	{
		public static readonly ResourceProvider = Calysto.Globalization.ResxExcelProvider.FromJson(_json);

		
		/** Jeste li sigurni? */
		public static get AreYouSure() { return CalystoLang.ResourceProvider.GetString("AreYouSure") }

		/** Otkaži */
		public static get Cancel() { return CalystoLang.ResourceProvider.GetString("Cancel") }

		/** Zatvori */
		public static get Close() { return CalystoLang.ResourceProvider.GetString("Close") }

		/** Dan */
		public static get Day() { return CalystoLang.ResourceProvider.GetString("Day") }

		/** Obriši */
		public static get Delete() { return CalystoLang.ResourceProvider.GetString("Delete") }

		/** Uredi */
		public static get Edit() { return CalystoLang.ResourceProvider.GetString("Edit") }

		/** Greška */
		public static get Error() { return CalystoLang.ResourceProvider.GetString("Error") }

		/** Datoteka */
		public static get File() { return CalystoLang.ResourceProvider.GetString("File") }

		/** Informacija */
		public static get Information() { return CalystoLang.ResourceProvider.GetString("Information") }

		/** Pronađena je novija verzija stranice.
Kliknite:
- Osvježi za osvježavanje i dohvat nove verzije
- Otkaži za zadržavanje na trenutnoj verziji */
		public static get JavascriptEngineIsOutdatedInformation() { return CalystoLang.ResourceProvider.GetString("JavascriptEngineIsOutdatedInformation") }

		/** Poruka */
		public static get Message() { return CalystoLang.ResourceProvider.GetString("Message") }

		/** Nemate dozvolu za ovu akciju */
		public static get MethodInvocationFobidden() { return CalystoLang.ResourceProvider.GetString("MethodInvocationFobidden") }

		/** Mjesec */
		public static get Month() { return CalystoLang.ResourceProvider.GetString("Month") }

		/** Pronađena je novija verzija, stranica se osvježava... */
		public static get NewVersionFoundPageIsReloading() { return CalystoLang.ResourceProvider.GetString("NewVersionFoundPageIsReloading") }

		/** Ne */
		public static get No() { return CalystoLang.ResourceProvider.GetString("No") }

		/** U redu */
		public static get OK() { return CalystoLang.ResourceProvider.GetString("OK") }

		/** Otvori */
		public static get Open() { return CalystoLang.ResourceProvider.GetString("Open") }

		/** Molimo pričekajte, stranica se osvježava... */
		public static get PageIsReloadingPleaseWait() { return CalystoLang.ResourceProvider.GetString("PageIsReloadingPleaseWait") }

		/** Molimo potvrdite */
		public static get PleaseConfirm() { return CalystoLang.ResourceProvider.GetString("PleaseConfirm") }

		/** Pitanje */
		public static get Question() { return CalystoLang.ResourceProvider.GetString("Question") }

		/** Osvježi */
		public static get Reload() { return CalystoLang.ResourceProvider.GetString("Reload") }

		/** Spremi */
		public static get Save() { return CalystoLang.ResourceProvider.GetString("Save") }

		/** Uspješno */
		public static get Success() { return CalystoLang.ResourceProvider.GetString("Success") }

		/** Danas */
		public static get Today() { return CalystoLang.ResourceProvider.GetString("Today") }

		/** Upozorenje */
		public static get Warning() { return CalystoLang.ResourceProvider.GetString("Warning") }

		/** Tjedan */
		public static get Week() { return CalystoLang.ResourceProvider.GetString("Week") }

		/** Godina */
		public static get Year() { return CalystoLang.ResourceProvider.GetString("Year") }

		/** Da */
		public static get Yes() { return CalystoLang.ResourceProvider.GetString("Yes") }

	}
}
