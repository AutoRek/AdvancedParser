using ApiSoftware.Library35.Parsing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data;

namespace ParserLibraryTests
{


	/// <summary>
	///This is a test class for DateTimeNodeTest and is intended
	///to contain all DateTimeNodeTest Unit Tests
	///</summary>
	[TestClass()]
	public class DateTimeNodeTest : NodeBaseTestClass
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
		/// Each node should initialise correctly with the correct match
		/// status, an object reference to the rule and the correct begin
		/// and end.
		/// </summary>
		[TestMethod()]
		public override void ConstructorTest()
		{
			var text = "Test text";
			var rule = new DateTimeRule();
			var index = 1000;
			var node = new DateTimeNode(rule, text, index, 100);
			Assert.AreSame(rule, node.Rule);
			Assert.AreEqual(index, node.Begin);
			Assert.AreEqual(index + 100, node.End);
			Assert.IsTrue(node.IsMatch);
		}

		/// <summary>
		/// Each node should return the value associated with the node
		/// in the appropriate way for the type of node.
		/// </summary>
		[TestMethod()]
		public override void ValueTest()
		{
			var node = CreateTestNode();
			Assert.AreEqual(new DateTime(2010, 10, 20), node.Value);
		}

		/// <summary>
		/// Each node should return the node text as a string based on the
		/// begin and end position if appropriate for the type of node.
		/// </summary>
		[TestMethod()]
		public override void NodeTextTest()
		{
			var node = CreateTestNode();
			Assert.AreEqual("20/10/2010", node.NodeText);
		}

		/// <summary>
		/// Each node should return the formatted output of the node based
		/// on using the node's rule to get the formatted output.
		/// </summary>
		[TestMethod()]
		public override void FormattedOutputTest()
		{
			var node = CreateTestNode();
			Assert.AreEqual("[20101020]<2010-10-20>", node.FormattedOutput());
		}

		/// <summary>
		/// Each node type should get the error text appropriate to the
		/// node type and rule. Block nodes in particular should get the
		/// error text of any error nodes they contain.
		/// </summary>
		[TestMethod()]
		public override void GetErrorTextTest()
		{
			var node = CreateTestNode();
			node.IsMatch = false;
			Assert.AreEqual("(0|0|20|)", node.GetErrorText());
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

			// check the table and column are created and the row has the correct value and type.
			Assert.IsTrue(ds.Tables.Contains("TestTable"));
			Assert.IsTrue(ds.Tables[0].Columns.Contains("TestColumn"));
			Assert.AreEqual(1, ds.Tables[0].Rows.Count);
			Assert.AreEqual(new DateTime(2010, 10, 20), ds.Tables[0].Rows[0][0]);
		}


		private static ApiSoftware.Library35.Parsing.DateTimeNode CreateTestNode()
		{
			var text = "20/10/2010";

			var rule = new DateTimeRule();
			rule.Record = "TestTable";							// set a table for Fill test
			rule.Field = "TestColumn";							// set a column for Fill test
			rule.Template = "[{0:yyyyMMdd}]<{0:yyyy-MM-dd}>";	// set an interesting template for formatted output
			rule.ErrorTemplate = "({0}|{1}|{2}|{3})";			// set an error template with all properties

			// fake having parsed the rule to the node
			var node = new DateTimeNode(rule, text, 0, 10);
			return node;
		}
	}
}
