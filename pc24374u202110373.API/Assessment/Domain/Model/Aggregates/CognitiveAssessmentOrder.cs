using pc24374u202110373.API.Assessment.Domain.Model.Commands;
using pc24374u202110373.API.Assessment.Domain.Model.ValueObjects;

namespace pc24374u202110373.API.Assessment.Domain.Model.Aggregates;

/// <summary>
/// Cognitive Assessment Order Aggregate Root
/// </summary>
/// <remarks>
/// Juan Diego Mondoñedo Rodriguez
/// </remarks>
public partial class CognitiveAssessmentOrder
{
    protected CognitiveAssessmentOrder()
    {
        AssessmentOrderId = new CognitiveAssessmentOrderId();
        PatientId = new PatientId(1);
        SessionCount = 1;
        RequestedAt = DateTime.UtcNow;
        AssessmentStatus = EAssessmentStatus.Pending;
        CognitiveCriteria = new CognitiveCriteria(1.0, 1.0, 1.0);
    }

    /// <summary>
    /// Constructor for the CognitiveAssessmentOrder aggregate.
    /// </summary>
    /// <remarks>
    /// This constructor validates all business rules and creates a new cognitive assessment order.
    /// </remarks>
    /// <param name="command">The CreateCognitiveAssessmentOrderCommand</param>
    /// <exception cref="ArgumentException">Thrown when business rules are violated</exception>
    public CognitiveAssessmentOrder(CreateCognitiveAssessmentOrderCommand command)
    {
        // Validate business rules
        if (command.SessionCount <= 0)
            throw new ArgumentException("SessionCount must be greater than zero");

        if (command.RequestedAt > DateTime.UtcNow)
            throw new ArgumentException("RequestedAt cannot be a future date");

        if (!Enum.IsDefined(typeof(EAssessmentStatus), command.AssessmentStatus))
            throw new ArgumentException("Invalid AssessmentStatus value");

        AssessmentOrderId = new CognitiveAssessmentOrderId();
        PatientId = new PatientId(command.PatientId);
        SessionCount = command.SessionCount;
        RequestedAt = command.RequestedAt;
        AssessmentStatus = command.AssessmentStatus;
        CognitiveCriteria = command.CognitiveCriteria;
    }

    public CognitiveAssessmentOrderId AssessmentOrderId { get; private set; }
    public PatientId PatientId { get; private set; }
    public int SessionCount { get; private set; }
    public DateTime RequestedAt { get; private set; }
    public EAssessmentStatus AssessmentStatus { get; private set; }
    public CognitiveCriteria CognitiveCriteria { get; private set; }
}
