using AutoMapper;
using OnlineShop.Core.Entities;
using OnlineShop.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Service.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductModel>().ReverseMap();
            CreateMap<Order, OrderModel>().ReverseMap();
            CreateMap<Address, AddressModel>().ReverseMap();
            CreateMap<Category, CategoryModel>().ReverseMap();
            CreateMap<Customer, CustomerModel>().ReverseMap();
        }
    }
}
