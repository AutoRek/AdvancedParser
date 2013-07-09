using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using ApiSoftware.Library35;
using System.Globalization;
using System.Diagnostics;

namespace ApiSoftware.Library35.Parsing
{
	/// <summary>
	/// An integer rule.
	/// </summary>
	/// <remarks>
	/// The integer rule parses a single integer value. 
	/// Whitespace before the integer value is ignored.
	/// </remarks>
	[XmlRoot("DateTime")]
	public sealed class DateTimeRule : RuleBase
	{
		private Regex expression = new Regex(@"\G\s*[0-9.:\\/-]+\b");

		/// <summary>
		/// Uses the rule to parse the text from the specified position.
		/// </summary>
		/// <param name="text">The text being parsed.</param>
		/// <param name="position">The position to parse from.</param>
		/// <returns>
		/// The result of the parse.
		/// </returns>
		/// <remarks>
		/// If the rule parses successfully, the result will reflect the new position
		/// for the next rule to begin parsing from. If the rule does not parse
		/// successfully, the rule leaves the position unchanged. In this case the
		/// rules will back-track up the stack to find the next rule that will parse
		/// from the current position. If no rule can parse, then the text is
		/// incorrectly formatted and the overall parse result will be unsuccessful.
		/// </remarks>
		public override OutputNode Parse(string text, int position)
		{
			try
			{
				var match = expression.Match(text ?? string.Empty, position);
				if (match.Success)
				{
					//Trace.WriteLine(Name + ":" + position + ":true", "IntegerRule");
					return new DateTimeNode(this, text, position, match.Length);
				}
				else
				{
					//Trace.WriteLine(Name + ":" + position + ":false", "IntegerRule");
					return new ErrorNode(this, text, position);
				}
			}
			catch (ArgumentOutOfRangeException)
			{
				throw new ArgumentOutOfRangeException("position", position, "parameter 'position' must be between zero and the length of the text being parsed.");
			}
		}

		/// <summary>
		/// Uses the integer rule to get the value of the node 
		/// </summary>
		/// <param name="node">Node to get the value of.</param>
		/// <returns>Object containing the integer value of the node (or null).</returns>
		internal override object GetValue(OutputNode node)
		{
			DateTime i;
			if (DateTime.TryParse(node.NodeText, out i)) return i; else return null;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="IntegerRule"/> class.
		/// </summary>
		public DateTimeRule()
		{
			ErrorTemplate = "$: expected an integer value.";
		}
	}

}
