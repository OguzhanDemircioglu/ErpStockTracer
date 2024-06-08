using AutoMapper;
using GenericRepository;
using MediatR;
using server.Domain.Repositories;
using TS.Result;

namespace server.Application.Features.Products.UpdateProduct;

public sealed class UpdateProductCommandHandler(
    IProductRespository respository,
    IUnitOfWork unitOfWork,
    IMapper mapper): IRequestHandler<UpdateProductCommand, Result<string>>
{
    public async Task<Result<string>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        Domain.Entities.Product product = await respository.GetByExpressionWithTrackingAsync(p => p.Id == request.Id, cancellationToken);
        
        if (product == null)
        {
            return Result<string>.Failure("Product bulunamadı");
        }
        
        bool isExist = await respository.AnyAsync(p=>p.Name.Equals(request.Name),
            cancellationToken);

        if (isExist)
        {
            return Result<string>.Failure("Ürün adı önce eklenmiş");
        }
        
        mapper.Map(request, product);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return "Ürün Başarı ile Güncellendi";
    }
}