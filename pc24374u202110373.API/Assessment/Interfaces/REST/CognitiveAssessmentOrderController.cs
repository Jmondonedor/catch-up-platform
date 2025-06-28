using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using pc24374u202110373.API.Assessment.Domain.Services;
using pc24374u202110373.API.Assessment.Interfaces.REST.Resources;
using pc24374u202110373.API.Assessment.Interfaces.REST.Transform;

namespace pc24374u202110373.API.Assessment.Interfaces.REST;

/// <summary>
/// Cognitive Assessment Order REST Controller
/// </summary>
/// <remarks>
/// Juan Diego Mondoñedo Rodriguez
/// </remarks>
/// <param name="cognitiveAssessmentOrderCommandService">The cognitive assessment order command service</param>
/// <param name="cognitiveAssessmentOrderQueryService">The cognitive assessment order query service</param>
[ApiController]
[Route("api/v1/cognitive-assessments")]
[Produces(MediaTypeNames.Application.Json)]
[Tags("Cognitive Assessment Orders API")]
public class CognitiveAssessmentOrderController(
    ICognitiveAssessmentOrderCommandService cognitiveAssessmentOrderCommandService,
    ICognitiveAssessmentOrderQueryService cognitiveAssessmentOrderQueryService) : ControllerBase
{
    /// <summary>
    /// Create a new cognitive assessment order
    /// </summary>
    /// <param name="resource">The create cognitive assessment order resource</param>
    /// <returns>The created cognitive assessment order</returns>
    /// <response code="201">Returns the newly created cognitive assessment order</response>
    /// <response code="400">If the request data is invalid according to business rules</response>
    /// <response code="500">If there was an internal server error</response>
    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a cognitive assessment order",
        Description = "Creates a new cognitive assessment order with the provided information",
        OperationId = "CreateCognitiveAssessmentOrder"
    )]
    [ProducesResponseType(typeof(CognitiveAssessmentOrderResource), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateCognitiveAssessmentOrder(
        [FromBody] CreateCognitiveAssessmentOrderResource resource)
    {
        try
        {
            var createCommand = resource.ToCommandFromResource();
            var result = await cognitiveAssessmentOrderCommandService.Handle(createCommand);

            if (result == null)
                return BadRequest(new ProblemDetails
                {
                    Title = "Creation Failed",
                    Detail = "Unable to create cognitive assessment order",
                    Status = StatusCodes.Status400BadRequest
                });

            var createdResource = CognitiveAssessmentOrderResourceFromEntityAssembler.ToResourceFromEntity(result);
            return CreatedAtAction(
                nameof(GetCognitiveAssessmentOrderById),
                new { id = result.AssessmentOrderId.Value },
                createdResource);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new ProblemDetails
            {
                Title = "Validation Error",
                Detail = ex.Message,
                Status = StatusCodes.Status400BadRequest
            });
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new ProblemDetails
            {
                Title = "Internal Server Error",
                Detail = ex.Message,
                Status = StatusCodes.Status500InternalServerError
            });
        }
    }

    /// <summary>
    /// Get a cognitive assessment order by its identifier
    /// </summary>
    /// <param name="id">The cognitive assessment order identifier (GUID)</param>
    /// <returns>The cognitive assessment order</returns>
    /// <response code="200">Returns the requested cognitive assessment order</response>
    /// <response code="404">If the order with the specified ID was not found</response>
    [HttpGet("{id:guid}")]
    [SwaggerOperation(
        Summary = "Get a cognitive assessment order by ID",
        Description = "Retrieves a cognitive assessment order by its unique identifier",
        OperationId = "GetCognitiveAssessmentOrderById"
    )]
    [ProducesResponseType(typeof(CognitiveAssessmentOrderResource), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetCognitiveAssessmentOrderById([FromRoute] Guid id)
    {
        var query = new GetCognitiveAssessmentOrderByIdQuery(id);
        var result = await cognitiveAssessmentOrderQueryService.Handle(query);

        if (result == null)
            return NotFound();

        var resource = CognitiveAssessmentOrderResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resource);
    }
}
