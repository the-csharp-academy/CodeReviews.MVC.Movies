using Microsoft.EntityFrameworkCore;
using Movies.AnaClos.Data;
using Movies.AnaClos.Models;
using OfficeOpenXml;

ExcelPackage.License.SetNonCommercialPersonal("Ana Clos");

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<MoviesAnaClosContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MoviesAnaClosContext")
        ?? throw new InvalidOperationException("Connection string 'MoviesAnaClosContext' not found.")));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

var supportedCultures = new[] { "en-US" };
var localizationOptions = new RequestLocalizationOptions()
    .SetDefaultCulture("en-US")
    .AddSupportedCultures(supportedCultures)
    .AddSupportedUICultures(supportedCultures);

app.UseRequestLocalization(localizationOptions);

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
