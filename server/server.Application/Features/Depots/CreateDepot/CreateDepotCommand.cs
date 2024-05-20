using MediatR;
using TS.Result;

namespace server.Application.Features.Depots.CreateDepot;

public sealed record CreateDepotCommand(
    string Name,
    string City,
    string Town,
    string FullAdress
) : IRequest<Result<string>>;