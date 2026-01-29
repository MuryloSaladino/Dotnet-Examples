using dotenv.net;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infrastructure.Persistence.Context;

public class SkillsDbContextFactory : IDesignTimeDbContextFactory<SkillsContext>
{
    public SkillsContext CreateDbContext(string[] args)
    {
        DotEnv.Load(options: new DotEnvOptions(envFilePaths: ["../../.env"]));

        var dbUrl = Environment.GetEnvironmentVariable("DatabaseUrl")
            ?? throw new ConfigurationException("Missing \"DatabaseUrl\" environment variable");

        var optionsBuilder = new DbContextOptionsBuilder<SkillsContext>();

        optionsBuilder.UseNpgsql(dbUrl);

        return new SkillsContext(optionsBuilder.Options);
    }
}