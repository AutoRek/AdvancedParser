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
	/// A rule for a Sql-style string (i.e. '...')
	/// </summary>
	/// <remarks>
	/// The SQL string rule parses a string in conventional single-quoted format.
	/// Whitespace before the string value is ignored.
	/// 
	/// The sql string rule automatically handles escaped quotes in the string
	/// that have been converted to doubled-single-quotes.
	/// </remarks>
	public sealed class SString : RuleBase
	{
		private Regex expression = new Regex(@"\G\s*'(''|[^'])*'");

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
				return new TextNode(this, position, match.Length);
			}
			else
			{
				return new ErrorNode(this, position);
			}
		}

		internal override object GetValue(OutputNode node)
		{
			var s = (string)base.GetValue(node);
			return s.Trim().Replace("''", "'").Trim('\'');
		}

		internal override string FormattedOutput(OutputNode node)
		{
			return string.Format(CultureInfo.InvariantCulture, Template ?? "{0}", GetValue(node));
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="SString"/> class.
		/// </summary>
		public SString()
		{
			ErrorTemplate = "Error at line {0}, position {1}: Expected 'string' but found \"{2}\"";
		}
	}

}
