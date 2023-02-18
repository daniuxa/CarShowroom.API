using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShowroom.Bll.Models
{
    /// <summary>
    /// Brand DTO which doesn't contain name of the company
    /// </summary>
    public class BrandWithoutCompNameDTO
    {
        /// <summary>
        /// Brand Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Brand name
        /// </summary>
        public string Name { get; set; } = null!;
    }
}
