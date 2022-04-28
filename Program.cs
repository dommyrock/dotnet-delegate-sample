using delegatePractice.Expressions;
using System;
using System.Linq.Expressions;

namespace delegatePractice
{
		delegate bool ParameterlessDelegate();
		delegate int AddDelegate(int a, int b);
		public delegate int BizRuleDelegate(int a, int b);
	class Program
	{

		static void Main(string[] args)
		{
			#region Delagates
			//delegate (Lambda)with paramns
			AddDelegate addDelegate = (a, b) => (a + b);
			Console.WriteLine(addDelegate(230, 260));

			//delegate (Lambda) without params
			ParameterlessDelegate pLessDelegate = () =>
				 {
					 Console.WriteLine("Writing to db");
					 Console.WriteLine("Dsposing initialized objects...");
					 return true;
				 };
			bool workDone = pLessDelegate();

			//Pass any delegate as param to 
			BizRuleDelegate addDel = (x, y) => x + y;
			BizRuleDelegate multiplyDel = (x, y) => x *y;
			var proc = new ProcessData();
			//proc.Process(20, 30, multiplyDel);
			//proc.Process(20, 30, addDel);

			//Using biult in delegate Action<T> 
			Action<int, int> addAction = (x, y) => Console.WriteLine(x+y);
			Action<int, int> multiplyaction = (x, y) => Console.WriteLine(x*y);
			proc.ProcessAction(30, 30, addAction);
			proc.ProcessAction(30, 30, multiplyaction);

			//Using built in delegate Func<T> 
			Func<int, int, int> addFunc = (x, y) => x + y;
			Func<int, int, int> multiplyFunc = (x, y) => x * y;
			proc.ProcessFunc(50, 50, addFunc);
			proc.ProcessFunc(50, 50, multiplyFunc);
			#endregion

			#region Expressions
			//Constructing expressions at runtime
			var someClass = new SomeClass();

			Expression<Func<SomeClass, string>> expr = c => c.MyMethod(42,"Some string...");

			//Bellow code creates delegate same as above at the runtime!
			var numberConst= Expression.Constant(42);
			var txtConst= Expression.Constant("Some text");
			var someClassType= typeof(SomeClass);
			var parameterExpression= Expression.Parameter(someClassType,"c");
			var methodInfo = someClassType.GetMethod(nameof(SomeClass.MyMethod));
			var callExpression = Expression.Call(parameterExpression, methodInfo,numberConst,txtConst);
			//run debugger on this line and it should equal to  same lambda at line 53
			var lambdaExpression = Expression.Lambda<Func<SomeClass,string>>(callExpression, parameterExpression);


			//Compile function we created at runtime 
			var func  = lambdaExpression.Compile();
			Console.WriteLine(func(someClass));

			// Be carefull to pass  params to method in exact order , else we cause exceptions at runtime
			//Passing variable to expression , creates Class with prop set to its type & value & runtime , prod version should heave some validations to check that
			//Be carefull when caching [key] expressions because two that look the same arent
			//Expression trees can be used to optimize code that uses Reflection and make it faster
			#endregion


			Console.ReadLine();
		}
	}
}
