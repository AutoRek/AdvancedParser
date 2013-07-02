using ApiSoftware.Library35.Parsing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ParserLibraryTests
{


	/// <summary>
	///This is a test class for TextPointTest and is intended
	///to contain all TextPointTest Unit Tests
	///</summary>
	[TestClass()]
	public class TextPointTest
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
		///A test for TextPoint Constructor
		///</summary>
		[TestMethod()]
		public void TextPointConstructorTest()
		{
			var text = "Line 0 - Sample Text\r\nLine 1\r\nLine 2";
			var position = 25;

			var tp0 = new TextPoint(text, 0);
			Assert.AreEqual(0, tp0.Index);
			Assert.AreEqual(0, tp0.Line);
			Assert.AreEqual(0, tp0.Character);

			var tp1 = new TextPoint(text, position);
			Assert.AreEqual(25, tp1.Index);
			Assert.AreEqual(1, tp1.Line);		// 25 chars in is line 1
			Assert.AreEqual(3, tp1.Character);	// and 3rd char
			Assert.AreSame(text, tp1.Text);

			var tp2 = new TextPoint(text, 200);
			Assert.AreEqual(text.Length, tp2.Index);
			Assert.AreEqual(2, tp2.Line);		// position is end of string
			Assert.AreEqual(6, tp2.Character);	// after last character at end of the line

			var tp3 = new TextPoint(text, 9); // start of the word 'Sample'
			Assert.AreEqual("Sample", tp3.Symbol);

			var tp4 = new TextPoint(text, 1);	// Bug with position if not at start and on first line
			Assert.AreEqual(1, tp4.Index);
			Assert.AreEqual(0, tp4.Line);
			Assert.AreEqual(1, tp4.Character);

		}

	}
}
