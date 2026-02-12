using Domain.Entities;
using Infrastructure.Persistence.Context;
using Application.Data.Repository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repository.Skills;

public class SkillRepository(SkillsContext context)
    : BaseRepository<Skill>(context), ISkillsRepository
{
    public Task<List<Skill>> SearchByName(string name, CancellationToken cancellationToken)
        => Context.Set<Skill>()
            .Where(skill => EF.Functions.ILike($"%{name}%", skill.Name))
            .ToListAsync(cancellationToken);
}