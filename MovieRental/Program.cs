using Microsoft.EntityFrameworkCore;
using MovieRental.Data;
using MovieRental.Models;
using Microsoft.AspNetCore.Identity;
using MovieRental.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<MovieRentalContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MovieRentalContext") ?? throw new InvalidOperationException("Connection string 'MovieRentalContext' not found.")));

//builder.Services.AddDbContext<LoginContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("LoginContextConnection") ?? throw new InvalidOperationException("Connection string 'LoginContextConnection' not found.")));

builder.Services.AddDefaultIdentity<MovieRentalUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<LoginContext>();



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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Movies1}/{action=Index}/{id?}");

app.Run();
