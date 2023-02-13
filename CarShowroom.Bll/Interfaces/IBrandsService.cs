using CarShowroom.Bll.Models;
using CarShowroom.Bll.Services;
using CarShowroom.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShowroom.Bll.Interfaces
{
    public interface IBrandsService
    {
        Task AddBrand(Brand brand);
        void DeleteBrand(Brand brand);
        Task<Brand?> GetBrandAsync(int brandId, bool includeModels = false);
        Task<(IEnumerable<Brand>, PaginationMetadata)> GetBrandsAsync(int pageNumber = 1, int pageSize = 10);
        Task<IEnumerable<Brand>> GetBrandsForCompanyAsync(string companyName);
        Task<bool> SaveChangesAsync();
    }
}
