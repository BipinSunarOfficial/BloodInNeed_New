using BloodInNeed.Data.DataAccess;
using BloodInNeed.Data.Repository;
using BloodInNeed.UI.DBCtx;
using BloodInNeed.UI.Models;
using BloodInNeed.UI.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;

var builder = WebApplication.CreateBuilder(args);



// Add Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
})
.AddCookie()
.AddGoogle(googleOptions =>
{
    googleOptions.ClientId = builder.Configuration["Authentication:Google:ClientId"];
    googleOptions.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"];
});


// Add services to the container.
//builder.Services.AddControllersWithViews();
builder.Services.AddControllersWithViews()
    .AddRazorRuntimeCompilation();

builder.Services.AddControllers();
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
builder.Services.AddScoped<ISqlDataAccess, SqlDataAccess>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<LogInService>();
builder.Services.AddTransient<SignupService>();
builder.Services.AddTransient<BaseService>();
builder.Services.AddTransient<SidebarMenuService>();
builder.Services.AddTransient<ProfileService>();


builder.Services.AddTransient<SideBarDBCtx>(); // Register SideBarDBCtx
builder.Services.AddScoped<LogInDBCtx>();
builder.Services.AddScoped<SignupDBCtx>();
builder.Services.AddScoped<BaseDBCtx>();
builder.Services.AddScoped<ProfileDBCtx>();

builder.Services.AddSession();


builder.Services.Configure<ApplicationSettings>(
builder.Configuration.GetSection("Application"));




// Add session services
builder.Services.AddDistributedMemoryCache(); // Use in-memory session storage
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Set session timeout
    options.Cookie.HttpOnly = true; // Protect against XSS
    options.Cookie.IsEssential = true; // Ensure cookies are essential
});





var app = builder.Build();

// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Home/Error");
//    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//    app.UseHsts();
//}


if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
 
app.UseRouting();


app.UseSession();

app.UseAuthorization();

app.UseDeveloperExceptionPage();


app.MapControllers();

app.MapControllerRoute
    (
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}"
    );

app.Run();
