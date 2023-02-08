using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShowroom.Bll.Models
{
    public class CompanyDTO
    {
        public string CompanyName { get; set; } = null!;
        public string? CompanySite { get; set; }
    }
}
