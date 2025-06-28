using Microsoft.EntityFrameworkCore;
using pc24374u202110373.API.Assessment.Domain.Model.Aggregates;
using pc24374u202110373.API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using EntityFrameworkCore.CreatedUpdatedDate.Contracts;

namespace pc24374u202110373.API.Shared.Infrastructure.Persistence.EFC.Configuration;

/// <summary>
/// Application Database Context
/// </summary>
/// <remarks>
/// This class represents the database context for the NeuroLink HealthTech application.
/// </remarks>
/// <param name="options">The database context options</param>
public class AppDbContext(DbContextOptions options) : DbContext(options), IUnitOfWork
{
    /// <summary>
    /// Cognitive Assessment Orders DbSet
    /// </summary>
    public DbSet<CognitiveAssessmentOrder> CognitiveAssessmentOrders { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.AddCreatedUpdatedInterceptor();
        base.OnConfiguring(builder);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<CognitiveAssessmentOrder>(entity =>
        {
            entity.HasKey(e => e.AssessmentOrderId);

            entity.OwnsOne(e => e.CognitiveCriteria, cognitiveCriteria =>
            {
                cognitiveCriteria.Property(c => c.AttentionThreshold).HasColumnName("attention_threshold");
                cognitiveCriteria.Property(c => c.MemoryThreshold).HasColumnName("memory_threshold");
                cognitiveCriteria.Property(c => c.ProcessingSpeedThreshold).HasColumnName("processing_speed_threshold");
            });

            entity.Property(e => e.CreatedDate).HasColumnName("created_at");
            entity.Property(e => e.UpdatedDate).HasColumnName("updated_at");
        });

        builder.UseSnakeCaseNamingConvention();
    }
}
