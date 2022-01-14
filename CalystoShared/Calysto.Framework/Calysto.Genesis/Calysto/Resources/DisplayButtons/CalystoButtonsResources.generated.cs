using Calysto.Globalization;

namespace Calysto.Resources
{
    public class CalystoButtonsResources : ICalystoResx
    {
		private CalystoButtonsResources(){ }

		static string[] _columns = new string[] { "property", "en-US", "hr-HR", "sr-RS", "it-IT" };

		const string _json = "{\"__calystotype\":\"Calysto_DataTable\",\"TotalCount\":null,\"TableName\":\"\",\"Columns\":[\"property\",\"en-US\",\"hr-HR\",\"sr-RS\",\"it-IT\"],\"Rows\":[[\"Yes\",\"Yes\",\"Da\",\"Da\",\"Sì\"],[\"No\",\"No\",\"Ne\",\"Ne\",\"No\"],[\"Cancel\",\"Cancel\",\"Otkaži\",\"Otkaži\",\"Annulla\"],[\"OK\",\"OK\",\"OK\",\"OK\",\"Bene\"],[\"Submit\",\"Submit\",\"Pošalji\",\"Pošalji\",\"Invia\"],[\"Clear\",\"Clear\",\"Očisti\",\"Očisti\",\"Chiaro\"],[\"Save\",\"Save\",\"Spremi\",\"Spremi\",\"Salva\"],[\"Select\",\"Select\",\"Odaberi\",\"Odaberi\",\"Selezionare\"],[\"Delete\",\"Delete\",\"Obriši\",\"Obriši\",\"Elimina\"]]}";

        public static readonly ResxExcelProvider ResourceProvider = ResxExcelProvider.FromJson<ResxExcelProvider>(_json);


        /// <summary>
        /// Otkaži 
        /// </summary>
		public static string Cancel => ResourceProvider.GetString("Cancel");

        /// <summary>
        /// Očisti 
        /// </summary>
		public static string Clear => ResourceProvider.GetString("Clear");

        /// <summary>
        /// Obriši 
        /// </summary>
		public static string Delete => ResourceProvider.GetString("Delete");

        /// <summary>
        /// Ne 
        /// </summary>
		public static string No => ResourceProvider.GetString("No");

        /// <summary>
        /// OK 
        /// </summary>
		public static string OK => ResourceProvider.GetString("OK");

        /// <summary>
        /// Spremi 
        /// </summary>
		public static string Save => ResourceProvider.GetString("Save");

        /// <summary>
        /// Odaberi 
        /// </summary>
		public static string Select => ResourceProvider.GetString("Select");

        /// <summary>
        /// Pošalji 
        /// </summary>
		public static string Submit => ResourceProvider.GetString("Submit");

        /// <summary>
        /// Da 
        /// </summary>
		public static string Yes => ResourceProvider.GetString("Yes");

	}
}
