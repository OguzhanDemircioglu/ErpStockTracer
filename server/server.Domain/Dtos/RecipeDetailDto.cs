namespace server.Domain.Dtos;

public sealed record RecipeDetailDto(
    Guid ProductId,
    Double Quantity);