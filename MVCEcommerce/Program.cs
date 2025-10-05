using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MVCEcommerce;
using MVCECommerceData;
using NETCore.MailKit.Extensions;
using NETCore.MailKit.Infrastructure.Internal;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews(); //*
builder.Services.AddDbContext<DbcontextEcommerce>(config=>
{
    AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    config.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
    //config.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder
    .Services
    .AddIdentity<User, Role>(config =>
    {
        config.Password.RequireDigit = builder.Configuration.GetValue<bool>("Identity:RequireDigit");
        config.Password.RequireLowercase = builder.Configuration.GetValue<bool>("Identity:RequireLowercase");
        config.Password.RequireUppercase = builder.Configuration.GetValue<bool>("Identity:RequireUppercase");
        config.Password.RequireNonAlphanumeric = builder.Configuration.GetValue<bool>("Identity:RequireNonAlphanumeric");
        config.Password.RequiredLength = builder.Configuration.GetValue<int>("Identity:RequiredLength");
        config.Password.RequiredUniqueChars = builder.Configuration.GetValue<int>("Identity:RequiredUniqueChars");

        config.User.RequireUniqueEmail = true;
        config.Lockout.MaxFailedAccessAttempts = 5;
        config.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);

        config.SignIn.RequireConfirmedEmail = true;
    })
    .AddEntityFrameworkStores<DbcontextEcommerce>()
    .AddDefaultTokenProviders();  //token üretir email onay _ reset password için


builder
    .Services
    .AddMailKit(config =>
    {
        config.UseMailKit(new MailKitOptions
        {
            Server = "sandbox.smtp.mailtrap.io",
            Port = 2525,
            SenderName = "MVCEcommerce Hesap",
            SenderEmail = "hesap@mvcforum.com",
            Account = "1dbd08a42eee36",
            Password = "94db0de79ecb1e",
            Security = true,



        });
    });



var app = builder.Build();

app.UseStaticFiles(); //*wwwroot için 

app.UseAuthorization();  //yetki
app.UseAuthentication(); //giriþ yetkisi

app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
          );

app.MapControllerRoute( 
    name: "Default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

using var scope = app.Services.CreateScope();
using var dbContext = scope.ServiceProvider.GetRequiredService<DbcontextEcommerce>();
using var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<Role>>();
using var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
dbContext.Database.Migrate();

new[]
{

new Role {DisplayName= "Yöneticiler" , Name = "Administrators", },
new Role {DisplayName= "Ürün Yöneticileri" , Name = "ProductAdministrators", },
new Role {DisplayName= "Sepet Yöneticileri" , Name = "OrderAdministrators", },
new Role {DisplayName= "Üyeler" , Name = "Members" , },
}.ToList()
.ForEach(p =>
{
    roleManager.CreateAsync(p).Wait();
});


var user = new User {

    Date = DateTime.Now,
    Gender = Genders.Male,
    GivenName = "Ecommerce Admin", 
    UserName = "admin@mvc.com",
    Email = " admin@mvc.com",
};

userManager.CreateAsync(user, "1").Wait();
userManager.AddToRoleAsync(user , "Administrators").Wait();
app.Run();
