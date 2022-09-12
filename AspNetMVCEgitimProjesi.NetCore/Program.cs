using AspNetMVCEgitimProjesi.NetCore.Areas.Admin.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews(); // Uygulamada MVC controller view yap�s�n� kullanaca��z

builder.Services.AddSession(option => option.IdleTimeout = TimeSpan.FromMinutes(3)); // Uygulamada session kullanaca��m�z� bildirdik. option kullanarak session yap�land�rmas�n� kullanabiliriz. Sonras�nda a�a��daki add tan�mlamas�ndan sonra use session ayar�n� yap�yoruz.

builder.Services.AddDbContext<DatabaseContext>(); // Entity framework � projede servis olarak kullanabilmek i�in bu tan�mlama gerekli

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection(); // http den https ye otomatik y�nlendire yap
app.UseStaticFiles(); // Uygulamada statik doyalar(wwwroot i�erisindekiler) kullan�labilsin

app.UseSession(); // web uygulamam�zda session kullan�m�n� aktif et

app.UseRouting(); // Uygulamada Routing mekanizmas�n� aktif et

app.UseAuthentication(); // Uygulamada oturum a�ma i�lemini aktif et
app.UseAuthorization(); // Uygulamada yetkilendirme kullan�m�n� aktif et

// Admin areas�n� ekledikten sonra a�a��daki route ayar�n� tan�mlamam�z gerekiyor! Sonras�nda admin i�erisindeki controllerlar�n �st�ne area ad�n� yazmam�z gerekiyor yoksa 404 error hatas� al�yoruz.
app.MapControllerRoute(
            name: "admin",
            pattern: "{area:exists}/{controller=Default}/{action=Index}/{id?}"
          );

app.MapControllerRoute( // uygulamada kullanaca��m�z routing yap�s�
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
// E�er birden fazla routing kullanacaksak bu alana ekleyebiliriz
app.Run(); // Uygulamay� �al��t�r
