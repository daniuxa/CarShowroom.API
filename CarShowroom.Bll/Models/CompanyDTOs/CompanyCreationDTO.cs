using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShowroom.Bll.Models.CompanyDTOs
{
    /// <summary>
    /// Company DTO for creation
    /// </summary>
    public class CompanyCreationDTO
    {
        /// <summary>
        /// Name of the company. Key property
        /// </summary>
        public string CompanyName { get; set; } = null!;
        /// <summary>
        /// Site of the company
        /// </summary>
        public string? CompanySite { get; set; }
    }
}
