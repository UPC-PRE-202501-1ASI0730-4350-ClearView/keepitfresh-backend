using System.Net.Mime;
using KeepItFresh.Platform.API.Order.Domain.Model.Commands;
using KeepItFresh.Platform.API.Order.Domain.Model.Queries;
using KeepItFresh.Platform.API.Order.Domain.Services;
using KeepItFresh.Platform.API.Order.interfaces.REST.Resources;
using KeepItFresh.Platform.API.Order.interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace KeepItFresh.Platform.API.Order.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[Tags("Orders")]
public class OrderController (IOrderCommandService orderCommandService, IOrderQueryServices orderQueryService) : ControllerBase
{
    [HttpPost]
    [SwaggerOperation(
        Summary = "Creates a new Order",
        Description = "Creates a new Order",
        OperationId = "CreateOrder")]
    [SwaggerResponse(StatusCodes.Status201Created, "The Order Was Created", typeof(OrderResource))]
    public async Task<IActionResult> CreateOrder([FromBody] CreateOrderResource resource)
    {
        var createOrderCommand = CreateOrderCommandFromResourceAssembler.ToCommandFromResource(resource);

        var result = await orderCommandService.Handle(createOrderCommand);
        
        if (result == null)
            return BadRequest();
        
        return CreatedAtAction(nameof(GetOrderById), new {id = result.Id}, OrderResourceFromEntityAssembler.ToResourceFromEntity(result));
    }
    
    
    [HttpGet("{id}")]
    [SwaggerOperation(
        Summary = "Gets an Order by Id",
        Description = "Gets an Order by Id",
        OperationId = "GetOrderById")]
    [SwaggerResponse(StatusCodes.Status200OK, "The Order Was Found", typeof(OrderResource))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid Data")]
    public async Task<IActionResult> GetOrderById([FromRoute] GetOrderByIdQuery query)
    {
        var getOrderByIdQuery = new GetOrderByIdQuery(query.Id);
        
        var result = await orderQueryService.Handle(getOrderByIdQuery);
        
        if (result == null)
            return NotFound();
        
        
        var orderResource = OrderResourceFromEntityAssembler.ToResourceFromEntity(result);
        
        
        return Ok(orderResource);
    }


    [HttpGet]
    [SwaggerOperation(
        Summary = "Gets all Orders",
        Description = "Gets all Orders",
        OperationId = "GetAllOrders")]
    [SwaggerResponse(StatusCodes.Status200OK, "The Orders Were Found", typeof(IEnumerable<OrderResource>))]
    public async Task<IActionResult> GetAllOrders()
    {
        var getAllOrdersQuery = new GetAllOrdersQuery();
        var orders = await orderQueryService.Handle(getAllOrdersQuery);
        var result = orders.Select(OrderResourceFromEntityAssembler.ToResourceFromEntity).ToList();
        
        return Ok(result);
    }

    [HttpPut("{id}")]
    [SwaggerOperation(
        Summary = "Updates an Order",
        Description = "Updates an Order",
        OperationId = "UpdatesOrder")]
    [SwaggerResponse(StatusCodes.Status200OK, "The Order Was Updated", typeof(OrderResource))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid Data")]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Order Not Found")]
    public async Task<IActionResult> UpdateOrder([FromRoute] UpdateOrderCommand resource)
    {
        if (resource.OrderId <= 0)
        {
            return BadRequest("Invalid Order Id");
        }
        
        var updateOrderCommand = new UpdateOrderCommand(resource.OrderId, resource.Name, resource.Dishes, resource.Price);
        var result = await orderCommandService.Handle(updateOrderCommand);

        if (result == null)
        {
            return NotFound("The Order Was Not Found");
        }
        
        return Ok(OrderResourceFromEntityAssembler.ToResourceFromEntity(result));
    }
    
    
    
}