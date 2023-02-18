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
    /// Automobile service
    /// </summary>
    public class AutomobilesService : IAutomobilesService
    {
        private readonly CarShowroomContext _carShowroomContext;

        /// <summary>
        /// Constructor of automobile service
        /// </summary>
        /// <param name="carShowroomContext">Car showroom data base context</param>
        /// <exception cref="ArgumentNullException">If carShowroom == null</exception>
        public AutomobilesService(CarShowroomContext carShowroomContext)
        {
            _carShowroomContext = carShowroomContext ?? throw new ArgumentNullException(nameof(carShowroomContext));
        }

        /// <summary>
        /// Receiving automobiles from data base with pagination
        /// </summary>
        /// <param name="pageNumber">Number of which page we want to receive</param>
        /// <param name="pageSize">Size of pages</param>
        /// <returns>Collection of automobiles and data about pagination</returns>
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
