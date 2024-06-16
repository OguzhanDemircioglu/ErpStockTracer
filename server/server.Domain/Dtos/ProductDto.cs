namespace server.Domain.Dtos;

public sealed record ProductDto(
  string Name,
  decimal Quantity
);