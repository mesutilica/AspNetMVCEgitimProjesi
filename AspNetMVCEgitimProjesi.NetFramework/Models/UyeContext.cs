using System.Data.Entity;

namespace AspNetMVCEgitimProjesi.NetFramework.Models
{
    public class UyeContext : DbContext
    {
        public DbSet<Uye> Uyes { get; set; }
        // EntityFramework6\Enable-Migrations
        // EntityFramework6\add-Migration initialCreate
        // EntityFramework6\update-database
    }
}