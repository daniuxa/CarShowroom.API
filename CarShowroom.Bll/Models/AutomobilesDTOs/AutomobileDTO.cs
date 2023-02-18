using CarShowroom.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShowroom.Bll.Models.AutomobilesDTOs
{
    /// <summary>
    /// Automobile DTO 
    /// </summary>
    public class AutomobileDTO
    {
        /// <summary>
        /// Key property VIN code, string length is 17 characters
        /// </summary>
        public string VIN { get; set; } = null!;
        /// <summary>
        /// Date of production of this automobile
        /// </summary>
        public DateTime? ProdDate { get; set; }
        /// <summary>
        /// Type of body of car. <br/>
        /// Possible strings: Sedan, Coupe, Wagon, Hatchback, SUV
        /// </summary>
        public string? BodyType { get; set; }
        /// <summary>
        /// Color of car. <br/>
        /// Possible strings: White, Black, Grey, Brown, Blue
        /// </summary>
        public string? Color { get; set; }
        /// <summary>
        /// Name of brand which is taken from brand entity
        /// </summary>
        public string BrandName { get; set; } = null!;
        /// <summary>
        /// Name of model which is taken from model entity
        /// </summary>
        public string ModelName { get; set; } = null!;
        /// <summary>
        /// Name of equipment which is taken from equipment entity
        /// </summary>
        public string EquipmentName { get; set; } = null!;
    }
}
