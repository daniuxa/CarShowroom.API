using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarShowroom.Dal.Entities
{
    /// <summary>
    /// Automobile class
    /// </summary>
    public class Automobile
    {
        /// <summary>
        /// Key property VIN code which has length 17 characters
        /// </summary>
        [Key]
        [StringLength(17)]
        public string VIN { get; set; } = null!;

        /// <summary>
        /// Date of production of this automobile
        /// </summary>
        public DateTime? ProdDate { get; set; }

        /// <summary>
        /// Type of body, enum property
        /// </summary>
        public BodyType? BodyType { get; set; }

        /// <summary>
        /// Color which has automobile, enum property
        /// </summary>
        public Color? Color { get; set; }

        /// <summary>
        /// Foreign key of brand entity
        /// </summary>
        public int BrandId { get; set; }
        /// <summary>
        /// Brand entity
        /// </summary>
        [ForeignKey("BrandId")]
        [Required]
        public Brand Brand { get; set; } = null!;

        /// <summary>
        /// Foreign key of model entity
        /// </summary>
        public int ModelId { get; set; }
        /// <summary>
        /// Model entity
        /// </summary>
        [ForeignKey("ModelId")]
        [Required]
        public Model Model { get; set; } = null!;

        /// <summary>
        /// Foreign key of equipment entity
        /// </summary>
        public int EquipmentId { get; set; }
        /// <summary>
        /// Equipment entity
        /// </summary>
        [ForeignKey("EquipmentId")]
        [Required]
        public Equipment Equipment { get; set; } = null!;
    }
}
