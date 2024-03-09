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

            builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))); // json dan �ekmek i�in

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
            {
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    //Validasyon yapmak istedi�imiz alanlar
                    ValidateAudience = true, // Kitleyi Do�rula
                    ValidateIssuer = true, // Token� vereni do�rula
                    ValidateLifetime = true, // Token ya�am s�resini do�rula
                    ValidateIssuerSigningKey = true, // Token� verenin �mzalama anahtar�n� Do�rula
                    ValidIssuer = builder.Configuration["Token:Issuer"], // Token� veren sa�lay�c�
                    ValidAudience = builder.Configuration["Token:Audience"], // Token� kullanacak kullan�c�
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:SecurityKey"])), // Token� �mzalama Anahtar�
                    ClockSkew = TimeSpan.Zero // saat fark� olmas�n
                };
            });

            builder.Services.AddCors(options =>
            {
                // this defines a CORS policy called "default"
                options.AddPolicy("default", policy =>
                {
                    policy
                        .AllowAnyOrigin() // t�m�ne izin ver
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