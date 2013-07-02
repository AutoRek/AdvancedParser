// <copyright file="ChoiceTest.cs">Copyright ©  2013</copyright>
using System;
using ApiSoftware.Library35.Parsing;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApiSoftware.Library35.Parsing
{
    /// <summary>This class contains parameterized unit tests for Choice</summary>
    [PexClass(typeof(Choice))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class ChoiceTest
    {
        /// <summary>Test stub for Parse(Int32)</summary>
        [PexMethod]
        public OutputNode Parse([PexAssumeUnderTest]Choice target, int position)
        {
            OutputNode result = target.Parse(position);
            return result;
            // TODO: add assertions to method ChoiceTest.Parse(Choice, Int32)
        }
    }
}
