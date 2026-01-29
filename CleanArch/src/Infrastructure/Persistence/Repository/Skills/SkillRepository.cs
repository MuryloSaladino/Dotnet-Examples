using Domain.Entities;
using Infrastructure.Persistence.Context;
using Application.Data.Repository;

namespace Infrastructure.Persistence.Repository.Skills;

public class SkillRepository(SkillsContext context) 
    : BaseRepository<Skill>(context), ISkillsRepository;