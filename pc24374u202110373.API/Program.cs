using pc24374u202110373.API.Assessment.Application.Internal.CommandServices;
using pc24374u202110373.API.Assessment.Application.Internal.QueryServices;
using pc24374u202110373.API.Assessment.Domain.Repositories;
using pc24374u202110373.API.Assessment.Domain.Services;
using pc24374u202110373.API.Assessment.Infrastructure.Repositories;
using pc24374u202110373.API.Shared.Domain.Repositories;
using pc24374u202110373.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using pc24374u202110373.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container

// Configure Lower Case URLs
builder.Services.AddRouting(options => options.LowercaseUrls = true);

// Configure Controllers
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = null; // Preserve exact property names
    });

// Add API Explorer and Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.EnableAnnotations();
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "NeuroLink HealthTech API",
        Version = "v1",
        Description = "API for managing cognitive assessment orders"
    });
});

// Add Database Connection
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Verify Database Connection String
if (connectionString is null)
    throw new Exception("Database connection string is not set.");

// Configure Database Context and Logging Levels
if (builder.Environment.IsDevelopment())
{
    builder.Services.AddDbContext<AppDbContext>(options =>
    {
        options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
            .LogTo(Console.WriteLine, LogLevel.Information)
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors();
    });
}
else if (builder.Environment.IsProduction())
{
    builder.Services.AddDbContext<AppDbContext>(options =>
    {
        options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
            .LogTo(Console.WriteLine, LogLevel.Error)
            .EnableDetailedErrors();
    });
}

// Configure Dependency Injection

// Shared Bounded Context Injection Configuration
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Assessment Bounded Context Injection Configuration
builder.Services.AddScoped<ICognitiveAssessmentOrderRepository, CognitiveAssessmentOrderRepository>();
builder.Services.AddScoped<ICognitiveAssessmentOrderCommandService, CognitiveAssessmentOrderCommandService>();
builder.Services.AddScoped<ICognitiveAssessmentOrderQueryService, CognitiveAssessmentOrderQueryService>();

var app = builder.Build();

// Apply Database Migrations and Ensure Database is Created
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.Migrate(); // Apply any pending migrations
}

// Configure Swagger UI
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "NeuroLink HealthTech API v1");
        options.RoutePrefix = string.Empty; // Set Swagger UI at the root
    });
}

// Configure the HTTP request pipeline
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
