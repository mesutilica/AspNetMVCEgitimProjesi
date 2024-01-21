using System.Data.Entity.Migrations;
using System.Linq;

namespace AspNetMVCEgitimProjesi.NetFramework.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<Models.UyeContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Models.UyeContext context)
        {
            if (!context.Uyeler.Any())
            {
                context.Uyeler.Add(new Models.Uye()
                {
                    Ad = "Admin",
                    Soyad = "User",
                    Email = "info@admin.net",
                    Sifre = "admin123",
                    KullaniciAdi = "Admin"
                });
                context.SaveChanges();
            }
        }
    }
}
