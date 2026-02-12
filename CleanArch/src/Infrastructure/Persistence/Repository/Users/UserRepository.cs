using Domain.Entities;
using Infrastructure.Persistence.Context;
using Application.Data.Repository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repository.Users;

public class UserRepository(SkillsContext context)
    : BaseRepository<User>(context), IUsersRepository
{
    public Task<bool> ExistsById(Guid id, CancellationToken cancellationToken)
        => Context.Set<User>()
            .Where(user => user.Id == id)
            .AnyAsync(cancellationToken);

    public Task<bool> ExistsByUsername(string name, CancellationToken cancellationToken)
        => Context.Set<User>()
            .Where(user => user.Username == name)
            .AnyAsync(cancellationToken);

    public Task<List<User>> SearchByUsername(string filter, CancellationToken cancellationToken)
        => Context.Set<User>()
            .Where(user => EF.Functions.ILike($"%{filter}%", user.Username))
            .ToListAsync(cancellationToken);
}