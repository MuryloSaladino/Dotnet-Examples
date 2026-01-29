using Microsoft.Extensions.DependencyInjection;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Persistence.Repository;
using Infrastructure.Persistence.Repository.Skills;
using Infrastructure.Persistence.Repository.Users;
using Infrastructure.Persistence.Repository.UserSkills;
using Application.Data;
using Application.Data.Repository;
using Application.Contracts;
using Infrastructure.Identity;

namespace Infrastructure;

public static class ServiceExtensions
{
    public static void ConfigureInfrastructure(this IServiceCollection services)
    {
        // PERSISTENCE
        services.AddDbContext<SkillsContext>((serviceProvider, options) =>
            options.UseNpgsql(Environment.GetEnvironmentVariable("DatabaseUrl")));

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<ISkillsRepository, SkillRepository>();
        services.AddScoped<IUsersRepository, UserRepository>();
        services.AddScoped<IUserSkillsRepository, UserSkillsRepository>();

        // IDENTITY
        services.AddScoped<IPasswordHasher, PasswordHasher>();
    }
}