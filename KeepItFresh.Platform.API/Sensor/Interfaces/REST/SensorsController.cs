using KeepItFresh.Platform.API.Sensor.Application.Internal.CommandServices;
using KeepItFresh.Platform.API.Sensor.Application.Internal.QueryServices;
using KeepItFresh.Platform.API.Sensor.Domain.Model.Commands;
using KeepItFresh.Platform.API.Sensor.Domain.Model.Queries;
using KeepItFresh.Platform.API.Sensor.Interfaces.REST.Resources;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace KeepItFresh.Platform.API.Sensor.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[SwaggerTag("Available sensors and products with sensors")]
public class SensorsController : ControllerBase
{
    private readonly SensorCommandService _commandService;
    private readonly SensorQueryService _queryService;

    public SensorsController(SensorCommandService commandService, SensorQueryService queryService)
    {
        _commandService = commandService;
        _queryService = queryService;
    }

    /// <summary>
    /// Returns products without sensor assigned.
    /// </summary>
    [HttpGet("available-products")]
    public async Task<IActionResult> GetAvailableProducts()
    {
        var products = await _queryService.Handle(new GetAvailableProductsQuery());
        return Ok(products);
    }

    [HttpGet("assigned-products")]
    public async Task<IActionResult> GetAssignedProducts()
    {
        var products = await _queryService.Handle(new GetAssignedProductsQuery());
        return Ok(products);
    }

    /// <summary>
    /// Assigns a sensor to a product.
    /// </summary>
    [HttpPost("{productId}")]
    public async Task<IActionResult> AssignSensor(int productId, [FromBody] SensorResource resource)
    {
        var command = new AssignSensorCommand(productId, resource.Type, resource.Status);
        await _commandService.Handle(command);
        return Ok();
    }

    [HttpPut("{productId}")]
    public async Task<IActionResult> UpdateSensor(int productId, [FromBody] SensorResource resource)
    {
        var command = new UpdateSensorCommand(productId, resource.Type, resource.Status);
        await _commandService.Handle(command);
        return Ok();
    }
}