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
	/// Base class representing a parsing rule.
	/// </summary>
	[Serializable]
	[XmlInclude(typeof(RuleListBase))]
	public abstract class RuleBase : IRule
	{
		/// <summary>
		/// The rules hosting the parsing
		/// </summary>
		protected Rules rules;

		/// <summary>
		/// Gets or sets the name of the Rule
		/// </summary>
		/// <value>
		/// The name of the rule.
		/// </value>
		[XmlAttribute]
		public string Name { get; set; }

		/// <summary>
		/// Gets or sets custom error text for the node.
		/// </summary>
		/// <remarks>
		/// If the template text includes '$', the '$' is replaced by the standard error text. 
		/// The returned string is used to format the error message. The string format
		/// value holders {0} to {3} are accepted where:
		/// {0} is the line number
		/// {1} is the character in the line
		/// {2} is the token at the position.
		/// {3} is the position in the text file.
		/// </remarks>
		[XmlAttribute]
		public string ErrorTemplate { get; set; }

		/// <summary>
		/// Gets or sets the optional template used to format the output.
		/// </summary>
		/// <value>
		/// The template.
		/// </value>
		[XmlAttribute]
		public string Template { get; set; }

		/// <summary>
		/// Gets or sets the table name.
		/// </summary>
		/// <value>
		/// The table name.
		/// </value>
		/// <remarks>
		/// This is used when collecting parsed nodes into table.
		/// Each node that the rule creates will create a new row for the named
		/// table. The values of the row will be set using any symbols containing 
		/// a Column attribute, where columns will be added automatically.
		/// </remarks>
		[XmlAttribute]
		public string Table { get; set; }

		/// <summary>
		/// Gets or sets the column name.
		/// </summary>
		/// <value>
		/// The column.
		/// </value>
		[XmlAttribute]
		public string Column { get; set; }

		/// <summary>
		/// Gets or sets the other elements.
		/// </summary>
		/// <value>
		/// The other elements.
		/// </value>
		[XmlAnyElement]
		public XmlElement[] OtherElements { get; set; }

		/// <summary>
		/// Uses the rule to parse the text from the start.
		/// </summary>
		/// <param name="text">The text being parsed.</param>
		/// <returns>
		/// The result of the parse.
		/// </returns>
		/// <remarks>
		/// If the rule parses successfully, the result will reflect the new position
		/// for the next rule to begin parsing from. If the rule does not parse
		/// successfully, the rule leaves the position unchanged. 
		/// This method is the same as <c>Parse(text, 0);</c> unless overridden by the rule.
		/// </remarks>
		virtual public OutputNode Parse(string text)
		{
			return Parse(text, 0);
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
		abstract public OutputNode Parse(string text, int position);

		/// <summary>
		/// Initialises the rule with the grammar.
		/// </summary>
		/// <param name="rules">The grammar to initialise with.</param>
		/// <remarks>
		/// All rules are initialised with the root-level node that represents
		/// the grammar to give each rule access to the other named rules and
		/// to the text being parsed.
		/// </remarks>
		virtual internal protected void Initialize(Rules rules)
		{
			this.rules = rules;
		}

		/// <summary>
		/// Builds a list of all rules that contain named references to other
		/// rules which will require to be resolved.
		/// </summary>
		/// <param name="rules">The rules containing named rule references.</param>
		virtual internal protected void GetRulesContainingIncludes(ICollection<RuleBase> rules)
		{

		}

		/// <summary>
		/// Resolves the include rules.
		/// </summary>
		/// <param name="rules">Base rules to lookup against.</param>
		virtual internal protected void ResolveIncludes(Rules rules)
		{

		}

		/// <summary>
		/// Applies the 'include' reference rule.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="rule">The potential reference rule.</param>
		/// <param name="rules">The rules.</param>
		/// <returns>The original rule or the referenced rule, if the original rule was a reference.</returns>
		protected static T ApplyInclude<T>(T rule, Rules rules) where T : RuleBase
		{
			if (rules == null) throw new ArgumentNullException("rules");
			var include = rule as ReferenceRule;
			if (include != null)
			{
				rule = rules[include.Reference] as T;
			}
			return rule;
		}

		/// <summary>
		/// Gets the value of the node as a typed value. 
		/// Internal use only.
		/// </summary>
		/// <param name="node">The node to get the value of.</param>
		/// <returns>The node value.</returns>
		/// <remarks>
		/// By default, the type of the value will be string.
		/// Integer rules will type the value to an integer.
		/// </remarks>
		internal virtual object GetValue(OutputNode node)
		{
			return node.NodeText;
		}

		/// <summary>
		/// Gets the formatted output of the rule.
		/// </summary>
		/// <param name="node">The node to get the output for.</param>
		/// <returns>The output.</returns>
		/// <remarks>
		/// The rule uses the node to get the content at the nodes location
		/// and then formats the output using its template (if set). If the 
		/// node contains child nodes, the rule may drill into the child 
		/// node list to get the formatted values of the child nodes (and so
		/// on). If the Template is not supplied, typically the rule will
		/// simply pass the output back out 'as is'.
		/// </remarks>
		internal virtual string FormattedOutput(OutputNode node)
		{
			return string.Format(CultureInfo.InvariantCulture, Template ?? "{0}", node.Value);
		}

		/// <summary>
		/// Gets the error text for the node for this rule.
		/// </summary>
		/// <param name="node">The node.</param>
		/// <returns>The error text.</returns>
		internal virtual protected string GetErrorText(OutputNode node)
		{
			if (node == null) throw new ArgumentNullException("node");
			var tp = new TextPoint(node.Text, node.Begin);
			return string.Format(CultureInfo.InvariantCulture, GetErrorFormatString(), tp.Line, tp.Character, tp.Symbol, string.Empty, tp.Index);
		}

		/// <summary>
		/// Gets the actual error format string based on the error template property.
		/// </summary>
		/// <returns></returns>
		protected string GetErrorFormatString()
		{
			var errText = "Error at '{2}' (line {0}, position {1})";
			if (!string.IsNullOrEmpty(ErrorTemplate)) errText = ErrorTemplate.Replace("$", errText);
			return errText;
		}

		/// <summary>
		/// Returns a <see cref="System.String"/> that represents this instance.
		/// </summary>
		/// <returns>
		/// A <see cref="System.String"/> that represents this instance.
		/// </returns>
		public override string ToString()
		{
			if (string.IsNullOrEmpty(Name))
			{
				return this.GetType().FullName;
			}
			else
			{
				return Name + ":" + this.GetType().FullName;
			}
		}

	}

}
