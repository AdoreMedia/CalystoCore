using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Calysto.Threading.Tasks
{
	public class TaskCompletionConditional<TValue>
	{
		private TaskCompletionSource<TValue> _completionSource = new TaskCompletionSource<TValue>();
		public Task Task => _completionSource.Task;

		public TValue Value { get; private set; }

		private bool _isCompleted;
		private Func<TValue, bool> _fnCompletedCondition;
		private Func<TValue, TValue> _fnOnIcrementOne;
		private Func<TValue, TValue> _fnOnDecrementOne;

		public TaskCompletionConditional(TValue intialValue, 
			Func<TValue, bool> fnCompletedCondition,
			Func<TValue, TValue> fnOnIcrementOne,
			Func<TValue, TValue> fnOnDecrementOne)
		{
			_fnCompletedCondition = fnCompletedCondition;
			_fnOnIcrementOne = fnOnIcrementOne;
			_fnOnDecrementOne = fnOnDecrementOne;
		}

		public void IncrementOne()
		{
			lock (this)
			{
				if (_isCompleted)
					return;

				this.Value = _fnOnIcrementOne.Invoke(this.Value);
				_isCompleted = _fnCompletedCondition.Invoke(this.Value);
			}

			if (_isCompleted)
				_completionSource.SetResult(this.Value);
		}

		public void DecrementOne()
		{
			lock (this)
			{
				if (_isCompleted)
					return;

				this.Value = _fnOnDecrementOne.Invoke(this.Value);
				_isCompleted = _fnCompletedCondition.Invoke(this.Value);
			}

			if (_isCompleted)
				_completionSource.SetResult(this.Value);
		}
	}
}
