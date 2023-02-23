using AutoMapper;
using CarShowroom.Bll.Models;
using CarShowroom.Bll.Models.BrandDTOs;
using CarShowroom.Dal.Entities;

namespace CarShowroom.Bll.Profiles
{
    /// <summary>
    /// Brands profile for AutoMapper
    /// </summary>
    public class BrandsProfile : Profile
    {
        /// <summary>
        /// Constructor for profiler
        /// </summary>
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
