using AspNetCoreMVCEgitimKonulari.Dtos;
using AspNetMVCEgitimProjesi.NetCore.Models;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims; // Bu kütüphaneyi de admin login için ekledik.

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews(); // Uygulamada MVC controller view yapýsýný kullanacaðýz

//FluentValidation
builder.Services.AddScoped<IValidator<Kullanici>, KullaniciValidator>();

builder.Services.AddSession(options =>
{
    options.Cookie.Name = ".CustomSession";
    options.IdleTimeout = TimeSpan.FromSeconds(60);
    options.Cookie.HttpOnly = true; // Javascriptle ulaþýlamasýn
    options.Cookie.IsEssential = true; // onay politikasý kontrolleri atlansýn
}); // Uygulamada session kullanacaðýmýzý bildirdik. option kullanarak session yapýlandýrmasýný kullanabiliriz. Sonrasýnda aþaðýdaki add tanýmlamasýndan sonra use session ayarýný yapýyoruz.

var connectionString = builder.Configuration.GetConnectionString("UyeContext"); // 

builder.Services.AddDbContext<UyeContext>(); // x => x.UseSqlServer(connectionString) //option => option.UseInMemoryDatabase("InMemoryDb") UseInMemoryDatabase kullanýmý

// Admin login iþlemi için aþaðýdaki servisi ekliyoruz.
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(x =>
{
    x.LoginPath = "/MVC15FiltersUsing/Login"; // Admin oturum açma sayfamýzý belirttik
});

builder.Services.AddAuthorizationBuilder()
    .AddPolicy("AdminPolicy", policy => policy.RequireClaim(ClaimTypes.Role, "Admin"))
    .AddPolicy("UserPolicy", policy => policy.RequireClaim(ClaimTypes.Role, "Admin", "User"))
    .AddPolicy("CustomerPolicy", policy => policy.RequireClaim(ClaimTypes.Role, "Admin", "User", "Customer"))
    .AddPolicy("BlogPolicy", policy => policy.RequireClaim(ClaimTypes.Role, "Admin", "User", "Customer"));

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddMemoryCache(); // Keþlemeyi kullanabilmek için

builder.Services.AddAutoMapper(typeof(DtoMapper)); // AutoMapper inject için

builder.Services.AddHttpClient(); //api ye istek iþlemleri için

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//app.UseExceptionHandler("/Home/Error"); // Global hata yakalama için

app.UseHttpsRedirection(); // http den https ye otomatik yönlendire yap
app.UseStaticFiles(); // Uygulamada statik doyalar(wwwroot içerisindekiler) kullanýlabilsin

app.UseSession(); // web uygulamamýzda session kullanýmýný aktif et

app.UseRouting(); // Uygulamada Routing mekanizmasýný aktif et

app.UseAuthentication(); // Uygulamada oturum açma iþlemini aktif et
app.UseAuthorization(); // Uygulamada yetkilendirme kullanýmýný aktif et

// Admin areasýný ekledikten sonra aþaðýdaki route ayarýný tanýmlamamýz gerekiyor! Sonrasýnda admin içerisindeki controllerlarýn üstüne area adýný yazmamýz gerekiyor yoksa 404 error hatasý alýyoruz.
app.MapControllerRoute(
            name: "admin",
            pattern: "{area:exists}/{controller=Main}/{action=Index}/{id?}"
          )
    .RequireAuthorization("BlogPolicy");

app.MapControllerRoute(
            name: "blog",
            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
          );

app.MapControllerRoute(
            name: "efcore",
            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
          );

app.MapControllerRoute( // uygulamada kullanacaðýmýz routing yapýsý
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
// Eðer birden fazla routing kullanacaksak bu alana ekleyebiliriz

app.Run(); // Uygulamayý çalýþtýr
