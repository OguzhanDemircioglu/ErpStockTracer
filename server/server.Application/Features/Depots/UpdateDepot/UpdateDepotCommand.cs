using MediatR;
using TS.Result;

namespace server.Application.Features.Depots.UpdateDepot;

public sealed record UpdateDepotCommand(
    Guid Guid,
    string Name,
    string City,
    string Town,
    string FullAdress
) : IRequest<Result<string>>;