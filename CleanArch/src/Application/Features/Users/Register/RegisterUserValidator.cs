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
            .MustAsync(async (username, cancellationToken) =>
                await usersRepository.FindByUsername(username, cancellationToken) is null
            );

        RuleFor(u => u.Password)
            .NotEmpty()
            .MinimumLength(8);
    }
}