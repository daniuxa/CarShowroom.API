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
    public class AutomobilesService : IAutomobileService
    {
        private readonly CarShowroomContext _carShowroomContext;

        public AutomobilesService(CarShowroomContext carShowroomContext)
        {
            _carShowroomContext = carShowroomContext;
        }
        public async Task<(IEnumerable<Automobile>, PaginationMetadata)> GetAutomobilesAsync(int pageNumber = 1, int pageSize = 10)
        {
            var collection = _carShowroomContext.Automobiles
                .Include(x => x.Brand)
                .Include(x => x.Model)
                .Include(x => x.Equipment) 
                as IQueryable<Automobile>;

            var totalItemCount = await collection.CountAsync();

            var paginationMetadata = new PaginationMetadata(totalItemCount, pageSize, pageNumber);

            var collectionToReturn = await collection.
                Skip(pageSize * (pageNumber - 1)).
                Take(pageSize).ToListAsync();

            return (collectionToReturn, paginationMetadata);
        }
    }
}
