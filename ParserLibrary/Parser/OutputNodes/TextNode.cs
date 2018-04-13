using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

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
	public sealed class TextNode : OutputNode
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="IntegerNode" /> class.
		/// </summary>
		/// <param name="rule">The rule that parsed the element.</param>
		/// <param name="text">The text teh node refers to.</param>
		/// <param name="index">The index within the text of the matched element.</param>
		/// <param name="length">The length of the element matched.</param>
		public TextNode(RuleBase rule, string text, int index, int length) : base(rule, text, index) { End = index + length; }

		/// <summary>
		/// Initializes a new instance of the <see cref="TextNode"/> class.
		/// </summary>
		[ExcludeFromCodeCoverage]
		private TextNode()
		{
			// used by the serializer only
		}
	}
}