using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ApiSoftware.Library35;
using ApiSoftware.Library35.Parsing;
using System.Windows.Forms;
using System.Diagnostics;

namespace NewParser
{
	class Program
	{

		static void Main(string[] args)
		{
			//var b = Stopwatch.IsHighResolution;
			//var f = Stopwatch.Frequency;
			//GC.Collect();
			//GC.WaitForFullGCComplete(); 
			//MessageBox.Show("Test");
			//var i = 0;
			//var tester = new Tester();
			//tester.Test2();
			//tester.Test3();
			//tester.Test1();
			//if (i == 0) return;
			//            var parser = new Grammar();

			//            /* example 1
			//            parser.Add( new Sequence()
			//                .Add("\\(")
			//                .Add(
			//                    new OneOrMore()
			//                    {
			//                        Rule =
			//                            new Sequence()
			//                                .Add(
			//                                    new Choice()
			//                                        .Add("\\s*ABC")
			//                                        .Add("\\s*123")
			//                                    )
			//                                .Add(
			//                                    new Choice()
			//                                        .Add("\\s*AAA")
			//                                        .Add("\\s*444")
			//                                    )
			//                    })
			//                .Add("\\)")); 
			//             * */

			//            parser
			//                .Add(new OneOrMore() 
			//                    { 
			//                        Name = "root",
			//                        Rule = new Include() { Reference = "statement"}
			//                    })
			//                .Add(new Sequence() { Name = "statement"}
			//                        .Add(@"\s*BEGIN")
			//                        .Add(@"\s*\d+")
			//                        .Add(@"\s*END")
			//                    );

			//            var xml = parser.XmlSerialize();
			//            Console.WriteLine(xml);

			//            parser = Grammar.LoadXml(@"
			//<Grammar>
			//	<OneOrMore Name='root'>
			//		<Include>statement</Include>
			//	</OneOrMore>
			//	<Sequence Name='statement'>
			//		<Symbol>\s*BEGIN</Symbol>
			//		<Symbol>\s*\d+</Symbol>
			//		<Symbol>\s*END</Symbol>
			//	</Sequence>
			//</Grammar>
			//"); 
			//            xml = parser.XmlSerialize();
			//            Console.WriteLine(xml);

			//            //var result = parser.Parse("(123AAA ABC444)");
			//            var result = parser.Parse("BEGIN 123 DEND BEGIN 345 END");
			//            Console.WriteLine(result.IsMatch);
			//            if (!result.IsMatch) Console.WriteLine(result.GetErrorText());
			//            Console.ReadKey();
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new TestWindow());
		}
	}
}
