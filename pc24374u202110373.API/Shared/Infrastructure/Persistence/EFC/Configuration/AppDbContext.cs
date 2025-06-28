using Microsoft.EntityFrameworkCore;
using pc24374u202110373.API.Assessment.Domain.Model.Aggregates;
using pc24374u202110373.API.Assessment.Domain.Model.ValueObjects;
using pc24374u202110373.API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using EntityFrameworkCore.CreatedUpdatedDate.Contracts;

namespace pc24374u202110373.API.Shared.Infrastructure.Persistence.EFC.Configuration;

/// <summary>
/// Application Database Context
/// </summary>
/// <remarks>
/// Juan Diego Mondoñedo Rodriguez
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
            // Configure primary key
            entity.HasKey(e => e.AssessmentOrderId);

            // Configure AssessmentOrderId value object
            entity.Property(e => e.AssessmentOrderId)
                .HasConversion(
                    v => v.Value,
                    v => new CognitiveAssessmentOrderId(v))
                .HasColumnName("id");

            // Configure PatientId value object
            entity.Property(e => e.PatientId)
                .HasConversion(
                    v => v.Value,
                    v => new PatientId(v))
                .HasColumnName("patient_id");

            // Configure other properties
            entity.Property(e => e.SessionCount)
                .IsRequired()
                .HasColumnName("session_count");

            entity.Property(e => e.RequestedAt)
                .IsRequired()
                .HasColumnName("requested_at");

            entity.Property(e => e.AssessmentStatus)
                .IsRequired()
                .HasConversion<string>()
                .HasColumnName("assessment_status");

            // Configure CognitiveCriteria owned entity using Fluent API
            entity.OwnsOne(e => e.CognitiveCriteria, cognitiveCriteria =>
            {
                cognitiveCriteria.Property(c => c.AttentionThreshold)
                    .IsRequired()
                    .HasColumnName("attention_threshold");
                cognitiveCriteria.Property(c => c.MemoryThreshold)
                    .IsRequired()
                    .HasColumnName("memory_threshold");
                cognitiveCriteria.Property(c => c.ProcessingSpeedThreshold)
                    .IsRequired()
                    .HasColumnName("processing_speed_threshold");
            });

            // Configure audit properties
            entity.Property(e => e.CreatedDate).HasColumnName("created_at");
            entity.Property(e => e.UpdatedDate).HasColumnName("updated_at");
        });

        builder.UseSnakeCaseNamingConvention();
    }

    /// <summary>
    /// Complete the unit of work by saving changes
    /// </summary>
    /// <returns>Task representing the asynchronous operation</returns>
    public async Task CompleteAsync()
    {
        await SaveChangesAsync();
    }
}
