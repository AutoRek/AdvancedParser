using ApiSoftware.Library35.Parsing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ParserLibraryTests
{


	/// <summary>
	///This is a test class for SequenceTest and is intended
	///to contain all SequenceTest Unit Tests
	///</summary>
	[TestClass()]
	public class SequenceTest : RuleTestsBaseClass
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
		///A test for Sequence Constructor
		///</summary>
		[TestMethod()]
		public override void ConstructorTest()
		{
			var rules = new Parser();
			var rule = new SequenceRule();
			rule.Initialize(rules);

			Assert.IsNotNull(rule.Rules);
			Assert.IsNull(rule.ErrorTemplate);
			Assert.IsNull(rule.Template);
		}

		/// <summary>
		///A test for Parse
		///</summary>
		[TestMethod()]
		public override void ParseTest()
		{
			var rules = Parser.LoadXml(@"<Rules><Sequence><Symbol>A</Symbol><Symbol>B</Symbol></Sequence></Rules>");

			OutputNode result;
			result = rules.Parse("AB");
			Assert.IsTrue(result.IsMatch);
			Assert.AreEqual(2, result.Children.Count);
			Assert.AreEqual("A", result.Children[0].Value);
			Assert.AreEqual("B", result.Children[1].Value);

			result = rules.Parse("A");
			Assert.IsFalse(result.IsMatch);
			Assert.AreEqual(2, result.Children.Count);
			Assert.AreEqual("A", result.Children[0].Value);
			Assert.IsInstanceOfType(result.Children[1], typeof(ErrorNode));
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
			var rules = Parser.LoadXml(@"<Rules><Sequence><Symbol>A</Symbol><Symbol>B</Symbol></Sequence></Rules>");

			OutputNode result;
			result = rules.Parse("CAB", 1);
			Assert.IsTrue(result.IsMatch);
			Assert.AreEqual(2, result.Children.Count);
			Assert.AreEqual("A", result.Children[0].Value);
			Assert.AreEqual("B", result.Children[1].Value);

			result = rules.Parse("CA", 1);
			Assert.IsFalse(result.IsMatch);
			Assert.AreEqual(2, result.Children.Count);
			Assert.AreEqual("A", result.Children[0].Value);
			Assert.IsInstanceOfType(result.Children[1], typeof(ErrorNode));
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
			var text = "'A'";
			var result = rule.Parse(text, 5);
		}

		/// <summary>
		/// This test checks that a newly constructed rule that contains
		/// reference rules (if appropriate) initialises properly given
		/// a rule list of named rules. References to other named rules
		/// by name must all be converted to direct object reference.
		/// </summary>
		[TestMethod()]
		public override void InitializeTest()
		{
			var rule = CreateTestRule();
			rule.Rules[0] = new ReferenceRule("TestRule");

			// Create the rule list and add the rule 
			var rules = new Parser();
			rules.Add(rule);

			// Initialise all the rules in the rule list.
			rules.Initialize();

			// The reference rule should have been be replaced by an object reference to the if rule
			Assert.AreSame(rule.Rules[0], rule);
		}

		/// <summary>
		/// By default all rules should list their type and name if any. If
		/// the rule includes a simple pattern, that will be included.
		/// </summary>
		[TestMethod()]
		public override void ToStringTest()
		{
			var rule = CreateTestRule();
			Assert.AreEqual("TestRule:ApiSoftware.Library35.Parsing.SequenceRule", rule.ToString());
		}

		/// <summary>
		/// This test checks that when a simple rule has parsed some text
		/// it generates the correct output based on the result node.
		/// Most rules will output the text of the node, but some rules
		/// can get more specific information.
		/// </summary>
		[TestMethod()]
		public override void GetFormattedOutputTest()
		{
			var rule = CreateTestRule();
			var result = rule.Parse("AB");
			var output = result.FormattedOutput();
			Assert.AreEqual("[A|B]", output);
		}

		/// <summary>
		/// A simple instance of the rule, on parsing a simple value,
		/// should return the result of the parsed value (unless the
		/// rule type specifically does otherwise).
		/// </summary>
		[TestMethod()]
		public override void GetValueTest()
		{
			var rule = CreateTestRule();
			OutputNode result;

			result = rule.Parse("A");
			Assert.AreEqual("A", rule.GetValue(result));

			result = rule.Parse("B");
			Assert.AreEqual("", rule.GetValue(result));
		}

		/// <summary>
		/// A simple instance of the rule, on failing to parse a simple value
		/// should return the standard error text and any additional rule-
		/// specific text required for the type of rule.
		/// If an error template is provided, that will be used as the error
		/// text, optionally with result values substituted in.
		/// </summary>
		[TestMethod()]
		public override void GetErrorTextTest()
		{
			var rule = CreateTestRule();
			var result = rule.Parse("AC");
			var error = rule.GetErrorText(result);
			Assert.AreEqual("Error at 'AC' (line 0, position 0)", error);
		}


		private SequenceRule CreateTestRule()
		{
			var rule = new SequenceRule();
			rule.Add("A", "B");
			rule.Name = "TestRule";
			rule.Template = "[{0}|{1}]";
			rule.Rules[0].Template = "{0}";
			rule.Rules[1].Template = "{0}";
			return rule;
		}
	}
}
