using Calysto.Globalization;

namespace Calysto.Resources
{
    public class CalystoAnnotationsResources : ICalystoResx
    {
		private CalystoAnnotationsResources(){ }

		static string[] _columns = new string[] { "property", "en-US", "hr-HR", "sr-RS", "it-IT" };

		const string _json = "{\"__calystotype\":\"Calysto_DataTable\",\"TotalCount\":null,\"TableName\":\"\",\"Columns\":[\"property\",\"en-US\",\"hr-HR\",\"sr-RS\",\"it-IT\"],\"Rows\":[[\"ArgumentIsNullOrWhitespace\",\"The argument \\u0027{0}\\u0027 cannot be null, empty or contain only white space.\",\"Podatak \\u0027{0}\\u0027 ne može biti null, prazan ili samo razmaci.\",\"Podatak \\u0027{0}\\u0027 ne može da bude null, prazan ili samo razmaci.\",\"L\\u0027argomento \\u0027{0}\\u0027 non può essere nullo, vuoto o contenere solo lo spazio bianco.\"],[\"AssociatedMetadataTypeTypeDescriptor_MetadataTypeContainsUnknownProperties\",\"The associated metadata type for type \\u0027{0}\\u0027 contains the following unknown properties or fields: {1}. Please make sure that the names of these members match the names of the properties on the main type.\",\"Pridružena zbirka podataka za tip \\u0027{0}\\u0027 sadrži sljedeće nepoznate propertije ili polja: {1}. Nazivi moraju biti istovjetni nazivima propertija glavnog tipa.\",\"Pridružena zbirka podataka za tip \\u0027{0}\\u0027 sadrži sledeće nepoznate propertije ili polja: {1}. Nazivi moraju da budu istovetni nazivima propertija glavnog tipa.\",\"Il tipo di metadati associato per il tipo \\u0027{0}\\u0027 contiene le seguenti proprietà o campi sconosciuti: {1}. Assicurati che i nomi di questi membri corrispondano ai nomi delle proprietà sul tipo principale.\"],[\"AttributeStore_Type_Must_Be_Public\",\"The type \\u0027{0}\\u0027 must be public.\",\"Tip \\u0027{0}\\u0027 mora biti public.\",\"Tip \\u0027{0}\\u0027 mora biti public.\",\"Il tipo \\u0027{0}\\u0027 deve essere pubblico.\"],[\"AttributeStore_Unknown_Method\",\"The type \\u0027{0}\\u0027 does not contain a public method named \\u0027{1}\\u0027.\",\"Tip \\u0027{0}\\u0027 ne sadrži public metodu \\u0027{1}\\u0027.\",\"Tip \\u0027{0}\\u0027 ne sadrži public metodu \\u0027{1}\\u0027.\",\"Il tipo \\u0027{0}\\u0027 non contiene un metodo pubblico denominato \\u0027{1}\\u0027.\"],[\"AttributeStore_Unknown_Property\",\"The type \\u0027{0}\\u0027 does not contain a public property named \\u0027{1}\\u0027.\",\"Tip \\u0027{0}\\u0027 ne sadrži public property \\u0027{1}\\u0027.\",\"Tip \\u0027{0}\\u0027 ne sadrži public property \\u0027{1}\\u0027.\",\"Il tipo \\u0027{0}\\u0027 non contiene una proprietà pubblica denominata \\u0027{1}\\u0027.\"],[\"Common_NullOrEmpty\",\"Value cannot be null or empty.\",\"Vrijednost ne može biti null ili prazna.\",\"Vrednost ne može da bude null ili prazna.\",\"Il valore non può essere nullo o vuoto.\"],[\"Common_PropertyNotFound\",\"The property {0}.{1} could not be found.\",\"Property {0}.{1} nije pronađen.\",\"Property {0}.{1} nije pronađen.\",\"Non è stato possibile trovare la proprietà {0}. {1}.\"],[\"CompareAttribute_MustMatch\",\"Values \\u0027{0}\\u0027 and \\u0027{1}\\u0027 do not match.\",\"Vrijednosti \\u0027{0}\\u0027 i \\u0027{1}\\u0027 nisu jednake.\",\"Vrednosti \\u0027{0}\\u0027 i \\u0027{1}\\u0027 nisu jednake.\",\"Valori \\u0027{0}\\u0027 e \\u0027{1}\\u0027 non corrispondono.\"],[\"CompareAttribute_UnknownProperty\",\"Could not find a property named {0}.\",\"Property \\u0027{0}\\u0027 nije moguće pronaći.\",\"Property \\u0027{0}\\u0027 nije moguće pronaći.\",\"Impossibile trovare una proprietà denominata {0}.\"],[\"CreditCardAttribute_Invalid\",\"{0} value is not a valid credit card number.\",\"{0} podatak nije ispravan broj kreditne kartice.\",\"{0} podatak nije ispravan broj kreditne kartice.\",\"{0} valore non è un numero di carta di credito valido.\"],[\"CustomValidationAttribute_Method_Must_Return_ValidationResult\",\"The CustomValidationAttribute method \\u0027{0}\\u0027 in type \\u0027{1}\\u0027 must return System.ComponentModel.DataAnnotations.ValidationResult.  Use System.ComponentModel.DataAnnotations.ValidationResult.Success to represent success.\",\"CustomValidationAttribute metoda \\u0027{0}\\u0027 u tipu \\u0027{1}\\u0027 mora vraćati System.ComponentModel.DataAnnotations.ValidationResult. Koristite System.ComponentModel.DataAnnotations.ValidationResult.Success kao vrijednost za valjani rezultat.\",\"CustomValidationAttribute metoda \\u0027{0}\\u0027 u tipu \\u0027{1}\\u0027 mora vraćati System.ComponentModel.DataAnnotations.ValidationResult. Koristite System.ComponentModel.DataAnnotations.ValidationResult.Success kao vrednost za valjani rezultat.\",\"Il metodo customValidationAttribute \\u0027{0}\\u0027 in Type \\u0027{1}\\u0027 deve restituire System.ComponentModel.DataNoNoNotations.ValidationResult. Utilizzare System.ComponentModel.DataNoNotations.ValidationResult.Success per rappresentare il successo.\"],[\"CustomValidationAttribute_Method_Not_Found\",\"The CustomValidationAttribute method \\u0027{0}\\u0027 does not exist in type \\u0027{1}\\u0027 or is not public and static.\",\"CustomValidationAttribute metoda \\u0027{0}\\u0027 ne postoji u tipu \\u0027{1}\\u0027 ili nije public i static.\",\"CustomValidationAttribute metoda \\u0027{0}\\u0027 ne postoji u tipu \\u0027{1}\\u0027 ili nije public i static.\",\"Il metodo customValidationAttribute \\u0027{0}\\u0027 non esiste nel tipo \\u0027{1}\\u0027 o non è pubblico e statico.\"],[\"CustomValidationAttribute_Method_Required\",\"The CustomValidationAttribute.Method was not specified.\",\"CustomValidationAttribute.Method nema postavljenu vrijednost.\",\"CustomValidationAttribute.Method nema postavljenu vrednost.\",\"Il CustomValidationAttribute.Method non è stato specificato.\"],[\"CustomValidationAttribute_Method_Signature\",\"The CustomValidationAttribute method \\u0027{0}\\u0027 in type \\u0027{1}\\u0027 must match the expected signature: public static ValidationResult {0}(object value, ValidationContext context).  The value can be strongly typed.  The ValidationContext parameter is optional.\",\"CustomValidationAttribute metoda \\u0027{0}\\u0027 u tipu \\u0027{1}\\u0027 mora odgovarati sljedećem zapisu: public static ValidationResult {0}(object value, ValidationContext context). Vrijednost može biti \\u0027strongly typed\\u0027.  ValidationContext parametar nije obavezan.\",\"CustomValidationAttribute metoda \\u0027{0}\\u0027 u tipu \\u0027{1}\\u0027 mora odgovarati sledećem zapisu: public static ValidationResult {0}(object value, ValidationContext context). Vrijednost može biti \\u0027strongly typed\\u0027.  ValidationContext parametar nije obavezan.\",\"Il metodo CustomValidationAttribute \\u0027{0}\\u0027 in Type \\u0027{1}\\u0027 deve corrispondere alla firma prevista: Public Static ValidationResult {0} (valore oggetto, contesto validationContext). Il valore può essere fortemente digitato. Il parametro validationContext è facoltativo.\"],[\"CustomValidationAttribute_Type_Conversion_Failed\",\"Could not convert the value of type \\u0027{0}\\u0027 to \\u0027{1}\\u0027 as expected by method {2}.{3}.\",\"Nije moguće konvertirati vrijednost tipa \\u0027{0}\\u0027 u tip \\u0027{1}\\u0027 kao što se očekuje u metodi {2}.{3}.\",\"Nije moguća konverzija vrednosti tipa \\u0027{0}\\u0027 u tip \\u0027{1}\\u0027 kao što se očekuje u metodi {2}.{3}.\",\"Impossibile convertire il valore del tipo \\u0027{0}\\u0027 su \\u0027{1}\\u0027 come previsto dal metodo {2}. {3}.\"],[\"CustomValidationAttribute_Type_Must_Be_Public\",\"The custom validation type \\u0027{0}\\u0027 must be public.\",\"Kastimizirana validacija tip \\u0027{0}\\u0027 mora biti public.\",\"Kastimizirana validacija tip \\u0027{0}\\u0027 mora biti public.\",\"Il tipo di convalida personalizzato \\u0027{0}\\u0027 deve essere pubblico.\"],[\"CustomValidationAttribute_ValidationError\",\"{0} value is not valid.\",\"{0} polje nije ispravno.\",\"{0} polje nije ispravno.\",\"{0} valore non è valido.\"],[\"CustomValidationAttribute_ValidatorType_Required\",\"The CustomValidationAttribute.ValidatorType was not specified.\",\"CustomValidationAttribute.ValidatorType vrijednost nije postavljena.\",\"CustomValidationAttribute.ValidatorType vrijednost nije postavljena.\",\"Il customValidatationaTtribute.Validatorype non è stato specificato.\"],[\"DataTypeAttribute_EmptyDataTypeString\",\"The custom DataType string cannot be null or empty.\",\"Kastimizirani DataType string ne može biti null ili prazna vrijednost.\",\"Kastimizirani DataType string ne može da bude null ili prazna vrednost.\",\"La stringa personalizzata dei tipi di dati non può essere nullo o vuota.\"],[\"DisplayAttribute_PropertyNotSet\",\"The {0} property has not been set.  Use the {1} method to get the value.\",\"{0} vrijednost nije postavljena. Koristite {1} metodu za postavljanje vrijednosti.\",\"{0} vrednost nije postavljena. Koristite {1} metodu za postavljanje vrednosti.\",\"La proprietà {0} non è stata impostata. Utilizzare il metodo {1} per ottenere il valore.\"],[\"EmailAddressAttribute_Invalid\",\"{0} is not a valid e-mail address.\",\"{0} nije valjana e-mail adresa.\",\"{0} nije valjana e-mail adresa.\",\"{0} non è un indirizzo e-mail valido.\"],[\"EnumDataTypeAttribute_TypeCannotBeNull\",\"The type provided for EnumDataTypeAttribute cannot be null.\",\"Tip za EnumDataTypeAttribute ne može biti null.\",\"Tip za EnumDataTypeAttribute ne može da bude null.\",\"Il tipo fornito per EnumDataTyPeattribute non può essere nullo.\"],[\"EnumDataTypeAttribute_TypeNeedsToBeAnEnum\",\"The type \\u0027{0}\\u0027 needs to represent an enumeration type.\",\"Tip \\u0027{0}\\u0027 mora biti enumeracija.\",\"Tip \\u0027{0}\\u0027 mora biti enumeracija.\",\"Il tipo \\u0027{0}\\u0027 deve rappresentare un tipo di enumerazione.\"],[\"FileExtensionsAttribute_Invalid\",\"{0} accepts files with the following extensions: {1}\",\"{0} prihvaća samo ekstenzije: {1}\",\"{0} prihvata samo ekstenzije: {1}\",\"{0} Accetta file con le seguenti estensioni: {1}\"],[\"LocalizableString_LocalizationFailed\",\"Cannot retrieve property \\u0027{0}\\u0027 because localization failed.  Type \\u0027{1}\\u0027 is not public or does not contain a public static string property with the name \\u0027{2}\\u0027.\",\"Vrijednost \\u0027{0}\\u0027 nije dostupna radi greške u lokalizaciji. Tip \\u0027{1}\\u0027 nije public ili ne sadrži public static string property naziva \\u0027{2}\\u0027.\",\"Vrednost \\u0027{0}\\u0027 nije dostupna radi greške u lokalizaciji. Tip \\u0027{1}\\u0027 nije public ili ne sadrži public static string property naziva \\u0027{2}\\u0027.\",\"Impossibile recuperare la proprietà \\u0027{0}\\u0027 perché la localizzazione non è riuscita. Digitare \\u0027{1}\\u0027 non è pubblico o non contiene una proprietà stringa statica pubblica con il nome \\u0027{2}\\u0027.\"],[\"MaxLengthAttribute_InvalidMaxLength\",\"MaxLengthAttribute must have a Length value that is greater than zero. Use MaxLength() without parameters to indicate that the string or array can have the maximum allowable length.\",\"MaxLengthAttribute mora imati vrijednost Length veću od 0. Koristite MaxLength() bez parametara kao indikaciju da string ili arraz može biti maksimalne duljine.\",\"MaxLengthAttribute mora da ima vrednost Length veću od 0. Koristite MaxLength() bez parametara kao indikaciju da string ili array može da bude maksimalne duljine.\",\"MaxLengthAttribute deve avere un valore di lunghezza maggiore di zero. Utilizzare MaxLength () senza parametri per indicare che la stringa o l\\u0027array possono avere la lunghezza massima consentita.\"],[\"MaxLengthAttribute_ValidationError\",\"{0} must be a string or array type with a maximum length of {1}.\",\"{0} smije sadržavati najviše {1} znakova.\",\"{0} smije sadržavati najviše {1} znakova.\",\"{0} deve essere un tipo di stringa o array con una lunghezza massima di {1}.\"],[\"MetadataTypeAttribute_TypeCannotBeNull\",\"MetadataClassType cannot be null.\",\"MetadataClassType ne može biti null.\",\"MetadataClassType ne može da bude null.\",\"Il metadataclastype non può essere nullo.\"],[\"MinLengthAttribute_InvalidMinLength\",\"MinLengthAttribute must have a Length value that is zero or greater.\",\"MinLengthAttribute mora imati vrijednost Length jednaku ili veću od 0.\",\"MinLengthAttribute mora da ima vrednost Length jednaku ili veću od 0.\",\"MinlengthAttribute deve avere un valore di lunghezza zero o maggiore.\"],[\"MinLengthAttribute_ValidationError\",\"{0} must be a string or array type with a minimum length of {1}.\",\"{0} mora sadržavati najmanje {1} znakova.\",\"{0} mora sadržavati najmanje {1} znakova.\",\"{0} deve essere un tipo di stringa o array con una lunghezza minima di {1}.\"],[\"PhoneAttribute_Invalid\",\"{0} is not a valid phone number.\",\"{0} nije ispravan telefonski broj.\",\"{0} nije ispravan telefonski broj.\",\"{0} non è un numero di telefono valido.\"],[\"RangeAttribute_ArbitraryTypeNotIComparable\",\"The type {0} must implement {1}.\",\"Tip {0} mora implementirati {1}.\",\"Tip {0} mora implementirati {1}.\",\"Il tipo {0} deve implementare {1}.\"],[\"RangeAttribute_MinGreaterThanMax\",\"The maximum value \\u0027{0}\\u0027 must be greater than or equal to the minimum value \\u0027{1}\\u0027.\",\"Maksimalna vrijednost \\u0027{0}\\u0027 mora biti veća ili jednaka minimalnoj vrijednosti \\u0027{1}\\u0027.\",\"Maksimalna vrednost \\u0027{0}\\u0027 mora da bude veća ili jednaka minimalnoj vrednosti \\u0027{1}\\u0027.\",\"Il valore massimo \\u0027{0}\\u0027 deve essere maggiore o uguale al valore minimo \\u0027{1}\\u0027.\"],[\"RangeAttribute_Must_Set_Min_And_Max\",\"The minimum and maximum values must be set.\",\"Maksimalna i minimalna vrijednosti moraju biti postavljene.\",\"Maksimalna i minimalna vrednosti moraju da budu postavljene.\",\"I valori minimi e massimi devono essere impostati.\"],[\"RangeAttribute_Must_Set_Operand_Type\",\"The OperandType must be set when strings are used for minimum and maximum values.\",\"OperandType mora biti postavljen kad se koristi string za minimalnu i maksimalnu vrijednost.\",\"OperandType mora da bude postavljen kad se koristi string za minimalnu i maksimalnu vrijednost.\",\"L\\u0027operello deve essere impostato quando le stringhe vengono utilizzate per i valori minimi e massimi.\"],[\"RangeAttribute_ValidationError\",\"{0} must be between {1} and {2}.\",\"{0} mora biti između {1} i {2}.\",\"{0} mora da bude između {1} i {2}.\",\"{0} deve essere compreso tra {1} e {2}.\"],[\"RegexAttribute_ValidationError\",\"{0} must match the regular expression \\u0027{1}\\u0027.\",\"{0} mora zadovoljavati obrazac \\u0027{1}\\u0027.\",\"{0} mora da zadovoljava obrazac \\u0027{1}\\u0027.\",\"{0} deve corrispondere all\\u0027espressione regolare \\u0027{1}\\u0027.\"],[\"RegularExpressionAttribute_Empty_Pattern\",\"The pattern must be set to a valid regular expression.\",\"Obrazac mora biti ispravni regular expression.\",\"Obrazac mora da bude ispravan regular expression.\",\"Il modello deve essere impostato su un\\u0027espressione regolare valida.\"],[\"RequiredAttribute_ValidationError\",\"{0} value is required.\",\"{0} podatak je obavezan.\",\"{0} podatak je obavezan.\",\"{0} valore è richiesto.\"],[\"StringLengthAttribute_InvalidMaxLength\",\"The maximum length must be a nonnegative integer.\",\"Maksimalna duljina mora biti pozitivni broj.\",\"Maksimalna duljina mora da bude pozitivni broj.\",\"La lunghezza massima deve essere un numero intero non negativo.\"],[\"StringLengthAttribute_ValidationError\",\"{0} must be a string with length between {2} and {1} chars.\",\"{0} mora biti string duljine od {2} do {1} znakova.\",\"{0} mora da bude string duljine od {2} do {1} znakova.\",\"{0} deve essere una stringa con lunghezza tra il carattere {2} e {1}.\"],[\"StringLengthAttribute_ValidationErrorIncludingMinimum\",\"{0} must be a string with a minimum length of {2} and a maximum length of {1}.\",\"{0} mora biti string duljine od {2} do {1} znakova.\",\"{0} mora da bude string duljine od {2} do {1} znakova.\",\"{0} deve essere una stringa con una lunghezza minima di {2} e una lunghezza massima di {1}.\"],[\"UIHintImplementation_ControlParameterKeyIsNotAString\",\"The key parameter at position {0} with value \\u0027{1}\\u0027 is not a string. Every key control parameter must be a string.\",\"Key parametar na poziciji {0}, vrijednosti \\u0027{1}\\u0027, nije string. Svaki key parametar mora biti string.\",\"Key parametar na poziciji {0}, vrednosti \\u0027{1}\\u0027, nije string. Svaki key parametar mora da bude string.\",\"Il parametro chiave in posizione {0} con valore \\u0027{1}\\u0027 non è una stringa. Ogni parametro di controllo chiave deve essere una stringa.\"],[\"UIHintImplementation_ControlParameterKeyIsNull\",\"The key parameter at position {0} is null. Every key control parameter must be a string.\",\"Key parametar na poziciji {0} je null. Svaki key parametar mora biti string.\",\"Key parametar na poziciji {0} je null. Svaki key parametar mora da bude string.\",\"Il parametro chiave in posizione {0} è nullo. Ogni parametro di controllo chiave deve essere una stringa.\"],[\"UIHintImplementation_ControlParameterKeyOccursMoreThanOnce\",\"The key parameter at position {0} with value \\u0027{1}\\u0027 occurs more than once.\",\"Key parametar na poziciji {0}, vrijednosti \\u0027{1}\\u0027, postoji više puta.\",\"Key parametar na poziciji {0}, vrednosti \\u0027{1}\\u0027, postoji više puta.\",\"Il parametro chiave in posizione {0} con valore \\u0027{1}\\u0027 si verifica più di una volta.\"],[\"UIHintImplementation_NeedEvenNumberOfControlParameters\",\"The number of control parameters must be even.\",\"Broj key parametara mora biti paran broj.\",\"Broj key parametara mora da bude paran broj.\",\"Il numero di parametri di controllo deve essere anche.\"],[\"UrlAttribute_Invalid\",\"{0} is not a valid fully-qualified http, https, or ftp URL.\",\"{0} nije ispravni http, https, ftp ili URL.\",\"{0} nije ispravni http, https, ftp ili URL.\",\"{0} non è un URL HTTP, HTTPS o FTP completamente qualificato valido.\"],[\"ValidationAttribute_Cannot_Set_ErrorMessage_And_Resource\",\"Either ErrorMessageString or ErrorMessageResourceName must be set, but not both.\",\"Samo jedan od ErrorMessageString ili ErrorMessageResourceName mora biti zadan, ali ne oba istovremeno.\",\"Samo jedan od ErrorMessageString ili ErrorMessageResourceName mora biti zadan, ali ne oba istovremeno.\",\"È necessario impostare ErrorMessageString o ErrorMessaGeresourCename, ma non entrambi.\"],[\"ValidationAttribute_IsValid_NotImplemented\",\"IsValid(object value) has not been implemented by this class.  The preferred entry point is GetValidationResult() and classes should override IsValid(object value, ValidationContext context).\",\"IsValid(object value) metoda nije implementirana. Preferirana ulazna metoda je GetValidationResult() te mora postojati override IsValid(object value, ValidationContext context) metoda.\",\"IsValid(object value) metoda nije implementisana. Preferirana ulazna metoda je GetValidationResult() te mora da postoji override IsValid(object value, ValidationContext context) metoda.\",\"ISValid (valore oggetto) non è stato implementato da questa classe. Il punto di ingresso preferito è GetValidationResult () e le classi dovrebbero sovrascrivere ISValid (valore oggetto, contesto validationContext).\"],[\"ValidationAttribute_NeedBothResourceTypeAndResourceName\",\"Both ErrorMessageResourceType and ErrorMessageResourceName need to be set on this attribute.\",\"Obje ErrorMessageResourceType i ErrorMessageResourceName vrijednosti moraju biti postavljene.\",\"Obe ErrorMessageResourceType i ErrorMessageResourceName vrednosti moraju da budu postavljene.\",\"Sia ErrorMessaGereSourCetype che ErrorMessaGeresourCename devono essere impostati su questo attributo.\"],[\"ValidationAttribute_ResourcePropertyNotStringType\",\"The property \\u0027{0}\\u0027 on resource type \\u0027{1}\\u0027 is not a string type.\",\"Property \\u0027{0}\\u0027 u resource tipu \\u0027{1}\\u0027 nije string tipa.\",\"Property \\u0027{0}\\u0027 u resource tipu \\u0027{1}\\u0027 nije string tipa.\",\"La proprietà \\u0027{0}\\u0027 su Tipo di risorsa \\u0027{1}\\u0027 non è un tipo di stringa.\"],[\"ValidationAttribute_ResourceTypeDoesNotHaveProperty\",\"The resource type \\u0027{0}\\u0027 does not have an accessible static property named \\u0027{1}\\u0027.\",\"Resource tipa \\u0027{0}\\u0027 ne sadrži public static property naziva \\u0027{1}\\u0027.\",\"Resource tipa \\u0027{0}\\u0027 ne sadrži public static property naziva \\u0027{1}\\u0027.\",\"Il tipo di risorsa \\u0027{0}\\u0027 non ha una proprietà statica accessibile denominata \\u0027{1}\\u0027.\"],[\"ValidationAttribute_ValidationError\",\"\\u0027{0}\\u0027 value is invalid.\",\"\\u0027{0}\\u0027 nije ispravna vrijednost.\",\"\\u0027{0}\\u0027 nije ispravna vrednost.\",\"\\u0027{0}\\u0027 il valore non è valido.\"],[\"ValidationAttribute_InvalidFieldValue\",\"{0} has invalid value.\",\"{0} podatak nije ispravan.\",\"{0} podatak nije ispravan.\",\"{0} ha valore non valido.\"],[\"ValidationContext_Must_Be_Method\",\"The ValidationContext for the type \\u0027{0}\\u0027, member name \\u0027{1}\\u0027 must provide the MethodInfo.\",\"ValidationContext za tip \\u0027{0}\\u0027, member naziva \\u0027{1}\\u0027, mora sadržavati MethodInfo.\",\"ValidationContext za tip \\u0027{0}\\u0027, member naziva \\u0027{1}\\u0027, mora da sadrži MethodInfo.\",\"Il ValidationContext per il tipo \\u0027{0}\\u0027, il nome del membro \\u0027{1}\\u0027 deve fornire il metodInFO.\"],[\"ValidationContextServiceContainer_ItemAlreadyExists\",\"A service of type \\u0027{0}\\u0027 already exists in the container.\",\"Servis tipa \\u0027{0}\\u0027 već postoji u kontejneru.\",\"Servis tipa \\u0027{0}\\u0027 već postoji u kontejneru.\",\"Un servizio di tipo \\u0027{0}\\u0027 esiste già nel contenitore.\"],[\"Validator_InstanceMustMatchValidationContextInstance\",\"The instance provided must match the ObjectInstance on the ValidationContext supplied.\",\"Tip instance mora biti istovjetan tipu ObjectInstance zadan u ValidationContext-u.\",\"Tip instance mora biti istovetan tipu ObjectInstance zadan u ValidationContext-u.\",\"L\\u0027istanza fornita deve corrispondere alla base di oggetti sulla validazioneContext fornita.\"],[\"Validator_Property_Value_Wrong_Type\",\"The value for property \\u0027{0}\\u0027 must be of type \\u0027{1}\\u0027.\",\"Vrijednost propertija \\u0027{0}\\u0027 mora biti tipa \\u0027{1}\\u0027.\",\"Vrednost propertija \\u0027{0}\\u0027 mora da bude tipa \\u0027{1}\\u0027.\",\"Il valore per la proprietà \\u0027{0}\\u0027 deve essere di tipo \\u0027{1}\\u0027.\"],[\"RegexAttribute_EnterDigitsOnly\",\"{0} accepts digits only.\",\"{0} polje prihvaća samo brojke.\",\"{0} polje prihvata samo brojke.\",\"{0} Accetta solo cifre.\"],[\"RegexAttribute_EnterLettersOnly\",\"{0} accepts letters only.\",\"{0} polje prihvaća samo slova.\",\"{0} polje prihvata samo slova.\",\"{0} Accetta solo lettere.\"],[\"RegexAttribute_EnterDigitsAndLettersOnly\",\"{0} accepts digits and letters only.\",\"{0} polje prihvaća samo brojke i slova.\",\"{0} polje prihvata samo brojke i slova.\",\"{0} Accetta solo cifre e lettere.\"],[\"RegexAttribute_SpacesNotAccepted\",\"{0} doesn\\u0027t accept spaces.\",\"{0} polje ne prihvaća praznine.\",\"{0} polje ne prihvata praznine.\",\"{0} non accetta spazi.\"],[\"PhoneNumberAttribute_ValidationError\",\"{0} requires valid phone number.\",\"{0} polje zahtijeva ispravan telefonski broj.\",\"{0} polje zahteva ispravan telefonski broj.\",\"{0} richiede un numero di telefono valido.\"]]}";

