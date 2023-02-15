using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShowroom.Bll.Models.AutomobilesDTOs
{
    public class AutomobileDTO
    {
        public string VIN { get; set; } = null!;
        public DateTime? ProdDate { get; set; }
        public string? BodyType { get; set; }
        public string? Color { get; set; }
        public string BrandName { get; set; } = null!;
        public string ModelName { get; set; } = null!;
        public string EquipmentName { get; set; } = null!;
    }
}
