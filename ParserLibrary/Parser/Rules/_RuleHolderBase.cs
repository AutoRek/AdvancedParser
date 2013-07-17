using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using ApiSoftware.Library35;
using System.Globalization;
using System.Xml;

namespace ApiSoftware.Library35.Parsing
{
	/// <summary>
	/// Base class for a rule that holds another rule
	/// </summary>
	[Serializable]
	public abstract class RuleHolderBase : RuleBase
	{

		/// <summary>
		/// Gets or sets the rule to be used as the repeating element.
		/// </summary>
		/// <value>
		/// The rule.
		/// </value>
		[XmlElement("Symbol", typeof(SymbolRule))]
		[XmlElement("Until", typeof(UntilRule))]
		[XmlElement("Crlf", typeof(CrlfRule))]
		[XmlElement("Whitespace", typeof(WhitespaceRule))]
		[XmlElement("BackRef", typeof(BackReferenceRule))]
		[XmlElement("Save", typeof(SaveRule))]
		[XmlElement("Integer", typeof(IntegerRule))]
		[XmlElement("Decimal", typeof(DecimalRule))]
		[XmlElement("DateTime", typeof(DateTimeRule))]
		[XmlElement("String", typeof(StringRule))]
		[XmlElement("SString", typeof(SqlStringRule))]
		[XmlElement("Choice", typeof(ChoiceRule))]
		[XmlElement("Sequence", typeof(SequenceRule))]
		[XmlElement("OneOrMore", typeof(OneOrMoreRule))]
		[XmlElement("Include", typeof(ReferenceRule))]
		// Do not include Optional or If as meaningless here
		public RuleBase Rule { get; set; }

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
			if (Rule == null) { throw new ArgumentException(this.GetType().Name + " must contain a rule."); }
			if (OtherElements != null) throw new ArgumentException(this.GetType().Name + " only supports a single contained rule.");
			base.Initialize(rules);
			Rule.Initialize(rules);
		}

		/// <summary>
		/// Resolves the include rules.
		/// </summary>
		/// <param name="rules">Base rules to lookup against.</param>
		protected internal override void GetRulesContainingIncludes(ICollection<RuleBase> rules)
		{
			if (rules == null) throw new ArgumentNullException("rules");
			if (Rule is ReferenceRule) // || Separator is Include) // currently Separator is a symbol only
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
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "0",
			Justification = "Base class does the validation")]
		protected internal override void ResolveIncludes(Parser rules)
		{
			base.ResolveIncludes(rules);
			if (Rule is ReferenceRule)
			{
				var refName = ((ReferenceRule)Rule).Reference;
				Rule = rules[refName];
			}
		}
	}

}