        public static readonly ResxExcelProvider ResourceProvider = ResxExcelProvider.FromJson<ResxExcelProvider>(_json);


        /// <summary>
        /// Podatak '{0}' ne može biti null, prazan ili samo razmaci. 
        /// </summary>
		public static string ArgumentIsNullOrWhitespace => ResourceProvider.GetString("ArgumentIsNullOrWhitespace");

        /// <summary>
        /// Pridružena zbirka podataka za tip '{0}' sadrži sljedeće nepoznate propertije ili polja: {1}. Nazivi moraju biti istovjetni nazivima propertija glavnog tipa. 
        /// </summary>
		public static string AssociatedMetadataTypeTypeDescriptor_MetadataTypeContainsUnknownProperties => ResourceProvider.GetString("AssociatedMetadataTypeTypeDescriptor_MetadataTypeContainsUnknownProperties");

        /// <summary>
        /// Tip '{0}' mora biti public. 
        /// </summary>
		public static string AttributeStore_Type_Must_Be_Public => ResourceProvider.GetString("AttributeStore_Type_Must_Be_Public");

        /// <summary>
        /// Tip '{0}' ne sadrži public metodu '{1}'. 
        /// </summary>
		public static string AttributeStore_Unknown_Method => ResourceProvider.GetString("AttributeStore_Unknown_Method");

