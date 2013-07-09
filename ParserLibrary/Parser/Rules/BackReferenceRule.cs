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
	/// A back reference rule.
	/// </summary>
	/// <remarks>
	/// The back reference rule matches a symbol previously matched and saved by the save rule.
	/// </remarks>
	public sealed class BackReferenceRule : RuleBase
	{
		private string symbol;


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
				symbol = rules.Symbols.Peek();
				//if (string.IsNullOrEmpty(pattern)) expression = new Regex(Regex.Escape(symbol));
				if (string.Compare(text, position, symbol, 0, symbol.Length) == 0)
				//var match = expression.Match(text ?? string.Empty, position);
				//if (match.Success)
				{
					//Trace.WriteLine(Name + ":" + position + ":true:" + match.Value, "SymbolRule");
					return new TextNode(this, text, position, symbol.Length);
				}
				else
				{
					//Trace.WriteLine(Name + ":" + position + ":false", "SymbolRule");
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
			return string.Format(CultureInfo.InvariantCulture, GetErrorFormatString(), tp.Line, tp.Character, tp.Symbol, symbol, tp.Index);
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="SymbolRule"/> class.
		/// </summary>
		public BackReferenceRule()
		{
			ErrorTemplate = "$: expected symbol matching regex pattern '{3}'.";
		}

		internal override string FormattedOutput(OutputNode node)
		{
			if (string.IsNullOrEmpty(Template)) return string.Empty; else return string.Format(Template, node.NodeText);
		}

	}

}
