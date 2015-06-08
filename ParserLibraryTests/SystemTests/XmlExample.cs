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
	public class XmlExample
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
		/// Parsing Example
		/// </summary>
		[TestMethod()]
		[DeploymentItem("Parser\\TestFiles", "TestFiles")]
		[DeploymentItem("Parser\\TestParsers", "TestFiles")]
		public void ParsingTest()
		{
			var xml = File.ReadAllText("TestFiles\\XmlParser.xml");
			var data = File.ReadAllText("TestFiles\\XmlParser.xml");

			var rules = Parser.LoadXml(xml);
			var result = rules.Parse(data);

			Assert.IsTrue(result.IsMatch);
		}

		[TestMethod]
		[DeploymentItem("Parser\\TestFiles", "TestFiles")]
		[DeploymentItem("Parser\\TestParsers", "TestFiles")]
		public void FillTest()
		{
			// Xml is not set up with any record/fields so dataset is completely empty
			var xml = File.ReadAllText("TestFiles\\XmlParser.xml");
			var data = File.ReadAllText("TestFiles\\XmlParser.xml");

			var rules = Parser.LoadXml(xml);
			var result = rules.Parse(data);

			using (var ds = new DataSet())
			{
				result.Fill(ds);
				Assert.AreEqual(0, ds.Tables.Count);
			}
		}

		[TestMethod]
		[DeploymentItem("Parser\\TestFiles", "TestFiles")]
		[DeploymentItem("Parser\\TestParsers", "TestFiles")]
		public void GetFormattedOutput()
		{
			// Just default content, so only the text values get output
			var xml = File.ReadAllText("TestFiles\\XmlParser.xml");
			var data = File.ReadAllText("TestFiles\\XmlParser.xml");

			var rules = Parser.LoadXml(xml);
			var result = rules.Parse(data);
			var output = result.FormattedOutput();

			Assert.AreEqual(@"element\s+\wtruetrueComment must end with -->contentattributetruetrue", output);
		}

		[TestMethod]
		[DeploymentItem("Parser\\TestFiles", "TestFiles")]
		[DeploymentItem("Parser\\TestParsers", "TestFiles")]
		public void GetErrorOutput()
		{
			// Check the error of the error sample
			var xml = File.ReadAllText("TestFiles\\XmlParser.xml");
			var data = File.ReadAllText("TestFiles\\XmlSample.xml.err");

			var rules = Parser.LoadXml(xml);
			var result = rules.Parse(data);

			Assert.IsFalse(result.IsMatch);
			
			var output = result.GetErrorText();
			Assert.AreEqual(@"Comment must end with -->", output);
		}
	}
}
