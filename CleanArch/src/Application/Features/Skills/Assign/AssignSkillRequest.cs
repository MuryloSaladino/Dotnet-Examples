using Domain.Enums;
using MediatR;

namespace Application.Features.Skills.Assign;

public sealed record AssignSkillRequest(
    Guid SkillId,
    Guid UserId,
    SkillLevel Level
) : IRequest<AssignSkillResponse>;