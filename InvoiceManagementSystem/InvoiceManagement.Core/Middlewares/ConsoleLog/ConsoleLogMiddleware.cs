using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace InvoiceManagement.Core.Middlewares.ConsoleLog
{
    public class ConsoleLogMiddleware
    {
        private readonly RequestDelegate _next;

        public ConsoleLogMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var watch = Stopwatch.StartNew();

            string message = $"[Request]  HTTP {context.Request.Method} - {context.Request.Path}";
            Console.WriteLine(message);

            await _next(context);
            watch.Stop();

            message =
                $"[Response] HTTP {context.Request.Method} - {context.Request.Path} responded {context.Response.StatusCode} in {watch.Elapsed.TotalMilliseconds} ms";
            Console.WriteLine(message);
        }
    }

    public static class ConsoleLogMiddlewareExtension
    {
        public static IApplicationBuilder UseConsoleLogMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ConsoleLogMiddleware>();
        }
    }
}

