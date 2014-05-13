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
		[STAThreadAttribute]
		static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Editor());
		}
	}
}
