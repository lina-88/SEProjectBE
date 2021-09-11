using SEProjectBE.Help.Dto;
using SEProjectBE.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEProjectBE.Help
{
    public class AutoMapperProfiles : Profile
    {
          public AutoMapperProfiles()
        {

            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<CartItem, CartItemDto>().ReverseMap();


        }





    }
}
