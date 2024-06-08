using GenericRepository;
using MediatR;
using server.Domain.Entities;
using server.Domain.Repositories;
using TS.Result;

namespace server.Application.Features.Recipes.CreateRecipe;

internal sealed class CreateRecipeCommandHandler(
    IRecipeRepository repository,
    IUnitOfWork unitOfWork): IRequestHandler<CreateRecipeCommand, Result<string>>
{
    public async Task<Result<string>> Handle(CreateRecipeCommand request, CancellationToken cancellationToken)
    {
        bool isExist = await repository.AnyAsync(p=>p.ProductId.Equals(request.ProductId),
            cancellationToken);

        if (isExist)
        {
            return Result<string>.Failure("Ürüne ait reçete daha önce oluşturuldu");
        }

        Recipe recipe = new()
        {
            ProductId = request.ProductId,
            Details = request.Details.Select(s =>
                new RecipeDetail()
                {
                    ProductId = s.ProductId,
                    Quantity = s.Quantity
                }).ToList()
        };
        
        await repository.AddAsync(recipe, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return "Reçete Kaydı Başarı ile oluşturuldu";
    }
}
