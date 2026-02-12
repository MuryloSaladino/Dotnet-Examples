using AutoMapper;
using Domain.Entities;

namespace Application.Features.Skills.Create;

public sealed class CreateSkillMapper : Profile
{
    public CreateSkillMapper()
    {
        CreateMap<CreateSkillRequest, Skill>();
        CreateMap<Skill, CreateSkillResponse>();
    }
}