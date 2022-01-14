//using System;
//using System.Threading;
//using System.Threading.Tasks;

//namespace Calysto.Threading.Tasks
//{
//	public class TaskPromise<TResult>
//	{
//		bool _isCompleted;
//		TResult _result;
//		bool _isNextInvoked;
//		CancellationToken _token;

//		private void OnComplete(TResult result)
//		{
//			lock (this)
//			{
//				if (!_isCompleted)
//				{
//					_isCompleted = true;
//					_result = result;
//					if (!_isNextInvoked && _nextAction != null)
//					{
//						_isNextInvoked = true;
//						_nextAction.Invoke();
//					}
//				}
//			}
//		}

//		public TaskPromise(Action<Action<TResult>> executor)
//		{
//			this.Run(executor, new CancellationTokenSource().Token);
//		}

//		public TaskPromise(Action<Action<TResult>> executor, CancellationToken token)
//		{
//			this.Run(executor, token);
//		}

//		private void Run(Action<Action<TResult>> executor, CancellationToken token)
//		{
//			this._token = token;

//			if (executor != null)
//				Task.Run(() => executor?.Invoke(this.OnComplete), token);
//		}

//		private Action _nextAction;

//		/// <summary>
//		/// (previousResult, state) => {... state.NotifySuccess(result2)}
//		/// </summary>
//		/// <typeparam name="TNextResult"></typeparam>
//		/// <param name="executor"></param>
//		/// <returns></returns>
//		public TaskPromise<TNextResult> Then<TNextResult>(Action<TResult, Action<TNextResult>> executor)
//		{
//			var pp = new TaskPromise<TNextResult>(null, this._token);

//			this._nextAction = () => Task.Run(() => executor.Invoke(this._result, result => pp.OnComplete(result)), this._token);

//			lock (this)
//			{
//				if (this._isCompleted && !this._isNextInvoked)
//				{
//					this._isNextInvoked = true;
//					this._nextAction.Invoke();
//				}
//			}

//			return pp;
//		}

//		public async Task<TResult> ResultAsync()
//		{
//			TResult result = default;
//			Task<TResult> task = new Task<TResult>(() => result);

//			TaskPromise<object> tt = this.Then<object>((prevResult, state) => {
//				result = prevResult;
//				task.Start();
//			});

//			return await task;
//		}
//	}
//}

