using AutoMapper;
using Domain.Entities;

namespace Application.Features.Skills.Search;

public sealed class SearchSkillMapper : Profile
{
    public SearchSkillMapper()
    {
        CreateMap<Skill, SearchSkillResponse>();
    }
}