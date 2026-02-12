using Domain.Entities;

namespace Application.Data.Repository;

public interface IUsersRepository : IBaseRepository<User>
{
    Task<bool> ExistsByUsername(string username, CancellationToken cancellationToken);
    Task<List<User>> SearchByUsername(string username, CancellationToken cancellationToken);
}