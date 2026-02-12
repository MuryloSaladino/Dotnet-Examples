using Application.Data.Repository;
using Domain.Entities;
using MediatR;

namespace Application.Features.Skills.Search;

public sealed class FindSkillHandler(
    ISkillsRepository skillsRepository
) : IRequestHandler<SearchSkillRequest, List<Skill>>
{
    public async Task<List<Skill>> Handle(
        SearchSkillRequest request, CancellationToken cancellationToken)
    {
        return await skillsRepository.SearchByName(request.Name, cancellationToken);
    }
}