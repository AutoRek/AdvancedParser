using System;
using ApiSoftware.Library35.Parsing;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace ApiSoftware.Library35.Parsing
{
	/// <summary>
	/// Interface of a parsing rule
	/// </summary>
	public interface IRule
	{
		/// <summary>
		/// Gets or sets the name of the rule
		/// </summary>
		/// <value>
		/// The name of the rule.
		/// </value>
		[XmlAttribute]
		string Name { get; set; }

		/// <summary>
		/// Gets or sets the field name the rule parses (if any).
		/// </summary>
		/// <value>
		/// The column name.
		/// </value>
		[XmlAttribute]
		string Field { get; set; }

		/// <summary>
		/// Gets or sets the name of the new record the rule will populate (if any).
		/// </summary>
		/// <value>
		/// The record name.
		/// </value>
		/// <remarks>
		/// The record name is commonly used as the table name when filling a data set
		/// or the element name when generating XML.
		/// </remarks>
		[XmlAttribute]
		string Record { get; set; }

		/// <summary>
		/// Gets or sets the rule's output template.
		/// </summary>
		/// <value>
		/// The template.
		/// </value>
		/// <remarks>
		/// The rule's output template is used by result nodes to get formatted text output.
		/// </remarks>
		[XmlAttribute]
		string Template { get; set; }

		/// <summary>
		/// Gets or sets the rule's error template.
		/// </summary>
		/// <value>
		/// The error template.
		/// </value>
		/// <remarks>
		/// The rule's error template is used to override the default error message returned 
		/// by a result node when the rule has failed to parse.
		/// </remarks>
		[XmlAttribute]
		string ErrorTemplate { get; set; }

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
		OutputNode Parse(string text);

		/// <summary>
		/// Uses the rule to parse the text from the specified position.
		/// </summary>
		/// <param name="text">The text being parsed.</param>
		/// <param name="position">The position to parse from.</param>
		/// <returns>
		/// The result node of the parse.
		/// </returns>
		/// <remarks>
		/// If the rule parses successfully, the result will reflect the new position
		/// for the next rule to begin parsing from. If the rule does not parse
		/// successfully, the rule leaves the position unchanged. In this case the
		/// rules will back-track up the stack to find the next rule that will parse
		/// from the current position. If no rule can parse, then the text is
		/// incorrectly formatted and the overall parse result will be unsuccessful.
		/// </remarks>
		OutputNode Parse(string text, int position);

	}

	/// <summary>
	/// 
	/// </summary>
	public interface IRuleList : IRule
	{
		/// <summary>
		/// Gets the rules.
		/// </summary>
		/// <value>
		/// The rules.
		/// </value>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists",
			Justification = "Performance critical - use generic list")]
		List<RuleBase> Rules { get; }
	}

}
