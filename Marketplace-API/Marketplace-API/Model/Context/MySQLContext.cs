using Microsoft.EntityFrameworkCore;


namespace MarketplaceAPI.Model.Context
{
    public class MySQLContext : DbContext
    {
        public MySQLContext(){}
        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options){}

        public DbSet<Store> Stores { get; set; }
        public DbSet<Product> Products { get; set; }

    }
}
