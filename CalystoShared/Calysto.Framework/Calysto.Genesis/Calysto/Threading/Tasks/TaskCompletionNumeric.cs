namespace Calysto.Threading.Tasks
{
	public class TaskCompletionNumeric : TaskCompletionConditional<int>
	{
		public TaskCompletionNumeric(int initialValue)
			: base(initialValue, v => v <= 0, v => v + 1, v => v - 1)
		{
		}
	}
}
