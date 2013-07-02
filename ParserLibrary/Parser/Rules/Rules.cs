using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using ApiSoftware.Library35;
using System.Diagnostics.CodeAnalysis;

namespace ApiSoftware.Library35.Parsing
{
	/// <summary>
	/// A list of named rules for parsing text.
	/// </summary>
	[Serializable]
	public sealed class Rules : RuleListBase
	{
		internal string Text;

		/// <summary>
		/// Gets the <see cref="ApiSoftware.Library35.Parsing.RuleBase"/> with the specified name.
		/// </summary>
		public RuleBase this[string name]
		{
			get
			{
				try
				{
					return Rules.First(r => r.Name == name);
				}
				catch (InvalidOperationException e)
				{
					throw new InvalidOperationException("Attempt to reference rule with name '" + name + "' but no such rule exist. Check rule names against rule references.", e);
				}
			}
		}

		/// <summary>
		/// Parses the specified text using the grammar.
		/// </summary>
		/// <param name="text">The text to parse.</param>
		/// <returns>The result of the parsing.</returns>
		public OutputNode Parse(string text)
		{
			this.Text = text;
			if (this.grammar == null) { Initialise(); }
			//return Parse(0);
			var result = Parse(0);
			if (result.IsMatch)
			{
				// good so far, so check we are at the end of the file
				var eof = new Symbol("\\s*$");
				eof.Initialize(this);
				var atEnd = eof.Parse(result.End);
				if (atEnd.IsMatch) return result; else return atEnd;
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
			return Rules[0].Parse(position);
		}

		/// <summary>
		/// Loads the parsing rules from the Xml.
		/// </summary>
		/// <param name="xml">The Xml that contains the parsing rules.</param>
		/// <returns>A grammar for the parsing rules.</returns>
		public static Rules LoadXml(string xml)
		{
			var grammar = Objects.XmlDeserialize<Rules>(xml);
			grammar.Initialise();
			return grammar;
		}

		private void Initialise()
		{
			Initialize(this);
			var rules = new List<RuleBase>();
			GetRulesContainingIncludes(rules);
			foreach (var rule in rules)
			{
				rule.ResolveIncludes(this);
			}
		}

		[ExcludeFromCodeCoverage]
		internal override string FormattedOutput(OutputNode node)
		{
			throw new NotImplementedException();
		}

	}


}
