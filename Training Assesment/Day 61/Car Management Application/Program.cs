using Car_Management_Application.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDefaultIdentity<IdentityUser>(
        options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();   // ← you were also missing this!
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.MapRazorPages();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    db.Database.Migrate();

    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

    string[] roles = { "Admin", "Customer", "User" };
    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
            await roleManager.CreateAsync(new IdentityRole(role));
    }

    if (await userManager.FindByEmailAsync("admin@test.com") == null)
    {
        var admin = new IdentityUser { UserName = "admin@test.com", Email = "admin@test.com", EmailConfirmed = true };
        await userManager.CreateAsync(admin, "Admin@123");
        await userManager.AddToRoleAsync(admin, "Admin");
    }
    if (await userManager.FindByEmailAsync("customer@test.com") == null)
    {
        var customer = new IdentityUser { UserName = "customer@test.com", Email = "customer@test.com", EmailConfirmed = true };
        await userManager.CreateAsync(customer, "Customer@123");
        await userManager.AddToRoleAsync(customer, "Customer");
    }
    if (await userManager.FindByEmailAsync("user@test.com") == null)
    {
        var user = new IdentityUser { UserName = "user@test.com", Email = "user@test.com", EmailConfirmed = true };
        await userManager.CreateAsync(user, "User@123");
        await userManager.AddToRoleAsync(user, "User");
    }
}

app.Run();