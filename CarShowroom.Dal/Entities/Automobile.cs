using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShowroom.Dal.Entities
{
    public class Automobile
    {
        [Key]
        [StringLength(17)]
        public string VIN { get; set; } = null!;
        public DateTime? ProdDate { get; set; }
        public BodyType? BodyType { get; set; }
        public Color? Color { get; set; }

        public int BrandId { get; set; }
        [ForeignKey("BrandId")]
        [Required]
        public Brand Brand { get; set; } = null!;

        public int ModelId { get; set; }
        [ForeignKey("ModelId")]
        [Required]
        public Model Model { get; set; } = null!;

        public int EquipmentId { get; set; }
        [ForeignKey("EquipmentId")]
        [Required]
        public Equipment Equipment { get; set; } = null!;

/*        public Automobile(string vin, Brand brand, Model model, Equipment equipment)
        {
            VIN = vin;
            Brand = brand;
            Model = model;
            Equipment = equipment;
        }
        private Automobile()
        {

        }*/
    }
}
