using Application.Contracts;
using Application.Data.Repository;
using MediatR;

namespace Application.Features.Auth.Login;

public sealed class LoginHandler(
    IUsersRepository usersRepository,
    IPasswordHasher passwordHasher,
    ITokenEncryptor tokenEncryptor
) : IRequestHandler<LoginRequest, LoginResponse>
{
    public async Task<LoginResponse> Handle(
        LoginRequest request, CancellationToken cancellationToken)
    {
        var user = await usersRepository.FindByUsername(request.Username, cancellationToken)
            ?? throw new InvalidCredentialsException();

        var matches = passwordHasher.Compare(user.Password, request.Password);

        if (!matches) throw new InvalidCredentialsException();

        var token = tokenEncryptor.GenerateUserToken(user);

        return new LoginResponse(token);
    }
}