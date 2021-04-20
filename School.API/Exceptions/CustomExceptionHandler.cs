using Microsoft.AspNetCore.Http;
using School.API.Data.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace School.API.Exceptions
{
    public class CustomExceptionHandler
    {
        private readonly RequestDelegate _next;

        public CustomExceptionHandler(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }


        private Task HandleExceptionAsync(HttpContext httpContext, Exception ex)
        {
            httpContext.Response.ContentType = "application/json";

            var errorMessageString = new ErrorResponseData()
            {
                StatusCode = (int)HttpStatusCode.InternalServerError,
                Message = ex.Message,
                Path = httpContext.Request.Path
            }.ToString();

            return httpContext.Response.WriteAsync(errorMessageString);
        }
    }
}
