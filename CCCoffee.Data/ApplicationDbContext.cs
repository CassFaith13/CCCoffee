using CCCoffee.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CCCoffee.Data
{
    public class ApplicationDbContext : DbContext 
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<CustomerEntity> Customers { get; set; }
        public DbSet<CustomerOrderEntity> CustomerOrders { get; set; }
        public DbSet<MenuItemEntity> MenuItems { get; set; }
    }
}