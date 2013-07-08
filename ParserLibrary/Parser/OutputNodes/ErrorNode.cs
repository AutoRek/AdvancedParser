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
	/// Represents an error when a parsing rule was applied to the text.
	/// </summary>
	/// <remarks>
	/// If the rule is successful, the Position value is updated to the 
	/// end of the content that has been successfully parsed.
	/// If the rule is unsuccessful, the Position is left unchanged.
	/// </remarks>
	public sealed class ErrorNode : OutputNode
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ErrorNode" /> class.
		/// </summary>
		/// <param name="rule">The rule the node corresponds to.</param>
		/// <param name="text">The text the node refers to.</param>
		/// <param name="index">The index position in the text.</param>
		public ErrorNode(RuleBase rule, string text, int index)
			: base(rule, text, index)
		{
			IsMatch = false;
			End = index;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ErrorNode"/> class.
		/// </summary>
		[ExcludeFromCodeCoverage]
		private ErrorNode()
		{
			// Used by the serializer only
		}

	}

}
