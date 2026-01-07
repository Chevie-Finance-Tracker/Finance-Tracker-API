using System.Net;
using Microsoft.AspNetCore.Diagnostics;

public static class ExceptionMiddlewareExtensions
{
    public static void UseGlobalExceptionHandler(this WebApplication app)
    {
        app.UseExceptionHandler(errorApp =>
        {
            errorApp.Run(async context =>
            {
                var exceptionFeature = context.Features.Get<IExceptionHandlerFeature>();
                var exception = exceptionFeature?.Error;

                context.Response.ContentType = "application/json";

                switch (exception)
                {
                    case KeyNotFoundException:
                        context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                        await context.Response.WriteAsJsonAsync(new
                        {
                            message = exception.Message
                        });
                        break;

                    case UnauthorizedAccessException:
                        context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                        await context.Response.WriteAsJsonAsync(new
                        {
                            message = exception.Message
                        });
                        break;

                    default:
                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        await context.Response.WriteAsJsonAsync(new
                        {
                            message = "An unexpected error occurred. O_O"
                        });
                        break;
                }
            });
        });
    }
}