using MediatR;

namespace Application.Features.Skills.Create;

public sealed record CreateSkillRequest(
    string Name
) : IRequest<CreateSkillResponse>;