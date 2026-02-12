using System.Text.Json.Serialization;
using dotenv.net;
using Presentation.Pipeline.Cors;
using Presentation.Pipeline.Handlers;
using Application;
using Infrastructure.Persistence.Context;
using Infrastructure;

DotEnv.Load(options: new DotEnvOptions(envFilePaths: ["../../.env"]));

var builder = WebApplication.CreateBuilder(args);

// LAYERS CONFIG
builder.Services.ConfigureApplication();
builder.Services.ConfigureInfrastructure();

// CORS
builder.Services.ConfigureCorsPolicy(builder.Configuration);

// CONTROLLERS AND OPTIONS
builder.Services.AddControllers().AddJsonOptions(op =>
{
    op.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    op.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

// SWAGGER
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

var serviceScope = app.Services.CreateScope();
var dataContext = serviceScope.ServiceProvider.GetService<SkillsContext>()
    ?? throw new InvalidOperationException("Failed to resolve SkillsContext from service provider.");

await dataContext.Database.EnsureCreatedAsync();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();
app.UseErrorHandler();
app.MapControllers();
app.Run();
