using ApiSoftware.Library35.Parsing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data;

namespace ParserLibraryTests
{


	/// <summary>
	///This is a test class for BlockNodeTest and is intended
	///to contain all BlockNodeTest Unit Tests
	///</summary>
	[TestClass()]
	public class BlockNodeTest : NodeBaseTestClass
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



		[TestMethod()]
		public override void ConstructorTest()
		{
			var text = "Test text";
			var rule = new SymbolRule("TEST");
			var index = 1000;
			var node = new BlockNode(rule, text, index);
			Assert.AreSame(rule, node.Rule);
			Assert.AreEqual(index, node.Begin);
			Assert.IsTrue(node.IsMatch);
		}

		[TestMethod()]
		public override void ValueTest()
		{
			//// Use a sequence with a correct symbol. 
			//// This will parse and return a block node as the root node.
			//var rules = Rules.LoadXml(@"<Rules><Sequence><Symbol>1</Symbol><Symbol>2</Symbol></Sequence></Rules>");
			//var result = rules.Parse("12");
			//Assert.AreEqual("12", result.Value);


			var node = CreateTestNode();
			Assert.AreEqual("AB", node.Value);
		}

		[TestMethod()]
		public override void NodeTextTest()
		{
			var node = CreateTestNode();
			Assert.AreEqual("AB", node.NodeText);
		}

		[TestMethod()]
		public override void FormattedOutputTest()
		{
			var node = CreateTestNode();
			Assert.AreEqual("[-A-]<:B:>", node.FormattedOutput());
		}

		[TestMethod()]
		public override void GetErrorTextTest()
		{
			var node = CreateTestNode();
			node.IsMatch = false;
			Assert.AreEqual("Error at 'AB' (line 0, position 0)", node.GetErrorText());
		}

		/// <summary>
		/// If the rule has table and column data setup, then each node
		/// should add it's value to the table and column as per the rule's
		/// settings.
		/// </summary>
		[TestMethod()]
		public override void FillTest()
		{
			var node = CreateTestNode();

			// fill the data set
			var ds = new DataSet();
			node.Fill(ds);

			// check the table and column are created and the row has the correct value
			Assert.IsTrue(ds.Tables.Contains("TestTable"));
			Assert.IsTrue(ds.Tables[0].Columns.Contains("Column1"));
			Assert.IsTrue(ds.Tables[0].Columns.Contains("Column2"));
			Assert.AreEqual(1, ds.Tables[0].Rows.Count);
			Assert.AreEqual("A", ds.Tables[0].Rows[0][0]);
			Assert.AreEqual("B", ds.Tables[0].Rows[0][1]);
		}


		private static BlockNode CreateTestNode()
		{
			var text = "AB";

			// Typical scenario for block node is a parent that sets the table and 
			// a child that sets the column. So set up a sequence with symbol and
			// set the table/column of each.

			var rule = new SequenceRule();
			rule.Add("A", "B"); // shortcut to add the symbol patterns
			rule.Table = "TestTable";
			rule.Rules[0].Column = "Column1";
			rule.Rules[0].Template = "-{0}-";	// individual template for 1st symbol
			rule.Rules[1].Column = "Column2";
			rule.Rules[1].Template = ":{0}:";	// individual template for 2nd symbol
			rule.Template = "[{0}]<{1}>";		// Sequence template for both symbols

			// fake having parsed the rule to the node
			var node = new BlockNode(rule, text, 0);
			node.End = 2;
			node.Children.Add(new TextNode(rule.Rules[0], text, 0, 1));
			node.Children.Add(new TextNode(rule.Rules[1], text, 1, 1));
			return node;
		}
	}
}
