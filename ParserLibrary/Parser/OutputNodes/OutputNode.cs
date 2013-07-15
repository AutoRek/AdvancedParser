using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using System.Data;
using System.Diagnostics.CodeAnalysis;

namespace ApiSoftware.Library35.Parsing
{
	/// <summary>
	/// Represents the result of a rule being applied to the text.
	/// </summary>
	/// <remarks>
	/// If the rule is successful, the Position value is updated to the 
	/// end of the content that has been successfully parsed.
	/// If the rule is unsuccessful, the Position is left unchanged.
	/// </remarks>
	[Serializable]
	[XmlInclude(typeof(TextNode))]
	[XmlInclude(typeof(IntegerNode))]
	[XmlInclude(typeof(BlockNode))]
	[XmlInclude(typeof(ErrorNode))]
	public abstract class OutputNode
	{

		/// <summary>
		/// Name of the field used for the record Id, if used.
		/// </summary>
		public const string RecordIdField = "$RowId";

		/// <summary>
		/// Name of the field used for the parent Id, if used.
		/// </summary>
		public const string ParentIdField = "$ParentId";

		private List<OutputNode> children = new List<OutputNode>();

		/// <summary>
		/// The text the node refers to.
		/// </summary>
		/// <remarks>
		/// For performance reasons, this is a publicly visible field.
		/// </remarks>
		[XmlIgnore]
		public string Text { get { return text; } }

		private string text;

		/// <summary>
		/// Gets the list of child results to this result.
		/// </summary>
		/// <value>
		/// The list of child nodes.
		/// </value>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists",
			Justification = "Performance critical - use generic list")]
		[XmlElement(typeof(TextNode))]
		[XmlElement(typeof(IntegerNode))]
		[XmlElement(typeof(BlockNode))]
		[XmlElement(typeof(ErrorNode))]
		public List<OutputNode> Children { get { return children; } }

		/// <summary>
		/// Gets or sets a value indicating whether the rule was successful.
		/// </summary>
		/// <value>
		///   <c>true</c> if the rule was successful; otherwise, <c>false</c>.
		/// </value>
		[XmlAttribute]
		public bool IsMatch { get; set; }

		/// <summary>
		/// Gets or sets the start position of the result.
		/// </summary>
		/// <value>
		/// The start.
		/// </value>
		[XmlAttribute]
		public int Begin { get; set; }

		/// <summary>
		/// Gets or sets the position of the last match.
		/// </summary>
		/// <value>
		/// The position.
		/// </value>
		[XmlAttribute]
		public int End { get; set; }

		/// <summary>
		/// Gets or sets the rule that generated the result.
		/// </summary>
		/// <value>
		/// The rule.
		/// </value>
		[XmlIgnore]
		public RuleBase Rule { get; internal set; }

		/// <summary>
		/// Gets the formatted output for the node.
		/// </summary>
		/// <returns></returns>
		public string FormattedOutput()
		{
			if (IsMatch)
			{
				return Rule.FormattedOutput(this);
			}
			else
			{
				// If no match, cannot return formatted output
				return string.Empty;
			}
		}

		/// <summary>
		/// Gets the value of the node.
		/// </summary>
		/// <returns>The value in the type the rule specified.</returns>
		[XmlIgnore]
		virtual public object Value
		{
			get { return Rule.GetValue(this); }
		}

		/// <summary>
		/// Gets the text value of the node.
		/// </summary>
		/// <returns>The value as a string.</returns>
		[XmlIgnore]
		virtual public string NodeText
		{
			get { return text.Substring(Begin, End - Begin); }
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="OutputNode" /> class.
		/// </summary>
		/// <param name="rule">The rule the node corresponds to.</param>
		/// <param name="text">The text the node refers to.</param>
		/// <param name="index">The index position in the text.</param>
		protected OutputNode(RuleBase rule, string text, int index)
		{
			Begin = index;
			Rule = rule;
			IsMatch = true;
			this.text = text;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="OutputNode"/> class.
		/// </summary>
		[ExcludeFromCodeCoverage]
		protected OutputNode()
		{
			// Serializer use only
		}
	}

}
