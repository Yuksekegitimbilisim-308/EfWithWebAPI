using Microsoft.EntityFrameworkCore;

namespace EfWithWebAPI
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Category>().ToTable("kategori");
            //modelBuilder.Entity<Category>()
            //    .Property(x => x.CategoryId).HasColumnName("kategori_sirano");
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
