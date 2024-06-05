using MediatR;
using TS.Result;

namespace server.Application.Features.Product.GetAllProducts;

public sealed record GetAllProductQuery() : IRequest<Result<List<Domain.Entities.Product>>>;