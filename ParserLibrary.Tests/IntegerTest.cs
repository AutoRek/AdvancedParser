// <copyright file="IntegerTest.cs">Copyright ©  2013</copyright>

using System;
using ApiSoftware.Library35.Parsing;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;

namespace ApiSoftware.Library35.Parsing
{
    [PexClass(typeof(Integer))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class IntegerTest
    {
    }
}
