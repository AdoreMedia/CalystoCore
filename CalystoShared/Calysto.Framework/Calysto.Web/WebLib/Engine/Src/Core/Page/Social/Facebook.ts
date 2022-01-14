namespace Calysto.Page.Social.Facebook
{
	// https://developers.facebook.com/docs/reference/javascript/FB.getLoginStatus/
	// https://developers.facebook.com/docs/graph-api/reference/user
	// https://developers.facebook.com/docs/facebook-login/permissions

	/* COMPLETE TEST:
	export function fbCompleteLogin1()
	{
		// complete test
		let promise2 = new Calysto.Page.Social.Facebook.FacebookPromise()
			.Initialize("520024095463488")
			.Login()
			.LoadPermissions()
			.LoadPicture()
			.LoadProfile()
			.Then((state, value) =>
			{
				console.log(value);
				state.Success(value);
			});
	}
	*/

	function fbCreateTagLoaderOnce()
	{
		(function (d, s, id)
		{
			var localeStr = (Calysto.Globalization.CultureInfo.CurrentCulture.Name || "").replace("-", "_"); // hr-HR to hr_HR
			var js;
			var fjs = d.getElementsByTagName(s)[0];
			if (d.getElementById(id)) { return; } // will not create tag if already exists
			js = d.createElement(s); js.id = id;
			js.src = "//connect.facebook.net/" + (localeStr || "en_US") + "/sdk.js";
			js.async = "async";
			// fb locale: "en_US", "hr_HR", "sr_RS"
			//js.src = "//connect.facebook.net/" + window.facebookLocaleStr + "/all.js#xfbml=1&appId=" + window.facebookAppId;
			if (fjs && fjs.parentNode) fjs.parentNode.insertBefore(js, fjs);
		}(document, 'script', 'facebook-jssdk'));
	}

	async function fbInitializeEngineAsync(cancellationToken?: Calysto.Tasks.CancellationToken)
	{
		return await Tasks.TaskUtility.RunAsync<fb.FacebookStatic>(async () =>
		{
			fbCreateTagLoaderOnce();

			let end1 = Date.now() + 15 * 1000; // let's wait 15 seconds

			while (!cancellationToken?.IsCancellationRequested && Date.now() < end1)
			{
				let _fbInstance = window["FB"];

				if (!!_fbInstance && !!_fbInstance.init && !!_fbInstance.Event && !!_fbInstance.Event.subscribe)
				{
					return _fbInstance;
				}
				await Tasks.TaskUtility.SleepAsync(200, cancellationToken);
			}

			return <any> null;

		}, cancellationToken);
	}

	// https://developers.facebook.com/docs/reference/javascript/FB.getLoginStatus/
	function fbAssignEvents(provider: FacebookProvider)
	{
		let _fbInstance = window["FB"];

		// This method will be called after the user login into facebook.
		_fbInstance.Event.subscribe('auth.authResponseChange', (response: fb.StatusResponse) =>
		{
			// invoked eg. if customer is not logged in to facebook account and then he enters login data into popup window
			// provider.OnLoginResponse.Invoke(f => f(response));
			//console.log({ "auth.authResponseChange": response });
			if (provider.Data)
				provider.Data.StatusResponse = response;
		});

		_fbInstance.Event.subscribe('auth.statusChange', (response: fb.StatusResponse) =>
		{
			// invoked eg. if customer is not logged in to facebook account and then he enters login data into popup window
			// provider.OnLoginResponse.Invoke(f => f(response));
			//console.log({ "auth.statusChange": response });
			if (provider.Data)
				provider.Data.StatusResponse = response;
		});

		// edge.create not available any more, FB doesn't want to track if user has liked the page
		//// hook into the Event.subscribe to display the hidden content after the user likes the page
		//_fbInstance.Event.subscribe(<any>'edge.create', (...response: any[]) =>
		//{
		//	console.log({ "edge.create": response });
		//	//provider.OnLikeResponse.Invoke(f => f());
		//});
	}

	export interface fbProfile
	{
		error: string;
		email: string; // email@nn.com
		first_name: string; // Marco
		id: string; // fb userid
		last_name: string; // Bianco
		name: string; //"Marco Bianco"
		picture: fbPicture;
	}

	export interface fbPicture
	{
		error: string;
		data: fbPictureData;
	}

	export interface fbPictureData
	{
		height: number;
		is_silhouette: boolean;
		url: string;
		width: number;
	}

	export interface fbPermissions
	{
		error: string;
		data: fbPermissionsItem[];
	}

	export interface fbPermissionsItem
	{
		permission: string;
		status: string;
	}

	class FacebookData
	{
		public constructor()
		{
		}

		// mora se dohvacati instanca iz window.FB jer stara instanca ne radi, valjda je replaceaju
		public get FB() { return <fb.FacebookStatic>window["FB"];}

		public StatusResponse: fb.StatusResponse;

		public Profile: fbProfile;

		public Picture: fbPicture;

		public Permissions: fbPermissions;
	}

	export class FacebookProvider
	{
		public Data: FacebookData;
		public Error: any;
		////public readonly OnLoginResponse = new Calysto.MulticastDelegate<(response: fb.StatusResponse) => void>().AsFunc();
		////public readonly OnLikeResponse = new Calysto.MulticastDelegate<(response: fb.StatusResponse) => void>().AsFunc(); // not available any more

		private constructor(private facebookAppId: string, private scope?: string)
		{
		}

		static _cache = new Map<string, FacebookProvider>();

		public static GetProvider(facebookAppId: string, scope?: string)
		{
			let key1 = facebookAppId + "$$$" + scope;
			let pp = FacebookProvider._cache.get(key1);
			if (!pp)
			{
				pp = new FacebookProvider(facebookAppId, scope);
				FacebookProvider._cache.set(key1, pp);
			}
			return pp;
		}

		/**
		 * Load FB SDK.
		 * @param cancellationToken
		 */
		public async InitEngine(cancellationToken?: Tasks.CancellationToken)
		{
			if (this.Data)
				return true;

			return await Tasks.TaskUtility.RunAsync<boolean>(async () =>
			{
				let res = await fbInitializeEngineAsync(cancellationToken);
				if (res)
				{
					this.Data = new FacebookData();
					fbAssignEvents(this);
					return true;
				}
				else
				{
					return false;
				}
			}, cancellationToken);
		}

		/**
		 * Load FB SDK scripts and invoke FB.init() with current app (current facebookAppId).
		 * @param cancellationToken
		 */
		public async InitApp(cancellationToken?: Tasks.CancellationToken)
		{
			if (!await this.InitEngine(cancellationToken))
				return false;

			return await Tasks.TaskUtility.CallbackAsync<boolean>(callback =>
			{
				let fb1 = this.Data.FB;
				if (fb1["__fbInitDone"] != this.facebookAppId)
				{
					fb1["__fbInitDone"] = this.facebookAppId;

					// if we invoke FB.init, after some time it looses settings, so it has to be invoked again
					this.Data.FB.init({
						appId: this.facebookAppId,
						xfbml: true, // set to true if fb button are used with it's attributes, eg. 
						status: true, // if true, autoload data from fb on intialize
						cookie: true,
						version: 'v11.0'
					});
				}
				callback(true);

			}, cancellationToken);
		}

		public async GetLoginStatus(cancellationToken?: Tasks.CancellationToken)
		{
			if (this.Data?.StatusResponse)
				return this.Data.StatusResponse;

			if (!await this.InitApp(cancellationToken))
				return null;

			return await Tasks.TaskUtility.CallbackAsync<fb.StatusResponse>(resolve =>
			{
				if (this.Data?.FB?.getLoginStatus)
					this.Data?.FB?.getLoginStatus(resp =>
					{
						this.Data.StatusResponse = resp;
						resolve(resp);
					}, false);

				else
					resolve(<any>null);
			}, cancellationToken);
		}

		/** Is current user authenticated with current app (current facebookAppId) */
		public async IsAuthenticated()
		{
			let res1 = await this.GetLoginStatus();
			return res1 && res1.status == "connected";
		}

		/** Is current user authenticated to his FB account */
		public async IsFbAuthenticated()
		{
			let res1 = await this.GetLoginStatus();
			if (res1)
			{
				if (res1.status == "connected") // logged in to FB account and to our App, provjereno!!!
					return true; 
				else if (res1.status == "not_authorized") // logged in to FB account, not to our App, provjereno!!!!
					return true; 
				else if (res1.status == "authorization_expired") // logged in to FB account, not to out App
					return true;
				else if (res1.status == "unknown") // not logged in to FB account
					return false;
			}
			return false;
		}

		/**
		 * Login to current app (current facebookAppId)
		 * default scope: public_profile,email
		 * @param scope additional scope
		 */
		public async Login(cancellationToken?: Tasks.CancellationToken)
		{
			if (await this.IsAuthenticated())
				return true;
			else if (!await this.InitApp())
				return false;

			//console.log("Login #1");
			return await Tasks.TaskUtility.CallbackAsync<boolean>(resolve =>
			{
				let scopes1 = (this.scope || "").split(',')
					.AsEnumerable()
					.Select(o => o.Trim())
					.Concat(["public_profile", "email"])
					.Where(o => !!o)
					.Distinct()
					.ToStringJoined(",");

				//#if DEBUG
				if (Calysto.Core.IsDebugDefined)
				{
					console.log("fb#before-login");
				}
				//#endif

				//console.log("Login #2");
				this.Data.FB.login(resp =>
				{
					//console.log("Login #3");
					this.Data.StatusResponse = resp;
					if (resp.status == "connected")
					{
						//#if DEBUG
						if (Calysto.Core.IsDebugDefined)
							console.log("fb#login-success");
						//#endif
						resolve(true);
					}
					else
					{
						//#if DEBUG
						if (Calysto.Core.IsDebugDefined)
							console.log("fb#login-failed");
						//#endif
						this.Error = resp.status;
						resolve(false);
					}
				}, {
					enable_profile_selector: true,
					return_scopes: true,
					scope: scopes1
				});
			}, cancellationToken);
		}

		public async LoadProfile(cancellationToken?: Tasks.CancellationToken)
		{
			if (!await this.Login(cancellationToken))
				return false;

			Calysto.Core.DebugRun(() =>
			{
				//#if DEBUG
				console.log("fb#before-LoadProfile1");
				//#endif
			});

			return await Tasks.TaskUtility.CallbackAsync<boolean>(resolve => 
			{
				//#if DEBUG
				if (Calysto.Core.IsDebugDefined)
					console.log("fb#before-LoadProfile2");
				//#endif

				try
				{
					this.Data.FB.api("/me", { fields: "id,name,gender,email,birthday,verified,picture,locale,link,first_name,last_name,age_range,hometown,photos" }, resp =>
					{
						//#if DEBUG
						if (Calysto.Core.IsDebugDefined)
							console.log("fb#loaded-LoadProfile");
						//#endif

						this.Data.Profile = <fbProfile>resp;
						resolve(true);
					});
				}
				catch (e1)
				{
					this.Error = e1;
					resolve(false);
				}
			}, cancellationToken);
		}

		public async LoadPicture(cancellationToken?: Tasks.CancellationToken)
		{
			if (!await this.Login(cancellationToken))
				return false;

			Calysto.Core.DebugRun(() =>
			{
				//#if DEBUG
				console.log("fb#before-LoadPicture1");
				//#endif
			});

			return await Tasks.TaskUtility.CallbackAsync<boolean>(resolve =>
			{
				//#if DEBUG
				if (Calysto.Core.IsDebugDefined)
					console.log("fb#before-LoadPicture2");
				//#endif
				try
				{
					// moze se dohvatiti sa osnovnim permissionima: public_profile,email
					this.Data.FB.api("/me/picture", { redirect: false, height: 300, width: 300 }, resp =>
					{
						this.Data.Picture = <fbPicture>resp;
						resolve(true);
					});
				}
				catch (e1)
				{
					this.Error = e1;
					resolve(false);
				}
			}, cancellationToken);
		}

		public async LoadPermissions(cancellationToken?: Tasks.CancellationToken)
		{
			if (!await this.Login(cancellationToken))
				return false;

			Calysto.Core.DebugRun(() =>
			{
				//#if DEBUG
				console.log("fb#before-LoadPermissions1");
				//#endif
			});

			return await Tasks.TaskUtility.CallbackAsync<boolean>(resolve =>
			{
				//#if DEBUG
				if (Calysto.Core.IsDebugDefined)
					console.log("fb#before-LoadPermissions2");
				//#endif

				try
				{
					// moze se dohvatiti sa osnovnim permissionima: public_profile,email
					this.Data.FB.api("/me/permissions", resp =>
					{
						this.Data.Permissions = <fbPermissions>resp;
						resolve(true);
					});
				}
				catch (e1)
				{
					this.Error = e1;
					resolve(false);
				}
			}, cancellationToken);
		}
	}
}
