namespace Converters
{
	export function ItemIndexConverter(cx: Calysto.Binding.IDataListenerContext, dsValue: any)
	{
		return `This is index value ${dsValue} in context data path ${cx.DataPath}`;
	}
}

namespace Calysto.Genesis.WebTest.CalystoWebControlsTests.CalystoBindable3.Web
{
	declare let factory1: Calysto.Binding.Setup.BindingFactory;
	declare let model1: any;

	var mm = new Calysto.Binding.BindingObservable()
		.SetFactory(factory1)
		.SetDataSource(model1)
		.DataBind();

	//setTimeout(() => mm.SetValue("Ready", true), 1000);
}

