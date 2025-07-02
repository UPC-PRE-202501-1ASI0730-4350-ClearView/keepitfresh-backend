using KeepItFresh.Platform.API.Subscriptions.Domain.Model.Commands;
using KeepItFresh.Platform.API.Subscriptions.Domain.Model.Queries;
using KeepItFresh.Platform.API.Subscriptions.Domain.Services;
using KeepItFresh.Platform.API.Subscriptions.Interfaces.REST.Resources;
using KeepItFresh.Platform.API.Subscriptions.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace KeepItFresh.Platform.API.Subscriptions.Interfaces.REST.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
[SwaggerTag("Manage user subscriptions")]

public class SubscriptionsController : ControllerBase
{
    private readonly ISubscriptionCommandService _commandService;
    private readonly ISubscriptionQueryService _queryService;

    public SubscriptionsController(ISubscriptionCommandService commandService, ISubscriptionQueryService queryService)
    {
        _commandService = commandService;
        _queryService = queryService;
    }

    [HttpPost]
    [SwaggerOperation(Summary = "Register a new subscription")]
    public async Task<IActionResult> Create([FromBody] CreateSubscriptionResource resource)
    {
        var command = CreateSubscriptionCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await _commandService.Handle(command);
        if (result == null) return BadRequest("Error creating subscription");

        return CreatedAtAction(nameof(GetById), new { id = result.UserId }, SubscriptionResourceFromEntityAssembler.ToResourceFromEntity(result));
    }

    [HttpGet("{id:guid}")]
    [SwaggerOperation(Summary = "Get a subscription by user ID")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _queryService.Handle(new GetSubscriptionByUserIdQuery(id));
        return result == null ? NotFound() : Ok(SubscriptionResourceFromEntityAssembler.ToResourceFromEntity(result));
    }

    [HttpPut("{id:guid}")]
    [SwaggerOperation(Summary = "Update an existing subscription")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateSubscriptionResource resource)
    {
        if (id != resource.UserId) return BadRequest("ID does not match");

        var command = UpdateSubscriptionCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await _commandService.Handle(command);
        return result == null ? NotFound() : Ok(SubscriptionResourceFromEntityAssembler.ToResourceFromEntity(result));
    }
}
