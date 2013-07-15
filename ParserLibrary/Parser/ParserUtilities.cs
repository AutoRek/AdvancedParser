using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Data;

namespace ApiSoftware.Library35.Parsing
{
	/// <summary>
	/// Different record ID generation styles.
	/// </summary>
	public enum IdStyle
	{
		/// <summary>
		/// No Ids will be created.
		/// </summary>
		None,

		/// <summary>
		/// Ids are integers.
		/// </summary>
		Int,

		/// <summary>
		/// Ids are Guids.
		/// </summary>
		Guid
	}

	/// <summary>
	/// Different record ID generation modes.
	/// </summary>
	public enum IdMode
	{
		/// <summary>
		/// No Ids will be created.
		/// </summary>
		None,
		/// <summary>
		/// Row Ids only are created.
		/// </summary>
		Rows,
		/// <summary>
		/// Row and parent Ids are created.
		/// </summary>
		RowAndParents
	}

	/// <summary>
	/// Extension methods for the parser
	/// </summary>
	static public class ParserUtilities
	{

		/// <summary>
		/// Gets the error text.
		/// </summary>
		/// <param name="node">The node.</param>
		/// <returns>
		/// The error text.
		/// </returns>
		static public string GetErrorText(this OutputNode node)
		{
			var errorNode = node.GetErrorNode();
			if (errorNode == null) return null; else return errorNode.Rule.GetErrorText(errorNode);
		}

		/// <summary>
		/// Gets the error node.
		/// </summary>
		/// <param name="node">The node.</param>
		/// <returns>
		/// The error node (or null of there is no error).
		/// </returns>
		static public OutputNode GetErrorNode(this OutputNode node)
		{
			if (node == null || node.IsMatch) return null;
			var child = node.Children.FirstOrDefault(c => !c.IsMatch);
			if (child == null) return node; else return child.GetErrorNode();
		}


		/// <summary>
		/// Fills the specified data set with data from this node and its children.
		/// </summary>
		/// <param name="node">The node.</param>
		/// <param name="dataSet">The data set to fill.</param>
		/// <remarks>
		/// Each node that the rule creates will create a new row for the named
		/// table. The values of the row will be set using any symbols containing
		/// a Column attribute, where columns will be added automatically.
		/// Node.Fill()
		/// This method collects node values into data sets. The record name is used as the
		/// table name of the new record and the field name is used to determine the column
		/// that the node will populate. Tables are added automatically
		/// </remarks>
		static public void Fill(this OutputNode node, DataSet dataSet)
		{
			node.Fill(dataSet, null, IdMode.None, IdStyle.None);
		}

		/// <summary>
		/// Fills the specified data set with data from this node and its children.
		/// </summary>
		/// <param name="node">The node.</param>
		/// <param name="dataSet">The data set to fill.</param>
		/// <param name="idMode">The mode for handling record Ids.</param>
		/// <param name="idStyle">The style for the generated ids.</param>
		static public void Fill(this OutputNode node, DataSet dataSet, IdMode idMode, IdStyle idStyle)
		{
			node.Fill(dataSet, null, idMode, idStyle);
		}

		/// <summary>
		/// Fills the specified data set with data from this node and its children.
		/// </summary>
		/// <param name="node">The node.</param>
		/// <param name="dataSet">The data set to fill.</param>
		/// <param name="row">The current row being filled.</param>
		/// <param name="idMode">The mode for handling record Ids.</param>
		/// <param name="idStyle">The style for the generated ids.</param>
		static public void Fill(this OutputNode node, DataSet dataSet, DataRow row, IdMode idMode, IdStyle idStyle)
		{
			if (node == null || dataSet == null) return;
			var value = node.Value;

			// If the node specifies a table, create a new row on that table as the
			// current row. Create the table if necessary.
			var tableName = node.Rule.Record;
			if (!string.IsNullOrEmpty(tableName))
			{
				// create a new row in the named table
				if (!dataSet.Tables.Contains(tableName)) { CreateTable(dataSet, idMode, tableName); }
				row = dataSet.Tables[tableName].NewRow();
				if (idStyle == IdStyle.Guid)
				{
					row[OutputNode.RecordIdField] = Guid.NewGuid();
				}
				dataSet.Tables[tableName].Rows.Add(row);
			}

			// If the current node specifies a column, populate the column of the
			// current row with the node's value. (Create the column if necessary)
			var columnName = node.Rule.Field;
			if (!string.IsNullOrEmpty(columnName) && row != null)
			{
				if (!row.Table.Columns.Contains(columnName))
				{
					if (value == null)
					{
						// add the column without explicit type (will effectively be a string)
						row.Table.Columns.Add(columnName);
					}
					else
					{
						// add the column in the correct type
						row.Table.Columns.Add(columnName, value.GetType());
					}
				}
				row[columnName] = value;
			}

			// Process all the child nodes into the current row.
			foreach (var item in node.Children)
			{
				item.Fill(dataSet, row, idMode, idStyle);
			}
		}

		// Create the table in the dataset (already assumed not to exist)
		private static void CreateTable(DataSet dataSet, IdMode idMode, string tableName)
		{
			var t = dataSet.Tables.Add(tableName);
			switch (idMode)
			{
				case IdMode.Rows:
					t.Columns.Add(OutputNode.RecordIdField);
					break;
				case IdMode.RowAndParents:
					t.Columns.Add(OutputNode.RecordIdField);
					t.Columns.Add(OutputNode.ParentIdField);
					break;
				default:
					break;
			}
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
