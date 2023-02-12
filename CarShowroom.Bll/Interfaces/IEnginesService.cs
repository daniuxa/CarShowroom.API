using CarShowroom.Dal.Entities;
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
        Task<Engine?> GetEngineAsync(int engineId);
        Task<Engine?> GetEngineForCompanyAsync(int engineId, string companyName);
        Task<IEnumerable<Engine>> GetEnginesAsync();
        Task<IEnumerable<Engine>> GetEnginesForCompanyAsync(string companyName);
        Task<bool> SaveChangesAsync();
    }
}
