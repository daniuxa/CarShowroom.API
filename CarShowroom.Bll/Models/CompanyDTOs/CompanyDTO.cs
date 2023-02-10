using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShowroom.Bll.Models
{
    public class CompanyDTO
    {
        public string CompanyName { get; set; } = null!;
        public string? CompanySite { get; set; }
        public IEnumerable<EngineDTO> Engines { get; set; } = new List<EngineDTO>();
        public IEnumerable<BrandDTO> Brands { get; set; } = new List<BrandDTO>();
    }
}
