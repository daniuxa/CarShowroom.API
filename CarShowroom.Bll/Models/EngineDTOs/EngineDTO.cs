namespace CarShowroom.Bll.Models.EngineDTOs
{
    /// <summary>
    /// Engine DTO
    /// </summary>
    public class EngineDTO
    {
        /// <summary>
        /// Engine Id
        /// </summary>
        public int Id { get; set; }
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
        /// <summary>
        /// Company name. Company entity foreign key 
        /// </summary>
        public string? CompanyName { get; set; }
    }
}
