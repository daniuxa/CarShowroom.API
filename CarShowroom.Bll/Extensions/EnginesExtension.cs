using CarShowroom.Dal.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarShowroom.Dal
{
    /// <summary>
    /// Class for extensions different collections which works with an engine entity
    /// </summary>
    public static class EnginesExtension
    {
        /// <summary>
        /// Extension methode which return paginated collection
        /// </summary>
        /// <param name="collection">Collection of engines</param>
        /// <param name="pageNumber">Number of which page we want to return</param>
        /// <param name="pageSize">Size of pages</param>
        /// <returns>Paginated collection</returns>
        public static async Task<IEnumerable<Engine>> GetPaginatedEnginesAsync(this IQueryable<Engine> collection, int pageNumber = 1, int pageSize = 10)
        {
            return await collection.
                 Skip(pageSize * (pageNumber - 1)).
                 Take(pageSize).ToListAsync();
        }
    }
}
