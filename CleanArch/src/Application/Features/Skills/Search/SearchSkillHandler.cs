using Application.Data.Repository;
using AutoMapper;
using MediatR;

namespace Application.Features.Skills.Search;

public sealed class FindSkillHandler(
    ISkillsRepository skillsRepository,
    IMapper mapper
) : IRequestHandler<FindSkillRequest, List<FindSkillResponse>>
{
    public async Task<List<FindSkillResponse>> Handle(
        FindSkillRequest request, CancellationToken cancellationToken)
    {
        var skills = await skillsRepository.SearchByName(request.Name, cancellationToken);

        return mapper.Map<List<FindSkillResponse>>(skills);
    }
}