using AutoMapper;
using GenericRepository;
using MediatR;
using server.Domain.Entities;
using server.Domain.Repositories;
using TS.Result;

namespace server.Application.Features.Invoices.CreateInvoice;

internal sealed class CreateInvoiceCommandHandler(
    IInvoiceRepository repository,
    IUnitOfWork unitOfWork,
    IMapper mapper) : IRequestHandler<CreateInvoiceCommand, Result<string>>
{
    public async Task<Result<string>> Handle(CreateInvoiceCommand request, CancellationToken cancellationToken)
    {
        Invoice order = mapper.Map<Invoice>(request);
        
        await repository.AddAsync(order, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return "Fatura İşlemi Başarlı";
    }
}