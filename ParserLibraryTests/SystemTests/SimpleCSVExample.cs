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
	public class SimpleCSVExample
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
		[DeploymentItem("Parser\\TestFiles", "TestFiles")]
		[DeploymentItem("Parser\\TestParsers", "TestFiles")]
		public void ParsingExample1()
		{
			var xml = File.ReadAllText("TestFiles\\CSVParser.xml");
			var data = File.ReadAllText("TestFiles\\SimpleCSV.txt");

			var rules = Parser.LoadXml(xml);
			var result = rules.Parse(data);

			using (var ds = new DataSet())
			{
				result.Fill(ds);
				Assert.IsTrue(ds.Tables.Contains("R"));
				Assert.AreEqual(15, ds.Tables["R"].Rows.Count);
				// Expect 4 'common' columns created before the 'record' + 4 columns belonging to the record.
				// This is a change over the functionality before common fields were allowed.
				Assert.AreEqual(8, ds.Tables["R"].Columns.Count); 
			}
		}

		/// <summary>
		/// Parsing Example 2 - An error in the file
		/// </summary>
		[TestMethod()]
		[DeploymentItem("Parser\\TestFiles", "TestFiles")]
		[DeploymentItem("Parser\\TestParsers", "TestFiles")]
		public void ParsingExample2()
		{
			var xml = File.ReadAllText("TestFiles\\CSVParser.xml");
			var data = File.ReadAllText("TestFiles\\SimpleCSV_error.txt");

			var rules = Parser.LoadXml(xml);
			var result = rules.Parse(data);
			Assert.IsFalse(result.IsMatch);
			Assert.AreEqual("Error at '31X' (line 14, position 9): expected an integer value.", result.GetErrorText());
		}

		/// <summary>
		/// Parsing Example 3 - Convert to XML
		/// </summary>
		[TestMethod()]
		[DeploymentItem("Parser\\TestFiles", "TestFiles")]
		[DeploymentItem("Parser\\TestParsers", "TestFiles")]
		public void ParsingExample3()
		{
			var xml = File.ReadAllText("TestFiles\\CSVParser.xml");
			var data = File.ReadAllText("TestFiles\\SimpleCSV.txt");

			var rules = Parser.LoadXml(xml);
			var result = rules.Parse(data);

			var xmlText = result.ToXml();
			var expected = @"<?xml version=""1.0"" encoding=""utf-16""?><Xml h1=""Header1a"" h2=""'Header2a'"" h3=""&quot;Header3a&quot;"" h4=""0""><R r1=""1"" r2=""Val21"" r3=""301"" r4=""'AA'"" /><R r1=""2"" r2=""Val22"" r3=""302"" r4=""'BB'"" /><R r1=""3"" r2=""Val23"" r3=""303"" r4=""'CC'"" /><R r1=""4"" r2=""Val24"" r3=""304"" r4=""'DD'"" /><R r1=""5"" r2=""Val25"" r3=""305"" r4=""'EE'"" /><R r1=""6"" r2=""Val26"" r3=""306"" r4=""'AAA'"" /><R r1=""7"" r2=""Val27"" r3=""307"" r4=""'BBB'"" /><R r1=""8"" r2=""Val28"" r3=""308"" r4=""'CCC'"" /><R r1=""9"" r2=""Val29"" r3=""309"" r4=""'DDD'"" /><R r1=""10"" r2=""Val30"" r3=""310"" r4=""'EEE'"" /><R r1=""11"" r2=""Val31"" r3=""311"" r4=""'AAAA'"" /><R r1=""12"" r2=""Val32"" r3=""312"" r4=""'BBBB'"" /><R r1=""13"" r2=""Val33"" r3=""313"" r4=""'CCCC'"" /><R r1=""14"" r2=""Val34"" r3=""314"" r4=""'DDDD'"" /><R r1=""15"" r2=""Val35"" r3=""315"" r4=""'EEEE'"" /></Xml>";
			Assert.AreEqual(expected, xmlText);

			xmlText = result.ToXml("xml", true);
			expected = @"<?xml version=""1.0"" encoding=""utf-16""?><xml h1=""Header1a"" h2=""'Header2a'"" h3=""&quot;Header3a&quot;"" h4=""0""><R r1=""1"" r2=""Val21"" r3=""301"" r4=""'AA'"" /><R r1=""2"" r2=""Val22"" r3=""302"" r4=""'BB'"" /><R r1=""3"" r2=""Val23"" r3=""303"" r4=""'CC'"" /><R r1=""4"" r2=""Val24"" r3=""304"" r4=""'DD'"" /><R r1=""5"" r2=""Val25"" r3=""305"" r4=""'EE'"" /><R r1=""6"" r2=""Val26"" r3=""306"" r4=""'AAA'"" /><R r1=""7"" r2=""Val27"" r3=""307"" r4=""'BBB'"" /><R r1=""8"" r2=""Val28"" r3=""308"" r4=""'CCC'"" /><R r1=""9"" r2=""Val29"" r3=""309"" r4=""'DDD'"" /><R r1=""10"" r2=""Val30"" r3=""310"" r4=""'EEE'"" /><R r1=""11"" r2=""Val31"" r3=""311"" r4=""'AAAA'"" /><R r1=""12"" r2=""Val32"" r3=""312"" r4=""'BBBB'"" /><R r1=""13"" r2=""Val33"" r3=""313"" r4=""'CCCC'"" /><R r1=""14"" r2=""Val34"" r3=""314"" r4=""'DDDD'"" /><R r1=""15"" r2=""Val35"" r3=""315"" r4=""'EEEE'"" /></xml>";
			Assert.AreEqual(expected, xmlText);

			xmlText = result.ToXml("test", false);
			expected = @"<?xml version=""1.0"" encoding=""utf-16""?><test><h1>Header1a</h1><h2>'Header2a'</h2><h3>""Header3a""</h3><h4>0</h4><R><r1>1</r1><r2>Val21</r2><r3>301</r3><r4>'AA'</r4></R><R><r1>2</r1><r2>Val22</r2><r3>302</r3><r4>'BB'</r4></R><R><r1>3</r1><r2>Val23</r2><r3>303</r3><r4>'CC'</r4></R><R><r1>4</r1><r2>Val24</r2><r3>304</r3><r4>'DD'</r4></R><R><r1>5</r1><r2>Val25</r2><r3>305</r3><r4>'EE'</r4></R><R><r1>6</r1><r2>Val26</r2><r3>306</r3><r4>'AAA'</r4></R><R><r1>7</r1><r2>Val27</r2><r3>307</r3><r4>'BBB'</r4></R><R><r1>8</r1><r2>Val28</r2><r3>308</r3><r4>'CCC'</r4></R><R><r1>9</r1><r2>Val29</r2><r3>309</r3><r4>'DDD'</r4></R><R><r1>10</r1><r2>Val30</r2><r3>310</r3><r4>'EEE'</r4></R><R><r1>11</r1><r2>Val31</r2><r3>311</r3><r4>'AAAA'</r4></R><R><r1>12</r1><r2>Val32</r2><r3>312</r3><r4>'BBBB'</r4></R><R><r1>13</r1><r2>Val33</r2><r3>313</r3><r4>'CCCC'</r4></R><R><r1>14</r1><r2>Val34</r2><r3>314</r3><r4>'DDDD'</r4></R><R><r1>15</r1><r2>Val35</r2><r3>315</r3><r4>'EEEE'</r4></R></test>";
			Assert.AreEqual(expected, xmlText);

			xmlText = result.ToXml("test", false, true);
			Assert.AreEqual(expected.Replace("<?xml version=\"1.0\" encoding=\"utf-16\"?>", ""), xmlText.Replace(">\r\n", ">").Replace("  <", "<").Replace("  <", "<"));
		}

		/// <summary>
		/// Parsing Example 3B - Convert to XML, explicit attribute modifiers
		/// Note that attribute modifier fields must appear before element fields.
		/// This is a requirement imposed by the XML writer.
		/// </summary>
		[TestMethod()]
		[DeploymentItem("Parser\\TestFiles", "TestFiles")]
		[DeploymentItem("Parser\\TestParsers", "TestFiles")]
		public void ParsingExample3B()
		{
			var xml = File.ReadAllText("TestFiles\\CSVParserB.xml");
			var data = File.ReadAllText("TestFiles\\SimpleCSV.txt");

			var rules = Parser.LoadXml(xml);
			var result = rules.Parse(data);

			var xmlText = result.ToXml();
			var expected = @"<?xml version=""1.0"" encoding=""utf-16""?><Xml h1=""Header1a"" h2=""'Header2a'"" h3=""&quot;Header3a&quot;"" h4=""0""><R r1=""1"" r2=""Val21"" r3=""301"" r4=""'AA'"" /><R r1=""2"" r2=""Val22"" r3=""302"" r4=""'BB'"" /><R r1=""3"" r2=""Val23"" r3=""303"" r4=""'CC'"" /><R r1=""4"" r2=""Val24"" r3=""304"" r4=""'DD'"" /><R r1=""5"" r2=""Val25"" r3=""305"" r4=""'EE'"" /><R r1=""6"" r2=""Val26"" r3=""306"" r4=""'AAA'"" /><R r1=""7"" r2=""Val27"" r3=""307"" r4=""'BBB'"" /><R r1=""8"" r2=""Val28"" r3=""308"" r4=""'CCC'"" /><R r1=""9"" r2=""Val29"" r3=""309"" r4=""'DDD'"" /><R r1=""10"" r2=""Val30"" r3=""310"" r4=""'EEE'"" /><R r1=""11"" r2=""Val31"" r3=""311"" r4=""'AAAA'"" /><R r1=""12"" r2=""Val32"" r3=""312"" r4=""'BBBB'"" /><R r1=""13"" r2=""Val33"" r3=""313"" r4=""'CCCC'"" /><R r1=""14"" r2=""Val34"" r3=""314"" r4=""'DDDD'"" /><R r1=""15"" r2=""Val35"" r3=""315"" r4=""'EEEE'"" /></Xml>";
			Assert.AreEqual(expected, xmlText);

			xmlText = result.ToXml("xml", true);
			expected = @"<?xml version=""1.0"" encoding=""utf-16""?><xml h1=""Header1a"" h2=""'Header2a'"" h3=""&quot;Header3a&quot;"" h4=""0""><R r1=""1"" r2=""Val21"" r3=""301"" r4=""'AA'"" /><R r1=""2"" r2=""Val22"" r3=""302"" r4=""'BB'"" /><R r1=""3"" r2=""Val23"" r3=""303"" r4=""'CC'"" /><R r1=""4"" r2=""Val24"" r3=""304"" r4=""'DD'"" /><R r1=""5"" r2=""Val25"" r3=""305"" r4=""'EE'"" /><R r1=""6"" r2=""Val26"" r3=""306"" r4=""'AAA'"" /><R r1=""7"" r2=""Val27"" r3=""307"" r4=""'BBB'"" /><R r1=""8"" r2=""Val28"" r3=""308"" r4=""'CCC'"" /><R r1=""9"" r2=""Val29"" r3=""309"" r4=""'DDD'"" /><R r1=""10"" r2=""Val30"" r3=""310"" r4=""'EEE'"" /><R r1=""11"" r2=""Val31"" r3=""311"" r4=""'AAAA'"" /><R r1=""12"" r2=""Val32"" r3=""312"" r4=""'BBBB'"" /><R r1=""13"" r2=""Val33"" r3=""313"" r4=""'CCCC'"" /><R r1=""14"" r2=""Val34"" r3=""314"" r4=""'DDDD'"" /><R r1=""15"" r2=""Val35"" r3=""315"" r4=""'EEEE'"" /></xml>";
			Assert.AreEqual(expected, xmlText);

			xmlText = result.ToXml("test", false);
			expected = @"<?xml version=""1.0"" encoding=""utf-16""?><test><h1>Header1a</h1><h2>'Header2a'</h2><h3>""Header3a""</h3><h4>0</h4><R r1=""1"" r2=""Val21""><r3>301</r3><r4>'AA'</r4></R><R r1=""2"" r2=""Val22""><r3>302</r3><r4>'BB'</r4></R><R r1=""3"" r2=""Val23""><r3>303</r3><r4>'CC'</r4></R><R r1=""4"" r2=""Val24""><r3>304</r3><r4>'DD'</r4></R><R r1=""5"" r2=""Val25""><r3>305</r3><r4>'EE'</r4></R><R r1=""6"" r2=""Val26""><r3>306</r3><r4>'AAA'</r4></R><R r1=""7"" r2=""Val27""><r3>307</r3><r4>'BBB'</r4></R><R r1=""8"" r2=""Val28""><r3>308</r3><r4>'CCC'</r4></R><R r1=""9"" r2=""Val29""><r3>309</r3><r4>'DDD'</r4></R><R r1=""10"" r2=""Val30""><r3>310</r3><r4>'EEE'</r4></R><R r1=""11"" r2=""Val31""><r3>311</r3><r4>'AAAA'</r4></R><R r1=""12"" r2=""Val32""><r3>312</r3><r4>'BBBB'</r4></R><R r1=""13"" r2=""Val33""><r3>313</r3><r4>'CCCC'</r4></R><R r1=""14"" r2=""Val34""><r3>314</r3><r4>'DDDD'</r4></R><R r1=""15"" r2=""Val35""><r3>315</r3><r4>'EEEE'</r4></R></test>";
			Assert.AreEqual(expected, xmlText);
		}

		/// <summary>
		/// Parsing Example 4 - Get Formatted output to XML
		/// </summary>
		[TestMethod()]
		[DeploymentItem("Parser\\TestFiles", "TestFiles")]
		[DeploymentItem("Parser\\TestParsers", "TestFiles")]
		public void ParsingExample4()
		{
			var xml = File.ReadAllText("TestFiles\\CSVParser.xml");
			var data = File.ReadAllText("TestFiles\\SimpleCSV.txt");

			var rules = Parser.LoadXml(xml);
			var result = rules.Parse(data);

			var xmlText = result.FormattedOutput();
			var expected =
@"Header1a:Header2a:Header3a:0
1|Val21|301|AA
2|Val22|302|BB
3|Val23|303|CC
4|Val24|304|DD
5|Val25|305|EE
6|Val26|306|AAA
7|Val27|307|BBB
8|Val28|308|CCC
9|Val29|309|DDD
10|Val30|310|EEE
11|Val31|311|AAAA
12|Val32|312|BBBB
13|Val33|313|CCCC
14|Val34|314|DDDD
15|Val35|315|EEEE
";
			Assert.AreEqual(expected, xmlText);
		}
	}
}
