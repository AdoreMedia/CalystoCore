var Calysto;
(function (Calysto) {
    var Tasks;
    (function (Tasks) {
        /**
         *  Promise implementation for IE <= 11 where Promise is not implemented
         *  Complete implementation compatible with window.Promise
         */
        class CPromise {
            constructor(executor) {
                this.executor = executor;
                if (this.executor) {
                    try {
                        this.executor(value => this.notifyResolved(value), value => this.notifyRejected(value));
                    }
                    catch (ex) {
                        this.notifyRejected(ex);
                    }
                }
            }
            notifyResolved(value) {
                this._isResolved = true;
                this._resolveValue = value;
                this.notifyNext();
            }
            notifyRejected(value) {
                this._isRejected = true;
                this._rejectValue = value;
                this.notifyNext();
            }
            notifyNext() {
                if (this._nextPromise && !this._isNextNotified) {
                    if (this._isRejected && this._nextPromise._onPreviousFailed) {
                        this._isNextNotified = true;
                        this._nextPromise._onPreviousFailed(this._rejectValue);
                        this._nextPromise.notifyNext();
                    }
                    else if (this._isResolved && this._nextPromise._onPreviousSuccess) {
                        this._isNextNotified = true;
                        this._nextPromise._onPreviousSuccess(this._resolveValue);
                        this._nextPromise.notifyNext();
                    }
                }
            }
            then(onResolved, onRejected) {
                let next = new CPromise();
                next._onPreviousSuccess = (previousValue) => {
                    try {
                        // if Promise ctor executor returns Promise
                        if (previousValue && previousValue.then) {
                            let p1 = previousValue;
                            p1.then(v1 => next._onPreviousSuccess(v1), e1 => next._onPreviousFailed(e1));
                            return;
                        }
                        if (!onResolved)
                            onResolved = x => x;
                        // if onResolved returns Promise
                        let currValue = onResolved(previousValue);
                        if (currValue && currValue.then) {
                            let currPromise = currValue;
                            currPromise.then(value => {
                                next.notifyResolved(value);
                            }, err => {
                                next.notifyRejected(err);
                            });
                        }
                        else {
                            next.notifyResolved(currValue);
                        }
                    }
                    catch (e1) {
                        next.notifyRejected(e1);
                    }
                };
                next._onPreviousFailed = (previsousError) => {
                    try {
                        if (!onRejected)
                            onRejected = x => { throw x; };
                        let currErr = onRejected(previsousError);
                        if (currErr && currErr.then) {
                            let currPromise = currErr;
                            currPromise.then(value => {
                                next.notifyResolved(value);
                            }, err => {
                                next.notifyRejected(err);
                            });
                        }
                        else {
                            next.notifyResolved(currErr);
                        }
                    }
                    catch (e1) {
                        next.notifyRejected(e1);
                    }
                };
                this._nextPromise = next;
                this.notifyNext();
                return next;
            }
            catch(fn) {
                return this.then(v => v, fn || (x => x));
            }
            finally(fn) {
                return this.then(fn ? x => { fn(); return x; /*return*/ } : x => x, fn ? x => { fn(); throw x; /*throw*/ } : x => x);
            }
            static resolve(value) {
                return new CPromise((resolve, reject) => {
                    resolve(value);
                });
            }
            static reject(value) {
                return new CPromise((resolve, reject) => {
                    reject(value);
                });
            }
        }
        Tasks.CPromise = CPromise;
        // IE <= 11 has no Pomise
        if (!window.Promise)
            window.Promise = CPromise;
    })(Tasks = Calysto.Tasks || (Calysto.Tasks = {}));
})(Calysto || (Calysto = {}));
