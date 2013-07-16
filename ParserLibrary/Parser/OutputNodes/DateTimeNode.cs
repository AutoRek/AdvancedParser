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
		private DateTimeNode()
		{
			// used by the serializer only
		}
	}

}
