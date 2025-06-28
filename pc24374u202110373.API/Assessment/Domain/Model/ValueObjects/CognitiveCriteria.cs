namespace pc24374u202110373.API.Assessment.Domain.Model.ValueObjects;

/// <summary>
/// Cognitive Criteria Value Object
/// </summary>
/// <remarks>
/// This value object represents the cognitive criteria thresholds for an assessment.
/// All threshold values must be greater than zero.
/// </remarks>
public record CognitiveCriteria
{
    public double AttentionThreshold { get; }
    public double MemoryThreshold { get; }
    public double ProcessingSpeedThreshold { get; }

    public CognitiveCriteria(double attentionThreshold, double memoryThreshold, double processingSpeedThreshold)
    {
        if (attentionThreshold <= 0)
            throw new ArgumentException("AttentionThreshold must be greater than zero");
        if (memoryThreshold <= 0)
            throw new ArgumentException("MemoryThreshold must be greater than zero");
        if (processingSpeedThreshold <= 0)
            throw new ArgumentException("ProcessingSpeedThreshold must be greater than zero");

        AttentionThreshold = attentionThreshold;
        MemoryThreshold = memoryThreshold;
        ProcessingSpeedThreshold = processingSpeedThreshold;
    }
}
