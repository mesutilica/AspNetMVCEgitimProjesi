using Microsoft.EntityFrameworkCore;

namespace AspNetMVCEgitimProjesi.NetCore.Models
{
    public class UyeContext : DbContext // DbContext sınıfı Nuget dan yüklediğimiz entity framework core paketleri ile gelmektedir ve ef ile veritabanı işlemlerini yapabilmemizi sağlar.
    {
        public DbSet<Uye> Uyes { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("InMemoryDb");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
