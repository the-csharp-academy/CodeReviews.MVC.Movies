using Microsoft.EntityFrameworkCore;
using MovieApp.Data;
using MovieApp.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TelevisionShowContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("TelevisionSeriesContext")
            ?? throw new InvalidOperationException(
                "Connection string 'TelevisionSeriesContext' not found."
            )
    )
);
builder.Services.AddDbContext<MovieContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("MovieAppContext")
            ?? throw new InvalidOperationException("Connection string 'MovieAppContext' not found.")
    )
);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Initialize the database with seed data
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    SeedMovieData.InitializeMovies(services);
    SeedShowData.InitializeShows(services);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}").WithStaticAssets();

app.Run();
