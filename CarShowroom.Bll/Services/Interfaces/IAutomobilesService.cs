using CarShowroom.Bll.Services;
using CarShowroom.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShowroom.Bll.Interfaces
{
    /// <summary>
    /// Interface for automobiles service
    /// </summary>
    public interface IAutomobilesService
    {
        /// <summary>
        /// Receiving automobiles from data base with pagination
        /// </summary>
        /// <param name="pageNumber">Number of which page we want to receive</param>
        /// <param name="pageSize">Size of pages</param>
        /// <returns>Collection of automobiles and data about pagination</returns>
        Task<(IEnumerable<Automobile>, PaginationMetadata)> GetAutomobilesAsync(int pageNumber = 1, int pageSize = 10);
    }
}
