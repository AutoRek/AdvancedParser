using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Xml.Serialization;
using ApiSoftware.Library35;

namespace ApiSoftware.Library35.Parsing
{
	/// <summary>
	/// A list of named rules for parsing text.
	/// </summary>
	[Serializable]
	[XmlRoot("Rules")]
	public sealed class Parser : RuleListBase
	{
		private bool initialised;

		/// <summary>
		/// Gets or sets the default number format.
		/// </summary>
		/// <value>
		/// The default number format.
		/// </value>
		/// <remarks>
		/// The invariant format is used by default if no explicit value is set.
		/// </remarks>
		[XmlElement]
		public NumberFormatInfo NumberFormat { get; set; }

		/// <summary>
		/// Gets or sets the default date time format.
		/// </summary>
		/// <value>
		/// The default date time format.
		/// </value>
		/// <remarks>
		/// The invariant format is used by default if no explicit value is set.
		/// </remarks>
		[XmlElement]
		public DateTimeFormatInfo DateTimeFormat { get; set; }

		/// <summary>
		/// The symbol stack used during parsing back references.
		/// </summary>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields",
			Justification = "For performance reasons, this public member is a field.")]
		[XmlIgnore]
		internal Stack<string> BackReferences = new Stack<string>();

		/// <summary>
		/// Parses the specified text using the grammar.
		/// </summary>
		/// <param name="text">The text to parse.</param>
		/// <returns>The result of the parsing.</returns>
		public override OutputNode Parse(string text)
		{
			if (!initialised) Initialize();
			var result = Parse(text, 0);
			if (result.IsMatch)
			{
				// good so far, so check we are at the end of the file
				var eof = new SymbolRule("\\s*$");
				eof.Initialize(this);
				var atEnd = eof.Parse(text, result.End);
				if (atEnd.IsMatch) return result; else return ErrorNode ?? atEnd;
			}
			else
			{
				// return the error
				return result;
			}
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
			CommitPosition = 0;
			return Rules[0].Parse(text, position);
		}

		/// <summary>
		/// Initialises all the rules in this rule list.
		/// </summary>
		public void Initialize()
		{
			if (initialised) return;

			Initialize(this);
			var rules = new List<RuleBase>();
			GetRulesContainingIncludes(rules);
			foreach (var rule in rules)
			{
				rule.ResolveIncludes(this);
			}
			initialised = true;
		}

		[ExcludeFromCodeCoverage]
		internal override string FormattedOutput(OutputNode node)
		{
			throw new NotSupportedException();
		}

		/// <summary>
		/// Loads the parsing rules from the Xml.
		/// </summary>
		/// <param name="xml">The Xml that contains the parsing rules.</param>
		/// <returns>A grammar for the parsing rules.</returns>
		public static Parser LoadXml(string xml)
		{
			var rules = Objects.XmlDeserialize<Parser>(xml);
			rules.Initialize();
			return rules;
		}

		/// <summary>
		/// Gets or sets the error node.
		/// </summary>
		/// <value>
		/// The error node.
		/// </value>
		[XmlIgnore]
		public OutputNode ErrorNode { get; set; }

		/// <summary>
		/// Gets or sets the furthest committed position reached as defined by the <see cref="RuleBase.CheckPoint"/> property.
		/// </summary>
		[XmlIgnore]
		public int CommitPosition { get; internal set; } = 0;

		/// <summary>
		/// Initializes a new instance of the <see cref="Parser"/> class.
		/// </summary>
		public Parser()
			: base()
		{
			NumberFormat = (NumberFormatInfo)NumberFormatInfo.InvariantInfo.Clone();
			DateTimeFormat = (DateTimeFormatInfo)DateTimeFormatInfo.InvariantInfo.Clone();
		}
	}
}