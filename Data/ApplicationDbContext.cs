using Microsoft.EntityFrameworkCore;
using FurnitureStore.Models;

namespace FurnitureStore.Data
{
    public class ApplicationDbContext : DbContext
    {
        // The DbSet property will tell EF Core tha we have a table that needs to be created
        public virtual DbSet<StockModel> Stocks { get; set; }
        public virtual DbSet<AdminMemberModel> Members { get; set; }
        public virtual DbSet<OrderModel> Order { get; set; }
        public virtual DbSet<CartModel> Cart { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // On model creating function will provide us with the ability to manage the tables properties
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
