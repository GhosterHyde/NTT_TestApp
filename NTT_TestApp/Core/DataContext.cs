using NTT_TestApp.Model;
using System.Data.Entity;

namespace NTT_TestApp.Core
{
    public class DataContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasMany(s => s.Categories)
                .WithMany(c => c.Products)
                .Map(cs =>
                {
                    cs.MapLeftKey("ProductId");
                    cs.MapRightKey("CategoryId");
                    cs.ToTable("ProductCategory");
                });
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<Category>().ToTable("Category");
            base.OnModelCreating(modelBuilder);
        }

        public DataContext() : base(@"Data Source=.\SQLEXPRESS;Database=ProductCatalog;Trusted_Connection=True;")
        {
        }
    }
}
