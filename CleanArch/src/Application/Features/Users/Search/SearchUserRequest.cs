using MediatR;

namespace Application.Features.Users.Search;

public sealed record SearchUserRequest(
    string? Filter
) : IRequest<List<SearchUserResponse>>;