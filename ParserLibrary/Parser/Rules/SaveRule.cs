using System;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using ApiSoftware.Library35;

namespace ApiSoftware.Library35.Parsing
{
	/// <summary>
	/// A push rule.
	/// </summary>
	/// <remarks>
	/// The save rule represents a single symbol in the content, e.g. a literal value
	/// or a number or a string. The symbol is encoded using a conventional regex.
	/// For example, encoding a symbol that allows optional preceding white space is 
	/// achieved by including <c>\s*</c> as a prefix to the symbol.
	/// 
	/// The Save rule can only be used in a sequence. When the symbol is matched, it 
	/// is saved onto the stack to be used by a back reference rule. At the end of
	/// the sequence the saved position is automatically pulled from the stack.
	/// 
	/// The Save rule and BackRef rules work together to implement xml element matching
	/// in the xml parser ensuring that the close element tag matches the opening tag.
	/// 
	/// When encoding literal values, especially punctuation, note that regex encoding 
	/// must be used, e.g. an open bracket would be specified as <c>Pattern = @"\(";</c>.
	/// </remarks>
	public sealed class SaveRule : RuleBase
	{
		private Regex expression = null;
		private string pattern;

		/// <summary>
		/// Gets or sets the pattern that represents the symbol.
		/// </summary>
		/// <value>
		/// The pattern.
		/// </value>
		[XmlText]
		public string Pattern
		{
			get { return pattern; }
			set { pattern = value; expression = new Regex("\\G" + pattern); } // The \G forces the pattern to start at the current position.
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
					parser.BackReferences.Push(match.Value);
					return new TextNode(this, text, position, match.Length);
				}
				else
				{
					// The pattern will have been set at run time, and the Expecting text might also have been changed.
					// So, in the event of error, replace the placeholder just before creating the error node.
					Expecting = Expecting.Replace("{pattern}", pattern);
					return new ErrorNode(this, text, position);
				}
			}
			catch (ArgumentOutOfRangeException)
			{
				throw new ArgumentOutOfRangeException("position", position, "parameter 'position' must be between zero and the length of the text being parsed.");
			}
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="SymbolRule"/> class.
		/// </summary>
		public SaveRule()
		{
			Expecting = "content matching pattern '{pattern}'";
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="SymbolRule"/> class.
		/// </summary>
		/// <param name="pattern">The pattern to initialise with.</param>
		public SaveRule(string pattern)
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