using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using System.Data;
using System.Diagnostics;

namespace ApiSoftware.Library35.Parsing
{

	// performance experiment

	class O1
	{
		public string Text;
	}

	class O2
	{
		public O1 parent;
		virtual public void Test2(ref string t, int i) { }
		virtual public void Test3(int i) { }
		virtual public void Test1(int i) { }
	}

	sealed class O3 : O2
	{
		public string text;
		public char c;
		override public void Test1(int i)
		{
			c = parent.Text[i];
		}

		public override void Test2(ref string t, int i)
		{
			c = t[i];
		}

		public override void Test3(int i)
		{
			c = text[i];
		}
	}

	class Tester
	{
		string text = "This is a test string:This is a test string:This is a test string:This is a test string:This is a test string:This is a test string:";

		public void Test1()
		{
			var o1 = new O1();
			o1.Text = text;
			var o3 = new O3();
			o3.parent = o1;

			var s = Stopwatch.StartNew();
			for (int i = 0; i < 1000000; i++)
			{
				for (int j = 0; j < 100; j++)
				{
					o3.Test1(j);
				}
			}
			s.Stop();
			GC.Collect();
			GC.WaitForFullGCComplete();
			System.Windows.Forms.MessageBox.Show(s.ElapsedMilliseconds.ToString());
		}

		public void Test2()
		{
			var o1 = new O1();
			o1.Text = text;
			var o3 = new O3();
			o3.parent = o1;

			var s = Stopwatch.StartNew();
			for (int i = 0; i < 1000000; i++)
			{
				for (int j = 0; j < 100; j++)
				{
					o3.Test2(ref text, j);
				}
			}
			s.Stop();
			GC.Collect();
			GC.WaitForFullGCComplete();
			System.Windows.Forms.MessageBox.Show(s.ElapsedMilliseconds.ToString());
		}

		public void Test3()
		{
			var o1 = new O1();
			o1.Text = text;
			var o3 = new O3();
			o3.parent = o1;

			o3.text = o1.Text;
			var s = Stopwatch.StartNew();
			for (int i = 0; i < 1000000; i++)
			{
				for (int j = 0; j < 100; j++)
				{
					o3.Test3(j);
				}
			}
			s.Stop();
			GC.Collect();
			GC.WaitForFullGCComplete();
			System.Windows.Forms.MessageBox.Show(s.ElapsedMilliseconds.ToString());
		}
	}


}
