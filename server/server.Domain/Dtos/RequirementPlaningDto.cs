namespace server.Domain.Dtos;

public sealed record RequirementPlaningDto(
  DateOnly DateOnly,
  string Title,
  List<ProductDto> Products);