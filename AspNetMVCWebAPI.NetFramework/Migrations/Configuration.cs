using System.Data.Entity.Migrations;
using System.Linq;

namespace AspNetMVCWebAPI.NetFramework.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<Data.DatabaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Data.DatabaseContext context)
        {
            if (!context.Users.Any())
            {
                context.Users.Add(new Entities.User()
                {
                    Name = "Admin",
                    Surname = "User",
                    Email = "info@admin.net",
                    Password = "admin123",
                    UserName = "Admin",
                    IsActive = true,
                    IsAdmin = true,
                    UserGuid = System.Guid.NewGuid()
                });
                context.SaveChanges();
            }
        }
    }
}
