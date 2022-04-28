using System;
using System.Collections.Generic;
using System.Text;

namespace delegatePractice.Expressions
{
	public class SomeClass
	{
		public bool MyProperty { get; set; }

		public string MyMethod(int number,string text) => $"{number} {text}";
	}
}
