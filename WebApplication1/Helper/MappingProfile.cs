using AutoMapper;
using Taskk.Core.DataTransferObjects;
using Taskk.Core.Entites;

namespace WebApplication1.Helper

{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            //customer map
            CreateMap<Customer, CustomerToReturnDto>()/*.
                ForMember(destination => destination.Orders, opt => opt.MapFrom(source => source.Orders))*/.ReverseMap();
            //order map
            CreateMap<Order, OrderToReturnDto>()/*
                .ForMember(destination => destination.Customer, opt => opt.MapFrom(source=>source.Customer.Name))*/.ReverseMap();
           /* CreateMap<Order, OrderToReturnDto>()
                .ForMember(destination => destination.OrderItems, opt => opt.MapFrom(source => source.OrderItems));*/
            //product map
            CreateMap<Product, ProductToReturnDto>().ReverseMap();
            //invoice map
            CreateMap<Invoice, InvoiceToReturnDto>();




        }
    }
}
