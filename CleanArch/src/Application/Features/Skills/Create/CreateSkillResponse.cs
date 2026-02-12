namespace Application.Features.Skills.Create;

public sealed record CreateSkillResponse(
    Guid Id,
    string Name,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    DateTime? DeletedAt
);