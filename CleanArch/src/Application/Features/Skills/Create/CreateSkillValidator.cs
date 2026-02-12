using Application.Data.Repository;
using FluentValidation;

namespace Application.Features.Skills.Create;

public sealed class CreateSkillValidator : AbstractValidator<CreateSkillRequest>
{
    public CreateSkillValidator(ISkillsRepository skillsRepository)
    {
        RuleFor(request => request.Name)
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(25)
            .MustAsync(async (name, cancellationToken) =>
                await skillsRepository.ExistsByName(name, cancellationToken)
            ); ;
    }
}