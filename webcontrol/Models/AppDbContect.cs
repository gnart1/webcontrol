
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace webcontrol.Models
{
    // razorweb.models.MyBlogContext
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<CartModel> Carts { get; set; }
        public DbSet<CategoryModel> Categories { get; set; }
        public DbSet<CouponModel> Coupons { get; set; }
        public DbSet<ItemModel> Items { get; set; }
        public DbSet<OrderHeader> OrderHeaders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<SubCategoryModel> SubCategories { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            base.OnConfiguring(builder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            //{
            //    var tableName = entityType.GetTableName();
            //    if (tableName.StartsWith("AspNet"))
            //    {
            //        entityType.SetTableName(tableName.Substring(6));
            //    }
            //}

        }
    }
}