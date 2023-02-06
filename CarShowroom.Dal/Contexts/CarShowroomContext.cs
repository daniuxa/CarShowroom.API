using CarShowroom.Dal.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShowroom.Dal.Contexts
{
    public class CarShowroomContext : DbContext
    {
        public DbSet<Automobile> Automobiles { get; set; } = null!;
        public DbSet<Brand> Brands { get; set; } = null!;
        public DbSet<Company> Companies { get; set; } = null!;
        public DbSet<Engine> Engines { get; set; } = null!;
        public DbSet<Equipment> Equipments { get; set; } = null!;
        public DbSet<Model> Models { get; set; } = null!;

        public CarShowroomContext(DbContextOptions<CarShowroomContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CarShowroomContext).Assembly);
        }
    }
}
