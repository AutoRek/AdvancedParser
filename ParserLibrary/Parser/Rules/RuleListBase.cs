using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace ApiSoftware.Library35.Parsing
{
	/// <summary>
	/// Base class to hold a list of rules.
	/// </summary>
	public abstract class RuleListBase : RuleBase
	{
		private List<RuleBase> ruleList = new List<RuleBase>();

		/// <summary>
		/// Gets or sets the rules in this rule list.
		/// </summary>
		/// <value>
		/// The rules.
		/// </value>
		[XmlElement(typeof(Symbol))]
		[XmlElement(typeof(Integer))]
		[XmlElement(typeof(Choice))]
		[XmlElement(typeof(Sequence))]
		[XmlElement(typeof(OneOrMore))]
		[XmlElement(typeof(Optional))]
		[XmlElement(typeof(If))]
		[XmlElement(typeof(Include))]
		[XmlElement(typeof(String))]
		[XmlElement(typeof(SString))]
		public List<RuleBase> Rules { get { return ruleList; } }

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
			base.Initialize(rules);
			foreach (var rule in Rules)
			{
				rule.Initialize(rules);
			}
		}

		/// <summary>
		/// Builds a list of all rules that contain named references to other
		/// rules which will require to be resolved.
		/// </summary>
		/// <param name="rules">The rules containing named rule references.</param>
		protected internal override void GetRulesContainingIncludes(ICollection<RuleBase> rules)
		{
			if (rules == null) throw new ArgumentNullException("rules");
			for (int i = 0; i < Rules.Count; i++)
			{
				if (Rules[i] is Include) rules.Add(this);
				Rules[i].GetRulesContainingIncludes(rules);
			}
		}

		/// <summary>
		/// Resolves the include rules.
		/// </summary>
		protected internal override void ResolveIncludes(Rules rules)
		{
			if (rules == null) throw new ArgumentNullException("rules");
			for (int i = 0; i < Rules.Count; i++)
			{
				var includeRule = Rules[i] as Include;
				if (includeRule != null) { Rules[i] = rules[includeRule.Reference]; }
			}
		}

		/// <summary>
		/// Adds the specified rule to the rule list.
		/// </summary>
		/// <param name="rule">The rule.</param>
		/// <returns>The rule list.</returns>
		/// <remarks>
		/// By returning the rule list, the method can be used with fluid syntax.
		/// </remarks>
		public RuleListBase Add(RuleBase rule)
		{
			Rules.Add(rule);
			return this;
		}

		/// <summary>
		/// Adds the specified pattern as a symbol rule to the rule list.
		/// </summary>
		/// <param name="pattern">The pattern.</param>
		/// <returns>The rule list.</returns>
		/// <remarks>
		/// By returning the rule list, the method can be used with fluid syntax.
		/// </remarks>
		public RuleListBase Add(string pattern)
		{
			Add(new Symbol(pattern));
			return this;
		}

	}

}
