using MediatR;
using server.Domain.Entities;
using TS.Result;

namespace server.Application.Features.Orders.GetAllOrder;

public sealed record GetAllOrderQuery() : IRequest<Result<List<Order>>>;