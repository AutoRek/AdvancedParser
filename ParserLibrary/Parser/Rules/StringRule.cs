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
	/// A rule for a common-style string (i.e. "...")
	/// </summary>
	/// <remarks>
	/// The string rule parses a string in conventional quoted format.
	/// Whitespace before the string value is ignored.
	/// 
	/// The string rule automatically handles escaped quotes in the string
	/// that have been converted to doubled-quotes within the string.
	/// </remarks>
	public sealed partial class StringRule : RuleBase
	{
		private Regex expression = new Regex(@"\G\s*""(""""|[^""])*""", RegexOptions.Compiled);

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
			var value = node.NodeText.Trim().Replace("\"\"", "\"");
			if (value.Length < 2) return string.Empty;
			return value.Substring(1, value.Length - 2);
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="StringRule"/> class.
		/// </summary>
		public StringRule()
		{
			ErrorTemplate = "$: expected a string value of the form \"...\".";
		}
	}

}
