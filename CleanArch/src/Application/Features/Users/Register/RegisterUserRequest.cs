using MediatR;

namespace Application.Features.Users.Register;

public sealed record RegisterUserRequest(
    string Username
) : IRequest<RegisterUserResponse>;
