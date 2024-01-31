using AspNetCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreMVCWebAPIUsing.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        // EntityFramework6\Enable-Migrations
        // EntityFramework6\add-Migration initialCreate
        // EntityFramework6\update-database
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Burası veritabanı yapılandırma ayarlarını yapabileceğimiz metot
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB; database=AspNetCoreMVCProjesi; integrated security=true;"); // TrustServerCertificate=True
            //optionsBuilder.UseInMemoryDatabase("NetCoreMvcProjeUygulamasi");
            //optionsBuilder.UseLazyLoadingProxies();
            // komut satırında yardım için dotnet ef enter
            base.OnConfiguring(optionsBuilder);
        }
    }
}
