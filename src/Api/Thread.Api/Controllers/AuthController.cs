namespace Thread.Api.Controllers;

[ApiController]
[AllowAnonymous]
[Route("auth")]
public class AuthController : ApiController
{
    private readonly IUserAccessModule _userAccessModule;

    public AuthController(IUserAccessModule userAccessModule)
    {
        _userAccessModule = userAccessModule;
    }

    [HttpGet]
    public async Task<ActionResult> GetNewAuthTokenAsync([FromQuery] GetAuthTokenRequest request, CancellationToken cancellationToken)
    {
        var result = await _userAccessModule.GetAuthTokenAsync(request.Email, request.Password, cancellationToken);

        return Ok(result);
    }
}