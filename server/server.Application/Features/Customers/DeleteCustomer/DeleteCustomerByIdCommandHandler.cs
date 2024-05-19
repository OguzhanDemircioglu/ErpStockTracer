using GenericRepository;
using MediatR;
using server.Domain.Entities;
using server.Domain.Repositories;
using TS.Result;

namespace server.Application.Features.Customers.DeleteCustomer;

public sealed class DeleteCustomerByIdCommandHandler
(
    ICustomerRepository customerRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<DeleteCustomerByIdCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(DeleteCustomerByIdCommand request, CancellationToken cancellationToken)
        {
            Customer customer = await customerRepository.GetByExpressionAsync(p=> p.Id == request.Id, 
                cancellationToken);

            if (customer is null)
            {
                return Result<string>.Failure("Müşteri Bulunamadı");
            }

            customerRepository.Delete(customer);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return "Müşteri Kaydı Silindi";
        }
    }