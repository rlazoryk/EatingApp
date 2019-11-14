using AutoMapper;
using EatingApp.Core.DTO;
using EatingApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EatingApp.Core
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<OrderDTO, Order>();

            CreateMap<Order, OrderDTO>();

            CreateMap<OrderItemDTO, OrderItem>();

            CreateMap<OrderItem, OrderItemDTO>();

            CreateMap<ProductDTO, Product>();

            CreateMap<Product, ProductDTO>();

            CreateMap<ProductTypeDTO, ProductType>();

            CreateMap<ProductType, ProductTypeDTO>();

            CreateMap<StatusDTO, Status>();

            CreateMap<Status, StatusDTO>();

            CreateMap<UserDTO, User>()
                .ForMember(destination => destination.FirstName,
                            opt => opt.MapFrom(item => item.FullName.Split(null).GetValue(0)))
                .ForMember(destination => destination.LastName,
                            opt => opt.MapFrom(item => item.FullName.Split(null).GetValue(1)));

            CreateMap<User, UserDTO>()
                .ForMember(destination => destination.FullName,
                           opt => opt.MapFrom(item => item.FirstName + " " + item.LastName));
        }
    }
}
