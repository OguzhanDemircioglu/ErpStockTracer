using AutoMapper;
using GenericRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using server.Domain.Entities;
using server.Domain.Repositories;
using TS.Result;

namespace server.Application.Features.Productions.CreateProduction;

internal sealed class CreateProductionCommandHandler(
    IProductionRepository productionRepository,
    IRecipeRepository recipeRepository,
    IStockMovementRepository stockMovementRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper) : IRequestHandler<CreateProductionCommand, Result<string>>
{
    public async Task<Result<string>> Handle(CreateProductionCommand request, CancellationToken cancellationToken)
    {
        Production production = mapper.Map<Production>(request);
        List<StockMovement> newMovements = new();

        Recipe? recipe = 
            await recipeRepository
                .Where(p => p.ProductId == request.ProductId)
                .Include(p => p.Details!)
                .ThenInclude(p => p.Product)
                .FirstOrDefaultAsync(cancellationToken);

        if(recipe is not null && recipe.Details is not null)
        {
            var details = recipe.Details;
            foreach (var item in details)
            {
                List<StockMovement> movements = await stockMovementRepository.Where(p => p.ProductId == item.ProductId).ToListAsync(cancellationToken);

                List<Guid> depotIds = movements.GroupBy(p=> p.DepotId)
                    .Select(g=> g.Key)
                    .ToList();

                decimal stock = movements.Sum(p => p.NumberOfInputs) - movements.Sum(p => p.NumberOfOutputs);
                if(item.Quantity > (double)stock)
                {
                    return Result<string>.Failure(item.Product!.Name + " ürününden üretim için yeterli miktarda yok. Eksik miktar: " + (item.Quantity - (double)stock));
                }

                foreach (var depotId in depotIds)
                {
                    if (item.Quantity <= 0) break;

                    decimal quantity = movements.Where(p => p.DepotId == depotId).Sum(s => s.NumberOfInputs - s.NumberOfOutputs);

                    decimal totalAmount = 
                        movements
                            .Where(p => p.DepotId == depotId && p.NumberOfInputs > 0)
                            .Sum(s => s.Price * s.NumberOfInputs);

                    decimal totalEntiresQuantity =
                        movements
                            .Where(p => p.DepotId == depotId && p.NumberOfInputs > 0)
                            .Sum(s => s.NumberOfInputs);

                    decimal price = totalAmount / totalEntiresQuantity;


                    StockMovement stockMovement = new()
                    {
                        ProductionId = production.Id,
                        ProductId = item.ProductId,
                        DepotId = depotId,
                        Price = price
                    };

                    if (item.Quantity <= (double)stock)
                    {
                        stockMovement.NumberOfOutputs = (decimal)item.Quantity;
                    }
                    else
                    {
                        stockMovement.NumberOfOutputs = quantity;
                    }
                        
                    item.Quantity -= (double)quantity;

                    newMovements.Add(stockMovement);
                }                
            }
        }

        await stockMovementRepository.AddRangeAsync(newMovements, cancellationToken);
        await productionRepository.AddAsync(production, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return "Ürün başarıyla üretildi";
    }
}