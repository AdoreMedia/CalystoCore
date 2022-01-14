namespace Microsoft.Ajax.Utilities.Css2
{
	public enum MinifyModeEnum
	{
		/// <summary>
		/// Serve raw file, withour preprocessing or anything else. map file may be used this way.
		/// </summary>
		None = 0,

		/// <summary>
		/// DEBUG blocks if DEBUG is added using RegisterDefinedWords(...)
		/// </summary>
		Preprocess = 1,

		/// <summary>
		/// Remove comments 
		/// </summary>
		RemoveComments = 2,

		/// <summary>
		/// 
		/// </summary>
		Minify = 3,

		/// <summary>
		/// 
		/// </summary>
		Shrink = 4
	}
}
