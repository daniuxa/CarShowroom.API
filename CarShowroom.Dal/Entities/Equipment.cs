using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShowroom.Dal.Entities
{
    public class Equipment
    {
        /// <summary>
        /// Key ID property
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Name of the equipment
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// Price of equipment
        /// </summary>
        public decimal? Price { get; set; }

        /// <summary>
        /// Foreign key of engine entity
        /// </summary>
        public int EngineId { get; set; }
        /// <summary>
        /// Engine entity
        /// </summary>
        [ForeignKey("EngineId")]
        [Required]
        public Engine Engine { get; set; } = null!;

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
        /// Collection of automobiles which has this equipment
        /// </summary>
        public IEnumerable<Automobile> Automobiles { get; set; } = new List<Automobile>();
    }
}
