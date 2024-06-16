using MediatR;
using server.Domain.Dtos;
using TS.Result;

namespace server.Application.Features.Orders.RequirementsPlanningByOrderId;

public sealed record RequirementsPlanningByOrderIdCommand(Guid OrderId) : IRequest<Result<RequirementPlaningDto>>;