        /// <summary>
        /// Tip '{0}' ne sadrži public property '{1}'. 
        /// </summary>
		public static string AttributeStore_Unknown_Property => ResourceProvider.GetString("AttributeStore_Unknown_Property");

        /// <summary>
        /// Vrijednost ne može biti null ili prazna. 
        /// </summary>
		public static string Common_NullOrEmpty => ResourceProvider.GetString("Common_NullOrEmpty");

        /// <summary>
        /// Property {0}.{1} nije pronađen. 
        /// </summary>
		public static string Common_PropertyNotFound => ResourceProvider.GetString("Common_PropertyNotFound");

        /// <summary>
        /// Vrijednosti '{0}' i '{1}' nisu jednake. 
        /// </summary>
		public static string CompareAttribute_MustMatch => ResourceProvider.GetString("CompareAttribute_MustMatch");

        /// <summary>
        /// Property '{0}' nije moguće pronaći. 
        /// </summary>
		public static string CompareAttribute_UnknownProperty => ResourceProvider.GetString("CompareAttribute_UnknownProperty");

        /// <summary>
        /// {0} podatak nije ispravan broj kreditne kartice. 
        /// </summary>
		public static string CreditCardAttribute_Invalid => ResourceProvider.GetString("CreditCardAttribute_Invalid");

