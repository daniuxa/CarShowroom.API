using CarShowroom.Bll.Models.ModelDTOs;

namespace CarShowroom.Bll.Models.BrandDTOs
{
    /// <summary>
    /// Brand DTO which contain Model DTOs collection
    /// </summary>
    public class BrandWithModelsDTO
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
        /// <summary>
        /// Collection of Model DTOs
        /// </summary>
        public IEnumerable<ModelDTO> Models { get; set; } = new List<ModelDTO>();
    }
}
