using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShowroom.Dal.Entities
{
    /// <summary>
    /// Brand class
    /// </summary>
    public class Brand
    {
        /// <summary>
        /// Key ID of brand class
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Name of brand
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = null!;

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
        /// Collection of automobiles which has this brand
        /// </summary>
        public IEnumerable<Automobile> Automobiles { get; set; } = new List<Automobile>();

        /// <summary>
        /// Collection of models which has this brand
        /// </summary>
        public IEnumerable<Model> Models { get; set; } = new List<Model>();
    }
}
