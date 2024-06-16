using AutoMapper;
using GenericRepository;
using MediatR;
using server.Domain.Entities;
using server.Domain.Repositories;
using TS.Result;

namespace server.Application.Features.Customers.UpdateCustomer;

internal sealed class CreateCustomerCommandHandler(
    ICustomerRepository customerRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper) : IRequestHandler<UpdateCustomerCommand, Result<string>>
{
    public async Task<Result<string>> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        Customer customer = await customerRepository.GetByExpressionWithTrackingAsync(p=> p.Id.Equals(request.Id), 
            cancellationToken);

        if (customer is null)
        {
            return Result<string>.Failure("Müşteri Bulunamadı");
        }
        
        mapper.Map(request, customer);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return "Müşteri Kaydı Güncellendi";
    }
}