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
	/// A result node containing a decimal value.
	/// </summary>
	/// <remarks>
	/// The GetValue method returns a decimal valued object.
	/// </remarks>
	public sealed class DecimalNode : OutputNode
	{

		/// <summary>
		/// Initializes a new instance of the <see cref="DecimalNode" /> class.
		/// </summary>
		/// <param name="rule">The rule.</param>
		/// <param name="text">The text.</param>
		/// <param name="index">The index.</param>
		/// <param name="length">The length of the element matched.</param>
		public DecimalNode(DecimalRule rule, string text, int index, int length)
			: base(rule, text, index)
		{
			End = index + length;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="DecimalNode"/> class.
		/// </summary>
		[ExcludeFromCodeCoverage]
		private DecimalNode()
		{
			// used by the serializer only
		}
	}

}
