using pc24374u202110373.API.Assessment.Domain.Model.Aggregates;
using pc24374u202110373.API.Assessment.Domain.Model.Queries;

namespace pc24374u202110373.API.Assessment.Domain.Services;

/// <summary>
/// Cognitive Assessment Order Query Service Interface
/// </summary>
/// <remarks>
/// This interface defines the contract for cognitive assessment order query operations.
/// </remarks>
public interface ICognitiveAssessmentOrderQueryService
{
    /// <summary>
    /// Handle the get cognitive assessment order by id query
    /// </summary>
    /// <param name="query">The GetCognitiveAssessmentOrderByIdQuery</param>
    /// <returns>The cognitive assessment order if found, null otherwise</returns>
    Task<CognitiveAssessmentOrder?> Handle(GetCognitiveAssessmentOrderByIdQuery query);
}
