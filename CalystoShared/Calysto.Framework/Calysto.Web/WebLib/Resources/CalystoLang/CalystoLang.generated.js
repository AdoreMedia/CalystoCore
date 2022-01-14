var Calysto;
(function (Calysto) {
    var Resources;
    (function (Resources) {
        var _columns = ["property", "en-US", "hr-HR", "sr-RS", "it-IT"];
        var _json = { "__calystotype": "Calysto_DataTable", "TotalCount": null, "TableName": "", "Columns": ["property", "en-US", "hr-HR", "sr-RS", "it-IT"], "Rows": [["Cancel", "Cancel", "Otkaži", "Otkaži", "Annulla"], ["Close", "Close", "Zatvori", "Zatvori", "Vicino"], ["Day", "Day", "Dan", "Dan", "Giorno"], ["Error", "Error", "Greška", "Greška", "Errore"], ["Information", "Information", "Informacija", "Informacija", "Informazione"], ["JavascriptEngineIsOutdatedInformation", "New version of this page found!\nPlease click:\n    - Reload to reload page and new engine\n    - Cancel to keep the current page", "Pronađena je novija verzija stranice.\nKliknite:\n    - Osvježi za osvježavanje i dohvat nove verzije\n    - Otkaži za zadržavanje na trenutnoj verziji", "Pronađena je novija verzija stranice.\nKliknite:\n    - Osveži za osvežavanje i dohvat nove verzije\n    - Otkaži za zadržavanje na trenutnoj verziji", "Nuova versione di questa pagina trovata!\nFare clic su:\n     - Ricarica per ricaricare la pagina e il nuovo motore\n     - Annulla per mantenere la pagina corrente "], ["Message", "Message", "Poruka", "Poruka", "Messaggio"], ["Month", "Month", "Mjesec", "Mesec", "Mese"], ["NewVersionFoundPageIsReloading", "New version found, page is reloading...", "Pronađena je novija verzija, stranica se osvježava...", "Pronađena je novija verzija, stranica se osvežava...", "Nuova versione trovati, pagina sta caricando ..."], ["No", "No", "Ne", "Ne", "No"], ["OK", "OK", "U redu", "U redu", "Bene"], ["Open", "Open", "Otvori", "Otvori", "Aperto"], ["PageIsReloadingPleaseWait", "Please wait, page is reloading...", "Molimo pričekajte, stranica se osvježava...", "Molimo pričekajte, stranica se osvežava...", "Si prega di attendere, la pagina sta caricando ..."], ["PleaseConfirm", "Please confirm", "Molimo potvrdite", "Molimo potvrdite", "Si prega di confermare"], ["Question", "Question", "Pitanje", "Pitanje", "Domanda"], ["Reload", "Reload", "Osvježi", "Osveži", "Ricaricare"], ["Save", "Save", "Spremi", "Spremi", "Salva"], ["Success", "Success", "Uspješno", "Uspešno", "Successo"], ["Today", "Today", "Danas", "Danas", "Oggi"], ["Warning", "Warning", "Upozorenje", "Upozorenje", "avvertimento"], ["Week", "Week", "Tjedan", "Tjedan", "Settimana"], ["Year", "Year", "Godina", "Godina", "Anno"], ["Yes", "Yes", "Da", "Da", "Sì"], ["MethodInvocationFobidden", "Invocation forbidden", "Nemate dozvolu za ovu akciju", "Nemate dozvolu za ovu akciju", "Invocazione proibito"], ["File", "File", "Datoteka", "Datoteka", "File"], ["Edit", "Edit", "Uredi", "Uredi", "Modificare"], ["Delete", "Delete", "Obriši", "Obriši", "Elimina"], ["AreYouSure", "Are you sure?", "Jeste li sigurni?", "Jeste li sigurni?", "Sei sicuro?"]] };
        var CalystoLang = /** @class */ (function () {
            function CalystoLang() {
            }
            Object.defineProperty(CalystoLang, "AreYouSure", {
                /** Jeste li sigurni? */
                get: function () { return CalystoLang.ResourceProvider.GetString("AreYouSure"); },
                enumerable: false,
                configurable: true
            });
            Object.defineProperty(CalystoLang, "Cancel", {
                /** Otkaži */
                get: function () { return CalystoLang.ResourceProvider.GetString("Cancel"); },
                enumerable: false,
                configurable: true
            });
            Object.defineProperty(CalystoLang, "Close", {
                /** Zatvori */
                get: function () { return CalystoLang.ResourceProvider.GetString("Close"); },
                enumerable: false,
                configurable: true
            });
            Object.defineProperty(CalystoLang, "Day", {
                /** Dan */
                get: function () { return CalystoLang.ResourceProvider.GetString("Day"); },
                enumerable: false,
                configurable: true
            });
            Object.defineProperty(CalystoLang, "Delete", {
                /** Obriši */
                get: function () { return CalystoLang.ResourceProvider.GetString("Delete"); },
                enumerable: false,
                configurable: true
            });
            Object.defineProperty(CalystoLang, "Edit", {
                /** Uredi */
                get: function () { return CalystoLang.ResourceProvider.GetString("Edit"); },
                enumerable: false,
                configurable: true
            });
            Object.defineProperty(CalystoLang, "Error", {
                /** Greška */
                get: function () { return CalystoLang.ResourceProvider.GetString("Error"); },
                enumerable: false,
                configurable: true
            });
            Object.defineProperty(CalystoLang, "File", {
                /** Datoteka */
                get: function () { return CalystoLang.ResourceProvider.GetString("File"); },
                enumerable: false,
                configurable: true
            });
            Object.defineProperty(CalystoLang, "Information", {
                /** Informacija */
                get: function () { return CalystoLang.ResourceProvider.GetString("Information"); },
                enumerable: false,
                configurable: true
            });
            Object.defineProperty(CalystoLang, "JavascriptEngineIsOutdatedInformation", {
                /** Pronađena je novija verzija stranice.
        Kliknite:
        - Osvježi za osvježavanje i dohvat nove verzije
        - Otkaži za zadržavanje na trenutnoj verziji */
                get: function () { return CalystoLang.ResourceProvider.GetString("JavascriptEngineIsOutdatedInformation"); },
                enumerable: false,
                configurable: true
            });
            Object.defineProperty(CalystoLang, "Message", {
                /** Poruka */
                get: function () { return CalystoLang.ResourceProvider.GetString("Message"); },
                enumerable: false,
                configurable: true
            });
            Object.defineProperty(CalystoLang, "MethodInvocationFobidden", {
                /** Nemate dozvolu za ovu akciju */
                get: function () { return CalystoLang.ResourceProvider.GetString("MethodInvocationFobidden"); },
                enumerable: false,
                configurable: true
            });
            Object.defineProperty(CalystoLang, "Month", {
                /** Mjesec */
                get: function () { return CalystoLang.ResourceProvider.GetString("Month"); },
                enumerable: false,
                configurable: true
            });
            Object.defineProperty(CalystoLang, "NewVersionFoundPageIsReloading", {
                /** Pronađena je novija verzija, stranica se osvježava... */
                get: function () { return CalystoLang.ResourceProvider.GetString("NewVersionFoundPageIsReloading"); },
                enumerable: false,
                configurable: true
            });
            Object.defineProperty(CalystoLang, "No", {
                /** Ne */
                get: function () { return CalystoLang.ResourceProvider.GetString("No"); },
                enumerable: false,
                configurable: true
            });
            Object.defineProperty(CalystoLang, "OK", {
                /** U redu */
                get: function () { return CalystoLang.ResourceProvider.GetString("OK"); },
                enumerable: false,
                configurable: true
            });
            Object.defineProperty(CalystoLang, "Open", {
                /** Otvori */
                get: function () { return CalystoLang.ResourceProvider.GetString("Open"); },
                enumerable: false,
                configurable: true
            });
            Object.defineProperty(CalystoLang, "PageIsReloadingPleaseWait", {
                /** Molimo pričekajte, stranica se osvježava... */
                get: function () { return CalystoLang.ResourceProvider.GetString("PageIsReloadingPleaseWait"); },
                enumerable: false,
                configurable: true
            });
            Object.defineProperty(CalystoLang, "PleaseConfirm", {
                /** Molimo potvrdite */
                get: function () { return CalystoLang.ResourceProvider.GetString("PleaseConfirm"); },
                enumerable: false,
                configurable: true
            });
            Object.defineProperty(CalystoLang, "Question", {
                /** Pitanje */
                get: function () { return CalystoLang.ResourceProvider.GetString("Question"); },
                enumerable: false,
                configurable: true
            });
            Object.defineProperty(CalystoLang, "Reload", {
                /** Osvježi */
                get: function () { return CalystoLang.ResourceProvider.GetString("Reload"); },
                enumerable: false,
                configurable: true
            });
            Object.defineProperty(CalystoLang, "Save", {
                /** Spremi */
                get: function () { return CalystoLang.ResourceProvider.GetString("Save"); },
                enumerable: false,
                configurable: true
            });
            Object.defineProperty(CalystoLang, "Success", {
                /** Uspješno */
                get: function () { return CalystoLang.ResourceProvider.GetString("Success"); },
                enumerable: false,
                configurable: true
            });
            Object.defineProperty(CalystoLang, "Today", {
                /** Danas */
                get: function () { return CalystoLang.ResourceProvider.GetString("Today"); },
                enumerable: false,
                configurable: true
            });
            Object.defineProperty(CalystoLang, "Warning", {
                /** Upozorenje */
                get: function () { return CalystoLang.ResourceProvider.GetString("Warning"); },
                enumerable: false,
                configurable: true
            });
            Object.defineProperty(CalystoLang, "Week", {
                /** Tjedan */
                get: function () { return CalystoLang.ResourceProvider.GetString("Week"); },
                enumerable: false,
                configurable: true
            });
            Object.defineProperty(CalystoLang, "Year", {
                /** Godina */
                get: function () { return CalystoLang.ResourceProvider.GetString("Year"); },
                enumerable: false,
                configurable: true
            });
            Object.defineProperty(CalystoLang, "Yes", {
                /** Da */
                get: function () { return CalystoLang.ResourceProvider.GetString("Yes"); },
                enumerable: false,
                configurable: true
            });
            CalystoLang.ResourceProvider = Calysto.Globalization.ResxExcelProvider.FromJson(_json);
            return CalystoLang;
        }());
        Resources.CalystoLang = CalystoLang;
    })(Resources = Calysto.Resources || (Calysto.Resources = {}));
})(Calysto || (Calysto = {}));
//# sourceMappingURL=CalystoLang.generated.js.map