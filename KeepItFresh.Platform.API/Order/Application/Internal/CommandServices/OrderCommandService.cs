using ACME.LearningCenterPlatform.API.Shared.Domain.Repositories;
using KeepItFresh.Platform.API.Order.Domain.Model.Commands;
using KeepItFresh.Platform.API.Order.Domain.Repositories;
using KeepItFresh.Platform.API.Order.Domain.Services;
using KeepItFresh.Platform.API.Order.Infrastructure.Repositories;

namespace KeepItFresh.Platform.API.Order.Application.Internal.CommandServices;

public class OrderCommandService(IOrderRepository repository, IUnitOfWork unitOfWork) : IOrderCommandService
{
    public async Task<Domain.Model.Aggregates.Order?> Handle(CreateOrderCommand command)
    {
        var order = new Domain.Model.Aggregates.Order(command);
        await OrderRepository.AddAsync(order);  
    }
}