using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoRek.Message.PreParser
{
	/// <summary>
	/// Describes the output modes of the swift parser
	/// </summary>
	public enum OutputMode
	{
		/// <summary>
		/// The fully parsed output
		/// </summary>
		CSV,
		/// <summary>
		/// The output parsed to XML as elements
		/// </summary>
		XML_Element,
		/// <summary>
		/// The output parsed to XML as attributes
		/// </summary>
		XML_Attr
	}
}
