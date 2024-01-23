using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MovieRental.Data;
using MovieRental.Models;
using Microsoft.AspNetCore.Identity.UI.Services;
using MovieRental.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddTransient<IEmailSender, EmailSender>();

builder.Services.AddDbContext<MovieRentalContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MovieRentalContext") ?? throw new InvalidOperationException("Connection string 'MovieRentalContext' not found.")));

builder.Services.AddDefaultIdentity<AppUser>(
    options => options.SignIn.RequireConfirmedAccount = true
)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<MovieRentalContext>();

//builder.Services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<MovieRentalContext>().AddDefaultTokenProviders();
//builder.Services.ConfigureApplicationCookie(options => options.LoginPath = "/UserAuthentication/Login");

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
app.MapRazorPages();

app.Run();
