using ApiSoftware.Library35.Parsing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ParserLibraryTests
{


	/// <summary>
	///This is a test class for OptionalTest and is intended
	///to contain all OptionalTest Unit Tests
	///</summary>
	[TestClass()]
	public class OptionalTest
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
		/// A test for Optional Constructor
		/// </summary>
		[TestMethod()]
		public void OptionalConstructorTest()
		{
			var rules = new Rules();
			var rule = new Optional();
			rule.Rule = new Symbol("A");
			rule.Initialize(rules);
			Assert.IsNotNull(rule.Grammar);
		}

		/// <summary>
		/// A test for ResolveIncludes
		/// </summary>
		[TestMethod()]
		public void ResolveIncludesTest()
		{
			var rules = Rules.LoadXml(@"<Rules><Optional Name='A'><Include>A</Include></Optional></Rules>");

			// ResolveIncludes already called - just check the self reference
			var rule = (rules["A"] as Optional);
			Assert.AreSame(rule, rule.Rule);
		}

		/// <summary>
		/// A test for Parse
		/// </summary>
		[TestMethod()]
		public void ParseTest()
		{
			var rules = Rules.LoadXml(@"<Rules><Sequence><Optional><Symbol>A</Symbol></Optional><Symbol>B</Symbol></Sequence></Rules>");

			OutputNode result;
			result = rules.Parse("AB");
			Assert.IsTrue(result.IsMatch);
			Assert.AreEqual(2, result.Children.Count);
			Assert.AreEqual("A", result.Children[0].Value());
			Assert.AreEqual("B", result.Children[1].Value());

			result = rules.Parse("B");
			Assert.IsTrue(result.IsMatch);
			Assert.AreEqual(2, result.Children.Count);
			Assert.AreEqual("", result.Children[0].Value()); // rule node is still included
			Assert.AreEqual("B", result.Children[1].Value());

		}

		/// <summary>
		/// Test that a choice template passes through to the chosen node
		/// </summary>
		[TestMethod]
		public void GetFormattedOutput()
		{
			var rules = Rules.LoadXml("<Rules><Sequence Template=':{0}{1}:'><Optional><Symbol Template='[{0}]'>A</Symbol></Optional><Symbol Template='({0})'>B</Symbol></Sequence></Rules>");
			var result = rules.Parse("AB");
			var output = result.FormattedOutput();
			Assert.AreEqual(":[A](B):", output);
		}
	}

}
