using ApiSoftware.Library35.Parsing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ParserLibraryTests
{


	/// <summary>
	/// This is a test class for WhitespaceTest and is intended
	/// to contain all WhitespaceTest Unit Tests
	/// </summary>
	[TestClass()]
	public class WhitespaceTest : RuleTestsBaseClass
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


		/// <summary>
		/// A test for Whitespace Constructor
		/// </summary>
		[TestMethod()]
		public override void ConstructorTest()
		{
			var rules = new Parser();
			var rule = new WhitespaceRule();
			rule.Initialize(rules);
			Assert.IsNotNull(rule.ErrorTemplate);
			Assert.IsNull(rule.Template);
		}

		/// <summary>
		/// All consecutive whitespace is read as one block.
		/// </summary>
		[TestMethod()]
		public override void ParseTest()
		{
			var rule = CreateTestRule();
			OutputNode result;

			result = rule.Parse("\t B");
			Assert.IsTrue(result.IsMatch);
			Assert.AreEqual("\t ", result.Value);

			result = rule.Parse("B A");
			Assert.IsFalse(result.IsMatch);

			result = rule.Parse(null);
			Assert.IsFalse(result.IsMatch);
		}

		/// <summary>
		/// A simple instance of the rule will parse a variety of sample text
		/// values and output the correct output nodes. This test covers the
		/// case when parsing is carried out from a location within the text.
		/// Some specific failure cases will also be tried to test that parsing
		/// started from the  correct location.
		/// </summary>
		[TestMethod()]
		public override void ParsePositionTest()
		{
			var rule = CreateTestRule();
			OutputNode result;

			result = rule.Parse("C\t A B", 1);
			Assert.IsTrue(result.IsMatch);
			Assert.AreEqual("\t ", result.Value);

			result = rule.Parse("A B", 2);
			Assert.IsFalse(result.IsMatch);
		}

		/// <summary>
		/// If a rule attempts to parse an out-of-range position, an error is
		/// raised explicitly describing the situation
		/// </summary>
		[TestMethod()]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public override void ParseErrorInput()
		{
			var rule = CreateTestRule();
			var text = "A";
			var result = rule.Parse(text, 3);
		}

		/// <summary>
		/// This test checks that when a simple rule has parsed some text
		/// it generates the correct output based on the result node.
		/// Most rules will output the text of the node, but some rules
		/// can get more specific information.
		/// </summary>
		[TestMethod]
		public override void GetFormattedOutputTest()
		{
			var rule = CreateTestRule();
			var result = rule.Parse("\t ");
			var output = result.FormattedOutput();
			Assert.AreEqual("[\t ]", output);

			// if the whitespace rule has no template, it does not provide formatted output by default
			rule.Template = null;
			Assert.AreEqual("", result.FormattedOutput());
		}

		/// <summary>
		/// By default all rules should list their type and name if any. If
		/// the rule includes a simple pattern, that will be included.
		/// </summary>
		[TestMethod]
		public override void ToStringTest()
		{
			var rule = CreateTestRule();
			Assert.AreEqual("TestRule:ApiSoftware.Library35.Parsing.WhitespaceRule", rule.ToString());
		}

		/// <summary>
		/// This test checks that a newly constructed rule that contains
		/// reference rules (if appropriate) initialises properly given
		/// a rule list of named rules. References to other named rules
		/// by name must all be converted to direct object reference.
		/// </summary>
		[TestMethod]
		public override void InitializeTest()
		{
			// Create an if rule with its Rule as a reference to itself
			var rule = CreateTestRule();

			// Create the rule list and add the rule 
			var rules = new Parser();
			rules.Add(rule);

			// Initialise all the rules in the rule list.
			rules.Initialize();

			// No errors mean pass as integer rule is not changed on initialise.
		}

		/// <summary>
		/// A simple instance of the rule, on parsing a simple value,
		/// should return the result of the parsed value (unless the
		/// rule type specifically does otherwise).
		/// </summary>
		[TestMethod]
		public override void GetValueTest()
		{
			var rule = CreateTestRule();
			OutputNode result;

			result = rule.Parse("\t\r\n ");
			Assert.AreEqual("\t\r\n ", rule.GetValue(result));

			result = rule.Parse("1");
			Assert.AreEqual("", rule.GetValue(result));
		}

		/// <summary>
		/// A simple instance of the rule, on failing to parse a simple value
		/// should return the standard error text and any additional rule-
		/// specific text required for the type of rule.
		/// If an error template is provided, that will be used as the error
		/// text, optionally with result values substituted in.
		/// </summary>
		[TestMethod]
		public override void GetErrorTextTest()
		{
			var rule = CreateTestRule();
			var result = rule.Parse("B");
			var error = rule.GetErrorText(result);
			Assert.AreEqual("Error at 'B' (line 0, position 0): expected whitespace", error);
		}


		private WhitespaceRule CreateTestRule()
		{
			var rule = new WhitespaceRule();
			rule.Name = "TestRule";
			rule.Template = "[{0}]";
			return rule;
		}
	}
}
