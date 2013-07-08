using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using ApiSoftware.Library35.Parsing;

namespace TestConsole
{
	class Program
	{
		static void Main(string[] args)
		{
			IntegerRulePerformance();
			Console.WriteLine("Finished.");
		}

		private static void IntegerRulePerformance()
		{
			var best = double.MaxValue;
			var ir = new IntegerRule();
			var sw = new Stopwatch();
			for (int j = 0; j < 50; j++)
			{
				// code under test
				sw.Restart();
				for (int i = 0; i < 100000; i++)
				{
					var node = ir.Parse("TEXT 1234", 5);
				}
				sw.Stop();
			}
			if (sw.Elapsed.TotalMilliseconds < best) best = sw.Elapsed.TotalMilliseconds;
			Console.WriteLine("{0}ms", best);
		}
	}
}
