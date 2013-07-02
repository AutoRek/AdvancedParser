using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using ApiSoftware.Library35;
using System.Globalization;

namespace ApiSoftware.Library35.Parsing
{
	/// <summary>
	/// An integer rule.
	/// </summary>
	/// <remarks>
	/// The integer rule parses a single integer value. 
	/// Whitespace before the integer value is ignored.
	/// </remarks>
	public sealed class Integer : RuleBase
	{
		private Regex expression = new Regex(@"\G\s*\d+\b");

		/// <summary>
		/// Uses the rule to parse the text from the specified position.
		/// </summary>
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
		public override OutputNode Parse(int position)
		{
			var match = expression.Match(grammar.Text, position);
			if (match.Success)
			{
				return new IntegerNode(this, position, match.Length);
			}
			else
			{
				return new ErrorNode(this, position);
			}
		}

		/// <summary>
		/// Uses the integer rule to get the value of the node 
		/// </summary>
		/// <param name="node">Node to get the value of.</param>
		/// <returns>Object containing the integer value of the node (or null).</returns>
		internal override object GetValue(OutputNode node)
		{
			int i;
			if (int.TryParse(base.GetStringValue(node), out i)) return i; else return null;
		}

		internal override string FormattedOutput(OutputNode node)
		{
			return string.Format(CultureInfo.InvariantCulture, Template ?? "{0}", GetValue(node));
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Integer"/> class.
		/// </summary>
		public Integer()
		{
			ErrorTemplate = "Error at line {0}, position {1}: Expected an integer but found '{2}'";
		}
	}

}
