namespace pc24374u202110373.API.Assessment.Domain.Model.ValueObjects;

/// <summary>
/// Cognitive Assessment Order Identifier Value Object
/// </summary>
/// <remarks>
/// Juan Diego Mondoñedo Rodriguez
/// </remarks>
public record CognitiveAssessmentOrderId
{
    public Guid Value { get; }

    public CognitiveAssessmentOrderId()
    {
        Value = Guid.NewGuid();
    }

    public CognitiveAssessmentOrderId(Guid value)
    {
        if (value == Guid.Empty)
            throw new ArgumentException("CognitiveAssessmentOrderId cannot be empty");
        Value = value;
    }

    public static implicit operator Guid(CognitiveAssessmentOrderId id) => id.Value;
    public static implicit operator CognitiveAssessmentOrderId(Guid value) => new(value);

    public override string ToString() => Value.ToString();
}
