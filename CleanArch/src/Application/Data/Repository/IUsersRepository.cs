using Domain.Entities;

namespace Application.Data.Repository;

public interface IUsersRepository : IBaseRepository<User>
{
    Task<bool> ExistsById(Guid id, CancellationToken cancellationToken);
    Task<bool> ExistsByUsername(string username, CancellationToken cancellationToken);
    Task<List<User>> SearchByUsername(string username, CancellationToken cancellationToken);
}