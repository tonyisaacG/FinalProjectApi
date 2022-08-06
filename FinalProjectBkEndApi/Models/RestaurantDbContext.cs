using Microsoft.EntityFrameworkCore;

namespace FinalProjectBkEndApi.Models
{
    public class RestaurantDbContext:DbContext
    {
        public RestaurantDbContext(DbContextOptions options) : base(options) { }

        //public virtual DbSet<Cutomer> Cutomers { get; set; }
        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<Items> Items { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetails> OrderDetails { get; set; }
        public virtual DbSet<PurchasesConsumption> PurchasesConsumptions { get; set; }
        public virtual DbSet<PurchasesConsumptionDetails> PurchasesDetails { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Order Config
            modelBuilder.Entity<Order>()
            .Property(order=>order.date).HasDefaultValueSql("getdate()");
            #endregion

            #region Order Config
            modelBuilder.Entity<PurchasesConsumption>()
            .Property(pur => pur.date).HasDefaultValueSql("getdate()");
            #endregion

            #region  Material Config
            modelBuilder.Entity<Items>()
            .HasCheckConstraint("CK_Properties_ExpectQ_NowQ", "[expectedQuantityInDay] < [totalQuantity]");
            #endregion

            #region Order Details Config
            modelBuilder.Entity<OrderDetails>()
                .HasKey(orderD => new { orderD.product_id, orderD.order_id });
            #endregion

            #region Purchases Details Config
            modelBuilder.Entity<PurchasesConsumptionDetails>()
                .HasKey(purD => new { purD.item_id, purD.purchases_id });
            #endregion
            
        }

    }
}
