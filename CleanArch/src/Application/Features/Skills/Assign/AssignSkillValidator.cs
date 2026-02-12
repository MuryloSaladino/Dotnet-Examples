using Application.Data.Repository;
using FluentValidation;

namespace Application.Features.Skills.Assign;

public sealed class AssignSkillValidator : AbstractValidator<AssignSkillRequest>
{
    public AssignSkillValidator(ISkillsRepository skillsRepository, IUsersRepository usersRepository)
    {
        RuleFor(request => request.UserId)
            .NotEmpty()
            .MustAsync(async (userId, cancellationToken) =>
                await usersRepository.ExistsById(userId, cancellationToken)
            )
            .WithMessage("Invalid user id.");

        RuleFor(request => request.SkillId)
            .NotEmpty()
            .MustAsync(async (skillId, cancellationToken) =>
                await skillsRepository.ExistsById(skillId, cancellationToken)
            )
            .WithMessage("Invalid skill id.");

        RuleFor(request => request.Level)
            .NotEmpty();
    }
}