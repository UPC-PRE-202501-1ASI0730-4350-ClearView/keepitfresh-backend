using KeepItFresh.Platform.API.Inventory.Application.Internal.CommandServices;
using KeepItFresh.Platform.API.Inventory.Application.Internal.QueryServices;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using KeepItFresh.Platform.API.Inventory.Domain.Model.Commands;
using KeepItFresh.Platform.API.Inventory.Domain.Model.Queries;
using KeepItFresh.Platform.API.Inventory.Domain.Model.ValueObjects;
using KeepItFresh.Platform.API.Inventory.Infrastructure.Persistence.EFC;
using KeepItFresh.Platform.API.Inventory.Interfaces.REST.Resources;
using KeepItFresh.Platform.API.Inventory.Interfaces.REST.Transform;

namespace KeepItFresh.Platform.API.Inventory.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[SwaggerTag("Operations for managing products and assigning sensors")]

public class ProductsController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly ProductCommandService _commandService;
    private readonly ProductQueryService _queryService;

    public ProductsController(AppDbContext context, ProductCommandService commandService, ProductQueryService queryService)
    {
        _context = context;
        _commandService = commandService;
        _queryService = queryService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _queryService.Handle(new ListProductsQuery());
        return Ok(result.Select(ProductResourceAssembler.ToResource));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var product = await _queryService.Handle(new GetProductByIdQuery(id));
        if (product is null) return NotFound();
        return Ok(ProductResourceAssembler.ToResource(product));
    }

    [HttpPost]
    [SwaggerOperation(Summary = "Create new product")]
    public async Task<IActionResult> Create([FromBody] ProductDto dto)
    {
        if (!DateTime.TryParse(dto.ExpirationDate, out var parsedDate))
            return BadRequest("Invalid expiration date format.");

        var command = new CreateProductCommand(
            dto.Name, dto.Category, dto.Quantity, dto.Price, parsedDate,dto.Image
        );

        var product = await _commandService.Handle(command);

        return CreatedAtAction(nameof(GetById), new { id = product.Id }, ProductResourceAssembler.ToResource(product));
    }


    [HttpPut("{id}")]
    [SwaggerOperation(Summary = "Update product or assign sensor")]
    public async Task<IActionResult> Update(int id, [FromBody] ProductDto dto)
    {
        if (!DateTime.TryParse(dto.ExpirationDate, out var parsedDate))
            return BadRequest("Invalid expiration date format.");

        var sensor = dto.Sensor is not null
            ? new SensorData(dto.Sensor.Id, dto.Sensor.Type, dto.Sensor.Status)
            : null;

        var command = new UpdateProductCommand(
            id, dto.Name, dto.Category, dto.Quantity, dto.Price, parsedDate, dto.Image, sensor
        );

        var updated = await _commandService.Handle(command);
        if (updated is null) return NotFound();

        return Ok(ProductResourceAssembler.ToResource(updated));
    }

    [HttpDelete("{id}")]
    [SwaggerOperation(Summary = "Delete product")]
    public async Task<IActionResult> Delete(int id)
    {
        var success = await _commandService.Handle(new DeleteProductCommand(id));
        return success ? NoContent() : NotFound();
    }
}
