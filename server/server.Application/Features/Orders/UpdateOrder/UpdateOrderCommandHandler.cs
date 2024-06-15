using AutoMapper;
using GenericRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using server.Domain.Entities;
using server.Domain.Repositories;
using TS.Result;

namespace server.Application.Features.Orders.UpdateOrder;

internal sealed class UpdateOrderCommandHandler(
  IOrderRepository repository,
  IOrderDetailRepository orderDetailRepository,
  IUnitOfWork unitOfWork,
  IMapper mapper) : IRequestHandler<UpdateOrderCommand, Result<string>>
{
  public async Task<Result<string>> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
  {
    Order? order =
      await repository
        .Where(p => p.Id == request.Id)
        .Include(p => p.Details)
        .FirstOrDefaultAsync();

    if (order is null)
    {
      return Result<string>.Failure("Şipariş  Bulunamadı");
    }

    orderDetailRepository.DeleteRange(order.Details);

    List<OrderDetail> newDetails = request.Details
      .Select(s => new OrderDetail
      {
        OrderId = order.Id,
        Price = s.Price,
        ProductId = s.ProductId,
        Quantity = s.Quantity
      }).ToList();

    await orderDetailRepository.AddRangeAsync(newDetails, cancellationToken);

    mapper.Map(request, order);

    repository.Update(order);

    await unitOfWork.SaveChangesAsync(cancellationToken);

    return "Şipariş Güncellendi";
  }
}