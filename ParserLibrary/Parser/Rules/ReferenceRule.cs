using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Xml.Serialization;

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
	public sealed class ReferenceRule : RuleBase
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
		/// <param name="text">The text being parsed.</param>
		/// <param name="position">The position to parse from.</param>
		/// <returns>
		/// The result of the parse.
		/// </returns>
		/// <exception cref="System.NotImplementedException">Rule references will all be removed before the rules run. This method will never be executed.</exception>
		/// <remarks>
		/// Note that all rule references should be removed before parsing, so
		/// this method should never be called.
		/// </remarks>
		[ExcludeFromCodeCoverage]
		public override OutputNode Parse(string text, int position)
		{
			throw new NotImplementedException("Rule references will all be removed before the rules run. This method will never be executed.");
		}

		[ExcludeFromCodeCoverage]
		internal override string FormattedOutput(OutputNode node)
		{
			throw new NotImplementedException("Rule references will all be removed before the rules run. This method will never be executed.");
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ReferenceRule"/> class.
		/// </summary>
		public ReferenceRule()
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ReferenceRule"/> class.
		/// </summary>
		/// <param name="name">The name of the referenced rule.</param>
		public ReferenceRule(string name)
			: this()
		{
			Reference = name;
		}
	}
}