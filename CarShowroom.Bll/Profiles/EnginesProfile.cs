using AutoMapper;
using CarShowroom.Bll.Models;
using CarShowroom.Bll.Models.EngineDTOs;
using CarShowroom.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShowroom.Bll.Profiles
{
    public class EnginesProfile : Profile
    {
        public EnginesProfile()
        {
            CreateMap<Engine, EngineWithoutCompanyDTO>();
            CreateMap<Engine, EngineDTO>();
            CreateMap<Engine, EngineForUpdateDTO>();
            CreateMap<EngineForUpdateDTO, Engine>();
            CreateMap<EngineCreationDTO, Engine>();
        }
    }
}
