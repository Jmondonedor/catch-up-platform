using pc24374u202110373.API.Assessment.Domain.Model.ValueObjects;

namespace pc24374u202110373.API.Assessment.Interfaces.REST.Resources;

/// <summary>
/// Create Cognitive Assessment Order Resource
/// </summary>
/// <remarks>
/// This resource represents the data required to create a cognitive assessment order.
/// </remarks>
/// <param name="PatientId">The patient identifier</param>
/// <param name="SessionCount">The number of sessions</param>
/// <param name="RequestedAt">The date when the assessment was requested</param>
/// <param name="AssessmentStatus">The initial status of the assessment</param>
/// <param name="AttentionThreshold">The attention threshold</param>
/// <param name="MemoryThreshold">The memory threshold</param>
/// <param name="ProcessingSpeedThreshold">The processing speed threshold</param>
public record CreateCognitiveAssessmentOrderResource(
    long PatientId,
    int SessionCount,
    DateTime RequestedAt,
    EAssessmentStatus AssessmentStatus,
    double AttentionThreshold,
    double MemoryThreshold,
    double ProcessingSpeedThreshold
);
