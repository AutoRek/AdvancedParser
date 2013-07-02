using System;
using ApiSoftware.Library35.Parsing;
using System.Xml.Serialization;

namespace ApiSoftware.Library35.Parsing
{
	/// <summary>
	/// Rule interface
	/// </summary>
	public interface IRule
	{		
		/// <summary>
		/// Gets or sets the name of the Rule
		/// </summary>
		/// <value>
		/// The name of the rule.
		/// </value>
		[XmlAttribute]
		string Name { get; set; }

		/// <summary>
		/// Gets or sets the column.
		/// </summary>
		/// <value>
		/// The column.
		/// </value>
		string Column { get; set; }
		/// <summary>
		/// Gets or sets the error template.
		/// </summary>
		/// <value>
		/// The error template.
		/// </value>
		string ErrorTemplate { get; set; }

		/// <summary>
		/// Parses the specified position.
		/// </summary>
		/// <param name="position">The position.</param>
		/// <returns></returns>
		OutputNode Parse(int position);
		/// <summary>
		/// Gets or sets the table.
		/// </summary>
		/// <value>
		/// The table.
		/// </value>
		string Table { get; set; }
		/// <summary>
		/// Gets or sets the template.
		/// </summary>
		/// <value>
		/// The template.
		/// </value>
		string Template { get; set; }
	}
}
