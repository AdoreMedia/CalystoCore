//************************************************************
// type def
//************************************************************
/// <reference path="../../../Extern/facebook-js-sdk.d.ts" />
/// <reference path="../../../Extern/gapi-index.d.ts" />
/// <reference path="../../../Extern/gapi.auth-index.d.ts" />
/// <reference path="../../../Extern/jquery/jquery.d.ts" />
/// <reference path="../../../Extern/jquery/jquery.form.d.ts" />
/// <reference path="../../../Extern/jquery/jquery.validate.d.ts" />
/// <reference path="../../../Extern/jquery/jquery.validate.unobtrusive.d.ts" />
/// <reference path="../../../Extern/jquery/jquery.soap.d.ts" />
/// <reference path="../../../Extern/jquery/jquery.cycle.d.ts" />
/// <reference path="../../../Extern/jquery/jquery.color.d.ts" />
/// <reference path="../../../Extern/jquery/jquery.pajax.d.ts" />
/// <reference path="../../../Extern/bootstrap/bootstrap.d.ts" />
//************************************************************
// Calysto engine
//************************************************************
/// <reference path="../../src/core/d.ts/CalystoInterfaces.d.ts" />
/// <reference path="../../src/core/d.ts/CalystoDeclarations.d.ts" />
/// <reference path="../../src/core/d.ts/IRuntimeConstants.d.ts" />
/// <reference path="../../Src/Core/Tasks/Tasks.ts" />
/// <reference path="../../Src/Core/Tasks/TaskExtensions.ts" />
/// <reference path="../../Src/Core/Tasks/CalystoMonitor.ts" />
/// <reference path="../../../resources/Images/Images.ts" />
/// <reference path="../../Src/Core/Constants/AppConstants.ts" />
/// <reference path="../../Src/Core/Constants/WsjsHeaderConstants.ts" />
/// <reference path="../../Src/Core/Constants/PredefinedCultures.ts" />
/// <reference path="../../Src/Core/Constants/CalystoDomAttributes.ts" />
/// <reference path="../../Src/Core/Constants/CalystoAjaxHandlerConstants.ts" />
/// <reference path="../../Src/Core/Constants/BaseXCharsTable.ts" />
/// <reference path="../../Src/Core/Globalization/ResxExcelProvider.ts" />
/// <reference path="../../../Resources/CalystoLang/CalystoLang.generated.ts" />
/// <reference path="../../Src/Core/Extension/Date.d.ts" />
/// <reference path="../../Src/Core/Extension/Location.d.ts" />
/// <reference path="../../Src/Core/Extension/Array.d.ts" />
/// <reference path="../../Src/Core/Core.ts" />
/// <reference path="../../Src/Core/AttrName.ts" />
/// <reference path="../../Src/Core/BoxValue.ts" />
/// <reference path="../../Src/Core/Utility/Utility.Generators.ts" />
/// <reference path="../../Src/Core/Enumerable/ArraySorter.ts" />
/// <reference path="../../Src/Core/Enum.ts" />
/// <reference path="../../Src/Core/Globalization/Globalization.ts" />
/// <reference path="../../Src/Core/Extension/Array.ts" />
/// <reference path="../../Src/Core/Extension/Map.ts" />
/// <reference path="../../Src/Core/Extension/Math.ts" />
/// <reference path="../../Src/Core/Extension/Blob.ts" />
/// <reference path="../../Src/Core/Extension/Boolean.ts" />
/// <reference path="../../Src/Core/Extension/Date.ts" />
/// <reference path="../../Src/Core/Extension/Error.ts" />
/// <reference path="../../Src/Core/Extension/Function.ts" />
/// <reference path="../../Src/Core/Utility/Utility.Expressions.ts" />
/// <reference path="../../Src/Core/Extension/Regexp.ts" />
/// <reference path="../../Src/Core/DataBinder.ts" />
/// <reference path="../../Src/Core/Utility/Utility.ts" />
/// <reference path="../../Src/Core/Type/Type.ts" />
/// <reference path="../../Src/Core/Mathm.ts" />
/// <reference path="../../Src/Core/Extension/Number.ts" />
/// <reference path="../../Src/Core/Extension/String.ts" />
/// <reference path="../../Src/Core/TimeSpan.ts" />
/// <reference path="../../Src/Core/DateTime.ts" />
/// <reference path="../../Src/Core/Dictionary.ts" />
/// <reference path="../../Src/Core/Enumerable/Collections.ts" />
/// <reference path="../../Src/Core/Enumerable/Enumerator.ts" />
/// <reference path="../../Src/Core/Enumerable/Enumerable.ts" />
/// <reference path="../../Src/Core/Features.ts" />
/// <reference path="../../Src/Core/CookieUtility.ts" />
/// <reference path="../../Src/Core/Event.ts" />
/// <reference path="../../Src/Core/Utility/Utility.Html.ts" />
/// <reference path="../../Src/Core/Utility/Utility.Encoding.ts" />
/// <reference path="../../Src/Core/Utility/Utility.Dom.Style.ts" />
/// <reference path="../../Src/Core/Utility/Utility.Dom.ts" />
/// <reference path="../../Src/Core/Utility/Utility.Path.ts" />
/// <reference path="../../Src/Core/Utility/Utility.Blob.ts" />
/// <reference path="../../Src/Core/Utility/Utility.Caret.ts" />
/// <reference path="../../Src/Core/Utility/Utility.FullScreen.ts" />
/// <reference path="../../Src/Core/Utility/Utility.CalystoTools.ts" />
/// <reference path="../../Src/Core/Graphics.ImageResize.ts" />
/// <reference path="../../Src/Core/QueryString.ts" />
/// <reference path="../../Src/Core/ScriptLoader.ts" />
/// <reference path="../../Src/Core/Timer.ts" />
/// <reference path="../../Src/Core/Uri.ts" />
/// <reference path="../../Src/Core/Validate.ts" />
/// <reference path="../../Src/Core/Regex.ts" />
/// <reference path="../../Src/Core/StyleSheet.ts" />
/// <reference path="../../Src/Core/JSON/JSON.ts" />
/// <reference path="../../Src/Core/JSON/JSON.JsonNode.ts" />
/// <reference path="../../Src/Core/JSON/JSON.BinaryFrame.ts" />
/// <reference path="../../Src/Core/Dialog/OverflowProvider.ts" />
/// <reference path="../../Src/Core/Dialog/Dialog.ts" />
/// <reference path="../../Src/Core/Notification/Notification.ts" />
/// <reference path="../../Src/Core/Net/Net.WebClient.ts" />
/// <reference path="../../Src/Core/Net/Net.WebSocket.ts" />
/// <reference path="../../Src/Core/Net/Net.WebService.ts" />
/// <reference path="../../Src/Core/MulticastDelegate.ts" />
/// <reference path="../../Src/Core/Page/Page.ts" />
/// <reference path="../../Src/Core/Page/Social/Facebook.ts" />
/// <reference path="../../Src/Core/Page/Social/Google.ts" />
/// <reference path="../../Src/Core/Page/Page.Google.AnalyticsService.ts" />
/// <reference path="../../Src/Core/Page/Page.Microsoft.ts" />
/// <reference path="../../Src/Core/Page/Page.Preloader.ts" />
/// <reference path="../../Src/Core/Page/Page.Diagnostic.ts" />
/// <reference path="../../Src/Core/AjaxHistory.ts" />
/// <reference path="../../Src/Core/PostMessage.ts" />
/// <reference path="../../Src/Core/Forms/Forms.ts" />
/// <reference path="../../Src/Core/Enumerable/JsObjectReader.ts" />
/// <reference path="../../Src/Core/Enumerable/SelectorReader.ts" />
/// <reference path="../../Src/Core/Enumerable/DomQuery.ts" />
/// <reference path="../../Src/Core/Colorspace.ts" />
/// <reference path="../../Src/Core/Animator.ts" />
/// <reference path="../../Src/Core/Preloaders.ts" />
/// <reference path="../../Src/Core/DataTable.ts" />
/// <reference path="../../Src/Core/Enumerable/List.ts" />
/// <reference path="../../Src/Core/Utility/Utility.StringCompressor.ts" />
/// <reference path="../../Src/Core/Security/SimpleEncryptor.ts" />
/// <reference path="../../Src/Core/UnitTesting/TestTools.UnitTesting.ts" />
/// <reference path="../../Src/Core/UnitTesting/TestTools.TestsRunner.ts" />
/// <reference path="../../Src/Core/Console.ts" />
/// <reference path="../../Src/Core/CacheProvider.ts" />
/// <reference path="../../Src/Core/Mvc/Mvc.ts" />
/// <reference path="../../src/core/Binding/Binding.d.ts" />
/// <reference path="../../Src/Core/Binding/BindingEnums.ts" />
/// <reference path="../../Src/Core/Binding/BindingSetup.ts" />
/// <reference path="../../Src/Core/Binding/BindingAttributes.ts" />
/// <reference path="../../Src/Core/Binding/BindingCache.ts" />
/// <reference path="../../Src/Core/Binding/BindingDataSource.ts" />
/// <reference path="../../Src/Core/Binding/BindingDictionaryTree.ts" />
/// <reference path="../../Src/Core/Binding/BindingElementPathResolver.ts" />
/// <reference path="../../Src/Core/Binding/BindingObservable.ts" />
/// <reference path="../../Src/Core/Web/CalystoVirtualPathHelper.ts" />
/// <reference path="../../Src/Core/DataAnnotations/CalystoValidationService.ts" />
/// <reference path="../../Src/Core/Web/Direct/UI/CalystoMvcModelState.ts" />
/// <reference path="../../Src/Core/WebView/HostObjectBase.ts" />
/// <reference path="../../src/core/type/type.ts" />
//************************************************************
// Calysto web controls
//************************************************************
/// <reference path="../../Src/Core/WebControls/Scroller/Scroller.ts" />
/// <reference path="../../Src/Core/WebControls/Table/Table.ts" />
//************************************************************
// TESTS
//************************************************************
/// <reference path="../../Src/Core/Enumerable/Collections.TEST.ts" />
/// <reference path="../../Src/Core/Enumerable/Enumerable.TEST.ts" />
/// <reference path="../../Src/Core/DateTime.TEST.ts" />
/// <reference path="../../Src/Core/Dictionary.TEST.ts" />
/// <reference path="../../Src/Core/Enum.TEST.ts" />
/// <reference path="../../Src/Core/Type/Type.TEST.ts" />
/// <reference path="../../Src/Core/Utility/Utility.TEST.ts" />
/// <reference path="../../Src/Core/extension/String.TEST.ts" />
/// <reference path="../../Src/Core/extension/Number.TEST.ts" />
/// <reference path="../../Src/Core/QueryString.TEST.ts" />
/// <reference path="../../Src/Core/Regex.TEST.ts" />
/// <reference path="../../Src/Core/json/JSON.JsonNode.TEST.ts" />
/// <reference path="../../Src/Core/net/Net.WebClient.TEST.ts" />
/// <reference path="../../Src/Core/Forms/Forms.TEST.ts" />
/// <reference path="../../Src/Core/Enumerable/DomQuery.TEST.ts" />
/// <reference path="../../Src/Core/Utility/Utility.StringCompressor.TEST.ts" />
/// <reference path="../../Src/Core/security/SimpleEncryptor.TEST.ts" />
/// <reference path="../../Src/Core/Validate.TEST.ts" />
/// <reference path="../../Src/Core/Uri.TEST.ts" />
/// <reference path="../../Src/Core/MulticastDelegate.TEST.ts" />
/// <reference path="../../Src/Core/Globalization/ResxExcelProvider.TEST.ts" />
/// <reference path="../../Src/Core/Tasks/CPromise.TEST.ts" />
/// <reference path="../../Src/Core/Tasks/CalystoMonitor.TEST.ts" />
/// <reference path="../../Src/Core/Tasks/TaskExtensions.TEST.ts" />
//# sourceMappingURL=EngineComplete.js.map