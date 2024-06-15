using MediatR;
using server.Domain.Entities;
using TS.Result;

namespace server.Application.Features.Products.GetAllProducts;

public sealed record GetAllProductQuery() : IRequest<Result<List<Product>>>;