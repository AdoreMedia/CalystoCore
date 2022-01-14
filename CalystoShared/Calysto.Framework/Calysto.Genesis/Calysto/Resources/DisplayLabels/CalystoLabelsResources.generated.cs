using Calysto.Globalization;

namespace Calysto.Resources
{
    public class CalystoLabelsResources : ICalystoResx
    {
		private CalystoLabelsResources(){ }

		static string[] _columns = new string[] { "property", "en-US", "hr-HR", "sr-RS", "it-IT" };

		const string _json = "{\"__calystotype\":\"Calysto_DataTable\",\"TotalCount\":null,\"TableName\":\"\",\"Columns\":[\"property\",\"en-US\",\"hr-HR\",\"sr-RS\",\"it-IT\"],\"Rows\":[[\"Username_Label\",\"Username\",\"Korisničko ime\",\"Korisničko ime\",\"Nome utente\"],[\"Username_Prompt\",\"Enter username\",\"Unesite korisničko ime\",\"Unesite korisničko ime\",\"Inserire username\"],[\"Password_Label\",\"Password\",\"Lozinka\",\"Lozinka\",\"Parola d\\u0027ordine\"],[\"Password_Prompt\",\"Enter password\",\"Unesite lozinku\",\"Unesite lozinku\",\"Inserire la password\"],[\"Email_Label\",\"E-mail address\",\"E-mail adresa\",\"E-mail adresa\",\"Indirizzo e-mail\"],[\"Email_Prompt\",\"Enter email address\",\"Unesite e-mail adresu\",\"Unesite e-mail adresu\",\"Inserisci l\\u0027indirizzo email\"],[\"FirstName_Label\",\"First name\",\"Ime\",\"Ime\",\"nome di battesimo\"],[\"FirstName_Prompt\",\"Enter first name\",\"Unesite ime\",\"Unesite ime\",\"Inserire il nome\"],[\"LastName_Label\",\"Last name\",\"Prezime\",\"Prezime\",\"Cognome\"],[\"LastName_Prompt\",\"Enter last name\",\"Unesite prezime\",\"Unesite prezime\",\"Digitare il cognome\"],[\"PhoneNumber_Label\",\"Phone number\",\"Telefonski broj\",\"Telefonski broj\",\"Numero di telefono\"],[\"PhoneNumber_Prompt\",\"Enter phone number\",\"Unesite telefonski broj\",\"Unesite telefonski broj\",\"Inserisci il numero di telefono\"],[\"BirthDate_Label\",\"Birth date\",\"Datum rođenja\",\"Datum rođenja\",\"Data di nascita\"],[\"BirthDate_Prompt\",\"Enter birth date\",\"Unesite datum rođenja\",\"Unesite datum rođenja\",\"Inserisci la data di nascita\"],[\"Address_Label\",\"Address\",\"Adresa\",\"Adresa\",\"Indirizzo\"],[\"Address_Prompt\",\"Enter the address\",\"Unesite adresu\",\"Unesite adresu\",\"Inserire l\\u0027indirizzo\"],[\"City_Label\",\"City\",\"Grad\",\"Grad\",\"Città\"],[\"City_Prompt\",\"Enter the city\",\"Unesite grad\",\"Unesite grad\",\"Inserisci la città\"],[\"StreetName_Label\",\"Street name\",\"Ulica\",\"Ulica\",\"nome della via\"],[\"StreetName_Prompt\",\"Enter the street name\",\"Unesite ulicu\",\"Unesite ulicu\",\"Inserire il nome della via\"],[\"ZipCode_Label\",\"Zip code\",\"Poštanski broj\",\"Poštanski broj\",\"Cap\"],[\"ZipCode_Prompt\",\"Enter the zip code\",\"Unesite poštanski broj\",\"Unesite poštanski broj\",\"Inserisci il codice di avviamento postale\"],[\"FullName_Label\",\"Full name\",\"Puni naziv\",\"Puni naziv\",\"Nome e cognome\"],[\"FullName_Prompt\",\"Enter full name\",\"Unesite puni naziv\",\"Unesite puni naziv\",\"Inserire il nome completo\"],[\"Subject_Label\",\"Subject\",\"Naslov\",\"Naslov\",\"Soggetto\"],[\"Subject_Prompt\",\"Enter subject\",\"Unesite naslov\",\"Unesite naslov\",\"Inserisci soggetto\"],[\"MobilePhone_Label\",\"Mobile phone number\",\"Broj mobitela\",\"Broj mobitela\",\"Numero di cellulare\"],[\"MobilePhone_Prompt\",\"Enter mobile phone number\",\"Unesite broj mobitela\",\"Unesite broj mobitela\",\"Inserire il numero di cellulare\"],[\"CompanyPorezniBroj_Label\",\"Company tax number\",\"OIB tvrtke\",\"PIB kompanije\",\"Codice fiscale dell\\u0027azienda\"],[\"CompanyPorezniBroj_Prompt\",\"Enter company tax number\",\"Unesite OIB tvrtke\",\"Unesite PIB kompanije\",\"Inserire il numero di imposta sulle società\"],[\"CompanyName_Label\",\"Company name\",\"Naziv tvrtke\",\"Naziv kompanije\",\"Nome della ditta\"],[\"CompanyName_Prompt\",\"Enter company name\",\"Unesite naziv tvrtke\",\"Unesite naziv kompanije\",\"Inserire nome della società\"],[\"Message_Label\",\"Message\",\"Poruka\",\"Poruka\",\"Messaggio\"],[\"Message_Prompt\",\"Enter message\",\"Unesite tekst poruke\",\"Unesite tekst poruke\",\"Inserisci messaggio\"],[\"FirstNameLastName_Label\",\"First and last name\",\"Ime i prezime\",\"Ime i prezime\",\"Nome e cognome\"],[\"FirstNameLastName_Prompt\",\"Enter first and last name\",\"Unesite ime i prezime\",\"Unesite ime i prezime\",\"Inserire nome e cognome\"],[\"RememberMe_Prompt\",\"Remember me\",\"Zapamti me\",\"Zapamti me\",\"Ricordati di me\"],[\"RememberMe_Label\",\"Remember me\",\"Zapamti me\",\"Zapamti me\",\"Ricordati di me\"],[\"CurrentPassword_Label\",\"Current password\",\"Trenutna lozinka\",\"Trenutna lozinka\",\"Password attuale\"],[\"CurrentPassword_Prompt\",\"Enter current password\",\"Unesite trenutnu lozinku\",\"Unesite trenutnu lozinku\",\"Immetti la password corrente\"],[\"NewPassword_Label\",\"New password\",\"Nova lozinka\",\"Nova lozinka\",\"Nuova password\"],[\"NewPassword_Prompt\",\"Enter new password\",\"Unesite novu lozinku\",\"Unesite novu lozinku\",\"Inserire una nuova password\"],[\"RepeatPassword_Label\",\"Repeat password\",\"Lozinka ponovo\",\"Lozinka ponovo\",\"Ripeti la password\"],[\"RepeatPassword_Prompt\",\"Enter password again\",\"Unesite lozinku ponovo\",\"Unesite lozinku ponovo\",\"Inserisci di nuovo la password\"],[\"RepeatNewPassword_Label\",\"Repeat new password\",\"Nova lozinka ponovo\",\"Nova lozinka ponovo\",\"Ripetere la nuova password\"],[\"RepeatNewPassword_Prompt\",\"Enter new password again\",\"Unesite novu lozinku ponovo\",\"Unesite novu lozinku ponovo\",\"Immettere nuovamente la nuova password\"]]}";

