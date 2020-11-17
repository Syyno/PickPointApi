using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PickPointAPI.Models;
using PickPointAPI.Models.DTO.Order_DTO_s;

namespace PickPointAPI.Util
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<OrderStore, OrderUpdate>();
            CreateMap<OrderUpdate, OrderStore>();

            CreateMap<OrderStore, OrderReturn>();
            CreateMap<OrderReturn, OrderStore>();

            CreateMap<OrderReturn, OrderUpdate>();
            CreateMap<OrderUpdate, OrderReturn>();

            CreateMap<OrderStore, OrderCreate>();
            CreateMap<OrderCreate, OrderStore>();
        }
    }
}
