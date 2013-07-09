using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics;

namespace ApiSoftware.Library35.Parsing
{
	/// <summary>
	/// A choice rule.
	/// </summary>
	/// <remarks>
	/// A choice rule allows the parser to try from a range different rules. The
	/// parser will try each rule in turn and use the first successful rule as the
	/// parse result.
	/// 
	/// For best performance in parsing, the most common situation should typically
	/// be used as the first rule choice, provided the rules don't require to be in
	/// a particular ordering to parse correctly.
	/// </remarks>
	public sealed class ChoiceRule : RuleListBase
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
			//Trace.WriteLine(Name + ":" + position, "ChoiceRule");
			OutputNode result = null;
			OutputNode best = null;
			foreach (var item in Rules)
			{
				result = item.Parse(text, position);
				if (result.IsMatch)
				{
					return result;
				}
				if (best == null || result.End > best.End) { best = result; }
			}
			return best;
		}

		[ExcludeFromCodeCoverage]
		internal override string FormattedOutput(OutputNode node)
		{
			throw new NotSupportedException("Formatted output is not supported on the ChoiceRule");
		}
	}

}
