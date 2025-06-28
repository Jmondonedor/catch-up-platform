using pc24374u202110373.API.Assessment.Domain.Model.Aggregates;
using pc24374u202110373.API.Assessment.Domain.Model.Queries;
using pc24374u202110373.API.Assessment.Domain.Repositories;
using pc24374u202110373.API.Assessment.Domain.Services;

namespace pc24374u202110373.API.Assessment.Application.Internal.QueryServices;

/// <summary>
/// Cognitive Assessment Order Query Service Implementation
/// </summary>
/// <remarks>
/// This class implements the cognitive assessment order query service operations.
/// </remarks>
/// <param name="cognitiveAssessmentOrderRepository">The cognitive assessment order repository</param>
public class CognitiveAssessmentOrderQueryService(
    ICognitiveAssessmentOrderRepository cognitiveAssessmentOrderRepository) : ICognitiveAssessmentOrderQueryService
{
    /// <inheritdoc />
    public async Task<CognitiveAssessmentOrder?> Handle(GetCognitiveAssessmentOrderByIdQuery query)
    {
        return await cognitiveAssessmentOrderRepository.FindByAssessmentOrderIdAsync(query.AssessmentOrderId);
    }
}
