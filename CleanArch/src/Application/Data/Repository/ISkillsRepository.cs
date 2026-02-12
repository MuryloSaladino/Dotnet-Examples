using Domain.Entities;

namespace Application.Data.Repository;

public interface ISkillsRepository : IBaseRepository<Skill>
{
    Task<List<Skill>> SearchByName(string name, CancellationToken cancellationToken);
}