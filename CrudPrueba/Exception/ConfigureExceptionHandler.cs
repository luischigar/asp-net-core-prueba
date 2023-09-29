using CrudPrueba.Service.Dto;
using Microsoft.AspNetCore.Diagnostics;
using Serilog;

namespace CrudPrueba.Exception
{
    public static class ConfigureExceptionHandler
    {
        public static void ExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(error =>
            {
                error.Run(async context =>
                {
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    context.Response.ContentType = "application/json";
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if(contextFeature != null)
                    {
                        Log.Error(contextFeature.Error.ToString());

                        await context.Response.WriteAsync(new Error
                        {
                            Message = contextFeature.Error.Message.ToString(),
                            StatusCode = context.Response.StatusCode
                        }.ToString());
                    }
                });
            });
        }
    }
}
