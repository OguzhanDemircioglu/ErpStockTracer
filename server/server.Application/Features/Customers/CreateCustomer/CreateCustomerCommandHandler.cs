using AutoMapper;
using GenericRepository;
using MediatR;
using server.Domain.Entities;
using server.Domain.Repositories;
using TS.Result;

namespace server.Application.Features.Customers.CreateCustomer;

public sealed class CreateCustomerCommandHandler(
    ICustomerRepository customerRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper) : IRequestHandler<CreateCustomerCommand, Result<string>>
{
    public async Task<Result<string>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        bool isTaxNumberExist = await customerRepository.AnyAsync(p => p.TaxNumber == request.TaxNumber,
            cancellationToken);

        if (isTaxNumberExist)
        {
            return Result<string>.Failure("Vergi Numarası Zaten Mevcut");
        }

        Customer customer = mapper.Map<Customer>(request);

        await customerRepository.AddAsync(customer, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return "Müşteri Kaydı Başarılı";
    }
}