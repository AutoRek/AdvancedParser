// <copyright file="IntegerRuleTest.cs">Copyright ©  2013</copyright>

using System;
using ApiSoftware.Library35.Parsing;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Pex.Framework.Generated;

namespace ApiSoftware.Library35.Parsing
{
	[TestClass]
	[PexClass(typeof(IntegerRule))]
	[PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
	[PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
	public partial class IntegerRuleTest
	{
		[PexMethod, PexAllowedException(typeof(ArgumentOutOfRangeException))]
		public OutputNode Parse(
			[PexAssumeUnderTest]IntegerRule target,
			string text,
			int position
		)
		{
			OutputNode result = target.Parse(text, position);

			// specific examples of inputs and outputs
			if (text == "1" && position == 0)
			{
				Assert.IsInstanceOfType(result, typeof(IntegerNode));
				Assert.AreEqual(1, result.Value);
			}

			return result;
		}


	}
}
