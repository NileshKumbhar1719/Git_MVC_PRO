using Git_MVC_PRO.Data;
using Git_MVC_PRO.Repogitory;
using Git_MVC_PRO.Service;
using Microsoft.EntityFrameworkCore;
using Git_MVC_PRO.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using NLog;
using NLog.Web;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Git_MVC_PRO.Middleware;

var builder = WebApplication.CreateBuilder(args);

var logger = LogManager.Setup().LoadConfigurationFromFile("nlog.config").GetCurrentClassLogger();
builder.Logging.ClearProviders();

// Register NLog
builder.Host.UseNLog();

// Add services to the container.
builder.Services.AddControllersWithViews();

// Database Context
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaulConnection"));
});

builder.Services.AddDbContext<LoginContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaulConnection"));
});

// Identity (ONLY ONCE)
builder.Services.AddDefaultIdentity<UserRegister>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
})
.AddRoles<IdentityRole>()
.AddEntityFrameworkStores<LoginContext>();




// Dependency Injection
builder.Services.AddScoped<IDepartments, Depart>();
builder.Services.AddScoped<IDepartService, DepartService>();
builder.Services.AddScoped<IEmployees, Employee>();
builder.Services.AddScoped<IEmployeesService, EmployeesService>();


logger.Info("++===============================Server Start==================================++");
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

    if (!await roleManager.RoleExistsAsync("Admin"))
        await roleManager.CreateAsync(new IdentityRole("Admin"));

    if (!await roleManager.RoleExistsAsync("User"))
        await roleManager.CreateAsync(new IdentityRole("User"));
}

// Create Roles Automatically
//using (var scope = app.Services.CreateScope())
//{
//    var services = scope.ServiceProvider;

//    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

//    string[] roles = { "Admin", "User" };

//    foreach (var role in roles)
//    {
//        if (!await roleManager.RoleExistsAsync(role))
//        {
//            await roleManager.CreateAsync(new IdentityRole(role));
//        }
//    }
//}


// Configure HTTP pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// IMPORTANT
app.UseAuthentication();
app.UseAuthorization();

app.UseCustomRateLimiting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();