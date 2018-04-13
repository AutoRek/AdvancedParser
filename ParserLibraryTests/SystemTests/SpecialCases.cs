using ApiSoftware.Library35;
using ApiSoftware.Library35.Parsing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ParserLibraryTests
{

	/// <summary>
	/// Tests special cases such as resetting the 'extra values' and duplicate attributes in data.
	/// </summary>
	[TestClass()]
	public class SpecialCases
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
		[DeploymentItem("Parser\\TestFiles", "TestFiles")]
		[DeploymentItem("Parser\\TestParsers", "TestFiles")]
		public void ClearFieldsTest()
		{
			var xml = File.ReadAllText("TestFiles\\PagedCSVwithClearFields.xml");
			var data = File.ReadAllText("TestFiles\\SimplePagedCSVusingClearFields.txt");

			var rules = Parser.LoadXml(xml);
			var result = rules.Parse(data);

			// Include in the test that selected cells are empty, as per the ClearFields options.
			using (var ds = new DataSet())
			{
				result.Fill(ds);

				Assert.AreEqual(1, ds.Tables.Count);
				Assert.IsTrue(ds.Tables.Contains("R"));
				var actual = ToString(ds.Tables[0], "\t");
				var expected = @"h1	h2	h3	h4	s1	s2	s3	r1	r2	r3	r4
Header1a	Header2a	Header3a	0	10	Val10	100	11	Val11	101	AA
Header1a	Header2a	Header3a	0	10	Val10	100	12	Val12	102	BB
Header1b	Header2b	Header3b		20	Val20	200	21	Val21	201	AAA
Header1b	Header2b	Header3b		20	Val20	200	22	Val22	202	BBB
Header1c	Header2c	Header3c		30	Val30		31	Val31	301	AAAA
Header1c	Header2c	Header3c		30	Val30		32	Val32	302	BBBB
";
				Assert.AreEqual(expected, actual);
			}
		}

		[TestMethod]
		public void DuplicateAttributes()
		{
			// The F attribute will be read twice for the single record.
			// To be valid XML we have to ensure that each attribute is used once.
			var rules = new Parser();
			var rule = new OneOrMoreRule() { Record = "R" };
			rule.Rule = new SymbolRule("A") { Field = "F" };
			rules.Add(rule);
			var output = rule.Parse("AA");
			Assert.AreEqual(true, output.IsMatch);
			// Using XElement, formatted output with no duplicate attribute.
			// The XmlTextWriter version doesn't support handling duplicate attributes unfortunately.
			Assert.AreEqual("<Xml>\r\n  <R F=\"A\" />\r\n</Xml>", output.ToXml(true));
		}

		private static string ToString(DataTable table, string delimiter)
		{
			var count = table.Columns.Count;
			var sb = new StringBuilder();
			for (int i = 0; i < count; i++)
			{
				if (i > 0) sb.Append(delimiter);
				sb.Append(table.Columns[i].ColumnName);
			}
			sb.AppendLine();
			foreach (DataRow row in table.Rows)
			{
				for (int i = 0; i < count; i++)
				{
					if (i > 0) sb.Append(delimiter);
					sb.Append(row[i]);
				}
				sb.AppendLine();
			}
			var text = sb.ToString();
			return text;
		}

	}
}
