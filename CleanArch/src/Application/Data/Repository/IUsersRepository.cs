using Domain.Entities;

namespace Application.Data.Repository;

public interface IUsersRepository : IBaseRepository<User>
{
    Task<User?> FindByUsername(string username, CancellationToken cancellationToken);
    Task<List<User>> FindAndFilter(string filter, CancellationToken cancellationToken);
}