using CarShowroom.Dal.Entities;

namespace CarShowroom.Bll.Models
{
    /// <summary>
    /// Company DTO with brands collection
    /// </summary>
    public class CompanyWithBrandsDTO
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
        /// Collection of brands
        /// </summary>
        public ICollection<Brand> Brands { get; set; } = new List<Brand>();
    }
}
