using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CarEverywhere.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<CarEverywhereContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CarEverywhereContext") ?? throw new InvalidOperationException("Connection string 'CarEverywhereContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
