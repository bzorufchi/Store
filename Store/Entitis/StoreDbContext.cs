using Microsoft.EntityFrameworkCore;

namespace Store.Entitis
{
    public class StoreDbContext : DbContext
    {


        public StoreDbContext()
        {
        }

        public StoreDbContext(DbContextOptions<StoreDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Brands> Brands { get; set; }
        public virtual DbSet<Comments> Comments { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<ShoppingCart> ShoppingCart { get; set; }
        public virtual DbSet<States> States { get; set; }
    }
}
