namespace Calysto.DataAnnotations.ValidationService
{
	public class CalystoEntryValidationResult
	{
		public CalystoEntryValidationResult()
		{
		}

		public CalystoEntryValidationResult(string formsNamePath, string errorText)
		{
			this.FormsNamePath = formsNamePath;
			this.ErrorText = errorText;
		}

		public bool IsValid { get; internal set; }
		public string DisplayName { get; internal set; }
		public string ErrorText { get; internal set; }
		public object RawValue { get; internal set; }
		public string FormsNamePath { get; internal set; }
		public object ConvertedValue { get; internal set; }
	}
}