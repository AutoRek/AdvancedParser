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
	public sealed class Optional : RuleBase
	{
		/// <summary>
		/// Gets or sets the rule to be optionally applied.
		/// </summary>
		/// <value>
		/// The rule.
		/// </value>
		[XmlElement(typeof(Symbol))]
		[XmlElement(typeof(Integer))]
		[XmlElement(typeof(String))]
		[XmlElement(typeof(SString))]
		[XmlElement(typeof(Choice))]
		[XmlElement(typeof(Sequence))]
		[XmlElement(typeof(OneOrMore))]
		[XmlElement(typeof(Include))]
		// Do not include Optional or If as meaningless here
		public RuleBase Rule { get; set; }

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
			OutputNode result = Rule.Parse(position);
			if (result.IsMatch)
			{
				return result;
			}
			else
			{
				return new BlockNode(this, position) { End = position };
			}
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
		protected internal override void Initialize(Rules rules)
		{
			if (Rule == null) { throw new ArgumentException("'Optional' rule must contain a rule"); }
			base.Initialize(rules);
			Rule.Initialize(rules);
		}

		/// <summary>
		/// Builds a list of all rules that contain named references to other
		/// rules which will require to be resolved.
		/// </summary>
		/// <param name="rules">The rules containing named rule references.</param>
		protected internal override void GetRulesContainingIncludes(ICollection<RuleBase> rules)
		{
			if (rules == null) throw new ArgumentNullException("rules");
			if (Rule is Include)
			{
				rules.Add(this);
			}
			else
			{
				Rule.GetRulesContainingIncludes(rules);
			}
		}

		/// <summary>
		/// Resolves the include rules.
		/// </summary>
		/// <param name="rules">Base rules to lookup against.</param>
		protected internal override void ResolveIncludes(Rules rules)
		{
			Rule = ApplyInclude(Rule, rules);
		}

		internal override string FormattedOutput(OutputNode node)
		{
			if (node == null) throw new ArgumentNullException("node");
			if (node.End == node.Begin) return string.Empty;
			return string.Format(CultureInfo.InvariantCulture, Template ?? "{0}", Rule.FormattedOutput(node));
		}
	}

}
