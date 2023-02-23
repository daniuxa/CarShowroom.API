using CarShowroom.Bll.Services;
using CarShowroom.Dal.Entities;
using CarShowroom.Dal.Enums;

namespace CarShowroom.Bll.Interfaces
{
    /// <summary>
    /// Engine service
    /// </summary>
    public interface IEnginesService
    {
        /// <summary>
        /// Add engine to data base
        /// </summary>
        /// <param name="engine">Engine for adding</param>
        /// <returns>Task class</returns>
        Task AddEngineAsync(Engine engine);
        /// <summary>
        /// Delete engine from data base
        /// </summary>
        /// <param name="engine">Engine for deleting</param>
        void DeleteEngine(Engine engine);
        /// <summary>
        /// Receive engine from data base by Id
        /// </summary>
        /// <param name="engineId">Id of engine</param>
        /// <returns>Engine or null if haven't been found</returns>
        Task<Engine?> GetEngineAsync(int engineId);
        /// <summary>
        /// Receive engine by engine Id and company name
        /// </summary>
        /// <param name="engineId">Id of engine</param>
        /// <param name="companyName">Name of the company</param>
        /// <returns>Engine or null if haven't been found</returns>
        Task<Engine?> GetEngineForCompanyAsync(int engineId, string companyName);
        /// <summary>
        /// Receive collection of engines
        /// </summary>
        /// <param name="pageNumber">Number of page which we wnat to receive</param>
        /// <param name="pageSize">Size of pages</param>
        /// <param name="orderEngine">Order engines by parameters or not order if orderEngine == null</param>
        /// <returns>Collection of engines and data about pagination</returns>
        Task<(IEnumerable<Engine>, PaginationMetadata)> GetEnginesAsync(int pageNumber = 1, int pageSize = 10, OrderEngineBy? orderEngine = null);
        /// <summary>
        /// Receive engines from company
        /// </summary>
        /// <param name="companyName">Nsme of the company</param>
        /// <returns>Collection of engines</returns>
        Task<IEnumerable<Engine>> GetEnginesForCompanyAsync(string companyName);
        /// <summary>
        /// Save changes in data base
        /// </summary>
        /// <returns>true or false, saved successfully or not</returns>
        Task<bool> SaveChangesAsync();
    }
}
