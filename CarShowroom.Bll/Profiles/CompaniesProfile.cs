using AutoMapper;
using CarShowroom.Bll.Models;
using CarShowroom.Bll.Models.CompanyDTOs;
using CarShowroom.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShowroom.Bll.Profiles
{
    /// <summary>
    /// Companies profile for AutoMapper
    /// </summary>
    public class CompaniesProfile : Profile
    {
        /// <summary>
        /// Constructor for profiler
        /// </summary>
        public CompaniesProfile()
        {
            CreateMap<Company, CompanyWithCollectionsDTO>();
            CreateMap<Company, CompanyWithEnginesDTO>();
            CreateMap<Company, CompanyWithBrandsDTO>();
            CreateMap<Company, CompanyDTO>();
            CreateMap<CompanyCreationDTO, Company>();
            CreateMap<CompanyForUpdateDTO, Company>();
        }
    }
}
