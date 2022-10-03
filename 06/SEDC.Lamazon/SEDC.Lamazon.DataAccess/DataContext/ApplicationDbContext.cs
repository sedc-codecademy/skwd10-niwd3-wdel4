using Microsoft.EntityFrameworkCore;
using SEDC.Lamazon.Domain.Enitities;
using System.Reflection;

namespace SEDC.Lamazon.DataAccess.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) {
            this.ChangeTracker.AutoDetectChangesEnabled = false;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceLineItem> InvoiceLineItems { get; set; }
        public DbSet<InvoiceStatus> InvoiceStatuses { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLineItem> OrderLineItem { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
