using AutoMapper;
using Domain.Entities;

namespace Application.Features.Skills.Assign;

public sealed class AssignSkillMapper : Profile
{
    public AssignSkillMapper()
    {
        CreateMap<AssignSkillRequest, UserSkill>();
        CreateMap<UserSkill, AssignSkillResponse>()
            .ForMember(
                dest => dest.SkillName,
                opt => opt.MapFrom(src => src.Skill.Name)
            );
    }
}