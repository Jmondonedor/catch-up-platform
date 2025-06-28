using pc24374u202110373.API.Assessment.Domain.Model.ValueObjects;

namespace pc24374u202110373.API.Assessment.Domain.Model.Commands;

/// <summary>
/// Command to create a cognitive assessment order
/// </summary>
/// <remarks>
/// Juan Diego Mondoñedo Rodriguez
/// </remarks>
/// <param name="PatientId">The patient identifier</param>
/// <param name="SessionCount">The number of sessions</param>
/// <param name="RequestedAt">The date when the assessment was requested</param>
/// <param name="AssessmentStatus">The initial status of the assessment</param>
/// <param name="CognitiveCriteria">The cognitive criteria for the assessment</param>
public record CreateCognitiveAssessmentOrderCommand(
    long PatientId,
    int SessionCount,
    DateTime RequestedAt,
    EAssessmentStatus AssessmentStatus,
    CognitiveCriteria CognitiveCriteria
);
