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

        public int BrandId { get; set; }
        public Brand Brand { get; set; } = null!;

        public int ModelId { get; set; }
        [ForeignKey("ModelId")]
        [Required]
        public Model Model { get; set; } = null!;

        public int EquipmentId { get; set; }
        [ForeignKey("EquipmentId")]
        [Required]
        public Equipment Equipment { get; set; } = null!;
    }
}
