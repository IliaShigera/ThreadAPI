namespace Thread.Api.Controllers;

[ApiController]
[AllowAnonymous]
[Route("api/registration")]
public class RegistrationController : ApiController
{
    private readonly IUserAccessModule _userAccessModule;

    public RegistrationController(IUserAccessModule userAccessModule)
    {
        _userAccessModule = userAccessModule;
    }

    [HttpPost]
    public async Task<ActionResult> RegisterNewUserAsync(RegisterUserRequest request, CancellationToken cancellationToken)
    {
        await _userAccessModule.RegisterNewUserAsync(request.Email, request.Password, cancellationToken);
        return Ok();
    }

    [HttpPatch("confirm/{confirmationToken}")]
    public async Task<ActionResult> ConfirmRegistrationAsync([FromRoute] string confirmationToken, CancellationToken cancellationToken)
    {
        await _userAccessModule.ConfirmRegistrationAsync(confirmationToken, cancellationToken);
        return Ok();
    }
}