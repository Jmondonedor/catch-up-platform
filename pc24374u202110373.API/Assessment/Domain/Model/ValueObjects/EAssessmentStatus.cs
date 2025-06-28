namespace pc24374u202110373.API.Assessment.Domain.Model.ValueObjects;

/// <summary>
/// Assessment Status Enumeration
/// </summary>
/// <remarks>
/// This enumeration represents the possible states of a cognitive assessment order.
/// </remarks>
public enum EAssessmentStatus
{
    Pending,
    Scheduled,
    InProgress,
    Finalized,
    Cancelled
}
