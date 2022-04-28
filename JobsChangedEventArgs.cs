using System;

namespace delegatePractice
{
	public class JobsChangedEventArgs:EventArgs
	{
		public string Job { get; set; }
	}
}