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
    /// <summary>
    /// Companies sevice
    /// </summary>
    public class CompaniesService : ICompaniesService
    {
        private readonly CarShowroomContext _carShowroomContext;

        /// <summary>
        /// Constructor of class
        /// </summary>
        /// <param name="carShowroomContext">Car showroom data base context</param>
        /// <exception cref="ArgumentNullException">If carShowroom == null</exception>
        public CompaniesService(CarShowroomContext carShowroomContext)
        {
            _carShowroomContext = carShowroomContext ?? throw new ArgumentNullException(nameof(carShowroomContext));
        }
        /// <summary>
        /// Receive paginated companies collection from data base
        /// </summary>
        /// <param name="pageNumber">Number of page which we wnat to receive</param>
        /// <param name="pageSize">Size of pages</param>
        /// <returns>Collection of companies and data about pagination</returns>
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
        }

        /// <summary>
        /// Receive company by name
        /// </summary>
        /// <param name="companyName">Company name</param>
        /// <param name="includeEngines">Include engines collection or not</param>
        /// <param name="includeBrands">Include brands collection or not</param>
        /// <returns>Company or null if company haven't been found</returns>
        public async Task<Company?> GetCompanyAsync(string companyName, bool includeEngines = false, bool includeBrands = false)
        {
            Company? company = await _carShowroomContext.Companies.FirstOrDefaultAsync(x => x.CompanyName == companyName);

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
        /// <summary>
        /// Add company to data base 
        /// </summary>
        /// <param name="company">Company which we want to add</param>
        /// <returns>Task class</returns>
        public async Task AddCompanyAsync(Company company)
        {
            await _carShowroomContext.Companies.AddAsync(company);
        }
        /// <summary>
        /// Save changes in data base
        /// </summary>
        /// <returns>true or false, saved successfully or not</returns>
        public async Task<bool> SaveChangesAsync()
        {
            return await _carShowroomContext.SaveChangesAsync() >= 0;
        }
        /// <summary>
        /// Delete the company from data base
        /// </summary>
        /// <param name="company">Company for deleting</param>
        public void DeleteCompany(Company company)
        {
            _carShowroomContext.Companies.Remove(company);
        }
        /// <summary>
        /// Chech existing of company
        /// </summary>
        /// <param name="companyName">Company name</param>
        /// <returns>True - found, False - not found</returns>
        public async Task<bool> IsExistCompanyAsync(string companyName)
        {
            return await _carShowroomContext.Companies.AnyAsync(c => c.CompanyName == companyName);
        }
    }
}
