using MediatR;
using TS.Result;

namespace server.Application.Features.Products.DeleteProduct;

public sealed record DeleteProductByIdCommand(Guid Id): IRequest<Result<string>>;