using AutoMapper;
using Domain.Entities;

namespace Application.Features.Skills.Search;

public sealed class FindSkillMapper : Profile
{
    public FindSkillMapper()
    {
        CreateMap<Skill, FindSkillResponse>();
    }
}