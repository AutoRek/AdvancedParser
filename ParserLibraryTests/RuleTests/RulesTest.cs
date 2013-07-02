using ApiSoftware.Library35;
using ApiSoftware.Library35.Parsing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace ParserLibraryTests
{


	/// <summary>
	///This is a test class for RulesTest and is intended
	///to contain all RulesTest Unit Tests
	///</summary>
	[TestClass()]
	public class RulesTest
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
		///A test for Rules Constructor
		///</summary>
		[TestMethod()]
		public void RulesConstructorTest()
		{
			Rules target = new Rules();
			Assert.IsNotNull(target.Rules);
		}

		/// <summary>
		/// Verify that load xml loads OK by checking 2 rules at root level.
		/// </summary>
		[TestMethod()]
		public void LoadXmlTest()
		{
			var rules = Rules.LoadXml(@"<Rules><Symbol>A</Symbol><Sequence><SString/></Sequence></Rules>");
			Assert.AreEqual(2, rules.Rules.Count);
		}

		/// <summary>
		/// Verify fetching of named rules
		/// </summary>
		[TestMethod()]
		public void RuleNameTest()
		{
			var rules = Rules.LoadXml(@"<Rules><Symbol Name='A'>A</Symbol><Sequence Name='B'><SString/></Sequence></Rules>");
			var r1 = rules.Rules[1];
			var r2 = rules["B"];
			Assert.AreSame(r1, r2);
		}

		/// <summary>
		/// Parsing Example
		/// </summary>
		[TestMethod()]
		[DeploymentItem("TestFiles", "TestFiles")]
		public void ParsingExample1()
		{
			var xml = File.ReadAllText("TestFiles\\XmlParser.xml");
			var data = File.ReadAllText("TestFiles\\XmlParser.xml");

			var rules = Rules.LoadXml(xml);
			var result = rules.Parse(data);
			var output = result.FormattedOutput();
			Assert.IsTrue(result.IsMatch);
		}

		/// <summary>
		/// Parsing Example
		/// </summary>
		[TestMethod()]
		public void ParsingExample2()
		{
			Assert.Inconclusive("TODO: Parsing Example 2");
		}

		/// <summary>
		/// Parsing Example
		/// </summary>
		[TestMethod()]
		public void ParsingExample3()
		{
			Assert.Inconclusive("TODO: Parsing Example 3");
		}

		/// <summary>
		/// Parsing Example
		/// </summary>
		[TestMethod()]
		public void ParsingExample4()
		{
			Assert.Inconclusive("TODO: Parsing Example 4");
		}

	}
}
