using AutoMapper;
using GenericRepository;
using MediatR;
using server.Domain.Entities;
using server.Domain.Repositories;
using TS.Result;

namespace server.Application.Features.RecipeDetails.CreateRecipeDetail;

public sealed class CreateRecipeDetailCommandHandler(
    IRecipeDetailRepository repository,
    IUnitOfWork unitOfWork,
    IMapper mapper) : IRequestHandler<CreateRecipeDetailCommand, Result<string>>
{
    public async Task<Result<string>> Handle(CreateRecipeDetailCommand request, CancellationToken cancellationToken)
    {
        RecipeDetail recipeDetail = await repository
            .GetByExpressionWithTrackingAsync(p => p.RecipeId == request.RecipeId &&
                                                   p.ProductId == request.ProductId, cancellationToken);
        if (recipeDetail is not null)
        {
            recipeDetail.Quantity += request.Quantity;
        }
        else
        {
            recipeDetail = mapper.Map<RecipeDetail>(request);
            await repository.AddAsync(recipeDetail, cancellationToken);
        }

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return "Reçete Ürün kaydı başarılı ile tamamlandı";
    }
}