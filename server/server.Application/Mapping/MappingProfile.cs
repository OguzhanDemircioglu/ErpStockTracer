using AutoMapper;
using server.Application.Features.Customers.CreateCustomer;
using server.Domain.Entities;

namespace server.Application.Mapping;

public sealed class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateCustomerCommand, Customer>();
    }
}