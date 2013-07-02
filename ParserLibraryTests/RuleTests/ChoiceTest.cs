using ApiSoftware.Library35.Parsing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ParserLibraryTests
{


	/// <summary>
	///This is a test class for ChoiceTest and is intended
	///to contain all ChoiceTest Unit Tests
	///</summary>
	[TestClass()]
	public class ChoiceTest
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
		///A test for Choice Constructor
		///</summary>
		[TestMethod()]
		public void ChoiceConstructorTest()
		{
			var rules = new Rules();
			var rule = new Choice();
			rule.Initialize(rules);

			Assert.IsNotNull(rule.Rules);
			Assert.IsNotNull(rule.Grammar);
		}

		/// <summary>
		///A test for Parse
		///</summary>
		[TestMethod()]
		public void ParseTest()
		{
			var rules = Rules.LoadXml(@"<Rules><Choice><Symbol>A</Symbol><Symbol>B</Symbol></Choice></Rules>");

			OutputNode result;
			result = rules.Parse("A");
			Assert.IsTrue(result.IsMatch);
			Assert.AreEqual(0, result.Children.Count);
			Assert.AreEqual("A", result.Value());

			result = rules.Parse("B");
			Assert.IsTrue(result.IsMatch);
			Assert.AreEqual(0, result.Children.Count);
			Assert.AreEqual("B", result.Value());

			result = rules.Parse("C");
			Assert.IsFalse(result.IsMatch);
			Assert.AreEqual(0, result.Children.Count);
			Assert.IsInstanceOfType(result, typeof(ErrorNode));
		}

		/// <summary>
		/// Test that a choice template passes through to the chosen node
		/// </summary>
		[TestMethod]
		public void GetFormattedOutput()
		{
			var rules = Rules.LoadXml("<Rules><Sequence Template=':{0}:'><Choice><Symbol Template='[{0}]'>A</Symbol><Symbol>B</Symbol></Choice></Sequence></Rules>");
			var result = rules.Parse("A");
			var output = result.FormattedOutput();
			Assert.AreEqual(":[A]:", output);
		}
	}
}
