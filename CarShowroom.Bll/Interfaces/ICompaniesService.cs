using CarShowroom.Bll.Services;
using CarShowroom.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShowroom.Bll.Interfaces
{
    public interface ICompaniesService
    {
        Task AddCompanyAsync(Company company);
        void DeleteCompany(Company company);
        Task<(IEnumerable<Company>, PaginationMetadata)> GetCompaniesAsync(int pageNumber, int pageSize);
        Task<Company?> GetCompanyAsync(string name, bool includeEngines = false, bool includeBrands = false);
        Task<bool> IsExistCompanyAsync(string companyName);
        Task<bool> SaveChangesAsync();
    }
}
