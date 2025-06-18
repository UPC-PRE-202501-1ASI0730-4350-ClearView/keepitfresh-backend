using KeepItFresh.Platform.API.Sensor.Application.Internal.CommandServices;
using KeepItFresh.Platform.API.Sensor.Interfaces.REST.Resources;
using Microsoft.AspNetCore.Mvc;

namespace KeepItFresh.Platform.API.Sensor.Interfaces.REST;

[ApiController]
[Route("api/sensors")]
public class SensorsController : ControllerBase
{
    private readonly SensorApplicationService _service;

    public SensorsController(SensorApplicationService service)
    {
        _service = service;
    }

    /// <summary>
    /// Returns products without sensor assigned.
    /// </summary>
    [HttpGet("v1/available-products")]
    public async Task<IActionResult> GetAvailableProducts() =>
        Ok(await _service.GetAvailableProductsAsync());

    /// <summary>
    /// Returns products with sensor assigned.
    /// </summary>
    [HttpGet("v1/assigned-products")]
    public async Task<IActionResult> GetAssignedProducts() =>
        Ok(await _service.GetAssignedProductsAsync());

    /// <summary>
    /// Assigns a sensor to a product.
    /// </summary>
    [HttpPost("v1/{productId}")]
    public async Task<IActionResult> AssignSensor(int productId, [FromBody] SensorResource resource)
    {
        await _service.AssignSensorAsync(productId, resource.Type, resource.Status);
        return Ok();
    }

    /// <summary>
    /// Updates a sensor of a product.
    /// </summary>
    [HttpPut("v1/{productId}")]
    public async Task<IActionResult> UpdateSensor(int productId, [FromBody] SensorResource resource)
    {
        await _service.UpdateSensorAsync(productId, resource.Type, resource.Status);
        return Ok();
    }
}