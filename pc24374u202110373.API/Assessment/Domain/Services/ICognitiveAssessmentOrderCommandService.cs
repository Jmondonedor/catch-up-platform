using pc24374u202110373.API.Assessment.Domain.Model.Aggregates;
using pc24374u202110373.API.Assessment.Domain.Model.Commands;

namespace pc24374u202110373.API.Assessment.Domain.Services;

/// <summary>
/// Cognitive Assessment Order Command Service Interface
/// </summary>
/// <remarks>
/// Juan Diego Mondoñedo Rodriguez
/// </remarks>
public interface ICognitiveAssessmentOrderCommandService
{
    /// <summary>
    /// Handle the create cognitive assessment order command
    /// </summary>
    /// <param name="command">The CreateCognitiveAssessmentOrderCommand</param>
    /// <returns>The created cognitive assessment order or null if creation failed</returns>
    Task<CognitiveAssessmentOrder?> Handle(CreateCognitiveAssessmentOrderCommand command);
}
