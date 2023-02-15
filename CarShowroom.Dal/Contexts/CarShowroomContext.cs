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

            modelBuilder.Entity<Company>().HasData(
                new Company()
                {
                    CompanyName = "VAG",
                    CompanySite = "vag.com"
                },
                new Company()
                {
                    CompanyName = "Daimler",
                    CompanySite = "daimler.com"
                },
                new Company()
                {
                    CompanyName = "PSA Groupe",
                    CompanySite = "psa.com"
                }
                );

            modelBuilder.Entity<Brand>().HasData(
                new Brand()
                {
                    Id = 1,
                    Name = "Volkswagen",
                    CompanyName = "VAG"
                },
                new Brand()
                {
                    Id = 2,
                    Name = "Audi",
                    CompanyName = "VAG"
                },
                new Brand()
                {
                    Id = 3,
                    Name = "Mercedes-Benz",
                    CompanyName = "Daimler"
                },
                new Brand()
                {
                    Id = 4,
                    Name = "Citroen",
                    CompanyName = "PSA Groupe"
                },
                new Brand()
                {
                    Id = 5,
                    Name = "Peugeot",
                    CompanyName = "PSA Groupe"
                }
                );

            modelBuilder.Entity<Engine>().HasData(
                    new Engine()
                    {
                        Id = 1,
                        Name = "CCZB",
                        EngineCapacity = 2,
                        Power = 210,
                        FuelType = FuelType.Gasoline,
                        CompanyName = "VAG"
                    });

            modelBuilder.Entity<Model>().HasData(
                new Model()
                {
                    Id = 1,
                    Name = "Passat",
                    BrandId = 1
                });

            modelBuilder.Entity<Equipment>().HasData(
                new Equipment() 
                { 
                    Id = 1,
                    Name = "Comfort",
                    EngineId = 1,
                    ModelId = 1
                }
                );
            modelBuilder.Entity<Automobile>().HasData(
                new Automobile()
                {
                    VIN = "QWERTYUIOPASDFGHJ",
                    ProdDate = DateTime.Now.AddYears(-1),
                    BodyType = BodyType.Sedan,
                    Color = Color.Black,
                    BrandId = 1,
                    ModelId = 1,
                    EquipmentId = 1
                });
        }
    }
}
