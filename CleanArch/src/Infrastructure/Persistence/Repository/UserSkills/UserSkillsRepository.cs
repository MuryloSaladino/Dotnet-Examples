using Application.Data.Repository;
using Domain.Entities;
using Infrastructure.Persistence.Context;

namespace Infrastructure.Persistence.Repository.UserSkills;

public class UserSkillsRepository(SkillsContext context)
    : BaseRepository<UserSkill>(context), IUserSkillsRepository;