using ApiSoftware.Library35.Parsing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ParserLibraryTests
{


	/// <summary>
	///This is a test class for OneOrMoreTest and is intended
	///to contain all OneOrMoreTest Unit Tests
	///</summary>
	[TestClass()]
	public class OneOrMoreTest
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
		///A test for OneOrMore Constructor
		///</summary>
		[TestMethod()]
		public void OneOrMoreConstructorTest()
		{
			var rules = new Rules();
			var rule = new OneOrMore();
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
			var rules = Rules.LoadXml(@"<Rules><OneOrMore Name='A'><Include>A</Include></OneOrMore></Rules>");

			// ResolveIncludes already called - just check the self reference
			var rule = (rules["A"] as OneOrMore);
			Assert.AreSame(rule, rule.Rule);
		}

		/// <summary>
		/// A test for parsing one or more, no separators
		/// </summary>
		[TestMethod()]
		public void ParseNoSeparatorTest()
		{
			var rules = Rules.LoadXml(@"<Rules><OneOrMore><Symbol>A</Symbol></OneOrMore></Rules>");

			OutputNode result;
			result = rules.Parse("A");
			Assert.IsTrue(result.IsMatch);
			Assert.AreEqual(1, result.Children.Count);
			Assert.AreEqual("A", result.Children[0].Value());

			result = rules.Parse("AA");
			Assert.IsTrue(result.IsMatch);
			Assert.AreEqual(2, result.Children.Count);
			Assert.AreEqual("A", result.Children[0].Value());
			Assert.AreEqual("A", result.Children[1].Value());

			result = rules.Parse("AAA");
			Assert.IsTrue(result.IsMatch);
			Assert.AreEqual(3, result.Children.Count);
			Assert.AreEqual("A", result.Children[0].Value());
			Assert.AreEqual("A", result.Children[2].Value());

			result = rules.Parse("B");
			Assert.IsFalse(result.IsMatch);
		}

		/// <summary>
		/// A test for Parse
		/// </summary>
		[TestMethod()]
		public void ParseWithSeparatorTest()
		{
			var rules = Rules.LoadXml(@"<Rules><OneOrMore><Separator>,</Separator><Symbol>A</Symbol></OneOrMore></Rules>");

			OutputNode result;
			result = rules.Parse("A");
			Assert.IsTrue(result.IsMatch);
			Assert.AreEqual(1, result.Children.Count);
			Assert.AreEqual("A", result.Children[0].Value());

			result = rules.Parse("A,A");
			Assert.IsTrue(result.IsMatch);
			Assert.AreEqual(2, result.Children.Count);
			Assert.AreEqual("A", result.Children[0].Value());
			Assert.AreEqual("A", result.Children[1].Value());

			result = rules.Parse("A,A,A");
			Assert.IsTrue(result.IsMatch);
			Assert.AreEqual(3, result.Children.Count);
			Assert.AreEqual("A", result.Children[0].Value());
			Assert.AreEqual("A", result.Children[2].Value());

			result = rules.Parse("B");
			Assert.IsFalse(result.IsMatch);

			result = rules.Parse("A,B");
			Assert.IsFalse(result.IsMatch);

		}

		/// <summary>
		/// This test ensures that the item in the OneOrMore element is the rule.
		/// </summary>
		[TestMethod()]
		public void RuleTest()
		{
			var rules = Rules.LoadXml(@"<Rules><OneOrMore><Symbol>B</Symbol></OneOrMore></Rules>");
			Assert.IsInstanceOfType(rules.Rules[0], typeof(OneOrMore));
			Assert.IsInstanceOfType((rules.Rules[0] as OneOrMore).Rule, typeof(Symbol));
		}

		/// <summary>
		/// This test ensures that the 'Separator' element is interpreted as the symbol to be used as the separator rule.
		/// </summary>
		[TestMethod()]
		public void SeparatorTest()
		{
			var rules = Rules.LoadXml(@"<Rules><OneOrMore><Separator>B</Separator><Symbol>A</Symbol></OneOrMore></Rules>");
			Assert.IsInstanceOfType(rules.Rules[0], typeof(OneOrMore));
			Assert.IsInstanceOfType((rules.Rules[0] as OneOrMore).Separator, typeof(Symbol));
			Assert.AreEqual("B", (rules.Rules[0] as OneOrMore).Separator.Pattern);
		}
	}
}
