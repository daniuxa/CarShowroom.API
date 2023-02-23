using CarShowroom.Bll.Interfaces;
using CarShowroom.Dal;
using CarShowroom.Dal.Contexts;
using CarShowroom.Dal.Entities;
using CarShowroom.Dal.Enums;
using Microsoft.EntityFrameworkCore;

namespace CarShowroom.Bll.Services
{
    /// <summary>
    /// Engine service
    /// </summary>
    public class EnginesService : IEnginesService
    {
        private readonly CarShowroomContext _carShowroomContext;

        /// <summary>
        /// Constructor of class
        /// </summary>
        /// <param name="carShowroomContext">Car Showroom data base context</param>
        /// <exception cref="ArgumentNullException">If carShowroom == null</exception>
        public EnginesService(CarShowroomContext carShowroomContext)
        {
            _carShowroomContext = carShowroomContext ?? throw new ArgumentNullException(nameof(carShowroomContext));
        }
        /// <summary>
        /// Receive engines from company
        /// </summary>
        /// <param name="companyName">Nsme of the company</param>
        /// <returns>Collection of engines</returns>
        public async Task<IEnumerable<Engine>> GetEnginesForCompanyAsync(string companyName)
        {
            return await _carShowroomContext.Engines.Where(x => x.CompanyName == companyName).ToListAsync();
        }
        /// <summary>
        /// Receive engine by engine Id and company name
        /// </summary>
        /// <param name="engineId">Id of engine</param>
        /// <param name="companyName">Name of the company</param>
        /// <returns>Engine or null if haven't been found</returns>
        public async Task<Engine?> GetEngineForCompanyAsync(int engineId, string companyName)
        {
            return await _carShowroomContext.Engines.FirstOrDefaultAsync(x => x.Id == engineId && x.CompanyName == companyName);
        }
        /// <summary>
        /// Receive collection of engines
        /// </summary>
        /// <param name="pageNumber">Number of page which we wnat to receive</param>
        /// <param name="pageSize">Size of pages</param>
        /// <param name="orderEngine">Order engines by parameters or not order if orderEngine == null</param>
        /// <returns>Collection of engines and data about pagination</returns>
        public async Task<(IEnumerable<Engine>, PaginationMetadata)> GetEnginesAsync(int pageNumber = 1, int pageSize = 10, OrderEngineBy? orderEngine = null)
        {
            var collection = _carShowroomContext.Engines as IQueryable<Engine>;

            var totalItemCount = await collection.CountAsync();

            var paginationMetadata = new PaginationMetadata(totalItemCount, pageSize, pageNumber);

            var paginatedCollection = await collection.GetPaginatedEnginesAsync(pageNumber, pageSize);


            if (orderEngine == null)
            {
                return (paginatedCollection, paginationMetadata);
            }

            var propertyInfo = typeof(Engine).GetProperty(orderEngine.ToString()!);

            if (propertyInfo == null)
            {
                throw new ArgumentException($"Property {orderEngine} not found on type {typeof(Engine).Name}");
            }

            var orderedPaginatedCollection = paginatedCollection.OrderBy(x => propertyInfo.GetValue(x));

            return (orderedPaginatedCollection, paginationMetadata);
        }
        /// <summary>
        /// Receive engine from data base by Id
        /// </summary>
        /// <param name="engineId">Id of engine</param>
        /// <returns>Engine or null if haven't been found</returns>
        public async Task<Engine?> GetEngineAsync(int engineId)
        {
            return await _carShowroomContext.Engines.FirstOrDefaultAsync(x => x.Id == engineId);
        }
        /// <summary>
        /// Add engine to data base
        /// </summary>
        /// <param name="engine">Engine for adding</param>
        /// <returns>Task class</returns>
        public async Task AddEngineAsync(Engine engine)
        {
            await _carShowroomContext.Engines.AddAsync(engine);
        }
        /// <summary>
        /// Save changes in data base
        /// </summary>
        /// <returns>true or false, saved successfully or not</returns>
        public async Task<bool> SaveChangesAsync()
        {
            return (await _carShowroomContext.SaveChangesAsync() >= 0);
        }
        /// <summary>
        /// Delete engine from data base
        /// </summary>
        /// <param name="engine">Engine for deleting</param>
        public void DeleteEngine(Engine engine)
        {
            _carShowroomContext.Engines.Remove(engine);
        }
    }
}