        /// <summary>
        /// CustomValidationAttribute metoda '{0}' u tipu '{1}' mora vraćati System.ComponentModel.DataAnnotations.ValidationResult. Koristite System.ComponentModel.DataAnnotations.ValidationResult.Success kao vrijednost za valjani rezultat. 
        /// </summary>
		public static string CustomValidationAttribute_Method_Must_Return_ValidationResult => ResourceProvider.GetString("CustomValidationAttribute_Method_Must_Return_ValidationResult");

        /// <summary>
        /// CustomValidationAttribute metoda '{0}' ne postoji u tipu '{1}' ili nije public i static. 
        /// </summary>
		public static string CustomValidationAttribute_Method_Not_Found => ResourceProvider.GetString("CustomValidationAttribute_Method_Not_Found");

        /// <summary>
        /// CustomValidationAttribute.Method nema postavljenu vrijednost. 
        /// </summary>
		public static string CustomValidationAttribute_Method_Required => ResourceProvider.GetString("CustomValidationAttribute_Method_Required");

        /// <summary>
        /// CustomValidationAttribute metoda '{0}' u tipu '{1}' mora odgovarati sljedećem zapisu: public static ValidationResult {0}(object value, ValidationContext context). Vrijednost može biti 'strongly typed'.  ValidationContext parametar nije obavezan. 
        /// </summary>
		public static string CustomValidationAttribute_Method_Signature => ResourceProvider.GetString("CustomValidationAttribute_Method_Signature");

