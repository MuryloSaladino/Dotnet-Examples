using Application.Features.Skills.Assign;
using Application.Features.Skills.Create;
using Application.Features.Skills.Search;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Presentation.Constants;
using Presentation.Payloads;

namespace Presentation.Controllers;

[ApiController, Route(APIRoutes.Skills)]
public class SkillsController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<CreateSkillResponse>> Create(
        CreateSkillRequest request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(request, cancellationToken);
        return Created(APIRoutes.Skills, response);
    }

    [HttpGet]
    public async Task<ActionResult<List<SearchSkillResponse>>> Search(
        [FromQuery] string? name, CancellationToken cancellationToken)
    {
        var request = new SearchSkillRequest(name);
        var response = await mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpPut, Route("{skillId}/users/{userId}")]
    public async Task<ActionResult<AssignSkillResponse>> Assign(
        AssignSkillPayload body,
        Guid skillId,
        Guid userId,
        CancellationToken cancellationToken)
    {
        var request = new AssignSkillRequest(skillId, userId, body.Level);
        var response = await mediator.Send(request, cancellationToken);
        return Ok(response);
    }
}