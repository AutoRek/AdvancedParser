using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

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
			if (errorNode == null) return null; else return errorNode.Rule.GetErrorText(errorNode);
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

		/// <summary>
		/// Gets the node in Xml format, using the Record and Field attributes.
		/// </summary>
		/// <param name="node">The node.</param>
		/// <returns>
		/// Xml in string format.
		/// </returns>
		static public string ToXml(this OutputNode node)
		{
			return ToXml(node, "Xml", true);
		}

		/// <summary>
		/// Gets the node in Xml format, using the Record and Field attributes.
		/// </summary>
		/// <param name="node">The node to get Xml from.</param>
		/// <param name="rootNode">The root node.</param>
		/// <param name="useAttributes">if set to <c>true</c> field values will be put in attributes.</param>
		/// <returns>
		/// Xml in string format.
		/// </returns>
		static public string ToXml(this OutputNode node, string rootNode, bool useAttributes)
		{
			if (node == null) throw new ArgumentNullException("node");
			var sb = new StringBuilder();
			using (var writer = XmlWriter.Create(sb))
			{
				writer.WriteStartDocument();
				writer.WriteStartElement(rootNode);
				writer.WriteXml(node, useAttributes);
				writer.WriteEndElement();
				writer.WriteEndDocument();
			}
			return sb.ToString();
		}

		/// <summary>
		/// Writes the node as Xml to the writer.
		/// </summary>
		/// <param name="writer">The writer.</param>
		/// <param name="node">The node.</param>
		static public void WriteXml(this XmlWriter writer, OutputNode node)
		{
			WriteXml(writer, node, true);
		}

		/// <summary>
		/// Writes the node as Xml to the writer.
		/// </summary>
		/// <param name="writer">The writer.</param>
		/// <param name="node">The node.</param>
		/// <param name="useAttributes">if set to <c>true</c> field values will be put in attributes.</param>
		static public void WriteXml(this XmlWriter writer, OutputNode node, bool useAttributes)
		{
			if (writer == null) throw new ArgumentNullException("writer");
			if (node == null) throw new ArgumentNullException("node");
			var tableName = node.Rule.Record;
			var columnName = node.Rule.Field;
			if (!string.IsNullOrEmpty(tableName)) writer.WriteStartElement(tableName);
			if (!string.IsNullOrEmpty(columnName))
			{
				if (useAttributes || columnName.StartsWith("@", StringComparison.Ordinal))
				{
					columnName = columnName.TrimStart('@');
					writer.WriteAttributeString(columnName, node.NodeText);
				}
				else
				{
					writer.WriteElementString(columnName, node.NodeText);
				}
			}
			foreach (var childNode in node.Children)
			{
				writer.WriteXml(childNode, useAttributes);
			}
			if (!string.IsNullOrEmpty(tableName)) writer.WriteEndElement();
		}

	}
}
