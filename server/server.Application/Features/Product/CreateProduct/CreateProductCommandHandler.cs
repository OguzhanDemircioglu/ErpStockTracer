using AutoMapper;
using GenericRepository;
using MediatR;
using server.Application.Features.Depots.CreateDepot;
using server.Domain.Repositories;
using TS.Result;

namespace server.Application.Features.Product.CreateProduct;

internal sealed class CreateProductCommandHandler(
    IProductRespository respository,
    IUnitOfWork unitOfWork,
    IMapper mapper) : IRequestHandler<CreateDepotCommand, Result<string>>
{
    public async Task<Result<string>> Handle(CreateDepotCommand request, CancellationToken cancellationToken)
    {
        bool isExist = await respository.AnyAsync(p=>p.Name.Equals(request.Name),
            cancellationToken);

        if (isExist)
        {
            return Result<string>.Failure("Ürün adı önce eklenmiş");
        }
        
        Domain.Entities.Product product = mapper.Map<Domain.Entities.Product>(request);

        await respository.AddAsync(product, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return "Ürün Başarıyla Eklendi";
    }

}