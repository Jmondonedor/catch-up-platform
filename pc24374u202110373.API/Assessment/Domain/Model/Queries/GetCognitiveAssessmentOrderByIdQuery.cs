using pc24374u202110373.API.Assessment.Domain.Model.ValueObjects;

namespace pc24374u202110373.API.Assessment.Domain.Model.Queries;

/// <summary>
/// Query to get a cognitive assessment order by its identifier
/// </summary>
/// <remarks>
/// This query retrieves a cognitive assessment order using its unique identifier.
/// </remarks>
/// <param name="AssessmentOrderId">The cognitive assessment order identifier</param>
public record GetCognitiveAssessmentOrderByIdQuery(Guid AssessmentOrderId);
