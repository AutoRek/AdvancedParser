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
	public class SWIFTExample
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
		/// Parsing Example 1
		/// </summary>
		[TestMethod()]
		[DeploymentItem("TestFiles", "TestFiles")]
		[DeploymentItem("TestParsers", "TestFiles")]
		public void ParsingExample1()
		{
			var xml = File.ReadAllText("TestFiles\\SWIFTOuterParser.xml");
			var data = File.ReadAllText("TestFiles\\mt940_example_1.txt");

			var rules = Rules.LoadXml(xml);
			var result = rules.Parse(data);

			Assert.IsTrue(result.IsMatch);
		}

		/// <summary>
		/// Parsing Example 2
		/// </summary>
		[TestMethod()]
		[DeploymentItem("TestFiles", "TestFiles")]
		[DeploymentItem("TestParsers", "TestFiles")]
		public void ParsingExample2()
		{
			var xml = File.ReadAllText("TestFiles\\MT535Parser.xml");
			var data = File.ReadAllText("TestFiles\\mt535_example_1.txt");

			var rules = Rules.LoadXml(xml);
			var result = rules.Parse(data);

			Assert.IsTrue(result.IsMatch);
		}

		/// <summary>
		/// Parsing Example 3
		/// </summary>
		[TestMethod()]
		[DeploymentItem("TestFiles", "TestFiles")]
		[DeploymentItem("TestParsers", "TestFiles")]
		public void ParsingExample3()
		{
			var xml = File.ReadAllText("TestFiles\\MT535Parser.xml");
			var data = File.ReadAllText("TestFiles\\mt535_example_1.txt");

			var rules = Rules.LoadXml(xml);
			var result = rules.Parse(data);

			Assert.IsTrue(result.IsMatch);
		}

		/// <summary>
		/// Parsing Example 4
		/// </summary>
		[TestMethod()]
		[DeploymentItem("TestFiles", "TestFiles")]
		[DeploymentItem("TestParsers", "TestFiles")]
		public void ParsingExample4()
		{
			var xml = File.ReadAllText("TestFiles\\MT535Parser.xml");
			var data = File.ReadAllText("TestFiles\\mt535_example_1.txt");

			var rules = Rules.LoadXml(xml);
			var result = rules.Parse(data);

			Assert.IsTrue(result.IsMatch);
		}
	}
}
