using Application.Data.Repository;
using FluentValidation;

namespace Application.Features.Skills.Assign;

public sealed class AssignSkillValidator : AbstractValidator<AssignSkillRequest>
{
    public AssignSkillValidator(ISkillsRepository skillsRepository)
    {
        RuleFor(request => request.SkillId)
            .NotEmpty();

        RuleFor(request => request.SkillId)
            .NotEmpty()
            .MustAsync(async (skillId, cancellationToken) =>
                await skillsRepository.ExistsById(skillId, cancellationToken)
            );

        RuleFor(request => request.Level)
            .NotEmpty();
    }
}