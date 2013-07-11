using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApiSoftware.Library35.Parsing
{
	/// <summary>
	/// Extension methods for the parser
	/// </summary>
	static public class ParserUtilities
	{

		/// <summary>
		/// Gets the error text.
		/// </summary>
		/// <returns>The error text.</returns>
		static public string GetErrorText(this OutputNode node)
		{
			var errorNode = node.GetErrorNode();
			if (errorNode == null) return null;
			return errorNode.Rule.GetErrorText(errorNode);
		}

		/// <summary>
		/// Gets the error node.
		/// </summary>
		/// <returns>The error node (or null of there is no error).</returns>
		static public OutputNode GetErrorNode(this OutputNode node)
		{
			if (node == null || node.IsMatch) return null;
			var child = node.Children.FirstOrDefault(c => !c.IsMatch);
			if (child == null) return node; else return child.GetErrorNode();
		}
	}
}
