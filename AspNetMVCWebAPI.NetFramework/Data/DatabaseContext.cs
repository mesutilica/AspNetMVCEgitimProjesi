using AspNetMVCWebAPI.NetFramework.Entities;
using System.Data.Entity;

namespace AspNetMVCWebAPI.NetFramework.Data
{
    public class DatabaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        // EntityFramework6\Enable-Migrations
        // EntityFramework6\add-Migration initialCreate
        // EntityFramework6\update-database
    }
}