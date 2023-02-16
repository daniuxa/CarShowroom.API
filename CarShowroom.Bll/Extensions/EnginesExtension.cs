using CarShowroom.Dal.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShowroom.Dal
{
    public static class EnginesExtension
    {
        public static async Task<IEnumerable<Engine>> GetPaginatedEnginesAsync(this IQueryable<Engine> collection, int pageNumber = 1, int pageSize = 10)
        {
            return await collection.
                 Skip(pageSize * (pageNumber - 1)).
                 Take(pageSize).ToListAsync();
        }
    }
}
