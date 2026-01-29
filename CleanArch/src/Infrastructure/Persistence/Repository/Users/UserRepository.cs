using Domain.Entities;
using Infrastructure.Persistence.Context;
using Application.Data.Repository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repository.Users;

public class UserRepository(SkillsContext context)
    : BaseRepository<User>(context), IUsersRepository
{
    public Task<User?> FindByUsername(string username, CancellationToken cancellationToken)
        => Context.Set<User>()
            .Where(user => user.Username == username)
            .FirstOrDefaultAsync(cancellationToken);
}