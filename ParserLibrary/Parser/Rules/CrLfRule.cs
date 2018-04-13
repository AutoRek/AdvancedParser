using System;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using ApiSoftware.Library35;

namespace ApiSoftware.Library35.Parsing
{
	/// <summary>
	/// A Crlf rule.
	/// </summary>
	/// <remarks>
	/// The Crlf rule represents a single Crlf in the content.
	/// </remarks>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Crlf")]
	public sealed class CrlfRule : RuleBase
	{
		private Regex expression = new Regex("\\G\\r\\n");

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

		/// <summary>
		/// Initializes a new instance of the <see cref="CrlfRule"/> class.
		/// </summary>
		public CrlfRule()
		{
			Expecting = "line break";
		}

		internal override string FormattedOutput(OutputNode node)
		{
			if (string.IsNullOrEmpty(Template)) return string.Empty; else return string.Format(CultureInfo.CurrentCulture, Template, node.NodeText);
		}

		/// <summary>
		/// Returns a <see cref="System.String" /> that represents this instance.
		/// </summary>
		/// <returns>
		/// A <see cref="System.String" /> that represents this instance.
		/// </returns>
		public override string ToString()
		{
			return base.ToString();
		}
	}
}