using ApiSoftware.Library35.Parsing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ParserLibraryTests
{


	/// <summary>
	///This is a test class for SymbolTest and is intended
	///to contain all SymbolTest Unit Tests
	///</summary>
	[TestClass()]
	public class SymbolTest
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
		///A test for Symbol Constructor
		///</summary>
		[TestMethod()]
		public void SymbolConstructorTest1()
		{
			var rules = new Rules();
			var rule = new Symbol();
			rule.Initialize(rules);
			Assert.IsNotNull(rule.Grammar);
		}

		/// <summary>
		///A test for Symbol Constructor
		///</summary>
		[TestMethod()]
		public void SymbolConstructorTest2()
		{
			var rules = new Rules();
			var rule = new Symbol("TEST");
			rule.Initialize(rules);
			Assert.IsNotNull(rule.Grammar);
			Assert.AreEqual("TEST", rule.Pattern);
		}

		/// <summary>
		///A test for GetErrorReason
		///</summary>
		[TestMethod()]
		public void GetErrorReasonTest()
		{
			var rules = Rules.LoadXml(@"<Rules><Sequence><Symbol>A</Symbol><Symbol>C</Symbol></Sequence></Rules>");
			OutputNode result = rules.Parse("AB");
			Assert.IsFalse(result.IsMatch);
			var error = result.GetErrorText();
			Assert.AreEqual("Error at line 0, position 1: Expected 'C' but found 'B'", error);
		}

		/// <summary>
		///A test for Parse
		///</summary>
		[TestMethod()]
		public void ParseTest()
		{
			var rules = Rules.LoadXml(@"<Rules><Sequence><Symbol>\s*\w*:</Symbol><Symbol>B</Symbol></Sequence></Rules>");

			OutputNode result;
			result = rules.Parse(" :B");
			Assert.IsTrue(result.IsMatch);
			Assert.AreEqual(2, result.Children.Count);
			Assert.AreEqual(" :", result.Children[0].Value());
			Assert.AreEqual("B", result.Children[1].Value());

			result = rules.Parse("A:B");
			Assert.IsTrue(result.IsMatch);
			Assert.AreEqual(2, result.Children.Count);
			Assert.AreEqual("A:", result.Children[0].Value());
			Assert.AreEqual("B", result.Children[1].Value());

			result = rules.Parse("a123:B");
			Assert.IsTrue(result.IsMatch);
			Assert.AreEqual(2, result.Children.Count);
			Assert.AreEqual("a123:", result.Children[0].Value());
			Assert.AreEqual("B", result.Children[1].Value());

		}

	}
}
