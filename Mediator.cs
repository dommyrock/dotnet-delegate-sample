using System;

namespace delegatePractice
{

	//Don't want this class to be owerriden
	public sealed class Mediator
	{
		//singlton funtioonality 
		private static readonly Mediator _Instance = new Mediator();

		//Don't want to make it posible to new up instance, they can only instantiate it through our definition

		//hide constructor 
		private Mediator() { }

		public static Mediator GetMediator() => _Instance;


		//Once you got instance you can subscribe to JobChangedEvent

		//Instance functionality

		//public so we can access it from other parts of system that want to subscribe to it
		public event EventHandler<JobsChangedEventArgs> JobChanged;

		public void OnJobChanged(object sender,string job)
		{
			//cast event to our delegate type
			var jobChangedDelegate = JobChanged as EventHandler<JobsChangedEventArgs>;
			if (jobChangedDelegate != null)
			{
				//raise event and notify any listeners
				jobChangedDelegate(sender, new JobsChangedEventArgs { Job = job });
			}
		}
	}
}
