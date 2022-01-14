namespace Calysto.Tasks.TaskUtility
{
	const _tokenCancelled = "TokenCancellationRequested";

	// simple SleepAsync:
	// function SleepAsync(durationMs) { return new Promise<void>(function (resolve, reject) { setTimeout(function () { resolve() }, durationMs); }); }

	export function SleepAsync(durationMs: number, cancellationToken?: CancellationToken)
	{
		if (!cancellationToken)
		{
			return new Promise<void>(function (resolve, reject) { setTimeout(function () { resolve() }, durationMs); });
		}
		else
		{
			return new Promise<void>((resolve, reject) =>
			{
				if (cancellationToken?.IsCancellationRequested)
				{
					reject(_tokenCancelled);
				}
				else
				{
					let timeoutId: number;

					let cbRegistration = cancellationToken?.Register(() =>
					{
						cbRegistration?.Unregister();
						clearTimeout(timeoutId);
						reject(_tokenCancelled);
					});

					timeoutId = setTimeout(() =>
					{
						cbRegistration?.Unregister();

						if (cancellationToken?.IsCancellationRequested)
							reject(_tokenCancelled);
						else
							resolve();

					}, durationMs);
				}
			});
		}
	}

	/**
	 * 
	 * @param executor must have async to return promise.
	 * @param cancellationToken
	 */
	export function RunAsync<TResult>(executor: () => Promise<TResult>, cancellationToken?: CancellationToken)
	{
		return new Promise<TResult>(async (resolve, reject) =>
		{
			if (cancellationToken?.IsCancellationRequested)
			{
				reject(_tokenCancelled);
			}
			else
			{
				let cbRegistration = cancellationToken?.Register(() =>
				{
					cbRegistration?.Unregister();
					reject(_tokenCancelled);
				});

				try
				{
					let result1 = await executor();

					if (cancellationToken?.IsCancellationRequested)
						reject(_tokenCancelled);
					else
						resolve(result1);
				}
				finally
				{
					cbRegistration?.Unregister();
				}
			}
		});
	}

	/**
	 * To return from await, resolveCallback(result) has to be invoked inside executor method.
	 * @param executor executor: (resolveCallback(result)=>void)=>void
	 */
	export function CallbackAsync<TResult>(executor: (resolveCallback: (result: TResult) => void) => void, cancellationToken?: CancellationToken)
	{
		return new Promise <TResult>((resolve, reject) =>
		{
			if (cancellationToken?.IsCancellationRequested)
			{
				reject(_tokenCancelled);
			}
			else
			{
				let cbRegistration = cancellationToken?.Register(() =>
				{
					cbRegistration?.Unregister();
					reject(_tokenCancelled);
				});

				try
				{
					executor(result =>
					{
						cbRegistration?.Unregister();

						if (cancellationToken?.IsCancellationRequested)
							reject(_tokenCancelled);
						else
							resolve(result);
					});
				}
				finally
				{
					cbRegistration?.Unregister();
				}
			}
		});
	}

	const _timeoutLabel = "TimeoutInTimeoutAsync#9848768901948621";

	export async function TimeoutAsync<TResult>(promise1: Promise<TResult>, timeoutMs: number)
	{
		let tokenSource = new CancellationTokenSource();
		try
		{
			let sleep1 = new Promise(async (resolve, reject) =>
			{
				await TaskUtility.SleepAsync(timeoutMs, tokenSource.Token);
				resolve(_timeoutLabel);
			});

			let result3 = await Promise.race([promise1, <any>sleep1]);

			if (result3 == _timeoutLabel)
			{
				throw new Error(`Promise timeouted after ${timeoutMs} ms`);
			}
			else
			{
				return result3;
			}
		}
		finally
		{
			tokenSource.Dispose();
		}
	};

}
