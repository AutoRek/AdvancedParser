// <copyright file="IfRuleTest.cs">Copyright ©  2013</copyright>

using System;
using ApiSoftware.Library35.Parsing;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApiSoftware.Library35.Parsing
{
	[TestClass]
	[PexClass(typeof(IfRule))]
	[PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
	[PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
	public partial class IfRuleTest
	{
		private string sample1 = "";
		private SequenceRule sequence = new SequenceRule();

		[PexMethod]
		public OutputNode Parse(
			[PexAssumeUnderTest]IfRule target,
			string text,
			int position
		)
		{

			OutputNode result = target.Parse(text, position);
			return result;
		}

		[PexMethod]
		public OutputNode ParseTest(string text)
		{
			var sequence = new SequenceRule();
			sequence.Add("\\(");
			sequence.Add("A");
			sequence.Add("\\)");

			var target = new IfRule();
			target.Rule = sequence;
			target.Pattern = "\\(";

			OutputNode result = this.Parse(target, text, 0);

			if (text == "(A)")
			{
				Assert.AreEqual(3, result.Children.Count);
			}

			if (text == "(A(")
			{
				Assert.IsFalse(result.IsMatch);
				Assert.IsInstanceOfType(result.Children[2], typeof(ErrorNode));
			}
			return result;
		}
	}
}
