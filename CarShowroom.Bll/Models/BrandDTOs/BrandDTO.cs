namespace CarShowroom.Bll.Models.BrandDTOs
{
    /// <summary>
    /// Brand DTO
    /// </summary>
    public class BrandDTO
    {
        /// <summary>
        /// Brand Id
        /// </summary>
        public int Id { get; set; }
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
