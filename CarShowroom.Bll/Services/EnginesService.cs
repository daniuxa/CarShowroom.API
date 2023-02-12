using CarShowroom.Bll.Interfaces;
using CarShowroom.Dal.Contexts;
using CarShowroom.Dal.Entities;
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

        public async Task<IEnumerable<Engine>> GetEnginesAsync()
        {
            return await _carShowroomContext.Engines.ToListAsync();
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
    }
}
