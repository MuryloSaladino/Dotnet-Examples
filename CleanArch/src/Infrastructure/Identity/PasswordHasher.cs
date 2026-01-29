using Application.Contracts;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity;

public class PasswordHasher : IPasswordHasher
{
    private readonly PasswordHasher<object> _hasher = new();

    public string Hash(string password)
        => _hasher.HashPassword(null!, password);

    public bool Compare(string hashed, string password)
        => _hasher.VerifyHashedPassword(null!, hashed, password) == PasswordVerificationResult.Success;
}
