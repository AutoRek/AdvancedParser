using ApiSoftware.Library35.Parsing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace ParserLibraryTests
{


	/// <summary>
	///This is a test class for RuleListBaseTest and is intended
	///to contain all RuleListBaseTest Unit Tests
	///</summary>
	[TestClass()]
	public class RuleListBaseTest
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


		internal virtual RuleListBase CreateRuleListBase()
		{
			// TODO: Instantiate an appropriate concrete class.
			RuleListBase target = new Sequence();
			return target;
		}

		/// <summary>
		/// A test for Add Rule
		/// </summary>
		[TestMethod()]
		public void AddTest1()
		{
			var ruleList = CreateRuleListBase();
			var rule = new Symbol("TEST");
			var actual = ruleList.Add(rule);
			Assert.AreEqual(1, ruleList.Rules.Count);
			Assert.AreSame(rule, ruleList.Rules[0]);
			Assert.AreSame(actual, ruleList);
		}

		/// <summary>
		/// A test for Add "TEXT"
		/// </summary>
		[TestMethod()]
		public void AddTest2()
		{
			var ruleList = CreateRuleListBase();
			var actual = ruleList.Add("TEST");
			Assert.AreEqual(1, ruleList.Rules.Count);
			Assert.IsInstanceOfType(ruleList.Rules[0], typeof(Symbol));
			Assert.AreEqual("TEST", (ruleList.Rules[0] as Symbol).Pattern);
			Assert.AreSame(actual, ruleList);
		}

	}
}
