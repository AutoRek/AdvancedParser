using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ParserLibraryTests
{
	/// <summary>
	/// Extra assert methods
	/// </summary>
	static class AssertUtils
	{
		/// <summary>
		/// Ensures that the code in the action raises the exception.
		/// </summary>
		/// <param name="requiredType">The exception.</param>
		/// <param name="action">The action.</param>
		public static void RaisesException(Type requiredType, Action action)
		{
			try
			{
				action();
				Assert.Fail("Exception should have been raised.");
			}
			catch (AssertFailedException e)
			{
				throw e;
			}
			catch (Exception e)
			{
				Assert.IsInstanceOfType(e, requiredType);
			}
		}
	}
}
