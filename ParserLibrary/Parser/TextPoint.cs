using System;
using System.Linq;
using System.Text.RegularExpressions;

using ApiSoftware.Library35;

namespace ApiSoftware.Library35.Parsing
{
	/// <summary>
	/// Represents a point in a text string
	/// </summary>
	public class TextPoint
	{
		/// <summary>
		/// Gets or sets the text used for the TextPoint
		/// </summary>
		/// <value>
		/// The text containing the text position.
		/// </value>
		public string Text { get; private set; }

		/// <summary>
		/// Gets the index position of the point within the text string
		/// </summary>
		/// <value>
		/// The index position.
		/// </value>
		public int Index { get; private set; }

		/// <summary>
		/// Gets the line number of the point within the text string
		/// </summary>
		/// <value>
		/// The line number.
		/// </value>
		public int Line { get; private set; }

		/// <summary>
		/// Gets the character position within the line of the text position
		/// </summary>
		/// <value>
		/// The character position.
		/// </value>
		public int Character { get; private set; }

		/// <summary>
		/// Gets the symbol at the text point.
		/// </summary>
		/// <value>
		/// The symbol.
		/// </value>
		public string Symbol
		{
			get
			{
				var re = new Regex(@"\s*(\w+|\W+)");
				return re.Match(Text, Index).Value;
			}
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="TextPoint"/> class.
		/// </summary>
		/// <param name="text">The text.</param>
		/// <param name="position">The position.</param>
		public TextPoint(string text, int position)
		{
			if (text == null) throw new ArgumentNullException("text");
			if (position > text.Length) { position = text.Length; }
			Text = text;
			Index = position;
			position = 0;
			int i;
			for (i = 0; i < Index; i++)
			{
				if (text[i] == '\n') { Line += 1; position = i + 1; }
			}
			Character = i - position;
		}
	}
}