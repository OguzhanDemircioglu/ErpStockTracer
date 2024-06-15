using MediatR;
using server.Domain.Dtos;
using TS.Result;

namespace server.Application.Features.Orders.UpdateOrder;

public sealed record UpdateOrderCommand(
  Guid Id,
  Guid CustomerId,
  DateOnly OrderDate,
  DateOnly DeliveryDate,
  List<OrderDetailDto> Details) : IRequest<Result<string>>;