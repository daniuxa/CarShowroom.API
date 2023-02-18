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
