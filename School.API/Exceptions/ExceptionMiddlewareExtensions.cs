using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using School.API.Data.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace School.API.Exceptions
{
    public static class ExceptionMiddlewareExtensions
    {

        //Built-int Exception Handler
        public static void ConfigureBuiltInExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    var contextRequest = context.Features.Get<IHttpRequestFeature>();

                    context.Response.ContentType = "application/json";

                    if (contextFeature != null)
                    {
                        var errorString = new ErrorResponseData()
                        {
                            StatusCode = (int)HttpStatusCode.InternalServerError,
                            Message = contextFeature.Error.Message,
                            Path = contextRequest.Path
                        }.ToString();

                        await context.Response.WriteAsync(errorString);
                    }
                });
            });
        }
    
        public static void ConfigureCustomExceptionHandler(this IApplicationBuilder app)
        {
            app.UseMiddleware<CustomExceptionHandler>();
        }
    }
}
