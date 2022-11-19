using AspNetCoreMVCProjesi.Entities;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreMVCProjesi.Data
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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    IsActive = true,
                    IsAdmin = true,
                    UserName = "Admin",
                    Password = "123",
                    Email = "admin@admin.com",
                    Name = "Admin",
                    Surname = "User"
                });
            base.OnModelCreating(modelBuilder);
        }
    }
}
