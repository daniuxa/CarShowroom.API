using System.ComponentModel.DataAnnotations;

namespace CarShowroom.Dal.Entities
{
    /// <summary>
    /// Company class
    /// </summary>
    public class Company
    {
        /// <summary>
        /// Key property name of company
        /// </summary>
        [Key]
        [MaxLength(100)]
        public string CompanyName { get; set; } = null!;

        /// <summary>
        /// Site of company
        /// </summary>
        [MaxLength(50)]
        public string? CompanySite { get; set; }

        /// <summary>
        /// Collection of engines which has company entity
        /// </summary>
        public IEnumerable<Engine> Engines { get; set; } = new List<Engine>();
        /// <summary>
        /// Collection of brands which has company entity
        /// </summary>
        public IEnumerable<Brand> Brands { get; set; } = new List<Brand>();
    }
}
