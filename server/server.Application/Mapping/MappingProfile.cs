using AutoMapper;
using server.Application.Features.Customers.CreateCustomer;
using server.Application.Features.Customers.UpdateCustomer;
using server.Application.Features.Depots.CreateDepot;
using server.Domain.Entities;

namespace server.Application.Mapping;

public sealed class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateCustomerCommand, Customer>();
        CreateMap<UpdateCustomerCommand, Customer>();

        CreateMap<CreateDepotCommand, Depot>();
        CreateMap<UpdateCustomerCommand, Depot>();
    }
}