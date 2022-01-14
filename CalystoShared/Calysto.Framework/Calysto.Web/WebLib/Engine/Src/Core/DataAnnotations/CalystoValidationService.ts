/// <reference path="calystovalidators.ts" />
namespace Calysto.DataAnnotations
{
	export interface IValidator
	{
		ErrorText: string;
		IsValid: (value: any) => boolean;
	}

	export interface IValidationElement extends HTMLInputElement
	{
		$$validationInitialized: boolean;
		$$validationContainer: HTMLFormElement;
		$$validationValidators: IValidator[];
		$$validationContext: IValidationContext;
	}

	interface IValidationContainer extends HTMLFormElement
	{
		$$validationGuid: string;
	}

	interface ErrorMessage
	{
		/** full path Prop1.Prop2.Prop3 */
		FormsNamePath: string;
		ErrorText: string;
	}

	export interface IValidationContext
	{
		inputsArr: IValidationElement[];
		form: HTMLFormElement;
		/** input, textarea, select elements for validation */
		inputs: { [name: string]: IValidationElement }
		/** placeholders for error messages */
		spans: { [name: string]: HTMLSpanElement },
		/** summary div element */
		summary: HTMLDivElement[],
		/** current errors */
		errors: ErrorMessage[],
		isInteractive: boolean
	}

	class CalystoValidationService
	{
		public constructor(public readonly Context: IValidationContext)
		{
		}

		/** validate form */
		public Validate()
		{
			this.Context.errors.Clear();

			for (let name in this.Context.inputs)
				RunValidationSingle(this.Context, this.Context.inputs[name]);

			return this;
		}

		/** Render errors */
		public Render()
		{
			RenderErrorsWorker(this.Context);
			return this;
		}

		public HasErrors() { return this.Context.errors.Any() }

		/**
		 * If enabled, will validate during text entering.
		 * If not enabled, will validate before form submit only.
		 * @param enable
		 */
		public Interactive(enable: boolean)
		{
			this.Context.isInteractive = !!enable;
			if(enable)
				InitializeInteractiveValidation(this.Context);
			return this;
		}
	}

	function FindContainerForm(sender: IValidationElement)
	{
		if (!sender.$$validationContainer)
		{
			if (sender.tagName.toLowerCase() == "form")
				sender.$$validationContainer = <HTMLFormElement><any>sender;
			else
				sender.$$validationContainer = <HTMLFormElement>$$calysto(sender).AncestorNodes("form").First();
		}

		return <IValidationContainer>sender.$$validationContainer;
	}

	/**
	* Find parent form and create new CalystoValidationService where form is container.
    * Returns null if client side validation is not enabled.
	* @param element
	*/
	export function FindValidationService(element: HTMLElement)
	{
		let form = FindContainerForm(<IValidationElement>element);
		return UseValidationService(form);
	}

	export function UseValidationService(containerSelector: string | HTMLElement)
	{
		let form = $$calysto<IValidationContainer>(containerSelector).First();
		let context = GetOrCreateValidationContext(form);
		return new CalystoValidationService(context);
	}

	let _contextCache: { [key: string]: IValidationContext } = {};

	function GetOrCreateValidationContext(form: IValidationContainer)
	{
		let guid = form.$$validationGuid || (form.$$validationGuid = Calysto.Utility.Generators.GenerateLabel(20));
		let context = _contextCache[guid] || (_contextCache[guid] = <IValidationContext>{});

		context.form = form;
		context.errors = context.errors || [];
		context.inputsArr = $$calysto(form).Query<IValidationElement>("//[data-val=true][name]").ToArray();

		// input, textarea, select
		context.inputs = $$calysto(context.inputsArr).ToRawObject(o => o.name);

		// placeholders for error messages
		context.spans = $$calysto<HTMLSpanElement>("[data-valmsg-for]").ToRawObject(o => o.getAttribute("data-valmsg-for"), o => o);

		// validation summary
		context.summary = $$calysto<HTMLDivElement>("[data-valmsg-summary]").ToArray();

		return context;
	}

	function InitializeInteractiveValidation(context: IValidationContext)
	{
		// assing events if they are not assigned
		$$calysto(context.inputsArr)
			.Where(o => !o.$$validationInitialized)
			.ForEach(o => o.$$validationInitialized = true)
			.ForEach(o => o.$$validationContext = context)
			////.OnChange((sender, ev) => RunValidationSingle(sender))
			.OnInput((sender, ev) =>
			{
				if (!context.isInteractive)
					return;

				//#if DEBUG
				if (Calysto.Core.IsDebugDefined)
				{
					//console.log(sender.name, ev.type);
				}
				//#endif

				RunValidationSingle(context, sender);

				RenderErrorsWorker(context);

			}); // all elements have this event, after paste, ddl change
	}

	function RunValidationSingle(context: IValidationContext, sender: IValidationElement)
	{
		//#if DEBUG
		if (Calysto.Core.IsDebugDefined)
		{
		//	console.log("RunValidation@ " + sender.name + ": " + sender.value);
		}
		//#endif

		context.errors.RemoveBy(o => o.FormsNamePath == sender.name);

		// empty string must be converted to null for validations to work properly (it is logic from C# validators)
		let value1 = sender.value === "" ? null : sender.value;

		// it is important to keep the same order as in data model, but seem that attributes are backwarded
		let validators = sender.$$validationValidators || (sender.$$validationValidators = Validators.GetValidators(sender, context).Reverse());
		for (let validator of validators)
		{
			if (!validator.IsValid(value1))
			{
				context.errors.Add({
					FormsNamePath: sender.name,
					ErrorText: validator.ErrorText
				});
			}
		}

		//#if DEBUG
		if (Calysto.Core.IsDebugDefined)
		{
		//	console.log(context.errors);
		}
		//#endif
	}

	function RenderErrorsWorker(context: IValidationContext)
	{
		let state = new Calysto.Web.UI.Direct.CalystoMvcModelState();
		state.RootSelector = context.form;
		for (let err1 of context.errors)
			state.Errors.push(new KeyValue(err1.FormsNamePath, err1.ErrorText));

		state.Render();
	}

}
