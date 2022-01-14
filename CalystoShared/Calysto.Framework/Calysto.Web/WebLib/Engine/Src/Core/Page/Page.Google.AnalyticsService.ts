namespace Calysto.Page.Google
{
	export class AnalyticsService
	{
		// SPA analytics:
		// https://developers.google.com/analytics/devguides/collection/gtagjs/custom-dims-mets
		// https://developers.google.com/analytics/devguides/collection/gtagjs/single-page-applications

		// original tag:
		//<%--eRegistar.hr global site tag (gtag.js) - Google Analytics -- %>
		//<script async="async" src= "https://www.googletagmanager.com/gtag/js?id=UA-110466768-1" > </script>
		//<script>
		//		window.dataLayer = window.dataLayer || [];
		//		function gtag() { dataLayer.push(arguments); }
		//		gtag('js', new Date());
		//		gtag('config', 'UA-110466768-1');
		//</script>

		private gtag(...args: any[])
		{
			let dataLayer = window["dataLayer"] = window["dataLayer"] || [];
			dataLayer.push(arguments);
		}

		constructor(private trackingId: string)
		{
		}

		private EnsureEngineLoaded()
		{
			Calysto.ScriptLoader.LoadJsFileOnce("https://www.googletagmanager.com/gtag/js?id=" + this.trackingId, "google-analytics-" + this.trackingId);
		}

		/**
		 * Hit ajax page view.
		 * @param pagePath
		 *		eg. /new-page.html
		 *		if not set, will hit current page
		 */
		public HitPageView(pagePath?: string)
		{
			this.EnsureEngineLoaded();

			this.gtag('js', new Date());

			// gtag('config', 'GA_TRACKING_ID', {'page_path': '/new-page.html'});
			if (pagePath)
				this.gtag('config', this.trackingId, { 'page_path': pagePath });
			else
				this.gtag('config', this.trackingId); // hit current page

			return this;
		}
	}
}
