using Application.Data.Repository;
using AutoMapper;
using MediatR;

namespace Application.Features.Users.Search;

public sealed class SearchUserHandler(
    IUsersRepository usersRepository,
    IMapper mapper
) : IRequestHandler<SearchUserRequest, List<SearchUserResponse>>
{
    public async Task<List<SearchUserResponse>> Handle(
        SearchUserRequest request, CancellationToken cancellationToken)
    {
        var users = await usersRepository.SearchByUsername(request.Filter ?? "", cancellationToken);

        return mapper.Map<List<SearchUserResponse>>(users);
    }
}