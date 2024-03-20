using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes.EntityFramework;

public class RentACarContext : DbContext
{

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"server=(localdb)\mssqllocaldb;database=rentacardb;Trusted_Connection=true;");
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Car>()
            .HasOne(c => c.Color)
            .WithMany(c => c.Cars)
            .HasForeignKey(c => c.ColorId)
            .IsRequired();

        modelBuilder.Entity<Color>()
            .HasMany(c => c.Cars)
            .WithOne(c => c.Color)
            .HasForeignKey(c => c.ColorId)
            .IsRequired();
    }


    public DbSet<Brand> Brands { get; set; }
    public DbSet<Color> Colors { get; set; }
    public DbSet<Car> Cars { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Rental> Rentals { get; set; }
    public DbSet<Company> Companies { get; set; }
}
