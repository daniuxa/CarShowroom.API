using CarShowroom.Bll.Services;
using CarShowroom.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShowroom.Bll.Interfaces
{
    public interface IAutomobileService
    {
        Task<(IEnumerable<Automobile>, PaginationMetadata)> GetAutomobilesAsync(int pageNumber = 1, int pageSize = 10);
    }
}
