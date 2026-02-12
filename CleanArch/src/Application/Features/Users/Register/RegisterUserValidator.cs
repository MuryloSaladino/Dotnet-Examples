using Application.Data.Repository;
using FluentValidation;

namespace Application.Features.Users.Register;

public class RegisterUserValidator : AbstractValidator<RegisterUserRequest>
{
    public RegisterUserValidator(IUsersRepository usersRepository)
    {
        RuleFor(u => u.Username)
            .NotEmpty()
            .MinimumLength(3)
            .MaximumLength(35)
            .WithMessage("Username must be between 3 and 35 characters length.");

        RuleFor(u => u.Username)
            .MustAsync(async (username, cancellationToken) =>
                !await usersRepository.ExistsByUsername(username, cancellationToken)
            )
            .WithMessage("Username already taken.");
    }
}