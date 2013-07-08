using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApiSoftware.Library35.Parsing
{
	public abstract class NodeBaseTestClass
	{
		/// <summary>
		/// Each node should initialise correctly with the correct match 
		/// status, an object reference to the rule and the correct begin 
		/// and end.
		/// </summary>
		abstract public void ConstructorTest();

		/// <summary>
		/// Each node should return the value associated with the node
		/// in the appropriate way for the type of node.
		/// </summary>
		abstract public void ValueTest();

		/// <summary>
		/// Each node should return the node text as a string based on the 
		/// begin and end position if appropriate for the type of node.
		/// </summary>
		abstract public void NodeTextTest();

		/// <summary>
		/// Each node should return the formatted output of the node based
		/// on using the node's rule to get the formatted output.
		/// </summary>
		abstract public void FormattedOutputTest();

		/// <summary>
		/// Each node type should get the error text appropriate to the 
		/// node type and rule. Block nodes in particular should get the
		/// error text of any error nodes they contain.
		/// </summary>
		abstract public void GetErrorTextTest();

		/// <summary>
		/// If the rule has table and column data setup, then each node
		/// should add it's value to the table and column as per the rule's
		/// settings.
		/// </summary>
		abstract public void FillTest();
	}
}
