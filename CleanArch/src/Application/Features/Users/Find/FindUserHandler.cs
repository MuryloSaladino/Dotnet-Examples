using Application.Data.Repository;
using AutoMapper;
using MediatR;

namespace Application.Features.Users.Find;

public sealed class FindUserHandler(
    IUsersRepository usersRepository,
    IMapper mapper
) : IRequestHandler<FindUserRequest, List<FindUserResponse>>
{
    public async Task<List<FindUserResponse>> Handle(
        FindUserRequest request, CancellationToken cancellationToken)
    {
        var users = await usersRepository.FindAndFilter(request.Filter ?? "", cancellationToken);

        return mapper.Map<List<FindUserResponse>>(users);
    }
}