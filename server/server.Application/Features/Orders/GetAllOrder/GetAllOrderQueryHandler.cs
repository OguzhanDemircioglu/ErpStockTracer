using MediatR;
using Microsoft.EntityFrameworkCore;
using server.Domain.Entities;
using server.Domain.Repositories;
using TS.Result;

namespace server.Application.Features.Orders.GetAllOrder;

internal sealed class GetAllOrderQueryHandler(
  IOrderRepository repository) : IRequestHandler<GetAllOrderQuery, Result<List<Order>>>
{
  public async Task<Result<List<Order>>> Handle(GetAllOrderQuery request, CancellationToken cancellationToken)
  {
    List<Order> orders = await repository.GetAll()
      .Include(p => p.Customer)
      .Include(p => p.Details!)
      .ThenInclude(p => p.Product)
      .OrderByDescending(r => r.OrderDate)
      .ToListAsync(cancellationToken);
    return orders;
  }
}