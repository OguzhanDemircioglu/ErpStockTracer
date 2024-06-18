using server.Domain.Dtos;

namespace server.Application.Features.Orders.RequirementsPlanningByOrderId;

public sealed record RequirementsPlanningByOrderIdCommandResponse(
  DateOnly Date,
  string Title,
  List<ProductDto> Products);