using MediatR;
using TS.Result;

namespace server.Application.Features.Product.UpdateProduct;

public sealed record UpdateProductCommand(
    Guid Id,
    string Name,
    int TypeValue): IRequest<Result<string>>;