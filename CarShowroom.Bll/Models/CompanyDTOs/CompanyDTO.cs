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
        public IEnumerable<EngineWithoutCompanyDTO> Engines { get; set; } = new List<EngineWithoutCompanyDTO>();
        public IEnumerable<Brand> Brands { get; set; } = new List<Brand>();
    }
}
