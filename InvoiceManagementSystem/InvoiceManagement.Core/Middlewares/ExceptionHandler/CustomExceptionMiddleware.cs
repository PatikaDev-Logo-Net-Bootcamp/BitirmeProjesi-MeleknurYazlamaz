using System;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;
using InvoiceManagement.Core.Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace InvoiceManagement.Core.Middlewares.ExceptionHandler
{
    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILoggerService _loggerService;

        public CustomExceptionMiddleware(RequestDelegate requestDelegate, ILoggerService loggerService)
        {
            _next = requestDelegate;
            _loggerService = loggerService;
        }

        public async Task Invoke(HttpContext context)
        {
            var watch = Stopwatch.StartNew();
            try
            {
                string message = $"[Request]  HTTP {context.Request.Method} - {context.Request.Path}";
                _loggerService.Log(message);

                await _next(context);
                watch.Stop();

                message = $"[Response] HTTP {context.Request.Method} - {context.Request.Path} responded {context.Response.StatusCode} in {watch.Elapsed.TotalMilliseconds} ms";
                _loggerService.Log(message);
            }
            catch (Exception ex)
            {
                watch.Stop();
                await HandleException(context, ex, watch);
            }

        }

        private Task HandleException(HttpContext context, Exception ex, Stopwatch watch)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            string message = $"[Error]    HTTP {context.Request.Method} - {context.Response.StatusCode} Error Message: {ex.Message} in {watch.Elapsed.TotalMilliseconds} ms";
            _loggerService.Log(message);

            var result = JsonConvert.SerializeObject(new { Error = ex.Message }, Formatting.None);

            return context.Response.WriteAsync(result);
        }
    }

    public static class CustomExceptionMiddlewareExtension
    {
        public static IApplicationBuilder UseCustomExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomExceptionMiddleware>();
        }
    }
}