        /// <summary>
        /// Nije moguće konvertirati vrijednost tipa '{0}' u tip '{1}' kao što se očekuje u metodi {2}.{3}. 
        /// </summary>
		public static string CustomValidationAttribute_Type_Conversion_Failed => ResourceProvider.GetString("CustomValidationAttribute_Type_Conversion_Failed");

        /// <summary>
        /// Kastimizirana validacija tip '{0}' mora biti public. 
        /// </summary>
		public static string CustomValidationAttribute_Type_Must_Be_Public => ResourceProvider.GetString("CustomValidationAttribute_Type_Must_Be_Public");

        /// <summary>
        /// {0} polje nije ispravno. 
        /// </summary>
		public static string CustomValidationAttribute_ValidationError => ResourceProvider.GetString("CustomValidationAttribute_ValidationError");

        /// <summary>
        /// CustomValidationAttribute.ValidatorType vrijednost nije postavljena. 
        /// </summary>
		public static string CustomValidationAttribute_ValidatorType_Required => ResourceProvider.GetString("CustomValidationAttribute_ValidatorType_Required");

        /// <summary>
        /// Kastimizirani DataType string ne može biti null ili prazna vrijednost. 
        /// </summary>
		public static string DataTypeAttribute_EmptyDataTypeString => ResourceProvider.GetString("DataTypeAttribute_EmptyDataTypeString");