        public static readonly ResxExcelProvider ResourceProvider = ResxExcelProvider.FromJson<ResxExcelProvider>(_json);


        /// <summary>
        /// Adresa 
        /// </summary>
		public static string Address_Label => ResourceProvider.GetString("Address_Label");

        /// <summary>
        /// Unesite adresu 
        /// </summary>
		public static string Address_Prompt => ResourceProvider.GetString("Address_Prompt");

        /// <summary>
        /// Datum rođenja 
        /// </summary>
		public static string BirthDate_Label => ResourceProvider.GetString("BirthDate_Label");

        /// <summary>
        /// Unesite datum rođenja 
        /// </summary>
		public static string BirthDate_Prompt => ResourceProvider.GetString("BirthDate_Prompt");

        /// <summary>
        /// Grad 
        /// </summary>
		public static string City_Label => ResourceProvider.GetString("City_Label");

        /// <summary>
        /// Unesite grad 
        /// </summary>
		public static string City_Prompt => ResourceProvider.GetString("City_Prompt");

        /// <summary>
        /// Naziv tvrtke 
        /// </summary>
		public static string CompanyName_Label => ResourceProvider.GetString("CompanyName_Label");

        /// <summary>
        /// Unesite naziv tvrtke 
        /// </summary>
		public static string CompanyName_Prompt => ResourceProvider.GetString("CompanyName_Prompt");

        /// <summary>
        /// OIB tvrtke 
        /// </summary>
		public static string CompanyPorezniBroj_Label => ResourceProvider.GetString("CompanyPorezniBroj_Label");

        /// <summary>
        /// Unesite OIB tvrtke 
        /// </summary>
		public static string CompanyPorezniBroj_Prompt => ResourceProvider.GetString("CompanyPorezniBroj_Prompt");

        /// <summary>
        /// Trenutna lozinka 
        /// </summary>
		public static string CurrentPassword_Label => ResourceProvider.GetString("CurrentPassword_Label");

        /// <summary>
        /// Unesite trenutnu lozinku 
        /// </summary>
		public static string CurrentPassword_Prompt => ResourceProvider.GetString("CurrentPassword_Prompt");

        /// <summary>
        /// E-mail adresa 
        /// </summary>
		public static string Email_Label => ResourceProvider.GetString("Email_Label");

        /// <summary>
        /// Unesite e-mail adresu 
        /// </summary>
		public static string Email_Prompt => ResourceProvider.GetString("Email_Prompt");

        /// <summary>
        /// Ime 
        /// </summary>
		public static string FirstName_Label => ResourceProvider.GetString("FirstName_Label");

