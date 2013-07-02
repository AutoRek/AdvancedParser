using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using System.Diagnostics.CodeAnalysis;

namespace ApiSoftware.Library35.Parsing
{
	/// <summary>
	/// A reference to another rule by its name.
	/// </summary>
	/// <remarks>
	/// A reference rule passes the parsing on to the named rule. This
	/// allows rules to reference other rules and represent recursive
	/// grammars (such as for common languages like C#).
	/// 
	/// When the grammar is initialised, each reference rule is replaced
	/// by a direct object reference to the named rule.
	/// </remarks>
	public sealed class Include : RuleBase
	{

		/// <summary>
		/// Gets or sets the name of another rule to reference here.
		/// </summary>
		/// <value>
		/// The name of the referenced rule.
		/// </value>
		[XmlText]
		public string Reference { get; set; }

		/// <summary>
		/// Uses the rule to parse the text from the specified position.
		/// </summary>
		/// <param name="position">The position to parse from.</param>
		/// <returns>
		/// The result of the parse.
		/// </returns>
		/// <remarks>
		/// Note that all rule references should be removed before parsing, so
		/// this method should never be called.
		/// </remarks>
		[ExcludeFromCodeCoverage]
		public override OutputNode Parse(int position)
		{
			throw new NotImplementedException("Rule references will all be removed before the rules run. This method will never be executed.");
		}

		[ExcludeFromCodeCoverage]
		internal override string FormattedOutput(OutputNode node)
		{
			throw new NotImplementedException("Rule references will all be removed before the rules run. This method will never be executed.");
		}
	}

}
