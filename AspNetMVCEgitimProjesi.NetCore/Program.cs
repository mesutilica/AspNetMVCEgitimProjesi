var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews(); // Uygulamada MVC controller view yapýsýný kullanacaðýz

builder.Services.AddSession(option => option.IdleTimeout = TimeSpan.FromMinutes(3)); // Uygulamada session kullanacaðýmýzý bildirdik. option kullanarak session yapýlandýrmasýný kullanabiliriz. Sonrasýnda aþaðýdaki add tanýmlamasýndan sonra use session ayarýný yapýyoruz.

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection(); // http den https ye otomatik yönlendire yap
app.UseStaticFiles(); // Uygulamada statik doyalar(wwwroot içerisindekiler) kullanýlabilsin

app.UseSession(); // web uygulamamýzda session kullanýmýný aktif et

app.UseRouting(); // Uygulamada Routing mekanizmasýný aktif et

app.UseAuthentication(); // Uygulamada oturum açma iþlemini aktif et
app.UseAuthorization(); // Uygulamada yetkilendirme kullanýmýný aktif et

app.MapControllerRoute( // uygulamada kullanacaðýmýz routing yapýsý
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
// Eðer birden fazla routing kullanacaksak bu alana ekleyebiliriz
app.Run(); // Uygulamayý çalýþtýr
