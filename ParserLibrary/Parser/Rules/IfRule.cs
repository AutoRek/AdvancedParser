using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace ApiSoftware.Library35.Parsing
{
	/// <summary>
	/// Contains a rule to be evaluated conditionally.
	/// </summary>
	/// <remarks>
	/// If the pattern is found at the current position, then the contained rule
	/// will be applied and must match. Otherwise the rule is skipped and will
	/// return an empty block.
	/// </remarks>
	public sealed class IfRule : RuleHolderBase
	{
		private Regex expression = null;
		private string pattern;

		/// <summary>
		/// Gets or sets the pattern that represents the symbol.
		/// </summary>
		/// <value>
		/// The pattern.
		/// </value>
		[XmlAttribute]
		public string Pattern
		{
			get { return pattern; }
			set { pattern = value; expression = new Regex("\\G" + pattern); } // The \G forces the pattern to start at the current position.
		}

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
				if (expression.IsMatch(text ?? string.Empty, position))
				{
					return Rule.Parse(text, position);
				}
				else
				{
					return new BlockNode(this, text, position) { End = position };
				}
			}
			catch (ArgumentOutOfRangeException)
			{
				throw new ArgumentOutOfRangeException("position", position, "parameter 'position' must be between zero and the length of the text being parsed.");
			}
		}

		/// <summary>
		/// If rules use the expected values of the contained elements.
		/// </summary>
		/// <returns></returns>
		protected internal override string GetExpected()
		{
			// Generate a comma-separated list of the choices
			return Expecting.Else(Rule.GetExpected());
		}

		/// <summary>
		/// Initialises the rule with the grammar.
		/// </summary>
		/// <param name="rules">The grammar to initialise with.</param>
		/// <remarks>
		/// All rules are initialised with the root-level node that represents
		/// the grammar to give each rule access to the other named rules and
		/// to the text being parsed.
		/// </remarks>
		protected internal override void Initialize(Parser rules)
		{
			if (string.IsNullOrEmpty(pattern)) { throw new ArgumentException("'If' rule requires the 'Pattern' property to be provided"); }
			base.Initialize(rules);
		}
	}
}