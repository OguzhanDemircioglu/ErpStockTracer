using GenericRepository;
using MediatR;
using server.Domain.Repositories;
using TS.Result;

namespace server.Application.Features.Product.DeleteProduct;

internal sealed class DeleteProductByIdHandler(
    IProductRespository respository,
    IUnitOfWork unitOfWork): IRequestHandler<DeleteProductByIdCommand, Result<string>>
{

    public async Task<Result<string>> Handle(DeleteProductByIdCommand command, CancellationToken cancellationToken)
    {
        Domain.Entities.Product product = await respository.GetByExpressionAsync(p => p.Id == command.Id, cancellationToken);

        if (product == null)
        {
            return Result<string>.Failure("Product bulunamadı");
        }
        
        respository.Delete(product);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return "Ürün Başarı ile Silindi";
    }
    
}