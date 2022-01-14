namespace Calysto.Page.Social.Google
{
	// https://console.cloud.google.com/home/dashboard
	// https://console.cloud.google.com/apis/credentials
	// https://developers.google.com/identity/sign-in/web/reference

	/*	COMPLETE TEST:
	export function GoogleCompleteLogin1()
	{
		let promise1 = new Calysto.Page.Social.Google.GooglePromise()
			.Initialize()
			.LoadAuth2("AIzaSyCRzDlVMG8_EHhIjwyqDApaLWKMBjRGrRM", "658661145263-qah8cdjjb5idbo2ovt90msr3nsr4kvh1.apps.googleusercontent.com")
			.Login()
			.Then((state, value) =>
			{
				console.log("Google final:");
				console.log(value);

			}, (state, error) =>
			{
				console.log(error);
			});
	}
	*/

	function fnCreateTagLoaderOnce()
	{
		(function (d, s, id)
		{
			var js;
			var fjs = d.getElementsByTagName(s)[0];
			if (d.getElementById(id)) { return; } // will not create tag if already exists
			js = d.createElement(s); js.id = id;
			js.src = "https://apis.google.com/js/platform.js";
			js.async = "async";
			if (fjs && fjs.parentNode) fjs.parentNode.insertBefore(js, fjs);
		}(document, 'script', 'google-platform'));
	}

	async function fnInitializeEngineAsync(cancellationToken?: Tasks.CancellationToken)
	{
		return await Tasks.TaskUtility.RunAsync<boolean>(async () =>
		{
			fnCreateTagLoaderOnce();

			let end1 = Date.now() + 15000; //15 seconds
			while (!cancellationToken?.IsCancellationRequested && Date.now() < end1)
			{
				let _gapi = window["gapi"];

				if (_gapi && !!_gapi.load)
				{
					return true;
				}
				await Tasks.TaskUtility.SleepAsync(200, cancellationToken);
			}
			return false;

		}, cancellationToken);
	}

	interface googleSettings
	{
		apiKey: string;
		clientId: string;
		scope: string;
		discoveryDocs: string[];
	}

	interface googleBasicProfile
	{
		Id: string;
		Name: string;
		GivenName: string;
		FamilyName: string;
		ImageUrl: string;
		Email: string;
	}

	interface googleAuthData
	{
		AuthResponse: gapi.auth2.AuthResponse;
		GrantedScopes: string;
		isSignedIn: boolean;
		UserId: string;
	}

	function fnExtractBasicProfileData(obj: gapi.auth2.BasicProfile): googleBasicProfile
	{
		return ({
			Id: obj.getId(),
			Name: obj.getName(),
			GivenName: obj.getGivenName(),
			FamilyName: obj.getFamilyName(),
			ImageUrl: obj.getImageUrl(),
			Email: obj.getEmail()
		});
	}

	class GoogleData
	{
		public GoogleUser: gapi.auth2.GoogleUser;
		public BasicProfile: googleBasicProfile;
		public Data: googleAuthData;
	}

	let _defaultScope = "https://www.googleapis.com/auth/userinfo.profile https://www.googleapis.com/auth/userinfo.email https://www.googleapis.com/auth/plus.me";

	function fnCreateScopes(scope?: string)
	{
		if (scope)
			return _defaultScope + " " + scope;
		else
			return _defaultScope;
	}

	export class GoogleProvider
	{
		public Data: GoogleData;
		public Error: any;

		private constructor(private apiKey: string, private clientId: string, private scope?: string)
		{
		}

		static _cache = new Map<string, GoogleProvider>();

		public static GetProvider(apiKey: string, clientId: string, scope?: string)
		{
			let key1 = apiKey + "$$$" + clientId + "$$$" + scope;
			let pp = GoogleProvider._cache.get(key1);
			if (!pp)
			{
				pp = new GoogleProvider(apiKey, clientId, scope);
				GoogleProvider._cache.set(key1, pp);
			}
			return pp;
		}

		public async InitEngine(cancellationToken?: Tasks.CancellationToken)
		{
			if (this.Data)
				return true;

			return await Tasks.TaskUtility.RunAsync<boolean>(async () => 
			{
				if(await fnInitializeEngineAsync(cancellationToken))
				{
					this.Data = new GoogleData();
					return true;
				}
				else
				{
					return false;
				}
			}, cancellationToken);
		}

		public async InitApp(cancellationToken?: Tasks.CancellationToken)
		{
			if (!await this.InitEngine(cancellationToken))
				return false;

			return await Tasks.TaskUtility.CallbackAsync<boolean>(async resolve =>
			{
				if (!!window["gapi"] && !!gapi.load && !!gapi.auth2 && !!gapi.auth2.init)
				{
					resolve(true);
					return;
				}

				let apiKey = this.apiKey;
				let clientId = this.clientId;
				let scope = this.scope;

				// Load "client" & "auth2" libraries
				gapi.load('client:auth2', {
					callback: function ()
					{
						// Initialize client library
						// clientId & scope is provided => automatically initializes auth2 library
						gapi.client.init({
							apiKey: apiKey,
							clientId: clientId,
							scope: fnCreateScopes(scope)
						}).then(
							// On success
							function (success)
							{
								//#if DEBUG
								if (Calysto.Core.IsDebugDefined)
									console.log({ "google#success_LoadAuth2": success });
								//#endif
								resolve(true);
							},
							// On error
							function (error)
							{
								//#if DEBUG
								if (Calysto.Core.IsDebugDefined)
									console.log(error);
								//#endif
								resolve(false);
							}
						);
					},
					onerror: function (error)
					{
						// Failed to load libraries
						resolve(false);
					}
				});
			}, cancellationToken);
		}

		public async IsAuthenticated()
		{
			return this.Data?.GoogleUser?.isSignedIn();
		}

		public async Login(cancellationToken?: Tasks.CancellationToken)
		{
			if (await this.IsAuthenticated())
				return true;
			else if (!await this.InitApp(cancellationToken))
				return false;

			return await Tasks.TaskUtility.CallbackAsync<boolean>(resolve =>
			{
				//#if DEBUG
				if (Calysto.Core.IsDebugDefined)
					console.log({ "google#Login": this.Data });
				//#endif

				gapi.auth2.getAuthInstance().signIn().then((success) =>
				{
					//#if DEBUG
					if (Calysto.Core.IsDebugDefined)
						console.log({ "google#success-Login": success });
					//#endif

					this.Data.GoogleUser = success;

					this.Data.Data = {
						AuthResponse: success.getAuthResponse(),
						GrantedScopes: success.getGrantedScopes(),
						isSignedIn: success.isSignedIn(),
						UserId: success.getId()
					};

					resolve(true);

					//console.log(success.getBasicProfile());
					//console.log(gapi.auth2.getAuthInstance().currentUser.get().getBasicProfile());

				}, (error) =>
				{
						resolve(false);
				});
			}, cancellationToken);
		}

		public async LoadProfile(cancellationToken?: Tasks.CancellationToken)
		{
			if (!await this.Login(cancellationToken))
				return false;

			return await Tasks.TaskUtility.RunAsync<boolean>(async () =>
			{
				//#if DEBUG
				if (Calysto.Core.IsDebugDefined)
					console.log({ "google#LoadProfile": this.Data});
				//#endif

				this.Data.BasicProfile = fnExtractBasicProfileData(this.Data.GoogleUser.getBasicProfile());

				return true;

			}, cancellationToken);
		}
	}
}


