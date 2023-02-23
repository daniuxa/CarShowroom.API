namespace CarShowroom.Bll.Models.BrandDTOs
{
    /// <summary>
    /// Brand DTO for update brand entity
    /// </summary>
    public class BrandUpdateDTO
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
