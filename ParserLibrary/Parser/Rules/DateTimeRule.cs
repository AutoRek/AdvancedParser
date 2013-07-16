using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using ApiSoftware.Library35;
using System.Globalization;
using System.Diagnostics;

namespace ApiSoftware.Library35.Parsing
{
	/// <summary>
	/// A date time rule.
	/// </summary>
	/// <remarks>
	/// The date time rule parses a single date time value. 
	/// Whitespace before the date time value is ignored.
	/// </remarks>
	[XmlRoot("DateTime")]
	public sealed class DateTimeRule : RuleBase
	{
		private const string defaultPattern = @"\s*[0-9.:\\/-]+\b";
		private Regex expression = new Regex(@"\G" + defaultPattern);
		private string pattern = defaultPattern;

		/// <summary>
		/// Gets or sets the pattern that represents the symbol.
		/// </summary>
		/// <value>
		/// The pattern.
		/// </value>
		/// <remarks>
		/// A default pattern is provided and used if the pattern is not supplied explicitly.
		/// Supplying an explicit pattern allows more specific control of the content that
		/// the rule can parse.
		/// </remarks>
		[XmlText]
		public string Pattern
		{
			get { return pattern; }
			set { pattern = value; expression = new Regex("\\G" + pattern); } // The \G forces the pattern to start at the current position.
		}

		/// <summary>
		/// Gets or sets the format used to parse the value.
		/// </summary>
		/// <value>
		/// The format provider object
		/// </value>
		/// <remarks>
		/// The invariant culture is used by default. To fully override the invariant culture
		/// in a rule, include a Format tag and the required options of the format info object 
		/// in element form, e.g. 
		/// <code>
		/// <![CDATA[ <Decimal><Format><NumberDecimalSeparator>,</NumberDecimalSeparator></Format></Decimal> ]]>
		/// </code>
		/// </remarks>
		[XmlElement]
		public DateTimeFormatInfo Format { get; set; }

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
				var match = expression.Match(text ?? string.Empty, position);
				if (match.Success)
				{
					//Trace.WriteLine(Name + ":" + position + ":true", "datetimeRule");
					return new DateTimeNode(this, text, position, match.Length);
				}
				else
				{
					//Trace.WriteLine(Name + ":" + position + ":false", "datetimeRule");
					return new ErrorNode(this, text, position);
				}
			}
			catch (ArgumentOutOfRangeException)
			{
				throw new ArgumentOutOfRangeException("position", position, "parameter 'position' must be between zero and the length of the text being parsed.");
			}
		}

		/// <summary>
		/// Initialises the rule with the grammar.
		/// </summary>
		/// <param name="rules">The grammar to initialise with.</param>
		protected internal override void Initialize(Parser rules)
		{
			base.Initialize(rules);
			if (Format == null) Format = parserRules.DateTimeFormat;
		}

		/// <summary>
		/// Uses the date time rule to get the value of the node 
		/// </summary>
		/// <param name="node">Node to get the value of.</param>
		/// <returns>Object containing the date time value of the node (or null).</returns>
		internal override object GetValue(OutputNode node)
		{
			DateTime i;
			if (DateTime.TryParse(node.NodeText, Format, DateTimeStyles.AssumeLocal, out i)) return i; else return null;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="DateTimeRule"/> class.
		/// </summary>
		public DateTimeRule()
		{
			ErrorTemplate = "$: expected a date value.";
			//Format = DateTimeFormatInfo.InvariantInfo;
		}
	}

}
