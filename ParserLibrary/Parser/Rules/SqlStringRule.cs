using System;
using System.Linq;
using System.Text.RegularExpressions;
using ApiSoftware.Library35;

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
	public sealed class SqlStringRule : RuleBase
	{
		private Regex expression = new Regex(@"\G\s*'(''|[^'])*'");

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
					if (CheckPoint) parser.CommitPosition = position;
					return new TextNode(this, text, position, match.Length);
				}
				else
				{
					return new ErrorNode(this, text, position);
				}
			}
			catch (ArgumentOutOfRangeException)
			{
				throw new ArgumentOutOfRangeException("position", position, "parameter 'position' must be between zero and the length of the text being parsed.");
			}
		}

		internal override object GetValue(OutputNode node)
		{
			var value = node.NodeText.Trim().Replace("''", "'");
			if (value.Length < 2) return string.Empty;
			return value.Substring(1, value.Length - 2);
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="SqlStringRule"/> class.
		/// </summary>
		public SqlStringRule()
		{
			Expecting = "string of the form '...'";
		}
	}
}