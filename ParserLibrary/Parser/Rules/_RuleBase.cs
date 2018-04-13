using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using ApiSoftware.Library35;

namespace ApiSoftware.Library35.Parsing
{
	/// <summary>
	/// Base class representing a parsing rule.
	/// </summary>
	[Serializable]
	[XmlInclude(typeof(RuleListBase))]
	[XmlInclude(typeof(RuleHolderBase))]
	public abstract class RuleBase : IRule
	{
		/// <summary>
		/// The parser hosting the rules that are being used in this parse.
		/// </summary>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields",
			Justification = "For performance reasons, this protected member is a field.")]
		[XmlIgnore]
		public Parser parser;

		/// <summary>
		/// Gets or sets the name of the Rule
		/// </summary>
		/// <value>
		/// The name of the rule.
		/// </value>
		[XmlAttribute]
		public string Name { get; set; }

		/// <summary>
		/// Gets or sets the template used to format the error text if the rule cannot successfully parse.
		/// </summary>
		/// <remarks>
		/// The string is used to format the error message. The following place-holder values
		/// can be used in the template string:
		/// {0} {line}		= the line number from the start of the content.
		/// {1} {character}	= the character position within the line.
		/// {2} {content}	= actual content read at the current position.
		/// {3} {expected}	= the expected description value from the rule.
		/// {4} {index}		= index position from the start of the file.
		/// {5} {rule}		= the rule name or rule type if no name specified.
		/// </remarks>
		[XmlAttribute]
		public string ErrorTemplate { get; set; } = "{rule}: Expected {expected} but found '{content}' at line {line}, position {character}";

		/// <summary>
		/// Gets or sets the optional template used to format the output.
		/// </summary>
		/// <value>
		/// The template.
		/// </value>
		[XmlAttribute]
		public string Template { get; set; }

		/// <summary>
		/// Gets or sets the record name.
		/// </summary>
		/// <value>
		/// The record name.
		/// </value>
		/// <remarks>
		/// This property is used by the <c>Node.Fill()</c> and the <c>Node.ToXml()</c> methods.
		/// See <see cref="ParserUtilities.Fill(OutputNode, System.Data.DataSet)"/> for details on the Fill method and how to populate
		/// data sets from parsed data, and  <see cref="ParserUtilities.ToXml(OutputNode)"/> for details on the 
		/// ToXml method and how to pull Xml nodes from parsed data.
		/// </remarks>
		[XmlAttribute]
		public string Record { get; set; }

		/// <summary>
		/// Gets or sets the field name.
		/// </summary>
		/// <value>
		/// The field.
		/// </value>
		/// <remarks>
		/// This property is used by the <c>Node.Fill()</c> and the <c>Node.ToXml()</c> methods.
		/// See <see cref="ParserUtilities.Fill(OutputNode, System.Data.DataSet)"/> for details on the Fill method and how to populate
		/// data sets from parsed data, and  <see cref="ParserUtilities.ToXml(OutputNode)"/> for details on the 
		/// ToXml method and how to pull Xml nodes from parsed data.
		/// </remarks>
		[XmlAttribute]
		public string Field { get; set; }

		/// <summary>
		/// Gets or sets the fields to clear when using the <c>Node.Fill</c> method.
		/// </summary>
		/// <value>
		/// The fields to clear.
		/// </value>
		/// <remarks>
		/// This attribute is only used when the <see cref="Record"/> attribute is used. 
		/// If null, no fields will be cleared when the new record is started. This is the default behaviour.
		/// If *, all fields will be cleared when the new record is started.
		/// If a comma-separated list of field names is provided, each named value is cleared before the
		/// new record is started.
		/// </remarks>
		[XmlAttribute]
		public string ClearFields { get; set; }

		/// <summary>
		/// Gets or sets the Important flag.
		/// </summary>
		/// <value>
		/// The Important flag.
		/// </value>
		/// <remarks>
		/// If the rule is marked Important, the failures of this rule will be 
		/// reported in preference to any other errors.
		/// </remarks>
		[XmlAttribute]
		public bool Important { get; set; }

		/// <summary>
		/// Gets or sets whether the rule will act as a check point.
		/// </summary>
		/// <remarks>
		/// If the <see cref="CheckPoint"/> flag is set, the back-tracking on any error
		/// further along in the content will not be allowed to back-track past this
		/// point. This can be used to improve the error reporting by essentially
		/// commiting to the content parsed so far.
		/// </remarks>
		[XmlAttribute]
		public bool CheckPoint { get; set; }

		/// <summary>
		/// Gets or sets the other elements.
		/// </summary>
		/// <value>
		/// The other elements.
		/// </value>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1819:PropertiesShouldNotReturnArrays",
			Justification = "Internal use only: This property is only used to detect errors in grammar configuration.")]
		[XmlAnyElement]
		public XmlElement[] OtherElements { get; set; }

		/// <summary>
		/// Gets or set a short text description of the content expected by this rule.
		/// This value can be included in the error template with the {expected} placeholder.
		/// If not specified, each rule type will use a default behaviour.
		/// </summary>
		[XmlAttribute]
		public string Expecting { get; set; }

		/// <summary>
		/// Uses the rule to parse the text.
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
		/// This method is for internal use only and should not be used by external code.
		/// Parse the text from the given position.
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
		/// <param name="parser">The grammar to initialise with.</param>
		/// <remarks>
		/// All rules are initialised with the root-level node that represents
		/// the grammar to give each rule access to the other named rules and
		/// to the text being parsed.
		/// </remarks>
		protected internal virtual void Initialize(Parser parser)
		{
			this.parser = parser;
		}

		/// <summary>
		/// Builds a list of all rules that contain named references to other
		/// rules which will require to be resolved.
		/// </summary>
		/// <param name="rules">The rules containing named rule references.</param>
		protected internal virtual void GetRulesContainingIncludes(ICollection<RuleBase> rules)
		{
		}

		/// <summary>
		/// Resolves the include rules.
		/// </summary>
		/// <param name="rules">Base rules to lookup against.</param>
		protected internal virtual void ResolveIncludes(RuleListBase rules)
		{
			if (rules == null) throw new ArgumentNullException("rules");
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
		protected internal string GetErrorText(OutputNode node)
		{
			if (node == null) throw new ArgumentNullException("node");
			var templateText = GetErrorTextTemplate(node);

			var tp = new TextPoint(node.Text, node.Begin);
			var rule = Name ?? GetType().Name;
			return templateText.Values(tp.Line, tp.Character, tp.Symbol, GetExpected(), tp.Index, rule);
		}

		/// <summary>
		/// Gets the word or phrase describing the content expected by the rule.
		/// </summary>
		/// <returns></returns>
		/// <remarks>
		/// Some rule types will dynamically create this value based on the content.
		/// </remarks>
		protected virtual internal string GetExpected()
		{
			// The rule can specify an expected value text, or use the default.
			return Expecting.Else("Valid {0} value".Values(Name ?? GetType().Name)); 
		}

		// Returns the unformatted error text for the node.
		private string GetErrorTextTemplate(OutputNode node)
		{
			// Start with the error template.
			var errorText = ErrorTemplate;

			// If there is a parent node, and it contains enough detail to be of interest,
			// we initialise the error result since the parent node is what we were doing 
			// when we errored.
			// Note We can go up the parent chain to find the most interesting parent node.
			// TODO: consider if this is something to parameterise?
			var parentNode = node.ParentNode;
			while (parentNode != null)
			{
				var rule = parentNode.Rule.Name ?? parentNode.Rule.Expecting ?? parentNode.Rule.GetType().Name;
				var tp = new TextPoint(parentNode.Text, parentNode.Begin);
				errorText += ", while reading {0} (line {1}, character {2})".Values(rule, tp.Line, tp.Character);
				parentNode = parentNode.ParentNode;
			}

			return errorText
				.Replace("{line}", "{0}")
				.Replace("{character}", "{1}")
				.Replace("{content}", "{2}")
				.Replace("{expected}", "{3}")
				.Replace("{index}", "{4}")
				.Replace("{rule}", "{5}");
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