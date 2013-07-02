using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace ApiSoftware.Library35.Parsing
{
	/// <summary>
	/// A one or more rule.
	/// </summary>
	/// <remarks>
	/// The one or more rule represents an element that occurs one or more times, for example
	/// a list of parameters. The Separator is optional, but if used, can improve performance
	/// as the rule will only consider additional items if it first finds the separator.
	/// </remarks>
	public sealed class OneOrMore : RuleBase
	{
		/// <summary>
		/// Gets or sets the separator that separates the repeating elements.
		/// </summary>
		/// <value>
		/// The separator.
		/// </value>
		public Symbol Separator { get; set; }

		/// <summary>
		/// Gets or sets the rule to be used as the repeating element.
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
			var result = new BlockNode(this, position);
			var child = Rule.Parse(position);
			result.Children.Add(child);
			result.End = child.End;
			if (child.IsMatch)
			{
				// Found at least one, so successful so far.
				// if separator exists, use it, otherwise don't
				position = child.End;
				if (Separator != null)
				{
					// Since we have a separator, the rule MUST find its repeating
					// item after each separator, or it is a syntax fail.
					var sep = Separator.Parse(position);

					while (sep.IsMatch)
					{
						position = sep.End;
						child = Rule.Parse(position);
						result.End = child.End;
						position = child.End;
						result.Children.Add(child);
						if (!child.IsMatch)
						{
							// did not find our item after the separator, so fail and return
							result.IsMatch = false;
							//Grammar.ErrorNode = child;
							return result;
						}
						// If the separator is the next character, keep looping
						sep = Separator.Parse(position);
					}
				}
				else
				{
					// There was no separator, and since we already found our first item,
					// we cannot fail on this rule. So while we keep finding our rule, keep 
					// moving on then return success.
					while (child.IsMatch)
					{
						child = Rule.Parse(position);
						position = child.End;
						if (child.IsMatch)
						{
							result.Children.Add(child);
							result.End = child.End;
						}
					}
				}
				return result;
			}
			else
			{
				// failed to find a single match - return failed.
				result.IsMatch = false;
				result.End = position;
				return result;
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
			if (Rule == null) { throw new ArgumentException("'OneOrMore' rule must contain a rule"); }
			base.Initialize(rules);

			if (Separator != null) { Separator.Initialize(rules); }
			Rule.Initialize(rules);
		}

		/// <summary>
		/// Resolves the include rules.
		/// </summary>
		/// <param name="rules">Base rules to lookup against.</param>
		protected internal override void GetRulesContainingIncludes(ICollection<RuleBase> rules)
		{
			if (rules == null) throw new ArgumentNullException("rules");
			if (Rule is Include) // || Separator is Include) // currently Separator is a symbol only
			{
				rules.Add(this);
			}
			if (Rule != null)
			{
				Rule.GetRulesContainingIncludes(rules);
			}
			if (Separator != null)
			{
				Separator.GetRulesContainingIncludes(rules);
			}
		}

		/// <summary>
		/// Resolves the include rules.
		/// </summary>
		protected internal override void ResolveIncludes(Rules rules)
		{
			Separator = ApplyInclude(Separator, rules);
			Rule = ApplyInclude(Rule, rules);
		}

		internal override string FormattedOutput(OutputNode node)
		{
			// use the template to build the string
			var values = new string[node.Children.Count];
			OutputNode child;
			for (int i = 0; i < values.Length; i++)
			{
				child = node.Children[i];
				values[i] = child.FormattedOutput();
			}
			if (Template == null) { return string.Join(string.Empty, values); } else { return Template.Values(values); }
		}

	}

}
