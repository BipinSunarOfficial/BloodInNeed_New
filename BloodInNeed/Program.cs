using BloodInNeed.Data.DataAccess;
using BloodInNeed.Data.Repository;
using BloodInNeed.UI.DBCtx;
using BloodInNeed.UI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddControllers();
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
builder.Services.AddScoped<ISqlDataAccess, SqlDataAccess>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<LogInService>();
builder.Services.AddTransient<SidebarMenuService>();
builder.Services.AddTransient<SideBarDBCtx>(); // Register SideBarDBCtx
builder.Services.AddScoped<LogInDBCtx>();



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

app.UseRouting();

app.UseAuthorization();

app.UseDeveloperExceptionPage();


app.MapControllers();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();
