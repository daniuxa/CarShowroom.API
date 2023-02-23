using AutoMapper;
using CarShowroom.Bll.Models.ModelDTOs;
using CarShowroom.Dal.Entities;

namespace CarShowroom.Bll.Profiles
{
    /// <summary>
    /// Models profile for AutoMapper
    /// </summary>
    public class ModelsProfile : Profile
    {
        /// <summary>
        /// Constructor for profiler
        /// </summary>
        public ModelsProfile()
        {
            CreateMap<Model, ModelDTO>();
        }
    }
}
