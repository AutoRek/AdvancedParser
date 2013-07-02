using ApiSoftware.Library35.Parsing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ParserLibraryTests
{


	/// <summary>
	///This is a test class for SequenceTest and is intended
	///to contain all SequenceTest Unit Tests
	///</summary>
	[TestClass()]
	public class SequenceTest
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
		///A test for Sequence Constructor
		///</summary>
		[TestMethod()]
		public void SequenceConstructorTest()
		{
			var rules = new Rules();
			var sequence = new Sequence();
			sequence.Initialize(rules);

			Assert.IsNotNull(sequence.Rules);
			Assert.IsNotNull(sequence.Grammar);
		}

		/// <summary>
		///A test for Parse
		///</summary>
		[TestMethod()]
		public void ParseTest()
		{
			var rules = Rules.LoadXml(@"<Rules><Sequence><Symbol>A</Symbol><Symbol>B</Symbol></Sequence></Rules>");

			OutputNode result;
			result = rules.Parse("AB");
			Assert.IsTrue(result.IsMatch);
			Assert.AreEqual(2, result.Children.Count);
			Assert.AreEqual("A", result.Children[0].Value());
			Assert.AreEqual("B", result.Children[1].Value());

			result = rules.Parse("A");
			Assert.IsFalse(result.IsMatch);
			Assert.AreEqual(2, result.Children.Count);
			Assert.AreEqual("A", result.Children[0].Value());
			Assert.IsInstanceOfType(result.Children[1], typeof(ErrorNode));
		}
	}
}
