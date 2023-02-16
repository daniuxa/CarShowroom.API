using CarShowroom.Bll.Interfaces;
using CarShowroom.Dal;
using CarShowroom.Dal.Contexts;
using CarShowroom.Dal.Entities;
using CarShowroom.Dal.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShowroom.Bll.Services
{
    public class EnginesService : IEnginesService
    {
        private readonly CarShowroomContext _carShowroomContext;

        public EnginesService(CarShowroomContext carShowroomContext)
        {
            _carShowroomContext = carShowroomContext ?? throw new ArgumentNullException(nameof(carShowroomContext));
        }
        public async Task<IEnumerable<Engine>> GetEnginesForCompanyAsync(string companyName)
        {
            return await _carShowroomContext.Engines.Where(x => x.CompanyName == companyName).ToListAsync();
        }
        public async Task<Engine?> GetEngineForCompanyAsync(int engineId, string companyName)
        {
            return await _carShowroomContext.Engines.FirstOrDefaultAsync(x => x.Id == engineId && x.CompanyName == companyName);
        }

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

        public async Task<Engine?> GetEngineAsync(int engineId)
        {
            return await _carShowroomContext.Engines.FirstOrDefaultAsync(x => x.Id == engineId);
        }

        public async Task AddEngine(Engine engine)
        {
            await _carShowroomContext.Engines.AddAsync(engine);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _carShowroomContext.SaveChangesAsync() >= 0);
        }

        public void DeleteEngine(Engine engine)
        {
            _carShowroomContext.Engines.Remove(engine);
        }
    }
}
