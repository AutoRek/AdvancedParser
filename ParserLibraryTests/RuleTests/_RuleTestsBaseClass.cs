using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParserLibraryTests
{
	public abstract class RuleTestsBaseClass
	{
		/// <summary>
		/// On creation of a new rule, the rule should be properly initialised.
		/// The details will depend on the type of the rule.
		/// </summary>
		public abstract void ConstructorTest();

		/// <summary>
		/// This test checks that a newly constructed rule that contains
		/// reference rules (if appropriate) initialises properly given
		/// a rule list of named rules. References to other named rules 
		/// by name must all be converted to direct object reference.
		/// </summary>
		public abstract void InitializeTest();

		/// <summary>
		/// By default all rules should list their type and name if any. If
		/// the rule includes a simple pattern, that will be included.
		/// </summary>
		public abstract void ToStringTest();

		/// <summary>
		/// A simple instance of the rule will parse a variety of sample text
		/// values and output the correct output nodes. Some specific failure
		/// cases will also be tried to test that parsing started from the 
		/// correct location.
		/// </summary>
		public abstract void ParseTest();

		/// <summary>
		/// A simple instance of the rule will parse a variety of sample text
		/// values and output the correct output nodes. This test covers the
		/// case when parsing is carried out from a location within the text.
		/// Some specific failure cases will also be tried to test that parsing 
		/// started from the  correct location.
		/// </summary>
		public abstract void ParsePositionTest();

		/// <summary>
		/// If a rule attempts to parse an out-of-range position, an error is
		/// raised explicitly describing the situation
		/// </summary>
		public abstract void ParseErrorInput();

		/// <summary>
		/// This test checks that when a simple rule has parsed some text
		/// it generates the correct output based on the result node.
		/// Most rules will output the text of the node, but some rules
		/// can get more specific information.
		/// </summary>
		public abstract void GetFormattedOutputTest();

		/// <summary>
		/// A simple instance of the rule, on parsing a simple value,
		/// should return the result of the parsed value (unless the
		/// rule type specifically does otherwise).
		/// </summary>
		public abstract void GetValueTest();

		/// <summary>
		/// A simple instance of the rule, on failing to parse a simple value
		/// should return the standard error text and any additional rule-
		/// specific text required for the type of rule.
		/// 
		/// If an error template is provided, that will be used as the error
		/// text, optionally with result values substituted in.
		/// </summary>
		public abstract void GetErrorTextTest();

	}
}
