using GenericRepository;
using MediatR;
using server.Domain.Entities;
using server.Domain.Repositories;
using TS.Result;

namespace server.Application.Features.Depots.DeleteDepot;

public class DeleteDepotByIdCommandHandler(
    IDepotRepository depotRepository,
    IUnitOfWork unitOfWork): IRequestHandler<DeleteDepotByIdCommand, Result<string>>
{
    public async Task<Result<string>> Handle(DeleteDepotByIdCommand request, CancellationToken cancellationToken)
    {
        Depot depot = await depotRepository.GetByExpressionAsync(p=> p.Id == request.Id, 
            cancellationToken);

        if (depot is null)
        {
            return Result<string>.Failure("Depo Bulunamadı");
        }

        depotRepository.Delete(depot);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return "Depo Kaydı Silindi";
    }
}