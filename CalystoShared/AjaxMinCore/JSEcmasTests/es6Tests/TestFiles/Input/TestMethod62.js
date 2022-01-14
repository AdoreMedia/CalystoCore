class CPromise
{
    constructor(executor)
    {
        this.executor = executor;
        if (this.executor)
        {
            try
            {
                this.executor(value => this.notifyResolved(value), value => this.notifyRejected(value));
            }
            catch (ex)
            {
                this.notifyRejected(ex);
            }
        }
    }
    notifyResolved(value)
    {
        this._isResolved = true;
        this._resolveValue = value;
        this.notifyNext();
    }

	static Method(a, b)
    {
        return a;
    }

	async Method2(a, b, c)
    {
        return c + b;
    }

	static async Method3(a, b)
    {
        return a;
    }

    static async Method4(a, b)
    {
        return await CPromise.Method3(a, b);
    }

    static UseTryCatch(item, func, defaultResult)
    {
        try
        {
            return func(item);
        }
        catch
        {
            return defaultResult;
        }
		finally
        {
            return 3333;
		}
    }

    static UseTryCatch2(item, func, defaultResult)
    {
        try
        {
            return func(item);
        }
        catch (error1)
        {
            return defaultResult;
        }
        finally
        {
            return 4321;
        }
    }

    static UseTryCatch3(item, func, defaultResult)
    {
        try
        {
            return func(item);
        }
        catch
        {
           
        }
        finally
        {
            
        }
    }
}

class NewClass
{
	constructor(name)
    {
        this._name = name;
	}
}