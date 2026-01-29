using AutoMapper;
using MediatR;
using Domain.Entities;
using Application.Data.Repository;
using Application.Contracts;
using Application.Data;

namespace Application.Features.Users.Register;

public sealed class RegisterUserHandler(
    IUsersRepository userRepository,
    IPasswordHasher hasher,
    IUnitOfWork unitOfWork,
    IMapper mapper
) : IRequestHandler<RegisterUserRequest, RegisterUserResponse>
{
    public async Task<RegisterUserResponse> Handle(
        RegisterUserRequest request, CancellationToken cancellationToken)
    {
        var user = mapper.Map<User>(request);
        user.Password = hasher.Hash(user.Password);

        userRepository.Create(user);
        await unitOfWork.Save(cancellationToken);

        return mapper.Map<RegisterUserResponse>(user);
    }
}