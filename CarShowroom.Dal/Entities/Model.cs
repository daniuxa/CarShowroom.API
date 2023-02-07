using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShowroom.Dal.Entities
{
    public class Model
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public int BrandId { get; set; }
        [ForeignKey("BrandId")]
        public Brand Brand { get; set; }
        public IEnumerable<Automobile> Automobiles { get; set; } = new List<Automobile>();
        public IEnumerable<Equipment> Equipments { get; set; } = new List<Equipment>();


        public Model(string name, Brand brand)
        {
            Name = name;
            Brand = brand;
        }
        private Model()
        {

        }
    }
}
