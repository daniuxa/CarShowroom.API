using CarShowroom.Bll.Interfaces;
using CarShowroom.Bll.Models;
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
    /// Brands service
    /// </summary>
    public class BrandsService : IBrandsService
    {
        private readonly CarShowroomContext _carShowroomContext;

        /// <summary>
        /// Constructor of class
        /// </summary>
        /// <param name="carShowroomContext">Car Showroom data base context</param>
        /// <exception cref="ArgumentNullException">If carShowroom == null</exception>
        public BrandsService(CarShowroomContext carShowroomContext)
        {
            _carShowroomContext = carShowroomContext ?? throw new ArgumentNullException(nameof(carShowroomContext));
        }
        /// <summary>
        /// Receive paginated collection of brands
        /// </summary>
        /// <param name="pageNumber">Number of page which we want to receive</param>
        /// <param name="pageSize">Size of pages</param>
        /// <returns>Collection of brands and data about pagination</returns>
        public async Task<(IEnumerable<Brand>, PaginationMetadata)> GetBrandsAsync(int pageNumber = 1, int pageSize = 10)
        {
            var collection = _carShowroomContext.Brands as IQueryable<Brand>;

            var totalItemCount = await collection.CountAsync();

            var paginationMetadata = new PaginationMetadata(totalItemCount, pageSize, pageNumber);

            var collectionToReturn = await collection.
                Skip(pageSize * (pageNumber - 1)).
                Take(pageSize).ToListAsync();

            return (collectionToReturn, paginationMetadata);
        }
        /// <summary>
        /// Receive collection of brands which are from the same company
        /// </summary>
        /// <param name="companyName">Name of the company</param>
        /// <returns>Collection of brands</returns>
        public async Task<IEnumerable<Brand>> GetBrandsForCompanyAsync(string companyName)
        {
            return await _carShowroomContext.Brands.Where(x => x.CompanyName == companyName).ToListAsync();
        }
        /// <summary>
        /// Receive brand by Id parameter 
        /// </summary>
        /// <param name="brandId">Id pf brand</param>
        /// <param name="includeModels">include or not models collection</param>
        /// <returns>Brand which we find or null if brand havent't found</returns>
        public async Task<Brand?> GetBrandAsync(int brandId, bool includeModels = false)
        {
            if (includeModels)
            {
                return await _carShowroomContext.Brands.Include(x => x.Models).FirstOrDefaultAsync(x => x.Id == brandId);
            }
            return await _carShowroomContext.Brands.FirstOrDefaultAsync(x => x.Id == brandId);
        }
        /// <summary>
        /// Add brand to database
        /// </summary>
        /// <param name="brand">Brand for adding</param>
        /// <returns>Added entity</returns>
        public async Task AddBrand(Brand brand)
        {
            await _carShowroomContext.Brands.AddAsync(brand);
        }
        /// <summary>
        /// Save changes in data base
        /// </summary>
        /// <returns>true or false, saved successfully or not</returns>
        public async Task<bool> SaveChangesAsync()
        {
            return (await _carShowroomContext.SaveChangesAsync() >= 0);
        }
        /// <summary>
        /// Delete entity from data base
        /// </summary>
        /// <param name="brand">Brand for deleting</param>
        public void DeleteBrand(Brand brand)
        {
            _carShowroomContext.Brands.Remove(brand);
        }
    }
}
