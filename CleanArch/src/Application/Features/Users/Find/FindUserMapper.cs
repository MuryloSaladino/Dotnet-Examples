using AutoMapper;
using Domain.Entities;

namespace Application.Features.Users.Find;

public sealed class FindUserMapper : Profile
{
    public FindUserMapper()
    {
        CreateMap<User, FindUserResponse>();
    }
}