using MediatR;
using Microsoft.EntityFrameworkCore;
using server.Domain.Dtos;
using server.Domain.Entities;
using server.Domain.Repositories;
using TS.Result;

namespace server.Application.Features.Orders.RequirementsPlanningByOrderId;

internal sealed class RequirementsPlanningByOrderIdCommandHandler(
  IOrderRepository orderRepository)
  : IRequestHandler<RequirementsPlanningByOrderIdCommand, Result<RequirementPlaningDto>>
{
  public async Task<Result<RequirementPlaningDto>> Handle(RequirementsPlanningByOrderIdCommand request, CancellationToken cancellationToken)
  {
    Order? order = await orderRepository
      .Where(p => p.Id == request.OrderId)
      .Include(p=> p.Details)
      .FirstOrDefaultAsync(cancellationToken);

    if (order is null)
    {
      return Result<RequirementPlaningDto>.Failure("Sipariş Bulunamadı");
    }

    throw new Exception();
  }
}