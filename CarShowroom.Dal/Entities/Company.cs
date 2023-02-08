using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShowroom.Dal.Entities
{
    public class Company
    {
        [Key]
        [MaxLength(100)]
        public string CompanyName { get; set; } = null!;
        [MaxLength(50)]
        public string? CompanySite { get; set; }
        public IEnumerable<Engine> Engines { get; set; } = new List<Engine>();
        public IEnumerable<Brand> Brands { get; set; } = new List<Brand>();
    }
}
