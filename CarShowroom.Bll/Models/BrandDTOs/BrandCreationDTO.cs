namespace CarShowroom.Bll.Models.BrandDTOs
{
    /// <summary>
    /// Brand DTO for creation brand
    /// </summary>
    public class BrandCreationDTO
    {
        /// <summary>
        /// Brand name
        /// </summary>
        public string Name { get; set; } = null!;
        /// <summary>
        /// Name of the company. Company entity foreign key 
        /// </summary>
        public string? CompanyName { get; set; }
    }
}
