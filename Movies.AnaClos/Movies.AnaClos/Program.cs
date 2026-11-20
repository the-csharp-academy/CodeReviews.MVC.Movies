using Microsoft.EntityFrameworkCore;
using Movies.AnaClos.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<MoviesAnaClosContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MoviesAnaClosContext")
        ?? throw new InvalidOperationException("Connection string 'MoviesAnaClosContext' not found.")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
