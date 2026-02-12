using Application.Data;
using Application.Data.Repository;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Skills.Assign;

public sealed class AssignSkillHandler(
    IUserSkillsRepository userSkillsRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper
) : IRequestHandler<AssignSkillRequest, AssignSkillResponse>
{
    public async Task<AssignSkillResponse> Handle(
        AssignSkillRequest request, CancellationToken cancellationToken)
    {
        var userSkill = mapper.Map<UserSkill>(request);

        userSkillsRepository.Create(userSkill);

        await unitOfWork.Save(cancellationToken);

        return mapper.Map<AssignSkillResponse>(userSkill);
    }
}