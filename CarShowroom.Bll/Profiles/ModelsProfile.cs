using AutoMapper;
using CarShowroom.Bll.Models.ModelDTOs;
using CarShowroom.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShowroom.Bll.Profiles
{
    public class ModelsProfile : Profile
    {
        public ModelsProfile()
        {
            CreateMap<Model, ModelDTO>();
        }
    }
}
