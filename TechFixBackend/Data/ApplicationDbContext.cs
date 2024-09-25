using Microsoft.EntityFrameworkCore;
using TechFixBackend.Models;

namespace TechFixBackend.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSet properties for each entity
        public DbSet<User> Users { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Quote> Quotes { get; set; }
        public DbSet<QuoteItem> QuoteItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Inventory> Inventory { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure entity relationships and any additional configuration
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Supplier>().ToTable("Suppliers");
            modelBuilder.Entity<Quote>().ToTable("Quotes");
            modelBuilder.Entity<QuoteItem>().ToTable("QuoteItems");
            modelBuilder.Entity<Order>().ToTable("Orders");
            modelBuilder.Entity<OrderItem>().ToTable("OrderItems");
            modelBuilder.Entity<Inventory>().ToTable("Inventory");
            modelBuilder.Entity<Product>().ToTable("Products");

            // Configure foreign key relationships with no cascading delete
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Supplier)
                .WithMany()
                .HasForeignKey(o => o.SupplierId)
                .OnDelete(DeleteBehavior.Restrict); // Use NO ACTION behavior

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Quote)
                .WithMany()
                .HasForeignKey(o => o.QuoteId)
                .OnDelete(DeleteBehavior.Restrict); // Use NO ACTION behavior

            // Configure decimal properties for OrderItem and QuoteItem
            modelBuilder.Entity<OrderItem>()
                .Property(o => o.Price)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<QuoteItem>()
                .Property(q => q.Price)
                .HasColumnType("decimal(18,2)");
        }

    }
}
