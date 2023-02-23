using AutoMapper;
using CarShowroom.Bll.Models.AutomobilesDTOs;
using CarShowroom.Dal.Entities;

namespace CarShowroom.Bll.Profiles
{
    /// <summary>
    /// Automobiles profile for AutoMapper
    /// </summary>
    public class AutomobilesProfile : Profile
    {
        /// <summary>
        /// Constructor for profiler
        /// </summary>
        public AutomobilesProfile()
        {
            CreateMap<Automobile, AutomobileDTO>()
                .ForMember(destination => destination.ModelName,
                member => member.MapFrom(source => source.Model.Name))
                .ForMember(destination => destination.BrandName,
                member => member.MapFrom(source => source.Brand.Name))
                .ForMember(destination => destination.EquipmentName,
                member => member.MapFrom(source => source.Equipment.Name));
        }
    }
}
