using ApiSoftware.Library35.Parsing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data;

namespace ParserLibraryTests
{


	/// <summary>
	///This is a test class for TextNodeTest and is intended
	///to contain all TextNodeTest Unit Tests
	///</summary>
	[TestClass()]
	public class TextNodeTest : NodeBaseTestClass
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
			var node = new TextNode(rule, text, index, 100);
			Assert.AreSame(rule, node.Rule);
			Assert.AreEqual(index, node.Begin);
			Assert.AreEqual(index + 100, node.End);
			Assert.IsTrue(node.IsMatch);
		}

		[TestMethod()]
		public override void ValueTest()
		{
			var node = CreateTestNode();
			Assert.AreEqual("A", node.Value);
		}

		[TestMethod()]
		public override void NodeTextTest()
		{
			var node = CreateTestNode();
			Assert.AreEqual("A", node.NodeText);
		}

		[TestMethod()]
		public override void FormattedOutputTest()
		{
			var node = CreateTestNode();
			Assert.AreEqual("[A]<A>", node.FormattedOutput());
		}

		[TestMethod()]
		public override void GetErrorTextTest()
		{
			var node = CreateTestNode();
			node.IsMatch = false;
			Assert.AreEqual("(0|0|A|A)", node.GetErrorText());
		}

		[TestMethod()]
		public override void FillTest()
		{
			var node = CreateTestNode();

			// fill the data set
			var ds = new DataSet();
			node.Fill(ds);

			// check the table and column are created and the row has the correct value
			Assert.IsTrue(ds.Tables.Contains("TestTable"));
			Assert.IsTrue(ds.Tables[0].Columns.Contains("TestColumn"));
			Assert.AreEqual(1, ds.Tables[0].Rows.Count);
			Assert.AreEqual("A", ds.Tables[0].Rows[0][0]);
		}


		private static TextNode CreateTestNode()
		{
			var text = "A";

			var rule = new SymbolRule("A");
			rule.Table = "TestTable";					// set a table for Fill test
			rule.Column = "TestColumn";					// set a column for Fill test
			rule.Template = "[{0}]<{0}>";				// set interesting template for formatted output
			rule.ErrorTemplate = "({0}|{1}|{2}|{3})";	// set an error template with all properties

			// fake having parsed the rule to the node
			var node = new TextNode(rule, text, 0, 1);
			return node;
		}

	}
}
