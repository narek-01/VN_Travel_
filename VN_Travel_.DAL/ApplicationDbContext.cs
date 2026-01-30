using Microsoft.EntityFrameworkCore;
using VN_Travel_.DAL.Entities;

namespace VN_Travel_.DAL;

public class ApplicationDbContext :DbContext
{

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContext) : base(dbContext)
    {

    }
    public ApplicationDbContext()
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

        optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=TravelDB;");

    }

    public DbSet<Entities.Customer> Customers { get; set; }
    public DbSet<Entities.Order> Orders { get; set; }
    public DbSet<Entities.Tour> Tours { get; set; }
    public DbSet<Entities.Review> Reviews { get; set; }
    public DbSet<Entities.Hotel> Hotels { get; set; }
    public DbSet<Entities.Country> Countries { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    { 

        // Hotel <-> Country (you already intended this)
        modelBuilder.Entity<Entities.Hotel>()
            .HasOne(h => h.Country)                // navigation on Hotel
            .WithMany(c => c.Hotel)               // navigation on Country
            .HasForeignKey(h => h.CountryId)       // FK property on Hotel
            .OnDelete(DeleteBehavior.Cascade);

        // Example: Customer (1) <-> Order (many)
        // Requires: Order.Customer (nav), Customer.Orders (nav), Order.CustomerId (FK)
        modelBuilder.Entity<Entities.Order>()
            .HasOne(o => o.Customer)
            .WithMany(c => c.Orders)
            .HasForeignKey(o => o.CustomerId)
            .OnDelete(DeleteBehavior.Cascade);

        // Example: Tour (1) <-> Order (many)
        // Requires: Order.Tour (nav), Tour.Orders (nav), Order.TourId (FK)
        modelBuilder.Entity<Entities.Order>()
            .HasOne(o => o.Tour)
            .WithMany(t => t.Orders)
            .HasForeignKey(o => o.TourId)
            .OnDelete(DeleteBehavior.Restrict);

        // Example: Tour (1) <-> Review (many)
        // Requires: Review.Tour (nav), Tour.Reviews (nav), Review.TourId (FK)
        modelBuilder.Entity<Entities.Review>()
            .HasOne(r => r.Tour)
            .WithMany(t => t.Reviews)
            .HasForeignKey(r => r.TourId)
            .OnDelete(DeleteBehavior.Cascade);

        //// Example: Customer (1) <-> Review (many)
        //// Requires: Review.Customer (nav), Customer.Reviews (nav), Review.CustomerId (FK)
        //modelBuilder.Entity<Entities.Review>()
        //    .HasOne(r => r.Customer)
        //    .WithMany(c => c.Reviews)
        //    .HasForeignKey(r => r.CustomerId)
        //    ;

        // Example: Tour (many) <-> Hotel (1) if Tour references a Hotel
        // Requires: Tour.Hotel (nav), Hotel.Tours (nav), Tour.HotelId (FK)
        //modelBuilder.Entity<Entities.Tour>()
        //    .HasOne(t => t.Hotel)
        //    .WithMany(h => h.Tours)
        //    .HasForeignKey(t => t.HotelId);
        // Add additional configurations (indices, keys, property types) here as needed.

        //    modelBuilder.Entity<Entities.Hotel>()
        //        .HasMany(h => h.Tours)
        //        .WithOne(t => t.Hotel)
        //        .HasForeignKey(t => t.HotelId);
        //

    }

}
