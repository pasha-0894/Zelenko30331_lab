using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Zelenko30331_lab.Data;
using Zelenko30331_lab.Services;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Zelenko30331_lab.TagHelpers;
using Zelenko30331_lab.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString =builder.Configuration.GetConnectionString("SqLiteConnection")?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>options.UseSqlite(connectionString)); 
//builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

//MemoryCategoryService
builder.Services.AddScoped<ICategoryService, MemoryCategoryService>();
//MemoryAssetService
builder.Services.AddScoped<IProductService, MemoryProductService>();
//RazorPages
builder.Services.AddHttpContextAccessor();

builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = true;
    options.Password.RequireDigit = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
})
.AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddAuthorization(opt =>
{
    opt.AddPolicy("admin", p =>
    p.RequireClaim(ClaimTypes.Role, "admin"));
});
builder.Services.AddSingleton<IEmailSender, NoOpEmailSender>();

builder.Services.AddHttpClient<ICategoryService, ApiCategoryService>(opt => opt.BaseAddress = new Uri("https://localhost:7002/api/categories"));
builder.Services.AddHttpClient<IProductService, ApiProductService>(opt => opt.BaseAddress = new Uri("https://localhost:7002/api/dishes"));

builder.Services.AddControllersWithViews();

var app = builder.Build();

await DBInt.SetupIdentityAdmin(app);
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
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
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
