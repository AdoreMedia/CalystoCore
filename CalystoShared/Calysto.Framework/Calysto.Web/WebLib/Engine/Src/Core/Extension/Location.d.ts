interface Location
{
	/** hash part eg. #first if url is http://Calysto.test/support?name=gsdf#first */
	hash: string;

	host: string;

	/** eg. Calysto.test:1233 if url is http://Calysto.test:1233/support?name=gsdf#first */
	hostname: string;

	/** complete url, eg. http://Calysto.test/support?name=gsdf#first */
	href: string;

	/** http domain only, eg. http://Calysto.test, if complete url is http://Calysto.test/support?name=gsdf#first */
	readonly origin: string;

	/** path only eg. /support if complete url is http://Calysto.test/support?name=gsdf#first */
	pathname: string;

	/** port number as string */
	port: string;

	/** eg. http: or https: */
	protocol: string;

	/** query string only, eg. ?name=gsdf if url is http://Calysto.test/support?name=gsdf#first */
	search: string;

	assign(url: string): void;

	/** 
	* Reload current location.
	* @param forcedReload
	*		false - Default. Reloads the current page from the cache
	*		true - Reloads the current page from the server
	*/
	reload(forcedReload?: boolean): void;

	/** 
	* Navigate to the new url.
	*/
	replace(url: string): void;
}

