using Microsoft.EntityFrameworkCore;

namespace AspNetMVCEgitimProjesi.NetCore.Models
{
    public class UyeContext(DbContextOptions options) : DbContext(options) // DbContext sınıfı Nuget dan yüklediğimiz entity framework core paketleri ile gelmektedir ve ef ile veritabanı işlemlerini yapabilmemizi sağlar.
    {
        public DbSet<Uye> Uyeler { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // optionsBuilder.UseInMemoryDatabase("InMemoryDb");
            // con stringi manuel vermek istersek
            // optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB; database=UyeDb; integrated security=true; TrustServerCertificate=True"); //

            // con stringi appsettings den çekmek için
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("UyeContext");
            optionsBuilder.UseSqlServer(connectionString);

            base.OnConfiguring(optionsBuilder);
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