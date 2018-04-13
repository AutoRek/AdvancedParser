using System;
using System.Linq;
using System.Text;

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
			var childResult = Rule.Parse(text, position);
			if (childResult.IsMatch)
			{
				var result = new BlockNode(this, text, position) { End = childResult.End };
				result.Children.Add(childResult);
				return result;
			}
			else if (parser != null && parser.CommitPosition > position)
			{
				// (Parser may be null for individual rules being used for immediate parsing) 
				// We have committed to a position further along than this optional element.
				// This means the rule is no longer optional, so we have to return an
				// error node. We return the result of the contained rule, since it will have the
				// the non-matching error node.
				var result = new ErrorNode(this, text, position) { End = childResult.End };
				result.Children.Add(childResult);
				return result;
			}
			else
			{
				// Our optional rule did not match and there are no committed nodes further
				// along, so we consider this successful, and return a zero-sized block
				// node to allow the processing to continue.
				return new BlockNode(this, text, position) { End = position };
			}
		}

		internal override string FormattedOutput(OutputNode node)
		{
			var sb = new StringBuilder();
			foreach (var item in node.Children)
			{
				sb.Append(item.FormattedOutput());
			}
			return sb.ToString();
		}

		/// <summary>
		/// Optional rules use the expected values of the contained elements.
		/// </summary>
		/// <returns></returns>
		protected internal override string GetExpected()
		{
			// Generate a comma-separated list of the choices
			return Expecting.Else(Rule.GetExpected());
		}
	}
}