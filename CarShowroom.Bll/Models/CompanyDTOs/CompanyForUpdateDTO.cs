using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShowroom.Bll.Models.CompanyDTOs
{
    public class CompanyForUpdateDTO
    {
        public string CompanyName { get; set; } = null!;
        public string? CompanySite { get; set; }
    }
}
