using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace AspNetMVCEgitimProjesi.NetCore.Models
{
    public class UyeContext : DbContext // DbContext sınıfı Nuget dan yüklediğimiz entity framework core paketleri ile gelmektedir ve ef ile veritabanı işlemlerini yapabilmemizi sağlar.
    {
        public UyeContext(DbContextOptions<UyeContext> options) : base(options)
        {
            //Database.Migrate();
        }
        public UyeContext()
        {
            //Database.Migrate();
        }
        public DbSet<Uye> Uyeler { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // optionsBuilder.UseInMemoryDatabase("InMemoryDb");
            // con stringi manuel vermek istersek
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB; database=UyeDb; integrated security=true; TrustServerCertificate=True"); //

            // con stringi appsettings den çekmek için
            //var configuration = new ConfigurationBuilder()
            //    .SetBasePath(Directory.GetCurrentDirectory())
            //    .AddJsonFile("appsettings.json")
            //    .Build();

            //var connectionString = configuration.GetConnectionString("UyeContext");
            //optionsBuilder.UseSqlServer(connectionString);

            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Uye>().HasData(
                new Uye
                {
                    Id = 1,
                    Email = "admin@admin.com",
                    Ad = "Admin",
                    Soyad = "User",
                    DogumTarihi = DateTime.Now,
                    KullaniciAdi = "admin",
                    Sifre = "123",
                    SifreTekrar = "123",
                    TcKimlikNo = "12345678901",
                    Telefon = "12345678901"
                });
            base.OnModelCreating(modelBuilder);
        }
    }
}
/*
 >vscode mac için komutlar
    dotnet tool install --global dotnet-ef
    dotnet add package Microsoft.EntityFrameworkCore.Design
    dotnet ef migrations add InitialCreate
    dotnet ef database update
 */