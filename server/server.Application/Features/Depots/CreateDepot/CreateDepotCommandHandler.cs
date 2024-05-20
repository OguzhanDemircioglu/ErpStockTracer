using AutoMapper;
using GenericRepository;
using MediatR;
using server.Domain.Entities;
using server.Domain.Repositories;
using TS.Result;

namespace server.Application.Features.Depots.CreateDepot;

public class CreateDepotCommandHandler(
    IDepotRepository depotRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper) : IRequestHandler<CreateDepotCommand, Result<string>>
{
    public async Task<Result<string>> Handle(CreateDepotCommand request, CancellationToken cancellationToken)
    {
        bool isExist = await depotRepository.AnyAsync(p=>p.Name.Equals(request.Name),
            cancellationToken);

        if (isExist)
        {
            return Result<string>.Failure("Depo Zaten Eklenmiş");
        }
        
        Depot depot = mapper.Map<Depot>(request);

        await depotRepository.AddAsync(depot, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return "Depo Başarıyla Eklendi";
    }

}