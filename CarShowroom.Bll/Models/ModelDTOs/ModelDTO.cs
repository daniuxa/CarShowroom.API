using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShowroom.Bll.Models.ModelDTOs
{
    /// <summary>
    /// Model DTO
    /// </summary>
    public class ModelDTO
    {
        /// <summary>
        /// Model Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Model name
        /// </summary>
        public string Name { get; set; } = null!;
    }
}
