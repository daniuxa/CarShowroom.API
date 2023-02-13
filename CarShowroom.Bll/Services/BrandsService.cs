using CarShowroom.Bll.Interfaces;
using CarShowroom.Bll.Models;
using CarShowroom.Dal.Contexts;
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
        public async Task<IEnumerable<Dal.Entities.Brand>> GetBrandsAsync()
        {
            return await _carShowroomContext.Brands.ToListAsync();
        }
    }
}
