using MediatR;
using server.Domain.Dtos;
using TS.Result;

namespace server.Application.Features.Orders.CreateOrder;

public sealed record CreateOrderCommand(
  Guid CustomerId,
  DateTime OrderDate,
  DateTime DeliveryDate,
  List<OrderDetailDto> Details) : IRequest<Result<string>>;