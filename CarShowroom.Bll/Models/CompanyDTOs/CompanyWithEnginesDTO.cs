using CarShowroom.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShowroom.Bll.Models
{
    /// <summary>
    /// Company DTO with engines collection
    /// </summary>
    public class CompanyWithEnginesDTO
    {
        /// <summary>
        /// Name of the company. Key property
        /// </summary>
        public string CompanyName { get; set; } = null!;
        /// <summary>
        /// Site of the company
        /// </summary>
        public string? CompanySite { get; set; }
        /// <summary>
        /// Collection of engines
        /// </summary>
        public ICollection<Engine> Engines { get; set; } = new List<Engine>();
    }
}
