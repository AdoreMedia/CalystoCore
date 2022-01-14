namespace Calysto.Web.Script.Services
{
	public static class CalystoDomAttributes
	{
		/// <summary>
		/// calysto-id name attribute
		/// </summary>
		public const string CalystoId = "calysto-id";

		/// <summary>
		/// calysto-validator-msg-for="calysto-id name". Element in which to show error message after validation of an calysto-id element.
		/// </summary>
		public const string CalystoValidatorMsgFor = "calysto-validator-msg-for";

		public const string CalystoSummaryMsgFor = "calysto-summary-msg-for";

		public const string CalystoErrorMsgFor = "calysto-error-msg-for";

		/// <summary>
		/// Used in Calysto.Forms to convert value to type after serialization.
		/// </summary>
		public const string CalystoType = "calysto-type";

		/// <summary>
		/// JS function or lambda. Used in Calysto.Forms to get value from an element on serialization.
		/// </summary>
		public const string CalystoGetter = "calysto-getter";

		/// <summary>
		/// JS function or lambda. Used in Calysto.Forms to set value to an element on deserialization.
		/// </summary>
		public const string CalystoSetter = "calysto-setter";

		/// <summary>
		/// Used in Calysto.Forms serialization and deserialization, used to parse date or number from and to format
		/// </summary>
		public const string CalystoFormat = "calysto-format";

		public const string CalystoValidationFn = "calysto-validation-fn";

		public const string CalystoBind = "calysto-bind";

		public const string CalystoBindEvents = "calysto-bind-events";

		/** used in ObservableBinder
		 * invoke custom function: calysto-listen="click, mousedown:::(sender, ev)=>...."
		 * invoke data model property function: calysto-listen="click, mousedown:::@.HideDialog */
		public const string CalystoListen = "calysto-listen";

		/** calysto-uid
		 * element unique id, generate if required */
		public const string CalystoUid = "calysto-uid";

		/** calysto-isrepeater
		 * true or false value
		 * calysto-isrepeater used in Observable */
		public const string CalystoIsRepeater = "calysto-isrepeater";

		/** calysto-isgroup
		 * true or false value
		 * calysto-isgroup used in input element for serialization to create array of elements values with the same calysto-id attribute */
		public const string CalystoIsGroup = "calysto-isgroup";


		/** calysto-getconvert
		 * usage with observable data binding when getting value form an element
		 * lambda: (valueFromElement) => {return converted value} // this is element
		 * invocation: fn.call(element, valueFromElement)
		 * */
		public const string CalystoGetConvert = "calysto-getconvert";

		/** calysto-setconvert
		 * usage with observable data binding when setting value to an element
		 * lamba: (valueFromDataSource) => {return converted to string value} // this is element
		 * invocation: fn.call(element, valueFromDataSource)
		 * */
		public const string CalystoSetConvert = "calysto-setconvert";


		public const string CalystoFormTarget = "calysto-form-target";

		public const string CalystoFormHandler = "calysto-form-handler";

		public const string CalystoFormMode = "calysto-form-mode";

		public const string CalystoFormDestination = "calysto-form-dest";

		public const string CalystoAppendVersion = "calysto-append-version";

		public const string CalystoSpinnerDelay = "calysto-spinner-delay";

		public const string CalystoTimeout= "calysto-timeout";

		public const string CalystoControllerAction = "calysto-controller-action";

		public const string CalystoScriptRun = "calysto-script-run";
	}
}
