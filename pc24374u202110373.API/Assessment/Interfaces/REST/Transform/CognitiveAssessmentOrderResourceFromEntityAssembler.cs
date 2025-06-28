using pc24374u202110373.API.Assessment.Domain.Model.Aggregates;
using pc24374u202110373.API.Assessment.Interfaces.REST.Resources;

namespace pc24374u202110373.API.Assessment.Interfaces.REST.Transform;

/// <summary>
/// Cognitive Assessment Order Resource From Entity Assembler
/// </summary>
/// <remarks>
/// This assembler transforms cognitive assessment order entities into resources.
/// </remarks>
public static class CognitiveAssessmentOrderResourceFromEntityAssembler
{
    /// <summary>
    /// Transform a cognitive assessment order entity to a resource
    /// </summary>
    /// <param name="entity">The cognitive assessment order entity</param>
    /// <returns>The cognitive assessment order resource</returns>
    public static CognitiveAssessmentOrderResource ToResourceFromEntity(CognitiveAssessmentOrder entity)
    {
        return new CognitiveAssessmentOrderResource(
            entity.AssessmentOrderId.Value,
            entity.PatientId.Value,
            entity.SessionCount,
            entity.RequestedAt,
            entity.AssessmentStatus,
            entity.CognitiveCriteria.AttentionThreshold,
            entity.CognitiveCriteria.MemoryThreshold,
            entity.CognitiveCriteria.ProcessingSpeedThreshold
        );
    }
}
