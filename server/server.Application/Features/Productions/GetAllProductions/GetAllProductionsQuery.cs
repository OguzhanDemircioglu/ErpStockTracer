using MediatR;
using server.Domain.Entities;
using TS.Result;

namespace server.Application.Features.Productions.GetAllProductions;

public sealed record GetAllProductionsQuery: IRequest<Result<List<Production>>>;