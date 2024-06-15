using AutoMapper;
using GenericRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using server.Domain.Entities;
using server.Domain.Repositories;
using TS.Result;

namespace server.Application.Features.RecipeDetails.UpdateRecipeDetail;

internal sealed class UpdateRecipeDetailCommandHandler(
    IRecipeDetailRepository repository,
    IUnitOfWork unitOfWork,
    IMapper mapper) : IRequestHandler<UpdateRecipeDetailCommand, Result<string>>
{
    public async Task<Result<string>> Handle(UpdateRecipeDetailCommand request, CancellationToken cancellationToken)
    {
        RecipeDetail recipeDetail = await repository.GetByExpressionWithTrackingAsync(p => p.Id == request.Id, cancellationToken);

        if (recipeDetail is null)
        {
            return Result<string>.Failure("Reçetede bu ürün bulunamadı");
        }

        RecipeDetail? oldRecipeDetail = 
            await repository
                .Where(p=> 
                    p.Id != request.Id && 
                    p.ProductId == request.ProductId && 
                    p.RecipeId == recipeDetail.RecipeId)
                .FirstOrDefaultAsync(cancellationToken);

        if(oldRecipeDetail is not null)
        {
            repository.Delete(recipeDetail);

            oldRecipeDetail.Quantity += request.Quantity;
            repository.Update(oldRecipeDetail);
        }
        else
        {
            mapper.Map(request, recipeDetail);
        }

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return "Reçetedeki ürün başarıyla güncellendi";
    }
}