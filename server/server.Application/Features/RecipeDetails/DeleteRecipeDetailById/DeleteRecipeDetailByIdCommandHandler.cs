using GenericRepository;
using MediatR;
using server.Domain.Entities;
using server.Domain.Repositories;
using TS.Result;

namespace server.Application.Features.RecipeDetails.DeleteRecipeDetailById;

public sealed class
    DeleteRecipeDetailByIdCommandHandler(
        IRecipeDetailRepository repository,
        IUnitOfWork unitOfWork) : IRequestHandler<DeleteRecipeDetailByIdCommand, Result<string>>
{
    public async Task<Result<string>> Handle(DeleteRecipeDetailByIdCommand request, CancellationToken cancellationToken)
    {
        RecipeDetail recipeDetail =
            await repository.GetByExpressionWithTrackingAsync(p => p.Id == request.Id, cancellationToken);

        if (recipeDetail == null)
        {
            return Result<string>.Failure("Reçete Ürünü bulunamadı");
        }

        repository.Delete(recipeDetail);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return "Reçete Ürünü Başarıyla Silindi";
    }
}