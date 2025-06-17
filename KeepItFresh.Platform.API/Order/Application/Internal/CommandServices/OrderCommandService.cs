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
}