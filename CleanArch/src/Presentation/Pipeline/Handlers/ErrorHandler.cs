using System.Text.Json;
using Application;
using Infrastructure;
using Microsoft.AspNetCore.Diagnostics;

namespace Presentation.Pipeline.Handlers;

public static class ErrorHandlerExtensions
{
    public static void UseErrorHandler(this IApplicationBuilder app) =>
        app.UseExceptionHandler(error =>
        {
            error.Run(async context =>
            {
                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                if (contextFeature is null) return;

                context.Response.Headers.Append("Access-Control-Allow-Origin", "*");
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = contextFeature.Error switch
                {
                    RequestValidationException => StatusCodes.Status400BadRequest,
                    EntityNotFoundException => StatusCodes.Status404NotFound,
                    DuplicatedEntityException => StatusCodes.Status409Conflict,
                    _ => StatusCodes.Status500InternalServerError,
                };

                await context.Response.WriteAsync(JsonSerializer.Serialize(contextFeature.Error));
            });
        });
}