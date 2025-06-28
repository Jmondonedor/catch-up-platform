using pc24374u202110373.API.Assessment.Domain.Model.ValueObjects;

namespace pc24374u202110373.API.Assessment.Domain.Model.Queries;

/// <summary>
/// Query to get a cognitive assessment order by its identifier
/// </summary>
/// <remarks>
/// Juan Diego Mondoñedo Rodriguez
/// </remarks>
/// <param name="AssessmentOrderId">The cognitive assessment order identifier</param>
public record GetCognitiveAssessmentOrderByIdQuery(Guid AssessmentOrderId);
