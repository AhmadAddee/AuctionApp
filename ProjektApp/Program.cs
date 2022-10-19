using ProjektApp.Core.Interfaces;
using ProjektApp.Core;
using ProjektApp.Persistence;
using Microsoft.EntityFrameworkCore;

/** The starting point of the application (closest to Main in Java).
 * 
 */

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IAuctionService, AuctionService>();
builder.Services.AddScoped<IAuctionPersistence, AuctionSqlPersistenece>();


// db, with dependency injection
builder.Services.AddDbContext<AuctionDbContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("AuctionDbConnection")));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// Force the browser to use HTTPS insteade of HTTP.
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
