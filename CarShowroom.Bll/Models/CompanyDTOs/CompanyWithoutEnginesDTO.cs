using CarShowroom.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShowroom.Bll.Models
{
    public class CompanyWithoutEnginesDTO
    {
        public string CompanyName { get; set; } = null!;
        public string? CompanySite { get; set; }

        public ICollection<BrandDTO> Brands { get; set; } = new List<BrandDTO>();
    }
}
