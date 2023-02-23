using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarShowroom.Dal.Entities
{
    /// <summary>
    /// Engine class
    /// </summary>
    public class Engine
    {
        /// <summary>
        /// Key ID property 
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Name of engine
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = null!;

        /// <summary>
        /// Capacity of engine
        /// </summary>
        [DefaultValue(0)]
        public double? EngineCapacity { get; set; }

        /// <summary>
        /// Power of engine
        /// </summary>
        public int? Power { get; set; }

        /// <summary>
        /// Type of fuel which use engine, enum property
        /// </summary>
        public FuelType? FuelType { get; set; }

        /// <summary>
        /// Foreign key of company entity
        /// </summary>
        public string? CompanyName { get; set; }
        /// <summary>
        /// Company entity
        /// </summary>
        [ForeignKey("CompanyName")]
        public Company? Company { get; set; }

        /// <summary>
        /// Collection of equipments which has this engine
        /// </summary>
        public IEnumerable<Equipment> Equipments { get; set; } = new List<Equipment>();
    }
}
