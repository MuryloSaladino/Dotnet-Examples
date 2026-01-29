using AutoMapper;
using Domain.Entities;

namespace Application.Features.Users.Register;

public sealed class RegisterUserMapper : Profile
{
    public RegisterUserMapper()
    {
        CreateMap<RegisterUserRequest, User>();
        CreateMap<User, RegisterUserResponse>();
    }
}