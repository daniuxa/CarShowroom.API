namespace CarShowroom.Bll.Models
{
    /// <summary>
    /// Company DTO
    /// </summary>
    public class CompanyDTO
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
