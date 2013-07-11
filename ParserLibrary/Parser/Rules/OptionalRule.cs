using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using System.Globalization;

namespace ApiSoftware.Library35.Parsing
{
	/// <summary>
	/// An optional rule.
	/// </summary>
	/// <remarks>
	/// An optional rule allows the parser to try a rule without failing if there is no match.
	/// </remarks>
	public sealed class OptionalRule : RuleHolderBase
	{

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
			OutputNode result = Rule.Parse(text, position);
			if (result.IsMatch)
			{
				return result;
			}
			else
			{
				return new BlockNode(this, text, position) { End = position };
			}
		}

	}

}
