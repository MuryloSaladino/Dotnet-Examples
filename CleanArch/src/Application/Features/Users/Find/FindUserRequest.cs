using MediatR;

namespace Application.Features.Users.Find;

public sealed record FindUserRequest(
    string? Filter
) : IRequest<List<FindUserResponse>>;