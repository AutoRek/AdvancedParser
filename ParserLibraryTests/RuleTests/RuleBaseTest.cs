using ApiSoftware.Library35.Parsing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data;

namespace ParserLibraryTests
{

	/// <summary>
	///This is a test class for RuleBaseTest and is intended
	///to contain all RuleBaseTest Unit Tests
	///</summary>
	[TestClass()]
	public class RuleBaseTest
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
		/// Record property is used to assign the new record to the table in Fill
		/// </summary>
		[TestMethod()]
		public void RecordTest()
		{
			var rules = Parser.LoadXml(@"<Rules><OneOrMore><Sequence Record='T'><Symbol Field='C'>\s*\d+</Symbol></Sequence></OneOrMore></Rules>");
			var result = rules.Parse("123 456 789");
			using (var ds = new DataSet())
			{
				result.Fill(ds);
				Assert.IsNotNull(ds.Tables[0]);
				Assert.AreEqual("T", ds.Tables[0].TableName);
				// check the data also
				Assert.AreEqual(3, ds.Tables["T"].Rows.Count);
				Assert.AreEqual("123", ds.Tables["T"].Rows[0][0]);
				Assert.AreEqual(" 456", ds.Tables["T"].Rows[1][0]);
				Assert.AreEqual(" 789", ds.Tables["T"].Rows[2][0]);
			}
		}

		/// <summary>
		/// Field property is used to generate table columns in Fill
		/// </summary>
		[TestMethod()]
		public void FieldTest()
		{
			var rules = Parser.LoadXml(@"<Rules><OneOrMore><Sequence Record='T'><Symbol Field='C'>\s*\d+</Symbol></Sequence></OneOrMore></Rules>");
			var result = rules.Parse("123 456 789");
			using (var ds = new DataSet())
			{
				result.Fill(ds);
				Assert.IsNotNull(ds.Tables[0]);
				Assert.AreEqual("C", ds.Tables[0].Columns[0].ColumnName);
				// check the data also
				Assert.AreEqual(3, ds.Tables[0].Rows.Count);
				Assert.AreEqual("123", ds.Tables[0].Rows[0][0]);
				Assert.AreEqual(" 456", ds.Tables[0].Rows[1][0]);
				Assert.AreEqual(" 789", ds.Tables[0].Rows[2][0]);
			}
		}

	}
}
