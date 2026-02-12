using FluentValidation;

namespace Application.Features.Skills.Assign;

public sealed class AssignSkillValidator : AbstractValidator<AssignSkillRequest>
{
    public AssignSkillValidator()
    {
        RuleFor(request => request.SkillId)
            .NotEmpty();

        RuleFor(request => request.SkillId)
            .NotEmpty();

        RuleFor(request => request.Level)
            .NotEmpty();
    }
}