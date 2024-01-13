using Microsoft.EntityFrameworkCore;

namespace AspNetMVCEgitimProjesi.NetCore.Models
{
    public class UyeContext : DbContext // DbContext sınıfı Nuget dan yüklediğimiz entity framework core paketleri ile gelmektedir ve ef ile veritabanı işlemlerini yapabilmemizi sağlar.
    {
        public DbSet<Uye> Uyeler { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // optionsBuilder.UseInMemoryDatabase("InMemoryDb");
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB; database=UyeDb; integrated security=true; TrustServerCertificate=True"); // 
            base.OnConfiguring(optionsBuilder);
        }
    }
}
