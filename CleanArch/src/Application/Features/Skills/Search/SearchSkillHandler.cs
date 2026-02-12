using Application.Data.Repository;
using AutoMapper;
using MediatR;

namespace Application.Features.Skills.Search;

public sealed class FindSkillHandler(
    ISkillsRepository skillsRepository,
    IMapper mapper
) : IRequestHandler<SearchSkillRequest, List<SearchSkillResponse>>
{
    public async Task<List<SearchSkillResponse>> Handle(
        SearchSkillRequest request, CancellationToken cancellationToken)
    {
        var skills = await skillsRepository.SearchByName(request.Name ?? "", cancellationToken);
        return mapper.Map<List<SearchSkillResponse>>(skills);
    }
}