using CarShowroom.Bll.Services;
using CarShowroom.Dal.Entities;

namespace CarShowroom.Bll.Interfaces
{
    /// <summary>
    /// Interface for brands service 
    /// </summary>
    public interface IBrandsService
    {
        /// <summary>
        /// Add brand to database
        /// </summary>
        /// <param name="brand">Brand for adding</param>
        /// <returns>Task class</returns>
        Task AddBrand(Brand brand);
        /// <summary>
        /// Delete entity from data base
        /// </summary>
        /// <param name="brand">Brand for deleting</param>
        void DeleteBrand(Brand brand);
        /// <summary>
        /// Receive brand by Id parameter 
        /// </summary>
        /// <param name="brandId">Id pf brand</param>
        /// <param name="includeModels">include or not models collection</param>
        /// <returns>Brand which we find or null if brand havent't found</returns>
        Task<Brand?> GetBrandAsync(int brandId, bool includeModels = false);
        /// <summary>
        /// Receive paginated collection of brands
        /// </summary>
        /// <param name="pageNumber">Number of page which we wnat to receive</param>
        /// <param name="pageSize">Size of pages</param>
        /// <returns>Collection of brands and data about pagination</returns>
        Task<(IEnumerable<Brand>, PaginationMetadata)> GetBrandsAsync(int pageNumber = 1, int pageSize = 10);
        /// <summary>
        /// Receive collection of brands which are from the same company
        /// </summary>
        /// <param name="companyName">Name of the company</param>
        /// <returns>Collection of brands</returns>
        Task<IEnumerable<Brand>> GetBrandsForCompanyAsync(string companyName);
        /// <summary>
        /// Save changes in data base
        /// </summary>
        /// <returns>true or false, saved successfully or not</returns>
        Task<bool> SaveChangesAsync();
    }
}
