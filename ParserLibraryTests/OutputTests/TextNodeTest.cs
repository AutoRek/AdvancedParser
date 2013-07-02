using ApiSoftware.Library35.Parsing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ParserLibraryTests
{


	/// <summary>
	///This is a test class for TextNodeTest and is intended
	///to contain all TextNodeTest Unit Tests
	///</summary>
	[TestClass()]
	public class TextNodeTest
	{


		private TestContext testContextInstance;

		/// <summary>
		///Gets or sets the test context which provides
		///information about and functionality for the current test run.
		///</summary>
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


		/// <summary>
		///A test for TextNode Constructor
		///</summary>
		[TestMethod()]
		public void TextNodeConstructorTest()
		{
			var rule = new Symbol("TEST");
			var index = 1000;
			var node = new TextNode(rule, index, 100);
			Assert.AreSame(rule, node.Rule);
			Assert.AreEqual(index, node.Begin);
			Assert.AreEqual(index + 100, node.End);
			Assert.IsTrue(node.IsMatch);
		}

		/// <summary>
		///A test for GetValue
		///</summary>
		[TestMethod()]
		public void GetValueTest()
		{
			var rules = Rules.LoadXml(@"<Rules><Symbol>1</Symbol></Rules>");
			var result = rules.Parse("1");
			var node = new TextNode(rules.Rules[0], 0, 1);
			Assert.AreEqual("1", node.Value());
		}
	}
}
