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
	public class ChoiceTest : RuleTestsBaseClass
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
		public override void ConstructorTest()
		{
			var rules = new Parser();
			var rule = new ChoiceRule();
			rules.Add(rule);
			Assert.IsNull(rule.ErrorTemplate);
			Assert.IsNull(rule.Template);
		}

		/// <summary>
		///A test for Parse
		///</summary>
		[TestMethod()]
		public override void ParseTest()
		{
			// Rule can parse an A or B.
			var rule = new ChoiceRule();
			rule.Add("A");
			rule.Add("B");

			OutputNode result;

			// Parse an 'A' at position 0 - OK and position moved to 1
			result = rule.Parse("A");
			Assert.IsInstanceOfType(result, typeof(TextNode));
			Assert.IsTrue(result.IsMatch);
			Assert.AreEqual("A", result.Value);
			Assert.AreEqual(0, result.Begin);
			Assert.AreEqual(1, result.End);

			// Parse a 'B' at position 0 - OK and position moved to 1
			result = rule.Parse("B");
			Assert.IsInstanceOfType(result, typeof(TextNode));
			Assert.IsTrue(result.IsMatch);
			Assert.AreEqual("B", result.Value);
			Assert.AreEqual(0, result.Begin);
			Assert.AreEqual(1, result.End);

			// Try to parse a 'C' at position 0 - no match and position not moved.
			result = rule.Parse("C");
			Assert.IsInstanceOfType(result, typeof(ErrorNode));
			Assert.IsFalse(result.IsMatch);
			Assert.AreEqual("", result.Value);
			Assert.AreEqual(0, result.Begin);
			Assert.AreEqual(0, result.End);

			// Try to parse a ' A' from position 0 - no match and position not moved.
			result = rule.Parse(" A");
			Assert.IsInstanceOfType(result, typeof(ErrorNode));
			Assert.IsFalse(result.IsMatch);
			Assert.AreEqual("", result.Value);
			Assert.AreEqual(0, result.Begin);
			Assert.AreEqual(0, result.End);

			// For a partial match in a series of rules, return the result of the longest match.
			// Rule will match AB or ACD. We will give it ACX, longest match is on the ACD choice.
			rule = new ChoiceRule();
			rule.Add("A", "B");
			rule.Add("A", "C", "D");
			rule.Add("A", "D");
			result = rule.Parse("ACX");
			Assert.IsInstanceOfType(result, typeof(BlockNode));
			Assert.IsFalse(result.IsMatch);
			Assert.AreEqual(3, result.Children.Count);

			var errorNode = result.Children[2];
			Assert.IsInstanceOfType(errorNode, typeof(ErrorNode));
			Assert.AreEqual("", errorNode.Value);
			Assert.AreEqual(2, errorNode.Begin);
			Assert.AreEqual(2, errorNode.End);
		}

		[TestMethod]
		public override void ParsePositionTest()
		{
			// Rule can parse an A or B.
			var rule = new ChoiceRule();
			rule.Add("A");
			rule.Add("B");

			OutputNode result;

			// Parse an 'A' at position 1 - OK and position moved to 2
			result = rule.Parse(" A", 1);
			Assert.IsInstanceOfType(result, typeof(TextNode));
			Assert.IsTrue(result.IsMatch);
			Assert.AreEqual("A", result.Value);
			Assert.AreEqual(1, result.Begin);
			Assert.AreEqual(2, result.End);

			// Parse a 'B' at position 1 - OK and position moved to 2
			result = rule.Parse(" B", 1);
			Assert.IsInstanceOfType(result, typeof(TextNode));
			Assert.IsTrue(result.IsMatch);
			Assert.AreEqual("B", result.Value);
			Assert.AreEqual(1, result.Begin);
			Assert.AreEqual(2, result.End);

			// Try to parse a 'C' at position 1 - no match and position not moved.
			result = rule.Parse(" C", 1);
			Assert.IsInstanceOfType(result, typeof(ErrorNode));
			Assert.IsFalse(result.IsMatch);
			Assert.AreEqual("", result.Value);
			Assert.AreEqual(1, result.Begin);
			Assert.AreEqual(1, result.End);

			// Try to parse a 'A' at position 0 - no match and position not moved.
			result = rule.Parse(" A", 0);
			Assert.IsInstanceOfType(result, typeof(ErrorNode));
			Assert.IsFalse(result.IsMatch);
			Assert.AreEqual("", result.Value);
			Assert.AreEqual(0, result.Begin);
			Assert.AreEqual(0, result.End);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public override void ParseErrorInput()
		{
			var rule = CreateTestRule();
			rule.Parse("A", 2);
		}

		/// <summary>
		/// Test that a choice template passes through to the chosen node
		/// </summary>
		[TestMethod]
		public override void GetFormattedOutputTest()
		{
			var rules = Parser.LoadXml("<Rules><Sequence Template=':{0}:'><Choice><Symbol Template='[{0}]'>A</Symbol><Symbol>B</Symbol></Choice></Sequence></Rules>");
			var result = rules.Parse("A");
			var output = result.FormattedOutput();
			Assert.AreEqual(":[A]:", output);
		}

		[TestMethod]
		public override void ToStringTest()
		{
			var rule1 = new ChoiceRule();
			rule1.Name = "TEST";
			Assert.AreEqual("TEST:ApiSoftware.Library35.Parsing.ChoiceRule", rule1.ToString());

			var rule2 = new ChoiceRule();
			Assert.AreEqual("ApiSoftware.Library35.Parsing.ChoiceRule", rule2.ToString());
		}

		[TestMethod]
		public override void InitializeTest()
		{
			// Create an if rule with its Rule as a reference to itself
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


		[TestMethod]
		public override void GetValueTest()
		{
			var rule = CreateTestRule();
			var result = rule.Parse("A");
			var value = result.Value;
			Assert.AreEqual("A", value);
		}

		[TestMethod]
		public override void GetErrorTextTest()
		{
			// for a simple 'not found' return the standard error.
			var rule = CreateTestRule();
			var result = rule.Parse("C");
			var text = result.GetErrorText();
			Assert.AreEqual("Error at 'C' (line 0, position 0)", text);

		}

		private ChoiceRule CreateTestRule()
		{
			var rule = new ChoiceRule();
			rule.Name = "TestRule";
			rule.Add("A");
			rule.Add("B");
			return rule;
		}

	}
}
