using CarShowroom.Bll.Models.ModelDTOs;
using CarShowroom.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShowroom.Bll.Models.BrandDTOs
{
    public class BrandWithModelsDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? CompanyName { get; set; }
        public IEnumerable<ModelDTO> Models { get; set; } = new List<ModelDTO>();
    }
}
