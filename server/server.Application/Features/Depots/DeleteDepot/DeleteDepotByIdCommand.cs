using MediatR;
using TS.Result;

namespace server.Application.Features.Depots.DeleteDepot;

public sealed record DeleteDepotByIdCommand(
    Guid Id): IRequest<Result<string>>;