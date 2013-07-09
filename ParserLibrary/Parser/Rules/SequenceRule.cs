using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using System.Diagnostics;

namespace ApiSoftware.Library35.Parsing
{
	/// <summary>
	/// A sequence rule
	/// </summary>
	/// <remarks>
	/// A sequence rule is used to recognise a sequence of symbols, where each
	/// symbol may be literal or other value or a sub rule.
	/// </remarks>
	public sealed class SequenceRule : RuleListBase
	{
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
			int level = 0;
			if (rules != null) level = rules.Symbols.Count;
			//Trace.WriteLine(Name + ":" + position, "SequenceRule");
			var result = new BlockNode(this, text, position);
			foreach (var item in Rules)
			{
				var child = item.Parse(text, position);
				result.Children.Add(child);
				position = child.End;
				if (!child.IsMatch)
				{
					result.IsMatch = false;
					break;
				}
			}
			// update result to last position
			result.End = position;
			while (rules != null && rules.Symbols.Count > level) rules.Symbols.Pop();
			return result;
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
			if (Template == null || node.Children.Count == 0) { return string.Join(string.Empty, values); } else { return Template.Values(values); }
		}

		/// <summary>
		/// Adds the specified list of patterns as a sequence rule.
		/// </summary>
		/// <param name="patterns">The pattern list to add.</param>
		/// <returns>The rule list.</returns>
		/// <remarks>
		/// By returning the rule list, the method can be used with fluid syntax.
		/// </remarks>
		public override RuleListBase Add(params string[] patterns)
		{
			foreach (var pattern in patterns)
			{
				Add(pattern);
			}
			return this;
		}

	}

}
