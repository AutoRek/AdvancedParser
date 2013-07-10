using ApiSoftware.Library35.Parsing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data;
using System.Collections.Generic;
using System.IO;

namespace ParserLibraryTests
{

	/// <summary>
	/// The boolean expression example is a simple boolean expression parser that parses 
	/// expression built out of the operators:
	///	<![CDATA[  AND OR = != > >= < <= + - * /	]]>	
	///	strings, numbers and identifers.
	///	The templates have been set up to output the parsed content as an equivalent
	///	series of nested function calls.
	/// </summary>
	[TestClass()]
	public class BooleanExpressionExample
	{

		private TestContext testContextInstance;

		/// <summary>
		/// Gets or sets the test context which provides
		/// information about and functionality for the current test run.
		/// </summary>
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
			// Simple test that a simple equality gives the expected output
			var text = "1=1";
			var expected = "EQ(1,1)";

			var xml = File.ReadAllText("TestFiles\\ExpressionParser.xml");
			var rules = Rules.LoadXml(xml);
			var result = rules.Parse(text);
			Assert.IsTrue(result.IsMatch);
			Assert.AreEqual(expected, result.FormattedOutput());
		}

		/// <summary>
		/// Parsing Example 2
		/// </summary>
		[TestMethod()]
		[DeploymentItem("TestFiles", "TestFiles")]
		[DeploymentItem("TestParsers", "TestFiles")]
		public void ParsingExample2()
		{
			// Operator precedence automatically handled
			var text = "1+2*3";
			var expected = "ADD(1,MUL(2,3))";

			var xml = File.ReadAllText("TestFiles\\ExpressionParser.xml");
			var rules = Rules.LoadXml(xml);
			var result = rules.Parse(text);
			Assert.IsTrue(result.IsMatch);
			Assert.AreEqual(expected, result.FormattedOutput());
		}

		/// <summary>
		/// Parsing Example 3
		/// </summary>
		[TestMethod()]
		[DeploymentItem("TestFiles", "TestFiles")]
		[DeploymentItem("TestParsers", "TestFiles")]
		public void ParsingExample3()
		{
			// Complex test involving many operands and brackets and so on
			var text = "1=1 AND \"X\"=A OR (1+2*3 > 3*2)";
			var expected = "OR(AND(EQ(1,1),EQ('X',A)),GT(ADD(1,MUL(2,3)),MUL(3,2)))";

			var xml = File.ReadAllText("TestFiles\\ExpressionParser.xml");
			var rules = Rules.LoadXml(xml);
			var result = rules.Parse(text);
			Assert.IsTrue(result.IsMatch);
			Assert.AreEqual(expected, result.FormattedOutput());
		}

		/// <summary>
		/// Parsing Example 4
		/// </summary>
		[TestMethod()]
		[DeploymentItem("TestFiles", "TestFiles")]
		[DeploymentItem("TestParsers", "TestFiles")]
		public void ParsingExample4()
		{
			// Try a failing match
			var text = "1+*2*3";

			var xml = File.ReadAllText("TestFiles\\ExpressionParser.xml");
			var rules = Rules.LoadXml(xml);
			var result = rules.Parse(text);
			Assert.IsFalse(result.IsMatch);
		}
	}
}
