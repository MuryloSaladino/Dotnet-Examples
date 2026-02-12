using Application.Features.Users.Register;
using Application.Features.Users.Search;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Presentation.Constants;

namespace Presentation.Controllers;

[ApiController, Route(APIRoutes.Users)]
public class UsersController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<RegisterUserResponse>> Register(
        RegisterUserRequest request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(request, cancellationToken);
        return Created(APIRoutes.Users, response);
    }

    [HttpGet]
    public async Task<ActionResult<List<SearchUserResponse>>> Search(
        [FromQuery] string? username, CancellationToken cancellationToken)
    {
        var request = new SearchUserRequest(username);
        var response = await mediator.Send(request, cancellationToken);
        return Ok(response);
    }
}