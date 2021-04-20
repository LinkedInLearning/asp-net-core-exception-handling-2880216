using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using School.API.Data.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace School.API.Exceptions.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class CustomExceptionFilter:ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            context.HttpContext.Response.ContentType = "application/json";

            var exceptionString = new ErrorResponseData()
            {
                StatusCode = (int)HttpStatusCode.InternalServerError,
                Message = context.Exception.Message,
                Path = context.Exception.StackTrace
            }.ToString();

            context.Result = new JsonResult(exceptionString);
        }
    }
}