        /// <summary>
        /// {0} vrijednost nije postavljena. Koristite {1} metodu za postavljanje vrijednosti. 
        /// </summary>
		public static string DisplayAttribute_PropertyNotSet => ResourceProvider.GetString("DisplayAttribute_PropertyNotSet");

        /// <summary>
        /// {0} nije valjana e-mail adresa. 
        /// </summary>
		public static string EmailAddressAttribute_Invalid => ResourceProvider.GetString("EmailAddressAttribute_Invalid");

        /// <summary>
        /// Tip za EnumDataTypeAttribute ne može biti null. 
        /// </summary>
		public static string EnumDataTypeAttribute_TypeCannotBeNull => ResourceProvider.GetString("EnumDataTypeAttribute_TypeCannotBeNull");

        /// <summary>
        /// Tip '{0}' mora biti enumeracija. 
        /// </summary>
		public static string EnumDataTypeAttribute_TypeNeedsToBeAnEnum => ResourceProvider.GetString("EnumDataTypeAttribute_TypeNeedsToBeAnEnum");

        /// <summary>
        /// {0} prihvaća samo ekstenzije: {1} 
        /// </summary>
		public static string FileExtensionsAttribute_Invalid => ResourceProvider.GetString("FileExtensionsAttribute_Invalid");

