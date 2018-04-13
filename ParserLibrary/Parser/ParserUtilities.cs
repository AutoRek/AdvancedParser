using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using ApiSoftware.Library35;

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
		/// This method collects node values into data sets. Nodes that begin new records
		/// must have the Record attribute set. Each time a node is parsed with a record
		/// attribute set, a new record for that table is created and becomes the current
		/// record. The record name is used as the table name  of the new record. 
		/// 
		/// As column attributes are parsed, they are used to indicate the column values
		/// for the current record, where the columns are added automatically to the table
		/// hosting the record. 
		/// 
		/// The current record context is retained until a new record is specified or if 
		/// a child rule creates a new record context, when that context ends, the previous
		/// context is returned.
		/// 
		/// If the same column appears in more than one attribute on the same record, 
		/// the subsequence occurences will overwrite the previous ones.
		/// 
		/// <para>
		/// Columns that are set before the record attribute is specified are deemed to be
		/// 'common' and are automatically added to all tables. The current values of the
		/// common columns are used for all the records added. This feature is particularly
		/// useful to denormalise hierarchical data that might be parsed out of a data file;
		/// the common fields are set by parent levels in the grammar while the lowest child
		/// level sets up the denormalised record that will include all the common fields of
		/// the parent.
		/// </para>
		/// </remarks>
		static public void Fill(this OutputNode node, DataSet dataSet)
		{
			node.Fill(dataSet, IdMode.None, IdStyle.None, null, new Dictionary<string, object>());
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
			node.Fill(dataSet, idMode, idStyle, null, new Dictionary<string, object>());
		}

		/// <summary>
		/// Fills the specified data set with data from this node and its children.
		/// </summary>
		/// <param name="node">The node.</param>
		/// <param name="dataSet">The data set to fill.</param>
		/// <param name="idMode">The mode for handling record Ids.</param>
		/// <param name="idStyle">The style for the generated ids.</param>
		/// <param name="row">The current row being filled.</param>
		/// <param name="commonValues">The current common or shared field values.</param>
		static private void Fill(this OutputNode node, DataSet dataSet, IdMode idMode, IdStyle idStyle, DataRow row, Dictionary<string, object> commonValues)
		{
			if (node == null || dataSet == null) return;
			var value = node.Value;
			var parentId = string.Empty;

			// If the node specifies a table, create a new row on that table as the
			// current row. Create the table if necessary.
			var tableName = node.Rule.Record;
			if (!string.IsNullOrEmpty(tableName))
			{
				// create a new row in the named table
				if (!dataSet.Tables.Contains(tableName)) { CreateTable(dataSet, idMode, tableName); }
				if (row != null && idMode == IdMode.RowAndParents) parentId = Convert.ToString(row[OutputNode.RecordIdField], CultureInfo.InvariantCulture);
				row = dataSet.Tables[tableName].NewRow();
				if (idStyle == IdStyle.Guid)
				{
					row[OutputNode.RecordIdField] = Guid.NewGuid();
				}
				if (idMode == IdMode.RowAndParents)
				{
					row[OutputNode.ParentIdField] = parentId;
				}
				dataSet.Tables[tableName].Rows.Add(row);
				// Add the common values, if any
				foreach (var field in commonValues)
				{
					SetColumnValue(row, field.Key, field.Value);
				}
			}

			// Clear commonValues if required before the new row is started.
			if (node.Rule.ClearFields != null)
			{
				if (node.Rule.ClearFields == "*")
				{
					// Clear all fields
					commonValues.Clear();
				}
				else
				{
					// Clear named fields
					foreach (var name in node.Rule.ClearFields.Split(','))
					{
						if (commonValues.ContainsKey(name)) commonValues.Remove(name);
					}
				}
			}

			// If the current node specifies a column, populate the column of the
			// current row with the node's value. (Create the column if necessary).
			// If there is no current row, set the common field value.
			var columnName = node.Rule.Field;
			if (!string.IsNullOrEmpty(columnName))
			{
				if (row != null)
				{
					SetColumnValue(row, columnName, value);
				}
				else
				{
					commonValues[columnName] = value;
				}
			}

			// Process all the child nodes into the current row.
			foreach (var item in node.Children)
			{
				item.Fill(dataSet, idMode, idStyle, row, commonValues);
			}
		}

		// Set the named column of the row to the specified value, adding the column to the table if needed.
		static private void SetColumnValue(DataRow row, string columnName, object value)
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
			row[columnName] = value ?? DBNull.Value;
		}

		// Create the table in the dataset (already assumed not to exist)
		static private void CreateTable(DataSet dataSet, IdMode idMode, string tableName)
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
		/// <param name="node">The node.</param>
		/// <param name="useXDocument">if set to <c>true</c> uses xDocument. xDocument has the ability to replace duplicate attributes, but will decrease performance.</param>
		/// <returns>
		/// Xml in string format.
		/// </returns>
		static public string ToXml(this OutputNode node, bool useXDocument = false)
		{
			return ToXml(node, "Xml", true, useXDocument);
		}

		/// <summary>
		/// Gets the node in Xml format, using the Record and Field attributes.
		/// </summary>
		/// <param name="node">The node to get Xml from.</param>
		/// <param name="rootNodeName">The root node.</param>
		/// <param name="useAttributes">if set to <c>true</c> field values will be put in attributes.</param>
		/// <param name="useXDocument">if set to <c>true</c> uses xDocument.</param>
		/// <returns>
		/// Xml in string format.
		/// </returns>
		static public string ToXml(this OutputNode node, string rootNodeName, bool useAttributes, bool useXDocument = false)
		{
			if (node == null) throw new ArgumentNullException("node");
			if (useXDocument)
			{
				var rootNode = new XElement(rootNodeName);
				rootNode.WriteXml(node, useAttributes);
				return new XDocument(rootNode).ToString();
			}
			else
			{
				var sb = new StringBuilder();
				using (var writer = XmlWriter.Create(sb))
				{
					writer.WriteStartDocument();
					writer.WriteStartElement(rootNodeName);
					writer.WriteXml(node, useAttributes);
					writer.WriteEndElement();
					writer.WriteEndDocument();
				}
				return sb.ToString();
			}
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
		/// Writes the node as Xml to the Document.
		/// </summary>
		/// <param name="rootNode">The root xElement.</param>
		/// <param name="node">The node.</param>
		static public void WriteXml(this XElement rootNode, OutputNode node)
		{
			WriteXml(rootNode, node, true);
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
			var tableName = SafeName(node.Rule.Record);
			var columnName = SafeName(node.Rule.Field);
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

		/// <summary>
		/// Writes the node as Xml to the writer.
		/// </summary>
		/// <param name="rootNode">The root xElement.</param>
		/// <param name="node">The node.</param>
		/// <param name="useAttributes">if set to <c>true</c> field values will be put in attributes.</param>
		static public void WriteXml(this XElement rootNode, OutputNode node, bool useAttributes)
		{
			if (rootNode == null) throw new ArgumentNullException("rootNode");
			if (node == null) throw new ArgumentNullException("node");
			var tableName = SafeName(node.Rule.Record);
			var columnName = SafeName(node.Rule.Field);
			XElement currentNode = null;
			if (!string.IsNullOrEmpty(tableName)) currentNode = new XElement(tableName); else currentNode = rootNode;
			if (!string.IsNullOrEmpty(columnName))
			{
				if (useAttributes || columnName.StartsWith("@", StringComparison.Ordinal))
				{
					columnName = columnName.TrimStart('@');
					// XElement is sensitive to duplicate attributes, so take steps to avoid adding them.
					var attributes = currentNode.Attributes(columnName);
					if (attributes.Count() == 0)
					{
						// Add the attribute if not already present.
						currentNode.Add(new XAttribute(columnName, node.NodeText));
					}
					else
					{
						// Set the attribute with the value otherwise (avoids duplicate attribute errors).
						attributes.First().Value = node.NodeText;
					}
				}
				else
				{
					currentNode.Add(new XElement(columnName, node.NodeText));
				}
			}
			foreach (var childNode in node.Children)
			{
				currentNode.WriteXml(childNode, useAttributes);
			}
			if (!string.IsNullOrEmpty(tableName)) rootNode.Add(currentNode);
		}

		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters", MessageId = "ApiSoftware.Library35.Dictionaries.AddKeyValues(System.Collections.IDictionary,System.String,System.String,System.String)",
			Justification = "String contains no locale-sensitive values")]
		static private string SafeName(string name)
		{
			var replacements = new Dictionary<string, string>();
			replacements.AddKeyValues(" ,_|/,_|(,_|),_|',_", ",", "|");
			if (string.IsNullOrEmpty(name)) return name; else return name.Replace(replacements, StringComparison.Ordinal);
		}
	}
}