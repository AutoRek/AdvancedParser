using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Xml.Serialization;

namespace ApiSoftware.Library35.Parsing
{
	/// <summary>
	/// Collection of output nodes.
	/// </summary>
	[Serializable]
	public class NodeCollection : System.Collections.ObjectModel.Collection<OutputNode>
	{
		private OutputNode parent;

		/// <summary>
		/// Create an instance of the <see cref="NodeCollection"/>.
		/// </summary>
		/// <param name="parent">The output node containing this collection of nodes.</param>
		public NodeCollection(OutputNode parent)
		{
			this.parent = parent;
		}

		/// <summary>
		/// Add the item to the collection a the position
		/// </summary>
		/// <param name="index"></param>
		/// <param name="item"></param>
		protected override void InsertItem(int index, OutputNode item)
		{
			if (item == null) throw new ArgumentNullException(nameof(item));
			if (item == parent) throw new ArgumentException("Cannot add node to its own child nodes", nameof(item));
			item.ParentNode = parent;
			base.InsertItem(index, item);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="index"></param>
		protected override void RemoveItem(int index)
		{
			base[index].ParentNode = null;
			base.RemoveItem(index);

		}

		/// <summary>
		/// Replaces the item at the specified index position with the supplied item.
		/// </summary>
		/// <param name="index"></param>
		/// <param name="item"></param>
		/// <remarks>
		/// The item that was there previously is disconnected from this collection.
		/// </remarks>
		protected override void SetItem(int index, OutputNode item)
		{
			if (item == null) throw new ArgumentNullException(nameof(item));
			base[index].ParentNode = null;
			item.ParentNode = parent;
			base.SetItem(index, item);
		}
	}

}
