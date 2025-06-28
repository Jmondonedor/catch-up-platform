using System.ComponentModel.DataAnnotations.Schema;
using EntityFrameworkCore.CreatedUpdatedDate.Contracts;

namespace pc24374u202110373.API.Assessment.Domain.Model.Aggregates;

/// <summary>
/// Cognitive Assessment Order Aggregate with Audit Properties
/// </summary>
/// <remarks>
/// This partial class adds audit trail capabilities to the CognitiveAssessmentOrder aggregate.
/// </remarks>
public partial class CognitiveAssessmentOrder : IEntityWithCreatedUpdatedDate
{
    [Column("CreatedAt")]
    public DateTimeOffset? CreatedDate { get; set; }

    [Column("UpdatedAt")]
    public DateTimeOffset? UpdatedDate { get; set; }
}
