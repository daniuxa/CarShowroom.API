using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShowroom.Bll.Models.BrandDTOs
{
    public class BrandCreationDTO
    {
        public string Name { get; set; } = null!;
        public string? CompanyName { get; set; }
    }
}