        /// <summary>
        /// Vrijednost '{0}' nije dostupna radi greške u lokalizaciji. Tip '{1}' nije public ili ne sadrži public static string property naziva '{2}'. 
        /// </summary>
		public static string LocalizableString_LocalizationFailed => ResourceProvider.GetString("LocalizableString_LocalizationFailed");

        /// <summary>
        /// MaxLengthAttribute mora imati vrijednost Length veću od 0. Koristite MaxLength() bez parametara kao indikaciju da string ili arraz može biti maksimalne duljine. 
        /// </summary>
		public static string MaxLengthAttribute_InvalidMaxLength => ResourceProvider.GetString("MaxLengthAttribute_InvalidMaxLength");

        /// <summary>
        /// {0} smije sadržavati najviše {1} znakova. 
        /// </summary>
		public static string MaxLengthAttribute_ValidationError => ResourceProvider.GetString("MaxLengthAttribute_ValidationError");

        /// <summary>
        /// MetadataClassType ne može biti null. 
        /// </summary>
		public static string MetadataTypeAttribute_TypeCannotBeNull => ResourceProvider.GetString("MetadataTypeAttribute_TypeCannotBeNull");

        /// <summary>
        /// MinLengthAttribute mora imati vrijednost Length jednaku ili veću od 0. 
        /// </summary>
		public static string MinLengthAttribute_InvalidMinLength => ResourceProvider.GetString("MinLengthAttribute_InvalidMinLength");

        /// <summary>
        /// {0} mora sadržavati najmanje {1} znakova. 
        /// </summary>
		public static string MinLengthAttribute_ValidationError => ResourceProvider.GetString("MinLengthAttribute_ValidationError");

        /// <summary>
        /// {0} nije ispravan telefonski broj. 
        /// </summary>
		public static string PhoneAttribute_Invalid => ResourceProvider.GetString("PhoneAttribute_Invalid");

        /// <summary>
        /// {0} polje zahtijeva ispravan telefonski broj. 
        /// </summary>
		public static string PhoneNumberAttribute_ValidationError => ResourceProvider.GetString("PhoneNumberAttribute_ValidationError");

        /// <summary>
        /// Tip {0} mora implementirati {1}. 
        /// </summary>
		public static string RangeAttribute_ArbitraryTypeNotIComparable => ResourceProvider.GetString("RangeAttribute_ArbitraryTypeNotIComparable");

        /// <summary>
        /// Maksimalna vrijednost '{0}' mora biti veća ili jednaka minimalnoj vrijednosti '{1}'. 
        /// </summary>
		public static string RangeAttribute_MinGreaterThanMax => ResourceProvider.GetString("RangeAttribute_MinGreaterThanMax");

        /// <summary>
        /// Maksimalna i minimalna vrijednosti moraju biti postavljene. 
        /// </summary>
		public static string RangeAttribute_Must_Set_Min_And_Max => ResourceProvider.GetString("RangeAttribute_Must_Set_Min_And_Max");

        /// <summary>
        /// OperandType mora biti postavljen kad se koristi string za minimalnu i maksimalnu vrijednost. 
        /// </summary>
		public static string RangeAttribute_Must_Set_Operand_Type => ResourceProvider.GetString("RangeAttribute_Must_Set_Operand_Type");

        /// <summary>
        /// {0} mora biti između {1} i {2}. 
        /// </summary>
		public static string RangeAttribute_ValidationError => ResourceProvider.GetString("RangeAttribute_ValidationError");

        /// <summary>
        /// {0} polje prihvaća samo brojke i slova. 
        /// </summary>
		public static string RegexAttribute_EnterDigitsAndLettersOnly => ResourceProvider.GetString("RegexAttribute_EnterDigitsAndLettersOnly");

        /// <summary>
        /// {0} polje prihvaća samo brojke. 
        /// </summary>
		public static string RegexAttribute_EnterDigitsOnly => ResourceProvider.GetString("RegexAttribute_EnterDigitsOnly");

        /// <summary>
        /// {0} polje prihvaća samo slova. 
        /// </summary>
		public static string RegexAttribute_EnterLettersOnly => ResourceProvider.GetString("RegexAttribute_EnterLettersOnly");

        /// <summary>
        /// {0} polje ne prihvaća praznine. 
        /// </summary>
		public static string RegexAttribute_SpacesNotAccepted => ResourceProvider.GetString("RegexAttribute_SpacesNotAccepted");

        /// <summary>
        /// {0} mora zadovoljavati obrazac '{1}'. 
        /// </summary>
		public static string RegexAttribute_ValidationError => ResourceProvider.GetString("RegexAttribute_ValidationError");

