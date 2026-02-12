using MediatR;

namespace Application.Features.Skills.Search;

public sealed record SearchSkillRequest(
    string? Name
) : IRequest<List<SearchSkillResponse>>;