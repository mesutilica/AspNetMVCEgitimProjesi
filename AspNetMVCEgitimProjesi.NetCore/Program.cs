using AspNetMVCEgitimProjesi.NetCore.Models;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.Cookies; // Bu kütüphaneyi de admin login için ekledik.

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews(); // Uygulamada MVC controller view yapýsýný kullanacaðýz

//FluentValidation
builder.Services.AddScoped<IValidator<Kullanici>, KullaniciValidator>();

builder.Services.AddSession(option => option.IdleTimeout = TimeSpan.FromMinutes(3)); // Uygulamada session kullanacaðýmýzý bildirdik. option kullanarak session yapýlandýrmasýný kullanabiliriz. Sonrasýnda aþaðýdaki add tanýmlamasýndan sonra use session ayarýný yapýyoruz.

builder.Services.AddDbContext<UyeContext>(); //option => option.UseInMemoryDatabase("InMemoryDb") UseInMemoryDatabase kullanýmý
// Admin login iþlemi için aþaðýdaki servisi ekliyoruz.
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(x =>
{
    x.LoginPath = "/Admin/Login"; // Admin oturum açma sayfamýzý belirttik
});

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseExceptionHandler("/Home/Error"); // Global hata yakalama için

app.UseHttpsRedirection(); // http den https ye otomatik yönlendire yap
app.UseStaticFiles(); // Uygulamada statik doyalar(wwwroot içerisindekiler) kullanýlabilsin

app.UseSession(); // web uygulamamýzda session kullanýmýný aktif et

app.UseRouting(); // Uygulamada Routing mekanizmasýný aktif et

app.UseAuthentication(); // Uygulamada oturum açma iþlemini aktif et
app.UseAuthorization(); // Uygulamada yetkilendirme kullanýmýný aktif et

// Admin areasýný ekledikten sonra aþaðýdaki route ayarýný tanýmlamamýz gerekiyor! Sonrasýnda admin içerisindeki controllerlarýn üstüne area adýný yazmamýz gerekiyor yoksa 404 error hatasý alýyoruz.
app.MapControllerRoute(
            name: "admin",
            pattern: "{area:exists}/{controller=Default}/{action=Index}/{id?}"
          );

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
