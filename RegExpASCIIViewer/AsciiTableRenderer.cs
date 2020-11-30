using System.Collections.Generic;
using System.Text;

namespace RegExpASCIIViewer
{
	public class AsciiTableRenderer
	{
		private int _charsPerLine = 10;		

		public string Render(HashSet<char> highlightedChars)
		{			
			var asciiList = AsciiGenerator.GenerateCharList();
			
			return GenerateOutput(highlightedChars, asciiList);
		}

		private string GenerateOutput(HashSet<char> highlightedChars, string asciiList)
		{
			var output = new StringBuilder();
			int numOfRows = CalculateNumberOfRows(asciiList);

			for (int i = 0; i < numOfRows; i++)
			{
				for (int j = 0; j < _charsPerLine; j++)
				{
					var index = i * 10 + j;
					if (index >= asciiList.Length)
					{
						continue;
					}

					var c = asciiList[index];
					var formattedForPrint = highlightedChars.Contains(c) ? $"[91m{c}[0m" : $"{c}";
					output.Append($"   {formattedForPrint}   ");
				}

				output.Append('\n');
			}

			return output.ToString();
		}

		private int CalculateNumberOfRows(string asciiList)
		{
			var numOfChars = asciiList.Length;

			var numOfRows = numOfChars % _charsPerLine > 0
				? numOfChars / _charsPerLine + 1
				: numOfChars / _charsPerLine;
			return numOfRows;
		}
	}
}
