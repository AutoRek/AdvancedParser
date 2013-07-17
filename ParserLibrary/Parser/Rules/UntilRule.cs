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
	/// An until rule.
	/// </summary>
	/// <remarks>
	/// The until rule matches all content until it hits the specified pattern, but
	/// does not consume the pattern itself (which is then available for the next rule).
	/// The until is encoded using a conventional regex.
	/// </remarks>
	public sealed class UntilRule : RuleBase
	{
		private Regex expression = null;
		private string pattern;

		/// <summary>
		/// Gets or sets the pattern that represents the until rule.
		/// </summary>
		/// <value>
		/// The pattern.
		/// </value>
		[XmlText]
		public string Pattern
		{
			get { return pattern; }
			set { pattern = value; expression = new Regex("\\G.*?(?=" + pattern + ")", RegexOptions.Singleline | RegexOptions.Multiline); } // The \G forces the pattern to start at the current position.
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
				var match = expression.Match(text ?? string.Empty, position);
				if (match.Success)
				{
					//Trace.WriteLine(Name + ":" + position + ":true:" + match.Value, "UntilRule");
					return new TextNode(this, text, position, match.Length);
				}
				else
				{
					//Trace.WriteLine(Name + ":" + position + ":false", "UntilRule");
					return new ErrorNode(this, text, position);
				}
			}
			catch (ArgumentOutOfRangeException)
			{
				throw new ArgumentOutOfRangeException("position", position, "parameter 'position' must be between zero and the length of the text being parsed.");
			}
		}

		/// <summary>
		/// Gets the error text for the node for this rule.
		/// </summary>
		/// <param name="node">The node.</param>
		/// <returns>The error text.</returns>
		internal override protected string GetErrorText(OutputNode node)
		{
			if (node == null) throw new ArgumentNullException("node");
			var tp = new TextPoint(node.Text, node.Begin);
			return string.Format(CultureInfo.InvariantCulture, CreateErrorFormatString(), tp.Line, tp.Character, tp.Symbol, pattern, tp.Index);
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="UntilRule"/> class.
		/// </summary>
		public UntilRule()
		{
			ErrorTemplate = "$: expected until matching regex pattern '{3}'.";
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="UntilRule"/> class.
		/// </summary>
		/// <param name="pattern">The pattern to initialise with.</param>
		public UntilRule(string pattern)
			: this()
		{
			Pattern = pattern;
		}

		internal override string FormattedOutput(OutputNode node)
		{
			if (string.IsNullOrEmpty(Template)) return string.Empty; else return string.Format(CultureInfo.CurrentCulture, Template, node.NodeText);
		}

		/// <summary>
		/// Returns a <see cref="System.String" /> that represents this instance.
		/// </summary>
		/// <returns>
		/// A <see cref="System.String" /> that represents this instance.
		/// </returns>
		public override string ToString()
		{
			return base.ToString() + "(" + pattern + ")";
		}
	}

}
