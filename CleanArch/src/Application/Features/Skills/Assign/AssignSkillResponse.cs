using Domain.Enums;

namespace Application.Features.Skills.Assign;

public sealed record AssignSkillResponse(
    Guid UserId,
    Guid SkillId,
    SkillLevel Level,
    string SkillName
);