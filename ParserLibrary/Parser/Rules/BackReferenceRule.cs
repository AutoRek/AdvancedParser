using System;
using System.Globalization;
using System.Linq;
using ApiSoftware.Library35;

namespace ApiSoftware.Library35.Parsing
{
	/// <summary>
	/// A back reference rule.
	/// </summary>
	/// <remarks>
	/// The back reference rule matches a symbol previously matched and saved by the save rule.
	/// </remarks>
	public sealed class BackReferenceRule : RuleBase
	{
		private string symbol;

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
				symbol = parser.BackReferences.Peek();
				if (!string.IsNullOrEmpty(text) && string.Compare(text, position, symbol, 0, symbol.Length, StringComparison.Ordinal) == 0)
				{
					if (CheckPoint) parser.CommitPosition = position;
					return new TextNode(this, text, position, symbol.Length);
				}
				else
				{
					// For the back reference rule, the expected value depends on the back reference,
					// so to allow this to appear in the error text, we overwrite the Expecting value with the symbol.
					return new ErrorNode(this, text, position);
				}
			}
			catch (ArgumentOutOfRangeException)
			{
				throw new ArgumentOutOfRangeException("position", position, "parameter 'position' must be between zero and the length of the text being parsed.");
			}
		}

		/// <summary>
		/// One or more rules use the expected values of the contained rule.
		/// </summary>
		/// <returns></returns>
		protected internal override string GetExpected()
		{
			return Expecting.Else("'" + symbol + "'");
		}

		internal override string FormattedOutput(OutputNode node)
		{
			if (string.IsNullOrEmpty(Template)) return string.Empty; else return string.Format(CultureInfo.CurrentCulture, Template, node.NodeText);
		}
	}
}