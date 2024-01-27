using Microsoft.EntityFrameworkCore;

namespace Inventar.Data
{
    public class InventarContext : DbContext
    {
        public InventarContext(DbContextOptions<InventarContext> options)
            : base(options)
        {
        }

        public DbSet<Warehouse> Warehouses { get; set; }
    }
}
