﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShowroom.Bll.Models.EngineDTOs
{
    public class EngineDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public double? EngineCapacity { get; set; }
        public int? Power { get; set; }
        public string? FuelType { get; set; }
        public string? CompanyName { get; set; }
    }
}
