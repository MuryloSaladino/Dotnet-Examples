namespace Application.Features.Skills.Search;

public sealed record SearchSkillResponse(
    Guid Id,
    string Name,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    DateTime? DeletedAt
);