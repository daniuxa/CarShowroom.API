using AutoMapper;
using CarShowroom.Bll.Models;
using CarShowroom.Bll.Models.EngineDTOs;
using CarShowroom.Dal.Entities;

namespace CarShowroom.Bll.Profiles
{
    /// <summary>
    /// Engines profile for AutoMapper
    /// </summary>
    public class EnginesProfile : Profile
    {
        /// <summary>
        /// Constructor for profiler
        /// </summary>
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
