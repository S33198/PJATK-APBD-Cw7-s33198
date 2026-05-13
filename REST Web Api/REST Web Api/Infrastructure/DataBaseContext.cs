using Microsoft.EntityFrameworkCore;
using REST_Web_Api.Models;
namespace REST_Web_Api.Infrastructure;

public class DataBaseContext : DbContext
{
    public DbSet<PCs> PC { get; set; }
    public DbSet<Components> Component { get; set; }
    public DbSet<ComponentManufacturers> ComponentManufacturer { get; set; }
    public DbSet<ComponentTypes> ComponentType { get; set; }
    public DbSet<PCComponents> PCComponent { get; set; }

    public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
    {
        
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PCs>().ToTable("PCs");
        modelBuilder.Entity<Components>().ToTable("Components");
        modelBuilder.Entity<ComponentManufacturers>().ToTable("ComponentManufacturers");
        modelBuilder.Entity<ComponentTypes>().ToTable("ComponentTypes");
        modelBuilder.Entity<PCComponents>().ToTable("PCComponents");
        modelBuilder.Entity<PCComponents>().HasKey(pc => new { pc.PCId, pc.ComponentCode });
        modelBuilder.Entity<Components>().HasKey(c => c.Code);
        

        modelBuilder.Entity<ComponentTypes>().HasData(
            new ComponentTypes { Id = 1, Abbreviation = "CPU", Name = "Central Processing Unit" },
            new ComponentTypes { Id = 2, Abbreviation = "GPU", Name = "Graphics Processing Unit" },
            new ComponentTypes { Id = 3, Abbreviation = "RAM", Name = "Random Access Memory" }
        );
        modelBuilder.Entity<ComponentManufacturers>().HasData(
            new ComponentManufacturers() { Id = 1, Abbreviation = "INTEL", FullName = "Intel Group",  FoundationDate = new DateTime(1982, 1, 1) },
            new ComponentManufacturers() { Id = 2, Abbreviation = "NVIDIA", FullName = "Nvidia Group",  FoundationDate = new DateTime(1962, 1, 1) },
            new ComponentManufacturers() { Id = 3, Abbreviation = "Corsair", FullName = "Corsair Group",  FoundationDate = new DateTime(1992, 1, 1) },
            new ComponentManufacturers() { Id = 4, Abbreviation = "Kingston", FullName = "Kingston Group",  FoundationDate = new DateTime(1993, 1, 1) }
            );
        modelBuilder.Entity<Components>().HasData(
            new Components {Code = "I7-6950K", Name = "Intel Core i7-6950K", Description = "Intel Core i7-6950K", ComponentManufacturesld = 1, ComponentTypesld = 1},
            new Components {Code = "RTX5090", Name = "NVIDIA Geforce RTX 5090", Description = "New nvidia graphic card", ComponentManufacturesld = 2, ComponentTypesld = 2},
            new Components {Code = "DDR5 16GB", Name = "DDR5 16GB RAM", Description = "16GB (2x8GB) 6000MHz RAM" , ComponentManufacturesld = 3, ComponentTypesld = 3},
            new Components {Code = "DDR4 16GB", Name = "DDR4 16GB RAM", Description = "16GB (2x8GB) 6000MHz RAM" , ComponentManufacturesld = 4, ComponentTypesld = 3}
            );
        modelBuilder.Entity<PCs>().HasData(
            new PCs {Id=1, Name = "Cheap PC", Weight = 13f, Warranty = 24, CreatedAt = new DateTime(2026, 01, 01), Stock = 10},
            new PCs {Id=2, Name = "Medium PC", Weight = 16f, Warranty = 36, CreatedAt = new DateTime(2026, 02, 01), Stock = 5},
            new PCs {Id=3, Name = "Gaming PC", Weight = 22f, Warranty = 12, CreatedAt = new DateTime(2025, 01, 01), Stock = 3}
            );
        modelBuilder.Entity<PCComponents>().HasData(
            new PCComponents {PCId = 2, ComponentCode = "I7-6950K", Amount = 1},
            new PCComponents {PCId = 3, ComponentCode = "RTX5090", Amount = 1},
            new PCComponents {PCId = 2, ComponentCode = "DDR5 16GB", Amount = 2}
        );

    }
    
}