using AutoMapper;
using GenericRepository;
using MediatR;
using server.Domain.Entities;
using server.Domain.Repositories;
using TS.Result;

namespace server.Application.Features.Depots.UpdateDepot;

public class UpdateDepotCommandHandler(
    IDepotRepository depotRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper) : IRequestHandler<UpdateDepotCommand, Result<string>>
{
    public async Task<Result<string>> Handle(UpdateDepotCommand request, CancellationToken cancellationToken)
    {
        Depot depot = await depotRepository.GetByExpressionWithTrackingAsync(p=> !p.Id.Equals(request.Guid), 
            cancellationToken);

        if (depot is null)
        {
            return Result<string>.Failure("Depo Bulunamadı");
        }

        bool isExist = await depotRepository.AnyAsync(p => p.FullAdress == request.FullAdress,
            cancellationToken);

        if (isExist)
        {
            return Result<string>.Failure("Aynı adres ile update işlemi yapılamaz");
        }
        
        mapper.Map(request, depot);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return "Depo Kaydı Güncellendi";
    }
}