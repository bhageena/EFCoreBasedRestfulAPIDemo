using EFCoreBasedRestfulAPIDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCoreBasedRestfulAPIDemo.Repository
{
    public class ItemsDbContext : DbContext
    {
        public DbSet<Item> Items { get; set; }

        public ItemsDbContext(DbContextOptions<ItemsDbContext> options) : base(options) { }
    }
}