        /// <summary>
        /// Obrazac mora biti ispravni regular expression. 
        /// </summary>
		public static string RegularExpressionAttribute_Empty_Pattern => ResourceProvider.GetString("RegularExpressionAttribute_Empty_Pattern");

        /// <summary>
        /// {0} podatak je obavezan. 
        /// </summary>
		public static string RequiredAttribute_ValidationError => ResourceProvider.GetString("RequiredAttribute_ValidationError");

        /// <summary>
        /// Maksimalna duljina mora biti pozitivni broj. 
        /// </summary>
		public static string StringLengthAttribute_InvalidMaxLength => ResourceProvider.GetString("StringLengthAttribute_InvalidMaxLength");

        /// <summary>
        /// {0} mora biti string duljine od {2} do {1} znakova. 
        /// </summary>
		public static string StringLengthAttribute_ValidationError => ResourceProvider.GetString("StringLengthAttribute_ValidationError");

        /// <summary>
        /// {0} mora biti string duljine od {2} do {1} znakova. 
        /// </summary>
		public static string StringLengthAttribute_ValidationErrorIncludingMinimum => ResourceProvider.GetString("StringLengthAttribute_ValidationErrorIncludingMinimum");

        /// <summary>
        /// Key parametar na poziciji {0}, vrijednosti '{1}', nije string. Svaki key parametar mora biti string. 
        /// </summary>
		public static string UIHintImplementation_ControlParameterKeyIsNotAString => ResourceProvider.GetString("UIHintImplementation_ControlParameterKeyIsNotAString");

        /// <summary>
        /// Key parametar na poziciji {0} je null. Svaki key parametar mora biti string. 
        /// </summary>
		public static string UIHintImplementation_ControlParameterKeyIsNull => ResourceProvider.GetString("UIHintImplementation_ControlParameterKeyIsNull");

        /// <summary>
        /// Key parametar na poziciji {0}, vrijednosti '{1}', postoji više puta. 
        /// </summary>
		public static string UIHintImplementation_ControlParameterKeyOccursMoreThanOnce => ResourceProvider.GetString("UIHintImplementation_ControlParameterKeyOccursMoreThanOnce");

        /// <summary>
        /// Broj key parametara mora biti paran broj. 
        /// </summary>
		public static string UIHintImplementation_NeedEvenNumberOfControlParameters => ResourceProvider.GetString("UIHintImplementation_NeedEvenNumberOfControlParameters");

        /// <summary>
        /// {0} nije ispravni http, https, ftp ili URL. 
        /// </summary>
		public static string UrlAttribute_Invalid => ResourceProvider.GetString("UrlAttribute_Invalid");

        /// <summary>
        /// Samo jedan od ErrorMessageString ili ErrorMessageResourceName mora biti zadan, ali ne oba istovremeno. 
        /// </summary>
		public static string ValidationAttribute_Cannot_Set_ErrorMessage_And_Resource => ResourceProvider.GetString("ValidationAttribute_Cannot_Set_ErrorMessage_And_Resource");

        /// <summary>
        /// {0} podatak nije ispravan. 
        /// </summary>
		public static string ValidationAttribute_InvalidFieldValue => ResourceProvider.GetString("ValidationAttribute_InvalidFieldValue");

        /// <summary>
        /// IsValid(object value) metoda nije implementirana. Preferirana ulazna metoda je GetValidationResult() te mora postojati override IsValid(object value, ValidationContext context) metoda. 
        /// </summary>
		public static string ValidationAttribute_IsValid_NotImplemented => ResourceProvider.GetString("ValidationAttribute_IsValid_NotImplemented");

        /// <summary>
        /// Obje ErrorMessageResourceType i ErrorMessageResourceName vrijednosti moraju biti postavljene. 
        /// </summary>
		public static string ValidationAttribute_NeedBothResourceTypeAndResourceName => ResourceProvider.GetString("ValidationAttribute_NeedBothResourceTypeAndResourceName");

        /// <summary>
        /// Property '{0}' u resource tipu '{1}' nije string tipa. 
        /// </summary>
		public static string ValidationAttribute_ResourcePropertyNotStringType => ResourceProvider.GetString("ValidationAttribute_ResourcePropertyNotStringType");

        /// <summary>
        /// Resource tipa '{0}' ne sadrži public static property naziva '{1}'. 
        /// </summary>
		public static string ValidationAttribute_ResourceTypeDoesNotHaveProperty => ResourceProvider.GetString("ValidationAttribute_ResourceTypeDoesNotHaveProperty");

        /// <summary>
        /// '{0}' nije ispravna vrijednost. 
        /// </summary>
		public static string ValidationAttribute_ValidationError => ResourceProvider.GetString("ValidationAttribute_ValidationError");

        /// <summary>
        /// ValidationContext za tip '{0}', member naziva '{1}', mora sadržavati MethodInfo. 
        /// </summary>
		public static string ValidationContext_Must_Be_Method => ResourceProvider.GetString("ValidationContext_Must_Be_Method");

        /// <summary>
        /// Servis tipa '{0}' već postoji u kontejneru. 
        /// </summary>
		public static string ValidationContextServiceContainer_ItemAlreadyExists => ResourceProvider.GetString("ValidationContextServiceContainer_ItemAlreadyExists");

        /// <summary>
        /// Tip instance mora biti istovjetan tipu ObjectInstance zadan u ValidationContext-u. 
        /// </summary>
		public static string Validator_InstanceMustMatchValidationContextInstance => ResourceProvider.GetString("Validator_InstanceMustMatchValidationContextInstance");

        /// <summary>
        /// Vrijednost propertija '{0}' mora biti tipa '{1}'. 
        /// </summary>
		public static string Validator_Property_Value_Wrong_Type => ResourceProvider.GetString("Validator_Property_Value_Wrong_Type");

	}
}
