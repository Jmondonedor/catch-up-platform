using pc24374u202110373.API.Assessment.Domain.Model.Aggregates;
using pc24374u202110373.API.Shared.Domain.Repositories;

namespace pc24374u202110373.API.Assessment.Domain.Repositories;

/// <summary>
/// Cognitive Assessment Order Repository Interface
/// </summary>
/// <remarks>
/// Juan Diego Mondoñedo Rodriguez
/// </remarks>
public interface ICognitiveAssessmentOrderRepository : IBaseRepository<CognitiveAssessmentOrder>
{
    /// <summary>
    /// Find a cognitive assessment order by its identifier
    /// </summary>
    /// <param name="assessmentOrderId">The assessment order identifier</param>
    /// <returns>The cognitive assessment order if found, null otherwise</returns>
    Task<CognitiveAssessmentOrder?> FindByAssessmentOrderIdAsync(Guid assessmentOrderId);
}
