using System.Threading.Tasks;

namespace Calysto.Threading.Tasks
{
	public static class TaskExtensions2
	{
		public static Task Track(this Task task, string name = null)
		{
			CalystoTaskTracker.Current.Track(task);
			return task;
		}

		/// <summary>
		/// Started and ended.
		/// </summary>
		/// <param name="task"></param>
		/// <returns></returns>
		public static bool IsEnded(this Task task)
		{
			return task.Status >= TaskStatus.RanToCompletion;
		}

		public static bool IsStarted(this Task task)
		{
			return task.Status > TaskStatus.Created;
		}

	}
}
