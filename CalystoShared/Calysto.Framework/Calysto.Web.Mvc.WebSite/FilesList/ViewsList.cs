using System.Reflection;
using Calysto.AspNetCore.Mvc.ViewEngines;

namespace Calysto.Genesis.WebSite
{
	public static class ViewsList
	{
		private static ViewsListProvider _provider = new ViewsListProvider(Assembly.GetExecutingAssembly());

		public static string Pages__Home => _provider.GetExistingView("/Pages/_Home");
		public static string Pages__ViewImports => _provider.GetExistingView("/Pages/_ViewImports");
		public static string Web__ViewImports => _provider.GetExistingView("/Web/_ViewImports");
		public static string Web__ViewStart => _provider.GetExistingView("/Web/_ViewStart");
		public static string Web_Home_Error => _provider.GetExistingView("/Web/Home/Error");
		public static string Web_Home_Index => _provider.GetExistingView("/Web/Home/Index");
		public static string Web_Home_Index_hr_HR => _provider.GetExistingView("/Web/Home/Index.hr-HR");
		public static string Web_Home_Privacy => _provider.GetExistingView("/Web/Home/Privacy");
		public static string Web_Routes_Index => _provider.GetExistingView("/Web/Routes/Index");
		public static string Web__Shared__Layout => _provider.GetExistingView("/Web/_Shared/_Layout");
		public static string Web_CalystoUI_Ajax_Index => _provider.GetExistingView("/Web/CalystoUI/Ajax/Index");
		public static string Web_CalystoUI_Binding1_Index => _provider.GetExistingView("/Web/CalystoUI/Binding1/Index");
		public static string Web_CalystoUI_Binding2_Index => _provider.GetExistingView("/Web/CalystoUI/Binding2/Index");
		public static string Web_CalystoUI_Binding3_Index => _provider.GetExistingView("/Web/CalystoUI/Binding3/Index");
		public static string Web_CalystoUI_Binding4_Index => _provider.GetExistingView("/Web/CalystoUI/Binding4/Index");
		public static string Web_CalystoUI_CalystoHome_Index => _provider.GetExistingView("/Web/CalystoUI/CalystoHome/Index");
		public static string Web_CalystoUI_Checkboxes_Index => _provider.GetExistingView("/Web/CalystoUI/Checkboxes/Index");
		public static string Web_CalystoUI_Dialogs_Index => _provider.GetExistingView("/Web/CalystoUI/Dialogs/Index");
		public static string Web_CalystoUI_Flexbox_Index => _provider.GetExistingView("/Web/CalystoUI/Flexbox/Index");
		public static string Web_CalystoUI_Notifications_Index => _provider.GetExistingView("/Web/CalystoUI/Notifications/Index");
		public static string Web_CalystoUI_Preloaders_Index => _provider.GetExistingView("/Web/CalystoUI/Preloaders/Index");
		public static string Web_CalystoUI_Social_Index => _provider.GetExistingView("/Web/CalystoUI/Social/Index");
		public static string Web_CalystoUI_Validation_Index => _provider.GetExistingView("/Web/CalystoUI/Validation/Index");
		public static string Web_Home_Partial__LoginControl => _provider.GetExistingView("/Web/Home/Partial/_LoginControl");
	}
}
