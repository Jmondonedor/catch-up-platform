using pc24374u202110373.API.Assessment.Domain.Model.Commands;
using pc24374u202110373.API.Assessment.Domain.Model.ValueObjects;
using pc24374u202110373.API.Assessment.Interfaces.REST.Resources;

namespace pc24374u202110373.API.Assessment.Interfaces.REST.Transform;

/// <summary>
/// Create Cognitive Assessment Order Command From Resource Assembler
/// </summary>
/// <remarks>
/// This assembler transforms create cognitive assessment order resources into commands.
/// </remarks>
public static class CreateCognitiveAssessmentOrderCommandFromResourceAssembler
{
    /// <summary>
    /// Transform a create cognitive assessment order resource to a command
    /// </summary>
    /// <param name="resource">The create cognitive assessment order resource</param>
    /// <returns>The create cognitive assessment order command</returns>
    public static CreateCognitiveAssessmentOrderCommand ToCommandFromResource(
        this CreateCognitiveAssessmentOrderResource resource)
    {
        var cognitiveCriteria = new CognitiveCriteria(
            resource.AttentionThreshold,
            resource.MemoryThreshold,
            resource.ProcessingSpeedThreshold
        );

        return new CreateCognitiveAssessmentOrderCommand(
            resource.PatientId,
            resource.SessionCount,
            resource.RequestedAt,
            resource.AssessmentStatus,
            cognitiveCriteria
        );
    }
}
