using AutoMapper;
using server.Application.Features.Customers.CreateCustomer;
using server.Application.Features.Customers.UpdateCustomer;
using server.Application.Features.Depots.CreateDepot;
using server.Application.Features.Depots.UpdateDepot;
using server.Application.Features.Product.CreateProduct;
using server.Domain.Entities;

namespace server.Application.Mapping;

public sealed class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateCustomerCommand, Customer>();
        CreateMap<UpdateCustomerCommand, Customer>();

        CreateMap<CreateDepotCommand, Depot>();
        CreateMap<UpdateDepotCommand, Depot>();

        CreateMap<CreateProductCommand, Product>()
            .ForMember(m => m.Type, opt => opt.MapFrom(x => x.TypeValue));
            
        CreateMap<UpdateDepotCommand, Depot>();
    }
}