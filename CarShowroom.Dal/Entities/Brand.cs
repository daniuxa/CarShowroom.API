using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShowroom.Dal.Entities
{
    public class Brand
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public string? CompanyName { get; set; }
        [ForeignKey("CompanyName")]
        public Company? Company { get; set; }
        public IEnumerable<Automobile> Automobiles { get; set; } = new List<Automobile>();
        public IEnumerable<Model> Models { get; set; } = new List<Model>();
    }
}
