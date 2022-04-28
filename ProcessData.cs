using System;

namespace delegatePractice
{
	public class ProcessData
	{
		//example of method taking any delegate and invoking it
		public void Process(int x, int y, BizRuleDelegate del)
		{
			Console.WriteLine(del(x, y));
		}


		public void ProcessAction(int x, int y, Action<int, int> del)
		{
			del(x, y);
			Console.WriteLine("Processing action done.");
		}

		public void ProcessFunc(int x, int y, Func<int, int, int> del)
		{
			Console.WriteLine(del(x, y));
		}
	}
}
