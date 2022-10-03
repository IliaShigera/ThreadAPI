namespace Thread.Api.Models;

public class GetAuthTokenRequest
{
    public string Email { get;set; }
    public string Password { get; set; }
}