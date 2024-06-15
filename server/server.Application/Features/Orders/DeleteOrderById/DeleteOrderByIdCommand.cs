using MediatR;
using TS.Result;

namespace server.Application.Features.Orders.DeleteOrderById;

public sealed record DeleteOrderByIdCommand(
  Guid Id) : IRequest<Result<string>>;