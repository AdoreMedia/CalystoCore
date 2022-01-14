namespace Calysto.Mvc
{
	export class CalystoSpinner
	{
		private constructor()
		{
		}

		/**
		 * Start spinner inside container, execute executor, remove spinner, return result from executor.
		 * @param containerSelector
		 * @param executor
		 */
		static async UseSpinnerAsync<TReturn>(containerSelector: string | HTMLElement, executor: () => Promise<TReturn>)
		{
			let spinner1 = CalystoSpinner.Start(containerSelector, false);
			try
			{
				return await executor();
			}
			finally
			{
				spinner1.Remove();
			}
		}

		/**
		* Search for calysto-spinner elements inside container and use them.
	    * Spinner will be removed on first ajax response received.
		* @param containerSelector
		* @param autoRemoval
		*/
		public static Start(containerSelector: string | HTMLElement, autoRemoval: boolean)
		{
			let disabledElements = $$calysto(containerSelector).Query("//button, //a").WhereEnabled(true).SetEnabled(false);

			let spinners = $$calysto(containerSelector).Query<HTMLElement>("//div.calysto-spinner").ToArray();
			let timers: Calysto.Timer[] = [];

			for (let spinner1 of spinners)
			{
				let spinnerDelay = parseInt(<string>spinner1.getAttribute("calysto-spinner-delay")) || 300;

				let timer = new Calysto.Timer(s2 =>
				{
					spinner1.className += " calysto-visible";
				}).Start(spinnerDelay);

				timers.push(timer);
			}

			let spinner1 = new CalystoSpinner();
			let cb1 = spinner1.Remove = () =>
			{
				for (let timer of timers)
					timer?.Abort();

				spinners.AsEnumerable().AsDomQuery().RemoveClass("calysto-visible");

				disabledElements.SetEnabled(true);
			};

			if (autoRemoval)
				Page.OnEndResponse.MCD.AddOnce(cb1);

			return spinner1;
		}

		public Remove() { }
	}
}


