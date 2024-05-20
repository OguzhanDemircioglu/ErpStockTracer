using MediatR;
using server.Domain.Entities;
using TS.Result;

namespace server.Application.Features.Depots.GetAllDepots;

public sealed record GetAllDepotQuery() : IRequest<Result<List<Depot>>>;