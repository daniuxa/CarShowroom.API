using CarShowroom.Dal.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarShowroom.Dal.Contexts
{
    /// <summary>
    /// CarShowroomContext represent data base cntext to work with data base
    /// </summary>
    public class CarShowroomContext : DbContext
    {
        /// <summary>
        /// DbSet of automobiles
        /// </summary>
        public DbSet<Automobile> Automobiles { get; set; } = null!;
        /// <summary>
        /// DbSet of brands
        /// </summary>
        public DbSet<Brand> Brands { get; set; } = null!;
        /// <summary>
        /// DbSet of companies
        /// </summary>
        public DbSet<Company> Companies { get; set; } = null!;
        /// <summary>
        /// DbSet of engines
        /// </summary>
        public DbSet<Engine> Engines { get; set; } = null!;
        /// <summary>
        /// DbSet of equipments
        /// </summary>
        public DbSet<Equipment> Equipments { get; set; } = null!;
        /// <summary>
        /// DbSet of models
        /// </summary>
        public DbSet<Model> Models { get; set; } = null!;

        /// <summary>
        /// Context class constructor
        /// </summary>
        /// <param name="options"></param>
        public CarShowroomContext(DbContextOptions<CarShowroomContext> options) : base(options)
        {
        }

        /// <summary>
        /// Configuring entities when data base is creating
        /// </summary>
        /// <param name="modelBuilder">Model builder entity by what we are able to configuring entities</param>
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
