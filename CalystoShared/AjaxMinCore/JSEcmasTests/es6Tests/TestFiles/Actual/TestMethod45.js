var Calysto;(function(Calysto){var Tasks;(function(Tasks){class CPromise{constructor(executor){if(this.executor=executor,this.executor){try{this.executor(value=>this.notifyResolved(value),value=>this.notifyRejected(value))}catch(ex){this.notifyRejected(ex)}}}notifyResolved(value){this._isResolved=!0;this._resolveValue=value,this.notifyNext()}notifyRejected(value){this._isRejected=!0;this._rejectValue=value,this.notifyNext()}notifyNext(){this._nextPromise&&!this._isNextNotified&&(this._isRejected&&this._nextPromise._onPreviousFailed?(this._isNextNotified=!0,this._nextPromise._onPreviousFailed(this._rejectValue),this._nextPromise.notifyNext()):this._isResolved&&this._nextPromise._onPreviousSuccess&&(this._isNextNotified=!0,this._nextPromise._onPreviousSuccess(this._resolveValue),this._nextPromise.notifyNext()))}then(onResolved,onRejected){let next=new CPromise;next._onPreviousSuccess=previousValue=>{try{if(previousValue&&previousValue.then){let p1=previousValue;p1.then(v1=>next._onPreviousSuccess(v1),e1=>next._onPreviousFailed(e1));return}onResolved||(onResolved=x=>x);let currValue=onResolved(previousValue);if(currValue&&currValue.then){let currPromise=currValue;currPromise.then(value=>{next.notifyResolved(value)},err=>{next.notifyRejected(err)})}else next.notifyResolved(currValue)}catch(e1){next.notifyRejected(e1)}};next._onPreviousFailed=previsousError=>{try{onRejected||(onRejected=x=>{throw x;});let currErr=onRejected(previsousError);if(currErr&&currErr.then){let currPromise=currErr;currPromise.then(value=>{next.notifyResolved(value)},err=>{next.notifyRejected(err)})}else next.notifyResolved(currErr)}catch(e1){next.notifyRejected(e1)}},this._nextPromise=next,this.notifyNext();return next}catch(fn){return this.then(v=>v,fn||(x=>x))}finally(fn){return this.then(fn?x=>{fn();return x}:x=>x,fn?x=>{fn();throw x;}:x=>x)}static resolve(value){return new CPromise(resolve=>{resolve(value)})}static reject(value){return new CPromise((resolve,reject)=>{reject(value)})}}Tasks.CPromise=CPromise;window.Promise||(window.Promise=CPromise)})(Tasks=Calysto.Tasks||(Calysto.Tasks={}))})(Calysto||(Calysto={}))