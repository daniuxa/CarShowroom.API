namespace CarShowroom.Bll.Models
{
    /// <summary>
    /// Engine DTO without property of company name
    /// </summary>
    public class EngineWithoutCompanyDTO
    {
        /// <summary>
        /// Engine name
        /// </summary>
        public string Name { get; set; } = null!;
        /// <summary>
        /// Engine capacity, volume of engine
        /// </summary>
        public double? EngineCapacity { get; set; }
        /// <summary>
        /// Engine power 
        /// </summary>
        public int? Power { get; set; }
        /// <summary>
        /// Engine fuel type. <br/> 
        /// Possible strings: Gasoline, Disel, Electricity, Hydrogen
        /// </summary>
        public string? FuelType { get; set; }
    }
}