        /// <summary>
        /// Unesite ime 
        /// </summary>
		public static string FirstName_Prompt => ResourceProvider.GetString("FirstName_Prompt");

        /// <summary>
        /// Ime i prezime 
        /// </summary>
		public static string FirstNameLastName_Label => ResourceProvider.GetString("FirstNameLastName_Label");

        /// <summary>
        /// Unesite ime i prezime 
        /// </summary>
		public static string FirstNameLastName_Prompt => ResourceProvider.GetString("FirstNameLastName_Prompt");

        /// <summary>
        /// Puni naziv 
        /// </summary>
		public static string FullName_Label => ResourceProvider.GetString("FullName_Label");

        /// <summary>
        /// Unesite puni naziv 
        /// </summary>
		public static string FullName_Prompt => ResourceProvider.GetString("FullName_Prompt");

        /// <summary>
        /// Prezime 
        /// </summary>
		public static string LastName_Label => ResourceProvider.GetString("LastName_Label");

        /// <summary>
        /// Unesite prezime 
        /// </summary>
		public static string LastName_Prompt => ResourceProvider.GetString("LastName_Prompt");

        /// <summary>
        /// Poruka 
        /// </summary>
		public static string Message_Label => ResourceProvider.GetString("Message_Label");

        /// <summary>
        /// Unesite tekst poruke 
        /// </summary>
		public static string Message_Prompt => ResourceProvider.GetString("Message_Prompt");

        /// <summary>
        /// Broj mobitela 
        /// </summary>
		public static string MobilePhone_Label => ResourceProvider.GetString("MobilePhone_Label");

        /// <summary>
        /// Unesite broj mobitela 
        /// </summary>
		public static string MobilePhone_Prompt => ResourceProvider.GetString("MobilePhone_Prompt");

        /// <summary>
        /// Nova lozinka 
        /// </summary>
		public static string NewPassword_Label => ResourceProvider.GetString("NewPassword_Label");

        /// <summary>
        /// Unesite novu lozinku 
        /// </summary>
		public static string NewPassword_Prompt => ResourceProvider.GetString("NewPassword_Prompt");

        /// <summary>
        /// Lozinka 
        /// </summary>
		public static string Password_Label => ResourceProvider.GetString("Password_Label");

        /// <summary>
        /// Unesite lozinku 
        /// </summary>
		public static string Password_Prompt => ResourceProvider.GetString("Password_Prompt");

        /// <summary>
        /// Telefonski broj 
        /// </summary>
		public static string PhoneNumber_Label => ResourceProvider.GetString("PhoneNumber_Label");

        /// <summary>
        /// Unesite telefonski broj 
        /// </summary>
		public static string PhoneNumber_Prompt => ResourceProvider.GetString("PhoneNumber_Prompt");

        /// <summary>
        /// Zapamti me 
        /// </summary>
		public static string RememberMe_Label => ResourceProvider.GetString("RememberMe_Label");

        /// <summary>
        /// Zapamti me 
        /// </summary>
		public static string RememberMe_Prompt => ResourceProvider.GetString("RememberMe_Prompt");

        /// <summary>
        /// Nova lozinka ponovo 
        /// </summary>
		public static string RepeatNewPassword_Label => ResourceProvider.GetString("RepeatNewPassword_Label");

        /// <summary>
        /// Unesite novu lozinku ponovo 
        /// </summary>
		public static string RepeatNewPassword_Prompt => ResourceProvider.GetString("RepeatNewPassword_Prompt");

        /// <summary>
        /// Lozinka ponovo 
        /// </summary>
		public static string RepeatPassword_Label => ResourceProvider.GetString("RepeatPassword_Label");

        /// <summary>
        /// Unesite lozinku ponovo 
        /// </summary>
		public static string RepeatPassword_Prompt => ResourceProvider.GetString("RepeatPassword_Prompt");

        /// <summary>
        /// Ulica 
        /// </summary>
		public static string StreetName_Label => ResourceProvider.GetString("StreetName_Label");

        /// <summary>
        /// Unesite ulicu 
        /// </summary>
		public static string StreetName_Prompt => ResourceProvider.GetString("StreetName_Prompt");

        /// <summary>
        /// Naslov 
        /// </summary>
		public static string Subject_Label => ResourceProvider.GetString("Subject_Label");

        /// <summary>
        /// Unesite naslov 
        /// </summary>
		public static string Subject_Prompt => ResourceProvider.GetString("Subject_Prompt");

        /// <summary>
        /// Korisničko ime 
        /// </summary>
		public static string Username_Label => ResourceProvider.GetString("Username_Label");

        /// <summary>
        /// Unesite korisničko ime 
        /// </summary>
		public static string Username_Prompt => ResourceProvider.GetString("Username_Prompt");

        /// <summary>
        /// Poštanski broj 
        /// </summary>
		public static string ZipCode_Label => ResourceProvider.GetString("ZipCode_Label");

        /// <summary>
        /// Unesite poštanski broj 
        /// </summary>
		public static string ZipCode_Prompt => ResourceProvider.GetString("ZipCode_Prompt");

	}
}
