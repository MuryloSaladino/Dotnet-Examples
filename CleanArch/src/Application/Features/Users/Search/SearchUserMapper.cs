using AutoMapper;
using Domain.Entities;

namespace Application.Features.Users.Search;

public sealed class SearchUserMapper : Profile
{
    public SearchUserMapper()
    {
        CreateMap<User, SearchUserResponse>();
    }
}