using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShowroom.Bll.Models
{
    /// <summary>
    /// Company DTO with collections of engines and brands
    /// </summary>
    public class CompanyWithCollectionsDTO
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
        public IEnumerable<EngineWithoutCompanyDTO> Engines { get; set; } = new List<EngineWithoutCompanyDTO>();
        /// <summary>
        /// Collection of brands
        /// </summary>
        public IEnumerable<BrandWithoutCompNameDTO> Brands { get; set; } = new List<BrandWithoutCompNameDTO>();
    }
}
