namespace Thread.Api.Controllers;

[ApiController]
[AllowAnonymous]
[Route("api/registration")]
public class RegistrationController : ControllerBase
{
    private readonly IUserAccessModule _userAccessModule;

    public RegistrationController(IUserAccessModule userAccessModule)
    {
        _userAccessModule = userAccessModule;
    }

    [HttpPost("")]
    public async Task<ActionResult> RegisterNewUserAsync(RegisterUserRequest request, CancellationToken cancellationToken)
    {
        await _userAccessModule.RegisterNewUserAsync(request.Email, request.Password, cancellationToken);

        return Ok();
    }

    [HttpPatch("{registrationId:guid}")]
    public async Task<ActionResult> ConfirmRegistrationAsync([FromRoute] Guid registrationId, CancellationToken cancellationToken)
    {
        await _userAccessModule.ConfirmRegistrationAsync(registrationId, cancellationToken);

        return Ok();
    }
}