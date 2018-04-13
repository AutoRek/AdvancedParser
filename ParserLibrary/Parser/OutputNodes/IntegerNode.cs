using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace ApiSoftware.Library35.Parsing
{
	/// <summary>
	/// A result node containing an integer value.
	/// </summary>
	/// <remarks>
	/// The GetValue method returns an integer valued object.
	/// </remarks>
	public sealed class IntegerNode : OutputNode
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="IntegerNode" /> class.
		/// </summary>
		/// <param name="rule">The rule.</param>
		/// <param name="text">The text.</param>
		/// <param name="index">The index.</param>
		/// <param name="length">The length of the element matched.</param>
		public IntegerNode(IntegerRule rule, string text, int index, int length)
			: base(rule, text, index)
		{
			End = index + length;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="IntegerNode"/> class.
		/// </summary>
		[ExcludeFromCodeCoverage]
		private IntegerNode()
		{
			// used by the serializer only
		}
	}
}