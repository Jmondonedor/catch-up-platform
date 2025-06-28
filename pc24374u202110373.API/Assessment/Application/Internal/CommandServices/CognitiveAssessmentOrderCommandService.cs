using pc24374u202110373.API.Assessment.Domain.Model.Aggregates;
using pc24374u202110373.API.Assessment.Domain.Model.Commands;
using pc24374u202110373.API.Assessment.Domain.Repositories;
using pc24374u202110373.API.Assessment.Domain.Services;
using pc24374u202110373.API.Shared.Domain.Repositories;

namespace pc24374u202110373.API.Assessment.Application.Internal.CommandServices;

/// <summary>
/// Cognitive Assessment Order Command Service Implementation
/// </summary>
/// <remarks>
/// This class implements the cognitive assessment order command service operations.
/// </remarks>
/// <param name="cognitiveAssessmentOrderRepository">The cognitive assessment order repository</param>
/// <param name="unitOfWork">The unit of work</param>
public class CognitiveAssessmentOrderCommandService(
    ICognitiveAssessmentOrderRepository cognitiveAssessmentOrderRepository,
    IUnitOfWork unitOfWork) : ICognitiveAssessmentOrderCommandService
{
    /// <inheritdoc />
    public async Task<CognitiveAssessmentOrder?> Handle(CreateCognitiveAssessmentOrderCommand command)
    {
        try
        {
            var cognitiveAssessmentOrder = new CognitiveAssessmentOrder(command);
            await cognitiveAssessmentOrderRepository.AddAsync(cognitiveAssessmentOrder);
            await unitOfWork.CompleteAsync();
            return cognitiveAssessmentOrder;
        }
        catch (Exception)
        {
            return null;
        }
    }
}
