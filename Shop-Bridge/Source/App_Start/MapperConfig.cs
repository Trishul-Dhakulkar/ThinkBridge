using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Shop_Bridge.Dtos;
using Shop_Bridge.Models;

namespace Shop_Bridge.App_Start
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            Mapper.CreateMap<Product, ProductDto>();
            Mapper.CreateMap<ProductDto, Product>();
        }
    }
}