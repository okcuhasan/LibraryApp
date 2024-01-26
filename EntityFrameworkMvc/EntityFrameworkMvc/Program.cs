using EntityFrameworkMvc.Data;
using EntityFrameworkMvc.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration
    .GetConnectionString("EfConnectionString")));


builder.Services.AddIdentity<ApplicationUser, IdentityRole>() 
        .AddEntityFrameworkStores<AppDbContext>() 
        .AddDefaultTokenProviders(); 


builder.Services.AddSession();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.User.AllowedUserNameCharacters = "ABCÇDEFGHÐIÝJKLMNOÖPRSÞTUÜVYZabcçdefghðýijklmnoöprsþtuüvyz";
});

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromDays(1);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    if (!roleManager.RoleExistsAsync("Admin").Result)
    {
        var adminRole = new IdentityRole("Admin");
        var result = roleManager.CreateAsync(adminRole).Result;
    }
    if (!roleManager.RoleExistsAsync("User").Result)
    {
        var adminRole = new IdentityRole("User");
        var result = roleManager.CreateAsync(adminRole).Result;
    }

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

app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Login}/{id?}");

app.Run();
