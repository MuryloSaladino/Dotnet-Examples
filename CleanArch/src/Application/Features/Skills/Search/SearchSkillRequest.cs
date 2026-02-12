using MediatR;

namespace Application.Features.Skills.Search;

public sealed record FindSkillRequest(
    string Name
) : IRequest<List<FindSkillResponse>>;