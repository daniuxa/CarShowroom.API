using CarShowroom.Bll.Services;
using CarShowroom.Dal.Entities;

namespace CarShowroom.Bll.Interfaces
{
    /// <summary>
    /// Interface for companies service
    /// </summary>
    public interface ICompaniesService
    {
        /// <summary>
        /// Add company to data base 
        /// </summary>
        /// <param name="company">Company which we want to add</param>
        /// <returns>Task class</returns>
        Task AddCompanyAsync(Company company);
        /// <summary>
        /// Delete the company from data base
        /// </summary>
        /// <param name="company">Company for deleting</param>
        void DeleteCompany(Company company);
        /// <summary>
        /// Receive paginated companies collection from data base
        /// </summary>
        /// <param name="pageNumber">Number of page which we wnat to receive</param>
        /// <param name="pageSize">Size of pages</param>
        /// <returns>Collection of companies and data about pagination</returns>
        Task<(IEnumerable<Company>, PaginationMetadata)> GetCompaniesAsync(int pageNumber, int pageSize);
        /// <summary>
        /// Receive company by name
        /// </summary>
        /// <param name="companyName">Company name</param>
        /// <param name="includeEngines">Include engines collection or not</param>
        /// <param name="includeBrands">Include brands collection or not</param>
        /// <returns>Company or null if company haven't been found</returns>
        Task<Company?> GetCompanyAsync(string companyName, bool includeEngines = false, bool includeBrands = false);
        /// <summary>
        /// Chech existing of company
        /// </summary>
        /// <param name="companyName">Company name</param>
        /// <returns>True - found, False - not found</returns>
        Task<bool> IsExistCompanyAsync(string companyName);
        /// <summary>
        /// Save changes in data base
        /// </summary>
        /// <returns>true or false, saved successfully or not</returns>
        Task<bool> SaveChangesAsync();
    }
}
