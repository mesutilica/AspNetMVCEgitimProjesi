using AspNetMVCEgitimProjesi.NetCore.Models;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<UyeContext>();

// Rate Limiting Middleware, .NET 7 ile birlikte gelen ve API'lerde belirli bir süre içinde yapýlabilecek istek sayýsýný sýnýrlamak için kullanýlan bir mekanizmadýr. Bu middleware, aþýrý yüklenmeyi önlemek, hizmet sürekliliðini saðlamak ve kötü amaçlý saldýrýlara karþý koruma saðlamak için oldukça etkilidir.

builder.Services.AddRateLimiter(options =>
{
    options.AddFixedWindowLimiter("fixed", limiterOptions =>
    {
        limiterOptions.PermitLimit = 10; // Maksimum 10 istek
        limiterOptions.Window = TimeSpan.FromSeconds(10); // 10 saniyelik pencere
        limiterOptions.QueueProcessingOrder = System.Threading.RateLimiting.QueueProcessingOrder.OldestFirst;
        limiterOptions.QueueLimit = 5;
    });
    /*
     - Rate Limiting Algoritmalarý:
.NET 7, farklý rate limiting algoritmalarýný destekler:
- Fixed Window: Belirli bir zaman aralýðýnda sabit sayýda isteðe izin verir.
- Sliding Window: Ýstekleri belirli bir zaman dilimi içinde deðerlendirir ve pencereyi kaydýrarak daha esnek bir kontrol saðlar.
- Token Bucket: Belirli bir hýzda "token" ekler ve her istek bir token tüketir.
- Concurrency Limit: Ayný anda iþleme alýnabilecek maksimum istek sayýsýný sýnýrlar.
     */
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseRateLimiter(); // Bu middleware sayesinde API'ni DDoS saldýrýlarýna karþý koruyabilir, performansý artýrabilir ve hizmet sürekliliðini saðlayabiliriz.

app.Run();
