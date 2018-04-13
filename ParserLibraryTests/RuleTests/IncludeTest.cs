using ApiSoftware.Library35.Parsing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ParserLibraryTests
{


	/// <summary>
	///This is a test class for IncludeTest and is intended
	///to contain all IncludeTest Unit Tests
	///</summary>
	[TestClass()]
	public class IncludeTest
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
		/// A test for Include Constructor
		/// </summary>
		[TestMethod()]
		public void IncludeConstructorTest()
		{
			var rules = new Parser();
			var rule = new ReferenceRule();
			rules.Add(rule);
			Assert.IsNull(rule.ErrorTemplate);
			Assert.IsNull(rule.Template);
		}

		/// <summary>
		///A test for Parse
		///</summary>
		[TestMethod()]
		public void ParseTest()
		{
			// rule ABA where B can be 'B' or another ABA rule.
			var rules = Parser.LoadXml(@"<Rules><Sequence Name='ABA'><Symbol>A</Symbol><Choice><Include>ABA</Include><Symbol>B</Symbol></Choice><Symbol>A</Symbol></Sequence></Rules>");

			OutputNode result;
			result = rules.Parse("ABA");
			Assert.IsTrue(result.IsMatch);
			Assert.AreEqual(3, result.Children.Count);
			Assert.AreEqual("ABA", result.Value);

			result = rules.Parse("AABAA");
			Assert.IsTrue(result.IsMatch);
			Assert.AreEqual(3, result.Children.Count);
			Assert.AreEqual("AABAA", result.Value);

			result = rules.Parse("AA");
			Assert.IsFalse(result.IsMatch);
			Assert.AreEqual(2, result.Children.Count);
			Assert.IsInstanceOfType(result, typeof(BlockNode));

		}

		/// <summary>
		///A test for Reference
		///</summary>
		[TestMethod()]
		public void ReferenceTest()
		{
			var rules = Parser.LoadXml(@"<Rules><Choice><Include>A</Include><Symbol>B</Symbol></Choice><Symbol Name='A'>A</Symbol></Rules>");

			// Include rule should switch pointers to the named rule
			Assert.AreSame(
				rules.Rules[1],							// The symbol rule 'A'
				(rules.Rules[0] as ChoiceRule).Rules[0]		// The included rule in the first choice position.
				);

		}
	}
}
