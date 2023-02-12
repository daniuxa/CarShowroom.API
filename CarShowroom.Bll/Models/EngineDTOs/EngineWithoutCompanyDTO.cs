using CarShowroom.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShowroom.Bll.Models
{
    public class EngineWithoutCompanyDTO
    {
        public string Name { get; set; } = null!;
        public double? EngineCapacity { get; set; }
        public int? Power { get; set; }
        public string? FuelType { get; set; }
    }
}
