namespace pc24374u202110373.API.Assessment.Domain.Model.ValueObjects;

/// <summary>
/// Patient Identifier Value Object
/// </summary>
/// <remarks>
/// Juan Diego Mondoñedo Rodriguez
/// </remarks>
public record PatientId
{
    public long Value { get; }

    public PatientId(long value)
    {
        if (value <= 0)
            throw new ArgumentException("PatientId must be greater than zero");
        Value = value;
    }

    public static implicit operator long(PatientId patientId) => patientId.Value;
    public static implicit operator PatientId(long value) => new(value);

    public override string ToString() => Value.ToString();
}
