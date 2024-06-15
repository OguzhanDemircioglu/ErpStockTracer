using AutoMapper;
using GenericRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using server.Domain.Entities;
using server.Domain.Repositories;
using TS.Result;

namespace server.Application.Features.Orders.CreateOrder;

internal sealed class CreateOrderCommandHandler(
  IOrderRepository repository,
  IUnitOfWork unitOfWork,
  IMapper mapper) : IRequestHandler<CreateOrderCommand, Result<string>>
{
  public async Task<Result<string>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
  {
    Order? lastOrder = await repository
      .Where(p => p.OrderNumberYear == request.OrderDate.Year)
      .OrderByDescending(p => p.OrderDate)
      .FirstOrDefaultAsync(cancellationToken);

    int lastOrderNumber = 0;
    if (lastOrder is not null) lastOrderNumber = lastOrder.OrderNumber;

    /*List<OrderDetail> Details = request.Details.Select(s => new OrderDetail
    {
      ProductId = s.ProductId,
      Quantity = s.Quantity,
      Price = s.Price
    }).ToList();

    Order order = new()
    {
      CustomerId = request.CustomerId,
      DeliveryDate = request.DeliveryDate,
      OrderDate = request.OrderDate,
      OrderNumber = lastOrderNumber++,
      OrderNumberYear = request.OrderDate.Year,
      Details = Details
    };*/

    Order order = mapper.Map<Order>(request);
    order.OrderNumberYear = request.OrderDate.Year;
    order.OrderNumber = lastOrderNumber++;

    await repository.AddAsync(order, cancellationToken);
    await unitOfWork.SaveChangesAsync(cancellationToken);

    return "Sipariş İşlemi Başarlı";
  }
}