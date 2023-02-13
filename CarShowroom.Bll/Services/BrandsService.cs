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
    public class BrandsService : IBrandsService
    {
        private readonly CarShowroomContext _carShowroomContext;

        public BrandsService(CarShowroomContext carShowroomContext)
        {
            _carShowroomContext = carShowroomContext;
        }
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

        public async Task<IEnumerable<Brand>> GetBrandsForCompanyAsync(string companyName)
        {
            return await _carShowroomContext.Brands.Where(x => x.CompanyName == companyName).ToListAsync();
        }

        public async Task<Brand?> GetBrandAsync(int brandId, bool includeModels = false)
        {
            if (includeModels)
            {
                return await _carShowroomContext.Brands.Include(x => x.Models).FirstOrDefaultAsync(x => x.Id == brandId);
            }
            return await _carShowroomContext.Brands.FirstOrDefaultAsync(x => x.Id == brandId);
        }

        public async Task AddBrand(Brand brand)
        {
            await _carShowroomContext.Brands.AddAsync(brand);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _carShowroomContext.SaveChangesAsync() >= 0);
        }

        public void DeleteBrand(Brand brand)
        {
            _carShowroomContext.Brands.Remove(brand);
        }
    }
}
