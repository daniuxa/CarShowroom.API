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
    public class CompaniesService : ICompaniesService
    {
        private readonly CarShowroomContext _carShowroomContext;

        public CompaniesService(CarShowroomContext carShowroomContext)
        {
            _carShowroomContext = carShowroomContext ?? throw new ArgumentNullException(nameof(carShowroomContext));
        }
        public async Task<(IEnumerable<Company>, PaginationMetadata)> GetCompaniesAsync(int pageNumber, int pageSize)
        {
            var collection = _carShowroomContext.Companies as IQueryable<Company>;

            var totalItemCount = await collection.CountAsync();

            var paginationMetadata = new PaginationMetadata(totalItemCount, pageSize, pageNumber);

            var collectionToReturn = await collection.
                OrderBy(c => c.CompanyName).
                Skip(pageSize * (pageNumber - 1)).
                Take(pageSize).ToListAsync();

            return (collectionToReturn, paginationMetadata);
            //return await _carShowroomContext.Companies.OrderBy(x => x.CompanyName).ToListAsync();
        }

        public async Task<Company?> GetCompanyAsync(string name, bool includeEngines = false, bool includeBrands = false)
        {
            Company? company = await _carShowroomContext.Companies.FirstOrDefaultAsync(x => x.CompanyName == name);

            if (company == null)
            {
                return null;
            }

            if (includeEngines)
            {
                _carShowroomContext.Entry(company).Collection(c => c.Engines).Load();
            }
            if (includeBrands)
            {
                _carShowroomContext.Entry(company).Collection(c => c.Brands).Load();
            }

            return company;
        }

        public async Task AddCompanyAsync(Company company)
        {
            await _carShowroomContext.Companies.AddAsync(company);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _carShowroomContext.SaveChangesAsync() >= 0;
        }

        public void DeleteCompany(Company company)
        {
            _carShowroomContext.Companies.Remove(company);
        }
    }
}
