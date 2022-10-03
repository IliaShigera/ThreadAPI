using ExceptionHandlerMiddleware = Thread.Api.Configuration.Middlewares.ExceptionHandlerMiddleware;

namespace Thread.Api.Configuration.Extensions;

internal static class ApplicationBuilderExtensions
{
    internal static IApplicationBuilder UseCustomProblemDetails(this IApplicationBuilder app)
    {
        return app.UseMiddleware<ExceptionHandlerMiddleware>();
    }

    internal static IApplicationBuilder UseSwaggerDoc(this IApplicationBuilder app)
    {
        return app
            .UseSwagger()
            .UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Thread API V1"));
    }
}