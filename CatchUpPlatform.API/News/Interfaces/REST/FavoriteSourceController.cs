using System.Net.Mime;
using CatchUpPlatform.API.News.Domain.Model.Queries;
using CatchUpPlatform.API.News.Domain.Services;
using CatchUpPlatform.API.News.Interfaces.REST.Resources;
using CatchUpPlatform.API.News.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CatchUpPlatform.API.News.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[Tags("Favorite Sources API")]
public class FavoriteSourceController(
    IFavoriteSourceCommandService favoriteSourceCommandService,
    IFavoriteSourceQueryService favoriteSourceQueryService
    ) : ControllerBase
{

    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a favorite source",
        Description = "Creates a favorite source with a given News API Key and Source ID",
        OperationId = "CreateFavoriteSource"
        )]
    [SwaggerResponse(201, "The favorite source was created successfully.")]
    [SwaggerResponse(400, "The favorite source was not created.")]
    public async Task<ActionResult> CreateFavoriteSource([FromBody] CreateFavoriteSourceResource resource)
    {
        var createFavoriteSourceCommand =
            CreateFavoriteSourceCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await favoriteSourceCommandService.Handle(createFavoriteSourceCommand);
        if (result is null) return BadRequest();
        return CreatedAtAction(nameof(GetFavoriteSourceById), new { id = result.Id },
            FavoriteSourceResourceFromEntityAssembler.ToResourceFromEntity(result));
    }

    [HttpGet("{id}")]
    [SwaggerOperation(
        Summary = "Gets a favorite source according to id",
        Description = "Gets a favorite source according to id",
        OperationId = "GetFavoriteSourceById"
    )]
    public async Task<ActionResult> GetFavoriteSourceById(int id)
    {
        var getFavoriteSourceByIdQuery = new GetFavoriteSourceByIdQuery(id);
        var result = await favoriteSourceQueryService.Handle(getFavoriteSourceByIdQuery);
        if (result is null) return NotFound();
        var resource = FavoriteSourceResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resource);
    }
    
}