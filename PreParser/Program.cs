using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiSoftware.Library35;

namespace AutoRek.Message.PreParser
{
	class Program
	{
		static void Main(string[] args)
		{
			var parser = new MsgParser();
			Console.WriteLine("AutoRek Swift Stand Alone Parser");
			ArgumentList.ApplyArguments(parser, args, MsgParser.Help);
			parser.Parse();
			Console.ReadLine();
		}
	}
}
