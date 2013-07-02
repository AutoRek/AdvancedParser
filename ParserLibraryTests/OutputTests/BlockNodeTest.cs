using ApiSoftware.Library35.Parsing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ParserLibraryTests
{


	/// <summary>
	///This is a test class for BlockNodeTest and is intended
	///to contain all BlockNodeTest Unit Tests
	///</summary>
	[TestClass()]
	public class BlockNodeTest
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
		///A test for BlockNode Constructor
		///</summary>
		[TestMethod()]
		public void BlockNodeConstructorTest()
		{
			var rule = new Symbol("TEST");
			var index = 1000;
			var node = new BlockNode(rule, index);
			Assert.AreSame(rule, node.Rule);
			Assert.AreEqual(index, node.Begin);
			Assert.IsTrue(node.IsMatch);
		}

		/// <summary>
		///A test for BlockNode Constructor
		///</summary>
		[TestMethod()]
		public void BlockNodeConstructorTest1()
		{
			//BlockNode target = new BlockNode();
			//Assert.Inconclusive("TODO: Implement code to verify target");
		}

		/// <summary>
		/// BlockNode does not return values in GetValue
		/// </summary>
		[TestMethod()]
		public void GetValueTest()
		{
			var rules = Rules.LoadXml(@"<Rules><Symbol>1</Symbol></Rules>");
			var result = rules.Parse("1");
			var node = new BlockNode(rules.Rules[0], 0);
			Assert.AreEqual(string.Empty, node.Value());
		}
	}
}
