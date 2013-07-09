using ApiSoftware.Library35.Parsing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data;
using System.Collections.Generic;
using System.IO;

namespace ParserLibraryTests
{


	/// <summary>
	///This is a test class for OutputNodeTest and is intended
	///to contain all OutputNodeTest Unit Tests
	///</summary>
	[TestClass()]
	public class PagedCSVExample
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
		///A test for Fill
		///</summary>
		[TestMethod()]
		[DeploymentItem("TestFiles", "TestFiles")]
		[DeploymentItem("Parsers", "TestFiles")]
		public void FillTest1()
		{
			var xml = File.ReadAllText("TestFiles\\PagedCSVParser.xml");
			var data = File.ReadAllText("TestFiles\\SimplePagedCSV.txt");

			var rules = Rules.LoadXml(xml);
			var result = rules.Parse(data);

			using (var ds = new DataSet())
			{
				result.Fill(ds);
				Assert.IsTrue(ds.Tables.Contains("H"));
				Assert.IsTrue(ds.Tables.Contains("R"));
				Assert.AreEqual(3, ds.Tables["H"].Rows.Count);
				Assert.AreEqual(15, ds.Tables["R"].Rows.Count);
				Assert.AreEqual(4, ds.Tables["H"].Columns.Count);
				Assert.AreEqual(4, ds.Tables["R"].Columns.Count);
			}
		}

		/// <summary>
		///A test for Fill
		///</summary>
		[TestMethod()]
		[DeploymentItem("TestFiles", "TestFiles")]
		[DeploymentItem("Parsers", "TestFiles")]
		public void FillTest2()
		{
			var xml = File.ReadAllText("TestFiles\\PagedCSVParser.xml");
			var data = File.ReadAllText("TestFiles\\SimplePagedCSV.txt");

			var rules = Rules.LoadXml(xml);
			var result = rules.Parse(data);

			using (var ds = new DataSet())
			{
				result.Fill(ds, IdMode.RowAndParents, IdStyle.Guid);
				Assert.IsTrue(ds.Tables.Contains("H"));
				Assert.IsTrue(ds.Tables.Contains("R"));
				Assert.AreEqual(3, ds.Tables["H"].Rows.Count);
				Assert.AreEqual(15, ds.Tables["R"].Rows.Count);
				Assert.AreEqual(6, ds.Tables["H"].Columns.Count);
				Assert.AreEqual(6, ds.Tables["R"].Columns.Count);
			}
		}

		/// <summary>
		///A test for GetFormattedOutput
		///</summary>
		[TestMethod()]
		[DeploymentItem("TestFiles", "TestFiles")]
		[DeploymentItem("Parsers", "TestFiles")]
		public void GetFormattedOutputTest_Full()
		{
			var xml = File.ReadAllText("TestFiles\\PagedCSVParser.xml");
			var data = File.ReadAllText("TestFiles\\SimplePagedCSV.txt");
			var expected = File.ReadAllText("TestFiles\\SimplePagedCSV-output.txt");

			var rules = Rules.LoadXml(xml);
			var result = rules.Parse(data);

			var output = result.FormattedOutput();
			Assert.AreEqual(expected, output);
		}

	}
}
