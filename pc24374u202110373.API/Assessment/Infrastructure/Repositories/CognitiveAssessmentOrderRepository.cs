using Microsoft.EntityFrameworkCore;
using pc24374u202110373.API.Assessment.Domain.Model.Aggregates;
using pc24374u202110373.API.Assessment.Domain.Repositories;
using pc24374u202110373.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using pc24374u202110373.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace pc24374u202110373.API.Assessment.Infrastructure.Repositories;

/// <summary>
/// Cognitive Assessment Order Repository Implementation
/// </summary>
/// <remarks>
/// This class implements the cognitive assessment order repository operations.
/// </remarks>
/// <param name="context">The application database context</param>
public class CognitiveAssessmentOrderRepository(AppDbContext context)
    : BaseRepository<CognitiveAssessmentOrder>(context), ICognitiveAssessmentOrderRepository
{
    /// <inheritdoc />
    public async Task<CognitiveAssessmentOrder?> FindByAssessmentOrderIdAsync(Guid assessmentOrderId)
    {
        return await Context.Set<CognitiveAssessmentOrder>()
            .FirstOrDefaultAsync(cao => cao.AssessmentOrderId.Value == assessmentOrderId);
    }
}
