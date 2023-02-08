using AutoMapper;
using CarShowroom.Bll.Models;
using CarShowroom.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShowroom.Bll.Profiles
{
    public class CompaniesProfile : Profile
    {
        public CompaniesProfile()
        {
            CreateMap<Company, CompanyWithoutCollectionsDTO>();
            CreateMap<Company, CompanyWithoutBrandsDTO>();
            CreateMap<Company, CompanyWithoutEnginesDTO>();
            CreateMap<Company, CompanyDTO>();
        }
    }
}
