namespace Calysto.Page.Microsoft
{
		// https://clarity.microsoft.com/projects/view/

		/* original tag:
		<script type="text/javascript">
			(function(c,l,a,r,i,t,y){
				c[a]=c[a]||function(){(c[a].q=c[a].q||[]).push(arguments)};
				t=l.createElement(r);t.async=1;t.src="https://www.clarity.ms/tag/"+i;
				y=l.getElementsByTagName(r)[0];y.parentNode.insertBefore(t,y);
			})(window, document, "clarity", "script", "5jj7elzie0");
		</script>
		*/

	export class ClarityProvider
	{
		public constructor(private clarityId: string)
		{
		}

		private EnsureEngineLoaded(clarityId)
		{
			(function (c, l, a, r, i, t?:any, y?:any)
			{
				c[a] = c[a] || function () { (c[a].q = c[a].q || []).push(arguments) };
				Calysto.ScriptLoader.LoadJsFileOnce("https://www.clarity.ms/tag/" + i, "ms-clarity-" + i);
			})(window, document, "clarity", "script", clarityId);
		}

		public Start()
		{
			this.EnsureEngineLoaded(this.clarityId);
		}
	}
}
