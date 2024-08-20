using MediatR;
using TS.Result;

namespace server.Application.Features.Productions.DeleteProduction;

public sealed record DeleteProductionByIdCommand(
    Guid Id): IRequest<Result<string>>;