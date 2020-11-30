using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RegExpASCIIViewer.Handlers
{
	public class GetAciiTableFromReqularExpression
	{
		public async Task GetAsciiTable(HttpContext context)
		{
			if (!context.Request.Query.TryGetValue("regexp", out var regExp)
				|| string.IsNullOrEmpty(regExp))
			{
				throw new ArgumentException("Regexp not provided");
			}

			var table = AsciiGenerator.GenerateCharList();
			var matches = Regex.Matches(table, regExp);

			var m = string.Join(string.Empty, matches.Select(x => x.Value));
			var toHighlight = m.ToHashSet();
			

			var renderer = new AsciiTableRenderer();
			await context.Response.WriteAsync(renderer.Render(toHighlight));			
		}
	}
}
