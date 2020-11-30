using System;
using System.Text;

namespace RegExpASCIIViewer
{
	public class AsciiGenerator
	{
		public static string GenerateCharList()
		{
			var firstCharacter = 32;
			var lastCharacter = 126;

			var asciiList = new StringBuilder(lastCharacter - firstCharacter);
			for (int i = firstCharacter; i <= lastCharacter; i++)
			{
				asciiList.Append((char)i);
			}

			return asciiList.ToString();
		}
	}
}
