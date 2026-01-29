using Domain.Entities;

namespace Application.Data.Repository;

public interface IUsersRepository : IBaseRepository<User>
{
    Task<User?> FindByUsername(string username, CancellationToken cancellationToken);
}