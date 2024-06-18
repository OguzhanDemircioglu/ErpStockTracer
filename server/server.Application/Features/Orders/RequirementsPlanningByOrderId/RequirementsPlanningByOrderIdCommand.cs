using MediatR;
using TS.Result;

namespace server.Application.Features.Orders.RequirementsPlanningByOrderId;

public sealed record RequirementsPlanningByOrderIdCommand(
  Guid OrderId) : IRequest<Result<RequirementsPlanningByOrderIdCommandResponse>>;