using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System;
using Microsoft.Extensions.DependencyInjection;
using RegExpASCIIViewer.Handlers;

namespace RegExpASCIIViewer
{
	public class Program
	{
		public static async Task Main(string[] args)
		{
			var appBuilder = WebApplication.CreateBuilder(args);
			appBuilder.Services.AddTransient<GetAciiTableFromReqularExpression>();

			var app = appBuilder.Build();
									
			app.MapGet("/asciitable", GetDelegate<GetAciiTableFromReqularExpression>((x, context) => x.GetAsciiTable(context)));

			await app.RunAsync();
		}

		public static RequestDelegate GetDelegate<T>(Func<T, HttpContext, Task> e)
		{
			return context =>
			{
				var service = (T)context.RequestServices.GetService(typeof(T));
				return e(service, context);
			};
		}
	}
}
