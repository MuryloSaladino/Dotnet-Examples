namespace Application.Contracts;

public interface IPasswordHasher
{
    string Hash(string password);
    bool Compare(string hashed, string password);
}