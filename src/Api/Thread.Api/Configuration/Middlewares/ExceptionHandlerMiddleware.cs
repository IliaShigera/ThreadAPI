using ProblemDetails = Thread.Api.Configuration.Models.ProblemDetails;

namespace Thread.Api.Configuration.Middlewares;

public sealed class ExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next.Invoke(context);
        }
        catch (Exception ex)
        {
            Log.Error($"Exception {ex.GetType().Name} was thrown. {ex.Message}");

            await HandleExceptionAsync(context, ex);

            Log.Information($"Exception {ex.GetType().Name} handled");
        }
    }

    private Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        var problemDetails = GetConcreteProblemDetails(ex);

        var response = JsonConvert.SerializeObject(problemDetails);

        context.Response.ContentType = "application/problem+json";
        context.Response.StatusCode = problemDetails.Code!.Value;

        return context.Response.WriteAsync(response);
    }

    private ProblemDetails GetConcreteProblemDetails(Exception ex) => ex switch
    {
        SpecNotFoundException e => new ProblemDetails(
            title: "Spec not found.",
            details: e.Details,
            code: StatusCodes.Status400BadRequest
        ),

        DomainRuleBrokenException e => new ProblemDetails(
            title: "Bad request",
            details: e.Details,
            code: StatusCodes.Status400BadRequest
        ),

        _ => new ProblemDetails(
            title: "Internal server error",
            details: ex.Message,
            code: StatusCodes.Status500InternalServerError
        )
    };
}