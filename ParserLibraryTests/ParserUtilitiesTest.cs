using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ApiSoftware.Library35.Parsing;

namespace ParserLibraryTests
{
	/// <summary>
	///This is a test class for TextPointTest and is intended
	///to contain all TextPointTest Unit Tests
	///</summary>
	[TestClass()]
	public class ParserUtilitiesTests
	{

		private TestContext testContextInstance;

		/// <summary>
		/// Gets or sets the test context which provides
		/// information about and functionality for the current test run.
		/// </summary>
		public TestContext TestContext
		{
			get
			{
				return testContextInstance;
			}
			set
			{
				testContextInstance = value;
			}
		}

		#region Additional test attributes
		// 
		//You can use the following additional attributes as you write your tests:
		//
		//Use ClassInitialize to run code before running the first test in the class
		//[ClassInitialize()]
		//public static void MyClassInitialize(TestContext testContext)
		//{
		//}
		//
		//Use ClassCleanup to run code after all tests in a class have run
		//[ClassCleanup()]
		//public static void MyClassCleanup()
		//{
		//}
		//
		//Use TestInitialize to run code before running each test
		//[TestInitialize()]
		//public void MyTestInitialize()
		//{
		//}
		//
		//Use TestCleanup to run code after each test has run
		//[TestCleanup()]
		//public void MyTestCleanup()
		//{
		//}
		//
		#endregion


		[TestMethod]
		public void GetErrorTextTest()
		{
			// null or matching nodes should return NULL as error text
			TextNode node = null;
			Assert.IsNull(node.GetErrorText());
			node = new TextNode(null, "A", 0, 1);
			Assert.IsNull(node.GetErrorText());
		}
		
		[TestMethod]
		public void GetErrorNodeTest()
		{
			// null or matching nodes should return NULL as error node
			TextNode node = null;
			Assert.IsNull(node.GetErrorNode());
			node = new TextNode(null, "A", 0, 1);
			Assert.IsNull(node.GetErrorNode());
		}

	}
}
