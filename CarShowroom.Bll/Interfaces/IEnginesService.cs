using CarShowroom.Bll.Services;
using CarShowroom.Dal.Entities;
using CarShowroom.Dal.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShowroom.Bll.Interfaces
{
    public interface IEnginesService
    {
        Task AddEngine(Engine engine);
        void DeleteEngine(Engine engine);
        Task<Engine?> GetEngineAsync(int engineId);
        Task<Engine?> GetEngineForCompanyAsync(int engineId, string companyName);
        Task<(IEnumerable<Engine>, PaginationMetadata)> GetEnginesAsync(int pageNumber = 1, int pageSize = 10, OrderEngineBy? orderEngine = null);
        Task<IEnumerable<Engine>> GetEnginesForCompanyAsync(string companyName);
        Task<bool> SaveChangesAsync();
    }
}
