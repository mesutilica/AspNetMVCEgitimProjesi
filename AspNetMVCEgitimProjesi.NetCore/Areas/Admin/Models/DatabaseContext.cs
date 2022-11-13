using Microsoft.EntityFrameworkCore;

namespace AspNetMVCEgitimProjesi.NetCore.Areas.Admin.Models
{
    public class DatabaseContext : DbContext // DbContext sınıfı Nuget dan yüklediğimiz entity framework core paketleri ile gelmektedir ve ef ile veritabanı işlemlerini yapabilmemizi sağlar.
    {
        // EntityFrameworkCore da veritabanı işlemlerini yapabilmek için aşağıdaki dbset leri tanımlamak zorundayız.
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        // Sonrasında EntityFrameworkCore un hangi veritabanına bağlanacağını belirten ayarları aşağıdaki gibi yapmamız gerekiyor. Override yazıp bir boşluk bıraktıktan sonra onconfiguring metodunu seçiyoruz.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // metodu oluşturduktan sonra aşağıdaki gibi veritabanı ayarlarını tanımlayabiliriz.
            optionsBuilder.UseSqlServer(@"server=(localdb)\MSSQLLocalDB; Database=AspNetMVCEgitimProjesi; integrated security=True"); // Burada connection string tanımlıyoruz
            //optionsBuilder.UseInMemoryDatabase("InMemoryDb");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Veritabanı oluştuktan sonra tablolara başlangıç datası atmak için aşağıdaki yapıyı kullanıyoruz
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Email = "admin@AspNetMVCEgitimProjesi.net",
                    Name = "Admin",
                    Surname = "User",
                    Username = "Admin",
                    Password = "123"
                }
                );
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Name = "Elektronik",
                    IsActive = true
                },
                new Category
                {
                    Id = 2,
                    Name = "Bilgisayar",
                    IsActive = true
                }
                );
            modelBuilder.Entity<Product>().HasData(
                        new Product { Id = 1, CategoryId = 1, Name = "Monitör", Price = 1984, Stock = 3 },
                        new Product { Id = 2, CategoryId = 1, Name = "Led TV", Price = 5500, Stock = 5 },
                        new Product { Id = 3, CategoryId = 1, Name = "LCD TV", Price = 3500, Stock = 7 },
                        new Product { Id = 4, CategoryId = 2, Name = "Oyuncu PC", Price = 18000, Stock = 3 },
                        new Product { Id = 5, CategoryId = 2, Name = "Laptop", Price = 13000, Stock = 5 },
                        new Product { Id = 6, CategoryId = 2, Name = "Dizüstü", Price = 23500, Stock = 7 }
                );
            base.OnModelCreating(modelBuilder);
            // Bu aşamadan sonra artık migration oluşturmamız gerekiyor. Bunun için Visual studion üst menüsünden Tools > Nuget Package Manager > Package Manager Console menüsüne tıklayarak kod yazma penceresini aktif ediyoruz.
            // Veritabanı oluşturmak için P.M.C. konsoluna add-migration InitialCreate yazıp enter a basıyoruz fakat bu işlemden önce Entity Framework Core Tools paketini de yüklememiz gerekiyor projeye nuget dan
            // Migration oluştuktan sonra PMC konsoluna update-database yazıp enter a basıyoruz, bu veritabanımızı ve tablolarımızı oluşturacak
            // Sonraki adımda Program.cs dosyasına Databasecontext i servis olarak ekliyoruz
        }
        public DbSet<NetCore.Models.Kullanici> Kullanici { get; set; }
    }
}
