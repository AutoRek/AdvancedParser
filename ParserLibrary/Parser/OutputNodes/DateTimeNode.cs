using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace ApiSoftware.Library35.Parsing
{
	/// <summary>
	/// A result node containing a datetime value.
	/// </summary>
	/// <remarks>
	/// The GetValue method returns a datetime valued object.
	/// </remarks>
	public sealed class DateTimeNode : OutputNode
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="DateTimeNode" /> class.
		/// </summary>
		/// <param name="rule">The rule.</param>
		/// <param name="text">The text.</param>
		/// <param name="index">The index.</param>
		/// <param name="length">The length of the element matched.</param>
		public DateTimeNode(DateTimeRule rule, string text, int index, int length)
			: base(rule, text, index)
		{
			End = index + length;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="DateTimeNode"/> class.
		/// </summary>
		[ExcludeFromCodeCoverage]
		private DateTimeNode(): base()
		{
			// used by the serializer only
		}
	}
}