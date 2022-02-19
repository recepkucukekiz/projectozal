using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ozal.business.Abstract;
using ozal.business.Concrete;
using ozal.data.Abstract;
using ozal.data.Concrete.EfCore;
using ozal.webui.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlite("Data Source=ozalDb")); //identity
builder.Services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<ApplicationContext>().AddDefaultTokenProviders() ; //identity
builder.Services.Configure<IdentityOptions>(options => {
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 8;
    options.Password.RequireNonAlphanumeric = true;

    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.AllowedForNewUsers = true;

    options.User.RequireUniqueEmail = true;
    options.SignIn.RequireConfirmedEmail = false;
});
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/account/login"; //yönlendirmeler
    options.LogoutPath = "/account/logout";
    options.AccessDeniedPath = "/account/accessdenied";
    options.SlidingExpiration = true; //cookie timeout 20 min ve her request de yenilenecek
    options.ExpireTimeSpan = TimeSpan.FromMinutes(30); //artık 30 dk
    options.Cookie = new CookieBuilder
    {
        HttpOnly = true, // for security
        Name = ".Ozal.Security.Cookie"
    };
});

builder.Services.AddScoped<IProductRepository, EfCoreProductRepository>(); //injection
builder.Services.AddScoped<IProductService,ProductManager>();
builder.Services.AddScoped<ICareRepository, EfCoreCareRepository>(); //injection
builder.Services.AddScoped<ICareService,CareManager>();
builder.Services.AddScoped<IRepairRepository, EfCoreRepairRepository>(); //injection
builder.Services.AddScoped<IRepairService,ReapirManager>();
builder.Services.AddScoped<IStatusRepository,EfCoreStatusRepository>(); //injection
builder.Services.AddScoped<IStatusService,StatusManager>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthentication(); //identy
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
