namespace Thread.BuildingBlocks.Infrastructure.Model;

public sealed class HostEnvironment
{
    private static readonly string HostUriGlobalVariableName = "API_URI";
    private static readonly string EnvTypeGlobalVariableName = "ASPNETCORE_ENVIRONMENT";

    public static readonly string Uri = System.Environment.GetEnvironmentVariable(HostUriGlobalVariableName)!;
    public static readonly string EnvironmentType = System.Environment.GetEnvironmentVariable(EnvTypeGlobalVariableName)!;

    public static readonly string Development = nameof(Development);
    public static readonly string Production = nameof(Production);
    public static readonly string Test = nameof(Test);

    public static bool IsDevelopment() => String.Equals(EnvironmentType, Development);
    public static bool IsProduction() => String.Equals(EnvironmentType, Production);
    public static bool IsTest() => String.Equals(EnvironmentType, Test);
}