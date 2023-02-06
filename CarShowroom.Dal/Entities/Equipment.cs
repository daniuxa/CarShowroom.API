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
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public int EngineId { get; set; }
        public Engine Engine { get; set; }
        public int ModelId { get; set; }
        public Model Model { get; set; }

        public Equipment(string name, Engine engine, Model model)
        {
            Name = name;
            Engine = engine;
            Model = model;
        }
    }
}
