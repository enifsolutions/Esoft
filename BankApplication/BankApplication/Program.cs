var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddTransient<Banking.Business.AppUserBo.AppUserBo>();
builder.Services.AddTransient<Banking.Data.DatabaseUtility>();
builder.Services.AddTransient<Banking.Business.LoginBo.LoginBo>();

builder.Services.AddControllersWithViews();
builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(1800);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();



// Add session support
app.UseSession();

app.MapControllerRoute(
    name: "default",
     pattern: "{controller=login}/{action=login}/{id?}");


app.Run();
