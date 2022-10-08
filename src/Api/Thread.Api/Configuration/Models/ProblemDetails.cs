namespace Thread.Api.Configuration.Models;

internal sealed class ProblemDetails
{
    private ProblemDetails() { }

    internal ProblemDetails(string? title, string? details, int? code)
    {
        Title = title;
        Details = details;
        Code = code;
    }

    public string? Title { get; }
    public string? Details { get; }
    public int? Code { get; }
}