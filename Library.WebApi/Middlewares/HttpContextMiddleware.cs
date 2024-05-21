using Microsoft.AspNetCore.Http;
using System;
using System.Configuration;

namespace Library.WebApi.Api.Middlewares
{
    public class HttpContextMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<HttpContextMiddleware> _logger;
        private readonly IConfiguration _configuration;
        public HttpContextMiddleware(RequestDelegate next, ILogger<HttpContextMiddleware> logger, IConfiguration configuration)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
            _logger = logger;
            _configuration = configuration;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            string statusCode = getStatus(ex)[0];
            string errorType = getStatus(ex)[1];
            context.Response.StatusCode = int.Parse(getStatus(ex)[0]);
            context.Response.ContentType = "application/json";
            var exceptionMessage = _configuration.GetValue<string>("ExceptionMessage:Message");
            return context.Response.WriteAsync("Message: " + statusCode + "Description: " + exceptionMessage);
        }

        private string[] getStatus(Exception ex)
        {
            int statusCode = 500;
            string errorType = "Internal Server Error";

            string[] data = new string[2];
            
            data[0] = statusCode.ToString();
            data[1] = errorType;

            return data;
        }
    }
}
