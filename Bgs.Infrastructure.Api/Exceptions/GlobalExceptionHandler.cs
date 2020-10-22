using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Bgs.Infrastructure.Api.Exceptions
{
    public class GlobalExceptionHandler
    {
        private readonly RequestDelegate _next;

        public GlobalExceptionHandler(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }

            catch
            {
                await HandleExceptionAsync(httpContext, (int)HttpStatusCode.InternalServerError);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, int statusCode, string message = null)
        {
            context.Response.ContentType = "Application/Json";
            context.Response.StatusCode = statusCode;

            var responseString = JsonConvert.SerializeObject(new
            {
                message
            });

            return context.Response.WriteAsync(responseString);
        }
    }
}
