using Domain.Entities;

namespace Application.Data.Repository;

public interface ISkillsRepository : IBaseRepository<Skill>
{
    Task<bool> ExistsById(Guid id, CancellationToken cancellationToken);
    Task<bool> ExistsByName(string name, CancellationToken cancellationToken);
    Task<List<Skill>> SearchByName(string name, CancellationToken cancellationToken);
}