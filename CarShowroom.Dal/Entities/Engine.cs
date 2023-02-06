using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShowroom.Dal.Entities
{
    public class Engine
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [DefaultValue(0)]
        public double? EngineCapacity { get; set; }
        public int? Power { get; set; }
        public FuelType? FuelType { get; set; }

        public string? CompanyName { get; set; }
        [ForeignKey("CompanyName")]
        public Company? Company { get; set; }
        public IEnumerable<Equipment> Equipments { get; set; } = new List<Equipment>();

        public Engine(string name)
        {
            Name = name;
        }
    }
}
