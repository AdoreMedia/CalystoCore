//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Threading.Tasks;

//namespace Calysto.Threading.Tasks
//{
//    /// <summary>
//    /// Create unstarted task which may be started later.
//    /// </summary>
//    /// <typeparam name="TResult"></typeparam>
//    public class PendingTask<TResult>
//    {
//        TResult _result;
//        public Task<TResult> Task { get; }

//        public PendingTask()
//        {
//            this.Task = new Task<TResult>(() => this._result);
//        }

//        public void Start(TResult result)
//        {
//            this._result = result;
//            this.Task.Start();
//        }
//    }
//}
