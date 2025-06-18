using System.Net.Mime;
using KeepItFresh.Platform.API.Control.Domain.Model.Commands;
using KeepItFresh.Platform.API.Control.Domain.Model.Queries;
using KeepItFresh.Platform.API.Control.Domain.Services;
using KeepItFresh.Platform.API.Control.Interfaces.REST.Resources;
using KeepItFresh.Platform.API.Control.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace KeepItFresh.Platform.API.Control.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[Tags("Inventory")]
public class InventoryController(IInventoryCommandService inventoryCommandService,
    IInventoryQueryService inventoryQueryService) : ControllerBase
{
    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a new inventory",
        Description = "Create a new inventory",
        OperationId = "CreateInventory")]
    [SwaggerResponse(StatusCodes.Status201Created, "The inventory was created", typeof(InventoryResource))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "The inventory could not be created")]
    public async Task<IActionResult> CreateInventory([FromBody] CreateInventoryResource resource)
    {
        var createInventoryCommand = CreateInventoryCommandFromResourceAssembler.ToCommandFromResource(resource);

        var result = await inventoryCommandService.Handle(createInventoryCommand);
        
        if(result is null)
            return BadRequest();
        
        return CreatedAtAction(nameof(GetProductById), new { id = result.Id },
            InventoryResourceFromEntityAssembler.ToResourceFromEntity(result));
    }

    [HttpGet("{id}")]
    [SwaggerOperation(
        Summary = "Get a inventory by ID",
        Description = "Get a inventory source by the specified ID",
        OperationId = "GetInventoryById")]
    [SwaggerResponse(StatusCodes.Status200OK, "The inventory was found", typeof(InventoryResource))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "The inventory was not found")]
    public async Task<ActionResult> GetProductById(int id)
    {
        var getInventoryByIdQuery = new GetInventoryByIdQuery(id);
        
        var result = await inventoryQueryService.Handle(getInventoryByIdQuery);
        
        if (result is null)
            return NotFound();

        var resource = InventoryResourceFromEntityAssembler.ToResourceFromEntity(result);
        
        return Ok(result);
    }

    [SwaggerOperation(
        Summary = "Get all inventories",
        Description = "This endpoint is designed to get all inventories",
        OperationId = "GetAllInventories")]
    [SwaggerResponse(StatusCodes.Status200OK, "The inventories were found", typeof(IEnumerable<InventoryResource>))]
    [HttpGet]
    public async Task<IActionResult> GetAllInventories()
    {
        var getAllInventoriesQuery = new GetAllInventoriesQuery();
        var inventories = await inventoryQueryService.Handle(getAllInventoriesQuery);
        var inventoryResources = inventories.Select(InventoryResourceFromEntityAssembler.ToResourceFromEntity);

        return Ok(inventoryResources);
    }
    
    [HttpPut("owner_product")]
    [SwaggerOperation(
        Summary = "Update the owner of a product",
        Description = "Update the owner of the specified product",
        OperationId = "UpdateProductOwner")]
    [SwaggerResponse(StatusCodes.Status200OK, "The product owner was updated")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid data provided")]
    [SwaggerResponse(StatusCodes.Status404NotFound, "The product was not found")]
    public async Task<ActionResult> UpdateProductOwner([FromBody] UpdateProductOwnerResource resource)
    {
        if (resource.ProductId <= 0 || resource.ProductId <= 0) 
            return BadRequest("Invalid resource data");

        var updateOwnerCommand = new UpdateProductOwnerCommand(resource.ProductId);

        var result = await inventoryCommandService.Handle(updateOwnerCommand);

        if (result is null)
            return NotFound("The product or user was not found");

        return Ok("Product owner updated successfully");
    }
    
    [HttpPut("owner_supplier")]
    [SwaggerOperation(
        Summary = "Update the owner of a supplier",
        Description = "Update the owner of the specified supplier",
        OperationId = "UpdateSupplierOwner")]
    [SwaggerResponse(StatusCodes.Status200OK, "The supplier owner was updated")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid data provided")]
    [SwaggerResponse(StatusCodes.Status404NotFound, "The supplier was not found")]
    public async Task<ActionResult> UpdateSupplierOwner([FromBody] UpdateSupplierOwnerCommand resource)
    {
        if (resource.SupplierId <= 0 || resource.SupplierId <= 0) 
            return BadRequest("Invalid resource data");

        var updateOwnerCommand = new UpdateSupplierOwnerCommand(resource.SupplierId);

        var result = await inventoryCommandService.Handle(updateOwnerCommand);

        if (result is null)
            return NotFound("The supplier was not found");

        return Ok("Supplier owner updated successfully");
    }
    
    [HttpDelete("{id}")]
    [SwaggerOperation(
        Summary = "Delete a inventory by ID",
        Description = "Delete the inventory with the specified ID",
        OperationId = "DeleteInventory")]
    [SwaggerResponse(StatusCodes.Status204NoContent, "The inventory was deleted")]
    [SwaggerResponse(StatusCodes.Status404NotFound, "The inventory was not found")]
    public async Task<ActionResult> DeleteProduct(int id)
    {
        var resource = new DeleteInventoryResource(id);
        
        var deleteProductCommand = DeleteInventoryCommandFromResourceAssembler.ToCommandFromResource(resource);
        
        await inventoryCommandService.Handle(deleteProductCommand);
        
        return NoContent();
    }

    [HttpGet("products/{productId}/inventory")]
    [SwaggerOperation(
        Summary = "Get inventory by ProductId",
        Description = "Get all inventories associated with the specified ProductId",
        OperationId = "GetInventoryByProductId")]
    [SwaggerResponse(StatusCodes.Status200OK, "The inventories were found", typeof(IEnumerable<InventoryResource>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "No products found for the given ProductId")]
    public async Task<ActionResult> GetInventoryByProductId(int productId)
    {
        var getInventoryByProductIdQuery = new GetInventoryByProductIdQuery(productId);

        var result = await inventoryQueryService.Handle(getInventoryByProductIdQuery);

        if (result is null)
            return NotFound();

        var resources = result.Select(InventoryResourceFromEntityAssembler.ToResourceFromEntity);
        
        return Ok(resources);
    }
    
    [HttpGet("suppliers/{supplierId}/inventory")]
    [SwaggerOperation(
        Summary = "Get inventory by SupplierId",
        Description = "Get all inventories associated with the specified SupplierId",
        OperationId = "GetInventoryBySupplierId")]
    [SwaggerResponse(StatusCodes.Status200OK, "The inventories were found", typeof(IEnumerable<InventoryResource>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "No products found for the given SupplierId")]
    public async Task<ActionResult> GetInventoryBySupplierId(int supplierId)
    {
        var getInventoryBySupplierIdQuery = new GetInventoryBySupplierIdQuery(supplierId);

        var result = await inventoryQueryService.Handle(getInventoryBySupplierIdQuery);

        if (result is null)
            return NotFound();

        var resources = result.Select(InventoryResourceFromEntityAssembler.ToResourceFromEntity);
        
        return Ok(resources);
    }
    
}