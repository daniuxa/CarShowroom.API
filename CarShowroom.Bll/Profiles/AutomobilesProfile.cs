using AutoMapper;
using CarShowroom.Bll.Models.AutomobilesDTOs;
using CarShowroom.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShowroom.Bll.Profiles
{
    public class AutomobilesProfile : Profile
    {
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
