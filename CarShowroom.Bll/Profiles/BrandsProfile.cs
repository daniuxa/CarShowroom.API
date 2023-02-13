using AutoMapper;
using CarShowroom.Bll.Models;
using CarShowroom.Bll.Models.BrandDTOs;
using CarShowroom.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShowroom.Bll.Profiles
{
    public class BrandsProfile : Profile
    {
        public BrandsProfile()
        {
            CreateMap<Brand, BrandWithoutCompNameDTO>();
            CreateMap<Brand, BrandDTO>();
            CreateMap<Brand, BrandWithModelsDTO>();
            CreateMap<Brand, BrandUpdateDTO>();
            CreateMap<BrandUpdateDTO, Brand>();
            CreateMap<BrandCreationDTO, Brand>();
        }
    }
}
