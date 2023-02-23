using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarShowroom.Dal.Entities
{
    /// <summary>
    /// Model class
    /// </summary>
    public class Model
    {
        /// <summary>
        /// Key ID property
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Name of model
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = null!;

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
        /// Collection of automobiles which has this model
        /// </summary>
        public IEnumerable<Automobile> Automobiles { get; set; } = new List<Automobile>();
        /// <summary>
        /// Collection of equipments which has this models
        /// </summary>
        public IEnumerable<Equipment> Equipments { get; set; } = new List<Equipment>();
    }
}
