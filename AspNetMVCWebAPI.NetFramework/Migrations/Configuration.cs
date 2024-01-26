using AspNetFramework.Entities;
using System.Data.Entity.Migrations;
using System.Linq;

namespace AspNetFrameworkMVCWebAPI.Migrations
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
                context.Users.Add(new User()
                {
                    Name = "Admin",
                    Surname = "User",
                    Email = "info@admin.net",
                    Password = "admin123",
                    UserName = "Admin",
                    IsActive = true,
                    IsAdmin = true,
                    UserGuid = System.Guid.NewGuid(),
                    RefreshToken = System.Guid.NewGuid().ToString(),
                    RefreshTokenExpireDate = System.DateTime.Now.AddDays(1)
                });
                context.SaveChanges();
            }
        }
    }
}
