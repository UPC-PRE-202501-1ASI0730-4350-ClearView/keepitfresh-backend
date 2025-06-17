using ACME.LearningCenterPlatform.API.Shared.Domain.Repositories;
using KeepItFresh.Platform.API.Order.Domain.Model.Aggregates;
using KeepItFresh.Platform.API.Order.Domain.Model.Commands;
using KeepItFresh.Platform.API.Order.Domain.Repositories;
using KeepItFresh.Platform.API.Order.Domain.Services;

namespace KeepItFresh.Platform.API.Order.Application.Internal.CommandServices;

public class OrderCommandService(IOrderRepository repository, IUnitOfWork unitOfWork) : IOrderCommandService
{
    public async Task<Orders?> Handle(CreateOrderCommand command)
    {
        var order = new Orders(command);
        await repository.AddAsync(order);
        await unitOfWork.CompleteAsync();
        return order;
    }

    public async Task<Orders?> Handle(DeleteOrderCommand command)
    {
        var order = await repository.FindByIdAsync(command.Id);
        
        if (order == null)
            throw new ArgumentException("Order not found");

        try
        {
            repository.Remove(order);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            throw new Exception($"Failed to delete order {command.Id}", e);
        }
        
        return order;
    }
}