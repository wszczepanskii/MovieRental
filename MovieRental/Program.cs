using Microsoft.EntityFrameworkCore;
using MovieRental.Data;
using MovieRental.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<MovieRentalContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MovieRentalContext") ?? throw new InvalidOperationException("Connection string 'MovieRentalContext' not found.")));



// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
}


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Movies1}/{action=Index}/{id?}");

app.Run();
