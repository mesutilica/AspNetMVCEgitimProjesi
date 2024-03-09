using AspNetCoreWebAPI.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Json.Serialization;

namespace AspNetCoreWebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))); // json dan çekmek için

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
            {
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    //Validasyon yapmak istediðimiz alanlar
                    ValidateAudience = true, // Kitleyi Doðrula
                    ValidateIssuer = true, // Tokený vereni doðrula
                    ValidateLifetime = true, // Token yaþam süresini doðrula
                    ValidateIssuerSigningKey = true, // Tokený verenin Ýmzalama anahtarýný Doðrula
                    ValidIssuer = builder.Configuration["Token:Issuer"], // Tokený veren saðlayýcý
                    ValidAudience = builder.Configuration["Token:Audience"], // Tokený kullanacak kullanýcý
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:SecurityKey"])), // Tokený Ýmzalama Anahtarý
                    ClockSkew = TimeSpan.Zero // saat farký olmasýn
                };
            });

            builder.Services.AddCors(options =>
            {
                // this defines a CORS policy called "default"
                options.AddPolicy("default", policy =>
                {
                    policy
                        .AllowAnyOrigin() // tümüne izin ver
                        // .WithOrigins("https://localhost:7262") // sadece bu domainlere izin ver
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            // UseCors
            app.UseCors("default");

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}