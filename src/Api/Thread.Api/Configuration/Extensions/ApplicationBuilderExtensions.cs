using ExceptionHandlerMiddleware = Thread.Api.Configuration.Middlewares.ExceptionHandlerMiddleware;

namespace Thread.Api.Configuration.Extensions;

internal static class ApplicationBuilderExtensions
{
    internal static IApplicationBuilder UseCustomProblemDetails(this IApplicationBuilder app)
    {
        return app.UseMiddleware<ExceptionHandlerMiddleware>();
    }
}