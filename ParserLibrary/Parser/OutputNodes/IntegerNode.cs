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
	/// A result node containing an integer value.
	/// </summary>
	/// <remarks>
	/// The GetValue method returns an integer valued object.
	/// </remarks>
	public sealed class IntegerNode : OutputNode
	{
		///// <summary>
		///// Gets the value.
		///// </summary>
		///// <returns></returns>
		//public override object GetValue()
		//{
		//    return
		//}

		/// <summary>
		/// Initializes a new instance of the <see cref="IntegerNode"/> class.
		/// </summary>
		/// <param name="rule">The rule.</param>
		/// <param name="index">The index.</param>
		/// <param name="length">The length of the element matched.</param>
		public IntegerNode(Integer rule, int index, int length)
			: base(rule, index)
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
