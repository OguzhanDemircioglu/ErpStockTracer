using MediatR;
using server.Domain.Dtos;
using TS.Result;

namespace server.Application.Features.Orders.CreateOrder;

public sealed record CreateOrderCommand(
  Guid CustomerId,
  DateOnly OrderDate,
  DateOnly DeliveryDate,
  List<OrderDetailDto> Details) : IRequest<Result<string>>;