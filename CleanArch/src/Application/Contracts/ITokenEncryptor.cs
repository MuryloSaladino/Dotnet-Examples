using Domain.Entities;

namespace Application.Contracts;

public interface ITokenEncryptor
{
    string GenerateUserToken(User user);
    Task<User> ExtractUserFromToken(string token);
}