interface Promise<T>
{
	TimeoutAsync(timeoutMs: number): Promise<T>;
}

namespace Calysto.Tasks.TaskUtility
{
	Promise.prototype.TimeoutAsync = async function (timeoutMs: number)
	{
		return TaskUtility.TimeoutAsync(this, timeoutMs);
	};
}
