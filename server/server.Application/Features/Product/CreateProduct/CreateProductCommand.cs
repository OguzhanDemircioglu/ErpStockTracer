using MediatR;
using TS.Result;

namespace server.Application.Features.Product.CreateProduct;

public sealed record CreateProductCommand(
    string Name,
    int TypeValue) : IRequest<Result<string>>;