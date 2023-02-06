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
        public string CompanyName { get; set; }
        [MaxLength(50)]
        public string? CompanySite { get; set; }
        public Company(string companyName)
        {
            CompanyName = companyName;
        }
    }
}
