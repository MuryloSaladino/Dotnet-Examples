using Application.Data;
using Application.Data.Repository;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Skills.Create;

public sealed class CreateSkillHandler(
    ISkillsRepository skillsRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper
) : IRequestHandler<CreateSkillRequest, Skill>
{
    public async Task<Skill> Handle(
        CreateSkillRequest request, CancellationToken cancellationToken)
    {
        var skill = mapper.Map<Skill>(request);

        skillsRepository.Create(skill);

        await unitOfWork.Save(cancellationToken);

        return skill;
    }
}