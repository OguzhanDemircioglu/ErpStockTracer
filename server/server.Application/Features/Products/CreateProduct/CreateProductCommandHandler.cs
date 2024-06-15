using AutoMapper;
using GenericRepository;
using MediatR;
using server.Domain.Entities;
using server.Domain.Repositories;
using TS.Result;

namespace server.Application.Features.Products.CreateProduct;

public class CreateProductCommandHandler(
    IProductRespository respository,
    IUnitOfWork unitOfWork,
    IMapper mapper) : IRequestHandler<CreateProductCommand, Result<string>>
{
    public async Task<Result<string>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        bool isExist = await respository.AnyAsync(p=>p.Name.Equals(request.Name),
            cancellationToken);

        if (isExist)
        {
            return Result<string>.Failure("Ürün adı önce eklenmiş");
        }
        
        Product product = mapper.Map<Product>(request);

        await respository.AddAsync(product, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return "Ürün Başarıyla Eklendi";
    }

}